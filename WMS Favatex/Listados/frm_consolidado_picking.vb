Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_consolidado_picking
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub CARGA_GRILLA()
        Dim classPicking As class_picking = New class_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Dim diaCompromisoDesde As String = ""
        Dim mesCompromisoDesde As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classPicking.cnn = _cnn


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

            If txtHoraIni.Text = ":" Then
                txtHoraIni.Text = "00:00"
            End If

            If txtHoraTer.Text = ":" Then
                txtHoraTer.Text = "24:00"
            End If
            classPicking.hora_inicio = txtHoraIni.Text
            classPicking.hora_termino = txtHoraTer.Text


            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.PICKING_LISTADO_SIN_CONSOLIDAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pic_codigo"), False,
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            ds.Tables(0).Rows(Fila)("pic_fecha"),
                                            ds.Tables(0).Rows(Fila)("fecha_compromiso"),
                                            ds.Tables(0).Rows(Fila)("pic_hora"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("LugarDespacho"),
                                            ds.Tables(0).Rows(Fila)("epc_codigo"),
                                            ds.Tables(0).Rows(Fila)("epc_nombre"),
                                            ds.Tables(0).Rows(Fila)("cant_unidades"),
                                            ds.Tables(0).Rows(Fila)("cant_bultos"),
                                            ds.Tables(0).Rows(Fila)("total_bultos"),
                                            ds.Tables(0).Rows(Fila)("pic_consolidado"),
                                            ds.Tables(0).Rows(Fila)("pic_consolidadoBusqueda"),
                                            "",
                                            "")

                            If Grilla.Item(13, Fila).Value = True Then
                                Grilla.Item(13, Fila).Style.BackColor = Color.FromArgb(173, 8, 8)
                                'Grilla.Item(2, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)
                            End If

                            If Grilla.Item(14, Fila).Value = True Then
                                Grilla.Item(14, Fila).Style.BackColor = Color.FromArgb(173, 8, 8)
                                'Grilla.Item(2, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)
                            End If


                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString

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
                        Grilla.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


                    End If
                End If
                Me.Text = "CONSOLIDADO DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frm_consolidado_picking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
        Call CONFIGURA_COLUMNAS()
    End Sub

    Private Sub INICIALIZA()
        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized
        Me.Grilla.Columns(3).Frozen = True
        dtpCompromisoDesde.Value = GLO_FECHA_SISTEMA
        lblTotal.Text = ""
        txtHoraIni.Text = "08:00"
        txtHoraTer.Text = "20:00"
    End Sub


    Private Sub CONFIGURA_COLUMNAS()
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
        Grilla.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
        Call CONFIGURA_COLUMNAS()
    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0
        Dim Seleccionados As String = ""
        Try

            If EXISTEN_MARCADOS() = False Then
                MessageBox.Show("Debe marcar a lo menos un picking ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            respuesta = MessageBox.Show("Esta seuro(a) de generar el consolidado de picking", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If

            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(1).Value = True Then
                    Seleccionados = Seleccionados + CInt(row.Cells(2).Value).ToString + ","
                End If
            Next

            Dim frm As frm_imprimir = New frm_imprimir
            frm.Origen = "PKC"
            frm.strCadena = Seleccionados
            frm.strFecha = dtpCompromisoDesde.Text
            frm.strHoraIni = txtHoraIni.Text
            frm.strHoraFin = txtHoraTer.Text
            frm.ShowDialog()
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(1).Value = True Then
                        classPicking.pic_codigo = row.Cells(2).Value
                        ds = classPicking.MARCA_CONSOLIDADO_PICKING(_msgError, conexion)
                        If _msgError = "" Then
                            If ds.Tables.Count > 0 Then
                                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                    If conexion.State <> ConnectionState.Closed Then
                                        conexion.Close()
                                    End If
                                    conexion.Dispose()
                                    ds.Dispose()
                                    MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            End If
                        Else
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            ds.Dispose()
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        ds = Nothing
                    End If
                Next
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default
                Call CARGA_GRILLA()

            End Using
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function EXISTEN_MARCADOS() As Boolean
        Dim contador As Integer = 0
        Try
            EXISTEN_MARCADOS = False
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(1).Value = True Then
                    EXISTEN_MARCADOS = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            EXISTEN_MARCADOS = False
        End Try
    End Function

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(1)
        If e.ColumnIndex = Me.Grilla.Columns.Item(1).Index Then
            chkCell.Value = Not chkCell.Value
        End If

        Try
            If e.ColumnIndex = 15 Then
                Dim frm As frm_mant_picking = New frm_mant_picking
                frm.cnn = _cnn
                frm.pic_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.HabilitarBtn = False
                frm.ShowDialog()
                Call CARGA_GRILLA()
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

    Private Sub ButtonSelecciona_Click(sender As Object, e As EventArgs) Handles ButtonSelecciona.Click
        Call MARCAR_TODOS()
    End Sub
    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub
    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonExportar_Click(sender As Object, e As EventArgs) Handles ButtonExportar.Click
        Dim class_comunes As class_comunes = New class_comunes
        class_comunes.ExportarExcel(Me.Grilla)
    End Sub

    Private Function REQUIERE_AGRUPACION_POR_DESPACHO(ByVal codigoCliente As Integer) As Boolean
        Dim classCliente As class_cartera = New class_cartera
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        REQUIERE_AGRUPACION_POR_DESPACHO = False
        Try
            classCliente.cnn = _cnn
            classCliente.car_codigo = codigoCliente

            ds = classCliente.REQUIERE_GRUPAR_POR_DESPACHO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") <> 0 Then
                        REQUIERE_AGRUPACION_POR_DESPACHO = ds.Tables(0).Rows(Fila)("car_requiere_agrupar_x_despacho")
                    End If
                End If
            Else
                REQUIERE_AGRUPACION_POR_DESPACHO = False
                MessageBox.Show(_msgError + "\REQUIERE_AGRUPACION_POR_DESPACHO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            REQUIERE_AGRUPACION_POR_DESPACHO = False
            MessageBox.Show(ex.Message + "\REQUIERE_AGRUPACION_POR_DESPACHO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem.Click
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0
        Dim Seleccionados As String = ""
        Dim fila As Integer
        Dim Respuesta2 As Integer = 0
        Dim Despachar As String = ""
        Dim codCliente As Integer = 0
        Dim conCliente As String = ""

        Try

            If EXISTEN_MARCADOS() = False Then
                MessageBox.Show("Debe marcar a lo menos un picking ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(1).Value = True Then
                    If fila = 0 Then
                        codCliente = row.Cells(6).Value
                        conCliente = row.Cells(7).Value
                        'LugarDespacho = row.Cells(4).Value
                    Else
                        If Trim(conCliente) <> Trim(row.Cells(7).Value) Then
                            MessageBox.Show("Existen distintos clientes seleccionados, por favor revisar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    fila = fila + 1
                End If
            Next


            respuesta = MessageBox.Show("Esta seuro(a) de generar el consolidado de picking", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If

            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(1).Value = True Then
                    Seleccionados = Seleccionados + CInt(row.Cells(2).Value).ToString + ","
                End If
            Next

            If REQUIERE_AGRUPACION_POR_DESPACHO(codCliente) = True Then
                fila = 0
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(1).Value = True Then
                        If fila = 0 Then
                            Despachar = row.Cells(8).Value
                            'LugarDespacho = row.Cells(4).Value
                        Else
                            If Trim(Despachar) <> Trim(row.Cells(8).Value) Then
                                MessageBox.Show("Existen ordenes seleccionadas con distinto lugar de despacho, por favor revisar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        End If
                        fila = fila + 1
                    End If
                Next
            End If



            Dim frm As frm_imprimir = New frm_imprimir
            frm.Origen = "PKC"
            frm.strCadena = Seleccionados
            frm.strFecha = dtpCompromisoDesde.Text
            frm.strHoraIni = txtHoraIni.Text
            frm.strHoraFin = txtHoraTer.Text
            frm.ShowDialog()
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(1).Value = True Then
                        classPicking.pic_codigo = row.Cells(2).Value
                        ds = classPicking.MARCA_CONSOLIDADO_PICKING(_msgError, conexion)
                        If _msgError = "" Then
                            If ds.Tables.Count > 0 Then
                                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                    If conexion.State <> ConnectionState.Closed Then
                                        conexion.Close()
                                    End If
                                    conexion.Dispose()
                                    ds.Dispose()
                                    MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            End If
                        Else
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            ds.Dispose()
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        ds = Nothing
                    End If
                Next
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default
                Call CARGA_GRILLA()

            End Using
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CONSOLIDADODEPICKINGPARAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONSOLIDADODEPICKINGPARAToolStripMenuItem.Click
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0
        Dim Seleccionados As String = ""
        Try

            If EXISTEN_MARCADOS() = False Then
                MessageBox.Show("Debe marcar a lo menos un picking ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            respuesta = MessageBox.Show("Esta seuro(a) de generar el consolidado de picking para busqueda", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If

            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(1).Value = True Then
                    Seleccionados = Seleccionados + CInt(row.Cells(2).Value).ToString + ","
                End If
            Next

            Dim frm As frm_imprimir = New frm_imprimir
            frm.Origen = "PKCB"
            frm.strCadena = Seleccionados
            frm.strFecha = dtpCompromisoDesde.Text
            frm.strHoraIni = txtHoraIni.Text
            frm.strHoraFin = txtHoraTer.Text
            frm.ShowDialog()
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(1).Value = True Then
                        classPicking.pic_codigo = row.Cells(2).Value
                        ds = classPicking.MARCA_CONSOLIDADO_PICKING_BUSQUEDA(_msgError, conexion)
                        If _msgError = "" Then
                            If ds.Tables.Count > 0 Then
                                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                    If conexion.State <> ConnectionState.Closed Then
                                        conexion.Close()
                                    End If
                                    conexion.Dispose()
                                    ds.Dispose()
                                    MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            End If
                        Else
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            ds.Dispose()
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        ds = Nothing
                    End If
                Next
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default
                Call CARGA_GRILLA()

            End Using
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class