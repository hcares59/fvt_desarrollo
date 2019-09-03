Public Class estructura_dev_productos
    Public Property pic_codigo As Integer
    Public Property car_codigo As Integer
    Public Property pro_codigo As Integer
    Public Property pro_codigointerno As String
    Public Property pro_nombre As String
    Public Property sku_cartera As String
    Public Property sku_cartera_nombre As String
    Public Property pic_cantidad_encontrada As Integer
    Public Property pic_fila As Integer
    Public Property pic_ocnumeroas As Long
    Public Property fac_numeroas As Long
    Public Property gd_numero As Long
    Public Property cant_original As Integer
    Public Property num_bul_unidad As Integer
    Public Property total_bulto As Integer
    Public Property pro_codigooriginal As Integer
    Public Property pro_codigo_unico As String
    Public Property pdd_fila As Integer
    Public Property emb_sello As String


    Public Sub New(ByVal _pic_codigo As Integer, ByVal _car_codigo As Integer, ByVal _pro_codigo As Integer, ByVal _pro_codigointerno As String,
    ByVal _pro_nombre As String, ByVal _sku_cartera As String, ByVal _sku_cartera_nombre As String, ByVal _pic_cantidad_encontrada As Integer,
    ByVal _pic_fila As Integer, ByVal _pic_ocnumeroas As Long, ByVal _fac_numeroas As Long, ByVal _gd_numero As Long, ByVal _cant_original As Integer,
    ByVal _num_bul_unidad As Integer, ByVal _total_bulto As Integer, ByVal _pro_codigooriginal As Integer, ByVal _pro_codigo_unico As String, ByVal _pdd_fila As Integer, ByVal _emb_sello As String)
        Me.pic_codigo = _pic_codigo
        Me.car_codigo = _car_codigo
        Me.pro_codigo = _pro_codigo
        Me.pro_codigointerno = _pro_codigointerno
        Me.pro_nombre = _pro_nombre
        Me.sku_cartera = _sku_cartera
        Me.sku_cartera_nombre = _sku_cartera_nombre
        Me.pic_cantidad_encontrada = _pic_cantidad_encontrada
        Me.pic_fila = _pic_fila
        Me.pic_ocnumeroas = _pic_ocnumeroas
        Me.fac_numeroas = _fac_numeroas
        Me.gd_numero = _gd_numero
        Me.cant_original = _cant_original
        Me.num_bul_unidad = _num_bul_unidad
        Me.total_bulto = _total_bulto
        Me.pro_codigooriginal = _pro_codigooriginal
        Me.pro_codigo_unico = _pro_codigo_unico
        Me.pdd_fila = _pdd_fila
        Me.emb_sello = _emb_sello
    End Sub

End Class
