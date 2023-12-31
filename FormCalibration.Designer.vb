﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCalibration
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCalibration))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.dsp_RecipeID = New System.Windows.Forms.Label()
        Me.txtbx_RecipeID = New System.Windows.Forms.TextBox()
        Me.txtbx_CalVertol = New System.Windows.Forms.TextBox()
        Me.dsp_CalVertol = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtbx_CalLotID = New System.Windows.Forms.TextBox()
        Me.dsp_CalLotID = New System.Windows.Forms.Label()
        Me.txtbx_CalBackPressure = New System.Windows.Forms.TextBox()
        Me.dsp_CalBackPressure = New System.Windows.Forms.Label()
        Me.txtbx_ActCalCycletime = New System.Windows.Forms.TextBox()
        Me.dsp_ActCalCycletime = New System.Windows.Forms.Label()
        Me.btn_Discard = New System.Windows.Forms.Button()
        Me.btn_Verify = New System.Windows.Forms.Button()
        Me.btn_Calibrate = New System.Windows.Forms.Button()
        Me.txtbx_EstCalCycletime = New System.Windows.Forms.TextBox()
        Me.txtbx_CalDPPoints = New System.Windows.Forms.TextBox()
        Me.dsp_EstCalCycletime = New System.Windows.Forms.Label()
        Me.txtbx_CalDPTesttime = New System.Windows.Forms.TextBox()
        Me.dsp_CalDPPoints = New System.Windows.Forms.Label()
        Me.dsp_CalDPTesttime = New System.Windows.Forms.Label()
        Me.dsp_CalStabilizeTime = New System.Windows.Forms.Label()
        Me.dsp_ActVerCycletime = New System.Windows.Forms.Label()
        Me.dsp_EstVerCycletime = New System.Windows.Forms.Label()
        Me.dsp_OperatorID = New System.Windows.Forms.Label()
        Me.txtbx_CalDPTestFlowrate = New System.Windows.Forms.TextBox()
        Me.txtbx_ActVerCycletime = New System.Windows.Forms.TextBox()
        Me.txtbx_EstVerCycletime = New System.Windows.Forms.TextBox()
        Me.txtbx_JigType = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgv_VerificationResult = New System.Windows.Forms.DataGridView()
        Me.dgv_CalibrationResult = New System.Windows.Forms.DataGridView()
        Me.txtbx_CalResult = New System.Windows.Forms.TextBox()
        Me.txtbx_VerStatus = New System.Windows.Forms.TextBox()
        Me.txtbx_VerDP = New System.Windows.Forms.TextBox()
        Me.txtbx_CalOffset = New System.Windows.Forms.TextBox()
        Me.dsp_CalResult = New System.Windows.Forms.Label()
        Me.dsp_VerDP = New System.Windows.Forms.Label()
        Me.dsp_CalOffset = New System.Windows.Forms.Label()
        Me.dsp_VerOutletPressure = New System.Windows.Forms.Label()
        Me.txtbx_VerOutletPressure = New System.Windows.Forms.TextBox()
        Me.dsp_VerInletPressure = New System.Windows.Forms.Label()
        Me.txtbx_VerInletPressure = New System.Windows.Forms.TextBox()
        Me.dsp_CalOutletPressure = New System.Windows.Forms.Label()
        Me.txtbx_CalOutletPressure = New System.Windows.Forms.TextBox()
        Me.dsp_CalInletPressure = New System.Windows.Forms.Label()
        Me.txtbx_CalInletPressure = New System.Windows.Forms.TextBox()
        Me.dsp_VerStatus = New System.Windows.Forms.Label()
        Me.lbl_CalibrationMsg = New System.Windows.Forms.Label()
        Me.dsp_Home = New System.Windows.Forms.Label()
        Me.btn_Home = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmr_Calibration = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_Verification = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picbx_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_UserCategory.SuspendLayout()
        Me.panel_FormControl.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgv_VerificationResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_CalibrationResult, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PictureBox1.TabIndex = 105
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
        Me.Panel2.Controls.Add(Me.dsp_RecipeID)
        Me.Panel2.Controls.Add(Me.txtbx_RecipeID)
        Me.Panel2.Controls.Add(Me.txtbx_CalVertol)
        Me.Panel2.Controls.Add(Me.dsp_CalVertol)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.txtbx_CalBackPressure)
        Me.Panel2.Controls.Add(Me.dsp_CalBackPressure)
        Me.Panel2.Controls.Add(Me.txtbx_ActCalCycletime)
        Me.Panel2.Controls.Add(Me.dsp_ActCalCycletime)
        Me.Panel2.Controls.Add(Me.btn_Discard)
        Me.Panel2.Controls.Add(Me.btn_Verify)
        Me.Panel2.Controls.Add(Me.btn_Calibrate)
        Me.Panel2.Controls.Add(Me.txtbx_EstCalCycletime)
        Me.Panel2.Controls.Add(Me.txtbx_CalDPPoints)
        Me.Panel2.Controls.Add(Me.dsp_EstCalCycletime)
        Me.Panel2.Controls.Add(Me.txtbx_CalDPTesttime)
        Me.Panel2.Controls.Add(Me.dsp_CalDPPoints)
        Me.Panel2.Controls.Add(Me.dsp_CalDPTesttime)
        Me.Panel2.Controls.Add(Me.dsp_CalStabilizeTime)
        Me.Panel2.Controls.Add(Me.dsp_ActVerCycletime)
        Me.Panel2.Controls.Add(Me.dsp_EstVerCycletime)
        Me.Panel2.Controls.Add(Me.dsp_OperatorID)
        Me.Panel2.Controls.Add(Me.txtbx_CalDPTestFlowrate)
        Me.Panel2.Controls.Add(Me.txtbx_ActVerCycletime)
        Me.Panel2.Controls.Add(Me.txtbx_EstVerCycletime)
        Me.Panel2.Controls.Add(Me.txtbx_JigType)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(564, 802)
        Me.Panel2.TabIndex = 1
        '
        'dsp_RecipeID
        '
        Me.dsp_RecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RecipeID.Location = New System.Drawing.Point(20, 56)
        Me.dsp_RecipeID.Name = "dsp_RecipeID"
        Me.dsp_RecipeID.Size = New System.Drawing.Size(200, 35)
        Me.dsp_RecipeID.TabIndex = 56
        Me.dsp_RecipeID.Text = "Recipe ID :"
        Me.dsp_RecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RecipeID
        '
        Me.txtbx_RecipeID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_RecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_RecipeID.Location = New System.Drawing.Point(226, 61)
        Me.txtbx_RecipeID.Name = "txtbx_RecipeID"
        Me.txtbx_RecipeID.ReadOnly = True
        Me.txtbx_RecipeID.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_RecipeID.TabIndex = 57
        Me.txtbx_RecipeID.TabStop = False
        '
        'txtbx_CalVertol
        '
        Me.txtbx_CalVertol.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalVertol.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalVertol.Location = New System.Drawing.Point(226, 571)
        Me.txtbx_CalVertol.Name = "txtbx_CalVertol"
        Me.txtbx_CalVertol.ReadOnly = True
        Me.txtbx_CalVertol.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_CalVertol.TabIndex = 55
        Me.txtbx_CalVertol.TabStop = False
        '
        'dsp_CalVertol
        '
        Me.dsp_CalVertol.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalVertol.Location = New System.Drawing.Point(20, 566)
        Me.dsp_CalVertol.Name = "dsp_CalVertol"
        Me.dsp_CalVertol.Size = New System.Drawing.Size(200, 35)
        Me.dsp_CalVertol.TabIndex = 54
        Me.dsp_CalVertol.Text = "Verification Tolerance (kPa)(+/-) :"
        Me.dsp_CalVertol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Panel4.Controls.Add(Me.txtbx_CalLotID)
        Me.Panel4.Controls.Add(Me.dsp_CalLotID)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(562, 40)
        Me.Panel4.TabIndex = 53
        '
        'txtbx_CalLotID
        '
        Me.txtbx_CalLotID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalLotID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalLotID.Location = New System.Drawing.Point(226, 8)
        Me.txtbx_CalLotID.Name = "txtbx_CalLotID"
        Me.txtbx_CalLotID.ReadOnly = True
        Me.txtbx_CalLotID.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_CalLotID.TabIndex = 54
        Me.txtbx_CalLotID.TabStop = False
        '
        'dsp_CalLotID
        '
        Me.dsp_CalLotID.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dsp_CalLotID.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalLotID.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.dsp_CalLotID.Location = New System.Drawing.Point(20, 3)
        Me.dsp_CalLotID.Name = "dsp_CalLotID"
        Me.dsp_CalLotID.Size = New System.Drawing.Size(200, 35)
        Me.dsp_CalLotID.TabIndex = 35
        Me.dsp_CalLotID.Text = "Lot ID :"
        Me.dsp_CalLotID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalBackPressure
        '
        Me.txtbx_CalBackPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalBackPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalBackPressure.Location = New System.Drawing.Point(226, 367)
        Me.txtbx_CalBackPressure.Name = "txtbx_CalBackPressure"
        Me.txtbx_CalBackPressure.ReadOnly = True
        Me.txtbx_CalBackPressure.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_CalBackPressure.TabIndex = 14
        Me.txtbx_CalBackPressure.TabStop = False
        '
        'dsp_CalBackPressure
        '
        Me.dsp_CalBackPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalBackPressure.Location = New System.Drawing.Point(20, 362)
        Me.dsp_CalBackPressure.Name = "dsp_CalBackPressure"
        Me.dsp_CalBackPressure.Size = New System.Drawing.Size(200, 35)
        Me.dsp_CalBackPressure.TabIndex = 8
        Me.dsp_CalBackPressure.Text = "Back Pressure (kPa) :"
        Me.dsp_CalBackPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ActCalCycletime
        '
        Me.txtbx_ActCalCycletime.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ActCalCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ActCalCycletime.Location = New System.Drawing.Point(226, 214)
        Me.txtbx_ActCalCycletime.Name = "txtbx_ActCalCycletime"
        Me.txtbx_ActCalCycletime.ReadOnly = True
        Me.txtbx_ActCalCycletime.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ActCalCycletime.TabIndex = 17
        Me.txtbx_ActCalCycletime.TabStop = False
        '
        'dsp_ActCalCycletime
        '
        Me.dsp_ActCalCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ActCalCycletime.Location = New System.Drawing.Point(20, 209)
        Me.dsp_ActCalCycletime.Name = "dsp_ActCalCycletime"
        Me.dsp_ActCalCycletime.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ActCalCycletime.TabIndex = 8
        Me.dsp_ActCalCycletime.Text = "Actual Calibration Cycle Time " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(s) :"
        Me.dsp_ActCalCycletime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Discard
        '
        Me.btn_Discard.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Discard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Discard.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Discard.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_Discard.Location = New System.Drawing.Point(207, 720)
        Me.btn_Discard.Name = "btn_Discard"
        Me.btn_Discard.Size = New System.Drawing.Size(150, 60)
        Me.btn_Discard.TabIndex = 52
        Me.btn_Discard.Text = "Discard"
        Me.btn_Discard.UseVisualStyleBackColor = False
        '
        'btn_Verify
        '
        Me.btn_Verify.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Verify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Verify.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Verify.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_Verify.Location = New System.Drawing.Point(305, 634)
        Me.btn_Verify.Name = "btn_Verify"
        Me.btn_Verify.Size = New System.Drawing.Size(150, 60)
        Me.btn_Verify.TabIndex = 51
        Me.btn_Verify.Text = "Verify"
        Me.btn_Verify.UseVisualStyleBackColor = False
        '
        'btn_Calibrate
        '
        Me.btn_Calibrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Calibrate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Calibrate.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Calibrate.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_Calibrate.Location = New System.Drawing.Point(109, 634)
        Me.btn_Calibrate.Name = "btn_Calibrate"
        Me.btn_Calibrate.Size = New System.Drawing.Size(150, 60)
        Me.btn_Calibrate.TabIndex = 50
        Me.btn_Calibrate.Text = "Calibrate"
        Me.btn_Calibrate.UseVisualStyleBackColor = False
        '
        'txtbx_EstCalCycletime
        '
        Me.txtbx_EstCalCycletime.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_EstCalCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_EstCalCycletime.Location = New System.Drawing.Point(226, 163)
        Me.txtbx_EstCalCycletime.Name = "txtbx_EstCalCycletime"
        Me.txtbx_EstCalCycletime.ReadOnly = True
        Me.txtbx_EstCalCycletime.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_EstCalCycletime.TabIndex = 15
        Me.txtbx_EstCalCycletime.TabStop = False
        '
        'txtbx_CalDPPoints
        '
        Me.txtbx_CalDPPoints.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalDPPoints.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalDPPoints.Location = New System.Drawing.Point(226, 520)
        Me.txtbx_CalDPPoints.Name = "txtbx_CalDPPoints"
        Me.txtbx_CalDPPoints.ReadOnly = True
        Me.txtbx_CalDPPoints.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_CalDPPoints.TabIndex = 19
        Me.txtbx_CalDPPoints.TabStop = False
        '
        'dsp_EstCalCycletime
        '
        Me.dsp_EstCalCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_EstCalCycletime.Location = New System.Drawing.Point(20, 158)
        Me.dsp_EstCalCycletime.Name = "dsp_EstCalCycletime"
        Me.dsp_EstCalCycletime.Size = New System.Drawing.Size(200, 35)
        Me.dsp_EstCalCycletime.TabIndex = 8
        Me.dsp_EstCalCycletime.Text = "Estimated Calibration Cycle Time (s) :"
        Me.dsp_EstCalCycletime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalDPTesttime
        '
        Me.txtbx_CalDPTesttime.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalDPTesttime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalDPTesttime.Location = New System.Drawing.Point(226, 469)
        Me.txtbx_CalDPTesttime.Name = "txtbx_CalDPTesttime"
        Me.txtbx_CalDPTesttime.ReadOnly = True
        Me.txtbx_CalDPTesttime.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_CalDPTesttime.TabIndex = 18
        Me.txtbx_CalDPTesttime.TabStop = False
        '
        'dsp_CalDPPoints
        '
        Me.dsp_CalDPPoints.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalDPPoints.Location = New System.Drawing.Point(20, 515)
        Me.dsp_CalDPPoints.Name = "dsp_CalDPPoints"
        Me.dsp_CalDPPoints.Size = New System.Drawing.Size(200, 35)
        Me.dsp_CalDPPoints.TabIndex = 8
        Me.dsp_CalDPPoints.Text = "DP Test Points :"
        Me.dsp_CalDPPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_CalDPTesttime
        '
        Me.dsp_CalDPTesttime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalDPTesttime.Location = New System.Drawing.Point(20, 464)
        Me.dsp_CalDPTesttime.Name = "dsp_CalDPTesttime"
        Me.dsp_CalDPTesttime.Size = New System.Drawing.Size(200, 35)
        Me.dsp_CalDPTesttime.TabIndex = 8
        Me.dsp_CalDPTesttime.Text = "DP Test Time (s) :"
        Me.dsp_CalDPTesttime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_CalStabilizeTime
        '
        Me.dsp_CalStabilizeTime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalStabilizeTime.Location = New System.Drawing.Point(20, 413)
        Me.dsp_CalStabilizeTime.Name = "dsp_CalStabilizeTime"
        Me.dsp_CalStabilizeTime.Size = New System.Drawing.Size(200, 35)
        Me.dsp_CalStabilizeTime.TabIndex = 8
        Me.dsp_CalStabilizeTime.Text = "DP Test Flowrate (l/min)  :"
        Me.dsp_CalStabilizeTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ActVerCycletime
        '
        Me.dsp_ActVerCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ActVerCycletime.Location = New System.Drawing.Point(20, 311)
        Me.dsp_ActVerCycletime.Name = "dsp_ActVerCycletime"
        Me.dsp_ActVerCycletime.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ActVerCycletime.TabIndex = 8
        Me.dsp_ActVerCycletime.Text = "Actual Verification Cycle Time " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(s) :"
        Me.dsp_ActVerCycletime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_EstVerCycletime
        '
        Me.dsp_EstVerCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_EstVerCycletime.Location = New System.Drawing.Point(20, 260)
        Me.dsp_EstVerCycletime.Name = "dsp_EstVerCycletime"
        Me.dsp_EstVerCycletime.Size = New System.Drawing.Size(200, 35)
        Me.dsp_EstVerCycletime.TabIndex = 8
        Me.dsp_EstVerCycletime.Text = "Estimated Verification Cycle Time (s) :"
        Me.dsp_EstVerCycletime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_OperatorID
        '
        Me.dsp_OperatorID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_OperatorID.Location = New System.Drawing.Point(20, 107)
        Me.dsp_OperatorID.Name = "dsp_OperatorID"
        Me.dsp_OperatorID.Size = New System.Drawing.Size(200, 35)
        Me.dsp_OperatorID.TabIndex = 8
        Me.dsp_OperatorID.Text = "Jig Type :"
        Me.dsp_OperatorID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalDPTestFlowrate
        '
        Me.txtbx_CalDPTestFlowrate.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalDPTestFlowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalDPTestFlowrate.Location = New System.Drawing.Point(226, 418)
        Me.txtbx_CalDPTestFlowrate.Name = "txtbx_CalDPTestFlowrate"
        Me.txtbx_CalDPTestFlowrate.ReadOnly = True
        Me.txtbx_CalDPTestFlowrate.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_CalDPTestFlowrate.TabIndex = 16
        Me.txtbx_CalDPTestFlowrate.TabStop = False
        '
        'txtbx_ActVerCycletime
        '
        Me.txtbx_ActVerCycletime.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ActVerCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ActVerCycletime.Location = New System.Drawing.Point(226, 316)
        Me.txtbx_ActVerCycletime.Name = "txtbx_ActVerCycletime"
        Me.txtbx_ActVerCycletime.ReadOnly = True
        Me.txtbx_ActVerCycletime.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ActVerCycletime.TabIndex = 13
        Me.txtbx_ActVerCycletime.TabStop = False
        '
        'txtbx_EstVerCycletime
        '
        Me.txtbx_EstVerCycletime.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_EstVerCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_EstVerCycletime.Location = New System.Drawing.Point(226, 265)
        Me.txtbx_EstVerCycletime.Name = "txtbx_EstVerCycletime"
        Me.txtbx_EstVerCycletime.ReadOnly = True
        Me.txtbx_EstVerCycletime.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_EstVerCycletime.TabIndex = 12
        Me.txtbx_EstVerCycletime.TabStop = False
        '
        'txtbx_JigType
        '
        Me.txtbx_JigType.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_JigType.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_JigType.Location = New System.Drawing.Point(226, 112)
        Me.txtbx_JigType.Name = "txtbx_JigType"
        Me.txtbx_JigType.ReadOnly = True
        Me.txtbx_JigType.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_JigType.TabIndex = 11
        Me.txtbx_JigType.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.dgv_VerificationResult)
        Me.Panel3.Controls.Add(Me.dgv_CalibrationResult)
        Me.Panel3.Controls.Add(Me.txtbx_CalResult)
        Me.Panel3.Controls.Add(Me.txtbx_VerStatus)
        Me.Panel3.Controls.Add(Me.txtbx_VerDP)
        Me.Panel3.Controls.Add(Me.txtbx_CalOffset)
        Me.Panel3.Controls.Add(Me.dsp_CalResult)
        Me.Panel3.Controls.Add(Me.dsp_VerDP)
        Me.Panel3.Controls.Add(Me.dsp_CalOffset)
        Me.Panel3.Controls.Add(Me.dsp_VerOutletPressure)
        Me.Panel3.Controls.Add(Me.txtbx_VerOutletPressure)
        Me.Panel3.Controls.Add(Me.dsp_VerInletPressure)
        Me.Panel3.Controls.Add(Me.txtbx_VerInletPressure)
        Me.Panel3.Controls.Add(Me.dsp_CalOutletPressure)
        Me.Panel3.Controls.Add(Me.txtbx_CalOutletPressure)
        Me.Panel3.Controls.Add(Me.dsp_CalInletPressure)
        Me.Panel3.Controls.Add(Me.txtbx_CalInletPressure)
        Me.Panel3.Controls.Add(Me.dsp_VerStatus)
        Me.Panel3.Controls.Add(Me.lbl_CalibrationMsg)
        Me.Panel3.Location = New System.Drawing.Point(566, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1311, 802)
        Me.Panel3.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(679, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(600, 30)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Verification"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(50, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(600, 30)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Calibration"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgv_VerificationResult
        '
        Me.dgv_VerificationResult.AllowUserToAddRows = False
        Me.dgv_VerificationResult.AllowUserToDeleteRows = False
        Me.dgv_VerificationResult.AllowUserToResizeColumns = False
        Me.dgv_VerificationResult.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_VerificationResult.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_VerificationResult.ColumnHeadersHeight = 60
        Me.dgv_VerificationResult.Location = New System.Drawing.Point(679, 215)
        Me.dgv_VerificationResult.Name = "dgv_VerificationResult"
        Me.dgv_VerificationResult.ReadOnly = True
        Me.dgv_VerificationResult.Size = New System.Drawing.Size(600, 560)
        Me.dgv_VerificationResult.TabIndex = 82
        '
        'dgv_CalibrationResult
        '
        Me.dgv_CalibrationResult.AllowUserToAddRows = False
        Me.dgv_CalibrationResult.AllowUserToDeleteRows = False
        Me.dgv_CalibrationResult.AllowUserToResizeColumns = False
        Me.dgv_CalibrationResult.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_CalibrationResult.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_CalibrationResult.ColumnHeadersHeight = 60
        Me.dgv_CalibrationResult.Location = New System.Drawing.Point(49, 215)
        Me.dgv_CalibrationResult.Name = "dgv_CalibrationResult"
        Me.dgv_CalibrationResult.ReadOnly = True
        Me.dgv_CalibrationResult.Size = New System.Drawing.Size(600, 560)
        Me.dgv_CalibrationResult.TabIndex = 81
        '
        'txtbx_CalResult
        '
        Me.txtbx_CalResult.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalResult.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalResult.Location = New System.Drawing.Point(1133, 124)
        Me.txtbx_CalResult.Name = "txtbx_CalResult"
        Me.txtbx_CalResult.ReadOnly = True
        Me.txtbx_CalResult.Size = New System.Drawing.Size(100, 29)
        Me.txtbx_CalResult.TabIndex = 80
        '
        'txtbx_VerStatus
        '
        Me.txtbx_VerStatus.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerStatus.Location = New System.Drawing.Point(529, 122)
        Me.txtbx_VerStatus.Name = "txtbx_VerStatus"
        Me.txtbx_VerStatus.ReadOnly = True
        Me.txtbx_VerStatus.Size = New System.Drawing.Size(100, 29)
        Me.txtbx_VerStatus.TabIndex = 79
        '
        'txtbx_VerDP
        '
        Me.txtbx_VerDP.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerDP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerDP.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerDP.Location = New System.Drawing.Point(831, 122)
        Me.txtbx_VerDP.Name = "txtbx_VerDP"
        Me.txtbx_VerDP.ReadOnly = True
        Me.txtbx_VerDP.Size = New System.Drawing.Size(100, 29)
        Me.txtbx_VerDP.TabIndex = 78
        '
        'txtbx_CalOffset
        '
        Me.txtbx_CalOffset.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalOffset.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalOffset.Location = New System.Drawing.Point(227, 122)
        Me.txtbx_CalOffset.Name = "txtbx_CalOffset"
        Me.txtbx_CalOffset.ReadOnly = True
        Me.txtbx_CalOffset.Size = New System.Drawing.Size(100, 29)
        Me.txtbx_CalOffset.TabIndex = 77
        '
        'dsp_CalResult
        '
        Me.dsp_CalResult.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalResult.Location = New System.Drawing.Point(963, 111)
        Me.dsp_CalResult.Name = "dsp_CalResult"
        Me.dsp_CalResult.Size = New System.Drawing.Size(150, 50)
        Me.dsp_CalResult.TabIndex = 76
        Me.dsp_CalResult.Text = "Calibration/Blank Result :"
        Me.dsp_CalResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_VerDP
        '
        Me.dsp_VerDP.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_VerDP.Location = New System.Drawing.Point(661, 111)
        Me.dsp_VerDP.Name = "dsp_VerDP"
        Me.dsp_VerDP.Size = New System.Drawing.Size(150, 50)
        Me.dsp_VerDP.TabIndex = 74
        Me.dsp_VerDP.Text = "Verification DP (kPa) :"
        Me.dsp_VerDP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_CalOffset
        '
        Me.dsp_CalOffset.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalOffset.Location = New System.Drawing.Point(57, 111)
        Me.dsp_CalOffset.Name = "dsp_CalOffset"
        Me.dsp_CalOffset.Size = New System.Drawing.Size(150, 50)
        Me.dsp_CalOffset.TabIndex = 72
        Me.dsp_CalOffset.Text = "Calibration/Blank Offset (kPa) :"
        Me.dsp_CalOffset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_VerOutletPressure
        '
        Me.dsp_VerOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_VerOutletPressure.Location = New System.Drawing.Point(963, 60)
        Me.dsp_VerOutletPressure.Name = "dsp_VerOutletPressure"
        Me.dsp_VerOutletPressure.Size = New System.Drawing.Size(150, 35)
        Me.dsp_VerOutletPressure.TabIndex = 69
        Me.dsp_VerOutletPressure.Text = "Verification Outlet Pressure (kPa) :"
        Me.dsp_VerOutletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_VerOutletPressure
        '
        Me.txtbx_VerOutletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerOutletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerOutletPressure.Location = New System.Drawing.Point(1133, 65)
        Me.txtbx_VerOutletPressure.Name = "txtbx_VerOutletPressure"
        Me.txtbx_VerOutletPressure.ReadOnly = True
        Me.txtbx_VerOutletPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_VerOutletPressure.TabIndex = 70
        Me.txtbx_VerOutletPressure.TabStop = False
        '
        'dsp_VerInletPressure
        '
        Me.dsp_VerInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_VerInletPressure.Location = New System.Drawing.Point(661, 60)
        Me.dsp_VerInletPressure.Name = "dsp_VerInletPressure"
        Me.dsp_VerInletPressure.Size = New System.Drawing.Size(150, 35)
        Me.dsp_VerInletPressure.TabIndex = 67
        Me.dsp_VerInletPressure.Text = "Verification Inlet Pressure (kPa) :"
        Me.dsp_VerInletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_VerInletPressure
        '
        Me.txtbx_VerInletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerInletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerInletPressure.Location = New System.Drawing.Point(831, 65)
        Me.txtbx_VerInletPressure.Name = "txtbx_VerInletPressure"
        Me.txtbx_VerInletPressure.ReadOnly = True
        Me.txtbx_VerInletPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_VerInletPressure.TabIndex = 68
        Me.txtbx_VerInletPressure.TabStop = False
        '
        'dsp_CalOutletPressure
        '
        Me.dsp_CalOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalOutletPressure.Location = New System.Drawing.Point(359, 60)
        Me.dsp_CalOutletPressure.Name = "dsp_CalOutletPressure"
        Me.dsp_CalOutletPressure.Size = New System.Drawing.Size(150, 35)
        Me.dsp_CalOutletPressure.TabIndex = 65
        Me.dsp_CalOutletPressure.Text = "Calibration Outlet Pressure (kPa) :"
        Me.dsp_CalOutletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalOutletPressure
        '
        Me.txtbx_CalOutletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalOutletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalOutletPressure.Location = New System.Drawing.Point(529, 65)
        Me.txtbx_CalOutletPressure.Name = "txtbx_CalOutletPressure"
        Me.txtbx_CalOutletPressure.ReadOnly = True
        Me.txtbx_CalOutletPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_CalOutletPressure.TabIndex = 66
        Me.txtbx_CalOutletPressure.TabStop = False
        '
        'dsp_CalInletPressure
        '
        Me.dsp_CalInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalInletPressure.Location = New System.Drawing.Point(57, 60)
        Me.dsp_CalInletPressure.Name = "dsp_CalInletPressure"
        Me.dsp_CalInletPressure.Size = New System.Drawing.Size(150, 35)
        Me.dsp_CalInletPressure.TabIndex = 63
        Me.dsp_CalInletPressure.Text = "Calibration Inlet Pressure (kPa) :"
        Me.dsp_CalInletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalInletPressure
        '
        Me.txtbx_CalInletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalInletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalInletPressure.Location = New System.Drawing.Point(227, 65)
        Me.txtbx_CalInletPressure.Name = "txtbx_CalInletPressure"
        Me.txtbx_CalInletPressure.ReadOnly = True
        Me.txtbx_CalInletPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_CalInletPressure.TabIndex = 64
        Me.txtbx_CalInletPressure.TabStop = False
        '
        'dsp_VerStatus
        '
        Me.dsp_VerStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_VerStatus.Location = New System.Drawing.Point(359, 111)
        Me.dsp_VerStatus.Name = "dsp_VerStatus"
        Me.dsp_VerStatus.Size = New System.Drawing.Size(150, 50)
        Me.dsp_VerStatus.TabIndex = 37
        Me.dsp_VerStatus.Text = "Verification" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Status :"
        Me.dsp_VerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CalibrationMsg
        '
        Me.lbl_CalibrationMsg.BackColor = System.Drawing.Color.Yellow
        Me.lbl_CalibrationMsg.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_CalibrationMsg.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CalibrationMsg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_CalibrationMsg.Location = New System.Drawing.Point(0, 0)
        Me.lbl_CalibrationMsg.Name = "lbl_CalibrationMsg"
        Me.lbl_CalibrationMsg.Size = New System.Drawing.Size(1309, 40)
        Me.lbl_CalibrationMsg.TabIndex = 35
        Me.lbl_CalibrationMsg.Text = "Press ""Calibrate"" to Start"
        Me.lbl_CalibrationMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dsp_Home
        '
        Me.dsp_Home.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Home.Location = New System.Drawing.Point(1531, 49)
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
        Me.Label1.Text = "Calibration && Verification"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tmr_Calibration
        '
        '
        'tmr_Verification
        '
        '
        'FormCalibration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1001)
        Me.ControlBox = False
        Me.Controls.Add(Me.panel_FormControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1920, 1040)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1918, 1030)
        Me.Name = "FormCalibration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recipe Management"
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
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgv_VerificationResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_CalibrationResult, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lbl_CalibrationMsg As Label
    Friend WithEvents dsp_CalLotID As Label
    Friend WithEvents txtbx_CalDPPoints As TextBox
    Friend WithEvents txtbx_CalDPTesttime As TextBox
    Friend WithEvents txtbx_ActCalCycletime As TextBox
    Friend WithEvents dsp_CalDPPoints As Label
    Friend WithEvents dsp_CalDPTesttime As Label
    Friend WithEvents dsp_ActCalCycletime As Label
    Friend WithEvents dsp_CalStabilizeTime As Label
    Friend WithEvents dsp_EstCalCycletime As Label
    Friend WithEvents dsp_CalBackPressure As Label
    Friend WithEvents dsp_ActVerCycletime As Label
    Friend WithEvents dsp_EstVerCycletime As Label
    Friend WithEvents dsp_OperatorID As Label
    Friend WithEvents txtbx_CalDPTestFlowrate As TextBox
    Friend WithEvents txtbx_EstCalCycletime As TextBox
    Friend WithEvents txtbx_CalBackPressure As TextBox
    Friend WithEvents txtbx_ActVerCycletime As TextBox
    Friend WithEvents txtbx_EstVerCycletime As TextBox
    Friend WithEvents txtbx_JigType As TextBox
    Friend WithEvents btn_Discard As Button
    Friend WithEvents btn_Verify As Button
    Friend WithEvents btn_Calibrate As Button
    Friend WithEvents dsp_VerStatus As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtbx_CalVertol As TextBox
    Friend WithEvents dsp_CalVertol As Label
    Friend WithEvents txtbx_CalLotID As TextBox
    Friend WithEvents dsp_RecipeID As Label
    Friend WithEvents txtbx_RecipeID As TextBox
    Friend WithEvents dsp_VerOutletPressure As Label
    Friend WithEvents txtbx_VerOutletPressure As TextBox
    Friend WithEvents dsp_VerInletPressure As Label
    Friend WithEvents txtbx_VerInletPressure As TextBox
    Friend WithEvents dsp_CalOutletPressure As Label
    Friend WithEvents txtbx_CalOutletPressure As TextBox
    Friend WithEvents dsp_CalInletPressure As Label
    Friend WithEvents txtbx_CalInletPressure As TextBox
    Friend WithEvents dsp_CalResult As Label
    Friend WithEvents dsp_VerDP As Label
    Friend WithEvents dsp_CalOffset As Label
    Friend WithEvents txtbx_CalOffset As TextBox
    Friend WithEvents txtbx_CalResult As TextBox
    Friend WithEvents txtbx_VerStatus As TextBox
    Friend WithEvents txtbx_VerDP As TextBox
    Friend WithEvents dgv_CalibrationResult As DataGridView
    Friend WithEvents tmr_Calibration As Timer
    Friend WithEvents tmr_Verification As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents dgv_VerificationResult As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
