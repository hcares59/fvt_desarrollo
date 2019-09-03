Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading

Public Class frm_reubicacion_de_bultos
    'Grilla
    Const CONT_COL_SEL As Integer = 0
    Const CONT_COL_FILA As Integer = 1
    Const CONT_COL_PRO_CODIGO As Integer = 2
    Const CONT_COL_CODIGO As Integer = 3
    Const CONT_COL_PRODUCTO As Integer = 4
    Const CONT_COL_NBULTO As Integer = 5
    Const CONT_COL_BULTO As Integer = 6
    Const CONT_COL_PALLET As Integer = 7
    Const CONT_COL_CANTIDAD As Integer = 8
    Const CONT_COL_UBICACION As Integer = 9
    Const CONT_COL_CODIGO_UBICACION As Integer = 10
    Const CONT_COL_UBICADO As Integer = 11
    Const CONT_COL_BOTON As Integer = 12

    'Grilla Variado
    Const CONT_COL_VSEL As Integer = 0
    Const CONT_COL_VFILA As Integer = 1
    Const CONT_COL_VPRO_CODIGO As Integer = 2
    Const CONT_COL_VCODIGO As Integer = 3
    Const CONT_COL_VPRODUCTO As Integer = 4
    Const CONT_COL_VNBULTO As Integer = 5
    Const CONT_COL_VBULTO As Integer = 6
    Const CONT_COL_VPALLET As Integer = 7
    Const CONT_COL_VCANTIDAD As Integer = 8

    'Grilla Variado Detalle
    Const CONT_COL_DSEL As Integer = 0
    Const CONT_COL_DFILA As Integer = 1
    Const CONT_COL_DPRO_CODIGO As Integer = 2
    Const CONT_COL_DCODIGO As Integer = 3
    Const CONT_COL_DPRODUCTO As Integer = 4
    Const CONT_COL_DNBULTO As Integer = 5
    Const CONT_COL_DBULTO As Integer = 6
    Const CONT_COL_DPALLET As Integer = 7
    Const CONT_COL_DCANTIDAD As Integer = 8
    Const CONT_COL_DUBICACION As Integer = 9
    Const CONT_COL_DCODIGO_UBICACION As Integer = 10
    Const CONT_COL_DUBICADO As Integer = 11
    Const CONT_COL_DBOTON As Integer = 12


    Private _APROBADO As Boolean
    Private _RECHAZADO As Boolean

    Dim _cnn As String
    Dim _asiNumero As Integer
    Private _esi_codigo As Integer
    Dim cargaPrimeraVez As Boolean = False

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property asiNumero() As String
        Get
            Return _asiNumero
        End Get
        Set(ByVal value As String)
            _asiNumero = value
        End Set
    End Property
    Public Property esi_codigo() As Integer
        Get
            Return _esi_codigo
        End Get
        Set(ByVal value As Integer)
            _esi_codigo = value
        End Set
    End Property

    Private Sub frm_reubicacion_de_bultos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'TabPage2.Parent = Nothing
        'TabPage1.Parent = TabControl1
    End Sub

    Private Sub frm_reubicacion_de_bultos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cargaPrimeraVez = False
        TabControl1.TabPages.Clear()
        TabPage1.Parent = TabControl1
        Call INICIALIZA()

        cargaPrimeraVez = True
        Call OBTIENE_ESTADO_ASIGNACION()

        If _esi_codigo > 0 Then
            Call CARGA_DATOS_ENCABEZADO_ASIGNACION()
            optBultoUnico.Visible = False
            optBultoVariado.Visible = False
        Else
            optBultoUnico.Visible = True
            optBultoVariado.Visible = True
            btnAsigna.Enabled = True
            txtNumAsi.Enabled = False
            TxtFechaAsi.Enabled = False
        End If
    End Sub

    Private Sub CARGA_DATOS_ENCABEZADO_ASIGNACION()
        Dim classAsi As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classAsi.cnn = _cnn
            classAsi.rec_numero = 0
            classAsi.asi_numero = _asiNumero

            ds = classAsi.CARGA_CABECERA_ASIGNACION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("asi_numero") > 0 Then
                        txtNumAsi.Text = ds.Tables(0).Rows(Fila)("asi_strnumero")
                        TxtFechaAsi.Text = ds.Tables(0).Rows(Fila)("asi_fecha")

                        txtNumAsi.Enabled = False
                        TxtFechaAsi.Enabled = False
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_ENCABEZADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_ENCABEZADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OBTIENE_ESTADO_ASIGNACION()
        Dim classAsi As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            Grilla.Columns(CONT_COL_UBICADO).Visible = False
            GrillaVariadoDetalle.Columns(CONT_COL_DUBICADO).Visible = False
            GrillaVariadoDetalle.Columns(CONT_COL_DBOTON).Visible = False

            classAsi.cnn = _cnn
            classAsi.asi_numero = _asiNumero

            ds = classAsi.OBTIENE_ESTADO_ASIGNACION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("esi_codigo") = ESTADO_ASIGNACION.ASIGNACION_GENERADA Then
                        btnImprimeIdentificador.Enabled = True
                        If USU_EJECUTA_ALMACENAMIENTO = True Then
                            btnAsigna.Enabled = False
                            btnImprimeIdentificador.Enabled = True
                            btnGuardaAsignacion.Enabled = True
                            btnEnviaAprovación.Enabled = True
                            btnAprueba.Enabled = False
                            btnRechazo.Enabled = False

                            Grilla.Columns(CONT_COL_BOTON).Visible = False
                            Grilla.Columns(CONT_COL_UBICADO).Visible = True

                            GrillaVariadoDetalle.Columns(CONT_COL_DBOTON).Visible = False
                            GrillaVariadoDetalle.Columns(CONT_COL_DUBICADO).Visible = True

                        End If
                    ElseIf ds.Tables(0).Rows(Fila)("esi_codigo") = ESTADO_ASIGNACION.PENDIENTE_DE_APROBACIÓN Then
                        btnImprimeIdentificador.Enabled = True
                        If USU_ASIGNA_PARA_ALMACENAMIENTO = True Then
                            btnAsigna.Enabled = False
                            btnImprimeIdentificador.Enabled = True
                            btnGuardaAsignacion.Enabled = False
                            btnEnviaAprovación.Enabled = False
                            btnAprueba.Enabled = True
                            btnRechazo.Enabled = True
                            Grilla.Columns(CONT_COL_BOTON).Visible = True
                            Grilla.Columns(CONT_COL_UBICADO).Visible = True
                            Grilla.Columns(CONT_COL_UBICADO).ReadOnly = True

                            GrillaVariadoDetalle.Columns(CONT_COL_DBOTON).Visible = True
                            GrillaVariadoDetalle.Columns(CONT_COL_DUBICADO).Visible = True
                            GrillaVariadoDetalle.Columns(CONT_COL_DUBICADO).ReadOnly = True

                        End If
                    ElseIf ds.Tables(0).Rows(Fila)("esi_codigo") = ESTADO_ASIGNACION.APROBADA_POR_BODEGA Then
                        btnImprimeIdentificador.Enabled = True
                        btnAsigna.Enabled = False
                        btnImprimeIdentificador.Enabled = True
                        btnGuardaAsignacion.Enabled = False
                        btnEnviaAprovación.Enabled = False
                        btnAprueba.Enabled = False
                        btnRechazo.Enabled = False

                        Grilla.Columns(CONT_COL_BOTON).Visible = False

                        GrillaVariadoDetalle.Columns(CONT_COL_DBOTON).Visible = False

                    Else
                        Grilla.Columns(CONT_COL_BOTON).Visible = False
                        Grilla.Columns(CONT_COL_UBICADO).ReadOnly = True

                        GrillaVariadoDetalle.Columns(CONT_COL_DBOTON).Visible = False
                        GrillaVariadoDetalle.Columns(CONT_COL_DUBICADO).ReadOnly = True

                        btnImprimeIdentificador.Enabled = False
                    End If
                Else
                    Grilla.Columns(CONT_COL_BOTON).Visible = False
                    Grilla.Columns(CONT_COL_UBICADO).Visible = False

                    GrillaVariadoDetalle.Columns(CONT_COL_DBOTON).Visible = False
                    GrillaVariadoDetalle.Columns(CONT_COL_DUBICADO).Visible = False
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_ESTADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\OBTIENE_ESTADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLE_BULTO_COMPLETO(ByVal proCodigo As Integer, ByVal ubiCodigo As Integer)
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classUbicacion.cnn = _cnn
            classUbicacion.pro_codigo = proCodigo
            classUbicacion.asi_numero = _asiNumero
            classUbicacion.ubi_codigo = ubiCodigo
            classUbicacion.bultoVariado = 0

            'If _asiNumero > 0 Then
            Grilla.Rows.Clear()
            'End If
            ds = classUbicacion.CARGA_DETALLE_REASIGNACION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False,
                                            ds.Tables(0).Rows(Fila)("asi_fila"),
                                            ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("pro_numbulto"),
                                            ds.Tables(0).Rows(Fila)("bulto"),
                                            ds.Tables(0).Rows(Fila)("prd_palletserie"),
                                            ds.Tables(0).Rows(Fila)("prd_cantidadsaldo"),
                                            ds.Tables(0).Rows(Fila)("ubi_nombre"),
                                            ds.Tables(0).Rows(Fila)("ubi_codigo"),
                                            ds.Tables(0).Rows(Fila)("asi_ubicado"))
                            Fila = Fila + 1
                            Contador = Contador + 1
                        Loop
                        Grilla.Columns(CONT_COL_SEL).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_FILA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_PRODUCTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_NBULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_PALLET).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_CANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_CODIGO_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_UBICADO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONT_COL_BOTON).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE_BULTO_COMPLETO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE_BULTO_COMPLETO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLE_BULTO_VARIADO(ByVal proCodigo As Integer, ByVal ubiCodigo As Integer)
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classUbicacion.cnn = _cnn
            classUbicacion.pro_codigo = proCodigo
            classUbicacion.asi_numero = _asiNumero
            classUbicacion.ubi_codigo = ubiCodigo
            classUbicacion.bultoVariado = True

            'If _asiNumero > 0 Then
            GrillaVariado.Rows.Clear()
            'End If
            ds = classUbicacion.CARGA_DETALLE_REASIGNACION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaVariado.Rows.Add(False,
                                            ds.Tables(0).Rows(Fila)("asi_fila"),
                                            ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("pro_numbulto"),
                                            ds.Tables(0).Rows(Fila)("bulto"),
                                            ds.Tables(0).Rows(Fila)("prd_palletserie"),
                                            ds.Tables(0).Rows(Fila)("prd_cantidadsaldo"))
                            Fila = Fila + 1
                            Contador = Contador + 1
                        Loop
                        GrillaVariado.Columns(CONT_COL_VSEL).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GrillaVariado.Columns(CONT_COL_VFILA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GrillaVariado.Columns(CONT_COL_VPRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GrillaVariado.Columns(CONT_COL_VCODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GrillaVariado.Columns(CONT_COL_VPRODUCTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GrillaVariado.Columns(CONT_COL_VNBULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GrillaVariado.Columns(CONT_COL_VBULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GrillaVariado.Columns(CONT_COL_VPALLET).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GrillaVariado.Columns(CONT_COL_VCANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE_BULTO_VARIADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE_BULTO_VARIADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub INICIALIZA()
        txtNumAsi.Text = "0"
        txtNumAsi.Enabled = False
        TxtFechaAsi.Enabled = True

        optBultoUnico.Visible = False
        optBultoVariado.Visible = False

        Call CARGA_COMBO_PRODUCTOS_UBICACION_PISO()
        Call CARGA_COMBO_PRODUCTOS_UBICACION_PISO_BULTO_VARIADO()

        If optBultoUnico.Checked = True Then
            Call CARGA_GRILLA_DETALLE_BULTO_COMPLETO(0, GLO_UBI_PISO_PRODUCTO_TERMINADO)
        Else
            Call CARGA_GRILLA_DETALLE_BULTO_VARIADO(0, GLO_UBI_PISO_PRODUCTO_TERMINADO)
        End If

        btnAsigna.Enabled = False
        btnImprimeIdentificador.Enabled = False
        btnGuardaAsignacion.Enabled = False
        btnEnviaAprovación.Enabled = False
        btnAprueba.Enabled = False
        btnRechazo.Enabled = False

    End Sub

    Private Sub CARGA_COMBO_PRODUCTOS_UBICACION_PISO()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn

            classUbicacion.ubi_codigo = GLO_UBI_PISO_PRODUCTO_TERMINADO

            _msg = ""
            ds = classUbicacion.PRODUCTOS_POR_UBICACIONES_PISO_CARGA_COMBO_BULTO_UNICO(_msg)
            If _msg = "" Then
                Me.cmbProductos.DataSource = ds.Tables(0)
                Me.cmbProductos.DisplayMember = "MENSAJE"
                Me.cmbProductos.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PRODUCTOS_UBICACION_PISO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_PRODUCTOS_UBICACION_PISO_BULTO_VARIADO()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn

            classUbicacion.ubi_codigo = GLO_UBI_PISO_PRODUCTO_TERMINADO

            _msg = ""
            ds = classUbicacion.PRODUCTOS_POR_UBICACIONES_PISO_CARGA_COMBO_BULTO_VARIADO(_msg)
            If _msg = "" Then
                Me.comProductoVariado.DataSource = ds.Tables(0)
                Me.comProductoVariado.DisplayMember = "MENSAJE"
                Me.comProductoVariado.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PRODUCTOS_UBICACION_PISO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub optBultoUnico_CheckedChanged(sender As Object, e As EventArgs) Handles optBultoUnico.CheckedChanged
        If optBultoUnico.Checked = True Then
            If cargaPrimeraVez = True Then
                TabControl1.TabPages.Clear()
                TabPage1.Parent = TabControl1
                Call CARGA_GRILLA_DETALLE_BULTO_COMPLETO(cmbProductos.SelectedValue, GLO_UBI_PISO_PRODUCTO_TERMINADO)
            End If
        End If
    End Sub

    Private Sub optBultoVariado_CheckedChanged(sender As Object, e As EventArgs) Handles optBultoVariado.CheckedChanged
        If optBultoVariado.Checked = True Then
            If cargaPrimeraVez = True Then
                TabControl1.TabPages.Clear()
                TabPage2.Parent = TabControl1
                Call CARGA_GRILLA_DETALLE_BULTO_VARIADO(comProductoVariado.SelectedValue, GLO_UBI_PISO_PRODUCTO_TERMINADO)
            End If

        End If
    End Sub

    Private Sub btnAsigna_Click(sender As Object, e As EventArgs)
        Dim respuesta As Integer = 0

        respuesta = MessageBox.Show("El proceso de asignación puede tardar un poco mas de lo normal" _
                                    + Chr(10) + "¿Esta seguro en continuar la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = vbNo Then
            Exit Sub
        End If

        _APROBADO = False
        _RECHAZADO = False
        'Call GENERA_ASIGNACION_UBICACION()
        'Call OBTIENE_ESTADO_ASIGNACION()
        'Call CARGA_GRILLA_DETALLE(0, 0)
        'Call CARGA_GRILLA_PENDIENTE()
    End Sub

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged

    End Sub

    Private Sub cmbProductos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbProductos.SelectionChangeCommitted
        If cargaPrimeraVez = True Then
            If optBultoUnico.Checked = True Then
                Call CARGA_GRILLA_DETALLE_BULTO_COMPLETO(cmbProductos.SelectedValue, GLO_UBI_PISO_PRODUCTO_TERMINADO)
            Else
                Call CARGA_GRILLA_DETALLE_BULTO_VARIADO(comProductoVariado.SelectedValue, GLO_UBI_PISO_PRODUCTO_TERMINADO)
            End If
        End If
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub GrillaVariado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaVariado.CellContentClick
        If e.ColumnIndex = Me.GrillaVariado.Columns.Item(CONT_COL_VSEL).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaVariado.Rows(e.RowIndex).Cells(CONT_COL_VSEL)
            chkCell.Value = Not chkCell.Value
            GrillaVariadoDetalle.Rows.Clear()
            Call SELECCIONA_DETALLE_PRODUCTO()

            GrillaVariadoDetalle.Columns(CONT_COL_DSEL).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DFILA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DPRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DCODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DPRODUCTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DNBULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DBULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DPALLET).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DCANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DUBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DCODIGO_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DUBICADO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            GrillaVariadoDetalle.Columns(CONT_COL_DBOTON).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        End If
    End Sub

    Private Sub SELECCIONA_DETALLE_PRODUCTO()
        Dim Fila As Integer = 0
        Try
            For Each row As DataGridViewRow In Me.GrillaVariado.Rows
                If row.Cells(0).Value = True Then
                    Fila = 1
                    Do While Fila <= row.Cells(CONT_COL_VCANTIDAD).Value
                        GrillaVariadoDetalle.Rows.Add(False, 0, row.Cells(CONT_COL_VPRO_CODIGO).Value,
                                                      row.Cells(CONT_COL_VCODIGO).Value,
                                                      row.Cells(CONT_COL_VPRODUCTO).Value,
                                                      row.Cells(CONT_COL_VNBULTO).Value,
                                                      row.Cells(CONT_COL_VBULTO).Value,
                                                      row.Cells(CONT_COL_VPALLET).Value,
                                                      1,
                                                      "", "", False)

                        Fila = Fila + 1
                    Loop
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub comProductoVariado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comProductoVariado.SelectedIndexChanged

    End Sub

    Private Sub comProductoVariado_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comProductoVariado.SelectionChangeCommitted
        If optBultoVariado.Checked = True Then
            Call CARGA_GRILLA_DETALLE_BULTO_VARIADO(comProductoVariado.SelectedValue, GLO_UBI_PISO_PRODUCTO_TERMINADO)
            Call GrillaVariadoDetalle.Rows.Clear()
        Else
            Call CARGA_GRILLA_DETALLE_BULTO_COMPLETO(cmbProductos.SelectedValue, GLO_UBI_PISO_PRODUCTO_TERMINADO)
        End If
    End Sub

    Private Sub btnAsigna_Click_1(sender As Object, e As EventArgs) Handles btnAsigna.Click
        Dim respuesta As Integer = 0

        respuesta = MessageBox.Show("El proceso de asignación puede tardar un poco mas de lo normal" _
                                    + Chr(10) + "¿Esta seguro en continuar la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = vbNo Then
            Exit Sub
        End If

        _APROBADO = False
        _RECHAZADO = False
        If GENERA_ASIGNACION_UBICACION() = False Then
            Exit Sub
        End If
        Call OBTIENE_ESTADO_ASIGNACION()
        'Call CARGA_GRILLA_DETALLE(0, 0)
        'Call CARGA_GRILLA_PENDIENTE()
    End Sub


    Private Function GENERA_ASIGNACION_UBICACION() As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        GENERA_ASIGNACION_UBICACION = False

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classUbicaciones.cnn = _cnn
                classUbicaciones.car_codigo = 0

                ProgressBar1.Visible = True
                ProgressBar1.Value = 0
                ProgressBar1.Minimum = 0
                ProgressBar1.Maximum = Grilla.RowCount
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(CONT_COL_CANTIDAD).Value > 0 Then
                        classUbicaciones.pro_codigo = row.Cells(CONT_COL_PRO_CODIGO).Value
                        classUbicaciones.bul_codigo = row.Cells(CONT_COL_NBULTO).Value
                        classUbicaciones.pallet = row.Cells(CONT_COL_PALLET).Value
                        ds = Nothing
                        ds = classUbicaciones.OBTIENE_UBICACION_PARA_ASIGNAR(_msgError, conexion)
                        If _msgError = "" Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                If ds.Tables(0).Rows(0)("mensaje") <> "-" Then
                                    row.Cells(CONT_COL_UBICACION).Value = ds.Tables(0).Rows(0)("mensaje")
                                    row.Cells(CONT_COL_CODIGO_UBICACION).Value = ds.Tables(0).Rows(0)("codigo")
                                Else
                                    row.Cells(CONT_COL_UBICACION).Value = "SIN UBICACIÓN"
                                    row.Cells(CONT_COL_CODIGO_UBICACION).Value = "00000"
                                End If

                                Grilla.Refresh()
                            Else
                                row.Cells(CONT_COL_UBICACION).Value = "SIN UBICACIÓN"
                                row.Cells(CONT_COL_CODIGO_UBICACION).Value = "00000"
                                Grilla.Refresh()
                                ds = Nothing
                            End If
                        Else
                            ds = Nothing
                            MessageBox.Show(_msgError + "\OBTIENE_UBICACIONES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                    ProgressBar1.Value += 1
                Next

                If GUARDA_ASIGNACION_ENCABEZADO(ESTADO_ASIGNACION.ASIGNACION_GENERADA, conexion) = False Then
                    Exit Function
                Else
                    _esi_codigo = ESTADO_ASIGNACION.ASIGNACION_GENERADA
                    If GUARDA_ASIGNACION_DETALLE(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        Me.Cursor = Cursors.Default
                        Exit Function
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default
            End Using

            If VERIFICA_UBICACIONES() = True Then
                MessageBox.Show("La asignación fue guardada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnImprimeIdentificador.Enabled = True
                GENERA_ASIGNACION_UBICACION = True
            Else
                MessageBox.Show("Existen registros que no tiene ubicación asignada, contacte al administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                GENERA_ASIGNACION_UBICACION = False
            End If

            'ProgressBar1.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function VERIFICA_UBICACIONES()
        Dim contador As Integer = 0

        VERIFICA_UBICACIONES = True
        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(CONT_COL_UBICACION).Value = "SIN UBICACIÓN" Or row.Cells(CONT_COL_UBICACION).Value = "-" Then
                contador = contador + 1
            End If
        Next

        If contador > 0 Then
            VERIFICA_UBICACIONES = False
        End If
    End Function

    Private Function GUARDA_ASIGNACION_DETALLE(ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim tmp_llave_pallet As String = ""
        GUARDA_ASIGNACION_DETALLE = False
        Try

            tmp_llave_pallet = "ASI-" + String.Format("{0:00000000}", _asiNumero)

            If _esi_codigo = ESTADO_ASIGNACION.PENDIENTE_DE_APROBACIÓN Then
                For Each row2 As DataGridViewRow In Me.Grilla.Rows
                    ds = Nothing
                    If row2.Cells(CONT_COL_UBICADO).Value = True Then
                        classUbicaciones.asi_codigo = _asiNumero
                        classUbicaciones.asi_fila = row2.Cells(CONT_COL_FILA).Value
                        classUbicaciones.pro_codigo = row2.Cells(CONT_COL_PRO_CODIGO).Value
                        classUbicaciones.asi_nbulto = row2.Cells(CONT_COL_NBULTO).Value
                        classUbicaciones.asi_bulto = row2.Cells(CONT_COL_BULTO).Value
                        classUbicaciones.asi_pallet = row2.Cells(CONT_COL_PALLET).Value
                        classUbicaciones.asi_cantidad = row2.Cells(CONT_COL_CANTIDAD).Value
                        classUbicaciones.asi_cantidadreserva = 0
                        classUbicaciones.asi_cantidadsaldo = row2.Cells(CONT_COL_CANTIDAD).Value
                        classUbicaciones.asi_ubicacionnombre = row2.Cells(CONT_COL_UBICACION).Value
                        classUbicaciones.asi_ubicacioncodigo = row2.Cells(CONT_COL_CODIGO_UBICACION).Value
                        classUbicaciones.asi_ubicado = IIf(IsDBNull(row2.Cells(CONT_COL_UBICADO).Value) = True, False, row2.Cells(CONT_COL_UBICADO).Value) 'row2.Cells(COL_GRI_PENDIENTE).Value
                        classUbicaciones.aprobado = _APROBADO
                        classUbicaciones.rechazado = _RECHAZADO

                        ds = classUbicaciones.GUARDA_DETALLE_ASIGNACION(_msgError, conexion)
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
                    End If
                Next
            Else
                For Each row2 As DataGridViewRow In Me.Grilla.Rows
                    If (row2.Cells(CONT_COL_UBICACION).Value <> "-") And (row2.Cells(CONT_COL_UBICACION).Value <> "SIN UBICACIÓN") Then
                        ds = Nothing
                        classUbicaciones.asi_codigo = _asiNumero
                        classUbicaciones.asi_fila = row2.Cells(CONT_COL_FILA).Value
                        classUbicaciones.pro_codigo = row2.Cells(CONT_COL_PRO_CODIGO).Value
                        classUbicaciones.asi_nbulto = row2.Cells(CONT_COL_NBULTO).Value
                        classUbicaciones.asi_bulto = row2.Cells(CONT_COL_BULTO).Value
                        classUbicaciones.asi_pallet = row2.Cells(CONT_COL_PALLET).Value
                        classUbicaciones.asi_cantidad = row2.Cells(CONT_COL_CANTIDAD).Value
                        classUbicaciones.asi_cantidadreserva = 0
                        classUbicaciones.asi_cantidadsaldo = row2.Cells(CONT_COL_CANTIDAD).Value
                        classUbicaciones.asi_ubicacionnombre = row2.Cells(CONT_COL_UBICACION).Value
                        classUbicaciones.asi_ubicacioncodigo = row2.Cells(CONT_COL_CODIGO_UBICACION).Value
                        classUbicaciones.asi_ubicado = IIf(IsDBNull(row2.Cells(CONT_COL_UBICADO).Value) = True, False, row2.Cells(CONT_COL_UBICADO).Value) 'row2.Cells(COL_GRI_PENDIENTE).Value
                        classUbicaciones.aprobado = _APROBADO
                        classUbicaciones.rechazado = _RECHAZADO

                        ds = classUbicaciones.GUARDA_DETALLE_ASIGNACION(_msgError, conexion)
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

                        ds = Nothing
                        classUbicaciones.asi_numero = _asiNumero
                        classUbicaciones.asi_pallet = row2.Cells(CONT_COL_PALLET).Value
                        ds = classUbicaciones.ASIGNA_NUMERO_ASI(_msgError, conexion)
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
                    End If
                Next
            End If

            GUARDA_ASIGNACION_DETALLE = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Function GUARDA_ASIGNACION_ENCABEZADO(ByVal codEstadoAsignacion As Integer, ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet

        GUARDA_ASIGNACION_ENCABEZADO = False

        Try
            'Guarda cabecera del documento
            ds = Nothing
            classUbicaciones.asi_codigo = _asiNumero
            classUbicaciones.asi_fecha = TxtFechaAsi.Value
            classUbicaciones.car_codigo = 0
            'classUbicaciones.esi_codigo = ESTADO_ASIGNACION.ASIGNACION_GENERADA
            classUbicaciones.esi_codigo = codEstadoAsignacion
            classUbicaciones.rec_numero = 0
            classUbicaciones.rec_fecha = CDate("01-01-1900")
            classUbicaciones.ocp_numero = 0
            classUbicaciones.ocp_fecha = CDate("01-01-1900")
            classUbicaciones.rec_nfactura = 0
            classUbicaciones.rec_nguia = 0

            If optBultoUnico.Checked = True Then
                classUbicaciones.bulto_completo = True
            ElseIf optBultoVariado.Checked = True Then
                classUbicaciones.bulto_completo = False
            End If

                ds = classUbicaciones.GUARDA_ASIGNACION_ENCABEZADO(_msgError, conexion)
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
                    _asiNumero = ds.Tables(0).Rows(0)("CODIGO")
                End If
            End If

            GUARDA_ASIGNACION_ENCABEZADO = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnEnviaAprovación_Click(sender As Object, e As EventArgs) Handles btnEnviaAprovación.Click
        Dim contador As Integer = 0
        Dim respuesta As Integer = 0

        For Each row As DataGridViewRow In Me.Grilla.Rows
            If (row.Cells(CONT_COL_UBICADO).Value = False) Then
                contador = contador + 1
            End If
        Next

        If contador > 0 Then
            respuesta = MessageBox.Show("Esta tratando de enviar aprobar ubicaciones sin marcar, ¿esta seguro que desea seguir con la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = vbNo Then
                Exit Sub
            End If

        End If

        _APROBADO = False
        _RECHAZADO = False
        Call GUARDA_ASIGNACION(ESTADO_ASIGNACION.PENDIENTE_DE_APROBACIÓN)
        Call OBTIENE_ESTADO_ASIGNACION()
        'Call CARGA_GRILLA_DETALLE(0, 0)
    End Sub

    Private Sub GUARDA_ASIGNACION(ByVal codEstadoAsignacion As Integer)
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim respuesta As Integer = 0
        Dim muestraMensaje As Boolean = False

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                If GUARDA_ASIGNACION_ENCABEZADO(codEstadoAsignacion, conexion) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    Exit Sub
                Else
                    _esi_codigo = codEstadoAsignacion
                    If GUARDA_ASIGNACION_DETALLE(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        Exit Sub
                    End If
                End If

                If _APROBADO = True Then
                    If ALMACENA_PALLET(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If ELIMINA_DATOS_TEMPORALES_PARA_PALETIZAR(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                If _RECHAZADO = True Then

                    If ELIMINA_DATOS_TEMPORALES_PARA_PALETIZAR(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If ELIMINA_ASIGNACION(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                End If

                If LIMPIA_DETALLE_ASIGNACION(conexion) = False Then
                    muestraMensaje = True
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                If muestraMensaje = True Then
                    MessageBox.Show("Los datos fueron guardados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.Cursor = Cursors.Default
                    Me.Dispose()
                End If

            End Using
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function LIMPIA_DETALLE_ASIGNACION(ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim totalRegistros As Integer = 0
        Dim contador As Integer = 0

        LIMPIA_DETALLE_ASIGNACION = False

        Try
            totalRegistros = Grilla.RowCount

            For Each row As DataGridViewRow In Me.Grilla.Rows
                If (row.Cells(CONT_COL_UBICACION).Value = "SIN UBICACIÓN") Or (row.Cells(CONT_COL_UBICACION).Value = "-") Then
                    contador = contador + 1
                End If
            Next

            ds = Nothing
            classUbicaciones.asi_codigo = _asiNumero

            If contador = 0 Then
                Exit Function
            ElseIf contador > 0 And contador < totalRegistros Then
                ds = classUbicaciones.LIMPIA_DETALLE_ASIGNACION(_msgError, conexion)
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
                        LIMPIA_DETALLE_ASIGNACION = False
                        MessageBox.Show("Documento enviado aprobar!!" _
                                        + Chr(10) + "Algunos items serán removidos del documento ya que no se encontro ubicación disponible para su almacenaje", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If

            ElseIf contador > 0 And contador = totalRegistros Then
                Call ELIMINA_ASIGNACION(conexion)
                MessageBox.Show("El documento no cuenta con ninguna ubicación disponible para su almacenaje y por ende se procedio a eliminarse", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIA_DETALLE_ASIGNACION = True
            End If

        Catch ex As Exception
            LIMPIA_DETALLE_ASIGNACION = True
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function ELIMINA_ASIGNACION(ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        ELIMINA_ASIGNACION = False
        Try
            ds = Nothing
            classUbicaciones.asi_codigo = _asiNumero
            ds = classUbicaciones.ELIMINA_ASIGNACION(_msgError, conexion)
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
            ELIMINA_ASIGNACION = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Function ELIMINA_DATOS_TEMPORALES_PARA_PALETIZAR(ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim tmp_llave_pallet As String = ""
        Dim ds As DataSet
        ELIMINA_DATOS_TEMPORALES_PARA_PALETIZAR = False
        Try
            tmp_llave_pallet = "ASI-" + String.Format("{0:00000000}", _asiNumero)

            ds = Nothing
            classUbicaciones.tmp_llave = tmp_llave_pallet
            classUbicaciones.Documento = "-"
            classUbicaciones.Numero = 0
            ds = classUbicaciones.DATOS_PARA_PALETIZAR_ELIMINA(_msgError, conexion)
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

            ELIMINA_DATOS_TEMPORALES_PARA_PALETIZAR = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Function ALMACENA_PALLET(ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim tmp_llave_pallet As String = ""
        ALMACENA_PALLET = False
        Try

            tmp_llave_pallet = "ASI-" + String.Format("{0:00000000}", _asiNumero)

            For Each row2 As DataGridViewRow In Me.Grilla.Rows
                ds = Nothing
                If row2.Cells(CONT_COL_CANTIDAD).Value > 0 Then
                    classUbicaciones.pallet = row2.Cells(CONT_COL_PALLET).Value
                    classUbicaciones.asi_cantidadsaldo = row2.Cells(CONT_COL_CANTIDAD).Value
                    classUbicaciones.ubi_codigostr = row2.Cells(CONT_COL_CODIGO_UBICACION).Value
                    classUbicaciones.tmp_llave = tmp_llave_pallet

                    ds = classUbicaciones.ALMACENA_PALLET(_msgError, conexion)
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
                End If
            Next

            ALMACENA_PALLET = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnAprueba_Click(sender As Object, e As EventArgs) Handles btnAprueba.Click
        Dim respuesta As Integer = 0

        _APROBADO = True
        _RECHAZADO = False

        respuesta = MessageBox.Show("¿Esta seguro(a) de aprobar la asignación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = vbNo Then
            Exit Sub
        End If

        If VALIDA_ITEMS_PARA_APROBAR() = False Then
            MessageBox.Show("Existen Items pendientes de ubicación" _
                            + Chr(10) + "No es posible aprobar la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
        End If

        Call GUARDA_ASIGNACION(ESTADO_ASIGNACION.APROBADA_POR_BODEGA)
        Call OBTIENE_ESTADO_ASIGNACION()
        'Call CARGA_GRILLA_DETALLE(0, 0)
    End Sub

    Private Function VALIDA_ITEMS_PARA_APROBAR() As Boolean
        Dim totalFilas As Integer = 0
        Dim contador As Integer = 0
        VALIDA_ITEMS_PARA_APROBAR = False
        Try
            totalFilas = Grilla.RowCount

            For Each row2 As DataGridViewRow In Me.Grilla.Rows
                If row2.Cells(CONT_COL_UBICADO).Value = True Then
                    contador = contador + 1
                End If
            Next

            If contador = totalFilas Then
                VALIDA_ITEMS_PARA_APROBAR = True
            End If
        Catch ex As Exception
            VALIDA_ITEMS_PARA_APROBAR = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub btnRechazo_Click(sender As Object, e As EventArgs) Handles btnRechazo.Click
        Dim Respuesta As Integer = 0

        Respuesta = MessageBox.Show("¿Esta seguro(a) de rechazar la asignación", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If Respuesta = vbNo Then
            Exit Sub
        End If

        _APROBADO = False
        _RECHAZADO = True
        Call GUARDA_ASIGNACION(ESTADO_ASIGNACION.APROBADA_POR_BODEGA)
        Call OBTIENE_ESTADO_ASIGNACION()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(CONT_COL_SEL).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(CONT_COL_SEL)
            chkCell.Value = Not chkCell.Value
        End If

        If USU_ASIGNA_PARA_ALMACENAMIENTO = True Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(CONT_COL_UBICADO)
            chkCell.Value = chkCell.Value 'False
        Else
            If e.ColumnIndex = Me.Grilla.Columns.Item(CONT_COL_UBICADO).Index Then
                Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(CONT_COL_UBICADO)
                chkCell.Value = Not chkCell.Value
            End If
        End If



        If e.ColumnIndex = Me.Grilla.Columns.Item(CONT_COL_BOTON).Index Then
            If Grilla.Rows(e.RowIndex).Cells(CONT_COL_UBICADO).Value = True Then
                MessageBox.Show("No es posible reasignar ubicación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            Dim frm As frm_movimiento_de_pallet = New frm_movimiento_de_pallet
            GLO_ACCION_EJECUTADA = False
            frm.cnn = _cnn
            frm.bod_codigo = BODEGAS.BOD_PRODUCTO_TERMINADO
            frm.ubi_codigo = UBICACION.PISO_PRODUCTO_TERMINADO
            frm.ubicacion_actual = Grilla.Rows(e.RowIndex).Cells(CONT_COL_UBICACION).Value
            frm.ShowDialog()

            If GLO_ACCION_EJECUTADA = True Then
                Grilla.Rows(e.RowIndex).Cells(CONT_COL_UBICADO).Value = True
                GLO_ACCION_EJECUTADA = False
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim frm As frm_imprimir = New frm_imprimir
        frm.nombreReporte = "rptDocumentoAsignacion.rpt"
        frm.Origen = "DAS"
        frm.asi_codigo = _asiNumero
        frm.ShowDialog()
    End Sub

    Private Sub btnImprimeIdentificador_Click(sender As Object, e As EventArgs) Handles btnImprimeIdentificador.Click
        Try
            Dim frm As frm_imprimir = New frm_imprimir
            frm.Origen = "SPA"

            frm.asi_codigo = _asiNumero
            frm.serie_paller = OBTIENE_SERIES()

            frm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function OBTIENE_SERIES() As String
        Dim strPallet As String = ""
        OBTIENE_SERIES = ""
        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(0).Value = True Then
                If strPallet = "" Then
                    strPallet = row.Cells(CONT_COL_PALLET).Value
                Else
                    strPallet = strPallet + "," + row.Cells(CONT_COL_PALLET).Value
                End If
            End If
        Next
        If strPallet = "" Then
            OBTIENE_SERIES = "-"
        Else
            OBTIENE_SERIES = strPallet + ","
        End If

    End Function

End Class