Imports System.Data.SqlClient
Imports System.Data
Imports System.Transactions
Imports System
Imports System.Configuration
Imports System.Linq
Public Class frm_asigna_privilegios
    Private _cnn As String
    Private _cargaPrimeraVez As Boolean = False

    Dim dataSetArbol As System.Data.DataSet
    Dim node As System.Windows.Forms.TreeNode

    Dim dtTree As DataTable = New DataTable
    Dim dtTree2 As DataTable = New DataTable

    Dim NodeRightClick As String

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_asigna_privilegios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _cargaPrimeraVez = False
        Call INICIALIZA_FORMULARIO()

        _cargaPrimeraVez = True
    End Sub

    Private Sub INICIALIZA_FORMULARIO()
        TreeMenu.Nodes.Clear()
        TreeMenu2.Nodes.Clear()

        FillTestTable()
        FillTestTableSuperior()

        CreateTree()
        CreateTreeSuperior()

        TreeMenu.ExpandAll()
        TreeMenu2.ExpandAll()

        Call CARGA_COMBO_USUARIO()
    End Sub

    Private Sub CARGA_COMBO_USUARIO()
        Dim _msg As String
        Try
            Dim classUsuario As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUsuario.cnn = _cnn
            _msg = ""
            ds = classUsuario.CARGA_COMBO_USUARIO(_msg)
            If _msg = "" Then
                Me.cmbUsuario.DataSource = ds.Tables(0)
                Me.cmbUsuario.DisplayMember = "MENSAJE"
                Me.cmbUsuario.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_USUARIO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub FillTestTable()
        Dim class_menu As class_menu = New class_menu
        Dim Msg As String = ""

        Dim i As Integer
        Try
            class_menu.cnn = _cnn
            dtTree = class_menu.MENU_SELECCIONA_TODOS(Msg)

            If dtTree.Rows(i).Item("men_nombre").ToString = "" Then
                Exit Sub
            End If

            For i = 0 To dtTree.Rows.Count - 1
                Dim ID1 As String = dtTree.Rows(i).Item("men_codigo").ToString
                dtTree.Rows(i).Item("LEVEL") = FindLevel(ID1, 0)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillTestTableSuperior()
        Dim class_menu As class_menu = New class_menu
        Dim Msg As String = ""

        Dim i As Integer
        Try
            class_menu.cnn = _cnn
            dtTree2 = class_menu.MENU_SELECCIONA_TODOS_BARRA(Msg)

            If dtTree2.Rows(i).Item("men_nombre").ToString = "" Then
                Exit Sub
            End If

            For i = 0 To dtTree2.Rows.Count - 1
                Dim ID1 As String = dtTree2.Rows(i).Item("men_codigo").ToString
                dtTree2.Rows(i).Item("LEVEL") = FindLevelSuperior(ID1, 0)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function FindLevel(ByVal ID As String, ByRef Level As Integer) As Integer
        Dim i As Integer

        For i = 0 To dtTree.Rows.Count - 1
            Dim ID1 As String = dtTree.Rows(i).Item("men_codigo").ToString
            Dim Parent1 As String = dtTree.Rows(i).Item("men_codigopadre").ToString

            If ID = ID1 Then
                If Parent1 = "" Then
                    Return Level
                Else
                    Level += 1
                    FindLevel(Parent1, Level)
                End If
            End If
        Next
        Return Level
    End Function
    Private Function FindLevelSuperior(ByVal ID As String, ByRef Level As Integer) As Integer
        Dim i As Integer

        For i = 0 To dtTree2.Rows.Count - 1
            Dim ID1 As String = dtTree2.Rows(i).Item("men_codigo").ToString
            Dim Parent1 As String = dtTree2.Rows(i).Item("men_codigopadre").ToString

            If ID = ID1 Then
                If Parent1 = "" Then
                    Return Level
                Else
                    Level += 1
                    FindLevelSuperior(Parent1, Level)
                End If
            End If
        Next
        Return Level
    End Function

    Private Sub CreateTree()
        Dim MaxLevel1 As Integer = CInt(dtTree.Compute("MAX(LEVEL)", ""))

        Dim i, j As Integer

        For i = 0 To MaxLevel1
            Dim Rows1() As DataRow = dtTree.Select("LEVEL = " & i)

            For j = 0 To Rows1.Count - 1
                Dim ID1 As String = Rows1(j).Item("men_codigo").ToString
                Dim Name1 As String = Rows1(j).Item("men_nombre").ToString
                Dim Parent1 As String = Rows1(j).Item("men_codigopadre").ToString

                If Parent1 = "0" Then
                    TreeMenu.Nodes.Add(ID1, Name1, 0, 0)
                Else
                    Dim TreeNodes1() As TreeNode = TreeMenu.Nodes.Find(Parent1, True)

                    If TreeNodes1.Length > 0 Then
                        TreeNodes1(0).Nodes.Add(ID1, Name1, 1, 1)
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub CreateTreeSuperior()
        Dim MaxLevel1 As Integer = CInt(dtTree2.Compute("MAX(LEVEL)", ""))

        Dim i, j As Integer

        For i = 0 To MaxLevel1
            Dim Rows1() As DataRow = dtTree2.Select("LEVEL = " & i)

            For j = 0 To Rows1.Count - 1
                Dim ID1 As String = Rows1(j).Item("men_codigo").ToString
                Dim Name1 As String = Rows1(j).Item("men_nombre").ToString
                Dim Parent1 As String = Rows1(j).Item("men_codigopadre").ToString

                If Parent1 = "0" Then
                    TreeMenu2.Nodes.Add(ID1, Name1, 0, 0)
                Else
                    Dim TreeNodes1() As TreeNode = TreeMenu2.Nodes.Find(Parent1, True)

                    If TreeNodes1.Length > 0 Then
                        TreeNodes1(0).Nodes.Add(ID1, Name1, 1, 1)
                    End If
                End If
            Next
        Next
    End Sub



    Private Sub TreeMenu_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeMenu.AfterSelect

    End Sub

    Private Sub TreeMenu_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeMenu.AfterCheck
        RemoveHandler TreeMenu.AfterCheck, AddressOf TreeMenu_AfterCheck
        If e.Node.Parent IsNot Nothing Then
            Dim result As Boolean = True
            For Each node As TreeNode In e.Node.Parent.Nodes
                If Not node.Checked Then
                    result = False
                    Exit For
                End If
            Next
            e.Node.Parent.Checked = result
        End If

        If e.Node.Nodes.Count > 0 Then
            For Each node As TreeNode In e.Node.Nodes
                node.Checked = e.Node.Checked
            Next
        End If

        AddHandler TreeMenu.AfterCheck, AddressOf TreeMenu_AfterCheck
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA_DATOS() = False Then
            Exit Sub
        End If

        Call GUARDA_ACCESOS()
        Call GUARDA_ACCESOS_SUPERIOR()

        MessageBox.Show("Los datos fueron ingresados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call INICIALIZA_FORMULARIO()
    End Sub

    Private Function VALIDA_DATOS() As Boolean
        VALIDA_DATOS = False

        If cmbUsuario.Text = "" Then
            MessageBox.Show("Debe seleccionar un usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbUsuario.Focus()
            Exit Function
        End If

        VALIDA_DATOS = True


    End Function

    Private Sub GUARDA_ACCESOS()
        Dim scopeOptions = New TransactionOptions()
        Dim conexion As SqlConnection
        Dim class_menu As class_menu = New class_menu
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim nodes As TreeNodeCollection = TreeMenu.Nodes

        'If VALIDA_DATOS() = False Then
        '    Exit Sub
        'End If
        conexion = New SqlConnection(_cnn)
        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                class_menu.usu_codigo = cmbUsuario.SelectedValue

                If class_menu.ELIMINA_USUARIO_MENUS(_msgError, conexion) = False Then
                    If conexion.State <> ConnectionState.Closed Then
                        conexion.Close()
                    End If
                    conexion.Dispose()
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                For Each n As TreeNode In nodes
                    If RecorrerNodos(n, conexion) = False Then
                        If conexion.State <> ConnectionState.Closed Then
                            conexion.Close()
                        End If
                        conexion.Dispose()
                        Exit Sub
                    End If
                Next

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
                conexion.Dispose()
                'MessageBox.Show("Los datos fueron ingresados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Call INICIALIZA_FORMULARIO()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GUARDA_ACCESOS_SUPERIOR()
        Dim scopeOptions = New TransactionOptions()
        Dim conexion As SqlConnection
        Dim class_menu As class_menu = New class_menu
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim nodes As TreeNodeCollection = TreeMenu2.Nodes

        'If VALIDA_DATOS() = False Then
        '    Exit Sub
        'End If
        conexion = New SqlConnection(_cnn)
        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                class_menu.usu_codigo = cmbUsuario.SelectedValue

                If class_menu.ELIMINA_USUARIO_MENUS_BARRA(_msgError, conexion) = False Then
                    If conexion.State <> ConnectionState.Closed Then
                        conexion.Close()
                    End If
                    conexion.Dispose()
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                For Each n As TreeNode In nodes
                    If RecorrerNodosSuperior(n, conexion) = False Then
                        If conexion.State <> ConnectionState.Closed Then
                            conexion.Close()
                        End If
                        conexion.Dispose()
                        Exit Sub
                    End If
                Next

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
                conexion.Dispose()
                'MessageBox.Show("Los datos fueron ingresados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Call INICIALIZA_FORMULARIO()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function RecorrerNodos(treeNode As TreeNode, ByVal cnn As SqlConnection) As Boolean
        Dim class_menu As class_menu = New class_menu
        Dim ds As DataSet = New DataSet
        Dim _Msg As String = ""
        Try
            RecorrerNodos = False
            For Each tn As TreeNode In treeNode.Nodes
                If tn.Checked = True Then
                    class_menu.usu_codigo = cmbUsuario.SelectedValue
                    class_menu.men_codigo = tn.Name
                    ds = class_menu.INGRESA_USUARIOS_MENUS(_Msg, cnn)
                    If _Msg = "" Then
                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                            Exit Function
                        End If
                    Else
                        MessageBox.Show(_Msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Function
                    End If
                End If
                RecorrerNodos(tn, cnn)
            Next
            RecorrerNodos = True
        Catch ex As Exception
            RecorrerNodos = False
            MessageBox.Show(ex.ToString())
        End Try
    End Function
    Private Function RecorrerNodosSuperior(treeNode As TreeNode, ByVal cnn As SqlConnection) As Boolean
        Dim class_menu As class_menu = New class_menu
        Dim ds As DataSet = New DataSet
        Dim _Msg As String = ""
        Try
            RecorrerNodosSuperior = False
            For Each tn As TreeNode In treeNode.Nodes
                If tn.Checked = True Then
                    class_menu.usu_codigo = cmbUsuario.SelectedValue
                    class_menu.mba_codigo = tn.Name
                    ds = class_menu.INGRESA_USUARIOS_MENUS_BARRA(_Msg, cnn)
                    If _Msg = "" Then
                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                            Exit Function
                        End If
                    Else
                        MessageBox.Show(_Msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Function
                    End If
                End If
                RecorrerNodos(tn, cnn)
            Next
            RecorrerNodosSuperior = True
        Catch ex As Exception
            RecorrerNodosSuperior = False
            MessageBox.Show(ex.ToString())
        End Try
    End Function
    Private Sub MARCA_MENUS_USUARIO()
        Dim class_menu As class_menu = New class_menu
        Dim _msg As String = ""
        Dim ds As DataSet
        Dim Fila As Integer
        Dim nodes As TreeNodeCollection = TreeMenu.Nodes
        For Each n As TreeNode In nodes
            DesmarcaMenu(n)
        Next

        class_menu.cnn = _cnn
        class_menu.usu_codigo = cmbUsuario.SelectedValue

        ds = class_menu.CONSULTA_USUARIOS_MENUS(_msg)
        If _msg = "" Then
            Try
                If ds.Tables(0).Rows.Count > 0 Then
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("men_codigo") > 0 Then
                            'Dim nodes As TreeNodeCollection = TreeMenu.Nodes
                            For Each n As TreeNode In nodes
                                MarcaMenu(n, ds.Tables(0).Rows(Fila)("men_codigo"))
                            Next
                        End If
                        Fila = Fila + 1
                    Loop

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message + "\MARCA_MENUS_USUARIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show(_msg + "\MARCA_MENUS_USUARIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub MARCA_MENUS_USUARIO_BARRA()
        Dim class_menu As class_menu = New class_menu
        Dim _msg As String = ""
        Dim ds As DataSet
        Dim Fila As Integer
        Dim nodes As TreeNodeCollection = TreeMenu2.Nodes
        For Each n As TreeNode In nodes
            DesmarcaMenu(n)
        Next

        class_menu.cnn = _cnn
        class_menu.usu_codigo = cmbUsuario.SelectedValue

        ds = class_menu.CONSULTA_USUARIOS_MENUS_BARRA(_msg)
        If _msg = "" Then
            Try
                If ds.Tables(0).Rows.Count > 0 Then
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("men_codigo") > 0 Then
                            'Dim nodes As TreeNodeCollection = TreeMenu.Nodes
                            For Each n As TreeNode In nodes
                                MarcaMenu(n, ds.Tables(0).Rows(Fila)("men_codigo"))
                            Next
                        End If
                        Fila = Fila + 1
                    Loop

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message + "\MARCA_MENUS_USUARIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show(_msg + "\MARCA_MENUS_USUARIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub MarcaMenu(treeNode As TreeNode, ByVal CodMenu As Integer)
        Try
            For Each tn As TreeNode In treeNode.Nodes
                If tn.Name = CodMenu Then
                    tn.Checked = True
                End If
                MarcaMenu(tn, CodMenu)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DesmarcaMenu(treeNode As TreeNode)
        Try
            For Each tn As TreeNode In treeNode.Nodes
                tn.Checked = False
                DesmarcaMenu(tn)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsuario.SelectedIndexChanged

    End Sub

    Private Sub cmbUsuario_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbUsuario.SelectionChangeCommitted
        If _cargaPrimeraVez = True Then
            TreeMenu.Nodes.Clear()
            TreeMenu2.Nodes.Clear()

            FillTestTable()
            FillTestTablesuperior()

            CreateTree()
            CreateTreeSuperior()

            TreeMenu.ExpandAll()
            TreeMenu2.ExpandAll()

            Call MARCA_MENUS_USUARIO()
            Call MARCA_MENUS_USUARIO_BARRA()
        End If
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub TreeMenu2_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeMenu2.AfterSelect

    End Sub

    Private Sub TreeMenu2_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeMenu2.AfterCheck
        RemoveHandler TreeMenu2.AfterCheck, AddressOf TreeMenu2_AfterCheck
        If e.Node.Parent IsNot Nothing Then
            Dim result As Boolean = True
            For Each node As TreeNode In e.Node.Parent.Nodes
                If Not node.Checked Then
                    result = False
                    Exit For
                End If
            Next
            e.Node.Parent.Checked = result
        End If

        If e.Node.Nodes.Count > 0 Then
            For Each node As TreeNode In e.Node.Nodes
                node.Checked = e.Node.Checked
            Next
        End If

        AddHandler TreeMenu2.AfterCheck, AddressOf TreeMenu2_AfterCheck
    End Sub
End Class