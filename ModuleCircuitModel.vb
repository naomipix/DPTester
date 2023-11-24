Module ModuleCircuitModel
    Public pb_MCVCircuitArr(19)() As PictureBox
    Public pb_MCVCircuitPathArr(19)() As PictureBox
    Public Lbl_ValvestatusArr(18) As Label
    Public WithEvents Circuittimer As New Timer()
    Public Circuitcall(19) As Integer
    Public Arrowbgcolor As Color
    Public Circuitbgcolor As Color
    Public Sub InitialiseCircuit()
        'Define Label Array
        Lbl_ValvestatusArr = {FormCircuitModel1.lbl_Valve1, FormCircuitModel1.lbl_Valve2, FormCircuitModel1.lbl_Valve3, FormCircuitModel1.lbl_Valve4, FormCircuitModel1.lbl_Valve5, FormCircuitModel1.lbl_Valve6, FormCircuitModel1.lbl_Valve7, FormCircuitModel1.lbl_Valve8, FormCircuitModel1.lbl_Valve9, FormCircuitModel1.lbl_Valve10,
            FormCircuitModel1.lbl_Valve11, FormCircuitModel1.lbl_Valve12, FormCircuitModel1.lbl_Valve13, FormCircuitModel1.lbl_Valve14, FormCircuitModel1.lbl_Valve15, FormCircuitModel1.lbl_Valve16, FormCircuitModel1.lbl_Valve17, FormCircuitModel1.lbl_Valve18, FormCircuitModel1.lbl_Valve19
        }
        'Define Label Array
        pb_MCVCircuitArr(0) = {}
        pb_MCVCircuitArr(1) = {FormCircuitModel1.pb_MCValve1bx1, FormCircuitModel1.pb_MCValve1bx2, FormCircuitModel1.pb_MCValve1bx3, FormCircuitModel1.pb_MCValve1bx4, FormCircuitModel1.pb_MCValve1bx5, FormCircuitModel1.pb_MCValve1bx6, FormCircuitModel1.pb_MCValve1bx7, FormCircuitModel1.pb_MCValve1bx8, FormCircuitModel1.pb_MCValve1bx9, FormCircuitModel1.pb_MCValve1bx10, FormCircuitModel1.pb_MCValve1bx11, FormCircuitModel1.pb_MCValve1bx12}
        pb_MCVCircuitArr(2) = {FormCircuitModel1.pb_MCValve2bx1, FormCircuitModel1.pb_MCValve2bx2, FormCircuitModel1.pb_MCValve2bx3, FormCircuitModel1.pb_MCValve2bx4, FormCircuitModel1.pb_MCValve2bx5, FormCircuitModel1.pb_MCValve2bx6, FormCircuitModel1.pb_MCValve2bx7, FormCircuitModel1.pb_MCValve2bx8, FormCircuitModel1.pb_MCValve2bx9}
        pb_MCVCircuitArr(3) = {FormCircuitModel1.pb_MCValve3bx1, FormCircuitModel1.pb_MCValve3bx2, FormCircuitModel1.pb_MCValve3bx3, FormCircuitModel1.pb_MCValve3bx4, FormCircuitModel1.pb_MCValve3bx5, FormCircuitModel1.pb_MCValve3bx6, FormCircuitModel1.pb_MCValve3bx7, FormCircuitModel1.pb_MCValve3bx8}
        pb_MCVCircuitArr(4) = {FormCircuitModel1.pb_MCValve4bx1, FormCircuitModel1.pb_MCValve4bx2, FormCircuitModel1.pb_MCValve4bx3, FormCircuitModel1.pb_MCValve4bx4, FormCircuitModel1.pb_MCValve4bx5}
        pb_MCVCircuitArr(5) = {FormCircuitModel1.pb_MCValve5bx1, FormCircuitModel1.pb_MCValve5bx2, FormCircuitModel1.pb_MCValve5bx3, FormCircuitModel1.pb_MCValve5bx4, FormCircuitModel1.pb_MCValve5bx5, FormCircuitModel1.pb_MCValve5bx6, FormCircuitModel1.pb_MCValve5bx7}
        pb_MCVCircuitArr(6) = {FormCircuitModel1.pb_MCValve6bx1, FormCircuitModel1.pb_MCValve6bx2, FormCircuitModel1.pb_MCValve6bx3, FormCircuitModel1.pb_MCValve6bx4}
        pb_MCVCircuitArr(7) = {FormCircuitModel1.pb_MCValve7bx1, FormCircuitModel1.pb_MCValve7bx2, FormCircuitModel1.pb_MCValve7bx3, FormCircuitModel1.pb_MCValve7bx4, FormCircuitModel1.pb_MCValve7bx5}
        pb_MCVCircuitArr(8) = {FormCircuitModel1.pb_MCValve8bx1, FormCircuitModel1.pb_MCValve8bx2, FormCircuitModel1.pb_MCValve8bx3, FormCircuitModel1.pb_MCValve8bx4}
        pb_MCVCircuitArr(9) = {FormCircuitModel1.pb_MCValve9bx1, FormCircuitModel1.pb_MCValve9bx2}
        pb_MCVCircuitArr(10) = {FormCircuitModel1.pb_MCValve10bx1, FormCircuitModel1.pb_MCValve10bx2, FormCircuitModel1.pb_MCValve10bx3}
        pb_MCVCircuitArr(11) = {FormCircuitModel1.pb_MCValve11bx1, FormCircuitModel1.pb_MCValve11bx2, FormCircuitModel1.pb_MCValve11bx3, FormCircuitModel1.pb_MCValve11bx4, FormCircuitModel1.pb_MCValve11bx5, FormCircuitModel1.pb_MCValve11bx6}
        pb_MCVCircuitArr(12) = {FormCircuitModel1.pb_MCValve12bx1, FormCircuitModel1.pb_MCValve12bx2, FormCircuitModel1.pb_MCValve12bx3, FormCircuitModel1.pb_MCValve12bx4, FormCircuitModel1.pb_MCValve12bx5, FormCircuitModel1.pb_MCValve12bx6}
        pb_MCVCircuitArr(13) = {FormCircuitModel1.pb_MCValve13bx1, FormCircuitModel1.pb_MCValve13bx2}
        pb_MCVCircuitArr(14) = {FormCircuitModel1.pb_MCValve14bx1, FormCircuitModel1.pb_MCValve14bx2}
        pb_MCVCircuitArr(15) = {FormCircuitModel1.pb_MCValve15bx1, FormCircuitModel1.pb_MCValve15bx2, FormCircuitModel1.pb_MCValve15bx3, FormCircuitModel1.pb_MCValve15bx4, FormCircuitModel1.pb_MCValve15bx5}
        pb_MCVCircuitArr(16) = {FormCircuitModel1.pb_MCValve16bx1, FormCircuitModel1.pb_MCValve16bx2, FormCircuitModel1.pb_MCValve16bx3}
        pb_MCVCircuitArr(17) = {FormCircuitModel1.pb_MCValve17bx1, FormCircuitModel1.pb_MCValve17bx2, FormCircuitModel1.pb_MCValve17bx3, FormCircuitModel1.pb_MCValve17bx4, FormCircuitModel1.pb_MCValve17bx5, FormCircuitModel1.pb_MCValve17bx6}
        pb_MCVCircuitArr(18) = {FormCircuitModel1.pb_MCValve18bx1, FormCircuitModel1.pb_MCValve18bx2, FormCircuitModel1.pb_MCValve18bx3, FormCircuitModel1.pb_MCValve18bx4, FormCircuitModel1.pb_MCValve18bx5, FormCircuitModel1.pb_MCValve18bx6, FormCircuitModel1.pb_MCValve18bx7}
        pb_MCVCircuitArr(19) = {FormCircuitModel1.pb_MCValve19bx1, FormCircuitModel1.pb_MCValve19bx2, FormCircuitModel1.pb_MCValve19bx3}


        'Define Label Array
        pb_MCVCircuitPathArr(0) = {}
        pb_MCVCircuitPathArr(1) = {FormCircuitModel1.pb_MCValve1Pipe1, FormCircuitModel1.pb_MCValve1Pipe2, FormCircuitModel1.pb_MCValve1Pipe3, FormCircuitModel1.pb_MCValve1Pipe4}
        pb_MCVCircuitPathArr(2) = {FormCircuitModel1.pb_MCValve2Pipe1, FormCircuitModel1.pb_MCValve2Pipe2, FormCircuitModel1.pb_MCValve2Pipe3}
        pb_MCVCircuitPathArr(3) = {FormCircuitModel1.pb_MCValve3Pipe1, FormCircuitModel1.pb_MCValve3Pipe2}
        pb_MCVCircuitPathArr(4) = {FormCircuitModel1.pb_MCValve4Pipe1, FormCircuitModel1.pb_MCValve4Pipe2, FormCircuitModel1.pb_MCValve4Pipe3, FormCircuitModel1.pb_MCValve4Pipe4, FormCircuitModel1.pb_MCValve4Pipe5}
        pb_MCVCircuitPathArr(5) = {FormCircuitModel1.pb_MCValve5Pipe1, FormCircuitModel1.pb_MCValve5Pipe2}
        pb_MCVCircuitPathArr(6) = {FormCircuitModel1.pb_MCValve6Pipe1, FormCircuitModel1.pb_MCValve6Pipe2, FormCircuitModel1.pb_MCValve6Pipe3}
        pb_MCVCircuitPathArr(7) = {FormCircuitModel1.pb_MCValve7Pipe1, FormCircuitModel1.pb_MCValve7Pipe2, FormCircuitModel1.pb_MCValve7Pipe3, FormCircuitModel1.pb_MCValve7Pipe4}
        pb_MCVCircuitPathArr(8) = {FormCircuitModel1.pb_MCValve8Pipe1, FormCircuitModel1.pb_MCValve8Pipe2}
        pb_MCVCircuitPathArr(9) = {FormCircuitModel1.pb_MCValve9Pipe1, FormCircuitModel1.pb_MCValve9Pipe2}
        pb_MCVCircuitPathArr(10) = {FormCircuitModel1.pb_MCValve10Pipe1, FormCircuitModel1.pb_MCValve10Pipe2, FormCircuitModel1.pb_MCValve10Pipe3, FormCircuitModel1.pb_MCValve10Pipe4}
        pb_MCVCircuitPathArr(11) = {FormCircuitModel1.pb_MCValve11Pipe1, FormCircuitModel1.pb_MCValve11Pipe2, FormCircuitModel1.pb_MCValve11Pipe3}
        pb_MCVCircuitPathArr(12) = {FormCircuitModel1.pb_MCValve12Pipe1, FormCircuitModel1.pb_MCValve12Pipe2, FormCircuitModel1.pb_MCValve12Pipe3, FormCircuitModel1.pb_MCValve12Pipe4}
        pb_MCVCircuitPathArr(13) = {FormCircuitModel1.pb_MCValve13Pipe1, FormCircuitModel1.pb_MCValve13Pipe2, FormCircuitModel1.pb_MCValve13Pipe3, FormCircuitModel1.pb_MCValve13Pipe4, FormCircuitModel1.pb_MCValve13Pipe5}
        pb_MCVCircuitPathArr(14) = {FormCircuitModel1.pb_MCValve14Pipe1, FormCircuitModel1.pb_MCValve14Pipe2, FormCircuitModel1.pb_MCValve14Pipe3}
        pb_MCVCircuitPathArr(15) = {FormCircuitModel1.pb_MCValve15Pipe1, FormCircuitModel1.pb_MCValve15Pipe2, FormCircuitModel1.pb_MCValve15Pipe3, FormCircuitModel1.pb_MCValve15Pipe4}
        pb_MCVCircuitPathArr(16) = {FormCircuitModel1.pb_MCValve16Pipe1, FormCircuitModel1.pb_MCValve16Pipe2}
        pb_MCVCircuitPathArr(17) = {FormCircuitModel1.pb_MCValve17Pipe1, FormCircuitModel1.pb_MCValve17Pipe2, FormCircuitModel1.pb_MCValve17Pipe3}
        pb_MCVCircuitPathArr(18) = {FormCircuitModel1.pb_MCValve18Pipe1, FormCircuitModel1.pb_MCValve18Pipe2, FormCircuitModel1.pb_MCValve18Pipe3}
        pb_MCVCircuitPathArr(19) = {FormCircuitModel1.pb_MCValve19Pipe1, FormCircuitModel1.pb_MCValve19Pipe2}




        For i As Integer = 0 To 19
            Circuitcall(i) = 0
        Next
    End Sub

    ' Circuit Control logic
    Private Async Sub CircuitTimer_Ticks(sender As Object, e As EventArgs) Handles Circuittimer.Tick

        For i As Integer = 0 To 15
            If DOut(1)(i) = True And Circuitcall(i) <> 1 Then
                CircuitMimic(1, i)
                Circuitcall(i) = 1
                For j As Integer = 0 To pb_MCVCircuitPathArr(i + 1).Length - 1
                    pb_MCVCircuitPathArr(i + 1)(j).BackColor = Color.FromArgb(25, 130, 246)
                    pb_MCVCircuitPathArr(i + 1)(j).BringToFront()
                Next
            Else
                If DOut(1)(i) = False Then
                    Circuitcall(i) = 0
                    For j As Integer = 0 To pb_MCVCircuitPathArr(i + 1).Length - 1
                        pb_MCVCircuitPathArr(i + 1)(j).BackColor = Color.Transparent
                        pb_MCVCircuitPathArr(i + 1)(j).SendToBack()
                    Next
                End If
            End If
        Next

        For i As Integer = 0 To 2
            If DOut(2)(i) = True And Circuitcall(i + 16) <> 1 Then
                CircuitMimic(2, i)
                Circuitcall(i + 16) = 1
                For j As Integer = 0 To pb_MCVCircuitPathArr(i + 17).Length - 1
                    pb_MCVCircuitPathArr(i + 17)(j).BackColor = Color.FromArgb(25, 130, 246)
                    pb_MCVCircuitPathArr(i + 17)(j).BringToFront()
                Next
            Else
                If DOut(2)(i) = False Then
                    Circuitcall(i + 16) = 0
                    For j As Integer = 0 To pb_MCVCircuitPathArr(i + 17).Length - 1
                        pb_MCVCircuitPathArr(i + 17)(j).BackColor = Color.Transparent
                        pb_MCVCircuitPathArr(i + 17)(j).SendToBack()
                    Next
                End If
            End If
        Next



    End Sub


    Public Async Function CircuitMimic(Output As Integer, Valve As Integer) As Task
        If Output = 1 Then
            While DOut(Output)(Valve) = True And Not FormCircuitModel1.btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246)
                Dim size(1) As Integer
                size(0) = 0
                While size(0) <= ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1).Length - 1 And Not FormCircuitModel1.btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246)
                    Await Task.Delay(500)
                    ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1)(size(0)).Visible = True
                    If ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1)(size(0)).BackColor = Color.Transparent Then
                        ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1)(size(0)).BackColor = Color.FromArgb(25, 130, 246)
                        ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1)(size(0)).BringToFront()
                    End If
                    size(0) = size(0) + 1
                End While
                size(1) = 0
                While size(1) <= ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1).Length - 1 And Not FormCircuitModel1.btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246)
                    Await Task.Delay(500)
                    ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1)(size(1)).Visible = False
                    If ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1)(size(1)).BackColor = Color.FromArgb(25, 130, 246) Then
                        ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1)(size(1)).BackColor = Color.Transparent
                        ModuleCircuitModel.pb_MCVCircuitArr(Valve + 1)(size(1)).SendToBack()
                    End If
                    size(1) = size(1) + 1
                End While


            End While
        End If

        If Output = 2 Then
            While DOut(Output)(Valve) = True And Not FormCircuitModel1.btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246)
                Dim size(1) As Integer
                size(0) = 0
                While size(0) <= ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17).Length - 1 And Not FormCircuitModel1.btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246)
                    Await Task.Delay(500)
                    ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17)(size(0)).Visible = True
                    If ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17)(size(0)).BackColor = Color.Transparent Then
                        ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17)(size(0)).BackColor = Color.FromArgb(25, 130, 246)
                        ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17)(size(0)).BringToFront()
                    End If
                    size(0) = size(0) + 1
                End While
                size(1) = 0
                While size(1) <= ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17).Length - 1 And Not FormCircuitModel1.btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246)
                    Await Task.Delay(500)
                    ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17)(size(1)).Visible = False
                    If ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17)(size(1)).BackColor = Color.FromArgb(25, 130, 246) Then
                        ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17)(size(1)).BackColor = Color.Transparent
                        ModuleCircuitModel.pb_MCVCircuitArr(Valve + 17)(size(1)).SendToBack()
                    End If
                    size(1) = size(1) + 1
                End While


            End While
        End If


    End Function








End Module
