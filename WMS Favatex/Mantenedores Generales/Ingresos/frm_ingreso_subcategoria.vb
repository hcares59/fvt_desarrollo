Public Class frm_ingreso_subcategoria
    Private _cnn As String
    Private _sub_codigo As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property sub_codigo() As Integer
        Get
            Return _sub_codigo
        End Get
        Set(ByVal value As Integer)
            _sub_codigo = value
        End Set
    End Property
    Private Sub frm_ingreso_subcategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbCategorias.Enabled = True
        If _sub_codigo > 0 Then
            Call CARGA_COMBO_CATEGORIAS()
            Call CARGA_REGISTRO()
            cmbCategorias.Enabled = False
        Else
            Call INICIALIZA()
        End If
    End Sub
    Private Sub INICIALIZA()
        cmbCategorias.DataSource = Nothing
        cmbCategorias.Items.Clear()

        Call CARGA_COMBO_CATEGORIAS()

        txtSubCategoria.Text = ""
        txtAbrevi.Text = ""
        _sub_codigo = 0
        txtSubCategoria.Focus()
        chkActivo.Checked = True
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

    Private Sub CARGA_REGISTRO()
        Dim classSubcategorias As class_subcategoria = New class_subcategoria
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classSubcategorias.cnn = _cnn
            classSubcategorias.sub_codigo = _sub_codigo

            _msg = ""
            ds = classSubcategorias.SUBCATEGORIA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("sub_codigo") > 0 Then
                        cmbCategorias.SelectedValue = ds.Tables(0).Rows(Fila)("cat_codigo")
                        txtSubCategoria.Text = ds.Tables(0).Rows(Fila)("sub_nombre")
                        txtAbrevi.Text = ds.Tables(0).Rows(Fila)("sub_abreviacion")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("sub_activo")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA_FORM() = False Then
            Exit Sub
        End If
        chkActivo.Focus()
        Call GUARDAR_REGISTRO()
    End Sub

    Private Function VALIDA_FORM()
        VALIDA_FORM = False

        If cmbCategorias.Text = "" Then
            MessageBox.Show("Debe seleccionar una Categoria, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCategorias.Focus()
            Exit Function
        End If

        If Trim(txtSubCategoria.Text) = "" Then
            MessageBox.Show("Debe ingresar el nombre de la Subcategoria, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSubCategoria.Focus()
            Exit Function
        End If

        If Trim(txtAbrevi.Text) = "" Then
            MessageBox.Show("Debe ingresar abreviación de la Subcategoria, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAbrevi.Focus()
            Exit Function
        End If
        VALIDA_FORM = True
    End Function

    Private Sub GUARDAR_REGISTRO()
        Dim clasSubcategorias As class_subcategoria = New class_subcategoria
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim respuesta As Integer = 0

        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            clasSubcategorias.cnn = _cnn
            clasSubcategorias.cat_codigo = cmbCategorias.SelectedValue
            clasSubcategorias.sub_codigo = _sub_codigo
            clasSubcategorias.sub_nombre = txtSubCategoria.Text
            clasSubcategorias.sub_abreviacion = txtAbrevi.Text
            clasSubcategorias.sub_activo = chkActivo.Checked

            ds = clasSubcategorias.SUBCATEGORIA_GUARDA_REGISTRO(_msgError)
            If _msgError <> "" Then

                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    _sub_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If

            ds = Nothing
            respuesta = MessageBox.Show("Los datos fueron guardados en forma correcta" _
                                + Chr(10) + "¿Desea ingresar otro registro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbYes Then
                Call INICIALIZA()
            Else
                Me.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
    End Sub
End Class