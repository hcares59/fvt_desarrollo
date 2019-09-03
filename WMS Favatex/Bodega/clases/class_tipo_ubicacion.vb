Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_tipo_ubicacion
    Private _cnn As String
    Private _tub_codigo As Integer
    Private _bod_codigo As Integer
    Private _tub_nombre As String
    Private _tub_activo As Boolean
    Private _tub_eliminado As Boolean
    Private _todos As Boolean
    Private _tub_cambiaestado As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property tub_codigo() As Integer
        Get
            Return _tub_codigo
        End Get
        Set(ByVal value As Integer)
            _tub_codigo = value
        End Set
    End Property
    Public Property bod_codigo() As Integer
        Get
            Return _bod_codigo
        End Get
        Set(ByVal value As Integer)
            _bod_codigo = value
        End Set
    End Property
    Public Property tub_nombre() As String
        Get
            Return _tub_nombre
        End Get
        Set(ByVal value As String)
            _tub_nombre = value
        End Set
    End Property
    Public Property tub_activo() As Boolean
        Get
            Return _tub_activo
        End Get
        Set(ByVal value As Boolean)
            _tub_activo = value
        End Set
    End Property
    Public Property tub_eliminado() As Boolean
        Get
            Return _tub_eliminado
        End Get
        Set(ByVal value As Boolean)
            _tub_eliminado = value
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
    Public Property tub_cambiaestado() As Boolean
        Get
            Return _tub_cambiaestado
        End Get
        Set(ByVal value As Boolean)
            _tub_cambiaestado = value
        End Set
    End Property

    Public Function COMBO_CARGA_TIPO_UBICACION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_ubicacion_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _bod_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_BODEGAS_UBICACION_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodegas_tipos_ubicaciones_por_bodega_listado", conexion)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _bod_codigo
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

    Public Function TIPOS_UBICACIONES_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_ubicaciones_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tub_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)
            command.Parameters.Add("@nombre", SqlDbType.NVarChar)

            command.Parameters(0).Value = _tub_codigo
            command.Parameters(1).Value = _todos
            command.Parameters(2).Value = _tub_nombre

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function TIPO_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_tipoubicacion_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tub_codigo", SqlDbType.Int)
            command.Parameters.Add("@tub_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@tub_activo", SqlDbType.Int)
            command.Parameters.Add("@tub_cambiaestado", SqlDbType.Bit)

            command.Parameters(0).Value = _tub_codigo
            command.Parameters(1).Value = _tub_nombre
            command.Parameters(2).Value = _tub_activo
            command.Parameters(3).Value = _tub_cambiaestado

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function TIPO_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_tipoubicacion_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tub_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tub_codigo

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
