Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frm_visor_devoluciones
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_visor_devoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        dtpCompromisoHasta.Value = Date.Today
        dtpCompromisoDesde.Value = DateAdd(DateInterval.Month, -1, Date.Today)
        Call CARGA_COMBO_CLIENTE()
        Call CARGA_GRILLA()
        Call carga_grilla_devoluciones_detalles()
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

    Private Sub CARGA_GRILLA()
        Dim classDevolucion As class_devolucion = New class_devolucion

        Dim mesIngresoDesde As String = ""
        Dim diaIngresoDesde As String = ""
        Dim mesIngresoHasta As String = ""
        Dim diaIngresoHasta As String = ""
        Dim mesCompromisoDesde As String = ""
        Dim diaCompromisoDesde As String = ""
        Dim mesCompromisoHasta As String = ""
        Dim diaCompromisoHasta As String = ""

        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classDevolucion.cnn = _cnn

            If cmbCliente.Text = "" Then
                classDevolucion.car_codigo = 0
            Else
                classDevolucion.car_codigo = cmbCliente.SelectedValue
            End If

            If chkCompromiso.Checked = True Then
                'fecha compromiso desde
                If CStr(dtpCompromisoDesde.Value.Month).Length = 1 Then
                    mesCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Month))
                Else
                    mesCompromisoDesde = CStr(dtpCompromisoDesde.Value.Month)
                End If

                If CStr(dtpCompromisoDesde.Value.Day).Length = 1 Then
                    diaCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Day))
                Else
                    diaCompromisoDesde = CStr(dtpCompromisoDesde.Value.Day)
                End If

                classDevolucion.fecha_desde = CStr(dtpCompromisoDesde.Value.Year) + mesCompromisoDesde + diaCompromisoDesde

                'fecha ingreso hasta
                If CStr(dtpCompromisoHasta.Value.Month).Length = 1 Then
                    mesCompromisoHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Month))
                Else
                    mesCompromisoHasta = CStr(dtpCompromisoHasta.Value.Month)
                End If

                If CStr(dtpCompromisoHasta.Value.Day).Length = 1 Then
                    diaCompromisoHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Day))
                Else
                    diaCompromisoHasta = CStr(dtpCompromisoHasta.Value.Day)
                End If

                classDevolucion.fecha_hasta = CStr(dtpCompromisoHasta.Value.Year) + mesCompromisoHasta + diaCompromisoHasta
            Else
                classDevolucion.fecha_desde = "19000101"
                classDevolucion.fecha_hasta = "20501231"
            End If


            lblTotRegistro.Text = "Registros encontrados: 0"
            _msg = ""
            Grilla.Rows.Clear()
            ds = classDevolucion.DEVOLUCIONES_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("dev_codigo"),
                                            ds.Tables(0).Rows(Fila)("dev_numero"),
                                            ds.Tables(0).Rows(Fila)("dev_numfactura"),
                                            ds.Tables(0).Rows(Fila)("dev_nguia"),
                                            ds.Tables(0).Rows(Fila)("dev_fecha"),
                                            ds.Tables(0).Rows(Fila)("dev_fechadevolucion"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("dev_observacion"),
                                            ds.Tables(0).Rows(Fila)("dev_cantproducto"))
                            Fila = Fila + 1
                        Loop
                        lblTotRegistro.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "DEVOLUCION DE PRODUCTOS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Call CARGA_GRILLA()
        Call carga_grilla_devoluciones_detalles()
    End Sub

    Private Sub carga_grilla_devoluciones_detalles()
        Dim classDevolucion As class_devolucion = New class_devolucion

        Dim mesIngresoDesde As String = ""
        Dim diaIngresoDesde As String = ""
        Dim mesIngresoHasta As String = ""
        Dim diaIngresoHasta As String = ""
        Dim mesCompromisoDesde As String = ""
        Dim diaCompromisoDesde As String = ""
        Dim mesCompromisoHasta As String = ""
        Dim diaCompromisoHasta As String = ""

        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classDevolucion.cnn = _cnn

            If cmbCliente.Text = "" Then
                classDevolucion.car_codigo = 0
            Else
                classDevolucion.car_codigo = cmbCliente.SelectedValue
            End If

            If chkCompromiso.Checked = True Then
                'fecha compromiso desde
                If CStr(dtpCompromisoDesde.Value.Month).Length = 1 Then
                    mesCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Month))
                Else
                    mesCompromisoDesde = CStr(dtpCompromisoDesde.Value.Month)
                End If

                If CStr(dtpCompromisoDesde.Value.Day).Length = 1 Then
                    diaCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Day))
                Else
                    diaCompromisoDesde = CStr(dtpCompromisoDesde.Value.Day)
                End If

                classDevolucion.fecha_desde = CStr(dtpCompromisoDesde.Value.Year) + mesCompromisoDesde + diaCompromisoDesde

                'fecha ingreso hasta
                If CStr(dtpCompromisoHasta.Value.Month).Length = 1 Then
                    mesCompromisoHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Month))
                Else
                    mesCompromisoHasta = CStr(dtpCompromisoHasta.Value.Month)
                End If

                If CStr(dtpCompromisoHasta.Value.Day).Length = 1 Then
                    diaCompromisoHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Day))
                Else
                    diaCompromisoHasta = CStr(dtpCompromisoHasta.Value.Day)
                End If

                classDevolucion.fecha_hasta = CStr(dtpCompromisoHasta.Value.Year) + mesCompromisoHasta + diaCompromisoHasta
            Else
                classDevolucion.fecha_desde = "19000101"
                classDevolucion.fecha_hasta = "20501231"
            End If


            lblTotRegistro.Text = "Registros encontrados: 0"
            _msg = ""
            Gril_Dev_Detalles.Rows.Clear()
            ds = classDevolucion.devolucion_detalle_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("dev_codigo") <> 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Gril_Dev_Detalles.Rows.Add(ds.Tables(0).Rows(Fila)("dev_codigo"),
                                            ds.Tables(0).Rows(Fila)("dev_numero"),
                                            ds.Tables(0).Rows(Fila)("pic_codigostr"),
                                            ds.Tables(0).Rows(Fila)("dev_numfactura"),
                                            ds.Tables(0).Rows(Fila)("dev_nguia"),
                                            ds.Tables(0).Rows(Fila)("dev_ocompra"),
                                            ds.Tables(0).Rows(Fila)("dev_fecha"),
                                            ds.Tables(0).Rows(Fila)("dev_fechadevolucion"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("dev_cantproducto"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("dev_observacion"),
                                            ds.Tables(0).Rows(Fila)("observacion"))
                            Fila = Fila + 1
                        Loop
                        lblTotRegistro.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "DEVOLUCION DE PRODUCTOS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Dim frm As frm_devolucion_importaciones = New frm_devolucion_importaciones
        frm.cnn = _cnn
        frm.ShowDialog()

    End Sub

    Private Sub chkCompromiso_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompromiso.CheckedChanged
        If chkCompromiso.Checked = True Then
            dtpCompromisoDesde.Enabled = True
            dtpCompromisoHasta.Enabled = True
        Else
            dtpCompromisoDesde.Enabled = False
            dtpCompromisoHasta.Enabled = False
        End If
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 10 Then
                Dim frm As frm_devolucion_importaciones = New frm_devolucion_importaciones
                frm.cnn = _cnn
                frm.dev_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 11 Then
                Dim frm As frm_imprimir = New frm_imprimir
                frm.Origen = "FD"
                frm.dev_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            respuesta = MessageBox.Show("¿Desea exportar listado de devoluciones con detalle?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbYes Then

                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call ExportarDatosExcel(Gril_Dev_Detalles, "LISTADO DETALLADO DEVOLUCIONES DE PRODUCTOS")
                Cursor = System.Windows.Forms.Cursors.Default
            Else
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call ExportarDatosExcel(Grilla, "LISTADO DEVOLUCIONES DE PRODUCTOS")
                'class_comunes.ExportarExcel(Me.Grilla)
                Cursor = System.Windows.Forms.Cursors.Default
            End If
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

End Class