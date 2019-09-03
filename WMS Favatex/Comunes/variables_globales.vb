Module variables_globales
    Public GLO_PRUEBA_DESARROLLO As Boolean = 0


    Public GLO_FECHA_SISTEMA As Date
    Public GLO_USUARIO_ACTUAL As Integer
    Public GLO_USUARIO_PASS As String
    Public GLO_PERSONA_NUMERO As Integer
    Public GLO_PERSONA_NOMBRE As String
    Public GLO_PERSONA_CARGO As String

    Public GLO_CODIGO_PRODUCTOS As Integer
    Public GLO_CANTIDAD_PRODUCTOS As Integer
    Public GLO_NOMBRE_PRODUCTOS As String
    Public GLO_CODIGO_INTERNO As String
    Public GLO_NUMERO_BULTOS_PRODUCTOS As Integer

    Public GLO_VALOR_IVA As Double = 0.19

    Public pasoHasta_doc As String = "T:\Repositorio\Doc\"
    Public pasoHasta_mul As String = "T:\Repositorio\Multi\"
    Public pasoDocumentosResepcion As String = "T:\Repositorio\adjuntos\recepciones\"
    Public pasoDocumentosOrdenCompra As String = "T:\Repositorio\adjuntos\OrdenCompra\"
    Public carpetaProveedores As String = "Q:\Documentos\"

    Public strRutaIngformes As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\"
    Public strRutaIngformesExcel As String = System.AppDomain.CurrentDomain.BaseDirectory() + "excel\"
    Public strRutaEtiquetas As String = "C:\Etiquetas\"

    Public pubServidor As String
    Public pubBaseDato As String
    Public pubUsuario As String
    Public pubContrasena As String

    Public USU_ASIGNA_PIKING As Boolean
    Public USU_FINALIZA_PIKING As Boolean
    Public USU_ENVIA_FACTURAR_PIKING As Boolean
    'Public USU_ASIGNA_PIKING As Boolean

    Public USU_ASIGNA_PARA_RECEPCION As Boolean
    Public USU_EJECUTA_RECEPCION As Boolean

    Public USU_ASIGNA_PARA_ALMACENAMIENTO As Boolean
    Public USU_EJECUTA_ALMACENAMIENTO As Boolean

    'Definicion de roles
    Public ES_COMERCILA As Boolean
    Public ES_DISENO As Boolean

    Public GLO_NUMERO_PICKING As Integer
    Public GLO_BUSQUEDA_PICKING_DESDE As String

    'Bodegas por defecto
    Public GLO_BODEGA_RECEPCION As Integer
    Public GLO_UBI_PISO_RECEPCION As Integer = 101
    Public GLO_UBI_PISO_PRODUCTO_TERMINADO As Integer = 3937
    Public GLO_UBI_PISO_SORTING_PICKEO As Integer = 3938
    Public GLO_UBI_PISO_SORTING_PALETIZADO As Integer = 3939
    Public GLO_UBI_PISO_PRODUCTOS_EXTRAVIADOS As Integer = 3940

    Public GLO_BODEGA_SSTT As Integer = 11
    Public GLO_BODEGA_CALIDAD As Integer = 18
    Public GLO_BODEGA_PRODUCTO_TERMINADO As Integer = 4

    Public listaDetalleProductos As List(Of estructura_dev_productos)
    Public listaPalletPickeado As List(Of estructura_pallet)
    Public listaPalletPickeadoAuxiliar As List(Of estructura_pallet)

    Public GLO_CANTIDAD_UNIDADES_SELECCIONADAS As Integer

    'Informes KPI
    Public GLO_INF_VENTAS_PENDIENTES As Integer = 1
    Public GLO_INF_FACTURAS_RENDIDAS_VS_POR_RENDIR As Integer = 3
    Public GLO_INF_COMPRAS_VS_DESPACHO As Integer = 4

    Public GLO_ACCION_EJECUTADA As Boolean = False

    Public _nuevaCantidadActualizada As Integer = 0
    Public _distintoPallet As Boolean = False
    Public _distintaCantidad As Boolean = False
    Public _palletPiso As String = ""


End Module
