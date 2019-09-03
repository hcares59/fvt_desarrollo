Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_visor_facturacion_guias
    Private _cnn As String
    Dim _colum As Integer = 0
    Dim _fila As Integer = 0
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_visor_facturacion_guias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_01;User ID=sa;Password=S1st3m4s"
        '_cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_03;User ID=sa;Password=S1st3m4s"
        Me.WindowState = FormWindowState.Maximized
        Call CARGA_COMBO_CLIENTE()
        cmbCliente.SelectedValue = 2
        Call CARGA_GRILLA()
    End Sub

    Private Sub CARGA_COMBO_CLIENTE()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE_DESPACHA_CON_GUIA(_msg)
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
        Dim classPicking As class_picking = New class_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Dim mesIngresoDesde As String = ""
        Dim diaIngresoDesde As String = ""
        Dim mesIngresoHasta As String = ""
        Dim diaIngresoHasta As String = ""
        Dim mesCompromisoDesde As String = ""
        Dim diaCompromisoDesde As String = ""
        Dim mesCompromisoHasta As String = ""
        Dim diaCompromisoHasta As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classPicking.cnn = _cnn

            If cmbCliente.Text = "" Then
                classPicking.car_codigo = 0
            Else
                classPicking.car_codigo = cmbCliente.SelectedValue
            End If

            If chkCompromiso.Checked = True Then
                'fecha compromiso desde
                If CStr(dtpCompromisoDesde.Value.Month).Length = 1 Then
                    mesCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Month))
                Else
                    mesCompromisoDesde = CStr(dtpCompromisoDesde.Value.Month)
                End If

                If CStr(dtpCompromisoDesde.Value.Day).Length = 1 Then
                    diaCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Day))
                Else
                    diaCompromisoDesde = CStr(dtpCompromisoDesde.Value.Day)
                End If

                classPicking.fecha_entrega_desde = CStr(dtpCompromisoDesde.Value.Year) + mesCompromisoDesde + diaCompromisoDesde

                'fecha ingreso hasta
                If CStr(dtpCompromisoHasta.Value.Month).Length = 1 Then
                    mesCompromisoHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Month))
                Else
                    mesCompromisoHasta = CStr(dtpCompromisoHasta.Value.Month)
                End If

                If CStr(dtpCompromisoHasta.Value.Day).Length = 1 Then
                    diaCompromisoHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Day))
                Else
                    diaCompromisoHasta = CStr(dtpCompromisoHasta.Value.Day)
                End If

                classPicking.fecha_entrega_hasta = CStr(dtpCompromisoHasta.Value.Year) + mesCompromisoHasta + diaCompromisoHasta
            Else
                classPicking.fecha_entrega_desde = "19000101"
                classPicking.fecha_entrega_hasta = "20501231"
            End If

            classPicking.usu_codigo = GLO_USUARIO_ACTUAL
            lblTotRegistro.Text = "Registros encontrados: 0"
            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.PICKING_LISTADO_VISOR_FACTURACION_DESDE_GUIA(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False, ds.Tables(0).Rows(Fila)("gde_numero"),
                                            ds.Tables(0).Rows(Fila)("gde_fecha"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("epc_codigo"),
                                            ds.Tables(0).Rows(Fila)("epc_nombre"),
                                            ds.Tables(0).Rows(Fila)("cant_unidades"),
                                            0,
                                            ds.Tables(0).Rows(Fila)("cant_embarcado"))

                            If ds.Tables(0).Rows(Fila)("cant_embarcado") = 0 Then
                                Grilla.RowsDefaultCellStyle.BackColor = Color.Khaki
                                Grilla.RowsDefaultCellStyle.ForeColor = Color.Black
                                'row.DefaultCellStyle.BackColor = Color.Khaki
                                'row.DefaultCellStyle.ForeColor = Color.Black
                            End If

                            Fila = Fila + 1
                        Loop
                        'Call PINTA_GRILLA()
                        lblTotRegistro.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "GUIAS PENDIENTES DE FACTURAR - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 8 Then
                If Grilla.Rows(e.RowIndex).Cells(9).Value = 0 Then
                    MessageBox.Show("La guia seleccionada no cuenta con un embarque asociado, por ende no es posible registrar la factura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim frm As frm_facturacion_por_guia = New frm_facturacion_por_guia
                frm.cnn = _cnn
                frm.gde_numero = Grilla.Rows(e.RowIndex).Cells(1).Value
                frm.car_codigo = Grilla.Rows(e.RowIndex).Cells(3).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Call CARGA_GRILLA()
    End Sub
    Private Sub PINTA_GRILLA()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(15).Value = 0 Then
                row.DefaultCellStyle.BackColor = Color.Khaki
                row.DefaultCellStyle.ForeColor = Color.Black
            End If

        Next
    End Sub

    Private Sub chkCompromiso_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompromiso.CheckedChanged
        If chkCompromiso.Checked = True Then
            dtpCompromisoDesde.Enabled = True
            dtpCompromisoHasta.Enabled = True
        Else
            dtpCompromisoDesde.Enabled = False
            dtpCompromisoHasta.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim respuesta As Integer

        respuesta = MessageBox.Show("¿Esta seguro(a) de devolver la(s) guia(s) seleccionada(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = vbNo Then
            Exit Sub
        End If

        Call DEVUELVE_GUIA()
        Call CARGA_GRILLA()
    End Sub

    Private Sub DEVUELVE_GUIA()
        Dim classGuia As class_guia = New class_guia
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
                        classGuia.car_codigo = cmbCliente.SelectedValue
                        classGuia.gde_fila = 0 'row2.Cells(4).Value
                        classGuia.gde_numero = row2.Cells(1).Value

                        ds = classGuia.DEVUELVE_GUIAS_A_POR_RENDIR(_msgError, conexion)
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
                MessageBox.Show("Las guias fueron devuelta en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAnula_Click(sender As Object, e As EventArgs) Handles btnAnula.Click
        Dim respuesta As Integer

        respuesta = MessageBox.Show("¿Esta seguro(a) de anular la(s) guia(s) seleccionada(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = vbNo Then
            Exit Sub
        End If

        Call ANULA_GUIA()
        Call CARGA_GRILLA()
    End Sub

    Private Sub ANULA_GUIA()
        Dim classGuia As class_guia = New class_guia
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
                        classGuia.car_codigo = cmbCliente.SelectedValue
                        classGuia.gde_numero = row2.Cells(1).Value

                        ds = classGuia.ANULA_GUIA_DESPACHO(_msgError, conexion)
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
                MessageBox.Show("Las guias fueron anuladas en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class