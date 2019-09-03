Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_certificado_recepcion_conforme
    Private _cnn As String
    Dim cargaPrimeraVez As Boolean
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_certificado_recepcion_conforme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cargaPrimeraVez = False
        Call INICIALIZA()
        Call CARGA_COMBO_CLIENTE()
        cargaPrimeraVez = True
    End Sub
    Private Sub INICIALIZA()
        lblTotal.Text = "Cantidad de registros encontrados: 0"
        dtpIngresoDesde.Value = DateAdd("d", -10, Now)
        dtpIngresoHasta.Value = DateAdd("m", 1, Now)
        'Call carga_grilla()
    End Sub
    Private Sub CARGA_COMBO_CLIENTE()
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
            MsgBox(ex.Message + " " + "CARGA_COMBO_CLIENTE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If cmbCliente.Text = "" Then
            MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Sub
        End If

        Call CARGA_GRILLA()
    End Sub
    Private Sub CARGA_GRILLA()
        Dim class_picking As class_picking = New class_picking
        Dim mesIngresoDesde As String = ""
        Dim diaIngresoDesde As String = ""
        Dim mesIngresoHasta As String = ""
        Dim diaIngresoHasta As String = ""
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_picking.cnn = _cnn
            class_picking.car_codigo = cmbCliente.SelectedValue

            If CStr(dtpIngresoDesde.Value.Month).Length = 1 Then
                mesIngresoDesde = Trim("0" + CStr(dtpIngresoDesde.Value.Month))
            Else
                mesIngresoDesde = CStr(dtpIngresoDesde.Value.Month)
            End If

            If CStr(dtpIngresoDesde.Value.Day).Length = 1 Then
                diaIngresoDesde = Trim("0" + CStr(dtpIngresoDesde.Value.Day))
            Else
                diaIngresoDesde = CStr(dtpIngresoDesde.Value.Day)
            End If

            class_picking.fecha_inicio = CStr(dtpIngresoDesde.Value.Year) + mesIngresoDesde + diaIngresoDesde

            'fecha ingreso hasta
            If CStr(dtpIngresoHasta.Value.Month).Length = 1 Then
                mesIngresoHasta = Trim("0" + CStr(dtpIngresoHasta.Value.Month))
            Else
                mesIngresoHasta = CStr(dtpIngresoHasta.Value.Month)
            End If

            If CStr(dtpIngresoHasta.Value.Day).Length = 1 Then
                diaIngresoHasta = Trim("0" + CStr(dtpIngresoHasta.Value.Day))
            Else
                diaIngresoHasta = CStr(dtpIngresoHasta.Value.Day)
            End If

            class_picking.fecha_termino = CStr(dtpIngresoHasta.Value.Year) + mesIngresoHasta + diaIngresoHasta
            class_picking.todos = chkImpresas.Checked

            _msg = ""
            Grilla.Rows.Clear()
            ds = class_picking.ORDENES_COMPRA_LISTADO(_msg)
            If _msg = "" Then
                lblTotal.Text = "Cantidad de registros encontrados: 0"
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pic_ocnumero") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count

                            Grilla.Rows.Add(False, ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                        ds.Tables(0).Rows(Fila)("pic_fechaoc"),
                                        ds.Tables(0).Rows(Fila)("con_despachara"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        Dim frm As frm_imprimir = New frm_imprimir
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()


        Dim nombreInforme = "rpt_certificado_recepcion_conforme.rpt"
        Dim Seleccionados As String = ""

        If cmbCliente.Text = "" Then
            MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Sub
        End If

        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(0).Value = True Then
                Seleccionados = Seleccionados + CStr(row.Cells(1).Value).ToString + ","
            End If
        Next

        If Seleccionados = "" Then
            MessageBox.Show("Debe seleccionar a lo menos una orden de compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        frm.nombreReporte = nombreInforme
        frm.Origen = "CC"
        frm.car_codigo = cmbCliente.SelectedValue
        frm.strCadena = Seleccionados
        frm.ShowDialog()

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                classPicking.car_codigo = cmbCliente.SelectedValue
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(0).Value = True Then
                        classPicking.pic_ocnumero = row.Cells(1).Value
                        ds = classPicking.MARCA_ORDEN_CERTIFICADO_IMPRESO(_msgError, conexion)
                        If _msgError <> "" Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            ds = Nothing
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Sub
                            End If
                        End If
                    End If
                Next
                Me.Cursor = Cursors.Default
                '----------------------
                '----------------------
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                chkImpresas.Checked = False
                Call CARGA_GRILLA()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub ButtonSelecciona_Click(sender As Object, e As EventArgs) Handles ButtonSelecciona.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub
End Class