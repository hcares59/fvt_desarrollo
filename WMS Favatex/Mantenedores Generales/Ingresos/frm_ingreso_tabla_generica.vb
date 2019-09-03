Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_tabla_generica
    Private _cnn As String
    Private _mod_codigo As Integer
    Private _tge_codigo As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property mod_codigo() As Integer
        Get
            Return _mod_codigo
        End Get
        Set(ByVal value As Integer)
            _mod_codigo = value
        End Set
    End Property
    Public Property tge_codigo() As Integer
        Get
            Return _tge_codigo
        End Get
        Set(ByVal value As Integer)
            _tge_codigo = value
        End Set
    End Property


    Private Sub frm_ingreso_tabla_generica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _tge_codigo > 0 Then
            Call CARGA_COMBO_MODULOS()
            If _mod_codigo > 0 Then
                cmbModulos.SelectedValue = _mod_codigo
                cmbModulos.Enabled = False
            End If
            Call CARGA_REGISTRO()
        Else
            Call INICIALIZA()
        End If
    End Sub
    Private Sub CARGA_REGISTRO()
        Dim class_tabla_generales As class_tablas_genericas = New class_tablas_genericas
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_tabla_generales.cnn = _cnn
            class_tabla_generales.mod_codigo = _mod_codigo
            class_tabla_generales.tge_codigo = _tge_codigo
            _msg = ""
            ds = class_tabla_generales.TABLA_GENERICA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("mod_codigo") > 0 Then
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("tge_nombre")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("tge_activo")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub INICIALIZA()
        cmbModulos.Enabled = True
        Call CARGA_COMBO_MODULOS()
        txtNombre.Text = ""
        _mod_codigo = 0
        _tge_codigo = 0
        txtNombre.Focus()
        chkActivo.Checked = True
    End Sub


    Private Sub CARGA_COMBO_MODULOS()
        Dim _msg As String
        Try
            Dim classUsuario As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUsuario.cnn = _cnn
            _msg = ""
            ds = classUsuario.CARGA_COMBO_MODULOS(_msg)
            If _msg = "" Then
                Me.cmbModulos.DataSource = ds.Tables(0)
                Me.cmbModulos.DisplayMember = "MENSAJE"
                Me.cmbModulos.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_USUARIO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA_FORM() = False Then
            Exit Sub
        End If
        chkActivo.Focus()
        Call GUARDA_REGISTRO()
    End Sub

    Private Function VALIDA_FORM()
        VALIDA_FORM = False

        If Trim(cmbModulos.Text) = "" Then
            MessageBox.Show("Debe seleccionar nombre del módulo, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbModulos.Focus()
            Exit Function
        End If

        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre de la tabla, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Function
        End If

        VALIDA_FORM = True

    End Function

    Private Sub GUARDA_REGISTRO()
        Dim class_tabla_generica As class_tablas_genericas = New class_tablas_genericas
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
                class_tabla_generica.tge_codigo = _tge_codigo
                class_tabla_generica.mod_codigo = cmbModulos.SelectedValue
                class_tabla_generica.tge_nombre = txtNombre.Text
                class_tabla_generica.tge_activo = chkActivo.Checked

                ds = class_tabla_generica.TABLA_GENERICA_GUARDA_REGISTRO(_msgError, conexion)
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
                        _mod_codigo = cmbModulos.SelectedValue
                        cmbModulos.Enabled = False
                        _tge_codigo = ds.Tables(0).Rows(0)("codigo")
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
                conexion.Close()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim frm As frm_ingreso_tabla_generica_detalle = New frm_ingreso_tabla_generica_detalle
        frm.cnn = _cnn
        frm.tge_codigo = _tge_codigo
        frm.tge_nombre = txtNombre.Text
        frm.Show()
    End Sub
End Class