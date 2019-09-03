Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_ingreso_pallet
    Private _cnn As String
    Private _pal_codigo_interno As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property pal_codigo_interno() As String
        Get
            Return _pal_codigo_interno
        End Get
        Set(ByVal value As String)
            _pal_codigo_interno = value
        End Set
    End Property
    Private Sub frm_ingreso_pallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _pal_codigo_interno <> "" Then
            Call carga_registro()
        Else
            Call inicializa()
        End If
    End Sub
    Private Sub inicializa()
        txt_codigo_int.Text = ""
        _pal_codigo_interno = 0
        txt_codigo_int.Focus()
        txt_descripcion.Text = ""
        txt_precio.Text = ""
        chkActivo.Checked = True
    End Sub
    Private Sub carga_registro()
        Dim class_pallet As class_pallet = New class_pallet
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_pallet.cnn = _cnn
            class_pallet.pal_cod_interno = _pal_codigo_interno

            _msg = ""
            ds = class_pallet.pallet_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pal_codigo_interno") <> "" Then
                        txt_codigo_int.Text = ds.Tables(0).Rows(Fila)("pal_codigo_interno")
                        txt_descripcion.Text = ds.Tables(0).Rows(Fila)("pal_descripcion")
                        txt_precio.Text = ds.Tables(0).Rows(Fila)("pal_precio")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("pal_activo")
                    Else
                        txt_descripcion.Text = ""
                        txt_precio.Text = ""
                        chkActivo.Checked = 1
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
    Private Function valida_form()
        valida_form = False

        If Trim(txt_precio.Text) = "" Then
            MessageBox.Show("Debe ingresar precio de el pallet , favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_precio.Focus()
            Exit Function
        End If

        valida_form = True
    End Function

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call inicializa()
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If valida_form() = False Then
            Exit Sub
        End If
        chkActivo.Focus()
        Call GUARDA_REGISTRO()
    End Sub

    Private Sub GUARDA_REGISTRO()
        Dim class_pallet As class_pallet = New class_pallet
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
                class_pallet.pal_cod_interno = txt_codigo_int.Text


                class_pallet.pal_descripcion = txt_descripcion.Text
                class_pallet.pal_precio = Val(txt_precio.Text)
                class_pallet.pal_activo = chkActivo.Checked

                ds = class_pallet.pallet_guarda_registro(_msgError, conexion)
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
                        _pal_codigo_interno = ds.Tables(0).Rows(0)("codigo")
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
                    Call inicializa()
                Else
                    Me.Dispose()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txt_codigo_int_LostFocus(sender As Object, e As EventArgs) Handles txt_codigo_int.LostFocus
        If txt_codigo_int.Text <> "" Then
            _pal_codigo_interno = txt_codigo_int.Text
            Call carga_registro()
        End If
    End Sub

    Private Sub txt_precio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_precio.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class