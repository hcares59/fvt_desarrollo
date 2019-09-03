Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class frm_visor_modificacion_guias
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
    Private Sub frm_visor_modificacion_guias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
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
    Private Sub carga_grilla()
        Dim classPicking As class_picking = New class_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Dim mesFacturacionDesde As String = ""
        Dim diafacturacionDesde As String = ""
        Dim mesFacturacionHasta As String = ""
        Dim diaFacturacionHasta As String = ""

        Dim mesDespachoDesde As String = ""
        Dim diaDespachoDesde As String = ""
        Dim mesDespachoHasta As String = ""
        Dim diaDespachoHasta As String = ""

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

            If chkGuia.Checked = True Then
                'fecha compromiso desde
                If CStr(dtpFacturacionDesde.Value.Month).Length = 1 Then
                    mesFacturacionDesde = Trim("0" + CStr(dtpFacturacionDesde.Value.Month))
                Else
                    mesFacturacionDesde = CStr(dtpFacturacionDesde.Value.Month)
                End If

                If CStr(dtpFacturacionDesde.Value.Day).Length = 1 Then
                    diafacturacionDesde = Trim("0" + CStr(dtpFacturacionDesde.Value.Day))
                Else
                    diafacturacionDesde = CStr(dtpFacturacionDesde.Value.Day)
                End If

                classPicking.fecha_guias_desde = CStr(dtpFacturacionDesde.Value.Year) + mesFacturacionDesde + diafacturacionDesde


                If CStr(dtpFacturacionHasta.Value.Month).Length = 1 Then
                    mesFacturacionHasta = Trim("0" + CStr(dtpFacturacionHasta.Value.Month))
                Else
                    mesFacturacionHasta = CStr(dtpFacturacionHasta.Value.Month)
                End If

                If CStr(dtpFacturacionHasta.Value.Day).Length = 1 Then
                    diaFacturacionHasta = Trim("0" + CStr(dtpFacturacionHasta.Value.Day))
                Else
                    diaFacturacionHasta = CStr(dtpFacturacionHasta.Value.Day)
                End If

                classPicking.fecha_guias_hasta = CStr(dtpFacturacionHasta.Value.Year) + mesFacturacionHasta + diaFacturacionHasta
            Else
                classPicking.fecha_guias_desde = "19000101"
                classPicking.fecha_guias_hasta = "20501231"
            End If


            If chkDespacho.Checked = True Then
                'fecha compromiso desde
                If CStr(dtpDespachoDesde.Value.Month).Length = 1 Then
                    mesDespachoDesde = Trim("0" + CStr(dtpDespachoDesde.Value.Month))
                Else
                    mesDespachoDesde = CStr(dtpDespachoDesde.Value.Month)
                End If

                If CStr(dtpDespachoDesde.Value.Day).Length = 1 Then
                    diaDespachoDesde = Trim("0" + CStr(dtpDespachoDesde.Value.Day))
                Else
                    diaDespachoDesde = CStr(dtpDespachoDesde.Value.Day)
                End If

                classPicking.fecha_entrega_desde = CStr(dtpDespachoDesde.Value.Year) + mesDespachoDesde + diaDespachoHasta

                'fecha ingreso hasta
                If CStr(dtpDespachoHasta.Value.Month).Length = 1 Then
                    mesDespachoHasta = Trim("0" + CStr(dtpDespachoHasta.Value.Month))
                Else
                    mesDespachoHasta = CStr(dtpDespachoHasta.Value.Month)
                End If

                If CStr(dtpDespachoHasta.Value.Day).Length = 1 Then
                    diaDespachoHasta = Trim("0" + CStr(dtpDespachoHasta.Value.Day))
                Else
                    diaDespachoHasta = CStr(dtpDespachoHasta.Value.Day)
                End If

                classPicking.fecha_entrega_hasta = CStr(dtpDespachoHasta.Value.Year) + mesDespachoHasta + diaDespachoHasta
            Else
                classPicking.fecha_entrega_desde = "19000101"
                classPicking.fecha_entrega_hasta = "20501231"
            End If
            classPicking.pic_codigo = IIf(txt_numero_picking.Text = "", 0, txt_numero_picking.Text)
            classPicking.gde_numero = IIf(txt_numero_guia.Text = "", 0, txt_numero_guia.Text)
            lblTotRegistro.Text = "Registros encontrados: 0"
            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.picking_modificacion_guias_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            ds.Tables(0).Rows(Fila)("pic_fila"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("gde_numero"),
                                            ds.Tables(0).Rows(Fila)("gde_fecha"),
                                            ds.Tables(0).Rows(Fila)("fecha_compromiso"),
                                            ds.Tables(0).Rows(Fila)("epc_codigo"),
                                            ds.Tables(0).Rows(Fila)("epc_nombre")
                                            )
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

                        lblTotRegistro.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "PICKING MODIFICACION DE GUIAS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 10 Then
                Dim frm As frm_mant_guia = New frm_mant_guia
                frm.cnn = _cnn
                frm.pic_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.pic_fila = Grilla.Rows(e.RowIndex).Cells(3).Value
                frm.nombreProducto = Grilla.Rows(e.RowIndex).Cells(4).Value

                frm.numGuia = Grilla.Rows(e.RowIndex).Cells(5).Value
                frm.fechaGuia = Grilla.Rows(e.RowIndex).Cells(6).Value
                frm.ShowDialog()
                Call carga_grilla()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call carga_grilla()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub txt_numero_picking_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_numero_picking.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Dispose()
    End Sub

    Private Sub txt_numero_guia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_numero_guia.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub chkGuia_CheckedChanged(sender As Object, e As EventArgs) Handles chkGuia.CheckedChanged
        If chkGuia.Checked = True Then
            dtpFacturacionDesde.Enabled = True
            dtpFacturacionHasta.Enabled = True
        Else
            dtpFacturacionDesde.Enabled = False
            dtpFacturacionHasta.Enabled = False
        End If
    End Sub

    Private Sub chkDespacho_CheckedChanged(sender As Object, e As EventArgs) Handles chkDespacho.CheckedChanged
        If chkDespacho.Checked = True Then
            dtpDespachoDesde.Enabled = True
            dtpDespachoHasta.Enabled = True
        Else
            dtpDespachoDesde.Enabled = False
            dtpDespachoHasta.Enabled = False
        End If
    End Sub
End Class