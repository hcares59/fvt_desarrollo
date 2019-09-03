Imports System.Data.SqlClient
Imports System.Data
Imports System.Transactions
Imports System.IO
Public Class frm_clientes_productos
    Private _cnn As String
    Private _pro_codigo As Integer
    Private _car_codigo As Integer
    Private _totdos As Boolean

    Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
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

    Private Sub frm_clientes_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Me.Grilla.Columns(2).Frozen = True
        Call LIMPIAR()

        If _car_codigo > 0 Then
            'If _car_codigo = 2 Then
            '    chkHomologa.Visible = True
            'End If

            _totdos = True
            Call CARGA_COMBO_CLIENTE()
            cmbCliente.SelectedValue = _car_codigo
            cmbCliente.Enabled = False
            Call CARGA_LISTADO()
        End If

    End Sub

    Private Sub LIMPIAR()
        'Call CARGA_COMBO_CLIENTE()
        txtSku.Text = ""
        txtNombreSku.Text = ""
        txtCodigoFav.Text = ""
        txtNombre.Text = ""
        txtVenta.Text = "0"
        txtPublico.Text = "0"
        txtBuscaSku.Text = ""
        txtBuscaNombre.Text = ""
        'cmbCliente.Enabled = True
    End Sub

    Private Sub CARGA_COMBO_CLIENTE()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
            If _msg = "" Then
                Me.cmbCliente.DataSource = ds.Tables(0)
                Me.cmbCliente.DisplayMember = "MENSAJE"
                Me.cmbCliente.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CLIENTE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub BtnBuscaDoc_Click(sender As Object, e As EventArgs) Handles BtnBuscaDoc.Click
        Dim frm As frm_busqueda_productos_para_relacionar = New frm_busqueda_productos_para_relacionar

        If cmbCliente.Text = "" Then
            MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Sub
        End If

        GLO_CODIGO_PRODUCTOS = 0
        GLO_NOMBRE_PRODUCTOS = ""
        GLO_CODIGO_INTERNO = ""
        frm.cnn = _cnn
        frm.car_codigo = cmbCliente.SelectedValue
        frm.ShowDialog()

        If GLO_CODIGO_PRODUCTOS > 0 Then
            txtCodigoFav.Text = GLO_CODIGO_INTERNO
            txtNombre.Text = GLO_NOMBRE_PRODUCTOS
            Call CARGA_REGISTRO_RELACIONADO_POR_CODIGO_OSKU(GLO_CODIGO_INTERNO, "F")
        End If
    End Sub

    Private Sub CARGA_REGISTRO_RELACIONADO_POR_CODIGO_OSKU(ByVal codigo As String, ByVal buscar As String)
        Dim class_prod As class_producto = New class_producto
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            If cmbCliente.Text = "" Then
                MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK)
                cmbCliente.Focus()
                Exit Sub
            End If

            ds = Nothing
            class_prod.cnn = _cnn
            class_prod.car_codigo = cmbCliente.SelectedValue
            class_prod.codigoGenerico = codigo
            class_prod.buscar = buscar
            _msg = ""
            ds = class_prod.PRODUCTOS_RELACIONADO_POR_CODIGO_OSKU_BUSCAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        GLO_CODIGO_PRODUCTOS = ds.Tables(0).Rows(Fila)("pro_codigo")
                        txtSku.Text = ds.Tables(0).Rows(Fila)("sku_cliente")
                        txtNombreSku.Text = ds.Tables(0).Rows(Fila)("sku_nombre")
                        txtCodigoFav.Text = ds.Tables(0).Rows(Fila)("cod_favatex")
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("pro_nombre")
                        txtVenta.Text = FormatNumber(ds.Tables(0).Rows(Fila)("pro_precioventa"), 0)
                        txtPublico.Text = FormatNumber(ds.Tables(0).Rows(Fila)("pro_precioventapublico"), 0)
                        If ds.Tables(0).Rows(Fila)("sku_tipo") = 1 Then
                            rdCadema.Checked = True
                        ElseIf ds.Tables(0).Rows(Fila)("sku_tipo") = 2 Then
                            rdInternet.Checked = True
                        ElseIf ds.Tables(0).Rows(Fila)("sku_tipo") = 3 Then
                            rdAmbos.Checked = True
                        Else
                            rdCadema.Checked = 0
                            rdInternet.Checked = 0
                            rdAmbos.Checked = 0
                        End If
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("sku_activo")
                        _pro_codigo = ds.Tables(0).Rows(Fila)("pro_codigo")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REGISTRO_RELACIONADO_POR_CODIGO_OSKU", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO_RELACIONADO_POR_CODIGO_OSKU", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub txtCodigoFav_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoFav.TextChanged

    End Sub

    Private Sub txtCodigoFav_LostFocus(sender As Object, e As EventArgs) Handles txtCodigoFav.LostFocus
        If txtCodigoFav.Text <> "" Then
            Call CARGA_REGISTRO_RELACIONADO_POR_CODIGO_OSKU(txtCodigoFav.Text, "F")
        End If
    End Sub

    Private Sub txtSku_LostFocus(sender As Object, e As EventArgs) Handles txtSku.LostFocus
        If txtSku.Text <> "" Then
            Call CARGA_REGISTRO_RELACIONADO_POR_CODIGO_OSKU(txtSku.Text, "S")
        End If
    End Sub

    Private Sub ButtonLimpiar_Click(sender As Object, e As EventArgs) Handles ButtonLimpiar.Click
        txtBuscaSku.Text = ""
        txtBuscaNombre.Text = ""
        Call CARGA_LISTADO_INTERNO_NOMBRE()
    End Sub

    Private Sub cmd_guardar_Click(sender As Object, e As EventArgs) Handles cmd_guardar.Click
        If VALIDA_FORM() = False Then
            Exit Sub
        End If

        Call GUARDA_REGISTRO()
        Call LIMPIAR()
        Call CARGA_LISTADO()
    End Sub

    Private Sub GUARDA_REGISTRO()
        Dim classprod As class_cartera = New class_cartera
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classprod.cnn = _cnn
            classprod.pro_codigo = GLO_CODIGO_PRODUCTOS
            classprod.car_codigo = cmbCliente.SelectedValue
            classprod.sku_cartera = txtSku.Text
            classprod.sku_carnomb = txtNombreSku.Text
            classprod.pro_precioventa = txtVenta.Text
            classprod.pro_preciovtapub = txtPublico.Text

            If rdCadema.Checked = True Then
                classprod.sku_tipo = 1
            ElseIf rdInternet.Checked = True Then
                classprod.sku_tipo = 2
            ElseIf rdAmbos.Checked = True Then
                classprod.sku_tipo = 3
            End If

            classprod.sku_activo = chkActivo.Checked

            ds = classprod.CARTERA_PRODUCTO_GUARDA_REGISTRO(_msgError)
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

            MessageBox.Show("Los datos fueron guardados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function VALIDA_FORM()
        VALIDA_FORM = False
        If cmbCliente.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar liente, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Function
        End If
        If Trim(txtCodigoFav.Text) = "" Then
            MessageBox.Show("Debe ingresar un producto, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodigoFav.Focus()
            Exit Function
        End If

        If Trim(txtSku.Text) = "" Then
            MessageBox.Show("Debe ingresar numero de sku, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSku.Focus()
            Exit Function
        End If
        If Trim(txtNombreSku.Text) = "" Then
            MessageBox.Show("Debe ingresar nombre de Sku, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombreSku.Focus()
            Exit Function
        End If

        'If Trim(txtVenta.Text) = "" Then
        '    MessageBox.Show("Debe ingresar valor de venta, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtVenta.Focus()
        '    Exit Function
        'End If
        'If Trim(txtPublico.Text) = "" Then
        '    MessageBox.Show("Debe ingresar valor publico, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtPublico.Focus()
        '    Exit Function
        'End If


        VALIDA_FORM = True

    End Function

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

    End Sub

    Private Sub CARGA_LISTADO()
        Dim classCartera As class_cartera = New class_cartera
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Dim canal As String = ""
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classCartera.cnn = _cnn
            classCartera.car_codigo = cmbCliente.SelectedValue
            classCartera.todos = _totdos
            classCartera.pro_codigo = 0
            _msg = ""

            Grilla.DataSource = Nothing
            Grilla.Rows.Clear()
            lblTotal.Text = "Total registro: 0"
            ds = classCartera.PRODUCTOS_RELACIONADOS_CARTERA(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_Codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count

                            If ds.Tables(0).Rows(Fila)("sku_tipo") = 1 Then
                                canal = "CADENA"
                            ElseIf ds.Tables(0).Rows(Fila)("sku_tipo") = 2 Then
                                canal = "INTERNET"
                            ElseIf ds.Tables(0).Rows(Fila)("sku_tipo") = 3 Then
                                canal = "CADENA /INTERNET"
                            End If

                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pro_Codigo"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                            ds.Tables(0).Rows(Fila)("pro_codInt"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            canal,
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_precioventa"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_precioventapublico"), 0),
                                            "",
                                            "")
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total registro: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_DATOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_DATOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCliente.SelectionChangeCommitted
        Call CARGA_LISTADO()
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Dim respuesta As Integer = 0
        If e.ColumnIndex = 8 Then
            Call CARGA_DATOS_REGISTRO(Grilla.Rows(e.RowIndex).Cells(0).Value)
        ElseIf e.ColumnIndex = 9 Then
            respuesta = MessageBox.Show("¿Está seguro(a) de eliminar el registro selccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = vbNo Then
                Exit Sub
            End If

            Call ELIMINA_REGISTRO(cmbCliente.SelectedValue, Grilla.Rows(e.RowIndex).Cells(0).Value, Grilla.Rows(e.RowIndex).Cells(1).Value)
        End If

    End Sub

    Private Sub ELIMINA_REGISTRO(ByVal carCodigo As Integer, ByVal proCodigo As Integer, ByVal skuCartera As String)
        Dim class_cartera As class_cartera = New class_cartera
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""

        Try
            ds = Nothing
            class_cartera.cnn = _cnn
            class_cartera.car_codigo = carCodigo
            class_cartera.pro_codigo = proCodigo
            class_cartera.sku_cartera = skuCartera

            ds = class_cartera.PRODUCTOS_RELACIONADOS_CARTERA_ELIMINA(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            MessageBox.Show("El registro fue eliminado en forma excelente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CARGA_LISTADO()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub


    Private Sub CARGA_DATOS_REGISTRO(ByVal CodProducto As Integer)
        Dim classCartera As class_cartera = New class_cartera
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing

            rdCadema.Checked = False
            rdInternet.Checked = False
            rdAmbos.Checked = False

            classCartera.cnn = _cnn
            classCartera.car_codigo = cmbCliente.SelectedValue
            classCartera.pro_codigo = CodProducto
            _msg = ""
            ds = classCartera.PRODUCTOS_RELACIONADOS_CARTERA(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then

                        txtNombre.Text = ds.Tables(0).Rows(Fila)("pro_nombre")
                        txtSku.Text = ds.Tables(0).Rows(Fila)("sku_cartera")
                        txtCodigoFav.Text = ds.Tables(0).Rows(Fila)("pro_codint")
                        txtNombreSku.Text = ds.Tables(0).Rows(Fila)("sku_cartera_nombre")
                        txtVenta.Text = ds.Tables(0).Rows(Fila)("pro_precioventa")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("sku_activo")
                        txtPublico.Text = ds.Tables(0).Rows(Fila)("pro_precioventapublico")
                        If Val(ds.Tables(0).Rows(Fila)("sku_tipo")) = 1 Then
                            rdCadema.Checked = True
                        ElseIf Val(ds.Tables(0).Rows(Fila)("sku_tipo")) = 2 Then
                            rdInternet.Checked = True
                        ElseIf Val(ds.Tables(0).Rows(Fila)("sku_tipo")) = 3 Then
                            rdAmbos.Checked = True
                        End If
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_DATOS_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_DATOS_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub txtSku_TextChanged(sender As Object, e As EventArgs) Handles txtSku.TextChanged

    End Sub

    Private Sub txtBuscaSku_TextChanged(sender As Object, e As EventArgs) Handles txtBuscaSku.TextChanged
        Call CARGA_LISTADO_INTERNO_NOMBRE()
    End Sub

    Private Sub CARGA_LISTADO_INTERNO_NOMBRE()
        Dim classCartera As class_cartera = New class_cartera
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Dim canal As String = ""
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classCartera.cnn = _cnn
            classCartera.car_codigo = cmbCliente.SelectedValue

            If txtBuscaSku.Text <> "" Then
                classCartera.pro_codigointerno = txtBuscaSku.Text
            Else
                classCartera.pro_codigointerno = "-"
            End If

            If txtBuscaNombre.Text <> "" Then
                classCartera.pro_nombre = txtBuscaNombre.Text
            Else
                classCartera.pro_nombre = "-"
            End If

            _msg = ""

            Grilla.DataSource = Nothing
            Grilla.Rows.Clear()
            lblTotal.Text = "Total registro: 0"
            ds = classCartera.PRODUCTOS_RELACIONADOS_CARTERA_INTERNO_NOMBRE(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_Codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count

                            If ds.Tables(0).Rows(Fila)("sku_tipo") = 1 Then
                                canal = "CADENA"
                            ElseIf ds.Tables(0).Rows(Fila)("sku_tipo") = 2 Then
                                canal = "INTERNET"
                            ElseIf ds.Tables(0).Rows(Fila)("sku_tipo") = 3 Then
                                canal = "CADENA /INTERNET"
                            End If

                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("pro_Codigo"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                            ds.Tables(0).Rows(Fila)("pro_codInt"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            canal,
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_precioventa"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_precioventapublico"), 0))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total registro: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_DATOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_DATOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub txtBuscaNombre_TextChanged(sender As Object, e As EventArgs) Handles txtBuscaNombre.TextChanged
        Call CARGA_LISTADO_INTERNO_NOMBRE()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click

    End Sub

    Private Sub cm_limpiar_Click(sender As Object, e As EventArgs) Handles cm_limpiar.Click
        Call LIMPIAR()
    End Sub
End Class