Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_gnera_fila_picking
    Dim _cnn As String
    Dim _pro_codigo As Integer
    Dim _cod_producto As Integer
    Dim _pro_nombre As String
    Dim _num_bultos As Integer
    Dim _cantidad As Integer

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
    Public Property pro_nombre() As String
        Get
            Return _pro_nombre
        End Get
        Set(ByVal value As String)
            _pro_nombre = value
        End Set
    End Property
    Public Property num_bultos() As Integer
        Get
            Return _num_bultos
        End Get
        Set(ByVal value As Integer)
            _num_bultos = value
        End Set
    End Property
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
    Public Property cod_producto() As Integer
        Get
            Return _cod_producto
        End Get
        Set(ByVal value As Integer)
            _cod_producto = value
        End Set
    End Property

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click
        GLO_CODIGO_PRODUCTOS = 0
        GLO_CANTIDAD_PRODUCTOS = 0
        GLO_NOMBRE_PRODUCTOS = ""
        GLO_NUMERO_BULTOS_PRODUCTOS = 0
        Me.Dispose()
    End Sub

    Private Sub frm_gnera_fila_picking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        txtNombreProducto.Text = _pro_nombre
        txtCantidad.Text = _cantidad
        txtNumBultos.Text = _num_bultos
        txtCantidadNew.Text = "0"
        txtBultosNew.Text = "0"
        Call CARGA_COMBO_PRODUCTOS_RELACIONADOS()
    End Sub

    Private Sub CARGA_COMBO_PRODUCTOS_RELACIONADOS()
        Dim _msg As String
        Try
            Dim classProducto As class_producto = New class_producto
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classProducto.cnn = _cnn
            classProducto.pro_codigo = _pro_codigo
            _msg = ""
            ds = classProducto.CARGA_COMBO_PRODUCTOS_RELACIONADOS(_msg)
            If _msg = "" Then
                Me.cmbProductos.DataSource = ds.Tables(0)
                Me.cmbProductos.DisplayMember = "MENSAJE"
                Me.cmbProductos.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PRODUCTOS_RELACIONADOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbProductos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbProductos.SelectionChangeCommitted
        Call SELECCIONA_DATOS_PRODUCTOS()
    End Sub

    Private Sub SELECCIONA_DATOS_PRODUCTOS()
        Dim class_producto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet

        txtBultosNew.Text = "0"
        class_producto.cnn = _cnn
        class_producto.pro_codigo = cmbProductos.SelectedValue
        ds = class_producto.PRODUCTOS_BUSQUEDA(_msgError)
        If _msgError = "" Then
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0)("pro_nombre") <> "" Then
                    txtBultosNew.Text = ds.Tables(0).Rows(0)("pro_numerobulto")
                End If
            End If
        Else
            MessageBox.Show(_msgError + "\SELECCIONA_DATOS_PRODUCTOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click
        Try
            If txtCantidadNew.Text <> "" And txtCantidadNew.Text <> "0" Then
                If txtCantidad.Text = "" Then
                    txtCantidad.Text = "0"
                End If

                If CInt(txtCantidad.Text) < CInt(txtCantidadNew.Text) Then
                    MessageBox.Show("La cantidad a reemplazar no puede ser superior a la cantidad original", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtCantidadNew.Focus()
                    Exit Sub
                End If

                'GLO_CODIGO_PRODUCTOS = cmbProductos.SelectedValue
                GLO_CANTIDAD_PRODUCTOS = txtCantidadNew.Text
                'GLO_NOMBRE_PRODUCTOS = cmbProductos.Text
                'GLO_NUMERO_BULTOS_PRODUCTOS = txtBultosNew.Text
            End If
            Me.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub txtCodInt_TextChanged(sender As Object, e As EventArgs) Handles txtCodInt.TextChanged

    End Sub

    Private Sub txtCodInt_LostFocus(sender As Object, e As EventArgs) Handles txtCodInt.LostFocus
        If txtCodInt.Text <> "" Then
            _cod_producto = 0
            Call mostar_producto()

            If _cod_producto = 0 Then
                txtCodInt.Text = ""
                txtNombre.Text = ""
            End If

        Else
            _cod_producto = 0
            txtCodInt.Text = ""
            txtNombre.Text = ""
        End If
    End Sub

    Private Sub mostar_producto()
        Dim class_existencias As class_existencias = New class_existencias
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing

            GLO_CODIGO_PRODUCTOS = 0
            GLO_NOMBRE_PRODUCTOS = ""
            GLO_NUMERO_BULTOS_PRODUCTOS = 0

            class_existencias.cnn = _cnn
            If txtCodInt.Text = "" Then
                class_existencias.pro_codInt = "-"
            Else
                class_existencias.pro_codInt = txtCodInt.Text
            End If
            _msg = ""
            ds = class_existencias.carga_datos_producto_por_codInterno(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        GLO_CODIGO_PRODUCTOS = ds.Tables(0).Rows(Fila)("pro_codigo")
                        GLO_NOMBRE_PRODUCTOS = ds.Tables(0).Rows(Fila)("pro_nombre")
                        GLO_NUMERO_BULTOS_PRODUCTOS = ds.Tables(0).Rows(Fila)("pro_numerobulto")
                        txtBultosNew.Text = ds.Tables(0).Rows(Fila)("pro_numerobulto")

                        txtNombre.Text = ds.Tables(0).Rows(Fila)("pro_nombre")
                        cod_producto = ds.Tables(0).Rows(Fila)("pro_codigo")
                    End If
                End If
                'Me.Text = "LISTADO DE TARJETA ESXISTENCIA - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\Busca producto ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "Busca producto", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub



End Class