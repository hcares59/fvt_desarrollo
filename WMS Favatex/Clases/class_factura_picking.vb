Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_factura_picking
    Private _cnn As String
    Private _pic_codigo As Integer
    Private _pic_ocnumero As Long

    Private _fac_codigo As Long
    Private _fac_fecha As Date
    Private _fac_neto As Long
    Private _fac_iva As Long
    Private _fac_total As Long

    Private _pic_fila As Integer
    Private _fac_numero As Long
    Private _gde_numero As Long

    Private _car_codigo As Integer
    Private _fac_monto As Long
    Private _fac_linea As Integer

    Private _estado As String
    Private _fecha_inicio As String

    Private _fac_numeronc As Long
    Private _sinFecha As Boolean
    Private _fecha_hasta As String

    Private _emb_sello As String
    Private _val_numero As Long

    Public Property val_numero() As Long
        Get
            Return _val_numero
        End Get
        Set(ByVal value As Long)
            _val_numero = value
        End Set
    End Property
    Public Property emb_sello() As String
        Get
            Return _emb_sello
        End Get
        Set(ByVal value As String)
            _emb_sello = value
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

    Public Property sinFecha() As Boolean
        Get
            Return _sinFecha
        End Get
        Set(ByVal value As Boolean)
            _sinFecha = value
        End Set
    End Property
    Public Property fac_numeronc() As Long
        Get
            Return _fac_numeronc
        End Get
        Set(ByVal value As Long)
            _fac_numeronc = value
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

    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property
    Public Property fac_linea() As Long
        Get
            Return _fac_linea
        End Get
        Set(ByVal value As Long)
            _fac_linea = value
        End Set
    End Property
    Public Property fac_monto() As Long
        Get
            Return _fac_monto
        End Get
        Set(ByVal value As Long)
            _fac_monto = value
        End Set
    End Property
    Public Property car_codigo() As Long
        Get
            Return _car_codigo
        End Get
        Set(ByVal value As Long)
            _car_codigo = value
        End Set
    End Property
    Public Property gde_numero() As Long
        Get
            Return _gde_numero
        End Get
        Set(ByVal value As Long)
            _gde_numero = value
        End Set
    End Property

    Public Property fac_numero() As Long
        Get
            Return _fac_numero
        End Get
        Set(ByVal value As Long)
            _fac_numero = value
        End Set
    End Property

    Public Property pic_fila() As Integer
        Get
            Return _pic_fila
        End Get
        Set(ByVal value As Integer)
            _pic_fila = value
        End Set
    End Property
    Public Property fac_codigo() As Long
        Get
            Return _fac_codigo
        End Get
        Set(ByVal value As Long)
            _fac_codigo = value
        End Set
    End Property
    Public Property fac_fecha() As Date
        Get
            Return _fac_fecha
        End Get
        Set(ByVal value As Date)
            _fac_fecha = value
        End Set
    End Property
    Public Property fac_neto() As Long
        Get
            Return _fac_neto
        End Get
        Set(ByVal value As Long)
            _fac_neto = value
        End Set
    End Property
    Public Property fac_iva() As Long
        Get
            Return _fac_iva
        End Get
        Set(ByVal value As Long)
            _fac_iva = value
        End Set
    End Property
    Public Property fac_total() As Long
        Get
            Return _fac_total
        End Get
        Set(ByVal value As Long)
            _fac_total = value
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
    Public Property pic_codigo() As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
        End Set
    End Property
    Public Property pic_ocnumero() As Long
        Get
            Return _pic_ocnumero
        End Get
        Set(ByVal value As Long)
            _pic_ocnumero = value
        End Set
    End Property

    Public Function LISTA_ENCABEZADOS_OC_PARA_FACTURAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_para_facturar_encabezado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pic_codigo

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

    Public Function LISTA_DETALLE_OC_PARA_FACTURAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_oc_para_facturar_detalle", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            'command.Parameters.Add("@pic_ocnumero", SqlDbType.Float)

            command.Parameters(0).Value = _pic_codigo
            'command.Parameters(1).Value = _pic_ocnumero

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

    Public Function LISTA_DETALLE_GD_PARA_FACTURAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_gd_para_facturar_detalle", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@gde_numero", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            'command.Parameters.Add("@pic_ocnumero", SqlDbType.Float)

            command.Parameters(0).Value = _gde_numero
            command.Parameters(1).Value = _car_codigo
            'command.Parameters(1).Value = _pic_ocnumero

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


    Public Function PICKING_FACTURA_GUARDA_DATOS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_factura_ingresa", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_fecha", SqlDbType.Date)
            command.Parameters.Add("@pic_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@fac_neto", SqlDbType.Float)
            command.Parameters.Add("@fac_iva", SqlDbType.Float)
            command.Parameters.Add("@fac_total", SqlDbType.Float)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _fac_codigo
            command.Parameters(2).Value = _fac_fecha
            command.Parameters(3).Value = _pic_ocnumero
            command.Parameters(4).Value = _fac_neto
            command.Parameters(5).Value = _fac_iva
            command.Parameters(6).Value = _fac_total

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

    Public Function PICKING_MARCA_FILAS_FACURADAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_marca_filas_facturadas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@con_ocnumero", SqlDbType.Float)
            command.Parameters.Add("@fila", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)
            command.Parameters.Add("@fac_fecha", SqlDbType.Date)
            command.Parameters.Add("@gde_numero", SqlDbType.Float)
            command.Parameters.Add("@car_codigo", SqlDbType.Float)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_ocnumero
            command.Parameters(2).Value = _pic_fila
            command.Parameters(3).Value = _fac_numero
            command.Parameters(4).Value = _fac_fecha
            command.Parameters(5).Value = _gde_numero
            command.Parameters(6).Value = _car_codigo

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

    Public Function REVISA_FILAS_FACTURADAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_revisa_filas_facturadas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pic_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PICKING_POR_GUIA_SELECCIONA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_picking_por_guia_selecciona", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@gde_numero", SqlDbType.Int)
            command.Parameters(0).Value = _gde_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function REVISA_FILAS_FACTURADAS_DESDE_FACTURA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_revisa_filas_facturadas_desde_facturacion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pic_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function FACTURAS_POR_RENDIR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_facturas_pendientes_retorno", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Int)
            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fac_numero


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MARCA_FACTURAS_RENDIDAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_factura_pendiente_cobro_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)
            command.Parameters.Add("@fac_fecha", SqlDbType.Date)
            command.Parameters.Add("@fac_monto", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fac_numero
            command.Parameters(2).Value = _fac_fecha
            command.Parameters(3).Value = _fac_monto


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

    Public Function REVISION_FACTURAS_RENDIDAS(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_validacion_facturas_por_rendir", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fac_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MARCA_FACTURAS_ENVIADAS_A_COBRAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_envia_cobrar_facturas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_linea", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fac_linea
            command.Parameters(2).Value = _fac_numero

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

    Public Function DEVUELVE_FACTURAS_A_POR_RENDIR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_devuelve_facturas_apor_rendir", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_linea", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fac_linea
            command.Parameters(2).Value = _fac_numero

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

    Public Function REVISION_FACTURAS_POR_COBRAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            'Dim command As New SqlCommand("sp_facturas_por_cobrar", conexion)
            Dim command As New SqlCommand("sp_lista_etapas_factura", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Int)
            command.Parameters.Add("@estado", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_inicio", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_termino", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fac_numero
            command.Parameters(2).Value = _estado
            command.Parameters(3).Value = _fecha_inicio
            command.Parameters(4).Value = _fecha_hasta

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function REVISION_FACTURAS_POR_COBRAR_RESUMEN(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_lista_etapas_factura_resumen", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)

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


    Public Function MARCA_FACTURAS_COBRADAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_cobra_facturas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_linea", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fac_linea
            command.Parameters(2).Value = _fac_numero

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

    Public Function FACTURAS_REVISADAS_DESDE_GUIAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_factura_revisadas_desde_guias_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_numero", SqlDbType.Float)
            command.Parameters.Add("@fac_fecha", SqlDbType.Date)
            command.Parameters.Add("@fac_monto", SqlDbType.Float)


            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fac_numero
            command.Parameters(2).Value = _fac_fecha
            command.Parameters(3).Value = _fac_monto

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

    Public Function FACTURAS_RENDIDAS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rendicion_facturas_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@fecha", SqlDbType.NVarChar)
            command.Parameters.Add("@fechaHasta", SqlDbType.NVarChar)

            command.Parameters(0).Value = _fecha_inicio
            command.Parameters(1).Value = _fecha_hasta


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function FACTURAS_REVISADAS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_revision_facturas_rendidas_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@fecha", SqlDbType.NVarChar)
            command.Parameters.Add("@numFactura", SqlDbType.NVarChar)
            command.Parameters.Add("@sinFecha", SqlDbType.NVarChar)

            command.Parameters(0).Value = _fecha_inicio
            command.Parameters(1).Value = _fac_numero
            command.Parameters(2).Value = _sinFecha


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function FACTURAS_COBRADAS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cobro_facturas", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@fecha", SqlDbType.NVarChar)
            command.Parameters(0).Value = _fecha_inicio

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ACTUALIZA_FACTURA_NOTA_CREDITO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_actualiza_factura_nc", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fac_numeronc", SqlDbType.Decimal)
            command.Parameters.Add("@fac_numero", SqlDbType.Decimal)
            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _fac_numeronc
            command.Parameters(2).Value = _fac_numero
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

    Public Function MARCA_GUIA_FACTURADA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_marca_guia_facturada", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@nguia", SqlDbType.Float)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _gde_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MARCA_GUIAS_RENDIDAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_guias_rececion_guias_pallets", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@gde_numero", SqlDbType.Float)
            command.Parameters.Add("@val_numero", SqlDbType.Float)
            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)

            command.Parameters(0).Value = _gde_numero
            command.Parameters(1).Value = _val_numero
            command.Parameters(2).Value = _emb_sello

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

    Public Function GUIAS_RENDIDAS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_guias_despacho_pallets_enc_rendidas", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@fecha_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_Hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@nro_vale", SqlDbType.Float)

            command.Parameters(0).Value = _fecha_inicio
            command.Parameters(1).Value = _fecha_hasta
            command.Parameters(2).Value = _car_codigo
            command.Parameters(3).Value = _val_numero

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
