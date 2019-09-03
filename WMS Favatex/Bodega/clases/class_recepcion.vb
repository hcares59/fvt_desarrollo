Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_recepcion
    Private _cnn As String
    Private _codigo As String
    Private _cantidad As Integer

    Private _rec_numero As Integer
    Private _car_codigo As Integer
    Private _rec_nguia As Long
    Private _rec_nfactura As Long
    Private _emp_codigo As Integer
    Private _rec_fecharecepcion As Date
    Private _rec_fechaingreso As Date
    Private _rec_empingreso As Integer
    Private _rec_nombrechofer As String
    Private _rec_patente As String
    Private _rec_observacion As String

    Private _pro_codigo As Integer
    Private _pro_codigointerno As String
    Private _pro_nombre As String
    Private _rde_bulto As Integer
    Private _rde_bultondem As String
    Private _rde_bultoporpallet As Double
    Private _rde_bultoporpalletdoble As Double
    Private _rde_bultoporpalletexistente As Double
    Private _rde_bultoporpalletdobleexistente As Double
    Private _rde_tipofila As String
    Private _pro_codigorel As Integer

    Private _fecha_desde As String
    Private _fecha_hasta As String
    Private _rec_ordencompra As Long
    Private _rde_cantidad As Integer
    Private _ere_codigo As Integer

    Private _rec_fila As Integer
    Private _rde_bultosunidad As Integer
    Private _ocp_codigo As Long
    Private _ocp_numero As Long
    Private _opd_fila As Integer

    Private _rec_nombre As String
    Private _rec_nombrearchivo As String
    Private _rec_url As String

    Private _rec_codigo As Integer
    Private _pre_cantidad As Integer
    Private _pre_bxpn As Integer
    Private _pre_cpn As Integer
    Private _pre_bxpd As Integer
    Private _pre_cpd As Integer
    Private _tipofila As String

    Private _prd_codigo As Integer
    Private _prd_palletserie As String
    Private _prs_codigo As Integer
    Private _prs_serie As String
    Private _pro_numbulto As Integer

    Private _prm_codigo As Integer
    Private _prm_tipo As String
    Private _prm_observacion As String
    Private _usu_codigo As Integer
    Private _bod_codigo As Integer

    Private _prs_consalida As Boolean
    Private _mov_folio As Long
    Private _rde_folio As String
    Private _cant_resepcionada As Integer
    Private _cant_fil As Integer
    Private _num_traspaso As Long

    Private _cantidad_muestra As Integer
    Private _bul_unidad As Integer
    Private _bul_total As Integer
    Private _ede_codigo As Integer

    Public Property ede_codigo() As Integer
        Get
            Return _ede_codigo
        End Get
        Set(ByVal value As Integer)
            _ede_codigo = value
        End Set
    End Property
    Public Property cantidad_muestra() As Integer
        Get
            Return _cantidad_muestra
        End Get
        Set(ByVal value As Integer)
            _cantidad_muestra = value
        End Set
    End Property
    Public Property bul_unidad() As Integer
        Get
            Return _bul_unidad
        End Get
        Set(ByVal value As Integer)
            _bul_unidad = value
        End Set
    End Property
    Public Property bul_total() As Integer
        Get
            Return _bul_total
        End Get
        Set(ByVal value As Integer)
            _bul_total = value
        End Set
    End Property

    Public Property num_traspaso() As Integer
        Get
            Return _num_traspaso
        End Get
        Set(ByVal value As Integer)
            _num_traspaso = value
        End Set
    End Property
    Public Property cant_fil() As Integer
        Get
            Return _cant_fil
        End Get
        Set(ByVal value As Integer)
            _cant_fil = value
        End Set
    End Property
    Public Property cant_resepcionada() As Integer
        Get
            Return _cant_resepcionada
        End Get
        Set(ByVal value As Integer)
            _cant_resepcionada = value
        End Set
    End Property
    Public Property rde_folio() As String
        Get
            Return _rde_folio
        End Get
        Set(ByVal value As String)
            _rde_folio = value
        End Set
    End Property
    Public Property mov_folio() As Long
        Get
            Return _mov_folio
        End Get
        Set(ByVal value As Long)
            _mov_folio = value
        End Set
    End Property
    Public Property prs_consalida() As Boolean
        Get
            Return _prs_consalida
        End Get
        Set(ByVal value As Boolean)
            _prs_consalida = value
        End Set
    End Property
    Public Property prm_codigo() As String
        Get
            Return _prm_codigo
        End Get
        Set(ByVal value As String)
            _prm_codigo = value
        End Set
    End Property
    Public Property prm_tipo() As String
        Get
            Return _prm_tipo
        End Get
        Set(ByVal value As String)
            _prm_tipo = value
        End Set
    End Property
    Public Property prm_observacion() As String
        Get
            Return _prm_observacion
        End Get
        Set(ByVal value As String)
            _prm_observacion = value
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
    Public Property bod_codigo() As Integer
        Get
            Return _bod_codigo
        End Get
        Set(ByVal value As Integer)
            _bod_codigo = value
        End Set
    End Property

    Public Property pro_numbulto() As Integer
        Get
            Return _pro_numbulto
        End Get
        Set(ByVal value As Integer)
            _pro_numbulto = value
        End Set
    End Property
    Public Property prs_serie() As String
        Get
            Return _prs_serie
        End Get
        Set(ByVal value As String)
            _prs_serie = value
        End Set
    End Property
    Public Property prs_codigo() As Integer
        Get
            Return _prs_codigo
        End Get
        Set(ByVal value As Integer)
            _prs_codigo = value
        End Set
    End Property
    Public Property prd_palletserie() As String
        Get
            Return _prd_palletserie
        End Get
        Set(ByVal value As String)
            _prd_palletserie = value
        End Set
    End Property
    Public Property prd_codigo() As Integer
        Get
            Return _prd_codigo
        End Get
        Set(ByVal value As Integer)
            _prd_codigo = value
        End Set
    End Property

    Public Property rec_codigo() As Integer
        Get
            Return _rec_codigo
        End Get
        Set(ByVal value As Integer)
            _rec_codigo = value
        End Set
    End Property
    Public Property pre_cantidad() As Integer
        Get
            Return _pre_cantidad
        End Get
        Set(ByVal value As Integer)
            _pre_cantidad = value
        End Set
    End Property
    Public Property pre_bxpn() As Integer
        Get
            Return _pre_bxpn
        End Get
        Set(ByVal value As Integer)
            _pre_bxpn = value
        End Set
    End Property
    Public Property pre_cpn() As Integer
        Get
            Return _pre_cpn
        End Get
        Set(ByVal value As Integer)
            _pre_cpn = value
        End Set
    End Property
    Public Property pre_bxpd() As Integer
        Get
            Return _pre_bxpd
        End Get
        Set(ByVal value As Integer)
            _pre_bxpd = value
        End Set
    End Property
    Public Property pre_cpd() As Integer
        Get
            Return _pre_cpd
        End Get
        Set(ByVal value As Integer)
            _pre_cpd = value
        End Set
    End Property
    Public Property tipofila() As String
        Get
            Return _tipofila
        End Get
        Set(ByVal value As String)
            _tipofila = value
        End Set
    End Property


    Public Property rec_url() As String
        Get
            Return _rec_url
        End Get
        Set(ByVal value As String)
            _rec_url = value
        End Set
    End Property
    Public Property rec_nombrearchivo() As String
        Get
            Return _rec_nombrearchivo
        End Get
        Set(ByVal value As String)
            _rec_nombrearchivo = value
        End Set
    End Property
    Public Property rec_nombre() As String
        Get
            Return _rec_nombre
        End Get
        Set(ByVal value As String)
            _rec_nombre = value
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
    Public Property ocp_numero() As Long
        Get
            Return ocp_numero
        End Get
        Set(ByVal value As Long)
            _ocp_numero = value
        End Set
    End Property
    Public Property ocp_codigo() As Long
        Get
            Return _ocp_codigo
        End Get
        Set(ByVal value As Long)
            _ocp_codigo = value
        End Set
    End Property
    Public Property rec_fila() As Integer
        Get
            Return _rec_fila
        End Get
        Set(ByVal value As Integer)
            _rec_fila = value
        End Set
    End Property
    Public Property rde_bultosunidad() As Integer
        Get
            Return _rde_bultosunidad
        End Get
        Set(ByVal value As Integer)
            _rde_bultosunidad = value
        End Set
    End Property

    Public Property ere_codigo() As Integer
        Get
            Return _ere_codigo
        End Get
        Set(ByVal value As Integer)
            _ere_codigo = value
        End Set
    End Property
    Public Property rde_cantidad() As Long
        Get
            Return _rde_cantidad
        End Get
        Set(ByVal value As Long)
            _rde_cantidad = value
        End Set
    End Property
    Public Property rec_ordencompra() As Long
        Get
            Return _rec_ordencompra
        End Get
        Set(ByVal value As Long)
            _rec_ordencompra = value
        End Set
    End Property
    Public Property fecha_desde() As Integer
        Get
            Return _fecha_desde
        End Get
        Set(ByVal value As Integer)
            _fecha_desde = value
        End Set
    End Property
    Public Property fecha_hasta() As Integer
        Get
            Return _fecha_hasta
        End Get
        Set(ByVal value As Integer)
            _fecha_hasta = value
        End Set
    End Property

    Public Property rec_numero() As Integer
        Get
            Return _rec_numero
        End Get
        Set(ByVal value As Integer)
            _rec_numero = value
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
    Public Property rec_nguia() As Long
        Get
            Return _rec_nguia
        End Get
        Set(ByVal value As Long)
            _rec_nguia = value
        End Set
    End Property
    Public Property rec_nfactura() As Long
        Get
            Return _rec_nfactura
        End Get
        Set(ByVal value As Long)
            _rec_nfactura = value
        End Set
    End Property
    Public Property emp_codigo() As Integer
        Get
            Return _emp_codigo
        End Get
        Set(ByVal value As Integer)
            _emp_codigo = value
        End Set
    End Property
    Public Property rec_fecharecepcion() As Date
        Get
            Return _rec_fecharecepcion
        End Get
        Set(ByVal value As Date)
            _rec_fecharecepcion = value
        End Set
    End Property
    Public Property rec_fechaingreso() As Date
        Get
            Return _rec_fechaingreso
        End Get
        Set(ByVal value As Date)
            _rec_fechaingreso = value
        End Set
    End Property
    Public Property rec_empingreso() As Integer
        Get
            Return _rec_empingreso
        End Get
        Set(ByVal value As Integer)
            _rec_empingreso = value
        End Set
    End Property
    Public Property rec_nombrechofer() As String
        Get
            Return _rec_nombrechofer
        End Get
        Set(ByVal value As String)
            _rec_nombrechofer = value
        End Set
    End Property
    Public Property rec_patente() As String
        Get
            Return _rec_patente
        End Get
        Set(ByVal value As String)
            _rec_patente = value
        End Set
    End Property
    Public Property rec_observacion() As String
        Get
            Return _rec_observacion
        End Get
        Set(ByVal value As String)
            _rec_observacion = value
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
    Public Property rde_bulto() As Integer
        Get
            Return _rde_bulto
        End Get
        Set(ByVal value As Integer)
            _rde_bulto = value
        End Set
    End Property
    Public Property rde_bultondem() As String
        Get
            Return _rde_bultondem
        End Get
        Set(ByVal value As String)
            _rde_bultondem = value
        End Set
    End Property
    Public Property rde_bultoporpallet() As Double
        Get
            Return _rde_bultoporpallet
        End Get
        Set(ByVal value As Double)
            _rde_bultoporpallet = value
        End Set
    End Property
    Public Property rde_bultoporpalletdoble() As Double
        Get
            Return _rde_bultoporpalletdoble
        End Get
        Set(ByVal value As Double)
            _rde_bultoporpalletdoble = value
        End Set
    End Property
    Public Property rde_bultoporpalletexistente() As Double
        Get
            Return _rde_bultoporpalletexistente
        End Get
        Set(ByVal value As Double)
            _rde_bultoporpalletexistente = value
        End Set
    End Property
    Public Property rde_bultoporpalletdobleexistente() As Double
        Get
            Return _rde_bultoporpalletdobleexistente
        End Get
        Set(ByVal value As Double)
            _rde_bultoporpalletdobleexistente = value
        End Set
    End Property
    Public Property rde_tipofila() As String
        Get
            Return _rde_tipofila
        End Get
        Set(ByVal value As String)
            _rde_tipofila = value
        End Set
    End Property
    Public Property pro_codigorel() As Integer
        Get
            Return _pro_codigorel
        End Get
        Set(ByVal value As Integer)
            _pro_codigorel = value
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
    Public Property codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Function DESGLOSA_PRODUCTOS_POR_BULTO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_desglosa_bultos_por_productos", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@codigo", SqlDbType.NVarChar)
            command.Parameters.Add("@cantidad", SqlDbType.Int)

            command.Parameters(0).Value = _codigo
            command.Parameters(1).Value = _cantidad

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function RECEPCION_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_recepcion_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@rec_nguia", SqlDbType.Float)
            command.Parameters.Add("@rec_nfactura", SqlDbType.Float)
            command.Parameters.Add("@rec_ordencompra", SqlDbType.Float)
            command.Parameters.Add("@emp_codigo", SqlDbType.Int)
            command.Parameters.Add("@rec_fecharecepcion", SqlDbType.Date)
            command.Parameters.Add("@rec_empingreso", SqlDbType.Int)
            command.Parameters.Add("@rec_nombrechofer", SqlDbType.NVarChar)
            command.Parameters.Add("@rec_patente", SqlDbType.NVarChar)
            command.Parameters.Add("@rec_observacion", SqlDbType.NVarChar)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _rec_nguia
            command.Parameters(3).Value = _rec_nfactura
            command.Parameters(4).Value = _rec_ordencompra
            command.Parameters(5).Value = _emp_codigo
            command.Parameters(6).Value = _rec_fecharecepcion
            command.Parameters(7).Value = _rec_empingreso
            command.Parameters(8).Value = _rec_nombrechofer
            command.Parameters(9).Value = _rec_patente
            command.Parameters(10).Value = _rec_observacion

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_DETALLE_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_recepcion_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@rec_fila", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@rde_cantidad", SqlDbType.Int)
            command.Parameters.Add("@rde_bulto", SqlDbType.Int)
            command.Parameters.Add("@rde_bultosunidad", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@ocp_numero", SqlDbType.Float)
            command.Parameters.Add("@opd_fila", SqlDbType.Int)
            command.Parameters.Add("@rde_lote", SqlDbType.NVarChar)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _rec_fila
            command.Parameters(2).Value = _pro_codigo
            command.Parameters(3).Value = _pro_codigointerno
            command.Parameters(4).Value = _pro_nombre
            command.Parameters(5).Value = _rde_cantidad
            command.Parameters(6).Value = _rde_bulto
            command.Parameters(7).Value = _rde_bultosunidad
            command.Parameters(8).Value = _car_codigo
            command.Parameters(9).Value = _ocp_numero
            command.Parameters(10).Value = _opd_fila
            command.Parameters(11).Value = _rde_folio


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_recepcion_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters(0).Value = _rec_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCIONES_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_recepcion_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@rec_numero", _rec_numero))
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@rec_nguia", _rec_nguia))
            command.Parameters.Add(New SqlParameter("@rec_nfactura", _rec_nfactura))
            command.Parameters.Add(New SqlParameter("@rec_ordencompra", _rec_ordencompra))
            command.Parameters.Add(New SqlParameter("@fecha_desde", _fecha_desde))
            command.Parameters.Add(New SqlParameter("@fecha_hasta", _fecha_hasta))
            command.Parameters.Add(New SqlParameter("@ere_codigo", _ere_codigo))

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

    Public Function RECEPCIONES_DETALLE_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_recepcion_detalle_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@rec_numero", _rec_numero))

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


    Public Function RECEPCION_CAMBIA_ESTADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_recepcion_cambia_estado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@ere_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@ocp_numero", SqlDbType.Float)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _ere_codigo
            command.Parameters(2).Value = _car_codigo
            command.Parameters(3).Value = _ocp_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_COMBO_ESTADO_RECEPCION(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_estado_recepcion_carga_combo", conexion)

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

    Public Function RECEPCION_ELIMINA_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_recepcion_detalle_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _rec_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ADJUNTO_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_adjuntos_recepcion_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@rec_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@rec_nombrearchivo", SqlDbType.NVarChar)
            command.Parameters.Add("@rec_url", SqlDbType.NVarChar)
            command.Parameters.Add("@rec_fila", SqlDbType.NVarChar)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _rec_nombre
            command.Parameters(2).Value = _rec_nombrearchivo
            command.Parameters(3).Value = _rec_url
            command.Parameters(4).Value = _rec_fila

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

    Public Function RECEPCIONES_ADJUNTO_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_recepcion_adjunto_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@rec_numero", _rec_numero))

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

    Public Function RECEPCIONES_ADJUNTO_ELIMINA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_recepcion_adjunto_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@fila", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _rec_fila

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PALETIZAR_RECEPCION(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_desglosa_bultos_por_productos_recepcion", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@nrecepcion", _rec_numero))

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

    Public Function PALETIZAR_RECEPCION_SERIE(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_desglosa_bultos_por_pallet_recepcion", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@nrecepcion", _rec_numero))

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

    Public Function EXISTE_PALETIZADO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_existe_paletizado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@rec_codigo", _rec_numero))

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
            Dim command As New SqlCommand("sp_inv_recepcion_pallet_resumen", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@rec_codigo", _rec_numero))

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
            Dim command As New SqlCommand("sp_inv_recepcion_pallet_detalle", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@rec_codigo", _rec_numero))

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

    Public Function PALETIZADO_RESUMEN_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_inv_recepcion_pallet_resumen_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@pre_cantidad", SqlDbType.Int)
            command.Parameters.Add("@pre_bxpn", SqlDbType.Int)
            command.Parameters.Add("@pre_cpn", SqlDbType.Int)
            command.Parameters.Add("@pre_bxpd", SqlDbType.Int)
            command.Parameters.Add("@pre_cpd", SqlDbType.Int)
            command.Parameters.Add("@tipofila", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_codigorel", SqlDbType.Int)
            command.Parameters.Add("@cant_fil", SqlDbType.Int)

            command.Parameters(0).Value = _rec_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _pro_codigointerno
            command.Parameters(3).Value = _pro_nombre
            command.Parameters(4).Value = _pre_cantidad
            command.Parameters(5).Value = _pre_bxpn
            command.Parameters(6).Value = _pre_cpn
            command.Parameters(7).Value = _pre_bxpd
            command.Parameters(8).Value = _pre_cpd
            command.Parameters(9).Value = _tipofila
            command.Parameters(10).Value = _pro_codigorel
            command.Parameters(11).Value = _cant_fil

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PALETIZADO_RESUMEN_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_inv_recepcion_pallet_resumen_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _rec_codigo


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function CIERRA_RECEPCION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_cierra_recepcion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters.Add("@cant_fil", SqlDbType.Int)

            command.Parameters(0).Value = _rec_codigo
            command.Parameters(1).Value = _cant_fil

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

    Public Function DETALLE_MOVIMIENTO_PALETIZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_productos_selecciona_carga_inventario_recepcion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            'command.Parameters.Add("@cant_fil", SqlDbType.Int)

            command.Parameters(0).Value = _rec_codigo
            'command.Parameters(1).Value = _cant_fil

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
    Public Function RECEPCION_PALLET_LISTADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_pallet_recepcion_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _rec_codigo

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

    Public Function RECEPCION_PRODUCTO_SERIE_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_inv_recepcion_producto_serie_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters.Add("@prd_codigo", SqlDbType.Int)
            command.Parameters.Add("@prd_palletserie", SqlDbType.NVarChar)
            command.Parameters.Add("@prs_codigo", SqlDbType.NVarChar)
            command.Parameters.Add("@prs_serie", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_codigo", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_numbulto", SqlDbType.Int)

            command.Parameters(0).Value = _rec_codigo
            command.Parameters(1).Value = _prd_codigo
            command.Parameters(2).Value = _prd_palletserie
            command.Parameters(3).Value = _prs_codigo
            command.Parameters(4).Value = _prs_serie
            command.Parameters(5).Value = _pro_codigo
            command.Parameters(6).Value = _pro_numbulto

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_PRODUCTO_SERIE_MOVIMINETO_GUARDAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_inv_recepcion_producto_serie_movimiento_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@prm_codigo", SqlDbType.Int)
            command.Parameters.Add("@prm_tipo", SqlDbType.NVarChar)
            command.Parameters.Add("@prs_serie", SqlDbType.NVarChar)
            command.Parameters.Add("@prd_palletserie", SqlDbType.NVarChar)
            command.Parameters.Add("@prm_observacion", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@prs_consalida", SqlDbType.Bit)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@mov_folio", SqlDbType.Float)

            command.Parameters(0).Value = _prm_codigo
            command.Parameters(1).Value = _prm_tipo
            command.Parameters(2).Value = _prs_serie
            command.Parameters(3).Value = _prd_palletserie
            command.Parameters(4).Value = _prm_observacion
            command.Parameters(5).Value = _usu_codigo
            command.Parameters(6).Value = _bod_codigo
            command.Parameters(7).Value = _prs_consalida
            command.Parameters(8).Value = _pro_codigo
            command.Parameters(9).Value = _mov_folio

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_PRODUCTO_SERIE_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_recepcion_producto_serie_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _rec_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MARCA_SALIDA_SERIE_MOVIMIENTO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_marca_salida_serie_movimiento", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@prs_serie", SqlDbType.NVarChar)
            command.Parameters.Add("@prd_palletserie", SqlDbType.NVarChar)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _prs_serie
            command.Parameters(1).Value = _prd_palletserie
            command.Parameters(2).Value = _bod_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function COMBO_PRODUCTO_POR_RECEPCION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_producto_recepcion_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _rec_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function COMBO_PALLET_POR_RECEPCION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_pallet_recepcion_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _rec_codigo
            command.Parameters(1).Value = _pro_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PRODUCTOS_RECEPCION_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_productos_recepcion_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            'command.Parameters.Add("@cant_fil", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero
            'command.Parameters(1).Value = _cant_fil

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function BULTOS_MOV_RECEPCION_LISTADO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_bultos_mov_recepcion_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _pro_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ACTUALIZA_UBICACIONES_PALLET(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_pallet_ubicacion_actualiza", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _usu_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ACTUALIZA_ESTADO_ITEM_RECEPCION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_estado_item_recepcion_actualiza", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@rde_cantidadconsumida", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _cant_resepcionada

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_ACTUALIZA_NUMERO_TRASPASO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_recepcion_num_traspaso_actualiza", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@rec_fila", SqlDbType.Int)
            command.Parameters.Add("@num_traspaso", SqlDbType.Float)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _rec_fila
            command.Parameters(2).Value = _num_traspaso

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_GUARDA_MUESTRA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_recepcion_muestra_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters.Add("@rec_fila", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@cantidad", SqlDbType.Int)
            command.Parameters.Add("@cantidad_muestra", SqlDbType.Int)
            command.Parameters.Add("@bul_unidad", SqlDbType.Int)
            command.Parameters.Add("@bul_total", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _rec_fila
            command.Parameters(2).Value = _pro_codigo
            command.Parameters(3).Value = _cantidad
            command.Parameters(4).Value = _cantidad_muestra
            command.Parameters(5).Value = _bul_unidad
            command.Parameters(6).Value = _bul_total

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_MUESTRA_EXISTE(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_recepcion_muestra_existe", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_MUESTRA_CON_NUMERO_TRASPASO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_recepcion_muestra_con_numero_traspaso", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_MUESTRA_LISTADO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_recepcion_muestra_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function APRUEBA_RECHAZA_RECEPCION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_aprueba_rechaza_recepcion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@ede_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _rec_codigo
            command.Parameters(1).Value = _ede_codigo

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

    Public Function RECEPCION_BORRA_TABLAS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_recepcion_borra_tablas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters(0).Value = _rec_numero

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

    Public Function OBTIENE_ESTADO_RECEPCION(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_obtiene_estado_recepcion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function RECEPCION_LISTAR_VISOR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_recepcion_listar_para_visor", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@usu_actual", _usu_codigo))
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

    Public Function RECEPCION_LISTAR_CANTIDADES_PENDIENTES(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_recepcacion_cantidad_por_ubicar", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@rec_codigo", _rec_numero))
            command.Parameters.Add(New SqlParameter("@pro_codigo", _pro_codigo))

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


End Class
