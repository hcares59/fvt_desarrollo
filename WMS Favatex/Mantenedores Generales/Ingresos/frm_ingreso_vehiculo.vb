Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_ingreso_vehiculo
    Private _cnn As String
    Private _vhe_codigo As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property vhe_codigo() As Integer
        Get
            Return _vhe_codigo
        End Get
        Set(ByVal value As Integer)
            _vhe_codigo = value
        End Set
    End Property

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frm_ingreso_vehiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()

        If _vhe_codigo > 0 Then
            Call CARGA_REGISTRO()
        End If
    End Sub

    Private Sub INICIALIZA()
        txtNombre.Text = ""
        txtPatente.Text = ""
        txtCapaKg.Text = "0"
        txtCapacidaPal.Text = "0"
        txtCapacPalletDoble.Text = "0"
        txtCapacPalletDobleSodimac.Text = "0"
        chkActivo.Checked = True
        chRequiere.Checked = False
        Call CARGA_COMBO_TIPO_VEHICULO()
    End Sub

    Private Sub CARGA_COMBO_TIPO_VEHICULO()
        Dim _msg As String
        Try
            Dim classTVehiculo As class_tipo_vehiculo = New class_tipo_vehiculo
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classTVehiculo.cnn = _cnn
            _msg = ""
            ds = classTVehiculo.TIPO_VEHICULO_COMNBO(_msg)
            If _msg = "" Then
                Me.cbmTipoVehiculo.DataSource = ds.Tables(0)
                Me.cbmTipoVehiculo.DisplayMember = "MENSAJE"
                Me.cbmTipoVehiculo.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_VEHICULO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_REGISTRO()
        Dim classVehiculo As class_vehiculo = New class_vehiculo
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classVehiculo.cnn = _cnn
            classVehiculo.veh_codigo = _vhe_codigo

            _msg = ""
            ds = classVehiculo.VEHICULO_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("veh_codigo") > 0 Then
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("veh_nombre")
                        txtPatente.Text = ds.Tables(0).Rows(Fila)("veh_patente")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("veh_activo")
                        txtCapaKg.Text = ds.Tables(0).Rows(Fila)("veh_capacKilos")
                        txtCapacidaPal.Text = ds.Tables(0).Rows(Fila)("veh_capacpallets")
                        txtCapacPalletDoble.Text = ds.Tables(0).Rows(Fila)("veh_capacpaldobleancho")
                        txtCapacPalletDobleSodimac.Text = ds.Tables(0).Rows(Fila)("veh_capacpaldobleancho_sodimac")
                        cbmTipoVehiculo.SelectedValue = ds.Tables(0).Rows(Fila)("tve_codigo")
                        chRequiere.Checked = ds.Tables(0).Rows(Fila)("veh_requierecomplemento")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_DATOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_DATOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If valida_form() = False Then
            Exit Sub
        End If
        Call GUARDA_REGISTRO()
        _vhe_codigo = 0
    End Sub

    Private Sub GUARDA_REGISTRO()
        Dim classVehiculo As class_vehiculo = New class_vehiculo
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim respuesta As Integer = 0

        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classVehiculo.cnn = _cnn
            classVehiculo.veh_codigo = _vhe_codigo
            classVehiculo.veh_nombre = txtNombre.Text
            classVehiculo.veh_patente = txtPatente.Text
            classVehiculo.veh_activo = chkActivo.Checked
            classVehiculo.tve_codigo = cbmTipoVehiculo.SelectedValue
            classVehiculo.veh_capacKilos = txtCapaKg.Text
            classVehiculo.veh_capacpaldobleancho = txtCapacidaPal.Text
            classVehiculo.veh_capacpaldobleancho_sodimac = txtCapacPalletDobleSodimac.Text
            classVehiculo.veh_capacpallets = txtCapacidaPal.Text
            classVehiculo.veh_requierecomplemento = chRequiere.Checked


            ds = classVehiculo.VEHICULO_GUARDA_REGISTRO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    _vhe_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If

            ds = Nothing

            respuesta = MessageBox.Show("Los datos fueron guardados en forma correcta" _
                                        + Chr(10) + "¿Desea ingresar la información de otro vehiculo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbYes Then
                Call INICIALIZA()
                _vhe_codigo = 0
            Else
                Me.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function VALIDA_FORM()
        VALIDA_FORM = False
        If cbmTipoVehiculo.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar tipo de vehiculo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbmTipoVehiculo.Focus()
            Exit Function
        End If
        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre de vehiculo, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Function
        End If
        If Trim(txtPatente.Text) = "" Then
            MessageBox.Show("Debe ingresar patenete del vehiculo, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPatente.Focus()
            Exit Function
        End If
        If Trim(txtCapaKg.Text) = "" Then
            MessageBox.Show("Debe ingresar capacidad vehiculoc, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCapaKg.Focus()
            Exit Function
        End If
        If Trim(txtCapacidaPal.Text) = "" Then
            MessageBox.Show("Debe ingresar capacidad en pallets, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCapacidaPal.Focus()
            Exit Function
        End If
        If Trim(txtCapacidaPal.Text) = "" Then
            MessageBox.Show("Debe ingresar capacidad en pallets, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCapacidaPal.Focus()
            Exit Function
        End If
        If txtCapacPalletDoble.Text = "" Then
            MessageBox.Show("Debe ingresar capacidad en pallets doble ancho, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCapacPalletDoble.Focus()
            Exit Function
        End If
        VALIDA_FORM = True

    End Function

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
        _vhe_codigo = 0
    End Sub

    Public Sub NumerosyDecimal(ByVal CajaTexto As System.Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
            e.Handled = False
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCapaKg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapaKg.KeyPress
        NumerosyDecimal(txtCapaKg, e)
    End Sub

    Private Sub txtCapacidaPal_TextChanged(sender As Object, e As EventArgs) Handles txtCapacidaPal.TextChanged

    End Sub

    Private Sub txtCapacidaPal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapacidaPal.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtCapacPalletDoble_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapacPalletDoble.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtCapacPalletDobleSodimac_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapacPalletDobleSodimac.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class