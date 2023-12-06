Public Class FormCalibration
    Dim CurrentTabPage As TabPage


    Public Cal_samplingtime As Integer
    Public Cal_temperature As Decimal
    Public Cal_flowrate As Decimal
    Public Cal_inletpressure As Decimal
    Public Cal_outletpressure As Decimal
    Public Cal_dp As Decimal
    Public CalCycletime As Integer

    Public Ver_samplingtime As Integer
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
        txtbx_CalLotID.Text = FormMainModule.LotID
        txtbx_RecipeID.Text = FormMainModule.RecipeID
        txtbx_OperatorID.Text = PublicVariables.LoginUserName





        btn_Calibrate.Enabled = True
        btn_Verify.Enabled = True
        'tmr_Calibration.Enabled = False
        'tmr_Verification.Enabled = False


        dtrecipetable = SQL.ReadRecords($"SELECT * FROM RecipeTable Where recipe_id ='{txtbx_RecipeID.Text}'")


        If dtrecipetable.Rows.Count > 0 Then
            txtbx_CalFillTime.Text = dtrecipetable.Rows(0)("dp_fill_time")
            txtbx_CalBleedTime.Text = dtrecipetable.Rows(0)("dp_bleed_time")
            txtbx_CalFlowrate.Text = dtrecipetable.Rows(0)("dp_flowrate")
            txtbx_CalFlowTol.Text = dtrecipetable.Rows(0)("dp_flow_tolerance")
            txtbx_CalBackPressure.Text = dtrecipetable.Rows(0)("dp_back_pressure")
            txtbx_CalStabilizeTime.Text = dtrecipetable.Rows(0)("dp_stabilize_time")
            txtbx_CalDPTesttime.Text = dtrecipetable.Rows(0)("dp_test_time")
            txtbx_CalDPPoints.Text = dtrecipetable.Rows(0)("dp_testpoints")
            txtbx_CalVertol.Text = dtrecipetable.Rows(0)("verification_tolerance")
            If dtrecipetable.Rows(0)("firstflush_circuit") = "Enable" Then
                flush1cycletime = (dtrecipetable.Rows(0)("firstflush_fill_time") + dtrecipetable.Rows(0)("firstflush_bleed_time") + dtrecipetable.Rows(0)("firstflush_stabilize_time") + dtrecipetable.Rows(0)("firstflush_time"))
            End If
            If dtrecipetable.Rows(0)("secondflush_circuit") = "Enable" Then
                flush2cycletime = (dtrecipetable.Rows(0)("secondflush_fill_time") + dtrecipetable.Rows(0)("secondflush_bleed_time") + dtrecipetable.Rows(0)("secondflush_stabilize_time") + dtrecipetable.Rows(0)("secondflush_time"))
            End If
            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" Then
                DPtest1cycletime = (dtrecipetable.Rows(0)("dp_fill_time") + dtrecipetable.Rows(0)("dp_bleed_time") + dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
            End If
            If dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
                DPtest2cycletime = (dtrecipetable.Rows(0)("dp_fill_time") + dtrecipetable.Rows(0)("dp_bleed_time") + dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
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

            dptest1end = CalCycletime - (flush2cycletime + DPtest2cycletime + Drain1cycletime + Drain2cycletime + Drain3cycletime)
            Dptest1start = dptest1end - Cal_dptestpoints
            dptest2end = CalCycletime - (Drain1cycletime + Drain2cycletime + Drain3cycletime)
            Dptest2start = dptest2end - Cal_dptestpoints


            vertol = dtrecipetable.Rows(0)("verification_tolerance")
            Else
                txtbx_CalLotID.Text = Nothing
            txtbx_RecipeID.Text = Nothing
            txtbx_OperatorID.Text = Nothing
            txtbx_CalFillTime.Text = Nothing
            txtbx_CalBleedTime.Text = Nothing
            txtbx_CalFlowrate.Text = Nothing
            txtbx_CalFlowTol.Text = Nothing
            txtbx_CalBackPressure.Text = Nothing
            txtbx_CalStabilizeTime.Text = Nothing
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
        'tmr_Calibration.Enabled = False
        ' tmr_Verification.Enabled = False
        Me.Close()
    End Sub

    Private Sub btn_Discard_Click(sender As Object, e As EventArgs) Handles btn_Discard.Click
        If FormMain.MainMessage(11) = DialogResult.Yes Then
            PCStatus(1)(2) = False
            PCStatus(1)(3) = False
            txtbx_CalLotID.Text = Nothing
            txtbx_RecipeID.Text = Nothing
            txtbx_OperatorID.Text = Nothing
            txtbx_CalFillTime.Text = Nothing
            txtbx_CalBleedTime.Text = Nothing
            txtbx_CalFlowrate.Text = Nothing
            txtbx_CalFlowTol.Text = Nothing
            txtbx_CalBackPressure.Text = Nothing
            txtbx_CalStabilizeTime.Text = Nothing
            txtbx_CalDPTesttime.Text = Nothing
            txtbx_CalDPPoints.Text = Nothing
            txtbx_CalVertol.Text = Nothing
            tmr_Calibration.Enabled = False
            txtbx_CalInletPressure.Text = Nothing
            txtbx_CalOutletPressure.Text = Nothing
            txtbx_CalOffset.Text = Nothing
            tmr_Verification.Enabled = False
            txtbx_CalResult.Text = Nothing
            txtbx_VerInletPressure.Text = Nothing
            txtbx_VerOutletPressure.Text = Nothing
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
            Me.Close()
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
        If CalrecordValue = True And CommLost = False Then
            Dim newrw As DataRow = dtCalibration.NewRow
            Cal_samplingtime += 1
            Cal_inletpressure = AIn(9)
            Cal_outletpressure = AIn(10)
            Cal_flowrate = AIn(12)
            Cal_temperature = AIn(13)
            Cal_dp = Cal_inletpressure - Cal_outletpressure
            newrw(0) = Cal_samplingtime
            newrw(1) = Cal_temperature
            newrw(2) = Cal_flowrate
            newrw(3) = Cal_inletpressure
            newrw(4) = Cal_outletpressure
            newrw(5) = Cal_dp
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

                'Header Cell Alignment
                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Header Cell Font Bold
                .Columns(0).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(1).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(2).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(3).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(4).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(5).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)

            End With


        Else
            PCStatus(1)(2) = False
        End If
        If Cal_samplingtime = CalCycletime Then
            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
                For i = Dptest1start To dptest1end - 1
                    Cal_avginlet1 = Cal_avginlet1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Cal_avgoutlet1 = Cal_avgoutlet1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                Next
                Cal_avginlet1 = Cal_avginlet1 / Cal_dptestpoints
                Cal_avgoutlet1 = Cal_avgoutlet1 / Cal_dptestpoints
                Cal_offset1 = Cal_avginlet1 - Cal_avgoutlet1

                For i = Dptest2start To dptest2end - 1
                    Cal_avginlet2 = Cal_avginlet2 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Cal_avgoutlet2 = Cal_avgoutlet2 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                Next
                Cal_avginlet2 = Cal_avginlet2 / Cal_dptestpoints
                Cal_avgoutlet2 = Cal_avgoutlet2 / Cal_dptestpoints
                Cal_offset2 = Cal_avginlet2 - Cal_avgoutlet2

                Cal_finalInlet = ((Cal_avginlet1 + Cal_avginlet2) / 2)
                Cal_finalOutlet = ((Cal_avgoutlet1 + Cal_avgoutlet2) / 2)
                Cal_finaloffset = (Cal_offset1 - Cal_offset2) / 2



            End If

            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And Not dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
                For i = Dptest1start To dptest1end - 1
                    Cal_avginlet1 = Cal_avginlet1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Cal_avgoutlet1 = Cal_avgoutlet1 + dtCalibration.Rows(dtCalibration.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                Next
                Cal_avginlet1 = Cal_avginlet1 / Cal_dptestpoints
                Cal_avgoutlet1 = Cal_avgoutlet1 / Cal_dptestpoints
                Cal_offset1 = Cal_avginlet1 - Cal_avgoutlet1

                Cal_finalInlet = Cal_avginlet1
                Cal_finalOutlet = Cal_avgoutlet1
                Cal_finaloffset = Cal_offset1


            End If
            txtbx_CalInletPressure.Text = CType(Cal_finalInlet, String)
            txtbx_CalOutletPressure.Text = CType(Cal_finalOutlet, String)
            txtbx_CalOffset.Text = CType(Cal_finaloffset, String)
            'btn_Verify.Enabled = True
            PCStatus(1)(4) = True
            VerificationRun()
            tmr_Calibration.Enabled = False
        End If

    End Sub

    Private Sub btn_Verify_Click(sender As Object, e As EventArgs) Handles btn_Verify.Click

        VerificationRun()

    End Sub

    Private Sub tmr_Verification_Tick(sender As Object, e As EventArgs) Handles tmr_Verification.Tick

        If CalrecordValue = True And CommLost = False Then
            Dim newrw As DataRow = dtVerification.NewRow
            Ver_samplingtime += 1
            Ver_inletpressure = AIn(9)
            Ver_outletpressure = AIn(10)
            Ver_flowrate = AIn(12)
            Ver_temperature = AIn(13)
            Ver_dp = Ver_inletpressure - Ver_outletpressure
            newrw(0) = Ver_samplingtime
            newrw(1) = Ver_temperature
            newrw(2) = Ver_flowrate
            newrw(3) = Ver_inletpressure
            newrw(4) = Ver_outletpressure
            newrw(5) = Ver_dp
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

                'Header Cell Alignment
                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Header Cell Font Bold
                .Columns(0).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(1).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(2).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(3).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(4).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(5).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)

            End With

        Else
            PCStatus(1)(3) = False
        End If
        If Ver_samplingtime = CalCycletime Then
            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
                For i = Dptest1start To dptest1end - 1
                    Ver_avginlet1 = Ver_avginlet1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Ver_avgoutlet1 = Ver_avgoutlet1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                Next
                Ver_avginlet1 = Ver_avginlet1 / Cal_dptestpoints
                Ver_avgoutlet1 = Ver_avgoutlet1 / Cal_dptestpoints
                Ver_avgdp1 = Ver_avginlet1 - Ver_avgoutlet1

                For i = Dptest2start To dptest2end - 1
                    Ver_avginlet2 = Ver_avginlet2 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Ver_avgoutlet2 = Ver_avgoutlet2 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                Next
                Ver_avginlet2 = Ver_avginlet2 / Cal_dptestpoints
                Ver_avgoutlet2 = Ver_avgoutlet2 / Cal_dptestpoints
                Ver_avgdp2 = Ver_avginlet2 - Ver_avgoutlet2

                Ver_finalinlet = ((Ver_avginlet1 + Ver_avginlet2) / 2)
                Ver_finaloutlet = ((Ver_avgoutlet1 + Ver_avgoutlet2) / 2)
                Ver_finaldp = ((Ver_avgdp1 + Ver_avgdp2) / 2)


            End If

            If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And Not dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
                For i = Dptest1start To dptest1end - 1
                    Ver_avginlet1 = Ver_avginlet1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Inlet Pressure (kPa)")
                    Ver_avgoutlet1 = Ver_avgoutlet1 + dtVerification.Rows(dtVerification.Rows.Count - 1 - i)("Outlet Pressure (kPa)")
                Next
                Ver_avginlet1 = Ver_avginlet1 / Cal_dptestpoints
                Ver_avgoutlet1 = Ver_avgoutlet1 / Cal_dptestpoints
                Ver_avgdp1 = Ver_avginlet1 - Ver_avgoutlet1


                Ver_finalinlet = Ver_avginlet1
                Ver_finaloutlet = Ver_avgoutlet1
                Ver_finaldp = Ver_avgdp1


            End If
            txtbx_VerInletPressure.Text = CType(Ver_finalinlet, String)
            txtbx_VerOutletPressure.Text = CType(Ver_finaloutlet, String)
            txtbx_VerStatus.Text = "Completed"
            txtbx_VerStatus.BackColor = Color.FromArgb(192, 255, 192)

            PCStatus(1)(5) = True

            txtbx_VerDP.Text = CType(Ver_finaldp, String)


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
                Dim dtlotusage As DataTable = SQL.ReadRecords($"SELECT id,lot_id,lot_attempt FROM LotUsage where lot_id = '{txtbx_CalLotID.Text} ' AND lot_end_time IS NULL")
                If dtlotusage.Rows.Count = 1 Then
                    Dim Updateparameter As New Dictionary(Of String, Object) From {
                            {"recipe_id", txtbx_RecipeID.Text},
                            {"calibration_time", lbl_DateTimeClock.Text},
                            {"cal_inlet_pressure", Cal_finalInlet.ToString},
                            {"cal_outlet_pressure", Cal_finalOutlet.ToString},
                            {"cal_diff_pressure", Cal_finaloffset.ToString},
                             {"verify_inlet_pressure", Ver_finalinlet.ToString},
                            {"verify_outlet_pressure", Ver_finaloutlet.ToString},
                            {"verify_diff_pressure", Ver_finaldp.ToString},
                            {"cal_result", txtbx_CalResult.Text},
                            {"cal_cycle_time", CalCycletime.ToString}
                        }
                    Dim Condition As String = $"id = '{dtlotusage.Rows(0).Item("id")}'"

                    If SQL.UpdateRecord("LotUsage", Updateparameter, Condition) = 1 Then
                        If MsgBox($"Calibration/Blank Test Completed with Result as {txtbx_CalResult.Text} and Calibration offset as {Cal_finaloffset}", MsgBoxStyle.OkOnly, "Calibration Result") = DialogResult.OK Then
                            PCStatus(1)(6) = True
                            Me.Close()
                        End If

                    Else
                        MsgBox($"Query to Update Calibration Result Failed")
                    End If

                End If
            End If
        End If
    End Sub



    Public Sub CalibrationRun()
        If Not txtbx_CalDPTesttime.Text = Nothing And Not txtbx_CalDPTesttime.Text = "" And Not txtbx_CalDPTesttime.Text = "0" Then
            If btn_Calibrate.BackColor = Color.FromArgb(25, 130, 246) Then

                'SetButtonState(btn_Calibrate, True, "Calibrate")
                PCStatus(1)(2) = True
                dtCalibration = New DataTable()
                dgv_CalibrationResult.DataSource = Nothing
                CreateTable("Calibration")
                btn_Verify.Enabled = False


                With dgv_CalibrationResult
                    .BackgroundColor = SystemColors.Window



                End With
                Cal_samplingtime = 0
                'Cal_inletpressure = 0
                'Cal_outletpressure = 0
                Cal_avginlet1 = 0
                Cal_avgoutlet1 = 0
                Cal_offset1 = 0
                Cal_avginlet2 = 0
                Cal_avgoutlet2 = 0
                Cal_offset2 = 0
                Cal_finalInlet = 0
                Cal_finalOutlet = 0
                Cal_finaloffset = 0
                tmr_Calibration.Interval = 1000
                tmr_Calibration.Enabled = True
            End If
        Else
            SetButtonState(btn_Calibrate, False, "Calibrate")
            MsgBox($"No Valid data available to start the Test")
        End If

    End Sub

    Public Sub VerificationRun()
        If Not txtbx_CalDPTesttime.Text = Nothing And Not txtbx_CalDPTesttime.Text = "" And Not txtbx_CalDPTesttime.Text = "0" Then
            If btn_Verify.BackColor = Color.FromArgb(25, 130, 246) Then
                'SetButtonState(btn_Verify, True, "Verify")
                PCStatus(1)(3) = True
                btn_Calibrate.Enabled = False
                dtVerification = New DataTable()

                dgv_VerificationResult.DataSource = Nothing
                CreateTable("Verification")
                With dgv_CalibrationResult
                    .BackgroundColor = SystemColors.Window

                End With
                Ver_samplingtime = 0
                'Ver_inletpressure = 0
                'Ver_outletpressure = 0
                Ver_avgdp1 = 0
                Ver_avginlet1 = 0
                Ver_avgoutlet1 = 0
                Ver_avgdp2 = 0
                Ver_avginlet2 = 0
                Ver_avgoutlet2 = 0

                tmr_Verification.Interval = 1000
                tmr_Verification.Enabled = True
            End If
        Else
            SetButtonState(btn_Verify, False, "Verify")
            MsgBox($"No Valid data available to start the Test")
        End If
    End Sub

    Private Sub picbx_Icon_Click(sender As Object, e As EventArgs) Handles picbx_Icon.Click
        FormPixel.Show()
    End Sub
End Class