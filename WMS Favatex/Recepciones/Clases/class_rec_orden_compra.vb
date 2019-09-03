Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_rec_orden_compra
    Private _cnn As String
    Private _ocp_codigo As Integer
    Private _ocp_numero As Long
    Private _car_codigo As Integer
    Private _ocp_fechaorden As Date
    Private _ocp_fechallegada As Date
    Private _ocp_tipocambio As Double
    Private _ocp_numerorecepcion As Long

    Private _opd_fila As Integer
    Private _pro_codigo As Integer
    Private _pro_codigointerno As String
    Private _opd_cantidad As Integer
    Private _opd_preciounitario As Double
    Private _opd_totalfila As Double

    Private _fecha_ingreso_desde As String
    Private _fecha_hasta_desde As String
    Private _fecha_arribo_desde As String
    Private _fecha_arribo_hasta As String

    Private _eoc_codigo As Integer

    Private _ocp_ordennacional As Boolean
    Private _ocp_totalneto As Double
    Private _ocp_iva As Double
    Private _ocp_totalorden As Double
    Private _ocp_porciva As Double
    Private _usu_recepcion As Integer
    Private _usu_actual As Integer
    Private _mci_codigo As Integer

    Private _ocp_fila As Integer
    Private _ocp_nombre As String
    Private _ocp_nombrearchivo As String
    Private _ocp_url As String

    Private _ocp_empresatransporte As Integer
    Private _ocp_nfacturatransporte As Integer
    Private _ocp_fechaembarque As Date
    Private _ocp_ntransporte As Integer
    Private _ocp_nimportacion As Integer
    Private _ocp_fechapagotransporte As Date
    Private _ocp_fechavencimientotransporte As Date
    Private _ocp_valorflete As Double
    Private _ocp_nproforma As Integer
    Private _ocp_diaspago As Integer
    Private _ocp_pagofactura As Integer
    Private _ocp_condicionpago As Integer
    Private _ocp_fechapago As Date
    Private _ocp_empresadescarga As Integer
    Private _ocp_nfacturadescarga As Integer
    Private _ocp_fechadescarga As Date
    Private _ocp_banco As Integer
    Private _ocp_fechaaperturacc As Date
    Private _ocp_diaspagobanco As Integer
    Private _ocp_fechavencimientobanco As Date
    Private _ocp_agenciaaduana As Integer
    Private _ocp_numerodni As Integer
    Private _ocp_nfacturaimportacion As Integer
    Private _ocp_certificadoseguro As Integer

    Public Property ocp_empresatransporte() As Integer
        Get
            Return _ocp_empresatransporte
        End Get
        Set(ByVal value As Integer)
            _ocp_empresatransporte = value
        End Set
    End Property
    Public Property ocp_nfacturatransporte() As Integer
        Get
            Return _ocp_nfacturatransporte
        End Get
        Set(ByVal value As Integer)
            _ocp_nfacturatransporte = value
        End Set
    End Property
    Public Property ocp_fechaembarque() As Date
        Get
            Return _ocp_fechaembarque
        End Get
        Set(ByVal value As Date)
            _ocp_fechaembarque = value
        End Set
    End Property
    Public Property ocp_ntransporte() As Integer
        Get
            Return _ocp_ntransporte
        End Get
        Set(ByVal value As Integer)
            _ocp_ntransporte = value
        End Set
    End Property
    Public Property ocp_nimportacion() As Integer
        Get
            Return _ocp_nimportacion
        End Get
        Set(ByVal value As Integer)
            _ocp_nimportacion = value
        End Set
    End Property
    Public Property ocp_fechapagotransporte() As Date
        Get
            Return _ocp_fechapagotransporte
        End Get
        Set(ByVal value As Date)
            _ocp_fechapagotransporte = value
        End Set
    End Property
    Public Property ocp_fechavencimientotransporte() As Date
        Get
            Return _ocp_fechavencimientotransporte
        End Get
        Set(ByVal value As Date)
            _ocp_fechavencimientotransporte = value
        End Set
    End Property
    Public Property ocp_valorflete() As Double
        Get
            Return _ocp_valorflete
        End Get
        Set(ByVal value As Double)
            _ocp_valorflete = value
        End Set
    End Property
    Public Property ocp_nproforma() As Integer
        Get
            Return _ocp_nproforma
        End Get
        Set(ByVal value As Integer)
            _ocp_nproforma = value
        End Set
    End Property
    Public Property ocp_diaspago() As Integer
        Get
            Return _ocp_diaspago
        End Get
        Set(ByVal value As Integer)
            _ocp_diaspago = value
        End Set
    End Property
    Public Property ocp_pagofactura() As Integer
        Get
            Return _ocp_pagofactura
        End Get
        Set(ByVal value As Integer)
            _ocp_pagofactura = value
        End Set
    End Property
    Public Property ocp_condicionpago() As Integer
        Get
            Return _ocp_condicionpago
        End Get
        Set(ByVal value As Integer)
            _ocp_condicionpago = value
        End Set
    End Property
    Public Property ocp_fechapago() As Date
        Get
            Return _ocp_fechapago
        End Get
        Set(ByVal value As Date)
            _ocp_fechapago = value
        End Set
    End Property
    Public Property ocp_empresadescarga() As Integer
        Get
            Return _ocp_empresadescarga
        End Get
        Set(ByVal value As Integer)
            _ocp_empresadescarga = value
        End Set
    End Property
    Public Property ocp_nfacturadescarga() As Integer
        Get
            Return _ocp_nfacturadescarga
        End Get
        Set(ByVal value As Integer)
            _ocp_nfacturadescarga = value
        End Set
    End Property
    Public Property ocp_fechadescarga() As Date
        Get
            Return _ocp_fechadescarga
        End Get
        Set(ByVal value As Date)
            _ocp_fechadescarga = value
        End Set
    End Property
    Public Property ocp_banco() As Integer
        Get
            Return _ocp_banco
        End Get
        Set(ByVal value As Integer)
            _ocp_banco = value
        End Set
    End Property
    Public Property ocp_fechaaperturacc() As Date
        Get
            Return _ocp_fechaaperturacc
        End Get
        Set(ByVal value As Date)
            _ocp_fechaaperturacc = value
        End Set
    End Property
    Public Property ocp_diaspagobanco() As Integer
        Get
            Return _ocp_diaspagobanco
        End Get
        Set(ByVal value As Integer)
            _ocp_diaspagobanco = value
        End Set
    End Property
    Public Property ocp_fechavencimientobanco() As Date
        Get
            Return _ocp_fechavencimientobanco
        End Get
        Set(ByVal value As Date)
            _ocp_fechavencimientobanco = value
        End Set
    End Property
    Public Property ocp_agenciaaduana() As Integer
        Get
            Return _ocp_agenciaaduana
        End Get
        Set(ByVal value As Integer)
            _ocp_agenciaaduana = value
        End Set
    End Property
    Public Property ocp_numerodni() As Integer
        Get
            Return _ocp_numerodni
        End Get
        Set(ByVal value As Integer)
            _ocp_numerodni = value
        End Set
    End Property
    Public Property ocp_nfacturaimportacion() As Integer
        Get
            Return _ocp_nfacturaimportacion
        End Get
        Set(ByVal value As Integer)
            _ocp_nfacturaimportacion = value
        End Set
    End Property
    Public Property ocp_certificadoseguro() As Integer
        Get
            Return _ocp_certificadoseguro
        End Get
        Set(ByVal value As Integer)
            _ocp_certificadoseguro = value
        End Set
    End Property
    Public Property ocp_fila() As Integer
        Get
            Return _ocp_fila
        End Get
        Set(ByVal value As Integer)
            _ocp_fila = value
        End Set
    End Property
    Public Property ocp_nombre() As String
        Get
            Return _ocp_nombre
        End Get
        Set(ByVal value As String)
            _ocp_nombre = value
        End Set
    End Property
    Public Property ocp_nombrearchivo() As String
        Get
            Return _ocp_nombrearchivo
        End Get
        Set(ByVal value As String)
            _ocp_nombrearchivo = value
        End Set
    End Property
    Public Property ocp_url() As String
        Get
            Return _ocp_url
        End Get
        Set(ByVal value As String)
            _ocp_url = value
        End Set
    End Property
    Public Property mci_codigo() As Integer
        Get
            Return _mci_codigo
        End Get
        Set(ByVal value As Integer)
            _mci_codigo = value
        End Set
    End Property
    Public Property usu_actual() As Integer
        Get
            Return _usu_actual
        End Get
        Set(ByVal value As Integer)
            _usu_actual = value
        End Set
    End Property
    Public Property usu_recepcion() As Integer
        Get
            Return _usu_recepcion
        End Get
        Set(ByVal value As Integer)
            _usu_recepcion = value
        End Set
    End Property
    Public Property ocp_porciva() As Double
        Get
            Return _ocp_porciva
        End Get
        Set(ByVal value As Double)
            _ocp_porciva = value
        End Set
    End Property
    Public Property ocp_totalorden() As Double
        Get
            Return _ocp_totalorden
        End Get
        Set(ByVal value As Double)
            _ocp_totalorden = value
        End Set
    End Property
    Public Property ocp_iva() As Double
        Get
            Return _ocp_iva
        End Get
        Set(ByVal value As Double)
            _ocp_iva = value
        End Set
    End Property
    Public Property ocp_totalneto() As Double
        Get
            Return _ocp_totalneto
        End Get
        Set(ByVal value As Double)
            _ocp_totalneto = value
        End Set
    End Property
    Public Property ocp_ordennacional() As Boolean
        Get
            Return _ocp_ordennacional
        End Get
        Set(ByVal value As Boolean)
            _ocp_ordennacional = value
        End Set
    End Property
    Public Property eoc_codigo() As Integer
        Get
            Return _eoc_codigo
        End Get
        Set(ByVal value As Integer)
            _eoc_codigo = value
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
    Public Property ocp_codigo() As Integer
        Get
            Return _ocp_codigo
        End Get
        Set(ByVal value As Integer)
            _ocp_codigo = value
        End Set
    End Property
    Public Property ocp_numero() As Long
        Get
            Return _ocp_numero
        End Get
        Set(ByVal value As Long)
            _ocp_numero = value
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
    Public Property ocp_fechaorden() As Date
        Get
            Return _ocp_fechaorden
        End Get
        Set(ByVal value As Date)
            _ocp_fechaorden = value
        End Set
    End Property
    Public Property ocp_fechallegada() As Date
        Get
            Return _ocp_fechallegada
        End Get
        Set(ByVal value As Date)
            _ocp_fechallegada = value
        End Set
    End Property
    Public Property ocp_tipocambio() As Double
        Get
            Return _ocp_tipocambio
        End Get
        Set(ByVal value As Double)
            _ocp_tipocambio = value
        End Set
    End Property
    Public Property ocp_numerorecepcion() As Long
        Get
            Return _ocp_numerorecepcion
        End Get
        Set(ByVal value As Long)
            _ocp_numerorecepcion = value
        End Set
    End Property
    Public Property opd_fila() As Integer
        Get
            Return _opd_fila
        End Get
        Set(ByVal value As Integer)
            _opd_fila = value
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
    Public Property opd_cantidad() As Integer
        Get
            Return _opd_cantidad
        End Get
        Set(ByVal value As Integer)
            _opd_cantidad = value
        End Set
    End Property
    Public Property opd_preciounitario() As Double
        Get
            Return _opd_preciounitario
        End Get
        Set(ByVal value As Double)
            _opd_preciounitario = value
        End Set
    End Property
    Public Property opd_totalfila() As Double
        Get
            Return _opd_totalfila
        End Get
        Set(ByVal value As Double)
            _opd_totalfila = value
        End Set
    End Property
    Public Property fecha_ingreso_desde() As String
        Get
            Return _fecha_ingreso_desde
        End Get
        Set(ByVal value As String)
            _fecha_ingreso_desde = value
        End Set
    End Property
    Public Property fecha_hasta_desde() As String
        Get
            Return _fecha_hasta_desde
        End Get
        Set(ByVal value As String)
            _fecha_hasta_desde = value
        End Set
    End Property
    Public Property fecha_arribo_desde() As String
        Get
            Return _fecha_arribo_desde
        End Get
        Set(ByVal value As String)
            _fecha_arribo_desde = value
        End Set
    End Property
    Public Property fecha_arribo_hasta() As String
        Get
            Return _fecha_arribo_hasta
        End Get
        Set(ByVal value As String)
            _fecha_arribo_hasta = value
        End Set
    End Property

    Public Function OC_PROVEEDORES_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rec_orden_compra_listar", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))
            command.Parameters.Add(New SqlParameter("@ocp_numero", _ocp_numero))
            command.Parameters.Add(New SqlParameter("@fecha_ingreso_desde", _fecha_ingreso_desde))
            command.Parameters.Add(New SqlParameter("@fecha_hasta_desde", _fecha_hasta_desde))
            command.Parameters.Add(New SqlParameter("@fecha_arribo_desde", _fecha_arribo_desde))
            command.Parameters.Add(New SqlParameter("@fecha_arribo_hasta", _fecha_arribo_hasta))
            command.Parameters.Add(New SqlParameter("@eoc_codigo", _eoc_codigo))

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

    Public Function OC_PROVEEDORES_DETALLE_EXPORTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_orden_compra_exportar_detalle", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))
            command.Parameters.Add(New SqlParameter("@ocp_numero", _ocp_numero))
            command.Parameters.Add(New SqlParameter("@fecha_ingreso_desde", _fecha_ingreso_desde))
            command.Parameters.Add(New SqlParameter("@fecha_hasta_desde", _fecha_hasta_desde))
            command.Parameters.Add(New SqlParameter("@fecha_arribo_desde", _fecha_arribo_desde))
            command.Parameters.Add(New SqlParameter("@fecha_arribo_hasta", _fecha_arribo_hasta))
            command.Parameters.Add(New SqlParameter("@eoc_codigo", _eoc_codigo))

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

    Public Function OC_DETALLE_PROVEEDORES_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rec_orden_compra_detalle_listar", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

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

    Public Function OC_PROVEEDORES_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_rec_orden_compra_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ocp_codigo", SqlDbType.Int)
            command.Parameters.Add("@ocp_numero", SqlDbType.Float)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@ocp_fechaorden", SqlDbType.Date)
            command.Parameters.Add("@ocp_fechallegada", SqlDbType.Date)
            command.Parameters.Add("@ocp_tipocambio", SqlDbType.Decimal)
            command.Parameters.Add("@ocp_ordennacional", SqlDbType.Bit)
            command.Parameters.Add("@ocp_totalneto", SqlDbType.Decimal)
            command.Parameters.Add("@ocp_iva", SqlDbType.Decimal)
            command.Parameters.Add("@ocp_totalorden", SqlDbType.Decimal)
            command.Parameters.Add("@ocp_porciva", SqlDbType.Decimal)
            command.Parameters.Add("@ocp_empresatransporte", SqlDbType.Int)
            command.Parameters.Add("@ocp_nfacturatransporte", SqlDbType.Int)
            command.Parameters.Add("@ocp_fechaembarque", SqlDbType.Date)
            command.Parameters.Add("@ocp_ntransporte", SqlDbType.Int)
            command.Parameters.Add("@ocp_nimportacion", SqlDbType.Int)
            command.Parameters.Add("@ocp_fechapagotransporte", SqlDbType.Date)
            command.Parameters.Add("@ocp_fechavencimientotransporte", SqlDbType.Date)
            command.Parameters.Add("@ocp_valorflete", SqlDbType.Decimal)
            command.Parameters.Add("@ocp_nproforma", SqlDbType.Int)
            command.Parameters.Add("@ocp_diaspago", SqlDbType.Int)
            command.Parameters.Add("@ocp_pagofactura", SqlDbType.Int)
            command.Parameters.Add("@ocp_condicionpago", SqlDbType.Int)
            command.Parameters.Add("@ocp_fechapago", SqlDbType.Date)
            command.Parameters.Add("@ocp_empresadescarga", SqlDbType.Int)
            command.Parameters.Add("@ocp_nfacturadescarga", SqlDbType.Int)
            command.Parameters.Add("@ocp_fechadescarga", SqlDbType.Date)
            command.Parameters.Add("@ocp_banco", SqlDbType.Int)
            command.Parameters.Add("@ocp_fechaaperturacc", SqlDbType.Date)
            command.Parameters.Add("@ocp_diaspagobanco", SqlDbType.Int)
            command.Parameters.Add("@ocp_fechavencimientobanco", SqlDbType.Date)
            command.Parameters.Add("@ocp_agenciaaduana", SqlDbType.Int)
            command.Parameters.Add("@ocp_numerodni", SqlDbType.Int)
            command.Parameters.Add("@ocp_nfacturaimportacion", SqlDbType.Int)
            command.Parameters.Add("@ocp_certificadoseguro", SqlDbType.Int)


            command.Parameters(0).Value = _ocp_codigo
            command.Parameters(1).Value = _ocp_numero
            command.Parameters(2).Value = _car_codigo
            command.Parameters(3).Value = _ocp_fechaorden
            command.Parameters(4).Value = _ocp_fechallegada
            command.Parameters(5).Value = _ocp_tipocambio
            command.Parameters(6).Value = _ocp_ordennacional
            command.Parameters(7).Value = _ocp_totalneto
            command.Parameters(8).Value = _ocp_iva
            command.Parameters(9).Value = _ocp_totalorden
            command.Parameters(10).Value = _ocp_porciva
            command.Parameters(11).Value = _ocp_empresatransporte
            command.Parameters(12).Value = _ocp_nfacturatransporte
            command.Parameters(13).Value = _ocp_fechaembarque
            command.Parameters(14).Value = _ocp_ntransporte
            command.Parameters(15).Value = _ocp_nimportacion
            command.Parameters(16).Value = _ocp_fechapagotransporte
            command.Parameters(17).Value = _ocp_fechavencimientotransporte
            command.Parameters(18).Value = _ocp_valorflete
            command.Parameters(19).Value = _ocp_nproforma
            command.Parameters(20).Value = _ocp_diaspago
            command.Parameters(21).Value = _ocp_pagofactura
            command.Parameters(22).Value = _ocp_condicionpago
            command.Parameters(23).Value = _ocp_fechapago
            command.Parameters(24).Value = _ocp_empresadescarga
            command.Parameters(25).Value = _ocp_nfacturadescarga
            command.Parameters(26).Value = _ocp_fechadescarga
            command.Parameters(27).Value = _ocp_banco
            command.Parameters(28).Value = _ocp_fechaaperturacc
            command.Parameters(29).Value = _ocp_diaspagobanco
            command.Parameters(30).Value = _ocp_fechavencimientobanco
            command.Parameters(31).Value = _ocp_agenciaaduana
            command.Parameters(32).Value = _ocp_numerodni
            command.Parameters(33).Value = _ocp_nfacturaimportacion
            command.Parameters(34).Value = _ocp_certificadoseguro

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function OC_DETALLE_PROVEEDORES_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_rec_orden_compra_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ocp_codigo", SqlDbType.Int)
            command.Parameters.Add("@opd_fila", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@opd_cantidad", SqlDbType.Int)
            command.Parameters.Add("@opd_preciounitario", SqlDbType.Decimal)
            command.Parameters.Add("@opd_totalfila", SqlDbType.Decimal)

            command.Parameters(0).Value = _ocp_codigo
            command.Parameters(1).Value = _opd_fila
            command.Parameters(2).Value = _pro_codigo
            command.Parameters(3).Value = _pro_codigointerno
            command.Parameters(4).Value = _opd_cantidad
            command.Parameters(5).Value = _opd_preciounitario
            command.Parameters(6).Value = _opd_totalfila

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function OC_PROVEEDORES_ELIMINA(ByRef Msg As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            'Dim command As New SqlCommand("sp_rec_orden_compra_elimina", conexion)

            Dim command As New SqlCommand("sp_rec_orden_compra_elimina", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function OC_DETALLE_CON_SALDO_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rec_orden_compra_detalle_pendiente_listar", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@ocp_numero", _ocp_numero))

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

    Public Function REC_ORDEN_COMPRA_CAMBIA_ESTADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_rec_orden_compra_cambia_estado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ocp_codigo", SqlDbType.Int)
            command.Parameters.Add("@eoc_codigo", SqlDbType.Int)
            command.Parameters.Add("@mci_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _ocp_codigo
            command.Parameters(1).Value = _eoc_codigo
            command.Parameters(2).Value = _mci_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function REC_ORDEN_COMPRA_CAMBIA_ESTADO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_rec_orden_compra_cambia_estado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ocp_codigo", SqlDbType.Int)
            command.Parameters.Add("@eoc_codigo", SqlDbType.Int)
            command.Parameters.Add("@mci_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _ocp_codigo
            command.Parameters(1).Value = _eoc_codigo
            command.Parameters(2).Value = _mci_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function COMBO_CARGA_ESTADO_OC(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rec_orden_compra_estado_carga_combo", conexion)
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

    'PALETIZA ORDEN
    Public Function EXISTE_PALETIZADO_OC(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_existe_paletizado_orden_compra", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

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

    Public Function PALETIZAR_ORDEN_COMPRA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_desglosa_bultos_por_productos_rec_orden_compra", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

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

    Public Function PALETIZAR_ORDEN_COMPRA_SERIE(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_desglosa_bultos_por_pallet_orden_compra", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

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

    Public Function PALETIZADO_RESUMEN_SELECCIONA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_inv_orden_compra_pallet_resumen", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

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

    Public Function PALETIZADO_DETALLE_SELECCIONA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_inv_orden_compra_pallet_detalle", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

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

    Public Function REC_ORDEN_COMPRA_ASIGNA_PARA_RECEPCION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_rec_orden_compra_asigna_para_recepcion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ocp_codigo", SqlDbType.Int)
            command.Parameters.Add("@usu_recepcion", SqlDbType.Int)

            command.Parameters(0).Value = _ocp_codigo
            command.Parameters(1).Value = _usu_recepcion

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function OC_PROVEEDORES_LISTAR_VISOR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rec_orden_compra_listar_para_visor", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@usu_actual", _usu_actual))
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@usu_asignado", _usu_recepcion))

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

    Public Function OBTIENE_ESTADO_REC_ORDEN_COMPRA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_obtiene_estado_rec_orden_compra", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ocp_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ocp_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ADJUNTO_GUARDA_REGISTRO_OC_ADJUNTAR(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_adjuntos_orden_compra_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@ocp_codigo", SqlDbType.Int)
            command.Parameters.Add("@ocp_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@ocp_nombrearchivo", SqlDbType.NVarChar)
            command.Parameters.Add("@ocp_url", SqlDbType.NVarChar)
            command.Parameters.Add("@ocp_fila", SqlDbType.NVarChar)

            command.Parameters(0).Value = _ocp_codigo
            command.Parameters(1).Value = _ocp_nombre
            command.Parameters(2).Value = _ocp_nombrearchivo
            command.Parameters(3).Value = _ocp_url
            command.Parameters(4).Value = _ocp_fila

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

    Public Function ORDEN_COMPRA_ADJUNTO_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_adjuntos_orden_compra_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ORDEN_COMPRA_ADJUNTO_LISTAR(ByRef Msg As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_adjuntos_orden_compra_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ORDEN_COMPRA_ELIMINA_REGISTRO_ADJUNTO(ByRef Msg As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_rec_orden_compra_adjunto_elimina", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ocp_codigo", _ocp_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ORDEN_COMPRA_ADJUNTO_ELIMINA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("[sp_adjuntos_orden_compra_eliminar]", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ocp_codigo", SqlDbType.Int)
            command.Parameters.Add("@fila", SqlDbType.Int)

            command.Parameters(0).Value = _ocp_codigo
            command.Parameters(1).Value = _ocp_fila

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
