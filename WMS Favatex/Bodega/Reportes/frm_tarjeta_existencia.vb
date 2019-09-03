Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_tarjeta_existencia
    Private _cnn As String
    Private _cod_producto As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
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
    Private Sub frm_tarjeta_existencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
    End Sub
    Private Sub INICIALIZA()
        Call carga_bodegas()

        lblTotal.Text = "Total de registros: 0"
        'Me.Grilla.ClearSelection()
        'Me.WindowState = FormWindowState.Maximized

        lblTotal.Text = ""
    End Sub

    Private Sub carga_bodegas()
        Dim _msg As String
        Try
            Dim class_bodegas_tipo_ubicacion As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet
            ds = Nothing
            cmbBodega.DisplayMember = ""
            cmbBodega.ValueMember = "0"
            class_bodegas_tipo_ubicacion.cnn = _cnn
            _msg = ""
            ds = class_bodegas_tipo_ubicacion.BODEGA_CARGA_COMBO(_msg)
            If _msg = "" Then
                cmbBodega.DataSource = ds.Tables(0)
                cmbBodega.DisplayMember = "mensaje"
                cmbBodega.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_BODEGAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA()
        Dim class_existencias As class_existencias = New class_existencias
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Dim Saldo As Integer = 0
        Dim diaTEDesde As String = ""
        Dim mesTEDesde As String = ""

        Dim diaTEHasta As String = ""
        Dim mesTEHasta As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_existencias.cnn = _cnn
            If cmbBodega.Text = "" Then
                class_existencias.bod_codigo = 0
            Else
                class_existencias.bod_codigo = cmbBodega.SelectedValue
            End If

            class_existencias.pro_codigo = cod_producto


            _msg = ""
            Grilla.Rows.Clear()
            ds = class_existencias.carga_datos_tarjeta_existencia(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("mov_folio") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Saldo = Saldo + (ds.Tables(0).Rows(Fila)("dmo_cantEnt") - ds.Tables(0).Rows(Fila)("dmo_cantSal"))
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("mov_folio"),
                                            ds.Tables(0).Rows(Fila)("mov_fechMov"),
                                            ds.Tables(0).Rows(Fila)("pro_codinte"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("tmo_nombre"),
                                            ds.Tables(0).Rows(Fila)("tdo_nombre"),
                                            ds.Tables(0).Rows(Fila)("mov_observa"),
                                            ds.Tables(0).Rows(Fila)("dmo_cantEnt"),
                                            ds.Tables(0).Rows(Fila)("dmo_cantSal"),
                                            Saldo)
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "LISTADO DE TARJETA ESXISTENCIA - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        cmbBodega.SelectedValue = 0
        txtCodInt.Text = ""
        _cod_producto = 0
        txtNombre.Text = ""
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

    Private Sub ButtonExportar_Click(sender As Object, e As EventArgs) Handles ButtonExportar.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0

        Try

            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                                + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Call CARGA_GRILLA()
            class_comunes.ExportarExcel(Me.Grilla)
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
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

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click
        Dim frm As frm_imprimir = New frm_imprimir
        If cmbBodega.Text = "" Then
            frm.bod_codigo = 0
            frm.bod_nombre = "TODAS LAS BODEGAS"
        Else
            frm.bod_codigo = cmbBodega.SelectedValue
            frm.bod_nombre = cmbBodega.Text
        End If

        If txtNombre.Text = "" Then
            frm.pro_codigo = 0
            frm.pro_nombre = "TODOS LOS PRODUCTOS"
        Else
            frm.pro_codigo = cod_producto
            frm.pro_nombre = txtNombre.Text
        End If


        frm.Origen = "TX"
        frm.pro_codigo = cod_producto

        frm.ShowDialog()
    End Sub

    Private Sub txtCodInt_TextChanged(sender As Object, e As EventArgs) Handles txtCodInt.TextChanged

    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub
End Class