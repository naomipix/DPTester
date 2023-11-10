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
                            DI_0 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 1
                            DI_1 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 2
                            DI_2 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 3
                            DI_3 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 4
                            DI_4 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 5
                            DI_5 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 6
                            DI_6 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 7
                            DI_7 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 8
                            DI_8 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 9
                            DI_9 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 10
                            DI_10 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 11
                            DI_11 = If(dtActivityIO(i)("value") = 1, True, False)

                        Case 12
                            DO_0 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 13
                            DO_1 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 14
                            DO_2 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 15
                            DO_3 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 16
                            DO_4 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 17
                            DO_5 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 18
                            DO_6 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 19
                            DO_7 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 20
                            DO_8 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 21
                            DO_9 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 22
                            DO_10 = If(dtActivityIO(i)("value") = 1, True, False)
                        Case 23
                            DO_11 = If(dtActivityIO(i)("value") = 1, True, False)

                        Case 24
                            AI_0 = CDec(dtActivityIO(i)("value"))
                        Case 25
                            AI_1 = CDec(dtActivityIO(i)("value"))
                        Case 26
                            AI_2 = CDec(dtActivityIO(i)("value"))
                        Case 27
                            AI_3 = CDec(dtActivityIO(i)("value"))
                        Case 28
                            AI_4 = CDec(dtActivityIO(i)("value"))
                        Case 29
                            AI_5 = CDec(dtActivityIO(i)("value"))
                        Case 30
                            AI_6 = CDec(dtActivityIO(i)("value"))
                        Case 31
                            AI_7 = CDec(dtActivityIO(i)("value"))
                        Case 32
                            AI_8 = CDec(dtActivityIO(i)("value"))
                        Case 33
                            AI_9 = CDec(dtActivityIO(i)("value"))
                        Case 34
                            AI_10 = CDec(dtActivityIO(i)("value"))
                        Case 35
                            AI_11 = CDec(dtActivityIO(i)("value"))

                        Case 36
                            AO_0 = CDec(dtActivityIO(i)("value"))
                        Case 37
                            AO_1 = CDec(dtActivityIO(i)("value"))
                        Case 38
                            AO_2 = CDec(dtActivityIO(i)("value"))
                        Case 39
                            AO_3 = CDec(dtActivityIO(i)("value"))
                        Case 40
                            AO_4 = CDec(dtActivityIO(i)("value"))
                        Case 41
                            AO_5 = CDec(dtActivityIO(i)("value"))
                        Case 42
                            'AO_6 = CDec(dtActivityIO(i)("value"))
                        Case 43
                            'AO_7 = CDec(dtActivityIO(i)("value"))
                        Case 44
                            'AO_8 = CDec(dtActivityIO(i)("value"))
                        Case 45
                            'AO_9 = CDec(dtActivityIO(i)("value"))
                        Case 46
                            'AO_10 = CDec(dtActivityIO(i)("value"))
                        Case 47
                            'AO_11 = CDec(dtActivityIO(i)("value"))
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
                DI_0, DI_1, DI_2, DI_3, DI_4, DI_5, DI_6, DI_7,
                DI_8, DI_9, DI_10, DI_11, DI_12, DI_13, DI_14, DI_15,
                DI_16, DI_17, DI_18, DI_19, DI_20, DI_21, DI_22, DI_23,
                DI_24, DI_25, DI_26, DI_27, DI_28, DI_29 ', DI_30, DI_31
                }

                Dim D_Out() As Boolean = {
                    DO_0, DO_1, DO_2, DO_3, DO_4, DO_5, DO_6, DO_7,
                    DO_8, DO_9, DO_10, DO_11, DO_12, DO_13, DO_14, DO_15,
                    DO_16, DO_17, DO_18, DO_19, DO_20, DO_21, DO_22, DO_23,
                    DO_24, DO_25, DO_26, DO_27, DO_28, DO_29, DO_30, DO_31,
                    DO_32, DO_33, DO_34, DO_35, DO_36, DO_37, DO_38, DO_39,
                    DO_40, DO_41 ', DO_42, DO_43, DO_44, DO_45, DO_46, DO_47
                }

                Dim A_In() As Decimal = {
                    AI_0, AI_1, AI_2, AI_3, AI_4, AI_5, AI_6, AI_7,
                    AI_8, AI_9, AI_10, AI_11, AI_12, AI_13, AI_14, AI_15
                }

                Dim A_Out() As Decimal = {
                    AO_0, AO_1, AO_2, AO_3, AO_4, AO_5', AO_6, AO_7, AO_8, AO_9, AO_10, AO_11, AO_12, AO_13, AO_14, AO_15
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
