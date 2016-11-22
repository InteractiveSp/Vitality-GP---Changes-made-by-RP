Namespace Alliance.Data
    Public Class LatLong
        Public Property Latitude As Double
        Public Property Longitude As Double

        Public Sub New()

        End Sub

        Public Sub New(ByVal lat As Double, ByVal lon As Double)
            Me.Latitude = lat
            Me.Longitude = lon
        End Sub
    End Class
End Namespace