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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tp_prev = New System.Windows.Forms.Button()
        Me.tp_play = New System.Windows.Forms.Button()
        Me.tp_pause = New System.Windows.Forms.Button()
        Me.tp_stop = New System.Windows.Forms.Button()
        Me.tp_next = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.lblAlbum = New System.Windows.Forms.Label()
        Me.lblAlbumArtist = New System.Windows.Forms.Label()
        Me.pbTime = New System.Windows.Forms.ProgressBar()
        Me.lblcPos = New System.Windows.Forms.Label()
        Me.lblTrackNum = New System.Windows.Forms.Label()
        Me.lblArtist = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(475, 19)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(193, 61)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Initialize"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 17
        Me.ListBox1.Location = New System.Drawing.Point(292, 352)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(376, 259)
        Me.ListBox1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(475, 94)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(193, 61)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "GetData"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1020, 252)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(217, 76)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(15, 352)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(271, 264)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(160, 160)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1020, 484)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(217, 77)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'tp_prev
        '
        Me.tp_prev.Font = New System.Drawing.Font("Segoe UI Symbol", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_prev.Location = New System.Drawing.Point(12, 237)
        Me.tp_prev.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_prev.Name = "tp_prev"
        Me.tp_prev.Size = New System.Drawing.Size(78, 67)
        Me.tp_prev.TabIndex = 7
        Me.tp_prev.Text = "⏪"
        Me.tp_prev.UseVisualStyleBackColor = True
        '
        'tp_play
        '
        Me.tp_play.Font = New System.Drawing.Font("Segoe UI Symbol", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_play.Location = New System.Drawing.Point(182, 237)
        Me.tp_play.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_play.Name = "tp_play"
        Me.tp_play.Size = New System.Drawing.Size(78, 67)
        Me.tp_play.TabIndex = 8
        Me.tp_play.Text = "▶"
        Me.tp_play.UseVisualStyleBackColor = True
        '
        'tp_pause
        '
        Me.tp_pause.Font = New System.Drawing.Font("Segoe UI Symbol", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_pause.Location = New System.Drawing.Point(267, 237)
        Me.tp_pause.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_pause.Name = "tp_pause"
        Me.tp_pause.Size = New System.Drawing.Size(78, 67)
        Me.tp_pause.TabIndex = 9
        Me.tp_pause.Text = "❙❙"
        Me.tp_pause.UseVisualStyleBackColor = True
        '
        'tp_stop
        '
        Me.tp_stop.Font = New System.Drawing.Font("Segoe UI Symbol", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_stop.Location = New System.Drawing.Point(97, 237)
        Me.tp_stop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_stop.Name = "tp_stop"
        Me.tp_stop.Size = New System.Drawing.Size(78, 67)
        Me.tp_stop.TabIndex = 10
        Me.tp_stop.Text = "◼"
        Me.tp_stop.UseVisualStyleBackColor = True
        '
        'tp_next
        '
        Me.tp_next.Font = New System.Drawing.Font("Segoe UI Symbol", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tp_next.Location = New System.Drawing.Point(352, 237)
        Me.tp_next.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tp_next.Name = "tp_next"
        Me.tp_next.Size = New System.Drawing.Size(78, 67)
        Me.tp_next.TabIndex = 11
        Me.tp_next.Text = "⏩"
        Me.tp_next.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(190, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(240, 30)
        Me.lblTitle.TabIndex = 12
        Me.lblTitle.Text = "This is the song Track"
        '
        'lblDuration
        '
        Me.lblDuration.Location = New System.Drawing.Point(352, 192)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(78, 23)
        Me.lblDuration.TabIndex = 13
        Me.lblDuration.Text = "Label2"
        Me.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAlbum
        '
        Me.lblAlbum.AutoEllipsis = True
        Me.lblAlbum.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlbum.Location = New System.Drawing.Point(190, 47)
        Me.lblAlbum.Name = "lblAlbum"
        Me.lblAlbum.Size = New System.Drawing.Size(240, 30)
        Me.lblAlbum.TabIndex = 14
        Me.lblAlbum.Text = "AlbumName"
        '
        'lblAlbumArtist
        '
        Me.lblAlbumArtist.AutoEllipsis = True
        Me.lblAlbumArtist.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlbumArtist.Location = New System.Drawing.Point(190, 79)
        Me.lblAlbumArtist.Name = "lblAlbumArtist"
        Me.lblAlbumArtist.Size = New System.Drawing.Size(240, 30)
        Me.lblAlbumArtist.TabIndex = 15
        Me.lblAlbumArtist.Text = "Album Artist"
        '
        'pbTime
        '
        Me.pbTime.Location = New System.Drawing.Point(97, 192)
        Me.pbTime.Name = "pbTime"
        Me.pbTime.Size = New System.Drawing.Size(248, 23)
        Me.pbTime.TabIndex = 16
        '
        'lblcPos
        '
        Me.lblcPos.Location = New System.Drawing.Point(12, 192)
        Me.lblcPos.Name = "lblcPos"
        Me.lblcPos.Size = New System.Drawing.Size(78, 23)
        Me.lblcPos.TabIndex = 17
        Me.lblcPos.Text = "Label2"
        Me.lblcPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrackNum
        '
        Me.lblTrackNum.Location = New System.Drawing.Point(192, 153)
        Me.lblTrackNum.Name = "lblTrackNum"
        Me.lblTrackNum.Size = New System.Drawing.Size(153, 23)
        Me.lblTrackNum.TabIndex = 18
        Me.lblTrackNum.Text = "Track 10 of 99"
        Me.lblTrackNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblArtist
        '
        Me.lblArtist.AutoEllipsis = True
        Me.lblArtist.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtist.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblArtist.Location = New System.Drawing.Point(191, 113)
        Me.lblArtist.Name = "lblArtist"
        Me.lblArtist.Size = New System.Drawing.Size(240, 30)
        Me.lblArtist.TabIndex = 19
        Me.lblArtist.Text = "Artist"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1351, 1007)
        Me.Controls.Add(Me.lblArtist)
        Me.Controls.Add(Me.lblTrackNum)
        Me.Controls.Add(Me.lblcPos)
        Me.Controls.Add(Me.pbTime)
        Me.Controls.Add(Me.lblAlbumArtist)
        Me.Controls.Add(Me.lblAlbum)
        Me.Controls.Add(Me.lblDuration)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.tp_next)
        Me.Controls.Add(Me.tp_stop)
        Me.Controls.Add(Me.tp_pause)
        Me.Controls.Add(Me.tp_play)
        Me.Controls.Add(Me.tp_prev)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents tp_prev As System.Windows.Forms.Button
    Friend WithEvents tp_play As System.Windows.Forms.Button
    Friend WithEvents tp_pause As System.Windows.Forms.Button
    Friend WithEvents tp_stop As System.Windows.Forms.Button
    Friend WithEvents tp_next As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents lblAlbum As System.Windows.Forms.Label
    Friend WithEvents lblAlbumArtist As System.Windows.Forms.Label
    Friend WithEvents pbTime As System.Windows.Forms.ProgressBar
    Friend WithEvents lblcPos As System.Windows.Forms.Label
    Friend WithEvents lblTrackNum As System.Windows.Forms.Label
    Friend WithEvents lblArtist As System.Windows.Forms.Label

End Class
