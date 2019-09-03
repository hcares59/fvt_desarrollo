Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class class_menu
    Private _cnn As String
    Private _usu_codigo As Integer
    Private _men_codigo As Integer
    Private _mba_codigo As Integer
    Private _mod_codigo As Integer


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
    Public Property men_codigo() As Integer
        Get
            Return _men_codigo
        End Get
        Set(ByVal value As Integer)
            _men_codigo = value
        End Set
    End Property
    Public Property mba_codigo() As Integer
        Get
            Return _mba_codigo
        End Get
        Set(ByVal value As Integer)
            _mba_codigo = value
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


    Public Function USUARIO_BUSCA_MENU(ByRef Msg As String) As DataTable
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu$busca_menu_usuario", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@usu_codigo", _usu_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim dt As New DataTable
            'Dim ds As New DataSet

            conexion.Open()
            da.Fill(dt)

            conexion.Close()
            Return dt
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function USUARIO_BUSCA_MENU_NEW(ByRef Msg As String) As DataTable
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu$busca_menu_usuario_new", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@mod_codigo", _mod_codigo))
            command.Parameters.Add(New SqlParameter("@usu_codigo", _usu_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim dt As New DataTable
            'Dim ds As New DataSet

            conexion.Open()
            da.Fill(dt)

            conexion.Close()
            Return dt
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function USUARIO_BUSCA_MENU_BARRA(ByRef Msg As String) As DataTable
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu_barra$busca_menu_usuario", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@usu_codigo", _usu_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim dt As New DataTable
            'Dim ds As New DataSet

            conexion.Open()
            da.Fill(dt)

            conexion.Close()
            Return dt
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MENU_SELECCIONA_APLICACION(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu$seleciona_aplicacion", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@codMenu", _men_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            conexion.Open()
            da.Fill(ds)
            conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MENU_SELECCIONA_APLICACION_NEW(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu$seleciona_aplicacion_new", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@codMenu", _men_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            conexion.Open()
            da.Fill(ds)
            conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MENU_SELECCIONA_APLICACION_BARRA(ByRef Mensaje As String) As DataSet
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu_barra$seleciona_aplicacion", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@codMenu", _mba_codigo))

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            conexion.Open()
            da.Fill(ds)
            conexion.Close()
            Return ds
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MENU_SELECCIONA_TODOS(ByRef Msg As String) As DataTable
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu$busca_menu", conexion)

            command.CommandType = CommandType.StoredProcedure

            Dim da As New SqlDataAdapter(command)
            Dim dt As New DataTable
            'Dim ds As New DataSet

            conexion.Open()
            da.Fill(dt)

            conexion.Close()
            Return dt
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MENU_SELECCIONA_TODOS_NEW(ByRef Msg As String) As DataTable
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu$busca_menu_new", conexion)
            command.Parameters.Add(New SqlParameter("@mod_codigo", _mod_codigo))

            command.CommandType = CommandType.StoredProcedure

            Dim da As New SqlDataAdapter(command)
            Dim dt As New DataTable
            'Dim ds As New DataSet

            conexion.Open()
            da.Fill(dt)

            conexion.Close()
            Return dt
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function MENU_SELECCIONA_TODOS_BARRA(ByRef Msg As String) As DataTable
        Try
            Dim conexion As New SqlConnection(_cnn)
            Dim command As New SqlCommand("menu_barra$busca_menu", conexion)

            command.CommandType = CommandType.StoredProcedure

            Dim da As New SqlDataAdapter(command)
            Dim dt As New DataTable
            'Dim ds As New DataSet

            conexion.Open()
            da.Fill(dt)

            conexion.Close()
            Return dt
        Catch ex As Exception
            Msg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ELIMINA_USUARIO_MENUS_NEW(ByRef Mensaje As String, ByVal conexion As SqlConnection) As Boolean
        Try
            Dim command As New SqlCommand("EliminaUsuariosMenuNew", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@mod_codigo", SqlDbType.Int)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None
            command.Parameters(0).Value = _mod_codigo
            command.Parameters(1).Value = _usu_codigo

            command.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Mensaje = ex.Message
            Return False
        End Try
    End Function

    Public Function ELIMINA_USUARIO_MENUS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As Boolean
        Try
            Dim command As New SqlCommand("EliminaUsuariosMenu", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None
            command.Parameters(0).Value = _usu_codigo

            command.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Mensaje = ex.Message
            Return False
        End Try
    End Function


    Public Function ELIMINA_USUARIO_MENUS_BARRA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As Boolean
        Try
            Dim command As New SqlCommand("EliminaUsuariosMenuBarra", conexion)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None
            command.Parameters(0).Value = _usu_codigo

            command.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Mensaje = ex.Message
            Return False
        End Try
    End Function

    Public Function INGRESA_USUARIOS_MENUS(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("GuardaUsuariosMenu", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@men_codigo", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = men_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function INGRESA_USUARIOS_MENUS_NEW(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("GuardaUsuariosMenuNew", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@mod_codigo", SqlDbType.Int)
            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@men_codigo", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None

            command.Parameters(0).Value = _mod_codigo
            command.Parameters(1).Value = _usu_codigo
            command.Parameters(2).Value = men_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function INGRESA_USUARIOS_MENUS_BARRA(ByRef Mensaje As String, ByVal conexion As SqlConnection) As DataSet
        'Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("GuardaUsuariosMenuBarra", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.Parameters.Add("@mba_codigo", SqlDbType.Int)

            command.UpdatedRowSource = UpdateRowSource.None

            command.Parameters(0).Value = _usu_codigo
            command.Parameters(1).Value = _mba_codigo

            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CONSULTA_USUARIOS_MENUS(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("ConsultaUsuariosMenus", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.UpdatedRowSource = UpdateRowSource.None
            command.Parameters(0).Value = _usu_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function

    Public Function CONSULTA_USUARIOS_MENUS_NEW(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("ConsultaUsuariosMenusNew", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.UpdatedRowSource = UpdateRowSource.None
            command.Parameters(0).Value = _usu_codigo
            Dim da As New SqlDataAdapter(command)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function


    Public Function CONSULTA_USUARIOS_MENUS_BARRA(ByRef Mensaje As String) As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            Dim command As New SqlCommand("ConsultaUsuariosMenusBarra", conexion)
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@usu_codigo", SqlDbType.Int)
            command.UpdatedRowSource = UpdateRowSource.None
            command.Parameters(0).Value = _usu_codigo
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
