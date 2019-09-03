Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class frm_dev_buscar_prodecto_por_documento
    Private _cnn As String
    Private _car_codigo As Integer

    Const COL_SELECCION As Integer = 0
    Const COL_CAR_CODIGO As Integer = 1
    Const COL_CODIGO_INTERNO As Integer = 2
    Const COL_NOMBRE_FAVATEX As Integer = 3
    Const COL_SKU_CLIENTE As Integer = 4
    Const COL_SKU_NOMBRE As Integer = 5
    Const COL_CANTIDAD As Integer = 6
    Const COL_FILA As Integer = 7
    Const COL_OCOMPRA As Integer = 8
    Const COL_NPICKING As Integer = 9
    Const COL_NFACTURA As Integer = 10
    Const COL_NGD As Integer = 11
    Const COL_CODUNICO As Integer = 12
    Const COL_CANTIDAD_O As Integer = 13
    Const COL_NBXU As Integer = 14
    Const COL_TBULTO As Integer = 15
    Const COL_COD_INT_ORI As Integer = 16
    Const COL_PRO_CODIGO As Integer = 17
    Const COL_CODIGO_UNICO As Integer = 18
    Const COL_FILA_DEV As Integer = 19
    Const COL_PDD_FILA As Integer = 20
    Const COL_EMB_SELLO As Integer = 21

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property car_codigo() As Integer
        Get
            Return _car_codigo
        End Get
        Set(ByVal value As Integer)
            _car_codigo = value
        End Set
    End Property

    Private Sub frm_dev_buscar_prodecto_por_documento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub INICIALIZA()
        Me.Grilla.ClearSelection()
        Me.Grilla.Columns(3).Frozen = True


    End Sub

    Private Sub CARGA_GRILLA()
        Dim classDev As class_despacha_picking = New class_despacha_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classDev.cnn = _cnn
            classDev.car_codigo = _car_codigo
            classDev.numero = txtNumero.Text

            If RadioFactura.Checked = True Then
                classDev.tipo = "FA"
            ElseIf RadioGuia.Checked = True Then
                classDev.tipo = "GD"
            End If
            _msg = ""
            Grilla.Rows.Clear()
            ds = classDev.SELECCIONA_DETALLE_DOCUMENTO_DEVOLUCION(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False, ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                            ds.Tables(0).Rows(Fila)("pic_cantidad_encontrada"),
                                            ds.Tables(0).Rows(Fila)("pic_fila"),
                                            ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("fac_numero"),
                                            ds.Tables(0).Rows(Fila)("gd_numero"),
                                            ds.Tables(0).Rows(Fila)("codigo_unico"),
                                            ds.Tables(0).Rows(Fila)("cant_original"),
                                            ds.Tables(0).Rows(Fila)("num_bul_unidad"),
                                            ds.Tables(0).Rows(Fila)("total_bulto"),
                                            ds.Tables(0).Rows(Fila)("pro_codigooriginal"),
                                            ds.Tables(0).Rows(Fila)("pro_codigo"), 0, ds.Tables(0).Rows(Fila)("pic_filadevuelta"),
                                            ds.Tables(0).Rows(Fila)("pdd_fila"),
                                            ds.Tables(0).Rows(Fila)("emb_sello"))
                            Fila = Fila + 1
                        Loop
                    Else
                        MessageBox.Show("No existen items en el decumento para ser devueltos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    Call PINTA_FILA_GRILLA()
                End If
                Me.Text = "FORMULARIO DEVOLUCIÓN INTERNO - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub PINTA_FILA_GRILLA()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(COL_FILA_DEV).Value = True Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
                row.DefaultCellStyle.ForeColor = Color.Orange
            End If
        Next
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim respuesta As Integer = 0
        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(COL_FILA_DEV).Value = True And row.Cells(0).Value = True Then
                respuesta = MessageBox.Show("Dentro de la selección existen registros que ya fueron devueltos, " _
                                 + Chr(10) + "¿Desea sacarlos de la selección para continuar con la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbNo Then
                    Exit Sub
                End If

                For Each row2 As DataGridViewRow In Me.Grilla.Rows
                    If row2.Cells(COL_FILA_DEV).Value = True Then
                        row2.Cells(0).Value = False
                    End If
                Next
            End If
        Next


        Call SELECCIONA_PRODUCTOS()
        Me.Dispose()
    End Sub

    Private Sub SELECCIONA_PRODUCTOS()

        listaDetalleProductos = New List(Of estructura_dev_productos)()

        Try
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(COL_SELECCION).Value = True Then
                    listaDetalleProductos.Add(New estructura_dev_productos(row.Cells(COL_NPICKING).Value,
                                            row.Cells(COL_CAR_CODIGO).Value,
                                            row.Cells(COL_PRO_CODIGO).Value,
                                            row.Cells(COL_CODIGO_INTERNO).Value,
                                            row.Cells(COL_NOMBRE_FAVATEX).Value,
                                            row.Cells(COL_SKU_CLIENTE).Value,
                                            row.Cells(COL_SKU_NOMBRE).Value,
                                            row.Cells(COL_CANTIDAD).Value,
                                            row.Cells(COL_FILA).Value,
                                            row.Cells(COL_OCOMPRA).Value,
                                            row.Cells(COL_NFACTURA).Value,
                                            row.Cells(COL_NGD).Value,
                                            row.Cells(COL_CANTIDAD_O).Value,
                                            row.Cells(COL_NBXU).Value,
                                            row.Cells(COL_TBULTO).Value,
                                            row.Cells(COL_COD_INT_ORI).Value,
                                            row.Cells(COL_CODUNICO).Value,
                                            row.Cells(COL_PDD_FILA).Value,
                                            row.Cells(COL_EMB_SELLO).Value))
                End If
            Next
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        listaDetalleProductos = New List(Of estructura_dev_productos)()
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        If txtNumero.Text = "" Then
            MessageBox.Show("Debe ingresar el número del documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumero.Focus()
            Exit Sub
        End If

        Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub ButtonTodos_Click(sender As Object, e As EventArgs) Handles ButtonTodos.Click
        Call MARCAR_TODOS()
    End Sub
    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            'If row.Cells(COL_FILA_DEV).Value = False Then
            row.Cells(0).Value = True
            'End If
        Next
    End Sub
    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub
    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    'Private Sub frm_dev_buscar_prodecto_por_documento_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    '    listaDetalleProductos = New List(Of estructura_dev_productos)()
    'End Sub
End Class