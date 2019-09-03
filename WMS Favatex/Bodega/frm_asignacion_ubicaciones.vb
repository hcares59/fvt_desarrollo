Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading

Public Class frm_asignacion_ubicaciones
    Private _cnn As String
    Private _recNumero As Integer
    Private _asiNumero As Integer
    Private _car_codigo As Integer
    Private _esi_codigo As Integer

    Private _APROBADO As Boolean
    Private _RECHAZADO As Boolean

    Const COL_GRI_SEL_IMP As Integer = 0
    Const COL_GRI_FILA As Integer = 1
    Const COL_GRI_PRO_CODIGO As Integer = 2
    Const COL_GRI_CODIGO As Integer = 3
    Const COL_GRI_PRODUCTO As Integer = 4
    Const COL_GRI_NBULTO As Integer = 5
    Const COL_GRI_BULTO As Integer = 6
    Const COL_GRI_SERIE As Integer = 7
    Const COL_GRI_CA As Integer = 8
    Const COL_GRI_CR As Integer = 9
    Const COL_GRI_CS As Integer = 10
    Const COL_GRI_UBICACION As Integer = 11
    Const COL_GRI_COD_UBICACION As Integer = 12
    Const COL_GRI_PENDIENTE As Integer = 13
    Const COL_GRI_REUBICACION As Integer = 14


    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property recNumero() As Integer
        Get
            Return _recNumero
        End Get
        Set(ByVal value As Integer)
            _recNumero = value
        End Set
    End Property
    Public Property asiNumero() As Integer
        Get
            Return _asiNumero
        End Get
        Set(ByVal value As Integer)
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
    Private Sub frm_asignacion_ubicaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call INICIALIZA()
        Call CARGA_DATOS_ENCABEZADO_ASIGNACION()
        If asiNumero = 0 Then
            Grilla.Columns(COL_GRI_PENDIENTE).Visible = False
        End If
        'btnImprimeIdentificador.Enabled = True
        If _esi_codigo > 0 Then

            Call OBTIENE_ESTADO_ASIGNACION()


            txtNumAsi.Enabled = False
            TxtFechaAsi.Enabled = False
            TabPage1.Parent = Nothing
            Call CARGA_GRILLA_DETALLE(0, 0)
        Else
            btnAsigna.Enabled = True
            txtNumAsi.Enabled = False
            TxtFechaAsi.Enabled = False
            TabPage2.Parent = Nothing
            Call CARGA_GRILLA_PENDIENTE()
        End If

    End Sub

    Private Sub OBTIENE_ESTADO_ASIGNACION()
        Dim classAsi As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            Grilla.Columns(COL_GRI_PENDIENTE).Visible = False
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

                            Grilla.Columns(COL_GRI_REUBICACION).Visible = False
                            Grilla.Columns(COL_GRI_PENDIENTE).Visible = True
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
                            Grilla.Columns(COL_GRI_REUBICACION).Visible = True
                            Grilla.Columns(COL_GRI_PENDIENTE).Visible = True
                            Grilla.Columns(COL_GRI_PENDIENTE).ReadOnly = True

                        End If
                    ElseIf ds.Tables(0).Rows(Fila)("esi_codigo") = ESTADO_ASIGNACION.APROBADA_POR_BODEGA Then
                        btnImprimeIdentificador.Enabled = True
                        btnAsigna.Enabled = False
                        btnImprimeIdentificador.Enabled = True
                        btnGuardaAsignacion.Enabled = False
                        btnEnviaAprovación.Enabled = False
                        btnAprueba.Enabled = False
                        btnRechazo.Enabled = False

                        Grilla.Columns(COL_GRI_REUBICACION).Visible = False

                    Else
                        Grilla.Columns(COL_GRI_REUBICACION).Visible = False
                        Grilla.Columns(COL_GRI_PENDIENTE).ReadOnly = True
                        btnImprimeIdentificador.Enabled = False
                    End If

                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_ESTADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\OBTIENE_ESTADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CARGA_COMBO_PRODUCTOS_RECEPCION()
        Dim _msg As String
        Try
            Dim classRecepcion As class_recepcion = New class_recepcion
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _recNumero
            _msg = ""
            ds = classRecepcion.PRODUCTOS_RECEPCION_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbProductos.DataSource = ds.Tables(0)
                Me.cmbProductos.DisplayMember = "MENSAJE"
                Me.cmbProductos.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PRODUCTOS_RECEPCION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    'Private Sub CARGA_CO()

    Private Sub CARGA_DATOS_ENCABEZADO_ASIGNACION()
        Dim classAsi As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classAsi.cnn = _cnn
            classAsi.rec_numero = _recNumero
            classAsi.asi_numero = _asiNumero

            ds = classAsi.CARGA_CABECERA_ASIGNACION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        _car_codigo = ds.Tables(0).Rows(Fila)("car_codigo")
                        lblProveedor.Text = ds.Tables(0).Rows(Fila)("car_nombre")
                        txtNumRec.Text = ds.Tables(0).Rows(Fila)("rec_strnumero")
                        txtNumOc.Text = ds.Tables(0).Rows(Fila)("ocp_numero")
                        txtFechaRec.Value = ds.Tables(0).Rows(Fila)("rec_fecha")
                        txtFechaOC.Value = ds.Tables(0).Rows(Fila)("ocp_fecha")
                        txtNumAsi.Text = ds.Tables(0).Rows(Fila)("asi_strnumero")
                        TxtFechaAsi.Text = ds.Tables(0).Rows(Fila)("asi_fecha")
                        txtFactura.Text = ds.Tables(0).Rows(Fila)("rec_nfactura")
                        txtGuia.Text = ds.Tables(0).Rows(Fila)("rec_nguia")
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_ENCABEZADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_ENCABEZADO_ASIGNACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLE(ByVal proCodigo As Integer, ByVal canReserva As Integer)
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classUbicacion.cnn = _cnn
            classUbicacion.rec_numero = _recNumero
            classUbicacion.pro_codigo = proCodigo
            classUbicacion.can_reserva = canReserva
            classUbicacion.asi_numero = _asiNumero

            If _asiNumero > 0 Then
                Grilla.Rows.Clear()
            End If

            ds = classUbicacion.CARGA_DETALLE_ASIGNACION(_msgError)
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
                                            ds.Tables(0).Rows(Fila)("prd_cantidadpallet"),
                                            ds.Tables(0).Rows(Fila)("prd_cantidadreserva"),
                                            ds.Tables(0).Rows(Fila)("prd_cantidadsaldo"),
                                            ds.Tables(0).Rows(Fila)("ubi_nombre"),
                                            ds.Tables(0).Rows(Fila)("ubi_codigo"),
                                            ds.Tables(0).Rows(Fila)("asi_ubicado"))

                            If CInt(Grilla.Item(COL_GRI_CR, Fila).Value) > 0 Then
                                Grilla.Item(COL_GRI_CODIGO, Fila).Style.BackColor = Color.FromArgb(255, 214, 214)
                                Grilla.Item(COL_GRI_CODIGO, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

                                Grilla.Item(COL_GRI_PRODUCTO, Fila).Style.BackColor = Color.FromArgb(255, 214, 214)
                                Grilla.Item(COL_GRI_PRODUCTO, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

                                Grilla.Item(COL_GRI_BULTO, Fila).Style.BackColor = Color.FromArgb(255, 214, 214)
                                Grilla.Item(COL_GRI_BULTO, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

                                Grilla.Item(COL_GRI_SERIE, Fila).Style.BackColor = Color.FromArgb(255, 214, 214)
                                Grilla.Item(COL_GRI_SERIE, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

                                Grilla.Item(COL_GRI_CA, Fila).Style.BackColor = Color.FromArgb(255, 214, 214)
                                Grilla.Item(COL_GRI_CA, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

                                Grilla.Item(COL_GRI_CR, Fila).Style.BackColor = Color.FromArgb(255, 214, 214)
                                Grilla.Item(COL_GRI_CR, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

                                Grilla.Item(COL_GRI_CS, Fila).Style.BackColor = Color.FromArgb(255, 214, 214)
                                Grilla.Item(COL_GRI_CS, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

                                Grilla.Item(COL_GRI_UBICACION, Fila).Style.BackColor = Color.FromArgb(255, 214, 214)
                                Grilla.Item(COL_GRI_UBICACION, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)

                            End If

                            Fila = Fila + 1
                            Contador = Contador + 1
                        Loop
                        Grilla.Columns(COL_GRI_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_PRODUCTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_NBULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_SERIE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_CA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_CR).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_CS).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_COD_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_PENDIENTE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(COL_GRI_REUBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
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

    Private Sub CARGA_GRILLA_PENDIENTE()
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classRecepcion.cnn = _cnn
            classRecepcion.rec_numero = _recNumero

            If cmbProductos.Text = "" Then
                classRecepcion.pro_codigo = 0
            Else
                classRecepcion.pro_codigo = cmbProductos.SelectedValue
            End If



            ds = classRecepcion.RECEPCION_LISTAR_CANTIDADES_PENDIENTES(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GillaPendiente.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GillaPendiente.Rows.Add(False, ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("rec_cantidadpendiente"),
                                            ds.Tables(0).Rows(Fila)("rec_cantidadconsumida"),
                                            "0")
                            Fila = Fila + 1
                        Loop
                        GillaPendiente.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GillaPendiente.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GillaPendiente.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GillaPendiente.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        GillaPendiente.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
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

        txtNumRec.Text = "0"
        txtNumOc.Text = "0"

        txtFechaRec.Value = GLO_FECHA_SISTEMA
        txtFechaOC.Value = GLO_FECHA_SISTEMA

        txtNumAsi.Text = "0"
        TxtFechaAsi.Value = GLO_FECHA_SISTEMA

        Call CARGA_COMBO_PRODUCTOS_RECEPCION()

        btnAsigna.Enabled = False
        btnImprimeIdentificador.Enabled = False
        btnGuardaAsignacion.Enabled = False
        btnEnviaAprovación.Enabled = False
        btnAprueba.Enabled = False
        btnRechazo.Enabled = False

        Grilla.Columns(COL_GRI_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_PRODUCTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_NBULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_SERIE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_CA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_CR).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_CS).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_COD_UBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_PENDIENTE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_REUBICACION).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        GillaPendiente.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GillaPendiente.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GillaPendiente.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GillaPendiente.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        Grilla.Columns(COL_GRI_REUBICACION).Visible = False

    End Sub

    'Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
    '    Call CARGA_GRILLA_DETALLE()
    'End Sub

    Private Sub btnAsignaUbicacion_Click(sender As Object, e As EventArgs) Handles btnAsignaUbicacion.Click
        Dim fila As Integer = 0
        Dim contador As Integer = 0
        Dim cantReserva As Integer = 0

        Grilla.Rows.Clear()

        If DETALLES_MARCADAS() = False Then
            MessageBox.Show("No existen registros seleccionados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Do While fila <= GillaPendiente.RowCount - 1

            If GillaPendiente.Rows(fila).Cells(5).Value.ToString <> "" Then
                cantReserva = CInt(GillaPendiente.Rows(fila).Cells(5).Value)
            End If

            If (GillaPendiente.Rows(fila).Cells(0).Value = True And (GillaPendiente.Rows(fila).Cells(4).Value + cantReserva) = 0) Then
                contador = contador + 1
            End If
            fila = fila + 1
        Loop

        If contador > 0 Then
            MessageBox.Show("Existen registros seleccionados cuya cantidad en cero y por ende no es posible procesar la petición", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        fila = 0
        Do While fila <= GillaPendiente.RowCount - 1
            If GillaPendiente.Rows(fila).Cells(0).Value = True Then
                Call CARGA_GRILLA_DETALLE(GillaPendiente.Rows(fila).Cells(1).Value, GillaPendiente.Rows(fila).Cells(6).Value)
            End If
            fila = fila + 1
        Loop

        TabPage2.Parent = TabControl1


    End Sub

    Private Function DETALLES_MARCADAS() As Boolean
        Dim Contador As Integer = 0
        Try
            DETALLES_MARCADAS = False

            For Each row As DataGridViewRow In Me.GillaPendiente.Rows
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call CARGA_GRILLA_PENDIENTE()
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
                classUbicaciones.car_codigo = _car_codigo

                ProgressBar1.Visible = True
                ProgressBar1.Value = 0
                ProgressBar1.Minimum = 0
                ProgressBar1.Maximum = Grilla.RowCount
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(COL_GRI_CS).Value > 0 Then
                        classUbicaciones.pro_codigo = row.Cells(COL_GRI_PRO_CODIGO).Value
                        classUbicaciones.bul_codigo = row.Cells(COL_GRI_NBULTO).Value
                        classUbicaciones.pallet = row.Cells(COL_GRI_SERIE).Value
                        ds = Nothing
                        ds = classUbicaciones.OBTIENE_UBICACION_PARA_ASIGNAR(_msgError, conexion)
                        If _msgError = "" Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                If ds.Tables(0).Rows(0)("mensaje") <> "-" Then
                                    row.Cells(COL_GRI_UBICACION).Value = ds.Tables(0).Rows(0)("mensaje")
                                    row.Cells(COL_GRI_COD_UBICACION).Value = ds.Tables(0).Rows(0)("codigo")
                                Else
                                    row.Cells(COL_GRI_UBICACION).Value = "SIN UBICACIÓN"
                                    row.Cells(COL_GRI_COD_UBICACION).Value = "00000"
                                End If

                                Grilla.Refresh()
                            Else
                                row.Cells(COL_GRI_UBICACION).Value = "SIN UBICACIÓN"
                                row.Cells(COL_GRI_COD_UBICACION).Value = "00000"
                                Grilla.Refresh()
                                ds = Nothing
                            End If
                        Else
                            ds = Nothing
                            MessageBox.Show(_msgError + "\OBTIENE_UBICACIONES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                If row2.Cells(COL_GRI_CS).Value > 0 Then
                    classUbicaciones.pallet = row2.Cells(COL_GRI_SERIE).Value
                    classUbicaciones.asi_cantidadsaldo = row2.Cells(COL_GRI_CS).Value
                    classUbicaciones.ubi_codigostr = row2.Cells(COL_GRI_COD_UBICACION).Value
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

    Private Function ELIMINA_PALETIZADO_TEMPORAL(ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim tmp_llave_pallet As String = ""
        Dim ds As DataSet

        ELIMINA_PALETIZADO_TEMPORAL = False
        tmp_llave_pallet = "ASI-" + String.Format("{0:00000000}", _asiNumero)

        Try
            'Guarda cabecera del documento
            ds = Nothing
            classUbicaciones.tmp_llave = tmp_llave_pallet
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

            ELIMINA_PALETIZADO_TEMPORAL = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Function VERIFICA_UBICACIONES()
        Dim contador As Integer = 0

        VERIFICA_UBICACIONES = True
        For Each row As DataGridViewRow In Me.Grilla.Rows
            If (row.Cells(COL_GRI_UBICACION).Value = "SIN UBICACIÓN" Or row.Cells(COL_GRI_UBICACION).Value = "-") And CInt(row.Cells(COL_GRI_CS).Value) > 0 Then
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
                    If row2.Cells(COL_GRI_PENDIENTE).Value = True Then
                        classUbicaciones.asi_codigo = _asiNumero
                        classUbicaciones.asi_fila = row2.Cells(COL_GRI_FILA).Value
                        classUbicaciones.pro_codigo = row2.Cells(COL_GRI_PRO_CODIGO).Value
                        classUbicaciones.asi_nbulto = row2.Cells(COL_GRI_NBULTO).Value
                        classUbicaciones.asi_bulto = row2.Cells(COL_GRI_BULTO).Value
                        classUbicaciones.asi_pallet = row2.Cells(COL_GRI_SERIE).Value
                        classUbicaciones.asi_cantidad = row2.Cells(COL_GRI_CA).Value
                        classUbicaciones.asi_cantidadreserva = row2.Cells(COL_GRI_CR).Value
                        classUbicaciones.asi_cantidadsaldo = row2.Cells(COL_GRI_CS).Value
                        classUbicaciones.asi_ubicacionnombre = row2.Cells(COL_GRI_UBICACION).Value
                        classUbicaciones.asi_ubicacioncodigo = row2.Cells(COL_GRI_COD_UBICACION).Value
                        classUbicaciones.asi_ubicado = IIf(IsDBNull(row2.Cells(COL_GRI_PENDIENTE).Value) = True, False, row2.Cells(COL_GRI_PENDIENTE).Value) 'row2.Cells(COL_GRI_PENDIENTE).Value
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
                    If (row2.Cells(COL_GRI_CS).Value > 0) And (row2.Cells(COL_GRI_UBICACION).Value <> "-") And (row2.Cells(COL_GRI_UBICACION).Value <> "SIN UBICACIÓN") Then
                        ds = Nothing
                        classUbicaciones.asi_codigo = _asiNumero
                        classUbicaciones.asi_fila = row2.Cells(COL_GRI_FILA).Value
                        classUbicaciones.pro_codigo = row2.Cells(COL_GRI_PRO_CODIGO).Value
                        classUbicaciones.asi_nbulto = row2.Cells(COL_GRI_NBULTO).Value
                        classUbicaciones.asi_bulto = row2.Cells(COL_GRI_BULTO).Value
                        classUbicaciones.asi_pallet = row2.Cells(COL_GRI_SERIE).Value
                        classUbicaciones.asi_cantidad = row2.Cells(COL_GRI_CA).Value
                        classUbicaciones.asi_cantidadreserva = row2.Cells(COL_GRI_CR).Value
                        classUbicaciones.asi_cantidadsaldo = row2.Cells(COL_GRI_CS).Value
                        classUbicaciones.asi_ubicacionnombre = row2.Cells(COL_GRI_UBICACION).Value
                        classUbicaciones.asi_ubicacioncodigo = row2.Cells(COL_GRI_COD_UBICACION).Value
                        classUbicaciones.asi_ubicado = IIf(IsDBNull(row2.Cells(COL_GRI_PENDIENTE).Value) = True, False, row2.Cells(COL_GRI_PENDIENTE).Value) 'row2.Cells(COL_GRI_PENDIENTE).Value
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
                    'aca se guarda ka reserva
                    If _esi_codigo = ESTADO_ASIGNACION.ASIGNACION_GENERADA Then
                        If CInt(row2.Cells(COL_GRI_NBULTO).Value = 1) Then
                            classUbicaciones.rec_numero = _recNumero
                            classUbicaciones.pro_codigo = row2.Cells(COL_GRI_PRO_CODIGO).Value
                            classUbicaciones.can_reserva = row2.Cells(COL_GRI_CR).Value
                            ds = classUbicaciones.ACTUALIZA_RESERVAS_EN_RECEPCION(_msgError, conexion)
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

                        If (row2.Cells(COL_GRI_CR).Value > 0) And (row2.Cells(COL_GRI_CR).Value <= row2.Cells(COL_GRI_CA).Value) Then
                            classUbicaciones.tmp_procodigo = row2.Cells(COL_GRI_PRO_CODIGO).Value
                            classUbicaciones.tmp_numbulto = row2.Cells(COL_GRI_NBULTO).Value
                            classUbicaciones.tmp_cantidad = row2.Cells(COL_GRI_CR).Value
                            classUbicaciones.tmp_llave = tmp_llave_pallet
                            ds = classUbicaciones.DATOS_PARA_PALETIZAR_INGRESA(_msgError, conexion)
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
                        ds = Nothing


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
            classUbicaciones.car_codigo = _car_codigo
            'classUbicaciones.esi_codigo = ESTADO_ASIGNACION.ASIGNACION_GENERADA
            classUbicaciones.esi_codigo = codEstadoAsignacion
            classUbicaciones.rec_numero = txtNumRec.Text
            classUbicaciones.rec_fecha = txtFechaRec.Text
            classUbicaciones.ocp_numero = txtNumOc.Text
            classUbicaciones.ocp_fecha = txtFechaOC.Text

            If txtFactura.Text = "" Then
                classUbicaciones.rec_nfactura = 0
            Else
                classUbicaciones.rec_nfactura = txtFactura.Text
            End If

            If txtGuia.Text = "" Then
                classUbicaciones.rec_nguia = 0
            Else
                classUbicaciones.rec_nguia = txtGuia.Text
            End If

            classUbicaciones.bulto_completo = 1

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

    Private Function OBTIENE_SERIES() As String
        Dim strPallet As String = ""
        OBTIENE_SERIES = ""
        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(0).Value = True Then
                If strPallet = "" Then
                    strPallet = row.Cells(COL_GRI_SERIE).Value
                Else
                    strPallet = strPallet + "," + row.Cells(COL_GRI_SERIE).Value
                End If
            End If
        Next
        If strPallet = "" Then
            OBTIENE_SERIES = "-"
        Else
            OBTIENE_SERIES = strPallet + ","
        End If

    End Function

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles btnAsigna.Click
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
        Call CARGA_GRILLA_DETALLE(0, 0)
        Call CARGA_GRILLA_PENDIENTE()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles btnImprimeIdentificador.Click
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

    Private Sub btnGuardaAsignacion_Click(sender As Object, e As EventArgs) Handles btnGuardaAsignacion.Click
        _APROBADO = False
        _RECHAZADO = False
        Call GUARDA_ASIGNACION(_esi_codigo)
        Call OBTIENE_ESTADO_ASIGNACION()
        Call CARGA_GRILLA_DETALLE(0, 0)
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
                    If PALTIZA_RESERVAS(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If ALMACENA_PALLET(conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If GUARDA_MOVIMIENTO(conexion) = False Then
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

                    If DISPONIVILIZA_UBICACION(conexion) = False Then
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

    Private Function DISPONIVILIZA_UBICACION(ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim tmp_llave_pallet As String = ""
        DISPONIVILIZA_UBICACION = False
        Try

            For Each row2 As DataGridViewRow In Me.Grilla.Rows
                ds = Nothing
                If row2.Cells(COL_GRI_CS).Value > 0 Then
                    classUbicaciones.ubi_codigostr = row2.Cells(COL_GRI_COD_UBICACION).Value
                    ds = classUbicaciones.UBICACION_DISPONIBILIZA(_msgError, conexion)
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

            DISPONIVILIZA_UBICACION = True
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
            classUbicaciones.Documento = "REC"
            classUbicaciones.Numero = CLng(txtNumRec.Text)
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

    Private Function PALTIZA_RESERVAS(ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim tmp_llave_pallet As String = ""

        PALTIZA_RESERVAS = False

        Try
            tmp_llave_pallet = "ASI-" + String.Format("{0:00000000}", _asiNumero)
            ds = Nothing
            classUbicaciones.tmp_llave = tmp_llave_pallet
            classUbicaciones.car_codigo = _car_codigo
            classUbicaciones.ubi_codigo = GLO_UBI_PISO_RECEPCION

            ds = classUbicaciones.PALETIZA_SOBRANTES(_msgError, conexion)
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
            PALTIZA_RESERVAS = True
        Catch ex As Exception
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

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(COL_GRI_SEL_IMP).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(COL_GRI_SEL_IMP)
            chkCell.Value = Not chkCell.Value
        End If

        If USU_ASIGNA_PARA_ALMACENAMIENTO = True Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(COL_GRI_PENDIENTE)
            chkCell.Value = chkCell.Value 'False
        Else
            If e.ColumnIndex = Me.Grilla.Columns.Item(COL_GRI_PENDIENTE).Index Then
                Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(COL_GRI_PENDIENTE)
                chkCell.Value = Not chkCell.Value
            End If
        End If

        If e.ColumnIndex = Me.Grilla.Columns.Item(COL_GRI_REUBICACION).Index Then
            If Grilla.Rows(e.RowIndex).Cells(COL_GRI_PENDIENTE).Value = True Then
                MessageBox.Show("No es posible reasignar ubicación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            Dim frm As frm_movimiento_de_pallet = New frm_movimiento_de_pallet
            GLO_ACCION_EJECUTADA = False
            frm.cnn = _cnn
            frm.bod_codigo = BODEGAS.BOD_PRODUCTO_TERMINADO
            frm.ubi_codigo = UBICACION.PISO_PRODUCTO_TERMINADO
            frm.procedencia = "ABA"
            frm.ubicacion_actual = Grilla.Rows(e.RowIndex).Cells(COL_GRI_UBICACION).Value
            frm.ShowDialog()

            If GLO_ACCION_EJECUTADA = True Then
                Grilla.Rows(e.RowIndex).Cells(COL_GRI_PENDIENTE).Value = True
                GLO_ACCION_EJECUTADA = False
            End If
        End If

    End Sub

    Private Sub btnEnviaAprovación_Click(sender As Object, e As EventArgs) Handles btnEnviaAprovación.Click
        Dim contador As Integer = 0
        Dim respuesta As Integer = 0

        For Each row As DataGridViewRow In Me.Grilla.Rows
            If (row.Cells(COL_GRI_PENDIENTE).Value = False) Then
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
        Call CARGA_GRILLA_DETALLE(0, 0)
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
                If (row.Cells(COL_GRI_UBICACION).Value = "SIN UBICACIÓN") Or (row.Cells(COL_GRI_UBICACION).Value = "-") Then
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

    Private Sub CAMBIA_ESTADO_ASIGNACION(ByVal codEstadoAsignacion As Integer)
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet

        Try
            ds = Nothing
            classUbicaciones.cnn = _cnn
            classUbicaciones.asi_codigo = _asiNumero
            classUbicaciones.esi_codigo = codEstadoAsignacion
            ds = classUbicaciones.CAMBIA_ESTADO_ASIGNACION(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Exit Sub
                Else
                    txtNumAsi.Text = ds.Tables(0).Rows(0)("CODIGO")
                    _asiNumero = ds.Tables(0).Rows(0)("CODIGO")
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

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
        Call CARGA_GRILLA_DETALLE(0, 0)
    End Sub

    Private Function GUARDA_MOVIMIENTO(ByVal conexion As SqlConnection) As Boolean
        Dim classMOV As class_movimientos = New class_movimientos
        Dim classInv As class_inventario = New class_inventario
        'Dim class_recepcion As class_recepcion = New class_recepcion
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim ds As DataSet = New DataSet
        Dim dsDetalle As DataSet = New DataSet
        Dim dsInventario As DataSet = New DataSet
        Dim dsUbicacion As DataSet = New DataSet
        Dim dsMov As DataSet = New DataSet
        Dim _numCantidadBultos As Integer = 0

        Dim _Folio As Integer = 0
        Dim _FolioRelacionado As Integer = 0
        Dim fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim _msgError As String = ""
        'Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim _fecha As Date
        Dim cantidad As Integer = 0
        Dim sumaCantidad As Integer = 0
        Dim seriePallet As String = ""
        Dim _Observacion As String = ""
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones

        GUARDA_MOVIMIENTO = False

        Try
            _Observacion = "MOVIMIENTO GENERADO A TRAVEZ DE LA ASIGNACIÓN NUMERO:  " + _asiNumero.ToString + ""
            '_numCantidadBultos = OBTIENE_NUMERO_BULTOS(cmbProductos.SelectedValue)

            'Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
            '    conexion.Open()

            _fecha = GLO_FECHA_SISTEMA

                If CStr(_fecha.Month).Length = 1 Then
                    mes = Trim("0" + CStr(_fecha.Month))
                Else
                    mes = CStr(_fecha.Month)
                End If

                'SALIDA DE BODEGA DE ORIGEN
                '=============================================================
                If GUARDA_ENC_MOVIMINETO(conexion, 0, TIPO_MOVIMIENTO.SALIDA, GLO_BODEGA_RECEPCION, _fecha, mes, _fecha.Year, GLO_USUARIO_ACTUAL, 0,
                                         COM_TIPO_DOCUMENTO.VALE_DE_SALIDA, 0, 0, _Observacion, "-", 0, _Folio) = False Then
                    Return False
                    Exit Function
                End If

                _FolioRelacionado = _Folio

                If ELIMINA_DETALLE_MOVIMIENTO(conexion, _Folio) = False Then
                    Return False
                    Exit Function
                End If

                dsUbicacion = Nothing
                classUbicaciones.asi_codigo = _asiNumero
                dsUbicacion = classUbicaciones.OBTIENE_DETALLE_ASIGNACION_PARA_MOVIMIENTO(_msgError, conexion)
                If _msgError = "" Then
                    If dsUbicacion.Tables(0).Rows.Count > 0 Then
                        If dsUbicacion.Tables(0).Rows(fila)("cantidad") > 0 Then
                            If GUARDA_DET_MOVIMINETO(conexion, _Folio, dsUbicacion.Tables(0).Rows(fila)("pro_codigo"), CInt(dsUbicacion.Tables(0).Rows(fila)("cantidad")), CInt(dsUbicacion.Tables(0).Rows(fila)("numero_Bulto")), CInt(dsUbicacion.Tables(0).Rows(fila)("total_Bulto"))) = False Then
                                Return False
                                Exit Function
                            End If

                            If ACTUALIZA_STOCK_BODEGA(conexion, GLO_BODEGA_RECEPCION, dsUbicacion.Tables(0).Rows(fila)("pro_codigo"), TIPO_MOVIMIENTO.SALIDA, CInt(dsUbicacion.Tables(0).Rows(fila)("cantidad"))) = False Then
                                Return False
                                Exit Function
                            End If
                        End If
                    End If
                End If

                'FIN SALIDA DE BODEGA DE ORIGEN
                '=============================================================

                'ENTRADA A BODEGA DE DESTINO
                '=============================================================
                _Folio = 0
                If GUARDA_ENC_MOVIMINETO(conexion, 0, TIPO_MOVIMIENTO.ENTRADA, GLO_BODEGA_PRODUCTO_TERMINADO, _fecha, mes, _fecha.Year, GLO_USUARIO_ACTUAL, 0,
                                         COM_TIPO_DOCUMENTO.VALE_DE_INGRESO, 0, _FolioRelacionado, _Observacion, "-", CLng(0), _Folio) = False Then
                    Return False
                    Exit Function
                End If

                If ELIMINA_DETALLE_MOVIMIENTO(conexion, _Folio) = False Then
                    Return False
                    Exit Function
                End If

                dsUbicacion = Nothing
                classUbicaciones.asi_codigo = _asiNumero
                dsUbicacion = classUbicaciones.OBTIENE_DETALLE_ASIGNACION_PARA_MOVIMIENTO(_msgError, conexion)
                If _msgError = "" Then
                    If dsUbicacion.Tables(0).Rows.Count > 0 Then
                        If dsUbicacion.Tables(0).Rows(fila)("cantidad") > 0 Then
                            If GUARDA_DET_MOVIMINETO(conexion, _Folio, dsUbicacion.Tables(0).Rows(fila)("pro_codigo"), CInt(dsUbicacion.Tables(0).Rows(fila)("cantidad")), CInt(dsUbicacion.Tables(0).Rows(fila)("numero_Bulto")), CInt(dsUbicacion.Tables(0).Rows(fila)("total_Bulto"))) = False Then
                            'If conexion.State = ConnectionState.Open Then
                            '    conexion.Close()
                            'End If
                            Return False
                            Exit Function
                            End If

                            If ACTUALIZA_STOCK_BODEGA(conexion, GLO_BODEGA_PRODUCTO_TERMINADO, dsUbicacion.Tables(0).Rows(fila)("pro_codigo"), TIPO_MOVIMIENTO.ENTRADA, CInt(dsUbicacion.Tables(0).Rows(fila)("cantidad"))) = False Then
                                Return False
                                Exit Function
                            End If
                        End If
                    End If
                End If

                ''FIN ENTRADA A BODEGA DE DESTINO
                ''=============================================================

                'Transaccion.Complete()
                'Transaccion.Dispose()
                'If conexion.State = ConnectionState.Open Then
                '    conexion.Close()
                'End If

                GUARDA_MOVIMIENTO = True

            'End Using
        Catch ex As Exception
            GUARDA_MOVIMIENTO = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function VALIDA_ITEMS_PARA_APROBAR() As Boolean
        Dim totalFilas As Integer = 0
        Dim contador As Integer = 0
        VALIDA_ITEMS_PARA_APROBAR = False
        Try
            totalFilas = Grilla.RowCount

            For Each row2 As DataGridViewRow In Me.Grilla.Rows
                If row2.Cells(COL_GRI_PENDIENTE).Value = True Then
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

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim frm As frm_imprimir = New frm_imprimir
        frm.nombreReporte = "rptDocumentoAsignacion.rpt"
        frm.Origen = "DAS"
        frm.asi_codigo = _asiNumero
        frm.ShowDialog()

    End Sub

    Private Sub GillaPendiente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GillaPendiente.CellContentClick

    End Sub



End Class