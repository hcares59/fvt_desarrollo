Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frm_informe_devoluciones_por_tipo
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_informe_devoluciones_por_tipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
    End Sub
    Private Sub INICIALIZA()
        Call carga_combo_cliente()
        lblTotal.Text = "Total de registros: 0"

        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized
        'Me.Grilla.Columns(3).Frozen = True
        GLO_FECHA_SISTEMA = Date.Today
        dtpDevolucionDesde.Value = GLO_FECHA_SISTEMA
        lblTotal.Text = ""
    End Sub
    Private Sub carga_combo_cliente()
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
    Private Sub Carga_grilla()
        Dim class_informes As class_informes = New class_informes
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Dim diaDevolucionesDesde As String = ""
        Dim mesDevolucionesDesde As String = ""
        Dim mesDevolucionesHasta As String = ""
        Dim diaDevolucionesHasta As String = ""


        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            ds = Nothing
            class_informes.cnn = _cnn

            If cmbCliente.SelectedValue = 0 Then
                class_informes.car_codigo = 0
            Else
                class_informes.car_codigo = cmbCliente.SelectedValue
            End If



            'fecha devolucion desde
            If chkDevolucion.Checked = True Then
                If CStr(dtpDevolucionDesde.Value.Month).Length = 1 Then
                    mesDevolucionesDesde = Trim("0" + CStr(dtpDevolucionDesde.Value.Month))
                Else
                    mesDevolucionesDesde = CStr(dtpDevolucionDesde.Value.Month)
                End If

                If CStr(dtpDevolucionDesde.Value.Day).Length = 1 Then
                    diaDevolucionesDesde = Trim("0" + CStr(dtpDevolucionDesde.Value.Day))
                Else
                    diaDevolucionesDesde = CStr(dtpDevolucionDesde.Value.Day)
                End If

                class_informes.str_fechaDesde = CStr(dtpDevolucionDesde.Value.Year) + mesDevolucionesDesde + diaDevolucionesDesde


                'fecha devolucion hasta
                If CStr(dtpDevolucionesHasta.Value.Month).Length = 1 Then
                    mesDevolucionesHasta = Trim("0" + CStr(dtpDevolucionesHasta.Value.Month))
                Else
                    mesDevolucionesHasta = CStr(dtpDevolucionesHasta.Value.Month)
                End If

                If CStr(dtpDevolucionesHasta.Value.Day).Length = 1 Then
                    diaDevolucionesHasta = Trim("0" + CStr(dtpDevolucionesHasta.Value.Day))
                Else
                    diaDevolucionesHasta = CStr(dtpDevolucionesHasta.Value.Day)
                End If
                class_informes.str_fechaHasta = CStr(dtpDevolucionesHasta.Value.Year) + mesDevolucionesHasta + diaDevolucionesHasta

            Else
                class_informes.str_fechaDesde = "19000101"
                class_informes.str_fechaHasta = "20501231"
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = class_informes.carga_grilla_listado_devoluciones(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") <> "0" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("dev_fecha"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("dev_ocompra"),
                                            ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("dev_nfactura"),
                                            ds.Tables(0).Rows(Fila)("dev_nguia"),
                                            ds.Tables(0).Rows(Fila)("tdv_nombre"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "LISTADO DE ORDENES DE COMRPA - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            Cursor = System.Windows.Forms.Cursors.Default
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call Carga_grilla()
    End Sub
    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
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
            Call ExportarDatosExcel(Grilla, "LISTADO DEVOLUCIONES")
            Cursor = System.Windows.Forms.Cursors.Default


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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

    Private Sub chkDevolucion_CheckedChanged(sender As Object, e As EventArgs) Handles chkDevolucion.CheckedChanged
        If chkDevolucion.Checked = True Then
            dtpDevolucionDesde.Enabled = True
            dtpDevolucionesHasta.Enabled = True
        Else
            dtpDevolucionDesde.Enabled = False
            dtpDevolucionesHasta.Enabled = False
        End If
    End Sub
End Class