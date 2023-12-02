''To use SQL commands the System.Data and System.Data.sqlclient need to be imported into the project
'Imports System.ComponentModel
'Imports System.Data
'Imports System.Data.SqlClient

Imports System.ComponentModel
Public Class FormUserRegister

    Private Sub FormUserRegister_Load(sender As Object, e As EventArgs) Handles Me.Load
        Initialize()
    End Sub

    Private Sub Initialize()
        ' Load Default TabControls
        tab_UserReg.TabPages.Clear()
        For Each tabpg As TabPage In {tabpg_UserReg, tabpg_UserDel}
            tab_UserReg.TabPages.Add(tabpg)
        Next
        tab_UserReg.SelectedTab = tabpg_UserReg

        ' Initialize Text Box
        txtbox_RegPassword.Text = ""
        txtbox_RegUserName.Text = ""

        ' Load Category List
        GetUserCategory()

        ' Assign Default Value
        GetUserName(True)
    End Sub

    Private Sub FormUserRegister_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear Selection
        Me.Select()

        ' Select First Textbox
        txtbox_RegUserName.Select()
    End Sub

    Private Sub GetUserCategory()
        Dim comboSource As New Dictionary(Of String, String)()

        ' To Get Values From Dictionary (Example)
        'DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key | Value

        ' Assign Defaults
        comboSource.Add("0", "-Not Selected-")

        ' Get User Category Table
        Dim dtUserCategory As New DataTable
        If LoginUserCategoryName = "DEVELOPER" Or LoginUserCategoryName = "Administrator" Then
            dtUserCategory = SQL.ReadRecords("SELECT id, description FROM UserCategory")
        Else
            dtUserCategory = SQL.ReadRecords("SELECT id, description FROM UserCategory WHERE NOT description='Administrator'")
        End If

        ' Insert Available Record Into Dictionary
        If dtUserCategory.Rows.Count > 0 Then
            For i As Integer = 0 To dtUserCategory.Rows.Count - 1
                comboSource.Add(dtUserCategory(i)("id"), dtUserCategory(i)("description"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each cmbx As ComboBox In {cmbx_RegCategory, cmbx_DelCateory}
            With cmbx
                .DataSource = New BindingSource(comboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next
    End Sub

    Private Sub GetUserName(Init As Boolean)
        Dim comboSource As New Dictionary(Of String, String)()

        ' To Get Values From Dictionary (Example)
        'DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key | Value

        ' Assign Defaults
        comboSource.Add("0", "-Not Selected-")

        ' Execute If Not For Initialize
        If Init = False Then
            ' Get User Category Table
            Dim CurrentUserID As Integer = PublicVariables.LoginUserID
            Dim UserCategoryID As Integer = DirectCast(cmbx_DelCateory.SelectedItem, KeyValuePair(Of String, String)).Key

            Dim dtUserCategory As DataTable = SQL.ReadRecords($"SELECT id, user_name FROM UserAccount WHERE user_category_id='{UserCategoryID}' AND NOT id='{CurrentUserID}'")

            ' Insert Available Record Into Dictionary
            If dtUserCategory.Rows.Count > 0 Then
                For i As Integer = 0 To dtUserCategory.Rows.Count - 1
                    comboSource.Add(dtUserCategory(i)("id"), dtUserCategory(i)("user_name"))
                Next
            End If
        End If

        ' Bind ComboBox To Dictionary
        For Each cmbx As ComboBox In {cmbx_DelUserName}
            With cmbx
                .DataSource = New BindingSource(comboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next
    End Sub

    Private Sub cmbx_DelCateory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_DelCateory.SelectedIndexChanged
        If cmbx_DelCateory.SelectedIndex > 0 Then
            GetUserName(False)
            cmbx_DelUserName.Enabled = True
        Else
            With cmbx_DelUserName
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
                .Enabled = False
            End With
        End If
    End Sub

    Private Sub btn_Register_Click(sender As Object, e As EventArgs) Handles btn_Register.Click
        Me.Select()

        Dim RegUserName As String = txtbox_RegUserName.Text
        Dim RegUserPassword As String = txtbox_RegPassword.Text
        Dim RegUserCategoryID As String = DirectCast(cmbx_RegCategory.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim RegUserCategoryName As String = DirectCast(cmbx_RegCategory.SelectedItem, KeyValuePair(Of String, String)).Value

        Dim ReturnString As String = UserRegistration.Insert(RegUserName, RegUserPassword, cmbx_RegCategory)

        ' Returns - EmptyField;EmptyUsername;EmptyPassword;EmptyUserCategory;Developer;UserNameFound;Success;
        Select Case ReturnString
            Case "EmptyField"
                LoginMessage.RegistrationPrompt(1, 0, 0)
            Case "EmptyUsername"
                LoginMessage.RegistrationPrompt(1, 0, 0)
            Case "EmptyPassword"
                LoginMessage.RegistrationPrompt(2, 0, 0)
            Case "EmptyUserCategory"
                LoginMessage.RegistrationPrompt(3, 0, 0)
            Case "Developer"
                LoginMessage.RegistrationPrompt(9, 0, 0)
            Case "UserNameFound"
                LoginMessage.RegistrationPrompt(7, 0, 0)
            Case "Success"
                LoginMessage.RegistrationPrompt(5, RegUserName.Trim, RegUserCategoryName)
                Initialize()
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[User Registration] User Registration - User ({RegUserName}/{RegUserCategoryName}) Registered")
        End Select
    End Sub


    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        Me.Select()

        Dim UserCategoryName As String = DirectCast(cmbx_DelCateory.SelectedItem, KeyValuePair(Of String, String)).Value
        Dim UserName As String = DirectCast(cmbx_DelUserName.SelectedItem, KeyValuePair(Of String, String)).Value

        Dim ReturnString As String = UserRegistration.Delete(cmbx_DelCateory, cmbx_DelUserName)

        ' Returns - EmptyField;EmptyCategory;EmptyUser;Success;RecordFound;
        Select Case ReturnString
            Case "EmptyField"
                LoginMessage.RegistrationPrompt(3, 0, 0)
            Case "EmptyCategory"
                LoginMessage.RegistrationPrompt(3, 0, 0)
            Case "EmptyUser"
                LoginMessage.RegistrationPrompt(1, 0, 0)
            Case "Success"
                LoginMessage.RegistrationPrompt(6, UserName, UserCategoryName)
                Initialize()
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[User Registration] User Deletion - User ({UserName}/{UserCategoryName}) Deleted")
            Case "RecordFound"
                LoginMessage.RegistrationPrompt(11, 0, 0)
        End Select
    End Sub


    '    'Variable Declaration
    '    Private Server1_Name As String
    '    Private S1_Database1_Name As String
    '    Private S1_DB1_UID As String
    '    Private S1_DB1_Password As String
    '    Private table1_name As String
    '    Private table1_header1 As String
    '    Private table1_header2 As String
    '    Private table1_header3 As String
    '    Private table1_header4 As String
    '    Private table1_header5 As String
    '    Private table2_name As String
    '    Private table2_header1 As String
    '    Private table2_header2 As String
    '    Private table2_header3 As String
    '    Private table2_header4 As String
    '    Private table2_header5 As String
    '    Dim b_userfound As Boolean
    '    Private str_Regusername As String
    '    Private str_Regpassword As String
    '    Private int_Regcategory As Integer
    '    Private str_Regcategory As String
    '    Private str_Delcategory As String
    '    Private str_Delusername As String
    '    Dim sqlconn As SqlConnection
    '    Public Registertimestamp As String


    '    'The Below code will call functions mentioned below on loading the UserLogin Form
    '    Private Sub UserRegiser_Load(sender As Object, e As EventArgs) Handles Me.Load
    '        Page_initialize()
    '        RegisterTimer.Enabled = True
    '    End Sub

    '    'The Below code is to initialize the settings required on loading the form
    '    Private Sub Page_initialize()
    '        txtbox_RegUserName.Text = ""
    '        txtbox_RegPassword.Text = ""
    '        str_Regcategory = ""
    '        str_Regusername = ""
    '        str_Regpassword = ""
    '        str_Delusername = ""
    '        str_Delcategory = ""
    '        cmbx_RegCategory.Items.Clear()
    '        cmbx_DelCateory.Items.Clear()
    '        cmbx_DelUserName.Items.Clear()
    '        txtbox_RegPassword.PasswordChar = "*"
    '        btn_RegPwdVisible.BackColor = Color.FromArgb(25, 130, 246)
    '        Server1_Name = "LAPTOP-A1UORSBU\SQLEXPRESS"
    '        S1_Database1_Name = "PX1529_DPTester"
    '        S1_DB1_UID = "px"
    '        S1_DB1_Password = "Pixel"
    '        table1_name = "UserRegistry"
    '        table1_header1 = "UserName"
    '        table1_header2 = "UserPassword"
    '        table1_header3 = "UserCategoryID"
    '        table1_header4 = "Creationdate"
    '        table1_header5 = "Createdby"
    '        table2_name = "UserCategory"
    '        table2_header1 = "UserCategoryID"
    '        table2_header2 = "Description"
    '        table2_header3 = ""
    '        table2_header4 = ""
    '        table2_header5 = ""
    '        sqlconn = New SqlConnection("Data Source ='" & Server1_Name & "'; Initial Catalog = '" & S1_Database1_Name & "' ; User ID = '" & S1_DB1_UID & "' ; Password = '" & S1_DB1_Password & "'")
    '        drop_userCategory()
    '    End Sub

    '    Private Sub RegisterTimer_Tick(sender As Object, e As EventArgs) Handles RegisterTimer.Tick
    '        Registertimestamp = DateTime.Now.ToString("dd-MMM-yyyy   hh:mm:ss")
    '    End Sub

    '    'Message box creation
    '    Private Sub Messagetxt(a As Integer)
    '        Select Case a
    '            Case 1
    '                MessageBox.Show("User Name field cannot be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Case 2
    '                MessageBox.Show("Password field cannot be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Case 3
    '                MessageBox.Show("Category field cannot be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Case 4
    '                MessageBox.Show("User not found under selected Category, try again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            Case 5
    '                MessageBox.Show(str_Regcategory + " " + str_Regusername + " Registration Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.Close()
    '            Case 6
    '                MessageBox.Show(str_Delcategory + " " + str_Delusername + " Deletion Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.Close()
    '            Case 7
    '                MessageBox.Show("Username Already exists, Registration Fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.Close()
    '            Case 8
    '                MessageBox.Show("Administrator/Engineer Log in required to Register/Delete User", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.Close()
    '            Case 9
    '                MessageBox.Show("Username 'Developer' Cannot be created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.Close()
    '            Case 10
    '                MessageBox.Show("Query execution not successful, User Registration Failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.Close()
    '            Case 11
    '                MessageBox.Show("Query execution not successful, User Deletion Failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.Close()
    '            Case Else
    '                Exit Select
    '        End Select
    '    End Sub

    '    Private Sub drop_userCategory()
    '        'This code will get User Category Description and place it in the combo box
    '        Try
    '            'Creating the connection string to search Category description based on Category ID
    '            'Open SQL Connection
    '            'Creating the Data adapter, this act as a bridge between dataset and sql
    '            'Creating Dataset class which can store data in required format
    '            Dim sqlcmd As SqlCommand = New SqlCommand("SELECT " & table2_header2 & " FROM " & table2_name, sqlconn)
    '            sqlconn.Open()
    '            Dim Sqlda As SqlDataAdapter = New SqlDataAdapter(sqlcmd)
    '            Dim sqlds As New DataSet()
    '            Dim sqldt As New DataTable
    '            Dim x As Integer
    '            'This command will fill the dataset with table1 contents
    '            Sqlda.Fill(sqlds, table2_header2)
    '            sqldt = sqlds.Tables(table2_header2)
    '            For x = 0 To sqldt.Rows.Count - 1
    '                cmbx_RegCategory.Items.Add(sqldt.Rows(x).Item(table2_header2))
    '                cmbx_DelCateory.Items.Add(sqldt.Rows(x).Item(table2_header2))
    '            Next
    '            sqlconn.Close()

    '        Catch ex As Exception
    '            If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '                Environment.Exit(1)
    '            Else
    '                Environment.Exit(1)
    '            End If
    '        Finally
    '            'Even in case of error the SQL connection should be closed
    '            sqlconn.Close()
    '        End Try
    '    End Sub

    '    Private Sub drop_username()
    '        'This code will get User Category Description and place it in the combo box
    '        Try
    '            getusercategory(cmbx_DelCateory.Text)

    '            'Creating the connection string to search Category description based on Category ID
    '            'Open SQL Connection
    '            'Creating the Data adapter, this act as a bridge between dataset and sql
    '            'Creating Dataset class which can store data in required format
    '            Dim sqlcmd As SqlCommand = New SqlCommand("SELECT * FROM " & table1_name & " WHERE " & table1_header3 & "='" & int_Regcategory & "'", sqlconn)
    '            sqlconn.Open()
    '            Dim Sqlda As SqlDataAdapter = New SqlDataAdapter(sqlcmd)
    '            Dim sqlds As New DataSet()
    '            Dim sqldt As New DataTable
    '            Dim x As Integer
    '            'This command will fill the dataset with table1 contents
    '            Sqlda.Fill(sqlds, table1_header1)
    '            sqldt = sqlds.Tables(table1_header1)
    '            If sqldt.Rows.Count = 0 Then
    '                Messagetxt(4)
    '            Else
    '                For x = 0 To sqldt.Rows.Count - 1
    '                    cmbx_DelUserName.Items.Add(sqldt.Rows(x).Item(table1_header1))

    '                Next
    '            End If

    '            sqlconn.Close()

    '        Catch ex As Exception
    '            If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '                Environment.Exit(1)
    '            Else
    '                Environment.Exit(1)
    '            End If
    '        Finally
    '            'Even in case of error the SQL connection should be closed
    '            sqlconn.Close()
    '        End Try
    '    End Sub

    '    Private Sub Checkuserregistry()
    '        'This code will check whether username is available in the table 
    '        Try
    '            'Creating the connection string to search for username and password
    '            'Open SQL Connection
    '            Dim sqlcmd As SqlCommand = New SqlCommand("SELECT * FROM " & table1_name & " WHERE " & table1_header1 & "='" & txtbox_RegUserName.Text & "'", sqlconn)
    '            sqlconn.Open()
    '            Dim sqlreader As SqlDataReader = sqlcmd.ExecuteReader()
    '            'If any rows found with username, declare userfound
    '            If sqlreader.HasRows Then
    '                b_userfound = True
    '            Else
    '                b_userfound = False
    '            End If
    '        Catch ex As Exception
    '            If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '                Environment.Exit(1)
    '            Else
    '                Environment.Exit(1)
    '            End If
    '        Finally
    '            'Even in case of error the SQL connection should be closed
    '            sqlconn.Close()
    '        End Try
    '    End Sub

    '    Private Sub getusercategory(cat As String)
    '        'This code will get User Category ID with Category Description get from another table
    '        Try
    '            'Creating the connection string to search Category description based on Category ID
    '            'Open SQL Connection
    '            'Creating the Data adapter, this act as a bridge between dataset and sql
    '            'Creating Dataset class which can store data in required format
    '            Dim sqlcmd As SqlCommand = New SqlCommand("SELECT * FROM " & table2_name & " WHERE " & table2_header2 & "='" & cat & "' ", sqlconn)
    '            sqlconn.Open()
    '            Dim Sqlda As SqlDataAdapter = New SqlDataAdapter(sqlcmd)
    '            Dim sqlds As New DataSet()

    '            'This command will fill the dataset with table1 contents
    '            Sqlda.Fill(sqlds, table2_name)
    '            int_Regcategory = CInt(sqlds.Tables(table2_name).Rows(0).Item(table2_header1))
    '        Catch ex As Exception
    '            If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '                Environment.Exit(1)
    '            Else
    '                Environment.Exit(1)
    '            End If
    '        Finally
    '            'Even in case of error the SQL connection should be closed
    '            sqlconn.Close()
    '        End Try
    '    End Sub



    '    Private Sub RegisterUser(name As String, password As String, cat As Integer)
    '        'This code will register user into the User registry
    '        Try
    '            'Creating the connection string to insert data into the table
    '            'Open SQL Connection
    '            'Execute query
    '            'Close SQL Connection
    '            Dim sqlcmd As SqlCommand = New SqlCommand("INSERT INTO " & table1_name & " (" & table1_header1 & "," & table1_header2 & "," & table1_header3 & "," & table1_header4 & "," & table1_header5 & ") VALUES('" & name & "', '" & password & "', '" & cat & "','" & Registertimestamp & "', '" & FormUserLogin.str_username & "')", sqlconn)
    '            sqlconn.Open()

    '            If sqlcmd.ExecuteNonQuery() = 1 Then
    '                Messagetxt(5)
    '            Else
    '                Messagetxt(10)
    '            End If
    '            sqlconn.Close()

    '        Catch ex As Exception
    '            If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '                Environment.Exit(1)
    '            Else
    '                Environment.Exit(1)
    '            End If
    '        Finally
    '            'Even in case of error the SQL connection should be closed
    '            sqlconn.Close()
    '        End Try
    '    End Sub

    '    Private Sub DeleteUser(name As String)
    '        'This code will register user into the User registry
    '        Try
    '            'Creating the connection string to insert data into the table
    '            'Open SQL Connection
    '            'Execute query
    '            'Close SQL Connection
    '            Dim sqlcmd As SqlCommand = New SqlCommand("DELETE FROM " & table1_name & " WHERE " & table1_header1 & " = '" & str_Delusername & "'", sqlconn)
    '            sqlconn.Open()
    '            If sqlcmd.ExecuteNonQuery() = 1 Then
    '                Messagetxt(6)
    '            Else
    '                Messagetxt(11)
    '            End If
    '            sqlconn.Close()

    '        Catch ex As Exception
    '            If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '                Environment.Exit(1)
    '            Else
    '                Environment.Exit(1)
    '            End If
    '        Finally
    '            'Even in case of error the SQL connection should be closed
    '            sqlconn.Close()
    '        End Try
    '    End Sub



    Private Sub btn_RegPwdVisible_Click(sender As Object, e As EventArgs) Handles btn_RegPwdVisible.Click
        'The Below code is to toggle the password character on event of clicking the visible icon
        If btn_RegPwdVisible.BackColor = Color.FromArgb(25, 130, 246) Then

            btn_RegPwdVisible.BackColor = Color.FromArgb(0, 192, 0)
            txtbox_RegPassword.PasswordChar = Nothing
            txtbox_RegPassword.Focus()
        ElseIf btn_RegPwdVisible.BackColor = Color.FromArgb(0, 192, 0) Then

            btn_RegPwdVisible.BackColor = Color.FromArgb(25, 130, 246)
            txtbox_RegPassword.PasswordChar = "*"
            txtbox_RegPassword.Focus()
        End If
    End Sub

    Private Sub txtbox_RegUserName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbox_RegUserName.KeyPress
        ' Check if the pressed key is a control key (Ctrl, Alt, Shift, etc.)
        If Char.IsControl(e.KeyChar) Then
            ' Allow specific control functions (Ctrl+A, Ctrl+C, Ctrl+V, Ctrl+Z, Backspace)
            If e.KeyChar = ChrW(1) Or e.KeyChar = ChrW(3) Or e.KeyChar = ChrW(22) Or e.KeyChar = ChrW(26) Or e.KeyChar = ChrW(8) Then

                e.Handled = False ' Allow the key press
            Else
                e.Handled = True ' Ignore other control keys
            End If
        Else
            ' Allow only alphabetic characters
            If Not Char.IsLetter(e.KeyChar) Then
                e.Handled = True ' Ignore non-alphabetic characters
            End If
        End If
    End Sub

    Private Sub txtbox_RegUserName_TextChanged(sender As Object, e As EventArgs) Handles txtbox_RegUserName.TextChanged
        Dim preCleanCount As Integer = txtbox_RegUserName.TextLength
        Dim cleanedText As String = ""

        For Each c As Char In txtbox_RegUserName.Text
            If Char.IsLetter(c) Then
                cleanedText += c
            End If
        Next

        Dim selectionStart As Integer = txtbox_RegUserName.SelectionStart
        Dim selectionOffset As Integer = preCleanCount - selectionStart
        txtbox_RegUserName.Text = cleanedText
        txtbox_RegUserName.SelectionStart = Math.Min(selectionStart, txtbox_RegUserName.TextLength - selectionOffset)
    End Sub


    '    Private Sub cmbx_DelCateory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_DelCateory.SelectedIndexChanged
    '        ' This Code will load the username based on the caategory selected
    '        cmbx_DelUserName.ResetText()
    '        cmbx_DelUserName.Items.Clear()
    '        str_Delcategory = cmbx_DelCateory.Text
    '        drop_username()
    '    End Sub



    '    Private Sub btn_Register_Click(sender As Object, e As EventArgs) Handles btn_Register.Click
    '        'On Pressing the Register button on the form, this window will check for user in SQL table by calling other routines
    '        Try
    '            If String.Compare(FormUserLogin.str_category, "Administrator", True) = 0 Or String.Compare(FormUserLogin.str_category, "Engineer", True) = 0 Then
    '                If txtbox_RegUserName.Text <> "" Then
    '                    If txtbox_RegPassword.Text <> "" Then
    '                        If cmbx_RegCategory.Text <> "" Then
    '                            If String.Compare(txtbox_RegUserName.Text, "Developer", True) = 0 Then
    '                                Messagetxt(9)
    '                            Else
    '                                Checkuserregistry()
    '                                If b_userfound Then
    '                                    Messagetxt(7)
    '                                    txtbox_RegUserName.Text = ""
    '                                Else
    '                                    str_Regcategory = cmbx_RegCategory.Text
    '                                    getusercategory(str_Regcategory)
    '                                    str_Regusername = txtbox_RegUserName.Text
    '                                    str_Regpassword = txtbox_RegPassword.Text
    '                                    RegisterUser(str_Regusername, str_Regpassword, int_Regcategory)

    '                                End If
    '                            End If
    '                        Else
    '                            Messagetxt(3)
    '                        End If
    '                    Else
    '                        Messagetxt(2)
    '                    End If
    '                Else
    '                    Messagetxt(1)
    '                End If
    '            Else
    '                Messagetxt(8)
    '            End If
    '        Catch ex As Exception
    '            If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '                Environment.Exit(1)
    '            Else
    '                Environment.Exit(1)
    '            End If
    '        Finally
    '            'Even in case of error the SQL connection should be closed
    '            sqlconn.Close()
    '        End Try
    '    End Sub



    '    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
    '        'On Pressing the delete button on the form, this window will check for user in SQL table by calling other routines
    '        Try
    '            If String.Compare(FormUserLogin.str_category, "Administrator", True) = 0 Or String.Compare(FormUserLogin.str_category, "Engineer", True) = 0 Then
    '                If cmbx_DelCateory.Text <> "" Then
    '                    If cmbx_DelUserName.Text <> "" Then
    '                        str_Delusername = cmbx_DelUserName.Text
    '                        DeleteUser(str_Delusername)
    '                    Else
    '                        Messagetxt(1)
    '                    End If
    '                Else
    '                    Messagetxt(3)
    '                End If
    '            Else
    '                Messagetxt(8)
    '            End If

    '        Catch ex As Exception
    '            If MsgBox(ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '                Environment.Exit(1)
    '            Else
    '                Environment.Exit(1)
    '            End If
    '        Finally
    '            'Even in case of error the SQL connection should be closed
    '            sqlconn.Close()
    '        End Try
    '    End Sub


    '    Private Sub tab_UserReg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tab_UserReg.SelectedIndexChanged
    '        'This Code is to clear the text fields in case of changing the tab screen
    '        txtbox_RegUserName.Text = ""
    '        txtbox_RegPassword.Text = ""
    '        cmbx_RegCategory.ResetText()
    '        cmbx_DelCateory.ResetText()
    '        cmbx_DelUserName.ResetText()
    '        cmbx_RegCategory.Items.Clear()
    '        cmbx_DelCateory.Items.Clear()
    '        cmbx_DelUserName.Items.Clear()
    '        sqlconn.Close()
    '        drop_userCategory()
    '    End Sub

    '    Private Sub UserRegister_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    '        'This Code is to clear the text fields in case of closing the window
    '        txtbox_RegUserName.Text = ""
    '        txtbox_RegPassword.Text = ""
    '        str_Regcategory = ""
    '        str_Regusername = ""
    '        str_Regpassword = ""
    '        str_Delusername = ""
    '        str_Delcategory = ""
    '        RegisterTimer.Enabled = False
    '        cmbx_RegCategory.ResetText()
    '        cmbx_DelCateory.ResetText()
    '        cmbx_DelUserName.ResetText()
    '        cmbx_RegCategory.Items.Clear()
    '        cmbx_DelCateory.Items.Clear()
    '        cmbx_DelUserName.Items.Clear()
    '        sqlconn.Close()
    '    End Sub


End Class