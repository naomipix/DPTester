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
    Public dtCalibration As DataTable
    Public dtVerification As DataTable
    Public Dpteststart As Integer
    Public dptestend As Integer
    Public Cal_avginlet As Decimal
    Public Cal_avgoutlet As Decimal
    Public Cal_offset As Decimal
    Public Ver_avginlet As Decimal
    Public Ver_avgoutlet As Decimal
    Public Ver_avgdp As Decimal




    Public Sub CreateTable(str As String)

        If str = "Calibration" Then
            dtCalibration.Columns.Add("Sampling Time (s)")
            dtCalibration.Columns.Add("Temperature (K)")
            dtCalibration.Columns.Add("Flowrate (l/min)")
            dtCalibration.Columns.Add("Inlet Pressure (kPa)")
            dtCalibration.Columns.Add("Outlet Pressure (kPa)")
            dtCalibration.Columns.Add("Differential Pressure (kPa)")
        End If

        If str = "Verification" Then
            dtVerification.Columns.Add("Sampling Time (s)")
            dtVerification.Columns.Add("Temperature (K)")
            dtVerification.Columns.Add("Flowrate (l/min)")
            dtVerification.Columns.Add("Inlet Pressure (kPa)")
            dtVerification.Columns.Add("Outlet Pressure (kPa)")
            dtVerification.Columns.Add("Differential Pressure (kPa)")
        End If
    End Sub
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
        tmr_Calibration.Enabled = False
        tmr_Verification.Enabled = False


        Dim dtrecipetable As DataTable = SQL.ReadRecords($"SELECT dp_fill_time,dp_bleed_time,dp_flowrate,dp_flow_tolerance,
dp_back_pressure,dp_stabilize_time,dp_test_time,dp_testpoints,verification_tolerance FROM RecipeTable Where recipe_id ='{txtbx_RecipeID.Text}'")


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
            CalCycletime = dtrecipetable.Rows(0)("dp_fill_time") + dtrecipetable.Rows(0)("dp_bleed_time") + dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time")
            Cal_dptestpoints = dtrecipetable.Rows(0)("dp_testpoints")
            dptestend = CalCycletime
            Dpteststart = CalCycletime - Cal_dptestpoints
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

        End If

    End Sub

    Private Sub FormCalibration_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Clear Selection
        Me.Select()

        ' Display Form Control
        panel_FormControl.Visible = True
    End Sub

    Private Sub btn_Home_Click(sender As Object, e As EventArgs) Handles btn_Home.Click
        tmr_Calibration.Enabled = False
        tmr_Verification.Enabled = False
        Me.Close()
    End Sub

    Private Sub btn_Discard_Click(sender As Object, e As EventArgs) Handles btn_Discard.Click
        If FormMain.MainMessage(11) = DialogResult.Yes Then
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
            Me.Close()
        End If
    End Sub

    Private Sub btn_Calibrate_Click(sender As Object, e As EventArgs) Handles btn_Calibrate.Click
        If Not txtbx_CalDPTesttime.Text = Nothing And Not txtbx_CalDPTesttime.Text = "" And Not txtbx_CalDPTesttime.Text = "0" Then
            dtCalibration = New DataTable()
            dgv_CalibrationResult.DataSource = Nothing
            CreateTable("Calibration")
            btn_Verify.Enabled = False


            With dgv_CalibrationResult
                .BackgroundColor = SystemColors.Window



            End With
            Cal_samplingtime = 0
            Cal_inletpressure = 0
            Cal_outletpressure = 0
            Cal_avginlet = 0
            Cal_avgoutlet = 0
            Cal_offset = 0
            tmr_Calibration.Interval = 1000
            tmr_Calibration.Enabled = True
        Else
            MsgBox($"No Valid data available to start the Test")
        End If


    End Sub

    Private Sub tmr_Calibration_Tick(sender As Object, e As EventArgs) Handles tmr_Calibration.Tick
        Cal_samplingtime += 1
        Cal_inletpressure += 1.5
        Cal_outletpressure += 1
        Cal_dp = Cal_inletpressure - Cal_outletpressure
        dtCalibration.Rows.Add(Cal_samplingtime, Cal_temperature, Cal_flowrate, Cal_inletpressure, Cal_outletpressure, Cal_dp)
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
        If Cal_samplingtime = CalCycletime Then

            For i = Dpteststart To dptestend - 1
                Cal_avginlet = Cal_avginlet + dtCalibration.Rows(i)("Inlet Pressure (kPa)")
                Cal_avgoutlet = Cal_avgoutlet + dtCalibration.Rows(i)("Outlet Pressure (kPa)")
            Next
            Cal_avginlet = Cal_avginlet / Cal_dptestpoints
            Cal_avgoutlet = Cal_avgoutlet / Cal_dptestpoints
            Cal_offset = Cal_avginlet - Cal_avgoutlet

            txtbx_CalInletPressure.Text = CType(Cal_avginlet, String)
            txtbx_CalOutletPressure.Text = CType(Cal_avgoutlet, String)
            txtbx_CalOffset.Text = CType(Cal_offset, String)
            btn_Verify.Enabled = True
            tmr_Calibration.Enabled = False
        End If

    End Sub

    Private Sub btn_Verify_Click(sender As Object, e As EventArgs) Handles btn_Verify.Click
        If Not txtbx_CalDPTesttime.Text = Nothing And Not txtbx_CalDPTesttime.Text = "" And Not txtbx_CalDPTesttime.Text = "0" Then
            btn_Calibrate.Enabled = False
            dtVerification = New DataTable()

            dgv_VerificationResult.DataSource = Nothing
            CreateTable("Verification")
            With dgv_CalibrationResult
                .BackgroundColor = SystemColors.Window

            End With
            Ver_samplingtime = 0
            Ver_inletpressure = 0
            Ver_outletpressure = 0
            Ver_avgdp = 0
            Ver_avginlet = 0
            Ver_avgoutlet = 0

            tmr_Verification.Interval = 1000
            tmr_Verification.Enabled = True
        Else
            MsgBox($"No Valid data available to start the Test")
        End If

    End Sub

    Private Sub tmr_Verification_Tick(sender As Object, e As EventArgs) Handles tmr_Verification.Tick
        Ver_samplingtime += 1
        Ver_inletpressure += 1.5
        Ver_outletpressure += 1
        Ver_dp = Ver_inletpressure - Ver_outletpressure
        dtVerification.Rows.Add(Ver_samplingtime, Ver_temperature, Ver_flowrate, Ver_inletpressure, Ver_outletpressure, Ver_dp)
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
        If Ver_samplingtime = CalCycletime Then

            For i = Dpteststart To dptestend - 1
                Ver_avginlet = Ver_avginlet + dtCalibration.Rows(i)("Inlet Pressure (kPa)")
                Ver_avgoutlet = Ver_avgoutlet + dtCalibration.Rows(i)("Outlet Pressure (kPa)")
            Next
            Ver_avginlet = Ver_avginlet / Cal_dptestpoints
            Ver_avgoutlet = Ver_avgoutlet / Cal_dptestpoints
            Ver_avgdp = Ver_avginlet - Ver_avgoutlet

            txtbx_VerInletPressure.Text = CType(Ver_avginlet, String)
            txtbx_VerOutletPressure.Text = CType(Ver_avgoutlet, String)
            txtbx_VerDP.Text = CType(Ver_avgdp, String)
            txtbx_VerStatus.Text = "Completed"
            txtbx_VerStatus.BackColor = Color.FromArgb(192, 255, 192)
            tmr_Verification.Enabled = False
        End If
    End Sub

    Private Sub txtbx_VerDP_TextChanged(sender As Object, e As EventArgs) Handles txtbx_VerDP.TextChanged
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
                            {"cal_inlet_pressure", Cal_inletpressure.ToString},
                            {"cal_outlet_pressure", Cal_outletpressure.ToString},
                            {"cal_diff_pressure", Cal_offset.ToString},
                             {"verify_inlet_pressure", Ver_avginlet.ToString},
                            {"verify_outlet_pressure", Ver_avgoutlet.ToString},
                            {"verify_diff_pressure", Ver_avgdp.ToString},
                            {"cal_result", txtbx_CalResult.Text},
                            {"cal_cycle_time", CalCycletime.ToString}
                        }
                    Dim Condition As String = $"id = '{dtlotusage.Rows(0).Item("id")}'"

                    If SQL.UpdateRecord("LotUsage", Updateparameter, Condition) = 1 Then
                        If MsgBox($"Calibration/Blank Test Completed with Result as {txtbx_CalResult.Text} and Calibration offset as {Cal_offset}", MsgBoxStyle.OkOnly, "Calibration Result") = DialogResult.OK Then
                            Me.Close()
                        End If

                    Else
                        MsgBox($"Query to Update Calibration Result Failed")
                    End If

                End If
                End If
            End If
    End Sub
End Class