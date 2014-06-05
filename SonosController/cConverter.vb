Imports System.Windows
Imports System.Windows.Media.Imaging
Imports System.Xml.XPath
Imports Sonority.XPath
Imports System.IO
Imports System.Reflection
Imports TagLib

Public Class cConverter
    Dim WithEvents bi As New BitmapImage
    Public Event imageloaded(image As Bitmap, imageURI As Uri)

    Public Property Album As String
    Public Property AlbumArtist As String
    Public Property Title As String
    Public Property Artist As String

    Public Property TrackNumber As Integer
    Public Property AlbumTrackCount As Integer
    Public Property Year As Integer

    Private Property _missingAlbumArtPath As String

    '// Function to extract a tag from SONOS metadata on a track
    Public Function GetTrackMetadata(value As Object, parameter As Object) As String
        If value Is Nothing Then
            Return ""
        End If

        Dim nav As XPathNavigator = DirectCast(value, XPathNavigator)
        If parameter Is Nothing Then
            Return [String].Format("Artist: {0} / Album: {1} / Track: {2}", nav.SelectSingleNode(Expressions.Creator).Value, nav.SelectSingleNode(Expressions.Album).Value, nav.SelectSingleNode(Expressions.Title).Value)
        Else
            Dim e As XPathExpression
            Dim fi As FieldInfo = GetType(Expressions).GetField(parameter.ToString(), BindingFlags.[Public] Or BindingFlags.[Static] Or BindingFlags.GetField)
            Try
                e = DirectCast(fi.GetValue(Nothing), XPathExpression)

            Catch ex As Exception
                If e Is Nothing Then
                    Return ""
                End If
            End Try


            Dim node As XPathNavigator = nav.SelectSingleNode(e)
            If node IsNot Nothing Then
                Return node.Value.ToString
            Else
                Return ""
            End If

        End If
    End Function

    '// Function to extract both a graphic and link to the sonus albumart for a track
    Public Function GetTrackImage(trackdata As XPathNavigator, trackpath As Uri) As Object
        If trackdata Is Nothing Then
            Return DependencyProperty.UnsetValue
        ElseIf trackpath Is Nothing Then
            Return DependencyProperty.UnsetValue
        End If

        'For Each obj As Object In trackdata
        '    If obj Is Nothing OrElse obj = DependencyProperty.UnsetValue Then
        '        Return DependencyProperty.UnsetValue
        '    End If
        'Next

        Dim nav As XPathNavigator = DirectCast(trackdata, XPathNavigator)
        Dim artNav As XPathNavigator = nav.SelectSingleNode(Expressions.AlbumArt)
        If artNav Is Nothing Then
            Return Nothing
            'Return DependencyProperty.UnsetValue
        End If

        Dim art As String = artNav.Value
        If [String].IsNullOrEmpty(art) Then
            'Return DependencyProperty.UnsetValue
            Return Nothing
        End If

        If Uri.IsWellFormedUriString(art, UriKind.Absolute) Then
            ' Pandora, etc where the full Uri is already given to use
            bi = New BitmapImage(New Uri(art))
            Return BitmapImage2Bitmap(bi)
        Else



            'bi.BeginInit()
            bi = New BitmapImage(CreateAlbumArtURI(trackdata, trackpath))
            'bi.UriSource = CreateAlbumArtURI(trackdata, trackpath)

            'bi.EndInit()
            'Return BitmapImage2Bitmap(bi)
            Return Nothing
        End If
    End Function

    Public Function CreateAlbumArtURI(trackdata As XPathNavigator, trackpath As Uri) As Uri
        Dim nav As XPathNavigator = DirectCast(trackdata, XPathNavigator)
        If nav Is Nothing Then Return New Uri(_missingAlbumArtPath)

        Dim artNav As XPathNavigator = nav.SelectSingleNode(Expressions.AlbumArt)
        If artNav Is Nothing Then
            Return New Uri(_missingAlbumArtPath)
        Else

            Dim art As String = artNav.Value
            Dim baseUri As Uri = DirectCast(trackpath, Uri)
            Dim path As String = art.Substring(0, art.IndexOf("?"c))
            Dim qs As String = art.Substring(art.IndexOf("?"c))
            Dim builder As New UriBuilder(baseUri.Scheme, baseUri.Host, baseUri.Port, path, qs)
            Return builder.Uri
        End If
    End Function

    Private Function BitmapImage2Bitmap(bitmapImage As BitmapImage) As Bitmap

        ' BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

        Using outStream As New MemoryStream()
            Dim enc As BitmapEncoder = New BmpBitmapEncoder()
            enc.Frames.Add(BitmapFrame.Create(bitmapImage))
            enc.Save(outStream)
            Dim bitmap As New System.Drawing.Bitmap(outStream)

            ' return bitmap; <-- leads to problems, stream is closed/closing ...
            Return New Bitmap(bitmap)
        End Using
    End Function

    Private Sub bi_Changed(sender As Object, e As System.EventArgs) Handles bi.Changed
        Debug.Print("Changed")
    End Sub

    Private Sub bi_DownloadCompleted(sender As Object, e As System.EventArgs) Handles bi.DownloadCompleted
        Debug.Print("Download Completed")
        RaiseEvent imageloaded(BitmapImage2Bitmap(bi), bi.UriSource)
    End Sub

    Public Function GetMoreData(filepath As String) As String
        Dim tagFile As TagLib.File = TagLib.File.Create(filepath)
        Dim track As Integer = tagFile.Tag.Track
        Dim trackcount As Integer = tagFile.Tag.TrackCount

        Me.TrackNumber = track
        Me.AlbumTrackCount = trackcount
        Return String.Format("track {0} of {1}", track, trackcount)
    End Function

    Public Sub New(_pathtonoalbumart As String)
        _missingAlbumArtPath = _pathtonoalbumart
    End Sub

End Class
