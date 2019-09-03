Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_rack
    Private _cnn As String
    Private _rac_codigo As Integer
    Private _rac_nombre As String
    Private _rac_activo As Boolean
    Private _rac_eliminado As Boolean
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
    Public Property rac_nombre() As String
        Get
            Return _rac_nombre
        End Get
        Set(ByVal value As String)
            _rac_nombre = value
        End Set
    End Property
    Public Property rac_activo() As Boolean
        Get
            Return _rac_activo
        End Get
        Set(ByVal value As Boolean)
            _rac_activo = value
        End Set
    End Property
    Public Property rac_eliminado() As Boolean
        Get
            Return _rac_eliminado
        End Get
        Set(ByVal value As Boolean)
            _rac_eliminado = value
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

    Public Function COMBO_CARGA_RACK(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rack_carga_combo", conexion)
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
    Public Function RACK_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rack_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rac_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _rac_codigo
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

    Public Function RACK_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_rack_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rac_codigo", SqlDbType.Int)
            command.Parameters.Add("@rac_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@rac_activo", SqlDbType.Int)

            command.Parameters(0).Value = _rac_codigo
            command.Parameters(1).Value = _rac_nombre
            command.Parameters(2).Value = _rac_activo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RACK_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_rack_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rac_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _rac_codigo

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
