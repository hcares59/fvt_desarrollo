Imports DevComponents.DotNetBar
Imports DevComponents

Public Class frmNewDesktop

    Dim dtTree As DataTable = New DataTable
    Dim NodeRightClick As String
    Dim Modulo As String = ""

    ''SERVIDOR PRODUCCION
    Dim pubServidor As String = "192.168.1.8\POSEIDONSQL"
    Dim pubBaseDato As String = "APPFVT_01"
    Dim pubUsuario As String = "sa"
    Dim pubContrasena As String = "S1nc0ntr4s3n4db4.2017"

    Private _cnn As String = "Data Source=" + pubServidor + ";Initial Catalog=" + pubBaseDato + ";User ID=" + pubUsuario + ";Password=" + pubContrasena


    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub picH_Click(sender As Object, e As EventArgs) Handles picH.Click
        picD.Visible = True
        picH.Visible = False
        lblMenu.Text = "Mostrar menú"
        PanelMenu.Width = 10 ' 234
    End Sub

    Private Sub picD_Click(sender As Object, e As EventArgs) Handles picD.Click
        picH.Visible = True
        picD.Visible = False
        lblMenu.Text = "Contraer menú"
        PanelMenu.Width = 234 '10
    End Sub

    Private Sub frmNewDesktop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picH.Visible = True
        picD.Visible = False
        lblMenu.Text = "Contraer menú"
        PanelMenu.Width = 234
        Modulo = " LOGISTICA "
        FillTestTable(1)
        CreateTree()
        TreeMenu.ExpandAll()

        lblModulo.Text = "MODULO" + Modulo + "ACTIVO"

    End Sub


    Private Sub FillTestTable(ByVal modCodigo As Integer)
        Dim menu As class_menu = New class_menu
        Dim Msg As String = ""

        Dim i As Integer
        Try
            menu.cnn = _cnn
            menu.mod_codigo = modCodigo
            menu.usu_codigo = 6 'GLO_USUARIO_ACTUAL
            dtTree = menu.USUARIO_BUSCA_MENU_NEW(Msg)
            If dtTree.Rows(i).Item("men_nombre").ToString = "" Then
                Exit Sub
            End If

            For i = 0 To dtTree.Rows.Count - 1
                Dim ID1 As String = dtTree.Rows(i).Item("men_codigo").ToString
                dtTree.Rows(i).Item("LEVEL") = FindLevel(ID1, 0)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function FindLevel(ByVal ID As String, ByRef Level As Integer) As Integer
        Dim i As Integer

        For i = 0 To dtTree.Rows.Count - 1
            Dim ID1 As String = dtTree.Rows(i).Item("men_codigo").ToString
            Dim Parent1 As String = dtTree.Rows(i).Item("men_codigopadre").ToString

            If ID = ID1 Then
                If Parent1 = "" Then
                    Return Level
                Else
                    Level += 1
                    FindLevel(Parent1, Level)
                End If
            End If
        Next

        Return Level
    End Function

    Private Sub CreateTree()
        Dim MaxLevel1 As Integer = CInt(dtTree.Compute("MAX(LEVEL)", ""))

        Dim i, j As Integer

        For i = 0 To MaxLevel1
            Dim Rows1() As DataRow = dtTree.Select("LEVEL = " & i)

            For j = 0 To Rows1.Count - 1
                Dim ID1 As String = Rows1(j).Item("men_codigo").ToString
                Dim Name1 As String = Rows1(j).Item("men_nombre").ToString
                Dim Parent1 As String = Rows1(j).Item("men_codigopadre").ToString
                'Dim icono As String = Rows1(j).Item("men_icono").ToString

                If Parent1 = "0" Then
                    TreeMenu.Nodes.Add(ID1, Name1, 0, 0)
                Else
                    Dim TreeNodes1() As TreeNode = TreeMenu.Nodes.Find(Parent1, True)

                    If TreeNodes1.Length > 0 Then
                        TreeNodes1(0).Nodes.Add(ID1, Name1, 1, 1)
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub TreeMenu_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeMenu.AfterSelect
        Call ABRE_APLICACION(TreeMenu.SelectedNode.Name)
        TreeMenu.SelectedNode = TreeMenu.Nodes(0)
    End Sub

    Private Sub ABRE_APLICACION(ByVal codMenu As Integer)
        Dim class_menu As class_menu = New class_menu
        Dim _msg As String = ""
        Dim ds As DataSet

        Dim classComunes As class_comunes = New class_comunes

        Try
            class_menu.cnn = _cnn
            class_menu.men_codigo = codMenu
            ds = class_menu.MENU_SELECCIONA_APLICACION_NEW(_msg)
            If _msg = "" Then
                Try
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("men_codigopadre") = 0 Then
                            ds = Nothing
                            Exit Sub
                        End If

                        'MODULO LOGISTICA
                        '------------------------------
                        If ds.Tables(0).Rows(0)("men_urlpagina") = "frm_listado_areas" Then
                            Dim frm As frm_listado_areas = New frm_listado_areas
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "frm_listado_tipo_devolucion" Then
                            Dim frm As frm_listado_tipo_devolucion = New frm_listado_tipo_devolucion
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraPickingVentaVerde" Then
                            Dim frm As frm_picking_sugerido = New frm_picking_sugerido
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "OrdenesCompraCliente" Then
                            Dim frm As frm_orden_compra = New frm_orden_compra
                            frm.cnn = _cnn
                            classComunes.OpenSubForm(frm)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraciónAgenda" Then
                            Dim frm As frm_ingreso_agenda = New frm_ingreso_agenda
                            frm.cnn = _cnn
                            classComunes.OpenSubForm(frm)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraPickingAtravesAgenda" Then
                            Dim frm As frm_picking_por_agenda = New frm_picking_por_agenda
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "PickingPendientesDespacho" Then
                            Dim frm As frm_visor_despacho = New frm_visor_despacho
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "PickingPendientesFacturación" Then
                            Dim frm As frm_visor_facturacion_picking = New frm_visor_facturacion_picking
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ModificaFactura" Then
                            Dim frm As frm_visor_modificacion_facturavb = New frm_visor_modificacion_facturavb
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ModificaGuia" Then
                            Dim frm As frm_visor_modificacion_guias = New frm_visor_modificacion_guias
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GuiasPendientesFacturación" Then
                            Dim frm As frm_visor_facturacion_guias = New frm_visor_facturacion_guias
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RevisionFacturasRendidas" Then
                            Dim frm As frm_validacion_facturas = New frm_validacion_facturas
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RegistraCobroFactura" Then
                            Dim frm As frm_cobro_facturas = New frm_cobro_facturas
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "BusquedaPicking" Then
                            Dim frm As frm_listado_picking = New frm_listado_picking
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "BusquedaDeAgenda" Then
                            Dim frm As frm_listado_agenda = New frm_listado_agenda
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "CertificadoConformidad" Then
                            Dim frm As frm_certificado_recepcion_conforme = New frm_certificado_recepcion_conforme
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ImpresionEtiqueta" Then
                            Dim frm As frm_impresion_etiquetas = New frm_impresion_etiquetas
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)

                            '------------------------------
                            ' FIN MODULO LOGISTICA

                            'MODULO BODEGA
                            '------------------------------
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Bodega" Then
                            Dim frm As frm_listado_bodega = New frm_listado_bodega
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ConfTipoUbicacion" Then
                            Dim frm As frm_listado_tipo_ubicaciones = New frm_listado_tipo_ubicaciones
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Pallet" Then
                            Dim frm As frm_listado_pallet = New frm_listado_pallet
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Pallet" Then
                            Dim frm As frm_listado_pallet = New frm_listado_pallet
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ProductosBodega" Then
                            Dim frm As frm_asocia_producto_bodega = New frm_asocia_producto_bodega
                            frm.cnn = _cnn
                            classComunes.OpenSubForm(frm)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Zonas" Then
                            Dim frm As frm_listado_zona = New frm_listado_zona
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "TipoUbicacion" Then
                            Dim frm As frm_listado_tipo_ubicaciones = New frm_listado_tipo_ubicaciones
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Ubicaciones" Then
                            Dim frm As frm_listado_ubicaciones = New frm_listado_ubicaciones
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RecepcionMercaderia" Then
                            Dim frm As frm_listado_recepciones = New frm_listado_recepciones
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "VisorAlmacenamiento" Then
                            Dim frm As frm_visor_recepciones = New frm_visor_recepciones
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoAsignacion" Then
                            Dim frm As frm_listado_asignaciones = New frm_listado_asignaciones
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ReasignacionProductos" Then
                            Dim frm As frm_reubicacion_de_bultos = New frm_reubicacion_de_bultos
                            frm.cnn = _cnn
                            classComunes.OpenSubForm(frm)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "MovimientoPalletPiso" Then
                            Dim frm As frm_movimiento_pallet = New frm_movimiento_pallet
                            frm.cnn = _cnn
                            classComunes.OpenSubForm(frm)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "VisorPicking" Then
                            Dim frm As frm_visor_picking = New frm_visor_picking
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "DetallePickingPorDia" Then
                            Dim frm As frm_listado_picking_diario = New frm_listado_picking_diario
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ConsolidadoPicking" Then
                            Dim frm As frm_consolidado_picking = New frm_consolidado_picking
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoConteoProducto" Then
                            Dim frm As frm_conteo_producto = New frm_conteo_producto
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "TarjetaExistencia" Then
                            Dim frm As frm_tarjeta_existencia = New frm_tarjeta_existencia
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)

                            '------------------------------
                            ' FIN MODULO BODEGA


                            'MODULO DESPACHO
                            '------------------------------
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "TiposDevolucion" Then
                            Dim frm As frm_listado_tipo_devolucion = New frm_listado_tipo_devolucion
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "TransportistaExternos" Then
                            Dim frm As frm_listado_transp_externo = New frm_listado_transp_externo
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "TipoVehiculo" Then
                            Dim frm As frm_listado_tipo_vehiculo = New frm_listado_tipo_vehiculo
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Vehiculos" Then
                            Dim frm As frm_listado_vehiculo = New frm_listado_vehiculo
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Despachos" Then
                            Dim frm As frm_listado_embarques = New frm_listado_embarques
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "DevoluciónProductos" Then
                            Dim frm As frm_visor_devoluciones = New frm_visor_devoluciones
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "DevoluciónProductosPicking" Then
                            Dim frm As frm_visor_devoluciones_por_picking = New frm_visor_devoluciones_por_picking
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "QuitaEmbarque" Then
                            Dim frm As frm_listado_productos_pendiente_embarque = New frm_listado_productos_pendiente_embarque
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoGuiaPallet" Then
                            Dim frm As frm_listado_gd_pallets = New frm_listado_gd_pallets
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RendicionFacturas" Then
                            Dim frm As frm_rendicion_factura = New frm_rendicion_factura
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RendicionGuias" Then
                            Dim frm As frm_rendicion_guia = New frm_rendicion_guia
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)

                            '------------------------------
                            ' FIN MODULO DESPACHO

                            'MODULO COMERCIAL
                            '------------------------------
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Productos" Then
                            Dim frm As frm_listado_productos = New frm_listado_productos
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ConfiguraProductoReemplazo" Then
                            Dim frm As frm_asocia_producto_de_reemplazo = New frm_asocia_producto_de_reemplazo
                            frm.cnn = _cnn
                            classComunes.OpenSubForm(frm)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Categorias" Then
                            Dim frm As frm_listado_categoria = New frm_listado_categoria
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Subcategorias" Then
                            Dim frm As frm_listado_subcategoria = New frm_listado_subcategoria
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Colores" Then
                            Dim frm As frm_listado_color = New frm_listado_color
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "UnidadMedida" Then
                            Dim frm As frm_listado_umedida = New frm_listado_umedida
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "TipoMultimedia" Then
                            Dim frm As frm_listado_tipo_multimedia = New frm_listado_tipo_multimedia
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Calidad" Then
                            Dim frm As frm_listado_calidad = New frm_listado_calidad
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Cartera" Then
                            Dim frm As frm_listado_carteras = New frm_listado_carteras
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "MotivoCierre" Then
                            Dim frm As frm_listado_motivo_cierre = New frm_listado_motivo_cierre
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "OrdenCompraProveedor" Then
                            Dim frm As frm_listado_orden_compra_proveedor = New frm_listado_orden_compra_proveedor
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "VisorOrdenCompra" Then
                            Dim frm As frmVisorOrdenCompraProveedor = New frmVisorOrdenCompraProveedor
                            frm.cnn = _cnn
                            classComunes.OpenSubFormModal(frm, Me)

                            '------------------------------
                            ' FIN MODULO COMERCIAL

                        End If

                        '    If ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraPickingVentaVerde" Then
                        '        Dim frm As frm_picking_sugerido = New frm_picking_sugerido
                        '        frm.cnn = _cnn
                        '        classComunes.OpenSubFormModal(frm, Me)
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraPickingAtravesAgenda" Then
                        '        Dim frm As frm_picking_por_agenda = New frm_picking_por_agenda
                        '        frm.cnn = _cnn
                        '        classComunes.OpenSubFormModal(frm, Me)
                        '        'frm.MdiParent = Me
                        '        'frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "BusquedaAgenda" Then
                        '        Dim frm As frm_listado_agenda = New frm_listado_agenda
                        '        frm.cnn = _cnn
                        '        classComunes.OpenSubFormModal(frm, Me)
                        '        'frm.MdiParent = Me
                        '        'frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraciónAgenda" Then
                        '        Dim frm As frm_ingreso_agenda = New frm_ingreso_agenda
                        '        frm.cnn = _cnn
                        '        classComunes.OpenSubForm(frm)
                        '        'classComunes.OpenSubFormModal(frm, Me)
                        '        'frm.MdiParent = Me
                        '        'frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "VisorPicking" Then
                        '        Dim frm As frm_visor_picking = New frm_visor_picking
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "BusquedaPicking" Then
                        '        Dim frm As frm_listado_picking = New frm_listado_picking
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ConsolidadoPicking" Then
                        '        Dim frm As frm_consolidado_picking = New frm_consolidado_picking
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "DetallePickingPorDia" Then
                        '        Dim frm As frm_listado_picking_diario = New frm_listado_picking_diario
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoOrdenesCompraCliente" Then
                        '        Dim frm As frm_listado_ordenes_de_compra = New frm_listado_ordenes_de_compra
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "OrdenesCompraCliente" Then
                        '        Dim frm As frm_orden_compra = New frm_orden_compra
                        '        frm.cnn = _cnn
                        '        classComunes.OpenSubForm(frm)
                        '        'frm.MdiParent = Me
                        '        'frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "PickingPendientesFacturación" Then
                        '        Dim frm As frm_visor_facturacion_picking = New frm_visor_facturacion_picking
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GuiasPendientesFacturación" Then
                        '        Dim frm As frm_visor_facturacion_guias = New frm_visor_facturacion_guias
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "PickingPendientesDespacho" Then
                        '        Dim frm As frm_visor_despacho = New frm_visor_despacho
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "PickingPendientesDespacho" Then
                        '        Dim frm As frm_visor_devoluciones = New frm_visor_devoluciones
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "DevoluciónProductos" Then
                        '        Dim frm As frm_visor_devoluciones = New frm_visor_devoluciones
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Despachos" Then
                        '        Dim frm As frm_listado_embarques = New frm_listado_embarques
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ImpresionEtiqueta" Then
                        '        Dim frm As frm_impresion_etiquetas = New frm_impresion_etiquetas
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ImpresionEtiquetaProducto" Then
                        '        Dim frm As frm_impresion_etiquetas_por_productos = New frm_impresion_etiquetas_por_productos
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RendicionFacturas" Then
                        '        Dim frm As frm_rendicion_factura = New frm_rendicion_factura
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RendicionGuias" Then
                        '        Dim frm As frm_rendicion_guia = New frm_rendicion_guia
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RevisionFacturasRendidas" Then
                        '        Dim frm As frm_validacion_facturas = New frm_validacion_facturas
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RegistraCobroFactura" Then
                        '        Dim frm As frm_cobro_facturas = New frm_cobro_facturas
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ConfUbicaciones" Then
                        '        Dim frm As frm_configuracion_ubicaciones = New frm_configuracion_ubicaciones
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "CertificadoConformidad" Then
                        '        Dim frm As frm_certificado_recepcion_conforme = New frm_certificado_recepcion_conforme
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RecepcionMercaderia" Then
                        '        Dim frm As frm_listado_recepciones = New frm_listado_recepciones
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "OrdenCompraProveedor" Then
                        '        Dim frm As frm_listado_orden_compra_proveedor = New frm_listado_orden_compra_proveedor
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "VisorOrdenCompra" Then
                        '        Dim frm As frmVisorOrdenCompraProveedor = New frmVisorOrdenCompraProveedor
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "DevoluciónProductosPicking" Then
                        '        Dim frm As frm_visor_devoluciones_por_picking = New frm_visor_devoluciones_por_picking
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ImprimeVentasPendientes" Then
                        '        Dim frm As frm_imprime_vta_prendiente = New frm_imprime_vta_prendiente
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ModificaFactura" Then
                        '        Dim frm As frm_visor_modificacion_facturavb = New frm_visor_modificacion_facturavb
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "MovimientosDeRecepción" Then
                        '        Dim frm As frm_movimientos_recepcion = New frm_movimientos_recepcion
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ModificaGuia" Then
                        '        Dim frm As frm_visor_modificacion_guias = New frm_visor_modificacion_guias
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoGuiaPallet" Then
                        '        Dim frm As frm_listado_gd_pallets = New frm_listado_gd_pallets
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "QuitaEmbarque" Then
                        '        Dim frm As frm_listado_productos_pendiente_embarque = New frm_listado_productos_pendiente_embarque
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoConteoProducto" Then
                        '        Dim frm As frm_conteo_producto = New frm_conteo_producto
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "TarjetaExistencia" Then
                        '        Dim frm As frm_tarjeta_existencia = New frm_tarjeta_existencia
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "VisorAlmacenamiento" Then
                        '        Dim frm As frm_visor_recepciones = New frm_visor_recepciones
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoAsignacion" Then
                        '        Dim frm As frm_listado_asignaciones = New frm_listado_asignaciones
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "MovimientoPalletPiso" Then
                        '        Dim frm As frm_movimiento_pallet = New frm_movimiento_pallet
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ReasignacionProductos" Then
                        '        Dim frm As frm_reubicacion_de_bultos = New frm_reubicacion_de_bultos
                        '        frm.cnn = _cnn
                        '        frm.MdiParent = Me
                        '        frm.Show()
                        '    End If

                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message + "\ABRE_APLICACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Else
                MessageBox.Show(_msg + "\ABRE_APLICACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        Modulo = " BODEGA "
        TreeMenu.Nodes.Clear()
        FillTestTable(2)
        CreateTree()
        TreeMenu.ExpandAll()
        lblModulo.Text = "MODULO" + Modulo + "ACTIVO"
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        Modulo = " LOGISTICA "
        TreeMenu.Nodes.Clear()
        FillTestTable(1)
        CreateTree()
        TreeMenu.ExpandAll()
        lblModulo.Text = "MODULO" + Modulo + "ACTIVO"
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Modulo = " DESPACHO "
        TreeMenu.Nodes.Clear()
        FillTestTable(3)
        CreateTree()
        TreeMenu.ExpandAll()
        lblModulo.Text = "MODULO" + Modulo + "ACTIVO"

    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        Modulo = " COMERCIAL "
        TreeMenu.Nodes.Clear()
        FillTestTable(4)
        CreateTree()
        TreeMenu.ExpandAll()
        lblModulo.Text = "MODULO" + Modulo + "ACTIVO"
    End Sub
End Class