Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_informes
    Private _cnn As String
    Private _car_codigo As Integer
    Private _str_fecha As String
    Private _str_fechaHasta As String
    Private _str_fechaDesde As String
    Private _estado As String

    Private _epc_codigo As Integer
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
    Public Property epc_codigo() As Integer
        Get
            Return _epc_codigo
        End Get
        Set(ByVal value As Integer)
            _epc_codigo = value
        End Set
    End Property
    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property

    Public Property str_fecha() As String
        Get
            Return _str_fecha
        End Get
        Set(ByVal value As String)
            _str_fecha = value
        End Set
    End Property
    Public Property str_fechaDesde() As String
        Get
            Return _str_fechaDesde
        End Get
        Set(ByVal value As String)
            _str_fechaDesde = value
        End Set
    End Property
    Public Property str_fechaHasta() As String
        Get
            Return _str_fechaHasta
        End Get
        Set(ByVal value As String)
            _str_fechaHasta = value
        End Set
    End Property

    Public Function carga_grilla_listado_vta_pendientes(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ventas_pendientes_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@epc_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _str_fechaDesde
            command.Parameters(1).Value = _str_fechaHasta
            'command.Parameters(2).Value = _str_fechaHasta
            command.Parameters(2).Value = car_codigo
            command.Parameters(3).Value = epc_codigo
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
    Public Function carga_grilla_listado_devoluciones(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_informe_devoluciones_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)
            command.Parameters(0).Value = car_codigo
            command.Parameters(1).Value = _str_fechaDesde
            command.Parameters(2).Value = _str_fechaHasta
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

    Public Function carga_grilla_listado_uni_despachas_vs_compradas(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_informe_unidades_despachadas_y_pedidas_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)
            command.Parameters(0).Value = car_codigo
            command.Parameters(1).Value = _str_fechaDesde
            command.Parameters(2).Value = _str_fechaHasta
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
    'Public Function carga_facturas_rendidas_listado(ByRef Mensaje As String) As DataSet
    '    Try
    '        Dim conexion As New SqlConnection(_cnn)
    '        Dim command As New SqlCommand("sp_listado_facturas_rendidas", conexion)
    '        command.CommandType = CommandType.StoredProcedure
    '        command.Parameters.Add("@car_codigo", SqlDbType.Int)
    '        command.Parameters.Add("@fecha_desde", SqlDbType.Int)
    '        command.Parameters.Add("@fecha_hasta", SqlDbType.Int)
    '        command.Parameters.Add("@estado", SqlDbType.NVarChar)

    '        command.Parameters(0).Value = _car_codigo
    '        command.Parameters(1).Value = str_fechaDesde
    '        command.Parameters(2).Value = str_fechaHasta
    '        command.Parameters(3).Value = _estado

    '        Dim da As New SqlDataAdapter(command)
    '        Dim ds As New DataSet
    '        da.Fill(ds)
    '        Return ds
    '    Catch ex As Exception
    '        Mensaje = ex.Message
    '        Return Nothing
    '    End Try
    'End Function
    Public Function carga_facturas_sin_rendir_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rendicion_facturas_listado_muestra", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_desde", SqlDbType.Int)
            command.Parameters.Add("@fecha_hasta", SqlDbType.Int)
            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = str_fechaDesde
            command.Parameters(2).Value = str_fechaHasta
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function carga_facturas_rendidas_vs_por_rendir_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_listado_facturas_rendidas", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_inicio", SqlDbType.Int)
            command.Parameters.Add("@fecha_fin", SqlDbType.Int)
            command.Parameters.Add("@estado", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = str_fechaDesde
            command.Parameters(2).Value = str_fechaHasta
            command.Parameters(3).Value = _estado
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
