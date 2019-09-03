Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_listado_recepciones
    Private _cnn As String

    Const COL_NREC As Integer = 0
    Const COL_CAR_CODIGO As Integer = 1
    Const COL_NOM_PROVEEDOR As Integer = 2
    Const COL_FECHA_RECEP As Integer = 3
    Const COL_NUM_OC As Integer = 4
    Const COL_NUM_FACTURA As Integer = 5
    Const COL_NUM_GUIA As Integer = 6
    Const COL_ESTADO As Integer = 7
    Const COL_MUESTRA As Integer = 8
    Const COL_VALE_TRASPASO As Integer = 9
    Const COL_BTN_VER_MUESTRA As Integer = 10
    Const COL_BTN_VER As Integer = 11
    Const COL_BTN_IMPRIMIR As Integer = 12
    Const COL_BTN_MOV_RECEP As Integer = 13
    Const COL_BTN_ELIMINA As Integer = 14
    Const COL_COD_ESTADO As Integer = 15
    Const COL_COL_CPU As Integer = 16

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_recepciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        Call CARGA_COMBO_PROBVEEDOR()
        Call CARGA_COMBO_ESTADO_RECEPCION()
        lblTotal.Text = "Total de registros: 0"
        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized

        chkFecha.Checked = 0
        dtpFechaOCHasta.Value = GLO_FECHA_SISTEMA
        dtpFechaOCDesde.Value = GLO_FECHA_SISTEMA
        txtFactura.Text = "0"
        txtGuia.Text = "0"
        txtOCompra.Text = "0"

        lblTotal.Text = ""
    End Sub

    Private Sub CARGA_COMBO_ESTADO_RECEPCION()
        Dim _msg As String
        Try
            Dim classRecepcion As class_recepcion = New class_recepcion
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classRecepcion.cnn = _cnn
            _msg = ""
            ds = classRecepcion.CARGA_COMBO_ESTADO_RECEPCION(_msg)
            If _msg = "" Then
                Me.cmbEstado.DataSource = ds.Tables(0)
                Me.cmbEstado.DisplayMember = "MENSAJE"
                Me.cmbEstado.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ESTADO_RECEPCION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_PROBVEEDOR()
        Dim _msg As String
        Try
            Dim classProveedor As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classProveedor.cnn = _cnn
            _msg = ""
            ds = classProveedor.CARGA_COMBO_PROVEEDOR(_msg)
            If _msg = "" Then
                Me.cmbProveedor.DataSource = ds.Tables(0)
                Me.cmbProveedor.DisplayMember = "MENSAJE"
                Me.cmbProveedor.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROBVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        dtpFechaOCDesde.Enabled = chkFecha.Checked
        dtpFechaOCHasta.Enabled = chkFecha.Checked
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Dim diaOCDesde As String = ""
        Dim mesOCDesde As String = ""

        Dim diaOCHasta As String = ""
        Dim mesOCHasta As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classRecepcion.cnn = _cnn

            classRecepcion.rec_numero = 0

            If cmbProveedor.Text = "" Then
                classRecepcion.car_codigo = 0
            Else
                classRecepcion.car_codigo = cmbProveedor.SelectedValue
            End If

            If txtFactura.Text = "0" Or txtFactura.Text = "" Then
                classRecepcion.rec_nfactura = 0
            Else
                classRecepcion.rec_nfactura = CLng(txtFactura.Text)
            End If

            If txtGuia.Text = "0" Or txtGuia.Text = "" Then
                classRecepcion.rec_nguia = 0
            Else
                classRecepcion.rec_nguia = CLng(txtGuia.Text)
            End If

            If txtOCompra.Text = "0" Or txtOCompra.Text = "" Then
                classRecepcion.rec_ordencompra = 0
            Else
                classRecepcion.rec_ordencompra = CLng(txtOCompra.Text)
            End If

            If chkFecha.Checked = True Then
                'desde
                If CStr(dtpFechaOCDesde.Value.Month).Length = 1 Then
                    mesOCDesde = Trim("0" + CStr(dtpFechaOCDesde.Value.Month))
                Else
                    mesOCDesde = CStr(dtpFechaOCDesde.Value.Month)
                End If

                If CStr(dtpFechaOCDesde.Value.Day).Length = 1 Then
                    diaOCDesde = Trim("0" + CStr(dtpFechaOCDesde.Value.Day))
                Else
                    diaOCDesde = CStr(dtpFechaOCDesde.Value.Day)
                End If

                'Hasta
                If CStr(dtpFechaOCHasta.Value.Month).Length = 1 Then
                    mesOCHasta = Trim("0" + CStr(dtpFechaOCHasta.Value.Month))
                Else
                    mesOCHasta = CStr(dtpFechaOCHasta.Value.Month)
                End If

                If CStr(dtpFechaOCHasta.Value.Day).Length = 1 Then
                    diaOCHasta = Trim("0" + CStr(dtpFechaOCHasta.Value.Day))
                Else
                    diaOCHasta = CStr(dtpFechaOCHasta.Value.Day)
                End If

                classRecepcion.fecha_desde = CStr(dtpFechaOCDesde.Value.Year) + mesOCDesde + diaOCDesde
                classRecepcion.fecha_hasta = CStr(dtpFechaOCHasta.Value.Year) + mesOCHasta + diaOCHasta
            Else
                classRecepcion.fecha_desde = "19000101"
                classRecepcion.fecha_hasta = "20501231"
            End If

            If cmbEstado.Text = "" Then
                classRecepcion.ere_codigo = 0
            Else
                classRecepcion.ere_codigo = cmbEstado.SelectedValue
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = classRecepcion.RECEPCIONES_LISTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("rec_numero"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            CDate(ds.Tables(0).Rows(Fila)("rec_fecharecepcion")),
                                            ds.Tables(0).Rows(Fila)("rec_ordencompra"),
                                            ds.Tables(0).Rows(Fila)("rec_nfactura"),
                                            ds.Tables(0).Rows(Fila)("rec_nguia"),
                                            ds.Tables(0).Rows(Fila)("rec_estado"),
                                            IIf(ds.Tables(0).Rows(Fila)("rec_tienemuestra") > 0, True, False),
                                            ds.Tables(0).Rows(Fila)("rec_tienevaletraspaso"),
                                            "",
                                            "",
                                            "",
                                            "",
                                            "",
                                            ds.Tables(0).Rows(Fila)("ere_codigo"),
                                            ds.Tables(0).Rows(Fila)("rec_cantidadpendienteubicacion"))
                            Fila = Fila + 1
                        Loop

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
                        Grilla.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString
                        Call PINTA_GRILLA_ENCBEZADO()
                    End If
                End If
                Me.Text = "LISTADO DE ORDENES DE COMRPA - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub PINTA_GRILLA_ENCBEZADO()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(COL_COL_CPU).Value > 0 Then
                row.DefaultCellStyle.BackColor = Color.LemonChiffon
                row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod
            End If

        Next
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_recepcion = New frm_recepcion
        frm.cnn = _cnn
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = COL_BTN_VER_MUESTRA Then
                If Grilla.Rows(e.RowIndex).Cells(COL_MUESTRA).Value = False Then
                    MessageBox.Show("El registro seleccionado no tiene muestra asociada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim frm As frm_productos_muestra = New frm_productos_muestra
                frm.cnn = _cnn
                frm.rec_codigo = Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value
                frm.ere_codigo = Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = COL_BTN_VER Then
                Dim frm As frm_recepcion = New frm_recepcion
                frm.cnn = _cnn
                frm.rec_codigo = Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value
                frm.ere_codigo = Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()

            ElseIf e.ColumnIndex = COL_BTN_IMPRIMIR Then
                Try
                    If Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value <> 1 Then
                        Dim frm As frm_imprimir = New frm_imprimir
                        frm.Origen = "REC"
                        frm.rec_codigo = Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value
                        frm.ShowDialog()

                        Dim frm2 As frm_imprimir = New frm_imprimir
                        frm2.Origen = "INR"
                        frm2.rec_numero = Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value
                        frm2.ShowDialog()

                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                'Dim frm As frm_imprimir = New frm_imprimir
                'frm.Origen = "INR"
                'frm.rec_numero = Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value
                'frm.ShowDialog()

            ElseIf e.ColumnIndex = COL_BTN_MOV_RECEP Then
                'If Grilla.Rows(e.RowIndex).Cells(12).Value <> ESTADO_RECEPCION.RECEPCIONADA Then
                If Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value <> 1 Then
                    MessageBox.Show("No es posible generar un movimiento de recepción en el estado " + Grilla.Rows(e.RowIndex).Cells(COL_ESTADO).Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim frm As frm_movimientos_recepcion = New frm_movimientos_recepcion
                frm.cnn = _cnn
                frm.recNumero = Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()

            ElseIf e.ColumnIndex = COL_BTN_ELIMINA Then
                Dim respuesta As Integer

                'If Grilla.Rows(e.RowIndex).Cells(12).Value = ESTADO_RECEPCION.RECEPCIONADA Then
                If Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value = 1 Then
                    MessageBox.Show("No es posible eliminar los documentos con estado RESEPCIONADA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                respuesta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If respuesta = vbNo Then
                    Exit Sub
                End If

                Call ELIMINA_RECEPCION(Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value)
                Call CARGA_GRILLA()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ELIMINA_RECEPCION(ByVal ocCodigo As Integer)
        Dim classRec As class_recepcion = New class_recepcion
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""

        Try
            ds = Nothing
            classRec.cnn = _cnn
            classRec.rec_numero = ocCodigo

            ds = classRec.RECEPCION_ELIMINA_REGISTRO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Call ELIMINA_ADJUNTO_RECEPCION(ocCodigo)

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CARGA_GRILLA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ELIMINA_ADJUNTO_RECEPCION(ByVal numRecepcion As Integer)
        Dim classRecepcion As class_recepcion = New class_recepcion

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            Dim Fila As Integer = 0

            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = numRecepcion
            _msg = ""
            ds = classRecepcion.RECEPCIONES_ADJUNTO_LISTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("rec_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            If My.Computer.FileSystem.FileExists(pasoDocumentosResepcion + ds.Tables(0).Rows(Fila)("rec_nombrearchivo")) Then
                                My.Computer.FileSystem.DeleteFile(pasoDocumentosResepcion + ds.Tables(0).Rows(Fila)("rec_nombrearchivo"))
                            End If
                            Fila = Fila + 1
                        Loop
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\ELIMINA_ADJUNTO_RECEPCION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "ELIMINA_ADJUNTO_RECEPCION", MsgBoxStyle.Critical, Me.Text)
        End Try
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