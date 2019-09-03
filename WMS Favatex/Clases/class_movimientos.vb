Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_movimientos
    Private _cnn As String
    Private _opcion As Integer

    Private _mov_folio As Long
    Private _tmo_codigo As Integer
    Private _bod_codigo As Integer
    Private _mov_fechaingreso As Date
    Private _mov_fechamovimiento As Date
    Private _mov_mes As String
    Private _mov_anno As String
    Private _mov_usuario As Integer
    Private _car_codigo As Integer
    Private _tdo_codigo As Integer
    Private _mov_nomdoc As Long
    Private _mov_foliorelacionado As Long
    Private _mov_observacion As String

    Private _pro_codigo As Integer
    Private _dmo_cantidad As Integer
    Private _dmo_bultos As Integer
    Private _dmo_totalbultos As Integer

    Private _prs_serie As String
    Private _prd_palletserie As String
    Private _usu_codigo As Integer
    Private _observacion As String
    Private _prm_tipo As String
    Private _bod_destino As Integer

    Private _rec_codigo As Integer
    Private _ubi_codigo As Integer
    Private _cantidad As Integer
    Private _mov_tipomovmanager As String
    Private _mov_nummovmanager As Long

    Public Property mov_tipomovmanager() As String
        Get
            Return _mov_tipomovmanager
        End Get
        Set(ByVal value As String)
            _mov_tipomovmanager = value
        End Set
    End Property
    Public Property mov_nummovmanager() As Long
        Get
            Return _mov_nummovmanager
        End Get
        Set(ByVal value As Long)
            _mov_nummovmanager = value
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
    Public Property ubi_codigo() As Integer
        Get
            Return _ubi_codigo
        End Get
        Set(ByVal value As Integer)
            _ubi_codigo = value
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

    Public Property bod_destino() As String
        Get
            Return _bod_destino
        End Get
        Set(ByVal value As String)
            _bod_destino = value
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
    Public Property prd_palletserie() As String
        Get
            Return _prd_palletserie
        End Get
        Set(ByVal value As String)
            _prd_palletserie = value
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
    Public Property observacion() As String
        Get
            Return _observacion
        End Get
        Set(ByVal value As String)
            _observacion = value
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

    Public Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
        End Set
    End Property
    Public Property dmo_cantidad() As Integer
        Get
            Return _dmo_cantidad
        End Get
        Set(ByVal value As Integer)
            _dmo_cantidad = value
        End Set
    End Property
    Public Property dmo_bultos() As Integer
        Get
            Return _dmo_bultos
        End Get
        Set(ByVal value As Integer)
            _dmo_bultos = value
        End Set
    End Property
    Public Property dmo_totalbultos() As Integer
        Get
            Return _dmo_totalbultos
        End Get
        Set(ByVal value As Integer)
            _dmo_totalbultos = value
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
    Public Property tmo_codigo() As Integer
        Get
            Return _tmo_codigo
        End Get
        Set(ByVal value As Integer)
            _tmo_codigo = value
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
    Public Property mov_fechaingreso() As Date
        Get
            Return _mov_fechaingreso
        End Get
        Set(ByVal value As Date)
            _mov_fechaingreso = value
        End Set
    End Property
    Public Property mov_fechamovimiento() As Date
        Get
            Return _mov_fechamovimiento
        End Get
        Set(ByVal value As Date)
            _mov_fechamovimiento = value
        End Set
    End Property
    Public Property mov_mes() As String
        Get
            Return _mov_mes
        End Get
        Set(ByVal value As String)
            _mov_mes = value
        End Set
    End Property
    Public Property mov_anno() As String
        Get
            Return _mov_anno
        End Get
        Set(ByVal value As String)
            _mov_anno = value
        End Set
    End Property
    Public Property mov_usuario() As Integer
        Get
            Return _mov_usuario
        End Get
        Set(ByVal value As Integer)
            _mov_usuario = value
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
    Public Property tdo_codigo() As Integer
        Get
            Return _tdo_codigo
        End Get
        Set(ByVal value As Integer)
            _tdo_codigo = value
        End Set
    End Property
    Public Property mov_nomdoc() As Long
        Get
            Return _mov_nomdoc
        End Get
        Set(ByVal value As Long)
            _mov_nomdoc = value
        End Set
    End Property
    Public Property mov_foliorelacionado() As Long
        Get
            Return _mov_foliorelacionado
        End Get
        Set(ByVal value As Long)
            _mov_foliorelacionado = value
        End Set
    End Property
    Public Property mov_observacion() As String
        Get
            Return _mov_observacion
        End Get
        Set(ByVal value As String)
            _mov_observacion = value
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
    Public Property opcion() As Integer
        Get
            Return _opcion
        End Get
        Set(ByVal value As Integer)
            _opcion = value
        End Set
    End Property

    Public Function CARGA_COMBO_TIPO_MOVIMIENTO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_movimiento_carga_combo", conexion)

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
    Public Function CARGA_COMBO_BODEGA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodega_carga_combo", conexion)

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
    Public Function CARGA_COMBO_PROVEEDOR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_proveedores_carga_combo", conexion)
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
    Public Function CARGA_COMBO_TIPO_DOCUMENTO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_documento_carga_combo", conexion)

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
    Public Function CARGA_COMBO_TIPO_DOCUMENTO_MOV(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_documento_mov_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@opcion", SqlDbType.Int)
            command.Parameters(0).Value = _opcion

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
    Public Function MOVIMIENTOS_GUARDA_ENCABEZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_movimientos_encabezado_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@mov_folio", SqlDbType.Float)
            command.Parameters.Add("@tmo_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@mov_fechamovimiento", SqlDbType.Date)
            command.Parameters.Add("@mov_mes", SqlDbType.NVarChar)
            command.Parameters.Add("@mov_anno", SqlDbType.NVarChar)
            command.Parameters.Add("@mov_usuario", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@tdo_codigo", SqlDbType.Int)
            command.Parameters.Add("@mov_nomdoc", SqlDbType.Float)
            command.Parameters.Add("@mov_foliorelacionado", SqlDbType.Float)
            command.Parameters.Add("@mov_observacion", SqlDbType.NVarChar)
            command.Parameters.Add("@mov_tipomovmanager", SqlDbType.NVarChar)
            command.Parameters.Add("@mov_nummovmanager", SqlDbType.Float)

            command.Parameters(0).Value = _mov_folio
            command.Parameters(1).Value = _tmo_codigo
            command.Parameters(2).Value = _bod_codigo
            command.Parameters(3).Value = _mov_fechamovimiento
            command.Parameters(4).Value = _mov_mes
            command.Parameters(5).Value = _mov_anno
            command.Parameters(6).Value = _mov_usuario
            command.Parameters(7).Value = _car_codigo
            command.Parameters(8).Value = _tdo_codigo
            command.Parameters(9).Value = _mov_nomdoc
            command.Parameters(10).Value = _mov_foliorelacionado
            command.Parameters(11).Value = _mov_observacion
            command.Parameters(12).Value = _mov_tipomovmanager
            command.Parameters(13).Value = _mov_nummovmanager
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

    Public Function MOVIMIENTOS_GUARDA_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_movimiento_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@mov_folio", SqlDbType.Float)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@dmo_cantidad", SqlDbType.Int)
            command.Parameters.Add("@dmo_bultos", SqlDbType.Int)
            command.Parameters.Add("@dmo_totalbultos", SqlDbType.Int)

            command.Parameters(0).Value = _mov_folio
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _dmo_cantidad
            command.Parameters(3).Value = _dmo_bultos
            command.Parameters(4).Value = _dmo_totalbultos

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

    Public Function ELIMINA_DETALLE_MOVIMIENTO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet

        Try
            Dim command As New SqlCommand("sp_movimiento_detalle_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@mov_folio", SqlDbType.Int)

            command.Parameters(0).Value = _mov_folio

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

    Public Function PRODUCTO_SERIE_MOVIMIENTO_GUARDA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_recepcion_producto_serie_movimiento_por_pallet_guardar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@prs_serie", SqlDbType.NVarChar)
            command.Parameters.Add("@prd_palletserie", SqlDbType.NVarChar)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@mov_folio", SqlDbType.Float)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@observacion", SqlDbType.NVarChar)
            command.Parameters.Add("@prm_tipo", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_destino", SqlDbType.Int)

            command.Parameters(0).Value = _prs_serie
            command.Parameters(1).Value = _prd_palletserie
            command.Parameters(2).Value = _bod_codigo
            command.Parameters(3).Value = _mov_folio
            command.Parameters(4).Value = _usu_codigo
            command.Parameters(5).Value = _observacion
            command.Parameters(6).Value = _prm_tipo
            command.Parameters(7).Value = _pro_codigo
            command.Parameters(8).Value = _bod_destino

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

    Public Function GENERA_PALLET_SSTT(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_genera_pallet_sstt", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters.Add("@cantidad", SqlDbType.Int)

            command.Parameters(0).Value = _rec_codigo
            command.Parameters(1).Value = _ubi_codigo
            command.Parameters(2).Value = _cantidad

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

    Public Function ACTUALIZA_CANTIDADES_PARA_MUESTRA_SSTT(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_pallet_actualiza_cantidades_muestras_sstt", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@rec_codigo", SqlDbType.Int)
            command.Parameters.Add("@cantidad", SqlDbType.Int)
            command.Parameters.Add("@serie_pallet", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _rec_codigo
            command.Parameters(2).Value = _cantidad
            command.Parameters(3).Value = _prd_palletserie

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
