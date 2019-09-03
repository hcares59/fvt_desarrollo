Public Class frm_mant_picking_ubicaciones
    Private _cnn As String
    Private _proCodigo As Integer
    Private _proNombre As String
    Private _cantidad As Integer
    Private _cantidadDeBultos As Integer

    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""

    Const CON_FECHA As Integer = 0
    Const CON_BULTOS As Integer = 1
    Const CON_PALLET As Integer = 2
    Const CON_UBICACION As Integer = 3
    Const CON_DISPONIBLE As Integer = 4
    Const CON_TEMPORAL As Integer = 5
    Const CON_CONSUMIR As Integer = 6
    Const CON_NUMBULTO As Integer = 7

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property proCodigo() As Integer
        Get
            Return _proCodigo
        End Get
        Set(ByVal value As Integer)
            _proCodigo = value
        End Set
    End Property
    Public Property proNombre() As String
        Get
            Return _proNombre
        End Get
        Set(ByVal value As String)
            _proNombre = value
        End Set
    End Property
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private Sub frm_mant_picking_ubicaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProducto.Text = _proNombre
        txtCantidad.Text = _cantidad
        Call CARGA_GRILLA()
        _cantidadDeBultos = OBTIENE_NUMERO_BULTOS(_proCodigo)
    End Sub

    Private Function OBTIENE_NUMERO_BULTOS(ByVal pro_codigo As Integer) As Integer
        Dim classProducto As class_producto = New class_producto
        Dim msgError As String = ""
        Dim ds As DataSet = New DataSet
        Try
            OBTIENE_NUMERO_BULTOS = 0
            classProducto.cnn = _cnn
            classProducto.pro_codigo = pro_codigo
            ds = classProducto.PRODUCTOS_BUSQUEDA(msgError)
            If msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    OBTIENE_NUMERO_BULTOS = ds.Tables(0).Rows(0)("pro_numerobulto")
                End If
            Else
                MessageBox.Show(msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            OBTIENE_NUMERO_BULTOS = 0
        End Try
    End Function


    Private Sub CALCULA_DISPONIBLES()
        Dim fila As Integer = 0
        Try
            For Each p As estructura_pallet In listaPalletPickeado
                fila = 0
                Do While fila <= Grilla.Rows.Count - 1
                    If Grilla.Rows(fila).Cells(CON_PALLET).Value = p.pallet_serie Then
                        Grilla.Rows(fila).Cells(CON_TEMPORAL).Value = p.cantConsumo
                        'Grilla.Rows(fila).Cells(CON_CONSUMIR).Value = Grilla.Rows(fila).Cells(CON_DISPONIBLE).Value - p.cantConsumo
                    End If
                    fila = fila + 1
                Loop
                'MessageBox.Show(p.pallet_serie.ToString + " - " + p.pro_codigo.ToString + " - " + p.numBulto.ToString + " - " + p.cantConsumo.ToString)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub CARGA_GRILLA()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classUbicacion.cnn = _cnn
            classUbicacion.pro_codigo = _proCodigo

            _msg = ""
            Grilla.Rows.Clear()
            ds = classUbicacion.BUSCA_UBICACIONES_POR_PRODUCTOS_PARA_PICKING(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pal_fechamov"),
                                            ds.Tables(0).Rows(Fila)("pal_bultostr"),
                                            ds.Tables(0).Rows(Fila)("pal_palletserie"),
                                            ds.Tables(0).Rows(Fila)("ubicacion"),
                                            ds.Tables(0).Rows(Fila)("pal_cantidaddisponible"),
                                            0,
                                            0,
                                            ds.Tables(0).Rows(Fila)("pal_bulto"))
                            Fila = Fila + 1
                        Loop
                    End If
                    Call CALCULA_DISPONIBLES()
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick

    End Sub

    Private Sub Grilla_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        PrecionaTeclaDesde = "Grilla"
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
    End Sub

    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = Grilla.CurrentCell.ColumnIndex
        Dim fila As Integer = Grilla.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = CON_CONSUMIR) Then
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
        'Dim row As Integer
        'Dim control As String

        'control = ActiveControl.Name
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
                    If PrecionaTeclaDesde = "Grilla" Then

                        columna = Grilla.CurrentCell.ColumnIndex
                        fila = Grilla.CurrentCell.RowIndex

                        If (columna = CON_CONSUMIR) Then
                            If (cellTextBox IsNot Nothing) Then
                                With Grilla
                                    If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                                    ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex + 1, 0)
                                    End If
                                End With
                            End If

                            If CInt(Grilla.Rows(fila).Cells(CON_DISPONIBLE).Value) < CInt(Grilla.Rows(fila).Cells(CON_CONSUMIR).Value) Then
                                MessageBox.Show("El valor ingresado no puede ser mayor al valor disponible", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Grilla.Rows(fila).Cells(CON_CONSUMIR).Value = 0
                            End If
                        End If
                        'End If
                        '=============================================================
                        'PRECIONA TECLA CON EL FOCO EN LA GRILLA DE DESGLOSE DE CUOTAS
                        '=============================================================
                        'ElseIf GrillaCuotas.Focus = True Then

                    End If

                    PrecionaTeclaDesde = ""
                Case Else

                    Return MyBase.ProcessCmdKey(msg, keyData)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Call SUMATORIA()
    End Sub

    Private Sub SUMATORIA()
        Dim totalBulto1 As Integer = 0
        Dim totalBulto2 As Integer = 0
        Dim totalBulto3 As Integer = 0
        Dim totalBulto4 As Integer = 0
        Dim totalBulto5 As Integer = 0
        Dim totalBulto6 As Integer = 0
        Dim totalBulto7 As Integer = 0
        Dim totalBulto8 As Integer = 0
        Dim totalBulto9 As Integer = 0
        Dim totalBulto10 As Integer = 0
        Dim fila As Integer = 0
        Dim bulto As Integer = 1
        Dim sumaTotal As Integer = 0
        Dim Resto As Integer = 0

        Try
            Do While fila <= Grilla.RowCount - 1
                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 1 Then
                    totalBulto1 = totalBulto1 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If

                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 2 Then
                    totalBulto2 = totalBulto2 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If

                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 3 Then
                    totalBulto3 = totalBulto3 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If

                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 4 Then
                    totalBulto4 = totalBulto4 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If

                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 5 Then
                    totalBulto5 = totalBulto5 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If

                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 6 Then
                    totalBulto6 = totalBulto6 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If

                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 7 Then
                    totalBulto7 = totalBulto7 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If

                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 8 Then
                    totalBulto8 = totalBulto8 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If

                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 9 Then
                    totalBulto9 = totalBulto9 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If

                If Grilla.Rows(fila).Cells(CON_NUMBULTO).Value = 10 Then
                    totalBulto10 = totalBulto10 + (Grilla.Rows(fila).Cells(CON_TEMPORAL).Value + Grilla.Rows(fila).Cells(CON_CONSUMIR).Value)
                End If
                fila = fila + 1
            Loop

            Do While bulto <= _cantidadDeBultos
                If bulto = 1 Then
                    If (CInt(txtCantidad.Text) < totalBulto1) Or (totalBulto1 = 0) Then
                        MessageBox.Show("La cantidad de bultos 01 de ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                If bulto = 2 Then
                    If (CInt(txtCantidad.Text) < totalBulto2) Or (totalBulto2 = 0) Then
                        MessageBox.Show("La cantidad de bultos 02 debe ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                If bulto = 3 Then
                    If (CInt(txtCantidad.Text) < totalBulto3) Or (totalBulto3 = 0) Then
                        MessageBox.Show("La cantidad de bultos 03 debe ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                If bulto = 4 Then
                    If (CInt(txtCantidad.Text) < totalBulto4) Or (totalBulto4 = 0) Then
                        MessageBox.Show("La cantidad de bultos 04 debe ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                If bulto = 5 Then
                    If (CInt(txtCantidad.Text) < totalBulto5) Or (totalBulto5 = 0) Then
                        MessageBox.Show("La cantidad de bultos 05 debe ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                If bulto = 6 Then
                    If (CInt(txtCantidad.Text) < totalBulto6) Or (totalBulto6 = 0) Then
                        MessageBox.Show("La cantidad de bultos 06 debe ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                If bulto = 7 Then
                    If (CInt(txtCantidad.Text) < totalBulto7) Or (totalBulto7 = 0) Then
                        MessageBox.Show("La cantidad de bultos 07 debe ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                If bulto = 8 Then
                    If (CInt(txtCantidad.Text) < totalBulto8) Or (totalBulto8 = 0) Then
                        MessageBox.Show("La cantidad de bultos 08 debe ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                If bulto = 9 Then
                    If (CInt(txtCantidad.Text) < totalBulto9) Or (totalBulto9 = 0) Then
                        MessageBox.Show("La cantidad de bultos 09 debe ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                If bulto = 10 Then
                    If (CInt(txtCantidad.Text) < totalBulto10) Or (totalBulto10 = 0) Then
                        MessageBox.Show("La cantidad de bultos 10 debe ser mayor que 0 y menor que " + txtCantidad.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                bulto = bulto + 1
            Loop

            sumaTotal = totalBulto1 + totalBulto2 + totalBulto3 + totalBulto4 + totalBulto5 + totalBulto6 + totalBulto7 + totalBulto8 + totalBulto9 + totalBulto10
            Resto = (sumaTotal Mod _cantidadDeBultos)

            If Resto > 0 Then
                MessageBox.Show("Las cantidades ingresadas no son iguales para todos los bultos correspondiente al producto seleccionado," _
                                + Chr(10) + "por favor revisar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If listaPalletPickeado.Count > 0 Then
                Call LIMPIA_ESTRUCTURA_POR_PRODUCTO()
            End If
            Dim contador As Integer = 0
            If listaPalletPickeadoAuxiliar.Count > 0 Then
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    contador = 0
                    For Each p As estructura_pallet In listaPalletPickeadoAuxiliar
                        If proCodigo = p.pro_codigo Then
                            contador = contador + 1
                        End If
                    Next

                    If contador = 0 Then
                        If row.Cells(CON_CONSUMIR).Value > 0 Then
                            listaPalletPickeado.Add(New estructura_pallet(row.Cells(CON_PALLET).Value,
                                                                          proCodigo, row.Cells(CON_NUMBULTO).Value,
                                                                          (row.Cells(CON_TEMPORAL).Value + row.Cells(CON_CONSUMIR).Value)))
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If (row.Cells(CON_TEMPORAL).Value > 0) Or (row.Cells(CON_CONSUMIR).Value > 0) Then
                        listaPalletPickeado.Add(New estructura_pallet(row.Cells(CON_PALLET).Value,
                                                                      proCodigo, row.Cells(CON_NUMBULTO).Value,
                                                                      (row.Cells(CON_TEMPORAL).Value + row.Cells(CON_CONSUMIR).Value)))
                    End If
                Next
            End If
            listaPalletPickeadoAuxiliar.Clear()

            GLO_CANTIDAD_UNIDADES_SELECCIONADAS = totalBulto1
            Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LIMPIA_ESTRUCTURA_POR_PRODUCTO_AUXILIAR()
        Try
            For Each p As estructura_pallet In listaPalletPickeado
                If p.pro_codigo <> _proCodigo Then
                    listaPalletPickeadoAuxiliar.Add(New estructura_pallet(p.pallet_serie,
                                                                  p.pro_codigo, p.numBulto,
                                                                  (p.cantConsumo)))
                End If
            Next
            listaPalletPickeado.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LIMPIA_ESTRUCTURA_POR_PRODUCTO()
        Try
            For Each p As estructura_pallet In listaPalletPickeado
                If p.pro_codigo <> _proCodigo Then
                    listaPalletPickeadoAuxiliar.Add(New estructura_pallet(p.pallet_serie,
                                                                  p.pro_codigo, p.numBulto,
                                                                  (p.cantConsumo)))
                End If
            Next
            listaPalletPickeado.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class