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

                FormMain.lbl_CommOpen.BackColor = Color.LimeGreen
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
            Dim rcv As String = mySerialPort1.ReadLine()
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
        If str.Length = 9 Then
            If FormMain.txtbx_WorkOrderNumber.Enabled = True Then
                FormMain.txtbx_WorkOrderNumber.Text = str

            End If
        End If

            If str.Length > 15  Then
            If FormMain.txtbx_PartID.Enabled = True Then
                FormMain.txtbx_PartID.Text = str
            End If
        End If

        If str.Length = 10 And str.Contains("SG") = True Then
            If FormMain.txtbx_LotID.Enabled = True Then
                FormMain.txtbx_LotID.Text = str
            End If
        End If

        If str.Length = 10 And str.Contains("SG") = False Then
            If FormMain.txtbx_ConfirmationID.Enabled = True Then
                FormMain.txtbx_ConfirmationID.Text = str
            End If
        End If
        If str.Length < 4 Then
            If FormMain.txtbx_Quantity.Enabled = True Then
                FormMain.txtbx_Quantity.Text = str
            End If
        End If
        SerialDataReceived = False
    End Sub

    Private Sub ScannerTimer_Ticks(sender As Object, e As EventArgs) Handles Scannertimer.Tick

        If SerialDataReceived = True Then
            PlaceData(HandheldScandata)
            FormSetting.txtbx_ScannerRawData.Text = HandheldScanraw
            SerialDataReceived = False
        End If

        'If mySerialPort1.IsOpen = False Then
        '    ComPort1Connected = False
        '    FormMain.lbl_CommOpen.BackColor = SystemColors.Window
        'End If

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
