Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_impresion_etiquetas
    Private _cnn As String
    Dim IdImpresion As Integer = 0

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_impresion_etiquetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call CARGA_COMBO_CLIENTE()
        Call CARGA_COMBO_TIPO_ETIQUETA()
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

    Private Sub CARGA_COMBO_TIPO_ETIQUETA()
        Dim _msg As String
        Try
            Dim classTipoEtiqueta As class_etiqueta = New class_etiqueta
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classTipoEtiqueta.cnn = _cnn
            _msg = ""
            ds = classTipoEtiqueta.TIPO_ETIQUETA_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbTipoEtiqueta.DataSource = ds.Tables(0)
                Me.cmbTipoEtiqueta.DisplayMember = "MENSAJE"
                Me.cmbTipoEtiqueta.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_ETIQUETA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_ETIQUETAS()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            classCliente.car_codigo = cmbCliente.SelectedValue
            classCliente.tet_codigo = cmbTipoEtiqueta.SelectedValue
            _msg = ""
            ds = classCliente.CARTERA_ETIQUETA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbEtiqueta.DataSource = ds.Tables(0)
                Me.cmbEtiqueta.DisplayMember = "MENSAJE"
                Me.cmbEtiqueta.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ETIQUETAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

    End Sub

    Private Sub cmbCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCliente.SelectionChangeCommitted
        Try
            Call CARGA_COMBO_TIPO_ETIQUETA()
            Call CARGA_COMBO_ETIQUETAS()
            Grilla.DataSource = Nothing
            Grilla.Rows.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Grilla.Columns(3).Visible = False
        Me.Grilla.Columns(8).Visible = False
        If cmbCliente.SelectedValue = 5 Then
            If cmbEtiqueta.SelectedValue = 8 Then
                Call MUESTRA_COLUMNAS()
                Call CARGA_GRILLA_CON_OC()
            Else
                Call CARGA_GRILLA()
            End If
        Else
            If optBusquedaPicking.Checked = True Then
                Call CARGA_GRILLA()
            Else
                Call CARGA_GRILLA_PRODUCTOS()
            End If

        End If
    End Sub

    Private Sub CARGA_GRILLA_PRODUCTOS()
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msg As String
        Dim Fila As Integer = 0
        Try

            If txtNumPicking.Text = "" Or txtNumPicking.Text = "0" Then
                MessageBox.Show("Debe ingresar el número de un picking", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNumPicking.Focus()
                Exit Sub
            End If

            ds = Nothing
            classPicking.cnn = _cnn
            classPicking.car_codigo = cmbCliente.SelectedValue
            classPicking.pic_codigo = CInt(txtNumPicking.Text)
            classPicking.tet_codigo = cmbTipoEtiqueta.SelectedValue

            lblTotal.Text = "Total de registro: 0"
            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.PICKING_PRODUCTO_ETIQUETA_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("sku_cliente") <> "" Then

                        lblTotal.Text = "Total de registro: " + ds.Tables(0).Rows.Count.ToString
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaProductos.Rows.Add(False,
                                            ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("sku_cliente"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("bultos"),
                                            ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("con_codigounico"))

                            Fila = Fila + 1
                        Loop

                    End If
                End If
                Me.Text = "LISTADO DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msg As String
        Dim Fila As Integer = 0
        Try
            ds = Nothing
            classPicking.cnn = _cnn
            classPicking.car_codigo = cmbCliente.SelectedValue
            classPicking.tet_codigo = cmbTipoEtiqueta.SelectedValue

            lblTotal.Text = "Total de registro: 0"
            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.PICKING_ETIQUETA_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pic_codigostring") <> "" Then

                        lblTotal.Text = "Total de registro: " + ds.Tables(0).Rows.Count.ToString
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False,
                                            ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            0,
                                            ds.Tables(0).Rows(Fila)("pic_fechaingreso"),
                                            ds.Tables(0).Rows(Fila)("pic_fechaoc"),
                                            ds.Tables(0).Rows(Fila)("pic_horacita"),
                                            ds.Tables(0).Rows(Fila)("con_despachara"),
                                            0)

                            Fila = Fila + 1
                        Loop

                    End If
                End If
                Me.Text = "LISTADO DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click

        If cmbCliente.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Sub
        End If

        If cmbEtiqueta.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar una etiqueta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbEtiqueta.Focus()
            Exit Sub
        End If


        If cmbCliente.SelectedValue = 5 Then
            If cmbEtiqueta.Text = "EASY INTERNET" Then
                If EXISTEN_MARCADOS() = False Then
                    MessageBox.Show("Debe marcar a lo menos un picking ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If EXISTEN_ORDEN_PEDIDOS_INGRESADOS() = False Then
                    MessageBox.Show("Existen registros marcados que no se les a asignado un número de orden de pedido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Call LLENA_TABLA_OC_ORDEN_PEDIDO()
                Call IMPRIME_GUARDANDO_OC_ORDEN_PEDIDO()
                Call LIMPIA_TABLA_AUX_ORDEN_PEDIDO()
            Else
                Call IMPRIME_ETIQUETAS()
            End If
        Else
            Call IMPRIME_ETIQUETAS()
        End If

    End Sub

    Private Sub IMPRIME_ETIQUETAS()
        Dim classCartera As class_cartera = New class_cartera
        Dim frm As frm_imprimir = New frm_imprimir
        Dim ds As DataSet = New DataSet
        Dim _msg As String = ""
        Dim Fila As Integer = 0
        Dim nombreInforme As String = ""
        Dim Seleccionados As String = ""
        Dim numPK As Integer = 0
        Dim numBulto As Integer = 0
        Dim origen As String = ""

        Try
            origen = "FAL_ETI"

            If optBusquedaPicking.Checked = True Then
                If EXISTEN_MARCADOS() = False Then
                    MessageBox.Show("Debe marcar a lo menos un picking ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else
                If EXISTEN_PRODUCTOS_MARCADOS() = False Then
                    MessageBox.Show("Debe marcar a lo menos un producto ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If


            If optBusquedaPicking.Checked = True Then
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(0).Value = True Then
                        Seleccionados = Seleccionados + CStr(row.Cells(1).Value).ToString + ","
                    End If
                Next
                numPK = 0
            ElseIf optBusquedaProductos.Checked = True Then
                For Each row As DataGridViewRow In Me.GrillaProductos.Rows
                    If row.Cells(0).Value = True Then
                        Seleccionados = Seleccionados + CStr(row.Cells(1).Value).ToString + ","
                    End If
                Next

                If txtNumPicking.Text = "" Then
                    numPK = 0
                Else
                    numPK = CInt(txtNumPicking.Text)
                End If
            End If

            'Reportes de bultos para cliente ABCDIN
            If cmbCliente.SelectedValue = 24 Then
                If cmbEtiqueta.SelectedValue = 33 Then 'ETIQUETA PARA BULOS
                    If cmbBultos.Text = "" Then
                        MessageBox.Show("Debe seleccionar el número de bulto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Else
                        nombreInforme = ""
                        If cmbBultos.SelectedValue = 1 Then
                            nombreInforme = "etiquete_abcdin_bulto_1.rpt"
                        Else
                            nombreInforme = "etiquete_abcdin_bulto_2.rpt"
                        End If
                        numBulto = cmbBultos.SelectedValue
                        origen = "ETI_BUL_NUM"
                    End If
                End If
            Else
                ds = Nothing
                classCartera.cnn = _cnn
                classCartera.car_codigo = cmbCliente.SelectedValue
                classCartera.eti_codigo = cmbEtiqueta.SelectedValue
                ds = classCartera.CARTERA_ETIQUETA_LISTADO(_msg)
                If _msg = "" Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(Fila)("eti_informe") <> "" Then
                            nombreInforme = ds.Tables(0).Rows(Fila)("eti_informe")
                        End If
                    End If
                End If
            End If

            frm.nombreReporte = nombreInforme
            frm.Origen = origen '"FAL_ETI"
            frm.strCadena = Seleccionados
            frm.pic_codigo = numPK
            frm.numBulto = numBulto
            frm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LLENA_TABLA_OC_ORDEN_PEDIDO()
        Dim class_picking As class_picking = New class_picking
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

                ds = class_picking.OBTIENE_ID_IMPRESION_ETIQUETA_ORDEN_PEDIDO(_msg, conexion)
                If _msg = "" Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        IdImpresion = ds.Tables(0).Rows(fila)("codigo")
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    ds = Nothing
                    MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ds = Nothing
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(0).Value = True Then
                        class_picking.car_codigo = cmbCliente.SelectedValue
                        class_picking.pic_codigo = row.Cells(1).Value
                        class_picking.pic_ocnumero = row.Cells(3).Value
                        class_picking.cop_ocpnumero = row.Cells(8).Value
                        class_picking.cop_idimpresion = IdImpresion
                        ds = class_picking.INGRESA_OC_ORDEN_PEDIDO(_msg, conexion)
                        If _msg <> "" Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            ds = Nothing
                            MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LIMPIA_TABLA_AUX_ORDEN_PEDIDO()
        Dim class_picking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Try
            ds = Nothing
            class_picking.cnn = _cnn
            class_picking.cop_idimpresion = IdImpresion
            ds = class_picking.ELIMINA_ID_IMPRESION_ETIQUETA_ORDEN_PEDIDO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Private Sub IMPRIME_GUARDANDO_OC_ORDEN_PEDIDO()
        Dim Seleccionados As String = ""
        Dim classCartera As class_cartera = New class_cartera
        Dim frm As frm_imprimir = New frm_imprimir
        Dim ds As DataSet = New DataSet
        Dim _msg As String = ""
        Dim nombreInforme As String = ""

        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(0).Value = True Then
                Seleccionados = Seleccionados + CStr(row.Cells(1).Value).ToString + ","
            End If
        Next

        ds = Nothing
        classCartera.cnn = _cnn
        classCartera.car_codigo = cmbCliente.SelectedValue
        classCartera.eti_codigo = cmbEtiqueta.SelectedValue
        ds = classCartera.CARTERA_ETIQUETA_LISTADO(_msg)
        If _msg = "" Then
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0)("eti_informe") <> "" Then
                    nombreInforme = ds.Tables(0).Rows(0)("eti_informe")
                End If
            End If
        End If

        frm.nombreReporte = nombreInforme
        frm.idImpresion = IdImpresion
        frm.Origen = "EASY_INTERNET"
        frm.strCadena = Seleccionados
        frm.ShowDialog()


    End Sub

    Private Function EXISTEN_ORDEN_PEDIDOS_INGRESADOS() As Boolean
        Dim contadorMarcados As Integer = 0
        Dim contadorOrdenPedidos As Integer = 0
        Try
            EXISTEN_ORDEN_PEDIDOS_INGRESADOS = False
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    If CLng(row.Cells(8).Value) > 0 Then
                        contadorOrdenPedidos = contadorOrdenPedidos + 1
                    End If
                    contadorMarcados = contadorMarcados + 1
                End If
            Next

            If contadorMarcados > contadorOrdenPedidos Then
                EXISTEN_ORDEN_PEDIDOS_INGRESADOS = False
            Else
                EXISTEN_ORDEN_PEDIDOS_INGRESADOS = True
            End If

        Catch ex As Exception
            EXISTEN_ORDEN_PEDIDOS_INGRESADOS = False
        End Try
    End Function

    Private Function EXISTEN_MARCADOS() As Boolean
        Dim contador As Integer = 0
        Try
            EXISTEN_MARCADOS = False
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    EXISTEN_MARCADOS = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            EXISTEN_MARCADOS = False
        End Try
    End Function

    Private Function EXISTEN_PRODUCTOS_MARCADOS() As Boolean
        Dim contador As Integer = 0
        Try
            EXISTEN_PRODUCTOS_MARCADOS = False
            For Each row As DataGridViewRow In Me.GrillaProductos.Rows
                If row.Cells(0).Value = True Then
                    EXISTEN_PRODUCTOS_MARCADOS = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            EXISTEN_PRODUCTOS_MARCADOS = False
        End Try
    End Function

    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub ButtonSelecciona_Click(sender As Object, e As EventArgs) Handles ButtonSelecciona.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Dim classTipoEtiqueta As class_etiqueta = New class_etiqueta
        Dim varSel As String = ""
        Dim numPK As Integer = 0
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If

        If (cmbCliente.SelectedValue = 24 And cmbEtiqueta.SelectedValue = 33) Then
            If optBusquedaPicking.Checked = True Then
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(0).Value = True Then
                        varSel = varSel + CStr(row.Cells(1).Value).ToString + ","
                    End If
                Next
                numPK = 0
            ElseIf optBusquedaProductos.Checked = True Then
                For Each row As DataGridViewRow In Me.GrillaProductos.Rows
                    If row.Cells(0).Value = True Then
                        varSel = varSel + CStr(row.Cells(1).Value).ToString + ","
                    End If
                Next

                If txtNumPicking.Text = "" Then
                    numPK = 0
                Else
                    numPK = CInt(txtNumPicking.Text)
                End If
            End If

            If varSel <> "" Then
                Call CARGA_COMBO_BULTOS(varSel, numPK)
            End If
        Else
            cmbBultos.Items.Clear()
        End If



        If e.ColumnIndex = 9 Then
            Dim frm As frm_mant_picking = New frm_mant_picking
            frm.cnn = _cnn
            frm.pic_codigo = Grilla.Rows(e.RowIndex).Cells(1).Value
            frm.HabilitarBtn = False
            frm.ShowDialog()
        End If
    End Sub

    Private Sub CARGA_COMBO_BULTOS(ByVal VarSel As String, ByVal PK As Integer)
        Dim _msg As String
        Try
            Dim classEtiqueta As class_etiqueta = New class_etiqueta
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classEtiqueta.cnn = _cnn
            classEtiqueta.strCadena = VarSel
            classEtiqueta.pic_codigo = PK

            _msg = ""
            ds = classEtiqueta.BULTO_ETIQUETA_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbBultos.DataSource = ds.Tables(0)
                Me.cmbBultos.DisplayMember = "str_bulto"
                Me.cmbBultos.ValueMember = "num_bulto"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_BULTOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub cmbEtiqueta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEtiqueta.SelectedIndexChanged

    End Sub

    Private Sub cmbEtiqueta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbEtiqueta.SelectionChangeCommitted
        If cmbEtiqueta.SelectedValue = 33 Then
            grpBulto.Visible = True
        Else
            grpBulto.Visible = False
        End If


        'Me.Grilla.Columns(3).Visible = False
        'Me.Grilla.Columns(8).Visible = False
        'If cmbCliente.SelectedValue = 5 Then
        '    If cmbEtiqueta.SelectedValue = 8 Then
        '        Call MUESTRA_COLUMNAS()
        '        Call CARGA_GRILLA_CON_OC()
        '    Else
        '        Call CARGA_GRILLA()
        '    End If
        'End If
    End Sub

    Private Sub MUESTRA_COLUMNAS()
        Me.Grilla.Columns(3).Visible = True
        Me.Grilla.Columns(8).Visible = True
    End Sub

    Private Sub CARGA_GRILLA_CON_OC()
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msg As String
        Dim Fila As Integer = 0
        Try
            ds = Nothing
            classPicking.cnn = _cnn
            classPicking.car_codigo = cmbCliente.SelectedValue

            lblTotal.Text = "Total de registro: 0"
            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.PICKING_ETIQUETA_BUSCAR_CON_OC(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pic_codigostring") <> "" Then

                        lblTotal.Text = "Total de registro: " + ds.Tables(0).Rows.Count.ToString
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False,
                                            ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            ds.Tables(0).Rows(Fila)("pic_ocompra"),
                                            ds.Tables(0).Rows(Fila)("pic_fechaingreso"),
                                            ds.Tables(0).Rows(Fila)("pic_fechaoc"),
                                            ds.Tables(0).Rows(Fila)("pic_horacita"),
                                            ds.Tables(0).Rows(Fila)("con_despachara"),
                                            0)

                            Fila = Fila + 1
                        Loop

                    End If
                End If
                Me.Text = "LISTADO DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub cmbTipoEtiqueta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTipoEtiqueta.SelectionChangeCommitted
        Call CARGA_COMBO_ETIQUETAS()
    End Sub

    Private Sub cmbTipoEtiqueta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoEtiqueta.SelectedIndexChanged

    End Sub

    Private Sub optBusquedaPicking_CheckedChanged(sender As Object, e As EventArgs) Handles optBusquedaPicking.CheckedChanged
        If optBusquedaPicking.Checked = True Then
            lblPicking.Visible = False
            txtNumPicking.Visible = False
            txtNumPicking.Text = "0"

            GrillaProductos.DataSource = Nothing
            GrillaProductos.Rows.Clear()

            Grilla.Visible = True
            GrillaProductos.Visible = False
        Else
            lblPicking.Visible = True
            txtNumPicking.Visible = True

            Grilla.DataSource = Nothing
            Grilla.Rows.Clear()

            Grilla.Visible = False
            GrillaProductos.Visible = True
        End If
    End Sub

    Private Sub optBusquedaProductos_CheckedChanged(sender As Object, e As EventArgs) Handles optBusquedaProductos.CheckedChanged
        If optBusquedaProductos.Checked = True Then
            lblPicking.Visible = True
            txtNumPicking.Visible = True

            Grilla.DataSource = Nothing
            Grilla.Rows.Clear()

            Grilla.Visible = False
            GrillaProductos.Visible = True

        Else
            lblPicking.Visible = False
            txtNumPicking.Visible = False
            txtNumPicking.Text = "0"

            GrillaProductos.DataSource = Nothing
            GrillaProductos.Rows.Clear()

            Grilla.Visible = True
            GrillaProductos.Visible = False
        End If
    End Sub

    Private Sub GrillaProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaProductos.CellContentClick
        If e.ColumnIndex = Me.GrillaProductos.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaProductos.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If


    End Sub

End Class