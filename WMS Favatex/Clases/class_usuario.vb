Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_usuario
    Private _cnn As String
    Private _usu_codigo As Integer
    Private _usu_login As String
    Private _usu_contrasena As String
    Private _usu_nombre As String
    Private _uso_activo As Boolean
    Private _usu_asignapicking As Boolean
    Private _usu_finalizapicking As Boolean
    Private _usu_enviaafacturarpicking As Boolean
    Private _usu_enviaadespacharpicking As Boolean
    Private _usu_despachapicking As Boolean
    Private _todos As Boolean
    Private _usu_rut As String
    Private _es_comercial As Boolean
    Private _es_diseno As Boolean
    Private _es_chofer As Boolean
    Private _usu_desplegarinicio As Boolean
    Private _es_bodega As Boolean
    Private _es_asiganpararecepcion As Boolean
    Private _es_ejecutarecepcion As Boolean
    Private _uca_codigo As Integer

    Public Property uca_codigo() As Integer
        Get
            Return _uca_codigo
        End Get
        Set(ByVal value As Integer)
            _uca_codigo = value
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
    Public Property usu_codigo() As Integer
        Get
            Return _usu_codigo
        End Get
        Set(ByVal value As Integer)
            _usu_codigo = value
        End Set
    End Property
    Public Property usu_login() As String
        Get
            Return _usu_login
        End Get
        Set(ByVal value As String)
            _usu_login = value
        End Set
    End Property
    Public Property usu_contrasena() As String
        Get
            Return _usu_contrasena
        End Get
        Set(ByVal value As String)
            _usu_contrasena = value
        End Set
    End Property
    Public Property usu_nombre() As String
        Get
            Return _usu_nombre
        End Get
        Set(ByVal value As String)
            _usu_nombre = value
        End Set
    End Property
    Public Property uso_activo() As Boolean
        Get
            Return _uso_activo
        End Get
        Set(ByVal value As Boolean)
            _uso_activo = value
        End Set
    End Property
    Public Property usu_asignapicking() As Boolean
        Get
            Return _usu_asignapicking
        End Get
        Set(ByVal value As Boolean)
            _usu_asignapicking = value
        End Set
    End Property
    Public Property usu_finalizapicking() As Boolean
        Get
            Return _usu_finalizapicking
        End Get
        Set(ByVal value As Boolean)
            _usu_finalizapicking = value
        End Set
    End Property
    Public Property usu_enviaafacturarpicking() As Boolean
        Get
            Return _usu_enviaafacturarpicking
        End Get
        Set(ByVal value As Boolean)
            _usu_enviaafacturarpicking = value
        End Set
    End Property
    Public Property usu_enviaadespacharpicking() As Boolean
        Get
            Return _usu_enviaadespacharpicking
        End Get
        Set(ByVal value As Boolean)
            _usu_enviaadespacharpicking = value
        End Set
    End Property
    Public Property usu_despachapicking() As Boolean
        Get
            Return _usu_despachapicking
        End Get
        Set(ByVal value As Boolean)
            _usu_despachapicking = value
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
    Public Property usu_rut() As String
        Get
            Return _usu_rut
        End Get
        Set(ByVal value As String)
            _usu_rut = value
        End Set
    End Property
    Public Property es_comercial() As Boolean
        Get
            Return _es_comercial
        End Get
        Set(ByVal value As Boolean)
            _es_comercial = value
        End Set
    End Property
    Public Property es_diseno() As Boolean
        Get
            Return _es_diseno
        End Get
        Set(ByVal value As Boolean)
            _es_diseno = value
        End Set
    End Property
    Public Property es_chofer() As Boolean
        Get
            Return _es_chofer
        End Get
        Set(ByVal value As Boolean)
            _es_chofer = value
        End Set
    End Property
    Public Property usu_desplegarinicio() As Boolean
        Get
            Return _usu_desplegarinicio
        End Get
        Set(ByVal value As Boolean)
            _usu_desplegarinicio = value
        End Set
    End Property
    Public Property es_bodega() As Boolean
        Get
            Return _es_bodega
        End Get
        Set(ByVal value As Boolean)
            _es_bodega = value
        End Set
    End Property
    Public Property es_asiganpararecepcion() As Boolean
        Get
            Return _es_asiganpararecepcion
        End Get
        Set(ByVal value As Boolean)
            _es_asiganpararecepcion = value
        End Set
    End Property
    Public Property es_ejecutarecepcion() As Boolean
        Get
            Return _es_ejecutarecepcion
        End Get
        Set(ByVal value As Boolean)
            _es_ejecutarecepcion = value
        End Set
    End Property

    Public Function CARGA_DATOS_USUARIO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_usuario_busca", conexion)

            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _usu_codigo

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
    Public Function CARGA_COMBO_USUARIO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_usuarios_carga_combo", conexion)

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
    Public Function USUARIO_BUSCA_PERSONA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_persona_por_usuario", conexion)

            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _usu_codigo

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

    Public Function USUARIO_BUSCA_PERSONA_NEW(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_persona_por_usuario_new", conexion)

            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@usu_contrasena", SqlDbType.NVarChar)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _usu_contrasena

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

    Public Function USUARIO_BUSCA_ACCIONES(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_usuario_acciones3", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters(0).Value = _usu_codigo

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

    Public Function USUARIO_LISTADO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_usuario_listado", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@todos", SqlDbType.Bit)
            command.Parameters(0).Value = _usu_codigo
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
    Public Function USUARIO_GUARDA_DATOS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_usuario_guarda", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@usu_contrasena", SqlDbType.NVarChar)
            command.Parameters.Add("@usu_nombre", SqlDbType.NVarChar)
            command.Parameters.Add("@uso_activo", SqlDbType.Bit)
            command.Parameters.Add("@usu_asignapicking", SqlDbType.Bit)
            command.Parameters.Add("@usu_finalizapicking", SqlDbType.Bit)
            command.Parameters.Add("@usu_enviaafacturarpicking", SqlDbType.Bit)
            command.Parameters.Add("@usu_enviaadespacharpicking", SqlDbType.Bit)
            command.Parameters.Add("@usu_rut", SqlDbType.NVarChar)
            command.Parameters.Add("@es_comercial", SqlDbType.Bit)
            command.Parameters.Add("@es_diseno", SqlDbType.Bit)
            command.Parameters.Add("@es_chofer", SqlDbType.Bit)
            command.Parameters.Add("@usu_desplegarinicio", SqlDbType.Bit)
            command.Parameters.Add("@es_bodega", SqlDbType.Bit)
            command.Parameters.Add("@es_asiganpararecepcion", SqlDbType.Bit)
            command.Parameters.Add("@es_ejecutarecepcion", SqlDbType.Bit)
            command.Parameters.Add("@uca_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _usu_contrasena
            command.Parameters(2).Value = _usu_nombre
            command.Parameters(3).Value = _uso_activo
            command.Parameters(4).Value = _usu_asignapicking
            command.Parameters(5).Value = _usu_finalizapicking
            command.Parameters(6).Value = _usu_enviaafacturarpicking
            command.Parameters(7).Value = _usu_enviaadespacharpicking
            command.Parameters(8).Value = _usu_rut
            command.Parameters(9).Value = _es_comercial
            command.Parameters(10).Value = _es_diseno
            command.Parameters(11).Value = _es_chofer
            command.Parameters(12).Value = _usu_desplegarinicio
            command.Parameters(13).Value = _es_bodega
            command.Parameters(14).Value = _es_asiganpararecepcion
            command.Parameters(15).Value = _es_ejecutarecepcion
            command.Parameters(16).Value = _uca_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function USUARIO_ACTUALIZA_PASS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        Try
            Dim command As New SqlCommand("sp_cambia_contrasena_usuario", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@usu_contrasena", SqlDbType.NVarChar)

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _usu_contrasena

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet

            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ELIMINA_REGISTRO(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("sp_usuario_eliminar", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)


            command.Parameters(0).Value = _usu_codigo

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
    Public Function USUARIO_CARGA_DATOS_X_RUT(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_usuario_obtiene_datos_x_rut", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@usu_rut", SqlDbType.NVarChar)
            command.Parameters(0).Value = _usu_rut

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

    Public Function CARGA_COMBO_CHOFER(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_chofer_carga_combo", conexion)
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

    Public Function CARGA_COMBO_PERSONA_BODEGA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_persona_bodega_carga_combo", conexion)
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

    Public Function CARGA_COMBO_PERSONA_BODEGA_RECEPCION(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_persona_bodega_recepcion_carga_combo", conexion)
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


    Public Function CARGA_COMBO_EJECUTA_RECEPCION(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_usuarios_ejecutan_recepcion_carga_combo", conexion)
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


    Public Function CARGA_COMBO_EJECUTA_ALMACENAMIENTO(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_usuarios_ejecutan_almacenamiento_carga_combo", conexion)
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

    Public Function CARGA_COMBO_MODULOS(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_modulos_carga_combo", conexion)

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

    Public Function USUARIO_BUSCA_MODULO(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu$busca_modulo", conexion)

            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.Parameters(0).Value = _usu_codigo

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

    Public Function CARGA_COMBO_CARGOS(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_cargos_carga_combo", conexion)

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

    Public Function CARGA_OPERARIOS_BODEGA(ByRef Msg As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("sp_usuarios_carga_operario_bodega", conexion)

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
