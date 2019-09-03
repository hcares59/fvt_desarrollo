Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_orden_compra
    Private _cnn As String
    Private _car_codigo As Integer
    Private _con_ocnumero As Long
    Private _con_skucliente As String
    Private _con_skudescripcion As String
    Private _con_cantidad As String
    Private _con_preciocosto As String
    Private _con_fechadespacho As Date
    Private _con_despachara As String
    Private _con_local As String
    Private _con_observacion As String
    Private _con_numf12 As String
    Private _con_nombrearchivo As String
    Private _con_despacharanumero As String
    Private _con_localnombre As String
    Private _rut_cliente As String
    Private _nombre_cliente As String
    Private _con_codigounico As String
    Private _es_agendable As Boolean
    Private _es_abierta As Boolean
    Private _tipo As String
    Private _codigo_interno As String
    Private _opcion As Integer
    Private _age_fechaorden_string As String
    Private _por_confirmar As Boolean
    Private _con_comunareceptor As String
    Private _con_ciudadreceptor As String

    Private _con_sucursalentrega As String
    Private _con_fechaventa As Date
    Private _con_numboleta As Long
    Private _con_fechaentrega As Date
    Private _con_numcaja As Integer
    Private _fecha_emision As Date
    Private _fecha_despacho_desde As String
    Private _fecha_despacho_hasta As String
    Private _con_telefonocliente As String
    Private _con_emailcliente As String

    Public Property con_emailcliente() As String
        Get
            Return _con_emailcliente
        End Get
        Set(ByVal value As String)
            _con_emailcliente = value
        End Set
    End Property
    Public Property con_telefonocliente() As String
        Get
            Return _con_telefonocliente
        End Get
        Set(ByVal value As String)
            _con_telefonocliente = value
        End Set
    End Property
    Public Property fecha_emision() As Date
        Get
            Return _fecha_emision
        End Get
        Set(ByVal value As Date)
            _fecha_emision = value
        End Set
    End Property
    Public Property con_sucursalentrega() As String
        Get
            Return _con_sucursalentrega
        End Get
        Set(ByVal value As String)
            _con_sucursalentrega = value
        End Set
    End Property
    Public Property con_fechaventa() As Date
        Get
            Return _con_fechaventa
        End Get
        Set(ByVal value As Date)
            _con_fechaventa = value
        End Set
    End Property
    Public Property con_numboleta() As Long
        Get
            Return _con_numboleta
        End Get
        Set(ByVal value As Long)
            _con_numboleta = value
        End Set
    End Property
    Public Property con_fechaentrega() As Date
        Get
            Return _con_fechaentrega
        End Get
        Set(ByVal value As Date)
            _con_fechaentrega = value
        End Set
    End Property
    Public Property con_numcaja() As Integer
        Get
            Return _con_numcaja
        End Get
        Set(ByVal value As Integer)
            _con_numcaja = value
        End Set
    End Property

    Public Property con_comunareceptor() As String
        Get
            Return _con_comunareceptor
        End Get
        Set(ByVal value As String)
            _con_comunareceptor = value
        End Set
    End Property
    Public Property con_ciudadreceptor() As String
        Get
            Return _con_ciudadreceptor
        End Get
        Set(ByVal value As String)
            _con_ciudadreceptor = value
        End Set
    End Property
    Public Property opcion() As Integer
        Get
            Return _opcion
        End Get
        Set(ByVal value As Integer)
            _opcion = value
        End Set
    End Property
    Public Property codigo_interno() As String
        Get
            Return _codigo_interno
        End Get
        Set(ByVal value As String)
            _codigo_interno = value
        End Set
    End Property
    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property
    Public Property es_abierta() As Boolean
        Get
            Return _es_abierta
        End Get
        Set(ByVal value As Boolean)
            _es_abierta = value
        End Set
    End Property
    Public Property es_agendable() As Boolean
        Get
            Return _es_agendable
        End Get
        Set(ByVal value As Boolean)
            _es_agendable = value
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
    Public Property nombre_cliente() As String
        Get
            Return _nombre_cliente
        End Get
        Set(ByVal value As String)
            _nombre_cliente = value
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
    Public Property con_localnombre() As String
        Get
            Return _con_localnombre
        End Get
        Set(ByVal value As String)
            _con_localnombre = value
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
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Public Property con_skudescripcion() As String
        Get
            Return _con_skudescripcion
        End Get
        Set(ByVal value As String)
            _con_skudescripcion = value
        End Set
    End Property
    Public Property con_cantidad() As String
        Get
            Return _con_cantidad
        End Get
        Set(ByVal value As String)
            _con_cantidad = value
        End Set
    End Property
    Public Property con_preciocosto() As String
        Get
            Return _con_preciocosto
        End Get
        Set(ByVal value As String)
            _con_preciocosto = value
        End Set
    End Property
    Public Property con_fechadespacho() As Date
        Get
            Return _con_fechadespacho
        End Get
        Set(ByVal value As Date)
            _con_fechadespacho = value
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
    Public Property con_observacion() As String
        Get
            Return _con_observacion
        End Get
        Set(ByVal value As String)
            _con_observacion = value
        End Set
    End Property
    Public Property con_numf12() As String
        Get
            Return _con_numf12
        End Get
        Set(ByVal value As String)
            _con_numf12 = value
        End Set
    End Property
    Public Property con_nombrearchivo() As String
        Get
            Return _con_nombrearchivo
        End Get
        Set(ByVal value As String)
            _con_nombrearchivo = value
        End Set
    End Property
    Public Property age_fechaorden_string() As String
        Get
            Return _age_fechaorden_string
        End Get
        Set(ByVal value As String)
            _age_fechaorden_string = value
        End Set
    End Property
    Public Property por_confirmar() As Boolean
        Get
            Return _por_confirmar
        End Get
        Set(ByVal value As Boolean)
            _por_confirmar = value
        End Set
    End Property
    Public Property fecha_despacho_desde() As String
        Get
            Return _fecha_despacho_desde
        End Get
        Set(ByVal value As String)
            _fecha_despacho_desde = value
        End Set
    End Property
    Public Property fecha_despacho_hasta() As String
        Get
            Return _fecha_despacho_hasta
        End Get
        Set(ByVal value As String)
            _fecha_despacho_hasta = value
        End Set
    End Property

    Public Function CARGA_GRILLA_VISOR_OC(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_informe_ordenes_compra_sin_agenda_listar", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@fecha_inicio", _fecha_despacho_desde))
            command.Parameters.Add(New SqlParameter("@fecha_fin", _fecha_despacho_hasta))

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function INGRESA_REPOSITORIO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet

        Try
            Dim command As New SqlCommand("sp_guarda_repositorio_b2b", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@con_skucliente", SqlDbType.NVarChar)
            command.Parameters.Add("@con_skudescripcion", SqlDbType.NVarChar)
            command.Parameters.Add("@con_cantidad", SqlDbType.Int)
            command.Parameters.Add("@con_preciocosto", SqlDbType.Float)
            command.Parameters.Add("@con_fechadespacho", SqlDbType.DateTime)
            command.Parameters.Add("@con_despacharanumero", SqlDbType.NVarChar)
            command.Parameters.Add("@con_despachara", SqlDbType.NVarChar)
            command.Parameters.Add("@con_local", SqlDbType.NVarChar)
            command.Parameters.Add("@con_localnombre", SqlDbType.NVarChar)
            command.Parameters.Add("@rut_cliente", SqlDbType.NVarChar)
            command.Parameters.Add("@nombre_cliente", SqlDbType.NVarChar)
            command.Parameters.Add("@con_observacion", SqlDbType.NVarChar)
            command.Parameters.Add("@con_codigounico", SqlDbType.NVarChar)
            command.Parameters.Add("@es_agendable", SqlDbType.Bit)
            command.Parameters.Add("@es_abierta", SqlDbType.Bit)
            command.Parameters.Add("@con_nombrearchivo", SqlDbType.NVarChar)
            command.Parameters.Add("@por_confirmar", SqlDbType.Bit)
            command.Parameters.Add("@con_comunareceptor", SqlDbType.NVarChar)
            command.Parameters.Add("@con_ciudadreceptor", SqlDbType.NVarChar)
            command.Parameters.Add("@con_sucursalentrega", SqlDbType.NVarChar)
            command.Parameters.Add("@con_fechaventa", SqlDbType.Date)
            command.Parameters.Add("@con_numboleta", SqlDbType.Float)
            command.Parameters.Add("@con_fechaentrega", SqlDbType.Date)
            command.Parameters.Add("@con_numcaja", SqlDbType.Int)
            command.Parameters.Add("@fecha_emision", SqlDbType.Date)
            command.Parameters.Add("@con_telefonocliente", SqlDbType.NVarChar)
            command.Parameters.Add("@con_emailcliente", SqlDbType.NVarChar)


            command.UpdatedRowSource = UpdateRowSource.None

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _con_ocnumero
            command.Parameters(2).Value = Replace(_con_skucliente, Chr(34), "")
            command.Parameters(3).Value = Replace(_con_skudescripcion, Chr(34), "")
            command.Parameters(4).Value = CInt(_con_cantidad)
            command.Parameters(5).Value = _con_preciocosto
            command.Parameters(6).Value = _con_fechadespacho
            command.Parameters(7).Value = Replace(_con_despacharanumero, Chr(34), "")
            command.Parameters(8).Value = Replace(Replace(Replace(_con_despachara, "°", ""), Chr(34), ""), "�", "")
            command.Parameters(9).Value = Replace(Replace(_con_local, Chr(34), ""), "�", "")
            command.Parameters(10).Value = Replace(Replace(Replace(_con_localnombre, "°", ""), Chr(34), ""), "�", "")
            command.Parameters(11).Value = _rut_cliente
            command.Parameters(12).Value = Replace(Replace(Replace(_nombre_cliente, "°", ""), Chr(34), ""), "�", "")
            command.Parameters(13).Value = Replace(Replace(_con_observacion, Chr(34), ""), "�", "")
            command.Parameters(14).Value = Replace(Replace(Replace(_con_codigounico, "°", ""), Chr(34), ""), "�", "")
            command.Parameters(15).Value = _es_agendable
            command.Parameters(16).Value = _es_abierta
            command.Parameters(17).Value = _con_nombrearchivo
            command.Parameters(18).Value = _por_confirmar
            command.Parameters(19).Value = _con_comunareceptor
            command.Parameters(20).Value = _con_ciudadreceptor
            command.Parameters(21).Value = _con_sucursalentrega
            command.Parameters(22).Value = _con_fechaventa
            command.Parameters(23).Value = _con_numboleta
            command.Parameters(24).Value = _con_fechaentrega
            command.Parameters(25).Value = _con_numcaja
            command.Parameters(26).Value = _fecha_emision
            command.Parameters(27).Value = _con_telefonocliente
            command.Parameters(28).Value = _con_emailcliente

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function BUSCA_PRODUCTO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_producto_por_codigo_sku_buscar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@cod_interno", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_cliente", SqlDbType.NVarChar)
            command.Parameters.Add("@opcion", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _codigo_interno
            command.Parameters(2).Value = _con_skucliente
            command.Parameters(3).Value = _opcion

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

    Public Function CARGA_GRILLA_LISTADO_OC(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_orden_compra_listar", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@fecha", _age_fechaorden_string))
            command.Parameters.Add(New SqlParameter("@con_ocnumero", _con_ocnumero))

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ELIMINA_ORDEN_COMPRA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_orden_compra_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _con_ocnumero

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

    Public Function ELIMINA_ORDEN_COMPRA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_orden_compra_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _con_ocnumero

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

    Public Function CARGA_GRILLA_LISTADO_DETALLE_OC(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_orden_compra_detalle_listar", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@con_ocnumero", _con_ocnumero))

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ORDEN_COMPRA_CON_GESTION(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_orden_compra_con_gestion", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@con_ocnumero", _con_ocnumero))

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ORDEN_COMPRA_ULTIMA_OC(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ultima_oc_generica", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function carga_grilla_detalle_listado_oc(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_listado_orden_compra_detallado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@fecha", _age_fechaorden_string))
            command.Parameters.Add(New SqlParameter("@con_ocnumero", _con_ocnumero))

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

End Class
