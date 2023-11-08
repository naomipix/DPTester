Imports System.ComponentModel
Imports System.Linq.Expressions
Imports System.Security.Claims
Imports PoohPlcLink
Imports EEIP


Public Class Form1

    Dim a As String
    Dim val As Integer
    Dim b As String
    Dim d As Decimal


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TimerModule.clockTimer.Start()
        FINSInitialise()
        txtbx_DM200.Text = "0"
        txtbx_DM1.Text = "0"
        Timer1.Enabled = True
        txtbx_DM100.Text = ""
        txtbx_EEIPout.Text = "0"


    End Sub

    Private Sub btn_DM10_Click(sender As Object, e As EventArgs) Handles btn_DM10.Click
        txtbx_DM10.Text = OmronPLC.ReadMemoryWord(PoohFinsETN.MemoryTypes.DM, 10, 1).ToString
    End Sub

    Private Sub btn_DM200_Click(sender As Object, e As EventArgs) Handles btn_DM200.Click
        OmronPLC.WriteMemoryWord(PoohFinsETN.MemoryTypes.DM, 200, CType(txtbx_DM200.Text, Integer), PoohFinsETN.DataTypes.SignBIN)
        txtbx_DM0.Text = OmronPLC.ReadMemoryWord(PoohFinsETN.MemoryTypes.DM, 0, 1).ToString
    End Sub

    Private Sub btn_DM1_Click(sender As Object, e As EventArgs) Handles btn_DM1.Click
        txtbx_DM1.Text = RealFromPLC(OmronPLC, PoohFinsETN.MemoryTypes.DM, 1)
        RealtoPLC(OmronPLC, PoohFinsETN.MemoryTypes.DM, 201, CType(txtbx_DM201.Text, Decimal))

    End Sub

    Private Sub btn_DM500_1_Click(sender As Object, e As EventArgs) Handles btn_DM500_1.Click
        OmronPLC.WriteMemoryBit(PoohFinsETN.MemoryTypes.DM, 500, 1, True)

        If (OmronPLC.ReadMemoryBit(PoohFinsETN.MemoryTypes.DM, 500, 2)) Then
            Label6.BackColor = Color.Green
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OmronPLC.WriteMemoryBit(PoohFinsETN.MemoryTypes.DM, 500, 1, False)

        If Not (OmronPLC.ReadMemoryBit(PoohFinsETN.MemoryTypes.DM, 500, 2)) Then
            Label6.BackColor = SystemColors.Window
        End If
    End Sub



    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'IMEIPClose()
        Timer1.Enabled = False
    End Sub

    Private Sub btn_DM100_Click(sender As Object, e As EventArgs) Handles btn_DM100.Click
        OmronPLC.WriteMemoryString(PoohFinsETN.MemoryTypes.DM, 100, StringByteSwap(txtbx_DM100.Text))

    End Sub

    Private Sub btn_DM120_Click(sender As Object, e As EventArgs) Handles btn_DM120.Click
        txtbx_DM120.Text = StringByteSwap(OmronPLC.ReadMemoryString(PoohFinsETN.MemoryTypes.DM, 120, 10))
    End Sub

    Private Sub btn_EEIPread_Click(sender As Object, e As EventArgs) Handles btn_EEIPread.Click

        Dim dm300() As Boolean = IMEIPReadBooleanArr(0)

        If dm300(CType(txtbx_EEIPout.Text, Integer)) = True Then
            lbl_EEIP_out.BackColor = Color.Green
        Else
            lbl_EEIP_out.BackColor = SystemColors.Control
        End If

        If IMEIPReadBoolean(0, 4) = True Then
            lbl_EEIP_in.BackColor = Color.Green
        Else
            lbl_EEIP_in.BackColor = SystemColors.Control
        End If

        System.Threading.Thread.Sleep(500)
    End Sub

    Private Sub btn_EEIPStrread_Click(sender As Object, e As EventArgs) Handles btn_EEIPStrread.Click
        txtbx_EEIPstrin.Text = IMEIPReadString(4, 10)
    End Sub


    Private Sub btn_EEIPstrWrite_Click(sender As Object, e As EventArgs) Handles btn_EEIPstrWrite.Click
        IMEIPWriteString(4, txtbx_EEIPstrout.Text, 10)

    End Sub

    Private Sub btn_EEIPFloatwrite_Click(sender As Object, e As EventArgs) Handles btn_EEIPFloatwrite.Click
        IMEIPWriteFloat(2, CType(txtbx_Floatwrite.Text, Decimal))
        txtbx_Floatread.Text = IMEIPReadFloat(2).ToString
    End Sub

    Private Sub btn_EEIPIntWrite_Click(sender As Object, e As EventArgs) Handles btn_EEIPIntWrite.Click
        txtbx_EEIPIntRead.Text = IMEIPReadInt(9).ToString
        IMEIPWriteInt(9, CType(txtbx_EEIPIntWrite.Text, Integer))
        txtbx_DintRead.Text = IMEIPReadDInt(15).ToString
        IMEIPWriteDInt(10, CType(txtbx_DintWrite.Text, Int32))

    End Sub



    Private Sub btn_DM300_on_Click(sender As Object, e As EventArgs) Handles btn_DM300_on.Click
        IMEIPWriteBoolean(0, 1, True)
        IMEIPWriteBoolean(0, 6, True)

    End Sub

    Private Sub btn_DM300_off_Click(sender As Object, e As EventArgs) Handles btn_DM300_off.Click
        IMEIPWriteBoolean(0, 1, False)
        IMEIPWriteBoolean(0, 2, True)
        If IMEIPReadBoolean(0, 2) = True Then
            lbl_DM350_2.BackColor = Color.Green
        Else
            lbl_DM350_2.BackColor = Color.Red
        End If
    End Sub
End Class
