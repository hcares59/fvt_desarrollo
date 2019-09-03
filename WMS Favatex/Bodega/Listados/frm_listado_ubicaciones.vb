Public Class frm_listado_ubicaciones
    Private _cnn As String
    Dim cargaPrimeraVez As Boolean
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_ubicaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaPrimeraVez = False
        Call INICIALIZA()
        cargaPrimeraVez = True
    End Sub
    Private Sub INICIALIZA()
        Me.WindowState = FormWindowState.Maximized
        lblTotal.Text = "Cantidad de registros encontrados: 0"
        Call CARGA_COMBO_BODEGA()
        Call CARGA_COMBO_ALTURA()
        Call CARGA_COMBO_ESTADO_TIPO_UBICACION()
        'Call CARGA_GRILLA()
    End Sub

    Private Sub CARGA_COMBO_ALTURA()
        Dim _msg As String
        Try
            Dim classAltura As class_alturas = New class_alturas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classAltura.cnn = _cnn
            _msg = ""
            ds = classAltura.CARGA_COMBO_ALTURA(_msg)
            If _msg = "" Then
                Me.cmbAltura.DataSource = ds.Tables(0)
                Me.cmbAltura.DisplayMember = "MENSAJE"
                Me.cmbAltura.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ALTURA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_BODEGA()
        Dim _msg As String
        Try
            Dim classBodega As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classBodega.cnn = _cnn
            _msg = ""
            ds = classBodega.BODEGA_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbBodegas.DataSource = ds.Tables(0)
                Me.cmbBodegas.DisplayMember = "MENSAJE"
                Me.cmbBodegas.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_TIPO_UBICACION()
        Dim _msg As String
        Try
            Dim classTipoUbicacion As class_tipo_ubicacion = New class_tipo_ubicacion
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classTipoUbicacion.cnn = _cnn
            classTipoUbicacion.bod_codigo = cmbBodegas.SelectedValue

            _msg = ""
            ds = classTipoUbicacion.COMBO_CARGA_TIPO_UBICACION(_msg)
            If _msg = "" Then
                Me.cmbTipo.DataSource = ds.Tables(0)
                Me.cmbTipo.DisplayMember = "MENSAJE"
                Me.cmbTipo.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_UBICACION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_ESTADO_TIPO_UBICACION()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn

            _msg = ""
            ds = classUbicacion.ESTADO_UBICACIONES_CARGA_COMNBO(_msg)
            If _msg = "" Then
                Me.cmbEstado.DataSource = ds.Tables(0)
                Me.cmbEstado.DisplayMember = "MENSAJE"
                Me.cmbEstado.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ESTADO_TIPO_UBICACION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbBodegas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbBodegas.SelectionChangeCommitted
        If cmbBodegas.SelectedValue >= 0 Then
            Call CARGA_COMBO_TIPO_UBICACION()
        End If
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_ingreso_ubicaciones = New frm_ingreso_ubicaciones
        frm.cnn = _cnn
        frm.ubi_codigo = 0
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub CARGA_GRILLA()
        Dim class_ubicacion As class_ubicaciones = New class_ubicaciones

        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_ubicacion.cnn = _cnn
            class_ubicacion.ubi_codigo = 0

            If cmbBodegas.Text = "" Then
                class_ubicacion.bod_codigo = 0
            Else
                class_ubicacion.bod_codigo = cmbBodegas.SelectedValue
            End If

            If cmbTipo.Text = "" Then
                class_ubicacion.btu_codigo = 0
            Else
                class_ubicacion.btu_codigo = cmbTipo.SelectedValue
            End If

            If cmbZona.Text = "" Then
                class_ubicacion.zon_codigo = 0
            Else
                class_ubicacion.zon_codigo = cmbZona.SelectedValue
            End If

            If cmbAltura.Text = "" Then
                class_ubicacion.alt_codigo = 0
            Else
                class_ubicacion.alt_codigo = cmbAltura.SelectedValue
            End If

            If cmbEstado.Text = "" Then
                class_ubicacion.eub_codigo = 0
            Else
                class_ubicacion.eub_codigo = cmbEstado.SelectedValue
            End If

            class_ubicacion.ubi_codigo = 0

            _msg = ""
            Grilla.Rows.Clear()
            ds = class_ubicacion.CARGA_DATOS_UBICACIONES(_msg)
            If _msg = "" Then
                lblTotal.Text = "Cantidad de registros encontrados: 0"
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("ubi_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("ubi_codigo"),
                                            ds.Tables(0).Rows(Fila)("bod_codigo"),
                                            ds.Tables(0).Rows(Fila)("bod_nombre"),
                                            ds.Tables(0).Rows(Fila)("btu_codigo"),
                                            ds.Tables(0).Rows(Fila)("tub_nombre"),
                                            ds.Tables(0).Rows(Fila)("zon_codigo"),
                                            ds.Tables(0).Rows(Fila)("zon_nombre"),
                                            ds.Tables(0).Rows(Fila)("alt_codigo"),
                                            ds.Tables(0).Rows(Fila)("alt_nombre"),
                                            ds.Tables(0).Rows(Fila)("ubi_nombre"),
                                            ds.Tables(0).Rows(Fila)("eub_codigo"),
                                            ds.Tables(0).Rows(Fila)("eub_nombre"),
                                            ds.Tables(0).Rows(Fila)("ubi_activo"))

                            If Grilla.Item(10, Fila).Value = ESTADO_UBICACION.DISPONIBLE Then
                                Grilla.Item(11, Fila).Style.BackColor = Color.FromArgb(206, 239, 206)
                                Grilla.Item(11, Fila).Style.ForeColor = Color.FromArgb(107, 140, 107)
                            ElseIf Grilla.Item(10, Fila).Value = ESTADO_UBICACION.OCUPADO Then
                                Grilla.Item(11, Fila).Style.BackColor = Color.FromArgb(255, 214, 214)
                                Grilla.Item(11, Fila).Style.ForeColor = Color.FromArgb(253, 49, 49)
                            ElseIf Grilla.Item(10, Fila).Value = ESTADO_UBICACION.RESERVADO Then
                                Grilla.Item(11, Fila).Style.BackColor = Color.FromArgb(254, 218, 141)
                                Grilla.Item(11, Fila).Style.ForeColor = Color.FromArgb(223, 146, 74)
                            End If

                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                        Grilla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 13 Then
                Dim frm As frm_ingreso_ubicaciones = New frm_ingreso_ubicaciones
                frm.cnn = _cnn
                frm.ubi_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 14 Then
                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Call ELIMINA_REGISTRO(Grilla.Rows(e.RowIndex).Cells(0).Value)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ELIMINA_REGISTRO(ByVal codigo As Integer)
        Dim class_ubicacion As class_ubicaciones = New class_ubicaciones
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""

        Try
            ds = Nothing
            class_ubicacion.cnn = _cnn
            class_ubicacion.ubi_codigo = codigo

            ds = class_ubicacion.ELIMINA_UBICACIONES(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CARGA_GRILLA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub cmbTipo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTipo.SelectionChangeCommitted
        If cmbTipo.SelectedValue >= 0 Then
            Call CARGA_COMBO_ZONA()
        End If
    End Sub

    Private Sub CARGA_COMBO_ZONA()
        Dim _msg As String
        Try
            Dim classZona As class_zonas = New class_zonas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classZona.cnn = _cnn
            classZona.btu_codigo = cmbTipo.SelectedValue

            _msg = ""
            ds = classZona.ZONAS_CARGA_ZONAS(_msg)
            If _msg = "" Then
                Me.cmbZona.DataSource = ds.Tables(0)
                Me.cmbZona.DisplayMember = "MENSAJE"
                Me.cmbZona.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ZONA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub chkBodega_CheckedChanged(sender As Object, e As EventArgs) Handles chkBodega.CheckedChanged
        If chkBodega.Checked = True Then
            cmbBodegas.Enabled = True
        Else
            cmbZona.DataSource = Nothing
            cmbZona.Items.Clear()

            cmbTipo.DataSource = Nothing
            cmbTipo.Items.Clear()

            cmbBodegas.SelectedValue = 0
            cmbBodegas.Enabled = False
        End If
    End Sub

    Private Sub chktipoUbicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chktipoUbicacion.CheckedChanged
        If chktipoUbicacion.Checked = True Then
            cmbTipo.Enabled = True
        Else
            cmbZona.DataSource = Nothing
            cmbZona.Items.Clear()

            cmbTipo.SelectedValue = 0
            cmbTipo.Enabled = False
        End If
    End Sub

    Private Sub chkZona_CheckedChanged(sender As Object, e As EventArgs) Handles chkZona.CheckedChanged
        If chkZona.Checked = True Then
            cmbZona.Enabled = True
        Else
            cmbZona.SelectedValue = 0
            cmbZona.Enabled = False
        End If
    End Sub



    Private Sub chkEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstado.CheckedChanged
        If chkEstado.Checked = True Then
            cmbEstado.Enabled = True
        Else
            cmbEstado.SelectedValue = 0
            cmbEstado.Enabled = False
        End If
    End Sub

    Private Sub chkAltura_CheckedChanged(sender As Object, e As EventArgs) Handles chkAltura.CheckedChanged
        If chkAltura.Checked = True Then
            cmbAltura.Enabled = True
        Else
            cmbAltura.SelectedValue = 0
            cmbAltura.Enabled = False
        End If
    End Sub
End Class