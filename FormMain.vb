﻿Imports System.ComponentModel
Imports System.Net.NetworkInformation
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting

Module FormMainModule
    Public Workorder As String
    Public LotID As String
    Public PartID As String
    Public ConfirmationID As String
    Public Quantity As String
    Public RecipeID As String
    Public LotStartTime As String
    Public LotEndTime As String
    Public LotAttempt As Integer
    Public dtRecipeID As DataTable

    Public Sub ControlState(i As Integer)
        Select Case i
            Case 0  ' Logged Out
                ' Disable Tab Control
                FormMain.tabctrl_MainCtrl.Enabled = False

                ' Apply Permissions
                PermissionModule.ClearPermissions()
                PermissionModule.ReloadPermission()
            Case 1  ' Logged In
                ' Enable Tab Control
                FormMain.tabctrl_MainCtrl.Enabled = True

                ' Apply Permissions
                PermissionModule.ApplyOnLogon()
                PermissionModule.ReloadPermission()
        End Select
    End Sub
End Module

Public Class FormMain
#Region "Form Properties [ Load | Shown | Closing ]"
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Start Clock Timer
        TimerModule.clockTimer.Start()

        ' Load Ini file
        IniFileInitialize.ReadConfig()

        ' Load Retained Memory
        RetainedMemory.RetainedMemory.LoadAndApply()

        ' Load Version
        lbl_Version.Text = PublicVariables.AppVersion

        ' Set Program Title
        Me.Text = PublicVariables.ProgramTitle
        Me.lbl_Title.Text = PublicVariables.ProgramTitle

        ' Disable Controls
        FormMainModule.ControlState(0)

        ' DoubleBuffer DataGridView
        Dim dgvArr() As DataGridView = {
            dgv_ProdDetail,
            dgv_AlarmHistory,
                             _
            dgv_DigitalInput,
            dgv_DigitalOutput,
            dgv_AnalogInput,
            dgv_AnalogOutput
        }
        For Each dgv As DataGridView In dgvArr
            DoubleBuffer.DoubleBuffered(dgv, True)
        Next

        ' Enable Touch Capability for DataGridView
        DataGridViewDragScroll.EnableDragToScroll(dgv_ProdDetail)

        ' Initialize Chart Settings
        With cmbx_GraphSelection
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
        If PublicVariables.ChartType = "Spline" Then
            chart_MainLiveGraph.Series(0).ChartType = SeriesChartType.Spline
        Else
            chart_MainLiveGraph.Series(0).ChartType = SeriesChartType.Line
        End If
        If PublicVariables.MarkerEnabled = 1 Then
            chart_MainLiveGraph.Series(0).MarkerStyle = MarkerStyle.Circle
        Else
            chart_MainLiveGraph.Series(0).MarkerStyle = MarkerStyle.None
        End If

        'PLC Impicit Cyclic Messaging via Ethernet IP
        IMEIPInitialise()

        PLCTimer.Enabled = True
        'Disable buttons contents
        txtbx_WorkOrderNumber.Enabled = True
        txtbx_LotID.Enabled = True
        txtbx_PartID.Enabled = True
        txtbx_ConfirmationID.Enabled = True
        txtbx_Quantity.Enabled = True
        btn_WrkOrdScnDtConfirm.Enabled = True
        btn_WrkOrdScnDtEndLot.Enabled = False
        txtbx_WorkOrderNumber.Text = Nothing
        txtbx_LotID.Text = Nothing
        txtbx_PartID.Text = Nothing
        txtbx_ConfirmationID.Text = Nothing
        txtbx_Quantity.Text = Nothing
        txtbx_Operatorlotid.Text = Nothing

        btn_RecipeSelectionConfirm.Enabled = False
        cmbx_RecipeType.Enabled = False

        cmbx_RecipeID.Enabled = False
        lbl_CalibrationStatus.Text = Nothing
        lbl_CalibrationStatus.BackColor = Color.FromArgb(224, 224, 224)
        txtbx_SerialNumber.Enabled = False
        btn_OprKeyInDtConfirm.Enabled = False
        txtbx_Operatorlotid.Enabled = False



    End Sub

    Private Sub FormMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Clear Selection
        Me.Select()

        ' Show Controls
        panel_FormControl.Visible = True

        ' Check License
        Dim CheckLicense = True
        If CheckLicense = True Then
            PublicVariables.LicenseType = LicensingModule.LicensingModule.CheckLic()
            If PublicVariables.LicenseType = "LICENSED" Then
                With dsp_LicenseStatus
                    .Text = "License Activated"
                    .BackColor = Color.FromArgb(192, 255, 192)
                    .Visible = True
                End With
            End If
        End If

        ' Start LoginCheck Timer (In Seconds)
        If PublicVariables.LoginPrompt = True Then
            If PublicVariables.LoginPromptInterval > 0 Then
                StartLoginTimerCheck(PublicVariables.LoginPromptInterval)
            End If
        End If

        ' SQL Auto Backup
        If PublicVariables.AutoBackupSQLEnabled = True Then
            SQLSetAutoBackupMode(PublicVariables.AutoBackupSQLEnabled)
        End If

        ' Initialize Tables
        Dim t1 As Task = LoadProductionDetails()
        Dim t2 As Task = LoadStatus()

        ' Start Activity [TESTING] 
        'Dim test1 As Task = ClassActivity.GetActivityIO()
        'Dim test2 As Task = ClassActivity.UpdateActivityIO()
    End Sub

    Private Sub FormMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        PublicVariables.IsExitPromptShown = True
        If Not MsgBox("Are you sure you want to Exit?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Exit Application") = MsgBoxResult.Yes Then
            e.Cancel = True
            PublicVariables.IsExitPromptShown = False
        End If
        PLCTimer.Enabled = False
        IMEIPClose()
    End Sub



    Private Sub PLCTimer_Tick(sender As Object, e As EventArgs) Handles PLCTimer.Tick
        If DateTime.Now.Ticks > OmronEEIP.LastReceivedImplicitMessage.Ticks + (1000 * 10000) Then
            IMEIPreconnect()
        End If
        Form1.txtbx_DM370.Text = IMEIPReadString(10, 10)
        If IMEIPReadBoolean(0, 2) = True Then
            Form1.lbl_DM350_2.BackColor = Color.Green
        Else
            Form1.lbl_DM350_2.BackColor = Color.Red
        End If
        FetchPLC_DIn(0)
        FetchPLC_DOut(10)
        FetchPLC_Ain(20)
        FetchPLC_AOut(60)

        EXEIPFetch = OmronEEIP.AssemblyObject.getInstance(111)
    End Sub




#End Region

#Region "Main Menu Buttons"
    Private Sub btnMains_Click(sender As Object, e As EventArgs) Handles btn_LogInOut.Click, btn_UserRegistration.Click, btn_RecipeManagement.Click, btn_Calibration.Click, btn_Setting.Click, btn_MessageLog.Click, btn_ResultSummary.Click, btn_ResultGraph.Click
        ' Declare Button Clicked
        Dim btnClicked As Button = DirectCast(sender, Button)

        ' Remove Selection Highlight
        lbl_Title.Select()

        ' Button Login/Out
        If btnClicked Is btn_LogInOut Then
            If PublicVariables.LoggedIn = False Then
                FormUserLogin.ShowDialog()
            Else
                If MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Logout") = MsgBoxResult.Yes Then
                    LoginModule.ClearLoginValues()
                    FormMainModule.ControlState(0)
                    lbl_Username.Text = "-"
                    lbl_Category.Text = "-"
                End If
            End If
        End If

        ' Button User Registration
        If btnClicked Is btn_UserRegistration Then
            FormUserRegister.ShowDialog()
        End If

        ' Button Recipe Management
        If btnClicked Is btn_RecipeManagement Then
            FormRecipeManagement.ShowDialog()
        End If

        ' Button Calibration
        If btnClicked Is btn_Calibration Then
            FormCalibration.ShowDialog()
        End If

        ' Button Setting
        If btnClicked Is btn_Setting Then
            FormSetting.ShowDialog()
        End If

        ' Button Message Log
        If btnClicked Is btn_MessageLog Then
            FormMessageLog.ShowDialog()
        End If

        ' Button Result Summary
        If btnClicked Is btn_ResultSummary Then
            FormResultSummary.ShowDialog()

        End If

        ' Button Result Graph
        If btnClicked Is btn_ResultGraph Then
            FormResultGraph.ShowDialog()

        End If
    End Sub

#End Region

