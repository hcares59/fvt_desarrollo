Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_despacha_picking
    Private _cnn As String
    Private _pic_codigo As Integer
    Private _pic_ocnumero As Long
    Private _car_codigo As Integer
    Private _tipo As String
    Private _numero As Long

    Private _pic_fila As Integer
    Private _gde_numero As Long
    Private _es_despachada As Boolean
    Private _cantidadDespachada As Integer
    Private _pdd_fila As Integer
    Private _gde_fecha As Date
    Private _fac_numero As Long
    Private _fac_fecha As Date
    Private _fecha_elimina_desde As String
    Private _fecha_elimina_hasta As String
    Private _oc_numero As Long

    Public Property oc_numero() As Long
        Get
            Return _oc_numero
        End Get
        Set(ByVal value As Long)
            _oc_numero = value
        End Set
    End Property
    Public Property fecha_elimina_desde() As String
        Get
            Return _fecha_elimina_desde
        End Get
        Set(ByVal value As String)
            _fecha_elimina_desde = value
        End Set
    End Property
    Public Property fecha_elimina_hasta() As String
        Get
            Return _fecha_elimina_hasta
        End Get
        Set(ByVal value As String)
            _fecha_elimina_hasta = value
        End Set
    End Property

    Public Property fac_fecha() As Date
        Get
            Return _fac_fecha
        End Get
        Set(ByVal value As Date)
            _fac_fecha = value
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

    Public Property gde_fecha() As Date
        Get
            Return _gde_fecha
        End Get
        Set(ByVal value As Date)
            _gde_fecha = value
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
    Public Property cantidadDespachada() As Integer
        Get
            Return _cantidadDespachada
        End Get
        Set(ByVal value As Integer)
            _cantidadDespachada = value
        End Set
    End Property
    Public Property es_despachada() As Boolean
        Get
            Return _es_despachada
        End Get
        Set(ByVal value As Boolean)
            _es_despachada = value
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
    Public Property pic_fila() As Integer
        Get
            Return _pic_fila
        End Get
        Set(ByVal value As Integer)
            _pic_fila = value
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
    Public Property pic_codigo() As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
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

    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Public Property numero() As Long
        Get
            Return _numero
        End Get
        Set(ByVal value As Long)
            _numero = value
        End Set
    End Property


    Public Function SELECCIONA_DOCUMENTO_DESPACHO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cartera_despacha_por", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _car_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function LISTA_DETALLE_OC_PARA_DESPACHAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_para_despachar_detalle", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pic_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_MARCA_FILAS_DESPACHADAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_marca_filas_despachadas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@fila", SqlDbType.Int)
            command.Parameters.Add("@gde_numero", SqlDbType.Float)
            command.Parameters.Add("@cantidadDespachada", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _pic_ocnumero
            command.Parameters(3).Value = _pic_fila
            command.Parameters(4).Value = _gde_numero
            command.Parameters(5).Value = _cantidadDespachada

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

    Public Function REVISA_FILAS_DESPACHADAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_revisa_filas_despachadas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pic_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function


    Public Function SELECCIONA_DETALLE_DOCUMENTO_DEVOLUCION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_detalle_documento_selecciona", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@tipo", SqlDbType.NVarChar)
            command.Parameters.Add("@numero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _tipo
            command.Parameters(2).Value = _numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PRODUCTOS_PENDIENTE_EMBARQUE_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_pendiente_embarque", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@num_orden", SqlDbType.Float)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)
            'command.Parameters.Add("@gde_numero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _oc_numero
            command.Parameters(3).Value = _fac_numero
            'command.Parameters(1).Value = _gde_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DESPACHO_EMBARQUE_TEMP_INGRESA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_despacho_embarque_temp_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@pdd_fila", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _pic_fila
            command.Parameters(3).Value = _pdd_fila


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DESPACHO_EMBARQUE_TEMP_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_despacho_embarque_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@pdd_fila", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _pic_fila
            command.Parameters(3).Value = _pdd_fila

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DESPACHO_GUARDA_GUIA_DESPACHO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_inv_picking_detalle_despachados_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codio", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@gde_numero", SqlDbType.Int)
            command.Parameters.Add("@cantidad_despachada", SqlDbType.Int)
            command.Parameters.Add("@pdd_fila", SqlDbType.Int)
            command.Parameters.Add("@gde_fecha", SqlDbType.Date)
            command.Parameters.Add("@fac_numero", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _pic_fila
            command.Parameters(3).Value = _gde_numero
            command.Parameters(4).Value = _cantidadDespachada
            command.Parameters(5).Value = _pdd_fila
            command.Parameters(6).Value = _gde_fecha
            command.Parameters(7).Value = _fac_numero


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function REVISA_FILAS_DESPACHADAS_DESDE_DESPACHO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_revisa_filas_despachadas_desde_despacho", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pic_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function selecciona_detalle_por_piking_devolucion(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_detalle_selecciona_por_picking", conexion)

            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@numero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ELIMINA_REGISTRO_DEVOLUCIONES(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_productos_devolucion_eliminar", conexion)
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

    Public Function PRODUCTOS_PENDIENTES_DEVOLUCION_EMBARQUES_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_devueltas_pendiente_embarque", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@gde_numero", SqlDbType.Float)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)
            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pic_codigo
            command.Parameters(2).Value = _gde_numero
            command.Parameters(3).Value = _fac_numero
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function productos_pedientes_devolucion_embarques_eliminados_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_devueltas_pendiente_embarque_eliminadas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_eliminar_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_eliminar_hasta", SqlDbType.NVarChar)
            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_elimina_desde
            command.Parameters(2).Value = _fecha_elimina_hasta
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
