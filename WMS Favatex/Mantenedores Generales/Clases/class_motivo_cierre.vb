Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_motivo_cierre
    Private _cnn As String
    Private _mci_codigo As Integer
    Private _mci_nombre As String
    Private _mci_activo As Boolean
    Private _todos As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property mci_codigo() As Integer
        Get
            Return _mci_codigo
        End Get
        Set(ByVal value As Integer)
            _mci_codigo = value
        End Set
    End Property
    Public Property mci_nombre() As String
        Get
            Return _mci_nombre
        End Get
        Set(ByVal value As String)
            _mci_nombre = value
        End Set
    End Property
    Public Property mci_activo() As Boolean
        Get
            Return _mci_activo
        End Get
        Set(ByVal value As Boolean)
            _mci_activo = value
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

    Public Function CARGA_COMBO_MOTIVO_CIERRE(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_motivo_cierre_carga_combo", conexion)

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

    Public Function MOTIVO_CIERRE_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_motivo_cierre_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@mci_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)

            command.Parameters(0).Value = _mci_codigo
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

    Public Function MOTIVO_CIERRE_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_motivo_cierre_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@mci_codigo", SqlDbType.Int)
            command.Parameters.Add("@mci_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@mci_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _mci_codigo
            command.Parameters(1).Value = _mci_nombre
            command.Parameters(2).Value = _mci_activo

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

    Public Function MOTIVO_CIERRE_ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_motivo_cierre_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@mci_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _mci_codigo
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
