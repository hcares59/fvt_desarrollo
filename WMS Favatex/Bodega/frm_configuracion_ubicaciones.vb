Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_configuracion_ubicaciones
    Private _cnn As String
    Dim paso As String
    Dim cargaPrimeraVez As Boolean
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub frm_configuracion_ubicaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call CARGA_COMBO_RACK()
        Call CARGA_GRILLA_ALTURA()
        'Call CARGA_GRILLA_UBICACIONES()
    End Sub

    Private Sub CARGA_COMBO_RACK()
        Dim _msg As String
        Try
            Dim classRack As class_rack = New class_rack
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classRack.cnn = _cnn
            _msg = ""
            ds = classRack.COMBO_CARGA_RACK(_msg)
            If _msg = "" Then
                Me.cmbRack.DataSource = ds.Tables(0)
                Me.cmbRack.DisplayMember = "mensaje"
                Me.cmbRack.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_RACK", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classPosiciones As class_posiciones = New class_posiciones

        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classPosiciones.cnn = _cnn
            classPosiciones.rac_codigo = cmbRack.SelectedValue
            _msg = ""

            grillaPosicion.Rows.Clear()
            ds = classPosiciones.CARGA_DATOS_POSICION(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pos_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaPosicion.Rows.Add(ds.Tables(0).Rows(Fila)("pos_codigo"), False,
                                            ds.Tables(0).Rows(Fila)("pos_nombre"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "carga_grila", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    'Private Sub CARGA_GRILLA_UBICACIONES()
    '    Dim classUbicaciones As class_ubicaciones = New class_ubicaciones

    '    Dim Fila As Integer = 0

    '    Try
    '        Dim ds As DataSet = New DataSet
    '        Dim _msg As String
    '        ds = Nothing
    '        classUbicaciones.cnn = _cnn
    '        classUbicaciones.rac_codigo = cmbRack.SelectedValue
    '        classUbicaciones.ubi_codigo = 0
    '        _msg = ""

    '        Grilla.Rows.Clear()
    '        ds = classUbicaciones.CARGA_DATOS_UBICACIONES(_msg)
    '        If _msg = "" Then
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                If ds.Tables(0).Rows(Fila)("ubi_codigo") > 0 Then
    '                    Do While Fila < ds.Tables(0).Rows.Count
    '                        Grilla.Rows.Add(ds.Tables(0).Rows(Fila)("ubi_codigo"), False,
    '                                        ds.Tables(0).Rows(Fila)("ubi_nombre"),
    '                                        ds.Tables(0).Rows(Fila)("ubi_alto"),
    '                                        ds.Tables(0).Rows(Fila)("ubi_largo"),
    '                                        ds.Tables(0).Rows(Fila)("ubi_fondo"),
    '                                        ds.Tables(0).Rows(Fila)("sca_nombre"),
    '                                        ds.Tables(0).Rows(Fila)("car_nombre"))
    '                        Fila = Fila + 1
    '                    Loop

    '                End If
    '            End If
    '        Else
    '            MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message + " " + "carga_grila", MsgBoxStyle.Critical, Me.Text)
    '    End Try
    'End Sub


    Private Sub CARGA_GRILLA_ALTURA()
        Dim classAltura As class_alturas = New class_alturas

        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classAltura.cnn = _cnn
            _msg = ""

            grillaAltura.Rows.Clear()
            ds = classAltura.CARGA_DATOS_ALTURA(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("alt_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            grillaAltura.Rows.Add(ds.Tables(0).Rows(Fila)("alt_codigo"), False,
                                            ds.Tables(0).Rows(Fila)("alt_nombre"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA_ALTURA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA_ALTURA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbRack_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRack.SelectedIndexChanged

    End Sub

    Private Sub cmbRack_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbRack.SelectionChangeCommitted
        Call CARGA_GRILLA()
        'Call CARGA_GRILLA_UBICACIONES()
    End Sub

    Private Sub btnPosMarcar_Click(sender As Object, e As EventArgs) Handles btnPosMarcar.Click
        If grillaPosicion.Rows.Count = 0 Then
            Exit Sub
        End If

        If btnPosMarcar.Text = "SELECCIONAR TODO" Then
            Call MARCAR_TODOS_POSICION()
            btnPosMarcar.Text = "DESMARCAR TODOS"
        Else
            Call DESMARCAR_TODOS_POSICION()
            btnPosMarcar.Text = "SELECCIONAR TODO"
        End If
    End Sub

    Private Sub MARCAR_TODOS_POSICION()
        For Each row As DataGridViewRow In Me.grillaPosicion.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS_POSICION()
        For Each row As DataGridViewRow In Me.grillaPosicion.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub btnAltMarcar_Click(sender As Object, e As EventArgs) Handles btnAltMarcar.Click
        If grillaAltura.Rows.Count = 0 Then
            Exit Sub
        End If

        If btnAltMarcar.Text = "SELECCIONAR TODO" Then
            Call MARCAR_TODOS_ALTURA()
            btnAltMarcar.Text = "DESMARCAR TODOS"
        Else
            Call DESMARCAR_TODOS_ALTURA()
            btnAltMarcar.Text = "SELECCIONAR TODO"
        End If
    End Sub

    Private Sub MARCAR_TODOS_ALTURA()
        For Each row As DataGridViewRow In Me.grillaAltura.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS_ALTURA()
        For Each row As DataGridViewRow In Me.grillaAltura.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Cursor = Cursors.WaitCursor
        If cmbRack.Text = "" Then
            MessageBox.Show("Debe seleccionar un rack para generar las ubicaciones", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbRack.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If POSICIONES_MARCADAS() = 0 Then
            MessageBox.Show("Debe marcar a lo menos una posición", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            grillaPosicion.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If POSICIONES_MARCADAS_ALTURA() = 0 Then
            MessageBox.Show("Debe marcar a lo menos una altura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            grillaAltura.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        'If GENERA_UBICACIONES() = False Then
        '    MessageBox.Show("No se han generado las ubicaciones debido a un error, " _
        '                    + Chr(10) + "pongase en contacto con el area de desarrollo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Function POSICIONES_MARCADAS() As Integer
        Try
            POSICIONES_MARCADAS = 0
            For Each row As DataGridViewRow In Me.grillaPosicion.Rows
                If row.Cells(1).Value = True Then
                    POSICIONES_MARCADAS = POSICIONES_MARCADAS + 1
                End If
            Next
        Catch ex As Exception
            POSICIONES_MARCADAS = 0
            MessageBox.Show(ex.Message, Me.Text)
        End Try
    End Function

    Private Function POSICIONES_MARCADAS_ALTURA() As Integer
        Try
            POSICIONES_MARCADAS_ALTURA = 0
            For Each row As DataGridViewRow In Me.grillaAltura.Rows
                If row.Cells(1).Value = True Then
                    POSICIONES_MARCADAS_ALTURA = POSICIONES_MARCADAS_ALTURA + 1
                End If
            Next
        Catch ex As Exception
            POSICIONES_MARCADAS_ALTURA = 0
            MessageBox.Show(ex.Message, Me.Text)
        End Try
    End Function

    'Private Function GENERA_UBICACIONES() As Boolean
    '    Dim classUbicacion As class_ubicaciones = New class_ubicaciones
    '    Dim ds As DataSet = New DataSet
    '    Dim _msgError As String = ""
    '    Dim conexion As New SqlConnection(_cnn)
    '    Dim scopeOptions = New TransactionOptions()
    '    Dim fila As Integer = 0
    '    Dim _msg As String = ""
    '    Dim respuesta As Integer = 0

    '    GENERA_UBICACIONES = False

    '    Try
    '        Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
    '            conexion.Open()
    '            For Each rowPos As DataGridViewRow In Me.grillaPosicion.Rows
    '                If rowPos.Cells(1).Value = True Then
    '                    For Each rowAlt As DataGridViewRow In Me.grillaAltura.Rows
    '                        If rowAlt.Cells(1).Value = True Then
    '                            classUbicacion.pos_codigo = rowPos.Cells(0).Value
    '                            classUbicacion.alt_codigo = rowAlt.Cells(0).Value

    '                            ds = classUbicacion.GENERA_UBICACIONES(_msgError, conexion)
    '                            If _msgError <> "" Then
    '                                If conexion.State = ConnectionState.Open Then
    '                                    conexion.Close()
    '                                End If
    '                                ds = Nothing
    '                                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                Exit Function
    '                            Else
    '                                If ds.Tables(0).Rows(0)("codigo") < 0 Then
    '                                    If conexion.State = ConnectionState.Open Then
    '                                        conexion.Close()
    '                                    End If
    '                                    ds = Nothing
    '                                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                    Exit Function
    '                                End If
    '                            End If
    '                        End If
    '                    Next
    '                End If
    '            Next

    '            Transaccion.Complete()
    '            Transaccion.Dispose()
    '            If conexion.State = ConnectionState.Open Then
    '                conexion.Close()
    '            End If
    '            ds = Nothing

    '            MessageBox.Show("Las ubicaciones fueron generadas en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
    '            Call CARGA_GRILLA_UBICACIONES()
    '            GENERA_UBICACIONES = True
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call MARCAR_TODOS_UBICACION()
    End Sub

    Private Sub grillaPosicion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaPosicion.CellContentClick
        If e.ColumnIndex = Me.grillaPosicion.Columns.Item(1).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.grillaPosicion.Rows(e.RowIndex).Cells(1)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub grillaAltura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaAltura.CellContentClick
        If e.ColumnIndex = Me.grillaAltura.Columns.Item(1).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.grillaAltura.Rows(e.RowIndex).Cells(1)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellContentClick
        Dim _ubi_codigos As String = ""
        If e.ColumnIndex = Me.Grilla.Columns.Item(1).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.Grilla.Rows(e.RowIndex).Cells(1)
            chkCell.Value = Not chkCell.Value
        End If

        Try
            If e.ColumnIndex = 8 Then
                Dim frm As frm_ubicaciones_edicion = New frm_ubicaciones_edicion
                _ubi_codigos = Grilla.Rows(e.RowIndex).Cells(0).Value.ToString + ","
                frm.cnn = _cnn
                frm.es_edicion = True
                frm.ubi_codigos = _ubi_codigos
                frm.ShowDialog()
                Call CARGA_GRILLA()
                'ElseIf e.ColumnIndex = 5 Then

                '    If vbYes = MessageBox.Show("¿Esta seguro(a) de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                '        Call ELIMINA_REGISTRO(Grilla.Rows(e.RowIndex).Cells(0).Value)
                '    End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call DESMARCAR_TODOS_UBICACION()
    End Sub

    Private Sub MARCAR_TODOS_UBICACION()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub DESMARCAR_TODOS_UBICACION()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub BtnPosicion_Click(sender As Object, e As EventArgs) Handles BtnPosicion.Click
        Dim respuesta As Integer
        Me.Cursor = Cursors.WaitCursor

        If UBICACIONES_MARCADAS() = 0 Then
            MessageBox.Show("Debe marcar a lo menos una ubicación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Grilla.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        respuesta = MessageBox.Show("¿Esta seguro(a) de eliminar las ubicaciones seleccionadas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = vbNo Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        'If ELIMINA_UBICACIONES() = False Then
        '    MessageBox.Show("No se han eliminado las ubicaciones debido a un error, " _
        '                    + Chr(10) + "pongase en contacto con el area de desarrollo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Function UBICACIONES_MARCADAS() As Integer
        Try
            UBICACIONES_MARCADAS = 0
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(1).Value = True Then
                    UBICACIONES_MARCADAS = UBICACIONES_MARCADAS + 1
                End If
            Next
        Catch ex As Exception
            UBICACIONES_MARCADAS = 0
            MessageBox.Show(ex.Message, Me.Text)
        End Try
    End Function

    'Private Function ELIMINA_UBICACIONES() As Boolean
    '    Dim classUbicacion As class_ubicaciones = New class_ubicaciones
    '    Dim ds As DataSet = New DataSet
    '    Dim _msgError As String = ""
    '    Dim conexion As New SqlConnection(_cnn)
    '    Dim scopeOptions = New TransactionOptions()
    '    Dim fila As Integer = 0
    '    Dim _msg As String = ""
    '    Dim respuesta As Integer = 0

    '    ELIMINA_UBICACIONES = False

    '    Try
    '        Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
    '            conexion.Open()
    '            For Each row As DataGridViewRow In Me.Grilla.Rows
    '                If row.Cells(1).Value = True Then

    '                    classUbicacion.ubi_codigo = row.Cells(0).Value

    '                    ds = classUbicacion.ELIMINA_UBICACIONES(_msgError, conexion)
    '                    If _msgError <> "" Then
    '                        If conexion.State = ConnectionState.Open Then
    '                            conexion.Close()
    '                        End If
    '                        ds = Nothing
    '                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        Exit Function
    '                    Else
    '                        If ds.Tables(0).Rows(0)("codigo") < 0 Then
    '                            If conexion.State = ConnectionState.Open Then
    '                                conexion.Close()
    '                            End If
    '                            ds = Nothing
    '                            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            Exit Function
    '                        End If
    '                    End If
    '                End If
    '            Next

    '            Transaccion.Complete()
    '            Transaccion.Dispose()
    '            If conexion.State = ConnectionState.Open Then
    '                conexion.Close()
    '            End If
    '            ds = Nothing
    '            ELIMINA_UBICACIONES = True
    '            MessageBox.Show("Las ubicaciones fueron generadas en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
    '            'Call CARGA_GRILLA_UBICACIONES()

    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim _ubi_codigos As String = ""

        Try
            For Each row As DataGridViewRow In Me.Grilla.Rows
                If row.Cells(1).Value = True Then
                    If _ubi_codigos = "" Then
                        _ubi_codigos = row.Cells(0).Value.ToString + ","
                    Else
                        _ubi_codigos = _ubi_codigos + " " + row.Cells(0).Value.ToString + ","
                    End If
                End If
            Next

            Dim frm As frm_ubicaciones_edicion = New frm_ubicaciones_edicion
            frm.cnn = _cnn
            frm.es_edicion = False
            frm.ubi_codigos = _ubi_codigos
            frm.ShowDialog()
            Call CARGA_GRILLA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class