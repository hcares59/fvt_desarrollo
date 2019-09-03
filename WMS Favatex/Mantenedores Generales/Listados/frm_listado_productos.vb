Imports Microsoft.Office.Interop
Public Class frm_listado_productos
    Private _cnn As String
    Dim _pro_codigo As Integer
    Dim cargaPrimeraVez As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaPrimeraVez = False
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Call INICIALIZA()
        cargaPrimeraVez = True
    End Sub

    Private Sub INICIALIZA()
        Me.WindowState = FormWindowState.Maximized
        lblTotal.Text = "Cantidad de registros encontrados: 0"

        cmbCategorias.DataSource = Nothing
        cmbCategorias.Items.Clear()

        cmbSubCategoria.DataSource = Nothing
        cmbSubCategoria.Items.Clear()

        Call CARGA_COMBO_CATEGORIAS()
        Call CARGA_GRILLA()
        Call CARGA_GRILLA_DETALLADO()
    End Sub

    Private Sub CARGA_GRILLA()
        Dim class_productos As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_productos.cnn = _cnn
            class_productos.pro_codigo = 0
            class_productos.todos = chkActivo.Checked
            class_productos.codigo_interno = IIf(txtCodigoInterno.Text = "", "-", txtCodigoInterno.Text)

            If cmbCategorias.Text = "" Then
                class_productos.cat_codigo = 0
            Else
                class_productos.cat_codigo = cmbCategorias.SelectedValue
            End If

            If cmbSubCategoria.Text = "" Then
                class_productos.sub_codigo = 0
            Else
                class_productos.sub_codigo = cmbSubCategoria.SelectedValue
            End If

            If chkConfigurar.Checked = True Then
                class_productos.pro_config = 1
            Else
                class_productos.pro_config = 0
            End If

            _msg = ""
            Grilla.Rows.Clear()
            ds = class_productos.PRODUCTOS_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("cat_nombre"),
                                            ds.Tables(0).Rows(Fila)("sub_nombre"),
                                            ds.Tables(0).Rows(Fila)("pro_color"),
                                            ds.Tables(0).Rows(Fila)("pro_numbultos"),
                                            ds.Tables(0).Rows(Fila)("pro_cantbultoing"),
                                            ds.Tables(0).Rows(Fila)("pro_activo"),
                                            0)

                            If ds.Tables(0).Rows(Fila)("pro_numbultos") = 0 Then
                                Grilla.Rows(Fila).DefaultCellStyle.BackColor = Color.LightSalmon
                                Grilla.Rows(Fila).DefaultCellStyle.ForeColor = Color.Black
                            End If

                            If ds.Tables(0).Rows(Fila)("pro_numbultos") > 0 Then
                                If ds.Tables(0).Rows(Fila)("pro_numbultos") > ds.Tables(0).Rows(Fila)("pro_cantbultoing") Then
                                    Grilla.Rows(Fila).DefaultCellStyle.BackColor = Color.NavajoWhite
                                    Grilla.Rows(Fila).DefaultCellStyle.ForeColor = Color.Black
                                End If
                            End If

                            Fila = Fila + 1
                        Loop

                    End If
                End If
                lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                Me.Text = "LISTADO DE PRODUCTOS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_CATEGORIAS()
        Dim _msg As String
        Try
            Dim class_categoria As class_categorias = New class_categorias
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_categoria.cnn = _cnn
            _msg = ""
            ds = class_categoria.CARGA_COMBO_CATEGORIA(_msg)
            If _msg = "" Then
                Me.cmbCategorias.DataSource = ds.Tables(0)
                Me.cmbCategorias.DisplayMember = "mensaje"
                Me.cmbCategorias.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CATEGORIAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbCategorias_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCategorias.SelectionChangeCommitted
        Call CARGA_COMBO_SUBCATEGORIAS()
    End Sub

    Private Sub CARGA_COMBO_SUBCATEGORIAS()
        Dim _msg As String
        Try
            Dim class_subcategoria As class_subcategoria = New class_subcategoria
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_subcategoria.cnn = _cnn
            class_subcategoria.cat_codigo = cmbCategorias.SelectedValue
            _msg = ""
            ds = class_subcategoria.CARGA_COMBO_SUBCATEGORIA(_msg)
            If _msg = "" Then
                Me.cmbSubCategoria.DataSource = ds.Tables(0)
                Me.cmbSubCategoria.DisplayMember = "mensaje"
                Me.cmbSubCategoria.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_SUBCATEGORIAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_ingreso_productos = New frm_ingreso_productos
        frm.cnn = _cnn
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 10 Then
                Dim frm As frm_ingreso_productos = New frm_ingreso_productos
                frm.cnn = _cnn
                frm.pro_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 11 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Call ELIMINA_REGISTRO(Grilla.Rows(e.RowIndex).Cells(0).Value)
                End If
            End If

            If Grilla.Rows(e.RowIndex).Cells(9).Value Then
                Grilla.Rows(e.RowIndex).Cells(9).Value = False
            Else
                Grilla.Rows(e.RowIndex).Cells(9).Value = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ELIMINA_REGISTRO(ByVal Codigo As Integer)
        Dim class_producto As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""
        Dim respuesta As Integer = 0

        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                               + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            respuesta = MessageBox.Show("¿Desea exportar listado de productos con detalle?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbYes Then

                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call ExportarDatosExcel(grilla_det, "LISTADO DETALLADO PRODUCTOS")
                Cursor = System.Windows.Forms.Cursors.Default
            Else
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call ExportarDatosExcel(Grilla, "LISTADO PRODUCTOS")
                'class_comunes.ExportarExcel(Me.Grilla)
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    ds = Nothing
        '    class_producto.cnn = _cnn
        '    class_producto.pro_codigo = Codigo

        '    ds = class_producto.ELIMINA_REGISTRO(_msgError)
        '    If _msgError <> "" Then
        '        ds = Nothing
        '        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    Else
        '        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
        '            ds = Nothing
        '            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            Exit Sub
        '            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '    End If

        '    MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Call CARGA_GRILLA()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        'End Try
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
        Call CARGA_GRILLA_DETALLADO()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonLimpiar_Click(sender As Object, e As EventArgs) Handles ButtonLimpiar.Click
        cmbCategorias.DataSource = Nothing
        cmbCategorias.Items.Clear()

        cmbSubCategoria.DataSource = Nothing
        cmbSubCategoria.Items.Clear()

        Call CARGA_COMBO_CATEGORIAS()
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonExportar_Click(sender As Object, e As EventArgs) Handles ButtonExportar.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0

        Call CARGA_GRILLA()
        Call CARGA_GRILLA_DETALLADO()

        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                               + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            respuesta = MessageBox.Show("¿Desea exportar listado de productos con detalle?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbYes Then

                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call ExportarDatosExcel(grilla_det, "LISTADO DETALLADO PRODUCTOS")
                Cursor = System.Windows.Forms.Cursors.Default
            Else
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Call ExportarDatosExcel(Grilla, "LISTADO PRODUCTOS")
                'class_comunes.ExportarExcel(Me.Grilla)
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
        '                                        + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        '    If respuesta = vbNo Then
        '        Exit Sub
        '    End If
        '    Cursor = System.Windows.Forms.Cursors.WaitCursor
        '    'class_comunes.ExportarExcel(Me.Grilla)
        '    Call ExportarDatosExcel(Me.Grilla, "LISTADO DE PRODUCTOS")
        '    Cursor = System.Windows.Forms.Cursors.Default
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLADO()
        Dim class_productos As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_productos.cnn = _cnn
            class_productos.pro_codigo = 0
            class_productos.todos = chkActivo.Checked
            class_productos.codigo_interno = IIf(txtCodigoInterno.Text = "", "-", txtCodigoInterno.Text)

            If cmbCategorias.Text = "" Then
                class_productos.cat_codigo = 0
            Else
                class_productos.cat_codigo = cmbCategorias.SelectedValue
            End If

            If cmbSubCategoria.Text = "" Then
                class_productos.sub_codigo = 0
            Else
                class_productos.sub_codigo = cmbSubCategoria.SelectedValue
            End If

            If chkConfigurar.Checked = True Then
                class_productos.pro_config = 1
            Else
                class_productos.pro_config = 0
            End If


            _msg = ""
            grilla_det.Rows.Clear()
            ds = class_productos.PRODUCTOS_LISTADO_DETALLE(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigointerno") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grilla_det.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                                ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                ds.Tables(0).Rows(Fila)("cat_nombre"),
                                                ds.Tables(0).Rows(Fila)("sub_nombre"),
                                                ds.Tables(0).Rows(Fila)("bul_codigo"),
                                                ds.Tables(0).Rows(Fila)("bul_ancho"),
                                                ds.Tables(0).Rows(Fila)("bul_alto"),
                                                ds.Tables(0).Rows(Fila)("bul_fondo"),
                                                ds.Tables(0).Rows(Fila)("bul_cantidadbase"),
                                                ds.Tables(0).Rows(Fila)("bul_cantidadalto"),
                                                ds.Tables(0).Rows(Fila)("bul_tipobulto"),
                                                ds.Tables(0).Rows(Fila)("bul_horizontal"))

                            'grilla_det.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                            '                ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                            '                ds.Tables(0).Rows(Fila)("pro_nombre"),
                            '                ds.Tables(0).Rows(Fila)("cat_nombre"),
                            '                ds.Tables(0).Rows(Fila)("sub_nombre"),
                            '                ds.Tables(0).Rows(Fila)("pro_color"),
                            '                ds.Tables(0).Rows(Fila)("pro_numbultos"),
                            '                ds.Tables(0).Rows(Fila)("pro_cantbultoing"),
                            '                ds.Tables(0).Rows(Fila)("bul_codigo"),
                            '                ds.Tables(0).Rows(Fila)("bul_ancho"),
                            '                ds.Tables(0).Rows(Fila)("bul_alto"),
                            '                ds.Tables(0).Rows(Fila)("bul_fondo"),
                            '                ds.Tables(0).Rows(Fila)("bul_ca_pza"),
                            '                ds.Tables(0).Rows(Fila)("bul_peso"),
                            '                ds.Tables(0).Rows(Fila)("can_base"),
                            '                ds.Tables(0).Rows(Fila)("can_altu"),
                            '                ds.Tables(0).Rows(Fila)("pro_activo"))

                            'If ds.Tables(0).Rows(Fila)("pro_numbultos") = 0 Then
                            '    grilla_det.Rows(Fila).DefaultCellStyle.BackColor = Color.LightSalmon
                            '    grilla_det.Rows(Fila).DefaultCellStyle.ForeColor = Color.Black
                            'End If

                            'If ds.Tables(0).Rows(Fila)("pro_numbultos") > 0 Then
                            '    If ds.Tables(0).Rows(Fila)("pro_numbultos") > ds.Tables(0).Rows(Fila)("pro_cantbultoing") Then
                            '        grilla_det.Rows(Fila).DefaultCellStyle.BackColor = Color.NavajoWhite
                            '        grilla_det.Rows(Fila).DefaultCellStyle.ForeColor = Color.Black
                            '    End If
                            'End If

                            Fila = Fila + 1
                        Loop

                    End If
                End If
                lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                Me.Text = "LISTADO DE PRODUCTOS DETALLE - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_DETALLADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_DETALLADO", MsgBoxStyle.Critical, Me.Text)
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

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        Try
            Dim frm As frm_imprimir = New frm_imprimir
            Dim classEmbarque As class_embarque = New class_embarque
            Dim ds As DataSet = New DataSet
            Dim _msgError As String = ""

            Dim nombreInforme = "etiqueta_productos_fvt_bultos.rpt"
            Dim Seleccionados As String = ""

            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(9).Value = True Then
                    Seleccionados = Seleccionados + CStr(row.Cells(0).Value).ToString + ","
                End If
            Next

            If Seleccionados = "" Then
                MessageBox.Show("Debe seleccionar a lo menos un producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            frm.nombreReporte = nombreInforme
            frm.Origen = "EPB"

            frm.strCadena = Seleccionados
            frm.ShowDialog()


            'Me.Cursor = Cursors.WaitCursor

            'Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class