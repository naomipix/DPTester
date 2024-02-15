Public Class FormCircuitModel2
    Private Sub btn_MVCShowcircuit_Click(sender As Object, e As EventArgs) Handles btn_MVCShowcircuit.Click
        If btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then

            SetButtonState(btn_MVCShowcircuit, True, "Hide Circuit Path")


        Else
            SetButtonState(btn_MVCShowcircuit, False, "Show Circuit Path")
            'Circuittimer.Enabled = False

        End If
    End Sub

    Private Sub FormCircuitModel2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Circuittimer.Interval = 100
        Circuittimer.Enabled = True
        InitialiseCircuit()
    End Sub

    'Public pb_MCVCircuitArr(19)() As PictureBox
    'Public pb_MCVCircuitPathArr(19)() As PictureBox
    Public Lbl_ValvestatusArr(18) As Label
    Public Lbl_Valvepath(19)() As Label
    Public pathtask(19) As Boolean
    Public pathforward(22) As Boolean
    Public pathfwdack(22) As Boolean
    Public pathreverse(22) As Boolean
    Public pathrevack(22) As Boolean
    Public WithEvents Circuittimer As New Timer()
    Public Circuitcall(19) As Integer
    Public Arrowbgcolor As Color
    Public Circuitbgcolor As Color
    Public Lbl_Income(3)() As Label
    Public Lbl_NPDrain(1) As Label
    Public Lbl_PDrain(2)() As Label
    Public Lbl_Junction(1)() As Label
    Public Lbl_Product(3)() As Label
    Public Lbl_Bleed(1)() As Label
    Public Lbl_N2Purge(1) As Label
    Public Lbl_Pump(1)() As Label
    Public bgcolor As Color
    Public CircuitShown(3) As Boolean
    Public CircuitInitalised As Boolean
    Public Sub InitialiseCircuit()
        'Define Label Array
        Lbl_ValvestatusArr = {lbl_Valve1, lbl_Valve2, lbl_Valve3, lbl_Valve4,
                  lbl_Valve5, lbl_Valve6, lbl_Valve7, lbl_Valve8, lbl_Valve9,
                  lbl_Valve10, lbl_Valve11, lbl_Valve12, lbl_Valve13, lbl_Valve14,
                  lbl_Valve15, lbl_Valve16, lbl_Valve17, lbl_Valve18, lbl_Valve19
              }

        'Define Valve path
        Lbl_Valvepath(1) = {lbl_V1_P1, lbl_V1_P2, lbl_V1_P3, lbl_V1_P4, lbl_V1_P5,
                lbl_V1_P6, lbl_V1_P7, lbl_V1_P8, lbl_V1_P9, lbl_V1_P10
            }

        Lbl_Valvepath(2) = {lbl_V2_P1, lbl_V2_P2, lbl_V2_P3, lbl_V2_P4, lbl_V2_P5,
                lbl_V2_P6, lbl_V2_P7, lbl_V2_P8, lbl_V2_P9, lbl_V2_P10
            }

        Lbl_Valvepath(3) = {lbl_V3_P1, lbl_V3_P2, lbl_V3_P3, lbl_V3_P4, lbl_V3_P5,
               lbl_V3_P6, lbl_V3_P7, lbl_V3_P8, lbl_V3_P9, lbl_V3_P10
           }

        Lbl_Valvepath(4) = {lbl_V4_P1, lbl_V4_P2, lbl_V4_P3, lbl_V4_P4, lbl_V4_P5,
                lbl_V4_P6, lbl_V4_P7, lbl_V4_P8, lbl_V4_P9, lbl_V4_P10,
                lbl_V4_P11, lbl_V4_P12, lbl_V4_P13
            }

        Lbl_Valvepath(5) = {lbl_V5_P1, lbl_V5_P2, lbl_V5_P3, lbl_V5_P4, lbl_V5_P5,
              lbl_V5_P6, lbl_V5_P7, lbl_V5_P8, lbl_V5_P9, lbl_V5_P10
          }

        Lbl_Valvepath(6) = {lbl_V6_P1, lbl_V6_P2, lbl_V6_P3, lbl_V6_P4, lbl_V6_P5,
              lbl_V6_P6, lbl_V6_P7, lbl_V6_P8, lbl_V6_P9
          }

        Lbl_Valvepath(7) = {lbl_V7_P1, lbl_V7_P2, lbl_V7_P3, lbl_V7_P4}

        Lbl_Valvepath(8) = {lbl_V8_P1, lbl_V8_P2, lbl_V8_P3, lbl_V8_P4}

        Lbl_Valvepath(9) = {lbl_V9_P1, lbl_V9_P2, lbl_V9_P3}

        Lbl_Valvepath(10) = {lbl_V10_P1, lbl_V10_P2, lbl_V10_P3, lbl_V10_P4}

        Lbl_Valvepath(11) = {lbl_V11_P1, lbl_V11_P2, lbl_V11_P3, lbl_V11_P4}

        Lbl_Valvepath(12) = {lbl_V12_P1, lbl_V12_P2, lbl_V12_P3}

        Lbl_Valvepath(13) = {lbl_V13_P1, lbl_V13_P2, lbl_V13_P3}

        Lbl_Valvepath(14) = {lbl_V14_P1, lbl_V14_P2, lbl_V14_P3}

        Lbl_Valvepath(15) = {lbl_V15_P1, lbl_V15_P2, lbl_V15_P3, lbl_V15_P4}

        Lbl_Valvepath(16) = {lbl_V16_P1, lbl_V16_P2, lbl_V16_P3, lbl_V16_P4}

        Lbl_Valvepath(17) = {lbl_V17_P1, lbl_V17_P2, lbl_V17_P3, lbl_V17_P4, lbl_V17_P5,
              lbl_V17_P6, lbl_V17_P7, lbl_V17_P8
          }

        Lbl_Valvepath(18) = {lbl_V18_P1, lbl_V18_P2, lbl_V18_P3}

        Lbl_Valvepath(19) = {lbl_V19_P1, lbl_V19_P2, lbl_V19_P3, lbl_V19_P4, lbl_V19_P5
         }

        Lbl_Income(0) = {lbl_Income_P1, lbl_Income_P2, lbl_Income_P3, lbl_Income_P4, lbl_Income_P5,
                lbl_Income_P6, lbl_Income_P7, lbl_Income_P8, lbl_Income_P9, lbl_Income_P10,
                lbl_Income_P11}

        Lbl_Income(1) = {lbl_Income_P12, lbl_Income_P13, lbl_Income_P14, lbl_Income_P15,
                lbl_Income_P16, lbl_Income_P17, lbl_Income_P18, lbl_Income_P19,
                lbl_Income_P20, lbl_Income_P21, lbl_Income_P22, lbl_Income_P23,
                lbl_Income_P24
            }

        Lbl_Income(2) = {lbl_Income_P25, lbl_Income_P26, lbl_Income_P27}

        Lbl_Income(3) = {lbl_Income_P28, lbl_Income_P29}

        Lbl_NPDrain = {lbl_NPDrain_P1, lbl_NPDrain_P2, lbl_NPDrain_P3, lbl_NPDrain_P4,
            lbl_NPDrain_P5, lbl_NPDrain_P6, lbl_NPDrain_P7, lbl_NPDrain_P8,
            lbl_NPDrain_P9, lbl_NPDrain_P10, lbl_NPDrain_P11, lbl_NPDrain_P12,
            lbl_NPDrain_P13, lbl_NPDrain_P14, lbl_NPDrain_P15, lbl_NPDrain_P16,
            lbl_NPDrain_P17, lbl_NPDrain_P18, lbl_NPDrain_P19, lbl_NPDrain_P20,
            lbl_NPDrain_P21, lbl_NPDrain_P22, lbl_NPDrain_P23, lbl_NPDrain_P24,
            lbl_NPDrain_P25, lbl_NPDrain_P26, lbl_NPDrain_P27, lbl_NPDrain_P28,
            lbl_NPDrain_P29, lbl_NPDrain_P30, lbl_NPDrain_P31, lbl_NPDrain_P32
            }

        Lbl_PDrain(0) = {lbl_PDrain_P1, lbl_PDrain_P2, lbl_PDrain_P3, lbl_PDrain_P4,
            lbl_PDrain_P5, lbl_PDrain_P6, lbl_PDrain_P7, lbl_PDrain_P8,
            lbl_PDrain_P9}

        Lbl_PDrain(1) = {lbl_PDrain_P12, lbl_PDrain_P11, lbl_PDrain_P10}

        Lbl_PDrain(2) = {lbl_PDrain_P13, lbl_PDrain_P14, lbl_PDrain_P15}


        Lbl_Junction(0) = {lbl_Junction_P1, lbl_Junction_P2, lbl_Junction_P3, lbl_Junction_P4,
            lbl_Junction_P5, lbl_Junction_P6, lbl_Junction_P7, lbl_Junction_P8,
            lbl_Junction_P9, lbl_Junction_P10
            }

        Lbl_Junction(1) = {lbl_Junction_P11, lbl_Junction_P12,
            lbl_Junction_P13, lbl_Junction_P14, lbl_Junction_P15, lbl_Junction_P16,
            lbl_Junction_P17, lbl_Junction_P18, lbl_Junction_P19, lbl_Junction_P20,
            lbl_Junction_P21
                }

        Lbl_Product(0) = {lbl_Product_P1, lbl_Product_P2, lbl_Product_P3, lbl_Product_P4
            }

        Lbl_Product(1) = {lbl_Product_P5, lbl_Product_P6, lbl_Product_P7, lbl_Product_P8,
            lbl_Product_P9, lbl_Product_P10, lbl_Product_P11, lbl_Product_P12,
            lbl_Product_P13}

        Lbl_Product(2) = {lbl_Product_P14, lbl_Product_P15, lbl_Product_P16}

        Lbl_Product(3) = {lbl_Product_P17, lbl_Product_P18, lbl_Product_P19, lbl_Product_P20,
            lbl_Product_P21, lbl_Product_P22, lbl_Product_P23}


        Lbl_Bleed(0) = {lbl_Bleed_P1, lbl_Bleed_P2, lbl_Bleed_P3, lbl_Bleed_P4,
            lbl_Bleed_P5, lbl_Bleed_P6, lbl_Bleed_P7, lbl_Bleed_P8
           }

        Lbl_Bleed(1) = {lbl_Bleed_P9, lbl_Bleed_P10, lbl_Bleed_P11, lbl_Bleed_P12}



        Lbl_Pump(0) = {lbl_Pump_P1, lbl_Pump_P2, lbl_Pump_P3, lbl_Pump_P4,
            lbl_Pump_P5, lbl_Pump_P6, lbl_Pump_P7, lbl_Pump_P8,
            lbl_Pump_P9, lbl_Pump_P10}

        Lbl_Pump(1) = {lbl_Pump_P11, lbl_Pump_P12,
            lbl_Pump_P13, lbl_Pump_P14, lbl_Pump_P15, lbl_Pump_P16,
            lbl_Pump_P17, lbl_Pump_P18}


        Lbl_N2Purge = {lbl_N2Purge_P1, lbl_N2Purge_P2, lbl_N2Purge_P3, lbl_N2Purge_P4,
            lbl_N2Purge_P5, lbl_N2Purge_P6, lbl_N2Purge_P7, lbl_N2Purge_P8,
            lbl_N2Purge_P9, lbl_N2Purge_P10, lbl_N2Purge_P11, lbl_N2Purge_P12,
            lbl_N2Purge_P13, lbl_N2Purge_P14, lbl_N2Purge_P15, lbl_N2Purge_P16,
            lbl_N2Purge_P17, lbl_N2Purge_P18, lbl_N2Purge_P19, lbl_N2Purge_P20,
            lbl_N2Purge_P21, lbl_N2Purge_P22, lbl_N2Purge_P23, lbl_N2Purge_P24,
            lbl_N2Purge_P25, lbl_N2Purge_P26, lbl_N2Purge_P27, lbl_N2Purge_P28,
            lbl_N2Purge_P29, lbl_N2Purge_P30, lbl_N2Purge_P31, lbl_N2Purge_P32,
            lbl_N2Purge_P33, lbl_N2Purge_P34, lbl_N2Purge_P35, lbl_N2Purge_P36,
            lbl_N2Purge_P37, lbl_N2Purge_P38, lbl_N2Purge_P39, lbl_N2Purge_P40,
            lbl_N2Purge_P41, lbl_N2Purge_P42, lbl_N2Purge_P43, lbl_N2Purge_P44,
            lbl_N2Purge_P45, lbl_N2Purge_P46, lbl_N2Purge_P47, lbl_N2Purge_P48,
            lbl_N2Purge_P49, lbl_N2Purge_P50, lbl_N2Purge_P51, lbl_N2Purge_P52,
            lbl_N2Purge_P53, lbl_N2Purge_P54, lbl_N2Purge_P55, lbl_N2Purge_P56,
            lbl_N2Purge_P57, lbl_N2Purge_P58
            }

        CircuitInitalised = True


    End Sub

    ' Circuit Control logic
    Private Sub CircuitTimer_Ticks(sender As Object, e As EventArgs) Handles Circuittimer.Tick

        If CommLost = False Then
            If CircuitInitalised = True Then
                ' For Output of Valve 1 to Valve 16
                For i As Integer = 0 To 15
                    If DOut(1)(i) = True Then
                        Lbl_ValvestatusArr(i).BackColor = Color.LimeGreen
                    Else
                        Lbl_ValvestatusArr(i).BackColor = SystemColors.Window
                    End If
                Next

                ' For Output of Valve 17 to Valve 19
                For i As Integer = 0 To 2
                    If DOut(2)(i) = True Then
                        Lbl_ValvestatusArr(i + 16).BackColor = Color.LimeGreen
                    Else
                        Lbl_ValvestatusArr(i + 16).BackColor = SystemColors.Window
                    End If
                Next


                ' Colour selection based on N2 Purge valve Output
                If Lbl_ValvestatusArr(10).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(17).BackColor = Color.LimeGreen Then
                    bgcolor = Color.Yellow
                Else
                    bgcolor = Color.FromArgb(25, 130, 246)
                End If


                'Based on Output setting Path for Valve-1 to Valve 19
                If Not btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
                    For i As Integer = 1 To 19
                        For j As Integer = 0 To Lbl_Valvepath(i).Length - 1
                            Lbl_Valvepath(i)(j).Visible = True
                            Lbl_Valvepath(i)(j).BorderStyle = BorderStyle.None
                        Next
                    Next

                    For i As Integer = 0 To 18
                        If Lbl_ValvestatusArr(i).BackColor = Color.LimeGreen Then
                            If i < 7 And i <> 18 Then
                                If pathtask(i + 1) = False Then

                                    CircuitMimic(i + 1)
                                End If
                            Else
                                If pathtask(i + 1) = False Then

                                    CircuitMimic(i + 1)
                                End If
                            End If

                        Else

                            For k As Integer = 0 To Lbl_Valvepath(i + 1).Length - 1
                                Lbl_Valvepath(i + 1)(k).BackColor = Color.Transparent
                                Lbl_Valvepath(i + 1)(k).Visible = False
                            Next

                        End If
                    Next
                Else
                    For i As Integer = 1 To 19
                        For j As Integer = 0 To Lbl_Valvepath(i).Length - 1
                            Lbl_Valvepath(i)(j).BackColor = Color.Transparent
                            Lbl_Valvepath(i)(j).Visible = False
                        Next
                    Next
                End If


                'For Income Line Path
                'pathfwdack -0,1,2,3
                If Not btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then

                    For i As Integer = 0 To Lbl_Income.Length - 1
                        For j As Integer = 0 To Lbl_Income(i).Length - 1
                            Lbl_Income(i)(j).BorderStyle = BorderStyle.None
                            Lbl_Income(i)(j).Visible = True
                        Next

                        If pathfwdack(i) = False Then
                            For j As Integer = 0 To Lbl_Income(i).Length - 1
                                Lbl_Income(i)(j).BackColor = Color.Transparent
                                Lbl_Income(i)(j).Visible = True
                            Next
                            Circuitforward(Lbl_Income(i), i, 200, Color.FromArgb(25, 130, 246))
                        End If
                    Next

                Else
                    For i As Integer = 0 To Lbl_Income.Length - 1

                        For j As Integer = 0 To Lbl_Income(i).Length - 1
                            Lbl_Income(i)(j).BackColor = Color.Transparent
                            Lbl_Income(i)(j).Visible = False
                        Next

                    Next
                End If

                'For N2 Purge Path
                'pathfwdack -4
                If Not btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then


                    If pathfwdack(4) = False Then
                        For i As Integer = 0 To Lbl_N2Purge.Length - 1
                            Lbl_N2Purge(i).Visible = True
                            Lbl_N2Purge(i).BackColor = Color.Transparent
                            Lbl_N2Purge(i).BorderStyle = BorderStyle.None
                        Next
                        Circuitforward(Lbl_N2Purge, 4, 50, Color.Yellow)
                    End If

                Else

                    For i As Integer = 0 To Lbl_N2Purge.Length - 1
                        Lbl_N2Purge(i).BackColor = Color.Transparent
                        Lbl_N2Purge(i).Visible = False
                    Next
                End If

                'For Junction Path
                'pathfwdack -5,6
                If Not btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
                    If (Lbl_ValvestatusArr(10).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(8).BackColor = Color.LimeGreen) Then
                        For i As Integer = 0 To Lbl_Junction.Length - 1
                            For j As Integer = 0 To Lbl_Junction(i).Length - 1
                                Lbl_Junction(i)(j).BorderStyle = BorderStyle.None
                                Lbl_Junction(i)(j).Visible = True
                            Next
                            If (Lbl_ValvestatusArr(10).BackColor = Color.LimeGreen) Then
                                If pathfwdack(i + 5) = False Then
                                    For j As Integer = 0 To Lbl_Junction(i).Length - 1
                                        Lbl_Junction(i)(j).BackColor = Color.Transparent
                                        Lbl_Junction(i)(j).Visible = True
                                    Next
                                    Circuitforward(Lbl_Junction(i), i + 5, 500, Color.Yellow)
                                End If
                            Else


                                If i = 0 Then
                                    If pathrevack(i + 5) = False Then
                                        For j As Integer = 0 To Lbl_Junction(i).Length - 1
                                            Lbl_Junction(i)(j).BackColor = Color.Transparent
                                            Lbl_Junction(i)(j).Visible = True
                                        Next
                                        Circuitreverse(Lbl_Junction(i), i + 5, 500, Color.FromArgb(25, 130, 246))
                                    End If

                                Else
                                    If pathfwdack(i + 5) = False Then
                                        For j As Integer = 0 To Lbl_Junction(i).Length - 1
                                            Lbl_Junction(i)(j).BackColor = Color.Transparent
                                            Lbl_Junction(i)(j).Visible = True
                                        Next
                                        Circuitforward(Lbl_Junction(i), i + 5, 500, Color.FromArgb(25, 130, 246))
                                    End If

                                End If


                            End If

                        Next
                    Else
                        For i As Integer = 0 To Lbl_Junction.Length - 1

                            For j As Integer = 0 To Lbl_Junction(i).Length - 1
                                Lbl_Junction(i)(j).BackColor = Color.Transparent
                                Lbl_Junction(i)(j).Visible = False
                            Next

                        Next
                    End If
                Else
                    For i As Integer = 0 To Lbl_Junction.Length - 1

                        For j As Integer = 0 To Lbl_Junction(i).Length - 1
                            Lbl_Junction(i)(j).BackColor = Color.Transparent
                            Lbl_Junction(i)(j).Visible = False
                        Next

                    Next
                End If

                'For Product Path
                'pathfwdack -7,8,9,10
                If Not btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
                    If (Lbl_ValvestatusArr(9).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(12).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(13).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(14).BackColor = Color.LimeGreen) Then
                        For i As Integer = 0 To Lbl_Product.Length - 1
                            For j As Integer = 0 To Lbl_Product(i).Length - 1
                                Lbl_Product(i)(j).BorderStyle = BorderStyle.None
                                Lbl_Product(i)(j).Visible = True
                            Next

                            If pathfwdack(i + 7) = False Then
                                For j As Integer = 0 To Lbl_Product(i).Length - 1
                                    Lbl_Product(i)(j).BackColor = Color.Transparent
                                    Lbl_Product(i)(j).Visible = True
                                Next
                                Circuitforward(Lbl_Product(i), i + 7, 500, bgcolor)
                            End If
                        Next
                    Else
                        For i As Integer = 0 To Lbl_Product.Length - 1

                            For j As Integer = 0 To Lbl_Product(i).Length - 1
                                Lbl_Product(i)(j).BackColor = Color.Transparent
                                Lbl_Product(i)(j).Visible = False
                            Next

                        Next
                    End If
                Else
                    For i As Integer = 0 To Lbl_Product.Length - 1

                        For j As Integer = 0 To Lbl_Product(i).Length - 1
                            Lbl_Product(i)(j).BackColor = Color.Transparent
                            Lbl_Product(i)(j).Visible = False
                        Next

                    Next
                End If

                'For Bleed Path
                'pathfwdack -11,12,13
                If Not btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
                    If (Lbl_ValvestatusArr(12).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(13).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(17).BackColor = Color.LimeGreen) Then
                        For i As Integer = 0 To Lbl_Bleed.Length - 1
                            For j As Integer = 0 To Lbl_Bleed(i).Length - 1
                                Lbl_Bleed(i)(j).BorderStyle = BorderStyle.None
                                Lbl_Bleed(i)(j).Visible = True
                            Next

                            If pathfwdack(i + 11) = False Then
                                For j As Integer = 0 To Lbl_Bleed(i).Length - 1
                                    Lbl_Bleed(i)(j).BackColor = Color.Transparent
                                    Lbl_Bleed(i)(j).Visible = True
                                Next
                                Circuitforward(Lbl_Bleed(i), i + 11, 500, bgcolor)
                            End If
                        Next
                    Else
                        For i As Integer = 0 To Lbl_Bleed.Length - 1

                            For j As Integer = 0 To Lbl_Bleed(i).Length - 1
                                Lbl_Bleed(i)(j).BackColor = Color.Transparent
                                Lbl_Bleed(i)(j).Visible = False
                            Next

                        Next
                    End If
                Else
                    For i As Integer = 0 To Lbl_Bleed.Length - 1

                        For j As Integer = 0 To Lbl_Bleed(i).Length - 1
                            Lbl_Bleed(i)(j).BackColor = Color.Transparent
                            Lbl_Bleed(i)(j).Visible = False
                        Next

                    Next
                End If



                'For Pump Path
                'pathfwdack -14,15
                If Not btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
                    If (Lbl_ValvestatusArr(18).BackColor = Color.LimeGreen) Then
                        For i As Integer = 0 To Lbl_Pump.Length - 1
                            For j As Integer = 0 To Lbl_Pump(i).Length - 1
                                Lbl_Pump(i)(j).BorderStyle = BorderStyle.None
                                Lbl_Pump(i)(j).Visible = True
                            Next

                            If pathfwdack(i + 14) = False Then
                                For j As Integer = 0 To Lbl_Pump(i).Length - 1
                                    Lbl_Pump(i)(j).BackColor = Color.Transparent
                                    Lbl_Pump(i)(j).Visible = True
                                Next
                                Circuitforward(Lbl_Pump(i), i + 14, 1000, Color.FromArgb(25, 130, 246))
                            End If
                        Next
                    Else
                        For i As Integer = 0 To Lbl_Pump.Length - 1

                            For j As Integer = 0 To Lbl_Pump(i).Length - 1
                                Lbl_Pump(i)(j).BackColor = Color.Transparent
                                Lbl_Pump(i)(j).Visible = False
                            Next

                        Next
                    End If
                Else
                    For i As Integer = 0 To Lbl_Pump.Length - 1

                        For j As Integer = 0 To Lbl_Pump(i).Length - 1
                            Lbl_Pump(i)(j).BackColor = Color.Transparent
                            Lbl_Pump(i)(j).Visible = False
                        Next

                    Next
                End If


                'For Non Pressurised Drain Path
                'pathfwdack -16
                If Not btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
                    If (Lbl_ValvestatusArr(0).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(1).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(2).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(4).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(6).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(7).BackColor = Color.LimeGreen) Then
                        If pathfwdack(16) = False Then
                            For i As Integer = 0 To Lbl_NPDrain.Length - 1
                                Lbl_NPDrain(i).Visible = True
                                Lbl_NPDrain(i).BackColor = Color.Transparent
                                Lbl_NPDrain(i).BorderStyle = BorderStyle.None
                            Next
                            Circuitforward(Lbl_NPDrain, 16, 100, Color.FromArgb(25, 130, 246))
                        End If

                    Else

                        For i As Integer = 0 To Lbl_NPDrain.Length - 1
                            Lbl_NPDrain(i).BackColor = Color.Transparent
                            Lbl_NPDrain(i).Visible = False
                        Next
                    End If
                Else
                    For i As Integer = 0 To Lbl_NPDrain.Length - 1
                        Lbl_NPDrain(i).BackColor = Color.Transparent
                        Lbl_NPDrain(i).Visible = False
                    Next
                End If

                'For Pressurised Drain Path
                'pathfwdack -17,18,19
                If Not btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
                    If (Lbl_ValvestatusArr(11).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(14).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(15).BackColor = Color.LimeGreen Or Lbl_ValvestatusArr(16).BackColor = Color.LimeGreen) Then
                        For i As Integer = 0 To Lbl_PDrain.Length - 1
                            For j As Integer = 0 To Lbl_PDrain(i).Length - 1
                                Lbl_PDrain(i)(j).BorderStyle = BorderStyle.None
                                Lbl_PDrain(i)(j).Visible = True
                            Next

                            If pathfwdack(i + 17) = False Then
                                For j As Integer = 0 To Lbl_PDrain(i).Length - 1
                                    Lbl_PDrain(i)(j).BackColor = Color.Transparent
                                    Lbl_PDrain(i)(j).Visible = True
                                Next
                                Circuitforward(Lbl_PDrain(i), i + 17, 500, bgcolor)
                            End If
                        Next
                    Else
                        For i As Integer = 0 To Lbl_PDrain.Length - 1

                            For j As Integer = 0 To Lbl_PDrain(i).Length - 1
                                Lbl_PDrain(i)(j).BackColor = Color.Transparent
                                Lbl_PDrain(i)(j).Visible = False
                            Next

                        Next
                    End If
                Else
                    For i As Integer = 0 To Lbl_PDrain.Length - 1

                        For j As Integer = 0 To Lbl_PDrain(i).Length - 1
                            Lbl_PDrain(i)(j).BackColor = Color.Transparent
                            Lbl_PDrain(i)(j).Visible = False
                        Next

                    Next
                End If
            End If
