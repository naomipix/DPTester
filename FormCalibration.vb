Imports LiveChartsCore
Imports LiveChartsCore.Kernel.Sketches
Imports LiveChartsCore.SkiaSharpView
Imports LiveChartsCore.SkiaSharpView.Painting
Imports LiveChartsCore.SkiaSharpView.VisualElements
Imports SkiaSharp
Imports LiveChartsCore.Defaults
Imports System.Collections.ObjectModel
Imports LiveChartsCore.SkiaSharpView.Painting.Effects

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

    Public Ver_pumprpm As Decimal
    Public Cal_pumprpm As Decimal



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

        ' Initialize Chart
        InitializeLiveChart()

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

        ' Reset Graph View Selection
        SetVisibleLineSeries()
    End Sub

    Private Sub InitializeLiveChartXAxes(XLimit As Integer) '(XLimit As Integer, XScaleMSec As Integer)
        'Dim XScaleSec As Double = XScaleMSec / 1000
        'Dim XLabelArr(XLimit / XScaleSec) As String

        'For i As Integer = 0 To XLimit / XScaleSec
        '    XLabelArr(i) = i * XScaleSec
        'Next

        For Each LiveGraphChart In {CartesianChart_CalibrationLiveGraph} 'CartesianChartArr
            LiveGraphChart.XAxes = New ICartesianAxis() {
                New LiveChartsCore.SkiaSharpView.Axis() With {
                    .Name = "Time (s)",
                    .NameTextSize = 14,
                    .NamePaint = New SolidColorPaint(SKColors.Black),
                    .NamePadding = New LiveChartsCore.Drawing.Padding(0, 20),
                    .Padding = New LiveChartsCore.Drawing.Padding(0, 20, 0, 0),
                    .TextSize = 12,
                    .LabelsPaint = New SolidColorPaint(SKColors.Black),
                    .TicksPaint = New SolidColorPaint(SKColors.Black),
                    .SubticksPaint = New SolidColorPaint(SKColors.Black),
                    .DrawTicksPath = True,
                    .MinStep = 1,
                    .MaxLimit = XLimit,
                    .MinLimit = 0
                }
            }
        Next

        ' .MinStep = 1,
        ' .MaxLimit = XLimit,
    End Sub

    Private Sub InitializeLiveChart()

        For Each LiveGraphChart In {CartesianChart_CalibrationLiveGraph} 'CartesianChartArr
            LiveGraphChart.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Hidden
            LiveGraphChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right
            LiveGraphChart.LegendTextSize = 12
            LiveGraphChart.ZoomMode = Measure.ZoomAndPanMode.X

            LiveGraphChart.Title = New LabelVisual() With {
                .Text = "DP Tester Live Graph",
                .TextSize = 14,
                .Padding = New LiveChartsCore.Drawing.Padding(15),
                .Paint = New SolidColorPaint(SKColors.Black)
            }

            InitializeLiveChartXAxes(10)

            LiveGraphChart.YAxes = New ICartesianAxis() {
                New LiveChartsCore.SkiaSharpView.Axis() With {
                    .Name = "Pressure (kPa)",
                    .NameTextSize = 14,
                    .NamePaint = New SolidColorPaint(SKColors.Black),
                    .NamePadding = New LiveChartsCore.Drawing.Padding(0, 20),
                    .Padding = New LiveChartsCore.Drawing.Padding(0, 0, 20, 0),
                    .TextSize = 12,
                    .LabelsPaint = New SolidColorPaint(SKColors.Black),
                    .TicksPaint = New SolidColorPaint(SKColors.Black),
                    .SubticksPaint = New SolidColorPaint(SKColors.Black),
                    .DrawTicksPath = True
                },
                New LiveChartsCore.SkiaSharpView.Axis() With {
                    .Name = "Pump RPM (RPM)",
                    .NameTextSize = 14,
                    .NamePaint = New SolidColorPaint(SKColors.Orange),
                    .NamePadding = New LiveChartsCore.Drawing.Padding(0, 20),
                    .Padding = New LiveChartsCore.Drawing.Padding(20, 0, 0, 0),
                    .TextSize = 12,
                    .LabelsPaint = New SolidColorPaint(SKColors.Orange),
                    .TicksPaint = New SolidColorPaint(SKColors.Orange),
                    .SubticksPaint = New SolidColorPaint(SKColors.Orange),
                    .DrawTicksPath = True,
                    .ShowSeparatorLines = False,
                    .Position = LiveChartsCore.Measure.AxisPosition.End
                },
                New LiveChartsCore.SkiaSharpView.Axis() With {
                    .Name = "Temperature (C)",
                    .NameTextSize = 14,
                    .NamePaint = New SolidColorPaint(SKColors.Red),
                    .NamePadding = New LiveChartsCore.Drawing.Padding(0, 20),
                    .Padding = New LiveChartsCore.Drawing.Padding(20, 0, 0, 0),
                    .TextSize = 12,
                    .LabelsPaint = New SolidColorPaint(SKColors.Red),
                    .TicksPaint = New SolidColorPaint(SKColors.Red),
                    .SubticksPaint = New SolidColorPaint(SKColors.Red),
                    .DrawTicksPath = True,
                    .ShowSeparatorLines = False,
                    .Position = LiveChartsCore.Measure.AxisPosition.End
                },
                New LiveChartsCore.SkiaSharpView.Axis() With {
                    .Name = "Flowrate (l/Min)",
                    .NameTextSize = 14,
                    .NamePaint = New SolidColorPaint(SKColors.Brown),
                    .NamePadding = New LiveChartsCore.Drawing.Padding(0, 20),
                    .Padding = New LiveChartsCore.Drawing.Padding(20, 0, 0, 0),
                    .TextSize = 12,
                    .LabelsPaint = New SolidColorPaint(SKColors.Brown),
                    .TicksPaint = New SolidColorPaint(SKColors.Brown),
                    .SubticksPaint = New SolidColorPaint(SKColors.Brown),
                    .DrawTicksPath = True,
                    .ShowSeparatorLines = False,
                    .Position = LiveChartsCore.Measure.AxisPosition.End
                }
            }

            LiveGraphChart.Series = New ISeries() {
                New LineSeries(Of ObservablePoint)() With {
                    .Name = "Diff. Pressure",
                    .Values = CalibrateChartDPValue,
                    .Fill = Nothing,
                    .Stroke = New SolidColorPaint With {
                        .Color = SKColors.Blue,
                        .StrokeThickness = 1
                    },
                    .GeometryFill = New SolidColorPaint(SKColors.Blue),
                    .GeometryStroke = New SolidColorPaint(SKColors.Transparent),
                    .GeometrySize = 0,
                    .ScalesYAt = 0,
                    .ScalesXAt = 0
                },
                New LineSeries(Of ObservablePoint)() With {
                    .Name = "Inlet Pressure",
                    .Values = CalibrateChartInletValue,
                    .Fill = Nothing,
                    .Stroke = New SolidColorPaint With {
                        .Color = SKColors.Green,
                        .StrokeThickness = 1
                    },
                    .GeometryFill = New SolidColorPaint(SKColors.Green),
                    .GeometryStroke = New SolidColorPaint(SKColors.Transparent),
                    .GeometrySize = 0,
                    .ScalesYAt = 0,
                    .ScalesXAt = 0
                },
                New LineSeries(Of ObservablePoint)() With {
                    .Name = "Outlet Pressure",
                    .Values = CalibrateChartOutletValue,
                    .Fill = Nothing,
                    .Stroke = New SolidColorPaint With {
                        .Color = SKColors.Magenta,
                        .StrokeThickness = 1
                    },
                    .GeometryFill = New SolidColorPaint(SKColors.Magenta),
                    .GeometryStroke = New SolidColorPaint(SKColors.Transparent),
                    .GeometrySize = 0,
                    .ScalesYAt = 0,
                    .ScalesXAt = 0
                },
                New LineSeries(Of ObservablePoint)() With {
                    .Name = "Back Pressure",
                    .Values = CalibrateChartBPValue,
                    .Fill = Nothing,
                    .Stroke = New SolidColorPaint With {
                        .Color = SKColors.DarkOrange,
                        .StrokeThickness = 1
                    },
                    .GeometryFill = New SolidColorPaint(SKColors.DarkOrange),
                    .GeometryStroke = New SolidColorPaint(SKColors.Transparent),
                    .GeometrySize = 0,
                    .ScalesYAt = 0,
                    .ScalesXAt = 0
                },
                New LineSeries(Of ObservablePoint)() With {
                    .Name = "Pump Speed",
                    .Values = CalibrateChartRPMValue,
                    .Fill = Nothing,
                    .Stroke = New SolidColorPaint With {
                        .Color = SKColors.Orange,
                        .StrokeThickness = 1
                    },
                    .GeometryFill = New SolidColorPaint(SKColors.Orange),
                    .GeometryStroke = New SolidColorPaint(SKColors.Transparent),
                    .GeometrySize = 0,
                    .ScalesYAt = 1,
                    .ScalesXAt = 0
                },
                New LineSeries(Of ObservablePoint)() With {
                    .Name = "Flowrate",
                    .Values = CalibrateChartFLWRValue,
                    .Fill = Nothing,
                    .Stroke = New SolidColorPaint With {
                        .Color = SKColors.Brown,
                        .StrokeThickness = 1
                    },
                    .GeometryFill = New SolidColorPaint(SKColors.Brown),
                    .GeometryStroke = New SolidColorPaint(SKColors.Transparent),
                    .GeometrySize = 0,
                    .ScalesYAt = 3,
                    .ScalesXAt = 0
                },
                New LineSeries(Of ObservablePoint)() With {
                    .Name = "Temperature",
                    .Values = CalibrateChartTempValue,
                    .Fill = Nothing,
                    .Stroke = New SolidColorPaint With {
                        .Color = SKColors.Red,
                        .StrokeThickness = 1
                    },
                    .GeometryFill = New SolidColorPaint(SKColors.Red),
                    .GeometryStroke = New SolidColorPaint(SKColors.Transparent),
                    .GeometrySize = 0,
                    .ScalesYAt = 2,
                    .ScalesXAt = 0
                }
            }
        Next
    End Sub

    Private Sub checkbx_Graph_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_GraphDP.CheckedChanged, checkbx_GraphInletPressure.CheckedChanged, checkbx_GraphOutletPressure.CheckedChanged, checkbx_GraphBP.CheckedChanged, checkbx_GraphFlowrate.CheckedChanged, checkbx_GraphTemperature.CheckedChanged, checkbx_GraphRPM.CheckedChanged
        SetVisibleLineSeries()
    End Sub

    Private Sub SetVisibleLineSeries()
        If checkbx_GraphDP.Checked Then
            With CartesianChart_CalibrationLiveGraph
                .Series(0).IsVisible = True
            End With
        Else
            With CartesianChart_CalibrationLiveGraph
                .Series(0).IsVisible = False
            End With
        End If

        If checkbx_GraphInletPressure.Checked Then
            With CartesianChart_CalibrationLiveGraph
                .Series(1).IsVisible = True
            End With
        Else
            With CartesianChart_CalibrationLiveGraph
                .Series(1).IsVisible = False
            End With
        End If

        If checkbx_GraphOutletPressure.Checked Then
            With CartesianChart_CalibrationLiveGraph
                .Series(2).IsVisible = True
            End With
        Else
            With CartesianChart_CalibrationLiveGraph
                .Series(2).IsVisible = False
            End With
        End If

        If checkbx_GraphBP.Checked Then
            With CartesianChart_CalibrationLiveGraph
                .Series(3).IsVisible = True
            End With
        Else
            With CartesianChart_CalibrationLiveGraph
                .Series(3).IsVisible = False
            End With
        End If

        If checkbx_GraphFlowrate.Checked Then
            With CartesianChart_CalibrationLiveGraph
                .Series(5).IsVisible = True
                .YAxes(3).IsVisible = True
            End With
        Else
            With CartesianChart_CalibrationLiveGraph
                .Series(5).IsVisible = False
                .YAxes(3).IsVisible = False
            End With
        End If

        If checkbx_GraphTemperature.Checked Then
            With CartesianChart_CalibrationLiveGraph
                .Series(6).IsVisible = True
                .YAxes(2).IsVisible = True
            End With
        Else
            With CartesianChart_CalibrationLiveGraph
                .Series(6).IsVisible = False
                .YAxes(2).IsVisible = False
            End With
        End If

        If checkbx_GraphRPM.Checked Then
            With CartesianChart_CalibrationLiveGraph
                .Series(4).IsVisible = True
                .YAxes(1).IsVisible = True
            End With
        Else
            With CartesianChart_CalibrationLiveGraph
                .Series(4).IsVisible = False
                .YAxes(1).IsVisible = False
            End With
        End If
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
            txtbx_CalBackpress.Text = Nothing
            txtbx_CalOffset.Text = Nothing
            tmr_Verification.Enabled = False
            txtbx_CalResult.Text = Nothing
            txtbx_VerInletPressure.Text = Nothing
            txtbx_VerOutletPressure.Text = Nothing
            txtbx_VerFlowrate.Text = Nothing
            txtbx_VerTemperature.Text = Nothing
            txtbx_VerBackpress.Text = Nothing
            txtbx_VerDP.Text = Nothing
            txtbx_VerStatus.Text = Nothing
            txtbx_VerStatus.BackColor = SystemColors.Window
            txtbx_VerStatus.ForeColor = SystemColors.ControlText
            txtbx_CalResult.BackColor = SystemColors.Window
            txtbx_CalResult.ForeColor = SystemColors.ControlText
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

            ' Rolling Average
            Dim FinalFlowrate As Decimal = 0
            If True Then
                RollingAvgArr(RollingAvgCount) = AIn(12)

                If RollingAvgCount = RollingAvgArr.Length - 1 Then
                    RollingAvgCount = 0
                Else
                    RollingAvgCount += 1
                End If

                Dim FlwrateTemp As Decimal = 0
                For i As Integer = 0 To RollingAvgArr.Length - 1
                    FlwrateTemp += RollingAvgArr(i)
                Next
                FinalFlowrate = FlwrateTemp / RollingAvgArr.Length
            End If

            Dim newrw As DataRow = dtCalibration.NewRow
            Cal_samplingtime += CType((tmr_Calibration.Interval / 1000), Decimal)
            Cal_inletpressure = AIn(9)
            Cal_outletpressure = AIn(10)
            Cal_flowrate = FinalFlowrate
            Cal_temperature = AIn(13)
            Cal_dp = Cal_inletpressure - Cal_outletpressure
            Cal_backpressure = AIn(1)
            Cal_pumprpm = AIn(2)
            newrw(0) = Cal_samplingtime
            newrw(1) = Cal_temperature
            newrw(2) = Cal_flowrate
            newrw(3) = Cal_inletpressure
            newrw(4) = Cal_outletpressure
            newrw(5) = Cal_dp
            newrw(6) = Cal_backpressure
            newrw(7) = Cal_pumprpm
            dtCalibration.Rows.InsertAt(newrw, 0)

            CalibrateChartDPValue.Add(New ObservablePoint With {
                .X = Cal_samplingtime,
                .Y = Cal_dp
            })
            CalibrateChartInletValue.Add(New ObservablePoint With {
                .X = Cal_samplingtime,
                .Y = Cal_inletpressure
            })
            CalibrateChartOutletValue.Add(New ObservablePoint With {
                .X = Cal_samplingtime,
                .Y = Cal_outletpressure
            })
            CalibrateChartBPValue.Add(New ObservablePoint With {
                .X = Cal_samplingtime,
                .Y = Cal_backpressure
            })
            CalibrateChartRPMValue.Add(New ObservablePoint With {
                .X = Cal_samplingtime,
                .Y = Cal_pumprpm
            })
            CalibrateChartFLWRValue.Add(New ObservablePoint With {
                .X = Cal_samplingtime,
                .Y = Cal_flowrate
            })
            CalibrateChartTempValue.Add(New ObservablePoint With {
                .X = Cal_samplingtime,
                .Y = Cal_temperature
            })

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
                .Columns(7).Width = 100

                'Header Cell Alignment
                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Header Cell Font Bold
                .Columns(0).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(1).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(2).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(3).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(4).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(5).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(6).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(7).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)

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
            'txtbx_CalInletPressure.Text = CType(Cal_finalInlet, String)
            'txtbx_CalOutletPressure.Text = CType(Cal_finalOutlet, String)
            'txtbx_CalFlowrate.Text = CType(Cal_finalflowrate, String)
            'txtbx_CalTemperature.Text = CType(Cal_finaltemperature - 273.15, String)
            'txtbx_CalBackpress.Text = CType(Cal_finalbackpressure, String)
            'txtbx_CalOffset.Text = CType(Math.Round(Cal_finaloffset, 2), String)

            txtbx_CalInletPressure.Text = Decimal.Round(Cal_finalInlet, 2)
            txtbx_CalOutletPressure.Text = Decimal.Round(Cal_finalOutlet, 2)
            txtbx_CalFlowrate.Text = Decimal.Round(Cal_finalflowrate, 2)
            txtbx_CalTemperature.Text = Decimal.Round(CDec(Cal_finaltemperature - 273.15), 2)
            txtbx_CalBackpress.Text = Decimal.Round(Cal_finalbackpressure, 2)
            txtbx_CalOffset.Text = Decimal.Round(Math.Round(Cal_finaloffset, 2), 2)

            ' Convert Visible DataGridView Columns To DataTable

            If dgv_CalibrationResult.RowCount = 0 Then

            Else

                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Calibration Result for {txtbx_CalLotID.Text}] Inlet Pressure (kPa) : {txtbx_CalInletPressure.Text}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Calibration Result for {txtbx_CalLotID.Text}] Outlet Pressure (kPa) : {txtbx_CalOutletPressure.Text}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Calibration Result for {txtbx_CalLotID.Text}] Back Pressure (kPa) : {txtbx_CalBackpress.Text}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Calibration Result for {txtbx_CalLotID.Text}] DP Pressure (kPa) : {txtbx_CalOffset.Text}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Calibration Result for {txtbx_CalLotID.Text}] Flowrate (l/min) : {txtbx_CalFlowrate.Text}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Calibration Result for {txtbx_CalLotID.Text}] Temperature (C) : {txtbx_CalTemperature.Text}")

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

            ' Rolling Average
            Dim FinalFlowrate As Decimal = 0
            If True Then
                RollingAvgArr(RollingAvgCount) = AIn(12)

                If RollingAvgCount = RollingAvgArr.Length - 1 Then
                    RollingAvgCount = 0
                Else
                    RollingAvgCount += 1
                End If

                Dim FlwrateTemp As Decimal = 0
                For i As Integer = 0 To RollingAvgArr.Length - 1
                    FlwrateTemp += RollingAvgArr(i)
                Next
                FinalFlowrate = FlwrateTemp / RollingAvgArr.Length
            End If

            Dim newrw As DataRow = dtVerification.NewRow
            Ver_samplingtime += CType((tmr_Verification.Interval / 1000), Decimal)
            Ver_inletpressure = AIn(9)
            Ver_outletpressure = AIn(10)
            Ver_flowrate = FinalFlowrate
            Ver_temperature = AIn(13)
            Ver_backpressure = AIn(1)
            Ver_pumprpm = AIn(2)
            Ver_dp = Ver_inletpressure - Ver_outletpressure
            newrw(0) = Ver_samplingtime
            newrw(1) = Ver_temperature
            newrw(2) = Ver_flowrate
            newrw(3) = Ver_inletpressure
            newrw(4) = Ver_outletpressure
            newrw(5) = Ver_dp
            newrw(6) = Ver_backpressure
            newrw(7) = Ver_pumprpm
            dtVerification.Rows.InsertAt(newrw, 0)

            CalibrateChartDPValue.Add(New ObservablePoint With {
                .X = Ver_samplingtime,
                .Y = Ver_dp
            })
            CalibrateChartInletValue.Add(New ObservablePoint With {
                .X = Ver_samplingtime,
                .Y = Ver_inletpressure
            })
            CalibrateChartOutletValue.Add(New ObservablePoint With {
                .X = Ver_samplingtime,
                .Y = Ver_outletpressure
            })
            CalibrateChartBPValue.Add(New ObservablePoint With {
                .X = Ver_samplingtime,
                .Y = Ver_backpressure
            })
            CalibrateChartRPMValue.Add(New ObservablePoint With {
                .X = Ver_samplingtime,
                .Y = Ver_pumprpm
            })
            CalibrateChartFLWRValue.Add(New ObservablePoint With {
                .X = Ver_samplingtime,
                .Y = Ver_flowrate
            })
            CalibrateChartTempValue.Add(New ObservablePoint With {
                .X = Ver_samplingtime,
                .Y = Ver_temperature
            })

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
                .Columns(7).Width = 100

                'Header Cell Alignment
                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Header Cell Font Bold
                .Columns(0).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(1).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(2).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(3).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(4).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(5).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(6).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)
                .Columns(7).HeaderCell.Style.Font = New Font(dgv_CalibrationResult.Font, FontStyle.Bold)

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
                Ver_finaldp = ((1.002 / Viscosity) * (Ver_finalinlet - Ver_finaloutlet)) - CType(txtbx_CalOffset.Text, Decimal)



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
                Ver_finaldp = ((1.002 / Viscosity) * (Ver_finalinlet - Ver_finaloutlet)) - CType(txtbx_CalOffset.Text, Decimal)



            End If
            'txtbx_VerInletPressure.Text = CType(Ver_finalinlet, String)
            'txtbx_VerOutletPressure.Text = CType(Ver_finaloutlet, String)
            'txtbx_VerFlowrate.Text = CType(Ver_finalflowrate, String)
            'txtbx_VerTemperature.Text = CType(Ver_finaltemperature - 273.15, String)
            'txtbx_VerBackpress.Text = CType(Ver_finalbackpressure, String)
            'txtbx_VerStatus.Text = "Completed"
            'txtbx_VerStatus.BackColor = Color.FromArgb(192, 255, 192)

            txtbx_VerInletPressure.Text = Decimal.Round(Ver_finalinlet, 2)
            txtbx_VerOutletPressure.Text = Decimal.Round(Ver_finaloutlet, 2)
            txtbx_VerFlowrate.Text = Decimal.Round(Ver_finalflowrate, 2)
            txtbx_VerTemperature.Text = Decimal.Round(CDec(Ver_finaltemperature - 273.15), 2)
            txtbx_VerBackpress.Text = Decimal.Round(Ver_finalbackpressure, 2)
            txtbx_VerStatus.Text = "Completed"
            txtbx_VerStatus.BackColor = PublicVariables.StatusGreen
            txtbx_VerStatus.ForeColor = PublicVariables.StatusGreenT

            ' Convert Visible DataGridView Columns To DataTable

            If dgv_VerificationResult.RowCount = 0 Then

            Else
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Verification Result for {txtbx_CalLotID.Text}] Inlet Pressure (kPa) : {txtbx_VerInletPressure.Text}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Verification Result for {txtbx_CalLotID.Text}] Outlet Pressure (kPa) : {txtbx_VerOutletPressure.Text}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Verification Result for {txtbx_CalLotID.Text}] Back Pressure (kPa) : {txtbx_VerBackpress.Text}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Verification Result for {txtbx_CalLotID.Text}] DP Pressure (kPa) : {Ver_finaldp}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Verification Result for {txtbx_CalLotID.Text}] Flowrate (l/min) : {txtbx_VerFlowrate.Text}")
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Verification Result for {txtbx_CalLotID.Text}] Temperature (C) : {txtbx_VerTemperature.Text}")



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
                Dim min As Decimal = 0 ' CType(txtbx_CalOffset.Text, Decimal) - vertol
                Dim max As Decimal = 0 ' CType(txtbx_CalOffset.Text, Decimal) + vertol

                If vertol >= 0 Then
                    min = 0 - vertol
                    max = 0 + vertol
                End If

                If CType(txtbx_VerDP.Text, Decimal) >= min And CType(txtbx_VerDP.Text, Decimal) <= max Then
                    txtbx_CalResult.Text = "Pass"
                    txtbx_CalResult.BackColor = PublicVariables.StatusGreen
                    txtbx_CalResult.ForeColor = PublicVariables.StatusGreenT
                    FormMain.lbl_CalibrationStatus.Text = "Pass"
                    FormMain.lbl_CalibrationStatus.BackColor = PublicVariables.StatusGreen
                    FormMain.lbl_CalibrationStatus.ForeColor = PublicVariables.StatusGreenT
                    FormMain.lbl_BlankDP.Text = txtbx_CalOffset.Text

                Else
                    txtbx_CalResult.Text = "Fail"
                    txtbx_CalResult.BackColor = PublicVariables.StatusRed
                    txtbx_CalResult.ForeColor = PublicVariables.StatusRedT
                    FormMain.lbl_CalibrationStatus.Text = "Fail"
                    FormMain.lbl_CalibrationStatus.BackColor = PublicVariables.StatusRed
                    FormMain.lbl_CalibrationStatus.ForeColor = PublicVariables.StatusRedT
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
        Dim dptestpoints As Integer

        Dim flush1cycletime As Integer
        Dim flush2cycletime As Integer
        Dim DPtest1cycletime As Integer
        Dim DPtest2cycletime As Integer
        Dim Drain1cycletime As Integer
        Dim Drain2cycletime As Integer
        Dim Drain3cycletime As Integer

        Dim DP1Enabled As Boolean = False
        Dim DP2Enabled As Boolean = False

        Dim Flush1Enabled As Boolean = False
        Dim Flush2Enabled As Boolean = False

        Dim Drain1Enabled As Boolean = False
        Dim Drain2Enabled As Boolean = False
        Dim Drain3Enabled As Boolean = False

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

                Cal_backpressure = 0
                Cal_avgbackpressure1 = 0
                Cal_avgbackpressure2 = 0
                Cal_finalbackpressure = 0

                ' Define Values
                Dim DPFillTime As Integer = dtrecipetable.Rows(0)("dp_fill_time")
                Dim DPBleedTime As Integer = dtrecipetable.Rows(0)("dp_bleed_time")
                Dim DPStabilizeTime As Integer = dtrecipetable.Rows(0)("dp_stabilize_time")
                Dim DPTestTime As Integer = dtrecipetable.Rows(0)("dp_test_time")

                Dim Flush1FillTime As Integer = dtrecipetable.Rows(0)("firstflush_fill_time")
                Dim Flush1BleedTime As Integer = dtrecipetable.Rows(0)("firstflush_bleed_time")
                Dim Flush1StabilizeTime As Integer = dtrecipetable.Rows(0)("firstflush_stabilize_time")
                Dim Flush1TestTime As Integer = dtrecipetable.Rows(0)("firstflush_time")

                Dim Flush2FillTime As Integer = dtrecipetable.Rows(0)("secondflush_fill_time")
                Dim Flush2BleedTime As Integer = dtrecipetable.Rows(0)("secondflush_bleed_time")
                Dim Flush2StabilizeTime As Integer = dtrecipetable.Rows(0)("secondflush_stabilize_time")
                Dim Flush2TestTime As Integer = dtrecipetable.Rows(0)("secondflush_time")

                Dim Drain1Time As Integer = dtrecipetable.Rows(0)("drain1_time")
                Dim Drain2Time As Integer = dtrecipetable.Rows(0)("drain2_time")
                Dim Drain3Time As Integer = dtrecipetable.Rows(0)("drain3_time")

                ' Reset Rolling Average
                For i As Integer = 0 To RollingAvgArr.Length - 1
                    RollingAvgArr(i) = 0
                Next
                RollingAvgCount = 0

                ' Clear Live Graph Value
                CalibrateChartDPValue.Clear()
                CalibrateChartInletValue.Clear()
                CalibrateChartOutletValue.Clear()
                CalibrateChartBPValue.Clear()
                CalibrateChartRPMValue.Clear()
                CalibrateChartFLWRValue.Clear()
                CalibrateChartTempValue.Clear()

                ' Get Recipe Details
                Dim dtGetRecipe As DataTable = SQL.ReadRecords($"Select * From RecipeTable WHERE recipe_id ='{txtbx_RecipeID.Text}'")
                If dtrecipetable.Rows(0)("firstflush_circuit") = "Enable" Then

                    flush1cycletime = (dtrecipetable.Rows(0)("firstflush_fill_time") + dtrecipetable.Rows(0)("firstflush_bleed_time") + dtrecipetable.Rows(0)("firstflush_stabilize_time") + dtrecipetable.Rows(0)("firstflush_time"))
                    Flush1Enabled = True
                End If

                If dtrecipetable.Rows(0)("secondflush_circuit") = "Enable" Then
                    flush2cycletime = (dtrecipetable.Rows(0)("secondflush_fill_time") + dtrecipetable.Rows(0)("secondflush_bleed_time") + dtrecipetable.Rows(0)("secondflush_stabilize_time") + dtrecipetable.Rows(0)("secondflush_time"))
                    Flush2Enabled = True
                End If

                dptestpoints = dtrecipetable.Rows(0)("dp_testpoints")

                If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And dtrecipetable.Rows(0)("firstflush_circuit") = "Disable" Then
                    DPtest1cycletime = (dtrecipetable.Rows(0)("dp_fill_time") + dtrecipetable.Rows(0)("dp_bleed_time") + dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
                    DP1Enabled = True
                ElseIf dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And dtrecipetable.Rows(0)("firstflush_circuit") = "Enable" Then
                    DPtest1cycletime = (dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
                    DP1Enabled = True
                End If

                If dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" And dtrecipetable.Rows(0)("secondflush_circuit") = "Disable" Then
                    DPtest2cycletime = (dtrecipetable.Rows(0)("dp_fill_time") + dtrecipetable.Rows(0)("dp_bleed_time") + dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
                    DP2Enabled = True
                ElseIf dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" And dtrecipetable.Rows(0)("secondflush_circuit") = "Enable" Then
                    DPtest2cycletime = (dtrecipetable.Rows(0)("dp_stabilize_time") + dtrecipetable.Rows(0)("dp_test_time"))
                    DP2Enabled = True
                End If

                If dtrecipetable.Rows(0)("drain1_circuit") = "Enable" Then
                    Drain1cycletime = (dtrecipetable.Rows(0)("drain1_time"))
                    Drain1Enabled = True
                End If
                If dtrecipetable.Rows(0)("drain2_circuit") = "Enable" Then
                    Drain2cycletime = (dtrecipetable.Rows(0)("drain2_time"))
                    Drain2Enabled = True
                End If
                If dtrecipetable.Rows(0)("drain3_circuit") = "Enable" Then
                    Drain3cycletime = (dtrecipetable.Rows(0)("drain3_time"))
                    Drain3Enabled = True
                End If

                ' Set Live Graph Cycle Time
                Dim TotalCycleTime As Integer = flush1cycletime + flush2cycletime + DPtest1cycletime + DPtest2cycletime + Drain1cycletime + Drain2cycletime + Drain3cycletime
                InitializeLiveChartXAxes(TotalCycleTime)

                ' Set Live Graph Sections
                If True Then
                    Dim Flush1Start As Decimal = 0
                    Dim DP1Start As Decimal = 0

                    Dim Flush2Start As Decimal = 0
                    Dim DP2Start As Decimal = 0

                    Dim Drain1Start As Decimal = 0
                    Dim Drain2Start As Decimal = 0
                    Dim Drain3Start As Decimal = 0

                    Dim CycleTimeTotal As Decimal = 0

                    If True Then
                        If Flush1Enabled Then
                            DP1Start = flush1cycletime
                        End If

                        If DP1Enabled Then
                            Flush2Start = DP1Start + DPtest1cycletime
                        Else
                            Flush2Start = DP1Start
                        End If

                        If Flush2Enabled Then
                            DP2Start = Flush2Start + flush2cycletime
                        Else
                            DP2Start = Flush2Start
                        End If

                        If DP2Enabled Then
                            Drain1Start = DP2Start + DPtest2cycletime
                        Else
                            Drain1Start = DP2Start
                        End If

                        If Drain1Enabled Then
                            Drain2Start = Drain1Start + Drain1cycletime
                        Else
                            Drain2Start = Drain1Start
                        End If

                        If Drain2Enabled Then
                            Drain3Start = Drain2Start + Drain2cycletime
                        Else
                            Drain3Start = Drain2Start
                        End If

                        If Drain3Enabled Then
                            CycleTimeTotal = Drain3Start + Drain3cycletime
                        Else
                            CycleTimeTotal = Drain3Start
                        End If
                    End If

                    Dim ShowDP1Section As Boolean = DP1Enabled
                    Dim ShowDP2Section As Boolean = DP2Enabled

                    'If cmbx_LiveGraphSelection.SelectedIndex > 0 Then
                    '    ShowDP1Section = False
                    '    ShowDP2Section = False
                    'End If

                    '.Yi = CDbl(dtrecipetable.Rows(0)("dp_upperlimit")),
                    '.Yj = CDbl(dtrecipetable.Rows(0)("dp_lowerlimit")),

                    CartesianChart_CalibrationLiveGraph.Sections = New RectangularSection() {
                    New RectangularSection With {
                        .IsVisible = DP1Enabled,
                        .Xi = CInt((Flush2Start - 1) - (dptestpoints * (Resultcapturetimer.Interval / 1000))),
                        .Xj = Flush2Start - 1,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.Black,
                            .StrokeThickness = 1,
                            .PathEffect = New DashEffect(New Single() {6, 6})
                        }
                    },
                    New RectangularSection With {
                        .IsVisible = DP2Enabled,
                        .Xi = CInt((Drain1Start - 1) - (dptestpoints * (Resultcapturetimer.Interval / 1000))),
                        .Xj = Drain1Start - 1,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.Black,
                            .StrokeThickness = 1,
                            .PathEffect = New DashEffect(New Single() {6, 6})
                        }
                    },
                      _ ' Flush 1
                    New RectangularSection With {
                        .IsVisible = Flush1Enabled,
                        .Xi = Flush1Start,
                        .Xj = DP1Start,
                        .Fill = New SolidColorPaint With {.Color = SKColors.Violet.WithAlpha(20)},
                        .Label = "",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = Flush1Enabled,
                        .Xi = Flush1Start,
                        .Xj = Flush1Start + Flush1FillTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = $"Flush 1 - Fill",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = Flush1Enabled,
                        .Xi = Flush1Start + Flush1FillTime,
                        .Xj = Flush1Start + Flush1FillTime + Flush1BleedTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Vent",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = Flush1Enabled,
                        .Xi = Flush1Start + Flush1FillTime + Flush1BleedTime,
                        .Xj = Flush1Start + Flush1FillTime + Flush1BleedTime + Flush1StabilizeTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Stab",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = Flush1Enabled,
                        .Xi = Flush1Start + Flush1FillTime + Flush1BleedTime + Flush1StabilizeTime,
                        .Xj = DP1Start,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Test",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                      _ ' DP 1
                    New RectangularSection With {
                        .IsVisible = DP1Enabled,
                        .Xi = DP1Start,
                        .Xj = Flush2Start,
                        .Fill = New SolidColorPaint With {.Color = SKColors.Blue.WithAlpha(20)},
                        .Label = "",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = IIf(DP1Enabled, IIf(Flush1Enabled, False, True), False),
                        .Xi = DP1Start,
                        .Xj = DP1Start + DPFillTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = $"DP 1 - Fill",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = IIf(DP1Enabled, IIf(Flush1Enabled, False, True), False),
                        .Xi = DP1Start + DPFillTime,
                        .Xj = DP1Start + DPFillTime + DPBleedTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Vent",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = DP1Enabled,
                        .Xi = CDec(IIf(Flush1Enabled, DP1Start, DP1Start + DPFillTime + DPBleedTime)),
                        .Xj = CDec(IIf(Flush1Enabled, DP1Start + DPStabilizeTime, DP1Start + DPFillTime + DPBleedTime + DPStabilizeTime)),
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = IIf(Flush1Enabled, $"DP 1 - Stab", "Stab"),
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = DP1Enabled,
                        .Xi = CDec(IIf(Flush1Enabled, DP1Start + DPStabilizeTime, DP1Start + DPFillTime + DPBleedTime + DPStabilizeTime)),
                        .Xj = Flush2Start,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Test",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                      _ ' Flush 2
                    New RectangularSection With {
                        .IsVisible = Flush2Enabled,
                        .Xi = Flush2Start,
                        .Xj = DP2Start,
                        .Fill = New SolidColorPaint With {.Color = SKColors.Violet.WithAlpha(20)},
                        .Label = "",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = Flush2Enabled,
                        .Xi = Flush2Start,
                        .Xj = Flush2Start + Flush2FillTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = $"Flush 2 - Fill",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = Flush2Enabled,
                        .Xi = Flush2Start + Flush2FillTime,
                        .Xj = Flush2Start + Flush2FillTime + Flush2BleedTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Vent",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = Flush2Enabled,
                        .Xi = Flush2Start + Flush2FillTime + Flush2BleedTime,
                        .Xj = Flush2Start + Flush2FillTime + Flush2BleedTime + Flush2StabilizeTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Stab",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = Flush2Enabled,
                        .Xi = Flush2Start + Flush2FillTime + Flush2BleedTime + Flush2StabilizeTime,
                        .Xj = DP1Start,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Test",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                      _ ' DP 2
                    New RectangularSection With {
                        .IsVisible = DP2Enabled,
                        .Xi = DP2Start,
                        .Xj = Drain1Start,
                        .Fill = New SolidColorPaint With {.Color = SKColors.Blue.WithAlpha(20)},
                        .Label = "",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = IIf(DP2Enabled, IIf(Flush1Enabled, False, True), False),
                        .Xi = DP2Start,
                        .Xj = DP2Start + DPFillTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = $"DP 2 - Fill",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = IIf(DP2Enabled, IIf(Flush1Enabled, False, True), False),
                        .Xi = DP2Start + DPFillTime,
                        .Xj = DP2Start + DPFillTime + DPBleedTime,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Vent",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = DP2Enabled,
                        .Xi = CDec(IIf(Flush2Enabled, DP2Start, DP2Start + DPFillTime + DPBleedTime)),
                        .Xj = CDec(IIf(Flush2Enabled, DP2Start + DPStabilizeTime, DP2Start + DPFillTime + DPBleedTime + DPStabilizeTime)),
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = IIf(Flush1Enabled, $"DP 1 - Stab", "Stab"),
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                    New RectangularSection With {
                        .IsVisible = DP2Enabled,
                        .Xi = CDec(IIf(Flush2Enabled, DP2Start + DPStabilizeTime, DP2Start + DPFillTime + DPBleedTime + DPStabilizeTime)),
                        .Xj = Drain1Start,
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        },
                        .Label = "Test",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black}
                    },
                      _ ' Drain
                    New RectangularSection With {
                        .IsVisible = Drain1Enabled,
                        .Xi = Drain1Start,
                        .Xj = Drain2Start,
                        .Fill = New SolidColorPaint With {.Color = SKColors.Gray.WithAlpha(20)},
                        .Label = "Drain 1",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black},
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        }
                    },
                    New RectangularSection With {
                        .IsVisible = Drain2Enabled,
                        .Xi = Drain2Start,
                        .Xj = Drain3Start,
                        .Fill = New SolidColorPaint With {.Color = SKColors.Gray.WithAlpha(20)},
                        .Label = "Drain 2",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black},
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        }
                    },
                    New RectangularSection With {
                        .IsVisible = Drain3Enabled,
                        .Xi = Drain3Start,
                        .Xj = CycleTimeTotal,
                        .Fill = New SolidColorPaint With {.Color = SKColors.Gray.WithAlpha(20)},
                        .Label = "Drain 3",
                        .LabelSize = 12,
                        .LabelPaint = New SolidColorPaint With {.Color = SKColors.Black},
                        .Stroke = New SolidColorPaint With {
                            .Color = SKColors.LightGray,
                            .StrokeThickness = 1
                        }
                    }
                }
                End If

                checkbx_GraphDP.Checked = True
                checkbx_GraphInletPressure.Checked = False
                checkbx_GraphOutletPressure.Checked = False
                checkbx_GraphBP.Checked = False
                checkbx_GraphFlowrate.Checked = True
                checkbx_GraphTemperature.Checked = False
                checkbx_GraphRPM.Checked = False
                'SetVisibleLineSeries()

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

                Ver_backpressure = 0
                Ver_avgbackpressure1 = 0
                Ver_avgbackpressure2 = 0
                Ver_finalbackpressure = 0

                ' Reset Rolling Average
                For i As Integer = 0 To RollingAvgArr.Length - 1
                    RollingAvgArr(i) = 0
                Next
                RollingAvgCount = 0

                ' Clear Live Graph Value
                CalibrateChartDPValue.Clear()
                CalibrateChartInletValue.Clear()
                CalibrateChartOutletValue.Clear()
                CalibrateChartBPValue.Clear()
                CalibrateChartRPMValue.Clear()
                CalibrateChartFLWRValue.Clear()
                CalibrateChartTempValue.Clear()

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

    Private Sub checkbx_ShowTooltip_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_ShowTooltip.CheckedChanged
        If CartesianChart_CalibrationLiveGraph.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Hidden Then
            CartesianChart_CalibrationLiveGraph.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top

            If CartesianChart_CalibrationLiveGraph.XAxes.Count > 0 Then
                Dim XAxes As SkiaSharpView.Axis() = New SkiaSharpView.Axis() {
                    CartesianChart_CalibrationLiveGraph.XAxes(0)
                }
                With XAxes(0)
                    .CrosshairLabelsBackground = New SKColor(25, 130, 246, 255).AsLvcColor()
                    .CrosshairLabelsPaint = New SolidColorPaint(New SKColor(255, 255, 255, 255), 1)
                    .CrosshairPaint = New SolidColorPaint(New SKColor(25, 130, 246, 255), 1)
                    .CrosshairSnapEnabled = True
                End With
            End If

            If CartesianChart_CalibrationLiveGraph.YAxes.Count > 0 Then
                Dim YAxes As SkiaSharpView.Axis() = New SkiaSharpView.Axis() {
                    CartesianChart_CalibrationLiveGraph.YAxes(0)
                }
                With YAxes(0)
                    .CrosshairPaint = New SolidColorPaint(New SKColor(25, 130, 246, 255), 1)
                End With
            End If
        Else
            CartesianChart_CalibrationLiveGraph.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Hidden

            If CartesianChart_CalibrationLiveGraph.XAxes.Count > 0 Then
                Dim XAxes As SkiaSharpView.Axis() = New SkiaSharpView.Axis() {
                    CartesianChart_CalibrationLiveGraph.XAxes(0)
                }
                With XAxes(0)
                    .CrosshairLabelsBackground = New SKColor(25, 130, 246, 0).AsLvcColor()
                    .CrosshairLabelsPaint = New SolidColorPaint(New SKColor(255, 255, 255, 0), 1)
                    .CrosshairPaint = New SolidColorPaint(New SKColor(25, 130, 246, 0), 1)
                    .CrosshairSnapEnabled = True
                End With
            End If

            If CartesianChart_CalibrationLiveGraph.YAxes.Count > 0 Then
                Dim YAxes As SkiaSharpView.Axis() = New SkiaSharpView.Axis() {
                    CartesianChart_CalibrationLiveGraph.YAxes(0)
                }
                With YAxes(0)
                    .CrosshairPaint = New SolidColorPaint(New SKColor(25, 130, 246, 0), 1)
                End With
            End If
        End If
    End Sub
End Class