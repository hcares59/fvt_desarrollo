Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_despacha_ordenes
    Private _cnn As String
    Private _pic_codigo As Integer
    Private _car_codigo As Integer
    Private _despachaPor As String = ""

    Private _colum As Integer
    Private _fila As Integer

    Const colD_SELECCION As Integer = 0
    Const colD_CAR_CODIGO As Integer = 1
    Const colD_OC_ORIGEN As Integer = 2
    Const colD_FIL As Integer = 3
    Const colD_NUM_FACTURA As Integer = 4
    Const colD_NUM_GDEPACHO As Integer = 5
    Const colD_COD_UNICO As Integer = 6
    Const colD_CODIGO_INTERNO As Integer = 7
    Const colD_NOMBRE_FAVATEX As Integer = 8
    Const colD_SKU_CLIENTE As Integer = 9
    Const colD_SKU_NOMBRE As Integer = 10
    Const colD_DISPONIBLE As Integer = 11
    Const colD_CANTIDAD As Integer = 12
    Const colD_NBXU As Integer = 13 'NUMERO DE BULTOS POR UNIDAD
    Const colD_TBULTOS As Integer = 14
    Const colD_CODIGO_INTERNO_ORIGINAL As Integer = 15
    Const colD_EXISTENTES As Integer = 16
    Const colD_OBSERVACIONES As Integer = 17
    Const colD_NEW_CODIGO As Integer = 18
    Const colD_COD_INT_ORI As Integer = 19
    Const colD_NOMBRE_ORI As Integer = 20
    Const colD_NBO As Integer = 21 'CANTIDAD DE BULTOS ORIGINALES
    Const colD_PIC_CODIGO As Integer = 22
    Const colD_NUEVA As Integer = 23
    Const colD_PRECIO_UNITARIO As Integer = 24
    Const colD_FECHA_OC As Integer = 25
    Const colD_TOTAL_FILA As Integer = 26
    Const colD_ESTA_DESPACHADA As Integer = 27
    Const colD_EXISTENTESREAL As Integer = 28

    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property pic_codigo() As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
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

    Private Sub frm_despacha_ordenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.GrillaDetalle.Columns(colD_CANTIDAD).Frozen = True

        Dim valor As Integer = _pic_codigo
        Dim dato As String = String.Format("{0:000000}", valor)

        lbltitulo.Text = lbltitulo.Text + " " + dato
        Call CARGA_COMBO_CLIENTE()
        cmbCliente.SelectedValue = _car_codigo
        Call CARGA_GRILLA_DETALLE()
        Call DESPACHA_CON_GUIA()
        If _despachaPor = "GD" Then
            txtNumero.Enabled = True
            txtFecha.Enabled = True
        End If
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

    Private Sub DESPACHA_CON_GUIA()
        Dim classGDespacho As class_despacha_picking = New class_despacha_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classGDespacho.cnn = _cnn
            classGDespacho.car_codigo = cmbCliente.SelectedValue

            _msg = ""

            ds = classGDespacho.SELECCIONA_DOCUMENTO_DESPACHO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("dde_descripcion") <> "" Then
                        _despachaPor = ds.Tables(0).Rows(Fila)("dde_descripcion")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\DESPACHA_CON_GUIA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "DESPACHA_CON_GUIA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLE()
        Dim classGDespacho As class_despacha_picking = New class_despacha_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classGDespacho.cnn = _cnn
            classGDespacho.pic_codigo = _pic_codigo
            'classFactura.pic_ocnumero = num_oc
            _msg = ""
            GrillaDetalle.Rows.Clear()
            ds = classGDespacho.LISTA_DETALLE_OC_PARA_DESPACHAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("sku_cartera_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(False, 0,
                                            ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("pic_fila"),
                                            ds.Tables(0).Rows(Fila)("fac_numero"),
                                            ds.Tables(0).Rows(Fila)("gde_numero"),
                                            ds.Tables(0).Rows(Fila)("con_codigounico"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("disponible"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("cantidad"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("nuumero_bultos"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("total_bulto"), 0),
                                            ds.Tables(0).Rows(Fila)("pro_codigooriginal"),
                                            ds.Tables(0).Rows(Fila)("existentes"),
                                            ds.Tables(0).Rows(Fila)("observacion"),
                                            ds.Tables(0).Rows(Fila)("pro_codigoactual"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointernooriginal"),
                                            ds.Tables(0).Rows(Fila)("pro_nombreoriginal"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_numerobultosoriginal"), 0),
                                            ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("nueva_fila"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("precio"), 0),
                                            ds.Tables(0).Rows(Fila)("pic_fechaoc"),
                                            FormatNumber((ds.Tables(0).Rows(Fila)("precio") * ds.Tables(0).Rows(Fila)("existentes")), 0),
                                            ds.Tables(0).Rows(Fila)("es_despacho"),
                                            ds.Tables(0).Rows(Fila)("existentes_real"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
                Call PINTA_FILA_GRILLA()
                'GrillaDetalle.Columns(colD_EXISTENTES).DefaultCellStyle.BackColor = Color.Khaki
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub PINTA_FILA_GRILLA()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows

            If CLng(row.Cells(colD_ESTA_DESPACHADA).Value) = True Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
                row.DefaultCellStyle.ForeColor = Color.Orange
            End If
        Next
    End Sub

    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click
        Dim Respusta As Integer = 0
        If DETALLES_MARCADAS() = False Then
            MessageBox.Show("Debe checkar los detalles que desea despachar del picking seleccionado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If DETALLES_MARCADAS_EN_CERO() = True Then
            MessageBox.Show("Existen cantidades en 0 dentro de los items seleccionados que esta tratando de facturar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If VERIFICA_ITEMS_DESPACHADO() = True Then
            Respusta = MessageBox.Show("Existen detalles despachados en la selección, estos se desmarcaran para poder seguir con la operación " _
                            + Chr(10) + "¿Esta seguro(a) que desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Respusta = vbYes Then
                Call DESMARCAR_FILA()
            Else
                Exit Sub
            End If
        End If

        If _despachaPor = "GD" Then
            If txtNumero.Text = "" Then
                MessageBox.Show("Debe ingresar el número de la guía de despacho", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Call GUARDA_GDESPACHO()
    End Sub

    Private Function DETALLES_MARCADAS_EN_CERO() As Boolean
        Dim Contador As Integer = 0
        Try
            DETALLES_MARCADAS_EN_CERO = False

            For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
                If row.Cells(colD_SELECCION).Value = True And row.Cells(colD_EXISTENTES).Value = 0 Then
                    Contador = Contador + 1
                End If
            Next

            If Contador > 0 Then
                DETALLES_MARCADAS_EN_CERO = True
            End If

        Catch ex As Exception
            DETALLES_MARCADAS_EN_CERO = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GUARDA_GDESPACHO()
        Dim classGDescpacho As class_despacha_picking = New class_despacha_picking
        Dim classPicking As class_picking = New class_picking

        Dim classLog As LogEventos = New LogEventos
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Dim DetalleCompletoDespachado As Boolean = False

        Dim OrdeneDespachada As String = "[ "

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                'nuevo
                '----------------------
                classGDescpacho.pic_codigo = _pic_codigo
                For Each row2 As DataGridViewRow In Me.GrillaDetalle.Rows
                    If row2.Cells(colD_SELECCION).Value = True Then
                        ds = Nothing
                        classGDescpacho.car_codigo = cmbCliente.SelectedValue
                        classGDescpacho.pic_ocnumero = row2.Cells(colD_OC_ORIGEN).Value
                        classGDescpacho.pic_fila = row2.Cells(colD_FIL).Value
                        classGDescpacho.gde_numero = IIf(txtNumero.Text = "", 0, txtNumero.Text)
                        classGDescpacho.cantidadDespachada = row2.Cells(colD_EXISTENTES).Value
                        classGDescpacho.gde_fecha = txtFecha.Value.ToShortDateString
                        classGDescpacho.fac_numero = row2.Cells(colD_NUM_FACTURA).Value
                        ds = classGDescpacho.DESPACHO_GUARDA_GUIA_DESPACHO(_msgError, conexion)
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
                        classGDescpacho.car_codigo = cmbCliente.SelectedValue
                        classGDescpacho.pic_ocnumero = row2.Cells(colD_OC_ORIGEN).Value
                        classGDescpacho.pic_fila = row2.Cells(colD_FIL).Value
                        classGDescpacho.gde_numero = IIf(txtNumero.Text = "", 0, txtNumero.Text)
                        classGDescpacho.cantidadDespachada = row2.Cells(colD_EXISTENTES).Value
                        ds = classGDescpacho.PICKING_MARCA_FILAS_DESPACHADAS(_msgError, conexion)
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
                    End If
                Next

                ds = Nothing
                classPicking.pic_codigo = _pic_codigo

                If txtNumero.Text <> "" Then
                    classPicking.lpi_descripcion = "Se despacha sin guía asociada " + txtNumero.Text
                Else
                    classPicking.lpi_descripcion = "Se despacha con guía n°: " + txtNumero.Text
                End If


                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                ds = classGDescpacho.REVISA_FILAS_DESPACHADAS(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("mensaje") > 0 Then
                        DetalleCompletoDespachado = True
                    Else
                        DetalleCompletoDespachado = False
                    End If
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                If DetalleCompletoDespachado = False Then
                    classPicking.lpi_descripcion = "Picking Despachado parcial"
                Else
                    classPicking.lpi_descripcion = "Picking Despachado completo"
                End If

                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                If DetalleCompletoDespachado = True Then
                    ds = Nothing
                    classPicking.pic_codigo = _pic_codigo
                    classPicking.epc_codigo = ESTADOS_PICKING.Despachado
                    ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
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
                End If

                Me.Cursor = Cursors.Default
                '----------------------
                '----------------------
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                MessageBox.Show("Los registros fueron ingresados en forma correcta ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call CARGA_GRILLA_DETALLE()
            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DESMARCAR_FILA()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
            If CLng(row.Cells(colD_ESTA_DESPACHADA).Value) = True Then
                row.Cells(0).Value = False
            End If
        Next
    End Sub
    Private Function DETALLES_MARCADAS() As Boolean
        Dim Contador As Integer = 0
        Try
            DETALLES_MARCADAS = False

            For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
                If row.Cells(colD_SELECCION).Value = True Then
                    Contador = Contador + 1
                End If
            Next

            If Contador > 0 Then
                DETALLES_MARCADAS = True
            End If

        Catch ex As Exception
            DETALLES_MARCADAS = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function VERIFICA_ITEMS_DESPACHADO() As Boolean
        Dim Contador As Integer = 0
        Try
            VERIFICA_ITEMS_DESPACHADO = False
            For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
                If row.Cells(colD_SELECCION).Value = True Then
                    If CLng(row.Cells(colD_ESTA_DESPACHADA).Value) = True Then
                        Contador = Contador + 1
                    End If
                End If
            Next
            If Contador > 0 Then
                VERIFICA_ITEMS_DESPACHADO = True
            End If
        Catch ex As Exception
            VERIFICA_ITEMS_DESPACHADO = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub GrillaDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellContentClick
        Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaDetalle.Rows(e.RowIndex).Cells(0)
        If e.ColumnIndex = Me.GrillaDetalle.Columns.Item(0).Index Then
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub ButtonSelecciona_Click(sender As Object, e As EventArgs) Handles ButtonSelecciona.Click
        txtFecha.Focus()
        Call MARCAR_TODOS()
    End Sub
    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
            row.Cells(0).Value = True
        Next
    End Sub

    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        txtFecha.Focus()
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub GrillaDetalle_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GrillaDetalle.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        PrecionaTeclaDesde = "GrillaDetalle"
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
    End Sub
    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = GrillaDetalle.CurrentCell.ColumnIndex
        Dim fila As Integer = GrillaDetalle.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = 9) Then
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

                        If (columna = colD_EXISTENTES) Then
                            If (cellTextBox IsNot Nothing) Then
                                With GrillaDetalle
                                    If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                                    ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex - 2, 0)
                                    End If
                                End With
                            End If

                            If GrillaDetalle.Rows(fila).Cells(colD_EXISTENTES).Value = "" Then
                                GrillaDetalle.Rows(fila).Cells(colD_EXISTENTES).Value = 0
                            End If

                            If GrillaDetalle.Rows(fila).Cells(colD_EXISTENTES).Value > GrillaDetalle.Rows(fila).Cells(colD_EXISTENTESREAL).Value Then
                                MessageBox.Show("la cantidad ingresada no puede ser mayor a la cantidad pendiente de despacho", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                GrillaDetalle.Rows(fila).Cells(colD_EXISTENTES).Value = GrillaDetalle.Rows(fila).Cells(colD_EXISTENTESREAL).Value
                                Exit Function
                            End If

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

    Private Sub ButtonExportar_Click(sender As Object, e As EventArgs) Handles ButtonExportar.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0

        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                                + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            class_comunes.ExportarExcel(Me.GrillaDetalle)
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EliminarItmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarItmToolStripMenuItem.Click
        Dim classDev As class_devolucion = New class_devolucion
        Dim classPicking As class_picking = New class_picking
        Dim classFactura As class_factura_picking = New class_factura_picking
        Dim classDespachar As class_despacha_picking = New class_despacha_picking
        Dim codigo As Integer = 0
        Dim _msgError As String = ""
        Dim respuesta As Integer = 0
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim ds As DataSet
        Dim DetalleCompletoDespachado As Boolean = False
        Dim numeroPicking As Long = 0

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                respuesta = MessageBox.Show("¿Esta seguro(a) de eliminar la fila seleccionada?." _
                                         + Chr(10) + "Este item NO quedara disponible para poder incluirla en un siguiete picking", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbNo Then
                    Exit Sub
                End If

                numeroPicking = GrillaDetalle.Rows(_fila).Cells(colD_PIC_CODIGO).Value

                ds = Nothing
                classPicking.pic_codigo = numeroPicking
                classPicking.pic_fila = GrillaDetalle.Rows(_fila).Cells(colD_FIL).Value
                classPicking.observaciones = "* Anulación de venta, por petición del cliente desde despacho"
                ds = classPicking.PICKING_QUITA_FILA(_msgError, conexion)
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

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = numeroPicking
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Se Anula fila " + GrillaDetalle.Rows(_fila).Cells(colD_FIL).Value.ToString + " del picking, por petición del cliente desde despacho"
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                ds = Nothing
                classDespachar.pic_codigo = numeroPicking
                ds = classDespachar.REVISA_FILAS_DESPACHADAS_DESDE_DESPACHO(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("mensaje") > 0 Then
                        DetalleCompletoDespachado = True
                    Else
                        DetalleCompletoDespachado = False
                    End If
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = numeroPicking
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                If DetalleCompletoDespachado = True Then
                    'classPicking.lpi_descripcion = "Picking facturado parcial"
                    'Else
                    classPicking.lpi_descripcion = "Picking despachado completo"
                End If

                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                ds = Nothing
                classPicking.pic_codigo = numeroPicking

                If DetalleCompletoDespachado = True Then
                    classPicking.epc_codigo = ESTADOS_PICKING.Despachado
                    'ElseIf DetalleCompletoFacturado = False Then
                    'classPicking.epc_codigo = ESTADOS_PICKING.Facturado_parcial

                    ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
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
                End If


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default

                Call CARGA_GRILLA_DETALLE()

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrillaDetalle_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GrillaDetalle.CellMouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            _colum = e.ColumnIndex
            _fila = e.RowIndex
        End If
    End Sub

    Private Sub EliminarProductoDelPickingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarProductoDelPickingToolStripMenuItem.Click

    End Sub
End Class