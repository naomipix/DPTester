Imports PoohPlcLink
Imports EEIP
Imports System.Text
Imports System.ComponentModel
Imports System.Runtime.InteropServices.ComTypes
Imports System.Diagnostics.Eventing.Reader

Module ModuleOmron
    ' This Module consists of the some data conversions needed for reading and writing values to the PLC
    Public OmronPLC As New PoohFinsETN
    'Public OmronEEIP As New EEIPClient
    Public DIn(9)() As Boolean 'Consists of DM600-DM609
    Public DOut(9)() As Boolean 'Consists of DM610-DM619
    Public AIn(19) As Decimal 'Consists of DM620-DM659
    Public AOut(9) As Decimal 'Consists of DM660-DM679
    Public Alarm(9)() As Boolean 'Consists of DM700-DM709
    Public Warning(9)() As Boolean 'Consists of DM710-DM719
    'Public EXEIPFetchManualCtrl(212) As Byte ' Consists of DM3 to DM8
    'Public EXEIPFetchPLCStatus(200) As Byte ' Consists of DM500 to DM599
    'Public EXEIPPut(498) As Byte
    Public ManualCtrl(5)() As Boolean ' Consists of DM3 to DM8
    Public FINSinput() As Integer
    Public FINSOutput(199) As Integer
    Public WithEvents PLCtimer As New Timer()
    Public WithEvents PCtimer As New Timer()
    Dim PLCstatus(2)() As Boolean
    Public PCStatus(2)() As Boolean
    Public dtAlarm As New DataTable
    Public Currentalarm As New Dictionary(Of Integer, Object)


