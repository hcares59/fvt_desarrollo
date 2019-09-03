Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_tipomultimediacalidad
    Private _cnn As String
    Private _cal_codigo As Integer
    Private _cal_nombre As String
    Private _cal_activo As Boolean
    Private _todos As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property cal_codigo() As Integer
        Get
            Return _cal_codigo
        End Get
        Set(ByVal value As Integer)
            _cal_codigo = value
        End Set
    End Property
    Public Property cal_nombre() As String
        Get
            Return _cal_nombre
        End Get
        Set(ByVal value As String)
            _cal_nombre = value
        End Set
    End Property
    Public Property cal_activo() As Boolean
        Get
            Return _cal_activo
        End Get
        Set(ByVal value As Boolean)
            _cal_activo = value
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

    Public Function TIPO_MULTIMEDIA_CALIDAD_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_multimediacal_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@cal_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _cal_codigo
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

    Public Function TIPO_MULTIMEDIA_CALIDAD_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_multimediacal_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cal_codigo", SqlDbType.Int)
            command.Parameters.Add("@cal_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@cal_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _cal_codigo
            command.Parameters(1).Value = _cal_nombre
            command.Parameters(2).Value = _cal_activo
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

    Public Function TIPO_MULTIMEDIA_CALIDAD_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_multimediacal_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@cal_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _cal_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function TIPO_MULTIMEDIA_CALIDAD_CARGA_COMNBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_multimedia_calidad_carga_combo", conexion)
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

    Public Function TIPO_MULTIMEDIA_CALIDAD_IMG_CARGA_COMNBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_multimedia_calidad_img_carga_combo", conexion)
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
