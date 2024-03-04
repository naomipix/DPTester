﻿Imports System.Collections.ObjectModel
Imports System.Media
Imports System.Windows.Forms.DataVisualization.Charting
Imports LiveChartsCore
Imports LiveChartsCore.Defaults
Imports LiveChartsCore.Kernel.Sketches
Imports LiveChartsCore.SkiaSharpView
Imports LiveChartsCore.SkiaSharpView.Painting
Imports LiveChartsCore.SkiaSharpView.Painting.Effects
Imports LiveChartsCore.SkiaSharpView.VisualElements
Imports LiveChartsCore.SkiaSharpView.WinForms
Imports SkiaSharp

Public Class FormResultGraph
    Dim ResultChartDPValue = New ObservableCollection(Of ObservablePoint)({})
    Dim ResultChartInletValue = New ObservableCollection(Of ObservablePoint)({})
    Dim ResultChartOutletValue = New ObservableCollection(Of ObservablePoint)({})
    Dim ResultChartBPValue = New ObservableCollection(Of ObservablePoint)({})
    Dim ResultChartFLWRValue = New ObservableCollection(Of ObservablePoint)({})
    Dim ResultChartTempValue = New ObservableCollection(Of ObservablePoint)({})
    Dim ResultChartRPMValue = New ObservableCollection(Of ObservablePoint)({})

    Dim ResultChartYAxesVisible As Boolean() = {True}

    Dim ResultChartDPBP = New ObservableCollection(Of ObservablePoint)({})
    Dim ResultChartDPFLWR = New ObservableCollection(Of ObservablePoint)({})

