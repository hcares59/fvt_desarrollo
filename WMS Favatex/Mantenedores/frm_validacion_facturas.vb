Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_validacion_facturas
    Private _cnn As String
    Dim columna As Integer = 0
    Dim fila As Integer = 0
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_validacion_facturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        lblTotal.Text = ""
        Call CARGA_COMBO_CLIENTE()
    End Sub

    Private Sub CARGA_COMBO_CLIENTE()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            'ds = classCliente.CARGA_COMBO_CLIENTE_DESPACHA_CON_FACTURA(_msg)
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

    Private Sub CARGA_GRILLA()
        Dim classFactura As class_factura_picking = New class_factura_picking
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classFactura.cnn = _cnn

            If cmbCliente.Text = "" Then
                MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbCliente.Focus()
                Exit Sub
            Else
                classFactura.car_codigo = cmbCliente.SelectedValue
            End If

            If txtNumFactura.Text = "" Or txtNumFactura.Text = "0" Then
                classFactura.fac_numero = 0
            Else
                classFactura.fac_numero = CLng(txtNumFactura.Text)
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = classFactura.REVISION_FACTURAS_RENDIDAS(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("fac_numero") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False,
                                            ds.Tables(0).Rows(Fila)("fac_numero"),
                                            ds.Tables(0).Rows(Fila)("fac_fecha"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("fac_monto"), 0),
                                            ds.Tables(0).Rows(Fila)("fac_linea"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "VALIDACIÓN DE FACTURAS RENDIDAS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub btnRendir_Click(sender As Object, e As EventArgs) Handles btnRendir.Click
        Dim respuesta As Integer = 0

        If DETALLES_MARCADAS() = False Then
            MessageBox.Show("No existen registros seleccionados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        respuesta = MessageBox.Show("¿Esta seguro(a) de enviar a cobrar las facturas seleccionadas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = vbNo Then
            Exit Sub
        End If

        Call ENVIO_A_COBRAR()
        Call CARGA_GRILLA()
    End Sub

    Private Sub ENVIO_A_COBRAR()
        Dim classFactura As class_factura_picking = New class_factura_picking
        Dim ds As DataSet = New DataSet

        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim Fila As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                'nuevo
                '----------------------
                For Each row2 As DataGridViewRow In Me.Grilla.Rows
                    If row2.Cells(0).Value = True Then
                        ds = Nothing
                        classFactura.car_codigo = cmbCliente.SelectedValue
                        classFactura.fac_linea = row2.Cells(4).Value
                        classFactura.fac_numero = row2.Cells(1).Value

                        ds = classFactura.MARCA_FACTURAS_ENVIADAS_A_COBRAR(_msgError, conexion)
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
                '----------------------
                '----------------------
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Las facturas fueron enviadas a cobrar en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function DETALLES_MARCADAS() As Boolean
        Dim Contador As Integer = 0
        Try
            DETALLES_MARCADAS = False

            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    Contador = Contador + 1
                End If
            Next

            If Contador > 0 Then
                DETALLES_MARCADAS = True
            End If

        Catch ex As Exception
            DETALLES_MARCADAS = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0

        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                                + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            class_comunes.ExportarExcel(Me.Grilla)
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonSelecciona_Click(sender As Object, e As EventArgs) Handles ButtonSelecciona.Click
        Call MARCAR_TODOS()
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

    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub ButtonDev_Click(sender As Object, e As EventArgs) Handles ButtonDev.Click
        Dim respuesta As Integer

        respuesta = MessageBox.Show("¿Esta seguro(a) de devolver la(s) factura(s) seleccionada(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = vbNo Then
            Exit Sub
        End If

        Call DEVUELVE_FACTURA()
        Call CARGA_GRILLA()
    End Sub

    Private Sub DEVUELVE_FACTURA()
        Dim classFactura As class_factura_picking = New class_factura_picking
        Dim ds As DataSet = New DataSet

        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim Fila As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                'nuevo
                '----------------------
                For Each row2 As DataGridViewRow In Me.Grilla.Rows
                    If row2.Cells(0).Value = True Then
                        ds = Nothing
                        classFactura.car_codigo = cmbCliente.SelectedValue
                        classFactura.fac_linea = row2.Cells(4).Value
                        classFactura.fac_numero = row2.Cells(1).Value

                        ds = classFactura.DEVUELVE_FACTURAS_A_POR_RENDIR(_msgError, conexion)
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
                '----------------------
                '----------------------
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Las facturas fueron devuelta en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA_DETALLE()
    End Sub

    Private Sub CARGA_GRILLA_DETALLE()
        Dim class_facturas_firmadas As class_factura_picking = New class_factura_picking
        Dim mesIngresoDesde As String = ""
        Dim diaIngresoDesde As String = ""

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

        class_facturas_firmadas.fecha_inicio = CStr(dtpIngresoDesde.Value.Year) + mesIngresoDesde + diaIngresoDesde

        If txtFactura.Text = "0" Or txtFactura.Text = "" Then
            class_facturas_firmadas.fac_numero = 0
        Else
            class_facturas_firmadas.fac_numero = txtFactura.Text
        End If

        class_facturas_firmadas.sinFecha = chkSinFecha.Checked

        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_facturas_firmadas.cnn = _cnn


            _msg = ""
            GrillaDetalle.Rows.Clear()
            ds = class_facturas_firmadas.FACTURAS_REVISADAS_LISTADO(_msg)
            If _msg = "" Then

                lblTotal.Text = "Cantidad de registros encontrados: 0"
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("fac_numero") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(ds.Tables(0).Rows(Fila)("fac_numero"),
                                            ds.Tables(0).Rows(Fila)("fac_numero"),
                                            ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("fac_fecha"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("fac_neto"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("fac_iva"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("fac_total"), 0),
                                            ds.Tables(0).Rows(Fila)("car_rut"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\carga_registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_registro", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        Try
            Dim mesIngresoDesde As String = ""
            Dim diaIngresoDesde As String = ""

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

            Dim frm As frm_imprimir = New frm_imprimir
            frm.Origen = "RRF"

            frm.strFecha = CStr(dtpIngresoDesde.Value.Year) + mesIngresoDesde + diaIngresoDesde

            If txtFactura.Text = "0" Or txtFactura.Text = "" Then
                frm.facNumero = 0
            Else
                frm.facNumero = txtFactura.Text
            End If

            frm.sinFecha = chkSinFecha.Checked


            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AsociarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsociarToolStripMenuItem.Click
        If Grilla.Rows(fila).Cells(0).Value = True Then
            Dim respuesta As Integer = 0
            Dim frm As frm_ingreso_factura_nota_credito = New frm_ingreso_factura_nota_credito
            frm.cnn = _cnn
            frm.fac_numero = CLng(Grilla.Rows(fila).Cells(1).Value)
            frm.car_codigo = cmbCliente.SelectedValue
            frm.ShowDialog()
            'respuesta = MessageBox.Show("¿Esta seguro(a) de enviar a cobrar las facturas seleccionadas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'If respuesta = vbYes Then
            '    Call ENVIO_A_COBRAR()
            'End If
        Else
            MessageBox.Show("Debe seleccionar un registro para poder asociar una nota de credito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call CARGA_GRILLA()

        'For Each row As DataGridViewRow In Me.Grilla.Rows
        '    If row.Cells(0).Value = True Then
        '        Dim respuesta As Integer = 0
        '        Dim frm As frm_ingreso_factura_nota_credito = New frm_ingreso_factura_nota_credito
        '        frm.cnn = _cnn
        '        frm.fac_numero = Val(row.Cells(1).Value)
        '        frm.car_codigo = cmbCliente.SelectedValue
        '        frm.ShowDialog()
        '        respuesta = MessageBox.Show("¿Esta seguro(a) de enviar a cobrar las facturas seleccionadas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '        If respuesta = vbYes Then
        '            Call ENVIO_A_COBRAR()
        '        End If
        '    End If
        'Next
        'Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        columna = e.ColumnIndex
        fila = e.RowIndex
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class