Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading
Public Class frm_oden_para_picking
    Dim _cnn As String
    Dim _opi_codigo As Integer
    Dim _abp_estado As Integer
    Dim _dab_codigo As Integer
    Dim _viene As String

    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""

    Dim _colum As Integer = 0
    Dim _fila As Integer = 0


    'Estados _eop_codigo: 1: Generada, 2: Procesada, 3: Finalizada
    Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Property opi_codigo() As Integer
        Get
            Return _opi_codigo
        End Get
        Set(ByVal value As Integer)
            _opi_codigo = value
        End Set
    End Property
    Property abp_estado() As Integer
        Get
            Return _abp_estado
        End Get
        Set(ByVal value As Integer)
            _abp_estado = value
        End Set
    End Property
    Property dab_codigo() As Integer
        Get
            Return _dab_codigo
        End Get
        Set(ByVal value As Integer)
            _dab_codigo = value
        End Set
    End Property

    Const COL_GRI_COD_PICKING As Integer = 0
    Const COL_GRI_SELECCION As Integer = 1
    Const COL_GRI_NUM_PICKING As Integer = 2
    Const COL_GRI_FEC_INGRESO As Integer = 3
    Const COL_GRI_FEC_COMPROMISO As Integer = 4
    Const COL_GRI_HORA_CITA As Integer = 5
    Const COL_GRI_CAR_CODIGO As Integer = 6
    Const COL_GRI_CAR_NOMBRE As Integer = 7
    Const COL_GRI_DESPACHARA As Integer = 8
    Const COL_GRI_TOTAL_BULTO As Integer = 9
    Const COL_GRI_BOTON As Integer = 10

    Const COL_GRI_P2_PRO_CODIGO As Integer = 0
    Const COL_GRI_P2_SELECCION As Integer = 1
    Const COL_GRI_P2_CODIGO As Integer = 2
    Const COL_GRI_P2_NOMBRE As Integer = 3
    Const COL_GRI_P2_CANTIDAD As Integer = 4
    Const COL_GRI_P2_CANTIDAD_PICKEADA As Integer = 5
    Const COL_GRI_P2_CANTIDAD_PENDIENTE As Integer = 6
    Const COL_GRI_P2_CANTIDAD_UBICACION_PK As Integer = 7
    Const COL_GRI_P2_CANTIDAD_DISPONIBLE_BODEGA As Integer = 8
    Const COL_GRI_P2_OBSERVACION As Integer = 9
    Const COL_GRI_P2_COD_OBSERVACION As Integer = 10

    Const COL_GRI_P3_PRO_CODIGO As Integer = 0
    Const COL_GRI_P3_CODIGO As Integer = 1
    Const COL_GRI_P3_NOMBRE As Integer = 2
    Const COL_GRI_P3_COD_BULTO As Integer = 3
    Const COL_GRI_P3_BULTO As Integer = 4
    Const COL_GRI_P3_COD_UBICACION As Integer = 5
    Const COL_GRI_P3_UBICACION As Integer = 6
    Const COL_GRI_P3_PALLET As Integer = 7
    Const COL_GRI_P3_CANTIDAD As Integer = 8
    Const COL_GRI_P3_PROCESO As Integer = 9
    Const COL_GRI_P3_CE As Integer = 10
    Const COL_GRI_P3_PE As Integer = 11
    Const COL_GRI_P3_BOTON As Integer = 12
    Const COL_GRI_P3_FILA As Integer = 13

    Const COL_GRI_P4_PRO_CODIGO As Integer = 0
    Const COL_GRI_P4_SELECCION As Integer = 1
    Const COL_GRI_P4_CODIGO As Integer = 2
    Const COL_GRI_P4_NOMBRE As Integer = 3
    Const COL_GRI_P4_COD_BULTO As Integer = 4
    Const COL_GRI_P4_BULTO As Integer = 5
    Const COL_GRI_P4_CANTIDAD As Integer = 6
    Const COL_GRI_P4_ENCONTRADO As Integer = 7


    Private Sub frm_oden_para_picking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        lblEstado.Visible = False
        dtpCompromisoDesde.Value = CDate("22-08-2019")

        Call CONFIGURA_COLUMNAS()

        '_dab_codigo = 6
        If _dab_codigo > 0 Then
            lblEstado.Visible = True
            TabPage1.Parent = Nothing
            TabPage2.Parent = Nothing
            Call CARGA_ASIGNACION_BUSQUEDA_PICKING()
            Call CARGA_GRILLA_OPERARIO_BODEGA()
            Call CARGA_ASIGNACION_BUSQUEDA_OPERARIO_BODEGA()
            Call CARGA_ASIGNACION_BUSQUEDA_PICKING_PK()

            Call CARGA_ASIGNACION_BUSQUEDA_PICKING_PRODUCTO_BULTO()
            Call CONFIGURA_COLUMNAS_P4()

            Call CARGA_ASIGNACION_BUSQUEDA_PICKING_DETALLE()
            Call CONFIGURA_COLUMNAS_P3()

            If _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.GENERADA Then
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = True
            Else
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = False
            End If
        End If

        Call CONFIGURA_ACCIONES_SEGUN_ESTADOS()

        'Call CONFIGURA_COLUMNAS_P2()
    End Sub

    Private Sub CARGA_ASIGNACION_BUSQUEDA_PICKING()
        Dim classPicking As class_picking = New class_picking
        Dim Fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msg As String

        Try
            ds = Nothing
            classPicking.cnn = _cnn
            classPicking.abp_codigo = _dab_codigo
            _msg = ""
            ds = classPicking.ASIGNACION_BUSQUEDA_PICKING_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("abp_pikasociados") <> "" Then
                        txtNumAsignacion.Text = ds.Tables(0).Rows(Fila)("abp_codigo")
                        txtFecha.Text = ds.Tables(0).Rows(Fila)("abp_fecha")
                        txtNumPK.Text = ds.Tables(0).Rows(Fila)("abp_pikasociados")
                        _abp_estado = ds.Tables(0).Rows(Fila)("abp_estado")
                        If ds.Tables(0).Rows(Fila)("abp_estado") = ESTADO_ORDEN_BUSQUEDA_PICKING.GENERADA Then
                            lblEstado.Text = "GENERADA"
                            btnProcesa.Enabled = True
                        ElseIf ds.Tables(0).Rows(Fila)("abp_estado") = ESTADO_ORDEN_BUSQUEDA_PICKING.PROCESADA Then
                            lblEstado.Text = "PROCESADA"
                            btnProcesa.Enabled = False
                        ElseIf ds.Tables(0).Rows(Fila)("abp_estado") = ESTADO_ORDEN_BUSQUEDA_PICKING.FINALIZADA Then
                            lblEstado.Text = "FINALIZADA"
                            btnProcesa.Enabled = False
                        End If
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_ASIGNACION_BUSQUEDA_PICKING", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_ASIGNACION_BUSQUEDA_PICKING", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_ASIGNACION_BUSQUEDA_OPERARIO_BODEGA()
        Dim classPicking As class_picking = New class_picking
        Dim Fila As Integer = 0
        Dim FilaG As Integer
        Dim ds As DataSet = New DataSet
        Dim _msg As String

        Try
            If GrillaOperario.Rows.Count = 0 Then
                MessageBox.Show("No operarios configurados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ds = Nothing
            classPicking.cnn = _cnn
            classPicking.abp_codigo = _dab_codigo
            _msg = ""

            ds = classPicking.ASIGNACION_BUSQUEDA_PICKING_RESPONSABLE_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("usu_codigo") > 0 Then
                        Fila = 0
                        Do While Fila < ds.Tables(0).Rows.Count
                            FilaG = 0
                            Do While FilaG < GrillaOperario.Rows.Count
                                If GrillaOperario.Rows(FilaG).Cells(0).Value = ds.Tables(0).Rows(Fila)("usu_codigo") Then
                                    GrillaOperario.Rows(FilaG).Cells(1).Value = True
                                End If
                                FilaG = FilaG + 1
                            Loop
                            Fila = Fila + 1
                        Loop
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_ASIGNACION_BUSQUEDA_OPERARIO_BODEGA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_ASIGNACION_BUSQUEDA_OPERARIO_BODEGA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_ASIGNACION_BUSQUEDA_PICKING_PK()
        Dim classPicking As class_picking = New class_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classPicking.cnn = _cnn
            classPicking.abp_codigo = _dab_codigo

            _msg = ""
            GrillaPK.Rows.Clear()
            ds = classPicking.ASIGNACION_BUSQUEDA_PICKING_PK_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pic_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaPK.Rows.Add(ds.Tables(0).Rows(Fila)("pic_codigo"))

                            Fila = Fila + 1
                        Loop
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_ASIGNACION_BUSQUEDA_PICKING_PK", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_ASIGNACION_BUSQUEDA_PICKING_PK", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_ASIGNACION_BUSQUEDA_PICKING_PRODUCTO_BULTO()
        Dim classPicking As class_picking = New class_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classPicking.cnn = _cnn
            classPicking.abp_codigo = _dab_codigo

            _msg = ""
            GrillaProductoBulto.Rows.Clear()
            ds = classPicking.ASIGNACION_BUSQUEDA_PICKING_PRODUCTO_BULTO_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaProductoBulto.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                                         False,
                                                         ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                                         ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                         ds.Tables(0).Rows(Fila)("bul_codigo"),
                                                         ds.Tables(0).Rows(Fila)("bul_codigostr"),
                                                         ds.Tables(0).Rows(Fila)("cantidad_requerida"),
                                                         ds.Tables(0).Rows(Fila)("cantidad_encontrada"))


                            If ds.Tables(0).Rows(Fila)("cantidad_requerida") = ds.Tables(0).Rows(Fila)("cantidad_encontrada") Then
                                Call PINTA_CELDA_VERDE_PRODUCTO_BULTO(Fila)
                            ElseIf ds.Tables(0).Rows(Fila)("cantidad_requerida") > ds.Tables(0).Rows(Fila)("cantidad_encontrada") Then
                                Call PINTA_CELDA_ROJO_PRODUCTO_BULTO(Fila)
                            End If

                            Fila = Fila + 1
                        Loop
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_ASIGNACION_BUSQUEDA_PICKING_PRODUCTO_BULTO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_ASIGNACION_BUSQUEDA_PICKING_PRODUCTO_BULTO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_ASIGNACION_BUSQUEDA_PICKING_DETALLE()
        Dim classPicking As class_picking = New class_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classPicking.cnn = _cnn
            classPicking.abp_codigo = _dab_codigo

            _msg = ""
            grillaUbicaciones.Rows.Clear()
            ds = classPicking.ASIGNACION_BUSQUEDA_PICKING_DETALLE_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaUbicaciones.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                                       ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                                       ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                       ds.Tables(0).Rows(Fila)("cod_bulto"),
                                                       ds.Tables(0).Rows(Fila)("bulto"),
                                                       ds.Tables(0).Rows(Fila)("ubi_codigo"),
                                                       ds.Tables(0).Rows(Fila)("ubi_nombre"),
                                                       ds.Tables(0).Rows(Fila)("pallet"),
                                                       ds.Tables(0).Rows(Fila)("cantidad_en_pallet"),
                                                       ds.Tables(0).Rows(Fila)("preocesada"),
                                                       ds.Tables(0).Rows(Fila)("cantidad_confirmada"), "", "",
                                                       ds.Tables(0).Rows(Fila)("apd_fla"))

                            If ds.Tables(0).Rows(Fila)("preocesada") = True Then
                                grillaUbicaciones.Rows(Fila).Cells(COL_GRI_P3_CE).ReadOnly = True
                            End If

                            If ds.Tables(0).Rows(Fila)("cantidad_en_pallet") <> ds.Tables(0).Rows(Fila)("cantidad_confirmada") Then
                                Call PINTA_CELDA_UBICACIONES(Fila)
                            Else
                                Call PINTA_CELDA_EN_BLANCO_UBICACIONES(Fila)
                            End If

                            Fila = Fila + 1
                        Loop
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_ASIGNACION_BUSQUEDA_PICKING_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_ASIGNACION_BUSQUEDA_PICKING_DETALLE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub CONFIGURA_ACCIONES_SEGUN_ESTADOS()
        Try
            'Estados _eop_codigo: 1: Generada, 2: Procesada, 3: Finalizada
            grillaUbicaciones.Columns(COL_GRI_P3_PE).ReadOnly = False
            grillaUbicaciones.Columns(COL_GRI_P3_BOTON).ReadOnly = False
            If _abp_estado = 0 Then 'Sin generar
                btnGenera.Enabled = True
                btnGuardar.Enabled = False
                btnImprime.Enabled = False
                btnFinaliza.Enabled = False
                btnProcesa.Enabled = False
                btnAprueba.Enabled = False
                btnRechaza.Enabled = False
                'grillaUbicaciones.Columns(COL_GRI_P3_PE).Visible = False
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = False
            ElseIf _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.GENERADA Then 'Generada
                btnGenera.Enabled = False
                btnGuardar.Enabled = True
                btnImprime.Enabled = True
                btnFinaliza.Enabled = False
                btnProcesa.Enabled = True
                btnAprueba.Enabled = False
                btnRechaza.Enabled = False
                'grillaUbicaciones.Columns(COL_GRI_P3_PE).Visible = True
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = True
            ElseIf _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.PROCESADA Then 'Procesada
                btnGenera.Enabled = False
                btnGuardar.Enabled = False
                btnImprime.Enabled = True
                btnFinaliza.Enabled = True
                btnProcesa.Enabled = True
                btnAprueba.Enabled = False
                btnRechaza.Enabled = False
                'grillaUbicaciones.Columns(COL_GRI_P3_PE).Visible = True
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = True
                'grillaUbicaciones.Columns(COL_GRI_P3_PE).ReadOnly = True
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).ReadOnly = True
            ElseIf _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.FINALIZADA Then 'Finalizada
                btnGenera.Enabled = False
                btnGuardar.Enabled = False
                btnImprime.Enabled = True
                btnFinaliza.Enabled = False
                btnProcesa.Enabled = False
                btnAprueba.Enabled = True
                btnRechaza.Enabled = True
                'grillaUbicaciones.Columns(COL_GRI_P3_PE).Visible = True
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = True
                'grillaUbicaciones.Columns(COL_GRI_P3_PE).ReadOnly = True
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).ReadOnly = True
            ElseIf _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.APROBADA Then 'Aprobada
                btnGenera.Enabled = False
                btnGuardar.Enabled = False
                btnImprime.Enabled = True
                btnFinaliza.Enabled = False
                btnProcesa.Enabled = False
                btnAprueba.Enabled = False
                btnRechaza.Enabled = False
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = False
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).ReadOnly = False
            ElseIf _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.RECHAZADA Then 'Rechazada
                btnGenera.Enabled = False
                btnGuardar.Enabled = False
                btnImprime.Enabled = True
                btnFinaliza.Enabled = False
                btnProcesa.Enabled = False
                btnAprueba.Enabled = False
                btnRechaza.Enabled = False
                'grillaUbicaciones.Columns(COL_GRI_P3_PE).Visible = True
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = True
                'grillaUbicaciones.Columns(COL_GRI_P3_PE).ReadOnly = True
                grillaUbicaciones.Columns(COL_GRI_P3_BOTON).ReadOnly = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CONFIGURA_COLUMNAS()
        GrillaConsolidado.Columns(COL_GRI_COD_PICKING).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_SELECCION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_NUM_PICKING).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_FEC_INGRESO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_FEC_COMPROMISO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_HORA_CITA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_CAR_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_CAR_NOMBRE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_DESPACHARA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_TOTAL_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaConsolidado.Columns(COL_GRI_BOTON).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub CONFIGURA_COLUMNAS_P2()
        GrillaProductos.Columns(COL_GRI_P2_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductos.Columns(COL_GRI_P2_SELECCION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductos.Columns(COL_GRI_P2_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductos.Columns(COL_GRI_P2_NOMBRE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductos.Columns(COL_GRI_P2_CANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductos.Columns(COL_GRI_P2_CANTIDAD_PICKEADA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductos.Columns(COL_GRI_P2_CANTIDAD_PENDIENTE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductos.Columns(COL_GRI_P2_CANTIDAD_UBICACION_PK).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductos.Columns(COL_GRI_P2_CANTIDAD_DISPONIBLE_BODEGA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductos.Columns(COL_GRI_P2_OBSERVACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub CONFIGURA_COLUMNAS_P3()
        grillaUbicaciones.Columns(COL_GRI_P3_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_NOMBRE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_COD_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_COD_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_PALLET).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_CANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_PROCESO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_CE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_PE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaUbicaciones.Columns(COL_GRI_P3_BOTON).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub CONFIGURA_COLUMNAS_P4()
        GrillaProductoBulto.Columns(COL_GRI_P4_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductoBulto.Columns(COL_GRI_P4_SELECCION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductoBulto.Columns(COL_GRI_P4_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductoBulto.Columns(COL_GRI_P4_NOMBRE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductoBulto.Columns(COL_GRI_P4_COD_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductoBulto.Columns(COL_GRI_P4_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductoBulto.Columns(COL_GRI_P4_CANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaProductoBulto.Columns(COL_GRI_P4_ENCONTRADO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call CARGA_GRILLA_PK()

        GrillaProductos.DataSource = Nothing
        GrillaProductos.Rows.Clear()

        grillaUbicaciones.DataSource = Nothing
        grillaUbicaciones.Rows.Clear()
    End Sub

    Private Sub CARGA_GRILLA_PK()
        Dim classPicking As class_picking = New class_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Dim diaCompromisoDesde As String = ""
        Dim mesCompromisoDesde As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classPicking.cnn = _cnn


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

            classPicking.fecha_entrega_desde = CStr(dtpCompromisoDesde.Value.Year) + mesCompromisoDesde + diaCompromisoDesde

            _msg = ""
            GrillaConsolidado.Rows.Clear()
            ds = classPicking.PICKING_LISTADO_PARA_ORDEN_ASIGNACION(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaConsolidado.Rows.Add(ds.Tables(0).Rows(Fila)("pic_codigo"), False,
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            ds.Tables(0).Rows(Fila)("pic_fecha"),
                                            ds.Tables(0).Rows(Fila)("fecha_compromiso"),
                                            ds.Tables(0).Rows(Fila)("pic_hora"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("LugarDespacho"),
                                            ds.Tables(0).Rows(Fila)("total_bultos"),
                                            "")


                            Fila = Fila + 1
                        Loop
                        'lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString

                        Call CONFIGURA_COLUMNAS()


                    End If
                End If
                Me.Text = "CONSOLIDADO DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PK", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PK", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        Dim activa_tab As Boolean = True
        Call CARGA_GRILLA_PK_DETALLE(activa_tab)
        Call CONFIGURA_COLUMNAS_P2()
        If activa_tab = True Then
            TabControl1.SelectedIndex = 1
        End If
    End Sub

    Private Sub CARGA_GRILLA_PK_DETALLE(ByRef activa_tab As Boolean)
        Dim classPicking As class_picking = New class_picking
        Dim Seleccionados As String = ""
        Dim Fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msg As String

        Try
            For Each row As DataGridViewRow In Me.GrillaConsolidado.Rows
                If row.Cells(COL_GRI_SELECCION).Value = True Then
                    If Seleccionados = "" Then
                        Seleccionados = CStr(CInt(row.Cells(COL_GRI_NUM_PICKING).Value)).ToString
                    Else
                        Seleccionados = Seleccionados + ", " + CStr(CInt(row.Cells(COL_GRI_NUM_PICKING).Value)).ToString
                    End If

                End If
            Next

            ds = Nothing
            classPicking.cnn = _cnn

            If Seleccionados = "" Then
                MessageBox.Show("Debe seleccionar a lo menos un picking", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                activa_tab = False
                Exit Sub
            End If

            classPicking.strCadena = Seleccionados

            _msg = ""
            GrillaProductos.Rows.Clear()
            ds = classPicking.PICKING_LISTADO_PARA_ORDEN_ASIGNACION_DETALLE(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigointerno") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaProductos.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"), False,
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("cantidad"),
                                            ds.Tables(0).Rows(Fila)("cantidad_pickeada"),
                                            ds.Tables(0).Rows(Fila)("cantidad_pendiente_pickeo"),
                                            ds.Tables(0).Rows(Fila)("cantidad_en_ub_pk"),
                                            ds.Tables(0).Rows(Fila)("cantidad_stock_general"),
                                            ds.Tables(0).Rows(Fila)("mensaje"),
                                            ds.Tables(0).Rows(Fila)("cod_mensaje"))

                            If ds.Tables(0).Rows(Fila)("pro_requiereubicacionpk") = True Then
                                Call PINTA_CELDA_CON_UBICACION_PK(Fila)
                            End If

                            If ds.Tables(0).Rows(Fila)("cod_mensaje") = 3 Then
                                Call PINTA_CELDA_ROJO(Fila)
                            ElseIf ds.Tables(0).Rows(Fila)("cod_mensaje") = 1 Then
                                Call PINTA_CELDA_VERDE(Fila)
                            ElseIf ds.Tables(0).Rows(Fila)("cod_mensaje") = 2 Then
                                Call PINTA_CELDA_NARANJO(Fila)
                            End If
                            Fila = Fila + 1

                        Loop
                        'lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If

                If GrillaProductos.RowCount > 0 Then
                    activa_tab = True
                End If

                Me.Text = "CONSOLIDADO DE PICKING - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PK_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PK_DETALLE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub PINTA_CELDA_CON_UBICACION_PK(ByVal fila As Integer)
        GrillaProductos.Item(COL_GRI_P2_CODIGO, fila).Style.BackColor = Color.Gainsboro
        GrillaProductos.Item(COL_GRI_P2_CODIGO, fila).Style.ForeColor = Color.Black
    End Sub

    Private Sub PINTA_CELDA_ROJO(ByVal fila As Integer)
        GrillaProductos.Item(COL_GRI_P2_OBSERVACION, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        GrillaProductos.Item(COL_GRI_P2_OBSERVACION, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)
    End Sub

    Private Sub PINTA_CELDA_VERDE(ByVal fila As Integer)
        GrillaProductos.Item(COL_GRI_P2_OBSERVACION, fila).Style.BackColor = Color.FromArgb(213, 240, 221)
        GrillaProductos.Item(COL_GRI_P2_OBSERVACION, fila).Style.ForeColor = Color.FromArgb(46, 97, 63)
    End Sub

    Private Sub PINTA_CELDA_NARANJO(ByVal fila As Integer)
        GrillaProductos.Item(COL_GRI_P2_OBSERVACION, fila).Style.BackColor = Color.FromArgb(255, 255, 192)
        GrillaProductos.Item(COL_GRI_P2_OBSERVACION, fila).Style.ForeColor = Color.FromArgb(205, 114, 46)
    End Sub

    Private Sub btnMarcarTodos_Click(sender As Object, e As EventArgs) Handles btnMarcarTodos.Click
        Call MARCAR_TODOS_P1()
    End Sub

    Private Sub MARCAR_TODOS_P1()
        For Each row As DataGridViewRow In Me.GrillaConsolidado.Rows
            row.Cells(COL_GRI_SELECCION).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS_P1()
        For Each row As DataGridViewRow In Me.GrillaConsolidado.Rows
            row.Cells(COL_GRI_SELECCION).Value = False
        Next
    End Sub

    Private Sub btnDesmarcarTodos_Click(sender As Object, e As EventArgs) Handles btnDesmarcarTodos.Click
        Call DESMARCAR_TODOS_P1()
    End Sub

    Private Sub btnMarcarTodosP2_Click(sender As Object, e As EventArgs) Handles btnMarcarTodosP2.Click
        Call MARCAR_TODOS_P2()
    End Sub

    Private Sub MARCAR_TODOS_P2()
        For Each row As DataGridViewRow In Me.GrillaProductos.Rows
            row.Cells(COL_GRI_P2_SELECCION).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS_P2()
        For Each row As DataGridViewRow In Me.GrillaProductos.Rows
            row.Cells(COL_GRI_P2_SELECCION).Value = False
        Next
    End Sub

    Private Sub btnDesmarcarTodos2_Click(sender As Object, e As EventArgs) Handles btnDesmarcarTodos2.Click
        Call DESMARCAR_TODOS_P2()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim contador As Integer
        Dim contadorRojo As Integer
        Dim contadorNaranja As Integer
        Dim respuesta As Integer = 0
        Dim activa_tab As Boolean = True
        Dim contador_ub_pk As Integer = 0

        For Each row As DataGridViewRow In Me.GrillaProductos.Rows
            If row.Cells(COL_GRI_P2_SELECCION).Value = True Then
                If row.Cells(COL_GRI_P2_CANTIDAD_UBICACION_PK).Value = 0 Then
                    contador_ub_pk = contador_ub_pk + 1
                End If
            End If
        Next

        If contador_ub_pk > 0 Then
            MessageBox.Show("Dentro de la selección existen productos con stock 0 en la ubicación de picking, debe abastecer la(s) ubicacion(es)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        contador = 0
        contadorRojo = 0
        contadorNaranja = 0
        For Each row As DataGridViewRow In Me.GrillaProductos.Rows
            If row.Cells(COL_GRI_P2_SELECCION).Value = True Then
                contador = contador + 1

                If row.Cells(COL_GRI_P2_COD_OBSERVACION).Value = 3 Then
                    contadorRojo = contadorRojo + 1
                End If

                If row.Cells(COL_GRI_P2_COD_OBSERVACION).Value = 2 Then
                    contadorNaranja = contadorNaranja + 1
                End If

            End If
        Next

        If contador = 0 Then
            MessageBox.Show("Debe seleccionar a lo menos un producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If contadorRojo > 0 Then
            MessageBox.Show("Dentro de la seleccion existen productos (EN ROJO) que no cuentan con stock disponible", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If contadorNaranja > 0 Then
            respuesta = MessageBox.Show("Dentro de la seleccion existen productos (EN NARANJA) que no cuentan con stock suficiente para cumplir con lo requerido" _
                            + Chr(10) + "¿desea continuar con la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = vbNo Then
                Exit Sub
            End If
        End If

        txtNumPK.Text = OBTIENE_NUMEROS_DE_PK_EN_OPERACION()
        Call CARGA_GRILLA_OPERARIO_BODEGA()
        Call CARGA_GRILLA_UBICACIONES(activa_tab)

        Call CONFIGURA_COLUMNAS_P4()
        Call CONFIGURA_COLUMNAS_P3()
        If activa_tab = True Then
            TabControl1.SelectedIndex = 2
        End If

    End Sub

    Private Sub CARGA_GRILLA_OPERARIO_BODEGA()
        Dim classUsuario As class_usuario = New class_usuario
        Dim Fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msg As String

        Try
            ds = Nothing
            classUsuario.cnn = _cnn
            _msg = ""
            GrillaOperario.DataSource = Nothing
            GrillaOperario.Rows.Clear()
            ds = classUsuario.CARGA_OPERARIOS_BODEGA(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaOperario.Rows.Add(ds.Tables(0).Rows(Fila)("codigo"), False,
                                            ds.Tables(0).Rows(Fila)("nombre"))

                            Fila = Fila + 1

                        Loop
                        'lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_OPERARIO_BODEGA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_OPERARIO_BODEGA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Function OBTIENE_NUMEROS_DE_PK_EN_OPERACION() As String
        Dim classPiking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msg As String = ""
        Dim SelPicking As String = ""
        Dim SelProducto As String = ""
        Dim Fila As Integer = 0

        Dim CadenaPK As String = ""

        Try
            For Each row As DataGridViewRow In Me.GrillaConsolidado.Rows
                If row.Cells(COL_GRI_SELECCION).Value = True Then
                    If SelPicking = "" Then
                        SelPicking = row.Cells(COL_GRI_COD_PICKING).Value.ToString + ","
                    Else
                        SelPicking = SelPicking + row.Cells(COL_GRI_COD_PICKING).Value.ToString + ","
                    End If
                End If
            Next

            For Each row As DataGridViewRow In Me.GrillaProductos.Rows
                If row.Cells(COL_GRI_P2_SELECCION).Value = True Then
                    If SelProducto = "" Then
                        SelProducto = row.Cells(COL_GRI_P2_PRO_CODIGO).Value.ToString + ","
                    Else
                        SelProducto = SelProducto + row.Cells(COL_GRI_P2_PRO_CODIGO).Value.ToString + ","
                    End If
                End If
            Next

            GrillaPK.DataSource = Nothing
            GrillaPK.Rows.Clear()
            ds = Nothing
            classPiking.cnn = _cnn
            classPiking.StrCadenaPK = SelPicking
            classPiking.StrProductosPK = SelProducto
            ds = classPiking.SELECCIONA_PK_ASIGNACION_BUSQUEDA(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pic_codigo") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaPK.Rows.Add(CLng(ds.Tables(0).Rows(Fila)("pic_codigo")))
                            If CadenaPK = "" Then
                                CadenaPK = ds.Tables(0).Rows(Fila)("pic_codigo")
                            Else
                                CadenaPK = CadenaPK + " | " + ds.Tables(0).Rows(Fila)("pic_codigo")
                            End If
                            Fila = Fila + 1
                        Loop

                    End If
                End If
            End If

            OBTIENE_NUMEROS_DE_PK_EN_OPERACION = CadenaPK
        Catch ex As Exception
            OBTIENE_NUMEROS_DE_PK_EN_OPERACION = ""
            MsgBox(ex.Message + " " + "OBTIENE_NUMEROS_DE_PK_EN_OPERACION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Function


    Private Sub GrillaConsolidado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaConsolidado.CellContentClick
        Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaConsolidado.Rows(e.RowIndex).Cells(COL_GRI_SELECCION)
        If e.ColumnIndex = Me.GrillaConsolidado.Columns.Item(COL_GRI_SELECCION).Index Then
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub GrillaProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaProductos.CellContentClick
        Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaProductos.Rows(e.RowIndex).Cells(COL_GRI_P2_SELECCION)
        If e.ColumnIndex = Me.GrillaProductos.Columns.Item(COL_GRI_P2_SELECCION).Index Then
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub CARGA_GRILLA_BULTOS()
        Dim classPicking As class_picking = New class_picking
        Dim classProductos As class_producto = New class_producto
        Dim Seleccionados As String = ""
        Dim Fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msg As String
        Dim cantBultos As Integer = 0
        Dim bulto As Integer = 1

        Try

            ds = Nothing
            classPicking.cnn = _cnn
            GrillaProductoBulto.Rows.Clear()
            For Each row As DataGridViewRow In Me.GrillaProductos.Rows
                If row.Cells(COL_GRI_P2_SELECCION).Value = True Then
                    cantBultos = 0
                    classPicking.cnn = _cnn
                    classPicking.pro_codigo = row.Cells(COL_GRI_P2_PRO_CODIGO).Value
                    _msg = ""
                    ds = classPicking.PICKING_OBTIENE_PRODUCTO_BULTO_PARA_PIKEO(_msg)
                    If _msg = "" Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            If ds.Tables(0).Rows(0)("bul_str") <> "" Then
                                Fila = 0
                                Do While Fila < ds.Tables(0).Rows.Count
                                    GrillaProductoBulto.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"), False,
                                                               ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                                               ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                               ds.Tables(0).Rows(Fila)("bul_codigo"),
                                                               ds.Tables(0).Rows(Fila)("bul_str"),
                                                               row.Cells(COL_GRI_P2_CANTIDAD_PENDIENTE).Value,
                                                               0)
                                    Fila = Fila + 1
                                Loop
                            End If
                        End If
                    End If
                    ds = Nothing

                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_BULTOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_UBICACIONES(ByRef activa_tab As Boolean)
        Dim classPicking As class_picking = New class_picking
        Dim classProductos As class_producto = New class_producto
        Dim Seleccionados As String = ""
        Dim Fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msg As String
        Dim cantBultos As Integer = 0
        Dim bulto As Integer = 1

        Try
            activa_tab = False
            ds = Nothing
            classPicking.cnn = _cnn
            grillaUbicaciones.Rows.Clear()
            For Each row As DataGridViewRow In Me.GrillaProductos.Rows
                If row.Cells(COL_GRI_P2_SELECCION).Value = True Then
                    cantBultos = 0
                    classProductos.cnn = _cnn
                    classProductos.pro_codigo = 0
                    classProductos.todos = 1
                    classProductos.codigo_interno = row.Cells(COL_GRI_P2_CODIGO).Value
                    classProductos.cat_codigo = 0
                    classProductos.sub_codigo = 0
                    classProductos.pro_config = 0
                    _msg = ""
                    ds = classProductos.PRODUCTOS_LISTADO(_msg)
                    If _msg = "" Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            cantBultos = ds.Tables(0).Rows(0)("pro_numbultos")
                        End If
                    End If
                    ds = Nothing
                    bulto = 1
                    Do While bulto <= cantBultos
                        classPicking.cnn = _cnn
                        classPicking.pro_codigo = row.Cells(COL_GRI_P2_PRO_CODIGO).Value
                        classPicking.bul_codigo = bulto
                        classPicking.cantidad = row.Cells(COL_GRI_P2_CANTIDAD_PENDIENTE).Value

                        ds = classPicking.PICKING_OBTIENE_POSICIONES_PARA_ORDEN_ASIGNACION(_msg)
                        If _msg = "" Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                If ds.Tables(0).Rows(0)("pro_codigointerno") <> "" Then
                                    Fila = 0
                                    Do While Fila < ds.Tables(0).Rows.Count
                                        grillaUbicaciones.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                                                   ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                                                   ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                                   ds.Tables(0).Rows(Fila)("bul_codigo"),
                                                                   ds.Tables(0).Rows(Fila)("bul_strcodigo"),
                                                                   ds.Tables(0).Rows(Fila)("ubi_codigo"),
                                                                   ds.Tables(0).Rows(Fila)("ubi_nombre"),
                                                                   ds.Tables(0).Rows(Fila)("pallet"),
                                                                   ds.Tables(0).Rows(Fila)("cantidad"),
                                                                   False,
                                                                   0)
                                        Fila = Fila + 1
                                    Loop
                                End If
                            End If
                        Else
                            MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        bulto = bulto + 1
                    Loop
                End If
            Next
            Call CARGA_GRILLA_BULTOS()

            If grillaUbicaciones.RowCount > 0 Then
                activa_tab = True
            End If

        Catch ex As Exception
            activa_tab = False
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PK_DETALLE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub GrillaOperario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaOperario.CellContentClick
        Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaOperario.Rows(e.RowIndex).Cells(1)
        If e.ColumnIndex = Me.GrillaOperario.Columns.Item(1).Index Then
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub GrillaProductoBulto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaProductoBulto.CellContentClick
        Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaProductoBulto.Rows(e.RowIndex).Cells(COL_GRI_P4_SELECCION)
        If e.ColumnIndex = Me.GrillaProductoBulto.Columns.Item(COL_GRI_P4_SELECCION).Index Then
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub btnGenera_Click(sender As Object, e As EventArgs) Handles btnGenera.Click
        If VALIDA_DATOS_ASIGNACION() = False Then
            Exit Sub
        End If
        Call GENERA_ORDEN_ABASTECIMIENTO()
        Call CONFIGURA_ACCIONES_SEGUN_ESTADOS()
        _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.GENERADA
        Me.Dispose()
    End Sub

    Private Function VALIDA_DATOS_ASIGNACION() As Boolean
        Dim Contador As Integer = 0
        VALIDA_DATOS_ASIGNACION = False

        Try
            'VALIDA QUE EXISTAN OPERARIOS
            '---------------------------------------------------------
            If Me.GrillaOperario.Rows.Count = 0 Then
                MessageBox.Show("No existen operarios para seleccionar, debe configurarlos en el maestro de usuarios", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Function
            End If

            'VALIDA OPERARIOS SELECCIONADOS
            '---------------------------------------------------------
            Contador = 0
            For Each row2 As DataGridViewRow In Me.GrillaOperario.Rows
                If row2.Cells(1).Value = True Then
                    Contador = Contador + 1
                End If
            Next

            If Contador = 0 Then
                MessageBox.Show("Debe seleccionar a lo menos un operario ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Function
            End If

            'VALIDA QUE EXISTAN PRODUCTO BULTO
            '--------------------------------------------------------
            If Me.GrillaProductoBulto.Rows.Count = 0 Then
                MessageBox.Show("No existen productos/bultos para seleccionar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Function
            End If

            'VALIDA QUE EXISTAN UBICACIONES
            '--------------------------------------------------------
            If Me.grillaUbicaciones.Rows.Count = 0 Then
                MessageBox.Show("No existen ubicaciones propuestas para generar el documento de asignación de busqueda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Function
            End If

            VALIDA_DATOS_ASIGNACION = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GENERA_ORDEN_ABASTECIMIENTO() As Boolean
        Dim classPicking As class_picking = New class_picking
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
                classPicking.cnn = _cnn

                _msgError = ""
                If GUARDA_ORDEN_BUSQUEDA_PICKING_ENCABEZADO(ESTADO_ORDEN_BUSQUEDA_PICKING.GENERADA, conexion) = False Then
                    txtNumAsignacion.Text = 0
                    Exit Function
                Else

                    If GUARDA_ORDEN_BUSQUEDA_PICKING__DETALLE(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        txtNumAsignacion.Text = 0
                        ds = Nothing
                        Me.Cursor = Cursors.Default
                        Exit Function
                    End If

                    If GUARDA_ORDEN_PICKING_PICKING(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        txtNumAsignacion.Text = 0
                        Me.Cursor = Cursors.Default
                        Exit Function
                    End If

                    If GUARDA_ORDEN_RESPONSABLE_PICKING(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        txtNumAsignacion.Text = 0
                        ds = Nothing
                        Me.Cursor = Cursors.Default
                        Exit Function
                    End If

                    If GUARDA_ORDEN_PRODUCTO_BULTO_PICKING(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        txtNumAsignacion.Text = 0
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
                _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.GENERADA
                If _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.GENERADA Then
                    grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = True
                Else
                    grillaUbicaciones.Columns(COL_GRI_P3_BOTON).Visible = False
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default

                MessageBox.Show("Orden de busqueda de pickeo generada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GUARDA_ORDEN_PRODUCTO_BULTO_PICKING(ByVal conexion As SqlConnection) As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        GUARDA_ORDEN_PRODUCTO_BULTO_PICKING = False
        Try
            For Each row2 As DataGridViewRow In Me.GrillaProductoBulto.Rows

                classPicking.abp_codigo = _dab_codigo
                classPicking.pro_codigo = row2.Cells(COL_GRI_P4_PRO_CODIGO).Value
                classPicking.pro_codigointerno = row2.Cells(COL_GRI_P4_CODIGO).Value
                classPicking.pro_nombre = row2.Cells(COL_GRI_P4_NOMBRE).Value
                classPicking.bul_codigo = row2.Cells(COL_GRI_P4_COD_BULTO).Value
                classPicking.bulto = row2.Cells(COL_GRI_P4_BULTO).Value
                classPicking.cantidad_requerida = row2.Cells(COL_GRI_P4_CANTIDAD).Value
                classPicking.cantidad_confirmada = row2.Cells(COL_GRI_P4_ENCONTRADO).Value
                ds = classPicking.ASIGNACION_BUSQUEDA_PK_PRODUCTOS_BULTOS_GUARDAR(_msgError, conexion)
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

            GUARDA_ORDEN_PRODUCTO_BULTO_PICKING = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GUARDA_ORDEN_RESPONSABLE_PICKING(ByVal conexion As SqlConnection) As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        GUARDA_ORDEN_RESPONSABLE_PICKING = False
        Try
            'ELIMINA OPERADORES ASOCIADOS
            classPicking.abp_codigo = _dab_codigo
            ds = classPicking.ASIGNACION_BUSQUEDA_PK_RESPONSABLE_ELIMINA(_msgError, conexion)
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

            'GUARDA OPERADORES SELECCIONADOS
            For Each row2 As DataGridViewRow In Me.GrillaOperario.Rows
                ds = Nothing
                If row2.Cells(1).Value = True Then
                    classPicking.abp_codigo = _dab_codigo
                    classPicking.usu_codigo = row2.Cells(0).Value
                    ds = classPicking.ASIGNACION_BUSQUEDA_PK_RESPONSABLE_GUARDAR(_msgError, conexion)
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

            GUARDA_ORDEN_RESPONSABLE_PICKING = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GUARDA_ORDEN_PICKING_PICKING(ByVal conexion As SqlConnection) As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        GUARDA_ORDEN_PICKING_PICKING = False
        Try
            'ELIMINA PICKING ASOCIADOS
            classPicking.abp_codigo = _dab_codigo
            ds = classPicking.ASIGNACION_BUSQUEDA_PK_PK_ELIMINA(_msgError, conexion)
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

            'GUARDA PK SELECCIONADOS
            For Each row2 As DataGridViewRow In Me.GrillaPK.Rows
                ds = Nothing

                classPicking.abp_codigo = _dab_codigo
                classPicking.pic_codigo = row2.Cells(0).Value
                ds = classPicking.ASIGNACION_BUSQUEDA_PK_PK_GUARDAR(_msgError, conexion)
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

            GUARDA_ORDEN_PICKING_PICKING = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GUARDA_ORDEN_BUSQUEDA_PICKING__DETALLE(ByVal conexion As SqlConnection) As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        GUARDA_ORDEN_BUSQUEDA_PICKING__DETALLE = False
        Try
            For Each row2 As DataGridViewRow In Me.grillaUbicaciones.Rows
                classPicking.abp_codigo = _dab_codigo
                classPicking.apd_fila = row2.Cells(COL_GRI_P3_FILA).Value
                classPicking.pro_codigo = row2.Cells(COL_GRI_P3_PRO_CODIGO).Value
                classPicking.pro_codigointerno = row2.Cells(COL_GRI_P3_CODIGO).Value
                classPicking.pro_nombre = row2.Cells(COL_GRI_P3_NOMBRE).Value
                classPicking.cantidad_requerida = row2.Cells(COL_GRI_P3_CANTIDAD).Value
                classPicking.cod_bulto = row2.Cells(COL_GRI_P3_COD_BULTO).Value
                classPicking.bulto = row2.Cells(COL_GRI_P3_BULTO).Value
                classPicking.ubi_codigo = row2.Cells(COL_GRI_P3_COD_UBICACION).Value
                classPicking.ubi_nombre = row2.Cells(COL_GRI_P3_UBICACION).Value
                classPicking.pallet = row2.Cells(COL_GRI_P3_PALLET).Value
                classPicking.cantidad_en_pallet = row2.Cells(COL_GRI_P3_CANTIDAD).Value
                classPicking.preocesada = row2.Cells(COL_GRI_P3_PROCESO).Value
                classPicking.cantidad_confirmada = row2.Cells(COL_GRI_P3_CE).Value

                ds = classPicking.ASIGNACION_BUSQUEDA_PK_DET_GUARDAR(_msgError, conexion)
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

            GUARDA_ORDEN_BUSQUEDA_PICKING__DETALLE = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GUARDA_ORDEN_BUSQUEDA_PICKING_ENCABEZADO(ByVal codEstadoOrden As Integer, ByVal conexion As SqlConnection) As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        GUARDA_ORDEN_BUSQUEDA_PICKING_ENCABEZADO = False

        Try
            'Guarda cabecera del documento
            ds = Nothing
            classPicking.abp_codigo = _dab_codigo
            classPicking.abp_fecha = txtFecha.Value
            classPicking.abp_pikasociados = txtNumPK.Text
            classPicking.abp_estado = codEstadoOrden

            ds = classPicking.ASIGNACION_BUSQUEDA_PK_ENC_GUARDAR(_msgError, conexion)
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
                    txtNumAsignacion.Text = ds.Tables(0).Rows(0)("CODIGO")
                    _dab_codigo = ds.Tables(0).Rows(0)("CODIGO")
                End If
            End If

            GUARDA_ORDEN_BUSQUEDA_PICKING_ENCABEZADO = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GUARDA_ORDEN_BUSQUEDA_PICKING_DETALLE_ACTUALIZA(ByVal conexion As SqlConnection) As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        GUARDA_ORDEN_BUSQUEDA_PICKING_DETALLE_ACTUALIZA = False
        Try
            For Each row2 As DataGridViewRow In Me.grillaUbicaciones.Rows
                classPicking.abp_codigo = _dab_codigo
                classPicking.apd_fila = row2.Cells(COL_GRI_P3_FILA).Value
                classPicking.cantidad_confirmada = row2.Cells(COL_GRI_P3_CE).Value

                ds = classPicking.ASIGNACION_BUSQUEDA_PK_DET_ACTUALIZA_CANTIDAD(_msgError, conexion)
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

            GUARDA_ORDEN_BUSQUEDA_PICKING_DETALLE_ACTUALIZA = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function GUARDA_ORDEN_BUSQUEDA_PICKING_PRODUCTO_BULTO_ACTUALIZA(ByVal conexion As SqlConnection) As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        GUARDA_ORDEN_BUSQUEDA_PICKING_PRODUCTO_BULTO_ACTUALIZA = False
        Try
            For Each row2 As DataGridViewRow In Me.GrillaProductoBulto.Rows
                classPicking.abp_codigo = _dab_codigo
                classPicking.pro_codigo = row2.Cells(COL_GRI_P4_PRO_CODIGO).Value
                classPicking.bul_codigo = row2.Cells(COL_GRI_P4_COD_BULTO).Value
                classPicking.cantidad_confirmada = row2.Cells(COL_GRI_P4_ENCONTRADO).Value

                ds = classPicking.ASIGNACION_BUSQUEDA_PICKING_PRODUCTO_BULTO_ACTUALIZA_CANTIDAD(_msgError, conexion)
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

            GUARDA_ORDEN_BUSQUEDA_PICKING_PRODUCTO_BULTO_ACTUALIZA = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function ACTUALIZA_ESTADO_ORDEN_ASIGNACION_BUSQUEDA(ByVal conexion As SqlConnection, ByVal codigoEstado As Integer) As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        ACTUALIZA_ESTADO_ORDEN_ASIGNACION_BUSQUEDA = False
        Try
            classPicking.abp_codigo = _dab_codigo
            classPicking.abp_estado = codigoEstado

            ds = classPicking.ASIGNACION_BUSQUEDA_PICKING_ACTUALIZA_ESTADO(_msgError, conexion)
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

            ACTUALIZA_ESTADO_ORDEN_ASIGNACION_BUSQUEDA = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function PROCESA_ASIGNACION_PARA_PICKING(ByVal conexion As SqlConnection, ByVal codigoEstado As Integer) As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        PROCESA_ASIGNACION_PARA_PICKING = False
        Try
            classPicking.abp_codigo = _dab_codigo
            classPicking.abp_estado = codigoEstado

            ds = Nothing
            ds = classPicking.ASIGNACION_PROCESA_PICKING(_msgError, conexion)
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

            classPicking.abp_codigo = _dab_codigo
            ds = Nothing
            ds = classPicking.ASIGNACION_PROCESA_PICKING_DISPONIBILIZA_UBICACIONES(_msgError, conexion)
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
            ds = classPicking.ASIGNACION_BUSQUEDA_PICKING_ACTUALIZA_ESTADO(_msgError, conexion)
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

            PROCESA_ASIGNACION_PARA_PICKING = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If GUARDA_ORDEN_ABASTECIMIENTO() = False Then
            Exit Sub
        End If
    End Sub

    Private Function GUARDA_ORDEN_ABASTECIMIENTO() As Boolean
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        GUARDA_ORDEN_ABASTECIMIENTO = False

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classPicking.cnn = _cnn

                If GUARDA_ORDEN_BUSQUEDA_PICKING_DETALLE_ACTUALIZA(conexion) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Function
                End If

                GUARDA_ORDEN_ABASTECIMIENTO = True
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                ds = Nothing
                Me.Cursor = Cursors.Default

                MessageBox.Show("Orden de busqueda de pickeo guardada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub grillaUbicaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaUbicaciones.CellContentClick
        If e.ColumnIndex = Me.grillaUbicaciones.Columns.Item(COL_GRI_P3_BOTON).Index Then
            Dim frm As frm_movimiento_de_pallet = New frm_movimiento_de_pallet
            GLO_ACCION_EJECUTADA = False
            frm.cnn = _cnn
            frm.bod_codigo = BODEGAS.BOD_PRODUCTO_TERMINADO
            frm.ubi_codigo = UBICACION.PISO_PRODUCTO_TERMINADO
            frm.procedencia = "PIK"
            frm.ubicacion_actual = grillaUbicaciones.Rows(e.RowIndex).Cells(COL_GRI_P3_UBICACION).Value
            frm.palletRequerido = grillaUbicaciones.Rows(e.RowIndex).Cells(COL_GRI_P3_PALLET).Value
            frm.ShowDialog()

            If GLO_ACCION_EJECUTADA = True Then
                grillaUbicaciones.Rows(e.RowIndex).Cells(COL_GRI_P3_PROCESO).Value = 1
                grillaUbicaciones.Rows(e.RowIndex).Cells(COL_GRI_P3_CE).ReadOnly = True
                GLO_ACCION_EJECUTADA = False
            End If

        End If
    End Sub

    Private Sub grillaUbicaciones_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grillaUbicaciones.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        PrecionaTeclaDesde = "grillaUbicaciones"
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim columna As Integer
        Dim fila As Integer

        Try
            Select Case keyData
                Case Keys.Escape

                    ' No hacemos nada porque se supone

                    ' que la tecla Escape cancela la acción.

                Case Keys.Enter 'Or Keys.Down Or Keys.Up Or Keys.Left Or Keys.Right

                    'If GrillaFinanciamiento.Focus = True Then
                    If PrecionaTeclaDesde = "grillaUbicaciones" Then

                        columna = grillaUbicaciones.CurrentCell.ColumnIndex
                        fila = grillaUbicaciones.CurrentCell.RowIndex

                        If columna = COL_GRI_P3_CE Then
                            If (cellTextBox IsNot Nothing) Then
                                With grillaUbicaciones
                                    If ((.CurrentCell.RowIndex + 1) < .Rows.Count) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                                    End If
                                End With
                            End If

                            If grillaUbicaciones.Rows(fila).Cells(COL_GRI_P3_CE).Value.ToString = "" Then
                                grillaUbicaciones.Rows(fila).Cells(COL_GRI_P3_CE).Value = "0"
                            End If

                        End If
                    End If

                    PrecionaTeclaDesde = ""
                Case Else

                    Return MyBase.ProcessCmdKey(msg, keyData)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = grillaUbicaciones.CurrentCell.ColumnIndex
        Dim fila As Integer = grillaUbicaciones.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = COL_GRI_P3_CE) Then
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

    Private Sub btnProcesa_Click(sender As Object, e As EventArgs) Handles btnProcesa.Click
        Call PROCESAR()
        Call CONFIGURA_ACCIONES_SEGUN_ESTADOS()
        _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.PROCESADA
    End Sub

    Private Sub PROCESAR()
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        Dim varProCodigo As Integer = 0
        Dim varBulCodigo As Integer = 0
        Dim varSumaCant As Integer = 0

        Dim Fila As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each row As DataGridViewRow In Me.grillaUbicaciones.Rows
                If row.Cells(COL_GRI_P3_CANTIDAD).Value <> row.Cells(COL_GRI_P3_CE).Value Then
                    Call PINTA_CELDA_UBICACIONES(Fila)
                Else
                    PINTA_CELDA_EN_BLANCO_UBICACIONES(Fila)
                End If
                Fila = Fila + 1
            Next

            Fila = 0
            For Each row As DataGridViewRow In Me.GrillaProductoBulto.Rows
                varProCodigo = row.Cells(COL_GRI_P4_PRO_CODIGO).Value
                varBulCodigo = row.Cells(COL_GRI_P4_COD_BULTO).Value
                varSumaCant = 0
                For Each row2 As DataGridViewRow In Me.grillaUbicaciones.Rows
                    If row2.Cells(COL_GRI_P3_PRO_CODIGO).Value = varProCodigo And row2.Cells(COL_GRI_P3_COD_BULTO).Value = varBulCodigo Then
                        If row2.Cells(COL_GRI_P3_PROCESO).Value = 0 Then
                            varSumaCant = varSumaCant + row2.Cells(COL_GRI_P3_CE).Value
                        End If
                    End If
                Next
                row.Cells(COL_GRI_P4_ENCONTRADO).Value = varSumaCant

                If row.Cells(COL_GRI_P4_CANTIDAD).Value = row.Cells(COL_GRI_P4_ENCONTRADO).Value Then
                    Call PINTA_CELDA_VERDE_PRODUCTO_BULTO(Fila)
                ElseIf row.Cells(COL_GRI_P4_CANTIDAD).Value > row.Cells(COL_GRI_P4_ENCONTRADO).Value Then
                    Call PINTA_CELDA_ROJO_PRODUCTO_BULTO(Fila)
                End If

                Fila = Fila + 1
            Next

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classPicking.cnn = _cnn

                If GUARDA_ORDEN_BUSQUEDA_PICKING__DETALLE(conexion) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    txtNumAsignacion.Text = 0
                    ds = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                'If GUARDA_ORDEN_BUSQUEDA_PICKING_DETALLE_ACTUALIZA(conexion) = False Then
                '    If conexion.State = ConnectionState.Open Then
                '        conexion.Close()
                '    End If
                '    ds = Nothing
                '    Me.Cursor = Cursors.Default
                '    Exit Sub
                'End If

                If GUARDA_ORDEN_BUSQUEDA_PICKING_PRODUCTO_BULTO_ACTUALIZA(conexion) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                If ACTUALIZA_ESTADO_ORDEN_ASIGNACION_BUSQUEDA(conexion, ESTADO_ORDEN_BUSQUEDA_PICKING.PROCESADA) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    lblEstado.Visible = True
                    lblEstado.Text = "EN PROCESO"
                    _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.PROCESADA
                End If


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                ds = Nothing
                Me.Cursor = Cursors.Default

                MessageBox.Show("Orden de busqueda de pickeo guardada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PINTA_CELDA_ROJO_PRODUCTO_BULTO(ByVal fila As Integer)
        GrillaProductoBulto.Item(COL_GRI_P4_SELECCION, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        GrillaProductoBulto.Item(COL_GRI_P4_SELECCION, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        GrillaProductoBulto.Item(COL_GRI_P4_CODIGO, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        GrillaProductoBulto.Item(COL_GRI_P4_CODIGO, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        GrillaProductoBulto.Item(COL_GRI_P4_NOMBRE, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        GrillaProductoBulto.Item(COL_GRI_P4_NOMBRE, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        GrillaProductoBulto.Item(COL_GRI_P4_BULTO, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        GrillaProductoBulto.Item(COL_GRI_P4_BULTO, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        GrillaProductoBulto.Item(COL_GRI_P4_CANTIDAD, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        GrillaProductoBulto.Item(COL_GRI_P4_CANTIDAD, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        GrillaProductoBulto.Item(COL_GRI_P4_ENCONTRADO, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        GrillaProductoBulto.Item(COL_GRI_P4_ENCONTRADO, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)
    End Sub

    Private Sub PINTA_CELDA_UBICACIONES(ByVal fila As Integer)
        grillaUbicaciones.Item(COL_GRI_P3_CANTIDAD, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        grillaUbicaciones.Item(COL_GRI_P3_CANTIDAD, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

        grillaUbicaciones.Item(COL_GRI_P3_CE, fila).Style.BackColor = Color.FromArgb(255, 214, 214)
        grillaUbicaciones.Item(COL_GRI_P3_CE, fila).Style.ForeColor = Color.FromArgb(253, 49, 49)
    End Sub

    Private Sub PINTA_CELDA_EN_BLANCO_UBICACIONES(ByVal fila As Integer)
        grillaUbicaciones.Item(COL_GRI_P3_CANTIDAD, fila).Style.BackColor = Color.White
        grillaUbicaciones.Item(COL_GRI_P3_CANTIDAD, fila).Style.ForeColor = Color.Black

        grillaUbicaciones.Item(COL_GRI_P3_CE, fila).Style.BackColor = Color.White
        grillaUbicaciones.Item(COL_GRI_P3_CE, fila).Style.ForeColor = Color.Black
    End Sub


    Private Sub PINTA_CELDA_VERDE_PRODUCTO_BULTO(ByVal fila As Integer)
        GrillaProductoBulto.Item(COL_GRI_P4_SELECCION, fila).Style.BackColor = Color.FromArgb(213, 240, 221)
        GrillaProductoBulto.Item(COL_GRI_P4_SELECCION, fila).Style.ForeColor = Color.FromArgb(46, 97, 63)

        GrillaProductoBulto.Item(COL_GRI_P4_CODIGO, fila).Style.BackColor = Color.FromArgb(213, 240, 221)
        GrillaProductoBulto.Item(COL_GRI_P4_CODIGO, fila).Style.ForeColor = Color.FromArgb(46, 97, 63)

        GrillaProductoBulto.Item(COL_GRI_P4_NOMBRE, fila).Style.BackColor = Color.FromArgb(213, 240, 221)
        GrillaProductoBulto.Item(COL_GRI_P4_NOMBRE, fila).Style.ForeColor = Color.FromArgb(46, 97, 63)

        GrillaProductoBulto.Item(COL_GRI_P4_BULTO, fila).Style.BackColor = Color.FromArgb(213, 240, 221)
        GrillaProductoBulto.Item(COL_GRI_P4_BULTO, fila).Style.ForeColor = Color.FromArgb(46, 97, 63)

        GrillaProductoBulto.Item(COL_GRI_P4_CANTIDAD, fila).Style.BackColor = Color.FromArgb(213, 240, 221)
        GrillaProductoBulto.Item(COL_GRI_P4_CANTIDAD, fila).Style.ForeColor = Color.FromArgb(46, 97, 63)

        GrillaProductoBulto.Item(COL_GRI_P4_ENCONTRADO, fila).Style.BackColor = Color.FromArgb(213, 240, 221)
        GrillaProductoBulto.Item(COL_GRI_P4_ENCONTRADO, fila).Style.ForeColor = Color.FromArgb(46, 97, 63)
    End Sub

    Private Sub btnFinaliza_Click(sender As Object, e As EventArgs) Handles btnFinaliza.Click
        Dim respuesta As Integer = 0

        respuesta = MessageBox.Show("¿Esta seguro(a) de finalizar la asignación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = vbNo Then
            Exit Sub
        End If

        Call FINALIZA_ORDEN()
        Call CONFIGURA_ACCIONES_SEGUN_ESTADOS()
        _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.FINALIZADA
        Me.Dispose()
    End Sub

    Private Sub FINALIZA_ORDEN()
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        Dim varProCodigo As Integer = 0
        Dim varBulCodigo As Integer = 0
        Dim varSumaCant As Integer = 0

        Dim Fila As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor


            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classPicking.cnn = _cnn

                If ACTUALIZA_ESTADO_ORDEN_ASIGNACION_BUSQUEDA(conexion, ESTADO_ORDEN_BUSQUEDA_PICKING.FINALIZADA) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    lblEstado.Visible = True
                    lblEstado.Text = "FINALIZADA"
                    _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.FINALIZADA
                End If


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                ds = Nothing
                Me.Cursor = Cursors.Default

                MessageBox.Show("Orden de busqueda de pickeo guardada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerarNuevaBusquedaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarNuevaBusquedaToolStripMenuItem.Click
        Dim CantidadProcesada As Integer = 0
        Dim sumCantidadEnPallet As Integer = 0
        Dim sumCantidadEncontrada As Integer = 0
        Dim varProCodigo As Integer = 0
        Dim varBulCodigo As Integer = 0

        Try
            Call NUEVA_BUSQUEDA()

            'varProCodigo = GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_PRO_CODIGO).Value
            'varBulCodigo = GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_COD_BULTO).Value

            'For Each row2 As DataGridViewRow In Me.grillaUbicaciones.Rows
            '    If row2.Cells(COL_GRI_P3_PRO_CODIGO).Value = varProCodigo And row2.Cells(COL_GRI_P3_COD_BULTO).Value = varBulCodigo Then
            '        sumCantidadEnPallet = sumCantidadEnPallet + row2.Cells(COL_GRI_P3_CANTIDAD).Value
            '        sumCantidadEncontrada = sumCantidadEncontrada + row2.Cells(COL_GRI_P3_CE).Value
            '    End If
            'Next

            'CantidadProcesada = OBTIENE_CANTIDAD_PROCESADA_EN_ORDEN()
            'If CantidadProcesada = (grillaUbicaciones.RowCount - 1) Then
            '    MessageBox.Show("No existen mas ubicaciones disponibles para la orden seleccionada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            Call VULEVE_A_PROCESO()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function OBTIENE_CANTIDAD_PROCESADA_EN_ORDEN() As Integer
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet

        OBTIENE_CANTIDAD_PROCESADA_EN_ORDEN = 0
        Try
            classPicking.cnn = _cnn
            classPicking.abp_codigo = _dab_codigo
            ds = classPicking.OBTIENE_CANTIDAD_FILAS_PROCESADAS_EN_PICKING(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            Else
                OBTIENE_CANTIDAD_PROCESADA_EN_ORDEN = ds.Tables(0).Rows(0)("Cantidad")
            End If

            Return OBTIENE_CANTIDAD_PROCESADA_EN_ORDEN
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Sub VULEVE_A_PROCESO()
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        Dim Fila As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor

            Fila = 0

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classPicking.cnn = _cnn

                If ACTUALIZA_ESTADO_ORDEN_ASIGNACION_BUSQUEDA(conexion, ESTADO_ORDEN_BUSQUEDA_PICKING.PROCESADA) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    lblEstado.Visible = True
                    lblEstado.Text = "EN PROCESO"
                    _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.PROCESADA
                    Call CONFIGURA_ACCIONES_SEGUN_ESTADOS()
                End If


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                ds = Nothing
                Me.Cursor = Cursors.Default

                MessageBox.Show("La orden de asignación se encuentra nuevamente en proceso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "VULEVE_A_PROCESO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NUEVA_BUSQUEDA()
        Dim classPicking As class_picking = New class_picking
        Dim classProductos As class_producto = New class_producto
        Dim Seleccionados As String = ""
        Dim Fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim _msg As String = ""
        Dim cantBultos As Integer = 0
        Dim bulto As Integer = 1
        Dim strUbicaciones As String = ""
        Dim varProCodigo As Integer = 0
        Dim varBulCodigo As Integer = 0

        Try
            If (GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_CANTIDAD).Value = GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_ENCONTRADO).Value) _
                 And (GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_ENCONTRADO).Value > 0) Then
                MessageBox.Show("La cantidad requerida esta procesada completa", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'varProCodigo = GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_PRO_CODIGO).Value
            'varBulCodigo = GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_COD_BULTO).Value

            'For Each row As DataGridViewRow In Me.grillaUbicaciones.Rows
            '    If row.Cells(COL_GRI_P3_PRO_CODIGO).Value = varProCodigo And row.Cells(COL_GRI_P3_COD_BULTO).Value = varBulCodigo Then
            '        If row.Cells(COL_GRI_P3_CANTIDAD).Value > row.Cells(COL_GRI_P3_CE).Value Then
            '            If row.Cells(COL_GRI_P3_COD_UBICACION).Value.ToString.Length > 5 Then
            '                If strUbicaciones = "" Then
            '                    strUbicaciones = CInt(Mid(row.Cells(COL_GRI_P3_COD_UBICACION).Value.ToString, 1, 5)).ToString

            '                    strUbicaciones = strUbicaciones + CInt(Mid(row.Cells(COL_GRI_P3_COD_UBICACION).Value.ToString, 7, 5)).ToString
            '                Else

            '                End If
            '            End If

            '        End If
            '    End If

            '    varSumaCant = 0
            '    For Each row2 As DataGridViewRow In Me.grillaUbicaciones.Rows
            '        If row2.Cells(COL_GRI_P3_PRO_CODIGO).Value = varProCodigo And row2.Cells(COL_GRI_P3_COD_BULTO).Value = varBulCodigo Then
            '            varSumaCant = varSumaCant + row2.Cells(COL_GRI_P3_CE).Value
            '        End If
            '    Next
            '    row.Cells(COL_GRI_P4_ENCONTRADO).Value = varSumaCant

            '    If row.Cells(COL_GRI_P4_CANTIDAD).Value = row.Cells(COL_GRI_P4_ENCONTRADO).Value Then
            '        Call PINTA_CELDA_VERDE_PRODUCTO_BULTO(Fila)
            '    ElseIf row.Cells(COL_GRI_P4_CANTIDAD).Value > row.Cells(COL_GRI_P4_ENCONTRADO).Value Then
            '        Call PINTA_CELDA_ROJO_PRODUCTO_BULTO(Fila)
            '    End If

            '    Fila = Fila + 1
            'Next



            classPicking.cnn = _cnn
            classPicking.pro_codigo = GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_PRO_CODIGO).Value
            classPicking.bul_codigo = GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_COD_BULTO).Value
            classPicking.cantidad = (GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_CANTIDAD).Value - GrillaProductoBulto.Rows(_fila).Cells(COL_GRI_P4_ENCONTRADO).Value)
            classPicking.abp_codigo = _dab_codigo

            ds = classPicking.PICKING_OBTIENE_POSICIONES_PARA_ORDEN_ASIGNACION(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0)("pro_codigointerno") <> "" Then
                        Fila = 0
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaUbicaciones.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                                       ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                                       ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                       ds.Tables(0).Rows(Fila)("bul_codigo"),
                                                       ds.Tables(0).Rows(Fila)("bul_strcodigo"),
                                                       ds.Tables(0).Rows(Fila)("ubi_codigo"),
                                                       ds.Tables(0).Rows(Fila)("ubi_nombre"),
                                                       ds.Tables(0).Rows(Fila)("pallet"),
                                                       ds.Tables(0).Rows(Fila)("cantidad"),
                                                       False,
                                                       0)
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message + " " + "NUEVA_BUSQUEDA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub GrillaProductoBulto_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GrillaProductoBulto.CellMouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.FINALIZADA Then
                GenerarNuevaBusquedaToolStripMenuItem.Enabled = True
            Else
                GenerarNuevaBusquedaToolStripMenuItem.Enabled = False
            End If
            _colum = e.ColumnIndex
            _fila = e.RowIndex
        End If
    End Sub

    Private Sub btnAprueba_Click(sender As Object, e As EventArgs) Handles btnAprueba.Click
        Dim respuesta As Integer = 0

        respuesta = MessageBox.Show("¿Esta seguro(a) de aprobar la asignación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = vbNo Then
            Exit Sub
        End If

        Call APRUEBA_ORDEN()
        Call CONFIGURA_ACCIONES_SEGUN_ESTADOS()
        _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.APROBADA
    End Sub

    Private Sub APRUEBA_ORDEN()
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        Dim Fila As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor


            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classPicking.cnn = _cnn

                If PROCESA_ASIGNACION_PARA_PICKING(conexion, ESTADO_ORDEN_BUSQUEDA_PICKING.APROBADA) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    lblEstado.Visible = True
                    lblEstado.Text = "APROBADA"
                    _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.APROBADA
                End If


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                ds = Nothing
                Me.Cursor = Cursors.Default

                MessageBox.Show("Orden de busqueda de pickeo aprobada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRechaza_Click(sender As Object, e As EventArgs) Handles btnRechaza.Click
        Dim respuesta As Integer = 0

        respuesta = MessageBox.Show("¿Esta seguro(a) de rechazar la asignación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = vbNo Then
            Exit Sub
        End If

        Call RECHAZA_ORDEN()
        Call CONFIGURA_ACCIONES_SEGUN_ESTADOS()
        _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.RECHAZADA
    End Sub

    Private Sub RECHAZA_ORDEN()
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        Dim varProCodigo As Integer = 0
        Dim varBulCodigo As Integer = 0
        Dim varSumaCant As Integer = 0

        Dim Fila As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor


            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classPicking.cnn = _cnn

                If ACTUALIZA_ESTADO_ORDEN_ASIGNACION_BUSQUEDA(conexion, ESTADO_ORDEN_BUSQUEDA_PICKING.RECHAZADA) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    lblEstado.Visible = True
                    lblEstado.Text = "RECHAZADA"
                    _abp_estado = ESTADO_ORDEN_BUSQUEDA_PICKING.RECHAZADA
                End If


                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                ds = Nothing
                Me.Cursor = Cursors.Default

                MessageBox.Show("Orden de busqueda de picking fue rechazada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class