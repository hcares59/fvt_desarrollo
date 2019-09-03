Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frm_listado_picking
    Private _cnn As String

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_picking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        lblTotal.Text = "Total de registro: 0"
        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized
        Me.Grilla.Columns(3).Frozen = True
        dtpIngresoDesde.Value = GLO_FECHA_SISTEMA
        dtpIngresoHasta.Value = GLO_FECHA_SISTEMA
        chkCompromiso.Checked = True
        dtpCompromisoDesde.Value = DateAdd("d", -3, GLO_FECHA_SISTEMA)
        dtpCompromisoHasta.Value = DateAdd("d", 3, GLO_FECHA_SISTEMA)

        Call CARGA_COMBO_CLIENTE()
        Call CARGA_COMBO_ESTADO_PICKING()
        Call CARGA_COMBO_TIPO_ENTREGA()

        'GrillaFechas.AutoResizeColumns()
        'If cmbCliente.Text <> "" Then
        '    Call CARGA_GRILLA_FECHAS()
        'End If
    End Sub

    Private Sub CARGA_COMBO_TIPO_ENTREGA()
        Dim _msg As String
        Try
            Dim classTipoPicking As class_tipo_picking = New class_tipo_picking
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classTipoPicking.cnn = _cnn
            classTipoPicking.es_ventaverde = False
            _msg = ""
            ds = classTipoPicking.TIPO_PICKING_CARGA_COMBO_TODOS(_msg)
            If _msg = "" Then
                Me.cmbTipoEntrega.DataSource = ds.Tables(0)
                Me.cmbTipoEntrega.DisplayMember = "MENSAJE"
                Me.cmbTipoEntrega.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_ENTREGA", MsgBoxStyle.Critical, Me.Text)
        End Try
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
    Private Sub CARGA_COMBO_ESTADO_PICKING()
        Dim _msg As String
        Try
            Dim classComun As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classComun.cnn = _cnn
            _msg = ""
            ds = classComun.CRGA_COMBO_ESTADO_PICKING(_msg)
            If _msg = "" Then
                Me.cmbEstaddo.DataSource = ds.Tables(0)
                Me.cmbEstaddo.DisplayMember = "MENSAJE"
                Me.cmbEstaddo.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ESTADO_PICKING", MsgBoxStyle.Critical, Me.Text)
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
        Dim sumaTotalBultos As Long = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            Cursor = System.Windows.Forms.Cursors.WaitCursor

            ds = Nothing
            classPicking.cnn = _cnn

            If cmbCliente.Text = "" Then
                classPicking.car_codigo = 0
            Else
                classPicking.car_codigo = cmbCliente.SelectedValue
            End If

            If cmbEstaddo.Text = "" Then
                classPicking.epc_codigo = 0
            Else
                classPicking.epc_codigo = cmbEstaddo.SelectedValue
            End If

            If cmbTipoEntrega.Text = "" Then
                classPicking.tpi_codigo = 0
            Else
                classPicking.tpi_codigo = cmbTipoEntrega.SelectedValue
            End If

            If chkIngreso.Checked = True Then
                'fecha ingreso desde
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

                classPicking.fecha_ingreso_desde = CStr(dtpIngresoDesde.Value.Year) + mesIngresoDesde + diaIngresoDesde

                'fecha ingreso hasta
                If CStr(dtpIngresoHasta.Value.Month).Length = 1 Then
                    mesIngresoHasta = Trim("0" + CStr(dtpIngresoHasta.Value.Month))
                Else
                    mesIngresoHasta = CStr(dtpIngresoHasta.Value.Month)
                End If

                If CStr(dtpIngresoDesde.Value.Day).Length = 1 Then
                    mesIngresoHasta = Trim("0" + CStr(dtpIngresoHasta.Value.Day))
                Else
                    mesIngresoHasta = CStr(dtpIngresoHasta.Value.Day)
                End If

                classPicking.fecha_ingreso_hasta = CStr(dtpIngresoHasta.Value.Year) + mesIngresoHasta + mesIngresoHasta
            Else
                classPicking.fecha_ingreso_desde = "19000101"
                classPicking.fecha_ingreso_hasta = "20501231"
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

            If chkProOC.Checked = True Then
                If txtOrden.Text = "" Or txtOrden.Text = "0" Then
                    classPicking.pic_ocnumero = 0
                Else
                    classPicking.pic_ocnumero = CLng(txtOrden.Text)
                End If
            Else
                classPicking.pic_ocnumero = 0
            End If

            If txt_numero_picking.Text = "" Then
                classPicking.pic_codigo = 0
            Else
                classPicking.pic_codigo = txt_numero_picking.Text
            End If

            Dim FechaIng As String
            Dim FechaDes As String


            lblTotal.Text = "Total de registro: 0"
            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.PICKING_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            FechaIng = CDate(ds.Tables(0).Rows(Fila)("pic_fecha")).ToString("dd-MM-yyyy")
                            FechaDes = CDate(ds.Tables(0).Rows(Fila)("fecha_compromiso")).ToString("dd-MM-yyyy")

                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            Chr(32) + FechaIng,
                                            Chr(32) + FechaDes,
                                            ds.Tables(0).Rows(Fila)("tpi_nombre"),
                                            ds.Tables(0).Rows(Fila)("pic_hora"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("epc_codigo"),
                                            ds.Tables(0).Rows(Fila)("epc_nombre"),
                                            ds.Tables(0).Rows(Fila)("situacion_embarque"),
                                            ds.Tables(0).Rows(Fila)("pic_cantidad"),
                                            ds.Tables(0).Rows(Fila)("pic_cantidad_encontrada"),
                                            ds.Tables(0).Rows(Fila)("pic_cantidad_despachada"),
                                            ds.Tables(0).Rows(Fila)("pic_cantidad_embarca"))
                            'sumaTotalBultos = sumaTotalBultos + ds.Tables(0).Rows(Fila)("total_bultos")

                            If ds.Tables(0).Rows(Fila)("pic_esta_eliminada") > 0 Then
                                Grilla.Item(10, Fila).Style.BackColor = Color.FromArgb(246, 181, 97)
                            End If

                            Fila = Fila + 1
                        Loop

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
                        Grilla.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        'Grilla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


                        'txtTotalBultos.Text = sumaTotalBultos
                    End If
                End If
                Me.Text = "LISTADO DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
                lblTotal.Text = "Total de registro: " + ds.Tables(0).Rows.Count.ToString
                Cursor = System.Windows.Forms.Cursors.Default
            Else
                Cursor = System.Windows.Forms.Cursors.Default
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Cursor = System.Windows.Forms.Cursors.Default
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'cmbCliente.SelectedValue = 0
        'cmbEstaddo.SelectedValue = 0
        'chkIngreso.Checked = False
        'chkCompromiso.Checked = False
        Call CARGA_GRILLA()
        Call carga_gilla_detalle_picking()
    End Sub

    Private Sub carga_gilla_detalle_picking()
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
        Dim sumaTotalBultos As Long = 0

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

            If cmbEstaddo.Text = "" Then
                classPicking.epc_codigo = 0
            Else
                classPicking.epc_codigo = cmbEstaddo.SelectedValue
            End If

            If cmbTipoEntrega.Text = "" Then
                classPicking.tpi_codigo = 0
            Else
                classPicking.tpi_codigo = cmbTipoEntrega.SelectedValue
            End If
            If txt_numero_picking.Text = "" Then
                classPicking.pic_codigo = 0
            Else
                classPicking.pic_codigo = txt_numero_picking.Text
            End If
            If chkIngreso.Checked = True Then
                'fecha ingreso desde
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

                classPicking.fecha_ingreso_desde = CStr(dtpIngresoDesde.Value.Year) + mesIngresoDesde + diaIngresoDesde

                'fecha ingreso hasta
                If CStr(dtpIngresoHasta.Value.Month).Length = 1 Then
                    mesIngresoHasta = Trim("0" + CStr(dtpIngresoHasta.Value.Month))
                Else
                    mesIngresoHasta = CStr(dtpIngresoHasta.Value.Month)
                End If

                If CStr(dtpIngresoDesde.Value.Day).Length = 1 Then
                    diaIngresoHasta = Trim("0" + CStr(dtpIngresoHasta.Value.Day))
                Else
                    diaIngresoHasta = CStr(dtpIngresoHasta.Value.Day)
                End If

                classPicking.fecha_ingreso_hasta = CStr(dtpIngresoHasta.Value.Year) + mesIngresoHasta + diaIngresoHasta
            Else
                classPicking.fecha_ingreso_desde = "19000101"
                classPicking.fecha_ingreso_hasta = "20501231"
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

            If chkProOC.Checked = True Then
                If txtOrden.Text = "" Or txtOrden.Text = "0" Then
                    classPicking.pic_ocnumero = 0
                Else
                    classPicking.pic_ocnumero = CLng(txtOrden.Text)
                End If
            Else
                classPicking.pic_ocnumero = 0
            End If
            ' lblTotal.Text = "Total de registro: 0"
            _msg = ""
            grilla_detallada.Rows.Clear()
            ds = classPicking.picking_detalle_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grilla_detallada.Rows.Add(ds.Tables(0).Rows(Fila)("pic_codigo"),
                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                            ds.Tables(0).Rows(Fila)("pic_fecha"),
                            ds.Tables(0).Rows(Fila)("fecha_compromiso"),
                            ds.Tables(0).Rows(Fila)("car_nombre"),
                            ds.Tables(0).Rows(Fila)("tpi_nombre"),
                            ds.Tables(0).Rows(Fila)("epc_nombre"),
                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                            ds.Tables(0).Rows(Fila)("disponible"),
                            ds.Tables(0).Rows(Fila)("cantidad"),
                            ds.Tables(0).Rows(Fila)("pic_num_bultos"),
                            ds.Tables(0).Rows(Fila)("total_bulto"),
                            ds.Tables(0).Rows(Fila)("pro_codigooriginal"),
                            ds.Tables(0).Rows(Fila)("pro_codigoactual"),
                            ds.Tables(0).Rows(Fila)("existentes"),
                            ds.Tables(0).Rows(Fila)("observacion"),
                            ds.Tables(0).Rows(Fila)("pro_nombreoriginal"),
                            ds.Tables(0).Rows(Fila)("pro_numerobultosoriginal"),
                            ds.Tables(0).Rows(Fila)("precio"),
                            ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                            ds.Tables(0).Rows(Fila)("pic_fechaoc"),
                            ds.Tables(0).Rows(Fila)("con_codigounico"),
                            ds.Tables(0).Rows(Fila)("pic_filadevuelta"))
                            sumaTotalBultos = sumaTotalBultos + ds.Tables(0).Rows(Fila)("total_bulto")
                            Fila = Fila + 1
                        Loop
                        txtTotalBultos.Text = sumaTotalBultos
                    End If
                End If
                Me.Text = "LISTADO DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
                ' lblTotal.Text = "Total de registro: " + ds.Tables(0).Rows.Count.ToString
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub chkIngreso_CheckedChanged(sender As Object, e As EventArgs)
        If chkIngreso.Checked = True Then
            dtpIngresoDesde.Enabled = True
            dtpIngresoHasta.Enabled = True
        Else
            dtpIngresoDesde.Enabled = False
            dtpIngresoHasta.Enabled = False
        End If
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 15 Then
                Dim frm As frm_mant_picking = New frm_mant_picking
                frm.cnn = _cnn
                frm.pic_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.HabilitarBtn = False
                frm.ShowDialog()
                'Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 16 Then
                Dim frm As frm_imprimir = New frm_imprimir
                frm.Origen = "PK"
                frm.pic_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Dispose()
    End Sub

    Private Sub chkIngreso_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkIngreso.CheckedChanged
        If chkIngreso.Checked = True Then
            dtpIngresoDesde.Enabled = True
            dtpIngresoHasta.Enabled = True
        Else
            dtpIngresoDesde.Enabled = False
            dtpIngresoHasta.Enabled = False
        End If
    End Sub

    Private Sub chkProOC_CheckedChanged(sender As Object, e As EventArgs) Handles chkProOC.CheckedChanged
        If chkProOC.Checked = True Then
            txtOrden.Enabled = True
        Else
            txtOrden.Enabled = False
            txtOrden.Text = "0"
        End If
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

    Private Sub ButtonExportar_Click(sender As Object, e As EventArgs) Handles ButtonExportar.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0

        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                               + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            respuesta = MessageBox.Show("¿Desea exportar listado de picking con detalle?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbYes Then

                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call ExportarDatosExcel(grilla_detallada, "LISTADO DETALLADO PICKING")
                Cursor = System.Windows.Forms.Cursors.Default
            Else
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call ExportarDatosExcel(Grilla, "LISTADO PICKING")
                'class_comunes.ExportarExcel(Me.Grilla)
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            .Range("A1:L1").Merge()
            .Range("A1:L1").Value = "COMERCIAL FAVATEX"
            .Range("A1:L1").Font.Bold = True
            .Range("A1:L1").Font.Size = 15
            'Copete  
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = titulo
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12

            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With

        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        If Grilla.RowCount > 0 Then
            If GLO_BUSQUEDA_PICKING_DESDE = "IE" Then
                GLO_NUMERO_PICKING = Grilla.Rows(e.RowIndex).Cells(0).Value
                Me.Dispose()
            End If
        End If
    End Sub
End Class