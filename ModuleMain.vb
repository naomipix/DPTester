Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Xml.Schema

Module PublicVariables
    ' Version
    Public AppVersion As String = "Ver. " & "1.0.0.1"

    ' License Status
    Public LicenseType As String = ""

    ' SQL Auto Backup / Delete Status
    Public LastSQLAutoBackup As DateTime
    Public LastSQLAutoDelete As DateTime

    ' Retained Memory - Operation Mode
    Public OperationMode As String = ""

    ' Retained Memory - Scanner Settings
    Public ScannerType As String = ""
    Public ScannerBypass As Boolean = False

    ' Retained Memory - Dryrun/Buyoff Settings
    Public DryRunEnabled As Boolean = False
    Public BuyOffEnabled As Boolean = False

    ' Retained Memory - Auto Delete Settings
    Public AutoDeleteEnabled As Boolean = False
    Public AutoDeleteDayAfter As Integer = 365

    ' Retained Memory - CSV Settings
    Public CSVPathToProductionDetails As String = ""
    Public CSVPathToAlarmHistory As String = ""
    Public CSVPathToRecipeDetails As String = ""
    Public CSVPathToResultSummary As String = ""
    Public CSVDelimiterProductionDetails As String = ""
    Public CSVDelimiterAlarmHistory As String = ""
    Public CSVDelimiterRecipeDetails As String = ""
    Public CSVDelimiterResultSummary As String = ""

    ' Retained Memory - Lot Details
    Public RetainedPartID As String
    Public RetainedWorkOrder As String
    Public RetainedLotID As String
    Public RetainedConfirmationID As String
    Public RetainedQuantity As String
    Public RetainedRecipeType As String
    Public RetainedRecipeID As String


    'Public LotStarted As Boolean = ""
    'Public LotIDNumber As String = ""
    'Public RecipeType As String = ""
    'Public RecipeID As String = ""

    ' Retained Memory - User Login Table Settings
    Public UserLoginHistoryTopCount As Integer = 100

    ' Retained Memory - SQL Auto Backup Settings
    Public AutoBackupSQLEnabled As Boolean = False
    Public AutoBackupSQLAtHour As Integer = 0
    Public AutoBackupSQLPath As String = ""

    ' Ini - Database
    Public Server1 As String = ""
    Public DBName1 As String = ""
    Public DBUID1 As String = ""
    Public DBPWD1 As String = ""

    'ini Export
    Public Recipeexportpath As String = ""
    Public Resultexportpath As String = ""
    ' Ini - Login
    Public LoginPrompt As Boolean = False
    Public LoginPromptInterval As Integer = 0

    ' Ini - Main
    Public ProgramTitle As String = ""
    Public WorkOrderLen As Integer = 0
    Public LotIdLen As Integer = 0
    Public PartIdLen As Integer = 0
    Public ConfirmationIdLen As Integer = 0
    Public QuantityLen As Integer = 0

    ' Ini - Chart
    Public ChartPlotMax As Integer = 200
    Public ChartType As String = ""
    Public MarkerEnabled As Integer = 0

    ' Ini - Production Details
    Public ProdDetailsDisplayedTableCount As Integer = 10000

    ' Login
    Public LoggedIn As Boolean = False
    Public LoggedInIsDeveloper As Boolean = True
    Public LoginUserID As Long = 0
    Public LoginUserName As String = ""
    Public LoginUserCategoryID As Integer = -1
    Public LoginUserCategoryName As String = ""

    ' Main Form
    Public IsExitPromptShown As Boolean = False
End Module

' DataGridView DoubleBuffering Module
' To Enable DoubleBuffering On DataGridView, Reference To - DoubleBuffer.DoubleBuffered(DataGridViewName, True)
Module DoubleBuffer
    Public Sub DoubleBuffered(ByVal dgv As DataGridView, ByVal setting As Boolean)
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, setting, Nothing)
    End Sub
End Module

Module TimerModule
    Public WithEvents clockTimer As New Timer()

    Private Sub clockTimer_Tick(sender As Object, e As EventArgs) Handles clockTimer.Tick
        ' Code to execute on each tick of the timer
        FormMain.lbl_DateTimeClock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        FormRecipeManagement.lbl_DateTimeClock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim RunningClocks As Label() = {
            FormMain.lbl_DateTimeClock,
            FormRecipeManagement.lbl_DateTimeClock,
            FormCalibration.lbl_DateTimeClock,
            FormResultSummary.lbl_DateTimeClock,
            FormMessageLog.lbl_DateTimeClock,
            FormSetting.lbl_DateTimeClock,
            FormResultGraph.lbl_DateTimeClock
        }

        For Each ClockLabel As Label In RunningClocks
            ClockLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Next
    End Sub
End Module

Module DatabaseModule
    'Public ConnectionString As String = "Data Source=(your_server);Initial Catalog=(your_database);Integrated Security=True"
    Public ConnectionString As String = $"Data Source='{Server1}';Initial Catalog='{DBName1}';User ID='{DBUID1}'; Password='{DBPWD1}';"     ' TrustServerCertificate='True';MultiSubnetFailover='True';"

    Public Function GetConnection() As SqlConnection
        Dim connection As New SqlConnection(ConnectionString)
        Return connection
    End Function
End Module