#Region "FINS protocol"
    Public Sub FINSInitialise()
        Try
            OmronPLC.PLC_IPAddress = "192.168.0.1"
            OmronPLC.PLC_NodeNo = "1"
            OmronPLC.PLC_NetNo = "0"
            OmronPLC.PLC_UDPPort = "9600"
            OmronPLC.PC_NodeNo = "2"
            OmronPLC.PC_NetNo = "0"
            OmronPLC.TimeOutMSec = "1000"

            FINSOutput = OmronPLC.ReadMemoryWord(PoohFinsETN.MemoryTypes.DM, 0, 200, PoohFinsETN.DataTypes.UnSignBIN)
            For i As Integer = 0 To 5
                ManualCtrl(i) = Int2BoolArr(FINSOutput(3 + i))
            Next
            For i As Integer = 0 To 2
                PCStatus(i) = Int2BoolArr(FINSOutput(i))
            Next
            PLCtimer.Interval = 200
            PLCtimer.Enabled = True
            PCtimer.Interval = 1000
            dtAlarm = SQL.ReadRecords("select id,code,description from AlarmTable")



        Catch ex As Exception
            MsgBox("Cannot able to communicate with PLC, Connection failed")
        End Try
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
        Dim fractionpart As New Text.StringBuilder
        Dim fractionfinal As String = ""
        Dim Binarypart As New Text.StringBuilder
        Dim hexpart As New Text.StringBuilder
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
        Dim hexchar As New Text.StringBuilder
        Dim modhex As String
        Dim boolstring As New Text.StringBuilder
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

    '    Public Function IMEIPReadDInt(offset As Integer) As Int32
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Val(3) As Byte

    '        For i As Integer = 0 To 3
    '            Val(i) = OmronEEIP.T_O_IOData((offset * 2) + i)
    '        Next
    '        Return BitConverter.ToInt32(Val, 0)
    '    End Function


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

    Public Function Fillzerobefore(str As String, len As Integer) As String
        'String Text = strInput;
        '    While (Text.Length < len)
        '    {
        '        Text = "0" + Text;
        '    }

        '    Return Text;

        Dim text As String = str
        While (text.Length < len)
            text = "0" + text
        End While
        Return text
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
    '    'For EEIP Module Data

    '    Public Sub IMEIPInitialise()
    '        Try
    '            OmronEEIP.RegisterSession("192.168.0.1", 44818)

    '            OmronEEIP.O_T_InstanceID = &H64             ' //Instance ID Of the Output Assembly
    '            OmronEEIP.O_T_Length = 212              '// The Method "Detect_O_T_Length" detect the Length Using an UCMM Message
    '            OmronEEIP.O_T_RealTimeFormat = EEIP.RealTimeFormat.Header32Bit  '//Header Format
    '            OmronEEIP.O_T_OwnerRedundant = False
    '            OmronEEIP.O_T_Priority = EEIP.Priority.Scheduled
    '            OmronEEIP.O_T_VariableLength = False
    '            OmronEEIP.O_T_ConnectionType = EEIP.ConnectionType.Point_to_Point
    '            OmronEEIP.RequestedPacketRate_O_T = 10000        '//The data will update at frequency of 10ms, if we increase this time, then there will be delay in the data updation

    '            '//Parameters from Target -> Originator
    '            OmronEEIP.T_O_InstanceID = &H65
    '            OmronEEIP.T_O_Length = 200
    '            OmronEEIP.T_O_RealTimeFormat = EEIP.RealTimeFormat.Modeless
    '            OmronEEIP.T_O_OwnerRedundant = False
    '            OmronEEIP.T_O_Priority = EEIP.Priority.Scheduled
    '            OmronEEIP.T_O_VariableLength = False
    '            OmronEEIP.T_O_ConnectionType = EEIP.ConnectionType.Multicast
    '            OmronEEIP.RequestedPacketRate_T_O = 10000    '//RPI In  500ms Is the Standard value

    '            '//Forward open initiates the Implicit Messaging
    '            OmronEEIP.ForwardOpen(True)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    End Sub

    '    Public Sub IMEIPClose()
    '        Try
    '            OmronEEIP.ForwardClose()
    '            OmronEEIP.UnRegisterSession()
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Public Sub IMEIPreconnect()
    '        Try
    '            OmronEEIP.ForwardClose()
    '            OmronEEIP.UnRegisterSession()
    '            IMEIPInitialise()

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub



    '    Public Function IMEIPReadBoolean(offset As Integer, bit As Integer) As Boolean

    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Value(1) As Byte
    '        Dim result(15) As Boolean
    '        Value(0) = OmronEEIP.T_O_IOData(offset * 2)
    '        Value(1) = OmronEEIP.T_O_IOData((offset * 2) + 1)
    '        For i As Integer = 0 To 7
    '            result(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
    '            result(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
    '        Next
    '        Return result(bit)
    '    End Function

    '    Public Function IMEIPReadBooleanArr(Offset As Integer) As Boolean()
    '        '16 BIT WORD TO BOOLEAN(16)
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Value(1) As Byte
    '        Dim result(15) As Boolean
    '        Dim Binary As New Text.StringBuilder
    '        Value(0) = OmronEEIP.T_O_IOData(Offset * 2)
    '        Value(1) = OmronEEIP.T_O_IOData((Offset * 2) + 1)

    '        For i As Integer = 0 To 7
    '            result(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
    '            result(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
    '        Next
    '        Return result
    '    End Function

    '    Public Function IMEIPWriteBoolean(Offset As Integer, bit As Integer, state As Boolean) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Value(1) As Byte
    '        Dim result As UInt16
    '        Dim newVal As Byte()
    '        Dim resultarr(15) As Boolean

    '        Value(0) = OmronEEIP.O_T_IOData(Offset * 2)
    '        Value(1) = OmronEEIP.O_T_IOData((Offset * 2) + 1)

    '        For i As Integer = 0 To 7
    '            resultarr(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
    '            resultarr(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
    '        Next


    '        result = BitConverter.ToUInt16(Value, 0)

    '        If Not resultarr(bit) = state Then
    '            If state = True Then
    '                result = result + (2 ^ bit)
    '            Else
    '                If result >= (2 ^ bit) Then
    '                    result = result - (2 ^ bit)
    '                End If
    '            End If
    '        End If

    '        newVal = BitConverter.GetBytes(result)

    '        OmronEEIP.O_T_IOData(Offset * 2) = newVal(0)
    '        OmronEEIP.O_T_IOData((Offset * 2) + 1) = newVal(1)

    '        Return True
    '    End Function



    '    Public Function IMEIPReadString(offset As Integer, length As Integer) As String
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim text As New Text.StringBuilder
    '        Dim value(length - 1) As Byte
    '        For i As Integer = 0 To length - 1
    '            value(i) = OmronEEIP.T_O_IOData((offset * 2) + i)
    '            text.Append(Convert.ToChar(value(i)))
    '        Next
    '        Return text.ToString
    '    End Function


    '    Public Function IMEIPWriteString(offset As Integer, str As String, length As Integer) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim value(length - 1) As Byte
    '        For i As Integer = 0 To str.Length - 1
    '            value(i) = Convert.ToByte(str.Chars(i))
    '        Next
    '        For j As Integer = 0 To length - 1
    '            OmronEEIP.O_T_IOData((offset * 2) + j) = value(j)
    '        Next
    '        Return True
    '    End Function


    '    Public Function IMEIPWriteFloat(offset As Integer, real As Double) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim sign_value As Integer
    '        Dim fraction As Decimal
    '        Dim Absreal As Double = Math.Abs(real)
    '        Dim j As Integer = 0
    '        Dim exponent As Integer = 0
    '        Dim fractionpart As New Text.StringBuilder
    '        Dim fractionfinal As String = ""
    '        Dim Binarypart As New Text.StringBuilder
    '        Dim hexpart As New Text.StringBuilder
    '        Dim hexstr As String
    '        Dim val(3) As Byte

    '        ' Need to convert the decimal value into IEEE 754 form "0 10001000 10000000100101100000000"  bit 0 indicate sign, bit 1-8 indicate exponent, bit 9-31 indicate Mantessia
    '        'Finding the Sign Bit and add to binary text
    '        If real >= 0 Then
    '            sign_value = 0
    '            Binarypart.Append("0")
    '        Else
    '            sign_value = 1
    '            Binarypart.Append("1")
    '        End If

    '        'To find the exponent divide the number starting with 2 till we get value greater than 1 and less than 2
    '        If Absreal > 2 Then
    '            While Absreal > 2
    '                Absreal = Absreal / 2
    '                exponent = exponent + 1
    '            End While

    '        Else
    '            While Absreal < 1
    '                Absreal = Absreal * 2
    '                exponent = exponent - 1
    '            End While
    '        End If
    '        ' To Convert Signed exponent into unsigned bin
    '        If exponent >= -127 And exponent <= 127 Then
    '            exponent = 127 + exponent
    '        End If
    '        'Add binary of exponent to the binary text
    '        Binarypart.Append(DecToBin(exponent, 8))

    '        'Find the Value of Mantessa Part
    '        If Absreal > 1 Then
    '            fraction = Absreal - 1
    '        Else
    '            fraction = Absreal
    '        End If

    '        If fraction < 1 Then
    '            While fraction <> 0.0 And j < 23
    '                fraction = fraction * 2
    '                If fraction >= 1 Then
    '                    fractionpart.Append("1")
    '                    fraction = fraction - 1
    '                Else
    '                    fractionpart.Append("0")
    '                End If
    '                j = j + 1
    '            End While
    '        End If
    '        'If the Mantessa part length is less than 23, add zero to the right
    '        If (fractionpart.ToString).Length <= 23 Then
    '            fractionfinal = fractionpart.ToString.PadRight(23, "0"c)
    '        End If

    '        ' Add binary mantessa to binary text
    '        Binarypart.Append(fractionfinal)

    '        If Binarypart.ToString.Length = 32 Then
    '            hexpart.Append(BinToHex(Binarypart.ToString))
    '        End If
    '        hexpart.Insert(0, hexpart.ToString.Substring(4, 4))
    '        hexstr = hexpart.ToString.Remove(8, 4)

    '        For k As Integer = 0 To 3
    '            val(k) = HextoDec(hexstr.Substring(k * 2, 2))
    '        Next
    '        For l As Integer = 0 To 3
    '            If l Mod 2 = 0 Then
    '                OmronEEIP.O_T_IOData((offset * 2) + l) = val(l + 1)
    '            Else
    '                OmronEEIP.O_T_IOData((offset * 2) + l) = val(l - 1)
    '            End If
    '        Next
    '        Return True
    '    End Function

    '    Public Function IMEIPReadFloat(offset As Integer) As Decimal
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim hexchar As New Text.StringBuilder
    '        Dim firstpart As String
    '        Dim secondpart As String
    '        Dim modhex As String
    '        Dim boolstring As New Text.StringBuilder
    '        Dim hextoint(7) As Integer
    '        Dim Value(3) As Byte

    '        For i As Integer = 0 To 3
    '            If i Mod 2 = 0 Then
    '                Value(i) = OmronEEIP.T_O_IOData((offset * 2) + i + 1)
    '            Else
    '                Value(i) = OmronEEIP.T_O_IOData((offset * 2) + i - 1)
    '            End If
    '            hexchar.Append(Value(i).ToString("X2"))
    '        Next

    '        'The String has to be 2 words, we need to swap the words before processing
    '        firstpart = hexchar.ToString.Substring(0, 4)
    '        secondpart = hexchar.ToString.Substring(4, 4)
    '        modhex = String.Concat(secondpart, firstpart)

    '        'Convert the hex char into Decimal equivalent
    '        For i As Integer = 0 To modhex.Length - 1
    '            hextoint(i) = Convert.ToInt32(modhex.Substring(i, 1), 16)
    '        Next

    '        'Convert the Decimal equivalent into Boolean String
    '        For j As Integer = 0 To hexchar.Length - 1
    '            boolstring.Append(Convert.ToString(hextoint(j), 2).PadLeft(4, "0"c))
    '        Next
    '        Return (Math.Round(DecimalBoolStringtoDecimal(boolstring.ToString), 2)).ToString
    '    End Function

    '    Public Function IMEIPWriteInt(offset As Integer, Value As Integer) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Val As Byte() = BitConverter.GetBytes(Value)

    '        OmronEEIP.O_T_IOData(offset * 2) = Val(0)
    '        OmronEEIP.O_T_IOData((offset * 2) + 1) = Val(1)
    '        Return True
    '    End Function

    '    Public Function IMEIPReadInt(offset As Integer) As Integer
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Val(1) As Byte
    '        Val(0) = OmronEEIP.T_O_IOData(offset * 2)
    '        Val(1) = OmronEEIP.T_O_IOData((offset * 2) + 1)

    '        Return BitConverter.ToInt16(Val, 0)

    '    End Function



    '    Public Function IMEIPWriteDInt(offset As Integer, Value As Int32) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Val As Byte() = BitConverter.GetBytes(Value)

    '        For i As Integer = 0 To 3
    '            OmronEEIP.O_T_IOData((offset * 2) + i) = Val(i)
    '        Next
    '        Return True
    '    End Function

    '    Public Function IMEIPReadDInt(offset As Integer) As Int32
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Val(3) As Byte

    '        For i As Integer = 0 To 3
    '            Val(i) = OmronEEIP.T_O_IOData((offset * 2) + i)
    '        Next
    '        Return BitConverter.ToInt32(Val, 0)
    '    End Function






