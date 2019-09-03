Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_devolucion_por_picking_muestra
    Private _cnn As String
    Private _dev_codigo As Integer

    Private _newDevolucion As Integer = 0
    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""

    Const COL_SELECCION As Integer = 0
    Const COL_FILA_DEV As Integer = 1
    Const COL_BOTON As Integer = 2
    Const COL_CAR_CODIGO As Integer = 3
    Const COL_O_COMPRA As Integer = 4
    Const COL_N_PICKING As Integer = 5
    Const COL_N_FACTURA As Integer = 6
    Const COL_N_GD As Integer = 7
    Const COL_COD_UNICO As Integer = 8
    Const COL_PRO_CODIGO As Integer = 9
    Const COL_CODIGO_INTERNO As Integer = 10
    Const COL_NOMBRE_FAVATEX As Integer = 11
    Const COL_SKU_CLIENTE As Integer = 12
    Const COL_SKU_NOMBRE As Integer = 13
    Const COL_DISPONIBLE As Integer = 14
    Const COL_CANTIDAD As Integer = 15
    Const COL_N_B_X_U As Integer = 16
    Const COL_T_BULTO As Integer = 17
    Const COL_COD_INT_ORI As Integer = 18
    Const COL_CANT_DEV As Integer = 19
    Const COL_N_B_DEV As Integer = 20
    Const COL_OBSEVACIONES As Integer = 21
    Const COL_FILA As Integer = 22
    Const COL_PDD_FILA As Integer = 23
    Const COL_TDV_CODIGO As Integer = 24

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property dev_codigo() As Integer
        Get
            Return _dev_codigo
        End Get
        Set(ByVal value As Integer)
            _dev_codigo = value
        End Set
    End Property
    Private Sub frm_devolucion_por_picking_muestra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.GrillaDetalle.Columns(COL_SKU_NOMBRE).Frozen = True
        Call CARGA_COMBO_CLIENTE()

        If _dev_codigo > 0 Then
            Call CARGA_DATOS_ENCABEZADO()
            ButtonBuscar.Enabled = False
            ButtonGuardar.Enabled = False
        End If
    End Sub
    Private Sub GrillaDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellContentClick
        If e.ColumnIndex = 2 Then
            Dim respuesta As Integer
            respuesta = MessageBox.Show("¿Esta seguro(a) de quitar de la selección la fila seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = vbYes Then
                Me.GrillaDetalle.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub
    Private Sub CARGA_DATOS_ENCABEZADO()
        Dim classDevolucion As class_devolucion = New class_devolucion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classDevolucion.cnn = _cnn
            classDevolucion.dev_codigo = _dev_codigo

            ds = classDevolucion.DEVOLUCIONES_CARGA_ENCAVEZADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("dev_observacion") <> "" Then
                        cmbCliente.SelectedValue = ds.Tables(0).Rows(Fila)("car_codigo")
                        txtFecha.Value = ds.Tables(0).Rows(Fila)("dev_fechadevolucion")
                        txtObservacion.Text = ds.Tables(0).Rows(Fila)("dev_observacion")

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
        Dim classDevolucion As class_devolucion = New class_devolucion
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim _msgError As String = ""
        Try
            classDevolucion.cnn = _cnn
            classDevolucion.dev_codigo = _dev_codigo

            ds = classDevolucion.DEVOLUCIONES_CARGA_DETALLE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("dev_codigo") = 0 Then
                        Exit Sub
                    End If
                    GrillaDetalle.Rows.Clear()
                    GrillaDetalle.RowCount = ds.Tables(0).Rows.Count '

                    Do While Fila < ds.Tables(0).Rows.Count
                        GrillaDetalle.Rows(Fila).Cells(COL_FILA_DEV).Value = ds.Tables(0).Rows(Fila)("dev_codigo")
                        GrillaDetalle.Rows(Fila).Cells(COL_CAR_CODIGO).Value = cmbCliente.SelectedValue
                        GrillaDetalle.Rows(Fila).Cells(COL_O_COMPRA).Value = ds.Tables(0).Rows(Fila)("dev_ocompra")
                        GrillaDetalle.Rows(Fila).Cells(COL_N_PICKING).Value = ds.Tables(0).Rows(Fila)("pic_codigo")
                        GrillaDetalle.Rows(Fila).Cells(COL_N_FACTURA).Value = ds.Tables(0).Rows(Fila)("dev_nfactura")
                        GrillaDetalle.Rows(Fila).Cells(COL_N_GD).Value = ds.Tables(0).Rows(Fila)("dev_nguia")
                        GrillaDetalle.Rows(Fila).Cells(COL_COD_UNICO).Value = ds.Tables(0).Rows(Fila)("dev_codunico")
                        GrillaDetalle.Rows(Fila).Cells(COL_PRO_CODIGO).Value = ds.Tables(0).Rows(Fila)("pro_codigo")
                        GrillaDetalle.Rows(Fila).Cells(COL_CODIGO_INTERNO).Value = ds.Tables(0).Rows(Fila)("pro_codigointerno")
                        GrillaDetalle.Rows(Fila).Cells(COL_NOMBRE_FAVATEX).Value = ds.Tables(0).Rows(Fila)("pro_nombre")
                        GrillaDetalle.Rows(Fila).Cells(COL_SKU_CLIENTE).Value = ds.Tables(0).Rows(Fila)("sku_cliente")
                        GrillaDetalle.Rows(Fila).Cells(COL_SKU_NOMBRE).Value = ds.Tables(0).Rows(Fila)("sku_nombre")
                        GrillaDetalle.Rows(Fila).Cells(COL_DISPONIBLE).Value = 0
                        GrillaDetalle.Rows(Fila).Cells(COL_CANTIDAD).Value = FormatNumber(ds.Tables(0).Rows(Fila)("dev_cantidad"), 0)
                        GrillaDetalle.Rows(Fila).Cells(COL_N_B_X_U).Value = FormatNumber(ds.Tables(0).Rows(Fila)("dev_num_bulto"), 0)
                        GrillaDetalle.Rows(Fila).Cells(COL_T_BULTO).Value = FormatNumber(ds.Tables(0).Rows(Fila)("dev_total_bulto"), 0)
                        GrillaDetalle.Rows(Fila).Cells(COL_COD_INT_ORI).Value = ds.Tables(0).Rows(Fila)("pro_codigooriginal")
                        GrillaDetalle.Rows(Fila).Cells(COL_CANT_DEV).Value = ds.Tables(0).Rows(Fila)("dev_cant_devuelta")
                        GrillaDetalle.Rows(Fila).Cells(COL_N_B_DEV).Value = ds.Tables(0).Rows(Fila)("dev_cant_bulto")

                        If ds.Tables(0).Rows(Fila)("tdv_codigo") > 0 Then
                            Call carga_tipo_devolucion_por_picking(Fila)
                            GrillaDetalle.Rows(Fila).Cells(COL_OBSEVACIONES).Value = ds.Tables(0).Rows(Fila)("tdv_codigo")
                        End If

                        GrillaDetalle.Rows(Fila).Cells(COL_FILA).Value = ds.Tables(0).Rows(Fila)("pic_fila")
                        GrillaDetalle.Rows(Fila).Cells(COL_PDD_FILA).Value = ds.Tables(0).Rows(Fila)("pdd_fila")
                        GrillaDetalle.Rows(Fila).Cells(COL_TDV_CODIGO).Value = ds.Tables(0).Rows(Fila)("tdv_codigo")

                        Fila = Fila + 1
                    Loop
                End If

            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_BOLETA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        If cmbCliente.Text = "" Then
            MessageBox.Show("Debe seleccionar a un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Sub
        End If

        Dim frm As frm_dev_buscar_producto_por_picking = New frm_dev_buscar_producto_por_picking
        frm.cnn = _cnn
        frm.car_codigo = cmbCliente.SelectedValue
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub
    Private Sub CARGA_GRILLA()
        Try
            If listaDetalleProductos.Count = 0 Then
                Exit Sub
            End If
            '(p.pic_cantidad_encontrada * p.num_bul_unidad),
            For Each p As estructura_dev_productos In listaDetalleProductos
                GrillaDetalle.Rows.Add(False,
                                       0,
                                       0,
                                       cmbCliente.SelectedValue,
                                       p.pic_ocnumeroas,
                                       p.pic_codigo,
                                       p.fac_numeroas,
                                       p.gd_numero,
                                       p.pro_codigo_unico,
                                       p.pro_codigo,
                                       p.pro_codigointerno,
                                       p.pro_nombre,
                                       p.sku_cartera,
                                       p.sku_cartera_nombre,
                                       0,
                                       p.pic_cantidad_encontrada,
                                       p.num_bul_unidad,
                                       p.total_bulto,
                                       p.pro_codigooriginal,
                                       0,
                                       0,
                                       "",
                                       p.pic_fila,
                                       p.pdd_fila,
                                       0)
            Next
            'GrillaDetalle.AutoResizeColumns()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click
        Dim respuesta As Integer

        respuesta = MessageBox.Show("¿Esta seguro(a) de guardar la devolución?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = vbNo Then
            Exit Sub
        End If

        Call GUARDAR_DEVOLUCION()
    End Sub
    Private Sub GUARDAR_DEVOLUCION()
        Dim classDevolucion As class_devolucion = New class_devolucion
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classDevolucion.dev_codigo = _newDevolucion
                classDevolucion.dev_fechadevolucion = txtFecha.Value ' GLO_FECHA_SISTEMA
                classDevolucion.car_codigo = cmbCliente.SelectedValue
                classDevolucion.dev_observacion = Replace(txtObservacion.Text, "'", "")
                classDevolucion.usu_codigo = GLO_USUARIO_ACTUAL

                ds = classDevolucion.PICKING_GUARDA_DATOS_DEVOLUCION_ENCABEZADO(_msgError, conexion)
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
                    Else
                        _newDevolucion = ds.Tables(0).Rows(0)("CODIGO")
                    End If
                End If

                ds = Nothing

                classDevolucion.dev_codigo = _newDevolucion
                ds = classDevolucion.PICKING_ELIMINA_DATOS_DEVOLUCION_DETALLE(_msgError, conexion)
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

                Do While fila <= GrillaDetalle.Rows.Count - 1
                    classDevolucion.dev_codigo = _newDevolucion
                    classDevolucion.dev_ocompra = GrillaDetalle.Rows(fila).Cells(COL_O_COMPRA).Value
                    classDevolucion.pic_codigo = GrillaDetalle.Rows(fila).Cells(COL_N_PICKING).Value
                    classDevolucion.dev_nfactura = GrillaDetalle.Rows(fila).Cells(COL_N_FACTURA).Value
                    classDevolucion.dev_nguia = GrillaDetalle.Rows(fila).Cells(COL_N_GD).Value
                    classDevolucion.dev_codunico = GrillaDetalle.Rows(fila).Cells(COL_COD_UNICO).Value
                    classDevolucion.pro_codigo = GrillaDetalle.Rows(fila).Cells(COL_PRO_CODIGO).Value
                    classDevolucion.pro_codigointerno = GrillaDetalle.Rows(fila).Cells(COL_CODIGO_INTERNO).Value
                    classDevolucion.pro_nombre = GrillaDetalle.Rows(fila).Cells(COL_NOMBRE_FAVATEX).Value
                    classDevolucion.sku_cliente = GrillaDetalle.Rows(fila).Cells(COL_SKU_CLIENTE).Value
                    classDevolucion.sku_nombre = GrillaDetalle.Rows(fila).Cells(COL_SKU_NOMBRE).Value
                    classDevolucion.dev_cantidad = GrillaDetalle.Rows(fila).Cells(COL_CANTIDAD).Value
                    classDevolucion.dev_num_bulto = GrillaDetalle.Rows(fila).Cells(COL_N_B_X_U).Value
                    classDevolucion.dev_total_bulto = GrillaDetalle.Rows(fila).Cells(COL_T_BULTO).Value
                    classDevolucion.pro_codigooriginal = GrillaDetalle.Rows(fila).Cells(COL_COD_INT_ORI).Value

                    classDevolucion.dev_cant_devuelta = GrillaDetalle.Rows(fila).Cells(COL_CANT_DEV).Value
                    classDevolucion.dev_cant_bulto = (GrillaDetalle.Rows(fila).Cells(COL_N_B_DEV).Value * GrillaDetalle.Rows(fila).Cells(COL_CANTIDAD).Value)

                    classDevolucion.dev_motivo = "-"

                    classDevolucion.pic_fila = GrillaDetalle.Rows(fila).Cells(COL_FILA).Value
                    classDevolucion.pdd_fila = GrillaDetalle.Rows(fila).Cells(COL_PDD_FILA).Value
                    classDevolucion.tdv_codigo = GrillaDetalle.Rows(fila).Cells(COL_TDV_CODIGO).Value
                    classDevolucion.emb_sello = "-"
                    _msgError = ""
                    ds = classDevolucion.PICKING_GUARDA_DATOS_DEVOLUCION_DETALLE(_msgError, conexion)
                    If _msgError = "" Then
                        If ds.Tables.Count > 0 Then
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State <> ConnectionState.Closed Then
                                    conexion.Close()
                                End If
                                conexion.Dispose()
                                ds.Dispose()
                                MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    Else
                        If conexion.State <> ConnectionState.Closed Then
                            conexion.Close()
                        End If
                        conexion.Dispose()
                        ds.Dispose()
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    'GENERA AGENDA PARA LAS ORDENES QUE ERAN AGENDABLES
                    classDevolucion.dev_codigo = _newDevolucion
                    classDevolucion.car_codigo = cmbCliente.SelectedValue

                    _msgError = ""
                    ds = classDevolucion.GENERA_AGENDA_DESDE_DEVOLUCIONES(_msgError, conexion)
                    If _msgError = "" Then
                        If ds.Tables.Count > 0 Then
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State <> ConnectionState.Closed Then
                                    conexion.Close()
                                End If
                                conexion.Dispose()
                                ds.Dispose()
                                MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    Else
                        If conexion.State <> ConnectionState.Closed Then
                            conexion.Close()
                        End If
                        conexion.Dispose()
                        ds.Dispose()
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    fila = fila + 1
                Loop

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default

                MessageBox.Show("La devolución fue ingresada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ButtonGuardar.Enabled = False
                _dev_codigo = _newDevolucion
                _newDevolucion = 0

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub chkMostrarDetalle_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarDetalle.CheckedChanged
        If chkMostrarDetalle.Checked = True Then
            Call MuestraDetalle()
        Else
            Call OcultaDetalle()
        End If
    End Sub

    Private Sub MuestraDetalle()
        Me.GrillaDetalle.Columns(COL_O_COMPRA).Visible = True
        Me.GrillaDetalle.Columns(COL_N_PICKING).Visible = True
        Me.GrillaDetalle.Columns(COL_N_FACTURA).Visible = True
        Me.GrillaDetalle.Columns(COL_N_GD).Visible = True

        Me.GrillaDetalle.Columns(COL_SKU_CLIENTE).Visible = True
        Me.GrillaDetalle.Columns(COL_SKU_NOMBRE).Visible = True

        'Me.GrillaDetalle.Columns(1).Visible = True
        'Me.GrillaDetalle.Columns(22).Visible = True
    End Sub
    Private Sub OcultaDetalle()
        Me.GrillaDetalle.Columns(COL_O_COMPRA).Visible = False
        Me.GrillaDetalle.Columns(COL_N_PICKING).Visible = False
        Me.GrillaDetalle.Columns(COL_N_FACTURA).Visible = False
        Me.GrillaDetalle.Columns(COL_N_GD).Visible = False
        Me.GrillaDetalle.Columns(COL_SKU_CLIENTE).Visible = False
        Me.GrillaDetalle.Columns(COL_SKU_NOMBRE).Visible = False
    End Sub
    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        Dim frm As frm_imprimir = New frm_imprimir
        frm.Origen = "DPP"
        frm.dev_codigo = _dev_codigo
        frm.ShowDialog()
    End Sub

    Private Sub GrillaDetalle_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GrillaDetalle.EditingControlShowing
        If (GrillaDetalle.CurrentCell.ColumnIndex = COL_CANT_DEV) Then
            Dim validar As TextBox = CType(e.Control, TextBox)

            cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
            PrecionaTeclaDesde = "GrillaDetalle"
            ' agregar el controlador de eventos para el KeyPress  
            AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
        End If
    End Sub

    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = GrillaDetalle.CurrentCell.ColumnIndex
        Dim fila As Integer = GrillaDetalle.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = COL_CANT_DEV) Then
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
        'Dim row As Integer
        'Dim control As String

        'control = ActiveControl.Name
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
                    If PrecionaTeclaDesde = "GrillaDetalle" Then

                        columna = GrillaDetalle.CurrentCell.ColumnIndex
                        fila = GrillaDetalle.CurrentCell.RowIndex

                        If (columna = 19) Then
                            If (cellTextBox IsNot Nothing) Then
                                With GrillaDetalle
                                    If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                                    ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex + 1, 0)
                                    End If
                                End With
                            End If

                            GrillaDetalle.Rows(fila).Cells(20).Value = FormatNumber(CDbl(GrillaDetalle.Rows(fila).Cells(16).Value) * CDbl(GrillaDetalle.Rows(fila).Cells(19).Value), 0)
                        End If
                        'End If
                        '=============================================================
                        'PRECIONA TECLA CON EL FOCO EN LA GRILLA DE DESGLOSE DE CUOTAS
                        '=============================================================
                        'ElseIf GrillaCuotas.Focus = True Then

                    End If

                    PrecionaTeclaDesde = ""
                Case Else

                    Return MyBase.ProcessCmdKey(msg, keyData)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GrillaDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellEnter
        Call carga_tipo_devolucion_por_picking(e.RowIndex)
    End Sub

    Private Sub carga_tipo_devolucion_por_picking(ByVal fil As Integer)
        Dim classTipoDevolucion As class_tipo_devoluciones = New class_tipo_devoluciones
        Dim ds As DataSet = New DataSet
        Dim _msg As String

        Try

            ds = Nothing
            classTipoDevolucion.cnn = _cnn

            _msg = ""
            ds = classTipoDevolucion.TIPO_DEVOLUCION_POR_PICKING_CARGA_COMBO(_msg)

            'Dim column As DataGridViewComboBoxColumn = DirectCast(gDetalleSolicitud.Columns(14), DataGridViewComboBoxColumn)
            Dim column As DataGridViewComboBoxCell = DirectCast(GrillaDetalle.Rows(fil).Cells(21), DataGridViewComboBoxCell)

            If _msg = "" Then
                With column
                    'Origen de datos
                    .DataSource = ds.Tables(0)
                    'Nombre del campo cuyos datos se mostraran en la columna
                    .DisplayMember = "mensaje"
                    'Nombre del campo cuyo valor se devolvera cuando se seleccione un elemento.
                    .ValueMember = "codigo"
                End With
                'gDetalleSolicitud.Columns.Add(column)
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GrillaDetalle_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellValueChanged
        If GrillaDetalle.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumn23" Then
            Dim combo As DataGridViewComboBoxCell = TryCast(GrillaDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
            'Yo converti el valor del combo a string por que asi lo necesitaba, tu lo convertirias a integer o el formato que tengas en tu tabla.
            If combo.Value = Nothing Then

                Call carga_tipo_devolucion_por_picking(e.RowIndex)
                GrillaDetalle.Rows(GrillaDetalle.CurrentCell.RowIndex).Cells(COL_OBSEVACIONES).Value = 0
                GrillaDetalle.Rows(e.RowIndex).Cells(COL_OBSEVACIONES).Value = "0"
            Else
                Dim valor As String = combo.Value.ToString

                Call carga_tipo_devolucion_por_picking(e.RowIndex)
                'GrillaCheques.Rows(GrillaCheques.CurrentCell.RowIndex).Cells(6).Value = valor
                GrillaDetalle.Rows(e.RowIndex).Cells(COL_TDV_CODIGO).Value = valor
            End If
        End If
    End Sub

    Private Sub GrillaDetalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles GrillaDetalle.DataError
        If e.Exception IsNot Nothing AndAlso
       e.Context = DataGridViewDataErrorContexts.Commit Then

            'MessageBox.Show("CustomerID value must be unique.")

        End If
    End Sub

End Class