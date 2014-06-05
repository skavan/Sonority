Imports Sonority
Imports System.Xml.XPath
Imports Sonority.UPnP

Public Class Form1
    Const noalbumart = "http://www.kavan.us/musicweb/images/No-album-art300x300.jpg"

    Dim WithEvents zp As New UPnP.ZonePlayer("uuid:RINCON_000E58A72F9601400")
    Dim isReady As Boolean = False
    Dim WithEvents trackData As New cConverter(noalbumart)
    Dim WithEvents deviceProp As DeviceProperties
    Dim WithEvents renderCon As RenderingControl
    Dim WithEvents avTran As AVTransport
    Dim WithEvents contentDir As ContentDirectory
    Dim WithEvents groupMan As GroupManagement
    Private Delegate Sub ProgressCallback()
    Private Delegate Sub MetaDataCallback()

    Dim progCB As New ProgressCallback(AddressOf Me.CheckProgress)
    Dim metaCB As New MetaDataCallback(AddressOf GetMetaData)



    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Debug.Print(String.Format("Device: {0}, Icon: {1}", zp.UniqueDeviceName, zp.DeviceProperties.Icon))
        deviceProp = zp.DeviceProperties
        renderCon = zp.RenderingControl
        avTran = zp.AVTransport
        contentDir = zp.ContentDirectory
        groupMan = zp.GroupManagement
        Debug.Print(zp.AVTransport.GetMediaInfo.NrTracks)
        isReady = True
    End Sub


    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim path1 As String = ""
        Dim destination As String = ""
        For Each node As XPathNavigator In contentDir.Browse("0", BrowseFlags.BrowseDirectChildren, "*", "")
            Debug.Print(node.OuterXml)

            ''#If FOO Then
            'path1 = HttpUtility.UrlDecode(node.SelectSingleNode("@id", Sonority.XPath.Globals.Manager).Value)
            'path1 = path1.Replace("S://", "\\")
            'path1 = path1.Replace("/"c, "\"c)
            'destination = Path.Combine("c:\temp\nuevo", Path.GetFileName(path1))
            'Console.WriteLine("{0}", path1)

            ''#End If
            'File.Copy(path1, destination)
        Next

        For Each node As QueueItem In zp.Queue
            Console.WriteLine(node)
        Next
        zp.Queue.ToString()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Debug.Print("***********************************************************************************")
        'ListBox1.Items.Clear()
        'GetTagData(Nothing)
        
        'GetTagData("AlbumArt")
        'GetTagData("TrackNum")

        GetMetaData()

        'ImageLoader = New AlbumArtUriConverter()
        
        'ListBox1.Items.Add(trackData.GetMoreData("\\" & zp.AVTransport.CurrentTrackUri.Host & zp.AVTransport.CurrentTrackUri.LocalPath))

    End Sub

    Sub GetMetaData()
        lblAlbumArtist.Text = GetTagData("AlbumArtist")
        lblArtist.Text = GetTagData("Artist")
        If lblArtist.Text = lblAlbumArtist.Text Then lblArtist.Text = ""

        lblAlbum.Text = GetTagData("Album")
        lblTitle.Text = GetTagData("Title")
        Dim imgLink As String = trackData.CreateAlbumArtURI(zp.AVTransport.CurrentTrackMetaData, zp.DocumentUrl).OriginalString
        If Not (imgLink Is Nothing) Then
            PictureBox2.ImageLocation = trackData.CreateAlbumArtURI(zp.AVTransport.CurrentTrackMetaData, zp.DocumentUrl).OriginalString
        End If
        PictureBox1.Image = trackData.GetTrackImage(zp.AVTransport.CurrentTrackMetaData, zp.DocumentUrl)
        trackData.GetMoreData("\\" & zp.AVTransport.CurrentTrackUri.Host & zp.AVTransport.CurrentTrackUri.LocalPath)
        lblTrackNum.Text = String.Format("track {0} of {1}", trackData.TrackNumber, trackData.AlbumTrackCount)

        CheckProgress()


    End Sub
    Sub CheckProgress()
        Try
            lblDuration.Text = zp.AVTransport.CurrentTrackDuration.ToString
            lblcPos.Text = zp.AVTransport.RelTime.ToString
            pbTime.Maximum = zp.AVTransport.CurrentTrackDuration.TotalMilliseconds
            pbTime.Value = zp.AVTransport.RelTime.TotalMilliseconds
        Catch ex As Exception

        End Try



    End Sub

    Function GetTagData(tag As String) As String
        Dim RetVal As String = trackData.GetTrackMetadata(zp.AVTransport.CurrentTrackMetaData, tag)
        ListBox1.Items.Add(String.Format("{0}:{1}", tag, RetVal))
        Debug.Print(String.Format("{0}:{1}", tag, RetVal))
        If RetVal = Nothing Then RetVal = ""
        Return RetVal
    End Function



    Private Sub trackData_imageloaded(image As System.Drawing.Bitmap, imageURI As System.Uri) Handles trackData.imageloaded
        PictureBox1.Image = image
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

    End Sub

