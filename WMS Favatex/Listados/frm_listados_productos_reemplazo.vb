Public Class frm_listados_productos_reemplazo
    Private _cnn As String
    Private _pro_codigo As Integer

    Const COL_GRI_PRO_CODIGO As Integer = 0
    Const COL_GRI_PRO_CODIGO_INTERNO As Integer = 1
    Const COL_GRI_PRO_NOMBRE As Integer = 2
    Const COL_GRI_PRO_CANTIDAD As Integer = 3

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property pro_codigo() As String
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As String)
            _pro_codigo = value
        End Set
    End Property
    Private Sub frm_listados_productos_reemplazo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CARGA_GRILLA_PRODUCTOS_RELACIONADOS()
        Call CONFIGURA_COLUMNAS()
    End Sub

    Private Sub CONFIGURA_COLUMNAS()
        Grilla.Columns(COL_GRI_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_PRO_CODIGO_INTERNO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_PRO_NOMBRE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(COL_GRI_PRO_CANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub CARGA_GRILLA_PRODUCTOS_RELACIONADOS()
        Dim classProductos As class_producto = New class_producto

        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim usuario As String = ""
        Try

            Dim _msg As String
            ds = Nothing
            classProductos.cnn = _cnn
            classProductos.pro_codigo = pro_codigo

            _msg = ""
            Grilla.Rows.Clear()
            ds = classProductos.LISTADO_CAMBIO_PRODUCTO_SELECCIONADOS(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                        ds.Tables(0).Rows(Fila)("pro_codint"),
                                        ds.Tables(0).Rows(Fila)("pro_nombre"),
                                        0)
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                Me.Text = "Listado de productos cambio - [ulgtima consulta: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_PRODUCTOS_RELACIONADOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_PRODUCTOS_RELACIONADOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick

    End Sub

    Private Sub Grilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentDoubleClick
        GLO_CODIGO_PRODUCTOS = 0
        GLO_CODIGO_PRODUCTOS = Grilla.Rows(e.RowIndex).Cells(0).Value
        Me.Dispose()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        GLO_CODIGO_PRODUCTOS = 0
        Me.Dispose()
    End Sub
End Class