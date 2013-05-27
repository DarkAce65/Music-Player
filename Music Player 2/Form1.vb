Public Class Form1
    Dim Title_Current As String
    Dim Artist_Current As String
    Dim Duration_Current As String
    Dim Title As String
    Dim Artist As String
    Dim Duration As String
    Dim Index_Number As Integer
    Dim Import_Select As String
    Dim Current_User As String
    Dim Next_Delete As String

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form2.Cancel.PerformClick()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Enabled = False
        Form2.Hide()
        For A As Single = 100 To 0 Step -1
            Me.Opacity = A / 100
            Me.Refresh()
            Threading.Thread.Sleep(10)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Current_User = SystemInformation.UserName
        Auto_Play.Checked = True
        Move_Down.Enabled = False
        Move_Up.Enabled = False
        Me.Text = "Media Player by Taha Vasowalla " + Today
        Me.BackColor = Drawing.Color.Silver
        ListBox1.BackColor = Drawing.Color.Silver
        ListBox2.BackColor = Drawing.Color.Silver
        Form2.BackColor = Drawing.Color.Silver
        Label1.Text = "Media Player"
        AcceptButton = Play_Song
        AxWindowsMediaPlayer1.settings.volume = 100
        AxWindowsMediaPlayer1.settings.autoStart = True
        AxWindowsMediaPlayer2.settings.volume = 0
        OpenFileDialog1.Multiselect = True
        FolderBrowserDialog1.ShowNewFolderButton = False
        If My.Computer.FileSystem.DirectoryExists("C:\Users\" + Current_User + "\Documents\Media Player Library") = False Then
            My.Computer.FileSystem.CreateDirectory("C:\Users\" + Current_User + "\Documents\Media Player Library")
        End If
        My.Computer.FileSystem.CurrentDirectory = "C:\Users\" + Current_User + "\Documents\Media Player Library"
        For Each Path As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.CurrentDirectory, FileIO.SearchOption.SearchAllSubDirectories, "*.mp3", "*.wav", "*.wmv")
            ListBox1.Items.Add(My.Computer.FileSystem.GetFileInfo(Path).Name)
        Next
        ListBox1.Sorted = True
        For A As Single = 0 To 99 Step 3
            Me.Opacity = A / 100
            Me.Refresh()
        Next
        Me.Opacity = 1
        Me.Focus()
    End Sub

    Private Sub Play_Song_Click(sender As System.Object, e As System.EventArgs) Handles Play_Song.Click
        If ListBox1.SelectedItem <> "" Then
            ListBox2.Items.Clear()
            ListBox2.Items.Add(ListBox1.SelectedItem)
            If My.Computer.FileSystem.FileExists("C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox1.SelectedItem.ToString) = True Then
                Me.AxWindowsMediaPlayer1.URL = "C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox1.SelectedItem.ToString
            End If
        End If
        If ListBox2.SelectedItem <> "" Then
            If My.Computer.FileSystem.FileExists("C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox2.SelectedItem.ToString) = True Then
                Me.AxWindowsMediaPlayer1.URL = "C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox2.SelectedItem.ToString
            End If
        End If
    End Sub

    Private Sub Close_Player_Click(sender As System.Object, e As System.EventArgs) Handles Close_Player.Click
        Cursor.Current = Cursors.Default
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer2.Ctlcontrols.stop()
        Me.Close()
    End Sub

    Private Sub Import_Folder_Click(sender As System.Object, e As System.EventArgs) Handles Import_Folder.Click
        Form2.ProgressBar1.Maximum = 0
        FolderBrowserDialog1.SelectedPath = Nothing
        Form2.ProgressBar1.Value = 0
        Import.Enabled = False
        Import_Folder.Enabled = False
        Clear_Library.Enabled = False
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.CurrentDirectory = FolderBrowserDialog1.SelectedPath
            Try
                For Each File As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.CurrentDirectory, FileIO.SearchOption.SearchAllSubDirectories, "*.mp3", "*.wav", "*.wmv")
                    Form2.ProgressBar1.Maximum += 1
                Next
                If BackgroundWorker1.IsBusy = False Then
                    Form2.Show()
                    BackgroundWorker1.RunWorkerAsync()
                End If
            Catch ex As Exception
                Form2.ProgressBar1.Value = 0
                Form2.Hide()
                MsgBox("Access to this folder or subfolder is denied.", MsgBoxStyle.Exclamation, "Error")
                Import_Folder.Enabled = True
                Import_Folder.PerformClick()
            End Try
        Else
            Import.Enabled = True
            Import_Folder.Enabled = True
            Clear_Library.Enabled = True
        End If
    End Sub

    Private Sub Import_Click(sender As System.Object, e As System.EventArgs) Handles Import.Click
        Import.Enabled = False
        Import_Folder.Enabled = False
        Clear_Library.Enabled = False
        Form2.ProgressBar1.Maximum = 0
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each File As String In OpenFileDialog1.FileNames
                Form2.ProgressBar1.Maximum += 1
            Next
            If Form2.ProgressBar1.Maximum = 1 Then
                Import_Select = OpenFileDialog1.SafeFileName
            End If
            Form2.Show()
            BackgroundWorker2.RunWorkerAsync()
        Else
            Import.Enabled = True
            Import_Folder.Enabled = True
            Clear_Library.Enabled = True
        End If
    End Sub

    Private Sub Clear_Library_Click(sender As System.Object, e As System.EventArgs) Handles Clear_Library.Click
        Move_Down.Enabled = False
        Move_Up.Enabled = False
        Cursor.Current = Cursors.WaitCursor
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer2.Ctlcontrols.stop()
        For Each DeleteFile As String In My.Computer.FileSystem.GetFiles("C:\Users\" + Current_User + "\Documents\Media Player Library\", FileIO.SearchOption.SearchAllSubDirectories, "*.mp3", "*.wav", "*.wmv")
            My.Computer.FileSystem.DeleteFile(DeleteFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Next
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        Me.Refresh()
        Label1.Text = "Media Player"
        Label2.Text = ""
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As System.EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedItem <> "" Then
            ListBox2.Items.Clear()
            If My.Computer.FileSystem.FileExists("C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox1.SelectedItem.ToString) = True Then
                Me.AxWindowsMediaPlayer1.URL = "C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox1.SelectedItem.ToString
            End If
            ListBox2.Items.Add(ListBox1.SelectedItem)
        End If
    End Sub

    Private Sub ListBox1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ListBox1.SelectedIndex = ListBox1.IndexFromPoint(e.Location)
            If ListBox1.SelectedItem <> "" Then
                ContextMenuStrip1.Show(ListBox1, e.Location)
            End If
        End If
    End Sub

    Private Sub ListBox2_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListBox2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ListBox2.SelectedIndex = ListBox2.IndexFromPoint(e.Location)
            If ListBox2.SelectedItem <> "" Then
                ContextMenuStrip2.Show(ListBox2, e.Location)
            End If
        End If
    End Sub

    Private Sub ListBox1_MouseHover(sender As Object, e As System.EventArgs) Handles ListBox1.MouseHover
        ListBox1.Focus()
    End Sub

    Private Sub Listbox1_MouseLeave(sender As Object, e As System.EventArgs) Handles ListBox1.MouseLeave
        Me.Focus()
    End Sub

    Private Sub ListBox1_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ListBox1.SelectedValueChanged
        If ListBox1.SelectedItem <> "" Then
            Move_Down.Enabled = False
            Move_Up.Enabled = False
            ListBox2.SelectedItem = Nothing
        End If
        If ListBox1.SelectedItem <> "" Then
            If My.Computer.FileSystem.FileExists("C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox1.SelectedItem.ToString) = True Then
                Me.AxWindowsMediaPlayer2.URL = "C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox1.SelectedItem.ToString
            End If
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_DoubleClickEvent(sender As Object, e As AxWMPLib._WMPOCXEvents_DoubleClickEvent) Handles AxWindowsMediaPlayer1.DoubleClickEvent
        Try
            AxWindowsMediaPlayer1.fullScreen = Not AxWindowsMediaPlayer1.fullScreen
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AxWindowsMediaPlayer1_MediaChange(sender As Object, e As AxWMPLib._WMPOCXEvents_MediaChangeEvent) Handles AxWindowsMediaPlayer1.MediaChange
        Title_Current = AxWindowsMediaPlayer1.currentMedia.getItemInfo("Title")
        Artist_Current = AxWindowsMediaPlayer1.currentMedia.getItemInfo("Artist")
        Duration_Current = AxWindowsMediaPlayer1.currentMedia.durationString
        If Artist <> "" Then
            Label1.Text = Chr(39) + Title_Current + Chr(39) + " by " + Artist_Current + "   " + "(" + Duration_Current + ")"
        Else
            Label1.Text = Chr(39) + Title_Current + Chr(39) + "   " + "(" + Duration_Current + ")"
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer2_MediaChange(sender As Object, e As AxWMPLib._WMPOCXEvents_MediaChangeEvent) Handles AxWindowsMediaPlayer2.MediaChange
        AxWindowsMediaPlayer2.Ctlcontrols.pause()
        Artist = AxWindowsMediaPlayer2.currentMedia.getItemInfo("Artist")
        Duration = AxWindowsMediaPlayer2.currentMedia.durationString
        Title = AxWindowsMediaPlayer2.currentMedia.getItemInfo("Title")
        If Not ListBox2.SelectedItem <> "" Then
            If Artist <> "" Then
                Label2.Text = Chr(39) + Title + Chr(39) + " by " + Artist + "   " + "(" + Duration + ")"
            Else
                Label2.Text = Chr(39) + Title + Chr(39) + "   " + "(" + Duration + ")"
            End If
        End If
    End Sub

    Private Sub Color_Click(sender As System.Object, e As System.EventArgs) Handles Color.Click
        ColorDialog1.Color = Me.BackColor
        ColorDialog1.ShowDialog()
        Me.BackColor = ColorDialog1.Color
        ListBox1.BackColor = ColorDialog1.Color
        ListBox2.BackColor = ColorDialog1.Color
        Form2.BackColor = ColorDialog1.Color
        If ColorDialog1.Color.GetBrightness <= (1 / 3) Then
            Form2.Label1.ForeColor = Drawing.Color.White
            Label1.ForeColor = Drawing.Color.White
            Label2.ForeColor = Drawing.Color.White
            Label3.ForeColor = Drawing.Color.White
            ListBox1.ForeColor = Drawing.Color.White
            ListBox2.ForeColor = Drawing.Color.White
            Auto_Play.ForeColor = Drawing.Color.White
        Else
            Form2.Label1.ForeColor = Drawing.Color.Black
            Label1.ForeColor = Drawing.Color.Black
            Label2.ForeColor = Drawing.Color.Black
            Label3.ForeColor = Drawing.Color.Black
            ListBox1.ForeColor = Drawing.Color.Black
            ListBox2.ForeColor = Drawing.Color.Black
            Auto_Play.ForeColor = Drawing.Color.Black
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Cursor.Current = Cursors.WaitCursor
        Try
            For Each Path As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.CurrentDirectory, FileIO.SearchOption.SearchAllSubDirectories, "*.mp3", "*.wav", "*.wmv")
                If BackgroundWorker1.CancellationPending = True Then
                    Exit Try
                End If
                If My.Computer.FileSystem.FileExists("C:\Users\" + Current_User + "\Documents\Media Player Library\" + My.Computer.FileSystem.GetFileInfo(Path).Name) = False Then
                    My.Computer.FileSystem.CopyFile(Path, "C:\Users\" + Current_User + "\Documents\Media Player Library\" + My.Computer.FileSystem.GetFileInfo(Path).Name)
                End If
                BackgroundWorker1.ReportProgress(0, Path)
            Next
        Catch ex As Exception
            MsgBox("Import Failed." + vbNewLine + ex.ToString, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Cursor.Current = Cursors.WaitCursor
        Try
            For Each Path As String In OpenFileDialog1.FileNames
                If BackgroundWorker1.CancellationPending = True Then
                    Exit Try
                End If
                If My.Computer.FileSystem.FileExists("C:\Users\" + Current_User + "\Documents\Media Player Library\" + My.Computer.FileSystem.GetName(Path)) = False Then
                    My.Computer.FileSystem.CopyFile(Path, "C:\Users\" + Current_User + "\Documents\Media Player Library\" + My.Computer.FileSystem.GetName(Path))
                End If
                BackgroundWorker2.ReportProgress(0, Path)
            Next
        Catch ex As Exception
            MsgBox("Import Failed." + vbNewLine + ex.ToString, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub Backgroundworker2_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        Dim Path As String = CStr(e.UserState)
        Form2.Label1.Text = My.Computer.FileSystem.GetFileInfo(Path).Name
        If ListBox1.Items.Contains(My.Computer.FileSystem.GetFileInfo(Path).Name) = False Then
            ListBox1.Items.Add(My.Computer.FileSystem.GetFileInfo(Path).Name)
        End If
        Form2.ProgressBar1.Increment(1)
        Form2.Refresh()
        Form2.Label1.Text = My.Computer.FileSystem.GetFileInfo(Path).Name
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim Path As String = CStr(e.UserState)
        Form2.Label1.Text = My.Computer.FileSystem.GetFileInfo(Path).Name
        If ListBox1.Items.Contains(My.Computer.FileSystem.GetFileInfo(Path).Name) = False Then
            ListBox1.Items.Add(My.Computer.FileSystem.GetFileInfo(Path).Name)
        End If
        Form2.ProgressBar1.Increment(1)
        Form2.Refresh()
        Form2.Label1.Text = My.Computer.FileSystem.GetFileInfo(Path).Name
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Cursor.Current = Cursors.Default
        ListBox1.Sorted = True
        Form2.ProgressBar1.Maximum = 0
        Form2.ProgressBar1.Value = 0
        Form2.Hide()
        AxWindowsMediaPlayer1.Refresh()
        Import.Enabled = True
        Import_Folder.Enabled = True
        Clear_Library.Enabled = True
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Cursor.Current = Cursors.Default
        ListBox1.Sorted = True
        If Import_Select <> "" Then
            ListBox1.SelectedItem = Import_Select
        End If
        Form2.ProgressBar1.Maximum = 0
        Form2.ProgressBar1.Value = 0
        Form2.Hide()
        AxWindowsMediaPlayer1.Refresh()
        Import.Enabled = True
        Import_Folder.Enabled = True
        Clear_Library.Enabled = True
    End Sub

    Private Sub ListBox2_DoubleClick(sender As Object, e As System.EventArgs) Handles ListBox2.DoubleClick
        If ListBox2.SelectedItem <> "" Then
            If My.Computer.FileSystem.FileExists("C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox2.SelectedItem.ToString) = True Then
                Me.AxWindowsMediaPlayer1.URL = "C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox2.SelectedItem.ToString
            End If
        End If
    End Sub

    Private Sub ListBox2_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ListBox2.SelectedValueChanged
        If ListBox2.SelectedItem <> "" Then
            ListBox1.SelectedItem = Nothing
            Move_Up.Enabled = True
            Move_Down.Enabled = True
            Label2.Text = ""
        End If
    End Sub

    Private Sub ContextMenuStrip1_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        If e.ClickedItem.ToString = "Add to Playlist" Then
            If ListBox1.SelectedItem <> "" And ListBox2.Items.Contains(ListBox1.SelectedItem) = False Then
                ListBox2.Items.Add(ListBox1.SelectedItem)
            End If
        End If
        If e.ClickedItem.ToString = "Play Next" Then
            Try
                If AxWindowsMediaPlayer1.currentMedia.sourceURL <> "" And ListBox2.Items.Count > 0 Then
                    Index_Number = ListBox2.Items.IndexOf(Replace(AxWindowsMediaPlayer1.currentMedia.sourceURL, "C:\Users\" + Current_User + "\Documents\Media Player Library\", "")) + 1
                    If ListBox1.SelectedItem <> "" And ListBox2.Items.Contains(ListBox1.SelectedItem) = False Then
                        ListBox2.Items.Insert(Index_Number, ListBox1.SelectedItem)
                    End If
                End If
            Catch ex As Exception
                If ListBox1.SelectedItem <> "" And ListBox2.Items.Contains(ListBox1.SelectedItem) = False Then
                    ListBox2.Items.Add(ListBox1.SelectedItem)
                End If
            End Try
        End If
    End Sub

    Private Sub ContextMenuStrip2_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip2.ItemClicked
        If e.ClickedItem.ToString = "Remove from Playlist" Then
            If ListBox2.SelectedItem <> "" Then
                Next_Delete = ListBox2.SelectedIndex
                If ListBox2.Items.Count = 1 Then
                    ListBox2.Items.Clear()
                    AxWindowsMediaPlayer1.Ctlcontrols.stop()
                    Label1.Text = "Media Player"
                Else
                    If ListBox2.SelectedItem = Replace(AxWindowsMediaPlayer1.currentMedia.sourceURL, "C:\Users\" + Current_User + "\Documents\Media Player Library\", "") Then
                        AxWindowsMediaPlayer1.Ctlcontrols.stop()
                        Try
                            ListBox2.SelectedIndex = Next_Delete + 1
                        Catch ex As Exception
                            ListBox2.SelectedIndex = 0
                        End Try
                        Me.AxWindowsMediaPlayer1.URL = "C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox2.SelectedItem
                    End If
                    ListBox2.SelectedIndex = Next_Delete
                    ListBox2.Items.Remove(ListBox2.SelectedItem)
                End If
            End If
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
        If e.newState = 8 And ListBox2.Items.Count > 0 And Auto_Play.Checked = True Then
            If ListBox2.Items.IndexOf(Replace(AxWindowsMediaPlayer1.currentMedia.sourceURL, "C:\Users\" + Current_User + "\Documents\Media Player Library\", "")) + 2 > ListBox2.Items.Count Then
                ListBox2.SelectedIndex = 0
            Else
                ListBox2.SelectedIndex = ListBox2.Items.IndexOf(Replace(AxWindowsMediaPlayer1.currentMedia.sourceURL, "C:\Users\" + Current_User + "\Documents\Media Player Library\", "")) + 1
            End If
            Me.AxWindowsMediaPlayer1.URL = "C:\Users\" + Current_User + "\Documents\Media Player Library\" + ListBox2.SelectedItem
            BackgroundWorker3.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        System.Threading.Thread.Sleep(200)
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    Private Sub Clear_Playlist_Click(sender As Object, e As System.EventArgs) Handles Clear_Playlist.Click
        Move_Down.Enabled = False
        Move_Up.Enabled = False
        Label1.Text = "Media Player"
        ListBox2.Items.Clear()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub

    Private Sub Shuffle_Click(sender As Object, e As System.EventArgs) Handles Shuffle.Click
        Dim Selected_Media As String
        Dim Shuffled_Index As Integer
        Dim Shuffle_Playlist As New Collection
        If ListBox2.SelectedItem <> "" Then
            Selected_Media = ListBox2.SelectedItem
        Else
            Selected_Media = Nothing
        End If
        ListBox2.BeginUpdate()
        For Initial_Index As Integer = 0 To (ListBox2.Items.Count - 1)
            Shuffle_Playlist.Add(ListBox2.Items.Item(Initial_Index))
        Next
        ListBox2.Items.Clear()
        Do While Shuffle_Playlist.Count
            Randomize()
            Shuffled_Index = Int((Shuffle_Playlist.Count * Rnd()) + 1)
            ListBox2.Items.Add(Shuffle_Playlist(Shuffled_Index))
            Shuffle_Playlist.Remove(Shuffled_Index)
        Loop
        ListBox2.EndUpdate()
        If Not Selected_Media = Nothing Then
            ListBox2.SelectedItem = Selected_Media
        End If
    End Sub

    Private Sub Move_Up_Click(sender As Object, e As System.EventArgs) Handles Move_Up.Click
        If ListBox2.SelectedIndex > 0 Then
            Dim New_Index = ListBox2.SelectedIndex - 1
            ListBox2.Items.Insert(New_Index, ListBox2.SelectedItem)
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
            ListBox2.SelectedIndex = New_Index
        End If
    End Sub

    Private Sub Move_Down_Click(sender As Object, e As System.EventArgs) Handles Move_Down.Click
        If ListBox2.SelectedIndex < ListBox2.Items.Count - 1 Then
            Dim New_Index = ListBox2.SelectedIndex + 2
            ListBox2.Items.Insert(New_Index, ListBox2.SelectedItem)
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
            ListBox2.SelectedIndex = New_Index - 1
        End If
    End Sub

    Private Sub Mini_Player_Click(sender As Object, e As System.EventArgs) Handles Mini_Player.Click
        If Close_Player.Visible = True Then
            For Each Ctrl As Control In Me.Controls
                Ctrl.Visible = False
            Next
            Label1.Visible = True
            AxWindowsMediaPlayer1.Visible = True
            Mini_Player.Visible = True
            AxWindowsMediaPlayer1.Height = 45
            Mini_Player.Location = New Point(6, 73)
            Mini_Player.Size = New Size(200, 25)
            Mini_Player.Text = "Switch to Full-Player"
            Me.Refresh()
        Else
            For Each Ctrl As Control In Me.Controls
                Ctrl.Visible = True
            Next
            AxWindowsMediaPlayer2.Visible = False
            AxWindowsMediaPlayer1.Height = 228
            Mini_Player.Location = New Point(316, 328)
            Mini_Player.Size = New Size(100, 50)
            Mini_Player.Text = "Switch to Mini-Player"
            Me.Refresh()
        End If
    End Sub
End Class
