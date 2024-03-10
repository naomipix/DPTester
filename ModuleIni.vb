Module IniFileHandler
    ' Reading From Ini File
    'Dim value As String = IniFileHandler.ReadIniValue("path_to_your_ini_file.ini", "SectionName", "KeyName", "DefaultValue")
    'Console.WriteLine(value)

    ' Writing To Ini File
    'IniFileHandler.WriteIniValue("path_to_your_ini_file.ini", "SectionName", "KeyName", "NewValue")


    ' Function to read a value from an ini file
    Public Function ReadIniValue(filePath As String, section As String, key As String, defaultValue As String) As String
        Try
            Dim value As String = defaultValue
            If System.IO.File.Exists(filePath) Then
                Dim lines() As String = System.IO.File.ReadAllLines(filePath)
                Dim inSection As Boolean = False
                For Each line As String In lines
                    If line.Trim().StartsWith("[" & section & "]") Then
                        inSection = True
                    ElseIf inSection AndAlso line.Contains("=") Then
                        Dim parts() As String = line.Split("=")
                        If parts.Length = 2 AndAlso parts(0).Trim() = key Then
                            value = parts(1).Trim()
                            Exit For
                        End If
                    ElseIf inSection AndAlso line.Trim().StartsWith("[") Then
                        Exit For
                    End If
                Next
            End If
            Return value
        Catch ex As Exception
            ' Handle exceptions here
            Return defaultValue
        End Try
    End Function

    ' Function to write a value to an ini file
    Public Sub WriteIniValue(filePath As String, section As String, key As String, value As String)
        Try
            Dim lines() As String = {}
            If System.IO.File.Exists(filePath) Then
                lines = System.IO.File.ReadAllLines(filePath)
            End If

            Dim updatedLines As New List(Of String)()
            Dim inSection As Boolean = False
            Dim keyUpdated As Boolean = False

            For Each line As String In lines
                If line.Trim().StartsWith("[" & section & "]") Then
                    inSection = True
                ElseIf inSection AndAlso line.Contains("=") Then
                    Dim parts() As String = line.Split("=")
                    If parts.Length = 2 AndAlso parts(0).Trim() = key Then
                        line = key & " = " & value
                        keyUpdated = True
                    End If
                ElseIf inSection AndAlso line.Trim().StartsWith("[") Then
                    If Not keyUpdated Then
                        updatedLines.Add(key & " = " & value)
                        keyUpdated = True
                    End If
                End If
                updatedLines.Add(line)
            Next

            If Not keyUpdated Then
                updatedLines.Add(key & " = " & value)
            End If

            System.IO.File.WriteAllLines(filePath, updatedLines.ToArray())
        Catch ex As Exception
            ' Handle exceptions here
        End Try
    End Sub

End Module

Module IniFileDefaults
    'GenerateDefaultIniFile("default_config.ini")

    Sub GenerateDefaultIniFile(filePath As String)
        ' Write default values to the INI file
        IniFileHandler.WriteIniValue(filePath, "Section1", "Key1", "DefaultValue1")
        IniFileHandler.WriteIniValue(filePath, "Section1", "Key2", "DefaultValue2")
        IniFileHandler.WriteIniValue(filePath, "Section2", "Key3", "DefaultValue3")
        IniFileHandler.WriteIniValue(filePath, "Section2", "Key4", "DefaultValue4")

        Console.WriteLine("Default INI file generated successfully.")
    End Sub
End Module

