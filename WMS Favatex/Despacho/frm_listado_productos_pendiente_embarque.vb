Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_listado_productos_pendiente_embarque
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_listado_productos_pendiente_embarque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call CARGA_COMBO_CLIENTES()
        Call CARGA_COMBO_CLIENTES_2()
    End Sub

    Private Sub CARGA_COMBO_CLIENTES_2()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet
            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
            If _msg = "" Then
                Me.cmbCliente2.DataSource = ds.Tables(0)
                Me.cmbCliente2.DisplayMember = "MENSAJE"
                Me.cmbCliente2.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_CLIENTES_2", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_CLIENTES()
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

    Private Sub CARGA_GRILLA_PENDIENTE_DESPACHO()
        Dim classDespacho As class_despacha_picking = New class_despacha_picking
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classDespacho.cnn = _cnn

            If cmbCliente.Text = "" Then
                classDespacho.car_codigo = 0
            Else
                classDespacho.car_codigo = cmbCliente.SelectedValue
            End If

            If txtNumPiking.Text = "" Then
                classDespacho.pic_codigo = 0
            Else
                classDespacho.pic_codigo = CInt(txtNumPiking.Text)
            End If
            If txtNumGuia.Text = "" Then
                classDespacho.gde_numero = 0
            Else
                classDespacho.gde_numero = CInt(txtNumGuia.Text)
            End If
            If txtNumFac.Text = "" Then
                classDespacho.fac_numero = 0
            Else
                classDespacho.fac_numero = CInt(txtNumFac.Text)
            End If

            _msg = ""
            grila_pend.Rows.Clear()
            ds = classDespacho.PRODUCTOS_PENDIENTES_DEVOLUCION_EMBARQUES_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grila_pend.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_fila"),
                                            False,
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            ds.Tables(0).Rows(Fila)("fac_numero"),
                                            ds.Tables(0).Rows(Fila)("gde_numero"),
                                            ds.Tables(0).Rows(Fila)("gde_fecha"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("cantidad_pendiente"),
                                            ds.Tables(0).Rows(Fila)("pdd_fila"),
                                            ds.Tables(0).Rows(Fila)("es_fuedevuelta"))
                            Fila = Fila + 1
                        Loop

                        grila_pend.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_pend.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                    End If
                End If
                'lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString

            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PENDIENTE_DESPACHO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PENDIENTE_DESPACHO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub bt_buscar_Click(sender As Object, e As EventArgs) Handles bt_buscar.Click
        If cmbCliente.Text = "" Then
            MessageBox.Show("Debe seleccionar el cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente.Focus()
            Exit Sub
        End If
        Call CARGA_GRILLA_PENDIENTE_DESPACHO()
    End Sub

    Private Sub txtNumPiking_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumPiking.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtNumGuia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumGuia.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtNumFac_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumFac.KeyPress
        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub ButtonSMarcar_Click(sender As Object, e As EventArgs) Handles ButtonSMarcar.Click
        Call MARCAR_TODOS()
    End Sub
    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.grila_pend.Rows
            row.Cells(3).Value = True
        Next
    End Sub
    Private Sub ButtonSDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonSDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub
    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.grila_pend.Rows
            row.Cells(3).Value = False
        Next
    End Sub

    Private Sub ButtonSelecciona_Click(sender As Object, e As EventArgs) Handles ButtonSelecciona.Click
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Dim ds As DataSet = New DataSet
        Dim classDespacho As class_despacha_picking = New class_despacha_picking
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                For Each row As DataGridViewRow In Me.grila_pend.Rows
                    If row.Cells(3).Value = True Then
                        contador = contador + 1
                    End If
                Next

                If contador = 0 Then
                    MessageBox.Show("Debe seleccionar a lo menos un registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                For Each row As DataGridViewRow In Me.grila_pend.Rows
                    If row.Cells(3).Value = True Then
                        classDespacho.cnn = _cnn
                        classDespacho.pic_codigo = row.Cells(1).Value
                        classDespacho.pic_fila = row.Cells(2).Value()

                        ds = classDespacho.ELIMINA_REGISTRO_DEVOLUCIONES(_msgError, conexion)
                        If _msgError <> "" Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            ds = Nothing
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Sub
                            End If
                        End If
                    End If
                Next
                ds = Nothing

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                MessageBox.Show("Los items pendientes de embarque fueron cerrados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
                Call CARGA_GRILLA_PENDIENTE_DESPACHO()
            End Using
        Catch ex As Exception

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub CARGA_GRILLA_PENDIENTE_ELIMINADO()
        Dim classDespacho As class_despacha_picking = New class_despacha_picking
        Dim Fila As Integer = 0
        Try
            Dim mesEliminaDesde As String = ""
            Dim diaEliminaDesde As String = ""
            Dim mesEliminaHasta As String = ""
            Dim diaEliminaHasta As String = ""

            If chkCompromiso.Checked = True Then
                If CStr(dtpCompromisoDesde.Value.Month).Length = 1 Then
                    mesEliminaDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Month))
                Else
                    mesEliminaDesde = CStr(dtpCompromisoDesde.Value.Month)
                End If

                If CStr(dtpCompromisoDesde.Value.Day).Length = 1 Then
                    diaEliminaDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Day))
                Else
                    diaEliminaDesde = CStr(dtpCompromisoDesde.Value.Day)
                End If

                classDespacho.fecha_elimina_desde = CStr(dtpCompromisoDesde.Value.Year) + mesEliminaDesde + diaEliminaDesde


                If CStr(dtpCompromisoHasta.Value.Month).Length = 1 Then
                    mesEliminaHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Month))
                Else
                    mesEliminaHasta = CStr(dtpCompromisoHasta.Value.Month)
                End If

                If CStr(dtpCompromisoHasta.Value.Day).Length = 1 Then
                    diaEliminaHasta = Trim("0" + CStr(dtpCompromisoHasta.Value.Day))
                Else
                    diaEliminaHasta = CStr(dtpCompromisoHasta.Value.Day)
                End If

                classDespacho.fecha_elimina_hasta = CStr(dtpCompromisoHasta.Value.Year) + mesEliminaHasta + diaEliminaHasta
            Else
                classDespacho.fecha_elimina_desde = "19000101"
                classDespacho.fecha_elimina_hasta = "20501231"
            End If

            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classDespacho.cnn = _cnn

            If cmbCliente2.Text = "" Then
                classDespacho.car_codigo = 0
            Else
                classDespacho.car_codigo = cmbCliente2.SelectedValue
            End If

            _msg = ""
            grila_elim.Rows.Clear()
            ds = classDespacho.productos_pedientes_devolucion_embarques_eliminados_listado(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grila_elim.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_fila"),
                                            ds.Tables(0).Rows(Fila)("pic_codigostring"),
                                            ds.Tables(0).Rows(Fila)("fac_numero"),
                                            ds.Tables(0).Rows(Fila)("gde_numero"),
                                            ds.Tables(0).Rows(Fila)("gde_fecha"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("cantidad_pendiente"),
                                            ds.Tables(0).Rows(Fila)("pdd_fila"),
                                            ds.Tables(0).Rows(Fila)("es_fuedevuelta"),
                                            ds.Tables(0).Rows(Fila)("fec_eliminada"))
                            Fila = Fila + 1
                        Loop

                        grila_elim.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        grila_elim.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


                    End If
                End If
                'lblTotal.Text = "Cantidad de registros encontrados: " + ds.Tables(0).Rows.Count.ToString

            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_PENDIENTE_DESPACHO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_PENDIENTE_DESPACHO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub bt_buscarEliminados_Click_1(sender As Object, e As EventArgs) Handles bt_buscarEliminados.Click
        If cmbCliente2.Text = "" Then
            MessageBox.Show("Debe seleccionar el cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCliente2.Focus()
            Exit Sub
        End If
        Call CARGA_GRILLA_PENDIENTE_ELIMINADO()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim class_comunes As class_comunes = New class_comunes
        Dim respuesta As Integer = 0

        Try
            respuesta = MessageBox.Show("Esta acción podría tardar un tiempo considerable dependiendo de la cantidad de registros," _
                                                + Chr(10) + "¿Desea seguir ejecutando la acción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = vbNo Then
                Exit Sub
            End If
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            class_comunes.ExportarExcel(Me.grila_elim)
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkCompromiso_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompromiso.CheckedChanged
        If chkCompromiso.Checked = True Then
            dtpCompromisoDesde.Enabled = True
            dtpCompromisoHasta.Enabled = True
        Else
            dtpCompromisoDesde.Enabled = False
            dtpCompromisoHasta.Enabled = False
        End If
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click

    End Sub

    Private Sub LIMPIAR_FORMULARIO()
        Try
            cmbCliente.SelectedValue = 0
            txtNumPiking.Text = "0"
            txtNumGuia.Text = "0"
            txtNumFac.Text = "0"
            grila_pend.DataSource = Nothing
            grila_pend.Rows.Clear()

            cmbCliente2.SelectedValue = 0
            chkCompromiso.Checked = False
            dtpCompromisoDesde.Value = GLO_FECHA_SISTEMA
            dtpCompromisoHasta.Value = GLO_FECHA_SISTEMA
            grila_elim.DataSource = Nothing
            grila_elim.Rows.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class