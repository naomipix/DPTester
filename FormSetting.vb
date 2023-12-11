Imports System.Globalization
Imports System.IO

Public Class FormSetting
    ' Define IsLoginTableLoaded
    Dim IsLoginTableLoaded As Boolean = False

    ' Define Button Value Properties
    Dim btnScannerBypassValueTrue As String = "OFF"
    Dim btnScannerBypassValueFalse As String = "ON"

    Dim btnAutoDeleteEnabledValueTrue As String = "OFF"
    Dim btnAutoDeleteEnabledValueFalse As String = "ON"

    Dim btnSQLAutoBackupEnabledValueTrue As String = "OFF"
    Dim btnSQLAutoBackupEnabledValueFalse As String = "ON"

    ' Define Label Array
    Public lblArray(18) As Label
    Public dtbuyoffmessage As New DataTable
    ' Scanner ComboBox Initialize State
    Dim ScannerInitialized As Boolean = False

    Private Sub FormSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Always Maximize
        Me.WindowState = FormWindowState.Maximized

        ' Load Version
        lbl_Version.Text = PublicVariables.AppVersion

        ' Load Form Title
        Me.Text = PublicVariables.ProgramTitle & " - " & "Settings"
        lbl_Title.Text = PublicVariables.ProgramTitle

        ' Load User Details
        lbl_Username.Text = PublicVariables.LoginUserName
        lbl_Category.Text = PublicVariables.LoginUserCategoryName

        ' DoubleBuffer DataGridView
        Dim dgvArr() As DataGridView = {
            DataGridView1,
            dgv_MessageLog,
            dgv_DispUserCategory,
            dgv_PermUserCategory
        }
        For Each dgv As DataGridView In dgvArr
            DoubleBuffer.DoubleBuffered(dgv, True)
        Next

        dtbuyoffmessage = New DataTable
        dtbuyoffmessage.Columns.Add("id")
        dtbuyoffmessage.Columns.Add("no")
        dtbuyoffmessage.Columns.Add("user_name")
        dtbuyoffmessage.Columns.Add("trigger_time")
        dtbuyoffmessage.Columns.Add("event_log")




        ' Hide dgv_LoginTable
        DataGridView1.Visible = False

        ' Clear TabPages
        For Each tabpg As TabPage In tabctrl_Settings.TabPages
            tabctrl_Settings.TabPages.Remove(tabpg)
        Next

        ' Repopulate TabPages
        If True Then
            ' Repopulate TabPages
            tabctrl_Settings.TabPages.Add(tabpg_Settings)
            tabctrl_Settings.TabPages.Add(tabpg_ToolCounter)
            tabctrl_Settings.TabPages.Add(tabpg_BuyOff)

            ' Check IsUserDeveloper
            'tabctrl_Settings.TabPages.Add(tabpg_Developer)
            If PublicVariables.LoggedInIsDeveloper = True Then
                tabctrl_Settings.TabPages.Add(tabpg_Developer)
            End If
        End If

        ' Show First TabPage & Load Settings
        If tabctrl_Settings.TabCount > 0 Then
            tabctrl_Settings.SelectedIndex = 0
            LoadSettings()
        End If
    End Sub

    Private Sub FormSetting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear Selection
        Me.Select()

        ' Display Form Control
        panel_FormControl.Visible = True

        ' Show dgv_LoginTable
        If IsLoginTableLoaded = True Then
            DataGridView1.Visible = True
            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub btn_Home_Click(sender As Object, e As EventArgs) Handles btn_Home.Click
        Me.Close()
    End Sub

    Private Sub tabctrl_Settings_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabctrl_Settings.SelectedIndexChanged
        ' Settings Tab
        If tabctrl_Settings.SelectedTab Is tabpg_Settings Then
            LoadSettings()
        End If

        ' Tool Counter Tab


        ' Buy Off / Dry Run Tab
        If tabctrl_Settings.SelectedTab Is tabpg_BuyOff Then
            LoadBuyoff()
        End If

        ' Developer Tab
        If tabctrl_Settings.SelectedTab Is tabpg_Developer Then
            LoadDeveloper()
        End If
    End Sub

