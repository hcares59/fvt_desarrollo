Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_listado_ordenes_abastecimiento
    Private _cnn As String

    Const COL_NUMERO As Integer = 0
    Const COL_OBSERVACION As Integer = 1
    Const COL_FECHA As Integer = 2
    Const COL_COD_ESTADO As Integer = 3
    Const COL_ESTADO As Integer = 4
    Const COL_ABRIR As Integer = 5

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property


    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        TxtFechaDesde.Enabled = chkFecha.Checked
        txtFechaHasta.Enabled = chkFecha.Checked
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub FORMATEA_GRILLA()
        Grilla.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
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

            classUbicacion.oab_codigo = 0

            If cmbEstado.Text = "" Then
                classUbicacion.eab_codigo = 0
            Else
                classUbicacion.eab_codigo = cmbEstado.SelectedValue
            End If

            If txtCodigoUnico.Text = "" Then
                classUbicacion.pro_codigointerno = "-"
            Else
                classUbicacion.pro_codigointerno = txtCodigoUnico.Text
            End If

            If chkFecha.Checked = True Then
                'desde
                If CStr(TxtFechaDesde.Value.Month).Length = 1 Then
                    mesOCDesde = Trim("0" + CStr(TxtFechaDesde.Value.Month))
                Else
                    mesOCDesde = CStr(TxtFechaDesde.Value.Month)
                End If

                If CStr(TxtFechaDesde.Value.Day).Length = 1 Then
                    diaOCDesde = Trim("0" + CStr(TxtFechaDesde.Value.Day))
                Else
                    diaOCDesde = CStr(TxtFechaDesde.Value.Day)
                End If

                'Hasta
                If CStr(txtFechaHasta.Value.Month).Length = 1 Then
                    mesOCHasta = Trim("0" + CStr(txtFechaHasta.Value.Month))
                Else
                    mesOCHasta = CStr(txtFechaHasta.Value.Month)
                End If

                If CStr(txtFechaHasta.Value.Day).Length = 1 Then
                    diaOCHasta = Trim("0" + CStr(txtFechaHasta.Value.Day))
                Else
                    diaOCHasta = CStr(txtFechaHasta.Value.Day)
                End If

                classUbicacion.fecha_desde = CStr(TxtFechaDesde.Value.Year) + mesOCDesde + diaOCDesde
                classUbicacion.Fecha_hasta = CStr(txtFechaHasta.Value.Year) + mesOCHasta + diaOCHasta
            Else
                classUbicacion.fecha_desde = "19000101"
                classUbicacion.Fecha_hasta = "20501231"
            End If


            _msg = ""
            Grilla.Rows.Clear()
            ds = classUbicacion.ORDEN_ABASTECIMIENTO_LISTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codEstado") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("codigo"),
                                            ds.Tables(0).Rows(Fila)("observacion"),
                                            ds.Tables(0).Rows(Fila)("fecha"),
                                            ds.Tables(0).Rows(Fila)("codEstado"),
                                            ds.Tables(0).Rows(Fila)("estado"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString

                    End If
                End If
                Me.Text = "LISTADO DE ORDENES DE ABASTECIMIENTO - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Call FORMATEA_GRILLA()

        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frm_listado_ordenes_abastecimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call CARGA_COMBO_ORDEN_ABASTECIMIENTO()
        Call FORMATEA_GRILLA()
    End Sub

    Private Sub CARGA_COMBO_ORDEN_ABASTECIMIENTO()
        Dim _msg As String
        Try
            Dim classOrden As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classOrden.cnn = _cnn
            _msg = ""
            ds = classOrden.CARGA_COMBO_ESTADO_ORDEN_ABASTECIMIENTO(_msg)
            If _msg = "" Then
                Me.cmbEstado.DataSource = ds.Tables(0)
                Me.cmbEstado.DisplayMember = "MENSAJE"
                Me.cmbEstado.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ORDEN_ABASTECIMIENTO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = COL_ABRIR Then
                Dim frm As frm_abastecimiento_para_pk = New frm_abastecimiento_para_pk
                frm.cnn = _cnn
                frm.oab_codigo = CInt(Grilla.Rows(e.RowIndex).Cells(COL_NUMERO).Value)
                frm.eab_codigo = Grilla.Rows(e.RowIndex).Cells(COL_COD_ESTADO).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class