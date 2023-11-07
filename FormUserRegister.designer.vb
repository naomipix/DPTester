<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUserRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUserRegister))
        Me.tab_UserReg = New System.Windows.Forms.TabControl()
        Me.tabpg_UserReg = New System.Windows.Forms.TabPage()
        Me.cmbx_RegCategory = New System.Windows.Forms.ComboBox()
        Me.dsplbl_RegCategory = New System.Windows.Forms.Label()
        Me.btn_RegPwdVisible = New System.Windows.Forms.Button()
        Me.dsplbl_RegPassword = New System.Windows.Forms.Label()
        Me.txtbox_RegPassword = New System.Windows.Forms.TextBox()
        Me.txtbox_RegUserName = New System.Windows.Forms.TextBox()
        Me.dsplbl_RegUserName = New System.Windows.Forms.Label()
        Me.picbox_UserRegister = New System.Windows.Forms.PictureBox()
        Me.btn_Register = New System.Windows.Forms.Button()
        Me.tabpg_UserDel = New System.Windows.Forms.TabPage()
        Me.cmbx_DelUserName = New System.Windows.Forms.ComboBox()
        Me.cmbx_DelCateory = New System.Windows.Forms.ComboBox()
        Me.dsplbl_DelCategory = New System.Windows.Forms.Label()
        Me.dsplbl_DelUserName = New System.Windows.Forms.Label()
        Me.picbox_UserDelete = New System.Windows.Forms.PictureBox()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.tab_UserReg.SuspendLayout()
        Me.tabpg_UserReg.SuspendLayout()
        CType(Me.picbox_UserRegister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpg_UserDel.SuspendLayout()
        CType(Me.picbox_UserDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tab_UserReg
        '
        Me.tab_UserReg.Controls.Add(Me.tabpg_UserReg)
        Me.tab_UserReg.Controls.Add(Me.tabpg_UserDel)
        Me.tab_UserReg.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_UserReg.ItemSize = New System.Drawing.Size(120, 40)
        Me.tab_UserReg.Location = New System.Drawing.Point(40, 20)
        Me.tab_UserReg.Multiline = True
        Me.tab_UserReg.Name = "tab_UserReg"
        Me.tab_UserReg.SelectedIndex = 0
        Me.tab_UserReg.Size = New System.Drawing.Size(700, 700)
        Me.tab_UserReg.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tab_UserReg.TabIndex = 0
        Me.tab_UserReg.TabStop = False
        '
        'tabpg_UserReg
        '
        Me.tabpg_UserReg.BackColor = System.Drawing.SystemColors.Control
        Me.tabpg_UserReg.Controls.Add(Me.cmbx_RegCategory)
        Me.tabpg_UserReg.Controls.Add(Me.dsplbl_RegCategory)
        Me.tabpg_UserReg.Controls.Add(Me.btn_RegPwdVisible)
        Me.tabpg_UserReg.Controls.Add(Me.dsplbl_RegPassword)
        Me.tabpg_UserReg.Controls.Add(Me.txtbox_RegPassword)
        Me.tabpg_UserReg.Controls.Add(Me.txtbox_RegUserName)
        Me.tabpg_UserReg.Controls.Add(Me.dsplbl_RegUserName)
        Me.tabpg_UserReg.Controls.Add(Me.picbox_UserRegister)
        Me.tabpg_UserReg.Controls.Add(Me.btn_Register)
        Me.tabpg_UserReg.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.tabpg_UserReg.Location = New System.Drawing.Point(4, 44)
        Me.tabpg_UserReg.Name = "tabpg_UserReg"
        Me.tabpg_UserReg.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpg_UserReg.Size = New System.Drawing.Size(692, 652)
        Me.tabpg_UserReg.TabIndex = 0
        Me.tabpg_UserReg.Text = "User Registration"
        '
        'cmbx_RegCategory
        '
        Me.cmbx_RegCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RegCategory.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RegCategory.FormattingEnabled = True
        Me.cmbx_RegCategory.Location = New System.Drawing.Point(233, 487)
        Me.cmbx_RegCategory.Name = "cmbx_RegCategory"
        Me.cmbx_RegCategory.Size = New System.Drawing.Size(300, 38)
        Me.cmbx_RegCategory.TabIndex = 24
        '
        'dsplbl_RegCategory
        '
        Me.dsplbl_RegCategory.AutoSize = True
        Me.dsplbl_RegCategory.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsplbl_RegCategory.Location = New System.Drawing.Point(116, 490)
        Me.dsplbl_RegCategory.Name = "dsplbl_RegCategory"
        Me.dsplbl_RegCategory.Size = New System.Drawing.Size(107, 30)
        Me.dsplbl_RegCategory.TabIndex = 23
        Me.dsplbl_RegCategory.Text = "Category :"
        '
        'btn_RegPwdVisible
        '
        Me.btn_RegPwdVisible.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_RegPwdVisible.BackgroundImage = CType(resources.GetObject("btn_RegPwdVisible.BackgroundImage"), System.Drawing.Image)
        Me.btn_RegPwdVisible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_RegPwdVisible.Location = New System.Drawing.Point(551, 420)
        Me.btn_RegPwdVisible.Name = "btn_RegPwdVisible"
        Me.btn_RegPwdVisible.Size = New System.Drawing.Size(45, 45)
        Me.btn_RegPwdVisible.TabIndex = 22
        Me.btn_RegPwdVisible.UseVisualStyleBackColor = False
        '
        'dsplbl_RegPassword
        '
        Me.dsplbl_RegPassword.AutoSize = True
        Me.dsplbl_RegPassword.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsplbl_RegPassword.Location = New System.Drawing.Point(113, 428)
        Me.dsplbl_RegPassword.Name = "dsplbl_RegPassword"
        Me.dsplbl_RegPassword.Size = New System.Drawing.Size(110, 30)
        Me.dsplbl_RegPassword.TabIndex = 20
        Me.dsplbl_RegPassword.Text = "Password :"
        '
        'txtbox_RegPassword
        '
        Me.txtbox_RegPassword.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_RegPassword.Location = New System.Drawing.Point(233, 425)
        Me.txtbox_RegPassword.MaxLength = 30
        Me.txtbox_RegPassword.Name = "txtbox_RegPassword"
        Me.txtbox_RegPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbox_RegPassword.Size = New System.Drawing.Size(300, 35)
        Me.txtbox_RegPassword.TabIndex = 19
        '
        'txtbox_RegUserName
        '
        Me.txtbox_RegUserName.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_RegUserName.Location = New System.Drawing.Point(233, 361)
        Me.txtbox_RegUserName.MaxLength = 30
        Me.txtbox_RegUserName.Name = "txtbox_RegUserName"
        Me.txtbox_RegUserName.Size = New System.Drawing.Size(300, 35)
        Me.txtbox_RegUserName.TabIndex = 18
        '
        'dsplbl_RegUserName
        '
        Me.dsplbl_RegUserName.AutoSize = True
        Me.dsplbl_RegUserName.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsplbl_RegUserName.Location = New System.Drawing.Point(96, 364)
        Me.dsplbl_RegUserName.Name = "dsplbl_RegUserName"
        Me.dsplbl_RegUserName.Size = New System.Drawing.Size(127, 30)
        Me.dsplbl_RegUserName.TabIndex = 17
        Me.dsplbl_RegUserName.Text = "User Name :"
        Me.dsplbl_RegUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picbox_UserRegister
        '
        Me.picbox_UserRegister.BackgroundImage = CType(resources.GetObject("picbox_UserRegister.BackgroundImage"), System.Drawing.Image)
        Me.picbox_UserRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picbox_UserRegister.Location = New System.Drawing.Point(196, 8)
        Me.picbox_UserRegister.Margin = New System.Windows.Forms.Padding(4)
        Me.picbox_UserRegister.Name = "picbox_UserRegister"
        Me.picbox_UserRegister.Size = New System.Drawing.Size(300, 300)
        Me.picbox_UserRegister.TabIndex = 16
        Me.picbox_UserRegister.TabStop = False
        '
        'btn_Register
        '
        Me.btn_Register.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Register.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Register.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_Register.Location = New System.Drawing.Point(271, 563)
        Me.btn_Register.Name = "btn_Register"
        Me.btn_Register.Size = New System.Drawing.Size(150, 75)
        Me.btn_Register.TabIndex = 31
        Me.btn_Register.Text = "Register"
        Me.btn_Register.UseVisualStyleBackColor = False
        '
        'tabpg_UserDel
        '
        Me.tabpg_UserDel.BackColor = System.Drawing.SystemColors.Control
        Me.tabpg_UserDel.Controls.Add(Me.cmbx_DelUserName)
        Me.tabpg_UserDel.Controls.Add(Me.cmbx_DelCateory)
        Me.tabpg_UserDel.Controls.Add(Me.dsplbl_DelCategory)
        Me.tabpg_UserDel.Controls.Add(Me.dsplbl_DelUserName)
        Me.tabpg_UserDel.Controls.Add(Me.picbox_UserDelete)
        Me.tabpg_UserDel.Controls.Add(Me.btn_Delete)
        Me.tabpg_UserDel.Location = New System.Drawing.Point(4, 44)
        Me.tabpg_UserDel.Name = "tabpg_UserDel"
        Me.tabpg_UserDel.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpg_UserDel.Size = New System.Drawing.Size(692, 652)
        Me.tabpg_UserDel.TabIndex = 1
        Me.tabpg_UserDel.Text = "User Deletion"
        '
        'cmbx_DelUserName
        '
        Me.cmbx_DelUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_DelUserName.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_DelUserName.FormattingEnabled = True
        Me.cmbx_DelUserName.Location = New System.Drawing.Point(233, 425)
        Me.cmbx_DelUserName.Name = "cmbx_DelUserName"
        Me.cmbx_DelUserName.Size = New System.Drawing.Size(298, 38)
        Me.cmbx_DelUserName.TabIndex = 25
        '
        'cmbx_DelCateory
        '
        Me.cmbx_DelCateory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_DelCateory.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_DelCateory.FormattingEnabled = True
        Me.cmbx_DelCateory.Location = New System.Drawing.Point(233, 361)
        Me.cmbx_DelCateory.Name = "cmbx_DelCateory"
        Me.cmbx_DelCateory.Size = New System.Drawing.Size(300, 38)
        Me.cmbx_DelCateory.TabIndex = 24
        '
        'dsplbl_DelCategory
        '
        Me.dsplbl_DelCategory.AutoSize = True
        Me.dsplbl_DelCategory.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsplbl_DelCategory.Location = New System.Drawing.Point(116, 364)
        Me.dsplbl_DelCategory.Name = "dsplbl_DelCategory"
        Me.dsplbl_DelCategory.Size = New System.Drawing.Size(107, 30)
        Me.dsplbl_DelCategory.TabIndex = 23
        Me.dsplbl_DelCategory.Text = "Category :"
        '
        'dsplbl_DelUserName
        '
        Me.dsplbl_DelUserName.AutoSize = True
        Me.dsplbl_DelUserName.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsplbl_DelUserName.Location = New System.Drawing.Point(96, 428)
        Me.dsplbl_DelUserName.Name = "dsplbl_DelUserName"
        Me.dsplbl_DelUserName.Size = New System.Drawing.Size(127, 30)
        Me.dsplbl_DelUserName.TabIndex = 17
        Me.dsplbl_DelUserName.Text = "User Name :"
        Me.dsplbl_DelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picbox_UserDelete
        '
        Me.picbox_UserDelete.BackgroundImage = CType(resources.GetObject("picbox_UserDelete.BackgroundImage"), System.Drawing.Image)
        Me.picbox_UserDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picbox_UserDelete.Location = New System.Drawing.Point(196, 8)
        Me.picbox_UserDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.picbox_UserDelete.Name = "picbox_UserDelete"
        Me.picbox_UserDelete.Size = New System.Drawing.Size(300, 300)
        Me.picbox_UserDelete.TabIndex = 16
        Me.picbox_UserDelete.TabStop = False
        '
        'btn_Delete
        '
        Me.btn_Delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Delete.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Delete.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_Delete.Location = New System.Drawing.Point(271, 563)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(150, 75)
        Me.btn_Delete.TabIndex = 32
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = False
        '
        'FormUserRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 761)
        Me.Controls.Add(Me.tab_UserReg)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUserRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "UserRegister"
        Me.tab_UserReg.ResumeLayout(False)
        Me.tabpg_UserReg.ResumeLayout(False)
        Me.tabpg_UserReg.PerformLayout()
        CType(Me.picbox_UserRegister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpg_UserDel.ResumeLayout(False)
        Me.tabpg_UserDel.PerformLayout()
        CType(Me.picbox_UserDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tab_UserReg As TabControl
    Friend WithEvents tabpg_UserReg As TabPage
    Friend WithEvents tabpg_UserDel As TabPage
    Friend WithEvents cmbx_RegCategory As ComboBox
    Friend WithEvents dsplbl_RegCategory As Label
    Friend WithEvents btn_RegPwdVisible As Button
    Friend WithEvents dsplbl_RegPassword As Label
    Friend WithEvents txtbox_RegPassword As TextBox
    Friend WithEvents txtbox_RegUserName As TextBox
    Friend WithEvents dsplbl_RegUserName As Label
    Friend WithEvents picbox_UserRegister As PictureBox
    Friend WithEvents cmbx_DelUserName As ComboBox
    Friend WithEvents cmbx_DelCateory As ComboBox
    Friend WithEvents dsplbl_DelCategory As Label
    Friend WithEvents dsplbl_DelUserName As Label
    Friend WithEvents picbox_UserDelete As PictureBox
    Friend WithEvents btn_Register As Button
    Friend WithEvents btn_Delete As Button
End Class
