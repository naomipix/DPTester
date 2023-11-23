Public Class FormCircuitModel1
    'Public pb_MCVCircuitArr(19)() As PictureBox
    'Public Lbl_ValvestatusArr(18) As Label

    Private Sub FormCircuitModel1_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub


    Private Sub btn_MVCShowcircuit_Click(sender As Object, e As EventArgs) Handles btn_MVCShowcircuit.Click
        If btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
            'For i As Integer = 0 To 19
            '    For j As Integer = 0 To pb_MCVCircuitArr(i).Length - 1
            '        pb_MCVCircuitArr(i)(j).Visible = True
            '    Next
            'Next
            Circuittimer.Interval = 100
            Circuittimer.Enabled = True
            SetButtonState(btn_MVCShowcircuit, True, "Hide Circuit Path")
        Else
            For i As Integer = 0 To 19
                For j As Integer = 0 To pb_MCVCircuitArr(i).Length - 1
                    pb_MCVCircuitArr(i)(j).Visible = False
                Next
            Next
            Circuittimer.Enabled = False
            SetButtonState(btn_MVCShowcircuit, False, "Show Circuit Path")
        End If
    End Sub
End Class