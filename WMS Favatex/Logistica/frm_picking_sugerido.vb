Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_picking_sugerido
    Private _cnn As String
    Dim bodegas As String = ""
    Dim sentencia As String = "AND c.con_despachara IN("
    Dim fechaSeleccionada As String = ""
    Dim diaPlazo As Integer = 0
    Dim _newPicking As Integer = 0
    Dim filaSeleccionada As Integer = 0
    Dim LugarDespacho As String = ""

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


    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_picking_sugerido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_01;User ID=sa;Password=S1st3m4s"
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        txtFecha.Enabled = False
        'chkConFecha.Checked = True
        'txtFechaDesde.Value = DateAdd(DateInterval.Day, DIAS_ANTICIPO, GLO_FECHA_SISTEMA)
        lblBodegas.Text = ""
        'Me.Grilla.Columns(4).Frozen = True
        Me.WindowState = FormWindowState.Maximized
        Me.GrillaDetalle.Columns(NOMBRE_FAVATEX).Frozen = True
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
            ds = classCliente.CARGA_COMBO_CLIENTE_VV(_msg)
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
        GrillaDetalle.DataSource = Nothing
        GrillaDetalle.Rows.Clear()
        Call CARGA_GRILLA_FECHAS()
        Call CARGA_COMBO_BODEGAS()
        Call CARGA_GRILLA_BODEGAS(0)
        'Call CARGA_GRILLA_POR_CONFIRMAR(CDate("01-01-1900"), CDate("01-01-2050"))
    End Sub

    Private Sub CARGA_GRILLA_BODEGAS(ByVal proCodigo As Integer)
        Dim classStock As class_stock = New class_stock
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0

        Try

            grillaBodega.DataSource = Nothing
            grillaBodega.Rows.Clear()

            classStock.cnn = _cnn
            classStock.car_codigo = cmbCliente.SelectedValue
            classStock.pro_codigo = proCodigo

            ds = classStock.LISTADO_BODEGAS_CON_STOCK(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    grillaBodega.Rows.Clear()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("bod_nombre") <> "" Then
                            grillaBodega.Rows.Add(ds.Tables(0).Rows(Fila)("bod_codigo"),
                                                  ds.Tables(0).Rows(Fila)("bod_nombre"),
                                                  ds.Tables(0).Rows(Fila)("bpr_stock_disponible"))
                        End If

                        Fila = Fila + 1
                    Loop
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_BODEGAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_BODEGAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
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

            classSolicitud.cnn = _cnn
            classSolicitud.car_codigo = cmbCliente.SelectedValue

            If chkFecha.Checked = True Then
                If CStr(CDate(txtFecha.Value).Month).Length = 1 Then
                    mes = Trim("0" + CStr(CDate(txtFecha.Value).Month.ToString))
                Else
                    mes = CStr(CDate(txtFecha.Value).Month)
                End If

                If CStr(CDate(txtFecha.Value).Day).Length = 1 Then
                    dia = Trim("0" + CStr(CDate(txtFecha.Value).Day))
                Else
                    dia = CStr(CDate(txtFecha.Value).Day)
                End If

                classSolicitud.fecha_inicio = CDate(txtFecha.Value).Year.ToString + mes + dia
                classSolicitud.fecha_termino = CDate(txtFecha.Value).Year.ToString + mes + dia

            Else
                classSolicitud.fecha_inicio = "19000101"
                classSolicitud.fecha_termino = "20501231"
            End If



            ds = classSolicitud.CARGA_GRILLA_FECHAS(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaFechas.Rows.Clear()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("con_cantOC") > 0 Then
                            GrillaFechas.Rows.Add(False, cmbCliente.SelectedValue, CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")).ToShortDateString,
                                                                       ds.Tables(0).Rows(Fila)("con_cantOC"), destino)
                        End If

                        Fila = Fila + 1
                    Loop
                End If
                'GrillaFechas.AutoResizeColumns()
                'Call PINTA_GRILLA()
                Call PINTA_GRILLA_FECHAS()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PINTA_GRILLA_FECHAS()
        'pic.Image = Image.FromFile(Application.StartupPath + "\img\green.png")
        'diaActual = DateDiff(DateInterval.Day, GLO_FECHA_SISTEMA, CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")))
        'If ((diaActual * 100) / VariableDiaProCliente) <= 75 And ((diaActual * 100) / VariableDiaProCliente) >= 50 Then
        '    pic.Image = Image.FromFile(Application.StartupPath + "\img\orange.png")
        '    'marcar con naranjo
        'ElseIf ((diaActual * 100) / VariableDiaProCliente) < 50 Then
        '    pic.Image = Image.FromFile(Application.StartupPath + "\img\red.png")
        '    GrillaFechas.DefaultCellStyle.BackColor

        '    'marca rojo    
        'End If

        Dim pic As New PictureBox
        Dim destino As New Bitmap(13, 13) ' Me.GrillaFechas.RowTemplate.Height - 5)
        Dim diaActual As Integer = 0
        Dim VariableDiaProCliente = 4

        For Each row As DataGridViewRow In Me.GrillaFechas.Rows
            pic.Image = Image.FromFile(Application.StartupPath + "\img\green.png")
            diaActual = DateDiff(DateInterval.Day, GLO_FECHA_SISTEMA, CDate(row.Cells(2).Value))
            If ((diaActual * 100) / VariableDiaProCliente) <= 75 And ((diaActual * 100) / VariableDiaProCliente) >= 50 Then
                'Dim icoAtomico As New Icon(Environment.CurrentDirectory + "\edit.ico")
                'e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)

                'Me.DataGridView1.Rows(e.RowIndex).Height = icoAtomico.Height + 10
                'Me.DataGridView1.Columns(e.ColumnIndex).Width = icoAtomico.Width + 10


                pic.Image = Image.FromFile(Application.StartupPath + "\img\orange.png")
                'row.DefaultCellStyle.BackColor = Color.AliceBlue
                'row.DefaultCellStyle.ForeColor = Color.DarkSlateGray
            ElseIf ((diaActual * 100) / VariableDiaProCliente) < 50 Then
                pic.Image = Image.FromFile(Application.StartupPath + "\img\red.png")
                'row.DefaultCellStyle.BackColor = Color.Red
                'row.DefaultCellStyle.ForeColor = Color.DarkSlateGray

                'marca rojo    
            End If

            Dim Ima_origen As Image = pic.Image
            Dim g As Graphics
            g = Graphics.FromImage(destino)
            'Juega con los valores(0,0) y observa el resultado
            g.DrawImage(Ima_origen, New Rectangle(0, 0, destino.Width, destino.Height),
                                    0, 0, Ima_origen.Width, Ima_origen.Height, GraphicsUnit.Pixel)

        Next
    End Sub

    Private Sub GrillaFechas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellContentClick
        If e.ColumnIndex = Me.GrillaFechas.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaFechas.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If

        If e.ColumnIndex = 0 Then
            Call CARGA_ENCABEZADO_ORDENES()
        End If

        'Grilla.DataSource = Nothing
        'Grilla.Rows.Clear()
        'Call CARGA_GRILLA(Row.Cells(2).Value, Row.Cells(2).Value)
    End Sub

    Private Sub formateaFila()
        Dim myfont As Font
        Dim Fila = 0
        myfont = New Font(Grilla.Font, FontStyle.Bold + FontStyle.Italic)

        For Each row As DataGridViewRow In Me.Grilla.Rows
            If row.Cells(8).Value = True Then
                Grilla.Rows(row.Index).Cells(2).Style.Font = myfont
                Grilla.Rows(row.Index).Cells(3).Style.Font = myfont
                Grilla.Rows(row.Index).Cells(4).Style.Font = myfont
                Grilla.Rows(row.Index).Cells(5).Style.Font = myfont
                Grilla.Rows(row.Index).Cells(6).Style.Font = myfont
                Fila = Fila + 1
            End If

        Next
    End Sub

    Private Sub CARGA_ENCABEZADO_ORDENES()
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim mes2 As String = ""
        Dim dia2 As String = ""
        Dim fecha As Date
        'Dim myfont As Font
        'myfont = New Font(Grilla.Font, FontStyle.Bold + FontStyle.Italic)

        Try

            'Grilla.DataSource = Nothing
            'Grilla.Rows.Clear()

            classSolicitud.cnn = _cnn
            classSolicitud.car_codigo = cmbCliente.SelectedValue

            Grilla.Rows.Clear()
            GrillaDetalle.Rows.Clear()
            For Each row As DataGridViewRow In Me.GrillaFechas.Rows
                If row.Cells(0).Value = True Then
                    Fila = 0
                    fecha = CDate(row.Cells(2).Value)

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

                    classSolicitud.fecha_busqueda = CStr(fecha.Year) + mes + dia

                    If bodegas = "" Then
                        classSolicitud.bodega = "-"
                    Else
                        classSolicitud.bodega = sentencia
                    End If

                    ds = classSolicitud.CARGA_ODENES_DE_COMPRA(_msgError)
                    If _msgError = "" Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            'GrillaDetalle.Rows.Clear()
                            'Grilla.Rows.Clear()
                            Do While Fila < ds.Tables(0).Rows.Count
                                If ds.Tables(0).Rows(Fila)("con_ocnumero") > 0 Then
                                    Grilla.Rows.Add(False,
                                                          cmbCliente.SelectedValue,
                                                          ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                                          CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")).ToShortDateString,
                                                          ds.Tables(0).Rows(Fila)("con_despachara"),
                                                          FormatNumber(ds.Tables(0).Rows(Fila)("con_total"), 0),
                                                          ds.Tables(0).Rows(Fila)("con_nombrearchivo"),
                                                          NOMBRES_VACIO(cmbCliente.SelectedValue, ds.Tables(0).Rows(Fila)("con_ocnumero")),
                                                          ds.Tables(0).Rows(Fila)("con_devuelta"))


                                    'If ds.Tables(0).Rows(Fila)("con_devuelta") = True Then
                                    '    Grilla.Rows(Fila).Cells(2).Style.Font = myfont
                                    '    Grilla.Rows(Fila).Cells(3).Style.Font = myfont
                                    '    Grilla.Rows(Fila).Cells(4).Style.Font = myfont
                                    '    Grilla.Rows(Fila).Cells(5).Style.Font = myfont
                                    '    Grilla.Rows(Fila).Cells(6).Style.Font = myfont
                                    'End If

                                    'If NOMBRES_VACIO(cmbCliente.SelectedValue, ds.Tables(0).Rows(Fila)("con_ocnumero")) = True Then
                                    '    'Grilla.


                                    '    row.DefaultCellStyle.BackColor = Color.White
                                    '    row.DefaultCellStyle.ForeColor = Color.Red
                                    'End If

                                End If

                                Fila = Fila + 1
                            Loop
                            'Call PINTA_GRILLA_ENCBEZADO()
                            lblCantCabecera.Text = "Cantidad de ordenes: " + ds.Tables(0).Rows.Count.ToString
                        End If
                    Else
                        MessageBox.Show(_msgError + "\CARGA_ENCABEZADO_ORDENES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Next
            Call PINTA_GRILLA_ENCBEZADO()
            Call formateaFila()

        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_ENCABEZADO_ORDENES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PINTA_GRILLA_ENCBEZADO()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(7).Value > 0 Then
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
        Try

            classSolicitud.cnn = _cnn
            classSolicitud.car_codigo = car_codigo
            classSolicitud.oc_numero = oco_numero
            ds = classSolicitud.BUSCA_VALORES_VACIO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("cantidad") > 0 Then
                            NOMBRES_VACIO = ds.Tables(0).Rows(Fila)("cantidad")
                        End If
                        Fila = Fila + 1
                    Loop
                End If
            Else
                MessageBox.Show(_msgError + "\NOMBRES_VACIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\NOMBRES_VACIO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GrillaFechas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellEnter

        If GrillaFechas.RowCount < 0 Then
            Exit Sub
        End If

        'filaSeleccionada = 0
        'filaSeleccionada = e.RowIndex
        fechaSeleccionada = GrillaFechas.Rows(e.RowIndex).Cells(2).Value
        GrillaDetalle.DataSource = Nothing
        GrillaDetalle.Rows.Clear()
        'CARGA_ENCABEZADO_ORDENES(fechaSeleccionada)
        CARGA_ENCABEZADO_ORDENES()
    End Sub

    Private Sub ButtonBod_Click(sender As Object, e As EventArgs) Handles ButtonBod.Click
        If PanelBodegas.Visible = False Then
            PanelBodegas.Visible = True
        ElseIf PanelBodegas.Visible = True Then
            PanelBodegas.Visible = False
        End If
    End Sub
    Private Sub ButtonSeleccionar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = Me.Grilla.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If

        If e.ColumnIndex = 6 Then
            Process.Start(Grilla.Rows(e.RowIndex).Cells(6).Value)
        End If
    End Sub
    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        If GrillaDetalle.RowCount < 0 Then
            Exit Sub
        End If

        Call CARGA_ORDEN_COMPRA_DETALLE(Grilla.Rows(e.RowIndex).Cells(2).Value, ESTADOS_PICKING.Pendiente, Grilla.Rows(e.RowIndex).Cells(3).Value, Grilla.Rows(e.RowIndex).Cells(4).Value)
    End Sub

    Private Sub CARGA_ORDEN_COMPRA_DETALLE(ByVal numOC As Long, ByVal estado As Integer, ByVal fecha As Date, ByVal despachar As String)
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim car_codigo As Integer = 0
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        'Dim fecha As String = ""

        Try
            classSolicitud.cnn = _cnn

            classSolicitud.car_codigo = cmbCliente.SelectedValue
            classSolicitud.oc_numero = numOC
            classSolicitud.estado = estado
            classSolicitud.fecha = fecha
            classSolicitud.con_despachar = despachar

            ds = classSolicitud.CARGA_ODENES_DE_COMPRA_DETALLE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then

                    GrillaDetalle.Rows.Clear()
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
                                            ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("dpp_fila"),
                                            ds.Tables(0).Rows(Fila)("con_fila"))
                            Fila = Fila + 1
                        Loop
                        Call PINTA_GRILLA_DETALLE()
                        GrillaDetalle.AutoResizeColumns()
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_ORDEN_COMPRA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
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

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click
        Call MARCAR_TODOS()
    End Sub


    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows

            If row.Cells(7).Value = 0 Then
                row.Cells(0).Value = True
            End If
        Next
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub ButtonDesm_Click(sender As Object, e As EventArgs) Handles ButtonDesm.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub CONFIRMA_ITEM()
        Dim classPicking As class_solicitud_picking = New class_solicitud_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Try
            classPicking.cnn = _cnn
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    classPicking.car_codigo = row.Cells(1).Value
                    classPicking.con_ocnumero = row.Cells(2).Value
                    classPicking.estado = ESTADOS_PICKING.Por_confirmar
                    classPicking.fecha = row.Cells(3).Value
                    ds = classPicking.ACTUALIZA_ESTADO(_msgError)
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ButtonGenera.Click
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
            If row.Cells(0).Value = True And row.Cells(7).Value > 0 Then
                Respuesta = MessageBox.Show("Dentro de la selección existen registros que que no pueden ser elejidos por alguna inconsistencia, " _
                                 + Chr(10) + "¿Desea sacarlos de la selección para continuar con la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If Respuesta = vbNo Then
                    Exit Sub
                End If

                For Each row2 As DataGridViewRow In Me.Grilla.Rows
                    If row2.Cells(7).Value > 0 Then
                        row2.Cells(0).Value = False
                    End If
                Next
            End If
        Next



        If REQUIERE_AGRUPACION_POR_DESPACHO() = True Then
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    If fila = 0 Then
                        Despachar = row.Cells(4).Value
                        LugarDespacho = row.Cells(4).Value
                    Else
                        If Trim(Despachar) <> Trim(row.Cells(4).Value) Then
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
                Respuesta2 = MessageBox.Show("Se han seleccionado ordenes correspondientes a distintas fechas de compromiso," _
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
            MessageBox.Show("Debe ingresar la hora de despacho", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtHora.Focus()
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

        'fechaSeleccionada = GrillaFechas.Rows(e.RowIndex).Cells(2).Value
        'CARGA_ENCABEZADO_ORDENES(fechaSeleccionada)


    End Sub

    Private Sub GENERA_PICKING()
        Dim classPicking As class_picking = New class_picking
        Dim classSolicitud As class_solicitud_picking = New class_solicitud_picking
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

        Dim listaDetallePicking As List(Of estructura_detalle_picking)
        listaDetallePicking = New List(Of estructura_detalle_picking)()

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
                classPicking.pic_desdeagendable = False
                classPicking.tpi_codigo = TIPO_PICKING.VENTA_VERDE
                classPicking.LugarDespacho = LugarDespacho ' Grilla.Rows(0).Cells(4).Value.ToString

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

                classSolicitud.cnn = _cnn
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(0).Value = True Then
                        classSolicitud.car_codigo = cmbCliente.SelectedValue
                        classSolicitud.oc_numero = row.Cells(2).Value
                        classSolicitud.estado = ESTADOS_PICKING.Pendiente
                        classSolicitud.fecha = row.Cells(3).Value
                        classSolicitud.con_despachar = row.Cells(4).Value
                        ds = classSolicitud.CARGA_ODENES_DE_COMPRA_DETALLE_TRAN(_msgError, conexion)
                        If _msgError = "" Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                If ds.Tables(0).Rows(fila)("sku_cartera") <> "" Then
                                    Do While fila < ds.Tables(0).Rows.Count
                                        listaDetallePicking.Add(New estructura_detalle_picking(_newPicking,
                                        ds.Tables(0).Rows(fila)("pro_codigointerno"),
                                        ds.Tables(0).Rows(fila)("pro_nombre"),
                                        ds.Tables(0).Rows(fila)("sku_cartera"),
                                        ds.Tables(0).Rows(fila)("sku_cartera_nombre"),
                                        ds.Tables(0).Rows(fila)("con_cantidad"),
                                        ds.Tables(0).Rows(fila)("pro_numerobulto"),
                                        ds.Tables(0).Rows(fila)("pro_totalbulto"),
                                        ds.Tables(0).Rows(fila)("con_preciocosto"),
                                        0, 0, 0, row.Cells(2).Value, IIf(dtpFecha.Visible = True, dtpFecha.Value, row.Cells(3).Value),
                                        ds.Tables(0).Rows(fila)("con_codigounico"),
                                        ds.Tables(0).Rows(fila)("con_despacharanumero"),
                                        ds.Tables(0).Rows(fila)("con_despachara"),
                                        ds.Tables(0).Rows(fila)("con_local"),
                                        ds.Tables(0).Rows(fila)("con_localnombre"),
                                        ds.Tables(0).Rows(fila)("rut_cliente"),
                                        ds.Tables(0).Rows(fila)("nombre_cliente"),
                                        ds.Tables(0).Rows(fila)("con_observacion"),
                                        row.Cells(3).Value,
                                        IIf(dtpFecha.Visible = True, True, False),
                                        ds.Tables(0).Rows(fila)("dpp_fila"),
                                        ds.Tables(0).Rows(fila)("con_fila")))

                                        sum_cant_unidades = sum_cant_unidades + ds.Tables(0).Rows(fila)("con_cantidad")
                                        sum_cant_bultos = sum_cant_bultos + ds.Tables(0).Rows(fila)("pro_numerobulto")
                                        sum_total_bultos = sum_total_bultos + ds.Tables(0).Rows(fila)("pro_totalbulto")

                                        fila = fila + 1
                                    Loop
                                End If
                            End If
                        Else
                            ds = Nothing
                            MessageBox.Show(_msgError + "\GENERA_PICKING", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                    fila = 0
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
                For Each p As estructura_detalle_picking In listaDetallePicking
                    classPicking.pic_codigo = p.pic_codigo
                    classPicking.pro_codigo = p.pro_codigo
                    classPicking.pro_nombre = p.pro_nombre
                    classPicking.sku_cartera = p.sku_cartera
                    classPicking.sku_cartera_nombre = p.sku_cartera_nombre
                    classPicking.cant_unidades = p.pic_cantidad
                    classPicking.cant_bultos = p.pic_num_bultos
                    classPicking.pic_total_bultos = p.pic_total_bultos
                    classPicking.precio = p.precio
                    classPicking.pic_cantidad_encontrada = 0
                    classPicking.pic_num_bultos_encontrado = 0
                    classPicking.pic_total_bultos_encontrado = 0
                    classPicking.pic_ocnumero = p.num_orden_compra
                    classPicking.pic_fechaoc = p.fecha_orden_compra
                    classPicking.con_codigounico = p.con_codigounico
                    classPicking.con_despacharanumero = p.con_despacharanumero
                    classPicking.con_despachara = p.con_despachara
                    classPicking.con_local = p.con_local
                    classPicking.con_localnombre = p.con_localnombre
                    classPicking.rut_cliente = p.rut_cliente
                    classPicking.nombre_cliente = p.nombre_cliente
                    classPicking.con_observacion = p.con_observacion
                    classPicking.pic_fechaocoriginal = p.pic_fechaocoriginal
                    classPicking.pic_semodificafecha = p.pic_semodificafecha
                    classPicking.dpp_fila = p.dpp_fila
                    classPicking.con_fila = p.con_fila

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

                    classSolicitud.car_codigo = cmbCliente.SelectedValue
                    classSolicitud.con_ocnumero = p.num_orden_compra
                    classSolicitud.con_skucliente = p.sku_cartera
                    classSolicitud.fecha = p.pic_fechaocoriginal 'p.fecha_orden_compra
                    classSolicitud.estado = ESTADOS_PICKING.Generado
                    classSolicitud.pic_codigo = _newPicking
                    ds = classSolicitud.ACTUALIZA_ESTADO(_msgError, conexion)
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
                    fila = fila + 1
                Next

                ds = Nothing

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
            End Using
        Catch ex As Exception
            _newPicking = 0
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

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

    Private Function TIENE_FECHAS_DISTINTAS() As Boolean
        Dim fechaActual As Date
        TIENE_FECHAS_DISTINTAS = False
        If Grilla.Rows.Count > 0 Then
            fechaActual = Grilla.Rows(0).Cells(3).Value
        Else
            TIENE_FECHAS_DISTINTAS = False
            Exit Function
        End If
        Try
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(0).Value = True Then
                    If fechaActual <> CDate(row.Cells(3).Value) Then
                        TIENE_FECHAS_DISTINTAS = True
                        Exit For
                    End If

                End If
            Next
        Catch ex As Exception
            TIENE_FECHAS_DISTINTAS = False
        End Try
    End Function

    Private Function VALIDA_OC() As Boolean
        VALIDA_OC = False
        For Each row As DataGridViewRow In Me.GrillaDetalle.Rows
            If row.Cells(5).Value = "" Then
                VALIDA_OC = True
                Exit For
            End If
        Next
    End Function

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
                sentencia = "AND c.con_despachara IN(" + bodegas + ")"
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

        Call CARGA_ENCABEZADO_ORDENES()

        PanelBodegas.Visible = False
    End Sub

    Private Sub GrillaFechas_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles GrillaFechas.CellPainting
        ' En la tercera columna añado el icono edit.ico con
        Dim diaActual As Integer = 0
        Dim VariableDiaProCliente = 20

        If e.ColumnIndex = 4 AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            'Dim celBoton As DataGridViewButtonCell = TryCast(Me.GrillaFechas.Rows(e.RowIndex).Cells(3), DataGridViewButtonCell)
            diaActual = DateDiff(DateInterval.Day, GLO_FECHA_SISTEMA, CDate(GrillaFechas.Rows(e.RowIndex).Cells(2).Value))
            If ((diaActual * 100) / VariableDiaProCliente) > 75 Then
                Dim icoAtomico As New Icon(Application.StartupPath + "\img\green16.ico")
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                Me.GrillaFechas.Rows(e.RowIndex).Height = icoAtomico.Height + 10
                Me.GrillaFechas.Columns(e.ColumnIndex).Width = icoAtomico.Width + 10
            ElseIf ((diaActual * 100) / VariableDiaProCliente) <= 75 And ((diaActual * 100) / VariableDiaProCliente) >= 50 Then
                Dim icoAtomico As New Icon(Application.StartupPath + "\img\orange16.ico")
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                Me.GrillaFechas.Rows(e.RowIndex).Height = icoAtomico.Height + 10
                Me.GrillaFechas.Columns(e.ColumnIndex).Width = icoAtomico.Width + 10
            ElseIf ((diaActual * 100) / VariableDiaProCliente) < 50 Then
                Dim icoAtomico As New Icon(Application.StartupPath + "\img\red16.ico")
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                Me.GrillaFechas.Rows(e.RowIndex).Height = icoAtomico.Height + 10
                Me.GrillaFechas.Columns(e.ColumnIndex).Width = icoAtomico.Width + 10
            End If





            'Me.GrillaFechas.Rows(e.RowIndex).Cells(3).ToolTipText = "Editar cliente"

            e.Handled = True
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

    Private Sub GrillaDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellContentClick
        If GrillaDetalle.Rows.Count > 0 Then
            Call CARGA_GRILLA_BODEGAS(GrillaDetalle.Rows(e.RowIndex).Cells(20).Value)
        End If


    End Sub

    Private Sub GrillaDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaDetalle.CellEnter
        If GrillaDetalle.Rows.Count > 0 Then
            Call CARGA_GRILLA_BODEGAS(GrillaDetalle.Rows(e.RowIndex).Cells(20).Value)
        End If
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        If chkFecha.Checked = True Then
            txtFecha.Enabled = True
        Else
            txtFecha.Enabled = False
        End If
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        fechaSeleccionada = ""
        GrillaDetalle.DataSource = Nothing
        GrillaDetalle.Rows.Clear()
        Call CARGA_GRILLA_FECHAS()
        Call CARGA_COMBO_BODEGAS()
        Call CARGA_GRILLA_BODEGAS(0)
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonAnulaOrden_Click(sender As Object, e As EventArgs) Handles ButtonAnulaOrden.Click
        Dim respuesta As Integer = 0

        Try
            respuesta = MessageBox.Show("¿Esta seguro(a) de anular la(s) orden(es) seleccionada(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If

            If EXISTEN_MARCADOS() = False Then
                MessageBox.Show("Debe marcar a lo menos una Orden de compra ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Call ANULA_ORDENES()

            fechaSeleccionada = ""
            GrillaDetalle.DataSource = Nothing
            GrillaDetalle.Rows.Clear()
            Call CARGA_GRILLA_FECHAS()
            Call CARGA_COMBO_BODEGAS()
            Call CARGA_GRILLA_BODEGAS(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




    End Sub

    Private Sub ANULA_ORDENES()
        Dim classPickinhg As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Me.Cursor = Cursors.WaitCursor

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If row.Cells(0).Value = True Then
                        classPickinhg.car_codigo = row.Cells(1).Value
                        classPickinhg.pic_ocnumero = row.Cells(2).Value
                        classPickinhg.usu_anulaorden = GLO_USUARIO_ACTUAL
                        ds = classPickinhg.PICKING_ANULA_ORDEN_COMPRA(_msgError, conexion)
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
                    End If
                Next

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Las ordenes fueron anuladas en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
End Class