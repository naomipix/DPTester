Module ModuleCircuitModel
    Public pb_MCVCircuitArr(19)() As PictureBox
    Public Lbl_ValvestatusArr(18) As Label


    Public Sub InitialiseCircuit()
        'Define Label Array
        Lbl_ValvestatusArr = {FormCircuitModel1.lbl_Valve1, FormCircuitModel1.lbl_Valve2, FormCircuitModel1.lbl_Valve3, FormCircuitModel1.lbl_Valve4, FormCircuitModel1.lbl_Valve5, FormCircuitModel1.lbl_Valve6, FormCircuitModel1.lbl_Valve7, FormCircuitModel1.lbl_Valve8, FormCircuitModel1.lbl_Valve9, FormCircuitModel1.lbl_Valve10,
            FormCircuitModel1.lbl_Valve11, FormCircuitModel1.lbl_Valve12, FormCircuitModel1.lbl_Valve13, FormCircuitModel1.lbl_Valve14, FormCircuitModel1.lbl_Valve15, FormCircuitModel1.lbl_Valve16, FormCircuitModel1.lbl_Valve17, FormCircuitModel1.lbl_Valve18, FormCircuitModel1.lbl_Valve19
        }
        'Define Label Array
        pb_MCVCircuitArr(0) = {FormCircuitModel1.pb_MCDIWIncome, FormCircuitModel1.pb_MCN2Income1, FormCircuitModel1.pb_MCN2Income2, FormCircuitModel1.pb_MCN2Income3, FormCircuitModel1.pb_MCN2Income4, FormCircuitModel1.pb_MCVFilterDrain1, FormCircuitModel1.pb_MCVFilterDrain2, FormCircuitModel1.pb_MCVProdDrain1, FormCircuitModel1.pb_MCVProdDrain2}
        pb_MCVCircuitArr(1) = {FormCircuitModel1.pb_MCValve1bx1, FormCircuitModel1.pb_MCValve1bx2, FormCircuitModel1.pb_MCValve1bx3, FormCircuitModel1.pb_MCValve1bx4}
        pb_MCVCircuitArr(2) = {FormCircuitModel1.pb_MCValve2bx1, FormCircuitModel1.pb_MCValve2bx2}
        pb_MCVCircuitArr(3) = {FormCircuitModel1.pb_MCValve3bx1, FormCircuitModel1.pb_MCValve3bx2}
        pb_MCVCircuitArr(4) = {FormCircuitModel1.pb_MCValve4bx1, FormCircuitModel1.pb_MCValve4bx2, FormCircuitModel1.pb_MCValve4bx3, FormCircuitModel1.pb_MCValve4bx4}
        pb_MCVCircuitArr(5) = {FormCircuitModel1.pb_MCValve5bx1, FormCircuitModel1.pb_MCValve5bx2}
        pb_MCVCircuitArr(6) = {FormCircuitModel1.pb_MCValve6bx1, FormCircuitModel1.pb_MCValve6bx2, FormCircuitModel1.pb_MCValve6bx3, FormCircuitModel1.pb_MCValve6bx4}
        pb_MCVCircuitArr(7) = {FormCircuitModel1.pb_MCValve7bx1}
        pb_MCVCircuitArr(8) = {FormCircuitModel1.pb_MCValve8bx1}
        pb_MCVCircuitArr(9) = {FormCircuitModel1.pb_MCValve9bx1, FormCircuitModel1.pb_MCValve9bx2}
        pb_MCVCircuitArr(10) = {FormCircuitModel1.pb_MCValve10bx1, FormCircuitModel1.pb_MCValve10bx2, FormCircuitModel1.pb_MCValve10bx3}
        pb_MCVCircuitArr(11) = {FormCircuitModel1.pb_MCValve11bx1, FormCircuitModel1.pb_MCValve11bx2}
        pb_MCVCircuitArr(12) = {FormCircuitModel1.pb_MCValve12bx1, FormCircuitModel1.pb_MCValve12bx2}
        pb_MCVCircuitArr(13) = {FormCircuitModel1.pb_MCValve13bx1, FormCircuitModel1.pb_MCValve13bx2}
        pb_MCVCircuitArr(14) = {FormCircuitModel1.pb_MCValve14bx1, FormCircuitModel1.pb_MCValve14bx2}
        pb_MCVCircuitArr(15) = {FormCircuitModel1.pb_MCValve15bx1, FormCircuitModel1.pb_MCValve15bx2}
        pb_MCVCircuitArr(16) = {FormCircuitModel1.pb_MCValve16bx1}
        pb_MCVCircuitArr(17) = {FormCircuitModel1.pb_MCValve17bx1, FormCircuitModel1.pb_MCValve17bx2, FormCircuitModel1.pb_MCValve17bx3, FormCircuitModel1.pb_MCValve17bx4}
        pb_MCVCircuitArr(18) = {FormCircuitModel1.pb_MCValve18bx1, FormCircuitModel1.pb_MCValve18bx2, FormCircuitModel1.pb_MCValve18bx3}
        pb_MCVCircuitArr(19) = {FormCircuitModel1.pb_MCValve19bx1, FormCircuitModel1.pb_MCValve19bx2, FormCircuitModel1.pb_MCValve19bx3}

        For i As Integer = 0 To 19
            For j As Integer = 0 To pb_MCVCircuitArr(i).Length - 1
                pb_MCVCircuitArr(i)(j).Visible = False
            Next
        Next
    End Sub


End Module
