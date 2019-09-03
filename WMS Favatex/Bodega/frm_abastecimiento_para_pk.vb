Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading
Public Class frm_abastecimiento_para_pk
    Dim dataSetArbol As System.Data.DataSet
    Dim node As System.Windows.Forms.TreeNode

    Dim dtTree As DataTable = New DataTable
    Dim dtTree2 As DataTable = New DataTable
    Dim _cnn As String
    Dim _oab_codigo As Integer = 0
    Dim _eab_codigo As Integer

    Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Property eab_codigo() As Integer
        Get
            Return _eab_codigo
        End Get
        Set(ByVal value As Integer)
            _eab_codigo = value
        End Set
    End Property
    Property oab_codigo() As Integer
        Get
            Return _oab_codigo
        End Get
        Set(ByVal value As Integer)
            _oab_codigo = value
        End Set
    End Property

    Const COL_GRI_SELECCION As Integer = 0
    Const COL_GRI_PRO_CODIGO As Integer = 1
    Const COL_GRI_CODIGO As Integer = 2
    Const COL_GRI_PRODUCTO As Integer = 3
    Const COL_GRI_CATEGORIA As Integer = 4
    Const COL_GRI_SUBCATEGORIA As Integer = 5
    Const COL_GRI_BULTO As Integer = 6
    Const COL_GRI_CANT_UBICACIONES As Integer = 7
    Const COL_GRI_CANT_UNIDADES As Integer = 8
    Const COL_GRI_TIPOPALLET As Integer = 9
    Const COL_GRI_LLAEVE As Integer = 10
    Const COL_GRI_MARCA As Integer = 11

    'CONSTANTE GRILLA DE ORDEN DE ABASTECIMIENTO
    Const COL_ABA_FILA As Integer = 0
    Const COL_ABA_PRO_CODIGO As Integer = 1
    Const COL_ABA_PRO_CODIGO_INTERNO As Integer = 2
    Const COL_ABA_BULTO As Integer = 3
    Const COL_ABA_COD_UBICACION As Integer = 4
    Const COL_ABA_UBICACION_PK As Integer = 5
    Const COL_ABA_PALLET As Integer = 6
    Const COL_ABA_CANTIDAD As Integer = 7
    Const COL_ABA_COD_UBI_ABAS As Integer = 8
    Const COL_ABA_UBICACION_ABAS As Integer = 9
    Const COL_ABA_PALLET_ABAS As Integer = 10
    Const COL_ABA_CANTIDAD_ABAS As Integer = 11
    Const COL_ABA_PROCESADO As Integer = 12
    Const COL_ABA_UBICADO As Integer = 13
    Const COL_ABA_SIN_PROCESAR As Integer = 14
    Const COL_ABA_SIN_NEW_CANTIDAD As Integer = 15
    Const COL_ABA_PALLET_PISO As Integer = 16

    Private Sub frm_abastecimiento_para_pk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        If _oab_codigo = 0 Then
            GrillaAsignacion.Columns(COL_ABA_PROCESADO).Visible = False
            GrillaAsignacion.Columns(COL_ABA_UBICADO).Visible = False
        Else
            TabPage1.Parent = Nothing
            GrillaAsignacion.Columns(COL_ABA_PROCESADO).Visible = True
            GrillaAsignacion.Columns(COL_ABA_UBICADO).Visible = True
            txtNumAsi.Enabled = False

            Call CARGA_DATOS_ENCABEZADO_ORDEN_ABASTECIMIENTO()
            Call CARGA_GRILLA_DETALLE_ORDEN()
        End If
        Call INICIALIZA()
    End Sub

    Private Sub CARGA_GRILLA_DETALLE_ORDEN()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classUbicacion.cnn = _cnn

            classUbicacion.oab_codigo = _oab_codigo

            _msg = ""
            GrillaAsignacion.Rows.Clear()
            ds = classUbicacion.ORDEN_ABASTECIMIENTO_DETALLE_LISTAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("oab_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaAsignacion.Rows.Add(ds.Tables(0).Rows(Fila)("dab_fila"),
                                            ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("bulto"),
                                            ds.Tables(0).Rows(Fila)("dab_codigo_ubicacion_pk"),
                                            ds.Tables(0).Rows(Fila)("dab_nombre_ubicacion_pk"),
                                            ds.Tables(0).Rows(Fila)("dab_pallet_pk"),
                                            ds.Tables(0).Rows(Fila)("dab_cantidad_pk"),
                                            ds.Tables(0).Rows(Fila)("dab_codigo_ubicacion_aba"),
                                            ds.Tables(0).Rows(Fila)("dab_nombre_ubicacion_aba"),
                                            ds.Tables(0).Rows(Fila)("dab_pallet_aba"),
                                            ds.Tables(0).Rows(Fila)("dab_cantidad_aba"),
                                            ds.Tables(0).Rows(Fila)("dab_procesado"),
                                            "", False, "", "")
                            Fila = Fila + 1
                        Loop

                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_DETALLE_ORDEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Call CONFIGURA_COLUMNAS_ABASTECIMIENTO()

        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_DETALLE_ORDEN", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_DATOS_ENCABEZADO_ORDEN_ABASTECIMIENTO()
        Dim classOrden As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classOrden.cnn = _cnn
            classOrden.oab_codigo = _oab_codigo
            classOrden.pro_codigointerno = "-"
            classOrden.fecha_desde = "19000101"
            classOrden.Fecha_hasta = "20501231"
            classOrden.eab_codigo = 0

            ds = classOrden.ORDEN_ABASTECIMIENTO_LISTAR(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codEstado") > 0 Then
                        txtNumAsi.Text = ds.Tables(0).Rows(Fila)("codigo")
                        txtObservación.Text = ds.Tables(0).Rows(Fila)("observacion")
                        TxtFechaOab.Value = ds.Tables(0).Rows(Fila)("fecha")
                        _eab_codigo = ds.Tables(0).Rows(Fila)("codEstado")

                        If _eab_codigo = 1 Then
                            btnAsigna.Enabled = False
                            btnFinaliza.Enabled = True
                            'GrillaAsignacion.Columns(COL_ABA_PROCESADO).Visible = True
                            GrillaAsignacion.Columns(COL_ABA_UBICADO).Visible = True
                        ElseIf _eab_codigo = 2 Then
                            btnAsigna.Enabled = False
                            btnFinaliza.Enabled = False
                            'GrillaAsignacion.Columns(COL_ABA_PROCESADO).Visible = False
                            GrillaAsignacion.Columns(COL_ABA_UBICADO).Visible = False
                        End If
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_ENCABEZADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_ENCABEZADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub INICIALIZA()
        cmbCategoria.DataSource = Nothing
        cmbCategoria.Items.Clear()
        Call CARGA_COMBO_CATEGORIAS()
        Call CONFIGURA_COLUMNAS()
    End Sub

    Private Sub CONFIGURA_COLUMNAS()
        Grilla.Columns(COL_GRI_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_PRODUCTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_CATEGORIA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_SUBCATEGORIA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_CANT_UBICACIONES).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_CANT_UNIDADES).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub CONFIGURA_COLUMNAS_ABASTECIMIENTO()
        GrillaAsignacion.Columns(COL_ABA_FILA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_PRO_CODIGO_INTERNO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_COD_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_UBICACION_PK).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_PALLET).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_CANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_COD_UBI_ABAS).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_UBICACION_ABAS).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_PALLET_ABAS).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_CANTIDAD_ABAS).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_PROCESADO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaAsignacion.Columns(COL_ABA_UBICADO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
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

    Private Sub cmbCategoria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCategoria.SelectionChangeCommitted
        Call CARGA_COMBO_SUBCATEGORIAS()
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

    Private Sub CARGA_GRILLA_DETALLE()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            Me.Cursor = Cursors.WaitCursor
            classUbicacion.cnn = _cnn

            If txtCodigoUnico.Text = "" Then
                classUbicacion.pro_codigointerno = "-"
            Else
                classUbicacion.pro_codigointerno = Trim(txtCodigoUnico.Text)
            End If

            If cmbCategoria.Text = "" Then
                classUbicacion.cat_codigo = 0
            Else
                classUbicacion.cat_codigo = cmbCategoria.SelectedValue
            End If

            If cmbSubcategoria.Text = "" Then
                classUbicacion.sca_codigo = 0
            Else
                classUbicacion.sca_codigo = cmbSubcategoria.SelectedValue
            End If
            Grilla.Rows.Clear()
            ds = classUbicacion.BUSCA_PRODUCTOS_PARA_ABASTECIMIENTO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False,
                                            ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("cat_nombre"),
                                            ds.Tables(0).Rows(Fila)("sub_nombre"),
                                            ds.Tables(0).Rows(Fila)("pro_numerobulto"),
                                            ds.Tables(0).Rows(Fila)("cantidad_ubicaciones"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("bul_tipopallet"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno") + "-" + CStr(ds.Tables(0).Rows(Fila)("bul_codigo")))

                            Grilla.Item(COL_GRI_MARCA, Fila).Value = 0
                            If CInt(Grilla.Item(COL_GRI_CANT_UBICACIONES, Fila).Value) = 0 Then
                                Call PINTA_CELDA_ROJO(Fila)
                                Grilla.Item(COL_GRI_MARCA, Fila).Value = 0
                            Else
                                If CInt(Grilla.Item(COL_GRI_CANT_UNIDADES, Fila).Value) = 0 Then
                                    Call PINTA_CELDA_NARANJA(Fila)
                                    Grilla.Item(COL_GRI_MARCA, Fila).Value = 1
                                End If
                            End If

                            Fila = Fila + 1
                            Contador = Contador + 1
                        Loop
                        Call CONFIGURA_COLUMNAS()

                    End If
                End If

                Me.Cursor = Cursors.Default
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PINTA_CELDA_ROJO(ByVal fila As Integer)
        Grilla.Item(COL_GRI_PRO_CODIGO, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        Grilla.Item(COL_GRI_PRO_CODIGO, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        Grilla.Item(COL_GRI_CODIGO, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        Grilla.Item(COL_GRI_CODIGO, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        Grilla.Item(COL_GRI_PRODUCTO, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        Grilla.Item(COL_GRI_PRODUCTO, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        Grilla.Item(COL_GRI_CATEGORIA, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        Grilla.Item(COL_GRI_CATEGORIA, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        Grilla.Item(COL_GRI_SUBCATEGORIA, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        Grilla.Item(COL_GRI_SUBCATEGORIA, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        Grilla.Item(COL_GRI_BULTO, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        Grilla.Item(COL_GRI_BULTO, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        Grilla.Item(COL_GRI_CANT_UBICACIONES, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        Grilla.Item(COL_GRI_CANT_UBICACIONES, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        Grilla.Item(COL_GRI_CANT_UNIDADES, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        Grilla.Item(COL_GRI_CANT_UNIDADES, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)
    End Sub

    Private Sub PINTA_CELDA_NARANJA(ByVal fila As Integer)
        Grilla.Item(COL_GRI_PRO_CODIGO, fila).Style.BackColor = Color.FromArgb(250, 225, 169)
        Grilla.Item(COL_GRI_PRO_CODIGO, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

        Grilla.Item(COL_GRI_CODIGO, fila).Style.BackColor = Color.FromArgb(250, 225, 169)
        Grilla.Item(COL_GRI_CODIGO, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

        Grilla.Item(COL_GRI_PRODUCTO, fila).Style.BackColor = Color.FromArgb(250, 225, 169)
        Grilla.Item(COL_GRI_PRODUCTO, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

        Grilla.Item(COL_GRI_CATEGORIA, fila).Style.BackColor = Color.FromArgb(250, 225, 169)
        Grilla.Item(COL_GRI_CATEGORIA, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

        Grilla.Item(COL_GRI_SUBCATEGORIA, fila).Style.BackColor = Color.FromArgb(250, 225, 169)
        Grilla.Item(COL_GRI_SUBCATEGORIA, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

        Grilla.Item(COL_GRI_BULTO, fila).Style.BackColor = Color.FromArgb(250, 225, 169)
        Grilla.Item(COL_GRI_BULTO, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

        Grilla.Item(COL_GRI_CANT_UBICACIONES, fila).Style.BackColor = Color.FromArgb(250, 225, 169)
        Grilla.Item(COL_GRI_CANT_UBICACIONES, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

        Grilla.Item(COL_GRI_CANT_UNIDADES, fila).Style.BackColor = Color.FromArgb(250, 225, 169)
        Grilla.Item(COL_GRI_CANT_UNIDADES, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call CARGA_GRILLA_DETALLE()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(COL_GRI_SELECCION).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(COL_GRI_SELECCION)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub ButtonAsignar_Click(sender As Object, e As EventArgs) Handles ButtonAsignar.Click
        Dim fila As Integer = 0
        Dim strCadena As String = ""

        If DETALLES_MARCADAS() = False Then
            MessageBox.Show("No existen registros seleccionados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Do While fila <= Grilla.RowCount - 1
            If Grilla.Rows(fila).Cells(COL_GRI_SELECCION).Value = True Then
                If Grilla.Rows(fila).Cells(COL_GRI_TIPOPALLET).Value.ToString = "-" Then
                    MessageBox.Show("El producto " + Grilla.Rows(fila).Cells(COL_GRI_CODIGO).Value.ToString + ", bulto " + Grilla.Rows(fila).Cells(COL_GRI_BULTO).Value.ToString _
                                    + Chr(10) + "No tiene un tipo de pallet asociado (D: doble o E: Estandar), por favor configurar en mantenedor de bultos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If CInt(Grilla.Rows(fila).Cells(COL_GRI_CANT_UBICACIONES).Value) = 0 Then
                    MessageBox.Show("El producto " + Grilla.Rows(fila).Cells(COL_GRI_CODIGO).Value.ToString + ", bulto " + Grilla.Rows(fila).Cells(COL_GRI_BULTO).Value.ToString _
                                    + Chr(10) + "No tiene ubicaciones para picking asociada, por favor configurar en mantenedor de ubicaciones", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If CInt(Grilla.Rows(fila).Cells(COL_GRI_MARCA).Value) = 0 Then
                    MessageBox.Show("El producto " + Grilla.Rows(fila).Cells(COL_GRI_CODIGO).Value.ToString + ", bulto " + Grilla.Rows(fila).Cells(COL_GRI_BULTO).Value.ToString _
                                    + Chr(10) + "No requiere de abastecimiento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If



                'If Grilla.Rows(fila).Cells(COL_GRI_TIPOPALLET).Value.ToString = "D" Then
                '    If ((CInt(Grilla.Rows(fila).Cells(COL_GRI_CANT_UBICACIONES).Value) Mod 2) > 0) Then
                '        MessageBox.Show("El producto " + Grilla.Rows(fila).Cells(COL_GRI_CODIGO).Value.ToString + ", bulto " + Grilla.Rows(fila).Cells(COL_GRI_BULTO).Value.ToString _
                '                    + Chr(10) + "Utiliza un pallet doble y requiere a lo menos 2 ubicaciones o multiplos de 2, por favor configurar en mantenedor de ubicaciones ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Exit Sub
                '    End If
                'End If

                If strCadena = "" Then
                        strCadena = Grilla.Rows(fila).Cells(COL_GRI_LLAEVE).Value + ","
                    Else
                        strCadena = strCadena + Grilla.Rows(fila).Cells(COL_GRI_LLAEVE).Value + ","
                    End If

                End If
                fila = fila + 1
        Loop

        If strCadena <> "" Then
            Call CARGA_GRILLA_UBICACION_PK(strCadena)
            TabControl1.SelectedIndex = 1
        End If
    End Sub

    Private Sub CARGA_GRILLA_UBICACION_PK(ByVal strCadena As String)
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            Me.Cursor = Cursors.WaitCursor
            classUbicacion.cnn = _cnn
            classUbicacion.strCadena = strCadena

            GrillaAsignacion.Rows.Clear()
            ds = classUbicacion.SELECCIONA_PRODUCTOS_PARA_ABASTECIMIENTO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaAsignacion.Rows.Add(0, ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("bulto"),
                                            ds.Tables(0).Rows(Fila)("ubi_codigo"),
                                            ds.Tables(0).Rows(Fila)("ubi_nombre"),
                                            ds.Tables(0).Rows(Fila)("pallet"),
                                            ds.Tables(0).Rows(Fila)("cantidad"))

                            Fila = Fila + 1
                            Contador = Contador + 1
                        Loop

                        Call CONFIGURA_COLUMNAS_ABASTECIMIENTO()

                    End If
                End If
                Me.Cursor = Cursors.Default
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show(_msgError + "\CARGA_GRILLA_UBICACION_PK", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_UBICACION_PK", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function DETALLES_MARCADAS() As Boolean
        Dim Contador As Integer = 0
        Try
            DETALLES_MARCADAS = False

            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    Contador = Contador + 1
                End If
            Next

            If Contador > 0 Then
                DETALLES_MARCADAS = True
            End If

        Catch ex As Exception
            DETALLES_MARCADAS = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnAsigna_Click(sender As Object, e As EventArgs) Handles btnAsigna.Click
        If txtObservación.Text = "" Then
            MessageBox.Show("Debe ingresar una observación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtObservación.Focus()
            Exit Sub
        End If

        GENERA_ORDEN_ABASTECIMIENTO()
    End Sub

    Private Function GENERA_ORDEN_ABASTECIMIENTO()
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        GENERA_ORDEN_ABASTECIMIENTO = False

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classUbicaciones.cnn = _cnn

                ProgressBar1.Visible = True
                ProgressBar1.Value = 0
                ProgressBar1.Minimum = 0
                ProgressBar1.Maximum = GrillaAsignacion.RowCount
                For Each row As DataGridViewRow In Me.GrillaAsignacion.Rows
                    If row.Cells(COL_ABA_PRO_CODIGO_INTERNO).Value <> "" Then
                        classUbicaciones.pro_codigo = row.Cells(COL_ABA_PRO_CODIGO).Value
                        classUbicaciones.bul_codigo = CInt(Mid(row.Cells(COL_ABA_BULTO).Value, 1, 2))
                        ds = Nothing
                        ds = classUbicaciones.SELECCIONA_POSICIONES_PARA_ABASTECER(_msgError, conexion)
                        If _msgError = "" Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                If ds.Tables(0).Rows(0)("ubi_codigo") <> "" Then
                                    row.Cells(COL_ABA_COD_UBI_ABAS).Value = ds.Tables(0).Rows(0)("ubi_codigo")
                                    row.Cells(COL_ABA_UBICACION_ABAS).Value = ds.Tables(0).Rows(0)("ubi_nombre")
                                    row.Cells(COL_ABA_PALLET_ABAS).Value = ds.Tables(0).Rows(0)("pallet")
                                    row.Cells(COL_ABA_CANTIDAD_ABAS).Value = ds.Tables(0).Rows(0)("cantidad")
                                Else
                                    row.Cells(COL_ABA_COD_UBI_ABAS).Value = "-"
                                    row.Cells(COL_ABA_UBICACION_ABAS).Value = "SIN UBICACIÓN"
                                    row.Cells(COL_ABA_PALLET_ABAS).Value = "-"
                                    row.Cells(COL_ABA_CANTIDAD_ABAS).Value = 0
                                End If
                                GrillaAsignacion.Refresh()
                            Else
                                row.Cells(COL_ABA_COD_UBI_ABAS).Value = "-"
                                row.Cells(COL_ABA_UBICACION_ABAS).Value = "SIN UBICACIÓN"
                                row.Cells(COL_ABA_PALLET_ABAS).Value = "-"
                                row.Cells(COL_ABA_CANTIDAD_ABAS).Value = 0
                                GrillaAsignacion.Refresh()
                                ds = Nothing
                            End If
                        Else
                            ds = Nothing
                            MessageBox.Show(_msgError + "\GENERA_ORDEN_ABASTECIMIENTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            ds = Nothing
                            Me.Cursor = Cursors.Default
                            Exit Function
                        End If
                    End If
                    ProgressBar1.Value += 1
                Next

                _msgError = ""
                If GUARDA_ORDEN_REABASTECIMIENTO_ENCABEZADO(ESTADO_ORDEN_REABASTECIMIENTO.PENDIENTE, conexion) = False Then
                    Exit Function
                Else
                    _eab_codigo = ESTADO_ORDEN_REABASTECIMIENTO.PENDIENTE
                    If GUARDA_ORDEN_REABASTECIMIENTO_DETALLE(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        Me.Cursor = Cursors.Default
                        Exit Function
                    End If
                End If

                GrillaAsignacion.Columns(COL_ABA_PROCESADO).Visible = True
                GrillaAsignacion.Columns(COL_ABA_UBICADO).Visible = True

                Call CONFIGURA_COLUMNAS_ABASTECIMIENTO()


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default

                ProgressBar1.Visible = False

                MessageBox.Show("Orden de abastecimiento generada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using

            'If VERIFICA_UBICACIONES() = True Then
            '    MessageBox.Show("La asignación fue guardada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    btnImprimeIdentificador.Enabled = True
            '    GENERA_ASIGNACION_UBICACION = True
            'Else
            '    MessageBox.Show("Existen registros que no tiene ubicación asignada, contacte al administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    GENERA_ASIGNACION_UBICACION = False
            'End If


            'ProgressBar1.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GUARDA_ORDEN_REABASTECIMIENTO_DETALLE(ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim tmp_llave_pallet As String = ""
        GUARDA_ORDEN_REABASTECIMIENTO_DETALLE = False
        Try
            For Each row2 As DataGridViewRow In Me.GrillaAsignacion.Rows
                classUbicaciones.oab_codigo = _oab_codigo
                classUbicaciones.dab_fila = row2.Cells(COL_ABA_FILA).Value
                classUbicaciones.pro_codigo = row2.Cells(COL_ABA_PRO_CODIGO).Value
                classUbicaciones.pro_codigointerno = row2.Cells(COL_ABA_PRO_CODIGO_INTERNO).Value
                classUbicaciones.bulto = row2.Cells(COL_ABA_BULTO).Value
                classUbicaciones.dab_codigo_ubicacion_pk = row2.Cells(COL_ABA_COD_UBICACION).Value
                classUbicaciones.dab_nombre_ubicacion_pk = row2.Cells(COL_ABA_UBICACION_PK).Value
                classUbicaciones.dab_pallet_pk = row2.Cells(COL_ABA_PALLET).Value
                classUbicaciones.dab_cantidad_pk = row2.Cells(COL_ABA_CANTIDAD).Value
                classUbicaciones.dab_codigo_ubicacion_aba = row2.Cells(COL_ABA_COD_UBI_ABAS).Value
                classUbicaciones.dab_nombre_ubicacion_aba = row2.Cells(COL_ABA_UBICACION_ABAS).Value
                classUbicaciones.dab_pallet_aba = row2.Cells(COL_ABA_PALLET_ABAS).Value
                classUbicaciones.dab_cantidad_aba = row2.Cells(COL_ABA_CANTIDAD_ABAS).Value
                classUbicaciones.dab_procesado = row2.Cells(COL_ABA_PROCESADO).Value
                ds = classUbicaciones.GUARDA_ORDEN_ABASTECIMIENTO_DETALLE(_msgError, conexion)
                If _msgError <> "" Then
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Function
                    End If
                End If
            Next

            GUARDA_ORDEN_REABASTECIMIENTO_DETALLE = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GUARDA_ORDEN_REABASTECIMIENTO_ENCABEZADO(ByVal codEstadoOrden As Integer, ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet

        GUARDA_ORDEN_REABASTECIMIENTO_ENCABEZADO = False

        Try
            'Guarda cabecera del documento
            ds = Nothing
            classUbicaciones.oab_codigo = _oab_codigo
            classUbicaciones.oab_observacion = txtObservación.Text
            classUbicaciones.oab_fecha = TxtFechaOab.Value
            classUbicaciones.eab_codigo = codEstadoOrden

            ds = classUbicaciones.GUARDA_ORDEN_ABASTECIMIENTO_ENCABEZADO(_msgError, conexion)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Exit Function
                Else
                    txtNumAsi.Text = ds.Tables(0).Rows(0)("CODIGO")
                    _oab_codigo = ds.Tables(0).Rows(0)("CODIGO")
                End If
            End If

            GUARDA_ORDEN_REABASTECIMIENTO_ENCABEZADO = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Sub btnImprimeIdentificador_Click(sender As Object, e As EventArgs) Handles btnImprimeIdentificador.Click
        Dim frm As frm_imprimir = New frm_imprimir
        frm.Origen = "OAB"
        frm.oab_codigo = _oab_codigo
        frm.ShowDialog()
    End Sub

    Private Sub GrillaAsignacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaAsignacion.CellContentClick
        Try
            If e.ColumnIndex = Me.GrillaAsignacion.Columns.Item(COL_ABA_PROCESADO).Index Then
                Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_PROCESADO)
                chkCell.Value = Not chkCell.Value

                If GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_PROCESADO).Value = True Then
                    If GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_SIN_PROCESAR).Value = True Then
                        GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_PROCESADO).Value = False
                    End If
                End If

            End If


            If e.ColumnIndex = COL_ABA_UBICADO Then
                Dim _filaSeleccionada As Integer = 0
                Dim fila As Integer = 0

                _distintoPallet = False
                _distintaCantidad = False

                Dim frm As frm_modifica_registro = New frm_modifica_registro
                frm.cnn = _cnn
                _filaSeleccionada = GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_FILA).Value
                frm.strUbicacion = GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_COD_UBI_ABAS).Value
                frm.strUbicacionPK = GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_COD_UBICACION).Value
                frm.palletABA = GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_PALLET_ABAS).Value

                frm.ShowDialog()

                If _distintoPallet = True And _distintaCantidad = False Then
                    GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_SIN_PROCESAR).Value = True
                    GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_SIN_NEW_CANTIDAD).Value = 0
                    GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_PROCESADO).Value = False
                    GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_PALLET_PISO).Value = _palletPiso

                    GrillaAsignacion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.NavajoWhite
                    GrillaAsignacion.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black

                ElseIf _distintoPallet = False And _distintaCantidad = True Then
                    GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_SIN_PROCESAR).Value = False
                    GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_CANTIDAD_ABAS).Value = _nuevaCantidadActualizada
                    GrillaAsignacion.Rows(e.RowIndex).Cells(COL_ABA_PROCESADO).Value = True

                    GrillaAsignacion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 82)
                    GrillaAsignacion.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFinaliza_Click(sender As Object, e As EventArgs) Handles btnFinaliza.Click
        Dim contador As Integer = 0

        If GrillaAsignacion.RowCount = 1 Then
            If (GrillaAsignacion.Rows(0).Cells(COL_ABA_PROCESADO).Value = False) And (GrillaAsignacion.Rows(0).Cells(COL_ABA_PALLET_PISO).Value.ToString = "") Then
                contador = 0
            Else
                contador = 1
            End If
        Else
            For Each row As DataGridViewRow In Me.GrillaAsignacion.Rows
                If (row.Cells(COL_ABA_PROCESADO).Value = True) And (row.Cells(COL_ABA_PALLET_PISO).Value.ToString = "") Then
                    contador = contador + 1
                End If
            Next
        End If

        If contador = 0 Then
            MessageBox.Show("No existe ningun registro marcado como procesado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If FINALIZA_ORDEN_ABASTECIMIENTO() = True Then
            MessageBox.Show("Orden de abastecimiento finalizada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnFinaliza.Enabled = False
        End If

    End Sub

    Private Function FINALIZA_ORDEN_ABASTECIMIENTO() As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0
        Dim cantidadOrigen As Integer = 0
        Dim cantidadFinal As Integer = 0

        FINALIZA_ORDEN_ABASTECIMIENTO = False

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classUbicaciones.cnn = _cnn

                _msgError = ""
                If GUARDA_ORDEN_REABASTECIMIENTO_ENCABEZADO(ESTADO_ORDEN_REABASTECIMIENTO.FINALIZADA, conexion) = False Then
                    Exit Function
                Else
                    _eab_codigo = ESTADO_ORDEN_REABASTECIMIENTO.PENDIENTE
                    If GUARDA_ORDEN_REABASTECIMIENTO_DETALLE(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        Me.Cursor = Cursors.Default
                        Exit Function
                    End If
                End If

                For Each row As DataGridViewRow In Me.GrillaAsignacion.Rows
                    If row.Cells(COL_ABA_PALLET_PISO).Value <> "" Then
                        If ENVIA_PALLET_A_PT(row.Cells(COL_ABA_PALLET_PISO).Value, conexion) = False Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            Exit Function
                        End If
                    Else
                        If row.Cells(COL_ABA_PALLET).Value <> "" Then
                            cantidadOrigen = 0
                        Else
                            cantidadOrigen = row.Cells(COL_ABA_CANTIDAD).Value
                        End If

                        cantidadFinal = CInt(row.Cells(COL_ABA_CANTIDAD_ABAS).Value) + cantidadOrigen

                        classUbicaciones.dab_pallet_pk = row.Cells(COL_ABA_PALLET).Value
                        classUbicaciones.dab_pallet_aba = row.Cells(COL_ABA_PALLET_ABAS).Value
                        classUbicaciones.dab_cantidad_aba = row.Cells(COL_ABA_CANTIDAD_ABAS).Value
                        classUbicaciones.dab_codigo_ubicacion_pk = row.Cells(COL_ABA_COD_UBICACION).Value
                        classUbicaciones.dab_codigo_ubicacion_aba = row.Cells(COL_ABA_COD_UBI_ABAS).Value

                        ds = Nothing
                        ds = classUbicaciones.ACTUALIZA_CANTIDADES_UBICACIONES_PALLET(_msgError, conexion)
                        If _msgError = "" Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                If ds.Tables(0).Rows(0)("mensaje") <> "ok" Then
                                    ds = Nothing
                                    Me.Cursor = Cursors.Default
                                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje") + "\FINALIZA_ORDEN_ABASTECIMIENTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    If conexion.State = ConnectionState.Open Then
                                        conexion.Close()
                                    End If
                                    Exit Function
                                End If
                            End If
                        Else
                            ds = Nothing
                            Me.Cursor = Cursors.Default
                            MessageBox.Show(_msgError + "\FINALIZA_ORDEN_ABASTECIMIENTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            Exit Function
                        End If
                    End If
                Next

                GrillaAsignacion.Columns(COL_ABA_PROCESADO).Visible = False
                GrillaAsignacion.Columns(COL_ABA_UBICADO).Visible = False

                Call CONFIGURA_COLUMNAS_ABASTECIMIENTO()


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default

                FINALIZA_ORDEN_ABASTECIMIENTO = True

            End Using

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            FINALIZA_ORDEN_ABASTECIMIENTO = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function ENVIA_PALLET_A_PT(ByVal strPallet As String, ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet

        ENVIA_PALLET_A_PT = False

        Try
            'Guarda cabecera del documento
            ds = Nothing
            classUbicaciones.pallet = strPallet
            classUbicaciones.ubi_codigo = GLO_UBI_PISO_PRODUCTO_TERMINADO
            classUbicaciones.diasUbicacion = True
            ds = classUbicaciones.ACTUALIZA_UBICACIONES_A_PISO_PT(_msgError, conexion)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Exit Function
                End If
            End If

            ENVIA_PALLET_A_PT = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class