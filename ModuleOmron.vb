Imports PoohPlcLink
Imports EEIP
Module ModuleOmron
    ' This Module consists of the some data conversions needed for reading and writing values to the PLC
    Public OmronPLC As New PoohFinsETN
    Public OmronEEIP As New EEIPClient
    Public DIn(9)() As Boolean 'Consists of DM600-DM609
    Public DOut(9)() As Boolean 'Consists of DM610-DM619
    Public AIn(19) As Decimal 'Consists of DM620-DM659
    Public AOut(9) As Decimal 'Consists of DM660-DM679
    Public Alarm(9)() As Boolean 'Consists of DM700-DM709
    Public Warning(9)() As Boolean 'Consists of DM710-DM719
    Public EXEIPFetchManualCtrl(212) As Byte ' Consists of DM3 to DM8
    Public EXEIPFetchPLCStatus(200) As Byte ' Consists of DM500 to DM599
    'Public EXEIPPut(498) As Byte
    Public ManualCtrl(5)() As Boolean ' Consists of DM3 to DM8


#Region "FINS protocol"
    Public Sub FINSInitialise()
        OmronPLC.PLC_IPAddress = "192.168.0.1"
        OmronPLC.PLC_NodeNo = "1"
        OmronPLC.PLC_NetNo = "0"
        OmronPLC.PLC_UDPPort = "9600"
        OmronPLC.PC_NodeNo = "2"
        OmronPLC.PC_NetNo = "0"
        OmronPLC.TimeOutMSec = "1000"
    End Sub


    Public Function RealFromPLC(PLC As PoohFinsETN, Mem As PoohFinsETN.MemoryTypes, Startoffset As Integer) As String
        'This Function convert Hex string given by PLC on reading its Memory into Boolean string, so that it can be used to find the Float/decimal value
        Dim hexchar As String
        Dim firstpart As String
        Dim secondpart As String
        Dim modhex As String
        Dim boolstring As New Text.StringBuilder
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
        Dim fractionpart As New Text.StringBuilder
        Dim fractionfinal As String = ""
        Dim Binarypart As New Text.StringBuilder
        Dim hexpart As New Text.StringBuilder
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
        Dim text As New Text.StringBuilder
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


#End Region

    '
    '
    '
    '
    '
    '
    '
    '
