Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_tipo_vehiculo
    Private _cnn As String
    Private _tve_codigo As Integer
    Private _tve_nombre As String
    Private _tve_activo As Boolean
    Private _tve_eliminado As Boolean
    Private _todos As Boolean

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
    Public Property tve_codigo() As Integer
        Get
            Return _tve_codigo
        End Get
        Set(ByVal value As Integer)
            _tve_codigo = value
        End Set
    End Property
    Public Property tve_nombre() As String
        Get
            Return _tve_nombre
        End Get
        Set(ByVal value As String)
            _tve_nombre = value
        End Set
    End Property
    Public Property tve_activo() As Boolean
        Get
            Return _tve_activo
        End Get
        Set(ByVal value As Boolean)
            _tve_activo = value
        End Set
    End Property
    Public Property tve_eliminado() As Boolean
        Get
            Return _tve_eliminado
        End Get
        Set(ByVal value As Boolean)
            _tve_eliminado = value
        End Set
    End Property

    Public Function TIPO_VEHICULO_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipoVehiculo_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tve_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Int)

            command.Parameters(0).Value = _tve_codigo
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

    Public Function TIPO_VEHICULO_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_tipoVehiculo_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tve_codigo", SqlDbType.Int)
            command.Parameters.Add("@tve_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@tve_activo", SqlDbType.Int)

            command.Parameters(0).Value = _tve_codigo
            command.Parameters(1).Value = _tve_nombre
            command.Parameters(2).Value = _tve_activo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function TIPO_VEHICULO_ELIMINA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_tipoVehiculo_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tve_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _tve_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function TIPO_VEHICULO_COMNBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipoVehiculos_combo", conexion)
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

End Class
