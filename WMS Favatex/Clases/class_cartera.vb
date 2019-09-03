Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class class_cartera
    Private _cnn As String
    Private _car_codigo As Integer
    Private _todos As Boolean

    Private _pro_codigo As Integer
    Private _sku_cartera As String
    Private _sku_carnomb As String
    Private _sku_tipo As Integer
    Private _pro_precioventa As Long
    Private _pro_preciovtapub As Long
    Private _sku_activo As Boolean

    Private _car_rut As String
    Private _car_nombre As String
    Private _car_region As Integer
    Private _car_ciudad As Integer
    Private _car_comuna As Integer
    Private _direccion As String
    Private _car_telefono As String
    Private _car_tipoas As Integer
    Private _car_activo As Boolean
    Private _car_carpetarepositorioB2B As String
    Private _car_limitadordecaracteres As String
    Private _car_extensionarchivo As String
    Private _dias_plazo_entrega As Integer

    Private _pro_codigointerno As String
    Private _pro_nombre As String
    Private _dde_descripcion As String
    Private _eti_codigo As Integer
    Private _tet_codigo As String
    Private _porDefecto As Boolean

    Private _car_muestra_inf As Boolean

    Private _car_numOC_auto As Boolean
    Private _car_funcionaVV As Boolean

    Public Property car_numOC_auto() As Boolean
        Get
            Return _car_numOC_auto
        End Get
        Set(ByVal value As Boolean)
            _car_numOC_auto = value
        End Set
    End Property
    Public Property car_funcionaVV() As Boolean
        Get
            Return _car_funcionaVV
        End Get
        Set(ByVal value As Boolean)
            _car_funcionaVV = value
        End Set
    End Property

    Public Property car_muestra_inf() As Boolean
        Get
            Return _car_activo
        End Get
        Set(ByVal value As Boolean)
            _car_muestra_inf = value
        End Set
    End Property
    Public Property porDefecto() As Boolean
        Get
            Return _porDefecto
        End Get
        Set(ByVal value As Boolean)
            _porDefecto = value
        End Set
    End Property
    Public Property tet_codigo() As String
        Get
            Return _tet_codigo
        End Get
        Set(ByVal value As String)
            _tet_codigo = value
        End Set
    End Property
    Public Property eti_codigo() As Integer
        Get
            Return _eti_codigo
        End Get
        Set(ByVal value As Integer)
            _eti_codigo = value
        End Set
    End Property

    Public Property dde_descripcion() As String
        Get
            Return _dde_descripcion
        End Get
        Set(ByVal value As String)
            _dde_descripcion = value
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

    Public Property dias_plazo_entrega() As Integer
        Get
            Return _dias_plazo_entrega
        End Get
        Set(ByVal value As Integer)
            _dias_plazo_entrega = value
        End Set
    End Property
    Public Property car_extensionarchivo() As String
        Get
            Return _car_extensionarchivo
        End Get
        Set(ByVal value As String)
            _car_extensionarchivo = value
        End Set
    End Property
    Public Property car_limitadordecaracteres() As String
        Get
            Return _car_limitadordecaracteres
        End Get
        Set(ByVal value As String)
            _car_limitadordecaracteres = value
        End Set
    End Property
    Public Property car_carpetarepositorioB2B() As String
        Get
            Return _car_carpetarepositorioB2B
        End Get
        Set(ByVal value As String)
            _car_carpetarepositorioB2B = value
        End Set
    End Property
    Public Property car_activo() As Boolean
        Get
            Return _car_activo
        End Get
        Set(ByVal value As Boolean)
            _car_activo = value
        End Set
    End Property
    Public Property car_tipoas() As Integer
        Get
            Return _car_tipoas
        End Get
        Set(ByVal value As Integer)
            _car_tipoas = value
        End Set
    End Property
    Public Property car_telefono() As String
        Get
            Return _car_telefono
        End Get
        Set(ByVal value As String)
            _car_telefono = value
        End Set
    End Property
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property
    Public Property car_comuna() As Integer
        Get
            Return _car_comuna
        End Get
        Set(ByVal value As Integer)
            _car_comuna = value
        End Set
    End Property
    Public Property car_ciudad() As Integer
        Get
            Return _car_ciudad
        End Get
        Set(ByVal value As Integer)
            _car_ciudad = value
        End Set
    End Property
    Public Property car_region() As Integer
        Get
            Return _car_region
        End Get
        Set(ByVal value As Integer)
            _car_region = value
        End Set
    End Property
    Public Property car_nombre() As String
        Get
            Return _car_nombre
        End Get
        Set(ByVal value As String)
            _car_nombre = value
        End Set
    End Property
    Public Property car_rut() As String
        Get
            Return _car_rut
        End Get
        Set(ByVal value As String)
            _car_rut = value
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
    Public Property car_codigo() As Integer
        Get
            Return _car_codigo
        End Get
        Set(ByVal value As Integer)
            _car_codigo = value
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
    Public Property sku_cartera() As String
        Get
            Return _sku_cartera
        End Get
        Set(ByVal value As String)
            _sku_cartera = value
        End Set
    End Property
    Public Property sku_carnomb() As String
        Get
            Return _sku_carnomb
        End Get
        Set(ByVal value As String)
            _sku_carnomb = value
        End Set
    End Property
    Public Property sku_tipo() As Integer
        Get
            Return _sku_tipo
        End Get
        Set(ByVal value As Integer)
            _sku_tipo = value
        End Set
    End Property
    Public Property pro_precioventa() As Long
        Get
            Return _pro_precioventa
        End Get
        Set(ByVal value As Long)
            _pro_precioventa = value
        End Set
    End Property
    Public Property pro_preciovtapub() As Long
        Get
            Return _pro_preciovtapub
        End Get
        Set(ByVal value As Long)
            _pro_preciovtapub = value
        End Set
    End Property
    Public Property sku_activo() As Boolean
        Get
            Return _sku_activo
        End Get
        Set(ByVal value As Boolean)
            _sku_activo = value
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

    Public Function CARTERA_SELECCIONA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cartera$selecciona", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
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

    Public Function CARGA_COMBO_CLIENTE(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_clientes_carga_combo", conexion)

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

    Public Function CARGA_COMBO_CLIENTE_VV(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_clientes_carga_combo_vv", conexion)

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

    Public Function CARGA_COMBO_CLIENTE_TODOS(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_clientes_carga_combo_todos", conexion)

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

    Public Function CARGA_COMBO_CLIENTE_DESPACHA_CON_GUIA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_clientes_despacha_con_guia_carga_combo", conexion)

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

    Public Function CARGA_COMBO_CLIENTE_DESPACHA_CON_FACTURA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_clientes_despacha_con_factura_carga_combo", conexion)

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

    Public Function CARTERA_PRODUCTO_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_proveProduc_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@sku_cartera", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_carnomb", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_tipo", SqlDbType.Int)
            command.Parameters.Add("@pro_precioventa", SqlDbType.Float)
            command.Parameters.Add("@pro_preciovtapub", SqlDbType.Float)
            command.Parameters.Add("@sku_activo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _sku_cartera
            command.Parameters(3).Value = _sku_carnomb
            command.Parameters(4).Value = _sku_tipo
            command.Parameters(5).Value = _pro_precioventa
            command.Parameters(6).Value = _pro_preciovtapub
            command.Parameters(7).Value = _sku_activo

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

    Public Function CARTERA_PRODUCTO_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_proveProduc_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@sku_cartera", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_carnomb", SqlDbType.NVarChar)
            command.Parameters.Add("@sku_tipo", SqlDbType.Int)
            command.Parameters.Add("@pro_precioventa", SqlDbType.Float)
            command.Parameters.Add("@pro_preciovtapub", SqlDbType.Float)
            command.Parameters.Add("@sku_activo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _sku_cartera
            command.Parameters(3).Value = _sku_carnomb
            command.Parameters(4).Value = _sku_tipo
            command.Parameters(5).Value = _pro_precioventa
            command.Parameters(6).Value = _pro_preciovtapub
            command.Parameters(7).Value = _sku_activo

            'command.ExecuteNonQuery()
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


    Public Function PRODUCTOS_RELACIONADOS_CARTERA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_proveProduc_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@pro_codigo", _pro_codigo))
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

    Public Function PRODUCTOS_RELACIONADOS_CARTERA_INTERNO_NOMBRE(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_proveProduc_listado_interno_nombre", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@pro_codigointerno", _pro_codigointerno))
            command.Parameters.Add(New SqlParameter("@pro_nombre", _pro_nombre))
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

    Public Function CARTERA_LISTADO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cartera_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@todos", _todos))
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

    Public Function CARTERA_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_cartera_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_rut", SqlDbType.NVarChar)
            command.Parameters.Add("@car_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@car_region", SqlDbType.Int)
            command.Parameters.Add("@car_ciudad", SqlDbType.Int)
            command.Parameters.Add("@car_comuna", SqlDbType.Int)
            command.Parameters.Add("@direccion", SqlDbType.NVarChar)
            command.Parameters.Add("@car_telefono", SqlDbType.NVarChar)
            command.Parameters.Add("@car_tipo", SqlDbType.Int)
            command.Parameters.Add("@car_activo", SqlDbType.Bit)
            command.Parameters.Add("@dias_plazo_entrega", SqlDbType.Int)
            command.Parameters.Add("@car_muestra_inf", SqlDbType.Bit)
            command.Parameters.Add("@car_numOC_auto", SqlDbType.Bit)
            command.Parameters.Add("@car_funcionaVV", SqlDbType.Bit)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _car_rut
            command.Parameters(2).Value = _car_nombre
            command.Parameters(3).Value = _car_region
            command.Parameters(4).Value = _car_ciudad
            command.Parameters(5).Value = _car_comuna
            command.Parameters(6).Value = _direccion
            command.Parameters(7).Value = _car_telefono
            command.Parameters(8).Value = _car_tipoas
            command.Parameters(9).Value = _car_activo
            command.Parameters(10).Value = _dias_plazo_entrega
            command.Parameters(11).Value = _car_muestra_inf
            command.Parameters(12).Value = _car_numOC_auto
            command.Parameters(13).Value = _car_funcionaVV

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

    Public Function CARTERA_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_cartera_elimina", conexion)
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

    Public Function CARTERA_DOCUMENTO_DESPACHO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_documento_despacho_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@dde_descripcion", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _dde_descripcion

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

    Public Function PRODUCTOS_RELACIONADOS_CARTERA_ELIMINA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_proveProduc_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@sku_cartera", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _sku_cartera

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

    Public Function CARTERA_ETIQUETA_LISTADO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_etiquetas_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@eti_codigo", _eti_codigo))

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

    Public Function CARTERA_ETIQUETA_COMBO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_etiquetas_carga_combo", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@tet_codigo", _tet_codigo))

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

    Public Function CLIENTE_PARA_INFORME_KPI(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cliente_para_informe_kpi", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@porDefecto", _porDefecto))

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

    Public Function REQUIERE_GRUPAR_POR_DESPACHO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_clientes_obtiene_datos", conexion)

            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _car_codigo

            command.CommandType = CommandType.StoredProcedure
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