#Region "Main Settings"
    Private Sub LoadSettings()
        ' Scanner Settings
        If True Then
            ' Scanner Type
            If PublicVariables.ScannerType = "USB Scanner" Then
                With cmbx_ScannerType
                    If .Items.Count > 1 Then
                        .SelectedIndex = 1
                    End If
                End With
            Else
                With cmbx_ScannerType
                    If .Items.Count > 0 Then
                        .SelectedIndex = 0
                    End If
                End With
            End If

            ' Set Scanner Initialized State
            ScannerInitialized = True

            ' Scanner Bypass
            If PublicVariables.ScannerBypass = True Then
                SetButtonState(Button8, PublicVariables.ScannerBypass, btnScannerBypassValueTrue)
            Else
                SetButtonState(Button8, PublicVariables.ScannerBypass, btnScannerBypassValueFalse)
            End If
        End If

        ' Auto Delete Settings
        If True Then
            ' Auto Delete Enabled
            If PublicVariables.AutoDeleteEnabled Then
                SetButtonState(Button9, PublicVariables.AutoDeleteEnabled, btnAutoDeleteEnabledValueTrue)
            Else
                SetButtonState(Button9, PublicVariables.AutoDeleteEnabled, btnAutoDeleteEnabledValueFalse)
            End If

            If PublicVariables.AutoDeleteDayAfter > 0 Then
                TextBox6.Text = PublicVariables.AutoDeleteDayAfter
            Else
                TextBox6.Text = 365
            End If
        End If

        ' CSV Settings
        If True Then
            TextBox2.Text = PublicVariables.CSVPathToProductionDetails
            TextBox3.Text = PublicVariables.CSVPathToAlarmHistory
            TextBox4.Text = PublicVariables.CSVPathToRecipeDetails
            TextBox5.Text = PublicVariables.CSVPathToResultSummary
            TextBox7.Text = PublicVariables.CSVDelimiterProductionDetails
            TextBox8.Text = PublicVariables.CSVDelimiterAlarmHistory
            TextBox9.Text = PublicVariables.CSVDelimiterRecipeDetails
            TextBox10.Text = PublicVariables.CSVDelimiterResultSummary
        End If

        ' SQL Autobackup Settings
        If True Then
            ' Auto Backup Enabled
            If PublicVariables.AutoBackupSQLEnabled Then
                SetButtonState(Button11, PublicVariables.AutoBackupSQLEnabled, btnSQLAutoBackupEnabledValueTrue)
            Else
                SetButtonState(Button11, PublicVariables.AutoBackupSQLEnabled, btnSQLAutoBackupEnabledValueFalse)
            End If
            txtbx_BackupPath.Text = PublicVariables.AutoBackupSQLPath
            If PublicVariables.AutoBackupSQLAtHour >= 0 And PublicVariables.AutoBackupSQLAtHour <= 23 Then
                With ComboBox2
                    If .Items.Count > PublicVariables.AutoBackupSQLAtHour Then
                        .SelectedIndex = PublicVariables.AutoBackupSQLAtHour
                    End If
                End With
            Else
                With ComboBox2
                    If .Items.Count > 0 Then
                        .SelectedIndex = 0
                    End If
                End With
            End If
        End If

        ' Login Table
        If IsLoginTableLoaded = False Then
            LoadLoginTable()
        End If
    End Sub

    Private Sub btn_ScannerBypass_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ' Declare Button Clicked
        Dim btnClicked As Button = DirectCast(sender, Button)

        ' Define Button State
        Dim btnState As Boolean = False

        If btnClicked.Text = btnScannerBypassValueFalse Then
            btnState = True
        Else
            btnState = False
        End If

        ' Execute Action
        If btnState = False Then
            SetButtonState(btnClicked, btnState, btnScannerBypassValueFalse)
            PublicVariables.ScannerBypass = btnState
            RetainedMemory.Update(3, "ScannerBypass", "0")
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", "[Settings] Scanner Settings - Scanner Bypass (OFF)")
        Else
            SetButtonState(btnClicked, btnState, btnScannerBypassValueTrue)
            PublicVariables.ScannerBypass = btnState
            RetainedMemory.Update(3, "ScannerBypass", "1")
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", "[Settings] Scanner Settings - Scanner Bypass (ON)")
        End If

        ' Clear Selection
        lbl_Title.Select()
    End Sub

    Private Sub cmbx_ScannerType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_ScannerType.SelectedIndexChanged
        If cmbx_ScannerType.Items.Count > 0 Then
            If cmbx_ScannerType.SelectedIndex = 0 Then
                PublicVariables.ScannerType = CStr(cmbx_ScannerType.SelectedItem)
                RetainedMemory.Update(2, "ScannerType", CStr(cmbx_ScannerType.SelectedItem))
            End If
            If cmbx_ScannerType.SelectedIndex = 1 Then
                PublicVariables.ScannerType = CStr(cmbx_ScannerType.SelectedItem)
                RetainedMemory.Update(2, "ScannerType", CStr(cmbx_ScannerType.SelectedItem))
            End If
            If ScannerInitialized = True Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] Scanner Settings - Scanner Type ({CStr(cmbx_ScannerType.SelectedItem)})")
            End If
        End If
    End Sub

    Private Sub btn_AutoDeleteEnabled_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ' Declare Button Clicked
        Dim btnClicked As Button = DirectCast(sender, Button)

        ' Define Button State
        Dim btnState As Boolean = False

        If btnClicked.Text = btnAutoDeleteEnabledValueFalse Then
            btnState = True
        Else
            btnState = False
        End If

        ' Define Warning Messages
        Dim MsgBoxWarnStr1 As String = $"Are you sure you want to enable the Auto-Delete feature? This will result in the permanent removal of records older than {PublicVariables.AutoDeleteDayAfter} days from the database.{vbCrLf}** Only Production History will be removed."
        Dim MsgBoxWarnStr2 As String = $"The auto-delete will execute in 60 seconds."

        ' Execute Action
        If btnState = False Then
            SetButtonState(btnClicked, btnState, btnAutoDeleteEnabledValueFalse)
            PublicVariables.AutoDeleteEnabled = btnState
            SQLSetAutoDeleteMode(btnState)
            RetainedMemory.Update(6, "AutoDeleteEnabled", "0")
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] Historical Auto Delete - Auto Delete (OFF)")
        Else
            If MsgBox(MsgBoxWarnStr1, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes Then
                SetButtonState(btnClicked, btnState, btnAutoDeleteEnabledValueTrue)
                PublicVariables.AutoDeleteEnabled = btnState
                RetainedMemory.Update(6, "AutoDeleteEnabled", "1")
                MsgBox(MsgBoxWarnStr2, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Information")
                SQLSetAutoDeleteMode(btnState)
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] Historical Auto Delete - Auto Delete (ON)")
            End If
        End If

        ' Clear Selection
        lbl_Title.Select()
    End Sub

    Private Sub txtbx_AutoDeleteDayAfter_Validating(sender As Object, e As EventArgs) Handles TextBox6.Validating
        Dim txtbx As TextBox = TextBox6

        If txtbx.Text.Trim.Length < 1 Then
            txtbx.Text = PublicVariables.AutoDeleteDayAfter
        End If

        If Integer.TryParse(txtbx.Text.Trim, Nothing) = False Then
            txtbx.Text = PublicVariables.AutoDeleteDayAfter
        End If
    End Sub

    Private Sub txtbx_AutoDeleteDayAfter_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then
            Me.ActiveControl = Nothing
        End If
    End Sub

    Private Sub txtbx_AutoDeleteDayAfter_Validated(sender As Object, e As EventArgs) Handles TextBox6.Validated
        Dim DayInStr As String = TextBox6.Text.Trim
        Dim DayInStrOld As String = PublicVariables.AutoDeleteDayAfter

        PublicVariables.AutoDeleteDayAfter = DayInStr
        RetainedMemory.Update(7, "AutoDeleteDayAfter", DayInStr)
        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] Historical Auto Delete - Delete After (Day) set to {DayInStr} from {DayInStrOld}")
    End Sub

    Private Async Sub LoadLoginTable()
        ' Prevent UI Thread Freezing
        Await Task.Delay(20)

        ' Define SQL String
        Dim sqlString As String = $"
        SELECT TOP {PublicVariables.UserLoginHistoryTopCount} 
            row_number() OVER (ORDER BY date_created DESC) AS no, 
            id, 
            user_name, 
            user_category, 
            date_created 
        FROM UserLogin 
        ORDER BY date_created DESC
        "

        ' Populate Datatable From SQL Query
        Dim dtLoginTable As DataTable = Await Task.Run(Function() SQL.ReadRecords(sqlString))

        ' Bind To DataGridView DataSource
        DataGridView1.DataSource = dtLoginTable

        ' Prevent UI Thread Freezing
        Await Task.Delay(80)

        With DataGridView1
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
            .Columns("user_category").HeaderCell.Value = "User Category"
            .Columns("date_created").HeaderCell.Value = "Timestamp"

            ' Set Column Properties
            .Columns("no").Width = 80
            .Columns("user_name").Width = 160
            .Columns("user_category").Width = 130

            '.Columns("no").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '.Columns("user_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '.Columns("user_category").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '.Columns("date_created").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            With .Columns("date_created")
                .DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Width = 140
            End With

            ' Clear Selection
            FormMain.dgvClearSelection(DataGridView1)
        End With

        ' Set IsLoginTableLoaded State To True
        IsLoginTableLoaded = True
        DataGridView1.Visible = True
    End Sub

    Private Sub btn_PathSelection_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button10.Click
        ' Declare Button Click
        Dim btnClick As Button = DirectCast(sender, Button)

        ' Define Button & TextBox Array
        Dim btnArray As Button() = {Button4, Button5, Button6, Button7, Button10}
        Dim txtbxArray As TextBox() = {TextBox2, TextBox3, TextBox4, TextBox5, txtbx_BackupPath}

        ' Define FolderBrowserDialog
        Dim folderBrowser As New FolderBrowserDialog()

        ' Set Startup Path
        For i As Integer = 0 To btnArray.Length - 1
            If btnArray(i) Is btnClick Then
                folderBrowser.SelectedPath = txtbxArray(i).Text
            End If
        Next

        ' Show Dialog
        SendKeys.Send("{TAB}{TAB}{RIGHT}")
        If folderBrowser.ShowDialog() = DialogResult.OK Then
            Dim folderPath As String = folderBrowser.SelectedPath

            ' Ensure PATH ends with "\"
            If Not folderPath.EndsWith("\") Then
                folderPath = Path.Combine(folderPath, " ").Trim
            End If

            ' Show In TextBox
            For i As Integer = 0 To btnArray.Length - 1
                If btnArray(i) Is btnClick Then
                    txtbxArray(i).Text = folderPath
                End If
            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Update CSV Folder PATH & Delimiter?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "Question") = MsgBoxResult.Yes Then
            Dim directoryExists As Boolean = True
            Dim directoryInvalid As String = ""
            Dim txtbxInvalid As New TextBox

            Dim txtbxArr As TextBox() = {
                TextBox2,
                TextBox3,
                TextBox4,
                TextBox5,
                         _
                TextBox7,
                TextBox8,
                TextBox9,
                TextBox10
            }

            For Each txtbx As TextBox In txtbxArr
                If (txtbx Is TextBox2) Or (txtbx Is TextBox3) Or (txtbx Is TextBox4) Or (txtbx Is TextBox5) Then
                    If Not Directory.Exists(txtbx.Text) Then
                        directoryExists = False
                        directoryInvalid = txtbx.Text
                        txtbxInvalid = txtbx
                        Exit For
                    End If
                End If
            Next

            If directoryExists = True Then
                For Each txtbx As TextBox In txtbxArr
                    ' CSV Paths
                    If txtbx Is TextBox2 Then '8
                        Dim tempValue As String = PublicVariables.CSVPathToProductionDetails
                        RetainedMemory.Update(8, "CSVPathToProductionDetails", txtbx.Text)
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] CSV Settings - Production Details PATH set to {txtbx.Text} from {tempValue}")
                    End If
                    If txtbx Is TextBox3 Then '9
                        Dim tempValue As String = PublicVariables.CSVPathToAlarmHistory
                        RetainedMemory.Update(9, "CSVPathToAlarmHistory", txtbx.Text)
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] CSV Settings - Alarm History PATH set to {txtbx.Text} from {tempValue}")
                    End If
                    If txtbx Is TextBox4 Then '10
                        Dim tempValue As String = PublicVariables.CSVPathToRecipeDetails
                        RetainedMemory.Update(10, "CSVPathToRecipeDetails", txtbx.Text)
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] CSV Settings - Recipe Details PATH set to {txtbx.Text} from {tempValue}")
                    End If
                    If txtbx Is TextBox5 Then '11
                        Dim tempValue As String = PublicVariables.CSVPathToResultSummary
                        RetainedMemory.Update(11, "CSVPathToResultSummary", txtbx.Text)
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] CSV Settings - Result Summary PATH set to {txtbx.Text} from {tempValue}")
                    End If

                    ' CSV Delimiters
                    If txtbx Is TextBox7 Then '16
                        Dim tempValue As String = PublicVariables.CSVDelimiterProductionDetails
                        RetainedMemory.Update(16, "CSVDelimiterProductionDetails", txtbx.Text)
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] CSV Settings - Production Details Delimiter set to {txtbx.Text} from {tempValue}")
                    End If
                    If txtbx Is TextBox8 Then '17
                        Dim tempValue As String = PublicVariables.CSVDelimiterAlarmHistory
                        RetainedMemory.Update(17, "CSVDelimiterAlarmHistory", txtbx.Text)
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] CSV Settings - Alarm History Delimiter set to {txtbx.Text} from {tempValue}")
                    End If
                    If txtbx Is TextBox9 Then '18
                        Dim tempValue As String = PublicVariables.CSVDelimiterRecipeDetails
                        RetainedMemory.Update(18, "CSVDelimiterRecipeDetails", txtbx.Text)
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] CSV Settings - Recipe Details Delimiter set to {txtbx.Text} from {tempValue}")
                    End If
                    If txtbx Is TextBox10 Then '19
                        Dim tempValue As String = PublicVariables.CSVDelimiterResultSummary
                        RetainedMemory.Update(19, "CSVDelimiterResultSummary", txtbx.Text)
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] CSV Settings - Result Summary Delimiter set to {txtbx.Text} from {tempValue}")
                    End If

                Next
                MsgBox("Changes Updated Sucessfully.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Else
                MsgBox($"Invalid Path ""{directoryInvalid}""", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            End If
        End If
    End Sub

    Private Sub btn_SQLAutoBackupEnabled_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ' Declare Button Clicked
        Dim btnClicked As Button = DirectCast(sender, Button)

        ' Define Button State
        Dim btnState As Boolean = False

        If btnClicked.Text = btnSQLAutoBackupEnabledValueFalse Then
            btnState = True
        Else
            btnState = False
        End If

        ' Execute Action
        If btnState = False Then
            SetButtonState(btnClicked, btnState, btnSQLAutoBackupEnabledValueFalse)
            PublicVariables.AutoBackupSQLEnabled = btnState
            SQLSetAutoBackupMode(btnState)
            RetainedMemory.Update(21, "AutoBackupSQLEnabled", "0")
        Else
            SetButtonState(btnClicked, btnState, btnSQLAutoBackupEnabledValueTrue)
            PublicVariables.AutoBackupSQLEnabled = btnState
            SQLSetAutoBackupMode(btnState)
            RetainedMemory.Update(21, "AutoBackupSQLEnabled", "1")
        End If

        ' Clear Selection
        lbl_Title.Select()
    End Sub

    Private Sub btn_ForceBackup_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If MsgBox("Are you sure to perform a Forced Backup?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "Question") = MsgBoxResult.Yes Then
            If SQL.SQLAutoBackup().Length > 0 Then
                MsgBox($"Backup performed successfully at ""{SQL.SQLAutoBackup()}""", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Else
                MsgBox("Backup Unsuccessful", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
            End If
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Items.Count > 0 Then
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If MsgBox("Update SQL Backup PATH & Hour?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "Question") = MsgBoxResult.Yes Then
            Dim directoryExists As Boolean = Directory.Exists(txtbx_BackupPath.Text)

            If directoryExists = True Then
                RetainedMemory.Update(23, "AutoBackupSQLPath", txtbx_BackupPath.Text)

                PublicVariables.AutoBackupSQLAtHour = CInt(CStr(ComboBox2.SelectedItem))
                RetainedMemory.Update(22, "AutoBackupSQLAtHour", CStr(ComboBox2.SelectedItem))

                MsgBox("Changes Updated Sucessfully.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Else
                MsgBox($"Invalid Path ""{txtbx_BackupPath.Text}""", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            End If
        End If
    End Sub

#End Region

#Region "Tool Counter"

    Private Sub btn_ResetValves_Click(sender As Object, e As EventArgs) Handles _
        btn_ResetValve1.Click, btn_ResetValve2.Click, btn_ResetValve3.Click, btn_ResetValve4.Click, btn_ResetValve5.Click, btn_ResetValve6.Click,
        btn_ResetValve7.Click, btn_ResetValve8.Click, btn_ResetValve9.Click, btn_ResetValve10.Click, btn_ResetValve11.Click, btn_ResetValve12.Click,
        btn_ResetValve13.Click, btn_ResetValve14.Click, btn_ResetValve15.Click, btn_ResetValve16.Click, btn_ResetValve17.Click, btn_ResetValve18.Click,
        btn_ResetValve19.Click ', btn_ResetValve20.Click, btn_ResetValve21.Click

        ' Declare Button Clicked
        Dim btnClicked As Button = DirectCast(sender, Button)

        ' Define Button Array
        Dim btnArray As Button() = {
            btn_ResetValve1, btn_ResetValve2, btn_ResetValve3, btn_ResetValve4, btn_ResetValve5, btn_ResetValve6, btn_ResetValve7, btn_ResetValve8,
            btn_ResetValve9, btn_ResetValve10, btn_ResetValve11, btn_ResetValve12, btn_ResetValve13, btn_ResetValve14, btn_ResetValve15, btn_ResetValve16,
            btn_ResetValve17, btn_ResetValve18, btn_ResetValve19', btn_ResetValve20, btn_ResetValve21
        }

        ' Define Label Array
        Dim lblArray As Label() = {
            lbl_Valve1, lbl_Valve2, lbl_Valve3, lbl_Valve4, lbl_Valve5, lbl_Valve6, lbl_Valve7, lbl_Valve8,
            lbl_Valve9, lbl_Valve10, lbl_Valve11, lbl_Valve12, lbl_Valve13, lbl_Valve14, lbl_Valve15, lbl_Valve16,
            lbl_Valve17, lbl_Valve18, lbl_Valve19', lbl_Valve20, lbl_Valve21
        }

        For i As Integer = 0 To btnArray.Length - 1
            If btnClicked Is btnArray(i) Then
                If MsgBox($"Are you sure to Reset Tool Counter for [Valve-{i + 1}]?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "Question") = MsgBoxResult.Yes Then
                    Dim ToolCouterTemp As String = lblArray(i).Text
                    If i < 16 Then
                        ToolCounterreset(0)(i) = True
                    Else
                        ToolCounterreset(1)(i - 16) = True
                    End If
                    MsgBox($"[Valve-{i + 1}] Tool Counter Resetted", MsgBoxStyle.OkOnly, "Information")
                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] Tool Counter - Valve-{i + 1} Counter Reset | Last Counter : {ToolCouterTemp}")
                End If
            End If
        Next
    End Sub




#End Region

#Region "Buyoff Run"
    'Private WithEvents bindingSource As New BindingSource()

    Private Sub LoadBuyoff()
        'dgv_MessageLog.DataSource = bindingSource
        LoadMessageLog()
    End Sub

    Private Async Sub LoadMessageLog()
        ' Get StartTime From Label [lbl_StartTime.Text]
        Dim StartTime As DateTime = DateTime.Now

        If timer_Buyoff.Enabled = True Then
            StartTime = DateTime.ParseExact(lbl_StartTime.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
        End If

        ' Special Filter
        Dim FilterStr As String = ""

        ' Check Buyoff State
        'If timer_Buyoff.Enabled = False Then
        '    FilterStr = "WHERE 1 = 0"
        'Else
        '    FilterStr = $"WHERE MessageLog.trigger_time >=' {StartTime.ToString("yyyy-MM-dd HH:mm:ss:000")}'" ' YYYY-MM-DDTHH:mm:ss
        'End If

        '' Define SQL String
        'Dim sqlString As String = $"
        'SELECT row_number() OVER (ORDER BY MessageLog.trigger_time DESC) AS no,
        '    MessageLog.id, 
        '    MessageLog.user_name, 
        '    MessageLog.trigger_time, 
        '    MessageLog.event_log 
        'FROM MessageLog 
        '{FilterStr} 
        'ORDER BY MessageLog.trigger_time DESC
        '"

        '' Populate Datatable From SQL Query
        'Dim dtMessageLog As DataTable = SQL.ReadRecords(sqlString)   'SQL.ReadRecords(sqlString)

        '' Bind To DataGridView DataSource
        'dgv_MessageLog.DataSource = dtMessageLog

        ' Bind To DataGridView DataSource
        dgv_MessageLog.DataSource = dtbuyoffmessage


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
            .Columns("event_log").Width = 1224
        End With

        ' Clear Selection
        FormMain.dgvClearSelection(dgv_MessageLog)
    End Sub

    Private Sub chkbx_Buyoff_CheckedChanged(sender As Object, e As EventArgs) Handles chkbx_DryRun.CheckedChanged, chkbx_BuyOffRun.CheckedChanged
        ' Declare CheckBox Checked Changed
        Dim chkbxCheckedChanged As CheckBox = DirectCast(sender, CheckBox)

        ' CheckBox CheckState Changed
        If chkbxCheckedChanged.Checked = False Then
            chkbxCheckedChanged.Text = "Enable"
        Else
            chkbxCheckedChanged.Text = "Disable"
        End If

        ' Update RetainedMemoryTable
        If True Then
            If chkbxCheckedChanged Is chkbx_DryRun Then
                If chkbxCheckedChanged.Checked = False Then
                    chkbx_BuyOffRun.Enabled = True
                    RetainedMemory.Update(4, "DryRunEnabled", "0")
                Else
                    chkbx_BuyOffRun.Enabled = False
                    RetainedMemory.Update(4, "DryRunEnabled", "1")
                End If
            End If
            If chkbxCheckedChanged Is chkbx_BuyOffRun Then
                If chkbxCheckedChanged.Checked = False Then
                    chkbx_DryRun.Enabled = True
                    RetainedMemory.Update(5, "BuyOffEnabled", "0")
                Else
                    chkbx_DryRun.Enabled = False
                    RetainedMemory.Update(5, "BuyOffEnabled", "1")
                End If
            End If
        End If
    End Sub

    Private Sub btn_StartStop_Click(sender As Object, e As EventArgs) Handles btn_Start.Click, btn_Stop.Click
        ' Declare Button Click
        Dim btn As Button = DirectCast(sender, Button)

        ' Remove Selection Highlight
        lbl_Title.Select()

        ' Button Start
        If btn Is btn_Start Then
            ' Check State
            If Not (chkbx_DryRun.Checked = True And chkbx_BuyOffRun.Checked = True) Then
                If chkbx_DryRun.Checked = True OrElse chkbx_BuyOffRun.Checked = True Then
                    ' Set Start Time
                    lbl_StartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                    ' Format Label [lbl_Duration.Text]
                    lbl_Duration.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", 0, 0, 0)

                    ' Clear End Time
                    lbl_EndTime.Text = "-N/A-"

                    ' Disable CheckBox Buttons
                    For Each chkbx As CheckBox In {chkbx_DryRun, chkbx_BuyOffRun}
                        chkbx.Enabled = False
                    Next

                    ' Start Timer
                    timer_Buyoff.Start()

                    ' Event Log
                    If chkbx_DryRun.Checked = True Then
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] Dry-Run/Buy-Off Run - Dry-Run Started")
                    Else
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] Dry-Run/Buy-Off Run - Buy-Off Run Started")
                    End If
                End If
            Else
                ' Set CheckBoxes To Unchecked
                For Each chkbx As CheckBox In {chkbx_DryRun, chkbx_BuyOffRun}
                    chkbx.Checked = False
                Next
            End If
        End If

        ' Button Stop
        If btn Is btn_Stop Then
            ' Check If Timer Is Running
            If timer_Buyoff.Enabled = True Then
                ' Set End Time
                lbl_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                ' Enable CheckBox Buttons
                For Each chkbx As CheckBox In {chkbx_DryRun, chkbx_BuyOffRun}
                    chkbx.Enabled = True
                Next

                ' End Timer
                timer_Buyoff.Stop()

                ' Event Log
                If chkbx_DryRun.Checked = True Then
                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] Dry-Run/Buy-Off Run - Dry-Run Stopped | Duration : {lbl_Duration.Text} | Cycles : {lbl_CycleCount.Text}")
                Else
                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Settings] Dry-Run/Buy-Off Run - Buy-Off Run Stopped | Duration : {lbl_Duration.Text} | Cycles : {lbl_CycleCount.Text}")
                End If
            End If
        End If
    End Sub

    Private Sub timer_Buyoff_Tick(sender As Object, e As EventArgs) Handles timer_Buyoff.Tick
        ' Get StartTime From Label [lbl_StartTime.Text]
        Dim StartTime As DateTime = DateTime.ParseExact(lbl_StartTime.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)

        ' Get Current DateTime
        Dim CurrentTime As DateTime = DateTime.Now

        ' Calculate Time Difference
        Dim TimeDifference As TimeSpan = CurrentTime.Subtract(StartTime)

        ' Format Label [lbl_Duration.Text]
        lbl_Duration.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", TimeDifference.Hours, TimeDifference.Minutes, TimeDifference.Seconds)
    End Sub
#End Region

#Region "Developer"
    Private Sub LoadDeveloper()
        InitDevDefault()

        'LoadUserPermissionDefaults()
        LoadUserCategoryTable()
    End Sub

    Private Sub InitDevDefault()
        ' Reinitialize Defaults
        TextBox1.Text = ""
        With ComboBox1
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With

        ' Clear All Selection [CheckBox]
        For Each chkbx As CheckBox In {chkbx_Registration, chkbx_Recipe, chkbx_Calibrate, chkbx_Settings, chkbx_MessageLog, chkbx_ResultSummary, chkbx_ResultGraph}
            chkbx.Checked = False
        Next

        ' Clear All Selection [CheckedListBox]
        For Each chklstbx As CheckedListBox In {chklstbx_MainMenu, chklstbx_Registration, chklstbx_Recipe, chklstbx_Calibrate, chklstbx_Settings, chklstbx_MessageLog, chklstbx_ResultSummary, chklstbx_ResultGraph}
            For i As Integer = 0 To chklstbx.Items.Count - 1
                chklstbx.SetItemChecked(i, False)
            Next
        Next
    End Sub

    Private Sub LoadUserPermissionDefaults()
        ' Define CheckBox & CheckedListBox Arrays
        Dim chkbxArr As CheckBox() = {
            chkbx_MainMenu, chkbx_Registration, chkbx_Recipe, chkbx_Calibrate, chkbx_Settings, chkbx_MessageLog, chkbx_ResultSummary, chkbx_ResultGraph
        }
        Dim chklstbxArr As CheckedListBox() = {
            chklstbx_MainMenu, chklstbx_Registration, chklstbx_Recipe, chklstbx_Calibrate, chklstbx_Settings, chklstbx_MessageLog, chklstbx_ResultSummary, chklstbx_ResultGraph
        }

        ' CheckBox Default Checked Headers
        If True Then
            ' Define CheckBoxes To Checked
            Dim chkbxToCheckedArr As CheckBox() = {
                chkbx_MainMenu,
                chkbx_Recipe,
                chkbx_Calibrate
            }

            ' Enable / Disable CheckedListBox
            For i As Integer = 0 To chkbxArr.Length - 1
                If chkbxToCheckedArr.Contains(chkbxArr(i)) Then
                    ' Action Performed
                    chkbxArr(i).Checked = True
                End If
            Next
        End If

        ' CheckedListBox Default Checked Items
        For i As Integer = 0 To chklstbxArr.Length - 1
            If chklstbxArr(i) Is chklstbx_MainMenu Then
                For item As Integer = 0 To chklstbxArr(i).Items.Count - 1
                    If chklstbxArr(i).Items(item) = "Main" Then
                        chklstbxArr(i).SetItemChecked(item, True)
                    End If
                    If chklstbxArr(i).Items(item) = "Production Details" Then
                        chklstbxArr(i).SetItemChecked(item, True)
                    End If
                    If chklstbxArr(i).Items(item) = "Status" Then
                        chklstbxArr(i).SetItemChecked(item, True)
                    End If
                    If chklstbxArr(i).Items(item) = "Manual Control" Then
                        chklstbxArr(i).SetItemChecked(item, True)
                    End If
                    If chklstbxArr(i).Items(item) = "Alarm" Then
                        chklstbxArr(i).SetItemChecked(item, True)
                    End If
                Next
            End If

            If chklstbxArr(i) Is chklstbx_Registration Then
                For item As Integer = 0 To chklstbxArr(i).Items.Count - 1
                    If chklstbxArr(i).Items(item) = "User Registration" Then
                        chklstbxArr(i).SetItemChecked(item, False)
                    End If
                    If chklstbxArr(i).Items(item) = "User Deletion" Then
                        chklstbxArr(i).SetItemChecked(item, False)
                    End If
                Next
            End If

            If chklstbxArr(i) Is chklstbx_Recipe Then
                For item As Integer = 0 To chklstbxArr(i).Items.Count - 1
                    If chklstbxArr(i).Items(item) = "Recipe Details" Then
                        chklstbxArr(i).SetItemChecked(item, True)
                    End If
                    If chklstbxArr(i).Items(item) = "Recipe Edit" Then
                        chklstbxArr(i).SetItemChecked(item, False)
                    End If
                    If chklstbxArr(i).Items(item) = "Recipe Create" Then
                        chklstbxArr(i).SetItemChecked(item, False)
                    End If
                    If chklstbxArr(i).Items(item) = "Recipe Delete" Then
                        chklstbxArr(i).SetItemChecked(item, False)
                    End If
                Next
            End If

            'If chklstbxArr(i) Is chklstbx_Calibrate Then
            '    For item As Integer = 0 To chklstbxArr(i).Items.Count - 1

            '    Next
            'End If

            If chklstbxArr(i) Is chklstbx_Settings Then
                For item As Integer = 0 To chklstbxArr(i).Items.Count - 1
                    If chklstbxArr(i).Items(item) = "Main Settings" Then
                        chklstbxArr(i).SetItemChecked(item, False)
                    End If
                    If chklstbxArr(i).Items(item) = "Tool Counter" Then
                        chklstbxArr(i).SetItemChecked(item, False)
                    End If
                    If chklstbxArr(i).Items(item) = "Dry Run / Buy-Off" Then
                        chklstbxArr(i).SetItemChecked(item, False)
                    End If
                Next
            End If

            'If chklstbxArr(i) Is chklstbx_MessageLog Then
            '    For item As Integer = 0 To chklstbxArr(i).Items.Count - 1

            '    Next
            'End If

            'If chklstbxArr(i) Is chklstbx_ResultSummary Then
            '    For item As Integer = 0 To chklstbxArr(i).Items.Count - 1

            '    Next
            'End If

            'If chklstbxArr(i) Is chklstbx_ResultGraph Then
            '    For item As Integer = 0 To chklstbxArr(i).Items.Count - 1

            '    Next
            'End If
        Next
    End Sub

    Private Async Sub LoadUserCategoryTable()
        ' Prevent UI Thread Freezing
        Await Task.Delay(20)

        ' Define SQL String
        Dim sqlString As String = "
        SELECT row_number() OVER (ORDER BY id ASC) AS no, 
            id, 
            description 
        FROM UserCategory
        "

        ' Populate Datatable From SQL Query
        Dim dtUserCategory As DataTable = Await Task.Run(Function() SQL.ReadRecords(sqlString))   'SQL.ReadRecords(sqlString)

        ' Bind To DataGridView DataSource
        For Each dgv As DataGridView In {dgv_DispUserCategory, dgv_PermUserCategory}
            dgv.DataSource = dtUserCategory.Copy

            With dgv
                ' Set DataGridView Properties
                .BackgroundColor = SystemColors.Window
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .ShowCellToolTips = False
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

                ' Rename Columns
                .Columns("no").HeaderCell.Value = "No."
                .Columns("id").HeaderCell.Value = "ID"
                .Columns("description").HeaderCell.Value = "User Category"

                ' Set Column Properties
                .Columns("no").Width = 50
                .Columns("id").Width = 50
                .Columns("description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                ' Disable Sort
                For i As Integer = 0 To .ColumnCount - 1
                    .Columns.Item(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next

                .ClearSelection()
            End With
        Next

        ' Bind ComboBox To ComboSource [Dictionary]
        If True Then
            Dim comboSource As New Dictionary(Of String, String)()

            ' Assign Defaults
            comboSource.Add("0", "-Not Selected-")

            ' Insert Available Record Into Dictionary
            If dtUserCategory.Rows.Count > 0 Then
                For i As Integer = 0 To dtUserCategory.Rows.Count - 1
                    comboSource.Add(dtUserCategory(i)("id"), dtUserCategory(i)("description"))
                Next
            End If

            ' Bind ComboBox To Dictionary
            For Each cmbx As ComboBox In {ComboBox1}
                With cmbx
                    .DataSource = New BindingSource(comboSource, Nothing)
                    .DisplayMember = "Value"
                    .ValueMember = "Key"
                    If .Items.Count > 0 Then
                        .SelectedIndex = 0
                    End If
                End With
            Next
        End If
    End Sub

    Private Sub dgv_DispUserCategory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_DispUserCategory.CellClick
        Dim dgv As DataGridView = dgv_DispUserCategory

        If ComboBox1.FindStringExact(dgv.Rows(e.RowIndex).Cells("description").Value) >= 0 Then
            ComboBox1.SelectedIndex = ComboBox1.FindStringExact(dgv.Rows(e.RowIndex).Cells("description").Value)
        End If
    End Sub

    Private Sub btn_UserCategoryAdd_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Define InputString
        Dim InputStr As String = TextBox1.Text.Trim

        ' Check Input Range
        If InputStr.Length > 0 Then
            ' Query SQL Table
            Dim dt As DataTable = SQL.ReadRecords("SELECT id, description FROM UserCategory ORDER BY id DESC")

            ' Convert To DataView
            Dim dv As DataView = dt.DefaultView

            ' Filters Based On TextBox Input
            dv.RowFilter = $"description = '{InputStr}'"

            ' Convert To DataTable
            Dim dtGetCount As DataTable = dv.ToTable

            ' RowCount Of > 0 = User Category Exists
            If dtGetCount.Rows.Count > 0 Then
                ' User Category Exists
                MsgBox("exist")
            Else
                ' Define New ID
                Dim NewID As Integer = 1

                ' Check For MAX ID
                If dt.Rows.Count > 0 Then
                    ' Assign NewID With MaxID + 1; Since [id] already sorted by DESC in DataTable, top record of [id] will become MAX value instead.
                    NewID = dt(0)("id") + 1
                End If

                ' Insert Record
                Dim parameters As New Dictionary(Of String, Object) From {
                    {"id", NewID},
                    {"description", InputStr}
                }
                Dim ReturnValue As Integer = SQL.InsertRecord("UserCategory", parameters)

                If ReturnValue = 1 Then
                    ' Insert Success
                    MsgBox("success")

                    InitDevDefault()
                    LoadUserCategoryTable()
                Else
                    ' Insert Failed
                    MsgBox("fail")
                End If
            End If
        Else
            ' Empty [InputStr]
            MsgBox("empty")
        End If
    End Sub

    Private Sub btn_UserCategorDel_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cmbx As ComboBox = ComboBox1

        Dim UserCategoryID As Integer = DirectCast(cmbx.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim UserCategoryName As String = DirectCast(cmbx.SelectedItem, KeyValuePair(Of String, String)).Value

        If MsgBox($"Are you sure you want to Delete [{UserCategoryName}]?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "Question") = MsgBoxResult.Yes Then
            ' Delete From UserCategory
            Dim ReturnValue As Integer = SQL.DeleteRecord("UserCategory", $"id = '{UserCategoryID}'")

            ' Delete From UserPermission
            SQL.DeleteRecord("UserPermission", $"user_category_id = '{UserCategoryID}'")

            If ReturnValue > 0 Then
                ' Delete Sucess
                InitDevDefault()
                LoadUserCategoryTable()

                MsgBox($"User Category [{UserCategoryName}] Deleted Successfully.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Else
                ' Delete Unsuccessful
                MsgBox("User Category Deletion Failed.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
            End If
        End If
    End Sub

    Private Sub chklstbx_LostFocus(sender As Object, e As EventArgs) Handles _
        chklstbx_MainMenu.LostFocus, chklstbx_Registration.LostFocus, chklstbx_Recipe.LostFocus, chklstbx_Calibrate.LostFocus,
        chklstbx_Settings.LostFocus, chklstbx_MessageLog.LostFocus, chklstbx_ResultSummary.LostFocus, chklstbx_ResultGraph.LostFocus

        ' Declare CheckedListBox LostFocus
        Dim chklstbxLostFocus As CheckedListBox = DirectCast(sender, CheckedListBox)

        ' Clear Selection On Lost Focus
        chklstbxLostFocus.ClearSelected()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles _
        chkbx_MainMenu.CheckedChanged, chkbx_Registration.CheckedChanged, chkbx_Recipe.CheckedChanged, chkbx_Calibrate.CheckedChanged,
        chkbx_Settings.CheckedChanged, chkbx_MessageLog.CheckedChanged, chkbx_ResultSummary.CheckedChanged, chkbx_ResultGraph.CheckedChanged

        ' Declare CheckBox CheckChanged
        Dim chkbxCheckChanged As CheckBox = DirectCast(sender, CheckBox)

        ' Define CheckBox & CheckedListBox Arrays
        Dim chkbxArr As CheckBox() = {
            chkbx_MainMenu, chkbx_Registration, chkbx_Recipe, chkbx_Calibrate, chkbx_Settings, chkbx_MessageLog, chkbx_ResultSummary, chkbx_ResultGraph
        }
        Dim chklstbxArr As CheckedListBox() = {
            chklstbx_MainMenu, chklstbx_Registration, chklstbx_Recipe, chklstbx_Calibrate, chklstbx_Settings, chklstbx_MessageLog, chklstbx_ResultSummary, chklstbx_ResultGraph
        }

        ' Enable / Disable CheckedListBox
        For i As Integer = 0 To chkbxArr.Length - 1
            ' Define Excluded CheckBoxes
            Dim chkbxExcludeArr As CheckBox() = {
                chkbx_MainMenu, chkbx_Calibrate, chkbx_MessageLog, chkbx_ResultSummary, chkbx_ResultGraph
            }

            If Not chkbxExcludeArr.Contains(chkbxArr(i)) Then
                ' Action Performed
                If chkbxArr(i).Checked = True Then
                    chklstbxArr(i).Enabled = True
                    For item As Integer = 0 To chklstbxArr(i).Items.Count - 1
                        chklstbxArr(i).SetItemChecked(item, True)
                    Next
                Else
                    chklstbxArr(i).Enabled = False
                    For item As Integer = 0 To chklstbxArr(i).Items.Count - 1
                        chklstbxArr(i).SetItemChecked(item, False)
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub btn_UserPermissionSave_Click(sender As Object, e As EventArgs) Handles btn_UserPermissionSave.Click
        Dim dgv As DataGridView = dgv_PermUserCategory
        Dim rowIndex As Integer = -1
        Dim CategoryID As Integer = 0

        ' Create DataTable With Column
        Dim dtInsert As New DataTable : dtInsert.Columns.Add("permission")

        ' Get Selected Row Index
        If dgv_PermUserCategory.SelectedCells.Count > 0 Then
            rowIndex = dgv_PermUserCategory.SelectedCells(0).RowIndex
        Else
            rowIndex = -1
        End If

        ' Get Selected Permissions
        If rowIndex >= 0 Then
            CategoryID = dgv.Rows(rowIndex).Cells("id").Value

            If chkbx_MainMenu.Checked = True Then
                dtInsert.Rows.Add(chkbx_MainMenu.Text)

                For i As Integer = 0 To chklstbx_MainMenu.CheckedItems.Count - 1
                    dtInsert.Rows.Add(chklstbx_MainMenu.CheckedItems(i))
                Next
            End If

            If chkbx_Registration.Checked = True Then
                dtInsert.Rows.Add(chkbx_Registration.Text)

                For i As Integer = 0 To chklstbx_Registration.CheckedItems.Count - 1
                    dtInsert.Rows.Add(chklstbx_Registration.CheckedItems(i))
                Next
            End If

            If chkbx_Recipe.Checked = True Then
                dtInsert.Rows.Add(chkbx_Recipe.Text)

                For i As Integer = 0 To chklstbx_Recipe.CheckedItems.Count - 1
                    dtInsert.Rows.Add(chklstbx_Recipe.CheckedItems(i))
                Next
            End If

            If chkbx_Calibrate.Checked = True Then
                dtInsert.Rows.Add(chkbx_Calibrate.Text)

                For i As Integer = 0 To chklstbx_Calibrate.CheckedItems.Count - 1
                    dtInsert.Rows.Add(chklstbx_Calibrate.CheckedItems(i))
                Next
            End If

            If chkbx_Settings.Checked = True Then
                dtInsert.Rows.Add(chkbx_Settings.Text)

                For i As Integer = 0 To chklstbx_Settings.CheckedItems.Count - 1
                    dtInsert.Rows.Add(chklstbx_Settings.CheckedItems(i))
                Next
            End If

            If chkbx_MessageLog.Checked = True Then
                dtInsert.Rows.Add(chkbx_MessageLog.Text)

                For i As Integer = 0 To chklstbx_MessageLog.CheckedItems.Count - 1
                    dtInsert.Rows.Add(chklstbx_MessageLog.CheckedItems(i))
                Next
            End If

            If chkbx_ResultSummary.Checked = True Then
                dtInsert.Rows.Add(chkbx_ResultSummary.Text)

                For i As Integer = 0 To chklstbx_ResultSummary.CheckedItems.Count - 1
                    dtInsert.Rows.Add(chklstbx_ResultSummary.CheckedItems(i))
                Next
            End If

            If chkbx_ResultGraph.Checked = True Then
                dtInsert.Rows.Add(chkbx_ResultGraph.Text)

                For i As Integer = 0 To chklstbx_ResultGraph.CheckedItems.Count - 1
                    dtInsert.Rows.Add(chklstbx_ResultGraph.CheckedItems(i))
                Next
            End If
        Else
            MsgBox("Please Select A User Category To Continue.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
        End If

        If dtInsert.Rows.Count > 0 Then
            ' Remove Records With Existing Permission
            Dim delRecord As Integer = -1 : delRecord = SQL.DeleteRecord("UserPermission", $"user_category_id='{CategoryID}'")

            ' Add New Records
            If delRecord >= 0 Then
                Dim InsertedRowCount As Integer = 0
                For Each row As DataRow In dtInsert.Rows
                    Dim parameters As New Dictionary(Of String, Object) From {
                        {"user_category_id", CategoryID},
                        {"permission", row.Item("permission")}
                    }
                    InsertedRowCount += SQL.InsertRecord("UserPermission", parameters)
                Next

                If InsertedRowCount = dtInsert.Rows.Count Then
                    MsgBox("User Permission Update Success.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
                Else
                    MsgBox("Unable To Update User Permission. *[upd]", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
                End If
            Else
                MsgBox("Unable To Update User Permission. *[ins]", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Information")
            End If
        End If
    End Sub

    Private Sub dgv_PermUserCategory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_PermUserCategory.CellClick
        Dim dgv As DataGridView = dgv_PermUserCategory
        Dim CategoryID As Integer = -1

        If e.RowIndex >= 0 Then
            CategoryID = dgv.Rows(e.RowIndex).Cells("id").Value
        End If

        Dim dt As DataTable = SQL.ReadRecords($"SELECT permission FROM UserPermission WHERE user_category_id='{CategoryID}'")

        If dt.Rows.Count > 0 Then
            ' Clear All Selected
            For Each chkbx As CheckBox In {chkbx_Registration, chkbx_Recipe, chkbx_Calibrate, chkbx_Settings, chkbx_MessageLog, chkbx_ResultSummary, chkbx_ResultGraph}
                chkbx.Checked = False
            Next

            For Each row As DataRow In dt.Rows
                'If row.Item("permission") = "Main Menu" Then
                '    chkbx_MainMenu.Checked = True
                'Else
                '    chkbx_MainMenu.Checked = True
                'End If

                If row.Item("permission") = "Registration" Then
                    chkbx_Registration.Checked = True
                End If
                If row.Item("permission") = "Recipe" Then
                    chkbx_Recipe.Checked = True
                End If
                If row.Item("permission") = "Calibrate" Then
                    chkbx_Calibrate.Checked = True
                End If
                If row.Item("permission") = "Settings" Then
                    chkbx_Settings.Checked = True
                End If
                If row.Item("permission") = "Message Log" Then
                    chkbx_MessageLog.Checked = True
                End If
                If row.Item("permission") = "Result Summary" Then
                    chkbx_ResultSummary.Checked = True
                End If
                If row.Item("permission") = "Result Graph" Then
                    chkbx_ResultGraph.Checked = True
                End If
            Next

            ' Clear All Selected
            For Each chklstbx As CheckedListBox In {chklstbx_MainMenu, chklstbx_Registration, chklstbx_Recipe, chklstbx_Calibrate, chklstbx_Settings, chklstbx_MessageLog, chklstbx_ResultSummary, chklstbx_ResultGraph}
                For i As Integer = 0 To chklstbx.Items.Count - 1
                    chklstbx.SetItemChecked(i, False)
                Next
            Next


            For Each row As DataRow In dt.Rows
                If row.Item("permission") = "Main" Then
                    For i As Integer = 0 To chklstbx_MainMenu.Items.Count - 1
                        If chklstbx_MainMenu.Items(i) = "Main" Then
                            chklstbx_MainMenu.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "Production Details" Then
                    For i As Integer = 0 To chklstbx_MainMenu.Items.Count - 1
                        If chklstbx_MainMenu.Items(i) = "Production Details" Then
                            chklstbx_MainMenu.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "Status" Then
                    For i As Integer = 0 To chklstbx_MainMenu.Items.Count - 1
                        If chklstbx_MainMenu.Items(i) = "Status" Then
                            chklstbx_MainMenu.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "Manual Control" Then
                    For i As Integer = 0 To chklstbx_MainMenu.Items.Count - 1
                        If chklstbx_MainMenu.Items(i) = "Manual Control" Then
                            chklstbx_MainMenu.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "Alarm" Then
                    For i As Integer = 0 To chklstbx_MainMenu.Items.Count - 1
                        If chklstbx_MainMenu.Items(i) = "Alarm" Then
                            chklstbx_MainMenu.SetItemChecked(i, True)
                        End If
                    Next
                End If

                If row.Item("permission") = "User Registration" Then
                    For i As Integer = 0 To chklstbx_Registration.Items.Count - 1
                        If chklstbx_Registration.Items(i) = "User Registration" Then
                            chklstbx_Registration.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "User Deletion" Then
                    For i As Integer = 0 To chklstbx_Registration.Items.Count - 1
                        If chklstbx_Registration.Items(i) = "User Deletion" Then
                            chklstbx_Registration.SetItemChecked(i, True)
                        End If
                    Next
                End If

                If row.Item("permission") = "Recipe Details" Then
                    For i As Integer = 0 To chklstbx_Recipe.Items.Count - 1
                        If chklstbx_Recipe.Items(i) = "Recipe Details" Then
                            chklstbx_Recipe.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "Recipe Edit" Then
                    For i As Integer = 0 To chklstbx_Recipe.Items.Count - 1
                        If chklstbx_Recipe.Items(i) = "Recipe Edit" Then
                            chklstbx_Recipe.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "Recipe Create" Then
                    For i As Integer = 0 To chklstbx_Recipe.Items.Count - 1
                        If chklstbx_Recipe.Items(i) = "Recipe Create" Then
                            chklstbx_Recipe.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "Recipe Delete" Then
                    For i As Integer = 0 To chklstbx_Recipe.Items.Count - 1
                        If chklstbx_Recipe.Items(i) = "Recipe Delete" Then
                            chklstbx_Recipe.SetItemChecked(i, True)
                        End If
                    Next
                End If

                If row.Item("permission") = "Main Settings" Then
                    For i As Integer = 0 To chklstbx_Settings.Items.Count - 1
                        If chklstbx_Settings.Items(i) = "Main Settings" Then
                            chklstbx_Settings.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "Tool Counter" Then
                    For i As Integer = 0 To chklstbx_Settings.Items.Count - 1
                        If chklstbx_Settings.Items(i) = "Tool Counter" Then
                            chklstbx_Settings.SetItemChecked(i, True)
                        End If
                    Next
                End If
                If row.Item("permission") = "Dry Run / Buy-Off" Then
                    For i As Integer = 0 To chklstbx_Settings.Items.Count - 1
                        If chklstbx_Settings.Items(i) = "Dry Run / Buy-Off" Then
                            chklstbx_Settings.SetItemChecked(i, True)
                        End If
                    Next
                End If
                'If row.Item("permission") = "Developer" Then
                '    For i As Integer = 0 To chklstbx_Settings.Items.Count - 1
                '        If chklstbx_Settings.Items(i) = "Developer" Then
                '            chklstbx_Settings.SetItemChecked(i, True)
                '        End If
                '    Next
                'End If
            Next
        Else
            ' Clear All Selected
            For Each chkbx As CheckBox In {chkbx_Registration, chkbx_Recipe, chkbx_Calibrate, chkbx_Settings, chkbx_MessageLog, chkbx_ResultSummary, chkbx_ResultGraph}
                chkbx.Checked = False
            Next

            ' Clear All Selected
            For Each chklstbx As CheckedListBox In {chklstbx_MainMenu, chklstbx_Registration, chklstbx_Recipe, chklstbx_Calibrate, chklstbx_Settings, chklstbx_MessageLog, chklstbx_ResultSummary, chklstbx_ResultGraph}
                For i As Integer = 0 To chklstbx.Items.Count - 1
                    chklstbx.SetItemChecked(i, False)
                Next
            Next
        End If
    End Sub





#End Region



    Private Sub picbx_Icon_Click(sender As Object, e As EventArgs) Handles picbx_Icon.Click
        FormPixel.Show()
    End Sub

    Private Sub btn_Reset_Click(sender As Object, e As EventArgs) Handles btn_Reset.Click
        lbl_EndTime.Text = "-N/A-"
        lbl_StartTime.Text = "-N/A-"
        lbl_Duration.Text = "-N/A-"
        dtbuyoffmessage.Clear()
    End Sub
End Class