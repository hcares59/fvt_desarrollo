Public Class estructura_pallet
    Public Property pallet_serie As String
    Public Property pro_codigo As Integer
    Public Property numBulto As Integer
    Public Property cantConsumo As Integer

    Public Sub New(ByVal _pallet_serie As String, ByVal _pro_codigo As Integer, ByVal _numBulto As Integer, ByVal _cantConsumo As Integer)
        Me.pallet_serie = _pallet_serie
        Me.pro_codigo = _pro_codigo
        Me.numBulto = _numBulto
        Me.cantConsumo = _cantConsumo
    End Sub



End Class
