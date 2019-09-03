Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_solicitud_picking
    Private _cnn As String
    Dim dtTree As DataTable = New DataTable
    Dim NodeRightClick As String
    Dim bodegas As String = ""
    Dim sentencia As String = "AND c.con_despachara IN("
    Dim _pic_codigo As Integer = 0
    Dim _car_codigo As Integer = 0

    Const CON_SELECCION As Integer = 0
    Const CON_CAR_CODIGO As Integer = 1
    Const CON_CON_OCNUMERO As Integer = 2
    Const CON_CODIGO_INTERNO As Integer = 3
    Const CON_NOMBRE_FAVATEX As Integer = 4
    Const CON_SKU As Integer = 5
    Const CON_SKU_NOMBRE As Integer = 6
    Const CON_CANTIDAD As Integer = 7
    Const CON_NUM_BULTO As Integer = 8
    Const CON_TOTAL_BULTO As Integer = 9
    Const CON_PRECIOCOL As Integer = 10
    Const CON_CUMPLE_DIA_PLAZO As Integer = 11

    Dim DIAS_ANTICIPO As Integer = 3 'este se modificara por el configurado en el maestro de configuraciones
    Dim cargaPrimeraVez As Boolean = False

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_solicitud_picking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaPrimeraVez = False
        Call INICIALIZA()
        'Tree.Nodes.Clear()
        'FillTestTable()
        'CreateTree()
        Me.WindowState = FormWindowState.Maximized
        'Tree.ExpandAll()
        cargaPrimeraVez = True
    End Sub

    Private Sub INICIALIZA()
        DIAS_ANTICIPO = 5
        GLO_FECHA_SISTEMA = Date.Today
        chkConFecha.Checked = True
        txtFechaDesde.Value = DateAdd(DateInterval.Day, DIAS_ANTICIPO, GLO_FECHA_SISTEMA)
        lblBodegas.Text = ""
        Me.Grilla.Columns(4).Frozen = True
        Me.Grilla2.Columns(4).Frozen = True
        Call CARGA_COMBO_CLIENTE()
        If cmbCliente.Text <> "" Then
            Call CARGA_GRILLA_FECHAS()
        End If

    End Sub

    Private Sub CARGA_COMBO_CLIENTE()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
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
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_BOLETA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_BODEGAS()
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classSolicitud.cnn = _cnn
            classSolicitud.car_codigo = cmbCliente.SelectedValue

            'If Tree.SelectedNode.Name.Length > 1 Then
            '    TestPos = InStr(1, Tree.SelectedNode.Name, SearchChar, CompareMethod.Text)
            '    classSolicitud.car_codigo = Mid(Tree.SelectedNode.Name, 1, (TestPos - 1))
            'Else
            '    classSolicitud.car_codigo = Tree.SelectedNode.Name
            'End If

            _msg = ""
            GrillaBodegas.Rows.Clear()
            ds = classSolicitud.CARGA_COMBO_BODEGA(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("mensaje") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaBodegas.Rows.Add(True, ds.Tables(0).Rows(Fila)("mensaje"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_COMBO_BODEGAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_BODEGAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub FillTestTable()
        Dim menu As class_solicitud_picking = New class_solicitud_picking
        Dim Msg As String = ""
        Dim mes As String = ""
        Dim dia As String = ""

        Dim i As Integer
        Try

            If CStr(txtFechaDesde.Value.Month).Length = 1 Then
                mes = Trim("0" + CStr(txtFechaDesde.Value.Month))
            Else
                mes = CStr(txtFechaDesde.Value.Month)
            End If

            If CStr(txtFechaDesde.Value.Day).Length = 1 Then
                dia = Trim("0" + CStr(txtFechaDesde.Value.Day))
            Else
                dia = CStr(txtFechaDesde.Value.Day)
            End If

            menu.cnn = _cnn
            If chkConFecha.Checked = True Then
                menu.fecha_busqueda = CStr(txtFechaDesde.Value.Year) + mes + dia
            Else
                menu.fecha_busqueda = "19000101"
            End If

            dtTree = menu.MENU_BUSCA_MENUS(Msg)

            If dtTree.Rows(i).Item("descripcion").ToString = "" Then
                Exit Sub
            End If

            For i = 0 To dtTree.Rows.Count - 1
                Dim ID1 As String = dtTree.Rows(i).Item("codigo").ToString
                dtTree.Rows(i).Item("LEVEL") = FindLevel(ID1, 0)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function FindLevel(ByVal ID As String, ByRef Level As Integer) As Integer
        Dim i As Integer

        For i = 0 To dtTree.Rows.Count - 1
            Dim ID1 As String = dtTree.Rows(i).Item("codigo").ToString
            Dim Parent1 As String = dtTree.Rows(i).Item("codigo_padre").ToString

            If ID = ID1 Then
                If Parent1 = "" Then
                    Return Level
                Else
                    Level += 1
                    FindLevel(Parent1, Level)
                End If
            End If
        Next

        Return Level
    End Function

    Private Sub CreateTree()
        Dim MaxLevel1 As Integer = CInt(dtTree.Compute("MAX(LEVEL)", ""))

        Dim i, j As Integer

        For i = 0 To MaxLevel1
            Dim Rows1() As DataRow = dtTree.Select("LEVEL = " & i)

            For j = 0 To Rows1.Count - 1
                Dim ID1 As String = Rows1(j).Item("codigo").ToString
                Dim Name1 As String = Rows1(j).Item("descripcion").ToString
                Dim Parent1 As String = Rows1(j).Item("codigo_padre").ToString

                If Parent1 = "0" Then
                    Tree.Nodes.Add(ID1, Name1, 0, 0)
                Else
                    Dim TreeNodes1() As TreeNode = Tree.Nodes.Find(Parent1, True)

                    If TreeNodes1.Length > 0 Then
                        TreeNodes1(0).Nodes.Add(ID1, Name1, 1, 1)
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub CARGA_GRILLA(ByVal fechaDesde As Date, ByVal fechaHasta As Date)
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim mes2 As String = ""
        Dim dia2 As String = ""
        Dim car_codigo As Integer = 0
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim fecha As String = ""

        Try

            classSolicitud.cnn = _cnn
            If CStr(fechaHasta.Month).Length = 1 Then
                mes = Trim("0" + CStr(fechaHasta.Month))
            Else
                mes = CStr(fechaHasta.Month)
            End If

            If CStr(fechaHasta.Day).Length = 1 Then
                dia = Trim("0" + CStr(fechaHasta.Day))
            Else
                dia = CStr(fechaHasta.Day)
            End If


            If CStr(fechaDesde.Month).Length = 1 Then
                mes2 = Trim("0" + CStr(fechaDesde.Month))
            Else
                mes2 = CStr(fechaDesde.Month)
            End If

            If CStr(fechaDesde.Day).Length = 1 Then
                dia2 = Trim("0" + CStr(fechaDesde.Day))
            Else
                dia2 = CStr(fechaDesde.Day)
            End If


            If bodegas = "" Then
                classSolicitud.bodega = "-"
            Else
                classSolicitud.bodega = sentencia
            End If
            classSolicitud.fecha_busqueda = CStr(fechaHasta.Year) + mes + dia
            classSolicitud.fecha_inicio = CStr(fechaDesde.Year) + mes2 + dia2
            classSolicitud.car_codigo = cmbCliente.SelectedValue
            classSolicitud.estado = ESTADOS_PICKING.Pendiente

            ds = classSolicitud.CARGA_DETALLE_PARA_PICKING(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then

                    'Grilla.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("sku_cartera") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False, ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("con_cantidad"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_numerobulto"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_totalbulto"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("con_preciocosto"), 0),
                                            FormatDateTime(ds.Tables(0).Rows(Fila)("con_fechadespacho"), 2))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
                'Grilla.AutoResizeColumns()
                Call PINTA_GRILLA()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub CARGA_GRILLA_POR_CONFIRMAR(ByVal fechaDesde As Date, ByVal fechaHasta As Date)
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim mes2 As String = ""
        Dim dia2 As String = ""
        Dim car_codigo As Integer = 0
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim fecha As String = ""

        Try

            classSolicitud.cnn = _cnn
            If CStr(fechaHasta.Month).Length = 1 Then
                mes = Trim("0" + CStr(fechaHasta.Month))
            Else
                mes = CStr(fechaHasta.Month)
            End If

            If CStr(fechaHasta.Day).Length = 1 Then
                dia = Trim("0" + CStr(fechaHasta.Day))
            Else
                dia = CStr(fechaHasta.Day)
            End If


            If CStr(fechaDesde.Month).Length = 1 Then
                mes2 = Trim("0" + CStr(fechaDesde.Month))
            Else
                mes2 = CStr(fechaDesde.Month)
            End If

            If CStr(fechaDesde.Day).Length = 1 Then
                dia2 = Trim("0" + CStr(fechaDesde.Day))
            Else
                dia2 = CStr(fechaDesde.Day)
            End If


            If bodegas = "" Then
                classSolicitud.bodega = "-"
            Else
                classSolicitud.bodega = sentencia
            End If

            classSolicitud.fecha_busqueda = CStr(fechaHasta.Year) + mes + dia
            classSolicitud.fecha_inicio = CStr(fechaDesde.Year) + mes2 + dia2
            classSolicitud.car_codigo = cmbCliente.SelectedValue
            classSolicitud.estado = ESTADOS_PICKING.Por_confirmar

            ds = classSolicitud.CARGA_DETALLE_PARA_PICKING(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then

                    Grilla2.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("sku_cartera") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla2.Rows.Add(False, ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("con_cantidad"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_numerobulto"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_totalbulto"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("con_preciocosto"), 0),
                                            IIf(VALIDA_DIAS_PLAZO(ds.Tables(0).Rows(Fila)("car_codigo"), ds.Tables(0).Rows(Fila)("con_fechadespacho")) = False, 1, 0),
                                            FormatDateTime(ds.Tables(0).Rows(Fila)("con_fechadespacho"), 2))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
                'Grilla2.AutoResizeColumns()
                Call PINTA_FUERA_DE_PLAZO()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_POR_CONFIRMAR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_POR_CONFIRMAR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function VALIDA_DIAS_PLAZO(ByVal car_codigo As Integer, ByVal fecha As Date) As Boolean
        Dim classCartera As class_cartera = New class_cartera
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        'Dim fechaActual As Date
        Dim diasCalculado As Integer = 0

        VALIDA_DIAS_PLAZO = False
        Try
            classCartera.cnn = _cnn
            classCartera.car_codigo = car_codigo
            'fechaActual = Date.Now

            ds = classCartera.CARTERA_SELECCIONA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        diasCalculado = DateDiff(DateInterval.Day, GLO_FECHA_SISTEMA, fecha)
                        If diasCalculado > ds.Tables(0).Rows(Fila)("dias_plazo_entrega") Then
                            VALIDA_DIAS_PLAZO = True
                        End If
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\VALIDA_DIAS_PLAZO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                VALIDA_DIAS_PLAZO = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\VALIDA_DIAS_PLAZO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            VALIDA_DIAS_PLAZO = False
        End Try

    End Function

    Private Sub PINTA_GRILLA()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(CON_NOMBRE_FAVATEX).Value = "" Then
                row.DefaultCellStyle.BackColor = Color.MistyRose
                row.DefaultCellStyle.ForeColor = Color.Red
            End If

        Next
    End Sub

    Private Sub PINTA_FUERA_DE_PLAZO()
        For Each row As DataGridViewRow In Me.Grilla2.Rows

            If row.Cells(CON_CUMPLE_DIA_PLAZO).Value = 1 Then
                row.DefaultCellStyle.BackColor = Color.OldLace
                row.DefaultCellStyle.ForeColor = Color.Orange
            End If

        Next
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Tree.SelectedNode = Tree.Nodes(0)
        LabelCliente.Text = "Item seleccionado: " + Tree.Nodes(0).Text
        'Call CARGA_GRILLA()
        'Call CARGA_GRILLA_POR_CONFIRMAR()
        'Call SUMA_TOTALES_PLAZO_GRILLA2()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        Grilla.DataSource = Nothing
        Grilla.Rows.Clear()
        If chkConFecha.Checked = True Then
            txtFechaDesde.Enabled = True
        Else
            txtFechaDesde.Enabled = False
        End If
        Tree.Nodes.Clear()
        FillTestTable()
        CreateTree()
    End Sub

    'Private Sub Tree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree.AfterSelect
    '    Dim SearchChar As String = "-"
    '    Dim TestPos As Integer = 0
    '    If Tree.SelectedNode.Name.Length > 1 Then
    '        TestPos = InStr(1, Tree.SelectedNode.Name, SearchChar, CompareMethod.Text)
    '        _car_codigo = Mid(Tree.SelectedNode.Name, 1, (TestPos - 1))
    '    Else
    '        _car_codigo = Tree.SelectedNode.Name
    '    End If

    '    LabelCliente.Text = "Item seleccionado: " + Tree.SelectedNode.Text


    '    GrillaBodegas.Rows.Clear()
    '    bodegas = ""
    '    lblBodegas.Text = ""
    '    'Call CARGA_GRILLA()
    '    Call CARGA_COMBO_BODEGAS()
    '    Call CARGA_GRILLA_POR_CONFIRMAR()
    '    Call SUMA_TOTALES_PLAZO_GRILLA2()
    '    'Tree.SelectedNode = Tree.Nodes(0)
    'End Sub
    Private Sub chkConFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkConFecha.CheckedChanged

        If cargaPrimeraVez = False Then
            Exit Sub
        End If

        If chkConFecha.Checked = True Then
            txtFechaDesde.Enabled = True
            txtFechaDesde.Value = DateAdd(DateInterval.Day, 1, GLO_FECHA_SISTEMA)
        Else
            txtFechaDesde.Enabled = False
        End If

        'Tree.SelectedNode = Tree.Nodes(0)
        'LabelCliente.Text = "Item seleccionado: " + Tree.Nodes(0).Text
        'Tree.Nodes.Clear()
        'FillTestTable()
        'CreateTree()
        'Tree.SelectedNode = Tree.Nodes(0)

        If cmbCliente.Text <> "" Then
            Call CARGA_GRILLA_FECHAS()
        End If
        'Call CARGA_GRILLA()
        'Call CARGA_GRILLA_POR_CONFIRMAR()
        'Call SUMA_TOTALES_PLAZO_GRILLA2()
    End Sub

    Private Sub txtFechaDesde_ValueChanged_1(sender As Object, e As EventArgs) Handles txtFechaDesde.ValueChanged
        'Tree.Nodes.Clear()
        'FillTestTable()
        'CreateTree()
        'Tree.SelectedNode = Tree.Nodes(0)
        If cargaPrimeraVez = False Then
            Exit Sub
        End If

        If cmbCliente.Text <> "" Then
            Call CARGA_GRILLA_FECHAS()
        End If
        'Call CARGA_GRILLA()
        'Call CARGA_GRILLA_POR_CONFIRMAR()
        'Call SUMA_TOTALES_PLAZO_GRILLA2()
    End Sub

    Private Sub ButtonCheck_Click(sender As Object, e As EventArgs) Handles ButtonCheck.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(CON_NOMBRE_FAVATEX).Value <> "" Then
                row.Cells(CON_SELECCION).Value = True
            End If
        Next
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(CON_SELECCION).Value = False
        Next
    End Sub

    Private Sub ButtonUnCheck_Click(sender As Object, e As EventArgs) Handles ButtonUnCheck.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub ButtonConfirmar_Click(sender As Object, e As EventArgs) Handles ButtonConfirmar.Click
        Dim respuesta As Integer = 0

        If REGISTROS_SELECCIONADOS_GRILLA1() = 0 Then
            MessageBox.Show("No existen registros seleccionados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        respuesta = MessageBox.Show("¿Esta seguro(a) de confirmar los registors seleccionados para picking", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = vbYes Then
            Call CONFIRMA_ITEM()
            Call CARGA_GRILLAS()
            'Call CARGA_GRILLA()
            'Call CARGA_GRILLA_POR_CONFIRMAR()
            'Call SUMA_TOTALES_PLAZO_GRILLA2()
        End If
    End Sub

    Private Function REGISTROS_SELECCIONADOS_GRILLA1() As Integer
        Dim contador As Integer = 0
        REGISTROS_SELECCIONADOS_GRILLA1 = 0
        Try
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(CON_SELECCION).Value = True Then
                    contador = contador + 1
                End If
            Next

            Return contador
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Sub CONFIRMA_ITEM()
        Dim classPicking As class_solicitud_picking = New class_solicitud_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Try
            classPicking.cnn = _cnn
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(CON_SELECCION).Value = True Then
                    classPicking.car_codigo = row.Cells(CON_CAR_CODIGO).Value
                    classPicking.con_ocnumero = row.Cells(CON_CON_OCNUMERO).Value
                    classPicking.con_skucliente = row.Cells(CON_SKU).Value
                    classPicking.fecha = row.Cells(11).Value
                    classPicking.estado = ESTADOS_PICKING.Por_confirmar
                    ds = classPicking.ACTUALIZA_ESTADO(_msgError)
                    If ds.Tables(0).Rows.Count > 0 Then
                        If _msgError = "" Then
                            If ds.Tables(0).Rows(0)("CODIGO") <= 0 Then
                                ds = Nothing
                                MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub Grilla2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla2.CellContentClick
        If e.ColumnIndex = Me.Grilla2.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla2.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click
        Call MARCAR_TODOS_2()
    End Sub
    Private Sub MARCAR_TODOS_2()
        For Each row As DataGridViewRow In Me.Grilla2.Rows

            If row.Cells(CON_NOMBRE_FAVATEX).Value <> "" Then
                row.Cells(CON_SELECCION).Value = True
            End If
        Next
    End Sub
    Private Sub DESMARCAR_TODOS_2()
        For Each row As DataGridViewRow In Me.Grilla2.Rows
            row.Cells(CON_SELECCION).Value = False
        Next
    End Sub
    Private Sub ButtonDesm_Click(sender As Object, e As EventArgs) Handles ButtonDesm.Click
        Call DESMARCAR_TODOS_2()
    End Sub

    Private Sub ButtonDescartar_Click(sender As Object, e As EventArgs) Handles ButtonDescartar.Click
        Dim respuesta As Integer = 0
        If REGISTROS_SELECCIONADOS_GRILLA2_DESCARTAR() = 0 Then
            MessageBox.Show("No existen registros seleccionados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        respuesta = MessageBox.Show("¿Esta seguro(a) de descartar los registors seleccionados para picking", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = vbYes Then
            Call DESMARCAR_ITEM()
            Call CARGA_GRILLAS()
            'Call CARGA_GRILLA()
            'Call CARGA_GRILLA_POR_CONFIRMAR()
            'Call SUMA_TOTALES_PLAZO_GRILLA2()
        End If

    End Sub

    Private Function REGISTROS_SELECCIONADOS_GRILLA2_DESCARTAR() As Integer
        Dim contador As Integer = 0
        REGISTROS_SELECCIONADOS_GRILLA2_DESCARTAR = 0
        Try
            For Each row As DataGridViewRow In Me.Grilla2.Rows
                If row.Cells(CON_SELECCION).Value = True Then
                    contador = contador + 1
                End If
            Next

            Return contador
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub DESMARCAR_ITEM()
        Dim classPicking As class_solicitud_picking = New class_solicitud_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Try
            classPicking.cnn = _cnn
            For Each row As DataGridViewRow In Me.Grilla2.Rows
                If row.Cells(CON_SELECCION).Value = True Then
                    classPicking.car_codigo = row.Cells(CON_CAR_CODIGO).Value
                    classPicking.con_ocnumero = row.Cells(CON_CON_OCNUMERO).Value
                    classPicking.con_skucliente = row.Cells(CON_SKU).Value
                    classPicking.fecha = row.Cells(12).Value
                    classPicking.estado = ESTADOS_PICKING.Pendiente
                    ds = classPicking.ACTUALIZA_ESTADO(_msgError)
                    If ds.Tables(0).Rows.Count > 0 Then
                        If _msgError = "" Then
                            If ds.Tables(0).Rows(0)("CODIGO") <= 0 Then
                                ds = Nothing
                                MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonGeneraPicking_Click(sender As Object, e As EventArgs) Handles ButtonGeneraPicking.Click
        Dim respuesta As Integer

        If Trim(txtHora.Text) = ":" Then
            MessageBox.Show("Debe ingresar la hora de la cita de entrega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If REGISTROS_SELECCIONADOS_DIAS_PLAZO_GRILLA2() > 0 Then
            respuesta = MessageBox.Show("En los datos seleccionados existen registros cuya(s) fecha(s) de compromiso se encuentra(n) fuera de plazo con respecto a los dias de cuplimiento configurados para el cliente, " _
                            + Chr(10) + "¿Desea seguir con la operación de generar el picking?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If respuesta = vbYes Then
                Call GUARDA_DATOS()
            Else
                Exit Sub
            End If
        Else
            Call GUARDA_DATOS()
        End If

        Call CARGA_GRILLA_POR_CONFIRMAR(CDate("01-01-1900"), CDate("01-01-2050"))
        Call SUMA_TOTALES_PLAZO_GRILLA2()

    End Sub

    Private Sub GUARDA_DATOS()
        Dim classPicking As class_picking = New class_picking
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
        Dim classLog As LogEventos = New LogEventos
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim contadorfueraPlazo As Integer = 0
        Dim _newPicking As Integer = 0

        Try

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                Do While fila <= Grilla2.Rows.Count - 1
                    If Grilla2.Rows(fila).Cells(CON_CUMPLE_DIA_PLAZO).Value > 0 Then
                        contadorfueraPlazo = contadorfueraPlazo + 1
                    End If
                    fila = fila + 1
                Loop
                fila = 0

                classPicking.cnn = _cnn
                classPicking.pic_codigo = _newPicking
                classPicking.pic_fecha = GLO_FECHA_SISTEMA
                classPicking.car_codigo = cmbCliente.SelectedValue
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL

                If txtCantidad.Text = "" Or txtCantidad.Text = "-" Then
                    classPicking.cant_unidades = 0
                Else
                    classPicking.cant_unidades = CInt(txtCantidad.Text)
                End If

                If txtBultos.Text = "" Or txtBultos.Text = "-" Then
                    classPicking.cant_bultos = 0
                Else
                    classPicking.cant_bultos = CInt(txtBultos.Text)
                End If

                If txtBultos.Text = "" Or txtBultos.Text = "-" Then
                    classPicking.total_bultos = 0
                Else
                    classPicking.total_bultos = CInt(txtTotal.Text)
                End If

                classPicking.pic_hora = txtHora.Text

                If contadorfueraPlazo > 0 Then
                    classPicking.epc_codigo = ESTADOS_PICKING.Por_aprobar
                Else
                    classPicking.epc_codigo = ESTADOS_PICKING.Generado
                End If

                classPicking.pic_cantidad_encontrada = 0
                classPicking.pic_num_bultos_encontrado = 0
                classPicking.pic_total_bultos_encontrado = 0

                ds = classPicking.PICKING_GUARDA_DATOS_ENCABEZADO(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Sub
                    Else
                        _newPicking = ds.Tables(0).Rows(0)("CODIGO")
                    End If
                End If

                ds = Nothing
                ds = classPicking.PICKING_ELIMINA_DATOS_DETALLE(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Sub
                    End If
                End If

                ds = Nothing
                Do While fila <= Grilla2.Rows.Count - 1
                    classPicking.pic_codigo = _newPicking
                    classPicking.pro_codigo = Grilla2.Rows(fila).Cells(CON_CODIGO_INTERNO).Value
                    classPicking.pro_nombre = Grilla2.Rows(fila).Cells(CON_NOMBRE_FAVATEX).Value
                    classPicking.sku_cartera = Grilla2.Rows(fila).Cells(CON_SKU).Value
                    classPicking.sku_cartera_nombre = Grilla2.Rows(fila).Cells(CON_SKU_NOMBRE).Value
                    classPicking.cant_unidades = Grilla2.Rows(fila).Cells(CON_CANTIDAD).Value
                    classPicking.cant_bultos = Grilla2.Rows(fila).Cells(CON_NUM_BULTO).Value
                    classPicking.pic_total_bultos = Grilla2.Rows(fila).Cells(CON_TOTAL_BULTO).Value
                    classPicking.precio = Grilla2.Rows(fila).Cells(CON_PRECIOCOL).Value
                    classPicking.pic_cantidad_encontrada = 0
                    classPicking.pic_num_bultos_encontrado = 0
                    classPicking.pic_total_bultos_encontrado = 0

                    If Grilla2.Rows(fila).Cells(CON_CUMPLE_DIA_PLAZO).Value > 0 Then
                        contadorfueraPlazo = contadorfueraPlazo + 1
                    End If

                    ds = classPicking.PICKING_GUARDA_DATOS_DETALLE(_msg, conexion)
                    If _msg = "" Then
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
                        MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    ds = Nothing

                    classSolicitud.car_codigo = cmbCliente.SelectedValue
                    classSolicitud.con_ocnumero = Grilla2.Rows(fila).Cells(CON_CON_OCNUMERO).Value
                    classSolicitud.con_skucliente = Grilla2.Rows(fila).Cells(CON_SKU).Value
                    classSolicitud.fecha = Grilla2.Rows(fila).Cells(12).Value
                    classSolicitud.estado = ESTADOS_PICKING.Generado
                    ds = classSolicitud.ACTUALIZA_ESTADO(_msgError, conexion)
                    If ds.Tables(0).Rows.Count > 0 Then
                        If _msgError = "" Then
                            If ds.Tables(0).Rows(0)("CODIGO") <= 0 Then
                                ds = Nothing
                                MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                        End If
                    End If
                    fila = fila + 1
                Loop

                ds = Nothing

                classPicking.pic_codigo = _newPicking
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Picking generado AddressOf traves del B2B"
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Sub
                    End If
                End If


                'Call INGRESA_LOG(CODIGO_LOG_EVENTOS.LOG_INFORMACION, "Se genera el PICKING N°: " + _pic_codigo.ToString, "Sujerido de picking", GLO_USUARIO_ACTUAL, conexion)

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                If contadorfueraPlazo = 0 Then
                    MessageBox.Show("Se ha generado el picking N°: " + _newPicking.ToString + " en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Se ha generado el picking N°: " + _newPicking.ToString + " en forma correcta, para poder ejecutarse, primero debe ser aprobado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If



            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub INGRESA_LOG(ByVal TipoLog As Integer, ByVal LogDescripcion As String, ByVal LogAplicacion As String, ByVal LogUsuario As String, ByVal conexion As SqlConnection)
        Dim classLog As LogEventos = New LogEventos
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        classLog.log_tipo = TipoLog
        classLog.log_descripcion = LogDescripcion
        classLog.log_aplicacion = LogAplicacion
        classLog.log_usuario = LogUsuario

        ds = classLog.INGRESA_LOG_EVETOS(_msgError, conexion)
        If ds.Tables(0).Rows.Count > 0 Then
            If _msgError = "" Then
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    Call INGRESA_LOG(CODIGO_LOG_EVENTOS.LOG_ERROR, ds.Tables(0).Rows(0)("MENSAJE"), "CargaOrdenesB2BClientes", 1, conexion)
                    ds = Nothing
                    Exit Sub
                End If
            Else
                Call INGRESA_LOG(CODIGO_LOG_EVENTOS.LOG_ERROR, _msgError, "CargaOrdenesB2BClientes", 1, conexion)
                ds = Nothing
                Exit Sub
            End If
        End If

    End Sub


    Private Function REGISTROS_SELECCIONADOS_DIAS_PLAZO_GRILLA2() As Integer
        Dim contador As Integer = 0
        REGISTROS_SELECCIONADOS_DIAS_PLAZO_GRILLA2 = 0
        Try
            For Each row As DataGridViewRow In Me.Grilla2.Rows
                If row.Cells(CON_CUMPLE_DIA_PLAZO).Value > 0 Then
                    contador = contador + 1
                End If
            Next

            Return contador
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Sub SUMA_TOTALES_PLAZO_GRILLA2()
        Dim contador As Integer = 0
        Dim sumCantidad As Integer = 0
        Dim sumBulto As Integer = 0
        Dim sumBultoTotal As Integer = 0

        Try
            For Each row As DataGridViewRow In Me.Grilla2.Rows
                sumCantidad = sumCantidad + row.Cells(CON_CANTIDAD).Value
                sumBulto = sumBulto + row.Cells(CON_NUM_BULTO).Value
                sumBultoTotal = sumBultoTotal + row.Cells(CON_TOTAL_BULTO).Value
            Next

            txtCantidad.Text = FormatNumber(sumCantidad, 0)
            txtBultos.Text = FormatNumber(sumBulto, 0)
            txtTotal.Text = FormatNumber(sumBultoTotal, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub cmbBodega_SelectionChangeCommitted(sender As Object, e As EventArgs)
    '    'Call CARGA_GRILLA()
    '    Call CARGA_GRILLA_POR_CONFIRMAR()
    '    Call SUMA_TOTALES_PLAZO_GRILLA2()
    'End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonBod_Click(sender As Object, e As EventArgs) Handles ButtonBod.Click
        If PanelBodegas.Visible = False Then
            PanelBodegas.Visible = True
        ElseIf PanelBodegas.Visible = True Then
            PanelBodegas.Visible = False
        End If
    End Sub

    Private Sub ButtonSeleccionar_Click(sender As Object, e As EventArgs) Handles ButtonSeleccionar.Click
        Dim i As Integer = 0
        Dim contado As Integer = 0
        Dim nombreBodegas As String = ""

        bodegas = ""

        If GrillaBodegas.Rows.Count = 0 Then
            PanelBodegas.Visible = False
            Exit Sub
        End If

        i = 0
        Do While i <= GrillaBodegas.Rows.Count - 1
            If GrillaBodegas.Rows(i).Cells(0).Value = True Then
                contado = contado + 1
            End If
            i = i + 1
        Loop

        i = 0
        If contado > 0 Then
            'Do While i <= GrillaBodegas.ColumnCount - 1
            Do While i <= GrillaBodegas.Rows.Count - 1
                If GrillaBodegas.Rows(i).Cells(0).Value = True Then
                    If bodegas = "" Then
                        bodegas = "'" + GrillaBodegas.Rows(i).Cells(1).Value + "'"
                        nombreBodegas = GrillaBodegas.Rows(i).Cells(1).Value
                    Else
                        bodegas = bodegas + ", '" + GrillaBodegas.Rows(i).Cells(1).Value + "'"
                        nombreBodegas = nombreBodegas + " / " + GrillaBodegas.Rows(i).Cells(1).Value
                    End If
                End If
                i = i + 1
            Loop
            If bodegas <> "" And bodegas <> "-" Then
                sentencia = "AND c.con_despachara IN(" + bodegas + ")"
            End If
        End If
        i = 0

        If bodegas = "" Then
            lblBodegas.Text = ""
        Else
            lblBodegas.Text = nombreBodegas
        End If

        Call CARGA_GRILLAS()

        'Call CARGA_GRILLA()
        'Call CARGA_GRILLA_POR_CONFIRMAR()
        'Call SUMA_TOTALES_PLAZO_GRILLA2()

        PanelBodegas.Visible = False
    End Sub

    Private Sub cmbCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCliente.SelectionChangeCommitted
        Call CARGA_COMBO_BODEGAS()
        Call CARGA_GRILLA_FECHAS()
        Call CARGA_GRILLA_POR_CONFIRMAR(CDate("01-01-1900"), CDate("01-01-2050"))
        Call SUMA_TOTALES_PLAZO_GRILLA2()
    End Sub

    Private Sub CARGA_GRILLA_FECHAS()
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim mes2 As String = ""
        Dim dia2 As String = ""
        Try

            Grilla.DataSource = Nothing
            Grilla.Rows.Clear()

            classSolicitud.cnn = _cnn
            classSolicitud.car_codigo = cmbCliente.SelectedValue

            If chkConFecha.Checked = True Then
                If CStr(txtFechaDesde.Value.Month).Length = 1 Then
                    mes = Trim("0" + CStr(txtFechaDesde.Value.Month))
                Else
                    mes = CStr(txtFechaDesde.Value.Month)
                End If

                If CStr(txtFechaDesde.Value.Day).Length = 1 Then
                    dia = Trim("0" + CStr(txtFechaDesde.Value.Day))
                Else
                    dia = CStr(txtFechaDesde.Value.Day)
                End If

                classSolicitud.fecha_inicio = CStr(txtFechaDesde.Value.Year) + mes + dia
                classSolicitud.fecha_termino = CStr(txtFechaDesde.Value.Year) + mes + dia

            ElseIf chkConFecha.Checked = False Then
                If CStr(GLO_FECHA_SISTEMA.Month).Length = 1 Then
                    mes = Trim("0" + CStr(GLO_FECHA_SISTEMA.Month))
                Else
                    mes = CStr(GLO_FECHA_SISTEMA.Month)
                End If

                If CStr(GLO_FECHA_SISTEMA.Day).Length = 1 Then
                    dia = Trim("0" + CStr(GLO_FECHA_SISTEMA.Day))
                Else
                    dia = CStr(GLO_FECHA_SISTEMA.Day)
                End If

                classSolicitud.fecha_inicio = CStr(GLO_FECHA_SISTEMA.Year) + mes + dia
                classSolicitud.fecha_termino = "20501231"
            End If

            ds = classSolicitud.CARGA_GRILLA_FECHAS(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaFechas.Rows.Clear()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("con_cantOC") > 0 Then
                            GrillaFechas.Rows.Add(False, cmbCliente.SelectedValue, CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")).ToShortDateString,
                                                                       ds.Tables(0).Rows(Fila)("con_cantOC"))
                        End If

                        Fila = Fila + 1
                    Loop
                End If
                'Grilla.AutoResizeColumns()
                Call PINTA_GRILLA()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GrillaFechas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellContentClick
        'If e.ColumnIndex = Me.GrillaFechas.Columns.Item(0).Index Then
        '    Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaFechas.Rows(e.RowIndex).Cells(0)
        '    chkCell.Value = Not chkCell.Value
        'End If
    End Sub

    Private Sub GrillaFechas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellEnter
        'If e.RowIndex >= 0 Then
        '    If GrillaFechas.Rows(e.RowIndex).Cells(0).Value = True Then
        '        MessageBox.Show(GrillaFechas.Rows(e.RowIndex).Cells(2).Value)
        '    End If

        'End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLAS()
    End Sub


    Private Sub CARGA_GRILLAS()
        Dim fila As Integer = 0
        Grilla.DataSource = Nothing
        Grilla.Rows.Clear()
        For Each row As DataGridViewRow In Me.GrillaFechas.Rows
            If row.Cells(0).Value = True Then
                Call CARGA_GRILLA(row.Cells(2).Value, row.Cells(2).Value)
            End If
        Next
        Call CARGA_GRILLA_POR_CONFIRMAR(CDate("01-01-1900"), CDate("01-01-2050"))
        Call SUMA_TOTALES_PLAZO_GRILLA2()
        'Call CARGA_GRILLA()
        'Call CARGA_GRILLA_POR_CONFIRMAR()
        'Call SUMA_TOTALES_PLAZO_GRILLA2()
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub
End Class