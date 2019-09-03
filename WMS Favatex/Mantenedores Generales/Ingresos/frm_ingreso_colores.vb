Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_ingreso_colores
    Private _cnn As String
    Private _col_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property col_codigo() As Integer
        Get
            Return _col_codigo
        End Get
        Set(ByVal value As Integer)
            _col_codigo = value
        End Set
    End Property

    Private Sub frm_ingreso_colores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _col_codigo > 0 Then
            Call CARGA_REGISTRO()
        Else
            Call INICIALIZA()
        End If
    End Sub

    Private Sub INICIALIZA()
        txtColor.Text = ""
        txtAbrevi.Text = ""
        _col_codigo = 0
        txtColor.Focus()
        chkActivo.Checked = True
    End Sub

    Private Sub CARGA_REGISTRO()
        Dim class_colores As class_colores = New class_colores
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_colores.cnn = _cnn
            class_colores.col_codigo = col_codigo

            _msg = ""
            ds = class_colores.color_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("col_codigo") > 0 Then
                        txtColor.Text = ds.Tables(0).Rows(Fila)("col_nombre")
                        txtAbrevi.Text = ds.Tables(0).Rows(Fila)("col_abreviacion")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("col_activo")
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

    Private Sub GUARDA_REGISTRO()
        Dim class_colores As class_colores = New class_colores
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
                class_colores.col_codigo = _col_codigo
                class_colores.col_nombre = txtColor.Text
                class_colores.col_abreviacion = txtAbrevi.Text
                class_colores.col_activo = chkActivo.Checked

                ds = class_colores.color_guarda_registro(_msgError, conexion)
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
                        _col_codigo = ds.Tables(0).Rows(0)("codigo")
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

    Private Function valida_form()
        valida_form = False
        If Trim(txtColor.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre de el color, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtColor.Focus()
            Exit Function
        End If

        If Trim(txtAbrevi.Text) = "" Then
            MessageBox.Show("Debe ingresar abreviación para el color, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAbrevi.Focus()
            Exit Function
        End If
        valida_form = True

    End Function

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
    End Sub

    Private Sub txtAbrevi_TextChanged(sender As Object, e As EventArgs) Handles txtAbrevi.TextChanged

    End Sub

    Private Function VALIDA_ABREVIACION(ByVal varAbr As String) As String
        Dim class_colores As class_colores = New class_colores
        Dim Fila As Integer = 0
        VALIDA_ABREVIACION = ""
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            class_colores.cnn = _cnn
            class_colores.col_abreviacion = varAbr

            _msg = ""
            ds = class_colores.VALIDA_ABREVIACION(_msg)
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

    Private Sub txtAbrevi_LostFocus(sender As Object, e As EventArgs) Handles txtAbrevi.LostFocus
        Dim nombre As String = ""
        nombre = VALIDA_ABREVIACION(txtAbrevi.Text)
        If nombre <> "" Then
            MessageBox.Show("La abreviación que esta tratado de ingresar, ya se encuentra asociada al color " + nombre, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAbrevi.Text = ""
            txtAbrevi.Focus()
            Exit Sub
        End If
    End Sub
End Class