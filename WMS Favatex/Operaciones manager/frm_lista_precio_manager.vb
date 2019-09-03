Imports System.IO
Imports System.Xml
Public Class frm_lista_precio_manager
    Dim _rutEmpresa As String
    Private _tokenEmpresa As String
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frm_lista_precio_manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        _rutEmpresa = "76019160-4"
        _tokenEmpresa = "l_i313BcJYS51Gu8T1po93ZS66xvlT_9788VG46uTq7x7jLA82"
        Me.WindowState = FormWindowState.Maximized
        lblTotal.Text = ""
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim doc As New cl.manager.api.Productos
        Dim ds As DataSet = New DataSet
        Dim i As Integer

        Dim LPrecio() = doc.consultaListaPrec(_rutEmpresa, _tokenEmpresa)

        For Each lista In LPrecio
            MessageBox.Show(lista.nombreListaPrecio)
            For Each dato In lista.ListaProd
                MessageBox.Show(dato.idProducto)
                MessageBox.Show(dato.precioLista)
            Next
        Next
    End Sub
End Class