Public Class frmPlayer
    'Private WithEvents player As New clsPlayer("uuid:RINCON_000E58A72F9601400")
    Private WithEvents sonos As New clsSonos
    Private WithEvents player As clsPlayer
    Private Delegate Sub TrackPositionDelegate(trackData As clsTrack)
    Dim myDelegate1 As New TrackPositionDelegate(AddressOf Me.UpdateTrackPosition)

    Private Delegate Sub TrackDataDelegate(trackData As clsTrack)
    Dim myDelegate2 As New TrackDataDelegate(AddressOf Me.UpdateTrackData)


    Private Sub player_trackDataChange(Message As String, trackData As clsTrack) Handles player.trackDataChange
        'updateGUI()
        Debug.Print("FRMPLAYER " & Message)
        Select Case Message
            Case "Song Position"
                'If Me.InvokeRequired Then
                Me.Invoke(myDelegate1, trackData)
                'End If
            Case Else
                'If Me.InvokeRequired Then
                Me.Invoke(myDelegate2, trackData)
                'End If
        End Select
        'myDelegate.DynamicInvoke(trackData)


        'CheckProgress(trackData)
    End Sub

    Sub UpdateTrackPosition(trackData As clsTrack)
        Try
            lblDuration.Text = trackData.TrackDuration.ToString
            lblcPos.Text = trackData.TrackPosition.ToString
            pbTime.Value = trackData.TrackCompletion

        Catch ex As Exception
            Debug.Print("frmPlayer Error" & ex.Message)
        End Try

    End Sub

    Sub UpdateTrackData(trackdata As clsTrack)
        lblAlbumArtist.Text = trackdata.AlbumArtist
        lblAlbum.Text = trackdata.Album
        lblArtist.Text = trackdata.Artist
        If lblArtist.Text = lblAlbumArtist.Text Then lblArtist.Text = ""
        lblTitle.Text = trackdata.Title
        Dim imgLink As String = trackdata.AlbumArt.OriginalString
        If Not (imgLink Is Nothing) Then
            PictureBox2.ImageLocation = imgLink
        End If
        lblTrackNum.Text = String.Format("track {0} of {1}", trackdata.TrackNumber, trackdata.AlbumTrackCount)
        UpdateTrackPosition(trackdata)
    End Sub

    Private Sub tp_prev_Click(sender As System.Object, e As System.EventArgs) Handles tp_prev.Click
        player.Prev()
    End Sub

    Private Sub tp_stop_Click(sender As System.Object, e As System.EventArgs) Handles tp_stop.Click
        player.Stop()
    End Sub

    Private Sub tp_play_Click(sender As System.Object, e As System.EventArgs) Handles tp_play.Click
        player.Play()
    End Sub

    Private Sub tp_pause_Click(sender As System.Object, e As System.EventArgs) Handles tp_pause.Click
        player.Pause()
    End Sub

    Private Sub tp_next_Click(sender As System.Object, e As System.EventArgs) Handles tp_next.Click
        player.Next()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If lstPlayers.SelectedIndex = -1 Then
            MsgBox("You must select a player")
        End If
        Dim playerID = lstPlayers.SelectedItem
        player = New clsPlayer(playerID)

    End Sub

    Private Sub sonos_DevicesFound(deviceID As String) Handles sonos.DevicesFound
        lstPlayers.Items.Add(deviceID)
        lstPlayers.SelectedIndex = lstPlayers.Items.Count - 1
        'For Each x In sonos.Discover.ZonePlayers
        '    lstPlayers.Items.Add(x.UniqueDeviceName)
        'Next
    End Sub
End Class