Public Class frm_consulta_vv
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_consulta_vv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        lblTotRegistro.Text = "Registros encontrados: 0"
        Me.Grilla.Columns(4).Frozen = True
        Call CARGA_COMBO_CLIENTE()
        Call FormateaColumnas()

        'Call CARGA_GRILLA()
    End Sub
    Private Sub FormateaColumnas()
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
        Grilla.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
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
    Private Sub CARGA_GRILLA()
        Dim class_orden_compra As class_orden_compra = New class_orden_compra
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
            class_orden_compra.cnn = _cnn

            If cmbCliente.Text = "" Then
                class_orden_compra.car_codigo = 0
            Else
                class_orden_compra.car_codigo = cmbCliente.SelectedValue
            End If

            If chkCompromiso.Checked = True Then

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
                class_orden_compra.fecha_despacho_desde = CStr(dtpCompromisoDesde.Value.Year) + mesCompromisoDesde + diaCompromisoDesde

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

                class_orden_compra.fecha_despacho_hasta = CStr(dtpCompromisoHasta.Value.Year) + mesCompromisoHasta + diaCompromisoHasta
            Else
                class_orden_compra.fecha_despacho_desde = "19000101"
                class_orden_compra.fecha_despacho_hasta = "20501231"
            End If


            lblTotRegistro.Text = "Registros encontrados: 0"
            _msg = ""
            Grilla.Rows.Clear()
            ds = class_orden_compra.CARGA_GRILLA_VISOR_OC(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("con_skucliente") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("rut_cliente"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("car_direccion"),
                                            ds.Tables(0).Rows(Fila)("con_comunareceptor"),
                                            ds.Tables(0).Rows(Fila)("con_emailcliente"),
                                            ds.Tables(0).Rows(Fila)("con_telefonocliente"),
                                            ds.Tables(0).Rows(Fila)("con_skucliente"),
                                            ds.Tables(0).Rows(Fila)("con_skudescripcion"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("con_fechadespacho"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("nombre_cliente"))


                            Fila = Fila + 1
                        Loop
                        Call FormateaColumnas()
                        lblTotRegistro.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If
                Else
                    lblTotRegistro.Text = "Registros encontrados: 0"
                End If
                Me.Text = "CONSUTA DE CLIENTES DE VENTA EN VERDE - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call CARGA_GRILLA()
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
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

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class