#Region "EEIP Module Data Conversion-Implicit Messaging"
    'For EEIP Module Data

    Public Sub IMEIPInitialise()
        Try
            OmronEEIP.RegisterSession("192.168.0.1", 44818)

            OmronEEIP.O_T_InstanceID = &H64             ' //Instance ID Of the Output Assembly
            OmronEEIP.O_T_Length = 212              '// The Method "Detect_O_T_Length" detect the Length Using an UCMM Message
            OmronEEIP.O_T_RealTimeFormat = EEIP.RealTimeFormat.Header32Bit  '//Header Format
            OmronEEIP.O_T_OwnerRedundant = False
            OmronEEIP.O_T_Priority = EEIP.Priority.Scheduled
            OmronEEIP.O_T_VariableLength = False
            OmronEEIP.O_T_ConnectionType = EEIP.ConnectionType.Point_to_Point
            OmronEEIP.RequestedPacketRate_O_T = 10000        '//The data will update at frequency of 10ms, if we increase this time, then there will be delay in the data updation

            '//Parameters from Target -> Originator
            OmronEEIP.T_O_InstanceID = &H65
            OmronEEIP.T_O_Length = 200
            OmronEEIP.T_O_RealTimeFormat = EEIP.RealTimeFormat.Modeless
            OmronEEIP.T_O_OwnerRedundant = False
            OmronEEIP.T_O_Priority = EEIP.Priority.Scheduled
            OmronEEIP.T_O_VariableLength = False
            OmronEEIP.T_O_ConnectionType = EEIP.ConnectionType.Multicast
            OmronEEIP.RequestedPacketRate_T_O = 10000    '//RPI In  500ms Is the Standard value

            '//Forward open initiates the Implicit Messaging
            OmronEEIP.ForwardOpen(True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub IMEIPClose()
        Try
            OmronEEIP.ForwardClose()
            OmronEEIP.UnRegisterSession()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub IMEIPreconnect()
        Try
            OmronEEIP.ForwardClose()
            OmronEEIP.UnRegisterSession()
            IMEIPInitialise()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Public Function IMEIPReadBoolean(offset As Integer, bit As Integer) As Boolean

        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Value(1) As Byte
        Dim result(15) As Boolean
        Value(0) = OmronEEIP.T_O_IOData(offset * 2)
        Value(1) = OmronEEIP.T_O_IOData((offset * 2) + 1)
        For i As Integer = 0 To 7
            result(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
            result(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
        Next
        Return result(bit)
    End Function

    Public Function IMEIPReadBooleanArr(Offset As Integer) As Boolean()
        '16 BIT WORD TO BOOLEAN(16)
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Value(1) As Byte
        Dim result(15) As Boolean
        Dim Binary As New Text.StringBuilder
        Value(0) = OmronEEIP.T_O_IOData(Offset * 2)
        Value(1) = OmronEEIP.T_O_IOData((Offset * 2) + 1)

        For i As Integer = 0 To 7
            result(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
            result(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
        Next
        Return result
    End Function

    Public Function IMEIPWriteBoolean(Offset As Integer, bit As Integer, state As Boolean) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Value(1) As Byte
        Dim result As UInt16
        Dim newVal As Byte()
        Dim resultarr(15) As Boolean

        Value(0) = OmronEEIP.O_T_IOData(Offset * 2)
        Value(1) = OmronEEIP.O_T_IOData((Offset * 2) + 1)

        For i As Integer = 0 To 7
            resultarr(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
            resultarr(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
        Next


        result = BitConverter.ToUInt16(Value, 0)

        If Not resultarr(bit) = state Then
            If state = True Then
                result = result + (2 ^ bit)
            Else
                If result >= (2 ^ bit) Then
                    result = result - (2 ^ bit)
                End If
            End If
        End If

        newVal = BitConverter.GetBytes(result)

        OmronEEIP.O_T_IOData(Offset * 2) = newVal(0)
        OmronEEIP.O_T_IOData((Offset * 2) + 1) = newVal(1)

        Return True
    End Function



    Public Function IMEIPReadString(offset As Integer, length As Integer) As String
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim text As New Text.StringBuilder
        Dim value(length - 1) As Byte
        For i As Integer = 0 To length - 1
            value(i) = OmronEEIP.T_O_IOData((offset * 2) + i)
            text.Append(Convert.ToChar(value(i)))
        Next
        Return text.ToString
    End Function


    Public Function IMEIPWriteString(offset As Integer, str As String, length As Integer) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim value(length - 1) As Byte
        For i As Integer = 0 To str.Length - 1
            value(i) = Convert.ToByte(str.Chars(i))
        Next
        For j As Integer = 0 To length - 1
            OmronEEIP.O_T_IOData((offset * 2) + j) = value(j)
        Next
        Return True
    End Function


    Public Function IMEIPWriteFloat(offset As Integer, real As Double) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim sign_value As Integer
        Dim fraction As Decimal
        Dim Absreal As Double = Math.Abs(real)
        Dim j As Integer = 0
        Dim exponent As Integer = 0
        Dim fractionpart As New Text.StringBuilder
        Dim fractionfinal As String = ""
        Dim Binarypart As New Text.StringBuilder
        Dim hexpart As New Text.StringBuilder
        Dim hexstr As String
        Dim val(3) As Byte

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
        hexpart.Insert(0, hexpart.ToString.Substring(4, 4))
        hexstr = hexpart.ToString.Remove(8, 4)

        For k As Integer = 0 To 3
            val(k) = HextoDec(hexstr.Substring(k * 2, 2))
        Next
        For l As Integer = 0 To 3
            If l Mod 2 = 0 Then
                OmronEEIP.O_T_IOData((offset * 2) + l) = val(l + 1)
            Else
                OmronEEIP.O_T_IOData((offset * 2) + l) = val(l - 1)
            End If
        Next
        Return True
    End Function

    Public Function IMEIPReadFloat(offset As Integer) As Decimal
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim hexchar As New Text.StringBuilder
        Dim firstpart As String
        Dim secondpart As String
        Dim modhex As String
        Dim boolstring As New Text.StringBuilder
        Dim hextoint(7) As Integer
        Dim Value(3) As Byte

        For i As Integer = 0 To 3
            If i Mod 2 = 0 Then
                Value(i) = OmronEEIP.T_O_IOData((offset * 2) + i + 1)
            Else
                Value(i) = OmronEEIP.T_O_IOData((offset * 2) + i - 1)
            End If
            hexchar.Append(Value(i).ToString("X2"))
        Next

        'The String has to be 2 words, we need to swap the words before processing
        firstpart = hexchar.ToString.Substring(0, 4)
        secondpart = hexchar.ToString.Substring(4, 4)
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

    Public Function IMEIPWriteInt(offset As Integer, Value As Integer) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Val As Byte() = BitConverter.GetBytes(Value)

        OmronEEIP.O_T_IOData(offset * 2) = Val(0)
        OmronEEIP.O_T_IOData((offset * 2) + 1) = Val(1)
        Return True
    End Function

    Public Function IMEIPReadInt(offset As Integer) As Integer
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Val(1) As Byte
        Val(0) = OmronEEIP.T_O_IOData(offset * 2)
        Val(1) = OmronEEIP.T_O_IOData((offset * 2) + 1)

        Return BitConverter.ToInt16(Val, 0)

    End Function



    Public Function IMEIPWriteDInt(offset As Integer, Value As Int32) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Val As Byte() = BitConverter.GetBytes(Value)

        For i As Integer = 0 To 3
            OmronEEIP.O_T_IOData((offset * 2) + i) = Val(i)
        Next
        Return True
    End Function

    Public Function IMEIPReadDInt(offset As Integer) As Int32
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Val(3) As Byte

        For i As Integer = 0 To 3
            Val(i) = OmronEEIP.T_O_IOData((offset * 2) + i)
        Next
        Return BitConverter.ToInt32(Val, 0)
    End Function






#End Region


#Region "EEIP Module Data Conversion-Explicit Messaging"
    'For EEIP Module Data

    Public Sub EXEIPInitialise()
        Try
            OmronEEIP.RegisterSession("192.168.0.1", 44818)
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try

    End Sub

    Public Sub EXEIPClose()
        Try

            OmronEEIP.UnRegisterSession()
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub EXEIPreconnect()
        Try

            OmronEEIP.UnRegisterSession()
            EXEIPInitialise()

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try
    End Sub



    Public Function EXEIPReadBoolean(bytearr As Byte(), offset As Integer, bit As Integer) As Boolean

        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Value(1) As Byte
        Dim result(15) As Boolean
        Value(0) = bytearr(offset * 2)
        Value(1) = bytearr((offset * 2) + 1)
        For i As Integer = 0 To 7
            result(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
            result(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
        Next
        Return result(bit)
    End Function

    Public Function EXEIPReadBooleanArr(bytearr() As Byte, Offset As Integer) As Boolean()
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Value(1) As Byte
        Dim result(15) As Boolean
        Value(0) = bytearr(Offset * 2)
        Value(1) = bytearr((Offset * 2) + 1)
        For i As Integer = 0 To 7
            result(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
            result(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
        Next
        Return result
    End Function

    Public Function EXEIPWriteBoolean(bytearr As Byte(), Offset As Integer, bit As Integer, state As Boolean) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Value(1) As Byte
        Dim result As Integer
        Dim newVal As Byte()
        Dim resultarr(15) As Boolean

        Value(0) = bytearr(Offset * 2)
        Value(1) = bytearr((Offset * 2) + 1)
        For i As Integer = 0 To 7
            resultarr(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
            resultarr(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
        Next


        result = BitConverter.ToUInt16(Value, 0)

        If Not resultarr(bit) = state Then
            If state = True Then
                result = result + (2 ^ bit)
            Else
                If result >= (2 ^ bit) Then
                    result = result - (2 ^ bit)
                End If
            End If
        End If

        newVal = BitConverter.GetBytes(result)

        bytearr(Offset * 2) = newVal(0)
        bytearr((Offset * 2) + 1) = newVal(1)

        Return True
    End Function



    Public Function EXEIPReadString(bytearr As Byte(), offset As Integer, length As Integer) As String
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim text As New Text.StringBuilder
        Dim value(length - 1) As Byte
        For i As Integer = 0 To length - 1
            value(i) = bytearr((offset * 2) + i)
            text.Append(Convert.ToChar(value(i)))
        Next
        Return text.ToString
    End Function


    Public Function EXEIPWriteString(bytearr As Byte(), offset As Integer, str As String, length As Integer) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES

        Dim value(length - 1) As Byte
        For i As Integer = 0 To str.Length - 1
            value(i) = Convert.ToByte(str.Chars(i))
        Next
        For j As Integer = 0 To length - 1
            bytearr((offset * 2) + j) = value(j)
        Next
        Return True
    End Function


    Public Function EXEIPWriteFloat(bytearr As Byte(), offset As Integer, real As Double) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim sign_value As Integer
        Dim fraction As Decimal
        Dim Absreal As Double = Math.Abs(real)
        Dim j As Integer = 0
        Dim exponent As Integer = 0
        Dim fractionpart As New Text.StringBuilder
        Dim fractionfinal As String = ""
        Dim Binarypart As New Text.StringBuilder
        Dim hexpart As New Text.StringBuilder
        Dim hexstr As String
        Dim val(3) As Byte

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
        hexpart.Insert(0, hexpart.ToString.Substring(4, 4))
        hexstr = hexpart.ToString.Remove(8, 4)

        For k As Integer = 0 To 3
            val(k) = HextoDec(hexstr.Substring(k * 2, 2))
        Next
        For l As Integer = 0 To 3
            If l Mod 2 = 0 Then
                bytearr((offset * 2) + l) = val(l + 1)
            Else
                bytearr((offset * 2) + l) = val(l - 1)
            End If
        Next
        Return True
    End Function

    Public Function EXEIPReadFloat(bytearr As Byte(), offset As Integer) As Decimal
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim hexchar As New Text.StringBuilder
        Dim firstpart As String
        Dim secondpart As String
        Dim modhex As String
        Dim boolstring As New Text.StringBuilder
        Dim hextoint(7) As Integer
        Dim Value(3) As Byte

        For i As Integer = 0 To 3
            If i Mod 2 = 0 Then
                Value(i) = bytearr((offset * 2) + i + 1)
            Else
                Value(i) = bytearr((offset * 2) + i - 1)
            End If
            hexchar.Append(Value(i).ToString("X2"))
        Next

        'The String has to be 2 words, we need to swap the words before processing
        firstpart = hexchar.ToString.Substring(0, 4)
        secondpart = hexchar.ToString.Substring(4, 4)
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

    Public Function EXEIPWriteInt(bytearr As Byte(), offset As Integer, Value As Integer) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Val As Byte() = BitConverter.GetBytes(Value)

        bytearr(offset * 2) = Val(0)
        bytearr((offset * 2) + 1) = Val(1)
        Return True
    End Function

    Public Function EXEIPReadInt(bytearr As Byte(), offset As Integer) As Integer
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Val(1) As Byte
        Val(0) = bytearr(offset * 2)
        Val(1) = bytearr((offset * 2) + 1)

        Return BitConverter.ToInt16(Val, 0)

    End Function


    Public Function EXEIPWriteDInt(bytearr As Byte(), offset As Integer, Value As Int32) As Boolean
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Val As Byte() = BitConverter.GetBytes(Value)

        For i As Integer = 0 To 3
            bytearr((offset * 2) + i) = Val(i)
        Next
        Return True
    End Function

    Public Function EXEIPReadDInt(bytearr As Byte(), offset As Integer) As Int32
        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
        Dim Val(3) As Byte

        For i As Integer = 0 To 3
            Val(i) = bytearr((offset * 2) + i)
        Next
        Return BitConverter.ToInt32(Val, 0)
    End Function






#End Region




#Region "IO Status Fetch"
    Public Function FetchPLC_DIn(start As Integer) As Boolean

        For i As Integer = 0 To DIn.Length - 1
            DIn(i) = IMEIPReadBooleanArr(start + i)
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
            DOut(i) = IMEIPReadBooleanArr(start + i)
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

        For i As Integer = 0 To AIn.Length - 1
            AIn(i) = IMEIPReadFloat(start + (i * 2))
        Next
        For i As Integer = 0 To 15
            FormMain.dgv_AnalogInput.Rows(i).Cells("value").Value = AIn(i)
        Next
        Return True
    End Function

    Public Function FetchPLC_AOut(start As Integer) As Boolean

        For i As Integer = 0 To AOut.Length - 1
            AOut(i) = IMEIPReadFloat(start + (i * 2))
        Next
        For i As Integer = 0 To 5
            FormMain.dgv_AnalogOutput.Rows(i).Cells("value").Value = AOut(i)
        Next
        Return True
    End Function





#End Region


#Region "Alarm and Warnings Fetch"
    Public Function FetchAlarm(start As Integer) As Boolean

        For i As Integer = 0 To Alarm.Length - 1
            Alarm(i) = IMEIPReadBooleanArr(start + i)
        Next

        Return True
    End Function

    Public Function FetchWarning(start As Integer) As Boolean

        For i As Integer = 0 To Warning.Length - 1
            Warning(i) = IMEIPReadBooleanArr(start + i)
        Next

        Return True
    End Function
#End Region



#Region "Get & Put PC Manual Control"


    Public Function Get_PCManualctrl(offset As Integer) As Boolean

        For i As Integer = 0 To 5
            For j As Integer = 0 To 15
                ManualCtrl(i) = EXEIPReadBooleanArr(EXEIPFetchManualCtrl, offset + i)
            Next
        Next
        Return True
    End Function




    Public Function Put_PCManualctrl(offset As Integer) As Boolean

        For i As Integer = 0 To 5
            For j As Integer = 0 To 15
                IMEIPWriteBoolean(offset + i, j, ManualCtrl(i)(j))
            Next
        Next
        Return True
    End Function

#End Region
End Module


