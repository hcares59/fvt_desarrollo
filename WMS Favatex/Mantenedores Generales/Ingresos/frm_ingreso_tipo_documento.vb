Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_tipo_documento
    Private _cnn As String
    Private _tdo_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property tdo_codigo() As Integer
        Get
            Return _tdo_codigo
        End Get
        Set(ByVal value As Integer)
            _tdo_codigo = value
        End Set
    End Property
    Private Sub frm_ingreso_tipo_documento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _tdo_codigo > 0 Then
            Call CARGA_REGISTRO()
        Else
            Call INICIALIZA()
        End If
    End Sub
    Private Sub INICIALIZA()
        txtTipoDocto.Text = ""
        _tdo_codigo = 0
        txtTipoDocto.Focus()
        chkActivo.Checked = True
    End Sub
    Private Sub CARGA_REGISTRO()
        Dim classTDCTO As class_tipo_documento = New class_tipo_documento
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classTDCTO.cnn = _cnn
            classTDCTO.tdo_codigo = _tdo_codigo

            _msg = ""
            ds = classTDCTO.tipodocto_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("tdo_codigo") > 0 Then
                        txtTipoDocto.Text = ds.Tables(0).Rows(Fila)("tdo_nombre")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("tdo_activo")
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
        Dim classTDOCTO As class_tipo_documento = New class_tipo_documento
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
                classTDOCTO.tdo_codigo = _tdo_codigo
                classTDOCTO.tdo_nombre = txtTipoDocto.Text
                classTDOCTO.sub_activo = chkActivo.Checked

                ds = classTDOCTO.tipoDocto_guarda_registro(_msgError, conexion)
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
                        _tdo_codigo = ds.Tables(0).Rows(0)("codigo")
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

    Private Function valida_form()
        valida_form = False

        If Trim(txtTipoDocto.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre del tipo de documento, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTipoDocto.Focus()
            Exit Function
        End If

        valida_form = True

    End Function
    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
    End Sub
End Class