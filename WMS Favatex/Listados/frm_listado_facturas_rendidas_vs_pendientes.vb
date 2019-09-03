Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_listado_facturas_rendidas_vs_pendientes
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_facturas_rendidas_vs_pendientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializa()
    End Sub

    Private Sub Inicializa()
        Call carga_combo_cliente()
        lblTotal.Text = "Total de registros: 0"
        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized
        GLO_FECHA_SISTEMA = Date.Today
        dtpRecepcionDesde.Value = GLO_FECHA_SISTEMA
        lblTotal.Text = ""
    End Sub
    Private Sub carga_combo_cliente()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE_DESPACHA_CON_FACTURA(_msg)
            'ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
            If _msg = "" Then
                Me.cmbCliente.DataSource = ds.Tables(0)
                Me.cmbCliente.DisplayMember = "MENSAJE"
                Me.cmbCliente.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CLIENTE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If cmbCliente.Text = "" Then
            MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Sub
        Else
            Call carga_grilla()
        End If
    End Sub

    Private Sub carga_grilla()
        Dim class_informes As class_informes = New class_informes
        Dim Fila As Integer = 0
        Dim diaRendicionesDesde As String = ""
        Dim mesRendicionesDesde As String = ""
        Dim mesRendicionesHasta As String = ""
        Dim diaRendicionesHasta As String = ""
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            class_informes.cnn = _cnn
            class_informes.car_codigo = cmbCliente.SelectedValue

            If chkRecepcion.Checked = True Then
                If CStr(dtpRecepcionDesde.Value.Month).Length = 1 Then
                    mesRendicionesDesde = Trim("0" + CStr(dtpRecepcionDesde.Value.Month))
                Else
                    mesRendicionesDesde = CStr(dtpRecepcionDesde.Value.Month)
                End If

                If CStr(dtpRecepcionDesde.Value.Day).Length = 1 Then
                    diaRendicionesDesde = Trim("0" + CStr(dtpRecepcionDesde.Value.Day))
                Else
                    diaRendicionesDesde = CStr(dtpRecepcionDesde.Value.Day)
                End If
                class_informes.str_fechaDesde = CStr(dtpRecepcionDesde.Value.Year) + mesRendicionesDesde + diaRendicionesDesde


                If CStr(dtpRecepcionHasta.Value.Month).Length = 1 Then
                    mesRendicionesHasta = Trim("0" + CStr(dtpRecepcionHasta.Value.Month))
                Else
                    mesRendicionesHasta = CStr(dtpRecepcionHasta.Value.Month)
                End If

                If CStr(dtpRecepcionHasta.Value.Day).Length = 1 Then
                    diaRendicionesHasta = Trim("0" + CStr(dtpRecepcionHasta.Value.Day))
                Else
                    diaRendicionesHasta = CStr(dtpRecepcionHasta.Value.Day)
                End If
                class_informes.str_fechaHasta = CStr(dtpRecepcionHasta.Value.Year) + mesRendicionesHasta + diaRendicionesHasta


            Else
                class_informes.str_fechaDesde = "19000101"
                class_informes.str_fechaHasta = "20501231"
            End If

            If cmbEstado.Text = "" Then
                class_informes.estado = "-"
            Else
                class_informes.estado = cmbEstado.Text
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = class_informes.carga_facturas_rendidas_vs_por_rendir_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("emd_nfactura"),
                                            ds.Tables(0).Rows(Fila)("fec_fecha"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("fac_total"), 0),
                                            ds.Tables(0).Rows(Fila)("car_rut"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("car_estado"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = Me.Text + " :" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "LISTADO DE FACTURAS RENDIDAS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            Cursor = System.Windows.Forms.Cursors.Default
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonExportar_Click(sender As Object, e As EventArgs) Handles ButtonExportar.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0

        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                                + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            class_comunes.ExportarExcel(Me.Grilla)
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkRecepcion_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecepcion.CheckedChanged
        If chkRecepcion.Checked = True Then
            dtpRecepcionDesde.Enabled = True
            dtpRecepcionHasta.Enabled = True
        Else
            dtpRecepcionDesde.Enabled = False
            dtpRecepcionHasta.Enabled = False
        End If
    End Sub
End Class