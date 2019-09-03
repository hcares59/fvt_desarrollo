Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_etiqueta
    Private _cnn As String
    Private _strCadena As String
    Private _pic_codigo As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Public Property pic_codigo() As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
        End Set
    End Property


    Public Function TIPO_ETIQUETA_CARGA_COMBO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_tipo_etiqueta_carga_combo", conexion)

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

    Public Function BULTO_ETIQUETA_CARGA_COMBO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_carga_combo_numero_bultos", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@strCadena", SqlDbType.NVarChar)
            command.Parameters.Add("@intPicking", SqlDbType.Int)

            command.Parameters(0).Value = _strCadena
            command.Parameters(1).Value = _pic_codigo

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
