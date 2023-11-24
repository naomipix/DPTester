Public Class FormCircuitModel1
    'Public pb_MCVCircuitArr(19)() As PictureBox
    'Public Lbl_ValvestatusArr(18) As Label

    Private Sub FormCircuitModel1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'For i As Integer = 0 To 15
        '    If DOut(1)(i) = True Then
        '        CircuitMimic(1, i)
        '    End If
        'Next

        'For i As Integer = 0 To 2
        '    If DOut(2)(i) = True Then
        '        CircuitMimic(2, i)
        '    End If
        'Next
    End Sub


    Private Async Sub btn_MVCShowcircuit_Click(sender As Object, e As EventArgs) Handles btn_MVCShowcircuit.Click
        If btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
            'For i As Integer = 0 To 19
            '    For j As Integer = 0 To pb_MCVCircuitArr(i).Length - 1
            '        pb_MCVCircuitArr(i)(j).Visible = True
            '    Next
            'Next
            SetButtonState(btn_MVCShowcircuit, True, "Hide Circuit Path")
            Circuittimer.Interval = 200
            Circuittimer.Enabled = True

            'For i As Integer = 0 To 15
            '    If DOut(1)(i) = True Then
            '        CircuitMimic(1, i)
            '    End If
            'Next
        Else
            SetButtonState(btn_MVCShowcircuit, False, "Show Circuit Path")
            Circuittimer.Enabled = False



        End If
    End Sub







End Class