Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_tablas_genericas
    Private _cnn As String
    Private _tge_codigo As Integer
    Private _mod_codigo As Integer
    Private _tge_nombre As String
    Private _tge_activo As Boolean

    Private _tde_codigo As Integer
    Private _tde_nombre As String
    Private _tde_valor As String
    Private _tde_activo As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property tge_codigo() As Integer
        Get
            Return _tge_codigo
        End Get
        Set(ByVal value As Integer)
            _tge_codigo = value
        End Set
    End Property
    Public Property mod_codigo() As Integer
        Get
            Return _mod_codigo
        End Get
        Set(ByVal value As Integer)
            _mod_codigo = value
        End Set
    End Property
    Public Property tge_nombre() As String
        Get
            Return _tge_nombre
        End Get
        Set(ByVal value As String)
            _tge_nombre = value
        End Set
    End Property
    Public Property tge_activo() As Boolean
        Get
            Return _tge_activo
        End Get
        Set(ByVal value As Boolean)
            _tge_activo = value
        End Set
    End Property
    Public Property tde_codigo() As Integer
        Get
            Return _tde_codigo
        End Get
        Set(ByVal value As Integer)
            _tde_codigo = value
        End Set
    End Property
    Public Property tde_nombre() As String
        Get
            Return _tde_nombre
        End Get
        Set(ByVal value As String)
            _tde_nombre = value
        End Set
    End Property
    Public Property tde_valor() As String
        Get
            Return _tde_valor
        End Get
        Set(ByVal value As String)
            _tde_valor = value
        End Set
    End Property
    Public Property tde_activo() As Boolean
        Get
            Return _tde_activo
        End Get
        Set(ByVal value As Boolean)
            _tde_activo = value
        End Set
    End Property


    Public Function TABLA_GENERICA_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_sis_tablas_genericas_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tge_codigo", SqlDbType.Int)
            command.Parameters.Add("@mod_codigo", SqlDbType.Int)
            command.Parameters.Add("@tge_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@tge_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _tge_codigo
            command.Parameters(1).Value = _mod_codigo
            command.Parameters(2).Value = _tge_nombre
            command.Parameters(3).Value = _tge_activo

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

    Public Function TABLA_GENERICA_DETALLE_GUARDA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_sis_tablas_genericas_detalle_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tde_codigo", SqlDbType.Int)
            command.Parameters.Add("@tge_codigo", SqlDbType.Int)
            command.Parameters.Add("@tde_valor", SqlDbType.NVarChar)
            command.Parameters.Add("@tde_activo", SqlDbType.Bit)

            command.Parameters(0).Value = _tde_codigo
            command.Parameters(1).Value = _tge_codigo
            command.Parameters(2).Value = _tde_valor
            command.Parameters(3).Value = _tde_activo

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


    Public Function TABLA_GENERICA_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_sis_tablas_genericas_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@mod_codigo", SqlDbType.Int)
            command.Parameters.Add("@tge_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _mod_codigo
            command.Parameters(1).Value = _tge_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function TABLA_GENERICA_DETALLES_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_sis_tablas_genericas_detalle_listado", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tge_codigo", SqlDbType.Int)
            command.Parameters.Add("@tde_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _tge_codigo
            command.Parameters(1).Value = _tde_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function TABLA_GENERICA_DETALLE_ELIMINA_REGISTRO(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_sis_tablas_genericas_detalle_elimina", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tde_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tde_codigo

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

    Public Function TABLAS_GENERICAS_CARGA_COMBO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_tabla_generica_detalles_carga_combo", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@tge_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _tge_codigo

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
