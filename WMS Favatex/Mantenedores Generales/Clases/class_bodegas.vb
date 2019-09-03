
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_bodegas
    Private _cnn As String
    Private _bod_codigo As Integer
    Private _bod_nombre As String
    Private _bod_activa As Boolean
    Private _todos As Boolean
    Private _btu_codigo As Integer
    Private _btu_nombre As String

    Private _pro_codigo As Integer

    Public Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
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
    Public Property bod_nombre() As String
        Get
            Return _bod_nombre
        End Get
        Set(ByVal value As String)
            _bod_nombre = value
        End Set
    End Property
    Public Property bod_activa() As Boolean
        Get
            Return _bod_activa
        End Get
        Set(ByVal value As Boolean)
            _bod_activa = value
        End Set
    End Property
    Public Property btu_codigo() As Integer
        Get
            Return _btu_codigo
        End Get
        Set(ByVal value As Integer)
            _btu_codigo = value
        End Set
    End Property
    Public Property btu_nombre() As String
        Get
            Return _btu_nombre
        End Get
        Set(ByVal value As String)
            _btu_nombre = value
        End Set
    End Property

    Public Function BODEGA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodegas_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _bod_codigo
            command.Parameters(1).Value = _todos

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function BODEGA_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_bodegas_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@bod_activa", SqlDbType.Bit)

            command.Parameters(0).Value = _bod_codigo
            command.Parameters(1).Value = _bod_nombre
            command.Parameters(2).Value = _bod_activa
            'command.ExecuteNonQuery()
            'conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)
            'conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function BODEGA_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_bodegas_eliminar", conexion)
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
    Public Function BODEGA_CARGA_COMBO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodega_carga_combo", conexion)

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

    Public Function BODEGA_DESTINO_CARGA_COMBO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodega_destino_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _bod_codigo

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

    Public Function BODEGA_PRODUCTO_RELACIONA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_bodProd_seleccionar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _bod_codigo

            'command.ExecuteNonQuery()
            conexion.Open()
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
    Public Function BODEGA_PRODUCTO_QUITA_RELACION(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_bodProd_deseleccionar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _bod_codigo

            'command.ExecuteNonQuery()
            conexion.Open()
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

    Public Function BODEGA_UBICACIONES_SIN_SELECCIONAR_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodega_ubicaciones_sin_seleccion_listado", conexion)
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

    Public Function BODEGA_UBICACIONES_SELECCIONADOS_LISTADOS(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodega_ubicaciones_seleccionados_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _bod_codigo
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

    Public Function BODEGA_TIPO_UBICACION_SELEC_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_bodTipoUbicacion_seleccionar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tbu_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _btu_codigo
            command.Parameters(1).Value = _bod_codigo

            'command.ExecuteNonQuery()
            conexion.Open()
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

    Public Function BODEGA_TIPO_UBICACION_DESELEC_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_bodTipoUbicacion_deseleccionar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tbu_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _btu_codigo
            command.Parameters(1).Value = _bod_codigo
            conexion.Open()
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

    Public Function BODEGA_PISO_SIN_PT_CARGA_COMBO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodega_piso_sin_pt_carga_combo", conexion)

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

End Class
