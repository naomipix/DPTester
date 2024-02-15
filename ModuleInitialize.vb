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

                Inilines(9) = "[Recipe Parameter Limits]
                            MinVerificationTolerance=0
                            MinFlush1_FillTime=0
                            MinFlush1_BleedTime=0
                            MinFlush1_Flowrate=0
                            MinFlush1_FlowTolerance=0
                            MinFlush1_BackPressure=0
                            MinFlush1_StabilizeTime=0
                            MinFlush1_Time=0
                            MinDPTest_FillTime=0
                            MinDPTest_BleedTime=0
                            MinDPTest_Flowrate=0
                            MinDPTest_FLowTolerance=0
                            MinDPTest_BackPressure=0
                            MinDPTest_StabilizeTime=0
                            MinDPTest_Time=0
                            MinDPTest_LowLimit=0
                            MinDPTest_HighLimit=0 
                            MinDPTest_Points=0
                            MinFlush2_FillTime=0
                            MinFlush2_BleedTime=0
                            MinFlush2_Flowrate=0
                            MinFlush2_FlowTolerance=0
                            MinFlush2_BackPressure=0
                            MinFlush2_StabilizeTime=0
                            MinFlush2_Time=0
                            MinDrain1_Pressure=0
                            MinDrain1_Time=0
                            MinDrain2_Pressure=0
                            MinDrain2_Time=0
                            MinDrain3_Pressure=0
                            MinDrain3_Time=0

                            MaxVerificationTolerance=50
                            MaxFlush1_FillTime=600
                            MaxFlush1_BleedTime=600
                            MaxFlush1_Flowrate=20
                            MaxFlush1_FlowTolerance=5
                            MaxFlush1_BackPressure=500
                            MaxFlush1_StabilizeTime=600
                            MaxFlush1_Time=600
                            MaxDPTest_FillTime=600
                            MaxDPTest_BleedTime=600
                            MaxDPTest_Flowrate=20
                            MaxDPTest_FLowTolerance=5
                            MaxDPTest_BackPressure=500
                            MaxDPTest_StabilizeTime=600
                            MaxDPTest_Time=600
                            MaxDPTest_LowLimit=100
                            MaxDPTest_HighLimit=500 
                            MaxDPTest_Points=60
                            MaxFlush2_FillTime=600
                            MaxFlush2_BleedTime=600
                            MaxFlush2_Flowrate=20
                            MaxFlush2_FlowTolerance=5
                            MaxFlush2_BackPressure=500
                            MaxFlush2_StabilizeTime=600
                            MaxFlush2_Time=600
                            MaxDrain1_Pressure=500
                            MaxDrain1_Time=600
                            MaxDrain2_Pressure=500
                            MaxDrain2_Time=600
                            MaxDrain3_Pressure=500
                            MaxDrain3_Time=600
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
