Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Class class_embarque
    Private _cnn As String
    Private _emb_sello As String
    Private _emb_fechadespacho As Date
    Private _emb_usuario As Integer
    Private _emb_tipo As Integer
    Private _usu_chofer As Integer
    Private _veh_codigo As Integer
    Private _emb_chofernombre As String
    Private _emb_transporte As String
    Private _emb_cantpallet As Integer
    Private _emb_cantpalletdoble As Integer

    Private _car_codigo As Integer
    Private _pic_codigo As Integer
    Private _pic_fila As Integer
    Private _num_piciking As String
    Private _emd_nfactura As Long
    Private _emb_nguia As Long
    Private _emb_codigointerno As String
    Private _emb_nombreproducto As String
    Private _emb_cantidad As Integer

    Private _fecha_despacho_desde As String
    Private _fecha_despacho_hasta As String
    Private _pdd_fila As Integer

    Private _veh_codigocomplemento As Integer
    Private _emb_cpmplemento As String
    Private _emb_cantpalletdoble_sodimac As Integer
    Private _emb_fguia As Date
    Private _emb_horacita As String
    Private _tipoDocumento As String
    Private _numDocumento As Long
    Private _numGuia As Long
    Private _dep_cod_retorno As Integer

    Public Property dep_cod_retorno() As Integer
        Get
            Return _dep_cod_retorno
        End Get
        Set(ByVal value As Integer)
            _dep_cod_retorno = value
        End Set
    End Property

    Public Property numGuia() As Long
        Get
            Return _numGuia
        End Get
        Set(ByVal value As Long)
            _numGuia = value
        End Set
    End Property

    Public Property numDocumento() As Long
        Get
            Return _numDocumento
        End Get
        Set(ByVal value As Long)
            _numDocumento = value
        End Set
    End Property
    Public Property tipoDocumento() As String
        Get
            Return _tipoDocumento
        End Get
        Set(ByVal value As String)
            _tipoDocumento = value
        End Set
    End Property

    Public Property emb_horacita() As String
        Get
            Return _emb_horacita
        End Get
        Set(ByVal value As String)
            _emb_horacita = value
        End Set
    End Property
    Public Property emb_fguia() As Date
        Get
            Return _emb_fguia
        End Get
        Set(ByVal value As Date)
            _emb_fguia = value
        End Set
    End Property
    Public Property veh_codigocomplemento() As Integer
        Get
            Return _veh_codigocomplemento
        End Get
        Set(ByVal value As Integer)
            _veh_codigocomplemento = value
        End Set
    End Property
    Public Property emb_cpmplemento() As String
        Get
            Return _emb_cpmplemento
        End Get
        Set(ByVal value As String)
            _emb_cpmplemento = value
        End Set
    End Property
    Public Property emb_cantpalletdoble_sodimac() As Integer
        Get
            Return _emb_cantpalletdoble_sodimac
        End Get
        Set(ByVal value As Integer)
            _emb_cantpalletdoble_sodimac = value
        End Set
    End Property


    Public Property pdd_fila() As String
        Get
            Return _pdd_fila
        End Get
        Set(ByVal value As String)
            _pdd_fila = value
        End Set
    End Property

    Public Property fecha_despacho_desde() As String
        Get
            Return _fecha_despacho_desde
        End Get
        Set(ByVal value As String)
            _fecha_despacho_desde = value
        End Set
    End Property
    Public Property fecha_despacho_hasta() As String
        Get
            Return _fecha_despacho_hasta
        End Get
        Set(ByVal value As String)
            _fecha_despacho_hasta = value
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
    Public Property emb_sello() As String
        Get
            Return _emb_sello
        End Get
        Set(ByVal value As String)
            _emb_sello = value
        End Set
    End Property
    Public Property emb_fechadespacho() As Date
        Get
            Return _emb_fechadespacho
        End Get
        Set(ByVal value As Date)
            _emb_fechadespacho = value
        End Set
    End Property
    Public Property emb_usuario() As Integer
        Get
            Return _emb_usuario
        End Get
        Set(ByVal value As Integer)
            _emb_usuario = value
        End Set
    End Property
    Public Property emb_tipo() As Integer
        Get
            Return _emb_tipo
        End Get
        Set(ByVal value As Integer)
            _emb_tipo = value
        End Set
    End Property
    Public Property usu_chofer() As Integer
        Get
            Return _usu_chofer
        End Get
        Set(ByVal value As Integer)
            _usu_chofer = value
        End Set
    End Property
    Public Property veh_codigo() As Integer
        Get
            Return _veh_codigo
        End Get
        Set(ByVal value As Integer)
            _veh_codigo = value
        End Set
    End Property
    Public Property emb_chofernombre() As String
        Get
            Return _emb_chofernombre
        End Get
        Set(ByVal value As String)
            _emb_chofernombre = value
        End Set
    End Property
    Public Property emb_transporte() As String
        Get
            Return _emb_transporte
        End Get
        Set(ByVal value As String)
            _emb_transporte = value
        End Set
    End Property
    Public Property emb_cantpallet() As Integer
        Get
            Return _emb_cantpallet
        End Get
        Set(ByVal value As Integer)
            _emb_cantpallet = value
        End Set
    End Property
    Public Property emb_cantpalletdoble() As Integer
        Get
            Return _emb_cantpalletdoble
        End Get
        Set(ByVal value As Integer)
            _emb_cantpalletdoble = value
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
    Public Property pic_codigo() As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
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
    Public Property num_piciking() As String
        Get
            Return _num_piciking
        End Get
        Set(ByVal value As String)
            _num_piciking = value
        End Set
    End Property
    Public Property emd_nfactura() As Long
        Get
            Return _emd_nfactura
        End Get
        Set(ByVal value As Long)
            _emd_nfactura = value
        End Set
    End Property
    Public Property emb_nguia() As Long
        Get
            Return _emb_nguia
        End Get
        Set(ByVal value As Long)
            _emb_nguia = value
        End Set
    End Property
    Public Property emb_codigointerno() As String
        Get
            Return _emb_codigointerno
        End Get
        Set(ByVal value As String)
            _emb_codigointerno = value
        End Set
    End Property
    Public Property emb_nombreproducto() As String
        Get
            Return _emb_nombreproducto
        End Get
        Set(ByVal value As String)
            _emb_nombreproducto = value
        End Set
    End Property
    Public Property emb_cantidad() As Integer
        Get
            Return _emb_cantidad
        End Get
        Set(ByVal value As Integer)
            _emb_cantidad = value
        End Set
    End Property


    Public Function DESPACHO_EMBARQUE_GUARDA_DATOS_ENCABEZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_despacho_embarque_enc_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters.Add("@emb_fechadespacho", SqlDbType.Date)
            command.Parameters.Add("@emb_usuario", SqlDbType.Int)
            command.Parameters.Add("@emb_tipo", SqlDbType.Int)
            command.Parameters.Add("@usu_chofer", SqlDbType.Int)
            command.Parameters.Add("@veh_codigo", SqlDbType.Int)
            command.Parameters.Add("@emb_chofernombre", SqlDbType.NVarChar)
            command.Parameters.Add("@emb_transporte", SqlDbType.NVarChar)
            command.Parameters.Add("@emb_cantpallet", SqlDbType.Int)
            command.Parameters.Add("@emb_cantpalletdoble", SqlDbType.Int)
            command.Parameters.Add("@veh_codigocomplemento", SqlDbType.Int)
            command.Parameters.Add("@emb_cpmplemento", SqlDbType.NVarChar)
            command.Parameters.Add("@emb_cantpalletdoble_sodimac", SqlDbType.Int)
            command.Parameters.Add("@emb_horacita", SqlDbType.NVarChar)

            command.Parameters(0).Value = _emb_sello
            command.Parameters(1).Value = _emb_fechadespacho
            command.Parameters(2).Value = _emb_usuario
            command.Parameters(3).Value = _emb_tipo
            command.Parameters(4).Value = _usu_chofer
            command.Parameters(5).Value = _veh_codigo
            command.Parameters(6).Value = _emb_chofernombre
            command.Parameters(7).Value = _emb_transporte
            command.Parameters(8).Value = _emb_cantpallet
            command.Parameters(9).Value = _emb_cantpalletdoble
            command.Parameters(10).Value = _veh_codigocomplemento
            command.Parameters(11).Value = _emb_cpmplemento
            command.Parameters(12).Value = _emb_cantpalletdoble_sodimac
            command.Parameters(13).Value = _emb_horacita

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

    Public Function DESPACHO_EMBARQUE_GUARDA_DATOS_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_despacho_embarque_det_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@num_piciking", SqlDbType.NVarChar)
            command.Parameters.Add("@emd_nfactura", SqlDbType.Float)
            command.Parameters.Add("@emb_nguia", SqlDbType.Float)
            command.Parameters.Add("@emb_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@emb_nombreproducto", SqlDbType.NVarChar)
            command.Parameters.Add("@emb_cantidad", SqlDbType.Int)
            command.Parameters.Add("@pdd_fila", SqlDbType.Int)
            command.Parameters.Add("@emb_fguia", SqlDbType.Date)

            command.Parameters(0).Value = _emb_sello
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _pic_codigo
            command.Parameters(3).Value = _pic_fila
            command.Parameters(4).Value = _num_piciking
            command.Parameters(5).Value = _emd_nfactura
            command.Parameters(6).Value = _emb_nguia
            command.Parameters(7).Value = _emb_codigointerno
            command.Parameters(8).Value = _emb_nombreproducto
            command.Parameters(9).Value = _emb_cantidad
            command.Parameters(10).Value = _pdd_fila
            command.Parameters(11).Value = _emb_fguia

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

    Public Function DESPACHO_EMBARQUE_DETALLE_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_despacho_embarque_det_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters(0).Value = _emb_sello

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

    Public Function DESPACHO_EMBARQUE_ENC_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_embarque_enc_listar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters.Add("@emb_tipo", SqlDbType.Int)
            command.Parameters.Add("@fecha_despacho_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_despacho_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@tipoDocumento", SqlDbType.NVarChar)
            command.Parameters.Add("@numDocumento", SqlDbType.Float)

            command.Parameters(0).Value = _emb_sello
            command.Parameters(1).Value = _emb_tipo
            command.Parameters(2).Value = _fecha_despacho_desde
            command.Parameters(3).Value = _fecha_despacho_hasta
            command.Parameters(4).Value = _tipoDocumento
            command.Parameters(5).Value = _numDocumento

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DESPACHO_EMBARQUE_DET_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_embarque_det_listar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)

            command.Parameters(0).Value = _emb_sello

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DESPACHO_EMBARQUE_DETALLE_ELIMINA_FILA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_despacho_embarque_det_fila_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pic_codigo", SqlDbType.Int)
            command.Parameters.Add("@pic_fila", SqlDbType.Int)
            command.Parameters.Add("@cantidad", SqlDbType.Int)

            command.Parameters(0).Value = _pic_codigo
            command.Parameters(1).Value = _pic_fila
            command.Parameters(2).Value = _emb_cantidad

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

    Public Function DESPACHO_EMBARQUE_CANT_DETALLE_OBTIENE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_embarque_cantidad_registro", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)

            command.Parameters(0).Value = _emb_sello

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DESPACHO_EMBARQUE_ENCABEZADO_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_despacho_embarque_enc_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters(0).Value = _emb_sello

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

    Public Function DESPACHO_EMBARQUE_ELIMINA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_elimina_embarque", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters(0).Value = _emb_sello

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

    Public Function DESPACHO_EMBARQUE_PALLET_SELECCIONAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_pallets_listado_seleciona", conexion)
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

    Public Function CANT_DESPACHO_EMBARQUE_PALLET_SELECCIONAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_despacho_detalle_pallet_retorna_cant", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters.Add("@pal_codigo_interno", SqlDbType.NVarChar)

            command.Parameters(0).Value = _emb_sello
            command.Parameters(1).Value = _emb_codigointerno
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function GUARDA_DESPACHO_PALLET_EMBARQUES(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_despacho_detalle_pallet_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters.Add("@dep_cantidad", SqlDbType.Int)
            command.Parameters.Add("@pal_codigo_interno", SqlDbType.NVarChar)
            command.Parameters.Add("@dep_num_guia", SqlDbType.NVarChar)

            command.Parameters(0).Value = _emb_sello
            command.Parameters(1).Value = _emb_cantidad
            command.Parameters(2).Value = _emb_codigointerno
            command.Parameters(3).Value = _emb_nguia

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function listado_guias_pallets(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_guias_despacho_pallets_enc_listar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_despacho_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_despacho_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@dep_num_guia", SqlDbType.Float)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _emb_sello
            command.Parameters(1).Value = _fecha_despacho_desde
            command.Parameters(2).Value = _fecha_despacho_hasta
            command.Parameters(3).Value = _numGuia
            command.Parameters(4).Value = _car_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function listado_detalle_guias_pallets(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_guias_despacho_pallets_detalle_listar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters.Add("@dep_num_guia", SqlDbType.Float)
            command.Parameters(0).Value = _emb_sello
            command.Parameters(1).Value = _numGuia
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function palet_retorno_actualiza_registro(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_despacho_detalle_guia_retorno_actualizar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@dep_cantidad", SqlDbType.Int)
            command.Parameters.Add("@dep_cod_retorno", SqlDbType.Int)
            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters.Add("@dep_num_guia", SqlDbType.Float)
            command.Parameters.Add("@pal_codigo", SqlDbType.NVarChar)
            command.Parameters(0).Value = emb_cantidad
            command.Parameters(1).Value = dep_cod_retorno
            command.Parameters(2).Value = emb_sello
            command.Parameters(3).Value = numGuia
            command.Parameters(4).Value = emb_codigointerno

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function VERIFICA_DEVOLUCIONES(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_verifica_devolucion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)

            command.Parameters(0).Value = _emb_sello

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function LISTADO_GUIAS_PALLETS_RENDICION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            'sp_guias_despacho_pallets_enc_rendicion
            Dim command As New SqlCommand("sp_guias_despacho_pallets_por_rendir", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@emb_sello", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_despacho_desde", SqlDbType.NVarChar)
            command.Parameters.Add("@fecha_despacho_hasta", SqlDbType.NVarChar)
            command.Parameters.Add("@dep_num_guia", SqlDbType.NVarChar)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _emb_sello
            command.Parameters(1).Value = _fecha_despacho_desde
            command.Parameters(2).Value = _fecha_despacho_hasta
            command.Parameters(3).Value = _emb_nguia
            command.Parameters(4).Value = _car_codigo

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
