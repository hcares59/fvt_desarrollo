Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_guia
    Private _cnn As String
    Private _car_codigo As Integer
    Private _gde_numero As Long

    Private _gde_fecha As Date
    Private _gde_monto As Long

    Private _fecha_inicio As String
    Private _fecha_hasta As String
    Private _gde_fila As Integer

    Public Property gde_fila() As Integer
        Get
            Return _gde_fila
        End Get
        Set(ByVal value As Integer)
            _gde_fila = value
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

    Public Property fecha_hasta() As String
        Get
            Return _fecha_hasta
        End Get
        Set(ByVal value As String)
            _fecha_hasta = value
        End Set
    End Property
    Public Property gde_monto() As Long
        Get
            Return _gde_monto
        End Get
        Set(ByVal value As Long)
            _gde_monto = value
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

    Public Property gde_numero() As Long
        Get
            Return _gde_numero
        End Get
        Set(ByVal value As Long)
            _gde_numero = value
        End Set
    End Property

    Public Function GUAS_POR_RENDIR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_guias_pendientes_retorno", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@gde_numero", SqlDbType.Float)
            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _gde_numero


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MARCA_GUIAS_RENDIDAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_guia_pendiente_cobro_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@gde_numero", SqlDbType.Float)
            command.Parameters.Add("@gde_fecha", SqlDbType.Date)
            command.Parameters.Add("@gde_monto", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _gde_numero
            command.Parameters(2).Value = _gde_fecha
            command.Parameters(3).Value = _gde_monto

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
    Public Function GUIAS_RENDIDAS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rendicion_guias_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@fecha", SqlDbType.NVarChar)
            command.Parameters.Add("@fechaHasta", SqlDbType.NVarChar)

            command.Parameters(0).Value = _fecha_inicio
            command.Parameters(1).Value = _fecha_hasta

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DEVUELVE_GUIAS_A_POR_RENDIR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_devuelve_guia_apor_rendir", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@gde_linea", SqlDbType.Int)
            command.Parameters.Add("@gde_numero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _gde_fila
            command.Parameters(2).Value = _gde_numero

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

    Public Function ANULA_GUIA_DESPACHO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_anula_guia", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@gde_numero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _gde_numero

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
