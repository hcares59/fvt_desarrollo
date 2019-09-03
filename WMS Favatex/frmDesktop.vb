Public Class frmDesktop
    Private _cnn As String
    Dim dtTree As DataTable = New DataTable
    Dim NodeRightClick As String

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frmDesktop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'GLO_USUARIO_ACTUAL = 2
        'GLO_USUARIO_PASS = "123"
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        FillTestTable()
        CreateTree()
        TreeMenu.ExpandAll()
        Call INICIALIZA_VALORES()
        Call HABILITA_MENU()
        If GLO_USUARIO_ACTUAL = 6 Or GLO_USUARIO_ACTUAL = 13 Then
            menuDesarrollos.Visible = True
        End If


    End Sub

    Private Sub INICIALIZA_VALORES()
        txtUsuarioActual.Text = "USUARIO ACTUAL: " + GLO_PERSONA_NOMBRE
        txtServidor.Text = "SERVIDOR: " + pubServidor
        txtBase.Text = "BASE DE DATOS: " + pubBaseDato
        txtVersion.Text = "VERSIÓN DEL SISTEMA: " + Application.ProductVersion

        GLO_FECHA_SISTEMA = OBTIENE_FECHA_SISTEMA()
        GLO_BODEGA_RECEPCION = 14
        'GLO_UBI_PISO_RECEPCION = 220

        Call OBTIENE_PRIVILEGIOS_USUARIO()

    End Sub

    Private Function OBTIENE_PRIVILEGIOS_USUARIO() As Date
        Dim classUsuario As class_usuario = New class_usuario
        Dim _msgError As String = ""
        Dim ds As DataSet

        Try
            classUsuario.cnn = _cnn
            classUsuario.usu_codigo = GLO_USUARIO_ACTUAL
            classUsuario.todos = 1
            ds = classUsuario.USUARIO_LISTADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    USU_ASIGNA_PARA_RECEPCION = ds.Tables(0).Rows(0)("es_asiganpararecepcion")
                    USU_EJECUTA_RECEPCION = ds.Tables(0).Rows(0)("es_ejecutarecepcion")
                    USU_ASIGNA_PARA_ALMACENAMIENTO = ds.Tables(0).Rows(0)("es_asignaparaalmacenaje")
                    USU_EJECUTA_ALMACENAMIENTO = ds.Tables(0).Rows(0)("es_ejecutaalmacenaje")
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_PRIVILEGIOS_USUARIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message + "\OBTIENE_PRIVILEGIOS_USUARIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Function OBTIENE_FECHA_SISTEMA() As Date
        Dim classComnes As class_comunes = New class_comunes
        Dim _msgError As String = ""
        Dim ds As DataSet
        OBTIENE_FECHA_SISTEMA = CDate("01-01-1900")
        Try
            classComnes.cnn = _cnn
            ds = classComnes.OBTIENE_FECHA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return CDate(ds.Tables(0).Rows(0)("fecha_sistema"))
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_FECHA_SISTEMA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message + "\OBTIENE_FECHA_SISTEMA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Sub MostrarVentana(ByVal Formulario As Form, ByVal Mdi As Form, ByVal titulo_formulario As String, Optional ByVal CargaNormal As Boolean = False)
        Dim Frmllamado As Form
        Dim Escargado As Boolean = False
        For Each Frmllamado In Mdi.MdiChildren
            If Frmllamado.Text = titulo_formulario Then
                Escargado = True
                Exit For
            End If
        Next

        Formulario.MdiParent = Mdi
        Formulario.Show()
        Formulario.Focus()
    End Sub

    Private Sub FillTestTable()
        Dim menu As class_menu = New class_menu
        Dim Msg As String = ""

        Dim i As Integer
        Try
            menu.cnn = _cnn
            menu.usu_codigo = GLO_USUARIO_ACTUAL
            dtTree = menu.USUARIO_BUSCA_MENU(Msg)
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

    Private Sub HABILITA_MENU()
        Dim menu As class_menu = New class_menu
        Dim Msg As String = ""

        Dim i As Integer
        Try
            menu.cnn = _cnn
            menu.usu_codigo = GLO_USUARIO_ACTUAL
            dtTree = menu.USUARIO_BUSCA_MENU_BARRA(Msg)
            If dtTree.Rows(i).Item("men_nombre").ToString = "" Then
                Exit Sub
            End If

            For i = 0 To dtTree.Rows.Count - 1
                If dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_cambio_contrasena" Then
                    mnu_cambio_contrasena.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_ingreso_usuarios" Then
                    mnu_ingreso_usuarios.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_usuario" Then
                    mnu_listado_usuario.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_asigna_privilegios" Then
                    mnu_asigna_privilegios.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_productos" Then
                    mnu_listado_productos.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "frm_asocia_producto_bodega" Then
                    frm_asocia_producto_bodega.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_categoria" Then
                    mnu_listado_categoria.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_cartera" Then
                    mnu_listado_cartera.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_subcategoria" Then
                    mnu_listado_subcategoria.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_color" Then
                    mnu_listado_color.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_umedida" Then
                    mnu_listado_umedida.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_tipo_documento" Then
                    mnu_listado_tipo_documento.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_tipo_multimedia" Then
                    mnu_listado_tipo_multimedia.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_calidad" Then
                    mnu_listado_calidad.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_bodega" Then
                    mnu_listado_bodega.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_listado_productos" Then
                    mnu_listado_productos.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_tipo_de_vehiculo" Then
                    mnu_tipo_de_vehiculo.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_vehiculos" Then
                    mnu_vehiculos.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_productos_reemplazo" Then
                    mnu_productos_reemplazo.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_tipodevolucion" Then
                    mnu_tipodevolucion.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_tipoubicacion" Then
                    mnu_TipoDeUbicaciones.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_configura_ubicacion_bodega" Then
                    mnu_configura_ubicacion_bodega.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_zona" Then
                    mnu_zona.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_ubicaciones" Then
                    mnu_ubicaciones.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_segmento" Then
                    mnu_segmento.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_pallet" Then
                    mnu_pallet.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_transportistaexterno" Then
                    mnu_transportista.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "ObtenerListaDePreciosToolStripMenuItem" Then
                    ObtenerListaDePreciosToolStripMenuItem.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "DevolucionesPorMotivos" Then
                    DevolucionesPorMotivos.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "FacturasRendidasVsPorRendir4" Then
                    FacturasRendidasVsPorRendir4.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "VentasPendientes1" Then
                    VentasPendientes1.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "ComprasVsDespacho2" Then
                    ComprasVsDespacho2.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_area" Then
                    mnuArea.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mnu_glosa" Then
                    mnu_glosa.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mmu_motivocierre" Then
                    mmu_motivocierre.Enabled = True
                ElseIf dtTree.Rows(i).Item("men_urlpagina").ToString = "mmu_FillRate" Then
                    mmu_FillRate.Enabled = True
                End If


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
                Dim icono As String = Rows1(j).Item("men_icono").ToString

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

    Private Sub picH_Click(sender As Object, e As EventArgs) Handles picH.Click
        picD.Visible = True
        picH.Visible = False
        PanelMenu.Width = 234
    End Sub

    Private Sub picD_Click(sender As Object, e As EventArgs) Handles picD.Click
        picH.Visible = True
        picD.Visible = False
        PanelMenu.Width = 10
    End Sub

    Private Sub TreeMenu_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeMenu.AfterSelect
        Call ABRE_APLICACION(TreeMenu.SelectedNode.Name)
        TreeMenu.SelectedNode = TreeMenu.Nodes(0)
    End Sub

    Private Sub ABRE_APLICACION(ByVal codMenu As Integer)
        Dim class_menu As class_menu = New class_menu
        Dim _msg As String = ""
        Dim ds As DataSet


        Try
            class_menu.cnn = _cnn
            class_menu.men_codigo = codMenu
            ds = class_menu.MENU_SELECCIONA_APLICACION(_msg)
            If _msg = "" Then
                Try
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("men_codigopadre") = 0 Then
                            ds = Nothing
                            Exit Sub
                        End If

                        'MENU PARAMETROS GENERALES
                        If ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraPickingVentaVerde" Then
                            Dim frm As frm_picking_sugerido = New frm_picking_sugerido
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraPickingAtravesAgenda" Then
                            Dim frm As frm_picking_por_agenda = New frm_picking_por_agenda
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "BusquedaAgenda" Then
                            Dim frm As frm_listado_agenda = New frm_listado_agenda
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraciónAgenda" Then
                            Dim frm As frm_ingreso_agenda = New frm_ingreso_agenda
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "VisorPicking" Then
                            Dim frm As frm_visor_picking = New frm_visor_picking
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "BusquedaPicking" Then
                            Dim frm As frm_listado_picking = New frm_listado_picking
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ConsolidadoPicking" Then
                            Dim frm As frm_consolidado_picking = New frm_consolidado_picking
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "DetallePickingPorDia" Then
                            Dim frm As frm_listado_picking_diario = New frm_listado_picking_diario
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoOrdenesCompraCliente" Then
                            Dim frm As frm_listado_ordenes_de_compra = New frm_listado_ordenes_de_compra
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "OrdenesCompraCliente" Then
                            Dim frm As frm_orden_compra = New frm_orden_compra
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "PickingPendientesFacturación" Then
                            Dim frm As frm_visor_facturacion_picking = New frm_visor_facturacion_picking
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GuiasPendientesFacturación" Then
                            Dim frm As frm_visor_facturacion_guias = New frm_visor_facturacion_guias
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "PickingPendientesDespacho" Then
                            Dim frm As frm_visor_despacho = New frm_visor_despacho
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "PickingPendientesDespacho" Then
                            Dim frm As frm_visor_devoluciones = New frm_visor_devoluciones
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "DevoluciónProductos" Then
                            Dim frm As frm_visor_devoluciones = New frm_visor_devoluciones
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Despachos" Then
                            Dim frm As frm_listado_embarques = New frm_listado_embarques
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ImpresionEtiqueta" Then
                            Dim frm As frm_impresion_etiquetas = New frm_impresion_etiquetas
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ImpresionEtiquetaProducto" Then
                            Dim frm As frm_impresion_etiquetas_por_productos = New frm_impresion_etiquetas_por_productos
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RendicionFacturas" Then
                            Dim frm As frm_rendicion_factura = New frm_rendicion_factura
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RendicionGuias" Then
                            Dim frm As frm_rendicion_guia = New frm_rendicion_guia
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RevisionFacturasRendidas" Then
                            Dim frm As frm_validacion_facturas = New frm_validacion_facturas
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RegistraCobroFactura" Then
                            Dim frm As frm_cobro_facturas = New frm_cobro_facturas
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ConfUbicaciones" Then
                            Dim frm As frm_configuracion_ubicaciones = New frm_configuracion_ubicaciones
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "CertificadoConformidad" Then
                            Dim frm As frm_certificado_recepcion_conforme = New frm_certificado_recepcion_conforme
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "RecepcionMercaderia" Then
                            Dim frm As frm_listado_recepciones = New frm_listado_recepciones
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "OrdenCompraProveedor" Then
                            Dim frm As frm_listado_orden_compra_proveedor = New frm_listado_orden_compra_proveedor
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "VisorOrdenCompra" Then
                            Dim frm As frmVisorOrdenCompraProveedor = New frmVisorOrdenCompraProveedor
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "DevoluciónProductosPicking" Then
                            Dim frm As frm_visor_devoluciones_por_picking = New frm_visor_devoluciones_por_picking
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ImprimeVentasPendientes" Then
                            Dim frm As frm_imprime_vta_prendiente = New frm_imprime_vta_prendiente
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ModificaFactura" Then
                            Dim frm As frm_visor_modificacion_facturavb = New frm_visor_modificacion_facturavb
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "MovimientosDeRecepción" Then
                            Dim frm As frm_movimientos_recepcion = New frm_movimientos_recepcion
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ModificaGuia" Then
                            Dim frm As frm_visor_modificacion_guias = New frm_visor_modificacion_guias
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoGuiaPallet" Then
                            Dim frm As frm_listado_gd_pallets = New frm_listado_gd_pallets
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "QuitaEmbarque" Then
                            Dim frm As frm_listado_productos_pendiente_embarque = New frm_listado_productos_pendiente_embarque
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoConteoProducto" Then
                            Dim frm As frm_conteo_producto = New frm_conteo_producto
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "TarjetaExistencia" Then
                            Dim frm As frm_tarjeta_existencia = New frm_tarjeta_existencia
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "VisorAlmacenamiento" Then
                            Dim frm As frm_visor_recepciones = New frm_visor_recepciones
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ListadoAsignacion" Then
                            Dim frm As frm_listado_asignaciones = New frm_listado_asignaciones
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "MovimientoPalletPiso" Then
                            Dim frm As frm_movimiento_pallet = New frm_movimiento_pallet
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ReasignacionProductos" Then
                            Dim frm As frm_reubicacion_de_bultos = New frm_reubicacion_de_bultos
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "ConsultaVentaVerde" Then
                            Dim frm As frm_consulta_vv = New frm_consulta_vv
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "Homologacion" Then
                            Dim frm As frm_homologacion_productos = New frm_homologacion_productos
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        ElseIf ds.Tables(0).Rows(0)("men_urlpagina") = "GeneraNotaVenta" Then
                            Dim frm As frm_generacion_archivo_nv = New frm_generacion_archivo_nv
                            frm.cnn = _cnn
                            frm.MdiParent = Me
                            frm.Show()
                        End If

                    End If




                    'Dim FileProperties As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\" + ds.Tables(0).Rows(0)("men_aplicacion"))

                    'MessageBox.Show(FileProperties.FileVersion)

                    'Dim _rutaExe As String = Application.StartupPath & ds.Tables(0).Rows(0)("men_aplicacion")
                    'Shell(_rutaExe & " " & _servidor & " " & _baseDato & " " & _usuario & " " & _contrasena, AppWinStyle.NormalFocus)

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
    Private Sub PerfilesDeUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_asigna_privilegios.Click
        Dim frm As frm_asigna_privilegios = New frm_asigna_privilegios
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub CambioDeContraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_cambio_contrasena.Click
        Dim classComunes As class_comunes = New class_comunes
        Dim frm As frm_cambio_contrasena = New frm_cambio_contrasena
        frm.cnn = _cnn
        classComunes.OpenSubFormModal(frm, Me)



        'MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub IngresoDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_ingreso_usuarios.Click
        Dim frm As frm_ingreso_usuarios = New frm_ingreso_usuarios
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub ListadoUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_listado_usuario.Click
        Dim frm As frm_listado_usuario = New frm_listado_usuario
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub CategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_listado_categoria.Click
        Dim frm As frm_listado_categoria = New frm_listado_categoria
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub SubcategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_listado_subcategoria.Click
        Dim frm As frm_listado_subcategoria = New frm_listado_subcategoria
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub ColoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_listado_color.Click
        Dim frm As frm_listado_color = New frm_listado_color
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub UMedidasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_listado_umedida.Click
        Dim frm As frm_listado_umedida = New frm_listado_umedida
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub TiposDeDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_listado_tipo_documento.Click
        Dim frm As frm_listado_tipo_documento = New frm_listado_tipo_documento
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub TiposDeMultimediaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_listado_tipo_multimedia.Click
        Dim frm As frm_listado_tipo_multimedia = New frm_listado_tipo_multimedia
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub CalidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_listado_calidad.Click
        Dim frm As frm_listado_calidad = New frm_listado_calidad
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub BodegasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_listado_bodega.Click
        Dim frm As frm_listado_bodega = New frm_listado_bodega
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub frmDesktop_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub mnu_listado_productos_Click(sender As Object, e As EventArgs) Handles mnu_listado_productos.Click
        Dim frm As frm_listado_productos = New frm_listado_productos
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub mnu_listado_cartera_Click(sender As Object, e As EventArgs) Handles mnu_listado_cartera.Click
        Dim frm As frm_listado_carteras = New frm_listado_carteras
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub ProductosBodegasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles frm_asocia_producto_bodega.Click
        Dim frm As frm_asocia_producto_bodega = New frm_asocia_producto_bodega
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub TipoDeVehiculosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_tipo_de_vehiculo.Click
        Dim frm As frm_listado_tipo_vehiculo = New frm_listado_tipo_vehiculo
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub
    Private Sub mnu_vehiculos_Click(sender As Object, e As EventArgs) Handles mnu_vehiculos.Click
        Dim frm As frm_listado_vehiculo = New frm_listado_vehiculo
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub mnu_productos_reemplazo_Click(sender As Object, e As EventArgs) Handles mnu_productos_reemplazo.Click
        Dim frm As frm_asocia_producto_de_reemplazo = New frm_asocia_producto_de_reemplazo
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub TiposDeDevolucónesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_tipodevolucion.Click
        Dim frm As frm_listado_tipo_devolucion = New frm_listado_tipo_devolucion
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub SegmentocapacidadPesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_segmento.Click
        Dim frm As frm_listado_seg_capacidad = New frm_listado_seg_capacidad
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub UbicacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_ubicaciones.Click
        Dim frm As frm_listado_ubicaciones = New frm_listado_ubicaciones
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub mnu_configura_ubicacion_bodega_Click(sender As Object, e As EventArgs) Handles mnu_configura_ubicacion_bodega.Click
        Dim frm As frm_bodega_tipo_ubicacion = New frm_bodega_tipo_ubicacion
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub ZonasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_zona.Click
        Dim frm As frm_listado_zona = New frm_listado_zona
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub TipoDeUbicacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_TipoDeUbicaciones.Click
        Dim frm As frm_listado_tipo_ubicaciones = New frm_listado_tipo_ubicaciones
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub TrasportitasExternosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_transportista.Click
        Dim frm As frm_listado_transp_externo = New frm_listado_transp_externo
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub PalletToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_pallet.Click
        Dim frm As frm_listado_pallet = New frm_listado_pallet
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub ObtenerListaDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObtenerListaDePreciosToolStripMenuItem.Click
        Dim startInfo As System.Diagnostics.ProcessStartInfo
        Dim pStart As New System.Diagnostics.Process
        Dim ruta As String = Application.StartupPath

        startInfo = New System.Diagnostics.ProcessStartInfo(ruta + "\" + "ListaPrecioManager.exe")

        pStart.StartInfo = startInfo
        pStart.Start()

        'pStart.Wait-For-Exit() 'esto hace que tu código se detenga hasta que el exe se haya ejecutado
        'Dim frm As frm_lista_precio_manager = New frm_lista_precio_manager
        'MostrarVentana(frm, Me, frm.Text, False)
    End Sub
    Private Sub DevolucionesPorMotivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesPorMotivos.Click
        Dim frm As frm_informe_devoluciones_por_tipo = New frm_informe_devoluciones_por_tipo
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub
    Private Sub VentasPendientes1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasPendientes1.Click
        Dim frm As frm_listado_ventas_pendientes = New frm_listado_ventas_pendientes
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub
    Private Sub ComprasVsDespacho2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasVsDespacho2.Click
        Dim frm As frm_informe_uni_desp_vs_compra = New frm_informe_uni_desp_vs_compra
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub FacturasRendidasVsPorRendir4_Click(sender As Object, e As EventArgs) Handles FacturasRendidasVsPorRendir4.Click
        Dim frm As frm_listado_facturas_rendidas_vs_pendientes = New frm_listado_facturas_rendidas_vs_pendientes
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub KpiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KpiToolStripMenuItem.Click
        Dim frm As frm_kpi = New frm_kpi
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub AreasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuArea.Click
        Dim frm As frm_listado_areas = New frm_listado_areas
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub mnu_glosa_Click(sender As Object, e As EventArgs) Handles mnu_glosa.Click
        Dim frm As frm_listado_glosas = New frm_listado_glosas
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub MotivosDeCierreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mmu_motivocierre.Click
        Dim frm As frm_listado_motivo_cierre = New frm_listado_motivo_cierre
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub FillRateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mmu_FillRate.Click
        Dim frm As frm_fill_rate = frm_fill_rate
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub AbastecimientoParaPkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbastecimientoParaPkToolStripMenuItem.Click
        Dim frm As frm_abastecimiento_para_pk = frm_abastecimiento_para_pk
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub HomologacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomologacionToolStripMenuItem.Click
        Dim frm As frm_homologacion_productos = frm_homologacion_productos
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub ListadoAbastecimeitnoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoAbastecimeitnoToolStripMenuItem.Click
        Dim frm As frm_listado_ordenes_abastecimiento = frm_listado_ordenes_abastecimiento
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub OrdenDePkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDePkToolStripMenuItem.Click
        Dim frm As frm_listado_ordenes_pk_listado = frm_listado_ordenes_pk_listado
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)

        'Dim frm As frm_oden_para_picking = frm_oden_para_picking
        'frm.cnn = _cnn
        'MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub ListadoDeTablasGenericasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeTablasGenericasToolStripMenuItem.Click
        Dim frm As frm_listado_tablas_genericas = New frm_listado_tablas_genericas
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub AlturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlturaToolStripMenuItem.Click
        Dim frm As frm_listado_altura = frm_listado_altura
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub
End Class