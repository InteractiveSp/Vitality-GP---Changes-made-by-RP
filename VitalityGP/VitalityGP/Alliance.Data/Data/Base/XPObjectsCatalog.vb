Imports Microsoft.VisualBasic
Imports DevExpress.Xpo
Imports System.Drawing
Imports System
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo.DB
Imports System.Collections

Namespace Alliance.Data
    Public Class Picture
        Inherits XPObject
        Private fimage As Image
        Private fdescription As String

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        <DevExpress.Xpo.ValueConverter(GetType(DevExpress.Xpo.Metadata.ImageValueConverter))> _
        Public Property Image() As Image
            Get
                Return fimage
            End Get
            Set(ByVal value As Image)
                SetPropertyValue(Of Image)("Image", fimage, value)
            End Set
        End Property
        <Size(200)> _
        Public Property Description() As String
            Get
                Return fdescription
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", fdescription, value)
            End Set
        End Property
    End Class
    Public Class PostCode
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _postCode As String
        <Size(10)> _
        Public Property PostCode() As String
            Get
                Return _postCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", _postCode, value)
            End Set
        End Property
        Private _latitude As Double
        Public Property Latitude As Double
            Get
                Return _latitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Latitude", _latitude, value)
            End Set
        End Property
        Private _longitude As Double
        Public Property Longitude As Double
            Get
                Return _latitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Longitude", _longitude, value)
            End Set
        End Property
    End Class

End Namespace