#End Region


#Region "EEIP Module Data Conversion-Explicit Messaging"
    '    'For EEIP Module Data

    '    Public Sub EXEIPInitialise()
    '        Try
    '            OmronEEIP.RegisterSession("192.168.0.1", 44818)
    '        Catch ex As Exception
    '            MsgBox(ex.Message & ex.StackTrace)
    '        End Try

    '    End Sub

    '    Public Sub EXEIPClose()
    '        Try

    '            OmronEEIP.UnRegisterSession()
    '        Catch ex As Exception
    '            MsgBox(ex.Message & ex.StackTrace)
    '        End Try
    '    End Sub

    '    Public Sub EXEIPreconnect()
    '        Try

    '            OmronEEIP.UnRegisterSession()
    '            EXEIPInitialise()

    '        Catch ex As Exception
    '            MsgBox(ex.Message & ex.StackTrace)
    '        End Try
    '    End Sub



    '    Public Function EXEIPReadBoolean(bytearr As Byte(), offset As Integer, bit As Integer) As Boolean

    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Value(1) As Byte
    '        Dim result(15) As Boolean
    '        Value(0) = bytearr(offset * 2)
    '        Value(1) = bytearr((offset * 2) + 1)
    '        For i As Integer = 0 To 7
    '            result(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
    '            result(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
    '        Next
    '        Return result(bit)
    '    End Function

    '    Public Function EXEIPReadBooleanArr(bytearr() As Byte, Offset As Integer) As Boolean()
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Value(1) As Byte
    '        Dim result(15) As Boolean
    '        Value(0) = bytearr(Offset * 2)
    '        Value(1) = bytearr((Offset * 2) + 1)
    '        For i As Integer = 0 To 7
    '            result(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
    '            result(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
    '        Next
    '        Return result
    '    End Function

    '    Public Function EXEIPWriteBoolean(bytearr As Byte(), Offset As Integer, bit As Integer, state As Boolean) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Value(1) As Byte
    '        Dim result As Integer
    '        Dim newVal As Byte()
    '        Dim resultarr(15) As Boolean

    '        Value(0) = bytearr(Offset * 2)
    '        Value(1) = bytearr((Offset * 2) + 1)
    '        For i As Integer = 0 To 7
    '            resultarr(i) = ((Value(0) And 2 ^ i) / 2 ^ i)
    '            resultarr(i + 8) = ((Value(1) And 2 ^ i) / 2 ^ i)
    '        Next


    '        result = BitConverter.ToUInt16(Value, 0)

    '        If Not resultarr(bit) = state Then
    '            If state = True Then
    '                result = result + (2 ^ bit)
    '            Else
    '                If result >= (2 ^ bit) Then
    '                    result = result - (2 ^ bit)
    '                End If
    '            End If
    '        End If

    '        newVal = BitConverter.GetBytes(result)

    '        bytearr(Offset * 2) = newVal(0)
    '        bytearr((Offset * 2) + 1) = newVal(1)

    '        Return True
    '    End Function



    '    Public Function EXEIPReadString(bytearr As Byte(), offset As Integer, length As Integer) As String
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim text As New Text.StringBuilder
    '        Dim value(length - 1) As Byte
    '        For i As Integer = 0 To length - 1
    '            value(i) = bytearr((offset * 2) + i)
    '            text.Append(Convert.ToChar(value(i)))
    '        Next
    '        Return text.ToString
    '    End Function


    '    Public Function EXEIPWriteString(bytearr As Byte(), offset As Integer, str As String, length As Integer) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES

    '        Dim value(length - 1) As Byte
    '        For i As Integer = 0 To str.Length - 1
    '            value(i) = Convert.ToByte(str.Chars(i))
    '        Next
    '        For j As Integer = 0 To length - 1
    '            bytearr((offset * 2) + j) = value(j)
    '        Next
    '        Return True
    '    End Function


    '    Public Function EXEIPWriteFloat(bytearr As Byte(), offset As Integer, real As Double) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim sign_value As Integer
    '        Dim fraction As Decimal
    '        Dim Absreal As Double = Math.Abs(real)
    '        Dim j As Integer = 0
    '        Dim exponent As Integer = 0
    '        Dim fractionpart As New Text.StringBuilder
    '        Dim fractionfinal As String = ""
    '        Dim Binarypart As New Text.StringBuilder
    '        Dim hexpart As New Text.StringBuilder
    '        Dim hexstr As String
    '        Dim val(3) As Byte

    '        ' Need to convert the decimal value into IEEE 754 form "0 10001000 10000000100101100000000"  bit 0 indicate sign, bit 1-8 indicate exponent, bit 9-31 indicate Mantessia
    '        'Finding the Sign Bit and add to binary text
    '        If real >= 0 Then
    '            sign_value = 0
    '            Binarypart.Append("0")
    '        Else
    '            sign_value = 1
    '            Binarypart.Append("1")
    '        End If

    '        'To find the exponent divide the number starting with 2 till we get value greater than 1 and less than 2
    '        If Absreal > 2 Then
    '            While Absreal > 2
    '                Absreal = Absreal / 2
    '                exponent = exponent + 1
    '            End While

    '        Else
    '            While Absreal < 1
    '                Absreal = Absreal * 2
    '                exponent = exponent - 1
    '            End While
    '        End If
    '        ' To Convert Signed exponent into unsigned bin
    '        If exponent >= -127 And exponent <= 127 Then
    '            exponent = 127 + exponent
    '        End If
    '        'Add binary of exponent to the binary text
    '        Binarypart.Append(DecToBin(exponent, 8))

    '        'Find the Value of Mantessa Part
    '        If Absreal > 1 Then
    '            fraction = Absreal - 1
    '        Else
    '            fraction = Absreal
    '        End If

    '        If fraction < 1 Then
    '            While fraction <> 0.0 And j < 23
    '                fraction = fraction * 2
    '                If fraction >= 1 Then
    '                    fractionpart.Append("1")
    '                    fraction = fraction - 1
    '                Else
    '                    fractionpart.Append("0")
    '                End If
    '                j = j + 1
    '            End While
    '        End If
    '        'If the Mantessa part length is less than 23, add zero to the right
    '        If (fractionpart.ToString).Length <= 23 Then
    '            fractionfinal = fractionpart.ToString.PadRight(23, "0"c)
    '        End If

    '        ' Add binary mantessa to binary text
    '        Binarypart.Append(fractionfinal)

    '        If Binarypart.ToString.Length = 32 Then
    '            hexpart.Append(BinToHex(Binarypart.ToString))
    '        End If
    '        hexpart.Insert(0, hexpart.ToString.Substring(4, 4))
    '        hexstr = hexpart.ToString.Remove(8, 4)

    '        For k As Integer = 0 To 3
    '            val(k) = HextoDec(hexstr.Substring(k * 2, 2))
    '        Next
    '        For l As Integer = 0 To 3
    '            If l Mod 2 = 0 Then
    '                bytearr((offset * 2) + l) = val(l + 1)
    '            Else
    '                bytearr((offset * 2) + l) = val(l - 1)
    '            End If
    '        Next
    '        Return True
    '    End Function

    '    Public Function EXEIPReadFloat(bytearr As Byte(), offset As Integer) As Decimal
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim hexchar As New Text.StringBuilder
    '        Dim firstpart As String
    '        Dim secondpart As String
    '        Dim modhex As String
    '        Dim boolstring As New Text.StringBuilder
    '        Dim hextoint(7) As Integer
    '        Dim Value(3) As Byte

    '        For i As Integer = 0 To 3
    '            If i Mod 2 = 0 Then
    '                Value(i) = bytearr((offset * 2) + i + 1)
    '            Else
    '                Value(i) = bytearr((offset * 2) + i - 1)
    '            End If
    '            hexchar.Append(Value(i).ToString("X2"))
    '        Next

    '        'The String has to be 2 words, we need to swap the words before processing
    '        firstpart = hexchar.ToString.Substring(0, 4)
    '        secondpart = hexchar.ToString.Substring(4, 4)
    '        modhex = String.Concat(secondpart, firstpart)

    '        'Convert the hex char into Decimal equivalent
    '        For i As Integer = 0 To modhex.Length - 1
    '            hextoint(i) = Convert.ToInt32(modhex.Substring(i, 1), 16)
    '        Next

    '        'Convert the Decimal equivalent into Boolean String
    '        For j As Integer = 0 To hexchar.Length - 1
    '            boolstring.Append(Convert.ToString(hextoint(j), 2).PadLeft(4, "0"c))
    '        Next
    '        Return (Math.Round(DecimalBoolStringtoDecimal(boolstring.ToString), 2)).ToString
    '    End Function

    '    Public Function EXEIPWriteInt(bytearr As Byte(), offset As Integer, Value As Integer) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Val As Byte() = BitConverter.GetBytes(Value)

    '        bytearr(offset * 2) = Val(0)
    '        bytearr((offset * 2) + 1) = Val(1)
    '        Return True
    '    End Function

    '    Public Function EXEIPReadInt(bytearr As Byte(), offset As Integer) As Integer
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Val(1) As Byte
    '        Val(0) = bytearr(offset * 2)
    '        Val(1) = bytearr((offset * 2) + 1)

    '        Return BitConverter.ToInt16(Val, 0)

    '    End Function


    '    Public Function EXEIPWriteDInt(bytearr As Byte(), offset As Integer, Value As Int32) As Boolean
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Val As Byte() = BitConverter.GetBytes(Value)

    '        For i As Integer = 0 To 3
    '            bytearr((offset * 2) + i) = Val(i)
    '        Next
    '        Return True
    '    End Function

    '    Public Function EXEIPReadDInt(bytearr As Byte(), offset As Integer) As Int32
    '        'OFFSET IN TERMS OF NUMBER OF WORDS, NOT BYTES
    '        Dim Val(3) As Byte

    '        For i As Integer = 0 To 3
    '            Val(i) = bytearr((offset * 2) + i)
    '        Next
    '        Return BitConverter.ToInt32(Val, 0)
    '    End Function






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

        For i As Integer = 0 To Alarm.Length - 1
            For j As Integer = 0 To 15
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
                        'FormMain.dgv_CurrentAlarm.Rows.Add(Currentalarm.Count, FormMain.lbl_DateTimeClock.Text, dtAlarm.Rows((i * 16) + j).Item("description"), alarmcode)
                        alarmmessage.Item("id") = alarmid
                        alarmmessage.Item("S.No") = Currentalarm.Count
                        alarmmessage.Item("Trigger Time") = FormMain.lbl_DateTimeClock.Text
                        alarmmessage.Item("Description") = dtAlarm.Rows((i * 16) + j).Item("description")
                        alarmmessage.Item("Alarm Code") = alarmcode
                        Mainalarm.Rows.Add(alarmmessage)
                    End If
                Else
                    If Alarm(i)(j) = False And Currentalarm.ContainsKey(dtAlarm.Rows((i * 16) + j).Item("id")) Then

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
                    End If
                End If
            Next
        Next


        Return True
    End Function

    Public Function FetchWarning(start As Integer) As Boolean

        For i As Integer = 0 To Warning.Length - 1
            Warning(i) = Int2BoolArr(FINSinput(start + i))
        Next

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




    Public Function FINSInputRead() As Boolean
        Try
            'FINSOutput = OmronPLC.ReadMemoryWord(PoohFinsETN.MemoryTypes.DM, 0, 200, PoohFinsETN.DataTypes.UnSignBIN)
            FINSinput = OmronPLC.ReadMemoryWord(PoohFinsETN.MemoryTypes.DM, 500, 300, PoohFinsETN.DataTypes.UnSignBIN)
        Catch ex As Exception
            MsgBox("Cannot able to communicate with PLC, Connection failed")
        End Try

        Return True
    End Function

    Public Function FINSOutputRead() As Boolean
        Try
            FINSOutput = OmronPLC.ReadMemoryWord(PoohFinsETN.MemoryTypes.DM, 0, 200, PoohFinsETN.DataTypes.UnSignBIN)
            For i As Integer = 0 To 5
                ManualCtrl(i) = Int2BoolArr(FINSOutput(3 + i))
            Next
            For i As Integer = 0 To 2
                PCStatus(i) = Int2BoolArr(FINSOutput(i))
            Next
        Catch ex As Exception
            MsgBox("Cannot able to communicate with PLC, Connection failed")
        End Try

        Return True
    End Function


    Public Function FINSWrite(offset As Integer, size As Integer) As Boolean
        Try
            Dim text As New StringBuilder
            PLCtimer.Enabled = False

            For i As Integer = 0 To size - 1
                text.Append(Fillzerobefore(Conversion.Hex(FINSOutput(offset + i)), 4))
                'OmronPLC.WriteMemoryWord(PoohFinsETN.MemoryTypes.DM, offset + i, FINSOutput(offset + i), PoohFinsETN.DataTypes.UnSignBIN)
            Next
            OmronPLC.WriteMemory(PoohFinsETN.MemoryTypes.DM, 0, text.ToString)
            FINSOutputRead()
            PLCtimer.Enabled = True
        Catch ex As Exception
            MsgBox("Cannot able to communicate with PLC, Connection failed")
        End Try

        Return True
    End Function

    Private Sub PLCTimer_Ticks(sender As Object, e As EventArgs) Handles PLCtimer.Tick


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