#Region "Main Menu"
    ' Start - [Debugging & Testing]
    Private cts As New CancellationTokenSource()
    Dim PlotStarted As Boolean = False
    Private Async Sub btn_Debug1_Click(sender As Object, e As EventArgs) Handles btn_Debug1.Click
        Dim ListOfDec() As Decimal = {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            31.1, 31.8, 32.4, 31.5, 32.7, 31.2, 32.1, 32.9, 31.3, 31.9,
            31.6, 32.2, 32.6, 31.7, 32.3, 31.4, 32.0, 31.0, 32.8, 33.0,
            32.5, 31.8, 31.1, 32.4, 32.9, 31.2, 32.7, 31.5, 32.1, 31.3,
            32.2, 32.3, 31.9, 31.6, 32.6, 31.4, 32.0, 32.5, 31.7, 32.8,
            33.0, 31.0, 31.1, 32.4, 32.9, 32.7, 31.2, 32.1, 31.3, 31.8,
            31.9, 32.2, 31.5, 31.6, 32.3, 32.6, 31.4, 32.5, 32.0, 31.7,
            32.8, 33.0, 31.0, 31.1, 32.4, 32.9, 31.2, 32.7, 32.1, 31.3,
            32.2, 31.5, 31.8, 32.6, 31.9, 32.3, 31.6, 31.4, 32.5, 32.0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        }

        cts.Cancel()
        cts = New CancellationTokenSource() ' Create a new CancellationTokenSource
        PlotStarted = True
        Try
            Await TestDummyGraph(ListOfDec, cts.Token)
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Dim dt As New DataTable
    Private Async Function TestDummyGraph(ListOfDec() As Decimal, token As CancellationToken) As Task
        dt.Columns.Clear()

        dt.Columns.Add("second")
        dt.Columns.Add("inlet_pressure")
        dt.Columns.Add("outlet_pressure")
        dt.Columns.Add("diff_pressure")
        dt.Columns.Add("flow_rate")

        With chart_MainLiveGraph.Series(0)
            .XValueMember = "second"
        End With
        'With chart_MainLiveGraph.Series(1)
        '    .XValueMember = "second"
        '    .YValueMembers = "outlet_pressure"
        'End With
        'With chart_MainLiveGraph.Series(2)
        '    .XValueMember = "second"
        '    .YValueMembers = "diff_pressure"
        'End With

        Dim stepSize As Integer = Math.Max(ListOfDec.Length \ PublicVariables.ChartPlotMax, 1) ' Calculate step size

        ' Plot Data With Scaling 
        For i As Integer = 0 To ListOfDec.Length - 2 Step stepSize  'For i As Integer = 0 To ListOfDec.Count - 1
            If token.IsCancellationRequested Then
                PlotStarted = False
                Exit For ' Check if cancellation is requested
            End If

            Await Task.Delay(50)

            dt.Rows.Add(i + 1, ListOfDec(i), CDec(ListOfDec(i)) - CDec(1), CDec(ListOfDec(i)) - CDec(ListOfDec(i)) - CDec(1), 5)

            ' Dim maxDiffPress As Decimal = dt.AsEnumerable().Max(Function(row) Decimal.Parse(row.Field(Of String)("diff_pressure")))
            'Dim minDiffPress As Decimal = dt.AsEnumerable().Min(Function(row) Decimal.Parse(row.Field(Of String)("diff_pressure")))


            Dim maxDecimal As Decimal
            For Each row As DataRow In dt.Rows
                Dim value As String = row.Field(Of String)("diff_pressure")
                Dim currentDecimal As Decimal
                If Decimal.TryParse(value, currentDecimal) Then
                    maxDecimal = Math.Max(maxDecimal, currentDecimal)
                End If
            Next

            Dim minDecimal As Decimal
            For Each row As DataRow In dt.Rows
                Dim value As String = row.Field(Of String)("diff_pressure")
                Dim currentDecimal As Decimal
                If Decimal.TryParse(value, currentDecimal) Then
                    minDecimal = Math.Min(minDecimal, currentDecimal)
                End If
            Next

            With chart_MainLiveGraph
                .Series(0).Points.Clear()
                '.Series(1).Points.Clear()
                '.Series(2).Points.Clear()

                '.ChartAreas(0).AxisY2.Interval = 0.5
                '.ChartAreas(0).AxisY2.Minimum = Convert.ToInt32(minDecimal) - 1
                '.ChartAreas(0).AxisY2.Maximum = Convert.ToInt32(maxDecimal) + 0.5
                Select Case cmbx_GraphSelection.SelectedIndex
                    Case 0
                        .Series(0).YValueMembers = "diff_pressure"
                    Case 1
                        .Series(0).YValueMembers = "flow_rate"
                    Case 2
                        .Series(0).YValueMembers = "inlet_pressure"
                    Case 3
                        .Series(0).YValueMembers = "outlet_pressure"
                End Select

                .DataSource = Nothing
                .DataSource = dt
            End With
        Next

        ' Add Last Data Point (Pre-skipped On Resampling With StepSize)
        If Not token.IsCancellationRequested Then
            Await Task.Delay(30)

            dt.Rows.Add(ListOfDec.Length, ListOfDec(ListOfDec.Length - 1), CDec(ListOfDec(ListOfDec.Length - 1)) - CDec(1), ListOfDec(ListOfDec.Length - 1) - CDec(ListOfDec(ListOfDec.Length - 1)) - CDec(1), 5)

            'Dim maxDiffPress As Decimal = dt.AsEnumerable().Max(Function(row) row.Field(Of Decimal)("diff_pressure"))
            'Dim minDiffPress As Decimal = dt.AsEnumerable().Min(Function(row) row.Field(Of Decimal)("diff_pressure"))

            Dim maxDecimal As Decimal
            For Each row As DataRow In dt.Rows
                Dim value As String = row.Field(Of String)("diff_pressure")
                Dim currentDecimal As Decimal
                If Decimal.TryParse(value, currentDecimal) Then
                    maxDecimal = Math.Max(maxDecimal, currentDecimal)
                End If
            Next

            Dim minDecimal As Decimal
            For Each row As DataRow In dt.Rows
                Dim value As String = row.Field(Of String)("diff_pressure")
                Dim currentDecimal As Decimal
                If Decimal.TryParse(value, currentDecimal) Then
                    minDecimal = Math.Min(minDecimal, currentDecimal)
                End If
            Next

            With chart_MainLiveGraph
                .Series(0).Points.Clear()
                '.Series(1).Points.Clear()
                '.Series(2).Points.Clear()

                '.ChartAreas(0).AxisY2.Interval = 0.5
                '.ChartAreas(0).AxisY2.Minimum = Convert.ToInt32(minDecimal) - 1
                '.ChartAreas(0).AxisY2.Maximum = Convert.ToInt32(maxDecimal) + 0.5
                Select Case cmbx_GraphSelection.SelectedIndex
                    Case 0
                        .Series(0).YValueMembers = "diff_pressure"
                        .Series(0).Name = "Diff. Pressure"
                    Case 1
                        .Series(0).YValueMembers = "flow_rate"
                        .Series(0).Name = "Flow Rate"
                    Case 2
                        .Series(0).YValueMembers = "inlet_pressure"
                        .Series(0).Name = "Inlet Pressure"
                    Case 3
                        .Series(0).YValueMembers = "outlet_pressure"
                        .Series(0).Name = "Outlet Pressure"
                End Select

                .DataSource = Nothing
                .DataSource = dt
            End With
        End If

        PlotStarted = False
    End Function

    Private Sub cmbx_GraphSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_GraphSelection.SelectedIndexChanged
        If PlotStarted = False Then
            With chart_MainLiveGraph
                .Series(0).Points.Clear()

                Select Case cmbx_GraphSelection.SelectedIndex
                    Case 0
                        .Series(0).YValueMembers = "diff_pressure"
                        .Series(0).Name = "Diff. Pressure"
                    Case 1
                        .Series(0).YValueMembers = "flow_rate"
                        .Series(0).Name = "Flow Rate"
                    Case 2
                        .Series(0).YValueMembers = "inlet_pressure"
                        .Series(0).Name = "Inlet Pressure"
                    Case 3
                        .Series(0).YValueMembers = "outlet_pressure"
                        .Series(0).Name = "Outlet Pressure"
                End Select

                .DataSource = Nothing
                .DataSource = dt
            End With
        End If
    End Sub

    ' End   - [Debugging & Testing]

    ' Perform Action According To TabSelected
    Private Sub tabctrl_MainCtrl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabctrl_MainCtrl.SelectedIndexChanged
        If tabctrl_MainCtrl.SelectedTab Is tabpg_Main Then
            ' Focus First Tab Page
            tabctrl_SubMain.SelectedTab = tabpg_MainLiveGraph
        End If

        If tabctrl_MainCtrl.SelectedTab Is tabpg_ProdDetail Then
            ' Load Production Details
            Dim t1 As Task = LoadProductionDetails()
        End If

        If tabctrl_MainCtrl.SelectedTab Is tabpg_Status Then
            ' Focus First Tab Page
            tabctrl_SubStatus.SelectedTab = tabpg_StatusIO

        End If

        If tabctrl_MainCtrl.SelectedTab Is tabpg_ManualCtrl Then
            ' Focus First Tab Page
            tabctrl_SubManualCtrl.SelectedTab = tabpg_ManualControlValve

        End If

        If tabctrl_MainCtrl.SelectedTab Is tabpg_Alarm Then
            ' Focus First Tab Page
            tabctrl_SubAlarm.SelectedTab = tabpg_AlarmCurrent

            ' Initialize Current Alarm


            ' Load Alarm History
            Dim t2 As Task = LoadAlarm()
        End If
    End Sub

    ' Clear Selection
    Public Sub dgvClearSelection(dgv As DataGridView)
        With dgv
            .CurrentCell = Nothing
            .ClearSelection()
        End With
    End Sub
#End Region

#Region "Main"
    ' Perform Action According To TabSelected
    Private Sub tabctrl_SubMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabctrl_SubMain.SelectedIndexChanged
        If tabctrl_SubMain.SelectedTab Is tabpg_MainLiveGraph Then
            dsp_GraphSelection.Visible = True
            cmbx_GraphSelection.Visible = True
        Else
            dsp_GraphSelection.Visible = False
            cmbx_GraphSelection.Visible = False
        End If
    End Sub

    Private Sub CheckForCurrentWork()

    End Sub

    Private Sub CheckForCurrentRecipe()

    End Sub

    Private Sub CheckForCalibrationStatus()

    End Sub

    Private Sub CheckForProductionCount()

    End Sub
#End Region

