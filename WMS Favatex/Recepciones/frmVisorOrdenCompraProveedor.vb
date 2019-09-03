Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frmVisorOrdenCompraProveedor
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frmVisorOrdenCompraProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Call CARGA_COMBO_PROBVEEDOR()
        Call CARGA_COMBO_EJECUTA_RECEPCION()

        cmbAsignarA.Enabled = True
        If USU_EJECUTA_RECEPCION = True Then
            cmbAsignarA.SelectedValue = GLO_USUARIO_ACTUAL
            cmbAsignarA.Enabled = False
        End If

        Call CARGA_GRILLA()

    End Sub

    Private Sub CARGA_GRILLA()
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classOC.cnn = _cnn

            classOC.usu_actual = GLO_USUARIO_ACTUAL

            If cmbProveedor.Text = "" Then
                classOC.car_codigo = 0
            Else
                classOC.car_codigo = cmbProveedor.SelectedValue
            End If

            If cmbAsignarA.Text = "" Then
                classOC.usu_recepcion = 0
            Else
                classOC.usu_recepcion = cmbAsignarA.SelectedValue
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = classOC.OC_PROVEEDORES_LISTAR_VISOR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("ocp_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_numero"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechaorden"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechallegada"),
                                            ds.Tables(0).Rows(Fila)("eoc_nombre"),
                                            ds.Tables(0).Rows(Fila)("ere_nombre"),
                                            ds.Tables(0).Rows(Fila)("eoc_codigo"))
                            Fila = Fila + 1
                        Loop

                        Grilla.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


                    End If
                End If
                Me.Text = "LISTADO DE ORDENES DE COMRPA - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_PROBVEEDOR()
        Dim _msg As String
        Try
            Dim classProveedor As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classProveedor.cnn = _cnn
            _msg = ""
            ds = classProveedor.CARGA_COMBO_PROVEEDOR(_msg)
            If _msg = "" Then
                Me.cmbProveedor.DataSource = ds.Tables(0)
                Me.cmbProveedor.DisplayMember = "MENSAJE"
                Me.cmbProveedor.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROBVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_EJECUTA_RECEPCION()
        Dim _msg As String
        Try
            Dim classUsuario As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classUsuario.cnn = _cnn
            ds = classUsuario.CARGA_COMBO_EJECUTA_RECEPCION(_msg)
            If _msg = "" Then
                Me.cmbAsignarA.DataSource = ds.Tables(0)
                Me.cmbAsignarA.DisplayMember = "MENSAJE"
                Me.cmbAsignarA.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROBVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 9 Then
                Dim frm As rec_orden_compra = New rec_orden_compra
                frm.cnn = _cnn
                frm.ocp_codigo = Grilla.Rows(e.RowIndex).Cells(1).Value
                frm.eoc_codigo = Grilla.Rows(e.RowIndex).Cells(8).Value
                frm.viene = "V"
                frm.ShowDialog()
                Call CARGA_GRILLA()
                'ElseIf e.ColumnIndex = 9 Then
                '    Dim respuesta As Integer
                '    respuesta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                '    If respuesta = vbNo Then
                '        Exit Sub
                '    End If

                '    If (Grilla.Rows(e.RowIndex).Cells(7).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.ANULADA) Or (Grilla.Rows(e.RowIndex).Cells(7).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.ARRIBADA) _
                '        Or (Grilla.Rows(e.RowIndex).Cells(7).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.EN_TRANSITO) Then
                '        MessageBox.Show("No es posible eliminar una orden de compra en estado: " + Grilla.Rows(e.RowIndex).Cells(6).Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Exit Sub
                '    End If

                '    Call ELIMINA_ORDEN_COMPRA(Grilla.Rows(e.RowIndex).Cells(1).Value)

            ElseIf e.ColumnIndex = 10 Then
                Dim strCodigos As String = ""


                If EXISTE_VULOMETRIA(Grilla.Rows(e.RowIndex).Cells(1).Value, "OC", strCodigos) = True Then
                    If strCodigos <> "" Then
                        MessageBox.Show("Se requiere completar los datos de volumetria para los siguientes codigos: " _
                                + Chr(10) + "" + strCodigos, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                Dim frm As frm_paletiza_oc = New frm_paletiza_oc
                frm.cnn = _cnn
                frm.ocp_codigo = Grilla.Rows(e.RowIndex).Cells(1).Value
                frm.ShowDialog()

                'ElseIf e.ColumnIndex = 11 Then

                '    If (Grilla.Rows(e.RowIndex).Cells(7).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.ANULADA) Or (Grilla.Rows(e.RowIndex).Cells(7).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.ARRIBADA) Then
                '        MessageBox.Show("No es posible generar una recepción en estado: " + Grilla.Rows(e.RowIndex).Cells(6).Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Exit Sub
                '    End If

                '    Dim frm As frm_recepcion = New frm_recepcion
                '    frm.cnn = _cnn
                '    frm.car_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                '    frm.opd_numero = Grilla.Rows(e.RowIndex).Cells(3).Value
                '    frm.ShowDialog()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function EXISTE_VULOMETRIA(ByVal recNumero As Integer, ByVal tipDocumento As String, ByRef Codigos As String) As Boolean
        Dim classProducto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_VULOMETRIA = False
        Try
            classProducto.cnn = _cnn
            classProducto.numDocumento = recNumero
            classProducto.tipDocumento = tipDocumento

            ds = classProducto.OBTIENE_VOLUMETRIA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigos") <> "" Then
                        Codigos = ds.Tables(0).Rows(Fila)("codigos")
                        EXISTE_VULOMETRIA = True
                    End If
                End If
            Else
                EXISTE_VULOMETRIA = False
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            EXISTE_VULOMETRIA = False
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class