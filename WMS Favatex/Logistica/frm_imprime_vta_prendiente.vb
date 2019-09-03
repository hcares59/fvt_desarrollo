Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_imprime_vta_prendiente
    Private _cnn As String
    Dim IdImpresion As Integer = 0

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frm_imprime_vta_prendiente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CARGA_COMBO_CLIENTE()
        Call CARGA_COMBO_ESTADO()
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msg As String
        Dim Fila As Integer = 0
        Try
            ds = Nothing
            classPicking.cnn = _cnn

            If cmbCliente.Text = "" Then
                classPicking.car_codigo = 0
            Else
                classPicking.car_codigo = cmbCliente.SelectedValue
            End If

            'If cmbEstado.Text = "" Then
            '    classPicking.epc_codigo = 0
            'Else
            classPicking.epc_codigo = cmbEstado.SelectedValue
            'End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.PICKING_VENTAS_PENDIENTES(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("cliente") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("cliente"),
                                            ds.Tables(0).Rows(Fila)("estado"),
                                            ds.Tables(0).Rows(Fila)("fecha"),
                                            ds.Tables(0).Rows(Fila)("ordenCompra"),
                                            ds.Tables(0).Rows(Fila)("codigoFavatex"),
                                            ds.Tables(0).Rows(Fila)("codigoCliente"),
                                            ds.Tables(0).Rows(Fila)("nombreCliente"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("totalBultos"),
                                            ds.Tables(0).Rows(Fila)("precio"),
                                            ds.Tables(0).Rows(Fila)("total"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_CLIENTE()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
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

    Private Sub CARGA_COMBO_ESTADO()
        Dim _msg As String
        Try
            Dim classEstado As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classEstado.cnn = _cnn
            _msg = ""
            ds = classEstado.CRGA_COMBO_ESTADO_PICKING(_msg)
            If _msg = "" Then
                Me.cmbEstado.DataSource = ds.Tables(0)
                Me.cmbEstado.DisplayMember = "MENSAJE"
                Me.cmbEstado.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ESTADO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        If optAgrupado.Checked = True Then
            Call IMPRIME_VRNTAS_PENDIENTES()
        ElseIf optListado.Checked = True Then
            Call CARGA_GRILLA()

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
        End If
    End Sub

    Private Sub IMPRIME_VRNTAS_PENDIENTES()
        Dim frm As frm_imprimir = New frm_imprimir
        Dim ds As DataSet = New DataSet
        Dim car_codigo As Integer = 0
        Dim epc_codigo As Integer = 0
        Dim nombreCliente As String = ""
        Dim nombreEstado As String = ""

        Try
            ds = Nothing

            If cmbCliente.Text = "" Then
                car_codigo = 0
                nombreCliente = "TODOS"
            Else
                car_codigo = cmbCliente.SelectedValue
                nombreCliente = cmbCliente.Text
            End If

            epc_codigo = cmbEstado.SelectedValue
            nombreEstado = cmbEstado.Text


            frm.Origen = "IMP_VTAP"
            frm.car_codigo = car_codigo
            frm.epc_codigo = epc_codigo
            frm.nomCliente = nombreCliente
            frm.nomEstado = nombreEstado
            frm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



End Class