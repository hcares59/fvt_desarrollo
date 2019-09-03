Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class class_zonas
    Private _cnn As String
    Private _zon_codigo As Integer
    Private _bod_codigo As Integer
    Private _btu_codigo As Integer
    Private _zon_nombre As String
    Private _zon_activo As Boolean
    Private _zon_eliminado As Boolean
    Private _todos As Boolean
    Private _zon_relac As Integer
    Private _zon_fondo As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property zon_codigo() As Integer
        Get
            Return _zon_codigo
        End Get
        Set(ByVal value As Integer)
            _zon_codigo = value
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
    Public Property bod_codigo() As Integer
        Get
            Return _bod_codigo
        End Get
        Set(ByVal value As Integer)
            _bod_codigo = value
        End Set
    End Property
    Public Property zon_nombre() As String
        Get
            Return _zon_nombre
        End Get
        Set(ByVal value As String)
            _zon_nombre = value
        End Set
    End Property
    Public Property zon_activo() As Integer
        Get
            Return _zon_activo
        End Get
        Set(ByVal value As Integer)
            _zon_activo = value
        End Set
    End Property
    Public Property zon_eliminado() As Boolean
        Get
            Return _zon_eliminado
        End Get
        Set(ByVal value As Boolean)
            _zon_eliminado = value
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
    Public Property zon_relac() As Integer
        Get
            Return _zon_relac
        End Get
        Set(ByVal value As Integer)
            _zon_relac = value
        End Set
    End Property
    Public Property zon_fondo() As Boolean
        Get
            Return _zon_fondo
        End Get
        Set(ByVal value As Boolean)
            _zon_fondo = value
        End Set
    End Property

    Public Function ZONAS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_zonas_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@zon_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@tub_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _zon_codigo
            command.Parameters(1).Value = _todos
            command.Parameters(2).Value = _bod_codigo
            command.Parameters(3).Value = _btu_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ZONA_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_zona_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@zon_codigo", SqlDbType.Int)
            command.Parameters.Add("@btu_codigo", SqlDbType.Int)
            command.Parameters.Add("@zon_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@zon_activo", SqlDbType.Int)
            command.Parameters.Add("@zon_relac", SqlDbType.Int)
            'command.Parameters.Add("@zon_fondo", SqlDbType.Bit)

            command.Parameters(0).Value = _zon_codigo
            command.Parameters(1).Value = _btu_codigo
            command.Parameters(2).Value = _zon_nombre
            command.Parameters(3).Value = _zon_activo
            command.Parameters(4).Value = _zon_relac
            'command.Parameters(5).Value = _zon_fondo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ZONA_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_zona_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@zon_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _zon_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ZONAS_CARGA_ZONAS(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_zona_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@btu_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _btu_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ZONAS_CARGA_ZONAS_POR_BODEGA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_zona_por_bodega_carga_combo", conexion)
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

End Class
