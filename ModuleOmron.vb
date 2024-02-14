Imports PoohPlcLink
Imports EEIP
Imports System.Text
Imports System.ComponentModel
Imports System.Runtime.InteropServices.ComTypes
Imports System.Diagnostics.Eventing.Reader
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic.ApplicationServices
Imports DocumentFormat.OpenXml.Drawing

Module ModuleOmron
    ' This Module consists of the some data conversions needed for reading and writing values to the PLC
    Public OmronPLC As New PoohFinsETN
    'Public OmronEEIP As New EEIPClient
    Public DIn(9)() As Boolean 'Consists of DM600-DM609
    Public DOut(9)() As Boolean 'Consists of DM610-DM619
    Public AIn(19) As Decimal 'Consists of DM620-DM659
    Public AOut(9) As Decimal 'Consists of DM660-DM679
    Public Alarm(19)() As Boolean 'Consists of DM700-DM709

    Public ManualCtrl(5)() As Boolean ' Consists of DM3 to DM8
    Public FINSinput() As Integer
    Public FINSOutput(199) As Integer
    Public WithEvents PLCtimer As New Timer()
    Public WithEvents PCtimer As New Timer()
    Public WithEvents Alarmtimer As New Timer()
    Public WithEvents Calseqtimer As New Timer()
    Public WithEvents Resultcapturetimer As New Timer()
    Public PLCstatus(2)() As Boolean
    Public ToolCounterreset(1)() As Boolean
    Public PCStatus(2)() As Boolean
    Public dtAlarm As New DataTable
    Public Currentalarm As New Dictionary(Of Integer, Object)
    Public startindex As Integer = 0
    Public Currentindex As Integer = 0
    Public Cal_MessageNo As Integer = 0
    Public dtCalibrationmsg As New DataTable
    Public CalrecordValue As Boolean
    Public Main_MessageNo As Integer = 0
    Public dtMainmsg As New DataTable
    Public MainrecordValue As Boolean
    Public MainCycletime As Integer = 0
    Public MainDptestpoints As Integer
    Public result_samplingtime As Decimal
    Public result_temperature As Decimal
    Public result_flowrate As Decimal
    Public result_inletpressure As Decimal
    Public result_outletpressure As Decimal
    Public result_dp As Decimal
    Public result_avginlet1 As Decimal
    Public result_avgoutlet1 As Decimal
    Public result_avgdp1 As Decimal
    Public result_avginlet2 As Decimal
    Public result_avgoutlet2 As Decimal
    Public result_avgdp2 As Decimal
    Public result_finalinlet As Decimal
    Public result_finaloutlet As Decimal
    Public result_finaldp As Decimal
    Public result_avgtemperature1 As Decimal
    Public result_avgflowrate1 As Decimal
    Public result_avgtemperature2 As Decimal
    Public result_avgflowrate2 As Decimal
    Public result_finaltemperature As Decimal
    Public result_finalflowrate As Decimal
    Public dtrecipetable As DataTable
    Public MainDptest1start As Integer
    Public MainDptest1end As Integer
    Public MainDptest2start As Integer
    Public MainDptest2end As Integer
    Public dtserialrecord As New DataTable
    Public Viscosity As Double
    Public CommLost As Boolean



