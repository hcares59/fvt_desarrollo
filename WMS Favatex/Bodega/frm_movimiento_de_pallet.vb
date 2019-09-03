Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading
Public Class frm_movimiento_de_pallet
    Private _cnn As String
    Private _bod_codigo As Integer
    Private _ubi_codigo As Integer
    Private _ubicacion_actual As String
    Private _ubicacion2 As Integer
    Private _procedencia As String
    Private _palletRequerido As String

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property bod_codigo() As Integer
        Get
            Return _bod_codigo
        End Get
        Set(ByVal value As Integer)
            _bod_codigo = value
        End Set
    End Property
    Public Property ubi_codigo() As Integer
        Get
            Return _ubi_codigo
        End Get
        Set(ByVal value As Integer)
            _ubi_codigo = value
        End Set
    End Property
    Public Property ubicacion_actual() As String
        Get
            Return _ubicacion_actual
        End Get
        Set(ByVal value As String)
            _ubicacion_actual = value
        End Set
    End Property
    Public Property procedencia() As String
        Get
            Return _procedencia
        End Get
        Set(ByVal value As String)
            _procedencia = value
        End Set
    End Property
    Public Property palletRequerido() As String
        Get
            Return _palletRequerido
        End Get
        Set(ByVal value As String)
            _palletRequerido = value
        End Set
    End Property

    Private Sub frm_movimiento_de_pallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CARGA_COMBO_BODEGAS()

        If _procedencia = "PIK" Then
            chkUbicacionVacia.Visible = True
            chkMantener.Visible = False
        Else
            chkUbicacionVacia.Visible = False
            chkMantener.Visible = True
        End If

        lblCodigo.Text = ""
        lblNombre.Text = ""
        lblBultoCantidad.Text = ""

        lblCodigo2.Text = ""
        lblNombre2.Text = ""
        lblBultoCantidad2.Text = ""

        lblUbicacionActual.Text = _ubicacion_actual
        cmbPallet2.Enabled = False
        If _ubicacion_actual.Length > 5 Then
            _ubicacion2 = CInt(Mid(_ubicacion_actual, 7, 5))
            cmbPallet2.Enabled = True
        End If

        If _bod_codigo > 0 Then
            cbmBodegas.SelectedValue = _bod_codigo
            Call CARGA_COMBO_UBICACIONES()
            If _ubi_codigo > 0 Then
                cmbUbicacion.SelectedValue = _ubi_codigo
            End If
        End If
    End Sub

    Private Sub CARGA_COMBO_BODEGAS()
        Dim _msg As String
        Try
            Dim class_bodegas_tipo_ubicacion As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet
            ds = Nothing
            cbmBodegas.DisplayMember = ""
            cbmBodegas.ValueMember = "0"
            class_bodegas_tipo_ubicacion.cnn = _cnn
            _msg = ""
            ds = class_bodegas_tipo_ubicacion.BODEGA_CARGA_COMBO(_msg)
            If _msg = "" Then
                cbmBodegas.DataSource = ds.Tables(0)
                cbmBodegas.DisplayMember = "mensaje"
                cbmBodegas.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga bodegas", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_UBICACIONES()
        Dim _msg As String
        Try
            Dim class_ubicaciones As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet
            ds = Nothing
            cmbUbicacion.DisplayMember = ""
            cmbUbicacion.ValueMember = "0"
            class_ubicaciones.cnn = _cnn
            class_ubicaciones.bod_codigo = cbmBodegas.SelectedValue
            _msg = ""
            ds = class_ubicaciones.CARGA_COMBO_UBICACIONES(_msg)
            If _msg = "" Then
                cmbUbicacion.DataSource = ds.Tables(0)
                cmbUbicacion.DisplayMember = "mensaje"
                cmbUbicacion.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga bodegas", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbPallet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPallet.SelectedIndexChanged
        Call CARGA_DATOS_PALLET()
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

    Private Sub CARGA_COMBO_PALLET2()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn
            classUbicacion.pallet = cmbPallet.Text.ToUpper
            classUbicacion.pallet2 = cmbPallet.Text.ToUpper
            _msg = ""
            ds = classUbicacion.BUSCA_PALLET_POR_TEXTO(_msg)
            If _msg = "" Then
                Me.cmbPallet2.DataSource = ds.Tables(0)
                Me.cmbPallet2.DisplayMember = "MENSAJE"
                Me.cmbPallet2.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PALLET", MsgBoxStyle.Critical, Me.Text)
        End Try
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
                        lblBultoCantidad.Text = ds.Tables(0).Rows(Fila)("descripcion")
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

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If chkMantener.Checked = True Then
            GLO_ACCION_EJECUTADA = True
            Me.Dispose()
        Else
            If cmbPallet.Text = "" Then
                MessageBox.Show("Debe seleccionar un pallet", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbPallet.Focus()
                Exit Sub
            End If

            If _procedencia = "ABA" Then
                If ACTUALIZA_NUEVA_UBICACION() = True Then
                    MessageBox.Show("La ubicación fue liberada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GLO_ACCION_EJECUTADA = True
                    Me.Dispose()
                Else
                    GLO_ACCION_EJECUTADA = False
                End If
            ElseIf _procedencia = "PIK" Then
                If DISPONIBILIZA_UBICACION_DESDE_PICKEO() = True Then
                    MessageBox.Show("La ubicación fue disponibilizada en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GLO_ACCION_EJECUTADA = True
                    Me.Dispose()
                Else
                    GLO_ACCION_EJECUTADA = False
                End If
            End If

        End If
    End Sub

    Private Function DISPONIBILIZA_UBICACION_DESDE_PICKEO() As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet

        DISPONIBILIZA_UBICACION_DESDE_PICKEO = False

        Try
            'Guarda cabecera del documento
            ds = Nothing
            classUbicaciones.cnn = _cnn
            classUbicaciones.palletRequerido = _palletRequerido
            classUbicaciones.palletEncontrado = cmbPallet.Text
            classUbicaciones.ubi_codigoactual = _ubi_codigo
            classUbicaciones.ubi_codigopisopt = GLO_UBI_PISO_PRODUCTO_TERMINADO
            classUbicaciones.ubi_codigoextraviado = GLO_UBI_PISO_PRODUCTOS_EXTRAVIADOS
            classUbicaciones.ubicacion_vacia = chkUbicacionVacia.Checked

            ds = classUbicaciones.LIBERA_UBICACION_PROCESO_PICKEO(_msgError)
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

            If (cmbPallet2.Enabled = True And cmbPallet2.Text <> "") Then
                'Actualiza posicion del segundo pallet
                ds = Nothing
                classUbicaciones.cnn = _cnn
                classUbicaciones.cnn = _cnn
                classUbicaciones.palletRequerido = _palletRequerido
                classUbicaciones.palletEncontrado = cmbPallet2.Text
                classUbicaciones.ubi_codigoactual = _ubicacion2
                classUbicaciones.ubi_codigopisopt = GLO_UBI_PISO_PRODUCTO_TERMINADO
                classUbicaciones.ubi_codigoextraviado = GLO_UBI_PISO_PRODUCTOS_EXTRAVIADOS
                classUbicaciones.ubicacion_vacia = chkUbicacionVacia.Checked

                ds = classUbicaciones.LIBERA_UBICACION_PROCESO_PICKEO(_msgError)
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
            End If

            DISPONIBILIZA_UBICACION_DESDE_PICKEO = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function ACTUALIZA_NUEVA_UBICACION() As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet

        ACTUALIZA_NUEVA_UBICACION = False

        Try
            'Guarda cabecera del documento
            ds = Nothing
            classUbicaciones.cnn = _cnn
            classUbicaciones.pallet = cmbPallet.Text
            classUbicaciones.ubi_codigo = cmbUbicacion.SelectedValue

            ds = classUbicaciones.ACTUALIZA_UBICACIONES(_msgError)
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

            'Actualiza posicion del segundo pallet
            ds = Nothing
            classUbicaciones.cnn = _cnn
            classUbicaciones.pallet = cmbPallet2.Text
            classUbicaciones.ubi_codigo = cmbUbicacion.SelectedValue

            If (cmbPallet2.Enabled = True And cmbPallet2.Text <> "") Then
                ds = classUbicaciones.ACTUALIZA_UBICACIONES(_msgError)
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
            End If

            ACTUALIZA_NUEVA_UBICACION = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        GLO_ACCION_EJECUTADA = False
        Me.Dispose()
    End Sub

    Private Sub chkMantener_CheckedChanged(sender As Object, e As EventArgs) Handles chkMantener.CheckedChanged
        If chkMantener.Checked = True Then
            cmbPallet.Items.Clear()
            cmbPallet.Enabled = False
        ElseIf chkMantener.Checked = False Then
            cmbPallet.Enabled = True
        End If
    End Sub

    Private Sub cmbPallet2_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPallet2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cmbPallet.Text <> "" Then
                Call CARGA_COMBO_PALLET()
            Else
                MessageBox.Show("Debe seleccionar un primer pallet", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbPallet.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmbPallet2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPallet2.SelectedIndexChanged
        Call CARGA_DATOS_PALLET2()
    End Sub

    Private Sub CARGA_DATOS_PALLET2()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classUbicacion.cnn = _cnn
            classUbicacion.pallet = cmbPallet2.Text.ToUpper

            lblCodigo2.Text = ""
            lblNombre2.Text = ""
            lblBultoCantidad2.Text = ""

            ds = classUbicacion.BUSCA_PALLET_DESCRIPCION(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("codigo") <> "" Then
                        lblCodigo2.Text = ds.Tables(0).Rows(Fila)("codigo")
                        lblNombre2.Text = ds.Tables(0).Rows(Fila)("producto")
                        lblBultoCantidad2.Text = ds.Tables(0).Rows(Fila)("descripcion")
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_PALLET2", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_PALLET2", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPallet2_Layout(sender As Object, e As LayoutEventArgs) Handles cmbPallet2.Layout

    End Sub

    Private Sub chkUbicacionVacia_CheckedChanged(sender As Object, e As EventArgs) Handles chkUbicacionVacia.CheckedChanged
        If chkUbicacionVacia.Checked = True Then
            lblCodigo.Text = ""
            lblNombre.Text = ""
            lblBultoCantidad.Text = ""

            lblCodigo2.Text = ""
            lblNombre2.Text = ""
            lblBultoCantidad2.Text = ""

            If cmbPallet.Text <> "" Then
                cmbPallet.SelectedValue = 0
            End If

            If cmbPallet2.Text <> "" Then
                cmbPallet2.SelectedValue = 0
            End If
            cmbPallet.Enabled = False
            cmbPallet2.Enabled = False

        ElseIf chkUbicacionVacia.Checked = False Then
            cmbPallet.Enabled = True
            cmbPallet2.Enabled = True
        End If
    End Sub
End Class