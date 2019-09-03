Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_calidad
    Private _cnn As String
    Private _cal_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property cal_codigo() As Integer
        Get
            Return _cal_codigo
        End Get
        Set(ByVal value As Integer)
            _cal_codigo = value
        End Set
    End Property
    Private Sub frm_ingreso_calidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _cal_codigo > 0 Then
            Call CARGA_REGISTRO()
        Else
            Call INICIALIZA()
        End If
    End Sub
    Private Sub INICIALIZA()
        txtNombre.Text = ""
        _cal_codigo = 0
        txtNombre.Focus()
        chkActivo.Checked = True
    End Sub
    Private Sub CARGA_REGISTRO()
        Dim classCMUL As class_tipomultimediacalidad = New class_tipomultimediacalidad
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classCMUL.cnn = _cnn
            classCMUL.cal_codigo = _cal_codigo

            _msg = ""
            ds = classCMUL.TIPO_MULTIMEDIA_CALIDAD_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("cal_codigo") > 0 Then
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("cal_nombre")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("cal_activo")
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

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If valida_form() = False Then
            Exit Sub
        End If
        chkActivo.Focus()
        Call GUARDA_REGISTRO()
    End Sub
    Private Sub GUARDA_REGISTRO()
        Dim classCMUL As class_tipomultimediacalidad = New class_tipomultimediacalidad
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                'conexion.Open()
                classCMUL.cnn = _cnn
                classCMUL.cal_codigo = _cal_codigo
                classCMUL.cal_nombre = txtNombre.Text
                classCMUL.cal_activo = chkActivo.Checked

                ds = classCMUL.TIPO_MULTIMEDIA_CALIDAD_GUARDA_REGISTRO(_msgError)
                If _msgError <> "" Then
                    'If conexion.State = ConnectionState.Open Then
                    '    conexion.Close()
                    'End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("codigo") < 0 Then
                        'If conexion.State = ConnectionState.Open Then
                        '    conexion.Close()
                        'End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        _cal_codigo = ds.Tables(0).Rows(0)("codigo")
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                'If conexion.State = ConnectionState.Open Then
                '    conexion.Close()
                'End If
                ds = Nothing

                respuesta = MessageBox.Show("Los datos fueron guardados en forma correcta" _
                                + Chr(10) + "¿Desea ingresar otro registro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbYes Then
                    Call INICIALIZA()
                Else
                    Me.Dispose()
                End If
                'conexion.Close()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function valida_form()
        valida_form = False

        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre del tipo de calidad multimedia, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Function
        End If

        valida_form = True

    End Function
End Class