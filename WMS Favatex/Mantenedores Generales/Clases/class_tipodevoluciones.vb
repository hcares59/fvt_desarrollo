Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_tipodevoluciones
    Private _cnn As String
    Private _tdv_codigo As Integer
    Private _tdv_nombre As String
    Private _tdv_pendientepk As Boolean
    Private _tdv_para_documento As Boolean
    Private _tdv_para_picking As Boolean

    Private _tdv_activo As Boolean
    Private _tdv_eliminado As Boolean
    Private _todos As Boolean
    Private _tdv_finaliza_embarque As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Public Property tdv_codigo() As Integer
        Get
            Return _tdv_codigo
        End Get
        Set(ByVal value As Integer)
            _tdv_codigo = value
        End Set
    End Property
    Public Property tdv_nombre() As String
        Get
            Return _tdv_nombre
        End Get
        Set(ByVal value As String)
            _tdv_nombre = value
        End Set
    End Property
    Public Property tdv_para_documento() As Boolean
        Get
            Return _tdv_para_documento
        End Get
        Set(ByVal value As Boolean)
            _tdv_para_documento = value
        End Set
    End Property
    Public Property tdv_para_picking() As Boolean
        Get
            Return _tdv_para_picking
        End Get
        Set(ByVal value As Boolean)
            _tdv_para_picking = value
        End Set
    End Property
    Public Property tdv_pendientepk() As Boolean
        Get
            Return _tdv_pendientepk
        End Get
        Set(ByVal value As Boolean)
            _tdv_pendientepk = value
        End Set
    End Property
    Public Property tdv_activo() As Boolean
        Get
            Return _tdv_activo
        End Get
        Set(ByVal value As Boolean)
            _tdv_activo = value
        End Set
    End Property
    Public Property tdv_eliminado() As Boolean
        Get
            Return _tdv_eliminado
        End Get
        Set(ByVal value As Boolean)
            _tdv_eliminado = value
        End Set
    End Property
    Public Property tdv_finaliza_embarque() As Boolean
        Get
            Return _tdv_finaliza_embarque
        End Get
        Set(ByVal value As Boolean)
            _tdv_finaliza_embarque = value
        End Set
    End Property

    Public Function tipo_devolucion_listado(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_devolucion_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@tdv_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)
            command.Parameters.Add("@documentos", SqlDbType.Int)
            command.Parameters.Add("@picking", SqlDbType.Bit)
            command.Parameters(0).Value = _tdv_codigo
            command.Parameters(1).Value = _todos

            command.Parameters(2).Value = _tdv_para_documento
            command.Parameters(3).Value = _tdv_para_picking

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

    Public Function tipo_devolucion_guarda_registro(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_tipo_devolucion_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tdv_codigo", SqlDbType.Int)
            command.Parameters.Add("@tdv_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@tdv_pendientepk", SqlDbType.Bit)
            command.Parameters.Add("@tdv_activo", SqlDbType.Bit)
            command.Parameters.Add("@tdv_documento", SqlDbType.Bit)
            command.Parameters.Add("@tdv_picking", SqlDbType.Bit)
            command.Parameters.Add("@tdv_finEmbarque", SqlDbType.Bit)

            command.Parameters(0).Value = _tdv_codigo
            command.Parameters(1).Value = _tdv_nombre
            command.Parameters(2).Value = _tdv_pendientepk
            command.Parameters(3).Value = _tdv_activo
            command.Parameters(4).Value = _tdv_para_documento
            command.Parameters(5).Value = _tdv_para_picking
            command.Parameters(6).Value = _tdv_finaliza_embarque

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function tipo_devolucion_elimina(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_tipo_devolucion_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tdv_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tdv_codigo

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
