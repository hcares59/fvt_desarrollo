Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_ingreso_tipo_devoluciones
    Private _cnn As String
    Private _tdv_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Private Sub frm_ingreso_tipo_devoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _tdv_codigo > 0 Then
            Call CARGA_REGISTRO()
        Else
            Call INICIALIZA()
        End If
    End Sub

    Private Sub INICIALIZA()
        txtNombre.Text = ""
        chkDisponibiliza.Checked = False
        _tdv_codigo = 0
        txtNombre.Focus()
        chkActivo.Checked = True
        chk_finalizaEmbarque.Checked = False
    End Sub

    Private Sub CARGA_REGISTRO()
        Dim class_tipo_devolucion As class_tipodevoluciones = New class_tipodevoluciones
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_tipo_devolucion.cnn = _cnn
            class_tipo_devolucion.tdv_codigo = _tdv_codigo

            _msg = ""
            ds = class_tipo_devolucion.tipo_devolucion_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("tdv_codigo") > 0 Then
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("tdv_nombre")
                        chkDisponibiliza.Checked = ds.Tables(0).Rows(Fila)("tdv_pendientepk")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("tdv_activo")

                        chk_paraDocumentos.Checked = ds.Tables(0).Rows(Fila)("tdv_documento")
                        chk_paraPicking.Checked = ds.Tables(0).Rows(Fila)("tdv_picking")

                        chk_finalizaEmbarque.Checked = ds.Tables(0).Rows(Fila)("tdv_fin_embarque")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If valida_form() = False Then
            Exit Sub
        End If
        chkActivo.Focus()
        Call GUARDA_REGISTRO()
    End Sub
    Private Sub GUARDA_REGISTRO()
        Dim class_tipo_devoluciones As class_tipodevoluciones = New class_tipodevoluciones
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
                class_tipo_devoluciones.tdv_codigo = _tdv_codigo
                class_tipo_devoluciones.tdv_nombre = txtNombre.Text
                class_tipo_devoluciones.tdv_pendientepk = chkDisponibiliza.Checked
                class_tipo_devoluciones.tdv_activo = chkActivo.Checked
                class_tipo_devoluciones.tdv_para_documento = chk_paraDocumentos.Checked
                class_tipo_devoluciones.tdv_para_picking = chk_paraPicking.Checked
                class_tipo_devoluciones.tdv_finaliza_embarque = chk_finalizaEmbarque.Checked
                ds = class_tipo_devoluciones.tipo_devolucion_guarda_registro(_msgError, conexion)
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
                        _tdv_codigo = ds.Tables(0).Rows(0)("codigo")
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
                    Call INICIALIZA()
                Else
                    Me.Dispose()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function valida_form()
        valida_form = False
        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre del tipo de devolución, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Function
        End If

        valida_form = True

    End Function

    Private Sub chk_paraPicking_CheckedChanged(sender As Object, e As EventArgs) Handles chk_paraPicking.CheckedChanged
        If chk_paraPicking.Checked Then
            chkDisponibiliza.Enabled = False
            chkDisponibiliza.Checked = False
        Else
            chkDisponibiliza.Enabled = True
            chkDisponibiliza.Checked = False
        End If
    End Sub
End Class