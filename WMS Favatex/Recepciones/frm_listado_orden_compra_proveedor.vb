Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class frm_listado_orden_compra_proveedor
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_orden_compra_proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ButtonNueva.Enabled = True
        If USU_EJECUTA_RECEPCION = True Or USU_ASIGNA_PARA_RECEPCION = True Then
            ButtonNueva.Enabled = False
        End If

        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        Call CARGA_COMBO_PROBVEEDOR()
        Call CARGA_COMBO_ESTADO_OC()
        lblTotal.Text = "Total de registros: 0"
        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized
        GLO_FECHA_SISTEMA = Date.Today
        dtpFechaOCDesde.Value = GLO_FECHA_SISTEMA
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

    Private Sub CARGA_COMBO_ESTADO_OC()
        Dim _msg As String
        Try
            Dim classEstado As class_rec_orden_compra = New class_rec_orden_compra
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classEstado.cnn = _cnn
            _msg = ""
            ds = classEstado.COMBO_CARGA_ESTADO_OC(_msg)
            If _msg = "" Then
                Me.cmbEstado.DataSource = ds.Tables(0)
                Me.cmbEstado.DisplayMember = "MENSAJE"
                Me.cmbEstado.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ESTADO_OC", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        dtpFechaOCDesde.Enabled = chkFecha.Checked
        dtpFechaOCHasta.Enabled = chkFecha.Checked
    End Sub

    Private Sub chkFechaArribo_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaArribo.CheckedChanged
        dtpArriboDesde.Enabled = chkFechaArribo.Checked
        dtpArriboHasta.Enabled = chkFechaArribo.Checked
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Dim diaOCDesde As String = ""
        Dim mesOCDesde As String = ""

        Dim diaOCHasta As String = ""
        Dim mesOCHasta As String = ""

        Dim diaArriboDesde As String = ""
        Dim mesArriboDesde As String = ""

        Dim diaArriboHasta As String = ""
        Dim mesArriboHasta As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classOC.cnn = _cnn

            If cmbProveedor.Text = "" Then
                classOC.car_codigo = 0
            Else
                classOC.car_codigo = cmbProveedor.SelectedValue
            End If

            classOC.ocp_codigo = 0
            classOC.ocp_numero = 0

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

                classOC.fecha_ingreso_desde = CStr(dtpFechaOCDesde.Value.Year) + mesOCDesde + diaOCDesde
                classOC.fecha_hasta_desde = CStr(dtpFechaOCHasta.Value.Year) + mesOCHasta + diaOCHasta
            Else
                classOC.fecha_ingreso_desde = "19000101"
                classOC.fecha_hasta_desde = "20501231"
            End If


            If chkFechaArribo.Checked = True Then
                'desde
                If CStr(dtpArriboDesde.Value.Month).Length = 1 Then
                    mesArriboDesde = Trim("0" + CStr(dtpArriboDesde.Value.Month))
                Else
                    mesArriboDesde = CStr(dtpArriboDesde.Value.Month)
                End If

                If CStr(dtpArriboDesde.Value.Day).Length = 1 Then
                    diaArriboDesde = Trim("0" + CStr(dtpArriboDesde.Value.Day))
                Else
                    diaArriboDesde = CStr(dtpArriboDesde.Value.Day)
                End If

                'Hasta
                If CStr(dtpArriboHasta.Value.Month).Length = 1 Then
                    mesArriboHasta = Trim("0" + CStr(dtpArriboHasta.Value.Month))
                Else
                    mesArriboHasta = CStr(dtpArriboHasta.Value.Month)
                End If

                If CStr(dtpArriboHasta.Value.Day).Length = 1 Then
                    diaArriboHasta = Trim("0" + CStr(dtpArriboHasta.Value.Day))
                Else
                    diaArriboHasta = CStr(dtpArriboHasta.Value.Day)
                End If

                classOC.fecha_arribo_desde = CStr(dtpArriboDesde.Value.Year) + mesArriboDesde + diaArriboDesde
                classOC.fecha_arribo_hasta = CStr(dtpArriboHasta.Value.Year) + mesArriboHasta + diaArriboHasta
            Else
                classOC.fecha_arribo_desde = "19000101"
                classOC.fecha_arribo_hasta = "20501231"
            End If

            If cmbEstado.Text = "" Then
                classOC.eoc_codigo = 0
            Else
                classOC.eoc_codigo = cmbEstado.SelectedValue
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = classOC.OC_PROVEEDORES_LISTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("ocp_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_numero"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechaorden"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechallegada"),
                                            ds.Tables(0).Rows(Fila)("eoc_nombre"),
                                            "",
                                            ds.Tables(0).Rows(Fila)("eoc_codigo"),
                                            ds.Tables(0).Rows(Fila)("opd_cantidad"),
                                            ds.Tables(0).Rows(Fila)("opd_cantidadentransito"),
                                            ds.Tables(0).Rows(Fila)("opd_cantidadrecepcionada"),
                                            ds.Tables(0).Rows(Fila)("mci_nombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_empresatransportenombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_nfacturatransporte"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechaembarque"),
                                            ds.Tables(0).Rows(Fila)("ocp_ntransporte"),
                                            ds.Tables(0).Rows(Fila)("ocp_nimportacion"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechapagotransporte"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechavencimientotransporte"),
                                            ds.Tables(0).Rows(Fila)("ocp_valorflete"),
                                            ds.Tables(0).Rows(Fila)("ocp_nproforma"),
                                            ds.Tables(0).Rows(Fila)("ocp_diaspagonombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_pagofactura"),
                                            ds.Tables(0).Rows(Fila)("ocp_pagofacturanombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_condicionpagonombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechapago"),
                                            ds.Tables(0).Rows(Fila)("ocp_empresadescarganombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_nfacturadescarga"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechadescarga"),
                                            ds.Tables(0).Rows(Fila)("ocp_banconombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechaaperturacc"),
                                            ds.Tables(0).Rows(Fila)("ocp_diaspagobanconombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_fechavencimientobanco"),
                                            ds.Tables(0).Rows(Fila)("ocp_agenciaaduananombre"),
                                            ds.Tables(0).Rows(Fila)("ocp_numerodni"),
                                            ds.Tables(0).Rows(Fila)("ocp_nfacturaimportacion"),
                                            ds.Tables(0).Rows(Fila)("ocp_certificadoseguro"))
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
                        Grilla.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "LISTADO DE ORDENES DE COMRPA - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Fila = 0
            GrillaExp.Rows.Clear()
            ds = Nothing
            ds = classOC.OC_PROVEEDORES_DETALLE_EXPORTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaExp.Rows.Add(ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("numero_orden"),
                                            ds.Tables(0).Rows(Fila)("fecha_orden"),
                                            ds.Tables(0).Rows(Fila)("fecha_llegada"),
                                            ds.Tables(0).Rows(Fila)("estado_orden"),
                                            ds.Tables(0).Rows(Fila)("codigo_interno"),
                                            ds.Tables(0).Rows(Fila)("nombre_producto"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("precio"),
                                            ds.Tables(0).Rows(Fila)("total_fila"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If

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

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As rec_orden_compra = New rec_orden_compra
        frm.cnn = _cnn
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Dim scopeOptions = New TransactionOptions()
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)

        Try

            If e.ColumnIndex = 37 Then 'VER ORDEN (13) 
                Dim frm As rec_orden_compra = New rec_orden_compra
                frm.cnn = _cnn
                frm.ocp_codigo = Grilla.Rows(e.RowIndex).Cells(1).Value
                frm.eoc_codigo = Grilla.Rows(e.RowIndex).Cells(8).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()

            ElseIf e.ColumnIndex = 38 Then 'ELIMINA ORDEN (46)
                Dim respuesta As Integer

                If (USU_ASIGNA_PARA_RECEPCION = True) Or (USU_EJECUTA_RECEPCION = True) Then
                    MessageBox.Show("No cuenta con el perfil para poder eliminar ordenes de compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If (Grilla.Rows(e.RowIndex).Cells(8).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.ANULADA) Or (Grilla.Rows(e.RowIndex).Cells(8).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.ARRIBADA) _
                    Or (Grilla.Rows(e.RowIndex).Cells(8).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.EN_TRANSITO) Then
                    MessageBox.Show("No es posible eliminar una orden de compra en estado: " + Grilla.Rows(e.RowIndex).Cells(6).Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                respuesta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If respuesta = vbNo Then
                    Exit Sub
                End If

                Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                    conexion.Open()

                    If ELIMINA_ADJUNTO_ORDEN_COMPRA(Grilla.Rows(e.RowIndex).Cells(1).Value, conexion) = True Then
                        If ELIMINA_ORDEN_COMPRA(Grilla.Rows(e.RowIndex).Cells(1).Value, conexion) = False Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            Exit Sub
                        End If
                    Else
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        Exit Sub
                    End If

                    Transaccion.Complete()
                    Transaccion.Dispose()
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Using

                MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call CARGA_GRILLA()

            ElseIf e.ColumnIndex = 39 Then 'PALETIZAR (15)
                Dim frm As frm_paletiza_oc = New frm_paletiza_oc
                frm.cnn = _cnn
                frm.ocp_codigo = Grilla.Rows(e.RowIndex).Cells(1).Value
                frm.ShowDialog()

            ElseIf e.ColumnIndex = 40 Then 'GENERAR RECEPCION (16)

                If (Grilla.Rows(e.RowIndex).Cells(8).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.ANULADA) Or (Grilla.Rows(e.RowIndex).Cells(8).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.ARRIBADA) Then
                    MessageBox.Show("No es posible generar una recepción en estado: " + Grilla.Rows(e.RowIndex).Cells(6).Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim frm As frm_recepcion = New frm_recepcion
                frm.cnn = _cnn
                frm.car_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.opd_numero = Grilla.Rows(e.RowIndex).Cells(3).Value
                frm.ShowDialog()

            ElseIf e.ColumnIndex = 41 Then 'CIERRE MANUAL (17)
                If (Grilla.Rows(e.RowIndex).Cells(8).Value = ESTADO_ORDEN_COMPRA_PROVEEDOR.ARRIBADA) Then
                    MessageBox.Show("La Oden no se puede cerrar si ya esta ARRIBADA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim frm As frm_seleciona_motivo_cierre = New frm_seleciona_motivo_cierre
                frm.cnn = _cnn
                frm.ocp_codigo = Grilla.Rows(e.RowIndex).Cells(1).Value
                frm.ShowDialog()

                'Call CERRADO_MANUAL(Grilla.Rows(e.RowIndex).Cells(1).Value)
                Call CARGA_GRILLA()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ELIMINA_ADJUNTO_ORDEN_COMPRA(ByVal ocCodigo As Integer, ByVal conexion As SqlConnection) As Boolean
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            Dim Fila As Integer
            ELIMINA_ADJUNTO_ORDEN_COMPRA = False
            ds = Nothing
            Fila = 0

            classOC.cnn = _cnn
            classOC.ocp_codigo = ocCodigo
            _msg = ""

            ds = classOC.ORDEN_COMPRA_ADJUNTO_LISTAR(_msg, conexion)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("ocp_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            If My.Computer.FileSystem.FileExists(pasoDocumentosOrdenCompra + ds.Tables(0).Rows(Fila)("ocp_nombrearchivo")) Then
                                My.Computer.FileSystem.DeleteFile(pasoDocumentosOrdenCompra + ds.Tables(0).Rows(Fila)("ocp_nombrearchivo"))
                            End If
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\ELIMINA_ADJUNTO_ORDEN_COMPRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            classOC.cnn = _cnn
            classOC.ocp_codigo = ocCodigo
            ds = classOC.ORDEN_COMPRA_ELIMINA_REGISTRO_ADJUNTO(_msg, conexion)

            If _msg <> "" Then
                MessageBox.Show(_msg + "\ELIMINA_ADJUNTO_ORDEN_COMPRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            ELIMINA_ADJUNTO_ORDEN_COMPRA = True
        Catch ex As Exception
            ELIMINA_ADJUNTO_ORDEN_COMPRA = False
            MsgBox(ex.Message + " " + "ELIMINA_ADJUNTO_ORDEN_COMPRA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Function


    'Private Sub CERRADO_MANUAL(ByVal _ocp_codigo As Integer)
    '    Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
    '    Dim ds As DataSet = New DataSet
    '    Dim _msgError As String = ""

    '    Try
    '        ds = Nothing
    '        classOC.cnn = _cnn
    '        classOC.ocp_codigo = _ocp_codigo
    '        classOC.eoc_codigo = ESTADO_ORDEN_COMPRA_PROVEEDOR.CIERRE_MANUAL

    '        ds = classOC.REC_ORDEN_COMPRA_CAMBIA_ESTADO(_msgError)
    '        If _msgError <> "" Then
    '            ds = Nothing
    '            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
    '                ds = Nothing
    '                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End If
    '        End If

    '        MessageBox.Show("Orden cerrada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Function ELIMINA_ORDEN_COMPRA(ByVal ocCodigo As Integer, ByVal conexion As SqlConnection) As Boolean
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""
        ELIMINA_ORDEN_COMPRA = False

        Try
            ds = Nothing
            classOC.cnn = _cnn
            classOC.ocp_codigo = ocCodigo

            ds = classOC.OC_PROVEEDORES_ELIMINA(_msgError, conexion)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Exit Function
                End If
            End If
            ELIMINA_ORDEN_COMPRA = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Function

    Private Sub ButtonExportar_Click(sender As Object, e As EventArgs) Handles ButtonExportar.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0
        Dim respuesta2 As Integer = 0

        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                                + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If

            respuesta2 = MessageBox.Show("Si desea ontener los datos resumidos, precione SI, se desea obtener el detalle precione NO", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If respuesta2 = vbYes Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call MuestraColumnas()
                Call ExportarDatosExcel(Me.Grilla, "LISTADO DE ORDENES RESUMIDA")
                Call OcultaColumnas()
                Cursor = System.Windows.Forms.Cursors.Default
            Else
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call ExportarDatosExcel(Me.GrillaExp, "LISTADO DE ORDENES DETALLADAS")
                Cursor = System.Windows.Forms.Cursors.Default
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub MuestraColumnas()
        Grilla.Columns(13).Visible = True
        Grilla.Columns(14).Visible = True
        Grilla.Columns(15).Visible = True
        Grilla.Columns(16).Visible = True
        Grilla.Columns(17).Visible = True
        Grilla.Columns(18).Visible = True
        Grilla.Columns(19).Visible = True
        Grilla.Columns(20).Visible = True
        Grilla.Columns(21).Visible = True
        Grilla.Columns(22).Visible = True
        Grilla.Columns(23).Visible = True
        Grilla.Columns(24).Visible = True
        Grilla.Columns(25).Visible = True
        Grilla.Columns(26).Visible = True
        Grilla.Columns(27).Visible = True
        Grilla.Columns(28).Visible = True
        Grilla.Columns(29).Visible = True
        Grilla.Columns(30).Visible = True
        Grilla.Columns(31).Visible = True
        Grilla.Columns(32).Visible = True
        Grilla.Columns(33).Visible = True
        Grilla.Columns(34).Visible = True
        Grilla.Columns(35).Visible = True
        Grilla.Columns(36).Visible = True

    End Sub

    Private Sub OcultaColumnas()
        Grilla.Columns(13).Visible = False
        Grilla.Columns(14).Visible = False
        Grilla.Columns(15).Visible = False
        Grilla.Columns(16).Visible = False
        Grilla.Columns(17).Visible = False
        Grilla.Columns(18).Visible = False
        Grilla.Columns(19).Visible = False
        Grilla.Columns(20).Visible = False
        Grilla.Columns(21).Visible = False
        Grilla.Columns(22).Visible = False
        Grilla.Columns(23).Visible = False
        Grilla.Columns(24).Visible = False
        Grilla.Columns(25).Visible = False
        Grilla.Columns(26).Visible = False
        Grilla.Columns(27).Visible = False
        Grilla.Columns(28).Visible = False
        Grilla.Columns(29).Visible = False
        Grilla.Columns(30).Visible = False
        Grilla.Columns(31).Visible = False
        Grilla.Columns(32).Visible = False
        Grilla.Columns(33).Visible = False
        Grilla.Columns(34).Visible = False
        Grilla.Columns(35).Visible = False
        Grilla.Columns(36).Visible = False

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

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class