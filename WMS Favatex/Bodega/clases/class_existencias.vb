Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_existencias
    Private _cnn As String
    Private _pro_codigo As Integer
    Private _bod_codigo As Integer
    Private _pos_nombre As String
    Private _pro_codInt As String
    Private _fecha_desde As String
    Private _fecha_hasta As String
    Private _mov_folio As String
    Private _bod_nombre As String
    Private _fecha_mov As String
    Private _pro_nombre As String
    Private _mov_observacion As String
    Private _tmo_nombre As String
    Private _tdo_nombre As String
    Private _dmo_entrada As Double
    Private _dmo_salida As Double
    Private _dmo_saldo As Double
    Public Property dmo_saldo() As Double
        Get
            Return _dmo_saldo
        End Get
        Set(ByVal value As Double)
            _dmo_saldo = value
        End Set
    End Property
    Public Property dmo_salida() As Double
        Get
            Return _dmo_salida
        End Get
        Set(ByVal value As Double)
            _dmo_salida = value
        End Set
    End Property

    Public Property dmo_entrada() As Double
        Get
            Return _dmo_entrada
        End Get
        Set(ByVal value As Double)
            _dmo_entrada = value
        End Set
    End Property
    Public Property tdo_nombre() As String
        Get
            Return _tdo_nombre
        End Get
        Set(ByVal value As String)
            _tdo_nombre = value
        End Set
    End Property

    Public Property tmo_nombre() As String
        Get
            Return _tmo_nombre
        End Get
        Set(ByVal value As String)
            _tmo_nombre = value
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

    Public Property pro_nombre() As String
        Get
            Return _pro_nombre
        End Get
        Set(ByVal value As String)
            _pro_nombre = value
        End Set
    End Property
    Public Property fecha_mov() As String
        Get
            Return _fecha_mov
        End Get
        Set(ByVal value As String)
            _fecha_mov = value
        End Set
    End Property
    Public Property bod_nombre() As String
        Get
            Return _bod_nombre
        End Get
        Set(ByVal value As String)
            _bod_nombre = value
        End Set
    End Property
    Public Property mov_folio() As String
        Get
            Return _mov_folio
        End Get
        Set(ByVal value As String)
            _mov_folio = value
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
    Public Property bod_codigo() As Integer
        Get
            Return _bod_codigo
        End Get
        Set(ByVal value As Integer)
            _bod_codigo = value
        End Set
    End Property
    Public Property pos_nombre() As String
        Get
            Return _pos_nombre
        End Get
        Set(ByVal value As String)
            _pos_nombre = value
        End Set
    End Property

    Public Property pro_codInt() As String
        Get
            Return _pro_codInt
        End Get
        Set(ByVal value As String)
            _pro_codInt = value
        End Set
    End Property
    Public Function carga_datos_tarjeta_existencia(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tarjeta_existencia_listar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _bod_codigo
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

    Public Function carga_datos_producto_por_codInterno(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_busca_productos_por_codigo", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters(0).Value = _pro_codInt

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function producto_guarda_detalle_tarjeta_existencia(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)

        Try
            Dim command As New SqlCommand("sp_detalle_tarjeta_existencia_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@bod_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@mov_fechaingreso", SqlDbType.NVarChar)
            command.Parameters.Add("@tmo_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@mov_tipo", SqlDbType.NVarChar)
            command.Parameters.Add("@mov_folio", SqlDbType.Int)
            command.Parameters.Add("@mov_observacion", SqlDbType.NVarChar)
            command.Parameters.Add("@mov_entrada", SqlDbType.Decimal)
            command.Parameters.Add("@mov_salida", SqlDbType.Decimal)
            command.Parameters.Add("@mov_saldo", SqlDbType.Decimal)
            command.Parameters.Add("@mov_impresion", SqlDbType.Int)


            command.Parameters(0).Value = _bod_nombre
            command.Parameters(1).Value = _pro_nombre
            command.Parameters(2).Value = _fecha_mov
            command.Parameters(3).Value = _tmo_nombre
            command.Parameters(4).Value = _tdo_nombre
            command.Parameters(5).Value = _mov_folio
            command.Parameters(6).Value = _mov_observacion


            command.Parameters(7).Value = _dmo_entrada
            command.Parameters(8).Value = _dmo_salida
            command.Parameters(9).Value = _dmo_saldo
            command.Parameters(10).Value = 1

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
End Class
