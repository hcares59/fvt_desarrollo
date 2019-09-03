Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_posiciones
    Private _cnn As String
    Private _rac_codigo As Integer
    Private _pos_codigo As Integer
    Private _pos_nombre As String
    Private _pos_activo As Boolean
    Private _pos_eliminado As Boolean
    Private _todos As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property rac_codigo() As Integer
        Get
            Return _rac_codigo
        End Get
        Set(ByVal value As Integer)
            _rac_codigo = value
        End Set
    End Property
    Public Property pos_codigo() As Integer
        Get
            Return _pos_codigo
        End Get
        Set(ByVal value As Integer)
            _pos_codigo = value
        End Set
    End Property
    Public Property pos_nombre() As String
        Get
            Return _pos_nombre
        End Get
        Set(ByVal value As String)
            _pos_nombre = value
        End Set
    End Property
    Public Property pos_activo() As Boolean
        Get
            Return _pos_activo
        End Get
        Set(ByVal value As Boolean)
            _pos_activo = value
        End Set
    End Property
    Public Property pos_eliminado() As Boolean
        Get
            Return _pos_eliminado
        End Get
        Set(ByVal value As Boolean)
            _pos_eliminado = value
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

    Public Function CARGA_DATOS_POSICION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_posicion_carga_datos", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@rac_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _rac_codigo

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

    Public Function POSICION_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_posicion_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pos_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _pos_codigo
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
    Public Function POSICION_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_posicion_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pos_codigo", SqlDbType.Int)
            command.Parameters.Add("@rac_codigo", SqlDbType.Int)
            command.Parameters.Add("@pos_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@pos_activo", SqlDbType.Int)

            command.Parameters(0).Value = _pos_codigo
            command.Parameters(1).Value = _rac_codigo
            command.Parameters(2).Value = _pos_nombre
            command.Parameters(3).Value = _pos_activo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function POSICION_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_posicion_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pos_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pos_codigo

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
