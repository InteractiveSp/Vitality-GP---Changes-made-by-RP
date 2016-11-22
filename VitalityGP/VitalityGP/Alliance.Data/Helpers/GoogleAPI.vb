Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Xml
Imports System

Namespace Alliance.Data
    Public Module GoogleAPI
        Public Function GetLatLong(ByVal addr As String) As LatLong
            If String.IsNullOrWhiteSpace(addr) Then
                Return Nothing
            End If
            'Dim url As String = "http://maps.google.com/maps/geo?output=csv&key=AIzaSyA0ftBIwlz4Zxz0htMjtlOgLuoCsmhVgmk&q=" & addr
            Dim url As String = "https://maps.googleapis.com/maps/api/geocode/xml?address=" & addr & "&key=AIzaSyAhxC8Osou50uW3aVuB_0BjT8HtnxO_pd4"

            Dim request As System.Net.WebRequest = WebRequest.Create(url)

            Dim response As HttpWebResponse = request.GetResponse()

            If response.StatusCode = HttpStatusCode.OK Then

                'Dim ms As New System.IO.MemoryStream()

                'Dim responseStream As System.IO.Stream = response.GetResponseStream()
                Dim geoXml As XmlDocument = New XmlDocument()
                geoXml.Load(response.GetResponseStream())
                If geoXml.SelectSingleNode("/GeocodeResponse/status").InnerText = "OK" Then
                    Dim slat As String = geoXml.SelectSingleNode("/GeocodeResponse/result/geometry/location/lat").InnerText
                    Dim slng As String = geoXml.SelectSingleNode("/GeocodeResponse/result/geometry/location/lng").InnerText
                    Return New LatLong(Convert.ToDouble(slat), Convert.ToDouble(slng))
                End If
            End If

            Return Nothing

        End Function
    End Module
End Namespace
