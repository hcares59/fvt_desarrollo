Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class class_colores
    Private _cnn As String
    Private _col_codigo As Integer
    Private _col_nombre As String
    Private _col_abreviacion As String
    Private _col_activo As Integer
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
    Public Property col_codigo() As String
        Get
            Return _col_codigo
        End Get
        Set(ByVal value As String)
            _col_codigo = value
        End Set
    End Property
    Public Property col_nombre() As String
        Get
            Return _col_nombre
        End Get
        Set(ByVal value As String)
            _col_nombre = value
        End Set
    End Property
    Public Property col_activo() As Integer
        Get
            Return _col_activo
        End Get
        Set(ByVal value As Integer)
            _col_activo = value
        End Set
    End Property
    Public Property col_abreviacion() As String
        Get
            Return _col_abreviacion
        End Get
        Set(ByVal value As String)
            _col_abreviacion = value
        End Set
    End Property

    Public Function color_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_colores_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@col_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)
            command.Parameters(0).Value = _col_codigo
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
    Public Function color_guarda_registro(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_colores_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@col_codigo", SqlDbType.Int)
            command.Parameters.Add("@col_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@col_abreviacion", SqlDbType.NVarChar)
            command.Parameters.Add("@col_activo", SqlDbType.Int)
            command.Parameters(0).Value = _col_codigo
            command.Parameters(1).Value = _col_nombre
            command.Parameters(2).Value = _col_abreviacion
            command.Parameters(3).Value = _col_activo


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function elimina_resgistro(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_colores_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@col_codigo", SqlDbType.Int)


            command.Parameters(0).Value = _col_codigo

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
    Public Function VALIDA_ABREVIACION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_color_valida_abreviacion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@col_abreviacion", SqlDbType.NVarChar)

            command.Parameters(0).Value = _col_abreviacion


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
            Dim command As New SqlCommand("sp_colores_carga_combo", conexion)
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
