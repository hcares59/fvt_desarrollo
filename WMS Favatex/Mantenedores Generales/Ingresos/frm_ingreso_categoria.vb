Public Class frm_ingreso_categoria
    Private _cnn As String
    Private _cat_codigo As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property cat_codigo() As Integer
        Get
            Return _cat_codigo
        End Get
        Set(ByVal value As Integer)
            _cat_codigo = value
        End Set
    End Property

    Private Sub frm_ingreso_categoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _cat_codigo > 0 Then
            Call CARGA_REGISTRO()
        Else
            Call INICIALIZA()
        End If
    End Sub
    Private Sub INICIALIZA()
        txtCategoria.Text = ""
        txtAbrevi.Text = ""
        _cat_codigo = 0
        txtCategoria.Focus()
        chkActivo.Checked = True
    End Sub
    Private Sub CARGA_REGISTRO()
        Dim class_categorias As class_categorias = New class_categorias
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_categorias.cnn = _cnn
            class_categorias.cat_codigo = cat_codigo

            _msg = ""
            ds = class_categorias.categoria_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("cat_codigo") > 0 Then
                        txtCategoria.Text = ds.Tables(0).Rows(Fila)("cat_nombre")
                        txtAbrevi.Text = ds.Tables(0).Rows(Fila)("cat_abreviacion")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("cat_activo")
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
        If Trim(txtCategoria.Text) = "" Then
            MessageBox.Show("Debe ingresar el nombre de la categoria, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCategoria.Focus()
            Exit Function
        End If

        If Trim(txtAbrevi.Text) = "" Then
            MessageBox.Show("Debe ingresar abreviación de la categoria, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAbrevi.Focus()
            Exit Function
        End If
        VALIDA_FORM = True
    End Function

    Private Sub GUARDAR_REGISTRO()
        Dim class_categorias As class_categorias = New class_categorias
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim respuesta As Integer = 0

        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            class_categorias.cnn = _cnn
            class_categorias.cat_codigo = _cat_codigo
            class_categorias.cat_nombre = txtCategoria.Text
            class_categorias.cat_abreviacion = txtAbrevi.Text
            class_categorias.cat_activo = chkActivo.Checked

            ds = class_categorias.categoria_guarda_registro(_msgError)
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
                    cat_codigo = ds.Tables(0).Rows(0)("codigo")
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

    Private Sub txtAbrevi_TextChanged(sender As Object, e As EventArgs) Handles txtAbrevi.TextChanged

    End Sub

    Private Sub txtAbrevi_LostFocus(sender As Object, e As EventArgs) Handles txtAbrevi.LostFocus
        Dim nombre As String = ""
        nombre = VALIDA_ABREVIACION(txtAbrevi.Text)
        If nombre <> "" Then
            MessageBox.Show("La abreviación que esta tratado de ingresar, ya se encuentra asociada a la categoria " + nombre, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAbrevi.Text = ""
            txtAbrevi.Focus()
            Exit Sub
        End If
    End Sub

    Private Function VALIDA_ABREVIACION(ByVal varAbr As String) As String
        Dim classCategoria As class_categorias = New class_categorias
        Dim Fila As Integer = 0
        VALIDA_ABREVIACION = ""
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classCategoria.cnn = _cnn
            classCategoria.cat_abreviacion = varAbr

            _msg = ""
            ds = classCategoria.VALIDA_ABREVIACION_CATEGORIA(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("descripcion") <> "" Then
                        VALIDA_ABREVIACION = ds.Tables(0).Rows(Fila)("descripcion")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\VALIDA_ABREVIACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            VALIDA_ABREVIACION = ""
            MsgBox(ex.Message + " " + "VALIDA_ABREVIACION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Function
End Class