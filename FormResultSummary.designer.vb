<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormResultSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormResultSummary))
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
        Me.txtbx_ResultRecipeIDRev = New System.Windows.Forms.TextBox()
        Me.dsp_Resultattempt = New System.Windows.Forms.Label()
        Me.txtbx_Resultattempt = New System.Windows.Forms.TextBox()
        Me.dsp_ResultSerialUID = New System.Windows.Forms.Label()
        Me.txtbx_ResultSerialUID = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbx_ResultSearchSerial = New System.Windows.Forms.ComboBox()
        Me.dsp_ResultSearchSerial = New System.Windows.Forms.Label()
        Me.cmbx_ResultSearchLot = New System.Windows.Forms.ComboBox()
        Me.cmbx_ResultSearchAttempt = New System.Windows.Forms.ComboBox()
        Me.dsp_ResultSearchAttempt = New System.Windows.Forms.Label()
        Me.dsp_ResultSearchLot = New System.Windows.Forms.Label()
        Me.btn_ResultExport = New System.Windows.Forms.Button()
        Me.btn_ResultSearch = New System.Windows.Forms.Button()
        Me.txtbx_ResultTest = New System.Windows.Forms.TextBox()
        Me.dsp_ResultTest = New System.Windows.Forms.Label()
        Me.txtbx_ResultDiffPressure = New System.Windows.Forms.TextBox()
        Me.dsp_ResultDiffPressure = New System.Windows.Forms.Label()
        Me.txtbx_ResultOutletPressure = New System.Windows.Forms.TextBox()
        Me.dsp_ResultOutletPressure = New System.Windows.Forms.Label()
        Me.txtbx_ResultInletPressure = New System.Windows.Forms.TextBox()
        Me.dsp_ResultInletPressure = New System.Windows.Forms.Label()
        Me.txtbx_ResultFlowrate = New System.Windows.Forms.TextBox()
        Me.txtbx_ResultTemperature = New System.Windows.Forms.TextBox()
        Me.txtbx_ResultCalOffset = New System.Windows.Forms.TextBox()
        Me.dsp_ResultFlowrate = New System.Windows.Forms.Label()
        Me.dsp_ResultTemperature = New System.Windows.Forms.Label()
        Me.dsp_ResultCalOffset = New System.Windows.Forms.Label()
        Me.dsp_ResultRecipeID = New System.Windows.Forms.Label()
        Me.dsp_ResultConfirmation = New System.Windows.Forms.Label()
        Me.dsp_ResultPartID = New System.Windows.Forms.Label()
        Me.dsp_ResultWorkOrder = New System.Windows.Forms.Label()
        Me.dsp_ResultTimestamp = New System.Windows.Forms.Label()
        Me.txtbx_ResultRecipeID = New System.Windows.Forms.TextBox()
        Me.txtbx_ResultConfirmation = New System.Windows.Forms.TextBox()
        Me.txtbx_ResultPartID = New System.Windows.Forms.TextBox()
        Me.txtbx_ResultWorkOrder = New System.Windows.Forms.TextBox()
        Me.txtbx_ResultTimestamp = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dsp_ResultDrain3 = New System.Windows.Forms.Label()
        Me.txtbx_ResultDrain3 = New System.Windows.Forms.TextBox()
        Me.dsp_ResultDrain2 = New System.Windows.Forms.Label()
        Me.txtbx_ResultDrain2 = New System.Windows.Forms.TextBox()
        Me.dsp_ResultDrain1 = New System.Windows.Forms.Label()
        Me.txtbx_ResultDrain1 = New System.Windows.Forms.TextBox()
        Me.dsp_ResultDPTest2 = New System.Windows.Forms.Label()
        Me.txtbx_ResultDPTest2 = New System.Windows.Forms.TextBox()
        Me.dsp_Resultflush2 = New System.Windows.Forms.Label()
        Me.txtbx_Resultflush2 = New System.Windows.Forms.TextBox()
        Me.dsp_ResultDPTest1 = New System.Windows.Forms.Label()
        Me.txtbx_ResultDPTest1 = New System.Windows.Forms.TextBox()
        Me.dsp_Resultflush1 = New System.Windows.Forms.Label()
        Me.txtbx_Resultflush1 = New System.Windows.Forms.TextBox()
        Me.dgv_Resultsummary = New System.Windows.Forms.DataGridView()
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
        CType(Me.dgv_Resultsummary, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel2.Controls.Add(Me.txtbx_ResultRecipeIDRev)
        Me.Panel2.Controls.Add(Me.dsp_Resultattempt)
        Me.Panel2.Controls.Add(Me.txtbx_Resultattempt)
        Me.Panel2.Controls.Add(Me.dsp_ResultSerialUID)
        Me.Panel2.Controls.Add(Me.txtbx_ResultSerialUID)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.txtbx_ResultTest)
        Me.Panel2.Controls.Add(Me.dsp_ResultTest)
        Me.Panel2.Controls.Add(Me.txtbx_ResultDiffPressure)
        Me.Panel2.Controls.Add(Me.dsp_ResultDiffPressure)
        Me.Panel2.Controls.Add(Me.txtbx_ResultOutletPressure)
        Me.Panel2.Controls.Add(Me.dsp_ResultOutletPressure)
        Me.Panel2.Controls.Add(Me.txtbx_ResultInletPressure)
        Me.Panel2.Controls.Add(Me.dsp_ResultInletPressure)
        Me.Panel2.Controls.Add(Me.txtbx_ResultFlowrate)
        Me.Panel2.Controls.Add(Me.txtbx_ResultTemperature)
        Me.Panel2.Controls.Add(Me.txtbx_ResultCalOffset)
        Me.Panel2.Controls.Add(Me.dsp_ResultFlowrate)
        Me.Panel2.Controls.Add(Me.dsp_ResultTemperature)
        Me.Panel2.Controls.Add(Me.dsp_ResultCalOffset)
        Me.Panel2.Controls.Add(Me.dsp_ResultRecipeID)
        Me.Panel2.Controls.Add(Me.dsp_ResultConfirmation)
        Me.Panel2.Controls.Add(Me.dsp_ResultPartID)
        Me.Panel2.Controls.Add(Me.dsp_ResultWorkOrder)
        Me.Panel2.Controls.Add(Me.dsp_ResultTimestamp)
        Me.Panel2.Controls.Add(Me.txtbx_ResultRecipeID)
        Me.Panel2.Controls.Add(Me.txtbx_ResultConfirmation)
        Me.Panel2.Controls.Add(Me.txtbx_ResultPartID)
        Me.Panel2.Controls.Add(Me.txtbx_ResultWorkOrder)
        Me.Panel2.Controls.Add(Me.txtbx_ResultTimestamp)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(564, 802)
        Me.Panel2.TabIndex = 1
        '
        'txtbx_ResultRecipeIDRev
        '
        Me.txtbx_ResultRecipeIDRev.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultRecipeIDRev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultRecipeIDRev.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultRecipeIDRev.Location = New System.Drawing.Point(412, 454)
        Me.txtbx_ResultRecipeIDRev.Name = "txtbx_ResultRecipeIDRev"
        Me.txtbx_ResultRecipeIDRev.ReadOnly = True
        Me.txtbx_ResultRecipeIDRev.Size = New System.Drawing.Size(74, 25)
        Me.txtbx_ResultRecipeIDRev.TabIndex = 59
        Me.txtbx_ResultRecipeIDRev.TabStop = False
        '
        'dsp_Resultattempt
        '
        Me.dsp_Resultattempt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Resultattempt.Location = New System.Drawing.Point(345, 234)
        Me.dsp_Resultattempt.Name = "dsp_Resultattempt"
        Me.dsp_Resultattempt.Size = New System.Drawing.Size(90, 35)
        Me.dsp_Resultattempt.TabIndex = 57
        Me.dsp_Resultattempt.Text = "Attempt No :"
        Me.dsp_Resultattempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_Resultattempt
        '
        Me.txtbx_Resultattempt.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_Resultattempt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_Resultattempt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_Resultattempt.Location = New System.Drawing.Point(441, 239)
        Me.txtbx_Resultattempt.Name = "txtbx_Resultattempt"
        Me.txtbx_Resultattempt.ReadOnly = True
        Me.txtbx_Resultattempt.Size = New System.Drawing.Size(80, 25)
        Me.txtbx_Resultattempt.TabIndex = 58
        Me.txtbx_Resultattempt.TabStop = False
        '
        'dsp_ResultSerialUID
        '
        Me.dsp_ResultSerialUID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultSerialUID.Location = New System.Drawing.Point(19, 234)
        Me.dsp_ResultSerialUID.Name = "dsp_ResultSerialUID"
        Me.dsp_ResultSerialUID.Size = New System.Drawing.Size(100, 35)
        Me.dsp_ResultSerialUID.TabIndex = 55
        Me.dsp_ResultSerialUID.Text = "Serial UID :"
        Me.dsp_ResultSerialUID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultSerialUID
        '
        Me.txtbx_ResultSerialUID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultSerialUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultSerialUID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultSerialUID.Location = New System.Drawing.Point(131, 239)
        Me.txtbx_ResultSerialUID.Name = "txtbx_ResultSerialUID"
        Me.txtbx_ResultSerialUID.ReadOnly = True
        Me.txtbx_ResultSerialUID.Size = New System.Drawing.Size(200, 25)
        Me.txtbx_ResultSerialUID.TabIndex = 56
        Me.txtbx_ResultSerialUID.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.cmbx_ResultSearchSerial)
        Me.Panel4.Controls.Add(Me.dsp_ResultSearchSerial)
        Me.Panel4.Controls.Add(Me.cmbx_ResultSearchLot)
        Me.Panel4.Controls.Add(Me.cmbx_ResultSearchAttempt)
        Me.Panel4.Controls.Add(Me.dsp_ResultSearchAttempt)
        Me.Panel4.Controls.Add(Me.dsp_ResultSearchLot)
        Me.Panel4.Controls.Add(Me.btn_ResultExport)
        Me.Panel4.Controls.Add(Me.btn_ResultSearch)
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(556, 215)
        Me.Panel4.TabIndex = 54
        '
        'cmbx_ResultSearchSerial
        '
        Me.cmbx_ResultSearchSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_ResultSearchSerial.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_ResultSearchSerial.FormattingEnabled = True
        Me.cmbx_ResultSearchSerial.Location = New System.Drawing.Point(224, 59)
        Me.cmbx_ResultSearchSerial.Name = "cmbx_ResultSearchSerial"
        Me.cmbx_ResultSearchSerial.Size = New System.Drawing.Size(260, 25)
        Me.cmbx_ResultSearchSerial.TabIndex = 11
        '
        'dsp_ResultSearchSerial
        '
        Me.dsp_ResultSearchSerial.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultSearchSerial.Location = New System.Drawing.Point(18, 54)
        Me.dsp_ResultSearchSerial.Name = "dsp_ResultSearchSerial"
        Me.dsp_ResultSearchSerial.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultSearchSerial.TabIndex = 57
        Me.dsp_ResultSearchSerial.Text = "Serial Number :"
        Me.dsp_ResultSearchSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbx_ResultSearchLot
        '
        Me.cmbx_ResultSearchLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbx_ResultSearchLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbx_ResultSearchLot.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_ResultSearchLot.FormattingEnabled = True
        Me.cmbx_ResultSearchLot.Location = New System.Drawing.Point(223, 17)
        Me.cmbx_ResultSearchLot.Name = "cmbx_ResultSearchLot"
        Me.cmbx_ResultSearchLot.Size = New System.Drawing.Size(260, 25)
        Me.cmbx_ResultSearchLot.TabIndex = 10
        '
        'cmbx_ResultSearchAttempt
        '
        Me.cmbx_ResultSearchAttempt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_ResultSearchAttempt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_ResultSearchAttempt.FormattingEnabled = True
        Me.cmbx_ResultSearchAttempt.Location = New System.Drawing.Point(224, 101)
        Me.cmbx_ResultSearchAttempt.Name = "cmbx_ResultSearchAttempt"
        Me.cmbx_ResultSearchAttempt.Size = New System.Drawing.Size(260, 25)
        Me.cmbx_ResultSearchAttempt.TabIndex = 12
        '
        'dsp_ResultSearchAttempt
        '
        Me.dsp_ResultSearchAttempt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultSearchAttempt.Location = New System.Drawing.Point(18, 96)
        Me.dsp_ResultSearchAttempt.Name = "dsp_ResultSearchAttempt"
        Me.dsp_ResultSearchAttempt.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultSearchAttempt.TabIndex = 54
        Me.dsp_ResultSearchAttempt.Text = "Attempt Number :"
        Me.dsp_ResultSearchAttempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ResultSearchLot
        '
        Me.dsp_ResultSearchLot.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultSearchLot.Location = New System.Drawing.Point(18, 12)
        Me.dsp_ResultSearchLot.Name = "dsp_ResultSearchLot"
        Me.dsp_ResultSearchLot.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultSearchLot.TabIndex = 52
        Me.dsp_ResultSearchLot.Text = "Lot ID :"
        Me.dsp_ResultSearchLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_ResultExport
        '
        Me.btn_ResultExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_ResultExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ResultExport.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ResultExport.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_ResultExport.Location = New System.Drawing.Point(320, 146)
        Me.btn_ResultExport.Name = "btn_ResultExport"
        Me.btn_ResultExport.Size = New System.Drawing.Size(150, 50)
        Me.btn_ResultExport.TabIndex = 14
        Me.btn_ResultExport.Text = "Export"
        Me.btn_ResultExport.UseVisualStyleBackColor = False
        '
        'btn_ResultSearch
        '
        Me.btn_ResultSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_ResultSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ResultSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ResultSearch.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_ResultSearch.Location = New System.Drawing.Point(85, 146)
        Me.btn_ResultSearch.Name = "btn_ResultSearch"
        Me.btn_ResultSearch.Size = New System.Drawing.Size(150, 50)
        Me.btn_ResultSearch.TabIndex = 13
        Me.btn_ResultSearch.Text = "Search"
        Me.btn_ResultSearch.UseVisualStyleBackColor = False
        '
        'txtbx_ResultTest
        '
        Me.txtbx_ResultTest.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultTest.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultTest.Location = New System.Drawing.Point(226, 755)
        Me.txtbx_ResultTest.Name = "txtbx_ResultTest"
        Me.txtbx_ResultTest.ReadOnly = True
        Me.txtbx_ResultTest.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultTest.TabIndex = 27
        Me.txtbx_ResultTest.TabStop = False
        '
        'dsp_ResultTest
        '
        Me.dsp_ResultTest.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultTest.Location = New System.Drawing.Point(20, 750)
        Me.dsp_ResultTest.Name = "dsp_ResultTest"
        Me.dsp_ResultTest.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultTest.TabIndex = 26
        Me.dsp_ResultTest.Text = "DP Test Result  :"
        Me.dsp_ResultTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultDiffPressure
        '
        Me.txtbx_ResultDiffPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultDiffPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultDiffPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultDiffPressure.Location = New System.Drawing.Point(226, 712)
        Me.txtbx_ResultDiffPressure.Name = "txtbx_ResultDiffPressure"
        Me.txtbx_ResultDiffPressure.ReadOnly = True
        Me.txtbx_ResultDiffPressure.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultDiffPressure.TabIndex = 25
        Me.txtbx_ResultDiffPressure.TabStop = False
        '
        'dsp_ResultDiffPressure
        '
        Me.dsp_ResultDiffPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultDiffPressure.Location = New System.Drawing.Point(20, 707)
        Me.dsp_ResultDiffPressure.Name = "dsp_ResultDiffPressure"
        Me.dsp_ResultDiffPressure.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultDiffPressure.TabIndex = 24
        Me.dsp_ResultDiffPressure.Text = "Calculated Differnetial Pressure (kPa)  :"
        Me.dsp_ResultDiffPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultOutletPressure
        '
        Me.txtbx_ResultOutletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultOutletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultOutletPressure.Location = New System.Drawing.Point(226, 669)
        Me.txtbx_ResultOutletPressure.Name = "txtbx_ResultOutletPressure"
        Me.txtbx_ResultOutletPressure.ReadOnly = True
        Me.txtbx_ResultOutletPressure.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultOutletPressure.TabIndex = 23
        Me.txtbx_ResultOutletPressure.TabStop = False
        '
        'dsp_ResultOutletPressure
        '
        Me.dsp_ResultOutletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultOutletPressure.Location = New System.Drawing.Point(20, 664)
        Me.dsp_ResultOutletPressure.Name = "dsp_ResultOutletPressure"
        Me.dsp_ResultOutletPressure.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultOutletPressure.TabIndex = 22
        Me.dsp_ResultOutletPressure.Text = "DP Test Outlet Pressure (kPa) :"
        Me.dsp_ResultOutletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultInletPressure
        '
        Me.txtbx_ResultInletPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultInletPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultInletPressure.Location = New System.Drawing.Point(226, 626)
        Me.txtbx_ResultInletPressure.Name = "txtbx_ResultInletPressure"
        Me.txtbx_ResultInletPressure.ReadOnly = True
        Me.txtbx_ResultInletPressure.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultInletPressure.TabIndex = 21
        Me.txtbx_ResultInletPressure.TabStop = False
        '
        'dsp_ResultInletPressure
        '
        Me.dsp_ResultInletPressure.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultInletPressure.Location = New System.Drawing.Point(20, 621)
        Me.dsp_ResultInletPressure.Name = "dsp_ResultInletPressure"
        Me.dsp_ResultInletPressure.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultInletPressure.TabIndex = 20
        Me.dsp_ResultInletPressure.Text = "DP Test Inlet Pressure " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(kPa) :"
        Me.dsp_ResultInletPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultFlowrate
        '
        Me.txtbx_ResultFlowrate.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultFlowrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultFlowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultFlowrate.Location = New System.Drawing.Point(226, 583)
        Me.txtbx_ResultFlowrate.Name = "txtbx_ResultFlowrate"
        Me.txtbx_ResultFlowrate.ReadOnly = True
        Me.txtbx_ResultFlowrate.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultFlowrate.TabIndex = 19
        Me.txtbx_ResultFlowrate.TabStop = False
        '
        'txtbx_ResultTemperature
        '
        Me.txtbx_ResultTemperature.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultTemperature.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultTemperature.Location = New System.Drawing.Point(226, 540)
        Me.txtbx_ResultTemperature.Name = "txtbx_ResultTemperature"
        Me.txtbx_ResultTemperature.ReadOnly = True
        Me.txtbx_ResultTemperature.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultTemperature.TabIndex = 18
        Me.txtbx_ResultTemperature.TabStop = False
        '
        'txtbx_ResultCalOffset
        '
        Me.txtbx_ResultCalOffset.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultCalOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultCalOffset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultCalOffset.Location = New System.Drawing.Point(226, 497)
        Me.txtbx_ResultCalOffset.Name = "txtbx_ResultCalOffset"
        Me.txtbx_ResultCalOffset.ReadOnly = True
        Me.txtbx_ResultCalOffset.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultCalOffset.TabIndex = 17
        Me.txtbx_ResultCalOffset.TabStop = False
        '
        'dsp_ResultFlowrate
        '
        Me.dsp_ResultFlowrate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultFlowrate.Location = New System.Drawing.Point(20, 578)
        Me.dsp_ResultFlowrate.Name = "dsp_ResultFlowrate"
        Me.dsp_ResultFlowrate.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultFlowrate.TabIndex = 8
        Me.dsp_ResultFlowrate.Text = "DP Test Flowrate (l/min) :"
        Me.dsp_ResultFlowrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ResultTemperature
        '
        Me.dsp_ResultTemperature.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultTemperature.Location = New System.Drawing.Point(20, 535)
        Me.dsp_ResultTemperature.Name = "dsp_ResultTemperature"
        Me.dsp_ResultTemperature.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultTemperature.TabIndex = 8
        Me.dsp_ResultTemperature.Text = "DP Test Temperature (C) :"
        Me.dsp_ResultTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ResultCalOffset
        '
        Me.dsp_ResultCalOffset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultCalOffset.Location = New System.Drawing.Point(20, 492)
        Me.dsp_ResultCalOffset.Name = "dsp_ResultCalOffset"
        Me.dsp_ResultCalOffset.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultCalOffset.TabIndex = 8
        Me.dsp_ResultCalOffset.Text = "Calibration/Blank Offset (kPa)  :"
        Me.dsp_ResultCalOffset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ResultRecipeID
        '
        Me.dsp_ResultRecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultRecipeID.Location = New System.Drawing.Point(20, 449)
        Me.dsp_ResultRecipeID.Name = "dsp_ResultRecipeID"
        Me.dsp_ResultRecipeID.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultRecipeID.TabIndex = 8
        Me.dsp_ResultRecipeID.Text = "Recipe ID :"
        Me.dsp_ResultRecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ResultConfirmation
        '
        Me.dsp_ResultConfirmation.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultConfirmation.Location = New System.Drawing.Point(20, 406)
        Me.dsp_ResultConfirmation.Name = "dsp_ResultConfirmation"
        Me.dsp_ResultConfirmation.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultConfirmation.TabIndex = 8
        Me.dsp_ResultConfirmation.Text = "Confirmation ID :"
        Me.dsp_ResultConfirmation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ResultPartID
        '
        Me.dsp_ResultPartID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultPartID.Location = New System.Drawing.Point(20, 363)
        Me.dsp_ResultPartID.Name = "dsp_ResultPartID"
        Me.dsp_ResultPartID.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultPartID.TabIndex = 8
        Me.dsp_ResultPartID.Text = "Part ID :"
        Me.dsp_ResultPartID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ResultWorkOrder
        '
        Me.dsp_ResultWorkOrder.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultWorkOrder.Location = New System.Drawing.Point(20, 320)
        Me.dsp_ResultWorkOrder.Name = "dsp_ResultWorkOrder"
        Me.dsp_ResultWorkOrder.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultWorkOrder.TabIndex = 8
        Me.dsp_ResultWorkOrder.Text = "Work Order No :"
        Me.dsp_ResultWorkOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ResultTimestamp
        '
        Me.dsp_ResultTimestamp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultTimestamp.Location = New System.Drawing.Point(20, 277)
        Me.dsp_ResultTimestamp.Name = "dsp_ResultTimestamp"
        Me.dsp_ResultTimestamp.Size = New System.Drawing.Size(200, 35)
        Me.dsp_ResultTimestamp.TabIndex = 8
        Me.dsp_ResultTimestamp.Text = "Production TimeStamp :"
        Me.dsp_ResultTimestamp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultRecipeID
        '
        Me.txtbx_ResultRecipeID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultRecipeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultRecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultRecipeID.Location = New System.Drawing.Point(226, 454)
        Me.txtbx_ResultRecipeID.Name = "txtbx_ResultRecipeID"
        Me.txtbx_ResultRecipeID.ReadOnly = True
        Me.txtbx_ResultRecipeID.Size = New System.Drawing.Size(180, 25)
        Me.txtbx_ResultRecipeID.TabIndex = 16
        Me.txtbx_ResultRecipeID.TabStop = False
        '
        'txtbx_ResultConfirmation
        '
        Me.txtbx_ResultConfirmation.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultConfirmation.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultConfirmation.Location = New System.Drawing.Point(226, 411)
        Me.txtbx_ResultConfirmation.Name = "txtbx_ResultConfirmation"
        Me.txtbx_ResultConfirmation.ReadOnly = True
        Me.txtbx_ResultConfirmation.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultConfirmation.TabIndex = 15
        Me.txtbx_ResultConfirmation.TabStop = False
        '
        'txtbx_ResultPartID
        '
        Me.txtbx_ResultPartID.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultPartID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultPartID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultPartID.Location = New System.Drawing.Point(226, 368)
        Me.txtbx_ResultPartID.Name = "txtbx_ResultPartID"
        Me.txtbx_ResultPartID.ReadOnly = True
        Me.txtbx_ResultPartID.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultPartID.TabIndex = 14
        Me.txtbx_ResultPartID.TabStop = False
        '
        'txtbx_ResultWorkOrder
        '
        Me.txtbx_ResultWorkOrder.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultWorkOrder.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultWorkOrder.Location = New System.Drawing.Point(226, 325)
        Me.txtbx_ResultWorkOrder.Name = "txtbx_ResultWorkOrder"
        Me.txtbx_ResultWorkOrder.ReadOnly = True
        Me.txtbx_ResultWorkOrder.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultWorkOrder.TabIndex = 12
        Me.txtbx_ResultWorkOrder.TabStop = False
        '
        'txtbx_ResultTimestamp
        '
        Me.txtbx_ResultTimestamp.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultTimestamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultTimestamp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultTimestamp.Location = New System.Drawing.Point(226, 282)
        Me.txtbx_ResultTimestamp.Name = "txtbx_ResultTimestamp"
        Me.txtbx_ResultTimestamp.ReadOnly = True
        Me.txtbx_ResultTimestamp.Size = New System.Drawing.Size(260, 25)
        Me.txtbx_ResultTimestamp.TabIndex = 11
        Me.txtbx_ResultTimestamp.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.dsp_ResultDrain3)
        Me.Panel3.Controls.Add(Me.txtbx_ResultDrain3)
        Me.Panel3.Controls.Add(Me.dsp_ResultDrain2)
        Me.Panel3.Controls.Add(Me.txtbx_ResultDrain2)
        Me.Panel3.Controls.Add(Me.dsp_ResultDrain1)
        Me.Panel3.Controls.Add(Me.txtbx_ResultDrain1)
        Me.Panel3.Controls.Add(Me.dsp_ResultDPTest2)
        Me.Panel3.Controls.Add(Me.txtbx_ResultDPTest2)
        Me.Panel3.Controls.Add(Me.dsp_Resultflush2)
        Me.Panel3.Controls.Add(Me.txtbx_Resultflush2)
        Me.Panel3.Controls.Add(Me.dsp_ResultDPTest1)
        Me.Panel3.Controls.Add(Me.txtbx_ResultDPTest1)
        Me.Panel3.Controls.Add(Me.dsp_Resultflush1)
        Me.Panel3.Controls.Add(Me.txtbx_Resultflush1)
        Me.Panel3.Controls.Add(Me.dgv_Resultsummary)
        Me.Panel3.Location = New System.Drawing.Point(566, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1311, 802)
        Me.Panel3.TabIndex = 2
        '
        'dsp_ResultDrain3
        '
        Me.dsp_ResultDrain3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultDrain3.Location = New System.Drawing.Point(654, 73)
        Me.dsp_ResultDrain3.Name = "dsp_ResultDrain3"
        Me.dsp_ResultDrain3.Size = New System.Drawing.Size(150, 30)
        Me.dsp_ResultDrain3.TabIndex = 67
        Me.dsp_ResultDrain3.Text = "Drain-3 Circuit :"
        Me.dsp_ResultDrain3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultDrain3
        '
        Me.txtbx_ResultDrain3.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultDrain3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultDrain3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultDrain3.Location = New System.Drawing.Point(824, 76)
        Me.txtbx_ResultDrain3.Name = "txtbx_ResultDrain3"
        Me.txtbx_ResultDrain3.ReadOnly = True
        Me.txtbx_ResultDrain3.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_ResultDrain3.TabIndex = 68
        Me.txtbx_ResultDrain3.TabStop = False
        Me.txtbx_ResultDrain3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_ResultDrain2
        '
        Me.dsp_ResultDrain2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultDrain2.Location = New System.Drawing.Point(352, 73)
        Me.dsp_ResultDrain2.Name = "dsp_ResultDrain2"
        Me.dsp_ResultDrain2.Size = New System.Drawing.Size(150, 30)
        Me.dsp_ResultDrain2.TabIndex = 65
        Me.dsp_ResultDrain2.Text = "Drain-2 Circuit :"
        Me.dsp_ResultDrain2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultDrain2
        '
        Me.txtbx_ResultDrain2.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultDrain2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultDrain2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultDrain2.Location = New System.Drawing.Point(522, 76)
        Me.txtbx_ResultDrain2.Name = "txtbx_ResultDrain2"
        Me.txtbx_ResultDrain2.ReadOnly = True
        Me.txtbx_ResultDrain2.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_ResultDrain2.TabIndex = 66
        Me.txtbx_ResultDrain2.TabStop = False
        Me.txtbx_ResultDrain2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_ResultDrain1
        '
        Me.dsp_ResultDrain1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultDrain1.Location = New System.Drawing.Point(50, 73)
        Me.dsp_ResultDrain1.Name = "dsp_ResultDrain1"
        Me.dsp_ResultDrain1.Size = New System.Drawing.Size(150, 30)
        Me.dsp_ResultDrain1.TabIndex = 63
        Me.dsp_ResultDrain1.Text = "Drain-1 Circuit :"
        Me.dsp_ResultDrain1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultDrain1
        '
        Me.txtbx_ResultDrain1.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultDrain1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultDrain1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultDrain1.Location = New System.Drawing.Point(220, 76)
        Me.txtbx_ResultDrain1.Name = "txtbx_ResultDrain1"
        Me.txtbx_ResultDrain1.ReadOnly = True
        Me.txtbx_ResultDrain1.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_ResultDrain1.TabIndex = 64
        Me.txtbx_ResultDrain1.TabStop = False
        Me.txtbx_ResultDrain1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_ResultDPTest2
        '
        Me.dsp_ResultDPTest2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultDPTest2.Location = New System.Drawing.Point(956, 12)
        Me.dsp_ResultDPTest2.Name = "dsp_ResultDPTest2"
        Me.dsp_ResultDPTest2.Size = New System.Drawing.Size(150, 30)
        Me.dsp_ResultDPTest2.TabIndex = 61
        Me.dsp_ResultDPTest2.Text = "DP Test-2 Circuit :"
        Me.dsp_ResultDPTest2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultDPTest2
        '
        Me.txtbx_ResultDPTest2.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultDPTest2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultDPTest2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultDPTest2.Location = New System.Drawing.Point(1126, 15)
        Me.txtbx_ResultDPTest2.Name = "txtbx_ResultDPTest2"
        Me.txtbx_ResultDPTest2.ReadOnly = True
        Me.txtbx_ResultDPTest2.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_ResultDPTest2.TabIndex = 62
        Me.txtbx_ResultDPTest2.TabStop = False
        Me.txtbx_ResultDPTest2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_Resultflush2
        '
        Me.dsp_Resultflush2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Resultflush2.Location = New System.Drawing.Point(654, 12)
        Me.dsp_Resultflush2.Name = "dsp_Resultflush2"
        Me.dsp_Resultflush2.Size = New System.Drawing.Size(150, 30)
        Me.dsp_Resultflush2.TabIndex = 59
        Me.dsp_Resultflush2.Text = "Flush-2 Circuit :"
        Me.dsp_Resultflush2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_Resultflush2
        '
        Me.txtbx_Resultflush2.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_Resultflush2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_Resultflush2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_Resultflush2.Location = New System.Drawing.Point(824, 15)
        Me.txtbx_Resultflush2.Name = "txtbx_Resultflush2"
        Me.txtbx_Resultflush2.ReadOnly = True
        Me.txtbx_Resultflush2.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_Resultflush2.TabIndex = 60
        Me.txtbx_Resultflush2.TabStop = False
        Me.txtbx_Resultflush2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_ResultDPTest1
        '
        Me.dsp_ResultDPTest1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ResultDPTest1.Location = New System.Drawing.Point(352, 12)
        Me.dsp_ResultDPTest1.Name = "dsp_ResultDPTest1"
        Me.dsp_ResultDPTest1.Size = New System.Drawing.Size(150, 30)
        Me.dsp_ResultDPTest1.TabIndex = 57
        Me.dsp_ResultDPTest1.Text = "DP Test-1 Circuit :"
        Me.dsp_ResultDPTest1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_ResultDPTest1
        '
        Me.txtbx_ResultDPTest1.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_ResultDPTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_ResultDPTest1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_ResultDPTest1.Location = New System.Drawing.Point(522, 15)
        Me.txtbx_ResultDPTest1.Name = "txtbx_ResultDPTest1"
        Me.txtbx_ResultDPTest1.ReadOnly = True
        Me.txtbx_ResultDPTest1.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_ResultDPTest1.TabIndex = 58
        Me.txtbx_ResultDPTest1.TabStop = False
        Me.txtbx_ResultDPTest1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsp_Resultflush1
        '
        Me.dsp_Resultflush1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Resultflush1.Location = New System.Drawing.Point(50, 12)
        Me.dsp_Resultflush1.Name = "dsp_Resultflush1"
        Me.dsp_Resultflush1.Size = New System.Drawing.Size(150, 30)
        Me.dsp_Resultflush1.TabIndex = 55
        Me.dsp_Resultflush1.Text = "Flush-1 Circuit :"
        Me.dsp_Resultflush1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_Resultflush1
        '
        Me.txtbx_Resultflush1.BackColor = System.Drawing.SystemColors.Window
        Me.txtbx_Resultflush1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_Resultflush1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_Resultflush1.Location = New System.Drawing.Point(220, 15)
        Me.txtbx_Resultflush1.Name = "txtbx_Resultflush1"
        Me.txtbx_Resultflush1.ReadOnly = True
        Me.txtbx_Resultflush1.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_Resultflush1.TabIndex = 56
        Me.txtbx_Resultflush1.TabStop = False
        Me.txtbx_Resultflush1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgv_Resultsummary
        '
        Me.dgv_Resultsummary.AllowUserToAddRows = False
        Me.dgv_Resultsummary.AllowUserToDeleteRows = False
        Me.dgv_Resultsummary.AllowUserToResizeColumns = False
        Me.dgv_Resultsummary.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Resultsummary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_Resultsummary.ColumnHeadersHeight = 30
        Me.dgv_Resultsummary.Location = New System.Drawing.Point(50, 125)
        Me.dgv_Resultsummary.Name = "dgv_Resultsummary"
        Me.dgv_Resultsummary.ReadOnly = True
        Me.dgv_Resultsummary.Size = New System.Drawing.Size(1211, 640)
        Me.dgv_Resultsummary.TabIndex = 0
        Me.dgv_Resultsummary.TabStop = False
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
        Me.Label1.Text = "Test Detail"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormResultSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1001)
        Me.Controls.Add(Me.panel_FormControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1920, 1040)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1918, 1030)
        Me.Name = "FormResultSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Result Summary"
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
        CType(Me.dgv_Resultsummary, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtbx_ResultFlowrate As TextBox
    Friend WithEvents txtbx_ResultTemperature As TextBox
    Friend WithEvents txtbx_ResultCalOffset As TextBox
    Friend WithEvents dsp_ResultFlowrate As Label
    Friend WithEvents dsp_ResultTemperature As Label
    Friend WithEvents dsp_ResultCalOffset As Label
    Friend WithEvents dsp_ResultRecipeID As Label
    Friend WithEvents dsp_ResultConfirmation As Label
    Friend WithEvents dsp_ResultPartID As Label
    Friend WithEvents dsp_ResultWorkOrder As Label
    Friend WithEvents dsp_ResultTimestamp As Label
    Friend WithEvents txtbx_ResultRecipeID As TextBox
    Friend WithEvents txtbx_ResultConfirmation As TextBox
    Friend WithEvents txtbx_ResultPartID As TextBox
    Friend WithEvents txtbx_ResultWorkOrder As TextBox
    Friend WithEvents txtbx_ResultTimestamp As TextBox
    Friend WithEvents btn_ResultExport As Button
    Friend WithEvents btn_ResultSearch As Button
    Friend WithEvents txtbx_ResultTest As TextBox
    Friend WithEvents dsp_ResultTest As Label
    Friend WithEvents txtbx_ResultDiffPressure As TextBox
    Friend WithEvents dsp_ResultDiffPressure As Label
    Friend WithEvents txtbx_ResultOutletPressure As TextBox
    Friend WithEvents dsp_ResultOutletPressure As Label
    Friend WithEvents txtbx_ResultInletPressure As TextBox
    Friend WithEvents dsp_ResultInletPressure As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dsp_ResultSearchLot As Label
    Friend WithEvents dsp_Resultflush1 As Label
    Friend WithEvents txtbx_Resultflush1 As TextBox
    Friend WithEvents dgv_Resultsummary As DataGridView
    Friend WithEvents dsp_ResultDPTest2 As Label
    Friend WithEvents txtbx_ResultDPTest2 As TextBox
    Friend WithEvents dsp_Resultflush2 As Label
    Friend WithEvents txtbx_Resultflush2 As TextBox
    Friend WithEvents dsp_ResultDPTest1 As Label
    Friend WithEvents txtbx_ResultDPTest1 As TextBox
    Friend WithEvents dsp_ResultDrain3 As Label
    Friend WithEvents txtbx_ResultDrain3 As TextBox
    Friend WithEvents dsp_ResultDrain2 As Label
    Friend WithEvents txtbx_ResultDrain2 As TextBox
    Friend WithEvents dsp_ResultDrain1 As Label
    Friend WithEvents txtbx_ResultDrain1 As TextBox
    Friend WithEvents dsp_ResultSearchAttempt As Label
    Friend WithEvents cmbx_ResultSearchAttempt As ComboBox
    Friend WithEvents cmbx_ResultSearchLot As ComboBox
    Friend WithEvents cmbx_ResultSearchSerial As ComboBox
    Friend WithEvents dsp_ResultSearchSerial As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dsp_ResultSerialUID As Label
    Friend WithEvents txtbx_ResultSerialUID As TextBox
    Friend WithEvents dsp_Resultattempt As Label
    Friend WithEvents txtbx_Resultattempt As TextBox
    Friend WithEvents txtbx_ResultRecipeIDRev As TextBox
End Class
