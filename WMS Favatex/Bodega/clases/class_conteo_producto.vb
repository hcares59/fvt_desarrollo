Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_conteo_producto
    Private _cnn As String
    Private _pro_codigointerno As String
    Private _bod_codigo As Integer
    Private _tub_codigo As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Public Property bod_codigo() As Integer
        Get
            Return _bod_codigo
        End Get
        Set(ByVal value As Integer)
            _bod_codigo = value
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

    Public Function CONTEO_PRODUCTOS(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_conteo_productos", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@pro_codigointerno", SqlDbType.NVarChar)
            command.Parameters.Add("@bod_codigo", SqlDbType.Int)
            command.Parameters.Add("@tub_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _pro_codigointerno
            command.Parameters(1).Value = _bod_codigo
            command.Parameters(2).Value = _tub_codigo

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