#Region "FINS protocol"
    Public Sub FINSInitialise()
        OmronPLC.PLC_IPAddress = "192.168.0.1"
        OmronPLC.PLC_NodeNo = "1"
        OmronPLC.PLC_NetNo = "0"
        OmronPLC.PLC_UDPPort = "9600"
        OmronPLC.PC_NodeNo = "2"
        OmronPLC.PC_NetNo = "0"
        OmronPLC.TimeOutMSec = "1000"
        dtAlarm = SQL.ReadRecords("select id,code,description from AlarmTable")
        dtCalibrationmsg = SQL.ReadRecords("select * from CalibrationMessage")
        dtMainmsg = SQL.ReadRecords("select * from ProcessMessage")

        FINSOutputRead()

        PLCtimer.Interval = 100
        PLCtimer.Enabled = True
        PCtimer.Interval = 3000
        Alarmtimer.Interval = 1500

        Calseqtimer.Interval = 2000
        Resultcapturetimer.Interval = 500

        For i As Integer = 0 To 2

            PCStatus(i) = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}

        Next

        For i As Integer = 0 To 2

            PLCstatus(i) = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}

        Next

        For i As Integer = 0 To 1
            ToolCounterreset(i) = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        Next

    End Sub


    Public Function RealFromPLC(PLC As PoohFinsETN, Mem As PoohFinsETN.MemoryTypes, Startoffset As Integer) As String
        'This Function convert Hex string given by PLC on reading its Memory into Boolean string, so that it can be used to find the Float/decimal value
        Dim hexchar As String
        Dim firstpart As String
        Dim secondpart As String
        Dim modhex As String
        Dim boolstring As New StringBuilder
        Dim hextoint(7) As Integer
        'On reading the PLC Memory it will give the string of Hex Character
        hexchar = (PLC.ReadMemory(Mem, Startoffset, 2))

        'The String has to be 2 words, we need to swap the words before processing
        firstpart = hexchar.Substring(0, 4)
        secondpart = hexchar.Substring(4, 4)
        modhex = String.Concat(secondpart, firstpart)


        'Convert the hex char into Decimal equivalent
        For i As Integer = 0 To modhex.Length - 1
            hextoint(i) = Convert.ToInt32(modhex.Substring(i, 1), 16)

        Next

        'Convert the Decimal equivalent into Boolean String
        For j As Integer = 0 To hexchar.Length - 1
            boolstring.Append(Convert.ToString(hextoint(j), 2).PadLeft(4, "0"c))
        Next

        Return (Math.Round(DecimalBoolStringtoDecimal(boolstring.ToString), 2)).ToString

    End Function




    Public Function DecimalBoolStringtoDecimal(str As String) As Decimal
        ' This Function Converts Decimal Boolstring into Decimal value
        Dim sign_int As Integer
        Dim exponent As Integer = 0
        Dim wholeNumber As Decimal = 0
        Dim fractionalnumber As Decimal = 0
        Dim result As Decimal
        Dim wholepart As String

        If str.Length = 32 Then
            'Separate the Sign from the Boolean string
            sign_int = CType(str.Substring(0, 1), Integer)
            ' Find the biased expoenent value
            For i As Integer = 0 To str.Length - 25
                exponent = exponent + (CType(str.Substring(str.Length - 24 - i, 1), Integer) * (2 ^ i))
            Next

            If exponent > 0 And exponent < 255 Then
                'Get the last 23 bits which constructs Mantissa portion
                wholepart = str.Substring(9, 23)

                'Obtain the Mantissa Part
                For j As Integer = 0 To wholepart.Length - 1
                    fractionalnumber = fractionalnumber + (CType(wholepart.Substring(j, 1), Integer) / (2 ^ (j + 1)))
                Next

                'Convert biased Exponent into unbiased exponent Value
                exponent = exponent - 127

                wholeNumber = 1
                If sign_int = 0 Then
                    result = ((wholeNumber + fractionalnumber) * (2 ^ exponent))
                    Return result
                Else
                    result = -((wholeNumber + fractionalnumber) * (2 ^ exponent))
                    Return result
                End If

            Else
                Return 0.0
            End If

        Else
            Return 0.0
        End If
        Return 0.0
    End Function

    Public Function RealtoPLC(PLC As PoohFinsETN, Mem As PoohFinsETN.MemoryTypes, Offset As Integer, real As Double) As Boolean
        Dim sign_value As Integer
        Dim fraction As Decimal
        Dim Absreal As Double = Math.Abs(real)
        Dim j As Integer = 0
        Dim exponent As Integer = 0
        Dim fractionpart As New StringBuilder
        Dim fractionfinal As String = ""
        Dim Binarypart As New StringBuilder
        Dim hexpart As New StringBuilder
        Dim val(2) As Int32

        ' Need to convert the decimal value into IEEE 754 form "0 10001000 10000000100101100000000"  bit 0 indicate sign, bit 1-8 indicate exponent, bit 9-31 indicate Mantessia
        'Finding the Sign Bit and add to binary text
        If real >= 0 Then
            sign_value = 0
            Binarypart.Append("0")
        Else
            sign_value = 1
            Binarypart.Append("1")
        End If

        'To find the exponent divide the number starting with 2 till we get value greater than 1 and less than 2
        If Absreal > 2 Then
            While Absreal > 2
                Absreal = Absreal / 2
                exponent = exponent + 1
            End While

        Else
            While Absreal < 1
                Absreal = Absreal * 2
                exponent = exponent - 1
            End While
        End If
        ' To Convert Signed exponent into unsigned bin
        If exponent >= -127 And exponent <= 127 Then
            exponent = 127 + exponent
        End If
        'Add binary of exponent to the binary text
        Binarypart.Append(DecToBin(exponent, 8))

        'Find the Value of Mantessa Part
        If Absreal > 1 Then
            fraction = Absreal - 1
        Else
            fraction = Absreal
        End If

        If fraction < 1 Then
            While fraction <> 0.0 And j < 23
                fraction = fraction * 2
                If fraction >= 1 Then
                    fractionpart.Append("1")
                    fraction = fraction - 1
                Else
                    fractionpart.Append("0")
                End If
                j = j + 1
            End While
        End If
        'If the Mantessa part length is less than 23, add zero to the right
        If (fractionpart.ToString).Length <= 23 Then
            fractionfinal = fractionpart.ToString.PadRight(23, "0"c)
        End If

        ' Add binary mantessa to binary text
        Binarypart.Append(fractionfinal)

        If Binarypart.ToString.Length = 32 Then
            hexpart.Append(BinToHex(Binarypart.ToString))
        End If
        'Convert binary to hex and then to Decimal
        val(0) = HextoDec(hexpart.ToString.Substring(hexpart.ToString.Length - 4, 4))
        val(1) = HextoDec(hexpart.ToString.Substring(0, 4))


        PLC.WriteMemoryWord(PoohFinsETN.MemoryTypes.DM, Offset, val(0), PoohFinsETN.DataTypes.UnSignBIN)
        PLC.WriteMemoryWord(PoohFinsETN.MemoryTypes.DM, Offset + 1, val(1), PoohFinsETN.DataTypes.UnSignBIN)
        Return True
    End Function



    Public Function Int2BoolArr(intval As Integer) As Boolean()
        '16 BIT WORD TO BOOLEAN(16)
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Value(1) As Byte
        Dim result(15) As Boolean

        Value = BitConverter.GetBytes(intval)

        For i As Integer = 0 To 7
            result(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
            result(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
        Next
        Return result
    End Function

    Public Function Boolarr2int(boolarr As Boolean()) As UInt16

        Dim Value(1) As Byte
        Dim result As UInt16

        Dim resultarr(15) As Boolean


        result = 0
        For i As Integer = 0 To boolarr.Length - 1
            If boolarr(i) = True Then
                result = result + (2 ^ i)
            End If
        Next

        Return result
    End Function


    Public Function Float2int(offset As Integer, real As Double) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim sign_value As Integer
        Dim fraction As Decimal
        Dim Absreal As Double = Math.Abs(real)
        Dim j As Integer = 0
        Dim exponent As Integer = 0
        Dim fractionpart As New StringBuilder
        Dim fractionfinal As String = ""
        Dim Binarypart As New StringBuilder
        Dim hexpart As New StringBuilder
        Dim hexstr As String
        Dim val(1) As UInt16

        ' Need to convert the decimal value into IEEE 754 form "0 10001000 10000000100101100000000"  bit 0 indicate sign, bit 1-8 indicate exponent, bit 9-31 indicate Mantessia
        'Finding the Sign Bit and add to binary text
        If real >= 0 Then
            sign_value = 0
            Binarypart.Append("0")
        Else
            sign_value = 1
            Binarypart.Append("1")
        End If

        'To find the exponent divide the number starting with 2 till we get value greater than 1 and less than 2
        If Absreal >= 2 Then
            While Absreal >= 2
                exponent = exponent + 1
                Absreal = Absreal / 2
            End While

        Else
            If Absreal < 2 And Absreal >= 1 Then
                Absreal = Absreal
                exponent = 0
            End If
            If Absreal <> 0 Then
                While Absreal < 1
                    Absreal = Absreal * 2
                    exponent = exponent - 1
                End While
            End If

            If Absreal = 0 Then
                Absreal = 0
                exponent = 0
            End If
        End If
        ' To Convert Signed exponent into unsigned bin
        If exponent >= -127 And exponent <= 127 And Absreal <> 0 Then
            exponent = 127 + exponent

        End If
        'Add binary of exponent to the binary text
        Binarypart.Append(DecToBin(exponent, 8))

        'Find the Value of Mantessa Part
        If Absreal >= 1 Then
            fraction = Absreal - 1
        Else
            fraction = Absreal
        End If

        If fraction < 1 Then
            While fraction <> 0.0 And j < 23
                fraction = fraction * 2
                If fraction >= 1 Then
                    fractionpart.Append("1")
                    fraction = fraction - 1
                Else
                    fractionpart.Append("0")
                End If
                j = j + 1
            End While

        End If
        'If the Mantessa part length is less than 23, add zero to the right
        If (fractionpart.ToString).Length <= 23 Then
            fractionfinal = fractionpart.ToString.PadRight(23, "0"c)
        End If

        ' Add binary mantessa to binary text
        Binarypart.Append(fractionfinal)

        If Binarypart.ToString.Length = 32 Then
            hexpart.Append(BinToHex(Binarypart.ToString))
        End If
        If hexpart.ToString.Length = 8 Then
            hexpart.Insert(0, hexpart.ToString.Substring(4, 4))
            hexstr = hexpart.ToString.Remove(8, 4)

        Else
            hexpart.Insert(0, "0000")
            hexstr = hexpart.ToString
        End If


        For k As Integer = 0 To 1
            val(k) = HextoDec(hexstr.Substring(k * 4, 4))
            FINSOutput(offset + k) = val(k)
        Next

        Return True
    End Function

    Public Function Int2Float(Intarr As Integer(), offset As Integer) As Decimal
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim hexchar As New StringBuilder
        Dim modhex As String
        Dim boolstring As New StringBuilder
        Dim hextoint(7) As Integer
        Dim Value0(1) As Byte
        Dim Value1(1) As Byte

        Value0 = BitConverter.GetBytes(Intarr(offset))
        Value1 = BitConverter.GetBytes(CInt(Intarr(offset + 1)))

        hexchar.Append(Value1(1).ToString("X2"))
        hexchar.Append(Value1(0).ToString("X2"))
        hexchar.Append(Value0(1).ToString("X2"))
        hexchar.Append(Value0(0).ToString("X2"))


        modhex = hexchar.ToString.Substring(0, 8)

        'Convert the hex char into Decimal equivalent
        For i As Integer = 0 To modhex.Length - 1
            hextoint(i) = Convert.ToInt32(modhex.Substring(i, 1), 16)
        Next

        'Convert the Decimal equivalent into Boolean String
        For j As Integer = 0 To hexchar.Length - 1
            boolstring.Append(Convert.ToString(hextoint(j), 2).PadLeft(4, "0"c))
        Next
        Return (Math.Round(DecimalBoolStringtoDecimal(boolstring.ToString), 2))
    End Function

    '   
    Public Function DInt2int(offset As Integer, Value As Int32) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Val As Byte() = BitConverter.GetBytes(Value)

        For i As Integer = 0 To 1
            FINSOutput(offset + i) = BitConverter.ToUInt16(Val, (i * 2))
        Next
        Return True
    End Function


#End Region


#Region "General Conversions"
    Public Function BinToHex(BinNum As String) As String
        Dim BinLen As Integer, i As Integer
        Dim HexNum As Object, strHexNum As String
        HexNum = 0
        BinLen = Len(BinNum)
        For i = BinLen To 1 Step -1
            If Asc(Mid(BinNum, i, 1)) < 48 Or Asc(Mid(BinNum, i, 1)) > 49 Then
                HexNum = ""
            End If
            If Mid(BinNum, i, 1) And 1 Then
                HexNum = HexNum + 2 ^ Math.Abs(i - BinLen)
            End If
        Next i
        strHexNum = Hex(HexNum)
        If Len(strHexNum) = 1 Then
            strHexNum = "000" & strHexNum
        ElseIf Len(strHexNum) = 2 Then
            strHexNum = "00" & strHexNum
        ElseIf Len(strHexNum) = 3 Then
            strHexNum = "0" & strHexNum
        End If
        BinToHex = strHexNum
    End Function


    Public Function HextoDec(HexNum As String) As Object
        Dim lngOut As Object = 0
        Dim varOutValue As Object = 0
        Dim i As Integer
        Dim c As Integer
        For i = 1 To Len(HexNum)
            c = Asc(UCase(Mid(HexNum, i, 1)))
            Select Case c
                Case 65 To 70
                    lngOut = lngOut + ((c - 55) * 16 ^ (Len(HexNum) - i))

                Case 48 To 57
                    lngOut = lngOut + ((c - 48) * 16 ^ (Len(HexNum) - i))

                Case Else
            End Select
        Next i
        HextoDec = lngOut
    End Function

    Public Function DecToBin(DeciValue As Long, Optional NoOfBits As Integer = 8) As String
        Dim i As Integer, strBin As String
        strBin = ""
        Do While DeciValue > (2 ^ NoOfBits) - 1
            NoOfBits = NoOfBits + 8
        Loop
        DecToBin = ""
        For i = 0 To (NoOfBits - 1)
            strBin = CStr((DeciValue And 2 ^ i) / 2 ^ i) & strBin
        Next
        DecToBin = strBin
    End Function

    Public Function StringByteSwap(str As String) As String
        'This to swap bytes in the string, so that the same data can be write or read from the PLC
        Dim text As New StringBuilder
        If (str.Length Mod 2) = 1 Then
            str += " "
        End If
        For i As Integer = 0 To str.Length - 1 Step 2
            If Math.Abs(str.Length - i) <> 1 Then
                text.Append(StrReverse(str.Substring(i, 2)))
            Else
                text.Append(str.Substring(i, 1))
            End If
        Next
        Return text.ToString
    End Function

    Public Function Fillzerobefore(str As String, len As Integer) As String

        Dim text As String = str
        While (text.Length < len)
            text = "0" + text
        End While
        Return text
    End Function



#End Region



#Region "IO Status Fetch"
    Public Function FetchPLC_DIn(start As Integer) As Boolean

        For i As Integer = 0 To DIn.Length - 1
            DIn(i) = Int2BoolArr(FINSinput(start + i))
        Next

        For i As Integer = 0 To 13
            FormMain.dgv_DigitalInput.Rows(i).Cells("value").Value = DIn(0)(i)
        Next

        For i As Integer = 14 To 29
            FormMain.dgv_DigitalInput.Rows(i).Cells("value").Value = DIn(1)(i - 14)
        Next


        Return True
    End Function

    Public Function FetchPLC_DOut(start As Integer) As Boolean

        For i As Integer = 0 To DOut.Length - 1
            DOut(i) = Int2BoolArr(FINSinput(start + i))
        Next
        For i As Integer = 0 To 9
            FormMain.dgv_DigitalOutput.Rows(i).Cells("value").Value = DOut(0)(i)
        Next

        For i As Integer = 10 To 25
            FormMain.dgv_DigitalOutput.Rows(i).Cells("value").Value = DOut(1)(i - 10)
        Next

        For i As Integer = 26 To 41
            FormMain.dgv_DigitalOutput.Rows(i).Cells("value").Value = DOut(2)(i - 26)
        Next

        Return True
    End Function

    Public Function FetchPLC_Ain(start As Integer) As Boolean

        'RealFromPLC(OmronPLC, PoohFinsETN.MemoryTypes.DM, 1)



        For i As Integer = 0 To AIn.Length - 1

            AIn(i) = Int2Float(FINSinput, start + (i * 2))
        Next
        For i As Integer = 0 To 15
            FormMain.dgv_AnalogInput.Rows(i).Cells("value").Value = AIn(i)
        Next
        Return True
    End Function

    Public Function FetchPLC_AOut(start As Integer) As Boolean

        For i As Integer = 0 To AOut.Length - 1
            AOut(i) = Int2Float(FINSinput, start + (i * 2))
        Next
        For i As Integer = 0 To 5
            FormMain.dgv_AnalogOutput.Rows(i).Cells("value").Value = AOut(i)
        Next
        Return True
    End Function





#End Region


#Region "Alarm and Warnings Fetch"
    Public Function FetchAlarm(start As Integer) As Boolean
        Dim serialno As Integer = 0
        Dim alarmdescription As New StringBuilder
        Dim alarmid As Integer
        Dim alarmcode As String

        For i As Integer = 0 To Alarm.Length - 1
            Alarm(i) = Int2BoolArr(FINSinput(start + i))
        Next
        'If CommLost = True Then
        '    Currentalarm.Add(1, "ALM-001 PLC-PC Communication Lost Alarm")
        'End If
        For i As Integer = 0 To Alarm.Length - 1
            For j As Integer = 0 To 15
                alarmdescription.Clear()
                If Alarm(i)(j) = True Then

                    alarmid = dtAlarm.Rows((i * 16) + j).Item("id")
                    alarmcode = dtAlarm.Rows((i * 16) + j).Item("code")
                    alarmdescription.Append(dtAlarm.Rows((i * 16) + j).Item("code"))
                    alarmdescription.Append(" ")
                    alarmdescription.Append(dtAlarm.Rows((i * 16) + j).Item("description"))

                    If Not Currentalarm.ContainsKey(alarmid) Then
                        Dim alarmmessage As DataRow = Mainalarm.NewRow()
                        Dim alarmhistory As New Dictionary(Of String, Object) From {
                {"trigger_time", FormMain.lbl_DateTimeClock.Text},
                {"alarm_code", alarmcode}
                }
                        SQL.InsertRecord("AlarmHistory", alarmhistory)
                        Currentalarm.Add(alarmid, alarmdescription.ToString)

                        alarmmessage.Item("id") = alarmid
                        alarmmessage.Item("S.No") = Mainalarm.Rows.Count + 1
                        alarmmessage.Item("Trigger Time") = FormMain.lbl_DateTimeClock.Text
                        alarmmessage.Item("Description") = dtAlarm.Rows((i * 16) + j).Item("description")
                        alarmmessage.Item("Alarm Code") = alarmcode
                        Mainalarm.Rows.Add(alarmmessage)

                        If FormSetting.lbl_StartTime.Text.Length > 6 And FormSetting.lbl_EndTime.Text.Length < 6 Then
                            FormSetting.dtbuyoffmessage.Rows.Add(FormSetting.dtbuyoffmessage.Rows.Count - 1, FormSetting.dtbuyoffmessage.Rows.Count, alarmcode, DateTime.Now, dtAlarm.Rows((i * 16) + j).Item("description"))
                        End If



                    End If
                Else
                    If Alarm(i)(j) = False And Currentalarm.ContainsKey(dtAlarm.Rows((i * 16) + j).Item("id")) Then
                        Alarmtimer.Enabled = False
                        Currentindex = 0
                        If Currentalarm.Remove(dtAlarm.Rows((i * 16) + j).Item("id")) Then
                            Dim rows As DataRow()
                            Dim findrow As Integer
                            Dim reset As New Dictionary(Of String, Object) From {
                {"reset_time", FormMain.lbl_DateTimeClock.Text}}
                            'Dim Condition As String = $"lot_id ='{LotID}' AND lot_attempt = '{LotAttempt}'"
                            rows = Mainalarm.Select($"id = '{dtAlarm.Rows((i * 16) + j).Item("id")}'")
                            SQL.UpdateRecord("AlarmHistory", reset, $"reset_time IS NULL AND alarm_code='{dtAlarm.Rows((i * 16) + j).Item("code")}'")
                            If rows.Length > 0 Then
                                For k As Integer = 0 To rows.Length - 1
                                    findrow = Mainalarm.Rows.IndexOf(rows(k))
                                    Mainalarm.Rows.RemoveAt(findrow)
                                Next
                            End If

                        End If

                        Alarmtimer.Enabled = True
                    End If
                End If
            Next
        Next
        startindex = Currentalarm.Count - 1

        Return True
    End Function


#End Region



#Region "Put PC Manual Control"

    Public Function Put_PCManualctrl() As Boolean

        For i As Integer = 0 To 5
            FINSOutput(3 + i) = Boolarr2int(ManualCtrl(i))
        Next
        For i As Integer = 0 To 2
            FINSOutput(i) = Boolarr2int(PCStatus(i))
        Next
        Return True
    End Function

#End Region



#Region "PLC Read and Write"
    Public Function FINSInputRead() As Boolean
        Try
            Dim readtext As New StringBuilder(1500)
            Dim pumpcontrolquery As New StringBuilder(10)
            Dim pumpcontrolresponse As New StringBuilder(20)
            ' FormMain.txtbx_PLCWrite.Text = Nothing
            FINSinput = OmronPLC.ReadMemoryWord(PoohFinsETN.MemoryTypes.DM, 500, 300, PoohFinsETN.DataTypes.UnSignBIN)
            For i = 0 To 299
                readtext.Append(Fillzerobefore(Conversion.Hex(FINSinput(i)), 4))
            Next
            FormMain.txtbx_PLCRead.Text = readtext.ToString
            For a As Integer = 0 To 2
                pumpcontrolquery.Append(Fillzerobefore(Conversion.Hex(FINSinput(180 + a)), 4))
            Next

            For b As Integer = 0 To 4
                pumpcontrolresponse.Append(Fillzerobefore(Conversion.Hex(FINSinput(183 + b)), 4))
            Next


            FormMain.txtbx_PumpcontrolQuery.Text = pumpcontrolquery.ToString
            FormMain.txtbx_PumpcontrolResponse.Text = pumpcontrolresponse.ToString
        Catch ex As Exception
            CommLost = True


        End Try

        Return True
    End Function

    Public Function FINSOutputRead() As Boolean
        Try
            'FormMain.txtbx_PLCWrite.Text = Nothing
            FINSOutput = OmronPLC.ReadMemoryWord(PoohFinsETN.MemoryTypes.DM, 0, 200, PoohFinsETN.DataTypes.UnSignBIN)
            CommLost = False
            PLCtimer.Enabled = True
            For i As Integer = 0 To 5
                ManualCtrl(i) = Int2BoolArr(FINSOutput(3 + i))
            Next
            For i As Integer = 0 To 2
                PCStatus(i) = Int2BoolArr(FINSOutput(i))
            Next

        Catch ex As Exception
            CommLost = True
        End Try

        Return True
    End Function


    Public Function FINSWrite(offset As Integer, size As Integer) As Boolean
        Try

            Dim writetext As New StringBuilder(1500)
            PLCtimer.Enabled = False
            'FormMain.txtbx_PLCRead.Text = Nothing
            For i As Integer = 0 To size - 1
                writetext.Append(Fillzerobefore(Conversion.Hex(FINSOutput(offset + i)), 4))
                'OmronPLC.WriteMemoryWord(PoohFinsETN.MemoryTypes.DM, offset + i, FINSOutput(offset + i), PoohFinsETN.DataTypes.UnSignBIN)
            Next
            FormMain.txtbx_PLCWrite.Text = writetext.ToString
            OmronPLC.WriteMemory(PoohFinsETN.MemoryTypes.DM, 0, writetext.ToString)
            CommLost = False
            FINSOutputRead()
            PLCtimer.Enabled = True
        Catch ex As Exception
            CommLost = True
        End Try

        Return True
    End Function


#End Region



    Private Sub PLCTimer_Ticks(sender As Object, e As EventArgs) Handles PLCtimer.Tick

#Region "Auto Mode restrictions"

        If PLCstatus(0)(3) = True Then

            FormMain.btn_RecipeManagement.Enabled = False
            FormMain.btn_RecipeManagement.BackColor = SystemColors.ControlDark
            If MainMenu_BtnCalibrate = True Then
                FormMain.btn_Calibration.Enabled = True
                FormMain.btn_Calibration.BackColor = Color.FromArgb(25, 130, 246)
            End If
            If FormMain.txtbx_WorkOrderNumber.Enabled = True Then
                FormMain.btn_WrkOrdScnDtConfirm.Enabled = True
            Else
                FormMain.btn_WrkOrdScnDtConfirm.Enabled = False
            End If

        Else
            If MainMenu_BtnRecipe = True Then
                FormMain.btn_RecipeManagement.Enabled = True
                FormMain.btn_RecipeManagement.BackColor = Color.FromArgb(25, 130, 246)
            End If
            FormMain.btn_Calibration.Enabled = False
            FormMain.btn_Calibration.BackColor = SystemColors.ControlDark
            FormMain.btn_WrkOrdScnDtConfirm.Enabled = False
            FormMain.btn_RecipeSelectionConfirm.Enabled = False
        End If

#End Region

#Region "Manual Control Page Enable"

        If PLCstatus(0)(2) = True Then
            FormMain.tabpg_ManualControlValve.Enabled = True
            FormMain.tabpg_ManualControlPump.Enabled = True
            FormMain.tabpg_ManualControlTank.Enabled = True
            FormMain.tabpg_ManualControlDrain.Enabled = True
            FormMain.tabpg_ManualControlMaintenance.Enabled = True
        Else
            FormMain.tabpg_ManualControlValve.Enabled = False
            FormMain.tabpg_ManualControlPump.Enabled = False
            FormMain.tabpg_ManualControlTank.Enabled = False
            FormMain.tabpg_ManualControlDrain.Enabled = False
            FormMain.tabpg_ManualControlMaintenance.Enabled = False
        End If

#End Region

#Region "PLC-PC Heartbeat handshake"

        'PLC -PC HeartBeat indication label backcolor control 
        If PLCstatus(0)(0) = True Then
            PCStatus(0)(0) = False
            FormMain.lbl_B0.BackColor = Color.LimeGreen
            FormMain.lbl_B1.BackColor = SystemColors.Control

        Else
            PCStatus(0)(0) = True
            FormMain.lbl_B0.BackColor = SystemColors.Control
            FormMain.lbl_B1.BackColor = Color.LimeGreen

        End If

#End Region

#Region "HandHeld Scanner"

        If ComPort1Connected = False Then
            PCStatus(0)(6) = True
        Else
            PCStatus(0)(6) = False
        End If

#End Region

        If CommLost = False Then
            FINSInputRead()
            FetchPLC_DIn(100)
            FetchPLC_DOut(110)
            FetchPLC_Ain(120)
            FetchPLC_AOut(160)
            FetchAlarm(200)

            'Spiltting the Input into Boolean Array for Processing



            For i As Integer = 0 To 2
                PLCstatus(i) = Int2BoolArr(FINSinput(i))
            Next

#Region "Pump and tank status update on all page in main form"
            'Manual Pump Control label based on controller feedback
            If DIn(1)(7) = True Then
                FormMain.lbl_MCPumpState.BackColor = Color.LimeGreen
                FormMain.lbl_PZonePumpState.BackColor = Color.LimeGreen
                FormMain.lbl_PumpState.BackColor = Color.LimeGreen
                FormMain.lbl_PumpState.ForeColor = SystemColors.Window
                FormMain.lbl_PumpState.Text = "ON"
            Else
                FormMain.lbl_MCPumpState.BackColor = SystemColors.Window
                FormMain.lbl_PZonePumpState.BackColor = SystemColors.Window
                FormMain.lbl_PumpState.BackColor = SystemColors.Window
                FormMain.lbl_PumpState.ForeColor = SystemColors.ControlText
                FormMain.lbl_PumpState.Text = "OFF"
            End If

            If DIn(1)(8) = True Then
                FormMain.lbl_MCPumpError.BackColor = SystemColors.Window
                FormMain.lbl_PZonePumpError.BackColor = SystemColors.Window
                FormMain.lbl_PumpError.BackColor = SystemColors.Window
                FormMain.lbl_PumpError.ForeColor = SystemColors.ControlText
                FormMain.lbl_PumpError.Text = "ON"
            Else
                FormMain.lbl_MCPumpError.BackColor = Color.Red
                FormMain.lbl_PZonePumpError.BackColor = Color.Red
                FormMain.lbl_PumpError.BackColor = Color.Red
                FormMain.lbl_PumpError.ForeColor = SystemColors.Window
                FormMain.lbl_PumpError.Text = "OFF"
            End If

            If DIn(1)(9) = True Then
                FormMain.lbl_MCPumpWarning.BackColor = SystemColors.Window
                FormMain.lbl_PZonePumpWarning.BackColor = SystemColors.Window
                FormMain.lbl_PumpWarning.BackColor = SystemColors.Window
                FormMain.lbl_PumpWarning.ForeColor = SystemColors.ControlText
                FormMain.lbl_PumpWarning.Text = "ON"
            Else
                FormMain.lbl_MCPumpWarning.BackColor = Color.Red
                FormMain.lbl_PZonePumpWarning.BackColor = Color.Red
                FormMain.lbl_PumpWarning.BackColor = Color.Red
                FormMain.lbl_PumpWarning.ForeColor = SystemColors.Window
                FormMain.lbl_PumpWarning.Text = "OFF"
            End If

            'Manual Tank Level Label Color Change based on sensor
            If DIn(1)(2) = True Then
                FormMain.lbl_TankOverflow.BackColor = Color.LimeGreen
                FormMain.lbl_PZoneTankOverflow.BackColor = Color.LimeGreen

            Else
                FormMain.lbl_TankOverflow.BackColor = SystemColors.Window
                FormMain.lbl_PZoneTankOverflow.BackColor = SystemColors.Window

            End If

            If DIn(1)(3) = True Then
                FormMain.lbl_TankNominal.BackColor = Color.LimeGreen
                FormMain.lbl_PZoneTankNominal.BackColor = Color.LimeGreen
            Else
                FormMain.lbl_TankNominal.BackColor = SystemColors.Window
                FormMain.lbl_PZoneTankNominal.BackColor = SystemColors.Window
            End If

            If DIn(1)(4) = True Then
                FormMain.lbl_TankPrecondition.BackColor = Color.LimeGreen
                FormMain.lbl_PZoneTankPrecondition.BackColor = Color.LimeGreen
            Else
                FormMain.lbl_TankPrecondition.BackColor = SystemColors.Window
                FormMain.lbl_PZoneTankPrecondition.BackColor = SystemColors.Window
            End If

            If DIn(1)(5) = True Then
                FormMain.lbl_TankPumpProtect.BackColor = Color.LimeGreen
                FormMain.lbl_PZoneTankPumpProtect.BackColor = Color.LimeGreen
            Else
                FormMain.lbl_TankPumpProtect.BackColor = SystemColors.Window
                FormMain.lbl_PZoneTankPumpProtect.BackColor = SystemColors.Window
            End If

            FormMain.txtbx_BackPressActual.Text = AIn(1).ToString

            FormMain.lbl_InletPress.Text = AIn(9).ToString
            FormMain.lbl_OutletPress.Text = AIn(10).ToString
            FormMain.lbl_Flowmtr.Text = AIn(12).ToString
            FormMain.lbl_Temp.Text = AIn(13).ToString
            FormMain.lbl_PumpSpeed.Text = AIn(2).ToString




#End Region



#Region "Manual Control-Valve Screen Button state update"
            'Manual valve Control Button Color change on Output on
            For i As Integer = 0 To 15

                If DOut(1)(i) = False Then
                    SetButtonState(FormMain.btn_ValveCtrlArr(i), False, "Close")
                Else
                    SetButtonState(FormMain.btn_ValveCtrlArr(i), True, "Open")
                End If
            Next

            For i As Integer = 0 To 2
                If DOut(2)(i) = False Then
                    SetButtonState(FormMain.btn_ValveCtrlArr(i + 16), False, "Close")
                Else
                    SetButtonState(FormMain.btn_ValveCtrlArr(i + 16), True, "Open")
                End If
            Next



#End Region
#Region "Manual Control- Pump Control page Button"
            'Manual Pump Control Button Color change on Output on

            If DOut(2)(3) = False Then
                SetButtonState(FormMain.btn_PumpReset, False, "OFF")
            Else
                SetButtonState(FormMain.btn_PumpReset, True, "ON")
            End If
            If DOut(2)(4) = False Then
                SetButtonState(FormMain.btn_PumpMode, False, "Speed")
            Else
                SetButtonState(FormMain.btn_PumpMode, True, "Process")
            End If

            If DOut(2)(5) = False Then
                SetButtonState(FormMain.btn_PumpEnable, False, "OFF")
            Else
                SetButtonState(FormMain.btn_PumpEnable, True, "ON")
            End If




#End Region
#Region "Manual Control- Tank Control page Button"

            'Manual Tank Valve Label Color Change based on output
            If DOut(1)(3) = True Then
                FormMain.lbl_TankValve4.BackColor = Color.LimeGreen
            Else
                FormMain.lbl_TankValve4.BackColor = SystemColors.Window
            End If
            If DOut(1)(4) = True Then
                FormMain.lbl_TankValve5.BackColor = Color.LimeGreen
            Else
                FormMain.lbl_TankValve5.BackColor = SystemColors.Window
            End If

            ' Current Value update in the Pump control label  field
            FormMain.lbl_ReqRPM.Text = Int2Float(FINSOutput, 120).ToString
            FormMain.lbl_ReqLPM.Text = Int2Float(FINSOutput, 122).ToString

            'Manual Tank Control Button Color change on Output on

            If DOut(1)(3) = False Then
                SetButtonState(FormMain.btn_TankFill, False, "OFF")
            Else
                SetButtonState(FormMain.btn_TankFill, True, "ON")
            End If

            If DOut(1)(4) = False Then
                SetButtonState(FormMain.btn_TankDrain, False, "OFF")
            Else
                SetButtonState(FormMain.btn_TankDrain, True, "ON")
            End If



#End Region
#Region "Manual Control - Manual Drain page Button"

            ' Current Value update in the Pressure regulator control label  field
            FormMain.lbl_BackPressCurrent.Text = Int2Float(FINSOutput, 124).ToString
            FormMain.lbl_N2PurgeCurrent.Text = Int2Float(FINSOutput, 126).ToString

            If PLCstatus(2)(12) = False Then
                SetButtonState(FormMain.btn_BackPressureOn, False, "OFF")
            Else
                SetButtonState(FormMain.btn_BackPressureOn, True, "ON")
            End If

            If PLCstatus(2)(13) = False Then
                SetButtonState(FormMain.btn_N2PressureOn, False, "OFF")
            Else
                SetButtonState(FormMain.btn_N2PressureOn, True, "ON")
            End If


            If PLCstatus(2)(0) = False And PLCstatus(2)(1) = False And PLCstatus(2)(2) = False Then
                FormMain.btn_MCN2Purge1.Enabled = True
                FormMain.btn_MCN2Purge2.Enabled = True
                FormMain.btn_MCN2Purge3.Enabled = True
                SetButtonState(FormMain.btn_MCN2Purge1, False, "OFF")
                SetButtonState(FormMain.btn_MCN2Purge2, False, "OFF")
                SetButtonState(FormMain.btn_MCN2Purge3, False, "OFF")
            ElseIf PLCstatus(2)(0) = True Then
                FormMain.btn_MCN2Purge2.Enabled = False
                FormMain.btn_MCN2Purge3.Enabled = False
                SetButtonState(FormMain.btn_MCN2Purge1, True, "ON")
            ElseIf PLCstatus(2)(1) = True Then
                FormMain.btn_MCN2Purge1.Enabled = False
                FormMain.btn_MCN2Purge3.Enabled = False
                SetButtonState(FormMain.btn_MCN2Purge2, True, "ON")
            ElseIf PLCstatus(2)(2) = True Then
                FormMain.btn_MCN2Purge1.Enabled = False
                FormMain.btn_MCN2Purge2.Enabled = False
                SetButtonState(FormMain.btn_MCN2Purge3, True, "ON")
            End If





#End Region


#Region "Manual Control - Maintenance page Button"
            'Maintenance Label Color Change based on PLC status
            If PLCstatus(2)(3) = False Then
                SetButtonState(FormMain.btn_InFiltrDrain, False, "OFF")
            Else
                SetButtonState(FormMain.btn_InFiltrDrain, True, "ON")
            End If

            If PLCstatus(2)(4) = False Then
                SetButtonState(FormMain.btn_InFiltrVent, False, "OFF")
            Else
                SetButtonState(FormMain.btn_InFiltrVent, True, "ON")
            End If

            If PLCstatus(2)(5) = False Then
                SetButtonState(FormMain.btn_PumpFiltrDrain, False, "OFF")
            Else
                SetButtonState(FormMain.btn_PumpFiltrDrain, True, "ON")
            End If

            If PLCstatus(2)(6) = False Then
                SetButtonState(FormMain.btn_PumpFiltrVent, False, "OFF")
            Else
                SetButtonState(FormMain.btn_PumpFiltrVent, True, "ON")
            End If

            If PLCstatus(2)(7) = False Then
                SetButtonState(FormMain.btn_EmptyTank, False, "OFF")
            Else
                SetButtonState(FormMain.btn_EmptyTank, True, "ON")
            End If

            If PLCstatus(2)(8) = False Then
                SetButtonState(FormMain.btn_InletConnect, False, "OFF")
            Else
                SetButtonState(FormMain.btn_InletConnect, True, "ON")
            End If

            If PLCstatus(2)(9) = False Then
                SetButtonState(FormMain.btn_OutletConnect, False, "OFF")
            Else
                SetButtonState(FormMain.btn_OutletConnect, True, "ON")
            End If

            If PLCstatus(2)(10) = False Then
                SetButtonState(FormMain.btn_VentConnect, False, "OFF")
            Else
                SetButtonState(FormMain.btn_VentConnect, True, "ON")
            End If

            If PLCstatus(2)(11) = False Then
                SetButtonState(FormMain.btn_DrainConnect, False, "OFF")
            Else
                SetButtonState(FormMain.btn_DrainConnect, True, "ON")
            End If

#End Region
            '#Region "Mimic Panel Circuit Model 1"

            '            FormCircuitModel2.txtbx_BackPressActual.Text = AIn(1).ToString
            '            FormCircuitModel2.txtbx_N2PurgeActual.Text = AIn(0).ToString
            '            FormCircuitModel2.lbl_InletPress.Text = AIn(9).ToString
            '            FormCircuitModel2.lbl_OutletPress.Text = AIn(10).ToString
            '            FormCircuitModel2.lbl_Flowmtr.Text = AIn(12).ToString
            '            FormCircuitModel2.lbl_Temp.Text = AIn(13).ToString

            '#End Region
#Region "Device status screen status update"
            'Device status screen status update


            If DIn(1)(11) = True Then
                FormMain.lbl_FlwAlarm.BackColor = Color.Red
                FormMain.lbl_FlwAlarm.ForeColor = SystemColors.Window
                FormMain.lbl_FlwAlarm.Text = "ON"
            Else
                FormMain.lbl_FlwAlarm.BackColor = SystemColors.Window
                FormMain.lbl_FlwAlarm.ForeColor = SystemColors.ControlText
                FormMain.lbl_FlwAlarm.Text = "OFF"
            End If
            If PLCstatus(0)(1) = True Then
                FormMain.lbl_AutoRunning.BackColor = Color.LimeGreen
                FormMain.lbl_AutoRunning.ForeColor = SystemColors.Window
                FormMain.lbl_AutoRunning.Text = "ON"
            Else
                FormMain.lbl_AutoRunning.BackColor = SystemColors.Window
                FormMain.lbl_AutoRunning.ForeColor = SystemColors.ControlText
                FormMain.lbl_AutoRunning.Text = "OFF"
            End If

            If PLCstatus(1)(11) = True Then
                FormMain.lbl_AutoSeqComplete.BackColor = Color.LimeGreen
                FormMain.lbl_AutoSeqComplete.ForeColor = SystemColors.Window
                FormMain.lbl_AutoSeqComplete.Text = "ON"
            Else
                FormMain.lbl_AutoSeqComplete.BackColor = SystemColors.Window
                FormMain.lbl_AutoSeqComplete.ForeColor = SystemColors.ControlText
                FormMain.lbl_AutoSeqComplete.Text = "OFF"
            End If
            If PLCstatus(0)(4) = True Then
                FormMain.lbl_Alarm.BackColor = Color.Red
                FormMain.lbl_Alarm.ForeColor = SystemColors.Window
                FormMain.lbl_Alarm.Text = "ON"
            Else
                FormMain.lbl_Alarm.BackColor = SystemColors.Window
                FormMain.lbl_Alarm.ForeColor = SystemColors.ControlText
                FormMain.lbl_Alarm.Text = "OFF"
            End If
            If DIn(0)(4) = True Then
                FormMain.lbl_SafetyConOK.BackColor = Color.LimeGreen
                FormMain.lbl_SafetyConOK.ForeColor = SystemColors.Window
                FormMain.lbl_SafetyConOK.Text = "ON"
            Else
                FormMain.lbl_SafetyConOK.BackColor = Color.Red
                FormMain.lbl_SafetyConOK.ForeColor = SystemColors.ControlText
                FormMain.lbl_SafetyConOK.Text = "OFF"
            End If

            If PLCstatus(1)(12) = True Then
                FormMain.lbl_RecipeSelectionOK.BackColor = Color.LimeGreen
                FormMain.lbl_RecipeSelectionOK.ForeColor = SystemColors.Window
                FormMain.lbl_RecipeSelectionOK.Text = "ON"
            Else
                FormMain.lbl_RecipeSelectionOK.BackColor = SystemColors.Window
                FormMain.lbl_RecipeSelectionOK.ForeColor = SystemColors.ControlText
                FormMain.lbl_RecipeSelectionOK.Text = "OFF"
            End If
            If PLCstatus(1)(13) = True Then
                FormMain.lbl_JigSelect_ok.BackColor = Color.LimeGreen
                FormMain.lbl_JigSelect_ok.ForeColor = SystemColors.Window
                FormMain.lbl_JigSelect_ok.Text = "ON"
            Else
                FormMain.lbl_JigSelect_ok.BackColor = SystemColors.Window
                FormMain.lbl_JigSelect_ok.ForeColor = SystemColors.ControlText
                FormMain.lbl_JigSelect_ok.Text = "OFF"
            End If



#End Region
#Region "Recipe Selection Confirmation"

            'Recipe Selection
            If FormMain.txtbx_TitleRecipeID.Text.Length > 3 Then
                FINSOutput(20) = 1
                FINSOutput(21) = CheckJigType(JigType)
            Else
                FINSOutput(20) = 0
                FINSOutput(21) = 0
            End If

#End Region
#Region "Calibration and verification"
            If PLCstatus(1)(2) = True Then
                SetButtonState(FormCalibration.btn_Calibrate, True, "Calibrate")
            Else
                SetButtonState(FormCalibration.btn_Calibrate, False, "Calibrate")
            End If
            If PLCstatus(1)(3) = True Then
                SetButtonState(FormCalibration.btn_Verify, True, "Verify")

            Else
                SetButtonState(FormCalibration.btn_Verify, False, "Verify")

            End If
            If FINSinput(21) = 0 And FormCalibration.dtCalibration.Rows.Count = 0 And FormCalibration.dtVerification.Rows.Count = 0 Then
                ' FormCalibration.btn_Verify.Enabled = True
                FormCalibration.btn_Calibrate.Enabled = True
            Else
                ' FormCalibration.btn_Verify.Enabled = False
                FormCalibration.btn_Calibrate.Enabled = False
            End If

            If FINSinput(21) = 0 And Not FormCalibration.txtbx_CalOffset.Text = Nothing Then
                FormCalibration.btn_Verify.Enabled = True
            Else
                FormCalibration.btn_Verify.Enabled = False
            End If



            If FINSinput(21) = 300 Or FINSinput(21) = 320 Or FINSinput(21) = 350 Or FINSinput(21) = 370 Or FINSinput(21) = 600 Or FINSinput(21) = 620 Or FINSinput(21) = 650 Or FINSinput(21) = 670 Or FINSinput(21) = 800 Or FINSinput(21) = 820 Or FINSinput(21) = 850 Or FINSinput(21) = 870 Or FINSinput(21) = 1000 Or FINSinput(21) = 1020 Or FINSinput(21) = 1050 Or FINSinput(21) = 1070 Or FINSinput(21) = 1160 Or FINSinput(21) = 1360 Or FINSinput(21) = 1560 Or FINSinput(21) = 1700 Or FINSinput(21) = 1730 Then
                CalrecordValue = True
            Else
                CalrecordValue = False
            End If

            If FINSinput(21) <> Cal_MessageNo Then
                Cal_MessageNo = FINSinput(21)
                CalibrationMessage(Cal_MessageNo)
                If FINSinput(21) = 20 Then
                    If MsgBox($"Kindly Check and Acknowledge, Whether the Blank Product has been Connected properly? ", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes Then
                        PCStatus(1)(7) = True
                    ElseIf MsgBox("Do you want to Abort sequence?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes Then
                        PCStatus(1)(8) = True
                    Else
                        Cal_MessageNo = 0
                    End If
                End If
            End If



            If PLCstatus(1)(2) = False And PLCstatus(1)(3) = False Then
                PCStatus(1)(7) = False

            End If

            'Auto Running is False, Reset PC Acknowledge of Calibration and Verification reset
            If PLCstatus(0)(1) = False Then
                PCStatus(1)(4) = False
                PCStatus(1)(5) = False
            End If


            If FormCalibration.btn_Calibrate.Enabled = True Or FormCalibration.btn_Verify.Enabled = True Then
                    PCStatus(1)(8) = False
                    PCStatus(1)(6) = False
                End If

                If PLCstatus(1)(2) = True Or PLCstatus(1)(3) = True Then
                    FormCalibration.btn_Home.Enabled = False
                Else
                    FormCalibration.btn_Home.Enabled = True
                End If

#End Region
#Region "Main Sequence"
                If FINSinput(20) >= 10 And PLCstatus(1)(10) = True Then
                    PCStatus(1)(10) = False
                    FormMain.btn_OprKeyInDtConfirm.Enabled = False
                    FormMain.txtbx_SerialNumber.Enabled = False
                End If
                If FINSinput(20) = 0 And FormMain.lbl_CalibrationStatus.Text = "Pass" Then
                    FormMain.btn_OprKeyInDtConfirm.Enabled = True
                    FormMain.txtbx_SerialNumber.Enabled = True
                End If


            If PLCstatus(0)(1) = False Then
                PCStatus(1)(11) = False
                PCStatus(1)(12) = False
                PCStatus(1)(13) = False
                PCStatus(1)(14) = False
            End If
            If FINSinput(20) <> Main_MessageNo Then
                    Main_MessageNo = FINSinput(20)
                    MainMessage(Main_MessageNo)
                End If

            If FINSinput(20) = 300 Or FINSinput(20) = 320 Or FINSinput(20) = 350 Or FINSinput(20) = 370 Or FINSinput(20) = 600 Or FINSinput(20) = 620 Or FINSinput(20) = 650 Or FINSinput(20) = 670 Or FINSinput(20) = 800 Or FINSinput(20) = 820 Or FINSinput(20) = 850 Or FINSinput(20) = 870 Or FINSinput(20) = 1000 Or FINSinput(20) = 1020 Or FINSinput(20) = 1050 Or FINSinput(20) = 1070 Or FINSinput(20) = 1160 Or FINSinput(20) = 1360 Or FINSinput(20) = 1560 Or FINSinput(20) = 1700 Then
                MainrecordValue = True
            Else
                MainrecordValue = False
                End If
                FormMain.lbl_PassProdQty.Text = FINSinput(40).ToString
                FormMain.lbl_FailProdQty.Text = FINSinput(42).ToString


#End Region
#Region "Tool Counter"
                FormSetting.lblArray = {
            FormSetting.lbl_Valve1, FormSetting.lbl_Valve2, FormSetting.lbl_Valve3, FormSetting.lbl_Valve4, FormSetting.lbl_Valve5, FormSetting.lbl_Valve6, FormSetting.lbl_Valve7, FormSetting.lbl_Valve8, FormSetting.lbl_Valve9, FormSetting.lbl_Valve10, FormSetting.lbl_Valve11,
            FormSetting.lbl_Valve12, FormSetting.lbl_Valve13, FormSetting.lbl_Valve14, FormSetting.lbl_Valve15, FormSetting.lbl_Valve16, FormSetting.lbl_Valve17, FormSetting.lbl_Valve18, FormSetting.lbl_Valve19', lbl_Valve20, lbl_Valve21
}
                For i As Integer = 0 To FormSetting.lblArray.Length - 1
                    FormSetting.lblArray(i).Text = FINSinput(50 + (i * 2)).ToString
                Next
                FINSOutput(10) = Boolarr2int(ToolCounterreset(0))
                FINSOutput(11) = Boolarr2int(ToolCounterreset(1))
                If FINSOutput(10) > 0 Then
                    For i As Integer = 0 To 15
                        If FINSinput(50 + i * 2) = 0 And ToolCounterreset(0)(i) = True Then
                            ToolCounterreset(0)(i) = False
                        End If
                    Next
                End If
                If FINSOutput(11) > 0 Then
                    For i As Integer = 0 To 15
                        If FINSinput(80 + i * 2) = 0 And ToolCounterreset(1)(i) = True Then
                            ToolCounterreset(1)(i) = False
                        End If
                    Next
                End If






#End Region
                Put_PCManualctrl()
                FINSWrite(0, 200)
                LabelStatusupdate()
            Else
                FormCalibration.tmr_Calibration.Enabled = False
            FormCalibration.tmr_Verification.Enabled = False
            Resultcapturetimer.Enabled = False
            LabelStatusupdate()
            Alarmtimer.Enabled = True

        End If


    End Sub


    Private Sub PCTimer_Ticks(sender As Object, e As EventArgs) Handles PCtimer.Tick
        For i As Integer = 0 To 15
            If ManualCtrl(2)(i) = True And FormMain.btn_ValveCtrlArr(i).Text = "Close" Then
                ManualCtrl(2)(i) = False
            End If
        Next
        For i As Integer = 0 To 2
            If ManualCtrl(3)(i) = True And FormMain.btn_ValveCtrlArr(i + 16).Text = "Close" Then
                ManualCtrl(3)(i) = False
            End If
        Next
        For i As Integer = 8 To 15
            If ManualCtrl(3)(i) = True And FormMain.btn_Manualothersarr(i - 3).Text = "OFF" Then
                ManualCtrl(3)(i) = False
            End If
        Next
        For i As Integer = 3 To 7
            If ManualCtrl(3)(i) = True And FormMain.btn_Manualothersarr(i - 3).Text = "OFF" Then
                ManualCtrl(3)(i) = False
            End If
        Next

        For i As Integer = 0 To 5
            If ManualCtrl(4)(i) = True And FormMain.btn_Manualothersarr(13 + i).Text = "OFF" Then
                ManualCtrl(4)(i) = False
            End If
        Next

        'PCtimer.Stop()
    End Sub



#Region "Top Label Status Update"
    Public Sub LabelStatusupdate()
        'To Update the Status of the Header Bar in all Forms
        If CommLost = False Then
            If PLCstatus(0)(4) = False And PLCstatus(0)(14) = False And CommLost = False Then
                If Alarmtimer.Enabled = True Then
                    Alarmtimer.Enabled = False
                    startindex = 0
                End If

                If PLCstatus(0)(1) = True Then
                    FormMain.lbl_OperationMode.Text = "Auto Cycle Running"
                    FormMain.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)
                    FormCalibration.lbl_OperationMode.Text = "Auto Cycle Running"
                    FormCalibration.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)
                    FormMessageLog.lbl_OperationMode.Text = "Auto Cycle Running"
                    FormMessageLog.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormRecipeManagement.lbl_OperationMode.Text = "Auto Cycle Running"
                    FormRecipeManagement.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormResultGraph.lbl_OperationMode.Text = "Auto Cycle Running"
                    FormResultGraph.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)
                    FormResultSummary.lbl_OperationMode.Text = "Auto Cycle Running"
                    FormResultSummary.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)
                    FormSetting.lbl_OperationMode.Text = "Auto Cycle Running"
                    FormSetting.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormMain.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormCalibration.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormMessageLog.lbl_OperationMode.ForeColor = SystemColors.Window
                    FormRecipeManagement.lbl_OperationMode.ForeColor = SystemColors.Window
                    FormResultGraph.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormResultSummary.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormSetting.lbl_OperationMode.ForeColor = SystemColors.Window
                End If
                If PLCstatus(0)(2) = True Then
                    FormMain.lbl_OperationMode.Text = "Manual Mode"
                    FormMain.lbl_OperationMode.BackColor = Color.FromArgb(25, 130, 246)

                    FormCalibration.lbl_OperationMode.Text = "Manual Mode"
                    FormCalibration.lbl_OperationMode.BackColor = Color.FromArgb(25, 130, 246)

                    FormMessageLog.lbl_OperationMode.Text = "Manual Mode"
                    FormMessageLog.lbl_OperationMode.BackColor = Color.FromArgb(25, 130, 246)

                    FormRecipeManagement.lbl_OperationMode.Text = "Manual Mode"
                    FormRecipeManagement.lbl_OperationMode.BackColor = Color.FromArgb(25, 130, 246)

                    FormResultGraph.lbl_OperationMode.Text = "Manual Mode"
                    FormResultGraph.lbl_OperationMode.BackColor = Color.FromArgb(25, 130, 246)

                    FormResultSummary.lbl_OperationMode.Text = "Manual Mode"
                    FormResultSummary.lbl_OperationMode.BackColor = Color.FromArgb(25, 130, 246)

                    FormSetting.lbl_OperationMode.Text = "Manual Mode"
                    FormSetting.lbl_OperationMode.BackColor = Color.FromArgb(25, 130, 246)

                    FormMain.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormCalibration.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormMessageLog.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormRecipeManagement.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormResultGraph.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormResultSummary.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormSetting.lbl_OperationMode.ForeColor = SystemColors.Window

                End If

                If PLCstatus(0)(1) = False And PLCstatus(0)(3) = True And PLCstatus(0)(2) = False Then
                    FormMain.lbl_OperationMode.Text = "Auto Mode"
                    FormMain.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormCalibration.lbl_OperationMode.Text = "Auto Mode"
                    FormCalibration.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormMessageLog.lbl_OperationMode.Text = "Auto Mode"
                    FormMessageLog.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormRecipeManagement.lbl_OperationMode.Text = "Auto Mode"
                    FormRecipeManagement.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormResultGraph.lbl_OperationMode.Text = "Auto Mode"
                    FormResultGraph.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormResultSummary.lbl_OperationMode.Text = "Auto Mode"
                    FormResultSummary.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormSetting.lbl_OperationMode.Text = "Auto Mode"
                    FormSetting.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)

                    FormMain.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormCalibration.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormMessageLog.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormRecipeManagement.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormResultGraph.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormResultSummary.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormSetting.lbl_OperationMode.ForeColor = SystemColors.Window

                End If

                If PLCstatus(0)(1) = False And PLCstatus(0)(2) = False And PLCstatus(0)(3) = False Then
                    FormMain.lbl_OperationMode.Text = "No Status"
                    FormMain.lbl_OperationMode.BackColor = Color.Gray

                    FormCalibration.lbl_OperationMode.Text = "No Status"
                    FormCalibration.lbl_OperationMode.BackColor = Color.Gray

                    FormMessageLog.lbl_OperationMode.Text = "No Status"
                    FormMessageLog.lbl_OperationMode.BackColor = Color.Gray

                    FormRecipeManagement.lbl_OperationMode.Text = "No Status"
                    FormRecipeManagement.lbl_OperationMode.BackColor = Color.Gray

                    FormResultGraph.lbl_OperationMode.Text = "No Status"
                    FormResultGraph.lbl_OperationMode.BackColor = Color.Gray

                    FormResultSummary.lbl_OperationMode.Text = "No Status"
                    FormResultSummary.lbl_OperationMode.BackColor = Color.Gray

                    FormSetting.lbl_OperationMode.Text = "No Status"
                    FormSetting.lbl_OperationMode.BackColor = Color.Gray

                    FormMain.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormCalibration.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormMessageLog.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormRecipeManagement.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormResultGraph.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormResultSummary.lbl_OperationMode.ForeColor = SystemColors.Window

                    FormSetting.lbl_OperationMode.ForeColor = SystemColors.Window
                End If
            Else
                If PLCstatus(0)(4) = True Or PLCstatus(0)(14) = True Then

                    If PLCstatus(0)(4) = True Then
                        Currentalarm.Remove(0)
                        If Not Currentalarm.ContainsKey(0) Then
                            Currentalarm.Add(0, "Machine in Alarm Condition")
                        End If

                    Else
                        Currentalarm.Remove(0)
                        Currentalarm.Add(0, "Machine in Warning Condition")
                    End If



                    If Alarmtimer.Enabled = False Then
                        Alarmtimer.Enabled = True
                    End If
                End If

            End If
        Else
            Currentalarm.Remove(0)
            If Not Currentalarm.ContainsKey(0) Then
                Currentalarm.Add(0, "Machine in Alarm Condition")
            End If
            Currentalarm.Remove(1)
            If Not Currentalarm.ContainsKey(1) Then
                Currentalarm.Add(1, "ALM-001 PLC-PC Communication Lost Alarm")
            End If
            If Alarmtimer.Enabled = False Then
                Alarmtimer.Enabled = True
                startindex = Currentalarm.Count - 1
            End If

        End If


    End Sub

    Private Sub AlarmTimer_Ticks(sender As Object, e As EventArgs) Handles Alarmtimer.Tick
        Dim Value As KeyValuePair(Of Integer, Object)
        Dim bgcolor As Color
        Dim frcolor As Color


        Value = Currentalarm.ElementAt(startindex - Currentindex)
        FormCalibration.tmr_Calibration.Enabled = False
        FormCalibration.tmr_Verification.Enabled = False
        Resultcapturetimer.Enabled = False
        If Value.Value.ToString.Substring(0, 3) = "ALM" Or Value.Value.ToString.Contains("Alarm") Then
            bgcolor = Color.Red
            frcolor = SystemColors.Window
        End If
        If Value.Value.ToString.Substring(0, 3) = "WAR" Or Value.Value.ToString.Contains("Warning") Then
            bgcolor = Color.Yellow
            frcolor = SystemColors.ControlText
        End If

        FormMain.lbl_OperationMode.Text = Value.Value.ToString
        FormMain.lbl_OperationMode.BackColor = bgcolor
        FormMain.lbl_OperationMode.ForeColor = frcolor

        FormCalibration.lbl_OperationMode.Text = Value.Value.ToString
        FormCalibration.lbl_OperationMode.BackColor = bgcolor
        FormCalibration.lbl_OperationMode.ForeColor = frcolor

        FormMessageLog.lbl_OperationMode.Text = Value.Value.ToString
        FormMessageLog.lbl_OperationMode.BackColor = bgcolor
        FormMessageLog.lbl_OperationMode.ForeColor = frcolor

        FormRecipeManagement.lbl_OperationMode.Text = Value.Value.ToString
        FormRecipeManagement.lbl_OperationMode.BackColor = bgcolor
        FormRecipeManagement.lbl_OperationMode.ForeColor = frcolor

        FormResultGraph.lbl_OperationMode.Text = Value.Value.ToString
        FormResultGraph.lbl_OperationMode.BackColor = bgcolor
        FormResultGraph.lbl_OperationMode.ForeColor = frcolor

        FormResultSummary.lbl_OperationMode.Text = Value.Value.ToString
        FormResultSummary.lbl_OperationMode.BackColor = bgcolor
        FormResultSummary.lbl_OperationMode.ForeColor = frcolor

        FormSetting.lbl_OperationMode.Text = Value.Value.ToString
        FormSetting.lbl_OperationMode.BackColor = bgcolor
        FormSetting.lbl_OperationMode.ForeColor = frcolor




        If Currentindex >= startindex Then
            Currentindex = 0
            If CommLost = True Then
                FINSOutputRead()
            End If
        Else
            Currentindex = Currentindex + 1
        End If


    End Sub


