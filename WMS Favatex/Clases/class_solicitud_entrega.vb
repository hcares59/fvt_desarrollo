Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_solicitud_entrega
    Private _cnn As String
    Private _sol_codigo As Integer
    Private _sol_fecha As Date
    Private _car_codigo As Integer
    Private _usu_codigo As Integer
    Private _cant_unidades As Integer
    Private _cant_bultos As Integer
    Private _total_bultos As Integer
    Private _eso_codigo As Integer

    Private _pro_codigo As Integer
    Private _pro_nombre As String
    Private _sku_cartera As String
    Private _sku_cartera_nombre As String
    Private _pic_cantidad As Integer
    Private _pic_num_bultos As Integer
    Private _pic_total_bultos As Integer
    Private _precio As Long
    Private _pic_ocnumero As Long
    Private _pic_fechaoc As Date
    Private _pro_codigooriginal As Integer
    Private _con_codigounico As String
    Private _con_despacharanumero As String
    Private _con_despachara As String
    Private _con_local As String
    Private _con_localnombre As String
    Private _rut_cliente As String
    Private _nombre_cliente As String
    Private _con_observacion As String
    Private _pic_fechaocoriginal As Date
    Private _pic_semodificafecha As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Public Property sol_codigo() As Integer
        Get
            Return _sol_codigo
        End Get
        Set(ByVal value As Integer)
            _sol_codigo = value
        End Set
    End Property
    Public Property sol_fecha() As Date
        Get
            Return _sol_fecha
        End Get
        Set(ByVal value As Date)
            _sol_fecha = value
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
    Public Property usu_codigo() As Integer
        Get
            Return _usu_codigo
        End Get
        Set(ByVal value As Integer)
            _usu_codigo = value
        End Set
    End Property
    Public Property cant_unidades() As Integer
        Get
            Return _cant_unidades
        End Get
        Set(ByVal value As Integer)
            _cant_unidades = value
        End Set
    End Property
    Public Property cant_bultos() As Integer
        Get
            Return _cant_bultos
        End Get
        Set(ByVal value As Integer)
            _cant_bultos = value
        End Set
    End Property
    Public Property total_bultos() As Integer
        Get
            Return _total_bultos
        End Get
        Set(ByVal value As Integer)
            _total_bultos = value
        End Set
    End Property
    Public Property eso_codigo() As Integer
        Get
            Return _eso_codigo
        End Get
        Set(ByVal value As Integer)
            _eso_codigo = value
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
    Public Property pic_cantidad() As Integer
        Get
            Return _pic_cantidad
        End Get
        Set(ByVal value As Integer)
            _pic_cantidad = value
        End Set
    End Property
    Public Property pic_total_bultos() As Integer
        Get
            Return _pic_total_bultos
        End Get
        Set(ByVal value As Integer)
            _pic_total_bultos = value
        End Set
    End Property
    Public Property precio() As Long
        Get
            Return _precio
        End Get
        Set(ByVal value As Long)
            _precio = value
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
    Public Property pic_fechaoc() As Date
        Get
            Return _pic_fechaoc
        End Get
        Set(ByVal value As Date)
            _pic_fechaoc = value
        End Set
    End Property
    Public Property pro_codigooriginal() As Integer
        Get
            Return _pro_codigooriginal
        End Get
        Set(ByVal value As Integer)
            _pro_codigooriginal = value
        End Set
    End Property
    Public Property con_codigounico() As String
        Get
            Return _con_codigounico
        End Get
        Set(ByVal value As String)
            _con_codigounico = value
        End Set
    End Property
    Public Property con_despacharanumero() As String
        Get
            Return _con_despacharanumero
        End Get
        Set(ByVal value As String)
            _con_despacharanumero = value
        End Set
    End Property
    Public Property con_despachara() As String
        Get
            Return _con_despachara
        End Get
        Set(ByVal value As String)
            _con_despachara = value
        End Set
    End Property
    Public Property con_local() As String
        Get
            Return _con_local
        End Get
        Set(ByVal value As String)
            _con_local = value
        End Set
    End Property
    Public Property con_localnombre() As String
        Get
            Return _con_localnombre
        End Get
        Set(ByVal value As String)
            _con_localnombre = value
        End Set
    End Property
    Public Property rut_cliente() As String
        Get
            Return _rut_cliente
        End Get
        Set(ByVal value As String)
            _rut_cliente = value
        End Set
    End Property
    Public Property nombre_cliente() As String
        Get
            Return _nombre_cliente
        End Get
        Set(ByVal value As String)
            _nombre_cliente = value
        End Set
    End Property
    Public Property con_observacion() As String
        Get
            Return _con_observacion
        End Get
        Set(ByVal value As String)
            _con_observacion = value
        End Set
    End Property
    Public Property pic_fechaocoriginal() As Date
        Get
            Return _pic_fechaocoriginal
        End Get
        Set(ByVal value As Date)
            _pic_fechaocoriginal = value
        End Set
    End Property
    Public Property pic_semodificafecha() As Boolean
        Get
            Return _pic_semodificafecha
        End Get
        Set(ByVal value As Boolean)
            _pic_semodificafecha = value
        End Set
    End Property

    Public Function SOLICITUD_ENTREGA_ENCABEZADO_GUARDA_DATOS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_solicitud_entrega_encabezado_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@sol_codigo", SqlDbType.Int)
            command.Parameters.Add("@sol_fecha", SqlDbType.Date)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@cant_unidades", SqlDbType.Int)
            command.Parameters.Add("@cant_bultos", SqlDbType.Int)
            command.Parameters.Add("@total_bultos", SqlDbType.Int)
            command.Parameters.Add("@eso_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _sol_codigo
            command.Parameters(1).Value = _sol_fecha
            command.Parameters(2).Value = _car_codigo
            command.Parameters(3).Value = _usu_codigo
            command.Parameters(4).Value = _cant_unidades
            command.Parameters(5).Value = _cant_bultos
            command.Parameters(6).Value = _total_bultos
            command.Parameters(7).Value = _eso_codigo

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





End Class
