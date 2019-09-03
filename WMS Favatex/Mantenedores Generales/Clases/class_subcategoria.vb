Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_subcategoria
    Private _cnn As String
    Private _sub_codigo As Integer
    Private _cat_codigo As Integer
    Private _sub_nombre As String
    Private _sub_abreviacion As String
    Private _sub_activo As Boolean
    Private _todos As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property sub_codigo() As Integer
        Get
            Return _sub_codigo
        End Get
        Set(ByVal value As Integer)
            _sub_codigo = value
        End Set
    End Property
    Public Property cat_codigo() As Integer
        Get
            Return _cat_codigo
        End Get
        Set(ByVal value As Integer)
            _cat_codigo = value
        End Set
    End Property
    Public Property sub_nombre() As String
        Get
            Return _sub_nombre
        End Get
        Set(ByVal value As String)
            _sub_nombre = value
        End Set
    End Property
    Public Property sub_abreviacion() As String
        Get
            Return _sub_abreviacion
        End Get
        Set(ByVal value As String)
            _sub_abreviacion = value
        End Set
    End Property
    Public Property sub_activo() As Boolean
        Get
            Return _sub_activo
        End Get
        Set(ByVal value As Boolean)
            _sub_activo = value
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

    Public Function SUBCATEGORIA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_subcategoria_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@sub_codigo", SqlDbType.Int)
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _sub_codigo
            command.Parameters(1).Value = _cat_codigo
            command.Parameters(2).Value = _todos

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function SUBCATEGORIA_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_subcategoria_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@sub_codigo", SqlDbType.Int)
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters.Add("@sub_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@sub_abreviacion", SqlDbType.NVarChar)
            command.Parameters.Add("@sub_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _sub_codigo
            command.Parameters(1).Value = _cat_codigo
            command.Parameters(2).Value = _sub_nombre
            command.Parameters(3).Value = _sub_abreviacion
            command.Parameters(4).Value = _sub_activo
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
    Public Function SUBCATEGORIA_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_subcategoria_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@sub_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _sub_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_COMBO_SUBCATEGORIA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_subcategoria_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _cat_codigo

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
