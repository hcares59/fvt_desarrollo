Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class frm_edicion_guias_pallets
    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""
    Private _cnn As String
    Private _emb_sello As String
    Private _dep_num_guia As Long

    Public Property emb_sello() As String
        Get
            Return _emb_sello
        End Get
        Set(ByVal value As String)
            _emb_sello = value
        End Set
    End Property
    Public Property dep_num_guia() As Long
        Get
            Return _dep_num_guia
        End Get
        Set(ByVal value As Long)
            _dep_num_guia = value
        End Set
    End Property
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_edicion_guias_pallets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grilla.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grilla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grilla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grilla.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grilla.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grilla.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grilla.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        If dep_num_guia <> 0 And emb_sello <> 0 Then
            lbl_guia_despacho.Text = "GUIA DESPACHO: " + dep_num_guia.ToString
            lbl_sello.Text = "SELLO: " + emb_sello
            Call carga_detalle_guia()
        End If
    End Sub

    Sub carga_detalle_guia()
        Dim classEmbarque As class_embarque = New class_embarque
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classEmbarque.cnn = _cnn
            classEmbarque.emb_sello = emb_sello
            classEmbarque.numGuia = dep_num_guia
            _msg = ""
            grilla.Rows.Clear()
            ds = classEmbarque.listado_detalle_guias_pallets(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("emb_sello") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grilla.Rows.Add(ds.Tables(0).Rows(Fila)("emb_sello"),
                                            ds.Tables(0).Rows(Fila)("pal_codigo_interno"),
                                            ds.Tables(0).Rows(Fila)("pal_descripcion"),
                                            ds.Tables(0).Rows(Fila)("fecha_despacho_desde"),
                                            ds.Tables(0).Rows(Fila)("fecha_despacho_hasta"),
                                            ds.Tables(0).Rows(Fila)("dep_num_guia"),
                                            ds.Tables(0).Rows(Fila)("dep_pallets"),
                                            ds.Tables(0).Rows(Fila)("dep_cantidad_retorno"))
                            Fila = Fila + 1
                        Loop
                        grilla.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grilla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grilla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grilla.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grilla.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grilla.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grilla.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    End If
                    'lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                End If
                Me.Text = "LISTADO DE GUIAS POR PALLETS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub grilla_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grilla.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub
    Private Sub validar_Keypress(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna  
        Dim columna As Integer = grilla.CurrentCell.ColumnIndex
        Dim valor As Integer = grilla.CurrentCell.Value
        If columna = 7 Then
            Dim caracter As Char = e.KeyChar
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                Me.Text = e.KeyChar
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub

    Private Sub grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        Dim cantRetorno As Integer = grilla.Rows(e.RowIndex).Cells(7).Value
        Dim cantGuia As Integer = grilla.Rows(e.RowIndex).Cells(6).Value
        If cantRetorno > cantGuia Then
            MessageBox.Show("cantidad en retorno no puede superar a cantidad original", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            grilla.Rows(e.RowIndex).Cells(7).Value = 0
        End If
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        Dim classEmbarque As class_embarque = New class_embarque
        Dim _msgError As String = ""
        Dim sum_pallets, sum_retorno As Long
        Dim ds As DataSet = New DataSet
        Dim conexion As New SqlConnection(_cnn)
        Try
            classEmbarque.dep_cod_retorno = 1 'RETORNO PENDIENTE
            For Each row As DataGridViewRow In Me.grilla.Rows
                sum_pallets = sum_pallets + row.Cells(6).Value
                sum_retorno = sum_retorno + row.Cells(7).Value
            Next
            If sum_pallets = sum_retorno Then
                classEmbarque.dep_cod_retorno = 2 'RETORNO COMPLETO
            Else
                classEmbarque.dep_cod_retorno = 3 'RETORNO INCOMPLETO
            End If
            For Each row As DataGridViewRow In Me.grilla.Rows
                classEmbarque.emb_sello = row.Cells(0).Value
                classEmbarque.emb_codigointerno = row.Cells(1).Value
                classEmbarque.numGuia = row.Cells(5).Value
                classEmbarque.emb_cantidad = CInt(row.Cells(7).Value)
                ds = classEmbarque.palet_retorno_actualiza_registro(_msgError, conexion)
            Next
            MessageBox.Show("Los datos fueron guardados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
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


            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Call ExportarDatosExcel(grilla, "DETALE DE GUIAS DE DESPACHO DE PALLETS NUMERO : " & dep_num_guia)
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


End Class