#Region "PLC-PC Heartbeat handshake"

        'PLC - PC HeartBeat indication label backcolor control 
        If PLCstatus(0)(0) = True Then
            PCStatus(0)(0) = False
            FormMain.lbl_B0.BackColor = Color.LimeGreen
            FormMain.lbl_B1.BackColor = SystemColors.Control
            'FormMain.pb_Valve1Path1.BackColor = SystemColors.Control
        Else
            PCStatus(0)(0) = True
            FormMain.lbl_B0.BackColor = SystemColors.Control
            FormMain.lbl_B1.BackColor = Color.LimeGreen
            'FormMain.pb_Valve1Path1.BackColor = Color.FromArgb(25, 130, 246)
        End If

#End Region


#Region "Pump and tank status update on all page in main form"
        'Manual Pump Control label based on controller feedback
        If DIn(1)(7) = True Then
            FormMain.lbl_MCPumpState.BackColor = Color.LimeGreen
            FormMain.lbl_PZonePumpState.BackColor = Color.LimeGreen
        Else
            FormMain.lbl_MCPumpState.BackColor = SystemColors.Window
            FormMain.lbl_PZonePumpState.BackColor = SystemColors.Window
        End If

        If DIn(1)(8) = True Then
            FormMain.lbl_MCPumpError.BackColor = SystemColors.Window
            FormMain.lbl_PZonePumpError.BackColor = SystemColors.Window
        Else
            FormMain.lbl_MCPumpError.BackColor = Color.Red
            FormMain.lbl_PZonePumpError.BackColor = Color.Red
        End If

        If DIn(1)(9) = True Then
            FormMain.lbl_MCPumpWarning.BackColor = SystemColors.Window
            FormMain.lbl_PZonePumpWarning.BackColor = SystemColors.Window
        Else
            FormMain.lbl_MCPumpWarning.BackColor = Color.Red
            FormMain.lbl_PZonePumpWarning.BackColor = Color.Red
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

        'If ManualCtrl(3)(3) = True And FormMain.btn_PumpReset.Text = "ON" Then
        '    ManualCtrl(3)(3) = False
        'End If

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





        'Manual Drain Label Color Change based on PLC status
        If PLCstatus(2)(0) = False Then
            SetButtonState(FormMain.btn_MCN2Purge1, False, "OFF")
        Else
            SetButtonState(FormMain.btn_MCN2Purge1, True, "ON")
        End If

        If PLCstatus(2)(1) = False Then
            SetButtonState(FormMain.btn_MCN2Purge2, False, "OFF")
        Else
            SetButtonState(FormMain.btn_MCN2Purge2, True, "ON")
        End If

        If PLCstatus(2)(2) = False Then
            SetButtonState(FormMain.btn_MCN2Purge3, False, "OFF")
        Else
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

