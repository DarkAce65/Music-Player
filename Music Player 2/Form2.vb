Public Class Form2
    Private Sub Form2_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        For A As Single = 0 To 100 Step 2
            Me.Opacity = A / 100
            Me.Refresh()
        Next
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Computer.Audio.Play("C:\Windows\Media\Windows Print complete.wav", AudioPlayMode.Background)
        For A As Single = 100 To 0 Step -2
            Me.Opacity = A / 100
            Me.Refresh()
        Next
    End Sub

    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cancel.Click
        Form1.BackgroundWorker1.CancelAsync()
        Form1.BackgroundWorker2.CancelAsync()
    End Sub

    Private Sub Form2_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SetDesktopLocation(My.Computer.Screen.WorkingArea.Width - (Me.Width + 6), My.Computer.Screen.WorkingArea.Height - (Me.Height + 6))
    End Sub
End Class