Module IniFileInitialize
    Dim IniFilePath As String = "C:\DPTester\Ini File\appconfig.ini"

    Public Sub ReadConfig()
        Try
            Dim Section1 As String = "Database1"
            PublicVariables.Server1 = IniFileHandler.ReadIniValue(IniFilePath, Section1, "Server1", "127.0.0.1/SQLEXPRESS")
            PublicVariables.DBName1 = IniFileHandler.ReadIniValue(IniFilePath, Section1, "DBName1", "")
            PublicVariables.DBUID1 = IniFileHandler.ReadIniValue(IniFilePath, Section1, "DBUID1", "")
            PublicVariables.DBPWD1 = IniFileHandler.ReadIniValue(IniFilePath, Section1, "DBPWD1", "")

            Dim Section2 As String = "Login"
            If IniFileHandler.ReadIniValue(IniFilePath, Section2, "PromptForLogin", "1") = "1" Then
                PublicVariables.LoginPrompt = True
            End If
            PublicVariables.LoginPromptInterval = IniFileHandler.ReadIniValue(IniFilePath, Section2, "PromptInterval", "5")

            Dim Section3 As String = "Main"
            PublicVariables.ProgramTitle = IniFileHandler.ReadIniValue(IniFilePath, Section3, "Title", "DP Tester")
            PublicVariables.WorkOrderLenLow = IniFileHandler.ReadIniValue(IniFilePath, Section3, "WorkOrderLenLow", "5")
            PublicVariables.WorkOrderLenHigh = IniFileHandler.ReadIniValue(IniFilePath, Section3, "WorkOrderLenHigh", "5")
            PublicVariables.LotIdLenLow = IniFileHandler.ReadIniValue(IniFilePath, Section3, "LotIdLenLow", "5")
            PublicVariables.LotIdLenHigh = IniFileHandler.ReadIniValue(IniFilePath, Section3, "LotIdLenHigh", "5")
            PublicVariables.PartIdLenLow = IniFileHandler.ReadIniValue(IniFilePath, Section3, "PartIdLenLow", "5")
            PublicVariables.PartIdLenHigh = IniFileHandler.ReadIniValue(IniFilePath, Section3, "PartIdLenHigh", "5")
            PublicVariables.ConfirmationIdLenLow = IniFileHandler.ReadIniValue(IniFilePath, Section3, "ConfirmationIdLenLow", "5")
            PublicVariables.ConfirmationIdLenHigh = IniFileHandler.ReadIniValue(IniFilePath, Section3, "ConfirmationIdLenHigh", "5")
            PublicVariables.QuantityLenLow = IniFileHandler.ReadIniValue(IniFilePath, Section3, "QuantityLenLow", "1")
            PublicVariables.QuantityLenHigh = IniFileHandler.ReadIniValue(IniFilePath, Section3, "QuantityLenHigh", "1")
            PublicVariables.SerialNumLen = IniFileHandler.ReadIniValue(IniFilePath, Section3, "SerialNumLen", "3")

            Dim Section4 As String = "Chart"
            If CInt(IniFileHandler.ReadIniValue(IniFilePath, Section3, "ChartPlotMax", 500)) >= 100 Then
                PublicVariables.ChartPlotMax = IniFileHandler.ReadIniValue(IniFilePath, Section4, "ChartPlotMax", 500)
            Else
                PublicVariables.ChartPlotMax = 200
            End If
            PublicVariables.ChartType = IniFileHandler.ReadIniValue(IniFilePath, Section4, "ChartType", "Line")
            PublicVariables.MarkerEnabled = IniFileHandler.ReadIniValue(IniFilePath, Section4, "MarkerEnabled", 0)
            If CInt(IniFileHandler.ReadIniValue(IniFilePath, Section4, "RollingAvgSize", 3)) > 0 Then
                PublicVariables.RollingAvgSize = IniFileHandler.ReadIniValue(IniFilePath, Section4, "RollingAvgSize", 3)
            Else
                PublicVariables.RollingAvgSize = 1
            End If

            Dim Section5 As String = "Production Details"
            If True Then
                Dim DefaultValue As Integer = 10000
                If IsNumeric(IniFileHandler.ReadIniValue(IniFilePath, Section4, "MaxCountDisplayed", "10000")) = True Then
                    PublicVariables.ProdDetailsDisplayedTableCount = IniFileHandler.ReadIniValue(IniFilePath, Section5, "MaxCountDisplayed", DefaultValue)
                Else
                    PublicVariables.ProdDetailsDisplayedTableCount = DefaultValue
                End If
            End If

            Dim Section6 As String = "Export"
            PublicVariables.DefaultpathToProductionDetails = IniFileHandler.ReadIniValue(IniFilePath, Section6, "ProductionFolder", "C:\Users\")
            PublicVariables.DefaultpathToAlarmHistory = IniFileHandler.ReadIniValue(IniFilePath, Section6, "AlarmFolder", "C:\Users\")
            PublicVariables.DefaultpathToRecipeDetails = IniFileHandler.ReadIniValue(IniFilePath, Section6, "RecipeFolder", "C:\Users\")
            PublicVariables.DefaultpathToResultSummary = IniFileHandler.ReadIniValue(IniFilePath, Section6, "ResultFolder", "C:\Users\")

            Dim Section7 As String = "Limits"
            PublicVariables.BPRegulatorLowLimit = IniFileHandler.ReadIniValue(IniFilePath, Section7, "BackPressureLowLimit", "0.0")
            PublicVariables.BPRegulatorHighLimit = IniFileHandler.ReadIniValue(IniFilePath, Section7, "BackPressureHighLimit", "500.0")
            PublicVariables.N2RegulatorLowLimit = IniFileHandler.ReadIniValue(IniFilePath, Section7, "N2PressureLowLimit", "0.0")
            PublicVariables.N2RegulatorHighLimit = IniFileHandler.ReadIniValue(IniFilePath, Section7, "N2PressureHighLimit", "500.0")
            PublicVariables.PumpSpeedLowLimit = IniFileHandler.ReadIniValue(IniFilePath, Section7, "PumpSpeedLowLimit", "0")
            PublicVariables.PumpSpeedHighLimit = IniFileHandler.ReadIniValue(IniFilePath, Section7, "PumpSpeedHighLimit", "10000")
            PublicVariables.PumpFlowrateLowLimit = IniFileHandler.ReadIniValue(IniFilePath, Section7, "PumpFlowrateLowLimit", "0.0")
            PublicVariables.PumpFlowrateHighLimit = IniFileHandler.ReadIniValue(IniFilePath, Section7, "PumpFlowrateHighLimit", "100.0")

            Dim Section8 As String = "Recipe Parameter Limits"
            PublicVariables.Limit_Min_d_vertol = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinVerificationTolerance", "0")

            PublicVariables.Limit_Min_i_prepfilltime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinPrep_FillTime", "0")
            PublicVariables.Limit_Min_i_prepbleedtime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinPrep_BleedTime", "0")
            PublicVariables.Limit_Min_d_prepflow = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinPrep_Flowrate", "0")
            PublicVariables.Limit_Min_d_preppressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinPrep_BackPressure", "0")
            PublicVariables.Limit_Min_d_preppressuredrop = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinPrep_BackPressureDrop", "0")
            PublicVariables.Limit_Min_i_preppressuredroptime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinPrep_BackPressureDropTime", "0")

            'PublicVariables.Limit_Min_i_flush1filltime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush1_FillTime", "0")
            'PublicVariables.Limit_Min_i_flush1bleedtime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush1_BleedTime", "0")
            PublicVariables.Limit_Min_d_flush1flow = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush1_Flowrate", "0")
            PublicVariables.Limit_Min_d_flush1flowtol = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush1_FlowTolerance", "0")
            PublicVariables.Limit_Min_d_flush1pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush1_BackPressure", "0")
            PublicVariables.Limit_Min_i_flush1stabilize = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush1_StabilizeTime", "0")
            PublicVariables.Limit_Min_i_flush1time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush1_Time", "0")
            'PublicVariables.Limit_Min_i_dptestfilltime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_FillTime", "0")
            'PublicVariables.Limit_Min_i_dptestbleedtime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_BleedTime", "0")
            PublicVariables.Limit_Min_d_dptestflow = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_Flowrate", "0")
            PublicVariables.Limit_Min_d_dptestflowtol = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_FLowTolerance", "0")
            PublicVariables.Limit_Min_d_dptestpressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_BackPressure", "0")
            PublicVariables.Limit_Min_i_dpteststabilize = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_StabilizeTime", "0")
            PublicVariables.Limit_Min_i_dptesttime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_Time", "0")
            PublicVariables.Limit_Min_d_dptestlowlimit = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_LowLimit", "0")
            PublicVariables.Limit_Min_d_dptestuplimit = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_HighLimit", "0")
            PublicVariables.Limit_Min_i_dptestpoints = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDPTest_Points", "0")
            'PublicVariables.Limit_Min_i_flush2filltime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush2_FillTime", "0")
            'PublicVariables.Limit_Min_i_flush2bleedtime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush2_BleedTime", "0")
            PublicVariables.Limit_Min_d_flush2flow = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush2_Flowrate", "0")
            PublicVariables.Limit_Min_d_flush2flowtol = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush2_FlowTolerance", "0")
            PublicVariables.Limit_Min_d_flush2pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush2_BackPressure", "0")
            PublicVariables.Limit_Min_i_flush2stabilize = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush2_StabilizeTime", "0")
            PublicVariables.Limit_Min_i_flush2time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinFlush2_Time", "0")
            PublicVariables.Limit_Min_d_drain1pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDrain1_Pressure", "0")
            PublicVariables.Limit_Min_i_drain1time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDrain1_Time", "0")
            PublicVariables.Limit_Min_d_drain2pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDrain2_Pressure", "0")
            PublicVariables.Limit_Min_i_drain2time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDrain2_Time", "0")
            PublicVariables.Limit_Min_d_drain3pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDrain3_Pressure", "0")
            PublicVariables.Limit_Min_i_drain3time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MinDrain3_Time", "0")

            ' Hard Limit (BP/N2 Reg)
            If True Then
                Dim MinPress As Decimal = 5
                Dim PressArr As Decimal() = {
                    PublicVariables.Limit_Min_d_preppressure,
                    PublicVariables.Limit_Min_d_preppressuredrop,
                    PublicVariables.Limit_Min_d_flush1pressure,
                    PublicVariables.Limit_Min_d_flush2pressure,
                    PublicVariables.Limit_Min_d_dptestpressure,
                    PublicVariables.Limit_Min_d_drain1pressure,
                    PublicVariables.Limit_Min_d_drain2pressure,
                    PublicVariables.Limit_Min_d_drain3pressure
                }

                For i As Integer = 0 To PressArr.Length - 1
                    If PressArr(i) < MinPress Then
                        PressArr(i) = MinPress
                    End If
                Next
            End If

            ' Hard limit to drain time
            If True Then
                Dim MinDrainTime As Integer = 15
                Dim DrainArr As Integer() = {PublicVariables.Limit_Min_i_drain1time, PublicVariables.Limit_Min_i_drain2time, PublicVariables.Limit_Min_i_drain3time}

                For i As Integer = 0 To DrainArr.Length - 1
                    If DrainArr(i) < MinDrainTime Then
                        DrainArr(i) = MinDrainTime
                    End If
                Next
            End If


            PublicVariables.Limit_Max_d_vertol = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxVerificationTolerance", "10")

            PublicVariables.Limit_Max_i_prepfilltime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxPrep_FillTime", "600")
            PublicVariables.Limit_Max_i_prepbleedtime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxPrep_BleedTime", "600")
            PublicVariables.Limit_Max_d_prepflow = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxPrep_Flowrate", "20")
            PublicVariables.Limit_Max_d_preppressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxPrep_BackPressure", "500")
            PublicVariables.Limit_Max_d_preppressuredrop = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxPrep_BackPressureDrop", "500")
            PublicVariables.Limit_Max_i_preppressuredroptime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxPrep_BackPressureDropTime", "600")

            'PublicVariables.Limit_Max_i_flush1filltime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush1_FillTime", "600")
            'PublicVariables.Limit_Max_i_flush1bleedtime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush1_BleedTime", "600")
            PublicVariables.Limit_Max_d_flush1flow = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush1_Flowrate", "20")
            PublicVariables.Limit_Max_d_flush1flowtol = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush1_FlowTolerance", "5")
            PublicVariables.Limit_Max_d_flush1pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush1_BackPressure", "500")
            PublicVariables.Limit_Max_i_flush1stabilize = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush1_StabilizeTime", "600")
            PublicVariables.Limit_Max_i_flush1time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush1_Time", "600")
            'PublicVariables.Limit_Max_i_dptestfilltime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_FillTime", "600")
            'PublicVariables.Limit_Max_i_dptestbleedtime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_BleedTime", "600")
            PublicVariables.Limit_Max_d_dptestflow = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_Flowrate", "20")
            PublicVariables.Limit_Max_d_dptestflowtol = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_FLowTolerance", "5")
            PublicVariables.Limit_Max_d_dptestpressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_BackPressure", "500")
            PublicVariables.Limit_Max_i_dpteststabilize = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_StabilizeTime", "600")
            PublicVariables.Limit_Max_i_dptesttime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_Time", "600")
            PublicVariables.Limit_Max_d_dptestlowlimit = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_LowLimit", "100")
            PublicVariables.Limit_Max_d_dptestuplimit = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_HighLimit", "500")
            PublicVariables.Limit_Max_i_dptestpoints = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDPTest_Points", "60")
            'PublicVariables.Limit_Max_i_flush2filltime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush2_FillTime", "600")
            'PublicVariables.Limit_Max_i_flush2bleedtime = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush2_BleedTime", "600")
            PublicVariables.Limit_Max_d_flush2flow = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush2_Flowrate", "20")
            PublicVariables.Limit_Max_d_flush2flowtol = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush2_FlowTolerance", "5")
            PublicVariables.Limit_Max_d_flush2pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush2_BackPressure", "500")
            PublicVariables.Limit_Max_i_flush2stabilize = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush2_StabilizeTime", "600")
            PublicVariables.Limit_Max_i_flush2time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxFlush2_Time", "600")
            PublicVariables.Limit_Max_d_drain1pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDrain1_Pressure", "500")
            PublicVariables.Limit_Max_i_drain1time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDrain1_Time", "600")
            PublicVariables.Limit_Max_d_drain2pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDrain2_Pressure", "500")
            PublicVariables.Limit_Max_i_drain2time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDrain2_Time", "600")
            PublicVariables.Limit_Max_d_drain3pressure = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDrain3_Pressure", "500")
            PublicVariables.Limit_Max_i_drain3time = IniFileHandler.ReadIniValue(IniFilePath, Section8, "MaxDrain3_Time", "600")




        Catch ex As Exception
            MsgBox($"Incorrect Parameters Detected.{vbCrLf}Application Will Now Close.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, $"Configuration Error - {IniFilePath}")
            Application.Exit()
        End Try
    End Sub
End Module