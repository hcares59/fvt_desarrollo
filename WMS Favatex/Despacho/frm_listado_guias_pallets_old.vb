Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_listado_guias_pallets
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_listado_guias_pallets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
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
            classEmbarque.numGuia = IIf(txtDocumento.Text = "", "-", txtDocumento.Text)
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

            _msg = ""

            Grilla.Rows.Clear()
            ds = classEmbarque.listado_guias_pallets(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("emb_sello") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("emb_seleccion"),
                                            ds.Tables(0).Rows(Fila)("emb_sello"),
                                            ds.Tables(0).Rows(Fila)("fecha_despacho_desde"),
                                            ds.Tables(0).Rows(Fila)("fecha_despacho_hasta"),
                                            ds.Tables(0).Rows(Fila)("dep_num_guia"),
                                            ds.Tables(0).Rows(Fila)("dep_pallets")
                                            )
                            Fila = Fila + 1
                        Loop

                    End If
                    lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                End If
                Me.Text = "LISTADO DE GUIAS POR PALLETS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
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

    Private Sub txtDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocumento.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        Try
            Dim frm As frm_imprimir = New frm_imprimir
            Dim classEmbarque As class_embarque = New class_embarque
            Dim ds As DataSet = New DataSet
            Dim _msgError As String = ""
            Dim conexion As New SqlConnection(_cnn)
            Dim scopeOptions = New TransactionOptions()


            Dim nombreInforme = "rptInformeGuiaPallet2.rpt"
            Dim Seleccionados As String = ""

            Me.Cursor = Cursors.WaitCursor

            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    Seleccionados = Seleccionados + CStr(row.Cells(1).Value).ToString + ","
                End If
            Next

            If Seleccionados = "" Then
                MessageBox.Show("Debe seleccionar a lo menos una orden de despacho", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            frm.nombreReporte = nombreInforme
            frm.Origen = "IGP"

            frm.strCadena = Seleccionados
            frm.ShowDialog()

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = True
        Next
    End Sub

    Private Sub ButtonDesm_Click(sender As Object, e As EventArgs) Handles ButtonDesm.Click
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If Grilla.Rows(e.RowIndex).Cells(0).Value Then
                Grilla.Rows(e.RowIndex).Cells(0).Value = False
            Else

                Grilla.Rows(e.RowIndex).Cells(0).Value = True
            End If

        Catch ex As Exception
            'Message
        End Try
    End Sub
End Class