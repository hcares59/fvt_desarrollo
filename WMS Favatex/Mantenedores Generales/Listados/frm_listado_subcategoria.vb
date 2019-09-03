
Public Class frm_listado_subcategoria
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

    Private Sub frm_listado_subcategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaPrimeraVez = False
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Call INICIALIZA()
        cargaPrimeraVez = True
    End Sub

    Private Sub INICIALIZA()
        Me.WindowState = FormWindowState.Maximized
        lblTotal.Text = "Cantidad de registros encontrados: 0"

        cmbCategorias.DataSource = Nothing
        cmbCategorias.Items.Clear()

        Call CARGA_COMBO_CATEGORIAS()
        Call CARGA_GRILLA()
    End Sub

    Private Sub CARGA_COMBO_CATEGORIAS()
        Dim _msg As String
        Try
            Dim classCategoria As class_categorias = New class_categorias
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCategoria.cnn = _cnn
            _msg = ""
            ds = classCategoria.CARGA_COMBO_CATEGORIA(_msg)
            If _msg = "" Then
                Me.cmbCategorias.DataSource = ds.Tables(0)
                Me.cmbCategorias.DisplayMember = "MENSAJE"
                Me.cmbCategorias.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CATEGORIAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA()
        Dim class_subcategorias As class_subcategoria = New class_subcategoria
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_subcategorias.cnn = _cnn
            class_subcategorias.sub_codigo = 0

            If cmbCategorias.Text = "" Then
                class_subcategorias.cat_codigo = 0
            Else
                class_subcategorias.cat_codigo = cmbCategorias.SelectedValue
            End If

            class_subcategorias.todos = chkActivo.Checked

            _msg = ""
            Grilla.Rows.Clear()
            ds = class_subcategorias.SUBCATEGORIA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("sub_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("sub_codigo"),
                                            ds.Tables(0).Rows(Fila)("cat_codigo"),
                                            ds.Tables(0).Rows(Fila)("cat_nombre"),
                                            ds.Tables(0).Rows(Fila)("sub_nombre"),
                                            ds.Tables(0).Rows(Fila)("sub_abreviacion"),
                                            ds.Tables(0).Rows(Fila)("sub_activo"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                Me.Text = "LISTADO DE SUBCATEGORIA - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_ingreso_subcategoria = New frm_ingreso_subcategoria
        frm.cnn = _cnn
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 6 Then
                Dim frm As frm_ingreso_subcategoria = New frm_ingreso_subcategoria
                frm.cnn = _cnn
                frm.sub_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 7 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    paso = Grilla.Rows(e.RowIndex).Cells(0).Value
                    Call elimina_registro(Grilla.Rows(e.RowIndex).Cells(0).Value)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ELIMINA_REGISTRO(ByVal Codigo As Integer)
        Dim classSubcategorias As class_subcategoria = New class_subcategoria
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""

        Try
            ds = Nothing
            classSubcategorias.cnn = _cnn
            classSubcategorias.sub_codigo = Codigo

            ds = classSubcategorias.SUBCATEGORIA_ELIMINA_REGISTRO(_msgError)
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

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub
End Class