#End Region




#Region "Check Jig OK"
    Public Function CheckJigType(id As Integer) As Integer
        Select Case id
            Case 0
                If DIn(0)(7) = False And DIn(0)(8) = False And DIn(0)(9) = False Then
                    Return 1
                Else
                    Return 0
                End If
                Exit Select
            Case 1
                If DIn(0)(7) = False And DIn(0)(8) = False And DIn(0)(9) = True Then
                    Return 1
                Else
                    Return 0
                End If
                Exit Select
            Case 2
                If DIn(0)(7) = False And DIn(0)(8) = True And DIn(0)(9) = False Then
                    Return 1
                Else
                    Return 0
                End If
                Exit Select
            Case 3
                If DIn(0)(7) = False And DIn(0)(8) = True And DIn(0)(9) = True Then
                    Return 1
                Else
                    Return 0
                End If
                Exit Select
            Case 4
                If DIn(0)(7) = True And DIn(0)(8) = False And DIn(0)(9) = False Then
                    Return 1
                Else
                    Return 0
                End If
                Exit Select
            Case 5
                If DIn(0)(7) = True And DIn(0)(8) = False And DIn(0)(9) = True Then
                    Return 1
                Else
                    Return 0
                End If
                Exit Select
            Case 6
                If DIn(0)(7) = True And DIn(0)(8) = True And DIn(0)(9) = False Then
                    Return 1
                Else
                    Return 0
                End If
                Exit Select
            Case 7
                If DIn(0)(7) = True And DIn(0)(8) = True And DIn(0)(9) = True Then
                    Return 1
                Else
                    Return 0
                End If
                Exit Select
            Case Else
                Return 0


        End Select
    End Function

