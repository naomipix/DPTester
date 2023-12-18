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
        txtbox_RegPassword.PasswordChar = "*"
        btn_RegPwdVisible.BackColor = Color.FromArgb(25, 130, 246)


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



End Class