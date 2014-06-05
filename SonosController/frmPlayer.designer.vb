<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlayer
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblArtist = New System.Windows.Forms.Label()
        Me.lblTrackNum = New System.Windows.Forms.Label()
        Me.lblcPos = New System.Windows.Forms.Label()
        Me.pbTime = New System.Windows.Forms.ProgressBar()
        Me.lblAlbumArtist = New System.Windows.Forms.Label()
        Me.lblAlbum = New System.Windows.Forms.Label()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tp_next = New System.Windows.Forms.Button()
        Me.tp_stop = New System.Windows.Forms.Button()
        Me.tp_pause = New System.Windows.Forms.Button()
        Me.tp_play = New System.Windows.Forms.Button()
        Me.tp_prev = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lstPlayers = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblArtist)
        Me.GroupBox1.Controls.Add(Me.lblTrackNum)
        Me.GroupBox1.Controls.Add(Me.lblcPos)
        Me.GroupBox1.Controls.Add(Me.pbTime)
        Me.GroupBox1.Controls.Add(Me.lblAlbumArtist)
        Me.GroupBox1.Controls.Add(Me.lblAlbum)
        Me.GroupBox1.Controls.Add(Me.lblDuration)
        Me.GroupBox1.Controls.Add(Me.lblTitle)
        Me.GroupBox1.Controls.Add(Me.tp_next)
        Me.GroupBox1.Controls.Add(Me.tp_stop)
        Me.GroupBox1.Controls.Add(Me.tp_pause)
        Me.GroupBox1.Controls.Add(Me.tp_play)
        Me.GroupBox1.Controls.Add(Me.tp_prev)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(456, 335)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sonos Controller"
        '
        'lblArtist
        '
        Me.lblArtist.AutoEllipsis = True
        Me.lblArtist.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtist.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblArtist.Location = New System.Drawing.Point(196, 122)
        Me.lblArtist.Name = "lblArtist"
        Me.lblArtist.Size = New System.Drawing.Size(240, 30)
        Me.lblArtist.TabIndex = 33
        Me.lblArtist.Text = "Artist"
        '
        'lblTrackNum
        '
        Me.lblTrackNum.Location = New System.Drawing.Point(197, 162)
        Me.lblTrackNum.Name = "lblTrackNum"
        Me.lblTrackNum.Size = New System.Drawing.Size(153, 23)
        Me.lblTrackNum.TabIndex = 32
        Me.lblTrackNum.Text = "Track 10 of 99"
        Me.lblTrackNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblcPos
        '
        Me.lblcPos.Location = New System.Drawing.Point(17, 201)
        Me.lblcPos.Name = "lblcPos"
        Me.lblcPos.Size = New System.Drawing.Size(78, 23)
        Me.lblcPos.TabIndex = 31
        Me.lblcPos.Text = "Label2"
        Me.lblcPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbTime
        '
        Me.pbTime.Location = New System.Drawing.Point(102, 201)
        Me.pbTime.Name = "pbTime"
        Me.pbTime.Size = New System.Drawing.Size(248, 23)
        Me.pbTime.TabIndex = 30
        '
        'lblAlbumArtist
        '
        Me.lblAlbumArtist.AutoEllipsis = True
        Me.lblAlbumArtist.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlbumArtist.Location = New System.Drawing.Point(195, 88)
        Me.lblAlbumArtist.Name = "lblAlbumArtist"
        Me.lblAlbumArtist.Size = New System.Drawing.Size(240, 30)
        Me.lblAlbumArtist.TabIndex = 29
        Me.lblAlbumArtist.Text = "Album Artist"
        '
        'lblAlbum
        '
        Me.lblAlbum.AutoEllipsis = True
        Me.lblAlbum.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlbum.Location = New System.Drawing.Point(195, 56)
        Me.lblAlbum.Name = "lblAlbum"
        Me.lblAlbum.Size = New System.Drawing.Size(240, 30)
        Me.lblAlbum.TabIndex = 28
        Me.lblAlbum.Text = "AlbumName"
        '
        'lblDuration
        '
        Me.lblDuration.Location = New System.Drawing.Point(357, 201)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(78, 23)
        Me.lblDuration.TabIndex = 27
        Me.lblDuration.Text = "Label2"
        Me.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitle
        '
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(195, 25)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(240, 30)
        Me.lblTitle.TabIndex = 26
        Me.lblTitle.Text = "This is the song Track"
        '
        'tp_next
        '
        Me.tp_next.Font = New System.Drawing.Font("Segoe UI Symbol", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_next.Location = New System.Drawing.Point(357, 246)
        Me.tp_next.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_next.Name = "tp_next"
        Me.tp_next.Size = New System.Drawing.Size(78, 67)
        Me.tp_next.TabIndex = 25
        Me.tp_next.Text = "⏩"
        Me.tp_next.UseVisualStyleBackColor = True
        '
        'tp_stop
        '
        Me.tp_stop.Font = New System.Drawing.Font("Segoe UI Symbol", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_stop.Location = New System.Drawing.Point(102, 246)
        Me.tp_stop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_stop.Name = "tp_stop"
        Me.tp_stop.Size = New System.Drawing.Size(78, 67)
        Me.tp_stop.TabIndex = 24
        Me.tp_stop.Text = "◼"
        Me.tp_stop.UseVisualStyleBackColor = True
        '
        'tp_pause
        '
        Me.tp_pause.Font = New System.Drawing.Font("Segoe UI Symbol", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_pause.Location = New System.Drawing.Point(272, 246)
        Me.tp_pause.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_pause.Name = "tp_pause"
        Me.tp_pause.Size = New System.Drawing.Size(78, 67)
        Me.tp_pause.TabIndex = 23
        Me.tp_pause.Text = "❙❙"
        Me.tp_pause.UseVisualStyleBackColor = True
        '
        'tp_play
        '
        Me.tp_play.Font = New System.Drawing.Font("Segoe UI Symbol", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_play.Location = New System.Drawing.Point(187, 246)
        Me.tp_play.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_play.Name = "tp_play"
        Me.tp_play.Size = New System.Drawing.Size(78, 67)
        Me.tp_play.TabIndex = 22
        Me.tp_play.Text = "▶"
        Me.tp_play.UseVisualStyleBackColor = True
        '
        'tp_prev
        '
        Me.tp_prev.Font = New System.Drawing.Font("Segoe UI Symbol", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_prev.Location = New System.Drawing.Point(17, 246)
        Me.tp_prev.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_prev.Name = "tp_prev"
        Me.tp_prev.Size = New System.Drawing.Size(78, 67)
        Me.tp_prev.TabIndex = 21
        Me.tp_prev.Text = "⏪"
        Me.tp_prev.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(17, 25)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(160, 160)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 20
        Me.PictureBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(475, 29)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 58)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Initialize"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 364)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(599, 30)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(184, 25)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'lstPlayers
        '
        Me.lstPlayers.FormattingEnabled = True
        Me.lstPlayers.ItemHeight = 28
        Me.lstPlayers.Location = New System.Drawing.Point(479, 105)
        Me.lstPlayers.Name = "lstPlayers"
        Me.lstPlayers.Size = New System.Drawing.Size(105, 228)
        Me.lstPlayers.TabIndex = 3
        '
        'frmPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 394)
        Me.Controls.Add(Me.lstPlayers)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPlayer"
        Me.Text = "frmPlayer"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblArtist As System.Windows.Forms.Label
    Friend WithEvents lblTrackNum As System.Windows.Forms.Label
    Friend WithEvents lblcPos As System.Windows.Forms.Label
    Friend WithEvents pbTime As System.Windows.Forms.ProgressBar
    Friend WithEvents lblAlbumArtist As System.Windows.Forms.Label
    Friend WithEvents lblAlbum As System.Windows.Forms.Label
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents tp_next As System.Windows.Forms.Button
    Friend WithEvents tp_stop As System.Windows.Forms.Button
    Friend WithEvents tp_pause As System.Windows.Forms.Button
    Friend WithEvents tp_play As System.Windows.Forms.Button
    Friend WithEvents tp_prev As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lstPlayers As System.Windows.Forms.ListBox
End Class