#Region "Mimic Panel Circuit Model 1"

            txtbx_BackPressActual.Text = AIn(1).ToString
            txtbx_N2PurgeActual.Text = AIn(0).ToString
            lbl_InletPress.Text = AIn(9).ToString
            lbl_OutletPress.Text = AIn(10).ToString
            lbl_Flowmtr.Text = AIn(12).ToString
            lbl_Temp.Text = AIn(13).ToString
            lbl_PumpPress.Text = AIn(8).ToString
            lbl_N2Press.Text = AIn(11).ToString
            lbl_PumpSpeed.Text = AIn(2).ToString

            If DOut(2)(5) = False Then
                lbl_PumpEnable.BackColor = SystemColors.Window
            Else
                lbl_PumpEnable.BackColor = Color.LimeGreen
            End If

            If DIn(1)(2) = False Then
                lbl_PumpHighHigh.BackColor = SystemColors.Window
            Else
                lbl_PumpHighHigh.BackColor = Color.LimeGreen
            End If

            If DIn(1)(3) = False Then
                lbl_PumpHigh.BackColor = SystemColors.Window
            Else
                lbl_PumpHigh.BackColor = Color.LimeGreen
            End If

            If DIn(1)(4) = False Then
                lbl_PumpLow.BackColor = SystemColors.Window
            Else
                lbl_PumpLow.BackColor = Color.LimeGreen
            End If

            If DIn(1)(5) = False Then
                lbl_PumpLowLow.BackColor = SystemColors.Window
            Else
                lbl_PumpLowLow.BackColor = Color.LimeGreen
            End If

