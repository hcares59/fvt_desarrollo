Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_fill_rate
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call FILTRA_INFORME()
    End Sub

    Private Sub FILTRA_INFORME()
        Dim _codigoCliente As String = ""
        Dim _fecha_desde As String = ""
        Dim _fecha_hasta As String = ""
        Dim mesIngresoDesde As String = ""
        Dim diaIngresoDesde As String = ""
        Dim mesIngresoHasta As String = ""
        Dim diaIngresoHasta As String = ""



        Try

            'Fecha desde
            If CStr(dtpDesde.Value.Month).Length = 1 Then
                mesIngresoDesde = Trim("0" + CStr(dtpDesde.Value.Month))
            Else
                mesIngresoDesde = CStr(dtpDesde.Value.Month)
            End If

            If CStr(dtpDesde.Value.Day).Length = 1 Then
                diaIngresoDesde = Trim("0" + CStr(dtpDesde.Value.Day))
            Else
                diaIngresoDesde = CStr(dtpDesde.Value.Day)
            End If

            _fecha_desde = CStr(dtpDesde.Value.Year) + mesIngresoDesde + diaIngresoDesde

            'Fecha hasta
            If CStr(dtpHasta.Value.Month).Length = 1 Then
                mesIngresoHasta = Trim("0" + CStr(dtpHasta.Value.Month))
            Else
                mesIngresoHasta = CStr(dtpHasta.Value.Month)
            End If

            If CStr(dtpHasta.Value.Day).Length = 1 Then
                diaIngresoHasta = Trim("0" + CStr(dtpHasta.Value.Day))
            Else
                diaIngresoHasta = CStr(dtpHasta.Value.Day)
            End If

            _fecha_hasta = CStr(dtpHasta.Value.Year) + mesIngresoHasta + diaIngresoHasta

            Call VER_INFORME(_fecha_desde, _fecha_hasta)


        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VER_INFORME(ByVal _fecha_desde As String, ByVal _fecha_hasta As String)
        Dim classTipoInforme As class_tipo_informe_kpi = New class_tipo_informe_kpi
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Me.Cursor = Cursors.WaitCursor

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                classTipoInforme.fecha_desde = _fecha_desde
                classTipoInforme.fecha_hasta = _fecha_hasta

                ds = Nothing
                ds = classTipoInforme.CARGA_DATOS_PARA_FILL_RATE_RESUMEN(_msgError, conexion)
                If ds.Tables(0).Rows.Count > 0 Then
                    If _msgError = "" Then
                        If ds.Tables(0).Rows(0)("codigo") = 0 Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show("Error al ejecutar el procedimiento del resumen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                        End If
                    Else
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                    End If
                End If

                ds = Nothing
                ds = classTipoInforme.CARGA_DATOS_PARA_FILL_RATE_DETALLE(_msgError, conexion)
                If ds.Tables(0).Rows.Count > 0 Then
                    If _msgError = "" Then
                        If ds.Tables(0).Rows(0)("codigo") = 0 Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show("Error al ejecutar el procedimiento del detalle", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                        End If
                    Else
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                    End If
                End If

                ds = Nothing
                ds = classTipoInforme.CARGA_DATOS_PARA_FILL_RATE_DETALLE_PICKING(_msgError, conexion)
                If ds.Tables(0).Rows.Count > 0 Then
                    If _msgError = "" Then
                        If ds.Tables(0).Rows(0)("codigo") = 0 Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show("Error al ejecutar el procedimiento del detalle", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                        End If
                    Else
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

            End Using

            System.Diagnostics.Process.Start(strRutaIngformesExcel + "FILL RATE CLIENTES.xlsm")
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class