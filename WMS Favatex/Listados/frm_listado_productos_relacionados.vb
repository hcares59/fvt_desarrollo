Public Class frm_listado_productos_relacionados
    Private _pro_codigo As Integer
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
        End Set
    End Property

    Private Sub frm_listado_productos_relacionados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call BSCAR_PRODUCTOS()
        Call CARGA_GRILLA_PRODUCTOS_RELACIONADOS()
    End Sub

    Private Sub CARGA_GRILLA_PRODUCTOS_RELACIONADOS()
        Dim classProducto As class_producto = New class_producto

        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim usuario As String = ""
        Try
            classProducto.cnn = _cnn
            classProducto.pro_codigo = _pro_codigo

            If txtBuscar.Text = "" Then
                classProducto.pro_nombre = "-"
            Else
                classProducto.pro_nombre = txtBuscar.Text
            End If

            If txtCodigo.Text = "" Then
                classProducto.codigo_interno = "-"
            Else
                classProducto.codigo_interno = txtCodigo.Text
            End If

            ds = classProducto.PRODUCTOS_RELACIONADOS_LISTADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Grilla.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                               ds.Tables(0).Rows(Fila)("pro_nombre"),
                                               0,
                                               ds.Tables(0).Rows(Fila)("pro_codigo"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_PRODUCTOS_RELACIONADOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_PRODUCTOS_RELACIONADOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BSCAR_PRODUCTOS()
        Dim classProducto As class_producto = New class_producto

        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim usuario As String = ""
        Try
            classProducto.cnn = _cnn
            classProducto.pro_codigo = _pro_codigo

            ds = classProducto.PRODUCTOS_BUSQUEDA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Grilla.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        txtProducto.Text = ds.Tables(0).Rows(Fila)("pro_nombre")
                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\BSCAR_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\BSCAR_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick

    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click
        GLO_CODIGO_PRODUCTOS = 0
        Me.Dispose()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        GLO_CODIGO_PRODUCTOS = 0
        GLO_CODIGO_PRODUCTOS = Grilla.Rows(e.RowIndex).Cells(3).Value
        Me.Dispose()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Call CARGA_GRILLA_PRODUCTOS_RELACIONADOS()
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub txtCodigo_LostFocus(sender As Object, e As EventArgs) Handles txtCodigo.LostFocus
        Call CARGA_GRILLA_PRODUCTOS_RELACIONADOS()
    End Sub
End Class