#End Region



#Region "Calibration sequence timer and Message"


    Public Sub CalibrationMessage(MsgNumber As Integer)
        Dim msg As DataRow() = dtCalibrationmsg.Select($"step_id ='{MsgNumber}'")
        Select Case msg(0).Item("code").ToString
            Case "W"
                FormCalibration.lbl_CalibrationMsg.BackColor = Color.Yellow
                FormCalibration.lbl_CalibrationMsg.ForeColor = SystemColors.ControlText
            Case "M"
                FormCalibration.lbl_CalibrationMsg.BackColor = Color.LimeGreen
                FormCalibration.lbl_CalibrationMsg.ForeColor = SystemColors.Window
            Case "A"
                FormCalibration.lbl_CalibrationMsg.BackColor = Color.Red
                FormCalibration.lbl_CalibrationMsg.ForeColor = SystemColors.Window
            Case Else
                Exit Select
        End Select

        FormCalibration.lbl_CalibrationMsg.Text = msg(0).Item("calibration_message").ToString

    End Sub

#End Region


#Region "Main Sequence - Result capture, calculate and Message"
    Private Sub ResultCapture_Ticks(sender As Object, e As EventArgs) Handles Resultcapturetimer.Tick
        Dim serialusageid As Integer

        If MainrecordValue = True And CommLost = False Then
            Dim newrw As DataRow = dtresult.NewRow

            serialusageid = dtserialrecord.Rows(0)("id")
            result_samplingtime += CType((Resultcapturetimer.Interval / 1000), Decimal)
            result_inletpressure = AIn(9)
            result_outletpressure = AIn(10)
            result_flowrate = AIn(12)
            result_temperature = AIn(13)
            result_dp = result_inletpressure - result_outletpressure
            newrw(0) = serialusageid
            newrw(1) = result_samplingtime
            newrw(2) = result_temperature
            newrw(3) = result_flowrate
            newrw(4) = result_inletpressure
            newrw(5) = result_outletpressure
            newrw(6) = result_dp
            dtresult.Rows.Add(newrw)
        Else
            PCStatus(1)(10) = False
        End If


        'FormMain.lbl_EstCycleTime.Text = MainCycletime.ToString
        FormMain.lbl_runcycletime.Text = result_samplingtime.ToString

        If result_samplingtime = MainCycletime Then
            PCStatus(1)(11) = True
            Calculatefinalresult()

            'Resultcapturetimer.Enabled = False
        End If
    End Sub



    Public Sub Calculatefinalresult()
        Resultcapturetimer.Enabled = False
        LiveGraph.LiveGraph.ChartPlottingTimer(False)
        Dim A As Double = 0.01257187
        Dim B As Double = -0.005806436
        Dim C As Double = 0.001130911
        Dim D As Double = -0.000005723952
        Dim T2 As Double
        Dim exp As Double
        If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
            For i = MainDptest1start To MainDptest1end - 1
                result_avginlet1 = result_avginlet1 + dtresult.Rows(i)("Inlet Pressure (kPa)")
                result_avgoutlet1 = result_avgoutlet1 + dtresult.Rows(i)("Outlet Pressure (kPa)")
                result_avgflowrate1 = result_avgflowrate1 + dtresult.Rows(i)("Flowrate (l/min)")
                result_avgtemperature1 = result_avgtemperature1 + dtresult.Rows(i)("Temperature (°C)")
            Next
            result_avginlet1 = result_avginlet1 / MainDptestpoints
            result_avgoutlet1 = result_avgoutlet1 / MainDptestpoints
            result_avgflowrate1 = result_avgflowrate1 / MainDptestpoints
            result_avgtemperature1 = result_avgtemperature1 / MainDptestpoints
            result_avgdp1 = result_avginlet1 - result_avgoutlet1

            For i = MainDptest2start To MainDptest2end - 1
                result_avginlet2 = result_avginlet2 + dtresult.Rows(i)("Inlet Pressure (kPa)")
                result_avgoutlet2 = result_avgoutlet2 + dtresult.Rows(i)("Outlet Pressure (kPa)")
                result_avgflowrate2 = result_avgflowrate2 + dtresult.Rows(i)("Flowrate (l/min)")
                result_avgtemperature2 = result_avgtemperature2 + dtresult.Rows(i)("Temperature (°C)")
            Next
            result_avginlet2 = result_avginlet2 / MainDptestpoints
            result_avgoutlet2 = result_avgoutlet2 / MainDptestpoints
            result_avgflowrate2 = result_avgflowrate2 / MainDptestpoints
            result_avgtemperature2 = result_avgtemperature2 / MainDptestpoints
            result_avgdp2 = result_avginlet2 - result_avgoutlet2


            result_finalinlet = ((result_avginlet1 + result_avginlet2) / 2)
            result_finaloutlet = ((result_avgoutlet1 + result_avgoutlet2) / 2)

            result_finalflowrate = ((result_avgflowrate1 + result_avgflowrate2) / 2)
            result_finaltemperature = (((result_avgtemperature1 + result_avgtemperature2) / 2) + 273.15)

            T2 = result_finaltemperature * result_finaltemperature
            exp = Math.Exp((1 + (B * result_finaltemperature)) / ((C * result_finaltemperature) + (D * T2)))
            Viscosity = A * exp
            result_finaldp = ((1.002 / Viscosity) * (result_finalinlet - result_finaloutlet)) - CType(FormMain.lbl_BlankDP.Text, Decimal)

        End If

        If dtrecipetable.Rows(0)("firstdp_circuit") = "Enable" And Not dtrecipetable.Rows(0)("seconddp_circuit") = "Enable" Then
            For i = MainDptest1start To MainDptest1end - 1
                result_avginlet1 = result_avginlet1 + dtresult.Rows(i)("Inlet Pressure (kPa)")
                result_avgoutlet1 = result_avgoutlet1 + dtresult.Rows(i)("Outlet Pressure (kPa)")
                result_avgflowrate1 = result_avgflowrate1 + dtresult.Rows(i)("Flowrate (l/min)")
                result_avgtemperature1 = result_avgtemperature1 + dtresult.Rows(i)("Temperature (°C)")
            Next

            result_avginlet1 = result_avginlet1 / MainDptestpoints
            result_avgoutlet1 = result_avgoutlet1 / MainDptestpoints
            result_avgdp1 = result_avginlet1 - result_avgoutlet1
            result_avgflowrate1 = result_avgflowrate1 / MainDptestpoints
            result_avgtemperature1 = result_avgtemperature1 / MainDptestpoints

            result_finalinlet = result_avginlet1
            result_finaloutlet = result_avgoutlet1

            result_finalflowrate = result_avgflowrate1
            result_finaltemperature = (result_avgtemperature1 + 273.15)

            T2 = result_finaltemperature * result_finaltemperature
            exp = Math.Exp((1 + (B * result_finaltemperature)) / ((C * result_finaltemperature) + (D * T2)))
            Viscosity = A * exp
            result_finaldp = (((1.002 / Viscosity) * (result_finalinlet - result_finaloutlet)) - CType(FormMain.lbl_BlankDP.Text, Decimal))

        End If
        FormMain.lbl_DiffPressAct.Text = CType(Math.Round(result_finaldp, 2), String)

        If result_finaldp >= dtrecipetable.Rows(0)("dp_lowerlimit") And result_finaldp <= dtrecipetable.Rows(0)("dp_upperlimit") Then
            FormMain.lbl_DPTestResult.Text = "PASS"
            FormMain.lbl_DPTestResult.BackColor = Color.LimeGreen
            FormMain.lbl_DPTestResult.ForeColor = SystemColors.Window
            PCStatus(1)(13) = True
            PCStatus(1)(14) = False
        Else
            FormMain.lbl_DPTestResult.Text = "FAIL"
            FormMain.lbl_DPTestResult.BackColor = Color.Red
            FormMain.lbl_DPTestResult.ForeColor = SystemColors.Window
            PCStatus(1)(14) = True
            PCStatus(1)(13) = False
        End If

        If dtresult.Rows.Count > 0 Then
            Try
                For i As Integer = 0 To dtresult.Rows.Count - 1
                    Dim resultparameter As New Dictionary(Of String, Object) From {
                        {"serial_usage_id", dtresult.Rows(i)("Serial Usage id")},
                        {"sampling_time", dtresult.Rows(i)("Sampling Time (s)")},
                        {"temperature", dtresult.Rows(i)("Temperature (°C)")},
                        {"flowrate", dtresult.Rows(i)("Flowrate (l/min)")},
                        {"inlet_pressure", dtresult.Rows(i)("Inlet Pressure (kPa)")},
                        {"outlet_pressure", dtresult.Rows(i)("Outlet Pressure (kPa)")},
                        {"calculated_dp_pressure", dtresult.Rows(i)("Differential Pressure (kPa)")}
                    }
                    SQL.InsertRecord("ProductResult", resultparameter)
                Next
            Catch ex As Exception

            End Try

        End If




        Dim Updateparameter As New Dictionary(Of String, Object) From {
                            {"temperature", Math.Round(result_finaltemperature, 1)},
                            {"flowrate", Math.Round(result_finalflowrate, 1)},
                            {"inlet_pressure", Math.Round(result_finalinlet, 1)},
                            {"outlet_pressure", Math.Round(result_finaloutlet, 1)},
                            {"viscosity", Math.Round(Viscosity, 3)},
                            {"diff_pressure", Math.Round(result_finaldp, 1)},
                            {"cycle_time", MainCycletime},
                            {"result", FormMain.lbl_DPTestResult.Text.ToLower}
                        }
        Dim Condition As String = $"id = '{dtserialrecord.Rows(0)("id")}'"
        Try
            If SQL.UpdateRecord("ProductionDetail", Updateparameter, Condition) = 1 Then
                 PCStatus(1)(12) = True
                'If MsgBox($" Test Sequence Completed ", MsgBoxStyle.OkOnly, "Calibration Result") = DialogResult.OK Then
                '    PCStatus(1)(12) = True
                'End If
            Else
                MsgBox($" Query to Save Production Detail was not Successful", MsgBoxStyle.OkOnly, "Error")
            End If
        Catch ex As Exception
            MsgBox($" Query to Save Production Detail was not Successful", MsgBoxStyle.OkOnly, "Error")
        End Try





    End Sub




    Public Sub MainMessage(MsgNumber As Integer)
        Dim msg As DataRow() = dtMainmsg.Select($"step_id ='{MsgNumber}'")
        Select Case msg(0).Item("code").ToString
            Case "W"
                FormMain.lbl_StepwiseMessage.BackColor = Color.Yellow
                FormMain.lbl_StepwiseMessage.ForeColor = SystemColors.ControlText
            Case "M"
                FormMain.lbl_StepwiseMessage.BackColor = Color.LimeGreen
                FormMain.lbl_StepwiseMessage.ForeColor = SystemColors.Window
            Case "A"
                FormMain.lbl_StepwiseMessage.BackColor = Color.Red
                FormMain.lbl_StepwiseMessage.ForeColor = SystemColors.Window
            Case Else
                Exit Select
        End Select

        FormMain.lbl_StepwiseMessage.Text = msg(0).Item("process_message").ToString

    End Sub


