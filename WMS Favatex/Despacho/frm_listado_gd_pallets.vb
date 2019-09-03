Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class frm_listado_gd_pallets
    Private _cnn As String

    Const COL_SEL As Integer = 0
    Const COL_SELLO As Integer = 1
    Const COL_FDESPACHO As Integer = 2
    Const COL_FRETORNO As Integer = 3
    Const COL_CLIENTE As Integer = 4
    Const COL_ESTADO As Integer = 5
    Const COL_NGUIA As Integer = 6
    Const COL_TPALLET As Integer = 7
    Const COL_TPALLETR As Integer = 8
    Const COL_BTNEDITAR As Integer = 9

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_gd_pallets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call CARGA_COMBO_CLIENTES()
        Call CARGA_COMBO_CLIENTES_R()
        Call CARGA_COMBO_CLIENTES_B()
        Call JUSTIFICA_GRILLA_POR_RETORNO()
        Call JUSTIFICA_GRILLA_POR_RENDIR()
    End Sub

    Private Sub CARGA_COMBO_CLIENTES_B()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet
            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
            If _msg = "" Then
                Me.cmbClienteB.DataSource = ds.Tables(0)
                Me.cmbClienteB.DisplayMember = "MENSAJE"
                Me.cmbClienteB.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CLIENTES_B", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_CLIENTES_R()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet
            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
            If _msg = "" Then
                Me.cmbClienteR.DataSource = ds.Tables(0)
                Me.cmbClienteR.DisplayMember = "MENSAJE"
                Me.cmbClienteR.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CLIENTES_R", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_CLIENTES()
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
            MsgBox(ex.Message + " " + "CARGA_COMBO_CLIENTE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub carga_grilla()
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
            If cmbCliente.Text = "" Then
                classEmbarque.car_codigo = 0
            Else
                classEmbarque.car_codigo = cmbCliente.SelectedValue
            End If

            classEmbarque.emb_sello = IIf(txtSello.Text = "", "-", txtSello.Text)
            classEmbarque.numGuia = IIf(txtDocumento.Text = "", "0", txtDocumento.Text)
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

                If CStr(dtpHasta.Value.Day).Length = 1 Then
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
                            Grilla.Rows.Add(False, ds.Tables(0).Rows(Fila)("emb_sello"),
                                            ds.Tables(0).Rows(Fila)("emb_fechaingreso"),
                                            ds.Tables(0).Rows(Fila)("emb_fechadespacho"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("dep_nom_retorno"),
                                            ds.Tables(0).Rows(Fila)("dep_num_guia"),
                                            ds.Tables(0).Rows(Fila)("dep_pallets"),
                                            ds.Tables(0).Rows(Fila)("dep_cantidad_retorno"))
                            Fila = Fila + 1
                        Loop
                        Call JUSTIFICA_GRILLA_POR_RETORNO()
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

    Private Sub JUSTIFICA_GRILLA_POR_RETORNO()
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
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonExportar_Click(sender As Object, e As EventArgs)

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

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = COL_SEL Then
                If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
                    Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
                    chkCell.Value = Not chkCell.Value
                End If

                'If Grilla.Rows(e.RowIndex).Cells(COL_SEL).Value Then
                '    Grilla.Rows(e.RowIndex).Cells(COL_SEL).Value = False
                'Else
                '    Grilla.Rows(e.RowIndex).Cells(COL_SEL).Value = True
                'End If

            ElseIf e.ColumnIndex = COL_BTNEDITAR Then
                Dim frm As frm_edicion_guias_pallets = New frm_edicion_guias_pallets
                frm.cnn = _cnn
                frm.dep_num_guia = Grilla.Rows(e.RowIndex).Cells(COL_NGUIA).Value
                frm.emb_sello = Grilla.Rows(e.RowIndex).Cells(COL_SELLO).Value
                frm.ShowDialog()
                Call carga_grilla()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonLimpiar_Click(sender As Object, e As EventArgs) Handles ButtonLimpiar.Click
        txtSello.Text = ""
        cmbCliente.SelectedValue = 0
        Me.txtDocumento.Text = 0

        Me.Grilla.DataSource = Nothing
        Me.Grilla.Rows.Clear()
    End Sub

    Private Sub txtDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocumento.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonDesm_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub chkDespacho_CheckedChanged(sender As Object, e As EventArgs) Handles chkDespacho.CheckedChanged
        If chkDespacho.Checked = True Then
            dtpDesde.Enabled = True
            dtpHasta.Enabled = True
        ElseIf chkDespacho.Checked = False Then
            dtpDesde.Enabled = False
            dtpHasta.Enabled = False
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Call carga_grilla()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(COL_SEL).Value = True
        Next
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(COL_SEL).Value = False
        Next
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
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
                If row.Cells(COL_SEL).Value = True Then
                    Seleccionados = Seleccionados + CStr(row.Cells(COL_SELLO).Value).ToString + ","
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

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0

        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                               + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If


            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Call ExportarDatosExcel(Grilla, "LISTADO DE GUIAS DE DESPACHO DE PALLETS")
            Cursor = System.Windows.Forms.Cursors.Default


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA_POR_RENDIR()
    End Sub

    Private Sub CARGA_GRILLA_POR_RENDIR()
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
            Me.Cursor = Cursors.WaitCursor
            ds = Nothing
            classEmbarque.cnn = _cnn

            If cmbClienteR.Text = "" Then
                classEmbarque.car_codigo = 0
            Else
                classEmbarque.car_codigo = cmbClienteR.SelectedValue
            End If
            If txtNumSelloR.Text = "" Then
                classEmbarque.emb_sello = "-"
            Else
                classEmbarque.emb_sello = txtNumSelloR.Text

            End If
            If txtNumGuaR.Text = "" Then
                classEmbarque.emb_nguia = 0
            Else
                classEmbarque.emb_nguia = txtNumGuaR.Text
            End If
            If chkDespachoR.Checked = True Then
                If CStr(dtpDesdeR.Value.Month).Length = 1 Then
                    mesDesde = Trim("0" + CStr(dtpDesdeR.Value.Month))
                Else
                    mesDesde = CStr(dtpDesdeR.Value.Month)
                End If

                If CStr(dtpDesdeR.Value.Day).Length = 1 Then
                    diaDesde = Trim("0" + CStr(dtpDesdeR.Value.Day))
                Else
                    diaDesde = CStr(dtpDesdeR.Value.Day)
                End If
                classEmbarque.fecha_despacho_desde = CStr(dtpDesdeR.Value.Year) + mesDesde + diaDesde

                'fecha ingreso hasta
                If CStr(dtpHastaR.Value.Month).Length = 1 Then
                    mesHasta = Trim("0" + CStr(dtpHastaR.Value.Month))
                Else
                    mesHasta = CStr(dtpHastaR.Value.Month)
                End If

                If CStr(dtpHastaR.Value.Day).Length = 1 Then
                    diaHasta = Trim("0" + CStr(dtpHastaR.Value.Day))
                Else
                    diaHasta = CStr(dtpHastaR.Value.Day)
                End If
                classEmbarque.fecha_despacho_hasta = CStr(dtpHastaR.Value.Year) + mesHasta + diaHasta
            Else
                classEmbarque.fecha_despacho_desde = "19000101"
                classEmbarque.fecha_despacho_hasta = "20501231"
            End If
            _msg = ""
            GrillaPorRendir.Rows.Clear()
            ds = classEmbarque.LISTADO_GUIAS_PALLETS_RENDICION(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaPorRendir.Rows.Add(False, ds.Tables(0).Rows(Fila)("emb_sello"),
                                            ds.Tables(0).Rows(Fila)("emb_fechaingreso"),
                                            ds.Tables(0).Rows(Fila)("emb_fechaDespacho"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("dep_nom_retorno"),
                                            ds.Tables(0).Rows(Fila)("dep_num_guia"),
                                            ds.Tables(0).Rows(Fila)("dep_pallets"),
                                            ds.Tables(0).Rows(Fila)("dep_cantidad_retorno"))
                            Fila = Fila + 1
                        Loop
                        Call JUSTIFICA_GRILLA_POR_RENDIR()
                    End If
                    lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                End If
                Me.Text = "LISTADO DE GUIAS POR PALLETS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub JUSTIFICA_GRILLA_POR_RENDIR()
        GrillaPorRendir.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaPorRendir.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaPorRendir.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaPorRendir.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaPorRendir.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaPorRendir.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaPorRendir.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaPorRendir.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaPorRendir.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub btnRendir_Click(sender As Object, e As EventArgs) Handles btnRendir.Click
        If txtNumVale.Text = "" Then
            MessageBox.Show("No se a ingresado numero de vale, favor verifica", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumVale.Focus()
            Exit Sub
        End If
        If DETALLE_MARCADAS() = False Then
            MessageBox.Show("No existen registros seleccionados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If vbYes = MessageBox.Show("¿Esta seguro(a) desea registrar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            Call RENDICION_GUIA_PALLETS()
            Call CARGA_GRILLA_POR_RENDIR()
        End If
    End Sub

    Private Sub RENDICION_GUIA_PALLETS()
        Dim classFactura As class_factura_picking = New class_factura_picking
        Dim ds As DataSet = New DataSet

        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim Fila As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                For Each row2 As DataGridViewRow In Me.GrillaPorRendir.Rows
                    If row2.Cells(0).Value = True Then
                        ds = Nothing
                        classFactura.val_numero = txtNumVale.Text
                        classFactura.car_codigo = cmbCliente.SelectedValue

                        classFactura.gde_numero = row2.Cells(6).Value
                        classFactura.emb_sello = row2.Cells(1).Value
                        ds = classFactura.MARCA_GUIAS_RENDIDAS(_msgError, conexion)
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
                    End If
                Next
                Transaccion.Complete()
                Transaccion.Dispose()
                txtNumVale.Text = ""
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Las guias de depacho de pallets, fueron rendidas en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function DETALLE_MARCADAS() As Boolean
        Dim Contador As Integer = 0
        Try
            DETALLE_MARCADAS = False

            For Each row As DataGridViewRow In Me.GrillaPorRendir.Rows
                If row.Cells(0).Value = True Then
                    Contador = Contador + 1
                End If
            Next

            If Contador > 0 Then
                DETALLE_MARCADAS = True
            End If

        Catch ex As Exception
            DETALLE_MARCADAS = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        For Each row As DataGridViewRow In Me.GrillaPorRendir.Rows
            row.Cells(0).Value = True
        Next
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        For Each row As DataGridViewRow In Me.GrillaPorRendir.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub chkDespachoR_CheckedChanged(sender As Object, e As EventArgs) Handles chkDespachoR.CheckedChanged
        If chkDespachoR.Checked = True Then
            dtpDesdeR.Enabled = True
            dtpHastaR.Enabled = True
        ElseIf chkDespachoR.Checked = False Then
            dtpDesdeR.Enabled = False
            dtpHastaR.Enabled = False
        End If
    End Sub

    Private Sub chk_rendicion_CheckedChanged(sender As Object, e As EventArgs) Handles chk_rendicion.CheckedChanged
        If chk_rendicion.Checked = True Then
            dtpRendicionDesde.Enabled = True
            dtpRendicionHasta.Enabled = True
        ElseIf chk_rendicion.Checked = False Then
            dtpRendicionDesde.Enabled = False
            dtpRendicionHasta.Enabled = False
        End If
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Call CARGA_GRILLAS_RENDIDAS()
    End Sub

    Private Sub CARGA_GRILLAS_RENDIDAS()

        Dim class_factura As class_factura_picking = New class_factura_picking
        Dim mesDesde As String = ""
        Dim diaDesde As String = ""
        Dim mesHasta As String = ""
        Dim diaHasta As String = ""
        Dim mesIngresoDesde As String = ""
        Dim diaIngresoDesde As String = ""

        Dim mesIngresoHasta As String = ""
        Dim diaIngresoHasta As String = ""

        If chk_rendicion.Checked = True Then

            If CStr(dtpRendicionDesde.Value.Month).Length = 1 Then
                mesDesde = Trim("0" + CStr(dtpRendicionDesde.Value.Month))
            Else
                mesDesde = CStr(dtpRendicionDesde.Value.Month)
            End If

            If CStr(dtpRendicionDesde.Value.Day).Length = 1 Then
                diaDesde = Trim("0" + CStr(dtpRendicionDesde.Value.Day))
            Else
                diaDesde = CStr(dtpRendicionDesde.Value.Day)
            End If
            class_factura.fecha_inicio = CStr(dtpRendicionDesde.Value.Year) + mesDesde + diaDesde

            'fecha ingreso hasta
            If CStr(dtpRendicionHasta.Value.Month).Length = 1 Then
                mesHasta = Trim("0" + CStr(dtpRendicionHasta.Value.Month))
            Else
                mesHasta = CStr(dtpRendicionHasta.Value.Month)
            End If

            If CStr(dtpRendicionHasta.Value.Day).Length = 1 Then
                diaHasta = Trim("0" + CStr(dtpRendicionHasta.Value.Day))
            Else
                diaHasta = CStr(dtpRendicionHasta.Value.Day)
            End If
            class_factura.fecha_hasta = CStr(dtpRendicionHasta.Value.Year) + mesHasta + diaHasta
        Else
            class_factura.fecha_inicio = "19000101"
            class_factura.fecha_hasta = "20501231"
        End If

        If CStr(dtpRendicionDesde.Value.Month).Length = 1 Then
            mesIngresoDesde = Trim("0" + CStr(dtpRendicionDesde.Value.Month))
        Else
            mesIngresoDesde = CStr(dtpRendicionDesde.Value.Month)
        End If

        If CStr(dtpRendicionDesde.Value.Day).Length = 1 Then
            diaIngresoDesde = Trim("0" + CStr(dtpRendicionDesde.Value.Day))
        Else
            diaIngresoDesde = CStr(dtpRendicionDesde.Value.Day)
        End If

        If txt_nro_vale.Text = "" Then
            class_factura.val_numero = 0
        Else
            class_factura.val_numero = txt_nro_vale.Text
        End If


        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_factura.cnn = _cnn

            If cmbCliente.Text = "" Then
                class_factura.car_codigo = 0
            Else
                class_factura.car_codigo = cmbCliente.SelectedValue
            End If

            _msg = ""
            GrillaRendidas.Rows.Clear()
            ds = class_factura.guias_rendidas_listado(_msg)
            If _msg = "" Then

                lblTotal.Text = "Cantidad de registros encontrados: 0"
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("dep_nro_vale") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count

                            GrillaRendidas.Rows.Add(ds.Tables(0).Rows(Fila)("dep_nro_vale"),
                                            ds.Tables(0).Rows(Fila)("emb_fec_rendicion"),
                                            ds.Tables(0).Rows(Fila)("emb_sello"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("emb_fechaingreso"),
                                            ds.Tables(0).Rows(Fila)("emb_fechadespacho"),
                                            ds.Tables(0).Rows(Fila)("dep_nom_retorno"),
                                            ds.Tables(0).Rows(Fila)("dep_num_guia"),
                                            ds.Tables(0).Rows(Fila)("dep_pallets"),
                                            ds.Tables(0).Rows(Fila)("dep_cantidad_retorno"),
                                            ds.Tables(0).Rows(Fila)("dep_cantidad_retorno"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\carga_registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_registro", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cmbClienteB.SelectedValue = 0
        chk_rendicion.Checked = False
        dtpRendicionDesde.Value = GLO_FECHA_SISTEMA
        dtpRendicionHasta.Value = GLO_FECHA_SISTEMA
        txt_nro_vale.Text = ""
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Try
            Dim mesRecepcionDesde As String = ""
            Dim diaRecepcionDesde As String = ""
            Dim mesRecepcionHasta As String = ""
            Dim diaRecepcionHasta As String = ""

            If CStr(dtpRendicionDesde.Value.Month).Length = 1 Then
                mesRecepcionDesde = Trim("0" + CStr(dtpRendicionDesde.Value.Month))
            Else
                mesRecepcionDesde = CStr(dtpRendicionDesde.Value.Month)
            End If

            If CStr(dtpRendicionDesde.Value.Day).Length = 1 Then
                diaRecepcionDesde = Trim("0" + CStr(dtpRendicionDesde.Value.Day))
            Else
                diaRecepcionDesde = CStr(dtpRendicionDesde.Value.Day)
            End If

            If CStr(dtpRendicionHasta.Value.Month).Length = 1 Then
                mesRecepcionHasta = Trim("0" + CStr(dtpRendicionHasta.Value.Month))
            Else
                mesRecepcionHasta = CStr(dtpRendicionHasta.Value.Month)
            End If

            If CStr(dtpRendicionHasta.Value.Day).Length = 1 Then
                diaRecepcionHasta = Trim("0" + CStr(dtpRendicionHasta.Value.Day))
            Else
                diaRecepcionHasta = CStr(dtpRendicionHasta.Value.Day)
            End If



            Dim frm As frm_imprimir = New frm_imprimir
            frm.Origen = "IRG"

            If cmbCliente.Text = "" Then
                frm.car_codigo = 0
            Else
                frm.car_codigo = cmbCliente.SelectedValue
            End If
            If chk_rendicion.Checked = True Then
                frm.strFechaDesde = CStr(dtpRendicionDesde.Value.Year) + mesRecepcionDesde + diaRecepcionDesde
                frm.strFechaHasta = CStr(dtpRendicionHasta.Value.Year) + mesRecepcionHasta + diaRecepcionHasta
            Else
                frm.strFechaDesde = "19000101"
                frm.strFechaHasta = "20501231"
            End If

            If txt_nro_vale.Text = "" Then
                frm.val_numero = 0
            Else
                frm.val_numero = txt_nro_vale.Text
            End If

            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrillaPorRendir_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaPorRendir.CellContentClick
        If e.ColumnIndex = Me.GrillaPorRendir.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaPorRendir.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub GrillaRendidas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaRendidas.CellContentClick

    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0
        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                                + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            class_comunes.ExportarExcel(Me.GrillaRendidas)
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class