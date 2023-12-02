Public Class FormCircuitModel2
    Private Sub btn_MVCShowcircuit_Click(sender As Object, e As EventArgs) Handles btn_MVCShowcircuit.Click
        If btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then

            SetButtonState(btn_MVCShowcircuit, True, "Hide Circuit Path")


        Else
            SetButtonState(btn_MVCShowcircuit, False, "Show Circuit Path")
            'Circuittimer.Enabled = False

        End If
    End Sub


End Class