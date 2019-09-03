Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_imprimir
    Private CRReport As ReportDocument
    Private SRReport As Subreports
    Private _Origen As String
    Private _pic_codigo As String
    Private _dev_codigo As String
    Private _strCadena As String
    Private _strFecha As String
    Private _strHoraIni As String
    Private _strHoraFin As String
    Private _emb_sello As String
    Private _nombreReporte As String
    Private _idImpresion As Integer
    Private _car_codigo As Integer
    Private _epc_codigo As Integer
    Private _nomCliente As String
    Private _nomEstado As String
    Private _rec_codigo As Long
    Private _facNumero As Long
    Private _sinFecha As Boolean
    Private _rec_numero As Integer
    Private _bod_codigo As Integer
    Private _pro_codigo As Integer
    Private _bod_nombre As String
    Private _pro_nombre As String
    Private _ocp_codigo As Integer
    Private _strFechaHasta As String
    Private _strFechaDesde As String
    Private _val_numero As Long
    Private _asi_codigo As Long
    Private _serie_paller As String
    Private _numBulto As Integer = 0
    Private _oab_codigo As Long

    Public Property oab_codigo() As Integer
        Get
            Return _oab_codigo
        End Get
        Set(ByVal value As Integer)
            _oab_codigo = value
        End Set
    End Property

    Public Property numBulto() As Integer
        Get
            Return _numBulto
        End Get
        Set(ByVal value As Integer)
            _numBulto = value
        End Set
    End Property
    Public Property serie_paller() As String
        Get
            Return _serie_paller
        End Get
        Set(ByVal value As String)
            _serie_paller = value
        End Set
    End Property
    Public Property asi_codigo() As Long
        Get
            Return _asi_codigo
        End Get
        Set(ByVal value As Long)
            _asi_codigo = value
        End Set
    End Property
    Public Property val_numero() As Long
        Get
            Return _val_numero
        End Get
        Set(ByVal value As Long)
            _val_numero = value
        End Set
    End Property

    Public Property strFechaDesde() As String
        Get
            Return _strFechaDesde
        End Get
        Set(ByVal value As String)
            _strFechaDesde = value
        End Set
    End Property

    Public Property strFechaHasta() As String
        Get
            Return _strFechaHasta
        End Get
        Set(ByVal value As String)
            _strFechaHasta = value
        End Set
    End Property

    Public Property ocp_codigo() As Integer
        Get
            Return _ocp_codigo
        End Get
        Set(ByVal value As Integer)
            _ocp_codigo = value
        End Set
    End Property
    Public Property pro_nombre() As String
        Get
            Return _pro_nombre
        End Get
        Set(ByVal value As String)
            _pro_nombre = value
        End Set
    End Property
    Public Property bod_nombre() As String
        Get
            Return _bod_nombre
        End Get
        Set(ByVal value As String)
            _bod_nombre = value
        End Set
    End Property
    Public Property pro_codigo() As Integer
        Get
            Return _pro_codigo
        End Get
        Set(ByVal value As Integer)
            _pro_codigo = value
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

    Public Property rec_numero() As Integer
        Get
            Return _rec_numero
        End Get
        Set(ByVal value As Integer)
            _rec_numero = value
        End Set
    End Property
    Public Property facNumero() As Long
        Get
            Return _facNumero
        End Get
        Set(ByVal value As Long)
            _facNumero = value
        End Set
    End Property
    Public Property sinFecha() As Boolean
        Get
            Return _sinFecha
        End Get
        Set(ByVal value As Boolean)
            _sinFecha = value
        End Set
    End Property
    Public Property rec_codigo() As Long
        Get
            Return _rec_codigo
        End Get
        Set(ByVal value As Long)
            _rec_codigo = value
        End Set
    End Property
    Public Property idImpresion() As String
        Get
            Return _idImpresion
        End Get
        Set(ByVal value As String)
            _idImpresion = value
        End Set
    End Property
    Public Property nombreReporte() As String
        Get
            Return _nombreReporte
        End Get
        Set(ByVal value As String)
            _nombreReporte = value
        End Set
    End Property
    Public Property emb_sello() As String
        Get
            Return _emb_sello
        End Get
        Set(ByVal value As String)
            _emb_sello = value
        End Set
    End Property
    Public Property Origen() As String
        Get
            Return _Origen
        End Get
        Set(ByVal value As String)
            _Origen = value
        End Set
    End Property
    Public Property pic_codigo() As String
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As String)
            _pic_codigo = value
        End Set
    End Property
    Public Property strCadena() As String
        Get
            Return _strCadena
        End Get
        Set(ByVal value As String)
            _strCadena = value
        End Set
    End Property
    Public Property strFecha() As String
        Get
            Return _strFecha
        End Get
        Set(ByVal value As String)
            _strFecha = value
        End Set
    End Property
    Public Property strHoraIni() As String
        Get
            Return _strHoraIni
        End Get
        Set(ByVal value As String)
            _strHoraIni = value
        End Set
    End Property
    Public Property strHoraFin() As String
        Get
            Return _strHoraFin
        End Get
        Set(ByVal value As String)
            _strHoraFin = value
        End Set
    End Property
    Public Property dev_codigo() As String
        Get
            Return _dev_codigo
        End Get
        Set(ByVal value As String)
            _dev_codigo = value
        End Set
    End Property
    Public Property car_codigo() As Integer
        Get
            Return _car_codigo
        End Get
        Set(ByVal value As Integer)
            _car_codigo = value
        End Set
    End Property
    Public Property epc_codigo() As Integer
        Get
            Return _epc_codigo
        End Get
        Set(ByVal value As Integer)
            _epc_codigo = value
        End Set
    End Property
    Public Property nomCliente() As String
        Get
            Return _nomCliente
        End Get
        Set(ByVal value As String)
            _nomCliente = value
        End Set
    End Property
    Public Property nomEstado() As String
        Get
            Return _nomEstado
        End Get
        Set(ByVal value As String)
            _nomEstado = value
        End Set
    End Property

    Private Sub frm_imprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New ReportDocument

        If Origen = "TX" Then
            Call IMPRIME_TARJETA_EXISTENCIA()
        ElseIf Origen = "PK" Then
            Call IMPRIME_PICKING()
        ElseIf Origen = "PKC" Then
            Call IMPRIME_PICKING_CONSOLIDADO()
        ElseIf Origen = "PKCB" Then
            Call IMPRIME_PICKING_CONSOLIDADO_BUSQUEDA()
        ElseIf Origen = "FD" Then
            Call IMPRIME_DEVOLUCION()
        ElseIf Origen = "PKD" Then
            Call IMPRIME_PICKING_DIARIO()
        ElseIf Origen = "EM" Then
            Call IMPRIME_EMBARQUE()
        ElseIf Origen = "FAL_ETI" Then
            Call FALABELLA_IMPRIME_ETIQUETA_BULTO()
        ElseIf Origen = "EASY_INTERNET" Then
            Call EASY_IMPRIME_INTERNET()
        ElseIf Origen = "CC" Then
            Call IMPRIME_CERTIFICADO_CONFORMIDAD()
        ElseIf Origen = "RFR" Then
            Call IMPRIME_RENDICION_FACTURA()
        ElseIf Origen = "RGR" Then
            Call IMPRIME_RENDICION_GUIAS()
        ElseIf Origen = "RRF" Then
            Call IMPRIME_REISION_FACTURA()
        ElseIf Origen = "CFR" Then
            Call IMPRIME_FACTURA_COBRO()
        ElseIf Origen = "DPP" Then
            Call IMPRIME_DEVOLUCION_PICKING()
        ElseIf Origen = "IMP_VTAP" Then
            Call IMPRIME_VENTAS_PENDIENTES()
        ElseIf Origen = "EPB" Then
            Call IMPRIME_ETIQUETAS_PRODUCTOS()
        ElseIf Origen = "REM" Then
            Call IMPRIME_RECEPCION_MUESTRA()
        ElseIf Origen = "IGP" Then
            Call IMPRIME_GUIAS_PALLET()
        ElseIf Origen = "REC" Then
            Dim respuesta As Integer = 0

            respuesta = MessageBox.Show("Si desea imprimir el informe resumido preciones SI, si quiere imprimir el detalle precione NO", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Cursor = System.Windows.Forms.Cursors.WaitCursor
            If respuesta = vbYes Then
                Call IMPRIME_RECEPCION_RESUMEN()
            ElseIf respuesta = vbNo Then
                Call IMPRIME_RECEPCION_DETALLE()
            End If
            Cursor = System.Windows.Forms.Cursors.Default

        ElseIf Origen = "POR" Then
            Dim respuesta As Integer = 0

            respuesta = MessageBox.Show("Si desea imprimir el informe resumido preciones SI, si quiere imprimir el detalle precione NO", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Cursor = System.Windows.Forms.Cursors.WaitCursor
            If respuesta = vbYes Then
                Call IMPRIME_PALETIZADO_OC_RESUMEN()
            ElseIf respuesta = vbNo Then
                Call IMPRIME_PALETIZADO_OC_DETALLE()
            End If
            Cursor = System.Windows.Forms.Cursors.Default
        ElseIf Origen = "INR" Then
            Call IMPRIME_RECEPCION()
        ElseIf Origen = "IRG" Then
            Call IMPRIME_RENDICION_GUIAS_PALLETS()
        ElseIf Origen = "SPA" Then
            Call IMPRIME_IDENTIFICADOR_PALLET()
        ElseIf Origen = "DAS" Then
            Call IMPRIME_DOCUMENTO_ASIGNACION()
        ElseIf Origen = "ETI_BUL_NUM" Then
            Call IMPRIME_ETIQUETA_BULTO_CON_NUMERO()
        ElseIf Origen = "OAB" Then
            IMPRIME_ORDEN_ABASTECIMIENTO()
        End If
    End Sub

    Private Sub IMPRIME_ORDEN_ABASTECIMIENTO()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptOrdenAbastecimiento.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _oab_codigo)

        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub


    Private Sub IMPRIME_DOCUMENTO_ASIGNACION()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet
        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptDocumentoAsignacion.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _asi_codigo)

        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_IDENTIFICADOR_PALLET()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet
        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptIdentificadorPallet.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _asi_codigo)
        CRReport.SetParameterValue(1, _serie_paller)

        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_RENDICION_GUIAS_PALLETS()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet
        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rpt_rendicion_guias_pallets.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, strFechaDesde)
        CRReport.SetParameterValue(1, strFechaHasta)
        CRReport.SetParameterValue(2, car_codigo)
        CRReport.SetParameterValue(3, val_numero)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub
    Private Sub IMPRIME_RECEPCION_MUESTRA()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptRecepcionMuesta.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _rec_codigo)

        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_TARJETA_EXISTENCIA()

        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rpt_tarjeta_existencia.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, pro_codigo)
        CRReport.SetParameterValue(1, bod_codigo)
        CRReport.SetParameterValue(2, pro_nombre)
        CRReport.SetParameterValue(3, bod_nombre)

        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub
    Private Sub IMPRIME_RENDICION_GUIAS()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet
        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rpt_rendicion_guias.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, strFecha)
        CRReport.SetParameterValue(1, strFechaHasta)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_RECEPCION()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptRecepcion_completa.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _rec_numero)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_GUIAS_PALLET()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptInformeGuiaPallet3.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, strCadena)

        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_ETIQUETAS_PRODUCTOS()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        strRutaIngformes = strRutaEtiquetas
        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "etiqueta_prodctos_fvt_bultos.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, strCadena)
        CRReport.SetParameterValue(1, 0)

        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_RECEPCION_RESUMEN()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptRecepcionResumen.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _rec_codigo)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_PALETIZADO_OC_RESUMEN()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptPaletizacionOCResumen.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _ocp_codigo)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_RECEPCION_DETALLE()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptRecepcionDetalle.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _rec_codigo)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_PALETIZADO_OC_DETALLE()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptPaletizacionOCDetalle.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _ocp_codigo)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_VENTAS_PENDIENTES()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "frmInformeVentasPendientes.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _car_codigo)
        CRReport.SetParameterValue(1, _epc_codigo)
        CRReport.SetParameterValue(2, _nomCliente)
        CRReport.SetParameterValue(3, _nomEstado)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_DEVOLUCION_PICKING()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptFormularioDevolucionPicking.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _dev_codigo)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_FACTURA_COBRO()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rpt_cobro_facturas.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, strFecha)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub
    Private Sub IMPRIME_REISION_FACTURA()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet
        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rpt_revision_facturas_rendidas.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, strFecha)
        CRReport.SetParameterValue(1, _facNumero)
        CRReport.SetParameterValue(2, _sinFecha)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_RENDICION_FACTURA()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet
        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rpt_rendicion_facturas.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, strFecha)
        CRReport.SetParameterValue(1, strFechaHasta)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_CERTIFICADO_CONFORMIDAD()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        'Crystal.PrinterDriver =

        CRReport.Load(strRutaIngformes + _nombreReporte, OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _car_codigo)
        CRReport.SetParameterValue(1, _strCadena)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub EASY_IMPRIME_INTERNET()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        'Crystal.PrinterDriver =

        strRutaIngformes = strRutaEtiquetas
        CRReport.Load(strRutaIngformes + _nombreReporte, OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _strCadena)
        CRReport.SetParameterValue(1, _idImpresion)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub


    Private Sub FALABELLA_IMPRIME_ETIQUETA_BULTO()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        strRutaIngformes = strRutaEtiquetas
        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + _nombreReporte, OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _strCadena)
        CRReport.SetParameterValue(1, pic_codigo)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_ETIQUETA_BULTO_CON_NUMERO()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        strRutaIngformes = strRutaEtiquetas
        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + _nombreReporte, OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _strCadena)
        CRReport.SetParameterValue(1, pic_codigo)
        CRReport.SetParameterValue(2, _numBulto)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim pdprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        pdprint.PrinterSettings.PrinterName = PrinterName
        For i As Integer = 0 To pdprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If pdprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(pdprint.PrinterSettings.PaperSizes(i).RawKind)
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function

    Private Sub IMPRIME_EMBARQUE()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptInformeEmbarque_new.rpt", OpenReportMethod.OpenReportByTempCopy)
        'CRReport.Load(strRutaIngformes + "rptInformeEmbarque.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _emb_sello)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_PICKING_DIARIO()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptPickingDiario.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _strFecha)
        CRReport.SetParameterValue(1, _pic_codigo)
        CRReport.SetParameterValue(2, _strFecha)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_PICKING_CONSOLIDADO()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptConsolidadoPickingNew.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _strCadena)
        CRReport.SetParameterValue(1, _strFecha)
        CRReport.SetParameterValue(2, _strHoraIni)
        CRReport.SetParameterValue(3, _strHoraFin)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_PICKING_CONSOLIDADO_BUSQUEDA()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptConsolidadoPickingUbicacionesNew2.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _strCadena)
        CRReport.SetParameterValue(1, _strFecha)
        CRReport.SetParameterValue(2, _strHoraIni)
        CRReport.SetParameterValue(3, _strHoraFin)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub

    Private Sub IMPRIME_PICKING()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptSolicitudPicking.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _pic_codigo)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub
    Private Sub IMPRIME_DEVOLUCION()
        'Dim strRuta As String = System.AppDomain.CurrentDomain.BaseDirectory() + "\rpt\rptCotizacion.rpt"
        Dim CRTable As Table
        Dim CRTLI As CrystalDecisions.Shared.TableLogOnInfo
        Dim ds As New DataSet

        CRReport = New ReportDocument
        CRReport.Load(strRutaIngformes + "rptFormularioDevolucion.rpt", OpenReportMethod.OpenReportByTempCopy)
        CRReport.SetParameterValue(0, _dev_codigo)
        For Each CRTable In CRReport.Database.Tables
            CRTLI = CRTable.LogOnInfo
            With CRTLI.ConnectionInfo
                .ServerName = pubServidor
                .UserID = pubUsuario
                .Password = pubContrasena
                .DatabaseName = pubBaseDato
            End With
            CRTable.ApplyLogOnInfo(CRTLI)
        Next CRTable
        CRReport.SetDatabaseLogon(pubUsuario, pubContrasena, pubServidor, pubBaseDato)
        CR.ReportSource = CRReport
    End Sub


End Class