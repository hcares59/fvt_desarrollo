Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_tipo_informe_kpi
    Private _cnn As String
    Private _meseSeleccionado As Integer
    Private _tipo_informe As Integer
    Private _usu_codigo As Integer
    Private _cod_cliente As String
    Private _fecha_desde As String
    Private _fecha_hasta As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property meseSeleccionado() As Integer
        Get
            Return _meseSeleccionado
        End Get
        Set(ByVal value As Integer)
            _meseSeleccionado = value
        End Set
    End Property
    Public Property tipo_informe() As Integer
        Get
            Return _tipo_informe
        End Get
        Set(ByVal value As Integer)
            _tipo_informe = value
        End Set
    End Property
    Public Property usu_codigo() As Integer
        Get
            Return _usu_codigo
        End Get
        Set(ByVal value As Integer)
            _usu_codigo = value
        End Set
    End Property
    Public Property cod_cliente() As String
        Get
            Return _cod_cliente
        End Get
        Set(ByVal value As String)
            _cod_cliente = value
        End Set
    End Property
    Public Property fecha_desde() As String
        Get
            Return _fecha_desde
        End Get
        Set(ByVal value As String)
            _fecha_desde = value
        End Set
    End Property
    Public Property fecha_hasta() As String
        Get
            Return _fecha_hasta
        End Get
        Set(ByVal value As String)
            _fecha_hasta = value
        End Set
    End Property

    Public Function TIPO_INFORME_KPI_CARGA_COMBO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipos_informes_carga_combo", conexion)

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

    Public Function MESES_CARGA_COMBO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_meses_carga_combo", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@numMes", _meseSeleccionado))
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

    Public Function CARGA_DATOS_PARA_TABLA_INFORME_KPI_VENTA_PENDIENTE(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_informe_ventas_pendientes", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@cod_cliente", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _cod_cliente
            command.Parameters(2).Value = _fecha_desde
            command.Parameters(3).Value = _fecha_hasta

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

    'Public Function CARGA_DATOS_PARA_TABLA_INFORME_KPI_FACTURAS_RENDIDAS_VS_POR_RENDIR(ByRef Mensaje As String) As DataSet
    '    Dim conexion As New SqlConnection(_cnn)
    '    Try
    '        Dim command As New SqlCommand("sp_informe_facturas_rendidas_vs_por_rendir", conexion)
    '        command.CommandType = CommandType.StoredProcedure

    '        command.Parameters.Add("@usu_codigo", SqlDbType.Int)
    '        command.Parameters.Add("@cod_cliente", SqlDbType.NVarChar)
    '        command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
    '        command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)

    '        command.Parameters(0).Value = _usu_codigo
    '        command.Parameters(1).Value = _cod_cliente
    '        command.Parameters(2).Value = _fecha_desde
    '        command.Parameters(3).Value = _fecha_hasta

    '        'command.ExecuteNonQuery()

    '        Dim da As New SqlDataAdapter(command)
    '        Dim ds As New DataSet

    '        da.Fill(ds)

    '        Return ds
    '    Catch ex As Exception
    '        Mensaje = ex.Message
    '        Return Nothing
    '    End Try
    'End Function

    Public Function CARGA_DATOS_PARA_TABLA_INFORME_KPI_COMPRA_VS_DESPACHO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_informe_compra_vs_despacho", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@cod_cliente", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _cod_cliente
            command.Parameters(2).Value = _fecha_desde
            command.Parameters(3).Value = _fecha_hasta

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

    Public Function LIMPIA_TABLA_INFORME_KPI(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("limpia_tabla_informe_kpi", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@tipo_informe", SqlDbType.Int)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _tipo_informe
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

    Public Function CARGA_DATOS_PARA_TABLA_INFORME_KPI_FACTURAS_RENDIDAS_VS_POR_RENDIR(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_informe_facturas_rendidas_vs_por_rendir", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@cod_cliente", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_hasta", SqlDbType.NVarChar)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _cod_cliente
            command.Parameters(2).Value = _fecha_desde
            command.Parameters(3).Value = _fecha_hasta

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

    Public Function CARGA_DATOS_PARA_FILL_RATE_RESUMEN(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_fill_rate_semanal", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@fecha_inicio", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_termino", SqlDbType.NVarChar)

            command.Parameters(0).Value = _fecha_desde
            command.Parameters(1).Value = _fecha_hasta

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

    Public Function CARGA_DATOS_PARA_FILL_RATE_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_fill_rate_semanal_detalle", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@fecha_inicio", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_termino", SqlDbType.NVarChar)

            command.Parameters(0).Value = _fecha_desde
            command.Parameters(1).Value = _fecha_hasta

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

    Public Function CARGA_DATOS_PARA_FILL_RATE_DETALLE_PICKING(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_fill_rate_semanal_detalle_picking", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@fecha_inicio", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_termino", SqlDbType.NVarChar)

            command.Parameters(0).Value = _fecha_desde
            command.Parameters(1).Value = _fecha_hasta

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

End Class
