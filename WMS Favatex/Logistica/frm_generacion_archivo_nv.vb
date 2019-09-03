Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class frm_generacion_archivo_nv
    Private _cnn As String

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_generacion_archivo_nv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call CARGA_COMBO_CLIENTE()
    End Sub

    Private Sub CARGA_COMBO_CLIENTE()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE_TODOS(_msg)
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Function PintaCeldaEnRojo(ByVal fila As Integer) As Boolean
        Try
            Grilla.Item(0, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(0, fila).Style.ForeColor = Color.Red

            Grilla.Item(1, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(1, fila).Style.ForeColor = Color.Red

            Grilla.Item(2, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(2, fila).Style.ForeColor = Color.Red

            Grilla.Item(3, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(3, fila).Style.ForeColor = Color.Red

            Grilla.Item(4, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(4, fila).Style.ForeColor = Color.Red

            Grilla.Item(5, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(5, fila).Style.ForeColor = Color.Red

            Grilla.Item(6, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(6, fila).Style.ForeColor = Color.Red

            Grilla.Item(7, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(7, fila).Style.ForeColor = Color.Red

            Grilla.Item(8, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(8, fila).Style.ForeColor = Color.Red

            Grilla.Item(9, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(9, fila).Style.ForeColor = Color.Red

            Grilla.Item(10, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(10, fila).Style.ForeColor = Color.Red

            Grilla.Item(11, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(11, fila).Style.ForeColor = Color.Red

            Grilla.Item(12, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(12, fila).Style.ForeColor = Color.Red

            Grilla.Item(13, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(13, fila).Style.ForeColor = Color.Red

            Grilla.Item(14, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(14, fila).Style.ForeColor = Color.Red

            Grilla.Item(15, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(15, fila).Style.ForeColor = Color.Red

            Grilla.Item(16, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(16, fila).Style.ForeColor = Color.Red

            Grilla.Item(17, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(17, fila).Style.ForeColor = Color.Red

            Grilla.Item(18, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            Grilla.Item(18, fila).Style.ForeColor = Color.Red



            PintaCeldaEnRojo = True
        Catch ex As Exception
            PintaCeldaEnRojo = False
            MessageBox.Show(ex.Message, "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


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

            If cmbCliente.Text = "" Then
                classPicking.car_codigo = 0
            Else
                classPicking.car_codigo = cmbCliente.SelectedValue
            End If

            If chkProcesados.Checked = True Then
                classPicking.oc_procesadas = 1
            Else
                classPicking.oc_procesadas = 0
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = classPicking.LISTADO_ORDENES_PARA_ARCHIVO_NV(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_rut") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_fila"),
                                            False,
                                            ds.Tables(0).Rows(Fila)("car_rut"),
                                            ds.Tables(0).Rows(Fila)("fecha"),
                                            ds.Tables(0).Rows(Fila)("vendedor"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("sku_nombre"),
                                            ds.Tables(0).Rows(Fila)("pic_cantidad_encontrada"),
                                            ds.Tables(0).Rows(Fila)("precio"),
                                            ds.Tables(0).Rows(Fila)("bodega"),
                                            ds.Tables(0).Rows(Fila)("tpi_nombre"),
                                            ds.Tables(0).Rows(Fila)("glosa_pago"),
                                            ds.Tables(0).Rows(Fila)("forma_pago"),
                                            ds.Tables(0).Rows(Fila)("sucursal"),
                                            ds.Tables(0).Rows(Fila)("dcto_lineal"),
                                            ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("oc_fecha_emision"),
                                            ds.Tables(0).Rows(Fila)("pic_enarchivo_nv"))

                            If Grilla.Item(18, Fila).Value = 1 Then
                                Grilla.Item(16, Fila).Style.BackColor = Color.FromArgb(173, 8, 8)
                                Grilla.Item(16, Fila).Style.ForeColor = Color.White ' Color.FromArgb(253, 49, 49)
                            End If

                            If Grilla.Item(7, Fila).Value.ToString = "CODIGO SIN HOMOLOGAR" Then
                                PintaCeldaEnRojo(Fila)
                            End If



                            'If Grilla.Item(14, Fila).Value = True Then
                            '    Grilla.Item(14, Fila).Style.BackColor = Color.FromArgb(173, 8, 8)
                            '    'Grilla.Item(2, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)
                            'End If


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

                    End If
                End If
                Me.Text = "Generación de archivo para Notas de Ventas - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonSelecciona_Click(sender As Object, e As EventArgs) Handles ButtonSelecciona.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(2).Value = True
        Next
    End Sub

    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(2).Value = False
        Next
    End Sub

    Private Sub ButtonExportar_Click(sender As Object, e As EventArgs) Handles ButtonExportar.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0
        Dim contador As Integer = 0

        Try

            For Each row As DataGridViewRow In Grilla.Rows
                If row.Cells(2).Value = True Then
                    If Trim(row.Cells(7).Value.ToString) = "CODIGO SIN HOMOLOGAR" Then
                        contador = contador + 1
                    End If
                End If
            Next

            If contador > 0 Then
                MessageBox.Show("En la selección existen codigos sin homologar, no se ejecutara la generación del archivo hasta corregir la observación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                                + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            If ACTUALIZA_REGISTRO_PROCESADO() = False Then
                Exit Sub
            End If

            'class_comunes.ExportarExcel(Me.Grilla)
            Call ExportarDatosExcel(Me.Grilla, "LISTADO DE PRODUCTOS")
            Call CARGA_GRILLA()
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ACTUALIZA_REGISTRO_PROCESADO() As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0

        Try
            ACTUALIZA_REGISTRO_PROCESADO = False
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                For Each row As DataGridViewRow In Grilla.Rows
                    If row.Cells(2).Value = True Then
                        classPicking.pic_codigo = row.Cells(0).Value
                        classPicking.pic_fila = row.Cells(1).Value
                        ds = classPicking.MARCA_FILAS_PROCESADAS_EN_ARCHIVO_NV(_msgError, conexion)
                        If _msgError <> "" Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            ds = Nothing
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Function
                        Else
                            If ds.Tables(0).Rows(0)("codigo") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                ds = Nothing
                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Function
                            End If
                        End If
                    End If


                Next

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                conexion.Close()
                ACTUALIZA_REGISTRO_PROCESADO = True
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            ''Encabezado  
            '.Range("A1:L1").Merge()
            '.Range("A1:L1").Value = "COMERCIAL FAVATEX"
            '.Range("A1:L1").Font.Bold = True
            '.Range("A1:L1").Font.Size = 15
            ''Copete  
            '.Range("A2:L2").Merge()
            '.Range("A2:L2").Value = titulo
            '.Range("A2:L2").Font.Bold = True
            '.Range("A2:L2").Font.Size = 12

            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 1
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

            DataGridView1.Columns(2).Visible = False

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
                If reg.Cells(2).Value = True Then
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
                End If
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

            DataGridView1.Columns(2).Visible = True

        End With

        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click

    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(2)
        If e.ColumnIndex = Me.Grilla.Columns.Item(2).Index Then
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class