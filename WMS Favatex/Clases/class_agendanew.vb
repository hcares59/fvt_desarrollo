Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_agendanew
    Private _cnn As String
    Private _age_codigo As Integer
    Private _car_codigo As Integer
    Private _age_ordencompra As String
    Private _age_fechaorden As Date
    Private _eag_codigo As Integer
    Private _age_fechasujerida As Date
    Private _age_usuarioingreso As Integer
    Private _age_usuarioproceso As Integer
    Private _age_monto As Long

    Private _pro_codigo As Integer
    Private _pro_codigointerno As String
    Private _pro_nombre As String
    Private _sku_cartera As String
    Private _sku_cartera_nombre As String
    Private _ade_precio As Long
    Private _ade_cantidad As Integer
    Private _oco_numero As Long
    Private _fila_consolidado As Integer
    Private _age_cantidadagendada As Integer

    Private _age_fechaorden_string As String
    Private _bodega As String

    Public Property age_fechaorden_string() As String
        Get
            Return _age_fechaorden_string
        End Get
        Set(ByVal value As String)
            _age_fechaorden_string = value
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
    Public Property age_codigo() As Integer
        Get
            Return _age_codigo
        End Get
        Set(ByVal value As Integer)
            _age_codigo = value
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
    Public Property age_ordencompra() As String
        Get
            Return _age_ordencompra
        End Get
        Set(ByVal value As String)
            _age_ordencompra = value
        End Set
    End Property
    Public Property age_fechaorden() As Date
        Get
            Return _age_fechaorden
        End Get
        Set(ByVal value As Date)
            _age_fechaorden = value
        End Set
    End Property
    Public Property eag_codigo() As Integer
        Get
            Return _eag_codigo
        End Get
        Set(ByVal value As Integer)
            _eag_codigo = value
        End Set
    End Property
    Public Property age_fechasujerida() As Date
        Get
            Return _age_fechasujerida
        End Get
        Set(ByVal value As Date)
            _age_fechasujerida = value
        End Set
    End Property
    Public Property age_usuarioingreso() As Integer
        Get
            Return _age_usuarioingreso
        End Get
        Set(ByVal value As Integer)
            _age_usuarioingreso = value
        End Set
    End Property
    Public Property age_usuarioproceso() As Integer
        Get
            Return _age_usuarioproceso
        End Get
        Set(ByVal value As Integer)
            _age_usuarioproceso = value
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
    Public Property pro_codigointerno() As String
        Get
            Return _pro_codigointerno
        End Get
        Set(ByVal value As String)
            _pro_codigointerno = value
        End Set
    End Property
    Public Property pro_nombre() As String
        Get
            Return _pro_nombre
        End Get
        Set(ByVal value As String)
            _pro_nombre = value
        End Set
    End Property
    Public Property sku_cartera() As String
        Get
            Return _sku_cartera
        End Get
        Set(ByVal value As String)
            _sku_cartera = value
        End Set
    End Property
    Public Property sku_cartera_nombre() As String
        Get
            Return _sku_cartera_nombre
        End Get
        Set(ByVal value As String)
            _sku_cartera_nombre = value
        End Set
    End Property
    Public Property ade_precio() As Long
        Get
            Return _ade_precio
        End Get
        Set(ByVal value As Long)
            _ade_precio = value
        End Set
    End Property
    Public Property ade_cantidad() As Integer
        Get
            Return _ade_cantidad
        End Get
        Set(ByVal value As Integer)
            _ade_cantidad = value
        End Set
    End Property
    Public Property age_monto() As Long
        Get
            Return _age_monto
        End Get
        Set(ByVal value As Long)
            _age_monto = value
        End Set
    End Property
    Public Property oco_numero() As Long
        Get
            Return _oco_numero
        End Get
        Set(ByVal value As Long)
            _oco_numero = value
        End Set
    End Property
    Public Property fila_consolidado() As Integer
        Get
            Return _fila_consolidado
        End Get
        Set(ByVal value As Integer)
            _fila_consolidado = value
        End Set
    End Property
    Public Property age_cantidadagendada() As Integer
        Get
            Return _age_cantidadagendada
        End Get
        Set(ByVal value As Integer)
            _age_cantidadagendada = value
        End Set
    End Property
    Public Property bodega() As String
        Get
            Return _bodega
        End Get
        Set(ByVal value As String)
            _bodega = value
        End Set
    End Property

    Public Function AGENDA_GUARDA_DATOS_ENCABEZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_agenda_encabezado_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@age_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@age_ordencompra", SqlDbType.NVarChar)
            command.Parameters.Add("@age_fechaorden", SqlDbType.Date)
            command.Parameters.Add("@eag_codigo", SqlDbType.Int)
            command.Parameters.Add("@age_fechasujerida", SqlDbType.Date)
            command.Parameters.Add("@age_usuarioingreso", SqlDbType.Int)
            command.Parameters.Add("@age_usuarioproceso", SqlDbType.Int)
            command.Parameters.Add("@age_monto", SqlDbType.Int)

            command.Parameters(0).Value = _age_codigo
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _age_ordencompra
            command.Parameters(3).Value = _age_fechaorden
            command.Parameters(4).Value = _eag_codigo
            command.Parameters(5).Value = _age_fechasujerida
            command.Parameters(6).Value = _age_usuarioingreso
            command.Parameters(7).Value = _age_usuarioproceso
            command.Parameters(8).Value = _age_monto

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
    Public Function AGENDA_GUARDA_DATOS_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_agenda_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@age_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_cartera", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_cartera_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@ade_precio", SqlDbType.Float)
            command.Parameters.Add("@ade_cantidad", SqlDbType.Int)
            command.Parameters.Add("@oco_numero", SqlDbType.Float)
            command.Parameters.Add("@fila_consolidado", SqlDbType.Int)
            command.Parameters.Add("@age_cantidadagendada", SqlDbType.Int)

            command.Parameters(0).Value = _age_codigo
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _pro_codigo
            command.Parameters(3).Value = _pro_codigointerno
            command.Parameters(4).Value = Replace(_pro_nombre, "'", "")
            command.Parameters(5).Value = Replace(_sku_cartera, "'", "")
            command.Parameters(6).Value = Replace(_sku_cartera_nombre, "'", "")
            command.Parameters(7).Value = _ade_precio
            command.Parameters(8).Value = _ade_cantidad
            command.Parameters(9).Value = _oco_numero
            command.Parameters(10).Value = _fila_consolidado
            command.Parameters(11).Value = _age_cantidadagendada

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
    Public Function ELIMINA_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet

        Try
            Dim command As New SqlCommand("sp_agenda_detalle_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@age_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _age_codigo

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
    Public Function ELIMINA_AGENDA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_age_agenda_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@age_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _age_codigo

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
    Public Function AGENDA_CAMBIA_ESTDO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_cambia_estado_age_agenda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@age_codigo", SqlDbType.Int)
            command.Parameters.Add("@eag_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _age_codigo
            command.Parameters(1).Value = _eag_codigo

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
    Public Function AGENDA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_agenda_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@age_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_ingreso_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@eag_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _age_codigo
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _age_fechaorden_string
            command.Parameters(3).Value = _eag_codigo

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
    Public Function AGENDA_INGRESADO_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_agenda_detalle_ingresado_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@age_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _age_codigo

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
    Public Function OC_POR_FECHA_LISTADO_AGENDA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_fechas_oc_para_agenda_lista", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo

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
    Public Function OC_POR_FECHA_LISTADO_AGENDA_DETALLE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_agenda_detalle_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@oco_numero", SqlDbType.Float)
            command.Parameters.Add("@fecha", SqlDbType.Date)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = CLng(_age_ordencompra)
            command.Parameters(2).Value = _age_fechaorden

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
    Public Function CARGA_COMBO_ESTADO_AGENDA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_estado_agenda_carga_combo", conexion)

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
    Public Function CARGA_GRILLA_FECHAS_CON_AGENDA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_fechas_de_agenda_pendiente$selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
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
    Public Function CARGA_ODENES_DE_COMPRA_POR_AGENDA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_encabezado_por_agenda_selecciona", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@age_codigo", _age_codigo))
            command.Parameters.Add(New SqlParameter("@bodega", _bodega))
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

    Public Function detalle_agenda_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_agenda_detallado_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@age_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_ingreso_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@eag_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _age_codigo
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _age_fechaorden_string
            command.Parameters(3).Value = _eag_codigo

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
