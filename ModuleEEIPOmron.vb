Imports EEIP

Module ModuleEEIPOmron

    Public PLCConnection As New EEIP.EEIPClient
    Private PLCIPAddress As String = "192.168.0.1"
    Public Function PLCCOnnect() As Boolean
        'Ip-Address of the Ethernet-IP Device (In this case Omron PLC)
        PLCConnection.IPAddress = PLCIPAddress
        'A Session has to be registered before any communication can be established
        PLCConnection.RegisterSession()


        'Parameters from Originator -> Target
        PLCConnection.O_T_InstanceID = &H64             'Instance ID Of the Output Assembly
        PLCConnection.O_T_Length = 20                    'The Method "Detect_O_T_Length" detect the Length Using an UCMM Message
        PLCConnection.O_T_RealTimeFormat = EEIP.RealTimeFormat.Header32Bit  'Header Format
        PLCConnection.O_T_OwnerRedundant = False
        PLCConnection.O_T_Priority = EEIP.Priority.Scheduled
        PLCConnection.O_T_VariableLength = False
        PLCConnection.O_T_ConnectionType = EEIP.ConnectionType.Point_to_Point
        PLCConnection.RequestedPacketRate_O_T = 500000       '500ms Is the Standard value

        'Parameters from Target -> Originator
        PLCConnection.T_O_InstanceID = &H65
        PLCConnection.T_O_Length = 20
        PLCConnection.T_O_RealTimeFormat = EEIP.RealTimeFormat.Modeless
        PLCConnection.T_O_OwnerRedundant = False
        PLCConnection.T_O_Priority = EEIP.Priority.Scheduled
        PLCConnection.T_O_VariableLength = False
        PLCConnection.T_O_ConnectionType = EEIP.ConnectionType.Multicast
        PLCConnection.RequestedPacketRate_T_O = 500000   'RPI In  500ms Is the Standard value

        'Forward open initiates the Implicit Messaging
        PLCConnection.ForwardOpen()

        While (True)

            System.Threading.Thread.Sleep(500)
            'Detect Timeout (Read last Received Message Property)
            If (DateTime.Now.Ticks > PLCConnection.LastReceivedImplicitMessage.Ticks + (1000 * 10000)) Then

                Try

                    PLCConnection.ForwardClose()
                    PLCConnection.UnRegisterSession()

                    PLCConnection.RegisterSession()
                    PLCConnection.ForwardOpen()

                Catch e As Exception

                    MsgBox($"Couldn't reconnect to PLC due to {e}")
                End Try

            End If

        End While

        Return True
    End Function


End Module
