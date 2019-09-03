Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_paletizar
    Private _cnn As String
    Private _rec_codigo As Integer
    Private _car_codigo As Integer
    Private _fechaRecepcion As Date
    Private _ere_codigo As Integer = 0
    Private _creaPalletMuestra As Boolean
    Private _ExisteMuestra As Boolean

    Private _titulo As String
    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""
    Dim _fila As Integer = 0

    Public Property creaPalletMuestra() As Boolean
        Get
            Return _creaPalletMuestra
        End Get
        Set(ByVal value As Boolean)
            _creaPalletMuestra = value
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
    Public Property car_codigo() As Integer
        Get
            Return _car_codigo
        End Get
        Set(ByVal value As Integer)
            _car_codigo = value
        End Set
    End Property
    Public Property fechaRecepcion() As Date
        Get
            Return _fechaRecepcion
        End Get
        Set(ByVal value As Date)
            _fechaRecepcion = value
        End Set
    End Property

    Public Property rec_codigo() As Integer
        Get
            Return _rec_codigo
        End Get
        Set(ByVal value As Integer)
            _rec_codigo = value
        End Set
    End Property
    Public Property titulo() As String
        Get
            Return _titulo
        End Get
        Set(ByVal value As String)
            _titulo = value
        End Set
    End Property
    Public Property ere_codigo() As Integer
        Get
            Return _ere_codigo
        End Get
        Set(ByVal value As Integer)
            _ere_codigo = value
        End Set
    End Property

    Private Sub frm_paletizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        ButtonGeneraPallet.Enabled = False
        lblTitulo.Text = _titulo

        ButtonEditar.Enabled = True
        ButtonCierra.Enabled = True

        ButtonGeneraPallet.Enabled = False
        ButtonGeneraPallet.Text = "PRODUCTOS PARA MUESTRAS"

        If _ere_codigo = ESTADO_RECEPCION.FINALIZADA_CON_DIFERENCIA Or _ere_codigo = ESTADO_RECEPCION.FINALIZADA_SIN_DIFERENCIA Then
            If EXISTE_MUESTRA() = True Then
                ButtonGeneraPallet.Enabled = False
                ButtonGeneraPallet.Text = "RECEPCIÓN CON MUESTRA"
            Else
                ButtonGeneraPallet.Enabled = True
                ButtonGeneraPallet.Text = "PRODUCTOS PARA MUESTRAS"
            End If
        End If

        If USU_ASIGNA_PARA_RECEPCION = True Then
            ButtonEditar.Enabled = False
            ButtonCierra.Enabled = False
        End If


        If _ere_codigo = ESTADO_RECEPCION.FINALIZADA_CON_DIFERENCIA Or _ere_codigo = ESTADO_RECEPCION.FINALIZADA_SIN_DIFERENCIA Then
            ButtonEditar.Enabled = False
            ButtonGurdar.Enabled = False
            ButtonCierra.Enabled = False
            If USU_EJECUTA_RECEPCION = True Then
                ButtonGeneraPallet.Enabled = True
            Else
                ButtonGeneraPallet.Enabled = False
            End If
        End If

        If _ere_codigo = ESTADO_RECEPCION.EN_PROCESO Then
            Call CARGA_GRILLA_DETALLE()
            Call SUMA_PALLET()
            Call CARGA_GRILLA_DETALLE_SERIE()
        Else
            If EXISTE_PALETIZADO() = False Then
                Call CARGA_GRILLA_DETALLE()
                Call SUMA_PALLET()
                Call CARGA_GRILLA_DETALLE_SERIE()
            Else
                Call CARGA_GRILLA_RESUMEN_EXISTENTE()
                Call SUMA_PALLET()
                Call CARGA_GRILLA_DETALLE_EXISTENTE()
            End If
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Function EXISTE_MUESTRA() As Boolean
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_MUESTRA = False
        Try

            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            ds = classRecepcion.RECEPCION_MUESTRA_LISTADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("cantidad") > 0 Then
                        EXISTE_MUESTRA = True
                    Else
                        EXISTE_MUESTRA = False
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\EXISTE_MUESTRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\EXISTE_MUESTRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function EXISTE_PALETIZADO() As Boolean
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_PALETIZADO = False
        Try

            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            ds = classRecepcion.EXISTE_PALETIZADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("cantidad") > 0 Then
                        EXISTE_PALETIZADO = True
                    Else
                        EXISTE_PALETIZADO = False
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\EXISTE_PALETIZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\EXISTE_PALETIZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub CARGA_GRILLA_RESUMEN_EXISTENTE()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            ds = classRecepcion.PALETIZADO_RESUMEN_SELECCIONA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaDetalle.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            IIf(ds.Tables(0).Rows(Fila)("pro_codigointerno") <> "", "", ds.Tables(0).Rows(Fila)("pre_cantidad")),
                                            IIf(ds.Tables(0).Rows(Fila)("pro_codigointerno") <> "", "", ds.Tables(0).Rows(Fila)("pre_bxpn")),
                                            IIf(ds.Tables(0).Rows(Fila)("pro_codigointerno") <> "", "", ds.Tables(0).Rows(Fila)("pre_cpn")),
                                            IIf(ds.Tables(0).Rows(Fila)("pro_codigointerno") <> "", "", ds.Tables(0).Rows(Fila)("pre_bxpd")),
                                            IIf(ds.Tables(0).Rows(Fila)("pro_codigointerno") <> "", "", ds.Tables(0).Rows(Fila)("pre_cpd")),
                                            Contador,
                                            ds.Tables(0).Rows(Fila)("tipofila"),
                                            ds.Tables(0).Rows(Fila)("pro_codigorel"))
                            Fila = Fila + 1
                            Contador = Contador + 1
                        Loop
                        txtUnidadFil.Text = ds.Tables(0).Rows(0)("cant_fil")
                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_RESUMEN_EXISTENTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_RESUMEN_EXISTENTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CARGA_GRILLA_DETALLE_EXISTENTE()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            ds = classRecepcion.PALETIZADO_DETALLE_SELECCIONA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaSerie.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaSerie.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("prd_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("prd_palletserie"),
                                            ds.Tables(0).Rows(Fila)("bulto"),
                                            ds.Tables(0).Rows(Fila)("prd_cantidad"))
                            Fila = Fila + 1
                            Contador = Contador + 1
                        Loop

                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE_EXISTENTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE_EXISTENTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLE()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            ds = classRecepcion.PALETIZAR_RECEPCION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaDetalle.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("codigo"),
                                            ds.Tables(0).Rows(Fila)("nombre"),
                                            IIf(ds.Tables(0).Rows(Fila)("codigo") <> "", "", ds.Tables(0).Rows(Fila)("cantidad")),
                                            IIf(ds.Tables(0).Rows(Fila)("codigo") <> "", "", ds.Tables(0).Rows(Fila)("cpn")),
                                            IIf(ds.Tables(0).Rows(Fila)("codigo") <> "", "", ds.Tables(0).Rows(Fila)("pnu")),
                                            IIf(ds.Tables(0).Rows(Fila)("codigo") <> "", "", ds.Tables(0).Rows(Fila)("cpd")),
                                            IIf(ds.Tables(0).Rows(Fila)("codigo") <> "", "", ds.Tables(0).Rows(Fila)("pdu")),
                                            Contador,
                                            ds.Tables(0).Rows(Fila)("tipofila"),
                                            ds.Tables(0).Rows(Fila)("pro_codigorel"))
                            Fila = Fila + 1
                            Contador = Contador + 1
                        Loop

                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SUMA_PALLET()
        Dim totalPalletEstandar As Integer = 0
        Dim totalPalletDoble As Integer = 0

        Try
            For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
                If row.Cells(1).Value = "" Then
                    totalPalletEstandar = totalPalletEstandar + CInt(row.Cells(5).Value)
                    totalPalletDoble = totalPalletDoble + CInt(row.Cells(7).Value)
                End If
            Next

            lblTNormal.Text = totalPalletEstandar
            lblTDoble.Text = totalPalletDoble
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CARGA_GRILLA_DETALLE_SERIE()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            ds = classRecepcion.PALETIZAR_RECEPCION_SERIE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaSerie.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaSerie.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("prd_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("prd_palletserie"),
                                            ds.Tables(0).Rows(Fila)("bultos"),
                                            ds.Tables(0).Rows(Fila)("prd_cantidad"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonEditar_Click(sender As Object, e As EventArgs) Handles ButtonEditar.Click
        ButtonGurdar.Enabled = True
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        Call GUARDAR()
        ButtonGurdar.Enabled = False
    End Sub

    Private Sub GUARDAR()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classRecepcion.rec_codigo = _rec_codigo

                ds = classRecepcion.PALETIZADO_RESUMEN_ELIMINA(_msgError, conexion)
                If _msgError <> "" Then
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                ds = Nothing
                Do While fila < GrillaDetalle.RowCount
                    classRecepcion.rec_codigo = _rec_codigo
                    classRecepcion.pro_codigo = GrillaDetalle.Rows(fila).Cells(0).Value
                    classRecepcion.pro_codigointerno = GrillaDetalle.Rows(fila).Cells(1).Value
                    classRecepcion.pro_nombre = GrillaDetalle.Rows(fila).Cells(2).Value

                    If GrillaDetalle.Rows(fila).Cells(3).Value.ToString = "" Then
                        classRecepcion.pre_cantidad = 0
                    Else
                        classRecepcion.pre_cantidad = GrillaDetalle.Rows(fila).Cells(3).Value
                    End If

                    If GrillaDetalle.Rows(fila).Cells(4).Value.ToString = "" Then
                        classRecepcion.pre_bxpn = 0
                    Else
                        classRecepcion.pre_bxpn = GrillaDetalle.Rows(fila).Cells(4).Value
                    End If

                    If GrillaDetalle.Rows(fila).Cells(5).Value.ToString = "" Then
                        classRecepcion.pre_cpn = 0
                    Else
                        classRecepcion.pre_cpn = GrillaDetalle.Rows(fila).Cells(5).Value
                    End If

                    If GrillaDetalle.Rows(fila).Cells(6).Value.ToString = "" Then
                        classRecepcion.pre_bxpd = 0
                    Else
                        classRecepcion.pre_bxpd = GrillaDetalle.Rows(fila).Cells(6).Value
                    End If

                    If GrillaDetalle.Rows(fila).Cells(7).Value.ToString = "" Then
                        classRecepcion.pre_cpd = 0
                    Else
                        classRecepcion.pre_cpd = GrillaDetalle.Rows(fila).Cells(7).Value
                    End If

                    classRecepcion.tipofila = GrillaDetalle.Rows(fila).Cells(9).Value
                    classRecepcion.pro_codigorel = GrillaDetalle.Rows(fila).Cells(10).Value
                    classRecepcion.cant_fil = CInt(txtUnidadFil.Text)

                    ds = classRecepcion.PALETIZADO_RESUMEN_GUARDAR(_msgError, conexion)
                    If ds.Tables(0).Rows.Count > 0 Then
                        If _msgError = "" Then
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Sub
                            End If
                        Else
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                            Exit Sub
                        End If
                    End If
                    fila = fila + 1
                Loop

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                MessageBox.Show("Los datos fueron guardados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call CARGA_GRILLA_DETALLE_SERIE()

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PINTA_GRILLA_DETALLE(ByVal codigo As String)
        For Each row As DataGridViewRow In Me.GrillaSerie.Rows
            row.DefaultCellStyle.BackColor = Color.White
            row.DefaultCellStyle.ForeColor = Color.Black
        Next

        For Each row As DataGridViewRow In Me.GrillaSerie.Rows

            If row.Cells(2).Value = codigo Then
                row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(249, 253, 191)) 'RGB(249, 253, 191)
                row.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub


    Private Sub GrillaDetalle_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles GrillaDetalle.CellFormatting
        If GrillaDetalle.Columns(e.ColumnIndex).Name.Equals("Column6") Or GrillaDetalle.Columns(e.ColumnIndex).Name.Equals("Column4") Then
            e.CellStyle.BackColor = Color.Azure
            e.CellStyle.ForeColor = Color.Black
        ElseIf GrillaDetalle.Columns(e.ColumnIndex).Name.Equals("Column7") Or GrillaDetalle.Columns(e.ColumnIndex).Name.Equals("Column8") Then
            e.CellStyle.BackColor = Color.WhiteSmoke
            e.CellStyle.ForeColor = Color.Black
        End If
    End Sub

    Private Sub GrillaDetalle_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GrillaDetalle.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        PrecionaTeclaDesde = "GrillaDetalle"
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
    End Sub

    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = GrillaDetalle.CurrentCell.ColumnIndex
        Dim fila As Integer = GrillaDetalle.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = 4) Or (columna = 6) Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar  
                e.KeyChar = Chr(0)
            End If
        End If

        'If (columna = 2) Then
        '    Dim caracter As Char = e.KeyChar

        '    ' referencia a la celda  
        '    Dim txt As TextBox = CType(sender, TextBox)

        '    ' comprobar si es un número con isNumber, si es el backspace, si el caracter  

        '    ' es el separador decimal, y que no contiene ya el separador 

        '    If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ",") And (txt.Text.Contains(",") = False) Then

        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'End If

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim columna As Integer
        Dim fila As Integer
        Dim nDocumento As String = ""
        Try
            Select Case keyData
                Case Keys.Escape

                    ' No hacemos nada porque se supone

                    ' que la tecla Escape cancela la acción.

                Case Keys.Enter
                    '=========================================================
                    'PRECIONA TECLA CON EL FOCO EN LA GRILLA DE FINANCIAMIENTO
                    '=========================================================
                    'If GrillaFinanciamiento.Focus = True Then
                    If PrecionaTeclaDesde = "GrillaDetalle" Then
                        columna = GrillaDetalle.CurrentCell.ColumnIndex
                        fila = GrillaDetalle.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""

                Case Keys.Left
                    If PrecionaTeclaDesde = "GrillaDetalle" Then
                        columna = GrillaDetalle.CurrentCell.ColumnIndex
                        fila = GrillaDetalle.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""

                Case Keys.Right
                    If PrecionaTeclaDesde = "GrillaDetalle" Then
                        columna = GrillaDetalle.CurrentCell.ColumnIndex
                        fila = GrillaDetalle.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""
                Case Keys.Up
                    If PrecionaTeclaDesde = "GrillaDetalle" Then
                        columna = GrillaDetalle.CurrentCell.ColumnIndex
                        fila = GrillaDetalle.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""
                Case Keys.Down
                    If PrecionaTeclaDesde = "GrillaDetalle" Then
                        columna = GrillaDetalle.CurrentCell.ColumnIndex
                        fila = GrillaDetalle.CurrentCell.RowIndex

                        Call EDITA_GRILA_SELECCIONADOS(columna, fila)
                    End If

                    PrecionaTeclaDesde = ""
                Case Else

                    Return MyBase.ProcessCmdKey(msg, keyData)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub EDITA_GRILA_SELECCIONADOS(ByVal columna As Integer, ByVal fila As Integer)
        Dim nDocumento As String = ""
        Dim pEntera As Integer = 0
        Dim pDecimal As Double = 0

        Try
            If (cellTextBox IsNot Nothing) Then
                With GrillaDetalle
                    If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                        .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                    ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                        .CurrentCell = .Item(.CurrentCell.ColumnIndex - 1, 0)
                    End If
                End With
            End If
            If (columna = 4) Then
                If GrillaDetalle.Rows(fila).Cells(9).Value = "D" Then
                    'pallet estandar
                    If (GrillaDetalle.Rows(fila).Cells(5).Value <> "0") Then
                        If CInt(GrillaDetalle.Rows(fila).Cells(4).Value) <= CInt(GrillaDetalle.Rows(fila).Cells(3).Value) Then
                            pEntera = Math.Truncate((CInt(GrillaDetalle.Rows(fila).Cells(3).Value) / CInt(GrillaDetalle.Rows(fila).Cells(4).Value)))
                            pDecimal = (CInt(GrillaDetalle.Rows(fila).Cells(3).Value) / CInt(GrillaDetalle.Rows(fila).Cells(4).Value)) - pEntera
                            If pDecimal > 0 Then
                                pEntera = pEntera + 1
                            End If
                            GrillaDetalle.Rows(fila).Cells(5).Value = pEntera
                        Else
                            GrillaDetalle.Rows(fila).Cells(4).Value = 0
                            GrillaDetalle.Rows(fila).Cells(5).Value = 0
                        End If
                    Else
                        GrillaDetalle.Rows(fila).Cells(4).Value = 0
                        GrillaDetalle.Rows(fila).Cells(5).Value = 0
                    End If
                Else
                    GrillaDetalle.Rows(fila).Cells(4).Value = ""
                    GrillaDetalle.Rows(fila).Cells(5).Value = ""
                End If

                Call SUMA_PALLET()

            ElseIf (columna = 6) Then
                'pallet doble

                If GrillaDetalle.Rows(fila).Cells(9).Value = "D" Then
                    If (GrillaDetalle.Rows(fila).Cells(7).Value <> "0") Then
                        If CInt(GrillaDetalle.Rows(fila).Cells(6).Value) <= CInt(GrillaDetalle.Rows(fila).Cells(3).Value) Then
                            pEntera = Math.Truncate((CInt(GrillaDetalle.Rows(fila).Cells(3).Value) / CInt(GrillaDetalle.Rows(fila).Cells(6).Value)))
                            pDecimal = (CInt(GrillaDetalle.Rows(fila).Cells(3).Value) / CInt(GrillaDetalle.Rows(fila).Cells(6).Value)) - pEntera
                            If pDecimal > 0 Then
                                pEntera = pEntera + 1
                            End If
                            GrillaDetalle.Rows(fila).Cells(7).Value = pEntera
                        Else
                            GrillaDetalle.Rows(fila).Cells(6).Value = 0
                            GrillaDetalle.Rows(fila).Cells(7).Value = 0
                        End If
                    Else
                        GrillaDetalle.Rows(fila).Cells(6).Value = 0
                        GrillaDetalle.Rows(fila).Cells(7).Value = 0
                    End If
                Else
                    GrillaDetalle.Rows(fila).Cells(6).Value = ""
                    GrillaDetalle.Rows(fila).Cells(7).Value = ""
                End If

                Call SUMA_PALLET()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrillaDetalle_DoubleClick(sender As Object, e As EventArgs) Handles GrillaDetalle.DoubleClick
        Call PINTA_GRILLA_DETALLE(GrillaDetalle.Rows(_fila).Cells(1).Value)
    End Sub

    Private Sub GrillaDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellEnter
        _fila = e.RowIndex
    End Sub

    Private Sub ButtonImprime_Click(sender As Object, e As EventArgs) Handles ButtonImprime.Click
        Try
            Dim frm As frm_imprimir = New frm_imprimir
            frm.Origen = "REC"
            frm.rec_codigo = rec_codigo
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonCierra_Click(sender As Object, e As EventArgs) Handles ButtonCierra.Click
        Dim respuesta As Integer = 0

        If txtUnidadFil.Text = "0" Or txtUnidadFil.Text = "" Then
            MessageBox.Show("Debe ingresar la cantidad de fil utilizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUnidadFil.Focus()
            Exit Sub
        End If

        respuesta = MessageBox.Show("¿Esta seguro(a) de cerrar la recepción?. " _
                                    + Chr(10) + "Esto podría tomar un tiempo considerble en registrar las series", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = vbYes Then
            Me.Cursor = Cursors.WaitCursor
            Call CIERRA_RECEPCION()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Function CIERRA_RECEPCION() As Boolean
        Dim classMOV As class_movimientos = New class_movimientos
        Dim classInv As class_inventario = New class_inventario
        'Dim class_recepcion As class_recepcion = New class_recepcion
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim ds As DataSet = New DataSet
        Dim dsDetalle As DataSet = New DataSet
        Dim dsInventario As DataSet = New DataSet
        Dim dsMov As DataSet = New DataSet

        Dim _Folio As Integer
        Dim fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        CIERRA_RECEPCION = False
        Try
            If txtUnidadFil.Text = "0" And txtUnidadFil.Text = "" Then
                MessageBox.Show("Debe ingresar la cantidad de FILM STRECH utilizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtUnidadFil.Focus()
                Exit Function
            End If

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classRecepcion.rec_codigo = _rec_codigo
                classRecepcion.cant_fil = CInt(txtUnidadFil.Text)
                ds = classRecepcion.CIERRA_RECEPCION(_msgError, conexion)
                If ds.Tables(0).Rows.Count > 0 Then
                    If _msgError = "" Then
                        If ds.Tables(0).Rows(0)("CODIGO") <= 0 Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                            Exit Function
                        End If
                    Else
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Function
                    End If
                End If

                If CStr(_fechaRecepcion.Month).Length = 1 Then
                    mes = Trim("0" + CStr(_fechaRecepcion.Month))
                Else
                    mes = CStr(_fechaRecepcion.Month)
                End If

                Dim numSerieProducto As Integer = 1
                Dim contadorSerie As Integer = 0
                Dim cantidadProducto As Integer = 0
                Dim serieProductoString As String = ""
                fila = 0
                Do While fila <= GrillaSerie.Rows.Count - 1
                    numSerieProducto = 1
                    cantidadProducto = GrillaSerie.Rows(fila).Cells(5).Value
                    Do While numSerieProducto <= cantidadProducto
                        serieProductoString = ""
                        If Len(numSerieProducto.ToString) = 1 Then
                            serieProductoString = "0" + numSerieProducto.ToString
                        Else
                            serieProductoString = numSerieProducto.ToString
                        End If

                        classRecepcion.rec_codigo = _rec_codigo
                        classRecepcion.prd_codigo = GrillaSerie.Rows(fila).Cells(1).Value
                        classRecepcion.prd_palletserie = GrillaSerie.Rows(fila).Cells(3).Value
                        classRecepcion.prs_codigo = 0
                        classRecepcion.prs_serie = GrillaSerie.Rows(fila).Cells(3).Value.ToString + serieProductoString
                        classRecepcion.pro_codigo = GrillaSerie.Rows(fila).Cells(0).Value
                        classRecepcion.pro_numbulto = CInt(Mid(GrillaSerie.Rows(fila).Cells(3).Value.ToString, 17, 2))
                        ds = classRecepcion.RECEPCION_PRODUCTO_SERIE_GUARDAR(_msgError, conexion)
                        If _msgError <> "" Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If

                            ds = Nothing
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Function
                        Else
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If

                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Function
                            End If
                        End If
                        numSerieProducto = numSerieProducto + 1
                    Loop
                    fila = fila + 1
                Loop
                '***********

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                ButtonGeneraPallet.Enabled = True
                ButtonCierra.Enabled = False
                ButtonEditar.Enabled = False
                CIERRA_RECEPCION = True
                MessageBox.Show("La recepción fue cerrada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            CIERRA_RECEPCION = False
        End Try
    End Function

    Private Sub ButtonGeneraPallet_Click(sender As Object, e As EventArgs) Handles ButtonGeneraPallet.Click
        Dim frm As frm_productos_muestra = New frm_productos_muestra
        frm.cnn = _cnn
        frm.rec_codigo = _rec_codigo
        frm.ere_codigo = _ere_codigo
        frm.ShowDialog()
        If EXISTE_MUESTRA() = True Then
            ButtonGeneraPallet.Enabled = False
            ButtonGeneraPallet.Text = "RECEPCIÓN CON MUESTRA"
        End If
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonIdentificador_Click(sender As Object, e As EventArgs) Handles ButtonIdentificador.Click
        If EXISTE_PALETIZADO() = False Then

        End If
    End Sub
End Class