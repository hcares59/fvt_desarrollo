Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_agenda
    Private _cnn As String
    Private _car_codigo As Integer
    Private _fecha_inicio As String
    Private _fecha_termino As String
    Private _estado As Integer
    Private _con_ocnumero As Long
    Private _oc_numero As Long

    Private _fecha_orden As String
    Private _bodegas As String

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property car_codigo() As Integer
        Get
            Return _car_codigo
        End Get
        Set(ByVal value As Integer)
            _car_codigo = value
        End Set
    End Property
    Public Property fecha_inicio() As String
        Get
            Return _fecha_inicio
        End Get
        Set(ByVal value As String)
            _fecha_inicio = value
        End Set
    End Property
    Public Property fecha_termino() As String
        Get
            Return _fecha_termino
        End Get
        Set(ByVal value As String)
            _fecha_termino = value
        End Set
    End Property

    Public Property fecha_orden() As String
        Get
            Return _fecha_orden
        End Get
        Set(ByVal value As String)
            _fecha_orden = value
        End Set
    End Property
    Public Property bodegas() As String
        Get
            Return _bodegas
        End Get
        Set(ByVal value As String)
            _bodegas = value
        End Set
    End Property

    Public Property estado() As Integer
        Get
            Return _estado
        End Get
        Set(ByVal value As Integer)
            _estado = value
        End Set
    End Property
    Public Property oc_numero As Long
        Get
            Return _oc_numero
        End Get
        Set(ByVal value As Long)
            _oc_numero = value
        End Set
    End Property

    Public Function CARGA_GRILLA_FECHAS_PARA_AGENDAS(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_fechas_oc_pendiente_para_agenda$selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@fecha_inicio", _fecha_inicio))
            command.Parameters.Add(New SqlParameter("@fecha_fin", _fecha_termino))

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_GRILLA_OC_PARA_AGENDAS(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_encabezado_agenda", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@fecha_desde", _fecha_inicio))

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_ODENES_DE_COMPRA_DETALLE_PARA_AGENDA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_detalle_selecciona_para_agenda", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@oc_numero", _oc_numero))
            command.Parameters.Add(New SqlParameter("@epc_codigo", _estado))
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            conexion.Open()
            da.Fill(ds)
            conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_ODENES_DE_COMPRA_DETALLE_PARA_AGENDA_SELECCIONA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_detalle_para_agendar_selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@fecha_busqueda", _fecha_orden))
            command.Parameters.Add(New SqlParameter("@bodega", _bodegas))
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            conexion.Open()
            da.Fill(ds)
            conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function





End Class
