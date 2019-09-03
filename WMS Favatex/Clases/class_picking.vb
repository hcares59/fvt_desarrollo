Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_picking
    Private _cnn As String
    Private _pic_codigo As Integer
    Private _pic_fecha As Date
    Private _car_codigo As Integer
    Private _bod_codigo As Integer
    Private _usu_codigo As Integer
    Private _cant_unidades As Integer
    Private _cant_bultos As Integer
    Private _total_bultos As Integer
    Private _pic_hora As String
    Private _epc_codigo As Integer
    Private _pic_cantidad_encontrada As Integer
    Private _pic_num_bultos_encontrado As Integer
    Private _pic_total_bultos_encontrado As Integer
    Private _pic_ocnumero As Long
    Private _pic_fechaoc As Date

    Private _pic_fila As Integer
    Private _pro_codigo As String
    Private _pro_nombre As String
    Private _pic_cantidad As Integer
    Private _pic_num_bultos As Integer
    Private _pic_total_bultos As Integer
    Private _precio As Long
    Private _pro_codigooriginal As Integer
    Private _observaciones As String
    Private _pic_fechaocoriginal As Date
    Private _pic_semodificafecha As Boolean


    Private _sku_cartera As String
    Private _sku_cartera_nombre As String

    Private _lpi_descripcion As String


    Private _fecha_ingreso_desde As String
    Private _fecha_ingreso_hasta As String
    Private _fecha_entrega_desde As String
    Private _fecha_entrega_hasta As String
    Private _fecha_factura_desde As String
    Private _fecha_factura_hasta As String

    Private _per_codigoresponsable As Integer
    Private _nuevaFila As Boolean
    Private _con_codigounico As String

    Private _con_despacharanumero As String
    Private _con_despachara As String
    Private _con_local As String
    Private _con_localnombre As String
    Private _rut_cliente As String
    Private _nombre_cliente As String
    Private _con_observacion As String

    Private _hora_inicio As String
    Private _hora_termino As String

    Private _con_ocnumero As Long
    Private _con_skucliente As String
    Private _con_fila As Integer
    Private _cit_codigo As Integer
    Private _cantidad As Integer
    Private _cantidad_bultos As Integer

    Private _pic_desdeagendable As Boolean
    Private _age_codigo As Integer

    Private _usu_anulaorden As Integer
    Private _cop_ocpnumero As Long
    Private _cop_idimpresion As Integer
    Private _dpp_fila As Integer

    Private _tpi_codigo As Integer
    Private _tet_codigo As String
    Private _fecha_inicio As String
    Private _fecha_termino As String

    Private _nguia As Long
    Private _pdd_fila As Integer
    Private _todos As Boolean
    Private _pic_fechafactura As String
    Private _fac_numero As Long

    Private _fecha_guias_desde As String
    Private _fecha_guias_hasta As String
    Private _gde_numero As Long
    Private _gde_fecha As String

    Private _oc_procesadas As Integer
    Private _LugarDespacho As String
    Private _strCadena As String
    Private _bul_codigo As Integer

    Private _StrCadenaPK As String
    Private _StrProductosPK As String

    '-----------------------------------------------------------------------
    '----------------------- Asignacion de PK ------------------------------
    '-----------------------------------------------------------------------
    Private _abp_codigo As Integer
    Private _abp_fecha As Date
    Private _abp_pikasociados As String
    Private _abp_estado As Integer

    Private _apd_fila As Integer
    Private _pro_codigointerno As String
    Private _cantidad_requerida As Integer
    Private _cod_bulto As Integer
    Private _bulto As String
    Private _ubi_codigo As String
    Private _ubi_nombre As String
    Private _pallet As String
    Private _cantidad_en_pallet As Integer
    Private _preocesada As Boolean
    Private _cantidad_confirmada As Integer

    Public Property apd_fila() As Integer
        Get
            Return _apd_fila
        End Get
        Set(ByVal value As Integer)
            _apd_fila = value
        End Set
    End Property
    Public Property pro_codigointerno() As String
        Get
            Return _pro_codigointerno
        End Get
        Set(ByVal value As String)
            _pro_codigointerno = value
        End Set
    End Property
    Public Property cantidad_requerida() As Integer
        Get
            Return _cantidad_requerida
        End Get
        Set(ByVal value As Integer)
            _cantidad_requerida = value
        End Set
    End Property
    Public Property cod_bulto() As Integer
        Get
            Return _cod_bulto
        End Get
        Set(ByVal value As Integer)
            _cod_bulto = value
        End Set
    End Property
    Public Property bulto() As String
        Get
            Return _bulto
        End Get
        Set(ByVal value As String)
            _bulto = value
        End Set
    End Property
    Public Property ubi_codigo() As String
        Get
            Return _ubi_codigo
        End Get
        Set(ByVal value As String)
            _ubi_codigo = value
        End Set
    End Property
    Public Property ubi_nombre() As String
        Get
            Return _ubi_nombre
        End Get
        Set(ByVal value As String)
            _ubi_nombre = value
        End Set
    End Property
    Public Property pallet() As String
        Get
            Return _pallet
        End Get
        Set(ByVal value As String)
            _pallet = value
        End Set
    End Property
    Public Property cantidad_en_pallet() As Integer
        Get
            Return _cantidad_en_pallet
        End Get
        Set(ByVal value As Integer)
            _cantidad_en_pallet = value
        End Set
    End Property
    Public Property preocesada() As Boolean
        Get
            Return _preocesada
        End Get
        Set(ByVal value As Boolean)
            _preocesada = value
        End Set
    End Property
    Public Property cantidad_confirmada() As Integer
        Get
            Return _cantidad_confirmada
        End Get
        Set(ByVal value As Integer)
            _cantidad_confirmada = value
        End Set
    End Property

    Public Property abp_codigo() As Integer
        Get
            Return _abp_codigo
        End Get
        Set(ByVal value As Integer)
            _abp_codigo = value
        End Set
    End Property
    Public Property abp_fecha() As Date
        Get
            Return _abp_fecha
        End Get
        Set(ByVal value As Date)
            _abp_fecha = value
        End Set
    End Property
    Public Property abp_pikasociados() As String
        Get
            Return _abp_pikasociados
        End Get
        Set(ByVal value As String)
            _abp_pikasociados = value
        End Set
    End Property
    Public Property abp_estado() As Integer
        Get
            Return _abp_estado
        End Get
        Set(ByVal value As Integer)
            _abp_estado = value
        End Set
    End Property

    Public Property StrCadenaPK() As String
        Get
            Return _StrCadenaPK
        End Get
        Set(ByVal value As String)
            _StrCadenaPK = value
        End Set
    End Property
    Public Property StrProductosPK() As String
        Get
            Return _StrProductosPK
        End Get
        Set(ByVal value As String)
            _StrProductosPK = value
        End Set
    End Property
    Public Property bul_codigo() As Integer
        Get
            Return _bul_codigo
        End Get
        Set(ByVal value As Integer)
            _bul_codigo = value
        End Set
    End Property
    Public Property strCadena() As String
        Get
            Return _strCadena
        End Get
        Set(ByVal value As String)
            _strCadena = value
        End Set
    End Property
    Public Property LugarDespacho() As String
        Get
            Return _LugarDespacho
        End Get
        Set(ByVal value As String)
            _LugarDespacho = value
        End Set
    End Property

    Public Property oc_procesadas() As Integer
        Get
            Return _oc_procesadas
        End Get
        Set(ByVal value As Integer)
            _oc_procesadas = value
        End Set
    End Property
    Public Property gde_fecha() As String
        Get
            Return _gde_fecha
        End Get
        Set(ByVal value As String)
            _gde_fecha = value
        End Set
    End Property
    Public Property gde_numero() As Long
        Get
            Return _gde_numero
        End Get
        Set(ByVal value As Long)
            _gde_numero = value
        End Set
    End Property
    Public Property fecha_guias_hasta() As String
        Get
            Return _fecha_guias_hasta
        End Get
        Set(ByVal value As String)
            _fecha_guias_hasta = value
        End Set
    End Property
    Public Property fecha_guias_desde() As String
        Get
            Return _fecha_guias_desde
        End Get
        Set(ByVal value As String)
            _fecha_guias_desde = value
        End Set
    End Property

    Public Property fecha_factura_desde() As String
        Get
            Return _fecha_factura_desde
        End Get
        Set(ByVal value As String)
            _fecha_factura_desde = value
        End Set
    End Property
    Public Property fecha_factura_hasta() As String
        Get
            Return _fecha_factura_hasta
        End Get
        Set(ByVal value As String)
            _fecha_factura_hasta = value
        End Set
    End Property

    Public Property fac_numero() As Long
        Get
            Return _fac_numero
        End Get
        Set(ByVal value As Long)
            _fac_numero = value
        End Set
    End Property


    Public Property pic_fechafactura() As String
        Get
            Return _pic_fechafactura
        End Get
        Set(ByVal value As String)
            _pic_fechafactura = value
        End Set
    End Property

    Public Property todos() As Boolean
        Get
            Return _todos
        End Get
        Set(ByVal value As Boolean)
            _todos = value
        End Set
    End Property
    Public Property nguia() As Long
        Get
            Return _nguia
        End Get
        Set(ByVal value As Long)
            _nguia = value
        End Set
    End Property
    Public Property pdd_fila() As Integer
        Get
            Return _pdd_fila
        End Get
        Set(ByVal value As Integer)
            _pdd_fila = value
        End Set
    End Property

    Public Property fecha_inicio() As String
        Get
            Return _fecha_inicio
        End Get
        Set(ByVal value As String)
            _fecha_inicio = value
        End Set
    End Property
    Public Property fecha_termino As String
        Get
            Return _fecha_termino
        End Get
        Set(ByVal value As String)
            _fecha_termino = value
        End Set
    End Property
    Public Property tet_codigo() As String
        Get
            Return _tet_codigo
        End Get
        Set(ByVal value As String)
            _tet_codigo = value
        End Set
    End Property
    Public Property tpi_codigo() As Integer
        Get
            Return _tpi_codigo
        End Get
        Set(ByVal value As Integer)
            _tpi_codigo = value
        End Set
    End Property

    Public Property dpp_fila() As Integer
        Get
            Return _dpp_fila
        End Get
        Set(ByVal value As Integer)
            _dpp_fila = value
        End Set
    End Property
    Public Property cop_ocpnumero() As Integer
        Get
            Return _cop_ocpnumero
        End Get
        Set(ByVal value As Integer)
            _cop_ocpnumero = value
        End Set
    End Property

    Public Property cop_idimpresion() As Integer
        Get
            Return _cop_idimpresion
        End Get
        Set(ByVal value As Integer)
            _cop_idimpresion = value
        End Set
    End Property

    Public Property usu_anulaorden() As Integer
        Get
            Return _usu_anulaorden
        End Get
        Set(ByVal value As Integer)
            _usu_anulaorden = value
        End Set
    End Property

    Public Property age_codigo() As Integer
        Get
            Return _age_codigo
        End Get
        Set(ByVal value As Integer)
            _age_codigo = value
        End Set
    End Property

    Public Property pic_desdeagendable() As Boolean
        Get
            Return _pic_desdeagendable
        End Get
        Set(ByVal value As Boolean)
            _pic_desdeagendable = value
        End Set
    End Property

    Public Property con_ocnumero() As Long
        Get
            Return _con_ocnumero
        End Get
        Set(ByVal value As Long)
            _con_ocnumero = value
        End Set
    End Property
    Public Property con_skucliente() As String
        Get
            Return _con_skucliente
        End Get
        Set(ByVal value As String)
            _con_skucliente = value
        End Set
    End Property
    Public Property con_fila() As Integer
        Get
            Return _con_fila
        End Get
        Set(ByVal value As Integer)
            _con_fila = value
        End Set
    End Property
    Public Property cit_codigo() As Integer
        Get
            Return _cit_codigo
        End Get
        Set(ByVal value As Integer)
            _cit_codigo = value
        End Set
    End Property
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
    Public Property cantidad_bultos() As Integer
        Get
            Return _cantidad_bultos
        End Get
        Set(ByVal value As Integer)
            _cantidad_bultos = value
        End Set
    End Property

    Public Property hora_inicio() As String
        Get
            Return _hora_inicio
        End Get
        Set(ByVal value As String)
            _hora_inicio = value
        End Set
    End Property
    Public Property hora_termino() As String
        Get
            Return _hora_termino
        End Get
        Set(ByVal value As String)
            _hora_termino = value
        End Set
    End Property

    Public Property pic_semodificafecha() As Boolean
        Get
            Return _pic_semodificafecha
        End Get
        Set(ByVal value As Boolean)
            _pic_semodificafecha = value
        End Set
    End Property
    Public Property pic_fechaocoriginal() As Date
        Get
            Return _pic_fechaocoriginal
        End Get
        Set(ByVal value As Date)
            _pic_fechaocoriginal = value
        End Set
    End Property

    Public Property con_despacharanumero() As String
        Get
            Return _con_despacharanumero
        End Get
        Set(ByVal value As String)
            _con_despacharanumero = value
        End Set
    End Property
    Public Property con_despachara() As String
        Get
            Return _con_despachara
        End Get
        Set(ByVal value As String)
            _con_despachara = value
        End Set
    End Property
    Public Property con_local() As String
        Get
            Return _con_local
        End Get
        Set(ByVal value As String)
            _con_local = value
        End Set
    End Property
    Public Property con_localnombre() As String
        Get
            Return _con_localnombre
        End Get
        Set(ByVal value As String)
            _con_localnombre = value
        End Set
    End Property
    Public Property rut_cliente() As String
        Get
            Return _rut_cliente
        End Get
        Set(ByVal value As String)
            _rut_cliente = value
        End Set
    End Property
    Public Property nombre_cliente() As String
        Get
            Return _nombre_cliente
        End Get
        Set(ByVal value As String)
            _nombre_cliente = value
        End Set
    End Property
    Public Property con_observacion() As String
        Get
            Return _con_observacion
        End Get
        Set(ByVal value As String)
            _con_observacion = value
        End Set
    End Property


    Public Property con_codigounico() As String
        Get
            Return _con_codigounico
        End Get
        Set(ByVal value As String)
            _con_codigounico = value
        End Set
    End Property


    Public Property nuevaFila() As Boolean
        Get
            Return _nuevaFila
        End Get
        Set(ByVal value As Boolean)
            _nuevaFila = value
        End Set
    End Property


    Public Property pic_num_bultos() As Integer
        Get
            Return _pic_num_bultos
        End Get
        Set(ByVal value As Integer)
            _pic_num_bultos = value
        End Set
    End Property
    Public Property pic_fila() As Integer
        Get
            Return _pic_fila
        End Get
        Set(ByVal value As Integer)
            _pic_fila = value
        End Set
    End Property
    Public Property pro_codigooriginal() As Integer
        Get
            Return _pro_codigooriginal
        End Get
        Set(ByVal value As Integer)
            _pro_codigooriginal = value
        End Set
    End Property
    Public Property observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property

    'Public Property per_codigoresponsable() As Long
    '    Get
    '        Return _per_codigoresponsable
    '    End Get
    '    Set(ByVal value As Long)
    '        _per_codigoresponsable = value
    '    End Set
    'End Property

    Public Property per_codigoresponsable() As Integer
        Get
            Return _per_codigoresponsable
        End Get
        Set(ByVal value As Integer)
            _per_codigoresponsable = value
        End Set
    End Property

    Public Property pic_ocnumero() As Long
        Get
            Return _pic_ocnumero
        End Get
        Set(ByVal value As Long)
            _pic_ocnumero = value
        End Set
    End Property
    Public Property pic_fechaoc() As Date
        Get
            Return _pic_fechaoc
        End Get
        Set(ByVal value As Date)
            _pic_fechaoc = value
        End Set
    End Property

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Public Property pic_codigo() As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
        End Set
    End Property
    Public Property pic_fecha() As Date
        Get
            Return _pic_fecha
        End Get
        Set(ByVal value As Date)
            _pic_fecha = value
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
    Public Property bod_codigo() As Integer
        Get
            Return _bod_codigo
        End Get
        Set(ByVal value As Integer)
            _bod_codigo = value
        End Set
    End Property
    Public Property usu_codigo() As Integer
        Get
            Return _usu_codigo
        End Get
        Set(ByVal value As Integer)
            _usu_codigo = value
        End Set
    End Property
    Public Property cant_unidades() As Integer
        Get
            Return _cant_unidades
        End Get
        Set(ByVal value As Integer)
            _cant_unidades = value
        End Set
    End Property
    Public Property cant_bultos() As Integer
        Get
            Return _cant_bultos
        End Get
        Set(ByVal value As Integer)
            _cant_bultos = value
        End Set
    End Property
    Public Property total_bultos() As Integer
        Get
            Return _total_bultos
        End Get
        Set(ByVal value As Integer)
            _total_bultos = value
        End Set
    End Property
    Public Property pic_hora() As String
        Get
            Return _pic_hora
        End Get
        Set(ByVal value As String)
            _pic_hora = value
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
    Public Property pic_cantidad_encontrada() As Integer
        Get
            Return _pic_cantidad_encontrada
        End Get
        Set(ByVal value As Integer)
            _pic_cantidad_encontrada = value
        End Set
    End Property
    Public Property pic_num_bultos_encontrado() As Integer
        Get
            Return _pic_num_bultos_encontrado
        End Get
        Set(ByVal value As Integer)
            _pic_num_bultos_encontrado = value
        End Set
    End Property
    Public Property pic_total_bultos_encontrado() As Integer
        Get
            Return _pic_total_bultos_encontrado
        End Get
        Set(ByVal value As Integer)
            _pic_total_bultos_encontrado = value
        End Set
    End Property
    Public Property pro_codigo() As String
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As String)
            _pro_codigo = value
        End Set
    End Property
    Public Property pro_nombre() As String
        Get
            Return _pro_nombre
        End Get
        Set(ByVal value As String)
            _pro_nombre = value
        End Set
    End Property
    Public Property sku_cartera() As String
        Get
            Return _sku_cartera
        End Get
        Set(ByVal value As String)
            _sku_cartera = value
        End Set
    End Property
    Public Property sku_cartera_nombre() As String
        Get
            Return _sku_cartera_nombre
        End Get
        Set(ByVal value As String)
            _sku_cartera_nombre = value
        End Set
    End Property
    Public Property pic_cantidad() As Integer
        Get
            Return _pic_cantidad
        End Get
        Set(ByVal value As Integer)
            _pic_cantidad = value
        End Set
    End Property
    Public Property pic_total_bultos() As Integer
        Get
            Return _pic_total_bultos
        End Get
        Set(ByVal value As Integer)
            _pic_total_bultos = value
        End Set
    End Property
    Public Property precio() As Long
        Get
            Return _precio
        End Get
        Set(ByVal value As Long)
            _precio = value
        End Set
    End Property

    Public Property lpi_descripcion() As String
        Get
            Return _lpi_descripcion
        End Get
        Set(ByVal value As String)
            _lpi_descripcion = value
        End Set
    End Property

    Public Property fecha_ingreso_desde() As String
        Get
            Return _fecha_ingreso_desde
        End Get
        Set(ByVal value As String)
            _fecha_ingreso_desde = value
        End Set
    End Property
    Public Property fecha_ingreso_hasta() As String
        Get
            Return _fecha_ingreso_hasta
        End Get
        Set(ByVal value As String)
            _fecha_ingreso_hasta = value
        End Set
    End Property
    Public Property fecha_entrega_desde() As String
        Get
            Return _fecha_entrega_desde
        End Get
        Set(ByVal value As String)
            _fecha_entrega_desde = value
        End Set
    End Property
    Public Property fecha_entrega_hasta() As String
        Get
            Return _fecha_entrega_hasta
        End Get
        Set(ByVal value As String)
            _fecha_entrega_hasta = value
        End Set
    End Property

    Public Function PICKING_GUARDA_DATOS_ENCABEZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_encabezado_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fecha", SqlDbType.Date)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@cant_unidades", SqlDbType.Int)
            command.Parameters.Add("@cant_bultos", SqlDbType.Int)
            command.Parameters.Add("@total_bultos", SqlDbType.Int)
            command.Parameters.Add("@pic_hora", SqlDbType.NVarChar)
            command.Parameters.Add("@epc_codigo", SqlDbType.Int)
            command.Parameters.Add("@cant_unidades_encontradas", SqlDbType.Int)
            command.Parameters.Add("@cant_bultos_encontrado", SqlDbType.Int)
            command.Parameters.Add("@total_bultos_encontrados", SqlDbType.Int)
            command.Parameters.Add("@pic_desdeagendable", SqlDbType.Bit)
            command.Parameters.Add("@tpi_codigo", SqlDbType.Int)
            command.Parameters.Add("@LugarDespacho", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fecha
            command.Parameters(2).Value = _car_codigo
            command.Parameters(3).Value = _usu_codigo
            command.Parameters(4).Value = _cant_unidades
            command.Parameters(5).Value = _cant_bultos
            command.Parameters(6).Value = _total_bultos
            command.Parameters(7).Value = _pic_hora
            command.Parameters(8).Value = _epc_codigo
            command.Parameters(9).Value = _pic_cantidad_encontrada
            command.Parameters(10).Value = _pic_num_bultos_encontrado
            command.Parameters(11).Value = _pic_total_bultos_encontrado
            command.Parameters(12).Value = _pic_desdeagendable
            command.Parameters(13).Value = _tpi_codigo
            command.Parameters(14).Value = _LugarDespacho


            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_GUARDA_ENTREGAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_inv_consolidadoarchivo_entregas_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@con_skucliente", SqlDbType.NVarChar)
            command.Parameters.Add("@con_fila", SqlDbType.Int)
            command.Parameters.Add("@cit_codigo", SqlDbType.Int)
            command.Parameters.Add("@cantidad", SqlDbType.Int)
            command.Parameters.Add("@cantidad_bultos", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _con_ocnumero
            command.Parameters(2).Value = _con_skucliente
            command.Parameters(3).Value = _con_fila
            command.Parameters(4).Value = _cit_codigo
            command.Parameters(5).Value = _cantidad
            command.Parameters(6).Value = _cantidad_bultos
            command.Parameters(7).Value = _pic_codigo
            command.Parameters(8).Value = _pic_fila

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_GUARDA_ENTREGAS_AGENDA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_inv_consolidadoarchivo_entregas_agenda_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@con_skucliente", SqlDbType.NVarChar)
            command.Parameters.Add("@con_fila", SqlDbType.Int)
            command.Parameters.Add("@age_codigo", SqlDbType.Int)
            command.Parameters.Add("@cantidad", SqlDbType.Int)
            command.Parameters.Add("@cantidad_bultos", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _con_ocnumero
            command.Parameters(2).Value = _con_skucliente
            command.Parameters(3).Value = _con_fila
            command.Parameters(4).Value = _age_codigo
            command.Parameters(5).Value = _cantidad
            command.Parameters(6).Value = _cantidad_bultos
            command.Parameters(7).Value = _pic_codigo
            command.Parameters(8).Value = _pic_fila

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_GUARDA_PICKING_ASOCIADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_inv_consolidadoarchivo_picking_asociado_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@con_skucliente", SqlDbType.NVarChar)
            command.Parameters.Add("@con_fila", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@cantidad", SqlDbType.Int)
            command.Parameters.Add("@cantidad_bultos", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _con_ocnumero
            command.Parameters(2).Value = _con_skucliente
            command.Parameters(3).Value = _con_fila
            command.Parameters(4).Value = _pic_codigo
            command.Parameters(5).Value = _cantidad
            command.Parameters(6).Value = _cantidad_bultos

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_ELIMINA_DATOS_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_detalle_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo
            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_GUARDA_DATOS_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_cartera", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_cartera_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@pic_cantidad", SqlDbType.Int)
            command.Parameters.Add("@pic_num_bultos", SqlDbType.Int)
            command.Parameters.Add("@pic_total_bultos", SqlDbType.Int)
            command.Parameters.Add("@precio", SqlDbType.Int)
            command.Parameters.Add("@pic_cantidad_encontrada", SqlDbType.Int)
            command.Parameters.Add("@pic_num_bultos_encontrado", SqlDbType.Int)
            command.Parameters.Add("@pic_total_bultos_encontrado", SqlDbType.Int)
            command.Parameters.Add("@pic_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@pic_fechaoc", SqlDbType.Date)
            command.Parameters.Add("@con_codigounico", SqlDbType.NVarChar)

            command.Parameters.Add("@con_despacharanumero", SqlDbType.NVarChar)
            command.Parameters.Add("@con_despachara", SqlDbType.NVarChar)
            command.Parameters.Add("@con_local", SqlDbType.NVarChar)
            command.Parameters.Add("@con_localnombre", SqlDbType.NVarChar)
            command.Parameters.Add("@rut_cliente", SqlDbType.NVarChar)
            command.Parameters.Add("@nombre_cliente", SqlDbType.NVarChar)
            command.Parameters.Add("@con_observacion", SqlDbType.NVarChar)
            command.Parameters.Add("@pic_fechaocoriginal", SqlDbType.Date)
            command.Parameters.Add("@pic_semodificafecha", SqlDbType.Bit)
            command.Parameters.Add("@dpp_fila", SqlDbType.Int)
            command.Parameters.Add("@con_fila", SqlDbType.Decimal)


            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _pro_nombre
            command.Parameters(3).Value = _sku_cartera
            command.Parameters(4).Value = _sku_cartera_nombre
            command.Parameters(5).Value = _cant_unidades
            command.Parameters(6).Value = _cant_bultos
            command.Parameters(7).Value = _pic_total_bultos
            command.Parameters(8).Value = _precio
            command.Parameters(9).Value = _pic_cantidad_encontrada
            command.Parameters(10).Value = _pic_num_bultos_encontrado
            command.Parameters(11).Value = _pic_total_bultos_encontrado
            command.Parameters(12).Value = _pic_ocnumero
            command.Parameters(13).Value = _pic_fechaoc
            command.Parameters(14).Value = _con_codigounico
            command.Parameters(15).Value = _con_despacharanumero
            command.Parameters(16).Value = _con_despachara
            command.Parameters(17).Value = _con_local
            command.Parameters(18).Value = _con_localnombre
            command.Parameters(19).Value = _rut_cliente
            command.Parameters(20).Value = _nombre_cliente
            command.Parameters(21).Value = _con_observacion
            command.Parameters(22).Value = _pic_fechaocoriginal
            command.Parameters(23).Value = _pic_semodificafecha
            command.Parameters(24).Value = _dpp_fila
            command.Parameters(25).Value = _con_fila


            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_GUARDA_LOG(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_pickin_log_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@lpi_descripcion", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)


            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _lpi_descripcion
            command.Parameters(2).Value = _usu_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_GUARDA_LOG(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_pickin_log_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@lpi_descripcion", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)


            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _lpi_descripcion
            command.Parameters(2).Value = _usu_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            'Dim command As New SqlCommand("sp_picking_listado", conexion)
            Dim command As New SqlCommand("sp_picking_listado_new", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@p_car_codigo", SqlDbType.Int)
            command.Parameters.Add("@p_fecha_ingreso_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@p_fecha_ingreso_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@p_fecha_entrega_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@p_fecha_entrega_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@p_epc_codigo", SqlDbType.Int)
            command.Parameters.Add("@p_oc_numero", SqlDbType.Float)
            command.Parameters.Add("@p_tpi_codigo", SqlDbType.Int)
            command.Parameters.Add("@p_pic_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_ingreso_desde
            command.Parameters(2).Value = _fecha_ingreso_hasta
            command.Parameters(3).Value = _fecha_entrega_desde
            command.Parameters(4).Value = _fecha_entrega_hasta
            command.Parameters(5).Value = _epc_codigo
            command.Parameters(6).Value = _pic_ocnumero
            command.Parameters(7).Value = _tpi_codigo
            command.Parameters(8).Value = _pic_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_LISTADO_SIN_CONSOLIDAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_listado_sin_consolidar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@fecha_compromiso", SqlDbType.NVarChar)
            command.Parameters.Add("@hora_inicio", SqlDbType.NVarChar)
            command.Parameters.Add("@hora_termino", SqlDbType.NVarChar)

            command.Parameters(0).Value = _fecha_entrega_desde
            command.Parameters(1).Value = _hora_inicio
            command.Parameters(2).Value = _hora_termino

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_LISTADO_PARA_ORDEN_ASIGNACION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_listado_para_generar_orden_asignacion_pk", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@fecha_compromiso", SqlDbType.NVarChar)
            command.Parameters(0).Value = _fecha_entrega_desde

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function SELECCIONA_PK_ASIGNACION_BUSQUEDA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_obtiene_num_pk_en_asignacion_de_busqueda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@strCadena", SqlDbType.NVarChar)
            command.Parameters.Add("@strProductos", SqlDbType.NVarChar)

            command.Parameters(0).Value = _StrCadenaPK
            command.Parameters(1).Value = _StrProductosPK

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function



    Public Function PICKING_LISTADO_PARA_ORDEN_ASIGNACION_DETALLE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_listado_para_generar_orden_asignacion_pk_detalle", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@strCadena", SqlDbType.NVarChar)
            command.Parameters(0).Value = _strCadena

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_OBTIENE_POSICIONES_PARA_ORDEN_ASIGNACION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            conexion.Open()
            Dim command As New SqlCommand("sp_obtiene_ubicaciones_para_orden_de_asignacion_para_pk", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@var_pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@var_bul_codigo", SqlDbType.Int)
            command.Parameters.Add("@var_cantidad", SqlDbType.Int)
            command.Parameters.Add("@adp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _bul_codigo
            command.Parameters(2).Value = _cantidad
            command.Parameters(3).Value = _abp_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)
            conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_OBTIENE_PRODUCTO_BULTO_PARA_PIKEO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_obtiene_producto_con_bultos_para_pikeo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo
            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function



    Public Function PICKING_LISTADO_VISOR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_listado_visor", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_entrega_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_entrega_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_entrega_desde
            command.Parameters(2).Value = _fecha_entrega_hasta
            command.Parameters(3).Value = _usu_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_LISTADO_DESPACHO_VISOR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_listado_despacho_visor", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_entrega_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_entrega_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_entrega_desde
            command.Parameters(2).Value = _fecha_entrega_hasta
            command.Parameters(3).Value = _usu_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_LISTADO_VISOR_FACTURACION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_listado_visor_facturacion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_entrega_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_entrega_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_entrega_desde
            command.Parameters(2).Value = _fecha_entrega_hasta
            command.Parameters(3).Value = _usu_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_LISTADO_VISOR_FACTURACION_DESDE_GUIA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_listado_visor_facturacion_desde_guia", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_entrega_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_entrega_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_entrega_desde
            command.Parameters(2).Value = _fecha_entrega_hasta
            command.Parameters(3).Value = _usu_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function


    Public Function PICKING_CARGA_ENCABEZADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_selecciona_picking_encabezado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_CARGA_DETALLE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_selecciona_picking_detalle", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_CARGA_LOG(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_selecciona_picking_log", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_CAMBIA_ESTDO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_cambia_estado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@epc_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _epc_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MARCA_CONSOLIDADO_PICKING(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_marca_consolidado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pic_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MARCA_CONSOLIDADO_PICKING_BUSQUEDA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_marca_consolidado_busqueda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pic_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_ACTUALIZA_ENCABEZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_piactualiza_encabezado_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_hora", SqlDbType.NVarChar)
            command.Parameters.Add("@per_codigoresponsable", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_hora
            command.Parameters(2).Value = _per_codigoresponsable

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_ACTUALIZA_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_actualiza_detalle_picking", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@pic_cantidad", SqlDbType.Int)
            command.Parameters.Add("@pic_num_bultos", SqlDbType.Int)
            command.Parameters.Add("@pic_total_bultos", SqlDbType.Float)
            command.Parameters.Add("@pic_cantidad_encontrada", SqlDbType.Int)
            command.Parameters.Add("@pic_num_bultos_encontrado", SqlDbType.Int)
            command.Parameters.Add("@pic_total_bultos_encontrado", SqlDbType.Int)
            command.Parameters.Add("@pro_codigooriginal", SqlDbType.Int)
            command.Parameters.Add("@observaciones", SqlDbType.NVarChar)
            command.Parameters.Add("@nuevaFila", SqlDbType.Bit)
            command.Parameters.Add("@sku_cartera", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_cartera_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@precio", SqlDbType.Float)
            command.Parameters.Add("@pic_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@pic_fechaoc", SqlDbType.Date)
            command.Parameters.Add("@con_codigounico", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fila
            command.Parameters(2).Value = _pro_codigo
            command.Parameters(3).Value = Replace(_pro_nombre, "'", "")
            command.Parameters(4).Value = _pic_cantidad
            command.Parameters(5).Value = _pic_num_bultos
            command.Parameters(6).Value = _pic_total_bultos
            command.Parameters(7).Value = _pic_cantidad_encontrada
            command.Parameters(8).Value = _pic_num_bultos_encontrado
            command.Parameters(9).Value = _pic_total_bultos_encontrado
            command.Parameters(10).Value = _pro_codigooriginal
            command.Parameters(11).Value = Replace(_observaciones, "'", "")
            command.Parameters(12).Value = _nuevaFila
            command.Parameters(13).Value = Replace(_sku_cartera, "'", "")
            command.Parameters(14).Value = Replace(_sku_cartera_nombre, "'", "")
            command.Parameters(15).Value = _precio
            command.Parameters(16).Value = _pic_ocnumero
            command.Parameters(17).Value = _pic_fechaoc
            command.Parameters(18).Value = _con_codigounico


            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_QUITA_FILA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_quita_fila_picking", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@Mensaje", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fila
            command.Parameters(2).Value = _observaciones

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_ANULA_ORDEN_COMPRA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_anula_orden_compra", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@oc_numero", SqlDbType.Float)
            command.Parameters.Add("@usu_anulaorden", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_ocnumero
            command.Parameters(2).Value = _usu_anulaorden

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_LISTADO_PICKING_DIARIO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_listado_picking_por_dia", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@fecha", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@epc_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _fecha_entrega_desde
            command.Parameters(1).Value = _fecha_entrega_hasta
            command.Parameters(2).Value = _pic_codigo
            command.Parameters(3).Value = _epc_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_ACTULIZA_DETALLE_PENDIENTE_FACTURA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_detalle_marca_pendiente_factura", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fila
            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_ETIQUETA_BUSCAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_busca_para_etiquetas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@tet_codigo", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _tet_codigo
            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_PRODUCTO_ETIQUETA_BUSCAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_busca_para_etiquetas_productos", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@tet_codigo", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _tet_codigo
            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_ETIQUETA_BUSCAR_CON_OC(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_con_ocbusca_para_etiquetas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function INGRESA_OC_ORDEN_PEDIDO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_guarda_orden_pedido_para_impresion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@cop_ocpnumero", SqlDbType.Float)
            command.Parameters.Add("@cop_idimpresion", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _pic_ocnumero
            command.Parameters(3).Value = _cop_ocpnumero
            command.Parameters(4).Value = _cop_idimpresion
            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function OBTIENE_ID_IMPRESION_ETIQUETA_ORDEN_PEDIDO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ultima_id_impresion", conexion)
            command.CommandType = CommandType.StoredProcedure

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ELIMINA_ID_IMPRESION_ETIQUETA_ORDEN_PEDIDO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_orden_pedido_para_impresion_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cop_idimpresion", SqlDbType.Int)

            command.Parameters(0).Value = _cop_idimpresion
            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ORDENES_COMPRA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_certificado_recepcion_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_inicio", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_termino", SqlDbType.NVarChar)
            command.Parameters.Add("@todos", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_inicio
            command.Parameters(2).Value = _fecha_termino
            command.Parameters(3).Value = _todos

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_QUITA_FILA_DESDE_GUIA_DESPACHO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_quita_fila_despacho", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@Mensaje", SqlDbType.NVarChar)
            command.Parameters.Add("@nguia", SqlDbType.Float)
            command.Parameters.Add("@pdd_fila", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fila
            command.Parameters(2).Value = _observaciones
            command.Parameters(3).Value = _nguia
            command.Parameters(4).Value = _pdd_fila


            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MARCA_ORDEN_CERTIFICADO_IMPRESO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_certificado_marca_impreso", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@orden_compra", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_ocnumero

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_VENTAS_PENDIENTES(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_imprime_ventas_pendientes", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@epc_codigo", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _epc_codigo
            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function picking_modificacion_factura_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_listado_modificacion_facturas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)
            command.Parameters.Add("@fecha_factura_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_factura_hasta", SqlDbType.NVarChar)
            'command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _fac_numero
            command.Parameters(3).Value = _fecha_factura_desde
            command.Parameters(4).Value = _fecha_factura_hasta
            'command.Parameters(5).Value = _usu_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function picking_listado_actualiza_facturacion_guarda(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_listado_picking_modifica_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)
            command.Parameters.Add("@fac_fecha", SqlDbType.NVarChar)
            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fila
            command.Parameters(2).Value = _fac_numero
            command.Parameters(3).Value = _pic_fechafactura
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function picking_detalle_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_selecciona_picking_detallado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_ingreso_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_ingreso_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_entrega_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_entrega_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@epc_codigo", SqlDbType.Int)
            command.Parameters.Add("@oc_numero", SqlDbType.Float)
            command.Parameters.Add("@tpi_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_ingreso_desde
            command.Parameters(2).Value = _fecha_ingreso_hasta
            command.Parameters(3).Value = _fecha_entrega_desde
            command.Parameters(4).Value = _fecha_entrega_hasta
            command.Parameters(5).Value = _epc_codigo
            command.Parameters(6).Value = _pic_ocnumero
            command.Parameters(7).Value = _tpi_codigo
            command.Parameters(8).Value = _pic_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function picking_modificacion_guias_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_picking_listado_modificacion_guias", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@gde_numero", SqlDbType.Float)
            command.Parameters.Add("@fecha_guias_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_guias_hasta", SqlDbType.NVarChar)
            'command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _gde_numero
            command.Parameters(3).Value = _fecha_guias_desde
            command.Parameters(4).Value = _fecha_guias_hasta
            'command.Parameters(5).Value = _usu_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function picking_listado_actualiza_guia_guarda(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_listado_guia_modifica_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@gde_numero", SqlDbType.Float)
            command.Parameters.Add("@gde_fecha", SqlDbType.NVarChar)
            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fila
            command.Parameters(2).Value = _gde_numero
            command.Parameters(3).Value = _gde_fecha
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function LISTADO_ORDENES_PARA_ARCHIVO_NV(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_genera_archivo_para_nv", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@oc_procesadas", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _oc_procesadas

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MARCA_FILAS_PROCESADAS_EN_ARCHIVO_NV(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_actualiza_fila_incluida_en_nv", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fila

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    '-----------------------------------------------------------------------
    '----------------------- Asignacion de PK ------------------------------
    '-----------------------------------------------------------------------
    Public Function ASIGNACION_BUSQUEDA_PK_ENC_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_asignacion_busqueda_pk_enc_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)
            command.Parameters.Add("@abp_fecha", SqlDbType.Date)
            command.Parameters.Add("@abp_pikasociados", SqlDbType.NVarChar)
            command.Parameters.Add("@abp_estado", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo
            command.Parameters(1).Value = _abp_fecha
            command.Parameters(2).Value = _abp_pikasociados
            command.Parameters(3).Value = _abp_estado

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PK_DET_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_agisnacion_busqueda_pk_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)
            command.Parameters.Add("@apd_fila", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@cantidad_requerida", SqlDbType.Int)
            command.Parameters.Add("@cod_bulto", SqlDbType.Int)
            command.Parameters.Add("@bulto", SqlDbType.NVarChar)
            command.Parameters.Add("@ubi_codigo", SqlDbType.NVarChar)
            command.Parameters.Add("@ubi_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@pallet", SqlDbType.NVarChar)
            command.Parameters.Add("@cantidad_en_pallet", SqlDbType.Int)
            command.Parameters.Add("@preocesada", SqlDbType.Bit)
            command.Parameters.Add("@cantidad_confirmada", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo
            command.Parameters(1).Value = _apd_fila
            command.Parameters(2).Value = _pro_codigo
            command.Parameters(3).Value = _pro_codigointerno
            command.Parameters(4).Value = _pro_nombre
            command.Parameters(5).Value = _cantidad_requerida
            command.Parameters(6).Value = _cod_bulto
            command.Parameters(7).Value = _bulto
            command.Parameters(8).Value = _ubi_codigo
            command.Parameters(9).Value = _ubi_nombre
            command.Parameters(10).Value = _pallet
            command.Parameters(11).Value = _cantidad_en_pallet
            command.Parameters(12).Value = _preocesada
            command.Parameters(13).Value = _cantidad_confirmada

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PK_RESPONSABLE_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_asignacion_busqueda_pk_responsable_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo
            command.Parameters(1).Value = _usu_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PK_RESPONSABLE_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_asignacion_busqueda_pk_responsable_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PK_PRODUCTOS_BULTOS_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_asignacion_busqueda_pk_producto_bultos_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@bul_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_codigostr", SqlDbType.NVarChar)
            command.Parameters.Add("@cantidad_requerida", SqlDbType.Int)
            command.Parameters.Add("@cantidad_encontrada", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _pro_codigointerno
            command.Parameters(3).Value = _pro_nombre
            command.Parameters(4).Value = _bul_codigo
            command.Parameters(5).Value = _bulto
            command.Parameters(6).Value = _cantidad_requerida
            command.Parameters(7).Value = _cantidad_confirmada

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PK_PK_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_asignacion_busqueda_pk_pk_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo
            command.Parameters(1).Value = _pic_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PK_PK_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_asignacion_busqueda_pk_pk_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PK_DET_ACTUALIZA_CANTIDAD(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bod_agisnacion_busqueda_piking_detalle_actualiza", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)
            command.Parameters.Add("@apd_fla", SqlDbType.Int)
            command.Parameters.Add("@cantidad_confirmada", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo
            command.Parameters(1).Value = _apd_fila
            command.Parameters(2).Value = _cantidad_confirmada

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PICKING_PRODUCTO_BULTO_ACTUALIZA_CANTIDAD(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bod_agisnacion_busqueda_piking_producto_bulto_actualiza", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_codigo", SqlDbType.Int)
            command.Parameters.Add("@cantidad_confirmada", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _bul_codigo
            command.Parameters(3).Value = _cantidad_confirmada

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PICKING_ACTUALIZA_ESTADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("[sp_bod_agisnacion_busqueda_piking_actualiza_estado]", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)
            command.Parameters.Add("@abp_estado", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo
            command.Parameters(1).Value = _abp_estado

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    'Obtiene datos de orden de abastecimiento de PK
    Public Function ASIGNACION_BUSQUEDA_PICKING_BUSCAR(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            conexion.Open()
            Dim command As New SqlCommand("sp_bod_agisnacion_busqueda_piking_buscar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
            conexion.Close()
        Catch ex As Exception
            Mensaje = ex.Message
            conexion.Close()
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PICKING_PK_BUSCAR(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            conexion.Open()
            Dim command As New SqlCommand("sp_bod_agisnacion_busqueda_piking_pk_buscar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
            conexion.Close()
        Catch ex As Exception
            Mensaje = ex.Message
            conexion.Close()
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PICKING_RESPONSABLE_BUSCAR(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            conexion.Open()
            Dim command As New SqlCommand("sp_bod_asignacion_busqueda_piking_responsable_buscar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
            conexion.Close()
        Catch ex As Exception
            Mensaje = ex.Message
            conexion.Close()
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PICKING_PRODUCTO_BULTO_BUSCAR(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            conexion.Open()
            Dim command As New SqlCommand("sp_bod_agisnacion_busqueda_piking_producto_bulto_buscar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
            conexion.Close()
        Catch ex As Exception
            Mensaje = ex.Message
            conexion.Close()
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_BUSQUEDA_PICKING_DETALLE_BUSCAR(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            conexion.Open()
            Dim command As New SqlCommand("sp_bod_agisnacion_busqueda_piking_detalle_buscar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
            conexion.Close()
        Catch ex As Exception
            Mensaje = ex.Message
            conexion.Close()
            Return Nothing
        End Try
    End Function

    Public Function OBTIENE_CANTIDAD_FILAS_PROCESADAS_EN_PICKING(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cantidad_filas_procesadas_busqueda_picking", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_PROCESA_PICKING(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_procesa_picking_desde_consolidado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACION_PROCESA_PICKING_DISPONIBILIZA_UBICACIONES(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("[sp_disponibiliza_ubicacion_en_consolidado]", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo

            'command.ExecuteNonQuery()

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_COMBO_ESTADO_ASIGNACION_PK(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_estado_asignacion_pk_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            conexion.Open()
            da.Fill(ds)
            conexion.Close()
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ASIGNACIONES_PARA_PICKING_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_listado_asignacion_busqueda_pk", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@abp_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_inicio", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_termino", SqlDbType.NVarChar)
            command.Parameters.Add("@codEstado", SqlDbType.Int)

            command.Parameters(0).Value = _abp_codigo
            command.Parameters(1).Value = _fecha_ingreso_desde
            command.Parameters(2).Value = _fecha_ingreso_hasta
            command.Parameters(3).Value = _abp_estado

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

End Class


