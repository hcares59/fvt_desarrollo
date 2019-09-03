Public Class frm_listado_embarques
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_listado_embarques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        Me.WindowState = FormWindowState.Maximized
        lblTotal.Text = "Cantidad de registros encontrados: 0"
        txtSello.Text = ""
        optPropio.Checked = True
        chkDespacho.Checked = False
        dtpDesde.Value = GLO_FECHA_SISTEMA
        dtpHasta.Value = GLO_FECHA_SISTEMA
        Grilla.DataSource = Nothing
        Grilla.Rows.Clear()
        chkDespacho.Checked = True
        'Call CARGA_GRILLA()
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classEmbarque As class_embarque = New class_embarque
        Dim mesDesde As String = ""
        Dim diaDesde As String = ""
        Dim mesHasta As String = ""
        Dim diaHasta As String = ""
        Dim Fila As Integer = 0
        Dim tipoTransporte As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classEmbarque.cnn = _cnn
            classEmbarque.emb_sello = IIf(txtSello.Text = "", "-", txtSello.Text)

            If optPropio.Checked = True Then
                classEmbarque.emb_tipo = 1
            Else
                classEmbarque.emb_tipo = 2
            End If

            If chkDespacho.Checked = True Then
                'fecha ingreso desde
                If CStr(dtpDesde.Value.Month).Length = 1 Then
                    mesDesde = Trim("0" + CStr(dtpDesde.Value.Month))
                Else
                    mesDesde = CStr(dtpDesde.Value.Month)
                End If

                If CStr(dtpDesde.Value.Day).Length = 1 Then
                    diaDesde = Trim("0" + CStr(dtpDesde.Value.Day))
                Else
                    diaDesde = CStr(dtpDesde.Value.Day)
                End If
                classEmbarque.fecha_despacho_desde = CStr(dtpDesde.Value.Year) + mesDesde + diaDesde

                'fecha ingreso hasta
                If CStr(dtpHasta.Value.Month).Length = 1 Then
                    mesHasta = Trim("0" + CStr(dtpHasta.Value.Month))
                Else
                    mesHasta = CStr(dtpHasta.Value.Month)
                End If

                If CStr(dtpDesde.Value.Day).Length = 1 Then
                    diaHasta = Trim("0" + CStr(dtpHasta.Value.Day))
                Else
                    diaHasta = CStr(dtpHasta.Value.Day)
                End If
                classEmbarque.fecha_despacho_hasta = CStr(dtpHasta.Value.Year) + mesHasta + diaHasta
            Else
                classEmbarque.fecha_despacho_desde = "19000101"
                classEmbarque.fecha_despacho_hasta = "20501231"
            End If

            If chkBuscaDoc.Checked = True Then

                If txtDocumento.Text = "0" Or txtDocumento.Text = "" Then
                    If optFactura.Checked = True Then
                        MessageBox.Show("Debe ingresar el número de factura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf optGuia.Checked = True Then
                        MessageBox.Show("Debe ingresar el número de la guia de despacho", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    txtDocumento.Focus()
                    Exit Sub
                End If

                If optFactura.Checked = True Then
                    classEmbarque.tipoDocumento = "F"
                Else
                    classEmbarque.tipoDocumento = "G"
                End If
                classEmbarque.numDocumento = CLng(txtDocumento.Text)
            Else
                classEmbarque.tipoDocumento = "N"
                classEmbarque.numDocumento = 0
            End If

            _msg = ""

            Grilla.Rows.Clear()
            ds = classEmbarque.DESPACHO_EMBARQUE_ENC_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("emb_sello") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            If ds.Tables(0).Rows(Fila)("emb_tipo") = 1 Then
                                tipoTransporte = "PROPIO"
                            Else
                                tipoTransporte = "EXTERNO"
                            End If

                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("emb_sello"),
                                            ds.Tables(0).Rows(Fila)("emb_fechaingreso"),
                                            ds.Tables(0).Rows(Fila)("emb_fechadespacho"),
                                            ds.Tables(0).Rows(Fila)("emb_horacita"),
                                            tipoTransporte,
                                            ds.Tables(0).Rows(Fila)("emb_chofernombre"),
                                            ds.Tables(0).Rows(Fila)("emb_transporte"),
                                            ds.Tables(0).Rows(Fila)("emb_cantpallet"),
                                            ds.Tables(0).Rows(Fila)("emb_cantpalletdoble"))
                            Fila = Fila + 1
                        Loop

                    End If
                    lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                End If
                Me.Text = "LISTADO DE EMBARQUES - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_ingreso_datos_despacho = New frm_ingreso_datos_despacho
        frm.cnn = _cnn
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Dim numDevolucion As Integer = 0
        Try
            If e.ColumnIndex = 9 Then
                Dim frm As frm_ingreso_datos_despacho = New frm_ingreso_datos_despacho
                frm.cnn = _cnn
                frm.sel_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 11 Then
                numDevolucion = VERIFICA_DEVOLUCIONES(Grilla.Rows(e.RowIndex).Cells(0).Value)
                If numDevolucion > 0 Then
                    MessageBox.Show("No es posible eliminar el embarque ya que tiene la devolucion n°: " + numDevolucion.ToString + " asociada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Call ELIMINA_REGISTRO(Grilla.Rows(e.RowIndex).Cells(0).Value)
                End If
            ElseIf e.ColumnIndex = 10 Then
                Dim frm As frm_imprimir = New frm_imprimir
                frm.Origen = "EM"
                frm.emb_sello = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function VERIFICA_DEVOLUCIONES(ByVal embSello As String) As Integer
        Dim classEmbarque As class_embarque = New class_embarque
        Dim Fila As Integer = 0
        VERIFICA_DEVOLUCIONES = 0


        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classEmbarque.cnn = _cnn
            classEmbarque.emb_sello = embSello

            _msg = ""
            ds = classEmbarque.VERIFICA_DEVOLUCIONES(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    VERIFICA_DEVOLUCIONES = ds.Tables(0).Rows(Fila)("dev_codigo")
                End If
            Else
                MessageBox.Show(_msg + "\VERIFICA_DEVOLUCIONES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            VERIFICA_DEVOLUCIONES = 0
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Function



    Private Sub ELIMINA_REGISTRO(ByVal sello As String)
        Dim classEmbarque As class_embarque = New class_embarque
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""

        Try
            ds = Nothing
            classEmbarque.cnn = _cnn
            classEmbarque.emb_sello = sello

            ds = classEmbarque.DESPACHO_EMBARQUE_ELIMINA(_msgError)
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

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CARGA_GRILLA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ButtonLimpiar_Click(sender As Object, e As EventArgs) Handles ButtonLimpiar.Click
        Call INICIALIZA()
    End Sub

    Private Sub chkDespacho_CheckedChanged(sender As Object, e As EventArgs) Handles chkDespacho.CheckedChanged
        If chkDespacho.Checked = True Then
            dtpDesde.Enabled = True
            dtpHasta.Enabled = True
        ElseIf chkDespacho.Checked = True Then
            dtpDesde.Enabled = False
            dtpHasta.Enabled = False
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
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            class_comunes.ExportarExcel(Me.Grilla)
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkBuscaDoc_CheckedChanged(sender As Object, e As EventArgs) Handles chkBuscaDoc.CheckedChanged
        If chkBuscaDoc.Checked = True Then
            optFactura.Enabled = True
            optGuia.Enabled = True

            optFactura.Checked = True
            optGuia.Checked = False
            txtDocumento.Enabled = True
        Else
            optFactura.Enabled = False
            optGuia.Enabled = False
            txtDocumento.Enabled = False
            txtDocumento.Text = "0"
        End If
    End Sub
End Class