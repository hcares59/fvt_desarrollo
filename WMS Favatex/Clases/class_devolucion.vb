Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_devolucion
    Private _cnn As String
    Private _dev_codigo As Integer
    Private _dev_fecha As Date
    Private _car_codigo As Integer
    Private _dev_observacion As String
    Private _usu_codigo As Integer

    Private _dev_fila As Integer
    Private _dev_ocompra As Long
    Private _pic_codigo As Integer
    Private _dev_nfactura As Long
    Private _dev_nguia As Long
    Private _dev_codunico As String
    Private _pro_codigo As Integer
    Private _pro_codigointerno As String
    Private _pro_nombre As String
    Private _sku_cliente As String
    Private _sku_nombre As String
    Private _dev_cantidad As Integer
    Private _dev_num_bulto As Integer
    Private _dev_total_bulto As Integer
    Private _pro_codigooriginal As Integer
    Private _dev_cant_devuelta As Integer
    Private _dev_cant_bulto As Integer
    Private _dev_motivo As String
    Private _pic_fila As Integer

    Private _fecha_desde As String
    Private _fecha_hasta As String
    Private _observacion As String

    Private _dev_fechadevolucion As Date
    Private _pdd_fila As Integer
    Private _tdv_codigo As Integer
    Private _emb_sello As String

    Public Property emb_sello() As String
        Get
            Return _emb_sello
        End Get
        Set(ByVal value As String)
            _emb_sello = value
        End Set
    End Property

    Public Property tdv_codigo() As Integer
        Get
            Return _tdv_codigo
        End Get
        Set(ByVal value As Integer)
            _tdv_codigo = value
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
    Public Property dev_fechadevolucion() As String
        Get
            Return _dev_fechadevolucion
        End Get
        Set(ByVal value As String)
            _dev_fechadevolucion = value
        End Set
    End Property
    Public Property observacion() As String
        Get
            Return _observacion
        End Get
        Set(ByVal value As String)
            _observacion = value
        End Set
    End Property
    Public Property fecha_desde() As String
        Get
            Return _fecha_desde
        End Get
        Set(ByVal value As String)
            _fecha_desde = value
        End Set
    End Property
    Public Property fecha_hasta() As String
        Get
            Return _fecha_hasta
        End Get
        Set(ByVal value As String)
            _fecha_hasta = value
        End Set
    End Property

    Public Property dev_ocompra() As Long
        Get
            Return _dev_ocompra
        End Get
        Set(ByVal value As Long)
            _dev_ocompra = value
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
    Public Property dev_nfactura() As Long
        Get
            Return _dev_nfactura
        End Get
        Set(ByVal value As Long)
            _dev_nfactura = value
        End Set
    End Property
    Public Property dev_nguia() As Long
        Get
            Return _dev_nguia
        End Get
        Set(ByVal value As Long)
            _dev_nguia = value
        End Set
    End Property
    Public Property dev_codunico() As String
        Get
            Return _dev_codunico
        End Get
        Set(ByVal value As String)
            _dev_codunico = value
        End Set
    End Property
    Public Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
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
    Public Property pro_nombre() As String
        Get
            Return _pro_nombre
        End Get
        Set(ByVal value As String)
            _pro_nombre = value
        End Set
    End Property
    Public Property sku_cliente() As String
        Get
            Return _sku_cliente
        End Get
        Set(ByVal value As String)
            _sku_cliente = value
        End Set
    End Property
    Public Property sku_nombre() As String
        Get
            Return _sku_nombre
        End Get
        Set(ByVal value As String)
            _sku_nombre = value
        End Set
    End Property
    Public Property dev_cantidad() As Integer
        Get
            Return _dev_cantidad
        End Get
        Set(ByVal value As Integer)
            _dev_cantidad = value
        End Set
    End Property
    Public Property dev_num_bulto() As Integer
        Get
            Return _dev_num_bulto
        End Get
        Set(ByVal value As Integer)
            _dev_num_bulto = value
        End Set
    End Property
    Public Property dev_total_bulto() As Integer
        Get
            Return _dev_total_bulto
        End Get
        Set(ByVal value As Integer)
            _dev_total_bulto = value
        End Set
    End Property
    Public Property dev_cant_devuelta() As Integer
        Get
            Return _dev_cant_devuelta
        End Get
        Set(ByVal value As Integer)
            _dev_cant_devuelta = value
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

    Public Property dev_cant_bulto() As Integer
        Get
            Return _dev_cant_bulto
        End Get
        Set(ByVal value As Integer)
            _dev_cant_bulto = value
        End Set
    End Property
    Public Property dev_motivo() As String
        Get
            Return _dev_motivo
        End Get
        Set(ByVal value As String)
            _dev_motivo = value
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


    Public Property usu_codigo() As Integer
        Get
            Return _usu_codigo
        End Get
        Set(ByVal value As Integer)
            _usu_codigo = value
        End Set
    End Property
    Public Property dev_observacion() As String
        Get
            Return _dev_observacion
        End Get
        Set(ByVal value As String)
            _dev_observacion = value
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

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property dev_codigo() As Integer
        Get
            Return _dev_codigo
        End Get
        Set(ByVal value As Integer)
            _dev_codigo = value
        End Set
    End Property
    Public Property dev_fecha() As Date
        Get
            Return _dev_fecha
        End Get
        Set(ByVal value As Date)
            _dev_fecha = value
        End Set
    End Property


    Public Function DEVOLUCIONES_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_devoluciones_listados", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_desde
            command.Parameters(2).Value = _fecha_hasta

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

    Public Function DEVOLUCIONES_CARGA_ENCAVEZADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_selecciona_devolucion_encabezado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@dev_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _dev_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DEVOLUCIONES_CARGA_DETALLE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_selecciona_devolucion_detalle", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@dev_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _dev_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function


    Public Function PICKING_GUARDA_DATOS_DEVOLUCION_ENCABEZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_devoluciones_encabezado_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@dev_codigo", SqlDbType.Int)
            command.Parameters.Add("@dev_fechadevolucion", SqlDbType.Date)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@dev_observacion", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _dev_codigo
            command.Parameters(1).Value = _dev_fechadevolucion
            command.Parameters(2).Value = _car_codigo
            command.Parameters(3).Value = Replace(_dev_observacion, "'", "-")
            command.Parameters(4).Value = _usu_codigo
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

    Public Function PICKING_ELIMINA_DATOS_DEVOLUCION_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_devoluciones_detalle_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@dev_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _dev_codigo
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

    Public Function DEVOLUCION_PRODUCTO_ORDEN_CONSOLIDADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_devolucion_orden_consolidado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@con_skucliente", SqlDbType.NVarChar)
            command.Parameters.Add("@con_codigounico", SqlDbType.NVarChar)
            command.Parameters.Add("@con_cantidad", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _dev_ocompra
            command.Parameters(2).Value = _sku_cliente
            command.Parameters(3).Value = _dev_codunico
            command.Parameters(4).Value = _dev_cantidad
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

    Public Function DEVOLUCION_PRODUCTO_ORDEN_CONSOLIDADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_devolucion_orden_consolidado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@con_skucliente", SqlDbType.NVarChar)
            command.Parameters.Add("@con_codigounico", SqlDbType.NVarChar)
            command.Parameters.Add("@con_cantidad", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _dev_ocompra
            command.Parameters(2).Value = _sku_cliente
            command.Parameters(3).Value = _dev_codunico
            command.Parameters(4).Value = _dev_cantidad
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

    Public Function MARCA_FILA_DEVUELTA_PICKING(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_marca_fila_devuelta", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@observacion", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fila
            command.Parameters(2).Value = _observacion

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

    Public Function GENERA_AGENDA_DESDE_DEVOLUCIONES(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_genera_agenda_desde_devolucion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@dev_codigo", SqlDbType.Float)
            command.Parameters.Add("@ca_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _dev_codigo
            command.Parameters(1).Value = _car_codigo

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


    Public Function PICKING_GUARDA_DATOS_DEVOLUCION_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_devoluciones_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@dev_codigo", SqlDbType.Float)
            command.Parameters.Add("@dev_ocompra", SqlDbType.Float)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@dev_nfactura", SqlDbType.Float)
            command.Parameters.Add("@dev_nguia", SqlDbType.Float)
            command.Parameters.Add("@dev_codunico", SqlDbType.Float)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_cliente", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@dev_cantidad", SqlDbType.Int)
            command.Parameters.Add("@dev_num_bulto", SqlDbType.Int)
            command.Parameters.Add("@dev_total_bulto", SqlDbType.Int)
            command.Parameters.Add("@pro_codigooriginal", SqlDbType.Int)
            command.Parameters.Add("@dev_cant_devuelta", SqlDbType.Int)
            command.Parameters.Add("@dev_cant_bulto", SqlDbType.Int)
            command.Parameters.Add("@dev_motivo", SqlDbType.NVarChar)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@pdd_fila", SqlDbType.Int)
            command.Parameters.Add("@tdv_codigo", SqlDbType.Int)
            command.Parameters.Add("@emb_sello", SqlDbType.NChar)


            command.Parameters(0).Value = _dev_codigo
            command.Parameters(1).Value = _dev_ocompra
            command.Parameters(2).Value = _pic_codigo
            command.Parameters(3).Value = _dev_nfactura
            command.Parameters(4).Value = _dev_nguia
            command.Parameters(5).Value = _dev_codunico
            command.Parameters(6).Value = _pro_codigo
            command.Parameters(7).Value = Replace(_pro_codigointerno, "'", "")
            command.Parameters(8).Value = Replace(_pro_nombre, "'", "")
            command.Parameters(9).Value = Replace(_sku_cliente, "'", "")
            command.Parameters(10).Value = Replace(_sku_nombre, "'", "")
            command.Parameters(11).Value = _dev_cantidad
            command.Parameters(12).Value = _dev_num_bulto
            command.Parameters(13).Value = _dev_total_bulto
            command.Parameters(14).Value = _pro_codigooriginal
            command.Parameters(15).Value = _dev_cant_devuelta
            command.Parameters(16).Value = _dev_cant_bulto
            command.Parameters(17).Value = _dev_motivo
            command.Parameters(18).Value = _pic_fila
            command.Parameters(19).Value = _pdd_fila
            command.Parameters(20).Value = _tdv_codigo
            command.Parameters(21).Value = _emb_sello

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

    Public Function DEVOLUCIONES_POR_PICKING(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_devoluciones_por_picking_listados", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_desde
            command.Parameters(2).Value = _fecha_hasta

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

    Public Function devoluciones_detalle_por_picking(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_devoluciones_detalle_por_picking_listados", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)
            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_desde
            command.Parameters(2).Value = _fecha_hasta
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function devolucion_detalle_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_devoluciones_detalle_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fecha_desde
            command.Parameters(2).Value = _fecha_hasta

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

    Public Function retorna_fin_embarque(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_retorna_finaliza_embarque", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tdv_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tdv_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function VERIFICA_TIPO_DEVOLUCION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_verifica_tipo_devolucion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tdv_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tdv_codigo
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

End Class
