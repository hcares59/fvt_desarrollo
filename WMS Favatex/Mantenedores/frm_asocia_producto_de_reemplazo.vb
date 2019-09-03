Public Class frm_asocia_producto_de_reemplazo
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_asocia_producto_de_reemplazo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Call INICIALIZA()
        lblSinRelacionar.Text = "Registros encontrados: 0"
        lblRelacionados.Text = "Registros encontrados: 0"
    End Sub

    Private Sub INICIALIZA()
        Call CARGA_CATEGORIAS()
        Call CARGA_CATEGORIAS2()
    End Sub

    Private Sub CARGA_CATEGORIAS()
        Dim _msg As String
        Try
            Dim classCategoria As class_categorias = New class_categorias
            Dim ds As DataSet = New DataSet

            ds = Nothing

            classCategoria.cnn = _cnn
            _msg = ""
            ds = classCategoria.CARGA_COMBO_CATEGORIA(_msg)
            If _msg = "" Then
                cmbCategoria.DataSource = ds.Tables(0)
                cmbCategoria.DisplayMember = "mensaje"
                cmbCategoria.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_CATEGORIAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_CATEGORIAS2()
        Dim _msg As String
        Try
            Dim classCategoria As class_categorias = New class_categorias
            Dim ds As DataSet = New DataSet

            ds = Nothing

            classCategoria.cnn = _cnn
            _msg = ""
            ds = classCategoria.CARGA_COMBO_CATEGORIA(_msg)
            If _msg = "" Then
                cmbCategoria2.DataSource = ds.Tables(0)
                cmbCategoria2.DisplayMember = "mensaje"
                cmbCategoria2.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_CATEGORIAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_PRODUCTOS(ByVal codcat As Integer)
        Dim _msg As String
        Dim classProducto As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Try
            ds = Nothing
            classProducto.cnn = _cnn
            classProducto.cat_codigo = codcat
            _msg = ""
            ds = classProducto.CARGA_PRODUCTO_POR_CATEGORIA_CARGA_COMBO(_msg)
            If _msg = "" Then
                cbmProductos.DataSource = ds.Tables(0)
                cbmProductos.DisplayMember = "pro_nombre"
                cbmProductos.ValueMember = "pro_codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_PRODUCTOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbCategoria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCategoria.SelectionChangeCommitted
        GrillaSinInc.DataSource = Nothing
        GrillaSinInc.Rows.Clear()
        Call CARGA_PRODUCTOS(cmbCategoria.SelectedValue)
        cmbCategoria2.SelectedValue = cmbCategoria.SelectedValue
    End Sub

    Private Sub cbmProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbmProductos.SelectedIndexChanged

    End Sub

    Private Sub cbmProductos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbmProductos.SelectionChangeCommitted
        If cbmProductos.SelectedValue = 0 Then
            GrillaSinInc.Rows.Clear()
            GrillaConInc.Rows.Clear()
            Exit Sub
        End If
        Call CARGA_PRODUCTOS_SIN_SELECCIOANR(Val(cbmProductos.SelectedValue))
        Call CARGA_PRODUCTOS_SELECCIONADOS(Val(cbmProductos.SelectedValue))
    End Sub

    Private Sub CARGA_PRODUCTOS_SIN_SELECCIOANR(ByVal pro_codigo As Integer)
        Dim classProducto As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classProducto.cnn = _cnn
            classProducto.pro_codigo = pro_codigo
            classProducto.cat_codigo = cmbCategoria2.SelectedValue

            _msg = ""
            GrillaSinInc.Rows.Clear()
            ds = classProducto.LISTADO_CAMBIO_PRODUCTO_SIN_SELECCIONAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    lblSinRelacionar.Text = "Registros encontrados: 0"
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaSinInc.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                        ds.Tables(0).Rows(Fila)("pro_seleccion"),
                                        ds.Tables(0).Rows(Fila)("pro_codint"),
                                        ds.Tables(0).Rows(Fila)("pro_nombre"))
                            Fila = Fila + 1
                        Loop
                        lblSinRelacionar.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_PRODUCTOS_INCLUIDOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grilla", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_PRODUCTOS_SELECCIONADOS(ByVal pro_codigo As Integer)
        Dim classProductos As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classProductos.cnn = _cnn
            classProductos.pro_codigo = pro_codigo

            _msg = ""
            GrillaConInc.Rows.Clear()
            ds = classProductos.LISTADO_CAMBIO_PRODUCTO_SELECCIONADOS(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaConInc.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                        ds.Tables(0).Rows(Fila)("pro_seleccion"),
                                        ds.Tables(0).Rows(Fila)("pro_codint"),
                                        ds.Tables(0).Rows(Fila)("pro_nombre"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                Me.Text = "Listado de productos cambio - [ulgtima consulta: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\carga_grila", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grilla", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub btn_selecciona_Click(sender As Object, e As EventArgs) Handles btn_selecciona.Click
        Dim Codigo As String
        Dim codCamb As Integer
        For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
            Codigo = row.Cells(1).Value
            codCamb = row.Cells(0).Value
            If Codigo = True Then
                SELECCIONA_REGISTRO(codCamb, Val(cbmProductos.SelectedValue))
            End If
        Next
        Call CARGA_PRODUCTOS_SIN_SELECCIOANR(Val(cbmProductos.SelectedValue))
        Call CARGA_PRODUCTOS_SELECCIONADOS(Val(cbmProductos.SelectedValue))
        MessageBox.Show("Seleccion de productos fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SELECCIONA_REGISTRO(ByVal cod_cambio As Integer, ByVal pro_codigo As Integer)
        Dim classProductos As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classProductos.cnn = _cnn
            classProductos.pro_codigo = pro_codigo
            classProductos.pro_cambio = cod_cambio
            ds = classProductos.PRO_SELEC_REGISTRO(_msgError)
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

    Private Sub btn_deselecciona_Click(sender As Object, e As EventArgs) Handles btn_deselecciona.Click
        Dim Codigo As String
        Dim codPro As Integer
        For Each row As DataGridViewRow In Me.GrillaConInc.Rows
            Codigo = row.Cells(1).Value
            codPro = row.Cells(0).Value
            If Codigo = True Then
                DESELECCIONA_REGISTRO(codPro, Val(cbmProductos.SelectedValue))
            End If
        Next
        Call CARGA_PRODUCTOS_SIN_SELECCIOANR(Val(cbmProductos.SelectedValue))
        Call CARGA_PRODUCTOS_SELECCIONADOS(Val(cbmProductos.SelectedValue))
        MessageBox.Show("Desseleccion de productos fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DESELECCIONA_REGISTRO(ByVal pro_cambio As Integer, ByVal pro_codigo As Integer)
        Dim classProducto As class_producto = New class_producto
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            classProducto.cnn = _cnn
            classProducto.pro_codigo = pro_codigo
            classProducto.pro_cambio = pro_cambio
            ds = classProducto.PRO_DESSELEC_REGISTRO(_msgError)
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

    Private Sub ButtonSMarcar_Click(sender As Object, e As EventArgs) Handles ButtonSMarcar.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub ButtonSDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonSDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub ButtonAMarcar_Click(sender As Object, e As EventArgs) Handles ButtonAMarcar.Click
        Call MARCAR_TODOS_CON_R()
    End Sub

    Private Sub MARCAR_TODOS_CON_R()
        For Each row As DataGridViewRow In Me.GrillaConInc.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS_CON_R()
        For Each row As DataGridViewRow In Me.GrillaConInc.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub ButtonADesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonADesmarcar.Click
        Call DESMARCAR_TODOS_CON_R()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged

    End Sub

    Private Sub cmbCategoria2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria2.SelectedIndexChanged

    End Sub

    Private Sub cmbCategoria2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCategoria2.SelectionChangeCommitted
        Call CARGA_PRODUCTOS_SIN_SELECCIOANR(Val(cbmProductos.SelectedValue))
    End Sub
End Class