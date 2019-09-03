Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_glosa
    Private _cnn As String
    Private _glo_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property glo_codigo() As Integer
        Get
            Return _glo_codigo
        End Get
        Set(ByVal value As Integer)
            _glo_codigo = value
        End Set
    End Property
    Private Sub frm_ingreso_glosa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _glo_codigo > 0 Then
            Call INICIALIZA()
            Call CARGA_REGISTRO()
        Else
            Call INICIALIZA()
        End If
    End Sub
    Private Sub INICIALIZA()
        'class_glosas.glo_codigo = 0
        txtNombre.Text = ""

        txtNombre.Focus()
        chkActivo.Checked = True
        Call carga_combo_areas()
    End Sub
    Private Sub carga_combo_areas()
        Dim _msg As String
        Try
            Dim class_areas As class_areas = New class_areas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            class_areas.cnn = _cnn
            _msg = ""

            ds = class_areas.carga_combo_areas(_msg)
            If _msg = "" Then
                Me.cmbAreas.DataSource = ds.Tables(0)
                Me.cmbAreas.DisplayMember = "MENSAJE"
                Me.cmbAreas.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_AREA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_REGISTRO()
        Dim class_glosas As class_glosas = New class_glosas
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_glosas.cnn = _cnn
            class_glosas.glo_codigo = _glo_codigo
            _msg = ""
            ds = class_glosas.glosas_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("glo_codigo") > 0 Then
                        cmbAreas.SelectedValue = ds.Tables(0).Rows(Fila)("are_codigo")
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("glo_nombre")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("glo_activa")
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
        Call guarda_registro()
    End Sub
    Private Sub guarda_registro()
        Dim class_glosas As class_glosas = New class_glosas
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
                class_glosas.glo_codigo = _glo_codigo
                class_glosas.are_codigo = cmbAreas.SelectedValue
                class_glosas.glo_nombre = txtNombre.Text
                class_glosas.glo_activo = chkActivo.Checked

                ds = class_glosas.glosas_guarda_registo(_msgError, conexion)
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
                        _glo_codigo = ds.Tables(0).Rows(0)("codigo")
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
                    _glo_codigo = 0
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
        If Trim(cmbAreas.Text) = "" Then
            MessageBox.Show("Debe selecionar una area, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbAreas.Focus()
            Exit Function
        End If

        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre de la glosa, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Function
        End If

        valida_form = True

    End Function

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
    End Sub
End Class