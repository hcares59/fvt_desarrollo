Module Generales
    Public Enum ESTADOS_PICKING
        Pendiente = 1
        Por_confirmar = 2
        Generado = 3
        En_proceso = 4
        Finalizado_con_diferenia = 5
        Finalizado_sin_diferencia = 6
        Enviado_a_facturar = 7
        Enviado_a_despachar = 8
        Despachado = 9
        Por_aprobar = 10
        Rechazado = 11
        Nulo = 12
        Facturado_parcial = 13
    End Enum

    Public Enum CODIGO_LOG_EVENTOS
        LOG_ERROR = 1
        LOG_INFORMACION = 2
        LOG_ADVERTENCIA = 3
    End Enum

    Public Enum ESTADOS_CITAS
        AGENDADA = 1
        PROCESADA = 2
    End Enum

    Public Enum ESTADOS_AGENDA
        POR_CONFIRMAR = 1
        AGENDADA = 2
        PROCESADA = 3
    End Enum

    Public Enum TIPO_MOVIMIENTO
        ENTRADA = 1
        SALIDA = 2
        TRASPASO = 3
    End Enum

    Public Enum TIPO_PICKING
        VENTA_VERDE = 1
        PREDISTRIBUIDA = 2
        STOCK = 3
        DIRECTO_TIENDA = 4
        INTERNET = 5
    End Enum

    Public Enum COM_TIPO_DOCUMENTO
        FACTURA_DE_COMPRA = 1
        GUIA_DESPACHO_PROVEEDOR = 2
        FACTURA_DE_VENTA = 3
        VALE_DE_INGRESO = 4
        VALE_DE_SALIDA = 5
        RECEPCION = 6
    End Enum

    Public Enum ESTADO_UBICACION
        DISPONIBLE = 1
        OCUPADO = 2
        RESERVADO = 3
    End Enum

    Public Enum ESTADO_ORDEN_COMPRA_PROVEEDOR
        PENDIENTE = 1
        EN_TRANSITO = 2
        ARRIBADA = 3
        ANULADA = 4
        ASIGNADA = 5
        CIERRE_MANUAL = 6
    End Enum

    Public Enum ESTADO_RECEPCION
        EN_PROCESO = 1
        FINALIZADA_SIN_DIFERENCIA = 2
        FINALIZADA_CON_DIFERENCIA = 3
        APROBADA_POR_BODEGA = 4
        ASIGNADA_PARA_ALMACENAR = 5
        ALMACENADA_PARCIAL = 6
        ALMACENADA_COMPLETA = 7
    End Enum

    Public Enum ESTADO_ALMACENAMIENTO
        PENDIENTE = 1
        EN_PROCESO = 2
        PARCIAL = 3
        COMPLETO = 4
    End Enum

    Public Enum ESTADO_ASIGNACION
        ASIGNACION_GENERADA = 1
        PENDIENTE_DE_APROBACIÓN = 2
        APROBADA_POR_BODEGA = 3
    End Enum

    Public Enum BODEGAS
        BOD_PRODUCTO_TERMINADO = 4
    End Enum

    Public Enum UBICACION
        PISO_PRODUCTO_TERMINADO = 3937
    End Enum

    Public Enum ESTADO_ORDEN_REABASTECIMIENTO
        PENDIENTE = 1
        FINALIZADA = 2
    End Enum

    Public Enum ESTADO_ORDEN_BUSQUEDA_PICKING
        GENERADA = 1
        PROCESADA = 2
        FINALIZADA = 3
        APROBADA = 4
        RECHAZADA = 5
    End Enum

    Public Enum CLIENTES
        SODIMAC = 1
        HOMY = 2
        HITES = 3
        FALABELLA = 4
        EASY = 5
        PARIS = 6
        CORONA = 7
        LIDER = 8
        RIPLEY = 9
        CLIENTE_GENERICO = 17
        ABCDIN = 24
        VENTA_BODEGA_FAVATEX = 26
        SODIMAC_VICENTI = 29
        CLIENTE_DESARROLLO = 31
        LA_POLAR = 98
        LIQUIDADORA_FAVATEX = 105
    End Enum

    Public Enum TABLAS_GENERICAS
        DIAS_PAGO = 1
        PAGO_DE_FACTURA = 2
        CONDICION_DE_PAGO = 3
        EMPRESA_DE_TRANSPORTE = 4
        EMPRESA_DE_DESCARGA = 5
        BANCOS = 6
        DIAS_PAGO_BANCO = 7
        AGENCIA_DE_ADUANA = 8
    End Enum

    Public Enum CORRELATIVOS
        IMPORTACIONES = 1
    End Enum

End Module
