Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_cargos
    Private _cnn As String
    Private _uca_codigo As Integer
    Private _uca_nombre As String

    Private _uca_activo As Integer
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
    Public Property uca_codigo() As String
        Get
            Return _uca_codigo
        End Get
        Set(ByVal value As String)
            _uca_codigo = value
        End Set
    End Property
    Public Property uca_nombre() As String
        Get
            Return _uca_nombre
        End Get
        Set(ByVal value As String)
            _uca_nombre = value
        End Set
    End Property
    Public Property uca_activo() As Integer
        Get
            Return _uca_activo
        End Get
        Set(ByVal value As Integer)
            _uca_activo = value
        End Set
    End Property
    Public Function carga_combo_cargos(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cargos_carga_combo", conexion)

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

    Public Function cargos_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cargos_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@uca_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)
            command.Parameters(0).Value = _uca_codigo
            command.Parameters(1).Value = _todos

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
    Public Function cargos_guarda_registro(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_cargos_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@uca_codigo", SqlDbType.Int)
            command.Parameters.Add("@uca_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@uca_activo", SqlDbType.NVarChar)
            command.Parameters(0).Value = _uca_codigo
            command.Parameters(1).Value = _uca_nombre
            command.Parameters(2).Value = _uca_activo


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function elimina_registro(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_cargos_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@uca_codigo", SqlDbType.Int)


            command.Parameters(0).Value = _uca_codigo

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

    Public Function COLORES_CARGA_COMNBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ucaores_carga_combo", conexion)
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