#Region "zp_changed_events"


    Private Sub zp_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles zp.PropertyChanged
        Dim obj As Object
        If sender.[GetType]().GetProperty(e.PropertyName) Is Nothing Then
            obj = ""
        Else
            obj = sender.[GetType]().GetProperty(e.PropertyName).GetValue(sender, Nothing)
        End If
        Debug.Print("Changed: {0}.{1} -> {2}", sender.[GetType]().Name, e.PropertyName, obj)
        'zp = sender
        isReady = True
    End Sub

    Private Sub avTran_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles avTran.PropertyChanged

        Dim obj As Object
        If sender.[GetType]().GetProperty(e.PropertyName) Is Nothing Then
            obj = ""
        Else
            obj = sender.[GetType]().GetProperty(e.PropertyName).GetValue(sender, Nothing)
        End If
        If Not isReady Then Exit Sub
        Select Case e.PropertyName
            Case "RelTime"

                'Me.BeginInvoke(d, New Object() {[obj]})
                Me.BeginInvoke(progCB)
                CheckProgress()
            Case "CurrentTrackMetaData"
                Me.BeginInvoke(metaCB)
            Case Else
        End Select
        Debug.Print("av Tran Changed: {0}.{1} -> {2}", sender.[GetType]().Name, e.PropertyName, obj)
    End Sub

    Private Sub contentDir_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles contentDir.PropertyChanged
        Dim obj As Object
        If sender.[GetType]().GetProperty(e.PropertyName) Is Nothing Then
            obj = ""
        Else
            obj = sender.[GetType]().GetProperty(e.PropertyName).GetValue(sender, Nothing)
        End If
        Debug.Print("ContentDir Changed: {0}.{1} -> {2}", sender.[GetType]().Name, e.PropertyName, obj)
    End Sub

    Private Sub deviceProp_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles deviceProp.PropertyChanged
        Dim obj As Object
        If sender.[GetType]().GetProperty(e.PropertyName) Is Nothing Then
            obj = ""
        Else
            obj = sender.[GetType]().GetProperty(e.PropertyName).GetValue(sender, Nothing)
        End If
        Debug.Print("device Prop Changed: {0}.{1} -> {2}", sender.[GetType]().Name, e.PropertyName, obj)
    End Sub

    Private Sub groupMan_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles groupMan.PropertyChanged
        Dim obj As Object
        If sender.[GetType]().GetProperty(e.PropertyName) Is Nothing Then
            obj = ""
        Else
            obj = sender.[GetType]().GetProperty(e.PropertyName).GetValue(sender, Nothing)
        End If
        Debug.Print("Group Man Changed: {0}.{1} -> {2}", sender.[GetType]().Name, e.PropertyName, obj)
    End Sub

    Private Sub renderCon_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles renderCon.PropertyChanged
        Dim obj As Object
        If sender.[GetType]().GetProperty(e.PropertyName) Is Nothing Then
            obj = ""
        Else
            obj = sender.[GetType]().GetProperty(e.PropertyName).GetValue(sender, Nothing)
        End If
        Debug.Print("RenderCon Changed: {0}.{1} -> {2}", sender.[GetType]().Name, e.PropertyName, obj)
    End Sub
#End Region

    Private Sub tp_stop_Click(sender As System.Object, e As System.EventArgs) Handles tp_stop.Click
        zp.AVTransport.Stop()
    End Sub

    Private Sub tp_prev_Click(sender As System.Object, e As System.EventArgs) Handles tp_prev.Click
        zp.AVTransport.Previous()
    End Sub

    Private Sub tp_play_Click(sender As System.Object, e As System.EventArgs) Handles tp_play.Click
        zp.AVTransport.Play()
    End Sub

    Private Sub tp_pause_Click(sender As System.Object, e As System.EventArgs) Handles tp_pause.Click
        zp.AVTransport.Pause()
    End Sub

    Private Sub tp_next_Click(sender As System.Object, e As System.EventArgs) Handles tp_next.Click
        zp.AVTransport.Next()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        
    End Sub
End Class

Partial Public Class MyApp

    Public ReadOnly Property Discover() As UPnP.Discover
        Get
            Return _disc
        End Get
    End Property

    Private _disc As New Sonority.UPnP.Discover

End Class
