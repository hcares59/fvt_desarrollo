Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_listado_ordenes_pk_listado
    Private _cnn As String

    Const COL_ASI_COD As Integer = 0
    Const COL_ASI_STR As Integer = 1
    Const COL_ASI_FEC As Integer = 2
    Const COL_COD_EST As Integer = 3
    Const COL_ASI_EST As Integer = 4
    Const COL_ASI_PIC As Integer = 5
    Const COL_ASI_RES As Integer = 6
    Const COL_ASI_VER As Integer = 7

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_ordenes_pk_listado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        Call CARGA_COMBO_ESTADOS()

        lblTotal.Text = "Total de registros: 0"
        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized

        chkFecha.Checked = 0
        dtpFechaOCHasta.Value = GLO_FECHA_SISTEMA
        dtpFechaOCDesde.Value = GLO_FECHA_SISTEMA

        lblTotal.Text = ""
        Call CONFIGURA_COLUMNAS()
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
    End Sub

    Private Sub CARGA_COMBO_ESTADOS()
        Dim _msg As String
        Try
            Dim classPicking As class_picking = New class_picking
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classPicking.cnn = _cnn
            _msg = ""
            ds = classPicking.CARGA_COMBO_ESTADO_ASIGNACION_PK(_msg)
            If _msg = "" Then
                Me.cmbEstado.DataSource = ds.Tables(0)
                Me.cmbEstado.DisplayMember = "MENSAJE"
                Me.cmbEstado.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ESTADOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA()
        Dim class_PK As class_picking = New class_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Dim diaASDesde As String = ""
        Dim mesASDesde As String = ""

        Dim diaASHasta As String = ""
        Dim mesASHasta As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            class_PK.cnn = _cnn
            class_PK.abp_codigo = 0

            If cmbEstado.Text = "" Then
                class_PK.abp_estado = 0
            Else
                class_PK.abp_estado = cmbEstado.SelectedValue
            End If

            If chkFecha.Checked = True Then
                'desde
                If CStr(dtpFechaOCDesde.Value.Month).Length = 1 Then
                    mesASDesde = Trim("0" + CStr(dtpFechaOCDesde.Value.Month))
                Else
                    mesASDesde = CStr(dtpFechaOCDesde.Value.Month)
                End If

                If CStr(dtpFechaOCDesde.Value.Day).Length = 1 Then
                    diaASDesde = Trim("0" + CStr(dtpFechaOCDesde.Value.Day))
                Else
                    diaASDesde = CStr(dtpFechaOCDesde.Value.Day)
                End If

                'Hasta
                If CStr(dtpFechaOCHasta.Value.Month).Length = 1 Then
                    mesASHasta = Trim("0" + CStr(dtpFechaOCHasta.Value.Month))
                Else
                    mesASHasta = CStr(dtpFechaOCHasta.Value.Month)
                End If

                If CStr(dtpFechaOCHasta.Value.Day).Length = 1 Then
                    diaASHasta = Trim("0" + CStr(dtpFechaOCHasta.Value.Day))
                Else
                    diaASHasta = CStr(dtpFechaOCHasta.Value.Day)
                End If

                class_PK.fecha_ingreso_desde = CStr(dtpFechaOCDesde.Value.Year) + mesASDesde + diaASDesde
                class_PK.fecha_ingreso_hasta = CStr(dtpFechaOCHasta.Value.Year) + mesASHasta + diaASHasta
            Else
                class_PK.fecha_ingreso_desde = "19000101"
                class_PK.fecha_ingreso_hasta = "20501231"
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = class_PK.ASIGNACIONES_PARA_PICKING_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("abp_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("abp_codigo"),
                                            ds.Tables(0).Rows(Fila)("abp_codigostring"),
                                            CDate(ds.Tables(0).Rows(Fila)("abp_fecha")),
                                            ds.Tables(0).Rows(Fila)("abp_estado"),
                                            ds.Tables(0).Rows(Fila)("abp_estadonombre"),
                                            ds.Tables(0).Rows(Fila)("abp_picking"),
                                            ds.Tables(0).Rows(Fila)("abp_asignado"),
                                            "")
                            Fila = Fila + 1
                        Loop

                        Call CONFIGURA_COLUMNAS()

                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString

                    End If
                End If
                Me.Text = "LISTADO DE ORDENES DE PICKEO - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
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
        Dim frm As frm_oden_para_picking = New frm_oden_para_picking
        frm.cnn = _cnn
        frm.dab_codigo = 0
        frm.ShowDialog()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = COL_ASI_VER Then
                If Grilla.Rows(e.RowIndex).Cells(COL_ASI_STR).Value <> "" Then
                    Dim frm As frm_oden_para_picking = New frm_oden_para_picking
                    frm.cnn = _cnn
                    frm.dab_codigo = Grilla.Rows(e.RowIndex).Cells(COL_ASI_COD).Value
                    frm.ShowDialog()
                    Call CARGA_GRILLA()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class