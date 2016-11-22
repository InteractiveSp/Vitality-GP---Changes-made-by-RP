Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data
    Public Class Practice
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
            Me.PracticeName = name
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private fODS As String
        <Size(8)> _
        Public Property ODS() As String
            Get
                Return fODS
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ODS", fODS, value)
            End Set
        End Property
        Private fPracticeName As String
        <Size(50)> _
        Public Property PracticeName() As String
            Get
                Return fPracticeName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PracticeName", fPracticeName, value)
            End Set
        End Property
        Private fAddr1 As String
        <Size(50)> _
        Public Property Addr1() As String
            Get
                Return fAddr1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr1", fAddr1, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr2 As String
        Public Property Addr2() As String
            Get
                Return fAddr2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr2", fAddr2, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr3 As String
        Public Property Addr3() As String
            Get
                Return fAddr3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr3", fAddr3, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr4 As String
        Public Property Addr4() As String
            Get
                Return fAddr4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr4", fAddr4, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr5 As String
        Public Property Addr5() As String
            Get
                Return fAddr5
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr5", fAddr5, value)
            End Set
        End Property
        <Size(10)> _
        Private fPostcode As String
        Public Property PostCode() As String
            Get
                Return fPostcode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", fPostcode, value)
            End Set
        End Property
        Private fLatitude As Double
        Public Property Latitude() As Double
            Get
                Return fLatitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Latitude", fLatitude, value)
            End Set
        End Property
        Private fLongitude As Double
        Public Property Longitude() As Double
            Get
                Return fLongitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Longitude", fLongitude, value)
            End Set
        End Property

        Private fStatusCode As Char
        Public Property StatusCode() As Char
            Get
                Return fStatusCode
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("StatusCode", fStatusCode, value)
            End Set
        End Property
        Private fTelephone As String
        <Size(12)> _
        Public Property Telephone() As String
            Get
                Return fTelephone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Telephone", fTelephone, value)
            End Set
        End Property

        Private fcomments As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Comments() As String
            Get
                Return fcomments
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Comments", fcomments, value)
            End Set
        End Property
        <Association("Practice-GPs")> _
        Public ReadOnly Property GPs() As XPCollection(Of GP)
            Get
                Return GetCollection(Of GP)("GPs")
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", PracticeName)
        End Function
        Private fcreatedBy As GlobalUser
        Public Property CreatedBy() As GlobalUser
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
            End Set
        End Property
        Private fcreatedAt As DateTime
        Public Property CreatedAt() As DateTime
            Get
                Return fcreatedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
            End Set
        End Property
        Private fmodifiedBy As GlobalUser
        Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        Private fmodifiedAt As DateTime
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property

    End Class
    Public Class GP
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnSaved()
            MyBase.OnSaved()
        End Sub
        Private fODS As String
        <Size(8)> _
        Public Property ODS() As String
            Get
                Return fODS
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ODS", fODS, value)
            End Set
        End Property
        Private fFullName As String
        <Size(50)> _
        Public Property FullName() As String
            Get
                Return fFullName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FullName", fFullName, value)
            End Set
        End Property
        Private fAddr1 As String
        <Size(50)> _
        Public Property Addr1() As String
            Get
                Return fAddr1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr1", fAddr1, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr2 As String
        Public Property Addr2() As String
            Get
                Return fAddr2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr2", fAddr2, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr3 As String
        Public Property Addr3() As String
            Get
                Return fAddr3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr3", fAddr3, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr4 As String
        Public Property Addr4() As String
            Get
                Return fAddr4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr4", fAddr4, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr5 As String
        Public Property Addr5() As String
            Get
                Return fAddr5
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr5", fAddr5, value)
            End Set
        End Property
        <Size(10)> _
        Private fPostcode As String
        Public Property PostCode() As String
            Get
                Return fPostcode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", fPostcode, value)
            End Set
        End Property
        Private fLatitude As Double
        Public Property Latitude() As Double
            Get
                Return fLatitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Latitude", fLatitude, value)
            End Set
        End Property
        Private fLongitude As Double
        Public Property Longitude() As Double
            Get
                Return fLongitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Longitude", fLongitude, value)
            End Set
        End Property

        Private fStatusCode As Char
        Public Property StatusCode() As Char
            Get
                Return fStatusCode
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("StatusCode", fStatusCode, value)
            End Set
        End Property
        Private fTelephone As String
        <Size(12)> _
        Public Property Telephone() As String
            Get
                Return fTelephone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Telephone", fTelephone, value)
            End Set
        End Property
        Private fPractice As Practice
        <Association("Practice-GPs")> _
        Public Property Practice() As Practice
            Get
                Return fPractice
            End Get
            Set(ByVal value As Practice)
                SetPropertyValue(Of Practice)("Practice", fPractice, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", FullName)
        End Function
        Private fcreatedBy As GlobalUser
        Public Property CreatedBy() As GlobalUser
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
            End Set
        End Property
        Private fcreatedAt As DateTime
        Public Property CreatedAt() As DateTime
            Get
                Return fcreatedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
            End Set
        End Property
        Private fmodifiedBy As GlobalUser
        Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        Private fmodifiedAt As DateTime
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property
    End Class
End Namespace
