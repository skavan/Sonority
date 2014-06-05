Imports Sonority
Imports System.Xml.XPath
Imports Sonority.UPnP

Public Class clsPlayer

    Const noalbumart = "http://www.kavan.us/musicweb/images/No-album-art300x300.jpg"

    Public Event trackDataChange(Message As String, trackData As clsTrack)
    Public WithEvents currentTrack As clsTrack

    Private WithEvents zp As ZonePlayer

    Private WithEvents deviceProp As DeviceProperties
    Private WithEvents renderCon As RenderingControl
    Private WithEvents avTran As AVTransport
    Private WithEvents contentDir As ContentDirectory
    Private WithEvents groupMan As GroupManagement
    Public LastPlayerID As String = "xxxx"

    Public Sub New(uniqueDeviceName As String)
        InitPlayer(uniqueDeviceName)
    End Sub

    Public Sub New()
        If LastPlayerID <> "" Then
            InitPlayer(LastPlayerID)
        End If
    End Sub

    Private Sub InitPlayer(PlayerID As String)
        Try
            zp = New UPnP.ZonePlayer(PlayerID)
            If Not zp Is Nothing Then
                InitSonosSystem()
            End If

        Catch ex As Exception
            Debug.Print("No Device Found")
        End Try
    End Sub


    Private Sub InitSonosSystem()
        Debug.Print(String.Format("Sonos Player Initialization: {0}, Icon: {1}", zp.UniqueDeviceName, zp.DeviceProperties.Icon))
        deviceProp = zp.DeviceProperties
        'renderCon = zp.RenderingControl
        avTran = zp.AVTransport
        contentDir = zp.ContentDirectory
        'groupMan = zp.GroupManagement
        currentTrack = New clsTrack(zp)

        'Debug.Print(zp.AVTransport.GetMediaInfo.NrTracks)
    End Sub

#Region "Transport Controls"

    Public Sub [Stop]()
        zp.AVTransport.Stop()
    End Sub

    Public Sub Pause()
        zp.AVTransport.Pause()
    End Sub

    Public Sub Play()
        zp.AVTransport.Play()
    End Sub

    Public Sub [Next]()
        zp.AVTransport.Next()
    End Sub

    Public Sub Prev()
        zp.AVTransport.Previous()
    End Sub

#End Region

#Region "SONOS Events"

    Private Sub zp_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles zp.PropertyChanged
        HandleSonosEvent(sender, e)
    End Sub

    Private Sub avTran_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles avTran.PropertyChanged
        HandleSonosEvent(sender, e)
    End Sub

    Private Sub contentDir_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles contentDir.PropertyChanged
        HandleSonosEvent(sender, e)
    End Sub

    Private Sub deviceProp_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles deviceProp.PropertyChanged
        HandleSonosEvent(sender, e)
    End Sub

    Private Sub groupMan_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles groupMan.PropertyChanged
        HandleSonosEvent(sender, e)
    End Sub

    Private Sub renderCon_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles renderCon.PropertyChanged
        HandleSonosEvent(sender, e)
    End Sub

    Private Sub HandleSonosEvent(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs)
        Dim obj As Object
        If sender.[GetType]().GetProperty(e.PropertyName) Is Nothing Then
            obj = ""
        Else
            obj = sender.[GetType]().GetProperty(e.PropertyName).GetValue(sender, Nothing)
        End If
        'Debug.Print("{0}: {1}.{2} -> {3}", (New System.Diagnostics.StackTrace).GetFrame(1).GetMethod.Name, sender.[GetType]().Name, e.PropertyName, obj)
    End Sub

#End Region



    Private Sub currentTrack_trackDataChange(message As String) Handles currentTrack.trackDataChange
        Debug.Print(String.Format("Player Class: trackdata change ({0})", message))
        RaiseEvent trackDataChange(message, currentTrack)
    End Sub

End Class
