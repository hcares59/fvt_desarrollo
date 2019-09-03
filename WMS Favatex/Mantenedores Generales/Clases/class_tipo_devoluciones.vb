Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_tipo_devoluciones
    Private _cnn As String
    Private _tdv_codigo As Integer
    Private _tdv_nombre As String
    Private _tdv_pendientepk As Boolean
    Private _tdv_activo As Boolean
    Private _tdv_eliminado As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Public Property tdv_nombre() As String
        Get
            Return _tdv_nombre
        End Get
        Set(ByVal value As String)
            _tdv_nombre = value
        End Set
    End Property
    Public Property tdv_pendientepk() As Boolean
        Get
            Return _tdv_pendientepk
        End Get
        Set(ByVal value As Boolean)
            _tdv_pendientepk = value
        End Set
    End Property
    Public Property tdv_activo() As Boolean
        Get
            Return _tdv_activo
        End Get
        Set(ByVal value As Boolean)
            _tdv_activo = value
        End Set
    End Property
    Public Property tdv_eliminado() As Boolean
        Get
            Return _tdv_eliminado
        End Get
        Set(ByVal value As Boolean)
            _tdv_eliminado = value
        End Set
    End Property

    Public Function TIPO_DEVOLUCION_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_devolucion_carga_combo", conexion)
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
    Public Function TIPO_DEVOLUCION_POR_PICKING_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_devolucion_por_picking_carga_combo", conexion)
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
