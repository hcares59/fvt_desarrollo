Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading
Public Class frm_homologacion_productos
    Private _cnn As String

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub btn_carga_Click(sender As Object, e As EventArgs) Handles btn_carga.Click
        If cmbCliente.Text = "" Then
            MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Call importarExcel(Grilla, _cnn, cmbCliente.SelectedValue)
    End Sub

    Private Sub frm_homologacion_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call carga_combo_clientes()
        Call ConfiguraTamanos()
    End Sub

    Private Sub ConfiguraTamanos()
        Grilla.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub carga_combo_clientes()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
            If _msg = "" Then
                Me.cmbCliente.DataSource = ds.Tables(0)
                Me.cmbCliente.DisplayMember = "MENSAJE"
                Me.cmbCliente.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_combo_cliientes", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If

        If Grilla.Rows(e.RowIndex).Cells(2).Value = 0 Or Grilla.Rows(e.RowIndex).Cells(7).Value > 0 Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = False
        Else
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = chkCell.Value
        End If

        If e.ColumnIndex = Me.Grilla.Columns.Item(1).Index Then
            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
        End If

    End Sub

    Private Sub btnMarcar_Click(sender As Object, e As EventArgs) Handles btnMarcar.Click
        Call marcar_todos()
    End Sub

    Private Sub marcar_todos()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            If (row.Cells(2).Value > 0) And (row.Cells(7).Value = 0) Then
                row.Cells(0).Value = True
            End If
        Next
    End Sub

    Private Function valida_marcados() As Integer
        Dim contador As Integer = 0
        valida_marcados = 0

        Try
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If (row.Cells(0).Value = True) Then
                    contador = contador + 1
                End If
            Next
            valida_marcados = contador
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub desmarcar_todos()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub btnDesmarcar_Click(sender As Object, e As EventArgs) Handles btnDesmarcar.Click
        Call desmarcar_todos()
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If valida_marcados() = 0 Then
            MessageBox.Show("Para poder homologar los codigos debe selecciónar a lo menos una fila", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call GUARDA_HOMOLOGACION()

    End Sub

    Private Sub GUARDA_HOMOLOGACION()
        Dim classCartera As class_cartera = New class_cartera
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0
        Dim muestraMensaje As Boolean = False
        Dim ds As DataSet

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If (row.Cells(0).Value = True) Then
                        classCartera.car_codigo = cmbCliente.SelectedValue
                        classCartera.pro_codigo = row.Cells(2).Value
                        classCartera.sku_cartera = row.Cells(5).Value
                        classCartera.sku_carnomb = row.Cells(6).Value
                        classCartera.sku_tipo = 1
                        classCartera.pro_precioventa = 0
                        classCartera.pro_preciovtapub = 0
                        classCartera.sku_activo = True

                        ds = classCartera.CARTERA_PRODUCTO_GUARDA_REGISTRO(_msgError, conexion)
                        If _msgError <> "" Then
                            ds = Nothing
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Sub
                            End If
                        End If
                    End If
                Next

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                Me.Cursor = Cursors.Default
                MessageBox.Show("Los datos fueron homologados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Grilla.Rows.Clear()
                cmbCliente.SelectedValue = 0

            End Using
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class