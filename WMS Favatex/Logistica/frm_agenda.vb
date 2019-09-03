Public Class frm_agenda
    Private _cnn As String
    Dim fechaSeleccionada As String = ""

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub ButtonBod_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frm_agenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=CL-MV032\DESARROLLO;Initial Catalog=db_favatex;User ID=sa;Password=S1st3m4s"
        Call INICIALIZA()
    End Sub
    Private Sub INICIALIZA()
        Call CARGA_COMBO_CLIENTE()
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

    Private Sub CARGA_GRILLA_FECHAS()
        Dim classSolicitud As class_agenda = New class_agenda
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

            If CStr(dtpDesde.Value.Month).Length = 1 Then
                mes = Trim("0" + CStr(dtpDesde.Value.Month))
            Else
                mes = CStr(dtpDesde.Value.Month)
            End If

            If CStr(dtpDesde.Value.Day).Length = 1 Then
                dia = Trim("0" + CStr(dtpDesde.Value.Day))
            Else
                dia = CStr(dtpDesde.Value.Day)
            End If
            classSolicitud.fecha_inicio = CStr(dtpDesde.Value.Year) + mes + dia


            If CStr(dtpHasta.Value.Month).Length = 1 Then
                mes = Trim("0" + CStr(dtpHasta.Value.Month))
            Else
                mes = CStr(dtpHasta.Value.Month)
            End If

            If CStr(dtpHasta.Value.Day).Length = 1 Then
                dia = Trim("0" + CStr(dtpHasta.Value.Day))
            Else
                dia = CStr(dtpHasta.Value.Day)
            End If
            classSolicitud.fecha_termino = CStr(dtpHasta.Value.Year) + mes + dia


            ds = classSolicitud.CARGA_GRILLA_FECHAS_PARA_AGENDAS(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaFechas.Rows.Clear()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("con_cantOC") > 0 Then
                            'pic.Image = Image.FromFile(Application.StartupPath + "\img\green.png")
                            'diaActual = DateDiff(DateInterval.Day, GLO_FECHA_SISTEMA, CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")))
                            'If ((diaActual * 100) / VariableDiaProCliente) <= 75 And ((diaActual * 100) / VariableDiaProCliente) >= 50 Then
                            '    pic.Image = Image.FromFile(Application.StartupPath + "\img\orange.png")
                            '    'marcar con naranjo
                            'ElseIf ((diaActual * 100) / VariableDiaProCliente) < 50 Then
                            '    pic.Image = Image.FromFile(Application.StartupPath + "\img\red.png")
                            '    'marca rojo    
                            'End If

                            'Dim Ima_origen As Image = pic.Image
                            'Dim g As Graphics
                            'g = Graphics.FromImage(destino)
                            ''Juega con los valores(0,0) y observa el resultado
                            'g.DrawImage(Ima_origen, New Rectangle(0, 0, destino.Width, destino.Height),
                            '    0, 0, Ima_origen.Width, Ima_origen.Height, GraphicsUnit.Pixel)


                            'GrillaFechas.Rows.Add(False, cmbCliente.SelectedValue, CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")).ToShortDateString,
                            '                                           ds.Tables(0).Rows(Fila)("con_cantOC"), destino)

                            GrillaFechas.Rows.Add(False, cmbCliente.SelectedValue, CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")).ToShortDateString,
                                                                       ds.Tables(0).Rows(Fila)("con_cantOC"))
                        End If

                        Fila = Fila + 1
                    Loop
                End If
                'GrillaFechas.AutoResizeColumns()
                'Call PINTA_GRILLA()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Call CARGA_GRILLA_FECHAS()
    End Sub

    Private Sub GrillaFechas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellContentClick

    End Sub

    Private Sub GrillaFechas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellEnter
        If GrillaFechas.RowCount < 0 Then
            Exit Sub
        End If
        fechaSeleccionada = GrillaFechas.Rows(e.RowIndex).Cells(2).Value
        CARGA_ENCABEZADO_ORDENES_PARA_AGENDA(fechaSeleccionada)
    End Sub

    Private Sub CARGA_ENCABEZADO_ORDENES_PARA_AGENDA(ByVal fecha As Date)
        Dim classSolicitud As class_agenda = New class_agenda
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim mes2 As String = ""
        Dim dia2 As String = ""
        Try

            'Grilla.DataSource = Nothing
            'Grilla.Rows.Clear()

            classSolicitud.cnn = _cnn
            classSolicitud.car_codigo = cmbCliente.SelectedValue

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

            classSolicitud.fecha_inicio = CStr(fecha.Year) + mes + dia


            ds = classSolicitud.CARGA_GRILLA_OC_PARA_AGENDAS(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    'GrillaDetalle.Rows.Clear()
                    Grilla.Rows.Clear()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("con_ocnumero") > 0 Then
                            Grilla.Rows.Add(False,
                                                  cmbCliente.SelectedValue,
                                                  ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                                  CDate(ds.Tables(0).Rows(Fila)("con_fechadespacho")).ToShortDateString,
                                                  ds.Tables(0).Rows(Fila)("con_despachara"),
                                                  ds.Tables(0).Rows(Fila)("con_localnombre"),
                                                  ds.Tables(0).Rows(Fila)("con_codigounico"),
                                                  ds.Tables(0).Rows(Fila)("es_abierta"))
                        End If

                        Fila = Fila + 1
                    Loop

                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_ENCABEZADO_ORDENES_PARA_AGENDA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_ENCABEZADO_ORDENES_PARA_AGENDA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        If GrillaDetalle.RowCount < 0 Then
            Exit Sub
        End If

        Call CARGA_ORDEN_COMPRA_DETALLE_AGENDA(Grilla.Rows(e.RowIndex).Cells(2).Value, ESTADOS_PICKING.Pendiente)
    End Sub

    Private Sub CARGA_ORDEN_COMPRA_DETALLE_AGENDA(ByVal numOC As Long, ByVal estado As Integer)
        Dim classSolicitud As class_agenda = New class_agenda
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim car_codigo As Integer = 0
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim fecha As String = ""

        Try

            classSolicitud.cnn = _cnn

            classSolicitud.car_codigo = cmbCliente.SelectedValue
            classSolicitud.oc_numero = numOC
            classSolicitud.estado = estado

            ds = classSolicitud.CARGA_ODENES_DE_COMPRA_DETALLE_PARA_AGENDA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then

                    GrillaDetalle.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("sku_cartera") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(False, ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("con_cantidad"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("con_cant_agendable"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("con_cant_enregada"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("con_cant_pendiente"), 0))
                            Fila = Fila + 1
                        Loop
                        Call PINTA_GRILLA_DETALLE()
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

            If row.Cells(4).Value = "" Then
                row.DefaultCellStyle.BackColor = Color.White
                row.DefaultCellStyle.ForeColor = Color.Red
            End If

        Next
    End Sub


End Class