Module SQL
    '' Example of inserting a record
    'Dim parameters As New Dictionary(Of String, Object) From {
    '    {"Name", "John Doe"},
    '    {"Age", 30}
    '}
    'SQL.InsertRecord("Users", parameters)

    '' Example of reading records
    'Dim table As DataTable = SQL.ReadRecords("Users")
    '' You can now use the table to display the results or manipulate the data

    '' Example of updating a record
    'Dim updateParameters As New Dictionary(Of String, Object) From {
    '    {"Age", 31}
    '}
    'SQL.UpdateRecord("Users", updateParameters, "Name = 'John Doe'")

    '' Example of deleting a record
    'SQL.DeleteRecord("Users", "Name = 'John Doe'")

    Public WithEvents SQLAutoBackupTimer As New Timer()
    Public WithEvents SQLAutoDeleteTimer As New Timer()

    Public Function InsertRecord(tableName As String, parameters As Dictionary(Of String, Object)) As Integer
        Dim connection As SqlConnection = DatabaseModule.GetConnection()
        Dim ReturnValue As Integer = 0
        PCStatus(0)(2) = False
        Try
            Using (connection)
                Dim command As New SqlCommand()
                command.Connection = connection

                Dim InsertKey As String = ""
                Dim InsertValue As String = ""

                For item As Integer = 0 To parameters.Count - 1
                    ' Format SQL Values
                    Dim ParamID As String = $"@P{item + 1}"
                    Dim ParamColumn As String = parameters.Keys(item)
                    Dim ParamValue As String = parameters.Values(item)

                    ' Assign SQL Statement Values
                    InsertKey += ParamColumn
                    InsertValue += ParamID
                    If item < parameters.Count - 1 Then
                        ' Add "," To End Of Value
                        Dim delimiter As String = ", "
                        InsertKey += delimiter
                        InsertValue += delimiter
                    End If

                    ' Assign SQL Parametric Values
                    command.Parameters.AddWithValue(ParamID, ParamValue)
                Next

                connection.Open()

                ' Concatenate SQL String
                Dim sqlConcatenate As String = $"INSERT INTO {tableName} ({InsertKey}) VALUES ({InsertValue})"
                With command
                    .CommandText = sqlConcatenate
                    ReturnValue = .ExecuteNonQuery()
                End With

                connection.Close()
            End Using
        Catch ex As Exception
            PCStatus(0)(2) = True
            MsgBox(ex.Message & ex.StackTrace)
        End Try

        Return ReturnValue
    End Function

    Public Function ReadRecords(sqlString As String) As DataTable
        Dim connection As SqlConnection = DatabaseModule.GetConnection()
        connection.Open()

        'Dim query As String = $"SELECT * FROM {tableName}"
        Dim query As String = sqlString
        Dim command As New SqlCommand(query, connection)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        connection.Close()

        Return table
    End Function

    Public Function UpdateRecord(tableName As String, parameters As Dictionary(Of String, Object), condition As String) As Integer
        Dim connection As SqlConnection = DatabaseModule.GetConnection()
        Dim ReturnValue As Integer = 0
        PCStatus(0)(2) = False
        Try
            'conn.ConnectionString = connStr
            Using (connection)
                Dim cmd As New SqlCommand
                With cmd
                    ' Define Parameters
                    .Connection = connection
                    Dim sqlValues As String = ""

                    For item As Integer = 0 To parameters.Count - 1
                        ' Format SQL Values
                        Dim ParamID As String = $"@P{item + 1}"
                        Dim ParamColumn As String = parameters.Keys(item)
                        Dim ParamValue As String = parameters.Values(item)

                        ' Assign SQL Statement Values
                        sqlValues += ParamColumn & " = " & ParamID
                        If item < parameters.Count - 1 Then
                            ' Add "," To End Of Value
                            Dim delimiter As String = ", "
                            sqlValues += delimiter
                        End If

                        ' Assign SQL Parametric Values
                        .Parameters.AddWithValue(ParamID, ParamValue)
                    Next
                    ' Concatenate SQL String
                    Dim sqlConcatenate As String = "UPDATE " & tableName & " SET " & sqlValues & " WHERE " & condition
                    .CommandText = sqlConcatenate
                End With

                connection.Open()
                If condition <> Nothing Then
                    ReturnValue = cmd.ExecuteNonQuery()
                End If
                connection.Close()
            End Using
        Catch ex As Exception
            PCStatus(0)(2) = True
            MsgBox(ex.Message & ex.StackTrace)
        End Try

        Return ReturnValue
    End Function

    Public Function DeleteRecord(tableName As String, condition As String) As Integer
        Dim ReturnValue As Integer = 0

        Dim connection As SqlConnection = DatabaseModule.GetConnection()
        connection.Open()

        Dim query As String = $"DELETE FROM {tableName} WHERE {condition}"
        Dim command As New SqlCommand(query, connection)

        ReturnValue = command.ExecuteNonQuery()

        connection.Close()

        Return ReturnValue
    End Function

    Public Sub SQLSetAutoBackupMode(BackupEnabled As Boolean)
        SQLAutoBackupTimer.Interval = 30000
        If BackupEnabled = True Then
            SQLAutoBackupTimer.Enabled = BackupEnabled
        Else
            SQLAutoBackupTimer.Enabled = BackupEnabled
        End If
    End Sub

    Public Function SQLAutoBackup() As String
        Dim connection As New SqlConnection(ConnectionString)
        Dim command As New SqlCommand()

        Dim backupPath As String = PublicVariables.AutoBackupSQLPath.Substring(0, PublicVariables.AutoBackupSQLPath.Length - 1)
        Directory.CreateDirectory(backupPath)

        Dim backupFileName As String = $"{connection.Database}_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.bak"

        Dim ReturnedValue As String = ""

        Try
            connection.Open()
            command.Connection = connection
            command.CommandText = $"BACKUP DATABASE {connection.Database} TO DISK='{backupPath}\{backupFileName}'"

            command.ExecuteNonQuery()

            If True Then
                LastSQLAutoBackup = DateTime.Now
                'MessageBox.Show("Backup successful.", "Success")
                EventLog.EventLogger.Log("-", "[Application] Local Database Backup Success")
            End If

            RetainedMemory.Update(24, "AutoBackupSQLPerformedDate", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffK", CultureInfo.InvariantCulture))
            ReturnedValue = $"{backupPath}\{backupFileName}"
        Catch ex As Exception
            'MessageBox.Show("Error during backup: " & ex.Message, "Error")
            ReturnedValue = ""
        Finally
            connection.Close()
        End Try

        Return ReturnedValue
    End Function

    Private Sub SQLAutoBackupTimer_Tick(sender As Object, e As EventArgs) Handles SQLAutoBackupTimer.Tick
        If Not DateTime.Now.Date = LastSQLAutoBackup.Date Then
            If DateTime.Now.Hour = AutoBackupSQLAtHour Then
                SQLAutoBackup()
            End If
        End If
    End Sub


    Public Sub SQLSetAutoDeleteMode(AutoDeleteEnabled As Boolean)
        SQLAutoDeleteTimer.Interval = 60000
        If AutoDeleteEnabled = True Then
            SQLAutoDeleteTimer.Enabled = AutoDeleteEnabled
        Else
            SQLAutoDeleteTimer.Enabled = AutoDeleteEnabled
        End If
    End Sub

    Public Function SQLAutoDelete() As String
        Dim dtPastSetDayCount As DataTable = SQL.ReadRecords($"SELECT id FROM ProductionDetail WHERE timestamp < DATEADD(DAY, -{PublicVariables.AutoDeleteDayAfter}, GETDATE())")

        For Each row As DataRow In dtPastSetDayCount.Rows
            SQL.DeleteRecord("ProductionDetail", $"id='{row.Item("id")}'")
            SQL.DeleteRecord("ProductResult", $"serial_usage_id='{row.Item("id")}'")
        Next

        LastSQLAutoDelete = DateTime.Now

        Return True 'ReturnedValue
    End Function

    Private Sub SQLAutoDeleteTimer_Tick(sender As Object, e As EventArgs) Handles SQLAutoDeleteTimer.Tick
        If Not DateTime.Now.Date = LastSQLAutoDelete.Date Then
            If DateTime.Now.Hour = 0 Then
                SQLAutoDelete()
            End If
        End If
    End Sub
End Module

Module CsvExportModule
    'Function ExportDataTableToCsv(dataTable As DataTable, filePath As String, Optional delimiter As String = ",") As Boolean
    '    Dim ReturnState As Boolean = False
    '    Try
    '        Using writer As New StreamWriter(filePath)
    '            ' Write header row
    '            writer.WriteLine(String.Join(delimiter, dataTable.Columns.Cast(Of DataColumn).Select(Function(column) column.ColumnName)))

    '            ' Write data rows
    '            For Each row As DataRow In dataTable.Rows
    '                writer.WriteLine(String.Join(delimiter, row.ItemArray.Select(Function(item) item.ToString())))
    '            Next
    '        End Using
    '        ReturnState = True
    '    Catch ex As Exception
    '        ReturnState = False
    '    End Try

    '    Return ReturnState
    'End Function

    Function ExportDataTableToCsv(dataTable As DataTable, filePath As String, Optional delimiter As String = ",") As String
        Dim ReturnState As String = ""
        Try
            Dim directoryPath As String = Path.GetDirectoryName(filePath)

            If Not String.IsNullOrEmpty(directoryPath) AndAlso Directory.Exists(directoryPath) Then
                Using writer As New StreamWriter(filePath)
                    ' Write header row
                    writer.WriteLine(String.Join(delimiter, dataTable.Columns.Cast(Of DataColumn).Select(Function(column) column.ColumnName)))

                    ' Write data rows
                    For Each row As DataRow In dataTable.Rows
                        writer.WriteLine(String.Join(delimiter, row.ItemArray.Select(Function(item) item.ToString())))
                    Next
                    ReturnState = "True"
                End Using
            Else
                ReturnState = "Missing"
            End If
        Catch ex As Exception
            ReturnState = "False"
        End Try

        Return ReturnState
    End Function

    Function GetVisibleColumnsDataTable(dgv As DataGridView) As DataTable
        Dim dt As New DataTable()

        ' Create columns in DataTable based on visible columns in DataGridView
        For Each column As DataGridViewColumn In dgv.Columns
            If column.Visible Then
                dt.Columns.Add(column.HeaderText, column.ValueType)
            End If
        Next

        ' Populate DataTable with data from visible columns
        For Each row As DataGridViewRow In dgv.Rows
            Dim newRow As DataRow = dt.NewRow()
            For Each column As DataGridViewColumn In dgv.Columns
                If column.Visible Then
                    newRow(column.HeaderText) = row.Cells(column.Index).Value
                End If
            Next
            dt.Rows.Add(newRow)
        Next

        Return dt
    End Function
End Module

Namespace RetainedMemory
    Module RetainedMemory
        ' Retained Memory
        'Public AutoDeleteEnabled As String = ""
        'Public AutoDeleteDayAfter As String = ""
        'Public LotStarted As String = ""
        'Public LotIDNumber As String = ""
        'Public RecipeType As String = ""
        'Public RecipeID As String = ""

        Public Sub LoadAndApply()
            Dim dt As New DataTable
            Try
                dt = SQL.ReadRecords("SELECT id, description, retained_value FROM [0_RetainedMemory]")
            Catch ex As Exception
                MsgBox(ex.Message & ex.StackTrace)
            End Try

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    ' Operation Mode
                    If dt(i)("id") = 1 Then
                        PublicVariables.OperationMode = dt(i)("retained_value")
                    End If

                    ' Scanner Type
                    If dt(i)("id") = 2 Then
                        PublicVariables.ScannerType = dt(i)("retained_value")
                    End If

                    ' Scanner Bypass
                    If dt(i)("id") = 3 Then
                        If dt(i)("retained_value") = 1 Then
                            PublicVariables.ScannerBypass = True
                        Else
                            PublicVariables.ScannerBypass = False
                        End If
                    End If

                    ' Dry Run Enabled
                    If dt(i)("id") = 4 Then
                        If dt(i)("retained_value") = 1 Then
                            PublicVariables.DryRunEnabled = True
                        Else
                            PublicVariables.DryRunEnabled = False
                        End If
                    End If

                    ' Buy Off Enabled
                    If dt(i)("id") = 5 Then
                        If dt(i)("retained_value") = 1 Then
                            PublicVariables.BuyOffEnabled = True
                        Else
                            PublicVariables.BuyOffEnabled = False
                        End If
                    End If

                    ' Auto Delete Enabled
                    If dt(i)("id") = 6 Then
                        If dt(i)("retained_value") = 1 Then
                            PublicVariables.AutoDeleteEnabled = True
                        Else
                            PublicVariables.AutoDeleteEnabled = False
                        End If
                    End If

                    ' Auto Delete Day After
                    If dt(i)("id") = 7 Then
                        If Not Integer.TryParse(dt(i)("retained_value"), PublicVariables.AutoDeleteDayAfter) Then
                            PublicVariables.AutoDeleteDayAfter = 365
                        End If
                    End If

                    ' CSV Path To Production Details
                    If dt(i)("id") = 8 Then
                        PublicVariables.CSVPathToProductionDetails = dt(i)("retained_value")
                    End If

                    ' CSV Path To Alarm History
                    If dt(i)("id") = 9 Then
                        PublicVariables.CSVPathToAlarmHistory = dt(i)("retained_value")
                    End If

                    ' CSV Path To Recipe Details
                    If dt(i)("id") = 10 Then
                        PublicVariables.CSVPathToRecipeDetails = dt(i)("retained_value")
                    End If

                    ' CSV Path To Result Summary
                    If dt(i)("id") = 11 Then
                        PublicVariables.CSVPathToResultSummary = dt(i)("retained_value")
                    End If

                    ' Lot Started
                    If dt(i)("id") = 12 Then

                    End If

                    ' Lot ID Number
                    If dt(i)("id") = 13 Then

                    End If

                    ' Recipe Type
                    If dt(i)("id") = 14 Then
                        PublicVariables.RetainedRecipeType = dt(i)("retained_value")
                    End If

                    ' Recipe ID
                    If dt(i)("id") = 15 Then
                        PublicVariables.RetainedRecipeID = dt(i)("retained_value")
                    End If

                    ' CSV Production Details Delimiter
                    If dt(i)("id") = 16 Then
                        PublicVariables.CSVDelimiterProductionDetails = dt(i)("retained_value")
                    End If

                    ' CSV Alarm History Delimiter
                    If dt(i)("id") = 17 Then
                        PublicVariables.CSVDelimiterAlarmHistory = dt(i)("retained_value")
                    End If

                    ' CSV Recipe Details Delimiter
                    If dt(i)("id") = 18 Then
                        PublicVariables.CSVDelimiterRecipeDetails = dt(i)("retained_value")
                    End If

                    ' CSV Result Summary Delimiter
                    If dt(i)("id") = 19 Then
                        PublicVariables.CSVDelimiterResultSummary = dt(i)("retained_value")
                    End If

                    ' Quantity Of Row Displayed For User Login History Table
                    If dt(i)("id") = 20 Then
                        If Not Integer.TryParse(dt(i)("retained_value"), PublicVariables.UserLoginHistoryTopCount) Then
                            PublicVariables.UserLoginHistoryTopCount = 100
                        End If

                        ' Reset To Default of 100 if value returned 0
                        If PublicVariables.UserLoginHistoryTopCount = 0 Then
                            PublicVariables.UserLoginHistoryTopCount = 100
                            RetainedMemory.Update(dt(i)("id"), "UserLoginHistoryTopCount", "100")
                        End If
                    End If

                    ' Set Auto Backup SQL State
                    If dt(i)("id") = 21 Then
                        If dt(i)("retained_value") = 1 Then
                            PublicVariables.AutoBackupSQLEnabled = True
                        Else
                            PublicVariables.AutoBackupSQLEnabled = False
                        End If
                    End If

                    ' Set Auto Backup SQL At Specific Hour
                    If dt(i)("id") = 22 Then
                        If Not Integer.TryParse(dt(i)("retained_value"), PublicVariables.AutoBackupSQLAtHour) Then
                            PublicVariables.AutoBackupSQLAtHour = 0
                        End If

                        ' Reset To Default of 0 if value returned > 23
                        If PublicVariables.AutoBackupSQLAtHour > 23 Then
                            PublicVariables.AutoBackupSQLAtHour = 0
                            RetainedMemory.Update(dt(i)("id"), "AutoBackupSQLAtHour", "0")
                        End If
                    End If

                    ' Set Auto Backup SQL Path
                    If dt(i)("id") = 23 Then
                        PublicVariables.AutoBackupSQLPath = dt(i)("retained_value")
                    End If

                    ' Get Retained Lot Details
                    If dt(i)("id") = 25 Then
                        PublicVariables.RetainedWorkOrder = dt(i)("retained_value")
                    End If

                    If dt(i)("id") = 26 Then
                        PublicVariables.RetainedPartID = dt(i)("retained_value")
                    End If

                    If dt(i)("id") = 27 Then
                        PublicVariables.RetainedLotID = dt(i)("retained_value")
                    End If

                    If dt(i)("id") = 28 Then
                        PublicVariables.RetainedConfirmationID = dt(i)("retained_value")
                    End If

                    If dt(i)("id") = 29 Then
                        PublicVariables.RetainedQuantity = dt(i)("retained_value")
                    End If



                Next
            End If
        End Sub

        ' RetainedMemory.Update(1, "Description", "12345")
        Public Function Update(MemId As Integer, MemDesc As String, MemValue As String)
            Dim updateParameters As New Dictionary(Of String, Object) From {
                {"description", MemDesc.Substring(0, Math.Min(MemDesc.Length, 50))},
                {"retained_value", MemValue.Substring(0, Math.Min(MemValue.Length, 50))}
            }
            Return SQL.UpdateRecord("[0_RetainedMemory]", updateParameters, $"id = '{MemId}'")
        End Function
    End Module
End Namespace

Module DataGridViewDragScroll

    Private WithEvents dgv As DataGridView
    Private isDragging As Boolean = False
    Private initialMouseLocation As Point
    Private scrollFactor As Integer = 2 'Adjust this value for faster or slower scrolling 
    Private scrollFactorUp As Integer = scrollFactor ' Adjust this value for faster or slower scrolling up
    Private scrollFactorDown As Integer = scrollFactor * 1.67 ' Adjust this value for faster or slower scrolling down
    Private lastDeltaY As Integer = 0
    Private hasScrolled As Boolean = False

    Public Sub EnableDragToScroll(dgv As DataGridView)
        DataGridViewDragScroll.dgv = dgv

        ' Disable multi-select
        dgv.MultiSelect = False

        AddHandler dgv.MouseDown, AddressOf dgv_MouseDown
        AddHandler dgv.MouseUp, AddressOf dgv_MouseUp
        AddHandler dgv.MouseMove, AddressOf dgv_MouseMove
    End Sub

    Private Sub dgv_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            isDragging = True
            initialMouseLocation = e.Location
        End If
    End Sub

    Private Sub dgv_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            isDragging = False
            lastDeltaY = 0

            ' Clear selection if a scroll has occurred
            If hasScrolled Then
                dgv.ClearSelection()
                hasScrolled = False
            End If
        End If
    End Sub

    Private Sub dgv_MouseMove(sender As Object, e As MouseEventArgs)
        If isDragging Then
            Dim deltaY As Integer = e.Y - initialMouseLocation.Y
            Dim visibleRows As Integer = dgv.DisplayedRowCount(True)
            Dim firstDisplayedRowIndex As Integer = dgv.FirstDisplayedScrollingRowIndex

            If deltaY > 0 And firstDisplayedRowIndex > 0 Then
                If deltaY > lastDeltaY Then
                    dgv.FirstDisplayedScrollingRowIndex = Math.Max(firstDisplayedRowIndex - scrollFactorUp, 0)
                    hasScrolled = True
                End If
            ElseIf deltaY < 0 And firstDisplayedRowIndex + visibleRows < dgv.RowCount Then
                If deltaY < lastDeltaY Then
                    dgv.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedRowIndex + scrollFactorDown, dgv.RowCount - 1)
                    hasScrolled = True
                End If
            End If

            lastDeltaY = deltaY
            initialMouseLocation = e.Location
        End If
    End Sub

