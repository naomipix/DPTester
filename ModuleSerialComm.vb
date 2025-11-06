Imports System.IO.Ports

Module ModuleSerialComm
    Public mySerialPort1 As SerialPort
    Public ComPort1Connected As Boolean
    Public SerialDataReceived As Boolean
    Public HandheldScanraw As String
    Public HandheldScandata As String
    Public Tempscandata As String
    Public ConnectionRetry As Integer
    Public WithEvents Scannertimer As New Timer()
    Public rcv As String
    Public Sub StartSerialComListener1()
        Try
            mySerialPort1 = New SerialPort()
            With mySerialPort1
                .PortName = "COM3"
                .BaudRate = 9600
                .DataBits = 8
                .Parity = Parity.None
                .StopBits = StopBits.One
                .Handshake = Handshake.None
                AddHandler .DataReceived, AddressOf SerialComDataReceivedHandler1
            End With
            mySerialPort1.Open()
            If mySerialPort1.IsOpen Then
                ComPort1Connected = True

                FormMain.lbl_CommOpen.BackColor = PublicVariables.StatusGreen
                Scannertimer.Interval = 100
                Scannertimer.Enabled = True
            Else
                ComPort1Connected = False
                Scannertimer.Enabled = False
                'Scannertimer.Enabled = False
                FormMain.lbl_CommOpen.BackColor = SystemColors.Window
            End If
        Catch ex As Exception
            ComPort1Connected = False

            FormMain.lbl_CommOpen.BackColor = SystemColors.Window
            'MsgBox($"Scanner Disconnected or COM3 Does not exists")
            'Scannertimer.Enabled = False
        End Try
    End Sub

    Private Sub SerialComDataReceivedHandler1(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            rcv = String.Empty
            rcv = mySerialPort1.ReadLine()
            HandheldScanraw = rcv

            If HandheldScanraw <> "" And HandheldScanraw <> Tempscandata Then
                Tempscandata = HandheldScanraw.Replace(vbCr, "").Replace(vbLf, "")
                HandheldScandata = Tempscandata
            End If

            SerialDataReceived = True
            If Scannertimer.Enabled = False Then
                Scannertimer.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("Scan Failed, Please Try Again!")
        End Try
    End Sub

    Public Sub PlaceData(str As String)
        If True Then
            Dim onContinue = True

            If onContinue Then ' Work Order ID 
                If str.Length >= PublicVariables.WorkOrderLenLow And str.Length <= PublicVariables.WorkOrderLenHigh Then
                    Dim numericValue As Long

                    ' Check if string is numeric and within the allowed ranges
                    If Long.TryParse(str, numericValue) AndAlso ((numericValue >= 6000000 AndAlso numericValue <= 6999999) OrElse (numericValue >= 100000000 AndAlso numericValue <= 199999999)) Then

                        If FormMain.txtbx_WorkOrderNumber.Enabled = True Then
                            FormMain.txtbx_WorkOrderNumber.Text = str
                            onContinue = False
                        End If
                    End If
                End If
            End If
            If onContinue Then ' Lot ID 
                If str.Length >= PublicVariables.LotIdLenLow AndAlso str.Length <= PublicVariables.LotIdLenHigh Then
                    Dim prefix As String = str.Substring(0, 2) '.ToUpper() 

                    If (prefix = "TK" OrElse prefix = "SG") Then

                        If FormMain.txtbx_LotID.Enabled = True Then
                            FormMain.txtbx_LotID.Text = str
                            onContinue = False
                        End If
                    End If
                End If
            End If
            If onContinue Then ' Confirmation
                If str.Length >= PublicVariables.ConfirmationIdLenLow And str.Length <= PublicVariables.ConfirmationIdLenHigh Then
                    If FormMain.txtbx_ConfirmationID.Enabled = True Then
                        Dim ParsedInt As Integer = 0
                        If Integer.TryParse(str, ParsedInt) Then
                            FormMain.txtbx_ConfirmationID.Text = str
                            onContinue = False
                        End If
                    End If
                End If
            End If
            If onContinue Then  ' Quantity
                If str.Length >= PublicVariables.QuantityLenLow And str.Length <= PublicVariables.QuantityLenHigh Then
                    If FormMain.txtbx_Quantity.Enabled = True Then
                        Dim ParsedInt As Integer = 0
                        If Integer.TryParse(str, ParsedInt) AndAlso ParsedInt > 0 Then
                            FormMain.txtbx_Quantity.Text = ParsedInt
                            onContinue = False
                        End If
                    End If
                End If
            End If
            If onContinue Then ' Part ID
                If str.Length >= PublicVariables.PartIdLenLow And str.Length <= PublicVariables.PartIdLenHigh Then
                    If FormMain.txtbx_PartID.Enabled = True Then
                        FormMain.txtbx_PartID.Text = str
                    End If
                End If
            End If
        End If
        SerialDataReceived = False
    End Sub

    Public Sub PlaceDataOld(str As String)
        'If True Then
        '    If str.Length >= PublicVariables.WorkOrderLenLow And str.Length <= PublicVariables.WorkOrderLenHigh Then
        '        If FormMain.txtbx_WorkOrderNumber.Enabled = True Then
        '            FormMain.txtbx_WorkOrderNumber.Text = str
        '        End If
        '    End If

        '    If str.Length >= PublicVariables.ConfirmationIdLenLow And str.Length <= PublicVariables.ConfirmationIdLenHigh And Char.IsLetter(str.Substring(0, 1)) = False Then
        '        If FormMain.txtbx_ConfirmationID.Enabled = True Then
        '            FormMain.txtbx_ConfirmationID.Text = str
        '        End If
        '    End If

        '    If str.Length >= PublicVariables.PartIdLenLow And str.Length <= PublicVariables.PartIdLenHigh Then
        '        If FormMain.txtbx_PartID.Enabled = True Then
        '            FormMain.txtbx_PartID.Text = str
        '        End If
        '    End If

        '    If str.Length >= PublicVariables.LotIdLenLow And str.Length <= PublicVariables.LotIdLenHigh And Char.IsLetter(str.Substring(0, 1)) = True Then
        '        If FormMain.txtbx_LotID.Enabled = True Then
        '            FormMain.txtbx_LotID.Text = str
        '        End If
        '    End If

        '    If str.Length >= PublicVariables.QuantityLenLow And str.Length <= PublicVariables.QuantityLenHigh Then
        '        If FormMain.txtbx_Quantity.Enabled = True Then
        '            'FormMain.txtbx_Quantity.Text = str

        '            Dim ParsedInt As Integer = 0
        '            If Integer.TryParse(str, ParsedInt) Then
        '                FormMain.txtbx_Quantity.Text = ParsedInt
        '            End If
        '        End If
        '    End If
        'End If
        If True Then
            Dim onContinue = True

            If onContinue Then ' Lot ID
                If str.Length >= PublicVariables.LotIdLenLow And str.Length <= PublicVariables.LotIdLenHigh And Char.IsLetter(str.Substring(0, 1)) = True Then
                    If FormMain.txtbx_LotID.Enabled = True Then
                        FormMain.txtbx_LotID.Text = str
                        onContinue = False
                    End If
                End If
            End If
            If onContinue Then ' Work Order ID
                If str.Length >= PublicVariables.WorkOrderLenLow And str.Length <= PublicVariables.WorkOrderLenHigh Then
                    If FormMain.txtbx_WorkOrderNumber.Enabled = True Then
                        FormMain.txtbx_WorkOrderNumber.Text = str
                        onContinue = False
                    End If
                End If
            End If
            If onContinue Then  ' Quantity
                If str.Length >= PublicVariables.QuantityLenLow And str.Length <= PublicVariables.QuantityLenHigh Then
                    If FormMain.txtbx_Quantity.Enabled = True Then
                        Dim ParsedInt As Integer = 0
                        If Integer.TryParse(str, ParsedInt) Then
                            FormMain.txtbx_Quantity.Text = ParsedInt
                            onContinue = False
                        End If
                    End If
                End If
            End If
            If onContinue Then ' Confirmation
                If str.Length >= PublicVariables.ConfirmationIdLenLow And str.Length <= PublicVariables.ConfirmationIdLenHigh Then
                    If FormMain.txtbx_ConfirmationID.Enabled = True Then
                        Dim ParsedInt As Integer = 0
                        If Integer.TryParse(str, ParsedInt) Then
                            FormMain.txtbx_ConfirmationID.Text = str
                            onContinue = False
                        End If
                    End If
                End If
            End If
            If onContinue Then ' Part ID
                If str.Length >= PublicVariables.PartIdLenLow And str.Length <= PublicVariables.PartIdLenHigh Then
                    If FormMain.txtbx_PartID.Enabled = True Then
                        FormMain.txtbx_PartID.Text = str
                    End If
                End If
            End If
        End If
        SerialDataReceived = False
    End Sub

    Private Sub ScannerTimer_Ticks(sender As Object, e As EventArgs) Handles Scannertimer.Tick
        If SerialDataReceived = True Then
            PlaceData(HandheldScandata)
            FormSetting.txtbx_ScannerRawData.Text = HandheldScanraw
            FormMain.txtbx_HandScanner.Text = rcv
            SerialDataReceived = False
        End If

        If My.Computer.Ports.SerialPortNames.Contains("COM3") = True Then
            If ComPort1Connected = False Then
                FormMain.lbl_CommOpen.BackColor = SystemColors.Window
                StartSerialComListener1()
            End If
        Else
            ComPort1Connected = False
            FormMain.lbl_CommOpen.BackColor = SystemColors.Window
        End If
    End Sub
End Module