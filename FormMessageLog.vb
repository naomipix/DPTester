Public Class FormMessageLog
    Dim PlaceHolderText As String = " User Category / Event Logged"
    Public IsSearchState As Boolean = False

    Private Sub FormMessageLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Always Maximize
        Me.WindowState = FormWindowState.Maximized

        ' Load Version
        lbl_Version.Text = PublicVariables.AppVersion

        ' Load Form Title
        Me.Text = PublicVariables.ProgramTitle & " - " & "Event Log"
        lbl_Title.Text = PublicVariables.ProgramTitle

        ' Load User Details
        lbl_Username.Text = PublicVariables.LoginUserName
        lbl_Category.Text = PublicVariables.LoginUserCategoryName

        ' DoubleBuffer DataGridView
        Dim dgvArr() As DataGridView = {
            dgv_MessageLog
        }
        For Each dgv As DataGridView In dgvArr
            DoubleBuffer.DoubleBuffered(dgv, True)
        Next

        ' Initialize Defaults
        IsSearchState = False
        With txtbx_Search
            .Text = PlaceHolderText
            .ForeColor = Color.Gray
        End With
        Dim t As Task = LoadMessageLog()
    End Sub

    Private Sub FormMessageLog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear Selection
        Me.Select()

        ' Display Form Control
        panel_FormControl.Visible = True
    End Sub

    Private Sub btn_Home_Click(sender As Object, e As EventArgs) Handles btn_Home.Click
        Me.Close()
    End Sub

    Private Sub txtbx_Search_GotFocus(sender As Object, e As EventArgs) Handles txtbx_Search.GotFocus
        If txtbx_Search.Text = PlaceHolderText Then
            txtbx_Search.Text = ""
            txtbx_Search.ForeColor = SystemColors.WindowText ' Set text color to black when editing
        End If
    End Sub

    Private Sub txtbx_Search_LostFocus(sender As Object, e As EventArgs) Handles txtbx_Search.LostFocus
        If String.IsNullOrWhiteSpace(txtbx_Search.Text) Then
            txtbx_Search.Text = PlaceHolderText
            txtbx_Search.ForeColor = Color.Gray ' Set placeholder text color
        End If
    End Sub

    Private Async Function LoadMessageLog() As Task
        ' Prevent UI Thread Freezing
        Await Task.Delay(20)

        MessageLogFieldReset()
        LoadMessageLogTable(False, Nothing, DateTime.Now.AddDays(-1), DateTime.Now)
    End Function


    ' Reset Search & Filter Fields
    Private Sub MessageLogFieldReset()
        txtbx_Search.Text = PlaceHolderText
        txtbx_Search.ForeColor = Color.Gray ' Set placeholder text color
        For Each dtpicker As DateTimePicker In {dtpicker_EndDate}
            dtpicker.Value = DateTime.Now
        Next
    End Sub

    ' Button Clicked Event [Reset] [Search]
    Private Sub btnMessageLog_Click(sender As Object, e As EventArgs) Handles btn_Reset.Click, btn_Search.Click
        ' Declare Button Clicked
        Dim btnClicked As Button = DirectCast(sender, Button)

        ' Remove Selection Highlight
        lbl_Title.Select()

        ' Button Reset
        If btnClicked Is btn_Reset Then
            MessageLogFieldReset()
            LoadMessageLogTable(False, Nothing, DateTime.Now.AddDays(-1), DateTime.Now)
        End If

        ' Button Search
        If btnClicked Is btn_Search Then
            SearchMessageLog()
        End If
    End Sub

    ' Populate DataGridView From SQL Tables
    Private Async Sub LoadMessageLogTable(containSearch As Boolean, SearchText As String, dtStart As DateTime, dtEnd As DateTime)
        ' Define SQL String
        'The constant 105 is the datastyle which suits the database datatime format, hence it is used
        Dim sqlString As String = $"
        SELECT row_number() OVER (ORDER BY MessageLog.trigger_time DESC) AS no,
            MessageLog.id, 
            MessageLog.user_name, 
            MessageLog.trigger_time, 
            MessageLog.event_log 
        FROM MessageLog WHERE MessageLog.trigger_time Between CONVERT(datetime,'{dtStart}',105) AND CONVERT(datetime,'{dtEnd}',105) 
        ORDER BY MessageLog.trigger_time DESC
        "

        ' Populate Datatable From SQL Query
        Dim dtMessageLog As DataTable = Await Task.Run(Function() SQL.ReadRecords(sqlString))   'SQL.ReadRecords(sqlString)

        ' Search
        If containSearch = True Then
            ' Convert To DataView Table
            Dim dvMessageLog As DataView = dtMessageLog.DefaultView

            ' Declare FilterList Array
            Dim FilterList As New List(Of String)

            ' Check TextBox String
            If SearchText.Length > 0 Then
                ' Filter [user_name] & [event_log]
                If Not SearchText = PlaceHolderText Then
                    FilterList.Add($"user_name LIKE '%{SearchText}%' OR event_log LIKE '%{SearchText}%'")
                End If
            End If

            ' Check DateTime
            If True Then
                'FilterList.Add($"trigger_time>=#{dtStart}#")
                'FilterList.Add($"trigger_time<=#{dtEnd}#")

                FilterList.Add($"Convert(trigger_time, 'System.DateTime')>=#{dtStart.ToString("MM/dd/yyyy 00:00:00")}#")
                FilterList.Add($"Convert(trigger_time, 'System.DateTime')<=#{dtEnd.ToString("MM/dd/yyyy 23:59:59")}#")
            End If

            ' Declare FilterString
            Dim FilterString As String = ""

            ' Concatenate Filter String
            For i As Integer = 0 To FilterList.Count - 1
                If i = 0 Then
                    FilterString += FilterList(i)
                Else
                    FilterString += $" And {FilterList(i)}"
                End If
            Next

            ' Apply Filter To DataView Table
            dvMessageLog.RowFilter = FilterString

            ' Bind To DataGridView DataSource
            dgv_MessageLog.DataSource = dvMessageLog.ToTable
        Else
            ' Bind To DataGridView DataSource
            dgv_MessageLog.DataSource = dtMessageLog

            ' Set dtStart [DateTimePicker] To Earliest Record
            If dtMessageLog.Rows.Count > 0 Then
                dtpicker_StartDate.Value = dtMessageLog(dtMessageLog.Rows.Count - 1)("trigger_time")
            Else
                dtpicker_StartDate.Value = DateTime.Now
            End If
        End If

        With dgv_MessageLog
            ' Set DataGridView Properties
            .BackgroundColor = SystemColors.Window
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ShowCellToolTips = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            ' Hide Unnecessary Columns
            .Columns("id").Visible = False

            ' Rename Columns
            .Columns("no").HeaderCell.Value = "No."
            .Columns("user_name").HeaderCell.Value = "Username"
            .Columns("trigger_time").HeaderCell.Value = "Trigger Time"
            .Columns("event_log").HeaderCell.Value = "Event Logged"

            ' Set Column Properties
            .Columns("user_name").Width = 200
            With .Columns("trigger_time")
                .DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Width = 140
            End With
            .Columns("event_log").Width = 1408
        End With

        ' Clear Selection
        FormMain.dgvClearSelection(dgv_MessageLog)
    End Sub

    ' Remove DataGridView Selection When Not In Focus
    Private Sub dgv_MessageLog_LostFocus(sender As Object, e As EventArgs)
        FormMain.dgvClearSelection(dgv_MessageLog)
    End Sub

    ' Search Message Log
    Private Sub SearchMessageLog()
        ' Load Table With Filters
        LoadMessageLogTable(True, txtbx_Search.Text, dtpicker_StartDate.Value, dtpicker_EndDate.Value)

        ' Set Search State
        IsSearchState = True
    End Sub

    Private Sub picbx_Icon_Click(sender As Object, e As EventArgs) Handles picbx_Icon.Click
        FormPixel.Show()
    End Sub
End Class