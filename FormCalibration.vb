Public Class FormCalibration
    Dim CurrentTabPage As TabPage


    Public Cal_samplingtime As Decimal
    Public Cal_temperature As Decimal
    Public Cal_flowrate As Decimal
    Public Cal_inletpressure As Decimal
    Public Cal_outletpressure As Decimal
    Public Cal_dp As Decimal
    Public CalCycletime As Integer

    Public Ver_samplingtime As Decimal
    Public Ver_temperature As Decimal
    Public Ver_flowrate As Decimal
    Public Ver_inletpressure As Decimal
    Public Ver_outletpressure As Decimal
    Public Ver_dp As Decimal
    Public vertol As Decimal

    Public Cal_dptestpoints As Integer
    Public dtCalibration As New DataTable
    Public dtVerification As New DataTable
    Public Dptest1start As Integer
    Public dptest1end As Integer
    Public Dptest2start As Integer
    Public dptest2end As Integer
    Public Cal_avginlet1 As Decimal
    Public Cal_avgoutlet1 As Decimal
    Public Cal_offset1 As Decimal
    Public Ver_avginlet1 As Decimal
    Public Ver_avgoutlet1 As Decimal
    Public Ver_avgdp1 As Decimal
    Public Cal_avginlet2 As Decimal
    Public Cal_avgoutlet2 As Decimal
    Public Cal_offset2 As Decimal
    Public Ver_avginlet2 As Decimal
    Public Ver_avgoutlet2 As Decimal
    Public Ver_avgdp2 As Decimal
    Public Cal_finalInlet As Decimal
    Public Cal_finalOutlet As Decimal
    Public Cal_finaloffset As Decimal
    Public Ver_finalinlet As Decimal
    Public Ver_finaloutlet As Decimal
    Public Ver_finaldp As Decimal
    Public Cal_avgtemperature1 As Decimal
    Public Cal_avgflowrate1 As Decimal
    Public Cal_avgtemperature2 As Decimal
    Public Cal_avgflowrate2 As Decimal
    Public Cal_finaltemperature As Decimal
    Public Cal_finalflowrate As Decimal
    Public Ver_avgtemperature1 As Decimal
    Public Ver_avgflowrate1 As Decimal
    Public Ver_avgtemperature2 As Decimal
    Public Ver_avgflowrate2 As Decimal
    Public Ver_finaltemperature As Decimal
    Public Ver_finalflowrate As Decimal

    Public Cal_backpressure As Decimal
    Public Cal_avgbackpressure1 As Decimal
    Public Cal_avgbackpressure2 As Decimal
    Public Cal_finalbackpressure As Decimal

    Public Ver_backpressure As Decimal
    Public Ver_avgbackpressure1 As Decimal
    Public Ver_avgbackpressure2 As Decimal
    Public Ver_finalbackpressure As Decimal




    Public flush1cycletime As Integer
    Public flush2cycletime As Integer
    Public DPtest1cycletime As Integer
    Public DPtest2cycletime As Integer
    Public Drain1cycletime As Integer
    Public Drain2cycletime As Integer
    Public Drain3cycletime As Integer



    Private Sub FormCalibration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Always Maximize
        Me.WindowState = FormWindowState.Maximized

        ' Load Version
        lbl_Version.Text = PublicVariables.AppVersion

        ' Load Form Title
        Me.Text = PublicVariables.ProgramTitle & " - " & "Calibration & Verification"
        lbl_Title.Text = PublicVariables.ProgramTitle

        ' Load User Details
        lbl_Username.Text = PublicVariables.LoginUserName
        lbl_Category.Text = PublicVariables.LoginUserCategoryName

        ' Initialize Defaults
        txtbx_CalLotID.Text = FormMain.txtbx_LotID.Text
        txtbx_RecipeID.Text = FormMain.cmbx_RecipeID.Text


        txtbx_JigType.Text = Jig
        tmr_Calibration.Interval = 500
        tmr_Verification.Interval = 500



        btn_Calibrate.Enabled = True
        btn_Verify.Enabled = True



        dtrecipetable = SQL.ReadRecords($"SELECT * FROM RecipeTable Where recipe_id ='{txtbx_RecipeID.Text}'")


        If dtrecipetable.Rows.Count > 0 Then

            If dtrecipetable.Rows(0)("firstdp_circuit") = "Disable" And dtrecipetable.Rows(0)("seconddp_circuit") = "Disable" Then
                FormMain.lbl_CalibrationStatus.Text = "Pass"
                FormMain.lbl_CalibrationStatus.BackColor = Color.FromArgb(192, 255, 192)
                FormMain.lbl_BlankDP.Text = "0.0"
                Dim dtlotusage As DataTable = SQL.ReadRecords($"SELECT id,lot_id,lot_attempt FROM LotUsage where lot_id = '{FormMain.txtbx_LotID.Text}' AND lot_end_time IS NULL")
                If dtlotusage.Rows.Count > 0 Then
                    Dim Updateparameter As New Dictionary(Of String, Object) From {
                            {"recipe_id", FormMain.cmbx_RecipeID.Text},
                            {"calibration_time", lbl_DateTimeClock.Text},
                            {"cal_inlet_pressure", "0"},
                            {"cal_outlet_pressure", "0"},
                            {"cal_diff_pressure", "0"},
                             {"verify_inlet_pressure", "0"},
                            {"verify_outlet_pressure", "0"},
                            {"verify_diff_pressure", "0"},
                            {"cal_result", "Pass"},
                            {"cal_cycle_time", "0"}
                        }
                    Dim Condition As String = $"id = '{dtlotusage.Rows(dtlotusage.Rows.Count - 1).Item("id")}'"

                    If SQL.UpdateRecord("LotUsage", Updateparameter, Condition) = 1 Then
                        Dim onContinue = True

                        If onContinue = True Then
                            Dim calstatusparameter As New Dictionary(Of String, Object) From {
                        {"retained_value", "Pass"}
                        }
                            Dim calstatuscondition As String = $"id='30'"
                            If SQL.UpdateRecord($"[0_RetainedMemory]", calstatusparameter, calstatuscondition) = 1 Then
                                onContinue = True
                            Else
                                MsgBox($"Query to Update Calibration Result Failed")
                                onContinue = False
                            End If
                        End If

                        If onContinue = True Then
                            Dim caloffsetparameter As New Dictionary(Of String, Object) From {
                        {"retained_value", "0.0"}
                        }
                            Dim caloffsetcondition As String = $"id='31'"
                            If SQL.UpdateRecord($"[0_RetainedMemory]", caloffsetparameter, caloffsetcondition) = 1 Then
                                onContinue = True
                            Else
                                MsgBox($"Query to Update Calibration Result Failed")
                                onContinue = False
                            End If
                        End If
                    Else
                        MsgBox($"Query to Update Calibration Result Failed")
                    End If
                End If

                Me.Close()
            End If



            txtbx_CalBackPressure.Text = dtrecipetable.Rows(0)("dp_back_pressure")
            txtbx_CalDPTestFlowrate.Text = dtrecipetable.Rows(0)("dp_flowrate")
            txtbx_CalDPTesttime.Text = dtrecipetable.Rows(0)("dp_test_time")
            txtbx_CalDPPoints.Text = dtrecipetable.Rows(0)("dp_testpoints")
            txtbx_CalVertol.Text = dtrecipetable.Rows(0)("verification_tolerance")
            If dtrecipetable.Rows(0)("firstflush_circuit") = "Enable" Then
                flush1cycletime = (dtrecipetable.Rows(0)("firstflush_fill_time") + dtrecipetable.Rows(0)("firstflush_bleed_time") + dtrecipetable.Rows(0)("firstflush_stabilize_time") + dtrecipetable.Rows(0)("firstflush_time"))
            End If
            If dtrecipetable.Rows(0)("secondflush_circuit") = "Enable" Then
                flush2cycletime = (dtrecipetable.Rows(0)("secondflush_fill_time") + dtrecipetable.Rows(0)("secondflush_bleed_time") + dtrecipetable.Rows(0)("secondflush_stabilize_time") + dtrecipetable.Rows(0)("secondflush_time"))
            End If

            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And dtrecipetable.Rows(0)("firstflush_circuit") = "Disable" Then
                DPtest1cycletime = (dtrecipetable.Rows(0)("dp_fill_time") + dtrecipetable.Rows(0)("dp_bleed_time") + dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
            ElseIf dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And dtrecipetable.Rows(0)("firstflush_circuit") = "Enable" Then
                DPtest1cycletime = (dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
            End If

            If dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" And dtrecipetable.Rows(0)("secondflush_circuit") = "Disable" Then
                DPtest2cycletime = (dtrecipetable.Rows(0)("dp_fill_time") + dtrecipetable.Rows(0)("dp_bleed_time") + dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
            ElseIf dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" And dtrecipetable.Rows(0)("secondflush_circuit") = "Enable" Then
                DPtest2cycletime = (dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
            End If

            If dtrecipetable.Rows(0)("drain1_circuit") = "Enable" Then
                Drain1cycletime = (dtrecipetable.Rows(0)("drain1_time"))
            End If
            If dtrecipetable.Rows(0)("drain2_circuit") = "Enable" Then
                Drain2cycletime = (dtrecipetable.Rows(0)("drain2_time"))
            End If
            If dtrecipetable.Rows(0)("drain3_circuit") = "Enable" Then
                Drain3cycletime = (dtrecipetable.Rows(0)("drain3_time"))
            End If

            CalCycletime = flush1cycletime + flush2cycletime + DPtest1cycletime + DPtest2cycletime + Drain1cycletime + Drain2cycletime + Drain3cycletime
            Cal_dptestpoints = dtrecipetable.Rows(0)("dp_testpoints")

            dptest1end = CType((CalCycletime - (flush2cycletime + DPtest2cycletime + Drain1cycletime + Drain2cycletime + Drain3cycletime) - 1) * (1000 / tmr_Calibration.Interval), Decimal)
            Dptest1start = dptest1end - Cal_dptestpoints
            dptest2end = CType((CalCycletime - (Drain1cycletime + Drain2cycletime + Drain3cycletime)) * (1000 / tmr_Calibration.Interval), Decimal)
            Dptest2start = dptest2end - Cal_dptestpoints


            vertol = dtrecipetable.Rows(0)("verification_tolerance")
            txtbx_EstCalCycletime.Text = CalCycletime.ToString

            txtbx_EstVerCycletime.Text = CalCycletime.ToString
            txtbx_ActCalCycletime.Text = "0"
            txtbx_ActVerCycletime.Text = "0"
        Else
            txtbx_CalLotID.Text = Nothing
            txtbx_RecipeID.Text = Nothing
            txtbx_JigType.Text = Nothing
            txtbx_EstCalCycletime.Text = Nothing
            txtbx_ActCalCycletime.Text = Nothing
            txtbx_EstVerCycletime.Text = Nothing
            txtbx_ActVerCycletime.Text = Nothing
            txtbx_CalBackPressure.Text = Nothing
            txtbx_CalDPTestFlowrate.Text = Nothing
            txtbx_CalDPTesttime.Text = Nothing
            txtbx_CalDPPoints.Text = Nothing
            txtbx_CalVertol.Text = Nothing
            flush1cycletime = 0
            flush2cycletime = 0
            DPtest1cycletime = 0
            DPtest2cycletime = 0
            Drain1cycletime = 0
            Drain2cycletime = 0
            Drain3cycletime = 0


        End If

    End Sub

    Private Sub FormCalibration_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Clear Selection
        Me.Select()

        ' Display Form Control
        panel_FormControl.Visible = True
    End Sub

    Private Sub btn_Home_Click(sender As Object, e As EventArgs) Handles btn_Home.Click

        Me.Close()
    End Sub

    Private Sub btn_Discard_Click(sender As Object, e As EventArgs) Handles btn_Discard.Click
        If FormMain.MainMessage(11) = DialogResult.Yes Then
            PCStatus(1)(2) = False
            PCStatus(1)(3) = False

            txtbx_ActCalCycletime.Text = "0"

            txtbx_ActVerCycletime.Text = "0"

            tmr_Calibration.Enabled = False
            txtbx_CalInletPressure.Text = Nothing
            txtbx_CalOutletPressure.Text = Nothing
            txtbx_CalFlowrate.Text = Nothing
            txtbx_CalTemperature.Text = Nothing
            txtbx_CalOffset.Text = Nothing
            tmr_Verification.Enabled = False
            txtbx_CalResult.Text = Nothing
            txtbx_VerInletPressure.Text = Nothing
            txtbx_VerOutletPressure.Text = Nothing
            txtbx_VerFlowrate.Text = Nothing
            txtbx_VerTemperature.Text = Nothing
            txtbx_VerDP.Text = Nothing
            txtbx_VerStatus.Text = Nothing
            txtbx_VerStatus.BackColor = SystemColors.Window
            txtbx_CalResult.BackColor = SystemColors.Window
            SetButtonState(btn_Calibrate, False, "Calibrate")
            SetButtonState(btn_Verify, False, "Verify")
            flush1cycletime = 0
            flush2cycletime = 0
            DPtest1cycletime = 0
            DPtest2cycletime = 0
            Drain1cycletime = 0
            Drain2cycletime = 0
            Drain3cycletime = 0
            PCStatus(1)(8) = True

            If dtCalibration.Rows.Count > 0 Then
                dtCalibration.Clear()
            End If
            If dtVerification.Rows.Count > 0 Then
                dtVerification.Clear()
            End If


        End If
    End Sub

    Private Sub btn_Calibrate_Click(sender As Object, e As EventArgs) Handles btn_Calibrate.Click
        CalibrationRun()

    End Sub

    Private Sub tmr_Calibration_Tick(sender As Object, e As EventArgs) Handles tmr_Calibration.Tick
        PCStatus(1)(2) = False
        If CalrecordValue = True And CommLost = False Then


            Dim newrw As DataRow = dtCalibration.NewRow
            Cal_samplingtime += CType((tmr_Calibration.Interval / 1000), Decimal)
            Cal_inletpressure = AIn(9)
            Cal_outletpressure = AIn(10)
            Cal_flowrate = AIn(12)
            Cal_temperature = AIn(13)
            Cal_dp = Cal_inletpressure - Cal_outletpressure
            Cal_backpressure = AIn(1)
            newrw(0) = Cal_samplingtime
            newrw(1) = Cal_temperature
            newrw(2) = Cal_flowrate
            newrw(3) = Cal_inletpressure
            newrw(4) = Cal_outletpressure
            newrw(5) = Cal_dp
            newrw(6) = Cal_backpressure
            dtCalibration.Rows.InsertAt(newrw, 0)
            With dgv_CalibrationResult
                .BackgroundColor = SystemColors.Window

                dgv_CalibrationResult.DataSource = dtCalibration
                'Set Column Width
                .Columns(0).Width = 80
                .Columns(1).Width = 80
                .Columns(2).Width = 80
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 100
                .Columns(6).Width = 100

                'Header Cell Alignment
                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Header Cell Font Bold
                .Columns(0).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(1).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(2).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(3).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(4).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(5).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(6).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)

            End With


        Else
            PCStatus(1)(2) = False
        End If

        txtbx_ActCalCycletime.Text = Cal_samplingtime.ToString
        If Cal_samplingtime = CalCycletime Then
            Dim A As Double = 0.01257187
            Dim B As Double = -0.005806436
            Dim C As Double = 0.001130911
            Dim D As Double = -0.000005723952
            Dim T2 As Double
            Dim exp As Double
            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
                For i = Dptest1start To dptest1end - 1
                    Cal_avginlet1 = Cal_avginlet1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Cal_avgoutlet1 = Cal_avgoutlet1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                    Cal_avgflowrate1 = Cal_avgflowrate1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Flowrate (l/min)")
                    Cal_avgtemperature1 = Cal_avgtemperature1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Temperature (°C)")
                    Cal_avgbackpressure1 = Cal_avgbackpressure1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Back Pressure (kPa)")
                Next
                Cal_avginlet1 = Cal_avginlet1 / Cal_dptestpoints
                Cal_avgoutlet1 = Cal_avgoutlet1 / Cal_dptestpoints
                Cal_avgflowrate1 = Cal_avgflowrate1 / Cal_dptestpoints
                Cal_avgtemperature1 = Cal_avgtemperature1 / Cal_dptestpoints
                Cal_avgbackpressure1 = Cal_avgbackpressure1 / Cal_dptestpoints
                Cal_offset1 = Cal_avginlet1 - Cal_avgoutlet1

                For i = Dptest2start To dptest2end - 1
                    Cal_avginlet2 = Cal_avginlet2 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Cal_avgoutlet2 = Cal_avgoutlet2 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                    Cal_avgflowrate2 = Cal_avgflowrate2 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Flowrate (l/min)")
                    Cal_avgtemperature2 = Cal_avgtemperature2 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Temperature (°C)")
                    Cal_avgbackpressure2 = Cal_avgbackpressure2 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Back Pressure (kPa)")
                Next
                Cal_avginlet2 = Cal_avginlet2 / Cal_dptestpoints
                Cal_avgoutlet2 = Cal_avgoutlet2 / Cal_dptestpoints
                Cal_avgflowrate2 = Cal_avgflowrate2 / Cal_dptestpoints
                Cal_avgtemperature2 = Cal_avgtemperature2 / Cal_dptestpoints
                Cal_avgbackpressure2 = Cal_avgbackpressure2 / Cal_dptestpoints
                Cal_offset2 = Cal_avginlet2 - Cal_avgoutlet2

                Cal_finalInlet = ((Cal_avginlet1 + Cal_avginlet2) / 2)
                Cal_finalOutlet = ((Cal_avgoutlet1 + Cal_avgoutlet2) / 2)
                Cal_finalflowrate = ((Cal_avgflowrate1 + Cal_avgflowrate2) / 2)
                Cal_finaltemperature = (((Cal_avgtemperature1 + Cal_avgtemperature2) / 2) + 273.15)
                Cal_finalbackpressure = ((Cal_avgbackpressure1 + Cal_avgbackpressure2) / 2)

                T2 = Cal_finaltemperature * Cal_finaltemperature
                exp = Math.Exp((1 + (B * Cal_finaltemperature)) / ((C * Cal_finaltemperature) + (D * T2)))
                Viscosity = A * exp
                Cal_finaloffset = ((1.002 / Viscosity) * (Cal_finalInlet - Cal_finalOutlet))




            End If

            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And Not dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
                For i = Dptest1start To dptest1end - 1
                    Cal_avginlet1 = Cal_avginlet1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Cal_avgoutlet1 = Cal_avgoutlet1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                    Cal_avgflowrate1 = Cal_avgflowrate1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Flowrate (l/min)")
                    Cal_avgtemperature1 = Cal_avgtemperature1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Temperature (°C)")
                    Cal_avgbackpressure1 = Cal_avgbackpressure1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Back Pressure (kPa)")
                Next
                Cal_avginlet1 = Cal_avginlet1 / Cal_dptestpoints
                Cal_avgoutlet1 = Cal_avgoutlet1 / Cal_dptestpoints
                Cal_avgflowrate1 = Cal_avgflowrate1 / Cal_dptestpoints
                Cal_avgtemperature1 = Cal_avgtemperature1 / Cal_dptestpoints
                Cal_avgbackpressure1 = Cal_avgbackpressure1 / Cal_dptestpoints
                Cal_offset1 = Cal_avginlet1 - Cal_avgoutlet1

                Cal_finalInlet = Cal_avginlet1
                Cal_finalOutlet = Cal_avgoutlet1
                Cal_finalflowrate = Cal_avgflowrate1
                Cal_finaltemperature = (Cal_avgtemperature1 + 273.15)
                Cal_finalbackpressure = Cal_avgbackpressure1

                T2 = Cal_finaltemperature * Cal_finaltemperature
                exp = Math.Exp((1 + (B * Cal_finaltemperature)) / ((C * Cal_finaltemperature) + (D * T2)))
                Viscosity = A * exp
                Cal_finaloffset = ((1.002 / Viscosity) * (Cal_finalInlet - Cal_finalOutlet))



            End If
            txtbx_CalInletPressure.Text = CType(Cal_finalInlet, String)
            txtbx_CalOutletPressure.Text = CType(Cal_finalOutlet, String)
            txtbx_CalFlowrate.Text = CType(Cal_finalflowrate, String)
            txtbx_CalTemperature.Text = CType(Cal_finaltemperature - 273.15, String)
            txtbx_CalBackpress.Text = CType(Cal_finalbackpressure, String)
            txtbx_CalOffset.Text = CType(Math.Round(Cal_finaloffset, 2), String)

            ' Convert Visible DataGridView Columns To DataTable

            If dgv_CalibrationResult.RowCount = 0 Then

            Else
                Dim dtcalresultexport As DataTable = GetVisibleColumnsDataTable(dgv_CalibrationResult)    'GetVisibleColumnsDataTable(dgv_recipedetails)
                'Dim Filepath As String = $"{Resultsummaryexportpath}ResultSummary_{Lotid}-{serialnum}_{attempt}.csv"

                ' Get Path
                'Dim dtGetPath As DataTable = SQL.ReadRecords($"SELECT id, description, retained_value FROM [0_RetainedMemory] WHERE id={11}")
                Dim Filepath As String = $"{PublicVariables.CSVPathToResultSummary}CalibrationSummary_{txtbx_CalLotID.Text}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv"

                ' Export With Return
                Dim ReturnValue As String = ExportDataTableToCsv(dtcalresultexport, Filepath, PublicVariables.CSVDelimiterResultSummary)

                ' Check Return State
                If ReturnValue = "True" Then

                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Calibration Result Summary] CSV Export Success ""{Filepath}""")
                ElseIf ReturnValue = "Missing" Then

                ElseIf ReturnValue = "False" Then

                End If
            End If


            PCStatus(1)(4) = True
            VerificationRun()
            tmr_Calibration.Enabled = False
        End If

    End Sub

    Private Sub btn_Verify_Click(sender As Object, e As EventArgs) Handles btn_Verify.Click

        VerificationRun()

    End Sub

    Private Sub tmr_Verification_Tick(sender As Object, e As EventArgs) Handles tmr_Verification.Tick
        PCStatus(1)(3) = False
        If CalrecordValue = True And CommLost = False Then
            Dim newrw As DataRow = dtVerification.NewRow
            Ver_samplingtime += CType((tmr_Verification.Interval / 1000), Decimal)
            Ver_inletpressure = AIn(9)
            Ver_outletpressure = AIn(10)
            Ver_flowrate = AIn(12)
            Ver_temperature = AIn(13)
            Ver_backpressure = AIn(1)
            Ver_dp = Ver_inletpressure - Ver_outletpressure
            newrw(0) = Ver_samplingtime
            newrw(1) = Ver_temperature
            newrw(2) = Ver_flowrate
            newrw(3) = Ver_inletpressure
            newrw(4) = Ver_outletpressure
            newrw(5) = Ver_dp
            newrw(6) = Ver_backpressure
            dtVerification.Rows.InsertAt(newrw, 0)
            With dgv_VerificationResult
                .BackgroundColor = SystemColors.Window



                dgv_VerificationResult.DataSource = dtVerification
                'Set Column Width
                .Columns(0).Width = 80
                .Columns(1).Width = 80
                .Columns(2).Width = 80
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 100
                .Columns(6).Width = 100

                'Header Cell Alignment
                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Header Cell Font Bold
                .Columns(0).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(1).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(2).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(3).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(4).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(5).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(6).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)

            End With

        Else
            PCStatus(1)(3) = False
        End If

        txtbx_ActVerCycletime.Text = Ver_samplingtime.ToString
        If Ver_samplingtime = CalCycletime Then
            Dim A As Double = 0.01257187
            Dim B As Double = -0.005806436
            Dim C As Double = 0.001130911
            Dim D As Double = -0.000005723952
            Dim T2 As Double
            Dim exp As Double
            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
                For i = Dptest1start To dptest1end - 1
                    Ver_avginlet1 = Ver_avginlet1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Ver_avgoutlet1 = Ver_avgoutlet1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                    Ver_avgflowrate1 = Ver_avgflowrate1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Flowrate (l/min)")
                    Ver_avgtemperature1 = Ver_avgtemperature1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Temperature (°C)")
                    Ver_avgbackpressure1 = Ver_avgbackpressure1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Back Pressure (kPa)")


                Next
                Ver_avginlet1 = Ver_avginlet1 / Cal_dptestpoints
                Ver_avgoutlet1 = Ver_avgoutlet1 / Cal_dptestpoints
                Ver_avgflowrate1 = Ver_avgflowrate1 / Cal_dptestpoints
                Ver_avgtemperature1 = Ver_avgtemperature1 / Cal_dptestpoints
                Ver_avgbackpressure1 = Ver_avgbackpressure1 / Cal_dptestpoints
                Ver_avgdp1 = Ver_avginlet1 - Ver_avgoutlet1

                For i = Dptest2start To dptest2end - 1
                    Ver_avginlet2 = Ver_avginlet2 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Ver_avgoutlet2 = Ver_avgoutlet2 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                    Ver_avgflowrate2 = Ver_avgflowrate2 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Flowrate (l/min)")
                    Ver_avgtemperature2 = Ver_avgtemperature2 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Temperature (°C)")
                    Ver_avgbackpressure2 = Ver_avgbackpressure2 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Back Pressure (kPa)")
                Next
                Ver_avginlet2 = Ver_avginlet2 / Cal_dptestpoints
                Ver_avgoutlet2 = Ver_avgoutlet2 / Cal_dptestpoints
                Ver_avgflowrate2 = Ver_avgflowrate2 / Cal_dptestpoints
                Ver_avgtemperature2 = Ver_avgtemperature2 / Cal_dptestpoints
                Ver_avgbackpressure2 = Ver_avgbackpressure2 / Cal_dptestpoints
                Ver_avgdp2 = Ver_avginlet2 - Ver_avgoutlet2

                Ver_finalinlet = ((Ver_avginlet1 + Ver_avginlet2) / 2)
                Ver_finaloutlet = ((Ver_avgoutlet1 + Ver_avgoutlet2) / 2)
                Ver_finalflowrate = ((Ver_avgflowrate1 + Ver_avgflowrate2) / 2)
                Ver_finaltemperature = (((Ver_avgtemperature1 + Ver_avgtemperature2) / 2) + 273.15)
                Ver_finalbackpressure = ((Ver_avgbackpressure1 + Ver_avgbackpressure2) / 2)

                T2 = Ver_finaltemperature * Ver_finaltemperature
                exp = Math.Exp((1 + (B * Ver_finaltemperature)) / ((C * Ver_finaltemperature) + (D * T2)))
                Viscosity = A * exp
                Ver_finaldp = ((1.002 / Viscosity) * (Ver_finalinlet - Ver_finaloutlet))



            End If

            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And Not dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
                For i = Dptest1start To dptest1end - 1
                    Ver_avginlet1 = Ver_avginlet1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Ver_avgoutlet1 = Ver_avgoutlet1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                    Ver_avgflowrate1 = Ver_avgflowrate1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Flowrate (l/min)")
                    Ver_avgtemperature1 = Ver_avgtemperature1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Temperature (°C)")
                    Ver_avgbackpressure1 = Ver_avgbackpressure1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Back Pressure (kPa)")
                Next
                Ver_avginlet1 = Ver_avginlet1 / Cal_dptestpoints
                Ver_avgoutlet1 = Ver_avgoutlet1 / Cal_dptestpoints
                Ver_avgflowrate1 = Ver_avgflowrate1 / Cal_dptestpoints
                Ver_avgtemperature1 = Ver_avgtemperature1 / Cal_dptestpoints
                Ver_avgbackpressure1 = Ver_avgbackpressure1 / Cal_dptestpoints
                Ver_avgdp1 = Ver_avginlet1 - Ver_avgoutlet1


                Ver_finalinlet = Ver_avginlet1
                Ver_finaloutlet = Ver_avgoutlet1


                Ver_finalflowrate = Ver_avgflowrate1
                Ver_finaltemperature = (Ver_avgtemperature1 + 273.15)
                Ver_finalbackpressure = Ver_avgbackpressure1
                T2 = Ver_finaltemperature * Ver_finaltemperature
                exp = Math.Exp((1 + (B * Ver_finaltemperature)) / ((C * Ver_finaltemperature) + (D * T2)))
                Viscosity = A * exp
                Ver_finaldp = ((1.002 / Viscosity) * (Ver_finalinlet - Ver_finaloutlet))



            End If
            txtbx_VerInletPressure.Text = CType(Ver_finalinlet, String)
            txtbx_VerOutletPressure.Text = CType(Ver_finaloutlet, String)
            txtbx_VerFlowrate.Text = CType(Ver_finalflowrate, String)
            txtbx_VerTemperature.Text = CType(Ver_finaltemperature - 273.15, String)
            txtbx_VerBackpress.Text = CType(Ver_finalbackpressure, String)
            txtbx_VerStatus.Text = "Completed"
            txtbx_VerStatus.BackColor = Color.FromArgb(192, 255, 192)
            ' Convert Visible DataGridView Columns To DataTable

            If dgv_VerificationResult.RowCount = 0 Then

            Else
                Dim dtVerresultexport As DataTable = GetVisibleColumnsDataTable(dgv_VerificationResult)    'GetVisibleColumnsDataTable(dgv_recipedetails)
                'Dim Filepath As String = $"{Resultsummaryexportpath}ResultSummary_{Lotid}-{serialnum}_{attempt}.csv"

                ' Get Path
                'Dim dtGetPath As DataTable = SQL.ReadRecords($"SELECT id, description, retained_value FROM [0_RetainedMemory] WHERE id={11}")
                Dim Filepath As String = $"{PublicVariables.CSVPathToResultSummary}VerificationSummary_{txtbx_CalLotID.Text}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv"

                ' Export With Return
                Dim ReturnValue As String = ExportDataTableToCsv(dtVerresultexport, Filepath, PublicVariables.CSVDelimiterResultSummary)

                ' Check Return State
                If ReturnValue = "True" Then

                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Verification Result Summary] CSV Export Success ""{Filepath}""")
                ElseIf ReturnValue = "Missing" Then

                ElseIf ReturnValue = "False" Then

                End If
            End If

            PCStatus(1)(5) = True

            txtbx_VerDP.Text = CType(Math.Round(Ver_finaldp, 2), String)


        End If
    End Sub

    Private Sub txtbx_VerDP_TextChanged(sender As Object, e As EventArgs) Handles txtbx_VerDP.TextChanged
        tmr_Verification.Enabled = False
        If IsNumeric(txtbx_VerDP.Text) Then
            If IsNumeric(txtbx_CalOffset.Text) Then
                Dim min As Decimal = CType(txtbx_CalOffset.Text, Decimal) - vertol
                Dim max As Decimal = CType(txtbx_CalOffset.Text, Decimal) + vertol
                If CType(txtbx_VerDP.Text, Decimal) >= min And CType(txtbx_VerDP.Text, Decimal) <= max Then
                    txtbx_CalResult.Text = "Pass"
                    txtbx_CalResult.BackColor = Color.FromArgb(192, 255, 192)
                    FormMain.lbl_CalibrationStatus.Text = "Pass"
                    FormMain.lbl_CalibrationStatus.BackColor = Color.FromArgb(192, 255, 192)
                    FormMain.lbl_BlankDP.Text = txtbx_CalOffset.Text

                Else
                    txtbx_CalResult.Text = "Fail"
                    txtbx_CalResult.BackColor = Color.OrangeRed
                    FormMain.lbl_CalibrationStatus.Text = "Fail"
                    FormMain.lbl_CalibrationStatus.BackColor = Color.OrangeRed
                    FormMain.lbl_BlankDP.Text = txtbx_CalOffset.Text
                End If
                Dim dtlotusage As DataTable = SQL.ReadRecords($"SELECT id,lot_id,lot_attempt FROM LotUsage where lot_id = '{txtbx_CalLotID.Text}' AND lot_end_time IS NULL")
                If dtlotusage.Rows.Count > 0 Then
                    Dim Updateparameter As New Dictionary(Of String, Object) From {
                            {"recipe_id", txtbx_RecipeID.Text},
                            {"calibration_time", lbl_DateTimeClock.Text},
                            {"cal_inlet_pressure", Cal_finalInlet.ToString},
                            {"cal_outlet_pressure", Cal_finalOutlet.ToString},
                            {"cal_diff_pressure", txtbx_CalOffset.Text},
                             {"verify_inlet_pressure", Ver_finalinlet.ToString},
                            {"verify_outlet_pressure", Ver_finaloutlet.ToString},
                            {"verify_diff_pressure", Ver_finaldp.ToString},
                            {"cal_result", txtbx_CalResult.Text},
                            {"cal_cycle_time", CalCycletime.ToString}
                        }
                    Dim Condition As String = $"id = '{dtlotusage.Rows(dtlotusage.Rows.Count - 1).Item("id")}'"

                    If SQL.UpdateRecord("LotUsage", Updateparameter, Condition) = 1 Then
                        Dim onContinue = True
                        PCStatus(1)(6) = True
                        If onContinue = True Then
                            Dim calstatusparameter As New Dictionary(Of String, Object) From {
                        {"retained_value", txtbx_CalResult.Text}
                        }
                            Dim calstatuscondition As String = $"id='30'"
                            If SQL.UpdateRecord($"[0_RetainedMemory]", calstatusparameter, calstatuscondition) = 1 Then
                                onContinue = True
                            Else
                                MsgBox($"Query to Update Calibration Result Failed")
                                onContinue = False
                            End If
                        End If

                        If onContinue = True Then
                            Dim caloffsetparameter As New Dictionary(Of String, Object) From {
                        {"retained_value", txtbx_CalOffset.Text}
                        }
                            Dim caloffsetcondition As String = $"id='31'"
                            If SQL.UpdateRecord($"[0_RetainedMemory]", caloffsetparameter, caloffsetcondition) = 1 Then
                                onContinue = True
                            Else
                                MsgBox($"Query to Update Calibration Result Failed")
                                onContinue = False
                            End If
                        End If

                        If onContinue = True Then
                            If txtbx_CalResult.Text = "Fail" Then
                                If MsgBox($"Calibration/Blank Test Results as {txtbx_CalResult.Text}, Do you Want to Reset and Re-calirbate?", MsgBoxStyle.YesNo, "Calibration Result") = DialogResult.No Then

                                    Me.Close()
                                Else
                                    btn_Discard.PerformClick()
                                End If
                            ElseIf txtbx_CalResult.Text = "Pass" Then

                                If MsgBox($"Calibration/Blank Test Completed with Result as {txtbx_CalResult.Text} and Calibration offset as {txtbx_CalOffset.Text}", MsgBoxStyle.OkOnly, "Calibration Result") = DialogResult.OK Then

                                    Me.Close()
                                End If
                            End If


                        Else
                            MsgBox($"Error in Result capture")
                        End If



                    Else
                        MsgBox($"Query to Update Calibration Result Failed")
                    End If
                Else
                    MsgBox($"Lot information Not Found!")
                End If
            Else
                MsgBox($"Numeric Data not found in Calibration offset")
            End If

        End If
    End Sub



    Public Sub CalibrationRun()
        If Not txtbx_CalDPTesttime.Text = Nothing And Not txtbx_CalDPTesttime.Text = "" And Not txtbx_CalDPTesttime.Text = "0" And Not txtbx_CalDPPoints.Text = "0" Then
            If btn_Calibrate.BackColor = Color.FromArgb(25, 130, 246) Then


                PCStatus(1)(2) = True
                dtCalibration = New DataTable()
                dgv_CalibrationResult.DataSource = Nothing
                CreateTable("Calibration")
                btn_Verify.Enabled = False


                With dgv_CalibrationResult
                    .BackgroundColor = SystemColors.Window



                End With
                Cal_samplingtime = 0

                Cal_avginlet1 = 0
                Cal_avgoutlet1 = 0
                Cal_offset1 = 0
                Cal_avginlet2 = 0
                Cal_avgoutlet2 = 0
                Cal_offset2 = 0
                Cal_finalInlet = 0
                Cal_finalOutlet = 0
                Cal_finaloffset = 0
                Cal_finalflowrate = 0
                Cal_finaltemperature = 0
                Cal_avgflowrate1 = 0
                Cal_avgflowrate2 = 0
                Cal_avgtemperature1 = 0
                Cal_avgtemperature2 = 0

                tmr_Calibration.Enabled = True
            End If
        Else
            SetButtonState(btn_Calibrate, False, "Calibrate")
            PCStatus(1)(2) = False
            MsgBox($"No Valid data available to start the Test")
        End If

    End Sub

    Public Sub VerificationRun()
        If Not txtbx_CalDPTesttime.Text = Nothing And Not txtbx_CalDPTesttime.Text = "" And Not txtbx_CalDPTesttime.Text = "0" And Not txtbx_CalDPPoints.Text = "0" Then
            If btn_Verify.BackColor = Color.FromArgb(25, 130, 246) Then

                PCStatus(1)(3) = True
                btn_Calibrate.Enabled = False
                dtVerification = New DataTable()

                dgv_VerificationResult.DataSource = Nothing
                CreateTable("Verification")
                With dgv_CalibrationResult
                    .BackgroundColor = SystemColors.Window

                End With
                Ver_samplingtime = 0

                Ver_avgdp1 = 0
                Ver_avginlet1 = 0
                Ver_avgoutlet1 = 0
                Ver_avgdp2 = 0
                Ver_avginlet2 = 0
                Ver_avgoutlet2 = 0
                Ver_avgflowrate1 = 0
                Ver_avgflowrate2 = 0
                Ver_avgtemperature1 = 0
                Ver_avgtemperature2 = 0
                Ver_finalinlet = 0
                Ver_finaloutlet = 0
                Ver_finaldp = 0
                Ver_finalflowrate = 0
                Ver_finaltemperature = 0

                tmr_Verification.Enabled = True
            End If
        Else
            SetButtonState(btn_Verify, False, "Verify")
            PCStatus(1)(3) = False
            MsgBox($"No Valid data available to start the Test")
        End If
    End Sub

    Private Sub picbx_Icon_Click(sender As Object, e As EventArgs) Handles picbx_Icon.Click
        FormPixel.Show()
    End Sub

    Private Sub btn_CircuitView_Click(sender As Object, e As EventArgs) Handles btn_CircuitView.Click

        If btn_CircuitView.BackColor = Color.FromArgb(25, 130, 246) Then
            Panel_Calibration_Circuit.Visible = True
            btn_CircuitView.BackColor = Color.FromArgb(0, 192, 0)
        Else
            Panel_Calibration_Circuit.Visible = False
            btn_CircuitView.BackColor = Color.FromArgb(25, 130, 246)
        End If
    End Sub


End Class