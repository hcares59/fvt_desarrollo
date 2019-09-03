Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_usuarios
    Private _cnn As String
    Private _usu_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property usu_codigo() As Integer
        Get
            Return _usu_codigo
        End Get
        Set(ByVal value As Integer)
            _usu_codigo = value
        End Set
    End Property
    Private Sub frm_ingreso_usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call carga_combo_cargos()
        If _usu_codigo > 0 Then
            Call CARGA_REGISTRO()
        Else
            Call INICIALIZA()
        End If
    End Sub

    Private Sub carga_combo_cargos()
        Dim _msg As String
        Try
            Dim class_usuario As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_usuario.cnn = _cnn
            _msg = ""
            ds = class_usuario.CARGA_COMBO_CARGOS(_msg)
            If _msg = "" Then
                Me.cmbCargo.DataSource = ds.Tables(0)
                Me.cmbCargo.DisplayMember = "mensaje"
                Me.cmbCargo.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CARGOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub INICIALIZA()
        txtRut.Text = ""
        txtNombre.Text = ""
        txtContrasena.Text = "favatex"
        _usu_codigo = 0
        chkActivo.Checked = True
        chkContraseña.Checked = True
        chkAsigna.Checked = False
        chkFactura.Checked = False
        chkProcesa.Checked = False
        chkDespacha.Checked = False
        chkComercial.Checked = False
        chkDiseno.Checked = False
        chkEsChofer.Checked = False
        txtRut.Focus()
    End Sub

    Private Sub CARGA_REGISTRO()
        Dim class_usuario As class_usuario = New class_usuario
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_usuario.cnn = _cnn
            class_usuario.usu_codigo = _usu_codigo

            _msg = ""
            ds = class_usuario.USUARIO_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("usu_codigo") > 0 Then
                        txtRut.Text = ds.Tables(0).Rows(Fila)("usu_rut")
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("usu_nombre")
                        txtContrasena.Text = ds.Tables(0).Rows(Fila)("usu_contrasena")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("uso_activo")
                        chkAsigna.Checked = ds.Tables(0).Rows(Fila)("usu_asignapicking")
                        chkProcesa.Checked = ds.Tables(0).Rows(Fila)("usu_finalizapicking")
                        chkFactura.Checked = ds.Tables(0).Rows(Fila)("usu_enviaafacturarpicking")
                        chkDespacha.Checked = ds.Tables(0).Rows(Fila)("usu_enviaadespacharpicking")
                        chkComercial.Checked = ds.Tables(0).Rows(Fila)("es_comercial")
                        chkDiseno.Checked = ds.Tables(0).Rows(Fila)("es_diseno")
                        chkEsChofer.Checked = ds.Tables(0).Rows(Fila)("es_chofer")
                        chkEsUsuario.Checked = ds.Tables(0).Rows(Fila)("usu_desplegarinicio")
                        chkEsBodega.Checked = ds.Tables(0).Rows(Fila)("es_bodega")
                        chkAsignaRecepcion.Checked = ds.Tables(0).Rows(Fila)("es_asiganpararecepcion")
                        chkEjecutaRecepcion.Checked = ds.Tables(0).Rows(Fila)("es_ejecutarecepcion")
                        cmbCargo.SelectedValue = ds.Tables(0).Rows(Fila)("uca_codigo")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_REGISTROS_X_RUT()
        Dim class_usuario As class_usuario = New class_usuario
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_usuario.cnn = _cnn
            class_usuario.usu_rut = Trim(txtRut.Text)

            _msg = ""
            ds = class_usuario.USUARIO_CARGA_DATOS_X_RUT(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("usu_codigo") > 0 Then
                        _usu_codigo = ds.Tables(0).Rows(Fila)("usu_codigo")
                        txtRut.Text = ds.Tables(0).Rows(Fila)("usu_rut")
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("usu_nombre")
                        txtContrasena.Text = ds.Tables(0).Rows(Fila)("usu_contrasena")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("uso_activo")
                        chkAsigna.Checked = ds.Tables(0).Rows(Fila)("usu_asignapicking")
                        chkProcesa.Checked = ds.Tables(0).Rows(Fila)("usu_finalizapicking")
                        chkFactura.Checked = ds.Tables(0).Rows(Fila)("usu_enviaadespacharpicking")
                        chkComercial.Checked = ds.Tables(0).Rows(Fila)("es_comercial")
                        chkDiseno.Checked = ds.Tables(0).Rows(Fila)("es_diseno")
                        chkEsChofer.Checked = ds.Tables(0).Rows(Fila)("es_chofer")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If valida_form() = False Then
            Exit Sub
        End If
        chkActivo.Focus()
        Call GUARDA_REGISTRO()
    End Sub
    Private Function valida_form()
        Dim class_comunes As class_comunes = New class_comunes

        valida_form = False
        If Trim(txtRut.Text) = "" Then
            MessageBox.Show("Debe ingresar el rut del usuario, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRut.Focus()
            Exit Function
        End If

        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar el nombre del usuario, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Function
        End If

        If Trim(txtContrasena.Text) = "" Then
            MessageBox.Show("Debe ingresar la contraseña del usuario, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtContrasena.Focus()
            Exit Function
        End If

        If class_comunes.validarRut(txtRut.Text) = False Then
            MessageBox.Show("rut no valido, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRut.Focus()
            Exit Function
        End If

        valida_form = True

    End Function

    Private Sub GUARDA_REGISTRO()
        Dim class_usuario As class_usuario = New class_usuario
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                class_usuario.usu_codigo = _usu_codigo
                class_usuario.uso_activo = chkActivo.Checked
                class_usuario.usu_rut = txtRut.Text
                class_usuario.usu_nombre = txtNombre.Text
                class_usuario.usu_contrasena = txtContrasena.Text
                class_usuario.usu_asignapicking = chkAsigna.Checked
                class_usuario.usu_finalizapicking = chkProcesa.Checked
                class_usuario.usu_enviaafacturarpicking = chkFactura.Checked
                class_usuario.usu_enviaadespacharpicking = chkDespacha.Checked
                class_usuario.es_comercial = chkComercial.Checked
                class_usuario.es_diseno = chkDiseno.Checked
                class_usuario.es_chofer = chkEsChofer.Checked
                class_usuario.usu_desplegarinicio = chkEsUsuario.Checked
                class_usuario.es_bodega = chkEsBodega.Checked
                class_usuario.es_asiganpararecepcion = chkAsignaRecepcion.Checked
                class_usuario.es_ejecutarecepcion = chkEjecutaRecepcion.Checked
                class_usuario.uca_codigo = cmbCargo.SelectedValue
                ds = class_usuario.USUARIO_GUARDA_DATOS(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("codigo") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        _usu_codigo = ds.Tables(0).Rows(0)("codigo")
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                respuesta = MessageBox.Show("Los datos fueron guardados en forma correcta" _
                                + Chr(10) + "¿Desea ingresar otro registro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbYes Then
                    Call INICIALIZA()
                Else
                    Me.Dispose()
                End If


            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
    End Sub

    Private Sub txtRut_TextChanged(sender As Object, e As EventArgs) Handles txtRut.TextChanged

    End Sub

    Private Sub txtRut_Leave(sender As Object, e As EventArgs) Handles txtRut.Leave

    End Sub

    Public Sub NumerosyDigitoK(ByVal CajaTexto As System.Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
            'ElseIf (e.KeyChar = "k" And Not CajaTexto.Text.IndexOf("k")) Then
            '    e.Handled = False
            'ElseIf e.KeyChar = "K" Then
            '    e.Handled = False
        ElseIf e.KeyChar = "-" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtRut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRut.KeyPress
        'NumerosyDigitoK(txtRut, e)
    End Sub

    Private Sub chkContraseña_CheckedChanged(sender As Object, e As EventArgs) Handles chkContraseña.CheckedChanged
        If chkContraseña.Checked = True Then
            txtContrasena.Text = "favatex"
            txtContrasena.Enabled = False
        Else
            txtContrasena.Text = ""
            txtContrasena.Enabled = True
            txtContrasena.Focus()
        End If
    End Sub

    Private Sub txtRut_LostFocus(sender As Object, e As EventArgs) Handles txtRut.LostFocus
        If txtRut.Text <> "" Then
            Call CARGA_REGISTROS_X_RUT()
        End If
    End Sub
End Class