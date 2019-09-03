Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_areas
    Private _cnn As String
    Private _are_codigo As Integer
    Private _are_nombre As String
    Private _are_activa As Boolean
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
    Public Property are_codigo() As Integer
        Get
            Return _are_codigo
        End Get
        Set(ByVal value As Integer)
            _are_codigo = value
        End Set
    End Property
    Public Property are_nombre() As String
        Get
            Return _are_nombre
        End Get
        Set(ByVal value As String)
            _are_nombre = value
        End Set
    End Property
    Public Property are_activa() As Boolean
        Get
            Return _are_activa
        End Get
        Set(ByVal value As Boolean)
            _are_activa = value
        End Set
    End Property

    Public Function carga_combo_areas(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_areas_carga_combo", conexion)

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

    Public Function AREAS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_areas_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@are_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _are_codigo
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

    Public Function AREA_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_areas_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@are_codigo", SqlDbType.Int)
            command.Parameters.Add("@are_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@are_activa", SqlDbType.Bit)

            command.Parameters(0).Value = _are_codigo
            command.Parameters(1).Value = _are_nombre
            command.Parameters(2).Value = _are_activa

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

    Public Function AREA_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_areas_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@are_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _are_codigo
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
