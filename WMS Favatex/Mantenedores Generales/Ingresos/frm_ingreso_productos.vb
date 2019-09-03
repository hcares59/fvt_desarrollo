Imports System.Data.SqlClient
Imports System.Data
Imports System.Transactions
Imports System.IO

Public Class frm_ingreso_productos
    Dim _cnn As String
    Dim _pro_codigo As Integer
    Dim _bul_codigo As Integer
    Dim pasoDesdeDoc As String
    Dim pasoDesdeMulti As String
    Dim _pum_codigo As Integer
    Dim _nombreArchivo As String
    Dim _extension As String
    Dim _esEdicion As Boolean
    Dim _tdo_codigo As Integer

    Dim _nombreDocto As String

    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""

    Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
        End Set
    End Property

    Private Sub frm_ingreso_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"

        Call INICIALIZA()
        Call HABILITA_OPCIONES()

        If _pro_codigo > 0 Then
            Call CARGA_REGISTRO()
            Call CARGA_GRILLA()
            Call CARGA_IMG_PRODUCTOS()
            Call CARGA_GRILLA_MULTI()
            Call CARGA_GRILLA_DOCUMENTOS()
            Call CARGA_GRILLA_EXCLUSIBIDAD()
            Call CARGA_GRILLAS_BODEGAS()
            Call CARGA_GRILLA_PRODUCTOS_POR_ASOCIAR()
            Call CARGA_GRILLA_PRODUCTOS_ASOCIADOS()
        End If


        'img1.Image = Image.FromFile("C:\fotos\1.jpg")
        'img2.Image = Image.FromFile("C:\fotos\2.jpg")
        'img3.Image = Image.FromFile("C:\fotos\3.jpg")
        'img4.Image = Image.FromFile("C:\fotos\4.jpg")
        'img5.Image = Image.FromFile("C:\fotos\5.jpg")
        'img6.Image = Image.FromFile("C:\fotos\6.jpg")
    End Sub

    Private Sub HABILITA_OPCIONES()
        'Datos generales
        ButtonGurdar.Enabled = False

        'Pestaña de bultos
        btn_agregar.Enabled = False
        Grilla.Columns(7).Visible = False

        'Pestaña multimedia
        btnAgregaMultimedia.Enabled = False
        grillaMulti.Columns(6).Visible = False

        'Documentos
        btnAgregaDoc.Enabled = False
        grillaDoctos.Columns(5).Visible = False

        'Exclusividad
        Button1.Enabled = False

        If ES_COMERCILA = True Then
            ButtonGurdar.Enabled = True
            Button1.Enabled = True
        End If

        If ES_DISENO = True Then
            btn_agregar.Enabled = True
            Grilla.Columns(7).Visible = True

            btnAgregaMultimedia.Enabled = True
            grillaMulti.Columns(6).Visible = True

            grillaDoctos.Columns(5).Visible = True

            btnAgregaDoc.Enabled = True
        End If



    End Sub

    Private Sub CARGA_GRILLAS_BODEGAS()
        Dim classProducto As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classProducto.cnn = _cnn
            classProducto.pro_codigo = _pro_codigo

            _msg = ""
            grdProdBodegas.Rows.Clear()
            ds = classProducto.PRODUCTOS_ASOCIADOS_BODEGAS(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("bod_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grdProdBodegas.Rows.Add(ds.Tables(0).Rows(Fila)("bod_codigo"),
                                            ds.Tables(0).Rows(Fila)("bod_nombre"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
                'Me.Text = "LISTADO DE DOCUMENTOS DEL PRODUCTO - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLAS_BODEGAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLAS_BODEGAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_EXCLUSIBIDAD()
        Dim class_producto As class_producto = New class_producto
        Dim Fila As Integer = 0
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim ds As DataSet = New DataSet
        Dim _msg As String
        ds = Nothing

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                class_producto.cnn = _cnn
                class_producto.pro_codigo = _pro_codigo

                _msg = ""

                grd_Exclusividad.Rows.Clear()
                ds = class_producto.EXCLUSIBIDAD_CLIENTE_LISTADO(_msg, conexion)
                If _msg = "" Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                            Do While Fila < ds.Tables(0).Rows.Count
                                grd_Exclusividad.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                                ds.Tables(0).Rows(Fila)("car_sel"),
                                                ds.Tables(0).Rows(Fila)("car_rut"),
                                                ds.Tables(0).Rows(Fila)("car_nombre"))
                                Fila = Fila + 1
                            Loop
                        End If
                    End If
                    'Me.Text = "LISTADO DE DOCUMENTOS DEL PRODUCTO - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
                Else
                    MessageBox.Show(_msg + "\CARGA_GRILLA_EXCLUSIBIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grilla_excclusividad", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub CARGA_GRILLA_DOCUMENTOS()
        Dim class_proddoc As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_proddoc.cnn = _cnn
            class_proddoc.pro_codigo = _pro_codigo
            class_proddoc.tdp_codigo = 0
            _msg = ""
            grillaDoctos.Rows.Clear()
            ds = class_proddoc.DOCUMENTOS_PRODUCTOS_LISTADOS(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("tdp_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaDoctos.Rows.Add(ds.Tables(0).Rows(Fila)("tdp_codigo"),
                                            ds.Tables(0).Rows(Fila)("tdp_nombre"),
                                            ds.Tables(0).Rows(Fila)("tdo_nombre"),
                                            ds.Tables(0).Rows(Fila)("tdp_ruta"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_DOCUMENTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_DOCUMENTOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_IMG_PRODUCTOS()
        Dim class_prodm As class_producto = New class_producto
        Dim Fila As Integer = 0
        Dim foto As Integer = 1

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            img0.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
            img1.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
            img2.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
            img3.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
            img4.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
            img5.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
            img6.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")

            ds = Nothing
            class_prodm.cnn = _cnn
            class_prodm.pro_codigo = _pro_codigo
            class_prodm.pmu_codigo = 0
            _msg = ""
            grillaMulti.Rows.Clear()
            ds = class_prodm.MULTIMEDIA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pmu_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            If ds.Tables(0).Rows(Fila)("pmu_fotoficha") = True Then
                                If foto = 1 Then
                                    Dim fs As System.IO.FileStream = New System.IO.FileStream(pasoHasta_mul & ds.Tables(0).Rows(Fila)("pmu_nombre"), System.IO.FileMode.Open)
                                    img1.Image = Image.FromStream(fs)
                                    fs.Close()
                                    'img1.Image = Image.FromFile(pasoHasta_mul + ds.Tables(0).Rows(Fila)("pmu_nombre"))
                                    foto = foto + 1
                                ElseIf foto = 2 Then
                                    Dim fs As System.IO.FileStream = New System.IO.FileStream(pasoHasta_mul & ds.Tables(0).Rows(Fila)("pmu_nombre"), System.IO.FileMode.Open)
                                    img2.Image = Image.FromStream(fs)
                                    fs.Close()
                                    'img2.Image = Image.FromFile(pasoHasta_mul + ds.Tables(0).Rows(Fila)("pmu_nombre"))
                                    foto = foto + 1
                                ElseIf foto = 3 Then
                                    Dim fs As System.IO.FileStream = New System.IO.FileStream(pasoHasta_mul & ds.Tables(0).Rows(Fila)("pmu_nombre"), System.IO.FileMode.Open)
                                    img3.Image = Image.FromStream(fs)
                                    fs.Close()
                                    'img3.Image = Image.FromFile(pasoHasta_mul + ds.Tables(0).Rows(Fila)("pmu_nombre"))
                                    foto = foto + 1
                                ElseIf foto = 4 Then
                                    Dim fs As System.IO.FileStream = New System.IO.FileStream(pasoHasta_mul & ds.Tables(0).Rows(Fila)("pmu_nombre"), System.IO.FileMode.Open)
                                    img4.Image = Image.FromStream(fs)
                                    fs.Close()
                                    'img4.Image = Image.FromFile(pasoHasta_mul + ds.Tables(0).Rows(Fila)("pmu_nombre"))
                                    foto = foto + 1
                                ElseIf foto = 5 Then
                                    Dim fs As System.IO.FileStream = New System.IO.FileStream(pasoHasta_mul & ds.Tables(0).Rows(Fila)("pmu_nombre"), System.IO.FileMode.Open)
                                    img5.Image = Image.FromStream(fs)
                                    fs.Close()
                                    'img5.Image = Image.FromFile(pasoHasta_mul + ds.Tables(0).Rows(Fila)("pmu_nombre"))
                                    foto = foto + 1
                                ElseIf foto = 6 Then
                                    Dim fs As System.IO.FileStream = New System.IO.FileStream(pasoHasta_mul & ds.Tables(0).Rows(Fila)("pmu_nombre"), System.IO.FileMode.Open)
                                    img6.Image = Image.FromStream(fs)
                                    fs.Close()
                                    'img6.Image = Image.FromFile(pasoHasta_mul + ds.Tables(0).Rows(Fila)("pmu_nombre"))
                                    foto = foto + 1
                                End If
                            End If
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_IMG_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_IMG_PRODUCTOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub INICIALIZA()

        TabPage10.Parent = Nothing

        txtLetra.CharacterCasing = CharacterCasing.Upper

        txtCodInt.Text = ""
        txtcodigobarra.Text = ""
        chkActivo.Checked = True
        txtNombre.Text = ""
        txtNombreProducto.Text = ""

        optEstandar.Checked = 1
        optDoble.Checked = 0

        optPos1.Checked = 1
        optPos2.Checked = 0
        optPos3.Checked = 0

        cmbUmedida.DataSource = Nothing
        cmbUmedida.Items.Clear()
        Call CARGA_COMBO_UNIDAD_MEDIDA()

        cmbSubcategoria.DataSource = Nothing
        cmbSubcategoria.Items.Clear()

        cmbCategoria.DataSource = Nothing
        cmbCategoria.Items.Clear()
        Call CARGA_COMBO_CATEGORIAS()

        cmbColor.DataSource = Nothing
        cmbColor.Items.Clear()
        Call CARGA_COMBO_COLORES()
        Call CARGA_COMBO_PROVEEDOR()
        Call CARGA_COMBO_TIPO_MULTIMEDIA()
        Call CARGA_COMBO_TIPO_MULTIMEDIA_CALIDAD()

        Call CARGA_COMBO_TIPO_DOCUMENTO_PRODUCTO()

        img0.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
        img1.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
        img2.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
        img3.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
        img4.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
        img5.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
        img6.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")


    End Sub
    Private Sub CARGA_COMBO_PROVEEDOR()
        Dim _msg As String
        Try
            Dim class_producto As class_producto = New class_producto
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_producto.cnn = _cnn
            _msg = ""
            ds = class_producto.PROVEEDOR_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmb_proveedor.DataSource = ds.Tables(0)
                Me.cmb_proveedor.DisplayMember = "mensaje"
                Me.cmb_proveedor.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_TIPO_DOCUMENTO_PRODUCTO()
        Dim _msg As String
        Try
            Dim class_tipodoc As class_tipo_documento = New class_tipo_documento
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_tipodoc.cnn = _cnn
            _msg = ""
            ds = class_tipodoc.carga_combo_tipoDocto(_msg)
            If _msg = "" Then
                Me.cmbTipoDoc.DataSource = ds.Tables(0)
                Me.cmbTipoDoc.DisplayMember = "mensaje"
                Me.cmbTipoDoc.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_DOCUMENTO_PRODUCTO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_UNIDAD_MEDIDA()
        Dim _msg As String
        Try
            Dim class_umedida As class_umedida = New class_umedida
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_umedida.cnn = _cnn
            _msg = ""
            ds = class_umedida.UMEDIDA_CARGA_COMNBO(_msg)
            If _msg = "" Then
                Me.cmbUmedida.DataSource = ds.Tables(0)
                Me.cmbUmedida.DisplayMember = "mensaje"
                Me.cmbUmedida.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_UNIDAD_MEDIDA", MsgBoxStyle.Critical, Me.Text)
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
                Me.cmbCategoria.DataSource = ds.Tables(0)
                Me.cmbCategoria.DisplayMember = "mensaje"
                Me.cmbCategoria.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CATEGORIAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_SUBCATEGORIAS()
        Dim _msg As String
        Try
            Dim class_subcategoria As class_subcategoria = New class_subcategoria
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_subcategoria.cnn = _cnn
            class_subcategoria.cat_codigo = cmbCategoria.SelectedValue
            _msg = ""
            ds = class_subcategoria.CARGA_COMBO_SUBCATEGORIA(_msg)
            If _msg = "" Then
                Me.cmbSubcategoria.DataSource = ds.Tables(0)
                Me.cmbSubcategoria.DisplayMember = "mensaje"
                Me.cmbSubcategoria.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_SUBCATEGORIAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_COLORES()
        Dim _msg As String
        Try
            Dim class_color As class_colores = New class_colores
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_color.cnn = _cnn
            _msg = ""
            ds = class_color.COLORES_CARGA_COMNBO(_msg)
            If _msg = "" Then
                Me.cmbColor.DataSource = ds.Tables(0)
                Me.cmbColor.DisplayMember = "mensaje"
                Me.cmbColor.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_COLORES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_TIPO_MULTIMEDIA()
        Dim _msg As String
        Try
            Dim class_tipom As class_tipomultimedia = New class_tipomultimedia
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_tipom.cnn = _cnn
            _msg = ""
            ds = class_tipom.TIPO_MULTIMEDIA_CARGA_COMNBO(_msg)
            If _msg = "" Then
                Me.cmbTipoMultimedia.DataSource = ds.Tables(0)
                Me.cmbTipoMultimedia.DisplayMember = "mensaje"
                Me.cmbTipoMultimedia.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_MULTIMEDIA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_TIPO_MULTIMEDIA_CALIDAD()
        Dim _msg As String
        Try
            Dim class_tipomc As class_tipomultimediacalidad = New class_tipomultimediacalidad
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_tipomc.cnn = _cnn
            _msg = ""
            ds = class_tipomc.TIPO_MULTIMEDIA_CALIDAD_CARGA_COMNBO(_msg)
            If _msg = "" Then
                Me.cmbCalidad.DataSource = ds.Tables(0)
                Me.cmbCalidad.DisplayMember = "mensaje"
                Me.cmbCalidad.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_MULTIMEDIA_CALIDAD", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_TIPO_MULTIMEDIA_CALIDAD_IMG()
        Dim _msg As String
        Try
            Dim class_tipomc As class_tipomultimediacalidad = New class_tipomultimediacalidad
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_tipomc.cnn = _cnn
            _msg = ""
            ds = class_tipomc.TIPO_MULTIMEDIA_CALIDAD_IMG_CARGA_COMNBO(_msg)
            If _msg = "" Then
                Me.cmbCalidad.DataSource = ds.Tables(0)
                Me.cmbCalidad.DisplayMember = "mensaje"
                Me.cmbCalidad.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_MULTIMEDIA_CALIDAD", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub img1_MouseMove(sender As Object, e As MouseEventArgs) Handles img1.MouseMove
        leer(img1)
    End Sub

    Sub leer(ByVal origen As PictureBox)
        Try
            If img1.Image Is Nothing Then Exit Sub
            'With Shape
            '    .Left = origen.Left - 5
            '    .Top = origen.Top - 5
            '    .Width = origen.Width + 10
            '    .Height = origen.Height + 10
            '    .Visible = True
            'End With
            ''origen.SizeMode = PictureBoxSizeMode.Zoom
            img0.Image = origen.Image
        Catch ex As Exception
            ex.Message.ToUpper()
        End Try
    End Sub
    Private Sub img2_MouseMove(sender As Object, e As MouseEventArgs) Handles img2.MouseMove
        leer(img2)
    End Sub
    Private Sub img3_MouseMove(sender As Object, e As MouseEventArgs) Handles img3.MouseMove
        leer(img3)
    End Sub
    Private Sub img4_MouseMove(sender As Object, e As MouseEventArgs) Handles img4.MouseMove
        leer(img4)
    End Sub
    Private Sub img5_MouseMove(sender As Object, e As MouseEventArgs) Handles img5.MouseMove
        leer(img5)
    End Sub
    Private Sub img6_MouseMove(sender As Object, e As MouseEventArgs) Handles img6.MouseMove
        leer(img6)
    End Sub

    Private Sub cmbCategoria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCategoria.SelectionChangeCommitted
        'If cmbCategoria.Text <> "" Then
        Call CARGA_COMBO_SUBCATEGORIAS()
        'End If
    End Sub

    Private Sub txtCodInt_TextChanged(sender As Object, e As EventArgs) Handles txtCodInt.TextChanged

    End Sub

    Private Sub txtCodInt_LostFocus(sender As Object, e As EventArgs) Handles txtCodInt.LostFocus
        If txtCodInt.Text <> "" Then
            Call CARGA_REGISTRO()
            Call CARGA_GRILLA()
            Call CARGA_IMG_PRODUCTOS()
            Call CARGA_GRILLA_MULTI()
            Call CARGA_GRILLA_DOCUMENTOS()
        End If
    End Sub

    Private Sub CARGA_REGISTRO()
        Dim class_producto As class_producto = New class_producto
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_producto.cnn = _cnn
            class_producto.pro_codigo = pro_codigo
            class_producto.codigo_interno = IIf(txtCodInt.Text = "", "-", txtCodInt.Text)
            class_producto.cat_codigo = 0
            class_producto.sub_codigo = 0
            _msg = ""
            ds = class_producto.PRODUCTOS_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then

                        _pro_codigo = ds.Tables(0).Rows(Fila)("pro_codigo")
                        Call CARGA_IMG_PRODUCTOS()
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("pro_activo")
                        txtCodInt.Text = ds.Tables(0).Rows(Fila)("pro_codigointerno")
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("pro_nombre")
                        txtNombreProducto.Text = "[ " + ds.Tables(0).Rows(Fila)("pro_codigointerno") + " ] - " + UCase(ds.Tables(0).Rows(Fila)("pro_nombre"))
                        cmbCategoria.SelectedValue = ds.Tables(0).Rows(Fila)("cat_codigo")
                        cmbColor.SelectedValue = ds.Tables(0).Rows(Fila)("col_codigo")
                        ''cmbFamilia.SelectedValue = ds.Tables(0).Rows(Fila)("fam_codigo")

                        If ds.Tables(0).Rows(Fila)("cat_codigo") > 0 Then
                            Call CARGA_COMBO_SUBCATEGORIAS()
                        End If

                        cmbSubcategoria.SelectedValue = ds.Tables(0).Rows(Fila)("sub_codigo")
                        cmbUmedida.SelectedValue = ds.Tables(0).Rows(Fila)("uni_codigo")
                        txtObservacion.Text = ds.Tables(0).Rows(Fila)("pro_observación")
                        txtBultos.Text = ds.Tables(0).Rows(Fila)("pro_numbultos")
                        cmb_proveedor.SelectedValue = ds.Tables(0).Rows(Fila)("car_codigo")
                        chkRequiereUbicacionPK.Checked = ds.Tables(0).Rows(Fila)("pro_requiereubicacionpk")

                        If ds.Tables(0).Rows(Fila)("pro_escombo") = True Then
                            chkEsCombo.Checked = True
                            TabPage10.Parent = TabControl1
                        Else
                            chkEsCombo.Checked = False
                            TabPage10.Parent = Nothing
                        End If

                        'Call desahabilitacontroles()
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_DATOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_DATOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    'Private Sub CARGA_GRILLA_MULTIMEDIA()
    '    Dim class_tipom As class_tipomultimedia = New class_tipomultimedia
    '    Dim Fila As Integer = 0

    '    Try
    '        Dim ds As DataSet = New DataSet
    '        Dim _msg As String
    '        ds = Nothing
    '        class_tipom.cnn = _cnn
    '        class_tipom.pro_codigo = _pro_codigo
    '        class_tipom.tmu_codigo = 0
    '        _msg = ""
    '        grillaMulti.Rows.Clear()
    '        ds = class_tipom.TIPO_MULTIMEDIA_LISTADO(_msg)
    '        If _msg = "" Then
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                If ds.Tables(0).Rows(Fila)("pmu_codigo") > 0 Then
    '                    Do While Fila < ds.Tables(0).Rows.Count
    '                        grillaMulti.Rows.Add(ds.Tables(0).Rows(Fila)("pmu_codigo"),
    '                                        ds.Tables(0).Rows(Fila)("pmu_nombre"),
    '                                        ds.Tables(0).Rows(Fila)("pmu_nombre"),
    '                                        ds.Tables(0).Rows(Fila)("pmu_ruta"))
    '                        Fila = Fila + 1
    '                    Loop
    '                End If
    '            End If
    '            Me.Text = "LISTADO DE DOCUMENTOS DEL PRODUCTO - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
    '        Else
    '            MessageBox.Show(_msg + "\carga_grilla_multimedia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message + " " + "carga_grilla_multimedia", MsgBoxStyle.Critical, Me.Text)
    '    End Try
    'End Sub


    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA_FORM() = False Then
            Exit Sub
        End If

        Call GUARDA_REGISTRO()
    End Sub

    Private Function VALIDA_FORM()
        VALIDA_FORM = False

        If txtBultos.Text = "" Or txtBultos.Text = "0" Then
            MessageBox.Show("Debe ingresar la cantidad de bultos, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBultos.Focus()
            Exit Function
        End If

        If txtCodInt.Text = "" Then
            MessageBox.Show("Debe ingresar el codigo interno, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodInt.Focus()
            Exit Function
        End If

        If cmbColor.SelectedValue = 0 Then
            MessageBox.Show("Debe ingresar color, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbColor.Focus()
            Exit Function
        End If
        'If cmbFamilia.SelectedValue = 0 Then
        '    MessageBox.Show("Debe ingresar familia, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cmbFamilia.Focus()
        '    Exit Function
        'End If
        'If cmbUmedida.SelectedValue = 0 Then
        '    MessageBox.Show("Debe ingresar unidad de medida, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cmbUmedida.Focus()
        '    Exit Function
        'End If
        If cmbCategoria.SelectedValue = 0 Then
            MessageBox.Show("Debe ingresar categoria, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCategoria.Focus()
            Exit Function
        End If
        If cmbSubcategoria.SelectedValue = 0 Then
            MessageBox.Show("Debe ingresar subcategoria, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbSubcategoria.Focus()
            Exit Function
        End If


        VALIDA_FORM = True
    End Function
    Private Sub GUARDA_REGISTRO()
        Dim class_producto As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim str_codbr As String
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            str_codbr = ""
            class_producto.cnn = _cnn
            class_producto.pro_codigo = _pro_codigo
            class_producto.codigo_interno = txtCodInt.Text
            str_codbr = str_codbr & Long.Parse(txtCodInt.Text).ToString("00000000")
            class_producto.pro_nombre = txtNombre.Text
            class_producto.pro_observacion = IIf(txtObservacion.Text = "", "-", txtObservacion.Text)
            class_producto.fam_codigo = 0 'cmbFamilia.SelectedValue
            class_producto.pro_activo = chkActivo.Checked
            class_producto.uni_codigo = cmbUmedida.SelectedValue
            class_producto.cat_codigo = cmbCategoria.SelectedValue
            class_producto.car_codigo = cmb_proveedor.SelectedValue
            str_codbr = str_codbr & Long.Parse(class_producto.cat_codigo).ToString("00")
            class_producto.sub_codigo = cmbSubcategoria.SelectedValue
            str_codbr = str_codbr & Long.Parse(class_producto.sub_codigo).ToString("00")
            class_producto.col_codigo = cmbColor.SelectedValue
            str_codbr = str_codbr & Long.Parse(class_producto.col_codigo).ToString("00")
            class_producto.pro_metroscubicos = 0 'txtmtcubicos.Text
            txtcodigobarra.Text = str_codbr
            class_producto.cod_barra = str_codbr
            class_producto.pro_numerobulto = txtBultos.Text
            class_producto.pro_escombo = chkEsCombo.Checked
            class_producto.pro_requiereubicacionpk = chkRequiereUbicacionPK.Checked
            ds = class_producto.producto_guarda_registro(_msgError)
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
                    _pro_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If
            ds = Nothing

            If chkEsCombo.Checked = False Then
                ELIMINA_PRODUCTO_ASOCIADO_A_COMBO(0)
            End If

            MessageBox.Show("Los datos fueron guardados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Call cargar_registro()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub NumerosyDecimal(ByVal CajaTexto As System.Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "," Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeso.KeyPress
        Call NumerosyDecimal(txtPeso, e)
    End Sub
    Private Sub txtPzas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPzas.KeyPress
        Call NumerosyDecimal(txtPzas, e)
    End Sub
    Private Sub txtAncho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAncho.KeyPress
        Call NumerosyDecimal(txtAncho, e)
    End Sub
    Private Sub txtAlto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlto.KeyPress
        Call NumerosyDecimal(txtAlto, e)
    End Sub
    Private Sub txtFondo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFondo.KeyPress
        Call NumerosyDecimal(txtFondo, e)
    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        If Not VALIDA_FORM_BULTOS() Then
            Exit Sub
        End If
        Call GUARDA_BULTOS()
        Call CARGA_GRILLA()
        Call LIMPIA_DATOS_BULTOS()
    End Sub

    Sub LIMPIA_DATOS_BULTOS()
        txtAlto.Text = "0"
        txtAncho.Text = "0"
        txtFondo.Text = "0"
        'txtMts3.Text = ""
        txtPeso.Text = "0"
        txtPzas.Text = "0"
        lblBulCodigo.Text = "0"
        txtAlto.Focus()
        _bul_codigo = 0
        txtEnBase.Text = "0"
        txtEnAltura.Text = "0"
        'txtDoctoRuta.Text = ""
        'txtDoctoNombre.Text = ""
        'cbxTipoDocto.SelectedValue = 0

        optEstandar.Checked = 0
        optDoble.Checked = 0

        optPos1.Checked = 0
        optPos2.Checked = 0
        optPos3.Checked = 0


    End Sub
    Private Function BUSCAR_ARCHIVO(ByVal nombreArchivo As String) As String
        Dim class_producto As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            BUSCAR_ARCHIVO = False

            ds = Nothing
            class_producto.cnn = _cnn
            class_producto.pro_codigo = _pro_codigo
            class_producto.pmu_nombre = nombreArchivo
            _msg = ""

            ds = class_producto.NOMBRE_IMG_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigo") > 0 Then
                        BUSCAR_ARCHIVO = True
                    End If
                End If
                'Me.Text = "LISTADO DEL PRODUCTO - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\BUSCAR_ARCHIVO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "BUSCAR_ARCHIVO", MsgBoxStyle.Critical, Me.Text)
            BUSCAR_ARCHIVO = False
        End Try
    End Function

    Private Sub CARGA_GRILLA()
        Dim class_producto As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_producto.cnn = _cnn
            class_producto.pro_codigo = _pro_codigo
            class_producto.bul_codigo = 0
            _msg = ""
            Grilla.Rows.Clear()
            ds = class_producto.BULTOS_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("bul_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("bul_codigostring"),
                                            ds.Tables(0).Rows(Fila)("bul_ancho"),
                                            ds.Tables(0).Rows(Fila)("bul_alto"),
                                            ds.Tables(0).Rows(Fila)("bul_fondo"),
                                            ds.Tables(0).Rows(Fila)("bul_piezas"),
                                            ds.Tables(0).Rows(Fila)("bul_peso"),
                                            ds.Tables(0).Rows(Fila)("bul_cantidadbase"),
                                            ds.Tables(0).Rows(Fila)("bul_cantidadalto"),
                                            "", "",
                                            ds.Tables(0).Rows(Fila)("bul_tipobulto"),
                                            ds.Tables(0).Rows(Fila)("bul_posicion"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                'Me.Text = "LISTADO DEL PRODUCTO - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\carga_grilla", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grilla", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub GUARDA_BULTOS()
        Dim class_producto As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            class_producto.cnn = _cnn
            class_producto.pro_codigo = _pro_codigo
            class_producto.bul_codigo = Val(lblBulCodigo.Text)
            class_producto.bul_alto = txtAlto.Text
            class_producto.bul_fondo = txtFondo.Text
            class_producto.bul_ancho = txtAncho.Text
            class_producto.bul_peso = txtPeso.Text
            class_producto.bul_piezas = txtPzas.Text
            class_producto.bul_fondo = txtFondo.Text
            class_producto.bul_metro3 = 0 ' txtMts3.Text
            class_producto.bul_cantidadbase = txtEnBase.Text
            class_producto.bul_cantidadalto = txtEnAltura.Text

            If optEstandar.Checked = True Then
                class_producto.bul_tipobulto = "E"
            ElseIf optDoble.Checked = True Then
                class_producto.bul_tipobulto = "D"
            End If

            If optPos1.Checked = True Then
                class_producto.bul_posicion = 1
            ElseIf optPos2.Checked = True Then
                class_producto.bul_posicion = 2
            ElseIf optPos3.Checked = True Then
                class_producto.bul_posicion = 3
            End If

            class_producto.bul_horizontal = chkHorizontal.Checked

            ds = class_producto.BULTOS_GUARDA_REGISTRO(_msgError)
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
                    _bul_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If
            ds = Nothing
            MessageBox.Show("Bulto ingresado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function VALIDA_FORM_BULTOS()
        VALIDA_FORM_BULTOS = False
        'If Trim(txtMts3.Text) = "" Then
        '    MessageBox.Show("Debe ingresar metros cubicos, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtMts3.Focus()
        '    Exit Function
        'End If

        If Trim(txtAlto.Text) = "" Or Trim(txtAlto.Text) = "0" Then
            MessageBox.Show("Debe ingresar alto, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAlto.Focus()
            Exit Function
        End If
        If Trim(txtAncho.Text) = "" Or Trim(txtAncho.Text) = "0" Then
            MessageBox.Show("Debe ingresar ancho, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAncho.Focus()
            Exit Function
        End If
        If Trim(txtFondo.Text) = "" Or Trim(txtFondo.Text) = "0" Then
            MessageBox.Show("Debe ingresar fondo, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFondo.Focus()
            Exit Function
        End If

        'If Trim(txtPeso.Text) = "" Then
        '    MessageBox.Show("Debe ingresar peso, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtFondo.Focus()
        '    Exit Function
        'End If

        'If Trim(txtPzas.Text) = "" Then
        '    MessageBox.Show("Debe ingresar cantidad de piezas, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtPzas.Focus()
        '    Exit Function
        'End If

        VALIDA_FORM_BULTOS = True
    End Function

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 8 Then
                _bul_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                Call MOSTRAR_DETALLE()
                Call CARGA_COMBO_POSICIONES()
                Call CARGA_UBICACION_ASOCIADAS()
            ElseIf e.ColumnIndex = 9 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    ' paso = Grilla.Rows(e.RowIndex).Cells(0).Value
                    _pro_codigo = _pro_codigo
                    _bul_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                    Call ELIMINA_BULTOS(_pro_codigo, _bul_codigo)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_UBICACION_ASOCIADAS()
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classUbicaciones.cnn = _cnn
            classUbicaciones.pro_codigo = _pro_codigo
            classUbicaciones.bul_codigo = _bul_codigo

            _msg = ""
            grillaUbicacion.Rows.Clear()
            ds = classUbicaciones.CARGA_UBICACIONES_CON_UBICACION_ASOC(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("ubi_codigo") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaUbicacion.Rows.Add(False, ds.Tables(0).Rows(Fila)("ubi_codigo"), ds.Tables(0).Rows(Fila)("ubi_nombre"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_UBICACION_ASOCIADAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "\CARGA_UBICACION_ASOCIADAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_POSICIONES()
        Dim _msg As String
        Try
            Dim class_ubicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_ubicacion.cnn = _cnn
            class_ubicacion.pro_codigo = _pro_codigo
            class_ubicacion.bul_codigo = _bul_codigo
            class_ubicacion.ExcluyendoAsignadas = True

            If optEstandar.Checked = True Then
                class_ubicacion.tipoPallet = "E"
            ElseIf optDoble.Checked = True Then
                class_ubicacion.tipoPallet = "D"
            End If

            _msg = ""
            ds = class_ubicacion.OBTIENE_UBICACION_PARA_PK(_msg)
            If _msg = "" Then
                Me.cmbPosiciones.DataSource = ds.Tables(0)
                Me.cmbPosiciones.DisplayMember = "mensaje"
                Me.cmbPosiciones.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_POSICIONES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ELIMINA_BULTOS(ByVal pro_codigo As Integer, bul_codigo As Integer)
        Dim class_productos As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""
        Try
            ds = Nothing
            class_productos.cnn = _cnn
            class_productos.pro_codigo = pro_codigo
            class_productos.bul_codigo = bul_codigo
            ds = class_productos.BULTOS_ELIMINA(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CARGA_GRILLA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub MOSTRAR_DETALLE()
        Dim class_producto As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_producto.cnn = _cnn
            class_producto.pro_codigo = _pro_codigo
            class_producto.bul_codigo = _bul_codigo
            _msg = ""
            ds = class_producto.BULTOS_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("bul_codigo") > 0 Then
                        '_bul_codigo = ds.Tables(0).Rows(Fila)("bul_codigo")
                        lblBulCodigo.Text = ds.Tables(0).Rows(Fila)("bul_codigo")
                        txtAncho.Text = ds.Tables(0).Rows(Fila)("bul_ancho")
                        txtAlto.Text = ds.Tables(0).Rows(Fila)("bul_alto")
                        txtFondo.Text = ds.Tables(0).Rows(Fila)("bul_fondo")
                        txtPzas.Text = ds.Tables(0).Rows(Fila)("bul_piezas")
                        'txtMts3.Text = ds.Tables(0).Rows(Fila)("bul_metros3")
                        txtPeso.Text = ds.Tables(0).Rows(Fila)("bul_peso")
                        txtEnBase.Text = ds.Tables(0).Rows(Fila)("bul_cantidadbase")
                        txtEnAltura.Text = ds.Tables(0).Rows(Fila)("bul_cantidadalto")

                        If ds.Tables(0).Rows(Fila)("bul_tipobulto") = "-" Then
                            optEstandar.Checked = False
                            optDoble.Checked = False
                        ElseIf ds.Tables(0).Rows(Fila)("bul_tipobulto") = "E" Then
                            optEstandar.Checked = True
                            optDoble.Checked = False
                        ElseIf ds.Tables(0).Rows(Fila)("bul_tipobulto") = "D" Then
                            optEstandar.Checked = False
                            optDoble.Checked = True
                        End If

                        If ds.Tables(0).Rows(Fila)("bul_posicion") = 0 Then
                            optPos1.Checked = False
                            optPos2.Checked = False
                            optPos3.Checked = False
                        ElseIf ds.Tables(0).Rows(Fila)("bul_posicion") = 1 Then
                            optPos1.Checked = True
                            optPos2.Checked = False
                            optPos3.Checked = False
                        ElseIf ds.Tables(0).Rows(Fila)("bul_posicion") = 2 Then
                            optPos1.Checked = False
                            optPos2.Checked = True
                            optPos3.Checked = False
                        ElseIf ds.Tables(0).Rows(Fila)("bul_posicion") = 3 Then
                            optPos1.Checked = False
                            optPos2.Checked = False
                            optPos3.Checked = True
                        End If
                        chkHorizontal.Checked = ds.Tables(0).Rows(Fila)("bul_horizontal")

                    End If
                End If
            Else
                MessageBox.Show(_msg + "\MOSTRAR_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "Mostrar_Detalle", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbLimpiar_Click(sender As Object, e As EventArgs) Handles cmbLimpiar.Click
        Call LIMPIA_DATOS_BULTOS()
    End Sub

    Private Sub cmbTipoMultimedia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTipoMultimedia.SelectionChangeCommitted
        If cmbTipoMultimedia.SelectedValue = 2 Then
            Call CARGA_COMBO_TIPO_MULTIMEDIA_CALIDAD_IMG()
            txtMultiNombre.Text = txtCodInt.Text
            txtMultiNombre.Enabled = False
            txtLetra.Focus()
            chkEsFicha.Enabled = True
            txtLetra.Visible = True
        Else
            Call CARGA_COMBO_TIPO_MULTIMEDIA_CALIDAD()
            txtMultiNombre.Text = ""
            'txtMultiNombre.Enabled = True
            chkEsFicha.Enabled = False
            txtLetra.Visible = False
        End If
    End Sub

    Private Sub btnAgregaMultimedia_Click(sender As Object, e As EventArgs) Handles btnAgregaMultimedia.Click

        If Not VALIDA_FORM_MULTIMEDIA() Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Call GUARDAR_REGISTRO_MULTIMEDIA()
        Call CARGA_IMG_PRODUCTOS()
        Call CARGA_GRILLA_MULTI()
        Call LIMPIA_MULTIMEDIA()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CARGA_GRILLA_MULTI()
        Dim class_prodm As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_prodm.cnn = _cnn
            class_prodm.pro_codigo = _pro_codigo
            class_prodm.pmu_codigo = 0
            _msg = ""
            grillaMulti.Rows.Clear()
            ds = class_prodm.MULTIMEDIA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pmu_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaMulti.Rows.Add(ds.Tables(0).Rows(Fila)("pmu_codigo"),
                                            ds.Tables(0).Rows(Fila)("pmu_nombre"),
                                            ds.Tables(0).Rows(Fila)("tmu_nombre"),
                                            ds.Tables(0).Rows(Fila)("cal_nombre"),
                                            ds.Tables(0).Rows(Fila)("pmu_fotoficha"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_MULTI", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grilla_multimedia", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub GUARDAR_REGISTRO_MULTIMEDIA()
        Dim class_prom As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            class_prom.cnn = _cnn
            class_prom.pro_codigo = _pro_codigo
            class_prom.pmu_codigo = _pum_codigo
            class_prom.tmu_codigo = cmbTipoMultimedia.SelectedValue

            If cmbTipoMultimedia.SelectedValue = 2 Then
                '_nombreArchivo = txtMultiNombre.Text & Mid(cmbCalidad.Text, 1, 1) & txtLetra.Text & _extension
                If txtNomArch.Text = "" Then
                    _nombreArchivo = txtCodInt.Text & Mid(cmbCalidad.Text, 1, 1) & txtLetra.Text & _extension
                    class_prom.pmu_nombre = _nombreArchivo
                Else
                    class_prom.pmu_nombre = txtNomArch.Text
                End If
            Else
                'class_prom.pmu_nombre = _nombreArchivo
                class_prom.pmu_nombre = txtMultiNombre.Text
            End If

            class_prom.pmu_ruta = txtMultRuta.Text
            class_prom.cal_codigo = cmbCalidad.SelectedValue
            class_prom.pmu_fotoficha = chkEsFicha.Checked
            ds = class_prom.MULTIMEDIA_GUARDA_REGISTRO(_msgError)
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
                    _pum_codigo = ds.Tables(0).Rows(0)("codigo")
                    If _esEdicion = False And cmbTipoMultimedia.SelectedValue = 2 Then
                        If My.Computer.FileSystem.FileExists(pasoHasta_mul + _nombreArchivo) Then
                            My.Computer.FileSystem.DeleteFile(pasoHasta_mul + _nombreArchivo)
                            My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoHasta_mul + _nombreArchivo, overwrite:=False)
                        Else
                            My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoHasta_mul + _nombreArchivo, overwrite:=False)
                        End If
                    Else
                        If cmbTipoMultimedia.SelectedValue <> 2 Then
                            If My.Computer.FileSystem.FileExists(pasoHasta_mul + _nombreArchivo) Then
                                My.Computer.FileSystem.DeleteFile(pasoHasta_mul + _nombreArchivo)
                                My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoHasta_mul + _nombreArchivo, overwrite:=False)
                            Else
                                My.Computer.FileSystem.CopyFile(pasoDesdeMulti, pasoHasta_mul + _nombreArchivo, overwrite:=False)
                            End If
                        End If

                    End If
                End If
            End If
            ds = Nothing
            MessageBox.Show("multimedia ingresada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function VALIDA_FORM_MULTIMEDIA()
        Dim nombreArchivo As String = ""
        Dim respuesta As Integer = 0

        VALIDA_FORM_MULTIMEDIA = False

        If Trim(txtMultiNombre.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre archivo, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMultiNombre.Focus()
            Exit Function
        End If

        If cmbCalidad.SelectedValue = 0 Then
            MessageBox.Show("Debe ingresar calidad de multimedia, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCalidad.Focus()
            Exit Function
        End If

        If cmbTipoMultimedia.SelectedValue = 0 Then
            MessageBox.Show("Debe ingresar tipo de multimedia, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbTipoMultimedia.Focus()
            Exit Function
        End If

        If _pum_codigo = 0 Then
            If Trim(txtMultRuta.Text) = "" Then 'pasoDesde
                MessageBox.Show("Debe seleccionar archivo de origen, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmdSelecMulti.Focus()
                Exit Function
            End If

            If Trim(pasoDesdeMulti) = "" Then '
                MessageBox.Show("Debe seleccionar archivo de origen, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmdSelecMulti.Focus()
                Exit Function
            End If

            If cmbTipoMultimedia.Text = "IMAGENES" Then
                If txtLetra.Text = "" Then
                    MessageBox.Show("Debe ingresar la letra correspondiente a la imagen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtLetra.Focus()
                    Exit Function
                End If

                'nombreArchivo = Trim(txtMultiNombre.Text) + Trim(Mid(cmbCalidad.Text, 1, 1)) + Trim(txtLetra.Text)
                'nombreArchivo = txtMultiNombre.Text & Mid(cmbCalidad.Text, 1, 1) & txtLetra.Text & _extension
                _nombreArchivo = txtCodInt.Text & Mid(cmbCalidad.Text, 1, 1) & txtLetra.Text & _extension
                If BUSCAR_ARCHIVO(Trim(nombreArchivo)) = True Then
                    respuesta = MessageBox.Show("El archivo que esta ingresando ya se encuentra con un archivo asociado" _
                                            + Chr(10) + "¿Desea reemplazarlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If respuesta = vbNo Then
                        txtLetra.Focus()
                        Exit Function
                    End If
                End If
            End If

        End If

        VALIDA_FORM_MULTIMEDIA = True
    End Function

    Private Sub btnLimpiarMultimedia_Click(sender As Object, e As EventArgs) Handles btnLimpiarMultimedia.Click
        Call LIMPIA_MULTIMEDIA()
    End Sub

    Private Sub LIMPIA_MULTIMEDIA()
        txtNomArch.Text = ""
        lblNumeroMultimedia.Text = ""
        txtMultiNombre.Text = ""
        txtLetra.Text = ""
        txtMultRuta.Text = ""
        cmbTipoMultimedia.SelectedValue = 0
        cmbCalidad.SelectedValue = 0
        _nombreArchivo = ""
        _extension = ""
        _pum_codigo = 0
        txtMultiNombre.Enabled = True
        chkEsFicha.Checked = False

        txtMultiNombre.Enabled = True
        txtLetra.Enabled = True
        cmbTipoMultimedia.Enabled = True
        cmbCalidad.Enabled = True
        txtMultRuta.Enabled = True
        cmdSelecMulti.Enabled = True
        chkEsFicha.Enabled = True
        _esEdicion = False
        txtLetra.Visible = False
    End Sub

    Private Sub cmdSelecMulti_Click(sender As Object, e As EventArgs) Handles cmdSelecMulti.Click
        Dim openFileDialog1 As New OpenFileDialog()

        If cmbTipoMultimedia.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar el tipo de multimedia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbTipoMultimedia.Focus()
            Exit Sub
        End If

        'openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If cmbTipoMultimedia.SelectedValue = 2 Then
            openFileDialog1.Filter = "Archivo de imagenes (JPEG,PNG)|*.jpg;*.jpeg;*.png"
        Else
            openFileDialog1.Filter = "Todos los archivos|*.*"
        End If

        openFileDialog1.Title = "seleccione archivo"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pasoDesdeMulti = openFileDialog1.FileName
            txtMultRuta.Text = pasoDesdeMulti
            _nombreArchivo = (System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName)) & (System.IO.Path.GetExtension(openFileDialog1.FileName))
            txtMultiNombre.Text = _nombreArchivo
            _extension = System.IO.Path.GetExtension(openFileDialog1.FileName)
        End If
    End Sub

    Private Sub cmbTipoMultimedia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMultimedia.SelectedIndexChanged

    End Sub

    Private Sub grillaMulti_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaMulti.CellContentClick
        Try
            If e.ColumnIndex = 5 Then
                _pro_codigo = _pro_codigo
                _pum_codigo = grillaMulti.Rows(e.RowIndex).Cells(0).Value
                Call MUESTRA_REGISTRO_MULTIMEDIA()
            ElseIf e.ColumnIndex = 6 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    ' paso = Grilla.Rows(e.RowIndex).Cells(0).Value
                    _pro_codigo = _pro_codigo
                    _pum_codigo = grillaMulti.Rows(e.RowIndex).Cells(0).Value
                    Call ELIMINA_REGISTRO_MULTIMEDIA(_pro_codigo, _pum_codigo, Trim(grillaMulti.Rows(e.RowIndex).Cells(1).Value))
                    Call LIMPIA_MULTIMEDIA()
                End If

            End If

        Catch ex As Exception
            'Message
        End Try
    End Sub

    Private Sub MUESTRA_REGISTRO_MULTIMEDIA()
        Dim class_prodm As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_prodm.cnn = _cnn
            class_prodm.pro_codigo = _pro_codigo
            class_prodm.pmu_codigo = _pum_codigo
            _msg = ""
            ds = class_prodm.MULTIMEDIA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pmu_codigo") > 0 Then
                        _pmu_codigo = _pmu_codigo
                        _esEdicion = True
                        lblNumeroMultimedia.Text = ds.Tables(0).Rows(Fila)("pmu_codigo")
                        cmbTipoMultimedia.SelectedValue = ds.Tables(0).Rows(Fila)("tmu_codigo")

                        If cmbTipoMultimedia.SelectedValue = 2 Then
                            Call CARGA_COMBO_TIPO_MULTIMEDIA_CALIDAD_IMG()
                        Else
                            Call CARGA_COMBO_TIPO_MULTIMEDIA_CALIDAD()
                        End If

                        cmbCalidad.SelectedValue = ds.Tables(0).Rows(Fila)("cal_codigo")
                        'pasoDesdeMulti = ds.Tables(0).Rows(Fila)("pmu_ruta")
                        txtMultiNombre.Text = ds.Tables(0).Rows(Fila)("pmu_nombre")

                        txtNomArch.Text = ds.Tables(0).Rows(Fila)("pmu_nombre")

                        chkEsFicha.Checked = ds.Tables(0).Rows(Fila)("pmu_fotoficha")
                        'txtMultRuta.Text = ds.Tables(0).Rows(Fila)("pmu_ruta")

                        If cmbTipoMultimedia.SelectedValue = 2 Then
                            txtMultiNombre.Enabled = False
                            txtLetra.Enabled = False
                            cmbTipoMultimedia.Enabled = False
                            cmbCalidad.Enabled = False
                            txtMultRuta.Enabled = False
                            cmdSelecMulti.Enabled = False
                            chkEsFicha.Enabled = True
                        Else
                            txtMultiNombre.Enabled = True
                            txtLetra.Enabled = False
                            cmbTipoMultimedia.Enabled = True
                            cmbCalidad.Enabled = True
                            txtMultRuta.Enabled = True
                            cmdSelecMulti.Enabled = True
                            chkEsFicha.Enabled = False
                        End If

                    End If
                End If

            Else
                MessageBox.Show(_msg + "\Mostrar_Detalle", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "Mostrar_Detalle", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ELIMINA_REGISTRO_MULTIMEDIA(ByVal pro_codigo As Integer, pmu_codigo As Integer, ByVal nomArchivo As String)
        Dim class_prodm As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""
        Try
            ds = Nothing
            class_prodm.cnn = _cnn
            class_prodm.pro_codigo = pro_codigo
            class_prodm.pmu_codigo = pmu_codigo
            ds = class_prodm.ELIMINA_MULTIMEDIA(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Call CARGA_IMG_PRODUCTOS()

            If My.Computer.FileSystem.FileExists(pasoHasta_mul + nomArchivo) Then
                My.Computer.FileSystem.DeleteFile(pasoHasta_mul + nomArchivo)
            End If

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CARGA_GRILLA_MULTI()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btnAgregaDoc_Click(sender As Object, e As EventArgs) Handles btnAgregaDoc.Click
        If Not VALIDA_FORM_DOCTOS() Then
            Exit Sub
        End If

        Call GUARDA_DOCUMENTO_PRODUCTO()
        Call CARGA_GRILLA_DOCUMENTOS()
        Call LIMPIA_DATOS_DOCUMENTOS()
    End Sub

    Sub LIMPIA_DATOS_DOCUMENTOS()
        txtNumDoc.Text = ""
        txtNomDoc.Text = ""
        cmbTipoDoc.SelectedValue = 0
        txtRutaDoc.Text = ""
        _extension = ""
        _nombreDocto = ""
        _tdo_codigo = 0
    End Sub

    Private Sub GUARDA_DOCUMENTO_PRODUCTO()
        Dim class_productosDoctos As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            class_productosDoctos.cnn = _cnn
            class_productosDoctos.pro_codigo = _pro_codigo
            class_productosDoctos.tdp_codigo = _tdo_codigo
            class_productosDoctos.tdo_codigo = cmbTipoDoc.SelectedValue
            class_productosDoctos.tdp_nombre = txtNomDoc.Text
            class_productosDoctos.tdp_ruta = txtRutaDoc.Text

            ds = class_productosDoctos.DOCUMENTOS_PRODUCTOS_GUARDA_REGISTRO(_msgError)
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
                    _tdo_codigo = ds.Tables(0).Rows(0)("codigo")
                    If My.Computer.FileSystem.FileExists(pasoHasta_doc + _nombreDocto) Then
                        My.Computer.FileSystem.DeleteFile(pasoHasta_doc + _nombreDocto)
                        My.Computer.FileSystem.CopyFile(pasoDesdeDoc, pasoHasta_doc + _nombreDocto, overwrite:=False)
                    Else
                        My.Computer.FileSystem.CopyFile(pasoDesdeDoc, pasoHasta_doc + _nombreDocto, overwrite:=False)
                    End If
                End If
            End If
            ds = Nothing
            MessageBox.Show("Documentos ingresado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function VALIDA_FORM_DOCTOS()
        Dim respuesta As Integer = 0
        Dim nombreDocto As String = ""
        VALIDA_FORM_DOCTOS = False
        If Trim(txtNomDoc.Text) = "" Then
            MessageBox.Show("Debe seleccionar el nombre de un archivo, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNomDoc.Focus()
            Exit Function
        End If
        If Trim(_nombreDocto) = "" Then '
            MessageBox.Show("Debe seleccionar archivo de origen, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BtnBuscaDoc.Focus()
            Exit Function
        End If
        If Trim(cmbTipoDoc.Text) = "" Then 'pasoDesde
            MessageBox.Show("Debe seleccionar un tipo de documento, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbTipoDoc.Focus()
            Exit Function
        End If

        If BUSCAR_DOCUMENTO(Trim(nombreDocto)) = True Then
            respuesta = MessageBox.Show("El documento que esta ingresando ya se encuentra con un archivo asociado" _
                                            + Chr(10) + "¿Desea reemplazarlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = vbNo Then
                txtLetra.Focus()
                Exit Function
            End If
        End If


        'If My.Computer.FileSystem.FileExists(pasoHasta_doc + _nombreDocto) Then
        '    respuesta = MessageBox.Show("El archivo seleccionado ya se encuentra en el repositorio, " _
        '                + Chr(10) + "¿Desea reemplazarlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If respuesta = vbNo Then
        '        Exit Function
        '    End If
        'End If


        VALIDA_FORM_DOCTOS = True
    End Function

    Private Function BUSCAR_DOCUMENTO(ByVal nombreDocto As String) As String
        Dim class_proddoc As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            BUSCAR_DOCUMENTO = False

            ds = Nothing
            class_proddoc.cnn = _cnn
            class_proddoc.pro_codigo = _pro_codigo
            class_proddoc.tdp_nombre = nombreDocto
            _msg = ""

            ds = class_proddoc.NOMBRE_DOCUMENTO_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigo") > 0 Then
                        BUSCAR_DOCUMENTO = True
                    End If
                End If
                'Me.Text = "LISTADO DEL PRODUCTO - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\BUSCAR_DOCUMENTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "BUSCAR_DOCUMENTO", MsgBoxStyle.Critical, Me.Text)
            BUSCAR_DOCUMENTO = False
        End Try
    End Function

    Private Sub BtnBuscaDoc_Click(sender As Object, e As EventArgs) Handles BtnBuscaDoc.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim prefijo As String = ""

        If cmbTipoDoc.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar el tipo de multimedia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbTipoDoc.Focus()
            Exit Sub
        End If

        'openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If cmbTipoDoc.SelectedValue = 1 Then
            prefijo = "FT"
        ElseIf cmbTipoDoc.SelectedValue = 2 Then
            prefijo = "FL"
        End If

        openFileDialog1.Filter = "documentos (PPT, XLS)|*.pptx;*.ppt;*.xlsx;*.xls;"


        openFileDialog1.Title = "seleccione archivo"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pasoDesdeDoc = openFileDialog1.FileName
            txtRutaDoc.Text = pasoDesdeDoc
            _nombreDocto = Trim(txtCodInt.Text) & prefijo & (System.IO.Path.GetExtension(openFileDialog1.FileName))
            txtNomDoc.Text = _nombreDocto
            _extension = System.IO.Path.GetExtension(openFileDialog1.FileName)
        End If




    End Sub

    Private Sub grillaDoctos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaDoctos.CellContentClick
        Try
            If e.ColumnIndex = 4 Then
                _tdo_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                'Call Mostrar_proDocumentos()
            ElseIf e.ColumnIndex = 5 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    _tdo_codigo = grillaDoctos.Rows(e.RowIndex).Cells(0).Value
                    Call ELIMINA_DOCUMENTO_PRODUCTO(_pro_codigo, _tdo_codigo)
                End If
            End If
        Catch ex As Exception
            'Message
        End Try
    End Sub

    Private Sub ELIMINA_DOCUMENTO_PRODUCTO(ByVal pro_codigo As Integer, ByVal tdp_codigo As Integer)
        Dim class_proddoc As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""
        Try
            ds = Nothing
            class_proddoc.cnn = _cnn
            class_proddoc.tdp_codigo = _tdo_codigo
            class_proddoc.pro_codigo = _pro_codigo
            ds = class_proddoc.ELIMINA_DOCTO_PRODUCTO(_msgError)

            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CARGA_GRILLA_DOCUMENTOS()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call GUARDA_REGISTRO_EXCLUSIBIDAD()
        Call CARGA_GRILLA_EXCLUSIBIDAD()
    End Sub

    Private Sub GUARDA_REGISTRO_EXCLUSIBIDAD()
        Dim class_producto As class_producto = New class_producto
        Dim Fila As Integer = 0
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim ds As DataSet = New DataSet
        Dim _msg As String
        ds = Nothing

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                class_producto.cnn = _cnn
                class_producto.pro_codigo = _pro_codigo

                _msg = ""

                ds = class_producto.EXCLUSIBIDAD_CLIENTE_ELIMINA(_msg, conexion)
                If _msg = "" Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(Fila)("codigo") < 0 Then
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds.Dispose()
                            Exit Sub
                        End If
                    End If
                Else
                    If conexion.State <> ConnectionState.Closed Then
                        conexion.Close()
                    End If
                    conexion.Dispose()
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds.Dispose()
                    Exit Sub
                End If

                ds = Nothing

                For Each row As DataGridViewRow In Me.grd_Exclusividad.Rows
                    If row.Cells(1).Value = True Then
                        class_producto.pro_codigo = _pro_codigo
                        class_producto.car_codigo = row.Cells(0).Value

                        ds = class_producto.EXCLUSIBIDAD_CLIENTE_GUARDA_REGISTRO(_msg, conexion)
                        If _msg = "" Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                If ds.Tables(0).Rows(Fila)("codigo") < 0 Then
                                    If conexion.State <> ConnectionState.Closed Then
                                        conexion.Close()
                                    End If
                                    conexion.Dispose()
                                    MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    ds.Dispose()
                                    Exit Sub
                                End If
                            End If
                        Else
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds.Dispose()
                            Exit Sub
                        End If
                    End If
                Next

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                MessageBox.Show("Clientes asociados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message + " " + "GUARDA_REGISTRO_EXCLUSIBIDAD", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub img1_Click(sender As Object, e As EventArgs) Handles img1.Click

    End Sub

    Private Sub grillaMulti_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaMulti.CellClick
        Try
            If e.ColumnIndex = 1 Then
                If grillaMulti.Rows(e.RowIndex).Cells(2).Value = "IMAGENES" Then
                    Dim fs As System.IO.FileStream = New System.IO.FileStream(pasoHasta_mul & grillaMulti.Rows(e.RowIndex).Cells(1).Value, System.IO.FileMode.Open)
                    imgMuestra.Image = Image.FromStream(fs)
                    fs.Close()
                Else
                    imgMuestra.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grillaMulti_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grillaMulti.CellEnter
        Try
            If grillaMulti.Rows.Count > 0 Then
                If grillaMulti.Rows(e.RowIndex).Cells(2).Value = "IMAGENES" Then
                    Dim fs As System.IO.FileStream = New System.IO.FileStream(pasoHasta_mul & grillaMulti.Rows(e.RowIndex).Cells(1).Value, System.IO.FileMode.Open)
                    imgMuestra.Image = Image.FromStream(fs)
                    fs.Close()
                Else
                    imgMuestra.Image = Image.FromFile(Application.StartupPath + "\img\nofoto.jpg")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grillaMulti_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaMulti.CellDoubleClick
        Dim OpenRuta As String
        Try
            If grillaMulti.Rows.Count > 0 Then
                If grillaMulti.Rows(e.RowIndex).Cells(2).Value = "IMAGENES" Then
                    OpenRuta = pasoHasta_mul & grillaMulti.Rows(e.RowIndex).Cells(1).Value
                    Process.Start(OpenRuta)
                Else
                    OpenRuta = pasoHasta_mul & grillaMulti.Rows(e.RowIndex).Cells(1).Value
                    Process.Start(OpenRuta)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub optEstandar_CheckedChanged(sender As Object, e As EventArgs) Handles optEstandar.CheckedChanged
        If optEstandar.Checked = True Then
            chkHorizontal.Enabled = False
            chkHorizontal.Checked = 0
        Else
            chkHorizontal.Enabled = True
            chkHorizontal.Checked = 0
        End If
    End Sub

    Private Sub optDoble_CheckedChanged(sender As Object, e As EventArgs) Handles optDoble.CheckedChanged
        If optDoble.Checked = True Then
            optDoble.Enabled = True
        Else
            chkHorizontal.Enabled = False
            chkHorizontal.Checked = 0
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cmbPosiciones.Text = "" Then
            MessageBox.Show("Debe seleccionar una posición", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbPosiciones.Focus()
            Exit Sub
        End If

        Call ASOCIA_UBICACION()
        Call CARGA_COMBO_POSICIONES()
        Call CARGA_UBICACION_ASOCIADAS()

    End Sub

    Private Sub ASOCIA_UBICACION()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classUbicacion.cnn = _cnn
            classUbicacion.ubi_codigoString = cmbPosiciones.SelectedValue
            classUbicacion.pro_codigo = _pro_codigo
            classUbicacion.bul_codigo = _bul_codigo
            classUbicacion.ubi_nombre = cmbPosiciones.Text

            ds = classUbicacion.UBICACION_ASOCIA_REGISTRO(_msgError)
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
                    'fam_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If
            ds = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Ubicacion As String = ""
        Dim Seleccion As Boolean = False

        For Each row As DataGridViewRow In Me.grillaUbicacion.Rows
            Seleccion = row.Cells(0).Value
            Ubicacion = row.Cells(1).Value
            If Seleccion = True Then
                DESELECCIONA_REGISTRO(Ubicacion)
            End If
        Next
        Call CARGA_COMBO_POSICIONES()
        Call CARGA_UBICACION_ASOCIADAS()
        MessageBox.Show("Ubicación eliminada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DESELECCIONA_REGISTRO(ByVal ubicacion As String)
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            classUbicacion.cnn = _cnn
            classUbicacion.ubi_codigoString = ubicacion
            classUbicacion.pro_codigo = _pro_codigo
            classUbicacion.bul_codigo = _bul_codigo
            ds = classUbicacion.UBICACION_DESASOCIA_REGISTRO(_msgError)
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
                    'fam_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If
            ds = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grillaUbicacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaUbicacion.CellContentClick
        If e.ColumnIndex = Me.grillaUbicacion.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.grillaUbicacion.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub chkEsCombo_CheckedChanged(sender As Object, e As EventArgs) Handles chkEsCombo.CheckedChanged
        If chkEsCombo.Checked = True Then
            TabPage10.Parent = TabControl1
            chkRequiereUbicacionPK.Checked = False
            chkRequiereUbicacionPK.Enabled = False
        Else
            TabPage10.Parent = Nothing
            chkRequiereUbicacionPK.Enabled = True
        End If
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Call CARGA_GRILLA_PRODUCTOS_POR_ASOCIAR()
    End Sub

    Private Sub CARGA_GRILLA_PRODUCTOS_POR_ASOCIAR()
        Dim class_productos As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_productos.cnn = _cnn
            class_productos.pro_codigo = pro_codigo
            class_productos.codigo_interno = IIf(txtCodigoInterno.Text = "", "-", txtCodigoInterno.Text)

            _msg = ""
            grillaPorAsociar.Rows.Clear()
            ds = class_productos.PRODUCTOS_LISTADO_POR_RELACIONAR_EN_COMBO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaPorAsociar.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("pro_cantidadbulto"),
                                            0)

                            Fila = Fila + 1
                        Loop
                        Call CONFIGURA_COLUMNAS_POR_ASOCIAR()
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PRODUCTOS_POR_ASOCIAR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PRODUCTOS_POR_ASOCIAR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_PRODUCTOS_ASOCIADOS()
        Dim class_productos As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_productos.cnn = _cnn
            class_productos.pro_codigo = pro_codigo

            _msg = ""
            grillaAsociados.Rows.Clear()
            ds = class_productos.PRODUCTOS_LISTADO_RELACIONADO_EN_COMBO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaAsociados.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("pro_cantidadbulto"),
                                            ds.Tables(0).Rows(Fila)("pro_cantidad"))

                            Fila = Fila + 1
                        Loop
                        Call CONFIGURA_COLUMNAS_ASOCIADOS()
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PRODUCTOS_ASOCIADOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PRODUCTOS_ASOCIADOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CONFIGURA_COLUMNAS_POR_ASOCIAR()
        grillaPorAsociar.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaPorAsociar.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaPorAsociar.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaPorAsociar.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaPorAsociar.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaPorAsociar.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub CONFIGURA_COLUMNAS_ASOCIADOS()
        grillaAsociados.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaAsociados.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaAsociados.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaAsociados.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaAsociados.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaAsociados.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub grillaPorAsociar_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaPorAsociar.CellContentClick
        If e.ColumnIndex = 5 Then

            If grillaPorAsociar.Rows(e.RowIndex).Cells(4).Value = 0 Then
                MessageBox.Show("Debe ingresar una cantidad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ASOCIA_PRODUCTO_A_COMBO(grillaPorAsociar.Rows(e.RowIndex).Cells(0).Value, grillaPorAsociar.Rows(e.RowIndex).Cells(4).Value)
            Call CARGA_GRILLA_PRODUCTOS_POR_ASOCIAR()
            Call CARGA_GRILLA_PRODUCTOS_ASOCIADOS()
        End If
    End Sub

    Private Sub ASOCIA_PRODUCTO_A_COMBO(ByVal codRelacionado As Integer, ByVal Cantidad As Integer)
        Dim classProducto As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classProducto.cnn = _cnn
            classProducto.pro_codigo = _pro_codigo
            classProducto.pro_codigorel = codRelacionado
            classProducto.pro_cantidad = Cantidad

            ds = classProducto.PRODUCTOS_RELACIONA_A_COMBO(_msgError)
            If _msgError <> "" Then

                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            MessageBox.Show("Producto asociado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub grillaPorAsociar_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grillaPorAsociar.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        PrecionaTeclaDesde = "grillaPorAsociar"
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
    End Sub

    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = grillaPorAsociar.CurrentCell.ColumnIndex
        Dim fila As Integer = grillaPorAsociar.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = 4) Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar  
                e.KeyChar = Chr(0)
            End If
        End If

    End Sub

    Private Sub grillaAsociados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaAsociados.CellContentClick
        If e.ColumnIndex = 5 Then
            Dim respuesta As Integer

            respuesta = MessageBox.Show("¿Esta seguro(a) de desasociar el codigo seleccionado al combo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbYes Then
                ELIMINA_PRODUCTO_ASOCIADO_A_COMBO(grillaAsociados.Rows(e.RowIndex).Cells(0).Value)
                Call CARGA_GRILLA_PRODUCTOS_POR_ASOCIAR()
                Call CARGA_GRILLA_PRODUCTOS_ASOCIADOS()
            End If

        End If

    End Sub

    Private Sub ELIMINA_PRODUCTO_ASOCIADO_A_COMBO(ByVal codRelacionado As Integer)
        Dim classProducto As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classProducto.cnn = _cnn
            classProducto.pro_codigo = _pro_codigo
            classProducto.pro_codigorel = codRelacionado

            ds = classProducto.PRODUCTOS_ELIMINA_RELACION_DE_COMBO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            'MessageBox.Show("Producto fue desasociado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class