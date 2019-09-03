Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_visor_recepciones
    Private _cnn As String

    Const COL_CAR_CODIGO As Integer = 0
    Const COL_CAR_NOMBRE As Integer = 1
    Const COL_NUM_RECEPC As Integer = 2
    Const COL_FEC_RECEPC As Integer = 3
    Const COL_NUM_OCOMPR As Integer = 4
    Const COL_FEC_OCOMPR As Integer = 5
    Const COL_ERE_CODIGO As Integer = 6
    Const COL_ERE_NOMBRE As Integer = 7
    Const COL_VER_RECEPC As Integer = 8
    Const COL_VER_ALMACE As Integer = 9

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_visor_recepciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Call CARGA_COMBO_PROBVEEDOR()
        Call CARGA_COMBO_EJECUTA_ALMACENAMIENTO()

        cmbAsignarA.Enabled = True
        If USU_EJECUTA_ALMACENAMIENTO = True Then
            cmbAsignarA.SelectedValue = GLO_USUARIO_ACTUAL
            cmbAsignarA.Enabled = False
        End If

        Call CARGA_GRILLA()
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classRecepcion.cnn = _cnn

            classRecepcion.usu_codigo = GLO_USUARIO_ACTUAL

            If cmbProveedor.Text = "" Then
                classRecepcion.car_codigo = 0
            Else
                classRecepcion.car_codigo = cmbProveedor.SelectedValue
            End If

            'If cmbAsignarA.Text = "" Then
            '    classRecepcion.usu_recepcion = 0
            'Else
            '    classRecepcion.usu_recepcion = cmbAsignarA.SelectedValue
            'End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = classRecepcion.RECEPCION_LISTAR_VISOR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("rec_numero"),
                                            ds.Tables(0).Rows(Fila)("rec_fecharecepcion"),
                                            ds.Tables(0).Rows(Fila)("ocp_numero"),
                                            ds.Tables(0).Rows(Fila)("ocp_fecha"),
                                            ds.Tables(0).Rows(Fila)("ere_codigo"),
                                            ds.Tables(0).Rows(Fila)("ere_nombre"))
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

                    End If
                End If
                Me.Text = "LISTADO DE RECEPCIONES - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
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

    Private Sub CARGA_COMBO_EJECUTA_ALMACENAMIENTO()
        Dim _msg As String
        Try
            Dim classUsuario As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classUsuario.cnn = _cnn
            ds = classUsuario.CARGA_COMBO_EJECUTA_ALMACENAMIENTO(_msg)
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

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = COL_VER_RECEPC Then
                Dim frm As frm_recepcion = New frm_recepcion
                frm.cnn = _cnn
                frm.rec_codigo = Grilla.Rows(e.RowIndex).Cells(COL_NUM_RECEPC).Value
                frm.ere_codigo = Grilla.Rows(e.RowIndex).Cells(COL_ERE_CODIGO).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()

            ElseIf e.ColumnIndex = COL_VER_ALMACE Then

                If VERIFICA_ASIGNACIONES_PENDIENTES(Grilla.Rows(e.RowIndex).Cells(COL_NUM_RECEPC).Value) = True Then
                    MessageBox.Show("La recepción tiene documentos de asignaciones pendiente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim frm As frm_asignacion_ubicaciones = New frm_asignacion_ubicaciones
                frm.cnn = _cnn
                frm.recNumero = Grilla.Rows(e.RowIndex).Cells(COL_NUM_RECEPC).Value
                frm.asiNumero = 0
                frm.ShowDialog()
                Call CARGA_GRILLA()



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function VERIFICA_ASIGNACIONES_PENDIENTES(ByVal numReserva As Integer) As Boolean
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0

        VERIFICA_ASIGNACIONES_PENDIENTES = False
        Try

            classUbicacion.cnn = _cnn
            classUbicacion.rec_numero = numReserva
            ds = classUbicacion.VALIDA_ASIGNACIONES_PENDIENTE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("cantidad") > 0 Then
                        VERIFICA_ASIGNACIONES_PENDIENTES = True
                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\VERIFICA_ASIGNACIONES_PENDIENTES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\VERIFICA_ASIGNACIONES_PENDIENTES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

End Class