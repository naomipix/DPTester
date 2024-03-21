Imports System.Linq.Expressions

Public Class FormTesting
    Private statusIndex As Integer = -1

    Dim dtAlarmStatus As New DataTable
    Dim isManualMode As Boolean = False
    Dim isAutoMode As Boolean = False
    Dim isAutoCycle As Boolean = False

    Dim currentStatus As String = "No Status"
    Dim MsgAlarmShown As Boolean = False
    Dim MsgAlarmShownTime As New DateTime

    Dim MsgNoStatus As String = "No Status"
    Dim MsgAutoMode As String = "Auto Mode"
    Dim MsgAutoCycle As String = "Machine In Auto Cycle"
    Dim MsgManualMode As String = "Manual Mode"
    Dim MsgAlarm As String = "Machine In Alarm Condition"
    Dim MsgWarning As String = "Machine In Warning Condition"

    Dim MsgNoStatusColor As Color = Color.Gray
    Dim MsgManualColor As Color = Color.FromArgb(25, 130, 246)
    Dim MsgAutoColor As Color = Color.FromArgb(0, 192, 0)
    Dim MsgWarningColor As Color = Color.Yellow
    Dim MsgAlarmColor As Color = Color.Red

    Dim MsgNoStatusColorT As Color = SystemColors.Window
    Dim MsgManualColorT As Color = SystemColors.Window
    Dim MsgAutoColorT As Color = SystemColors.Window
    Dim MsgWarningColorT As Color = SystemColors.ControlText
    Dim MsgAlarmColorT As Color = SystemColors.Window


    Private Sub FormTesting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormTesting_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Timer1.Interval = 3000

        If dtAlarmStatus.Columns.Count <= 0 Then
            dtAlarmStatus.Columns.Add("alarm")
        End If

        RadioButton1.Checked = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick ' Rolling Alarm
        DisplayNextStatus()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick ' Check 0 Alarm/Warning
        UpdateStatus()
    End Sub

    Private Sub DisplayNextStatus()
        ' Initialize
        If dtAlarmStatus.Rows.Count = 0 Then
            ' Reset Status Index
            statusIndex = -1

            ' Set Alarm Shown
            MsgAlarmShown = False

            ' No Alarm/Warning
            If isManualMode Or isAutoMode Then
                If isManualMode Then
                    currentStatus = MsgManualMode
                    With Label1
                        .BackColor = MsgManualColor
                        .ForeColor = MsgManualColorT
                    End With
                End If
                If isAutoMode Then
                    If isAutoCycle Then
                        currentStatus = MsgAutoCycle
                        With Label1
                            .BackColor = MsgAutoColor
                            .ForeColor = MsgAutoColorT
                        End With
                    Else
                        currentStatus = MsgAutoMode
                        With Label1
                            .BackColor = MsgAutoColor
                            .ForeColor = MsgAutoColorT
                        End With
                    End If
                End If
            Else
                currentStatus = MsgNoStatus
                With Label1
                    .BackColor = MsgNoStatusColor
                    .ForeColor = MsgNoStatusColorT
                End With
            End If

            ' Set Status Label Text
            Label1.Text = currentStatus
        Else
            Dim IsWarning As Boolean = False
            Dim IsAlarm As Boolean = False

            ' Reset Index On First Thrown
            If MsgAlarmShown = False Then
                ' Reset Status Index
                statusIndex = -1
            End If

            For i As Integer = 0 To dtAlarmStatus.Rows.Count - 1
                If CStr(dtAlarmStatus(i)("alarm")).Substring(0, 3) = "ALM" Or CStr(dtAlarmStatus(i)("alarm")).Contains("Alarm") Then
                    IsAlarm = True
                End If
                If CStr(dtAlarmStatus(i)("alarm")).Substring(0, 3) = "WAR" Or CStr(dtAlarmStatus(i)("alarm")).Contains("Warning") Then
                    IsWarning = True
                End If
            Next

            If IsAlarm Then
                currentStatus = MsgAlarm
            Else
                If IsWarning Then
                    currentStatus = MsgWarning
                End If
            End If

            ' Reset Index On End Of List
            If statusIndex > dtAlarmStatus.Rows.Count - 1 Then
                statusIndex = -1
            End If

            ' Prevent Updating Too Quickly
            If DateTime.Now >= MsgAlarmShownTime.AddMilliseconds(Timer1.Interval) Then
                If statusIndex < 0 Then
                    Label1.Text = currentStatus
                Else
                    Label1.Text = dtAlarmStatus(statusIndex)("alarm")
                End If

                If dtAlarmStatus.Rows.Count > 0 Then
                    If CStr(Label1.Text).Substring(0, 3) = "ALM" Or CStr(Label1.Text).Contains("Alarm") Then
                        With Label1
                            .BackColor = MsgAlarmColor
                            .ForeColor = MsgAlarmColorT
                        End With
                    ElseIf CStr(Label1.Text).Substring(0, 3) = "WAR" Or CStr(Label1.Text).Contains("Warning") Then
                        With Label1
                            .BackColor = MsgWarningColor
                            .ForeColor = MsgWarningColorT
                        End With
                    Else
                        With Label1
                            .BackColor = MsgNoStatusColor
                            .ForeColor = MsgNoStatusColorT
                        End With
                    End If
                End If

                ' Increment the index for the next status
                statusIndex += 1
            End If

            ' Set Alarm Thrown State
            If MsgAlarmShown = False Then
                MsgAlarmShown = True
                MsgAlarmShownTime = DateTime.Now
            End If
        End If
    End Sub

    Private Sub UpdateStatus()
        If dtAlarmStatus.Rows.Count = 0 Then
            ' Reset Status Index
            statusIndex = -1

            ' Set Alarm Shown
            MsgAlarmShown = False

            ' No Alarm/Warning
            If isManualMode Or isAutoMode Then
                If isManualMode Then
                    currentStatus = MsgManualMode
                    With Label1
                        .BackColor = MsgManualColor
                        .ForeColor = MsgManualColorT
                    End With
                End If
                If isAutoMode Then
                    If isAutoCycle Then
                        currentStatus = MsgAutoCycle
                        With Label1
                            .BackColor = MsgAutoColor
                            .ForeColor = MsgAutoColorT
                        End With
                    Else
                        currentStatus = MsgAutoMode
                        With Label1
                            .BackColor = MsgAutoColor
                            .ForeColor = MsgAutoColorT
                        End With
                    End If
                End If
            Else
                currentStatus = MsgNoStatus
                With Label1
                    .BackColor = MsgNoStatusColor
                    .ForeColor = MsgNoStatusColorT
                End With
            End If

            ' Set Status Label Text
            Label1.Text = currentStatus
        Else
            If MsgAlarmShown = True Then
                ' Check Alarm Thrown During Warning
                If currentStatus.Substring(0, 3) = "WAR" Or currentStatus.Contains("Warning") Then
                    For i As Integer = 0 To dtAlarmStatus.Rows.Count - 1
                        If CStr(dtAlarmStatus(i)("alarm")).Substring(0, 3) = "ALM" Or CStr(dtAlarmStatus(i)("alarm")).Contains("Alarm") Then
                            ' Reset Warning To Show Alarm
                            MsgAlarmShown = False
                            DisplayNextStatus()
                            Exit For
                        End If
                    Next
                End If
            Else
                ' Display Alarm/Warning
                DisplayNextStatus()
            End If
        End If
    End Sub










    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        If RadioButton1.Checked Then
            CheckBox1.Enabled = True
        Else
            CheckBox1.Enabled = False
            CheckBox1.Checked = False
        End If

        If RadioButton1.Checked Then
            isAutoMode = True
        Else
            isAutoMode = False
        End If
        If RadioButton2.Checked Then
            isManualMode = True
        Else
            isManualMode = False
        End If

        'UpdateStatus()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        isAutoCycle = CheckBox1.Checked

        'UpdateStatus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RadioButton1.Checked = False
        RadioButton2.Checked = False

        'UpdateStatus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        dtAlarmStatus.Rows.Add(TextBox1.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        dtAlarmStatus.Rows.Clear()
    End Sub
End Class