Public Class FormCircuitModel1
    'Public pb_MCVCircuitArr(19)() As PictureBox
    'Public Lbl_ValvestatusArr(18) As Label

    Private Sub FormCircuitModel1_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub


    Private Sub btn_MVCShowcircuit_Click(sender As Object, e As EventArgs) Handles btn_MVCShowcircuit.Click
        If btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then

            SetButtonState(btn_MVCShowcircuit, True, "Hide Circuit Path")
            Circuittimer.Interval = 200
            Circuittimer.Enabled = True

        Else
            SetButtonState(btn_MVCShowcircuit, False, "Show Circuit Path")
            Circuittimer.Enabled = False

        End If
    End Sub



End Class