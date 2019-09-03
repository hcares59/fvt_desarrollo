Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_pallet
    Private _cnn As String
    Private _pal_cod_interno As String
    Private _pal_descripcion As String
    Private _pal_precio As Long
    Private _pal_activo As Integer
    Private _todos As Boolean

    Public Property pal_precio() As Long
        Get
            Return _pal_precio
        End Get
        Set(ByVal value As Long)
            _pal_precio = value
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
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property pal_cod_interno() As String
        Get
            Return _pal_cod_interno
        End Get
        Set(ByVal value As String)
            _pal_cod_interno = value
        End Set
    End Property

    Public Property pal_activo() As Integer
        Get
            Return _pal_activo
        End Get
        Set(ByVal value As Integer)
            _pal_activo = value
        End Set
    End Property
    Public Property pal_descripcion() As String
        Get
            Return _pal_descripcion
        End Get
        Set(ByVal value As String)
            _pal_descripcion = value
        End Set
    End Property

    Public Function pallet_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_pallet_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@pal_cod_int", SqlDbType.NVarChar)
            command.Parameters.Add("@todos", SqlDbType.Bit)
            command.Parameters(0).Value = _pal_cod_interno
            command.Parameters(1).Value = _todos

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
    Public Function pallet_guarda_registro(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_pallets_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pal_cod_int", SqlDbType.NVarChar)
            command.Parameters.Add("@pal_descripcion", SqlDbType.NVarChar)
            command.Parameters.Add("@pal_precio", SqlDbType.Float)
            command.Parameters.Add("@pal_activo", SqlDbType.Int)

            command.Parameters(0).Value = _pal_cod_interno
            command.Parameters(1).Value = _pal_descripcion
            command.Parameters(2).Value = _pal_precio
            command.Parameters(3).Value = _pal_activo


            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function pallet_elimina_resgistro(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_pallet_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pal_cod_int", SqlDbType.NVarChar)


            command.Parameters(0).Value = _pal_cod_interno

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
