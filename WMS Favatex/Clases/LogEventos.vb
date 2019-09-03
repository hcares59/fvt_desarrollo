Imports System.Configuration
Imports System.Data.SqlClient
Public Class LogEventos
    Private _cnn As String

    Private _log_tipo As Integer
    Private _log_descripcion As String
    Private _log_aplicacion As String
    Private _log_usuario As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property log_tipo() As Integer
        Get
            Return _log_tipo
        End Get
        Set(ByVal value As Integer)
            _log_tipo = value
        End Set
    End Property
    Public Property log_descripcion() As String
        Get
            Return _log_descripcion
        End Get
        Set(ByVal value As String)
            _log_descripcion = value
        End Set
    End Property
    Public Property log_aplicacion() As String
        Get
            Return _log_aplicacion
        End Get
        Set(ByVal value As String)
            _log_aplicacion = value
        End Set
    End Property
    Public Property log_usuario() As Integer
        Get
            Return _log_usuario
        End Get
        Set(ByVal value As Integer)
            _log_usuario = value
        End Set
    End Property

    Public Function INGRESA_LOG_EVETOS(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_guarda_log", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@log_tipo", SqlDbType.Int)
            command.Parameters.Add("@log_descripcion", SqlDbType.NVarChar)
            command.Parameters.Add("@log_aplicacion", SqlDbType.NVarChar)
            command.Parameters.Add("@log_usuario", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None

            command.Parameters(0).Value = _log_tipo
            command.Parameters(1).Value = _log_descripcion
            command.Parameters(2).Value = _log_aplicacion
            command.Parameters(3).Value = _log_usuario

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function INGRESA_LOG_EVETOS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_guarda_log", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@log_tipo", SqlDbType.Int)
            command.Parameters.Add("@log_descripcion", SqlDbType.NVarChar)
            command.Parameters.Add("@log_aplicacion", SqlDbType.NVarChar)
            command.Parameters.Add("@log_usuario", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None

            command.Parameters(0).Value = _log_tipo
            command.Parameters(1).Value = _log_descripcion
            command.Parameters(2).Value = _log_aplicacion
            command.Parameters(3).Value = _log_usuario

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
