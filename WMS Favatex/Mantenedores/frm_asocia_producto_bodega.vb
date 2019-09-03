Public Class frm_asocia_producto_bodega
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_asocia_producto_bodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        Call CARGA_BODEGAS()
        lblSinRelacionar.Text = "Registros encontrados: 0"
        lblRelacionados.Text = "Registros encontrados: 0"
    End Sub

    Private Sub CARGA_BODEGAS()
        Dim _msg As String
        Try
            Dim classBodega As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet

            ds = Nothing

            classBodega.cnn = _cnn
            _msg = ""
            ds = classBodega.BODEGA_CARGA_COMBO(_msg)
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

    Private Sub CARGA_PRODUCTOS_SIN_INCLUIR()
        Dim classProductos As class_producto = New class_producto

        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classProductos.cnn = _cnn

            classProductos.bod_codigo = cbmBodegas.SelectedValue
            _msg = ""
            GrillaSinInc.Rows.Clear()
            ds = classProductos.PRODUCTOS_SIN_BODEGA_LISTADO(_msg)
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
                MessageBox.Show(_msg + "\CARGA_PRODUCTOS_SIN_INCLUIR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_PRODUCTOS_SIN_INCLUIR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_PRODUCTOS_INCLUIDOS()
        Dim classProductos As class_producto = New class_producto
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classProductos.cnn = _cnn
            classProductos.bod_codigo = cbmBodegas.SelectedValue

            _msg = ""
            GrillaIncluid.Rows.Clear()
            ds = classProductos.PRODUCTOS_CON_BODEGA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    lblRelacionados.Text = "Registros encontrados: 0"
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaIncluid.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                        ds.Tables(0).Rows(Fila)("pro_seleccion"),
                                        ds.Tables(0).Rows(Fila)("pro_codint"),
                                        ds.Tables(0).Rows(Fila)("pro_nombre"))
                            Fila = Fila + 1
                        Loop
                        lblRelacionados.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_PRODUCTOS_INCLUIDOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grilla", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cbmBodegas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbmBodegas.SelectedIndexChanged

    End Sub

    Private Sub cbmBodegas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbmBodegas.SelectionChangeCommitted
        If cbmBodegas.SelectedValue = 0 Then
            GrillaSinInc.DataSource = Nothing
            GrillaIncluid.DataSource = Nothing
            GrillaSinInc.Rows.Clear()
            GrillaIncluid.Rows.Clear()
            Exit Sub
        End If

        Call CARGA_PRODUCTOS_SIN_INCLUIR()
        Call CARGA_PRODUCTOS_INCLUIDOS()
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
        For Each row As DataGridViewRow In Me.GrillaIncluid.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS_CON_R()
        For Each row As DataGridViewRow In Me.GrillaIncluid.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub ButtonADesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonADesmarcar.Click
        Call DESMARCAR_TODOS_CON_R()
    End Sub

    Private Sub btn_selecciona_Click(sender As Object, e As EventArgs) Handles btn_selecciona.Click
        Dim Codigo As String
        Dim codPro As Integer
        For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
            Codigo = row.Cells(1).Value
            codPro = row.Cells(0).Value
            If Codigo = True Then
                selecciona_registro(Val(cbmBodegas.SelectedValue), codPro)
            End If
        Next
        Call CARGA_PRODUCTOS_SIN_INCLUIR()
        Call CARGA_PRODUCTOS_INCLUIDOS()
        MessageBox.Show("Seleccion de productos fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub selecciona_registro(ByVal bod_codigo As Integer, ByVal pro_codigo As Integer)
        Dim classBodegas As class_bodegas = New class_bodegas
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classBodegas.cnn = _cnn
            classBodegas.pro_codigo = pro_codigo
            classBodegas.bod_codigo = bod_codigo
            ds = classBodegas.BODEGA_PRODUCTO_RELACIONA(_msgError)
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
        For Each row As DataGridViewRow In Me.GrillaIncluid.Rows
            Codigo = row.Cells(1).Value
            codPro = row.Cells(0).Value
            If Codigo = True Then
                deselecciona_registro(Val(cbmBodegas.SelectedValue), codPro)
            End If
        Next
        Call CARGA_PRODUCTOS_SIN_INCLUIR()
        Call CARGA_PRODUCTOS_INCLUIDOS()
        MessageBox.Show("Seleccion de productos fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub deselecciona_registro(ByVal bod_codigo As Integer, ByVal pro_codigo As Integer)
        Dim classBodega As class_bodegas = New class_bodegas
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            classBodega.cnn = _cnn
            classBodega.pro_codigo = pro_codigo
            classBodega.bod_codigo = bod_codigo
            ds = classBodega.BODEGA_PRODUCTO_QUITA_RELACION(_msgError)
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

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class