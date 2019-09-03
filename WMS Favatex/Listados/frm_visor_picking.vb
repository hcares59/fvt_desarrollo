Public Class frm_visor_picking
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_visor_picking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Grilla.Columns(4).Frozen = True
        Call CARGA_COMBO_CLIENTE()
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
            ds = classPicking.PICKING_LISTADO_VISOR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            ds.Tables(0).Rows(Fila)("pic_fecha"),
                                            ds.Tables(0).Rows(Fila)("fecha_compromiso"),
                                            ds.Tables(0).Rows(Fila)("pic_hora"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("epc_codigo"),
                                            ds.Tables(0).Rows(Fila)("epc_nombre"),
                                            ds.Tables(0).Rows(Fila)("cant_unidades"),
                                            ds.Tables(0).Rows(Fila)("cant_bultos"),
                                            ds.Tables(0).Rows(Fila)("total_bultos"),
                                            ds.Tables(0).Rows(Fila)("despachar"),
                                            "",
                                            "",
                                            "",
                                            ds.Tables(0).Rows(Fila)("cantidad_encontrada"))
                            Fila = Fila + 1
                        Loop
                        lblTotRegistro.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                        Call RECORRE_GRILLA_PARA_MARCAR()
                    End If
                End If
                Me.Text = "VISOR DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub RECORRE_GRILLA_PARA_MARCAR()
        Dim Fila As Integer = 0

        Do While Fila < Grilla.Rows.Count
            If Grilla.Rows(Fila).Cells(0).Value = 11576 Then
                Fila = Fila
            End If

            Call PINTA_CELDA_FILA_PK(Fila, Grilla.Rows(Fila).Cells(7).Value, Grilla.Rows(Fila).Cells(9).Value, Grilla.Rows(Fila).Cells(16).Value)
            Fila = Fila + 1
        Loop
    End Sub

    Private Sub PINTA_CELDA_FILA_PK(ByVal fila As Integer, ByVal codEstado As Integer, ByVal cantRequerida As Integer, ByVal cantEncontrada As Integer)
        Dim columna As Integer = 0
        If codEstado = ESTADOS_PICKING.Generado Then
            Do While columna <= Grilla.ColumnCount - 1
                Grilla.Item(columna, fila).Style.BackColor = Color.PeachPuff
                Grilla.Item(columna, fila).Style.ForeColor = Color.Brown
                columna = columna + 1
            Loop
            columna = columna + 1
        ElseIf codEstado = ESTADOS_PICKING.En_proceso Then
            columna = 0
            Do While columna <= Grilla.ColumnCount - 1
                If cantRequerida = cantEncontrada Then
                    Grilla.Item(columna, fila).Style.BackColor = Color.Beige
                    Grilla.Item(columna, fila).Style.ForeColor = Color.Black
                Else
                    Grilla.Item(columna, fila).Style.BackColor = Color.AntiqueWhite
                    Grilla.Item(columna, fila).Style.ForeColor = Color.Black
                End If
                columna = columna + 1
            Loop
        ElseIf (codEstado = ESTADOS_PICKING.Finalizado_con_diferenia) Or (codEstado = ESTADOS_PICKING.Finalizado_sin_diferencia) Then
            columna = 0
            Do While columna <= Grilla.ColumnCount - 1
                Grilla.Item(columna, fila).Style.BackColor = Color.Honeydew
                Grilla.Item(columna, fila).Style.ForeColor = Color.MediumSeaGreen
                columna = columna + 1
            Loop
            columna = columna + 1
        End If




    End Sub


    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 13 Then
                Dim frm As frm_mant_picking = New frm_mant_picking
                frm.cnn = _cnn
                frm.pic_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 14 Then
                Dim frm As frm_imprimir = New frm_imprimir
                frm.Origen = "PK"
                frm.pic_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()

            ElseIf e.ColumnIndex = 15 Then
                Dim frm As frm_factura_ordenes = New frm_factura_ordenes
                frm.cnn = _cnn
                frm.pic_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_COMBO_CLIENTE()
                Call CARGA_GRILLA()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call CARGA_GRILLA()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)

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
End Class