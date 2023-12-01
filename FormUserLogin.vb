'To use SQL commands the System.Data and System.Data.sqlclient need to be imported into the project
Imports System.ComponentModel
'Imports System.Data
'Imports System.Data.SqlClient

Public Class FormUserLogin

    Private Sub UserLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Initialize Defaults
        txtbox_LogUserName.Text = ""
        txtbox_LogPassword.Text = ""
    End Sub

    Private Sub UserLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear Selection
        Me.Select()

        ' Select First Textbox
        txtbox_LogUserName.Select()
    End Sub

    'Variable Declaration
    'Private Server1_Name As String
    'Private S1_Database1_Name As String
    'Private S1_DB1_UID As String
    'Private S1_DB1_Password As String
    'Private table1_name As String
    'Private table1_header1 As String
    'Private table1_header2 As String
    'Private table1_header3 As String
    'Private table1_header4 As String
    'Private table1_header5 As String
    'Private table2_name As String
    'Private table2_header1 As String
    'Private table2_header2 As String
    'Private table2_header3 As String
    'Private table2_header4 As String
    'Private table2_header5 As String
    'Dim b_userfound As Boolean
    'Public str_username As String
    'Private str_password As String
    'Private int_category As Integer
    'Public str_category As String
    'Dim sqlconn As SqlConnection
    'Public Logintimestamp As String


    'Private Sub UserLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    'This piece of code will intialize the elements of the User Login page on loading
    '    Page_initialize()
    '    UserTimer.Enabled = True

    'End Sub


    'Private Sub Page_initialize()
    '    'This is Settings for User Login Page
    '    txtbox_LogUserName.Text = ""
    '    txtbox_LogPassword.Text = ""
    '    txtbox_LogPassword.PasswordChar = "*"
    '    btn_LogPwdVisible.BackColor = Color.FromArgb(25, 130, 246)
    '    'Server1_Name = "LAPTOP-A1UORSBU\SQLEXPRESS"
    '    Server1_Name = "HP-LINWEI\SQLEXPRESS"
    '    S1_Database1_Name = "PX1529_DPTester"
    '    S1_DB1_UID = "px"
    '    S1_DB1_Password = "Pixel"
    '    table1_name = "UserRegistry"
    '    table1_header1 = "UserName"
    '    table1_header2 = "UserPassword"
    '    table1_header3 = "UserCategoryID"
    '    table1_header4 = ""
    '    table1_header5 = ""
    '    table2_name = "UserCategory"
    '    table2_header1 = "UserCategoryID"
    '    table2_header2 = "Description"
    '    table2_header3 = ""
    '    table2_header4 = ""
    '    table2_header5 = ""
    '    sqlconn = New SqlConnection("Data Source ='" & Server1_Name & "'; Initial Catalog = '" & S1_Database1_Name & "' ; User ID = '" & S1_DB1_UID & "' ; Password = '" & S1_DB1_Password & "'")

    'End Sub

    'Private Sub UserTimer_Tick(sender As Object, e As EventArgs) Handles UserTimer.Tick
    '    Logintimestamp = DateTime.Now.ToString("dd-MMM-yyyy   hh:mm:ss")
    'End Sub


    ''Message box creation
    'Private Sub Messagetxt(a As Integer)
    '    Select Case a
    '        Case 1
    '            MessageBox.Show("User Name field cannot be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Case 2
    '            MessageBox.Show("Password field cannot be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Case 3
    '            MessageBox.Show("Bad Credentials, Username and password not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Case 4
    '            MessageBox.Show("Wrong Password, try again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            txtbox_LogPassword.Text = ""
    '        Case 5
    '            MessageBox.Show(str_category + " " + str_username + " Log in Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.Close()
    '        Case 6
    '            MessageBox.Show(" Developer Log in Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.Close()
    '        Case 7
    '            MessageBox.Show("Developer Login failed, Wrong Password, try Camera Resolution unit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            txtbox_LogPassword.Text = ""
    '        Case Else
    '            Exit Select
    '    End Select
    'End Sub

    'Private Sub Checkuserregistry() 
    '    'This code will check whether username is available in the table 
    '    Try
    '        'Creating the connection string to search for username and password
    '        'Open SQL Connection
    '        Dim sqlcmd As SqlCommand = New SqlCommand("SELECT * FROM " & table1_name & " WHERE " & table1_header1 & "='" & txtbox_LogUserName.Text & "'", sqlconn)
    '        sqlconn.Open()
    '        Dim sqlreader As SqlDataReader = sqlcmd.ExecuteReader()
    '        'If any rows found with username, declare userfound
    '        If sqlreader.HasRows Then
    '            b_userfound = True
    '        Else
    '            b_userfound = False
    '        End If
    '    Catch ex As Exception
    '        If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '            Environment.Exit(1)
    '        Else
    '            Environment.Exit(1)
    '        End If
    '    Finally
    '        'Even in case of error the SQL connection should be closed
    '        sqlconn.Close()
    '    End Try
    'End Sub

    'Private Sub getuserregistry()
    '    'This code will get username, Password and Category ID available in the table 
    '    Try
    '        'Creating the connection string to search for username and password
    '        'Open SQL Connection
    '        'Creating the Data adapter, this act as a bridge between dataset and sql
    '        'Creating Dataset class which can store data in required format
    '        Dim sqlcmd As SqlCommand = New SqlCommand("SELECT * FROM " & table1_name & " WHERE " & table1_header1 & " ='" & txtbox_LogUserName.Text & "'", sqlconn)
    '        sqlconn.Open()
    '        Dim Sqlda As SqlDataAdapter = New SqlDataAdapter(sqlcmd)
    '        Dim sqlds As New DataSet()

    '        'This command will fill the dataset with table1 contents
    '        Sqlda.Fill(sqlds, table1_name)
    '        str_username = sqlds.Tables(table1_name).Rows(0).Item(table1_header1).ToString()
    '        str_password = sqlds.Tables(table1_name).Rows(0).Item(table1_header2).ToString()
    '        int_category = sqlds.Tables(table1_name).Rows(0).Item(table1_header3).ToString()
    '        sqlconn.Close()
    '        getusercategoryid(int_category)
    '    Catch ex As Exception
    '        If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '            Environment.Exit(1)
    '        Else
    '            Environment.Exit(1)
    '        End If
    '    Finally
    '        'Even in case of error the SQL connection should be closed
    '        sqlconn.Close()
    '    End Try

    'End Sub

    'Private Sub getusercategoryid(cat As Integer)
    '    'This code will get User Category Description with Category ID get from another table
    '    Try
    '        'Creating the connection string to search Category description based on Category ID
    '        'Open SQL Connection
    '        'Creating the Data adapter, this act as a bridge between dataset and sql
    '        'Creating Dataset class which can store data in required format
    '        Dim sqlcmd As SqlCommand = New SqlCommand("SELECT * FROM " & table2_name & " WHERE " & table2_header1 & "='" & cat & "' ", sqlconn)
    '        sqlconn.Open()
    '        Dim Sqlda As SqlDataAdapter = New SqlDataAdapter(sqlcmd)
    '        Dim sqlds As New DataSet()

    '        'This command will fill the dataset with table1 contents
    '        Sqlda.Fill(sqlds, table2_name)
    '        str_category = sqlds.Tables(table2_name).Rows(0).Item(table2_header2).ToString()
    '    Catch ex As Exception
    '        If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '            Environment.Exit(1)
    '        Else
    '            Environment.Exit(1)
    '        End If
    '    Finally
    '        'Even in case of error the SQL connection should be closed
    '        sqlconn.Close()
    '    End Try
    'End Sub


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

    'Private Sub btn_Login_Click(sender As Object, e As EventArgs) 'Handles btn_Login.Click
    '    'On Pressing the login button on the form, this window will check for user in SQL table by calling other routines
    '    Try
    '        If txtbox_LogUserName.Text <> "" Then
    '            If txtbox_LogPassword.Text <> "" Then
    '                If String.Compare(txtbox_LogUserName.Text, "Developer", True) = 0 Then
    '                    If txtbox_LogPassword.Text = "Pixel" Then
    '                        Messagetxt(6)
    '                        str_username = "Developer"
    '                        str_category = "DEVELOPER"
    '                    Else
    '                        Messagetxt(7)
    '                    End If
    '                Else
    '                    Checkuserregistry()
    '                    If Not b_userfound = True Then
    '                        Messagetxt(3)
    '                    Else
    '                        getuserregistry()
    '                        If str_password = txtbox_LogPassword.Text Then
    '                            Messagetxt(5)
    '                        Else
    '                            Messagetxt(4)
    '                        End If
    '                    End If
    '                End If
    '            Else
    '                Messagetxt(2)
    '            End If
    '        Else
    '            Messagetxt(1)
    '        End If
    '    Catch ex As Exception
    '        If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '            Environment.Exit(1)
    '        Else
    '            Environment.Exit(1)
    '        End If
    '    Finally
    '        'Even in case of error the SQL connection should be closed
    '        sqlconn.Close()
    '    End Try

    'End Sub

    'Private Sub UserLogin_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    '    txtbox_LogUserName.Text = ""
    '    txtbox_LogPassword.Text = ""
    '    UserTimer.Enabled = False
    'End Sub

    Private Sub btn_Login1_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        picbox_UserLogin.Select()
        Dim ReturnString As String = LoginModule.Authenticate(txtbox_LogUserName.Text, txtbox_LogPassword.Text)

        If ReturnString = "LoginSuccess" Or ReturnString = "LoginSuccessDeveloper" Then
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
            Case "LoginSuccess"
                LoginMessage.LoginPrompt(5, PublicVariables.LoginUserName, PublicVariables.LoginUserCategoryName)
            Case "LoginSuccessDeveloper"
                LoginMessage.LoginPrompt(6, 0, 0)
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
