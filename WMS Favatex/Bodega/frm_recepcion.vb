Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_recepcion
    Private _cnn As String
    Private _rec_codigo As Integer
    Private _colum As Integer
    Private _fila As Integer
    Private _filaSeleccionada As Integer = -1
    Private _cantidad As Integer = 0
    Private _proCodigo As Integer = 0
    Private _numBultos As Integer = 0
    Private _ere_codigo As Integer = 0

    Private _car_codigo As Integer = 0
    Private _opd_numero As Long = 0

    Dim _nombreArchivo As String = ""
    Dim _extension As String = ""
    Dim pasoDesdeMulti As String = ""

    Dim fila As Integer = 0

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Public Property ere_codigo() As Integer
        Get
            Return _ere_codigo
        End Get
        Set(ByVal value As Integer)
            _ere_codigo = value
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
    Public Property opd_numero() As Long
        Get
            Return _opd_numero
        End Get
        Set(ByVal value As Long)
            _opd_numero = value
        End Set
    End Property

    Private Sub BUSCA_PRODUCTOS(ByVal codigo As String)
        Dim class_producto As class_producto = New class_producto
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_producto.cnn = _cnn
            class_producto.codigo_interno = codigo

            _msg = ""
            ds = class_producto.BUSCA_PRODUCTO_CODIGO_INTERNO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        txtNombreProducto.Text = ds.Tables(0).Rows(Fila)("pro_nombre")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\BUSCA_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "BUSCA_PRODUCTOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub txtCodigo_LostFocus(sender As Object, e As EventArgs) Handles txtCodigo.LostFocus
        If txtCodigo.Text <> "" Then
            Call BUSCA_PRODUCTOS(txtCodigo.Text)
        End If
    End Sub

    Private Sub frm_recepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized
        Call INICIALIZA()

        Call OBTIENE_ESTADO_RECEPCION()

        If USU_ASIGNA_PARA_RECEPCION = True Then
            If (_ere_codigo = ESTADO_RECEPCION.FINALIZADA_CON_DIFERENCIA) Or (_ere_codigo = ESTADO_RECEPCION.FINALIZADA_SIN_DIFERENCIA) Then
                btnAprueba.Visible = True
                sepApruebaR.Visible = True
                btnRechazaR.Visible = True
                btnRechazaR.Visible = True
            End If
        End If

        If USU_ASIGNA_PARA_ALMACENAMIENTO = True Then
            If _ere_codigo = ESTADO_RECEPCION.APROBADA_POR_BODEGA Or _ere_codigo = ESTADO_RECEPCION.ASIGNADA_PARA_ALMACENAR Then
                grpAsignacion.Visible = True
            Else
                grpAsignacion.Visible = False
            End If
        End If

        If USU_EJECUTA_ALMACENAMIENTO = True Then
            cmbResAlmacenamiento.SelectedValue = GLO_USUARIO_ACTUAL
            cmbResAlmacenamiento.Enabled = False
        End If

        If USU_EJECUTA_RECEPCION = True Then
            cmbResponsable.SelectedValue = GLO_USUARIO_ACTUAL
            cmbResponsable.Enabled = False
        End If

        If (_ere_codigo = ESTADO_RECEPCION.FINALIZADA_CON_DIFERENCIA) Or (_ere_codigo = ESTADO_RECEPCION.FINALIZADA_SIN_DIFERENCIA) Or (_ere_codigo = ESTADO_RECEPCION.APROBADA_POR_BODEGA) _
            Or (_ere_codigo = ESTADO_RECEPCION.ASIGNADA_PARA_ALMACENAR) Or (_ere_codigo = ESTADO_RECEPCION.ALMACENADA_PARCIAL) Or (_ere_codigo = ESTADO_RECEPCION.ALMACENADA_COMPLETA) Then
            ButtonGurdar.Enabled = False
            ButtonPaletizar.Enabled = False
        End If

        If (USU_ASIGNA_PARA_RECEPCION = False) And (USU_EJECUTA_RECEPCION = False) Then
            ButtonGurdar.Enabled = False
            ButtonPaletizar.Enabled = False
        End If

        If _rec_codigo > 0 Then
            TabPage2.Parent = TabControl1
            Call CARGA_DATOS_ENCABEZADO()
            Call BUSCA_ADJUNTO_RECEPCION()
            cmbProveedor.Enabled = False
            txtOCompra.Enabled = False
            ButtonPaletizar.Enabled = True
            If (_ere_codigo = ESTADO_RECEPCION.FINALIZADA_CON_DIFERENCIA) Or (_ere_codigo = ESTADO_RECEPCION.FINALIZADA_SIN_DIFERENCIA) Or (_ere_codigo = ESTADO_RECEPCION.APROBADA_POR_BODEGA) _
            Or (_ere_codigo = ESTADO_RECEPCION.ASIGNADA_PARA_ALMACENAR) Or (_ere_codigo = ESTADO_RECEPCION.ALMACENADA_PARCIAL) Or (_ere_codigo = ESTADO_RECEPCION.ALMACENADA_COMPLETA) Then
                ButtonGurdar.Enabled = False
                ButtonPaletizar.Enabled = False
            End If
            'If _ere_codigo = ESTADO_RECEPCION.FINALIZADA_CON_DIFERENCIA Or _ere_codigo = ESTADO_RECEPCION.FINALIZADA_SIN_DIFERENCIA Or (_ere_codigo = ESTADO_RECEPCION.APROBADA_POR_BODEGA) Then 'ESTADO_RECEPCION.RECEPCIONADA Then
            '    ButtonGurdar.Enabled = False
            '    ButtonPaletizar.Enabled = False
            'End If
        Else
            If _car_codigo > 0 And _opd_numero > 0 Then
                cmbProveedor.SelectedValue = _car_codigo
                txtOCompra.Text = _opd_numero
                cmbProveedor.Enabled = False
                txtOCompra.Enabled = False

                Call BUSCA_DETALLES_OC_PENDIENTES()

            End If
        End If

    End Sub

    Private Sub CARGA_COMBO_EJECUTA_ALMACENAMENTO()
        Dim _msg As String
        Try
            Dim classUsuario As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            _msg = ""
            classUsuario.cnn = _cnn
            ds = classUsuario.CARGA_COMBO_EJECUTA_ALMACENAMIENTO(_msg)
            If _msg = "" Then
                Me.cmbResAlmacenamiento.DataSource = ds.Tables(0)
                Me.cmbResAlmacenamiento.DisplayMember = "MENSAJE"
                Me.cmbResAlmacenamiento.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_EJECUTA_ALMACENAMENTO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_DATOS_ENCABEZADO()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            classRecepcion.car_codigo = 0
            classRecepcion.rec_nguia = 0
            classRecepcion.rec_nfactura = 0
            classRecepcion.rec_ordencompra = 0
            classRecepcion.fecha_desde = "19000101"
            classRecepcion.fecha_hasta = "20501231"
            classRecepcion.ere_codigo = 0

            ds = classRecepcion.RECEPCIONES_LISTAR(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        cmbProveedor.SelectedValue = ds.Tables(0).Rows(Fila)("car_codigo")
                        txtOCompra.Text = ds.Tables(0).Rows(Fila)("rec_ordencompra")
                        cmbResponsable.SelectedValue = ds.Tables(0).Rows(Fila)("rec_empingreso")
                        txtFactura.Text = ds.Tables(0).Rows(Fila)("rec_nfactura")
                        txtGuia.Text = ds.Tables(0).Rows(Fila)("rec_nguia")
                        txtNumRec.Text = ds.Tables(0).Rows(Fila)("rec_numero")
                        txtChofer.Text = ds.Tables(0).Rows(Fila)("rec_nombrechofer")
                        txtPatente.Text = ds.Tables(0).Rows(Fila)("rec_patente")
                        txtFecha.Text = ds.Tables(0).Rows(Fila)("rec_fecharecepcion")
                        cmbResAlmacenamiento.SelectedValue = ds.Tables(0).Rows(Fila)("usu_almacenamiento")
                        txtObservacion.Text = ds.Tables(0).Rows(Fila)("rec_observacion")
                        'If (ds.Tables(0).Rows(Fila)("ere_codigo") = ESTADO_RECEPCION.RECEPCIONADA) Or (ds.Tables(0).Rows(Fila)("ere_codigo") = ESTADO_RECEPCION.ANULADA) Then
                        '    ButtonPaletizar.Enabled = False
                        'Else
                        '    ButtonPaletizar.Enabled = True
                        'End If

                        Call CARGA_GRILLA_DETALLE()

                        End If
                    End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_ENCABEZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_ENCABEZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLE()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _rec_codigo
            ds = classRecepcion.RECEPCIONES_DETALLE_LISTAR(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaDetalle.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("rde_cantidad"),
                                            ds.Tables(0).Rows(Fila)("rde_bultos"),
                                            ds.Tables(0).Rows(Fila)("rde_lote"),
                                            "",
                                            "",
                                            ds.Tables(0).Rows(Fila)("rde_bultosunidad"),
                                            ds.Tables(0).Rows(Fila)("rec_fila"),
                                            ds.Tables(0).Rows(Fila)("opd_fila"))
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


    Private Sub INICIALIZA()
        TabPage2.Parent = Nothing

        GrillaDetalle.DataSource = Nothing
        GrillaDetalle.Rows.Clear()

        Call CARGA_COMBO_PROVEEDOR()
        Call CARGA_COMBO_PERSONA_BODEGA_RECEPCION()
        Call CARGA_COMBO_EJECUTA_ALMACENAMENTO()

        txtOCompra.Text = "0"
        txtFactura.Text = "0"
        txtGuia.Text = "0"
        txtNumRec.Text = "0"
        txtChofer.Text = "-"
        txtPatente.Text = "-"
        txtFecha.Value = GLO_FECHA_SISTEMA
        txtObservacion.Text = ""

        txtCodigo.Text = ""
        txtNombreProducto.Text = ""
        txtCantidad.Text = "0"

        cmbProveedor.Enabled = True
        txtOCompra.Enabled = True
        ButtonGurdar.Enabled = True

        ButtonPaletizar.Enabled = False

        btnAprueba.Visible = False
        sepApruebaR.Visible = False
        btnRechazaR.Visible = False
        sepRechazoR.Visible = False

        ButtonGurdar.Enabled = True

        'btnRechazaR.Visible = False

        If (_ere_codigo = ESTADO_RECEPCION.APROBADA_POR_BODEGA) Then
            btnAprueba.Enabled = False
            btnRechazaR.Enabled = False
        End If

    End Sub

    Private Sub CARGA_COMBO_PROVEEDOR()
        Dim _msg As String
        Try
            Dim classComunes As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classComunes.cnn = _cnn
            _msg = ""
            ds = classComunes.CARGA_COMBO_PROVEEDOR(_msg)
            If _msg = "" Then
                Me.cmbProveedor.DataSource = ds.Tables(0)
                Me.cmbProveedor.DisplayMember = "MENSAJE"
                Me.cmbProveedor.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_PERSONA_BODEGA_RECEPCION()
        Dim _msg As String
        Try
            Dim classPersona As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classPersona.cnn = _cnn
            _msg = ""
            ds = classPersona.CARGA_COMBO_PERSONA_BODEGA_RECEPCION(_msg)
            If _msg = "" Then
                Me.cmbResponsable.DataSource = ds.Tables(0)
                Me.cmbResponsable.DisplayMember = "MENSAJE"
                Me.cmbResponsable.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PERSONA_BODEGA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonSeleccion_Click(sender As Object, e As EventArgs) Handles ButtonSeleccion.Click
        If txtCodigo.Text = "" Then
            MessageBox.Show("Debe seleccionar un producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodigo.Focus()
            Exit Sub
        End If

        If txtCantidad.Text = "" And txtCantidad.Text = "0" Then
            MessageBox.Show("Debe seleccionar un producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodigo.Focus()
            Exit Sub
        End If

        'If CInt(txtCantidad.Text) > _cantidad Then
        '    MessageBox.Show("La cantidad no puede ser mayor que " + _cantidad.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtCodigo.Focus()
        '    Exit Sub
        'End If

        GrillaDetalle.Rows(_fila).Cells(3).Value = txtCantidad.Text
        GrillaDetalle.Rows(_fila).Cells(4).Value = CInt(txtCantidad.Text) * _numBultos


        'Call CARGA_GRILLA_DESGLOSA_PRODUCTO_BULTOS()
        Call LIMPIA_DATOS_BUSQUEDA()
        _cantidad = 0

    End Sub

    Private Sub LIMPIA_DATOS_BUSQUEDA()
        txtCodigo.Text = ""
        txtNombreProducto.Text = ""
        txtCantidad.Text = "0"
    End Sub

    Private Sub CARGA_GRILLA_DESGLOSA_PRODUCTO_BULTOS()
        Dim class_recepcion As class_recepcion = New class_recepcion
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0


        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_recepcion.cnn = _cnn
            class_recepcion.codigo = txtCodigo.Text
            class_recepcion.cantidad = CInt(txtCantidad.Text)
            _msg = ""
            'Grilla.Rows.Clear()
            ds = class_recepcion.DESGLOSA_PRODUCTOS_POR_BULTO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            If _filaSeleccionada = 0 Then
                                Grilla.Rows(_fila).Cells(1).Value = ds.Tables(0).Rows(Fila)("codigo")
                                Grilla.Rows(_fila).Cells(0).Value = ds.Tables(0).Rows(Fila)("pro_codigo")
                                Grilla.Rows(_fila).Cells(1).Value = ds.Tables(0).Rows(Fila)("codigo")
                                Grilla.Rows(_fila).Cells(2).Value = ds.Tables(0).Rows(Fila)("nombre")
                                Grilla.Rows(_fila).Cells(3).Value = ds.Tables(0).Rows(Fila)("cantidad")
                                Grilla.Rows(_fila).Cells(4).Value = ds.Tables(0).Rows(Fila)("alto")
                                Grilla.Rows(_fila).Cells(5).Value = ds.Tables(0).Rows(Fila)("ancho")
                                Grilla.Rows(_fila).Cells(6).Value = ds.Tables(0).Rows(Fila)("fondo")
                                Grilla.Rows(_fila).Cells(7).Value = ds.Tables(0).Rows(Fila)("cpn")
                                Grilla.Rows(_fila).Cells(8).Value = ds.Tables(0).Rows(Fila)("pnu")
                                Grilla.Rows(_fila).Cells(9).Value = ds.Tables(0).Rows(Fila)("cpd")
                                Grilla.Rows(_fila).Cells(10).Value = ds.Tables(0).Rows(Fila)("pdu")
                                Grilla.Rows(_fila).Cells(12).Value = ds.Tables(0).Rows(Fila)("tipofila")
                                Grilla.Rows(_fila).Cells(12).Value = ds.Tables(0).Rows(Fila)("pro_codigorel")
                                Grilla.Rows(_fila).Cells(13).Value = Fila
                                _filaSeleccionada = 1
                            ElseIf _filaSeleccionada = 1 Then
                                _fila = _fila + 1
                                Grilla.Rows(_fila).Cells(1).Value = ds.Tables(0).Rows(Fila)("codigo")
                                Grilla.Rows(_fila).Cells(0).Value = ds.Tables(0).Rows(Fila)("pro_codigo")
                                Grilla.Rows(_fila).Cells(1).Value = ds.Tables(0).Rows(Fila)("codigo")
                                Grilla.Rows(_fila).Cells(2).Value = ds.Tables(0).Rows(Fila)("nombre")
                                Grilla.Rows(_fila).Cells(3).Value = ds.Tables(0).Rows(Fila)("cantidad")
                                Grilla.Rows(_fila).Cells(4).Value = ds.Tables(0).Rows(Fila)("alto")
                                Grilla.Rows(_fila).Cells(5).Value = ds.Tables(0).Rows(Fila)("ancho")
                                Grilla.Rows(_fila).Cells(6).Value = ds.Tables(0).Rows(Fila)("fondo")
                                Grilla.Rows(_fila).Cells(7).Value = ds.Tables(0).Rows(Fila)("cpn")
                                Grilla.Rows(_fila).Cells(8).Value = ds.Tables(0).Rows(Fila)("pnu")
                                Grilla.Rows(_fila).Cells(9).Value = ds.Tables(0).Rows(Fila)("cpd")
                                Grilla.Rows(_fila).Cells(10).Value = ds.Tables(0).Rows(Fila)("pdu")
                                Grilla.Rows(_fila).Cells(12).Value = ds.Tables(0).Rows(Fila)("tipofila")
                                Grilla.Rows(_fila).Cells(12).Value = ds.Tables(0).Rows(Fila)("pro_codigorel")
                                Grilla.Rows(_fila).Cells(13).Value = Fila
                            Else
                                Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("codigo"),
                                            ds.Tables(0).Rows(Fila)("nombre"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("alto"),
                                            ds.Tables(0).Rows(Fila)("ancho"),
                                            ds.Tables(0).Rows(Fila)("fondo"),
                                            ds.Tables(0).Rows(Fila)("cpn"),
                                            ds.Tables(0).Rows(Fila)("pnu"),
                                            ds.Tables(0).Rows(Fila)("cpd"),
                                            ds.Tables(0).Rows(Fila)("pdu"),
                                            ds.Tables(0).Rows(Fila)("tipofila"),
                                            ds.Tables(0).Rows(Fila)("pro_codigorel"),
                                            Fila)
                            End If

                            Fila = Fila + 1
                        Loop
                        Call PINTA_GRILLA()
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_DESGLOSA_PRODUCTO_BULTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_DESGLOSA_PRODUCTO_BULTOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub PINTA_GRILLA()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(11).Value = "C" Then
                row.DefaultCellStyle.BackColor = Color.Gainsboro
                row.DefaultCellStyle.ForeColor = Color.Black
            ElseIf row.Cells(11).Value = "T" Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
                row.DefaultCellStyle.ForeColor = Color.Black
            End If

        Next
    End Sub

    Private Sub ButtonLimpiar_Click(sender As Object, e As EventArgs) Handles ButtonLimpiar.Click
        Call LIMPIA_DATOS_BUSQUEDA()
    End Sub

    Private Sub QuitarDeLaSelecciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarDeLaSelecciónToolStripMenuItem.Click
        Dim codigo As Integer = 0
        Dim Fila As Integer = 0
        Try
            'If Grilla.Rows(_fila).Cells(12).Value = "" Then
            '    MessageBox.Show("Debe seleccionar una celda con un código de producto para poder quitar la fila", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If

            codigo = Grilla.Rows(_fila).Cells(12).Value

            Do While Fila <= Grilla.RowCount
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(12).Value = codigo Then
                        Me.Grilla.Rows.Remove(row)
                        Fila = Fila - 1
                    End If
                Next
                Fila = Fila + 1
            Loop

            'For Each row As DataGridViewRow In Me.Grilla.Rows
            '    If row.Cells(12).Value = codigo Then
            '        Me.Grilla.Rows.Remove(row)
            '    End If
            'Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ELIMINA_ITEM(ByVal codigo As Integer)
        Try
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(12).Value = codigo Then
                    Me.Grilla.Rows.Remove(row)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick

    End Sub

    Private Sub Grilla_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            _colum = e.ColumnIndex
            _fila = e.RowIndex
        End If
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA_DATOS() = False Then
            Exit Sub
        End If

        Call GUARDAR()
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

                classRecepcion.rec_numero = _rec_codigo
                classRecepcion.car_codigo = cmbProveedor.SelectedValue
                classRecepcion.rec_nguia = IIf(txtGuia.Text = "", "0", txtGuia.Text)
                classRecepcion.rec_nfactura = IIf(txtFactura.Text = "", "0", txtFactura.Text)
                classRecepcion.rec_ordencompra = CLng(txtOCompra.Text)
                classRecepcion.emp_codigo = GLO_USUARIO_ACTUAL
                classRecepcion.rec_fecharecepcion = txtFecha.Value
                classRecepcion.rec_empingreso = cmbResponsable.SelectedValue
                classRecepcion.rec_nombrechofer = IIf(txtChofer.Text = "", "-", txtChofer.Text)
                classRecepcion.rec_patente = IIf(txtPatente.Text = "", "-", txtPatente.Text)
                classRecepcion.rec_observacion = IIf(txtObservacion.Text = "", "-", txtObservacion.Text)

                ds = classRecepcion.RECEPCION_GUARDA_REGISTRO(_msgError, conexion)
                If _msgError <> "" Then
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        _rec_codigo = ds.Tables(0).Rows(0)("codigo")
                        txtNumRec.Text = _rec_codigo
                    End If
                End If

                'ELIMINA DETALLE SOLO CUANDO ESTA EN TRANSITO
                'If _ere_codigo = ESTADO_RECEPCION.EN_TRANSITO Then
                '    ds = Nothing
                '    classRecepcion.cnn = _cnn
                '    classRecepcion.rec_numero = _rec_codigo
                '    classRecepcion.ocp_codigo = CLng(txtOCompra.Text)

                '    ds = classRecepcion.RECEPCION_ELIMINA_DETALLE(_msgError, conexion)
                '    If _msgError <> "" Then
                '        ds = Nothing
                '        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        Exit Sub
                '    Else
                '        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                '            ds = Nothing
                '            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '            Exit Sub
                '        End If
                '    End If
                'End If


                Do While fila < GrillaDetalle.RowCount
                    classRecepcion.rec_numero = _rec_codigo
                    classRecepcion.rec_fila = GrillaDetalle.Rows(fila).Cells(9).Value
                    classRecepcion.pro_codigo = GrillaDetalle.Rows(fila).Cells(0).Value
                    classRecepcion.pro_codigointerno = GrillaDetalle.Rows(fila).Cells(1).Value
                    classRecepcion.pro_nombre = GrillaDetalle.Rows(fila).Cells(2).Value
                    classRecepcion.rde_cantidad = GrillaDetalle.Rows(fila).Cells(3).Value
                    classRecepcion.rde_bulto = GrillaDetalle.Rows(fila).Cells(4).Value

                    If GrillaDetalle.Rows(fila).Cells(5).Value = "" Then
                        classRecepcion.rde_folio = "-"
                    Else
                        classRecepcion.rde_folio = GrillaDetalle.Rows(fila).Cells(5).Value
                    End If


                    classRecepcion.rde_bultosunidad = GrillaDetalle.Rows(fila).Cells(8).Value
                    classRecepcion.car_codigo = cmbProveedor.SelectedValue
                    classRecepcion.ocp_numero = CLng(txtOCompra.Text)

                    classRecepcion.opd_fila = GrillaDetalle.Rows(fila).Cells(10).Value

                    ds = classRecepcion.RECEPCION_DETALLE_GUARDA_REGISTRO(_msgError, conexion)
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

                ds = Nothing
                classRecepcion.cnn = _cnn
                classRecepcion.rec_numero = _rec_codigo
                classRecepcion.ere_codigo = ESTADO_RECEPCION.EN_PROCESO
                classRecepcion.car_codigo = cmbProveedor.SelectedValue
                classRecepcion.ocp_numero = CLng(txtOCompra.Text)

                ds = classRecepcion.RECEPCION_CAMBIA_ESTADO(_msgError, conexion)
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


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                respuesta = MessageBox.Show("La recepcion de compra fue guardada en forma correcta" _
                                            + Chr(10) + "¿Desea generar el paletizado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                TabPage2.Parent = TabControl1

                If respuesta = vbYes Then
                    '_rec_codigo = 0
                    'Call INICIALIZA()
                    ButtonPaletizar.Enabled = True

                    Dim frm As frm_paletizar = New frm_paletizar
                    frm.cnn = _cnn
                    frm.rec_codigo = CInt(txtNumRec.Text)
                    frm.fechaRecepcion = txtFecha.Value
                    frm.car_codigo = cmbProveedor.SelectedValue
                    frm.ere_codigo = _ere_codigo
                    frm.titulo = "RECEPCIÓN: " + txtNumRec.Text + " - PROVEEDOR: " + cmbProveedor.Text
                    frm.ShowDialog()
                    'Else
                    '    Me.Dispose()
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function VALIDA_DATOS() As Boolean
        VALIDA_DATOS = False

        If cmbProveedor.Text = "" Then
            MessageBox.Show("Debe seleccionar un proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbProveedor.Focus()
            Exit Function
        End If

        If cmbResponsable.Text = "" Then
            MessageBox.Show("Debe seleccionar un responsable", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbResponsable.Focus()
            Exit Function
        End If

        If txtFactura.Text = "" Then
            txtFactura.Text = "0"
        End If

        If txtGuia.Text = "" Then
            txtGuia.Text = "0"
        End If

        If (txtFactura.Text = "0" And txtGuia.Text = "0") Then
            MessageBox.Show("Debe ingresar el numero de la factura o guia de despacho", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFactura.Focus()
            Exit Function
        End If

        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
            If row.Cells(1).Value <> "" Then
                If row.Cells(5).Value = "" Then
                    MessageBox.Show("Debe ingresar el lote en el código: " + row.Cells(1).Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    GrillaDetalle.Focus()
                    Exit Function
                End If
            End If
        Next

        VALIDA_DATOS = True

    End Function

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call BUSCA_DETALLES_OC_PENDIENTES()
    End Sub

    Private Sub BUSCA_DETALLES_OC_PENDIENTES()
        Dim classOrden As class_rec_orden_compra = New class_rec_orden_compra
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing

            If cmbProveedor.Text = "" Then
                MessageBox.Show("Debe seleccionar un proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbProveedor.Focus()
                Exit Sub
            End If

            If txtOCompra.Text = "" Or txtOCompra.Text = "0" Then
                MessageBox.Show("Debe ingresar un número de orden de compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtOCompra.Focus()
                Exit Sub
            End If


            classOrden.cnn = _cnn
            classOrden.car_codigo = cmbProveedor.SelectedValue
            classOrden.ocp_numero = CLng(txtOCompra.Text)

            _msg = ""
            GrillaDetalle.Rows.Clear()
            ds = classOrden.OC_DETALLE_CON_SALDO_LISTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("opd_cantidadpendiente"),
                                            ds.Tables(0).Rows(Fila)("pro_numerobulto"),
                                            "",
                                            "",
                                            "",
                                            ds.Tables(0).Rows(Fila)("pro_bultosporunidad"),
                                            0,
                                            ds.Tables(0).Rows(Fila)("opd_fila"))


                            'txtCodigo.Text = ds.Tables(0).Rows(Fila)("pro_codigointerno")
                            'txtCantidad.Text = ds.Tables(0).Rows(Fila)("opd_cantidadpendiente")
                            ''Call CARGA_GRILLA_DESGLOSA_PRODUCTO_BULTOS()
                            'txtCodigo.Text = ""
                            'txtCantidad.Text = ""

                            Fila = Fila + 1
                        Loop
                    Else
                        MessageBox.Show("No existe la orden de compra para el proveedor seleccionado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\BUSCA_DETALLES_OC_PENDIENTES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "BUSCA_DETALLES_OC_PENDIENTES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    'Private Sub Grilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentDoubleClick

    '    If Grilla.Rows(e.RowIndex).Cells(11).Value = "C" Then
    '        _fila = e.RowIndex
    '        txtCodigo.Text = Grilla.Rows(e.RowIndex).Cells(1).Value
    '        txtNombreProducto.Text = Grilla.Rows(e.RowIndex).Cells(2).Value
    '        txtCantidad.Text = Grilla.Rows(e.RowIndex + 1).Cells(3).Value
    '        _cantidad = Grilla.Rows(e.RowIndex + 1).Cells(3).Value
    '        _filaSeleccionada = Grilla.Rows(e.RowIndex).Cells(13).Value
    '    End If

    'End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub GrillaDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellContentClick
        Try
            If e.ColumnIndex = 6 Then
                _fila = e.RowIndex
                _proCodigo = GrillaDetalle.Rows(e.RowIndex).Cells(0).Value
                txtCodigo.Text = GrillaDetalle.Rows(e.RowIndex).Cells(1).Value
                txtNombreProducto.Text = GrillaDetalle.Rows(e.RowIndex).Cells(2).Value
                txtCantidad.Text = GrillaDetalle.Rows(e.RowIndex).Cells(3).Value
                _cantidad = GrillaDetalle.Rows(e.RowIndex).Cells(3).Value
                _numBultos = GrillaDetalle.Rows(e.RowIndex).Cells(8).Value
            ElseIf e.ColumnIndex = 7 Then
                Dim respuesta As Integer
                respuesta = MessageBox.Show("¿Esta seguro(a) de quitar la fila seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If respuesta = vbYes Then
                    Me.GrillaDetalle.Rows.RemoveAt(e.RowIndex)
                    'If GrillaDetalle.RowCount = 0 Then
                    '    GrillaDetalle.Rows.Add(0, "", "", "", "", "", "", "")
                    'End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdSelecMulti_Click(sender As Object, e As EventArgs) Handles cmdSelecMulti.Click
        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        'If cmbTipoMultimedia.SelectedValue = 2 Then
        '    openFileDialog1.Filter = "Archivo de imagenes (JPEG,PNG)|*.jpg;*.jpeg;*.png"
        'Else
        openFileDialog1.Filter = "Todos los archivos|*.*"
        'End If

        openFileDialog1.Title = "seleccione archivo"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pasoDesdeMulti = openFileDialog1.FileName
            txtMultRuta.Text = openFileDialog1.FileName
            _nombreArchivo = (System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName)) & (System.IO.Path.GetExtension(openFileDialog1.FileName))
            'txtMultiNombre.Text = _nombreArchivo
            _extension = System.IO.Path.GetExtension(openFileDialog1.FileName)
        End If
    End Sub


    Private Sub GUARDAR_REGISTRO_MULTIMEDIA()
        Dim class_recepcion As class_recepcion = New class_recepcion
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Dim _msg As String = ""

        Try
            class_recepcion.cnn = _cnn
            class_recepcion.rec_numero = txtNumRec.Text
            class_recepcion.rec_fila = fila
            class_recepcion.rec_nombre = txtNombreArchivo.Text
            class_recepcion.rec_nombrearchivo = _nombreArchivo
            class_recepcion.rec_url = pasoDesdeMulti

            ds = class_recepcion.ADJUNTO_GUARDA_REGISTRO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else

                    If fila = 0 Then
                        '_pum_codigo = ds.Tables(0).Rows(0)("codigo")
                        'If _esEdicion = False And cmbTipoMultimedia.SelectedValue = 2 Then
                        If My.Computer.FileSystem.FileExists(pasoDocumentosResepcion + _nombreArchivo) Then
                            My.Computer.FileSystem.DeleteFile(pasoDocumentosResepcion + _nombreArchivo)
                            My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoDocumentosResepcion + _nombreArchivo, overwrite:=False)
                        Else
                            My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoDocumentosResepcion + _nombreArchivo, overwrite:=False)
                        End If
                        'Else
                        '    If cmbTipoMultimedia.SelectedValue <> 2 Then
                        '        If My.Computer.FileSystem.FileExists(pasoHasta_mul + _nombreArchivo) Then
                        '            My.Computer.FileSystem.DeleteFile(pasoHasta_mul + _nombreArchivo)
                        '            My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoHasta_mul + _nombreArchivo, overwrite:=False)
                        '        Else
                        '            My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoHasta_mul + _nombreArchivo, overwrite:=False)
                        '        End If
                        '    End If

                        'End If
                    End If

                End If
            End If
            ds = Nothing
            MessageBox.Show("El archivo fue ingresado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            fila = 0
            txtMultRuta.Text = ""
            txtNombreArchivo.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        Call GUARDAR_REGISTRO_MULTIMEDIA()
        Call BUSCA_ADJUNTO_RECEPCION()
    End Sub
    Private Sub BUSCA_ADJUNTO_RECEPCION()
        Dim classRecepcion As class_recepcion = New class_recepcion

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            Dim Fila As Integer = 0

            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = CInt(txtNumRec.Text)
            _msg = ""
            GrillaAdjunto.Rows.Clear()
            ds = classRecepcion.RECEPCIONES_ADJUNTO_LISTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("rec_nombrearchivo") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaAdjunto.Rows.Add(ds.Tables(0).Rows(Fila)("rec_fila"),
                                            ds.Tables(0).Rows(Fila)("rec_nombre"),
                                            ds.Tables(0).Rows(Fila)("rec_nombrearchivo"))
                            Fila = Fila + 1
                        Loop
                        'Else
                        '    MessageBox.Show("No existe la orden de compra para el proveedor seleccionado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\BUSCA_ADJUNTO_RECEPCION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "BUSCA_ADJUNTO_RECEPCION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub GrillaAdjunto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaAdjunto.CellContentClick
        Try
            If e.ColumnIndex = 3 Then
                fila = GrillaAdjunto.Rows(e.RowIndex).Cells(0).Value
                txtNombreArchivo.Text = GrillaAdjunto.Rows(e.RowIndex).Cells(1).Value
            ElseIf e.ColumnIndex = 4 Then
                System.Diagnostics.Process.Start(pasoDocumentosResepcion + GrillaAdjunto.Rows(e.RowIndex).Cells(2).Value)
            ElseIf e.ColumnIndex = 5 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Call ELIMINA_RECEPCION_ADJUNTO(GrillaAdjunto.Rows(e.RowIndex).Cells(0).Value, GrillaAdjunto.Rows(e.RowIndex).Cells(2).Value)
                End If
            End If
        Catch ex As Exception
            'Message
        End Try
    End Sub

    Private Sub ELIMINA_RECEPCION_ADJUNTO(ByVal fila As Integer, ByVal _Archivo As String)
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""
        Try
            ds = Nothing
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = CInt(txtNumRec.Text)
            classRecepcion.rec_fila = fila
            ds = classRecepcion.RECEPCIONES_ADJUNTO_ELIMINA(_msgError)
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

            If My.Computer.FileSystem.FileExists(pasoDocumentosResepcion + _Archivo) Then
                My.Computer.FileSystem.DeleteFile(pasoDocumentosResepcion + _Archivo)
            End If

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call BUSCA_ADJUNTO_RECEPCION()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ButtonPaletizar_Click(sender As Object, e As EventArgs) Handles ButtonPaletizar.Click
        Dim strCodigos As String = ""


        If EXISTE_VULOMETRIA(CInt(txtNumRec.Text), "RE", strCodigos) = True Then
            If strCodigos <> "" Then
                MessageBox.Show("Se requiere completar los datos de volumetria para los siguientes codigos: " _
                                + Chr(10) + "" + strCodigos, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If EXISTE_BULTO_VALIDA(CInt(txtNumRec.Text), "RE", strCodigos) = True Then
            If strCodigos <> "" Then
                MessageBox.Show("Falta ingresar informacion de los bultos para los siguientes codigos: " _
                                + Chr(10) + "" + strCodigos, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        'EXISTE_VULOMETRIA(CInt(txtNumRec.Text), "RE", strCodigos)
        'If strCodigos = "" Then
        '    MessageBox.Show("Se requiere completar los datos de volumetria para los siguientes codigos: " _
        '                            + Chr(10) + "" + strCodigos, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If

        Dim frm As frm_paletizar = New frm_paletizar
        frm.cnn = _cnn
        frm.rec_codigo = CInt(txtNumRec.Text)
        frm.fechaRecepcion = txtFecha.Value
        frm.car_codigo = cmbProveedor.SelectedValue
        frm.ere_codigo = _ere_codigo
        frm.titulo = "RECEPCIÓN: " + txtNumRec.Text + " - PROVEEDOR: " + cmbProveedor.Text
        frm.ShowDialog()
    End Sub

    Private Function EXISTE_VULOMETRIA(ByVal recNumero As Integer, ByVal tipDocumento As String, ByRef Codigos As String) As Boolean
        Dim classProducto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_VULOMETRIA = False
        Try
            classProducto.cnn = _cnn
            classProducto.numDocumento = recNumero
            classProducto.tipDocumento = tipDocumento

            ds = classProducto.OBTIENE_VOLUMETRIA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigos") <> "" Then
                        Codigos = ds.Tables(0).Rows(Fila)("codigos")
                        Return True
                        Exit Function
                    End If
                End If
                Return False
            Else
                Return False
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function EXISTE_BULTO_VALIDA(ByVal recNumero As Integer, ByVal tipDocumento As String, ByRef Codigos As String) As Boolean
        Dim classProducto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        EXISTE_BULTO_VALIDA = False
        Try
            classProducto.cnn = _cnn
            classProducto.numDocumento = recNumero
            classProducto.tipDocumento = tipDocumento

            ds = classProducto.VALIDA_EXISTENCIA_BULTOS(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigos") <> "" Then
                        Codigos = ds.Tables(0).Rows(Fila)("codigos")
                        EXISTE_BULTO_VALIDA = True
                    End If
                End If
            Else
                EXISTE_BULTO_VALIDA = False
                MessageBox.Show(_msgError + "\EXISTE_BULTO_VALIDA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            EXISTE_BULTO_VALIDA = False
            MessageBox.Show(ex.Message + "\EXISTE_BULTO_VALIDA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Sub OBTIENE_ESTADO_RECEPCION()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0

        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = CInt(txtNumRec.Text)
            ds = classRecepcion.OBTIENE_ESTADO_RECEPCION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("ere_codigo") > 0 Then
                        If (ds.Tables(0).Rows(Fila)("ere_codigo") = ESTADO_RECEPCION.FINALIZADA_CON_DIFERENCIA) Or (ds.Tables(0).Rows(Fila)("ere_codigo") = ESTADO_RECEPCION.FINALIZADA_SIN_DIFERENCIA) Or (ds.Tables(0).Rows(Fila)("ere_codigo") = ESTADO_RECEPCION.APROBADA_POR_BODEGA) Then
                            ButtonGurdar.Enabled = False
                            ButtonPaletizar.Enabled = False
                            _ere_codigo = ds.Tables(0).Rows(Fila)("ere_codigo")
                        End If
                        'Else
                        '    ButtonGurdar.Enabled = False
                        '    ButtonPaletizar.Enabled = False
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_ESTADO_RECEPCION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\OBTIENE_ESTADO_RECEPCION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAprueba_Click(sender As Object, e As EventArgs) Handles btnAprueba.Click
        Call APRUEBA_RECHAZA_RECEPCION(ESTADO_RECEPCION.APROBADA_POR_BODEGA)
    End Sub

    Private Sub APRUEBA_RECHAZA_RECEPCION(ByVal edeCodigo As Integer)
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim classMOV As class_movimientos = New class_movimientos
        Dim classInv As class_inventario = New class_inventario

        Dim ds As DataSet = New DataSet
        Dim dsDetalle As DataSet = New DataSet
        Dim dsInventario As DataSet = New DataSet
        Dim dsMov As DataSet = New DataSet

        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Dim fila As Integer = 0
        Dim _Folio As Long = 0
        Dim mes As String = ""
        Dim dia As String = ""



        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)

                conexion.Open()
                classRecepcion.rec_codigo = _rec_codigo
                classRecepcion.ede_codigo = edeCodigo

                ds = classRecepcion.APRUEBA_RECHAZA_RECEPCION(_msgError, conexion)
                If ds.Tables(0).Rows.Count > 0 Then
                    If _msgError = "" Then
                        If ds.Tables(0).Rows(0)("CODIGO") <= 0 Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                If edeCodigo = ESTADO_RECEPCION.EN_PROCESO Then
                    ds = Nothing
                    classRecepcion.rec_numero = _rec_codigo
                    ds = classRecepcion.RECEPCION_BORRA_TABLAS(_msgError, conexion)
                    If ds.Tables(0).Rows.Count > 0 Then
                        If _msgError = "" Then
                            If ds.Tables(0).Rows(0)("CODIGO") <= 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                End If

                If edeCodigo = ESTADO_RECEPCION.APROBADA_POR_BODEGA Then
                    If CStr(txtFecha.Value.Month).Length = 1 Then
                        mes = Trim("0" + CStr(txtFecha.Value.Month))
                    Else
                        mes = CStr(txtFecha.Value.Month)
                    End If

                    classMOV.mov_folio = 0
                    classMOV.tmo_codigo = TIPO_MOVIMIENTO.ENTRADA
                    classMOV.bod_codigo = GLO_BODEGA_RECEPCION
                    classMOV.mov_fechamovimiento = GLO_FECHA_SISTEMA
                    classMOV.mov_mes = mes
                    classMOV.mov_anno = CStr(txtFecha.Value.Year) 'CStr(_fechaRecepcion.Year)
                    classMOV.mov_usuario = GLO_USUARIO_ACTUAL

                    classMOV.car_codigo = cmbProveedor.SelectedValue
                    classMOV.tdo_codigo = COM_TIPO_DOCUMENTO.RECEPCION
                    classMOV.mov_nomdoc = CLng(txtNumRec.Text) '_rec_codigo


                    classMOV.mov_foliorelacionado = 0
                    classMOV.mov_observacion = "INGRESO REALIZADO A TRAVEZ DE LA RECEPCIÓN NÚMERO: " + txtNumRec.Text '_rec_codigo.ToString

                    ds = classMOV.MOVIMIENTOS_GUARDA_ENCABEZADO(_msgError, conexion)
                    If ds.Tables(0).Rows.Count > 0 Then
                        If _msgError = "" Then
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Sub
                            Else
                                _Folio = ds.Tables(0).Rows(0)("CODIGO")
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

                    classMOV.mov_folio = _Folio
                    ds = Nothing
                    ds = classMOV.ELIMINA_DETALLE_MOVIMIENTO(_msgError, conexion)
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

                    fila = 0
                    ds = Nothing
                    classRecepcion.cnn = _cnn
                    classRecepcion.rec_numero = CInt(txtNumRec.Text) '_rec_codigo
                    'classRecepcion.cant_fil = CInt(txtUnidadFil.Text)
                    ds = classRecepcion.DETALLE_MOVIMIENTO_PALETIZADO(_msgError, conexion)
                    If _msgError = "" Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            'GrillaSerie.Rows.Clear()
                            If ds.Tables(0).Rows(fila)("pro_codigo") > 0 Then
                                Do While fila < ds.Tables(0).Rows.Count

                                    ' Verifica si el producto esta asociado a la bodega predeterminada para embarque
                                    ' ==============================================================================
                                    classInv.bod_codigo = GLO_BODEGA_RECEPCION
                                    classInv.pro_codigo = ds.Tables(0).Rows(fila)("pro_codigo")
                                    dsInventario = classInv.VERIFICA_PRODUCTO_BODEGA(_msgError, conexion)
                                    If _msgError <> "" Then
                                        If conexion.State = ConnectionState.Open Then
                                            conexion.Close()
                                        End If
                                        ds = Nothing
                                        dsInventario = Nothing
                                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    Else
                                        If dsInventario.Tables(0).Rows(0)("CODIGO") < 0 Then
                                            If conexion.State = ConnectionState.Open Then
                                                conexion.Close()
                                            End If
                                            MessageBox.Show(dsDetalle.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            ds = Nothing
                                            dsInventario = Nothing
                                            Exit Sub
                                        End If
                                    End If
                                    ' Fin verificación archivo
                                    ' ===============================================================================

                                    classMOV.mov_folio = _Folio
                                    classMOV.pro_codigo = ds.Tables(0).Rows(fila)("pro_codigo")
                                    classMOV.dmo_cantidad = ds.Tables(0).Rows(fila)("pre_cantidad")
                                    classMOV.dmo_bultos = ds.Tables(0).Rows(fila)("pro_numerobulto")
                                    classMOV.dmo_totalbultos = ds.Tables(0).Rows(fila)("pro_totalbulto")
                                    dsDetalle = classMOV.MOVIMIENTOS_GUARDA_DETALLE(_msgError, conexion)
                                    If _msgError <> "" Then
                                        If conexion.State = ConnectionState.Open Then
                                            conexion.Close()
                                        End If
                                        ds = Nothing
                                        dsDetalle = Nothing
                                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    Else
                                        If dsDetalle.Tables(0).Rows(0)("CODIGO") < 0 Then
                                            If conexion.State = ConnectionState.Open Then
                                                conexion.Close()
                                            End If
                                            MessageBox.Show(dsDetalle.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            ds = Nothing
                                            dsDetalle = Nothing
                                            Exit Sub
                                        End If
                                    End If

                                    ' Actualiza stock
                                    ' ============================================================
                                    classInv.bod_codigo = GLO_BODEGA_RECEPCION
                                    classInv.pro_codigo = ds.Tables(0).Rows(fila)("pro_codigo")
                                    classInv.tmo_codigo = TIPO_MOVIMIENTO.ENTRADA
                                    classInv.cantidad = ds.Tables(0).Rows(fila)("pre_cantidad")
                                    dsMov = classInv.ACTUALIZA_STOCK_MOVIMIENTOS(_msgError, conexion)
                                    If _msgError <> "" Then
                                        If conexion.State = ConnectionState.Open Then
                                            conexion.Close()
                                        End If
                                        ds = Nothing
                                        dsDetalle = Nothing
                                        dsMov = Nothing
                                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    Else
                                        If dsMov.Tables(0).Rows(0)("CODIGO") < 0 Then
                                            If conexion.State = ConnectionState.Open Then
                                                conexion.Close()
                                            End If
                                            ds = Nothing
                                            dsDetalle = Nothing
                                            dsMov = Nothing
                                            MessageBox.Show(dsMov.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If
                                    End If
                                    ' Fin actualiza stock
                                    ' ============================================================
                                    fila = fila + 1
                                Loop
                            End If
                        End If
                    Else
                        MessageBox.Show(_msgError + "\GUARDAR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    fila = 0
                    _msgError = ""
                    ds = Nothing
                    dsDetalle = Nothing
                    classRecepcion.cnn = _cnn
                    classRecepcion.rec_numero = CInt(txtNumRec.Text) '_rec_codigo
                    dsDetalle = classRecepcion.RECEPCION_PALLET_LISTADO(_msgError, conexion)
                    If _msgError = "" Then
                        If dsDetalle.Tables(0).Rows.Count > 0 Then
                            If dsDetalle.Tables(0).Rows(fila)("pro_codigo") > 0 Then
                                Do While fila < dsDetalle.Tables(0).Rows.Count
                                    'GUARDA ENCABEZADO PALLET
                                    classInv.serie_pallet = dsDetalle.Tables(0).Rows(fila)("prd_palletserie")
                                    classInv.cantidad = dsDetalle.Tables(0).Rows(fila)("prd_cantidad")
                                    classInv.ubi_codigo = GLO_UBI_PISO_RECEPCION
                                    ds = classInv.INGRESA_PALLET_ENCABEZADO(_msgError, conexion)
                                    If _msgError <> "" Then
                                        If conexion.State = ConnectionState.Open Then
                                            conexion.Close()
                                        End If
                                        ds = Nothing
                                        dsDetalle = Nothing
                                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    Else
                                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                            If conexion.State = ConnectionState.Open Then
                                                conexion.Close()
                                            End If
                                            ds = Nothing
                                            dsDetalle = Nothing
                                            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If
                                    End If

                                    'GUARDA DETALLE PALLET
                                    classInv.serie_pallet = dsDetalle.Tables(0).Rows(fila)("prd_palletserie")
                                    classInv.pro_codigo = dsDetalle.Tables(0).Rows(fila)("pro_codigo")
                                    classInv.num_bulto = dsDetalle.Tables(0).Rows(fila)("pro_numbulto")
                                    classInv.cantidad = dsDetalle.Tables(0).Rows(fila)("prd_cantidad")
                                    ds = classInv.INGRESA_PALLET_DETALLE(_msgError, conexion)
                                    If _msgError <> "" Then
                                        If conexion.State = ConnectionState.Open Then
                                            conexion.Close()
                                        End If
                                        ds = Nothing
                                        dsDetalle = Nothing
                                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    Else
                                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                            If conexion.State = ConnectionState.Open Then
                                                conexion.Close()
                                            End If
                                            ds = Nothing
                                            dsDetalle = Nothing
                                            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If
                                    End If
                                    fila = fila + 1
                                Loop
                            End If
                        End If
                    End If

                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default

                If edeCodigo = ESTADO_RECEPCION.APROBADA_POR_BODEGA Then
                    MessageBox.Show("La recepción N°: " + txtNumRec.Text + " ha sigo aprobada con exito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnAprueba.Enabled = False
                    grpAsignacion.Visible = True
                ElseIf edeCodigo = ESTADO_RECEPCION.EN_PROCESO Then
                    MessageBox.Show("La recepción N°: " + txtNumRec.Text + " ha sigo rechazada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Dispose()
                End If

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRechazaR_Click(sender As Object, e As EventArgs) Handles btnRechazaR.Click
        Dim respuesta As Integer

        Try
            respuesta = MessageBox.Show("Si la recepción es rechazada, se eliminarán todos los registros asociada a ella" _
                                                + Chr(10) + "¿Desea seguir con la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbYes Then
                Call APRUEBA_RECHAZA_RECEPCION(ESTADO_RECEPCION.EN_PROCESO)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frm_recepcion_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Call OBTIENE_ESTADO_RECEPCION()
    End Sub

    Private Sub ButtonAsignar_Click(sender As Object, e As EventArgs) Handles ButtonAsignar.Click
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0

        Try
            If cmbResAlmacenamiento.Text = "" Then
                MessageBox.Show("Debe seleccionar a una persona para asignar la recepción para su almacenamiento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbResAlmacenamiento.Focus()
                Exit Sub
            End If

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classUbicacion.rec_numero = _rec_codigo
                classUbicacion.usu_almacenamiento = cmbResAlmacenamiento.SelectedValue

                ds = Nothing
                ' ASIGNA RECEPCIÓN PARA SU ALMACENAMIENTO
                classUbicacion.cnn = _cnn
                classUbicacion.rec_numero = _rec_codigo
                classUbicacion.usu_almacenamiento = cmbResAlmacenamiento.SelectedValue

                ds = classUbicacion.RECEPCION_ASIGNA_PARA_UBICACION(_msgError, conexion)
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


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                respuesta = MessageBox.Show("La recepción fue asignada en forma correcta para su almacenmiento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class