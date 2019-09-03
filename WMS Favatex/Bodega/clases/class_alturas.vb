Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_alturas
    Private _cnn As String
    Private _alt_codigo As Integer
    Private _alt_nombre As String
    Private _alt_activo As Boolean
    Private _alt_eliminado As Boolean
    Private _todos As Boolean
    Private _alt_para_picking As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property alt_codigo() As Integer
        Get
            Return _alt_codigo
        End Get
        Set(ByVal value As Integer)
            _alt_codigo = value
        End Set
    End Property
    Public Property alt_nombre() As String
        Get
            Return _alt_nombre
        End Get
        Set(ByVal value As String)
            _alt_nombre = value
        End Set
    End Property
    Public Property alt_activo() As Boolean
        Get
            Return _alt_activo
        End Get
        Set(ByVal value As Boolean)
            _alt_activo = value
        End Set
    End Property
    Public Property alt_eliminado() As Boolean
        Get
            Return _alt_eliminado
        End Get
        Set(ByVal value As Boolean)
            _alt_eliminado = value
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
    Public Property alt_para_picking() As Boolean
        Get
            Return _alt_para_picking
        End Get
        Set(ByVal value As Boolean)
            _alt_para_picking = value
        End Set
    End Property

    Public Function CARGA_DATOS_ALTURA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_altura_carga_datos", conexion)
            command.CommandType = CommandType.StoredProcedure

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

    Public Function ALTURA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_altura_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@alt_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _alt_codigo
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

    Public Function ALTURA_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_altura_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@alt_codigo", SqlDbType.Int)
            command.Parameters.Add("@alt_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@alt_activo", SqlDbType.Int)
            command.Parameters.Add("@alt_para_picking", SqlDbType.Bit)

            command.Parameters(0).Value = _alt_codigo
            command.Parameters(1).Value = _alt_nombre
            command.Parameters(2).Value = _alt_activo
            command.Parameters(3).Value = _alt_para_picking

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ALTURA_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_altura_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@alt_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _alt_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_COMBO_ALTURA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_altura_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

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
