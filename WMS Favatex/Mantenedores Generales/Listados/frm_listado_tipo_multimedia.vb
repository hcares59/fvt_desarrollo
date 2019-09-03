Public Class frm_listado_tipo_multimedia
    Private _cnn As String
    Dim paso As String
    Dim cargaPrimeraVez As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_tipo_multimedia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        cargaPrimeraVez = False
        Call INICIALIZA()
        cargaPrimeraVez = True
    End Sub
    Private Sub INICIALIZA()
        Me.WindowState = FormWindowState.Maximized
        lblTotal.Text = "Cantidad de registros encontrados: 0"
        Call CARGA_GRILLA()
    End Sub

    Private Sub CARGA_GRILLA()
        '_cnn = "Data Source=CL-MV031;Initial Catalog=Productos;User ID=sa;Password=qwe123.,"
        Dim classTMUL As class_tipomultimedia = New class_tipomultimedia

        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classTMUL.cnn = _cnn
            classTMUL.tmu_codigo = 0
            classTMUL.todos = chkActivo.Checked

            _msg = ""

            Grilla.Rows.Clear()
            ds = classTMUL.TIPO_MULTIMEDIA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("tmu_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("tmu_codigo"),
                                            ds.Tables(0).Rows(Fila)("tmu_nombre"),
                                            ds.Tables(0).Rows(Fila)("tmu_activo"))
                            Fila = Fila + 1
                        Loop

                    End If
                    lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                End If
                Me.Text = "LISTADO DE TIPOS DE MULTIMEDIA - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\carga_grila", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grila", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_ingreso_tipo_multimedia = New frm_ingreso_tipo_multimedia
        frm.cnn = _cnn
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 3 Then
                Dim frm As frm_ingreso_tipo_multimedia = New frm_ingreso_tipo_multimedia
                frm.cnn = _cnn
                frm.tmu_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 4 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    paso = Grilla.Rows(e.RowIndex).Cells(0).Value
                    Call ELIMINA_REGISTRO(Grilla.Rows(e.RowIndex).Cells(0).Value)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ELIMINA_REGISTRO(ByVal codigo As Integer)
        Dim classTMUL As class_tipomultimedia = New class_tipomultimedia
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""

        Try
            ds = Nothing
            classTMUL.cnn = _cnn
            classTMUL.tmu_codigo = codigo

            ds = classTMUL.TIPO_MULTIMEDIA_ELIMINA_REGISTRO(_msgError)
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

    Private Sub chkActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivo.CheckedChanged
        If cargaPrimeraVez = True Then
            Call CARGA_GRILLA()
        End If
    End Sub
End Class