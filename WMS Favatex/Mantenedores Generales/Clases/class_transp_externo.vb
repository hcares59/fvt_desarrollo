Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_transp_externo
    Private _cnn As String
    Private _tra_codigo As Integer
    Private _tra_nombre As String
    Private _tra_activa As Boolean
    Private _todos As Boolean

    Private _pro_codigo As Integer

    Public Property tra_codigo() As Integer
        Get
            Return _tra_codigo
        End Get
        Set(ByVal value As Integer)
            _tra_codigo = value
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

    Public Property tra_nombre() As String
        Get
            Return _tra_nombre
        End Get
        Set(ByVal value As String)
            _tra_nombre = value
        End Set
    End Property
    Public Property tra_activa() As Boolean
        Get
            Return _tra_activa
        End Get
        Set(ByVal value As Boolean)
            _tra_activa = value
        End Set
    End Property

    Public Function transp_externo_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_transp_externo_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tra_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _tra_codigo
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
    Public Function trans_guarda_registro(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_transp_externo_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tra_codigo", SqlDbType.Int)
            command.Parameters.Add("@tra_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@tra_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _tra_codigo
            command.Parameters(1).Value = _tra_nombre
            command.Parameters(2).Value = _tra_activa
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
    Public Function trans_elimina_registro(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_transp_externo_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tra_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tra_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function carga_combo_emp_extern(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_transp_extern_combo", conexion)
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
End Class
