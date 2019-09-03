Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_mant_factura
    Private _cnn As String
    Private _pic_codigo As Integer
    Dim mesfecha As String = ""
    Dim diafecha As String = ""
    Private _nombreProducto As String
    Private _pic_fila As Integer
    Dim _numFactura As Long = 0
    Dim _fechaFactura As Date

    Public Property nombreProducto() As String
        Get
            Return _nombreProducto
        End Get
        Set(ByVal value As String)
            _nombreProducto = value
        End Set
    End Property
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property pic_codigo() As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
        End Set
    End Property
    Public Property pic_fila() As Integer
        Get
            Return _pic_fila
        End Get
        Set(ByVal value As Integer)
            _pic_fila = value
        End Set
    End Property
    Public Property numFactura() As Long
        Get
            Return _numFactura
        End Get
        Set(ByVal value As Long)
            _numFactura = value
        End Set
    End Property
    Public Property fechaFactura() As Date
        Get
            Return _fechaFactura
        End Get
        Set(ByVal value As Date)
            _fechaFactura = value
        End Set
    End Property

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frm_mant_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _pic_codigo <> 0 Then
            lbl_nombre_producto.Text = nombreProducto
            txtNumero.Text = _numFactura
            dtpFechaFactura.Text = _fechaFactura
        End If
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        Dim class_picking As class_picking = New class_picking

        If CStr(dtpFechaFactura.Value.Month).Length = 1 Then
            mesfecha = Trim("0" + CStr(dtpFechaFactura.Value.Month))
        Else
            mesfecha = CStr(dtpFechaFactura.Value.Month)
        End If

        If CStr(dtpFechaFactura.Value.Day).Length = 1 Then
            diafecha = Trim("0" + CStr(dtpFechaFactura.Value.Day))
        Else
            diafecha = CStr(dtpFechaFactura.Value.Day)
        End If

        Call guarda_registro(CStr(dtpFechaFactura.Value.Year) + mesfecha + diafecha)
    End Sub

    Private Sub guarda_registro(ByVal fecha As String)
        Dim class_picking As class_picking = New class_picking
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                class_picking.pic_codigo = _pic_codigo
                class_picking.pic_fila = _pic_fila
                class_picking.fac_numero = txtNumero.Text
                class_picking.pic_fechafactura = fecha

                ds = class_picking.picking_listado_actualiza_facturacion_guarda(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("codigo") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        _pic_codigo = ds.Tables(0).Rows(0)("codigo")
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                MessageBox.Show("Se ha modificado con existo los datos de la factura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Dispose()
                'End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress
        Dim caracter As Char = e.KeyChar

        ' comprobar si el caracter es un número o el retroceso  
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class