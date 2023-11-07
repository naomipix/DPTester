Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection

Module PublicVariables
    ' Version
    Public AppVersion As String = "Ver. " & "1.0.0.1"

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
    'Public LotStarted As Boolean = ""
    'Public LotIDNumber As String = ""
    'Public RecipeType As String = ""
    'Public RecipeID As String = ""

    ' Retained Memory - User Login Table Settings
    Public UserLoginHistoryTopCount As Integer = 100

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

    Public Function InsertRecord(tableName As String, parameters As Dictionary(Of String, Object)) As Integer
        Dim connection As SqlConnection = DatabaseModule.GetConnection()
        Dim ReturnValue As Integer = 0

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

                    End If

                    ' Recipe ID
                    If dt(i)("id") = 15 Then

                    End If

                    ' CSV Path To Production Details
                    If dt(i)("id") = 16 Then
                        PublicVariables.CSVDelimiterProductionDetails = dt(i)("retained_value")
                    End If

                    ' CSV Path To Alarm History
                    If dt(i)("id") = 17 Then
                        PublicVariables.CSVDelimiterAlarmHistory = dt(i)("retained_value")
                    End If

                    ' CSV Path To Recipe Details
                    If dt(i)("id") = 18 Then
                        PublicVariables.CSVDelimiterRecipeDetails = dt(i)("retained_value")
                    End If

                    ' CSV Path To Result Summary
                    If dt(i)("id") = 19 Then
                        PublicVariables.CSVDelimiterResultSummary = dt(i)("retained_value")
                    End If

                    ' CSV Path To Result Summary
                    If dt(i)("id") = 20 Then
                        If Not Integer.TryParse(dt(i)("retained_value"), PublicVariables.UserLoginHistoryTopCount) Then
                            PublicVariables.UserLoginHistoryTopCount = 100
                        End If

                        ' Reset To Default of 100 if value returned 0
                        If PublicVariables.UserLoginHistoryTopCount = 0 Then
                            PublicVariables.UserLoginHistoryTopCount = 100
                            RetainedMemory.Update(20, "UserLoginHistoryTopCount", "100")
                        End If
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
    Public Sub SetButtonState(GetButton As Button, ButtonState As Boolean, ButtonValue As String)
        If ButtonState = True Then
            With GetButton
                .BackColor = Color.FromArgb(0, 192, 0)
                .Text = ButtonValue
            End With
        Else
            With GetButton
                .BackColor = Color.FromArgb(25, 130, 246)
                .Text = ButtonValue
            End With
        End If
    End Sub
End Module
