<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUserLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUserLogin))
        Me.picbox_UserLogin = New System.Windows.Forms.PictureBox()
        Me.dsplbl_LogUserName = New System.Windows.Forms.Label()
        Me.txtbox_LogUserName = New System.Windows.Forms.TextBox()
        Me.txtbox_LogPassword = New System.Windows.Forms.TextBox()
        Me.dsplbl_LogPassword = New System.Windows.Forms.Label()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.btn_LogPwdVisible = New System.Windows.Forms.Button()
        CType(Me.picbox_UserLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picbox_UserLogin
        '
        Me.picbox_UserLogin.BackgroundImage = CType(resources.GetObject("picbox_UserLogin.BackgroundImage"), System.Drawing.Image)
        Me.picbox_UserLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picbox_UserLogin.Location = New System.Drawing.Point(250, 50)
        Me.picbox_UserLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.picbox_UserLogin.Name = "picbox_UserLogin"
        Me.picbox_UserLogin.Size = New System.Drawing.Size(300, 300)
        Me.picbox_UserLogin.TabIndex = 0
        Me.picbox_UserLogin.TabStop = False
        '
        'dsplbl_LogUserName
        '
        Me.dsplbl_LogUserName.AutoSize = True
        Me.dsplbl_LogUserName.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsplbl_LogUserName.Location = New System.Drawing.Point(159, 420)
        Me.dsplbl_LogUserName.Name = "dsplbl_LogUserName"
        Me.dsplbl_LogUserName.Size = New System.Drawing.Size(127, 30)
        Me.dsplbl_LogUserName.TabIndex = 1
        Me.dsplbl_LogUserName.Text = "User Name :"
        Me.dsplbl_LogUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbox_LogUserName
        '
        Me.txtbox_LogUserName.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_LogUserName.Location = New System.Drawing.Point(296, 418)
        Me.txtbox_LogUserName.MaxLength = 30
        Me.txtbox_LogUserName.Name = "txtbox_LogUserName"
        Me.txtbox_LogUserName.Size = New System.Drawing.Size(300, 35)
        Me.txtbox_LogUserName.TabIndex = 2
        '
        'txtbox_LogPassword
        '
        Me.txtbox_LogPassword.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_LogPassword.Location = New System.Drawing.Point(296, 482)
        Me.txtbox_LogPassword.MaxLength = 30
        Me.txtbox_LogPassword.Name = "txtbox_LogPassword"
        Me.txtbox_LogPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbox_LogPassword.Size = New System.Drawing.Size(300, 35)
        Me.txtbox_LogPassword.TabIndex = 3
        '
        'dsplbl_LogPassword
        '
        Me.dsplbl_LogPassword.AutoSize = True
        Me.dsplbl_LogPassword.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsplbl_LogPassword.Location = New System.Drawing.Point(176, 484)
        Me.dsplbl_LogPassword.Name = "dsplbl_LogPassword"
        Me.dsplbl_LogPassword.Size = New System.Drawing.Size(110, 30)
        Me.dsplbl_LogPassword.TabIndex = 4
        Me.dsplbl_LogPassword.Text = "Password :"
        '
        'btn_Login
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Login.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_Login.Location = New System.Drawing.Point(325, 630)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(150, 75)
        Me.btn_Login.TabIndex = 5
        Me.btn_Login.Text = "Log in"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'btn_LogPwdVisible
        '
        Me.btn_LogPwdVisible.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_LogPwdVisible.BackgroundImage = CType(resources.GetObject("btn_LogPwdVisible.BackgroundImage"), System.Drawing.Image)
        Me.btn_LogPwdVisible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_LogPwdVisible.Location = New System.Drawing.Point(614, 477)
        Me.btn_LogPwdVisible.Name = "btn_LogPwdVisible"
        Me.btn_LogPwdVisible.Size = New System.Drawing.Size(45, 45)
        Me.btn_LogPwdVisible.TabIndex = 4
        Me.btn_LogPwdVisible.UseVisualStyleBackColor = False
        '
        'FormUserLogin
        '
        Me.AcceptButton = Me.btn_Login
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 761)
        Me.Controls.Add(Me.btn_LogPwdVisible)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.dsplbl_LogPassword)
        Me.Controls.Add(Me.txtbox_LogPassword)
        Me.Controls.Add(Me.txtbox_LogUserName)
        Me.Controls.Add(Me.dsplbl_LogUserName)
        Me.Controls.Add(Me.picbox_UserLogin)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUserLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Login"
        CType(Me.picbox_UserLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picbox_UserLogin As PictureBox
    Friend WithEvents dsplbl_LogUserName As Label
    Friend WithEvents txtbox_LogUserName As TextBox
    Friend WithEvents txtbox_LogPassword As TextBox
    Friend WithEvents dsplbl_LogPassword As Label
    Friend WithEvents btn_Login As Button
    Friend WithEvents btn_LogPwdVisible As Button
End Class
