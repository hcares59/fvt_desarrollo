Public Class frm_ingreso_factura_nota_credito
    Private _cnn As String
    Private _fac_numero As Long
    Private _car_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property fac_numero() As Long
        Get
            Return _fac_numero
        End Get
        Set(ByVal value As Long)
            _fac_numero = value
        End Set
    End Property
    Public Property car_codigo() As Integer
        Get
            Return _car_codigo
        End Get
        Set(ByVal value As Integer)
            _car_codigo = value
        End Set
    End Property

    Private Sub frm_ingreso_factura_nota_credito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _fac_numero > 0 Then
            txtNumFactura.Text = fac_numero
        End If

        txtNumero.Focus()
    End Sub
    Private Sub cmbGuardar_Click(sender As Object, e As EventArgs) Handles cmbGuardar.Click
        If valida_form() = False Then
            Exit Sub
        End If

        Call guardar_registro()
    End Sub
    Private Function valida_form() As Boolean
        valida_form = False
        If Trim(txtNumero.Text) = "" Then
            MessageBox.Show("Debe ingresar el numero de la nota de credito, favor verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumero.Focus()
            Exit Function
        End If
        valida_form = True
    End Function

    Private Sub guardar_registro()
        Dim class_factura_picking As class_factura_picking = New class_factura_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim respuesta As Integer = 0
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            class_factura_picking.cnn = _cnn
            class_factura_picking.fac_numero = fac_numero
            class_factura_picking.fac_numeronc = txtNumero.Text
            class_factura_picking.car_codigo = car_codigo
            ds = class_factura_picking.actualiza_factura_nota_credito(_msgError)
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
                    fac_numero = ds.Tables(0).Rows(0)("codigo")
                End If
            End If

            ds = Nothing
            MessageBox.Show("Registro inresado correctamentre", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
    End Sub

    Private Sub cmbCancelar_Click(sender As Object, e As EventArgs) Handles cmbCancelar.Click
        Me.Dispose()
    End Sub
    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class