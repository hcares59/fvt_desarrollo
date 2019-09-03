Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_listado_citas
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_listado_citas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        '_cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_01;User ID=sa;Password=S1st3m4s"
        Call INICIALIZA()
    End Sub

    Private Sub INICIALIZA()
        Call CARGA_COMBO_CLIENTE()
        Me.Grilla.ClearSelection()
        Me.WindowState = FormWindowState.Maximized
        'Me.Grilla.Columns(3).Frozen = True
        GLO_FECHA_SISTEMA = Date.Today
        dtpCompromisoDesde.Value = GLO_FECHA_SISTEMA
        lblTotal.Text = ""
        txtHoraIni.Text = "08:00"
        txtHoraTer.Text = "20:00"
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
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_BOLETA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call CARGA_GRILLA()
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classCita As class_citas = New class_citas
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Dim diaCompromisoDesde As String = ""
        Dim mesCompromisoDesde As String = ""

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classCita.cnn = _cnn
            classCita.cit_codigo = 0

            If cmbCliente.Text = "" Then
                classCita.car_codigo = 0
            Else
                classCita.car_codigo = cmbCliente.SelectedValue

            End If


            If chkFecha.Checked = True Then
                If CStr(dtpCompromisoDesde.Value.Month).Length = 1 Then
                    mesCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Month))
                Else
                    mesCompromisoDesde = CStr(dtpCompromisoDesde.Value.Month)
                End If

                If CStr(dtpCompromisoDesde.Value.Day).Length = 1 Then
                    diaCompromisoDesde = Trim("0" + CStr(dtpCompromisoDesde.Value.Day))
                Else
                    diaCompromisoDesde = CStr(dtpCompromisoDesde.Value.Day)
                End If

                classCita.fecha_compromiso = CStr(dtpCompromisoDesde.Value.Year) + mesCompromisoDesde + diaCompromisoDesde
            Else
                classCita.fecha_compromiso = "-"
            End If
            'fecha compromiso desde

            If txtHoraIni.Text = ":" Then
                txtHoraIni.Text = "00:00"
            End If

            If txtHoraTer.Text = ":" Then
                txtHoraTer.Text = "24:00"
            End If
            classCita.hora_inicio = txtHoraIni.Text
            classCita.hora_termino = txtHoraTer.Text
            classCita.solo_codigo = 0

            _msg = ""
            Grilla.Rows.Clear()
            ds = classCita.CITA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("cit_codigo"),
                                            ds.Tables(0).Rows(Fila)("cit_numero"),
                                            ds.Tables(0).Rows(Fila)("cit_fecha"),
                                            ds.Tables(0).Rows(Fila)("cit_hora"),
                                            ds.Tables(0).Rows(Fila)("car_codigo"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            ds.Tables(0).Rows(Fila)("cit_ordencompra"),
                                            ds.Tables(0).Rows(Fila)("cit_fechaorden"),
                                            ds.Tables(0).Rows(Fila)("eci_codigo"),
                                            ds.Tables(0).Rows(Fila)("eci_nombre"))
                            Fila = Fila + 1
                        Loop
                        lblTotal.Text = "Total de registros:" + ds.Tables(0).Rows.Count.ToString
                    End If
                End If
                Me.Text = "LISTADO DE CITAS - [ULTIMA CONSULTA: " + DateTime.Now.ToString() + "]"
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Try
            If e.ColumnIndex = 10 Then
                Dim frm As frm_ingreso_citas = New frm_ingreso_citas
                frm.cnn = _cnn
                frm.cit_codigo = Grilla.Rows(e.RowIndex).Cells(0).Value
                frm.eci_codigo = Grilla.Rows(e.RowIndex).Cells(8).Value
                frm.ShowDialog()
                Call CARGA_GRILLA()
            ElseIf e.ColumnIndex = 11 Then
                If Grilla.Rows(e.RowIndex).Cells(8).Value <> ESTADOS_CITAS.AGENDADA Then
                    MessageBox.Show("El registro seleccionado se encuentra en un estado no permitodo para ser eliminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Dim respuesta As Integer

                    respuesta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If respuesta = vbNo Then
                        Exit Sub
                    End If

                    Call ELIMINA_CITA(Grilla.Rows(e.RowIndex).Cells(4).Value, Grilla.Rows(e.RowIndex).Cells(0).Value)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ELIMINA_CITA(ByVal carCodigo As Integer, ByVal citCodigo As Integer)
        Dim classCita As class_citas = New class_citas
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim _msg As String = ""

        Try
            ds = Nothing
            classCita.cnn = _cnn
            classCita.car_codigo = carCodigo
            classCita.cit_codigo = citCodigo

            ds = classCita.ELIMINA_CITA(_msgError)
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
            Call CARGA_GRILLA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ButtonNueva_Click(sender As Object, e As EventArgs) Handles ButtonNueva.Click
        Dim frm As frm_ingreso_citas = New frm_ingreso_citas
        frm.cnn = _cnn
        frm.cit_codigo = 0
        frm.eci_codigo = 0
        frm.ShowDialog()
        Call CARGA_GRILLA()
    End Sub
End Class