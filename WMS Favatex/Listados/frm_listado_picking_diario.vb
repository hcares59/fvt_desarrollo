Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_listado_picking_diario
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_picking_diario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized
        Me.Grilla.Columns(3).Frozen = True
        dtpCompromisoDesde.Value = GLO_FECHA_SISTEMA
        lblTotal.Text = ""

        Call CARGA_COMBO_ESTADO_PICKING()
    End Sub

    Private Sub CARGA_COMBO_ESTADO_PICKING()
        Dim _msg As String
        Try
            Dim classComun As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classComun.cnn = _cnn
            _msg = ""
            ds = classComun.CRGA_COMBO_ESTADO_PICKING(_msg)
            If _msg = "" Then
                Me.cmbEstaddo.DataSource = ds.Tables(0)
                Me.cmbEstaddo.DisplayMember = "MENSAJE"
                Me.cmbEstaddo.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ESTADO_PICKING", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classPicking As class_picking = New class_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Dim diaCompromisoDesde As String = ""
        Dim mesCompromisoDesde As String = ""
        Dim mesCompromisoHasta As String = ""
        Dim diaCompromisoHasta As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classPicking.cnn = _cnn


            'fecha compromiso desde
            If CStr(dtpCompromisoDesde.Value.Month).Length = 1 Then
                mesCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Month))
            Else
                mesCompromisoDesde = CStr(dtpCompromisoDesde.Value.Month)
            End If

            If CStr(dtpCompromisoDesde.Value.Day).Length = 1 Then
                diaCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Day))
            Else
                diaCompromisoDesde = CStr(dtpCompromisoDesde.Value.Day)
            End If
            classPicking.fecha_entrega_desde = CStr(dtpCompromisoDesde.Value.Year) + mesCompromisoDesde + diaCompromisoDesde

            'fecha compromiso hasta
            If CStr(dtpCompromisoHasta.Value.Month).Length = 1 Then
                mesCompromisoHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Month))
            Else
                mesCompromisoHasta = CStr(dtpCompromisoHasta.Value.Month)
            End If

            If CStr(dtpCompromisoHasta.Value.Day).Length = 1 Then
                diaCompromisoHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Day))
            Else
                diaCompromisoHasta = CStr(dtpCompromisoHasta.Value.Day)
            End If
            classPicking.fecha_entrega_hasta = CStr(dtpCompromisoHasta.Value.Year) + mesCompromisoHasta + diaCompromisoHasta


            If txtNumPicking.Text = "0" Or txtNumPicking.Text = "" Then
                classPicking.pic_codigo = 0
            Else
                classPicking.pic_codigo = CInt(txtNumPicking.Text)
            End If

            If cmbEstaddo.Text = "" Then
                classPicking.epc_codigo = 0
            Else
                classPicking.epc_codigo = cmbEstaddo.SelectedValue
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.PICKING_LISTADO_PICKING_DIARIO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("fecha"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("pic_cantidad"),
                                            ds.Tables(0).Rows(Fila)("pic_cantidad_encontrada"),
                                            ds.Tables(0).Rows(Fila)("pic_num_bultos"),
                                            ds.Tables(0).Rows(Fila)("pic_num_bultos_encontrado"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "CONSOLIDADO DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        Dim frm As frm_imprimir = New frm_imprimir
        frm.Origen = "PKD"

        If txtNumPicking.Text = "" Or txtNumPicking.Text = "" Then
            frm.pic_codigo = 0
        Else
            frm.pic_codigo = CInt(txtNumPicking.Text)
        End If

        frm.strFecha = dtpCompromisoDesde.Text

        frm.ShowDialog()
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
End Class