#End Region


#Region "Mimic Panel Circuit Model 1"
        'Manual valve Control Button Color change on Output on
        For i As Integer = 0 To 15

            If DOut(1)(i) = False Then

                ModuleCircuitModel.Lbl_ValvestatusArr(i).BackColor = SystemColors.Window
                ModuleCircuitModel.Lbl_ValvestatusArr(i).ForeColor = SystemColors.ControlText
            Else

                ModuleCircuitModel.Lbl_ValvestatusArr(i).BackColor = Color.LimeGreen
                ModuleCircuitModel.Lbl_ValvestatusArr(i).ForeColor = SystemColors.Window

            End If

        Next

        For i As Integer = 0 To 2

            If DOut(2)(i) = False Then

                ModuleCircuitModel.Lbl_ValvestatusArr(i + 16).BackColor = SystemColors.Window
                ModuleCircuitModel.Lbl_ValvestatusArr(i + 16).ForeColor = SystemColors.ControlText
            Else

                ModuleCircuitModel.Lbl_ValvestatusArr(i + 16).BackColor = Color.LimeGreen
                ModuleCircuitModel.Lbl_ValvestatusArr(i + 16).ForeColor = SystemColors.Window
            End If

        Next

        If FormCircuitModel1.btn_MVCShowcircuit.BackColor = Color.FromArgb(25, 130, 246) Then
            For i As Integer = 0 To 18
                Circuitcall(i) = 0
                For j As Integer = 0 To pb_MCVCircuitArr(i + 1).Length - 1
                    pb_MCVCircuitArr(i + 1)(j).Visible = False
                    pb_MCVCircuitArr(i + 1)(j).BackColor = Color.Transparent
                    pb_MCVCircuitArr(i + 1)(j).SendToBack()
                Next
                For j As Integer = 0 To pb_MCVCircuitPathArr(i + 1).Length - 1
                    'pb_MCVCircuitArr(i + 1)(j).Visible = False
                    pb_MCVCircuitPathArr(i + 1)(j).BackColor = Color.Transparent
                    pb_MCVCircuitPathArr(i + 1)(j).SendToBack()

                Next
            Next
        End If
        FormCircuitModel1.txtbx_BackPressActual.Text = AIn(1).ToString
        FormCircuitModel1.txtbx_N2PurgeActual.Text = AIn(0).ToString
        FormCircuitModel1.lbl_InletPress.Text = AIn(9).ToString
        FormCircuitModel1.lbl_OutletPress.Text = AIn(10).ToString
        FormCircuitModel1.lbl_Flowmtr.Text = AIn(12).ToString
        FormCircuitModel1.lbl_Temp.Text = AIn(13).ToString

        'Circuit path and valve signal remove
        For i As Integer = 0 To 15

            If DOut(1)(i) = False Then
                For j As Integer = 0 To pb_MCVCircuitArr(i + 1).Length - 1
                    pb_MCVCircuitArr(i + 1)(j).Visible = False
                    pb_MCVCircuitArr(i + 1)(j).BackColor = Color.Transparent
                    pb_MCVCircuitArr(i + 1)(j).SendToBack()
                Next
                For j As Integer = 0 To pb_MCVCircuitPathArr(i + 1).Length - 1
                    'pb_MCVCircuitArr(i + 1)(j).Visible = False
                    pb_MCVCircuitPathArr(i + 1)(j).BackColor = Color.Transparent
                    pb_MCVCircuitPathArr(i + 1)(j).SendToBack()
                Next

            End If
        Next

        For i As Integer = 0 To 2

            If DOut(2)(i) = False Then
                For j As Integer = 0 To pb_MCVCircuitArr(i + 17).Length - 1
                    pb_MCVCircuitArr(i + 17)(j).Visible = False
                    pb_MCVCircuitArr(i + 17)(j).BackColor = Color.Transparent
                    pb_MCVCircuitArr(i + 17)(j).SendToBack()
                Next
                For j As Integer = 0 To pb_MCVCircuitPathArr(i + 17).Length - 1
                    'pb_MCVCircuitArr(i + 1)(j).Visible = False
                    pb_MCVCircuitPathArr(i + 17)(j).BackColor = Color.Transparent
                    pb_MCVCircuitPathArr(i + 17)(j).SendToBack()

                Next
            End If
        Next


