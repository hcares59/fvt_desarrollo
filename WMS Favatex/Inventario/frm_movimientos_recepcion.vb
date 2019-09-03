Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_movimientos_recepcion
    Private _cnn As String = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
    Private _recNumero As Integer
    Private _sPallet As String = ""
    Private _cantidad As Integer = 0
    Private _sBulto As Integer
    Private _Observacion As String = ""

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
    Public Property recNumero() As String
        Get
            Return _recNumero
        End Get
        Set(ByVal value As String)
            _recNumero = value
        End Set
    End Property
    Private Sub frm_movimientos_recepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GLO_USUARIO_ACTUAL = 6
        txtNumero.Text = _recNumero
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        cmbZona.DataSource = Nothing
        cmbZona.Items.Clear()

        GrillaDetalle.DataSource = Nothing
        GrillaDetalle.Rows.Clear()


        Call CARGA_COMBO_PRODUCTOS_RECEPCION()
        Call CARGA_COMBO_BODEGA_DESTINO()
    End Sub

    Private Sub CARGA_COMBO_PRODUCTOS_RECEPCION()
        Dim _msg As String
        Try
            Dim classRecepcion As class_recepcion = New class_recepcion
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _recNumero
            _msg = ""
            ds = classRecepcion.PRODUCTOS_RECEPCION_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbProductos.DataSource = ds.Tables(0)
                Me.cmbProductos.DisplayMember = "MENSAJE"
                Me.cmbProductos.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PRODUCTOS_RECEPCION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_BODEGA_DESTINO()
        Dim _msg As String
        Try
            Dim classBodega As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classBodega.cnn = _cnn
            classBodega.bod_codigo = GLO_BODEGA_RECEPCION
            _msg = ""
            ds = classBodega.BODEGA_DESTINO_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbBodegaDestino.DataSource = ds.Tables(0)
                Me.cmbBodegaDestino.DisplayMember = "MENSAJE"
                Me.cmbBodegaDestino.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_BODEGA_DESTINO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbBodegaDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodegaDestino.SelectedIndexChanged

    End Sub

    Private Sub cmbBodegaDestino_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbBodegaDestino.SelectionChangeCommitted
        If (cmbProductos.SelectedValue > 0) And (cmbBodegaDestino.SelectedValue > 0) Then
            If VERIFICA_PRODUCTO_EN_BODEGA(_cnn, cmbBodegaDestino.SelectedValue, cmbProductos.SelectedValue) = False Then
                MessageBox.Show("El producto no esta asociado a la bodega seleccionada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbBodegaDestino.SelectedValue = 0
                Exit Sub
            End If
        End If

        Call CARGA_COMBO_ZONA_POR_BODEGA()
        Call CARGA_GRILLA_PALLET()
        Call CARGA_GRILLA_UBICACIONES(_sPallet)
    End Sub

    Private Sub CARGA_COMBO_ZONA_POR_BODEGA()
        Dim _msg As String
        Try
            Dim classZona As class_zonas = New class_zonas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classZona.cnn = _cnn
            classZona.bod_codigo = cmbBodegaDestino.SelectedValue

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

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged

    End Sub

    Private Sub cmbProductos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbProductos.SelectionChangeCommitted
        If (cmbProductos.SelectedValue > 0) And (cmbBodegaDestino.SelectedValue > 0) Then
            If VERIFICA_PRODUCTO_EN_BODEGA(_cnn, cmbBodegaDestino.SelectedValue, cmbProductos.SelectedValue) = False Then
                MessageBox.Show("El producto no esta asociado a la bodega seleccionada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbBodegaDestino.SelectedValue = 0
                Exit Sub
            End If
        End If

        Call CARGA_GRILLA_BULTOS()
        'Call CARGA_GRILLA_PALLET()
        Call CARGA_GRILLA_UBICACIONES(_sPallet)
    End Sub

    Private Sub CARGA_GRILLA_PALLET()
        Dim classInv As class_inventario = New class_inventario
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classInv.cnn = _cnn

            'CARGA GRILLA
            Fila = 0
            _msg = ""
            grillaPallet.Rows.Clear()
            ds = Nothing
            classInv.rec_codigo = _recNumero
            classInv.pro_codigo = cmbProductos.SelectedValue
            classInv.bod_codigo = cmbBodegaDestino.SelectedValue
            ds = classInv.PALLET_POR_PRODUCTOS_SELECCIONADOS(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaPallet.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            False,
                                            ds.Tables(0).Rows(Fila)("prd_palletserie"),
                                            ds.Tables(0).Rows(Fila)("bulto_str"),
                                            ds.Tables(0).Rows(Fila)("disponible"),
                                            ds.Tables(0).Rows(Fila)("nbulto"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PALLET", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PALLET", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub CARGA_GRILLA_BULTOS()
        Dim classRec As class_recepcion = New class_recepcion
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classRec.cnn = _cnn
            classRec.rec_numero = _recNumero
            classRec.pro_codigo = cmbProductos.SelectedValue

            Fila = 0

            _msg = ""
            GrillaDetalle.Rows.Clear()
            ds = Nothing
            ds = classRec.BULTOS_MOV_RECEPCION_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        txtCantidad.Text = ds.Tables(0).Rows(Fila)("cantidad")
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("bulto_string"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("cant_recep"),
                                            (ds.Tables(0).Rows(Fila)("cantidad") - ds.Tables(0).Rows(Fila)("cant_recep")),
                                            ds.Tables(0).Rows(Fila)("num_bulto"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_BULTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_BULTOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub grillaPallet_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grillaPallet.CellEnter
        _sPallet = grillaPallet.Rows(e.RowIndex).Cells(2).Value
        _cantidad = grillaPallet.Rows(e.RowIndex).Cells(4).Value
        _sBulto = grillaPallet.Rows(e.RowIndex).Cells(5).Value ' CInt(Mid(GrillaDetalle.Rows(e.RowIndex).Cells(3).Value, 1, 2))

        'If cmbBodegaDestino.SelectedValue = 0 Then
        '    MessageBox.Show("Debe seleccionar una bodega de destino", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cmbBodegaDestino.Focus()
        '    Exit Sub
        'End If

        'If cmbZona.SelectedValue = 0 Then
        '    MessageBox.Show("Debe seleccionar una zona", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cmbZona.Focus()
        '    Exit Sub
        'End If


        Call CARGA_GRILLA_UBICACIONES(_sPallet)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CARGA_GRILLA_UBICACIONES(ByVal seriePallet As String)
        Dim classInv As class_inventario = New class_inventario
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classInv.cnn = _cnn
            classInv.serie_pallet = seriePallet
            classInv.bod_codigo = cmbBodegaDestino.SelectedValue
            classInv.zon_codigo = cmbZona.SelectedValue
            _msg = ""
            grillaUbicaciones.Rows.Clear()
            ds = classInv.UBICACIONES_DISPONIBLE_SELECCIONADOS(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("ubi_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaUbicaciones.Rows.Add(ds.Tables(0).Rows(Fila)("ubi_codigo"),
                                            False,
                                            ds.Tables(0).Rows(Fila)("ubi_nombre"),
                                            "",
                                            ds.Tables(0).Rows(Fila)("ubi_relacionada"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PALLET", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PALLET", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbZona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbZona.SelectedIndexChanged

    End Sub

    Private Sub cmbZona_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbZona.SelectionChangeCommitted
        Call CARGA_GRILLA_PALLET()
        Call CARGA_GRILLA_UBICACIONES(_sPallet)
    End Sub

    Private Sub grillaUbicaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaUbicaciones.CellContentClick
        Dim codRelacionado As Integer = 0
        Dim fila As Integer = 0
        Dim valorMarcado As Boolean = False

        Try
            If e.ColumnIndex = Me.grillaUbicaciones.Columns.Item(1).Index Then
                Dim chkCell As DataGridViewCheckBoxCell = Me.grillaUbicaciones.Rows(e.RowIndex).Cells(1)
                'chkCell.Value = Not chkCell.Value
                chkCell.Value = Not chkCell.Value
                valorMarcado = chkCell.Value
            End If

            If e.ColumnIndex = 3 Then
                If grillaUbicaciones.Rows(e.RowIndex).Cells(1).Value = True Then
                    Call GUARDA_ASIGNACION_TEMPORAL()
                    'Call CARGA_GRILLA_PALLET()
                    Call CARGA_GRILLA_SERIE_UBICACIONES()
                    Call RECALCULA_BULTOS()
                    'Call CalculaBultos()
                End If

            End If

            Call DESABILITA_MARCADOS()

            grillaUbicaciones.Rows(e.RowIndex).Cells(1).Value = valorMarcado

            If grillaUbicaciones.Rows(e.RowIndex).Cells(1).Value = True Then

                codRelacionado = grillaUbicaciones.Rows(e.RowIndex).Cells(4).Value
                grillaUbicaciones.Item(1, e.RowIndex).Style.BackColor = Color.FromArgb(206, 239, 206)
                grillaUbicaciones.Item(2, e.RowIndex).Style.BackColor = Color.FromArgb(206, 239, 206)
                grillaUbicaciones.Item(3, e.RowIndex).Style.BackColor = Color.FromArgb(206, 239, 206)

                grillaUbicaciones.Item(1, e.RowIndex).Style.SelectionBackColor = Color.FromArgb(206, 239, 206)
                grillaUbicaciones.Item(2, e.RowIndex).Style.SelectionBackColor = Color.FromArgb(206, 239, 206)
                grillaUbicaciones.Item(3, e.RowIndex).Style.SelectionBackColor = Color.FromArgb(206, 239, 206)

                ' MessageBox.Show(codRelacionado)
                If Mid(_sPallet, 1, 2) = "PD" Then
                    If codRelacionado > 0 Then
                        Do While fila <= grillaUbicaciones.Rows.Count - 1
                            If grillaUbicaciones.Rows(fila).Cells(0).Value = codRelacionado Then
                                grillaUbicaciones.Rows(fila).Cells(1).Value = True
                                grillaUbicaciones.Item(1, fila).Style.BackColor = Color.FromArgb(206, 239, 206)
                                grillaUbicaciones.Item(2, fila).Style.BackColor = Color.FromArgb(206, 239, 206)
                                grillaUbicaciones.Item(3, fila).Style.BackColor = Color.FromArgb(206, 239, 206)
                            End If
                            fila = fila + 1
                        Loop
                    End If
                End If
            ElseIf grillaUbicaciones.Rows(e.RowIndex).Cells(1).Value = False Then
                Call DESABILITA_MARCADOS()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RECALCULA_BULTOS()
        Dim fila As Integer = 0
        Dim fila2 As Integer = 0
        Dim subTotal As Integer = 0

        Do While fila <= GrillaDetalle.RowCount - 1
            fila2 = 0
            subTotal = 0
            Do While fila2 <= GrillaSerieUbicacion.RowCount - 1
                If GrillaSerieUbicacion.Rows(fila2).Cells(4).Value = GrillaDetalle.Rows(fila).Cells(5).Value Then
                    subTotal = subTotal + CInt(GrillaSerieUbicacion.Rows(fila2).Cells(2).Value)
                End If
                fila2 = fila2 + 1
            Loop
            GrillaDetalle.Rows(fila).Cells(3).Value = subTotal
            GrillaDetalle.Rows(fila).Cells(4).Value = CInt(GrillaDetalle.Rows(fila).Cells(2).Value) - CInt(GrillaDetalle.Rows(fila).Cells(3).Value)
            fila = fila + 1
        Loop
    End Sub

    Private Sub CARGA_GRILLA_SERIE_UBICACIONES()
        Dim classInv As class_inventario = New class_inventario
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classInv.cnn = _cnn
            classInv.usu_codigo = GLO_USUARIO_ACTUAL

            _msg = ""
            GrillaSerieUbicacion.Rows.Clear()
            ds = classInv.SERIES_UBICACIONES_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("usu_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaSerieUbicacion.Rows.Add(ds.Tables(0).Rows(Fila)("usu_codigo"),
                                            ds.Tables(0).Rows(Fila)("serie"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("ubi_nombres"),
                                            ds.Tables(0).Rows(Fila)("bulto"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_SERIE_UBICACIONES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_SERIE_UBICACIONES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub GUARDA_ASIGNACION_TEMPORAL()
        Dim classInventario As class_inventario = New class_inventario
        Dim fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim dsDetalle As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classInventario.usu_codigo = GLO_USUARIO_ACTUAL
                classInventario.serie_pallet = _sPallet
                classInventario.cantidad = _cantidad
                classInventario.bulto = _sBulto

                ds = classInventario.MOVIMIENTOS_TEMP_ENC_GUARDAR(_msgError, conexion)
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

                Do While fila <= grillaUbicaciones.Rows.Count - 1
                    If grillaUbicaciones.Rows(fila).Cells(1).Value = True Then
                        classInventario.usu_codigo = GLO_USUARIO_ACTUAL
                        classInventario.serie_pallet = _sPallet
                        classInventario.ubi_codigo = grillaUbicaciones.Rows(fila).Cells(0).Value

                        dsDetalle = Nothing
                        dsDetalle = classInventario.MOVIMIENTOS_TEMP_DET_GUARDAR(_msgError, conexion)
                        If _msgError <> "" Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If

                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dsDetalle = Nothing
                            Exit Sub
                        Else
                            If dsDetalle.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If

                                MessageBox.Show(dsDetalle.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                dsDetalle = Nothing
                                Exit Sub
                            End If
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

                Call CARGA_GRILLA_PALLET()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DESABILITA_MARCADOS()
        Dim fila As Integer = 0
        Try
            Do While fila <= grillaUbicaciones.Rows.Count - 1
                grillaUbicaciones.Rows(fila).Cells(1).Value = False
                grillaUbicaciones.Item(1, fila).Style.BackColor = Color.White
                grillaUbicaciones.Item(2, fila).Style.BackColor = Color.White
                grillaUbicaciones.Item(3, fila).Style.BackColor = Color.White

                grillaUbicaciones.Item(1, fila).Style.SelectionBackColor = Color.White
                grillaUbicaciones.Item(2, fila).Style.SelectionBackColor = Color.White
                grillaUbicaciones.Item(3, fila).Style.SelectionBackColor = Color.White


                fila = fila + 1
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrillaSerieUbicacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaSerieUbicacion.CellContentClick
        Dim respuesta As Integer = 0
        If e.ColumnIndex = 5 Then
            'Me.GrillaSerieUbicacion.Rows.Remove(Me.GrillaSerieUbicacion.CurrentRow)
            Call ELIMINA_MOVIMIENTO_TEMP(GrillaSerieUbicacion.Rows(e.RowIndex).Cells(1).Value)
            Call CARGA_GRILLA_SERIE_UBICACIONES()
            Call RECALCULA_BULTOS()
            'Call CalculaBultos()
        End If
    End Sub

    Private Sub ELIMINA_MOVIMIENTO_TEMP(ByVal serie As String)
        Dim classInv As class_inventario = New class_inventario
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classInv.usu_codigo = GLO_USUARIO_ACTUAL
                classInv.serie_pallet = serie

                ds = classInv.MOVIMIENTOS_TEMP_ENC_ELIMINA(_msgError, conexion)
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
                ds = classInv.MOVIMIENTOS_TEMP_DET_ELIMINA(_msgError, conexion)
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

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

            End Using

            Call CARGA_GRILLA_PALLET()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
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

        GUARDA_MOVIMIENTO = False

        Try
            _Observacion = "MOVIMIENTO GENERADO A TRAVEZ DE LA RECEPCIÓN NUMERO: " + _recNumero.ToString
            _numCantidadBultos = OBTIENE_NUMERO_BULTOS(cmbProductos.SelectedValue)

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                _fecha = GLO_FECHA_SISTEMA

                If CStr(_fecha.Month).Length = 1 Then
                    mes = Trim("0" + CStr(_fecha.Month))
                Else
                    mes = CStr(_fecha.Month)
                End If

                cantidad = OBTIENE_CANTIDAD()

                If cantidad < 0 Then
                    Exit Function
                End If

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

                If ACTULIZA_UBICACION_DEL_PALLET(conexion, GLO_USUARIO_ACTUAL) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If _numCantidadBultos = 0 Then
                    MessageBox.Show("La cantidad de bultos del producto, no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If GUARDA_DET_MOVIMINETO(conexion, _Folio, cmbProductos.SelectedValue, CInt(cantidad), _numCantidadBultos, (CInt(cantidad) * _numCantidadBultos)) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If ACTUALIZA_STOCK_BODEGA(conexion, GLO_BODEGA_RECEPCION, cmbProductos.SelectedValue, TIPO_MOVIMIENTO.SALIDA, CInt(cantidad)) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If
                'FIN SALIDA DE BODEGA DE ORIGEN
                '=============================================================

                'ENTRADA A BODEGA DE DESTINO
                '=============================================================
                _Folio = 0
                If GUARDA_ENC_MOVIMINETO(conexion, 0, TIPO_MOVIMIENTO.ENTRADA, cmbBodegaDestino.SelectedValue, _fecha, mes, _fecha.Year, GLO_USUARIO_ACTUAL, 0,
                                         COM_TIPO_DOCUMENTO.VALE_DE_INGRESO, 0, _FolioRelacionado, _Observacion, "-", 0, _Folio) = False Then
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

                If _numCantidadBultos = 0 Then
                    MessageBox.Show("La cantidad de bultos del producto, no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If GUARDA_DET_MOVIMINETO(conexion, _Folio, cmbProductos.SelectedValue, CInt(cantidad), _numCantidadBultos, (CInt(cantidad) * _numCantidadBultos)) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If ACTUALIZA_STOCK_BODEGA(conexion, cmbBodegaDestino.SelectedValue, cmbProductos.SelectedValue, TIPO_MOVIMIENTO.ENTRADA, CInt(cantidad)) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                'FIN ENTRADA A BODEGA DE DESTINO
                '=============================================================
                If ELIMINA_UBICACIONES_TEMPORALES(conexion, GLO_USUARIO_ACTUAL) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If ACTUALIZA_ITEM_RECEPCION(conexion, _recNumero, cmbProductos.SelectedValue, CInt(cantidad)) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                GUARDA_MOVIMIENTO = True
                Call INICIALIZA()
                MessageBox.Show("El movimiento fui ingresado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                GrillaSerieUbicacion.DataSource = Nothing
                GrillaSerieUbicacion.Rows.Clear()
            End Using
        Catch ex As Exception
            GUARDA_MOVIMIENTO = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function OBTIENE_CANTIDAD() As Integer
        Dim fila As Integer = 0
        Dim suma As Integer = 0

        Try
            OBTIENE_CANTIDAD = 0
            Do While fila <= GrillaSerieUbicacion.RowCount - 1
                suma = suma + GrillaSerieUbicacion.Rows(fila).Cells(2).Value
                fila = fila + 1
            Loop
            OBTIENE_CANTIDAD = suma
        Catch ex As Exception
            OBTIENE_CANTIDAD = -1
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Function


    Private Function OBTIENE_NUMERO_BULTOS(ByVal pro_codigo As Integer) As Integer
        Dim classProducto As class_producto = New class_producto
        Dim msgError As String = ""
        Dim ds As DataSet = New DataSet
        Try
            OBTIENE_NUMERO_BULTOS = 0
            classProducto.cnn = _cnn
            classProducto.pro_codigo = pro_codigo
            ds = classProducto.PRODUCTOS_BUSQUEDA(msgError)
            If msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    OBTIENE_NUMERO_BULTOS = ds.Tables(0).Rows(0)("pro_numerobulto")
                End If
            Else
                MessageBox.Show(msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            OBTIENE_NUMERO_BULTOS = 0
        End Try
    End Function

    Private Sub ButtonGrabar_Click(sender As Object, e As EventArgs) Handles ButtonGrabar.Click
        Call GUARDA_MOVIMIENTO()
    End Sub

    Private Sub grillaPallet_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaPallet.CellContentClick

    End Sub
End Class