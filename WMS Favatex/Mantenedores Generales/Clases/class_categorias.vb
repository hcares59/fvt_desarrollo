Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_categorias
    Private _cnn As String
    Private _cat_codigo As Integer
    Private _cat_nombre As String
    Private _cat_abreviacion As String
    Private _cat_activo As Boolean
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
    Public Property cat_codigo() As Integer
        Get
            Return _cat_codigo
        End Get
        Set(ByVal value As Integer)
            _cat_codigo = value
        End Set
    End Property
    Public Property cat_nombre() As String
        Get
            Return _cat_nombre
        End Get
        Set(ByVal value As String)
            _cat_nombre = value
        End Set
    End Property
    Public Property cat_activo() As Boolean
        Get
            Return _cat_activo
        End Get
        Set(ByVal value As Boolean)
            _cat_activo = value
        End Set
    End Property
    Public Property cat_abreviacion() As String
        Get
            Return _cat_abreviacion
        End Get
        Set(ByVal value As String)
            _cat_abreviacion = value
        End Set
    End Property

    Public Function CATEGORIA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_categoria_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _cat_codigo
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

    Public Function CATEGORIA_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_categoria_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters.Add("@cat_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@cat_abreviacion", SqlDbType.NVarChar)
            command.Parameters.Add("@cat_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _cat_codigo
            command.Parameters(1).Value = _cat_nombre
            command.Parameters(2).Value = _cat_abreviacion
            command.Parameters(3).Value = _cat_activo
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

    Public Function CATEGORIA_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_categoria_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cat_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _cat_codigo

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

    Public Function CARGA_COMBO_CATEGORIA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_categoria_carga_combo", conexion)

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

    Public Function VALIDA_ABREVIACION_CATEGORIA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_categoria_valida_abreviacion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cat_abreviacion", SqlDbType.NVarChar)

            command.Parameters(0).Value = _cat_abreviacion


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
