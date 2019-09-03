Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_tabla_generica_detalle
    Private _cnn As String
    Private _tge_codigo As Integer
    Private _tge_nombre As String
    Private _tde_codigo As Integer
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
    Public Property tge_nombre() As String
        Get
            Return _tge_nombre
        End Get
        Set(ByVal value As String)
            _tge_nombre = value
        End Set
    End Property

    Private Sub frm_ingreso_tabla_generica_detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombreTabla.Text = _tge_nombre
        Call CARGA_GRILLA()
    End Sub

    Private Sub LIMPIAR()
        _tde_codigo = 0
        txtNombreCampo.Text = ""
        chkActivo.Checked = True
        Call CARGA_GRILLA()
    End Sub
    Private Sub CARGA_GRILLA()
        Dim class_tabla_genberica As class_tablas_genericas = New class_tablas_genericas
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_tabla_genberica.cnn = _cnn
            class_tabla_genberica.tge_codigo = _tge_codigo
            class_tabla_genberica.tde_codigo = 0

            _msg = ""

            Grilla.Rows.Clear()
            ds = class_tabla_genberica.TABLA_GENERICA_DETALLES_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("tge_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("tde_codigo"),
                                            ds.Tables(0).Rows(Fila)("tde_valor"),
                                            ds.Tables(0).Rows(Fila)("tde_activo"))
                            Fila = Fila + 1
                        Loop

                    End If
                    lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                End If
                Me.Text = "LISTADO DE TABLAS GENERICAS DETALLES - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call LIMPIAR()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA_FORM() = False Then
            Exit Sub
        End If
        Call GUARDA_REGISTRO()
    End Sub

    Private Sub GUARDA_REGISTRO()
        Dim class_tabla_generica As class_tablas_genericas = New class_tablas_genericas
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                class_tabla_generica.tde_codigo = _tde_codigo
                class_tabla_generica.tge_codigo = _tge_codigo
                class_tabla_generica.tde_valor = txtNombreCampo.Text
                class_tabla_generica.tde_activo = chkActivo.Checked

                ds = class_tabla_generica.TABLA_GENERICA_DETALLE_GUARDA_REGISTRO(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("codigo") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        _tde_codigo = ds.Tables(0).Rows(0)("codigo")
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                respuesta = MessageBox.Show("Los datos fueron guardados en forma correcta" _
                                + Chr(10) + "¿Desea ingresar otro registro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbYes Then
                    Call LIMPIAR()
                Else
                    Me.Dispose()
                End If
                conexion.Close()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function VALIDA_FORM()
        VALIDA_FORM = False

        If Trim(txtNombreCampo.Text) = "" Then
            MessageBox.Show("Debe ingresar dato del valor, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombreCampo.Focus()
            Exit Function
        End If

        VALIDA_FORM = True

    End Function

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 3 Then
                _tde_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                txtNombreCampo.Text = Grilla.Rows(e.RowIndex).Cells(1).Value
                chkActivo.Checked = Grilla.Rows(e.RowIndex).Cells(2).Value
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim respuesta As Integer

        If _tde_codigo = 0 Then
            MessageBox.Show("Debe seleccionar un valor para poder eliminarlo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        respuesta = MessageBox.Show("Esta seguro(a) de eliminar el valor seleccionado", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = vbYes Then
            Call ELIMINA_REGISTRO()
        End If



    End Sub

    Private Sub ELIMINA_REGISTRO()
        Dim class_tabla_generica As class_tablas_genericas = New class_tablas_genericas
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                class_tabla_generica.tde_codigo = _tde_codigo
                ds = class_tabla_generica.TABLA_GENERICA_DETALLE_ELIMINA_REGISTRO(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("codigo") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                MessageBox.Show("El valor fue eliminado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call LIMPIAR()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class