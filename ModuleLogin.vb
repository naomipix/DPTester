Module LoginMessage 'LoginMessage.LoginPrompt(0, 0, 0)
    Public Sub LoginPrompt(i As Integer, username As String, categoryname As String)
        Select Case i
            Case 1
                MsgBox("User Name field cannot be Empty", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 2
                MsgBox("Password field cannot be Empty", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 3
                MsgBox("Bad Credentials, Username and password not found", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 4
                MsgBox("Wrong Password, try again", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 5
                MsgBox(categoryname + " " + username + " Log in Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 6
                MsgBox(" Developer Log in Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 7
                MsgBox("Developer Login failed, Wrong Password, try Camera Resolution unit", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
        End Select
    End Sub

    Public Sub RegistrationPrompt(i As Integer, username As String, categoryname As String)
        Select Case i
            Case 1
                MsgBox("User Name field cannot be Empty", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 2
                MsgBox("Password field cannot be Empty", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 3
                MsgBox("Category field cannot be Empty", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 4
                MsgBox("User not found under selected Category, try again", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 5
                MsgBox(categoryname + " " + username + " Registration Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 6
                MsgBox(categoryname + " " + username + " Deletion Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 7
                MsgBox("Username Already exists, Registration Fail", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 8
                MsgBox("Administrator/Engineer Log in required to Register/Delete User", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 9
                MsgBox("Username 'Developer' Cannot be created", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 10
                MsgBox("Query execution not successful, User Registration Failed", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 11
                MsgBox("Query execution not successful, User Deletion Failed", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
        End Select
    End Sub
End Module

Module LoginModule
    Public WithEvents loginTimer As New Timer()

    Private Sub loginTimer_Tick(sender As Object, e As EventArgs) Handles loginTimer.Tick
        ' Code to execute on each tick of the timer
        If PublicVariables.LoggedIn = False Then
            If Application.OpenForms().OfType(Of FormUserLogin).Any Then
            Else
                If PublicVariables.IsExitPromptShown = False Then
                    FormUserLogin.ShowDialog()
                End If
            End If
        End If
    End Sub

    Public Sub StartLoginTimerCheck(Seconds As Integer)
        loginTimer.Interval = Seconds * 1000
        loginTimer.Start()
    End Sub

    Public Function Authenticate(TxtbxUsername As String, TxtbxPassword As String) As String
        ' Returns - EmptyField;EmptyUsername;EmptyPassword;DeveloperLoginFailed;LoginSuccess;LoginSuccessDeveloper;WrongPassword;UserDuplicate;UserNotFound;

        ' Declare Parameters
        Dim ReturnValue As String = ""
        Dim LoginDeveloper As Boolean = False
        Dim LoginUsername As String = TxtbxUsername.Trim
        Dim LoginPassword As String = TxtbxPassword.Trim

        ' Execute Action
        If LoggedIn = False Then
            ' Log In
            Dim onContinue As Boolean = True

            ' Check Is Username & Password Empty
            If onContinue = True Then
                If LoginUsername.Length = 0 And LoginPassword.Length = 0 Then
                    ReturnValue = "EmptyField"
                    onContinue = False
                End If
            End If

            ' Check Is Username Empty
            If onContinue = True Then
                If LoginUsername.Length = 0 Then
                    ReturnValue = "EmptyUsername"
                    onContinue = False
                End If
            End If

            ' Check Is Password Empty
            If onContinue = True Then
                If LoginPassword.Length = 0 Then
                    ReturnValue = "EmptyPassword"
                    onContinue = False
                End If
            End If

            ' Check Is Developer
            If onContinue = True Then
                If String.Compare(LoginUsername, "Developer", true) = 0 Then
                    LoginDeveloper = True
                End If
            End If

            ' Authenticate
            If onContinue = True Then
                If LoginDeveloper = True Then
                    ' Login As Developer
                    If String.Compare(LoginPassword, "Pixel", False) = 0 Then
                        ' Login Success
                        ReturnValue = "LoginSuccessDeveloper"
                        PublicVariables.LoggedIn = True
                        PublicVariables.LoggedInIsDeveloper = True
                        PublicVariables.LoginUserID = 0
                        PublicVariables.LoginUserName = LoginUsername
                        PublicVariables.LoginUserCategoryID = 0
                        PublicVariables.LoginUserCategoryName = "DEVELOPER"
                    Else
                        ' Login Failed
                        ReturnValue = "DeveloperLoginFailed"
                    End If
                Else
                    ' Login As User
                    Dim sqlString As String = "
                        SELECT UserAccount.id, 
                            UserAccount.user_name, 
                            UserAccount.user_password, 
                            UserAccount.user_category_id, 
                            UserCategory.description 
                        FROM UserAccount 
                        LEFT JOIN UserCategory ON UserAccount.user_category_id=UserCategory.id 
                        "
                    Dim dvUserAccount As DataView = SQL.ReadRecords(sqlString).DefaultView

                    ' Filters Based On LoginUsername
                    dvUserAccount.RowFilter = $"user_name = '{LoginUsername}'"

                    ' Convert To DataTable
                    Dim dtUserAccount As DataTable = dvUserAccount.ToTable



                    If dtUserAccount.Rows.Count > 0 Then
                        If dtUserAccount.Rows.Count = 1 Then
                            ' User Found
                            If String.Compare(LoginPassword, dtUserAccount(0)("user_password"), False) = 0 Then
                                PublicVariables.LoggedIn = True
                                PublicVariables.LoggedInIsDeveloper = False
                                PublicVariables.LoginUserID = dtUserAccount(0)("id")
                                PublicVariables.LoginUserName = dtUserAccount(0)("user_name")
                                PublicVariables.LoginUserCategoryID = dtUserAccount(0)("user_category_id")
                                PublicVariables.LoginUserCategoryName = dtUserAccount(0)("description")

                                ' Update LoginTable [To Log Every User Logins]
                                If True Then
                                    Dim parameters As New Dictionary(Of String, Object) From {
                                        {"user_name", PublicVariables.LoginUserName},
                                        {"user_category", PublicVariables.LoginUserCategoryName}
                                    }
                                    SQL.InsertRecord("UserLogin", parameters)
                                End If



                                ReturnValue = "LoginSuccess"
                            Else
                                ReturnValue = "WrongPassword"
                            End If
                        Else
                            ' User Duplicate
                            ReturnValue = "UserDuplicate"
                        End If
                    Else
                        ' User Not Found
                        ReturnValue = "UserNotFound"
                    End If
                End If
            End If

            ' Check Login Success
            If Not (ReturnValue = "LoginSuccess" Or ReturnValue = "LoginSuccessDeveloper") Then
                LoginModule.ClearLoginValues()
            End If
        End If

        ' Return State
        Return ReturnValue
    End Function

    Public Sub ClearLoginValues()
        PublicVariables.LoggedIn = False
        PublicVariables.LoggedInIsDeveloper = False
        PublicVariables.LoginUserID = -1
        PublicVariables.LoginUserName = ""
        PublicVariables.LoginUserCategoryID = -1
        PublicVariables.LoginUserCategoryName = ""
    End Sub
End Module

Module PermissionModule
    ' Permissions
    Public MainMenu_BtnRegister As Boolean = False
    Public MainMenu_BtnRecipe As Boolean = False
    Public MainMenu_BtnCalibrate As Boolean = False
    Public MainMenu_BtnSetting As Boolean = False
    Public MainMenu_BtnMsgLog As Boolean = False
    Public MainMenu_BtnResultSum As Boolean = False
    Public MainMenu_BtnResultGraph As Boolean = False

    Public MainMenu_Main As Boolean = False
    Public MainMenu_ProdDetail As Boolean = False
    Public MainMenu_Status As Boolean = False
    Public MainMenu_ManualCtrl As Boolean = False
    Public MainMenu_Alarm As Boolean = False

    Public UserRegister_Registration As Boolean = False
    Public UserRegister_Deletion As Boolean = False

    Public Recipe_Detail As Boolean = False
    Public Recipe_Edit As Boolean = False
    Public Recipe_Create As Boolean = False
    Public Recipe_Delete As Boolean = False

    Public Setting_Main As Boolean = False
    Public Setting_ToolCounter As Boolean = False
    Public Setting_Buyoff As Boolean = False
    Public Setting_Developer As Boolean = False

    Public Sub ClearPermissions()
        If True Then
            MainMenu_BtnRegister = False
            MainMenu_BtnRecipe = False
            MainMenu_BtnCalibrate = False
            MainMenu_BtnSetting = False
            MainMenu_BtnMsgLog = False
            MainMenu_BtnResultSum = False
            MainMenu_BtnResultGraph = False

            MainMenu_Main = False
            MainMenu_ProdDetail = False
            MainMenu_Status = False
            MainMenu_ManualCtrl = False
            MainMenu_Alarm = False

            UserRegister_Registration = False
            UserRegister_Deletion = False

            Recipe_Detail = False
            Recipe_Edit = False
            Recipe_Create = False
            Recipe_Delete = False

            Setting_Main = False
            Setting_ToolCounter = False
            Setting_Buyoff = False
            'Setting_Developer = False
        End If

        ReloadPermission()
    End Sub

    Public Sub ApplyOnLogon()
        Dim dt As DataTable = SQL.ReadRecords($"SELECT permission FROM UserPermission WHERE user_category_id='{PublicVariables.LoginUserCategoryID}'")

        ' Apply All Permission (Developer)
        If PublicVariables.LoggedInIsDeveloper Then
            dt = New DataTable
            dt.Columns.Add("permission")

            dt.Rows.Add("Main Menu")
            dt.Rows.Add("Registration")
            dt.Rows.Add("Recipe")
            dt.Rows.Add("Calibrate")
            dt.Rows.Add("Settings")
            dt.Rows.Add("Message Log")
            dt.Rows.Add("Result Summary")
            dt.Rows.Add("Result Graph")

            dt.Rows.Add("Main")
            dt.Rows.Add("Production Details")
            dt.Rows.Add("Status")
            dt.Rows.Add("Manual Control")
            dt.Rows.Add("Alarm")

            dt.Rows.Add("User Registration")
            dt.Rows.Add("User Deletion")

            dt.Rows.Add("Recipe Details")
            dt.Rows.Add("Recipe Edit")
            dt.Rows.Add("Recipe Create")
            dt.Rows.Add("Recipe Delete")

            dt.Rows.Add("Main Settings")
            dt.Rows.Add("Tool Counter")
            dt.Rows.Add("Dry Run / Buy-Off")
        End If

        For Each row As DataRow In dt.Rows
            ' Apply Permission
            If True Then
                If row.Item("permission") = "Main Menu" Then

                End If
                If row.Item("permission") = "Registration" Then
                    MainMenu_BtnRegister = True
                End If
                If row.Item("permission") = "Recipe" Then
                    MainMenu_BtnRecipe = True
                End If
                If row.Item("permission") = "Calibrate" Then
                    MainMenu_BtnCalibrate = True
                End If
                If row.Item("permission") = "Settings" Then
                    MainMenu_BtnSetting = True
                End If
                If row.Item("permission") = "Message Log" Then
                    MainMenu_BtnMsgLog = True
                End If
                If row.Item("permission") = "Result Summary" Then
                    MainMenu_BtnResultSum = True
                End If
                If row.Item("permission") = "Result Graph" Then
                    MainMenu_BtnResultGraph = True
                End If
            End If

            If True Then
                If row.Item("permission") = "Main" Then
                    MainMenu_Main = True
                End If
                If row.Item("permission") = "Production Details" Then
                    MainMenu_ProdDetail = True
                End If
                If row.Item("permission") = "Status" Then
                    MainMenu_Status = True
                End If
                If row.Item("permission") = "Manual Control" Then
                    MainMenu_ManualCtrl = True
                End If
                If row.Item("permission") = "Alarm" Then
                    MainMenu_Alarm = True
                End If

                If row.Item("permission") = "User Registration" Then
                    UserRegister_Registration = True
                End If
                If row.Item("permission") = "User Deletion" Then
                    UserRegister_Deletion = True
                End If

                If row.Item("permission") = "Recipe Details" Then
                    Recipe_Detail = True
                End If
                If row.Item("permission") = "Recipe Edit" Then
                    Recipe_Edit = True
                End If
                If row.Item("permission") = "Recipe Create" Then
                    Recipe_Create = True
                End If
                If row.Item("permission") = "Recipe Delete" Then
                    Recipe_Delete = True
                End If

                If row.Item("permission") = "Main Settings" Then
                    Setting_Main = True
                End If
                If row.Item("permission") = "Tool Counter" Then
                    Setting_ToolCounter = True
                End If
                If row.Item("permission") = "Dry Run / Buy-Off" Then
                    Setting_Buyoff = True
                End If
                'If row.Item("permission") = "Developer" Then
                '    Setting_Developer = True
                'End If
            End If
        Next
    End Sub

    Public Sub ReloadPermission()
        If MainMenu_BtnRegister = True Then
            With FormMain.btn_UserRegistration
                .Enabled = True
                .BackColor = Color.FromArgb(25, 130, 246)
            End With
        Else
            With FormMain.btn_UserRegistration
                .Enabled = False
                .BackColor = SystemColors.ControlDark
            End With
        End If
        If MainMenu_BtnRecipe = True Then
            With FormMain.btn_RecipeManagement
                .Enabled = True
                .BackColor = Color.FromArgb(25, 130, 246)
            End With
        Else
            With FormMain.btn_RecipeManagement
                .Enabled = False
                .BackColor = SystemColors.ControlDark
            End With
        End If
        If MainMenu_BtnCalibrate = True Then
            With FormMain.btn_Calibration
                .Enabled = True
                .BackColor = Color.FromArgb(25, 130, 246)
            End With
        Else
            With FormMain.btn_Calibration
                .Enabled = False
                .BackColor = SystemColors.ControlDark
            End With
        End If
        If MainMenu_BtnSetting = True Then
            With FormMain.btn_Setting
                .Enabled = True
                .BackColor = Color.FromArgb(25, 130, 246)
            End With
        Else
            With FormMain.btn_Setting
                .Enabled = False
                .BackColor = SystemColors.ControlDark
            End With
        End If
        If MainMenu_BtnMsgLog = True Then
            With FormMain.btn_MessageLog
                .Enabled = True
                .BackColor = Color.FromArgb(25, 130, 246)
            End With
        Else
            With FormMain.btn_MessageLog
                .Enabled = False
                .BackColor = SystemColors.ControlDark
            End With
        End If
        If MainMenu_BtnResultSum = True Then
            With FormMain.btn_ResultSummary
                .Enabled = True
                .BackColor = Color.FromArgb(25, 130, 246)
            End With
        Else
            With FormMain.btn_ResultSummary
                .Enabled = False
                .BackColor = SystemColors.ControlDark
            End With
        End If
        If MainMenu_BtnResultGraph = True Then
            With FormMain.btn_ResultGraph
                .Enabled = True
                .BackColor = Color.FromArgb(25, 130, 246)
            End With
        Else
            With FormMain.btn_ResultGraph
                .Enabled = False
                .BackColor = SystemColors.ControlDark
            End With
        End If

        If MainMenu_Main = True Then
            FormMain.tabpg_Main.Enabled = True
        Else
            FormMain.tabpg_Main.Enabled = False
        End If
        If MainMenu_ProdDetail = True Then
            FormMain.tabpg_ProdDetail.Enabled = True
        Else
            FormMain.tabpg_ProdDetail.Enabled = False
        End If
        If MainMenu_Status = True Then
            FormMain.tabpg_Status.Enabled = True
        Else
            FormMain.tabpg_Status.Enabled = False
        End If
        If MainMenu_ManualCtrl = True Then
            FormMain.tabpg_ManualCtrl.Enabled = True
        Else
            FormMain.tabpg_ManualCtrl.Enabled = False
        End If
        If MainMenu_Alarm = True Then
            FormMain.tabpg_Alarm.Enabled = True
        Else
            FormMain.tabpg_Alarm.Enabled = False
        End If

        If UserRegister_Registration = True Then
            FormUserRegister.tabpg_UserReg.Enabled = True
        Else
            FormUserRegister.tabpg_UserReg.Enabled = False
        End If
        If UserRegister_Deletion = True Then
            FormUserRegister.tabpg_UserDel.Enabled = True
        Else
            FormUserRegister.tabpg_UserDel.Enabled = False
        End If

        If Recipe_Detail = True Then
            FormRecipeManagement.tabpg_RecipeDetails.Enabled = True
        Else
            FormRecipeManagement.tabpg_RecipeDetails.Enabled = False
        End If
        If Recipe_Edit = True Then
            FormRecipeManagement.tabpg_Edit.Enabled = True
        Else
            FormRecipeManagement.tabpg_Edit.Enabled = False
        End If
        If Recipe_Create = True Then
            FormRecipeManagement.tabpg_Create.Enabled = True
        Else
            FormRecipeManagement.tabpg_Create.Enabled = False
        End If
        If Recipe_Delete = True Then
            FormRecipeManagement.tabpg_Delete.Enabled = True
        Else
            FormRecipeManagement.tabpg_Delete.Enabled = False
        End If

        If Setting_Main = True Then
            FormSetting.tabpg_Settings.Enabled = True
        Else
            FormSetting.tabpg_Settings.Enabled = False
        End If
        If Setting_ToolCounter = True Then
            FormSetting.tabpg_ToolCounter.Enabled = True
        Else
            FormSetting.tabpg_ToolCounter.Enabled = False
        End If
        If Setting_Buyoff = True Then
            FormSetting.tabpg_BuyOff.Enabled = True
        Else
            FormSetting.tabpg_BuyOff.Enabled = False
        End If

    End Sub
End Module

Module UserRegistration
    Public Function Insert(TxtbxUsername As String, TxtbxPassword As String, ComboBoxCategory As ComboBox) As String
        ' Returns - EmptyField;EmptyUsername;EmptyPassword;EmptyUserCategory;Developer;UserNameFound;Success;

        ' Declare Parameters
        Dim ReturnValue As String = ""
        Dim RegisterUsername As String = TxtbxUsername.Trim
        Dim RegisterPassword As String = TxtbxPassword.Trim
        Dim UserCategoryID As Integer = DirectCast(ComboBoxCategory.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim UserCategoryName As String = DirectCast(ComboBoxCategory.SelectedItem, KeyValuePair(Of String, String)).Value
        Dim onContinue As Boolean = True

        ' Execute Action
        If True Then
            ' Check Is Username & Password Empty
            If onContinue = True Then
                If RegisterUsername.Length = 0 And RegisterPassword.Length = 0 And ComboBoxCategory.SelectedIndex = 0 Then
                    ReturnValue = "EmptyField"
                    onContinue = False
                End If
            End If

            ' Check Is Username Empty
            If onContinue = True Then
                If RegisterUsername.Length = 0 Then
                    ReturnValue = "EmptyUsername"
                    onContinue = False
                End If
            End If

            ' Check Is Password Empty
            If onContinue = True Then
                If RegisterPassword.Length = 0 Then
                    ReturnValue = "EmptyPassword"
                    onContinue = False
                End If
            End If

            ' Check Is User Category Empty
            If onContinue = True Then
                If ComboBoxCategory.SelectedIndex = 0 Then
                    ReturnValue = "EmptyUserCategory"
                    onContinue = False
                End If
            End If

            ' Check Is User Name [Developer]
            If onContinue = True Then
                If String.Compare(RegisterUsername, "Developer", True) = 0 Then
                    ReturnValue = "Developer"
                    onContinue = False
                End If
            End If

            ' Check User Exists
            If onContinue = True Then
                Dim dtUserAccount As DataTable = SQL.ReadRecords("SELECT user_name FROM UserAccount")

                For Each row As DataRow In dtUserAccount.Rows
                    If String.Compare(row.Item("user_name"), RegisterUsername, True) = 0 Then
                        ReturnValue = "UserNameFound"
                        onContinue = False
                        Exit For
                    End If
                Next
            End If

            ' Register
            If onContinue = True Then
                ' Get SQL Date Time
                Dim SQLDateTime As DateTime = SQL.ReadRecords("SELECT GETDATE()")(0)(0)

                ' Insert Record
                If True Then
                    Dim parameters As New Dictionary(Of String, Object) From {
                        {"user_name", RegisterUsername},
                        {"user_password", RegisterPassword},
                        {"user_category_id", UserCategoryID},
                        {"user_created", PublicVariables.LoginUserName}
                    }
                    SQL.InsertRecord("UserAccount", parameters)
                End If

                ' Check Insert Success
                If True Then
                    Dim dtUserAccount As DataTable = SQL.ReadRecords("SELECT user_name FROM UserAccount")

                    For Each row As DataRow In dtUserAccount.Rows
                        If String.Compare(row.Item("user_name"), RegisterUsername, True) = 0 Then
                            ReturnValue = "Success"
                        End If
                    Next
                End If
            End If
        End If

        ' Return State
        Return ReturnValue
    End Function

    Public Function Delete(ComboBoxCategory As ComboBox, ComboBoxUser As ComboBox) As String
        ' Returns - EmptyField;EmptyCategory;EmptyUser;Success;RecordFound;
        ' Declare Parameters
        Dim ReturnValue As String = ""
        Dim UserID As Integer = DirectCast(ComboBoxUser.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim UserName As String = DirectCast(ComboBoxUser.SelectedItem, KeyValuePair(Of String, String)).Value
        Dim onContinue As Boolean = True

        ' Execute Action
        If True Then
            ' Check Is ComboBoxCategory & ComboBoxUser Empty
            If onContinue = True Then
                Dim ValueToReturn As String = "EmptyField"
                If ComboBoxCategory.Items.Count > 0 And ComboBoxUser.Items.Count > 0 Then
                    If ComboBoxCategory.SelectedIndex = 0 And ComboBoxUser.SelectedIndex = 0 Then
                        ReturnValue = ValueToReturn
                        onContinue = False
                    End If
                Else
                    ReturnValue = ValueToReturn
                    onContinue = False
                End If
            End If

            ' Check Is ComboBoxCategory Empty
            If onContinue = True Then
                If ComboBoxCategory.SelectedIndex = 0 Then
                    ReturnValue = "EmptyCategory"
                    onContinue = False
                End If
            End If

            ' Check Is ComboBoxUser Empty
            If onContinue = True Then
                If ComboBoxUser.SelectedIndex = 0 Then
                    ReturnValue = "EmptyUser"
                    onContinue = False
                End If
            End If

            ' Remove
            If onContinue = True Then
                ' Get SQL Date Time
                Dim SQLDateTime As DateTime = SQL.ReadRecords("SELECT GETDATE()")(0)(0)

                ' Delete Record
                If True Then
                    SQL.DeleteRecord("UserAccount", $"id='{UserID}'")
                End If

                ' Check Record Exists
                If True Then
                    Dim dtUserAccount As DataTable = SQL.ReadRecords($"SELECT id FROM UserAccount WHERE id='{UserID}'")

                    If dtUserAccount.Rows.Count = 0 Then
                        ReturnValue = "Success"
                    Else
                        ReturnValue = "RecordFound"
                    End If
                End If
            End If
        End If

        ' Return State
        Return ReturnValue
    End Function
End Module
