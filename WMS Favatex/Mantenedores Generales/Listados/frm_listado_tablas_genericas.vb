Public Class frm_listado_tablas_genericas
    Private _cnn As String
    Dim paso As String
    Dim cargaPrimeraVez As Boolean
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_tablas_genericas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaPrimeraVez = False
        Call INICIALIZA()
        cargaPrimeraVez = True
    End Sub

    Private Sub CARGA_COMBO_MODULOS()
        Dim _msg As String
        Try
            Dim classUsuario As class_usuario = New class_usuario
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUsuario.cnn = _cnn
            _msg = ""
            ds = classUsuario.CARGA_COMBO_MODULOS(_msg)
            If _msg = "" Then
                Me.cmbModulos.DataSource = ds.Tables(0)
                Me.cmbModulos.DisplayMember = "MENSAJE"
                Me.cmbModulos.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_USUARIO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub INICIALIZA()
        Me.WindowState = FormWindowState.Maximized
        lblTotal.Text = "Cantidad de registros encontrados: 0"
        Call CARGA_COMBO_MODULOS()
        Call CARGA_GRILLA()
    End Sub
    Private Sub CARGA_GRILLA()
        Dim class_tabla_genberica As class_tablas_genericas = New class_tablas_genericas
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_tabla_genberica.cnn = _cnn

            If cmbModulos.Text = "" Then
                class_tabla_genberica.mod_codigo = 0
            Else
                class_tabla_genberica.mod_codigo = cmbModulos.SelectedValue
            End If

            class_tabla_genberica.tge_codigo = 0

            _msg = ""

            Grilla.Rows.Clear()
            ds = class_tabla_genberica.TABLA_GENERICA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("mod_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("mod_codigo"),
                                            ds.Tables(0).Rows(Fila)("mod_nombre"),
                                            ds.Tables(0).Rows(Fila)("tge_codigo"),
                                            ds.Tables(0).Rows(Fila)("tge_nombre"),
                                            ds.Tables(0).Rows(Fila)("tge_activo"))
                            Fila = Fila + 1
                        Loop

                    End If
                    lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                End If
                Me.Text = "LISTADO DE TABLAS GENERICAS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
                Call CONFIGURA_COLUMNAS()
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CONFIGURA_COLUMNAS()
        Grilla.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_ingreso_tabla_generica = New frm_ingreso_tabla_generica
        frm.cnn = _cnn
        frm.mod_codigo = 0
        frm.tge_codigo = 0
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 5 Then
                Dim frm As frm_ingreso_tabla_generica = New frm_ingreso_tabla_generica
                frm.cnn = _cnn
                frm.mod_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.tge_codigo = Grilla.Rows(e.RowIndex).Cells(2).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class