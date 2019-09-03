Public Class frmInicioSesion
    Dim _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frmInicioSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''SERVIDOR PRODUCCION
        pubServidor = "192.168.1.8\POSEIDONSQL"
        pubBaseDato = "APPFVT_01"
        pubUsuario = "sa"
        pubContrasena = "S1nc0ntr4s3n4db4.2017"

        'SERVIDOR DESARROLLO
        'pubServidor = "CL-MV054\DESARROLLO"
        'pubBaseDato = "APPFVT_03"
        'pubUsuario = "sa"
        'pubContrasena = "S1st3m4s"


        ''SERVIDOR PRODUCCION
        _cnn = "Data Source=" + pubServidor + ";Initial Catalog=" + pubBaseDato + ";User ID=" + pubUsuario + ";Password=" + pubContrasena

        ''SERVIDOR DESARROLLO
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_DE;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"

        'LOCAL
        '_cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_01;User ID=sa;Password=S1st3m4s"
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

        If txtPass.Text = "" Then
            MessageBox.Show("Debe ingresar la contraseña", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        GLO_USUARIO_ACTUAL = cmbUsuario.SelectedValue
        GLO_USUARIO_PASS = Trim(txtPass.Text)
        If OBTIENE_CODIGO_PERSONA() = False Then
            MessageBox.Show("Los datos de acceso son incorrecto, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If GLO_USUARIO_ACTUAL = 6 Then
            Dim frmmenu As frmDesktop = New frmDesktop
            frmmenu.RequerimientosEnCertificaciónMenu.Visible = True
        Else
            Dim frmmenu As frmDesktop = New frmDesktop
            frmmenu.RequerimientosEnCertificaciónMenu.Visible = False
        End If

        'SETEA VARIABLE PARA PRUEBAS DE DESARROLLO
        GLO_PRUEBA_DESARROLLO = False
        If GLO_PRUEBA_DESARROLLO = True Then


            'RequerimientosEnCertificaciónMenu

            Dim frm2 As frmMenu = New frmMenu
            frm2.cnn = _cnn
            Me.Hide()
            frm2.Show()
        Else
            Dim frm As frmDesktop = New frmDesktop
            frm.cnn = _cnn
            Me.Hide()
            frm.Show()
        End If

    End Sub
    Private Function OBTIENE_CODIGO_PERSONA() As Boolean
        Dim classUsuario As class_usuario = New class_usuario
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            OBTIENE_CODIGO_PERSONA = False
            classUsuario.cnn = _cnn
            classUsuario.usu_codigo = cmbUsuario.SelectedValue
            classUsuario.usu_contrasena = txtPass.Text

            ds = classUsuario.USUARIO_BUSCA_PERSONA_NEW(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("usu_nombre") <> "" Then
                        GLO_PERSONA_NUMERO = ds.Tables(0).Rows(Fila)("per_codigo")
                        GLO_PERSONA_NOMBRE = ds.Tables(0).Rows(Fila)("usu_nombre")
                        USU_ASIGNA_PIKING = ds.Tables(0).Rows(Fila)("usu_asignapicking")
                        USU_FINALIZA_PIKING = ds.Tables(0).Rows(Fila)("usu_finalizapicking")
                        USU_ENVIA_FACTURAR_PIKING = ds.Tables(0).Rows(Fila)("usu_enviafacturar")
                        ES_COMERCILA = ds.Tables(0).Rows(Fila)("es_comercial")
                        ES_DISENO = ds.Tables(0).Rows(Fila)("es_diseno")
                        GLO_PERSONA_CARGO = ds.Tables(0).Rows(Fila)("uca_nombre")
                        OBTIENE_CODIGO_PERSONA = True
                    End If
                End If
            Else
                OBTIENE_CODIGO_PERSONA = False
                MessageBox.Show(_msgError + "\OBTIENE_CODIGO_PERSONA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            OBTIENE_CODIGO_PERSONA = False
            MessageBox.Show(ex.Message + "\OBTIENE_CODIGO_PERSONA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click
        Application.Exit()
    End Sub
End Class