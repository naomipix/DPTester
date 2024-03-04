'To use SQL commands the System.Data and System.Data.sqlclient need to be imported into the project
Imports System.ComponentModel
'Imports System.Data
'Imports System.Data.SqlClient

Public Class FormUserLogin

    Private Sub UserLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Initialize Defaults
        txtbox_LogUserName.Text = ""
        txtbox_LogPassword.Text = ""
        txtbox_LogPassword.PasswordChar = "*"
        btn_LogPwdVisible.BackColor = Color.FromArgb(25, 130, 246)
    End Sub

    Private Sub UserLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear Selection
        Me.Select()

        ' Select First Textbox
        txtbox_LogUserName.Select()
    End Sub


    Private Sub btn_LogPwdVisible_Click(sender As Object, e As EventArgs) Handles btn_LogPwdVisible.Click
        'The Below code is to toggle the password character on event of clicking the visible icon

        If btn_LogPwdVisible.BackColor = Color.FromArgb(25, 130, 246) Then
            btn_LogPwdVisible.BackColor = Color.FromArgb(0, 192, 0)
            txtbox_LogPassword.PasswordChar = Nothing
            txtbox_LogPassword.Focus()
        ElseIf btn_LogPwdVisible.BackColor = Color.FromArgb(0, 192, 0) Then

            btn_LogPwdVisible.BackColor = Color.FromArgb(25, 130, 246)
            txtbox_LogPassword.PasswordChar = "*"
            txtbox_LogPassword.Focus()
        End If
    End Sub



    Private Sub btn_Login1_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        picbox_UserLogin.Select()
        Dim ReturnString As String = LoginModule.Authenticate(txtbox_LogUserName.Text, txtbox_LogPassword.Text)

        If ReturnString = "LoginSuccess" Or ReturnString = "LoginSuccessDeveloper" Then
            Select Case ReturnString
                Case "LoginSuccess"
                    LoginMessage.LoginPrompt(5, PublicVariables.LoginUserName, PublicVariables.LoginUserCategoryName)
                Case "LoginSuccessDeveloper"
                    LoginMessage.LoginPrompt(6, 0, 0)
            End Select

            FormMain.lbl_Username.Text = PublicVariables.LoginUserName
            FormMain.lbl_Category.Text = PublicVariables.LoginUserCategoryName
            FormMainModule.ControlState(1)

            ' Login Event
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Login/Out] User ({PublicVariables.LoginUserName}/{PublicVariables.LoginUserCategoryName}) Logged In")

            Me.Close()
        End If

        ' Returns - EmptyField;EmptyUsername;EmptyPassword;DeveloperLoginFailed;LoginSuccess;LoginSuccessDeveloper;WrongPassword;UserDuplicate;UserNotFound;
        Select Case ReturnString
            Case "EmptyField"
                LoginMessage.LoginPrompt(1, 0, 0)
            Case "EmptyUsername"
                LoginMessage.LoginPrompt(1, 0, 0)
            Case "EmptyPassword"
                LoginMessage.LoginPrompt(2, 0, 0)
            Case "DeveloperLoginFailed"
                LoginMessage.LoginPrompt(7, 0, 0)
                txtbox_LogPassword.Text = ""
            'Case "LoginSuccess"
            '    LoginMessage.LoginPrompt(5, PublicVariables.LoginUserName, PublicVariables.LoginUserCategoryName)
            'Case "LoginSuccessDeveloper"
            '    LoginMessage.LoginPrompt(6, 0, 0)
            Case "WrongPassword"
                LoginMessage.LoginPrompt(4, 0, 0)
                txtbox_LogPassword.Text = ""
            Case "UserDuplicate"
                MsgBox(ReturnString)
            Case "UserNotFound"
                LoginMessage.LoginPrompt(3, 0, 0)
        End Select
    End Sub
End Class