#End Region


    Public Sub CreateTable(str As String)

        If str = "Calibration" Then
            FormCalibration.dtCalibration.Columns.Add("Sampling Time (s)")
            FormCalibration.dtCalibration.Columns.Add("Temperature (°C)")
            FormCalibration.dtCalibration.Columns.Add("Flowrate (l/min)")
            FormCalibration.dtCalibration.Columns.Add("Inlet Pressure (kPa)")
            FormCalibration.dtCalibration.Columns.Add("Outlet Pressure (kPa)")
            FormCalibration.dtCalibration.Columns.Add("Differential Pressure (kPa)")
        End If

        If str = "Verification" Then
            FormCalibration.dtVerification.Columns.Add("Sampling Time (s)")
            FormCalibration.dtVerification.Columns.Add("Temperature (°C)")
            FormCalibration.dtVerification.Columns.Add("Flowrate (l/min)")
            FormCalibration.dtVerification.Columns.Add("Inlet Pressure (kPa)")
            FormCalibration.dtVerification.Columns.Add("Outlet Pressure (kPa)")
            FormCalibration.dtVerification.Columns.Add("Differential Pressure (kPa)")
        End If

        If str = "Production_Result" Then

            dtresult.Columns.Add("Serial Usage id")
            dtresult.Columns.Add("Sampling Time (s)")
            dtresult.Columns.Add("Temperature (°C)")
            dtresult.Columns.Add("Flowrate (l/min)")
            dtresult.Columns.Add("Inlet Pressure (kPa)")
            dtresult.Columns.Add("Outlet Pressure (kPa)")
            dtresult.Columns.Add("Differential Pressure (kPa)")
        End If
    End Sub



End Module


