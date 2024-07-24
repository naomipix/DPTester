Imports System.ComponentModel

Public Class FormRecipeManagement
    Public WithEvents Recipetimer As New Timer()
#Region "Variables"
    ' Declare Variables
    Dim CurrentTabPage As TabPage
    Public Recipeexportpath As String = PublicVariables.Recipeexportpath
    Public d_vertol As Decimal
    'Public d_prepflow As Decimal
    'Public d_prepflowtol As Decimal

    Public i_prepfilltime As Integer
    Public i_prepprefillstarttime As Integer
    Public i_prepprefilltime As Integer
    Public i_prepdrainstarttime As Integer
    Public i_prepdraintime As Integer
    Public i_prepbleedtime As Integer
    Public i_preppressuredroptime As Integer
    Public d_preppressuredrop As Decimal
    Public d_preppressure As Decimal
    Public i_preprpm1 As Integer
    'Public i_preprpm2 As Integer
    Public str_prepspeedenable As String

    Public str_flush1enable As String
    'Public i_flush1filltime As Integer
    'Public i_flush1bleedtime As Integer
    Public d_flush1flow As Decimal
    Public d_flush1flowtol As Decimal
    Public d_flush1pressure As Decimal
    Public i_flush1stabilize As Integer
    Public i_flush1time As Integer
    Public i_flush1rpm As Integer
    Public str_flush1speedenable As String

    Public str_dptest1enable As String
    'Public i_dptestfilltime As Integer
    'Public i_dptestbleedtime As Integer
    Public d_dptestflow As Decimal
    Public d_dptestflowtol As Decimal
    Public d_dptestpressure As Decimal
    Public i_dpteststabilize As Integer
    Public i_dptesttime As Integer
    Public d_dptestlowlimit As Decimal
    Public d_dptestuplimit As Decimal
    Public i_dptestpoints As Integer
    Public i_dptestrpm As Integer
    Public str_dptestspeedenable As String
    Public str_dptest2enable As String

    Public str_flush2enable As String
    'Public i_flush2filltime As Integer
    'Public i_flush2bleedtime As Integer
    Public d_flush2flow As Decimal
    Public d_flush2flowtol As Decimal
    Public d_flush2pressure As Decimal
    Public i_flush2stabilize As Integer
    Public i_flush2time As Integer
    Public i_flush2rpm As Integer
    Public str_flush2speedenable As String

    Public str_drain1enable As String
    Public d_drain1pressure As Decimal
    Public i_drain1time As Integer
    Public str_drain2enable As String
    Public d_drain2pressure As Decimal
    Public i_drain2time As Integer
    Public str_drain3enable As String
    Public d_drain3pressure As Decimal
    Public i_drain3time As Integer
    Public str_drain4enable As String
    Public d_drain4pressure As Decimal
    Public i_drain4time As Integer

    ' Declare Recipe Parameter Nominal Value Variables
    Private nom_d_vertol As Decimal = 1.0
    'Private nom_d_prepflow As Decimal = 3
    'Private nom_d_prepflowtol As Decimal = 0.5

    Private nom_i_prepfilltime As Integer = 5
    Private nom_i_prepprefillstarttime As Integer = 0
    Private nom_i_prepprefilltime As Integer = 0
    Private nom_i_prepdrainstarttime As Integer = 0
    Private nom_i_prepdraintime As Integer = 0
    Private nom_i_prepbleedtime As Integer = 0
    Private nom_i_preppressuredroptime As Integer = 0
    Private nom_d_preppressuredrop As Decimal = 5
    Private nom_d_preppressure As Decimal = 5
    Private nom_i_preprpm1 As Integer = 3000
    'Private nom_i_preprpm2 As Integer = 3000
    Private nom_str_prepspeedenable As String = "Disable"

    Private nom_str_flush1enable As String = "Disable"
    'Private nom_i_flush1filltime As Integer = 5
    'Private nom_i_flush1bleedtime As Integer = 5
    Private nom_d_flush1flow As Decimal = 3.0
    Private nom_d_flush1flowtol As Decimal = 0.5
    Private nom_d_flush1pressure As Decimal = 5.0
    Private nom_i_flush1stabilize As Integer = 5
    Private nom_i_flush1time As Integer = 60
    Private nom_i_flush1rpm As Integer = 3000
    Private nom_str_flush1speedenable As String = "Disable"

    Private nom_str_dptest1enable As String = "Disable"
    'Private nom_i_dptestfilltime As Integer = 5
    'Private nom_i_dptestbleedtime As Integer = 5
    Private nom_d_dptestflow As Decimal = 3.0
    Private nom_d_dptestflowtol As Decimal = 0.2
    Private nom_d_dptestpressure As Decimal = 5.0
    Private nom_i_dpteststabilize As Integer = 5
    Private nom_i_dptesttime As Integer = 60
    Private nom_d_dptestlowlimit As Decimal = 0.0
    Private nom_d_dptestuplimit As Decimal = 10.0
    Private nom_i_dptestpoints As Integer = 20
    Private nom_i_dptestrpm As Integer = 3000
    Private nom_str_dptestspeedenable As String = "Disable"
    Private nom_str_dptest2enable As String = "Disable"

    Private nom_str_flush2enable As String = "Disable"
    'Private nom_i_flush2filltime As Integer = 5
    'Private nom_i_flush2bleedtime As Integer = 5
    Private nom_d_flush2flow As Decimal = 3.0
    Private nom_d_flush2flowtol As Decimal = 0.2
    Private nom_d_flush2pressure As Decimal = 5.0
    Private nom_i_flush2stabilize As Integer = 5
    Private nom_i_flush2time As Integer = 60
    Private nom_i_flush2rpm As Integer = 3000
    Private nom_str_flush2speedenable As String = "Disable"

    Private nom_str_drain1enable As String = "Disable"
    Private nom_d_drain1pressure As Decimal = 5.0
    Private nom_i_drain1time As Integer = 60
    Private nom_str_drain2enable As String = "Disable"
    Private nom_d_drain2pressure As Decimal = 5.0
    Private nom_i_drain2time As Integer = 60
    Private nom_str_drain3enable As String = "Disable"
    Private nom_d_drain3pressure As Decimal = 5.0
    Private nom_i_drain3time As Integer = 60
    Private nom_str_drain4enable As String = "Disable"
    Private nom_d_drain4pressure As Decimal = 5.0
    Private nom_i_drain4time As Integer = 60

    ' Declare Recipe Parameter Min Limit Variables
    Private min_d_vertol As Decimal = PublicVariables.Limit_Min_d_vertol

    Private min_i_prepfilltime As Integer = PublicVariables.Limit_Min_i_prepfilltime
    Private min_i_prepbleedtime As Integer = PublicVariables.Limit_Min_i_prepbleedtime
    'Private min_d_prepflow As Decimal = PublicVariables.Limit_Min_d_prepflow
    'Private min_d_prepflowtol As Decimal = PublicVariables.Limit_Min_d_prepflowtol
    Private min_d_preppressuredrop As Decimal = PublicVariables.Limit_Min_d_preppressuredrop
    Private min_i_preppressuredroptime As Integer = PublicVariables.Limit_Min_i_preppressuredroptime
    Private min_d_preppressure As Decimal = PublicVariables.Limit_Min_d_preppressure
    Private min_i_prepprefillstarttime As Integer = PublicVariables.Limit_Min_i_prepprefillstarttime
    Private min_i_prepprefilltime As Integer = PublicVariables.Limit_Min_i_prepprefilltime
    Private min_i_prepdrainstarttime As Integer = PublicVariables.Limit_Min_i_prepdrainstarttime
    Private min_i_prepdraintime As Integer = PublicVariables.Limit_Min_i_prepdraintime
    Private min_i_preprpm1 As Integer = PublicVariables.Limit_Min_i_preprpm1
    'Private min_i_preprpm2 As Integer = PublicVariables.Limit_Min_i_preprpm2

    'Private min_i_flush1filltime As Integer = PublicVariables.Limit_Min_i_flush1filltime
    'Private min_i_flush1bleedtime As Integer = PublicVariables.Limit_Min_i_flush1bleedtime
    Private min_d_flush1flow As Decimal = PublicVariables.Limit_Min_d_flush1flow
    Private min_d_flush1flowtol As Decimal = PublicVariables.Limit_Min_d_flush1flowtol
    Private min_d_flush1pressure As Decimal = PublicVariables.Limit_Min_d_flush1pressure
    Private min_i_flush1stabilize As Integer = PublicVariables.Limit_Min_i_flush1stabilize
    Private min_i_flush1time As Integer = PublicVariables.Limit_Min_i_flush1time
    Private min_i_flush1rpm As Integer = PublicVariables.Limit_Min_i_flush1rpm

    'Private min_i_dptestfilltime As Integer = PublicVariables.Limit_Min_i_dptestfilltime
    'Private min_i_dptestbleedtime As Integer = PublicVariables.Limit_Min_i_dptestbleedtime
    Private min_d_dptestflow As Decimal = PublicVariables.Limit_Min_d_dptestflow
    Private min_d_dptestflowtol As Decimal = PublicVariables.Limit_Min_d_dptestflowtol
    Private min_d_dptestpressure As Decimal = PublicVariables.Limit_Min_d_dptestpressure
    Private min_i_dpteststabilize As Integer = PublicVariables.Limit_Min_i_dpteststabilize
    Private min_i_dptesttime As Integer = PublicVariables.Limit_Min_i_dptesttime
    Private min_d_dptestlowlimit As Decimal = PublicVariables.Limit_Min_d_dptestlowlimit
    Private min_d_dptestuplimit As Decimal = PublicVariables.Limit_Min_d_dptestuplimit
    Private min_i_dptestpoints As Integer = PublicVariables.Limit_Min_i_dptestpoints
    Private min_i_dptestrpm As Integer = PublicVariables.Limit_Min_i_dptestrpm

    'Private min_i_flush2filltime As Integer = PublicVariables.Limit_Min_i_flush2filltime
    'Private min_i_flush2bleedtime As Integer = PublicVariables.Limit_Min_i_flush2bleedtime
    Private min_d_flush2flow As Decimal = PublicVariables.Limit_Min_d_flush2flow
    Private min_d_flush2flowtol As Decimal = PublicVariables.Limit_Min_d_flush2flowtol
    Private min_d_flush2pressure As Decimal = PublicVariables.Limit_Min_d_flush2pressure
    Private min_i_flush2stabilize As Integer = PublicVariables.Limit_Min_i_flush2stabilize
    Private min_i_flush2time As Integer = PublicVariables.Limit_Min_i_flush2time
    Private min_i_flush2rpm As Integer = PublicVariables.Limit_Min_i_flush2rpm

    Private min_d_drain1pressure As Decimal = PublicVariables.Limit_Min_d_drain1pressure
    Private min_i_drain1time As Integer = PublicVariables.Limit_Min_i_drain1time

    Private min_d_drain2pressure As Decimal = PublicVariables.Limit_Min_d_drain2pressure
    Private min_i_drain2time As Integer = PublicVariables.Limit_Min_i_drain2time

    Private min_d_drain3pressure As Decimal = PublicVariables.Limit_Min_d_drain3pressure
    Private min_i_drain3time As Integer = PublicVariables.Limit_Min_i_drain3time

    Private min_d_drain4pressure As Decimal = PublicVariables.Limit_Min_d_drain4pressure
    Private min_i_drain4time As Integer = PublicVariables.Limit_Min_i_drain4time

    ' Declare Recipe Parameter Max Limit Variables
    Private max_d_vertol As Decimal = PublicVariables.Limit_Max_d_vertol

    Private max_i_prepfilltime As Integer = PublicVariables.Limit_Max_i_prepfilltime
    Private max_i_prepbleedtime As Integer = PublicVariables.Limit_Max_i_prepbleedtime
    'Private max_d_prepflow As Decimal = PublicVariables.Limit_Max_d_prepflow
    'Private max_d_prepflowtol As Decimal = PublicVariables.Limit_Max_d_prepflowtol
    Private max_d_preppressuredrop As Decimal = PublicVariables.Limit_Max_d_preppressuredrop
    Private max_i_preppressuredroptime As Integer = PublicVariables.Limit_Max_i_preppressuredroptime
    Private max_d_preppressure As Decimal = PublicVariables.Limit_Max_d_preppressure
    Private max_i_prepprefillstarttime As Integer = PublicVariables.Limit_Max_i_prepprefillstarttime
    Private max_i_prepprefilltime As Integer = PublicVariables.Limit_Max_i_prepprefilltime
    Private max_i_prepdrainstarttime As Integer = PublicVariables.Limit_Max_i_prepdrainstarttime
    Private max_i_prepdraintime As Integer = PublicVariables.Limit_Max_i_prepdraintime
    Private max_i_preprpm1 As Integer = PublicVariables.Limit_Max_i_preprpm1
    'Private max_i_preprpm2 As Integer = PublicVariables.Limit_Max_i_preprpm2

    'Private max_i_flush1filltime As Integer = PublicVariables.Limit_Max_i_flush1filltime
    'Private max_i_flush1bleedtime As Integer = PublicVariables.Limit_Max_i_flush1bleedtime
    Private max_d_flush1flow As Decimal = PublicVariables.Limit_Max_d_flush1flow
    Private max_d_flush1flowtol As Decimal = PublicVariables.Limit_Max_d_flush1flowtol
    Private max_d_flush1pressure As Decimal = PublicVariables.Limit_Max_d_flush1pressure
    Private max_i_flush1stabilize As Integer = PublicVariables.Limit_Max_i_flush1stabilize
    Private max_i_flush1time As Integer = PublicVariables.Limit_Max_i_flush1time
    Private max_i_flush1rpm As Integer = PublicVariables.Limit_Max_i_flush1rpm

    'Private max_i_dptestfilltime As Integer = PublicVariables.Limit_Max_i_dptestfilltime
    'Private max_i_dptestbleedtime As Integer = PublicVariables.Limit_Max_i_dptestbleedtime
    Private max_d_dptestflow As Decimal = PublicVariables.Limit_Max_d_dptestflow
    Private max_d_dptestflowtol As Decimal = PublicVariables.Limit_Max_d_dptestflowtol
    Private max_d_dptestpressure As Decimal = PublicVariables.Limit_Max_d_dptestpressure
    Private max_i_dpteststabilize As Integer = PublicVariables.Limit_Max_i_dpteststabilize
    Private max_i_dptesttime As Integer = PublicVariables.Limit_Max_i_dptesttime
    Private max_d_dptestlowlimit As Decimal = PublicVariables.Limit_Max_d_dptestlowlimit
    Private max_d_dptestuplimit As Decimal = PublicVariables.Limit_Max_d_dptestuplimit
    Private max_i_dptestpoints As Integer = PublicVariables.Limit_Max_i_dptestpoints
    Private max_i_dptestrpm As Integer = PublicVariables.Limit_Max_i_dptestrpm

    'Private max_i_flush2filltime As Integer = PublicVariables.Limit_Max_i_flush2filltime
    'Private max_i_flush2bleedtime As Integer = PublicVariables.Limit_Max_i_flush2bleedtime
    Private max_d_flush2flow As Decimal = PublicVariables.Limit_Max_d_flush2flow
    Private max_d_flush2flowtol As Decimal = PublicVariables.Limit_Max_d_flush2flowtol
    Private max_d_flush2pressure As Decimal = PublicVariables.Limit_Max_d_flush2pressure
    Private max_i_flush2stabilize As Integer = PublicVariables.Limit_Max_i_flush2stabilize
    Private max_i_flush2time As Integer = PublicVariables.Limit_Max_i_flush2time
    Private max_i_flush2rpm As Integer = PublicVariables.Limit_Max_i_flush2rpm

    Private max_d_drain1pressure As Decimal = PublicVariables.Limit_Max_d_drain1pressure
    Private max_i_drain1time As Integer = PublicVariables.Limit_Max_i_drain1time

    Private max_d_drain2pressure As Decimal = PublicVariables.Limit_Max_d_drain2pressure
    Private max_i_drain2time As Integer = PublicVariables.Limit_Max_i_drain2time

    Private max_d_drain3pressure As Decimal = PublicVariables.Limit_Max_d_drain3pressure
    Private max_i_drain3time As Integer = PublicVariables.Limit_Max_i_drain3time

    Private max_d_drain4pressure As Decimal = PublicVariables.Limit_Max_d_drain4pressure
    Private max_i_drain4time As Integer = PublicVariables.Limit_Max_i_drain4time

    ' Declare Recipe parameters for collecting Edit recipe
    Dim recipeparameter(50) As String
    Dim recipeparametertemp(50) As String ' For Event Logging
    Dim dtEditrecipetemp As New DataTable
#End Region

#Region "Message"
    Private Function RecipeMessage(a As Integer, Optional field As String = Nothing) As MsgBoxResult
        Select Case a
            Case 1
                Return MsgBox("Filter Type Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 2
                Return MsgBox("Jig Type Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 3
                Return MsgBox("Part ID Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 4
                Return MsgBox("Category Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 5
                Return MsgBox("Type Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 6
                Return MsgBox("Recipe ID Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 7
                Return MsgBox("Part ID already exists, Part ID Creation Failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 8
                Return MsgBox("Recipe ID already exists, Recipe ID Creation Failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 9
                Return MsgBox("Part ID Creation Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 10
                Return MsgBox("Recipe ID Creation Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 11
                Return MsgBox("Query unsuccessful , Part ID Creation Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 12
                Return MsgBox($"{field}, Creation Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 13
                Return MsgBox("Special Characters Found, Creation Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 14
                Return MsgBox("Query unsuccessful , Recipe ID Creation Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 15
                Return MsgBox("Unsaved changes in " + field + ", Discard?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning")
            Case 16
                Return Nothing 'MsgBox("Characters, Special characters and Spaces not allowed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 17
                Return MsgBox("Current Selection is of Integer type, decimal points are not allowed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 18
                Return MsgBox("Decimal points already present in current selection", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 19
                Return MsgBox(field + " field cannot be empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 20
                Return MsgBox("Data in the " + field + " range", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 21
                Return MsgBox(field + " Test points cannot be greater than " + field + " Test time ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 22
                Return MsgBox("Neither Flush nor DP Test circuit enabled, Action Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 23
                Return MsgBox("If " + field + " is enabled then " + field + " time cannot be Zero", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 24
                Return MsgBox("Recipe ID attached with the " + field + " found, Part ID Deletion Failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 25
                Return MsgBox("Part ID Deletion Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 26
                Return MsgBox("Query unsuccessful , Part ID Deletion Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 27
                Return MsgBox(field + " Part ID doesn't have Recipe, Recipe Deletion Failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 28
                Return MsgBox("Recipe ID Deletion Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 29
                Return MsgBox("Query unsuccessful , Recipe ID Deletion Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 30
                Return MsgBox("Failed to load default recipe parameters value", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning")
            Case 31
                Return MsgBox($"Are you sure, Do you want to Delete Part ID " + field + " ?" + vbCrLf + "**ALL Related Lot & Historical Data will be Deleted & NOT Recoverable!", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning")
            Case 32
                Return MsgBox("Part ID Deletion Aborted as per user request", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Information")
            Case 33
                Return MsgBox($"Are you sure to Delete Recipe ID " + field + " ?" + vbCrLf + "**ALL Related Lot & Historical Data will be Deleted & NOT Recoverable!", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning")
            Case 34
                Return MsgBox("Recipe ID Deletion Aborted as per user request", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Information")
            Case 35
                Return MsgBox(field + " Part ID doesn't have Recipe, Recipe Edit Failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 36
                Return MsgBox("Are you sure, Do you want to Update " + field + " Parameters ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning")
            Case 37
                Return MsgBox("Recipe Parameters Updation Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 38
                Return MsgBox("Query unsuccessful , Recipe Parameters Edit/Update Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 39
                Return MsgBox("None of the Drain circuits were enabled, Action Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 40
                Return MsgBox("Data not found with the selected group of filters ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 41
                Return MsgBox("CSV File Exported Successfully.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Export - Success")
            Case 42
                Return MsgBox("Unable To Export CSV File, Please Try Again.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Export - Failed To Export")
            Case 43
                Return MsgBox("New Type Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 44
                Return MsgBox("New Recipe ID Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 45
                Return MsgBox("Recipe ID Field cannot be Empty", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 46
                Return MsgBox("Recipe ID with given name already exists, Duplication Failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 47
                Return MsgBox("Recipe ID Duplication Successful", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            Case 48
                Return MsgBox("Query unsuccessful , Recipe ID Duplication Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 49
                Return MsgBox($"{field}, Duplication Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 50
                Return MsgBox("Special Characters Found, Duplication Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 51
                Return MsgBox("Failed to Load Duplicate Recipe for Edit ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 52
                Return MsgBox("Invalid File Path Specified.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Export - Path Error")
            Case 53
                Return MsgBox($"{field}", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 54
                Return MsgBox($"{field} Recipe ID's Product Result Data Deletion Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 55
                Return MsgBox($"{field} Recipe ID's Production Details Data Deletion Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 56
                Return MsgBox($"{field} Recipe ID's Calibration Data Deletion Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 57
                Return MsgBox($"{field} Recipe ID's Work Order Data Deletion Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Case 58
                Return MsgBox($"{field} Recipe ID's Lot Usage Data Deletion Failed ", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")


            Case Else
                Exit Select
        End Select

        Return 0
    End Function
#End Region

#Region "General Formatting and checks"
    'To convert string into uppercase and to trim leading or trailing spaces in the string
    Public Function Formatstring(str As String) As String
        Dim strupper As String
        strupper = str.ToUpper
        Return strupper.Trim
    End Function

    ' To Check whether the String has any special Characters other than "-" and "_"
    Public Function Checkspecial(specialstr As String) As Integer
        'Dim specialchar() As Char = New Char() {"!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "[", "]", "{", "}", ":", ";", "'", ",", ".", "<", ">", "/", "?", "|", "\", "~", "`", """"}
        Dim specialchar() As Char = New Char() {"!", "@", "#", "$", "%", "^", "&", "(", ")", "+", "=", "[", "]", "{", "}", ":", ";", "'", ",", ".", "<", ">", "?", "|", "\", "~", "`", """"}
        Return specialstr.IndexOfAny(specialchar)
    End Function

    Public Function recipeparameterdefaults() As Integer
        d_vertol = nom_d_vertol

        i_prepfilltime = 0
        i_prepbleedtime = 0
        i_prepprefillstarttime = 0
        i_prepprefilltime = 0
        i_prepdrainstarttime = 0
        i_prepdraintime = 0
        'd_prepflow = 0
        d_preppressuredrop = 0
        i_preppressuredroptime = 0
        d_preppressure = 0
        i_preprpm1 = 0
        str_prepspeedenable = nom_str_prepspeedenable

        str_flush1enable = nom_str_flush1enable
        'i_flush1filltime = 0
        'i_flush1bleedtime = 0
        d_flush1flow = 0
        d_flush1flowtol = 0
        d_flush1pressure = 0
        i_flush1stabilize = 0
        i_flush1time = 0
        i_flush1rpm = 0
        str_flush1speedenable = nom_str_flush1speedenable

        str_dptest1enable = nom_str_dptest1enable
        'i_dptestfilltime = 0
        'i_dptestbleedtime = 0
        d_dptestflow = 0
        d_dptestflowtol = 0
        d_dptestpressure = 0
        i_dpteststabilize = 0
        i_dptesttime = 0
        d_dptestlowlimit = 0
        d_dptestuplimit = 0
        i_dptestpoints = 0
        i_dptestrpm = 0
        str_dptestspeedenable = nom_str_dptestspeedenable
        str_dptest2enable = nom_str_dptest2enable

        str_flush2enable = nom_str_flush2enable
        'i_flush2filltime = 0
        'i_flush2bleedtime = 0
        d_flush2flow = 0
        d_flush2flowtol = 0
        d_flush2pressure = 0
        i_flush2stabilize = 0
        i_flush2time = 0
        i_flush2rpm = 0
        str_flush2speedenable = nom_str_flush2speedenable

        str_drain1enable = nom_str_drain1enable
        d_drain1pressure = 0
        i_drain1time = 0
        str_drain2enable = nom_str_drain2enable
        d_drain2pressure = 0
        i_drain2time = 0
        str_drain3enable = nom_str_drain3enable
        d_drain3pressure = 0
        i_drain3time = 0
        str_drain4enable = nom_str_drain4enable
        d_drain4pressure = 0
        i_drain4time = 0

        txtbx_RcpCreateVerTol.Text = "0.0" '"CType(d_vertol, String)

        Return 1
    End Function
#End Region

#Region "Form Opening"
    Private Sub FormRecipeManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Always Maximize
        Me.WindowState = FormWindowState.Maximized

        ' Load Version
        lbl_Version.Text = PublicVariables.AppVersion

        ' Load Form Title
        Me.Text = PublicVariables.ProgramTitle & " - " & "Recipe Management"
        lbl_Title.Text = PublicVariables.ProgramTitle

        ' Load User Details
        lbl_Username.Text = PublicVariables.LoginUserName
        lbl_Category.Text = PublicVariables.LoginUserCategoryName

        ' Initialize Defaults
        CurrentTabPage = tabpg_RecipeDetails                     ' Declare Currently Selected Tab Page
        tabctrl_RecipeCtrl.SelectedTab = tabpg_RecipeDetails     ' Select First Tab Page

        Recipetimer.Interval = 1000
        Recipetimer.Enabled = True

        txtbx_PartCreatePartID.Text = "--"
        txtbx_RcpCreateRecipeID.Text = "--"
        txtbx_RcpCreateVerTol.Text = ""

        cmbx_RcpEditPartID.DataSource = Nothing
        cmbx_RcpEditRecipeID.DataSource = Nothing
        cmbx_RcpEditFilterType.DataSource = Nothing
        cmbx_PartCreateFilterType.DataSource = Nothing
        cmbx_RcpCreateFilterType.DataSource = Nothing
        cmbx_PartDeleteFilterType.DataSource = Nothing
        cmbx_RcpDeleteFilterType.DataSource = Nothing
        cmbx_PartCreateJigType.DataSource = Nothing

        cmbx_RcpDeletePartID.DataSource = Nothing
        cmbx_RcpDeleteRecipeID.DataSource = Nothing

        ' DoubleBuffer DataGridView
        Dim dgvArr() As DataGridView = {
                        dgv_RecipeDetails
                    }
        For Each dgv As DataGridView In dgvArr
            DoubleBuffer.DoubleBuffered(dgv, True)
        Next

        'Load Filter Type
        GetFilterType()
        LoadRecipeDetails(0, Nothing, Nothing, Nothing, Nothing)
        GetRecipedetailsfilter()
        GetRecipeID()

        ' Load Fitting Type
        GetFittingType()
    End Sub

    Private Sub FormRecipeManagement_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear Selection
        Me.Select()

        ' Display Form Control
        panel_FormControl.Visible = True
    End Sub
#End Region

#Region "ComboBox and TextBox Data Load and Enable"
    Private Sub GetFilterType()
        Dim FiltercomboSource As New Dictionary(Of String, String)()

        ' Assign Defaults
        FiltercomboSource.Add("0", "-Not Selected-")

        ' Get User Category Table
        Dim dtFilterType As DataTable = SQL.ReadRecords("SELECT id, filter_type FROM FilterType")

        ' Insert Available Record Into Dictionary
        If dtFilterType.Rows.Count > 0 Then
            For i As Integer = 0 To dtFilterType.Rows.Count - 1
                FiltercomboSource.Add(dtFilterType(i)("id"), dtFilterType(i)("filter_type"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each Filtercmbx As ComboBox In {cmbx_RcpEditFilterType, cmbx_PartCreateFilterType, cmbx_RcpCreateFilterType, cmbx_PartDeleteFilterType, cmbx_RcpDeleteFilterType}
            With Filtercmbx
                .DataSource = New BindingSource(FiltercomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
            End With
        Next
    End Sub


    Private Sub GetJigType()
        Dim JigcomboSource As New Dictionary(Of String, String)()

        ' Assign Defaults
        JigcomboSource.Add("0", "-Not Selected-")

        ' Get User Category Table
        Dim dtJigType As DataTable = SQL.ReadRecords("SELECT id, jig_description FROM JigType")

        ' Insert Available Record Into Dictionary
        If dtJigType.Rows.Count > 0 Then
            For i As Integer = 0 To dtJigType.Rows.Count - 1
                JigcomboSource.Add(dtJigType(i)("id"), dtJigType(i)("jig_description"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each Jigcmbx As ComboBox In {cmbx_PartCreateJigType}
            With Jigcmbx
                .DataSource = New BindingSource(JigcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next
    End Sub


    Private Sub GetRecipeType()
        Dim TypecomboSource As New Dictionary(Of String, String)()

        ' Assign Defaults
        TypecomboSource.Add("0", "-Not Selected-")

        ' Get User Category Table
        Dim dtRecipeType As DataTable = SQL.ReadRecords("SELECT id, recipe_type FROM RecipeType")

        ' Insert Available Record Into Dictionary
        If dtRecipeType.Rows.Count > 0 Then
            For i As Integer = 0 To dtRecipeType.Rows.Count - 1
                TypecomboSource.Add(dtRecipeType(i)("id"), dtRecipeType(i)("recipe_type"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each RecipeTypecmbx As ComboBox In {cmbx_RcpCreateType, Cmbx_RcpDupNewType}
            With RecipeTypecmbx
                .DataSource = New BindingSource(TypecomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next
    End Sub

    Private Sub GetRecipeID()
        Dim RecipecomboSource As New Dictionary(Of String, String)()

        ' Assign Defaults
        RecipecomboSource.Add("0", "-Not Selected-")

        ' Get User Category Table
        'Dim dtRecipeID As DataTable = SQL.ReadRecords("SELECT id, recipe_id FROM RecipeTable")
        Dim dtRecipeID As DataTable = SQL.ReadRecords("
            SELECT id, recipe_id FROM RecipeTable t1 
            WHERE recipe_rev = (
                SELECT MAX(recipe_rev)
                FROM RecipeTable t2
                WHERE t1.recipe_id = t2.recipe_id
            )
        ")

        ' Insert Available Record Into Dictionary
        If dtRecipeID.Rows.Count > 0 Then
            For i As Integer = 0 To dtRecipeID.Rows.Count - 1
                RecipecomboSource.Add(dtRecipeID(i)("id"), dtRecipeID(i)("recipe_id"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each RecipeIDcmbx As ComboBox In {cmbx_RcpDupSelRecipe}
            With RecipeIDcmbx
                .DataSource = New BindingSource(RecipecomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next
    End Sub

    Private Sub GetRecipedetailsfilter()
        Dim RcpdetailFilter As String = $"
            SELECT * FROM RecipeTable 
            LEFT JOIN PartTable ON RecipeTable.part_id=PartTable.part_id 
            LEFT JOIN FilterType ON PartTable.filter_type_id=FilterType.id 
            LEFT JOIN JigType ON PartTable.jig_type_id=JigType.id
            LEFT JOIN RecipeType ON RecipeTable.recipe_type_id=RecipeType.id 
            ORDER BY RecipeTable.recipe_id ASC
        "
        Dim dvGetRcpDetail As DataView = SQL.ReadRecords(RcpdetailFilter).DefaultView

        Dim FiltercomboSource As New Dictionary(Of String, String)()
        Dim PartcomboSource As New Dictionary(Of String, String)()
        Dim TypecomboSource As New Dictionary(Of String, String)()
        Dim RecipecomboSource As New Dictionary(Of String, String)()

        ' Assign Defaults
        FiltercomboSource.Add("0", "-Not Selected-")
        PartcomboSource.Add("0", "-Not Selected-")
        TypecomboSource.Add("0", "-Not Selected-")
        RecipecomboSource.Add("0", "-Not Selected-")

        ' Get User Category Table
        Dim dtFilterType As DataTable = dvGetRcpDetail.ToTable(True, "filter_type")

        ' Insert Available Record Into Dictionary
        If dtFilterType.Rows.Count > 0 Then
            For i As Integer = 0 To dtFilterType.Rows.Count - 1
                FiltercomboSource.Add(i + 1, dtFilterType(i)("filter_type"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each Filtercmbx As ComboBox In {cmbx_RcpDetailFilter}
            With Filtercmbx
                .DataSource = New BindingSource(FiltercomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next

        Dim dtPartid As DataTable = dvGetRcpDetail.ToTable(True, "part_id")

        ' Insert Available Record Into Dictionary
        If dtPartid.Rows.Count > 0 Then
            For i As Integer = 0 To dtPartid.Rows.Count - 1
                PartcomboSource.Add(i + 1, dtPartid(i)("part_id"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each Partcmbx As ComboBox In {cmbx_RcpDetailPart}
            With Partcmbx
                .DataSource = New BindingSource(PartcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next

        Dim dttype As DataTable = dvGetRcpDetail.ToTable(True, "recipe_type")

        ' Insert Available Record Into Dictionary
        If dttype.Rows.Count > 0 Then
            For i As Integer = 0 To dttype.Rows.Count - 1
                TypecomboSource.Add(i + 1, dttype(i)("recipe_type"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each Filtercmbx As ComboBox In {cmbx_RcpDetailType}
            With Filtercmbx
                .DataSource = New BindingSource(TypecomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next

        Dim dtrecipe As DataTable = dvGetRcpDetail.ToTable(True, "recipe_id")

        ' Insert Available Record Into Dictionary
        If dtrecipe.Rows.Count > 0 Then
            For i As Integer = 0 To dtrecipe.Rows.Count - 1
                RecipecomboSource.Add(i + 1, dtrecipe(i)("recipe_id"))
            Next
        End If

        ' Bind ComboBox To Dictionary
        For Each Filtercmbx As ComboBox In {cmbx_RcpDetailRecipeID}
            With Filtercmbx
                .DataSource = New BindingSource(RecipecomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Next
    End Sub

    Private Sub FilterTypecmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_RcpEditFilterType.SelectedIndexChanged, cmbx_PartCreateFilterType.SelectedIndexChanged, cmbx_RcpCreateFilterType.SelectedIndexChanged, cmbx_PartDeleteFilterType.SelectedIndexChanged, cmbx_RcpDeleteFilterType.SelectedIndexChanged
        Dim cmbxFilterSelected As ComboBox = DirectCast(sender, ComboBox)

        Dim dtPartID As DataTable = SQL.ReadRecords("SELECT * FROM PartTable WHERE filter_type_id = '" & cmbxFilterSelected.SelectedIndex & "'")
        Dim PartIDgcomboSource As New Dictionary(Of String, String)()
        PartIDgcomboSource.Add("0", "-Not Selected-")
        If dtPartID.Rows.Count > 0 Then
            For i As Integer = 0 To dtPartID.Rows.Count - 1
                PartIDgcomboSource.Add(dtPartID(i)("id"), dtPartID(i)("part_id"))
            Next
        End If

        If cmbxFilterSelected Is cmbx_RcpEditFilterType Then
            With cmbx_RcpEditPartID
                .DataSource = New BindingSource(PartIDgcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                    .Enabled = False
                End If
            End With
            If cmbxFilterSelected.SelectedIndex > 0 Then
                cmbx_RcpEditPartID.Enabled = True
            Else
                cmbx_RcpEditPartID.SelectedIndex = 0
                cmbx_RcpEditPartID.Enabled = False
            End If
        End If

        If cmbxFilterSelected Is cmbx_PartCreateFilterType Then
            GetJigType()
            If cmbxFilterSelected.SelectedIndex > 0 Then
                cmbx_PartCreateJigType.Enabled = True

            Else
                cmbx_PartCreateJigType.SelectedIndex = 0
                cmbx_PartCreateJigType.Enabled = False
            End If
        End If

        If cmbxFilterSelected Is cmbx_RcpCreateFilterType Then
            With cmbx_RcpCreatePartID
                .DataSource = New BindingSource(PartIDgcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                    .Enabled = False
                End If
            End With
            If cmbxFilterSelected.SelectedIndex > 0 Then
                cmbx_RcpCreatePartID.Enabled = True
            Else
                cmbx_RcpCreatePartID.SelectedIndex = 0
                cmbx_RcpCreatePartID.Enabled = False
            End If
        End If

        If cmbxFilterSelected Is cmbx_PartDeleteFilterType Then
            With cmbx_PartDeletePartID
                .DataSource = New BindingSource(PartIDgcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
            If cmbxFilterSelected.SelectedIndex > 0 Then
                cmbx_PartDeletePartID.Enabled = True
            Else
                cmbx_PartDeletePartID.SelectedIndex = 0
                cmbx_PartDeletePartID.Enabled = False
            End If
        End If

        If cmbxFilterSelected Is cmbx_RcpDeleteFilterType Then
            With cmbx_RcpDeletePartID
                .DataSource = New BindingSource(PartIDgcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
            If cmbxFilterSelected.SelectedIndex > 0 Then
                cmbx_RcpDeletePartID.Enabled = True
            Else
                cmbx_RcpDeletePartID.SelectedIndex = 0
                cmbx_RcpDeletePartID.Enabled = False
            End If
        End If
    End Sub

    Private Sub PartIDcmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_RcpEditPartID.SelectedIndexChanged, cmbx_RcpCreatePartID.SelectedIndexChanged, cmbx_RcpDeletePartID.SelectedIndexChanged
        Dim cmbxPartSelected As ComboBox = DirectCast(sender, ComboBox)

        'Dim dtRecipeID As DataTable = SQL.ReadRecords("SELECT * FROM RecipeTable WHERE part_id = '" + cmbxPartSelected.Text + "'")
        Dim dtRecipeID As DataTable = SQL.ReadRecords($"
            SELECT * FROM RecipeTable t1
            WHERE recipe_rev = (
                SELECT MAX(recipe_rev)
                FROM RecipeTable t2
                WHERE t1.recipe_id = t2.recipe_id
            ) 
            AND part_id='{cmbxPartSelected.Text}'
        ")

        Dim RecipeIDgcomboSource As New Dictionary(Of String, String)()
        RecipeIDgcomboSource.Add("0", "-Not Selected-")
        If dtRecipeID.Rows.Count > 0 Then
            For i As Integer = 0 To dtRecipeID.Rows.Count - 1
                RecipeIDgcomboSource.Add(dtRecipeID(i)("id"), dtRecipeID(i)("recipe_id"))
            Next
        End If

        If cmbxPartSelected Is cmbx_RcpEditPartID Then
            With cmbx_RcpEditRecipeID
                .DataSource = New BindingSource(RecipeIDgcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                    .Enabled = False
                End If
            End With

            If cmbxPartSelected.SelectedIndex > 0 Then
                cmbx_RcpEditRecipeID.Enabled = True
                If cmbx_RcpEditRecipeID.Items.Count <= 1 Then
                    RecipeMessage(35, cmbx_RcpEditPartID.Text)
                End If
            Else
                cmbx_RcpEditRecipeID.SelectedIndex = 0
                cmbx_RcpEditRecipeID.Enabled = False
            End If
        End If

        If cmbxPartSelected Is cmbx_RcpCreatePartID Then
            GetRecipeType()
            If cmbxPartSelected.SelectedIndex > 0 Then
                cmbx_RcpCreateType.Enabled = True
            Else
                cmbx_RcpCreateType.SelectedIndex = 0
                cmbx_RcpCreateType.Enabled = False
            End If
        End If

        If cmbxPartSelected Is cmbx_RcpDeletePartID Then
            With cmbx_RcpDeleteRecipeID
                .DataSource = New BindingSource(RecipeIDgcomboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With

            If cmbxPartSelected.SelectedIndex > 0 Then
                cmbx_RcpDeleteRecipeID.Enabled = True
                If cmbx_RcpDeleteRecipeID.Items.Count <= 1 Then
                    RecipeMessage(27, cmbx_RcpDeletePartID.Text)
                End If
            Else
                cmbx_RcpDeleteRecipeID.SelectedIndex = 0
                cmbx_RcpDeleteRecipeID.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmbx_PartCreateJigType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_PartCreateJigType.SelectedIndexChanged
        If cmbx_PartCreateJigType.SelectedIndex > 0 Then
            txtbx_PartCreatePartID.Enabled = True
            txtbx_PartCreatePartID.Text = ""
            btnPartIDCreate.Enabled = True
        Else
            txtbx_PartCreatePartID.Text = "--"
            txtbx_PartCreatePartID.Enabled = False
            btnPartIDCreate.Enabled = False
        End If
    End Sub

    Private Sub cmbx_RcpCreateType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_RcpCreateType.SelectedIndexChanged
        If cmbx_RcpCreateType.SelectedIndex > 0 Then
            txtbx_RcpCreateRecipeID.Enabled = True
            txtbx_RcpCreateRecipeID.Text = ""
            ' Load defaults and enable to the recipe parameters
            'txtbx_RcpCreateVerTol.Enabled = True

            checkbx_CreateFlush1.Enabled = True
            checkbx_CreateDPTest1.Enabled = True
            checkbx_CreateDPTest2.Enabled = False
            checkbx_CreateFlush2.Enabled = True
            'checkbx_CreateDrain1.Enabled = True
            checkbx_CreateDrain2.Enabled = True
            'checkbx_CreateDrain3.Enabled = True

            ComboBox3.Enabled = True
            ComboBox4.Enabled = True
            ComboBox6.Enabled = True

            ' For Preparation Sequence
            txtbx_RcpCreatePrepFill.Enabled = True
            'txtbx_RcpCreatePrepBleed.Enabled = True
            'txtbx_RcpCreatePrepFlow.Enabled = True
            'txtbx_RcpCreatePrepFlowTol.Enabled = True
            txtbx_RcpCreatePrepPressureDrop.Enabled = True
            txtbx_RcpCreatePrepPressureDrop.Enabled = True
            txtbx_RcpCreatePrepPressureDropTime.Enabled = True
            txtbx_RcpCreatePrepPressure.Enabled = True
            'txtbx_RcpCreatePrepPrefillStartTime.Enabled = True
            'txtbx_RcpCreatePrepPrefillTime.Enabled = True
            'cmbx_RcpCreatePrepPumpMode.Enabled = True
            'cmbx_RcpCreatePrepPumpMode.SelectedIndex = 0
            'txtbx_RcpCreatePrepRPM1.Enabled = True
            'txtbx_RcpCreatePrepRPM2.Enabled = True
            txtbx_RcpCreatePrepRPM.Enabled = True
            panel_RcpCreatePrepPumpMode.Enabled = True

            recipeparameterdefaults()

            btn_RecipeIDCreate.Enabled = True

            If Not DirectCast(cmbx_RcpCreateFilterType.SelectedItem, KeyValuePair(Of String, String)).Value = "Cal. Master" Then
                txtbx_RcpCreateVerTol.Enabled = True
                checkbx_CreateDrain1.Enabled = True
                checkbx_CreateDrain3.Enabled = True
                checkbx_CreateDrain4.Enabled = True
                txtbx_RcpCreatePrepBleed.Enabled = True
                txtbx_RcpCreatePrepPrefillStartTime.Enabled = True
                txtbx_RcpCreatePrepPrefillTime.Enabled = True
                txtbx_RcpCreatePrepDrainStartTime.Enabled = True
                txtbx_RcpCreatePrepDrainTime.Enabled = True
                txtbx_RcpCreateVerTol.Text = d_vertol.ToString("F1") 'CType(d_vertol, String)
            End If

            i_prepfilltime = nom_i_prepfilltime
            i_prepbleedtime = nom_i_prepbleedtime
            'd_prepflow = nom_d_prepflow
            'd_prepflowtol = nom_d_prepflowtol
            d_preppressure = nom_d_preppressure
            d_preppressuredrop = nom_d_preppressuredrop
            i_preppressuredroptime = nom_i_preppressuredroptime
            i_prepprefillstarttime = nom_i_prepprefillstarttime
            i_prepprefilltime = nom_i_prepprefilltime
            'i_preprpm1 = 0
            'i_preprpm2 = 0
            i_preprpm1 = nom_i_preprpm1
            str_prepspeedenable = "Enable"

            txtbx_RcpCreatePrepFill.Text = CType(i_prepfilltime, String)
            txtbx_RcpCreatePrepBleed.Text = CType(i_prepbleedtime, String)
            'txtbx_RcpCreatePrepFlow.Text = d_prepflow.ToString("F1") 'CType(d_prepflow, String)
            'txtbx_RcpCreatePrepFlowTol.Text = d_prepflowtol.ToString("F1") 'CType(d_prepflowtol, String)
            txtbx_RcpCreatePrepPressureDrop.Text = d_preppressuredrop.ToString("F1") 'CType(d_preppressuredrop, String)
            txtbx_RcpCreatePrepPressureDropTime.Text = CType(i_preppressuredroptime, String)
            txtbx_RcpCreatePrepPressure.Text = d_preppressure.ToString("F1") 'CType(d_preppressure, String)
            txtbx_RcpCreatePrepPrefillStartTime.Text = CType(i_prepprefillstarttime, String)
            txtbx_RcpCreatePrepPrefillTime.Text = CType(i_prepprefilltime, String)
            txtbx_RcpCreatePrepDrainStartTime.Text = CType(i_prepdrainstarttime, String)
            txtbx_RcpCreatePrepDrainTime.Text = CType(i_prepdraintime, String)
            'rdbtn_RcpCreatePrepPumpSpeed.Checked = True
            'rdbtn_RcpCreatePrepPumpProcess.Checked = False
            txtbx_RcpCreatePrepRPM.Text = CType(i_preprpm1, String)
            TextBox2.Enabled = True
            txtbx_RcpCreateDuration_TextChanged(Nothing, Nothing)
        Else
            txtbx_RcpCreateRecipeID.Text = "--"
            txtbx_RcpCreateRecipeID.Enabled = False
            ' clear defaults and disable the recipe parameters
            txtbx_RcpCreateVerTol.Text = Nothing

            txtbx_RcpCreateVerTol.Enabled = False

            checkbx_CreateFlush1.Checked = False
            checkbx_CreateDPTest1.Checked = False
            checkbx_CreateDPTest2.Checked = False
            checkbx_CreateFlush2.Checked = False
            checkbx_CreateDrain1.Checked = False
            checkbx_CreateDrain2.Checked = False
            checkbx_CreateDrain3.Checked = False
            checkbx_CreateDrain4.Checked = False
            checkbx_CreateFlush1.Enabled = False
            checkbx_CreateDPTest1.Enabled = False
            checkbx_CreateDPTest2.Enabled = False
            checkbx_CreateFlush2.Enabled = False
            checkbx_CreateDrain1.Enabled = False
            checkbx_CreateDrain2.Enabled = False
            checkbx_CreateDrain3.Enabled = False
            checkbx_CreateDrain4.Enabled = False
            ComboBox3.Enabled = False
            ComboBox4.Enabled = False
            ComboBox6.Enabled = False
            txtbx_RcpCreatePrepFill.Enabled = False
            txtbx_RcpCreatePrepDrainStartTime.Enabled = False
            txtbx_RcpCreatePrepDrainTime.Enabled = False
            txtbx_RcpCreatePrepBleed.Enabled = False
            txtbx_RcpCreatePrepPressureDrop.Enabled = False
            txtbx_RcpCreatePrepPressureDropTime.Enabled = False
            txtbx_RcpCreatePrepPressure.Enabled = False
            txtbx_RcpCreatePrepPrefillStartTime.Enabled = False
            txtbx_RcpCreatePrepPrefillTime.Enabled = False
            'btn_RcpCreateCal.Enabled = False
            'cmbx_RcpCreatePrepPumpMode.Enabled = False
            txtbx_RcpCreatePrepRPM.Enabled = False
            'txtbx_RcpCreatePrepRPM2.Enabled = False
            panel_RcpCreatePrepPumpMode.Enabled = False
            'txtbx_RcpCreateFlush1Fill.Enabled = False
            'txtbx_RcpCreateFlush1Bleed.Enabled = False
            txtbx_RcpCreateFlush1Flow.Enabled = False
            txtbx_RcpCreateFlush1FlowTol.Enabled = False
            'txtbx_RcpCreateFlush1Pressure.Enabled = False
            txtbx_RcpCreateFlush1Stabilize.Enabled = False
            txtbx_RcpCreateFlush1Time.Enabled = False
            txtbx_RcpCreateFlush1Pressure.Enabled = False
            panel_RcpCreateFlush1PumpMode.Enabled = False
            txtbx_RcpCreateFlush1RPM.Enabled = False
            'txtbx_RcpCreateDPFill.Enabled = False
            'txtbx_RcpCreateDPBleed.Enabled = False
            txtbx_RcpCreateDPFlow.Enabled = False
            txtbx_RcpCreateDPFlowTol.Enabled = False
            'txtbx_RcpCreateDPPressure.Enabled = False
            txtbx_RcpCreateDPStabilize.Enabled = False
            txtbx_RcpCreateDPTime.Enabled = False
            'txtbx_RcpCreatePrepFlow.Enabled = False
            'txtbx_RcpCreatePrepFlowTol.Enabled = False
            txtbx_RcpCreateDPPressure.Enabled = False
            txtbx_RcpCreateDPLowLimit.Enabled = False
            txtbx_RcpCreateDPUpLimit.Enabled = False
            txtbx_RcpCreateDPPoints.Enabled = False
            panel_RcpCreateDPTestPumpMode.Enabled = False
            txtbx_RcpCreateDPTestRPM.Enabled = False
            'txtbx_RcpCreateFlush2Fill.Enabled = False
            'txtbx_RcpCreateFlush2Bleed.Enabled = False
            txtbx_RcpCreateFlush2Flow.Enabled = False
            txtbx_RcpCreateFlush2FlowTol.Enabled = False
            'txtbx_RcpCreateFlush2Pressure.Enabled = False
            txtbx_RcpCreateFlush2Stabilize.Enabled = False
            txtbx_RcpCreateFlush2Time.Enabled = False
            txtbx_RcpCreateFlush2Pressure.Enabled = False
            panel_RcpCreateFlush2PumpMode.Enabled = False
            txtbx_RcpCreateFlush2RPM.Enabled = False

            txtbx_RcpCreateDrain1Pressure.Enabled = False
            txtbx_RcpCreateDrain1Time.Enabled = False
            txtbx_RcpCreateDrain2Pressure.Enabled = False
            txtbx_RcpCreateDrain2Time.Enabled = False
            txtbx_RcpCreateDrain3Pressure.Enabled = False
            txtbx_RcpCreateDrain3Time.Enabled = False
            txtbx_RcpCreateDrain4Pressure.Enabled = False
            txtbx_RcpCreateDrain4Time.Enabled = False
            btn_RecipeIDCreate.Enabled = False

            i_prepfilltime = 0
            i_prepbleedtime = 0
            'd_prepflow = 0
            d_preppressure = 0
            d_preppressuredrop = 0
            i_preppressuredroptime = 0
            i_prepprefillstarttime = 0
            i_prepprefilltime = 0
            'i_preprpm1 = 0
            'i_preprpm2 = 0
            str_prepspeedenable = "Disable"

            txtbx_RcpCreatePrepFill.Text = Nothing
            txtbx_RcpCreatePrepBleed.Text = Nothing
            'txtbx_RcpCreatePrepFlow.Text = Nothing
            'txtbx_RcpCreatePrepFlowTol.Text = Nothing
            txtbx_RcpCreatePrepPressureDrop.Text = Nothing
            txtbx_RcpCreatePrepPressureDropTime.Text = Nothing
            txtbx_RcpCreatePrepPressure.Text = Nothing
            txtbx_RcpCreatePrepPrefillStartTime.Text = Nothing
            txtbx_RcpCreatePrepPrefillTime.Text = Nothing
            txtbx_RcpCreatePrepDrainStartTime.Text = Nothing
            txtbx_RcpCreatePrepDrainTime.Text = Nothing
            'cmbx_RcpCreatePrepPumpMode.SelectedItem = Nothing
            txtbx_RcpCreatePrepRPM.Text = Nothing
            'txtbx_RcpCreatePrepRPM2.Text = Nothing

            rdbtn_RcpCreatePrepPumpSpeed.Checked = True
            rdbtn_RcpCreateFlush1PumpProcess.Checked = True
            rdbtn_RcpCreateFlush2PumpProcess.Checked = True
            rdbtn_RcpCreateDPTestPumpProcess.Checked = True

            TextBox2.Enabled = False
        End If
    End Sub
#End Region

#Region "Part ID Creation"
    Private Sub btnPartIDCreate_Click(sender As Object, e As EventArgs) Handles btnPartIDCreate.Click
        ' Declare Parameters
        Dim cmbxFilterType As ComboBox = cmbx_PartCreateFilterType
        Dim cmbxJigType As ComboBox = cmbx_PartCreateJigType

        Dim FilterTypeID As Integer = cmbxFilterType.SelectedIndex
        Dim JigTypeID As Integer = cmbxJigType.SelectedIndex
        Dim PartID As String = Formatstring(txtbx_PartCreatePartID.Text)
        Dim onContinue As Boolean = True

        'Check Empty fields
        If onContinue = True Then
            If FilterTypeID = 0 Then
                RecipeMessage(1)
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If JigTypeID = 0 Then
                RecipeMessage(2)
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If PartID.Length = 0 Then
                RecipeMessage(3)
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If PartID.Length < PublicVariables.PartIdLenLow Then
                RecipeMessage(12, $"Part ID should be greater than {PublicVariables.PartIdLenLow} Characters, Try Again")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If PartID.Length > PublicVariables.PartIdLenHigh Then
                RecipeMessage(12, $"Part ID should be lower than {PublicVariables.PartIdLenHigh} Characters, Try Again")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If Checkspecial(PartID) <> -1 Then
                RecipeMessage(13)
                onContinue = False
            End If
        End If

        If onContinue = True Then
            Dim dtPartIDcheck As DataTable = SQL.ReadRecords("SELECT * FROM PartTable WHERE part_id = '" + PartID + "'")

            If dtPartIDcheck.Rows.Count = 0 Then
                Dim partParameter As New Dictionary(Of String, Object) From {
                    {"part_id", PartID},
                    {"filter_type_id", FilterTypeID},
                    {"jig_type_id", JigTypeID},
                    {"user_created", PublicVariables.LoginUserName}
                }
                If SQL.InsertRecord("PartTable", partParameter) = 1 Then
                    RecipeMessage(9)

                    ' Event Log
                    Dim FilterTypeValue As String = DirectCast(cmbxFilterType.SelectedItem, KeyValuePair(Of String, String)).Value
                    Dim JigTypeValue As String = DirectCast(cmbxJigType.SelectedItem, KeyValuePair(Of String, String)).Value
                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Part ID Creation - Part ID ({FilterTypeValue}/{JigTypeValue}/{PartID}) Created")

                    cmbxFilterType.SelectedIndex = 0
                Else
                    RecipeMessage(11)
                    onContinue = False
                End If
            Else
                RecipeMessage(7)
                onContinue = False
            End If
        End If
    End Sub
#End Region

#Region "Recipe Parameter Textbox Enable/Disable"
    Private Sub checkbx_CreateFlush1_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_CreateFlush1.CheckedChanged

        If checkbx_CreateFlush1.Checked = True Then
            'txtbx_RcpCreateFlush1Fill.Enabled = True
            'txtbx_RcpCreateFlush1Bleed.Enabled = True
            txtbx_RcpCreateFlush1Flow.Enabled = True
            txtbx_RcpCreateFlush1FlowTol.Enabled = True
            txtbx_RcpCreateFlush1Pressure.Enabled = True
            txtbx_RcpCreateFlush1Stabilize.Enabled = True
            txtbx_RcpCreateFlush1Time.Enabled = True

            'Select Case cmbx_RcpCreatePrepPumpMode.SelectedIndex
            '    Case 0
            '        With txtbx_RcpCreateFlush1Flow
            '            .Enabled = True
            '            .Text = nom_d_flush1flow.ToString("F1")
            '        End With
            '        With txtbx_RcpCreateFlush1FlowTol
            '            .Enabled = True
            '            .Text = nom_d_flush1flowtol.ToString("F1")
            '        End With
            '        With txtbx_RcpCreateFlush1RPM
            '            .Enabled = False
            '            .Text = 0
            '        End With

            '        d_flush1flow = nom_d_flush1flow
            '        d_flush1flowtol = nom_d_flush1flowtol
            '        i_flush1rpm = 0
            '    Case 1
            '        With txtbx_RcpCreateFlush1Flow
            '            .Enabled = False
            '            .Text = d_prepflow.ToString("F1") '"0.0"
            '        End With
            '        With txtbx_RcpCreateFlush1FlowTol
            '            .Enabled = False
            '            .Text = "0.0"
            '        End With
            '        With txtbx_RcpCreateFlush1RPM
            '            .Enabled = True
            '            .Text = nom_i_flush1rpm
            '        End With

            '        d_flush1flow = 0
            '        d_flush1flowtol = 0
            '        i_flush1rpm = nom_i_flush1rpm
            'End Select

            panel_RcpCreateFlush1PumpMode.Enabled = True
            If rdbtn_RcpCreateFlush1PumpSpeed.Checked = True Then
                With txtbx_RcpCreateFlush2RPM
                    .Enabled = True
                    .Text = nom_i_flush2rpm
                End With
                i_flush2rpm = nom_i_flush2rpm
            End If

            'i_flush1filltime = nom_i_flush1filltime
            'i_flush1bleedtime = nom_i_flush1bleedtime
            d_flush1flow = nom_d_flush1flow
            d_flush1flowtol = nom_d_flush1flowtol
            d_flush1pressure = nom_d_flush1pressure
            i_flush1stabilize = nom_i_flush1stabilize
            i_flush1time = nom_i_flush1time

            str_flush1enable = "Enable"
            'txtbx_RcpCreateFlush1Fill.Text = CType(i_flush1filltime, String)
            'txtbx_RcpCreateFlush1Bleed.Text = CType(i_flush1bleedtime, String)
            txtbx_RcpCreateFlush1Flow.Text = d_flush1flow.ToString("F1") 'CType(d_flush1flow, String)
            txtbx_RcpCreateFlush1FlowTol.Text = d_flush1flowtol.ToString("F1") 'CType(d_flush1flowtol, String)
            txtbx_RcpCreateFlush1Pressure.Text = d_flush1pressure.ToString("F1") 'CType(d_flush1pressure, String)
            txtbx_RcpCreateFlush1Stabilize.Text = CType(i_flush1stabilize, String)
            txtbx_RcpCreateFlush1Time.Text = CType(i_flush1time, String)
        Else
            'txtbx_RcpCreateFlush1Fill.Enabled = False
            'txtbx_RcpCreateFlush1Bleed.Enabled = False
            txtbx_RcpCreateFlush1Flow.Enabled = False
            txtbx_RcpCreateFlush1FlowTol.Enabled = False
            txtbx_RcpCreateFlush1Pressure.Enabled = False
            txtbx_RcpCreateFlush1Stabilize.Enabled = False
            txtbx_RcpCreateFlush1Time.Enabled = False
            panel_RcpCreateFlush1PumpMode.Enabled = False
            txtbx_RcpCreateFlush1RPM.Enabled = False

            ' Load Zero if the Flush-1 is not enabled
            'i_flush1filltime = 0
            'i_flush1bleedtime = 0
            d_flush1flow = 0.0
            d_flush1flowtol = 0.0
            d_flush1pressure = 0.0
            i_flush1stabilize = 0
            i_flush1time = 0
            i_flush1rpm = 0

            str_flush1enable = "Disable"
            'txtbx_RcpCreateFlush1Fill.Text = Nothing
            'txtbx_RcpCreateFlush1Bleed.Text = Nothing
            txtbx_RcpCreateFlush1Flow.Text = Nothing
            txtbx_RcpCreateFlush1FlowTol.Text = Nothing
            txtbx_RcpCreateFlush1Pressure.Text = Nothing
            txtbx_RcpCreateFlush1Stabilize.Text = Nothing
            txtbx_RcpCreateFlush1Time.Text = Nothing
            txtbx_RcpCreateFlush1RPM.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_CreateDPTest1_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_CreateDPTest1.CheckedChanged
        If checkbx_CreateDPTest1.Checked = True Then
            'txtbx_RcpCreateDPFill.Enabled = True
            'txtbx_RcpCreateDPBleed.Enabled = True
            txtbx_RcpCreateDPFlow.Enabled = True
            txtbx_RcpCreateDPFlowTol.Enabled = True
            txtbx_RcpCreateDPPressure.Enabled = True
            txtbx_RcpCreateDPStabilize.Enabled = True
            txtbx_RcpCreateDPTime.Enabled = True
            txtbx_RcpCreateDPLowLimit.Enabled = True
            txtbx_RcpCreateDPUpLimit.Enabled = True
            txtbx_RcpCreateDPPoints.Enabled = True
            checkbx_CreateDPTest2.Enabled = True

            'Select Case cmbx_RcpCreatePrepPumpMode.SelectedIndex
            '    Case 0
            '        With txtbx_RcpCreateDPFlow
            '            .Enabled = True
            '            .Text = nom_d_dptestflow.ToString("F1")
            '        End With
            '        With txtbx_RcpCreateDPFlowTol
            '            .Enabled = True
            '            .Text = nom_d_dptestflowtol.ToString("F1")
            '        End With
            '        With txtbx_RcpCreateDPTestRPM
            '            .Enabled = False
            '            .Text = 0
            '        End With

            '        d_dptestflow = nom_d_dptestflow
            '        d_dptestflowtol = nom_d_dptestflowtol
            '        i_dptestrpm = 0
            '    Case 1
            '        With txtbx_RcpCreateDPFlow
            '            .Enabled = False
            '            .Text = d_prepflow.ToString("F1") '"0.0"
            '        End With
            '        With txtbx_RcpCreateDPFlowTol
            '            .Enabled = False
            '            .Text = "0.0"
            '        End With
            '        With txtbx_RcpCreateDPTestRPM
            '            .Enabled = True
            '            .Text = nom_i_dptestrpm
            '        End With

            '        d_dptestflow = 0
            '        d_dptestflowtol = 0
            '        i_dptestrpm = nom_i_dptestrpm
            'End Select

            panel_RcpCreateDPTestPumpMode.Enabled = True
            If rdbtn_RcpCreateDPTestPumpSpeed.Checked = True Then
                With txtbx_RcpCreateDPTestRPM
                    .Enabled = True
                    .Text = nom_i_dptestrpm
                End With
                i_dptestrpm = nom_i_dptestrpm
            End If

            'i_dptestfilltime = nom_i_dptestfilltime
            'i_dptestbleedtime = nom_i_dptestbleedtime
            d_dptestflow = nom_d_dptestflow
            d_dptestflowtol = nom_d_dptestflowtol
            d_dptestpressure = nom_d_dptestpressure
            i_dpteststabilize = nom_i_dpteststabilize
            i_dptesttime = nom_i_dptesttime
            d_dptestlowlimit = nom_d_dptestlowlimit
            d_dptestuplimit = nom_d_dptestuplimit
            i_dptestpoints = nom_i_dptestpoints

            str_dptest1enable = "Enable"
            'txtbx_RcpCreateDPFill.Text = CType(i_dptestfilltime, String)
            'txtbx_RcpCreateDPBleed.Text = CType(i_dptestbleedtime, String)
            txtbx_RcpCreateDPFlow.Text = d_dptestflow.ToString("F1") 'CType(d_dptestflow, String)
            txtbx_RcpCreateDPFlowTol.Text = d_dptestflowtol.ToString("F1") 'CType(d_dptestflowtol, String)
            txtbx_RcpCreateDPPressure.Text = d_dptestpressure.ToString("F1") 'CType(d_dptestpressure, String)
            txtbx_RcpCreateDPStabilize.Text = CType(i_dpteststabilize, String)
            txtbx_RcpCreateDPTime.Text = CType(i_dptesttime, String)
            txtbx_RcpCreateDPLowLimit.Text = d_dptestlowlimit.ToString("F1") 'CType(d_dptestlowlimit, String)
            txtbx_RcpCreateDPUpLimit.Text = d_dptestuplimit.ToString("F1") 'CType(d_dptestuplimit, String)
            txtbx_RcpCreateDPPoints.Text = CType(i_dptestpoints, String)
        Else
            'txtbx_RcpCreateDPFill.Enabled = False
            'txtbx_RcpCreateDPBleed.Enabled = False
            txtbx_RcpCreateDPFlow.Enabled = False
            txtbx_RcpCreateDPFlowTol.Enabled = False
            txtbx_RcpCreateDPPressure.Enabled = False
            txtbx_RcpCreateDPStabilize.Enabled = False
            txtbx_RcpCreateDPTime.Enabled = False
            txtbx_RcpCreateDPLowLimit.Enabled = False
            txtbx_RcpCreateDPUpLimit.Enabled = False
            checkbx_CreateDPTest2.Enabled = False
            txtbx_RcpCreateDPPoints.Enabled = False
            panel_RcpCreateDPTestPumpMode.Enabled = False
            txtbx_RcpCreateDPTestRPM.Enabled = False

            'i_dptestfilltime = 0
            'i_dptestbleedtime = 0
            d_dptestflow = 0.0
            d_dptestflowtol = 0.0
            d_dptestpressure = 0.0
            i_dpteststabilize = 0
            i_dptesttime = 0
            d_dptestlowlimit = 0.0
            d_dptestuplimit = 0.0
            i_dptestpoints = 0
            i_dptestrpm = 0

            str_dptest1enable = "Disable"
            'txtbx_RcpCreateDPFill.Text = Nothing
            'txtbx_RcpCreateDPBleed.Text = Nothing
            txtbx_RcpCreateDPFlow.Text = Nothing
            txtbx_RcpCreateDPFlowTol.Text = Nothing
            txtbx_RcpCreateDPPressure.Text = Nothing
            txtbx_RcpCreateDPStabilize.Text = Nothing
            txtbx_RcpCreateDPTime.Text = Nothing
            txtbx_RcpCreateDPLowLimit.Text = Nothing
            txtbx_RcpCreateDPUpLimit.Text = Nothing
            txtbx_RcpCreateDPPoints.Text = Nothing
            txtbx_RcpCreateDPTestRPM.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_CreateFlush2_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_CreateFlush2.CheckedChanged
        If checkbx_CreateFlush2.Checked = True Then
            'txtbx_RcpCreateFlush2Fill.Enabled = True
            'txtbx_RcpCreateFlush2Bleed.Enabled = True
            txtbx_RcpCreateFlush2Flow.Enabled = True
            txtbx_RcpCreateFlush2FlowTol.Enabled = True
            txtbx_RcpCreateFlush2Pressure.Enabled = True
            txtbx_RcpCreateFlush2Stabilize.Enabled = True
            txtbx_RcpCreateFlush2Time.Enabled = True

            'Select Case cmbx_RcpCreatePrepPumpMode.SelectedIndex
            '    Case 0
            '        With txtbx_RcpCreateFlush2Flow
            '            .Enabled = True
            '            .Text = nom_d_flush2flow.ToString("F1")
            '        End With
            '        With txtbx_RcpCreateFlush2FlowTol
            '            .Enabled = True
            '            .Text = nom_d_flush2flowtol.ToString("F1")
            '        End With
            '        With txtbx_RcpCreateFlush2RPM
            '            .Enabled = False
            '            .Text = 0
            '        End With

            '        d_flush2flow = nom_d_flush2flow
            '        d_flush2flowtol = nom_d_flush2flowtol
            '        i_flush2rpm = 0
            '    Case 1
            '        With txtbx_RcpCreateFlush2Flow
            '            .Enabled = False
            '            .Text = d_prepflow.ToString("F1") '"0.0"
            '        End With
            '        With txtbx_RcpCreateFlush2FlowTol
            '            .Enabled = False
            '            .Text = "0.0"
            '        End With
            '        With txtbx_RcpCreateFlush2RPM
            '            .Enabled = True
            '            .Text = nom_i_flush2rpm
            '        End With

            '        d_flush2flow = 0
            '        d_flush2flowtol = 0
            '        i_flush2rpm = nom_i_flush2rpm
            'End Select

            panel_RcpCreateFlush2PumpMode.Enabled = True
            If rdbtn_RcpCreateFlush2PumpSpeed.Checked = True Then
                With txtbx_RcpCreateFlush2RPM
                    .Enabled = True
                    .Text = nom_i_flush2rpm
                End With
                i_flush2rpm = nom_i_flush2rpm
            End If

            'i_flush2filltime = nom_i_flush2filltime
            'i_flush2bleedtime = nom_i_flush2bleedtime
            d_flush2flow = nom_d_flush2flow
            d_flush2flowtol = nom_d_flush2flowtol
            d_flush2pressure = nom_d_flush2pressure
            i_flush2stabilize = nom_i_flush2stabilize
            i_flush2time = nom_i_flush2time

            str_flush2enable = "Enable"
            'txtbx_RcpCreateFlush2Fill.Text = CType(i_flush2filltime, String)
            'txtbx_RcpCreateFlush2Bleed.Text = CType(i_flush2bleedtime, String)
            txtbx_RcpCreateFlush2Flow.Text = d_flush2flow.ToString("F1") 'CType(d_flush2flow, String)
            txtbx_RcpCreateFlush2FlowTol.Text = d_flush2flowtol.ToString("F1") 'CType(d_flush2flowtol, String)
            txtbx_RcpCreateFlush2Pressure.Text = d_flush2pressure.ToString("F1") 'CType(d_flush2pressure, String)
            txtbx_RcpCreateFlush2Stabilize.Text = CType(i_flush2stabilize, String)
            txtbx_RcpCreateFlush2Time.Text = CType(i_flush2time, String)
        Else
            'txtbx_RcpCreateFlush2Fill.Enabled = False
            'txtbx_RcpCreateFlush2Bleed.Enabled = False
            txtbx_RcpCreateFlush2Flow.Enabled = False
            txtbx_RcpCreateFlush2FlowTol.Enabled = False
            txtbx_RcpCreateFlush2Pressure.Enabled = False
            txtbx_RcpCreateFlush2Stabilize.Enabled = False
            txtbx_RcpCreateFlush2Time.Enabled = False
            panel_RcpCreateFlush2PumpMode.Enabled = False
            txtbx_RcpCreateFlush2RPM.Enabled = False

            'i_flush2filltime = 0
            'i_flush2bleedtime = 0
            d_flush2flow = 0.0
            d_flush2flowtol = 0.0
            d_flush2pressure = 0.0
            i_flush2stabilize = 0
            i_flush2time = 0
            i_flush2rpm = 0

            str_flush2enable = "Disable"
            'txtbx_RcpCreateFlush2Fill.Text = Nothing
            'txtbx_RcpCreateFlush2Bleed.Text = Nothing
            txtbx_RcpCreateFlush2Flow.Text = Nothing
            txtbx_RcpCreateFlush2FlowTol.Text = Nothing
            txtbx_RcpCreateFlush2Pressure.Text = Nothing
            txtbx_RcpCreateFlush2Stabilize.Text = Nothing
            txtbx_RcpCreateFlush2Time.Text = Nothing
            txtbx_RcpCreateFlush2RPM.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_CreateDPTest2_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_CreateDPTest2.CheckedChanged
        If checkbx_CreateDPTest2.Checked = True Then
            str_dptest2enable = "Enable"
        Else
            str_dptest2enable = "Disable"
        End If
    End Sub

    Private Sub checkbx_CreateDrain1_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_CreateDrain1.CheckedChanged
        If checkbx_CreateDrain1.Checked = True Then
            txtbx_RcpCreateDrain1Pressure.Enabled = True
            txtbx_RcpCreateDrain1Time.Enabled = True

            d_drain1pressure = nom_d_drain1pressure
            i_drain1time = nom_i_drain1time

            str_drain1enable = "Enable"
            txtbx_RcpCreateDrain1Pressure.Text = d_drain1pressure.ToString("F1") 'CType(d_drain1pressure, String)
            txtbx_RcpCreateDrain1Time.Text = CType(i_drain1time, String)
        Else
            txtbx_RcpCreateDrain1Pressure.Enabled = False
            txtbx_RcpCreateDrain1Time.Enabled = False

            d_drain1pressure = 0.0
            i_drain1time = 0

            str_drain1enable = "Disable"
            txtbx_RcpCreateDrain1Pressure.Text = Nothing
            txtbx_RcpCreateDrain1Time.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_CreateDrain2_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_CreateDrain2.CheckedChanged
        If checkbx_CreateDrain2.Checked = True Then
            txtbx_RcpCreateDrain2Pressure.Enabled = True
            txtbx_RcpCreateDrain2Time.Enabled = True

            d_drain2pressure = nom_d_drain2pressure
            i_drain2time = nom_i_drain2time

            str_drain2enable = "Enable"
            txtbx_RcpCreateDrain2Pressure.Text = d_drain2pressure.ToString("F1") 'CType(d_drain2pressure, String)
            txtbx_RcpCreateDrain2Time.Text = CType(i_drain2time, String)
        Else
            txtbx_RcpCreateDrain2Pressure.Enabled = False
            txtbx_RcpCreateDrain2Time.Enabled = False

            d_drain2pressure = 0.0
            i_drain2time = 0

            str_drain2enable = "Disable"
            txtbx_RcpCreateDrain2Pressure.Text = Nothing
            txtbx_RcpCreateDrain2Time.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_CreateDrain3_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_CreateDrain3.CheckedChanged
        If checkbx_CreateDrain3.Checked = True Then
            txtbx_RcpCreateDrain3Pressure.Enabled = True
            txtbx_RcpCreateDrain3Time.Enabled = True

            d_drain3pressure = nom_d_drain3pressure
            i_drain3time = nom_i_drain3time

            str_drain3enable = "Enable"
            txtbx_RcpCreateDrain3Pressure.Text = d_drain3pressure.ToString("F1") 'CType(d_drain3pressure, String)
            txtbx_RcpCreateDrain3Time.Text = CType(i_drain3time, String)
        Else
            txtbx_RcpCreateDrain3Pressure.Enabled = False
            txtbx_RcpCreateDrain3Time.Enabled = False

            d_drain3pressure = 0.0
            i_drain3time = 0

            str_drain3enable = "Disable"
            txtbx_RcpCreateDrain3Pressure.Text = Nothing
            txtbx_RcpCreateDrain3Time.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_CreateDrain4_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_CreateDrain4.CheckedChanged
        If checkbx_CreateDrain4.Checked = True Then
            txtbx_RcpCreateDrain4Pressure.Enabled = True
            txtbx_RcpCreateDrain4Time.Enabled = True

            d_drain4pressure = nom_d_drain4pressure
            i_drain4time = nom_i_drain4time

            str_drain4enable = "Enable"
            txtbx_RcpCreateDrain4Pressure.Text = d_drain4pressure.ToString("F1") 'CType(d_drain4pressure, String)
            txtbx_RcpCreateDrain4Time.Text = CType(i_drain4time, String)
        Else
            txtbx_RcpCreateDrain4Pressure.Enabled = False
            txtbx_RcpCreateDrain4Time.Enabled = False

            d_drain4pressure = 0.0
            i_drain4time = 0

            str_drain4enable = "Disable"
            txtbx_RcpCreateDrain4Pressure.Text = Nothing
            txtbx_RcpCreateDrain4Time.Text = Nothing
        End If
    End Sub
#End Region

#Region "Recipe Parameter Textbox KeyPress event"
    ' To restrict any special character or character key or decimal point press inside Integer type box other than Numeric value
    Private Sub integerkeypress(sender As Object, e As KeyPressEventArgs) Handles txtbx_RcpCreateFlush1Stabilize.KeyPress, txtbx_RcpCreateFlush1Time.KeyPress, txtbx_RcpCreateDPStabilize.KeyPress, txtbx_RcpCreateDPTime.KeyPress, txtbx_RcpCreateDPPoints.KeyPress, txtbx_RcpCreateFlush2Stabilize.KeyPress, txtbx_RcpCreateFlush2Time.KeyPress, txtbx_RcpCreateDrain1Time.KeyPress, txtbx_RcpCreateDrain2Time.KeyPress, txtbx_RcpCreateDrain3Time.KeyPress, txtbx_RcpEditFlush1Stabilize.KeyPress, txtbx_RcpEditFlush1Time.KeyPress, txtbx_RcpEditDPStabilize.KeyPress, txtbx_RcpEditDPTime.KeyPress, txtbx_RcpEditDPPoints.KeyPress, txtbx_RcpEditFlush2Stabilize.KeyPress, txtbx_RcpEditFlush2Time.KeyPress, txtbx_RcpEditDrain1Time.KeyPress, txtbx_RcpEditDrain2Time.KeyPress, txtbx_RcpEditDrain3Time.KeyPress, txtbx_RcpEditDrain4Time.KeyPress
        Dim checktextbox As TextBox = DirectCast(sender, TextBox)

        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso Not Char.IsControl(e.KeyChar) Then
            RecipeMessage(16)
            e.Handled = True ' Suppress the key press
        End If

        ' Check for decimal points
        If e.KeyChar = "." Then
            RecipeMessage(17)
            e.Handled = True ' Suppress the key press
        End If
    End Sub

    ' To restrict any speecial character or character key press inside Decimal type box other than Numeric value
    'This allow single decimal point, if multiple decimal points pressed, it will throw message
    Private Sub decimalkeypress(sender As Object, e As KeyPressEventArgs) Handles txtbx_RcpCreateVerTol.KeyPress, txtbx_RcpCreateFlush1Flow.KeyPress, txtbx_RcpCreateFlush1FlowTol.KeyPress, txtbx_RcpCreateDPLowLimit.KeyPress, txtbx_RcpCreateDPUpLimit.KeyPress, txtbx_RcpCreateFlush2Flow.KeyPress, txtbx_RcpCreateFlush2FlowTol.KeyPress, txtbx_RcpCreateDrain1Pressure.KeyPress, txtbx_RcpCreateDrain2Pressure.KeyPress, txtbx_RcpCreateDrain3Pressure.KeyPress, txtbx_RcpCreateDrain4Pressure.KeyPress, txtbx_RcpEditVerTol.KeyPress, txtbx_RcpEditFlush1Flow.KeyPress, txtbx_RcpEditFlush1FlowTol.KeyPress, txtbx_RcpEditDPLowLimit.KeyPress, txtbx_RcpEditDPUpLimit.KeyPress, txtbx_RcpEditFlush2Flow.KeyPress, txtbx_RcpEditFlush2FlowTol.KeyPress, txtbx_RcpEditDrain1Pressure.KeyPress, txtbx_RcpEditDrain2Pressure.KeyPress, txtbx_RcpEditDrain3Pressure.KeyPress, txtbx_RcpEditDrain4Pressure.KeyPress
        Dim checktextbox As TextBox = DirectCast(sender, TextBox)

        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso Not Char.IsControl(e.KeyChar) Then
            RecipeMessage(16)
            e.Handled = True ' Suppress the key press
        End If

        ' Check for multiple decimal points
        If e.KeyChar = "." AndAlso DirectCast(sender, TextBox).Text.Contains(".") Then
            RecipeMessage(18)
            e.Handled = True ' Suppress the key press
        End If
    End Sub

    Private Sub alphanumerikeypress(sender As Object, e As KeyPressEventArgs) Handles txtbx_PartCreatePartID.KeyPress, txtbx_RcpCreateRecipeID.KeyPress, txtbx_RcpDupNewRecipeID.KeyPress
        Dim checktextbox As TextBox = DirectCast(sender, TextBox)

        If Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True ' Suppress the key press
        End If

        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "_" AndAlso Not e.KeyChar = "*" AndAlso Not e.KeyChar = "/" Then
            e.Handled = True ' Suppress the key press
        End If

        If e.KeyChar = "_" AndAlso DirectCast(sender, TextBox).Text.Contains("_") Then
            'e.Handled = True ' Suppress the key press
        End If
    End Sub

    Private Sub gotcursor(sender As Object, e As EventArgs) Handles txtbx_PartCreatePartID.GotFocus, txtbx_RcpCreateRecipeID.GotFocus, txtbx_RcpDupNewRecipeID.GotFocus
        Dim txtonfocus As TextBox = DirectCast(sender, TextBox)
        Dim texttooltip As New ToolTip
        texttooltip.InitialDelay = 100

        If txtonfocus Is txtbx_PartCreatePartID Then
            texttooltip.SetToolTip(txtbx_PartCreatePartID, "Number of characters is restricted to 16")
        End If

        If txtonfocus Is txtbx_RcpCreateRecipeID Then
            texttooltip.SetToolTip(txtbx_RcpCreateRecipeID, "Number of characters is restricted from 4 to 20")
        End If

        If txtonfocus Is txtbx_RcpDupNewRecipeID Then
            texttooltip.SetToolTip(txtbx_RcpDupNewRecipeID, "Number of characters is restricted from 4 to 20")
        End If
    End Sub
#End Region

#Region "Recipe parameter Range tooltip Creation"
    Private Sub gotfocusevent(sender As Object, e As EventArgs) Handles txtbx_RcpCreateVerTol.GotFocus, txtbx_RcpEditVerTol.GotFocus, txtbx_RcpCreateFlush1Flow.GotFocus, txtbx_RcpEditFlush1Flow.GotFocus, txtbx_RcpCreateFlush1FlowTol.GotFocus, txtbx_RcpEditFlush1FlowTol.GotFocus, txtbx_RcpCreateFlush1Stabilize.GotFocus, txtbx_RcpEditFlush1Stabilize.GotFocus, txtbx_RcpCreateFlush1Time.GotFocus, txtbx_RcpEditFlush1Time.GotFocus, txtbx_RcpCreateDPStabilize.GotFocus, txtbx_RcpEditDPStabilize.GotFocus, txtbx_RcpCreateDPTime.GotFocus, txtbx_RcpEditDPTime.GotFocus, txtbx_RcpCreateDPLowLimit.GotFocus, txtbx_RcpEditDPLowLimit.GotFocus, txtbx_RcpCreateDPUpLimit.GotFocus, txtbx_RcpEditDPUpLimit.GotFocus, txtbx_RcpCreateDPPoints.GotFocus, txtbx_RcpEditDPPoints.GotFocus, txtbx_RcpCreateFlush2Flow.GotFocus, txtbx_RcpEditFlush2Flow.GotFocus, txtbx_RcpCreateFlush2FlowTol.GotFocus, txtbx_RcpEditFlush2FlowTol.GotFocus, txtbx_RcpCreateFlush2Stabilize.GotFocus, txtbx_RcpEditFlush2Stabilize.GotFocus, txtbx_RcpCreateFlush2Time.GotFocus, txtbx_RcpEditFlush2Time.GotFocus, txtbx_RcpCreateDrain1Time.GotFocus, txtbx_RcpEditDrain1Time.GotFocus, txtbx_RcpCreateDrain1Pressure.GotFocus, txtbx_RcpEditDrain1Pressure.GotFocus, txtbx_RcpCreateDrain2Time.GotFocus, txtbx_RcpEditDrain2Time.GotFocus, txtbx_RcpCreateDrain2Pressure.GotFocus, txtbx_RcpEditDrain2Pressure.GotFocus, txtbx_RcpCreateDrain3Time.GotFocus, txtbx_RcpEditDrain3Time.GotFocus, txtbx_RcpCreateDrain3Pressure.GotFocus, txtbx_RcpEditDrain3Pressure.GotFocus, txtbx_RcpCreateDrain4Time.GotFocus, txtbx_RcpEditDrain4Time.GotFocus, txtbx_RcpCreateDrain4Pressure.GotFocus, txtbx_RcpEditDrain4Pressure.GotFocus
        Dim txtonfocus As TextBox = DirectCast(sender, TextBox)
        Dim focustooltip As New ToolTip
        focustooltip.InitialDelay = 100

        If txtonfocus Is txtbx_RcpCreateVerTol Then
            focustooltip.SetToolTip(txtbx_RcpCreateVerTol, $"Enter Value between {min_d_vertol} to {max_d_vertol}")
        End If
        If txtonfocus Is txtbx_RcpEditVerTol Then
            focustooltip.SetToolTip(txtbx_RcpEditVerTol, $"Enter Value between {min_d_vertol} to {max_d_vertol}")
        End If

        If txtonfocus Is txtbx_RcpCreatePrepFill Then
            focustooltip.SetToolTip(txtbx_RcpCreatePrepFill, $"Enter Value between {min_i_prepfilltime} to {max_i_prepfilltime}")
        End If
        If txtonfocus Is txtbx_RcpEditPrepFill Then
            focustooltip.SetToolTip(txtbx_RcpEditPrepFill, $"Enter Value between {min_i_prepfilltime} to {max_i_prepfilltime}")
        End If

        If txtonfocus Is txtbx_RcpCreatePrepBleed Then
            focustooltip.SetToolTip(txtbx_RcpCreatePrepBleed, $"Enter Value between {min_i_prepbleedtime} to {max_i_prepbleedtime}")
        End If
        If txtonfocus Is txtbx_RcpEditPrepBleed Then
            focustooltip.SetToolTip(txtbx_RcpEditPrepBleed, $"Enter Value between {min_i_prepbleedtime} to {max_i_prepbleedtime}")
        End If

        'If txtonfocus Is txtbx_RcpCreatePrepFlow Then
        '    focustooltip.SetToolTip(txtbx_RcpCreatePrepFlow, $"Enter Value between {min_d_prepflow} to {max_d_prepflow}")
        'End If
        'If txtonfocus Is txtbx_RcpEditPrepFlow Then
        '    focustooltip.SetToolTip(txtbx_RcpEditPrepFlow, $"Enter Value between {min_d_prepflow} to {max_d_prepflow}")
        'End If

        If txtonfocus Is txtbx_RcpCreatePrepPressureDrop Then
            focustooltip.SetToolTip(txtbx_RcpCreatePrepPressureDrop, $"Enter Value between {min_d_preppressure} to {max_d_preppressure}")
        End If
        If txtonfocus Is txtbx_RcpEditPrepPressureDrop Then
            focustooltip.SetToolTip(txtbx_RcpEditPrepPressureDrop, $"Enter Value between {min_d_preppressure} to {max_d_preppressure}")
        End If

        If txtonfocus Is txtbx_RcpCreatePrepPressureDrop Then
            focustooltip.SetToolTip(txtbx_RcpCreatePrepPressureDrop, $"Enter Value between {min_d_preppressuredrop} to {max_d_preppressuredrop}")
        End If
        If txtonfocus Is txtbx_RcpEditPrepPressureDrop Then
            focustooltip.SetToolTip(txtbx_RcpEditPrepPressureDrop, $"Enter Value between {min_d_preppressuredrop} to {max_d_preppressuredrop}")
        End If

        If txtonfocus Is txtbx_RcpCreatePrepPressureDropTime Then
            focustooltip.SetToolTip(txtbx_RcpCreatePrepPressureDropTime, $"Enter Value between {min_i_preppressuredroptime} to {max_i_preppressuredroptime}")
        End If
        If txtonfocus Is txtbx_RcpEditPrepPressureDropTime Then
            focustooltip.SetToolTip(txtbx_RcpEditPrepPressureDropTime, $"Enter Value between {min_i_preppressuredroptime} to {max_i_preppressuredroptime}")
        End If

        If txtonfocus Is txtbx_RcpCreatePrepPrefillStartTime Then
            focustooltip.SetToolTip(txtbx_RcpCreatePrepPrefillStartTime, $"Enter Value between {min_i_prepprefillstarttime} to {max_i_prepprefillstarttime}")
        End If
        If txtonfocus Is txtbx_RcpEditPrepPrefillStartTime Then
            focustooltip.SetToolTip(txtbx_RcpEditPrepPrefillStartTime, $"Enter Value between {min_i_prepprefillstarttime} to {max_i_prepprefillstarttime}")
        End If

        If txtonfocus Is txtbx_RcpCreatePrepPrefillTime Then
            focustooltip.SetToolTip(txtbx_RcpCreatePrepPrefillTime, $"Enter Value between {min_i_prepprefilltime} to {max_i_prepprefilltime}")
        End If
        If txtonfocus Is txtbx_RcpEditPrepPrefillTime Then
            focustooltip.SetToolTip(txtbx_RcpEditPrepPrefillTime, $"Enter Value between {min_i_prepprefilltime} to {max_i_prepprefilltime}")
        End If

        If txtonfocus Is txtbx_RcpCreatePrepRPM Then
            focustooltip.SetToolTip(txtbx_RcpCreatePrepRPM, $"Enter Value between {min_i_preprpm1} to {max_i_preprpm1}")
        End If
        If txtonfocus Is txtbx_RcpEditPrepRPM Then
            focustooltip.SetToolTip(txtbx_RcpEditPrepRPM, $"Enter Value between {min_i_preprpm1} to {max_i_preprpm1}")
        End If

        'If txtonfocus Is txtbx_RcpCreatePrepRPM2 Then
        '    focustooltip.SetToolTip(txtbx_RcpCreatePrepRPM2, $"Enter Value between {min_i_preprpm2} to {max_i_preprpm2}")
        'End If
        'If txtonfocus Is txtbx_RcpEditPrepRPM2 Then
        '    focustooltip.SetToolTip(txtbx_RcpEditPrepRPM2, $"Enter Value between {min_i_preprpm2} to {max_i_preprpm2}")
        'End If


        'If txtonfocus Is txtbx_RcpCreateFlush1Fill Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateFlush1Fill, $"Enter Value between {min_i_flush1filltime} to {max_i_flush1filltime}")
        'End If
        'If txtonfocus Is txtbx_RcpEditFlush1Fill Then
        '    focustooltip.SetToolTip(txtbx_RcpEditFlush1Fill, $"Enter Value between {min_i_flush1filltime} to {max_i_flush1filltime}")
        'End If

        'If txtonfocus Is txtbx_RcpCreateFlush1Bleed Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateFlush1Bleed, $"Enter Value between {min_i_flush1bleedtime} to {max_i_flush1bleedtime}")
        'End If
        'If txtonfocus Is txtbx_RcpEditFlush1Bleed Then
        '    focustooltip.SetToolTip(txtbx_RcpEditFlush1Bleed, $"Enter Value between {min_i_flush1bleedtime} to {max_i_flush1bleedtime}")
        'End If

        If txtonfocus Is txtbx_RcpCreateFlush1Flow Then
            focustooltip.SetToolTip(txtbx_RcpCreateFlush1Flow, $"Enter Value between {min_d_flush1flow} to {max_d_flush1flow}")
        End If
        If txtonfocus Is txtbx_RcpEditFlush1Flow Then
            focustooltip.SetToolTip(txtbx_RcpEditFlush1Flow, $"Enter Value between {min_d_flush1flow} to {max_d_flush1flow}")
        End If

        If txtonfocus Is txtbx_RcpCreateFlush1FlowTol Then
            focustooltip.SetToolTip(txtbx_RcpCreateFlush1FlowTol, $"Enter Value between {min_d_flush1flowtol} to {max_d_flush1flowtol}")
        End If
        If txtonfocus Is txtbx_RcpEditFlush1FlowTol Then
            focustooltip.SetToolTip(txtbx_RcpEditFlush1FlowTol, $"Enter Value between {min_d_flush1flowtol} to {max_d_flush1flowtol}")
        End If

        'If txtonfocus Is txtbx_RcpCreateFlush1Pressure Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateFlush1Pressure, $"Enter Value between {min_d_flush1pressure} to {max_d_flush1pressure}")
        'End If
        'If txtonfocus Is txtbx_RcpEditFlush1Pressure Then
        '    focustooltip.SetToolTip(txtbx_RcpEditFlush1Pressure, $"Enter Value between {min_d_flush1pressure} to {max_d_flush1pressure}")
        'End If

        If txtonfocus Is txtbx_RcpCreateFlush1Stabilize Then
            focustooltip.SetToolTip(txtbx_RcpCreateFlush1Stabilize, $"Enter Value between {min_i_flush1stabilize} to {max_i_flush1stabilize}")
        End If
        If txtonfocus Is txtbx_RcpEditFlush1Stabilize Then
            focustooltip.SetToolTip(txtbx_RcpEditFlush1Stabilize, $"Enter Value between {min_i_flush1stabilize} to {max_i_flush1stabilize}")
        End If

        If txtonfocus Is txtbx_RcpCreateFlush1Time Then
            focustooltip.SetToolTip(txtbx_RcpCreateFlush1Time, $"Enter Value between {min_i_flush1time} to {max_i_flush1time}")
        End If
        If txtonfocus Is txtbx_RcpEditFlush1Time Then
            focustooltip.SetToolTip(txtbx_RcpEditFlush1Time, $"Enter Value between {min_i_flush1time} to {max_i_flush1time}")
        End If

        'If txtonfocus Is txtbx_RcpCreateDPFill Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateDPFill, $"Enter Value between {min_i_dptestfilltime} to {max_i_dptestfilltime}")
        'End If
        'If txtonfocus Is txtbx_RcpEditDPFill Then
        '    focustooltip.SetToolTip(txtbx_RcpEditDPFill, $"Enter Value between {min_i_dptestfilltime} to {max_i_dptestfilltime}")
        'End If

        'If txtonfocus Is txtbx_RcpCreateDPBleed Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateDPBleed, $"Enter Value between {min_i_dptestbleedtime} to {max_i_dptestbleedtime}")
        'End If
        'If txtonfocus Is txtbx_RcpEditDPBleed Then
        '    focustooltip.SetToolTip(txtbx_RcpEditDPBleed, $"Enter Value between {min_i_dptestbleedtime} to {max_i_dptestbleedtime}")
        'End If

        'If txtonfocus Is txtbx_RcpCreateDPFlow Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateDPFlow, $"Enter Value between {min_d_dptestflow} to {max_d_dptestflow}")
        'End If
        'If txtonfocus Is txtbx_RcpEditDPFlow Then
        '    focustooltip.SetToolTip(txtbx_RcpEditDPFlow, $"Enter Value between {min_d_dptestflow} to {max_d_dptestflow}")
        'End If

        'If txtonfocus Is txtbx_RcpCreateDPFlowTol Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateDPFlowTol, $"Enter Value between {min_d_dptestflowtol} to {max_d_dptestflowtol}")
        'End If
        'If txtonfocus Is txtbx_RcpEditDPFlowTol Then
        '    focustooltip.SetToolTip(txtbx_RcpEditDPFlowTol, $"Enter Value between {min_d_dptestflowtol} to {max_d_dptestflowtol}")
        'End If

        'If txtonfocus Is txtbx_RcpCreateDPPressure Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateDPPressure, $"Enter Value between {min_d_dptestpressure} to {max_d_dptestpressure}")
        'End If
        'If txtonfocus Is txtbx_RcpEditDPPressure Then
        '    focustooltip.SetToolTip(txtbx_RcpEditDPPressure, $"Enter Value between {min_d_dptestpressure} to {max_d_dptestpressure}")
        'End If

        If txtonfocus Is txtbx_RcpCreateDPStabilize Then
            focustooltip.SetToolTip(txtbx_RcpCreateDPStabilize, $"Enter Value between {min_i_dpteststabilize} to {max_i_dpteststabilize}")
        End If
        If txtonfocus Is txtbx_RcpEditDPStabilize Then
            focustooltip.SetToolTip(txtbx_RcpEditDPStabilize, $"Enter Value between {min_i_dpteststabilize} to {max_i_dpteststabilize}")
        End If

        If txtonfocus Is txtbx_RcpCreateDPTime Then
            focustooltip.SetToolTip(txtbx_RcpCreateDPTime, $"Enter Value between {min_i_dptesttime} to {max_i_dptesttime}")
        End If
        If txtonfocus Is txtbx_RcpEditDPTime Then
            focustooltip.SetToolTip(txtbx_RcpEditDPTime, $"Enter Value between {min_i_dptesttime} to {max_i_dptesttime}")
        End If

        If txtonfocus Is txtbx_RcpCreateDPLowLimit Then
            focustooltip.SetToolTip(txtbx_RcpCreateDPLowLimit, $"Enter Value between {min_d_dptestlowlimit} to {max_d_dptestlowlimit}")
        End If
        If txtonfocus Is txtbx_RcpEditDPLowLimit Then
            focustooltip.SetToolTip(txtbx_RcpEditDPLowLimit, $"Enter Value between {min_d_dptestlowlimit} to {max_d_dptestlowlimit}")
        End If

        If txtonfocus Is txtbx_RcpCreateDPUpLimit Then
            focustooltip.SetToolTip(txtbx_RcpCreateDPUpLimit, $"Enter Value between {min_d_dptestuplimit} to {max_d_dptestuplimit}")
        End If
        If txtonfocus Is txtbx_RcpEditDPUpLimit Then
            focustooltip.SetToolTip(txtbx_RcpEditDPUpLimit, $"Enter Value between {min_d_dptestuplimit} to {max_d_dptestuplimit}")
        End If

        If txtonfocus Is txtbx_RcpCreateDPPoints Then
            focustooltip.SetToolTip(txtbx_RcpCreateDPPoints, $"Enter Value between {min_i_dptestpoints} to {max_i_dptestpoints}")
        End If
        If txtonfocus Is txtbx_RcpEditDPPoints Then
            focustooltip.SetToolTip(txtbx_RcpEditDPPoints, $"Enter Value between {min_i_dptestpoints} to {max_i_dptestpoints}")
        End If

        'If txtonfocus Is txtbx_RcpCreateFlush2Fill Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateFlush2Fill, $"Enter Value between {min_i_flush2filltime} to {max_i_flush2filltime}")
        'End If
        'If txtonfocus Is txtbx_RcpEditFlush2Fill Then
        '    focustooltip.SetToolTip(txtbx_RcpEditFlush2Fill, $"Enter Value between {min_i_flush2filltime} to {max_i_flush2filltime}")
        'End If

        'If txtonfocus Is txtbx_RcpCreateFlush2Bleed Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateFlush2Bleed, $"Enter Value between {min_i_flush2bleedtime} to {max_i_flush2bleedtime}")
        'End If
        'If txtonfocus Is txtbx_RcpEditFlush2Bleed Then
        '    focustooltip.SetToolTip(txtbx_RcpEditFlush2Bleed, $"Enter Value between {min_i_flush2bleedtime} to {max_i_flush2bleedtime}")
        'End If

        If txtonfocus Is txtbx_RcpCreateFlush2Flow Then
            focustooltip.SetToolTip(txtbx_RcpCreateFlush2Flow, $"Enter Value between {min_d_flush2flow} to {max_d_flush2flow}")
        End If
        If txtonfocus Is txtbx_RcpEditFlush2Flow Then
            focustooltip.SetToolTip(txtbx_RcpEditFlush2Flow, $"Enter Value between {min_d_flush2flow} to {max_d_flush2flow}")
        End If

        If txtonfocus Is txtbx_RcpCreateFlush2FlowTol Then
            focustooltip.SetToolTip(txtbx_RcpCreateFlush2FlowTol, $"Enter Value between {min_d_flush2flowtol} to {max_d_flush2flowtol}")
        End If
        If txtonfocus Is txtbx_RcpEditFlush2FlowTol Then
            focustooltip.SetToolTip(txtbx_RcpEditFlush2FlowTol, $"Enter Value between {min_d_flush2flowtol} to {max_d_flush2flowtol}")
        End If

        'If txtonfocus Is txtbx_RcpCreateFlush2Pressure Then
        '    focustooltip.SetToolTip(txtbx_RcpCreateFlush2Pressure, $"Enter Value between {min_d_flush2pressure} to {max_d_flush2pressure}")
        'End If
        'If txtonfocus Is txtbx_RcpEditFlush2Pressure Then
        '    focustooltip.SetToolTip(txtbx_RcpEditFlush2Pressure, $"Enter Value between {min_d_flush2pressure} to {max_d_flush2pressure}")
        'End If

        If txtonfocus Is txtbx_RcpCreateFlush2Stabilize Then
            focustooltip.SetToolTip(txtbx_RcpCreateFlush2Stabilize, $"Enter Value between {min_i_flush2stabilize} to {max_i_flush2stabilize}")
        End If
        If txtonfocus Is txtbx_RcpEditFlush2Stabilize Then
            focustooltip.SetToolTip(txtbx_RcpEditFlush2Stabilize, $"Enter Value between {min_i_flush2stabilize} to {max_i_flush2stabilize}")
        End If

        If txtonfocus Is txtbx_RcpCreateFlush2Time Then
            focustooltip.SetToolTip(txtbx_RcpCreateFlush2Time, $"Enter Value between {min_i_flush2time} to {max_i_flush2time}")
        End If
        If txtonfocus Is txtbx_RcpEditFlush2Time Then
            focustooltip.SetToolTip(txtbx_RcpEditFlush2Time, $"Enter Value between {min_i_flush2time} to {max_i_flush2time}")
        End If

        If txtonfocus Is txtbx_RcpCreateDrain1Pressure Then
            focustooltip.SetToolTip(txtbx_RcpCreateDrain1Pressure, $"Enter Value between {min_d_drain1pressure} to {max_d_drain1pressure}")
        End If
        If txtonfocus Is txtbx_RcpEditDrain1Pressure Then
            focustooltip.SetToolTip(txtbx_RcpEditDrain1Pressure, $"Enter Value between {min_d_drain1pressure} to {max_d_drain1pressure}")
        End If

        If txtonfocus Is txtbx_RcpCreateDrain1Time Then
            focustooltip.SetToolTip(txtbx_RcpCreateDrain1Time, $"Enter Value between {min_i_drain1time} to {max_i_drain1time}")
        End If
        If txtonfocus Is txtbx_RcpEditDrain1Time Then
            focustooltip.SetToolTip(txtbx_RcpEditDrain1Time, $"Enter Value between {min_i_drain1time} to {max_i_drain1time}")
        End If

        If txtonfocus Is txtbx_RcpCreateDrain2Pressure Then
            focustooltip.SetToolTip(txtbx_RcpCreateDrain2Pressure, $"Enter Value between {min_d_drain2pressure} to {max_d_drain2pressure}")
        End If
        If txtonfocus Is txtbx_RcpEditDrain2Pressure Then
            focustooltip.SetToolTip(txtbx_RcpEditDrain2Pressure, $"Enter Value between {min_d_drain2pressure} to {max_d_drain2pressure}")
        End If

        If txtonfocus Is txtbx_RcpCreateDrain2Time Then
            focustooltip.SetToolTip(txtbx_RcpCreateDrain2Time, $"Enter Value between {min_i_drain2time} to {max_i_drain2time}")
        End If
        If txtonfocus Is txtbx_RcpEditDrain2Time Then
            focustooltip.SetToolTip(txtbx_RcpEditDrain2Time, $"Enter Value between {min_i_drain2time} to {max_i_drain2time}")
        End If

        If txtonfocus Is txtbx_RcpCreateDrain3Pressure Then
            focustooltip.SetToolTip(txtbx_RcpCreateDrain3Pressure, $"Enter Value between {min_d_drain3pressure} to {max_d_drain3pressure}")
        End If
        If txtonfocus Is txtbx_RcpEditDrain3Pressure Then
            focustooltip.SetToolTip(txtbx_RcpEditDrain3Pressure, $"Enter Value between {min_d_drain3pressure} to {max_d_drain3pressure}")
        End If

        If txtonfocus Is txtbx_RcpCreateDrain3Time Then
            focustooltip.SetToolTip(txtbx_RcpCreateDrain3Time, $"Enter Value between {min_i_drain3time} to {max_i_drain3time}")
        End If
        If txtonfocus Is txtbx_RcpEditDrain3Time Then
            focustooltip.SetToolTip(txtbx_RcpEditDrain3Time, $"Enter Value between {min_i_drain3time} to {max_i_drain3time}")
        End If

        If txtonfocus Is txtbx_RcpCreateDrain4Pressure Then
            focustooltip.SetToolTip(txtbx_RcpCreateDrain4Pressure, $"Enter Value between {min_d_drain4pressure} to {max_d_drain4pressure}")
        End If
        If txtonfocus Is txtbx_RcpEditDrain4Pressure Then
            focustooltip.SetToolTip(txtbx_RcpEditDrain4Pressure, $"Enter Value between {min_d_drain4pressure} to {max_d_drain4pressure}")
        End If

        If txtonfocus Is txtbx_RcpCreateDrain4Time Then
            focustooltip.SetToolTip(txtbx_RcpCreateDrain4Time, $"Enter Value between {min_i_drain4time} to {max_i_drain4time}")
        End If
        If txtonfocus Is txtbx_RcpEditDrain4Time Then
            focustooltip.SetToolTip(txtbx_RcpEditDrain4Time, $"Enter Value between {min_i_drain4time} to {max_i_drain4time}")
        End If
    End Sub
#End Region

#Region "Recipe Create Parameter Range Validating Event"
    Private Sub txtbx_RcpCreateVerTol_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateVerTol.Validating
        'Check verification tolerance

        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateVerTol.Text = "" And Not txtbx_RcpCreateVerTol.Text = "." Then
            'Convert to the required type
            d_vertol = CType(txtbx_RcpCreateVerTol.Text, Decimal)
            'Check the value within range
            If d_vertol < min_d_vertol Or d_vertol > max_d_vertol Then
                RecipeMessage(20, "Verification tolerance should be within " + CType(min_d_vertol, String) + " to " + CType(max_d_vertol, String))
                txtbx_RcpCreateVerTol.Text = Nothing
                txtbx_RcpCreateVerTol.Focus()
            End If
        Else
            RecipeMessage(19, "Verification tolerance")
        End If
    End Sub

    Private Sub txtbx_RcpCreatePrepFill_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreatePrepFill.Validating
        'Check fill time 

        'Check the text is empty
        If Not txtbx_RcpCreatePrepFill.Text = "" Then
            'Convert to the required type
            i_prepfilltime = CType(txtbx_RcpCreatePrepFill.Text, Integer)
            'Check the value within range
            If i_prepfilltime < min_i_prepfilltime Or i_prepfilltime > max_i_prepfilltime Then
                RecipeMessage(20, "Preparation Fill Time should be within " + CType(min_i_prepfilltime, String) + " to " + CType(max_i_prepfilltime, String))
                txtbx_RcpCreatePrepFill.Text = Nothing
                txtbx_RcpCreatePrepFill.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Fill Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreatePrepBleed_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreatePrepBleed.Validating
        'Check bleed time 

        'Check the text is empty
        If Not txtbx_RcpCreatePrepBleed.Text = "" Then
            'Convert to the required type
            i_prepbleedtime = CType(txtbx_RcpCreatePrepBleed.Text, Integer)
            'Check the value within range
            If i_prepbleedtime < min_i_prepbleedtime Or i_prepbleedtime > max_i_prepbleedtime Then
                RecipeMessage(20, "Preparation Bleed Time should be within " + CType(min_i_prepbleedtime, String) + " to " + CType(max_i_prepbleedtime, String))
                txtbx_RcpCreatePrepBleed.Text = Nothing
                txtbx_RcpCreatePrepBleed.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Bleed Time")
        End If
    End Sub

    'Private Sub txtbx_RcpCreatePrepFlow_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreatePrepFlow.Validating
    '    'Check for Preparation Flowrate
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpCreatePrepFlow.Text = "" And Not txtbx_RcpCreatePrepFlow.Text = "." Then
    '        'Convert to the required type
    '        d_prepflow = CType(txtbx_RcpCreatePrepFlow.Text, Decimal)

    '        '' Set flowrate of other to same as this
    '        'If cmbx_RcpCreatePrepPumpMode.SelectedIndex = 1 Then
    '        '    d_flush1flow = d_prepflow
    '        '    d_dptestflow = d_prepflow
    '        '    d_flush2flow = d_prepflow
    '        '    txtbx_RcpCreateFlush1Flow.Text = d_prepflow.ToString("F1")
    '        '    txtbx_RcpCreateDPFlow.Text = d_prepflow.ToString("F1")
    '        '    txtbx_RcpCreateFlush2Flow.Text = d_prepflow.ToString("F1")

    '        '    d_flush1flowtol = 0
    '        '    d_dptestflowtol = 0
    '        '    d_flush2flowtol = 0
    '        '    txtbx_RcpCreateFlush1FlowTol.Text = "0.0"
    '        '    txtbx_RcpCreateDPFlowTol.Text = "0.0"
    '        '    txtbx_RcpCreateFlush2FlowTol.Text = "0.0"
    '        'End If

    '        'Check the value within range
    '        If d_prepflow < min_d_prepflow Or d_prepflow > max_d_prepflow Then
    '            RecipeMessage(20, "Preparation Flowrate should be within " + CType(min_d_prepflow, String) + " to " + CType(max_d_prepflow, String))
    '            txtbx_RcpCreatePrepFlow.Text = Nothing
    '            txtbx_RcpCreatePrepFlow.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Preparation Flowrate")
    '    End If
    'End Sub

    Private Sub txtbx_RcpCreatePrepPressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreatePrepPressureDrop.Validating
        'Check for Preparation Back Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreatePrepPressureDrop.Text = "" And Not txtbx_RcpCreatePrepPressureDrop.Text = "." Then
            'Convert to the required type
            d_preppressure = CType(txtbx_RcpCreatePrepPressureDrop.Text, Decimal)
            'Check the value within range
            If d_preppressure < min_d_preppressure Or d_preppressure > max_d_preppressure Then
                RecipeMessage(20, "Preparation Back Pressure should be within " + CType(min_d_preppressure, String) + " to " + CType(max_d_preppressure, String))
                txtbx_RcpCreatePrepPressureDrop.Text = Nothing
                txtbx_RcpCreatePrepPressureDrop.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Back Pressure")
        End If
    End Sub

    Private Sub txtbx_RcpCreatePrepPressureDrop_Validating(sender As Object, e As CancelEventArgs)
        'Check for Preparation Back Pressure Drop
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreatePrepPressureDrop.Text = "" And Not txtbx_RcpCreatePrepPressureDrop.Text = "." Then
            'Convert to the required type
            d_preppressuredrop = CType(txtbx_RcpCreatePrepPressureDrop.Text, Decimal)
            'Check the value within range
            If d_preppressuredrop < min_d_preppressuredrop Or d_preppressuredrop > max_d_preppressuredrop Then
                RecipeMessage(20, "Preparation Pressure Drop should be within " + CType(min_d_preppressuredrop, String) + " to " + CType(max_d_preppressuredrop, String))
                txtbx_RcpCreatePrepPressureDrop.Text = Nothing
                txtbx_RcpCreatePrepPressureDrop.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Pressure Drop")
        End If
    End Sub

    Private Sub txtbx_RcpCreatePrepPressureDropTime_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreatePrepPressureDropTime.Validating
        'Check pressure drop time 

        'Check the text is empty
        If Not txtbx_RcpCreatePrepPressureDrop.Text = "" Then
            'Convert to the required type
            i_preppressuredroptime = CType(txtbx_RcpCreatePrepPressureDrop.Text, Integer)
            'Check the value within range
            If i_preppressuredroptime < min_i_preppressuredroptime Or i_preppressuredroptime > max_i_preppressuredroptime Then
                RecipeMessage(20, "Preparation Drop Time should be within " + CType(min_i_preppressuredroptime, String) + " to " + CType(max_i_preppressuredroptime, String))
                txtbx_RcpCreatePrepPressureDrop.Text = Nothing
                txtbx_RcpCreatePrepPressureDrop.Focus()

            End If
        Else
            RecipeMessage(19, "Preparation Drop Time")
        End If

    End Sub

    Private Sub txtbx_RcpCreatePrefillStartTime_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreatePrepPrefillStartTime.Validating
        'Check prefill start time 

        'Check the text is empty
        If Not txtbx_RcpCreatePrepPrefillStartTime.Text = "" Then
            'Convert to the required type
            i_prepprefillstarttime = CType(txtbx_RcpCreatePrepPrefillStartTime.Text, Integer)
            'Check the value within range
            If i_prepprefillstarttime < min_i_prepprefillstarttime Or i_prepprefillstarttime > max_i_prepprefillstarttime Then
                RecipeMessage(20, "Preparation Prefill Start Time should be within " + CType(min_i_prepprefillstarttime, String) + " to " + CType(max_i_prepprefillstarttime, String))
                txtbx_RcpCreatePrepPrefillStartTime.Text = Nothing
                txtbx_RcpCreatePrepPrefillStartTime.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Start Prefill Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreatePrefillTime_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreatePrepPrefillTime.Validating
        'Check prefill time 

        'Check the text is empty
        If Not txtbx_RcpCreatePrepPrefillTime.Text = "" Then
            'Convert to the required type
            i_prepprefilltime = CType(txtbx_RcpCreatePrepPrefillTime.Text, Integer)
            'Check the value within range
            If i_prepprefilltime < min_i_prepprefilltime Or i_prepprefilltime > max_i_prepprefilltime Then
                RecipeMessage(20, "Preparation Prefill Time should be within " + CType(min_i_prepprefilltime, String) + " to " + CType(max_i_prepprefilltime, String))
                txtbx_RcpCreatePrepPrefillTime.Text = Nothing
                txtbx_RcpCreatePrepPrefillTime.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Prefill Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreatePrepRPM_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreatePrepRPM.Validating
        'Check rpm

        'Check the text is empty
        If Not txtbx_RcpCreatePrepRPM.Text = "" Then
            'Convert to the required type
            i_preprpm1 = CType(txtbx_RcpCreatePrepRPM.Text, Integer)
            'Check the value within range
            If i_preprpm1 < min_i_preprpm1 Or i_preprpm1 > max_i_preprpm1 Then
                RecipeMessage(20, "Preparation RPM should be within " + CType(min_i_preprpm1, String) + " to " + CType(max_i_preprpm1, String))
                txtbx_RcpCreatePrepRPM.Text = Nothing
                txtbx_RcpCreatePrepRPM.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation RPM")
        End If
    End Sub

    'Private Sub txtbx_RcpCreatePrepRPM2_Validating(sender As Object, e As CancelEventArgs)
    '    'Check rpm 

    '    'Check the text is empty
    '    If Not txtbx_RcpCreatePrepRPM2.Text = "" Then
    '        'Convert to the required type
    '        i_preprpm2 = CType(txtbx_RcpCreatePrepRPM2.Text, Integer)
    '        'Check the value within range
    '        If i_preprpm2 < min_i_preprpm2 Or i_preprpm2 > max_i_preprpm2 Then
    '            RecipeMessage(20, "Preparation RPM-2 should be within " + CType(min_i_preprpm2, String) + " to " + CType(max_i_preprpm2, String))
    '            txtbx_RcpCreatePrepRPM2.Text = Nothing
    '            txtbx_RcpCreatePrepRPM2.Focus()

    '        End If
    '    Else
    '        RecipeMessage(19, "Preparation RPM-2")
    '    End If

    'End Sub

    'Private Sub txtbx_RcpCreateFlush1Fill_Validating(sender As Object, e As CancelEventArgs)
    '    'Check fill time 

    '    'Check the text is empty
    '    If Not txtbx_RcpCreateFlush1Fill.Text = "" Then
    '        'Convert to the required type
    '        i_flush1filltime = CType(txtbx_RcpCreateFlush1Fill.Text, Integer)
    '        'Check the value within range
    '        If i_flush1filltime < min_i_flush1filltime Or i_flush1filltime > max_i_flush1filltime Then
    '            RecipeMessage(20, "Flush-1 Fill Time should be within " + CType(min_i_flush1filltime, String) + " to " + CType(max_i_flush1filltime, String))
    '            txtbx_RcpCreateFlush1Fill.Text = Nothing
    '            txtbx_RcpCreateFlush1Fill.Focus()

    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-1 Fill Time")
    '    End If

    'End Sub

    'Private Sub txtbx_RcpCreateFlush1Bleed_Validating(sender As Object, e As CancelEventArgs)
    '    'Check air bleed time

    '    'Check the text is empty
    '    If Not txtbx_RcpCreateFlush1Bleed.Text = "" Then
    '        'Convert to the required type
    '        i_flush1bleedtime = CType(txtbx_RcpCreateFlush1Bleed.Text, Integer)
    '        'Check the value within range
    '        If i_flush1bleedtime < min_i_flush1bleedtime Or i_flush1bleedtime > max_i_flush1bleedtime Then
    '            RecipeMessage(20, "Flush-1 Bleed Time should be within " + CType(min_i_flush1bleedtime, String) + " to " + CType(max_i_flush1bleedtime, String))
    '            txtbx_RcpCreateFlush1Bleed.Text = Nothing
    '            txtbx_RcpCreateFlush1Bleed.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-1 Bleed Time")

    '    End If

    'End Sub

    Private Sub txtbx_RcpCreateFlush1Flow_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush1Flow.Validating
        'Check for Flush-1 Flowrate
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateFlush1Flow.Text = "" And Not txtbx_RcpCreateFlush1Flow.Text = "." Then
            'Convert to the required type
            d_flush1flow = CType(txtbx_RcpCreateFlush1Flow.Text, Decimal)
            'Check the value within range
            If d_flush1flow < min_d_flush1flow Or d_flush1flow > max_d_flush1flow Then
                RecipeMessage(20, "Flush-1 Flowrate should be within " + CType(min_d_flush1flow, String) + " to " + CType(max_d_flush1flow, String))
                txtbx_RcpCreateFlush1Flow.Text = Nothing
                txtbx_RcpCreateFlush1Flow.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 Flowrate")
        End If
    End Sub

    Private Sub txtbx_RcpCreateFlush1FlowTol_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush1FlowTol.Validating
        'Check for Flush-1 Flow Tolerance
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateFlush1FlowTol.Text = "" And Not txtbx_RcpCreateFlush1FlowTol.Text = "." Then
            'Convert to the required type
            d_flush1flowtol = CType(txtbx_RcpCreateFlush1FlowTol.Text, Decimal)
            'Check the value within range
            If d_flush1flowtol < min_d_flush1flowtol Or d_flush1flowtol > max_d_flush1flowtol Then
                RecipeMessage(20, "Flush-1 Flow Tolerance should be within " + CType(min_d_flush1flowtol, String) + " to " + CType(max_d_flush1flowtol, String))
                txtbx_RcpCreateFlush1FlowTol.Text = Nothing
                txtbx_RcpCreateFlush1FlowTol.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 Flow tolerance")
        End If
    End Sub

    'Private Sub txtbx_RcpCreateFlush1Pressure_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for Flush-1 Pressure
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpCreateFlush1Pressure.Text = "" And Not txtbx_RcpCreateFlush1Pressure.Text = "." Then
    '        'Convert to the required type
    '        d_flush1pressure = CType(txtbx_RcpCreateFlush1Pressure.Text, Decimal)
    '        'Check the value within range
    '        If d_flush1pressure < min_d_flush1pressure Or d_flush1pressure > max_d_flush1pressure Then
    '            RecipeMessage(20, "Flush-1 Pressure should be within " + CType(min_d_flush1pressure, String) + " to " + CType(max_d_flush1pressure, String))
    '            txtbx_RcpCreateFlush1Pressure.Text = Nothing
    '            txtbx_RcpCreateFlush1Pressure.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-1 Back Pressure")
    '    End If
    'End Sub

    Private Sub txtbx_RcpCreateFlush1Stabilize_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush1Stabilize.Validating
        'Check for Flush-1 Stabilize Time
        'Check the text is empty
        If Not txtbx_RcpCreateFlush1Stabilize.Text = "" Then
            'Convert to the required type
            i_flush1stabilize = CType(txtbx_RcpCreateFlush1Stabilize.Text, Integer)
            'Check the value within range
            If i_flush1stabilize < min_i_flush1stabilize Or i_flush1stabilize > max_i_flush1stabilize Then
                RecipeMessage(20, "Flush-1 Stabilize Time should be within " + CType(min_i_flush1stabilize, String) + " to " + CType(max_i_flush1stabilize, String))
                txtbx_RcpCreateFlush1Stabilize.Text = Nothing
                txtbx_RcpCreateFlush1Stabilize.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 Stabilize Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreateFlush1Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush1Time.Validating
        'Check for Flush-1 Time
        'Check the text is empty
        If Not txtbx_RcpCreateFlush1Time.Text = "" Then
            'Convert to the required type
            i_flush1time = CType(txtbx_RcpCreateFlush1Time.Text, Integer)
            'Check the value within range
            If i_flush1time < min_i_flush1time Or i_flush1time > max_i_flush1time Then
                RecipeMessage(20, "Flush-1 Time should be within " + CType(min_i_flush1time, String) + " to " + CType(max_i_flush1time, String))
                txtbx_RcpCreateFlush1Time.Text = Nothing
                txtbx_RcpCreateFlush1Time.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreateFlush1RPM_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush1RPM.Validating
        'Check for Flush-1 RPM
        'Check the text is empty
        If Not txtbx_RcpCreateFlush1RPM.Text = "" Then
            'Convert to the required type
            i_flush1rpm = CType(txtbx_RcpCreateFlush1RPM.Text, Integer)
            'Check the value within range
            If i_flush1rpm < min_i_flush1rpm Or i_flush1rpm > max_i_flush1rpm Then
                RecipeMessage(20, "Flush-1 RPM should be within " + CType(min_i_flush1rpm, String) + " to " + CType(max_i_flush1rpm, String))
                txtbx_RcpCreateFlush1RPM.Text = Nothing
                txtbx_RcpCreateFlush1RPM.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 RPM")
        End If
    End Sub

    'Private Sub txtbx_RcpCreateDPFill_Validating(sender As Object, e As CancelEventArgs)
    '    'Check fill time 

    '    'Check the text is empty
    '    If Not txtbx_RcpCreateDPFill.Text = "" Then
    '        'Convert to the required type
    '        i_dptestfilltime = CType(txtbx_RcpCreateDPFill.Text, Integer)
    '        'Check the value within range
    '        If i_dptestfilltime < min_i_dptestfilltime Or i_dptestfilltime > max_i_dptestfilltime Then
    '            RecipeMessage(20, "DP Test Fill Time should be within " + CType(min_i_dptestfilltime, String) + " to " + CType(max_i_dptestfilltime, String))
    '            txtbx_RcpCreateDPFill.Text = Nothing
    '            txtbx_RcpCreateDPFill.Focus()

    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Fill Time")
    '    End If
    'End Sub

    'Private Sub txtbx_RcpCreateDPBleed_Validating(sender As Object, e As CancelEventArgs)
    '    'Check air bleed time

    '    'Check the text is empty
    '    If Not txtbx_RcpCreateDPBleed.Text = "" Then
    '        'Convert to the required type
    '        i_dptestbleedtime = CType(txtbx_RcpCreateDPBleed.Text, Integer)
    '        'Check the value within range
    '        If i_dptestbleedtime < min_i_dptestbleedtime Or i_dptestbleedtime > max_i_dptestbleedtime Then
    '            RecipeMessage(20, "DP Test Bleed Time should be within " + CType(min_i_dptestbleedtime, String) + " to " + CType(max_i_dptestbleedtime, String))
    '            txtbx_RcpCreateDPBleed.Text = Nothing
    '            txtbx_RcpCreateDPBleed.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Bleed Time")

    '    End If
    'End Sub


    'Private Sub txtbx_RcpCreateDPFlow_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for DP Test Flowrate
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpCreateDPFlow.Text = "" And Not txtbx_RcpCreateDPFlow.Text = "." Then
    '        'Convert to the required type
    '        d_dptestflow = CType(txtbx_RcpCreateDPFlow.Text, Decimal)
    '        'Check the value within range
    '        If d_dptestflow < min_d_dptestflow Or d_dptestflow > max_d_dptestflow Then
    '            RecipeMessage(20, "DP Test Flowrate should be within " + CType(min_d_dptestflow, String) + " to " + CType(max_d_dptestflow, String))
    '            txtbx_RcpCreateDPFlow.Text = Nothing
    '            txtbx_RcpCreateDPFlow.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Flowrate")

    '    End If
    'End Sub

    'Private Sub txtbx_RcpCreateDPFlowTol_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for DP Test Flow Tolerance
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpCreateDPFlowTol.Text = "" And Not txtbx_RcpCreateDPFlowTol.Text = "." Then
    '        'Convert to the required type
    '        d_dptestflowtol = CType(txtbx_RcpCreateDPFlowTol.Text, Decimal)
    '        'Check the value within range
    '        If d_dptestflowtol < min_d_dptestflowtol Or d_dptestflowtol > max_d_dptestflowtol Then
    '            RecipeMessage(20, "DP Test Flow Tolerance should be within " + CType(min_d_dptestflowtol, String) + " to " + CType(max_d_dptestflowtol, String))
    '            txtbx_RcpCreateDPFlowTol.Text = Nothing
    '            txtbx_RcpCreateDPFlowTol.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Flow tolerance")

    '    End If
    'End Sub
    'Private Sub txtbx_RcpCreateDPPressure_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for DP Test Pressure
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpCreateDPPressure.Text = "" And Not txtbx_RcpCreateDPPressure.Text = "." Then
    '        'Convert to the required type
    '        d_dptestpressure = CType(txtbx_RcpCreateDPPressure.Text, Decimal)
    '        'Check the value within range
    '        If d_dptestpressure < min_d_dptestpressure Or d_dptestpressure > max_d_dptestpressure Then
    '            RecipeMessage(20, "DP Test Pressure should be within " + CType(min_d_dptestpressure, String) + " to " + CType(max_d_dptestpressure, String))
    '            txtbx_RcpCreateDPPressure.Text = Nothing
    '            txtbx_RcpCreateDPPressure.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Back Pressure")

    '    End If
    'End Sub

    Private Sub txtbx_RcpCreateDPStabilize_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDPStabilize.Validating
        'Check for DP Test Stabilize Time
        'Check the text is empty
        If Not txtbx_RcpCreateDPStabilize.Text = "" Then
            'Convert to the required type
            i_dpteststabilize = CType(txtbx_RcpCreateDPStabilize.Text, Integer)
            'Check the value within range
            If i_dpteststabilize < min_i_dpteststabilize Or i_dpteststabilize > max_i_dpteststabilize Then
                RecipeMessage(20, "DP Test Stabilize Time should be within " + CType(min_i_dpteststabilize, String) + " to " + CType(max_i_dpteststabilize, String))
                txtbx_RcpCreateDPStabilize.Text = Nothing
                txtbx_RcpCreateDPStabilize.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test Stabilize Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDPTime_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDPTime.Validating
        'Check for DP Test Time
        'Check the text is empty
        If Not txtbx_RcpCreateDPTime.Text = "" Then
            'Convert to the required type
            i_dptesttime = CType(txtbx_RcpCreateDPTime.Text, Integer)
            'Check the value within range
            If i_dptesttime < min_i_dptesttime Or i_dptesttime > max_i_dptesttime Then
                RecipeMessage(20, "DP Test Time should be within " + CType(min_i_dptesttime, String) + " to " + CType(max_i_dptesttime, String))
                txtbx_RcpCreateDPTime.Text = Nothing
                txtbx_RcpCreateDPTime.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDPLowLimit_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDPLowLimit.Validating
        'Check for DP Test LowerLimit
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateDPLowLimit.Text = "" And Not txtbx_RcpCreateDPLowLimit.Text = "." Then
            'Convert to the required type
            d_dptestlowlimit = CType(txtbx_RcpCreateDPLowLimit.Text, Decimal)
            'Check the value within range
            If d_dptestlowlimit < min_d_dptestlowlimit Or d_dptestlowlimit > max_d_dptestlowlimit Then
                RecipeMessage(20, "DP Test Lower Limit should be within " + CType(min_d_dptestlowlimit, String) + " to " + CType(max_d_dptestlowlimit, String))
                txtbx_RcpCreateDPLowLimit.Text = Nothing
                txtbx_RcpCreateDPLowLimit.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test Lower Limit")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDPUpLimit_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDPUpLimit.Validating
        'check for dp test upperlimit
        'check the text is empty or has only decimal point
        If Not txtbx_RcpCreateDPUpLimit.Text = "" And Not txtbx_RcpCreateDPUpLimit.Text = "." Then
            'convert to the required type
            d_dptestuplimit = CType(txtbx_RcpCreateDPUpLimit.Text, Decimal)
            'check the value within range
            If d_dptestuplimit < min_d_dptestuplimit Or d_dptestuplimit > max_d_dptestuplimit Then
                RecipeMessage(20, "DP Test Upper Limit should be within " + CType(min_d_dptestuplimit, String) + " to " + CType(max_d_dptestuplimit, String))
                txtbx_RcpCreateDPUpLimit.Text = Nothing
                txtbx_RcpCreateDPUpLimit.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test Upper Limit")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDPPoints_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDPPoints.Validating
        'Check for DP Test points
        'Check the text is empty
        If Not txtbx_RcpCreateDPPoints.Text = "" Then
            'Convert to the required type
            i_dptestpoints = CType(txtbx_RcpCreateDPPoints.Text, Integer)
            'Check the value within range
            If i_dptestpoints < min_i_dptestpoints Or i_dptestpoints > max_i_dptestpoints Then
                RecipeMessage(20, "DP Test Point should be within " + CType(min_i_dptestpoints, String) + " to " + CType(max_i_dptestpoints, String))
                txtbx_RcpCreateDPPoints.Text = Nothing
                txtbx_RcpCreateDPPoints.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test points")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDPTestRPM_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDPTestRPM.Validating, TextBox2.Validating
        'Check for DP Test RPM
        'Check the text is empty
        If Not txtbx_RcpCreateDPTestRPM.Text = "" Then
            'Convert to the required type
            i_dptestrpm = CType(txtbx_RcpCreateDPTestRPM.Text, Integer)
            'Check the value within range
            If i_dptestrpm < min_i_dptestrpm Or i_dptestrpm > max_i_dptestrpm Then
                RecipeMessage(20, "DP Test RPM should be within " + CType(min_i_dptestrpm, String) + " to " + CType(max_i_dptestrpm, String))
                txtbx_RcpCreateDPTestRPM.Text = Nothing
                txtbx_RcpCreateDPTestRPM.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test RPM")
        End If
    End Sub

    'Private Sub txtbx_RcpCreateflush2Fill_Validating(sender As Object, e As CancelEventArgs)
    '    'Check fill time 

    '    'Check the text is empty
    '    If Not txtbx_RcpCreateFlush2Fill.Text = "" Then
    '        'Convert to the required type
    '        i_flush2filltime = CType(txtbx_RcpCreateFlush2Fill.Text, Integer)
    '        'Check the value within range
    '        If i_flush2filltime < min_i_flush2filltime Or i_flush2filltime > max_i_flush2filltime Then
    '            RecipeMessage(20, "Flush-2 Fill Time should be within " + CType(min_i_flush2filltime, String) + " to " + CType(max_i_flush2filltime, String))
    '            txtbx_RcpCreateFlush2Fill.Text = Nothing
    '            txtbx_RcpCreateFlush2Fill.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-2 Fill Time")
    '    End If

    'End Sub

    'Private Sub txtbx_RcpCreateflush2Bleed_Validating(sender As Object, e As CancelEventArgs)
    '    'Check air bleed time

    '    'Check the text is empty
    '    If Not txtbx_RcpCreateFlush2Bleed.Text = "" Then
    '        'Convert to the required type
    '        i_flush2bleedtime = CType(txtbx_RcpCreateFlush2Bleed.Text, Integer)
    '        'Check the value within range
    '        If i_flush2bleedtime < min_i_flush2bleedtime Or i_flush2bleedtime > max_i_flush2bleedtime Then
    '            RecipeMessage(20, "Flush-2 Bleed Time should be within " + CType(min_i_flush2bleedtime, String) + " to " + CType(max_i_flush2bleedtime, String))
    '            txtbx_RcpCreateFlush2Bleed.Text = Nothing
    '            txtbx_RcpCreateFlush2Bleed.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-2 Bleed Time")

    '    End If

    'End Sub

    Private Sub txtbx_RcpCreateflush2Flow_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush2Flow.Validating
        'Check for Flush-2 Flowrate
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateFlush2Flow.Text = "" And Not txtbx_RcpCreateFlush2Flow.Text = "." Then
            'Convert to the required type
            d_flush2flow = CType(txtbx_RcpCreateFlush2Flow.Text, Decimal)
            'Check the value within range
            If d_flush2flow < min_d_flush2flow Or d_flush2flow > max_d_flush2flow Then
                RecipeMessage(20, "Flush-2 Flowrate should be within " + CType(min_d_flush2flow, String) + " to " + CType(max_d_flush2flow, String))
                txtbx_RcpCreateFlush2Flow.Text = Nothing
                txtbx_RcpCreateFlush2Flow.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-2 Flowrate")
        End If
    End Sub

    Private Sub txtbx_RcpCreateflush2FlowTol_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush2FlowTol.Validating
        'Check for Flush-2 Flow Tolerance
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateFlush2FlowTol.Text = "" And Not txtbx_RcpCreateFlush2FlowTol.Text = "." Then
            'Convert to the required type
            d_flush2flowtol = CType(txtbx_RcpCreateFlush2FlowTol.Text, Decimal)
            'Check the value within range
            If d_flush2flowtol < min_d_flush2flowtol Or d_flush2flowtol > max_d_flush2flowtol Then
                RecipeMessage(20, "Flush-2 Flow Tolerance should be within " + CType(min_d_flush2flowtol, String) + " to " + CType(max_d_flush2flowtol, String))
                txtbx_RcpCreateFlush2FlowTol.Text = Nothing
                txtbx_RcpCreateFlush2FlowTol.Focus()

            End If
        Else
            RecipeMessage(19, "Flush-2 Flow tolerance")
        End If
    End Sub

    'Private Sub txtbx_RcpCreateflush2Pressure_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for Flush-2 Pressure
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpCreateFlush2Pressure.Text = "" And Not txtbx_RcpCreateFlush2Pressure.Text = "." Then
    '        'Convert to the required type
    '        d_flush2pressure = CType(txtbx_RcpCreateFlush2Pressure.Text, Decimal)
    '        'Check the value within range
    '        If d_flush2pressure < min_d_flush2pressure Or d_flush2pressure > max_d_flush2pressure Then
    '            RecipeMessage(20, "Flush-2 Pressure should be within " + CType(min_d_flush2pressure, String) + " to " + CType(max_d_flush2pressure, String))
    '            txtbx_RcpCreateFlush2Pressure.Text = Nothing
    '            txtbx_RcpCreateFlush2Pressure.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-2 Back Pressure")
    '    End If
    'End Sub

    Private Sub txtbx_RcpCreateflush2Stabilize_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush2Stabilize.Validating
        'Check for Flush-2 Stabilize Time
        'Check the text is empty
        If Not txtbx_RcpCreateFlush2Stabilize.Text = "" Then
            'Convert to the required type
            i_flush2stabilize = CType(txtbx_RcpCreateFlush2Stabilize.Text, Integer)
            'Check the value within range
            If i_flush2stabilize < min_i_flush2stabilize Or i_flush2stabilize > max_i_flush2stabilize Then
                RecipeMessage(20, "Flush-2 Stabilize Time should be within " + CType(min_i_flush2stabilize, String) + " to " + CType(max_i_flush2stabilize, String))
                txtbx_RcpCreateFlush2Stabilize.Text = Nothing
                txtbx_RcpCreateFlush2Stabilize.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-2 Stabilize Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreateflush2Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush2Time.Validating
        'Check for Flush-2 Time
        'Check the text is empty
        If Not txtbx_RcpCreateFlush2Time.Text = "" Then
            'Convert to the required type
            i_flush2time = CType(txtbx_RcpCreateFlush2Time.Text, Integer)
            'Check the value within range
            If i_flush2time < min_i_flush2time Or i_flush2time > max_i_flush2time Then
                RecipeMessage(20, "Flush-2 Time should be within " + CType(min_i_flush2time, String) + " to " + CType(max_i_flush2time, String))
                txtbx_RcpCreateFlush2Time.Text = Nothing
                txtbx_RcpCreateFlush2Time.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-2 Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreateFlush2RPM_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateFlush2RPM.Validating
        'Check for Flush-2 RPM
        'Check the text is empty
        If Not txtbx_RcpCreateFlush2RPM.Text = "" Then
            'Convert to the required type
            i_flush2rpm = CType(txtbx_RcpCreateFlush2RPM.Text, Integer)
            'Check the value within range
            If i_flush2rpm < min_i_flush2rpm Or i_flush2rpm > max_i_flush2rpm Then
                RecipeMessage(20, "Flush-2 RPM should be within " + CType(min_i_flush2rpm, String) + " to " + CType(max_i_flush2rpm, String))
                txtbx_RcpCreateFlush2RPM.Text = Nothing
                txtbx_RcpCreateFlush2RPM.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-2 RPM")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDrain1Pressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDrain1Pressure.Validating
        'Check for Drain-1 Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateDrain1Pressure.Text = "" And Not txtbx_RcpCreateDrain1Pressure.Text = "." Then
            'Convert to the required type
            d_drain1pressure = CType(txtbx_RcpCreateDrain1Pressure.Text, Decimal)
            'Check the value within range
            If d_drain1pressure < min_d_drain1pressure Or d_drain1pressure > max_d_drain1pressure Then
                RecipeMessage(20, "Drain-1 Pressure should be within " + CType(min_d_drain1pressure, String) + " to " + CType(max_d_drain1pressure, String))
                txtbx_RcpCreateDrain1Pressure.Text = Nothing
                txtbx_RcpCreateDrain1Pressure.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-1 Pressure")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDrain1Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDrain1Time.Validating
        'Check for Drain-1 Time
        'Check the text is empty
        If Not txtbx_RcpCreateDrain1Time.Text = "" Then
            'Convert to the required type
            i_drain1time = CType(txtbx_RcpCreateDrain1Time.Text, Integer)
            'Check the value within range
            If i_drain1time < min_i_drain1time Or i_drain1time > max_i_drain1time Then
                RecipeMessage(20, "Drain-1 Time should be within " + CType(min_i_drain1time, String) + " to " + CType(max_i_drain1time, String))
                txtbx_RcpCreateDrain1Time.Text = Nothing
                txtbx_RcpCreateDrain1Time.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-1 Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDrain2Pressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDrain2Pressure.Validating
        'Check for Drain-2 Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateDrain2Pressure.Text = "" And Not txtbx_RcpCreateDrain2Pressure.Text = "." Then
            'Convert to the required type
            d_drain2pressure = CType(txtbx_RcpCreateDrain2Pressure.Text, Decimal)
            'Check the value within range
            If d_drain2pressure < min_d_drain2pressure Or d_drain2pressure > max_d_drain2pressure Then
                RecipeMessage(20, "Drain-2 Pressure should be within " + CType(min_d_drain2pressure, String) + " to " + CType(max_d_drain2pressure, String))
                txtbx_RcpCreateDrain2Pressure.Text = Nothing
                txtbx_RcpCreateDrain2Pressure.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-2 Pressure")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDrain2Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDrain2Time.Validating
        'Check for Drain-2 Time
        'Check the text is empty
        If Not txtbx_RcpCreateDrain2Time.Text = "" Then
            'Convert to the required type
            i_drain2time = CType(txtbx_RcpCreateDrain2Time.Text, Integer)
            'Check the value within range
            If i_drain2time < min_i_drain2time Or i_drain2time > max_i_drain2time Then
                RecipeMessage(20, "Drain-2 Time should be within " + CType(min_i_drain2time, String) + " to " + CType(max_i_drain2time, String))
                txtbx_RcpCreateDrain2Time.Text = Nothing
                txtbx_RcpCreateDrain2Time.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-2 Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDrain3Pressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDrain3Pressure.Validating
        'Check for FDrain-3 Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateDrain3Pressure.Text = "" And Not txtbx_RcpCreateDrain3Pressure.Text = "." Then
            'Convert to the required type
            d_drain3pressure = CType(txtbx_RcpCreateDrain3Pressure.Text, Decimal)
            'Check the value within range
            If d_drain3pressure < min_d_drain3pressure Or d_drain3pressure > max_d_drain3pressure Then
                RecipeMessage(20, "Drain-3 Pressure should be within " + CType(min_d_drain3pressure, String) + " to " + CType(max_d_drain3pressure, String))
                txtbx_RcpCreateDrain3Pressure.Text = Nothing
                txtbx_RcpCreateDrain3Pressure.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-3 Pressure")
        End If

    End Sub

    Private Sub txtbx_RcpCreateDrain3Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDrain3Time.Validating
        'Check for Drain-3 Time
        'Check the text is empty
        If Not txtbx_RcpCreateDrain3Time.Text = "" Then
            'Convert to the required type
            i_drain3time = CType(txtbx_RcpCreateDrain3Time.Text, Integer)
            'Check the value within range
            If i_drain3time < min_i_drain3time Or i_drain3time > max_i_drain3time Then
                RecipeMessage(20, "Drain-3 Time should be within " + CType(min_i_drain3time, String) + " to " + CType(max_i_drain3time, String))
                txtbx_RcpCreateDrain3Time.Text = Nothing
                txtbx_RcpCreateDrain3Time.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-3 Time")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDrain4Pressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDrain4Pressure.Validating
        'Check for FDrain-4 Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpCreateDrain4Pressure.Text = "" And Not txtbx_RcpCreateDrain4Pressure.Text = "." Then
            'Convert to the required type
            d_drain4pressure = CType(txtbx_RcpCreateDrain4Pressure.Text, Decimal)
            'Check the value within range
            If d_drain4pressure < min_d_drain4pressure Or d_drain4pressure > max_d_drain4pressure Then
                RecipeMessage(20, "Drain-4 Pressure should be within " + CType(min_d_drain4pressure, String) + " to " + CType(max_d_drain4pressure, String))
                txtbx_RcpCreateDrain4Pressure.Text = Nothing
                txtbx_RcpCreateDrain4Pressure.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-4 Pressure")
        End If
    End Sub

    Private Sub txtbx_RcpCreateDrain4Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpCreateDrain4Time.Validating
        'Check for Drain-4 Time
        'Check the text is empty
        If Not txtbx_RcpCreateDrain4Time.Text = "" Then
            'Convert to the required type
            i_drain4time = CType(txtbx_RcpCreateDrain4Time.Text, Integer)
            'Check the value within range
            If i_drain4time < min_i_drain4time Or i_drain4time > max_i_drain4time Then
                RecipeMessage(20, "Drain-4 Time should be within " + CType(min_i_drain4time, String) + " to " + CType(max_i_drain4time, String))
                txtbx_RcpCreateDrain4Time.Text = Nothing
                txtbx_RcpCreateDrain4Time.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-4 Time")
        End If
    End Sub
#End Region

#Region "Recipe ID Creation"
    Private Sub btn_RecipeIDCreate_Click(sender As Object, e As EventArgs) Handles btn_RecipeIDCreate.Click
        ' Declare Parameters
        Dim FilterTypeID As Integer = cmbx_RcpCreateFilterType.SelectedIndex
        Dim PartID As String = cmbx_RcpCreatePartID.Text

        Dim TypeID As Integer = cmbx_RcpCreateType.SelectedIndex
        Dim RecipeID As String = Formatstring(txtbx_RcpCreateRecipeID.Text)
        Dim onContinue As Boolean = True
        Dim dtrecipeidcheck As DataTable = SQL.ReadRecords("select * from RecipeTable where recipe_id = '" + RecipeID + "'")

        'Check Filter Type Empty fields
        If onContinue = True Then
            If FilterTypeID = 0 Then
                RecipeMessage(1)
                onContinue = False
            End If
        End If
        'Check Part ID Empty fields
        If onContinue = True Then
            If cmbx_RcpCreatePartID.SelectedIndex = 0 Then
                RecipeMessage(3)
                onContinue = False
            End If
        End If

        'Check Type Empty fields
        If onContinue = True Then
            If TypeID = 0 Then
                RecipeMessage(5)
                onContinue = False
            End If
        End If
        'Check Recipe ID Empty fields
        If onContinue = True Then
            If RecipeID.Length = 0 Then
                RecipeMessage(6)
                onContinue = False
            End If
        End If
        'Check Recipe ID Length exceed
        If onContinue = True Then
            If RecipeID.Length < 4 Or RecipeID.Length > 20 Then
                RecipeMessage(12, $"Recipe ID is limited from 4 to 20 Characters, Try Again")
                onContinue = False
            End If
        End If
        'Check Recipe ID has special character
        If onContinue = True Then
            If Checkspecial(RecipeID) <> -1 Then
                RecipeMessage(13)
                onContinue = False
            End If
        End If
        'Check Recipe ID already exists
        If onContinue = True Then
            If dtrecipeidcheck.Rows.Count <> 0 Then
                RecipeMessage(8)
                onContinue = False
            End If
        End If
        ''Check Pump Mode has something selected
        'If onContinue = True Then
        '    If cmbx_RcpCreatePrepPumpMode.SelectedIndex < 0 Then
        '        MsgBox("Preparation - No Pump Mode Selected", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
        '        onContinue = False
        '    Else
        '        Select Case cmbx_RcpCreatePrepPumpMode.SelectedIndex
        '            Case 0
        '                str_prepspeedenable = "Disable"
        '            Case 1
        '                str_prepspeedenable = "Enable"
        '        End Select
        '    End If
        'End If

#Region "Recipe Create Parameter Range Validating Event"
        If onContinue = True Then
            'Check verification tolerance

            'Check the text is empty or has only decimal point
            If Not txtbx_RcpCreateVerTol.Text = "" And Not txtbx_RcpCreateVerTol.Text = "." Then
                'Convert to the required type
                d_vertol = CType(txtbx_RcpCreateVerTol.Text, Decimal)
                'Check the value within range
                If d_vertol < min_d_vertol Or d_vertol > max_d_vertol Then
                    RecipeMessage(20, "Verification tolerance should be within " + CType(min_d_vertol, String) + " to " + CType(max_d_vertol, String))
                    txtbx_RcpCreateVerTol.Text = Nothing
                    txtbx_RcpCreateVerTol.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Verification tolerance")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check fill time 

            'Check the text is empty
            If Not txtbx_RcpCreatePrepFill.Text = "" Then
                'Convert to the required type
                i_prepfilltime = CType(txtbx_RcpCreatePrepFill.Text, Integer)
                'Check the value within range
                If i_prepfilltime < min_i_prepfilltime Or i_prepfilltime > max_i_prepfilltime Then
                    RecipeMessage(20, "Preparation Fill Time should be within " + CType(min_i_prepfilltime, String) + " to " + CType(max_i_prepfilltime, String))
                    txtbx_RcpCreatePrepFill.Text = Nothing
                    txtbx_RcpCreatePrepFill.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Fill Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Bleed time 

            'Check the text is empty
            If Not txtbx_RcpCreatePrepBleed.Text = "" Then
                'Convert to the required type
                i_prepbleedtime = CType(txtbx_RcpCreatePrepBleed.Text, Integer)
                'Check the value within range
                If i_prepbleedtime < min_i_prepbleedtime Or i_prepbleedtime > max_i_prepbleedtime Then
                    RecipeMessage(20, "Preparation Bleed Time should be within " + CType(min_i_prepbleedtime, String) + " to " + CType(max_i_prepbleedtime, String))
                    txtbx_RcpCreatePrepBleed.Text = Nothing
                    txtbx_RcpCreatePrepBleed.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Bleed Time")
                onContinue = False
            End If
        End If

        'If onContinue = True Then
        '    'Check for Flowrate
        '    'Check the text is empty or has only decimal point
        '    If Not txtbx_RcpCreatePrepFlow.Text = "" And Not txtbx_RcpCreatePrepFlow.Text = "." Then
        '        'Convert to the required type
        '        d_prepflow = CType(txtbx_RcpCreatePrepFlow.Text, Decimal)
        '        'Check the value within range
        '        If d_prepflow < min_d_prepflow Or d_prepflow > max_d_prepflow Then
        '            RecipeMessage(20, "Preparation Flowrate should be within " + CType(min_d_prepflow, String) + " to " + CType(max_d_prepflow, String))
        '            txtbx_RcpCreatePrepFlow.Text = Nothing
        '            txtbx_RcpCreatePrepFlow.Focus()
        '            onContinue = False
        '        End If
        '    Else
        '        RecipeMessage(19, "Preparation Flowrate")
        '        onContinue = False
        '    End If
        'End If

        'If onContinue = True Then
        '    'Check for Flowrate Tolerance
        '    'Check the text is empty or has only decimal point
        '    If Not txtbx_RcpCreatePrepFlowTol.Text = "" And Not txtbx_RcpCreatePrepFlowTol.Text = "." Then
        '        'Convert to the required type
        '        d_prepflowtol = CType(txtbx_RcpCreatePrepFlowTol.Text, Decimal)
        '        'Check the value within range
        '        If d_prepflowtol < min_d_prepflowtol Or d_prepflowtol > max_d_prepflowtol Then
        '            RecipeMessage(20, "Preparation Flowrate Tolerance should be within " + CType(min_d_prepflowtol, String) + " to " + CType(max_d_prepflowtol, String))
        '            txtbx_RcpCreatePrepFlowTol.Text = Nothing
        '            txtbx_RcpCreatePrepFlowTol.Focus()
        '            onContinue = False
        '        End If
        '    Else
        '        RecipeMessage(19, "Preparation Flowrate Tolerance")
        '        onContinue = False
        '    End If
        'End If

        If onContinue = True Then
            'Check for Back Pressure 2
            'Check the text is empty or has only decimal point
            If Not txtbx_RcpCreatePrepPressure.Text = "" And Not txtbx_RcpCreatePrepPressure.Text = "." Then
                'Convert to the required type
                d_preppressure = CType(txtbx_RcpCreatePrepPressure.Text, Decimal)
                'Check the value within range
                If d_preppressure < min_d_preppressure Or d_preppressure > max_d_preppressure Then
                    RecipeMessage(20, "Preparation Back Pressure 2 should be within " + CType(min_d_preppressure, String) + " to " + CType(max_d_preppressure, String))
                    txtbx_RcpCreatePrepPressure.Text = Nothing
                    txtbx_RcpCreatePrepPressure.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Back Pressure")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check for Back Pressure 1
            'Check the text is empty or has only decimal point
            If Not txtbx_RcpCreatePrepPressureDrop.Text = "" And Not txtbx_RcpCreatePrepPressureDrop.Text = "." Then
                'Convert to the required type
                d_preppressuredrop = CType(txtbx_RcpCreatePrepPressureDrop.Text, Decimal)
                'Check the value within range
                If d_preppressuredrop < min_d_preppressuredrop Or d_preppressuredrop > max_d_preppressuredrop Then
                    RecipeMessage(20, "Preparation Back Pressure 1 should be within " + CType(min_d_preppressuredrop, String) + " to " + CType(max_d_preppressuredrop, String))
                    txtbx_RcpCreatePrepPressureDrop.Text = Nothing
                    txtbx_RcpCreatePrepPressureDrop.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Back Pressure 1")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Pressure 1 Time

            'Check the text is empty
            If Not txtbx_RcpCreatePrepPressureDropTime.Text = "" Then
                'Convert to the required type
                i_preppressuredroptime = CType(txtbx_RcpCreatePrepPressureDropTime.Text, Integer)
                'Check the value within range
                If i_preppressuredroptime < min_i_preppressuredroptime Or i_preppressuredroptime > max_i_preppressuredroptime Then
                    RecipeMessage(20, "Preparation Back Pressure 1 Time should be within " + CType(min_i_preppressuredroptime, String) + " to " + CType(max_i_preppressuredroptime, String))
                    txtbx_RcpCreatePrepPressureDropTime.Text = Nothing
                    txtbx_RcpCreatePrepPressureDropTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Back Pressure 1 Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Prefill Start Time

            'Check the text is empty
            If Not txtbx_RcpCreatePrepPrefillStartTime.Text = "" Then
                'Convert to the required type
                i_prepprefillstarttime = CType(txtbx_RcpCreatePrepPrefillStartTime.Text, Integer)
                'Check the value within range
                If i_prepprefillstarttime < min_i_prepprefillstarttime Or i_prepprefillstarttime > max_i_prepprefillstarttime Then
                    RecipeMessage(20, "Preparation Vent Start Time should be within " + CType(min_i_prepprefillstarttime, String) + " to " + CType(max_i_prepprefillstarttime, String))
                    txtbx_RcpCreatePrepPrefillStartTime.Text = Nothing
                    txtbx_RcpCreatePrepPrefillStartTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Vent Start Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Prefill Time

            'Check the text is empty
            If Not txtbx_RcpCreatePrepPrefillTime.Text = "" Then
                'Convert to the required type
                i_prepprefilltime = CType(txtbx_RcpCreatePrepPrefillTime.Text, Integer)
                'Check the value within range
                If i_prepprefilltime < min_i_prepprefilltime Or i_prepprefilltime > max_i_prepprefilltime Then
                    RecipeMessage(20, "Preparation Vent Time should be within " + CType(min_i_prepprefilltime, String) + " to " + CType(max_i_prepprefilltime, String))
                    txtbx_RcpCreatePrepPrefillTime.Text = Nothing
                    txtbx_RcpCreatePrepPrefillTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Vent Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Drain Start Time

            'Check the text is empty
            If Not txtbx_RcpCreatePrepDrainStartTime.Text = "" Then
                'Convert to the required type
                i_prepdrainstarttime = CType(txtbx_RcpCreatePrepDrainStartTime.Text, Integer)
                'Check the value within range
                If i_prepdrainstarttime < min_i_prepDrainstarttime Or i_prepdrainstarttime > max_i_prepDrainstarttime Then
                    RecipeMessage(20, "Preparation Drain Start Time should be within " + CType(min_i_prepdrainstarttime, String) + " to " + CType(max_i_prepdrainstarttime, String))
                    txtbx_RcpCreatePrepDrainStartTime.Text = Nothing
                    txtbx_RcpCreatePrepDrainStartTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Drain Start Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Drain Time

            'Check the text is empty
            If Not txtbx_RcpCreatePrepDrainTime.Text = "" Then
                'Convert to the required type
                i_prepdraintime = CType(txtbx_RcpCreatePrepDrainTime.Text, Integer)
                'Check the value within range
                If i_prepdraintime < min_i_prepdraintime Or i_prepdraintime > max_i_prepdraintime Then
                    RecipeMessage(20, "Preparation Drain Time should be within " + CType(min_i_prepdraintime, String) + " to " + CType(max_i_prepdraintime, String))
                    txtbx_RcpCreatePrepDrainTime.Text = Nothing
                    txtbx_RcpCreatePrepDrainTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Drain Time")
                onContinue = False
            End If
        End If

        If onContinue = True And rdbtn_RcpCreatePrepPumpSpeed.Checked = True Then
            'Check Pump RPM-1

            'Check the text is empty
            If Not txtbx_RcpCreatePrepRPM.Text = "" Then
                'Convert to the required type
                i_preprpm1 = CType(txtbx_RcpCreatePrepRPM.Text, Integer)
                'Check the value within range
                If i_preprpm1 < min_i_preprpm1 Or i_preprpm1 > max_i_preprpm1 Then
                    RecipeMessage(20, "Preparation Pump Speed should be within " + CType(min_i_preprpm1, String) + " to " + CType(max_i_preprpm1, String))
                    txtbx_RcpCreatePrepRPM.Text = Nothing
                    txtbx_RcpCreatePrepRPM.Focus()
                    onContinue = False

                End If
            Else
                RecipeMessage(19, "Preparation Pump Speed")
                onContinue = False
            End If
        End If

        'If onContinue = True And cmbx_RcpCreatePrepPumpMode.SelectedIndex = 1 Then
        '    'Check Pump RPM-2

        '    'Check the text is empty
        '    If Not txtbx_RcpCreatePrepRPM2.Text = "" Then
        '        'Convert to the required type
        '        i_preprpm2 = CType(txtbx_RcpCreatePrepRPM2.Text, Integer)
        '        'Check the value within range
        '        If i_preprpm2 < min_i_preprpm2 Or i_preprpm2 > max_i_preprpm2 Then
        '            RecipeMessage(20, "Preparation Pump Speed-2 should be within " + CType(min_i_preprpm2, String) + " to " + CType(max_i_preprpm2, String))
        '            txtbx_RcpCreatePrepRPM2.Text = Nothing
        '            txtbx_RcpCreatePrepRPM2.Focus()
        '            onContinue = False

        '        End If
        '    Else
        '        RecipeMessage(19, "Preparation Pump Speed-2")
        '        onContinue = False
        '    End If

        'End If

        'In Case of Flush-1 Enabled, the Field should not be empty
        If checkbx_CreateFlush1.Checked = True Then

            'If onContinue = True Then
            '    'Check fill time 

            '    'Check the text is empty
            '    If Not txtbx_RcpCreateFlush1Fill.Text = "" Then
            '        'Convert to the required type
            '        i_flush1filltime = CType(txtbx_RcpCreateFlush1Fill.Text, Integer)
            '        'Check the value within range
            '        If i_flush1filltime < min_i_flush1filltime Or i_flush1filltime > max_i_flush1filltime Then
            '            RecipeMessage(20, "Flush-1 Fill Time should be within " + CType(min_i_flush1filltime, String) + " to " + CType(max_i_flush1filltime, String))
            '            txtbx_RcpCreateFlush1Fill.Text = Nothing
            '            txtbx_RcpCreateFlush1Fill.Focus()
            '            onContinue = False

            '        End If
            '    Else
            '        RecipeMessage(19, "Flush-1 Fill Time")
            '        onContinue = False
            '    End If

            'End If

            'If onContinue = True Then
            '    'Check air bleed time

            '    'Check the text is empty
            '    If Not txtbx_RcpCreateFlush1Bleed.Text = "" Then
            '        'Convert to the required type
            '        i_flush1bleedtime = CType(txtbx_RcpCreateFlush1Bleed.Text, Integer)
            '        'Check the value within range
            '        If i_flush1bleedtime < min_i_flush1bleedtime Or i_flush1bleedtime > max_i_flush1bleedtime Then
            '            RecipeMessage(20, "Flush-1 Bleed Time should be within " + CType(min_i_flush1bleedtime, String) + " to " + CType(max_i_flush1bleedtime, String))
            '            txtbx_RcpCreateFlush1Bleed.Text = Nothing
            '            txtbx_RcpCreateFlush1Bleed.Focus()
            '            onContinue = False
            '        End If
            '    Else
            '        RecipeMessage(19, "Flush-1 Bleed Time")
            '        onContinue = False
            '    End If

            'End If

            If onContinue = True Then
                'Check for Flush-1 Flowrate
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateFlush1Flow.Text = "" And Not txtbx_RcpCreateFlush1Flow.Text = "." Then
                    'Convert to the required type
                    d_flush1flow = CType(txtbx_RcpCreateFlush1Flow.Text, Decimal)
                    'Check the value within range
                    If d_flush1flow < min_d_flush1flow Or d_flush1flow > max_d_flush1flow Then
                        RecipeMessage(20, "Flush-1 Flowrate should be within " + CType(min_d_flush1flow, String) + " to " + CType(max_d_flush1flow, String))
                        txtbx_RcpCreateFlush1Flow.Text = Nothing
                        txtbx_RcpCreateFlush1Flow.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Flowrate")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-1 Flow Tolerance
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateFlush1FlowTol.Text = "" And Not txtbx_RcpCreateFlush1FlowTol.Text = "." Then
                    'Convert to the required type
                    d_flush1flowtol = CType(txtbx_RcpCreateFlush1FlowTol.Text, Decimal)
                    'Check the value within range
                    If d_flush1flowtol < min_d_flush1flowtol Or d_flush1flowtol > max_d_flush1flowtol Then
                        RecipeMessage(20, "Flush-1 Flow Tolerance should be within " + CType(min_d_flush1flowtol, String) + " to " + CType(max_d_flush1flowtol, String))
                        txtbx_RcpCreateFlush1FlowTol.Text = Nothing
                        txtbx_RcpCreateFlush1FlowTol.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Flow Tolerance")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-1 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateFlush1Pressure.Text = "" And Not txtbx_RcpCreateFlush1Pressure.Text = "." Then
                    'Convert to the required type
                    d_flush1pressure = CType(txtbx_RcpCreateFlush1Pressure.Text, Decimal)
                    'Check the value within range
                    If d_flush1pressure < min_d_flush1pressure Or d_flush1pressure > max_d_flush1pressure Then
                        RecipeMessage(20, "Flush-1 Pressure should be within " + CType(min_d_flush1pressure, String) + " to " + CType(max_d_flush1pressure, String))
                        txtbx_RcpCreateFlush1Pressure.Text = Nothing
                        txtbx_RcpCreateFlush1Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Back Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-1 Stabilize Time
                'Check the text is empty
                If Not txtbx_RcpCreateFlush1Stabilize.Text = "" Then
                    'Convert to the required type
                    i_flush1stabilize = CType(txtbx_RcpCreateFlush1Stabilize.Text, Integer)
                    'Check the value within range
                    If i_flush1stabilize < min_i_flush1stabilize Or i_flush1stabilize > max_i_flush1stabilize Then
                        RecipeMessage(20, "Flush-1 Stabilize Time should be within " + CType(min_i_flush1stabilize, String) + " to " + CType(max_i_flush1stabilize, String))
                        txtbx_RcpCreateFlush1Stabilize.Text = Nothing
                        txtbx_RcpCreateFlush1Stabilize.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Stabilize Time")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-1 Time
                'Check the text is empty
                If Not txtbx_RcpCreateFlush1Time.Text = "" Then
                    'Convert to the required type
                    i_flush1time = CType(txtbx_RcpCreateFlush1Time.Text, Integer)
                    'Check the value within range
                    If i_flush1time < min_i_flush1time Or i_flush1time > max_i_flush1time Then
                        RecipeMessage(20, "Flush-1 Time should be within " + CType(min_i_flush1time, String) + " to " + CType(max_i_flush1time, String))
                        txtbx_RcpCreateFlush1Time.Text = Nothing
                        txtbx_RcpCreateFlush1Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Time")
                    onContinue = False
                End If
            End If

            If onContinue = True And rdbtn_RcpCreateFlush1PumpSpeed.Checked = True Then
                'Check Flush-1 Pump RPM
                'Check the text is empty
                If Not txtbx_RcpCreateFlush1RPM.Text = "" Then
                    'Convert to the required type
                    i_flush1rpm = CType(txtbx_RcpCreateFlush1RPM.Text, Integer)
                    'Check the value within range
                    If i_flush1rpm < min_i_flush1rpm Or i_flush1rpm > max_i_flush1rpm Then
                        RecipeMessage(20, "Flush-1 Pump Speed should be within " + CType(min_i_flush1rpm, String) + " to " + CType(max_i_flush1rpm, String))
                        txtbx_RcpCreateFlush1RPM.Text = Nothing
                        txtbx_RcpCreateFlush1RPM.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Pump Speed")
                    onContinue = False
                End If
            End If
        End If

        'In Case of Flush-2 Enabled, the Field should not be empty
        If checkbx_CreateFlush2.Checked = True Then

            'If onContinue = True Then
            '    'Check fill time 

            '    'Check the text is empty
            '    If Not txtbx_RcpCreateFlush2Fill.Text = "" Then
            '        'Convert to the required type
            '        i_flush2filltime = CType(txtbx_RcpCreateFlush2Fill.Text, Integer)
            '        'Check the value within range
            '        If i_flush2filltime < min_i_flush2filltime Or i_flush2filltime > max_i_flush2filltime Then
            '            RecipeMessage(20, "Flush-2 Fill Time should be within " + CType(min_i_flush2filltime, String) + " to " + CType(max_i_flush2filltime, String))
            '            txtbx_RcpCreateFlush2Fill.Text = Nothing
            '            txtbx_RcpCreateFlush2Fill.Focus()
            '            onContinue = False
            '        End If
            '    Else
            '        RecipeMessage(19, "Flush-2 Fill Time")
            '        onContinue = False
            '    End If

            'End If

            'If onContinue = True Then
            '    'Check air bleed time

            '    'Check the text is empty
            '    If Not txtbx_RcpCreateFlush2Bleed.Text = "" Then
            '        'Convert to the required type
            '        i_flush2bleedtime = CType(txtbx_RcpCreateFlush2Bleed.Text, Integer)
            '        'Check the value within range
            '        If i_flush2bleedtime < min_i_flush2bleedtime Or i_flush2bleedtime > max_i_flush2bleedtime Then
            '            RecipeMessage(20, "Flush-2 Bleed Time should be within " + CType(min_i_flush2bleedtime, String) + " to " + CType(max_i_flush2bleedtime, String))
            '            txtbx_RcpCreateFlush2Bleed.Text = Nothing
            '            txtbx_RcpCreateFlush2Bleed.Focus()
            '            onContinue = False
            '        End If
            '    Else
            '        RecipeMessage(19, "Flush-2 Bleed Time")
            '        onContinue = False
            '    End If

            'End If

            If onContinue = True Then
                'Check for Flush-2 Flowrate
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateFlush2Flow.Text = "" And Not txtbx_RcpCreateFlush2Flow.Text = "." Then
                    'Convert to the required type
                    d_flush2flow = CType(txtbx_RcpCreateFlush2Flow.Text, Decimal)
                    'Check the value within range
                    If d_flush2flow < min_d_flush2flow Or d_flush2flow > max_d_flush2flow Then
                        RecipeMessage(20, "Flush-2 Flowrate should be within " + CType(min_d_flush2flow, String) + " to " + CType(max_d_flush2flow, String))
                        txtbx_RcpCreateFlush2Flow.Text = Nothing
                        txtbx_RcpCreateFlush2Flow.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Flowrate")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-2 Flow Tolerance
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateFlush2FlowTol.Text = "" And Not txtbx_RcpCreateFlush2FlowTol.Text = "." Then
                    'Convert to the required type
                    d_flush2flowtol = CType(txtbx_RcpCreateFlush2FlowTol.Text, Decimal)
                    'Check the value within range
                    If d_flush2flowtol < min_d_flush2flowtol Or d_flush2flowtol > max_d_flush2flowtol Then
                        RecipeMessage(20, "Flush-2 Flow Tolerance should be within " + CType(min_d_flush2flowtol, String) + " to " + CType(max_d_flush2flowtol, String))
                        txtbx_RcpCreateFlush2FlowTol.Text = Nothing
                        txtbx_RcpCreateFlush2FlowTol.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Flow Tolerance")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-2 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateFlush2Pressure.Text = "" And Not txtbx_RcpCreateFlush2Pressure.Text = "." Then
                    'Convert to the required type
                    d_flush2pressure = CType(txtbx_RcpCreateFlush2Pressure.Text, Decimal)
                    'Check the value within range
                    If d_flush2pressure < min_d_flush2pressure Or d_flush2pressure > max_d_flush2pressure Then
                        RecipeMessage(20, "Flush-2 Pressure should be within " + CType(min_d_flush2pressure, String) + " to " + CType(max_d_flush2pressure, String))
                        txtbx_RcpCreateFlush2Pressure.Text = Nothing
                        txtbx_RcpCreateFlush2Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Back Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-2 Stabilize Time
                'Check the text is empty
                If Not txtbx_RcpCreateFlush2Stabilize.Text = "" Then
                    'Convert to the required type
                    i_flush2stabilize = CType(txtbx_RcpCreateFlush2Stabilize.Text, Integer)
                    'Check the value within range
                    If i_flush2stabilize < min_i_flush2stabilize Or i_flush2stabilize > max_i_flush2stabilize Then
                        RecipeMessage(20, "Flush-2 Stabilize Time should be within " + CType(min_i_flush2stabilize, String) + " to " + CType(max_i_flush2stabilize, String))
                        txtbx_RcpCreateFlush2Stabilize.Text = Nothing
                        txtbx_RcpCreateFlush2Stabilize.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Stabilize Time")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-2 Time
                'Check the text is empty
                If Not txtbx_RcpCreateFlush2Time.Text = "" Then
                    'Convert to the required type
                    i_flush2time = CType(txtbx_RcpCreateFlush2Time.Text, Integer)
                    'Check the value within range
                    If i_flush2time < min_i_flush2time Or i_flush2time > max_i_flush2time Then
                        RecipeMessage(20, "Flush-2 Time should be within " + CType(min_i_flush2time, String) + " to " + CType(max_i_flush2time, String))
                        txtbx_RcpCreateFlush2Time.Text = Nothing
                        txtbx_RcpCreateFlush2Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Time")
                    onContinue = False
                End If
            End If

            If onContinue = True And rdbtn_RcpCreateFlush2PumpSpeed.Checked = True Then
                'Check Flush-2 Pump RPM
                'Check the text is empty
                If Not txtbx_RcpCreateFlush2RPM.Text = "" Then
                    'Convert to the required type
                    i_flush2rpm = CType(txtbx_RcpCreateFlush2RPM.Text, Integer)
                    'Check the value within range
                    If i_flush2rpm < min_i_flush2rpm Or i_flush2rpm > max_i_flush2rpm Then
                        RecipeMessage(20, "Flush-2 Pump Speed should be within " + CType(min_i_flush2rpm, String) + " to " + CType(max_i_flush2rpm, String))
                        txtbx_RcpCreateFlush2RPM.Text = Nothing
                        txtbx_RcpCreateFlush2RPM.Focus()
                        onContinue = False

                    End If
                Else
                    RecipeMessage(19, "Flush-2 Pump Speed")
                    onContinue = False
                End If
            End If
        End If

        'In Case of DP Test-1 Enabled, the Field should not be empty
        If checkbx_CreateDPTest1.Checked = True Then

            'If onContinue = True Then
            '    'Check fill time 

            '    'Check the text is empty
            '    If Not txtbx_RcpCreateDPFill.Text = "" Then
            '        'Convert to the required type
            '        i_dptestfilltime = CType(txtbx_RcpCreateDPFill.Text, Integer)
            '        'Check the value within range
            '        If i_dptestfilltime < min_i_dptestfilltime Or i_dptestfilltime > max_i_dptestfilltime Then
            '            RecipeMessage(20, "DP Test Fill Time should be within " + CType(min_i_dptestfilltime, String) + " to " + CType(max_i_dptestfilltime, String))
            '            txtbx_RcpCreateDPFill.Text = Nothing
            '            txtbx_RcpCreateDPFill.Focus()
            '            onContinue = False

            '        End If
            '    Else
            '        RecipeMessage(19, "DP Test Fill Time")
            '        onContinue = False
            '    End If
            'End If

            'If onContinue = True Then
            '    'Check air bleed time

            '    'Check the text is empty
            '    If Not txtbx_RcpCreateDPBleed.Text = "" Then
            '        'Convert to the required type
            '        i_dptestbleedtime = CType(txtbx_RcpCreateDPBleed.Text, Integer)
            '        'Check the value within range
            '        If i_dptestbleedtime < min_i_dptestbleedtime Or i_dptestbleedtime > max_i_dptestbleedtime Then
            '            RecipeMessage(20, "DP Test Bleed Time should be within " + CType(min_i_dptestbleedtime, String) + " to " + CType(max_i_dptestbleedtime, String))
            '            txtbx_RcpCreateDPBleed.Text = Nothing
            '            txtbx_RcpCreateDPBleed.Focus()
            '            onContinue = False
            '        End If
            '    Else
            '        RecipeMessage(19, "DP Test Bleed Time")
            '        onContinue = False
            '    End If
            'End If


            If onContinue = True Then
                'Check for DP Test Flowrate
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateDPFlow.Text = "" And Not txtbx_RcpCreateDPFlow.Text = "." Then
                    'Convert to the required type
                    d_dptestflow = CType(txtbx_RcpCreateDPFlow.Text, Decimal)
                    'Check the value within range
                    If d_dptestflow < min_d_dptestflow Or d_dptestflow > max_d_dptestflow Then
                        RecipeMessage(20, "DP Test Flowrate should be within " + CType(min_d_dptestflow, String) + " to " + CType(max_d_dptestflow, String))
                        txtbx_RcpCreateDPFlow.Text = Nothing
                        txtbx_RcpCreateDPFlow.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Flowrate")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test Flow Tolerance
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateDPFlowTol.Text = "" And Not txtbx_RcpCreateDPFlowTol.Text = "." Then
                    'Convert to the required type
                    d_dptestflowtol = CType(txtbx_RcpCreateDPFlowTol.Text, Decimal)
                    'Check the value within range
                    If d_dptestflowtol < min_d_dptestflowtol Or d_dptestflowtol > max_d_dptestflowtol Then
                        RecipeMessage(20, "DP Test Flow Tolerance should be within " + CType(min_d_dptestflowtol, String) + " to " + CType(max_d_dptestflowtol, String))
                        txtbx_RcpCreateDPFlowTol.Text = Nothing
                        txtbx_RcpCreateDPFlowTol.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Flow tolerance")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Back Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateDPPressure.Text = "" And Not txtbx_RcpCreateDPPressure.Text = "." Then
                    'Convert to the required type
                    d_dptestpressure = CType(txtbx_RcpCreateDPPressure.Text, Decimal)
                    'Check the value within range
                    If d_dptestpressure < min_d_dptestpressure Or d_dptestpressure > max_d_dptestpressure Then
                        RecipeMessage(20, "DP Back Pressure should be within " + CType(min_d_dptestpressure, String) + " to " + CType(max_d_dptestpressure, String))
                        txtbx_RcpCreateDPPressure.Text = Nothing
                        txtbx_RcpCreateDPPressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Back Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test Stabilize Time
                'Check the text is empty
                If Not txtbx_RcpCreateDPStabilize.Text = "" Then
                    'Convert to the required type
                    i_dpteststabilize = CType(txtbx_RcpCreateDPStabilize.Text, Integer)
                    'Check the value within range
                    If i_dpteststabilize < min_i_dpteststabilize Or i_dpteststabilize > max_i_dpteststabilize Then
                        RecipeMessage(20, "DP Test Stabilize Time should be within " + CType(min_i_dpteststabilize, String) + " to " + CType(max_i_dpteststabilize, String))
                        txtbx_RcpCreateDPStabilize.Text = Nothing
                        txtbx_RcpCreateDPStabilize.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Stabilize Time")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test Time
                'Check the text is empty
                If Not txtbx_RcpCreateDPTime.Text = "" Then
                    'Convert to the required type
                    i_dptesttime = CType(txtbx_RcpCreateDPTime.Text, Integer)
                    'Check the value within range
                    If i_dptesttime < min_i_dptesttime Or i_dptesttime > max_i_dptesttime Then
                        RecipeMessage(20, "DP Test Time should be within " + CType(min_i_dptesttime, String) + " to " + CType(max_i_dptesttime, String))
                        txtbx_RcpCreateDPTime.Text = Nothing
                        txtbx_RcpCreateDPTime.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Time")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test LowerLimit
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateDPLowLimit.Text = "" And Not txtbx_RcpCreateDPLowLimit.Text = "." Then
                    'Convert to the required type
                    d_dptestlowlimit = CType(txtbx_RcpCreateDPLowLimit.Text, Decimal)
                    'Check the value within range
                    If d_dptestlowlimit < min_d_dptestlowlimit Or d_dptestlowlimit > max_d_dptestlowlimit Then
                        RecipeMessage(20, "DP Test Lower Limit should be within " + CType(min_d_dptestlowlimit, String) + " to " + CType(max_d_dptestlowlimit, String))
                        txtbx_RcpCreateDPLowLimit.Text = Nothing
                        txtbx_RcpCreateDPLowLimit.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Lower Limit")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'check for dp test upperlimit
                'check the text is empty or has only decimal point
                If Not txtbx_RcpCreateDPUpLimit.Text = "" And Not txtbx_RcpCreateDPUpLimit.Text = "." Then
                    'convert to the required type
                    d_dptestuplimit = CType(txtbx_RcpCreateDPUpLimit.Text, Decimal)
                    'check the value within range
                    If d_dptestuplimit < min_d_dptestuplimit Or d_dptestuplimit > max_d_dptestuplimit Then
                        RecipeMessage(20, "DP Test Upper Limit should be within " + CType(min_d_dptestuplimit, String) + " to " + CType(max_d_dptestuplimit, String))
                        txtbx_RcpCreateDPUpLimit.Text = Nothing
                        txtbx_RcpCreateDPUpLimit.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Upper Limit")
                    onContinue = False
                End If
            End If
            If onContinue = True Then
                'Check for DP Test points
                'Check the text is empty
                If Not txtbx_RcpCreateDPPoints.Text = "" Then
                    'Convert to the required type
                    i_dptestpoints = CType(txtbx_RcpCreateDPPoints.Text, Integer)
                    'Check the value within range
                    If i_dptestpoints < min_i_dptestpoints Or i_dptestpoints > max_i_dptestpoints Then
                        RecipeMessage(20, "DP Test Point should be within " + CType(min_i_dptestpoints, String) + " to " + CType(max_i_dptestpoints, String))
                        txtbx_RcpCreateDPPoints.Text = Nothing
                        txtbx_RcpCreateDPPoints.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test points")
                    onContinue = False
                End If
            End If

            If onContinue = True And rdbtn_RcpCreateDPTestPumpSpeed.Checked = True Then
                'Check DP Test Pump RPM
                'Check the text is empty
                If Not txtbx_RcpCreateDPTestRPM.Text = "" Then
                    'Convert to the required type
                    i_dptestrpm = CType(txtbx_RcpCreateDPTestRPM.Text, Integer)
                    'Check the value within range
                    If i_dptestrpm < min_i_dptestrpm Or i_dptestrpm > max_i_dptestrpm Then
                        RecipeMessage(20, "DP Test Pump Speed should be within " + CType(min_i_dptestrpm, String) + " to " + CType(max_i_dptestrpm, String))
                        txtbx_RcpCreateDPTestRPM.Text = Nothing
                        txtbx_RcpCreateDPTestRPM.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Pump Speed")
                    onContinue = False
                End If
            End If
        End If


        'In Case of Drain-1 Enabled, the Field should not be empty
        If checkbx_CreateDrain1.Checked = True Then
            If onContinue = True Then
                'Check for Drain-1 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateDrain1Pressure.Text = "" And Not txtbx_RcpCreateDrain1Pressure.Text = "." Then
                    'Convert to the required type
                    d_drain1pressure = CType(txtbx_RcpCreateDrain1Pressure.Text, Decimal)
                    'Check the value within range
                    If d_drain1pressure < min_d_drain1pressure Or d_drain1pressure > max_d_drain1pressure Then
                        RecipeMessage(20, "Drain-1 Pressure should be within " + CType(min_d_drain1pressure, String) + " to " + CType(max_d_drain1pressure, String))
                        txtbx_RcpCreateDrain1Pressure.Text = Nothing
                        txtbx_RcpCreateDrain1Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-1 Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Drain-1 Time
                'Check the text is empty
                If Not txtbx_RcpCreateDrain1Time.Text = "" Then
                    'Convert to the required type
                    i_drain1time = CType(txtbx_RcpCreateDrain1Time.Text, Integer)
                    'Check the value within range
                    If i_drain1time < min_i_drain1time Or i_drain1time > max_i_drain1time Then
                        RecipeMessage(20, "Drain-1 Time should be within " + CType(min_i_drain1time, String) + " to " + CType(max_i_drain1time, String))
                        txtbx_RcpCreateDrain1Time.Text = Nothing
                        txtbx_RcpCreateDrain1Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-1 Time")
                    onContinue = False
                End If
            End If

        End If

        'In Case of Drain-2 Enabled, the Field should not be empty
        If checkbx_CreateDrain2.Checked = True Then
            If onContinue = True Then
                'Check for Drain-2 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateDrain2Pressure.Text = "" And Not txtbx_RcpCreateDrain2Pressure.Text = "." Then
                    'Convert to the required type
                    d_drain2pressure = CType(txtbx_RcpCreateDrain2Pressure.Text, Decimal)
                    'Check the value within range
                    If d_drain2pressure < min_d_drain2pressure Or d_drain2pressure > max_d_drain2pressure Then
                        RecipeMessage(20, "Drain-2 Pressure should be within " + CType(min_d_drain2pressure, String) + " to " + CType(max_d_drain2pressure, String))
                        txtbx_RcpCreateDrain2Pressure.Text = Nothing
                        txtbx_RcpCreateDrain2Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-2 Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Drain-2 Time
                'Check the text is empty
                If Not txtbx_RcpCreateDrain2Time.Text = "" Then
                    'Convert to the required type
                    i_drain2time = CType(txtbx_RcpCreateDrain2Time.Text, Integer)
                    'Check the value within range
                    If i_drain2time < min_i_drain2time Or i_drain2time > max_i_drain2time Then
                        RecipeMessage(20, "Drain-2 Time should be within " + CType(min_i_drain2time, String) + " to " + CType(max_i_drain2time, String))
                        txtbx_RcpCreateDrain2Time.Text = Nothing
                        txtbx_RcpCreateDrain2Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-2 Time")
                    onContinue = False
                End If
            End If
        End If

        'In Case of Drain-3 Enabled, the Field should not be empty
        If checkbx_CreateDrain3.Checked = True Then
            If onContinue = True Then
                'Check for FDrain-3 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateDrain3Pressure.Text = "" And Not txtbx_RcpCreateDrain3Pressure.Text = "." Then
                    'Convert to the required type
                    d_drain3pressure = CType(txtbx_RcpCreateDrain3Pressure.Text, Decimal)
                    'Check the value within range
                    If d_drain3pressure < min_d_drain3pressure Or d_drain3pressure > max_d_drain3pressure Then
                        RecipeMessage(20, "Drain-3 Pressure should be within " + CType(min_d_drain3pressure, String) + " to " + CType(max_d_drain3pressure, String))
                        txtbx_RcpCreateDrain3Pressure.Text = Nothing
                        txtbx_RcpCreateDrain3Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-3 Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Drain-3 Time
                'Check the text is empty
                If Not txtbx_RcpCreateDrain3Time.Text = "" Then
                    'Convert to the required type
                    i_drain3time = CType(txtbx_RcpCreateDrain3Time.Text, Integer)
                    'Check the value within range
                    If i_drain3time < min_i_drain3time Or i_drain3time > max_i_drain3time Then
                        RecipeMessage(20, "Drain-3 Time should be within " + CType(min_i_drain3time, String) + " to " + CType(max_i_drain3time, String))
                        txtbx_RcpCreateDrain3Time.Text = Nothing
                        txtbx_RcpCreateDrain3Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-3 Time")
                    onContinue = False
                End If
            End If
        End If

        'In Case of Drain-4 Enabled, the Field should not be empty
        If checkbx_CreateDrain4.Checked = True Then
            If onContinue = True Then
                'Check for Drain-4 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpCreateDrain4Pressure.Text = "" And Not txtbx_RcpCreateDrain4Pressure.Text = "." Then
                    'Convert to the required type
                    d_drain4pressure = CType(txtbx_RcpCreateDrain4Pressure.Text, Decimal)
                    'Check the value within range
                    If d_drain4pressure < min_d_drain4pressure Or d_drain4pressure > max_d_drain4pressure Then
                        RecipeMessage(20, "Drain-4 Pressure should be within " + CType(min_d_drain4pressure, String) + " to " + CType(max_d_drain4pressure, String))
                        txtbx_RcpCreateDrain4Pressure.Text = Nothing
                        txtbx_RcpCreateDrain4Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-4 Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Drain-4 Time
                'Check the text is empty
                If Not txtbx_RcpCreateDrain4Time.Text = "" Then
                    'Convert to the required type
                    i_drain4time = CType(txtbx_RcpCreateDrain4Time.Text, Integer)
                    'Check the value within range
                    If i_drain4time < min_i_drain4time Or i_drain4time > max_i_drain4time Then
                        RecipeMessage(20, "Drain-4 Time should be within " + CType(min_i_drain4time, String) + " to " + CType(max_i_drain4time, String))
                        txtbx_RcpCreateDrain4Time.Text = Nothing
                        txtbx_RcpCreateDrain4Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-4 Time")
                    onContinue = False
                End If
            End If
        End If
#End Region

        'If onContinue = True Then
        '    If checkbx_CreateFlush1.Checked = True Then
        '        If Not (i_flush1time > 0 And d_flush1flow > 0 And d_flush1pressure > 0) Then
        '            RecipeMessage(53, "If Flush-1 Enabled, then Flush-1 Time, Flush-1 FLowrate and Flush-1 BackPressure Cannot be Zero")
        '            onContinue = False
        '        End If
        '    End If
        'End If

        'If onContinue = True Then
        '    If checkbx_CreateDPTest1.Checked = True Then
        '        If Not (i_dptesttime > 0 And i_dptestpoints > 0 And d_dptestflow > 0 And d_dptestpressure > 0) Then
        '            RecipeMessage(53, "If DP Test Enabled, then DPTest Time, DPTest Points, DPTest FLowrate and DPTest BackPressure Cannot be Zero")
        '            onContinue = False
        '        End If
        '    End If
        'End If

        'If onContinue = True Then
        '    If checkbx_CreateFlush2.Checked = True Then
        '        If Not (i_flush2time > 0 And d_flush2flow > 0 And d_flush2pressure > 0) Then
        '            RecipeMessage(53, "If Flush-2 Enabled, then Flush-2 Time, Flush-2 FLowrate and Flush-2 BackPressure Cannot be Zero")
        '            onContinue = False
        '        End If
        '    End If
        'End If

        'Check whether Test points is greater than Test time
        ' Always Test points should be less than or equal to Test time
        If onContinue = True Then
            If checkbx_CreateDPTest1.Checked = True Then
                If i_dptestpoints > i_dptesttime Then
                    RecipeMessage(21, "DP Test-1")
                    onContinue = False
                End If
            End If
        End If

        'Check whether any one process is selected, if not don't allow recipe creation
        If onContinue = True Then
            If checkbx_CreateDPTest1.Checked = False And checkbx_CreateFlush1.Checked = False And checkbx_CreateFlush2.Checked = False Then
                RecipeMessage(22)
                onContinue = False
            End If
        End If

        'Check whether any one drain is selected, if not don't allow recipe creation
        If onContinue = True Then
            'If checkbx_CreateDrain1.Checked = False And checkbx_CreateDrain2.Checked = False And checkbx_CreateDrain3.Checked = False Then
            '    RecipeMessage(39)
            '    onContinue = False
            'End If
        End If

        'Check is Fill valid for Prefill & Prep Drain
        If onContinue = True Then
            Dim ParseError As Boolean = False

            Dim TotalFillTime As Integer
            Dim TotalBleedTime As Integer
            Dim PrefillStartTime As Integer
            Dim PrefillTime As Integer
            Dim DrainStartTime As Integer
            Dim DrainTime As Integer
            Dim BP1Time As Integer

            If Not Integer.TryParse(txtbx_RcpCreatePrepFill.Text, TotalFillTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpCreatePrepBleed.Text, TotalBleedTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpCreatePrepPrefillStartTime.Text, PrefillStartTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpCreatePrepPrefillTime.Text, PrefillTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpCreatePrepDrainStartTime.Text, DrainStartTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpCreatePrepDrainTime.Text, DrainTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpCreatePrepPressureDropTime.Text, BP1Time) Then
                ParseError = True
            End If

            If ParseError = False Then
                If onContinue = True Then
                    If (PrefillStartTime + PrefillTime) >= TotalFillTime Then
                        onContinue = False
                        MsgBox("Prefill Time must be less than Fill Time", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
                    End If
                End If
                If onContinue = True Then
                    If (DrainStartTime + DrainTime) >= TotalFillTime Then
                        onContinue = False
                        MsgBox("Drain Time must be less than Fill Time", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
                    End If
                End If
                If onContinue = True Then
                    If BP1Time >= TotalFillTime + TotalBleedTime Then
                        onContinue = False
                        MsgBox("Prep Back Pressure Time must be less than Fill + Bleed Time", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
                    End If
                End If
            Else
                onContinue = False
                MsgBox("Integer Parse Error", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            End If
        End If

        ' Check if filter types are available/selected
        If True Then
            If ComboBox3.Items.Count > 0 And ComboBox4.Items.Count > 0 And ComboBox6.Items.Count > 0 Then
            Else
                onContinue = False
                MsgBox("Filter Types Not Selected", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            End If
        End If

        If onContinue = True Then
            ' Upon all previous conditions are true,
            ' Send the Data to SQL Database
            Dim DateTimeNowInStr As String = DateTime.Now.ToString("s")
            If dtrecipeidcheck.Rows.Count = 0 Then
                Dim recipeparameter As New Dictionary(Of String, Object) From {
                    {"recipe_id", RecipeID},
                    {"recipe_rev", 0},
                    {"part_id", PartID},
                    {"recipe_type_id", TypeID},
                    {"last_modified_by", PublicVariables.LoginUserName},
                    {"last_modified_time", DateTimeNowInStr},
                    {"user_created", PublicVariables.LoginUserName},
                    {"created_time", DateTimeNowInStr},
                    {"fitting_inlet", IIf(ComboBox3.Items.Count > 0, ComboBox3.SelectedItem, "")},
                    {"fitting_outlet", IIf(ComboBox4.Items.Count > 0, ComboBox4.SelectedItem, "")},
                    {"fitting_blank", IIf(ComboBox6.Items.Count > 0, ComboBox6.SelectedItem, "")},
                    {"verification_tolerance", d_vertol},
                    {"prep_fill_time", i_prepfilltime},
                    {"prep_bleed_time", i_prepbleedtime},
                                                         _ '{"prep_flowrate", d_prepflow},
                                                         _ '{"prep_flow_tolerance", d_prepflowtol},
                    {"prep_flowrate", 0},
                    {"prep_flow_tolerance", 0},
                    {"prep_back_pressure", d_preppressure},
                    {"prep_pressure_drop", d_preppressuredrop},
                    {"prep_pressure_drop_time", i_preppressuredroptime},
                    {"prep_prefill_start_time", i_prepprefillstarttime},
                    {"prep_prefill_time", i_prepprefilltime},
                    {"prep_drain_start_time", i_prepdrainstarttime},
                    {"prep_drain_time", i_prepdraintime},
                    {"prep_speed_mode", str_prepspeedenable},
                    {"prep_rpm1", i_preprpm1},
                                              _ '{"prep_rpm2", i_preprpm2},
                    {"firstflush_circuit", str_flush1enable},
                                                             _ '{"firstflush_fill_time", i_flush1filltime},
                                                             _ '{"firstflush_bleed_time", i_flush1bleedtime},
                    {"firstflush_flowrate", d_flush1flow},
                    {"firstflush_flow_tolerance", d_flush1flowtol},
                    {"firstflush_back_pressure", d_flush1pressure},
                    {"firstflush_stabilize_time", i_flush1stabilize},
                    {"firstflush_time", i_flush1time},
                    {"firstflush_speed_mode", str_flush1speedenable},
                    {"firstflush_rpm", i_flush1rpm},
                    {"firstdp_circuit", str_dptest1enable},
                                                           _ '{"dp_fill_time", i_dptestfilltime},
                                                           _ '{"dp_bleed_time", i_dptestbleedtime},
                    {"dp_flowrate", d_dptestflow},
                    {"dp_flow_tolerance", d_dptestflowtol},
                    {"dp_back_pressure", d_dptestpressure},
                    {"dp_stabilize_time", i_dpteststabilize},
                    {"dp_test_time", i_dptesttime},
                    {"dp_lowerlimit", d_dptestlowlimit},
                    {"dp_upperlimit", d_dptestuplimit},
                    {"dp_testpoints", i_dptestpoints},
                    {"dp_speed_mode", str_dptestspeedenable},
                    {"dp_rpm", i_dptestrpm},
                    {"seconddp_circuit", str_dptest2enable},
                    {"secondflush_circuit", str_flush2enable},
                                                              _ '{"secondflush_fill_time", i_flush2filltime},
                                                              _ '{"secondflush_bleed_time", i_flush2bleedtime},
                    {"secondflush_flowrate", d_flush2flow},
                    {"secondflush_flow_tolerance", d_flush2flowtol},
                    {"secondflush_back_pressure", d_flush2pressure},
                    {"secondflush_stabilize_time", i_flush2stabilize},
                    {"secondflush_time", i_flush2time},
                    {"secondflush_speed_mode", str_flush2speedenable},
                    {"secondflush_rpm", i_flush2rpm},
                    {"drain1_circuit", str_drain1enable},
                    {"drain1_back_pressure", d_drain1pressure},
                    {"drain1_time", i_drain1time},
                    {"drain2_circuit", str_drain2enable},
                    {"drain2_back_pressure", d_drain2pressure},
                    {"drain2_time", i_drain2time},
                    {"drain3_circuit", str_drain3enable},
                    {"drain3_back_pressure", d_drain3pressure},
                    {"drain3_time", i_drain3time},
                    {"drain4_circuit", str_drain4enable},
                    {"drain4_back_pressure", d_drain4pressure},
                    {"drain4_time", i_drain4time}
                }
                If SQL.InsertRecord("RecipeTable", recipeparameter) = 1 Then
                    RecipeMessage(10)

                    ' Event Log
                    Dim FilterTypeValue As String = DirectCast(cmbx_RcpCreateFilterType.SelectedItem, KeyValuePair(Of String, String)).Value
                    Dim PartIDValue As String = DirectCast(cmbx_RcpCreatePartID.SelectedItem, KeyValuePair(Of String, String)).Value
                    Dim RecipeTypeValue As String = DirectCast(cmbx_RcpCreateType.SelectedItem, KeyValuePair(Of String, String)).Value
                    Dim RecipeIDValue As String = txtbx_RcpCreateRecipeID.Text
                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Creation - Recipe ID ({FilterTypeValue}/{PartIDValue}/{RecipeTypeValue}/{RecipeIDValue}) Created")

                    cmbx_RcpCreateFilterType.SelectedIndex = 0
                    LoadRecipeDetails(0, Nothing, Nothing, Nothing, Nothing)
                    GetRecipeID()
                Else
                    RecipeMessage(14)
                    onContinue = False
                End If
            Else
                RecipeMessage(8)
                onContinue = False
            End If
        End If
    End Sub
#End Region

#Region "Recipe Duplicate"
    Private Sub cmbx_RcpDupSelRecipe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_RcpDupSelRecipe.SelectedIndexChanged
        Dim dtPartID As DataTable = SQL.ReadRecords("SELECT * FROM PartTable")
        Dim PartIDgcomboSource As New Dictionary(Of String, String)()
        PartIDgcomboSource.Add("0", "-Not Selected-")
        If dtPartID.Rows.Count > 0 Then
            For i As Integer = 0 To dtPartID.Rows.Count - 1
                PartIDgcomboSource.Add(dtPartID(i)("id"), dtPartID(i)("part_id"))
            Next
        End If

        With Cmbx_RcpDupNewPartID
            .DataSource = New BindingSource(PartIDgcomboSource, Nothing)
            .DisplayMember = "Value"
            .ValueMember = "Key"
            If .Items.Count > 0 Then
                .SelectedIndex = 0
                .Enabled = False
            End If
        End With

        If cmbx_RcpDupSelRecipe.SelectedIndex > 0 Then
            Cmbx_RcpDupNewPartID.Enabled = True
            Cmbx_RcpDupNewType.Enabled = True
        Else
            Cmbx_RcpDupNewPartID.SelectedIndex = 0
            Cmbx_RcpDupNewPartID.Enabled = False
            Cmbx_RcpDupNewType.SelectedIndex = 0
            Cmbx_RcpDupNewType.Enabled = False
        End If
    End Sub

    Private Sub Cmbx_RcpDupNewType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbx_RcpDupNewType.SelectedIndexChanged, Cmbx_RcpDupNewPartID.SelectedIndexChanged
        If Cmbx_RcpDupNewType.SelectedIndex > 0 Then
            txtbx_RcpDupNewRecipeID.Text = ""
            txtbx_RcpDupNewRecipeID.Enabled = True
            btn_RcpDuplicate.Enabled = True
        Else
            txtbx_RcpDupNewRecipeID.Text = "--"
            txtbx_RcpDupNewRecipeID.Enabled = False
            btn_RcpDuplicate.Enabled = False
        End If
    End Sub

    Private Sub btn_RcpDuplicate_Click(sender As Object, e As EventArgs) Handles btn_RcpDuplicate.Click
        Dim Newtype As Integer = Cmbx_RcpDupNewType.SelectedIndex
        Dim Newrecipe As String = txtbx_RcpDupNewRecipeID.Text
        Dim Newpartid As String = Cmbx_RcpDupNewPartID.Text
        Dim selrecipeid As Integer = cmbx_RcpDupSelRecipe.SelectedIndex
        Dim selrecipe As String = cmbx_RcpDupSelRecipe.Text
        'Dim duplicaterecipe(50) As String
        Dim dtDuplicaterecipe As DataTable = SQL.ReadRecords("SELECT * FROM RecipeTable WHERE recipe_id = '" + selrecipe + "' ORDER BY recipe_rev DESC")
        Dim Oncontinue As Boolean = True
        Dim dtrecipeidcheck As DataTable = SQL.ReadRecords("SELECT * FROM RecipeTable WHERE recipe_id = '" + Newrecipe + "'")
        'If dtDuplicaterecipe.Rows.Count > 0 Then
        '    For i As Integer = 0 To dtDuplicaterecipe.Columns.Count - 1
        '        duplicaterecipe(i) = dtDuplicaterecipe.Rows(0).Item(i)
        '    Next
        'End If

        'Check Selected Recipe ID Empty fields
        If Oncontinue = True Then
            If selrecipeid = 0 Then
                RecipeMessage(45)
                Oncontinue = False
            End If
        End If

        'Check Type Empty fields
        If Oncontinue = True Then
            If Newtype = 0 Then
                RecipeMessage(43)
                Oncontinue = False
            End If
        End If
        'Check Recipe ID Empty fields
        If Oncontinue = True Then
            If Newrecipe.Length = 0 Then
                RecipeMessage(44)
                Oncontinue = False
            End If
        End If
        'Check Recipe ID Length exceed
        If Oncontinue = True Then
            If Newrecipe.Length > 20 Or Newrecipe.Length < 4 Then
                RecipeMessage(49, $"Recipe ID is limited from 4 to 20 Characters, Try Again")
                Oncontinue = False
            End If
        End If
        'Check Recipe ID has special character
        If Oncontinue = True Then
            If Checkspecial(Newrecipe) <> -1 Then
                RecipeMessage(50)
                Oncontinue = False
            End If
        End If
        'Check Recipe ID already exists
        If Oncontinue = True Then
            If dtrecipeidcheck.Rows.Count <> 0 Then
                RecipeMessage(46)
                Oncontinue = False
            End If
        End If

        'Check datatable row count
        If Oncontinue = True Then
            If dtDuplicaterecipe.Rows.Count <= 0 Then
                Oncontinue = False
                MsgBox("Recipe not found, Duplication Failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            Else
                For i As Integer = 0 To dtDuplicaterecipe.Columns.Count - 1
                    If IsDBNull(dtDuplicaterecipe.Rows(0).Item(i)) Then
                        Oncontinue = False
                        MsgBox("Recipe data incomplete, Duplication Failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
                        Exit For
                    End If
                Next
            End If

            'If Oncontinue = False Then
            '    MsgBox("Recipe not found, Duplication Failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            'End If
        End If

        If Oncontinue = True Then
            Dim CurrentDate As DateTime = DateTime.Now
            Dim DateTimeNowInStr As String = DateTime.Now.ToString("s")

            dtDuplicaterecipe(0)("recipe_id") = Newrecipe
            dtDuplicaterecipe(0)("recipe_type_id") = Newtype
            dtDuplicaterecipe(0)("last_modified_by") = PublicVariables.LoginUserName
            dtDuplicaterecipe(0)("last_modified_time") = DateTimeNowInStr 'lbl_DateTimeClock.Text
            dtDuplicaterecipe(0)("user_created") = PublicVariables.LoginUserName
            dtDuplicaterecipe(0)("created_time") = DateTimeNowInStr 'lbl_DateTimeClock.Text

            ' Upon all previous conditions are true,
            ' Send the Data to SQL Database
            If dtrecipeidcheck.Rows.Count = 0 Then
                Dim recipeparameter As New Dictionary(Of String, Object) From {
                    {"recipe_id", dtDuplicaterecipe(0)("recipe_id")},
                    {"recipe_rev", 0},
                                      _ '{"part_id", dtDuplicaterecipe(0)("part_id")},
                    {"part_id", Newpartid},
                    {"recipe_type_id", dtDuplicaterecipe(0)("recipe_type_id")},
                    {"last_modified_by", dtDuplicaterecipe(0)("last_modified_by")},
                    {"last_modified_time", dtDuplicaterecipe(0)("last_modified_time")},
                    {"user_created", dtDuplicaterecipe(0)("user_created")},
                    {"created_time", dtDuplicaterecipe(0)("created_time")},
                    {"fitting_inlet", dtDuplicaterecipe(0)("fitting_inlet")},
                    {"fitting_outlet", dtDuplicaterecipe(0)("fitting_outlet")},
                    {"fitting_blank", dtDuplicaterecipe(0)("fitting_blank")},
                    {"verification_tolerance", dtDuplicaterecipe(0)("verification_tolerance")},
                                                                                               _
                    {"prep_fill_time", dtDuplicaterecipe(0)("prep_fill_time")},
                    {"prep_bleed_time", dtDuplicaterecipe(0)("prep_bleed_time")},
                                                                                 _ '{"prep_flowrate", dtDuplicaterecipe(0)("prep_flowrate")},
                                                                                 _ '{"prep_flow_tolerance", dtDuplicaterecipe(0)("prep_flow_tolerance")},
                    {"prep_flowrate", 0},
                    {"prep_flow_tolerance", 0},
                    {"prep_back_pressure", dtDuplicaterecipe(0)("prep_back_pressure")},
                    {"prep_pressure_drop", dtDuplicaterecipe(0)("prep_pressure_drop")},
                    {"prep_pressure_drop_time", dtDuplicaterecipe(0)("prep_pressure_drop_time")},
                    {"prep_prefill_start_time", dtDuplicaterecipe(0)("prep_prefill_start_time")},
                    {"prep_prefill_time", dtDuplicaterecipe(0)("prep_prefill_time")},
                    {"prep_drain_start_time", dtDuplicaterecipe(0)("prep_drain_start_time")},
                    {"prep_drain_time", dtDuplicaterecipe(0)("prep_drain_time")},
                    {"prep_speed_mode", dtDuplicaterecipe(0)("prep_speed_mode")},
                    {"prep_rpm1", dtDuplicaterecipe(0)("prep_rpm1")},
                                                                     _ '{"prep_rpm2", dtDuplicaterecipe(0)("prep_rpm2")},
                                                                     _
                    {"firstflush_circuit", dtDuplicaterecipe(0)("firstflush_circuit")},
                                                                                       _ '{"firstflush_fill_time", duplicaterecipe(10)},
                                                                                       _ '{"firstflush_bleed_time", duplicaterecipe(11)},
                    {"firstflush_flowrate", dtDuplicaterecipe(0)("firstflush_flowrate")},
                    {"firstflush_flow_tolerance", dtDuplicaterecipe(0)("firstflush_flow_tolerance")},
                    {"firstflush_back_pressure", dtDuplicaterecipe(0)("firstflush_back_pressure")},
                    {"firstflush_stabilize_time", dtDuplicaterecipe(0)("firstflush_stabilize_time")},
                    {"firstflush_time", dtDuplicaterecipe(0)("firstflush_time")},
                    {"firstflush_speed_mode", dtDuplicaterecipe(0)("firstflush_speed_mode")},
                    {"firstflush_rpm", dtDuplicaterecipe(0)("firstflush_rpm")},
                    {"firstdp_circuit", dtDuplicaterecipe(0)("firstdp_circuit")},
                                                                                 _ '{"dp_fill_time", duplicaterecipe(18)},
                                                                                 _ '{"dp_bleed_time", duplicaterecipe(19)},
                    {"dp_flowrate", dtDuplicaterecipe(0)("dp_flowrate")},
                    {"dp_flow_tolerance", dtDuplicaterecipe(0)("dp_flow_tolerance")},
                    {"dp_back_pressure", dtDuplicaterecipe(0)("dp_back_pressure")},
                    {"dp_stabilize_time", dtDuplicaterecipe(0)("dp_stabilize_time")},
                    {"dp_test_time", dtDuplicaterecipe(0)("dp_test_time")},
                    {"dp_lowerlimit", dtDuplicaterecipe(0)("dp_lowerlimit")},
                    {"dp_upperlimit", dtDuplicaterecipe(0)("dp_upperlimit")},
                    {"dp_testpoints", dtDuplicaterecipe(0)("dp_testpoints")},
                    {"dp_speed_mode", dtDuplicaterecipe(0)("dp_speed_mode")},
                    {"dp_rpm", dtDuplicaterecipe(0)("dp_rpm")},
                    {"seconddp_circuit", dtDuplicaterecipe(0)("seconddp_circuit")},
                    {"secondflush_circuit", dtDuplicaterecipe(0)("secondflush_circuit")},
                                                                                         _ '{"secondflush_fill_time", duplicaterecipe(30)},
                                                                                         _ '{"secondflush_bleed_time", duplicaterecipe(31)},
                    {"secondflush_flowrate", dtDuplicaterecipe(0)("secondflush_flowrate")},
                    {"secondflush_flow_tolerance", dtDuplicaterecipe(0)("secondflush_flow_tolerance")},
                    {"secondflush_back_pressure", dtDuplicaterecipe(0)("secondflush_back_pressure")},
                    {"secondflush_stabilize_time", dtDuplicaterecipe(0)("secondflush_stabilize_time")},
                    {"secondflush_time", dtDuplicaterecipe(0)("secondflush_time")},
                    {"secondflush_speed_mode", dtDuplicaterecipe(0)("secondflush_speed_mode")},
                    {"secondflush_rpm", dtDuplicaterecipe(0)("secondflush_rpm")},
                    {"drain1_circuit", dtDuplicaterecipe(0)("drain1_circuit")},
                    {"drain1_back_pressure", dtDuplicaterecipe(0)("drain1_back_pressure")},
                    {"drain1_time", dtDuplicaterecipe(0)("drain1_time")},
                    {"drain2_circuit", dtDuplicaterecipe(0)("drain2_circuit")},
                    {"drain2_back_pressure", dtDuplicaterecipe(0)("drain2_back_pressure")},
                    {"drain2_time", dtDuplicaterecipe(0)("drain2_time")},
                    {"drain3_circuit", dtDuplicaterecipe(0)("drain3_circuit")},
                    {"drain3_back_pressure", dtDuplicaterecipe(0)("drain3_back_pressure")},
                    {"drain3_time", dtDuplicaterecipe(0)("drain3_time")},
                    {"drain4_circuit", dtDuplicaterecipe(0)("drain4_circuit")},
                    {"drain4_back_pressure", dtDuplicaterecipe(0)("drain4_back_pressure")},
                    {"drain4_time", dtDuplicaterecipe(0)("drain4_time")}
                }
                If SQL.InsertRecord("RecipeTable", recipeparameter) = 1 Then
                    RecipeMessage(47)

                    ' Event Log
                    Dim RecipeIDPrev As String = DirectCast(cmbx_RcpDupSelRecipe.SelectedItem, KeyValuePair(Of String, String)).Value
                    Dim RecipeTypeValue As String = DirectCast(Cmbx_RcpDupNewType.SelectedItem, KeyValuePair(Of String, String)).Value
                    Dim RecipeIDValue As String = txtbx_RcpDupNewRecipeID.Text
                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Duplication - Recipe ID ({RecipeTypeValue}/{RecipeIDValue}) Created With Parameters From Recipe ID ({RecipeIDPrev})")

                    cmbx_RcpDupSelRecipe.SelectedIndex = 0
                    LoadRecipeDetails(0, Nothing, Nothing, Nothing, Nothing)
                    GetRecipeID()
                Else
                    RecipeMessage(48)
                    Oncontinue = False
                End If
            Else
                RecipeMessage(46)
                Oncontinue = False
            End If
        End If

        If Oncontinue = True Then
            Dim dtfiltertype As DataTable = SQL.ReadRecords($"SELECT Filtertype.id, FilterType.filter_type FROM PartTable INNER JOIN FilterType ON PartTable.filter_type_id=FilterType.id AND PartTable.part_id='{dtDuplicaterecipe(0)("part_id")}'")
            If dtfiltertype.Rows.Count > 0 Then
                If cmbx_RcpEditPartID.Items.Count > 0 Then
                    cmbx_RcpEditPartID.SelectedIndex = 0
                End If

                cmbx_RcpEditFilterType.Text = dtfiltertype.Rows(0).Item("filter_type")
                cmbx_RcpEditPartID.Text = dtDuplicaterecipe(0)("part_id")
                cmbx_RcpEditRecipeID.Text = dtDuplicaterecipe(0)("recipe_id")
            Else
                RecipeMessage(51)
                Oncontinue = False
            End If
        End If
    End Sub
#End Region

#Region "Part ID Deletion"
    Private Sub btn_PartDelete_Click(sender As Object, e As EventArgs) Handles btn_PartDelete.Click
        ' Declare Parameters
        Dim FilterTypeID As Integer = cmbx_PartDeleteFilterType.SelectedIndex
        Dim PartID As String = cmbx_PartDeletePartID.Text
        Dim onContinue As Boolean = True
        Dim dtPartIDcheck As DataTable = SQL.ReadRecords("SELECT * FROM RecipeTable WHERE part_id = '" + PartID + "'")

        'Check Empty fields
        If onContinue = True Then
            If FilterTypeID = 0 Then
                RecipeMessage(1)
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If cmbx_PartDeletePartID.SelectedIndex = 0 Then
                RecipeMessage(3)
                onContinue = False
            End If
        End If

        'If onContinue = True Then
        '    If dtPartIDcheck.Rows.Count <> 0 Then

        '        RecipeMessage(24, PartID)
        '        onContinue = False
        '    End If
        'End If

        If onContinue = True Then

            If RecipeMessage(31, PartID) = DialogResult.Yes Then
                If dtPartIDcheck.Rows.Count > 0 Then


                    For i As Integer = 0 To dtPartIDcheck.Rows.Count - 1

                        If onContinue = True Then


                            Dim Condition1 As String = "serial_usage_id in (SELECT ProductionDetail.id FROM ProductionDetail LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id WHERE Lotusage.recipe_id = '" + dtPartIDcheck(i)("recipe_id") + "')"
                            Dim Condition2 As String = "id in (SELECT ProductionDetail.id FROM ProductionDetail LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id WHERE Lotusage.recipe_id = '" + dtPartIDcheck(i)("recipe_id") + "')"
                            Dim Condition3 As String = "lot_id in (SELECT lot_id FROM Lotusage WHERE Lotusage.recipe_id='" + dtPartIDcheck(i)("recipe_id") + "')"
                            Dim condition As String = "recipe_id = '" + dtPartIDcheck(i)("recipe_id") + "'"

                            'Delete Data from Product Result Table
                            If onContinue = True Then
                                Try
                                    SQL.DeleteRecord("ProductResult", Condition1)
                                    onContinue = True
                                Catch
                                    'RecipeMessage(54, RecipeID)
                                    onContinue = False
                                End Try
                            End If

                            'Delete Data from Production Details Table
                            If onContinue = True Then
                                Try
                                    SQL.DeleteRecord("ProductionDetail", Condition2)
                                    onContinue = True
                                Catch
                                    'RecipeMessage(55, RecipeID)
                                    onContinue = False
                                End Try
                            End If

                            'Delete Data from Calibration Result Table
                            If onContinue = True Then
                                Try
                                    SQL.DeleteRecord("CalibrationResult", condition)
                                    onContinue = True
                                Catch
                                    'RecipeMessage(56, RecipeID)
                                    onContinue = False
                                End Try
                            End If


                            'Delete Data from Work Order Table
                            If onContinue = True Then
                                Try
                                    SQL.DeleteRecord("WorkOrder", Condition3)
                                    onContinue = True
                                Catch
                                    'RecipeMessage(57, RecipeID)
                                    onContinue = False
                                End Try
                            End If


                            'Delete Data from LotUsage Table
                            If onContinue = True Then
                                Try
                                    SQL.DeleteRecord("LotUsage", condition)
                                    onContinue = True
                                Catch
                                    'RecipeMessage(58, RecipeID)
                                    onContinue = False
                                End Try
                            End If


                            If onContinue = True Then
                                Try

                                    SQL.DeleteRecord("RecipeTable", condition)
                                    'RecipeMessage(28)

                                    ' Event Log
                                    Dim FilterTypeValue As String = DirectCast(cmbx_RcpCreateFilterType.SelectedItem, KeyValuePair(Of String, String)).Value
                                    Dim PartIDValue As String = DirectCast(cmbx_RcpCreatePartID.SelectedItem, KeyValuePair(Of String, String)).Value
                                    Dim RecipeIDValue As String = txtbx_RcpCreateRecipeID.Text
                                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Deletion - Recipe ID ({FilterTypeValue}/{PartIDValue}/{RecipeIDValue}) Deleted")

                                    cmbx_RcpDeleteFilterType.SelectedIndex = 0
                                    LoadRecipeDetails(0, Nothing, Nothing, Nothing, Nothing)
                                    GetRecipeID()

                                Catch
                                    'RecipeMessage(29)
                                    onContinue = False
                                End Try
                            End If


                        End If
                    Next


                End If
            Else
                RecipeMessage(32)

            End If

            If onContinue = True Then


                Dim condition As String = "part_id = '" + PartID + "'"

                If SQL.DeleteRecord("PartTable", condition) = 1 Then
                    RecipeMessage(25)

                    ' Event Log
                    Dim FilterTypeValue As String = DirectCast(cmbx_PartDeleteFilterType.SelectedItem, KeyValuePair(Of String, String)).Value
                    Dim PartIDValue As String = DirectCast(cmbx_PartDeletePartID.SelectedItem, KeyValuePair(Of String, String)).Value
                    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Part ID Deletion - Part ID ({FilterTypeValue}/{PartIDValue}) Deleted")

                    cmbx_PartDeleteFilterType.SelectedIndex = 0
                    LoadRecipeDetails(0, Nothing, Nothing, Nothing, Nothing)
                    GetRecipeID()

                Else
                    RecipeMessage(26)
                    onContinue = False
                End If
            Else
                RecipeMessage(32)
            End If


        End If





    End Sub
#End Region

#Region "Recipe ID Deletion"
    Private Sub btn_RecipeDelete_Click(sender As Object, e As EventArgs) Handles btn_RecipeDelete.Click
        ' Declare Parameters
        Dim FilterTypeID As Integer = cmbx_RcpDeleteFilterType.SelectedIndex
        Dim PartID As String = cmbx_RcpDeletePartID.Text
        Dim RecipeID As String = cmbx_RcpDeleteRecipeID.Text
        Dim onContinue As Boolean = True
        Dim dtRecipeIDcheck As DataTable = SQL.ReadRecords("SELECT * FROM RecipeTable WHERE recipe_id = '" + RecipeID + "'")

        'Check Empty fields
        If onContinue = True Then
            If FilterTypeID = 0 Then
                RecipeMessage(1)
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If cmbx_RcpDeletePartID.SelectedIndex = 0 Then
                RecipeMessage(3)
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If cmbx_RcpDeleteRecipeID.SelectedIndex = 0 Then
                RecipeMessage(6)
                onContinue = False
            End If
        End If

        ' Need to check production details contain this part id or not
        'If onContinue = True Then
        '    Dim dtProdDetail As DataTable = SQL.ReadRecords($"SELECT Lotusage.recipe_id FROM ProductionDetail LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id WHERE Lotusage.recipe_id='{RecipeID}'")
        '    If dtProdDetail.Rows.Count > 0 Then
        '        MsgBox("Unable To Delete, Production Details With Current Recipe Exists", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
        '        onContinue = False
        '    End If
        'End If

        If onContinue = True Then
            If RecipeMessage(33, RecipeID) = DialogResult.Yes Then
                Dim Condition1 As String = "serial_usage_id in (SELECT ProductionDetail.id FROM ProductionDetail LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id WHERE Lotusage.recipe_id = '" + RecipeID + "')"
                Dim Condition2 As String = "id in (SELECT ProductionDetail.id FROM ProductionDetail LEFT JOIN Lotusage ON ProductionDetail.lot_usage_id=Lotusage.id WHERE Lotusage.recipe_id = '" + RecipeID + "')"
                Dim Condition3 As String = "lot_id in (SELECT lot_id FROM Lotusage WHERE Lotusage.recipe_id='" + RecipeID + "')"
                Dim condition As String = "recipe_id = '" + RecipeID + "'"

                'Delete Data from Product Result Table
                If onContinue = True Then
                    Try
                        SQL.DeleteRecord("ProductResult", Condition1)
                        onContinue = True
                    Catch
                        RecipeMessage(54, RecipeID)
                        onContinue = False
                    End Try
                End If

                'Delete Data from Production Details Table
                If onContinue = True Then
                    Try
                        SQL.DeleteRecord("ProductionDetail", Condition2)
                        onContinue = True
                    Catch
                        RecipeMessage(55, RecipeID)
                        onContinue = False
                    End Try
                End If

                'Delete Data from Calibration Result Table
                If onContinue = True Then
                    Try
                        SQL.DeleteRecord("CalibrationResult", condition)
                        onContinue = True
                    Catch
                        RecipeMessage(56, RecipeID)
                        onContinue = False
                    End Try
                End If


                'Delete Data from Work Order Table
                If onContinue = True Then
                    Try
                        SQL.DeleteRecord("WorkOrder", Condition3)
                        onContinue = True
                    Catch
                        RecipeMessage(57, RecipeID)
                        onContinue = False
                    End Try
                End If


                'Delete Data from LotUsage Table
                If onContinue = True Then
                    Try
                        SQL.DeleteRecord("LotUsage", condition)
                        onContinue = True
                    Catch
                        RecipeMessage(58, RecipeID)
                        onContinue = False
                    End Try
                End If


                If onContinue = True Then
                    If SQL.DeleteRecord("RecipeTable", condition) = 1 Then
                        RecipeMessage(28)

                        ' Event Log
                        Dim FilterTypeValue As String = DirectCast(cmbx_RcpCreateFilterType.SelectedItem, KeyValuePair(Of String, String)).Value
                        Dim PartIDValue As String = DirectCast(cmbx_RcpCreatePartID.SelectedItem, KeyValuePair(Of String, String)).Value
                        Dim RecipeIDValue As String = txtbx_RcpCreateRecipeID.Text
                        EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Deletion - Recipe ID ({FilterTypeValue}/{PartIDValue}/{RecipeIDValue}) Deleted")

                        cmbx_RcpDeleteFilterType.SelectedIndex = 0
                        LoadRecipeDetails(0, Nothing, Nothing, Nothing, Nothing)
                        GetRecipeID()


                    Else
                        RecipeMessage(29)
                        onContinue = False
                    End If
                End If
            Else
                RecipeMessage(34)

            End If
        End If

    End Sub
#End Region

#Region "Recipe Edit Parameter Data Check"
    Private Sub checkbx_EditFlush1_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_EditFlush1.CheckedChanged
        If checkbx_EditFlush1.Checked = True Then
            If checkbx_EditFlush1.Enabled = True Then
                'txtbx_RcpEditFlush1Fill.Enabled = True
                'txtbx_RcpEditFlush1Bleed.Enabled = True
                txtbx_RcpEditFlush1Flow.Enabled = True
                txtbx_RcpEditFlush1FlowTol.Enabled = True
                'txtbx_RcpEditFlush1Pressure.Enabled = True
                txtbx_RcpEditFlush1Stabilize.Enabled = True
                txtbx_RcpEditFlush1Time.Enabled = True
                'txtbx_RcpEditFlush1RPM.Enabled = True

                'Select Case cmbx_RcpEditPrepPumpMode.SelectedIndex
                '    Case 0
                '        With txtbx_RcpEditFlush1Flow
                '            .Enabled = True
                '        End With
                '        With txtbx_RcpEditFlush1FlowTol
                '            .Enabled = True
                '        End With
                '        With txtbx_RcpEditFlush1RPM
                '            .Enabled = False
                '        End With
                '    Case 1
                '        With txtbx_RcpEditFlush1Flow
                '            .Enabled = False
                '            .Text = d_prepflow.ToString("F1") '"0.0"
                '        End With
                '        With txtbx_RcpEditFlush1FlowTol
                '            .Enabled = False
                '            .Text = "0.0"
                '        End With
                '        With txtbx_RcpEditFlush1RPM
                '            .Enabled = True
                '        End With
                'End Select

                panel_RcpEditFlush1PumpMode.Enabled = True
                If rdbtn_RcpEditFlush1PumpSpeed.Checked Then
                    txtbx_RcpEditFlush1RPM.Enabled = True
                Else
                    txtbx_RcpEditFlush1RPM.Enabled = False
                End If
            End If

            str_flush1enable = "Enable"
            'txtbx_RcpEditFlush1Fill.Text = CType(i_flush1filltime, String)
            'txtbx_RcpEditFlush1Bleed.Text = CType(i_flush1bleedtime, String)
            txtbx_RcpEditFlush1Flow.Text = CType(d_flush1flow, String)
            txtbx_RcpEditFlush1FlowTol.Text = CType(d_flush1flowtol, String)
            'txtbx_RcpEditFlush1Pressure.Text = CType(d_flush1pressure, String)
            txtbx_RcpEditFlush1Stabilize.Text = CType(i_flush1stabilize, String)
            txtbx_RcpEditFlush1Time.Text = CType(i_flush1time, String)

            If rdbtn_RcpEditFlush1PumpSpeed.Checked = True Then
                txtbx_RcpEditFlush1RPM.Text = CType(i_flush1rpm, String)
            End If
        Else
            'txtbx_RcpEditFlush1Fill.Enabled = False
            'txtbx_RcpEditFlush1Bleed.Enabled = False
            txtbx_RcpEditFlush1Flow.Enabled = False
            txtbx_RcpEditFlush1FlowTol.Enabled = False
            'txtbx_RcpEditFlush1Pressure.Enabled = False
            txtbx_RcpEditFlush1Stabilize.Enabled = False
            txtbx_RcpEditFlush1Time.Enabled = False
            panel_RcpEditFlush1PumpMode.Enabled = False
            txtbx_RcpEditFlush1RPM.Enabled = False

            str_flush1enable = "Disable"
            'txtbx_RcpEditFlush1Fill.Text = Nothing
            'txtbx_RcpEditFlush1Bleed.Text = Nothing
            txtbx_RcpEditFlush1Flow.Text = Nothing
            txtbx_RcpEditFlush1FlowTol.Text = Nothing
            'txtbx_RcpEditFlush1Pressure.Text = Nothing
            txtbx_RcpEditFlush1Stabilize.Text = Nothing
            txtbx_RcpEditFlush1Time.Text = Nothing
            rdbtn_RcpEditFlush1PumpProcess.Checked = True
            txtbx_RcpEditFlush1RPM.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_EditDPTest1_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_EditDPTest1.CheckedChanged
        If checkbx_EditDPTest1.Checked = True Then
            If checkbx_EditDPTest1.Enabled = True Then
                'txtbx_RcpEditDPFill.Enabled = True
                'txtbx_RcpEditDPBleed.Enabled = True
                'txtbx_RcpEditDPFlow.Enabled = True
                'txtbx_RcpEditDPFlowTol.Enabled = True
                'txtbx_RcpEditDPPressure.Enabled = True
                txtbx_RcpEditDPStabilize.Enabled = True
                txtbx_RcpEditDPTime.Enabled = True
                txtbx_RcpEditDPLowLimit.Enabled = True
                txtbx_RcpEditDPUpLimit.Enabled = True
                txtbx_RcpEditDPPoints.Enabled = True
                checkbx_EditDPTest2.Enabled = True
                'txtbx_RcpEditDPTestRPM.Enabled = True

                'Select Case cmbx_RcpEditPrepPumpMode.SelectedIndex
                '    Case 0
                '        With txtbx_RcpEditDPFlow
                '            .Enabled = True
                '        End With
                '        With txtbx_RcpEditDPFlowTol
                '            .Enabled = True
                '        End With
                '        With txtbx_RcpEditDPTestRPM
                '            .Enabled = False
                '        End With
                '    Case 1
                '        With txtbx_RcpEditDPFlow
                '            .Enabled = False
                '            .Text = d_prepflow.ToString("F1") '"0.0"
                '        End With
                '        With txtbx_RcpEditDPFlowTol
                '            .Enabled = False
                '            .Text = "0.0"
                '        End With
                '        With txtbx_RcpEditDPTestRPM
                '            .Enabled = True
                '        End With
                'End Select

                panel_RcpEditDPTestPumpMode.Enabled = True
                If rdbtn_RcpEditDPTestPumpSpeed.Checked Then
                    txtbx_RcpEditDPTestRPM.Enabled = True
                Else
                    txtbx_RcpEditDPTestRPM.Enabled = False
                End If
            End If

            str_dptest1enable = "Enable"
            'txtbx_RcpEditDPFill.Text = CType(i_dptestfilltime, String)
            'txtbx_RcpEditDPBleed.Text = CType(i_dptestbleedtime, String)
            'txtbx_RcpEditDPFlow.Text = CType(d_dptestflow, String)
            'txtbx_RcpEditDPFlowTol.Text = CType(d_dptestflowtol, String)
            'txtbx_RcpEditDPPressure.Text = CType(d_dptestpressure, String)
            txtbx_RcpEditDPStabilize.Text = CType(i_dpteststabilize, String)
            txtbx_RcpEditDPTime.Text = CType(i_dptesttime, String)
            txtbx_RcpEditDPLowLimit.Text = CType(d_dptestlowlimit, String)
            txtbx_RcpEditDPUpLimit.Text = CType(d_dptestuplimit, String)
            txtbx_RcpEditDPPoints.Text = CType(i_dptestpoints, String)

            If rdbtn_RcpEditDPTestPumpSpeed.Checked = True Then
                txtbx_RcpEditDPTestRPM.Text = CType(i_dptestrpm, String)
            End If
        Else
            'txtbx_RcpEditDPFill.Enabled = False
            'txtbx_RcpEditDPBleed.Enabled = False
            'txtbx_RcpEditDPFlow.Enabled = False
            'txtbx_RcpEditDPFlowTol.Enabled = False
            'txtbx_RcpEditDPPressure.Enabled = False
            txtbx_RcpEditDPStabilize.Enabled = False
            txtbx_RcpEditDPTime.Enabled = False
            txtbx_RcpEditDPLowLimit.Enabled = False
            txtbx_RcpEditDPUpLimit.Enabled = False
            txtbx_RcpEditDPPoints.Enabled = False
            checkbx_EditDPTest2.Enabled = False
            panel_RcpEditDPTestPumpMode.Enabled = False
            txtbx_RcpEditDPTestRPM.Enabled = False
            str_dptest1enable = "Disable"
            'txtbx_RcpEditDPFill.Text = Nothing
            'txtbx_RcpEditDPBleed.Text = Nothing
            'txtbx_RcpEditDPFlow.Text = Nothing
            'txtbx_RcpEditDPFlowTol.Text = Nothing
            'txtbx_RcpEditDPPressure.Text = Nothing
            txtbx_RcpEditDPStabilize.Text = Nothing
            txtbx_RcpEditDPTime.Text = Nothing
            txtbx_RcpEditDPLowLimit.Text = Nothing
            txtbx_RcpEditDPUpLimit.Text = Nothing
            txtbx_RcpEditDPPoints.Text = Nothing
            checkbx_EditDPTest2.Checked = False
            rdbtn_RcpEditDPTestPumpProcess.Checked = True
            txtbx_RcpEditDPTestRPM.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_EditFlush2_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_EditFlush2.CheckedChanged
        If checkbx_EditFlush2.Checked = True Then
            If checkbx_EditFlush2.Enabled = True Then
                'txtbx_RcpEditFlush2Fill.Enabled = True
                'txtbx_RcpEditFlush2Bleed.Enabled = True
                txtbx_RcpEditFlush2Flow.Enabled = True
                txtbx_RcpEditFlush2FlowTol.Enabled = True
                'txtbx_RcpEditFlush2Pressure.Enabled = True
                txtbx_RcpEditFlush2Stabilize.Enabled = True
                txtbx_RcpEditFlush2Time.Enabled = True
                'txtbx_RcpEditFlush2RPM.Enabled = True

                'Select Case cmbx_RcpEditPrepPumpMode.SelectedIndex
                '    Case 0
                '        With txtbx_RcpEditFlush2Flow
                '            .Enabled = True
                '        End With
                '        With txtbx_RcpEditFlush2FlowTol
                '            .Enabled = True
                '        End With
                '        With txtbx_RcpEditFlush2RPM
                '            .Enabled = False
                '        End With
                '    Case 1
                '        With txtbx_RcpEditFlush2Flow
                '            .Enabled = False
                '            .Text = d_prepflow.ToString("F1") '"0.0"
                '        End With
                '        With txtbx_RcpEditFlush2FlowTol
                '            .Enabled = False
                '            .Text = "0.0"
                '        End With
                '        With txtbx_RcpEditFlush2RPM
                '            .Enabled = True
                '        End With
                'End Select

                panel_RcpEditFlush2PumpMode.Enabled = True
                If rdbtn_RcpEditFlush2PumpSpeed.Checked Then
                    txtbx_RcpEditFlush2RPM.Enabled = True
                Else
                    txtbx_RcpEditFlush2RPM.Enabled = False
                End If
            End If

            str_flush2enable = "Enable"
            'txtbx_RcpEditFlush2Fill.Text = CType(i_flush2filltime, String)
            'txtbx_RcpEditFlush2Bleed.Text = CType(i_flush2bleedtime, String)
            txtbx_RcpEditFlush2Flow.Text = CType(d_flush2flow, String)
            txtbx_RcpEditFlush2FlowTol.Text = CType(d_flush2flowtol, String)
            'txtbx_RcpEditFlush2Pressure.Text = CType(d_flush2pressure, String)
            txtbx_RcpEditFlush2Stabilize.Text = CType(i_flush2stabilize, String)
            txtbx_RcpEditFlush2Time.Text = CType(i_flush2time, String)

            If rdbtn_RcpEditFlush2PumpSpeed.Checked = True Then
                txtbx_RcpEditFlush2RPM.Text = CType(i_flush2rpm, String)
            End If
        Else
            'txtbx_RcpEditFlush2Fill.Enabled = False
            'txtbx_RcpEditFlush2Bleed.Enabled = False
            txtbx_RcpEditFlush2Flow.Enabled = False
            txtbx_RcpEditFlush2FlowTol.Enabled = False
            'txtbx_RcpEditFlush2Pressure.Enabled = False
            txtbx_RcpEditFlush2Stabilize.Enabled = False
            txtbx_RcpEditFlush2Time.Enabled = False
            panel_RcpEditFlush2PumpMode.Enabled = False
            txtbx_RcpEditFlush2RPM.Enabled = False

            str_flush2enable = "Disable"
            'txtbx_RcpEditFlush2Fill.Text = Nothing
            'txtbx_RcpEditFlush2Bleed.Text = Nothing
            txtbx_RcpEditFlush2Flow.Text = Nothing
            txtbx_RcpEditFlush2FlowTol.Text = Nothing
            'txtbx_RcpEditFlush2Pressure.Text = Nothing
            txtbx_RcpEditFlush2Stabilize.Text = Nothing
            txtbx_RcpEditFlush2Time.Text = Nothing
            rdbtn_RcpEditFlush2PumpProcess.Checked = True
            txtbx_RcpEditFlush2RPM.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_EditDPTest2_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_EditDPTest2.CheckedChanged
        If checkbx_EditDPTest2.Checked = True Then
            str_dptest2enable = "Enable"
        Else
            str_dptest2enable = "Disable"
        End If
    End Sub

    Private Sub checkbx_EditDrain1_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_EditDrain1.CheckedChanged
        If checkbx_EditDrain1.Checked = True Then
            If checkbx_EditDrain1.Enabled = True Then
                txtbx_RcpEditDrain1Pressure.Enabled = True
                txtbx_RcpEditDrain1Time.Enabled = True
            End If

            str_drain1enable = "Enable"
            txtbx_RcpEditDrain1Pressure.Text = d_drain1pressure.ToString("F1")
            txtbx_RcpEditDrain1Time.Text = CType(i_drain1time, String)
        Else
            txtbx_RcpEditDrain1Pressure.Enabled = False
            txtbx_RcpEditDrain1Time.Enabled = False
            str_drain1enable = "Disable"
            txtbx_RcpEditDrain1Pressure.Text = Nothing
            txtbx_RcpEditDrain1Time.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_EditDrain2_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_EditDrain2.CheckedChanged
        If checkbx_EditDrain2.Checked = True Then
            If checkbx_EditDrain2.Enabled = True Then
                txtbx_RcpEditDrain2Pressure.Enabled = True
                txtbx_RcpEditDrain2Time.Enabled = True
            End If

            str_drain2enable = "Enable"
            txtbx_RcpEditDrain2Pressure.Text = d_drain2pressure.ToString("F1")
            txtbx_RcpEditDrain2Time.Text = CType(i_drain2time, String)
        Else
            txtbx_RcpEditDrain2Pressure.Enabled = False
            txtbx_RcpEditDrain2Time.Enabled = False
            str_drain2enable = "Disable"
            txtbx_RcpEditDrain2Pressure.Text = Nothing
            txtbx_RcpEditDrain2Time.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_EditDrain3_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_EditDrain3.CheckedChanged
        If checkbx_EditDrain3.Checked = True Then
            If checkbx_EditDrain3.Enabled = True Then
                txtbx_RcpEditDrain3Pressure.Enabled = True
                txtbx_RcpEditDrain3Time.Enabled = True
            End If
            str_drain3enable = "Enable"
            txtbx_RcpEditDrain3Pressure.Text = d_drain3pressure.ToString("F1")
            txtbx_RcpEditDrain3Time.Text = CType(i_drain3time, String)
        Else
            txtbx_RcpEditDrain3Pressure.Enabled = False
            txtbx_RcpEditDrain3Time.Enabled = False
            str_drain3enable = "Disable"
            txtbx_RcpEditDrain3Pressure.Text = Nothing
            txtbx_RcpEditDrain3Time.Text = Nothing
        End If
    End Sub

    Private Sub checkbx_EditDrain4_CheckedChanged(sender As Object, e As EventArgs) Handles checkbx_EditDrain4.CheckedChanged
        If checkbx_EditDrain4.Checked = True Then
            If checkbx_EditDrain4.Enabled = True Then
                txtbx_RcpEditDrain4Pressure.Enabled = True
                txtbx_RcpEditDrain4Time.Enabled = True
            End If
            str_drain4enable = "Enable"
            txtbx_RcpEditDrain4Pressure.Text = d_drain4pressure.ToString("F1")
            txtbx_RcpEditDrain4Time.Text = CType(i_drain4time, String)
        Else
            txtbx_RcpEditDrain4Pressure.Enabled = False
            txtbx_RcpEditDrain4Time.Enabled = False
            str_drain4enable = "Disable"
            txtbx_RcpEditDrain4Pressure.Text = Nothing
            txtbx_RcpEditDrain4Time.Text = Nothing
        End If
    End Sub
#End Region

#Region "Recipe Edit Parameter Range Validating Event"
    Private Sub txtbx_RcpEditVerTol_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditVerTol.Validating
        'Check verification tolerance

        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditVerTol.Text = "" And Not txtbx_RcpEditVerTol.Text = "." Then
            'Convert to the required type
            d_vertol = CType(txtbx_RcpEditVerTol.Text, Decimal)
            'Check the value within range
            If d_vertol < min_d_vertol Or d_vertol > max_d_vertol Then
                RecipeMessage(20, "Verification tolerance should be within " + CType(min_d_vertol, String) + " to " + CType(max_d_vertol, String))
                txtbx_RcpEditVerTol.Text = Nothing
                txtbx_RcpEditVerTol.Focus()
            End If

        Else
            RecipeMessage(19, "Verification tolerance")
        End If
    End Sub

    Private Sub txtbx_RcpEditPrepFill_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditPrepFill.Validating
        'Check fill time 

        'Check the text is empty
        If Not txtbx_RcpEditPrepFill.Text = "" Then
            'Convert to the required type
            i_prepfilltime = CType(txtbx_RcpEditPrepFill.Text, Integer)
            'Check the value within range
            If i_prepfilltime < min_i_prepfilltime Or i_prepfilltime > max_i_prepfilltime Then
                RecipeMessage(20, "Preparation Fill Time should be within " + CType(min_i_prepfilltime, String) + " to " + CType(max_i_prepfilltime, String))
                txtbx_RcpEditPrepFill.Text = Nothing
                txtbx_RcpEditPrepFill.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Fill Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditPrepBleed_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditPrepBleed.Validating
        'Check bleed time 

        'Check the text is empty
        If Not txtbx_RcpEditPrepBleed.Text = "" Then
            'Convert to the required type
            i_prepbleedtime = CType(txtbx_RcpEditPrepBleed.Text, Integer)
            'Check the value within range
            If i_prepbleedtime < min_i_prepbleedtime Or i_prepbleedtime > max_i_prepbleedtime Then
                RecipeMessage(20, "Preparation Bleed Time should be within " + CType(min_i_prepbleedtime, String) + " to " + CType(max_i_prepbleedtime, String))
                txtbx_RcpEditPrepBleed.Text = Nothing
                txtbx_RcpEditPrepBleed.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Bleed Time")
        End If
    End Sub

    'Private Sub txtbx_RcpEditPrepFlow_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditPrepFlow.Validating
    '    'Check for Preparation Flowrate
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpEditPrepFlow.Text = "" And Not txtbx_RcpEditPrepFlow.Text = "." Then
    '        'Convert to the required type
    '        d_prepflow = CType(txtbx_RcpEditPrepFlow.Text, Decimal)

    '        '' Set flowrate of other to same as this
    '        'If cmbx_RcpEditPrepPumpMode.SelectedIndex = 1 Then
    '        '    d_flush1flow = d_prepflow
    '        '    d_dptestflow = d_prepflow
    '        '    d_flush2flow = d_prepflow
    '        '    txtbx_RcpEditFlush1Flow.Text = d_prepflow.ToString("F1")
    '        '    txtbx_RcpEditDPFlow.Text = d_prepflow.ToString("F1")
    '        '    txtbx_RcpEditFlush2Flow.Text = d_prepflow.ToString("F1")

    '        '    d_flush1flowtol = 0
    '        '    d_dptestflowtol = 0
    '        '    d_flush2flowtol = 0
    '        '    txtbx_RcpEditFlush1FlowTol.Text = "0.0"
    '        '    txtbx_RcpEditDPFlowTol.Text = "0.0"
    '        '    txtbx_RcpEditFlush2FlowTol.Text = "0.0"
    '        'End If

    '        'Check the value within range
    '        If d_prepflow < min_d_prepflow Or d_prepflow > max_d_prepflow Then
    '            RecipeMessage(20, "Preparation Flowrate should be within " + CType(min_d_prepflow, String) + " to " + CType(max_d_prepflow, String))
    '            txtbx_RcpEditPrepFlow.Text = Nothing
    '            txtbx_RcpEditPrepFlow.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Preparation Flowrate")
    '    End If
    'End Sub

    Private Sub txtbx_RcpEditPrepPressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditPrepPressureDrop.Validating
        'Check for Preparation Back Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditPrepPressureDrop.Text = "" And Not txtbx_RcpEditPrepPressureDrop.Text = "." Then
            'Convert to the required type
            d_preppressure = CType(txtbx_RcpEditPrepPressureDrop.Text, Decimal)
            'Check the value within range
            If d_preppressure < min_d_preppressure Or d_preppressure > max_d_preppressure Then
                RecipeMessage(20, "Preparation Back Pressure should be within " + CType(min_d_preppressure, String) + " to " + CType(max_d_preppressure, String))
                txtbx_RcpEditPrepPressureDrop.Text = Nothing
                txtbx_RcpEditPrepPressureDrop.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Back Pressure")
        End If
    End Sub

    Private Sub txtbx_RcpEditPrepPressureDrop_Validating(sender As Object, e As CancelEventArgs)
        'Check for Preparation Back Pressure Drop
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditPrepPressureDrop.Text = "" And Not txtbx_RcpEditPrepPressureDrop.Text = "." Then
            'Convert to the required type
            d_preppressuredrop = CType(txtbx_RcpEditPrepPressureDrop.Text, Decimal)
            'Check the value within range
            If d_preppressuredrop < min_d_preppressuredrop Or d_preppressuredrop > max_d_preppressuredrop Then
                RecipeMessage(20, "Preparation Pressure Drop should be within " + CType(min_d_preppressuredrop, String) + " to " + CType(max_d_preppressuredrop, String))
                txtbx_RcpEditPrepPressureDrop.Text = Nothing
                txtbx_RcpEditPrepPressureDrop.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Pressure Drop")
        End If
    End Sub

    Private Sub txtbx_RcpEditPrepPressureDropTime_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditPrepPressureDropTime.Validating
        'Check pressure drop time 

        'Check the text is empty
        If Not txtbx_RcpEditPrepPressureDrop.Text = "" Then
            'Convert to the required type
            i_preppressuredroptime = CType(txtbx_RcpEditPrepPressureDrop.Text, Integer)
            'Check the value within range
            If i_preppressuredroptime < min_i_preppressuredroptime Or i_preppressuredroptime > max_i_preppressuredroptime Then
                RecipeMessage(20, "Preparation Drop Time should be within " + CType(min_i_preppressuredroptime, String) + " to " + CType(max_i_preppressuredroptime, String))
                txtbx_RcpEditPrepPressureDrop.Text = Nothing
                txtbx_RcpEditPrepPressureDrop.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Drop Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditPrefillStartTime_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditPrepPrefillStartTime.Validating
        'Check prefill start time 

        'Check the text is empty
        If Not txtbx_RcpEditPrepPrefillStartTime.Text = "" Then
            'Convert to the required type
            i_prepprefillstarttime = CType(txtbx_RcpEditPrepPrefillStartTime.Text, Integer)
            'Check the value within range
            If i_prepprefillstarttime < min_i_prepprefillstarttime Or i_prepprefillstarttime > max_i_prepprefillstarttime Then
                RecipeMessage(20, "Preparation Prefill Start Time should be within " + CType(min_i_prepprefillstarttime, String) + " to " + CType(max_i_prepprefillstarttime, String))
                txtbx_RcpEditPrepPrefillStartTime.Text = Nothing
                txtbx_RcpEditPrepPrefillStartTime.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Start Prefill Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditPrefillTime_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditPrepPrefillTime.Validating
        'Check prefill time 

        'Check the text is empty
        If Not txtbx_RcpEditPrepPrefillTime.Text = "" Then
            'Convert to the required type
            i_prepprefilltime = CType(txtbx_RcpEditPrepPrefillTime.Text, Integer)
            'Check the value within range
            If i_prepprefilltime < min_i_prepprefilltime Or i_prepprefilltime > max_i_prepprefilltime Then
                RecipeMessage(20, "Preparation Prefill Time should be within " + CType(min_i_prepprefilltime, String) + " to " + CType(max_i_prepprefilltime, String))
                txtbx_RcpEditPrepPrefillTime.Text = Nothing
                txtbx_RcpEditPrepPrefillTime.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation Prefill Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditPrepRPM_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditPrepRPM.Validating
        'Check rpm

        'Check the text is empty
        If Not txtbx_RcpEditPrepRPM.Text = "" Then
            'Convert to the required type
            i_preprpm1 = CType(txtbx_RcpEditPrepRPM.Text, Integer)
            'Check the value within range
            If i_preprpm1 < min_i_preprpm1 Or i_preprpm1 > max_i_preprpm1 Then
                RecipeMessage(20, "Preparation RPM should be within " + CType(min_i_preprpm1, String) + " to " + CType(max_i_preprpm1, String))
                txtbx_RcpEditPrepRPM.Text = Nothing
                txtbx_RcpEditPrepRPM.Focus()
            End If
        Else
            RecipeMessage(19, "Preparation RPM")
        End If
    End Sub

    'Private Sub txtbx_RcpEditPrepRPM2_Validating(sender As Object, e As CancelEventArgs)
    '    'Check rpm 

    '    'Check the text is empty
    '    If Not txtbx_RcpEditPrepRPM2.Text = "" Then
    '        'Convert to the required type
    '        i_preprpm2 = CType(txtbx_RcpEditPrepRPM2.Text, Integer)
    '        'Check the value within range
    '        If i_preprpm2 < min_i_preprpm2 Or i_preprpm2 > max_i_preprpm2 Then
    '            RecipeMessage(20, "Preparation RPM-2 should be within " + CType(min_i_preprpm2, String) + " to " + CType(max_i_preprpm2, String))
    '            txtbx_RcpEditPrepRPM2.Text = Nothing
    '            txtbx_RcpEditPrepRPM2.Focus()

    '        End If
    '    Else
    '        RecipeMessage(19, "Preparation RPM-2")
    '    End If

    'End Sub

    'Private Sub txtbx_RcpEditFlush1Fill_Validating(sender As Object, e As CancelEventArgs)
    '    'Check fill time 

    '    'Check the text is empty
    '    If Not txtbx_RcpEditFlush1Fill.Text = "" Then
    '        'Convert to the required type
    '        i_flush1filltime = CType(txtbx_RcpEditFlush1Fill.Text, Integer)
    '        'Check the value within range
    '        If i_flush1filltime < min_i_flush1filltime Or i_flush1filltime > max_i_flush1filltime Then
    '            RecipeMessage(20, "Flush-1 Fill Time should be within " + CType(min_i_flush1filltime, String) + " to " + CType(max_i_flush1filltime, String))
    '            txtbx_RcpEditFlush1Fill.Text = Nothing
    '            txtbx_RcpEditFlush1Fill.Focus()

    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-1 Fill Time")
    '    End If

    'End Sub

    'Private Sub txtbx_RcpEditFlush1Bleed_Validating(sender As Object, e As CancelEventArgs)
    '    'Check air bleed time

    '    'Check the text is empty
    '    If Not txtbx_RcpEditFlush1Bleed.Text = "" Then
    '        'Convert to the required type
    '        i_flush1bleedtime = CType(txtbx_RcpEditFlush1Bleed.Text, Integer)
    '        'Check the value within range
    '        If i_flush1bleedtime < min_i_flush1bleedtime Or i_flush1bleedtime > max_i_flush1bleedtime Then
    '            RecipeMessage(20, "Flush-1 Bleed Time should be within " + CType(min_i_flush1bleedtime, String) + " to " + CType(max_i_flush1bleedtime, String))
    '            txtbx_RcpEditFlush1Bleed.Text = Nothing
    '            txtbx_RcpEditFlush1Bleed.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-1 Bleed Time")

    '    End If

    'End Sub

    Private Sub txtbx_RcpEditFlush1Flow_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush1Flow.Validating
        'Check for Flush-1 Flowrate
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditFlush1Flow.Text = "" And Not txtbx_RcpEditFlush1Flow.Text = "." Then
            'Convert to the required type
            d_flush1flow = CType(txtbx_RcpEditFlush1Flow.Text, Decimal)
            'Check the value within range
            If d_flush1flow < min_d_flush1flow Or d_flush1flow > max_d_flush1flow Then
                RecipeMessage(20, "Flush-1 Flowrate should be within " + CType(min_d_flush1flow, String) + " to " + CType(max_d_flush1flow, String))
                txtbx_RcpEditFlush1Flow.Text = Nothing
                txtbx_RcpEditFlush1Flow.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 Flowrate")
        End If
    End Sub

    Private Sub txtbx_RcpEditFlush1FlowTol_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush1FlowTol.Validating
        'Check for Flush-1 Flow Tolerance
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditFlush1FlowTol.Text = "" And Not txtbx_RcpEditFlush1FlowTol.Text = "." Then
            'Convert to the required type
            d_flush1flowtol = CType(txtbx_RcpEditFlush1FlowTol.Text, Decimal)
            'Check the value within range
            If d_flush1flowtol < min_d_flush1flowtol Or d_flush1flowtol > max_d_flush1flowtol Then
                RecipeMessage(20, "Flush-1 Flow Tolerance should be within " + CType(min_d_flush1flowtol, String) + " to " + CType(max_d_flush1flowtol, String))
                txtbx_RcpEditFlush1FlowTol.Text = Nothing
                txtbx_RcpEditFlush1FlowTol.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 Flow tolerance")
        End If
    End Sub

    'Private Sub txtbx_RcpEditFlush1Pressure_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for Flush-1 Pressure
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpEditFlush1Pressure.Text = "" And Not txtbx_RcpEditFlush1Pressure.Text = "." Then
    '        'Convert to the required type
    '        d_flush1pressure = CType(txtbx_RcpEditFlush1Pressure.Text, Decimal)
    '        'Check the value within range
    '        If d_flush1pressure < min_d_flush1pressure Or d_flush1pressure > max_d_flush1pressure Then
    '            RecipeMessage(20, "Flush-1 Pressure should be within " + CType(min_d_flush1pressure, String) + " to " + CType(max_d_flush1pressure, String))
    '            txtbx_RcpEditFlush1Pressure.Text = Nothing
    '            txtbx_RcpEditFlush1Pressure.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-1 Back Pressure")
    '    End If
    'End Sub

    Private Sub txtbx_RcpEditFlush1Stabilize_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush1Stabilize.Validating
        'Check for Flush-1 Stabilize Time
        'Check the text is empty
        If Not txtbx_RcpEditFlush1Stabilize.Text = "" Then
            'Convert to the required type
            i_flush1stabilize = CType(txtbx_RcpEditFlush1Stabilize.Text, Integer)
            'Check the value within range
            If i_flush1stabilize < min_i_flush1stabilize Or i_flush1stabilize > max_i_flush1stabilize Then
                RecipeMessage(20, "Flush-1 Stabilize Time should be within " + CType(min_i_flush1stabilize, String) + " to " + CType(max_i_flush1stabilize, String))
                txtbx_RcpEditFlush1Stabilize.Text = Nothing
                txtbx_RcpEditFlush1Stabilize.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 Stabilize Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditFlush1Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush1Time.Validating
        'Check for Flush-1 Time
        'Check the text is empty
        If Not txtbx_RcpEditFlush1Time.Text = "" Then
            'Convert to the required type
            i_flush1time = CType(txtbx_RcpEditFlush1Time.Text, Integer)
            'Check the value within range
            If i_flush1time < min_i_flush1time Or i_flush1time > max_i_flush1time Then
                RecipeMessage(20, "Flush-1 Time should be within " + CType(min_i_flush1time, String) + " to " + CType(max_i_flush1time, String))
                txtbx_RcpEditFlush1Time.Text = Nothing
                txtbx_RcpEditFlush1Time.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditFlush1RPM_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush1RPM.Validating
        'Check for Flush-1 RPM
        'Check the text is empty
        If Not txtbx_RcpEditFlush1RPM.Text = "" Then
            'Convert to the required type
            i_flush1rpm = CType(txtbx_RcpEditFlush1RPM.Text, Integer)
            'Check the value within range
            If i_flush1rpm < min_i_flush1rpm Or i_flush1rpm > max_i_flush1rpm Then
                RecipeMessage(20, "Flush-1 RPM should be within " + CType(min_i_flush1rpm, String) + " to " + CType(max_i_flush1rpm, String))
                txtbx_RcpEditFlush1RPM.Text = Nothing
                txtbx_RcpEditFlush1RPM.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-1 RPM")
        End If
    End Sub

    'Private Sub txtbx_RcpEditDPFill_Validating(sender As Object, e As CancelEventArgs)
    '    'Check fill time 

    '    'Check the text is empty
    '    If Not txtbx_RcpEditDPFill.Text = "" Then
    '        'Convert to the required type
    '        i_dptestfilltime = CType(txtbx_RcpEditDPFill.Text, Integer)
    '        'Check the value within range
    '        If i_dptestfilltime < min_i_dptestfilltime Or i_dptestfilltime > max_i_dptestfilltime Then
    '            RecipeMessage(20, "DP Test Fill Time should be within " + CType(min_i_dptestfilltime, String) + " to " + CType(max_i_dptestfilltime, String))
    '            txtbx_RcpEditDPFill.Text = Nothing
    '            txtbx_RcpEditDPFill.Focus()

    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Fill Time")
    '    End If
    'End Sub

    'Private Sub txtbx_RcpEditDPBleed_Validating(sender As Object, e As CancelEventArgs)
    '    'Check air bleed time

    '    'Check the text is empty
    '    If Not txtbx_RcpEditDPBleed.Text = "" Then
    '        'Convert to the required type
    '        i_dptestbleedtime = CType(txtbx_RcpEditDPBleed.Text, Integer)
    '        'Check the value within range
    '        If i_dptestbleedtime < min_i_dptestbleedtime Or i_dptestbleedtime > max_i_dptestbleedtime Then
    '            RecipeMessage(20, "DP Test Bleed Time should be within " + CType(min_i_dptestbleedtime, String) + " to " + CType(max_i_dptestbleedtime, String))
    '            txtbx_RcpEditDPBleed.Text = Nothing
    '            txtbx_RcpEditDPBleed.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Bleed Time")

    '    End If
    'End Sub


    'Private Sub txtbx_RcpEditDPFlow_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for DP Test Flowrate
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpEditDPFlow.Text = "" And Not txtbx_RcpEditDPFlow.Text = "." Then
    '        'Convert to the required type
    '        d_dptestflow = CType(txtbx_RcpEditDPFlow.Text, Decimal)
    '        'Check the value within range
    '        If d_dptestflow < min_d_dptestflow Or d_dptestflow > max_d_dptestflow Then
    '            RecipeMessage(20, "DP Test Flowrate should be within " + CType(min_d_dptestflow, String) + " to " + CType(max_d_dptestflow, String))
    '            txtbx_RcpEditDPFlow.Text = Nothing
    '            txtbx_RcpEditDPFlow.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Flowrate")

    '    End If
    'End Sub

    'Private Sub txtbx_RcpEditDPFlowTol_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for DP Test Flow Tolerance
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpEditDPFlowTol.Text = "" And Not txtbx_RcpEditDPFlowTol.Text = "." Then
    '        'Convert to the required type
    '        d_dptestflowtol = CType(txtbx_RcpEditDPFlowTol.Text, Decimal)
    '        'Check the value within range
    '        If d_dptestflowtol < min_d_dptestflowtol Or d_dptestflowtol > max_d_dptestflowtol Then
    '            RecipeMessage(20, "DP Test Flow Tolerance should be within " + CType(min_d_dptestflowtol, String) + " to " + CType(max_d_dptestflowtol, String))
    '            txtbx_RcpEditDPFlowTol.Text = Nothing
    '            txtbx_RcpEditDPFlowTol.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Flow tolerance")

    '    End If
    'End Sub
    'Private Sub txtbx_RcpEditDPPressure_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for DP Test Pressure
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpEditDPPressure.Text = "" And Not txtbx_RcpEditDPPressure.Text = "." Then
    '        'Convert to the required type
    '        d_dptestpressure = CType(txtbx_RcpEditDPPressure.Text, Decimal)
    '        'Check the value within range
    '        If d_dptestpressure < min_d_dptestpressure Or d_dptestpressure > max_d_dptestpressure Then
    '            RecipeMessage(20, "DP Test Pressure should be within " + CType(min_d_dptestpressure, String) + " to " + CType(max_d_dptestpressure, String))
    '            txtbx_RcpEditDPPressure.Text = Nothing
    '            txtbx_RcpEditDPPressure.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test Back Pressure")

    '    End If
    'End Sub

    Private Sub txtbx_RcpEditDPStabilize_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDPStabilize.Validating
        'Check for DP Test Stabilize Time
        'Check the text is empty
        If Not txtbx_RcpEditDPStabilize.Text = "" Then
            'Convert to the required type
            i_dpteststabilize = CType(txtbx_RcpEditDPStabilize.Text, Integer)
            'Check the value within range
            If i_dpteststabilize < min_i_dpteststabilize Or i_dpteststabilize > max_i_dpteststabilize Then
                RecipeMessage(20, "DP Test Stabilize Time should be within " + CType(min_i_dpteststabilize, String) + " to " + CType(max_i_dpteststabilize, String))
                txtbx_RcpEditDPStabilize.Text = Nothing
                txtbx_RcpEditDPStabilize.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test Stabilize Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditDPTime_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDPTime.Validating
        'Check for DP Test Time
        'Check the text is empty
        If Not txtbx_RcpEditDPTime.Text = "" Then
            'Convert to the required type
            i_dptesttime = CType(txtbx_RcpEditDPTime.Text, Integer)
            'Check the value within range
            If i_dptesttime < min_i_dptesttime Or i_dptesttime > max_i_dptesttime Then
                RecipeMessage(20, "DP Test Time should be within " + CType(min_i_dptesttime, String) + " to " + CType(max_i_dptesttime, String))
                txtbx_RcpEditDPTime.Text = Nothing
                txtbx_RcpEditDPTime.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditDPLowLimit_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDPLowLimit.Validating
        'Check for DP Test LowerLimit
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditDPLowLimit.Text = "" And Not txtbx_RcpEditDPLowLimit.Text = "." Then
            'Convert to the required type
            d_dptestlowlimit = CType(txtbx_RcpEditDPLowLimit.Text, Decimal)
            'Check the value within range
            If d_dptestlowlimit < min_d_dptestlowlimit Or d_dptestlowlimit > max_d_dptestlowlimit Then
                RecipeMessage(20, "DP Test Lower Limit should be within " + CType(min_d_dptestlowlimit, String) + " to " + CType(max_d_dptestlowlimit, String))
                txtbx_RcpEditDPLowLimit.Text = Nothing
                txtbx_RcpEditDPLowLimit.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test Lower Limit")
        End If
    End Sub

    Private Sub txtbx_RcpEditDPUpLimit_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDPUpLimit.Validating
        'check for dp test upperlimit
        'check the text is empty or has only decimal point
        If Not txtbx_RcpEditDPUpLimit.Text = "" And Not txtbx_RcpEditDPUpLimit.Text = "." Then
            'convert to the required type
            d_dptestuplimit = CType(txtbx_RcpEditDPUpLimit.Text, Decimal)
            'check the value within range
            If d_dptestuplimit < min_d_dptestuplimit Or d_dptestuplimit > max_d_dptestuplimit Then
                RecipeMessage(20, "DP Test Upper Limit should be within " + CType(min_d_dptestuplimit, String) + " to " + CType(max_d_dptestuplimit, String))
                txtbx_RcpEditDPUpLimit.Text = Nothing
                txtbx_RcpEditDPUpLimit.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test Upper Limit")
        End If
    End Sub
    Private Sub txtbx_RcpEditDPPoints_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDPPoints.Validating
        'Check for DP Test points
        'Check the text is empty
        If Not txtbx_RcpEditDPPoints.Text = "" Then
            'Convert to the required type
            i_dptestpoints = CType(txtbx_RcpEditDPPoints.Text, Integer)
            'Check the value within range
            If i_dptestpoints < min_i_dptestpoints Or i_dptestpoints > max_i_dptestpoints Then
                RecipeMessage(20, "DP Test Point should be within " + CType(min_i_dptestpoints, String) + " to " + CType(max_i_dptestpoints, String))
                txtbx_RcpEditDPPoints.Text = Nothing
                txtbx_RcpEditDPPoints.Focus()
            End If
        Else
            RecipeMessage(19, "DP Test points")
        End If
    End Sub

    'Private Sub txtbx_RcpEditDPTestRPM_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDPTestRPM.Validating
    '    'Check for DP Test RPM
    '    'Check the text is empty
    '    If Not txtbx_RcpEditDPTestRPM.Text = "" Then
    '        'Convert to the required type
    '        i_dptestrpm = CType(txtbx_RcpEditDPTestRPM.Text, Integer)
    '        'Check the value within range
    '        If i_dptestrpm < min_i_dptestrpm Or i_dptestrpm > max_i_dptestrpm Then
    '            RecipeMessage(20, "DP Test RPM should be within " + CType(min_i_dptestrpm, String) + " to " + CType(max_i_dptestrpm, String))
    '            txtbx_RcpEditDPTestRPM.Text = Nothing
    '            txtbx_RcpEditDPTestRPM.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "DP Test RPM")
    '    End If
    'End Sub

    'Private Sub txtbx_RcpEditflush2Fill_Validating(sender As Object, e As CancelEventArgs)
    '    'Check fill time 

    '    'Check the text is empty
    '    If Not txtbx_RcpEditFlush2Fill.Text = "" Then
    '        'Convert to the required type
    '        i_flush2filltime = CType(txtbx_RcpEditFlush2Fill.Text, Integer)
    '        'Check the value within range
    '        If i_flush2filltime < min_i_flush2filltime Or i_flush2filltime > max_i_flush2filltime Then
    '            RecipeMessage(20, "Flush-2 Fill Time should be within " + CType(min_i_flush2filltime, String) + " to " + CType(max_i_flush2filltime, String))
    '            txtbx_RcpEditFlush2Fill.Text = Nothing
    '            txtbx_RcpEditFlush2Fill.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-2 Fill Time")
    '    End If

    'End Sub

    'Private Sub txtbx_RcpEditflush2Bleed_Validating(sender As Object, e As CancelEventArgs)
    '    'Check air bleed time

    '    'Check the text is empty
    '    If Not txtbx_RcpEditFlush2Bleed.Text = "" Then
    '        'Convert to the required type
    '        i_flush2bleedtime = CType(txtbx_RcpEditFlush2Bleed.Text, Integer)
    '        'Check the value within range
    '        If i_flush2bleedtime < min_i_flush2bleedtime Or i_flush2bleedtime > max_i_flush2bleedtime Then
    '            RecipeMessage(20, "Flush-2 Bleed Time should be within " + CType(min_i_flush2bleedtime, String) + " to " + CType(max_i_flush2bleedtime, String))
    '            txtbx_RcpEditFlush2Bleed.Text = Nothing
    '            txtbx_RcpEditFlush2Bleed.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-2 Bleed Time")

    '    End If

    'End Sub

    Private Sub txtbx_RcpEditflush2Flow_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush2Flow.Validating
        'Check for Flush-2 Flowrate
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditFlush2Flow.Text = "" And Not txtbx_RcpEditFlush2Flow.Text = "." Then
            'Convert to the required type
            d_flush2flow = CType(txtbx_RcpEditFlush2Flow.Text, Decimal)
            'Check the value within range
            If d_flush2flow < min_d_flush2flow Or d_flush2flow > max_d_flush2flow Then
                RecipeMessage(20, "Flush-2 Flowrate should be within " + CType(min_d_flush2flow, String) + " to " + CType(max_d_flush2flow, String))
                txtbx_RcpEditFlush2Flow.Text = Nothing
                txtbx_RcpEditFlush2Flow.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-2 Flowrate")
        End If
    End Sub

    Private Sub txtbx_RcpEditflush2FlowTol_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush2FlowTol.Validating
        'Check for Flush-2 Flow Tolerance
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditFlush2FlowTol.Text = "" And Not txtbx_RcpEditFlush2FlowTol.Text = "." Then
            'Convert to the required type
            d_flush2flowtol = CType(txtbx_RcpEditFlush2FlowTol.Text, Decimal)
            'Check the value within range
            If d_flush2flowtol < min_d_flush2flowtol Or d_flush2flowtol > max_d_flush2flowtol Then
                RecipeMessage(20, "Flush-2 Flow Tolerance should be within " + CType(min_d_flush2flowtol, String) + " to " + CType(max_d_flush2flowtol, String))
                txtbx_RcpEditFlush2FlowTol.Text = Nothing
                txtbx_RcpEditFlush2FlowTol.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-2 Flow tolerance")
        End If
    End Sub

    'Private Sub txtbx_RcpEditflush2Pressure_Validating(sender As Object, e As CancelEventArgs)
    '    'Check for Flush-2 Pressure
    '    'Check the text is empty or has only decimal point
    '    If Not txtbx_RcpEditFlush2Pressure.Text = "" And Not txtbx_RcpEditFlush2Pressure.Text = "." Then
    '        'Convert to the required type
    '        d_flush2pressure = CType(txtbx_RcpEditFlush2Pressure.Text, Decimal)
    '        'Check the value within range
    '        If d_flush2pressure < min_d_flush2pressure Or d_flush2pressure > max_d_flush2pressure Then
    '            RecipeMessage(20, "Flush-2 Pressure should be within " + CType(min_d_flush2pressure, String) + " to " + CType(max_d_flush2pressure, String))
    '            txtbx_RcpEditFlush2Pressure.Text = Nothing
    '            txtbx_RcpEditFlush2Pressure.Focus()
    '        End If
    '    Else
    '        RecipeMessage(19, "Flush-2 Back Pressure")
    '    End If
    'End Sub

    Private Sub txtbx_RcpEditflush2Stabilize_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush2Stabilize.Validating
        'Check for Flush-2 Stabilize Time
        'Check the text is empty
        If Not txtbx_RcpEditFlush2Stabilize.Text = "" Then
            'Convert to the required type
            i_flush2stabilize = CType(txtbx_RcpEditFlush2Stabilize.Text, Integer)
            'Check the value within range
            If i_flush2stabilize < min_i_flush2stabilize Or i_flush2stabilize > max_i_flush2stabilize Then
                RecipeMessage(20, "Flush-2 Stabilize Time should be within " + CType(min_i_flush2stabilize, String) + " to " + CType(max_i_flush2stabilize, String))
                txtbx_RcpEditFlush2Stabilize.Text = Nothing
                txtbx_RcpEditFlush2Stabilize.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-2 Stabilize Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditflush2Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush2Time.Validating
        'Check for Flush-2 Time
        'Check the text is empty
        If Not txtbx_RcpEditFlush2Time.Text = "" Then
            'Convert to the required type
            i_flush2time = CType(txtbx_RcpEditFlush2Time.Text, Integer)
            'Check the value within range
            If i_flush2time < min_i_flush2time Or i_flush2time > max_i_flush2time Then
                RecipeMessage(20, "Flush-2 Time should be within " + CType(min_i_flush2time, String) + " to " + CType(max_i_flush2time, String))
                txtbx_RcpEditFlush2Time.Text = Nothing
                txtbx_RcpEditFlush2Time.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-2 Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditFlush2RPM_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditFlush2RPM.Validating
        'Check for Flush-2 RPM
        'Check the text is empty
        If Not txtbx_RcpEditFlush2RPM.Text = "" Then
            'Convert to the required type
            i_flush2rpm = CType(txtbx_RcpEditFlush2RPM.Text, Integer)
            'Check the value within range
            If i_flush2rpm < min_i_flush2rpm Or i_flush2rpm > max_i_flush2rpm Then
                RecipeMessage(20, "Flush-2 RPM should be within " + CType(min_i_flush2rpm, String) + " to " + CType(max_i_flush2rpm, String))
                txtbx_RcpEditFlush2RPM.Text = Nothing
                txtbx_RcpEditFlush2RPM.Focus()
            End If
        Else
            RecipeMessage(19, "Flush-2 RPM")
        End If
    End Sub

    Private Sub txtbx_RcpEditDrain1Pressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDrain1Pressure.Validating
        'Check for Drain-1 Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditDrain1Pressure.Text = "" And Not txtbx_RcpEditDrain1Pressure.Text = "." Then
            'Convert to the required type
            d_drain1pressure = CType(txtbx_RcpEditDrain1Pressure.Text, Decimal)
            'Check the value within range
            If d_drain1pressure < min_d_drain1pressure Or d_drain1pressure > max_d_drain1pressure Then
                RecipeMessage(20, "Drain-1 Pressure should be within " + CType(min_d_drain1pressure, String) + " to " + CType(max_d_drain1pressure, String))
                txtbx_RcpEditDrain1Pressure.Text = Nothing
                txtbx_RcpEditDrain1Pressure.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-1 Pressure")
        End If
    End Sub

    Private Sub txtbx_RcpEditDrain1Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDrain1Time.Validating
        'Check for Drain-1 Time
        'Check the text is empty
        If Not txtbx_RcpEditDrain1Time.Text = "" Then
            'Convert to the required type
            i_drain1time = CType(txtbx_RcpEditDrain1Time.Text, Integer)
            'Check the value within range
            If i_drain1time < min_i_drain1time Or i_drain1time > max_i_drain1time Then
                RecipeMessage(20, "Drain-1 Time should be within " + CType(min_i_drain1time, String) + " to " + CType(max_i_drain1time, String))
                txtbx_RcpEditDrain1Time.Text = Nothing
                txtbx_RcpEditDrain1Time.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-1 Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditDrain2Pressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDrain2Pressure.Validating
        'Check for Drain-2 Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditDrain2Pressure.Text = "" And Not txtbx_RcpEditDrain2Pressure.Text = "." Then
            'Convert to the required type
            d_drain2pressure = CType(txtbx_RcpEditDrain2Pressure.Text, Decimal)
            'Check the value within range
            If d_drain2pressure < min_d_drain2pressure Or d_drain2pressure > max_d_drain2pressure Then
                RecipeMessage(20, "Drain-2 Pressure should be within " + CType(min_d_drain2pressure, String) + " to " + CType(max_d_drain2pressure, String))
                txtbx_RcpEditDrain2Pressure.Text = Nothing
                txtbx_RcpEditDrain2Pressure.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-2 Pressure")
        End If
    End Sub

    Private Sub txtbx_RcpEditDrain2Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDrain2Time.Validating
        'Check for Drain-2 Time
        'Check the text is empty
        If Not txtbx_RcpEditDrain2Time.Text = "" Then
            'Convert to the required type
            i_drain2time = CType(txtbx_RcpEditDrain2Time.Text, Integer)
            'Check the value within range
            If i_drain2time < min_i_drain2time Or i_drain2time > max_i_drain2time Then
                RecipeMessage(20, "Drain-2 Time should be within " + CType(min_i_drain2time, String) + " to " + CType(max_i_drain2time, String))
                txtbx_RcpEditDrain2Time.Text = Nothing
                txtbx_RcpEditDrain2Time.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-2 Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditDrain3Pressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDrain3Pressure.Validating
        'Check for FDrain-3 Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditDrain3Pressure.Text = "" And Not txtbx_RcpEditDrain3Pressure.Text = "." Then
            'Convert to the required type
            d_drain3pressure = CType(txtbx_RcpEditDrain3Pressure.Text, Decimal)
            'Check the value within range
            If d_drain3pressure < min_d_drain3pressure Or d_drain3pressure > max_d_drain3pressure Then
                RecipeMessage(20, "Drain-3 Pressure should be within " + CType(min_d_drain3pressure, String) + " to " + CType(max_d_drain3pressure, String))
                txtbx_RcpEditDrain3Pressure.Text = Nothing
                txtbx_RcpEditDrain3Pressure.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-3 Pressure")
        End If
    End Sub

    Private Sub txtbx_RcpEditDrain3Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDrain3Time.Validating
        'Check for Drain-3 Time
        'Check the text is empty
        If Not txtbx_RcpEditDrain3Time.Text = "" Then
            'Convert to the required type
            i_drain3time = CType(txtbx_RcpEditDrain3Time.Text, Integer)
            'Check the value within range
            If i_drain3time < min_i_drain3time Or i_drain3time > max_i_drain3time Then
                RecipeMessage(20, "Drain-3 Time should be within " + CType(min_i_drain3time, String) + " to " + CType(max_i_drain3time, String))
                txtbx_RcpEditDrain3Time.Text = Nothing
                txtbx_RcpEditDrain3Time.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-3 Time")
        End If
    End Sub

    Private Sub txtbx_RcpEditDrain4Pressure_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDrain4Pressure.Validating
        'Check for FDrain-4 Pressure
        'Check the text is empty or has only decimal point
        If Not txtbx_RcpEditDrain4Pressure.Text = "" And Not txtbx_RcpEditDrain4Pressure.Text = "." Then
            'Convert to the required type
            d_drain4pressure = CType(txtbx_RcpEditDrain4Pressure.Text, Decimal)
            'Check the value within range
            If d_drain4pressure < min_d_drain4pressure Or d_drain4pressure > max_d_drain4pressure Then
                RecipeMessage(20, "Drain-4 Pressure should be within " + CType(min_d_drain4pressure, String) + " to " + CType(max_d_drain4pressure, String))
                txtbx_RcpEditDrain4Pressure.Text = Nothing
                txtbx_RcpEditDrain4Pressure.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-4 Pressure")
        End If
    End Sub

    Private Sub txtbx_RcpEditDrain4Time_Validating(sender As Object, e As CancelEventArgs) Handles txtbx_RcpEditDrain4Time.Validating
        'Check for Drain-4 Time
        'Check the text is empty
        If Not txtbx_RcpEditDrain4Time.Text = "" Then
            'Convert to the required type
            i_drain4time = CType(txtbx_RcpEditDrain4Time.Text, Integer)
            'Check the value within range
            If i_drain4time < min_i_drain4time Or i_drain4time > max_i_drain4time Then
                RecipeMessage(20, "Drain-4 Time should be within " + CType(min_i_drain4time, String) + " to " + CType(max_i_drain4time, String))
                txtbx_RcpEditDrain4Time.Text = Nothing
                txtbx_RcpEditDrain4Time.Focus()
            End If
        Else
            RecipeMessage(19, "Drain-4 Time")
        End If
    End Sub
#End Region

#Region "Edit Recipe"
    Private Sub btn_RcpEdit_Click(sender As Object, e As EventArgs) Handles btn_RcpEdit.Click
        'cmbx_RcpEditRecipeID.Enabled=false
        txtbx_RcpEditVerTol.Enabled = True

        ComboBox9.Enabled = True
        ComboBox8.Enabled = True
        ComboBox7.Enabled = True

        txtbx_RcpEditPrepFill.Enabled = True
        'txtbx_RcpEditPrepBleed.Enabled = True
        'txtbx_RcpEditDPFlow.Enabled = True
        'txtbx_RcpEditDPFlowTol.Enabled = True
        txtbx_RcpEditPrepPressureDrop.Enabled = True
        txtbx_RcpEditPrepPressureDropTime.Enabled = True
        txtbx_RcpEditPrepPressure.Enabled = True
        'txtbx_RcpEditPrepPrefillStartTime.Enabled = True
        'txtbx_RcpEditPrepPrefillTime.Enabled = True
        'cmbx_RcpEditPrepPumpMode.Enabled = True
        'Select Case cmbx_RcpEditPrepPumpMode.SelectedIndex
        '    Case 0
        '        txtbx_RcpEditPrepRPM.Enabled = False
        '        txtbx_RcpEditPrepRPM2.Enabled = False
        '        'txtbx_RcpEditPrepFlow.Enabled = True
        '        txtbx_RcpEditPrepFlowTol.Enabled = False
        '    Case 1
        '        txtbx_RcpEditPrepRPM.Enabled = True
        '        txtbx_RcpEditPrepRPM2.Enabled = True
        '        'txtbx_RcpEditPrepFlow.Enabled = False
        '        txtbx_RcpEditPrepFlowTol.Enabled = True
        'End Select
        panel_RcpEditPrepPumpMode.Enabled = True
        If rdbtn_RcpEditPrepPumpSpeed.Checked Then
            txtbx_RcpEditPrepRPM.Enabled = True
        Else
            txtbx_RcpEditPrepRPM.Enabled = False
        End If

        If Not DirectCast(cmbx_RcpEditFilterType.SelectedItem, KeyValuePair(Of String, String)).Value = "Cal. Master" Then
            checkbx_EditDrain1.Enabled = True
            checkbx_EditDrain3.Enabled = True
            txtbx_RcpEditPrepBleed.Enabled = True
            txtbx_RcpEditPrepPrefillStartTime.Enabled = True
            txtbx_RcpEditPrepPrefillTime.Enabled = True
            txtbx_RcpEditPrepDrainStartTime.Enabled = True
            txtbx_RcpEditPrepDrainTime.Enabled = True
        End If

        If checkbx_EditFlush1.Checked = True Then
            'txtbx_RcpEditFlush1Fill.Enabled = True
            'txtbx_RcpEditFlush1Bleed.Enabled = True
            txtbx_RcpEditFlush1Flow.Enabled = True
            txtbx_RcpEditFlush1FlowTol.Enabled = True
            txtbx_RcpEditFlush1Pressure.Enabled = True
            txtbx_RcpEditFlush1Stabilize.Enabled = True
            txtbx_RcpEditFlush1Time.Enabled = True
            'Select Case cmbx_RcpEditPrepPumpMode.SelectedIndex
            '    Case 0
            '        txtbx_RcpEditFlush1RPM.Enabled = False
            '        txtbx_RcpEditFlush1RPM.Enabled = False
            '        txtbx_RcpEditFlush1Flow.Enabled = True
            '        txtbx_RcpEditFlush1FlowTol.Enabled = True
            '    Case 1
            '        txtbx_RcpEditFlush1RPM.Enabled = True
            '        txtbx_RcpEditFlush1RPM.Enabled = True
            '        txtbx_RcpEditFlush1Flow.Enabled = False
            '        txtbx_RcpEditFlush1FlowTol.Enabled = False
            'End Select
            panel_RcpEditFlush1PumpMode.Enabled = True
            If rdbtn_RcpEditFlush1PumpSpeed.Checked Then
                txtbx_RcpEditFlush1RPM.Enabled = True
            Else
                txtbx_RcpEditFlush1RPM.Enabled = False
            End If
        End If

        If checkbx_EditDPTest1.Checked = True Then
            'txtbx_RcpEditDPFill.Enabled = True
            'txtbx_RcpEditDPBleed.Enabled = True
            txtbx_RcpEditDPFlow.Enabled = True
            txtbx_RcpEditDPFlowTol.Enabled = True
            txtbx_RcpEditDPPressure.Enabled = True
            txtbx_RcpEditDPStabilize.Enabled = True
            txtbx_RcpEditDPTime.Enabled = True
            txtbx_RcpEditDPLowLimit.Enabled = True
            txtbx_RcpEditDPUpLimit.Enabled = True
            txtbx_RcpEditDPPoints.Enabled = True
            checkbx_EditDPTest2.Enabled = True
            'Select Case cmbx_RcpEditPrepPumpMode.SelectedIndex
            '    Case 0
            '        txtbx_RcpEditDPTestRPM.Enabled = False
            '        txtbx_RcpEditDPTestRPM.Enabled = False
            '        txtbx_RcpEditDPFlow.Enabled = True
            '        txtbx_RcpEditDPFlowTol.Enabled = True
            '    Case 1
            '        txtbx_RcpEditDPTestRPM.Enabled = True
            '        txtbx_RcpEditDPTestRPM.Enabled = True
            '        txtbx_RcpEditDPFlow.Enabled = False
            '        txtbx_RcpEditDPFlowTol.Enabled = False
            'End Select
            panel_RcpEditDPTestPumpMode.Enabled = True
            If rdbtn_RcpEditDPTestPumpSpeed.Checked Then
                txtbx_RcpEditDPTestRPM.Enabled = True
            Else
                txtbx_RcpEditDPTestRPM.Enabled = False
            End If
        End If

        If checkbx_EditFlush2.Checked = True Then
            'txtbx_RcpEditFlush2Fill.Enabled = True
            'txtbx_RcpEditFlush2Bleed.Enabled = True
            txtbx_RcpEditFlush2Flow.Enabled = True
            txtbx_RcpEditFlush2FlowTol.Enabled = True
            txtbx_RcpEditFlush2Pressure.Enabled = True
            txtbx_RcpEditFlush2Stabilize.Enabled = True
            txtbx_RcpEditFlush2Time.Enabled = True
            'Select Case cmbx_RcpEditPrepPumpMode.SelectedIndex
            '    Case 0
            '        txtbx_RcpEditFlush2RPM.Enabled = False
            '        txtbx_RcpEditFlush2RPM.Enabled = False
            '        txtbx_RcpEditFlush2Flow.Enabled = True
            '        txtbx_RcpEditFlush2FlowTol.Enabled = True
            '    Case 1
            '        txtbx_RcpEditFlush2RPM.Enabled = True
            '        txtbx_RcpEditFlush2RPM.Enabled = True
            '        txtbx_RcpEditFlush2Flow.Enabled = False
            '        txtbx_RcpEditFlush2FlowTol.Enabled = False
            'End Select
            panel_RcpEditFlush2PumpMode.Enabled = True
            If rdbtn_RcpEditFlush2PumpSpeed.Checked Then
                txtbx_RcpEditFlush2RPM.Enabled = True
            Else
                txtbx_RcpEditFlush2RPM.Enabled = False
            End If
        End If

        If checkbx_EditDrain1.Checked = True Then
            txtbx_RcpEditDrain1Pressure.Enabled = True
            txtbx_RcpEditDrain1Time.Enabled = True
        End If

        If checkbx_EditDrain2.Checked = True Then
            txtbx_RcpEditDrain2Pressure.Enabled = True
            txtbx_RcpEditDrain2Time.Enabled = True
        End If

        If checkbx_EditDrain3.Checked = True Then
            txtbx_RcpEditDrain3Pressure.Enabled = True
            txtbx_RcpEditDrain3Time.Enabled = True
        End If

        If checkbx_EditDrain4.Checked = True Then
            txtbx_RcpEditDrain4Pressure.Enabled = True
            txtbx_RcpEditDrain4Time.Enabled = True
        End If

        checkbx_EditFlush1.Enabled = True
        checkbx_EditFlush2.Enabled = True
        checkbx_EditDPTest1.Enabled = True

        checkbx_EditDrain1.Enabled = True
        checkbx_EditDrain2.Enabled = True
        checkbx_EditDrain3.Enabled = True
        checkbx_EditDrain4.Enabled = True
        btn_RcpEditSave.Enabled = True

        TextBox3.Enabled = True
        txtbx_RcpEditDuration_TextChanged(Nothing, Nothing)
    End Sub

    'Public Sub LoadRecipeParameters(parameterarr As String())

    '    d_vertol = CType(parameterarr(8), Decimal)

    '    i_flush1filltime = CType(parameterarr(10), Integer)
    '    i_flush1bleedtime = CType(parameterarr(11), Integer)
    '    d_flush1flow = CType(parameterarr(12), Decimal)
    '    d_flush1flowtol = CType(parameterarr(13), Decimal)
    '    d_flush1pressure = CType(parameterarr(14), Decimal)
    '    i_flush1stabilize = CType(parameterarr(15), Integer)
    '    i_flush1time = CType(parameterarr(16), Integer)

    '    i_dptestfilltime = CType(parameterarr(18), Integer)
    '    i_dptestbleedtime = CType(parameterarr(19), Integer)
    '    d_dptestflow = CType(parameterarr(20), Decimal)
    '    d_dptestflowtol = CType(parameterarr(21), Decimal)
    '    d_dptestpressure = CType(parameterarr(22), Decimal)
    '    i_dpteststabilize = CType(parameterarr(23), Integer)
    '    i_dptesttime = CType(parameterarr(24), Integer)
    '    d_dptestlowlimit = CType(parameterarr(25), Decimal)
    '    d_dptestuplimit = CType(parameterarr(26), Decimal)
    '    i_dptestpoints = CType(parameterarr(27), Integer)

    '    i_flush2filltime = CType(parameterarr(30), Integer)
    '    i_flush2bleedtime = CType(parameterarr(31), Integer)
    '    d_flush2flow = CType(parameterarr(32), Decimal)
    '    d_flush2flowtol = CType(parameterarr(33), Decimal)
    '    d_flush2pressure = CType(parameterarr(34), Decimal)
    '    i_flush2stabilize = CType(parameterarr(35), Integer)
    '    i_flush2time = CType(parameterarr(36), Integer)



    '    d_drain1pressure = CType(parameterarr(38), Decimal)
    '    i_drain1time = CType(parameterarr(39), Integer)

    '    d_drain2pressure = CType(parameterarr(41), Decimal)
    '    i_drain2time = CType(parameterarr(42), Integer)

    '    d_drain3pressure = CType(parameterarr(44), Decimal)
    '    i_drain3time = CType(parameterarr(45), Integer)


    '    txtbx_RcpEditVerTol.Text = CType(d_vertol, String)




    '    If parameterarr(9) = "Enable" Then
    '        checkbx_EditFlush1.Checked = True
    '        txtbx_RcpEditFlush1Fill.Text = CType(i_flush1filltime, String)
    '        txtbx_RcpEditFlush1Bleed.Text = CType(i_flush1bleedtime, String)
    '        txtbx_RcpEditFlush1Flow.Text = CType(d_flush1flow, String)
    '        txtbx_RcpEditFlush1FlowTol.Text = CType(d_flush1flowtol, String)
    '        txtbx_RcpEditFlush1Pressure.Text = CType(d_flush1pressure, String)
    '        txtbx_RcpEditFlush1Stabilize.Text = CType(i_flush1stabilize, String)
    '        txtbx_RcpEditFlush1Time.Text = CType(i_flush1time, String)
    '    Else
    '        checkbx_EditFlush1.Checked = False
    '    End If

    '    If parameterarr(17) = "Enable" Then
    '        checkbx_EditDPTest1.Checked = True
    '        txtbx_RcpEditDPFill.Text = CType(i_dptestfilltime, String)
    '        txtbx_RcpEditDPBleed.Text = CType(i_dptestbleedtime, String)
    '        txtbx_RcpEditDPFlow.Text = CType(d_dptestflow, String)
    '        txtbx_RcpEditDPFlowTol.Text = CType(d_dptestflowtol, String)
    '        txtbx_RcpEditDPPressure.Text = CType(d_dptestpressure, String)
    '        txtbx_RcpEditDPStabilize.Text = CType(i_dpteststabilize, String)
    '        txtbx_RcpEditDPTime.Text = CType(i_dptesttime, String)
    '        txtbx_RcpEditDPLowLimit.Text = CType(d_dptestlowlimit, String)
    '        txtbx_RcpEditDPUpLimit.Text = CType(d_dptestuplimit, String)
    '        txtbx_RcpEditDPPoints.Text = CType(i_dptestpoints, String)
    '    Else
    '        checkbx_EditDPTest1.Checked = False
    '    End If

    '    If parameterarr(28) = "Enable" Then
    '        checkbx_EditDPTest2.Checked = True

    '    Else
    '        checkbx_EditDPTest2.Checked = False
    '    End If

    '    If parameterarr(29) = "Enable" Then
    '        checkbx_EditFlush2.Checked = True
    '        txtbx_RcpEditFlush2Fill.Text = CType(i_flush2filltime, String)
    '        txtbx_RcpEditFlush2Bleed.Text = CType(i_flush2bleedtime, String)
    '        txtbx_RcpEditFlush2Flow.Text = CType(d_flush2flow, String)
    '        txtbx_RcpEditFlush2FlowTol.Text = CType(d_flush2flowtol, String)
    '        txtbx_RcpEditFlush2Pressure.Text = CType(d_flush2pressure, String)
    '        txtbx_RcpEditFlush2Stabilize.Text = CType(i_flush2stabilize, String)
    '        txtbx_RcpEditFlush2Time.Text = CType(i_flush2time, String)

    '    Else
    '        checkbx_EditFlush2.Checked = False
    '    End If



    '    If parameterarr(37) = "Enable" Then
    '        checkbx_EditDrain1.Checked = True
    '        txtbx_RcpEditDrain1Pressure.Text = CType(d_drain1pressure, String)
    '        txtbx_RcpEditDrain1Time.Text = CType(i_drain1time, String)
    '    Else
    '        checkbx_EditDrain1.Checked = False
    '    End If

    '    If parameterarr(40) = "Enable" Then
    '        checkbx_EditDrain2.Checked = True
    '        txtbx_RcpEditDrain2Pressure.Text = CType(d_drain2pressure, String)
    '        txtbx_RcpEditDrain2Time.Text = CType(i_drain2time, String)
    '    Else
    '        checkbx_EditDrain2.Checked = False
    '    End If

    '    If parameterarr(43) = "Enable" Then
    '        checkbx_EditDrain3.Checked = True
    '        txtbx_RcpEditDrain3Pressure.Text = CType(d_drain3pressure, String)
    '        txtbx_RcpEditDrain3Time.Text = CType(i_drain3time, String)
    '    Else
    '        checkbx_EditDrain3.Checked = False
    '    End If

    'End Sub

    Public Sub LoadRecipeParameters(dtRecipe As DataTable)
        d_vertol = CType(dtRecipe(0)("verification_tolerance"), Decimal)

        i_prepfilltime = CType(dtRecipe(0)("prep_fill_time"), Decimal)
        i_prepbleedtime = CType(dtRecipe(0)("prep_bleed_time"), Decimal)
        'd_prepflow = CType(dtRecipe(0)("prep_flowrate"), Decimal)
        'd_prepflowtol = CType(dtRecipe(0)("prep_flow_tolerance"), Decimal)
        If Not IsDBNull(dtRecipe(0)("prep_pressure_drop")) Then
            d_preppressuredrop = CType(dtRecipe(0)("prep_pressure_drop"), Decimal)
        Else
            d_preppressuredrop = 0
        End If
        If Not IsDBNull(dtRecipe(0)("prep_pressure_drop_time")) Then
            i_preppressuredroptime = CType(dtRecipe(0)("prep_pressure_drop_time"), Decimal)
        Else
            i_preppressuredroptime = 0
        End If
        If Not IsDBNull(dtRecipe(0)("prep_back_pressure")) Then
            d_preppressure = CType(dtRecipe(0)("prep_back_pressure"), Decimal)
        Else
            d_preppressure = 0
        End If
        If Not IsDBNull(dtRecipe(0)("prep_prefill_start_time")) Then
            i_prepprefillstarttime = CType(dtRecipe(0)("prep_prefill_start_time"), Decimal)
        Else
            i_prepprefillstarttime = 0
        End If
        If Not IsDBNull(dtRecipe(0)("prep_prefill_time")) Then
            i_prepprefilltime = CType(dtRecipe(0)("prep_prefill_time"), Decimal)
        Else
            i_prepprefilltime = 0
        End If
        If Not IsDBNull(dtRecipe(0)("prep_drain_start_time")) Then
            i_prepdrainstarttime = CType(dtRecipe(0)("prep_drain_start_time"), Decimal)
        Else
            i_prepdrainstarttime = 0
        End If
        If Not IsDBNull(dtRecipe(0)("prep_drain_time")) Then
            i_prepdraintime = CType(dtRecipe(0)("prep_drain_time"), Decimal)
        Else
            i_prepdraintime = 0
        End If
        If Not IsDBNull(dtRecipe(0)("prep_rpm1")) Then
            i_preprpm1 = CType(dtRecipe(0)("prep_rpm1"), Integer)
        Else
            i_preprpm1 = 0
        End If
        'If Not IsDBNull(dtRecipe(0)("prep_rpm2")) Then
        '    i_preprpm2 = CType(dtRecipe(0)("prep_rpm2"), Integer)
        'Else
        '    i_preprpm2 = 0
        'End If

        'i_flush1filltime = CType(dtRecipe(0)("firstflush_fill_time"), Integer)
        'i_flush1bleedtime = CType(dtRecipe(0)("firstflush_bleed_time"), Integer)
        d_flush1flow = CType(dtRecipe(0)("firstflush_flowrate"), Decimal)
        d_flush1flowtol = CType(dtRecipe(0)("firstflush_flow_tolerance"), Decimal)
        If Not IsDBNull(dtRecipe(0)("firstflush_back_pressure")) Then
            d_flush1pressure = CType(dtRecipe(0)("firstflush_back_pressure"), Decimal)
        Else
            d_flush1pressure = 0
        End If
        i_flush1stabilize = CType(dtRecipe(0)("firstflush_stabilize_time"), Integer)
        i_flush1time = CType(dtRecipe(0)("firstflush_time"), Integer)
        If Not IsDBNull(dtRecipe(0)("firstflush_rpm")) Then
            i_flush1rpm = CType(dtRecipe(0)("firstflush_rpm"), Integer)
        Else
            i_flush1rpm = 0
        End If

        'i_dptestfilltime = CType(dtRecipe(0)("dp_fill_time"), Integer)
        'i_dptestbleedtime = CType(dtRecipe(0)("dp_bleed_time"), Integer)

        If Not IsDBNull(dtRecipe(0)("dp_flowrate")) Then
            d_dptestflow = CType(dtRecipe(0)("dp_flowrate"), Decimal)
        Else
            d_dptestflow = 0
        End If
        If Not IsDBNull(dtRecipe(0)("dp_flow_tolerance")) Then
            d_dptestflowtol = CType(dtRecipe(0)("dp_flow_tolerance"), Decimal)
        Else
            d_dptestflowtol = 0
        End If
        If Not IsDBNull(dtRecipe(0)("dp_back_pressure")) Then
            d_dptestpressure = CType(dtRecipe(0)("dp_back_pressure"), Decimal)
        Else
            d_dptestpressure = 0
        End If

        i_dpteststabilize = CType(dtRecipe(0)("dp_stabilize_time"), Integer)
        i_dptesttime = CType(dtRecipe(0)("dp_test_time"), Integer)
        d_dptestlowlimit = CType(dtRecipe(0)("dp_lowerlimit"), Decimal)
        d_dptestuplimit = CType(dtRecipe(0)("dp_upperlimit"), Decimal)
        i_dptestpoints = CType(dtRecipe(0)("dp_testpoints"), Integer)
        If Not IsDBNull(dtRecipe(0)("dp_rpm")) Then
            i_dptestrpm = CType(dtRecipe(0)("dp_rpm"), Integer)
        Else
            i_dptestrpm = 0
        End If

        'i_flush2filltime = CType(dtRecipe(0)("secondflush_fill_time"), Integer)
        'i_flush2bleedtime = CType(dtRecipe(0)("secondflush_bleed_time"), Integer)
        d_flush2flow = CType(dtRecipe(0)("secondflush_flowrate"), Decimal)
        d_flush2flowtol = CType(dtRecipe(0)("secondflush_flow_tolerance"), Decimal)
        If Not IsDBNull(dtRecipe(0)("secondflush_back_pressure")) Then
            d_flush2pressure = CType(dtRecipe(0)("secondflush_back_pressure"), Decimal)
        Else
            d_flush2pressure = 0
        End If
        i_flush2stabilize = CType(dtRecipe(0)("secondflush_stabilize_time"), Integer)
        i_flush2time = CType(dtRecipe(0)("secondflush_time"), Integer)
        If Not IsDBNull(dtRecipe(0)("secondflush_rpm")) Then
            i_flush2rpm = CType(dtRecipe(0)("secondflush_rpm"), Integer)
        Else
            i_flush2rpm = 0
        End If

        d_drain1pressure = CType(dtRecipe(0)("drain1_back_pressure"), Decimal)
        i_drain1time = CType(dtRecipe(0)("drain1_time"), Integer)

        d_drain2pressure = CType(dtRecipe(0)("drain2_back_pressure"), Decimal)
        i_drain2time = CType(dtRecipe(0)("drain2_time"), Integer)

        d_drain3pressure = CType(dtRecipe(0)("drain3_back_pressure"), Decimal)
        i_drain3time = CType(dtRecipe(0)("drain3_time"), Integer)

        d_drain4pressure = CType(dtRecipe(0)("drain4_back_pressure"), Decimal)
        i_drain4time = CType(dtRecipe(0)("drain4_time"), Integer)

        txtbx_RcpEditVerTol.Text = CType(d_vertol, String)

        'If Not IsDBNull(dtRecipe(0)("prep_speed_mode")) Then
        '    Select Case CStr(dtRecipe(0)("prep_speed_mode")).ToUpper
        '        Case "ENABLE"
        '            rdbtn_RcpEditPrepPumpSpeed.Checked = True
        '        Case "DISABLE"
        '            rdbtn_RcpEditPrepPumpProcess.Checked = True
        '    End Select
        'Else
        '    rdbtn_RcpEditPrepPumpProcess.Checked = True
        'End If
        rdbtn_RcpEditPrepPumpSpeed.Checked = True

        If Not IsDBNull(dtRecipe(0)("fitting_inlet")) Then
            ComboBox9.SelectedIndex = ComboBox9.FindStringExact(dtRecipe(0)("fitting_inlet"))
        End If
        If Not IsDBNull(dtRecipe(0)("fitting_outlet")) Then
            ComboBox8.SelectedIndex = ComboBox8.FindStringExact(dtRecipe(0)("fitting_outlet"))
        End If
        If Not IsDBNull(dtRecipe(0)("fitting_blank")) Then
            ComboBox7.SelectedIndex = ComboBox7.FindStringExact(dtRecipe(0)("fitting_blank"))
        End If

        txtbx_RcpEditPrepFill.Text = CType(i_prepfilltime, String)
        txtbx_RcpEditPrepBleed.Text = CType(i_prepbleedtime, String)
        'txtbx_RcpEditPrepFlow.Text = d_prepflow.ToString("F1") 'CType(d_prepflow, String)
        'txtbx_RcpEditPrepFlowTol.Text = d_prepflowtol.ToString("F1") 'CType(d_prepflowtol, String)
        txtbx_RcpEditPrepPressureDrop.Text = d_preppressuredrop.ToString("F1") 'CType(d_preppressuredrop, String)
        txtbx_RcpEditPrepPressureDropTime.Text = CType(i_preppressuredroptime, String)
        txtbx_RcpEditPrepPressure.Text = d_preppressure.ToString("F1") 'CType(d_preppressure, String)
        txtbx_RcpEditPrepPrefillStartTime.Text = CType(i_prepprefillstarttime, String)
        txtbx_RcpEditPrepPrefillTime.Text = CType(i_prepprefilltime, String)
        txtbx_RcpEditPrepDrainStartTime.Text = CType(i_prepdrainstarttime, String)
        txtbx_RcpEditPrepDrainTime.Text = CType(i_prepdraintime, String)

        If rdbtn_RcpEditPrepPumpSpeed.Checked = True Then
            txtbx_RcpEditPrepRPM.Text = CType(i_preprpm1, String)
        End If

        'txtbx_RcpEditPrepRPM2.Text = CType(i_preprpm2, String)

        If dtRecipe(0)("firstflush_circuit") = "Enable" Then
            checkbx_EditFlush1.Checked = True
            'txtbx_RcpEditFlush1Fill.Text = CType(i_flush1filltime, String)
            'txtbx_RcpEditFlush1Bleed.Text = CType(i_flush1bleedtime, String)
            txtbx_RcpEditFlush1Flow.Text = d_flush1flow.ToString("F1") 'CType(d_flush1flow, String)
            txtbx_RcpEditFlush1FlowTol.Text = d_flush1flowtol.ToString("F1") 'CType(d_flush1flowtol, String)
            txtbx_RcpEditFlush1Pressure.Text = d_flush1pressure.ToString("F1") 'CType(d_flush1pressure, String)
            txtbx_RcpEditFlush1Stabilize.Text = CType(i_flush1stabilize, String)
            txtbx_RcpEditFlush1Time.Text = CType(i_flush1time, String)

            If Not IsDBNull(dtRecipe(0)("firstflush_speed_mode")) Then
                Select Case CStr(dtRecipe(0)("firstflush_speed_mode")).ToUpper
                    Case "ENABLE"
                        rdbtn_RcpEditFlush1PumpSpeed.Checked = True
                    Case "DISABLE"
                        rdbtn_RcpEditFlush1PumpProcess.Checked = True
                End Select
            Else
                rdbtn_RcpEditFlush1PumpProcess.Checked = True
            End If

            If rdbtn_RcpEditFlush1PumpSpeed.Checked = True Then
                txtbx_RcpEditFlush1RPM.Text = CType(i_flush1rpm, String)
            End If
        Else
            checkbx_EditFlush1.Checked = False
        End If

        If dtRecipe(0)("firstdp_circuit") = "Enable" Then
            checkbx_EditDPTest1.Checked = True
            'txtbx_RcpEditDPFill.Text = CType(i_dptestfilltime, String)
            'txtbx_RcpEditDPBleed.Text = CType(i_dptestbleedtime, String)
            txtbx_RcpEditDPFlow.Text = d_dptestflow.ToString("F1") 'CType(d_dptestflow, String)
            txtbx_RcpEditDPFlowTol.Text = d_dptestflowtol.ToString("F1") 'CType(d_dptestflowtol, String)
            txtbx_RcpEditDPPressure.Text = d_dptestpressure.ToString("F1") 'CType(d_dptestpressure, String)
            txtbx_RcpEditDPStabilize.Text = CType(i_dpteststabilize, String)
            txtbx_RcpEditDPTime.Text = CType(i_dptesttime, String)
            txtbx_RcpEditDPLowLimit.Text = d_dptestlowlimit.ToString("F1") 'CType(d_dptestlowlimit, String)
            txtbx_RcpEditDPUpLimit.Text = d_dptestuplimit.ToString("F1") 'CType(d_dptestuplimit, String)
            txtbx_RcpEditDPPoints.Text = CType(i_dptestpoints, String)

            'If Not IsDBNull(dtRecipe(0)("dp_speed_mode")) Then
            '    Select Case CStr(dtRecipe(0)("dp_speed_mode")).ToUpper
            '        Case "ENABLE"
            '            rdbtn_RcpEditDPTestPumpSpeed.Checked = True
            '        Case "DISABLE"
            '            rdbtn_RcpEditDPTestPumpProcess.Checked = True
            '    End Select
            'Else
            '    rdbtn_RcpEditDPTestPumpProcess.Checked = True
            'End If
            rdbtn_RcpEditDPTestPumpProcess.Checked = True

            If rdbtn_RcpEditDPTestPumpSpeed.Checked = True Then
                txtbx_RcpEditDPTestRPM.Text = CType(i_dptestrpm, String)
            End If
        Else
            checkbx_EditDPTest1.Checked = False
        End If

        If dtRecipe(0)("seconddp_circuit") = "Enable" Then
            checkbx_EditDPTest2.Checked = True

        Else
            checkbx_EditDPTest2.Checked = False
        End If

        If dtRecipe(0)("secondflush_circuit") = "Enable" Then
            checkbx_EditFlush2.Checked = True
            'txtbx_RcpEditFlush2Fill.Text = CType(i_flush2filltime, String)
            'txtbx_RcpEditFlush2Bleed.Text = CType(i_flush2bleedtime, String)
            txtbx_RcpEditFlush2Flow.Text = d_flush2flow.ToString("F1") 'CType(d_flush2flow, String)
            txtbx_RcpEditFlush2FlowTol.Text = d_flush2flowtol.ToString("F1") 'CType(d_flush2flowtol, String)
            txtbx_RcpEditFlush2Pressure.Text = d_flush2pressure.ToString("F1") 'CType(d_flush2pressure, String)
            txtbx_RcpEditFlush2Stabilize.Text = CType(i_flush2stabilize, String)
            txtbx_RcpEditFlush2Time.Text = CType(i_flush2time, String)

            If Not IsDBNull(dtRecipe(0)("secondflush_speed_mode")) Then
                Select Case CStr(dtRecipe(0)("secondflush_speed_mode")).ToUpper
                    Case "ENABLE"
                        rdbtn_RcpEditFlush2PumpSpeed.Checked = True
                    Case "DISABLE"
                        rdbtn_RcpEditFlush2PumpProcess.Checked = True
                End Select
            Else
                rdbtn_RcpEditFlush2PumpProcess.Checked = True
            End If

            If rdbtn_RcpEditFlush2PumpSpeed.Checked = True Then
                txtbx_RcpEditFlush2RPM.Text = CType(i_flush2rpm, String)
            End If
        Else
            checkbx_EditFlush2.Checked = False
        End If

        If dtRecipe(0)("drain1_circuit") = "Enable" Then
            checkbx_EditDrain1.Checked = True
            txtbx_RcpEditDrain1Pressure.Text = d_drain1pressure.ToString("F1") 'CType(d_drain1pressure, String)
            txtbx_RcpEditDrain1Time.Text = CType(i_drain1time, String)
        Else
            checkbx_EditDrain1.Checked = False
        End If

        If dtRecipe(0)("drain2_circuit") = "Enable" Then
            checkbx_EditDrain2.Checked = True
            txtbx_RcpEditDrain2Pressure.Text = d_drain2pressure.ToString("F1") 'CType(d_drain2pressure, String)
            txtbx_RcpEditDrain2Time.Text = CType(i_drain2time, String)
        Else
            checkbx_EditDrain2.Checked = False
        End If

        If dtRecipe(0)("drain3_circuit") = "Enable" Then
            checkbx_EditDrain3.Checked = True
            txtbx_RcpEditDrain3Pressure.Text = d_drain3pressure.ToString("F1") 'CType(d_drain3pressure, String)
            txtbx_RcpEditDrain3Time.Text = CType(i_drain3time, String)
        Else
            checkbx_EditDrain3.Checked = False
        End If

        If dtRecipe(0)("drain4_circuit") = "Enable" Then
            checkbx_EditDrain4.Checked = True
            txtbx_RcpEditDrain4Pressure.Text = d_drain4pressure.ToString("F1") 'CType(d_drain4pressure, String)
            txtbx_RcpEditDrain4Time.Text = CType(i_drain4time, String)
        Else
            checkbx_EditDrain4.Checked = False
        End If
    End Sub

    Private Sub cmbx_RcpEditRecipeID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_RcpEditRecipeID.SelectedIndexChanged
        If cmbx_RcpEditRecipeID.SelectedIndex > 0 Then
            Dim RecipeID As String = cmbx_RcpEditRecipeID.Text
            Dim PartID As String = cmbx_RcpEditPartID.Text

            cmbx_RcpDupSelRecipe.Text = RecipeID
            Cmbx_RcpDupNewPartID.Text = PartID

            'Dim dtEditrecipe As DataTable = SQL.ReadRecords("SELECT * FROM RecipeTable WHERE recipe_id = '" + RecipeID + "'")
            Dim dtEditrecipe As DataTable = SQL.ReadRecords("SELECT * FROM RecipeTable WHERE id = '" + DirectCast(cmbx_RcpEditRecipeID.SelectedItem, KeyValuePair(Of String, String)).Key + "'")

            'If dtEditrecipe.Rows.Count > 0 Then
            '    For i As Integer = 0 To dtEditrecipe.Columns.Count - 1
            '        recipeparameter(i) = dtEditrecipe.Rows(0).Item(i)
            '    Next
            'End If
            'LoadRecipeParameters(recipeparameter)
            dtEditrecipetemp = New DataTable
            If dtEditrecipe.Rows.Count > 0 Then
                dtEditrecipetemp = dtEditrecipe.Copy
                LoadRecipeParameters(dtEditrecipe)
                btn_RcpEdit.Enabled = True
            End If
        Else
            txtbx_RcpEditVerTol.Enabled = False
            txtbx_RcpEditDPFlow.Enabled = False
            txtbx_RcpEditDPFlowTol.Enabled = False

            'ComboBox9.Enabled = False
            'ComboBox8.Enabled = False
            'ComboBox7.Enabled = False

            txtbx_RcpEditPrepFill.Enabled = False
            txtbx_RcpEditPrepPrefillStartTime.Enabled = False
            txtbx_RcpEditPrepPrefillTime.Enabled = False
            txtbx_RcpEditPrepDrainStartTime.Enabled = False
            txtbx_RcpEditPrepDrainTime.Enabled = False
            txtbx_RcpEditPrepBleed.Enabled = False
            txtbx_RcpEditPrepPressureDrop.Enabled = False
            txtbx_RcpEditPrepPressureDropTime.Enabled = False
            txtbx_RcpEditPrepPressure.Enabled = False
            panel_RcpEditPrepPumpMode.Enabled = False
            txtbx_RcpEditPrepRPM.Enabled = False

            txtbx_RcpEditFlush1Flow.Enabled = False
            txtbx_RcpEditFlush1FlowTol.Enabled = False
            txtbx_RcpEditFlush1Stabilize.Enabled = False
            txtbx_RcpEditFlush1Time.Enabled = False
            txtbx_RcpEditFlush1Pressure.Enabled = False
            panel_RcpEditFlush1PumpMode.Enabled = False
            txtbx_RcpEditFlush1RPM.Enabled = False

            txtbx_RcpEditFlush2Flow.Enabled = False
            txtbx_RcpEditFlush2FlowTol.Enabled = False
            txtbx_RcpEditFlush2Stabilize.Enabled = False
            txtbx_RcpEditFlush2Time.Enabled = False
            txtbx_RcpEditFlush2Pressure.Enabled = False
            panel_RcpEditFlush2PumpMode.Enabled = False
            txtbx_RcpEditFlush2RPM.Enabled = False

            txtbx_RcpEditDPStabilize.Enabled = False
            txtbx_RcpEditDPTime.Enabled = False
            txtbx_RcpEditDPPressure.Enabled = False
            txtbx_RcpEditDPLowLimit.Enabled = False
            txtbx_RcpEditDPUpLimit.Enabled = False
            txtbx_RcpEditDPPoints.Enabled = False
            panel_RcpEditDPTestPumpMode.Enabled = False
            txtbx_RcpEditDPTestRPM.Enabled = False

            txtbx_RcpEditDrain1Pressure.Enabled = False
            txtbx_RcpEditDrain1Time.Enabled = False

            txtbx_RcpEditDrain2Pressure.Enabled = False
            txtbx_RcpEditDrain2Time.Enabled = False

            txtbx_RcpEditDrain3Pressure.Enabled = False
            txtbx_RcpEditDrain3Time.Enabled = False

            txtbx_RcpEditDrain4Pressure.Enabled = False
            txtbx_RcpEditDrain4Time.Enabled = False

            checkbx_EditFlush1.Enabled = False
            checkbx_EditFlush2.Enabled = False
            checkbx_EditDPTest1.Enabled = False
            checkbx_EditDPTest2.Enabled = False
            checkbx_EditDrain1.Enabled = False
            checkbx_EditDrain2.Enabled = False
            checkbx_EditDrain3.Enabled = False
            checkbx_EditDrain4.Enabled = False

            txtbx_RcpEditVerTol.Text = Nothing
            txtbx_RcpEditDPFlow.Text = Nothing
            txtbx_RcpEditDPFlowTol.Text = Nothing

            txtbx_RcpEditPrepFill.Text = Nothing
            txtbx_RcpEditPrepPrefillStartTime.Text = Nothing
            txtbx_RcpEditPrepPrefillTime.Text = Nothing
            txtbx_RcpEditPrepDrainStartTime.Text = Nothing
            txtbx_RcpEditPrepDrainTime.Text = Nothing
            txtbx_RcpEditPrepBleed.Text = Nothing
            txtbx_RcpEditPrepPressureDrop.Text = Nothing
            txtbx_RcpEditPrepPressureDropTime.Text = Nothing
            txtbx_RcpEditPrepPressure.Text = Nothing
            rdbtn_RcpEditPrepPumpSpeed.Checked = True
            txtbx_RcpEditPrepRPM.Enabled = False
            txtbx_RcpEditPrepRPM.Text = Nothing

            txtbx_RcpEditFlush1Flow.Text = Nothing
            txtbx_RcpEditFlush1FlowTol.Text = Nothing
            txtbx_RcpEditFlush1Stabilize.Text = Nothing
            txtbx_RcpEditFlush1Time.Text = Nothing
            txtbx_RcpEditFlush1Pressure.Text = Nothing
            rdbtn_RcpEditFlush1PumpProcess.Checked = True
            txtbx_RcpEditFlush1RPM.Text = Nothing

            txtbx_RcpEditFlush2Flow.Text = Nothing
            txtbx_RcpEditFlush2FlowTol.Text = Nothing
            txtbx_RcpEditFlush2Stabilize.Text = Nothing
            txtbx_RcpEditFlush2Time.Text = Nothing
            txtbx_RcpEditFlush2Pressure.Text = Nothing
            rdbtn_RcpEditFlush2PumpProcess.Checked = True
            txtbx_RcpEditFlush2RPM.Text = Nothing

            txtbx_RcpEditDPStabilize.Text = Nothing
            txtbx_RcpEditDPTime.Text = Nothing
            txtbx_RcpEditDPPressure.Text = Nothing
            txtbx_RcpEditDPLowLimit.Text = Nothing
            txtbx_RcpEditDPUpLimit.Text = Nothing
            txtbx_RcpEditDPPoints.Text = Nothing
            rdbtn_RcpEditDPTestPumpSpeed.Checked = True
            txtbx_RcpEditDPTestRPM.Text = Nothing

            txtbx_RcpEditDrain1Pressure.Text = Nothing
            txtbx_RcpEditDrain1Time.Text = Nothing

            txtbx_RcpEditDrain2Pressure.Text = Nothing
            txtbx_RcpEditDrain2Time.Text = Nothing

            txtbx_RcpEditDrain3Pressure.Text = Nothing
            txtbx_RcpEditDrain3Time.Text = Nothing

            txtbx_RcpEditDrain4Pressure.Text = Nothing
            txtbx_RcpEditDrain4Time.Text = Nothing

            checkbx_EditFlush1.Checked = False
            checkbx_EditFlush2.Checked = False
            checkbx_EditDPTest1.Checked = False
            checkbx_EditDPTest2.Checked = False
            checkbx_EditDrain1.Checked = False
            checkbx_EditDrain2.Checked = False
            checkbx_EditDrain3.Checked = False
            checkbx_EditDrain4.Checked = False

            btn_RcpEdit.Enabled = False
            btn_RcpEditSave.Enabled = False

            TextBox3.Enabled = False
        End If
    End Sub

    Private Sub btn_EditDiscard_Click(sender As Object, e As EventArgs) Handles btn_EditDiscard.Click
        Dim RecipeIDTemp As String = cmbx_RcpEditRecipeID.Text

        cmbx_RcpEditRecipeID.SelectedIndex = 0
        cmbx_RcpEditRecipeID.Text = RecipeIDTemp
    End Sub

    Private Sub btn_RcpEditSave_Click(sender As Object, e As EventArgs) Handles btn_RcpEditSave.Click
        Dim RecipeID As String = cmbx_RcpEditRecipeID.Text
        Dim PartIDTmp As String = cmbx_RcpEditPartID.Text
        Dim FilterTypeTmp As String = cmbx_RcpEditFilterType.Text

        Dim onContinue As Boolean = True
        Dim dtrecipeidcheck As DataTable = SQL.ReadRecords("select * from RecipeTable where recipe_id = '" + RecipeID + "' order by recipe_rev desc")

        ''Check Pump Mode has something selected
        'If onContinue = True Then
        '    If cmbx_RcpEditPrepPumpMode.SelectedIndex < 0 Then
        '        MsgBox("Preparation - No Pump Mode Selected", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
        '        onContinue = False
        '    Else
        '        Select Case cmbx_RcpEditPrepPumpMode.SelectedIndex
        '            Case 0
        '                str_prepspeedenable = "Disable"
        '            Case 1
        '                str_prepspeedenable = "Enable"
        '        End Select
        '    End If
        'End If
        If rdbtn_RcpEditPrepPumpSpeed.Checked Then
            str_prepspeedenable = "Enable"
        Else
            str_prepspeedenable = "Disable"
        End If
        If rdbtn_RcpEditFlush1PumpSpeed.Checked Then
            str_flush1speedenable = "Enable"
        Else
            str_flush1speedenable = "Disable"
        End If
        If rdbtn_RcpEditFlush2PumpSpeed.Checked Then
            str_flush2speedenable = "Enable"
        Else
            str_flush2speedenable = "Disable"
        End If
        If rdbtn_RcpEditDPTestPumpSpeed.Checked Then
            str_dptestspeedenable = "Enable"
        Else
            str_dptestspeedenable = "Disable"
        End If

#Region "Recipe Edit Parameter Range Validating Event"
        If onContinue = True Then
            'Check verification tolerance

            'Check the text is empty or has only decimal point
            If Not txtbx_RcpEditVerTol.Text = "" And Not txtbx_RcpEditVerTol.Text = "." Then
                'Convert to the required type
                d_vertol = CType(txtbx_RcpEditVerTol.Text, Decimal)
                'Check the value within range
                If d_vertol < min_d_vertol Or d_vertol > max_d_vertol Then
                    RecipeMessage(20, "Verification tolerance should be within " + CType(min_d_vertol, String) + " to " + CType(max_d_vertol, String))
                    txtbx_RcpEditVerTol.Text = Nothing
                    txtbx_RcpEditVerTol.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Verification tolerance")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check fill time 

            'Check the text is empty
            If Not txtbx_RcpEditPrepFill.Text = "" Then
                'Convert to the required type
                i_prepfilltime = CType(txtbx_RcpEditPrepFill.Text, Integer)
                'Check the value within range
                If i_prepfilltime < min_i_prepfilltime Or i_prepfilltime > max_i_prepfilltime Then
                    RecipeMessage(20, "Preparation Fill Time should be within " + CType(min_i_prepfilltime, String) + " to " + CType(max_i_prepfilltime, String))
                    txtbx_RcpEditPrepFill.Text = Nothing
                    txtbx_RcpEditPrepFill.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Fill Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Bleed time 

            'Check the text is empty
            If Not txtbx_RcpEditPrepBleed.Text = "" Then
                'Convert to the required type
                i_prepbleedtime = CType(txtbx_RcpEditPrepBleed.Text, Integer)
                'Check the value within range
                If i_prepbleedtime < min_i_prepbleedtime Or i_prepbleedtime > max_i_prepbleedtime Then
                    RecipeMessage(20, "Preparation Bleed Time should be within " + CType(min_i_prepbleedtime, String) + " to " + CType(max_i_prepbleedtime, String))
                    txtbx_RcpEditPrepBleed.Text = Nothing
                    txtbx_RcpEditPrepBleed.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Bleed Time")
                onContinue = False
            End If
        End If

        'If onContinue = True Then
        '    'Check for Flowrate
        '    'Check the text is empty or has only decimal point
        '    If Not txtbx_RcpEditPrepFlow.Text = "" And Not txtbx_RcpEditPrepFlow.Text = "." Then
        '        'Convert to the required type
        '        d_prepflow = CType(txtbx_RcpEditPrepFlow.Text, Decimal)
        '        'Check the value within range
        '        If d_prepflow < min_d_prepflow Or d_prepflow > max_d_prepflow Then
        '            RecipeMessage(20, "Preparation Flowrate should be within " + CType(min_d_prepflow, String) + " to " + CType(max_d_prepflow, String))
        '            txtbx_RcpEditPrepFlow.Text = Nothing
        '            txtbx_RcpEditPrepFlow.Focus()
        '            onContinue = False
        '        End If
        '    Else
        '        RecipeMessage(19, "Preparation Flowrate")
        '        onContinue = False
        '    End If
        'End If

        'If onContinue = True Then
        '    'Check for Flowrate Tolerance
        '    'Check the text is empty or has only decimal point
        '    If Not txtbx_RcpEditPrepFlowTol.Text = "" And Not txtbx_RcpEditPrepFlowTol.Text = "." Then
        '        'Convert to the required type
        '        d_prepflowtol = CType(txtbx_RcpEditPrepFlowTol.Text, Decimal)
        '        'Check the value within range
        '        If d_prepflowtol < min_d_prepflowtol Or d_prepflowtol > max_d_prepflowtol Then
        '            RecipeMessage(20, "Preparation Flowrate Tolerance should be within " + CType(min_d_prepflowtol, String) + " to " + CType(max_d_prepflowtol, String))
        '            txtbx_RcpEditPrepFlowTol.Text = Nothing
        '            txtbx_RcpEditPrepFlowTol.Focus()
        '            onContinue = False
        '        End If
        '    Else
        '        RecipeMessage(19, "Preparation Flowrate Tolerance")
        '        onContinue = False
        '    End If
        'End If

        If onContinue = True Then
            'Check for Back Pressure 2
            'Check the text is empty or has only decimal point
            If Not txtbx_RcpEditPrepPressureDrop.Text = "" And Not txtbx_RcpEditPrepPressureDrop.Text = "." Then
                'Convert to the required type
                d_preppressure = CType(txtbx_RcpEditPrepPressureDrop.Text, Decimal)
                'Check the value within range
                If d_preppressure < min_d_preppressure Or d_preppressure > max_d_preppressure Then
                    RecipeMessage(20, "Preparation Back Pressure 2 should be within " + CType(min_d_preppressure, String) + " to " + CType(max_d_preppressure, String))
                    txtbx_RcpEditPrepPressureDrop.Text = Nothing
                    txtbx_RcpEditPrepPressureDrop.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Back Pressure 2")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check for Back Pressure 1
            'Check the text is empty or has only decimal point
            If Not txtbx_RcpEditPrepPressureDrop.Text = "" And Not txtbx_RcpEditPrepPressureDrop.Text = "." Then
                'Convert to the required type
                d_preppressuredrop = CType(txtbx_RcpEditPrepPressureDrop.Text, Decimal)
                'Check the value within range
                If d_preppressuredrop < min_d_preppressuredrop Or d_preppressuredrop > max_d_preppressuredrop Then
                    RecipeMessage(20, "Preparation Back Pressure 1 should be within " + CType(min_d_preppressuredrop, String) + " to " + CType(max_d_preppressuredrop, String))
                    txtbx_RcpEditPrepPressureDrop.Text = Nothing
                    txtbx_RcpEditPrepPressureDrop.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Back Pressure 1")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Back Pressure 1 Time

            'Check the text is empty
            If Not txtbx_RcpEditPrepPressureDropTime.Text = "" Then
                'Convert to the required type
                i_preppressuredroptime = CType(txtbx_RcpEditPrepPressureDropTime.Text, Integer)
                'Check the value within range
                If i_preppressuredroptime < min_i_preppressuredroptime Or i_preppressuredroptime > max_i_preppressuredroptime Then
                    RecipeMessage(20, "Preparation Back Pressure 1 Time should be within " + CType(min_i_preppressuredroptime, String) + " to " + CType(max_i_preppressuredroptime, String))
                    txtbx_RcpEditPrepPressureDropTime.Text = Nothing
                    txtbx_RcpEditPrepPressureDropTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Back Pressure 1 Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Prefill Start Time

            'Check the text is empty
            If Not txtbx_RcpEditPrepPrefillStartTime.Text = "" Then
                'Convert to the required type
                i_prepprefillstarttime = CType(txtbx_RcpEditPrepPrefillStartTime.Text, Integer)
                'Check the value within range
                If i_prepprefillstarttime < min_i_prepprefillstarttime Or i_prepprefillstarttime > max_i_prepprefillstarttime Then
                    RecipeMessage(20, "Preparation Vent Start Time should be within " + CType(min_i_prepprefillstarttime, String) + " to " + CType(max_i_prepprefillstarttime, String))
                    txtbx_RcpEditPrepPrefillStartTime.Text = Nothing
                    txtbx_RcpEditPrepPrefillStartTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Vent Start Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Prefill Time

            'Check the text is empty
            If Not txtbx_RcpEditPrepPrefillTime.Text = "" Then
                'Convert to the required type
                i_prepprefilltime = CType(txtbx_RcpEditPrepPrefillTime.Text, Integer)
                'Check the value within range
                If i_prepprefilltime < min_i_prepprefilltime Or i_prepprefilltime > max_i_prepprefilltime Then
                    RecipeMessage(20, "Preparation Vent Time should be within " + CType(min_i_prepprefilltime, String) + " to " + CType(max_i_prepprefilltime, String))
                    txtbx_RcpEditPrepPrefillTime.Text = Nothing
                    txtbx_RcpEditPrepPrefillTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Vent Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Drain Start Time

            'Check the text is empty
            If Not txtbx_RcpEditPrepDrainStartTime.Text = "" Then
                'Convert to the required type
                i_prepdrainstarttime = CType(txtbx_RcpEditPrepDrainStartTime.Text, Integer)
                'Check the value within range
                If i_prepdrainstarttime < min_i_prepdrainstarttime Or i_prepdrainstarttime > max_i_prepdrainstarttime Then
                    RecipeMessage(20, "Preparation Drain Start Time should be within " + CType(min_i_prepdrainstarttime, String) + " to " + CType(max_i_prepdrainstarttime, String))
                    txtbx_RcpEditPrepDrainStartTime.Text = Nothing
                    txtbx_RcpEditPrepDrainStartTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Drain Start Time")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            'Check Drain Time

            'Check the text is empty
            If Not txtbx_RcpEditPrepDrainTime.Text = "" Then
                'Convert to the required type
                i_prepdraintime = CType(txtbx_RcpEditPrepDrainTime.Text, Integer)
                'Check the value within range
                If i_prepdraintime < min_i_prepdraintime Or i_prepdraintime > max_i_prepdraintime Then
                    RecipeMessage(20, "Preparation Drain Time should be within " + CType(min_i_prepdraintime, String) + " to " + CType(max_i_prepdraintime, String))
                    txtbx_RcpEditPrepDrainTime.Text = Nothing
                    txtbx_RcpEditPrepDrainTime.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Drain Time")
                onContinue = False
            End If
        End If

        If onContinue = True And rdbtn_RcpEditPrepPumpSpeed.Checked = True Then
            'Check Pump RPM

            'Check the text is empty
            If Not txtbx_RcpEditPrepRPM.Text = "" Then
                'Convert to the required type
                i_preprpm1 = CType(txtbx_RcpEditPrepRPM.Text, Integer)
                'Check the value within range
                If i_preprpm1 < min_i_preprpm1 Or i_preprpm1 > max_i_preprpm1 Then
                    RecipeMessage(20, "Preparation Pump Speed should be within " + CType(min_i_preprpm1, String) + " to " + CType(max_i_preprpm1, String))
                    txtbx_RcpEditPrepRPM.Text = Nothing
                    txtbx_RcpEditPrepRPM.Focus()
                    onContinue = False
                End If
            Else
                RecipeMessage(19, "Preparation Pump Speed")
                onContinue = False
            End If
        End If

        'If onContinue = True And cmbx_RcpEditPrepPumpMode.SelectedIndex = 1 Then
        '    'Check Pump RPM-2

        '    'Check the text is empty
        '    If Not txtbx_RcpEditPrepRPM2.Text = "" Then
        '        'Convert to the required type
        '        i_preprpm2 = CType(txtbx_RcpEditPrepRPM2.Text, Integer)
        '        'Check the value within range
        '        If i_preprpm2 < min_i_preprpm2 Or i_preprpm2 > max_i_preprpm2 Then
        '            RecipeMessage(20, "Preparation Pump Speed-2 should be within " + CType(min_i_preprpm2, String) + " to " + CType(max_i_preprpm2, String))
        '            txtbx_RcpEditPrepRPM2.Text = Nothing
        '            txtbx_RcpEditPrepRPM2.Focus()
        '            onContinue = False

        '        End If
        '    Else
        '        RecipeMessage(19, "Preparation Pump Speed-2")
        '        onContinue = False
        '    End If

        'End If

        'In Case of Flush-1 Enabled, the Field should not be empty
        If checkbx_EditFlush1.Checked = True Then
            'If onContinue = True Then
            '    'Check fill time 

            '    'Check the text is empty
            '    If Not txtbx_RcpEditFlush1Fill.Text = "" Then
            '        'Convert to the required type
            '        i_flush1filltime = CType(txtbx_RcpEditFlush1Fill.Text, Integer)
            '        'Check the value within range
            '        If i_flush1filltime < min_i_flush1filltime Or i_flush1filltime > max_i_flush1filltime Then
            '            RecipeMessage(20, "Flush-1 Fill Time should be within " + CType(min_i_flush1filltime, String) + " to " + CType(max_i_flush1filltime, String))
            '            txtbx_RcpEditFlush1Fill.Text = Nothing
            '            txtbx_RcpEditFlush1Fill.Focus()
            '            onContinue = False

            '        End If
            '    Else
            '        RecipeMessage(19, "Flush-1 Fill Time")
            '        onContinue = False
            '    End If

            'End If

            'If onContinue = True Then
            '    'Check air bleed time

            '    'Check the text is empty
            '    If Not txtbx_RcpEditFlush1Bleed.Text = "" Then
            '        'Convert to the required type
            '        i_flush1bleedtime = CType(txtbx_RcpEditFlush1Bleed.Text, Integer)
            '        'Check the value within range
            '        If i_flush1bleedtime < min_i_flush1bleedtime Or i_flush1bleedtime > max_i_flush1bleedtime Then
            '            RecipeMessage(20, "Flush-1 Bleed Time should be within " + CType(min_i_flush1bleedtime, String) + " to " + CType(max_i_flush1bleedtime, String))
            '            txtbx_RcpEditFlush1Bleed.Text = Nothing
            '            txtbx_RcpEditFlush1Bleed.Focus()
            '            onContinue = False
            '        End If
            '    Else
            '        RecipeMessage(19, "Flush-1 Bleed Time")
            '        onContinue = False
            '    End If

            'End If

            If onContinue = True Then
                'Check for Flush-1 Flowrate
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditFlush1Flow.Text = "" And Not txtbx_RcpEditFlush1Flow.Text = "." Then
                    'Convert to the required type
                    d_flush1flow = CType(txtbx_RcpEditFlush1Flow.Text, Decimal)
                    'Check the value within range
                    If d_flush1flow < min_d_flush1flow Or d_flush1flow > max_d_flush1flow Then
                        RecipeMessage(20, "Flush-1 Flowrate should be within " + CType(min_d_flush1flow, String) + " to " + CType(max_d_flush1flow, String))
                        txtbx_RcpEditFlush1Flow.Text = Nothing
                        txtbx_RcpEditFlush1Flow.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Flowrate")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-1 Flow Tolerance
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditFlush1FlowTol.Text = "" And Not txtbx_RcpEditFlush1FlowTol.Text = "." Then
                    'Convert to the required type
                    d_flush1flowtol = CType(txtbx_RcpEditFlush1FlowTol.Text, Decimal)
                    'Check the value within range
                    If d_flush1flowtol < min_d_flush1flowtol Or d_flush1flowtol > max_d_flush1flowtol Then
                        RecipeMessage(20, "Flush-1 Flow Tolerance should be within " + CType(min_d_flush1flowtol, String) + " to " + CType(max_d_flush1flowtol, String))
                        txtbx_RcpEditFlush1FlowTol.Text = Nothing
                        txtbx_RcpEditFlush1FlowTol.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Flow Tolerance")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-1 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditFlush1Pressure.Text = "" And Not txtbx_RcpEditFlush1Pressure.Text = "." Then
                    'Convert to the required type
                    d_flush1pressure = CType(txtbx_RcpEditFlush1Pressure.Text, Decimal)
                    'Check the value within range
                    If d_flush1pressure < min_d_flush1pressure Or d_flush1pressure > max_d_flush1pressure Then
                        RecipeMessage(20, "Flush-1 Pressure should be within " + CType(min_d_flush1pressure, String) + " to " + CType(max_d_flush1pressure, String))
                        txtbx_RcpEditFlush1Pressure.Text = Nothing
                        txtbx_RcpEditFlush1Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Back Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-1 Stabilize Time
                'Check the text is empty
                If Not txtbx_RcpEditFlush1Stabilize.Text = "" Then
                    'Convert to the required type
                    i_flush1stabilize = CType(txtbx_RcpEditFlush1Stabilize.Text, Integer)
                    'Check the value within range
                    If i_flush1stabilize < min_i_flush1stabilize Or i_flush1stabilize > max_i_flush1stabilize Then
                        RecipeMessage(20, "Flush-1 Stabilize Time should be within " + CType(min_i_flush1stabilize, String) + " to " + CType(max_i_flush1stabilize, String))
                        txtbx_RcpEditFlush1Stabilize.Text = Nothing
                        txtbx_RcpEditFlush1Stabilize.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Stabilize Time")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-1 Time
                'Check the text is empty
                If Not txtbx_RcpEditFlush1Time.Text = "" Then
                    'Convert to the required type
                    i_flush1time = CType(txtbx_RcpEditFlush1Time.Text, Integer)
                    'Check the value within range
                    If i_flush1time < min_i_flush1time Or i_flush1time > max_i_flush1time Then
                        RecipeMessage(20, "Flush-1 Time should be within " + CType(min_i_flush1time, String) + " to " + CType(max_i_flush1time, String))
                        txtbx_RcpEditFlush1Time.Text = Nothing
                        txtbx_RcpEditFlush1Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Time")
                    onContinue = False
                End If
            End If

            If onContinue = True And rdbtn_RcpEditFlush1PumpSpeed.Checked = True Then
                'Check Flush-1 Pump RPM
                'Check the text is empty
                If Not txtbx_RcpEditFlush1RPM.Text = "" Then
                    'Convert to the required type
                    i_flush1rpm = CType(txtbx_RcpEditFlush1RPM.Text, Integer)
                    'Check the value within range
                    If i_flush1rpm < min_i_flush1rpm Or i_flush1rpm > max_i_flush1rpm Then
                        RecipeMessage(20, "Flush-1 Pump Speed should be within " + CType(min_i_flush1rpm, String) + " to " + CType(max_i_flush1rpm, String))
                        txtbx_RcpEditFlush1RPM.Text = Nothing
                        txtbx_RcpEditFlush1RPM.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-1 Pump Speed")
                    onContinue = False
                End If
            End If
        End If

        'In Case of Flush-2 Enabled, the Field should not be empty
        If checkbx_EditFlush2.Checked = True Then
            'If onContinue = True Then
            '    'Check fill time 

            '    'Check the text is empty
            '    If Not txtbx_RcpEditFlush2Fill.Text = "" Then
            '        'Convert to the required type
            '        i_flush2filltime = CType(txtbx_RcpEditFlush2Fill.Text, Integer)
            '        'Check the value within range
            '        If i_flush2filltime < min_i_flush2filltime Or i_flush2filltime > max_i_flush2filltime Then
            '            RecipeMessage(20, "Flush-2 Fill Time should be within " + CType(min_i_flush2filltime, String) + " to " + CType(max_i_flush2filltime, String))
            '            txtbx_RcpEditFlush2Fill.Text = Nothing
            '            txtbx_RcpEditFlush2Fill.Focus()
            '            onContinue = False
            '        End If
            '    Else
            '        RecipeMessage(19, "Flush-2 Fill Time")
            '        onContinue = False
            '    End If

            'End If

            'If onContinue = True Then
            '    'Check air bleed time

            '    'Check the text is empty
            '    If Not txtbx_RcpEditFlush2Bleed.Text = "" Then
            '        'Convert to the required type
            '        i_flush2bleedtime = CType(txtbx_RcpEditFlush2Bleed.Text, Integer)
            '        'Check the value within range
            '        If i_flush2bleedtime < min_i_flush2bleedtime Or i_flush2bleedtime > max_i_flush2bleedtime Then
            '            RecipeMessage(20, "Flush-2 Bleed Time should be within " + CType(min_i_flush2bleedtime, String) + " to " + CType(max_i_flush2bleedtime, String))
            '            txtbx_RcpEditFlush2Bleed.Text = Nothing
            '            txtbx_RcpEditFlush2Bleed.Focus()
            '            onContinue = False
            '        End If
            '    Else
            '        RecipeMessage(19, "Flush-2 Bleed Time")
            '        onContinue = False
            '    End If

            'End If

            If onContinue = True Then
                'Check for Flush-2 Flowrate
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditFlush2Flow.Text = "" And Not txtbx_RcpEditFlush2Flow.Text = "." Then
                    'Convert to the required type
                    d_flush2flow = CType(txtbx_RcpEditFlush2Flow.Text, Decimal)
                    'Check the value within range
                    If d_flush2flow < min_d_flush2flow Or d_flush2flow > max_d_flush2flow Then
                        RecipeMessage(20, "Flush-2 Flowrate should be within " + CType(min_d_flush2flow, String) + " to " + CType(max_d_flush2flow, String))
                        txtbx_RcpEditFlush2Flow.Text = Nothing
                        txtbx_RcpEditFlush2Flow.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Flowrate")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-2 Flow Tolerance
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditFlush2FlowTol.Text = "" And Not txtbx_RcpEditFlush2FlowTol.Text = "." Then
                    'Convert to the required type
                    d_flush2flowtol = CType(txtbx_RcpEditFlush2FlowTol.Text, Decimal)
                    'Check the value within range
                    If d_flush2flowtol < min_d_flush2flowtol Or d_flush2flowtol > max_d_flush2flowtol Then
                        RecipeMessage(20, "Flush-2 Flow Tolerance should be within " + CType(min_d_flush2flowtol, String) + " to " + CType(max_d_flush2flowtol, String))
                        txtbx_RcpEditFlush2FlowTol.Text = Nothing
                        txtbx_RcpEditFlush2FlowTol.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Flow Tolerance")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-2 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditFlush2Pressure.Text = "" And Not txtbx_RcpEditFlush2Pressure.Text = "." Then
                    'Convert to the required type
                    d_flush2pressure = CType(txtbx_RcpEditFlush2Pressure.Text, Decimal)
                    'Check the value within range
                    If d_flush2pressure < min_d_flush2pressure Or d_flush2pressure > max_d_flush2pressure Then
                        RecipeMessage(20, "Flush-2 Pressure should be within " + CType(min_d_flush2pressure, String) + " to " + CType(max_d_flush2pressure, String))
                        txtbx_RcpEditFlush2Pressure.Text = Nothing
                        txtbx_RcpEditFlush2Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Back Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-2 Stabilize Time
                'Check the text is empty
                If Not txtbx_RcpEditFlush2Stabilize.Text = "" Then
                    'Convert to the required type
                    i_flush2stabilize = CType(txtbx_RcpEditFlush2Stabilize.Text, Integer)
                    'Check the value within range
                    If i_flush2stabilize < min_i_flush2stabilize Or i_flush2stabilize > max_i_flush2stabilize Then
                        RecipeMessage(20, "Flush-2 Stabilize Time should be within " + CType(min_i_flush2stabilize, String) + " to " + CType(max_i_flush2stabilize, String))
                        txtbx_RcpEditFlush2Stabilize.Text = Nothing
                        txtbx_RcpEditFlush2Stabilize.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Stabilize Time")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Flush-2 Time
                'Check the text is empty
                If Not txtbx_RcpEditFlush2Time.Text = "" Then
                    'Convert to the required type
                    i_flush2time = CType(txtbx_RcpEditFlush2Time.Text, Integer)
                    'Check the value within range
                    If i_flush2time < min_i_flush2time Or i_flush2time > max_i_flush2time Then
                        RecipeMessage(20, "Flush-2 Time should be within " + CType(min_i_flush2time, String) + " to " + CType(max_i_flush2time, String))
                        txtbx_RcpEditFlush2Time.Text = Nothing
                        txtbx_RcpEditFlush2Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Time")
                    onContinue = False
                End If
            End If

            If onContinue = True And rdbtn_RcpEditFlush2PumpSpeed.Checked = True Then
                'Check Flush-2 Pump RPM
                'Check the text is empty
                If Not txtbx_RcpEditFlush2RPM.Text = "" Then
                    'Convert to the required type
                    i_flush2rpm = CType(txtbx_RcpEditFlush2RPM.Text, Integer)
                    'Check the value within range
                    If i_flush2rpm < min_i_flush2rpm Or i_flush2rpm > max_i_flush2rpm Then
                        RecipeMessage(20, "Flush-2 Pump Speed should be within " + CType(min_i_flush2rpm, String) + " to " + CType(max_i_flush2rpm, String))
                        txtbx_RcpEditFlush2RPM.Text = Nothing
                        txtbx_RcpEditFlush2RPM.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Flush-2 Pump Speed")
                    onContinue = False
                End If
            End If
        End If

        'In Case of DP Test-1 Enabled, the Field should not be empty
        If checkbx_EditDPTest1.Checked = True Then
            'If onContinue = True Then
            '    'Check fill time 

            '    'Check the text is empty
            '    If Not txtbx_RcpEditDPFill.Text = "" Then
            '        'Convert to the required type
            '        i_dptestfilltime = CType(txtbx_RcpEditDPFill.Text, Integer)
            '        'Check the value within range
            '        If i_dptestfilltime < min_i_dptestfilltime Or i_dptestfilltime > max_i_dptestfilltime Then
            '            RecipeMessage(20, "DP Test Fill Time should be within " + CType(min_i_dptestfilltime, String) + " to " + CType(max_i_dptestfilltime, String))
            '            txtbx_RcpEditDPFill.Text = Nothing
            '            txtbx_RcpEditDPFill.Focus()
            '            onContinue = False

            '        End If
            '    Else
            '        RecipeMessage(19, "DP Test Fill Time")
            '        onContinue = False
            '    End If
            'End If

            'If onContinue = True Then
            '    'Check air bleed time

            '    'Check the text is empty
            '    If Not txtbx_RcpEditDPBleed.Text = "" Then
            '        'Convert to the required type
            '        i_dptestbleedtime = CType(txtbx_RcpEditDPBleed.Text, Integer)
            '        'Check the value within range
            '        If i_dptestbleedtime < min_i_dptestbleedtime Or i_dptestbleedtime > max_i_dptestbleedtime Then
            '            RecipeMessage(20, "DP Test Bleed Time should be within " + CType(min_i_dptestbleedtime, String) + " to " + CType(max_i_dptestbleedtime, String))
            '            txtbx_RcpEditDPBleed.Text = Nothing
            '            txtbx_RcpEditDPBleed.Focus()
            '            onContinue = False
            '        End If
            '    Else
            '        RecipeMessage(19, "DP Test Bleed Time")
            '        onContinue = False
            '    End If
            'End If


            If onContinue = True Then
                'Check for DP Test Flowrate
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditDPFlow.Text = "" And Not txtbx_RcpEditDPFlow.Text = "." Then
                    'Convert to the required type
                    d_dptestflow = CType(txtbx_RcpEditDPFlow.Text, Decimal)
                    'Check the value within range
                    If d_dptestflow < min_d_dptestflow Or d_dptestflow > max_d_dptestflow Then
                        RecipeMessage(20, "DP Test Flowrate should be within " + CType(min_d_dptestflow, String) + " to " + CType(max_d_dptestflow, String))
                        txtbx_RcpEditDPFlow.Text = Nothing
                        txtbx_RcpEditDPFlow.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Flowrate")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test Flow Tolerance
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditDPFlowTol.Text = "" And Not txtbx_RcpEditDPFlowTol.Text = "." Then
                    'Convert to the required type
                    d_dptestflowtol = CType(txtbx_RcpEditDPFlowTol.Text, Decimal)
                    'Check the value within range
                    If d_dptestflowtol < min_d_dptestflowtol Or d_dptestflowtol > max_d_dptestflowtol Then
                        RecipeMessage(20, "DP Test Flow Tolerance should be within " + CType(min_d_dptestflowtol, String) + " to " + CType(max_d_dptestflowtol, String))
                        txtbx_RcpEditDPFlowTol.Text = Nothing
                        txtbx_RcpEditDPFlowTol.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Flow tolerance")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditDPPressure.Text = "" And Not txtbx_RcpEditDPPressure.Text = "." Then
                    'Convert to the required type
                    d_dptestpressure = CType(txtbx_RcpEditDPPressure.Text, Decimal)
                    'Check the value within range
                    If d_dptestpressure < min_d_dptestpressure Or d_dptestpressure > max_d_dptestpressure Then
                        RecipeMessage(20, "DP Test Pressure should be within " + CType(min_d_dptestpressure, String) + " to " + CType(max_d_dptestpressure, String))
                        txtbx_RcpEditDPPressure.Text = Nothing
                        txtbx_RcpEditDPPressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Back Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test Stabilize Time
                'Check the text is empty
                If Not txtbx_RcpEditDPStabilize.Text = "" Then
                    'Convert to the required type
                    i_dpteststabilize = CType(txtbx_RcpEditDPStabilize.Text, Integer)
                    'Check the value within range
                    If i_dpteststabilize < min_i_dpteststabilize Or i_dpteststabilize > max_i_dpteststabilize Then
                        RecipeMessage(20, "DP Test Stabilize Time should be within " + CType(min_i_dpteststabilize, String) + " to " + CType(max_i_dpteststabilize, String))
                        txtbx_RcpEditDPStabilize.Text = Nothing
                        txtbx_RcpEditDPStabilize.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Stabilize Time")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test Time
                'Check the text is empty
                If Not txtbx_RcpEditDPTime.Text = "" Then
                    'Convert to the required type
                    i_dptesttime = CType(txtbx_RcpEditDPTime.Text, Integer)
                    'Check the value within range
                    If i_dptesttime < min_i_dptesttime Or i_dptesttime > max_i_dptesttime Then
                        RecipeMessage(20, "DP Test Time should be within " + CType(min_i_dptesttime, String) + " to " + CType(max_i_dptesttime, String))
                        txtbx_RcpEditDPTime.Text = Nothing
                        txtbx_RcpEditDPTime.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Time")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test LowerLimit
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditDPLowLimit.Text = "" And Not txtbx_RcpEditDPLowLimit.Text = "." Then
                    'Convert to the required type
                    d_dptestlowlimit = CType(txtbx_RcpEditDPLowLimit.Text, Decimal)
                    'Check the value within range
                    If d_dptestlowlimit < min_d_dptestlowlimit Or d_dptestlowlimit > max_d_dptestlowlimit Then
                        RecipeMessage(20, "DP Test Lower Limit should be within " + CType(min_d_dptestlowlimit, String) + " to " + CType(max_d_dptestlowlimit, String))
                        txtbx_RcpEditDPLowLimit.Text = Nothing
                        txtbx_RcpEditDPLowLimit.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Lower Limit")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'check for dp test upperlimit
                'check the text is empty or has only decimal point
                If Not txtbx_RcpEditDPUpLimit.Text = "" And Not txtbx_RcpEditDPUpLimit.Text = "." Then
                    'convert to the required type
                    d_dptestuplimit = CType(txtbx_RcpEditDPUpLimit.Text, Decimal)
                    'check the value within range
                    If d_dptestuplimit < min_d_dptestuplimit Or d_dptestuplimit > max_d_dptestuplimit Then
                        RecipeMessage(20, "DP Test Upper Limit should be within " + CType(min_d_dptestuplimit, String) + " to " + CType(max_d_dptestuplimit, String))
                        txtbx_RcpEditDPUpLimit.Text = Nothing
                        txtbx_RcpEditDPUpLimit.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Upper Limit")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for DP Test points
                'Check the text is empty
                If Not txtbx_RcpEditDPPoints.Text = "" Then
                    'Convert to the required type
                    i_dptestpoints = CType(txtbx_RcpEditDPPoints.Text, Integer)
                    'Check the value within range
                    If i_dptestpoints < min_i_dptestpoints Or i_dptestpoints > max_i_dptestpoints Then
                        RecipeMessage(20, "DP Test Point should be within " + CType(min_i_dptestpoints, String) + " to " + CType(max_i_dptestpoints, String))
                        txtbx_RcpEditDPPoints.Text = Nothing
                        txtbx_RcpEditDPPoints.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test points")
                    onContinue = False
                End If
            End If

            If onContinue = True And rdbtn_RcpEditDPTestPumpSpeed.Checked = True Then
                'Check DP Test Pump RPM
                'Check the text is empty
                If Not txtbx_RcpEditDPTestRPM.Text = "" Then
                    'Convert to the required type
                    i_dptestrpm = CType(txtbx_RcpEditDPTestRPM.Text, Integer)
                    'Check the value within range
                    If i_dptestrpm < min_i_dptestrpm Or i_dptestrpm > max_i_dptestrpm Then
                        RecipeMessage(20, "DP Test Pump Speed should be within " + CType(min_i_dptestrpm, String) + " to " + CType(max_i_dptestrpm, String))
                        txtbx_RcpEditDPTestRPM.Text = Nothing
                        txtbx_RcpEditDPTestRPM.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "DP Test Pump Speed")
                    onContinue = False
                End If
            End If
        End If

        'In Case of Drain-1 Enabled, the Field should not be empty
        If checkbx_EditDrain1.Checked = True Then
            If onContinue = True Then
                'Check for Drain-1 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditDrain1Pressure.Text = "" And Not txtbx_RcpEditDrain1Pressure.Text = "." Then
                    'Convert to the required type
                    d_drain1pressure = CType(txtbx_RcpEditDrain1Pressure.Text, Decimal)
                    'Check the value within range
                    If d_drain1pressure < min_d_drain1pressure Or d_drain1pressure > max_d_drain1pressure Then
                        RecipeMessage(20, "Drain-1 Pressure should be within " + CType(min_d_drain1pressure, String) + " to " + CType(max_d_drain1pressure, String))
                        txtbx_RcpEditDrain1Pressure.Text = Nothing
                        txtbx_RcpEditDrain1Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-1 Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Drain-1 Time
                'Check the text is empty
                If Not txtbx_RcpEditDrain1Time.Text = "" Then
                    'Convert to the required type
                    i_drain1time = CType(txtbx_RcpEditDrain1Time.Text, Integer)
                    'Check the value within range
                    If i_drain1time < min_i_drain1time Or i_drain1time > max_i_drain1time Then
                        RecipeMessage(20, "Drain-1 Time should be within " + CType(min_i_drain1time, String) + " to " + CType(max_i_drain1time, String))
                        txtbx_RcpEditDrain1Time.Text = Nothing
                        txtbx_RcpEditDrain1Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-1 Time")
                    onContinue = False
                End If
            End If
        End If

        'In Case of Drain-2 Enabled, the Field should not be empty
        If checkbx_EditDrain2.Checked = True Then
            If onContinue = True Then
                'Check for Drain-2 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditDrain2Pressure.Text = "" And Not txtbx_RcpEditDrain2Pressure.Text = "." Then
                    'Convert to the required type
                    d_drain2pressure = CType(txtbx_RcpEditDrain2Pressure.Text, Decimal)
                    'Check the value within range
                    If d_drain2pressure < min_d_drain2pressure Or d_drain2pressure > max_d_drain2pressure Then
                        RecipeMessage(20, "Drain-2 Pressure should be within " + CType(min_d_drain2pressure, String) + " to " + CType(max_d_drain2pressure, String))
                        txtbx_RcpEditDrain2Pressure.Text = Nothing
                        txtbx_RcpEditDrain2Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-2 Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Drain-2 Time
                'Check the text is empty
                If Not txtbx_RcpEditDrain2Time.Text = "" Then
                    'Convert to the required type
                    i_drain2time = CType(txtbx_RcpEditDrain2Time.Text, Integer)
                    'Check the value within range
                    If i_drain2time < min_i_drain2time Or i_drain2time > max_i_drain2time Then
                        RecipeMessage(20, "Drain-2 Time should be within " + CType(min_i_drain2time, String) + " to " + CType(max_i_drain2time, String))
                        txtbx_RcpEditDrain2Time.Text = Nothing
                        txtbx_RcpEditDrain2Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-2 Time")
                    onContinue = False
                End If
            End If
        End If

        'In Case of Drain-3 Enabled, the Field should not be empty
        If checkbx_EditDrain3.Checked = True Then
            If onContinue = True Then
                'Check for FDrain-3 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditDrain3Pressure.Text = "" And Not txtbx_RcpEditDrain3Pressure.Text = "." Then
                    'Convert to the required type
                    d_drain3pressure = CType(txtbx_RcpEditDrain3Pressure.Text, Decimal)
                    'Check the value within range
                    If d_drain3pressure < min_d_drain3pressure Or d_drain3pressure > max_d_drain3pressure Then
                        RecipeMessage(20, "Drain-3 Pressure should be within " + CType(min_d_drain3pressure, String) + " to " + CType(max_d_drain3pressure, String))
                        txtbx_RcpEditDrain3Pressure.Text = Nothing
                        txtbx_RcpEditDrain3Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-3 Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Drain-3 Time
                'Check the text is empty
                If Not txtbx_RcpEditDrain3Time.Text = "" Then
                    'Convert to the required type
                    i_drain3time = CType(txtbx_RcpEditDrain3Time.Text, Integer)
                    'Check the value within range
                    If i_drain3time < min_i_drain3time Or i_drain3time > max_i_drain3time Then
                        RecipeMessage(20, "Drain-3 Time should be within " + CType(min_i_drain3time, String) + " to " + CType(max_i_drain3time, String))
                        txtbx_RcpEditDrain3Time.Text = Nothing
                        txtbx_RcpEditDrain3Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-3 Time")
                    onContinue = False
                End If
            End If
        End If

        'In Case of Drain-4 Enabled, the Field should not be empty
        If checkbx_EditDrain4.Checked = True Then
            If onContinue = True Then
                'Check for FDrain-4 Pressure
                'Check the text is empty or has only decimal point
                If Not txtbx_RcpEditDrain4Pressure.Text = "" And Not txtbx_RcpEditDrain4Pressure.Text = "." Then
                    'Convert to the required type
                    d_drain4pressure = CType(txtbx_RcpEditDrain4Pressure.Text, Decimal)
                    'Check the value within range
                    If d_drain4pressure < min_d_drain4pressure Or d_drain4pressure > max_d_drain4pressure Then
                        RecipeMessage(20, "Drain-4 Pressure should be within " + CType(min_d_drain4pressure, String) + " to " + CType(max_d_drain4pressure, String))
                        txtbx_RcpEditDrain4Pressure.Text = Nothing
                        txtbx_RcpEditDrain4Pressure.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-4 Pressure")
                    onContinue = False
                End If
            End If

            If onContinue = True Then
                'Check for Drain-4 Time
                'Check the text is empty
                If Not txtbx_RcpEditDrain4Time.Text = "" Then
                    'Convert to the required type
                    i_drain4time = CType(txtbx_RcpEditDrain4Time.Text, Integer)
                    'Check the value within range
                    If i_drain4time < min_i_drain4time Or i_drain4time > max_i_drain4time Then
                        RecipeMessage(20, "Drain-4 Time should be within " + CType(min_i_drain4time, String) + " to " + CType(max_i_drain4time, String))
                        txtbx_RcpEditDrain4Time.Text = Nothing
                        txtbx_RcpEditDrain4Time.Focus()
                        onContinue = False
                    End If
                Else
                    RecipeMessage(19, "Drain-4 Time")
                    onContinue = False
                End If
            End If
        End If
#End Region

        'Load Zero if the Flush-1 is not enabled
        If onContinue = True Then
            If checkbx_EditFlush1.Checked = False Then
                'i_flush1filltime = 0
                'i_flush1bleedtime = 0
                d_flush1flow = 0.0
                d_flush1flowtol = 0.0
                'd_flush1pressure = 0.0
                i_flush1stabilize = 0
                i_flush1time = 0
            ElseIf Not (i_flush1time > 0 And d_flush1flow > 0) Then
                RecipeMessage(53, "If Flush-1 Enabled, then Flush-1 Time & Flush-1 Flowrate Cannot be Zero")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If checkbx_EditDPTest1.Checked = False Then
                'i_dptestfilltime = 0
                'i_dptestbleedtime = 0
                'd_dptestflow = 0.0
                'd_dptestflowtol = 0.0
                'd_dptestpressure = 0.0
                i_dpteststabilize = 0
                i_dptesttime = 0
                d_dptestlowlimit = 0.0
                d_dptestuplimit = 0.0
                i_dptestpoints = 0
            ElseIf Not (i_dptesttime > 0 And i_dptestpoints > 0) Then
                RecipeMessage(53, "If DP Test Enabled, then DP Test Time & DP Test Points Cannot be Zero")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If checkbx_EditFlush2.Checked = False Then
                'i_flush2filltime = 0
                'i_flush2bleedtime = 0
                d_flush2flow = 0.0
                d_flush2flowtol = 0.0
                'd_flush2pressure = 0.0
                i_flush2stabilize = 0
                i_flush2time = 0
            ElseIf Not (i_flush2time > 0 And d_flush2flow > 0) Then
                RecipeMessage(53, "If Flush-2 Enabled, then Flush-2 Time & Flush-2 Flowrate Cannot be Zero")
                onContinue = False
            End If
        End If

        If onContinue = True Then
            If checkbx_EditDrain1.Checked = False Then
                d_drain1pressure = 0.0
                i_drain1time = 0
            End If
        End If

        If onContinue = True Then
            If checkbx_EditDrain2.Checked = False Then
                d_drain2pressure = 0.0
                i_drain2time = 0
            End If
        End If

        If onContinue = True Then
            If checkbx_EditDrain3.Checked = False Then
                d_drain3pressure = 0.0
                i_drain3time = 0
            End If
        End If

        If onContinue = True Then
            If checkbx_EditDrain4.Checked = False Then
                d_drain4pressure = 0.0
                i_drain4time = 0
            End If
        End If

        'Check whether Test points is greater than Test time
        ' Always Test points should be less than or equal to Test time
        If onContinue = True Then
            If checkbx_EditDPTest1.Checked = True Then
                If i_dptestpoints > i_dptesttime Then
                    RecipeMessage(21, "DP Test-1")
                    onContinue = False
                End If
            End If
        End If

        'Check whether any one process is selected, if not don't allow recipe creation
        If onContinue = True Then
            If checkbx_EditDPTest1.Checked = False And checkbx_EditFlush1.Checked = False And checkbx_EditFlush2.Checked = False Then
                RecipeMessage(22)
                onContinue = False
            End If
        End If

        'Check whether any one drain is selected, if not don't allow recipe creation
        If onContinue = True Then
            'If checkbx_EditDrain1.Checked = False And checkbx_EditDrain2.Checked = False And checkbx_EditDrain3.Checked = False Then
            '    RecipeMessage(39)
            '    onContinue = False
            'End If
        End If

        'Check is Fill valid for Prefill
        If onContinue = True Then
            Dim ParseError As Boolean = False

            Dim TotalFillTime As Integer
            Dim TotalBleedTime As Integer
            Dim PrefillStartTime As Integer
            Dim PrefillTime As Integer
            Dim DrainStartTime As Integer
            Dim DrainTime As Integer
            Dim BP1Time As Integer

            If Not Integer.TryParse(txtbx_RcpEditPrepFill.Text, TotalFillTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpEditPrepBleed.Text, TotalBleedTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpEditPrepPrefillStartTime.Text, PrefillStartTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpEditPrepPrefillTime.Text, PrefillTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpEditPrepDrainStartTime.Text, DrainStartTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpEditPrepDrainTime.Text, DrainTime) Then
                ParseError = True
            End If
            If Not Integer.TryParse(txtbx_RcpEditPrepPressureDropTime.Text, BP1Time) Then
                ParseError = True
            End If

            If ParseError = False Then
                If onContinue = True Then
                    If (PrefillStartTime + PrefillTime) >= TotalFillTime Then
                        onContinue = False
                        MsgBox("Vent Time must be less than Fill Time", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
                    End If
                End If
                If onContinue = True Then
                    If (DrainStartTime + DrainTime) >= TotalFillTime Then
                        onContinue = False
                        MsgBox("Drain Time must be less than Fill Time", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
                    End If
                End If
                If onContinue = True Then
                    If BP1Time >= TotalFillTime + TotalBleedTime Then
                        onContinue = False
                        MsgBox("Prep Back Pressure Time must be less than Fill + Bleed Time", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
                    End If
                End If
            Else
                onContinue = False
                MsgBox("Integer Parse Error", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            End If
        End If

        If onContinue = True Then
            If checkbx_EditFlush1.Checked = True Then
                str_flush1enable = "Enable"
            Else
                str_flush1enable = "Disable"
            End If
            If checkbx_EditFlush2.Checked = True Then
                str_flush2enable = "Enable"
            Else
                str_flush2enable = "Disable"
            End If
            If checkbx_EditDPTest1.Checked = True Then
                str_dptest1enable = "Enable"
            Else
                str_dptest1enable = "Disable"
            End If
            If checkbx_EditDPTest2.Checked = True Then
                str_dptest2enable = "Enable"
            Else
                str_dptest2enable = "Disable"
            End If

            If checkbx_EditDrain1.Checked = True Then
                str_drain1enable = "Enable"
            Else
                str_drain1enable = "Disable"
            End If
            If checkbx_EditDrain2.Checked = True Then
                str_drain2enable = "Enable"
            Else
                str_drain2enable = "Disable"
            End If
            If checkbx_EditDrain3.Checked = True Then
                str_drain3enable = "Enable"
            Else
                str_drain3enable = "Disable"
            End If
            If checkbx_EditDrain4.Checked = True Then
                str_drain4enable = "Enable"
            Else
                str_drain4enable = "Disable"
            End If
        End If

        ' Check if filter types are available/selected
        If True Then
            If ComboBox9.Items.Count > 0 And ComboBox8.Items.Count > 0 And ComboBox7.Items.Count > 0 Then
            Else
                onContinue = False
                MsgBox("Filter Types Not Selected", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
            End If
        End If

        If onContinue = True Then
            Dim DateTimeNowInStr As String = DateTime.Now.ToString("s")
            Dim currentDateTime As String = lbl_DateTimeClock.Text
            Dim currentDateTime2 As DateTime = DateTime.Now
            If dtrecipeidcheck.Rows.Count > 0 Then
                Dim Updateparameter As New Dictionary(Of String, Object) From {
                    {"recipe_id", RecipeID},
                    {"recipe_rev", CInt(dtrecipeidcheck(0)("recipe_rev")) + 1},
                    {"part_id", dtrecipeidcheck(0)("part_id")},
                    {"recipe_type_id", dtrecipeidcheck(0)("recipe_type_id")},
                    {"user_created", PublicVariables.LoginUserName},
                    {"created_time", DateTimeNowInStr},
                    {"fitting_inlet", IIf(ComboBox9.Items.Count > 0, ComboBox9.SelectedItem, "")},
                    {"fitting_outlet", IIf(ComboBox8.Items.Count > 0, ComboBox8.SelectedItem, "")},
                    {"fitting_blank", IIf(ComboBox7.Items.Count > 0, ComboBox7.SelectedItem, "")},
                                                                                                  _
                    {"last_modified_by", PublicVariables.LoginUserName},
                    {"last_modified_time", DateTimeNowInStr}, ' lbl_DateTimeClock.Text
                    {"verification_tolerance", d_vertol},
                    {"prep_fill_time", i_prepfilltime},
                    {"prep_bleed_time", i_prepbleedtime},
                                                         _ '{"prep_flowrate", d_prepflow},
                                                         _ '{"prep_flow_tolerance", d_prepflowtol},
                    {"prep_flowrate", 0},
                    {"prep_flow_tolerance", 0},
                    {"prep_back_pressure", d_preppressure},
                    {"prep_pressure_drop", d_preppressuredrop},
                    {"prep_pressure_drop_time", i_preppressuredroptime},
                    {"prep_prefill_start_time", i_prepprefillstarttime},
                    {"prep_prefill_time", i_prepprefilltime},
                    {"prep_drain_start_time", i_prepdrainstarttime},
                    {"prep_drain_time", i_prepdraintime},
                    {"prep_speed_mode", str_prepspeedenable},
                    {"prep_rpm1", i_preprpm1},
                                              _ '{"prep_rpm2", i_preprpm2},
                    {"firstflush_circuit", str_flush1enable},
                                                             _ '{"firstflush_fill_time", i_flush1filltime},
                                                             _ '{"firstflush_bleed_time", i_flush1bleedtime},
                    {"firstflush_flowrate", d_flush1flow},
                    {"firstflush_flow_tolerance", d_flush1flowtol},
                    {"firstflush_back_pressure", d_flush1pressure},
                    {"firstflush_stabilize_time", i_flush1stabilize},
                    {"firstflush_time", i_flush1time},
                    {"firstflush_speed_mode", str_flush1speedenable},
                    {"firstflush_rpm", i_flush1rpm},
                    {"firstdp_circuit", str_dptest1enable},
                                                           _ '{"dp_fill_time", i_dptestfilltime},
                                                           _ '{"dp_bleed_time", i_dptestbleedtime},
                    {"dp_flowrate", d_dptestflow},
                    {"dp_flow_tolerance", d_dptestflowtol},
                    {"dp_back_pressure", d_dptestpressure},
                    {"dp_stabilize_time", i_dpteststabilize},
                    {"dp_test_time", i_dptesttime},
                    {"dp_lowerlimit", d_dptestlowlimit},
                    {"dp_upperlimit", d_dptestuplimit},
                    {"dp_testpoints", i_dptestpoints},
                    {"dp_speed_mode", str_dptestspeedenable},
                    {"dp_rpm", i_dptestrpm},
                    {"seconddp_circuit", str_dptest2enable},
                    {"secondflush_circuit", str_flush2enable},
                                                              _ '{"secondflush_fill_time", i_flush2filltime},
                                                              _ '{"secondflush_bleed_time", i_flush2bleedtime},
                    {"secondflush_flowrate", d_flush2flow},
                    {"secondflush_flow_tolerance", d_flush2flowtol},
                    {"secondflush_back_pressure", d_flush2pressure},
                    {"secondflush_stabilize_time", i_flush2stabilize},
                    {"secondflush_time", i_flush2time},
                    {"secondflush_speed_mode", str_flush2speedenable},
                    {"secondflush_rpm", i_flush2rpm},
                    {"drain1_circuit", str_drain1enable},
                    {"drain1_back_pressure", d_drain1pressure},
                    {"drain1_time", i_drain1time},
                    {"drain2_circuit", str_drain2enable},
                    {"drain2_back_pressure", d_drain2pressure},
                    {"drain2_time", i_drain2time},
                    {"drain3_circuit", str_drain3enable},
                    {"drain3_back_pressure", d_drain3pressure},
                    {"drain3_time", i_drain3time},
                    {"drain4_circuit", str_drain4enable},
                    {"drain4_back_pressure", d_drain4pressure},
                    {"drain4_time", i_drain4time}
                }
                Dim Condition As String = "recipe_id = '" + RecipeID + "'"

                If RecipeMessage(36, RecipeID) = DialogResult.Yes Then
                    'If SQL.UpdateRecord("RecipeTable", Updateparameter, Condition) = 1 Then
                    If SQL.InsertRecord("RecipeTable", Updateparameter) = 1 Then
                        Dim recipeUpdateContinue As Boolean = False

                        ' Check Edit Recipe Match Current Recipe Selected
                        'If FormMainModule.RecipeID = RecipeID Then
                        '    ' Check Lot Status
                        '    If True Then
                        '        If MsgBox("This action will End Lot. Continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Warning") = DialogResult.Yes Then
                        '            ' Continue Recipe Update
                        '            recipeUpdateContinue = True

                        '            ' End Lot
                        '            FormMain.Endlot()

                        '            ' Clear Calibration Records

                        '        End If
                        '    End If
                        'Else
                        '    recipeUpdateContinue = True
                        'End If

                        If True Then
                            RecipeMessage(37)

                            RcpEditEventLogger(Updateparameter)

                            cmbx_RcpEditFilterType.SelectedIndex = 0
                            LoadRecipeDetails(0, Nothing, Nothing, Nothing, Nothing)

                            cmbx_RcpEditFilterType.Text = FilterTypeTmp
                            cmbx_RcpEditPartID.Text = PartIDTmp
                            cmbx_RcpEditRecipeID.Text = RecipeID
                        End If
                    Else
                        RecipeMessage(38)
                        onContinue = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RcpEditEventLogger(dic As Dictionary(Of String, Object))
        Dim VerificationTolerance As Decimal = CType(dtEditrecipetemp(0)("verification_tolerance"), Decimal)

        Dim PrepFill As Integer = CType(dtEditrecipetemp(0)("prep_fill_time"), Integer)
        Dim PrepBleed As Integer = CType(dtEditrecipetemp(0)("prep_bleed_time"), Integer)
        'Dim PrepFlow As Decimal = CType(dtEditrecipetemp(0)("prep_flowrate"), Decimal)
        Dim PrepBPress As Decimal = CType(dtEditrecipetemp(0)("prep_back_pressure"), Decimal)
        Dim PrepPressDrop As Decimal = CType(dtEditrecipetemp(0)("prep_pressure_drop"), Decimal)
        Dim PrepPressDropTime As Integer = CType(dtEditrecipetemp(0)("prep_pressure_drop_time"), Integer)
        Dim PrepPrefillStartTime As Integer = CType(dtEditrecipetemp(0)("prep_prefill_start_time"), Integer)
        Dim PrepPrefillTime As Integer = CType(dtEditrecipetemp(0)("prep_prefill_time"), Integer)
        Dim PrepDrainStartTime As Integer = CType(dtEditrecipetemp(0)("prep_drain_start_time"), Integer)
        Dim PrepDrainTime As Integer = CType(dtEditrecipetemp(0)("prep_drain_time"), Integer)

        'Dim Flush1Fill As Integer = CType(dtEditrecipetemp(0)("firstflush_fill_time"), Integer)
        'Dim Flush1Bleed As Integer = CType(dtEditrecipetemp(0)("firstflush_bleed_time"), Integer)
        Dim Flush1Flow As Decimal = CType(dtEditrecipetemp(0)("firstflush_flowrate"), Decimal)
        Dim Flush1FlowTol As Decimal = CType(dtEditrecipetemp(0)("firstflush_flow_tolerance"), Decimal)
        Dim Flush1BPress As Decimal = CType(dtEditrecipetemp(0)("firstflush_back_pressure"), Decimal)
        Dim Flush1Stabilize As Integer = CType(dtEditrecipetemp(0)("firstflush_stabilize_time"), Integer)
        Dim Flush1Time As Integer = CType(dtEditrecipetemp(0)("firstflush_time"), Integer)

        'Dim DPFill As Integer = CType(dtEditrecipetemp(0)("dp_fill_time"), Integer)
        'Dim DPBleed As Integer = CType(dtEditrecipetemp(0)("dp_bleed_time"), Integer)
        Dim DPFlow As Decimal = CType(dtEditrecipetemp(0)("dp_flowrate"), Decimal)
        Dim DPFlowTol As Decimal = CType(dtEditrecipetemp(0)("dp_flow_tolerance"), Decimal)
        Dim DPBPress As Decimal = CType(dtEditrecipetemp(0)("dp_back_pressure"), Decimal)
        Dim DPStabilize As Integer = CType(dtEditrecipetemp(0)("dp_stabilize_time"), Integer)
        Dim DPTime As Integer = CType(dtEditrecipetemp(0)("dp_test_time"), Integer)
        Dim DPLL As Decimal = CType(dtEditrecipetemp(0)("dp_lowerlimit"), Decimal)
        Dim DPUL As Decimal = CType(dtEditrecipetemp(0)("dp_upperlimit"), Decimal)
        Dim DPTestPoints As Integer = CType(dtEditrecipetemp(0)("dp_testpoints"), Integer)

        'Dim Flush2Fill As Integer = CType(dtEditrecipetemp(0)("secondflush_fill_time"), Integer)
        'Dim Flush2Bleed As Integer = CType(dtEditrecipetemp(0)("secondflush_bleed_time"), Integer)
        Dim Flush2Flow As Decimal = CType(dtEditrecipetemp(0)("secondflush_flowrate"), Decimal)
        Dim Flush2FlowTol As Decimal = CType(dtEditrecipetemp(0)("secondflush_flow_tolerance"), Decimal)
        Dim Flush2BPress As Decimal = CType(dtEditrecipetemp(0)("secondflush_back_pressure"), Decimal)
        Dim Flush2Stabilize As Integer = CType(dtEditrecipetemp(0)("secondflush_stabilize_time"), Integer)
        Dim Flush2Time As Integer = CType(dtEditrecipetemp(0)("secondflush_time"), Integer)

        Dim Drain1Press As Decimal = CType(dtEditrecipetemp(0)("drain1_back_pressure"), Decimal)
        Dim Drain1Time As Integer = CType(dtEditrecipetemp(0)("drain1_time"), Integer)

        Dim Drain2Press As Decimal = CType(dtEditrecipetemp(0)("drain2_back_pressure"), Decimal)
        Dim Drain2Time As Integer = CType(dtEditrecipetemp(0)("drain2_time"), Integer)

        Dim Drain3Press As Decimal = CType(dtEditrecipetemp(0)("drain3_back_pressure"), Decimal)
        Dim Drain3Time As Integer = CType(dtEditrecipetemp(0)("drain3_time"), Integer)

        Dim Drain4Press As Decimal = CType(dtEditrecipetemp(0)("drain4_back_pressure"), Decimal)
        Dim Drain4Time As Integer = CType(dtEditrecipetemp(0)("drain4_time"), Integer)

        Dim Flush1Enable As String = dtEditrecipetemp(0)("firstflush_circuit")
        Dim DP1Enable As String = dtEditrecipetemp(0)("firstdp_circuit")
        Dim DP2Enable As String = dtEditrecipetemp(0)("seconddp_circuit")
        Dim Flush2Enable As String = dtEditrecipetemp(0)("secondflush_circuit")
        Dim Drain1Enable As String = dtEditrecipetemp(0)("drain1_circuit")
        Dim Drain2Enable As String = dtEditrecipetemp(0)("drain2_circuit")
        Dim Drain3Enable As String = dtEditrecipetemp(0)("drain3_circuit")
        Dim Drain4Enable As String = dtEditrecipetemp(0)("drain4_circuit")

        If Not d_vertol = VerificationTolerance Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters - Verification Tolerance (kPa) (+/-) Parameter Changed, from {VerificationTolerance} to {d_vertol}")
        End If

        If Not i_prepfilltime = PrepFill Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Prep Fill Time (s) Parameter Changed, from {PrepFill} to {i_prepfilltime}")
        End If
        If Not i_prepbleedtime = PrepBleed Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Prep Bleed Time (s) Parameter Changed, from {PrepBleed} to {i_prepbleedtime}")
        End If
        'If Not d_prepflow = PrepFlow Then
        '    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Flowrate (l/min) Parameter Changed, from {PrepFlow} to {d_prepflow}")
        'End If
        If Not d_preppressure = PrepBPress Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Back Pressure 2 (kPa) Parameter Changed, from {PrepBPress} to {d_preppressure}")
        End If
        If Not d_preppressuredrop = PrepPressDrop Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Back Pressure 1 (kPa) Parameter Changed, from {PrepPressDrop} to {d_preppressuredrop}")
        End If
        If Not i_preppressuredroptime = PrepPressDropTime Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Back Pressure 1 Time (s) Parameter Changed, from {PrepPressDropTime} to {i_preppressuredroptime}")
        End If
        If Not i_prepprefillstarttime = PrepPrefillStartTime Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Vent Start Time (s) Parameter Changed, from {PrepPrefillStartTime} to {i_prepprefillstarttime}")
        End If
        If Not i_prepprefilltime = PrepPrefillTime Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Vent Time (s) Parameter Changed, from {PrepPrefillTime} to {i_prepprefilltime}")
        End If
        If Not i_prepdrainstarttime = PrepDrainStartTime Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Drain Start Time (s) Parameter Changed, from {PrepDrainStartTime} to {i_prepdrainstarttime}")
        End If
        If Not i_prepdraintime = PrepDrainTime Then
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Preparation) - Drain Time (s) Parameter Changed, from {PrepDrainTime} to {i_prepdraintime}")
        End If

        If str_flush1enable = "Enable" Then
            If Not str_flush1enable = Flush1Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-1) - Flush-1 Enable (True)")
            End If
            'If Not i_flush1filltime = Flush1Fill Then
            '    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-1) - Flush-1 Fill Time (s) Parameter Changed, from {Flush1Fill} to {i_flush1filltime}")
            'End If
            'If Not i_flush1bleedtime = Flush1Bleed Then
            '    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-1) - Flush-1 Air Bleed Time (s) Parameter Changed, from {Flush1Bleed} to {i_flush1bleedtime}")
            'End If
            If Not d_flush1flow = Flush1Flow Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-1) - Flowrate (l/min) Parameter Changed, from {Flush1Flow} to {d_flush1flow}")
            End If
            If Not d_flush1flowtol = Flush1FlowTol Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-1) - Flowrate Tolerance (l/min) (+/-) Parameter Changed, from {Flush1FlowTol} to {d_flush1flowtol}")
            End If
            If Not d_flush1pressure = Flush1BPress Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-1) - Back Pressure (kPa) Parameter Changed, from {Flush1BPress} to {d_flush1pressure}")
            End If
            If Not i_flush1stabilize = Flush1Stabilize Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-1) - Flush-1 Stabilize Time (s) Parameter Changed, from {Flush1Stabilize} to {i_flush1stabilize}")
            End If
            If Not i_flush1time = Flush1Time Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-1) - Flush-1 Time (s) Parameter Changed, from {Flush1Time} to {i_flush1time}")
            End If
        Else
            If Not str_flush1enable = Flush1Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-1) - Flush-1 Enable (False)")
            End If
        End If

        If str_dptest1enable = "Enable" Then
            If Not str_dptest1enable = DP1Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP Test-1 Enable (True)")
            End If
        Else
            If Not str_dptest1enable = DP1Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP Test-1 Enable (False)")
            End If
        End If

        If str_dptest2enable = "Enable" Then
            If Not str_dptest2enable = DP2Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP Test-2 Enable (True)")
            End If
        Else
            If Not str_dptest2enable = DP2Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP Test-2 Enable (False)")
            End If
        End If

        If str_dptest1enable = "Enable" Or str_dptest2enable = "Enable" Then
            'If Not i_dptestfilltime = DPFill Then
            '    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP-Test Fill Time (s) Parameter Changed, from {DPFill} to {i_dptestfilltime}")
            'End If
            'If Not i_dptestbleedtime = DPBleed Then
            '    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP-Test Air Bleed Time (s) Parameter Changed, from {DPBleed} to {i_dptestbleedtime}")
            'End If
            If Not d_dptestflow = DPFlow Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - Flowrate (l/min) Parameter Changed, from {DPFlow} to {d_dptestflow}")
            End If
            If Not d_dptestflowtol = DPFlowTol Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - Flowrate Tolerance (l/min) (+/-) Parameter Changed, from {DPFlowTol} to {d_dptestflowtol}")
            End If
            If Not d_dptestpressure = DPBPress Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - Back Pressure (kPa) Parameter Changed, from {DPBPress} to {d_dptestpressure}")
            End If
            If Not i_dpteststabilize = DPStabilize Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP Stabilize Time (s) Parameter Changed, from {DPStabilize} to {i_dpteststabilize}")
            End If
            If Not i_dptesttime = DPTime Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP Time (s) Parameter Changed, from {DPTime} to {i_dptesttime}")
            End If
            If Not d_dptestlowlimit = DPLL Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP Lower Limit (kPa) Parameter Changed, from {DPLL} to {d_dptestlowlimit}")
            End If
            If Not d_dptestuplimit = DPUL Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - DP Upper Limit (kPa) Parameter Changed, from {DPUL} to {d_dptestuplimit}")
            End If
            If Not i_dptestpoints = DPTestPoints Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (DP Test) - Number of Test Points Parameter Changed, from {DPTestPoints} to {i_dptestpoints}")
            End If
        End If

        If str_flush2enable = "Enable" Then
            If Not str_flush2enable = Flush2Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-2) - Flush-2 Enable (True)")
            End If
            'If Not i_flush2filltime = Flush2Fill Then
            '    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-2) - Flush-2 Fill Time (s) Parameter Changed, from {Flush2Fill} to {i_flush2filltime}")
            'End If
            'If Not i_flush2bleedtime = Flush2Bleed Then
            '    EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-2) - Flush-2 Air Bleed Time (s) Parameter Changed, from {Flush2Bleed} to {i_flush2bleedtime}")
            'End If
            If Not d_flush2flow = Flush2Flow Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-2) - Flowrate (l/min) Parameter Changed, from {Flush2Flow} to {d_flush2flow}")
            End If
            If Not d_flush2flowtol = Flush2FlowTol Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-2) - Flowrate Tolerance (l/min) (+/-) Parameter Changed, from {Flush2FlowTol} to {d_flush2flowtol}")
            End If
            If Not d_flush2pressure = Flush2BPress Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-2) - Back Pressure (kPa) Parameter Changed, from {Flush2BPress} to {d_flush2pressure}")
            End If
            If Not i_flush2stabilize = Flush2Stabilize Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-2) - Flush-2 Stabilize Time (s) Parameter Changed, from {Flush2Stabilize} to {i_flush2stabilize}")
            End If
            If Not i_flush2time = Flush2Time Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-2) - Flush-2 Time (s) Parameter Changed, from {Flush2Time} to {i_flush2time}")
            End If
        Else
            If Not str_flush2enable = Flush2Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Flush-2) - Flush-2 Enable (False)")
            End If
        End If

        If str_drain1enable = "Enable" Then
            If Not str_drain1enable = Drain1Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-1) - Drain-1 Enable (True)")
            End If
            If Not d_drain1pressure = Drain1Press Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-1) - Drain-1 N2 Purge Pressure (kPa) Parameter Changed, from {Drain1Press} to {d_drain1pressure}")
            End If
            If Not i_drain1time = Drain1Time Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-1) - Drain-1 Time Parameter Changed, from {Drain1Time} to {i_drain1time}")
            End If
        Else
            If Not str_drain1enable = Drain1Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-1) - Drain-1 Enable (False)")
            End If
        End If

        If str_drain2enable = "Enable" Then
            If Not str_drain2enable = Drain2Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-2) - Drain-2 Enable (True)")
            End If
            If Not d_drain2pressure = Drain2Press Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-2) - Drain-2 N2 Purge Pressure (kPa) Parameter Changed, from {Drain2Press} to {d_drain2pressure}")
            End If
            If Not i_drain2time = Drain2Time Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-2) - Drain-2 Time Parameter Changed, from {Drain2Time} to {i_drain2time}")
            End If
        Else
            If Not str_drain2enable = Drain2Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-2) - Drain-2 Enable (False)")
            End If
        End If

        If str_drain3enable = "Enable" Then
            If Not str_drain3enable = Drain3Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-3) - Drain-3 Enable (True)")
            End If
            If Not d_drain3pressure = Drain3Press Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-3) - Drain-3 N2 Purge Pressure (kPa) Parameter Changed, from {Drain3Press} to {d_drain3pressure}")
            End If
            If Not i_drain3time = Drain3Time Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-3) - Drain-3 Time Parameter Changed, from {Drain3Time} to {i_drain3time}")
            End If
        Else
            If Not str_drain3enable = Drain3Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-3) - Drain-3 Enable (False)")
            End If
        End If

        If str_drain4enable = "Enable" Then
            If Not str_drain4enable = Drain4Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-4) - Drain-4 Enable (True)")
            End If
            If Not d_drain4pressure = Drain4Press Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-4) - Drain-4 N2 Purge Pressure (kPa) Parameter Changed, from {Drain4Press} to {d_drain4pressure}")
            End If
            If Not i_drain4time = Drain4Time Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-4) - Drain-4 Time Parameter Changed, from {Drain4Time} to {i_drain4time}")
            End If
        Else
            If Not str_drain4enable = Drain4Enable Then
                EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] Recipe Edit Parameters (Drain-4) - Drain-4 Enable (False)")
            End If
        End If
    End Sub
#End Region

#Region "Recipe Details"
    Private Sub LoadRecipeDetails(containSearch As Integer, recipeid As ComboBox, filtertype As ComboBox, partid As ComboBox, recipetype As ComboBox)
        Dim strrecipedetails As String = $"
            SELECT * FROM RecipeTable 
            LEFT JOIN PartTable ON RecipeTable.part_id=PartTable.part_id 
            LEFT JOIN FilterType ON PartTable.filter_type_id=FilterType.id 
            LEFT JOIN JigType ON PartTable.jig_type_id=JigType.id
            LEFT JOIN RecipeType ON RecipeTable.recipe_type_id=RecipeType.id             
            {IIf(cmbx_RcpDetailRecipeIDRev.Items.Count > 0, "", "
                WHERE RecipeTable.recipe_rev = ( 
                    SELECT MAX(recipe_rev) 
                    FROM RecipeTable t2 
                    WHERE RecipeTable.recipe_id = t2.recipe_id 
                ) 
            ")}
            ORDER BY RecipeTable.recipe_id ASC
        "
        Dim dtrecipetable As DataTable = SQL.ReadRecords(strrecipedetails)

        If containSearch = 1 Then
            Dim bstemp As New BindingSource
            bstemp.DataSource = dtrecipetable

            ' Declare FilterList Array
            Dim FilterList As New List(Of String)

            ' Check ComboBox Selection
            For Each cmbx As ComboBox In {recipeid, filtertype, partid, recipetype}
                If cmbx.Items.Count > 0 AndAlso cmbx.SelectedIndex > 0 Then
                    Dim selectedValue As String = DirectCast(cmbx.SelectedItem, KeyValuePair(Of String, String)).Value
                    Dim cellValue As String = ""

                    If cmbx Is recipeid Then
                        FilterList.Add($"recipe_id='{selectedValue}'")

                        ' Added later on to filter revisions
                        If cmbx_RcpDetailRecipeIDRev.Items.Count > 0 Then
                            FilterList.Add($"recipe_rev='{cmbx_RcpDetailRecipeIDRev.SelectedItem}'")
                        End If
                    End If
                    If cmbx Is filtertype Then
                        FilterList.Add($"filter_type='{selectedValue}'")
                    End If
                    If cmbx Is partid Then
                        FilterList.Add($"part_id='{selectedValue}'")
                    End If
                    If cmbx Is recipetype Then
                        FilterList.Add($"recipe_type='{selectedValue}'")
                    End If
                End If
            Next

            ' Declare FilterString
            Dim FilterString As String = ""

            ' Concatenate Filter String
            For i As Integer = 0 To FilterList.Count - 1
                If i = 0 Then
                    FilterString += FilterList(i)
                Else
                    FilterString += $" And {FilterList(i)}"
                End If
            Next
            bstemp.Filter = FilterString
            dgv_RecipeDetails.DataSource = bstemp

            If bstemp.Count = 0 Then
                RecipeMessage(40)
            End If
        Else
            dgv_RecipeDetails.DataSource = dtrecipetable
        End If

        With dgv_RecipeDetails
            ' Set DataGridView Properties
            .BackgroundColor = SystemColors.Window
            ''.RowHeadersVisible = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.ShowCellToolTips = False
            '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            ' Hide Unnecessary Columns
            .Columns("id").Visible = False
            .Columns("id1").Visible = False
            .Columns("id2").Visible = False
            .Columns("id3").Visible = False
            .Columns("id4").Visible = False
            .Columns("recipe_type_id").Visible = False
            .Columns("part_id1").Visible = False
            .Columns("filter_type_id").Visible = False
            .Columns("jig_type_id").Visible = False
            .Columns("user_created1").Visible = False
            .Columns("date_created").Visible = False
            .Columns("created_time").Visible = False
            .Columns("fitting_inlet").Visible = False
            .Columns("fitting_outlet").Visible = False
            .Columns("fitting_blank").Visible = False

            'Rename Columns
            .Columns("recipe_id").HeaderCell.Value = "Recipe ID"
            .Columns("part_id").HeaderCell.Value = "Part ID"
            .Columns("last_modified_by").HeaderCell.Value = "Last Mod. By"
            .Columns("last_modified_time").HeaderCell.Value = "Last Mod. Time"
            .Columns("user_created").HeaderCell.Value = "Created by"
            .Columns("Verification_tolerance").HeaderCell.Value = "Verification Tolerance +/-(kPa)"

            .Columns("prep_fill_time").HeaderCell.Value = "Prep. Fill Time (s)"
            .Columns("prep_bleed_time").HeaderCell.Value = "Prep. Bleed Time (s)"
            .Columns("prep_flowrate").HeaderCell.Value = "Prep. Flowrate (l/min)"
            .Columns("prep_flow_tolerance").HeaderCell.Value = "Prep. Flow Tolerance +/-(l/min)"
            .Columns("prep_back_pressure").HeaderCell.Value = "Prep. Back Pressure 1 (kPa)"
            .Columns("prep_pressure_drop").HeaderCell.Value = "Prep. Back Pressure 2 (kPa)"
            .Columns("prep_pressure_drop_time").HeaderCell.Value = "Prep. Back Pressure 1 Time (s)"
            .Columns("prep_prefill_start_time").HeaderCell.Value = "Prefill Start Time (s)"
            .Columns("prep_prefill_time").HeaderCell.Value = "Prefill Duration (s)"
            .Columns("prep_speed_mode").HeaderCell.Value = "Prep. Speed Mode"
            .Columns("prep_rpm1").HeaderCell.Value = "Prep. RPM-1"
            '.Columns("prep_rpm2").HeaderCell.Value = "Prep. RPM-2"

            .Columns("firstflush_circuit").HeaderCell.Value = "Flush-1 Circuit"
            '.Columns("firstflush_fill_time").HeaderCell.Value = "Flush-1 Fill Time (s)"
            '.Columns("firstflush_bleed_time").HeaderCell.Value = "Flush-1 Bleed Time (s)"
            .Columns("firstflush_flowrate").HeaderCell.Value = "Flush-1 Flowrate (l/min)"
            .Columns("firstflush_flow_tolerance").HeaderCell.Value = "Flush-1 Flow Tolerance +/-(l/min)"
            '.Columns("firstflush_back_pressure").HeaderCell.Value = "Flush-1 Pressure (kPa)"
            .Columns("firstflush_stabilize_time").HeaderCell.Value = "Flush-1 Stabilize Time (s)"
            .Columns("firstflush_time").HeaderCell.Value = "Flush-1 Time (s)"
            .Columns("firstflush_speed_mode").HeaderCell.Value = "Flush-1 Speed Mode"
            .Columns("firstflush_rpm").HeaderCell.Value = "Flush-1 RPM"
            .Columns("firstdp_circuit").HeaderCell.Value = "DP Test-1 Circuit"
            '.Columns("dp_fill_time").HeaderCell.Value = "DP Test Fill Time (s)"
            '.Columns("dp_bleed_time").HeaderCell.Value = "DP Test Bleed Time (s)"
            '.Columns("dp_flowrate").HeaderCell.Value = "DP Test Flowrate (l/min)"
            '.Columns("dp_flow_tolerance").HeaderCell.Value = "DP Test Flow Tolerance +/-(l/min)"
            '.Columns("dp_back_pressure").HeaderCell.Value = "DP Test Pressure (kPa)"
            .Columns("dp_stabilize_time").HeaderCell.Value = "DP Test Stabilize Time (s)"
            .Columns("dp_test_time").HeaderCell.Value = "DP Test Time (s)"
            .Columns("dp_lowerlimit").HeaderCell.Value = "DP Test Lower Limit (kPa)"
            .Columns("dp_upperlimit").HeaderCell.Value = "DP Test Upper Limit (Kpa)"
            .Columns("dp_testpoints").HeaderCell.Value = "DP Test Points"
            .Columns("dp_speed_mode").HeaderCell.Value = "DP Test Speed Mode"
            .Columns("dp_rpm").HeaderCell.Value = "DP Test RPM"
            .Columns("seconddp_circuit").HeaderCell.Value = "DP Test-2 Circuit"
            .Columns("secondflush_circuit").HeaderCell.Value = "Flush-2 Circuit"
            '.Columns("secondflush_fill_time").HeaderCell.Value = "Flush-2 Fill Time (s)"
            '.Columns("secondflush_bleed_time").HeaderCell.Value = "Flush-2 Bleed Time (s)"
            .Columns("secondflush_flowrate").HeaderCell.Value = "Flush-2 Flowrate (l/min)"
            .Columns("secondflush_flow_tolerance").HeaderCell.Value = "Flush-2 Flow Tolerance +/-(l/min)"
            '.Columns("secondflush_back_pressure").HeaderCell.Value = "Flush-2 Pressure (kPa)"
            .Columns("secondflush_stabilize_time").HeaderCell.Value = "Flush-2 Stabilize Time (s)"
            .Columns("secondflush_time").HeaderCell.Value = "Flush-2 Time (s)"
            .Columns("secondflush_speed_mode").HeaderCell.Value = "Flush-2 Speed Mode"
            .Columns("secondflush_rpm").HeaderCell.Value = "Flush-2 RPM"
            .Columns("drain1_circuit").HeaderCell.Value = "Drain-1 Circuit"
            .Columns("drain1_back_pressure").HeaderCell.Value = "Drain-1 Pressure (kPa)"
            .Columns("drain1_time").HeaderCell.Value = "Drain-1 Time (s)"
            .Columns("drain2_circuit").HeaderCell.Value = "Drain-2 Circuit"
            .Columns("drain2_back_pressure").HeaderCell.Value = "Drain-2 Pressure (kPa)"
            .Columns("drain2_time").HeaderCell.Value = "Drain-2 Time (s)"
            .Columns("drain3_circuit").HeaderCell.Value = "Drain-3 Circuit"
            .Columns("drain3_back_pressure").HeaderCell.Value = "Drain-3 Pressure (kPa)"
            .Columns("drain3_time").HeaderCell.Value = "Drain-3 Time (s)"
            .Columns("drain4_circuit").HeaderCell.Value = "Drain-4 Circuit"
            .Columns("drain4_back_pressure").HeaderCell.Value = "Drain-4 Pressure (kPa)"
            .Columns("drain4_time").HeaderCell.Value = "Drain-4 Time (s)"
            .Columns("filter_type").HeaderCell.Value = "Filter Type"
            .Columns("jig_description").HeaderCell.Value = "Jig Type"
            .Columns("recipe_type").HeaderCell.Value = "Recipe Type"
            .Columns("recipe_rev").HeaderCell.Value = "Recipe Rev."
            .Columns("fitting_inlet").HeaderCell.Value = "Inlet Fitting"
            .Columns("fitting_outlet").HeaderCell.Value = "Outlet Fitting"
            .Columns("fitting_blank").HeaderCell.Value = "Blank Fitting"

            'Set Column Width
            .Columns("recipe_id").Width = 140
            .Columns("part_id").Width = 140
            .Columns("last_modified_by").Width = 100
            .Columns("last_modified_time").Width = 140
            .Columns("user_created").Width = 100
            .Columns("Verification_tolerance").Width = 80

            .Columns("prep_fill_time").Width = 60
            .Columns("prep_bleed_time").Width = 60
            .Columns("prep_flowrate").Width = 60
            .Columns("prep_flow_tolerance").Width = 70
            .Columns("prep_back_pressure").Width = 60
            .Columns("prep_pressure_drop").Width = 60
            .Columns("prep_pressure_drop_time").Width = 60
            .Columns("prep_prefill_start_time").Width = 60
            .Columns("prep_prefill_time").Width = 60
            .Columns("prep_speed_mode").Width = 60
            .Columns("prep_rpm1").Width = 60
            '.Columns("prep_rpm2").Width = 60

            .Columns("firstflush_circuit").Width = 70
            '.Columns("firstflush_fill_time").Width = 60
            '.Columns("firstflush_bleed_time").Width = 60
            .Columns("firstflush_flowrate").Width = 60
            .Columns("firstflush_flow_tolerance").Width = 70
            '.Columns("firstflush_back_pressure").Width = 60
            .Columns("firstflush_stabilize_time").Width = 60
            .Columns("firstflush_time").Width = 60
            .Columns("firstflush_speed_mode").Width = 60
            .Columns("firstflush_rpm").Width = 60
            .Columns("firstdp_circuit").Width = 70
            '.Columns("dp_fill_time").Width = 60
            '.Columns("dp_bleed_time").Width = 60
            '.Columns("dp_flowrate").Width = 70
            '.Columns("dp_flow_tolerance").Width = 70
            '.Columns("dp_back_pressure").Width = 70
            .Columns("dp_stabilize_time").Width = 70
            .Columns("dp_test_time").Width = 70
            .Columns("dp_lowerlimit").Width = 70
            .Columns("dp_upperlimit").Width = 70
            .Columns("dp_testpoints").Width = 70
            .Columns("dp_speed_mode").Width = 70
            .Columns("dp_rpm").Width = 70
            .Columns("seconddp_circuit").Width = 70
            .Columns("secondflush_circuit").Width = 70
            '.Columns("secondflush_fill_time").Width = 60
            '.Columns("secondflush_bleed_time").Width = 60
            .Columns("secondflush_flowrate").Width = 60
            .Columns("secondflush_flow_tolerance").Width = 70
            '.Columns("secondflush_back_pressure").Width = 60
            .Columns("secondflush_stabilize_time").Width = 60
            .Columns("secondflush_time").Width = 60
            .Columns("secondflush_speed_mode").Width = 60
            .Columns("secondflush_rpm").Width = 60
            .Columns("drain1_circuit").Width = 70
            .Columns("drain1_back_pressure").Width = 60
            .Columns("drain1_time").Width = 60
            .Columns("drain2_circuit").Width = 70
            .Columns("drain2_back_pressure").Width = 60
            .Columns("drain2_time").Width = 60
            .Columns("drain3_circuit").Width = 70
            .Columns("drain3_back_pressure").Width = 60
            .Columns("drain3_time").Width = 60
            .Columns("drain4_circuit").Width = 70
            .Columns("drain4_back_pressure").Width = 60
            .Columns("drain4_time").Width = 60
            .Columns("filter_type").Width = 90
            .Columns("jig_description").Width = 60
            .Columns("recipe_type").Width = 90
            .Columns("recipe_rev").Width = 60
            .Columns("fitting_inlet").Width = 60
            .Columns("fitting_outlet").Width = 60
            .Columns("fitting_blank").Width = 60

            'Header Cell Alignment
            .Columns("recipe_id").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("part_id").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("last_modified_by").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("last_modified_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("user_created").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Verification_tolerance").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("prep_fill_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_bleed_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_flowrate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_flow_tolerance").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_back_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_pressure_drop").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_pressure_drop_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_prefill_start_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_prefill_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_speed_mode").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("prep_rpm1").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("prep_rpm2").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("firstflush_circuit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("firstflush_fill_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("firstflush_bleed_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("firstflush_flowrate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("firstflush_flow_tolerance").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("firstflush_back_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("firstflush_stabilize_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("firstflush_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("firstflush_speed_mode").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("firstflush_rpm").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("firstdp_circuit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("dp_fill_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("dp_bleed_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("dp_flowrate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("dp_flow_tolerance").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("dp_back_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("dp_stabilize_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("dp_test_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("dp_lowerlimit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("dp_upperlimit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("dp_testpoints").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("dp_speed_mode").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("dp_rpm").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("seconddp_circuit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("secondflush_circuit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("secondflush_fill_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("secondflush_bleed_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("secondflush_flowrate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("secondflush_flow_tolerance").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("secondflush_back_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("secondflush_stabilize_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("secondflush_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("secondflush_speed_mode").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("secondflush_rpm").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain1_circuit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain1_back_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain1_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain2_circuit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain2_back_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain2_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain3_circuit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain3_back_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain3_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain4_circuit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain4_back_pressure").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("drain4_time").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("filter_type").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("jig_description").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("recipe_type").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("recipe_rev").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("fitting_inlet").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("fitting_outlet").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("fitting_blank").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Header Cell Font Bold
            .Columns("recipe_id").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("part_id").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("last_modified_by").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("last_modified_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("user_created").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("Verification_tolerance").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)

            .Columns("prep_fill_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_bleed_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_flowrate").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_flow_tolerance").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_back_pressure").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_pressure_drop").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_pressure_drop_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_prefill_start_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_prefill_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_speed_mode").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("prep_rpm1").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("prep_rpm2").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)

            .Columns("firstflush_circuit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("firstflush_fill_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("firstflush_bleed_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("firstflush_flowrate").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("firstflush_flow_tolerance").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("firstflush_back_pressure").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("firstflush_stabilize_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("firstflush_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("firstflush_speed_mode").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("firstflush_rpm").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("firstdp_circuit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("dp_fill_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("dp_bleed_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("dp_flowrate").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("dp_flow_tolerance").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("dp_back_pressure").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("dp_stabilize_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("dp_test_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("dp_lowerlimit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("dp_upperlimit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("dp_testpoints").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("dp_speed_mode").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("dp_rpm").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("seconddp_circuit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("secondflush_circuit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("secondflush_fill_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("secondflush_bleed_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("secondflush_flowrate").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("secondflush_flow_tolerance").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            '.Columns("secondflush_back_pressure").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("secondflush_stabilize_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("secondflush_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("secondflush_speed_mode").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("secondflush_rpm").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain1_circuit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain1_back_pressure").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain1_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain2_circuit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain2_back_pressure").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain2_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain3_circuit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain3_back_pressure").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain3_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain4_circuit").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain4_back_pressure").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("drain4_time").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("filter_type").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("jig_description").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("recipe_type").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("recipe_rev").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("fitting_inlet").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("fitting_outlet").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)
            .Columns("fitting_blank").HeaderCell.Style.Font = New Font(dgv_RecipeDetails.Font, FontStyle.Bold)

            'Order the column as per requirement
            .Columns("recipe_id").DisplayIndex = 0
            .Columns("recipe_rev").DisplayIndex = 1
            .Columns("part_id").DisplayIndex = 2

            .Columns("filter_type").DisplayIndex = 3
            .Columns("jig_description").DisplayIndex = 4
            .Columns("recipe_type").DisplayIndex = 5

            .Columns("last_modified_by").DisplayIndex = 6
            .Columns("last_modified_time").DisplayIndex = 7
            .Columns("user_created").DisplayIndex = 8
            .Columns("Verification_tolerance").DisplayIndex = 9

            .Columns("prep_fill_time").DisplayIndex = 10
            .Columns("prep_bleed_time").DisplayIndex = 11
            .Columns("prep_flowrate").DisplayIndex = 12
            .Columns("prep_flow_tolerance").DisplayIndex = 12 + 1
            .Columns("prep_back_pressure").DisplayIndex = 13 + 1
            .Columns("prep_pressure_drop").DisplayIndex = 14 + 1
            .Columns("prep_pressure_drop_time").DisplayIndex = 15 + 1
            .Columns("prep_prefill_start_time").DisplayIndex = 16 + 1
            .Columns("prep_prefill_time").DisplayIndex = 17 + 1
            .Columns("prep_speed_mode").DisplayIndex = 18 + 1
            .Columns("prep_rpm1").DisplayIndex = 19 + 1
            '.Columns("prep_rpm2").DisplayIndex = 20 + 1

            .Columns("firstflush_circuit").DisplayIndex = 10 + 12
            '.Columns("firstflush_fill_time").DisplayIndex = 11 + 12
            '.Columns("firstflush_bleed_time").DisplayIndex = 12 + 12
            .Columns("firstflush_flowrate").DisplayIndex = 13 + 12
            .Columns("firstflush_flow_tolerance").DisplayIndex = 14 + 12
            '.Columns("firstflush_back_pressure").DisplayIndex = 15 + 12
            .Columns("firstflush_stabilize_time").DisplayIndex = 16 + 12
            .Columns("firstflush_time").DisplayIndex = 17 + 12
            .Columns("firstflush_speed_mode").DisplayIndex = 17 + 13
            .Columns("firstflush_rpm").DisplayIndex = 17 + 14
            .Columns("firstdp_circuit").DisplayIndex = 18 + 14
            '.Columns("dp_fill_time").DisplayIndex = 19 + 13
            '.Columns("dp_bleed_time").DisplayIndex = 20 + 13
            '.Columns("dp_flowrate").DisplayIndex = 21 + 13
            '.Columns("dp_flow_tolerance").DisplayIndex = 22 + 13
            '.Columns("dp_back_pressure").DisplayIndex = 23 + 13
            .Columns("dp_stabilize_time").DisplayIndex = 24 + 13
            .Columns("dp_test_time").DisplayIndex = 25 + 13
            .Columns("dp_lowerlimit").DisplayIndex = 26 + 13
            .Columns("dp_upperlimit").DisplayIndex = 27 + 13
            .Columns("dp_testpoints").DisplayIndex = 28 + 13
            .Columns("dp_speed_mode").DisplayIndex = 28 + 14
            .Columns("dp_rpm").DisplayIndex = 28 + 15
            .Columns("seconddp_circuit").DisplayIndex = 29 + 15
            .Columns("secondflush_circuit").DisplayIndex = 31 + 14
            '.Columns("secondflush_fill_time").DisplayIndex = 31 + 14
            '.Columns("secondflush_bleed_time").DisplayIndex = 32 + 14
            .Columns("secondflush_flowrate").DisplayIndex = 33 + 14
            .Columns("secondflush_flow_tolerance").DisplayIndex = 34 + 14
            '.Columns("secondflush_back_pressure").DisplayIndex = 35 + 14
            .Columns("secondflush_stabilize_time").DisplayIndex = 36 + 14
            .Columns("secondflush_time").DisplayIndex = 37 + 14
            .Columns("secondflush_speed_mode").DisplayIndex = 37 + 15
            .Columns("secondflush_rpm").DisplayIndex = 37 + 16
            .Columns("drain1_circuit").DisplayIndex = 38 + 16
            .Columns("drain1_back_pressure").DisplayIndex = 39 + 16
            .Columns("drain1_time").DisplayIndex = 40 + 16
            .Columns("drain2_circuit").DisplayIndex = 41 + 16
            .Columns("drain2_back_pressure").DisplayIndex = 42 + 16
            .Columns("drain2_time").DisplayIndex = 43 + 16
            .Columns("drain3_circuit").DisplayIndex = 44 + 16
            .Columns("drain3_back_pressure").DisplayIndex = 45 + 16
            .Columns("drain3_time").DisplayIndex = 46 + 16
            .Columns("drain4_circuit").DisplayIndex = 47 + 16
            .Columns("drain4_back_pressure").DisplayIndex = 48 + 16
            .Columns("drain4_time").DisplayIndex = 49 + 16
            .Columns("fitting_inlet").DisplayIndex = 50 + 16
            .Columns("fitting_outlet").DisplayIndex = 51 + 16
            .Columns("fitting_blank").DisplayIndex = 52 + 16

            ' Format Date
            With .Columns("last_modified_time")
                .DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
            End With

            ''Wrap content
            dgv_RecipeDetails.ColumnHeadersHeight = 100
        End With

        FormMain.dgvClearSelection(dgv_RecipeDetails)
    End Sub

    Private Sub btn_Reset_Click(sender As Object, e As EventArgs) Handles btn_Reset.Click
        cmbx_RcpDetailRecipeID.SelectedIndex = 0
        cmbx_RcpDetailFilter.SelectedIndex = 0
        cmbx_RcpDetailPart.SelectedIndex = 0
        cmbx_RcpDetailType.SelectedIndex = 0
        LoadRecipeDetails(0, Nothing, Nothing, Nothing, Nothing)
    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        LoadRecipeDetails(1, cmbx_RcpDetailRecipeID, cmbx_RcpDetailFilter, cmbx_RcpDetailPart, cmbx_RcpDetailType)
    End Sub

    Private Sub btn_RcpDetailEdit_Click(sender As Object, e As EventArgs) Handles btn_RcpDetailEdit.Click
        Dim dgv As DataGridView = dgv_RecipeDetails

        If dgv.SelectedCells.Count > 0 Then
            Dim selectedCell As DataGridViewCell = dgv.SelectedCells(0)

            'Dim columnIndex As Integer = selectedCell.ColumnIndex
            Dim rowIndex As Integer = selectedCell.RowIndex

            If rowIndex >= 0 Then
                Dim recipeid As String = dgv.Rows(rowIndex).Cells("recipe_id").Value 'row.Cells("recipe_id").Value
                Dim partid As String = dgv.Rows(rowIndex).Cells("part_id").Value 'row.Cells("part_id").Value
                Dim filtertype As String = dgv.Rows(rowIndex).Cells("filter_type").Value 'row.Cells("filter_type").Value
                tabctrl_RecipeCtrl.SelectedTab = tabpg_Edit
                cmbx_RcpEditFilterType.Text = filtertype
                cmbx_RcpEditPartID.Text = partid
                cmbx_RcpEditRecipeID.Text = recipeid
            End If
        End If

        'If dgv_RecipeDetails.SelectedRows.Count > 0 Then
        '    Dim row As DataGridViewRow = dgv_RecipeDetails.CurrentRow
        '    Dim recipeid As String = row.Cells("recipe_id").Value
        '    Dim partid As String = row.Cells("part_id").Value
        '    Dim filtertype As String = row.Cells("filter_type").Value
        '    tabctrl_RecipeCtrl.SelectedTab = tabpg_Edit
        '    cmbx_RcpEditFilterType.Text = filtertype
        '    cmbx_RcpEditPartID.Text = partid
        '    cmbx_RcpEditRecipeID.Text = recipeid
        'End If
    End Sub

    Private Sub btn_RcpDetailExport_Click(sender As Object, e As EventArgs) Handles btn_RcpDetailExport.Click
        ' Convert Visible DataGridView Columns To DataTable
        Dim dt As DataTable = GetVisibleColumnsDataTable(dgv_RecipeDetails)    'GetVisibleColumnsDataTable(dgv_recipedetails)

        ' Get Path
        Dim Filepath As String = $"{PublicVariables.CSVPathToRecipeDetails}RecipeDetails_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv"

        ' Export With Return
        Dim ReturnValue As String = ExportDataTableToCsv(dt, Filepath, PublicVariables.CSVDelimiterResultSummary)

        ' Check Return State
        If ReturnValue = "True" Then
            RecipeMessage(41)
            EventLog.EventLogger.Log($"{PublicVariables.LoginUserName}", $"[Recipe Management] CSV Export Success ""{Filepath}""")
        ElseIf ReturnValue = "Missing" Then
            RecipeMessage(52)
        ElseIf ReturnValue = "False" Then
            RecipeMessage(42)
        End If
    End Sub
#End Region

#Region "Tab Control"
    Private Sub tabctrl_RecipeCtrl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabctrl_RecipeCtrl.SelectedIndexChanged
        CurrentTabPage = tabctrl_RecipeCtrl.SelectedTab

        If CurrentTabPage.Text = "Edit" Then
            txtbx_RcpEditVerTol.Enabled = False
            txtbx_RcpEditDPFlow.Enabled = False
            txtbx_RcpEditDPFlowTol.Enabled = False

            txtbx_RcpEditPrepFill.Enabled = False
            txtbx_RcpEditPrepPrefillStartTime.Enabled = False
            txtbx_RcpEditPrepPrefillTime.Enabled = False
            txtbx_RcpEditPrepBleed.Enabled = False
            txtbx_RcpEditPrepPressureDrop.Enabled = False
            txtbx_RcpEditPrepPressureDropTime.Enabled = False
            txtbx_RcpEditPrepPressureDrop.Enabled = False
            panel_RcpEditPrepPumpMode.Enabled = False
            txtbx_RcpEditPrepRPM.Enabled = False

            txtbx_RcpEditFlush1Flow.Enabled = False
            txtbx_RcpEditFlush1FlowTol.Enabled = False
            txtbx_RcpEditFlush1Stabilize.Enabled = False
            txtbx_RcpEditFlush1Time.Enabled = False
            panel_RcpEditFlush1PumpMode.Enabled = False
            txtbx_RcpEditFlush1RPM.Enabled = False

            txtbx_RcpEditFlush2Flow.Enabled = False
            txtbx_RcpEditFlush2FlowTol.Enabled = False
            txtbx_RcpEditFlush2Stabilize.Enabled = False
            txtbx_RcpEditFlush2Time.Enabled = False
            panel_RcpEditFlush2PumpMode.Enabled = False
            txtbx_RcpEditFlush2RPM.Enabled = False

            txtbx_RcpEditDPStabilize.Enabled = False
            txtbx_RcpEditDPTime.Enabled = False
            txtbx_RcpEditDPLowLimit.Enabled = False
            txtbx_RcpEditDPUpLimit.Enabled = False
            txtbx_RcpEditDPPoints.Enabled = False
            panel_RcpEditDPTestPumpMode.Enabled = False
            txtbx_RcpEditDPTestRPM.Enabled = False

            txtbx_RcpEditDrain1Pressure.Enabled = False
            txtbx_RcpEditDrain1Time.Enabled = False

            txtbx_RcpEditDrain2Pressure.Enabled = False
            txtbx_RcpEditDrain2Time.Enabled = False

            txtbx_RcpEditDrain3Pressure.Enabled = False
            txtbx_RcpEditDrain3Time.Enabled = False

            txtbx_RcpEditDrain4Pressure.Enabled = False
            txtbx_RcpEditDrain4Time.Enabled = False

            checkbx_EditFlush1.Enabled = False
            checkbx_EditFlush2.Enabled = False
            checkbx_EditDPTest1.Enabled = False
            checkbx_EditDPTest2.Enabled = False
            checkbx_EditDrain1.Enabled = False
            checkbx_EditDrain2.Enabled = False
            checkbx_EditDrain3.Enabled = False
            checkbx_EditDrain4.Enabled = False

            txtbx_RcpEditVerTol.Text = Nothing
            txtbx_RcpEditDPFlow.Text = Nothing
            txtbx_RcpEditDPFlowTol.Text = Nothing

            txtbx_RcpEditPrepFill.Text = Nothing
            txtbx_RcpEditPrepPrefillStartTime.Text = Nothing
            txtbx_RcpEditPrepPrefillTime.Text = Nothing
            txtbx_RcpEditPrepBleed.Text = Nothing
            txtbx_RcpEditPrepPressureDrop.Text = Nothing
            txtbx_RcpEditPrepPressureDropTime.Text = Nothing
            txtbx_RcpEditPrepPressureDrop.Text = Nothing
            rdbtn_RcpEditPrepPumpProcess.Checked = True
            txtbx_RcpEditPrepRPM.Text = Nothing

            txtbx_RcpEditFlush1Flow.Text = Nothing
            txtbx_RcpEditFlush1FlowTol.Text = Nothing
            txtbx_RcpEditFlush1Stabilize.Text = Nothing
            txtbx_RcpEditFlush1Time.Text = Nothing
            rdbtn_RcpEditFlush1PumpProcess.Checked = True
            txtbx_RcpEditFlush1RPM.Text = Nothing

            txtbx_RcpEditFlush2Flow.Text = Nothing
            txtbx_RcpEditFlush2FlowTol.Text = Nothing
            txtbx_RcpEditFlush2Stabilize.Text = Nothing
            txtbx_RcpEditFlush2Time.Text = Nothing
            rdbtn_RcpEditFlush2PumpProcess.Checked = True
            txtbx_RcpEditFlush2RPM.Text = Nothing

            txtbx_RcpEditDPStabilize.Text = Nothing
            txtbx_RcpEditDPTime.Text = Nothing
            txtbx_RcpEditDPLowLimit.Text = Nothing
            txtbx_RcpEditDPUpLimit.Text = Nothing
            txtbx_RcpEditDPPoints.Text = Nothing
            rdbtn_RcpEditDPTestPumpProcess.Checked = True
            txtbx_RcpEditDPTestRPM.Text = Nothing

            txtbx_RcpEditDrain1Pressure.Text = Nothing
            txtbx_RcpEditDrain1Time.Text = Nothing

            txtbx_RcpEditDrain2Pressure.Text = Nothing
            txtbx_RcpEditDrain2Time.Text = Nothing

            txtbx_RcpEditDrain3Pressure.Text = Nothing
            txtbx_RcpEditDrain3Time.Text = Nothing

            txtbx_RcpEditDrain4Pressure.Text = Nothing
            txtbx_RcpEditDrain4Time.Text = Nothing

            checkbx_EditFlush1.Checked = False
            checkbx_EditFlush2.Checked = False
            checkbx_EditDPTest1.Checked = False
            checkbx_EditDPTest2.Checked = False
            checkbx_EditDrain1.Checked = False
            checkbx_EditDrain2.Checked = False
            checkbx_EditDrain3.Checked = False
            checkbx_EditDrain4.Checked = False

            cmbx_RcpEditFilterType.SelectedIndex = 0
            cmbx_RcpDupSelRecipe.SelectedIndex = 0
        End If

        If CurrentTabPage.Text = "Create" Then
            cmbx_RcpCreateFilterType.SelectedIndex = 0
            cmbx_PartCreateFilterType.SelectedIndex = 0
        End If

        If CurrentTabPage.Text = "Delete" Then
            cmbx_RcpDeleteFilterType.SelectedIndex = 0
            cmbx_PartDeleteFilterType.SelectedIndex = 0
        End If
    End Sub
#End Region

#Region "Form Closing"
    Private Sub btn_Home_Click(sender As Object, e As EventArgs) Handles btn_Home.Click
        If txtbx_RcpEditVerTol.Enabled = True Or txtbx_RcpCreateVerTol.Enabled = True Then
            If RecipeMessage(15, "Recipe Edit/Create Tab") = DialogResult.Yes Then
                Me.Close()
            End If
        End If

        If txtbx_RcpEditVerTol.Enabled = False And txtbx_RcpCreateVerTol.Enabled = False Then
            Me.Close()
        End If
    End Sub

    Private Sub FormRecipeManagement_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Recipetimer.Enabled = False
    End Sub
#End Region

    Private Sub picbx_Icon_Click(sender As Object, e As EventArgs) Handles picbx_Icon.Click
        FormPixel.Show()
    End Sub

    Private Sub cmbx_RcpDetailRecipeID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbx_RcpDetailRecipeID.SelectedIndexChanged
        cmbx_RcpDetailRecipeIDRev.Items.Clear()

        If cmbx_RcpDetailRecipeID.SelectedIndex > 0 Then
            Dim dtRecipeTbl As DataTable = SQL.ReadRecords($"
                SELECT DISTINCT recipe_rev FROM RecipeTable 
                WHERE recipe_id='{DirectCast(cmbx_RcpDetailRecipeID.SelectedItem, KeyValuePair(Of String, String)).Value}' 
                ORDER BY recipe_rev ASC
            ")

            If dtRecipeTbl.Rows.Count > 0 Then
                ' Add Revisions To ComboBox List
                For i As Integer = 0 To dtRecipeTbl.Rows.Count - 1
                    cmbx_RcpDetailRecipeIDRev.Items.Add(dtRecipeTbl(i)("recipe_rev"))
                Next

                With cmbx_RcpDetailRecipeIDRev
                    .Enabled = True
                    .SelectedIndex = dtRecipeTbl.Rows.Count - 1
                End With
            End If
        Else
            cmbx_RcpDetailRecipeIDRev.Enabled = False
        End If
    End Sub

    Private Sub GetFittingType()
        InitializeFittingType()
        LoadFittingID()
        LoadRecipeFittingSelection()
    End Sub

    Private Sub LoadRecipeFittingSelection()
        Dim cmbxArr1 As ComboBox() = {ComboBox9, ComboBox8, ComboBox3, ComboBox4}
        Dim cmbxArr2 As ComboBox() = {ComboBox7, ComboBox6}
        Dim SelectedType As String = ComboBox1.SelectedItem

        Dim dtFittingTbl As DataTable = SQL.ReadRecords($"
            SELECT * FROM FittingType 
            WHERE fitting_type='Fittings' 
            ORDER BY fitting_name ASC
        ")

        Dim dtBlankTbl As DataTable = SQL.ReadRecords($"
            SELECT * FROM FittingType 
            WHERE fitting_type='Blanks' 
            ORDER BY fitting_name ASC
        ")

        For Each cmbx As ComboBox In cmbxArr1
            cmbx.Items.Clear()
            If dtFittingTbl.Rows.Count > 0 Then
                For i As Integer = 0 To dtFittingTbl.Rows.Count - 1
                    cmbx.Items.Add(dtFittingTbl(i)("fitting_name"))
                Next
                cmbx.SelectedIndex = 0
            End If
        Next

        For Each cmbx As ComboBox In cmbxArr2
            cmbx.Items.Clear()
            If dtBlankTbl.Rows.Count > 0 Then
                For i As Integer = 0 To dtBlankTbl.Rows.Count - 1
                    cmbx.Items.Add(dtBlankTbl(i)("fitting_name"))
                Next
                cmbx.SelectedIndex = 0
            End If
        Next
    End Sub

    Private Sub InitializeFittingType()
        Dim cmbxArr As ComboBox() = {ComboBox5, ComboBox1}

        For Each cmbx As ComboBox In cmbxArr
            cmbx.SelectedIndex = 0
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.Click
        Select Case ComboBox1.SelectedItem
            Case "Fittings"
                Label3.Text = "Fitting ID :"
            Case "Blanks"
                Label3.Text = "Blank ID :"
        End Select
        LoadFittingID()
        LoadRecipeFittingSelection()
    End Sub

    Private Sub LoadFittingID()
        Dim cmbxArr As ComboBox() = {ComboBox2}
        Dim SelectedType As String = ComboBox1.SelectedItem

        Dim dtFittingTbl As DataTable = SQL.ReadRecords($"
            SELECT * FROM FittingType 
            WHERE fitting_type='{SelectedType}' 
            ORDER BY fitting_name ASC
        ")

        For Each cmbx As ComboBox In cmbxArr
            cmbx.Items.Clear()
            If dtFittingTbl.Rows.Count > 0 Then
                For i As Integer = 0 To dtFittingTbl.Rows.Count - 1
                    cmbx.Items.Add(dtFittingTbl(i)("fitting_name"))
                Next
                cmbx.SelectedIndex = 0
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SelectedType As String = ComboBox5.SelectedItem
        Dim FittingNameInput As String = TextBox1.Text.Trim

        Dim dtFittingTbl As DataTable = SQL.ReadRecords($"
            SELECT * FROM FittingType 
            WHERE fitting_type='{SelectedType}' 
            AND fitting_name='{FittingNameInput}' 
        ")

        If dtFittingTbl.Rows.Count > 0 Then
            MsgBox("Fitting Creation Failed, Fitting Exists.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Warning")
        Else
            Dim parameters As New Dictionary(Of String, Object) From {
                {"fitting_type", SelectedType},
                {"fitting_name", FittingNameInput},
                {"user_updated", PublicVariables.LoginUserName},
                {"date_updated", DateTime.Now.ToString("s")} 'lbl_DateTimeClock.Text}
            }
            Dim InsertRecord As Integer = SQL.InsertRecord("FittingType", parameters)

            If InsertRecord > 0 Then
                LoadFittingID()
                LoadRecipeFittingSelection()
                MsgBox("Fitting Creation Success.", MsgBoxStyle.Information Or MsgBoxStyle.OkCancel, "Information")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SelectedType As String = ComboBox1.SelectedItem
        Dim SelectedID As String = ComboBox2.SelectedItem

        If ComboBox2.Items.Count > 0 Then
            If ComboBox2.SelectedIndex >= 0 Then
                Dim DeleteRecord As Integer = SQL.DeleteRecord("FittingType", $"fitting_type = '{SelectedType}' AND fitting_name = '{SelectedID}'")

                If DeleteRecord > 0 Then
                    LoadFittingID()
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        Select Case ComboBox1.SelectedItem
            Case "Fittings"
                Label8.Text = "Fitting ID :"
            Case "Blanks"
                Label8.Text = "Blank ID :"
        End Select
        TextBox1.Text = ""
    End Sub

    Private Sub txtbx_Dec_LostFocus(sender As Object, e As EventArgs) Handles _
                    txtbx_RcpCreateVerTol.LostFocus,
                    txtbx_RcpCreateDPFlow.LostFocus,
                    txtbx_RcpCreatePrepPressureDrop.LostFocus,
                    txtbx_RcpCreateFlush1Flow.LostFocus,
                    txtbx_RcpCreateFlush1FlowTol.LostFocus,
                    txtbx_RcpCreateDPLowLimit.LostFocus,
                    txtbx_RcpCreateDPUpLimit.LostFocus,
                    txtbx_RcpCreateFlush2Flow.LostFocus,
                    txtbx_RcpCreateFlush2FlowTol.LostFocus,
                    txtbx_RcpCreateDrain1Pressure.LostFocus,
                    txtbx_RcpCreateDrain2Pressure.LostFocus,
                    txtbx_RcpCreateDrain3Pressure.LostFocus,
                    txtbx_RcpEditVerTol.LostFocus,
                    txtbx_RcpEditDPFlow.LostFocus,
                    txtbx_RcpEditPrepPressureDrop.LostFocus,
                    txtbx_RcpEditFlush1Flow.LostFocus,
                    txtbx_RcpEditFlush1FlowTol.LostFocus,
                    txtbx_RcpEditDPLowLimit.LostFocus,
                    txtbx_RcpEditDPUpLimit.LostFocus,
                    txtbx_RcpEditFlush2Flow.LostFocus,
                    txtbx_RcpEditFlush2FlowTol.LostFocus,
                    txtbx_RcpEditDrain1Pressure.LostFocus,
                    txtbx_RcpEditDrain2Pressure.LostFocus,
                    txtbx_RcpEditDrain3Pressure.LostFocus,
                    txtbx_RcpEditDrain4Pressure.LostFocus

        Dim txtbxValidate As TextBox = DirectCast(sender, TextBox)

        Dim txtbxInDec As Decimal = 0

        If Decimal.TryParse(txtbxValidate.Text, txtbxInDec) Then
            txtbxValidate.Text = txtbxInDec.ToString("F1")
        Else
            txtbxValidate.Text = "0.0"
        End If
    End Sub

    Private Sub rdbtn_RcpCreatePumpMode_CheckedChanged(sender As Object, e As EventArgs) Handles _
    rdbtn_RcpCreatePrepPumpProcess.CheckedChanged, rdbtn_RcpCreateFlush1PumpProcess.CheckedChanged, rdbtn_RcpCreateFlush2PumpProcess.CheckedChanged, rdbtn_RcpCreateDPTestPumpProcess.CheckedChanged,
    rdbtn_RcpCreatePrepPumpSpeed.CheckedChanged, rdbtn_RcpCreateFlush1PumpSpeed.CheckedChanged, rdbtn_RcpCreateFlush2PumpSpeed.CheckedChanged, rdbtn_RcpCreateDPTestPumpSpeed.CheckedChanged

        If rdbtn_RcpCreatePrepPumpSpeed.Checked Then
            If txtbx_RcpCreatePrepRPM.Enabled = False Then
                str_prepspeedenable = "Enable"
                i_preprpm1 = nom_i_preprpm1
                If cmbx_RcpCreateType.SelectedIndex > 0 Then
                    With txtbx_RcpCreatePrepRPM
                        .Enabled = True
                        .Text = i_preprpm1
                    End With
                End If
            End If
        Else
            str_prepspeedenable = "Disable"
            i_preprpm1 = 0
            With txtbx_RcpCreatePrepRPM
                .Enabled = False
                .Text = Nothing
            End With
        End If
        If rdbtn_RcpCreateFlush1PumpSpeed.Checked Then
            If txtbx_RcpCreateFlush1RPM.Enabled = False And checkbx_CreateFlush1.Checked = True Then
                str_flush1speedenable = "Enable"
                i_flush1rpm = nom_i_flush1rpm
                With txtbx_RcpCreateFlush1RPM
                    .Enabled = True
                    .Text = i_flush1rpm
                End With
            End If
        Else
            str_flush1speedenable = "Disable"
            i_flush1rpm = 0
            With txtbx_RcpCreateFlush1RPM
                .Enabled = False
                .Text = Nothing
            End With
        End If
        If rdbtn_RcpCreateFlush2PumpSpeed.Checked Then
            If txtbx_RcpCreateFlush2RPM.Enabled = False And checkbx_CreateFlush2.Checked = True Then
                str_flush2speedenable = "Enable"
                i_flush2rpm = nom_i_flush2rpm
                With txtbx_RcpCreateFlush2RPM
                    .Enabled = True
                    .Text = i_flush2rpm
                End With
            End If
        Else
            str_flush2speedenable = "Disable"
            i_flush2rpm = 0
            With txtbx_RcpCreateFlush2RPM
                .Enabled = False
                .Text = Nothing
            End With
        End If
        If rdbtn_RcpCreateDPTestPumpSpeed.Checked Then
            If txtbx_RcpCreateDPTestRPM.Enabled = False And checkbx_CreateDPTest1.Checked = True Then
                str_dptestspeedenable = "Enable"
                i_dptestrpm = nom_i_dptestrpm
                With txtbx_RcpCreateDPTestRPM
                    .Enabled = True
                    .Text = i_dptestrpm
                End With
            End If
        Else
            str_dptestspeedenable = "Disable"
            i_dptestrpm = 0
            With txtbx_RcpCreateDPTestRPM
                .Enabled = False
                .Text = Nothing
            End With
        End If
    End Sub

    Private Sub rdbtn_RcpEditPumpMode_CheckedChanged(sender As Object, e As EventArgs) Handles _
    rdbtn_RcpEditPrepPumpProcess.CheckedChanged, rdbtn_RcpEditFlush1PumpProcess.CheckedChanged, rdbtn_RcpEditFlush2PumpProcess.CheckedChanged, rdbtn_RcpEditDPTestPumpProcess.CheckedChanged,
    rdbtn_RcpEditPrepPumpSpeed.CheckedChanged, rdbtn_RcpEditFlush1PumpSpeed.CheckedChanged, rdbtn_RcpEditFlush2PumpSpeed.CheckedChanged, rdbtn_RcpEditDPTestPumpSpeed.CheckedChanged

        If rdbtn_RcpEditPrepPumpSpeed.Checked Then
            With txtbx_RcpEditPrepRPM
                If panel_RcpEditPrepPumpMode.Enabled Then
                    .Enabled = True
                End If
                .Text = i_preprpm1
            End With
        Else
            With txtbx_RcpEditPrepRPM
                .Enabled = False
                .Text = Nothing
            End With
        End If
        If rdbtn_RcpEditFlush1PumpSpeed.Checked Then
            With txtbx_RcpEditFlush1RPM
                If panel_RcpEditFlush1PumpMode.Enabled Then
                    .Enabled = True
                End If
                .Text = i_flush1rpm
            End With
        Else
            With txtbx_RcpEditFlush1RPM
                .Enabled = False
                .Text = Nothing
            End With
        End If
        If rdbtn_RcpEditFlush2PumpSpeed.Checked Then
            With txtbx_RcpEditFlush2RPM
                If panel_RcpEditFlush2PumpMode.Enabled Then
                    .Enabled = True
                End If
                .Text = i_flush2rpm
            End With
        Else
            With txtbx_RcpEditFlush2RPM
                .Enabled = False
                .Text = Nothing
            End With
        End If
        If rdbtn_RcpEditDPTestPumpSpeed.Checked Then
            With txtbx_RcpEditDPTestRPM
                If panel_RcpEditDPTestPumpMode.Enabled Then
                    .Enabled = True
                End If
                .Text = i_dptestrpm
            End With
        Else
            With txtbx_RcpEditDPTestRPM
                .Enabled = False
                .Text = Nothing
            End With
        End If
    End Sub

    Private Sub txtbx_RcpEditDuration_TextChanged(sender As Object, e As EventArgs) Handles _
            txtbx_RcpEditPrepFill.TextChanged, txtbx_RcpEditPrepBleed.TextChanged, txtbx_RcpEditFlush1Stabilize.TextChanged, txtbx_RcpEditFlush1Time.TextChanged,
            txtbx_RcpEditFlush2Stabilize.TextChanged, txtbx_RcpEditFlush2Time.TextChanged, txtbx_RcpEditDPStabilize.TextChanged, txtbx_RcpEditDPTime.TextChanged,
            txtbx_RcpEditDrain1Time.TextChanged, txtbx_RcpEditDrain2Time.TextChanged, txtbx_RcpEditDrain3Time.TextChanged, txtbx_RcpEditDrain4Time.TextChanged

        Dim TotalCycleTime As Integer = 0

        Dim PrepCycleTime As Integer = 0
        Dim Flush1CycleTime As Integer = 0
        Dim Flush2CycleTime As Integer = 0
        Dim DP1CycleTime As Integer = 0
        Dim DP2CycleTime As Integer = 0
        Dim Drain1CycleTime As Integer = 0
        Dim Drain2CycleTime As Integer = 0
        Dim Drain3CycleTime As Integer = 0
        Dim Drain4CycleTime As Integer = 0

        ' Calculate Individual Cycle Time
        If cmbx_RcpEditRecipeID.SelectedIndex > 0 Then
            Dim PrepFillTime As Integer = 0
            Dim PrepBleedTime As Integer = 0
            Dim Flush1Stabilize As Integer = 0
            Dim Flush1Time As Integer = 0
            Dim Flush2Stabilize As Integer = 0
            Dim Flush2Time As Integer = 0
            Dim DPStabilizeTime As Integer = 0
            Dim DPTestTime As Integer = 0
            Dim Drain1Time As Integer = 0
            Dim Drain2Time As Integer = 0
            Dim Drain3Time As Integer = 0
            Dim Drain4Time As Integer = 0

            Integer.TryParse(txtbx_RcpEditPrepFill.Text, PrepFillTime)
            Integer.TryParse(txtbx_RcpEditPrepBleed.Text, PrepBleedTime)
            Integer.TryParse(txtbx_RcpEditFlush1Stabilize.Text, Flush1Stabilize)
            Integer.TryParse(txtbx_RcpEditFlush1Time.Text, Flush1Time)
            Integer.TryParse(txtbx_RcpEditFlush2Stabilize.Text, Flush2Stabilize)
            Integer.TryParse(txtbx_RcpEditFlush2Time.Text, Flush2Time)
            Integer.TryParse(txtbx_RcpEditDPStabilize.Text, DPStabilizeTime)
            Integer.TryParse(txtbx_RcpEditDPTime.Text, DPTestTime)
            Integer.TryParse(txtbx_RcpEditDrain1Time.Text, Drain1Time)
            Integer.TryParse(txtbx_RcpEditDrain2Time.Text, Drain2Time)
            Integer.TryParse(txtbx_RcpEditDrain3Time.Text, Drain3Time)
            Integer.TryParse(txtbx_RcpEditDrain4Time.Text, Drain4Time)

            PrepCycleTime = PrepFillTime + PrepBleedTime
            If checkbx_EditFlush1.Checked Then
                Flush1CycleTime = Flush1Stabilize + Flush1Time
            End If
            If checkbx_EditFlush2.Checked Then
                Flush2CycleTime = Flush2Stabilize + Flush2Time
            End If
            If checkbx_EditDPTest1.Checked Then
                DP1CycleTime = DPStabilizeTime + DPTestTime
            End If
            If checkbx_EditDPTest2.Checked Then
                DP2CycleTime = DPStabilizeTime + DPTestTime
            End If
            If checkbx_EditDrain1.Checked Then
                Drain1CycleTime = Drain1Time
            End If
            If checkbx_EditDrain2.Checked Then
                Drain2CycleTime = Drain2Time
            End If
            If checkbx_EditDrain3.Checked Then
                Drain3CycleTime = Drain3Time
            End If
            If checkbx_EditDrain4.Checked Then
                Drain4CycleTime = Drain4Time
            End If
        End If

        ' Calculate Total Cycle Time
        If cmbx_RcpEditRecipeID.SelectedIndex > 0 Then
            TotalCycleTime =
                PrepCycleTime + Flush1CycleTime + Flush2CycleTime + DP1CycleTime + DP2CycleTime +
                Drain1CycleTime + Drain2CycleTime + Drain3CycleTime + Drain4CycleTime

            TextBox3.Text = TotalCycleTime
        Else
            TextBox3.Text = Nothing
        End If
    End Sub

    Private Sub txtbx_RcpCreateDuration_TextChanged(sender As Object, e As EventArgs) Handles _
            txtbx_RcpCreatePrepFill.TextChanged, txtbx_RcpCreatePrepBleed.TextChanged, txtbx_RcpCreateFlush1Stabilize.TextChanged, txtbx_RcpCreateFlush1Time.TextChanged,
            txtbx_RcpCreateFlush2Stabilize.TextChanged, txtbx_RcpCreateFlush2Time.TextChanged, txtbx_RcpCreateDPStabilize.TextChanged, txtbx_RcpCreateDPTime.TextChanged,
            txtbx_RcpCreateDrain1Time.TextChanged, txtbx_RcpCreateDrain2Time.TextChanged, txtbx_RcpCreateDrain3Time.TextChanged, txtbx_RcpCreateDrain4Time.TextChanged

        Dim TotalCycleTime As Integer = 0

        Dim PrepCycleTime As Integer = 0
        Dim Flush1CycleTime As Integer = 0
        Dim Flush2CycleTime As Integer = 0
        Dim DP1CycleTime As Integer = 0
        Dim DP2CycleTime As Integer = 0
        Dim Drain1CycleTime As Integer = 0
        Dim Drain2CycleTime As Integer = 0
        Dim Drain3CycleTime As Integer = 0
        Dim Drain4CycleTime As Integer = 0

        ' Calculate Individual Cycle Time
        If TextBox2.Enabled Then
            Dim PrepFillTime As Integer = 0
            Dim PrepBleedTime As Integer = 0
            Dim Flush1Stabilize As Integer = 0
            Dim Flush1Time As Integer = 0
            Dim Flush2Stabilize As Integer = 0
            Dim Flush2Time As Integer = 0
            Dim DPStabilizeTime As Integer = 0
            Dim DPTestTime As Integer = 0
            Dim Drain1Time As Integer = 0
            Dim Drain2Time As Integer = 0
            Dim Drain3Time As Integer = 0
            Dim Drain4Time As Integer = 0

            Integer.TryParse(txtbx_RcpCreatePrepFill.Text, PrepFillTime)
            Integer.TryParse(txtbx_RcpCreatePrepBleed.Text, PrepBleedTime)
            Integer.TryParse(txtbx_RcpCreateFlush1Stabilize.Text, Flush1Stabilize)
            Integer.TryParse(txtbx_RcpCreateFlush1Time.Text, Flush1Time)
            Integer.TryParse(txtbx_RcpCreateFlush2Stabilize.Text, Flush2Stabilize)
            Integer.TryParse(txtbx_RcpCreateFlush2Time.Text, Flush2Time)
            Integer.TryParse(txtbx_RcpCreateDPStabilize.Text, DPStabilizeTime)
            Integer.TryParse(txtbx_RcpCreateDPTime.Text, DPTestTime)
            Integer.TryParse(txtbx_RcpCreateDrain1Time.Text, Drain1Time)
            Integer.TryParse(txtbx_RcpCreateDrain2Time.Text, Drain2Time)
            Integer.TryParse(txtbx_RcpCreateDrain3Time.Text, Drain3Time)
            Integer.TryParse(txtbx_RcpCreateDrain4Time.Text, Drain4Time)

            PrepCycleTime = PrepFillTime + PrepBleedTime
            If checkbx_CreateFlush1.Checked Then
                Flush1CycleTime = Flush1Stabilize + Flush1Time
            End If
            If checkbx_CreateFlush2.Checked Then
                Flush2CycleTime = Flush2Stabilize + Flush2Time
            End If
            If checkbx_CreateDPTest1.Checked Then
                DP1CycleTime = DPStabilizeTime + DPTestTime
            End If
            If checkbx_CreateDPTest2.Checked Then
                DP2CycleTime = DPStabilizeTime + DPTestTime
            End If
            If checkbx_CreateDrain1.Checked Then
                Drain1CycleTime = Drain1Time
            End If
            If checkbx_CreateDrain2.Checked Then
                Drain2CycleTime = Drain2Time
            End If
            If checkbx_CreateDrain3.Checked Then
                Drain3CycleTime = Drain3Time
            End If
            If checkbx_CreateDrain4.Checked Then
                Drain4CycleTime = Drain4Time
            End If
        End If

        ' Calculate Total Cycle Time
        If TextBox2.Enabled Then
            TotalCycleTime =
                PrepCycleTime + Flush1CycleTime + Flush2CycleTime + DP1CycleTime + DP2CycleTime +
                Drain1CycleTime + Drain2CycleTime + Drain3CycleTime + Drain4CycleTime

            TextBox2.Text = TotalCycleTime
        Else
            TextBox2.Text = Nothing
        End If
    End Sub


End Class