<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDesktop
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDesktop))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtUsuarioActual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtServidor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtBase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_cambio_contrasena = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_ingreso_usuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_listado_usuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_asigna_privilegios = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_listado_productos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_productos_reemplazo = New System.Windows.Forms.ToolStripMenuItem()
        Me.frm_asocia_producto_bodega = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_listado_cartera = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_listado_categoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_listado_subcategoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_listado_color = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_listado_umedida = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_listado_tipo_documento = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_listado_tipo_multimedia = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_listado_calidad = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_listado_bodega = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_TipoDeUbicaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_configura_ubicacion_bodega = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_zona = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_ubicaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_segmento = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_tipo_de_vehiculo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_vehiculos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_glosa = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_tipodevolucion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_transportista = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_pallet = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mmu_motivocierre = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesConManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObtenerListaDePreciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequerimientosEnCertificaciónMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevolucionesPorMotivos = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturasRendidasVsPorRendir4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasPendientes1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprasVsDespacho2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.KpiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbastecimientoParaPkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HomologacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListadoAbastecimeitnoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenDePkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mmu_FillRate = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuDesarrollos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListadoDeTablasGenericasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.picD = New System.Windows.Forms.PictureBox()
        Me.picH = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TreeMenu = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.AlturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMenu.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtUsuarioActual, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.txtServidor, Me.txtBase, Me.txtVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 533)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(789, 22)
        Me.StatusStrip1.TabIndex = 30
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtUsuarioActual
        '
        Me.txtUsuarioActual.Name = "txtUsuarioActual"
        Me.txtUsuarioActual.Size = New System.Drawing.Size(119, 17)
        Me.txtUsuarioActual.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'txtServidor
        '
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(119, 17)
        Me.txtServidor.Text = "ToolStripStatusLabel1"
        '
        'txtBase
        '
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(119, 17)
        Me.txtBase.Text = "ToolStripStatusLabel1"
        '
        'txtVersion
        '
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(119, 17)
        Me.txtVersion.Text = "ToolStripStatusLabel1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SistemaToolStripMenuItem, Me.MantenedoresToolStripMenuItem, Me.OperacionesConManagerToolStripMenuItem, Me.RequerimientosEnCertificaciónMenu, Me.InformesToolStripMenuItem, Me.menuDesarrollos})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(789, 24)
        Me.MenuStrip1.TabIndex = 31
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SistemaToolStripMenuItem
        '
        Me.SistemaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_cambio_contrasena, Me.ToolStripMenuItem1, Me.mnu_ingreso_usuarios, Me.mnu_listado_usuario, Me.ToolStripMenuItem2, Me.mnu_asigna_privilegios})
        Me.SistemaToolStripMenuItem.Name = "SistemaToolStripMenuItem"
        Me.SistemaToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.SistemaToolStripMenuItem.Text = "Sistema"
        '
        'mnu_cambio_contrasena
        '
        Me.mnu_cambio_contrasena.Enabled = False
        Me.mnu_cambio_contrasena.Name = "mnu_cambio_contrasena"
        Me.mnu_cambio_contrasena.Size = New System.Drawing.Size(189, 22)
        Me.mnu_cambio_contrasena.Text = "Cambio de contraseña"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(186, 6)
        '
        'mnu_ingreso_usuarios
        '
        Me.mnu_ingreso_usuarios.Enabled = False
        Me.mnu_ingreso_usuarios.Name = "mnu_ingreso_usuarios"
        Me.mnu_ingreso_usuarios.Size = New System.Drawing.Size(189, 22)
        Me.mnu_ingreso_usuarios.Text = "Ingreso de usuarios"
        '
        'mnu_listado_usuario
        '
        Me.mnu_listado_usuario.Enabled = False
        Me.mnu_listado_usuario.Name = "mnu_listado_usuario"
        Me.mnu_listado_usuario.Size = New System.Drawing.Size(189, 22)
        Me.mnu_listado_usuario.Text = "Listado usuarios"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(186, 6)
        '
        'mnu_asigna_privilegios
        '
        Me.mnu_asigna_privilegios.Enabled = False
        Me.mnu_asigna_privilegios.Name = "mnu_asigna_privilegios"
        Me.mnu_asigna_privilegios.Size = New System.Drawing.Size(189, 22)
        Me.mnu_asigna_privilegios.Text = "Perfiles de usuario"
        '
        'MantenedoresToolStripMenuItem
        '
        Me.MantenedoresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_listado_productos, Me.mnu_productos_reemplazo, Me.frm_asocia_producto_bodega, Me.ToolStripMenuItem6, Me.mnu_listado_cartera, Me.ToolStripMenuItem3, Me.mnu_listado_categoria, Me.mnu_listado_subcategoria, Me.mnu_listado_color, Me.mnu_listado_umedida, Me.ToolStripMenuItem4, Me.mnu_listado_tipo_documento, Me.mnu_listado_tipo_multimedia, Me.mnu_listado_calidad, Me.ToolStripMenuItem5, Me.mnu_listado_bodega, Me.mnu_TipoDeUbicaciones, Me.mnu_configura_ubicacion_bodega, Me.mnu_zona, Me.mnu_ubicaciones, Me.mnu_segmento, Me.ToolStripMenuItem7, Me.mnu_tipo_de_vehiculo, Me.mnu_vehiculos, Me.mnuArea, Me.mnu_glosa, Me.mnu_tipodevolucion, Me.mnu_transportista, Me.mnu_pallet, Me.ToolStripMenuItem8, Me.mmu_motivocierre})
        Me.MantenedoresToolStripMenuItem.Name = "MantenedoresToolStripMenuItem"
        Me.MantenedoresToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.MantenedoresToolStripMenuItem.Text = "Mantenedores"
        '
        'mnu_listado_productos
        '
        Me.mnu_listado_productos.Enabled = False
        Me.mnu_listado_productos.Name = "mnu_listado_productos"
        Me.mnu_listado_productos.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_productos.Text = "Productos"
        '
        'mnu_productos_reemplazo
        '
        Me.mnu_productos_reemplazo.Enabled = False
        Me.mnu_productos_reemplazo.Name = "mnu_productos_reemplazo"
        Me.mnu_productos_reemplazo.Size = New System.Drawing.Size(262, 22)
        Me.mnu_productos_reemplazo.Text = "Configura productos de remplazo"
        '
        'frm_asocia_producto_bodega
        '
        Me.frm_asocia_producto_bodega.Enabled = False
        Me.frm_asocia_producto_bodega.Name = "frm_asocia_producto_bodega"
        Me.frm_asocia_producto_bodega.Size = New System.Drawing.Size(262, 22)
        Me.frm_asocia_producto_bodega.Text = "Productos bodegas"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(259, 6)
        '
        'mnu_listado_cartera
        '
        Me.mnu_listado_cartera.Enabled = False
        Me.mnu_listado_cartera.Name = "mnu_listado_cartera"
        Me.mnu_listado_cartera.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_cartera.Text = "Cartera"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(259, 6)
        '
        'mnu_listado_categoria
        '
        Me.mnu_listado_categoria.Enabled = False
        Me.mnu_listado_categoria.Name = "mnu_listado_categoria"
        Me.mnu_listado_categoria.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_categoria.Text = "Categoria"
        '
        'mnu_listado_subcategoria
        '
        Me.mnu_listado_subcategoria.Enabled = False
        Me.mnu_listado_subcategoria.Name = "mnu_listado_subcategoria"
        Me.mnu_listado_subcategoria.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_subcategoria.Text = "Subcategoria"
        '
        'mnu_listado_color
        '
        Me.mnu_listado_color.Enabled = False
        Me.mnu_listado_color.Name = "mnu_listado_color"
        Me.mnu_listado_color.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_color.Text = "Colores"
        '
        'mnu_listado_umedida
        '
        Me.mnu_listado_umedida.Enabled = False
        Me.mnu_listado_umedida.Name = "mnu_listado_umedida"
        Me.mnu_listado_umedida.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_umedida.Text = "U. Medidas"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(259, 6)
        '
        'mnu_listado_tipo_documento
        '
        Me.mnu_listado_tipo_documento.Enabled = False
        Me.mnu_listado_tipo_documento.Name = "mnu_listado_tipo_documento"
        Me.mnu_listado_tipo_documento.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_tipo_documento.Text = "Tipos de documento"
        '
        'mnu_listado_tipo_multimedia
        '
        Me.mnu_listado_tipo_multimedia.Enabled = False
        Me.mnu_listado_tipo_multimedia.Name = "mnu_listado_tipo_multimedia"
        Me.mnu_listado_tipo_multimedia.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_tipo_multimedia.Text = "Tipos de multimedia"
        '
        'mnu_listado_calidad
        '
        Me.mnu_listado_calidad.Enabled = False
        Me.mnu_listado_calidad.Name = "mnu_listado_calidad"
        Me.mnu_listado_calidad.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_calidad.Text = "Calidad"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(259, 6)
        '
        'mnu_listado_bodega
        '
        Me.mnu_listado_bodega.Enabled = False
        Me.mnu_listado_bodega.Name = "mnu_listado_bodega"
        Me.mnu_listado_bodega.Size = New System.Drawing.Size(262, 22)
        Me.mnu_listado_bodega.Text = "Bodegas"
        '
        'mnu_TipoDeUbicaciones
        '
        Me.mnu_TipoDeUbicaciones.Enabled = False
        Me.mnu_TipoDeUbicaciones.Name = "mnu_TipoDeUbicaciones"
        Me.mnu_TipoDeUbicaciones.Size = New System.Drawing.Size(262, 22)
        Me.mnu_TipoDeUbicaciones.Text = "Tipo de ubicaciones"
        '
        'mnu_configura_ubicacion_bodega
        '
        Me.mnu_configura_ubicacion_bodega.Enabled = False
        Me.mnu_configura_ubicacion_bodega.Name = "mnu_configura_ubicacion_bodega"
        Me.mnu_configura_ubicacion_bodega.Size = New System.Drawing.Size(262, 22)
        Me.mnu_configura_ubicacion_bodega.Text = "Configura tipo de ubicación bodega"
        '
        'mnu_zona
        '
        Me.mnu_zona.Enabled = False
        Me.mnu_zona.Name = "mnu_zona"
        Me.mnu_zona.Size = New System.Drawing.Size(262, 22)
        Me.mnu_zona.Text = "Zonas"
        '
        'mnu_ubicaciones
        '
        Me.mnu_ubicaciones.Enabled = False
        Me.mnu_ubicaciones.Name = "mnu_ubicaciones"
        Me.mnu_ubicaciones.Size = New System.Drawing.Size(262, 22)
        Me.mnu_ubicaciones.Text = "Ubicaciones"
        '
        'mnu_segmento
        '
        Me.mnu_segmento.Enabled = False
        Me.mnu_segmento.Name = "mnu_segmento"
        Me.mnu_segmento.Size = New System.Drawing.Size(262, 22)
        Me.mnu_segmento.Text = "Segmento (capacidad peso)"
        Me.mnu_segmento.Visible = False
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(259, 6)
        '
        'mnu_tipo_de_vehiculo
        '
        Me.mnu_tipo_de_vehiculo.Enabled = False
        Me.mnu_tipo_de_vehiculo.Name = "mnu_tipo_de_vehiculo"
        Me.mnu_tipo_de_vehiculo.Size = New System.Drawing.Size(262, 22)
        Me.mnu_tipo_de_vehiculo.Text = "Tipo de vehiculos"
        '
        'mnu_vehiculos
        '
        Me.mnu_vehiculos.Enabled = False
        Me.mnu_vehiculos.Name = "mnu_vehiculos"
        Me.mnu_vehiculos.Size = New System.Drawing.Size(262, 22)
        Me.mnu_vehiculos.Text = "Vehiculos"
        '
        'mnuArea
        '
        Me.mnuArea.Enabled = False
        Me.mnuArea.Name = "mnuArea"
        Me.mnuArea.Size = New System.Drawing.Size(262, 22)
        Me.mnuArea.Text = "Areas"
        '
        'mnu_glosa
        '
        Me.mnu_glosa.Enabled = False
        Me.mnu_glosa.Name = "mnu_glosa"
        Me.mnu_glosa.Size = New System.Drawing.Size(262, 22)
        Me.mnu_glosa.Text = "Glosas para tipo de devolucion"
        '
        'mnu_tipodevolucion
        '
        Me.mnu_tipodevolucion.Enabled = False
        Me.mnu_tipodevolucion.Name = "mnu_tipodevolucion"
        Me.mnu_tipodevolucion.Size = New System.Drawing.Size(262, 22)
        Me.mnu_tipodevolucion.Text = "Tipos de devoluciones"
        '
        'mnu_transportista
        '
        Me.mnu_transportista.Enabled = False
        Me.mnu_transportista.Name = "mnu_transportista"
        Me.mnu_transportista.Size = New System.Drawing.Size(262, 22)
        Me.mnu_transportista.Text = "Trasportitas externos"
        '
        'mnu_pallet
        '
        Me.mnu_pallet.Enabled = False
        Me.mnu_pallet.Name = "mnu_pallet"
        Me.mnu_pallet.Size = New System.Drawing.Size(262, 22)
        Me.mnu_pallet.Text = "Pallet"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(259, 6)
        '
        'mmu_motivocierre
        '
        Me.mmu_motivocierre.Enabled = False
        Me.mmu_motivocierre.Name = "mmu_motivocierre"
        Me.mmu_motivocierre.Size = New System.Drawing.Size(262, 22)
        Me.mmu_motivocierre.Text = "Motivos de cierre"
        '
        'OperacionesConManagerToolStripMenuItem
        '
        Me.OperacionesConManagerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ObtenerListaDePreciosToolStripMenuItem})
        Me.OperacionesConManagerToolStripMenuItem.Name = "OperacionesConManagerToolStripMenuItem"
        Me.OperacionesConManagerToolStripMenuItem.Size = New System.Drawing.Size(155, 20)
        Me.OperacionesConManagerToolStripMenuItem.Text = "Operaciones con Manager"
        '
        'ObtenerListaDePreciosToolStripMenuItem
        '
        Me.ObtenerListaDePreciosToolStripMenuItem.Enabled = False
        Me.ObtenerListaDePreciosToolStripMenuItem.Name = "ObtenerListaDePreciosToolStripMenuItem"
        Me.ObtenerListaDePreciosToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ObtenerListaDePreciosToolStripMenuItem.Text = "Obtener lista de precios"
        '
        'RequerimientosEnCertificaciónMenu
        '
        Me.RequerimientosEnCertificaciónMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DevolucionesPorMotivos, Me.FacturasRendidasVsPorRendir4, Me.VentasPendientes1, Me.ComprasVsDespacho2, Me.KpiToolStripMenuItem, Me.AbastecimientoParaPkToolStripMenuItem, Me.HomologacionToolStripMenuItem, Me.ListadoAbastecimeitnoToolStripMenuItem, Me.OrdenDePkToolStripMenuItem, Me.AlturaToolStripMenuItem})
        Me.RequerimientosEnCertificaciónMenu.Name = "RequerimientosEnCertificaciónMenu"
        Me.RequerimientosEnCertificaciónMenu.Size = New System.Drawing.Size(181, 20)
        Me.RequerimientosEnCertificaciónMenu.Text = "Requerimientos en certificación"
        '
        'DevolucionesPorMotivos
        '
        Me.DevolucionesPorMotivos.Enabled = False
        Me.DevolucionesPorMotivos.Name = "DevolucionesPorMotivos"
        Me.DevolucionesPorMotivos.Size = New System.Drawing.Size(248, 22)
        Me.DevolucionesPorMotivos.Text = "Devoluciones por motivos (3)"
        '
        'FacturasRendidasVsPorRendir4
        '
        Me.FacturasRendidasVsPorRendir4.Enabled = False
        Me.FacturasRendidasVsPorRendir4.Name = "FacturasRendidasVsPorRendir4"
        Me.FacturasRendidasVsPorRendir4.Size = New System.Drawing.Size(248, 22)
        Me.FacturasRendidasVsPorRendir4.Text = "Facturas rendidas vs por rendir (4)"
        '
        'VentasPendientes1
        '
        Me.VentasPendientes1.Enabled = False
        Me.VentasPendientes1.Name = "VentasPendientes1"
        Me.VentasPendientes1.Size = New System.Drawing.Size(248, 22)
        Me.VentasPendientes1.Text = "Ventas pendientes (1)"
        '
        'ComprasVsDespacho2
        '
        Me.ComprasVsDespacho2.Enabled = False
        Me.ComprasVsDespacho2.Name = "ComprasVsDespacho2"
        Me.ComprasVsDespacho2.Size = New System.Drawing.Size(248, 22)
        Me.ComprasVsDespacho2.Text = "Compras vs despacho (2)"
        '
        'KpiToolStripMenuItem
        '
        Me.KpiToolStripMenuItem.Name = "KpiToolStripMenuItem"
        Me.KpiToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.KpiToolStripMenuItem.Text = "kpi"
        '
        'AbastecimientoParaPkToolStripMenuItem
        '
        Me.AbastecimientoParaPkToolStripMenuItem.Name = "AbastecimientoParaPkToolStripMenuItem"
        Me.AbastecimientoParaPkToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AbastecimientoParaPkToolStripMenuItem.Text = "abastecimiento para pk"
        '
        'HomologacionToolStripMenuItem
        '
        Me.HomologacionToolStripMenuItem.Name = "HomologacionToolStripMenuItem"
        Me.HomologacionToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.HomologacionToolStripMenuItem.Text = "homologacion"
        Me.HomologacionToolStripMenuItem.Visible = False
        '
        'ListadoAbastecimeitnoToolStripMenuItem
        '
        Me.ListadoAbastecimeitnoToolStripMenuItem.Name = "ListadoAbastecimeitnoToolStripMenuItem"
        Me.ListadoAbastecimeitnoToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ListadoAbastecimeitnoToolStripMenuItem.Text = "listado abastecimeitno"
        '
        'OrdenDePkToolStripMenuItem
        '
        Me.OrdenDePkToolStripMenuItem.Name = "OrdenDePkToolStripMenuItem"
        Me.OrdenDePkToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.OrdenDePkToolStripMenuItem.Text = "orden de pk"
        '
        'InformesToolStripMenuItem
        '
        Me.InformesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmu_FillRate})
        Me.InformesToolStripMenuItem.Name = "InformesToolStripMenuItem"
        Me.InformesToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.InformesToolStripMenuItem.Text = "Informes"
        '
        'mmu_FillRate
        '
        Me.mmu_FillRate.Name = "mmu_FillRate"
        Me.mmu_FillRate.Size = New System.Drawing.Size(115, 22)
        Me.mmu_FillRate.Text = "Fill Rate"
        '
        'menuDesarrollos
        '
        Me.menuDesarrollos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListadoDeTablasGenericasToolStripMenuItem})
        Me.menuDesarrollos.Name = "menuDesarrollos"
        Me.menuDesarrollos.Size = New System.Drawing.Size(77, 20)
        Me.menuDesarrollos.Text = "Desarrollos"
        Me.menuDesarrollos.Visible = False
        '
        'ListadoDeTablasGenericasToolStripMenuItem
        '
        Me.ListadoDeTablasGenericasToolStripMenuItem.Name = "ListadoDeTablasGenericasToolStripMenuItem"
        Me.ListadoDeTablasGenericasToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ListadoDeTablasGenericasToolStripMenuItem.Text = "Listado de tablas Genericas"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 24)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(789, 4)
        Me.Panel4.TabIndex = 33
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.picD)
        Me.Panel2.Controls.Add(Me.picH)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Location = New System.Drawing.Point(0, 28)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(789, 23)
        Me.Panel2.TabIndex = 34
        '
        'picD
        '
        Me.picD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picD.Image = CType(resources.GetObject("picD.Image"), System.Drawing.Image)
        Me.picD.Location = New System.Drawing.Point(177, 1)
        Me.picD.Name = "picD"
        Me.picD.Size = New System.Drawing.Size(20, 18)
        Me.picD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picD.TabIndex = 3
        Me.picD.TabStop = False
        '
        'picH
        '
        Me.picH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picH.Image = CType(resources.GetObject("picH.Image"), System.Drawing.Image)
        Me.picH.Location = New System.Drawing.Point(149, 1)
        Me.picH.Name = "picH"
        Me.picH.Size = New System.Drawing.Size(20, 18)
        Me.picH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picH.TabIndex = 2
        Me.picH.TabStop = False
        Me.picH.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "MENU PRINCIPAL"
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.White
        Me.PanelMenu.Controls.Add(Me.TabControl1)
        Me.PanelMenu.Controls.Add(Me.Panel3)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 51)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(234, 482)
        Me.PanelMenu.TabIndex = 35
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(234, 424)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TreeMenu)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(226, 398)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Menú Sistema"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TreeMenu
        '
        Me.TreeMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeMenu.ImageIndex = 0
        Me.TreeMenu.ImageList = Me.ImageList1
        Me.TreeMenu.Location = New System.Drawing.Point(3, 3)
        Me.TreeMenu.Name = "TreeMenu"
        Me.TreeMenu.SelectedImageIndex = 0
        Me.TreeMenu.Size = New System.Drawing.Size(220, 392)
        Me.TreeMenu.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder-3-16.ico")
        Me.ImageList1.Images.SetKeyName(1, "application_form.gif")
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(226, 398)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Favoritos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 424)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(234, 58)
        Me.Panel3.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(234, 58)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'AlturaToolStripMenuItem
        '
        Me.AlturaToolStripMenuItem.Name = "AlturaToolStripMenuItem"
        Me.AlturaToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AlturaToolStripMenuItem.Text = "altura"
        Me.AlturaToolStripMenuItem.Visible = False
        '
        'frmDesktop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 555)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmDesktop"
        Me.Text = "DESKTOP - SISTEMA FAVATEX"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMenu.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SistemaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TreeMenu As TreeView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents picH As PictureBox
    Friend WithEvents picD As PictureBox
    Friend WithEvents mnu_cambio_contrasena As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnu_ingreso_usuarios As ToolStripMenuItem
    Friend WithEvents mnu_listado_usuario As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents mnu_asigna_privilegios As ToolStripMenuItem
    Friend WithEvents MantenedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnu_listado_productos As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents mnu_listado_categoria As ToolStripMenuItem
    Friend WithEvents mnu_listado_subcategoria As ToolStripMenuItem
    Friend WithEvents mnu_listado_color As ToolStripMenuItem
    Friend WithEvents mnu_listado_umedida As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents mnu_listado_tipo_documento As ToolStripMenuItem
    Friend WithEvents mnu_listado_tipo_multimedia As ToolStripMenuItem
    Friend WithEvents mnu_listado_calidad As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents mnu_listado_bodega As ToolStripMenuItem
    Friend WithEvents txtUsuarioActual As ToolStripStatusLabel
    Friend WithEvents txtServidor As ToolStripStatusLabel
    Friend WithEvents txtBase As ToolStripStatusLabel
    Friend WithEvents txtVersion As ToolStripStatusLabel
    Friend WithEvents mnu_listado_cartera As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents frm_asocia_producto_bodega As ToolStripMenuItem
    Friend WithEvents mnu_tipo_de_vehiculo As ToolStripMenuItem
    Friend WithEvents mnu_vehiculos As ToolStripMenuItem
    Friend WithEvents mnu_productos_reemplazo As ToolStripMenuItem
    Friend WithEvents mnu_tipodevolucion As ToolStripMenuItem
    Friend WithEvents mnu_segmento As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As ToolStripSeparator
    Friend WithEvents mnu_ubicaciones As ToolStripMenuItem
    Friend WithEvents mnu_configura_ubicacion_bodega As ToolStripMenuItem
    Friend WithEvents mnu_zona As ToolStripMenuItem
    Friend WithEvents mnu_TipoDeUbicaciones As ToolStripMenuItem
    Friend WithEvents mnu_transportista As ToolStripMenuItem
    Friend WithEvents mnu_pallet As ToolStripMenuItem
    Friend WithEvents OperacionesConManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObtenerListaDePreciosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequerimientosEnCertificaciónMenu As ToolStripMenuItem
    Friend WithEvents DevolucionesPorMotivos As ToolStripMenuItem
    Friend WithEvents FacturasRendidasVsPorRendir4 As ToolStripMenuItem
    Friend WithEvents VentasPendientes1 As ToolStripMenuItem
    Friend WithEvents ComprasVsDespacho2 As ToolStripMenuItem
    Friend WithEvents KpiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuArea As ToolStripMenuItem
    Friend WithEvents mnu_glosa As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripSeparator
    Friend WithEvents mmu_motivocierre As ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mmu_FillRate As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents AbastecimientoParaPkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HomologacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListadoAbastecimeitnoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrdenDePkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menuDesarrollos As ToolStripMenuItem
    Friend WithEvents ListadoDeTablasGenericasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlturaToolStripMenuItem As ToolStripMenuItem
End Class
