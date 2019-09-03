Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_tipo_vehiculo
    Private _cnn As String
    Private _tve_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property tve_codigo() As Integer
        Get
            Return _tve_codigo
        End Get
        Set(ByVal value As Integer)
            _tve_codigo = value
        End Set
    End Property
    Private Sub frm_tipo_vehiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _tve_codigo > 0 Then
            Call CARGA_REGISTRO()
        End If
    End Sub

    Private Sub CARGA_REGISTRO()
        Dim classTipoVehiculo As class_tipo_vehiculo = New class_tipo_vehiculo
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classTipoVehiculo.cnn = _cnn
            classTipoVehiculo.tve_codigo = tve_codigo
            _msg = ""
            ds = classTipoVehiculo.TIPO_VEHICULO_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("TVE_codigo") > 0 Then
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("TVE_nombre")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("TVE_activo")
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
        If VALIDA_FORM() = False Then
            Exit Sub
        End If

        Call guarda_registro()
        'Me.Dispose()
        'tve_codigo = 0
    End Sub

    Private Sub guarda_registro()
        Dim classTipoVehiculo As class_tipo_vehiculo = New class_tipo_vehiculo
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
                classTipoVehiculo.tve_codigo = _tve_codigo
                classTipoVehiculo.tve_nombre = txtNombre.Text
                classTipoVehiculo.tve_activo = chkActivo.Checked

                ds = classTipoVehiculo.TIPO_VEHICULO_GUARDA_REGISTRO(_msgError, conexion)
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
                        tve_codigo = ds.Tables(0).Rows(0)("codigo")
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                respuesta = MessageBox.Show("Los datos fueron ingresado en forma correcta," _
                                            + Chr(10) + "¿Desea seguir ingresando otros tipos de vehiculos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbYes Then
                    _tve_codigo = 0
                    txtNombre.Text = ""
                    chkActivo.Checked = False
                Else
                    Me.Dispose()
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function VALIDA_FORM()
        VALIDA_FORM = False
        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre de el tipo de vehiculo, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Function
        End If
        VALIDA_FORM = True
    End Function

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        txtNombre.Text = ""
        chkActivo.Checked = False
    End Sub
End Class