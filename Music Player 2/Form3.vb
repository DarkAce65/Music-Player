Public Class Form3

    Private Sub Form3_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Dim Border As New Drawing2D.GraphicsPath()
        Border.StartFigure()
        Border.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        Border.AddLine(20, 0, Me.Width - 20, 0)
        Border.AddArc(New Rectangle(Me.Width - 20, 0, 20, 20), -90, 90)
        Border.AddLine(Me.Width, 20, Me.Width, Me.Height - 20)
        Border.AddArc(New Rectangle(Me.Width - 20, Me.Height - 20, 20, 20), 0, 90)
        Border.AddLine(Me.Width - 20, Me.Height, 20, Me.Height)
        Border.AddArc(New Rectangle(0, Me.Height - 20, 20, 20), 90, 90)
        Border.CloseFigure()
        Me.Region = New Region(Border)
        Label4.Text = My.Application.Info.Copyright
        Label4.Location = New Point(Me.Size.Width - (Label4.Width + 12), 85)
        Label3.Text = "v. " + My.Application.Deployment.CurrentVersion.ToString
        Label3.Location = New Point(Me.Size.Width - (Label3.Width + 12), 67)
    End Sub
End Class