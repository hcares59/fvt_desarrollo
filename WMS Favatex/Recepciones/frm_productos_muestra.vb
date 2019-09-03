Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_productos_muestra
    Private _cnn As String
    Private _rec_codigo As Integer
    Private _ere_codigo As Integer = 0
    Private _nom_proveedor As String
    Private _Observacion As String
    Private _ExisteMuestra As Boolean
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
    Public Property rec_codigo() As Integer
        Get
            Return _rec_codigo
        End Get
        Set(ByVal value As Integer)
            _rec_codigo = value
        End Set
    End Property
    Public Property nom_proveedor() As String
        Get
            Return _nom_proveedor
        End Get
        Set(ByVal value As String)
            _nom_proveedor = value
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

    Private Sub frm_productos_muestra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
        ButtonGurdar.Enabled = True
        ButtonImprime.Enabled = False
        _ExisteMuestra = EXISTE_MUESTRA()

        If _ExisteMuestra Then
            ButtonImprime.Enabled = True
            If USU_ASIGNA_PARA_RECEPCION = False Or USU_EJECUTA_RECEPCION = False Then
                If _ere_codigo = ESTADO_RECEPCION.APROBADA_POR_BODEGA Then
                    cmbZona.Visible = True
                    txtNumTraspaso.Visible = True
                    lblZona.Visible = True
                    lblNumTraspaso.Visible = True
                End If
            End If
        Else
            cmbZona.Visible = False
            txtNumTraspaso.Visible = False
            lblZona.Visible = False
            lblNumTraspaso.Visible = False
        End If

        Call CARGA_DATOS_ENCABEZADO()

    End Sub

    Private Sub CARGA_RECEPCION_MUESTRA_DETALLE()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            ds = classRecepcion.RECEPCION_MUESTRA_LISTADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaDetalle.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("cantidad_muestra"),
                                            ds.Tables(0).Rows(Fila)("bul_unidad"),
                                            ds.Tables(0).Rows(Fila)("bul_total"),
                                            ds.Tables(0).Rows(Fila)("rec_fila"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_RECEPCION_MUESTRA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_RECEPCION_MUESTRA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function EXISTE_MUESTRA() As Boolean
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_MUESTRA = False
        Try

            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo

            ds = classRecepcion.RECEPCION_MUESTRA_EXISTE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("cantidad") <= 0 Then
                        EXISTE_MUESTRA = False
                    Else
                        EXISTE_MUESTRA = True
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\EXISTE_MUESTRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\EXISTE_MUESTRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function EXISTE_MUESTRA_CON_NUMERO_TRASPASO() As Boolean
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_MUESTRA_CON_NUMERO_TRASPASO = False
        Try

            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo

            ds = classRecepcion.RECEPCION_MUESTRA_CON_NUMERO_TRASPASO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("cantidad") <= 0 Then
                        EXISTE_MUESTRA_CON_NUMERO_TRASPASO = False
                    Else
                        EXISTE_MUESTRA_CON_NUMERO_TRASPASO = True
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\EXISTE_MUESTRA_CON_NUMERO_TRASPASO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\EXISTE_MUESTRA_CON_NUMERO_TRASPASO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub INICIALIZA()
        Call CARGA_COMBO_ZONA_POR_BODEGA()
    End Sub

    Private Sub CARGA_COMBO_ZONA_POR_BODEGA()
        Dim _msg As String
        Try
            Dim classZona As class_zonas = New class_zonas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classZona.cnn = _cnn
            classZona.bod_codigo = GLO_BODEGA_CALIDAD

            _msg = ""
            ds = classZona.ZONAS_CARGA_ZONAS_POR_BODEGA(_msg)
            If _msg = "" Then
                Me.cmbZona.DataSource = ds.Tables(0)
                Me.cmbZona.DisplayMember = "MENSAJE"
                Me.cmbZona.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ZONA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_DATOS_ENCABEZADO()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            classRecepcion.car_codigo = 0
            classRecepcion.rec_nguia = 0
            classRecepcion.rec_nfactura = 0
            classRecepcion.rec_ordencompra = 0
            classRecepcion.fecha_desde = "19000101"
            classRecepcion.fecha_hasta = "20501231"
            classRecepcion.ere_codigo = 0

            ds = classRecepcion.RECEPCIONES_LISTAR(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        lblNumRec.Text = "RECEPCIÓN NÚMERO: " + ds.Tables(0).Rows(Fila)("rec_numero").ToString
                        lblProveedor.Text = "PROVEEDOR: " + ds.Tables(0).Rows(Fila)("car_nombre")

                        If _ExisteMuestra = False Then
                            Call CARGA_GRILLA_DETALLE()
                        Else
                            Call CARGA_RECEPCION_MUESTRA_DETALLE()
                            If EXISTE_MUESTRA_CON_NUMERO_TRASPASO() = True Then
                                ButtonGurdar.Enabled = False
                                ButtonImprime.Enabled = True
                            End If
                        End If
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
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            ds = classRecepcion.RECEPCIONES_DETALLE_LISTAR(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaDetalle.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("rde_cantidad"),
                                            0,
                                            ds.Tables(0).Rows(Fila)("rde_bultosunidad"),
                                            ds.Tables(0).Rows(Fila)("rde_bultos"),
                                            ds.Tables(0).Rows(Fila)("rec_fila"))
                            Fila = Fila + 1
                        Loop

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

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If (_ExisteMuestra = True) And (_ere_codigo = ESTADO_RECEPCION.APROBADA_POR_BODEGA) Then
            Call GUARDA_MOVIMIENTO()
        Else
            Call GUARDAR_MUESTRA()
        End If
    End Sub

    Private Sub GUARDAR_MUESTRA()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                Do While fila < GrillaDetalle.RowCount
                    classRecepcion.rec_numero = _rec_codigo
                    classRecepcion.rec_fila = GrillaDetalle.Rows(fila).Cells(7).Value
                    classRecepcion.pro_codigo = GrillaDetalle.Rows(fila).Cells(0).Value
                    classRecepcion.cantidad = GrillaDetalle.Rows(fila).Cells(3).Value
                    classRecepcion.cantidad_muestra = GrillaDetalle.Rows(fila).Cells(4).Value
                    classRecepcion.bul_unidad = GrillaDetalle.Rows(fila).Cells(5).Value
                    classRecepcion.bul_total = GrillaDetalle.Rows(fila).Cells(6).Value

                    ds = classRecepcion.RECEPCION_GUARDA_MUESTRA(_msgError, conexion)
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

                respuesta = MessageBox.Show("La muestra fue ingresada en forma correcta" _
                                            + Chr(10) + "¿Desea imprimir el informe de muestra?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbYes Then
                    Call IMPREME_MUESTRA()
                End If

                Me.Dispose()

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GUARDA_MOVIMIENTO() As Boolean
        Dim classMOV As class_movimientos = New class_movimientos
        Dim classInv As class_inventario = New class_inventario
        'Dim class_recepcion As class_recepcion = New class_recepcion
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim ds As DataSet = New DataSet
        Dim dsDetalle As DataSet = New DataSet
        Dim dsInventario As DataSet = New DataSet
        Dim dsMov As DataSet = New DataSet
        Dim _numCantidadBultos As Integer = 0

        Dim _Folio As Integer = 0
        Dim _FolioRelacionado As Integer = 0
        Dim fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim _fecha As Date
        Dim cantidad As Integer = 0
        Dim sumaCantidad As Integer = 0
        Dim seriePallet As String = ""

        GUARDA_MOVIMIENTO = False

        If txtNumTraspaso.Text = "" Or txtNumTraspaso.Text = "0" Then
            MessageBox.Show("Debe ingresar el número de traspaso obtenido desde Manager", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumTraspaso.Focus()
            Exit Function
        End If

        Try
            _Observacion = "MOVIMIENTO GENERADO A TRAVEZ DE LA RECEPCIÓN NUMERO:  " + _rec_codigo.ToString + " PARA CALIDAD"
            '_numCantidadBultos = OBTIENE_NUMERO_BULTOS(cmbProductos.SelectedValue)

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                _fecha = GLO_FECHA_SISTEMA

                If cmbZona.Text = "" Then
                    MessageBox.Show("Debe seleccionar una zona", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If CStr(_fecha.Month).Length = 1 Then
                    mes = Trim("0" + CStr(_fecha.Month))
                Else
                    mes = CStr(_fecha.Month)
                End If

                'cantidad = OBTIENE_CANTIDAD()

                'If cantidad < 0 Then
                '    Exit Function
                'End If

                'SALIDA DE BODEGA DE ORIGEN
                '=============================================================
                If GUARDA_ENC_MOVIMINETO(conexion, 0, TIPO_MOVIMIENTO.SALIDA, GLO_BODEGA_RECEPCION, _fecha, mes, _fecha.Year, GLO_USUARIO_ACTUAL, 0,
                                         COM_TIPO_DOCUMENTO.VALE_DE_SALIDA, 0, 0, _Observacion, "-", 0, _Folio) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                _FolioRelacionado = _Folio

                If ELIMINA_DETALLE_MOVIMIENTO(conexion, _Folio) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                ' Suma cantidades
                Do While fila <= GrillaDetalle.Rows.Count - 1
                    If CInt(GrillaDetalle.Rows(fila).Cells(4).Value) > 0 Then
                        sumaCantidad = sumaCantidad + CInt(GrillaDetalle.Rows(fila).Cells(4).Value)
                    End If
                    fila = fila + 1
                Loop

                If sumaCantidad = 0 Then
                    MessageBox.Show("Debe ingresar la cantidad de muestra en al menos un producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                'If ACTULIZA_UBICACION_DEL_PALLET(conexion, GLO_USUARIO_ACTUAL) = False Then
                '    If conexion.State = ConnectionState.Open Then
                '        conexion.Close()
                '    End If

                '    Return False
                '    Exit Function
                'End If

                'If _numCantidadBultos = 0 Then
                '    MessageBox.Show("La cantidad de bultos del producto, no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                '    If conexion.State = ConnectionState.Open Then
                '        conexion.Close()
                '    End If

                '    Return False
                '    Exit Function
                'End If

                fila = 0
                Do While fila <= GrillaDetalle.Rows.Count - 1
                    If CInt(GrillaDetalle.Rows(fila).Cells(4).Value) > 0 Then
                        If GUARDA_DET_MOVIMINETO(conexion, _Folio, GrillaDetalle.Rows(fila).Cells(0).Value, CInt(GrillaDetalle.Rows(fila).Cells(4).Value), CInt(GrillaDetalle.Rows(fila).Cells(5).Value), CInt(GrillaDetalle.Rows(fila).Cells(6).Value)) = False Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If

                            Return False
                            Exit Function
                        End If

                        If ACTUALIZA_STOCK_BODEGA(conexion, GLO_BODEGA_RECEPCION, GrillaDetalle.Rows(fila).Cells(0).Value, TIPO_MOVIMIENTO.SALIDA, CInt(GrillaDetalle.Rows(fila).Cells(4).Value)) = False Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If

                            Return False
                            Exit Function
                        End If

                    End If
                    fila = fila + 1
                Loop

                'FIN SALIDA DE BODEGA DE ORIGEN
                '=============================================================

                'ENTRADA A BODEGA DE DESTINO
                '=============================================================
                _Folio = 0
                If GUARDA_ENC_MOVIMINETO(conexion, 0, TIPO_MOVIMIENTO.ENTRADA, GLO_BODEGA_CALIDAD, _fecha, mes, _fecha.Year, GLO_USUARIO_ACTUAL, 0,
                                         COM_TIPO_DOCUMENTO.VALE_DE_INGRESO, 0, _FolioRelacionado, _Observacion, "VTR", CLng(txtNumTraspaso.Text), _Folio) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If ELIMINA_DETALLE_MOVIMIENTO(conexion, _Folio) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                seriePallet = GENERA_PALLET_PARA_SSTT(conexion, rec_codigo, cmbZona.SelectedValue, sumaCantidad)

                fila = 0
                Do While fila <= GrillaDetalle.Rows.Count - 1
                    If GUARDA_DET_MOVIMINETO(conexion, _Folio, GrillaDetalle.Rows(fila).Cells(0).Value, CInt(GrillaDetalle.Rows(fila).Cells(4).Value), CInt(GrillaDetalle.Rows(fila).Cells(5).Value), CInt(GrillaDetalle.Rows(fila).Cells(6).Value)) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If

                        Return False
                        Exit Function
                    End If

                    If ACTUALIZA_STOCK_BODEGA(conexion, GLO_BODEGA_CALIDAD, GrillaDetalle.Rows(fila).Cells(0).Value, TIPO_MOVIMIENTO.ENTRADA, CInt(GrillaDetalle.Rows(fila).Cells(4).Value)) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If

                        Return False
                        Exit Function
                    End If

                    ds = Nothing
                    classRecepcion.rec_numero = rec_codigo
                    classRecepcion.rec_fila = GrillaDetalle.Rows(fila).Cells(7).Value
                    classRecepcion.num_traspaso = CLng(txtNumTraspaso.Text)
                    ds = classRecepcion.RECEPCION_ACTUALIZA_NUMERO_TRASPASO(_msgError, conexion)
                    If _msgError <> "" Then
                        ds = Nothing
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Function
                    Else
                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                            ds = Nothing
                            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Function
                        End If
                    End If


                    If DESCUENTA_CANTIDAD_ULTIMO_PALLET(conexion, GrillaDetalle.Rows(fila).Cells(0).Value, rec_codigo, CInt(GrillaDetalle.Rows(fila).Cells(4).Value), seriePallet) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If

                        Return False
                        Exit Function
                    End If

                    fila = fila + 1
                Loop

                ''FIN ENTRADA A BODEGA DE DESTINO
                ''=============================================================
                'If ELIMINA_UBICACIONES_TEMPORALES(conexion, GLO_USUARIO_ACTUAL) = False Then
                '    If conexion.State = ConnectionState.Open Then
                '        conexion.Close()
                '    End If

                '    Return False
                '    Exit Function
                'End If

                'If ACTUALIZA_ITEM_RECEPCION(conexion, _recNumero, cmbProductos.SelectedValue, CInt(cantidad)) = False Then
                '    If conexion.State = ConnectionState.Open Then
                '        conexion.Close()
                '    End If

                '    Return False
                '    Exit Function
                'End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                GUARDA_MOVIMIENTO = True
                'Call INICIALIZA()
                MessageBox.Show("El movimiento fui ingresado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Dispose()

                'GrillaSerieUbicacion.DataSource = Nothing
                'GrillaSerieUbicacion.Rows.Clear()
            End Using
        Catch ex As Exception
            GUARDA_MOVIMIENTO = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GrillaDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellContentClick

    End Sub

    Private Sub GrillaDetalle_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GrillaDetalle.EditingControlShowing
        If (GrillaDetalle.CurrentCell.ColumnIndex = 4) Then
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
        If (columna = 4) Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar  
                e.KeyChar = Chr(0)
            End If
        End If

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

                        If (columna = 4) Then
                            If (cellTextBox IsNot Nothing) Then
                                With GrillaDetalle
                                    If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                                    ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex - 1, 0)
                                    End If
                                End With
                            End If

                            If GrillaDetalle.Rows(fila).Cells(4).Value > GrillaDetalle.Rows(fila).Cells(3).Value Then
                                MessageBox.Show("La cantidad de muestra no debe ser mayo que la cantidad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                GrillaDetalle.Rows(fila).Cells(4).Value = 0
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

    Private Sub GrillaDetalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles GrillaDetalle.DataError
        e.Cancel = True
    End Sub

    Private Sub ButtonImprime_Click(sender As Object, e As EventArgs) Handles ButtonImprime.Click
        Call IMPREME_MUESTRA()
    End Sub

    Private Sub IMPREME_MUESTRA()
        Try
            Dim frm As frm_imprimir = New frm_imprimir
            frm.Origen = "REM"
            frm.rec_codigo = rec_codigo
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class