#End Region

        End If


    End Sub


    Public Async Function CircuitMimic(Valve As Integer) As Task
        Dim delay As Integer

        Select Case Valve
            Case 1
                delay = 100
            Case 2
                delay = 100
            Case 3
                delay = 100
            Case 4
                delay = 100
            Case 5
                delay = 100
            Case 6
                delay = 100
            Case 7
                delay = 100
            Case 8
                delay = 100
            Case 9
                delay = 500
            Case 10
                delay = 500
            Case 11
                delay = 500
            Case 12
                delay = 500
            Case 13
                delay = 500
            Case 14
                delay = 500
            Case 15
                delay = 500
            Case 16
                delay = 500
            Case 17
                delay = 500
            Case 18
                delay = 500
            Case 19
                delay = 500
            Case Else
                Exit Select
        End Select


        While Lbl_ValvestatusArr(Valve - 1).BackColor = Color.LimeGreen
            pathtask(Valve) = True
            Dim size As Integer
            size = 0
            While size <= Lbl_Valvepath(Valve).Length - 1 And Lbl_ValvestatusArr(Valve - 1).BackColor = Color.LimeGreen
                Await Task.Delay(delay)
                If size = 0 Then
                    Lbl_Valvepath(Valve)(Lbl_Valvepath(Valve).Length - 1).BackColor = Color.Transparent
                    Lbl_Valvepath(Valve)(size).BackColor = bgcolor
                End If

                If size > 0 And size <= Lbl_Valvepath(Valve).Length - 1 Then
                    Lbl_Valvepath(Valve)(size - 1).BackColor = Color.Transparent
                    Lbl_Valvepath(Valve)(size).BackColor = bgcolor
                End If


                size = size + 1
            End While
        End While

        pathtask(Valve) = False





    End Function



    Public Async Function Circuitforward(lblarr As Label(), index As Integer, delay As Integer, bg As Color) As Task


        While lblarr(0).Visible = True
            pathrevack(index) = False
            pathfwdack(index) = True
            Dim size As Integer
            size = 0
            While size <= lblarr.Length - 1 And lblarr(0).Visible = True
                Await Task.Delay(delay)
                If size = 0 Then
                    lblarr(lblarr.Length - 1).BackColor = Color.Transparent

                    lblarr(size).BackColor = bg
                End If

                If size > 0 And size <= lblarr.Length - 1 Then
                    lblarr(size - 1).BackColor = Color.Transparent

                    lblarr(size).BackColor = bg
                End If


                size = size + 1
            End While

        End While

        pathfwdack(index) = False
    End Function


    Public Async Function Circuitreverse(lblarr As Label(), index As Integer, delay As Integer, bg As Color) As Task


        While lblarr(0).Visible = True
            pathfwdack(index) = False
            pathrevack(index) = True
            Dim size As Integer
            size = lblarr.Length - 1
            While size >= 0 And lblarr(0).Visible = True
                Await Task.Delay(delay)
                If size = lblarr.Length - 1 Then
                    lblarr(0).BackColor = Color.Transparent

                    lblarr(size).BackColor = bg
                End If

                If size >= 0 And size < lblarr.Length - 1 Then
                    lblarr(size + 1).BackColor = Color.Transparent

                    lblarr(size).BackColor = bg
                End If


                size = size - 1
            End While

        End While

        pathrevack(index) = False
    End Function



    Public Sub ChildformOverview(Childform As Form)

        Childform.TopLevel = False
        While FormMain.panel_ManualValve_Circuit.Controls.Count > 0
            FormMain.panel_ManualValve_Circuit.Controls(0).Dispose()
        End While
        FormMain.panel_ManualValve_Circuit.Controls.Add(Childform)
        Childform.Show()
        CircuitShown(0) = True
        CircuitShown(1) = False
        CircuitShown(2) = False
        CircuitShown(3) = False
    End Sub


End Class
