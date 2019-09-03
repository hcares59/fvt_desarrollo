Public Class frm_conteo_producto

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
    Private Sub frm_conteo_producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call CARGA_BODEGAS()
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classConteo As class_conteo_producto = New class_conteo_producto

        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing

            If cbmBodegas.Text = "" And TxtCodigo.Text = "" Then
                MessageBox.Show("Debe filtrar a lo menos por bodega o por código de producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbmBodegas.Focus()
                Exit Sub
            End If


            classConteo.cnn = _cnn
            classConteo.pro_codigointerno = IIf(TxtCodigo.Text = "", "-", TxtCodigo.Text)

            If cbmBodegas.Text = "" Then
                classConteo.bod_codigo = 0
            Else
                classConteo.bod_codigo = cbmBodegas.SelectedValue
            End If

            If cbx_tipubicacion.Text = "" Then
                classConteo.tub_codigo = 0
            Else
                classConteo.tub_codigo = cbx_tipubicacion.SelectedValue
            End If

            _msg = ""
            Grilla.Rows.Clear()
            If _msg = "" Then
                ds = classConteo.CONTEO_PRODUCTOS(_msg)
                lblTotal.Text = "Cantidad de registros encontrados: 0"
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("bod_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(FormatDateTime(ds.Tables(0).Rows(Fila)("pal_fechamov"), DateFormat.ShortDate),
                                            ds.Tables(0).Rows(Fila)("bod_codigo"),
                                            ds.Tables(0).Rows(Fila)("bod_nombre"),
                                            ds.Tables(0).Rows(Fila)("tub_nombre"),
                                            ds.Tables(0).Rows(Fila)("ubicacion"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("pal_bultostr"),
                                            ds.Tables(0).Rows(Fila)("pal_cantidad"),
                                            ds.Tables(0).Rows(Fila)("pal_cantidadreservada"),
                                            ds.Tables(0).Rows(Fila)("pal_cantidaddisponible"))
                            Fila = Fila + 1
                        Loop
                        Grilla.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                        lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If

                End If
            Else
                MessageBox.Show(_msg + "\carga_grilla", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grilla", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub CARGA_BODEGAS()
        Dim _msg As String
        Try
            Dim class_bodegas_tipo_ubicacion As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet
            ds = Nothing
            cbmBodegas.DisplayMember = ""
            cbmBodegas.ValueMember = "0"
            class_bodegas_tipo_ubicacion.cnn = _cnn
            _msg = ""
            ds = class_bodegas_tipo_ubicacion.BODEGA_CARGA_COMBO(_msg)
            If _msg = "" Then
                cbmBodegas.DataSource = ds.Tables(0)
                cbmBodegas.DisplayMember = "mensaje"
                cbmBodegas.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_BODEGAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cbmBodegas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbmBodegas.SelectionChangeCommitted
        Call CARGA_BODEGAS_TIPO_UBICACIONES_COMBO(Val(cbmBodegas.SelectedValue))
    End Sub

    Private Sub CARGA_BODEGAS_TIPO_UBICACIONES_COMBO(ByVal bod_codigo As Integer)
        Dim _msg As String
        Try
            Dim class_bodegas_tipo_ubicacion As class_tipo_ubicacion = New class_tipo_ubicacion
            class_bodegas_tipo_ubicacion.bod_codigo = bod_codigo
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_bodegas_tipo_ubicacion.cnn = _cnn
            _msg = ""
            ds = class_bodegas_tipo_ubicacion.CARGA_BODEGAS_UBICACION_COMBO(_msg)
            If _msg = "" Then
                cbx_tipubicacion.DataSource = ds.Tables(0)
                cbx_tipubicacion.DisplayMember = "tub_nombre"
                cbx_tipubicacion.ValueMember = "tub_codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga bodegas tipo ubicaciones", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonLimpiar_Click(sender As Object, e As EventArgs) Handles ButtonLimpiar.Click
        cbmBodegas.SelectedValue = 0
        cbx_tipubicacion.DataSource = Nothing
        cbx_tipubicacion.Items.Clear()
        TxtCodigo.Text = ""
    End Sub

    Private Sub cbmBodegas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbmBodegas.SelectedIndexChanged

    End Sub
End Class