End Module

Module CustomButtonModule
    Public Sub SetButtonState(GetButton As Button, ButtonState As Boolean, ButtonValue As String, Optional IsMomentary As Boolean = False)
        Dim ColorAsTrue As Color = Color.FromArgb(0, 192, 0)
        Dim ColorAsFalse As Color = Color.FromArgb(25, 130, 246)

        Dim ColorAsMomentaryTrueToDarken As Decimal = 0.8
        Dim ColorAsMomentaryFalseToDarken As Decimal = 0.8

        Dim ColorAsMomentaryTrue As Color = Color.FromArgb(CInt(ColorAsTrue.R * ColorAsMomentaryTrueToDarken), CInt(ColorAsTrue.G * ColorAsMomentaryTrueToDarken), CInt(ColorAsTrue.B * ColorAsMomentaryTrueToDarken))
        Dim ColorAsMomentaryFalse As Color = Color.FromArgb(CInt(ColorAsFalse.R * ColorAsMomentaryFalseToDarken), CInt(ColorAsFalse.G * ColorAsMomentaryFalseToDarken), CInt(ColorAsFalse.B * ColorAsMomentaryFalseToDarken))

        If ButtonState = True Then
            With GetButton
                If IsMomentary = True Then
                    .BackColor = ColorAsMomentaryTrue
                Else
                    .BackColor = ColorAsTrue
                End If
                .Text = ButtonValue
            End With
        Else
            With GetButton
                If IsMomentary = True Then
                    .BackColor = ColorAsMomentaryFalse
                Else
                    .BackColor = ColorAsFalse
                End If
                .Text = ButtonValue
            End With
        End If
    End Sub
