Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class class_solicitud_picking
    Private _cnn As String
    Private _fecha_busqueda As String
    Private _car_codigo As Integer
    Private _estado As Integer
    Private _bodega As String

    Private _fecha As Date
    Private _con_skucliente As String
    Private _con_ocnumero As Long

    Private _fecha_inicio As String
    Private _fecha_termino As String

    Private _oc_numero As Long

    Private _pic_codigo As Integer

    Private _cit_codigo As Integer
    Private _filaDetalle As Integer
    Private _age_codigo As Integer
    Private _es_abierta As Boolean

    Private _con_despachar As String

    Public Property es_abierta() As Boolean
        Get
            Return _es_abierta
        End Get
        Set(ByVal value As Boolean)
            _es_abierta = value
        End Set
    End Property

    Public Property con_despachar() As String
        Get
            Return _con_despachar
        End Get
        Set(ByVal value As String)
            _con_despachar = value
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
    Public Property fecha_busqueda() As String
        Get
            Return _fecha_busqueda
        End Get
        Set(ByVal value As String)
            _fecha_busqueda = value
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
    Public Property estado() As Integer
        Get
            Return _estado
        End Get
        Set(ByVal value As Integer)
            _estado = value
        End Set
    End Property
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Public Property con_skucliente As String
        Get
            Return _con_skucliente
        End Get
        Set(ByVal value As String)
            _con_skucliente = value
        End Set
    End Property
    Public Property con_ocnumero As Long
        Get
            Return _con_ocnumero
        End Get
        Set(ByVal value As Long)
            _con_ocnumero = value
        End Set
    End Property
    Public Property bodega As String
        Get
            Return _bodega
        End Get
        Set(ByVal value As String)
            _bodega = value
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
    Public Property pic_codigo As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
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
    Public Property cit_codigo As Integer
        Get
            Return _cit_codigo
        End Get
        Set(ByVal value As Integer)
            _cit_codigo = value
        End Set
    End Property
    Public Property filaDetalle As Integer
        Get
            Return _filaDetalle
        End Get
        Set(ByVal value As Integer)
            _filaDetalle = value
        End Set
    End Property
    Public Property age_codigo As Integer
        Get
            Return _age_codigo
        End Get
        Set(ByVal value As Integer)
            _age_codigo = value
        End Set
    End Property

    Public Function MENU_BUSCA_MENUS(ByRef Msg As String) As DataTable
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_carga_treeview_picking_sugerido", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@fecha_busqueda", _fecha_busqueda))
            Dim da As New SqlDataAdapter(command)
            Dim dt As New DataTable
            'Dim ds As New DataSet

            conexion.Open()
            da.Fill(dt)

            conexion.Close()
            Return dt
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function CARGA_DETALLE_PARA_PICKING(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_selecciona_detalles_pendientes_picking", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@fecha_busqueda", _fecha_busqueda))
            command.Parameters.Add(New SqlParameter("@estado", _estado))
            command.Parameters.Add(New SqlParameter("@bodega", _bodega))
            command.Parameters.Add(New SqlParameter("@fechaActual", _fecha_inicio))
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
    Public Function ACTUALIZA_ESTADO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_actualiza_estado_picking", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@Estado", SqlDbType.Int)
            command.Parameters.Add("@oc_fecha", SqlDbType.Date)

            command.UpdatedRowSource = UpdateRowSource.None

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _con_ocnumero
            command.Parameters(2).Value = _estado
            command.Parameters(3).Value = _fecha


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ACTUALIZA_ESTADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_actualiza_estado_picking", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@Estado", SqlDbType.Int)
            command.Parameters.Add("@oc_fecha", SqlDbType.Date)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _con_ocnumero
            command.Parameters(2).Value = _estado
            command.Parameters(3).Value = _fecha
            command.Parameters(4).Value = _pic_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ACTUALIZA_ESTADO_PICKING_ENTREGA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_actualiza_estado_picking_entrega", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@Estado", SqlDbType.Int)
            command.Parameters.Add("@oc_fecha", SqlDbType.Date)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@fila", SqlDbType.Int)
            command.Parameters.Add("@es_abierta", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _con_ocnumero
            command.Parameters(2).Value = _estado
            command.Parameters(3).Value = _fecha
            command.Parameters(4).Value = _pic_codigo
            command.Parameters(5).Value = _filaDetalle
            command.Parameters(6).Value = _es_abierta

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_COMBO_BODEGA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_bodegas_consolidadas_clietes_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.UpdatedRowSource = UpdateRowSource.None
            command.Parameters(0).Value = _car_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_GRILLA_FECHAS(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_fechas_oc_pendiente$selecciona", conexion)

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

    Public Function CARGA_GRILLA_FECHAS_CON_CITAS(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_fechas_de_citas_pendiente$selecciona", conexion)

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


    'Public Function CARGA_DETALLE_PARA_PICKING(ByRef Msg As String) As DataTable
    '    Try
    '        Dim conexion As New SqlConnection(_cnn)
    '        Dim command As New SqlCommand("sp_selecciona_detalles_pendientes_picking", conexion)

    '        command.CommandType = CommandType.StoredProcedure
    '        'command.Parameters.Add(New SqlParameter("@NUMUSU", _numUsu))
    '        Dim da As New SqlDataAdapter(command)
    '        Dim dt As New DataTable
    '        'Dim ds As New DataSet

    '        conexion.Open()
    '        da.Fill(dt)

    '        conexion.Close()
    '        Return dt
    '    Catch ex As Exception
    '        Msg = ex.Message
    '        Return Nothing
    '    End Try
    'End Function

    Public Function CARGA_ODENES_DE_COMPRA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_encabezado_selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@fecha_busqueda", _fecha_busqueda))
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

    Public Function CARGA_ODENES_DE_COMPRA_POR_CITA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_encabezado_por_cita_selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@cit_codigo", _cit_codigo))
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



    Public Function CARGA_ODENES_DE_COMPRA_DETALLE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_detalle_selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@oc_numero", _oc_numero))
            command.Parameters.Add(New SqlParameter("@epc_codigo", _estado))
            command.Parameters.Add(New SqlParameter("@oc_fecha", _fecha))
            command.Parameters.Add(New SqlParameter("@con_despachara", _con_despachar))
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

    Public Function CARGA_ODENES_DE_COMPRA_AGENDABLE_DETALLE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_detalle_agendable_selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@oc_numero", _oc_numero))
            command.Parameters.Add(New SqlParameter("@epc_codigo", _estado))
            command.Parameters.Add(New SqlParameter("@oc_fecha", _fecha))
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

    Public Function CARGA_AGENDA_ODENES_DE_COMPRA_AGENDABLE_DETALLE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_agenda_detalle_agendable_selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@oc_numero", _oc_numero))
            command.Parameters.Add(New SqlParameter("@age_codigo", _age_codigo))
            command.Parameters.Add(New SqlParameter("@oc_fecha", _fecha))
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


    Public Function CARGA_ODENES_DE_COMPRA_DETALLE_TRAN(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_detalle_selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@oc_numero", _oc_numero))
            command.Parameters.Add(New SqlParameter("@epc_codigo", _estado))
            command.Parameters.Add(New SqlParameter("@oc_fecha", _fecha))
            command.Parameters.Add(New SqlParameter("@con_despachara", _con_despachar))
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            'conexion.Open()
            da.Fill(ds)
            'conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_ODENES_DE_COMPRA_DETALLE_TRAN_AGENDA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_detalle_selecciona_agenda", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@oc_numero", _oc_numero))
            command.Parameters.Add(New SqlParameter("@epc_codigo", _estado))
            command.Parameters.Add(New SqlParameter("@oc_fecha", _fecha))
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            'conexion.Open()
            da.Fill(ds)
            'conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function


    Public Function BUSCA_VALORES_VACIO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_verifica_productos_oc", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@oc_numero", _oc_numero))
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
