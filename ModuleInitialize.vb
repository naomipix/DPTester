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
                'Inilines(1) = "[Database1]
                '            Server1=PIXELSVR01
                '            DBName1=PX1529_DPTester
                '            DBUID1=px
                '            DBPWD1=Pixel
                '            "
                Inilines(1) = "[Database1]" + vbCrLf +
                              "Server1=PIXELSVR01" + vbCrLf +
                              "DBName1=PX1529_DPTester" + vbCrLf +
                              "DBUID1=px" + vbCrLf +
                              "DBPWD1=Pixel"
                Inilines(2) = vbCrLf + "[Login]" + vbCrLf +
                              "PromptForLogin=1" + vbCrLf +
                              "PromptInterval=5"

                Inilines(3) = vbCrLf + "[Main Menu]"
                Inilines(4) = "[Main]" + vbCrLf +
                              "Title=SMART Test DP Tester" + vbCrLf +
                              "WorkOrderLenLow=9" + vbCrLf +
                              "WorkOrderLenHigh=9" + vbCrLf +
                              "LotIdLenLow=10" + vbCrLf +
                              "LotIdLenHigh=10" + vbCrLf +
                              "PartIdLenLow=16" + vbCrLf +
                              "PartIdLenHigh=16" + vbCrLf +
                              "ConfirmationIdLenLow=10" + vbCrLf +
                              "ConfirmationIdLenHigh=10" + vbCrLf +
                              "QuantityLenLow=2" + vbCrLf +
                              "QuantityLenHigh=2" + vbCrLf +
                              "SerialNumLen=3"
                Inilines(5) = vbCrLf + "[Chart]" + vbCrLf +
                              "ChartType=Spline" + vbCrLf +
                              "MarkerEnabled=0" + vbCrLf +
                              "ChartPlotMax=1000"

                Inilines(6) = vbCrLf + "[Production Details]" + vbCrLf +
                              "MaxCountDisplayed=10000"

                Inilines(7) = vbCrLf + "[Export]" + vbCrLf +
                              "ProductionFolder= C:\DPTester\Production Details\Export\" + vbCrLf +
                              "AlarmFolder=C:\DPTester\Alarm History\Export\" + vbCrLf +
                              "RecipeFolder=C:\DPTester\Recipe Details\Export\" + vbCrLf +
                              "ResultFolder=C:\DPTester\Result Details\Export\"

                Inilines(8) = vbCrLf + "[Limits]" + vbCrLf +
                              "BackPressureLowLimit=0.0" + vbCrLf +
                              "BackPressureHighLimit=500.0" + vbCrLf +
                              "N2PressureLowLimit=0.0" + vbCrLf +
                              "N2PressureHighLimit=500.0" + vbCrLf +
                              "PumpSpeedLowLimit=0" + vbCrLf +
                              "PumpSpeedLowLimit=10000" + vbCrLf +
                              "PumpFlowrateLowLimit=0.0" + vbCrLf +
                              "PumpFlowrateHighLimit=100.0"

                Inilines(9) = vbCrLf + "[Recipe Parameter Limits]" + vbCrLf +
                              "MinVerificationTolerance=0" + vbCrLf +
                              "MinFlush1_FillTime=0" + vbCrLf +
                              "MinFlush1_BleedTime=0" + vbCrLf +
                              "MinFlush1_Flowrate=0" + vbCrLf +
                              "MinFlush1_FlowTolerance=0" + vbCrLf +
                              "MinFlush1_BackPressure=0" + vbCrLf +
                              "MinFlush1_StabilizeTime=0" + vbCrLf +
                              "MinFlush1_Time=0" + vbCrLf +
                              "MinDPTest_FillTime=0" + vbCrLf +
                              "MinDPTest_BleedTime=0" + vbCrLf +
                              "MinDPTest_Flowrate=0" + vbCrLf +
                              "MinDPTest_FLowTolerance=0" + vbCrLf +
                              "MinDPTest_BackPressure=0" + vbCrLf +
                              "MinDPTest_StabilizeTime=0" + vbCrLf +
                              "MinDPTest_Time=0" + vbCrLf +
                              "MinDPTest_LowLimit=0" + vbCrLf +
                              "MinDPTest_HighLimit=0" + vbCrLf +
                              "MinDPTest_Points=0" + vbCrLf +
                              "MinFlush2_FillTime=0" + vbCrLf +
                              "MinFlush2_BleedTime=0" + vbCrLf +
                              "MinFlush2_Flowrate=0" + vbCrLf +
                              "MinFlush2_FlowTolerance=0" + vbCrLf +
                              "MinFlush2_BackPressure=0" + vbCrLf +
                              "MinFlush2_StabilizeTime=0" + vbCrLf +
                              "MinFlush2_Time=0" + vbCrLf +
                              "MinDrain1_Pressure=0" + vbCrLf +
                              "MinDrain1_Time=0" + vbCrLf +
                              "MinDrain2_Pressure=0" + vbCrLf +
                              "MinDrain2_Time=0" + vbCrLf +
                              "MinDrain3_Pressure=0" + vbCrLf +
                              "MinDrain3_Time=0" + vbCrLf +
                              vbCrLf +
                              "MaxVerificationTolerance=50" + vbCrLf +
                              "MaxFlush1_FillTime=600" + vbCrLf +
                              "MaxFlush1_BleedTime=600" + vbCrLf +
                              "MaxFlush1_Flowrate=20" + vbCrLf +
                              "MaxFlush1_FlowTolerance=5" + vbCrLf +
                              "MaxFlush1_BackPressure=500" + vbCrLf +
                              "MaxFlush1_StabilizeTime=600" + vbCrLf +
                              "MaxFlush1_Time=600" + vbCrLf +
                              "MaxDPTest_FillTime=600" + vbCrLf +
                              "MaxDPTest_BleedTime=600" + vbCrLf +
                              "MaxDPTest_Flowrate=20" + vbCrLf +
                              "MaxDPTest_FLowTolerance=5" + vbCrLf +
                              "MaxDPTest_BackPressure=500" + vbCrLf +
                              "MaxDPTest_StabilizeTime=600" + vbCrLf +
                              "MaxDPTest_Time=600" + vbCrLf +
                              "MaxDPTest_LowLimit=100" + vbCrLf +
                              "MaxDPTest_HighLimit=500" + vbCrLf +
                              "MaxDPTest_Points=60" + vbCrLf +
                              "MaxFlush2_FillTime=600" + vbCrLf +
                              "MaxFlush2_BleedTime=600" + vbCrLf +
                              "MaxFlush2_Flowrate=20" + vbCrLf +
                              "MaxFlush2_FlowTolerance=5" + vbCrLf +
                              "MaxFlush2_BackPressure=500" + vbCrLf +
                              "MaxFlush2_StabilizeTime=600" + vbCrLf +
                              "MaxFlush2_Time=600" + vbCrLf +
                              "MaxDrain1_Pressure=500" + vbCrLf +
                              "MaxDrain1_Time=600" + vbCrLf +
                              "MaxDrain2_Pressure=500" + vbCrLf +
                              "MaxDrain2_Time=600" + vbCrLf +
                              "MaxDrain3_Pressure=500" + vbCrLf +
                              "MaxDrain3_Time=600"




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
