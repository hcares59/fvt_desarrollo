Public Class frm_listado_tipo_vehiculo
    Private _cnn As String
    Dim cargaPrimeraVez As Boolean
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_tipo_vehiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        cargaPrimeraVez = False
        Call INICIALIZA()
        cargaPrimeraVez = True
    End Sub
    Private Sub INICIALIZA()
        Me.WindowState = FormWindowState.Maximized
        Call CARGA_GRILLA()
    End Sub
    Private Sub CARGA_GRILLA()
        Dim classTipoVehiculo As class_tipo_vehiculo = New class_tipo_vehiculo
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classTipoVehiculo.cnn = _cnn
            classTipoVehiculo.tve_codigo = 0
            classTipoVehiculo.todos = chkActivo.Checked

            _msg = ""
            Grilla.Rows.Clear()
            ds = classTipoVehiculo.TIPO_VEHICULO_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("tve_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("tve_codigo"),
                                            ds.Tables(0).Rows(Fila)("tve_nombre"),
                                            ds.Tables(0).Rows(Fila)("tve_activo"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                Me.Text = "LISTADO DE TIPOS DE VEHICULOS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grila", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 3 Then
                Dim frm As frm_tipo_vehiculo = New frm_tipo_vehiculo
                frm.cnn = _cnn
                frm.tve_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 4 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Call elimina_registro(Grilla.Rows(e.RowIndex).Cells(0).Value)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ELIMINA_REGISTRO(ByVal tve_codigo As Integer)
        Dim classTipoVehiculo As class_tipo_vehiculo = New class_tipo_vehiculo
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""
        Try
            ds = Nothing
            classTipoVehiculo.cnn = _cnn
            classTipoVehiculo.tve_codigo = tve_codigo
            ds = classTipoVehiculo.TIPO_VEHICULO_ELIMINA(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CARGA_GRILLA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub
    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub chkActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivo.CheckedChanged
        If cargaPrimeraVez = True Then
            Call CARGA_GRILLA()
        End If
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_tipo_vehiculo = New frm_tipo_vehiculo
        frm.cnn = _cnn
        frm.tve_codigo = 0
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub
End Class