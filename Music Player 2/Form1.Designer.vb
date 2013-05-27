<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Play_Song = New System.Windows.Forms.Button()
        Me.Import = New System.Windows.Forms.Button()
        Me.Import_Folder = New System.Windows.Forms.Button()
        Me.Clear_Library = New System.Windows.Forms.Button()
        Me.Close_Player = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Color = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveFromPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
        Me.Clear_Playlist = New System.Windows.Forms.Button()
        Me.Auto_Play = New System.Windows.Forms.CheckBox()
        Me.Shuffle = New System.Windows.Forms.Button()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.AxWindowsMediaPlayer2 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.Move_Up = New System.Windows.Forms.Button()
        Me.Move_Down = New System.Windows.Forms.Button()
        Me.Mini_Player = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Play_Song
        '
        Me.Play_Song.BackColor = System.Drawing.SystemColors.Control
        Me.Play_Song.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Play_Song, "Play_Song")
        Me.Play_Song.Name = "Play_Song"
        Me.Play_Song.UseVisualStyleBackColor = False
        '
        'Import
        '
        Me.Import.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Import, "Import")
        Me.Import.Name = "Import"
        Me.Import.UseVisualStyleBackColor = True
        '
        'Import_Folder
        '
        Me.Import_Folder.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Import_Folder, "Import_Folder")
        Me.Import_Folder.Name = "Import_Folder"
        Me.Import_Folder.UseVisualStyleBackColor = True
        '
        'Clear_Library
        '
        Me.Clear_Library.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Clear_Library, "Clear_Library")
        Me.Clear_Library.Name = "Clear_Library"
        Me.Clear_Library.UseVisualStyleBackColor = True
        '
        'Close_Player
        '
        Me.Close_Player.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Close_Player, "Close_Player")
        Me.Close_Player.Name = "Close_Player"
        Me.Close_Player.UseVisualStyleBackColor = True
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.ListBox1, "ListBox1")
        Me.ListBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Name = "ListBox1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.AddToPlaylistToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'AddToPlaylistToolStripMenuItem
        '
        Me.AddToPlaylistToolStripMenuItem.Name = "AddToPlaylistToolStripMenuItem"
        resources.ApplyResources(Me.AddToPlaylistToolStripMenuItem, "AddToPlaylistToolStripMenuItem")
        '
        'OpenFileDialog1
        '
        resources.ApplyResources(Me.OpenFileDialog1, "OpenFileDialog1")
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'FolderBrowserDialog1
        '
        resources.ApplyResources(Me.FolderBrowserDialog1, "FolderBrowserDialog1")
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.UserProfile
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Color
        '
        Me.Color.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Color, "Color")
        Me.Color.Name = "Color"
        Me.Color.UseVisualStyleBackColor = True
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.FullOpen = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.ListBox2, "ListBox2")
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Name = "ListBox2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveFromPlaylistToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        resources.ApplyResources(Me.ContextMenuStrip2, "ContextMenuStrip2")
        '
        'RemoveFromPlaylistToolStripMenuItem
        '
        Me.RemoveFromPlaylistToolStripMenuItem.Name = "RemoveFromPlaylistToolStripMenuItem"
        resources.ApplyResources(Me.RemoveFromPlaylistToolStripMenuItem, "RemoveFromPlaylistToolStripMenuItem")
        '
        'BackgroundWorker3
        '
        '
        'Clear_Playlist
        '
        Me.Clear_Playlist.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Clear_Playlist, "Clear_Playlist")
        Me.Clear_Playlist.Name = "Clear_Playlist"
        Me.Clear_Playlist.UseVisualStyleBackColor = True
        '
        'Auto_Play
        '
        resources.ApplyResources(Me.Auto_Play, "Auto_Play")
        Me.Auto_Play.BackColor = System.Drawing.Color.Transparent
        Me.Auto_Play.Name = "Auto_Play"
        Me.Auto_Play.UseVisualStyleBackColor = False
        '
        'Shuffle
        '
        Me.Shuffle.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Shuffle, "Shuffle")
        Me.Shuffle.Name = "Shuffle"
        Me.Shuffle.UseVisualStyleBackColor = True
        '
        'AxWindowsMediaPlayer1
        '
        resources.ApplyResources(Me.AxWindowsMediaPlayer1, "AxWindowsMediaPlayer1")
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'AxWindowsMediaPlayer2
        '
        resources.ApplyResources(Me.AxWindowsMediaPlayer2, "AxWindowsMediaPlayer2")
        Me.AxWindowsMediaPlayer2.Name = "AxWindowsMediaPlayer2"
        Me.AxWindowsMediaPlayer2.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer2.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'Move_Up
        '
        Me.Move_Up.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Move_Up, "Move_Up")
        Me.Move_Up.Name = "Move_Up"
        Me.Move_Up.UseVisualStyleBackColor = True
        '
        'Move_Down
        '
        Me.Move_Down.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Move_Down, "Move_Down")
        Me.Move_Down.Name = "Move_Down"
        Me.Move_Down.UseVisualStyleBackColor = True
        '
        'Mini_Player
        '
        Me.Mini_Player.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Mini_Player, "Mini_Player")
        Me.Mini_Player.Name = "Mini_Player"
        Me.Mini_Player.UseVisualStyleBackColor = True
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.Move_Down)
        Me.Controls.Add(Me.Move_Up)
        Me.Controls.Add(Me.Shuffle)
        Me.Controls.Add(Me.Auto_Play)
        Me.Controls.Add(Me.Mini_Player)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Clear_Playlist)
        Me.Controls.Add(Me.Play_Song)
        Me.Controls.Add(Me.AxWindowsMediaPlayer2)
        Me.Controls.Add(Me.Import_Folder)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Clear_Library)
        Me.Controls.Add(Me.Import)
        Me.Controls.Add(Me.Color)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Controls.Add(Me.Close_Player)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Play_Song As System.Windows.Forms.Button
    Friend WithEvents Import As System.Windows.Forms.Button
    Friend WithEvents Import_Folder As System.Windows.Forms.Button
    Friend WithEvents Clear_Library As System.Windows.Forms.Button
    Friend WithEvents Close_Player As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AxWindowsMediaPlayer2 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Color As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToPlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveFromPlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Clear_Playlist As System.Windows.Forms.Button
    Friend WithEvents Auto_Play As System.Windows.Forms.CheckBox
    Friend WithEvents Shuffle As System.Windows.Forms.Button
    Friend WithEvents Move_Up As System.Windows.Forms.Button
    Friend WithEvents Move_Down As System.Windows.Forms.Button
    Friend WithEvents Mini_Player As System.Windows.Forms.Button

End Class
