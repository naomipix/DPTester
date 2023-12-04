Imports System.Media
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FormResultGraph


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
        GetLotid()

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


    End Sub

    Private Sub FormResultGraph_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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
        Dim dvGetRecord As DataView = SQL.ReadRecords($"SELECT id,lot_id FROM LotUsage").DefaultView
        ' Sort Recipe Table
        dvGetRecord.Sort = "lot_id" & " ASC"


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
        Dim resultsummary(90) As String

        Dim dt_Graphsummary As DataTable
        Dim dtproductiondetail As DataTable = SQL.ReadRecords($"SELECT * FROM ProductionDetail 
                    LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id
                    LEFT JOIN RecipeTable ON Lotusage.recipe_id=RecipeTable.recipe_id
                    LEFT JOIN WorkOrder ON Lotusage.lot_id=WorkOrder.lot_id WHERE serial_uid = '{Lotid}-{serialnum}' AND serial_attempt ='{attempt}'")



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

            If dtproductiondetail.Rows.Count > 0 Then
                checkbx_GraphDP.Checked = True
                checkbx_GraphInletPressure.Checked = True
                checkbx_GraphOutletPressure.Checked = True

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



                    ResultChart.ChartAreas(0).Axes(0).MajorGrid.Enabled = False  'To Disable the Grid line in the X Axis
                    ResultChart.ChartAreas(0).Axes(1).MajorGrid.Enabled = False  'To Disable the Grid line in the Y Axis
                    ResultChart.DataSource = Nothing
                    ResultChart.DataSource = dt_Graphsummary
                Else
                    checkbx_GraphDP.Checked = False
                    checkbx_GraphInletPressure.Checked = False
                    checkbx_GraphOutletPressure.Checked = False
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

            txtbx_GraphCalOffset.Text = resultsummary(24)
            txtbx_GraphRecipeID.Text = resultsummary(31)
            txtbx_Graphflush1.Text = resultsummary(39).ToUpper
            txtbx_GraphDPTest1.Text = resultsummary(47).ToUpper
            txtbx_GraphDPTest2.Text = resultsummary(58).ToUpper
            txtbx_Graphflush2.Text = resultsummary(59).ToUpper
            txtbx_GraphDrain1.Text = resultsummary(67).ToUpper
            txtbx_GraphDrain2.Text = resultsummary(70).ToUpper
            txtbx_GraphDrain3.Text = resultsummary(73).ToUpper
            txtbx_GraphWorkOrder.Text = resultsummary(77)
            txtbx_GraphPartID.Text = resultsummary(78)
            txtbx_GraphConfirmation.Text = resultsummary(79)

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
            txtbx_GraphTest.BackColor = Color.FromArgb(192, 255, 192)

        Else
            txtbx_GraphTest.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub txtbx_Graphflush1_TextChanged(sender As Object, e As EventArgs) Handles txtbx_Graphflush1.TextChanged
        If txtbx_Graphflush1.Text = "ENABLE" Then
            txtbx_Graphflush1.BackColor = Color.FromArgb(192, 255, 192)
        Else
            txtbx_Graphflush1.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub txtbx_GraphDPTest1_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDPTest1.TextChanged
        If txtbx_GraphDPTest1.Text = "ENABLE" Then
            txtbx_GraphDPTest1.BackColor = Color.FromArgb(192, 255, 192)
        Else
            txtbx_GraphDPTest1.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub txtbx_Graphflush2_TextChanged(sender As Object, e As EventArgs) Handles txtbx_Graphflush2.TextChanged
        If txtbx_Graphflush2.Text = "ENABLE" Then
            txtbx_Graphflush2.BackColor = Color.FromArgb(192, 255, 192)
        Else
            txtbx_Graphflush2.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub txtbx_GraphDPTest2_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDPTest2.TextChanged
        If txtbx_GraphDPTest2.Text = "ENABLE" Then
            txtbx_GraphDPTest2.BackColor = Color.FromArgb(192, 255, 192)
        Else
            txtbx_GraphDPTest2.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub txtbx_GraphDrain1_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDrain1.TextChanged
        If txtbx_GraphDrain1.Text = "ENABLE" Then
            txtbx_GraphDrain1.BackColor = Color.FromArgb(192, 255, 192)
        Else
            txtbx_GraphDrain1.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub txtbx_GraphDrain2_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDrain2.TextChanged
        If txtbx_GraphDrain2.Text = "ENABLE" Then
            txtbx_GraphDrain2.BackColor = Color.FromArgb(192, 255, 192)
        Else
            txtbx_GraphDrain2.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub txtbx_GraphDrain3_TextChanged(sender As Object, e As EventArgs) Handles txtbx_GraphDrain3.TextChanged
        If txtbx_GraphDrain3.Text = "ENABLE" Then
            txtbx_GraphDrain3.BackColor = Color.FromArgb(192, 255, 192)
        Else
            txtbx_GraphDrain3.BackColor = SystemColors.Window
        End If
    End Sub



#End Region


#Region "Checkbox checked"
    Private Sub checkbx_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_GraphDP.CheckedChanged, checkbx_GraphInletPressure.CheckedChanged, checkbx_GraphOutletPressure.CheckedChanged, checkbx_GraphTemperature.CheckedChanged, checkbx_GraphFlowrate.CheckedChanged
        CreateResultGraph()
    End Sub





#End Region

    Private Sub picbx_Icon_Click(sender As Object, e As EventArgs) Handles picbx_Icon.Click
        FormPixel.Show()
    End Sub

End Class