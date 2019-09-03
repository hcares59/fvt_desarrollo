Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_vehiculo
    Private _cnn As String
    Private _veh_codigo As Integer
    Private _tve_codigo As Integer
    Private _veh_nombre As String
    Private _veh_patente As String
    Private _veh_capacKilos As Double
    Private _veh_capacpallets As Integer
    Private _veh_capacpaldobleancho As Integer
    Private _veh_activo As Boolean
    Private _veh_eliminado As Boolean
    Private _todos As Boolean
    Private _veh_capacpaldobleancho_sodimac As Integer
    Private _veh_requierecomplemento As Boolean

    Public Property veh_capacpaldobleancho_sodimac() As Integer
        Get
            Return _veh_capacpaldobleancho_sodimac
        End Get
        Set(ByVal value As Integer)
            _veh_capacpaldobleancho_sodimac = value
        End Set
    End Property
    Public Property veh_requierecomplemento() As Boolean
        Get
            Return _veh_requierecomplemento
        End Get
        Set(ByVal value As Boolean)
            _veh_requierecomplemento = value
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
    Public Property veh_codigo() As Integer
        Get
            Return _veh_codigo
        End Get
        Set(ByVal value As Integer)
            _veh_codigo = value
        End Set
    End Property
    Public Property tve_codigo() As Integer
        Get
            Return _tve_codigo
        End Get
        Set(ByVal value As Integer)
            _tve_codigo = value
        End Set
    End Property
    Public Property veh_nombre() As String
        Get
            Return _veh_nombre
        End Get
        Set(ByVal value As String)
            _veh_nombre = value
        End Set
    End Property
    Public Property veh_patente() As String
        Get
            Return _veh_patente
        End Get
        Set(ByVal value As String)
            _veh_patente = value
        End Set
    End Property
    Public Property veh_capacKilos() As Double
        Get
            Return _veh_capacKilos
        End Get
        Set(ByVal value As Double)
            _veh_capacKilos = value
        End Set
    End Property
    Public Property veh_capacpallets() As Integer
        Get
            Return _veh_capacpallets
        End Get
        Set(ByVal value As Integer)
            _veh_capacpallets = value
        End Set
    End Property
    Public Property veh_capacpaldobleancho() As Integer
        Get
            Return _veh_capacpaldobleancho
        End Get
        Set(ByVal value As Integer)
            _veh_capacpaldobleancho = value
        End Set
    End Property
    Public Property veh_activo() As Boolean
        Get
            Return _veh_activo
        End Get
        Set(ByVal value As Boolean)
            _veh_activo = value
        End Set
    End Property
    Public Property veh_eliminado() As Boolean
        Get
            Return _veh_eliminado
        End Get
        Set(ByVal value As Boolean)
            _veh_eliminado = value
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

    Public Function VEHICULO_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_vehiculos_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@veh_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _veh_codigo
            command.Parameters(1).Value = _todos

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function VEHICULO_GUARDA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_vehiculos_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@veh_codigo", SqlDbType.Int)
            command.Parameters.Add("@veh_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@veh_patente", SqlDbType.NVarChar)
            command.Parameters.Add("@veh_capacKilos", SqlDbType.Decimal)
            command.Parameters.Add("@veh_capacpallets", SqlDbType.Int)
            command.Parameters.Add("@tve_codigo", SqlDbType.Int)
            command.Parameters.Add("@veh_capacpaldobleancho", SqlDbType.Int)
            command.Parameters.Add("@veh_capacpaldobleancho_sodimac", SqlDbType.Int)
            command.Parameters.Add("@veh_activo", SqlDbType.Bit)
            command.Parameters.Add("@veh_requierecomplemento", SqlDbType.Bit)

            command.Parameters(0).Value = _veh_codigo
            command.Parameters(1).Value = _veh_nombre
            command.Parameters(2).Value = _veh_patente
            command.Parameters(3).Value = _veh_capacKilos
            command.Parameters(4).Value = _veh_capacpallets
            command.Parameters(5).Value = _tve_codigo
            command.Parameters(6).Value = _veh_capacpaldobleancho
            command.Parameters(7).Value = _veh_capacpaldobleancho_sodimac
            command.Parameters(8).Value = _veh_activo
            command.Parameters(9).Value = _veh_requierecomplemento


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

    Public Function VEHICULO_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_vehiculo_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@veh_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _veh_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CARGA_COMBO_VEHICULO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_vehiculos_combo", conexion)
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

End Class
