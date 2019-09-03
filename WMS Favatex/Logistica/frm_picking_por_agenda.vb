Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_picking_por_agenda
    Private _cnn As String
    Dim bodegas As String = ""
    Dim sentencia As String = "AND c.con_despachara IN("
    Dim fechaSeleccionada As String = ""
    Dim diaPlazo As Integer = 0
    Dim _newPicking As Integer = 0
    Dim filaSeleccionada As Integer = 0
    Const COL_COD_CITA As Integer = 2
    Const COL_NUM_CITA As Integer = 3
    Const COL_FECHA_CITA As Integer = 4
    Const COL_NUM_COMPRA As Integer = 5
    Const COL_FECHA_COMPROMISO As Integer = 6
    Const COL_BODEGA_DESPACHO As Integer = 7
    Const COL_TOTAL As Integer = 8
    Const COL_ARCHIVO_ORIGEN As Integer = 9
    Const COL_CANT_NO_ENCONTRADA As Integer = 10
    Const COL_ES_DEVOLUCION As Integer = 11
    Const COL_ES_ABIERTA As Integer = 12

    Const S As Integer = 0
    Const car_codigo As Integer = 1
    Const N_OC As Integer = 2
    Const COD_UNICO As Integer = 3
    Const CODIGO_INTERNO As Integer = 4
    Const NOMBRE_FAVATEX As Integer = 5
    Const SKU_CLIENTE As Integer = 6
    Const SKU_NOMBRE As Integer = 7
    Const CANTIDAD As Integer = 8
    Const N_BULTOS_X_UNIDAD As Integer = 9
    Const T_BULTO As Integer = 10
    Const PRECIO As Integer = 11
    Const FECHA_DESPACHO As Integer = 12
    Const con_despacharanumero As Integer = 13
    Const con_despachara As Integer = 14
    Const con_local As Integer = 15
    Const con_localnombre As Integer = 16
    Const rut_cliente As Integer = 17
    Const nombre_cliente As Integer = 18
    Const con_observacion As Integer = 19
    Const SALDO As Integer = 20
    Const ENTREGA As Integer = 21
    Const BXE As Integer = 22
    Const NFILA As Integer = 23
    Const NCITA As Integer = 24
    Const PRO_CODIGO As Integer = 25
    Const FCITA As Integer = 26
    Const DES_ABIERTA As Integer = 27
    Const PDD_CODIGO As Integer = 28

    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""
    Dim LugarDespacho As String = ""

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_picking_por_agenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_01;User ID=sa;Password=S1st3m4s"
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        'chkConFecha.Checked = True
        'txtFechaDesde.Value = DateAdd(DateInterval.Day, DIAS_ANTICIPO, GLO_FECHA_SISTEMA)
        lblBodegas.Text = ""
        'Me.Grilla.Columns(4).Frozen = True
        Me.WindowState = FormWindowState.Maximized
        Me.GrillaDetalle.Columns(SKU_NOMBRE).Frozen = True
        'Me.GrillaDetalle.Columns(NOMBRE_FAVATEX).Frozen = True
        Call CARGA_COMBO_CLIENTE()
        Call CARGA_COMBO_TIPO_ENTREGA()
        'GrillaFechas.AutoResizeColumns()
        'If cmbCliente.Text <> "" Then
        '    Call CARGA_GRILLA_FECHAS()
        'End If
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

    Private Sub CARGA_COMBO_TIPO_ENTREGA()
        Dim _msg As String
        Try
            Dim classTipoPicking As class_tipo_picking = New class_tipo_picking
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classTipoPicking.cnn = _cnn
            classTipoPicking.es_ventaverde = False
            _msg = ""
            ds = classTipoPicking.TIPO_PICKING_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbTipoPicking.DataSource = ds.Tables(0)
                Me.cmbTipoPicking.DisplayMember = "MENSAJE"
                Me.cmbTipoPicking.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_BOLETA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub



    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

    End Sub

    Private Sub cmbCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCliente.SelectionChangeCommitted
        fechaSeleccionada = ""
        lblBodegas.Text = ""
        'GrillaDetalle.DataSource = Nothing
        'GrillaDetalle.Rows.Clear()
        Call CARGA_GRILLA_FECHAS()
        Call CARGA_COMBO_BODEGAS()
    End Sub

    Private Sub CARGA_COMBO_BODEGAS()
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classSolicitud.cnn = _cnn
            classSolicitud.car_codigo = cmbCliente.SelectedValue

            _msg = ""
            GrillaBodegas.Rows.Clear()
            ds = classSolicitud.CARGA_COMBO_BODEGA(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("mensaje") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaBodegas.Rows.Add(True, ds.Tables(0).Rows(Fila)("mensaje"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_COMBO_BODEGAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_BODEGAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_FECHAS()
        Dim classAgenda As class_agendanew = New class_agendanew
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim mes2 As String = ""
        Dim dia2 As String = ""
        Dim diaActual As Integer = 0
        Dim VariableDiaProCliente = 10
        Dim pic As New PictureBox
        Dim destino As New Bitmap(13, 13) ' Me.GrillaFechas.RowTemplate.Height - 5)
        Try

            Grilla.DataSource = Nothing
            Grilla.Rows.Clear()

            classAgenda.cnn = _cnn
            classAgenda.car_codigo = cmbCliente.SelectedValue

            ds = classAgenda.CARGA_GRILLA_FECHAS_CON_AGENDA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaFechas.Rows.Clear()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("age_codigo") > 0 Then
                            GrillaFechas.Rows.Add(False,
                                                  CDate(ds.Tables(0).Rows(Fila)("age_fecha")).ToShortDateString,
                                                  ds.Tables(0).Rows(Fila)("age_numero"),
                                                  ds.Tables(0).Rows(Fila)("age_codigo"))
                        End If

                        Fila = Fila + 1
                    Loop
                End If
                'GrillaFechas.AutoResizeColumns()

            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSeleccionar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GrillaFechas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellContentClick
        If e.ColumnIndex = Me.GrillaFechas.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaFechas.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If

        If e.ColumnIndex = 0 Then
            Call CARGA_ENCABEZADO_ORDENES()
        End If
    End Sub

    Private Sub CARGA_ENCABEZADO_ORDENES()
        Dim classAgenda As class_agendanew = New class_agendanew
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim mes2 As String = ""
        Dim dia2 As String = ""

        Dim myfont As Font
        myfont = New Font(Grilla.Font, FontStyle.Bold + FontStyle.Italic)

        Try
            classAgenda.cnn = _cnn
            classAgenda.car_codigo = cmbCliente.SelectedValue

            Grilla.Rows.Clear()
            GrillaDetalle.Rows.Clear()
            For Each row As DataGridViewRow In Me.GrillaFechas.Rows
                If row.Cells(0).Value = True Then
                    Fila = 0
                    classAgenda.age_codigo = row.Cells(3).Value
                    If bodegas = "" Then
                        classAgenda.bodega = "-"
                    Else
                        classAgenda.bodega = sentencia
                    End If

                    ds = classAgenda.CARGA_ODENES_DE_COMPRA_POR_AGENDA(_msgError)
                    If _msgError = "" Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            'GrillaDetalle.Rows.Clear()
                            'Grilla.Rows.Clear()
                            Do While Fila < ds.Tables(0).Rows.Count
                                If ds.Tables(0).Rows(Fila)("con_ocnumero") > 0 Then
                                    Grilla.Rows.Add(False,
                                                          cmbCliente.SelectedValue,
                                                          ds.Tables(0).Rows(Fila)("age_codigo"),
                                                          ds.Tables(0).Rows(Fila)("age_numero"),
                                                          CDate(ds.Tables(0).Rows(Fila)("age_fecha")).ToShortDateString,
                                                          ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                                          CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")).ToShortDateString,
                                                          ds.Tables(0).Rows(Fila)("con_despachara"),
                                                          FormatNumber(ds.Tables(0).Rows(Fila)("con_total"), 0),
                                                          ds.Tables(0).Rows(Fila)("con_nombrearchivo"),
                                                          NOMBRES_VACIO(cmbCliente.SelectedValue, ds.Tables(0).Rows(Fila)("con_ocnumero")),
                                                          ds.Tables(0).Rows(Fila)("con_devuelta"),
                                                          ds.Tables(0).Rows(Fila)("con_esabierta"))


                                    If ds.Tables(0).Rows(Fila)("con_devuelta") = True Then
                                        Grilla.Rows(Fila).Cells(COL_NUM_CITA).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(COL_FECHA_CITA).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(COL_NUM_COMPRA).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(COL_FECHA_COMPROMISO).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(COL_BODEGA_DESPACHO).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(COL_TOTAL).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(COL_ARCHIVO_ORIGEN).Style.Font = myfont
                                    End If

                                    If NOMBRES_VACIO(cmbCliente.SelectedValue, ds.Tables(0).Rows(Fila)("con_ocnumero")) > 0 Then
                                        row.DefaultCellStyle.BackColor = Color.White
                                        row.DefaultCellStyle.ForeColor = Color.Red
                                    End If

                                End If

                                Fila = Fila + 1
                            Loop
                            'Call PINTA_GRILLA_ENCBEZADO()
                        End If
                    Else
                        MessageBox.Show(_msgError + "\CARGA_ENCABEZADO_ORDENES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Next
            Call PINTA_GRILLA_ENCBEZADO()


        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_ENCABEZADO_ORDENES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PINTA_GRILLA_ENCBEZADO()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(10).Value > 0 Then
                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Red
            End If

        Next
    End Sub

    Private Function NOMBRES_VACIO(ByVal car_codigo As Integer, ByVal oco_numero As Long) As Integer
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        NOMBRES_VACIO = 0
        Dim Cantidad As Integer = 0
        Try

            classSolicitud.cnn = _cnn
            classSolicitud.car_codigo = car_codigo
            classSolicitud.oc_numero = oco_numero
            ds = classSolicitud.BUSCA_VALORES_VACIO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("cantidad") > 0 Then
                            'NOMBRES_VACIO = ds.Tables(0).Rows(Fila)("cantidad")
                            Cantidad = Cantidad + 1
                        End If
                        Fila = Fila + 1
                    Loop
                End If
                NOMBRES_VACIO = Cantidad
            Else
                MessageBox.Show(_msgError + "\NOMBRES_VACIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\NOMBRES_VACIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If

        If e.ColumnIndex = COL_ARCHIVO_ORIGEN Then
            Process.Start(Grilla.Rows(e.RowIndex).Cells(COL_ARCHIVO_ORIGEN).Value)
        End If
        If e.ColumnIndex = 0 Then
            Call CARGA_ORDEN_COMPRA_DETALLE_MARCADAS()
        End If
    End Sub

    Private Sub CARGA_ORDEN_COMPRA_DETALLE_MARCADAS()
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim car_codigo As Integer = 0
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        'Dim fecha As String = ""
        Dim NCITA_DATO As String = ""
        Dim FCITA_DATO As String = ""

        Try
            classSolicitud.cnn = _cnn
            GrillaDetalle.Rows.Clear()
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    classSolicitud.car_codigo = cmbCliente.SelectedValue
                    classSolicitud.oc_numero = row.Cells(COL_NUM_COMPRA).Value
                    classSolicitud.age_codigo = row.Cells(COL_COD_CITA).Value
                    classSolicitud.fecha = row.Cells(COL_FECHA_COMPROMISO).Value

                    NCITA_DATO = row.Cells(COL_NUM_CITA).Value
                    FCITA_DATO = row.Cells(COL_FECHA_CITA).Value

                    ds = classSolicitud.CARGA_AGENDA_ODENES_DE_COMPRA_AGENDABLE_DETALLE(_msgError)
                    If _msgError = "" Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            Fila = 0
                            'GrillaDetalle.Rows.Clear()
                            If ds.Tables(0).Rows(Fila)("sku_cartera") <> "" Then
                                Do While Fila < ds.Tables(0).Rows.Count
                                    GrillaDetalle.Rows.Add(False, ds.Tables(0).Rows(Fila)("car_codigo"),
                                                    ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                                    ds.Tables(0).Rows(Fila)("con_codigounico"),
                                                    ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                                    ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                    ds.Tables(0).Rows(Fila)("sku_cartera"),
                                                    ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                                    FormatNumber(ds.Tables(0).Rows(Fila)("con_cantidad"), 0),
                                                    FormatNumber(ds.Tables(0).Rows(Fila)("pro_numerobulto"), 0),
                                                    FormatNumber(ds.Tables(0).Rows(Fila)("pro_totalbulto"), 0),
                                                    FormatNumber(ds.Tables(0).Rows(Fila)("con_preciocosto"), 0),
                                                    FormatDateTime(ds.Tables(0).Rows(Fila)("con_fechadespacho"), 2),
                                                    ds.Tables(0).Rows(Fila)("con_despacharanumero"),
                                                    ds.Tables(0).Rows(Fila)("con_despachara"),
                                                    ds.Tables(0).Rows(Fila)("con_local"),
                                                    ds.Tables(0).Rows(Fila)("con_localnombre"),
                                                    ds.Tables(0).Rows(Fila)("rut_cliente"),
                                                    ds.Tables(0).Rows(Fila)("nombre_cliente"),
                                                    ds.Tables(0).Rows(Fila)("con_observacion"),
                                                    ds.Tables(0).Rows(Fila)("saldo"),
                                                    ds.Tables(0).Rows(Fila)("con_cantidadagendada"),
                                                    FormatNumber((ds.Tables(0).Rows(Fila)("con_cantidadagendada") * ds.Tables(0).Rows(Fila)("pro_numerobulto")), 0),
                                                    ds.Tables(0).Rows(Fila)("fila"), NCITA_DATO,
                                                    ds.Tables(0).Rows(Fila)("pro_codigo"), FCITA_DATO,
                                                    ds.Tables(0).Rows(Fila)("es_abierta"),
                                                    ds.Tables(0).Rows(Fila)("dpp_fila"))
                                    Fila = Fila + 1
                                Loop
                                Call PINTA_GRILLA_DETALLE()
                                GrillaDetalle.AutoResizeColumns()
                            End If
                        End If
                    Else
                        MessageBox.Show(_msgError + "\CARGA_ORDEN_COMPRA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_ORDEN_COMPRA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PINTA_GRILLA_DETALLE()
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows

            If row.Cells(NOMBRE_FAVATEX).Value = "" Then
                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Red
            End If

        Next
    End Sub

    Private Sub ButtonBod_Click(sender As Object, e As EventArgs) Handles ButtonBod.Click
        If PanelBodegas.Visible = False Then
            PanelBodegas.Visible = True
        ElseIf PanelBodegas.Visible = True Then
            PanelBodegas.Visible = False
        End If
    End Sub

    Private Sub ButtonFecha_Click(sender As Object, e As EventArgs) Handles ButtonFecha.Click
        If ButtonFecha.Text = "Modifica fecha" Then
            lblFecha.Visible = True
            dtpFecha.Visible = True
            ButtonFecha.Text = "No mdifica fecha"
        Else
            lblFecha.Visible = False
            dtpFecha.Visible = False
            ButtonFecha.Text = "Modifica fecha"
        End If
    End Sub

    Private Sub ButtonSeleccionar_Click_1(sender As Object, e As EventArgs) Handles ButtonSeleccionar.Click
        Dim i As Integer = 0
        Dim contado As Integer = 0
        Dim nombreBodegas As String = ""

        bodegas = ""

        If GrillaBodegas.Rows.Count = 0 Then
            PanelBodegas.Visible = False
            Exit Sub
        End If

        i = 0
        Do While i <= GrillaBodegas.Rows.Count - 1
            If GrillaBodegas.Rows(i).Cells(0).Value = True Then
                contado = contado + 1
            End If
            i = i + 1
        Loop

        i = 0
        If contado > 0 Then
            'Do While i <= GrillaBodegas.ColumnCount - 1
            Do While i <= GrillaBodegas.Rows.Count - 1
                If GrillaBodegas.Rows(i).Cells(0).Value = True Then
                    If bodegas = "" Then
                        bodegas = "'" + GrillaBodegas.Rows(i).Cells(1).Value + "'"
                        nombreBodegas = GrillaBodegas.Rows(i).Cells(1).Value
                    Else
                        bodegas = bodegas + ", '" + GrillaBodegas.Rows(i).Cells(1).Value + "'"
                        nombreBodegas = nombreBodegas + " / " + GrillaBodegas.Rows(i).Cells(1).Value
                    End If
                End If
                i = i + 1
            Loop
            If bodegas <> "" And bodegas <> "-" Then
                sentencia = "AND co.con_despachara IN(" + bodegas + ")"
            End If
        End If
        i = 0

        If bodegas = "" Then
            lblBodegas.Text = ""
        Else
            lblBodegas.Text = nombreBodegas
        End If

        If Grilla.RowCount < 0 Then
            Exit Sub
        End If

        'Call CARGA_ENCABEZADO_ORDENES(fechaSeleccionada)
        Call CARGA_ENCABEZADO_ORDENES()

        'Call CARGA_GRILLA()
        'Call CARGA_GRILLA_POR_CONFIRMAR()
        'Call SUMA_TOTALES_PLAZO_GRILLA2()

        PanelBodegas.Visible = False
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click
        Call MARCAR_TODOS()
        Call CARGA_ORDEN_COMPRA_DETALLE_MARCADAS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(COL_CANT_NO_ENCONTRADA).Value = 0 Then
                row.Cells(0).Value = True
            End If
        Next
    End Sub

    Private Sub ButtonDesm_Click(sender As Object, e As EventArgs) Handles ButtonDesm.Click
        Call DESMARCAR_TODOS()
        GrillaDetalle.DataSource = Nothing
        GrillaDetalle.Rows.Clear()
    End Sub
    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = False
        Next
    End Sub
    Private Sub ButtonGenera_Click(sender As Object, e As EventArgs) Handles ButtonGenera.Click
        Dim Respuesta As Integer = 0
        Dim Respuesta2 As Integer = 0
        Dim Despachar As String = ""
        Dim fila As Integer = 0

        If EXISTEN_MARCADOS() = False Then
            MessageBox.Show("Debe marcar a lo menos una Orden de compra ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'If VALIDA_OC() = True Then
        '    MessageBox.Show("No es posible seleccionar la orden ya que existen inconsistencia en los datos, como por ejemplo: " _
        '                            + Chr(10) + "- No existe la homologación de algún SKU con un código FAVATEX", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If

        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(0).Value = True And row.Cells(COL_CANT_NO_ENCONTRADA).Value > 0 Then
                Respuesta = MessageBox.Show("Dentro de la selección existen registros que que no pueden ser elejidos por alguna inconsistencia, " _
                                 + Chr(10) + "¿Desea sacarlos de la selección para continuar con la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If Respuesta = vbNo Then
                    Exit Sub
                End If

                For Each row2 As DataGridViewRow In Me.Grilla.Rows
                    If row2.Cells(COL_CANT_NO_ENCONTRADA).Value > 0 Then
                        row2.Cells(0).Value = False
                    End If
                Next
            End If
        Next

        LugarDespacho = ""
        If REQUIERE_AGRUPACION_POR_DESPACHO() = True Then
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    If fila = 0 Then
                        Despachar = row.Cells(7).Value
                        LugarDespacho = row.Cells(7).Value
                    Else
                        If Trim(Despachar) <> Trim(row.Cells(7).Value) Then
                            MessageBox.Show("Existen ordenes seleccionadas con distinto lugar de despacho, por favor revisar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    fila = fila + 1
                End If
            Next
        End If

        If lblFecha.Visible = False Then
            If TIENE_FECHAS_DISTINTAS() = True Then
                Respuesta2 = MessageBox.Show("Se han seleccionado citas correspondientes a distintas fechas de compromiso," _
                                 + Chr(10) + "¿Desea unificarlas bajo una misma fecha de compromiso?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If Respuesta2 = vbNo Then
                    Exit Sub
                ElseIf Respuesta2 = vbYes Then
                    lblFecha.Visible = True
                    dtpFecha.Visible = True
                    Exit Sub
                End If
            End If
        End If

        If Trim(txtHora.Text) = ":" Then
            MessageBox.Show("Debe ingresar la hora de la cita de entrega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtHora.Focus()
            Exit Sub
        End If

        If cmbTipoPicking.Text = "" Then
            MessageBox.Show("Debe seleccionar el tipo de entrega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbTipoPicking.Focus()
            Exit Sub
        End If


        Respuesta = MessageBox.Show("¿Esta seguro(a) de generar el picking con la(s) orden(es) seleccionada(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If GrillaFechas.RowCount < 0 Then
            Exit Sub
        End If

        If Respuesta = vbNo Then
            Exit Sub
        End If

        Call GENERA_PICKING()
        Call CARGA_GRILLA_FECHAS()
        Call CARGA_COMBO_BODEGAS()

        Try
            If GrillaFechas.RowCount < 0 Then
                Grilla.DataSource = Nothing
                Grilla.Rows.Clear()

                GrillaDetalle.DataSource = Nothing
                GrillaDetalle.Rows.Clear()
            Else
                If GrillaFechas.RowCount < 0 Then
                    Exit Sub
                End If
                If GrillaFechas.RowCount > 0 Then
                    fechaSeleccionada = GrillaFechas.Rows(0).Cells(2).Value
                    'Call CARGA_ENCABEZADO_ORDENES(fechaSeleccionada)
                    Call CARGA_ENCABEZADO_ORDENES()
                Else
                    fechaSeleccionada = ""
                    GrillaFechas.DataSource = Nothing
                    GrillaDetalle.DataSource = Nothing
                    Grilla.DataSource = Nothing
                    GrillaFechas.Rows.Clear()
                    GrillaDetalle.Rows.Clear()
                    Grilla.Rows.Clear()
                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function REQUIERE_AGRUPACION_POR_DESPACHO() As Boolean
        Dim classCliente As class_cartera = New class_cartera
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        REQUIERE_AGRUPACION_POR_DESPACHO = False
        Try
            classCliente.cnn = _cnn
            classCliente.car_codigo = cmbCliente.SelectedValue

            ds = classCliente.REQUIERE_GRUPAR_POR_DESPACHO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") <> 0 Then
                        REQUIERE_AGRUPACION_POR_DESPACHO = ds.Tables(0).Rows(Fila)("car_requiere_agrupar_x_despacho")
                    End If
                End If
            Else
                REQUIERE_AGRUPACION_POR_DESPACHO = False
                MessageBox.Show(_msgError + "\REQUIERE_AGRUPACION_POR_DESPACHO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            REQUIERE_AGRUPACION_POR_DESPACHO = False
            MessageBox.Show(ex.Message + "\REQUIERE_AGRUPACION_POR_DESPACHO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GENERA_PICKING()
        Dim classPicking As class_picking = New class_picking
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
        Dim classAgenda As class_agendanew = New class_agendanew
        Dim classLog As LogEventos = New LogEventos
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim contadorfueraPlazo As Integer = 0

        Dim sum_cant_unidades As Integer = 0
        Dim sum_cant_bultos As Integer = 0
        Dim sum_total_bultos As Integer = 0
        Dim FilaDetallePicking As Integer = 0

        Dim listaDetallePicking As List(Of estructura_detalle_picking)
        listaDetallePicking = New List(Of estructura_detalle_picking)()
        GLO_FECHA_SISTEMA = Date.Today
        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classPicking.pic_codigo = _newPicking
                classPicking.pic_fecha = GLO_FECHA_SISTEMA
                classPicking.car_codigo = cmbCliente.SelectedValue
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.cant_unidades = 0
                classPicking.cant_bultos = 0
                classPicking.total_bultos = 0
                classPicking.pic_hora = txtHora.Text
                classPicking.epc_codigo = ESTADOS_PICKING.Generado
                classPicking.pic_cantidad_encontrada = 0
                classPicking.pic_num_bultos_encontrado = 0
                classPicking.pic_total_bultos_encontrado = 0
                classPicking.pic_desdeagendable = True
                classPicking.LugarDespacho = LugarDespacho

                If cmbTipoPicking.Text = "" Then
                    classPicking.tpi_codigo = 0
                Else
                    classPicking.tpi_codigo = cmbTipoPicking.SelectedValue
                End If

                ds = classPicking.PICKING_GUARDA_DATOS_ENCABEZADO(_msgError, conexion)
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
                    Else
                        _newPicking = ds.Tables(0).Rows(0)("CODIGO")
                    End If
                End If

                ds = Nothing
                ds = classPicking.PICKING_ELIMINA_DATOS_DETALLE(_msgError, conexion)
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

                For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
                    If row.Cells(ENTREGA).Value.ToString <> "" And row.Cells(ENTREGA).Value.ToString <> "0" Then
                        classPicking.pic_codigo = _newPicking
                        classPicking.pro_codigo = row.Cells(CODIGO_INTERNO).Value
                        classPicking.pro_nombre = row.Cells(NOMBRE_FAVATEX).Value
                        classPicking.sku_cartera = row.Cells(SKU_CLIENTE).Value
                        classPicking.sku_cartera_nombre = row.Cells(SKU_NOMBRE).Value
                        classPicking.cant_unidades = row.Cells(ENTREGA).Value
                        classPicking.cant_bultos = row.Cells(N_BULTOS_X_UNIDAD).Value
                        classPicking.pic_total_bultos = row.Cells(BXE).Value
                        classPicking.precio = row.Cells(PRECIO).Value
                        classPicking.pic_cantidad_encontrada = 0
                        classPicking.pic_num_bultos_encontrado = 0
                        classPicking.pic_total_bultos_encontrado = 0
                        classPicking.pic_ocnumero = row.Cells(N_OC).Value
                        classPicking.pic_fechaoc = IIf(dtpFecha.Visible = True, dtpFecha.Value, row.Cells(FECHA_DESPACHO).Value) 'row.Cells(FECHA_DESPACHO).Value
                        classPicking.con_codigounico = row.Cells(COD_UNICO).Value
                        classPicking.con_despacharanumero = row.Cells(con_despacharanumero).Value
                        classPicking.con_despachara = row.Cells(con_despachara).Value
                        classPicking.con_local = row.Cells(con_local).Value
                        classPicking.con_localnombre = row.Cells(con_localnombre).Value
                        classPicking.rut_cliente = row.Cells(rut_cliente).Value
                        classPicking.nombre_cliente = row.Cells(nombre_cliente).Value
                        classPicking.con_observacion = row.Cells(con_observacion).Value
                        classPicking.pic_fechaocoriginal = row.Cells(FCITA).Value
                        classPicking.pic_semodificafecha = IIf(dtpFecha.Visible = True, True, False)
                        classPicking.dpp_fila = row.Cells(PDD_CODIGO).Value
                        classPicking.con_fila = row.Cells(NFILA).Value

                        sum_cant_unidades = sum_cant_unidades + row.Cells(ENTREGA).Value
                        sum_cant_bultos = sum_cant_bultos + 0
                        sum_total_bultos = sum_total_bultos + (row.Cells(ENTREGA).Value * row.Cells(N_BULTOS_X_UNIDAD).Value)

                        ds = classPicking.PICKING_GUARDA_DATOS_DETALLE(_msg, conexion)
                        If _msg = "" Then
                            If ds.Tables.Count > 0 Then
                                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                    If conexion.State <> ConnectionState.Closed Then
                                        conexion.Close()
                                    End If
                                    conexion.Dispose()
                                    ds.Dispose()
                                    MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                Else
                                    FilaDetallePicking = ds.Tables(0).Rows(0)("CODIGO")
                                End If
                            End If
                        Else
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            ds.Dispose()
                            MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        ds = Nothing


                        '-------------------------------------------------
                        '----- Guarda en la tabla de entregas
                        '-------------------------------------------------
                        classPicking.car_codigo = cmbCliente.SelectedValue
                        classPicking.con_ocnumero = row.Cells(N_OC).Value
                        classPicking.con_skucliente = row.Cells(SKU_CLIENTE).Value
                        classPicking.con_fila = row.Cells(NFILA).Value
                        classPicking.age_codigo = row.Cells(NCITA).Value
                        classPicking.cantidad = row.Cells(ENTREGA).Value
                        classPicking.cantidad_bultos = row.Cells(BXE).Value
                        classPicking.pic_codigo = _newPicking
                        classPicking.pic_fila = FilaDetallePicking
                        ds = classPicking.PICKING_GUARDA_ENTREGAS_AGENDA(_msg, conexion)
                        If _msg = "" Then
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
                            MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        ds = Nothing

                        ''-------------------------------------------------
                        ''----- Guarda en la tabla de picking asociados
                        ''-------------------------------------------------
                        'classPicking.car_codigo = cmbCliente.SelectedValue
                        'classPicking.con_ocnumero = row.Cells(N_OC).Value
                        'classPicking.con_skucliente = row.Cells(SKU_CLIENTE).Value
                        'classPicking.con_fila = row.Cells(NFILA).Value
                        'classPicking.pic_codigo = _newPicking
                        'classPicking.cantidad = row.Cells(ENTREGA).Value
                        'classPicking.cantidad_bultos = row.Cells(BXE).Value
                        'ds = classPicking.PICKING_GUARDA_PICKING_ASOCIADO(_msg, conexion)
                        'If _msg = "" Then
                        '    If ds.Tables.Count > 0 Then
                        '        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        '            If conexion.State <> ConnectionState.Closed Then
                        '                conexion.Close()
                        '            End If
                        '            conexion.Dispose()
                        '            ds.Dispose()
                        '            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '            Exit Sub
                        '        End If
                        '    End If
                        'Else
                        '    If conexion.State <> ConnectionState.Closed Then
                        '        conexion.Close()
                        '    End If
                        '    conexion.Dispose()
                        '    ds.Dispose()
                        '    MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '    Exit Sub
                        'End If
                        'ds = Nothing

                        '-------------------------------------------------
                        '----- Cambia estado del registro del consolidado
                        '-------------------------------------------------

                        'If row.Cells(DES_ABIERTA).Value = False Then
                        classSolicitud.car_codigo = cmbCliente.SelectedValue
                        classSolicitud.con_ocnumero = row.Cells(N_OC).Value
                        classSolicitud.con_skucliente = row.Cells(SKU_CLIENTE).Value
                        classSolicitud.fecha = row.Cells(FECHA_DESPACHO).Value 'p.fecha_orden_compra
                        classSolicitud.estado = ESTADOS_PICKING.Generado
                        classSolicitud.pic_codigo = _newPicking
                        classSolicitud.filaDetalle = row.Cells(NFILA).Value
                        classSolicitud.es_abierta = row.Cells(DES_ABIERTA).Value
                        ds = classSolicitud.ACTUALIZA_ESTADO_PICKING_ENTREGA(_msgError, conexion)
                        If ds.Tables(0).Rows.Count > 0 Then
                            If _msgError = "" Then
                                If ds.Tables(0).Rows(0)("CODIGO") <= 0 Then
                                    ds = Nothing
                                    MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                            End If
                        End If
                        'Else

                        'End If


                    End If
                Next

                'ACTUALIZA TOTALES EN TALA DE CABECERA
                '--------------------------------------
                classPicking.pic_codigo = _newPicking
                classPicking.pic_fecha = GLO_FECHA_SISTEMA
                classPicking.car_codigo = cmbCliente.SelectedValue
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.cant_unidades = sum_cant_unidades
                classPicking.cant_bultos = sum_cant_bultos
                classPicking.total_bultos = sum_total_bultos 'sum_cant_unidades * sum_cant_bultos '    sum_total_bultos
                classPicking.pic_hora = txtHora.Text
                classPicking.epc_codigo = ESTADOS_PICKING.Generado
                classPicking.pic_cantidad_encontrada = 0
                classPicking.pic_num_bultos_encontrado = 0
                classPicking.pic_total_bultos_encontrado = 0

                ds = classPicking.PICKING_GUARDA_DATOS_ENCABEZADO(_msgError, conexion)
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
                    Else
                        _newPicking = ds.Tables(0).Rows(0)("CODIGO")
                    End If
                End If
                'FIN DE ACTUALIZACION DE TOTALES
                '--------------------------------

                ds = Nothing
                fila = 0

                classPicking.pic_codigo = _newPicking
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                classPicking.lpi_descripcion = "Picking generado a traves del B2B"
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
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Sub
                    End If
                End If

                For Each row As DataGridViewRow In Me.GrillaFechas.Rows
                    If row.Cells(0).Value.ToString = True Then
                        classAgenda.age_codigo = row.Cells(2).Value
                        classAgenda.eag_codigo = ESTADOS_AGENDA.PROCESADA

                        ds = classAgenda.AGENDA_CAMBIA_ESTDO(_msgError, conexion)
                        If ds.Tables(0).Rows.Count > 0 Then
                            If _msgError = "" Then
                                If ds.Tables(0).Rows(0)("CODIGO") <= 0 Then
                                    ds = Nothing
                                    MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                            End If
                        End If
                    End If
                Next

                'Call INGRESA_LOG(CODIGO_LOG_EVENTOS.LOG_INFORMACION, "Se genera el PICKING N°: " + _pic_codigo.ToString, "Sujerido de picking", GLO_USUARIO_ACTUAL, conexion)

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default

                lblFecha.Visible = False
                dtpFecha.Visible = False
                ButtonFecha.Text = "Modifica fecha"

                Dim valor As Integer = _newPicking
                Dim dato As String = String.Format("{0:000000}", valor)
                MessageBox.Show("Se ha generado el picking N°: " + dato + " en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                _newPicking = 0
                txtHora.Text = ""
                cmbTipoPicking.SelectedValue = 0
            End Using
        Catch ex As Exception
            _newPicking = 0
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Function TIENE_FECHAS_DISTINTAS() As Boolean
        Dim fechaActual As Date
        TIENE_FECHAS_DISTINTAS = False
        If Grilla.Rows.Count > 0 Then
            fechaActual = Grilla.Rows(0).Cells(COL_FECHA_CITA).Value
        Else
            TIENE_FECHAS_DISTINTAS = False
            Exit Function
        End If
        Try
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    If fechaActual <> CDate(row.Cells(COL_FECHA_CITA).Value) Then
                        TIENE_FECHAS_DISTINTAS = True
                        Exit For
                    End If

                End If
            Next
        Catch ex As Exception
            TIENE_FECHAS_DISTINTAS = False
        End Try
    End Function
    Private Function EXISTEN_MARCADOS() As Boolean
        Dim contador As Integer = 0
        Try
            EXISTEN_MARCADOS = False
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    EXISTEN_MARCADOS = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            EXISTEN_MARCADOS = False
        End Try
    End Function

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

    End Sub
End Class