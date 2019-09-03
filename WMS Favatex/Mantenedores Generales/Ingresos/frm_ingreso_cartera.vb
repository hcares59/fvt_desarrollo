Public Class frm_ingreso_cartera
    Private _cnn As String
    Private _car_codigo As Integer
    Private cod_tipoCli As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property car_codigo() As Integer
        Get
            Return _car_codigo
        End Get
        Set(ByVal value As Integer)
            _car_codigo = value
        End Set
    End Property
    Private Sub frm_ingreso_cartera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Call LIMPIAR()

        If _car_codigo > 0 Then
            Call CARGA_REGISTRO()
        End If
    End Sub

    Private Sub CARGA_REGISTRO()
        Dim classCartera As class_cartera = New class_cartera
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classCartera.cnn = _cnn
            classCartera.car_codigo = _car_codigo
            classCartera.todos = 0

            _msg = ""
            ds = classCartera.CARTERA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        txtRut.Text = ds.Tables(0).Rows(Fila)("car_rut")
                        txtFono.Text = ds.Tables(0).Rows(Fila)("car_telefono")
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("car_nombre")
                        txtCalle.Text = ds.Tables(0).Rows(Fila)("direccion")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("car_activo")
                        chkIncluye.Checked = ds.Tables(0).Rows(Fila)("car_muestra_inf")
                        txtDiasplazo.Text = ds.Tables(0).Rows(Fila)("car_diaspl")
                        cmbRegion.SelectedValue = ds.Tables(0).Rows(Fila)("reg_codigo")
                        Call CARGA_COMBO_CIUDAD()
                        cmbCiudad.SelectedValue = ds.Tables(0).Rows(Fila)("ciu_codigo")
                        Call CARGA_COMBO_COMUNA()
                        cmbComunas.SelectedValue = ds.Tables(0).Rows(Fila)("com_codigo")
                        If Val(ds.Tables(0).Rows(Fila)("car_tipo")) = 1 Then
                            optcliente.Checked = True
                        ElseIf Val(ds.Tables(0).Rows(Fila)("car_tipo")) = 2 Then
                            optProveedor.Checked = True
                        ElseIf Val(ds.Tables(0).Rows(Fila)("car_tipo")) = 3 Then
                            optAmbos.Checked = True
                        End If

                        If ds.Tables(0).Rows(Fila)("dd_descripcion") = "GD" Then
                            optGD.Checked = True
                        ElseIf ds.Tables(0).Rows(Fila)("dd_descripcion") = "FA" Then
                            OptFactura.Checked = True
                        Else
                            optGD.Checked = False
                            OptFactura.Checked = False
                        End If

                        chkAutonumerico.Checked = ds.Tables(0).Rows(Fila)("car_numOC_auto")
                        chkVV.Checked = ds.Tables(0).Rows(Fila)("car_funcionaVV")

                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_REGIONES()
        Dim _msg As String
        Try
            Dim classComun As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classComun.cnn = _cnn
            _msg = ""
            ds = classComun.CARGA_COMBO_REGIONES(_msg)
            If _msg = "" Then
                Me.cmbRegion.DataSource = ds.Tables(0)
                Me.cmbRegion.DisplayMember = "mensaje"
                Me.cmbRegion.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_REGIONES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_CIUDAD()
        Dim _msg As String
        Try
            Dim classComun As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classComun.cnn = _cnn
            classComun.IdRegion = cmbRegion.SelectedValue
            _msg = ""
            ds = classComun.CARGA_COMBO_CIUDADES(_msg)
            If _msg = "" Then
                Me.cmbCiudad.DataSource = ds.Tables(0)
                Me.cmbCiudad.DisplayMember = "mensaje"
                Me.cmbCiudad.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CIUDAD", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_COMUNA()
        Dim _msg As String
        Try
            Dim classComun As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classComun.cnn = _cnn
            classComun.IdCiudad = cmbCiudad.SelectedValue
            _msg = ""
            ds = classComun.CARGA_COMBO_COMUNAS(_msg)
            If _msg = "" Then
                Me.cmbComunas.DataSource = ds.Tables(0)
                Me.cmbComunas.DisplayMember = "mensaje"
                Me.cmbComunas.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_COMUNA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegion.SelectedIndexChanged

    End Sub

    Private Sub cmbRegion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbRegion.SelectionChangeCommitted
        cmbCiudad.DataSource = Nothing
        cmbCiudad.Items.Clear()

        cmbComunas.DataSource = Nothing
        cmbComunas.Items.Clear()

        If cmbRegion.SelectedValue > 0 Then
            Call CARGA_COMBO_CIUDAD()
        End If
    End Sub
    Private Sub cmbCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCiudad.SelectedIndexChanged

    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA_FORM() = False Then
            Exit Sub
        End If

        Call GUARDA_REGISTRO()

    End Sub

    Private Sub GUARDA_REGISTRO()
        Dim classCartera As class_cartera = New class_cartera
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classCartera.cnn = _cnn
            classCartera.car_codigo = _car_codigo
            classCartera.car_nombre = txtNombre.Text
            classCartera.car_rut = txtRut.Text
            classCartera.direccion = txtCalle.Text
            classCartera.car_region = cmbRegion.SelectedValue
            classCartera.car_ciudad = cmbCiudad.SelectedValue
            classCartera.car_comuna = cmbComunas.SelectedValue
            classCartera.car_activo = chkActivo.Checked
            classCartera.car_muestra_inf = chkIncluye.Checked

            If optcliente.Checked = True Then
                classCartera.car_tipoas = 1
            ElseIf optProveedor.Checked = True Then
                classCartera.car_tipoas = 2
            ElseIf optAmbos.Checked = True Then
                classCartera.car_tipoas = 3
            End If

            classCartera.car_telefono = txtFono.Text
            classCartera.dias_plazo_entrega = txtDiasplazo.Text
            classCartera.car_numOC_auto = chkAutonumerico.Checked
            classCartera.car_funcionaVV = chkVV.Checked

            ds = classCartera.CARTERA_GUARDA_REGISTRO(_msgError)

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
                    _car_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If

            'TIPOS DE DESPACHO
            ds = Nothing
            classCartera.car_codigo = _car_codigo

            If OptFactura.Checked = True Then
                classCartera.dde_descripcion = "FA"
            ElseIf optGD.Checked = True Then
                classCartera.dde_descripcion = "GD"
            End If
            ds = classCartera.CARTERA_DOCUMENTO_DESPACHO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    'Else
                    '    _car_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If

            ds = Nothing

            MessageBox.Show("Los datos fueron guardados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Function VALIDA_FORM()
        Dim classComun As class_comunes = New class_comunes

        VALIDA_FORM = False
        If Trim(txtRut.Text) = "" Then
            MessageBox.Show("Debe ingresar un rut , favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRut.Focus()
            Exit Function
        End If

        If classComun.validarRut(txtRut.Text) = False Then
            MessageBox.Show("rut no valido, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRut.Focus()
            Exit Function
        End If

        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Function
        End If

        'If cmbRegion.SelectedValue = 0 Then
        '    MessageBox.Show("Debe ingresar region, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cmbRegion.Focus()
        '    Exit Function
        'End If
        'If cmbCiudad.SelectedValue = 0 Then
        '    MessageBox.Show("Debe ingresar ciudad, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cmbCiudad.Focus()
        '    Exit Function
        'End If
        'If cmbComunas.SelectedValue = 0 Then
        '    MessageBox.Show("Debe ingresar comuna, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cmbComunas.Focus()
        '    Exit Function
        'End If
        'If cod_tipoCli = 0 Then
        '    MessageBox.Show("Debe ingresar tipo, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cmbComunas.Focus()
        '    Exit Function
        'End If

        VALIDA_FORM = True

    End Function

    Private Sub txtFono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFono.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtDiasplazo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasplazo.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbCiudad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCiudad.SelectionChangeCommitted

        cmbComunas.DataSource = Nothing
        cmbComunas.Items.Clear()

        If cmbCiudad.SelectedValue > 0 Then
            Call CARGA_COMBO_COMUNA()
        End If
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        _car_codigo = 0
        Call LIMPIAR()
    End Sub

    Private Sub LIMPIAR()
        txtRut.Text = ""
        optcliente.Checked = True
        txtNombre.Text = ""

        cmbCiudad.DataSource = Nothing
        cmbCiudad.Items.Clear()

        cmbComunas.DataSource = Nothing
        cmbComunas.Items.Clear()

        Call CARGA_COMBO_REGIONES()

        txtCalle.Text = ""
        txtFono.Text = ""
        txtDiasplazo.Text = "0"

        chkActivo.Checked = True
        chkIncluye.Checked = False
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonProductos_Click(sender As Object, e As EventArgs) Handles ButtonProductos.Click
        If _car_codigo = 0 Then
            MessageBox.Show("El cliente debe estar ingresado en la base de datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRut.Focus()
            Exit Sub
        End If

        If optProveedor.Checked = True Then
            MessageBox.Show("El funcionalidad no apta para proveedores", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRut.Focus()
            Exit Sub
        End If

        Dim frm As frm_clientes_productos = New frm_clientes_productos
        frm.cnn = _cnn
        frm.car_codigo = _car_codigo
        frm.ShowDialog()
    End Sub

    Private Sub txtRut_TextChanged(sender As Object, e As EventArgs) Handles txtRut.TextChanged

    End Sub
End Class