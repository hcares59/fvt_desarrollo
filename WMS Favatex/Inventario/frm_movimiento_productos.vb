Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_movimiento_productos
    Private _cnn As String
    Private _Folio As Long

    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""

    Const C_FILA As Integer = 0
    Const C_COD_PRODUCTO As Integer = 1
    Const C_COD_INTERNO As Integer = 2
    Const C_NOMBRE_FAVATEX As Integer = 3
    Const C_CANTIDAD As Integer = 4
    Const C_PRECIO As Integer = 5
    Const C_TOTAL As Integer = 6
    Const C_QUITAR As Integer = 7

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property Folio() As Long
        Get
            Return _Folio
        End Get
        Set(ByVal value As Long)
            _Folio = value
        End Set
    End Property

    Private Sub frm_movimiento_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        _cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_01;User ID=sa;Password=S1st3m4s"
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        GrillaDetalle.DataSource = Nothing
        GrillaDetalle.Rows.Clear()
        GrillaDetalle.Rows.Add(0, "", "", "", "", "")

        Call CARGA_COMBO_TIPO_MOVIMINETO()
        cmbTipo.SelectedValue = TIPO_MOVIMIENTO.ENTRADA
        Call CARGA_COMBO_TIPO_DOCUMENTO()

        Call CARGA_COMBO_BODEGA_1()
        Call CARGA_COMBO_BODEGA_2()
        Call CARGA_COMBO_PROVEEDOR()


        txtFolio.Text = "0"
        txtNumDoc.Text = "0"
        txtObservacion.Text = ""


        lblBodega1.Text = "BODEGA DESTINO"
        lblBodega2.Visible = False
        cmbBodega2.Visible = False
    End Sub

    Private Sub CARGA_COMBO_TIPO_MOVIMINETO()
        Dim _msg As String
        Try
            Dim classMOV As class_movimientos = New class_movimientos
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classMOV.cnn = _cnn
            _msg = ""
            ds = classMOV.CARGA_COMBO_TIPO_MOVIMIENTO(_msg)
            If _msg = "" Then
                Me.cmbTipo.DataSource = ds.Tables(0)
                Me.cmbTipo.DisplayMember = "MENSAJE"
                Me.cmbTipo.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_MOVIMINETO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_BODEGA_1()
        Dim _msg As String
        Try
            Dim classMOV As class_movimientos = New class_movimientos
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classMOV.cnn = _cnn
            _msg = ""
            ds = classMOV.CARGA_COMBO_BODEGA(_msg)
            If _msg = "" Then
                Me.cmbBodega1.DataSource = ds.Tables(0)
                Me.cmbBodega1.DisplayMember = "MENSAJE"
                Me.cmbBodega1.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_BODEGA_1", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_BODEGA_2()
        Dim _msg As String
        Try
            Dim classMOV As class_movimientos = New class_movimientos
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classMOV.cnn = _cnn
            _msg = ""
            ds = classMOV.CARGA_COMBO_BODEGA(_msg)
            If _msg = "" Then
                Me.cmbBodega2.DataSource = ds.Tables(0)
                Me.cmbBodega2.DisplayMember = "MENSAJE"
                Me.cmbBodega2.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_BODEGA_2", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_PROVEEDOR()
        Dim _msg As String
        Try
            Dim classMOV As class_movimientos = New class_movimientos
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classMOV.cnn = _cnn
            _msg = ""
            ds = classMOV.CARGA_COMBO_PROVEEDOR(_msg)
            If _msg = "" Then
                Me.cmbCartera.DataSource = ds.Tables(0)
                Me.cmbCartera.DisplayMember = "MENSAJE"
                Me.cmbCartera.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_TIPO_DOCUMENTO()
        Dim _msg As String
        Try
            Dim classMOV As class_movimientos = New class_movimientos
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classMOV.cnn = _cnn

            If cmbTipo.SelectedValue = TIPO_MOVIMIENTO.ENTRADA Then
                classMOV.opcion = 1
            ElseIf cmbTipo.SelectedValue = TIPO_MOVIMIENTO.SALIDA Then
                classMOV.opcion = 2
            End If

            _msg = ""
            ds = classMOV.CARGA_COMBO_TIPO_DOCUMENTO_MOV(_msg)
            If _msg = "" Then
                Me.cmbTipoDoc.DataSource = ds.Tables(0)
                Me.cmbTipoDoc.DisplayMember = "MENSAJE"
                Me.cmbTipoDoc.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_DOCUMENTO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbBodega1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega1.SelectedIndexChanged

    End Sub

    Private Sub HABILITA_BODEGAS()

        lblCartera.Visible = True
        cmbCartera.Visible = True

        lblTipoDoc.Visible = True
        cmbTipoDoc.Visible = True

        lblNumDoc.Visible = True
        txtNumDoc.Visible = True

        If cmbTipo.SelectedValue = TIPO_MOVIMIENTO.ENTRADA Then
            lblBodega1.Text = "BODEGA DESTINO"
            lblBodega2.Visible = False
            cmbBodega2.Visible = False
            lblCartera.Text = "PROVEEDOR"
        ElseIf cmbTipo.SelectedValue = TIPO_MOVIMIENTO.SALIDA Then
            lblBodega1.Text = "BODEGA ORIGEN"
            lblBodega2.Visible = False
            cmbBodega2.Visible = False
            lblCartera.Text = "CLIENTE"
        ElseIf cmbTipo.SelectedValue = TIPO_MOVIMIENTO.TRASPASO Then
            lblBodega1.Text = "BODEGA ORIGEN"
            lblBodega2.Visible = True
            cmbBodega2.Visible = True
            lblBodega2.Text = "BODEGA DESTINO"

            lblCartera.Visible = False
            cmbCartera.Visible = False

            lblTipoDoc.Visible = False
            cmbTipoDoc.Visible = False

            lblNumDoc.Visible = False
            txtNumDoc.Visible = False

        End If
    End Sub

    Private Sub cmbTipo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTipo.SelectionChangeCommitted
        Call HABILITA_BODEGAS()
        Call CARGA_COMBO_TIPO_DOCUMENTO()
    End Sub

    Private Sub GrillaDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellContentClick
        If e.ColumnIndex = C_QUITAR Then
            Dim respuesta As Integer
            respuesta = MessageBox.Show("¿Esta seguro(a) de quitar la fila seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = vbYes Then
                Me.GrillaDetalle.Rows.RemoveAt(e.RowIndex)
                If GrillaDetalle.RowCount = 0 Then
                    GrillaDetalle.Rows.Add(0, "", "", "", "", "", "", "")
                End If
            End If

        End If
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
                    If PrecionaTeclaDesde = "GrillaDetalle" Then

                        columna = GrillaDetalle.CurrentCell.ColumnIndex
                        fila = GrillaDetalle.CurrentCell.RowIndex
                        If (cellTextBox IsNot Nothing) Then
                            With GrillaDetalle
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

                        If columna = C_COD_INTERNO Then
                            Call CARGA_DATOS_PRODUCTOS(1, fila)
                        End If



                        If (columna = C_CANTIDAD) Or (columna = C_PRECIO) Then
                            If GrillaDetalle.Rows(fila).Cells(C_CANTIDAD).Value.ToString = "" Then
                                GrillaDetalle.Rows(fila).Cells(C_CANTIDAD).Value = "0"
                            End If

                            If GrillaDetalle.Rows(fila).Cells(C_PRECIO).Value.ToString = "" Then
                                GrillaDetalle.Rows(fila).Cells(C_PRECIO).Value = "0"
                            End If

                            GrillaDetalle.Rows(fila).Cells(C_CANTIDAD).Value = FormatNumber(GrillaDetalle.Rows(fila).Cells(C_CANTIDAD).Value, 0)
                            GrillaDetalle.Rows(fila).Cells(C_PRECIO).Value = FormatNumber(GrillaDetalle.Rows(fila).Cells(C_PRECIO).Value, 0)
                            GrillaDetalle.Rows(fila).Cells(C_TOTAL).Value = FormatNumber(GrillaDetalle.Rows(fila).Cells(C_CANTIDAD).Value * GrillaDetalle.Rows(fila).Cells(C_PRECIO).Value, 0)
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

    Private Sub CARGA_DATOS_PRODUCTOS(ByVal Opcion As Integer, ByVal FilaDato As Integer)
        Dim classPR As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim myfont As Font
        Dim fila As Integer = 0
        myfont = New Font(GrillaDetalle.Font, ForeColor = Color.Red)

        Try
            classPR.cnn = _cnn
            classPR.codigo_interno = GrillaDetalle.Rows(FilaDato).Cells(C_COD_INTERNO).Value
            ds = classPR.BUSCA_PRODUCTO_CODIGO_INTERNO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then

                    If ds.Tables(0).Rows(fila)("pro_codigo") > 0 Then
                        GrillaDetalle.Rows(FilaDato).Cells(C_COD_PRODUCTO).Value = ds.Tables(0).Rows(fila)("pro_codigo")
                        GrillaDetalle.Rows(FilaDato).Cells(C_COD_INTERNO).Value = ds.Tables(0).Rows(fila)("codigo_interno")
                        GrillaDetalle.Rows(FilaDato).Cells(C_NOMBRE_FAVATEX).Value = ds.Tables(0).Rows(fila)("pro_nombre")
                        GrillaDetalle.Rows(FilaDato).Cells(C_CANTIDAD).Value = 0
                        GrillaDetalle.Rows(FilaDato).Cells(C_PRECIO).Value = FormatNumber(ds.Tables(0).Rows(fila)("precio"), 0)
                        GrillaDetalle.Rows(FilaDato).Cells(C_TOTAL).Value = FormatNumber(0 * ds.Tables(0).Rows(fila)("precio"), 0)

                        If GrillaDetalle.Rows((GrillaDetalle.RowCount - 1)).Cells(C_NOMBRE_FAVATEX).Value <> "" Then
                            GrillaDetalle.Rows.Add(0, "", "", "", "", "")
                        End If
                    Else
                        MessageBox.Show("No existe el codigo en la base de datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged

    End Sub

    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click

    End Sub

    Private Function VALIDA_DATOS() As Boolean
        VALIDA_DATOS = False

        If cmbTipo.Text = "" Then
            MessageBox.Show("Debe seleccionar un tipo de movimiento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbTipo.Focus()
            Exit Function
        End If

        If cmbTipo.SelectedValue = TIPO_MOVIMIENTO.ENTRADA Then
            If cmbBodega1.Text = "" Then
                MessageBox.Show("Debe seleccionar la bodega de destino", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbBodega1.Focus()
                Exit Function
            End If

            If cmbCartera.Text = "" Then
                MessageBox.Show("Debe seleccionar el proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbCartera.Focus()
                Exit Function
            End If

            If cmbTipoDoc.Text = "" Then
                MessageBox.Show("Debe seleccionar el tipo de documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbTipoDoc.Focus()
                Exit Function
            End If

            If txtNumDoc.Text = "" Then
                MessageBox.Show("Debe ingresar el número del documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNumDoc.Focus()
                Exit Function
            End If
        ElseIf cmbTipo.SelectedValue = TIPO_MOVIMIENTO.SALIDA Then
            If cmbBodega1.Text = "" Then
                MessageBox.Show("Debe seleccionar la bodega de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbBodega1.Focus()
                Exit Function
            End If

            If cmbCartera.Text = "" Then
                MessageBox.Show("Debe seleccionar el cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbCartera.Focus()
                Exit Function
            End If

            If cmbTipoDoc.Text = "" Then
                MessageBox.Show("Debe seleccionar el tipo de documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbTipoDoc.Focus()
                Exit Function
            End If

            If txtNumDoc.Text = "" Then
                MessageBox.Show("Debe ingresar el número del documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNumDoc.Focus()
                Exit Function
            End If
        ElseIf cmbTipo.SelectedValue = TIPO_MOVIMIENTO.TRASPASO Then
            If cmbBodega1.Text = "" Then
                MessageBox.Show("Debe seleccionar la bodega de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbBodega1.Focus()
                Exit Function
            End If

            If cmbBodega2.Text = "" Then
                MessageBox.Show("Debe seleccionar la bodega de destino", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbBodega1.Focus()
                Exit Function
            End If
        End If
    End Function

    Private Sub GUARDAR(ByVal tipoMov As Integer, ByVal codBodega As Integer)
        Dim classMOV As class_movimientos = New class_movimientos
        Dim fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""

        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                If CStr(txtFecha.Value.Month).Length = 1 Then
                    mes = Trim("0" + CStr(txtFecha.Value.Month))
                Else
                    mes = CStr(txtFecha.Value.Month)
                End If

                classMOV.mov_folio = _Folio
                classMOV.tmo_codigo = tipoMov
                classMOV.bod_codigo = codBodega
                classMOV.mov_fechamovimiento = txtFecha.Text
                classMOV.mov_mes = mes
                classMOV.mov_anno = CStr(txtFecha.Value.Year)
                classMOV.mov_usuario = GLO_USUARIO_ACTUAL

                If (TIPO_MOVIMIENTO.ENTRADA = tipoMov) Or (TIPO_MOVIMIENTO.SALIDA = tipoMov) Then
                    classMOV.car_codigo = cmbCartera.SelectedValue
                    classMOV.tdo_codigo = cmbTipoDoc.SelectedValue
                    classMOV.mov_nomdoc = txtNumDoc.Text
                Else
                    classMOV.car_codigo = 0
                    classMOV.tdo_codigo = 0
                    classMOV.mov_nomdoc = ""
                End If

                classMOV.mov_foliorelacionado = 0
                classMOV.mov_observacion = IIf(txtObservacion.Text = "", "-", txtObservacion.Text)
                ds = classMOV.MOVIMIENTOS_GUARDA_ENCABEZADO(_msgError, conexion)
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

                classMOV.mov_folio = _Folio

                ds = classMOV.ELIMINA_DETALLE_MOVIMIENTO(_msgError, conexion)
                If _msgError <> "" Then
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Sub
                    End If
                End If

                Do While fila < GrillaDetalle.RowCount - 1
                    classMOV.mov_folio = _Folio
                    classMOV.pro_codigo = GrillaDetalle.Rows(fila).Cells(C_COD_PRODUCTO).Value
                    classMOV.dmo_cantidad = GrillaDetalle.Rows(fila).Cells(C_CANTIDAD).Value
                    classMOV.dmo_bultos = GrillaDetalle.Rows(fila).Cells(C_CANTIDAD).Value
                    classMOV.dmo_totalbultos = GrillaDetalle.Rows(fila).Cells(C_PRECIO).Value

                    '''''ds = classOC.INGRESA_REPOSITORIO(_msgError, conexion)
                    '''''If ds.Tables(0).Rows.Count > 0 Then
                    '''''    If _msgError = "" Then
                    '''''        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    '''''            If conexion.State = ConnectionState.Open Then
                    '''''                conexion.Close()
                    '''''            End If
                    '''''            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '''''            ds = Nothing
                    '''''            Exit Sub
                    '''''        End If
                    '''''    Else
                    '''''        If conexion.State = ConnectionState.Open Then
                    '''''            conexion.Close()
                    '''''        End If
                    '''''        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '''''        ds = Nothing
                    '''''        Exit Sub
                    '''''    End If
                    '''''End If
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

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub
End Class