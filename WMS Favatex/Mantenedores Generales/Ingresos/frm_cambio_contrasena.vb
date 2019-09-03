Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_cambio_contrasena
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click

    End Sub

    Private Sub frm_cambio_contrasena_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'GLO_USUARIO_ACTUAL = 2
        'GLO_USUARIO_PASS = "123"
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
    End Sub

    Private Sub INICIALIZA()
        TxtActual.Text = ""
        txtNueva.Text = ""
        txtRepita.Text = ""
        TxtActual.Focus()
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If valida_form() = False Then
            Exit Sub
        End If

        Call GUARDA_REGISTRO()
    End Sub
    Private Function valida_form()

        valida_form = False
        If Trim(TxtActual.Text) = "" Then
            MessageBox.Show("Debe ingresar la contraseña actual, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtActual.Focus()
            Exit Function
        End If

        If Trim(txtNueva.Text) = "" Then
            MessageBox.Show("Debe ingresar la nueva contraseña, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNueva.Focus()
            Exit Function
        End If

        If Trim(txtRepita.Text) = "" Then
            MessageBox.Show("Debe ingresar la nueva contraseña, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRepita.Focus()
            Exit Function
        End If

        If Trim(TxtActual.Text) <> GLO_USUARIO_PASS Then
            MessageBox.Show("La contraseña actual no corresponde a la que se enuentra registrada en la base de datos, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtActual.Focus()
            Exit Function
        End If

        If Trim(txtNueva.Text) <> Trim(txtRepita.Text) Then
            MessageBox.Show("La repitición de la contraseña no corresponde con la nueva contraña que esta ingresando, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRepita.Focus()
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

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                class_usuario.usu_codigo = GLO_USUARIO_ACTUAL
                class_usuario.usu_contrasena = txtRepita.Text

                ds = class_usuario.USUARIO_ACTUALIZA_PASS(_msgError, conexion)
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
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                MessageBox.Show("La contraseña fue actualizada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



End Class