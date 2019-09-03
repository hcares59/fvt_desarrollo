Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_mant_picking
    Dim _cnn As String
    Dim _pic_codigo As Integer
    Dim _colum As Integer = 0
    Dim _fila As Integer = 0
    Dim _HabilitarBtn As Boolean = True
    Dim _despachaPor As String
    Dim _conUbicacion As Boolean
    Dim _proCodigo As Integer
    Dim _proNombre As String
    Dim _proCantidad As Integer
    Dim _filaSeleccionada As Integer = 0

    Const col_SELECCION As Integer = 0
    Const col_CAR_CODIGO As Integer = 1
    Const col_FIL As Integer = 2
    Const col_CODIGO_INTERNO As Integer = 3
    Const col_NOMBRE_FAVATEX As Integer = 4
    Const col_SKU_CLIENTE As Integer = 5
    Const col_SKU_NOMBRE As Integer = 6
    Const col_DISPONIBLE As Integer = 7
    Const col_CANTIDAD As Integer = 8
    Const col_NBXU As Integer = 9 'NUMERO DE BULTOS POR UNIDAD
    Const col_TBULTOS As Integer = 10
    Const col_CODIGO_INTERNO_ORIGINAL As Integer = 11
    Const col_EXISTENTES As Integer = 12
    Const col_OBSERVACIONES As Integer = 13
    Const col_NEW_CODIGO As Integer = 14
    Const col_COD_INT_ORI As Integer = 15
    Const col_NOMBRE_ORI As Integer = 16
    Const col_NBO As Integer = 17 'CANTIDAD DE BULTOS ORIGINALES
    Const col_PIC_CODIGO As Integer = 18

    Const col_NUEVA As Integer = 19
    Const col_PRECIO_UNITARIO As Integer = 20
    Const col_OC_ORIGEN As Integer = 21
    Const col_FECHA_OC As Integer = 22
    Const col_COD_UNICO As Integer = 23
    Const col_FILA_DEVULETA As Integer = 24

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property pic_codigo() As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
        End Set
    End Property
    Public Property HabilitarBtn() As Boolean
        Get
            Return _HabilitarBtn
        End Get
        Set(ByVal value As Boolean)
            _HabilitarBtn = value
        End Set
    End Property

    Private Sub frm_mant_picking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=CL-MV032\DESARROLLO;Initial Catalog=db_favatex;User ID=sa;Password=S1st3m4s"
        Call INICAILIZA()

        '_pic_codigo = 2
        If _pic_codigo > 0 Then
            Call CARGA_DATOS_ENCABEZADO()
            Call DESPACHA_CON_GUIA()
        End If

        If _HabilitarBtn = True Then
            Call habilita_botonera()
        Else
            ButtonEditar.Enabled = False
            ButtonGurdar.Enabled = False
            ButtonEnvio.Enabled = False
            ButtonFinaliza.Enabled = False
            ButtonAnula.Enabled = False
            ButtonEnviadaFacturar.Enabled = False
            ButtonDespacho.Visible = False
        End If

    End Sub

    Private Sub DESPACHA_CON_GUIA()
        Dim classGDespacho As class_despacha_picking = New class_despacha_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classGDespacho.cnn = _cnn
            classGDespacho.car_codigo = cmbCliente.SelectedValue

            _msg = ""

            ds = classGDespacho.SELECCIONA_DOCUMENTO_DESPACHO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("dde_descripcion") <> "" Then
                        _despachaPor = ds.Tables(0).Rows(Fila)("dde_descripcion")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\DESPACHA_CON_GUIA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "DESPACHA_CON_GUIA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub habilita_botonera()
        ButtonEditar.Enabled = False
        ButtonGurdar.Enabled = True
        ButtonEnvio.Enabled = False
        ButtonImprimir.Enabled = False
        ButtonAnula.Enabled = False
        ButtonFinaliza.Enabled = False
        ButtonEnviadaFacturar.Enabled = False
        chkTodos.Enabled = False


        Me.GrillaDetalle.Columns(11).ReadOnly = True
        Me.GrillaDetalle.Columns(12).ReadOnly = True

        If (cmbEstado.SelectedValue = ESTADOS_PICKING.Generado) Then
            ButtonEditar.Enabled = True
            ButtonEnvio.Enabled = True
            ButtonImprimir.Enabled = True
            ButtonAnula.Enabled = True
            ButtonGurdar.Enabled = True
        ElseIf (cmbEstado.SelectedValue = ESTADOS_PICKING.En_proceso) Then
            'ButtonEditar.Enabled = True
            ButtonEnvio.Enabled = False
            ButtonImprimir.Enabled = True
            'ButtonAnula.Enabled = True
            ButtonFinaliza.Enabled = True
            ButtonGurdar.Enabled = False
            chkTodos.Enabled = True

            If GLO_PERSONA_NUMERO <> cmbPersonas.SelectedValue Then
                ButtonGurdar.Enabled = True
            End If

            Me.GrillaDetalle.Columns(11).ReadOnly = False
            Me.GrillaDetalle.Columns(12).ReadOnly = False
        ElseIf (cmbEstado.SelectedValue = ESTADOS_PICKING.Finalizado_con_diferenia) Then
            ButtonImprimir.Enabled = True
            ButtonAnula.Enabled = True

            If USU_ENVIA_FACTURAR_PIKING = True Then
                ButtonEnviadaFacturar.Enabled = True
                If _despachaPor = "GD" Then
                    ButtonEnviadaFacturar.Visible = False
                    ButtonDespacho.Visible = True
                Else
                    ButtonEnviadaFacturar.Visible = True
                    ButtonDespacho.Visible = False
                End If
            End If
            ButtonEditar.Enabled = True
            ButtonGurdar.Enabled = True
            GrillaDetalle.Columns(12).ReadOnly = False

        ElseIf (cmbEstado.SelectedValue = ESTADOS_PICKING.Finalizado_sin_diferencia) Then
            ButtonImprimir.Enabled = True
            ButtonGurdar.Enabled = False

            If USU_ENVIA_FACTURAR_PIKING = True Then
                ButtonEnviadaFacturar.Enabled = True
                If _despachaPor = "GD" Then
                    ButtonEnviadaFacturar.Visible = False
                    ButtonDespacho.Visible = True
                Else
                    ButtonEnviadaFacturar.Visible = True
                    ButtonDespacho.Visible = False
                End If
            End If
            ButtonEditar.Enabled = True
            ButtonGurdar.Enabled = True
            GrillaDetalle.Columns(12).ReadOnly = False

        ElseIf (cmbEstado.SelectedValue = ESTADOS_PICKING.Enviado_a_facturar) Then
            ButtonImprimir.Enabled = True
            ButtonAnula.Enabled = True
            ButtonGurdar.Enabled = True
        ElseIf (cmbEstado.SelectedValue = ESTADOS_PICKING.Enviado_a_despachar) Then
            ButtonImprimir.Enabled = True
        ElseIf (cmbEstado.SelectedValue = ESTADOS_PICKING.Despachado) Then
            ButtonImprimir.Enabled = True
        ElseIf (cmbEstado.SelectedValue = ESTADOS_PICKING.Nulo) Then
            ButtonImprimir.Enabled = True
        End If

        If cmbEstado.SelectedValue = ESTADOS_PICKING.En_proceso Then
            ButtonDev.Visible = True
            Separador1.Visible = True
        End If

    End Sub

    Private Sub CARGA_DATOS_ENCABEZADO()
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classPicking.cnn = _cnn
            classPicking.pic_codigo = _pic_codigo

            ds = classPicking.PICKING_CARGA_ENCABEZADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        cmbCliente.SelectedValue = ds.Tables(0).Rows(Fila)("car_codigo")
                        cmbEstado.SelectedValue = ds.Tables(0).Rows(Fila)("epc_codigo")
                        dtpFechaDespacho.Value = ds.Tables(0).Rows(Fila)("fecha_despacho")
                        txtHora.Text = ds.Tables(0).Rows(Fila)("hora_cita")
                        txtNumero.Text = ds.Tables(0).Rows(Fila)("pic_codigostring")
                        cmbPersonas.SelectedValue = ds.Tables(0).Rows(Fila)("per_codigoresponsable")

                        Call CARGA_GRILLA_LOG()
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
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classPicking.cnn = _cnn
            classPicking.pic_codigo = _pic_codigo

            ds = classPicking.PICKING_CARGA_DETALLE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaDetalle.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("sku_cartera_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(False, 0,
                                                   ds.Tables(0).Rows(Fila)("pic_fila"),
                                                   ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                                   ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                   ds.Tables(0).Rows(Fila)("sku_cartera"),
                                                   ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                                   FormatNumber(ds.Tables(0).Rows(Fila)("disponible"), 0),
                                                   FormatNumber(ds.Tables(0).Rows(Fila)("cantidad"), 0),
                                                   FormatNumber(ds.Tables(0).Rows(Fila)("nuumero_bultos"), 0),
                                                   FormatNumber(ds.Tables(0).Rows(Fila)("total_bulto"), 0),
                                                   ds.Tables(0).Rows(Fila)("pro_codigooriginal"),
                                                   ds.Tables(0).Rows(Fila)("existentes"),
                                                   ds.Tables(0).Rows(Fila)("observacion"),
                                                   ds.Tables(0).Rows(Fila)("pro_codigoactual"),
                                                   ds.Tables(0).Rows(Fila)("pro_codigointernooriginal"),
                                                   ds.Tables(0).Rows(Fila)("pro_nombreoriginal"),
                                                   FormatNumber(ds.Tables(0).Rows(Fila)("pro_numerobultosoriginal"), 0),
                                                   ds.Tables(0).Rows(Fila)("pic_codigo"),
                                                   ds.Tables(0).Rows(Fila)("nueva_fila"),
                                                   ds.Tables(0).Rows(Fila)("precio"),
                                                   ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                                   ds.Tables(0).Rows(Fila)("pic_fechaoc"),
                                                   ds.Tables(0).Rows(Fila)("con_codigounico"),
                                                   ds.Tables(0).Rows(Fila)("pic_filadevuelta"),
                                                   ds.Tables(0).Rows(Fila)("pic_conubicacion"))

                            If ds.Tables(0).Rows(Fila)("pic_conubicacion") = True Then
                                GrillaDetalle.Item(col_EXISTENTES, Fila).Style.BackColor = Color.FromArgb(246, 181, 97)
                            End If

                            Fila = Fila + 1
                        Loop
                        Call PINTA_GRILLA_CODIGOS_DISTINTOS()
                        Call PINTA_GRILLA_CODIGOS_NUEVOS()
                        Call PINTA_GRILLA_ENCBEZADO()
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

    Private Sub PINTA_GRILLA_CODIGOS_DISTINTOS()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows

            If row.Cells(col_CODIGO_INTERNO_ORIGINAL).Value <> row.Cells(col_NEW_CODIGO).Value Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
                row.DefaultCellStyle.ForeColor = Color.Orange
            End If

        Next
    End Sub

    Private Sub CARGA_GRILLA_LOG()
        Dim classPicking As class_picking = New class_picking

        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim usuario As String = ""
        Try
            classPicking.cnn = _cnn
            classPicking.pic_codigo = _pic_codigo

            ds = classPicking.PICKING_CARGA_LOG(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaLog.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("lpi_descripcion") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            usuario = BUSCAR_NOMBRE_USUARIO(ds.Tables(0).Rows(Fila)("usu_codigo"))


                            GrillaLog.Rows.Add(ds.Tables(0).Rows(Fila)("lpi_codigo"),
                                               ds.Tables(0).Rows(Fila)("pic_codigo"),
                                               ds.Tables(0).Rows(Fila)("lpi_descripcion"),
                                               ds.Tables(0).Rows(Fila)("usu_codigo"),
                                               usuario,
                                               ds.Tables(0).Rows(Fila)("lpi_fechahora"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_LOG", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_LOG", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function BUSCAR_NOMBRE_USUARIO(ByVal cod_usuario As Integer) As String
        Dim classUsuario As class_usuario = New class_usuario
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            BUSCAR_NOMBRE_USUARIO = ""
            classUsuario.cnn = _cnn
            classUsuario.usu_codigo = cod_usuario
            ds = classUsuario.CARGA_DATOS_USUARIO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("nombreUsuario") <> "" Then
                        BUSCAR_NOMBRE_USUARIO = ds.Tables(0).Rows(Fila)("nombreUsuario")
                    End If
                End If
            Else
                BUSCAR_NOMBRE_USUARIO = ""
                MessageBox.Show(_msgError + "\BUSCAR_NOMBRE_USUARIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            BUSCAR_NOMBRE_USUARIO = ""
            MessageBox.Show(ex.Message + "\BUSCAR_NOMBRE_USUARIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub INICAILIZA()
        listaPalletPickeado = New List(Of estructura_pallet)()
        listaPalletPickeadoAuxiliar = New List(Of estructura_pallet)()
        GLO_CANTIDAD_UNIDADES_SELECCIONADAS = 0

        lblCodigoInterno.Text = ""
        lblNombreFavatex.Text = ""
        lblOriginalInterno.Text = ""
        lblOriginalNombreFavatex.Text = ""

        lblOriginalInterno.Text = ""
        lblOriginalNombreFavatex.Text = ""

        Me.GrillaDetalle.Columns(col_EXISTENTES).ReadOnly = True
        Me.GrillaDetalle.Columns(col_OBSERVACIONES).ReadOnly = True

        Call CARGA_COMBO_CLIENTE()
        Call CARGA_COMBO_ESADO()
        Call CARGA_COMBO_PERSONAS()

        ButtonDev.Visible = False
        Separador1.Visible = False

    End Sub

    Private Sub CARGA_COMBO_CLIENTE()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
            If _msg = "" Then
                Me.cmbCliente.DataSource = ds.Tables(0)
                Me.cmbCliente.DisplayMember = "MENSAJE"
                Me.cmbCliente.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_BOLETA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_ESADO()
        Dim _msg As String
        Try
            Dim classComunes As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classComunes.cnn = _cnn
            _msg = ""
            ds = classComunes.CRGA_COMBO_ESTADO_PICKING(_msg)
            If _msg = "" Then
                Me.cmbEstado.DataSource = ds.Tables(0)
                Me.cmbEstado.DisplayMember = "MENSAJE"
                Me.cmbEstado.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ESADO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_PERSONAS()
        Dim _msg As String
        Try
            Dim classPersonas As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classPersonas.cnn = _cnn
            _msg = ""
            ds = classPersonas.CRGA_COMBO_PERSONAS(_msg)
            If _msg = "" Then
                Me.cmbPersonas.DataSource = ds.Tables(0)
                Me.cmbPersonas.DisplayMember = "MENSAJE"
                Me.cmbPersonas.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PERSONAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonEditar_Click(sender As Object, e As EventArgs) Handles ButtonEditar.Click
        txtHora.Enabled = True
        cmbPersonas.Enabled = True
        dtpFechaDespacho.Enabled = True
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonEnvio_Click(sender As Object, e As EventArgs) Handles ButtonEnvio.Click
        If cmbPersonas.Text = "" Then
            MessageBox.Show("Debe seleccionar una persona para asignar un picking", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call ASIGNA_PICKING()
    End Sub

    Private Sub ASIGNA_PICKING()
        Dim classComunes As class_comunes = New class_comunes
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                classComunes.cnn = _cnn
                classComunes.per_codigo = cmbPersonas.SelectedValue
                ds = classComunes.CARGA_DATOS_PERONA(_msgError, conexion)
                If _msgError = "" Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("nombrePersona") <> "" Then
                            nombreResponsable = ds.Tables(0).Rows(0)("nombrePersona")
                        End If
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError + "\GENERA_PICKING", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Picking asignado a: " + nombreResponsable
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.pic_hora = txtHora.Text
                classPicking.per_codigoresponsable = cmbPersonas.SelectedValue()

                ds = classPicking.PICKING_ACTUALIZA_ENCABEZADO(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If


                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.epc_codigo = ESTADOS_PICKING.En_proceso
                ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
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
                Me.Cursor = Cursors.Default

                Call CARGA_DATOS_ENCABEZADO()
                Call CARGA_GRILLA_LOG()
                Call habilita_botonera()

                MessageBox.Show("El picking N°: " + txtNumero.Text + " ha sigo asignado a " + " " + cmbPersonas.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonAnula_Click(sender As Object, e As EventArgs) Handles ButtonAnula.Click
        Dim respuesta As Integer

        respuesta = MessageBox.Show("¿Esta seguro(a) de alular el picking N°: " + txtNumero.Text + "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

        If respuesta = vbYes Then
            Call ANULA_PICKING()
        End If

    End Sub

    Private Sub ANULA_PICKING()
        Dim classComunes As class_comunes = New class_comunes
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Anula picking"
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.epc_codigo = ESTADOS_PICKING.Nulo
                ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
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
                Me.Cursor = Cursors.Default

                Call CARGA_DATOS_ENCABEZADO()
                Call CARGA_GRILLA_LOG()
                Call habilita_botonera()

                MessageBox.Show("El picking N°: " + txtNumero.Text + " ha sigo anulado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonFinaliza_Click(sender As Object, e As EventArgs) Handles ButtonFinaliza.Click
        Call FINALIZA_PICKING()
    End Sub

    Private Sub FINALIZA_PICKING()
        Dim classComunes As class_comunes = New class_comunes
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim conDiferencia As Boolean = False

        Try

            Do While fila <= GrillaDetalle.Rows.Count - 1
                If (GrillaDetalle.Rows(fila).Cells(col_EXISTENTES).Value = 0) And (GrillaDetalle.Rows(fila).Cells(col_FILA_DEVULETA).Value) = False Then
                    MessageBox.Show("El producto: [" + GrillaDetalle.Rows(fila).Cells(col_CODIGO_INTERNO).Value.ToString + "] - [" + GrillaDetalle.Rows(fila).Cells(col_NOMBRE_FAVATEX).Value.ToString + "], Esta tratando de finalizarlo con cantidad 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If (CInt(GrillaDetalle.Rows(fila).Cells(col_CANTIDAD).Value) < CInt(GrillaDetalle.Rows(fila).Cells(col_EXISTENTES).Value)) And (GrillaDetalle.Rows(fila).Cells(col_FILA_DEVULETA).Value) = False Then
                    MessageBox.Show("El producto: [" + GrillaDetalle.Rows(fila).Cells(col_CODIGO_INTERNO).Value.ToString + "] - [" + GrillaDetalle.Rows(fila).Cells(col_NOMBRE_FAVATEX).Value.ToString + "], con cantidad mayor a la solicitada", Me.Text + " koba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                fila = fila + 1
            Loop


            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)

                ds = Nothing
                'classPicking.pic_codigo = _pic_codigo
                'ds = classPicking.PICKING_ELIMINA_DATOS_DETALLE(_msgError, conexion)
                'If _msgError <> "" Then
                '    If conexion.State = ConnectionState.Open Then
                '        conexion.Close()
                '    End If
                '    ds = Nothing
                '    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'Else
                '    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                '        If conexion.State = ConnectionState.Open Then
                '            conexion.Close()
                '        End If
                '        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        ds = Nothing
                '        Exit Sub
                '    End If
                'End If

                ds = Nothing
                'classPicking.cnn = _cnn
                fila = 0
                Do While fila <= GrillaDetalle.Rows.Count - 1
                    classPicking.pic_codigo = _pic_codigo
                    classPicking.pic_fila = GrillaDetalle.Rows(fila).Cells(col_FIL).Value
                    classPicking.pro_codigo = GrillaDetalle.Rows(fila).Cells(col_NEW_CODIGO).Value
                    classPicking.pro_nombre = GrillaDetalle.Rows(fila).Cells(col_NOMBRE_FAVATEX).Value
                    classPicking.pic_cantidad = GrillaDetalle.Rows(fila).Cells(col_CANTIDAD).Value
                    classPicking.pic_num_bultos = GrillaDetalle.Rows(fila).Cells(col_NBXU).Value
                    classPicking.pic_total_bultos = GrillaDetalle.Rows(fila).Cells(col_TBULTOS).Value
                    classPicking.pic_cantidad_encontrada = IIf(GrillaDetalle.Rows(fila).Cells(col_FILA_DEVULETA).Value = False, GrillaDetalle.Rows(fila).Cells(col_EXISTENTES).Value, 0)
                    classPicking.pic_num_bultos_encontrado = GrillaDetalle.Rows(fila).Cells(col_NBXU).Value
                    classPicking.pic_total_bultos_encontrado = FormatNumber(GrillaDetalle.Rows(fila).Cells(col_EXISTENTES).Value * GrillaDetalle.Rows(fila).Cells(col_NBXU).Value, 0)
                    classPicking.pro_codigooriginal = GrillaDetalle.Rows(fila).Cells(col_CODIGO_INTERNO_ORIGINAL).Value
                    classPicking.observaciones = IIf(GrillaDetalle.Rows(fila).Cells(col_OBSERVACIONES).Value = "", "-", GrillaDetalle.Rows(fila).Cells(col_OBSERVACIONES).Value)
                    classPicking.nuevaFila = IIf(GrillaDetalle.Rows(fila).Cells(col_NUEVA).Value = 0, False, True)
                    classPicking.sku_cartera = GrillaDetalle.Rows(fila).Cells(col_SKU_CLIENTE).Value
                    classPicking.sku_cartera_nombre = GrillaDetalle.Rows(fila).Cells(col_SKU_NOMBRE).Value
                    classPicking.precio = GrillaDetalle.Rows(fila).Cells(col_PRECIO_UNITARIO).Value
                    classPicking.pic_ocnumero = GrillaDetalle.Rows(fila).Cells(col_OC_ORIGEN).Value
                    classPicking.pic_fechaoc = GrillaDetalle.Rows(fila).Cells(col_FECHA_OC).Value
                    classPicking.con_codigounico = GrillaDetalle.Rows(fila).Cells(col_COD_UNICO).Value
                    _msgError = ""

                    ds = classPicking.PICKING_ACTUALIZA_DETALLE(_msgError, conexion)
                    If _msgError = "" Then
                        If ds.Tables.Count > 0 Then
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State <> ConnectionState.Closed Then
                                    conexion.Close()
                                End If
                                conexion.Dispose()
                                ds.Dispose()
                                MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    Else
                        If conexion.State <> ConnectionState.Closed Then
                            conexion.Close()
                        End If
                        conexion.Dispose()
                        ds.Dispose()
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    ds = Nothing

                    fila = fila + 1
                Loop


                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                If VALIDA_CANTIDADES() = False Then
                    classPicking.lpi_descripcion = "Finaliza picking con diferencia"
                    conDiferencia = True
                Else
                    classPicking.lpi_descripcion = "Finaliza picking sin diferencia"
                    conDiferencia = False
                End If

                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo

                'If VALIDA_CANTIDADES() = False Then
                If conDiferencia = True Then
                    classPicking.epc_codigo = ESTADOS_PICKING.Finalizado_con_diferenia
                Else
                    classPicking.epc_codigo = ESTADOS_PICKING.Finalizado_sin_diferencia
                End If

                ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
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
                Me.Cursor = Cursors.Default

                Call CARGA_DATOS_ENCABEZADO()
                Call CARGA_GRILLA_LOG()
                Call habilita_botonera()



                If conDiferencia = True Then
                    MessageBox.Show("El picking N°: " + txtNumero.Text + " fue finalizado con diferencia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("El picking N°: " + txtNumero.Text + " fue finalizado sin diferencia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function VALIDA_CANTIDADES() As Boolean
        Dim fila As Integer = 0
        Dim CantidadSolicitada As Integer = 0
        Dim CantidadEncontrada As Integer = 0

        VALIDA_CANTIDADES = False

        Try
            For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
                If row.Cells(col_FILA_DEVULETA).Value = False Then
                    CantidadSolicitada = CantidadSolicitada + row.Cells(col_CANTIDAD).Value
                    CantidadEncontrada = CantidadEncontrada + row.Cells(col_EXISTENTES).Value
                Else
                    row.Cells(col_EXISTENTES).Value = 0
                End If
            Next

            If CantidadEncontrada = 0 Then
                VALIDA_CANTIDADES = False
            Else
                If CantidadSolicitada = CantidadEncontrada Then
                    VALIDA_CANTIDADES = True
                Else
                    VALIDA_CANTIDADES = False
                End If
            End If
        Catch ex As Exception
            VALIDA_CANTIDADES = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GrillaDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellContentClick



        'If e.ColumnIndex = 2 Then
        '    Dim frm As frm_listado_productos_relacionados = New frm_listado_productos_relacionados
        '    Dim codigo As Integer = 0
        '    Dim _msgError As String = ""
        '    Dim ds As DataSet

        '    Try
        '        If cmbEstado.SelectedValue <> ESTADOS_PICKING.Generado And cmbEstado.SelectedValue <> ESTADOS_PICKING.En_proceso Then
        '            Exit Sub
        '        End If


        '        codigo = GrillaDetalle.Rows(e.RowIndex).Cells(13).Value

        '        frm.cnn = _cnn
        '        frm.pro_codigo = codigo
        '        frm.ShowDialog()

        '        If GLO_CODIGO_PRODUCTOS > 0 Then
        '            Dim class_producto As class_producto = New class_producto
        '            class_producto.cnn = _cnn
        '            class_producto.pro_codigo = GLO_CODIGO_PRODUCTOS
        '            ds = class_producto.PRODUCTOS_BUSQUEDA(_msgError)
        '            If _msgError = "" Then
        '                If ds.Tables(0).Rows.Count > 0 Then
        '                    If ds.Tables(0).Rows(0)("pro_nombre") <> "" Then
        '                        GrillaDetalle.Rows(e.RowIndex).Cells(2).Value = ds.Tables(0).Rows(0)("pro_codigointerno")
        '                        GrillaDetalle.Rows(e.RowIndex).Cells(3).Value = ds.Tables(0).Rows(0)("pro_nombre")
        '                        GrillaDetalle.Rows(e.RowIndex).Cells(8).Value = ds.Tables(0).Rows(0)("pro_numerobulto")
        '                        GrillaDetalle.Rows(e.RowIndex).Cells(9).Value = FormatNumber((ds.Tables(0).Rows(0)("pro_numerobulto") * GrillaDetalle.Rows(e.RowIndex).Cells(7).Value), 0)
        '                        GrillaDetalle.Rows(e.RowIndex).Cells(13).Value = ds.Tables(0).Rows(0)("pro_codigo")
        '                    End If
        '                End If
        '                Call PINTA_GRILLA_CODIGOS_DISTINTOS()
        '                'GrillaNotaria.AutoResizeColumns()
        '            Else
        '                MessageBox.Show(_msgError + "\BSCAR_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            End If

        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If
    End Sub

    Private Sub GrillaDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellEnter
        Try
            lblCodigoInterno.Text = GrillaDetalle.Rows(e.RowIndex).Cells(col_CODIGO_INTERNO).Value
            lblNombreFavatex.Text = GrillaDetalle.Rows(e.RowIndex).Cells(col_NOMBRE_FAVATEX).Value
            lblOriginalInterno.Text = GrillaDetalle.Rows(e.RowIndex).Cells(col_COD_INT_ORI).Value
            lblOriginalNombreFavatex.Text = GrillaDetalle.Rows(e.RowIndex).Cells(col_NOMBRE_ORI).Value
            _conUbicacion = GrillaDetalle.Rows(e.RowIndex).Cells(25).Value
            _proCodigo = GrillaDetalle.Rows(e.RowIndex).Cells(11).Value
            _proNombre = GrillaDetalle.Rows(e.RowIndex).Cells(col_NOMBRE_FAVATEX).Value
            _proCantidad = GrillaDetalle.Rows(e.RowIndex).Cells(col_CANTIDAD).Value
            _filaSeleccionada = e.RowIndex
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        Call GUARDAR_DATOS()
    End Sub

    Private Sub GUARDAR_DATOS()
        Dim classComunes As class_comunes = New class_comunes
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim conDiferencia As Boolean = False

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                ds = Nothing

                For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
                    row.Cells(col_FECHA_OC).Value = dtpFechaDespacho.Value
                Next


                Do While fila <= GrillaDetalle.Rows.Count - 1
                    classPicking.pic_codigo = _pic_codigo
                    classPicking.pic_fila = GrillaDetalle.Rows(fila).Cells(col_FIL).Value
                    classPicking.pro_codigo = GrillaDetalle.Rows(fila).Cells(col_NEW_CODIGO).Value
                    classPicking.pro_nombre = GrillaDetalle.Rows(fila).Cells(col_NOMBRE_FAVATEX).Value
                    classPicking.pic_cantidad = GrillaDetalle.Rows(fila).Cells(col_CANTIDAD).Value
                    classPicking.pic_num_bultos = GrillaDetalle.Rows(fila).Cells(col_NBXU).Value
                    classPicking.pic_total_bultos = GrillaDetalle.Rows(fila).Cells(col_TBULTOS).Value
                    classPicking.pic_cantidad_encontrada = GrillaDetalle.Rows(fila).Cells(col_EXISTENTES).Value
                    classPicking.pic_num_bultos_encontrado = GrillaDetalle.Rows(fila).Cells(col_NBXU).Value
                    classPicking.pic_total_bultos_encontrado = FormatNumber(GrillaDetalle.Rows(fila).Cells(col_EXISTENTES).Value * GrillaDetalle.Rows(fila).Cells(col_NBXU).Value, 0)
                    classPicking.pro_codigooriginal = GrillaDetalle.Rows(fila).Cells(col_CODIGO_INTERNO_ORIGINAL).Value
                    classPicking.observaciones = IIf(GrillaDetalle.Rows(fila).Cells(col_OBSERVACIONES).Value = "", "-", GrillaDetalle.Rows(fila).Cells(col_OBSERVACIONES).Value)
                    classPicking.nuevaFila = IIf(GrillaDetalle.Rows(fila).Cells(col_NUEVA).Value = 0, False, True)
                    classPicking.sku_cartera = GrillaDetalle.Rows(fila).Cells(col_SKU_CLIENTE).Value
                    classPicking.sku_cartera_nombre = GrillaDetalle.Rows(fila).Cells(col_SKU_NOMBRE).Value
                    classPicking.precio = GrillaDetalle.Rows(fila).Cells(col_PRECIO_UNITARIO).Value
                    classPicking.pic_ocnumero = GrillaDetalle.Rows(fila).Cells(col_OC_ORIGEN).Value
                    classPicking.pic_fechaoc = GrillaDetalle.Rows(fila).Cells(col_FECHA_OC).Value
                    classPicking.con_codigounico = GrillaDetalle.Rows(fila).Cells(col_COD_UNICO).Value
                    _msgError = ""

                    ds = classPicking.PICKING_ACTUALIZA_DETALLE(_msgError, conexion)
                    If _msgError = "" Then
                        If ds.Tables.Count > 0 Then
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
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
                    fila = fila + 1
                Loop

                If (cmbEstado.SelectedValue = ESTADOS_PICKING.Finalizado_con_diferenia) Or (cmbEstado.SelectedValue = ESTADOS_PICKING.Finalizado_sin_diferencia) Then
                    classPicking.cnn = _cnn
                    classPicking.pic_codigo = _pic_codigo
                    classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                    If VALIDA_CANTIDADES() = False Then
                        classPicking.lpi_descripcion = "Finaliza picking con diferencia - [Corrige cantidades]"
                        conDiferencia = True
                    Else
                        classPicking.lpi_descripcion = "Finaliza picking sin diferencia - [Corrige cantidades]"
                        conDiferencia = False
                    End If

                    ds = Nothing
                    ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                            ds = Nothing
                            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If

                    ds = Nothing
                    classPicking.cnn = _cnn
                    classPicking.pic_codigo = _pic_codigo

                    'If VALIDA_CANTIDADES() = False Then
                    If conDiferencia = True Then
                        classPicking.epc_codigo = ESTADOS_PICKING.Finalizado_con_diferenia
                    Else
                        classPicking.epc_codigo = ESTADOS_PICKING.Finalizado_sin_diferencia
                    End If

                    ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
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
                            ds = Nothing
                            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
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

                Call CARGA_DATOS_ENCABEZADO()
                Call CARGA_GRILLA_LOG()
                Call habilita_botonera()
                MessageBox.Show("Los datos fueron guardados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked = True Then
            For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
                row.Cells(col_EXISTENTES).Value = row.Cells(col_CANTIDAD).Value
            Next
        Else
            For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
                row.Cells(col_EXISTENTES).Value = 0
            Next
        End If
    End Sub

    Private Sub ModificaElCódigoParaLaLíneaCompletaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaElCódigoParaLaLíneaCompletaToolStripMenuItem.Click
        'GLO_PRUEBA_DESARROLLO = True
        'If GLO_PRUEBA_DESARROLLO = True Then
        '    Call BUSCA_PRODUCTO_REEMPLAZO_NEW()
        'Else

        If cmbEstado.SelectedValue > ESTADOS_PICKING.Finalizado_sin_diferencia Then
            MessageBox.Show("El estado del documento no es compatible para esta operación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call BUSCA_PRODUCTO_REEMPLAZO()
        'End If
    End Sub

    Private Sub BUSCA_PRODUCTO_REEMPLAZO_NEW()
        Dim frm As frm_listados_productos_reemplazo = New frm_listados_productos_reemplazo
        Dim codigo As Integer = 0
        Dim _msgError As String = ""
        Dim ds As DataSet

        Try
            'If cmbEstado.SelectedValue <> ESTADOS_PICKING.Generado And cmbEstado.SelectedValue <> ESTADOS_PICKING.En_proceso Then
            '    Exit Sub
            'End If

            codigo = GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value

            frm.cnn = _cnn
            frm.pro_codigo = codigo
            frm.ShowDialog()

            GrillaDetalle.Rows(_fila).Cells(col_OBSERVACIONES).Value = "PRODUCTO ORIGINAL: [" + GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value + " - " + GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value + "]"

            If GLO_CODIGO_PRODUCTOS > 0 Then
                Dim class_producto As class_producto = New class_producto
                class_producto.cnn = _cnn
                class_producto.pro_codigo = GLO_CODIGO_PRODUCTOS
                ds = class_producto.PRODUCTOS_BUSQUEDA(_msgError)
                If _msgError = "" Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("pro_nombre") <> "" Then
                            GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value = ds.Tables(0).Rows(0)("pro_codigointerno")
                            GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value = ds.Tables(0).Rows(0)("pro_nombre")
                            GrillaDetalle.Rows(_fila).Cells(col_NBXU).Value = ds.Tables(0).Rows(0)("pro_numerobulto")
                            GrillaDetalle.Rows(_fila).Cells(col_TBULTOS).Value = FormatNumber((ds.Tables(0).Rows(0)("pro_numerobulto") * GrillaDetalle.Rows(_fila).Cells(col_CANTIDAD).Value), 0)
                            GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value = ds.Tables(0).Rows(0)("pro_codigo")

                            lblCodigoInterno.Text = GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value
                            lblNombreFavatex.Text = GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value
                        End If
                    End If
                    Call PINTA_GRILLA_CODIGOS_DISTINTOS()
                    Call PINTA_GRILLA_CODIGOS_NUEVOS()
                    'GrillaNotaria.AutoResizeColumns()
                Else
                    MessageBox.Show(_msgError + "\BSCAR_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'MessageBox.Show(GrillaDetalle.Rows(_fila).Cells(_colum).Value)
    End Sub

    Private Sub BUSCA_PRODUCTO_REEMPLAZO()
        Dim frm As frm_listado_productos_relacionados = New frm_listado_productos_relacionados
        Dim codigo As Integer = 0
        Dim _msgError As String = ""
        Dim ds As DataSet

        Try
            If cmbEstado.SelectedValue <> ESTADOS_PICKING.Generado And cmbEstado.SelectedValue <> ESTADOS_PICKING.En_proceso Then
                Exit Sub
            End If

            codigo = GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value

            frm.cnn = _cnn
            frm.pro_codigo = codigo
            frm.ShowDialog()

            GrillaDetalle.Rows(_fila).Cells(col_OBSERVACIONES).Value = "PRODUCTO ORIGINAL: [" + GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value + " - " + GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value + "]"

            If GLO_CODIGO_PRODUCTOS > 0 Then
                Dim class_producto As class_producto = New class_producto
                class_producto.cnn = _cnn
                class_producto.pro_codigo = GLO_CODIGO_PRODUCTOS
                ds = class_producto.PRODUCTOS_BUSQUEDA(_msgError)
                If _msgError = "" Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("pro_nombre") <> "" Then
                            GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value = ds.Tables(0).Rows(0)("pro_codigointerno")
                            GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value = ds.Tables(0).Rows(0)("pro_nombre")
                            GrillaDetalle.Rows(_fila).Cells(col_NBXU).Value = ds.Tables(0).Rows(0)("pro_numerobulto")
                            GrillaDetalle.Rows(_fila).Cells(col_TBULTOS).Value = FormatNumber((ds.Tables(0).Rows(0)("pro_numerobulto") * GrillaDetalle.Rows(_fila).Cells(col_CANTIDAD).Value), 0)
                            GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value = ds.Tables(0).Rows(0)("pro_codigo")

                            lblCodigoInterno.Text = GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value
                            lblNombreFavatex.Text = GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value
                        End If
                    End If
                    Call PINTA_GRILLA_CODIGOS_DISTINTOS()
                    Call PINTA_GRILLA_CODIGOS_NUEVOS()
                    'GrillaNotaria.AutoResizeColumns()
                Else
                    MessageBox.Show(_msgError + "\BSCAR_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'MessageBox.Show(GrillaDetalle.Rows(_fila).Cells(_colum).Value)
    End Sub


    Private Sub GrillaDetalle_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GrillaDetalle.CellMouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            _colum = e.ColumnIndex
            _fila = e.RowIndex
        End If
    End Sub

    Private Sub GeneraUnaNuevaLíenaAPartirDeLaSeleccionadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraUnaNuevaLíenaAPartirDeLaSeleccionadaToolStripMenuItem.Click
        Dim frm As frm_gnera_fila_picking = New frm_gnera_fila_picking
        Dim _msgError As String = ""
        Dim COD_INTERNO As String = ""
        Dim ds As DataSet
        Try
            If cmbEstado.SelectedValue > ESTADOS_PICKING.Finalizado_sin_diferencia Then
                MessageBox.Show("El estado del documento no es compatible para esta operación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            frm.cnn = _cnn
            frm.pro_codigo = GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value
            frm.pro_nombre = GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value
            frm.cantidad = GrillaDetalle.Rows(_fila).Cells(col_CANTIDAD).Value
            frm.num_bultos = GrillaDetalle.Rows(_fila).Cells(col_NBXU).Value

            GLO_CODIGO_PRODUCTOS = 0
            GLO_CANTIDAD_PRODUCTOS = 0
            GLO_NOMBRE_PRODUCTOS = ""
            GLO_NUMERO_BULTOS_PRODUCTOS = 0

            frm.ShowDialog()
            'FormatNumber(GLO_CANTIDAD_PRODUCTOS, 0),
            If GLO_CODIGO_PRODUCTOS > 0 Then
                Dim class_producto As class_producto = New class_producto
                class_producto.cnn = _cnn
                class_producto.pro_codigo = GLO_CODIGO_PRODUCTOS
                ds = class_producto.PRODUCTOS_BUSQUEDA(_msgError)
                If _msgError = "" Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("pro_nombre") <> "" Then
                            COD_INTERNO = ds.Tables(0).Rows(0)("pro_codigointerno")
                            ''GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value = ds.Tables(0).Rows(0)("pro_nombre")
                            GLO_NUMERO_BULTOS_PRODUCTOS = ds.Tables(0).Rows(0)("pro_numerobulto")
                            ''GrillaDetalle.Rows(_fila).Cells(col_TBULTOS).Value = FormatNumber((ds.Tables(0).Rows(0)("pro_numerobulto") * GrillaDetalle.Rows(_fila).Cells(col_CANTIDAD).Value), 0)
                            ''GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value = ds.Tables(0).Rows(0)("pro_codigo")

                            ''lblCodigoInterno.Text = GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value
                            ''lblNombreFavatex.Text = GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value
                        End If
                    End If
                    ''Call PINTA_GRILLA_CODIGOS_DISTINTOS()
                    ''Call PINTA_GRILLA_CODIGOS_NUEVOS()
                    'GrillaNotaria.AutoResizeColumns()
                Else
                    MessageBox.Show(_msgError + "\BSCAR_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


                GrillaDetalle.Rows(_fila).Cells(col_CANTIDAD).Value = GrillaDetalle.Rows(_fila).Cells(col_CANTIDAD).Value - GLO_CANTIDAD_PRODUCTOS
                'GrillaDetalle.Rows(_fila).Cells(col_EXISTENTES).Value = GrillaDetalle.Rows(_fila).Cells(col_CANTIDAD).Value
                GrillaDetalle.Rows.Add(False, cmbCliente.SelectedValue,
                                       0,
                                       COD_INTERNO,
                                       GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value, GrillaDetalle.Rows(_fila).Cells(col_SKU_CLIENTE).Value,
                                       GrillaDetalle.Rows(_fila).Cells(col_SKU_NOMBRE).Value, 0,
                                       FormatNumber(GLO_CANTIDAD_PRODUCTOS, 0),
                                       FormatNumber(GLO_NUMERO_BULTOS_PRODUCTOS, 0),
                                       FormatNumber(GLO_CANTIDAD_PRODUCTOS * GLO_NUMERO_BULTOS_PRODUCTOS, 0),
                                       GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value,
                                       0,
                                       "SE REEMPLAZAN " + FormatNumber(GLO_CANTIDAD_PRODUCTOS, 0).ToString + " CANTIDADES DEL CODIGO: " + GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value,
                                       GLO_CODIGO_PRODUCTOS, 'GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value,
                                       GrillaDetalle.Rows(_fila).Cells(col_CODIGO_INTERNO).Value, 'GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value,
                                       GrillaDetalle.Rows(_fila).Cells(col_NOMBRE_FAVATEX).Value,
                                       GrillaDetalle.Rows(_fila).Cells(col_NBXU).Value,
                                       pic_codigo,
                                       1,
                                       GrillaDetalle.Rows(_fila).Cells(col_PRECIO_UNITARIO).Value,
                                       GrillaDetalle.Rows(_fila).Cells(col_OC_ORIGEN).Value,
                                       GrillaDetalle.Rows(_fila).Cells(col_FECHA_OC).Value,
                                       GrillaDetalle.Rows(_fila).Cells(col_COD_UNICO).Value)
                Call PINTA_GRILLA_CODIGOS_NUEVOS()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PINTA_GRILLA_CODIGOS_NUEVOS()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
            If row.Cells(col_NUEVA).Value = "1" Then
                row.DefaultCellStyle.BackColor = Color.AliceBlue
                row.DefaultCellStyle.ForeColor = Color.DarkSlateGray
            End If
        Next
    End Sub

    Private Sub ButtonEnviadaFacturar_Click(sender As Object, e As EventArgs) Handles ButtonEnviadaFacturar.Click
        Dim respuesta As Integer

        If ENCUENTRA_VALOR_CERO() = True Then
            MessageBox.Show("Esta enviando a facturar unidades en 0, " _
            + Chr(10) + "debe quitar la fila del picking o eliminarla dependiendo del caso con el boton derecho del mause posecionandose en el código interno ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        respuesta = MessageBox.Show("¿Esta seguro(a) de enviar a facturar el picking N°: " + txtNumero.Text + "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = vbYes Then
            Call ENVIA_A_FACTURAR()
        End If
    End Sub

    Private Function ENCUENTRA_VALOR_CERO() As Boolean
        Dim contador As Integer = 0
        ENCUENTRA_VALOR_CERO = False
        Try
            For Each row2 As DataGridViewRow In Me.GrillaDetalle.Rows
                If (row2.Cells(col_EXISTENTES).Value = 0) And (row2.Cells(col_FILA_DEVULETA).Value <> True) Then
                    contador = contador + 1
                End If
            Next

            If contador > 0 Then
                ENCUENTRA_VALOR_CERO = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Function


    Private Sub ENVIA_A_FACTURAR()
        Dim classComunes As class_comunes = New class_comunes
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Envia a facturar"
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.epc_codigo = ESTADOS_PICKING.Enviado_a_facturar
                ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
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
                Me.Cursor = Cursors.Default

                Call CARGA_DATOS_ENCABEZADO()
                Call CARGA_GRILLA_LOG()
                Call habilita_botonera()

                MessageBox.Show("El picking N°: " + txtNumero.Text + " ha sigo enviado a facturar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        Dim frm As frm_imprimir = New frm_imprimir
        frm.Origen = "PK"
        frm.pic_codigo = _pic_codigo
        frm.ShowDialog()
    End Sub

    Private Sub EliminarProductoDelPickingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarProductoDelPickingToolStripMenuItem.Click
        Dim classDev As class_devolucion = New class_devolucion
        Dim classPicking As class_picking = New class_picking
        Dim codigo As Integer = 0
        Dim _msgError As String = ""
        Dim respuesta As Integer = 0
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim ds As DataSet

        Try
            If cmbEstado.SelectedValue > ESTADOS_PICKING.Finalizado_sin_diferencia Then
                MessageBox.Show("El estado del documento no es compatible para esta operación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                respuesta = MessageBox.Show("¿Esta seguro(a) de eliminar la fila seleccionada?." _
                                         + Chr(10) + "Este item quedara disponible para poder incluirla en un siguiete picking", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbNo Then
                    Exit Sub
                End If

                codigo = GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value
                GrillaDetalle.Rows(_fila).Cells(col_FILA_DEVULETA).Value = True

                classDev.cnn = _cnn
                classDev.pic_codigo = CLng(txtNumero.Text)
                classDev.dev_ocompra = GrillaDetalle.Rows(_fila).Cells(col_OC_ORIGEN).Value
                classDev.sku_cliente = GrillaDetalle.Rows(_fila).Cells(col_SKU_CLIENTE).Value
                classDev.dev_codunico = GrillaDetalle.Rows(_fila).Cells(col_COD_UNICO).Value
                classDev.dev_cantidad = GrillaDetalle.Rows(_fila).Cells(col_CANTIDAD).Value
                ds = classDev.DEVOLUCION_PRODUCTO_ORDEN_CONSOLIDADO(_msgError, conexion)
                If _msgError = "" Then
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            ds.Dispose()
                            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                Else
                    If conexion.State <> ConnectionState.Closed Then
                        conexion.Close()
                    End If
                    conexion.Dispose()
                    ds.Dispose()
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ds = Nothing

                classPicking.pic_codigo = CLng(txtNumero.Text)
                classPicking.pic_fila = GrillaDetalle.Rows(_fila).Cells(col_FIL).Value
                classPicking.observaciones = "Item disponible para picking"
                ds = classPicking.PICKING_QUITA_FILA(_msgError, conexion)
                If _msgError = "" Then
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            ds.Dispose()
                            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                Else
                    If conexion.State <> ConnectionState.Closed Then
                        conexion.Close()
                    End If
                    conexion.Dispose()
                    ds.Dispose()
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Se deja disponible fila " + GrillaDetalle.Rows(_fila).Cells(col_FIL).Value.ToString + "del picking, para un reproceso"
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                Me.Cursor = Cursors.Default

                Call CARGA_GRILLA_DETALLE()
                Call CARGA_GRILLA_LOG()
                Call PINTA_GRILLA_ENCBEZADO()

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PINTA_GRILLA_ENCBEZADO()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows

            If row.Cells(col_FILA_DEVULETA).Value = True Then
                row.DefaultCellStyle.BackColor = Color.Silver
                row.DefaultCellStyle.ForeColor = Color.Black
            End If

        Next
    End Sub

    Private Sub EliminarItmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarItmToolStripMenuItem.Click
        Dim classDev As class_devolucion = New class_devolucion
        Dim classPicking As class_picking = New class_picking
        Dim codigo As Integer = 0
        Dim _msgError As String = ""
        Dim respuesta As Integer = 0
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim ds As DataSet

        Try
            If cmbEstado.SelectedValue > ESTADOS_PICKING.Finalizado_sin_diferencia Then
                MessageBox.Show("El estado del documento no es compatible para esta operación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                respuesta = MessageBox.Show("¿Esta seguro(a) de eliminar la fila seleccionada?." _
                                         + Chr(10) + "Este item NO quedara disponible para poder incluirla en un siguiete picking", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbNo Then
                    Exit Sub
                End If

                codigo = GrillaDetalle.Rows(_fila).Cells(col_NEW_CODIGO).Value
                GrillaDetalle.Rows(_fila).Cells(col_FILA_DEVULETA).Value = True

                ds = Nothing
                classPicking.pic_codigo = CLng(txtNumero.Text)
                classPicking.pic_fila = GrillaDetalle.Rows(_fila).Cells(col_FIL).Value
                classPicking.observaciones = "* Anulación de venta, por petición del cliente"
                ds = classPicking.PICKING_QUITA_FILA(_msgError, conexion)
                If _msgError = "" Then
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            ds.Dispose()
                            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                Else
                    If conexion.State <> ConnectionState.Closed Then
                        conexion.Close()
                    End If
                    conexion.Dispose()
                    ds.Dispose()
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Se Anula fila " + GrillaDetalle.Rows(_fila).Cells(col_FIL).Value.ToString + " del picking, por petición del cliente"
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                Me.Cursor = Cursors.Default

                Call CARGA_GRILLA_DETALLE()
                Call CARGA_GRILLA_LOG()
                Call PINTA_GRILLA_ENCBEZADO()

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonDev_Click(sender As Object, e As EventArgs) Handles ButtonDev.Click
        Dim respuesta As Integer = 0

        respuesta = MessageBox.Show("¿esta seguro(a) de hacer la devolución del picking para su modificación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = vbYes Then
            Call DEVUELVE_PICKING()
        End If

    End Sub

    Private Sub DEVUELVE_PICKING()
        Dim classComunes As class_comunes = New class_comunes
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Devuelve picking para su modificación"
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.epc_codigo = ESTADOS_PICKING.Generado
                ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
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
                Me.Cursor = Cursors.Default

                Call CARGA_DATOS_ENCABEZADO()
                Call CARGA_GRILLA_LOG()
                Call habilita_botonera()

                MessageBox.Show("El picking N°: " + txtNumero.Text + " ha sido devuelto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonDespacho_Click(sender As Object, e As EventArgs) Handles ButtonDespacho.Click
        If ENCUENTRA_VALOR_CERO() = True Then
            MessageBox.Show("Esta enviando a despachar unidades en 0, " _
            + Chr(10) + "debe quitar la fila del picking o eliminarla dependiendo del caso con el boton derecho del mause posecionandose en el código interno ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call ENVIA_A_DESPACHAR()
    End Sub

    Private Sub ENVIA_A_DESPACHAR()
        Dim classComunes As class_comunes = New class_comunes
        Dim classPicking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim nombreResponsable As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Envia a despachar con factura pendiente"
                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
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
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                'marca detalle
                classPicking.pic_codigo = _pic_codigo
                For Each row2 As DataGridViewRow In Me.GrillaDetalle.Rows
                    ds = Nothing
                    classPicking.pic_fila = row2.Cells(2).Value
                    ds = classPicking.PICKING_ACTULIZA_DETALLE_PENDIENTE_FACTURA(_msgError, conexion)
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
                Next

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.epc_codigo = ESTADOS_PICKING.Enviado_a_despachar
                ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
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
                Me.Cursor = Cursors.Default

                Call CARGA_DATOS_ENCABEZADO()
                Call CARGA_GRILLA_LOG()
                Call habilita_botonera()

                MessageBox.Show("El picking N°: " + txtNumero.Text + " ha sigo enviado a despachar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GrillaDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellDoubleClick
        If e.ColumnIndex = col_EXISTENTES Then
            If _conUbicacion = True Then
                Dim frm As frm_mant_picking_ubicaciones = New frm_mant_picking_ubicaciones
                frm.cnn = _cnn
                frm.proCodigo = _proCodigo
                frm.proNombre = _proNombre
                frm.cantidad = _proCantidad
                frm.ShowDialog()
                GrillaDetalle.Rows(_filaSeleccionada).Cells(col_EXISTENTES).Value = GLO_CANTIDAD_UNIDADES_SELECCIONADAS
                Call MUESTRA_DATOS_ARREGLO()
            End If
        End If
    End Sub
    Private Sub MUESTRA_DATOS_ARREGLO()
        MessageBox.Show(listaPalletPickeado.Count)
        For Each p As estructura_pallet In listaPalletPickeado
            MessageBox.Show(p.pallet_serie.ToString + " - " + p.pro_codigo.ToString + " - " + p.numBulto.ToString + " - " + p.cantConsumo.ToString)
        Next
    End Sub


End Class