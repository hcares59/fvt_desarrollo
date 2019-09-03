Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class class_tipo_documento
    Private _cnn As String
    Private _tdo_codigo As Integer
    Private _tdo_nombre As String
    Private _tdo_activo As Integer
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
    Public Property tdo_codigo() As Integer
        Get
            Return _tdo_codigo
        End Get
        Set(ByVal value As Integer)
            _tdo_codigo = value
        End Set
    End Property
    Public Property tdo_nombre() As String
        Get
            Return _tdo_nombre
        End Get
        Set(ByVal value As String)
            _tdo_nombre = value
        End Set
    End Property
    Public Property sub_activo() As Boolean
        Get
            Return _tdo_activo
        End Get
        Set(ByVal value As Boolean)
            _tdo_activo = value
        End Set
    End Property
    Public Function tipodocto_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tiposdoctos_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tdo_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _tdo_codigo
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

    Public Function tipoDocto_guarda_registro(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_tiposdoctos_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tdo_codigo", SqlDbType.Int)
            command.Parameters.Add("@tdo_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@tdo_activo", SqlDbType.Int)

            command.Parameters(0).Value = _tdo_codigo
            command.Parameters(1).Value = _tdo_nombre
            command.Parameters(2).Value = _tdo_activo
            'command.ExecuteNonQuery()
            'conexion.Open()
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

    Public Function tipoDocto_elimina_registro(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_tiposdoctos_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tdo_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tdo_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function carga_combo_tipoDocto(ByRef Mensaje As String) As DataSet
        Try

            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tiposdoctos_carga_combo", conexion)
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
