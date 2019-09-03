Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_tipomultimedia
    Private _cnn As String
    Private _tmu_codigo As Integer
    Private _tmu_nombre As String
    Private _tmu_activo As Boolean
    Private _todos As Boolean
    Private _pro_codigo As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property tmu_codigo() As Integer
        Get
            Return _tmu_codigo
        End Get
        Set(ByVal value As Integer)
            _tmu_codigo = value
        End Set
    End Property
    Public Property tmu_nombre() As String
        Get
            Return _tmu_nombre
        End Get
        Set(ByVal value As String)
            _tmu_nombre = value
        End Set
    End Property
    Public Property tmu_activo() As Boolean
        Get
            Return _tmu_activo
        End Get
        Set(ByVal value As Boolean)
            _tmu_activo = value
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
    Public Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
        End Set
    End Property

    Public Function TIPO_MULTIMEDIA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tiposmultimedia_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tmu_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _tmu_codigo
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

    Public Function TIPO_MULTIMEDIA_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_tiposmultimedia_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tmu_codigo", SqlDbType.Int)
            command.Parameters.Add("@tmu_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@tmu_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _tmu_codigo
            command.Parameters(1).Value = _tmu_nombre
            command.Parameters(2).Value = _tmu_activo
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

    Public Function TIPO_MULTIMEDIA_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_tiposmultimedia_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tmu_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tmu_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function TIPO_MULTIMEDIA_CARGA_COMNBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_multimedia_carga_combo", conexion)
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
