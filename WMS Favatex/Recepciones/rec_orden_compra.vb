Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class rec_orden_compra
    Private _cnn As String
    'Private _numOC As Long
    'Private _car_codigo As Integer
    Private _ocp_codigo As Integer
    Private _eoc_codigo As Integer
    Private _ere_codigo As Integer
    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""
    Private _viene As String = ""
    Dim _nombreArchivo As String = ""
    Dim _extension As String = ""
    Dim pasoDesdeMulti As String = ""
    Dim Fila As Integer = 0
    Private cargaCombos As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property ere_codigo() As Integer
        Get
            Return _ere_codigo
        End Get
        Set(ByVal value As Integer)
            _ere_codigo = value
        End Set
    End Property
    Public Property ocp_codigo() As Integer
        Get
            Return _ocp_codigo
        End Get
        Set(ByVal value As Integer)
            _ocp_codigo = value
        End Set
    End Property
    Public Property viene() As String
        Get
            Return _viene
        End Get
        Set(ByVal value As String)
            _viene = value
        End Set
    End Property

    'Public Property numOC() As String
    '    Get
    '        Return _numOC
    '    End Get
    '    Set(ByVal value As String)
    '        _numOC = value
    '    End Set
    'End Property
    'Public Property car_codigo() As Integer
    '    Get
    '        Return _car_codigo
    '    End Get
    '    Set(ByVal value As Integer)
    '        _car_codigo = value
    '    End Set
    'End Property
    Public Property eoc_codigo() As Integer
        Get
            Return _eoc_codigo
        End Get
        Set(ByVal value As Integer)
            _eoc_codigo = value
        End Set
    End Property
    Private Sub rec_orden_compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaCombos = False
        Call INICIALIZA()
        cargaCombos = True
        ButtonNuevo.Enabled = False
        ButtonGurdar.Enabled = False
        If _eoc_codigo = ESTADO_ORDEN_COMPRA_PROVEEDOR.PENDIENTE Or _eoc_codigo = 0 Then
            ButtonNuevo.Enabled = True
            ButtonGurdar.Enabled = True
        End If

        If _viene = "V" Then
            ButtonGurdar.Enabled = False
            If USU_EJECUTA_RECEPCION = True Then
                BtnRecepcion.Visible = True
                sepRecepcion.Visible = True
            End If

        End If

        If _ocp_codigo > 0 Then
            cmbProveedor.Enabled = False
            txtNomOC.Enabled = False
            Call CARGA_DATOS_ENCABEZADO()
            TabPage2.Parent = TabControl1
            Call BUSCA_ADJUNTO_ORDEN_COMPRA()
        End If

    End Sub

    Private Sub OBTIENE_CORRELATIVO_IMPORTACION()
        Dim classGen As class_comunes = New class_comunes
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classGen.cnn = _cnn
            classGen.cor_codigo = CORRELATIVOS.IMPORTACIONES
            ds = classGen.OBTIENE_ULTIMO_CORRELATIVO_DOCUMETO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    txtNumeroImportacion.Text = ds.Tables(0).Rows(Fila)("cor_numeroactual")
                Else
                    txtNumeroImportacion.Text = 0
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_CORRELATIVO_IMPORTACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\OBTIENE_CORRELATIVO_IMPORTACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OBTIENE_ESTADO_ORDEN_COMPRA()
        Dim classOrden As class_rec_orden_compra = New class_rec_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0

        Try
            classOrden.cnn = _cnn
            classOrden.ocp_codigo = _ocp_codigo
            ds = classOrden.OBTIENE_ESTADO_REC_ORDEN_COMPRA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("eoc_codigo") > 0 Then
                        If (ds.Tables(0).Rows(Fila)("eoc_codigo") = ESTADO_ORDEN_COMPRA_PROVEEDOR.ARRIBADA) Or (ds.Tables(0).Rows(Fila)("eoc_codigo") = ESTADO_ORDEN_COMPRA_PROVEEDOR.CIERRE_MANUAL) Or (ds.Tables(0).Rows(Fila)("eoc_codigo") = ESTADO_ORDEN_COMPRA_PROVEEDOR.ANULADA) Then
                            ButtonEnvio.Enabled = False
                            BtnRecepcion.Enabled = False
                            _eoc_codigo = ds.Tables(0).Rows(Fila)("eoc_codigo")
                        End If
                        'Else
                        '    ButtonGurdar.Enabled = False
                        '    ButtonPaletizar.Enabled = False
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_ESTADO_ORDEN_COMPRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\OBTIENE_ESTADO_ORDEN_COMPRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CARGA_DATOS_ENCABEZADO()
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo
            classOC.car_codigo = 0
            classOC.ocp_numero = 0
            classOC.fecha_ingreso_desde = "19000101"
            classOC.fecha_hasta_desde = "20501231"
            classOC.fecha_arribo_desde = "19000101"
            classOC.fecha_arribo_hasta = "20501231"

            ds = classOC.OC_PROVEEDORES_LISTAR(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        cmbProveedor.SelectedValue = ds.Tables(0).Rows(Fila)("car_codigo")
                        txtFechaOC.Value = ds.Tables(0).Rows(Fila)("ocp_fechaorden")
                        txtNomOC.Text = ds.Tables(0).Rows(Fila)("ocp_numero")
                        txtFechaArribo.Text = ds.Tables(0).Rows(Fila)("ocp_fechallegada")
                        txtTipoCambio.Text = ds.Tables(0).Rows(Fila)("ocp_tipocambio")
                        chkTipoOrden.Checked = ds.Tables(0).Rows(Fila)("ocp_ordennacional")
                        txtTotalNeto.Text = ds.Tables(0).Rows(Fila)("ocp_totalneto")
                        txtIva.Text = ds.Tables(0).Rows(Fila)("ocp_iva")
                        txtTotal.Text = ds.Tables(0).Rows(Fila)("ocp_totalorden")
                        cmbAsignarA.SelectedValue = ds.Tables(0).Rows(Fila)("usu_recepcion")

                        cmbEmpresaTransporte.SelectedValue = ds.Tables(0).Rows(Fila)("ocp_empresatransporte")
                        txtFacturaTransporte.Text = ds.Tables(0).Rows(Fila)("ocp_nfacturatransporte")
                        txtFechaEmbarque.Value = ds.Tables(0).Rows(Fila)("ocp_fechaembarque")
                        txtNumeroTransporte.Text = ds.Tables(0).Rows(Fila)("ocp_ntransporte")
                        txtNumeroImportacion.Text = ds.Tables(0).Rows(Fila)("ocp_nimportacion")
                        txtFechaPagoTransporte.Value = ds.Tables(0).Rows(Fila)("ocp_fechapagotransporte")
                        txtFechaVectoTransporte.Value = ds.Tables(0).Rows(Fila)("ocp_fechavencimientotransporte")
                        txtValorFlete.Text = ds.Tables(0).Rows(Fila)("ocp_valorflete")
                        txtProforma.Text = ds.Tables(0).Rows(Fila)("ocp_nproforma")
                        cmbDiasPago.SelectedValue = ds.Tables(0).Rows(Fila)("ocp_diaspago")
                        cmbPagoFacturas.SelectedValue = ds.Tables(0).Rows(Fila)("ocp_pagofactura")
                        cmbCondicionPago.SelectedValue = ds.Tables(0).Rows(Fila)("ocp_condicionpago")
                        txtFechaPago.Value = ds.Tables(0).Rows(Fila)("ocp_fechapago")
                        cmbEmpresaDescarga.SelectedValue = ds.Tables(0).Rows(Fila)("ocp_empresadescarga")
                        txtFacturaDescarga.Text = ds.Tables(0).Rows(Fila)("ocp_nfacturadescarga")
                        txtFechaDescarga.Value = ds.Tables(0).Rows(Fila)("ocp_fechadescarga")
                        cmbBanco.SelectedValue = ds.Tables(0).Rows(Fila)("ocp_banco")
                        txtFechaAperturaCC.Value = ds.Tables(0).Rows(Fila)("ocp_fechaaperturacc")
                        cmbDiasPagoCredito.SelectedValue = ds.Tables(0).Rows(Fila)("ocp_diaspagobanco")
                        txtFechaVencimientoCredito.Text = ds.Tables(0).Rows(Fila)("ocp_fechavencimientobanco")
                        cmbAgencia.SelectedValue = ds.Tables(0).Rows(Fila)("ocp_agenciaaduana")
                        txtDNI.Text = ds.Tables(0).Rows(Fila)("ocp_numerodni")
                        txtFacturaImportacion.Text = ds.Tables(0).Rows(Fila)("ocp_nfacturaimportacion")
                        txtCertificadoSeguro.Text = ds.Tables(0).Rows(Fila)("ocp_certificadoseguro")



                        Call CARGA_GRILLA_DETALLE()

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
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo

            ds = classOC.OC_DETALLE_PROVEEDORES_LISTAR(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Grilla.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_codigointerno") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("opd_cantidad"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("opd_preciounitario"), 2),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("opd_totalfila"), 2),
                                            ds.Tables(0).Rows(Fila)("opd_fila"))
                            Fila = Fila + 1
                        Loop
                        Grilla.Rows.Add(0, "", "", "", "", "", "")
                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub INICIALIZA()

        TabPage2.Parent = Nothing
        Call OBTIENE_CORRELATIVO_IMPORTACION()
        'txtFechaEmbarque.Value = GLO_FECHA_SISTEMA
        txtFechaPagoTransporte.Value = GLO_FECHA_SISTEMA
        txtFechaVectoTransporte.Value = GLO_FECHA_SISTEMA
        txtFechaPago.Value = GLO_FECHA_SISTEMA
        txtFechaDescarga.Value = GLO_FECHA_SISTEMA
        txtFechaAperturaCC.Value = GLO_FECHA_SISTEMA
        txtFechaVencimientoCredito.Value = GLO_FECHA_SISTEMA

        Grilla.Columns(7).Visible = True
        Call CARGA_COMBO_EJECUTA_RECEPCION()
        Call CARGA_COMBO_DIAS_PAGO()
        Call CARGA_COMBO_PAGO_FACTURA()
        Call CARGA_COMBO_CONDICION_PAGO()
        Call CARGA_COMBO_EMPRESA_TRANSPORTE()
        Call CARGA_COMBO_EMPRESA_DESCARGA()
        Call CARGA_COMBO_BANCOS()
        Call CARGA_COMBO_DIAS_PAGO_BANCO()
        Call CARGA_COMBO_AGENCIA_DE_ADUANA()

        If USU_ASIGNA_PARA_RECEPCION = True Then
            lblAsignarA.Visible = True
            cmbAsignarA.Visible = True
            ButtonEnvio.Visible = True
            sepAsignacion.Visible = True
            Grilla.Columns(7).Visible = False
        End If

        cmbAsignarA.Enabled = True
        If USU_EJECUTA_RECEPCION = True Then
            lblAsignarA.Visible = True
            cmbAsignarA.Visible = True
            cmbAsignarA.Enabled = False
            ButtonEnvio.Visible = False
            sepAsignacion.Visible = False
            Grilla.Columns(7).Visible = False
        End If

        If _ocp_codigo = 0 Then
            lblAsignarA.Visible = False
            cmbAsignarA.Visible = False
            ButtonEnvio.Visible = False
            sepAsignacion.Visible = False
            ButtonPaletizar.Visible = False
            sepPaletiza.Visible = False
        End If

        Grilla.DataSource = Nothing
        Grilla.Rows.Clear()
        Grilla.Rows.Add(0, "", "", "", "", "", "")

        Call CARGA_COMBO_PROBVEEDOR()
        txtFechaOC.Value = Now
        txtNomOC.Text = "0"
        txtFechaArribo.Value = Now
        txtTipoCambio.Text = "0"

        _nombreArchivo = ""
        _extension = ""
        pasoDesdeMulti = ""

        GrillaAdjunto.DataSource = Nothing
        GrillaAdjunto.Rows.Clear()

        GrillaAdjunto.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAdjunto.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAdjunto.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'GrillaAdjunto.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'GrillaAdjunto.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'GrillaAdjunto.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

    End Sub
    Private Sub CARGA_COMBO_AGENCIA_DE_ADUANA()
        Dim _msg As String
        Try
            Dim classTablasGenericas As class_tablas_genericas = New class_tablas_genericas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classTablasGenericas.cnn = _cnn
            classTablasGenericas.tge_codigo = TABLAS_GENERICAS.AGENCIA_DE_ADUANA
            ds = classTablasGenericas.TABLAS_GENERICAS_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbAgencia.DataSource = ds.Tables(0)
                Me.cmbAgencia.DisplayMember = "MENSAJE"
                Me.cmbAgencia.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_AGENCIA_DE_ADUANA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_DIAS_PAGO_BANCO()
        Dim _msg As String
        Try
            Dim classTablasGenericas As class_tablas_genericas = New class_tablas_genericas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classTablasGenericas.cnn = _cnn
            classTablasGenericas.tge_codigo = TABLAS_GENERICAS.DIAS_PAGO_BANCO
            ds = classTablasGenericas.TABLAS_GENERICAS_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbDiasPagoCredito.DataSource = ds.Tables(0)
                Me.cmbDiasPagoCredito.DisplayMember = "MENSAJE"
                Me.cmbDiasPagoCredito.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_DIAS_PAGO_BANCO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_BANCOS()
        Dim _msg As String
        Try
            Dim classTablasGenericas As class_tablas_genericas = New class_tablas_genericas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classTablasGenericas.cnn = _cnn
            classTablasGenericas.tge_codigo = TABLAS_GENERICAS.BANCOS
            ds = classTablasGenericas.TABLAS_GENERICAS_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbBanco.DataSource = ds.Tables(0)
                Me.cmbBanco.DisplayMember = "MENSAJE"
                Me.cmbBanco.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_BANCOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_EMPRESA_DESCARGA()
        Dim _msg As String
        Try
            Dim classTablasGenericas As class_tablas_genericas = New class_tablas_genericas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classTablasGenericas.cnn = _cnn
            classTablasGenericas.tge_codigo = TABLAS_GENERICAS.EMPRESA_DE_DESCARGA
            ds = classTablasGenericas.TABLAS_GENERICAS_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbEmpresaDescarga.DataSource = ds.Tables(0)
                Me.cmbEmpresaDescarga.DisplayMember = "MENSAJE"
                Me.cmbEmpresaDescarga.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_EMPRESA_DESCARGA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_EMPRESA_TRANSPORTE()
        Dim _msg As String
        Try
            Dim classTablasGenericas As class_tablas_genericas = New class_tablas_genericas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classTablasGenericas.cnn = _cnn
            classTablasGenericas.tge_codigo = TABLAS_GENERICAS.EMPRESA_DE_TRANSPORTE
            ds = classTablasGenericas.TABLAS_GENERICAS_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbEmpresaTransporte.DataSource = ds.Tables(0)
                Me.cmbEmpresaTransporte.DisplayMember = "MENSAJE"
                Me.cmbEmpresaTransporte.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CONDICION_PAGO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_CONDICION_PAGO()
        Dim _msg As String
        Try
            Dim classTablasGenericas As class_tablas_genericas = New class_tablas_genericas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classTablasGenericas.cnn = _cnn
            classTablasGenericas.tge_codigo = TABLAS_GENERICAS.CONDICION_DE_PAGO
            ds = classTablasGenericas.TABLAS_GENERICAS_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbCondicionPago.DataSource = ds.Tables(0)
                Me.cmbCondicionPago.DisplayMember = "MENSAJE"
                Me.cmbCondicionPago.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CONDICION_PAGO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_PAGO_FACTURA()
        Dim _msg As String
        Try
            Dim classTablasGenericas As class_tablas_genericas = New class_tablas_genericas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classTablasGenericas.cnn = _cnn
            classTablasGenericas.tge_codigo = TABLAS_GENERICAS.PAGO_DE_FACTURA
            ds = classTablasGenericas.TABLAS_GENERICAS_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbPagoFacturas.DataSource = ds.Tables(0)
                Me.cmbPagoFacturas.DisplayMember = "MENSAJE"
                Me.cmbPagoFacturas.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PAGO_FACTURA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_DIAS_PAGO()
        Dim _msg As String
        Try
            Dim classTablasGenericas As class_tablas_genericas = New class_tablas_genericas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classTablasGenericas.cnn = _cnn
            classTablasGenericas.tge_codigo = TABLAS_GENERICAS.DIAS_PAGO
            ds = classTablasGenericas.TABLAS_GENERICAS_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbDiasPago.DataSource = ds.Tables(0)
                Me.cmbDiasPago.DisplayMember = "MENSAJE"
                Me.cmbDiasPago.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_DIAS_PAGO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_PROBVEEDOR()
        Dim _msg As String
        Try
            Dim classProveedor As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classProveedor.cnn = _cnn
            _msg = ""
            ds = classProveedor.CARGA_COMBO_PROVEEDOR(_msg)
            If _msg = "" Then
                Me.cmbProveedor.DataSource = ds.Tables(0)
                Me.cmbProveedor.DisplayMember = "MENSAJE"
                Me.cmbProveedor.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROBVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_EJECUTA_RECEPCION()
        Dim _msg As String
        Try
            Dim classUsuario As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classUsuario.cnn = _cnn
            ds = classUsuario.CARGA_COMBO_EJECUTA_RECEPCION(_msg)
            If _msg = "" Then
                Me.cmbAsignarA.DataSource = ds.Tables(0)
                Me.cmbAsignarA.DisplayMember = "MENSAJE"
                Me.cmbAsignarA.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROBVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = 7 Then
            Dim respuesta As Integer
            respuesta = MessageBox.Show("¿Esta seguro(a) de quitar la fila seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = vbYes Then
                Me.Grilla.Rows.RemoveAt(e.RowIndex)
                If Grilla.RowCount = 0 Then
                    Grilla.Rows.Add(0, "", "", "", "", "", "")
                End If
                Call SUMA_PRODUCTOS()
            End If

        End If
    End Sub

    Private Sub Grilla_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        PrecionaTeclaDesde = "Grilla"
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
    End Sub

    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = Grilla.CurrentCell.ColumnIndex
        Dim fila As Integer = Grilla.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = 3) Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar  
                e.KeyChar = Chr(0)
            End If
        End If

        If (columna = 4) Then
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  

            ' es el separador decimal, y que no contiene ya el separador 

            If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ",") And (txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim columna As Integer
        Dim fila As Integer

        Try
            Select Case keyData
                Case Keys.Escape

                    ' No hacemos nada porque se supone

                    ' que la tecla Escape cancela la acción.

                Case Keys.Enter 'Or Keys.Down Or Keys.Up Or Keys.Left Or Keys.Right

                    'If GrillaFinanciamiento.Focus = True Then
                    If PrecionaTeclaDesde = "Grilla" Then

                        columna = Grilla.CurrentCell.ColumnIndex
                        fila = Grilla.CurrentCell.RowIndex

                        ' 3: CANTIDAD
                        ' 4: PRECIO
                        If columna = 1 Then
                            If (cellTextBox IsNot Nothing) Then
                                With Grilla
                                    .CurrentCell = .Item(.CurrentCell.ColumnIndex + 2, fila)
                                End With
                            End If
                        End If

                        If columna = 3 Then
                            If (cellTextBox IsNot Nothing) Then
                                With Grilla
                                    .CurrentCell = .Item(.CurrentCell.ColumnIndex + 1, fila)
                                End With
                            End If
                        End If

                        If columna = 4 Then
                            If (cellTextBox IsNot Nothing) Then
                                With Grilla
                                    .CurrentCell = .Item(1, .CurrentCell.RowIndex + 1)
                                End With
                            End If
                        End If

                        'If (cellTextBox IsNot Nothing) Then
                        '    With Grilla
                        '        If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                        '            .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                        '        ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                        '            If .ColumnCount = (.CurrentCell.ColumnIndex + 1) Then
                        '                .CurrentCell = .Item(.CurrentCell.ColumnIndex, 0)
                        '            Else
                        '                .CurrentCell = .Item(.CurrentCell.ColumnIndex + 1, 0)
                        '            End If

                        '        End If
                        '    End With
                        'End If
                        If (columna = 1) Then
                            Call CARGA_DATOS_PRODUCTOS(Grilla.Rows(fila).Cells(1).Value, fila)
                        End If

                        If (columna = 3) Or (columna = 4) Then
                            If Grilla.Rows(fila).Cells(3).Value.ToString = "" Then
                                Grilla.Rows(fila).Cells(3).Value = "0"
                            End If

                            If Grilla.Rows(fila).Cells(4).Value.ToString = "" Then
                                Grilla.Rows(fila).Cells(4).Value = "0"
                            End If

                            'If chkTipoOrden.Checked = False Then
                            '    If txtTipoCambio.Text = "" Or txtTipoCambio.Text = "0" Then
                            '        MessageBox.Show("Para continuar debe ingresar el tipo de cambio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            '        txtTipoCambio.Focus()
                            '        Exit Function
                            '    End If
                            'End If

                            If chkTipoOrden.Checked = False Then
                                'Grilla.Rows(fila).Cells(3).Value = FormatNumber(Grilla.Rows(fila).Cells(3).Value, 2)
                                Grilla.Rows(fila).Cells(4).Value = FormatNumber(Grilla.Rows(fila).Cells(4).Value, 2)
                                Grilla.Rows(fila).Cells(5).Value = FormatNumber(Grilla.Rows(fila).Cells(3).Value * Grilla.Rows(fila).Cells(4).Value, 2)
                            Else
                                'Grilla.Rows(fila).Cells(3).Value = FormatNumber(Grilla.Rows(fila).Cells(3).Value, 0)
                                Grilla.Rows(fila).Cells(4).Value = FormatNumber(Grilla.Rows(fila).Cells(4).Value, 0)
                                Grilla.Rows(fila).Cells(5).Value = FormatNumber(Grilla.Rows(fila).Cells(3).Value * Grilla.Rows(fila).Cells(4).Value, 0)
                            End If


                            Call SUMA_PRODUCTOS()

                        End If
                    End If

                    PrecionaTeclaDesde = ""
                Case Else

                    Return MyBase.ProcessCmdKey(msg, keyData)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub RECALCULA()
        Dim fila As Integer = 1

        Try
            Do While fila <= Grilla.RowCount - 1
                If chkTipoOrden.Checked = False Then
                    Grilla.Rows(fila).Cells(5).Value = FormatNumber(Grilla.Rows(fila).Cells(3).Value * Grilla.Rows(fila).Cells(4).Value, 0)
                Else
                    Grilla.Rows(fila).Cells(5).Value = FormatNumber(Grilla.Rows(fila).Cells(3).Value * Grilla.Rows(fila).Cells(4).Value, 2)
                End If
                fila = fila + 1
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SUMA_PRODUCTOS()
        Dim fila As Integer = 0
        Dim suma As Double = 0
        Dim subTotal As Double = 0
        Dim subIva As Double = 0
        Dim Total As Double = 0

        Try
            Do While fila <= Grilla.RowCount - 1
                If Grilla.Rows(fila).Cells(5).Value <> "" Then
                    suma = suma + Grilla.Rows(fila).Cells(5).Value
                End If
                fila = fila + 1
            Loop

            If suma > 0 Then
                subTotal = suma

                If chkTipoOrden.Checked = True Then
                    subIva = FormatNumber(suma * GLO_VALOR_IVA, 0)
                    Total = subTotal + subIva

                    txtTotalNeto.Text = FormatNumber(subTotal, 0)
                    txtIva.Text = FormatNumber(subIva, 0)
                    txtTotal.Text = FormatNumber(Total, 0)
                Else
                    subIva = 0
                    Total = subTotal + subIva

                    txtTotalNeto.Text = FormatNumber(subTotal, 2)
                    txtIva.Text = FormatNumber(subIva, 2)
                    txtTotal.Text = FormatNumber(Total, 2)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_DATOS_PRODUCTOS(ByVal Codigo As String, ByVal FilaDato As Integer)
        Dim classProducto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim myfont As Font
        Dim fila As Integer = 0
        myfont = New Font(Grilla.Font, ForeColor = Color.Red)

        Try
            classProducto.cnn = _cnn
            classProducto.pro_codigo = 0
            classProducto.todos = 1
            classProducto.codigo_interno = Codigo
            classProducto.cat_codigo = 0
            classProducto.sub_codigo = 0

            ds = classProducto.PRODUCTOS_LISTADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then

                    If ds.Tables(0).Rows(fila)("pro_codigo") > 0 Then
                        Grilla.Rows(FilaDato).Cells(0).Value = ds.Tables(0).Rows(fila)("pro_codigo")
                        Grilla.Rows(FilaDato).Cells(1).Value = ds.Tables(0).Rows(fila)("pro_codigointerno")
                        Grilla.Rows(FilaDato).Cells(2).Value = ds.Tables(0).Rows(fila)("pro_nombre")
                        Grilla.Rows(FilaDato).Cells(3).Value = 0
                        Grilla.Rows(FilaDato).Cells(4).Value = 0
                        Grilla.Rows(FilaDato).Cells(5).Value = 0
                        Grilla.Rows(FilaDato).Cells(6).Value = 0

                        If Grilla.Rows((Grilla.RowCount - 1)).Cells(2).Value <> "" Then
                            Grilla.Rows.Add(0, "", "", "", "", "", "")
                        End If
                    Else
                        MessageBox.Show("No existe el codigo ingresado, verifique el mantenedor de productos del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
                'GrillaFechas.AutoResizeColumns()
                'Call PINTA_GRILLA()
                'Call PINTA_GRILLA_FECHAS()
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA() = False Then
            Exit Sub
        End If

        Call GUARDAR()
    End Sub

    Private Sub GUARDAR()
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classOC.ocp_codigo = _ocp_codigo
                classOC.ocp_numero = CLng(txtNomOC.Text)
                classOC.car_codigo = cmbProveedor.SelectedValue
                classOC.ocp_fechaorden = txtFechaOC.Value
                classOC.ocp_fechallegada = txtFechaArribo.Value
                classOC.ocp_tipocambio = CDbl(txtTipoCambio.Text)
                classOC.ocp_ordennacional = chkTipoOrden.Checked
                classOC.ocp_totalneto = CDbl(txtTotalNeto.Text)
                classOC.ocp_iva = CDbl(txtIva.Text)
                classOC.ocp_totalorden = CDbl(txtTotal.Text)
                classOC.ocp_porciva = GLO_VALOR_IVA

                If cmbEmpresaTransporte.Text <> "" Then
                    classOC.ocp_empresatransporte = cmbEmpresaTransporte.SelectedValue
                Else
                    classOC.ocp_empresatransporte = 0
                End If

                If txtFacturaTransporte.Text <> "" Then
                    classOC.ocp_nfacturatransporte = CInt(txtFacturaTransporte.Text)
                Else
                    classOC.ocp_nfacturatransporte = 0
                End If

                classOC.ocp_fechaembarque = txtFechaEmbarque.Value

                If txtNumeroTransporte.Text <> "" Then
                    classOC.ocp_ntransporte = CInt(txtNumeroTransporte.Text)
                Else
                    classOC.ocp_ntransporte = 0
                End If

                If txtNumeroTransporte.Text <> "" Then
                    classOC.ocp_nimportacion = CInt(txtNumeroImportacion.Text)
                Else
                    classOC.ocp_nimportacion = 0
                End If

                classOC.ocp_fechapagotransporte = txtFechaPagoTransporte.Value
                classOC.ocp_fechavencimientotransporte = txtFechaVectoTransporte.Value

                If txtValorFlete.Text <> "" Then
                    classOC.ocp_valorflete = CDbl(txtValorFlete.Text)
                Else
                    classOC.ocp_valorflete = 0
                End If

                If txtProforma.Text <> "" Then
                    classOC.ocp_nproforma = CInt(txtProforma.Text)
                Else
                    classOC.ocp_nproforma = 0
                End If

                If cmbDiasPago.Text <> "" Then
                    classOC.ocp_diaspago = cmbDiasPago.SelectedValue
                Else
                    classOC.ocp_diaspago = 0
                End If

                If cmbPagoFacturas.Text <> "" Then
                    classOC.ocp_pagofactura = cmbPagoFacturas.SelectedValue
                Else
                    classOC.ocp_pagofactura = 0
                End If

                If cmbCondicionPago.Text <> "" Then
                    classOC.ocp_condicionpago = cmbCondicionPago.SelectedValue
                Else
                    classOC.ocp_condicionpago = 0
                End If

                classOC.ocp_fechapago = txtFechaPago.Value

                If cmbEmpresaDescarga.Text <> "" Then
                    classOC.ocp_empresadescarga = cmbEmpresaDescarga.SelectedValue
                Else
                    classOC.ocp_empresadescarga = 0
                End If

                If txtFacturaDescarga.Text <> "" Then
                    classOC.ocp_nfacturadescarga = CInt(txtFacturaDescarga.Text)
                Else
                    classOC.ocp_nfacturadescarga = 0
                End If

                classOC.ocp_fechadescarga = txtFechaDescarga.Value

                If cmbBanco.Text <> "" Then
                    classOC.ocp_banco = cmbBanco.SelectedValue
                Else
                    classOC.ocp_banco = 0
                End If

                classOC.ocp_fechaaperturacc = txtFechaAperturaCC.Value

                If cmbDiasPagoCredito.Text <> "" Then
                    classOC.ocp_diaspagobanco = cmbDiasPagoCredito.SelectedValue
                Else
                    classOC.ocp_diaspagobanco = 0
                End If

                classOC.ocp_fechavencimientobanco = txtFechaVencimientoCredito.Value

                If cmbAgencia.Text <> "" Then
                    classOC.ocp_agenciaaduana = cmbAgencia.SelectedValue
                Else
                    classOC.ocp_agenciaaduana = 0
                End If

                If txtDNI.Text <> "" Then
                    classOC.ocp_numerodni = CInt(txtDNI.Text)
                Else
                    classOC.ocp_numerodni = 0
                End If

                If txtFacturaImportacion.Text <> "" Then
                    classOC.ocp_nfacturaimportacion = CInt(txtFacturaImportacion.Text)
                Else
                    classOC.ocp_nfacturaimportacion = 0
                End If

                If txtCertificadoSeguro.Text <> "" Then
                    classOC.ocp_certificadoseguro = CInt(txtCertificadoSeguro.Text)
                Else
                    classOC.ocp_certificadoseguro = 0
                End If

                ds = classOC.OC_PROVEEDORES_GUARDAR(_msgError, conexion)
                If _msgError <> "" Then
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        _ocp_codigo = ds.Tables(0).Rows(0)("codigo")
                    End If
                End If

                Do While fila < Grilla.RowCount - 1
                    classOC.ocp_codigo = _ocp_codigo
                    classOC.opd_fila = Grilla.Rows(fila).Cells(6).Value
                    classOC.pro_codigo = Grilla.Rows(fila).Cells(0).Value
                    classOC.pro_codigointerno = Grilla.Rows(fila).Cells(1).Value
                    classOC.opd_cantidad = Grilla.Rows(fila).Cells(3).Value
                    classOC.opd_preciounitario = Grilla.Rows(fila).Cells(4).Value
                    classOC.opd_totalfila = Grilla.Rows(fila).Cells(5).Value

                    ds = classOC.OC_DETALLE_PROVEEDORES_GUARDAR(_msgError, conexion)
                    If ds.Tables(0).Rows.Count > 0 Then
                        If _msgError = "" Then
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Sub
                            End If
                        Else
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                            Exit Sub
                        End If
                    End If
                    fila = fila + 1
                Loop

                ds = Nothing
                classOC.cnn = _cnn
                classOC.ocp_codigo = _ocp_codigo
                classOC.eoc_codigo = ESTADO_ORDEN_COMPRA_PROVEEDOR.PENDIENTE

                ds = classOC.REC_ORDEN_COMPRA_CAMBIA_ESTADO(_msgError, conexion)
                If _msgError <> "" Then
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                If ACTUALIZA_CORRELATIVOS_IMPORTACION(conexion) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                respuesta = MessageBox.Show("La orden de compra fue guardada en forma correcta" _
                                            + Chr(10) + "¿Desea ingresar otro documento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                TabPage2.Parent = TabControl1

                If respuesta = vbYes Then
                    _ocp_codigo = 0
                    Call INICIALIZA()
                Else
                    'Me.Dispose()
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ACTUALIZA_CORRELATIVOS_IMPORTACION(ByVal conexion As SqlConnection) As Boolean
        Dim classGen As class_comunes = New class_comunes
        Dim _msgError As String = ""
        Dim ds As DataSet

        ACTUALIZA_CORRELATIVOS_IMPORTACION = False
        Try

            classGen.cor_codigo = CORRELATIVOS.IMPORTACIONES
            classGen.cor_numeroactual = txtNumeroImportacion.Text
            ds = classGen.ACTUALIZA_CORRELATIVO_DOCUMETO(_msgError, conexion)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Exit Function
                End If
            End If

            ACTUALIZA_CORRELATIVOS_IMPORTACION = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function VALIDA() As Boolean
        VALIDA = False
        If cmbProveedor.Text = "" Then
            MessageBox.Show("Debe seleccionar cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbProveedor.Focus()
            Exit Function
        End If

        If txtNomOC.Text = "" Or txtNomOC.Text = "0" Then
            MessageBox.Show("Debe digitar el numero de la orden de compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNomOC.Focus()
            Exit Function
        End If

        If chkTipoOrden.Checked = False Then
            If txtTipoCambio.Text = "" Or txtTipoCambio.Text = "0" Then
                MessageBox.Show("Debe digitar el tipo de cambio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtTipoCambio.Focus()
                Exit Function
            End If
        End If

        If txtFechaOC.Value > txtFechaArribo.Value Then
            MessageBox.Show("La fecha de arribo debe ser mayor a la fecha de la Orden de Compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFechaArribo.Focus()
            Exit Function
        End If



        VALIDA = True
    End Function

    Private Sub chkTipoOrden_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoOrden.CheckedChanged
        If chkTipoOrden.Checked = False Then
            txtTipoCambio.Enabled = True
        Else
            txtTipoCambio.Text = 0
            txtTipoCambio.Enabled = False
        End If
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonEnvio_Click(sender As Object, e As EventArgs) Handles ButtonEnvio.Click
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0

        Try
            If cmbAsignarA.Text = "" Then
                MessageBox.Show("Debe seleccionar a una persona para asignar la orden para su recepción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbAsignarA.Focus()
                Exit Sub
            End If

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classOC.ocp_codigo = _ocp_codigo


                ds = Nothing
                'CAMBIA ESTADO ORDEN COMPRA
                classOC.cnn = _cnn
                classOC.ocp_codigo = _ocp_codigo
                classOC.eoc_codigo = ESTADO_ORDEN_COMPRA_PROVEEDOR.ASIGNADA

                ds = classOC.REC_ORDEN_COMPRA_CAMBIA_ESTADO(_msgError, conexion)
                If _msgError <> "" Then
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                ' ASIGNA ORDEN DE COMPRA PARA SU RECEPCION
                classOC.cnn = _cnn
                classOC.ocp_codigo = _ocp_codigo
                classOC.usu_recepcion = cmbAsignarA.SelectedValue

                ds = classOC.REC_ORDEN_COMPRA_ASIGNA_PARA_RECEPCION(_msgError, conexion)
                If _msgError <> "" Then
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                respuesta = MessageBox.Show("La orden de compra fue asignada en forma correcta para su recepción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                If respuesta = vbYes Then
                    _ocp_codigo = 0
                    Call INICIALIZA()
                Else
                    Me.Dispose()
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonPaletizar_Click(sender As Object, e As EventArgs) Handles ButtonPaletizar.Click
        Dim strCodigos As String = ""

        If EXISTE_VULOMETRIA(_ocp_codigo, "OC", strCodigos) = True Then
            If strCodigos <> "" Then
                MessageBox.Show("Se requiere completar los datos de volumetria para los siguientes codigos: " _
                                + Chr(10) + "" + strCodigos, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If EXISTE_BULTO_VALIDA(_ocp_codigo, "OC", strCodigos) = True Then
            If strCodigos <> "" Then
                MessageBox.Show("Falta ingresar informacion de los bultos para los siguientes codigos: " _
                                + Chr(10) + "" + strCodigos, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        'EXISTE_VULOMETRIA(_ocp_codigo, "OC", strCodigos)
        'If strCodigos = "" Then
        '    MessageBox.Show("Se requiere completar los datos de volumetria para los siguientes codigos: " _
        '                            + Chr(10) + "" + strCodigos, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If

        Dim frm As frm_paletiza_oc = New frm_paletiza_oc
        frm.cnn = _cnn
        frm.ocp_codigo = _ocp_codigo
        frm.ShowDialog()
    End Sub

    Private Function EXISTE_VULOMETRIA(ByVal recNumero As Integer, ByVal tipDocumento As String, ByRef Codigos As String) As Boolean
        Dim classProducto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_VULOMETRIA = False
        Try
            classProducto.cnn = _cnn
            classProducto.numDocumento = recNumero
            classProducto.tipDocumento = tipDocumento

            ds = classProducto.OBTIENE_VOLUMETRIA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigos") <> "" Then
                        Codigos = ds.Tables(0).Rows(Fila)("codigos")
                        EXISTE_VULOMETRIA = True
                    End If
                End If
            Else
                EXISTE_VULOMETRIA = False
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            EXISTE_VULOMETRIA = False
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function EXISTE_BULTO_VALIDA(ByVal recNumero As Integer, ByVal tipDocumento As String, ByRef Codigos As String) As Boolean
        Dim classProducto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_BULTO_VALIDA = False
        Try
            classProducto.cnn = _cnn
            classProducto.numDocumento = recNumero
            classProducto.tipDocumento = tipDocumento

            ds = classProducto.VALIDA_EXISTENCIA_BULTOS(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigos") <> "" Then
                        Codigos = ds.Tables(0).Rows(Fila)("codigos")
                        EXISTE_BULTO_VALIDA = True
                    End If
                End If
            Else
                EXISTE_BULTO_VALIDA = False
                MessageBox.Show(_msgError + "\EXISTE_BULTO_VALIDA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            EXISTE_BULTO_VALIDA = False
            MessageBox.Show(ex.Message + "\EXISTE_BULTO_VALIDA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub BtnRecepcion_Click(sender As Object, e As EventArgs) Handles BtnRecepcion.Click
        Dim frm As frm_recepcion = New frm_recepcion
        frm.cnn = _cnn
        frm.car_codigo = cmbProveedor.SelectedValue
        frm.opd_numero = CLng(txtNomOC.Text)
        frm.ere_codigo = ESTADO_RECEPCION.EN_PROCESO
        frm.ShowDialog()
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click

    End Sub

    Private Sub rec_orden_compra_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Call OBTIENE_ESTADO_ORDEN_COMPRA()
    End Sub

    Private Sub cmdSelecMulti_Click(sender As Object, e As EventArgs) Handles cmdSelecMulti.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "Todos los archivos|*.*"


        openFileDialog1.Title = "seleccione archivo"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pasoDesdeMulti = openFileDialog1.FileName
            txtMultRuta.Text = openFileDialog1.FileName
            _nombreArchivo = (System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName)) & (System.IO.Path.GetExtension(openFileDialog1.FileName))
            'txtMultiNombre.Text = _nombreArchivo
            _extension = System.IO.Path.GetExtension(openFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        'If txtMultRuta.Text = "" Then
        '    MessageBox.Show("Debe seleccionar un archivo para adjuntar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtMultRuta.Focus()
        '    Exit Sub
        'End If

        If txtNombreArchivo.Text = "" Then
            MessageBox.Show("Debe ingresar el nombre que haga referencia al archivo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombreArchivo.Focus()
            Exit Sub
        End If


        Call GUARDAR_REGISTRO_MULTIMEDIA()
        Call BUSCA_ADJUNTO_ORDEN_COMPRA()

        txtMultRuta.Text = ""
        txtNombreArchivo.Text = ""
        Fila = 0
    End Sub

    Private Sub BUSCA_ADJUNTO_ORDEN_COMPRA()
        'Dim classRecepcion As class_recepcion = New class_recepcion
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            Fila = 0

            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo
            _msg = ""
            GrillaAdjunto.Rows.Clear()
            ds = classOC.ORDEN_COMPRA_ADJUNTO_LISTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("ocp_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaAdjunto.Rows.Add(ds.Tables(0).Rows(Fila)("ocp_fila"),
                                            ds.Tables(0).Rows(Fila)("ocp_nombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_nombrearchivo"))
                            Fila = Fila + 1
                        Loop
                        'Else
                        '    MessageBox.Show("No existe la orden de compra para el proveedor seleccionado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\BUSCA_ADJUNTO_RECEPCION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "BUSCA_ADJUNTO_RECEPCION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub GUARDAR_REGISTRO_MULTIMEDIA()
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Dim _msg As String = ""

        Try
            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo

            classOC.ocp_fila = Fila
            classOC.ocp_nombre = txtNombreArchivo.Text
            classOC.ocp_nombrearchivo = _nombreArchivo
            classOC.ocp_url = pasoDesdeMulti

            ds = classOC.ADJUNTO_GUARDA_REGISTRO_OC_ADJUNTAR(_msgError)
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
                    If Fila = 0 Then
                        If txtMultRuta.Text <> "" Then
                            If My.Computer.FileSystem.FileExists(pasoDocumentosOrdenCompra + _nombreArchivo) Then
                                My.Computer.FileSystem.DeleteFile(pasoDocumentosOrdenCompra + _nombreArchivo)
                                My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoDocumentosOrdenCompra + _nombreArchivo, overwrite:=False)
                            Else
                                My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoDocumentosOrdenCompra + _nombreArchivo, overwrite:=False)
                            End If
                        End If
                    End If
                End If
            End If
            ds = Nothing
            MessageBox.Show("El archivo fue ingresado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Fila = 0
            txtMultRuta.Text = ""
            txtNombreArchivo.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function ORDEN_COMPRA_ADJUNTO_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_adjuntos_orden_compra_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Private Sub GrillaAdjunto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaAdjunto.CellContentClick
        Try
            If e.ColumnIndex = 3 Then
                Fila = GrillaAdjunto.Rows(e.RowIndex).Cells(0).Value
                txtNombreArchivo.Text = GrillaAdjunto.Rows(e.RowIndex).Cells(1).Value
            ElseIf e.ColumnIndex = 4 Then
                System.Diagnostics.Process.Start(pasoDocumentosOrdenCompra + GrillaAdjunto.Rows(e.RowIndex).Cells(2).Value)
            ElseIf e.ColumnIndex = 5 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Call ELIMINA_ORDEN_COMPRA_ADJUNTO(GrillaAdjunto.Rows(e.RowIndex).Cells(0).Value, GrillaAdjunto.Rows(e.RowIndex).Cells(2).Value)
                End If
            End If
        Catch ex As Exception
            'Message
        End Try
    End Sub

    Private Sub ELIMINA_ORDEN_COMPRA_ADJUNTO(ByVal fila As Integer, ByVal _Archivo As String)
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""
        Try
            ds = Nothing
            classOC.cnn = _cnn
            classOC.ocp_codigo = CInt(_ocp_codigo)
            classOC.ocp_fila = fila
            ds = classOC.ORDEN_COMPRA_ADJUNTO_ELIMINA(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            If My.Computer.FileSystem.FileExists(pasoDocumentosResepcion + _Archivo) Then
                My.Computer.FileSystem.DeleteFile(pasoDocumentosResepcion + _Archivo)
            End If

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call BUSCA_ADJUNTO_ORDEN_COMPRA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub txtProforma_TextChanged(sender As Object, e As EventArgs) Handles txtProforma.TextChanged

    End Sub

    Private Sub txtProforma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProforma.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFacturaTransporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFacturaTransporte.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroTransporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroTransporte.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroImportacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroImportacion.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFacturaDescarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFacturaDescarga.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDNI.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFacturaImportacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFacturaImportacion.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCertificadoSeguro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCertificadoSeguro.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtValorFlete_TextChanged(sender As Object, e As EventArgs) Handles txtValorFlete.TextChanged

    End Sub

    Private Sub txtValorFlete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorFlete.KeyPress
        If Not Char.IsPunctuation(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            If Not e.KeyChar = Chr(8) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cmbDiasPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiasPago.SelectedIndexChanged

    End Sub

    Private Sub cmbDiasPago_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbDiasPago.SelectionChangeCommitted

    End Sub

    Private Sub cmbDiasPagoCredito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiasPagoCredito.SelectedIndexChanged

    End Sub

    Private Sub cmbDiasPagoCredito_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbDiasPagoCredito.SelectionChangeCommitted

    End Sub

    Private Sub txtFechaEmbarque_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaEmbarque.ValueChanged
        Dim classComunes As class_comunes = New class_comunes
        Dim DiasPago As Integer = 0
        Try
            'Factura
            If cargaCombos = True Then
                If cmbDiasPago.SelectedValue = 0 Then
                    DiasPago = 0
                Else
                    DiasPago = CInt(Mid(cmbDiasPago.Text, 1, 3))
                End If

                txtFechaPago.Value = classComunes.SUMA_DIAS_FECHA_COMPROMISO(CDate(txtFechaEmbarque.Value), DiasPago)

                'Bancos
                If cmbDiasPagoCredito.SelectedValue = 0 Then
                    DiasPago = 0
                Else
                    DiasPago = CInt(Mid(cmbDiasPagoCredito.Text, 1, 3))
                End If

                txtFechaVencimientoCredito.Value = classComunes.SUMA_DIAS_FECHA_COMPROMISO(CDate(txtFechaEmbarque.Value), DiasPago)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbDiasPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDiasPago.SelectedValueChanged
        Dim classComunes As class_comunes = New class_comunes
        Dim DiasPago As Integer = 0
        Try
            If cargaCombos = True Then
                If cmbDiasPago.SelectedValue = 0 Then
                    DiasPago = 0
                Else
                    DiasPago = CInt(Mid(cmbDiasPago.Text, 1, 3))
                End If

                txtFechaPago.Value = classComunes.SUMA_DIAS_FECHA_COMPROMISO(CDate(txtFechaEmbarque.Value), DiasPago)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbDiasPagoCredito_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDiasPagoCredito.SelectedValueChanged
        Dim classComunes As class_comunes = New class_comunes
        Dim DiasPago As Integer = 0
        Try
            If cargaCombos = True Then
                If cmbDiasPagoCredito.SelectedValue = 0 Then
                    DiasPago = 0
                Else
                    DiasPago = CInt(Mid(cmbDiasPagoCredito.Text, 1, 3))
                End If

                txtFechaVencimientoCredito.Value = classComunes.SUMA_DIAS_FECHA_COMPROMISO(CDate(txtFechaEmbarque.Value), DiasPago)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Not (IO.Directory.Exists(carpetaProveedores))) Then
            MessageBox.Show("No existe la carpeta compartida.")
        Else
            MessageBox.Show("Si existe la carpeta compartida.")
        End If
    End Sub
End Class