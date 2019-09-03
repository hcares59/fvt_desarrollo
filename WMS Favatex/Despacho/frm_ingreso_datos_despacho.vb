Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class frm_ingreso_datos_despacho
    Private _cnn As String
    Private _sel_codigo As String
    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""
    Dim embarqueIngresado As Boolean = False
    Dim requiereComplemento As Boolean = False

    'GRILLA DETALLES PENDIENTE DE EMBARQUE
    Const CON_BUS_CAR_CODIGO As Integer = 0
    Const CON_BUS_PIC_CODIGO As Integer = 1
    Const CON_BUS_PIC_FILA As Integer = 2
    Const CON_BUS_S As Integer = 3
    Const CON_BUS_N_PICKING As Integer = 4
    Const CON_BUS_O_COMPRA As Integer = 5
    Const CON_BUS_FACTURA As Integer = 6
    Const CON_BUS_GUIA_DESP As Integer = 7
    Const CON_BUS_GUIA_FECHA As Integer = 8
    Const CON_BUS_DESPACHAR_A As Integer = 9
    Const CON_BUS_CODIGO As Integer = 10
    Const CON_BUS_PRODUCTO As Integer = 11
    Const CON_BUS_CANT As Integer = 12
    Const CON_BUS_PDD_FILA As Integer = 13
    Const CON_BUS_ES_FUEDEVUELTA As Integer = 14

    'GRILLA DETALLES EMBARCADOS
    Const CON_MAR_CAR_CODIGO As Integer = 0
    Const CON_MAR_PIC_CODIGO As Integer = 1
    Const CON_MAR_PIC_FILA As Integer = 2
    Const CON_MAR_S As Integer = 3
    Const CON_MAR_N_PICKING As Integer = 4
    Const CON_MAR_FACTURA As Integer = 5
    Const CON_MAR_GUIA_DESP As Integer = 6
    Const CON_MAR_GUIA_FECHA As Integer = 7
    Const CON_MAR_CODIGO As Integer = 8
    Const CON_MAR_PRODUCTO As Integer = 9
    Const CON_MAR_CANT As Integer = 10
    Const CON_MAR_CANT_O As Integer = 11
    Const CON_MAR_DESPACHAR_A As Integer = 12
    Const CON_MAR_QUITAR As Integer = 13
    Const CON_MAR_PDD_FILA As Integer = 14
    Const CON_MAR_ES_FUEDEVUELTA As Integer = 15
    Const CON_MAR_FACT2 As Integer = 16
    Const CON_MAR_GUIA2 As Integer = 17





    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property sel_codigo() As String
        Get
            Return _sel_codigo
        End Get
        Set(ByVal value As String)
            _sel_codigo = value
        End Set
    End Property
    Private Sub frm_ingreso_datos_despacho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Call INICIALIZA()

        If _sel_codigo <> "" Then
            embarqueIngresado = True
            txtSello.Text = _sel_codigo
            Call CARGA_DATOS_ENCABEZADO()
            Call CUENTA_MUESTRA_PALLETS()
        End If
    End Sub

    Sub CUENTA_MUESTRA_PALLETS()
        Dim classEmbarque As class_embarque = New class_embarque
        Dim _msgError As String = ""
        Dim ds As DataSet
        Try
            classEmbarque.emb_sello = _sel_codigo
            For Each row As DataGridViewRow In Me.grilla_pallets.Rows
                If row.Cells(0).Value <> "" Then
                    If row.Cells(1).Value <> "" Then
                        Dim fila As Integer = 0
                        Dim _msg As String = ""
                        Try
                            classEmbarque.cnn = _cnn
                            classEmbarque.emb_codigointerno = row.Cells(0).Value
                            ds = classEmbarque.CANT_DESPACHO_EMBARQUE_PALLET_SELECCIONAR(_msgError)
                            If ds.Tables(0).Rows(fila)("dep_num_guia") > 0 Then
                                txtNumeroGuia.Text = ds.Tables(0).Rows(fila)("dep_num_guia")

                            End If

                            row.Cells(2).Value = ds.Tables(0).Rows(fila)("dep_cantidad")
                            ds = Nothing
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(_msgError + "\carga_grilla_seleccion_palett", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_COMBO_TRANSP_EXTERNOS()
        Dim _msg As String
        Try
            Dim classTrans As class_transp_externo = New class_transp_externo
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classTrans.cnn = _cnn
            _msg = ""
            ds = classTrans.carga_combo_emp_extern(_msg)
            If _msg = "" Then
                cmb_transporte_externo.DataSource = ds.Tables(0)
                Me.cmb_transporte_externo.DisplayMember = "MENSAJE"
                Me.cmb_transporte_externo.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TRANSPORTE_EXTERNO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_DATOS_ENCABEZADO()
        Dim classEmbarque As class_embarque = New class_embarque
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classEmbarque.cnn = _cnn
            classEmbarque.emb_sello = _sel_codigo
            classEmbarque.emb_tipo = 0
            classEmbarque.fecha_despacho_desde = "19000101"
            classEmbarque.fecha_despacho_hasta = "20501231"
            classEmbarque.tipoDocumento = "N"
            classEmbarque.numDocumento = 0

            ds = classEmbarque.DESPACHO_EMBARQUE_ENC_LISTADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("emb_sello") <> "" Then
                        txtSello.Text = ds.Tables(0).Rows(Fila)("emb_sello")
                        txtSello.Enabled = False
                        txtFecha.Value = ds.Tables(0).Rows(Fila)("emb_fechadespacho")
                        txtHora.Text = ds.Tables(0).Rows(Fila)("emb_horacita")

                        If ds.Tables(0).Rows(Fila)("emb_tipo") = 1 Then
                            OptPropio.Checked = True

                            Call CARGA_COMBO_CHOFER()
                            cmbUsuario.SelectedValue = ds.Tables(0).Rows(Fila)("usu_chofer")

                            Call CARGA_COMBO_VEHICULO()
                            cmbTransporte.SelectedValue = ds.Tables(0).Rows(Fila)("veh_codigo")

                            cmbUsuario.Visible = True
                            cmbTransporte.Visible = True

                            If ds.Tables(0).Rows(Fila)("veh_codigocomplemento") > 0 Then
                                requiereComplemento = True
                                Call CARGA_COMBO_COMPLEMENTO()
                                cmbComplemento.SelectedValue = ds.Tables(0).Rows(Fila)("veh_codigocomplemento")
                            Else
                                requiereComplemento = False
                                cmbComplemento.DataSource = Nothing
                                cmbComplemento.Items.Clear()
                            End If

                            txtCapacPalletDobleSodimac.Text = ds.Tables(0).Rows(Fila)("emb_cantpalletdoble_sodimac")
                            txtChofer.Visible = False
                            txtTransporte.Visible = False
                        ElseIf ds.Tables(0).Rows(Fila)("emb_tipo") = 2 Then
                            OptExterno.Checked = True

                            cmbUsuario.SelectedValue = 0
                            cmbTransporte.SelectedValue = 0

                            txtChofer.Text = ds.Tables(0).Rows(Fila)("emb_chofernombre")
                            txtTransporte.Text = ds.Tables(0).Rows(Fila)("emb_transporte")

                            cmbUsuario.Visible = False
                            cmbTransporte.Visible = False

                            txtChofer.Visible = True
                            txtTransporte.Visible = True

                            requiereComplemento = False
                            cmbComplemento.DataSource = Nothing
                            cmbComplemento.Items.Clear()
                            txtCapacPalletDobleSodimac.Text = ds.Tables(0).Rows(Fila)("emb_cantpalletdoble_sodimac")
                        End If

                        txtCapacidaPal.Text = ds.Tables(0).Rows(Fila)("emb_cantpallet")
                        txtCapacPalletDoble.Text = ds.Tables(0).Rows(Fila)("emb_cantpalletdoble")

                        Call CARGA_GRILLA_DETALLE()

                        TabControl1.SelectedIndex = 1
                        Me.TabPage1.Parent = Nothing
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_ENCABEZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_ENCABEZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLE()
        Dim classEmbarque As class_embarque = New class_embarque
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classEmbarque.cnn = _cnn
            classEmbarque.emb_sello = _sel_codigo

            ds = classEmbarque.DESPACHO_EMBARQUE_DET_LISTADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaSel.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("emb_sello") <> "-" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaSel.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                               ds.Tables(0).Rows(Fila)("pic_codigo"),
                                               ds.Tables(0).Rows(Fila)("pic_fila"),
                                               False,
                                               ds.Tables(0).Rows(Fila)("num_piciking"),
                                               ds.Tables(0).Rows(Fila)("emd_nfactura"),
                                               ds.Tables(0).Rows(Fila)("emb_nguia"),
                                               ds.Tables(0).Rows(Fila)("emb_fguia"),
                                               ds.Tables(0).Rows(Fila)("emb_codigointerno"),
                                               ds.Tables(0).Rows(Fila)("emb_nombreproducto"),
                                               ds.Tables(0).Rows(Fila)("emb_cantidad"),
                                               0, 0,
                                               ds.Tables(0).Rows(Fila)("pdd_fila"),
                                               0,
                                               ds.Tables(0).Rows(Fila)("emd_nfactura"),
                                               ds.Tables(0).Rows(Fila)("emb_nguia")
                                               )
                            Fila = Fila + 1
                        Loop
                    End If
                End If
                'GrillaSel.Columns(11).Visible = False

                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub INICIALIZA()
        txtSello.Text = ""

        txtCapacidaPal.Text = "0"
        txtCapacPalletDoble.Text = "0"
        txtCapacPalletDobleSodimac.Text = "0"

        Call CARGA_COMBO_VEHICULO()
        Call CARGA_COMBO_CHOFER()
        Call CARGA_COMBO_CLIENTE()
        Call CARGA_COMBO_TRANSP_EXTERNOS()
        Call CARGA_GRILLA_SELECCION_PALLET()

        txtChofer.Text = ""
        txtTransporte.Text = ""

        OptPropio.Checked = 1
        'txtFecha.Value = GLO_FECHA_SISTEMA

        Grilla.DataSource = Nothing
        Grilla.Rows.Clear()

        GrillaSel.DataSource = Nothing
        GrillaSel.Rows.Clear()

        cmbComplemento.DataSource = Nothing
        cmbComplemento.Items.Clear()
        cmbComplemento.Enabled = False

        requiereComplemento = False

    End Sub

    Private Sub CARGA_GRILLA_SELECCION_PALLET()
        Dim classEmbarque As class_embarque = New class_embarque
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classEmbarque.cnn = _cnn
            _sel_codigo = IIf(Len(_sel_codigo) > 0, _sel_codigo, "")

            classEmbarque.emb_sello = _sel_codigo
            ds = classEmbarque.DESPACHO_EMBARQUE_PALLET_SELECCIONAR(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    grilla_pallets.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pal_codigo_interno") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grilla_pallets.Rows.Add(ds.Tables(0).Rows(Fila)("pal_codigo_interno"),
                                               ds.Tables(0).Rows(Fila)("pal_descripcion"),
                                               ds.Tables(0).Rows(Fila)("dep_cantidad"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
                grilla_pallets.Columns(1).ReadOnly = True
                Fila = 0
                Call CUENTA_MUESTRA_PALLETS()
                ' Call conteo_grilla_seleccion_palett()
            Else
                MessageBox.Show(_msgError + "\carga_grilla_seleccion_palett", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\carga_grilla_seleccion_palett", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_COMBO_CHOFER()
        Dim _msg As String
        Try
            Dim classChofer As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classChofer.cnn = _cnn
            _msg = ""
            ds = classChofer.CARGA_COMBO_CHOFER(_msg)
            If _msg = "" Then
                Me.cmbUsuario.DataSource = ds.Tables(0)
                Me.cmbUsuario.DisplayMember = "MENSAJE"
                Me.cmbUsuario.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CHOFER", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_VEHICULO()
        Dim _msg As String
        Try
            Dim classVehiculo As class_vehiculo = New class_vehiculo
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classVehiculo.cnn = _cnn
            _msg = ""
            ds = classVehiculo.CARGA_COMBO_VEHICULO(_msg)
            If _msg = "" Then
                Me.cmbTransporte.DataSource = ds.Tables(0)
                Me.cmbTransporte.DisplayMember = "MENSAJE"
                Me.cmbTransporte.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_VEHICULO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_CLIENTE()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
            If _msg = "" Then
                Me.cmbCliente.DataSource = ds.Tables(0)
                Me.cmbCliente.DisplayMember = "MENSAJE"
                Me.cmbCliente.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CLIENTE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub OptPropio_CheckedChanged(sender As Object, e As EventArgs) Handles OptPropio.CheckedChanged
        If OptPropio.Checked = True Then
            txtChofer.Visible = False
            txtTransporte.Visible = False
            cmbUsuario.Visible = True
            cmbTransporte.Visible = True
            cmb_transporte_externo.Enabled = False
        Else
            txtChofer.Visible = True
            txtTransporte.Visible = True
            cmbUsuario.Visible = False
            cmbTransporte.Visible = False
            cmb_transporte_externo.Enabled = True
        End If
    End Sub

    Private Sub OptExterno_CheckedChanged(sender As Object, e As EventArgs) Handles OptExterno.CheckedChanged
        If OptExterno.Checked = True Then
            txtChofer.Visible = True
            txtTransporte.Visible = True
            cmbUsuario.Visible = False
            cmbTransporte.Visible = False
            cmb_transporte_externo.Enabled = True
        Else
            txtChofer.Visible = False
            txtTransporte.Visible = False
            cmbUsuario.Visible = True
            cmbTransporte.Visible = True
            cmb_transporte_externo.Enabled = False
        End If
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        If cmbCliente.Text = "" Then
            MessageBox.Show("Debe seleccionar el cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Sub
        End If

        'If txtNumero.Text = "" Or txtNumero.Text = "0" Then
        '    MessageBox.Show("Debe ingresar el número de la GD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtNumero.Focus()
        '    Exit Sub
        'End If

        Call CARGA_GRILLA_PENDIENTE_DESPACHO()
    End Sub

    Private Sub CARGA_GRILLA_PENDIENTE_DESPACHO()
        Dim classDespacho As class_despacha_picking = New class_despacha_picking
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classDespacho.cnn = _cnn

            If cmbCliente.Text = "" Then
                classDespacho.car_codigo = 0
            Else
                classDespacho.car_codigo = cmbCliente.SelectedValue
            End If

            If txtNumPiking.Text = "" Then
                classDespacho.pic_codigo = 0
            Else
                classDespacho.pic_codigo = CInt(txtNumPiking.Text)
            End If

            If txtOC.Text = "" Then
                classDespacho.oc_numero = 0
            Else
                classDespacho.oc_numero = CLng(txtOC.Text)
            End If

            If txtFactura.Text = "" Then
                classDespacho.fac_numero = 0
            Else
                classDespacho.fac_numero = CLng(txtFactura.Text)
            End If

            'classDespacho.gde_numero = CLng(txtNumero.Text)

            _msg = ""
            Grilla.Rows.Clear()
            ds = classDespacho.PRODUCTOS_PENDIENTE_EMBARQUE_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_fila"),
                                            False,
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            ds.Tables(0).Rows(Fila)("pic_ordencompra"),
                                            ds.Tables(0).Rows(Fila)("fac_numero"),
                                            ds.Tables(0).Rows(Fila)("gde_numero"),
                                            ds.Tables(0).Rows(Fila)("gde_fecha"),
                                            ds.Tables(0).Rows(Fila)("LugarDespacho"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("cantidad_pendiente"),
                                            ds.Tables(0).Rows(Fila)("pdd_fila"),
                                            ds.Tables(0).Rows(Fila)("es_fuedevuelta"))
                            Fila = Fila + 1
                        Loop
                        Call PINTA_REGISTROS_DEVUELTOS_GRILLA()
                    End If
                End If
                lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString

            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PENDIENTE_DESPACHO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PENDIENTE_DESPACHO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub PINTA_REGISTROS_DEVUELTOS_GRILLA()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(CON_BUS_ES_FUEDEVUELTA).Value = True Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
                row.DefaultCellStyle.ForeColor = Color.Orange
            End If
        Next
    End Sub

    Private Function REQUIERE_AGRUPACION_POR_DESPACHO(ByVal codigoCliente As Integer) As Boolean
        Dim classCliente As class_cartera = New class_cartera
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        REQUIERE_AGRUPACION_POR_DESPACHO = False
        Try
            classCliente.cnn = _cnn
            classCliente.car_codigo = codigoCliente

            ds = classCliente.REQUIERE_GRUPAR_POR_DESPACHO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") <> 0 Then
                        REQUIERE_AGRUPACION_POR_DESPACHO = ds.Tables(0).Rows(Fila)("car_requiere_agrupar_x_despacho")
                    End If
                End If
            Else
                REQUIERE_AGRUPACION_POR_DESPACHO = False
                MessageBox.Show(_msgError + "\REQUIERE_AGRUPACION_POR_DESPACHO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            REQUIERE_AGRUPACION_POR_DESPACHO = False
            MessageBox.Show(ex.Message + "\REQUIERE_AGRUPACION_POR_DESPACHO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub ButtonSelecciona_Click(sender As Object, e As EventArgs) Handles ButtonSelecciona.Click
        Dim fila As Integer = 0
        Dim Despachar As String = ""

        If cmbCliente.SelectedValue = CLIENTES.RIPLEY Then
            If REQUIERE_AGRUPACION_POR_DESPACHO(cmbCliente.SelectedValue) = True Then
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(CON_BUS_S).Value = True Then
                        If fila = 0 Then
                            Despachar = row.Cells(CON_BUS_DESPACHAR_A).Value.ToString
                            'LugarDespacho = row.Cells(4).Value
                        Else
                            If Trim(Despachar) <> Trim(row.Cells(CON_BUS_DESPACHAR_A).Value.ToString) Then
                                MessageBox.Show("Existen ordenes seleccionadas con distinto lugar de despacho, por favor revisar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        End If
                        fila = fila + 1
                    End If
                Next
            End If
        End If


        Call GUARDA_REGISTRO_TEMPORAL()
    End Sub

    Private Sub GUARDA_REGISTRO_TEMPORAL()
        Dim classDespacho As class_despacha_picking = New class_despacha_picking
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

                For Each row As DataGridViewRow In Me.Grilla.Rows

                    If row.Cells(CON_BUS_S).Value = True Then
                        classDespacho.car_codigo = row.Cells(CON_BUS_CAR_CODIGO).Value
                        classDespacho.pic_codigo = row.Cells(CON_BUS_PIC_CODIGO).Value
                        classDespacho.pic_fila = row.Cells(CON_BUS_PIC_FILA).Value
                        classDespacho.pdd_fila = row.Cells(CON_BUS_PDD_FILA).Value

                        ds = classDespacho.DESPACHO_EMBARQUE_TEMP_INGRESA(_msgError, conexion)

                        If _msgError <> "" Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            ds = Nothing
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            GrillaSel.Rows.Clear()
                            Exit Sub
                        Else
                            If ds.Tables(0).Rows(0)("codigo") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                ds = Nothing
                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                GrillaSel.Rows.Clear()
                                Exit Sub
                            Else
                                GrillaSel.Rows.Add(row.Cells(CON_BUS_CAR_CODIGO).Value,
                                                    row.Cells(CON_BUS_PIC_CODIGO).Value,
                                                    row.Cells(CON_BUS_PIC_FILA).Value,
                                                    False,
                                                    row.Cells(CON_BUS_N_PICKING).Value,
                                                    row.Cells(CON_BUS_FACTURA).Value,
                                                    row.Cells(CON_BUS_GUIA_DESP).Value,
                                                    CDate(row.Cells(CON_BUS_GUIA_FECHA).Value).ToShortDateString,
                                                    row.Cells(CON_BUS_CODIGO).Value,
                                                    row.Cells(CON_BUS_PRODUCTO).Value,
                                                    row.Cells(CON_BUS_CANT).Value,
                                                    row.Cells(CON_BUS_CANT).Value,
                                                    row.Cells(CON_BUS_DESPACHAR_A).Value,
                                                    0,
                                                    row.Cells(CON_BUS_PDD_FILA).Value,
                                                    row.Cells(CON_BUS_ES_FUEDEVUELTA).Value,
                                                    row.Cells(CON_BUS_FACTURA).Value,
                                                    row.Cells(CON_BUS_GUIA_DESP).Value)

                            End If
                        End If
                    End If
                Next
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Call PINTA_REGISTROS_SELECCIONADOS_GRILLA()
                Call CARGA_GRILLA_PENDIENTE_DESPACHO()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PINTA_REGISTROS_SELECCIONADOS_GRILLA()
        For Each row As DataGridViewRow In Me.GrillaSel.Rows

            If row.Cells(CON_MAR_ES_FUEDEVUELTA).Value = True Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
                row.DefaultCellStyle.ForeColor = Color.Orange
            End If
        Next
    End Sub

    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        Call ELIMINA_REGISTRO_TEMPORAL()
    End Sub

    Private Sub ELIMINA_REGISTRO_TEMPORAL()
        Dim classDespacho As class_despacha_picking = New class_despacha_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0
        Dim i As Integer = 0
        Dim filas As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                For Each row As DataGridViewRow In Me.GrillaSel.Rows
                    classDespacho.car_codigo = row.Cells(CON_MAR_CAR_CODIGO).Value
                    classDespacho.pic_codigo = row.Cells(CON_MAR_PIC_CODIGO).Value
                    classDespacho.pic_fila = row.Cells(CON_MAR_PIC_FILA).Value
                    classDespacho.pdd_fila = row.Cells(CON_MAR_PDD_FILA).Value

                    ds = classDespacho.DESPACHO_EMBARQUE_TEMP_ELIMINA(_msgError, conexion)

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
                            'Else
                            '    GrillaSel.Rows.Remove(GrillaSel.Rows(i))
                            '    GrillaSel.Refresh()
                        End If
                    End If
                Next

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Call CARGA_GRILLA_PENDIENTE_DESPACHO()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrillaSel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaSel.CellContentClick
        Try
            If e.ColumnIndex = CON_MAR_QUITAR Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) que desea quitar el registro de la selección?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    If embarqueIngresado = False Then
                        If QUITA_REGISTRO(GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_CAR_CODIGO).Value, GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_PIC_CODIGO).Value, GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_PIC_FILA).Value, GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_PDD_FILA).Value) = True Then
                            GrillaSel.Rows.Remove(GrillaSel.Rows(e.RowIndex))
                        End If
                    Else
                        If OBTIENE_CANTIDAD_REGISTRO() > 1 Then
                            If ELIMINA_FILA_EMBARQUE(GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_PIC_CODIGO).Value, GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_PIC_FILA).Value, GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_CANT).Value) = True Then
                                GrillaSel.Rows.Remove(GrillaSel.Rows(e.RowIndex))
                            End If
                        Else
                            If vbYes = MessageBox.Show("El embarque solo cuenta con una fila de detalle, si lo elimina eliminará el documento completo" _
                                                       + Chr(10) + "¿Esta seguro(a) que desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then

                                If ELIMINA_FILA_EMBARQUE(GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_PIC_CODIGO).Value, GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_PIC_FILA).Value, GrillaSel.Rows(e.RowIndex).Cells(CON_MAR_CANT).Value) = True Then
                                    GrillaSel.Rows.Remove(GrillaSel.Rows(e.RowIndex))
                                    ELIMINA_ENCABEZADO_EMBARQUE()
                                    Me.Dispose()
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function OBTIENE_CANTIDAD_REGISTRO() As Integer
        Dim classEmbarque As class_embarque = New class_embarque
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classEmbarque.cnn = _cnn
            classEmbarque.emb_sello = _sel_codigo

            ds = classEmbarque.DESPACHO_EMBARQUE_CANT_DETALLE_OBTIENE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    OBTIENE_CANTIDAD_REGISTRO = ds.Tables(0).Rows(Fila)("cantidad")
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_CANTIDAD_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\OBTIENE_CANTIDAD_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function ELIMINA_ENCABEZADO_EMBARQUE() As Boolean
        Dim classEmbarque As class_embarque = New class_embarque
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0
        Dim i As Integer = 0
        Dim filas As Integer = 0

        ELIMINA_ENCABEZADO_EMBARQUE = False

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classEmbarque.emb_sello = _sel_codigo
                ds = classEmbarque.DESPACHO_EMBARQUE_ENCABEZADO_ELIMINA(_msgError, conexion)

                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Function
                Else
                    If ds.Tables(0).Rows(0)("codigo") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Exit Function
                    Else
                        ELIMINA_ENCABEZADO_EMBARQUE = True
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Function


    Private Function ELIMINA_FILA_EMBARQUE(ByVal pic_codigo As Integer, ByVal pic_fila As Integer, ByVal cantidad As Integer) As Boolean
        Dim classEmbarque As class_embarque = New class_embarque
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0
        Dim i As Integer = 0
        Dim filas As Integer = 0

        ELIMINA_FILA_EMBARQUE = False

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classEmbarque.pic_codigo = pic_codigo
                classEmbarque.pic_fila = pic_fila
                classEmbarque.emb_cantidad = cantidad

                ds = classEmbarque.DESPACHO_EMBARQUE_DETALLE_ELIMINA_FILA(_msgError, conexion)

                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Function
                Else
                    If ds.Tables(0).Rows(0)("codigo") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Exit Function
                    Else
                        ELIMINA_FILA_EMBARQUE = True
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                'Call CARGA_GRILLA_PENDIENTE_DESPACHO()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Function


    Private Function QUITA_REGISTRO(ByVal car_codigo As Integer, ByVal pic_codigo As Integer, ByVal pic_fila As Integer, ByVal pdd_fila As Integer) As Boolean
        Dim classDespacho As class_despacha_picking = New class_despacha_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0
        Dim i As Integer = 0
        Dim filas As Integer = 0

        QUITA_REGISTRO = False

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classDespacho.car_codigo = car_codigo
                classDespacho.pic_codigo = pic_codigo
                classDespacho.pic_fila = pic_fila
                classDespacho.pdd_fila = pdd_fila

                ds = classDespacho.DESPACHO_EMBARQUE_TEMP_ELIMINA(_msgError, conexion)

                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Function
                Else
                    If ds.Tables(0).Rows(0)("codigo") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Exit Function
                    Else
                        QUITA_REGISTRO = True
                        '    GrillaSel.Rows.Remove(GrillaSel.Rows(i))
                        '    GrillaSel.Refresh()
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Call CARGA_GRILLA_PENDIENTE_DESPACHO()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Function


    Private Sub GrillaSel_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GrillaSel.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        PrecionaTeclaDesde = "GrillaSel"
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
    End Sub

    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = GrillaSel.CurrentCell.ColumnIndex
        Dim fila As Integer = GrillaSel.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = CON_MAR_CANT) Or (columna = CON_MAR_FACTURA) Or (columna = CON_MAR_GUIA_DESP) Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar  
                e.KeyChar = Chr(0)
            End If
        End If

        'If (columna = 2) Then
        '    Dim caracter As Char = e.KeyChar

        '    ' referencia a la celda  
        '    Dim txt As TextBox = CType(sender, TextBox)

        '    ' comprobar si es un número con isNumber, si es el backspace, si el caracter  

        '    ' es el separador decimal, y que no contiene ya el separador 

        '    If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ",") And (txt.Text.Contains(",") = False) Then

        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'End If

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim columna As Integer
        Dim fila As Integer
        Dim nDocumento As String = ""
        Try
            Select Case keyData
                Case Keys.Escape

                    ' No hacemos nada porque se supone

                    ' que la tecla Escape cancela la acción.

                Case Keys.Enter
                    '=========================================================
                    'PRECIONA TECLA CON EL FOCO EN LA GRILLA DE FINANCIAMIENTO
                    '=========================================================
                    'If GrillaFinanciamiento.Focus = True Then
                    If PrecionaTeclaDesde = "GrillaSel" Then
                        columna = GrillaSel.CurrentCell.ColumnIndex
                        fila = GrillaSel.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""

                Case Keys.Left
                    If PrecionaTeclaDesde = "GrillaSel" Then
                        columna = GrillaSel.CurrentCell.ColumnIndex
                        fila = GrillaSel.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""

                Case Keys.Right
                    If PrecionaTeclaDesde = "GrillaSel" Then
                        columna = GrillaSel.CurrentCell.ColumnIndex
                        fila = GrillaSel.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""
                Case Keys.Up
                    If PrecionaTeclaDesde = "GrillaSel" Then
                        columna = GrillaSel.CurrentCell.ColumnIndex
                        fila = GrillaSel.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""
                Case Keys.Down
                    If PrecionaTeclaDesde = "GrillaSel" Then
                        columna = GrillaSel.CurrentCell.ColumnIndex
                        fila = GrillaSel.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""
                Case Else

                    Return MyBase.ProcessCmdKey(msg, keyData)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub EDITA_GRILA_SELECCIONADOS(ByVal columna As Integer, ByVal fila As Integer)
        Dim nDocumento As String = ""

        Try
            If (columna = CON_MAR_CANT) Then
                If (cellTextBox IsNot Nothing) Then
                    With GrillaSel
                        If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                            .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                        ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                            .CurrentCell = .Item(.CurrentCell.ColumnIndex - 1, 0)
                        End If
                    End With
                End If

                If GrillaSel.Rows(fila).Cells(CON_MAR_CANT).Value = "" Then
                    GrillaSel.Rows(fila).Cells(CON_MAR_CANT).Value = 0
                End If

                If GrillaSel.Rows(fila).Cells(CON_MAR_CANT).Value > GrillaSel.Rows(fila).Cells(CON_MAR_CANT_O).Value Then
                    MessageBox.Show("la cantidad ingresada no puede ser mayor a la cantidad pendiente de despacho", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    GrillaSel.Rows(fila).Cells(CON_MAR_CANT).Value = GrillaSel.Rows(fila).Cells(CON_MAR_CANT_O).Value
                    Exit Sub
                End If
            ElseIf (columna = CON_MAR_FACTURA) Then

                nDocumento = GrillaSel.Rows(fila).Cells(CON_MAR_FACTURA).Value

                If (cellTextBox IsNot Nothing) Then
                    With GrillaSel
                        If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                            .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                        ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                            .CurrentCell = .Item(.CurrentCell.ColumnIndex - 1, 0)
                        End If
                    End With
                End If

                If GrillaSel.Rows(fila).Cells(CON_MAR_ES_FUEDEVUELTA).Value = False Then
                    If nDocumento <> GrillaSel.Rows(fila).Cells(CON_MAR_FACTURA).Value Then
                        MessageBox.Show("El registro no pertenece a una devolución, por este motivo no esta permitido modificar el número de sus documentos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        GrillaSel.Rows(fila).Cells(CON_MAR_FACTURA).Value = nDocumento
                        Exit Sub
                    End If
                End If

            ElseIf (columna = CON_MAR_GUIA_DESP) Then

                nDocumento = GrillaSel.Rows(fila).Cells(CON_MAR_GUIA_DESP).Value

                If (cellTextBox IsNot Nothing) Then
                    With GrillaSel
                        If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                            .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                        ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                            .CurrentCell = .Item(.CurrentCell.ColumnIndex - 1, 0)
                        End If
                    End With
                End If
                If GrillaSel.Rows(fila).Cells(CON_MAR_ES_FUEDEVUELTA).Value = False Then
                    MessageBox.Show("El registro no pertenece a una devolución, por este motivo no esta permitido modificar el número de sus documentos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    GrillaSel.Rows(fila).Cells(CON_MAR_GUIA_DESP).Value = nDocumento
                    Exit Sub
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Despachar As String = ""
        Dim fila As Integer = 0

        If cmbCliente.SelectedValue = CLIENTES.RIPLEY Then
            If REQUIERE_AGRUPACION_POR_DESPACHO(cmbCliente.SelectedValue) = True Then
                For Each row As DataGridViewRow In Me.GrillaSel.Rows
                    'If row.Cells(1).Value = True Then
                    If fila = 0 Then
                        Despachar = row.Cells(CON_MAR_DESPACHAR_A).Value.ToString
                        'LugarDespacho = row.Cells(4).Value
                    Else
                        If Trim(Despachar) <> Trim(row.Cells(CON_MAR_DESPACHAR_A).Value.ToString) Then
                            MessageBox.Show("Existen ordenes seleccionadas con distinto lugar de despacho, por favor revisar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    fila = fila + 1
                    'End If
                Next
            End If
        End If


        If VALIDA_DATOS() = False Then
            Exit Sub
        End If

        If VALIDA_DOCUMENTOS_INGRESADOS() = False Then
            Exit Sub
        End If

        Call GUARDA_EMBARQUE()

    End Sub

    Private Function VALIDA_DOCUMENTOS_INGRESADOS() As Boolean
        VALIDA_DOCUMENTOS_INGRESADOS = True
        Try
            For Each row As DataGridViewRow In Me.GrillaSel.Rows
                If row.Cells(CON_MAR_ES_FUEDEVUELTA).Value = False Then
                    If row.Cells(CON_MAR_FACTURA).Value <> row.Cells(CON_MAR_FACT2).Value Then
                        MessageBox.Show("El código [" + row.Cells(CON_MAR_CODIGO).Value + "]  no pertenece a una devolución, por este motivo no esta permitido modificar el número de sus documentos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        row.Cells(CON_MAR_FACTURA).Value = row.Cells(CON_MAR_FACT2).Value
                        VALIDA_DOCUMENTOS_INGRESADOS = False
                        Exit Function
                    End If

                    If row.Cells(CON_MAR_GUIA_DESP).Value <> row.Cells(CON_MAR_GUIA2).Value Then
                        MessageBox.Show("El código [" + row.Cells(CON_MAR_CODIGO).Value + "]  no pertenece a una devolución, por este motivo no esta permitido modificar el número de sus documentos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        row.Cells(CON_MAR_GUIA_DESP).Value = row.Cells(CON_MAR_GUIA2).Value
                        VALIDA_DOCUMENTOS_INGRESADOS = False
                        Exit Function
                    End If

                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            VALIDA_DOCUMENTOS_INGRESADOS = False
        End Try


    End Function


    Private Sub GUARDA_EMBARQUE()
        Dim classEmbaruque As class_embarque = New class_embarque
        Dim classDespacho As class_despacha_picking = New class_despacha_picking
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
                classEmbaruque.emb_sello = txtSello.Text
                classEmbaruque.emb_fechadespacho = txtFecha.Value
                classEmbaruque.emb_usuario = GLO_USUARIO_ACTUAL

                If OptPropio.Checked = True Then
                    classEmbaruque.emb_tipo = 1
                    classEmbaruque.usu_chofer = cmbUsuario.SelectedValue
                    classEmbaruque.veh_codigo = cmbTransporte.SelectedValue
                    classEmbaruque.emb_chofernombre = cmbUsuario.Text
                    classEmbaruque.emb_transporte = cmbTransporte.Text
                    classEmbaruque.veh_codigocomplemento = IIf(cmbComplemento.Text <> "", cmbComplemento.SelectedValue, 0)
                    classEmbaruque.emb_cpmplemento = cmbComplemento.Text
                    classEmbaruque.emb_cantpalletdoble_sodimac = txtCapacPalletDobleSodimac.Text

                Else
                    classEmbaruque.emb_tipo = 2
                    classEmbaruque.usu_chofer = 0
                    classEmbaruque.veh_codigo = 0
                    classEmbaruque.emb_chofernombre = txtChofer.Text
                    classEmbaruque.emb_transporte = txtTransporte.Text
                    classEmbaruque.veh_codigocomplemento = IIf(cmbComplemento.Text <> "", cmbComplemento.SelectedValue, 0)
                    classEmbaruque.emb_cpmplemento = cmbComplemento.Text
                    classEmbaruque.emb_cantpalletdoble_sodimac = txtCapacPalletDobleSodimac.Text
                    classEmbaruque.veh_codigocomplemento = 0
                    classEmbaruque.emb_cpmplemento = ""
                    classEmbaruque.emb_cantpalletdoble_sodimac = "0"
                End If

                classEmbaruque.emb_cantpallet = txtCapacidaPal.Text
                classEmbaruque.emb_cantpalletdoble = txtCapacPalletDoble.Text
                classEmbaruque.emb_horacita = txtHora.Text

                ds = classEmbaruque.DESPACHO_EMBARQUE_GUARDA_DATOS_ENCABEZADO(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Sub
                        'Else
                        '    _bho_codigo = ds.Tables(0).Rows(0)("CODIGO")
                    End If
                End If

                ds = Nothing
                classEmbaruque.emb_sello = txtSello.Text
                ds = classEmbaruque.DESPACHO_EMBARQUE_DETALLE_ELIMINA(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Sub

                    End If
                End If

                ds = Nothing
                Do While fila <= GrillaSel.Rows.Count - 1
                    classEmbaruque.emb_sello = txtSello.Text
                    classEmbaruque.car_codigo = GrillaSel.Rows(fila).Cells(CON_MAR_CAR_CODIGO).Value
                    classEmbaruque.pic_codigo = GrillaSel.Rows(fila).Cells(CON_MAR_PIC_CODIGO).Value
                    classEmbaruque.pic_fila = GrillaSel.Rows(fila).Cells(CON_MAR_PIC_FILA).Value
                    classEmbaruque.num_piciking = GrillaSel.Rows(fila).Cells(CON_MAR_N_PICKING).Value
                    classEmbaruque.emd_nfactura = GrillaSel.Rows(fila).Cells(CON_MAR_FACTURA).Value
                    classEmbaruque.emb_nguia = GrillaSel.Rows(fila).Cells(CON_MAR_GUIA_DESP).Value
                    classEmbaruque.emb_codigointerno = GrillaSel.Rows(fila).Cells(CON_MAR_CODIGO).Value
                    classEmbaruque.emb_nombreproducto = GrillaSel.Rows(fila).Cells(CON_MAR_PRODUCTO).Value
                    classEmbaruque.emb_cantidad = CInt(GrillaSel.Rows(fila).Cells(CON_MAR_CANT).Value)
                    classEmbaruque.pdd_fila = CInt(GrillaSel.Rows(fila).Cells(CON_MAR_PDD_FILA).Value)
                    classEmbaruque.emb_fguia = GrillaSel.Rows(fila).Cells(CON_MAR_GUIA_FECHA).Value
                    _msg = ""

                    ds = classEmbaruque.DESPACHO_EMBARQUE_GUARDA_DATOS_DETALLE(_msg, conexion)
                    If _msg = "" Then
                        If ds.Tables.Count > 0 Then
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State <> ConnectionState.Closed Then
                                    conexion.Close()
                                End If
                                conexion.Dispose()
                                MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Sub
                            End If
                        End If
                    Else
                        If conexion.State <> ConnectionState.Closed Then
                            conexion.Close()
                        End If
                        conexion.Dispose()
                        ds.Dispose()
                        MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    ds = Nothing

                    fila = fila + 1
                Loop

                ds = Nothing
                For Each row As DataGridViewRow In Me.GrillaSel.Rows
                    classDespacho.car_codigo = row.Cells(CON_MAR_CAR_CODIGO).Value
                    classDespacho.pic_codigo = row.Cells(CON_MAR_PIC_CODIGO).Value
                    classDespacho.pic_fila = row.Cells(CON_MAR_PIC_FILA).Value
                    ds = classDespacho.DESPACHO_EMBARQUE_TEMP_ELIMINA(_msgError, conexion)

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

                            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                            Exit Sub
                        End If
                    End If

                Next

                'guarda guia de pallet
                ds = Nothing
                For Each row As DataGridViewRow In Me.grilla_pallets.Rows
                    If row.Cells(2).Value() > 0 Then
                        classEmbaruque.cnn = _cnn
                        classEmbaruque.emb_sello = _sel_codigo
                        classEmbaruque.emb_codigointerno = row.Cells(0).Value()
                        classEmbaruque.emb_cantidad = row.Cells(2).Value()
                        classEmbaruque.emb_nguia = Val(txtNumeroGuia.Text)
                        ds = classEmbaruque.GUARDA_DESPACHO_PALLET_EMBARQUES(_msgError, conexion)
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

                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Sub
                            End If
                        End If
                    End If
                Next

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                respuesta = MessageBox.Show("Los datos fueron guardados en forma correcta" _
                                            + Chr(10) + "¿Desea imprimir el embarque?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                embarqueIngresado = True
                If respuesta = vbYes Then
                    Dim frm As frm_imprimir = New frm_imprimir
                    frm.Origen = "EM"
                    frm.emb_sello = txtSello.Text
                    frm.ShowDialog()

                    embarqueIngresado = False
                    Call INICIALIZA()
                    txtSello.Focus()
                Else
                    Me.Close()

                End If

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function VALIDA_DATOS() As Boolean
        Dim fila As Integer = 0
        Dim sumaPallets As Integer = 0

        VALIDA_DATOS = False
        Try
            If txtSello.Text = "" Then
                MessageBox.Show("Debe ingresar el numero que corresponde al sello", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtSello.Focus()
                Exit Function
            End If

            If OptPropio.Checked = True Then
                If cmbUsuario.Text = "" Then
                    MessageBox.Show("Debe seleccionar el nombre de un chofer", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    cmbUsuario.Focus()
                    Exit Function
                End If

                If cmbTransporte.Text = "" Then
                    MessageBox.Show("Debe seleccionar el transporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    cmbTransporte.Focus()
                    Exit Function
                End If

                If requiereComplemento = True Then
                    If cmbComplemento.Text = "" Then
                        MessageBox.Show("Debe seleccionar el complemento del transporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        cmbComplemento.Focus()
                        Exit Function
                    End If
                End If
            Else
                If txtChofer.Text = "" Then
                    MessageBox.Show("Debe ingresar el nombre del chofer", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtChofer.Focus()
                    Exit Function
                End If

                If txtTransporte.Text = "" Then
                    MessageBox.Show("Debe ingresar el transporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtTransporte.Focus()
                    Exit Function
                End If

                If cmb_transporte_externo.Text = "" Then
                    MessageBox.Show("Debe ingresar empresa externa", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    cmb_transporte_externo.Focus()
                    Exit Function
                End If

            End If

            If Trim(txtHora.Text) = ":" Then
                MessageBox.Show("Debe ingresar la hora de la cita de entrega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtHora.Focus()
                Exit Function
            End If

            If txtCapacidaPal.Text = "" Then
                txtCapacidaPal.Text = "0"
            End If

            If txtNumeroGuia.Text = "" Or txtNumeroGuia.Text = "0" Then
                MessageBox.Show("Debe ingresar el número de guia de despacho de pallets, asociada al embarque que esta ingresando ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNumeroGuia.Focus()
                Exit Function
            End If

            If txtCapacPalletDoble.Text = "" Then
                txtCapacPalletDoble.Text = "0"
            End If

            Do While fila <= grilla_pallets.RowCount - 1
                'If grilla_pallets.Rows(fila).Cells(2).Value = "" Then
                '    grilla_pallets.Rows(fila).Cells(2).Value = "0"
                'End If
                sumaPallets = sumaPallets + CInt(grilla_pallets.Rows(fila).Cells(2).Value)
                fila = fila + 1
            Loop

            If sumaPallets = 0 Then
                MessageBox.Show("Debe ingresar la cantidad de pallets de alo menos un tipo ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                GrillaSel.Focus()
                Exit Function
            End If



            'If txtCapacidaPal.Text = "0" And txtCapacPalletDoble.Text = "0" And txtCapacPalletDobleSodimac.Text = "0" Then
            '    MessageBox.Show("Debe asignar una cantidad de pallet", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txtTransporte.Focus()
            '    Exit Function
            'End If

            VALIDA_DATOS = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub frm_ingreso_datos_despacho_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub frm_ingreso_datos_despacho_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call ELIMINA_REGISTRO_TEMPORAL()
    End Sub

    Private Sub txtSello_TextChanged(sender As Object, e As EventArgs) Handles txtSello.TextChanged

    End Sub

    Private Sub txtSello_LostFocus(sender As Object, e As EventArgs) Handles txtSello.LostFocus
        If txtSello.Text <> "" Then
            _sel_codigo = txtSello.Text
            Call CARGA_DATOS_ENCABEZADO()
        End If
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frm_ingreso_datos_despacho_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub cmbTransporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTransporte.SelectedIndexChanged

    End Sub

    Private Sub cmbTransporte_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTransporte.SelectionChangeCommitted
        Call CARGA_REQUIERE_COMPLEMENTO()
    End Sub

    Private Sub CARGA_REQUIERE_COMPLEMENTO()
        Dim classVehiculo As class_vehiculo = New class_vehiculo
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classVehiculo.cnn = _cnn
            classVehiculo.veh_codigo = cmbTransporte.SelectedValue
            classVehiculo.todos = 0

            cmbComplemento.Enabled = False
            cmbComplemento.DataSource = Nothing
            cmbComplemento.Items.Clear()
            _msg = ""
            Grilla.Rows.Clear()
            ds = classVehiculo.VEHICULO_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("veh_codigo") > 0 Then
                        requiereComplemento = ds.Tables(0).Rows(Fila)("veh_requierecomplemento")
                        If requiereComplemento = True Then
                            cmbComplemento.Enabled = True
                            Call CARGA_COMBO_COMPLEMENTO()
                        Else
                            cmbComplemento.DataSource = Nothing
                            cmbComplemento.Items.Clear()
                            cmbComplemento.Enabled = False
                        End If
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REQUIERE_COMPLEMENTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REQUIERE_COMPLEMENTO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_COMPLEMENTO()
        Dim _msg As String
        Try
            Dim classVehiculo As class_vehiculo = New class_vehiculo
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classVehiculo.cnn = _cnn
            _msg = ""
            ds = classVehiculo.CARGA_COMBO_VEHICULO(_msg)
            If _msg = "" Then
                Me.cmbComplemento.DataSource = ds.Tables(0)
                Me.cmbComplemento.DisplayMember = "MENSAJE"
                Me.cmbComplemento.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_COMPLEMENTO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub GrillaSel_DragEnter(sender As Object, e As DragEventArgs) Handles GrillaSel.DragEnter

    End Sub

    Private Sub ButtonSMarcar_Click(sender As Object, e As EventArgs) Handles ButtonSMarcar.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(3).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(3).Value = False
        Next
    End Sub

    Private Sub ButtonSDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonSDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub txtNumeroGuia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroGuia.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub grilla_pallets_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla_pallets.CellContentClick

    End Sub

    Private Sub grilla_pallets_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grilla_pallets.EditingControlShowing
        Try
            RemoveHandler e.Control.KeyPress, AddressOf typeOnlynumbers
            AddHandler e.Control.KeyPress, AddressOf typeOnlynumbers

        Catch ex As Exception
            MessageBox.Show("solamente numeros")
        End Try
    End Sub

    Sub typeOnlynumbers(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) >= 33 And Asc(e.KeyChar) <= 47 Or
            Asc(e.KeyChar) >= 58 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroGuia_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroGuia.TextChanged

    End Sub
End Class