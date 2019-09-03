Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_ubicaciones
    Private _cnn As String
    Private _ubi_codigo As Integer
    Private _bod_codigo As Integer
    Private _btu_codigo As Integer
    Private _zon_codigo As Integer
    Private _tub_codigo As Integer
    Private _car_codigo As Integer
    Private _sca_codigo As Integer
    Private _eub_codigo As Integer
    Private _ubi_nombre As String
    Private _ubi_cantpallet As Double
    Private _ubi_cantpalletdoble As Double
    Private _ubi_cantpalletotro1 As Double
    Private _ubi_cantpalletotro2 As Double
    Private _ubi_alto As Double
    Private _ubi_ancho As Double
    Private _ubi_fondo As Double
    Private _ubi_capacidadm3 As Double
    Private _ubi_activo As Boolean
    Private _ubi_prioridad As Integer
    Private _prd_palletserie As String
    Private _ubi_relacionada As Integer
    Private _usu_codigo As Integer

    Private _ubi_cadena As String
    Private _pro_codigo As Integer

    Private _alt_codigo As Integer

    Private _rec_numero As Integer
    Private _asi_numero As Integer
    Private _asi_fila As Integer

    Private _usu_almacenamiento As Integer
    Private _can_reserva As Integer
    Private _pallet As String

    Private _asi_codigo As Integer
    Private _asi_fecha As Date
    Private _asi_fechaingreso As Date
    Private _esi_codigo As Integer
    Private _rec_fecha As Date
    Private _ocp_numero As Long
    Private _ocp_fecha As Date

    Private _asi_nbulto As Integer
    Private _asi_bulto As String
    Private _asi_pallet As String
    Private _asi_cantidad As Integer
    Private _asi_cantidadreserva As Integer
    Private _asi_cantidadsaldo As Integer
    Private _asi_ubicacionnombre As String
    Private _asi_ubicacioncodigo As String

    Private _fecha_desde As String
    Private _fecha_hasta As String
    Private _asi_ubicado As Boolean
    Private _aprobado As Boolean
    Private _rechazado As Boolean
    Private _rec_nguia As Long
    Private _rec_nfactura As Long

    Private _tmp_procodigo As Integer
    Private _tmp_numbulto As Integer
    Private _tmp_cantidad As Integer
    Private _tmp_llave As String

    Private _ubi_codigostr As String
    Private _Documento As String
    Private _Numero As Long
    Private _bultoVariado As Boolean
    Private _bul_codigo As Integer
    Private _desde_recepcion As Boolean
    Private _bulto_completo As Boolean
    Private _pro_codigointerno As String
    Private _pallet2 As String

    Private _cat_codigo As Integer
    Private _tipoPallet As String
    Private _ExcluyendoAsignadas As Boolean
    Private _ubi_codigoString As String
    Private _strCadena As String

    Private _oab_codigo As Integer
    Private _oab_fecha As Date

    Private _dab_fila As Integer
    Private _bulto As String
    Private _dab_codigo_ubicacion_pk As String
    Private _dab_nombre_ubicacion_pk As String
    Private _dab_pallet_pk As String
    Private _dab_cantidad_pk As Integer
    Private _dab_codigo_ubicacion_aba As String
    Private _dab_nombre_ubicacion_aba As String
    Private _dab_pallet_aba As String
    Private _dab_cantidad_aba As Integer
    Private _dab_procesado As Boolean

    Private _eab_codigo As Integer
    Private _diasUbicacion As Boolean = False
    Private _oab_observacion As String

    Private _palletRequerido As String
    Private _palletEncontrado As String
    Private _ubi_codigoactual As Integer
    Private _ubi_codigopisopt As Integer
    Private _ubi_codigoextraviado As Integer
    Private _ubicacion_vacia As Boolean

    Public Property ubicacion_vacia() As Boolean
        Get
            Return _ubicacion_vacia
        End Get
        Set(ByVal value As Boolean)
            _ubicacion_vacia = value
        End Set
    End Property
    Public Property ubi_codigoextraviado() As Integer
        Get
            Return _ubi_codigoextraviado
        End Get
        Set(ByVal value As Integer)
            _ubi_codigoextraviado = value
        End Set
    End Property
    Public Property ubi_codigopisopt() As Integer
        Get
            Return _ubi_codigopisopt
        End Get
        Set(ByVal value As Integer)
            _ubi_codigopisopt = value
        End Set
    End Property
    Public Property ubi_codigoactual() As Integer
        Get
            Return _ubi_codigoactual
        End Get
        Set(ByVal value As Integer)
            _ubi_codigoactual = value
        End Set
    End Property
    Public Property palletEncontrado() As String
        Get
            Return _palletEncontrado
        End Get
        Set(ByVal value As String)
            _palletEncontrado = value
        End Set
    End Property
    Public Property palletRequerido() As String
        Get
            Return _palletRequerido
        End Get
        Set(ByVal value As String)
            _palletRequerido = value
        End Set
    End Property

    Public Property oab_observacion() As String
        Get
            Return _oab_observacion
        End Get
        Set(ByVal value As String)
            _oab_observacion = value
        End Set
    End Property

    Public Property diasUbicacion() As Boolean
        Get
            Return _diasUbicacion
        End Get
        Set(ByVal value As Boolean)
            _diasUbicacion = value
        End Set
    End Property

    Public Property eab_codigo() As Integer
        Get
            Return _eab_codigo
        End Get
        Set(ByVal value As Integer)
            _eab_codigo = value
        End Set
    End Property

    Public Property dab_procesado() As Boolean
        Get
            Return _dab_procesado
        End Get
        Set(ByVal value As Boolean)
            _dab_procesado = value
        End Set
    End Property
    Public Property dab_cantidad_aba() As Integer
        Get
            Return _dab_cantidad_aba
        End Get
        Set(ByVal value As Integer)
            _dab_cantidad_aba = value
        End Set
    End Property
    Public Property dab_pallet_aba() As String
        Get
            Return _dab_pallet_aba
        End Get
        Set(ByVal value As String)
            _dab_pallet_aba = value
        End Set
    End Property
    Public Property dab_nombre_ubicacion_aba() As String
        Get
            Return _dab_nombre_ubicacion_aba
        End Get
        Set(ByVal value As String)
            _dab_nombre_ubicacion_aba = value
        End Set
    End Property
    Public Property dab_codigo_ubicacion_aba() As String
        Get
            Return _dab_codigo_ubicacion_aba
        End Get
        Set(ByVal value As String)
            _dab_codigo_ubicacion_aba = value
        End Set
    End Property
    Public Property dab_cantidad_pk() As Integer
        Get
            Return _dab_cantidad_pk
        End Get
        Set(ByVal value As Integer)
            _dab_cantidad_pk = value
        End Set
    End Property
    Public Property dab_pallet_pk() As String
        Get
            Return _dab_pallet_pk
        End Get
        Set(ByVal value As String)
            _dab_pallet_pk = value
        End Set
    End Property
    Public Property dab_nombre_ubicacion_pk() As String
        Get
            Return _dab_nombre_ubicacion_pk
        End Get
        Set(ByVal value As String)
            _dab_nombre_ubicacion_pk = value
        End Set
    End Property
    Public Property dab_codigo_ubicacion_pk() As String
        Get
            Return _dab_codigo_ubicacion_pk
        End Get
        Set(ByVal value As String)
            _dab_codigo_ubicacion_pk = value
        End Set
    End Property
    Public Property bulto() As String
        Get
            Return _bulto
        End Get
        Set(ByVal value As String)
            _bulto = value
        End Set
    End Property
    Public Property dab_fila() As Integer
        Get
            Return _dab_fila
        End Get
        Set(ByVal value As Integer)
            _dab_fila = value
        End Set
    End Property

    Public Property oab_fecha() As Date
        Get
            Return _oab_fecha
        End Get
        Set(ByVal value As Date)
            _oab_fecha = value
        End Set
    End Property
    Public Property oab_codigo() As Integer
        Get
            Return _oab_codigo
        End Get
        Set(ByVal value As Integer)
            _oab_codigo = value
        End Set
    End Property
    Public Property strCadena() As String
        Get
            Return _strCadena
        End Get
        Set(ByVal value As String)
            _strCadena = value
        End Set
    End Property

    Public Property ubi_codigoString() As String
        Get
            Return _ubi_codigoString
        End Get
        Set(ByVal value As String)
            _ubi_codigoString = value
        End Set
    End Property

    Public Property ExcluyendoAsignadas() As Boolean
        Get
            Return _ExcluyendoAsignadas
        End Get
        Set(ByVal value As Boolean)
            _ExcluyendoAsignadas = value
        End Set
    End Property
    Public Property tipoPallet() As String
        Get
            Return _tipoPallet
        End Get
        Set(ByVal value As String)
            _tipoPallet = value
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

    Public Property pallet2() As String
        Get
            Return _pallet2
        End Get
        Set(ByVal value As String)
            _pallet2 = value
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
    Public Property bulto_completo() As Boolean
        Get
            Return _bulto_completo
        End Get
        Set(ByVal value As Boolean)
            _bulto_completo = value
        End Set
    End Property

    Public Property desde_recepcion() As Boolean
        Get
            Return _desde_recepcion
        End Get
        Set(ByVal value As Boolean)
            _desde_recepcion = value
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

    Public Property bultoVariado() As Boolean
        Get
            Return _bultoVariado
        End Get
        Set(ByVal value As Boolean)
            _bultoVariado = value
        End Set
    End Property
    Public Property Documento() As String
        Get
            Return _Documento
        End Get
        Set(ByVal value As String)
            _Documento = value
        End Set
    End Property
    Public Property Numero() As Long
        Get
            Return _Numero
        End Get
        Set(ByVal value As Long)
            _Numero = value
        End Set
    End Property
    Public Property ubi_codigostr() As String
        Get
            Return _ubi_codigostr
        End Get
        Set(ByVal value As String)
            _ubi_codigostr = value
        End Set
    End Property

    Public Property tmp_procodigo() As Integer
        Get
            Return _tmp_procodigo
        End Get
        Set(ByVal value As Integer)
            _tmp_procodigo = value
        End Set
    End Property
    Public Property tmp_numbulto() As Integer
        Get
            Return _tmp_numbulto
        End Get
        Set(ByVal value As Integer)
            _tmp_numbulto = value
        End Set
    End Property
    Public Property tmp_cantidad() As Integer
        Get
            Return _tmp_cantidad
        End Get
        Set(ByVal value As Integer)
            _tmp_cantidad = value
        End Set
    End Property

    Public Property tmp_llave() As String
        Get
            Return _tmp_llave
        End Get
        Set(ByVal value As String)
            _tmp_llave = value
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
    Public Property aprobado() As Boolean
        Get
            Return _aprobado
        End Get
        Set(ByVal value As Boolean)
            _aprobado = value
        End Set
    End Property
    Public Property rechazado() As Boolean
        Get
            Return _rechazado
        End Get
        Set(ByVal value As Boolean)
            _rechazado = value
        End Set
    End Property

    Public Property asi_ubicado() As Boolean
        Get
            Return _asi_ubicado
        End Get
        Set(ByVal value As Boolean)
            _asi_ubicado = value
        End Set
    End Property
    Public Property asi_fila() As Integer
        Get
            Return _asi_fila
        End Get
        Set(ByVal value As Integer)
            _asi_fila = value
        End Set
    End Property
    Public Property fecha_desde() As String
        Get
            Return _fecha_desde
        End Get
        Set(ByVal value As String)
            _fecha_desde = value
        End Set
    End Property
    Public Property Fecha_hasta() As String
        Get
            Return _fecha_hasta
        End Get
        Set(ByVal value As String)
            _fecha_hasta = value
        End Set
    End Property

    Public Property asi_nbulto() As String
        Get
            Return _asi_nbulto
        End Get
        Set(ByVal value As String)
            _asi_nbulto = value
        End Set
    End Property
    Public Property asi_bulto() As String
        Get
            Return _asi_bulto
        End Get
        Set(ByVal value As String)
            _asi_bulto = value
        End Set
    End Property
    Public Property asi_pallet() As String
        Get
            Return _asi_pallet
        End Get
        Set(ByVal value As String)
            _asi_pallet = value
        End Set
    End Property
    Public Property asi_cantidad() As Integer
        Get
            Return _asi_cantidad
        End Get
        Set(ByVal value As Integer)
            _asi_cantidad = value
        End Set
    End Property
    Public Property asi_cantidadreserva() As Integer
        Get
            Return _asi_cantidadreserva
        End Get
        Set(ByVal value As Integer)
            _asi_cantidadreserva = value
        End Set
    End Property
    Public Property asi_cantidadsaldo() As Integer
        Get
            Return _asi_cantidadsaldo
        End Get
        Set(ByVal value As Integer)
            _asi_cantidadsaldo = value
        End Set
    End Property
    Public Property asi_ubicacionnombre() As String
        Get
            Return _asi_ubicacionnombre
        End Get
        Set(ByVal value As String)
            _asi_ubicacionnombre = value
        End Set
    End Property
    Public Property asi_ubicacioncodigo() As String
        Get
            Return _asi_ubicacioncodigo
        End Get
        Set(ByVal value As String)
            _asi_ubicacioncodigo = value
        End Set
    End Property

    Public Property asi_codigo() As Integer
        Get
            Return _asi_codigo
        End Get
        Set(ByVal value As Integer)
            _asi_codigo = value
        End Set
    End Property
    Public Property asi_fecha() As Date
        Get
            Return _asi_fecha
        End Get
        Set(ByVal value As Date)
            _asi_fecha = value
        End Set
    End Property
    Public Property asi_fechaingreso() As Date
        Get
            Return _asi_fechaingreso
        End Get
        Set(ByVal value As Date)
            _asi_fechaingreso = value
        End Set
    End Property
    Public Property esi_codigo() As Integer
        Get
            Return _esi_codigo
        End Get
        Set(ByVal value As Integer)
            _esi_codigo = value
        End Set
    End Property
    Public Property rec_fecha() As Date
        Get
            Return _rec_fecha
        End Get
        Set(ByVal value As Date)
            _rec_fecha = value
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
    Public Property ocp_fecha() As Date
        Get
            Return _ocp_fecha
        End Get
        Set(ByVal value As Date)
            _ocp_fecha = value
        End Set
    End Property

    Public Property pallet() As String
        Get
            Return _pallet
        End Get
        Set(ByVal value As String)
            _pallet = value
        End Set
    End Property

    Public Property can_reserva() As Integer
        Get
            Return _can_reserva
        End Get
        Set(ByVal value As Integer)
            _can_reserva = value
        End Set
    End Property

    Public Property asi_numero() As Integer
        Get
            Return _asi_numero
        End Get
        Set(ByVal value As Integer)
            _asi_numero = value
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
    Public Property usu_almacenamiento() As Integer
        Get
            Return _usu_almacenamiento
        End Get
        Set(ByVal value As Integer)
            _usu_almacenamiento = value
        End Set
    End Property


    Public Property alt_codigo() As Integer
        Get
            Return _alt_codigo
        End Get
        Set(ByVal value As Integer)
            _alt_codigo = value
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

    Public Property ubi_relacionada() As Integer
        Get
            Return _ubi_relacionada
        End Get
        Set(ByVal value As Integer)
            _ubi_relacionada = value
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

    Public Property eub_codigo() As Integer
        Get
            Return _eub_codigo
        End Get
        Set(ByVal value As Integer)
            _eub_codigo = value
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
    Public Property ubi_prioridad() As Integer
        Get
            Return _ubi_prioridad
        End Get
        Set(ByVal value As Integer)
            _ubi_prioridad = value
        End Set
    End Property
    Public Property btu_codigo() As Integer
        Get
            Return _btu_codigo
        End Get
        Set(ByVal value As Integer)
            _btu_codigo = value
        End Set
    End Property
    Public Property zon_codigo() As Integer
        Get
            Return _zon_codigo
        End Get
        Set(ByVal value As Integer)
            _zon_codigo = value
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

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Public Property tub_codigo() As Integer
        Get
            Return _tub_codigo
        End Get
        Set(ByVal value As Integer)
            _tub_codigo = value
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
    Public Property sca_codigo() As Integer
        Get
            Return _sca_codigo
        End Get
        Set(ByVal value As Integer)
            _sca_codigo = value
        End Set
    End Property
    Public Property ubi_nombre() As String
        Get
            Return _ubi_nombre
        End Get
        Set(ByVal value As String)
            _ubi_nombre = value
        End Set
    End Property
    Public Property ubi_cantpallet() As Double
        Get
            Return _ubi_cantpallet
        End Get
        Set(ByVal value As Double)
            _ubi_cantpallet = value
        End Set
    End Property
    Public Property ubi_cantpalletdoble() As Double
        Get
            Return _ubi_cantpalletdoble
        End Get
        Set(ByVal value As Double)
            _ubi_cantpalletdoble = value
        End Set
    End Property
    Public Property ubi_cantpalletotro1() As Double
        Get
            Return _ubi_cantpalletotro1
        End Get
        Set(ByVal value As Double)
            _ubi_cantpalletotro1 = value
        End Set
    End Property
    Public Property ubi_cantpalletotro2() As Double
        Get
            Return _ubi_cantpalletotro2
        End Get
        Set(ByVal value As Double)
            _ubi_cantpalletotro2 = value
        End Set
    End Property
    Public Property ubi_alto() As Double
        Get
            Return _ubi_alto
        End Get
        Set(ByVal value As Double)
            _ubi_alto = value
        End Set
    End Property
    Public Property ubi_ancho() As Double
        Get
            Return _ubi_ancho
        End Get
        Set(ByVal value As Double)
            _ubi_ancho = value
        End Set
    End Property
    Public Property ubi_fondo() As Double
        Get
            Return _ubi_fondo
        End Get
        Set(ByVal value As Double)
            _ubi_fondo = value
        End Set
    End Property
    Public Property ubi_capacidadm3() As Double
        Get
            Return _ubi_capacidadm3
        End Get
        Set(ByVal value As Double)
            _ubi_capacidadm3 = value
        End Set
    End Property
    Public Property ubi_activo() As Boolean
        Get
            Return _ubi_activo
        End Get
        Set(ByVal value As Boolean)
            _ubi_activo = value
        End Set
    End Property

    Public Function CARGA_DATOS_UBICACIONES(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ubicacion_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@btu_codigo", SqlDbType.Int)
            command.Parameters.Add("@zon_cadigo", SqlDbType.Int)
            command.Parameters.Add("@eub_codigo", SqlDbType.Int)
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters.Add("@alt_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _bod_codigo
            command.Parameters(1).Value = _btu_codigo
            command.Parameters(2).Value = _zon_codigo
            command.Parameters(3).Value = _eub_codigo
            command.Parameters(4).Value = _ubi_codigo
            command.Parameters(5).Value = _alt_codigo

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

    'Public Function GENERA_UBICACIONES(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
    '    Try
    '        Dim command As New SqlCommand("sp_ubicaciones_genera", conexion)
    '        command.CommandType = CommandType.StoredProcedure

    '        command.Parameters.Add("@pos_codigo", SqlDbType.Int)
    '        command.Parameters.Add("@alt_codigo", SqlDbType.Int)

    '        command.Parameters(0).Value = _pos_codigo
    '        command.Parameters(1).Value = _alt_codigo

    '        Dim da As New SqlDataAdapter(command)
    '        Dim ds As New DataSet

    '        da.Fill(ds)

    '        Return ds
    '    Catch ex As Exception
    '        Mensaje = ex.Message
    '        Return Nothing
    '    End Try
    'End Function

     Public Function ELIMINA_UBICACIONES(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_ubicacion_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ubi_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function GUARDA_REGISTRO_UBICACION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_bod_ubicacion_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@btu_codigo", SqlDbType.Int)
            command.Parameters.Add("@zon_codigo", SqlDbType.Int)
            command.Parameters.Add("@alt_codigo", SqlDbType.Int)
            command.Parameters.Add("@ubi_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@ubi_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _ubi_codigo
            command.Parameters(1).Value = _bod_codigo
            command.Parameters(2).Value = _btu_codigo
            command.Parameters(3).Value = _zon_codigo
            command.Parameters(4).Value = _alt_codigo
            command.Parameters(5).Value = _ubi_nombre
            command.Parameters(6).Value = _ubi_activo

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

    Public Function BUSCA_DATOS_UBICACIONES(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ubicacion_carga_datos", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ubi_codigo
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

    Public Function ESTADO_UBICACIONES_CARGA_COMNBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_estado_ubicacion_carga_combo", conexion)
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

    Public Function UBICACIONES_RELACIONADAS_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ubicaciones_disponibles_relacionar_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@zon_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _zon_codigo
            command.Parameters(1).Value = _car_codigo

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

    Public Function UBICACIONES_RELACIONADAS_CON_UBICACION_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ubicaciones_disponibles_relacionadas_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ubi_codigo
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

    Public Function ACTUALIZA_POSICIONES(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try

            Dim command As New SqlCommand("sp_actualiza_posiciones", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@eub_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _bod_codigo
            command.Parameters(2).Value = _eub_codigo

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

    Public Function BUSCA_UBICACIONES_POR_PRODUCTOS_PARA_PICKING(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ubicacionees_por_productos_para_picking", conexion)
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

    Public Function CARGA_UBICACIONES_SIN_PROVEEDORES(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ubicacion_proveedor_sin_asociar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ubi_codigo
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
    Public Function CARGA_UBICACIONES_CON_PROVEEDORES(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ubicacion_proveedor_asociado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ubi_codigo
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
    Public Function PROVEEDOR_ASOCIA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_ubicacion_proveesor_selecciona", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _ubi_codigo
            command.Parameters(1).Value = _car_codigo
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

    Public Function PROVEEDOR_DESASOCIA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_ubicacion_proveesor_deselecciona", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _ubi_codigo
            command.Parameters(1).Value = _car_codigo
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

    Public Function RECEPCION_ASIGNA_PARA_UBICACION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_asigna_para_recepcion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@usu_almacenamiento", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _usu_almacenamiento

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_CABECERA_ASIGNACION(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_obtiene_asignacion_sin_numero", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@numAsigacion", SqlDbType.Int)
            command.Parameters.Add("@recNumero", SqlDbType.Int)

            command.Parameters(0).Value = _asi_numero
            command.Parameters(1).Value = _rec_numero
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
    Public Function CARGA_DETALLE_ASIGNACION(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_listado_detalle_asignacion_ubicacion", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@numRecepcion", SqlDbType.Int)
            command.Parameters.Add("@proCodigo", SqlDbType.Int)
            command.Parameters.Add("@can_reserva", SqlDbType.Int)
            command.Parameters.Add("@asiCodigo", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _can_reserva
            command.Parameters(3).Value = _asi_numero
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
    Public Function OBTIENE_UBICACION_PARA_ASIGNAR(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_obtiene_posicion_disponible", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_codigo", SqlDbType.Int)
            command.Parameters.Add("@pallet", SqlDbType.NVarChar)

            command.Parameters(0).Value = _car_codigo
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _bul_codigo
            command.Parameters(3).Value = _pallet

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

    Public Function GUARDA_ASIGNACION_ENCABEZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_asignacion_ubicacion_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@asi_codigo", SqlDbType.Int)
            command.Parameters.Add("@asi_fecha", SqlDbType.Date)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@esi_codigo", SqlDbType.Int)
            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@rec_fecha", SqlDbType.Date)
            command.Parameters.Add("@ocp_numero", SqlDbType.Float)
            command.Parameters.Add("@ocp_fecha", SqlDbType.Date)
            command.Parameters.Add("@rec_nguia", SqlDbType.Int)
            command.Parameters.Add("@rec_nfactura", SqlDbType.Int)
            command.Parameters.Add("@bulto_completo", SqlDbType.Int)

            command.Parameters(0).Value = _asi_codigo
            command.Parameters(1).Value = _asi_fecha
            command.Parameters(2).Value = _car_codigo
            command.Parameters(3).Value = _esi_codigo
            command.Parameters(4).Value = _rec_numero
            command.Parameters(5).Value = _rec_fecha
            command.Parameters(6).Value = _ocp_numero
            command.Parameters(7).Value = _ocp_fecha
            command.Parameters(8).Value = _rec_nguia
            command.Parameters(9).Value = _rec_nfactura
            command.Parameters(10).Value = _bulto_completo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function LIMPIA_DETALLE_ASIGNACION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_limpia_detalle_asignacion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@asi_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _asi_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CAMBIA_ESTADO_ASIGNACION(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_asignacion_cambia_estado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@asi_codigo", SqlDbType.Int)
            command.Parameters.Add("@esi_codigo", SqlDbType.Date)

            command.Parameters(0).Value = _asi_codigo
            command.Parameters(1).Value = _esi_codigo


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ELIMINA_ASIGNACION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_asignacion_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@asi_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _asi_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function GUARDA_DETALLE_ASIGNACION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_asignacion_ubicacion_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@asi_codigo", SqlDbType.Int)
            command.Parameters.Add("@asi_fila", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@asi_nbulto", SqlDbType.Int)
            command.Parameters.Add("@asi_bulto", SqlDbType.NVarChar)
            command.Parameters.Add("@asi_pallet", SqlDbType.NVarChar)
            command.Parameters.Add("@asi_cantidad", SqlDbType.Int)
            command.Parameters.Add("@asi_cantidadreserva", SqlDbType.Int)
            command.Parameters.Add("@asi_cantidadsaldo", SqlDbType.Int)
            command.Parameters.Add("@asi_ubicacionnombre", SqlDbType.NVarChar)
            command.Parameters.Add("@asi_ubicacioncodigo", SqlDbType.NVarChar)
            command.Parameters.Add("@asi_ubicado", SqlDbType.Bit)
            command.Parameters.Add("@aprobado", SqlDbType.Bit)
            command.Parameters.Add("@rechazado", SqlDbType.Bit)

            command.Parameters(0).Value = _asi_codigo
            command.Parameters(1).Value = _asi_fila
            command.Parameters(2).Value = _pro_codigo
            command.Parameters(3).Value = _asi_nbulto
            command.Parameters(4).Value = _asi_bulto
            command.Parameters(5).Value = _asi_pallet
            command.Parameters(6).Value = _asi_cantidad
            command.Parameters(7).Value = _asi_cantidadreserva
            command.Parameters(8).Value = _asi_cantidadsaldo
            command.Parameters(9).Value = _asi_ubicacionnombre
            command.Parameters(10).Value = _asi_ubicacioncodigo
            command.Parameters(11).Value = _asi_ubicado
            command.Parameters(12).Value = _aprobado
            command.Parameters(13).Value = _rechazado


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function


    'Public Function GUARDA_ASIGNACION_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
    '    'Dim conexion As New SqlConnection(_cnn)
    '    Try
    '        Dim command As New SqlCommand("sp_asignacion_ubicacion_detalle_guarda", conexion)
    '        command.CommandType = CommandType.StoredProcedure

    '        command.Parameters.Add("@asi_codigo", SqlDbType.Int)
    '        command.Parameters.Add("@asi_fila", SqlDbType.Int)
    '        command.Parameters.Add("@pro_codigo", SqlDbType.Int)
    '        command.Parameters.Add("@asi_nbulto", SqlDbType.Int)
    '        command.Parameters.Add("@asi_bulto", SqlDbType.NVarChar)
    '        command.Parameters.Add("@asi_pallet", SqlDbType.NVarChar)
    '        command.Parameters.Add("@asi_cantidad", SqlDbType.Int)
    '        command.Parameters.Add("@asi_cantidadreserva", SqlDbType.Int)
    '        command.Parameters.Add("@asi_cantidadsaldo", SqlDbType.Int)
    '        command.Parameters.Add("@asi_ubicacionnombre", SqlDbType.NVarChar)
    '        command.Parameters.Add("@asi_ubicacioncodigo", SqlDbType.NVarChar)
    '        command.Parameters.Add("@asi_ubicado", SqlDbType.Bit)
    '        command.Parameters.Add("@aprobado", SqlDbType.Bit)
    '        command.Parameters.Add("@rechazado", SqlDbType.Bit)

    '        command.Parameters(0).Value = _asi_codigo
    '        command.Parameters(1).Value = _asi_fila
    '        command.Parameters(2).Value = _pro_codigo
    '        command.Parameters(3).Value = _asi_nbulto
    '        command.Parameters(4).Value = _asi_bulto
    '        command.Parameters(5).Value = _asi_pallet
    '        command.Parameters(6).Value = _asi_cantidad
    '        command.Parameters(7).Value = _asi_cantidadreserva
    '        command.Parameters(8).Value = _asi_cantidadsaldo
    '        command.Parameters(9).Value = _asi_ubicacionnombre
    '        command.Parameters(10).Value = _asi_ubicacioncodigo
    '        command.Parameters(11).Value = _asi_ubicado
    '        command.Parameters(12).Value = _aprobado
    '        command.Parameters(13).Value = _rechazado


    '        Dim da As New SqlDataAdapter(command)
    '        Dim ds As New DataSet
    '        da.Fill(ds)
    '        Return ds
    '    Catch ex As Exception
    '        Mensaje = ex.Message
    '        Return Nothing
    '    End Try
    'End Function

    Public Function CARGA_COMBO_ESTADO_ASIGNACION_UBICACION(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_asignacion_ubicacion_carga_combo", conexion)

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

    Public Function ASIGNACIONES_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_asignacion_ubicacion_listado", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@asi_codigo", _asi_codigo))
            command.Parameters.Add(New SqlParameter("@car_codigo", _car_codigo))
            command.Parameters.Add(New SqlParameter("@asi_orden", _ocp_numero))
            command.Parameters.Add(New SqlParameter("@asi_recep", _rec_numero))
            command.Parameters.Add(New SqlParameter("@fecha_desde", _fecha_desde))
            command.Parameters.Add(New SqlParameter("@fecha_hasta", _fecha_hasta))
            command.Parameters.Add(New SqlParameter("@esi_codigo", _esi_codigo))
            command.Parameters.Add(New SqlParameter("@desde_recepcion", _desde_recepcion))
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

    Public Function OBTIENE_ESTADO_ASIGNACION(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_obtiene_estado_asignacion", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@numAsigacion", SqlDbType.Int)

            command.Parameters(0).Value = _asi_numero
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

    Public Function BUSCA_PALLET_POR_TEXTO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_pallet_txt_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pallet", SqlDbType.NVarChar)
            command.Parameters.Add("@pallet2", SqlDbType.NVarChar)
            command.Parameters(0).Value = _pallet
            command.Parameters(1).Value = _pallet2
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

    Public Function BUSCA_PALLET_DESCRIPCION(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_pallet_descripcion_pallet", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pallet", SqlDbType.NVarChar)
            command.Parameters(0).Value = _pallet
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

    Public Function CARGA_COMBO_UBICACIONES(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_ubicacion_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _bod_codigo
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

    Public Function ACTUALIZA_UBICACIONES(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_ubicacion_actualiza", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pallet", SqlDbType.NVarChar)
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pallet
            command.Parameters(1).Value = _ubi_codigo
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

    Public Function ACTUALIZA_RESERVAS_EN_RECEPCION(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_cantidades_reservadas_recepcion", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@cantidad", SqlDbType.Int)

            command.Parameters(0).Value = _rec_numero
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _can_reserva

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DATOS_PARA_PALETIZAR_INGRESA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_tmp_datos_para_paletizar_ingresa", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tmp_procodigo", SqlDbType.Int)
            command.Parameters.Add("@tmp_numbulto", SqlDbType.Int)
            command.Parameters.Add("@tmp_cantidad", SqlDbType.Int)
            command.Parameters.Add("@tmp_llave", SqlDbType.NVarChar)

            command.Parameters(0).Value = _tmp_procodigo
            command.Parameters(1).Value = _tmp_numbulto
            command.Parameters(2).Value = _tmp_cantidad
            command.Parameters(3).Value = _tmp_llave

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function DATOS_PARA_PALETIZAR_ELIMINA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_tmp_datos_para_paletizar_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tmp_llave", SqlDbType.NVarChar)
            command.Parameters.Add("@Documento", SqlDbType.NVarChar)
            command.Parameters.Add("@Numero", SqlDbType.Float)

            command.Parameters(0).Value = _tmp_llave
            command.Parameters(1).Value = _Documento
            command.Parameters(2).Value = _Numero

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function PALETIZA_SOBRANTES(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_paletiza_sobrante", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tmp_llave_in", SqlDbType.NVarChar)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _tmp_llave
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _ubi_codigo
            'command.ExecuteNonQuery()
            'conexion.Open()
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

    Public Function ALMACENA_PALLET(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_almacena_pallet", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pal_palletserie", SqlDbType.NVarChar)
            command.Parameters.Add("@cantidad", SqlDbType.Int)
            command.Parameters.Add("@asi_ubicacioncodigo", SqlDbType.NVarChar)
            command.Parameters.Add("@tmp_llave", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pallet
            command.Parameters(1).Value = _asi_cantidadsaldo
            command.Parameters(2).Value = _ubi_codigostr
            command.Parameters(3).Value = _tmp_llave

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function UBICACION_DISPONIBILIZA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_ubicaciones_disponibiliza", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@asi_ubicacioncodigo", SqlDbType.NVarChar)
            command.Parameters(0).Value = _ubi_codigostr

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function OBTIENE_DETALLE_ASIGNACION_PARA_MOVIMIENTO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_selecciona_asignacion_para_movimiento", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@asiNumero", SqlDbType.Int)
            command.Parameters(0).Value = _asi_codigo
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

    Public Function UBICACIONES_PISO_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_ubicacion_piso_sin_pt_carga_combo", conexion)
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

    Public Function PRODUCTOS_POR_UBICACIONES_PISO_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_piso_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ubi_codigo

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

    Public Function PALLET_PISO_CARGA_GRILLA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_pallet_piso_carga_grilla", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ubi_codigo
            command.Parameters(1).Value = _pro_codigo
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

    Public Function ACTUALIZA_UBICACIONES_A_PISO_PT(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_envia_pallet_a_pt", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters.Add("@pallet", SqlDbType.NVarChar)
            command.Parameters.Add("@diasUbicacion", SqlDbType.Bit)

            command.Parameters(0).Value = _ubi_codigo
            command.Parameters(1).Value = _pallet
            command.Parameters(2).Value = _diasUbicacion
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

    Public Function DATOS_PARA_TRASPASO_A_PISO_PT(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_obtiene_datos_para_traspaso_a_piso_pt", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@asi_pallet", SqlDbType.NVarChar)
            command.Parameters(0).Value = _pallet

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_DETALLE_REASIGNACION(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_listado_detalle_asignacion_reubicacion", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@proCodigo", SqlDbType.Int)
            command.Parameters.Add("@asiCodigo", SqlDbType.Int)
            command.Parameters.Add("@ubiCodigo", SqlDbType.Int)
            command.Parameters.Add("@bultoVariado", SqlDbType.Bit)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _asi_numero
            command.Parameters(2).Value = _ubi_codigo
            command.Parameters(3).Value = _bultoVariado

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

    Public Function PRODUCTOS_POR_UBICACIONES_PISO_CARGA_COMBO_BULTO_UNICO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_piso_carga_combo_reubicacion_bulto_unico", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ubi_codigo

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

    Public Function PRODUCTOS_POR_UBICACIONES_PISO_CARGA_COMBO_BULTO_VARIADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_productos_piso_carga_combo_reubicacion_bulto_variado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _ubi_codigo

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

    Public Function ASIGNA_NUMERO_ASI(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_asigna_numero_asi", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@asi_codigo", SqlDbType.Int)
            command.Parameters.Add("@pallet", SqlDbType.NVarChar)

            command.Parameters(0).Value = _asi_numero
            command.Parameters(1).Value = _asi_pallet


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

    Public Function VALIDA_ASIGNACIONES_PENDIENTE(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_valida_asignaciones_pendientes", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@rec_numero", SqlDbType.Int)
            command.Parameters(0).Value = _rec_numero

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

    Public Function CARGA_UBICACIONES_SIN_UBICACION_ASOC(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_producto_bulto_por_ubicar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@ubi_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigointerno
            command.Parameters(1).Value = _ubi_codigo
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

    Public Function CARGA_UBICACIONES_CON_UBICACION_ASOC(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_producto_bulto_ubicado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bulto", SqlDbType.Int)

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

    Public Function UBICACION_ASOCIA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_ubicacion_producto_bulto_selecciona", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@ubi_codigo", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_codigo", SqlDbType.Int)
            command.Parameters.Add("@ubi_nombre", SqlDbType.NVarChar)

            command.Parameters(0).Value = _ubi_codigoString
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _bul_codigo
            command.Parameters(3).Value = _ubi_nombre

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

    Public Function UBICACION_DESASOCIA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_ubicacion_producto_bulto_deselecciona", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@ubi_codigoStr", SqlDbType.NVarChar)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _ubi_codigoString
            command.Parameters(1).Value = _pro_codigo
            command.Parameters(2).Value = _bul_codigo

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

    Public Function BUSCA_PRODUCTOS_PARA_ABASTECIMIENTO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_producto_listado_abastecimiento_para_pk", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@cat_codigo", SqlDbType.Int)
            command.Parameters.Add("@sub_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigointerno
            command.Parameters(1).Value = _cat_codigo
            command.Parameters(2).Value = _sca_codigo
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

    Public Function OBTIENE_UBICACION_PARA_PK(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_obtiene_posicion_para_abastecimiento", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@Bulto", SqlDbType.Int)
            command.Parameters.Add("@tipoPallet", SqlDbType.NVarChar)
            command.Parameters.Add("@ExcluyendoAsignadas", SqlDbType.NVarChar)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _bul_codigo
            command.Parameters(2).Value = _tipoPallet
            command.Parameters(3).Value = _ExcluyendoAsignadas
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

    Public Function SELECCIONA_PRODUCTOS_PARA_ABASTECIMIENTO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_posiciones_para_pk_selecciona", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@strCadena", SqlDbType.NVarChar)
            command.Parameters(0).Value = _strCadena

            conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)
            conexion.Close()
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function SELECCIONA_POSICIONES_PARA_ABASTECER(ByRef Msg As String, ByVal conexion As SqlConnection) As DataSet
        Try
            'Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_obtiene_posicion_abastecimiento", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@bul_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigo
            command.Parameters(1).Value = _bul_codigo

            'conexion.Open()
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)
            'conexion.Close()
            Return ds
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function GUARDA_ORDEN_ABASTECIMIENTO_ENCABEZADO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_orden_abastecimiento_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@oab_codigo", SqlDbType.Int)
            command.Parameters.Add("@oab_fecha", SqlDbType.Date)
            command.Parameters.Add("@oab_observacion", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@eab_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _oab_codigo
            command.Parameters(1).Value = _oab_fecha
            command.Parameters(2).Value = _oab_observacion
            command.Parameters(3).Value = GLO_USUARIO_ACTUAL
            command.Parameters(4).Value = _eab_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function GUARDA_ORDEN_ABASTECIMIENTO_DETALLE(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_orden_abastecimiento_destalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@oab_codigo", SqlDbType.Int)
            command.Parameters.Add("@dab_fila", SqlDbType.Int)
            command.Parameters.Add("@pro_codigo", SqlDbType.Int)
            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@bulto", SqlDbType.NVarChar)
            command.Parameters.Add("@dab_codigo_ubicacion_pk", SqlDbType.NVarChar)
            command.Parameters.Add("@dab_nombre_ubicacion_pk", SqlDbType.NVarChar)
            command.Parameters.Add("@dab_pallet_pk", SqlDbType.NVarChar)
            command.Parameters.Add("@dab_cantidad_pk", SqlDbType.Int)
            command.Parameters.Add("@dab_codigo_ubicacion_aba", SqlDbType.NVarChar)
            command.Parameters.Add("@dab_nombre_ubicacion_aba", SqlDbType.NVarChar)
            command.Parameters.Add("@dab_pallet_aba", SqlDbType.NVarChar)
            command.Parameters.Add("@dab_cantidad_aba", SqlDbType.Int)
            command.Parameters.Add("@dab_procesado", SqlDbType.Int)

            command.Parameters(0).Value = _oab_codigo
            command.Parameters(1).Value = _dab_fila
            command.Parameters(2).Value = _pro_codigo
            command.Parameters(3).Value = _pro_codigointerno
            command.Parameters(4).Value = _bulto
            command.Parameters(5).Value = _dab_codigo_ubicacion_pk
            command.Parameters(6).Value = _dab_nombre_ubicacion_pk
            command.Parameters(7).Value = _dab_pallet_pk
            command.Parameters(8).Value = _dab_cantidad_pk
            command.Parameters(9).Value = _dab_codigo_ubicacion_aba
            command.Parameters(10).Value = _dab_nombre_ubicacion_aba
            command.Parameters(11).Value = _dab_pallet_aba
            command.Parameters(12).Value = _dab_cantidad_aba
            command.Parameters(13).Value = _dab_procesado

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ORDEN_ABASTECIMIENTO_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_listado_ordenes_abastecimiento", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@numero", _oab_codigo))
            command.Parameters.Add(New SqlParameter("@codigo", _pro_codigointerno))
            command.Parameters.Add(New SqlParameter("@fecha_desde", _fecha_desde))
            command.Parameters.Add(New SqlParameter("@fecha_hasta", _fecha_hasta))
            command.Parameters.Add(New SqlParameter("@eab_codigo", _eab_codigo))

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

    Public Function CARGA_COMBO_ESTADO_ORDEN_ABASTECIMIENTO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_estado_orden_abastecimiento_carga_combo", conexion)
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

    Public Function ORDEN_ABASTECIMIENTO_DETALLE_LISTAR(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_listado_ordenes_abastecimiento_detalle", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@numero", _oab_codigo))

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

    Public Function ACTUALIZA_CANTIDADES_UBICACIONES_PALLET(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_actualiza_cantidad_en_pallet", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@palletPK", SqlDbType.NVarChar)
            command.Parameters.Add("@pallet", SqlDbType.NVarChar)
            command.Parameters.Add("@cantidad", SqlDbType.Int)
            command.Parameters.Add("@codUbicacionPK", SqlDbType.NVarChar)
            command.Parameters.Add("@codUbicacionAB", SqlDbType.NVarChar)

            command.Parameters(0).Value = _dab_pallet_pk
            command.Parameters(1).Value = _dab_pallet_aba
            command.Parameters(2).Value = _dab_cantidad_aba
            command.Parameters(3).Value = _dab_codigo_ubicacion_pk
            command.Parameters(4).Value = _dab_codigo_ubicacion_aba

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function LIBERA_UBICACION_PROCESO_PICKEO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_actualiza_ubicacion_pallet", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@palletRequerido", SqlDbType.NVarChar)
            command.Parameters.Add("@palletEncontrado", SqlDbType.NVarChar)
            command.Parameters.Add("@ubi_codigoactual", SqlDbType.Int)
            command.Parameters.Add("@ubi_codigopisopt", SqlDbType.Int)
            command.Parameters.Add("@ubi_codigoextraviado", SqlDbType.Int)
            command.Parameters.Add("@ubicacion_vacia", SqlDbType.Bit)

            command.Parameters(0).Value = _palletRequerido
            command.Parameters(1).Value = _palletEncontrado
            command.Parameters(2).Value = _ubi_codigoactual
            command.Parameters(3).Value = _ubi_codigopisopt
            command.Parameters(4).Value = _ubi_codigoextraviado
            command.Parameters(5).Value = _ubicacion_vacia

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
