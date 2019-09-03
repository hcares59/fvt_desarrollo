Public Class frm_genera_solicitud_entrega
    Private _cnn As String
    Dim sentencia As String = "AND c.con_despachara IN("
    Dim fechaSeleccionada As String = ""
    Dim bodegas As String = ""

    Const CL_SELECCIONA As Integer = 0
    Const CL_CODIGO As Integer = 1
    Const CL_FECHA_DESPACHO As Integer = 2
    Const CL_NUM_OC As Integer = 3
    Const CL_COD_UNICO As Integer = 4
    Const CL_COD_INTERNO As Integer = 5
    Const CL_NOMBRE_FAVATEX As Integer = 6
    Const CL_SKU_CLIENTE As Integer = 7
    Const CL_SKU_NOMBRE As Integer = 8
    Const CL_CANTIDAD As Integer = 9
    Const CL_N_B_X_U As Integer = 10
    Const CL_TOT_BULTO As Integer = 11
    Const CL_PRECIO As Integer = 12
    Const CL_DESPACHAR_NUMERO As Integer = 13
    Const CL_DESPACHAR_A As Integer = 14
    Const CL_CON_LOCAL As Integer = 15
    Const CL_CON_LOCAL_NOMBRE As Integer = 16
    Const CL_RUT_CLIENTE As Integer = 17
    Const CL_NOMBRE_CLIENTE As Integer = 18
    Const CL_CON_OBSERVACION As Integer = 19

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property


    Private Sub frm_genera_solicitud_entrega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_01;User ID=sa;Password=S1st3m4s"
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        'chkConFecha.Checked = True
        'txtFechaDesde.Value = DateAdd(DateInterval.Day, DIAS_ANTICIPO, GLO_FECHA_SISTEMA)
        'Me.Grilla.Columns(4).Frozen = True
        Me.WindowState = FormWindowState.Maximized
        Me.Grilla.Columns(CL_NOMBRE_FAVATEX).Frozen = True
        Call CARGA_COMBO_CLIENTE()
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

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

    End Sub

    Private Sub cmbCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCliente.SelectionChangeCommitted
        fechaSeleccionada = ""
        Grilla.DataSource = Nothing
        Grilla.Rows.Clear()
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
        Dim classAgenda As class_agenda = New class_agenda
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

            If CStr(GLO_FECHA_SISTEMA.Month).Length = 1 Then
                mes = Trim("0" + CStr(GLO_FECHA_SISTEMA.Month))
            Else
                mes = CStr(GLO_FECHA_SISTEMA.Month)
            End If

            If CStr(GLO_FECHA_SISTEMA.Day).Length = 1 Then
                dia = Trim("0" + CStr(GLO_FECHA_SISTEMA.Day))
            Else
                dia = CStr(GLO_FECHA_SISTEMA.Day)
            End If

            classAgenda.fecha_inicio = "19000101"
            classAgenda.fecha_termino = "20501231"

            ds = classAgenda.CARGA_GRILLA_FECHAS_PARA_AGENDAS(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaFechas.Rows.Clear()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("con_cantOC") > 0 Then
                            GrillaFechas.Rows.Add(False, CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")).ToShortDateString,
                                                               ds.Tables(0).Rows(Fila)("con_cantOC"))
                        End If

                        Fila = Fila + 1
                    Loop
                End If
                'GrillaFechas.AutoResizeColumns()
                'Call PINTA_GRILLA()
                'Call PINTA_GRILLA_FECHAS()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonBod_Click(sender As Object, e As EventArgs) Handles ButtonBod.Click
        If PanelBodegas.Visible = False Then
            PanelBodegas.Visible = True
        ElseIf PanelBodegas.Visible = True Then
            PanelBodegas.Visible = False
        End If
    End Sub

    Private Sub ButtonSeleccionar_Click(sender As Object, e As EventArgs) Handles ButtonSeleccionar.Click
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
                sentencia = "AND c.con_despachara IN(" + bodegas + ")"
            End If
        End If
        i = 0

        'If bodegas = "" Then
        '    lblBodegas.Text = ""
        'Else
        '    lblBodegas.Text = nombreBodegas
        'End If

        If Grilla.RowCount < 0 Then
            Exit Sub
        End If

        Call CARGA_DETALLE_ORDENES()

        'Call CARGA_ENCABEZADO_ORDENES(fechaSeleccionada)
        'Call CARGA_ENCABEZADO_ORDENES()

        'Call CARGA_GRILLA()
        'Call CARGA_GRILLA_POR_CONFIRMAR()
        'Call SUMA_TOTALES_PLAZO_GRILLA2()

        PanelBodegas.Visible = False
    End Sub


    Private Sub CARGA_DETALLE_ORDENES()
        Dim classAgenda As class_agenda = New class_agenda
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim mes2 As String = ""
        Dim dia2 As String = ""
        Dim fecha As Date
        Dim myfont As Font
        myfont = New Font(Grilla.Font, FontStyle.Bold + FontStyle.Italic)

        Try

            classAgenda.cnn = _cnn
            classAgenda.car_codigo = cmbCliente.SelectedValue

            Grilla.Rows.Clear()


            For Each row As DataGridViewRow In Me.GrillaFechas.Rows
                If row.Cells(0).Value = True Then
                    Fila = 0
                    fecha = CDate(row.Cells(1).Value)

                    If CStr(fecha.Month).Length = 1 Then
                        mes = Trim("0" + CStr(fecha.Month))
                    Else
                        mes = CStr(fecha.Month)
                    End If

                    If CStr(fecha.Day).Length = 1 Then
                        dia = Trim("0" + CStr(fecha.Day))
                    Else
                        dia = CStr(fecha.Day)
                    End If

                    classAgenda.fecha_orden = CStr(fecha.Year) + mes + dia

                    If bodegas = "" Then
                        classAgenda.bodegas = "-"
                    Else
                        classAgenda.bodegas = sentencia
                    End If

                    ds = classAgenda.CARGA_ODENES_DE_COMPRA_DETALLE_PARA_AGENDA_SELECCIONA(_msgError)
                    If _msgError = "" Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            Do While Fila < ds.Tables(0).Rows.Count
                                If ds.Tables(0).Rows(Fila)("con_ocnumero") > 0 Then
                                    Grilla.Rows.Add(False,
                                                    cmbCliente.SelectedValue,
                                                    CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")).ToShortDateString,
                                                    ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                                    ds.Tables(0).Rows(Fila)("con_codigounico"),
                                                    ds.Tables(0).Rows(Fila)("con_codigointerno"),
                                                    ds.Tables(0).Rows(Fila)("con_nombre_favatex"),
                                                    ds.Tables(0).Rows(Fila)("con_skucliente"),
                                                    ds.Tables(0).Rows(Fila)("con_skudescripcion"),
                                                    FormatNumber(ds.Tables(0).Rows(Fila)("con_cantidad"), 0),
                                                    FormatNumber(ds.Tables(0).Rows(Fila)("con_nbxu"), 0),
                                                    FormatNumber(ds.Tables(0).Rows(Fila)("con_total_bulto"), 0),
                                                    FormatNumber(ds.Tables(0).Rows(Fila)("con_preciocosto"), 0),
                                                    ds.Tables(0).Rows(Fila)("con_despacharanumero"),
                                                    ds.Tables(0).Rows(Fila)("con_local"),
                                                    ds.Tables(0).Rows(Fila)("con_localnombre"),
                                                    ds.Tables(0).Rows(Fila)("rut_cliente"),
                                                    ds.Tables(0).Rows(Fila)("nombre_cliente"),
                                                    ds.Tables(0).Rows(Fila)("con_fila"),
                                                    ds.Tables(0).Rows(Fila)("pic_codigo"),
                                                    ds.Tables(0).Rows(Fila)("es_devolucion"))

                                    If ds.Tables(0).Rows(Fila)("es_devolucion") = True Then
                                        Grilla.Rows(Fila).Cells(CL_FECHA_DESPACHO).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(CL_NUM_OC).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(CL_COD_INTERNO).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(CL_NOMBRE_FAVATEX).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(CL_SKU_CLIENTE).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(CL_SKU_NOMBRE).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(CL_CANTIDAD).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(CL_N_B_X_U).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(CL_TOT_BULTO).Style.Font = myfont
                                        Grilla.Rows(Fila).Cells(CL_PRECIO).Style.Font = myfont
                                    End If

                                End If

                                Fila = Fila + 1
                            Loop
                            Call PINTA_GRILLA_DETALLE()
                        End If
                    Else
                        MessageBox.Show(_msgError + "\CARGA_DETALLE_ORDENES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Next

            Grilla.AutoResizeColumns()
            'Call PINTA_GRILLA_ENCBEZADO()


        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DETALLE_ORDENES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PINTA_GRILLA_DETALLE()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(CL_NOMBRE_FAVATEX).Value = "" Then
                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Red
            End If

        Next
    End Sub

    Private Sub GrillaFechas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellContentClick
        If e.ColumnIndex = Me.GrillaFechas.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaFechas.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If

        If e.ColumnIndex = 0 Then
            Call CARGA_DETALLE_ORDENES()
        End If
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(CL_NOMBRE_FAVATEX).Value <> "" Then
                row.Cells(CL_SELECCIONA).Value = True
            End If
        Next
    End Sub
    Private Sub ButtonDesm_Click(sender As Object, e As EventArgs) Handles ButtonDesm.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(CL_SELECCIONA).Value = False
        Next
    End Sub

    Private Sub ButtonGenera_Click(sender As Object, e As EventArgs) Handles ButtonGenera.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class