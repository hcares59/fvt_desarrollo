Public Class frm_listado_zona
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
    Private Sub frm_listado_zona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaPrimeraVez = False
        Call INICIALIZA()

        cargaPrimeraVez = True
    End Sub

    Private Sub INICIALIZA()
        Me.WindowState = FormWindowState.Maximized
        lblTotal.Text = "Cantidad de registros encontrados: 0"
        Call carga_bodegas()
        Call carga_grilla()
    End Sub

    Private Sub CARGA_GRILLA()
        Dim class_zonas As class_zonas = New class_zonas

        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_zonas.cnn = _cnn
            class_zonas.btu_codigo = Val(cbx_tipubicacion.SelectedValue)
            class_zonas.bod_codigo = Val(cbmBodegas.SelectedValue)
            class_zonas.zon_codigo = 0
            class_zonas.todos = chkActivo.Checked

            _msg = ""
            Grilla.Rows.Clear()
            If _msg = "" Then
                ds = class_zonas.zonas_listado(_msg)
                lblTotal.Text = "Cantidad de registros encontrados: 0"
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("zon_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("zon_codigo"),
                                            ds.Tables(0).Rows(Fila)("bod_nombre"),
                                            ds.Tables(0).Rows(Fila)("tub_nombre"),
                                            ds.Tables(0).Rows(Fila)("zon_nombre"),
                                            ds.Tables(0).Rows(Fila)("zon_activo"))
                            Fila = Fila + 1
                        Loop
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub carga_bodegas_tipo_ubicaciones_combo(ByVal bod_codigo As Integer)
        Dim _msg As String
        Try
            Dim class_bodegas_tipo_ubicacion As class_tipo_ubicacion = New class_tipo_ubicacion
            class_bodegas_tipo_ubicacion.bod_codigo = bod_codigo
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_bodegas_tipo_ubicacion.cnn = _cnn
            _msg = ""
            ds = class_bodegas_tipo_ubicacion.carga_bodegas_ubicacion_combo(_msg)
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

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ELIMINA_REGISTRO(ByVal codigo As Integer)
        Dim class_zonas As class_zonas = New class_zonas
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""

        Try
            ds = Nothing
            class_zonas.cnn = _cnn
            class_zonas.zon_codigo = codigo

            ds = class_zonas.ZONA_ELIMINA_REGISTRO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CARGA_GRILLA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 5 Then
                Dim frm As frm_ingreso_zona = New frm_ingreso_zona
                frm.cnn = _cnn
                frm.zon_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 6 Then

                If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Call ELIMINA_REGISTRO(Grilla.Rows(e.RowIndex).Cells(0).Value)
                    Call CARGA_GRILLA()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_ingreso_zona = New frm_ingreso_zona
        frm.cnn = _cnn
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub

    Private Sub chkActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivo.CheckedChanged
        If cargaPrimeraVez = True Then
            Call CARGA_GRILLA()
        End If
    End Sub


    Private Sub cbmBodegas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbmBodegas.SelectionChangeCommitted
        Call carga_bodegas_tipo_ubicaciones_combo(Val(cbmBodegas.SelectedValue))
    End Sub

    Private Sub cbmBodegas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbmBodegas.SelectedIndexChanged

    End Sub
End Class