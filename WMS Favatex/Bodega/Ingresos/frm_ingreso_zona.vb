Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_zona
    Private _cnn As String
    Private _zon_codigo As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property zon_codigo() As Integer
        Get
            Return _zon_codigo
        End Get
        Set(ByVal value As Integer)
            _zon_codigo = value
        End Set
    End Property
    Private Sub frm_ingreso_zona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call carga_bodegas()
        If _zon_codigo > 0 Then
            Call carga_registro()
        Else
            Call inicializa()
        End If
    End Sub

    Private Sub carga_bodegas_tipo_ubicaciones_combo(ByVal bod_codigo As Integer)
        Dim _msg As String
        Try
            Dim class_bodegas_tipo_ubicacion As class_tipo_ubicacion = New class_tipo_ubicacion
            class_bodegas_tipo_ubicacion.cnn = _cnn
            class_bodegas_tipo_ubicacion.bod_codigo = bod_codigo
            Dim ds As DataSet = New DataSet
            ds = Nothing

            class_bodegas_tipo_ubicacion.cnn = _cnn
            _msg = ""
            ds = class_bodegas_tipo_ubicacion.carga_bodegas_ubicacion_combo(_msg)
            If _msg = "" Then
                cbx_tipubicacion.DataSource = ds.Tables(0)
                cbx_tipubicacion.DisplayMember = "tub_nombre"
                cbx_tipubicacion.ValueMember = "tub_codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga bodegas tipo ubicaciones", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_BODEGAS()
        Dim _msg As String
        Try
            Dim class_bodegas_tipo_ubicacion As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet
            ds = Nothing
            cbmBodegas.ValueMember = "0"
            cbmBodegas.DisplayMember = ""
            class_bodegas_tipo_ubicacion.cnn = _cnn
            _msg = ""
            ds = class_bodegas_tipo_ubicacion.BODEGA_CARGA_COMBO(_msg)
            If _msg = "" Then
                cbmBodegas.DataSource = ds.Tables(0)
                cbmBodegas.DisplayMember = "mensaje"
                cbmBodegas.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_BODEGAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub INICIALIZA()
        txtNombre.Text = ""
        _zon_codigo = 0
        txtNombre.Focus()
        chkActivo.Checked = True
    End Sub

    Private Sub CARGA_REGISTRO()
        Dim class_zonas As class_zonas = New class_zonas
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_zonas.cnn = _cnn
            class_zonas.zon_codigo = zon_codigo
            class_zonas.btu_codigo = 0

            _msg = ""
            If _msg = "" Then
                ds = class_zonas.ZONAS_LISTADO(_msg)
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("zon_codigo") > 0 Then
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("zon_nombre")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("zon_activo")
                        cbmBodegas.SelectedValue = ds.Tables(0).Rows(Fila)("bod_codigo")
                        cbmBodegas.Enabled = False
                        Call carga_bodegas_tipo_ubicaciones_combo(Val(cbmBodegas.SelectedValue))
                        cbx_tipubicacion.Enabled = False
                        cbx_tipubicacion.SelectedValue = ds.Tables(0).Rows(Fila)("btu_codigo")
                        chkFondo.Checked = ds.Tables(0).Rows(Fila)("zon_fondo")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\carga_registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_registro", MsgBoxStyle.Critical, Me.Text)
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
        Call guarda_registro(Val(cbx_tipubicacion.SelectedValue))
    End Sub

    Private Sub GUARDA_REGISTRO(ByVal btu_codigo As Integer)
        Dim class_zonas As class_zonas = New class_zonas
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
                class_zonas.zon_codigo = _zon_codigo
                class_zonas.zon_nombre = txtNombre.Text
                class_zonas.btu_codigo = btu_codigo
                class_zonas.zon_activo = chkActivo.Checked
                class_zonas.zon_relac = 0
                class_zonas.zon_fondo = chkFondo.Checked

                ds = class_zonas.ZONA_GUARDA_REGISTRO(_msgError, conexion)
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
                        _zon_codigo = ds.Tables(0).Rows(0)("codigo")
                    End If
                End If
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                conexion.Close()
                respuesta = MessageBox.Show("Los datos fueron ingresados en forma correcta," _
                                            + Chr(10) + "¿Desea ingresar otra zona?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If respuesta = vbNo Then
                    Me.Dispose()
                Else
                    Call INICIALIZA()
                    zon_codigo = 0
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function VALIDA_FORM()
        VALIDA_FORM = False
        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre de la zona, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Function
        End If
        If cbmBodegas.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar bodega, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbmBodegas.Focus()
            Exit Function
        End If
        If cbx_tipubicacion.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar tipo ubicaciones, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbx_tipubicacion.Focus()
            Exit Function
        End If
        VALIDA_FORM = True
    End Function

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
    End Sub

    Private Sub cbmBodegas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbmBodegas.SelectedIndexChanged

    End Sub

    Private Sub cbmBodegas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbmBodegas.SelectionChangeCommitted
        Call carga_bodegas_tipo_ubicaciones_combo(Val(cbmBodegas.SelectedValue))
    End Sub
End Class