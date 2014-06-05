Imports Sonority
Imports System.Xml.XPath
Imports Sonority.UPnP

Public Class clsSonos
    Public WithEvents Player As clsPlayer
    Private WithEvents _disc As New Sonority.UPnP.Discover '// Initialize the system
    Public Event DevicesFound(deviceID As String)
    Public ReadOnly Property Discover As UPnP.Discover
        Get
            Return _disc
        End Get
    End Property

    Private Sub _disc_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles _disc.PropertyChanged

        Debug.Print("DISCOVERED: " & e.PropertyName & "Device Name: " & _disc.ZonePlayers(0).UniqueDeviceName)
        'Debug.Print(_disc.ZonePlayers(0).UniqueDeviceName)
        'Debug.Print(_disc.ZonePlayers.Count)
        Select Case e.PropertyName
            Case "ZonePlayer Added"
                For n As Integer = 0 To _disc.ZonePlayers.Count - 1
                    '// if the last entry
                    If n = _disc.ZonePlayers.Count - 1 Then
                        RaiseEvent DevicesFound(_disc.ZonePlayers(n).UniqueDeviceName)
                    End If
                Next

        End Select
    End Sub
End Class
