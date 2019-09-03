Imports System.Data.SqlClient
Imports System.Data
Imports System.Transactions
Imports System.IO

Public Class frm_busqueda_productos_para_relacionar
    Dim _cnn As String
    Dim _car_codigo As Integer

    Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Property car_codigo() As Integer
        Get
            Return _car_codigo
        End Get
        Set(ByVal value As Integer)
            _car_codigo = value
        End Set
    End Property

    Private Sub frm_busqueda_productos_para_relacionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        cmbCategoria.DataSource = Nothing
        cmbCategoria.Items.Clear()
        Call CARGA_COMBO_CATEGORIAS()

        txtBuscar.Text = ""
        lblTotal.Text = "REGISTROS ENCONTRADOS: 0"
    End Sub

    Private Sub CARGA_COMBO_CATEGORIAS()
        Dim _msg As String
        Try
            Dim class_categoria As class_categorias = New class_categorias
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_categoria.cnn = _cnn
            _msg = ""
            ds = class_categoria.CARGA_COMBO_CATEGORIA(_msg)
            If _msg = "" Then
                Me.cmbCategoria.DataSource = ds.Tables(0)
                Me.cmbCategoria.DisplayMember = "mensaje"
                Me.cmbCategoria.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CATEGORIAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbCategoria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCategoria.SelectionChangeCommitted
        Call CARGA_COMBO_SUBCATEGORIAS()
    End Sub
    Private Sub CARGA_COMBO_SUBCATEGORIAS()
        Dim _msg As String
        Try
            Dim class_subcategoria As class_subcategoria = New class_subcategoria
            Dim ds As DataSet = New DataSet
            ds = Nothing
            class_subcategoria.cnn = _cnn
            class_subcategoria.cat_codigo = cmbCategoria.SelectedValue
            _msg = ""
            ds = class_subcategoria.CARGA_COMBO_SUBCATEGORIA(_msg)
            If _msg = "" Then
                Me.cmbSubcategoria.DataSource = ds.Tables(0)
                Me.cmbSubcategoria.DisplayMember = "mensaje"
                Me.cmbSubcategoria.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_SUBCATEGORIAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Call CARGA_GRILLA_PRODUCTOS_NO_RELACIONADOS()
    End Sub

    Private Sub CARGA_GRILLA_PRODUCTOS_NO_RELACIONADOS()
        Dim classProd As class_producto = New class_producto

        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim usuario As String = ""
        Try
            classProd.cnn = _cnn
            classProd.car_codigo = _car_codigo

            If cmbCategoria.Text = "" Then
                classProd.cat_codigo = 0
            Else
                classProd.cat_codigo = cmbCategoria.SelectedValue
            End If

            If cmbSubcategoria.Text = "" Then
                classProd.sub_codigo = 0
            Else
                classProd.sub_codigo = cmbSubcategoria.SelectedValue
            End If

            If txtBuscar.Text = "" Then
                classProd.pro_nombre = "-"
            Else
                classProd.pro_nombre = txtBuscar.Text
            End If

            ds = classProd.PRODUCTOS_SIN_RELACION_CLIENTE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Grilla.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("pro_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                               ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                               ds.Tables(0).Rows(Fila)("pro_nombre"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
                lblTotal.Text = "REGISTROS ENCONTRADOS: " + ds.Tables(0).Rows.Count.ToString

                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_PRODUCTOS_NO_RELACIONADOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_PRODUCTOS_NO_RELACIONADOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        If e.ColumnIndex = 3 Then
            GLO_CODIGO_PRODUCTOS = Grilla.Rows(e.RowIndex).Cells(0).Value
            GLO_CODIGO_INTERNO = Grilla.Rows(e.RowIndex).Cells(1).Value
            GLO_NOMBRE_PRODUCTOS = Grilla.Rows(e.RowIndex).Cells(2).Value

            Me.Dispose()
        End If
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        GLO_CODIGO_PRODUCTOS = 0
        GLO_NOMBRE_PRODUCTOS = ""
        GLO_CODIGO_INTERNO = ""
    End Sub
End Class