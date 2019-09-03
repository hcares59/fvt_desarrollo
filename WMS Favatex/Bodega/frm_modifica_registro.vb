Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading
Public Class frm_modifica_registro
    Private _cnn As String
    Private _strUbicacionPK As String
    Private _strUbicacion As String
    Private _palletPK As String
    Private _palletABA As String

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property strUbicacion() As String
        Get
            Return _strUbicacion
        End Get
        Set(ByVal value As String)
            _strUbicacion = value
        End Set
    End Property
    Public Property strUbicacionPK() As String
        Get
            Return _strUbicacionPK
        End Get
        Set(ByVal value As String)
            _strUbicacionPK = value
        End Set
    End Property
    Public Property palletPK() As String
        Get
            Return _palletPK
        End Get
        Set(ByVal value As String)
            _palletPK = value
        End Set
    End Property
    Public Property palletABA() As String
        Get
            Return _palletABA
        End Get
        Set(ByVal value As String)
            _palletABA = value
        End Set
    End Property

    Private Sub frm_modifica_registro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call INICIALIZA()

        lblCodigoCant.Text = ""
        lblNombreCant.Text = ""
        lblBultoCantidad.Text = ""
        txtCantidad.Text = "0"

        chkPallet.Checked = True
        chkCantidad.Checked = False

        grpDistintoPallet.Enabled = True
        grpDistintaCantidad.Enabled = False

        cmbPalletCantidad.Text = _palletABA
        Call CARGA_DATOS_PALLET_CANTIDAD()

    End Sub

    Private Sub INICIALIZA()
        lblCodigo.Text = ""
        lblNombre.Text = ""
        lblBulto.Text = ""

        cmbPallet.DataSource = Nothing
        cmbPallet.Items.Clear()

        cmbPalletCantidad.DataSource = Nothing
        cmbPalletCantidad.Items.Clear()

    End Sub


    Private Sub cmbPallet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPallet.SelectedIndexChanged
        Dim seleccionOK As Boolean = True

        If Mid(cmbPallet.Text.ToUpper, 1, 2) = "PE" And _strUbicacion.Length > 5 Then
            seleccionOK = False
        ElseIf Mid(cmbPallet.Text.ToUpper, 1, 2) = "PD" And _strUbicacion.Length <= 5 Then
            seleccionOK = False
        End If

        If seleccionOK = False Then
            lblCodigo.Text = "-"
            lblNombre.Text = "-"
            lblBulto.Text = "-"
            cmbPallet.DataSource = Nothing
            cmbPallet.Items.Clear()

            MessageBox.Show("El pallet seleccionado no corresponde a las dimenciones de la ubicación de piking", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call CARGA_DATOS_PALLET()
    End Sub

    Private Sub CARGA_DATOS_PALLET()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classUbicacion.cnn = _cnn
            classUbicacion.pallet = cmbPallet.Text.ToUpper

            lblCodigo.Text = ""
            lblNombre.Text = ""
            lblBultoCantidad.Text = ""

            ds = classUbicacion.BUSCA_PALLET_DESCRIPCION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigo") <> "" Then
                        lblCodigo.Text = ds.Tables(0).Rows(Fila)("codigo")
                        lblNombre.Text = ds.Tables(0).Rows(Fila)("producto")
                        lblBulto.Text = ds.Tables(0).Rows(Fila)("descripcion")
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_PALLET", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_PALLET", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPallet_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPallet.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CARGA_COMBO_PALLET()
        End If
    End Sub

    Private Sub CARGA_COMBO_PALLET()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn
            classUbicacion.pallet = cmbPallet.Text.ToUpper
            _msg = ""
            ds = classUbicacion.BUSCA_PALLET_POR_TEXTO(_msg)
            If _msg = "" Then
                Me.cmbPallet.DataSource = ds.Tables(0)
                Me.cmbPallet.DisplayMember = "MENSAJE"
                Me.cmbPallet.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PALLET", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbPalletCantidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPalletCantidad.SelectedIndexChanged
        Dim seleccionOK As Boolean = True

        If Mid(cmbPalletCantidad.Text.ToUpper, 1, 2) = "PE" And _strUbicacion.Length > 5 Then
            seleccionOK = False
        ElseIf Mid(cmbPalletCantidad.Text.ToUpper, 1, 2) = "PD" And _strUbicacion.Length <= 5 Then
            seleccionOK = False
        End If

        If seleccionOK = False Then
            lblCodigoCant.Text = "-"
            lblNombreCant.Text = "-"
            lblBultoCantidad.Text = "-"
            cmbPalletCantidad.DataSource = Nothing
            cmbPalletCantidad.Items.Clear()

            MessageBox.Show("El pallet seleccionado no corresponde a las dimenciones de la ubicación de piking", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call CARGA_DATOS_PALLET_CANTIDAD()
    End Sub
    Private Sub CARGA_DATOS_PALLET_CANTIDAD()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classUbicacion.cnn = _cnn
            classUbicacion.pallet = cmbPalletCantidad.Text.ToUpper

            lblCodigoCant.Text = ""
            lblNombreCant.Text = ""
            lblBultoCantidad.Text = ""

            ds = classUbicacion.BUSCA_PALLET_DESCRIPCION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigo") <> "" Then
                        lblCodigoCant.Text = ds.Tables(0).Rows(Fila)("codigo")
                        lblNombreCant.Text = ds.Tables(0).Rows(Fila)("producto")
                        lblBultoCantidad.Text = ds.Tables(0).Rows(Fila)("descripcion")
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_PALLET_CANTIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_PALLET_CANTIDAD", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPalletCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPalletCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CARGA_COMBO_PALLET_CANTIDAD()
        End If
    End Sub

    Private Sub CARGA_COMBO_PALLET_CANTIDAD()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn
            classUbicacion.pallet = cmbPalletCantidad.Text.ToUpper
            _msg = ""
            ds = classUbicacion.BUSCA_PALLET_POR_TEXTO(_msg)
            If _msg = "" Then
                Me.cmbPalletCantidad.DataSource = ds.Tables(0)
                Me.cmbPalletCantidad.DisplayMember = "MENSAJE"
                Me.cmbPalletCantidad.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PALLET_CANTIDAD", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub chkPallet_CheckedChanged(sender As Object, e As EventArgs) Handles chkPallet.CheckedChanged
        If chkPallet.Checked = True Then
            chkCantidad.Checked = False
            grpDistintaCantidad.Enabled = False
            grpDistintoPallet.Enabled = True
        Else
            chkPallet.Checked = False
            grpDistintaCantidad.Enabled = True
            grpDistintoPallet.Enabled = False
        End If
        Call INICIALIZA()
    End Sub

    Private Sub chkCantidad_CheckedChanged(sender As Object, e As EventArgs) Handles chkCantidad.CheckedChanged
        If chkCantidad.Checked = True Then
            chkPallet.Checked = False
            grpDistintaCantidad.Enabled = True
            grpDistintoPallet.Enabled = False
        Else
            chkCantidad.Checked = False
            grpDistintaCantidad.Enabled = False
            grpDistintoPallet.Enabled = True

        End If
        Call INICIALIZA()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call GUARDAR()
    End Sub

    Private Sub GUARDAR()
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
            conexion.Open()

            If chkPallet.Checked = True Then
                _distintoPallet = True
                _distintaCantidad = False
                'If ENVIA_PALLET_A_PT(cmbPallet.Text, conexion) = False Then
                '    If conexion.State = ConnectionState.Open Then
                '        conexion.Close()
                '    End If
                '    Exit Sub
                'End If
                _nuevaCantidadActualizada = -1
                _palletPiso = cmbPallet.Text
                Me.Dispose()
            ElseIf chkCantidad.Checked = True Then
                _distintoPallet = False
                _distintaCantidad = True
                _nuevaCantidadActualizada = 0

                If txtCantidad.Text <> "" Then
                    _nuevaCantidadActualizada = CInt(txtCantidad.Text)
                Else
                    _nuevaCantidadActualizada = 0
                End If

                Me.Dispose()

            End If
        End Using
    End Sub

    Private Function ENVIA_PALLET_A_PT(ByVal strPallet As String, ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet

        ENVIA_PALLET_A_PT = False

        Try
            'Guarda cabecera del documento
            ds = Nothing
            classUbicaciones.pallet = strPallet
            classUbicaciones.ubi_codigo = GLO_UBI_PISO_PRODUCTO_TERMINADO

            ds = classUbicaciones.ACTUALIZA_UBICACIONES_A_PISO_PT(_msgError, conexion)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Exit Function
                End If
            End If

            ENVIA_PALLET_A_PT = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

End Class