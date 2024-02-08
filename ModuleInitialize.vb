Imports System.IO
Imports DocumentFormat.OpenXml.Packaging

Module ModuleInitialize
    Public iniFolderLocation As String = "C:\DPTester\Ini File"
    Public iniFileLocation As String = "C:\DPTester\Ini File\appconfig.ini"
    Public ProductionFolder As String = "C:\DPTester\Production Details\Export"
    Public AlarmFolder As String = "C:\DPTester\Alarm History\Export"
    Public RecipeFolder As String = "C:\DPTester\Recipe Details\Export"
    Public ResultFolder As String = "C:\DPTester\Result Details\Export"
    Public EventFolder As String = "C:\DPTester\Event Log\Export"
    Public LotreportFolder As String = "C:\DPTester\LotEnd Report"
    Public TemplateFolder As String = "C:\DPTester\Template"
    Public TemplateFile As String = Environment.CurrentDirectory & "\EndLotReportTemplate.xlsx"
    Public CdriveTemplate As String = "C:\DPTester\Template\EndLotReportTemplate.xlsx"

    Public Sub CreateFolders()
        Try
            'Create Ini Folder
            If Not Directory.Exists(iniFolderLocation) Then
                Directory.CreateDirectory(iniFolderLocation)
            End If

            If Directory.Exists(iniFolderLocation) Then
                If Not File.Exists(iniFileLocation) Then
                    Inifilegenerate()
                End If
            End If

            'Create Production Folder
            If Not Directory.Exists(ProductionFolder) Then
                Directory.CreateDirectory(ProductionFolder)
            End If

            'Create Alarm Folder
            If Not Directory.Exists(AlarmFolder) Then
                Directory.CreateDirectory(AlarmFolder)
            End If

            'Create Recipe Folder
            If Not Directory.Exists(RecipeFolder) Then
                Directory.CreateDirectory(RecipeFolder)
            End If

            'Create Result Folder
            If Not Directory.Exists(ResultFolder) Then
                Directory.CreateDirectory(ResultFolder)
            End If

            'Create Event Log Folder
            If Not Directory.Exists(EventFolder) Then
                Directory.CreateDirectory(EventFolder)
            End If

            'Create Lot Report Folder
            If Not Directory.Exists(LotreportFolder) Then
                Directory.CreateDirectory(LotreportFolder)
            End If

            'Create Template Folder
            If Not Directory.Exists(TemplateFolder) Then
                Directory.CreateDirectory(TemplateFolder)
            End If

            If Not File.Exists(CdriveTemplate) Then
                MoveFile()
            End If


        Catch ex As Exception
            MsgBox("Folder Creation Failed, check for Access Level")
        End Try

    End Sub

    Public Sub Inifilegenerate()
        Try
            If Not File.Exists(iniFileLocation) Then
                Dim Inilines(10) As String
                Inilines(0) = "[App Config]"
                Inilines(1) = "[Database1]
                            Server1=PIXELSVR01
                            DBName1=PX1529_DPTester
                            DBUID1=px
                            DBPWD1=Pixel
                            "
                Inilines(2) = "[Login]
                            PromptForLogin=1
                            PromptInterval=5"

                Inilines(3) = "[Main Menu]"
                Inilines(4) = "[Main]
                            Title=SMART Test DP Tester
                            WorkOrderLen=9
                            LotIdLen=10
                            PartIdLen=16
                            ConfirmationIdLen=10
                            QuantityLen=2"
                Inilines(5) = "[Chart]
                            ChartType=Spline
                            MarkerEnabled=0
                            ChartPlotMax=1000"

                Inilines(6) = "[Production Details]
                            MaxCountDisplayed=10000"

                Inilines(7) = "[Export]
                            ProductionFolder= C:\DPTester\Production Details\Export\
                            AlarmFolder=C:\DPTester\Alarm History\Export\
                            RecipeFolder=C:\DPTester\Recipe Details\Export\
                            ResultFolder=C:\DPTester\Result Details\Export\
                            "

                Inilines(8) = "[Limits]
                            BackPressureLowLimit=0.0
                            BackPressureHighLimit=500.0
                            N2PressureLowLimit=0.0
                            N2PressureHighLimit=500.0
                            PumpSpeedLowLimit=0
                            PumpSpeedLowLimit=10000
                            PumpFlowrateLowLimit=0.0
                            PumpFlowrateHighLimit=100.0
                            "

                System.IO.File.WriteAllLines(iniFileLocation, Inilines)

            End If
        Catch ex As Exception
            MsgBox("Ini File Creation Failed")
        End Try

    End Sub

    Public Sub MoveFile()
        Try

            If System.IO.File.Exists(TemplateFile) Then

                File.Copy(TemplateFile, "C:\DPTester\Template\EndLotReportTemplate.xlsx", True)

            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub


End Module
