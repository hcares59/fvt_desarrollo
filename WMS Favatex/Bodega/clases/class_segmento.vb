Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_segmento
    Private _cnn As String
    Private _sca_codigo As Integer
    Private _sca_nombre As String
    Private _sca_activo As Boolean
    Private _sca_eliminado As Boolean
    Private _todos As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property sca_codigo() As Integer
        Get
            Return _sca_codigo
        End Get
        Set(ByVal value As Integer)
            _sca_codigo = value
        End Set
    End Property
    Public Property sca_nombre() As String
        Get
            Return _sca_nombre
        End Get
        Set(ByVal value As String)
            _sca_nombre = value
        End Set
    End Property
    Public Property sca_activo() As Boolean
        Get
            Return _sca_activo
        End Get
        Set(ByVal value As Boolean)
            _sca_activo = value
        End Set
    End Property
    Public Property sca_eliminado() As Boolean
        Get
            Return _sca_eliminado
        End Get
        Set(ByVal value As Boolean)
            _sca_eliminado = value
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

    Public Function CARGA_COMBO_SEGMENTO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_segmento_carga_combo", conexion)
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

    Public Function SEGMENTO_CAP_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_segmento_cap_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@sca_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _sca_codigo
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

    Public Function SEGMENTO_CAP_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_segmento_cap_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@sca_codigo", SqlDbType.Int)
            command.Parameters.Add("@sca_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@sca_activo", SqlDbType.Int)

            command.Parameters(0).Value = _sca_codigo
            command.Parameters(1).Value = _sca_nombre
            command.Parameters(2).Value = _sca_activo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function SEGMENTO_CAP_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_segmento_cap_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@sca_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _sca_codigo

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
