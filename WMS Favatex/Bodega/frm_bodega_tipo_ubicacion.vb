Public Class frm_bodega_tipo_ubicacion
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_bodega_tipo_ubicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CARGA_COMBO_BODEGAS()
    End Sub

    Private Sub CARGA_COMBO_BODEGAS()
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
            MsgBox(ex.Message + " " + "carga bodegas", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cbmBodegas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbmBodegas.SelectedIndexChanged

    End Sub

    Private Sub cbmBodegas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbmBodegas.SelectionChangeCommitted
        If cbmBodegas.SelectedValue = 0 Then
            GrillaSinInc.Rows.Clear()
            GrillaIncluid.Rows.Clear()
            Exit Sub
        End If
        Call carga_ubicaciones_sin_incluir(Val(cbmBodegas.SelectedValue))
        Call carga_ubicaciones_incluidos(Val(cbmBodegas.SelectedValue))
    End Sub

    Private Sub carga_ubicaciones_sin_incluir(ByVal bod_codigo As Integer)
        Dim class_bodegas_tipo_ubicacion As class_bodegas = New class_bodegas

        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_bodegas_tipo_ubicacion.cnn = _cnn
            class_bodegas_tipo_ubicacion.bod_codigo = bod_codigo

            _msg = ""
            GrillaSinInc.Rows.Clear()
            ds = class_bodegas_tipo_ubicacion.BODEGA_UBICACIONES_SIN_SELECCIONAR_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("tub_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaSinInc.Rows.Add(ds.Tables(0).Rows(Fila)("tub_selec"),
                                                ds.Tables(0).Rows(Fila)("tub_codigo"),
                                                ds.Tables(0).Rows(Fila)("tub_nombre"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                Me.Text = "Listado de bodega ubicacion - [ulgtima consulta: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\carga_grila", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grilla", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub carga_ubicaciones_incluidos(ByVal bod_codigo As Integer)
        Dim class_bodegas_tipo_ubicacion As class_bodegas = New class_bodegas
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_bodegas_tipo_ubicacion.cnn = _cnn
            class_bodegas_tipo_ubicacion.bod_codigo = bod_codigo

            ds = class_bodegas_tipo_ubicacion.BODEGA_UBICACIONES_SELECCIONADOS_LISTADOS(_msg)
            _msg = ""
            GrillaIncluid.Rows.Clear()
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("tub_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaIncluid.Rows.Add(ds.Tables(0).Rows(Fila)("tub_selec"),
                                        ds.Tables(0).Rows(Fila)("tub_codigo"),
                                         ds.Tables(0).Rows(Fila)("tub_nombre"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                Me.Text = "Listado de productos bodega - [ulgtima consulta: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\carga_grila", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grilla", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
                row.Cells(0).Value = True
            Next
            CheckBox1.Text = "DESSELECIONAR TODO"
        Else
            For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
                row.Cells(0).Value = False
            Next
            CheckBox1.Text = "SELECIONAR TODO"
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            For Each row As DataGridViewRow In Me.GrillaIncluid.Rows
                row.Cells(0).Value = True
            Next
            CheckBox2.Text = "DESSELECIONAR TODO"
        Else
            For Each row As DataGridViewRow In Me.GrillaIncluid.Rows
                row.Cells(0).Value = False
            Next
            CheckBox1.Text = "SELECIONAR TODO"
        End If
    End Sub

    Private Sub GrillaIncluid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaIncluid.CellContentClick
        Try
            If GrillaIncluid.Rows(e.RowIndex).Cells(0).Value Then
                GrillaIncluid.Rows(e.RowIndex).Cells(0).Value = False
            Else

                GrillaIncluid.Rows(e.RowIndex).Cells(0).Value = True
            End If
        Catch ex As Exception
            'Message
        End Try
    End Sub

    Private Sub btn_deselecciona_Click(sender As Object, e As EventArgs) Handles btn_deselecciona.Click
        Dim contador As Integer = 0

        If cbmBodegas.Text = "" Then
            MessageBox.Show("Debe selccionar una bodega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbmBodegas.Focus()
            Exit Sub
        End If

        For Each row As DataGridViewRow In Me.GrillaIncluid.Rows
            If row.Cells(0).Value = vbTrue Then
                contador = contador + 1
            End If
        Next

        If contador = 0 Then
            MessageBox.Show("Debe selccionar a lo menos un item para desasignar la bodega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            GrillaIncluid.Focus()
            Exit Sub
        End If


        For Each row As DataGridViewRow In Me.GrillaIncluid.Rows
            If row.Cells(0).Value = vbTrue Then
                deselecciona_registro(Val(cbmBodegas.SelectedValue), row.Cells(1).Value)
            End If
        Next
        Call carga_ubicaciones_sin_incluir(Val(cbmBodegas.SelectedValue))
        Call carga_ubicaciones_incluidos(Val(cbmBodegas.SelectedValue))
        CheckBox2.Checked = False

        MessageBox.Show("deseleccion de productos fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub deselecciona_registro(ByVal bod_codigo As Integer, ByVal pro_codigo As Integer)
        Dim class_bodegas_tipo_ubicacion As class_bodegas = New class_bodegas
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            class_bodegas_tipo_ubicacion.cnn = _cnn
            class_bodegas_tipo_ubicacion.btu_codigo = pro_codigo
            class_bodegas_tipo_ubicacion.bod_codigo = bod_codigo
            ds = class_bodegas_tipo_ubicacion.BODEGA_TIPO_UBICACION_DESELEC_REGISTRO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    'fam_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If
            ds = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_selecciona_Click(sender As Object, e As EventArgs) Handles btn_selecciona.Click
        Dim contador As Integer = 0

        If cbmBodegas.Text = "" Then
            MessageBox.Show("Debe selccionar una bodega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbmBodegas.Focus()
            Exit Sub
        End If

        For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
            If row.Cells(0).Value = vbTrue Then
                contador = contador + 1
            End If
        Next

        If contador = 0 Then
            MessageBox.Show("Debe selccionar a lo menos un item para asignar la bodega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            GrillaSinInc.Focus()
            Exit Sub
        End If

        For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
            If row.Cells(0).Value = vbTrue Then
                Call SELECCIONA_REGISTRO(Val(cbmBodegas.SelectedValue), row.Cells(1).Value)
            End If
        Next
        Call carga_ubicaciones_sin_incluir(Val(cbmBodegas.SelectedValue))
        Call carga_ubicaciones_incluidos(Val(cbmBodegas.SelectedValue))
        CheckBox1.Checked = False

        MessageBox.Show("Seleccion de productos fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SELECCIONA_REGISTRO(ByVal bod_codigo As Integer, ByVal btu_codigo As Integer)
        Dim class_bodegas_tipo_ubicacion As class_bodegas = New class_bodegas
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            class_bodegas_tipo_ubicacion.cnn = _cnn
            class_bodegas_tipo_ubicacion.btu_codigo = btu_codigo
            class_bodegas_tipo_ubicacion.bod_codigo = bod_codigo

            ds = class_bodegas_tipo_ubicacion.bodega_tipo_ubicacion_selec_registro(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else

                End If
            End If
            ds = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class