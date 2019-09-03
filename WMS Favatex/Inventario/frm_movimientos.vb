Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_movimientos
    Private _cnn As String
    Private _tabSeleccionado As Integer
    Private _sPallet As String = ""
    Private _cantidad As Integer = 0
    Private _sBulto As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_movimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call INICIALIZA()
        _tabSeleccionado = 1
    End Sub

    Private Sub INICIALIZA()
        'TabPage2.Parent = Nothing

        GrillaDetalle.DataSource = Nothing
        GrillaDetalle.Rows.Clear()

        Call CARGA_COMBO_BODEGA_ORIGEN()

        txtFecha.Value = GLO_FECHA_SISTEMA
        txtObservacion.Text = ""
        cmbProductos.DataSource = Nothing
        cmbProductos.Items.Clear()

        txtTotalProducto.Text = "0"
        txtTotalBulto1.Text = "0"
        txtTotalBulto2.Text = "0"
        txtTotalBulto3.Text = "0"
        txtTotalBulto4.Text = "0"
        txtTotalBulto5.Text = "0"
        txtTotalBulto6.Text = "0"
        txtTotalBulto7.Text = "0"
        txtTotalBulto8.Text = "0"

        grillaUbicaciones.DataSource = Nothing
        grillaUbicaciones.Rows.Clear()

        GrillaSerieUbicacion.DataSource = Nothing
        GrillaSerieUbicacion.Rows.Clear()


        'txtOCompra.Text = "0"
        'txtFactura.Text = "0"
        'txtGuia.Text = "0"
        'txtNumRec.Text = "0"
        'txtChofer.Text = "-"
        'txtPatente.Text = "-"
        'txtFecha.Value = GLO_FECHA_SISTEMA
        'txtObservacion.Text = ""

        'txtCodigo.Text = ""
        'txtNombreProducto.Text = ""
        'txtCantidad.Text = "0"

        'cmbProveedor.Enabled = True
        'txtOCompra.Enabled = True
        'ButtonGurdar.Enabled = True

        'ButtonPaletizar.Enabled = False

    End Sub

    Private Sub CARGA_COMBO_PRODUCTOS_DISPONIBLES_POR_BODEGA()
        Dim _msg As String
        Try
            Dim classInv As class_inventario = New class_inventario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classInv.cnn = _cnn
            classInv.bod_codigo = cmbBodegaOrigen.SelectedValue
            _msg = ""
            ds = classInv.PRODUCTOS_PENDIENTES_POR_BODEGA_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbProductos.DataSource = ds.Tables(0)
                Me.cmbProductos.DisplayMember = "MENSAJE"
                Me.cmbProductos.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PRODUCTOS_DISPONIBLES_POR_BODEGA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbBodegaOrigen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbBodegaOrigen.SelectionChangeCommitted
        If cmbBodegaOrigen.SelectedValue > 0 Then
            Call CARGA_COMBO_BODEGA_DESTINO()
            Call CARGA_COMBO_PRODUCTOS_DISPONIBLES_POR_BODEGA()
        End If
    End Sub

    Private Sub CARGA_COMBO_BODEGA_DESTINO()
        Dim _msg As String
        Try
            Dim classBodega As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classBodega.cnn = _cnn
            classBodega.bod_codigo = cmbBodegaOrigen.SelectedValue
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

    Private Sub CARGA_COMBO_BODEGA_ORIGEN()
        Dim _msg As String
        Try
            Dim classBodega As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classBodega.cnn = _cnn
            _msg = ""
            ds = classBodega.BODEGA_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbBodegaOrigen.DataSource = ds.Tables(0)
                Me.cmbBodegaOrigen.DisplayMember = "MENSAJE"
                Me.cmbBodegaOrigen.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_BODEGA_ORIGEN", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_PALLET()
        Dim classInv As class_inventario = New class_inventario
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classInv.cnn = _cnn

            If cmbBodegaOrigen.Text = "" Then
                MessageBox.Show("Debe seleccionar la bodega de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbBodegaOrigen.Focus()
                Exit Sub
            Else
                classInv.bod_codigo = cmbBodegaOrigen.SelectedValue
            End If

            If cmbProductos.Text = "" Then
                MessageBox.Show("Debe seleccionar la un producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbProductos.Focus()
                Exit Sub
            Else
                classInv.pro_codigo = cmbProductos.SelectedValue
            End If

            ds = Nothing
            _msg = ""
            ds = classInv.CANTIDADES_POR_BULTOS_SELECCIONADOS(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("nbulto") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            If ds.Tables(0).Rows(Fila)("nbulto") = 1 Then
                                txtTotalProducto.Text = ds.Tables(0).Rows(Fila)("cantidad")
                                txtTotalBulto1.Text = ds.Tables(0).Rows(Fila)("cantidad")
                            ElseIf ds.Tables(0).Rows(Fila)("nbulto") = 2 Then
                                txtTotalBulto2.Text = ds.Tables(0).Rows(Fila)("cantidad")
                            ElseIf ds.Tables(0).Rows(Fila)("nbulto") = 3 Then
                                txtTotalBulto3.Text = ds.Tables(0).Rows(Fila)("cantidad")
                            ElseIf ds.Tables(0).Rows(Fila)("nbulto") = 4 Then
                                txtTotalBulto4.Text = ds.Tables(0).Rows(Fila)("cantidad")
                            ElseIf ds.Tables(0).Rows(Fila)("nbulto") = 5 Then
                                txtTotalBulto5.Text = ds.Tables(0).Rows(Fila)("cantidad")
                            ElseIf ds.Tables(0).Rows(Fila)("nbulto") = 6 Then
                                txtTotalBulto6.Text = ds.Tables(0).Rows(Fila)("cantidad")
                            ElseIf ds.Tables(0).Rows(Fila)("nbulto") = 7 Then
                                txtTotalBulto7.Text = ds.Tables(0).Rows(Fila)("cantidad")
                            ElseIf ds.Tables(0).Rows(Fila)("nbulto") = 8 Then
                                txtTotalBulto8.Text = ds.Tables(0).Rows(Fila)("cantidad")
                            End If

                            Fila = Fila + 1
                        Loop

                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PALLET", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            'CARGA GRILLA
            Fila = 0
            lblTotal.Text = "Total de pallet: 0"
            _msg = ""
            GrillaDetalle.Rows.Clear()
            ds = Nothing
            ds = classInv.PALLET_POR_PRODUCTOS_SELECCIONADOS(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            False,
                                            ds.Tables(0).Rows(Fila)("prd_palletserie"),
                                            ds.Tables(0).Rows(Fila)("bulto_str"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("disponible"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total de pallet:" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "LISTADO DE FACTURAS POR RENDIR - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PALLET", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PALLET", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        txtTotalProducto.Text = 0
        txtTotalBulto1.Text = 0
        txtTotalBulto2.Text = 0
        txtTotalBulto3.Text = 0
        txtTotalBulto4.Text = 0
        txtTotalBulto5.Text = 0
        txtTotalBulto6.Text = 0
        txtTotalBulto7.Text = 0
        txtTotalBulto8.Text = 0
        Call CARGA_GRILLA_PALLET()
    End Sub

    Private Sub ButtonMarcar_Click(sender As Object, e As EventArgs) Handles ButtonMarcar.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged

    End Sub

    Private Sub cmbProductos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbProductos.SelectionChangeCommitted
        txtTotalProducto.Text = 0
        txtTotalBulto1.Text = 0
        txtTotalBulto2.Text = 0
        txtTotalBulto3.Text = 0
        txtTotalBulto4.Text = 0
        txtTotalBulto5.Text = 0
        txtTotalBulto6.Text = 0
        txtTotalBulto7.Text = 0
        txtTotalBulto8.Text = 0

        GrillaDetalle.DataSource = Nothing
        GrillaDetalle.Rows.Clear()
    End Sub

    Private Sub cmbBodegaDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodegaDestino.SelectedIndexChanged

    End Sub
    Private Sub cmbBodegaDestino_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbBodegaDestino.SelectionChangeCommitted
        'If cmbBodegaDestino.SelectedText <> "" Then
        'Call OBTIENE_SOLICITUD_DE_UBICACION()
        'End If

    End Sub

    'Private Sub OBTIENE_SOLICITUD_DE_UBICACION()
    '    Dim classInv As class_inventario = New class_inventario
    '    Dim Fila As Integer = 0
    '    Dim _msg As String = ""
    '    Try
    '        Dim ds As DataSet = New DataSet

    '        ds = Nothing
    '        classInv.cnn = _cnn
    '        classInv.bod_codigo = cmbBodegaDestino.SelectedValue

    '        ds = classInv.VALIDA_SOLICITUD_DE_UBICACION(_msg)
    '        If _msg = "" Then
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                If ds.Tables(0).Rows(Fila)("bod_solicitaubicacion") = True Then
    '                    'pnlUbicacion.Visible = True
    '                    TabPage2.Parent = TabControl1
    '                Else
    '                    'pnlUbicacion.Visible = False
    '                    'TabPage2.Parent = Nothing
    '                End If
    '            End If
    '        Else
    '            MessageBox.Show(_msg + "\OBTIENE_SOLICITUD_DE_UBICACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message + " " + "OBTIENE_SOLICITUD_DE_UBICACION", MsgBoxStyle.Critical, Me.Text)
    '    End Try
    'End Sub

    Private Sub GrillaDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellContentClick

    End Sub

    Private Sub GrillaDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellEnter
        Me.Cursor = Cursors.WaitCursor
        _sPallet = GrillaDetalle.Rows(e.RowIndex).Cells(2).Value
        _cantidad = GrillaDetalle.Rows(e.RowIndex).Cells(5).Value
        _sBulto = CInt(Mid(GrillaDetalle.Rows(e.RowIndex).Cells(3).Value, 1, 2))

        Call CARGA_GRILLA_UBICACIONES(GrillaDetalle.Rows(e.RowIndex).Cells(2).Value)

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

            _msg = ""
            grillaUbicaciones.Rows.Clear()
            ds = classInv.UBICACIONES_DISPONIBLE_SELECCIONADOS(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("ubi_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaUbicaciones.Rows.Add(ds.Tables(0).Rows(Fila)("ubi_codigo"),
                                            False,
                                            ds.Tables(0).Rows(Fila)("zon_nombre"),
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

    Private Sub grillaUbicaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaUbicaciones.CellContentClick
        Dim codRelacionado As Integer = 0
        Dim fila As Integer = 0
        Dim valorMarcado As Boolean = False

        Try
            If e.ColumnIndex = Me.grillaUbicaciones.Columns.Item(1).Index Then
                Dim chkCell As DataGridViewCheckBoxCell = Me.grillaUbicaciones.Rows(e.RowIndex).Cells(1)
                'chkCell.Value = Not chkCell.Value
                chkCell.Value = chkCell.Value
                valorMarcado = chkCell.Value
            End If

            If e.ColumnIndex = 4 Then
                If grillaUbicaciones.Rows(e.RowIndex).Cells(1).Value = True Then
                    Call GUARDA_ASIGNACION_TEMPORAL()
                    'Call CARGA_GRILLA_PALLET()
                    Call CARGA_GRILLA_SERIE_UBICACIONES()
                    Call CalculaBultos()
                End If

            End If

            Call DESABILITA_MARCADOS()

            grillaUbicaciones.Rows(e.RowIndex).Cells(1).Value = valorMarcado

            If grillaUbicaciones.Rows(e.RowIndex).Cells(1).Value = True Then

                codRelacionado = grillaUbicaciones.Rows(e.RowIndex).Cells(5).Value
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

    Private Sub CalculaBultos()
        Dim fila As Integer = 0
        Dim totBulto1 As Integer = 0
        Dim totBulto2 As Integer = 0
        Dim totBulto3 As Integer = 0
        Dim totBulto4 As Integer = 0
        Dim totBulto5 As Integer = 0
        Dim totBulto6 As Integer = 0
        Dim totBulto7 As Integer = 0
        Dim totBulto8 As Integer = 0

        Try
            Do While fila <= GrillaSerieUbicacion.RowCount - 1
                If GrillaSerieUbicacion.Rows(fila).Cells(4).Value = 1 Then
                    totBulto1 = totBulto1 + GrillaSerieUbicacion.Rows(fila).Cells(2).Value
                ElseIf GrillaSerieUbicacion.Rows(fila).Cells(4).Value = 2 Then
                    totBulto2 = totBulto2 + GrillaSerieUbicacion.Rows(fila).Cells(2).Value
                ElseIf GrillaSerieUbicacion.Rows(fila).Cells(4).Value = 3 Then
                    totBulto3 = totBulto3 + GrillaSerieUbicacion.Rows(fila).Cells(2).Value
                ElseIf GrillaSerieUbicacion.Rows(fila).Cells(4).Value = 4 Then
                    totBulto4 = totBulto4 + GrillaSerieUbicacion.Rows(fila).Cells(2).Value
                ElseIf GrillaSerieUbicacion.Rows(fila).Cells(4).Value = 5 Then
                    totBulto5 = totBulto5 + GrillaSerieUbicacion.Rows(fila).Cells(2).Value
                ElseIf GrillaSerieUbicacion.Rows(fila).Cells(4).Value = 6 Then
                    totBulto6 = totBulto6 + GrillaSerieUbicacion.Rows(fila).Cells(2).Value
                ElseIf GrillaSerieUbicacion.Rows(fila).Cells(4).Value = 7 Then
                    totBulto8 = totBulto8 + GrillaSerieUbicacion.Rows(fila).Cells(2).Value
                ElseIf GrillaSerieUbicacion.Rows(fila).Cells(4).Value = 8 Then
                    totBulto8 = totBulto8 + GrillaSerieUbicacion.Rows(fila).Cells(2).Value
                End If
                fila = fila + 1
            Loop

            If totBulto1 > 0 Then
                txtTotalBulto1.Text = CInt(txtTotalProducto.Text) - totBulto1
            End If

            If totBulto2 > 0 Then
                txtTotalBulto2.Text = CInt(txtTotalProducto.Text) - totBulto2
            End If

            If totBulto3 > 0 Then
                txtTotalBulto3.Text = CInt(txtTotalProducto.Text) - totBulto3
            End If

            If totBulto4 > 0 Then
                txtTotalBulto4.Text = CInt(txtTotalProducto.Text) - totBulto4
            End If

            If totBulto5 > 0 Then
                txtTotalBulto5.Text = CInt(txtTotalProducto.Text) - totBulto5
            End If

            If totBulto6 > 0 Then
                txtTotalBulto6.Text = CInt(txtTotalProducto.Text) - totBulto6
            End If

            If totBulto7 > 0 Then
                txtTotalBulto7.Text = CInt(txtTotalProducto.Text) - totBulto7
            End If

            If totBulto8 > 0 Then
                txtTotalBulto8.Text = CInt(txtTotalProducto.Text) - totBulto8
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


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

    Private Sub grillaUbicaciones_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles grillaUbicaciones.CurrentCellDirtyStateChanged
        If grillaUbicaciones.IsCurrentCellDirty Then
            grillaUbicaciones.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub GrillaSerieUbicacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaSerieUbicacion.CellContentClick
        Dim respuesta As Integer = 0
        If e.ColumnIndex = 5 Then
            'Me.GrillaSerieUbicacion.Rows.Remove(Me.GrillaSerieUbicacion.CurrentRow)
            Call ELIMINA_MOVIMIENTO_TEMP(GrillaSerieUbicacion.Rows(e.RowIndex).Cells(1).Value)
            Call CARGA_GRILLA_SERIE_UBICACIONES()
            Call CalculaBultos()

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

    Private Sub ButtonGrabar_Click(sender As Object, e As EventArgs) Handles ButtonGrabar.Click
        Call GUARDA_MOVIMIENTO()
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
        GUARDA_MOVIMIENTO = False
        Try
            _numCantidadBultos = OBTIENE_NUMERO_BULTOS(cmbProductos.SelectedValue)

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                _fecha = txtFecha.Value

                If CStr(_fecha.Month).Length = 1 Then
                    mes = Trim("0" + CStr(_fecha.Month))
                Else
                    mes = CStr(_fecha.Month)
                End If



                'SALIDA DE BODEGA DE ORIGEN
                '=============================================================
                If GUARDA_ENC_MOVIMINETO(conexion, 0, TIPO_MOVIMIENTO.SALIDA, cmbBodegaOrigen.SelectedValue, txtFecha.Value, mes, _fecha.Year, GLO_USUARIO_ACTUAL, 0,
                                         COM_TIPO_DOCUMENTO.VALE_DE_SALIDA, 0, 0, txtObservacion.Text, "-", 0, _Folio) = False Then
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

                fila = 0
                Do While fila <= GrillaSerieUbicacion.Rows.Count - 1
                    If MARCA_SERIE_MOVIMIENTO(conexion, "-", GrillaSerieUbicacion.Rows(fila).Cells(1).Value, cmbBodegaOrigen.SelectedValue) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If

                        Return False
                        Exit Function
                    End If

                    If GUARDA_PRODUCTO_SERIE_MOVIMIENTO(conexion, "-", GrillaSerieUbicacion.Rows(fila).Cells(1).Value, cmbBodegaOrigen.SelectedValue,
                                                        _Folio, GLO_USUARIO_ACTUAL, "TRASPASO A TRAVEZ DEL MOVIMIENTO: " + _Folio.ToString, "S",
                                                        cmbProductos.SelectedValue, 0) = False Then

                    End If
                    fila = fila + 1
                Loop

                If _numCantidadBultos = 0 Then
                    MessageBox.Show("La cantidad de bultos del producto, no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If GUARDA_DET_MOVIMINETO(conexion, _Folio, cmbProductos.SelectedValue, CInt(txtTotalProducto.Text), _numCantidadBultos, (CInt(txtTotalProducto.Text) * _numCantidadBultos)) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If ACTUALIZA_STOCK_BODEGA(conexion, cmbBodegaOrigen.SelectedValue, cmbProductos.SelectedValue, TIPO_MOVIMIENTO.SALIDA, CInt(txtTotalProducto.Text)) = False Then
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
                If GUARDA_ENC_MOVIMINETO(conexion, 0, TIPO_MOVIMIENTO.ENTRADA, cmbBodegaDestino.SelectedValue, txtFecha.Value, mes, _fecha.Year, GLO_USUARIO_ACTUAL, 0,
                                         COM_TIPO_DOCUMENTO.VALE_DE_INGRESO, 0, _FolioRelacionado, txtObservacion.Text, "-", 0, _Folio) = False Then
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

                fila = 0
                Do While fila <= GrillaSerieUbicacion.Rows.Count - 1
                    If GUARDA_PRODUCTO_SERIE_MOVIMIENTO(conexion, "-", GrillaSerieUbicacion.Rows(fila).Cells(1).Value, cmbBodegaOrigen.SelectedValue,
                                                        _Folio, GLO_USUARIO_ACTUAL, "TRASPASO A TRAVEZ DEL MOVIMIENTO: " + _Folio.ToString, "E",
                                                        cmbProductos.SelectedValue, cmbBodegaDestino.SelectedValue) = False Then

                    End If
                    fila = fila + 1
                Loop

                If _numCantidadBultos = 0 Then
                    MessageBox.Show("La cantidad de bultos del producto, no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If GUARDA_DET_MOVIMINETO(conexion, _Folio, cmbProductos.SelectedValue, CInt(txtTotalProducto.Text), _numCantidadBultos, (CInt(txtTotalProducto.Text) * _numCantidadBultos)) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                If ACTUALIZA_STOCK_BODEGA(conexion, cmbBodegaDestino.SelectedValue, cmbProductos.SelectedValue, TIPO_MOVIMIENTO.ENTRADA, CInt(txtTotalProducto.Text)) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    Return False
                    Exit Function
                End If

                'FIN ENTRADA A BODEGA DE DESTINO
                '=============================================================
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                GUARDA_MOVIMIENTO = True
                Call INICIALIZA()
                MessageBox.Show("El movimiento fui ingresado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            GUARDA_MOVIMIENTO = False
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

    Private Sub cmbBodegaOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodegaOrigen.SelectedIndexChanged

    End Sub
End Class