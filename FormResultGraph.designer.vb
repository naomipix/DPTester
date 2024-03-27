﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormResultGraph
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormResultGraph))
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series11 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series12 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series13 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series14 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series15 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.lbl_Version = New System.Windows.Forms.Label()
        Me.picbx_Icon = New System.Windows.Forms.PictureBox()
        Me.lbl_DateTimeClock = New System.Windows.Forms.Label()
        Me.lbl_Title = New System.Windows.Forms.Label()
        Me.dsp_Category = New System.Windows.Forms.Label()
        Me.lbl_Category = New System.Windows.Forms.Label()
        Me.lbl_Username = New System.Windows.Forms.Label()
        Me.dsp_Username = New System.Windows.Forms.Label()
        Me.panel_UserCategory = New System.Windows.Forms.Panel()
        Me.lbl_OperationMode = New System.Windows.Forms.Label()
        Me.panel_FormControl = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dsp_Graphattempt = New System.Windows.Forms.Label()
        Me.txtbx_Graphattempt = New System.Windows.Forms.TextBox()
        Me.dsp_GraphSerialUID = New System.Windows.Forms.Label()
        Me.txtbx_GraphSerialUID = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbx_GraphSearchSerial = New System.Windows.Forms.ComboBox()
        Me.dsp_GraphSearchSerial = New System.Windows.Forms.Label()
        Me.cmbx_GraphSearchLot = New System.Windows.Forms.ComboBox()
        Me.cmbx_GraphSearchAttempt = New System.Windows.Forms.ComboBox()
        Me.dsp_GraphSearchAttempt = New System.Windows.Forms.Label()
        Me.dsp_GraphSearchLot = New System.Windows.Forms.Label()
        Me.btn_GraphClear = New System.Windows.Forms.Button()
        Me.btn_GraphSearch = New System.Windows.Forms.Button()
        Me.txtbx_GraphTest = New System.Windows.Forms.TextBox()
        Me.dsp_GraphTest = New System.Windows.Forms.Label()
        Me.txtbx_GraphDiffPressure = New System.Windows.Forms.TextBox()
        Me.dsp_GraphDiffPressure = New System.Windows.Forms.Label()
        Me.txtbx_GraphOutletPressure = New System.Windows.Forms.TextBox()
        Me.dsp_GraphOutletPressure = New System.Windows.Forms.Label()
        Me.txtbx_GraphInletPressure = New System.Windows.Forms.TextBox()
        Me.dsp_GraphInletPressure = New System.Windows.Forms.Label()
        Me.txtbx_GraphFlowrate = New System.Windows.Forms.TextBox()
        Me.txtbx_GraphTemperature = New System.Windows.Forms.TextBox()
        Me.txtbx_GraphCalOffset = New System.Windows.Forms.TextBox()
        Me.dsp_GraphFlowrate = New System.Windows.Forms.Label()
        Me.dsp_GraphTemperature = New System.Windows.Forms.Label()
        Me.dsp_GraphCalOffset = New System.Windows.Forms.Label()
        Me.dsp_GraphRecipeID = New System.Windows.Forms.Label()
        Me.dsp_GraphConfirmation = New System.Windows.Forms.Label()
        Me.dsp_GraphPartID = New System.Windows.Forms.Label()
        Me.dsp_GraphWorkOrder = New System.Windows.Forms.Label()
        Me.dsp_GraphTimestamp = New System.Windows.Forms.Label()
        Me.txtbx_GraphRecipeIDRev = New System.Windows.Forms.TextBox()
        Me.txtbx_GraphRecipeID = New System.Windows.Forms.TextBox()
        Me.txtbx_GraphConfirmation = New System.Windows.Forms.TextBox()
        Me.txtbx_GraphPartID = New System.Windows.Forms.TextBox()
        Me.txtbx_GraphWorkOrder = New System.Windows.Forms.TextBox()
        Me.txtbx_GraphTimestamp = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_ResetZoom = New System.Windows.Forms.Button()
        Me.checkbx_ShowTooltip = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphRPM = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphTemperature = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphFlowrate = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphBP = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphOutletPressure = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphInletPressure = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphDP = New System.Windows.Forms.CheckBox()
        Me.dsp_GraphDrain3 = New System.Windows.Forms.Label()
        Me.txtbx_GraphDrain3 = New System.Windows.Forms.TextBox()
        Me.dsp_GraphDrain2 = New System.Windows.Forms.Label()
        Me.txtbx_GraphDrain2 = New System.Windows.Forms.TextBox()
        Me.dsp_GraphDrain1 = New System.Windows.Forms.Label()
        Me.txtbx_GraphDrain1 = New System.Windows.Forms.TextBox()
        Me.dsp_GraphDPTest2 = New System.Windows.Forms.Label()
        Me.txtbx_GraphDPTest2 = New System.Windows.Forms.TextBox()
        Me.dsp_Graphflush2 = New System.Windows.Forms.Label()
        Me.txtbx_Graphflush2 = New System.Windows.Forms.TextBox()
        Me.dsp_GraphDPTest1 = New System.Windows.Forms.Label()
        Me.txtbx_GraphDPTest1 = New System.Windows.Forms.TextBox()
        Me.dsp_Graphflush1 = New System.Windows.Forms.Label()
        Me.txtbx_Graphflush1 = New System.Windows.Forms.TextBox()
        Me.CartesianChart_ResultGraph = New LiveChartsCore.SkiaSharpView.WinForms.CartesianChart()
        Me.ResultChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dsp_Home = New System.Windows.Forms.Label()
        Me.btn_Home = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.picbx_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_UserCategory.SuspendLayout()
        Me.panel_FormControl.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.ResultChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Version
        '
        Me.lbl_Version.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Version.Location = New System.Drawing.Point(1782, 160)
        Me.lbl_Version.Name = "lbl_Version"
        Me.lbl_Version.Size = New System.Drawing.Size(120, 18)
        Me.lbl_Version.TabIndex = 38
        Me.lbl_Version.Text = "Ver. 0.0"
        Me.lbl_Version.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picbx_Icon
        '
        Me.picbx_Icon.Image = CType(resources.GetObject("picbx_Icon.Image"), System.Drawing.Image)
        Me.picbx_Icon.Location = New System.Drawing.Point(1792, 57)
        Me.picbx_Icon.Name = "picbx_Icon"
        Me.picbx_Icon.Size = New System.Drawing.Size(100, 100)
        Me.picbx_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picbx_Icon.TabIndex = 37
        Me.picbx_Icon.TabStop = False
        '
        'lbl_DateTimeClock
        '
        Me.lbl_DateTimeClock.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DateTimeClock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.lbl_DateTimeClock.Location = New System.Drawing.Point(10, 42)
        Me.lbl_DateTimeClock.Name = "lbl_DateTimeClock"
        Me.lbl_DateTimeClock.Size = New System.Drawing.Size(250, 50)
        Me.lbl_DateTimeClock.TabIndex = 36
        Me.lbl_DateTimeClock.Text = "2023-01-01 23:59:59"
        Me.lbl_DateTimeClock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Title
        '
        Me.lbl_Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_Title.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Title.Location = New System.Drawing.Point(0, 40)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(1904, 50)
        Me.lbl_Title.TabIndex = 0
        Me.lbl_Title.Text = "DP Tester"
        Me.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dsp_Category
        '
        Me.dsp_Category.AutoSize = True
        Me.dsp_Category.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Category.Location = New System.Drawing.Point(40, 25)
        Me.dsp_Category.Name = "dsp_Category"
        Me.dsp_Category.Size = New System.Drawing.Size(68, 17)
        Me.dsp_Category.TabIndex = 8
        Me.dsp_Category.Text = "Category :"
        '
        'lbl_Category
        '
        Me.lbl_Category.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Category.Location = New System.Drawing.Point(114, 25)
        Me.lbl_Category.Name = "lbl_Category"
        Me.lbl_Category.Size = New System.Drawing.Size(250, 17)
        Me.lbl_Category.TabIndex = 8
        Me.lbl_Category.Text = "-"
        '
        'lbl_Username
        '
        Me.lbl_Username.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Username.Location = New System.Drawing.Point(114, 3)
        Me.lbl_Username.Name = "lbl_Username"
        Me.lbl_Username.Size = New System.Drawing.Size(250, 17)
        Me.lbl_Username.TabIndex = 8
        Me.lbl_Username.Text = "-"
        '
        'dsp_Username
        '
        Me.dsp_Username.AutoSize = True
        Me.dsp_Username.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Username.Location = New System.Drawing.Point(34, 3)
        Me.dsp_Username.Name = "dsp_Username"
        Me.dsp_Username.Size = New System.Drawing.Size(74, 17)
        Me.dsp_Username.TabIndex = 8
        Me.dsp_Username.Text = "Username :"
        '
        'panel_UserCategory
        '
        Me.panel_UserCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_UserCategory.Controls.Add(Me.dsp_Category)
        Me.panel_UserCategory.Controls.Add(Me.lbl_Category)
        Me.panel_UserCategory.Controls.Add(Me.lbl_Username)
        Me.panel_UserCategory.Controls.Add(Me.dsp_Username)
        Me.panel_UserCategory.Location = New System.Drawing.Point(12, 93)
        Me.panel_UserCategory.Name = "panel_UserCategory"
        Me.panel_UserCategory.Size = New System.Drawing.Size(400, 50)
        Me.panel_UserCategory.TabIndex = 0
        '
        'lbl_OperationMode
        '
        Me.lbl_OperationMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_OperationMode.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_OperationMode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_OperationMode.ForeColor = System.Drawing.SystemColors.Window
        Me.lbl_OperationMode.Location = New System.Drawing.Point(0, 0)
        Me.lbl_OperationMode.Name = "lbl_OperationMode"
        Me.lbl_OperationMode.Size = New System.Drawing.Size(1904, 40)
        Me.lbl_OperationMode.TabIndex = 34
        Me.lbl_OperationMode.Text = "Auto Mode"
        Me.lbl_OperationMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel_FormControl
        '
        Me.panel_FormControl.Controls.Add(Me.PictureBox1)
        Me.panel_FormControl.Controls.Add(Me.Panel1)
        Me.panel_FormControl.Controls.Add(Me.dsp_Home)
        Me.panel_FormControl.Controls.Add(Me.btn_Home)
        Me.panel_FormControl.Controls.Add(Me.picbx_Icon)
        Me.panel_FormControl.Controls.Add(Me.panel_UserCategory)
        Me.panel_FormControl.Controls.Add(Me.Label1)
        Me.panel_FormControl.Controls.Add(Me.lbl_Version)
        Me.panel_FormControl.Controls.Add(Me.lbl_DateTimeClock)
        Me.panel_FormControl.Controls.Add(Me.lbl_Title)
        Me.panel_FormControl.Controls.Add(Me.lbl_OperationMode)
        Me.panel_FormControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_FormControl.Location = New System.Drawing.Point(0, 0)
        Me.panel_FormControl.Name = "panel_FormControl"
        Me.panel_FormControl.Size = New System.Drawing.Size(1904, 1001)
        Me.panel_FormControl.TabIndex = 0
        Me.panel_FormControl.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1631, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 106
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(12, 181)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1880, 808)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dsp_Graphattempt)
        Me.Panel2.Controls.Add(Me.txtbx_Graphattempt)
        Me.Panel2.Controls.Add(Me.dsp_GraphSerialUID)
        Me.Panel2.Controls.Add(Me.txtbx_GraphSerialUID)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.txtbx_GraphTest)
        Me.Panel2.Controls.Add(Me.dsp_GraphTest)
        Me.Panel2.Controls.Add(Me.txtbx_GraphDiffPressure)
        Me.Panel2.Controls.Add(Me.dsp_GraphDiffPressure)
        Me.Panel2.Controls.Add(Me.txtbx_GraphOutletPressure)
        Me.Panel2.Controls.Add(Me.dsp_GraphOutletPressure)
        Me.Panel2.Controls.Add(Me.txtbx_GraphInletPressure)
        Me.Panel2.Controls.Add(Me.dsp_GraphInletPressure)
        Me.Panel2.Controls.Add(Me.txtbx_GraphFlowrate)
        Me.Panel2.Controls.Add(Me.txtbx_GraphTemperature)
        Me.Panel2.Controls.Add(Me.txtbx_GraphCalOffset)
        Me.Panel2.Controls.Add(Me.dsp_GraphFlowrate)
        Me.Panel2.Controls.Add(Me.dsp_GraphTemperature)
        Me.Panel2.Controls.Add(Me.dsp_GraphCalOffset)
        Me.Panel2.Controls.Add(Me.dsp_GraphRecipeID)
        Me.Panel2.Controls.Add(Me.dsp_GraphConfirmation)
        Me.Panel2.Controls.Add(Me.dsp_GraphPartID)
        Me.Panel2.Controls.Add(Me.dsp_GraphWorkOrder)
        Me.Panel2.Controls.Add(Me.dsp_GraphTimestamp)
        Me.Panel2.Controls.Add(Me.txtbx_GraphRecipeIDRev)
        Me.Panel2.Controls.Add(Me.txtbx_GraphRecipeID)
        Me.Panel2.Controls.Add(Me.txtbx_GraphConfirmation)
        Me.Panel2.Controls.Add(Me.txtbx_GraphPartID)
        Me.Panel2.Controls.Add(Me.txtbx_GraphWorkOrder)
        Me.Panel2.Controls.Add(Me.txtbx_GraphTimestamp)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(564, 802)
        Me.Panel2.TabIndex = 1
        '
        'dsp_Graphattempt
        '
        Me.dsp_Graphattempt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Graphattempt.Location = New System.Drawing.Point(345, 234)
        Me.dsp_Graphattempt.Name = "dsp_Graphattempt"
        Me.dsp_Graphattempt.Size = New System.Drawing.Size(90, 35)
        Me.dsp_Graphattempt.TabIndex = 61
        Me.dsp_Graphattempt.Text = "Attempt No :"
        Me.dsp_Graphattempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_Graphattempt
        '
        Me.txtbx_Graphattempt.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_Graphattempt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_Graphattempt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_Graphattempt.Location = New System.Drawing.Point(441, 239)
        Me.txtbx_Graphattempt.Name = "txtbx_Graphattempt"
        Me.txtbx_Graphattempt.ReadOnly = True
        Me.txtbx_Graphattempt.Size = New System.Drawing.Size(80, 25)
        Me.txtbx_Graphattempt.TabIndex = 62
        Me.txtbx_Graphattempt.TabStop = False
        '
        'dsp_GraphSerialUID
        '
        Me.dsp_GraphSerialUID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphSerialUID.Location = New System.Drawing.Point(19, 234)
        Me.dsp_GraphSerialUID.Name = "dsp_GraphSerialUID"
        Me.dsp_GraphSerialUID.Size = New System.Drawing.Size(100, 35)
        Me.dsp_GraphSerialUID.TabIndex = 59
        Me.dsp_GraphSerialUID.Text = "Serial UID :"
        Me.dsp_GraphSerialUID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphSerialUID
        '
        Me.txtbx_GraphSerialUID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphSerialUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphSerialUID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphSerialUID.Location = New System.Drawing.Point(131, 239)
        Me.txtbx_GraphSerialUID.Name = "txtbx_GraphSerialUID"
        Me.txtbx_GraphSerialUID.ReadOnly = True
        Me.txtbx_GraphSerialUID.Size = New System.Drawing.Size(200, 25)
        Me.txtbx_GraphSerialUID.TabIndex = 60
        Me.txtbx_GraphSerialUID.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.cmbx_GraphSearchSerial)
        Me.Panel4.Controls.Add(Me.dsp_GraphSearchSerial)
        Me.Panel4.Controls.Add(Me.cmbx_GraphSearchLot)
        Me.Panel4.Controls.Add(Me.cmbx_GraphSearchAttempt)
        Me.Panel4.Controls.Add(Me.dsp_GraphSearchAttempt)
        Me.Panel4.Controls.Add(Me.dsp_GraphSearchLot)
        Me.Panel4.Controls.Add(Me.btn_GraphClear)
        Me.Panel4.Controls.Add(Me.btn_GraphSearch)
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(556, 215)
        Me.Panel4.TabIndex = 54
        '
        'cmbx_GraphSearchSerial
        '
        Me.cmbx_GraphSearchSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_GraphSearchSerial.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_GraphSearchSerial.FormattingEnabled = True
        Me.cmbx_GraphSearchSerial.Location = New System.Drawing.Point(224, 59)
        Me.cmbx_GraphSearchSerial.Name = "cmbx_GraphSearchSerial"
        Me.cmbx_GraphSearchSerial.Size = New System.Drawing.Size(260, 25)
        Me.cmbx_GraphSearchSerial.TabIndex = 52
        '
        'dsp_GraphSearchSerial
        '
        Me.dsp_GraphSearchSerial.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphSearchSerial.Location = New System.Drawing.Point(18, 54)
        Me.dsp_GraphSearchSerial.Name = "dsp_GraphSearchSerial"
        Me.dsp_GraphSearchSerial.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphSearchSerial.TabIndex = 57
        Me.dsp_GraphSearchSerial.Text = "Serial Number :"
        Me.dsp_GraphSearchSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbx_GraphSearchLot
        '
        Me.cmbx_GraphSearchLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbx_GraphSearchLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbx_GraphSearchLot.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_GraphSearchLot.FormattingEnabled = True
        Me.cmbx_GraphSearchLot.Location = New System.Drawing.Point(223, 17)
        Me.cmbx_GraphSearchLot.Name = "cmbx_GraphSearchLot"
        Me.cmbx_GraphSearchLot.Size = New System.Drawing.Size(260, 25)
        Me.cmbx_GraphSearchLot.TabIndex = 51
        '
        'cmbx_GraphSearchAttempt
        '
        Me.cmbx_GraphSearchAttempt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_GraphSearchAttempt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_GraphSearchAttempt.FormattingEnabled = True
        Me.cmbx_GraphSearchAttempt.Location = New System.Drawing.Point(224, 101)
        Me.cmbx_GraphSearchAttempt.Name = "cmbx_GraphSearchAttempt"
        Me.cmbx_GraphSearchAttempt.Size = New System.Drawing.Size(260, 25)
        Me.cmbx_GraphSearchAttempt.TabIndex = 53
        '
        'dsp_GraphSearchAttempt
        '
        Me.dsp_GraphSearchAttempt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphSearchAttempt.Location = New System.Drawing.Point(18, 96)
        Me.dsp_GraphSearchAttempt.Name = "dsp_GraphSearchAttempt"
        Me.dsp_GraphSearchAttempt.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphSearchAttempt.TabIndex = 54
        Me.dsp_GraphSearchAttempt.Text = "Attempt Number :"
        Me.dsp_GraphSearchAttempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_GraphSearchLot
        '
        Me.dsp_GraphSearchLot.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphSearchLot.Location = New System.Drawing.Point(18, 12)
        Me.dsp_GraphSearchLot.Name = "dsp_GraphSearchLot"
        Me.dsp_GraphSearchLot.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphSearchLot.TabIndex = 52
        Me.dsp_GraphSearchLot.Text = "Lot ID :"
        Me.dsp_GraphSearchLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_GraphClear
        '
        Me.btn_GraphClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_GraphClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_GraphClear.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GraphClear.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_GraphClear.Location = New System.Drawing.Point(320, 146)
        Me.btn_GraphClear.Name = "btn_GraphClear"
        Me.btn_GraphClear.Size = New System.Drawing.Size(150, 50)
        Me.btn_GraphClear.TabIndex = 55
        Me.btn_GraphClear.Text = "Clear"
        Me.btn_GraphClear.UseVisualStyleBackColor = False
        '
        'btn_GraphSearch
        '
        Me.btn_GraphSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_GraphSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_GraphSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GraphSearch.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_GraphSearch.Location = New System.Drawing.Point(85, 146)
        Me.btn_GraphSearch.Name = "btn_GraphSearch"
        Me.btn_GraphSearch.Size = New System.Drawing.Size(150, 50)
        Me.btn_GraphSearch.TabIndex = 54
        Me.btn_GraphSearch.Text = "Search"
        Me.btn_GraphSearch.UseVisualStyleBackColor = False
        '
        'txtbx_GraphTest
        '
        Me.txtbx_GraphTest.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphTest.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphTest.Location = New System.Drawing.Point(226, 755)
        Me.txtbx_GraphTest.Name = "txtbx_GraphTest"
        Me.txtbx_GraphTest.ReadOnly = True
        Me.txtbx_GraphTest.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphTest.TabIndex = 27
        Me.txtbx_GraphTest.TabStop = False
        '
        'dsp_GraphTest
        '
        Me.dsp_GraphTest.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphTest.Location = New System.Drawing.Point(20, 750)
        Me.dsp_GraphTest.Name = "dsp_GraphTest"
        Me.dsp_GraphTest.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphTest.TabIndex = 26
        Me.dsp_GraphTest.Text = "DP Test Result  :"
        Me.dsp_GraphTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphDiffPressure
        '
        Me.txtbx_GraphDiffPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphDiffPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphDiffPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphDiffPressure.Location = New System.Drawing.Point(226, 712)
        Me.txtbx_GraphDiffPressure.Name = "txtbx_GraphDiffPressure"
        Me.txtbx_GraphDiffPressure.ReadOnly = True
        Me.txtbx_GraphDiffPressure.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphDiffPressure.TabIndex = 25
        Me.txtbx_GraphDiffPressure.TabStop = False
        '
        'dsp_GraphDiffPressure
        '
        Me.dsp_GraphDiffPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphDiffPressure.Location = New System.Drawing.Point(20, 707)
        Me.dsp_GraphDiffPressure.Name = "dsp_GraphDiffPressure"
        Me.dsp_GraphDiffPressure.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphDiffPressure.TabIndex = 24
        Me.dsp_GraphDiffPressure.Text = "Calculated Differnetial Pressure (kPa)  :"
        Me.dsp_GraphDiffPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphOutletPressure
        '
        Me.txtbx_GraphOutletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphOutletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphOutletPressure.Location = New System.Drawing.Point(226, 669)
        Me.txtbx_GraphOutletPressure.Name = "txtbx_GraphOutletPressure"
        Me.txtbx_GraphOutletPressure.ReadOnly = True
        Me.txtbx_GraphOutletPressure.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphOutletPressure.TabIndex = 23
        Me.txtbx_GraphOutletPressure.TabStop = False
        '
        'dsp_GraphOutletPressure
        '
        Me.dsp_GraphOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphOutletPressure.Location = New System.Drawing.Point(20, 664)
        Me.dsp_GraphOutletPressure.Name = "dsp_GraphOutletPressure"
        Me.dsp_GraphOutletPressure.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphOutletPressure.TabIndex = 22
        Me.dsp_GraphOutletPressure.Text = "DP Test Outlet Pressure (kPa) :"
        Me.dsp_GraphOutletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphInletPressure
        '
        Me.txtbx_GraphInletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphInletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphInletPressure.Location = New System.Drawing.Point(226, 626)
        Me.txtbx_GraphInletPressure.Name = "txtbx_GraphInletPressure"
        Me.txtbx_GraphInletPressure.ReadOnly = True
        Me.txtbx_GraphInletPressure.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphInletPressure.TabIndex = 21
        Me.txtbx_GraphInletPressure.TabStop = False
        '
        'dsp_GraphInletPressure
        '
        Me.dsp_GraphInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphInletPressure.Location = New System.Drawing.Point(20, 621)
        Me.dsp_GraphInletPressure.Name = "dsp_GraphInletPressure"
        Me.dsp_GraphInletPressure.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphInletPressure.TabIndex = 20
        Me.dsp_GraphInletPressure.Text = "DP Test Inlet Pressure " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(kPa) :"
        Me.dsp_GraphInletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphFlowrate
        '
        Me.txtbx_GraphFlowrate.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphFlowrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphFlowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphFlowrate.Location = New System.Drawing.Point(226, 583)
        Me.txtbx_GraphFlowrate.Name = "txtbx_GraphFlowrate"
        Me.txtbx_GraphFlowrate.ReadOnly = True
        Me.txtbx_GraphFlowrate.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphFlowrate.TabIndex = 19
        Me.txtbx_GraphFlowrate.TabStop = False
        '
        'txtbx_GraphTemperature
        '
        Me.txtbx_GraphTemperature.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphTemperature.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphTemperature.Location = New System.Drawing.Point(226, 540)
        Me.txtbx_GraphTemperature.Name = "txtbx_GraphTemperature"
        Me.txtbx_GraphTemperature.ReadOnly = True
        Me.txtbx_GraphTemperature.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphTemperature.TabIndex = 18
        Me.txtbx_GraphTemperature.TabStop = False
        '
        'txtbx_GraphCalOffset
        '
        Me.txtbx_GraphCalOffset.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphCalOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphCalOffset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphCalOffset.Location = New System.Drawing.Point(226, 497)
        Me.txtbx_GraphCalOffset.Name = "txtbx_GraphCalOffset"
        Me.txtbx_GraphCalOffset.ReadOnly = True
        Me.txtbx_GraphCalOffset.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphCalOffset.TabIndex = 17
        Me.txtbx_GraphCalOffset.TabStop = False
        '
        'dsp_GraphFlowrate
        '
        Me.dsp_GraphFlowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphFlowrate.Location = New System.Drawing.Point(20, 578)
        Me.dsp_GraphFlowrate.Name = "dsp_GraphFlowrate"
        Me.dsp_GraphFlowrate.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphFlowrate.TabIndex = 8
        Me.dsp_GraphFlowrate.Text = "DP Test Flowrate (l/min) :"
        Me.dsp_GraphFlowrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_GraphTemperature
        '
        Me.dsp_GraphTemperature.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphTemperature.Location = New System.Drawing.Point(20, 535)
        Me.dsp_GraphTemperature.Name = "dsp_GraphTemperature"
        Me.dsp_GraphTemperature.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphTemperature.TabIndex = 8
        Me.dsp_GraphTemperature.Text = "DP Test Temperature (C) :"
        Me.dsp_GraphTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_GraphCalOffset
        '
        Me.dsp_GraphCalOffset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphCalOffset.Location = New System.Drawing.Point(20, 492)
        Me.dsp_GraphCalOffset.Name = "dsp_GraphCalOffset"
        Me.dsp_GraphCalOffset.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphCalOffset.TabIndex = 8
        Me.dsp_GraphCalOffset.Text = "Calibration/Blank Offset (kPa)  :"
        Me.dsp_GraphCalOffset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_GraphRecipeID
        '
        Me.dsp_GraphRecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphRecipeID.Location = New System.Drawing.Point(20, 449)
        Me.dsp_GraphRecipeID.Name = "dsp_GraphRecipeID"
        Me.dsp_GraphRecipeID.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphRecipeID.TabIndex = 8
        Me.dsp_GraphRecipeID.Text = "Recipe ID :"
        Me.dsp_GraphRecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_GraphConfirmation
        '
        Me.dsp_GraphConfirmation.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphConfirmation.Location = New System.Drawing.Point(20, 406)
        Me.dsp_GraphConfirmation.Name = "dsp_GraphConfirmation"
        Me.dsp_GraphConfirmation.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphConfirmation.TabIndex = 8
        Me.dsp_GraphConfirmation.Text = "Confirmation ID :"
        Me.dsp_GraphConfirmation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_GraphPartID
        '
        Me.dsp_GraphPartID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphPartID.Location = New System.Drawing.Point(20, 363)
        Me.dsp_GraphPartID.Name = "dsp_GraphPartID"
        Me.dsp_GraphPartID.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphPartID.TabIndex = 8
        Me.dsp_GraphPartID.Text = "Part ID :"
        Me.dsp_GraphPartID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_GraphWorkOrder
        '
        Me.dsp_GraphWorkOrder.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphWorkOrder.Location = New System.Drawing.Point(20, 320)
        Me.dsp_GraphWorkOrder.Name = "dsp_GraphWorkOrder"
        Me.dsp_GraphWorkOrder.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphWorkOrder.TabIndex = 8
        Me.dsp_GraphWorkOrder.Text = "Work Order No :"
        Me.dsp_GraphWorkOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_GraphTimestamp
        '
        Me.dsp_GraphTimestamp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphTimestamp.Location = New System.Drawing.Point(20, 277)
        Me.dsp_GraphTimestamp.Name = "dsp_GraphTimestamp"
        Me.dsp_GraphTimestamp.Size = New System.Drawing.Size(200, 35)
        Me.dsp_GraphTimestamp.TabIndex = 8
        Me.dsp_GraphTimestamp.Text = "Production TimeStamp :"
        Me.dsp_GraphTimestamp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphRecipeIDRev
        '
        Me.txtbx_GraphRecipeIDRev.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphRecipeIDRev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphRecipeIDRev.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphRecipeIDRev.Location = New System.Drawing.Point(412, 454)
        Me.txtbx_GraphRecipeIDRev.Name = "txtbx_GraphRecipeIDRev"
        Me.txtbx_GraphRecipeIDRev.ReadOnly = True
        Me.txtbx_GraphRecipeIDRev.Size = New System.Drawing.Size(74, 25)
        Me.txtbx_GraphRecipeIDRev.TabIndex = 16
        Me.txtbx_GraphRecipeIDRev.TabStop = False
        '
        'txtbx_GraphRecipeID
        '
        Me.txtbx_GraphRecipeID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphRecipeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphRecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphRecipeID.Location = New System.Drawing.Point(226, 454)
        Me.txtbx_GraphRecipeID.Name = "txtbx_GraphRecipeID"
        Me.txtbx_GraphRecipeID.ReadOnly = True
        Me.txtbx_GraphRecipeID.Size = New System.Drawing.Size(180, 25)
        Me.txtbx_GraphRecipeID.TabIndex = 16
        Me.txtbx_GraphRecipeID.TabStop = False
        '
        'txtbx_GraphConfirmation
        '
        Me.txtbx_GraphConfirmation.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphConfirmation.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphConfirmation.Location = New System.Drawing.Point(226, 411)
        Me.txtbx_GraphConfirmation.Name = "txtbx_GraphConfirmation"
        Me.txtbx_GraphConfirmation.ReadOnly = True
        Me.txtbx_GraphConfirmation.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphConfirmation.TabIndex = 15
        Me.txtbx_GraphConfirmation.TabStop = False
        '
        'txtbx_GraphPartID
        '
        Me.txtbx_GraphPartID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphPartID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphPartID.Location = New System.Drawing.Point(226, 368)
        Me.txtbx_GraphPartID.Name = "txtbx_GraphPartID"
        Me.txtbx_GraphPartID.ReadOnly = True
        Me.txtbx_GraphPartID.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphPartID.TabIndex = 14
        Me.txtbx_GraphPartID.TabStop = False
        '
        'txtbx_GraphWorkOrder
        '
        Me.txtbx_GraphWorkOrder.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphWorkOrder.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphWorkOrder.Location = New System.Drawing.Point(226, 325)
        Me.txtbx_GraphWorkOrder.Name = "txtbx_GraphWorkOrder"
        Me.txtbx_GraphWorkOrder.ReadOnly = True
        Me.txtbx_GraphWorkOrder.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphWorkOrder.TabIndex = 12
        Me.txtbx_GraphWorkOrder.TabStop = False
        '
        'txtbx_GraphTimestamp
        '
        Me.txtbx_GraphTimestamp.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphTimestamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphTimestamp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphTimestamp.Location = New System.Drawing.Point(226, 282)
        Me.txtbx_GraphTimestamp.Name = "txtbx_GraphTimestamp"
        Me.txtbx_GraphTimestamp.ReadOnly = True
        Me.txtbx_GraphTimestamp.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_GraphTimestamp.TabIndex = 11
        Me.txtbx_GraphTimestamp.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.CartesianChart_ResultGraph)
        Me.Panel3.Controls.Add(Me.ComboBox1)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.btn_ResetZoom)
        Me.Panel3.Controls.Add(Me.checkbx_ShowTooltip)
        Me.Panel3.Controls.Add(Me.checkbx_GraphRPM)
        Me.Panel3.Controls.Add(Me.checkbx_GraphTemperature)
        Me.Panel3.Controls.Add(Me.checkbx_GraphFlowrate)
        Me.Panel3.Controls.Add(Me.checkbx_GraphBP)
        Me.Panel3.Controls.Add(Me.checkbx_GraphOutletPressure)
        Me.Panel3.Controls.Add(Me.checkbx_GraphInletPressure)
        Me.Panel3.Controls.Add(Me.checkbx_GraphDP)
        Me.Panel3.Controls.Add(Me.dsp_GraphDrain3)
        Me.Panel3.Controls.Add(Me.txtbx_GraphDrain3)
        Me.Panel3.Controls.Add(Me.dsp_GraphDrain2)
        Me.Panel3.Controls.Add(Me.txtbx_GraphDrain2)
        Me.Panel3.Controls.Add(Me.dsp_GraphDrain1)
        Me.Panel3.Controls.Add(Me.txtbx_GraphDrain1)
        Me.Panel3.Controls.Add(Me.dsp_GraphDPTest2)
        Me.Panel3.Controls.Add(Me.txtbx_GraphDPTest2)
        Me.Panel3.Controls.Add(Me.dsp_Graphflush2)
        Me.Panel3.Controls.Add(Me.txtbx_Graphflush2)
        Me.Panel3.Controls.Add(Me.dsp_GraphDPTest1)
        Me.Panel3.Controls.Add(Me.txtbx_GraphDPTest1)
        Me.Panel3.Controls.Add(Me.dsp_Graphflush1)
        Me.Panel3.Controls.Add(Me.txtbx_Graphflush1)
        Me.Panel3.Controls.Add(Me.ResultChart)
        Me.Panel3.Location = New System.Drawing.Point(566, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1311, 802)
        Me.Panel3.TabIndex = 2
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"DP vs Seconds", "DP vs Back Pressure", "DP vs Flow Rate"})
        Me.ComboBox1.Location = New System.Drawing.Point(1042, 190)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(200, 25)
        Me.ComboBox1.TabIndex = 14
        Me.ComboBox1.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel5.Location = New System.Drawing.Point(50, 167)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1210, 68)
        Me.Panel5.TabIndex = 78
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(752, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 17)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Drain"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(652, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 17)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "DP"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(552, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Flush"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(452, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Prep"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(726, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 20)
        Me.Label8.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(626, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 20)
        Me.Label6.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(526, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 20)
        Me.Label4.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(426, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 20)
        Me.Label2.TabIndex = 0
        '
        'btn_ResetZoom
        '
        Me.btn_ResetZoom.BackColor = System.Drawing.SystemColors.Window
        Me.btn_ResetZoom.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btn_ResetZoom.Location = New System.Drawing.Point(1170, 732)
        Me.btn_ResetZoom.Name = "btn_ResetZoom"
        Me.btn_ResetZoom.Size = New System.Drawing.Size(80, 35)
        Me.btn_ResetZoom.TabIndex = 64
        Me.btn_ResetZoom.Text = "Reset"
        Me.btn_ResetZoom.UseVisualStyleBackColor = False
        '
        'checkbx_ShowTooltip
        '
        Me.checkbx_ShowTooltip.AutoSize = True
        Me.checkbx_ShowTooltip.BackColor = System.Drawing.Color.AliceBlue
        Me.checkbx_ShowTooltip.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.checkbx_ShowTooltip.Location = New System.Drawing.Point(1051, 740)
        Me.checkbx_ShowTooltip.Name = "checkbx_ShowTooltip"
        Me.checkbx_ShowTooltip.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.checkbx_ShowTooltip.Size = New System.Drawing.Size(108, 21)
        Me.checkbx_ShowTooltip.TabIndex = 63
        Me.checkbx_ShowTooltip.Text = "Show Tooltips"
        Me.checkbx_ShowTooltip.UseVisualStyleBackColor = False
        '
        'checkbx_GraphRPM
        '
        Me.checkbx_GraphRPM.AutoSize = True
        Me.checkbx_GraphRPM.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphRPM.ForeColor = System.Drawing.Color.Orange
        Me.checkbx_GraphRPM.Location = New System.Drawing.Point(1134, 132)
        Me.checkbx_GraphRPM.Name = "checkbx_GraphRPM"
        Me.checkbx_GraphRPM.Size = New System.Drawing.Size(95, 21)
        Me.checkbx_GraphRPM.TabIndex = 62
        Me.checkbx_GraphRPM.Text = "Pump RPM"
        Me.checkbx_GraphRPM.UseVisualStyleBackColor = True
        '
        'checkbx_GraphTemperature
        '
        Me.checkbx_GraphTemperature.AutoSize = True
        Me.checkbx_GraphTemperature.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphTemperature.ForeColor = System.Drawing.Color.Red
        Me.checkbx_GraphTemperature.Location = New System.Drawing.Point(978, 132)
        Me.checkbx_GraphTemperature.Name = "checkbx_GraphTemperature"
        Me.checkbx_GraphTemperature.Size = New System.Drawing.Size(104, 21)
        Me.checkbx_GraphTemperature.TabIndex = 61
        Me.checkbx_GraphTemperature.Text = "Temperature"
        Me.checkbx_GraphTemperature.UseVisualStyleBackColor = True
        '
        'checkbx_GraphFlowrate
        '
        Me.checkbx_GraphFlowrate.AutoSize = True
        Me.checkbx_GraphFlowrate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphFlowrate.ForeColor = System.Drawing.Color.Brown
        Me.checkbx_GraphFlowrate.Location = New System.Drawing.Point(830, 132)
        Me.checkbx_GraphFlowrate.Name = "checkbx_GraphFlowrate"
        Me.checkbx_GraphFlowrate.Size = New System.Drawing.Size(79, 21)
        Me.checkbx_GraphFlowrate.TabIndex = 60
        Me.checkbx_GraphFlowrate.Text = "Flowrate"
        Me.checkbx_GraphFlowrate.UseVisualStyleBackColor = True
        '
        'checkbx_GraphBP
        '
        Me.checkbx_GraphBP.AutoSize = True
        Me.checkbx_GraphBP.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphBP.ForeColor = System.Drawing.Color.DarkOrange
        Me.checkbx_GraphBP.Location = New System.Drawing.Point(652, 132)
        Me.checkbx_GraphBP.Name = "checkbx_GraphBP"
        Me.checkbx_GraphBP.Size = New System.Drawing.Size(111, 21)
        Me.checkbx_GraphBP.TabIndex = 59
        Me.checkbx_GraphBP.Text = "Back Pressure"
        Me.checkbx_GraphBP.UseVisualStyleBackColor = True
        '
        'checkbx_GraphOutletPressure
        '
        Me.checkbx_GraphOutletPressure.AutoSize = True
        Me.checkbx_GraphOutletPressure.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphOutletPressure.ForeColor = System.Drawing.Color.Magenta
        Me.checkbx_GraphOutletPressure.Location = New System.Drawing.Point(466, 132)
        Me.checkbx_GraphOutletPressure.Name = "checkbx_GraphOutletPressure"
        Me.checkbx_GraphOutletPressure.Size = New System.Drawing.Size(121, 21)
        Me.checkbx_GraphOutletPressure.TabIndex = 58
        Me.checkbx_GraphOutletPressure.Text = "Outlet Pressure"
        Me.checkbx_GraphOutletPressure.UseVisualStyleBackColor = True
        '
        'checkbx_GraphInletPressure
        '
        Me.checkbx_GraphInletPressure.AutoSize = True
        Me.checkbx_GraphInletPressure.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphInletPressure.ForeColor = System.Drawing.Color.Green
        Me.checkbx_GraphInletPressure.Location = New System.Drawing.Point(290, 132)
        Me.checkbx_GraphInletPressure.Name = "checkbx_GraphInletPressure"
        Me.checkbx_GraphInletPressure.Size = New System.Drawing.Size(110, 21)
        Me.checkbx_GraphInletPressure.TabIndex = 57
        Me.checkbx_GraphInletPressure.Text = "Inlet Pressure"
        Me.checkbx_GraphInletPressure.UseVisualStyleBackColor = True
        '
        'checkbx_GraphDP
        '
        Me.checkbx_GraphDP.AutoSize = True
        Me.checkbx_GraphDP.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphDP.ForeColor = System.Drawing.Color.Blue
        Me.checkbx_GraphDP.Location = New System.Drawing.Point(80, 132)
        Me.checkbx_GraphDP.Name = "checkbx_GraphDP"
        Me.checkbx_GraphDP.Size = New System.Drawing.Size(148, 21)
        Me.checkbx_GraphDP.TabIndex = 56
        Me.checkbx_GraphDP.Text = "Differential Pressure"
        Me.checkbx_GraphDP.UseVisualStyleBackColor = True
        '
        'dsp_GraphDrain3
        '
        Me.dsp_GraphDrain3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphDrain3.Location = New System.Drawing.Point(654, 73)
        Me.dsp_GraphDrain3.Name = "dsp_GraphDrain3"
        Me.dsp_GraphDrain3.Size = New System.Drawing.Size(150, 30)
        Me.dsp_GraphDrain3.TabIndex = 67
        Me.dsp_GraphDrain3.Text = "Drain-3 Circuit :"
        Me.dsp_GraphDrain3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphDrain3
        '
        Me.txtbx_GraphDrain3.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphDrain3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphDrain3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphDrain3.Location = New System.Drawing.Point(824, 76)
        Me.txtbx_GraphDrain3.Name = "txtbx_GraphDrain3"
        Me.txtbx_GraphDrain3.ReadOnly = True
        Me.txtbx_GraphDrain3.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_GraphDrain3.TabIndex = 68
        Me.txtbx_GraphDrain3.TabStop = False
        Me.txtbx_GraphDrain3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_GraphDrain2
        '
        Me.dsp_GraphDrain2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphDrain2.Location = New System.Drawing.Point(352, 73)
        Me.dsp_GraphDrain2.Name = "dsp_GraphDrain2"
        Me.dsp_GraphDrain2.Size = New System.Drawing.Size(150, 30)
        Me.dsp_GraphDrain2.TabIndex = 65
        Me.dsp_GraphDrain2.Text = "Drain-2 Circuit :"
        Me.dsp_GraphDrain2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphDrain2
        '
        Me.txtbx_GraphDrain2.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphDrain2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphDrain2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphDrain2.Location = New System.Drawing.Point(522, 76)
        Me.txtbx_GraphDrain2.Name = "txtbx_GraphDrain2"
        Me.txtbx_GraphDrain2.ReadOnly = True
        Me.txtbx_GraphDrain2.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_GraphDrain2.TabIndex = 66
        Me.txtbx_GraphDrain2.TabStop = False
        Me.txtbx_GraphDrain2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_GraphDrain1
        '
        Me.dsp_GraphDrain1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphDrain1.Location = New System.Drawing.Point(50, 73)
        Me.dsp_GraphDrain1.Name = "dsp_GraphDrain1"
        Me.dsp_GraphDrain1.Size = New System.Drawing.Size(150, 30)
        Me.dsp_GraphDrain1.TabIndex = 63
        Me.dsp_GraphDrain1.Text = "Drain-1 Circuit :"
        Me.dsp_GraphDrain1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphDrain1
        '
        Me.txtbx_GraphDrain1.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphDrain1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphDrain1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphDrain1.Location = New System.Drawing.Point(220, 76)
        Me.txtbx_GraphDrain1.Name = "txtbx_GraphDrain1"
        Me.txtbx_GraphDrain1.ReadOnly = True
        Me.txtbx_GraphDrain1.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_GraphDrain1.TabIndex = 64
        Me.txtbx_GraphDrain1.TabStop = False
        Me.txtbx_GraphDrain1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_GraphDPTest2
        '
        Me.dsp_GraphDPTest2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphDPTest2.Location = New System.Drawing.Point(956, 12)
        Me.dsp_GraphDPTest2.Name = "dsp_GraphDPTest2"
        Me.dsp_GraphDPTest2.Size = New System.Drawing.Size(150, 30)
        Me.dsp_GraphDPTest2.TabIndex = 61
        Me.dsp_GraphDPTest2.Text = "DP Test-2 Circuit :"
        Me.dsp_GraphDPTest2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphDPTest2
        '
        Me.txtbx_GraphDPTest2.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphDPTest2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphDPTest2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphDPTest2.Location = New System.Drawing.Point(1126, 15)
        Me.txtbx_GraphDPTest2.Name = "txtbx_GraphDPTest2"
        Me.txtbx_GraphDPTest2.ReadOnly = True
        Me.txtbx_GraphDPTest2.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_GraphDPTest2.TabIndex = 62
        Me.txtbx_GraphDPTest2.TabStop = False
        Me.txtbx_GraphDPTest2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_Graphflush2
        '
        Me.dsp_Graphflush2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Graphflush2.Location = New System.Drawing.Point(654, 12)
        Me.dsp_Graphflush2.Name = "dsp_Graphflush2"
        Me.dsp_Graphflush2.Size = New System.Drawing.Size(150, 30)
        Me.dsp_Graphflush2.TabIndex = 59
        Me.dsp_Graphflush2.Text = "Flush-2 Circuit :"
        Me.dsp_Graphflush2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_Graphflush2
        '
        Me.txtbx_Graphflush2.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_Graphflush2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_Graphflush2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_Graphflush2.Location = New System.Drawing.Point(824, 15)
        Me.txtbx_Graphflush2.Name = "txtbx_Graphflush2"
        Me.txtbx_Graphflush2.ReadOnly = True
        Me.txtbx_Graphflush2.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_Graphflush2.TabIndex = 60
        Me.txtbx_Graphflush2.TabStop = False
        Me.txtbx_Graphflush2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_GraphDPTest1
        '
        Me.dsp_GraphDPTest1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_GraphDPTest1.Location = New System.Drawing.Point(352, 12)
        Me.dsp_GraphDPTest1.Name = "dsp_GraphDPTest1"
        Me.dsp_GraphDPTest1.Size = New System.Drawing.Size(150, 30)
        Me.dsp_GraphDPTest1.TabIndex = 57
        Me.dsp_GraphDPTest1.Text = "DP Test-1 Circuit :"
        Me.dsp_GraphDPTest1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_GraphDPTest1
        '
        Me.txtbx_GraphDPTest1.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_GraphDPTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_GraphDPTest1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_GraphDPTest1.Location = New System.Drawing.Point(522, 15)
        Me.txtbx_GraphDPTest1.Name = "txtbx_GraphDPTest1"
        Me.txtbx_GraphDPTest1.ReadOnly = True
        Me.txtbx_GraphDPTest1.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_GraphDPTest1.TabIndex = 58
        Me.txtbx_GraphDPTest1.TabStop = False
        Me.txtbx_GraphDPTest1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_Graphflush1
        '
        Me.dsp_Graphflush1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Graphflush1.Location = New System.Drawing.Point(50, 12)
        Me.dsp_Graphflush1.Name = "dsp_Graphflush1"
        Me.dsp_Graphflush1.Size = New System.Drawing.Size(150, 30)
        Me.dsp_Graphflush1.TabIndex = 55
        Me.dsp_Graphflush1.Text = "Flush-1 Circuit :"
        Me.dsp_Graphflush1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_Graphflush1
        '
        Me.txtbx_Graphflush1.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_Graphflush1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_Graphflush1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_Graphflush1.Location = New System.Drawing.Point(220, 15)
        Me.txtbx_Graphflush1.Name = "txtbx_Graphflush1"
        Me.txtbx_Graphflush1.ReadOnly = True
        Me.txtbx_Graphflush1.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_Graphflush1.TabIndex = 56
        Me.txtbx_Graphflush1.TabStop = False
        Me.txtbx_Graphflush1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CartesianChart_ResultGraph
        '
        Me.CartesianChart_ResultGraph.BackColor = System.Drawing.Color.AliceBlue
        Me.CartesianChart_ResultGraph.Location = New System.Drawing.Point(50, 212)
        Me.CartesianChart_ResultGraph.Name = "CartesianChart_ResultGraph"
        Me.CartesianChart_ResultGraph.Size = New System.Drawing.Size(1210, 565)
        Me.CartesianChart_ResultGraph.TabIndex = 75
        Me.CartesianChart_ResultGraph.TabStop = False
        '
        'ResultChart
        '
        Me.ResultChart.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ResultChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter
        ChartArea3.AxisX.MajorGrid.Interval = 0R
        ChartArea3.AxisX.MajorGrid.IntervalOffset = 0R
        ChartArea3.AxisX.Title = "Sampling Time (s)"
        ChartArea3.AxisX.TitleFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea3.AxisY.TitleFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea3.Name = "ChartArea1"
        Me.ResultChart.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.ResultChart.Legends.Add(Legend3)
        Me.ResultChart.Location = New System.Drawing.Point(50, 177)
        Me.ResultChart.Name = "ResultChart"
        Series11.ChartArea = "ChartArea1"
        Series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series11.LabelToolTip = "X= #VALX, Y= #VALY"
        Series11.Legend = "Legend1"
        Series11.Name = "DP"
        Series11.ToolTip = "X= #VALX, Y= #VALY"
        Series12.ChartArea = "ChartArea1"
        Series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series12.Legend = "Legend1"
        Series12.Name = "Inlet Pressure"
        Series13.ChartArea = "ChartArea1"
        Series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series13.Legend = "Legend1"
        Series13.Name = "Outlet Pressure"
        Series14.ChartArea = "ChartArea1"
        Series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series14.Legend = "Legend1"
        Series14.Name = "Flowrate"
        Series15.ChartArea = "ChartArea1"
        Series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series15.Legend = "Legend1"
        Series15.Name = "Temperature"
        Me.ResultChart.Series.Add(Series11)
        Me.ResultChart.Series.Add(Series12)
        Me.ResultChart.Series.Add(Series13)
        Me.ResultChart.Series.Add(Series14)
        Me.ResultChart.Series.Add(Series15)
        Me.ResultChart.Size = New System.Drawing.Size(1210, 600)
        Me.ResultChart.TabIndex = 69
        Me.ResultChart.Text = "ResultChart"
        Title3.Name = "Result Graph"
        Me.ResultChart.Titles.Add(Title3)
        Me.ResultChart.Visible = False
        '
        'dsp_Home
        '
        Me.dsp_Home.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Home.Location = New System.Drawing.Point(1534, 49)
        Me.dsp_Home.Name = "dsp_Home"
        Me.dsp_Home.Size = New System.Drawing.Size(80, 25)
        Me.dsp_Home.TabIndex = 103
        Me.dsp_Home.Text = "Home"
        Me.dsp_Home.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Home
        '
        Me.btn_Home.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Home.BackgroundImage = CType(resources.GetObject("btn_Home.BackgroundImage"), System.Drawing.Image)
        Me.btn_Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Home.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Home.Location = New System.Drawing.Point(1534, 77)
        Me.btn_Home.Name = "btn_Home"
        Me.btn_Home.Size = New System.Drawing.Size(80, 80)
        Me.btn_Home.TabIndex = 0
        Me.btn_Home.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1904, 46)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Test Graph"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormResultGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1001)
        Me.Controls.Add(Me.panel_FormControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1920, 1040)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1918, 1030)
        Me.Name = "FormResultGraph"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Result Graph"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.picbx_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_UserCategory.ResumeLayout(False)
        Me.panel_UserCategory.PerformLayout()
        Me.panel_FormControl.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.ResultChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Version As Label
    Friend WithEvents picbx_Icon As PictureBox
    Friend WithEvents lbl_DateTimeClock As Label
    Friend WithEvents lbl_Title As Label
    Friend WithEvents dsp_Category As Label
    Friend WithEvents lbl_Category As Label
    Friend WithEvents lbl_Username As Label
    Friend WithEvents dsp_Username As Label
    Friend WithEvents panel_UserCategory As Panel
    Friend WithEvents lbl_OperationMode As Label
    Friend WithEvents panel_FormControl As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Home As Button
    Friend WithEvents dsp_Home As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtbx_GraphFlowrate As TextBox
    Friend WithEvents txtbx_GraphTemperature As TextBox
    Friend WithEvents txtbx_GraphCalOffset As TextBox
    Friend WithEvents dsp_GraphFlowrate As Label
    Friend WithEvents dsp_GraphTemperature As Label
    Friend WithEvents dsp_GraphCalOffset As Label
    Friend WithEvents dsp_GraphRecipeID As Label
    Friend WithEvents dsp_GraphConfirmation As Label
    Friend WithEvents dsp_GraphPartID As Label
    Friend WithEvents dsp_GraphWorkOrder As Label
    Friend WithEvents dsp_GraphTimestamp As Label
    Friend WithEvents txtbx_GraphRecipeID As TextBox
    Friend WithEvents txtbx_GraphConfirmation As TextBox
    Friend WithEvents txtbx_GraphPartID As TextBox
    Friend WithEvents txtbx_GraphWorkOrder As TextBox
    Friend WithEvents txtbx_GraphTimestamp As TextBox
    Friend WithEvents btn_GraphClear As Button
    Friend WithEvents btn_GraphSearch As Button
    Friend WithEvents txtbx_GraphTest As TextBox
    Friend WithEvents dsp_GraphTest As Label
    Friend WithEvents txtbx_GraphDiffPressure As TextBox
    Friend WithEvents dsp_GraphDiffPressure As Label
    Friend WithEvents txtbx_GraphOutletPressure As TextBox
    Friend WithEvents dsp_GraphOutletPressure As Label
    Friend WithEvents txtbx_GraphInletPressure As TextBox
    Friend WithEvents dsp_GraphInletPressure As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dsp_GraphSearchLot As Label
    Friend WithEvents dsp_Graphflush1 As Label
    Friend WithEvents txtbx_Graphflush1 As TextBox
    Friend WithEvents dsp_GraphDPTest2 As Label
    Friend WithEvents txtbx_GraphDPTest2 As TextBox
    Friend WithEvents dsp_Graphflush2 As Label
    Friend WithEvents txtbx_Graphflush2 As TextBox
    Friend WithEvents dsp_GraphDPTest1 As Label
    Friend WithEvents txtbx_GraphDPTest1 As TextBox
    Friend WithEvents dsp_GraphDrain3 As Label
    Friend WithEvents txtbx_GraphDrain3 As TextBox
    Friend WithEvents dsp_GraphDrain2 As Label
    Friend WithEvents txtbx_GraphDrain2 As TextBox
    Friend WithEvents dsp_GraphDrain1 As Label
    Friend WithEvents txtbx_GraphDrain1 As TextBox
    Friend WithEvents dsp_GraphSearchAttempt As Label
    Friend WithEvents cmbx_GraphSearchAttempt As ComboBox
    Friend WithEvents cmbx_GraphSearchLot As ComboBox
    Friend WithEvents cmbx_GraphSearchSerial As ComboBox
    Friend WithEvents dsp_GraphSearchSerial As Label
    Friend WithEvents ResultChart As DataVisualization.Charting.Chart
    Friend WithEvents checkbx_GraphTemperature As CheckBox
    Friend WithEvents checkbx_GraphFlowrate As CheckBox
    Friend WithEvents checkbx_GraphOutletPressure As CheckBox
    Friend WithEvents checkbx_GraphInletPressure As CheckBox
    Friend WithEvents checkbx_GraphDP As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dsp_Graphattempt As Label
    Friend WithEvents txtbx_Graphattempt As TextBox
    Friend WithEvents dsp_GraphSerialUID As Label
    Friend WithEvents txtbx_GraphSerialUID As TextBox
    Friend WithEvents CartesianChart_ResultGraph As LiveChartsCore.SkiaSharpView.WinForms.CartesianChart
    Friend WithEvents checkbx_GraphBP As CheckBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents checkbx_GraphRPM As CheckBox
    Friend WithEvents checkbx_ShowTooltip As CheckBox
    Friend WithEvents btn_ResetZoom As Button
    Friend WithEvents txtbx_GraphRecipeIDRev As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
End Class
