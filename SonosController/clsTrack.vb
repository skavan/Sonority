Imports Sonority
Imports System.Xml.XPath
Imports Sonority.UPnP

Public Class clsTrack

    Const noalbumart = "http://www.kavan.us/musicweb/images/No-album-art300x300.jpg"

    Dim WithEvents metadataConverter As New cConverter(noalbumart)
    Dim WithEvents zp As ZonePlayer
    Private WithEvents avTransport As AVTransport

    Public Event imageloaded(image As Bitmap, imageURI As Uri)
    Public Event trackDataChange(message As String)

    Public Property Album As String
    Public Property AlbumArtist As String
    Public Property Title As String
    Public Property Artist As String

    Public Property TrackNumber As Integer
    Public Property AlbumTrackCount As Integer
    Public Property Year As Integer
    Public Property AlbumArt As Uri
    Public Property ArtImage As Image

    Public Property TrackDuration As System.TimeSpan
    Public Property TrackPosition As System.TimeSpan
    Public Property TrackCompletion As Single           '// in percent
    Private Property cf As String = ""
    Dim thread1 As Threading.Thread
    Dim thread2 As Threading.Thread
    Dim thread3 As Threading.Thread
#Region "Initialization"
    Public Sub New(zonePlayer As ZonePlayer)
        zp = zonePlayer
        avTransport = zp.AVTransport
    End Sub

    Public Sub New(uniqueDeviceName As String)
        zp = New UPnP.ZonePlayer(uniqueDeviceName)
        avTransport = zp.AVTransport
    End Sub

#End Region


    Public Sub GetMetaData()
        AlbumArtist = GetTagData("AlbumArtist")
        Artist = GetTagData("Artist")
        Album = GetTagData("Album")
        Title = GetTagData("Title")
        AlbumArt = metadataConverter.CreateAlbumArtURI(zp.AVTransport.CurrentTrackMetaData, zp.DocumentUrl)
                
        RaiseEvent trackDataChange("Current Track Data")
    End Sub

    Public Sub GetMoreData()
        Dim filepath = String.Format("\\{0}{1}", zp.AVTransport.CurrentTrackUri.Host, zp.AVTransport.CurrentTrackUri.LocalPath)
        Dim tagFile As TagLib.File = TagLib.File.Create(filepath)
        Dim track As Integer = tagFile.Tag.Track
        Dim trackcount As Integer = tagFile.Tag.TrackCount
        If trackcount = 0 Then trackcount = System.IO.Directory.GetFiles(IO.Path.GetDirectoryName(filepath), "*.*", IO.SearchOption.TopDirectoryOnly).Where(Function(s) s.EndsWith(".mp3") OrElse s.EndsWith(".m4a") OrElse s.EndsWith(".wma")).Count
        Me.TrackNumber = track
        Me.AlbumTrackCount = trackcount

        RaiseEvent trackDataChange("Current Track Data")
    End Sub

    Public Sub CheckProgress()
        Try
            TrackDuration = zp.AVTransport.CurrentTrackDuration
            TrackPosition = zp.AVTransport.RelTime
            TrackCompletion = (zp.AVTransport.RelTime.TotalMilliseconds / zp.AVTransport.CurrentTrackDuration.TotalMilliseconds) * 100
            RaiseEvent trackDataChange("Song Position")
        Catch ex As Exception
            Debug.Print("Ouich!" & ex.Message)
        End Try

    End Sub

    Private Function GetTagData(tag As String) As String
        Dim RetVal As String = metadataConverter.GetTrackMetadata(zp.AVTransport.CurrentTrackMetaData, tag)
        Debug.Print(String.Format("{0}:{1}", tag, RetVal))
        If RetVal = Nothing Then RetVal = ""
        Return RetVal
    End Function

#Region "Sonos Events"

    Private Sub avTransport_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles avTransport.PropertyChanged
        Dim obj As Object
        If sender.[GetType]().GetProperty(e.PropertyName) Is Nothing Then
            obj = ""
        Else
            obj = sender.[GetType]().GetProperty(e.PropertyName).GetValue(sender, Nothing)
        End If

        Select Case e.PropertyName
            Case "RelTime"

                Debug.Print("Entering PropertyChanged : RelTime")
                thread3 = New System.Threading.Thread(AddressOf CheckProgress)
                thread3.Start()
                'CheckProgress()
                'Application.DoEvents()
            Case "CurrentTrackMetaData"
                Debug.Print("Entering PropertyChanged : CurrentMetaData")
                thread1 = New System.Threading.Thread(AddressOf GetMetaData)
                thread1.Start()
                Try
                    CheckProgress()
                Catch ex As Exception
                    Debug.Print("CheckProgress Failed in CurrentTrackMetaData")
                End Try
                thread2 = New System.Threading.Thread(AddressOf GetMoreData)
                thread2.Start()


                'Debug.Print("CurrentTrackMetaData Event Trigger")

                'RaiseEvent trackDataChange("Current Track Data")
                'Application.DoEvents()

            Case Else
        End Select
        'Debug.Print("av Tran Changed: {0}.{1} -> {2}", sender.[GetType]().Name, e.PropertyName, obj)
        Debug.Print("av Tran Changed: {0}.{1}", sender.[GetType]().Name, e.PropertyName)
    End Sub


    Private Sub trackData_imageloaded(image As System.Drawing.Bitmap, imageURI As System.Uri) Handles metadataConverter.imageloaded
        Debug.Print("We have the physical image")
        AlbumArt = imageURI
        ArtImage = image
        RaiseEvent trackDataChange("New Album Art")
    End Sub

#End Region

    

End Class
