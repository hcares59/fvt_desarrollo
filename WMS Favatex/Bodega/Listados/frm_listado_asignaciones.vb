Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_listado_asignaciones
    Private _cnn As String

    Const COL_NASI As Integer = 0
    Const COL_CAR_CODIGO As Integer = 1
    Const COL_CAR_NOMBRE As Integer = 2
    Const COL_NFECHA As Integer = 3
    Const COL_NUMEROOC As Integer = 4
    Const COL_NUMERORE As Integer = 5
    Const COL_COD_ESTA As Integer = 6
    Const COL_NOM_ESTA As Integer = 7
    Const COL_BOT_ABRIR As Integer = 8

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_listado_asignaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        Call CARGA_COMBO_PROBVEEDOR()
        Call CARGA_COMBO_ESTADO_ASIGNACION_UBICACION()
        lblTotal.Text = "Total de registros: 0"
        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized

        chkFecha.Checked = 0
        dtpFechaOCHasta.Value = GLO_FECHA_SISTEMA
        dtpFechaOCDesde.Value = GLO_FECHA_SISTEMA
        txtOCompra.Text = "0"
        txtRec.Text = "0"

        lblTotal.Text = ""
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
    Private Sub CARGA_COMBO_ESTADO_ASIGNACION_UBICACION()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn
            _msg = ""
            ds = classUbicacion.CARGA_COMBO_ESTADO_ASIGNACION_UBICACION(_msg)
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

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        dtpFechaOCDesde.Enabled = chkFecha.Checked
        dtpFechaOCHasta.Enabled = chkFecha.Checked
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
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
            classUbicacion.cnn = _cnn

            classUbicacion.asi_codigo = 0

            If cmbProveedor.Text = "" Then
                classUbicacion.car_codigo = 0
            Else
                classUbicacion.car_codigo = cmbProveedor.SelectedValue
            End If

            If txtOCompra.Text = "0" Or txtOCompra.Text = "" Then
                classUbicacion.ocp_numero = 0
            Else
                classUbicacion.ocp_numero = CLng(txtOCompra.Text)
            End If

            If txtRec.Text = "0" Or txtRec.Text = "" Then
                classUbicacion.rec_numero = 0
            Else
                classUbicacion.rec_numero = CLng(txtRec.Text)
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

                classUbicacion.fecha_desde = CStr(dtpFechaOCDesde.Value.Year) + mesOCDesde + diaOCDesde
                classUbicacion.Fecha_hasta = CStr(dtpFechaOCHasta.Value.Year) + mesOCHasta + diaOCHasta
            Else
                classUbicacion.fecha_desde = "19000101"
                classUbicacion.Fecha_hasta = "20501231"
            End If

            If cmbEstado.Text = "" Then
                classUbicacion.esi_codigo = 0
            Else
                classUbicacion.esi_codigo = cmbEstado.SelectedValue
            End If

            classUbicacion.desde_recepcion = chkDesdeRecepcion.Checked

            _msg = ""
            Grilla.Rows.Clear()
            ds = classUbicacion.ASIGNACIONES_LISTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("asi_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("asi_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            CDate(ds.Tables(0).Rows(Fila)("asi_fecha")),
                                            ds.Tables(0).Rows(Fila)("ocp_numero"),
                                            ds.Tables(0).Rows(Fila)("rec_numero"),
                                            ds.Tables(0).Rows(Fila)("esi_codigo"),
                                            ds.Tables(0).Rows(Fila)("esi_nombre"),
                                            "")
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

                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString

                    End If
                End If
                Me.Text = "LISTADO DE ASIGNACIONES DE UBICACION - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = COL_BOT_ABRIR Then
                If Grilla.Rows(e.RowIndex).Cells(COL_CAR_NOMBRE).Value <> "" Then
                    Dim frm As frm_asignacion_ubicaciones = New frm_asignacion_ubicaciones
                    frm.cnn = _cnn
                    frm.asiNumero = Grilla.Rows(e.RowIndex).Cells(COL_NASI).Value
                    frm.recNumero = 0
                    frm.esi_codigo = Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTA).Value
                    frm.ShowDialog()
                    Call CARGA_GRILLA()
                Else
                    Dim frm As frm_reubicacion_de_bultos = New frm_reubicacion_de_bultos
                    frm.cnn = _cnn
                    frm.asiNumero = Grilla.Rows(e.RowIndex).Cells(COL_NASI).Value
                    frm.esi_codigo = Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTA).Value
                    frm.ShowDialog()
                    Call CARGA_GRILLA()
                End If




                'ElseIf e.ColumnIndex = COL_BTN_VER Then
                '    Dim frm As frm_recepcion = New frm_recepcion
                '    frm.cnn = _cnn
                '    frm.rec_codigo = Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value
                '    frm.ere_codigo = Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value
                '    frm.ShowDialog()
                '    Call CARGA_GRILLA()

                'ElseIf e.ColumnIndex = COL_BTN_IMPRIMIR Then
                '    Try
                '        If Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value <> 1 Then
                '            Dim frm As frm_imprimir = New frm_imprimir
                '            frm.Origen = "REC"
                '            frm.rec_codigo = Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value
                '            frm.ShowDialog()

                '            Dim frm2 As frm_imprimir = New frm_imprimir
                '            frm2.Origen = "INR"
                '            frm2.rec_numero = Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value
                '            frm2.ShowDialog()

                '        End If
                '    Catch ex As Exception
                '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    End Try

                '    'Dim frm As frm_imprimir = New frm_imprimir
                '    'frm.Origen = "INR"
                '    'frm.rec_numero = Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value
                '    'frm.ShowDialog()

                'ElseIf e.ColumnIndex = COL_BTN_MOV_RECEP Then
                '    'If Grilla.Rows(e.RowIndex).Cells(12).Value <> ESTADO_RECEPCION.RECEPCIONADA Then
                '    If Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value <> 1 Then
                '        MessageBox.Show("No es posible generar un movimiento de recepción en el estado " + Grilla.Rows(e.RowIndex).Cells(COL_ESTADO).Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Exit Sub
                '    End If

                '    Dim frm As frm_movimientos_recepcion = New frm_movimientos_recepcion
                '    frm.cnn = _cnn
                '    frm.recNumero = Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value
                '    frm.ShowDialog()
                '    Call CARGA_GRILLA()

                'ElseIf e.ColumnIndex = COL_BTN_ELIMINA Then
                '    Dim respuesta As Integer

                '    'If Grilla.Rows(e.RowIndex).Cells(12).Value = ESTADO_RECEPCION.RECEPCIONADA Then
                '    If Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value = 1 Then
                '        MessageBox.Show("No es posible eliminar los documentos con estado RESEPCIONADA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Exit Sub
                '    End If

                '    respuesta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                '    If respuesta = vbNo Then
                '        Exit Sub
                '    End If

                '    Call ELIMINA_RECEPCION(Grilla.Rows(e.RowIndex).Cells(COL_NREC).Value)
                '    Call CARGA_GRILLA()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class