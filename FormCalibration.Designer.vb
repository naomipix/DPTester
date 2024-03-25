<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btn_CircuitView = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dsp_RecipeID = New System.Windows.Forms.Label()
        Me.txtbx_RecipeID = New System.Windows.Forms.TextBox()
        Me.txtbx_CalDate = New System.Windows.Forms.TextBox()
        Me.txtbx_CalVertol = New System.Windows.Forms.TextBox()
        Me.dsp_CalDate = New System.Windows.Forms.Label()
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
        Me.txtbx_RecipeRev = New System.Windows.Forms.TextBox()
        Me.dsp_RecipeRev = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabpg_GraphView = New System.Windows.Forms.TabPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_ResetZoom = New System.Windows.Forms.Button()
        Me.checkbx_ShowTooltip = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphRPM = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphTemperature = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphFlowrate = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphBP = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphOutletPressure = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphInletPressure = New System.Windows.Forms.CheckBox()
        Me.checkbx_GraphDP = New System.Windows.Forms.CheckBox()
        Me.CartesianChart_CalibrationLiveGraph = New LiveChartsCore.SkiaSharpView.WinForms.CartesianChart()
        Me.tabpg_TableView = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgv_CalibrationResult = New System.Windows.Forms.DataGridView()
        Me.dgv_VerificationResult = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabpg_CircuitView = New System.Windows.Forms.TabPage()
        Me.Panel_Calibration_Circuit = New System.Windows.Forms.Panel()
        Me.dsp_Vertemperature = New System.Windows.Forms.Label()
        Me.txtbx_VerTemperature = New System.Windows.Forms.TextBox()
        Me.dsp_Verflowrate = New System.Windows.Forms.Label()
        Me.txtbx_VerFlowrate = New System.Windows.Forms.TextBox()
        Me.dsp_Caltemperature = New System.Windows.Forms.Label()
        Me.txtbx_CalTemperature = New System.Windows.Forms.TextBox()
        Me.dsp_Calflowrate = New System.Windows.Forms.Label()
        Me.txtbx_CalFlowrate = New System.Windows.Forms.TextBox()
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
        Me.dsp_VerBackpress = New System.Windows.Forms.Label()
        Me.txtbx_VerBackpress = New System.Windows.Forms.TextBox()
        Me.dsp_CalBackpress = New System.Windows.Forms.Label()
        Me.txtbx_CalBackpress = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dsp_Home = New System.Windows.Forms.Label()
        Me.btn_Home = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmr_Calibration = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_Verification = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_Calibration_EndSeq = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_Verification_EndSeq = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picbx_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_UserCategory.SuspendLayout()
        Me.panel_FormControl.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabpg_GraphView.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.tabpg_TableView.SuspendLayout()
        CType(Me.dgv_CalibrationResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_VerificationResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpg_CircuitView.SuspendLayout()
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
        Me.panel_FormControl.Controls.Add(Me.Panel5)
        Me.panel_FormControl.Controls.Add(Me.btn_CircuitView)
        Me.panel_FormControl.Controls.Add(Me.PictureBox1)
        Me.panel_FormControl.Controls.Add(Me.Panel1)
        Me.panel_FormControl.Controls.Add(Me.Label6)
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
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.TextBox2)
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel5.Location = New System.Drawing.Point(1378, 77)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(150, 80)
        Me.Panel5.TabIndex = 107
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Warning"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Alarm"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(74, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(60, 25)
        Me.TextBox2.TabIndex = 0
        Me.TextBox2.Text = "0"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(74, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(60, 25)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "0"
        '
        'btn_CircuitView
        '
        Me.btn_CircuitView.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_CircuitView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_CircuitView.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CircuitView.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_CircuitView.Location = New System.Drawing.Point(1430, 77)
        Me.btn_CircuitView.Name = "btn_CircuitView"
        Me.btn_CircuitView.Size = New System.Drawing.Size(80, 80)
        Me.btn_CircuitView.TabIndex = 106
        Me.btn_CircuitView.Text = "Circuit View"
        Me.btn_CircuitView.UseVisualStyleBackColor = False
        Me.btn_CircuitView.Visible = False
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
        Me.Panel1.Size = New System.Drawing.Size(1880, 830)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dsp_RecipeID)
        Me.Panel2.Controls.Add(Me.txtbx_RecipeID)
        Me.Panel2.Controls.Add(Me.txtbx_CalDate)
        Me.Panel2.Controls.Add(Me.txtbx_CalVertol)
        Me.Panel2.Controls.Add(Me.dsp_CalDate)
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
        Me.Panel2.Controls.Add(Me.txtbx_RecipeRev)
        Me.Panel2.Controls.Add(Me.dsp_RecipeRev)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(450, 815)
        Me.Panel2.TabIndex = 1
        '
        'dsp_RecipeID
        '
        Me.dsp_RecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RecipeID.Location = New System.Drawing.Point(10, 51)
        Me.dsp_RecipeID.Name = "dsp_RecipeID"
        Me.dsp_RecipeID.Size = New System.Drawing.Size(150, 35)
        Me.dsp_RecipeID.TabIndex = 56
        Me.dsp_RecipeID.Text = "Recipe ID :"
        Me.dsp_RecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RecipeID
        '
        Me.txtbx_RecipeID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_RecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_RecipeID.Location = New System.Drawing.Point(166, 56)
        Me.txtbx_RecipeID.Name = "txtbx_RecipeID"
        Me.txtbx_RecipeID.ReadOnly = True
        Me.txtbx_RecipeID.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_RecipeID.TabIndex = 57
        Me.txtbx_RecipeID.TabStop = False
        '
        'txtbx_CalDate
        '
        Me.txtbx_CalDate.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalDate.Location = New System.Drawing.Point(166, 608)
        Me.txtbx_CalDate.Name = "txtbx_CalDate"
        Me.txtbx_CalDate.ReadOnly = True
        Me.txtbx_CalDate.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_CalDate.TabIndex = 55
        Me.txtbx_CalDate.TabStop = False
        '
        'txtbx_CalVertol
        '
        Me.txtbx_CalVertol.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalVertol.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalVertol.Location = New System.Drawing.Point(166, 562)
        Me.txtbx_CalVertol.Name = "txtbx_CalVertol"
        Me.txtbx_CalVertol.ReadOnly = True
        Me.txtbx_CalVertol.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_CalVertol.TabIndex = 55
        Me.txtbx_CalVertol.TabStop = False
        '
        'dsp_CalDate
        '
        Me.dsp_CalDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalDate.Location = New System.Drawing.Point(-2, 602)
        Me.dsp_CalDate.Name = "dsp_CalDate"
        Me.dsp_CalDate.Size = New System.Drawing.Size(162, 35)
        Me.dsp_CalDate.TabIndex = 54
        Me.dsp_CalDate.Text = "Calibration Date :"
        Me.dsp_CalDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_CalVertol
        '
        Me.dsp_CalVertol.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalVertol.Location = New System.Drawing.Point(10, 557)
        Me.dsp_CalVertol.Name = "dsp_CalVertol"
        Me.dsp_CalVertol.Size = New System.Drawing.Size(150, 35)
        Me.dsp_CalVertol.TabIndex = 54
        Me.dsp_CalVertol.Text = "Verification Tolerance" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(kPa)(+/-) :"
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
        Me.Panel4.Size = New System.Drawing.Size(448, 40)
        Me.Panel4.TabIndex = 53
        '
        'txtbx_CalLotID
        '
        Me.txtbx_CalLotID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalLotID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalLotID.Location = New System.Drawing.Point(166, 8)
        Me.txtbx_CalLotID.Name = "txtbx_CalLotID"
        Me.txtbx_CalLotID.ReadOnly = True
        Me.txtbx_CalLotID.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_CalLotID.TabIndex = 54
        Me.txtbx_CalLotID.TabStop = False
        '
        'dsp_CalLotID
        '
        Me.dsp_CalLotID.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.dsp_CalLotID.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalLotID.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.dsp_CalLotID.Location = New System.Drawing.Point(10, 3)
        Me.dsp_CalLotID.Name = "dsp_CalLotID"
        Me.dsp_CalLotID.Size = New System.Drawing.Size(150, 35)
        Me.dsp_CalLotID.TabIndex = 35
        Me.dsp_CalLotID.Text = "Lot ID :"
        Me.dsp_CalLotID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalBackPressure
        '
        Me.txtbx_CalBackPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalBackPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalBackPressure.Location = New System.Drawing.Point(166, 378)
        Me.txtbx_CalBackPressure.Name = "txtbx_CalBackPressure"
        Me.txtbx_CalBackPressure.ReadOnly = True
        Me.txtbx_CalBackPressure.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_CalBackPressure.TabIndex = 14
        Me.txtbx_CalBackPressure.TabStop = False
        '
        'dsp_CalBackPressure
        '
        Me.dsp_CalBackPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalBackPressure.Location = New System.Drawing.Point(10, 373)
        Me.dsp_CalBackPressure.Name = "dsp_CalBackPressure"
        Me.dsp_CalBackPressure.Size = New System.Drawing.Size(150, 35)
        Me.dsp_CalBackPressure.TabIndex = 8
        Me.dsp_CalBackPressure.Text = "Back Pressure" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(kPa) :"
        Me.dsp_CalBackPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ActCalCycletime
        '
        Me.txtbx_ActCalCycletime.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ActCalCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ActCalCycletime.Location = New System.Drawing.Point(166, 240)
        Me.txtbx_ActCalCycletime.Name = "txtbx_ActCalCycletime"
        Me.txtbx_ActCalCycletime.ReadOnly = True
        Me.txtbx_ActCalCycletime.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_ActCalCycletime.TabIndex = 17
        Me.txtbx_ActCalCycletime.TabStop = False
        '
        'dsp_ActCalCycletime
        '
        Me.dsp_ActCalCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ActCalCycletime.Location = New System.Drawing.Point(10, 235)
        Me.dsp_ActCalCycletime.Name = "dsp_ActCalCycletime"
        Me.dsp_ActCalCycletime.Size = New System.Drawing.Size(150, 35)
        Me.dsp_ActCalCycletime.TabIndex = 8
        Me.dsp_ActCalCycletime.Text = "Actual Calibration" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cycle Time (s) :"
        Me.dsp_ActCalCycletime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Discard
        '
        Me.btn_Discard.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Discard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Discard.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Discard.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_Discard.Location = New System.Drawing.Point(148, 739)
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
        Me.btn_Verify.Location = New System.Drawing.Point(246, 663)
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
        Me.btn_Calibrate.Location = New System.Drawing.Point(50, 663)
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
        Me.txtbx_EstCalCycletime.Location = New System.Drawing.Point(166, 194)
        Me.txtbx_EstCalCycletime.Name = "txtbx_EstCalCycletime"
        Me.txtbx_EstCalCycletime.ReadOnly = True
        Me.txtbx_EstCalCycletime.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_EstCalCycletime.TabIndex = 15
        Me.txtbx_EstCalCycletime.TabStop = False
        '
        'txtbx_CalDPPoints
        '
        Me.txtbx_CalDPPoints.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalDPPoints.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalDPPoints.Location = New System.Drawing.Point(166, 516)
        Me.txtbx_CalDPPoints.Name = "txtbx_CalDPPoints"
        Me.txtbx_CalDPPoints.ReadOnly = True
        Me.txtbx_CalDPPoints.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_CalDPPoints.TabIndex = 19
        Me.txtbx_CalDPPoints.TabStop = False
        '
        'dsp_EstCalCycletime
        '
        Me.dsp_EstCalCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_EstCalCycletime.Location = New System.Drawing.Point(10, 189)
        Me.dsp_EstCalCycletime.Name = "dsp_EstCalCycletime"
        Me.dsp_EstCalCycletime.Size = New System.Drawing.Size(150, 35)
        Me.dsp_EstCalCycletime.TabIndex = 8
        Me.dsp_EstCalCycletime.Text = "Estimated Calibration" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cycle Time (s) :"
        Me.dsp_EstCalCycletime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalDPTesttime
        '
        Me.txtbx_CalDPTesttime.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalDPTesttime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalDPTesttime.Location = New System.Drawing.Point(166, 470)
        Me.txtbx_CalDPTesttime.Name = "txtbx_CalDPTesttime"
        Me.txtbx_CalDPTesttime.ReadOnly = True
        Me.txtbx_CalDPTesttime.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_CalDPTesttime.TabIndex = 18
        Me.txtbx_CalDPTesttime.TabStop = False
        '
        'dsp_CalDPPoints
        '
        Me.dsp_CalDPPoints.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalDPPoints.Location = New System.Drawing.Point(10, 511)
        Me.dsp_CalDPPoints.Name = "dsp_CalDPPoints"
        Me.dsp_CalDPPoints.Size = New System.Drawing.Size(150, 35)
        Me.dsp_CalDPPoints.TabIndex = 8
        Me.dsp_CalDPPoints.Text = "DP Test Points :"
        Me.dsp_CalDPPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_CalDPTesttime
        '
        Me.dsp_CalDPTesttime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalDPTesttime.Location = New System.Drawing.Point(10, 465)
        Me.dsp_CalDPTesttime.Name = "dsp_CalDPTesttime"
        Me.dsp_CalDPTesttime.Size = New System.Drawing.Size(150, 35)
        Me.dsp_CalDPTesttime.TabIndex = 8
        Me.dsp_CalDPTesttime.Text = "DP Test Time" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(s) :"
        Me.dsp_CalDPTesttime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_CalStabilizeTime
        '
        Me.dsp_CalStabilizeTime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalStabilizeTime.Location = New System.Drawing.Point(10, 419)
        Me.dsp_CalStabilizeTime.Name = "dsp_CalStabilizeTime"
        Me.dsp_CalStabilizeTime.Size = New System.Drawing.Size(150, 35)
        Me.dsp_CalStabilizeTime.TabIndex = 8
        Me.dsp_CalStabilizeTime.Text = "DP Test Flowrate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(l/min)  :"
        Me.dsp_CalStabilizeTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ActVerCycletime
        '
        Me.dsp_ActVerCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ActVerCycletime.Location = New System.Drawing.Point(10, 327)
        Me.dsp_ActVerCycletime.Name = "dsp_ActVerCycletime"
        Me.dsp_ActVerCycletime.Size = New System.Drawing.Size(150, 35)
        Me.dsp_ActVerCycletime.TabIndex = 8
        Me.dsp_ActVerCycletime.Text = "Actual Verification" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cycle Time (s) :"
        Me.dsp_ActVerCycletime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_EstVerCycletime
        '
        Me.dsp_EstVerCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_EstVerCycletime.Location = New System.Drawing.Point(10, 281)
        Me.dsp_EstVerCycletime.Name = "dsp_EstVerCycletime"
        Me.dsp_EstVerCycletime.Size = New System.Drawing.Size(150, 35)
        Me.dsp_EstVerCycletime.TabIndex = 8
        Me.dsp_EstVerCycletime.Text = "Estimated Verification" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cycle Time (s) :"
        Me.dsp_EstVerCycletime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_OperatorID
        '
        Me.dsp_OperatorID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_OperatorID.Location = New System.Drawing.Point(10, 143)
        Me.dsp_OperatorID.Name = "dsp_OperatorID"
        Me.dsp_OperatorID.Size = New System.Drawing.Size(150, 35)
        Me.dsp_OperatorID.TabIndex = 8
        Me.dsp_OperatorID.Text = "Jig Type :"
        Me.dsp_OperatorID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalDPTestFlowrate
        '
        Me.txtbx_CalDPTestFlowrate.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalDPTestFlowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalDPTestFlowrate.Location = New System.Drawing.Point(166, 424)
        Me.txtbx_CalDPTestFlowrate.Name = "txtbx_CalDPTestFlowrate"
        Me.txtbx_CalDPTestFlowrate.ReadOnly = True
        Me.txtbx_CalDPTestFlowrate.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_CalDPTestFlowrate.TabIndex = 16
        Me.txtbx_CalDPTestFlowrate.TabStop = False
        '
        'txtbx_ActVerCycletime
        '
        Me.txtbx_ActVerCycletime.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ActVerCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ActVerCycletime.Location = New System.Drawing.Point(166, 332)
        Me.txtbx_ActVerCycletime.Name = "txtbx_ActVerCycletime"
        Me.txtbx_ActVerCycletime.ReadOnly = True
        Me.txtbx_ActVerCycletime.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_ActVerCycletime.TabIndex = 13
        Me.txtbx_ActVerCycletime.TabStop = False
        '
        'txtbx_EstVerCycletime
        '
        Me.txtbx_EstVerCycletime.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_EstVerCycletime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_EstVerCycletime.Location = New System.Drawing.Point(166, 286)
        Me.txtbx_EstVerCycletime.Name = "txtbx_EstVerCycletime"
        Me.txtbx_EstVerCycletime.ReadOnly = True
        Me.txtbx_EstVerCycletime.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_EstVerCycletime.TabIndex = 12
        Me.txtbx_EstVerCycletime.TabStop = False
        '
        'txtbx_JigType
        '
        Me.txtbx_JigType.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_JigType.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_JigType.Location = New System.Drawing.Point(166, 148)
        Me.txtbx_JigType.Name = "txtbx_JigType"
        Me.txtbx_JigType.ReadOnly = True
        Me.txtbx_JigType.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_JigType.TabIndex = 11
        Me.txtbx_JigType.TabStop = False
        '
        'txtbx_RecipeRev
        '
        Me.txtbx_RecipeRev.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_RecipeRev.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_RecipeRev.Location = New System.Drawing.Point(166, 102)
        Me.txtbx_RecipeRev.Name = "txtbx_RecipeRev"
        Me.txtbx_RecipeRev.ReadOnly = True
        Me.txtbx_RecipeRev.Size = New System.Drawing.Size(250, 25)
        Me.txtbx_RecipeRev.TabIndex = 59
        Me.txtbx_RecipeRev.TabStop = False
        '
        'dsp_RecipeRev
        '
        Me.dsp_RecipeRev.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RecipeRev.Location = New System.Drawing.Point(-2, 96)
        Me.dsp_RecipeRev.Name = "dsp_RecipeRev"
        Me.dsp_RecipeRev.Size = New System.Drawing.Size(162, 35)
        Me.dsp_RecipeRev.TabIndex = 58
        Me.dsp_RecipeRev.Text = "Recipe Rev. No. :"
        Me.dsp_RecipeRev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Controls.Add(Me.dsp_Vertemperature)
        Me.Panel3.Controls.Add(Me.txtbx_VerTemperature)
        Me.Panel3.Controls.Add(Me.dsp_Verflowrate)
        Me.Panel3.Controls.Add(Me.txtbx_VerFlowrate)
        Me.Panel3.Controls.Add(Me.dsp_Caltemperature)
        Me.Panel3.Controls.Add(Me.txtbx_CalTemperature)
        Me.Panel3.Controls.Add(Me.dsp_Calflowrate)
        Me.Panel3.Controls.Add(Me.txtbx_CalFlowrate)
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
        Me.Panel3.Controls.Add(Me.dsp_VerBackpress)
        Me.Panel3.Controls.Add(Me.txtbx_VerBackpress)
        Me.Panel3.Controls.Add(Me.dsp_CalBackpress)
        Me.Panel3.Controls.Add(Me.txtbx_CalBackpress)
        Me.Panel3.Location = New System.Drawing.Point(452, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1425, 815)
        Me.Panel3.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabpg_GraphView)
        Me.TabControl1.Controls.Add(Me.tabpg_TableView)
        Me.TabControl1.Controls.Add(Me.tabpg_CircuitView)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(110, 30)
        Me.TabControl1.Location = New System.Drawing.Point(96, 191)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1244, 620)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 97
        '
        'tabpg_GraphView
        '
        Me.tabpg_GraphView.BackColor = System.Drawing.Color.AliceBlue
        Me.tabpg_GraphView.Controls.Add(Me.Panel6)
        Me.tabpg_GraphView.Controls.Add(Me.btn_ResetZoom)
        Me.tabpg_GraphView.Controls.Add(Me.checkbx_ShowTooltip)
        Me.tabpg_GraphView.Controls.Add(Me.checkbx_GraphRPM)
        Me.tabpg_GraphView.Controls.Add(Me.checkbx_GraphTemperature)
        Me.tabpg_GraphView.Controls.Add(Me.checkbx_GraphFlowrate)
        Me.tabpg_GraphView.Controls.Add(Me.checkbx_GraphBP)
        Me.tabpg_GraphView.Controls.Add(Me.checkbx_GraphOutletPressure)
        Me.tabpg_GraphView.Controls.Add(Me.checkbx_GraphInletPressure)
        Me.tabpg_GraphView.Controls.Add(Me.checkbx_GraphDP)
        Me.tabpg_GraphView.Controls.Add(Me.CartesianChart_CalibrationLiveGraph)
        Me.tabpg_GraphView.Location = New System.Drawing.Point(4, 34)
        Me.tabpg_GraphView.Name = "tabpg_GraphView"
        Me.tabpg_GraphView.Size = New System.Drawing.Size(1236, 582)
        Me.tabpg_GraphView.TabIndex = 2
        Me.tabpg_GraphView.Text = "Graph View"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel6.Location = New System.Drawing.Point(15, 49)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1206, 30)
        Me.Panel6.TabIndex = 99
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(751, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 17)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Drain"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(651, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 17)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "DP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(551, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 17)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Flush"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(451, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 17)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Prep"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(725, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 20)
        Me.Label11.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(625, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 20)
        Me.Label12.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(525, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 20)
        Me.Label13.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Location = New System.Drawing.Point(425, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 20)
        Me.Label14.TabIndex = 0
        '
        'btn_ResetZoom
        '
        Me.btn_ResetZoom.BackColor = System.Drawing.SystemColors.Window
        Me.btn_ResetZoom.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btn_ResetZoom.Location = New System.Drawing.Point(1146, 537)
        Me.btn_ResetZoom.Name = "btn_ResetZoom"
        Me.btn_ResetZoom.Size = New System.Drawing.Size(80, 35)
        Me.btn_ResetZoom.TabIndex = 109
        Me.btn_ResetZoom.Text = "Reset"
        Me.btn_ResetZoom.UseVisualStyleBackColor = False
        '
        'checkbx_ShowTooltip
        '
        Me.checkbx_ShowTooltip.AutoSize = True
        Me.checkbx_ShowTooltip.BackColor = System.Drawing.Color.AliceBlue
        Me.checkbx_ShowTooltip.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.checkbx_ShowTooltip.Location = New System.Drawing.Point(1027, 545)
        Me.checkbx_ShowTooltip.Name = "checkbx_ShowTooltip"
        Me.checkbx_ShowTooltip.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.checkbx_ShowTooltip.Size = New System.Drawing.Size(108, 21)
        Me.checkbx_ShowTooltip.TabIndex = 108
        Me.checkbx_ShowTooltip.Text = "Show Tooltips"
        Me.checkbx_ShowTooltip.UseVisualStyleBackColor = False
        '
        'checkbx_GraphRPM
        '
        Me.checkbx_GraphRPM.AutoSize = True
        Me.checkbx_GraphRPM.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphRPM.ForeColor = System.Drawing.Color.Orange
        Me.checkbx_GraphRPM.Location = New System.Drawing.Point(1102, 17)
        Me.checkbx_GraphRPM.Name = "checkbx_GraphRPM"
        Me.checkbx_GraphRPM.Size = New System.Drawing.Size(95, 21)
        Me.checkbx_GraphRPM.TabIndex = 107
        Me.checkbx_GraphRPM.Text = "Pump RPM"
        Me.checkbx_GraphRPM.UseVisualStyleBackColor = True
        '
        'checkbx_GraphTemperature
        '
        Me.checkbx_GraphTemperature.AutoSize = True
        Me.checkbx_GraphTemperature.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphTemperature.ForeColor = System.Drawing.Color.Red
        Me.checkbx_GraphTemperature.Location = New System.Drawing.Point(945, 17)
        Me.checkbx_GraphTemperature.Name = "checkbx_GraphTemperature"
        Me.checkbx_GraphTemperature.Size = New System.Drawing.Size(104, 21)
        Me.checkbx_GraphTemperature.TabIndex = 106
        Me.checkbx_GraphTemperature.Text = "Temperature"
        Me.checkbx_GraphTemperature.UseVisualStyleBackColor = True
        '
        'checkbx_GraphFlowrate
        '
        Me.checkbx_GraphFlowrate.AutoSize = True
        Me.checkbx_GraphFlowrate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphFlowrate.ForeColor = System.Drawing.Color.Brown
        Me.checkbx_GraphFlowrate.Location = New System.Drawing.Point(797, 17)
        Me.checkbx_GraphFlowrate.Name = "checkbx_GraphFlowrate"
        Me.checkbx_GraphFlowrate.Size = New System.Drawing.Size(79, 21)
        Me.checkbx_GraphFlowrate.TabIndex = 105
        Me.checkbx_GraphFlowrate.Text = "Flowrate"
        Me.checkbx_GraphFlowrate.UseVisualStyleBackColor = True
        '
        'checkbx_GraphBP
        '
        Me.checkbx_GraphBP.AutoSize = True
        Me.checkbx_GraphBP.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphBP.ForeColor = System.Drawing.Color.DarkOrange
        Me.checkbx_GraphBP.Location = New System.Drawing.Point(619, 17)
        Me.checkbx_GraphBP.Name = "checkbx_GraphBP"
        Me.checkbx_GraphBP.Size = New System.Drawing.Size(111, 21)
        Me.checkbx_GraphBP.TabIndex = 104
        Me.checkbx_GraphBP.Text = "Back Pressure"
        Me.checkbx_GraphBP.UseVisualStyleBackColor = True
        '
        'checkbx_GraphOutletPressure
        '
        Me.checkbx_GraphOutletPressure.AutoSize = True
        Me.checkbx_GraphOutletPressure.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphOutletPressure.ForeColor = System.Drawing.Color.Magenta
        Me.checkbx_GraphOutletPressure.Location = New System.Drawing.Point(433, 17)
        Me.checkbx_GraphOutletPressure.Name = "checkbx_GraphOutletPressure"
        Me.checkbx_GraphOutletPressure.Size = New System.Drawing.Size(121, 21)
        Me.checkbx_GraphOutletPressure.TabIndex = 103
        Me.checkbx_GraphOutletPressure.Text = "Outlet Pressure"
        Me.checkbx_GraphOutletPressure.UseVisualStyleBackColor = True
        '
        'checkbx_GraphInletPressure
        '
        Me.checkbx_GraphInletPressure.AutoSize = True
        Me.checkbx_GraphInletPressure.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphInletPressure.ForeColor = System.Drawing.Color.Green
        Me.checkbx_GraphInletPressure.Location = New System.Drawing.Point(257, 17)
        Me.checkbx_GraphInletPressure.Name = "checkbx_GraphInletPressure"
        Me.checkbx_GraphInletPressure.Size = New System.Drawing.Size(110, 21)
        Me.checkbx_GraphInletPressure.TabIndex = 102
        Me.checkbx_GraphInletPressure.Text = "Inlet Pressure"
        Me.checkbx_GraphInletPressure.UseVisualStyleBackColor = True
        '
        'checkbx_GraphDP
        '
        Me.checkbx_GraphDP.AutoSize = True
        Me.checkbx_GraphDP.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_GraphDP.ForeColor = System.Drawing.Color.Blue
        Me.checkbx_GraphDP.Location = New System.Drawing.Point(47, 17)
        Me.checkbx_GraphDP.Name = "checkbx_GraphDP"
        Me.checkbx_GraphDP.Size = New System.Drawing.Size(148, 21)
        Me.checkbx_GraphDP.TabIndex = 101
        Me.checkbx_GraphDP.Text = "Differential Pressure"
        Me.checkbx_GraphDP.UseVisualStyleBackColor = True
        '
        'CartesianChart_CalibrationLiveGraph
        '
        Me.CartesianChart_CalibrationLiveGraph.BackColor = System.Drawing.Color.AliceBlue
        Me.CartesianChart_CalibrationLiveGraph.Location = New System.Drawing.Point(15, 61)
        Me.CartesianChart_CalibrationLiveGraph.Margin = New System.Windows.Forms.Padding(5)
        Me.CartesianChart_CalibrationLiveGraph.Name = "CartesianChart_CalibrationLiveGraph"
        Me.CartesianChart_CalibrationLiveGraph.Size = New System.Drawing.Size(1206, 521)
        Me.CartesianChart_CalibrationLiveGraph.TabIndex = 12
        '
        'tabpg_TableView
        '
        Me.tabpg_TableView.Controls.Add(Me.Label2)
        Me.tabpg_TableView.Controls.Add(Me.dgv_CalibrationResult)
        Me.tabpg_TableView.Controls.Add(Me.dgv_VerificationResult)
        Me.tabpg_TableView.Controls.Add(Me.Label4)
        Me.tabpg_TableView.Location = New System.Drawing.Point(4, 34)
        Me.tabpg_TableView.Name = "tabpg_TableView"
        Me.tabpg_TableView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpg_TableView.Size = New System.Drawing.Size(1236, 582)
        Me.tabpg_TableView.TabIndex = 0
        Me.tabpg_TableView.Text = "Table View"
        Me.tabpg_TableView.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(600, 30)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Calibration"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgv_CalibrationResult
        '
        Me.dgv_CalibrationResult.AllowUserToAddRows = False
        Me.dgv_CalibrationResult.AllowUserToDeleteRows = False
        Me.dgv_CalibrationResult.AllowUserToResizeColumns = False
        Me.dgv_CalibrationResult.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_CalibrationResult.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_CalibrationResult.ColumnHeadersHeight = 60
        Me.dgv_CalibrationResult.Location = New System.Drawing.Point(3, 36)
        Me.dgv_CalibrationResult.Name = "dgv_CalibrationResult"
        Me.dgv_CalibrationResult.ReadOnly = True
        Me.dgv_CalibrationResult.Size = New System.Drawing.Size(600, 529)
        Me.dgv_CalibrationResult.TabIndex = 81
        '
        'dgv_VerificationResult
        '
        Me.dgv_VerificationResult.AllowUserToAddRows = False
        Me.dgv_VerificationResult.AllowUserToDeleteRows = False
        Me.dgv_VerificationResult.AllowUserToResizeColumns = False
        Me.dgv_VerificationResult.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_VerificationResult.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_VerificationResult.ColumnHeadersHeight = 60
        Me.dgv_VerificationResult.Location = New System.Drawing.Point(633, 36)
        Me.dgv_VerificationResult.Name = "dgv_VerificationResult"
        Me.dgv_VerificationResult.ReadOnly = True
        Me.dgv_VerificationResult.Size = New System.Drawing.Size(600, 529)
        Me.dgv_VerificationResult.TabIndex = 82
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(633, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(600, 30)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Verification"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabpg_CircuitView
        '
        Me.tabpg_CircuitView.Controls.Add(Me.Panel_Calibration_Circuit)
        Me.tabpg_CircuitView.Location = New System.Drawing.Point(4, 34)
        Me.tabpg_CircuitView.Name = "tabpg_CircuitView"
        Me.tabpg_CircuitView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpg_CircuitView.Size = New System.Drawing.Size(1236, 582)
        Me.tabpg_CircuitView.TabIndex = 1
        Me.tabpg_CircuitView.Text = "Circuit View"
        Me.tabpg_CircuitView.UseVisualStyleBackColor = True
        '
        'Panel_Calibration_Circuit
        '
        Me.Panel_Calibration_Circuit.AutoSize = True
        Me.Panel_Calibration_Circuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel_Calibration_Circuit.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_Calibration_Circuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Calibration_Circuit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Calibration_Circuit.Location = New System.Drawing.Point(3, 3)
        Me.Panel_Calibration_Circuit.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel_Calibration_Circuit.Name = "Panel_Calibration_Circuit"
        Me.Panel_Calibration_Circuit.Size = New System.Drawing.Size(1230, 576)
        Me.Panel_Calibration_Circuit.TabIndex = 85
        '
        'dsp_Vertemperature
        '
        Me.dsp_Vertemperature.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Vertemperature.Location = New System.Drawing.Point(948, 91)
        Me.dsp_Vertemperature.Name = "dsp_Vertemperature"
        Me.dsp_Vertemperature.Size = New System.Drawing.Size(115, 35)
        Me.dsp_Vertemperature.TabIndex = 91
        Me.dsp_Vertemperature.Text = "Verification" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Temperature (°C) :"
        Me.dsp_Vertemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_VerTemperature
        '
        Me.txtbx_VerTemperature.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerTemperature.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerTemperature.Location = New System.Drawing.Point(1073, 96)
        Me.txtbx_VerTemperature.Name = "txtbx_VerTemperature"
        Me.txtbx_VerTemperature.ReadOnly = True
        Me.txtbx_VerTemperature.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_VerTemperature.TabIndex = 92
        Me.txtbx_VerTemperature.TabStop = False
        '
        'dsp_Verflowrate
        '
        Me.dsp_Verflowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Verflowrate.Location = New System.Drawing.Point(722, 91)
        Me.dsp_Verflowrate.Name = "dsp_Verflowrate"
        Me.dsp_Verflowrate.Size = New System.Drawing.Size(110, 35)
        Me.dsp_Verflowrate.TabIndex = 89
        Me.dsp_Verflowrate.Text = "Verification Flowrate (l/min) :"
        Me.dsp_Verflowrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_VerFlowrate
        '
        Me.txtbx_VerFlowrate.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerFlowrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerFlowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerFlowrate.Location = New System.Drawing.Point(842, 96)
        Me.txtbx_VerFlowrate.Name = "txtbx_VerFlowrate"
        Me.txtbx_VerFlowrate.ReadOnly = True
        Me.txtbx_VerFlowrate.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_VerFlowrate.TabIndex = 90
        Me.txtbx_VerFlowrate.TabStop = False
        '
        'dsp_Caltemperature
        '
        Me.dsp_Caltemperature.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Caltemperature.Location = New System.Drawing.Point(238, 94)
        Me.dsp_Caltemperature.Name = "dsp_Caltemperature"
        Me.dsp_Caltemperature.Size = New System.Drawing.Size(115, 35)
        Me.dsp_Caltemperature.TabIndex = 87
        Me.dsp_Caltemperature.Text = "Calibration" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Temperature (°C) :"
        Me.dsp_Caltemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalTemperature
        '
        Me.txtbx_CalTemperature.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalTemperature.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalTemperature.Location = New System.Drawing.Point(363, 99)
        Me.txtbx_CalTemperature.Name = "txtbx_CalTemperature"
        Me.txtbx_CalTemperature.ReadOnly = True
        Me.txtbx_CalTemperature.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_CalTemperature.TabIndex = 88
        Me.txtbx_CalTemperature.TabStop = False
        '
        'dsp_Calflowrate
        '
        Me.dsp_Calflowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Calflowrate.Location = New System.Drawing.Point(12, 94)
        Me.dsp_Calflowrate.Name = "dsp_Calflowrate"
        Me.dsp_Calflowrate.Size = New System.Drawing.Size(110, 35)
        Me.dsp_Calflowrate.TabIndex = 85
        Me.dsp_Calflowrate.Text = "Calibration Flowrate (l/min) :"
        Me.dsp_Calflowrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalFlowrate
        '
        Me.txtbx_CalFlowrate.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalFlowrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalFlowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalFlowrate.Location = New System.Drawing.Point(132, 99)
        Me.txtbx_CalFlowrate.Name = "txtbx_CalFlowrate"
        Me.txtbx_CalFlowrate.ReadOnly = True
        Me.txtbx_CalFlowrate.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_CalFlowrate.TabIndex = 86
        Me.txtbx_CalFlowrate.TabStop = False
        '
        'txtbx_CalResult
        '
        Me.txtbx_CalResult.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalResult.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalResult.Location = New System.Drawing.Point(1277, 150)
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
        Me.txtbx_VerStatus.Location = New System.Drawing.Point(517, 146)
        Me.txtbx_VerStatus.Name = "txtbx_VerStatus"
        Me.txtbx_VerStatus.ReadOnly = True
        Me.txtbx_VerStatus.Size = New System.Drawing.Size(100, 29)
        Me.txtbx_VerStatus.TabIndex = 78
        '
        'txtbx_VerDP
        '
        Me.txtbx_VerDP.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerDP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerDP.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerDP.Location = New System.Drawing.Point(975, 148)
        Me.txtbx_VerDP.Name = "txtbx_VerDP"
        Me.txtbx_VerDP.ReadOnly = True
        Me.txtbx_VerDP.Size = New System.Drawing.Size(100, 29)
        Me.txtbx_VerDP.TabIndex = 79
        '
        'txtbx_CalOffset
        '
        Me.txtbx_CalOffset.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalOffset.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalOffset.Location = New System.Drawing.Point(215, 146)
        Me.txtbx_CalOffset.Name = "txtbx_CalOffset"
        Me.txtbx_CalOffset.ReadOnly = True
        Me.txtbx_CalOffset.Size = New System.Drawing.Size(100, 29)
        Me.txtbx_CalOffset.TabIndex = 77
        '
        'dsp_CalResult
        '
        Me.dsp_CalResult.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalResult.Location = New System.Drawing.Point(1107, 137)
        Me.dsp_CalResult.Name = "dsp_CalResult"
        Me.dsp_CalResult.Size = New System.Drawing.Size(150, 50)
        Me.dsp_CalResult.TabIndex = 76
        Me.dsp_CalResult.Text = "Calibration/Blank Result :"
        Me.dsp_CalResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_VerDP
        '
        Me.dsp_VerDP.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_VerDP.Location = New System.Drawing.Point(805, 137)
        Me.dsp_VerDP.Name = "dsp_VerDP"
        Me.dsp_VerDP.Size = New System.Drawing.Size(150, 50)
        Me.dsp_VerDP.TabIndex = 74
        Me.dsp_VerDP.Text = "Verification DP (kPa) :"
        Me.dsp_VerDP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_CalOffset
        '
        Me.dsp_CalOffset.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalOffset.Location = New System.Drawing.Point(45, 135)
        Me.dsp_CalOffset.Name = "dsp_CalOffset"
        Me.dsp_CalOffset.Size = New System.Drawing.Size(150, 50)
        Me.dsp_CalOffset.TabIndex = 72
        Me.dsp_CalOffset.Text = "Calibration Offset (kPa) :"
        Me.dsp_CalOffset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_VerOutletPressure
        '
        Me.dsp_VerOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_VerOutletPressure.Location = New System.Drawing.Point(951, 48)
        Me.dsp_VerOutletPressure.Name = "dsp_VerOutletPressure"
        Me.dsp_VerOutletPressure.Size = New System.Drawing.Size(111, 35)
        Me.dsp_VerOutletPressure.TabIndex = 69
        Me.dsp_VerOutletPressure.Text = "Verification Outlet Pressure (kPa) :"
        Me.dsp_VerOutletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_VerOutletPressure
        '
        Me.txtbx_VerOutletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerOutletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerOutletPressure.Location = New System.Drawing.Point(1072, 53)
        Me.txtbx_VerOutletPressure.Name = "txtbx_VerOutletPressure"
        Me.txtbx_VerOutletPressure.ReadOnly = True
        Me.txtbx_VerOutletPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_VerOutletPressure.TabIndex = 70
        Me.txtbx_VerOutletPressure.TabStop = False
        '
        'dsp_VerInletPressure
        '
        Me.dsp_VerInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_VerInletPressure.Location = New System.Drawing.Point(721, 48)
        Me.dsp_VerInletPressure.Name = "dsp_VerInletPressure"
        Me.dsp_VerInletPressure.Size = New System.Drawing.Size(110, 35)
        Me.dsp_VerInletPressure.TabIndex = 67
        Me.dsp_VerInletPressure.Text = "Verification Inlet Pressure (kPa) :"
        Me.dsp_VerInletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_VerInletPressure
        '
        Me.txtbx_VerInletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerInletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerInletPressure.Location = New System.Drawing.Point(841, 53)
        Me.txtbx_VerInletPressure.Name = "txtbx_VerInletPressure"
        Me.txtbx_VerInletPressure.ReadOnly = True
        Me.txtbx_VerInletPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_VerInletPressure.TabIndex = 68
        Me.txtbx_VerInletPressure.TabStop = False
        '
        'dsp_CalOutletPressure
        '
        Me.dsp_CalOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalOutletPressure.Location = New System.Drawing.Point(242, 51)
        Me.dsp_CalOutletPressure.Name = "dsp_CalOutletPressure"
        Me.dsp_CalOutletPressure.Size = New System.Drawing.Size(110, 35)
        Me.dsp_CalOutletPressure.TabIndex = 65
        Me.dsp_CalOutletPressure.Text = "Calibration Outlet Pressure (kPa) :"
        Me.dsp_CalOutletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalOutletPressure
        '
        Me.txtbx_CalOutletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalOutletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalOutletPressure.Location = New System.Drawing.Point(362, 56)
        Me.txtbx_CalOutletPressure.Name = "txtbx_CalOutletPressure"
        Me.txtbx_CalOutletPressure.ReadOnly = True
        Me.txtbx_CalOutletPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_CalOutletPressure.TabIndex = 66
        Me.txtbx_CalOutletPressure.TabStop = False
        '
        'dsp_CalInletPressure
        '
        Me.dsp_CalInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalInletPressure.Location = New System.Drawing.Point(11, 51)
        Me.dsp_CalInletPressure.Name = "dsp_CalInletPressure"
        Me.dsp_CalInletPressure.Size = New System.Drawing.Size(110, 35)
        Me.dsp_CalInletPressure.TabIndex = 63
        Me.dsp_CalInletPressure.Text = "Calibration Inlet Pressure (kPa) :"
        Me.dsp_CalInletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalInletPressure
        '
        Me.txtbx_CalInletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalInletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalInletPressure.Location = New System.Drawing.Point(131, 56)
        Me.txtbx_CalInletPressure.Name = "txtbx_CalInletPressure"
        Me.txtbx_CalInletPressure.ReadOnly = True
        Me.txtbx_CalInletPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_CalInletPressure.TabIndex = 64
        Me.txtbx_CalInletPressure.TabStop = False
        '
        'dsp_VerStatus
        '
        Me.dsp_VerStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_VerStatus.Location = New System.Drawing.Point(347, 135)
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
        Me.lbl_CalibrationMsg.Size = New System.Drawing.Size(1423, 40)
        Me.lbl_CalibrationMsg.TabIndex = 35
        Me.lbl_CalibrationMsg.Text = "Press ""Calibrate"" to Start"
        Me.lbl_CalibrationMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dsp_VerBackpress
        '
        Me.dsp_VerBackpress.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_VerBackpress.Location = New System.Drawing.Point(1183, 48)
        Me.dsp_VerBackpress.Name = "dsp_VerBackpress"
        Me.dsp_VerBackpress.Size = New System.Drawing.Size(110, 35)
        Me.dsp_VerBackpress.TabIndex = 95
        Me.dsp_VerBackpress.Text = "Verification Back Pressure (kPa) :"
        Me.dsp_VerBackpress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_VerBackpress
        '
        Me.txtbx_VerBackpress.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_VerBackpress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_VerBackpress.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_VerBackpress.Location = New System.Drawing.Point(1303, 53)
        Me.txtbx_VerBackpress.Name = "txtbx_VerBackpress"
        Me.txtbx_VerBackpress.ReadOnly = True
        Me.txtbx_VerBackpress.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_VerBackpress.TabIndex = 96
        Me.txtbx_VerBackpress.TabStop = False
        '
        'dsp_CalBackpress
        '
        Me.dsp_CalBackpress.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_CalBackpress.Location = New System.Drawing.Point(473, 51)
        Me.dsp_CalBackpress.Name = "dsp_CalBackpress"
        Me.dsp_CalBackpress.Size = New System.Drawing.Size(110, 35)
        Me.dsp_CalBackpress.TabIndex = 93
        Me.dsp_CalBackpress.Text = "Calibration Back Pressure (kPa) :"
        Me.dsp_CalBackpress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_CalBackpress
        '
        Me.txtbx_CalBackpress.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_CalBackpress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_CalBackpress.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_CalBackpress.Location = New System.Drawing.Point(593, 56)
        Me.txtbx_CalBackpress.Name = "txtbx_CalBackpress"
        Me.txtbx_CalBackpress.ReadOnly = True
        Me.txtbx_CalBackpress.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_CalBackpress.TabIndex = 94
        Me.txtbx_CalBackpress.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1378, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 25)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Alarm/Warn Counter"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label1.Text = "Calibration && Verification"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tmr_Calibration
        '
        '
        'tmr_Verification
        '
        '
        'tmr_Calibration_EndSeq
        '
        '
        'tmr_Verification_EndSeq
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
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabpg_GraphView.ResumeLayout(False)
        Me.tabpg_GraphView.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.tabpg_TableView.ResumeLayout(False)
        CType(Me.dgv_CalibrationResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_VerificationResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpg_CircuitView.ResumeLayout(False)
        Me.tabpg_CircuitView.PerformLayout()
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
    Friend WithEvents tmr_Calibration As Timer
    Friend WithEvents tmr_Verification As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents dgv_VerificationResult As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_CircuitView As Button
    Friend WithEvents dgv_CalibrationResult As DataGridView
    Friend WithEvents Panel_Calibration_Circuit As Panel
    Friend WithEvents dsp_Vertemperature As Label
    Friend WithEvents txtbx_VerTemperature As TextBox
    Friend WithEvents dsp_Verflowrate As Label
    Friend WithEvents txtbx_VerFlowrate As TextBox
    Friend WithEvents dsp_Caltemperature As Label
    Friend WithEvents txtbx_CalTemperature As TextBox
    Friend WithEvents dsp_Calflowrate As Label
    Friend WithEvents txtbx_CalFlowrate As TextBox
    Friend WithEvents dsp_CalBackpress As Label
    Friend WithEvents txtbx_CalBackpress As TextBox
    Friend WithEvents dsp_VerBackpress As Label
    Friend WithEvents txtbx_VerBackpress As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabpg_GraphView As TabPage
    Friend WithEvents tabpg_TableView As TabPage
    Friend WithEvents tabpg_CircuitView As TabPage
    Friend WithEvents CartesianChart_CalibrationLiveGraph As LiveChartsCore.SkiaSharpView.WinForms.CartesianChart
    Friend WithEvents checkbx_GraphRPM As CheckBox
    Friend WithEvents checkbx_GraphTemperature As CheckBox
    Friend WithEvents checkbx_GraphFlowrate As CheckBox
    Friend WithEvents checkbx_GraphBP As CheckBox
    Friend WithEvents checkbx_GraphOutletPressure As CheckBox
    Friend WithEvents checkbx_GraphInletPressure As CheckBox
    Friend WithEvents checkbx_GraphDP As CheckBox
    Friend WithEvents checkbx_ShowTooltip As CheckBox
    Friend WithEvents txtbx_CalDate As TextBox
    Friend WithEvents dsp_CalDate As Label
    Friend WithEvents txtbx_RecipeRev As TextBox
    Friend WithEvents dsp_RecipeRev As Label
    Friend WithEvents btn_ResetZoom As Button
    Friend WithEvents tmr_Calibration_EndSeq As Timer
    Friend WithEvents tmr_Verification_EndSeq As Timer
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
End Class
