Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_umedida
    Private _cnn As String
    Private _uni_codigo As Integer
    Private _uni_nombre As String
    Private _uni_abreviacion As String
    Private _uni_activo As Boolean
    Private _todos As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property uni_codigo() As Integer
        Get
            Return _uni_codigo
        End Get
        Set(ByVal value As Integer)
            _uni_codigo = value
        End Set
    End Property
    Public Property uni_nombre() As String
        Get
            Return _uni_nombre
        End Get
        Set(ByVal value As String)
            _uni_nombre = value
        End Set
    End Property
    Public Property uni_abreviacion() As String
        Get
            Return _uni_abreviacion
        End Get
        Set(ByVal value As String)
            _uni_abreviacion = value
        End Set
    End Property
    Public Property uni_activo() As Boolean
        Get
            Return _uni_activo
        End Get
        Set(ByVal value As Boolean)
            _uni_activo = value
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

    Public Function UMEDIDA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_umedida_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@uni_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _uni_codigo
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
    Public Function UMEDIDA_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_umedida_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@uni_codigo", SqlDbType.Int)
            command.Parameters.Add("@uni_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@uni_abreviacion", SqlDbType.NVarChar)
            command.Parameters.Add("@uni_activo", SqlDbType.Int)

            command.Parameters(0).Value = _uni_codigo
            command.Parameters(1).Value = _uni_nombre
            command.Parameters(2).Value = _uni_abreviacion
            command.Parameters(3).Value = _uni_activo
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
    Public Function UMEDIDA_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_umedida_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@uni_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _uni_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function VALIDA_ABREVIACION_UMEDIDA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_umedida_valida_abreviacion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ume_abreviacion", SqlDbType.NVarChar)

            command.Parameters(0).Value = _uni_abreviacion

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
    Public Function UMEDIDA_CARGA_COMNBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_umedida_carga_combo", conexion)
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
