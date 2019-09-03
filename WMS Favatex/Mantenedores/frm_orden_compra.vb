Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_orden_compra
    Private _cnn As String
    Private _numOC As String
    Private _car_codigo As Integer
    Private _epc_codigo As Integer

    Private _car_numOC_auto As Boolean = False
    Private _car_funcionaVV As Boolean = False

    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""

    Const C_COD_PRODUCTO As Integer = 0
    Const C_COD_INTERNO As Integer = 1
    Const C_SKU_CLIENTE As Integer = 2
    Const C_NOMBRE_FAVATEX As Integer = 3
    Const C_NOMBRE_CLIENTE As Integer = 4
    Const C_CANTIDAD As Integer = 5
    Const C_PRECIO As Integer = 6
    Const C_TOTAL As Integer = 7
    Const C_QUITAR As Integer = 8

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property numOC() As String
        Get
            Return _numOC
        End Get
        Set(ByVal value As String)
            _numOC = value
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
    Public Property epc_codigo() As Integer
        Get
            Return _epc_codigo
        End Get
        Set(ByVal value As Integer)
            _epc_codigo = value
        End Set
    End Property

    Private Sub frm_orden_compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_01;User ID=sa;Password=S1st3m4s"
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        ToolStripButton2.Enabled = True
        Call INICIALIZA()
        If _numOC <> "0" And _numOC <> "" Then
            If _epc_codigo = ESTADOS_PICKING.En_proceso Then
                ToolStripButton2.Enabled = False
            End If

            cmbCliente.Enabled = False
            txtOrdenCompra.Enabled = False

            Call CARGA_DATOS_ENCABEZADO()
            Call VERIFICA_GESTION()
        End If
    End Sub

    Private Sub AjustaGrillas()
        GrillaFechas.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub VERIFICA_GESTION()
        Dim classOC As class_orden_compra = New class_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim fila As Integer = 0

        Try
            classOC.cnn = _cnn
            classOC.car_codigo = _car_codigo
            classOC.con_ocnumero = _numOC

            ds = classOC.ORDEN_COMPRA_CON_GESTION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(fila)("cantidad") > 0 Then
                        ToolStripButton2.Enabled = False
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_ENCABEZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_ENCABEZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CARGA_DATOS_ENCABEZADO()
        Dim classOC As class_orden_compra = New class_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim fila As Integer = 0

        Try
            classOC.cnn = _cnn
            classOC.car_codigo = _car_codigo
            classOC.con_ocnumero = _numOC
            classOC.age_fechaorden_string = "-"

            ds = classOC.CARGA_GRILLA_LISTADO_OC(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(fila)("car_codigo") > 0 Then
                        cmbCliente.SelectedValue = ds.Tables(0).Rows(fila)("car_codigo")
                        txtOrdenCompra.Text = ds.Tables(0).Rows(fila)("con_ocnumero")
                        chkParcial.Checked = ds.Tables(0).Rows(fila)("es_abierta")
                        txtFecha.Value = ds.Tables(0).Rows(fila)("con_fechadespacho")
                        txtDespachar.Text = ds.Tables(0).Rows(fila)("con_despachara")
                        txtLocal.Text = ds.Tables(0).Rows(fila)("con_localnombre")
                        txtRutCliente.Text = ds.Tables(0).Rows(fila)("rut_cliente")
                        txtNombreCliente.Text = ds.Tables(0).Rows(fila)("nombre_cliente")
                        txtEmailCliente.Text = ds.Tables(0).Rows(fila)("con_emailcliente")
                        txtFonoCliente.Text = ds.Tables(0).Rows(fila)("con_telefonocliente")
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
        Dim classOC As class_orden_compra = New class_orden_compra
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Dim diaCompromisoDesde As String = ""
        Dim mesCompromisoDesde As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classOC.cnn = _cnn
            classOC.car_codigo = _car_codigo
            classOC.con_ocnumero = _numOC

            _msg = ""
            GrillaFechas.Rows.Clear()
            ds = classOC.CARGA_GRILLA_LISTADO_DETALLE_OC(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("nombre_favatex") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaFechas.Rows.Add(ds.Tables(0).Rows(Fila)("cod_producto"),
                                            ds.Tables(0).Rows(Fila)("codigo_interno"),
                                            ds.Tables(0).Rows(Fila)("sku_cliente"),
                                            ds.Tables(0).Rows(Fila)("nombre_favatex"),
                                            ds.Tables(0).Rows(Fila)("nombre_cliente"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("precio"),
                                            ds.Tables(0).Rows(Fila)("total"), "",
                                            ds.Tables(0).Rows(Fila)("fila"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If

                GrillaFechas.Rows.Add(0, "", "", "", "", "", "", "")

            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_DETALLE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub INICIALIZA()

        GrillaFechas.DataSource = Nothing
        GrillaFechas.Rows.Clear()
        GrillaFechas.Rows.Add(0, "", "", "", "", "", "", "")

        cmbCliente.Enabled = True
        txtOrdenCompra.Enabled = True

        chkParcial.Enabled = False
        chkPorConfirmar.Enabled = False

        cmbCliente.Enabled = True
        cmbCliente.DataSource = Nothing
        cmbCliente.Items.Clear()
        Call CARGA_COMBO_CLIENTE()
        Call LIMPIA_FORMULARIO()
        Call AjustaGrillas()
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

    Private Sub LIMPIA_FORMULARIO()
        txtOrdenCompra.Text = "0"
        txtFecha.Value = Date.Today
        chkParcial.Checked = False
        txtDespachar.Text = ""
        txtLocal.Text = ""
        txtRutCliente.Text = ""
        txtNombreCliente.Text = ""
        txtEmailCliente.Text = ""
        txtFonoCliente.Text = ""
        _car_funcionaVV = False
        _car_numOC_auto = False
    End Sub

    Private Sub GrillaFechas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellContentClick
        If e.ColumnIndex = C_QUITAR Then
            Dim respuesta As Integer
            respuesta = MessageBox.Show("¿Esta seguro(a) de quitar la fila seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = vbYes Then
                Me.GrillaFechas.Rows.RemoveAt(e.RowIndex)
                If GrillaFechas.RowCount = 0 Then
                    GrillaFechas.Rows.Add(0, "", "", "", "", "", "", "")
                End If
            End If

        End If
    End Sub

    Private Sub GrillaFechas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GrillaFechas.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        PrecionaTeclaDesde = "GrillaFechas"
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
    End Sub

    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = GrillaFechas.CurrentCell.ColumnIndex
        Dim fila As Integer = GrillaFechas.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = C_CANTIDAD) Or (columna = C_PRECIO) Then
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

                Case Keys.Enter 'Or Keys.Down Or Keys.Up Or Keys.Left Or Keys.Right

                    'If GrillaFinanciamiento.Focus = True Then
                    If PrecionaTeclaDesde = "GrillaFechas" Then

                        columna = GrillaFechas.CurrentCell.ColumnIndex
                        fila = GrillaFechas.CurrentCell.RowIndex
                        If (cellTextBox IsNot Nothing) Then
                            With GrillaFechas
                                If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                                    .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                                ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                                    If .ColumnCount = (.CurrentCell.ColumnIndex + 1) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex, 0)
                                    Else
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex + 1, 0)
                                    End If

                                End If
                            End With
                        End If
                        If (columna = C_COD_INTERNO) Or (columna = C_SKU_CLIENTE) Then


                            If columna = C_COD_INTERNO Then
                                Call CARGA_DATOS_PRODUCTOS(1, fila)
                            ElseIf columna = C_SKU_CLIENTE Then
                                Call CARGA_DATOS_PRODUCTOS(2, fila)
                            End If

                        End If

                        If (columna = C_CANTIDAD) Or (columna = C_PRECIO) Then
                            If GrillaFechas.Rows(fila).Cells(C_CANTIDAD).Value.ToString = "" Then
                                GrillaFechas.Rows(fila).Cells(C_CANTIDAD).Value = "0"
                            End If

                            If GrillaFechas.Rows(fila).Cells(C_PRECIO).Value.ToString = "" Then
                                GrillaFechas.Rows(fila).Cells(C_PRECIO).Value = "0"
                            End If

                            GrillaFechas.Rows(fila).Cells(C_CANTIDAD).Value = FormatNumber(GrillaFechas.Rows(fila).Cells(C_CANTIDAD).Value, 0)
                            GrillaFechas.Rows(fila).Cells(C_PRECIO).Value = FormatNumber(GrillaFechas.Rows(fila).Cells(C_PRECIO).Value, 0)
                            GrillaFechas.Rows(fila).Cells(C_TOTAL).Value = FormatNumber(GrillaFechas.Rows(fila).Cells(C_CANTIDAD).Value * GrillaFechas.Rows(fila).Cells(C_PRECIO).Value, 0)
                        End If
                        Call AjustaGrillas()
                    End If

                    PrecionaTeclaDesde = ""
                Case Else

                    Return MyBase.ProcessCmdKey(msg, keyData)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub CARGA_DATOS_PRODUCTOS(ByVal Opcion As Integer, ByVal FilaDato As Integer)
        Dim classOC As class_orden_compra = New class_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim myfont As Font
        Dim fila As Integer = 0
        myfont = New Font(GrillaFechas.Font, ForeColor = Color.Red)

        Try
            classOC.cnn = _cnn
            classOC.car_codigo = cmbCliente.SelectedValue
            If Opcion = 1 Then
                classOC.codigo_interno = GrillaFechas.Rows(FilaDato).Cells(C_COD_INTERNO).Value
                classOC.con_skucliente = "-"
            Else
                classOC.codigo_interno = "-"
                classOC.con_skucliente = GrillaFechas.Rows(FilaDato).Cells(C_SKU_CLIENTE).Value
            End If
            classOC.opcion = Opcion

            ds = classOC.BUSCA_PRODUCTO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then

                    If ds.Tables(0).Rows(fila)("pro_codigo") > 0 Then
                        GrillaFechas.Rows(FilaDato).Cells(C_COD_PRODUCTO).Value = ds.Tables(0).Rows(fila)("pro_codigo")
                        GrillaFechas.Rows(FilaDato).Cells(C_COD_INTERNO).Value = ds.Tables(0).Rows(fila)("codigo_interno")
                        GrillaFechas.Rows(FilaDato).Cells(C_SKU_CLIENTE).Value = ds.Tables(0).Rows(fila)("sku_cliente")
                        GrillaFechas.Rows(FilaDato).Cells(C_NOMBRE_FAVATEX).Value = ds.Tables(0).Rows(fila)("pro_nombre")
                        GrillaFechas.Rows(FilaDato).Cells(C_NOMBRE_CLIENTE).Value = ds.Tables(0).Rows(fila)("sku_nombre")
                        GrillaFechas.Rows(FilaDato).Cells(C_CANTIDAD).Value = 0
                        GrillaFechas.Rows(FilaDato).Cells(C_PRECIO).Value = FormatNumber(ds.Tables(0).Rows(fila)("precio"), 0)
                        GrillaFechas.Rows(FilaDato).Cells(C_TOTAL).Value = FormatNumber(0 * ds.Tables(0).Rows(fila)("precio"), 0)

                        If GrillaFechas.Rows((GrillaFechas.RowCount - 1)).Cells(C_NOMBRE_FAVATEX).Value <> "" Then
                            GrillaFechas.Rows.Add(0, "", "", "", "", "", "", "")
                        End If

                        If ds.Tables(0).Rows(fila)("pro_nombre") = "" Or ds.Tables(0).Rows(fila)("sku_nombre") = "" Then
                            GrillaFechas.Rows(FilaDato).Cells(C_COD_PRODUCTO).Style.Font = myfont
                            GrillaFechas.Rows(FilaDato).Cells(C_COD_INTERNO).Style.Font = myfont
                            GrillaFechas.Rows(FilaDato).Cells(C_SKU_CLIENTE).Style.Font = myfont
                            GrillaFechas.Rows(FilaDato).Cells(C_NOMBRE_FAVATEX).Style.Font = myfont
                            GrillaFechas.Rows(FilaDato).Cells(C_NOMBRE_CLIENTE).Style.Font = myfont
                            GrillaFechas.Rows(FilaDato).Cells(C_CANTIDAD).Style.Font = myfont
                            GrillaFechas.Rows(FilaDato).Cells(C_PRECIO).Style.Font = myfont
                            GrillaFechas.Rows(FilaDato).Cells(C_TOTAL).Style.Font = myfont
                        End If
                    Else
                        MessageBox.Show("No existe el codigo relacionado al cliente seleccionado, verifique el mix de productos asociado al cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
                'GrillaFechas.AutoResizeColumns()
                'Call PINTA_GRILLA()
                'Call PINTA_GRILLA_FECHAS()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If VALIDA() = False Then
            Exit Sub
        End If

        Call GUARDAR()
    End Sub
    Private Function VALIDA() As Boolean
        Dim classComun As class_comunes = New class_comunes

        VALIDA = False
        If cmbCliente.Text = "" Then
            MessageBox.Show("Debe seleccionar cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Function
        End If

        If txtOrdenCompra.Text = "" Or txtOrdenCompra.Text = "0" Then
            MessageBox.Show("Debe digitar el numero de la orden de compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Function
        End If

        If _car_funcionaVV = True Then
            If txtRutCliente.Text = "" Then
                MessageBox.Show("Debe ingresar el rut del cliente final", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtRutCliente.Focus()
                Exit Function
            End If

            If classComun.validarRut(txtRutCliente.Text) = False Then
                MessageBox.Show("rut no valido, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtRutCliente.Focus()
                Exit Function
            End If

            If txtNombreCliente.Text = "" Then
                MessageBox.Show("Debe ingresar el nombre del cliente final", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNombreCliente.Focus()
                Exit Function
            End If

            If txtFonoCliente.Text = "" Then
                MessageBox.Show("Debe ingresar el teléfono del cliente final", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtFonoCliente.Focus()
                Exit Function
            End If

        End If

        If VALIDA_DETALLES() = False Then
            MessageBox.Show("No existen productos ingresados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        If VALIDA_MONTO() = True Then
            MessageBox.Show("Existen productos al cual no se le a ingresado una cantidad o un precio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        VALIDA = True
    End Function

    Private Function VALIDA_DETALLES() As Boolean
        Dim Contador As Integer = 0
        Try
            VALIDA_DETALLES = False

            For Each row As DataGridViewRow In Me.GrillaFechas.Rows
                If row.Cells(2).Value <> "" Then
                    Contador = Contador + 1
                End If
            Next

            If Contador > 0 Then
                VALIDA_DETALLES = True
            End If

        Catch ex As Exception
            VALIDA_DETALLES = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function VALIDA_MONTO() As Boolean
        Dim Contador As Integer = 0
        Try
            VALIDA_MONTO = False

            For Each row As DataGridViewRow In Me.GrillaFechas.Rows
                If row.Cells(2).Value <> "" Then
                    If CInt(row.Cells(7).Value) = 0 Then
                        Contador = Contador + 1
                    End If
                End If
            Next

            If Contador > 0 Then
                VALIDA_MONTO = True
            End If

        Catch ex As Exception
            VALIDA_MONTO = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GUARDAR()
        Dim classOC As class_orden_compra = New class_orden_compra
        Dim fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classOC.car_codigo = cmbCliente.SelectedValue
                classOC.car_codigo = cmbCliente.SelectedValue
                classOC.con_ocnumero = txtOrdenCompra.Text

                ds = classOC.ELIMINA_ORDEN_COMPRA(_msgError, conexion)
                If _msgError <> "" Then
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                Do While fila < GrillaFechas.RowCount - 1
                    classOC.con_ocnumero = txtOrdenCompra.Text
                    classOC.con_skucliente = GrillaFechas.Rows(fila).Cells(C_SKU_CLIENTE).Value
                    classOC.con_skudescripcion = GrillaFechas.Rows(fila).Cells(C_NOMBRE_FAVATEX).Value
                    classOC.con_cantidad = GrillaFechas.Rows(fila).Cells(C_CANTIDAD).Value
                    classOC.con_preciocosto = GrillaFechas.Rows(fila).Cells(C_PRECIO).Value
                    classOC.con_fechadespacho = txtFecha.Value
                    classOC.con_despacharanumero = 0
                    classOC.con_despachara = IIf(txtDespachar.Text = "", "-", txtDespachar.Text)
                    classOC.con_local = 0
                    classOC.con_localnombre = IIf(txtLocal.Text = "", "-", txtLocal.Text)

                    If _car_funcionaVV = True Then
                        classOC.rut_cliente = txtRutCliente.Text
                        classOC.nombre_cliente = txtNombreCliente.Text
                        classOC.con_telefonocliente = txtFonoCliente.Text
                        classOC.con_emailcliente = txtEmailCliente.Text

                        classOC.es_agendable = 0
                        classOC.es_abierta = 0
                    Else
                        classOC.rut_cliente = "-"
                        classOC.nombre_cliente = "-"
                        classOC.con_telefonocliente = "-"
                        classOC.con_emailcliente = "-"
                        classOC.es_agendable = 1
                        classOC.es_abierta = chkParcial.Checked
                    End If

                    classOC.con_observacion = "-"
                    classOC.con_codigounico = "-"

                    classOC.con_nombrearchivo = "INGRESO MANUAL"
                    classOC.por_confirmar = chkPorConfirmar.Checked
                    classOC.con_comunareceptor = "-"
                    classOC.con_ciudadreceptor = "-"

                    classOC.con_sucursalentrega = "-"
                    classOC.con_fechaventa = CDate("01-01-1900")
                    classOC.con_numboleta = 0
                    classOC.con_fechaentrega = CDate("01-01-1900")
                    classOC.con_numcaja = 0
                    classOC.fecha_emision = txtFechaEmision.Value

                    'If chkPorConfirmar.Checked = True Then

                    'End If


                    ds = classOC.INGRESA_REPOSITORIO(_msgError, conexion)
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

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                respuesta = MessageBox.Show("La orden de compra fue guardada en forma correcta" _
                                            + Chr(10) + "¿Desea ingresar otro documento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbYes Then
                    Call INICIALIZA()
                Else
                    Me.Dispose()
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        _numOC = ""
        _car_codigo = 0
        _epc_codigo = 0
        Call INICIALIZA()
    End Sub

    Private Sub chkPorConfirmar_CheckedChanged(sender As Object, e As EventArgs) Handles chkPorConfirmar.CheckedChanged
        If chkPorConfirmar.Checked = True Then
            chkParcial.Checked = True
            chkParcial.Enabled = False
        ElseIf chkPorConfirmar.Checked = False Then
            chkParcial.Checked = False
            chkParcial.Enabled = True
        End If
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

    End Sub

    Private Sub cmbCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCliente.SelectionChangeCommitted
        txtOrdenCompra.Text = "0"
        txtOrdenCompra.Enabled = True

        _car_codigo = 0
        _car_codigo = cmbCliente.SelectedValue
        'If cmbCliente.Text <> "" Then
        '    _car_codigo = cmbCliente.SelectedValue
        'End If

        txtRutCliente.Text = ""
        txtNombreCliente.Text = ""
        txtEmailCliente.Text = ""
        txtFonoCliente.Text = ""
        _car_numOC_auto = False
        _car_funcionaVV = False
        Call OBTIENE_ATRIBUTOS_CLIENTES()

        If _car_numOC_auto = True Then
            Call OBTIENE_ULTIMA_OC()
        Else
            txtOrdenCompra.Text = "0"
        End If

        If _car_funcionaVV = True Then
            txtRutCliente.Enabled = True
            txtNombreCliente.Enabled = True
            txtEmailCliente.Enabled = True
            txtFonoCliente.Enabled = True

            chkParcial.Checked = False
            chkPorConfirmar.Checked = False

            chkParcial.Enabled = False
            chkPorConfirmar.Enabled = False
        Else
            txtRutCliente.Enabled = False
            txtNombreCliente.Enabled = False
            txtEmailCliente.Enabled = False
            txtFonoCliente.Enabled = False
            chkParcial.Enabled = True
            chkPorConfirmar.Enabled = True
        End If

        'If cmbCliente.SelectedValue = 17 Or cmbCliente.SelectedValue = 23 Then
        '    Call OBTIENE_ULTIMA_OC()
        'End If


    End Sub

    Private Sub OBTIENE_ATRIBUTOS_CLIENTES()
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
                        _car_numOC_auto = ds.Tables(0).Rows(Fila)("car_numOC_auto")
                        _car_funcionaVV = ds.Tables(0).Rows(Fila)("car_funcionaVV")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\OBTIENE_ATRIBUTOS_CLIENTES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "OBTIENE_ATRIBUTOS_CLIENTES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub OBTIENE_ULTIMA_OC()
        Dim classOC As class_orden_compra = New class_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim fila As Integer = 0

        Try
            classOC.cnn = _cnn
            classOC.car_codigo = cmbCliente.SelectedValue

            ds = classOC.ORDEN_COMPRA_ULTIMA_OC(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(fila)("num_oc") > 0 Then
                        txtOrdenCompra.Text = ds.Tables(0).Rows(fila)("num_oc")
                        txtOrdenCompra.Enabled = False
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_ULTIMA_OC", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\OBTIENE_ULTIMA_OC", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtOrdenCompra_TextChanged(sender As Object, e As EventArgs) Handles txtOrdenCompra.TextChanged

    End Sub

    Private Sub txtOrdenCompra_LostFocus(sender As Object, e As EventArgs) Handles txtOrdenCompra.LostFocus
        _numOC = txtOrdenCompra.Text
        If _numOC <> "0" And _numOC <> "" Then
            _car_codigo = cmbCliente.SelectedValue
            If _epc_codigo = ESTADOS_PICKING.En_proceso Then
                ToolStripButton2.Enabled = False
            End If

            Call CARGA_DATOS_ENCABEZADO()
            Call VERIFICA_GESTION()
        End If
    End Sub
End Class