End Module

Namespace LicensingModule
    Module LicensingModule
        ' File Names
        Dim LicFileName As String = "Pixel License.key"
        Dim LicTrialFileName As String = "pxtrlic.tmp"
        Dim LicReqFileName As String = "PixelLicenseRequest.txt"

        ' MessageBox Messages
        Dim LicMsgPathError As String = "PATH Error. Application Will Now Exit."
        Dim LicMsgGenError As String = "Unable To Generate License Request File."
        Dim LicMsgGenerateLRF As String = "Generate License Request File?"
        Dim LicMsgActivateTrial As String = "Activate 30-Day Trial License?"
        Dim LicMsgGenerateLRFSuccess As String = "Generate Success."
        Dim LicMsgDeclined As String = "Application Will Now Exit."
        Dim LicMsgTrialExpired As String = "Trial License Expired!"
        Dim LicMsgTrialExpiring As String = "Trial License Expiring In "
        Dim LicMsgTrialRemain As String = "Trial Remaining: "

        ' License Encryption Keys
        'Dim ENC_key As String = "706978656C6175746F6D6174696F6E20"  ' [pixelautomation ]
        'Dim ENC_IV As String = "706978656C202020"                   ' [pixel   ]

        ' TEMP Path
        'Dim tempPath As String = Environment.GetEnvironmentVariable("TEMP")
        Dim tempPath As String = Environment.GetEnvironmentVariable("LOCALAPPDATA")

        ' File Path
        Dim PathToLicenseFolder As String = $"{Application.StartupPath()}\License"
        Dim PathToLicenseFile As String = $"{Application.StartupPath()}\License\{LicFileName}"
        Dim PathToTrialFile As String = $"{tempPath}\{LicTrialFileName}"
        Dim PathToLicReqFile As String = $"{Application.StartupPath()}\License\{LicReqFileName}"

        ' Trial License
        Dim dtTrialExpiring As New DateTime
        Dim DayCountGiven As Integer = 30
        Dim DayLeftTemp As Integer = 0
        Public WithEvents trialTimer As New Timer()
        Dim trialPromptExit As Boolean = False

        Private Sub trialTimer_Tick(sender As Object, e As EventArgs) Handles trialTimer.Tick
            ' Code to execute on each tick of the timer @ 12.00am
            If trialPromptExit = False Then
                If DateTime.Now.Hour = 0 Then
                    Dim DayRemaining As Integer = (dtTrialExpiring - DateTime.Now).TotalDays
                    Dim vStr As String = ""

                    If DayRemaining < 0 Then
                        DayRemaining = 0
                    ElseIf DayRemaining > 1 Then
                        vStr = "s"
                    End If

                    With FormMain.dsp_LicenseStatus
                        .Text = $"{LicMsgTrialRemain}{DayRemaining} Day{vStr}"
                        .BackColor = SystemColors.Info
                        .Visible = True
                    End With

                    If DayLeftTemp <> DayRemaining Then
                        trialPromptExit = True
                        MsgBox($"{LicMsgTrialExpiring}{DayRemaining} Day{vStr}", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                        MsgBox(LicMsgDeclined, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                        Application.Exit()
                    End If

                    If DayRemaining <= 0 Then
                        trialPromptExit = True
                        MsgBox(LicMsgTrialExpired, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                        MsgBox(LicMsgDeclined, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                        Application.Exit()
                    End If
                End If
            End If
        End Sub

        Public Sub trialTimerStart()
            DayLeftTemp = (dtTrialExpiring - DateTime.Now).TotalDays
            Dim vStr As String = ""

            If DayLeftTemp < 0 Then
                DayLeftTemp = 0
            ElseIf DayLeftTemp > 1 Then
                vStr = "s"
            End If

            With FormMain.dsp_LicenseStatus
                .Text = $"{LicMsgTrialRemain}{DayLeftTemp} Day{vStr}"
                .BackColor = SystemColors.Info
                .Visible = True
            End With

            EventLog.EventLogger.Log("-", $"[License] Trial License Remaining Day Count: {DayLeftTemp}")
            trialTimer.Interval = 30000
            trialTimer.Enabled = True
        End Sub

        Public Function CheckLic() As String
            Dim PathExist As Boolean = False
            Dim LicExist As Boolean = False
            Dim LicValid As Boolean = False
            Dim TrialExist As Boolean = False
            Dim TrialValid As Boolean = False
            Dim TrialExpired As Boolean = False

            ' Check Path Exists
            If Directory.Exists(PathToLicenseFolder) Then
                PathExist = True
            End If

            ' Check License Exists
            If File.Exists(PathToLicenseFile) Then
                LicExist = True
            Else
                EventLog.EventLogger.Log("-", "[License] License Not Found")
            End If

            ' Check Trial License Exists
            If File.Exists(PathToTrialFile) Then
                TrialExist = True
            End If

            ' Generate Path
            If PathExist = False Then
                PathExist = CreateLicPath()
            End If

            ' Recheck Path
            If PathExist Then
                ' Check License Validity
                If LicExist = True Then
                    Try
                        ' Read From Text File
                        Using reader As New StreamReader(PathToLicenseFile)
                            ' Read First Line
                            Dim line As String = reader.ReadLine()

                            ' Decrypt Line
                            Dim lineDecrypted As String = LicDecrypt(line.Trim)

                            ' Parse To Array
                            Dim delimiter As Char = "_"c
                            Dim stringArray() As String = lineDecrypted.Split(delimiter)

                            ' Get Addresses
                            Dim addrList As New List(Of String)
                            For Each addr As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
                                addrList.Add(addr.GetPhysicalAddress.ToString)
                            Next

                            ' Match License Info
                            If stringArray.Length = 2 Then
                                If stringArray(1) = "PropertyOfPixelAutomation" Then
                                    For Each item In addrList
                                        If item = stringArray(0) Then
                                            LicValid = True
                                            DeleteLicTrial()
                                            Return "LICENSED"
                                        End If
                                    Next
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                    End Try
                End If

                ' Continue On Invalid License
                If LicValid = False Then
                    If TrialExist = True Then
                        ' Event Log
                        EventLog.EventLogger.Log("-", "[License] Trial License Found")

                        ' Read From Text File
                        Try
                            Using reader As New StreamReader(PathToTrialFile)
                                ' Read First Line
                                Dim line As String = reader.ReadLine()

                                ' Decrypt Line
                                Dim lineDecrypted As String = LicDecrypt(line.Trim)

                                ' Parse To DateTime & Added Defined DayCountGiven
                                dtTrialExpiring = DateTime.ParseExact(lineDecrypted, "yyyyMMdd", Nothing).AddDays(DayCountGiven)
                            End Using
                        Catch ex As Exception
                        End Try

                        ' Check Trial Activation Expiry
                        If Not DateTime.Now > dtTrialExpiring Then
                            TrialValid = True
                            trialTimerStart()
                            Return "TRIAL"
                        Else
                            TrialExpired = True
                        End If
                    End If

                    ' Prompt To Ask For Generate License Request File / Trial License
                    If TrialValid = False Then
                        If TrialExpired = True Then
                            If Not MsgBox($"{LicMsgTrialExpired} Continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
                                MsgBox(LicMsgDeclined, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                                Application.Exit()
                                Return Nothing
                            End If
                        End If

                        If MsgBox(LicMsgGenerateLRF, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
                            If CreateLicReqFile() = True Then
                                EventLog.EventLogger.Log("-", "[License] License Request File Generated")
                                MsgBox(LicMsgGenerateLRFSuccess, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Information")
                                Process.Start("explorer.exe", PathToLicenseFolder)
                                If TrialExpired = False Then
                                    If MsgBox(LicMsgActivateTrial, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
                                        If CreateLicTrial() = True Then
                                            TrialValid = True
                                            trialTimerStart()
                                            Return "TRIAL"
                                        End If
                                    Else
                                        MsgBox(LicMsgDeclined, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                                        Application.Exit()
                                    End If
                                Else
                                    MsgBox(LicMsgDeclined, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                                    Application.Exit()
                                End If
                            Else
                                MsgBox(LicMsgGenError, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "License - License Request File Error")
                                MsgBox(LicMsgDeclined, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                                Application.Exit()
                            End If
                        Else
                            MsgBox(LicMsgDeclined, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                            Application.Exit()
                        End If
                    End If
                End If
            Else
                MsgBox(LicMsgPathError, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "License - Application PATH Error")
                Application.Exit()
            End If

            ' Prevent Bypass
            If TrialValid = False And LicValid = False Then
                MsgBox("lic info missing", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Information")
                Application.Exit()
            End If

            Return "END"
        End Function

        Public Function CreateLicPath()
            ' Create Path
            Directory.CreateDirectory(PathToLicenseFolder)

            ' Return Path State
            Return Directory.Exists(PathToLicenseFolder)
        End Function

        Public Function CreateLicReqFile()
            Try
                ' Get Addresses
                Dim addrList As New List(Of String)
                For Each addr As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
                    If addr.GetPhysicalAddress.ToString.Length = 12 Then
                        addrList.Add(addr.GetPhysicalAddress.ToString)
                    End If
                Next

                ' Generate License Request String
                Dim LicReqStr As String = ""
                For i As Integer = 0 To addrList.Count
                    ' Get Top 1 Results Only
                    If i > 0 Then
                        Exit For
                    End If

                    ' Concatenate License Request String
                    If i = 0 Then
                        LicReqStr += addrList(i)
                    Else
                        LicReqStr += $";{addrList(i)}"
                    End If
                Next

                ' Encrypt String 
                'Dim LicReqStrEnc As String = LicEncrypt(LicReqStr.Trim)

                ' Write Into File
                Using writer As New StreamWriter(PathToLicReqFile)
                    'writer.WriteLine(LicReqStrEnc)
                    writer.WriteLine(LicReqStr.Trim)
                End Using

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function CreateLicTrial()
            ' Create & Write Text File
            Try
                Using writer As New StreamWriter(PathToTrialFile)
                    ' Get Formatted Curent DateTime
                    Dim FormatDate As String = DateTime.Now.ToString("yyyyMMdd")

                    ' Encrypt Line
                    Dim strEncrypted As String = LicEncrypt(FormatDate.Trim)

                    ' Write Into File
                    writer.WriteLine(strEncrypted)
                End Using
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Sub DeleteLicTrial()
            ' Delete Text File
            File.Delete(PathToTrialFile)
        End Sub

        Public Function LicEncrypt(ByVal plainText As String) As String
            Dim strPassword As String = "yourPassPhrase"
            Dim s As String = "mySaltValue"
            Dim strHashName As String = "SHA1"
            Dim iterations As Integer = 2
            Dim s2 As String = "@1B2c3D4e5F6g7H8"
            Dim num As Integer = 256

            Dim bytes As Byte() = Encoding.ASCII.GetBytes(s2)
            Dim bytes2 As Byte() = Encoding.ASCII.GetBytes(s)
            Dim bytes3 As Byte() = Encoding.UTF8.GetBytes(plainText)

            Dim bytes4 As Byte() = New PasswordDeriveBytes(strPassword, bytes2, strHashName, iterations).GetBytes(num / 8)

            Dim transform As ICryptoTransform = New RijndaelManaged With {
                .Mode = CipherMode.CBC
            }.CreateEncryptor(bytes4, bytes)

            Dim memoryStream As New MemoryStream()
            Dim cryptoStream As New CryptoStream(memoryStream, transform, CryptoStreamMode.Write)

            cryptoStream.Write(bytes3, 0, bytes3.Length)
            cryptoStream.FlushFinalBlock()

            Dim inArray As Byte() = memoryStream.ToArray()

            memoryStream.Close()
            cryptoStream.Close()

            Return Convert.ToBase64String(inArray)
        End Function

        Public Function LicDecrypt(ByVal cipherText As String) As String
            Dim strPassword As String = "yourPassPhrase"
            Dim s As String = "mySaltValue"
            Dim strHashName As String = "SHA1"
            Dim iterations As Integer = 2
            Dim s2 As String = "@1B2c3D4e5F6g7H8"
            Dim num As Integer = 256

            Dim bytes As Byte() = Encoding.ASCII.GetBytes(s2)
            Dim bytes2 As Byte() = Encoding.ASCII.GetBytes(s)
            Dim array As Byte() = Convert.FromBase64String(cipherText)
            Dim bytes3 As Byte() = New PasswordDeriveBytes(strPassword, bytes2, strHashName, iterations).GetBytes(num / 8)

            Dim transform As ICryptoTransform = New RijndaelManaged With {
                .Mode = CipherMode.CBC
            }.CreateDecryptor(bytes3, bytes)

            Dim memoryStream As New MemoryStream(array)
            Dim cryptoStream As New CryptoStream(memoryStream, transform, CryptoStreamMode.Read)

            Dim array2(array.Length - 1) As Byte
            Dim count As Integer = cryptoStream.Read(array2, 0, array2.Length)

            memoryStream.Close()
            cryptoStream.Close()

            Return Encoding.UTF8.GetString(array2, 0, count)
        End Function
    End Module
End Namespace

Namespace EventLog ' EventLog.EventLogger.Log( ,)
    Module EventLogger
        Public Sub Log(user As String, eventmsg As String)
            ' Refresh Event Log Table
            If FormMessageLog.IsSearchState = False Then
                For Each form In My.Application.OpenForms
                    If form Is FormMessageLog Then
                        If form.visible = True Then
                            form.LoadMessageLogTable(False, Nothing, Nothing, Nothing)
                        End If
                    End If
                Next
            End If

            ' Log To SQL
            Dim parameters As New Dictionary(Of String, Object) From {
                {"user_name", user},
                {"event_log", eventmsg}
            }
            SQL.InsertRecord("MessageLog", parameters)
        End Sub
    End Module
End Namespace

Namespace LiveGraph
    Module LiveGraph
        ' Declare Controls
        Dim chartLiveGraph As Chart = FormMain.chart_MainLiveGraph
        Dim cmbxSelection As ComboBox = FormMain.cmbx_GraphSelection

        ' Plotting Timer
        Public WithEvents graphPlottingTimer As New Timer()

        ' Declare Parameter
        'Dim TickRateInMilliseconds As Integer = 50
        Dim dtRunningResult As New DataTable
        Dim dtRunningResultCopy As New DataTable
        Dim dtScaledResult As New DataTable
        'Dim dtLocked As Boolean = False
        'Dim StartTime As DateTime
        'Dim EndTime As DateTime
        'Dim RunDuration As Integer = 0

        Private Sub graphPlottingTimer_Tick(sender As Object, e As EventArgs) Handles graphPlottingTimer.Tick
            'Dim getSecElapsed As Decimal = ((dtRunningResult.Rows.Count + 1) * TickRateInMilliseconds) / 1000
            'Dim getInletPress As Decimal = InletPress
            'Dim getOutletPress As Decimal = OutletPress
            'Dim getDiffPress As Decimal = OutletPress - InletPress
            'Dim getFlowRate As Decimal = FlowRate

            'dtRunningResult.Rows.Add($"{getSecElapsed}", $"{getInletPress}", $"{getOutletPress}", $"{getDiffPress}", $"{getFlowRate}")

            'Dim dtCopy As New DataTable

            'Try
            '    If dataQueue.Count > 0 Then
            '        dtRunningResultCopy.Rows.Clear()
            '        dtRunningResultCopy = dataQueue.Dequeue() 'dtRunningResult.Copy
            '    End If
            'Catch ex As Exception

            'End Try

            dtRunningResultCopy = FormMainModule.dtresult.Copy

            If dtRunningResultCopy.Rows.Count > 0 Then
                ' Calculate Step Size
                'Dim stepSize As Integer = Math.Max(dtRunningResult.Rows.Count \ PublicVariables.ChartPlotMax, 1)
                Dim stepSize As Integer = Math.Max(dtRunningResultCopy.Rows.Count \ 200, 1)

                ' Plot Data With Scaling 
                dtScaledResult.Rows.Clear()
                For i As Integer = 0 To dtRunningResultCopy.Rows.Count - 2 Step stepSize
                    With dtScaledResult
                        .Rows.Add(
                                    $"{dtRunningResultCopy(i)(0)}",
                                    $"{dtRunningResultCopy(i)(1)}",
                                    $"{dtRunningResultCopy(i)(2)}",
                                    $"{dtRunningResultCopy(i)(3)}",
                                    $"{dtRunningResultCopy(i)(4)}",
                                    $"{dtRunningResultCopy(i)(5)}",
                                    $"{dtRunningResultCopy(i)(6)}"
                                )
                    End With
                Next

                'Dim maxDecimal As Decimal
                'Dim minDecimal As Decimal

                'If True Then
                '    For Each row As DataRow In dtRunningResult.Rows
                '        Dim value As String = row.Field(Of String)("diff_pressure")
                '        Dim currentDecimal As Decimal
                '        If Decimal.TryParse(value, currentDecimal) Then
                '            maxDecimal = Math.Max(maxDecimal, currentDecimal)
                '        End If
                '    Next

                '    For Each row As DataRow In dtRunningResult.Rows
                '        Dim value As String = row.Field(Of String)("diff_pressure")
                '        Dim currentDecimal As Decimal
                '        If Decimal.TryParse(value, currentDecimal) Then
                '            minDecimal = Math.Min(minDecimal, currentDecimal)
                '        End If
                '    Next
                'End If

                With chartLiveGraph
                    .Series(0).Points.Clear()
                    '.Series(1).Points.Clear()
                    '.Series(2).Points.Clear()

                    '.ChartAreas(0).AxisY2.Interval = 0.5
                    '.ChartAreas(0).AxisY2.Minimum = Convert.ToInt32(minDecimal) - 1
                    '.ChartAreas(0).AxisY2.Maximum = Convert.ToInt32(maxDecimal) + 0.5
                    Select Case cmbxSelection.SelectedIndex
                        Case 0
                            .Series(0).YValueMembers = "Differential Pressure (kPa)" '"diff_pressure"
                        Case 1
                            .Series(0).YValueMembers = "Flowrate (l/min)" '"flow_rate"
                        Case 2
                            .Series(0).YValueMembers = "Inlet Pressure (kPa)" '"inlet_pressure"
                        Case 3
                            .Series(0).YValueMembers = "Outlet Pressure (kPa)" '"outlet_pressure"
                    End Select

                    .DataSource = Nothing
                    .DataSource = dtScaledResult
                End With

                ' TESTING
                'If dtScaledResult.Rows.Count > 0 Then
                '    FormMain.btn_Debug1.Text = dtScaledResult(dtScaledResult.Rows.Count - 1)("second")
                'End If
            End If
        End Sub

        'Public Sub StartRun(duration As Integer)
        '    ' Initialize DataTable
        '    With dtRunningResult
        '        .Rows.Clear()
        '        .Columns.Clear()
        '        .Columns.Add("second")
        '        .Columns.Add("inlet_pressure")
        '        .Columns.Add("outlet_pressure")
        '        .Columns.Add("diff_pressure")
        '        .Columns.Add("flow_rate")
        '    End With
        '    dtScaledResult.Rows.Clear()
        '    dtScaledResult.Columns.Clear()
        '    dtScaledResult = dtRunningResult.Clone

        '    ' Assign ChartValueMember
        '    chartLiveGraph.Series(0).XValueMember = "second"

        '    ' Set Start/End Time
        '    StartTime = DateTime.Now
        '    EndTime = StartTime.AddSeconds(duration).AddMilliseconds(TickRateInMilliseconds)

        '    ' Set Run Duration
        '    RunDuration = duration

        '    ' Start Timer
        '    Dim TimerEnable = True
        '    Dim TimerInterval = 20 'TickRateInMilliseconds
        '    If TimerEnable = True Then
        '        Dim timerCallback As System.Threading.TimerCallback = AddressOf TimerCallbackMethod
        '        graphRuntimeTimer = New Threading.Timer(timerCallback, Nothing, 0, TimerInterval)

        '        With graphPlottingTimer
        '            .Interval = TimerInterval
        '            .Enabled = TimerEnable
        '        End With
        '    End If
        'End Sub

        Public Sub ChartPlottingTimer(timerEnable As Boolean)
            If timerEnable = True Then
                dtScaledResult.Rows.Clear()
                dtScaledResult.Columns.Clear()
                dtScaledResult = FormMainModule.dtresult.Clone

                ' Assign ChartValueMember
                chartLiveGraph.Series(0).XValueMember = "Sampling Time (s)" '"second"

                ' Start Timer
                With graphPlottingTimer
                    .Interval = 1000
                    .Enabled = timerEnable
                End With
            Else
                graphPlottingTimer.Enabled = False
            End If
        End Sub
    End Module
End Namespace