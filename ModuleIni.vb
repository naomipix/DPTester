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
            PublicVariables.WorkOrderLen = IniFileHandler.ReadIniValue(IniFilePath, Section3, "WorkOrderLen", "5")
            PublicVariables.LotIdLen = IniFileHandler.ReadIniValue(IniFilePath, Section3, "LotIdLen", "5")
            PublicVariables.PartIdLen = IniFileHandler.ReadIniValue(IniFilePath, Section3, "PartIdLen", "5")
            PublicVariables.ConfirmationIdLen = IniFileHandler.ReadIniValue(IniFilePath, Section3, "ConfirmationIdLen", "5")
            PublicVariables.QuantityLen = IniFileHandler.ReadIniValue(IniFilePath, Section3, "QuantityLen", "1")

            Dim Section4 As String = "Chart"
            If CInt(IniFileHandler.ReadIniValue(IniFilePath, Section3, "ChartPlotMax", 500)) >= 100 Then
                PublicVariables.ChartPlotMax = IniFileHandler.ReadIniValue(IniFilePath, Section4, "ChartPlotMax", 500)
            Else
                PublicVariables.ChartPlotMax = 200
            End If
            PublicVariables.ChartType = IniFileHandler.ReadIniValue(IniFilePath, Section4, "ChartType", "Line")
            PublicVariables.MarkerEnabled = IniFileHandler.ReadIniValue(IniFilePath, Section4, "MarkerEnabled", 0)

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


        Catch ex As Exception
            MsgBox($"Incorrect Parameters Detected.{vbCrLf}Application Will Now Close.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, $"Configuration Error - {IniFilePath}")
            Application.Exit()
        End Try
    End Sub
End Module