#End Region


        'Recipe Selection
        If FormMain.txtbx_TitleRecipeID.Text.Length > 3 Then
            FINSOutput(20) = 1
        Else
            FINSOutput(20) = 0
        End If





        'Write the PLC Output
        Put_PCManualctrl()
        FINSWrite(0, 200)
        LabelStatusupdate()
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
        PCtimer.Stop()
    End Sub


    Public Sub LabelStatusupdate()
        If PLCstatus(0)(4) = False And PLCstatus(0)(14) = False Then
            If PLCstatus(0)(1) = True Then
                FormMain.lbl_OperationMode.Text = "Auto Cycle Running"
                FormMain.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)
            End If
            If PLCstatus(0)(2) = True Then
                FormMain.lbl_OperationMode.Text = "Manual Mode"
                FormMain.lbl_OperationMode.BackColor = Color.FromArgb(25, 130, 246)
            End If

            If PLCstatus(0)(3) = True And PLCstatus(0)(2) = False Then
                FormMain.lbl_OperationMode.Text = "Auto Mode"
                FormMain.lbl_OperationMode.BackColor = Color.FromArgb(0, 192, 0)
            End If

            If PLCstatus(0)(1) = False And PLCstatus(0)(2) = False And PLCstatus(0)(3) = False Then
                FormMain.lbl_OperationMode.Text = "No Status"
                FormMain.lbl_OperationMode.BackColor = Color.Gray
            End If

        End If

    End Sub


End Module


