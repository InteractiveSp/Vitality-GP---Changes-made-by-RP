Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports Alliance.Data.ConnectionHelper
Imports DevExpress.Data.Filtering

Namespace Alliance.Data
    Public Enum eProviderStatus
        Active = 0
        Notes = 1
        OnHold = 2
        Closed = 3
        NoPatients = 4
    End Enum
    Public Class ProviderType
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private fOid As Integer
        <Key>
        Public Property Oid() As Integer
            Get
                Return fOid
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Oid", fOid, value)
            End Set
        End Property
        Private _sequenceNo As Integer
        Public Property SequenceNo() As Integer
            Get
                Return _sequenceNo
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SequenceNo", _sequenceNo, value)
            End Set
        End Property
        Private _providerType As String
        <Size(30)> _
        Public Property ProviderType() As String
            Get
                Return _providerType
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ProviderType", _providerType, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", ProviderType)
        End Function
    End Class
    'Public Class ProviderGroup
    '    Inherits XPObject
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Protected Overrides Sub OnSaving()
    '        MyBase.OnSaving()
    '        If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
    '            CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '            CreatedAt = DateTime.Now
    '        End If
    '        ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '        ModifiedAt = DateTime.Now
    '    End Sub
    '    Private _providerCode As String
    '    <Size(10)> _
    '    Public Property ProviderCode() As String
    '        Get
    '            Return _providerCode
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("ProviderCode", _providerCode, value)
    '        End Set
    '    End Property
    '    Private _ProviderType As eProviderType
    '    Public Property ProviderType() As eProviderType
    '        Get
    '            Return _ProviderType
    '        End Get
    '        Set(ByVal value As eProviderType)
    '            SetPropertyValue(Of eProviderType)("ProviderType", _ProviderType, value)
    '        End Set
    '    End Property
    '    Private _providerGroup As String
    '    <Size(20)> _
    '    Public Property ProviderGroup() As String
    '        Get
    '            Return _providerGroup
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("ProviderGroup", _providerGroup, value)
    '        End Set
    '    End Property
    '    Private _phoneNumber As String
    '    <Size(25)> _
    '    Public Property PhoneNumber() As String
    '        Get
    '            Return _phoneNumber
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("PhoneNumber", _phoneNumber, value)
    '        End Set
    '    End Property
    '    Private _faxNumber As String
    '    <Size(15)> _
    '    Public Property FaxNumber() As String
    '        Get
    '            Return _faxNumber
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("FaxNumber", _faxNumber, value)
    '        End Set
    '    End Property
    '    Private _contact As String
    '    <Size(30)> _
    '    Public Property Contact() As String
    '        Get
    '            Return _contact
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Contact", _contact, value)
    '        End Set
    '    End Property
    '    Private femail As String
    '    <Size(150)> _
    '    Public Property Email() As String
    '        Get
    '            Return femail
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Email", femail, value)
    '        End Set
    '    End Property
    '    Private fAddr1 As String
    '    <Size(50)> _
    '    Public Property Addr1() As String
    '        Get
    '            Return fAddr1
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Addr1", fAddr1, value)
    '        End Set
    '    End Property
    '    Private fAddr2 As String
    '    <Size(50)> _
    '    Public Property Addr2() As String
    '        Get
    '            Return fAddr2
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Addr2", fAddr2, value)
    '        End Set
    '    End Property
    '    Private fCity As String
    '    <Size(50)> _
    '    Public Property City() As String
    '        Get
    '            Return fCity
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("City", fCity, value)
    '        End Set
    '    End Property
    '    Private fCounty As String
    '    <Size(50)> _
    '    Public Property County() As String
    '        Get
    '            Return fCounty
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("County", fCounty, value)
    '        End Set
    '    End Property
    '    Private fPostcode As String
    '    <Size(10)> _
    '    Public Property PostCode() As String
    '        Get
    '            Return fPostcode
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("PostCode", fPostcode, value)
    '        End Set
    '    End Property
    '    <Association("ProviderGroup-ChargeRates")> _
    '    Public ReadOnly Property ChargeRates() As XPCollection(Of ProviderChargeRate)
    '        Get
    '            Return GetCollection(Of ProviderChargeRate)("ChargeRates")
    '        End Get
    '    End Property
    '    <Association("ProviderGroup-AccommodationRates")> _
    '    Public ReadOnly Property AccommodationRates() As XPCollection(Of ProviderAccomodationRate)
    '        Get
    '            Return GetCollection(Of ProviderAccomodationRate)("AccommodationRates")
    '        End Get
    '    End Property
    '    Public Overrides Function ToString() As String
    '        Return String.Format("{0}", ProviderGroup)
    '    End Function
    '    Private fcreatedBy As GlobalUser
    '    Public Property CreatedBy() As GlobalUser
    '        Get
    '            Return fcreatedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
    '        End Set
    '    End Property
    '    Private fcreatedAt As DateTime
    '    Public Property CreatedAt() As DateTime
    '        Get
    '            Return fcreatedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
    '        End Set
    '    End Property
    '    Private fmodifiedBy As GlobalUser
    '    Public Property ModifiedBy() As GlobalUser
    '        Get
    '            Return fmodifiedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
    '        End Set
    '    End Property
    '    Private fmodifiedAt As DateTime
    '    Public Property ModifiedAt() As DateTime
    '        Get
    '            Return fmodifiedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
    '        End Set
    '    End Property

    'End Class
    'Public Class ProviderBaseRate
    '    Inherits XPObject
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Protected Overrides Sub OnSaving()
    '        MyBase.OnSaving()
    '        If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
    '            CreatedBy = ProjectCurrentUser.GetCurrentUser(Session)
    '            CreatedAt = DateTime.Now
    '        End If
    '        ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
    '        ModifiedAt = DateTime.Now
    '    End Sub
    '    Dim _ProviderType As eProviderType
    '    Public Property ProviderType() As eProviderType
    '        Get
    '            Return _ProviderType
    '        End Get
    '        Set(ByVal value As eProviderType)
    '            SetPropertyValue(Of eProviderType)("ProviderType", _ProviderType, value)
    '        End Set
    '    End Property
    '    Dim fRateCategory As RateCategory
    '    Public Property RateCategory() As RateCategory
    '        Get
    '            Return fRateCategory
    '        End Get
    '        Set(ByVal value As RateCategory)
    '            SetPropertyValue(Of RateCategory)("RateCategory", fRateCategory, value)
    '        End Set
    '    End Property
    '    Private fRate As Double
    '    Public Property Rate() As Double
    '        Get
    '            Return fRate
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Rate", fRate, value)
    '        End Set
    '    End Property
    '    Private fcreatedBy As User
    '    Public Property CreatedBy() As User
    '        Get
    '            Return fcreatedBy
    '        End Get
    '        Set(ByVal value As User)
    '            SetPropertyValue(Of User)("CreatedBy", fcreatedBy, value)
    '        End Set
    '    End Property
    '    Private fcreatedAt As DateTime
    '    Public Property CreatedAt() As DateTime
    '        Get
    '            Return fcreatedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
    '        End Set
    '    End Property
    '    Private fmodifiedBy As User
    '    Public Property ModifiedBy() As User
    '        Get
    '            Return fmodifiedBy
    '        End Get
    '        Set(ByVal value As User)
    '            SetPropertyValue(Of User)("ModifiedBy", fmodifiedBy, value)
    '        End Set
    '    End Property
    '    Private fmodifiedAt As DateTime
    '    Public Property ModifiedAt() As DateTime
    '        Get
    '            Return fmodifiedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
    '        End Set
    '    End Property

    'End Class
    'Public Class ProviderCost
    '    Inherits XPObject
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Protected Overrides Sub OnSaving()
    '        MyBase.OnSaving()
    '        If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
    '            CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '            CreatedAt = DateTime.Now
    '        End If
    '        ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '        ModifiedAt = DateTime.Now
    '    End Sub
    '    Dim _provider As Provider
    '    <Association("Provider-Prices")> _
    '    Public Property Provider() As Provider
    '        Get
    '            Return _provider
    '        End Get
    '        Set(ByVal value As Provider)
    '            SetPropertyValue(Of Provider)("Provider", _provider, value)
    '        End Set
    '    End Property
    '    Dim _insurer As Insurer
    '    Public Property Insurer() As Insurer
    '        Get
    '            Return _insurer
    '        End Get
    '        Set(ByVal value As Insurer)
    '            SetPropertyValue(Of Insurer)("Insurer", _insurer, value)
    '        End Set
    '    End Property
    '    Dim _treatment As Treatment
    '    Public Property Treatment() As Treatment
    '        Get
    '            Return _treatment
    '        End Get
    '        Set(ByVal value As Treatment)
    '            SetPropertyValue(Of Treatment)("Treatment", _treatment, value)
    '        End Set
    '    End Property
    '    Private _cost As Double
    '    Public Property Cost() As Double
    '        Get
    '            Return _cost
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Cost", _cost, value)
    '        End Set
    '    End Property
    '    Private _ownCode As String
    '    <Size(20)> _
    '    Public Property OwnCode() As String
    '        Get
    '            Return _ownCode
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("OwnCode", _ownCode, value)
    '        End Set
    '    End Property
    '    Private fcreatedBy As GlobalUser
    '    Public Property CreatedBy() As GlobalUser
    '        Get
    '            Return fcreatedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
    '        End Set
    '    End Property
    '    Private fcreatedAt As DateTime
    '    Public Property CreatedAt() As DateTime
    '        Get
    '            Return fcreatedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
    '        End Set
    '    End Property
    '    Private fmodifiedBy As GlobalUser
    '    Public Property ModifiedBy() As GlobalUser
    '        Get
    '            Return fmodifiedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
    '        End Set
    '    End Property
    '    Private fmodifiedAt As DateTime
    '    Public Property ModifiedAt() As DateTime
    '        Get
    '            Return fmodifiedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
    '        End Set
    '    End Property

    'End Class
    'Public Class ProviderChargeRate
    '    Inherits XPObject
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Protected Overrides Sub OnSaving()
    '        MyBase.OnSaving()
    '        If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
    '            CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '            CreatedAt = DateTime.Now
    '        End If
    '        ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '        ModifiedAt = DateTime.Now
    '    End Sub
    '    Dim fProviderGroup As ProviderGroup
    '    <Association("ProviderGroup-ChargeRates")> _
    '    Public Property ProviderGroup() As ProviderGroup
    '        Get
    '            Return fProviderGroup
    '        End Get
    '        Set(ByVal value As ProviderGroup)
    '            SetPropertyValue(Of ProviderGroup)("ProviderGroup", fProviderGroup, value)
    '        End Set
    '    End Property
    '    Dim _rateCategory As RateCategory
    '    Public Property RateCategory() As RateCategory
    '        Get
    '            Return _rateCategory
    '        End Get
    '        Set(ByVal value As RateCategory)
    '            SetPropertyValue(Of RateCategory)("RateCategory", _rateCategory, value)
    '        End Set
    '    End Property
    '    Private fRate As Double
    '    Public Property Rate() As Double
    '        Get
    '            Return fRate
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Rate", fRate, value)
    '        End Set
    '    End Property

    '    Private fcreatedBy As GlobalUser
    '    Public Property CreatedBy() As GlobalUser
    '        Get
    '            Return fcreatedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
    '        End Set
    '    End Property
    '    Private fcreatedAt As DateTime
    '    Public Property CreatedAt() As DateTime
    '        Get
    '            Return fcreatedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
    '        End Set
    '    End Property
    '    Private fmodifiedBy As GlobalUser
    '    Public Property ModifiedBy() As GlobalUser
    '        Get
    '            Return fmodifiedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
    '        End Set
    '    End Property
    '    Private fmodifiedAt As DateTime
    '    Public Property ModifiedAt() As DateTime
    '        Get
    '            Return fmodifiedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
    '        End Set
    '    End Property

    'End Class
    'Public Class ProviderAccomodationRate
    '    Inherits XPObject
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Protected Overrides Sub OnSaving()
    '        MyBase.OnSaving()
    '        If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
    '            CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '            CreatedAt = DateTime.Now
    '        End If
    '        ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '        ModifiedAt = DateTime.Now
    '    End Sub
    '    Dim fProviderGroup As ProviderGroup
    '    <Association("ProviderGroup-AccommodationRates")> _
    '    Public Property ProviderGroup() As ProviderGroup
    '        Get
    '            Return fProviderGroup
    '        End Get
    '        Set(ByVal value As ProviderGroup)
    '            SetPropertyValue(Of ProviderGroup)("ProviderGroup", fProviderGroup, value)
    '        End Set
    '    End Property
    '    Dim _band As String
    '    Public Property Band() As String
    '        Get
    '            Return _band
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Band", _band, value)
    '        End Set
    '    End Property
    '    Private fRate As Double
    '    Public Property Rate() As Double
    '        Get
    '            Return fRate
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Rate", fRate, value)
    '        End Set
    '    End Property
    '    Private _dayCase As Double
    '    Public Property DayCase() As Double
    '        Get
    '            Return _dayCase
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("DayCase", _dayCase, value)
    '        End Set
    '    End Property
    '    Private _outPatient As Double
    '    Public Property OutPatient() As Double
    '        Get
    '            Return _outPatient
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("OutPatient", _outPatient, value)
    '        End Set
    '    End Property
    '    Private fcreatedBy As GlobalUser
    '    Public Property CreatedBy() As GlobalUser
    '        Get
    '            Return fcreatedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
    '        End Set
    '    End Property
    '    Private fcreatedAt As DateTime
    '    Public Property CreatedAt() As DateTime
    '        Get
    '            Return fcreatedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
    '        End Set
    '    End Property
    '    Private fmodifiedBy As GlobalUser
    '    Public Property ModifiedBy() As GlobalUser
    '        Get
    '            Return fmodifiedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
    '        End Set
    '    End Property
    '    Private fmodifiedAt As DateTime
    '    Public Property ModifiedAt() As DateTime
    '        Get
    '            Return fmodifiedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
    '        End Set
    '    End Property

    'End Class
    'Public Class Provider
    '    Inherits AuditedBase
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Protected Overrides Sub OnSaving()
    '        MyBase.OnSaving()
    '        If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
    '            CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '            CreatedAt = DateTime.Now
    '        End If
    '        ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '        ModifiedAt = DateTime.Now

    '        Dim miPostCode As XPMemberInfo = Me.ClassInfo.GetMember("PostCode")
    '        '   If miPostCode.GetOldValue(Me) <> Nothing Or Session.IsNewObject(Me) Then
    '        If miPostCode.GetOldValue(Me) <> PostCode Then
    '            Dim sLoc As String() = GetPostcodePosition(GetFullAddressLine, "", "UK")
    '            If sLoc(0) <> "" Then
    '                Latitude = sLoc(Coords.Latitude)
    '                Longitude = sLoc(Coords.Longitude)
    '            End If
    '            'End If
    '        End If

    '    End Sub
    '    Private _providerType As eProviderType
    '    <Size(30)> _
    '    Public Property ProviderType() As eProviderType
    '        Get
    '            Return _providerType
    '        End Get
    '        Set(ByVal value As eProviderType)
    '            SetPropertyValue(Of eProviderType)("ProviderType", _providerType, value)
    '        End Set
    '    End Property
    '    Dim _title As String
    '    <Size(15)> _
    '    Public Property Title() As String
    '        Get
    '            Return _title
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Title", _title, value)
    '        End Set
    '    End Property
    '    Private _firstName As String
    '    <Size(30)> _
    '    Public Property FirstName() As String
    '        Get
    '            Return _firstName
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("FirstName", _firstName, value)
    '        End Set
    '    End Property
    '    Private _initials As String
    '    <Size(10)> _
    '    Public Property Initials() As String
    '        Get
    '            Return _initials
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Initials", _initials, value)
    '        End Set
    '    End Property
    '    Private fSurName As String
    '    <Size(40)> _
    '    Public Property SurName() As String
    '        Get
    '            Return fSurName
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("SurName", fSurName, value)
    '        End Set
    '    End Property
    '    Private fGender As Char
    '    Public Property Gender() As Char
    '        Get
    '            Return fGender
    '        End Get
    '        Set(ByVal value As Char)
    '            SetPropertyValue(Of Char)("Gender", fGender, value)
    '        End Set
    '    End Property
    '    Private fDOB As Date?
    '    Public Property DOB() As Date?
    '        Get
    '            Return fDOB
    '        End Get
    '        Set(ByVal value As Date?)
    '            SetPropertyValue(Of Date?)("DOB", fDOB, value)
    '        End Set
    '    End Property

    '    Private femail As String
    '    <Size(150)> _
    '    Public Property Email() As String
    '        Get
    '            Return femail
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Email", femail, value)
    '        End Set
    '    End Property
    '    Private _phoneNumber As String
    '    <Size(30)> _
    '    Public Property PhoneNumber() As String
    '        Get
    '            Return _phoneNumber
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("PhoneNumber", _phoneNumber, value)
    '        End Set
    '    End Property
    '    Private fMobilePhone As String
    '    <Size(20)> _
    '    Public Property MobilePhone() As String
    '        Get
    '            Return fMobilePhone
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("MobilePhone ", fMobilePhone, value)
    '        End Set
    '    End Property
    '    Private ffax As String
    '    <Size(20)> _
    '    Public Property Fax() As String
    '        Get
    '            Return ffax
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Fax ", ffax, value)
    '        End Set
    '    End Property
    '    Private fhomePhone As String
    '    <Size(20)> _
    '    Public Property HomePhone() As String
    '        Get
    '            Return fhomePhone
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("HomePhone", fhomePhone, value)
    '        End Set
    '    End Property
    '    Private fJoinDate As Date
    '    Public Property JoinDate() As Date
    '        Get
    '            Return fJoinDate
    '        End Get
    '        Set(ByVal value As Date)
    '            SetPropertyValue(Of Date)("JoinDate", fJoinDate, value)
    '        End Set
    '    End Property
    '    Private fLeaveDate As Date?
    '    Public Property LeaveDate() As Date?
    '        Get
    '            Return fLeaveDate
    '        End Get
    '        Set(ByVal value As Date?)
    '            SetPropertyValue(Of Date?)("LeaveDate", fLeaveDate, value)
    '        End Set
    '    End Property
    '    Private fCompanyName As String
    '    <Size(60)> _
    '    Public Property CompanyName() As String
    '        Get
    '            Return fCompanyName
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("CompanyName", fCompanyName, value)
    '        End Set
    '    End Property
    '    Private fAcCode As String
    '    <Size(10)> _
    '    Public Property AcCode() As String
    '        Get
    '            Return fAcCode
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("AcCode", fAcCode, value)
    '        End Set
    '    End Property
    '    Private fAddr1 As String
    '    <Size(50)> _
    '    Public Property Addr1() As String
    '        Get
    '            Return fAddr1
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Addr1", fAddr1, value)
    '        End Set
    '    End Property
    '    <Size(50)> _
    '    Private fAddr2 As String
    '    Public Property Addr2() As String
    '        Get
    '            Return fAddr2
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Addr2", fAddr2, value)
    '        End Set
    '    End Property
    '    <Size(50)> _
    '    Private fCity As String
    '    Public Property City() As String
    '        Get
    '            Return fCity
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("City", fCity, value)
    '        End Set
    '    End Property
    '    <Size(50)> _
    '    Private fCounty As String
    '    Public Property County() As String
    '        Get
    '            Return fCounty
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("County", fCounty, value)
    '        End Set
    '    End Property
    '    <Size(10)> _
    '    Private fPostcode As String
    '    Public Property PostCode() As String
    '        Get
    '            Return fPostcode
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("PostCode", fPostcode, value)
    '        End Set
    '    End Property
    '    <Association("Provider-Staff")>
    '    Public ReadOnly Property Staff() As XPCollection(Of ProviderStaff)
    '        Get
    '            Return GetCollection(Of ProviderStaff)("Staff")
    '        End Get
    '    End Property
    '    <Association("Provider-Prices")> _
    '    Public ReadOnly Property Prices() As XPCollection(Of ProviderCost)
    '        Get
    '            Return GetCollection(Of ProviderCost)("Prices")
    '        End Get
    '    End Property
    '    Private _bookingEmail As Boolean
    '    Public Property BookingEmail() As Boolean
    '        Get
    '            Return _bookingEmail
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("BookingEmail", _bookingEmail, value)
    '        End Set
    '    End Property
    '    Private _invoiceEmail As Boolean
    '    Public Property InvoiceEmail() As Boolean
    '        Get
    '            Return _invoiceEmail
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("InvoiceEmail", _invoiceEmail, value)
    '        End Set
    '    End Property
    '    Private _latitude As Double
    '    Public Property Latitude As Double
    '        Get
    '            Return _latitude
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Latitude", _latitude, value)
    '        End Set
    '    End Property
    '    Private _longitude As Double
    '    Public Property Longitude As Double
    '        Get
    '            Return _longitude
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Longitude", _longitude, value)
    '        End Set
    '    End Property
    '    Public Function GetFullAddressLine() As String
    '        Dim ret As String = String.Empty
    '        If Not Object.Equals(Addr1, Nothing) Then
    '            ret = String.Format("{0}", Addr1)
    '        End If
    '        If Not Object.Equals(Addr2, Nothing) Then
    '            ret = String.Format("{0}, {1}", ret, Addr2)
    '        End If
    '        If Not Object.Equals(City, Nothing) Then
    '            ret = String.Format("{0}, {1}", ret, City)
    '        End If
    '        If Not Object.Equals(County, Nothing) Then
    '            ret = String.Format("{0}, {1}", ret, County)
    '        End If
    '        If Not Object.Equals(PostCode, Nothing) Then
    '            ret = String.Format("{0}, {1}", ret, PostCode)
    '        End If
    '        Return ret
    '    End Function
    '    Private _providerGroup As ProviderGroup
    '    Public Property ProviderGroup() As ProviderGroup
    '        Get
    '            Return _providerGroup
    '        End Get
    '        Set(ByVal value As ProviderGroup)
    '            SetPropertyValue(Of ProviderGroup)("ProviderGroup", _providerGroup, value)
    '        End Set
    '    End Property
    '    Private fAccomodationRate As ProviderAccomodationRate
    '    Public Property AccomodationRate() As ProviderAccomodationRate
    '        Get
    '            Return fAccomodationRate
    '        End Get
    '        Set(ByVal value As ProviderAccomodationRate)
    '            SetPropertyValue(Of ProviderAccomodationRate)("AccomodationRate ", fAccomodationRate, value)
    '        End Set
    '    End Property
    '    Private _provider As String
    '    <Size(100)> _
    '    Public Property Provider() As String
    '        Get
    '            Return GetFullName(ProviderType, Title, FirstName, SurName, CompanyName)
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Provider ", _provider, value)
    '        End Set
    '    End Property
    '    <NonPersistent>
    '    Public ReadOnly Property FirstReferral As Date
    '        Get
    '            Return Session.Evaluate(GetType(Referral), CriteriaOperator.Parse("Min(ReferralDate)"), CriteriaOperator.Parse("Consultant= ?", Oid))
    '        End Get
    '    End Property
    '    <NonPersistent>
    '    Public ReadOnly Property LastReferral As Date
    '        Get
    '            Return Session.Evaluate(GetType(Referral), CriteriaOperator.Parse("Max(ReferralDate)"), CriteriaOperator.Parse("Consultant= ?", Oid))
    '        End Get
    '    End Property
    '    <NonPersistent>
    '    Public ReadOnly Property NoReferrals As Integer
    '        Get
    '            Return Session.Evaluate(GetType(Referral), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Consultant= ?", Oid))
    '        End Get
    '    End Property
    '    <NonPersistent>
    '    Public ReadOnly Property NoReferralsThisYear As Integer
    '        Get
    '            Return Session.Evaluate(GetType(Referral), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Consultant= ? and ReferralDate > ?", Oid, DateTime.Today.AddYears(-1)))
    '        End Get
    '    End Property
    '    <NonPersistent>
    '    Public ReadOnly Property AvgCost As Double
    '        Get
    '            Return Session.Evaluate(GetType(ReferralTreatment), CriteriaOperator.Parse("Sum(Cost)"), CriteriaOperator.Parse("Consultant= ?", Oid))
    '        End Get
    '    End Property
    '    <NonPersistent>
    '    Public ReadOnly Property AvgCostThisYear As Double
    '        Get
    '            Return Session.Evaluate(GetType(ReferralTreatment), CriteriaOperator.Parse("Sum(Cost)"), CriteriaOperator.Parse("Consultant= ? and InvoiceDate > ?", Oid, DateTime.Today.AddYears(-1)))
    '        End Get
    '    End Property

    '    'Public ReadOnly Property ProviderLastSorting() As String
    '    '    Get
    '    '        Return GetFullName(ProviderType, Title, FirstName, SurName, CompanyName)
    '    '    End Get
    '    'End Property
    '    Public Shared Function GetFullName(PType As eProviderType, ByVal title As String, ByVal first As String, ByVal second As String, ByVal third As String) As String
    '        Dim ret As String
    '        If PType = eProviderType.Consultant And Not Object.Equals(first, Nothing) Then
    '            If Object.Equals(title, Nothing) Then
    '                ret = String.Empty
    '            Else
    '                ret = title.Trim()
    '            End If
    '            Dim firstTrim As String
    '            If Object.Equals(first, Nothing) Then
    '                ret &= (String.Empty)
    '            Else
    '                ret &= (" ") & first.Trim
    '            End If
    '            Dim secondTrim As String
    '            If Object.Equals(second, Nothing) Then
    '                secondTrim = String.Empty
    '            Else
    '                secondTrim = second.Trim()
    '            End If
    '            If secondTrim.Length <> 0 Then
    '                If ret.Length = 0 Then
    '                    ret &= (String.Empty) & secondTrim
    '                Else
    '                    ret &= (" ") & secondTrim
    '                End If
    '            End If
    '        Else
    '            Dim thirdTrim As String
    '            If Object.Equals(third, Nothing) Then
    '                thirdTrim = String.Empty
    '            Else
    '                thirdTrim = third.Trim()
    '            End If
    '            ret = thirdTrim
    '        End If
    '        Return ret
    '    End Function

    '    Private fGMCNo As String
    '    <Size(15)> _
    '    Public Property GMCNo() As String
    '        Get
    '            Return fGMCNo
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("GMCNo", fGMCNo, value)
    '        End Set
    '    End Property
    '    Private _personId As Integer
    '    Public Property Pers_PersonId() As Integer
    '        Get
    '            Return _personId
    '        End Get
    '        Set(ByVal value As Integer)
    '            SetPropertyValue(Of Integer)("Pers_PersonId", _personId, value)
    '        End Set
    '    End Property
    '    Private _companyId As Integer
    '    Public Property Comp_CompanyId() As Integer
    '        Get
    '            Return _companyId
    '        End Get
    '        Set(ByVal value As Integer)
    '            SetPropertyValue(Of Integer)("Comp_CompanyId", _companyId, value)
    '        End Set
    '    End Property
    '    Private _founderMember As Boolean
    '    Public Property FounderMember() As Boolean
    '        Get
    '            Return _founderMember
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("FounderMember", _founderMember, value)
    '        End Set
    '    End Property
    '    Private _status As eProviderStatus
    '    Public Property Status() As eProviderStatus
    '        Get
    '            Return _status
    '        End Get
    '        Set(ByVal value As eProviderStatus)
    '            SetPropertyValue(Of eProviderStatus)("Status", _status, value)
    '        End Set
    '    End Property
    '    Private _memberstatus As eMemberStatus
    '    Public Property MemberStatus() As eMemberStatus
    '        Get
    '            Return _memberstatus
    '        End Get
    '        Set(ByVal value As eMemberStatus)
    '            SetPropertyValue(Of eMemberStatus)("MemberStatus", _memberstatus, value)
    '        End Set
    '    End Property
    '    Private _psp As PSP
    '    <Association("PSP-Consultants")> _
    '    Public Property PSP() As PSP
    '        Get
    '            Return _psp
    '        End Get
    '        Set(ByVal value As PSP)
    '            SetPropertyValue(Of PSP)("PSP", _psp, value)
    '        End Set
    '    End Property
    '    <Association("SpecialismProvider", UseAssociationNameAsIntermediateTableName:=True)> _
    '    Public ReadOnly Property Specialisms() As XPCollection(Of Specialism)
    '        Get
    '            Return GetCollection(Of Specialism)("Specialisms")
    '        End Get
    '    End Property
    '    Private _paediatrics As Boolean
    '    Public Property Paediatrics() As Boolean
    '        Get
    '            Return _paediatrics
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("Paediatrics", _paediatrics, value)
    '        End Set
    '    End Property
    '    Private _availableforGPSelection As Boolean
    '    Public Property AvailableforGPSelection() As Boolean
    '        Get
    '            Return _availableforGPSelection
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("AvailableforGPSelection", _availableforGPSelection, value)
    '        End Set
    '    End Property
    '    Public Overrides Function ToString() As String
    '        If ProviderType = eProviderType.Consultant Then
    '            If Object.Equals(City, Nothing) Then
    '                Return String.Format("{0} )", Provider)
    '            Else
    '                Return String.Format("{0} ({1})", Provider, City.Trim)
    '            End If
    '        Else
    '            Return String.Format("{0} ({1})", Provider, AcCode)
    '        End If
    '    End Function
    '    Private _password As String
    '    <Size(10)> <MemberDesignTimeVisibility(False)> _
    '    Public Property Password() As String
    '        Get
    '            Return _password
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Password", _password, value)
    '        End Set
    '    End Property
    '    Private _CITuser As Boolean
    '    Public Property CITUser() As Boolean
    '        Get
    '            Return _CITuser
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("CITuser", _CITuser, value)
    '        End Set
    '    End Property
    '    Private _CITDiagnosisCost As Double
    '    Public Property CITDiagnosisCost() As Double
    '        Get
    '            Return _CITDiagnosisCost
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("CITDiagnosisCost", _CITDiagnosisCost, value)
    '        End Set
    '    End Property
    '    Private _CITFullCost As Double
    '    Public Property CITFullCost() As Double
    '        Get
    '            Return _CITFullCost
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("CITFullCost", _CITFullCost, value)
    '        End Set
    '    End Property
    '    Private _CITResponseTime As Integer
    '    Public Property CITResponseTime() As Integer
    '        Get
    '            Return _CITResponseTime
    '        End Get
    '        Set(ByVal value As Integer)
    '            SetPropertyValue(Of Integer)("CITResponseTime", _CITResponseTime, value)
    '        End Set
    '    End Property
    '    Private _CITReplyTime As Integer
    '    Public Property CITReplyTime() As Integer
    '        Get
    '            Return _CITReplyTime
    '        End Get
    '        Set(ByVal value As Integer)
    '            SetPropertyValue(Of Integer)("CITReplyTime", _CITReplyTime, value)
    '        End Set
    '    End Property
    '    Private _notes As String
    '    <Size(SizeAttribute.Unlimited), Delayed(True)> _
    '    Public Property Notes() As String
    '        Get
    '            Return GetDelayedPropertyValue(Of String)("Notes")
    '        End Get
    '        Set(ByVal value As String)
    '            SetDelayedPropertyValue("Notes", value)
    '        End Set
    '    End Property
    '    Private fcreatedBy As GlobalUser
    '    Public Property CreatedBy() As GlobalUser
    '        Get
    '            Return fcreatedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
    '        End Set
    '    End Property
    '    Private fcreatedAt As DateTime
    '    Public Property CreatedAt() As DateTime
    '        Get
    '            Return fcreatedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
    '        End Set
    '    End Property
    '    Private fmodifiedBy As GlobalUser
    '    Public Property ModifiedBy() As GlobalUser
    '        Get
    '            Return fmodifiedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
    '        End Set
    '    End Property
    '    Private fmodifiedAt As DateTime
    '    Public Property ModifiedAt() As DateTime
    '        Get
    '            Return fmodifiedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
    '        End Set
    '    End Property
    'End Class
    'Public Class ProviderStaff
    '    Inherits XPObject
    '    Private ffirstName, flastName, fposition, femail As String
    '    Private fsalutation As Salutation
    '    Private fcreatedBy As User
    '    Private fcreatedAt As DateTime
    '    Private fmodifiedBy As User
    '    Private fmodifiedAt As DateTime

    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Public Sub New(ByVal session As Session, ByVal selfId As Integer)
    '        Me.New(session)
    '    End Sub
    '    Public Overrides Sub AfterConstruction()
    '        MyBase.AfterConstruction()
    '        CreatedAt = DateTime.Now
    '        ModifiedAt = DateTime.Now
    '    End Sub
    '    Protected Overrides Sub OnSaving()
    '        MyBase.OnSaving()
    '        If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
    '            CreatedBy = ProjectCurrentUser.GetCurrentUser(Session)
    '            ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
    '        End If
    '        ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
    '        ModifiedAt = DateTime.Now
    '    End Sub
    '    Private _active As Boolean
    '    Public Property Active() As Boolean
    '        Get
    '            Return _active
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("Active", _active, value)
    '        End Set
    '    End Property
    '    <MemberDesignTimeVisibility(False)>
    '    Public Property Salutation() As Salutation
    '        Get
    '            Return fsalutation
    '        End Get
    '        Set(ByVal value As Salutation)
    '            SetPropertyValue(Of Salutation)("Title", fsalutation, value)
    '        End Set
    '    End Property
    '    Private _title As String
    '    <Size(20)> <MemberDesignTimeVisibility(True)>
    '    Public Property Title() As String
    '        Get
    '            Return _title
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Title", _title, value)
    '        End Set
    '    End Property
    '    <MemberDesignTimeVisibility(True)>
    '    Public Property FirstName() As String
    '        Get
    '            Return ffirstName
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("FirstName", ffirstName, value)
    '        End Set
    '    End Property
    '    <MemberDesignTimeVisibility(True)>
    '    Public Property LastName() As String
    '        Get
    '            Return flastName
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("LastName", flastName, value)
    '        End Set
    '    End Property
    '    <Size(150)> <MemberDesignTimeVisibility(True)>
    '    Public Property Email() As String
    '        Get
    '            Return femail
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Email", femail, value)
    '        End Set
    '    End Property
    '    Private fphone As String
    '    <Size(20)> <MemberDesignTimeVisibility(True)>
    '    Public Property Phone() As String
    '        Get
    '            Return fphone
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Phone", fphone, value)
    '        End Set
    '    End Property
    '    Private fextension As String
    '    <Size(5)> <MemberDesignTimeVisibility(True)>
    '    Public Property Extension() As String
    '        Get
    '            Return fextension
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Extension", fextension, value)
    '        End Set
    '    End Property
    '    Private _bookingEmail As Boolean
    '    Public Property BookingEmail() As Boolean
    '        Get
    '            Return _bookingEmail
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("BookingEmail", _bookingEmail, value)
    '        End Set
    '    End Property
    '    Private _invoiceEmail As Boolean
    '    Public Property InvoiceEmail() As Boolean
    '        Get
    '            Return _invoiceEmail
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("InvoiceEmail", _invoiceEmail, value)
    '        End Set
    '    End Property
    '    Private _notes As String
    '    <Size(SizeAttribute.Unlimited), Delayed(True)> _
    '    Public Property Notes() As String
    '        Get
    '            Return GetDelayedPropertyValue(Of String)("Notes")
    '        End Get
    '        Set(ByVal value As String)
    '            SetDelayedPropertyValue("Notes", value)
    '        End Set
    '    End Property
    '    Private _provider As Provider
    '    <Association("Provider-Staff")>
    '    Public Property Provider() As Provider
    '        Get
    '            Return _provider
    '        End Get
    '        Set(ByVal value As Provider)
    '            SetPropertyValue(Of Provider)("Provider", _provider, value)
    '        End Set
    '    End Property    
    '    <MemberDesignTimeVisibility(False)> _
    '    Public Property CreatedBy() As User
    '        Get
    '            Return fcreatedBy
    '        End Get
    '        Set(ByVal value As User)
    '            SetPropertyValue(Of User)("CreatedBy", fcreatedBy, value)
    '        End Set
    '    End Property
    '    <MemberDesignTimeVisibility(False)> _
    '    Public Property CreatedAt() As DateTime
    '        Get
    '            Return fcreatedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
    '        End Set
    '    End Property
    '    <MemberDesignTimeVisibility(False)> _
    '    Public Property ModifiedBy() As User
    '        Get
    '            Return fmodifiedBy
    '        End Get
    '        Set(ByVal value As User)
    '            SetPropertyValue(Of User)("ModifiedBy", fmodifiedBy, value)
    '        End Set
    '    End Property
    '    <MemberDesignTimeVisibility(False)> _
    '    Public Property ModifiedAt() As DateTime
    '        Get
    '            Return fmodifiedAt
    '        End Get
    '        Set(ByVal value As DateTime)
    '            SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
    '        End Set
    '    End Property
    '    <MemberDesignTimeVisibility(True)> _
    '    Public Overridable ReadOnly Property FullName() As String
    '        Get
    '            Dim ret As String
    '            If Object.Equals(FirstName, Nothing) Then
    '                ret = String.Empty
    '            Else
    '                ret = FirstName.Trim()
    '            End If
    '            Dim lastNameTrim As String
    '            If Object.Equals(LastName, Nothing) Then
    '                lastNameTrim = String.Empty
    '            Else
    '                lastNameTrim = LastName.Trim()
    '            End If
    '            If lastNameTrim.Length <> 0 Then
    '                If ret.Length = 0 Then
    '                    ret &= (String.Empty) & lastNameTrim
    '                Else
    '                    ret &= (" ") & lastNameTrim
    '                End If
    '            End If
    '            Return ret
    '        End Get
    '    End Property
    'End Class
    'Public Class ProviderCV
    '    Inherits XPObject
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Private _provider As Provider
    '    Public Property Provider() As Provider
    '        Get
    '            Return _provider
    '        End Get
    '        Set(ByVal value As Provider)
    '            SetPropertyValue(Of Provider)("Provider", _provider, value)
    '        End Set
    '    End Property
    '    Private _professionalQualifications As String
    '    <Size(SizeAttribute.Unlimited)> _
    '    Public Property ProfessionalQualifications() As String
    '        Get
    '            Return _professionalQualifications
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("ProfessionalQualifications", _professionalQualifications, value)
    '        End Set
    '    End Property
    '    Private _yearqualified As String
    '    <Size(10)> _
    '    Public Property YearQualified() As String
    '        Get
    '            Return _yearqualified
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("YearQualified", _yearqualified, value)
    '        End Set
    '    End Property
    '    Private _qualifications As String
    '    <Size(SizeAttribute.Unlimited)> _
    '    Public Property Qualifications() As String
    '        Get
    '            Return _qualifications
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Qualifications", _qualifications, value)
    '        End Set
    '    End Property
    '    Private _researchInterests As String
    '    <Size(SizeAttribute.Unlimited)> _
    '    Public Property ResearchInterests() As String
    '        Get
    '            Return _researchInterests
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("ResearchInterests", _researchInterests, value)
    '        End Set
    '    End Property
    '    Private _clinicalInterests As String
    '    <Size(SizeAttribute.Unlimited)> _
    '    Public Property ClinicalInterests() As String
    '        Get
    '            Return _clinicalInterests
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("ClinicalInterests", _clinicalInterests, value)
    '        End Set
    '    End Property
    '    Private _positionsHeld As String
    '    <Size(SizeAttribute.Unlimited)> _
    '    Public Property PositionsHeld() As String
    '        Get
    '            Return _positionsHeld
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("PositionsHeld", _positionsHeld, value)
    '        End Set
    '    End Property
    '    Private _medicoLegal As String
    '    <Size(SizeAttribute.Unlimited)> _
    '    Public Property MedicoLegal() As String
    '        Get
    '            Return _medicoLegal
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("MedicoLegal", _medicoLegal, value)
    '        End Set
    '    End Property
    '    Private _Notes As String
    '    <Size(SizeAttribute.Unlimited)> _
    '    Public Property Notes() As String
    '        Get
    '            Return _Notes
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Notes", _Notes, value)
    '        End Set
    '    End Property
    '    Private _additionalInfo As String
    '    <Size(SizeAttribute.Unlimited)> _
    '    Public Property AdditionalInfo() As String
    '        Get
    '            Return _additionalInfo
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("AdditionalInfo", _additionalInfo, value)
    '        End Set
    '    End Property
    '    Public Overrides Function ToString() As String
    '        Return String.Format("{0} (CV)", Provider)
    '    End Function
    'End Class
    'Public Class ProviderSpecialism
    '    Inherits XPObject
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Private _provider As Provider
    '    <Association("Provider-Specialism")> _
    '    Public Property Provider() As Provider
    '        Get
    '            Return _provider
    '        End Get
    '        Set(ByVal value As Provider)
    '            SetPropertyValue(Of Provider)("Provider", _provider, value)
    '        End Set
    '    End Property
    '    Private _specialism As Specialism
    '    <Association("SpecialismProvider")> _
    '    Public Property Specialism() As Specialism
    '        Get
    '            Return _specialism
    '        End Get
    '        Set(ByVal value As Specialism)
    '            SetPropertyValue(Of Specialism)("Specialism", _specialism, value)
    '        End Set
    '    End Property
    '    Private fNote As String
    '    <Size(SizeAttribute.Unlimited)> _
    '    Public Property Note() As String
    '        Get
    '            Return fNote
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Note", fNote, value)
    '        End Set
    '    End Property
    '    Public Overrides Function ToString() As String
    '        Return String.Format("{0} / {1}", Provider, Specialism)
    '    End Function
    'End Class

End Namespace