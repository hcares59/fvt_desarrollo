Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_glosas
    Private _cnn As String
    Private _glo_codigo As Integer
    Private _are_codigo As Integer
    Private _glo_nombre As String
    Private _glo_activo As Boolean
    Private _todos As Boolean
    Private _tdv_codigo As Integer
    Private _glo_selecc As Boolean

    Public Property glo_selecc() As Boolean
        Get
            Return _glo_selecc
        End Get
        Set(ByVal value As Boolean)
            _glo_selecc = value
        End Set
    End Property
    Public Property tdv_codigo() As Integer
        Get
            Return _tdv_codigo
        End Get
        Set(ByVal value As Integer)
            _tdv_codigo = value
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
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property glo_codigo() As Integer
        Get
            Return _glo_codigo
        End Get
        Set(ByVal value As Integer)
            _glo_codigo = value
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
    Public Property glo_nombre() As String
        Get
            Return _glo_nombre
        End Get
        Set(ByVal value As String)
            _glo_nombre = value
        End Set
    End Property
    Public Property glo_activo() As Boolean
        Get
            Return _glo_activo
        End Get
        Set(ByVal value As Boolean)
            _glo_activo = value
        End Set
    End Property

    Public Function glosas_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_glosas_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@glo_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _glo_codigo
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

    Public Function glosas_guarda_registo(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_glosas_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@glo_codigo", SqlDbType.Int)
            command.Parameters.Add("@are_codigo", SqlDbType.Int)
            command.Parameters.Add("@glo_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@glo_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _glo_codigo
            command.Parameters(1).Value = _are_codigo
            command.Parameters(2).Value = _glo_nombre
            command.Parameters(3).Value = _glo_activo

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
    Public Function glosa_elimina_registro(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_glosas_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@glo_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _glo_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function relacion_devoluciones_glosas(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_relacion_devoluciones_glosas", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tdv_codigo", SqlDbType.Int)
            command.Parameters.Add("@glo_codigo", SqlDbType.Int)
            command.Parameters.Add("@glo_selecc", SqlDbType.Bit)
            command.Parameters(0).Value = _tdv_codigo
            command.Parameters(1).Value = _glo_codigo
            command.Parameters(2).Value = _glo_selecc
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function sp_devoluciones_glosas_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_devoluciones_glosas_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tdv_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tdv_codigo
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
