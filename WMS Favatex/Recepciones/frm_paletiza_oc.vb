Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_paletiza_oc
    Private _cnn As String
    Private _ocp_codigo As Integer
    Private _car_codigo As Integer
    Private _fechaOrden As Date
    Private _ere_codigo As Integer = 0
    Private _creaPalletMuestra As Boolean
    Private _eoc_codigo As Integer

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
    Public Property fechaOrden() As Date
        Get
            Return _fechaOrden
        End Get
        Set(ByVal value As Date)
            _fechaOrden = value
        End Set
    End Property
    Public Property rec_codigo() As Integer
        Get
            Return _ocp_codigo
        End Get
        Set(ByVal value As Integer)
            _ocp_codigo = value
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
    Public Property ocp_codigo() As Integer
        Get
            Return _ocp_codigo
        End Get
        Set(ByVal value As Integer)
            _ocp_codigo = value
        End Set
    End Property
    Public Property eoc_codigo() As Integer
        Get
            Return _eoc_codigo
        End Get
        Set(ByVal value As Integer)
            _eoc_codigo = value
        End Set
    End Property

    Private Sub frm_paletiza_oc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        lblTitulo.Text = _titulo
        If (_eoc_codigo = ESTADO_ORDEN_COMPRA_PROVEEDOR.EN_TRANSITO) Or (_eoc_codigo = ESTADO_ORDEN_COMPRA_PROVEEDOR.ARRIBADA) Or (_eoc_codigo = ESTADO_ORDEN_COMPRA_PROVEEDOR.ANULADA) Or (_eoc_codigo = ESTADO_ORDEN_COMPRA_PROVEEDOR.CIERRE_MANUAL) Then
            Call CARGA_GRILLA_RESUMEN_EXISTENTE()
            Call SUMA_PALLET()
            Call CARGA_GRILLA_DETALLE_EXISTENTE()
        Else
            Call CARGA_GRILLA_DETALLE()
            Call SUMA_PALLET()
            Call CARGA_GRILLA_DETALLE_SERIE()
        End If

        ''If _eoc_codigo = 1 Then
        ''    Call CARGA_GRILLA_DETALLE()
        ''    Call SUMA_PALLET()
        ''    Call CARGA_GRILLA_DETALLE_SERIE()
        ''Else
        ''    If EXISTE_PALETIZADO_ORDEN_COMPRA() = False Then
        ''        Call CARGA_GRILLA_DETALLE()
        ''        Call SUMA_PALLET()
        ''        Call CARGA_GRILLA_DETALLE_SERIE()
        ''    Else
        ''        Call CARGA_GRILLA_RESUMEN_EXISTENTE()
        ''        Call SUMA_PALLET()
        ''        Call CARGA_GRILLA_DETALLE_EXISTENTE()
        ''    End If
        ''End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Function EXISTE_PALETIZADO_ORDEN_COMPRA() As Boolean
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_PALETIZADO_ORDEN_COMPRA = False
        Try

            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo
            ds = classOC.EXISTE_PALETIZADO_OC(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("cantidad") > 0 Then
                        EXISTE_PALETIZADO_ORDEN_COMPRA = True
                    Else
                        EXISTE_PALETIZADO_ORDEN_COMPRA = False
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\EXISTE_PALETIZADO_ORDEN_COMPRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\EXISTE_PALETIZADO_ORDEN_COMPRA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub CARGA_GRILLA_DETALLE()
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo
            ds = classOC.PALETIZAR_ORDEN_COMPRA(_msgError)
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
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo
            ds = classOC.PALETIZAR_ORDEN_COMPRA_SERIE(_msgError)
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
    Private Sub CARGA_GRILLA_RESUMEN_EXISTENTE()
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo
            ds = classOC.PALETIZADO_RESUMEN_SELECCIONA(_msgError)
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
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo
            ds = classOC.PALETIZADO_DETALLE_SELECCIONA(_msgError)
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

    Private Sub GrillaDetalle_DoubleClick(sender As Object, e As EventArgs) Handles GrillaDetalle.DoubleClick
        Call PINTA_GRILLA_DETALLE(GrillaDetalle.Rows(_fila).Cells(1).Value)
    End Sub

    Private Sub GrillaDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellEnter
        _fila = e.RowIndex
    End Sub

    Private Sub ButtonImprime_Click(sender As Object, e As EventArgs) Handles ButtonImprime.Click
        Try
            Dim frm As frm_imprimir = New frm_imprimir
            frm.Origen = "POR"
            frm.ocp_codigo = _ocp_codigo
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class