#Region "Form Loading"
    Private Sub FormResultGraph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Always Maximize
        Me.WindowState = FormWindowState.Maximized

        ' Load Version
        lbl_Version.Text = PublicVariables.AppVersion

        ' Load Form Title
        Me.Text = PublicVariables.ProgramTitle & " - " & "Result Graph"
        lbl_Title.Text = PublicVariables.ProgramTitle

        ' Load User Details
        lbl_Username.Text = PublicVariables.LoginUserName
        lbl_Category.Text = PublicVariables.LoginUserCategoryName

        ' Initialize Defaults
        InitializeResultChart()
        ComboBox1.SelectedIndex = 0

        txtbx_GraphTimestamp.Text = Nothing
        txtbx_GraphWorkOrder.Text = Nothing

        txtbx_GraphPartID.Text = Nothing
        txtbx_GraphConfirmation.Text = Nothing
        txtbx_GraphRecipeID.Text = Nothing
        txtbx_GraphCalOffset.Text = Nothing
        txtbx_GraphTemperature.Text = Nothing
        txtbx_GraphFlowrate.Text = Nothing
        txtbx_GraphInletPressure.Text = Nothing
        txtbx_GraphOutletPressure.Text = Nothing
        txtbx_GraphDiffPressure.Text = Nothing
        txtbx_GraphTest.Text = Nothing
        txtbx_Graphflush1.Text = Nothing
        txtbx_GraphDPTest1.Text = Nothing
        txtbx_Graphflush2.Text = Nothing
        txtbx_GraphDPTest2.Text = Nothing
        txtbx_GraphDrain1.Text = Nothing
        txtbx_GraphDrain2.Text = Nothing
        txtbx_GraphDrain3.Text = Nothing
        txtbx_GraphSerialUID.Text = Nothing
        txtbx_Graphattempt.Text = Nothing
        ResultChart.DataSource = Nothing
        ResultChart.Series.Clear()

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

    End Sub

    Private Sub FormResultGraph_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear Selection
        Me.Select()

        ' Display Form Control
        panel_FormControl.Visible = True

    End Sub

    Private Sub InitializeResultChartXAxes()
        CartesianChart_ResultGraph.XAxes = New ICartesianAxis() {
            New LiveChartsCore.SkiaSharpView.Axis() With {
                .Name = "Sampling Time (s)",
                .NameTextSize = 14,
                .NamePaint = New SolidColorPaint(SKColors.Black),
                .NamePadding = New LiveChartsCore.Drawing.Padding(0, 20),
                .Padding = New LiveChartsCore.Drawing.Padding(0, 20, 0, 0),
                .TextSize = 12,
                .LabelsPaint = New SolidColorPaint(SKColors.Black),
                .TicksPaint = New SolidColorPaint(SKColors.Black),
                .SubticksPaint = New SolidColorPaint(SKColors.Black),
                .DrawTicksPath = True,
                .MinLimit = 0,
                .MaxLimit = Nothing
            }
        }
    End Sub

    Private Sub InitializeResultChart()
        CartesianChart_ResultGraph.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Hidden
        CartesianChart_ResultGraph.TooltipTextSize = 12
        CartesianChart_ResultGraph.TooltipBackgroundPaint = New SolidColorPaint(New SKColor(0, 0, 0, 10))
        CartesianChart_ResultGraph.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right
        CartesianChart_ResultGraph.LegendTextSize = 12
        CartesianChart_ResultGraph.ZoomMode = Measure.ZoomAndPanMode.X

        CartesianChart_ResultGraph.Title = New LabelVisual() With {
            .Text = "Result Graph",
            .TextSize = 14,
            .Padding = New LiveChartsCore.Drawing.Padding(15),
            .Paint = New SolidColorPaint(SKColors.Black)
        }

        InitializeResultChartXAxes()

        CartesianChart_ResultGraph.YAxes = New ICartesianAxis() {
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

        CartesianChart_ResultGraph.Series = New ISeries() {
            New LineSeries(Of ObservablePoint)() With {
                .Name = "Diff. Pressure",
                .Values = ResultChartDPValue,
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
                .Values = ResultChartInletValue,
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
                .Values = ResultChartOutletValue,
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
                .Values = ResultChartBPValue,
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
                .Values = ResultChartRPMValue,
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
                .Values = ResultChartFLWRValue,
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
                .Values = ResultChartTempValue,
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
        For Each Lotcmbx As ComboBox In {cmbx_GraphSearchLot}
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



    Private Sub cmbx_GraphSearchLot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_GraphSearchLot.SelectedIndexChanged
        Dim SerialcomboSource As New Dictionary(Of String, String)()
        Dim Lotid As String = cmbx_GraphSearchLot.Text

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
        For Each Serialcmbx As ComboBox In {cmbx_GraphSearchSerial}
            With Serialcmbx
                .DataSource = New BindingSource(SerialcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next

        If cmbx_GraphSearchLot.SelectedIndex > 0 Then
            If cmbx_GraphSearchSerial.Items.Count <= 1 Then
                ResultMessage(8)
            End If
            cmbx_GraphSearchSerial.Enabled = True
        Else
            cmbx_GraphSearchSerial.Enabled = False
        End If
    End Sub



    Private Sub cmbx_GraphSearchSerial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_GraphSearchSerial.SelectedIndexChanged
        Dim AttemptcomboSource As New Dictionary(Of String, String)()
        Dim Lotid As String = cmbx_GraphSearchLot.Text
        Dim Lotusageid As Integer = cmbx_GraphSearchLot.SelectedIndex
        Dim serialnum As String = cmbx_GraphSearchSerial.Text

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
        For Each Attemptcmbx As ComboBox In {cmbx_GraphSearchAttempt}
            With Attemptcmbx
                .DataSource = New BindingSource(AttemptcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next

        If cmbx_GraphSearchSerial.SelectedIndex > 0 Then
            If cmbx_GraphSearchAttempt.Items.Count <= 1 Then
                ResultMessage(7)
            End If
            cmbx_GraphSearchAttempt.Enabled = True
        Else
            cmbx_GraphSearchAttempt.Enabled = False
        End If

    End Sub

    Private Sub cmbx_GraphSearchAttempt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_GraphSearchAttempt.SelectedIndexChanged
        If cmbx_GraphSearchAttempt.SelectedIndex > 0 Then
            btn_GraphSearch.Enabled = True
        Else
            btn_GraphSearch.Enabled = False
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
    Private Sub btn_GraphSearch_Click(sender As Object, e As EventArgs) Handles btn_GraphSearch.Click
        Dim Lotid As String = cmbx_GraphSearchLot.Text
        Dim serialnum As String = cmbx_GraphSearchSerial.Text
        Dim attempt As String = cmbx_GraphSearchAttempt.Text



        Dim Oncontinue As Boolean = True
        If Oncontinue = True Then
            If cmbx_GraphSearchLot.SelectedIndex <= 0 Then
                ResultMessage(1)
                Oncontinue = False
            End If
        End If

        If Oncontinue = True Then
            If cmbx_GraphSearchSerial.SelectedIndex <= 0 Then
                ResultMessage(2)
                Oncontinue = False
            End If
        End If

        If Oncontinue = True Then
            If cmbx_GraphSearchAttempt.SelectedIndex <= 0 Then
                ResultMessage(3)
                Oncontinue = False
            End If
        End If



        If Oncontinue = True Then
            LoadResult(Lotid, serialnum, attempt)
        End If


    End Sub
#End Region


#Region "Graph Creation"
    Public Sub CreateResultGraph()
        ResultChart.Series.Clear()

        Dim SeriesDP As Series = New Series("DP")
        SeriesDP.ChartType = SeriesChartType.Line 'To set the series chart type as Line Graph
        SeriesDP.MarkerStyle = MarkerStyle.Circle 'To set the markerstyle as circle, so that the datapoints are visible as circle in the graph
        SeriesDP.Color = Color.Blue 'To Set the Line graph colour
        SeriesDP.LegendText = "DP (Kpa)" 'To change the text shown as Legend

        Dim SeriesInlet As Series = New Series("Inlet Pressure")
        SeriesInlet.ChartType = SeriesChartType.Line
        SeriesInlet.MarkerStyle = MarkerStyle.Circle
        SeriesInlet.Color = Color.Green
        SeriesInlet.LegendText = "Inlet Pressure (Kpa)"

        Dim SeriesOutlet As Series = New Series("Outlet Pressure")
        SeriesOutlet.ChartType = SeriesChartType.Line
        SeriesOutlet.MarkerStyle = MarkerStyle.Circle
        SeriesOutlet.Color = Color.DarkViolet
        SeriesOutlet.LegendText = "Outlet Pressure (Kpa)"

        Dim SeriesFlowrate As Series = New Series("Flowrate")
        SeriesFlowrate.ChartType = SeriesChartType.Line
        SeriesFlowrate.MarkerStyle = MarkerStyle.Circle
        SeriesFlowrate.Color = Color.RosyBrown
        SeriesFlowrate.LegendText = "Flowrate (l/min)"

        Dim SeriesTemperature As Series = New Series("Temperature")
        SeriesTemperature.ChartType = SeriesChartType.Line
        SeriesTemperature.MarkerStyle = MarkerStyle.Circle
        SeriesTemperature.Color = Color.Red
        SeriesTemperature.LegendText = "Temperature (K)"


        If checkbx_GraphDP.Checked = True Then
            ResultChart.Series.Add(SeriesDP)

            With ResultChart.Series("DP")
                .Points.Clear()
                .XValueMember = "sampling_time"
                .YValueMembers = "calculated_dp_pressure"
                ' .IsValueShownAsLabel = True (To Show Data Points label with X and Y Coordinate)
                '.LabelToolTip = "X= #VALX, Y= #VALY" (To Show X and Y value when clicking on the datapoint label)
                .ToolTip = "X= #VALX, Y= #VALY"   '(To Show X and Y value when clicking on the datapoint itself)

            End With

            With CartesianChart_ResultGraph
                .Series(0).IsVisible = True
            End With
        Else
            With CartesianChart_ResultGraph
                .Series(0).IsVisible = False
            End With
        End If

        If checkbx_GraphInletPressure.Checked = True Then
            ResultChart.Series.Add(SeriesInlet)

            With ResultChart.Series("Inlet Pressure")
                .Points.Clear()
                .XValueMember = "sampling_time"
                .YValueMembers = "inlet_pressure"
                ' .IsValueShownAsLabel = True (To Show Data Points label with X and Y Coordinate)
                '.LabelToolTip = "X= #VALX, Y= #VALY" (To Show X and Y value when clicking on the datapoint label)
                .ToolTip = "X= #VALX, Y= #VALY"   '(To Show X and Y value when clicking on the datapoint itself)
            End With

            With CartesianChart_ResultGraph
                .Series(1).IsVisible = True
            End With
        Else
            With CartesianChart_ResultGraph
                .Series(1).IsVisible = False
            End With
        End If

        If checkbx_GraphOutletPressure.Checked = True Then
            ResultChart.Series.Add(SeriesOutlet)

            With ResultChart.Series("Outlet Pressure")
                .Points.Clear()
                .XValueMember = "sampling_time"
                .YValueMembers = "outlet_pressure"
                ' .IsValueShownAsLabel = True (To Show Data Points label with X and Y Coordinate)
                '.LabelToolTip = "X= #VALX, Y= #VALY" (To Show X and Y value when clicking on the datapoint label)
                .ToolTip = "X= #VALX, Y= #VALY"   '(To Show X and Y value when clicking on the datapoint itself)
            End With

            With CartesianChart_ResultGraph
                .Series(2).IsVisible = True
            End With
        Else
            With CartesianChart_ResultGraph
                .Series(2).IsVisible = False
            End With
        End If

        If checkbx_GraphBP.Checked = True Then
            With CartesianChart_ResultGraph
                .Series(3).IsVisible = True
            End With
        Else
            With CartesianChart_ResultGraph
                .Series(3).IsVisible = False
            End With
        End If

        If checkbx_GraphFlowrate.Checked = True Then
            ResultChart.Series.Add(SeriesFlowrate)

            With ResultChart.Series("Flowrate")
                .Points.Clear()
                .XValueMember = "sampling_time"
                .YValueMembers = "flowrate"
                ' .IsValueShownAsLabel = True (To Show Data Points label with X and Y Coordinate)
                '.LabelToolTip = "X= #VALX, Y= #VALY" (To Show X and Y value when clicking on the datapoint label)
                .ToolTip = "X= #VALX, Y= #VALY"   '(To Show X and Y value when clicking on the datapoint itself)
            End With

            With CartesianChart_ResultGraph
                .Series(5).IsVisible = True
                .YAxes(3).IsVisible = True
            End With
        Else
            With CartesianChart_ResultGraph
                .Series(5).IsVisible = False
                .YAxes(3).IsVisible = False
            End With
        End If

        If checkbx_GraphTemperature.Checked = True Then
            ResultChart.Series.Add(SeriesTemperature)

            With ResultChart.Series("Temperature")
                .Points.Clear()
                .XValueMember = "sampling_time"
                .YValueMembers = "temperature"
                ' .IsValueShownAsLabel = True (To Show Data Points label with X and Y Coordinate)
                '.LabelToolTip = "X= #VALX, Y= #VALY" (To Show X and Y value when clicking on the datapoint label)
                .ToolTip = "X= #VALX, Y= #VALY"   '(To Show X and Y value when clicking on the datapoint itself)
            End With

            With CartesianChart_ResultGraph
                .Series(6).IsVisible = True
                .YAxes(2).IsVisible = True
            End With
        Else
            With CartesianChart_ResultGraph
                .Series(6).IsVisible = False
                .YAxes(2).IsVisible = False
            End With
        End If

        If checkbx_GraphRPM.Checked = True Then
            With CartesianChart_ResultGraph
                .Series(4).IsVisible = True
                .YAxes(1).IsVisible = True
            End With
        Else
            With CartesianChart_ResultGraph
                .Series(4).IsVisible = False
                .YAxes(1).IsVisible = False
            End With
        End If


    End Sub

    Public Sub CreateResultGraphNew(dtResult As DataTable, resultsummary As String())
        ' Clear Result Graph Value
        ResultChartDPValue.Clear()
        ResultChartInletValue.Clear()
        ResultChartOutletValue.Clear()
        ResultChartBPValue.Clear()
        ResultChartFLWRValue.Clear()
        ResultChartTempValue.Clear()
        ResultChartRPMValue.Clear()

        ' Populate Result Graph Values
        For i As Integer = 0 To dtResult.Rows.Count - 1
            Dim XValue As Double = 0

            ResultChartDPValue.Add(New ObservablePoint With {
                .X = CDbl(dtResult(i)("sampling_time")),
                .Y = CDbl(dtResult(i)("calculated_dp_pressure"))
            })
            ResultChartInletValue.Add(New ObservablePoint With {
                .X = CDbl(dtResult(i)("sampling_time")),
                .Y = CDbl(dtResult(i)("inlet_pressure"))
            })
            ResultChartOutletValue.Add(New ObservablePoint With {
                .X = CDbl(dtResult(i)("sampling_time")),
                .Y = CDbl(dtResult(i)("outlet_pressure"))
            })
            ResultChartBPValue.Add(New ObservablePoint With {
                .X = CDbl(dtResult(i)("sampling_time")),
                .Y = CDbl(dtResult(i)("back_pressure"))
            })
            ResultChartFLWRValue.Add(New ObservablePoint With {
                .X = CDbl(dtResult(i)("sampling_time")),
                .Y = CDbl(dtResult(i)("flowrate"))
            })
            ResultChartTempValue.Add(New ObservablePoint With {
                .X = CDbl(dtResult(i)("sampling_time")),
                .Y = CDbl(dtResult(i)("temperature"))
            })
            ResultChartRPMValue.Add(New ObservablePoint With {
                .X = CDbl(dtResult(i)("sampling_time")),
                .Y = CDbl(dtResult(i)("pump_rpm"))
            })

            ResultChartDPBP.Add(New ObservablePoint With {
                .X = CDbl(dtResult(i)("back_pressure")),
                .Y = CDbl(dtResult(i)("calculated_dp_pressure"))
            })
            ResultChartDPFLWR.Add(New ObservablePoint With {
                .X = CDbl(dtResult(i)("flowrate")),
                .Y = CDbl(dtResult(i)("calculated_dp_pressure"))
            })
        Next

        ' Autoscale YAxis (Temperature)
        If True Then
            Dim TempMaxLimit As Decimal = 0
            Dim TempMinLimit As Decimal = 0
            Dim TempDifference As Integer = 5

            For i As Integer = 0 To ResultChartTempValue.Count - 1
                Dim maxVal As Decimal = 0
                Dim minVal As Decimal = 0

                maxVal = ResultChartTempValue(i).Y + TempDifference
                minVal = ResultChartTempValue(i).Y - TempDifference

                If i = 0 Then
                    TempMaxLimit = maxVal
                    TempMinLimit = minVal
                Else
                    If maxVal > TempMaxLimit Then
                        TempMaxLimit = maxVal
                    End If
                    If minVal < TempMinLimit Then
                        TempMinLimit = minVal
                    End If
                End If
            Next

            With CartesianChart_ResultGraph.YAxes(2)
                .MaxLimit = Math.Ceiling(TempMaxLimit)
                .MinLimit = Math.Floor(TempMinLimit)
            End With
        End If

        ' Read from LotUsageTable
        If True Then

        End If

        ' Set Result Graph Sections
        If True Then
            Dim Flush1Enabled As Boolean = False
            Dim DP1Enabled As Boolean = False

            Dim Flush2Enabled As Boolean = False
            Dim DP2Enabled As Boolean = False

            Dim Drain1Enabled As Boolean = False
            Dim Drain2Enabled As Boolean = False
            Dim Drain3Enabled As Boolean = False

            If True Then
                If resultsummary(40 - 8) = "Enable" Then
                    Flush1Enabled = True
                End If
                If resultsummary(48 - 8) = "Enable" Then
                    DP1Enabled = True
                End If
                If resultsummary(59 - 8) = "Enable" Then
                    Flush2Enabled = True
                End If
                If resultsummary(60 - 8) = "Enable" Then
                    DP2Enabled = True
                End If
                If resultsummary(68 - 8) = "Enable" Then
                    Drain1Enabled = True
                End If
                If resultsummary(71 - 8) = "Enable" Then
                    Drain2Enabled = True
                End If
                If resultsummary(74 - 8) = "Enable" Then
                    Drain3Enabled = True
                End If
            End If

            Dim DPtest1cycletime As Integer
            Dim DPtest2cycletime As Integer

            'Dim DPFillTime As Integer = CInt(resultsummary(49 - 8))
            'Dim DPBleedTime As Integer = CInt(resultsummary(50 - 8))
            'Dim DPStabilizeTime As Integer = CInt(resultsummary(54 - 8))
            'Dim DPTestTime As Integer = CInt(resultsummary(55 - 8))

            'Dim Flush1FillTime As Integer = CInt(resultsummary(41 - 8))
            'Dim Flush1BleedTime As Integer = CInt(resultsummary(42 - 8))
            'Dim Flush1StabilizeTime As Integer = CInt(resultsummary(46 - 8))
            'Dim Flush1TestTime As Integer = CInt(resultsummary(47 - 8))

            'Dim Flush2FillTime As Integer = CInt(resultsummary(61 - 8))
            'Dim Flush2BleedTime As Integer = CInt(resultsummary(62 - 8))
            'Dim Flush2StabilizeTime As Integer = CInt(resultsummary(66 - 8))
            'Dim Flush2TestTime As Integer = CInt(resultsummary(67 - 8))

            'Dim Drain1Time As Integer = CInt(resultsummary(70 - 8))
            'Dim Drain2Time As Integer = CInt(resultsummary(73 - 8))
            'Dim Drain3Time As Integer = CInt(resultsummary(76 - 8))

            Dim DPFillTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(49 - 8), DPFillTime), DPFillTime, 0)) 'CInt(resultsummary(49 - 8))
            Dim DPBleedTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(50 - 8), DPBleedTime), DPBleedTime, 0)) 'CInt(resultsummary(50 - 8))
            Dim DPStabilizeTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(54 - 8), DPStabilizeTime), DPStabilizeTime, 0)) 'CInt(resultsummary(54 - 8))
            Dim DPTestTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(55 - 8), DPTestTime), DPTestTime, 0)) 'CInt(resultsummary(55 - 8))

            Dim Flush1FillTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(41 - 8), Flush1FillTime), Flush1FillTime, 0)) 'CInt(resultsummary(41 - 8))
            Dim Flush1BleedTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(42 - 8), Flush1BleedTime), Flush1BleedTime, 0)) 'CInt(resultsummary(42 - 8))
            Dim Flush1StabilizeTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(46 - 8), Flush1StabilizeTime), Flush1StabilizeTime, 0)) 'CInt(resultsummary(46 - 8))
            Dim Flush1TestTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(47 - 8), Flush1TestTime), Flush1TestTime, 0)) 'CInt(resultsummary(47 - 8))

            Dim Flush2FillTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(61 - 8), Flush2FillTime), Flush2FillTime, 0)) 'CInt(resultsummary(61 - 8))
            Dim Flush2BleedTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(62 - 8), Flush2BleedTime), Flush2BleedTime, 0)) 'CInt(resultsummary(62 - 8))
            Dim Flush2StabilizeTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(66 - 8), Flush2StabilizeTime), Flush2StabilizeTime, 0)) 'CInt(resultsummary(66 - 8))
            Dim Flush2TestTime As Integer = CInt(IIf(Integer.TryParse(resultsummary(67 - 8), Flush2TestTime), Flush2TestTime, 0)) 'CInt(resultsummary(67 - 8))

            Dim Drain1Time As Integer = CInt(IIf(Integer.TryParse(resultsummary(70 - 8), Drain1Time), Drain1Time, 0)) 'CInt(resultsummary(70 - 8))
            Dim Drain2Time As Integer = CInt(IIf(Integer.TryParse(resultsummary(73 - 8), Drain2Time), Drain2Time, 0)) 'CInt(resultsummary(73 - 8))
            Dim Drain3Time As Integer = CInt(IIf(Integer.TryParse(resultsummary(76 - 8), Drain3Time), Drain3Time, 0)) 'CInt(resultsummary(76 - 8))

            If True Then
                If DP1Enabled And Flush1Enabled = False Then
                    DPtest1cycletime = DPFillTime + DPBleedTime + DPStabilizeTime + DPTestTime
                ElseIf DP1Enabled And Flush1Enabled Then
                    DPtest1cycletime = DPStabilizeTime + DPTestTime
                End If

                If DP2Enabled And Flush2Enabled = False Then
                    DPtest2cycletime = DPFillTime + DPBleedTime + DPStabilizeTime + DPTestTime
                ElseIf DP2Enabled And Flush2Enabled Then
                    DPtest2cycletime = DPStabilizeTime + DPTestTime
                End If
            End If


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
                    DP1Start = Flush1FillTime + Flush1BleedTime + Flush1StabilizeTime + Flush1TestTime
                End If

                If DP1Enabled Then
                    Flush2Start = DP1Start + DPtest1cycletime
                Else
                    Flush2Start = DP1Start
                End If

                If Flush2Enabled Then
                    DP2Start = Flush2Start + Flush2FillTime + Flush2BleedTime + Flush2StabilizeTime + Flush2TestTime
                Else
                    DP2Start = Flush2Start
                End If

                If DP2Enabled Then
                    Drain1Start = DP2Start + DPtest2cycletime
                Else
                    Drain1Start = DP2Start
                End If

                If Drain1Enabled Then
                    Drain2Start = Drain1Start + Drain1Time
                Else
                    Drain2Start = Drain1Start
                End If

                If Drain2Enabled Then
                    Drain3Start = Drain2Start + Drain2Time
                Else
                    Drain3Start = Drain2Start
                End If

                If Drain3Enabled Then
                    CycleTimeTotal = Drain3Start + Drain3Time
                Else
                    CycleTimeTotal = Drain3Start
                End If
            End If

            Dim DP1CaptureStart As Decimal = Flush2Start
            Dim DP2CaptureStart As Decimal = Drain1Start

            If True Then
                Dim RowCountStart As Integer = 0
                For i As Integer = 0 To dtResult.Rows.Count - 1
                    If dtResult(i)("sampling_time") = DPtest1cycletime - DPTestTime Then
                        RowCountStart = i
                        Exit For
                    End If
                Next
                For i As Integer = 0 To dtResult.Rows.Count - 1
                    If dtResult(i)("sampling_time") = Flush2Start - 1 Then
                        If i - 10 > RowCountStart Then
                            RowCountStart = i - 10
                        End If
                        Exit For
                    End If
                Next
                If RowCountStart > 0 Then
                    DP1CaptureStart = CDec(dtResult(RowCountStart)("sampling_time"))
                End If
            End If
            If True Then
                Dim RowCountStart As Integer = 0
                For i As Integer = 0 To dtResult.Rows.Count - 1
                    If dtResult(i)("sampling_time") = DPtest2cycletime - DPTestTime Then
                        RowCountStart = i
                        Exit For
                    End If
                Next
                For i As Integer = 0 To dtResult.Rows.Count - 1
                    If dtResult(i)("sampling_time") = Drain1Start - 1 Then
                        If i - 10 > RowCountStart Then
                            RowCountStart = i - 10
                        End If
                        Exit For
                    End If
                Next
                If RowCountStart > 0 Then
                    DP2CaptureStart = CDec(dtResult(RowCountStart)("sampling_time"))
                End If
            End If

            '.Yi = CDec(resultsummary(56)),
            '.Yj = CDec(resultsummary(57)),

            CartesianChart_ResultGraph.Sections = New RectangularSection() {
                New RectangularSection With {
                    .IsVisible = DP1Enabled,
                    .Xi = DP1CaptureStart,
                    .Xj = Flush2Start - 1,
                    .Stroke = New SolidColorPaint With {
                        .Color = SKColors.Black,
                        .StrokeThickness = 1,
                        .PathEffect = New DashEffect(New Single() {6, 6})
                    }
                },
                New RectangularSection With {
                    .IsVisible = DP2Enabled,
                    .Xi = DP2CaptureStart,
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

            Array.Resize(ResultChartYAxesVisible, CartesianChart_ResultGraph.Sections.Count)
            For i As Integer = 0 To CartesianChart_ResultGraph.Sections.Count - 1
                ResultChartYAxesVisible(i) = CartesianChart_ResultGraph.Sections(i).IsVisible
            Next
        End If
    End Sub
#End Region


#Region "Graph Clear"
    Private Sub btn_GraphClear_Click(sender As Object, e As EventArgs) Handles btn_GraphClear.Click
        checkbx_GraphDP.Checked = False
        checkbx_GraphInletPressure.Checked = False
        checkbx_GraphOutletPressure.Checked = False
        txtbx_GraphTimestamp.Text = Nothing
        txtbx_GraphWorkOrder.Text = Nothing

        txtbx_GraphPartID.Text = Nothing
        txtbx_GraphConfirmation.Text = Nothing
        txtbx_GraphRecipeID.Text = Nothing
        txtbx_GraphCalOffset.Text = Nothing
        txtbx_GraphTemperature.Text = Nothing
        txtbx_GraphFlowrate.Text = Nothing
        txtbx_GraphInletPressure.Text = Nothing
        txtbx_GraphOutletPressure.Text = Nothing
        txtbx_GraphDiffPressure.Text = Nothing
        txtbx_GraphTest.Text = Nothing
        txtbx_Graphflush1.Text = Nothing
        txtbx_GraphDPTest1.Text = Nothing
        txtbx_Graphflush2.Text = Nothing
        txtbx_GraphDPTest2.Text = Nothing
        txtbx_GraphDrain1.Text = Nothing
        txtbx_GraphDrain2.Text = Nothing
        txtbx_GraphDrain3.Text = Nothing

        ResultChart.DataSource = Nothing
        ResultChart.Series.Clear()
        cmbx_GraphSearchLot.SelectedIndex = 0

    End Sub
#End Region


#Region "Text Formatting"
    Private Sub txtbx_GraphTest_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphTest.TextChanged
        If txtbx_GraphTest.Text = "PASS" Then
            txtbx_GraphTest.BackColor = PublicVariables.StatusGreen
            txtbx_GraphTest.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_GraphTest.BackColor = PublicVariables.StatusRed
            txtbx_GraphTest.ForeColor = PublicVariables.StatusRedT
        End If
    End Sub

    Private Sub txtbx_Graphflush1_TextChanged(sender As Object, e As EventArgs) Handles txtbx_Graphflush1.TextChanged
        If txtbx_Graphflush1.Text = "ENABLE" Then
            txtbx_Graphflush1.BackColor = PublicVariables.StatusGreen
            txtbx_Graphflush1.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_Graphflush1.BackColor = SystemColors.Window
            txtbx_Graphflush1.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_GraphDPTest1_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDPTest1.TextChanged
        If txtbx_GraphDPTest1.Text = "ENABLE" Then
            txtbx_GraphDPTest1.BackColor = PublicVariables.StatusGreen
            txtbx_GraphDPTest1.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_GraphDPTest1.BackColor = SystemColors.Window
            txtbx_GraphDPTest1.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_Graphflush2_TextChanged(sender As Object, e As EventArgs) Handles txtbx_Graphflush2.TextChanged
        If txtbx_Graphflush2.Text = "ENABLE" Then
            txtbx_Graphflush2.BackColor = PublicVariables.StatusGreen
            txtbx_Graphflush2.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_Graphflush2.BackColor = SystemColors.Window
            txtbx_Graphflush2.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_GraphDPTest2_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDPTest2.TextChanged
        If txtbx_GraphDPTest2.Text = "ENABLE" Then
            txtbx_GraphDPTest2.BackColor = PublicVariables.StatusGreen
            txtbx_GraphDPTest2.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_GraphDPTest2.BackColor = SystemColors.Window
            txtbx_GraphDPTest2.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_GraphDrain1_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDrain1.TextChanged
        If txtbx_GraphDrain1.Text = "ENABLE" Then
            txtbx_GraphDrain1.BackColor = PublicVariables.StatusGreen
            txtbx_GraphDrain1.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_GraphDrain1.BackColor = SystemColors.Window
            txtbx_GraphDrain1.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_GraphDrain2_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDrain2.TextChanged
        If txtbx_GraphDrain2.Text = "ENABLE" Then
            txtbx_GraphDrain2.BackColor = PublicVariables.StatusGreen
            txtbx_GraphDrain2.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_GraphDrain2.BackColor = SystemColors.Window
            txtbx_GraphDrain2.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtbx_GraphDrain3_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDrain3.TextChanged
        If txtbx_GraphDrain3.Text = "ENABLE" Then
            txtbx_GraphDrain3.BackColor = PublicVariables.StatusGreen
            txtbx_GraphDrain3.ForeColor = PublicVariables.StatusGreenT
        Else
            txtbx_GraphDrain3.BackColor = SystemColors.Window
            txtbx_GraphDrain3.ForeColor = SystemColors.ControlText
        End If
    End Sub



#End Region


#Region "Checkbox checked"
    Private Sub checkbx_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_GraphDP.CheckedChanged, checkbx_GraphInletPressure.CheckedChanged, checkbx_GraphOutletPressure.CheckedChanged, checkbx_GraphTemperature.CheckedChanged, checkbx_GraphFlowrate.CheckedChanged, checkbx_GraphBP.CheckedChanged, checkbx_GraphRPM.CheckedChanged
        CreateResultGraph()

        If ComboBox1.SelectedIndex > 0 Then
            Dim chkbxArr As CheckBox() = {checkbx_GraphInletPressure, checkbx_GraphOutletPressure, checkbx_GraphBP, checkbx_GraphFlowrate, checkbx_GraphTemperature, checkbx_GraphRPM}
            For Each chkbx In chkbxArr
                chkbx.Checked = False
            Next
        End If
    End Sub





#End Region

#Region "Result Load"
    Private Sub LoadResult(lotid As String, serialnum As String, attempt As String)
        Dim Oncontinue As Boolean = True
        Dim resultsummary(90) As String
        Dim dt_Graphsummary As DataTable
        'Dim dtproductiondetail As DataTable = SQL.ReadRecords($"SELECT * FROM ProductionDetail 
        '            LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id
        '            LEFT JOIN RecipeTable ON Lotusage.recipe_id=RecipeTable.recipe_id
        '            LEFT JOIN WorkOrder ON Lotusage.lot_id=WorkOrder.lot_id WHERE serial_uid = '{lotid}-{serialnum}' AND serial_attempt ='{attempt}'")

        Dim dtproductiondetail As DataTable = SQL.ReadRecords($"SELECT * FROM ProductionDetail 
                    LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id
                    LEFT JOIN WorkOrder ON Lotusage.lot_id=WorkOrder.lot_id WHERE serial_uid = '{lotid}-{serialnum}' AND serial_attempt ='{attempt}'")

        If Oncontinue = True Then
            If dtproductiondetail.Rows.Count > 0 Then
                checkbx_GraphDP.Checked = True
                checkbx_GraphInletPressure.Checked = True
                checkbx_GraphOutletPressure.Checked = True
                checkbx_GraphBP.Checked = True

                For i As Integer = 0 To dtproductiondetail.Columns.Count - 1
                    If Not dtproductiondetail.Rows(0).IsNull(i) Then
                        resultsummary(i) = dtproductiondetail.Rows(0).Item(i)
                    Else
                        resultsummary(i) = String.Empty
                    End If

                Next

                dt_Graphsummary = SQL.ReadRecords($"SELECT * FROM ProductResult WHERE serial_usage_id = '{resultsummary(0)}'ORDER BY ProductResult.sampling_time ASC")
                'dgv_Graphsummary.DataSource = dt_Graphsummary



                If dt_Graphsummary.Rows.Count > 0 Then
                    CreateResultGraph()
                    CreateResultGraphNew(dt_Graphsummary, resultsummary)



                    ResultChart.ChartAreas(0).Axes(0).MajorGrid.Enabled = False  'To Disable the Grid line in the X Axis
                    ResultChart.ChartAreas(0).Axes(1).MajorGrid.Enabled = False  'To Disable the Grid line in the Y Axis
                    ResultChart.DataSource = Nothing
                    ResultChart.DataSource = dt_Graphsummary
                Else
                    checkbx_GraphDP.Checked = False
                    checkbx_GraphInletPressure.Checked = False
                    checkbx_GraphOutletPressure.Checked = False
                    checkbx_GraphBP.Checked = False
                    ResultMessage(6)
                    Oncontinue = False
                End If
            Else
                ResultMessage(6)
                Oncontinue = False
            End If
        End If




        If Oncontinue = True Then
            txtbx_GraphTimestamp.Text = resultsummary(5)
            txtbx_GraphTemperature.Text = resultsummary(6)
            txtbx_GraphFlowrate.Text = resultsummary(7)
            txtbx_GraphInletPressure.Text = resultsummary(8)
            txtbx_GraphOutletPressure.Text = resultsummary(9)
            txtbx_GraphDiffPressure.Text = resultsummary(11)
            txtbx_GraphTest.Text = resultsummary(13).ToUpper

            txtbx_GraphCalOffset.Text = resultsummary(25)
            txtbx_GraphRecipeID.Text = resultsummary(21)

            txtbx_Graphflush1.Text = resultsummary(40 - 8).ToUpper
            txtbx_GraphDPTest1.Text = resultsummary(48 - 8).ToUpper
            txtbx_GraphDPTest2.Text = resultsummary(59 - 8).ToUpper
            txtbx_Graphflush2.Text = resultsummary(60 - 8).ToUpper
            txtbx_GraphDrain1.Text = resultsummary(68 - 8).ToUpper
            txtbx_GraphDrain2.Text = resultsummary(71 - 8).ToUpper
            txtbx_GraphDrain3.Text = resultsummary(74 - 8).ToUpper

            txtbx_GraphWorkOrder.Text = resultsummary(77 - 7)
            txtbx_GraphPartID.Text = resultsummary(78 - 7)
            txtbx_GraphConfirmation.Text = resultsummary(79 - 7)
            txtbx_GraphSerialUID.Text = resultsummary(1)
            txtbx_Graphattempt.Text = resultsummary(3)
        End If
    End Sub
#End Region





    Private Sub picbx_Icon_Click(sender As Object, e As EventArgs) Handles picbx_Icon.Click
        FormPixel.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim chkbxArr As CheckBox() = {checkbx_GraphInletPressure, checkbx_GraphOutletPressure, checkbx_GraphBP, checkbx_GraphFlowrate, checkbx_GraphTemperature, checkbx_GraphRPM}

        Select Case ComboBox1.SelectedIndex
            Case 0
                ' Seconds
                CartesianChart_ResultGraph.XAxes(0).Name = "Sampling Time (s)"
                CartesianChart_ResultGraph.Series(0).Values = ResultChartDPValue

                For i As Integer = 0 To CartesianChart_ResultGraph.Sections.Count - 1
                    CartesianChart_ResultGraph.Sections(i).IsVisible = ResultChartYAxesVisible(i)
                Next

                For i As Integer = 0 To CartesianChart_ResultGraph.YAxes.Count - 1
                    CartesianChart_ResultGraph.YAxes(i).IsVisible = True
                Next
            Case 1
                ' BP
                CartesianChart_ResultGraph.XAxes(0).Name = "Back Pressure (kPa)"
                CartesianChart_ResultGraph.Series(0).Values = ResultChartDPBP

                For Each chkbx In chkbxArr
                    chkbx.Checked = False
                Next
                checkbx_GraphDP.Checked = True

                For i As Integer = 0 To CartesianChart_ResultGraph.Sections.Count - 1
                    CartesianChart_ResultGraph.Sections(i).IsVisible = False
                Next

                For i As Integer = 0 To CartesianChart_ResultGraph.YAxes.Count - 1
                    If i = 0 Then
                        CartesianChart_ResultGraph.YAxes(i).IsVisible = True
                    Else
                        CartesianChart_ResultGraph.YAxes(i).IsVisible = False
                    End If
                Next
            Case 2
                ' Flowrate
                CartesianChart_ResultGraph.XAxes(0).Name = "Flowrate (l/min)"
                CartesianChart_ResultGraph.Series(0).Values = ResultChartDPFLWR

                For Each chkbx In chkbxArr
                    chkbx.Checked = False
                Next
                checkbx_GraphDP.Checked = True

                For i As Integer = 0 To CartesianChart_ResultGraph.Sections.Count - 1
                    CartesianChart_ResultGraph.Sections(i).IsVisible = False
                Next

                For i As Integer = 0 To CartesianChart_ResultGraph.YAxes.Count - 1
                    If i = 0 Then
                        CartesianChart_ResultGraph.YAxes(i).IsVisible = True
                    Else
                        CartesianChart_ResultGraph.YAxes(i).IsVisible = False
                    End If
                Next
        End Select
    End Sub

    Private Sub checkbx_ShowTooltip_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_ShowTooltip.CheckedChanged
        If CartesianChart_ResultGraph.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Hidden Then
            CartesianChart_ResultGraph.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top

            If CartesianChart_ResultGraph.XAxes.Count > 0 Then
                Dim XAxes As SkiaSharpView.Axis() = New SkiaSharpView.Axis() {
                    CartesianChart_ResultGraph.XAxes(0)
                }
                With XAxes(0)
                    .CrosshairLabelsBackground = New SKColor(25, 130, 246, 255).AsLvcColor()
                    .CrosshairLabelsPaint = New SolidColorPaint(New SKColor(255, 255, 255, 255), 1)
                    .CrosshairPaint = New SolidColorPaint(New SKColor(25, 130, 246, 255), 1)
                    .CrosshairSnapEnabled = True
                End With
            End If

            If CartesianChart_ResultGraph.YAxes.Count > 0 Then
                Dim YAxes As SkiaSharpView.Axis() = New SkiaSharpView.Axis() {
                    CartesianChart_ResultGraph.YAxes(0)
                }
                With YAxes(0)
                    .CrosshairPaint = New SolidColorPaint(New SKColor(25, 130, 246, 255), 1)
                End With
            End If
        Else
            CartesianChart_ResultGraph.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Hidden

            If CartesianChart_ResultGraph.XAxes.Count > 0 Then
                Dim XAxes As SkiaSharpView.Axis() = New SkiaSharpView.Axis() {
                    CartesianChart_ResultGraph.XAxes(0)
                }
                With XAxes(0)
                    .CrosshairLabelsBackground = New SKColor(25, 130, 246, 0).AsLvcColor()
                    .CrosshairLabelsPaint = New SolidColorPaint(New SKColor(255, 255, 255, 0), 1)
                    .CrosshairPaint = New SolidColorPaint(New SKColor(25, 130, 246, 0), 1)
                    .CrosshairSnapEnabled = True
                End With
            End If

            If CartesianChart_ResultGraph.YAxes.Count > 0 Then
                Dim YAxes As SkiaSharpView.Axis() = New SkiaSharpView.Axis() {
                    CartesianChart_ResultGraph.YAxes(0)
                }
                With YAxes(0)
                    .CrosshairPaint = New SolidColorPaint(New SKColor(25, 130, 246, 0), 1)
                End With
            End If
        End If
    End Sub
End Class