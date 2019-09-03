Public Class frm_inicio_sesion
    Dim _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_inicio_sesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''SERVIDOR PRODUCCION
        pubServidor = "192.168.1.8\POSEIDONSQL"
        pubBaseDato = "APPFVT_01"
        pubUsuario = "sa"
        pubContrasena = "S1nc0ntr4s3n4db4.2017"

        'SERVIDOR DESARROLLO
        'pubServidor = "CL-MV054\DESARROLLO"
        'pubBaseDato = "APPFVT_01"
        'pubUsuario = "sa"
        'pubContrasena = "S1st3m4s"


        ''SERVIDOR PRODUCCION
        _cnn = "Data Source=" + pubServidor + ";Initial Catalog=" + pubBaseDato + ";User ID=" + pubUsuario + ";Password=" + pubContrasena

        GLO_BODEGA_RECEPCION = 14


        Call CARGA_COMBO_USUARIO()
    End Sub
    Private Sub CARGA_COMBO_USUARIO()
        Dim _msg As String
        Try
            Dim classUsuario As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUsuario.cnn = _cnn
            _msg = ""
            ds = classUsuario.CARGA_COMBO_USUARIO(_msg)
            If _msg = "" Then
                Me.cmbUsuario.DataSource = ds.Tables(0)
                Me.cmbUsuario.DisplayMember = "MENSAJE"
                Me.cmbUsuario.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_USUARIO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click
        If cmbUsuario.Text = "" Then
            MessageBox.Show("Debe seleccionar un usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        GLO_USUARIO_ACTUAL = cmbUsuario.SelectedValue
        Call OBTIENE_CODIGO_PERSONA()

        Dim frm As Desktop = New Desktop
        frm.cnn = _cnn
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub OBTIENE_CODIGO_PERSONA()
        Dim classUsuario As class_usuario = New class_usuario
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classUsuario.cnn = _cnn
            classUsuario.usu_codigo = cmbUsuario.SelectedValue

            ds = classUsuario.USUARIO_BUSCA_PERSONA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("usu_nombre") <> "" Then
                        GLO_PERSONA_NUMERO = ds.Tables(0).Rows(Fila)("per_codigo")
                        GLO_PERSONA_NOMBRE = ds.Tables(0).Rows(Fila)("usu_nombre")
                        USU_ASIGNA_PIKING = ds.Tables(0).Rows(Fila)("usu_asignapicking")
                        USU_FINALIZA_PIKING = ds.Tables(0).Rows(Fila)("usu_finalizapicking")
                        USU_ENVIA_FACTURAR_PIKING = ds.Tables(0).Rows(Fila)("usu_enviafacturar")
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_CODIGO_PERSONA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\OBTIENE_CODIGO_PERSONA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub OBTIENE_ACCIONES_USUARIO()
    '    Dim classUsuario As class_uuario = New class_uuario
    '    Dim _msgError As String = ""
    '    Dim ds As DataSet
    '    Dim Fila As Integer = 0
    '    Try
    '        classUsuario.cnn = _cnn
    '        classUsuario.usu_codigo = cmbUsuario.SelectedValue

    '        ds = classUsuario.USUARIO_BUSCA_ACCIONES(_msgError)
    '        If _msgError = "" Then
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                If ds.Tables(0).Rows(Fila)("epc_codigo") <> "" Then
    '                    Public USU_ASIGNA_PIKING As Boolean
    '                    Public USU_FINALIZA_PIKING As Boolean
    '                    Public USU_ENVIA_FACTURAR_PIKING As Boolean


    '                    ds.Tables(0).Rows(Fila)("epc_codigo")


    '                    GLO_PERSONA_NUMERO = ds.Tables(0).Rows(Fila)("per_codigo")
    '                    GLO_PERSONA_NOMBRE = ds.Tables(0).Rows(Fila)("usu_nombre")
    '                End If
    '            End If
    '        Else
    '            MessageBox.Show(_msgError + "\OBTIENE_CODIGO_PERSONA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message + "\OBTIENE_CODIGO_PERSONA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click
        Application.Exit()
    End Sub
End Class