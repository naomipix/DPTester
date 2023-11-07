Imports System.Globalization
Imports System.IO
Imports System.IO.Ports

Public Class FormSetting
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
            dgv_MessageLog,
            dgv_DispUserCategory,
            dgv_PermUserCategory
        }
        For Each dgv As DataGridView In dgvArr
            DoubleBuffer.DoubleBuffered(dgv, True)
        Next

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
            tabctrl_Settings.TabPages.Add(tabpg_Developer)
            'LoadDeveloper()
            If PublicVariables.LoggedInIsDeveloper = True Then
                'tabctrl_Settings.TabPages.Add(tabpg_Developer)
                'LoadDeveloper()
            End If
        End If

        ' Show First TabPage
        If tabctrl_Settings.TabCount > 0 Then
            tabctrl_Settings.SelectedIndex = 0
        End If
    End Sub

    Private Sub FormSetting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear Selection
        Me.Select()

        ' Display Form Control
        panel_FormControl.Visible = True
    End Sub

    Private Sub btn_Home_Click(sender As Object, e As EventArgs) Handles btn_Home.Click
        Me.Close()
    End Sub

    Private Sub tabctrl_Settings_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabctrl_Settings.SelectedIndexChanged

        If tabctrl_Settings.SelectedTab Is tabpg_Settings Then
            LoadSettings()
        End If

        If tabctrl_Settings.SelectedTab Is tabpg_BuyOff Then
            LoadBuyoff()
        End If

        If tabctrl_Settings.SelectedTab Is tabpg_Developer Then
            LoadDeveloper()
        End If
    End Sub

#Region "Main Settings"
    Private Sub LoadSettings()
        With cmbx_ScannerType
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With

        Dim dt As DataTable = SQL.ReadRecords("SELECT id, retained_value FROM [0_RetainedMemory]")
        For Each row As DataRow In dt.Rows
            If row.Item("id") = 8 Then
                TextBox2.Text = row.Item("retained_value")
            End If
            If row.Item("id") = 9 Then
                TextBox3.Text = row.Item("retained_value")
            End If
            If row.Item("id") = 10 Then
                TextBox4.Text = row.Item("retained_value")
            End If
            If row.Item("id") = 11 Then
                TextBox5.Text = row.Item("retained_value")
            End If
        Next
    End Sub

    Private Sub chkbx_ScannerBypass_CheckedChanged(sender As Object, e As EventArgs) Handles chkbx_ScannerBypass.CheckedChanged
        ' Declare CheckBox Checked Changed
        Dim chkbxCheckedChanged As CheckBox = DirectCast(sender, CheckBox)

        ' CheckBox CheckState Changed
        If chkbxCheckedChanged.Checked = False Then
            chkbxCheckedChanged.Text = "ON"
            RetainedMemory.Update(3, "ScannerBypass", "1")
        Else
            chkbxCheckedChanged.Text = "OFF"
            RetainedMemory.Update(3, "ScannerBypass", "0")
        End If
    End Sub

    Private Sub cmbx_ScannerType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_ScannerType.SelectedIndexChanged
        If cmbx_ScannerType.Items.Count > 0 Then
            If cmbx_ScannerType.SelectedIndex = 0 Then
                RetainedMemory.Update(2, "ScannerType", CStr(cmbx_ScannerType.SelectedItem))
            End If
            If cmbx_ScannerType.SelectedIndex = 1 Then
                RetainedMemory.Update(2, "ScannerType", CStr(cmbx_ScannerType.SelectedItem))
            End If
        End If
    End Sub

#End Region

#Region "Buyoff Run"
    Private Sub LoadBuyoff()

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
                    RetainedMemory.Update(4, "DryRunEnabled", "0")
                Else
                    RetainedMemory.Update(4, "DryRunEnabled", "1")
                End If
            End If
            If chkbxCheckedChanged Is chkbx_BuyOffRun Then
                If chkbxCheckedChanged.Checked = False Then
                    RetainedMemory.Update(5, "BuyOffEnabled", "0")
                Else
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

    Private Sub btn_PathSelection_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button5.Click, Button6.Click, Button7.Click
        ' Declare Button Click
        Dim btnClick As Button = DirectCast(sender, Button)

        ' Define FolderBrowserDialog
        Dim folderBrowser As New FolderBrowserDialog()

        ' Show Dialog
        If folderBrowser.ShowDialog() = DialogResult.OK Then
            Dim folderPath As String = folderBrowser.SelectedPath

            ' Ensure PATH ends with "\"
            If Not folderPath.EndsWith("\") Then
                folderPath = Path.Combine(folderPath, "")
            End If

            ' Show In TextBox
            If btnClick Is Button4 Then
                TextBox2.Text = folderPath
            End If
            If btnClick Is Button5 Then
                TextBox3.Text = folderPath
            End If
            If btnClick Is Button6 Then
                TextBox4.Text = folderPath
            End If
            If btnClick Is Button7 Then
                TextBox5.Text = folderPath
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox($"Are you sure you want to Update Folder PATH?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "Question") = MsgBoxResult.Yes Then
            Dim directoryExists As Boolean = True
            Dim directoryInvalid As String = ""
            Dim txtbxInvalid As New TextBox

            Dim txtbxArr As TextBox() = {
                TextBox2,
                TextBox3,
                TextBox4,
                TextBox5
            }

            For Each txtbx As TextBox In txtbxArr
                If Not Directory.Exists(txtbx.Text) Then
                    directoryExists = False
                    directoryInvalid = txtbx.Text
                    txtbxInvalid = txtbx
                    Exit For
                End If
            Next

            If directoryExists = True Then
                For Each txtbx As TextBox In txtbxArr
                    If txtbx Is TextBox2 Then '8
                        RetainedMemory.Update(8, "CSVPathToProductionDetails", txtbx.Text)
                    End If
                    If txtbx Is TextBox3 Then '9
                        RetainedMemory.Update(9, "CSVPathToAlarmHistory", txtbx.Text)
                    End If
                    If txtbx Is TextBox4 Then '10
                        RetainedMemory.Update(10, "CSVPathToRecipeDetails", txtbx.Text)
                    End If
                    If txtbx Is TextBox5 Then '11
                        RetainedMemory.Update(11, "CSVPathToResultSummary", txtbx.Text)
                    End If
                Next
            Else
                MsgBox($"Invalid Path ""{directoryInvalid}""", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            End If
        End If
    End Sub

#End Region
End Class