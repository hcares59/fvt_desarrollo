Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_citas
    Private _cnn As String
    Private _cit_codigo As Integer
    Private _car_codigo As Integer
    Private _cit_ordencompra As String
    Private _cit_fechaorden As Date
    Private _cit_fecha As Date
    Private _cit_hora As String
    Private _cit_numero As Integer
    Private _eci_codigo As Integer
    Private _fecha_compromiso As String
    Private _hora_inicio As String
    Private _hora_termino As String
    Private _solo_codigo As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Public Property solo_codigo() As Boolean
        Get
            Return _solo_codigo
        End Get
        Set(ByVal value As Boolean)
            _solo_codigo = value
        End Set
    End Property
    Public Property fecha_compromiso() As String
        Get
            Return _fecha_compromiso
        End Get
        Set(ByVal value As String)
            _fecha_compromiso = value
        End Set
    End Property
    Public Property hora_inicio() As String
        Get
            Return _hora_inicio
        End Get
        Set(ByVal value As String)
            _hora_inicio = value
        End Set
    End Property
    Public Property hora_termino() As String
        Get
            Return _hora_termino
        End Get
        Set(ByVal value As String)
            _hora_termino = value
        End Set
    End Property

    Public Property cit_codigo() As Integer
        Get
            Return _cit_codigo
        End Get
        Set(ByVal value As Integer)
            _cit_codigo = value
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
    Public Property cit_ordencompra() As String
        Get
            Return _cit_ordencompra
        End Get
        Set(ByVal value As String)
            _cit_ordencompra = value
        End Set
    End Property
    Public Property cit_fechaorden() As Date
        Get
            Return _cit_fechaorden
        End Get
        Set(ByVal value As Date)
            _cit_fechaorden = value
        End Set
    End Property
    Public Property cit_fecha() As Date
        Get
            Return _cit_fecha
        End Get
        Set(ByVal value As Date)
            _cit_fecha = value
        End Set
    End Property
    Public Property cit_hora() As String
        Get
            Return _cit_hora
        End Get
        Set(ByVal value As String)
            _cit_hora = value
        End Set
    End Property
    Public Property cit_numero() As Integer
        Get
            Return _cit_numero
        End Get
        Set(ByVal value As Integer)
            _cit_numero = value
        End Set
    End Property
    Public Property eci_codigo() As Integer
        Get
            Return _eci_codigo
        End Get
        Set(ByVal value As Integer)
            _eci_codigo = value
        End Set
    End Property

    Public Function CITA_GUARDA_DATOS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_agenda_cita_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cit_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@cit_ordencompra", SqlDbType.NVarChar)
            command.Parameters.Add("@cit_fechaorden", SqlDbType.Date)
            command.Parameters.Add("@cit_fecha", SqlDbType.Date)
            command.Parameters.Add("@cit_hora", SqlDbType.NVarChar)
            command.Parameters.Add("@cit_numero", SqlDbType.Int)
            command.Parameters.Add("@eci_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _cit_codigo
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _cit_ordencompra
            command.Parameters(3).Value = _cit_fechaorden
            command.Parameters(4).Value = _cit_fecha
            command.Parameters(5).Value = _cit_hora
            command.Parameters(6).Value = _cit_numero
            command.Parameters(7).Value = _eci_codigo

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

    Public Function ELIMINA_CITA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_age_citas_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cit_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _cit_codigo
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

    Public Function CITA_CAMBIA_ESTDO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_cambia_estado_age_citas", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cit_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@eci_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _cit_codigo
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _eci_codigo

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

    Public Function CITA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_age_citas_entrega_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@cit_codigo", SqlDbType.Int)
            command.Parameters.Add("@car_codigo", SqlDbType.Int)
            command.Parameters.Add("@fecha_compromiso", SqlDbType.NVarChar)
            command.Parameters.Add("@hora_inicio", SqlDbType.NVarChar)
            command.Parameters.Add("@hora_termino", SqlDbType.NVarChar)
            command.Parameters.Add("@solo_codigo", SqlDbType.Bit)

            command.Parameters(0).Value = _cit_codigo
            command.Parameters(1).Value = _car_codigo
            command.Parameters(2).Value = _fecha_compromiso
            command.Parameters(3).Value = _hora_inicio
            command.Parameters(4).Value = _hora_termino
            command.Parameters(5).Value = _solo_codigo

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

    Public Function OC_POR_FECHA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_fechas_oc_para_citas_lista", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@car_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _car_codigo

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
