<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMessageLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMessageLog))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.panel_MessageLog = New System.Windows.Forms.Panel()
        Me.dgv_MessageLog = New System.Windows.Forms.DataGridView()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.btn_Reset = New System.Windows.Forms.Button()
        Me.grpbx_Filter = New System.Windows.Forms.GroupBox()
        Me.txtbx_Search = New System.Windows.Forms.TextBox()
        Me.dtpicker_EndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpicker_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.dsp_FilterStartDate = New System.Windows.Forms.Label()
        Me.dsp_FilterEndDate = New System.Windows.Forms.Label()
        Me.dsp_Search = New System.Windows.Forms.Label()
        Me.dsp_Home = New System.Windows.Forms.Label()
        Me.btn_Home = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.picbx_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_UserCategory.SuspendLayout()
        Me.panel_FormControl.SuspendLayout()
        Me.panel_MessageLog.SuspendLayout()
        CType(Me.dgv_MessageLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbx_Filter.SuspendLayout()
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
        Me.panel_UserCategory.TabIndex = 48
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
        Me.panel_FormControl.Controls.Add(Me.panel_MessageLog)
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
        'panel_MessageLog
        '
        Me.panel_MessageLog.Controls.Add(Me.dgv_MessageLog)
        Me.panel_MessageLog.Controls.Add(Me.btn_Search)
        Me.panel_MessageLog.Controls.Add(Me.btn_Reset)
        Me.panel_MessageLog.Controls.Add(Me.grpbx_Filter)
        Me.panel_MessageLog.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_MessageLog.Location = New System.Drawing.Point(12, 181)
        Me.panel_MessageLog.Name = "panel_MessageLog"
        Me.panel_MessageLog.Size = New System.Drawing.Size(1880, 808)
        Me.panel_MessageLog.TabIndex = 104
        '
        'dgv_MessageLog
        '
        Me.dgv_MessageLog.AllowUserToAddRows = False
        Me.dgv_MessageLog.AllowUserToDeleteRows = False
        Me.dgv_MessageLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_MessageLog.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_MessageLog.Location = New System.Drawing.Point(3, 89)
        Me.dgv_MessageLog.Name = "dgv_MessageLog"
        Me.dgv_MessageLog.ReadOnly = True
        Me.dgv_MessageLog.Size = New System.Drawing.Size(1874, 716)
        Me.dgv_MessageLog.TabIndex = 32
        Me.dgv_MessageLog.TabStop = False
        '
        'btn_Search
        '
        Me.btn_Search.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Search.Location = New System.Drawing.Point(948, 24)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(100, 45)
        Me.btn_Search.TabIndex = 31
        Me.btn_Search.Text = "Search"
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'btn_Reset
        '
        Me.btn_Reset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Reset.Location = New System.Drawing.Point(832, 24)
        Me.btn_Reset.Name = "btn_Reset"
        Me.btn_Reset.Size = New System.Drawing.Size(100, 45)
        Me.btn_Reset.TabIndex = 30
        Me.btn_Reset.Text = "Reset"
        Me.btn_Reset.UseVisualStyleBackColor = True
        '
        'grpbx_Filter
        '
        Me.grpbx_Filter.Controls.Add(Me.txtbx_Search)
        Me.grpbx_Filter.Controls.Add(Me.dtpicker_EndDate)
        Me.grpbx_Filter.Controls.Add(Me.dtpicker_StartDate)
        Me.grpbx_Filter.Controls.Add(Me.dsp_FilterStartDate)
        Me.grpbx_Filter.Controls.Add(Me.dsp_FilterEndDate)
        Me.grpbx_Filter.Controls.Add(Me.dsp_Search)
        Me.grpbx_Filter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpbx_Filter.Location = New System.Drawing.Point(3, 3)
        Me.grpbx_Filter.Name = "grpbx_Filter"
        Me.grpbx_Filter.Size = New System.Drawing.Size(800, 80)
        Me.grpbx_Filter.TabIndex = 2
        Me.grpbx_Filter.TabStop = False
        Me.grpbx_Filter.Text = "Filter"
        '
        'txtbx_Search
        '
        Me.txtbx_Search.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_Search.ForeColor = System.Drawing.Color.Gray
        Me.txtbx_Search.Location = New System.Drawing.Point(15, 41)
        Me.txtbx_Search.MaxLength = 30
        Me.txtbx_Search.Name = "txtbx_Search"
        Me.txtbx_Search.Size = New System.Drawing.Size(406, 25)
        Me.txtbx_Search.TabIndex = 23
        Me.txtbx_Search.Text = " User Category / Message"
        '
        'dtpicker_EndDate
        '
        Me.dtpicker_EndDate.CustomFormat = " dd MMMM yyyy"
        Me.dtpicker_EndDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpicker_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpicker_EndDate.Location = New System.Drawing.Point(623, 41)
        Me.dtpicker_EndDate.Name = "dtpicker_EndDate"
        Me.dtpicker_EndDate.Size = New System.Drawing.Size(160, 25)
        Me.dtpicker_EndDate.TabIndex = 31
        '
        'dtpicker_StartDate
        '
        Me.dtpicker_StartDate.CustomFormat = " dd MMMM yyyy"
        Me.dtpicker_StartDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpicker_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpicker_StartDate.Location = New System.Drawing.Point(442, 41)
        Me.dtpicker_StartDate.Name = "dtpicker_StartDate"
        Me.dtpicker_StartDate.Size = New System.Drawing.Size(160, 25)
        Me.dtpicker_StartDate.TabIndex = 30
        '
        'dsp_FilterStartDate
        '
        Me.dsp_FilterStartDate.AutoSize = True
        Me.dsp_FilterStartDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_FilterStartDate.Location = New System.Drawing.Point(439, 21)
        Me.dsp_FilterStartDate.Name = "dsp_FilterStartDate"
        Me.dsp_FilterStartDate.Size = New System.Drawing.Size(73, 17)
        Me.dsp_FilterStartDate.TabIndex = 28
        Me.dsp_FilterStartDate.Text = "Start Date :"
        '
        'dsp_FilterEndDate
        '
        Me.dsp_FilterEndDate.AutoSize = True
        Me.dsp_FilterEndDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_FilterEndDate.Location = New System.Drawing.Point(620, 21)
        Me.dsp_FilterEndDate.Name = "dsp_FilterEndDate"
        Me.dsp_FilterEndDate.Size = New System.Drawing.Size(68, 17)
        Me.dsp_FilterEndDate.TabIndex = 29
        Me.dsp_FilterEndDate.Text = "End Date :"
        '
        'dsp_Search
        '
        Me.dsp_Search.AutoSize = True
        Me.dsp_Search.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Search.Location = New System.Drawing.Point(12, 21)
        Me.dsp_Search.Name = "dsp_Search"
        Me.dsp_Search.Size = New System.Drawing.Size(54, 17)
        Me.dsp_Search.TabIndex = 9
        Me.dsp_Search.Text = "Search :"
        '
        'dsp_Home
        '
        Me.dsp_Home.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Home.Location = New System.Drawing.Point(1696, 65)
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
        Me.btn_Home.Location = New System.Drawing.Point(1696, 93)
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
        Me.Label1.Text = "Event Log"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormMessageLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1001)
        Me.Controls.Add(Me.panel_FormControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1920, 1040)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1918, 1030)
        Me.Name = "FormMessageLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Event Log"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.picbx_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_UserCategory.ResumeLayout(False)
        Me.panel_UserCategory.PerformLayout()
        Me.panel_FormControl.ResumeLayout(False)
        Me.panel_MessageLog.ResumeLayout(False)
        CType(Me.dgv_MessageLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbx_Filter.ResumeLayout(False)
        Me.grpbx_Filter.PerformLayout()
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
    Friend WithEvents panel_MessageLog As Panel
    Friend WithEvents grpbx_Filter As GroupBox
    Friend WithEvents txtbx_Search As TextBox
    Friend WithEvents dtpicker_EndDate As DateTimePicker
    Friend WithEvents dtpicker_StartDate As DateTimePicker
    Friend WithEvents dsp_FilterStartDate As Label
    Friend WithEvents dsp_FilterEndDate As Label
    Friend WithEvents dsp_Search As Label
    Friend WithEvents btn_Search As Button
    Friend WithEvents btn_Reset As Button
    Friend WithEvents dgv_MessageLog As DataGridView
End Class
