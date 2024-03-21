﻿Imports System.ComponentModel
Imports System.Media

Public Class FormResultSummary
    Public Resultsummaryexportpath As String = PublicVariables.Resultexportpath

#Region "Form Loading"
    Private Sub FormResultSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Always Maximize
        Me.WindowState = FormWindowState.Maximized

        ' Load Version
        lbl_Version.Text = PublicVariables.AppVersion

        ' Load Form Title
        Me.Text = PublicVariables.ProgramTitle & " - " & "Individual Result Summary"
        lbl_Title.Text = PublicVariables.ProgramTitle

        ' Load User Details
        lbl_Username.Text = PublicVariables.LoginUserName
        lbl_Category.Text = PublicVariables.LoginUserCategoryName

        ' DoubleBuffer DataGridView
        Dim dgvArr() As DataGridView = {
            dgv_Resultsummary
        }
        For Each dgv As DataGridView In dgvArr
            DoubleBuffer.DoubleBuffered(dgv, True)
        Next

        ' Initialize Defaults
        dgv_Resultsummary.DataSource = Nothing
        txtbx_ResultTimestamp.Text = Nothing
        txtbx_ResultWorkOrder.Text = Nothing

        txtbx_ResultPartID.Text = Nothing
        txtbx_ResultConfirmation.Text = Nothing
        txtbx_ResultRecipeID.Text = Nothing
        txtbx_ResultRecipeIDRev.Text = Nothing
        txtbx_ResultCalOffset.Text = Nothing
        txtbx_ResultTemperature.Text = Nothing
        txtbx_ResultFlowrate.Text = Nothing
        txtbx_ResultInletPressure.Text = Nothing
        txtbx_ResultOutletPressure.Text = Nothing
        txtbx_ResultDiffPressure.Text = Nothing
        txtbx_ResultTest.Text = Nothing
        txtbx_Resultflush1.Text = Nothing
        txtbx_ResultDPTest1.Text = Nothing
        txtbx_Resultflush2.Text = Nothing
        txtbx_ResultDPTest2.Text = Nothing
        txtbx_ResultDrain1.Text = Nothing
        txtbx_ResultDrain2.Text = Nothing
        txtbx_ResultDrain3.Text = Nothing
        txtbx_ResultSerialUID.Text = Nothing
        txtbx_Resultattempt.Text = Nothing

        ' Get User Category Table
        Dim dtdefaultRecord As DataTable = SQL.ReadRecords($"SELECT DISTINCT serial_usage_id FROM ProductResult ORDER BY serial_usage_id DESC")
        Dim lastrecord As String = dtdefaultRecord.Rows(0)("serial_usage_id").ToString
        Dim dtdefaultdetail As DataTable = SQL.ReadRecords($"SELECT * FROM ProductionDetail 
                  LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id = Lotusage.id
                  WHERE ProductionDetail.id ='{lastrecord}' ")

        If dtdefaultdetail.Rows.Count > 0 Then
            Dim lastrecordlot = dtdefaultdetail.Rows(0)("lot_id")
            Dim Lastrecordserialnum = dtdefaultdetail.Rows(0)("serial_number")
            Dim lastrecordserialattmept = dtdefaultdetail.Rows(0)("serial_attempt")
            LoadResult(lastrecordlot, Lastrecordserialnum, lastrecordserialattmept)
        End If





        GetLotid()
        btn_ResultExport.Enabled = True


    End Sub

    Private Sub FormResultSummary_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear Selection
        Me.Select()

        ' Display Form Control
        panel_FormControl.Visible = True
    End Sub
#End Region


#Region "Combobox Data"
    Private Sub GetLotid()
        Dim LotcomboSource As New Dictionary(Of String, String)()

        ' To Get Values From Dictionary (Example)
        'DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key | Value

        ' Assign Defaults
        LotcomboSource.Add("0", "-Not Selected-")
        Dim dvGetRecord As DataView = SQL.ReadRecords($"SELECT DISTINCT ProductResult.serial_usage_id,Lotusage.lot_id FROM ProductResult INNER JOIN ProductionDetail ON ProductionDetail.id = ProductResult.serial_usage_id INNER JOIN LotUsage ON Lotusage.id=ProductionDetail.lot_usage_id").DefaultView
        ' Sort Recipe Table
        dvGetRecord.Sort = "serial_usage_id " & "DESC"


        ' Get User Category Table
        Dim dtLotid As DataTable = dvGetRecord.ToTable(True, "lot_id")

        ' Insert Available Record Into Dictionary
        If dtLotid.Rows.Count > 0 Then
            For i As Integer = 0 To dtLotid.Rows.Count - 1
                LotcomboSource.Add(i + 1, dtLotid(i)("lot_id"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each Lotcmbx As ComboBox In {cmbx_ResultSearchLot}
            With Lotcmbx
                .DataSource = New BindingSource(LotcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next
    End Sub



    Private Sub cmbx_ResultSearchLot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_ResultSearchLot.SelectedIndexChanged
        Dim SerialcomboSource As New Dictionary(Of String, String)()
        Dim Lotid As String = cmbx_ResultSearchLot.Text

        ' To Get Values From Dictionary (Example)
        'DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key | Value

        ' Assign Defaults
        SerialcomboSource.Add("0", "-Not Selected-")


        ' Get Production Detail Table
        Dim dvGetRecord As DataView = SQL.ReadRecords($"SELECT serial_number, lot_usage_id FROM ProductionDetail LEFT JOIN LotUsage ON ProductionDetail.lot_usage_id=Lotusage.id Where lot_id = '{Lotid} '").DefaultView
        ' Sort Recipe Table
        dvGetRecord.Sort = "serial_number" & " ASC"

        ' Get Unique Records
        '.toTable(distinct as boolean, Column name)
        Dim dtSerialid As DataTable = dvGetRecord.ToTable(True, "serial_number")

        ' Insert Available Record Into Dictionary
        If dtSerialid.Rows.Count > 0 Then
            For i As Integer = 0 To dtSerialid.Rows.Count - 1
                SerialcomboSource.Add(i + 1, dtSerialid(i)("serial_number"))
            Next

        End If


        ' Bind ComboBox To Dictionary
        For Each Serialcmbx As ComboBox In {cmbx_ResultSearchSerial}
            With Serialcmbx
                .DataSource = New BindingSource(SerialcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next

        If cmbx_ResultSearchLot.SelectedIndex > 0 Then
            If cmbx_ResultSearchSerial.Items.Count <= 1 Then
                ResultMessage(8)
            End If
            cmbx_ResultSearchSerial.Enabled = True
        Else
            cmbx_ResultSearchSerial.Enabled = False
        End If
    End Sub



    Private Sub cmbx_ResultSearchSerial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_ResultSearchSerial.SelectedIndexChanged
        Dim AttemptcomboSource As New Dictionary(Of String, String)()
        Dim Lotid As String = cmbx_ResultSearchLot.Text
        Dim Lotusageid As Integer = cmbx_ResultSearchLot.SelectedIndex
        Dim serialnum As String = cmbx_ResultSearchSerial.Text

        ' To Get Values From Dictionary (Example)
        'DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key | Value

        ' Assign Defaults
        AttemptcomboSource.Add("0", "-Not Selected-")


        ' Get Production Detail Table
        Dim dvGetRecord As DataView = SQL.ReadRecords($"SELECT id, serial_attempt FROM ProductionDetail Where serial_uid = '{Lotid}-{serialnum}'").DefaultView
        ' Sort Recipe Table
        dvGetRecord.Sort = "serial_attempt" & " ASC"

        ' Get Unique Records
        '.toTable(distinct as boolean, Column name)
        Dim dtAttemptid As DataTable = dvGetRecord.ToTable(True, "id", "serial_attempt")

        ' Insert Available Record Into Dictionary
        If dtAttemptid.Rows.Count > 0 Then
            For i As Integer = 0 To dtAttemptid.Rows.Count - 1
                AttemptcomboSource.Add(i + 1, dtAttemptid(i)("serial_attempt"))
            Next

        End If


        ' Bind ComboBox To Dictionary
        For Each Attemptcmbx As ComboBox In {cmbx_ResultSearchAttempt}
            With Attemptcmbx
                .DataSource = New BindingSource(AttemptcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next

        If cmbx_ResultSearchSerial.SelectedIndex > 0 Then
            If cmbx_ResultSearchAttempt.Items.Count <= 1 Then
                ResultMessage(7)
            End If
            cmbx_ResultSearchAttempt.Enabled = True
        Else
            cmbx_ResultSearchAttempt.Enabled = False
        End If

    End Sub


    Private Sub cmbx_ResultSearchAttempt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_ResultSearchAttempt.SelectedIndexChanged
        If cmbx_ResultSearchAttempt.SelectedIndex > 0 Then
            btn_ResultSearch.Enabled = True
            btn_ResultExport.Enabled = True
        Else
            btn_ResultSearch.Enabled = False
            btn_ResultExport.Enabled = False
        End If
    End Sub


#End Region



#Region " Result Message"
    Private Function ResultMessage(a As Integer) As MsgBoxResult
        Select Case a
            Case 1
                Return MsgBox("Lot ID Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 2
                Return MsgBox("Serial Number Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 3
                Return MsgBox("Attempt Number Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 4
                Return MsgBox("CSV File Exported Successfully.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Export - Success")
            Case 5
                Return MsgBox("Unable To Export CSV File, Please Try Again.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Export - Failed To Export")
            Case 6
                Return MsgBox("Data not found in Product Result Table for Particular Attempt Number", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 7
                Return MsgBox("Data not found in Product Result Table for Particular Serial Number", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 8
                Return MsgBox("Data not found in Product Result Table for Particular Lot ID", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 9
                Return MsgBox("Invalid File Path Specified.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Export - Path Error")
            Case Else
                Exit Select
        End Select
        Return 0
    End Function
#End Region




#Region "Form Closing"
    Private Sub btn_Home_Click(sender As Object, e As EventArgs) Handles btn_Home.Click
        Me.Close()
    End Sub
#End Region


#Region "Result Search"
    Private Sub btn_ResultSearch_Click(sender As Object, e As EventArgs) Handles btn_ResultSearch.Click
        Dim Lotid As String = cmbx_ResultSearchLot.Text
        Dim serialnum As String = cmbx_ResultSearchSerial.Text
        Dim attempt As String = cmbx_ResultSearchAttempt.Text







        Dim Oncontinue As Boolean = True
        If Oncontinue = True Then
            If cmbx_ResultSearchLot.SelectedIndex <= 0 Then
                ResultMessage(1)
                Oncontinue = False
            End If
        End If

        If Oncontinue = True Then
            If cmbx_ResultSearchSerial.SelectedIndex <= 0 Then
                ResultMessage(2)
                Oncontinue = False
            End If
        End If

        If Oncontinue = True Then
            If cmbx_ResultSearchAttempt.SelectedIndex <= 0 Then
                ResultMessage(3)
                Oncontinue = False
            End If
        End If

        If Oncontinue = True Then
            LoadResult(Lotid, serialnum, attempt)
        End If



    End Sub
#End Region



#Region "Result Export"
    Private Sub btn_ResultExport_Click(sender As Object, e As EventArgs) Handles btn_ResultExport.Click
        ' Convert Visible DataGridView Columns To DataTable
        Dim Lotid As String = cmbx_ResultSearchLot.Text
        Dim serialnum As String = cmbx_ResultSearchSerial.Text
        Dim attempt As String = cmbx_ResultSearchAttempt.Text
        If dgv_Resultsummary.RowCount = 0 Then
            ResultMessage(5)
        Else
            Dim dt As DataTable = GetVisibleColumnsDataTable(dgv_Resultsummary)    'GetVisibleColumnsDataTable(dgv_recipedetails)
            'Dim Filepath As String = $"{Resultsummaryexportpath}ResultSummary_{Lotid}-{serialnum}_{attempt}.csv"

            ' Get Path
            'Dim dtGetPath As DataTable = SQL.ReadRecords($"SELECT id, description, retained_value FROM [0_RetainedMemory] WHERE id={11}")
            Dim Filepath As String = $"{PublicVariables.CSVPathToResultSummary}ResultSummary_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv"

            ' Export With Return
            Dim ReturnValue As String = ExportDataTableToCsv(dt, Filepath, PublicVariables.CSVDelimiterResultSummary)

            ' Check Return State
            If ReturnValue = "True" Then
                ResultMessage(4)
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Individual Result Summary] CSV Export Success ""{Filepath}""")
            ElseIf ReturnValue = "Missing" Then
                ResultMessage(9)
            ElseIf ReturnValue = "False" Then
                ResultMessage(5)
            End If
        End If
    End Sub
#End Region


#Region "Text Formatting"
    Private Sub txtbx_ResultTest_TextChanged(sender As Object, e As EventArgs) Handles txtbx_ResultTest.TextChanged
        If txtbx_ResultTest.Text = "PASS" Then
            txtbx_ResultTest.BackColor = PublicVariables.StatusGreen
            txtbx_ResultTest.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_ResultTest.BackColor = PublicVariables.StatusRed
            txtbx_ResultTest.ForeColor = PublicVariables.StatusRedT
        End If
    End Sub

    Private Sub txtbx_Resultflush1_TextChanged(sender As Object, e As EventArgs) Handles txtbx_Resultflush1.TextChanged
        If txtbx_Resultflush1.Text = "ENABLE" Then
            txtbx_Resultflush1.BackColor = PublicVariables.StatusGreen
            txtbx_Resultflush1.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_Resultflush1.BackColor = SystemColors.Window
            txtbx_Resultflush1.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_ResultDPTest1_TextChanged(sender As Object, e As EventArgs) Handles txtbx_ResultDPTest1.TextChanged
        If txtbx_ResultDPTest1.Text = "ENABLE" Then
            txtbx_ResultDPTest1.BackColor = PublicVariables.StatusGreen
            txtbx_ResultDPTest1.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_ResultDPTest1.BackColor = SystemColors.Window
            txtbx_ResultDPTest1.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_Resultflush2_TextChanged(sender As Object, e As EventArgs) Handles txtbx_Resultflush2.TextChanged
        If txtbx_Resultflush2.Text = "ENABLE" Then
            txtbx_Resultflush2.BackColor = PublicVariables.StatusGreen
            txtbx_Resultflush2.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_Resultflush2.BackColor = SystemColors.Window
            txtbx_Resultflush2.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_ResultDPTest2_TextChanged(sender As Object, e As EventArgs) Handles txtbx_ResultDPTest2.TextChanged
        If txtbx_ResultDPTest2.Text = "ENABLE" Then
            txtbx_ResultDPTest2.BackColor = PublicVariables.StatusGreen
            txtbx_ResultDPTest2.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_ResultDPTest2.BackColor = SystemColors.Window
            txtbx_ResultDPTest2.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_ResultDrain1_TextChanged(sender As Object, e As EventArgs) Handles txtbx_ResultDrain1.TextChanged
        If txtbx_ResultDrain1.Text = "ENABLE" Then
            txtbx_ResultDrain1.BackColor = PublicVariables.StatusGreen
            txtbx_ResultDrain1.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_ResultDrain1.BackColor = SystemColors.Window
            txtbx_ResultDrain1.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_ResultDrain2_TextChanged(sender As Object, e As EventArgs) Handles txtbx_ResultDrain2.TextChanged
        If txtbx_ResultDrain2.Text = "ENABLE" Then
            txtbx_ResultDrain2.BackColor = PublicVariables.StatusGreen
            txtbx_ResultDrain2.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_ResultDrain2.BackColor = SystemColors.Window
            txtbx_ResultDrain2.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_ResultDrain3_TextChanged(sender As Object, e As EventArgs) Handles txtbx_ResultDrain3.TextChanged
        If txtbx_ResultDrain3.Text = "ENABLE" Then
            txtbx_ResultDrain3.BackColor = PublicVariables.StatusGreen
            txtbx_ResultDrain3.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_ResultDrain3.BackColor = SystemColors.Window
            txtbx_ResultDrain3.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub LoadResult(lotid As String, serialnum As String, attempt As String)
        Dim Oncontinue As Boolean = True
        'Dim resultsummary(90) As String
        Dim dt_Resultsummary As DataTable
        'Dim dtproductiondetail As DataTable = SQL.ReadRecords($"SELECT * FROM ProductionDetail 
        '            LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id
        '            LEFT JOIN RecipeTable ON Lotusage.recipe_id=RecipeTable.recipe_id
        '            LEFT JOIN WorkOrder ON Lotusage.lot_id=WorkOrder.lot_id WHERE serial_uid = '{lotid}-{serialnum}' AND serial_attempt ='{attempt}'")
        Dim dtproductiondetail As DataTable = SQL.ReadRecords($"
            SELECT 

            ProductionDetail.id AS productiondetail_id, 
            ProductionDetail.serial_uid AS productiondetail_serial_uid, 
            ProductionDetail.serial_number AS productiondetail_serial_number, 
            ProductionDetail.serial_attempt AS productiondetail_serial_attempt, 
            ProductionDetail.lot_usage_id AS productiondetail_lot_usage_id, 
            ProductionDetail.timestamp AS productiondetail_timestamp, 
            ProductionDetail.temperature AS productiondetail_temperature, 
            ProductionDetail.flowrate AS productiondetail_flowrate, 
            ProductionDetail.inlet_pressure AS productiondetail_inlet_pressure, 
            ProductionDetail.outlet_pressure AS productiondetail_outlet_pressure, 
            ProductionDetail.viscosity AS productiondetail_viscosity, 
            ProductionDetail.diff_pressure AS productiondetail_diff_pressure, 
            ProductionDetail.cycle_time AS productiondetail_cycle_time, 
            ProductionDetail.result AS productiondetail_result, 
            ProductionDetail.back_pressure AS productiondetail_back_pressure, 

            LotUsage.id AS lotusage_id, 
            LotUsage.lot_id AS lotusage_lot_id, 
            LotUsage.lot_attempt AS lotusage_lot_attempt, 
            LotUsage.lot_start_time AS lotusage_lot_start_time, 
            LotUsage.lot_end_time AS lotusage_lot_end_time, 
            LotUsage.run_by AS lotusage_run_by, 
            LotUsage.recipe_id AS lotusage_recipe_id, 
            LotUsage.recipe_rev AS lotusage_recipe_rev, 
            LotUsage.calibration_time AS lotusage_calibration_time, 
            LotUsage.cal_inlet_pressure AS lotusage_cal_inlet_pressure, 
            LotUsage.cal_outlet_pressure AS lotusage_cal_outlet_pressure, 
            LotUsage.cal_diff_pressure AS lotusage_cal_diff_pressure, 
            LotUsage.verify_inlet_pressure AS lotusage_verify_inlet_pressure, 
            LotUsage.verify_outlet_pressure AS lotusage_verify_outlet_pressure, 
            LotUsage.verify_diff_pressure AS lotusage_verify_diff_pressure, 
            LotUsage.cal_result AS lotusage_cal_result, 
            LotUsage.cal_cycle_time AS lotusage_cal_cycle_time, 

            RecipeTable.id AS recipetable_id, 
            RecipeTable.recipe_id AS recipetable_recipe_id, 
            RecipeTable.recipe_rev AS recipetable_recipe_rev, 
            RecipeTable.part_id AS recipetable_part_id, 
            RecipeTable.recipe_type_id AS recipetable_recipe_type_id, 
            RecipeTable.last_modified_by AS recipetable_last_modified_by, 
            RecipeTable.last_modified_time AS recipetable_last_modified_time, 
            RecipeTable.user_created AS recipetable_user_created, 
            RecipeTable.created_time AS recipetable_created_time, 
            RecipeTable.verification_tolerance AS recipetable_verification_tolerance, 
            RecipeTable.prep_fill_time AS recipetable_prep_fill_time, 
            RecipeTable.prep_bleed_time AS recipetable_prep_bleed_time, 
            RecipeTable.prep_flowrate AS recipetable_prep_flowrate, 
            RecipeTable.prep_back_pressure AS recipetable_prep_back_pressure, 
            RecipeTable.prep_pressure_drop AS recipetable_prep_pressure_drop, 
            RecipeTable.prep_pressure_drop_time AS recipetable_prep_pressure_drop_time, 
            RecipeTable.firstflush_circuit AS recipetable_firstflush_circuit, 
            RecipeTable.firstflush_flowrate AS recipetable_firstflush_flowrate, 
            RecipeTable.firstflush_flow_tolerance AS recipetable_firstflush_flow_tolerance, 
            RecipeTable.firstflush_back_pressure AS recipetable_firstflush_back_pressure, 
            RecipeTable.firstflush_stabilize_time AS recipetable_firstflush_stabilize_time, 
            RecipeTable.firstflush_time AS recipetable_firstflush_time, 
            RecipeTable.firstdp_circuit AS recipetable_firstdp_circuit, 
            RecipeTable.dp_flowrate AS recipetable_dp_flowrate, 
            RecipeTable.dp_flow_tolerance AS recipetable_dp_flow_tolerance, 
            RecipeTable.dp_back_pressure AS recipetable_dp_back_pressure, 
            RecipeTable.dp_stabilize_time AS recipetable_dp_stabilize_time, 
            RecipeTable.dp_test_time AS recipetable_dp_test_time, 
            RecipeTable.dp_lowerlimit AS recipetable_dp_lowerlimit, 
            RecipeTable.dp_upperlimit AS recipetable_dp_upperlimit, 
            RecipeTable.dp_testpoints AS recipetable_dp_testpoints, 
            RecipeTable.seconddp_circuit AS recipetable_seconddp_circuit, 
            RecipeTable.secondflush_circuit AS recipetable_secondflush_circuit, 
            RecipeTable.secondflush_flowrate AS recipetable_secondflush_flowrate, 
            RecipeTable.secondflush_flow_tolerance AS recipetable_secondflush_flow_tolerance, 
            RecipeTable.secondflush_back_pressure AS recipetable_secondflush_back_pressure, 
            RecipeTable.secondflush_stabilize_time AS recipetable_secondflush_stabilize_time, 
            RecipeTable.secondflush_time AS recipetable_secondflush_time, 
            RecipeTable.drain1_circuit AS recipetable_drain1_circuit, 
            RecipeTable.drain1_back_pressure AS recipetable_drain1_back_pressure, 
            RecipeTable.drain1_time AS recipetable_drain1_time, 
            RecipeTable.drain2_circuit AS recipetable_drain2_circuit, 
            RecipeTable.drain2_back_pressure AS recipetable_drain2_back_pressure, 
            RecipeTable.drain2_time AS recipetable_drain2_time, 
            RecipeTable.drain3_circuit AS recipetable_drain3_circuit, 
            RecipeTable.drain3_back_pressure AS recipetable_drain3_back_pressure, 
            RecipeTable.drain3_time AS recipetable_drain3_time, 

            WorkOrder.work_order AS workorder_work_order, 
            WorkOrder.part_id AS workorder_part_id, 
            WorkOrder.confirmation_id AS workorder_confirmation_id, 
            WorkOrder.quantity AS workorder_quantity 

            FROM ProductionDetail 
            LEFT JOIN LotUsage ON ProductionDetail.lot_usage_id=LotUsage.id
            LEFT JOIN RecipeTable ON LotUsage.recipe_id=RecipeTable.recipe_id
            LEFT JOIN WorkOrder ON LotUsage.lot_id=WorkOrder.lot_id 
            WHERE serial_uid = '{lotid}-{serialnum}' 
            AND serial_attempt ='{attempt}'
        ")

        'Dim dtproductiondetail As DataTable = SQL.ReadRecords($"SELECT * FROM ProductionDetail 
        '            LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id
        '            LEFT JOIN WorkOrder ON Lotusage.lot_id=WorkOrder.lot_id WHERE serial_uid = '{lotid}-{serialnum}' AND serial_attempt ='{attempt}'")

        If Oncontinue = True Then

            If dtproductiondetail.Rows.Count > 0 Then
                'For i As Integer = 0 To dtproductiondetail.Columns.Count - 1
                '    If Not dtproductiondetail.Rows(0).IsNull(i) Then
                '        resultsummary(i) = dtproductiondetail.Rows(0).Item(i)
                '    Else
                '        resultsummary(i) = String.Empty
                '    End If

                'Next

                dt_Resultsummary = SQL.ReadRecords($"SELECT * FROM ProductResult WHERE serial_usage_id = '{dtproductiondetail(0)("productiondetail_id")}'ORDER BY ProductResult.sampling_time ASC")
                dgv_Resultsummary.DataSource = dt_Resultsummary
            Else
                ResultMessage(6)
                Oncontinue = False
            End If

        End If

        If Oncontinue = True Then
            If dgv_Resultsummary.RowCount = 0 Then
                ResultMessage(6)
                Oncontinue = False
            End If
        End If

        With dgv_Resultsummary
            .BackgroundColor = SystemColors.Window

            'Hide Unwanted columns
            .Columns("id").Visible = False
            .Columns("serial_usage_id").Visible = False

            'Change header name
            .Columns("sampling_time").HeaderCell.Value = "Sampling Time (s)"
            .Columns("temperature").HeaderCell.Value = "Temperature (C)"
            .Columns("flowrate").HeaderCell.Value = "Flowrate (l/min)"
            .Columns("inlet_pressure").HeaderCell.Value = "Inlet Pressure (kPa)"
            .Columns("outlet_pressure").HeaderCell.Value = "Outlet Pressure (kPa)"
            .Columns("calculated_dp_pressure").HeaderCell.Value = "Differential Pressure (kPa)"
            .Columns("back_pressure").HeaderCell.Value = "Back Pressure (kPa)"
            .Columns("pump_rpm").HeaderCell.Value = "Pump Speed (RPM)"

            'Set Column Width
            .Columns("sampling_time").Width = 150
            .Columns("temperature").Width = 200
            .Columns("flowrate").Width = 200
            .Columns("inlet_pressure").Width = 200
            .Columns("outlet_pressure").Width = 200
            .Columns("calculated_dp_pressure").Width = 200
            .Columns("back_pressure").Width = 200
            .Columns("pump_rpm").Width = 200

            'Header Cell Alignment
            .Columns("sampling_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("temperature").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("flowrate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("inlet_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("outlet_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("calculated_dp_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("back_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("pump_rpm").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Header Cell Font Bold
            .Columns("sampling_time").HeaderCell.Style.Font = New Font(dgv_Resultsummary.Font, FontStyle.Bold)
            .Columns("temperature").HeaderCell.Style.Font = New Font(dgv_Resultsummary.Font, FontStyle.Bold)
            .Columns("flowrate").HeaderCell.Style.Font = New Font(dgv_Resultsummary.Font, FontStyle.Bold)
            .Columns("inlet_pressure").HeaderCell.Style.Font = New Font(dgv_Resultsummary.Font, FontStyle.Bold)
            .Columns("outlet_pressure").HeaderCell.Style.Font = New Font(dgv_Resultsummary.Font, FontStyle.Bold)
            .Columns("calculated_dp_pressure").HeaderCell.Style.Font = New Font(dgv_Resultsummary.Font, FontStyle.Bold)
            .Columns("back_pressure").HeaderCell.Style.Font = New Font(dgv_Resultsummary.Font, FontStyle.Bold)
            .Columns("pump_rpm").HeaderCell.Style.Font = New Font(dgv_Resultsummary.Font, FontStyle.Bold)

        End With


        If Oncontinue = True Then

            txtbx_ResultTimestamp.Text = dtproductiondetail(0)("productiondetail_timestamp")
            txtbx_ResultTemperature.Text = dtproductiondetail(0)("productiondetail_temperature")
            txtbx_ResultFlowrate.Text = dtproductiondetail(0)("productiondetail_flowrate")
            txtbx_ResultInletPressure.Text = dtproductiondetail(0)("productiondetail_inlet_pressure")
            txtbx_ResultOutletPressure.Text = dtproductiondetail(0)("productiondetail_outlet_pressure")
            txtbx_ResultDiffPressure.Text = dtproductiondetail(0)("productiondetail_diff_pressure")
            txtbx_ResultTest.Text = dtproductiondetail(0)("productiondetail_result").ToUpper

            txtbx_ResultCalOffset.Text = dtproductiondetail(0)("lotusage_cal_diff_pressure")
            txtbx_ResultRecipeID.Text = dtproductiondetail(0)("lotusage_recipe_id")
            txtbx_ResultRecipeIDRev.Text = dtproductiondetail(0)("lotusage_recipe_id")

            txtbx_Resultflush1.Text = dtproductiondetail(0)("recipetable_firstflush_circuit").ToUpper
            txtbx_ResultDPTest1.Text = dtproductiondetail(0)("recipetable_firstdp_circuit").ToUpper
            txtbx_ResultDPTest2.Text = dtproductiondetail(0)("recipetable_seconddp_circuit").ToUpper
            txtbx_Resultflush2.Text = dtproductiondetail(0)("recipetable_secondflush_circuit").ToUpper
            txtbx_ResultDrain1.Text = dtproductiondetail(0)("recipetable_drain1_circuit").ToUpper
            txtbx_ResultDrain2.Text = dtproductiondetail(0)("recipetable_drain2_circuit").ToUpper
            txtbx_ResultDrain3.Text = dtproductiondetail(0)("recipetable_drain3_circuit").ToUpper


            txtbx_ResultWorkOrder.Text = dtproductiondetail(0)("workorder_work_order")
            txtbx_ResultPartID.Text = dtproductiondetail(0)("workorder_part_id")
            txtbx_ResultConfirmation.Text = dtproductiondetail(0)("workorder_confirmation_id")
            txtbx_ResultSerialUID.Text = dtproductiondetail(0)("productiondetail_serial_uid")
            txtbx_Resultattempt.Text = dtproductiondetail(0)("productiondetail_serial_attempt")
        End If
    End Sub


#End Region
    Private Sub picbx_Icon_Click(sender As Object, e As EventArgs) Handles picbx_Icon.Click

        FormPixel.Show()

    End Sub


End Class