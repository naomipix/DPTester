Public Class ClassActivity
    Public Shared Async Function GetActivityIO() As Task
        Do While True
            Await Task.Delay(100)

            Dim SqlString As String = "
            SELECT * FROM Z_TEST_TABLE_DONOTDELETE
            "
            Dim dtActivityIO As DataTable = Await Task.Run(Function() SQL.ReadRecords(SqlString))
            Try
                For i As Integer = 0 To dtActivityIO.Rows.Count - 1
                    Select Case i
                        Case 0
                            DIO_IN_0 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 1
                            DIO_IN_1 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 2
                            DIO_IN_2 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 3
                            DIO_IN_3 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 4
                            DIO_IN_4 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 5
                            DIO_IN_5 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 6
                            DIO_IN_6 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 7
                            DIO_IN_7 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 8
                            DIO_IN_8 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 9
                            DIO_IN_9 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 10
                            DIO_IN_10 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 11
                            DIO_IN_11 = If(dtActivityIO(i)("value") = 1, True, False)

                        Case 12
                            DIO_OUT_0 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 13
                            DIO_OUT_1 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 14
                            DIO_OUT_2 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 15
                            DIO_OUT_3 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 16
                            DIO_OUT_4 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 17
                            DIO_OUT_5 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 18
                            DIO_OUT_6 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 19
                            DIO_OUT_7 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 20
                            DIO_OUT_8 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 21
                            DIO_OUT_9 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 22
                            DIO_OUT_10 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 23
                            DIO_OUT_11 = If(dtActivityIO(i)("value") = 1, True, False)

                        Case 24
                            AIO_IN_0 = CDec(dtActivityIO(i)("value"))
                        Case 25
                            AIO_IN_1 = CDec(dtActivityIO(i)("value"))
                        Case 26
                            AIO_IN_2 = CDec(dtActivityIO(i)("value"))
                        Case 27
                            AIO_IN_3 = CDec(dtActivityIO(i)("value"))
                        Case 28
                            AIO_IN_4 = CDec(dtActivityIO(i)("value"))
                        Case 29
                            AIO_IN_5 = CDec(dtActivityIO(i)("value"))
                        Case 30
                            AIO_IN_6 = CDec(dtActivityIO(i)("value"))
                        Case 31
                            AIO_IN_7 = CDec(dtActivityIO(i)("value"))
                        Case 32
                            AIO_IN_8 = CDec(dtActivityIO(i)("value"))
                        Case 33
                            AIO_IN_9 = CDec(dtActivityIO(i)("value"))
                        Case 34
                            AIO_IN_10 = CDec(dtActivityIO(i)("value"))
                        Case 35
                            AIO_IN_11 = CDec(dtActivityIO(i)("value"))

                        Case 36
                            AIO_OUT_0 = CDec(dtActivityIO(i)("value"))
                        Case 37
                            AIO_OUT_1 = CDec(dtActivityIO(i)("value"))
                        Case 38
                            AIO_OUT_2 = CDec(dtActivityIO(i)("value"))
                        Case 39
                            AIO_OUT_3 = CDec(dtActivityIO(i)("value"))
                        Case 40
                            AIO_OUT_4 = CDec(dtActivityIO(i)("value"))
                        Case 41
                            AIO_OUT_5 = CDec(dtActivityIO(i)("value"))
                        Case 42
                            'AIO_OUT_6 = CDec(dtActivityIO(i)("value"))
                        Case 43
                            'AIO_OUT_7 = CDec(dtActivityIO(i)("value"))
                        Case 44
                            'AIO_OUT_8 = CDec(dtActivityIO(i)("value"))
                        Case 45
                            'AIO_OUT_9 = CDec(dtActivityIO(i)("value"))
                        Case 46
                            'AIO_OUT_10 = CDec(dtActivityIO(i)("value"))
                        Case 47
                            'AIO_OUT_11 = CDec(dtActivityIO(i)("value"))
                    End Select
                Next
            Catch ex As Exception
            End Try
        Loop
    End Function


    Public Shared Async Function UpdateActivityIO() As Task
        Do While True
            Await Task.Delay(20)

            Try
                Dim D_In() As Boolean = {
                DIO_IN_0, DIO_IN_1, DIO_IN_2, DIO_IN_3, DIO_IN_4, DIO_IN_5, DIO_IN_6, DIO_IN_7,
                DIO_IN_8, DIO_IN_9, DIO_IN_10, DIO_IN_11, DIO_IN_12, DIO_IN_13, DIO_IN_14, DIO_IN_15,
                DIO_IN_16, DIO_IN_17, DIO_IN_18, DIO_IN_19, DIO_IN_20, DIO_IN_21, DIO_IN_22, DIO_IN_23,
                DIO_IN_24, DIO_IN_25, DIO_IN_26, DIO_IN_27, DIO_IN_28, DIO_IN_29 ', DIO_IN_30, DIO_IN_31
                }

                Dim D_Out() As Boolean = {
                    DIO_OUT_0, DIO_OUT_1, DIO_OUT_2, DIO_OUT_3, DIO_OUT_4, DIO_OUT_5, DIO_OUT_6, DIO_OUT_7,
                    DIO_OUT_8, DIO_OUT_9, DIO_OUT_10, DIO_OUT_11, DIO_OUT_12, DIO_OUT_13, DIO_OUT_14, DIO_OUT_15,
                    DIO_OUT_16, DIO_OUT_17, DIO_OUT_18, DIO_OUT_19, DIO_OUT_20, DIO_OUT_21, DIO_OUT_22, DIO_OUT_23,
                    DIO_OUT_24, DIO_OUT_25, DIO_OUT_26, DIO_OUT_27, DIO_OUT_28, DIO_OUT_29, DIO_OUT_30, DIO_OUT_31,
                    DIO_OUT_32, DIO_OUT_33, DIO_OUT_34, DIO_OUT_35, DIO_OUT_36, DIO_OUT_37, DIO_OUT_38, DIO_OUT_39,
                    DIO_OUT_40, DIO_OUT_41 ', DIO_OUT_42, DIO_OUT_43, DIO_OUT_44, DIO_OUT_45, DIO_OUT_46, DIO_OUT_47
                }

                Dim A_In() As Decimal = {
                    AIO_IN_0, AIO_IN_1, AIO_IN_2, AIO_IN_3, AIO_IN_4, AIO_IN_5, AIO_IN_6, AIO_IN_7,
                    AIO_IN_8, AIO_IN_9, AIO_IN_10, AIO_IN_11, AIO_IN_12, AIO_IN_13, AIO_IN_14, AIO_IN_15
                }

                Dim A_Out() As Decimal = {
                    AIO_OUT_0, AIO_OUT_1, AIO_OUT_2, AIO_OUT_3, AIO_OUT_4, AIO_OUT_5', AIO_OUT_6, AIO_OUT_7, AIO_OUT_8, AIO_OUT_9, AIO_OUT_10, AIO_OUT_11, AIO_OUT_12, AIO_OUT_13, AIO_OUT_14, AIO_OUT_15
                }

                For i As Integer = 0 To 11
                    FormMain.dgv_DigitalInput.Rows(i).Cells("value").Value = D_In(i)
                    FormMain.dgv_DigitalOutput.Rows(i).Cells("value").Value = D_Out(i)
                    FormMain.dgv_AnalogInput.Rows(i).Cells("value").Value = A_In(i)

                    If i <= 9 Then
                        FormMain.dgv_AnalogOutput.Rows(i).Cells("value").Value = A_Out(i)
                    End If
                Next
            Catch ex As Exception
            End Try
        Loop
    End Function
End Class
