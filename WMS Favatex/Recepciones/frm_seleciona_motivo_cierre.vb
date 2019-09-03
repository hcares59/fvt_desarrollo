Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_seleciona_motivo_cierre
    Private _cnn As String
    Private _ocp_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property ocp_codigo() As String
        Get
            Return _ocp_codigo
        End Get
        Set(ByVal value As String)
            _ocp_codigo = value
        End Set
    End Property


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub frm_seleciona_motivo_cierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CARGA_COMBO_MOTIVO_CIERRE()
    End Sub

    Private Sub CARGA_COMBO_MOTIVO_CIERRE()
        Dim _msg As String
        Try
            Dim classMotivo As class_motivo_cierre = New class_motivo_cierre
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classMotivo.cnn = _cnn
            _msg = ""
            ds = classMotivo.CARGA_COMBO_MOTIVO_CIERRE(_msg)
            If _msg = "" Then
                Me.cmbMotivoCierre.DataSource = ds.Tables(0)
                Me.cmbMotivoCierre.DisplayMember = "MENSAJE"
                Me.cmbMotivoCierre.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_MOTIVO_CIERRE", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CERRADO_MANUAL()
        Dim classOC As class_rec_orden_compra = New class_rec_orden_compra
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Try
            ds = Nothing
            classOC.cnn = _cnn
            classOC.ocp_codigo = _ocp_codigo
            classOC.eoc_codigo = ESTADO_ORDEN_COMPRA_PROVEEDOR.CIERRE_MANUAL
            classOC.mci_codigo = cmbMotivoCierre.SelectedValue

            ds = classOC.REC_ORDEN_COMPRA_CAMBIA_ESTADO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            MessageBox.Show("Orden cerrada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If cmbMotivoCierre.Text = "" Then
            MessageBox.Show("Debe seleccionar un motivo de cierre", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call CERRADO_MANUAL()
        Me.Dispose()
    End Sub
End Class