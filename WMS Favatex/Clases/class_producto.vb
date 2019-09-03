Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class class_producto
    Private _cnn As String
    Private _pro_codigo As Integer
    Private _pro_nombre As String
    Private _codigo_interno As String
    Private _todos As Boolean

    Private _pro_numerobulto As Integer
    Private _pro_observacion As String
    Private _fam_codigo	As Integer
    Private _uni_codigo As Integer
    Private _col_codigo As Integer
    Private _pro_metroscubicos As Double
    Private _pro_stockminimo As Integer
    Private _pro_stockmaximo As Integer
    Private _cat_codigo As Integer
    Private _sub_codigo As Integer
    Private _pro_activo As Boolean
    Private _cod_barra As String

    Private _bul_codigo As Integer
    Private _bul_ancho As Double
    Private _bul_alto As Double
    Private _bul_fondo As Double
    Private _bul_piezas As Integer
    Private _bul_peso As Double
    Private _bul_metro3 As Double

    Private _pmu_codigo As Integer
    Private _tmu_codigo As Integer
    Private _pmu_nombre As String
    Private _pmu_ruta As String
    Private _pmu_fotoficha As Boolean
    Private _cal_codigo As Integer
    Private _pmu_activo As Boolean

    Private _tdp_codigo As Integer
    Private _tdo_codigo As Integer
    Private _tdp_nombre As String
    Private _tdp_ruta As String

    Private _car_codigo As Integer

    Private _codigoGenerico As String
    Private _buscar As String
    Private _bod_codigo As Integer
    Private _pro_cambio As Integer
    Private _bul_cantidadbase As Integer
    Private _bul_cantidadalto As Integer

    Private _bul_tipobulto As String
    Private _bul_posicion As Integer
    Private _pro_config As Integer
    Private _bul_horizontal As Boolean

    Private _numDocumento As Integer
    Private _tipDocumento As String
    Private _sku_codigo As String
    Private _pro_escombo As Boolean

    Private _pro_codigorel As Integer
    Private _pro_cantidad As Integer
    Private _pro_requiereubicacionpk As Boolean

    Public Property pro_requiereubicacionpk() As Boolean
        Get
            Return _pro_requiereubicacionpk
        End Get
        Set(ByVal value As Boolean)
            _pro_requiereubicacionpk = value
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
    Public Property pro_cantidad() As Integer
        Get
            Return _pro_cantidad
        End Get
        Set(ByVal value As Integer)
            _pro_cantidad = value
        End Set
    End Property
    Public Property pro_escombo() As Boolean
        Get
            Return _pro_escombo
        End Get
        Set(ByVal value As Boolean)
            _pro_escombo = value
        End Set
    End Property
    Public Property sku_codigo() As String
        Get
            Return _sku_codigo
        End Get
        Set(ByVal value As String)
            _sku_codigo = value
        End Set
    End Property
    Public Property tipDocumento() As String
        Get
            Return _tipDocumento
        End Get
        Set(ByVal value As String)
            _tipDocumento = value
        End Set
    End Property
    Public Property numDocumento() As Integer
        Get
            Return _numDocumento
        End Get
        Set(ByVal value As Integer)
            _numDocumento = value
        End Set
    End Property

    Public Property bul_horizontal() As Boolean
        Get
            Return _bul_horizontal
        End Get
        Set(ByVal value As Boolean)
            _bul_horizontal = value
        End Set
    End Property

    Public Property pro_config() As Integer
        Get
            Return _pro_config
        End Get
        Set(ByVal value As Integer)
            _pro_config = value
        End Set
    End Property

    Public Property bul_tipobulto() As String
        Get
            Return _bul_tipobulto
        End Get
        Set(ByVal value As String)
            _bul_tipobulto = value
        End Set
    End Property
    Public Property bul_posicion() As Integer
        Get
            Return _bul_posicion
        End Get
        Set(ByVal value As Integer)
            _bul_posicion = value
        End Set
    End Property

    Public Property bul_cantidadbase() As Integer
        Get
            Return _bul_cantidadbase
        End Get
        Set(ByVal value As Integer)
            _bul_cantidadbase = value
        End Set
    End Property

    Public Property bul_cantidadalto() As Integer
        Get
            Return _bul_cantidadalto
        End Get
        Set(ByVal value As Integer)
            _bul_cantidadalto = value
        End Set
    End Property

    Public Property pro_cambio() As Integer
        Get
            Return _pro_cambio
        End Get
        Set(ByVal value As Integer)
            _pro_cambio = value
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

    Public Property codigoGenerico() As String
        Get
            Return _codigoGenerico
        End Get
        Set(ByVal value As String)
            _codigoGenerico = value
        End Set
    End Property
    Public Property buscar() As String
        Get
            Return _buscar
        End Get
        Set(ByVal value As String)
            _buscar = value
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

    Public Property tdp_codigo() As Integer
        Get
            Return _tdp_codigo
        End Get
        Set(ByVal value As Integer)
            _tdp_codigo = value
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
    Public Property tdp_nombre() As String
        Get
            Return _tdp_nombre
        End Get
        Set(ByVal value As String)
            _tdp_nombre = value
        End Set
    End Property
    Public Property tdp_ruta() As String
        Get
            Return _tdp_ruta
        End Get
        Set(ByVal value As String)
            _tdp_ruta = value
        End Set
    End Property

    Public Property pmu_codigo() As Integer
        Get
            Return _pmu_codigo
        End Get
        Set(ByVal value As Integer)
            _pmu_codigo = value
        End Set
    End Property
    Public Property tmu_codigo() As Integer
        Get
            Return _tmu_codigo
        End Get
        Set(ByVal value As Integer)
            _tmu_codigo = value
        End Set
    End Property
    Public Property pmu_nombre() As String
        Get
            Return _pmu_nombre
        End Get
        Set(ByVal value As String)
            _pmu_nombre = value
        End Set
    End Property
    Public Property pmu_ruta() As String
        Get
            Return _pmu_ruta
        End Get
        Set(ByVal value As String)
            _pmu_ruta = value
        End Set
    End Property
    Public Property pmu_fotoficha() As Boolean
        Get
            Return _pmu_fotoficha
        End Get
        Set(ByVal value As Boolean)
            _pmu_fotoficha = value
        End Set
    End Property
    Public Property cal_codigo() As Integer
        Get
            Return _cal_codigo
        End Get
        Set(ByVal value As Integer)
            _cal_codigo = value
        End Set
    End Property
    Public Property pmu_activo() As Boolean
        Get
            Return _pmu_activo
        End Get
        Set(ByVal value As Boolean)
            _pmu_activo = value
        End Set
    End Property


    Public Property bul_codigo() As Integer
        Get
            Return _bul_codigo
        End Get
        Set(ByVal value As Integer)
            _bul_codigo = value
        End Set
    End Property
    Public Property bul_ancho() As Double
        Get
            Return _bul_ancho
        End Get
        Set(ByVal value As Double)
            _bul_ancho = value
        End Set
    End Property
    Public Property bul_alto() As Double
        Get
            Return _bul_alto
        End Get
        Set(ByVal value As Double)
            _bul_alto = value
        End Set
    End Property
    Public Property bul_fondo() As Double
        Get
            Return _bul_fondo
        End Get
        Set(ByVal value As Double)
            _bul_fondo = value
        End Set
    End Property
    Public Property bul_piezas() As Integer
        Get
            Return _bul_piezas
        End Get
        Set(ByVal value As Integer)
            _bul_piezas = value
        End Set
    End Property
    Public Property bul_peso() As Double
        Get
            Return _bul_peso
        End Get
        Set(ByVal value As Double)
            _bul_peso = value
        End Set
    End Property
    Public Property bul_metro3() As Double
        Get
            Return _bul_metro3
        End Get
        Set(ByVal value As Double)
            _bul_metro3 = value
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
    Public Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
        End Set
    End Property
    Public Property codigo_interno() As String
        Get
            Return _codigo_interno
        End Get
        Set(ByVal value As String)
            _codigo_interno = value
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
    Public Property todos() As Boolean
        Get
            Return _todos
        End Get
        Set(ByVal value As Boolean)
            _todos = value
        End Set
    End Property
    Public Property pro_numerobulto() As Integer
        Get
            Return _pro_numerobulto
        End Get
        Set(ByVal value As Integer)
            _pro_numerobulto = value
        End Set
    End Property
    Public Property pro_observacion() As String
        Get
            Return _pro_observacion
        End Get
        Set(ByVal value As String)
            _pro_observacion = value
        End Set
    End Property
    Public Property fam_codigo() As Integer
        Get
            Return _fam_codigo
        End Get
        Set(ByVal value As Integer)
            _fam_codigo = value
        End Set
    End Property
    Public Property uni_codigo() As Integer
        Get
            Return _uni_codigo
        End Get
        Set(ByVal value As Integer)
            _uni_codigo = value
        End Set
    End Property
    Public Property col_codigo() As Integer
        Get
            Return _col_codigo
        End Get
        Set(ByVal value As Integer)
            _col_codigo = value
        End Set
    End Property
    Public Property pro_metroscubicos() As Double
        Get
            Return _pro_metroscubicos
        End Get
        Set(ByVal value As Double)
            _pro_metroscubicos = value
        End Set
    End Property
    Public Property pro_stockminimo() As Integer
        Get
            Return _pro_stockminimo
        End Get
        Set(ByVal value As Integer)
            _pro_stockminimo = value
        End Set
    End Property
    Public Property pro_stockmaximo() As Integer
        Get
            Return _pro_stockmaximo
        End Get
        Set(ByVal value As Integer)
            _pro_stockmaximo = value
        End Set
    End Property
    Public Property cat_codigo() As Integer
        Get
            Return _cat_codigo
        End Get
        Set(ByVal value As Integer)
            _cat_codigo = value
        End Set
    End Property
    Public Property sub_codigo() As Integer
        Get
            Return _sub_codigo
        End Get
        Set(ByVal value As Integer)
            _sub_codigo = value
        End Set
    End Property
    Public Property pro_activo() As Boolean
        Get
            Return _pro_activo
        End Get
        Set(ByVal value As Boolean)
            _pro_activo = value
        End Set
    End Property
    Public Property cod_barra() As String
        Get
            Return _cod_barra
        End Get
        Set(ByVal value As String)
            _cod_barra = value
        End Set
    End Property

    Public Function PRODUCTOS_RELACIONADOS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_relacionados_buscar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _codigo_interno
            command.Parameters(2).Value = _pro_nombre

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

    Public Function PRODUCTOS_RELACIONADOS_LISTADO_NEW(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_relacionados_buscar_new", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _codigo_interno
            command.Parameters(2).Value = _pro_nombre

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

    Public Function PRODUCTOS_BUSQUEDA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_buscar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo

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
    Public Function CARGA_COMBO_PRODUCTOS_RELACIONADOS(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_relacionados_carga_combo", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo
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
    Public Function BUSCA_PRODUCTO_CODIGO_INTERNO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_producto_buscar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cod_interno", SqlDbType.NVarChar)
            command.Parameters(0).Value = _codigo_interno

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
    Public Function PRODUCTOS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters.Add("@sub_codigo", SqlDbType.Int)
            command.Parameters.Add("@sin_conf", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _todos
            command.Parameters(2).Value = _codigo_interno
            command.Parameters(3).Value = _cat_codigo
            command.Parameters(4).Value = _sub_codigo
            command.Parameters(5).Value = _pro_config

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
    Public Function PRODUCTO_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_producto_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_numerobulto", SqlDbType.Int)
            command.Parameters.Add("@pro_observacion", SqlDbType.NVarChar)
            command.Parameters.Add("@fam_codigo", SqlDbType.Int)
            command.Parameters.Add("@uni_codigo", SqlDbType.Int)
            command.Parameters.Add("@col_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_metroscubicos", SqlDbType.Decimal)
            command.Parameters.Add("@pro_stockminimo", SqlDbType.Int)
            command.Parameters.Add("@pro_stockmaximo", SqlDbType.Int)
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters.Add("@sub_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_activo", SqlDbType.Int)
            command.Parameters.Add("@cod_barra", SqlDbType.NVarChar)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_escombo", SqlDbType.Int)
            command.Parameters.Add("@pro_requiereubicacionpk", SqlDbType.Bit)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _codigo_interno
            command.Parameters(2).Value = _pro_nombre
            command.Parameters(3).Value = _pro_numerobulto
            command.Parameters(4).Value = _pro_observacion
            command.Parameters(5).Value = _fam_codigo
            command.Parameters(6).Value = _uni_codigo
            command.Parameters(7).Value = _col_codigo
            command.Parameters(8).Value = _pro_metroscubicos
            command.Parameters(9).Value = _pro_stockminimo
            command.Parameters(10).Value = _pro_stockmaximo
            command.Parameters(11).Value = _cat_codigo
            command.Parameters(12).Value = _sub_codigo
            command.Parameters(13).Value = _pro_activo
            command.Parameters(14).Value = _cod_barra
            command.Parameters(15).Value = _car_codigo
            command.Parameters(16).Value = _pro_escombo
            command.Parameters(17).Value = _pro_requiereubicacionpk

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

    Public Function ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_producto_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo

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

    Public Function BULTOS_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_bulprod_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_alto", SqlDbType.Decimal)
            command.Parameters.Add("@bul_ancho", SqlDbType.Decimal)
            command.Parameters.Add("@bul_fondo", SqlDbType.Decimal)
            command.Parameters.Add("@bul_peso", SqlDbType.Decimal)
            command.Parameters.Add("@bul_metro3", SqlDbType.Decimal)
            command.Parameters.Add("@bul_piezas", SqlDbType.Int)
            command.Parameters.Add("@bul_cantidadbase", SqlDbType.Int)
            command.Parameters.Add("@bul_cantidadalto", SqlDbType.Int)
            command.Parameters.Add("@bul_tipobulto", SqlDbType.NVarChar)
            command.Parameters.Add("@bul_posicion", SqlDbType.Int)
            command.Parameters.Add("@bul_horizontal", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _bul_codigo
            command.Parameters(2).Value = _bul_alto
            command.Parameters(3).Value = _bul_ancho
            command.Parameters(4).Value = _bul_fondo
            command.Parameters(5).Value = _bul_peso
            command.Parameters(6).Value = _bul_metro3
            command.Parameters(7).Value = _bul_piezas
            command.Parameters(8).Value = _bul_cantidadbase
            command.Parameters(9).Value = _bul_cantidadalto
            command.Parameters(10).Value = _bul_tipobulto
            command.Parameters(11).Value = _bul_posicion
            command.Parameters(12).Value = _bul_horizontal


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

    Public Function BULTOS_ELIMINA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_bulprod_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _bul_codigo

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

    Public Function BULTOS_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bulprod_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _bul_codigo

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

    Public Function TIPO_MULTIMEDIA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_multprod_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pmu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _pmu_codigo
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

    Public Function NOMBRE_IMG_BUSCAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_busca_nombre_img", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pmu_nombre", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _pmu_nombre
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

    Public Function MULTIMEDIA_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_multprod_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pmu_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@tmu_codigo", SqlDbType.Int)
            command.Parameters.Add("@cal_codigo", SqlDbType.Int)
            command.Parameters.Add("@pmu_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@pmu_ruta", SqlDbType.NVarChar)
            command.Parameters.Add("@pmu_fotoficha", SqlDbType.Bit)

            command.Parameters(0).Value = _pmu_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _tmu_codigo
            command.Parameters(3).Value = _cal_codigo
            command.Parameters(4).Value = _pmu_nombre
            command.Parameters(5).Value = _pmu_ruta
            command.Parameters(6).Value = _pmu_fotoficha

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

    Public Function MULTIMEDIA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_multprod_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pmu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _pmu_codigo
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

    Public Function ELIMINA_MULTIMEDIA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_mulprod_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pmu_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _pmu_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DOCUMENTOS_PRODUCTOS_LISTADOS(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_docprod_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@tdp_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _tdp_codigo

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

    Public Function DOCUMENTOS_PRODUCTOS_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_docprod_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tdp_codigo", SqlDbType.Int)
            command.Parameters.Add("@tdo_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@tdp_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@tdp_ruta", SqlDbType.NVarChar)

            command.Parameters(0).Value = _tdp_codigo
            command.Parameters(1).Value = _tdo_codigo
            command.Parameters(2).Value = _pro_codigo
            command.Parameters(3).Value = _tdp_nombre
            command.Parameters(4).Value = _tdp_ruta
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

    Public Function ELIMINA_DOCTO_PRODUCTO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_docprod_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tdp_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _tdp_codigo
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

    Public Function NOMBRE_DOCUMENTO_BUSCAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_busca_nombre_docto_producto", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@tdp_nombre", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _tdp_nombre
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

    Public Function EXCLUSIBIDAD_CLIENTE_LISTADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_exclCliente_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo

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

    Public Function EXCLUSIBIDAD_CLIENTE_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_activa_exclCliente", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _car_codigo

            'conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            'conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function EXCLUSIBIDAD_CLIENTE_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("p_exclCliente_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo

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

    Public Function PRODUCTOS_SIN_RELACION_CLIENTE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_buscar_producto_sin_relacion_cliente", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters.Add("@sub_codigo", SqlDbType.Int)
            command.Parameters.Add("@descr", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _cat_codigo
            command.Parameters(2).Value = _sub_codigo
            command.Parameters(3).Value = _pro_nombre

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

    Public Function PRODUCTOS_RELACIONADO_POR_CODIGO_OSKU_BUSCAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_buscar_producto_relacionado_por_codigo_osku", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@codigo", SqlDbType.NVarChar)
            command.Parameters.Add("@buscar", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _codigoGenerico
            command.Parameters(2).Value = _buscar

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

    Public Function PRODUCTOS_SIN_BODEGA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodegasProduc_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _bod_codigo
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

    Public Function PRODUCTOS_CON_BODEGA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_selbodegasProduc_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _bod_codigo
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

    Public Function PRODUCTOS_ASOCIADOS_BODEGAS(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_bodprod_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_PRODUCTO_POR_CATEGORIA_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productoCateg_combo", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _cat_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function LISTADO_CAMBIO_PRODUCTO_SIN_SELECCIONAR(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cambioProducSinSelec_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _cat_codigo

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

    Public Function LISTADO_CAMBIO_PRODUCTO_SELECCIONADOS(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cambioProducSelec_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo
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

    Public Function PRO_SELEC_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_prodCambio_seleccionar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_cambio", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_cambio
            command.Parameters(1).Value = _pro_codigo
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

    Public Function PRO_DESSELEC_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_prodCambio_deseleccionar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_cambio", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_cambio
            command.Parameters(1).Value = _pro_codigo
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

    Public Function OBTIENE_VOLUMETRIA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_obtiene_volumetria", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@numDocumento", _numDocumento))
            command.Parameters.Add(New SqlParameter("@tipDocumento", _tipDocumento))

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

    Public Function VALIDA_EXISTENCIA_BULTOS(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_valida_existencia_bultos", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@numDocumento", _numDocumento))
            command.Parameters.Add(New SqlParameter("@tipDocumento", _tipDocumento))

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


    Public Function PROVEEDOR_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_proveedor_carga_combo", conexion)
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

    Public Function retorna_cod_interno(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_retorna_producto_cod_int", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@cod_interno", SqlDbType.NVarChar)
            command.Parameters(0).Value = _codigo_interno

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function retorna_nom_interno(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_retorna_producto_nom_int", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@cod_interno", SqlDbType.NVarChar)
            command.Parameters(0).Value = _codigo_interno

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function retorna_nom_homologado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_retorna_producto_nom_homologado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@cod_cordigo", SqlDbType.Int)
            command.Parameters.Add("@sku_codigo", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _sku_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function retorna_cod_homologado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_retorna_producto_cod_homologado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@cod_cordigo", SqlDbType.Int)
            command.Parameters.Add("@sku_codigo", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _sku_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function retorna_codinterno_homologado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_retorna_producto_codinterno_homologado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@cod_cordigo", SqlDbType.Int)
            command.Parameters.Add("@sku_codigo", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _sku_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PRODUCTOS_LISTADO_DETALLE(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_listado_detalle", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters.Add("@sub_codigo", SqlDbType.Int)
            command.Parameters.Add("@sin_conf", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _todos
            command.Parameters(2).Value = _codigo_interno
            command.Parameters(3).Value = _cat_codigo
            command.Parameters(4).Value = _sub_codigo
            command.Parameters(5).Value = _pro_config
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

    Public Function PRODUCTOS_LISTADO_POR_RELACIONAR_EN_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_producto_selecciona_disponible_para_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _codigo_interno

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

    Public Function PRODUCTOS_LISTADO_RELACIONADO_EN_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_producto_selecciona_asociado_en_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo

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

    Public Function PRODUCTOS_RELACIONA_A_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_relacionados_para_combo_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigorel", SqlDbType.Int)
            command.Parameters.Add("@pro_cantidad", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _pro_codigorel
            command.Parameters(2).Value = _pro_cantidad

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

    Public Function PRODUCTOS_ELIMINA_RELACION_DE_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_para_combo_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigorel", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _pro_codigorel

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