#Region "Production Details"
    ' Initialize Production Details Tab
    Private Async Function LoadProductionDetails() As Task
        ' Load Production Details Filter List
        Try
            Await LoadProductionDetailsFilterList()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try

        ' Load Production Details Table
        LoadProductionDetailsTable(False, Nothing, Nothing, Nothing, Nothing)

        ' Reset Filters
        ProdDetailFieldReset()
    End Function

    ' Load Filter List For ComboBoxes
    Private Async Function LoadProductionDetailsFilterList() As Task

        ' Lot ID
        If True Then
            Dim comboSource As New Dictionary(Of String, String)()

            ' Assign Defaults
            comboSource.Add("0", "-Not Selected-")

            ' Get Recipe Table
            'Dim dtRecipeTable As DataTable = SQL.ReadRecords("SELECT lot_id FROM WorkOrder")
            Dim dvGetRecord As DataView = Await Task.Run(Function() SQL.ReadRecords($"
                SELECT TOP {PublicVariables.ProdDetailsDisplayedTableCount} 
                    LotUsage.lot_id 
                FROM ProductionDetail 
                    LEFT JOIN LotUsage ON ProductionDetail.lot_usage_id=LotUsage.id 
                ORDER BY ProductionDetail.timestamp DESC
            ").DefaultView)

            ' Get Unique Records
            Dim dtRecipeTable As DataTable = dvGetRecord.ToTable(True, "lot_id")

            ' Insert Available Record Into Dictionary
            If dtRecipeTable.Rows.Count > 0 Then
                For i As Integer = 0 To dtRecipeTable.Rows.Count - 1
                    comboSource.Add(i + 1, dtRecipeTable(i)("lot_id"))
                Next
            End If

            ' Bind ComboBox To Dictionary
            For Each cmbx As ComboBox In {cmbx_FilterLotID}
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

        ' Part ID
        If True Then
            Dim comboSource As New Dictionary(Of String, String)()

            ' Assign Defaults
            comboSource.Add("0", "-Not Selected-")

            ' Get Recipe Table
            'Dim dtRecipeTable As DataTable = SQL.ReadRecords("SELECT part_id FROM PartTable")
            Dim dvGetRecord As DataView = Await Task.Run(Function() SQL.ReadRecords($"
                SELECT TOP {PublicVariables.ProdDetailsDisplayedTableCount} 
                    WorkOrder.part_id
                FROM ProductionDetail 
                LEFT JOIN LotUsage ON ProductionDetail.lot_usage_id=LotUsage.id 
                LEFT JOIN WorkOrder ON LotUsage.lot_id=WorkOrder.lot_id 
                ORDER BY ProductionDetail.timestamp DESC
            ").DefaultView)

            ' Get Unique Records
            Dim dtRecipeTable As DataTable = dvGetRecord.ToTable(True, "part_id")

            ' Insert Available Record Into Dictionary
            If dtRecipeTable.Rows.Count > 0 Then
                For i As Integer = 0 To dtRecipeTable.Rows.Count - 1
                    comboSource.Add(i + 1, dtRecipeTable(i)("part_id"))
                Next
            End If

            ' Bind ComboBox To Dictionary
            For Each cmbx As ComboBox In {cmbx_FilterPartID}
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

        ' Recipe ID
        If True Then
            Dim comboSource As New Dictionary(Of String, String)()

            ' Assign Defaults
            comboSource.Add("0", "-Not Selected-")

            ' Get Recipe Table
            'Dim dtRecipeTable As DataTable = SQL.ReadRecords("SELECT id, recipe_id FROM RecipeTable")
            Dim dvGetRecord As DataView = Await Task.Run(Function() SQL.ReadRecords($"
                SELECT TOP {PublicVariables.ProdDetailsDisplayedTableCount} 
                    LotUsage.recipe_id 
                FROM ProductionDetail 
                LEFT JOIN LotUsage ON ProductionDetail.lot_usage_id=LotUsage.id 
                ORDER BY ProductionDetail.timestamp DESC
            ").DefaultView)

            ' Sort Recipe Table
            dvGetRecord.Sort = "recipe_id" & " ASC"

            ' Get Unique Records
            Dim dtRecipeTable As DataTable = dvGetRecord.ToTable(True, "recipe_id")

            ' Insert Available Record Into Dictionary
            If dtRecipeTable.Rows.Count > 0 Then
                For i As Integer = 0 To dtRecipeTable.Rows.Count - 1
                    'comboSource.Add(dtRecipeTable(i)("id"), dtRecipeTable(i)("recipe_id"))
                    comboSource.Add(i + 1, dtRecipeTable(i)("recipe_id"))
                Next
            End If

            ' Bind ComboBox To Dictionary
            For Each cmbx As ComboBox In {cmbx_FilterRecipeID}
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

        ' Result
        If True Then
            Dim comboSource As New Dictionary(Of String, String)()

            ' Assign Defaults
            comboSource.Add("0", "-Not Selected-")
            comboSource.Add("1", "Pass")
            comboSource.Add("2", "Fail")

            ' Bind ComboBox To Dictionary
            For Each cmbx As ComboBox In {cmbx_FilterResult}
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
    End Function

    ' Reset Search & Filter Fields
    Private Sub ProdDetailFieldReset()
        txtbx_SearchSerialNumber.Text = ""
        For Each cmbx As ComboBox In {cmbx_FilterLotID, cmbx_FilterPartID, cmbx_FilterRecipeID, cmbx_FilterResult}
            If cmbx.Items.Count > 0 Then
                cmbx.SelectedIndex = 0
            End If
        Next
        For Each dtpicker As DateTimePicker In {dtpicker_EndDate}
            dtpicker.Value = DateTime.Now
        Next
    End Sub

    ' Button Clicked Event [Reset] [Search] [Export]
    Private Sub btnProductionDetails_Click(sender As Object, e As EventArgs) Handles btn_ProdDetailReset.Click, btn_ProdDetailSearch.Click, btn_ProdDetailExport.Click
        ' Declare Button Clicked
        Dim btnClicked As Button = DirectCast(sender, Button)

        ' Remove Selection Highlight
        lbl_Title.Select()

        ' Button Reset
        If btnClicked Is btn_ProdDetailReset Then
            ProdDetailFieldReset()
            LoadProductionDetailsTable(False, Nothing, Nothing, Nothing, Nothing)
        End If

        ' Button Search
        If btnClicked Is btn_ProdDetailSearch Then
            SearchProductionDetails()
        End If

        ' Button Export
        If btnClicked Is btn_ProdDetailExport Then
            ExportProductionDetails()
        End If
    End Sub

    ' Populate DataGridView From SQL Tables
    Private Async Sub LoadProductionDetailsTable(containSearch As Boolean, SerialNumber As String, cmbxArr() As ComboBox, dtStart As DateTime, dtEnd As DateTime)
        ' Prevent UI Thread Freezing
        Await Task.Delay(20)

        ' Define SQL String
        Dim sqlString As String = $"
        SELECT TOP {PublicVariables.ProdDetailsDisplayedTableCount} 
            ProductionDetail.id, 
            CONCAT(LotUsage.lot_id, '-', ProductionDetail.serial_number) AS serial_uid, 
            ProductionDetail.serial_number, 
            ProductionDetail.lot_usage_id, 
            LotUsage.lot_id, 
            ProductionDetail.timestamp, 
            ProductionDetail.serial_attempt, 
            LotUsage.recipe_id, 
            LotUsage.cal_diff_pressure, 
            ProductionDetail.flowrate, 
            ProductionDetail.diff_pressure, 
            CONCAT(UPPER(SUBSTRING(ProductionDetail.result, 1, 1)), LOWER(SUBSTRING(ProductionDetail.result, 2, LEN(ProductionDetail.result)))) AS result, 
            ProductionDetail.temperature, 
            ProductionDetail.viscosity, 
            ProductionDetail.inlet_pressure, 
            ProductionDetail.outlet_pressure, 
            ProductionDetail.cycle_time, 
            WorkOrder.work_order, 
            WorkOrder.part_id, 
            WorkOrder.confirmation_id, 
            LotUsage.run_by 
        FROM ProductionDetail 
        LEFT JOIN LotUsage ON ProductionDetail.lot_usage_id=LotUsage.id 
        LEFT JOIN WorkOrder ON LotUsage.lot_id=WorkOrder.lot_id 
        ORDER BY ProductionDetail.timestamp DESC
        "

        ' Populate Datatable From SQL Query
        Dim dtProdDetail As DataTable = Await Task.Run(Function() SQL.ReadRecords(sqlString))   'SQL.ReadRecords(sqlString)

        ' Search
        If containSearch = True Then
            ' Set DataTable To Case Insensitive
            dtProdDetail.CaseSensitive = False

            ' Convert To DataView Table
            Dim dvProdDetail As DataView = dtProdDetail.DefaultView

            ' Declare FilterList Array
            Dim FilterList As New List(Of String)

            ' Check TextBox String
            If SerialNumber.Length > 0 Then
                ' Filter [serial_uid]
                'FilterList.Add($"serial_uid='{SerialNumber}'")

                ' Filter [serial_number]
                FilterList.Add($"serial_number LIKE '%{SerialNumber}%'")
            End If

            ' Check ComboBox Selection
            For Each cmbx As ComboBox In cmbxArr
                If cmbx.Items.Count > 0 AndAlso cmbx.SelectedIndex > 0 Then
                    Dim selectedValue As String = DirectCast(cmbx.SelectedItem, KeyValuePair(Of String, String)).Value
                    Dim cellValue As String = ""

                    If cmbx Is cmbx_FilterLotID Then
                        FilterList.Add($"lot_id='{selectedValue}'")
                    End If
                    If cmbx Is cmbx_FilterPartID Then
                        FilterList.Add($"part_id='{selectedValue}'")
                    End If
                    If cmbx Is cmbx_FilterRecipeID Then
                        FilterList.Add($"recipe_id='{selectedValue}'")
                    End If
                    If cmbx Is cmbx_FilterResult Then
                        FilterList.Add($"result='{selectedValue}'")
                    End If
                End If
            Next

            ' Check DateTime
            If True Then
                'FilterList.Add($"timestamp>=#{dtStart}#")
                'FilterList.Add($"timestamp<=#{dtEnd}#")

                FilterList.Add($"Convert(timestamp, 'System.DateTime')>=#{dtStart.ToString("MM/dd/yyyy 00:00:00")}#")
                FilterList.Add($"Convert(timestamp, 'System.DateTime')<=#{dtEnd.ToString("MM/dd/yyyy 23:59:59")}#")
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
            dvProdDetail.RowFilter = FilterString

            ' Convert Into Temp DataTable
            Dim dtTemp As DataTable = dvProdDetail.ToTable

            ' Set DataTable To Case Sensitive
            dtTemp.CaseSensitive = True

            ' Bind To DataGridView DataSource
            dgv_ProdDetail.DataSource = dtTemp
        Else
            ' Bind To DataGridView DataSource
            dgv_ProdDetail.DataSource = dtProdDetail

            ' Set dtStart [DateTimePicker] To Earliest Record
            If dtProdDetail.Rows.Count > 0 Then
                dtpicker_StartDate.Value = dtProdDetail(dtProdDetail.Rows.Count - 1)("timestamp")
            Else
                dtpicker_StartDate.Value = DateTime.Now
            End If
        End If

        With dgv_ProdDetail
            ' Set DataGridView Properties
            .BackgroundColor = SystemColors.Window
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ShowCellToolTips = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            ' Hide Unnecessary Columns
            .Columns("id").Visible = False
            '.Columns("serial_number").Visible = False
            .Columns("lot_usage_id").Visible = False
            .Columns("lot_id").Visible = False
            '.Columns("cycle_time").Visible = False

            ' Rename Columns
            .Columns("serial_uid").HeaderCell.Value = "Unique ID"
            .Columns("serial_number").HeaderCell.Value = "S/N"
            .Columns("timestamp").HeaderCell.Value = "Timestamp"
            .Columns("serial_attempt").HeaderCell.Value = "Number of Attempt"
            .Columns("recipe_id").HeaderCell.Value = "Recipe ID"
            .Columns("cal_diff_pressure").HeaderCell.Value = "Calibration Offset (kPa)"
            .Columns("flowrate").HeaderCell.Value = "Flowrate (l/min)"
            .Columns("diff_pressure").HeaderCell.Value = "Calculated DP (kPa)"
            .Columns("result").HeaderCell.Value = "DP test Result"
            .Columns("temperature").HeaderCell.Value = "Temperature (K)"
            .Columns("viscosity").HeaderCell.Value = "Viscosity (mPa.s)"
            .Columns("inlet_pressure").HeaderCell.Value = "Inlet Pressure (kPa)"
            .Columns("outlet_pressure").HeaderCell.Value = "Outlet Pressure (kPa)"
            .Columns("cycle_time").HeaderCell.Value = "Cycle Time (s)"
            .Columns("work_order").HeaderCell.Value = "Work Order Number"
            .Columns("part_id").HeaderCell.Value = "Part ID"
            .Columns("confirmation_id").HeaderCell.Value = "Confirmation ID"
            .Columns("run_by").HeaderCell.Value = "Operator ID"

            ' Set Column Properties
            .Columns("serial_uid").Width = 150
            With .Columns("timestamp")
                .DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Width = 140
            End With
            .Columns("serial_number").Width = 80
            .Columns("serial_attempt").Width = 90
            .Columns("recipe_id").Width = 150
            .Columns("cal_diff_pressure").Width = 90
            .Columns("flowrate").Width = 90
            .Columns("diff_pressure").Width = 90
            .Columns("result").Width = 90
            .Columns("temperature").Width = 90
            .Columns("viscosity").Width = 90
            .Columns("inlet_pressure").Width = 90
            .Columns("outlet_pressure").Width = 90
            .Columns("cycle_time").Width = 90
            .Columns("work_order").Width = 90
            .Columns("part_id").Width = 145
            .Columns("confirmation_id").Width = 95
            .Columns("run_by").Width = 90

            '.Columns("serial_uid").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '.Columns("part_id").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            ' .Columns("run_by").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End With

        ' Clear Selection
        dgvClearSelection(dgv_ProdDetail)

        ' Prompt When No Result Returns
        If containSearch = True Then
            If Not dgv_ProdDetail.RowCount > 0 Then
                MsgBox("Search Result Returned Empty.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Information")
            End If
        End If
    End Sub

    ' Format Cell Color Based On Cell Content
    Private Sub dgv_ProdDetail_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv_ProdDetail.CellFormatting
        Dim dgv As DataGridView = dgv_ProdDetail
        Try
            'e.CellStyle.BackColor = Color.FromArgb(255, 192, 192)
            If dgv.Rows(e.RowIndex).Cells("result").Value.ToString().ToUpper = CStr("Pass").ToUpper Then
                dgv.Rows(e.RowIndex).Cells("result").Style.BackColor = Color.FromArgb(192, 255, 192)
            End If
            If dgv.Rows(e.RowIndex).Cells("result").Value.ToString().ToUpper = CStr("Fail").ToUpper Then
                dgv.Rows(e.RowIndex).Cells("result").Style.BackColor = Color.FromArgb(255, 192, 192)
            End If
        Catch ex As Exception

        End Try
    End Sub

    ' Remove DataGridView Selection When Not In Focus
    Private Sub dgv_ProdDetail_LostFocus(sender As Object, e As EventArgs) Handles dgv_ProdDetail.LostFocus
        dgvClearSelection(dgv_ProdDetail)
    End Sub

    ' Search Production Details
    Private Sub SearchProductionDetails()
        ' Declare Variables
        Dim SerialNumber As String = txtbx_SearchSerialNumber.Text
        Dim cmbxArr() As ComboBox = {cmbx_FilterLotID, cmbx_FilterPartID, cmbx_FilterRecipeID, cmbx_FilterResult}

        ' Load Table With Filters
        LoadProductionDetailsTable(True, SerialNumber, cmbxArr, dtpicker_StartDate.Value, dtpicker_EndDate.Value)
    End Sub

    ' Export Production Details
    Private Async Sub ExportProductionDetails()
        ' Convert Visible DataGridView Columns To DataTable
        Dim dt As DataTable = Await Task.Run(Function() GetVisibleColumnsDataTable(dgv_ProdDetail))     'GetVisibleColumnsDataTable(dgv_ProdDetail)

        ' Get Path
        'Dim dtGetPath As DataTable = Await Task.Run(Function() SQL.ReadRecords($"SELECT id, description, retained_value FROM [0_RetainedMemory] WHERE id={8}"))
        Dim ExportPath As String = PublicVariables.CSVPathToProductionDetails 'dtGetPath(0)("retained_value")

        ' Export With Return
        Dim ReturnValue As String = ExportDataTableToCsv(dt, ExportPath & $"ProductionDetails_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv", PublicVariables.CSVDelimiterProductionDetails)

        ' Check Return State
        If ReturnValue = "True" Then
            MsgBox("CSV File Exported Successfully.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Export - Success")
        ElseIf ReturnValue = "Missing" Then
            MsgBox("Invalid File Path Specified.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Export - Path Error")
        ElseIf ReturnValue = "False" Then
            MsgBox("Unable To Export CSV File, Please Try Again.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Export - Failed")
        End If
    End Sub

    ' Check DateTimePicker Selection
    Private Sub dtpicker_ProdDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker_StartDate.ValueChanged, dtpicker_EndDate.ValueChanged
        ' Validation Check To Ensure Start Date IsNot > End Date
        If dtpicker_StartDate.Value > dtpicker_EndDate.Value Then
            dtpicker_EndDate.Value = dtpicker_StartDate.Value
        End If
    End Sub
#End Region

#Region "Status"
    Private Async Function LoadStatus() As Task
        Try
            Await InitializeIOStatus()

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try

        Try
            Await InitializeDeviceStatus()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try
    End Function

#Region "IO Status"
    Private Async Function InitializeIOStatus() As Task
        ' Get IOTable Properties
        Dim dtIOTable As DataTable = Await Task.Run(Function() SQL.ReadRecords("SELECT * FROM IOTable"))

        For Each dgv As DataGridView In {dgv_DigitalInput, dgv_DigitalOutput, dgv_AnalogInput, dgv_AnalogOutput}
            With dgv
                ' Add Default Columns
                .Columns.Add("no", "No.")
                .Columns.Add("desc", "Description")
                .Columns.Add("io", "I/O")

                ' Custom Columns
                If dgv Is dgv_DigitalInput Or dgv Is dgv_DigitalOutput Then
                    ' CheckBox Column
                    Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                    With checkBoxColumn
                        .HeaderText = "Status"
                        .Name = "value"
                    End With
                    .Columns.Insert(dgv.ColumnCount, checkBoxColumn)
                Else
                    ' Text Column
                    .Columns.Add("value", "Value")
                End If

                ' Set Column Properties
                .Columns("no").Width = 40
                .Columns("desc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("io").Width = 85
                .Columns("value").Width = 70

                ' Set Cell Properties
                .Columns("no").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
                .Columns("io").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
                .Columns("value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter

                ' Set Header Properties
                .Columns("no").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("io").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("value").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                ' Disable Sort
                For i As Integer = 0 To .ColumnCount - 1
                    .Columns.Item(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            End With
        Next

        'IO Status [Digital Input]
        For i As Integer = 0 To 29
            ' Assign Defaults
            dgv_DigitalInput.Rows.Add(i + 1, $"Digital Input-{i + 1}", $"DIO_IN_{i}", False)

            ' Rename Fields
            If True Then
                Dim FieldIO As String = dtIOTable(i)("digital_in_io")
                Dim FieldDesc As String = dtIOTable(i)("digital_in_desc")

                If FieldDesc.Length > 0 Then
                    dgv_DigitalInput.Rows(i).Cells("desc").Value = FieldDesc
                End If

                If FieldIO.Length > 0 Then
                    dgv_DigitalInput.Rows(i).Cells("io").Value = FieldIO
                End If
            End If
        Next

        'IO Status [Digital Output]
        For i As Integer = 0 To 41
            ' Assign Defaults
            dgv_DigitalOutput.Rows.Add(i + 1, $"Digital Output-{i + 1}", $"DIO_OUT_{i}", False)

            ' Rename Fields
            If True Then
                Dim FieldIO As String = dtIOTable(i)("digital_out_io")
                Dim FieldDesc As String = dtIOTable(i)("digital_out_desc")

                If FieldDesc.Length > 0 Then
                    dgv_DigitalOutput.Rows(i).Cells("desc").Value = FieldDesc
                End If

                If FieldIO.Length > 0 Then
                    dgv_DigitalOutput.Rows(i).Cells("io").Value = FieldIO
                End If
            End If
        Next

        'IO Status [Analog Input]
        For i As Integer = 0 To 15
            ' Assign Defaults
            dgv_AnalogInput.Rows.Add(i + 1, $"Analog Input-{i + 1}", $"AIO_IN_{i}", "0.0")

            ' Rename Fields
            If True Then
                Dim FieldIO As String = dtIOTable(i)("analog_in_io")
                Dim FieldDesc As String = dtIOTable(i)("analog_in_desc")

                If FieldDesc.Length > 0 Then
                    dgv_AnalogInput.Rows(i).Cells("desc").Value = FieldDesc
                End If

                If FieldIO.Length > 0 Then
                    dgv_AnalogInput.Rows(i).Cells("io").Value = FieldIO
                End If
            End If
        Next

        'IO Status [Analog Output]
        For i As Integer = 0 To 5
            ' Assign Defaults
            dgv_AnalogOutput.Rows.Add(i + 1, $"Analog Output-{i + 1}", $"AIO_OUT_{i}", "0.0")

            ' Rename Fields
            If True Then
                Dim FieldIO As String = dtIOTable(i)("analog_out_io")
                Dim FieldDesc As String = dtIOTable(i)("analog_out_desc")

                If FieldDesc.Length > 0 Then
                    dgv_AnalogOutput.Rows(i).Cells("desc").Value = FieldDesc
                End If

                If FieldIO.Length > 0 Then
                    dgv_AnalogOutput.Rows(i).Cells("io").Value = FieldIO
                End If
            End If
        Next
    End Function

    Private Sub dgv_DigitalInput_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv_DigitalInput.CellPainting
        dgv_DigitalInputOutput_CustomizeCheckBox(e, dgv_DigitalInput)
    End Sub

    Private Sub dgv_DigitalOutput_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv_DigitalOutput.CellPainting
        dgv_DigitalInputOutput_CustomizeCheckBox(e, dgv_DigitalOutput)
    End Sub

    Private Sub dgv_DigitalInputOutput_CustomizeCheckBox(e As DataGridViewCellPaintingEventArgs, dgv As DataGridView)
        ' CheckBox Properties [Font Size] (In pt)
        Dim fontSize As Decimal = 9.75

        ' CheckBox Properties [Colors]
        Dim checkedColor As Color = Color.LimeGreen                 ' Default Color For CheckBox Checked
        Dim uncheckedColor As Color = SystemColors.Window           ' Default Color For CheckBox Unchecked
        Dim borderColor As Color = SystemColors.ControlDarkDark     ' Default Color For CheckBox Border

        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgv.Columns.Count - 1 AndAlso dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).ValueType Is GetType(Boolean) Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)

            Dim checkState As Boolean = CBool(e.FormattedValue)
            Dim cellBounds As Rectangle = e.CellBounds
            Dim checkBoxSize As Integer = CInt(fontSize * e.Graphics.DpiX / 72) ' Convert 9.75pt to Pixels
            Dim rectCheckBox As New Rectangle(cellBounds.X + (cellBounds.Width - checkBoxSize) \ 2, cellBounds.Y + (cellBounds.Height - checkBoxSize) \ 2, checkBoxSize, checkBoxSize)

            e.Handled = True

            ' Draw CheckBox Border
            ControlPaint.DrawBorder(e.Graphics, rectCheckBox, borderColor, ButtonBorderStyle.Solid)

            ' Fill CheckBox Based On CheckBox State
            Dim fillColor As Color = If(checkState, checkedColor, uncheckedColor)
            Using brush As New SolidBrush(fillColor)
                e.Graphics.FillRectangle(brush, rectCheckBox.X + 2, rectCheckBox.Y + 2, checkBoxSize - 4, checkBoxSize - 4)
            End Using
        End If
    End Sub

    Private Sub dgvIOStatus_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_DigitalInput.SelectionChanged, dgv_DigitalOutput.SelectionChanged, dgv_AnalogInput.SelectionChanged, dgv_AnalogOutput.SelectionChanged
        ' Declare DataGridView Cell Clicked
        Dim dgvSelectionChanged As DataGridView = DirectCast(sender, DataGridView)

        dgvSelectionChanged.ClearSelection()
    End Sub
#End Region

#Region "Device Status"
    Private Async Function InitializeDeviceStatus() As Task
        ' Remove This On Implementation
        Await Task.Delay(50)

    End Function
#End Region
#End Region

#Region "Manual Control"
    ' Valve Control
    Private Sub chkbx_ValveCtrl_CheckedChanged(sender As Object, e As EventArgs) Handles chkbx_Valve1.CheckedChanged,
        chkbx_Valve2.CheckedChanged, chkbx_Valve3.CheckedChanged, chkbx_Valve4.CheckedChanged, chkbx_Valve5.CheckedChanged, chkbx_Valve6.CheckedChanged,
        chkbx_Valve7.CheckedChanged, chkbx_Valve8.CheckedChanged, chkbx_Valve9.CheckedChanged, chkbx_Valve10.CheckedChanged, chkbx_Valve11.CheckedChanged,
        chkbx_Valve12.CheckedChanged, chkbx_Valve13.CheckedChanged, chkbx_Valve14.CheckedChanged, chkbx_Valve15.CheckedChanged, chkbx_Valve16.CheckedChanged,
        chkbx_Valve17.CheckedChanged, chkbx_Valve18.CheckedChanged, chkbx_Valve19.CheckedChanged

        ' Declare CheckBox Checked Changed
        Dim chkbxCheckedChanged As CheckBox = DirectCast(sender, CheckBox)

        ' Define CheckBox Array
        Dim chkbx_ValveCtrlArr As CheckBox() = {
            chkbx_Valve1, chkbx_Valve2, chkbx_Valve3, chkbx_Valve4, chkbx_Valve5, chkbx_Valve6, chkbx_Valve7, chkbx_Valve8,
            chkbx_Valve9, chkbx_Valve10, chkbx_Valve11, chkbx_Valve12, chkbx_Valve13, chkbx_Valve14, chkbx_Valve15, chkbx_Valve16,
            chkbx_Valve17, chkbx_Valve18, chkbx_Valve19
        }

        ' CheckBox CheckState Changed
        If chkbxCheckedChanged.Checked = False Then
            chkbxCheckedChanged.Text = "Open"
        Else
            chkbxCheckedChanged.Text = "Close"
        End If

        ' Assign IO
        For i As Integer = 0 To chkbx_ValveCtrlArr.Length - 1
            Select Case i
                Case 0

                Case 1

                Case 2

                Case 3

                Case 4

                Case 5

                Case 6

                Case 7

                Case 8

                Case 9

                Case 10

                Case 11

                Case 12

                Case 13

                Case 14

                Case 15

                Case 16

                Case 17

                Case 18

                Case 19

                Case 20

                Case 21

            End Select
        Next
    End Sub

    ' Pump & Tank Control
    Private Sub chkbx_PumpCtrl_CheckedChanged(sender As Object, e As EventArgs) Handles chkbx_ModeSelection.CheckedChanged, chkbx_PumpCtrlState.CheckedChanged
        ' Declare CheckBox Checked Changed
        Dim chkbxCheckedChanged As CheckBox = DirectCast(sender, CheckBox)

        ' Pump Mode Selection
        If chkbxCheckedChanged Is chkbx_ModeSelection Then
            ' CheckBox CheckState Changed
            If chkbx_ModeSelection.Checked = False Then
                chkbx_ModeSelection.Text = "Speed"
            Else
                chkbx_ModeSelection.Text = "Process"
            End If
        End If

        ' Pump State
        If chkbxCheckedChanged Is chkbx_PumpCtrlState Then
            ' CheckBox CheckState Changed
            If chkbx_PumpCtrlState.Checked = False Then
                chkbx_PumpCtrlState.Text = "ON"
            Else
                chkbx_PumpCtrlState.Text = "OFF"
            End If
        End If
    End Sub

    Private Sub chkbx_TankCtrl_CheckedChanged(sender As Object, e As EventArgs) Handles chkbx_TankFill.CheckedChanged, chkbx_TankDrain.CheckedChanged
        ' Declare CheckBox Checked Changed
        Dim chkbxCheckedChanged As CheckBox = DirectCast(sender, CheckBox)

        ' CheckBox CheckState Changed
        If chkbxCheckedChanged.Checked = False Then
            chkbxCheckedChanged.Text = "ON"
        Else
            chkbxCheckedChanged.Text = "OFF"
        End If
    End Sub

    ' Regulator Controls


    ' Manual Drain
    Private Sub chkbx_ManualDrain_CheckedChanged(sender As Object, e As EventArgs) Handles chkbx_N2PurgeCircuit1.CheckedChanged, chkbx_N2PurgeCircuit2.CheckedChanged, chkbx_N2PurgeCircuit3.CheckedChanged
        ' Declare CheckBox Checked Changed
        Dim chkbxCheckedChanged As CheckBox = DirectCast(sender, CheckBox)

        ' CheckBox CheckState Changed
        If chkbxCheckedChanged.Checked = False Then
            chkbxCheckedChanged.Text = "ON"
        Else
            chkbxCheckedChanged.Text = "OFF"
        End If
    End Sub

    ' Maintenance
    Private Sub chkbx_Maintenance_CheckedChanged(sender As Object, e As EventArgs) Handles chkbx_InFiltrDrain.CheckedChanged, chkbx_InFiltrVent.CheckedChanged,
        chkbx_PumpFiltrDrain.CheckedChanged, chkbx_PumpFiltrVent.CheckedChanged, chkbx_EmptyTank.CheckedChanged

        ' Declare CheckBox Checked Changed
        Dim chkbxCheckedChanged As CheckBox = DirectCast(sender, CheckBox)

        ' CheckBox CheckState Changed
        If chkbxCheckedChanged.Checked = False Then
            chkbxCheckedChanged.Text = "ON"
        Else
            chkbxCheckedChanged.Text = "OFF"
        End If
    End Sub
#End Region

#Region "Alarm"
    ' Initialize Alarm History Tab
    Private Async Function LoadAlarm() As Task
        '[Current Alarm]


        '[Alarm History]
        'LoadAlarmHistoryFilterList()

        Try
            Await LoadAlarmHistoryFilterList()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try

        AlarmHistoryFieldReset()
        LoadAlarmHistoryTable(False, Nothing, Nothing, Nothing)
    End Function

    ' Perform Action According To TabSelected
    Private Sub tabctrl_SubAlarm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabctrl_SubAlarm.SelectedIndexChanged
        If tabctrl_SubAlarm.SelectedTab Is tabpg_AlarmCurrent Then

        End If

        If tabctrl_SubAlarm.SelectedTab Is tabpg_AlarmHistory Then
            dgvClearSelection(dgv_AlarmHistory)
        End If
    End Sub

#Region "Current Alarm"

#End Region

#Region "Alarm History"
    Private Async Function LoadAlarmHistoryFilterList() As Task
        ' Lot ID
        If True Then
            Dim comboSource As New Dictionary(Of String, String)()

            ' Assign Defaults
            comboSource.Add("0", "-Not Selected-")

            ' Get Recipe Table
            'Dim dtRecipeTable As DataTable = SQL.ReadRecords("SELECT id, code FROM AlarmTable")
            Dim dvGetRecord As DataView = Await Task.Run(Function() SQL.ReadRecords("SELECT alarm_code FROM AlarmHistory").DefaultView)

            ' Sort Recipe Table
            dvGetRecord.Sort = "alarm_code" & " ASC"

            ' Get Unique Records
            Dim dtRecipeTable As DataTable = dvGetRecord.ToTable(True, "alarm_code")

            ' Insert Available Record Into Dictionary
            If dtRecipeTable.Rows.Count > 0 Then
                For i As Integer = 0 To dtRecipeTable.Rows.Count - 1
                    'comboSource.Add(dtRecipeTable(i)("id"), dtRecipeTable(i)("code"))
                    comboSource.Add(i + 1, dtRecipeTable(i)("alarm_code"))
                Next
            End If

            ' Bind ComboBox To Dictionary
            For Each cmbx As ComboBox In {cmbx_AlarmCode}
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
    End Function

    ' Reset Search & Filter Fields
    Private Sub AlarmHistoryFieldReset()
        ' Reset DateTimePicker
        For Each dtpicker As DateTimePicker In {dtpicker_AlarmEndDate}
            dtpicker.Value = DateTime.Now
        Next

        ' Reset ComboBox
        If cmbx_AlarmCode.Items.Count > 0 Then
            cmbx_AlarmCode.SelectedIndex = 0
        End If
    End Sub

    ' Button Clicked Event [Reset] [Search] [Export]
    Private Sub btnAlarmHistory_Click(sender As Object, e As EventArgs) Handles btn_AlarmReset.Click, btn_AlarmSearch.Click, btn_AlarmExport.Click
        ' Declare Button Clicked
        Dim btnClicked As Button = DirectCast(sender, Button)

        ' Remove Selection Highlight
        lbl_Title.Select()

        ' Button Reset
        If btnClicked Is btn_AlarmReset Then
            AlarmHistoryFieldReset()
            LoadAlarmHistoryTable(False, Nothing, Nothing, Nothing)
        End If

        ' Button Search
        If btnClicked Is btn_AlarmSearch Then
            SearchAlarmHistory()
        End If

        ' Button Export
        If btnClicked Is btn_AlarmExport Then
            ExportAlarmHistory()
        End If
    End Sub

    ' Populate DataGridView From SQL Tables
    Private Async Sub LoadAlarmHistoryTable(containSearch As Boolean, dtStart As DateTime, dtEnd As DateTime, cmbxAlarmCode As ComboBox)
        ' Define SQL String
        Dim sqlString As String = "
        SELECT row_number() OVER (ORDER BY AlarmHistory.trigger_time DESC) AS no,
            AlarmHistory.id, 
            AlarmHistory.trigger_time, 
            AlarmHistory.reset_time, 
            AlarmTable.description, 
            AlarmHistory.alarm_code 
        FROM AlarmHistory 
        LEFT JOIN AlarmTable ON AlarmHistory.alarm_code=AlarmTable.code 
        ORDER BY AlarmHistory.trigger_time DESC
        "

        ' Populate Datatable From SQL Query
        Dim dtAlarmTable As DataTable = Await Task.Run(Function() SQL.ReadRecords(sqlString))   'SQL.ReadRecords(sqlString)

        ' Search
        If containSearch = True Then
            ' Convert To DataView Table
            Dim dvAlarmTable As DataView = dtAlarmTable.DefaultView

            ' Declare FilterList Array
            Dim FilterList As New List(Of String)

            ' Check ComboBox Selection
            Dim cmbx As ComboBox = cmbxAlarmCode
            If cmbx.Items.Count > 0 AndAlso cmbx.SelectedIndex > 0 Then
                Dim selectedValue As String = DirectCast(cmbx.SelectedItem, KeyValuePair(Of String, String)).Value
                Dim cellValue As String = ""
                FilterList.Add($"alarm_code='{selectedValue}'")
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
            dvAlarmTable.RowFilter = FilterString

            ' Bind To DataGridView DataSource
            dgv_AlarmHistory.DataSource = dvAlarmTable.ToTable
        Else
            ' Bind To DataGridView DataSource
            dgv_AlarmHistory.DataSource = dtAlarmTable

            ' Set dtStart [DateTimePicker] To Earliest Record
            If dtAlarmTable.Rows.Count > 0 Then
                dtpicker_AlarmStartDate.Value = dtAlarmTable(dtAlarmTable.Rows.Count - 1)("trigger_time")
            Else
                dtpicker_AlarmStartDate.Value = DateTime.Now
            End If
        End If

        With dgv_AlarmHistory
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
            .Columns("trigger_time").HeaderCell.Value = "Trigger Time"
            .Columns("reset_time").HeaderCell.Value = "Reset Time"
            .Columns("description").HeaderCell.Value = "Description"
            .Columns("alarm_code").HeaderCell.Value = "Alarm Code"

            ' Set Column Properties
            .Columns("description").Width = 1000 '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            With .Columns("trigger_time")
                .DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Width = 140
            End With
            With .Columns("reset_time")
                .DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Width = 140
            End With
            '.Columns("description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("alarm_code").Width = 200
        End With

        ' Clear Selection
        dgvClearSelection(dgv_AlarmHistory)

        ' Prompt When No Result Returns
        If containSearch = True Then
            If Not dgv_AlarmHistory.RowCount > 0 Then
                MsgBox("Search Result Returned Empty.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Information")
            End If
        End If
    End Sub

    ' Remove DataGridView Selection When Not In Focus
    Private Sub dgv_AlarmHistory_LostFocus(sender As Object, e As EventArgs)
        dgvClearSelection(dgv_AlarmHistory)
    End Sub

    ' Search Alarm History
    Private Sub SearchAlarmHistory()
        ' Load Table With Filters
        LoadAlarmHistoryTable(True, dtpicker_AlarmStartDate.Value, dtpicker_AlarmEndDate.Value, cmbx_AlarmCode)
    End Sub

    ' Export Alarm History
    Private Async Sub ExportAlarmHistory()
        ' Convert Visible DataGridView Columns To DataTable
        Dim dt As DataTable = Await Task.Run(Function() GetVisibleColumnsDataTable(dgv_AlarmHistory))   'GetVisibleColumnsDataTable(dgv_AlarmHistory)

        ' Get Path
        'Dim dtGetPath As DataTable = Await Task.Run(Function() SQL.ReadRecords($"SELECT id, description, retained_value FROM [0_RetainedMemory] WHERE id={9}"))
        Dim ExportPath As String = PublicVariables.CSVPathToAlarmHistory 'dtGetPath(0)("retained_value")

        ' Export With Return
        Dim ReturnValue As String = ExportDataTableToCsv(dt, ExportPath & $"AlarmHistory_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv", PublicVariables.CSVDelimiterAlarmHistory)

        ' Check Return State
        If ReturnValue = "True" Then
            MsgBox("CSV File Exported Successfully.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Export - Success")
        ElseIf ReturnValue = "Missing" Then
            MsgBox("Invalid File Path Specified.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Export - Path Error")
        ElseIf ReturnValue = "False" Then
            MsgBox("Unable To Export CSV File, Please Try Again.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Export - Failed")
        End If
    End Sub

    ' Check DateTimePicker Selection
    Private Sub dtpicker_AlarmDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker_AlarmStartDate.ValueChanged, dtpicker_AlarmEndDate.ValueChanged
        ' Validation Check To Ensure Start Date IsNot > End Date
        If dtpicker_AlarmStartDate.Value > dtpicker_AlarmEndDate.Value Then
            dtpicker_AlarmEndDate.Value = dtpicker_AlarmStartDate.Value
        End If
    End Sub

#End Region


#End Region


#Region "Main Message"
    Public Function MainMessage(a As Integer, Optional str As String = "") As MsgBoxResult
        Select Case a
            Case 1
                Return MsgBox($"{str} Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 2
                Return MsgBox($"Required {str}, Please Scan again", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 3
                Return MsgBox($"Lot ID Accepted and Registered", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 4
                Return MsgBox($"Query to {str} was unsuccessful, Try again", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 5
                Return MsgBox($"Production Recipes not found for {str},Create Recipe and Proceed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 6
                Return MsgBox($"Special Characters not allowed in {str}, Scan and Try Again", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 7
                Return MsgBox($"Lot ID found with different data {str}, Check and Try Again", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 8
                Return MsgBox($"Are You sure to End Lot {str}?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning")
            Case 9
                Return MsgBox($"Lot {str} End successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 10
                Return MsgBox($"Query unsuccessful, Lot End data not registered", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 11
                Return MsgBox($"Are You Sure, Do you want to Abort/Discard Calibration?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning")
            Case Else
                Exit Select

        End Select
        Return 0
    End Function

#End Region


#Region "Main Menu Content"

    Private Sub btn_WrkOrdScnDtConfirm_Click(sender As Object, e As EventArgs) Handles btn_WrkOrdScnDtConfirm.Click
        Dim OnContinue As Boolean = True
        Workorder = FormRecipeManagement.Formatstring(txtbx_WorkOrderNumber.Text)
        LotID = FormRecipeManagement.Formatstring(txtbx_LotID.Text)
        PartID = FormRecipeManagement.Formatstring(txtbx_PartID.Text)
        ConfirmationID = FormRecipeManagement.Formatstring(txtbx_ConfirmationID.Text)
        Quantity = FormRecipeManagement.Formatstring(txtbx_Quantity.Text)

        'Empty box check
        If OnContinue = True Then
            If Workorder.Length = 0 Then
                MainMessage(1, "Work Order")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If LotID.Length = 0 Then
                MainMessage(1, "Lot ID")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If PartID.Length = 0 Then
                MainMessage(1, "Part ID")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If ConfirmationID.Length = 0 Then
                MainMessage(1, "Confirmation ID")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If Quantity.Length = 0 Then
                MainMessage(1, "Quantity")
                OnContinue = False
            End If
        End If

        'Check whether the scanned data meeting the Character length Criteria
        If OnContinue = True Then
            If Workorder.Length <> PublicVariables.WorkOrderLen Then
                MainMessage(2, $"Character(s) length for Work Order is {PublicVariables.WorkOrderLen} ")
                OnContinue = False
            End If
        End If

        'Check whether the scanned data has special character
        If OnContinue = True Then
            If FormRecipeManagement.Checkspecial(Workorder) <> -1 Then
                MainMessage(6, $"Work Order")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If LotID.Length <> PublicVariables.LotIdLen Then
                MainMessage(2, $"Character(s) length for Lot ID is {PublicVariables.LotIdLen} ")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If FormRecipeManagement.Checkspecial(LotID) <> -1 Then
                MainMessage(6, $"Lot ID")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If PartID.Length <> PublicVariables.PartIdLen Then
                MainMessage(2, $"Character(s) length for Part ID is {PublicVariables.PartIdLen} ")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If FormRecipeManagement.Checkspecial(PartID) <> -1 Then
                MainMessage(6, $"Part ID")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If ConfirmationID.Length <> PublicVariables.ConfirmationIdLen Then
                MainMessage(2, $"Character(s) length for Confirmation ID is {PublicVariables.ConfirmationIdLen} ")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If FormRecipeManagement.Checkspecial(ConfirmationID) <> -1 Then
                MainMessage(6, $"Confirmation ID")
                OnContinue = False
            End If
        End If

        If OnContinue = True Then
            If Quantity.Length <> PublicVariables.QuantityLen Then
                MainMessage(2, $"Character(s) length for Quantity is {PublicVariables.QuantityLen} ")
                OnContinue = False
            End If
        End If


        If OnContinue = True Then
            If FormRecipeManagement.Checkspecial(Quantity) <> -1 Then
                MainMessage(6, $"Quantity")
                OnContinue = False
            End If
        End If



        If OnContinue = True Then
            If IsNumeric(Quantity) = False Then
                MainMessage(2, $"Quantity as Integer")
                OnContinue = False
            Else
                If CType(Quantity, Integer) = 0 Then
                    MainMessage(2, $"Quantity Value greater than Zero")
                    OnContinue = False
                End If
            End If
        End If

        'Check whether the Part ID has Production Recipe and load Type combobox
        If OnContinue = True Then
            Dim TypecomboSource As New Dictionary(Of String, String)()

            ' To Get Values From Dictionary (Example)
            'DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key | Value

            'Assign Defaults
            TypecomboSource.Add("0", "-Not Selected-")

            ' Get User Category Table
            Dim dtRecipeTable As DataTable = SQL.ReadRecords($"SELECT   RecipeTable.id,RecipeTable.recipe_id, RecipeType.recipe_type,RecipeTable.part_id FROM RecipeTable
                            INNER JOIN RecipeType ON RecipeTable.recipe_type_id= RecipeType.id AND part_id = '{PartID}'")
            dtRecipeID = dtRecipeTable
            ' Insert Available Record Into Dictionary
            If dtRecipeTable.Rows.Count > 0 Then
                Dim type As DataTable = dtRecipeTable.DefaultView.ToTable(True, "recipe_type")

                For i As Integer = 0 To type.Rows.Count - 1
                    If LoginUserCategoryName = "Production" Then
                        If type(i)("recipe_type") <> "Evaluation" And type(i)("recipe_type") <> "Engineering" Then
                            TypecomboSource.Add(i + 1, type(i)("recipe_type"))
                        End If
                    End If
                    If LoginUserCategoryName = "Technician" Then
                        If type(i)("recipe_type") <> "Engineering" Then
                            TypecomboSource.Add(i + 1, type(i)("recipe_type"))
                        End If
                    End If
                    If LoginUserCategoryName = "Engineer" Or LoginUserCategoryName = "Administrator" Or LoginUserCategoryName = "Developer" Then

                        TypecomboSource.Add(i + 1, type(i)("recipe_type"))


                    End If
                Next

            End If

            ' Bind ComboBox To Dictionary
            For Each RecipeTypecmbx As ComboBox In {cmbx_RecipeType}
                With RecipeTypecmbx
                    .DataSource = New BindingSource(TypecomboSource, Nothing)
                    .DisplayMember = "Value"
                    .ValueMember = "Key"
                    If .Items.Count > 0 Then
                        .SelectedIndex = 0
                    End If

                    If .Items.Count > 1 Then
                    Else
                        MainMessage(5, PartID)
                        OnContinue = False
                    End If
                End With
            Next
        End If


        'Insert New record into the Work Order Table
        If OnContinue = True Then
            Dim dtlot As DataTable = SQL.ReadRecords($"SELECT * FROM WorkOrder WHERE lot_id ='{LotID}'")
            If OnContinue = True Then
                If dtlot.Rows.Count = 0 Then
                    Dim Workorderparameter As New Dictionary(Of String, Object) From {
                    {"lot_id", LotID},
                        {"work_order", Workorder},
                        {"part_id", PartID},
                        {"confirmation_id", ConfirmationID},
                        {"quantity", Quantity}
                    }
                    If SQL.InsertRecord("WorkOrder", Workorderparameter) = 1 Then

                        LotStartTime = lbl_DateTimeClock.Text
                    Else
                        MainMessage(4, "Insert Work Order details")
                        OnContinue = False
                    End If
                End If
            End If

            'Insert New record into the Lot Usage Table
            If OnContinue = True Then
                If dtlot.Rows.Count > 0 Then
                    If dtlot.Rows(0)("part_id") = PartID And dtlot.Rows(0)("confirmation_id") = ConfirmationID And dtlot.Rows(0)("work_order") = Workorder Then
                        Dim dtlotusage As DataTable = SQL.ReadRecords($"SELECT lot_id,lot_attempt FROM LotUsage WHERE lot_id ='{LotID}' ORDER BY lot_attempt ASC")
                        If dtlotusage.Rows.Count > 0 Then
                            LotAttempt = dtlotusage.Rows.Count + 1
                            LotStartTime = lbl_DateTimeClock.Text
                        Else
                            LotAttempt = 1
                        End If
                    Else
                        MainMessage(7, $" {dtlot.Rows(0)("work_order")}, {dtlot.Rows(0)("part_id")}, {dtlot.Rows(0)("confirmation_id")} ")
                        OnContinue = False
                    End If

                Else
                    LotAttempt = 1
                End If
            End If

            If OnContinue = True Then
                Dim Lotusageparameter As New Dictionary(Of String, Object) From {
                    {"lot_id", LotID},
                        {"lot_attempt", LotAttempt},
                        {"lot_start_time", LotStartTime},
                        {"run_by", PublicVariables.LoginUserName}
                    }
                If SQL.InsertRecord("LotUsage", Lotusageparameter) = 1 Then
                    MainMessage(3)
                    txtbx_WorkOrderNumber.Enabled = False
                    txtbx_LotID.Enabled = False
                    txtbx_PartID.Enabled = False
                    txtbx_ConfirmationID.Enabled = False
                    txtbx_Quantity.Enabled = False
                    btn_WrkOrdScnDtConfirm.Enabled = False
                    btn_WrkOrdScnDtEndLot.Enabled = True
                    txtbx_Operatorlotid.Text = LotID
                Else
                    MainMessage(4, "Insert Lot Usage details")
                    OnContinue = False
                End If
            End If


            If OnContinue = True Then

                cmbx_RecipeType.Enabled = True

            End If


        End If

    End Sub


    Private Sub btn_WrkOrdScnDtEndLot_Click(sender As Object, e As EventArgs) Handles btn_WrkOrdScnDtEndLot.Click
        Dim OnContinue As Boolean = True
        If OnContinue = True Then
            LotEndTime = lbl_DateTimeClock.Text

            Dim Updateparameter As New Dictionary(Of String, Object) From {
                {"lot_end_time", LotEndTime}
                }
            Dim Condition As String = $"lot_id ='{LotID}' AND lot_attempt = '{LotAttempt}'"
            If MainMessage(8, LotID) = DialogResult.Yes Then
                If SQL.UpdateRecord("LotUsage", Updateparameter, Condition) = 1 Then
                    MainMessage(9, LotID)
                Else
                    MainMessage(10)
                    OnContinue = False
                End If
            Else
                OnContinue = False
            End If
        End If

        If OnContinue = True Then

            txtbx_WorkOrderNumber.Enabled = True
            txtbx_LotID.Enabled = True
            txtbx_PartID.Enabled = True
            txtbx_ConfirmationID.Enabled = True
            txtbx_Quantity.Enabled = True
            btn_WrkOrdScnDtConfirm.Enabled = True
            btn_WrkOrdScnDtEndLot.Enabled = False
            txtbx_WorkOrderNumber.Text = Nothing
            txtbx_LotID.Text = Nothing
            txtbx_PartID.Text = Nothing
            txtbx_ConfirmationID.Text = Nothing
            txtbx_Quantity.Text = Nothing
            txtbx_TitleRecipeID.Text = Nothing
            txtbx_TitlePartID.Text = Nothing
            txtbx_TitleFilterType.Text = Nothing
            btn_RecipeSelectionConfirm.Enabled = False
            txtbx_Operatorlotid.Text = Nothing
            If cmbx_RecipeType.SelectedIndex > 0 Then
                cmbx_RecipeType.SelectedIndex = 0
            End If

            If cmbx_RecipeID.SelectedIndex > 0 Then
                cmbx_RecipeID.SelectedIndex = 0
            End If
            cmbx_RecipeType.Enabled = False

            cmbx_RecipeID.Enabled = False
        End If

        If OnContinue = True Then

            Workorder = Nothing
            LotID = Nothing
            PartID = Nothing
            ConfirmationID = Nothing
            Quantity = Nothing
            RecipeID = Nothing
            LotStartTime = Nothing
            LotEndTime = Nothing
            LotAttempt = 0
            dtRecipeID = Nothing
            FormCalibration.Cal_samplingtime = 0
            FormCalibration.Cal_temperature = 0
            FormCalibration.Cal_inletpressure = 0
            FormCalibration.Cal_outletpressure = 0
            FormCalibration.Cal_flowrate = 0
            FormCalibration.Cal_dp = 0

            FormCalibration.Ver_samplingtime = 0
            FormCalibration.Ver_temperature = 0
            FormCalibration.Ver_inletpressure = 0
            FormCalibration.Ver_outletpressure = 0
            FormCalibration.Ver_flowrate = 0
            FormCalibration.Ver_dp = 0
            FormCalibration.vertol = 0
            FormCalibration.Dpteststart = 0
            FormCalibration.dptestend = 0
            FormCalibration.Cal_dptestpoints = 0
            FormCalibration.Cal_avginlet = 0
            FormCalibration.Cal_avgoutlet = 0
            FormCalibration.Cal_offset = 0
            FormCalibration.Ver_avginlet = 0
            FormCalibration.Ver_avgoutlet = 0
            FormCalibration.Ver_avgdp = 0

            FormCalibration.txtbx_CalInletPressure.Text = Nothing
            FormCalibration.txtbx_CalOutletPressure.Text = Nothing
            FormCalibration.txtbx_CalOffset.Text = Nothing
            FormCalibration.txtbx_CalResult.Text = Nothing
            FormCalibration.txtbx_VerInletPressure.Text = Nothing
            FormCalibration.txtbx_VerOutletPressure.Text = Nothing
            FormCalibration.txtbx_VerDP.Text = Nothing
            FormCalibration.txtbx_VerStatus.Text = Nothing
            FormCalibration.txtbx_VerStatus.BackColor = SystemColors.Window
            FormCalibration.txtbx_CalResult.BackColor = SystemColors.Window
            FormCalibration.dgv_CalibrationResult.DataSource = Nothing
            FormCalibration.dgv_VerificationResult.DataSource = Nothing

        End If

    End Sub

    Private Sub cmbx_RecipeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_RecipeType.SelectedIndexChanged
        Dim Type As String = cmbx_RecipeType.Text
        Dim RecipecomboSource As New Dictionary(Of String, String)()

        ' To Get Values From Dictionary (Example)
        'DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key | Value

        'Assign Defaults
        RecipecomboSource.Add("0", "-Not Selected-")

        ' Insert Available Record Into Dictionary
        If dtRecipeID.Rows.Count > 0 Then
            For i As Integer = 0 To dtRecipeID.Rows.Count - 1
                If dtRecipeID(i)("recipe_type") = Type Then
                    RecipecomboSource.Add(dtRecipeID(i)("id"), dtRecipeID(i)("recipe_id"))
                End If
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each Recipecmbx As ComboBox In {cmbx_RecipeID}
            With Recipecmbx
                .DataSource = New BindingSource(RecipecomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next
        If cmbx_RecipeType.SelectedIndex > 0 Then
            cmbx_RecipeID.Enabled = True
        Else
            cmbx_RecipeID.Enabled = False
        End If
    End Sub

    Private Sub cmbx_RecipeID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_RecipeID.SelectedIndexChanged
        If cmbx_RecipeID.SelectedIndex > 0 Then
            btn_RecipeSelectionConfirm.Enabled = True
        Else
            btn_RecipeSelectionConfirm.Enabled = False
        End If
    End Sub



    Private Sub btn_RecipeSelectionConfirm_Click(sender As Object, e As EventArgs) Handles btn_RecipeSelectionConfirm.Click
        RecipeID = cmbx_RecipeID.Text
        cmbx_RecipeID.Enabled = False
        cmbx_RecipeType.Enabled = False
        btn_RecipeSelectionConfirm.Enabled = False
        txtbx_TitleRecipeID.Text = cmbx_RecipeID.Text
        txtbx_TitlePartID.Text = PartID
        Dim dtfilter As DataTable = SQL.ReadRecords($"SELECT PartTable.filter_type_id, FilterType.filter_type, PartTable.jig_type_id, JigType.jig_description From PartTable
INNER JOIN FilterType ON PartTable.filter_type_id = FilterType.id AND PartTable.part_id='{PartID}' INNER JOIN JigType ON PartTable.jig_type_id = JigType.id")
        txtbx_TitleFilterType.Text = dtfilter.Rows(0)("filter_type")

        LoadrecipeParameters(RecipeID)

        FormCalibration.ShowDialog()
    End Sub

    Private Sub lbl_CalibrationStatus_TextChanged(sender As Object, e As EventArgs) Handles lbl_CalibrationStatus.TextChanged
        If lbl_CalibrationStatus.Text = "Pass" Then
            txtbx_SerialNumber.Enabled = True
            btn_OprKeyInDtConfirm.Enabled = True
        End If
    End Sub

    Private Sub lbl_OperationMode_Click(sender As Object, e As EventArgs) Handles lbl_OperationMode.Click
        Form1.Show()
    End Sub

    Private Sub dtpicker_StartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker_StartDate.ValueChanged

    End Sub




#End Region

#Region "Load Recipe Data to PLC"

    Public Sub LoadrecipeParameters(Recipe As String)

        Dim dtrecipe As DataTable = SQL.ReadRecords($"SELECT * From RecipeTable WHERE recipe_id ='{Recipe}'")

        If dtrecipe.Rows.Count > 0 Then
            IMEIPWriteFloat(30, CType(dtrecipe.Rows(0)("verification_tolerance"), Double))

            IMEIPWriteFloat(32, CType(dtrecipe.Rows(0)("firstflush_flowrate"), Double))
            IMEIPWriteFloat(34, CType(dtrecipe.Rows(0)("firstflush_flow_tolerance"), Double))
            IMEIPWriteFloat(36, CType(dtrecipe.Rows(0)("firstflush_back_pressure"), Double))

            IMEIPWriteFloat(38, CType(dtrecipe.Rows(0)("dp_flowrate"), Double))
            IMEIPWriteFloat(40, CType(dtrecipe.Rows(0)("dp_flow_tolerance"), Double))
            IMEIPWriteFloat(42, CType(dtrecipe.Rows(0)("dp_back_pressure"), Double))

            IMEIPWriteFloat(44, CType(dtrecipe.Rows(0)("dp_lowerlimit"), Double))
            IMEIPWriteFloat(46, CType(dtrecipe.Rows(0)("dp_upperlimit"), Double))

            IMEIPWriteFloat(48, CType(dtrecipe.Rows(0)("secondflush_flowrate"), Double))
            IMEIPWriteFloat(50, CType(dtrecipe.Rows(0)("secondflush_flow_tolerance"), Double))
            IMEIPWriteFloat(52, CType(dtrecipe.Rows(0)("secondflush_back_pressure"), Double))

            IMEIPWriteFloat(54, CType(dtrecipe.Rows(0)("drain1_back_pressure"), Double))

            IMEIPWriteFloat(56, CType(dtrecipe.Rows(0)("drain2_back_pressure"), Double))

            IMEIPWriteFloat(58, CType(dtrecipe.Rows(0)("drain3_back_pressure"), Double))


            If dtrecipe.Rows(0)("firstflush_circuit") = "Enable" Then
                IMEIPWriteInt(60, 1)
            Else
                IMEIPWriteInt(60, 0)
            End If
            IMEIPWriteInt(62, CType(dtrecipe.Rows(0)("firstflush_fill_time"), Integer))
            IMEIPWriteInt(64, CType(dtrecipe.Rows(0)("firstflush_bleed_time"), Integer))
            IMEIPWriteInt(66, CType(dtrecipe.Rows(0)("firstflush_stabilize_time"), Integer))
            IMEIPWriteInt(68, CType(dtrecipe.Rows(0)("firstflush_time"), Integer))

            If dtrecipe.Rows(0)("firstdp_circuit") = "Enable" Then
                IMEIPWriteInt(70, 1)
            Else
                IMEIPWriteInt(70, 0)
            End If

            If dtrecipe.Rows(0)("seconddp_circuit") = "Enable" Then
                IMEIPWriteInt(72, 1)
            Else
                IMEIPWriteInt(72, 0)
            End If
            IMEIPWriteInt(74, CType(dtrecipe.Rows(0)("dp_fill_time"), Integer))
            IMEIPWriteInt(76, CType(dtrecipe.Rows(0)("dp_bleed_time"), Integer))
            IMEIPWriteInt(78, CType(dtrecipe.Rows(0)("dp_stabilize_time"), Integer))
            IMEIPWriteInt(80, CType(dtrecipe.Rows(0)("dp_test_time"), Integer))
            IMEIPWriteInt(82, CType(dtrecipe.Rows(0)("dp_testpoints"), Integer))

            If dtrecipe.Rows(0)("secondflush_circuit") = "Enable" Then
                IMEIPWriteInt(84, 1)
            Else
                IMEIPWriteInt(84, 0)
            End If
            IMEIPWriteInt(86, CType(dtrecipe.Rows(0)("secondflush_fill_time"), Integer))
            IMEIPWriteInt(88, CType(dtrecipe.Rows(0)("secondflush_bleed_time"), Integer))

            IMEIPWriteInt(90, CType(dtrecipe.Rows(0)("secondflush_stabilize_time"), Integer))
            IMEIPWriteInt(92, CType(dtrecipe.Rows(0)("secondflush_time"), Integer))


            If dtrecipe.Rows(0)("drain1_circuit") = "Enable" Then
                IMEIPWriteInt(94, 1)
            Else
                IMEIPWriteInt(94, 0)
            End If
            IMEIPWriteInt(96, CType(dtrecipe.Rows(0)("drain1_time"), Integer))

            If dtrecipe.Rows(0)("drain2_circuit") = "Enable" Then
                IMEIPWriteInt(98, 1)
            Else
                IMEIPWriteInt(98, 0)
            End If
            IMEIPWriteInt(100, CType(dtrecipe.Rows(0)("drain2_time"), Integer))


            If dtrecipe.Rows(0)("drain3_circuit") = "Enable" Then
                IMEIPWriteInt(102, 1)
            Else
                IMEIPWriteInt(102, 0)
            End If
            IMEIPWriteInt(104, CType(dtrecipe.Rows(0)("drain3_time"), Integer))

        End If


    End Sub




#End Region

End Class



'Dim dt As DataTable = SQL.ReadRecords("SELECT id, serial_uid FROM ProductionDetail")

'For Each row As DataRow In dt.Rows

'    Dim updateParameters As New Dictionary(Of String, Object) From {
'        {"serial_number", CStr(row.Item("serial_uid")).Substring(CStr(row.Item("serial_uid")).Length - 3)}
'    }
'    SQL.UpdateRecord("ProductionDetail", updateParameters, $"id='{row.Item("id")}'")
'Next
