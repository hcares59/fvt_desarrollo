Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_tipo_picking
    Private _cnn As String
    Private _tpi_codigo As Integer
    Private _tpi_nombre As String
    Private _es_ventaverde As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property tpi_codigo() As Integer
        Get
            Return _tpi_codigo
        End Get
        Set(ByVal value As Integer)
            _tpi_codigo = value
        End Set
    End Property
    Public Property tpi_nombre() As String
        Get
            Return _tpi_nombre
        End Get
        Set(ByVal value As String)
            _tpi_nombre = value
        End Set
    End Property
    Public Property es_ventaverde() As Boolean
        Get
            Return _es_ventaverde
        End Get
        Set(ByVal value As Boolean)
            _es_ventaverde = value
        End Set
    End Property

    Public Function TIPO_PICKING_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_picking_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@es_ventaverde", SqlDbType.Bit)

            command.Parameters(0).Value = _es_ventaverde
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function TIPO_PICKING_CARGA_COMBO_TODOS(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_picking_carga_combo_todos", conexion)
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
