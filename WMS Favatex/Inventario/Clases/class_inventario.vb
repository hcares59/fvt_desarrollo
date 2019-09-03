Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_inventario
    Private _cnn As String
    Private _bod_codigo As Integer
    Private _pro_codigo As Integer
    Private _tmo_codigo As Integer
    Private _cantidad As Integer
    Private _serie_pallet As String
    Private _usu_codigo As Integer
    Private _ubi_codigo As Integer
    Private _bulto As Integer

    Private _pallet As String
    Private _num_bulto As Integer
    Private _pal_cantidadbulto As Integer
    Private _rec_codigo As Integer
    Private _zon_codigo As Integer

    Public Property zon_codigo() As Integer
        Get
            Return _zon_codigo
        End Get
        Set(ByVal value As Integer)
            _zon_codigo = value
        End Set
    End Property
    Public Property rec_codigo() As Integer
        Get
            Return _rec_codigo
        End Get
        Set(ByVal value As Integer)
            _rec_codigo = value
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
    Public Property num_bulto() As Integer
        Get
            Return _num_bulto
        End Get
        Set(ByVal value As Integer)
            _num_bulto = value
        End Set
    End Property
    Public Property pal_cantidadbulto() As Integer
        Get
            Return _pal_cantidadbulto
        End Get
        Set(ByVal value As Integer)
            _pal_cantidadbulto = value
        End Set
    End Property
    Public Property bulto() As Integer
        Get
            Return _bulto
        End Get
        Set(ByVal value As Integer)
            _bulto = value
        End Set
    End Property
    Public Property ubi_codigo() As Integer
        Get
            Return _ubi_codigo
        End Get
        Set(ByVal value As Integer)
            _ubi_codigo = value
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
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Public Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
        End Set
    End Property
    Public Property tmo_codigo() As Integer
        Get
            Return _tmo_codigo
        End Get
        Set(ByVal value As Integer)
            _tmo_codigo = value
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
    Public Property serie_pallet() As String
        Get
            Return _serie_pallet
        End Get
        Set(ByVal value As String)
            _serie_pallet = value
        End Set
    End Property

    Public Function ACTUALIZA_STOCK_MOVIMIENTOS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_actualiza_stock", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@tmo_codigo", SqlDbType.Int)
            command.Parameters.Add("@cantidad", SqlDbType.Int)

            command.Parameters(0).Value = _bod_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _tmo_codigo
            command.Parameters(3).Value = _cantidad

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

    Public Function VERIFICA_PRODUCTO_BODEGA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_existe_producto_en_bodega", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _bod_codigo
            command.Parameters(1).Value = _pro_codigo

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

    Public Function VERIFICA_PRODUCTO_BODEGA_SIN_TRANSACCION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_existe_producto_en_bodega", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _bod_codigo
            command.Parameters(1).Value = _pro_codigo

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

    Public Function PRODUCTOS_PENDIENTES_POR_BODEGA_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_productos_disponibles_po_bodega_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _bod_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PALLET_POR_PRODUCTOS_SELECCIONADOS(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_pallet_por_producto_seleccionar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _rec_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _bod_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CANTIDADES_POR_BULTOS_SELECCIONADOS(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_cantidades_por_bultos_seleccionado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _bod_codigo
            command.Parameters(1).Value = _pro_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function VALIDA_SOLICITUD_DE_UBICACION(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_valida_solicitud_ubicaciones", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _bod_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function UBICACIONES_DISPONIBLE_SELECCIONADOS(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_ubicaciones_disponible_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@serie_pallet", SqlDbType.NVarChar)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@zon_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _serie_pallet
            command.Parameters(1).Value = _bod_codigo
            command.Parameters(2).Value = _zon_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MOVIMIENTOS_TEMP_ENC_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_movi_temp_ubi_ecn_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@serie", SqlDbType.NVarChar)
            command.Parameters.Add("@cantidad", SqlDbType.Int)
            command.Parameters.Add("@bulto", SqlDbType.Int)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _serie_pallet
            command.Parameters(2).Value = _cantidad
            command.Parameters(3).Value = _bulto

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

    Public Function MOVIMIENTOS_TEMP_DET_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_movi_temp_ubi_det_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@serie", SqlDbType.NVarChar)
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _serie_pallet
            command.Parameters(2).Value = _ubi_codigo

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

    Public Function MOVIMIENTOS_TEMP_ENC_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_movi_temp_ubi_ecn_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@serie", SqlDbType.NVarChar)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _serie_pallet

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

    Public Function MOVIMIENTOS_TEMP_DET_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_movi_temp_ubi_det_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@serie", SqlDbType.NVarChar)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _serie_pallet

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

    Public Function SERIES_UBICACIONES_LISTADO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_series_ubicaciones_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _usu_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function INGRESA_PALLET_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_pallet_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pallet", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@num_bulto", SqlDbType.Int)
            command.Parameters.Add("@pal_cantidad", SqlDbType.Int)

            command.Parameters(0).Value = _serie_pallet
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _num_bulto
            command.Parameters(3).Value = _cantidad

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
    Public Function INGRESA_PALLET_ENCABEZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_pallet_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pallet", SqlDbType.NVarChar)
            command.Parameters.Add("@pal_cantidadbulto", SqlDbType.Int)
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _serie_pallet
            command.Parameters(1).Value = _cantidad
            command.Parameters(2).Value = _ubi_codigo

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

    Public Function ELIMINA_UBICACIONES_TEMPORALES(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_movi_temp_ubi_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _usu_codigo

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
