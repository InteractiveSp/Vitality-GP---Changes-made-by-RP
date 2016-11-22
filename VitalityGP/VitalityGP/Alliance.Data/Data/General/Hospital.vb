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
    Public Enum eHospitalStatus
        Active = 0
        Notes = 1 ' Exchequer Don't understand
        OnHold = 2
        Closed = 3
    End Enum
    Public Enum eHospitalBandType
        None = 0
        Vitality = 10
    End Enum
    Public Enum eHospitalCategory
        NotSet = 0
        NHS = 1
        [Private] = 2
        PrivateUnit = 3
    End Enum
    Public Class HospitalCategory
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
        Private _hospitalCategory As String
        <Size(30)> _
        Public Property HospitalCategory() As String
            Get
                Return _hospitalCategory
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HospitalCategory", _hospitalCategory, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", HospitalCategory)
        End Function
    End Class
    Public Enum eHospitalType
        NotSet = 0
        Hospital = 1
        Anaesthetist = 3
        AlternativeMedicine = 4
        Other = 5
        ConsultingRoom = 6
        MedicalCenter = 8
        Clinic = 9
        MRICenter = 10
    End Enum
    Public Class HospitalType
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
        <Size(30)>
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
    Public Class HospitalGroup
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
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
        Private _hospitalCode As String
        <Size(10)> _
        Public Property HospitalCode() As String
            Get
                Return _hospitalCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HospitalCode", _hospitalCode, value)
            End Set
        End Property
        Private _hospitalType As eHospitalType
        Public Property HospitalType() As eHospitalType
            Get
                Return _hospitalType
            End Get
            Set(ByVal value As eHospitalType)
                SetPropertyValue(Of eHospitalType)("HospitalType", _hospitalType, value)
            End Set
        End Property
        Private _hospitalGroup As String
        <Size(20)> _
        Public Property HospitalGroup() As String
            Get
                Return _hospitalGroup
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HospitalGroup", _hospitalGroup, value)
            End Set
        End Property
        Private _phoneNumber As String
        <Size(25)> _
        Public Property PhoneNumber() As String
            Get
                Return _phoneNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PhoneNumber", _phoneNumber, value)
            End Set
        End Property
        Private _faxNumber As String
        <Size(15)> _
        Public Property FaxNumber() As String
            Get
                Return _faxNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FaxNumber", _faxNumber, value)
            End Set
        End Property
        Private _contact As String
        <Size(30)> _
        Public Property Contact() As String
            Get
                Return _contact
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Contact", _contact, value)
            End Set
        End Property
        Private femail As String
        <Size(150)> _
        Public Property Email() As String
            Get
                Return femail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", femail, value)
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
        Private fAddr2 As String
        <Size(50)> _
        Public Property Addr2() As String
            Get
                Return fAddr2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr2", fAddr2, value)
            End Set
        End Property
        Private fCity As String
        <Size(50)> _
        Public Property City() As String
            Get
                Return fCity
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("City", fCity, value)
            End Set
        End Property
        Private fCounty As String
        <Size(50)> _
        Public Property County() As String
            Get
                Return fCounty
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("County", fCounty, value)
            End Set
        End Property
        Private fPostcode As String
        <Size(10)> _
        Public Property PostCode() As String
            Get
                Return fPostcode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", fPostcode, value)
            End Set
        End Property
        'Private _consultantCategory As RateCategory
        'Public Property ConsultantCategory() As RateCategory
        '    Get
        '        Return _consultantCategory
        '    End Get
        '    Set(ByVal value As RateCategory)
        '        SetPropertyValue(Of RateCategory)("ConsultantCategory", _consultantCategory, value)
        '    End Set
        'End Property
        <Association("HospitalGroupMaxima")> _
        Public ReadOnly Property Maxima() As XPCollection(Of HospitalMaxima)
            Get
                Return GetCollection(Of HospitalMaxima)("Maxima")
            End Get
        End Property
        <Association("HospitalGroupAccommodationBand")> _
        Public ReadOnly Property AccommodationBands() As XPCollection(Of HospitalAccomodationBand)
            Get
                Return GetCollection(Of HospitalAccomodationBand)("AccommodationBands")
            End Get
        End Property
        <Association("HospitalGroupAccommodationeRate")> _
        Public ReadOnly Property AccommodationRates() As XPCollection(Of HospitalAccomodationRate)
            Get
                Return GetCollection(Of HospitalAccomodationRate)("AccommodationRates")
            End Get
        End Property
        <Association("HospitalGroupEstimate")> _
        Public ReadOnly Property Estimates() As XPCollection(Of HospitalEstimate)
            Get
                Return GetCollection(Of HospitalEstimate)("Estimates")
            End Get
        End Property
        <Association("GroupHospitals")>
        Public ReadOnly Property Hospitals() As XPCollection(Of Hospital)
            Get
                Return GetCollection(Of Hospital)("Hospitals")
            End Get
        End Property
        Public ReadOnly Property FullAddressBlock() As String
            Get
                Return GetFullAddressBlock()
            End Get
        End Property
        Public ReadOnly Property HospitalCount() As Integer
            Get
                Return Convert.ToInt32(Session.Evaluate(Of Hospital)(CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("HospitalGroup = ? ", Oid)))
            End Get
        End Property
        Public ReadOnly Property BenficiaryCount() As Integer
            Get
                Dim _sql As String = "SELECT COUNT(DISTINCT Authorisation.Beneficiary) AS Expr1 " _
                    & "FROM Authorisation INNER JOIN " _
                    & "Hospital ON Authorisation.Hospital = Hospital.OID where Hospital.HospitalGroup = " & Oid
                Return Convert.ToInt32(Session.ExecuteScalar(_sql))
            End Get
        End Property
        Public Function GetFullAddressBlock() As String
            Dim ret As String = String.Empty
            If Addr1 IsNot Nothing And Addr1 IsNot String.Empty Then
                ret = String.Format("{0}", Addr1)
            End If
            If Addr2 IsNot Nothing And Addr2 IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, Addr2)
            End If
            If City IsNot Nothing And City IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, City)
            End If
            If County IsNot Nothing And County IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCr, County)
            End If
            If PostCode IsNot Nothing And PostCode IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCr, PostCode)
            End If
            Return ret
        End Function
        Public Overrides Function ToString() As String
            Return String.Format("{0}", HospitalGroup)
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
    Public Class HospitalEstimate
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
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
        Dim _hospitalGroup As HospitalGroup
        <Association("HospitalGroupEstimate")> _
        Public Property HospitalGroup() As HospitalGroup
            Get
                Return _hospitalGroup
            End Get
            Set(ByVal value As HospitalGroup)
                SetPropertyValue(Of HospitalGroup)("HospitalGroup", _hospitalGroup, value)
            End Set
        End Property
        Dim _hospital As Hospital
        <Association("HospitalEstimate")> _
        Public Property Hospital() As Hospital
            Get
                Return _hospital
            End Get
            Set(ByVal value As Hospital)
                SetPropertyValue(Of Hospital)("Hospital", _hospital, value)
            End Set
        End Property
        Dim _treatment As Treatment
        Public Property Treatment() As Treatment
            Get
                Return _treatment
            End Get
            Set(ByVal value As Treatment)
                SetPropertyValue(Of Treatment)("Treatment", _treatment, value)
            End Set
        End Property
        Private _estimate As Double
        Public Property Estimate() As Double
            Get
                Return _estimate
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Estimate", _estimate, value)
            End Set
        End Property
        Private _ownCode As String
        <Size(20)> _
        Public Property OwnCode() As String
            Get
                Return _ownCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("OwnCode", _ownCode, value)
            End Set
        End Property
        Private _package As Char
        Public Property IsPackage() As Char
            Get
                Return _package
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("IsPackage", _package, value)
            End Set
        End Property
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
    Public Class HospitalMaxima
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
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
        Dim _hospitalGroup As HospitalGroup
        <Association("HospitalGroupMaxima")> _
        Public Property HospitalGroup() As HospitalGroup
            Get
                Return _hospitalGroup
            End Get
            Set(ByVal value As HospitalGroup)
                SetPropertyValue(Of HospitalGroup)("HospitalGroup", _hospitalGroup, value)
            End Set
        End Property
        Dim _Maxima As Maxima
        Public Property Maxima() As Maxima
            Get
                Return _Maxima
            End Get
            Set(ByVal value As Maxima)
                SetPropertyValue(Of Maxima)("Maxima", _Maxima, value)
            End Set
        End Property
        Private _budget As Double
        Public Property Budget() As Double
            Get
                Return _budget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Budget", _budget, value)
            End Set
        End Property
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
    Public Class HospitalAccomodationBand
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Dim _hospitalGroup As HospitalGroup
        <Association("HospitalGroupAccommodationBand")> _
         Public Property HospitalGroup() As HospitalGroup
            Get
                Return _hospitalGroup
            End Get
            Set(ByVal value As HospitalGroup)
                SetPropertyValue(Of HospitalGroup)("HospitalGroup", _hospitalGroup, value)
            End Set
        End Property
        Dim _accommodationBand As String
        Public Property AccommodationBand() As String
            Get
                Return _accommodationBand
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AccommodationBand", _accommodationBand, value)
            End Set
        End Property
    End Class
    Public Class HospitalAccomodationRate
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
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
        Dim _hospitalGroup As HospitalGroup
        <Association("HospitalGroupAccommodationeRate")> _
        Public Property HospitalGroup() As HospitalGroup
            Get
                Return _hospitalGroup
            End Get
            Set(ByVal value As HospitalGroup)
                SetPropertyValue(Of HospitalGroup)("HospitalGroup", _hospitalGroup, value)
            End Set
        End Property
        Dim _accommodationBand As HospitalAccomodationBand
        Public Property AccommodationBand() As HospitalAccomodationBand
            Get
                Return _accommodationBand
            End Get
            Set(ByVal value As HospitalAccomodationBand)
                SetPropertyValue(Of HospitalAccomodationBand)("AccommodationBand", _accommodationBand, value)
            End Set
        End Property
        Dim _accommodationtype As eAccommodationType
        Public Property AccommodationType() As eAccommodationType
            Get
                Return _accommodationtype
            End Get
            Set(ByVal value As eAccommodationType)
                SetPropertyValue(Of eAccommodationType)("AccommodationType", _accommodationtype, value)
            End Set
        End Property
        Private _lengthOfStay As String
        <Size(3)> _
        Public Property LengthOfStay() As String
            Get
                Return _lengthOfStay
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LengthOfStay", _lengthOfStay, value)
            End Set
        End Property
        Private _budget As Double
        Public Property Budget() As Double
            Get
                Return _budget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Rate", _budget, value)
            End Set
        End Property
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
    Public Class Hospital
        Inherits AuditedBase
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now

            Dim miPostCode As XPMemberInfo = Me.ClassInfo.GetMember("PostCode")
            '   If miPostCode.GetOldValue(Me) <> Nothing Or Session.IsNewObject(Me) Then
            If miPostCode.GetOldValue(Me) <> PostCode Then
                Dim sLoc As String() = GetPostcodePosition(GetFullAddressLine, "", "UK")
                If sLoc(0) <> "" Then
                    Latitude = sLoc(Coords.Latitude)
                    Longitude = sLoc(Coords.Longitude)
                End If
            End If

        End Sub
        Private _hospitalName As String
        <Size(60)> _
        Public Property HospitalName() As String
            Get
                Return _hospitalName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HospitalName", _hospitalName, value)
            End Set
        End Property
        Private fAcCode As String
        <Size(10)> _
        Public Property AcCode() As String
            Get
                Return fAcCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AcCode", fAcCode, value)
            End Set
        End Property
        Private _healthCodeNo As String
        <Size(10)> _
        Public Property HealthCodeNo() As String
            Get
                Return _healthCodeNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HealthCode", _healthCodeNo, value)
            End Set
        End Property
        Private _hospitalType As ProviderType
        Public Property HospitalType() As ProviderType
            Get
                Return _hospitalType
            End Get
            Set(ByVal value As ProviderType)
                SetPropertyValue(Of ProviderType)("HospitalType", _hospitalType, value)
            End Set
        End Property
        Private femail As String
        <Size(150)> _
        Public Property Email() As String
            Get
                Return femail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", femail, value)
            End Set
        End Property
        Private _phoneNumber As String
        <Size(30)> _
        Public Property PhoneNumber() As String
            Get
                Return _phoneNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PhoneNumber", _phoneNumber, value)
            End Set
        End Property
        Private _bookingNumber As String
        <Size(20)> _
        Public Property BookingNumber() As String
            Get
                Return _bookingNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BookingNumber ", _bookingNumber, value)
            End Set
        End Property
        Private ffax As String
        <Size(20)> _
        Public Property Fax() As String
            Get
                Return ffax
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Fax ", ffax, value)
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
        Private fCity As String
        Public Property City() As String
            Get
                Return fCity
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("City", fCity, value)
            End Set
        End Property
        <Size(50)> _
        Private fCounty As String
        Public Property County() As String
            Get
                Return fCounty
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("County", fCounty, value)
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
        <Association("HospitalStaff")>
        Public ReadOnly Property Staff() As XPCollection(Of HospitalStaff)
            Get
                Return GetCollection(Of HospitalStaff)("Staff")
            End Get
        End Property
        '<Association> _
        'Public ReadOnly Property ConsultantHospitals() As IList(Of ConsultantHospital)
        '    Get
        '        Return GetList(Of ConsultantHospital)("ConsultantHospitals")
        '    End Get
        'End Property
        <Association> _
        Public ReadOnly Property ConsultantHospitals() As XPCollection(Of ConsultantHospital)
            Get
                Return GetCollection(Of ConsultantHospital)("ConsultantHospitals")

            End Get
        End Property
        <ManyToManyAlias("ConsultantHospitals", "Consultant")> _
        Public ReadOnly Property Consultants() As IList(Of Consultant)
            Get
                Return GetList(Of Consultant)("Consultants")
            End Get
        End Property
        <Association, Browsable(False)> _
        Public ReadOnly Property HospitalAttributes() As IList(Of HospitalAttribute)
            Get
                Return GetList(Of HospitalAttribute)("HospitalAttributes")
            End Get
        End Property
        <ManyToManyAlias("HospitalAttributes", "Attrib")> _
        Public ReadOnly Property Attribs() As IList(Of Attrib)
            Get
                Return GetList(Of Attrib)("Attribs")
            End Get
        End Property
        <NonPersistent>
        Public ReadOnly Property NoConsultants As Integer
            Get
                Return CInt(Session.Evaluate(GetType(ConsultantHospital), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Hospital= ?", Oid)))
            End Get
        End Property
        Public ReadOnly Property AttributeList() As String
             Get
                Return GetAttributeList()
            End Get
        End Property
        Public Function GetAttributeList() As String
            Dim ret As String = Nothing
            For Each oattrib As Attrib In Attribs
                If ret Is Nothing Then
                    ret = String.Format(oattrib.Attribute)
                Else
                    ret &= String.Format(",{0}", oattrib.Attribute)
                End If
            Next
            Return ret
        End Function
        Public ReadOnly Property FullAddressLine() As String
            Get
                Return GetFullAddressLine()
            End Get
        End Property
        Public ReadOnly Property FullAddressBlock() As String
            Get
                Return GetFullAddressBlock()
            End Get
        End Property
        Public Function GetFullAddressBlock() As String
            Dim ret As String = String.Empty
            If Addr1 IsNot Nothing And Addr1 IsNot String.Empty Then
                ret = String.Format("{0}", Addr1)
            End If
            If Addr2 IsNot Nothing And Addr2 IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, Addr2)
            End If
            If City IsNot Nothing And City IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, City)
            End If
            If County IsNot Nothing And County IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCr, County)
            End If
            If PostCode IsNot Nothing And PostCode IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCr, PostCode)
            End If
            Return ret
        End Function
        Public ReadOnly Property HospitalConsultantInfoHtml() As String
            Get
                Return GetHospitalConsultantInfoHtml()
            End Get
        End Property
        Public Function GetHospitalConsultantInfoHtml() As String
            Dim ret As String = String.Empty
            Dim _consultantCount As Integer = 0
            For Each oCons As ConsultantHospital In ConsultantHospitals
                _consultantCount += 1
                ret &= String.Format(Constants.vbCrLf & "<b>{0}</b>", oCons.Consultant.FullName)
                If (Not String.IsNullOrEmpty(oCons.Comment)) Then
                    ret &= String.Format("{0}{1}       Note: {2}", Constants.vbCrLf, Constants.vbTab, oCons.Comment)
                    ret &= "-".PadRight(10 + oCons.Comment.Length, "-")
                End If
            Next
            ret = String.Format("<b>{0}</b>{1} {2} Consultants: {3}{4}{5}", HospitalName, vbCrLf, _consultantCount, Constants.vbCrLf, Constants.vbTab, ret)
            Return ret
        End Function
        <Association("HospitalEstimate")> _
        Public ReadOnly Property Estimates() As XPCollection(Of HospitalEstimate)
            Get
                Return GetCollection(Of HospitalEstimate)("Estimates")
            End Get
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
                Return _longitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Longitude", _longitude, value)
            End Set
        End Property
        Public Function GetFullAddressLine() As String
            Dim ret As String = String.Empty
            If Not Object.Equals(Addr1, Nothing) Then
                ret = String.Format("{0}", Addr1)
            End If
            If Not Object.Equals(Addr2, Nothing) Then
                ret = String.Format("{0}, {1}", ret, Addr2)
            End If
            If Not Object.Equals(City, Nothing) Then
                ret = String.Format("{0}, {1}", ret, City)
            End If
            If Not Object.Equals(County, Nothing) Then
                ret = String.Format("{0}, {1}", ret, County)
            End If
            If Not Object.Equals(PostCode, Nothing) Then
                ret = String.Format("{0}, {1}", ret, PostCode)
            End If
            Return ret
        End Function
        Private _hospitalGroup As HospitalGroup
        <Association("GroupHospitals")>
        Public Property HospitalGroup() As HospitalGroup
            Get
                Return _hospitalGroup
            End Get
            Set(ByVal value As HospitalGroup)
                SetPropertyValue(Of HospitalGroup)("HospitalGroup", _hospitalGroup, value)
            End Set
        End Property
        Private _accomodationBand As HospitalAccomodationBand
        Public Property AccomodationBand() As HospitalAccomodationBand
            Get
                Return _accomodationBand
            End Get
            Set(ByVal value As HospitalAccomodationBand)
                SetPropertyValue(Of HospitalAccomodationBand)("AccomodationBand ", _accomodationBand, value)
            End Set
        End Property
        Private _companyId As Integer
        Public Property Comp_CompanyId() As Integer
            Get
                Return _companyId
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Comp_CompanyId", _companyId, value)
            End Set
        End Property
        Private _status As eHospitalStatus
        Public Property Status() As eHospitalStatus
            Get
                Return _status
            End Get
            Set(ByVal value As eHospitalStatus)
                SetPropertyValue(Of eHospitalStatus)("Status", _status, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", HospitalName.Trim)
        End Function
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return GetDelayedPropertyValue(Of String)("Notes")
            End Get
            Set(ByVal value As String)
                SetDelayedPropertyValue("Notes", value)
            End Set
        End Property
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
    Public Class HospitalStaff
        Inherits XPObject
        Private ffirstName, flastName, fposition, femail As String
        Private fsalutation As Salutation
        Private fcreatedBy As GlobalUser
        Private fcreatedAt As DateTime
        Private fmodifiedBy As GlobalUser
        Private fmodifiedAt As DateTime

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal selfId As Integer)
            Me.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            CreatedAt = DateTime.Now
            ModifiedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _active As Boolean
        Public Property Active() As Boolean
            Get
                Return _active
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Active", _active, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)>
        Public Property Salutation() As Salutation
            Get
                Return fsalutation
            End Get
            Set(ByVal value As Salutation)
                SetPropertyValue(Of Salutation)("Title", fsalutation, value)
            End Set
        End Property
        Private _title As String
        <Size(20)> <MemberDesignTimeVisibility(True)>
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Title", _title, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        Public Property FirstName() As String
            Get
                Return ffirstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FirstName", ffirstName, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        Public Property LastName() As String
            Get
                Return flastName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LastName", flastName, value)
            End Set
        End Property
        <Size(150)> <MemberDesignTimeVisibility(True)>
        Public Property Email() As String
            Get
                Return femail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", femail, value)
            End Set
        End Property
        Private fphone As String
        <Size(20)> <MemberDesignTimeVisibility(True)>
        Public Property Phone() As String
            Get
                Return fphone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Phone", fphone, value)
            End Set
        End Property
        Private fextension As String
        <Size(5)> <MemberDesignTimeVisibility(True)>
        Public Property Extension() As String
            Get
                Return fextension
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Extension", fextension, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return GetDelayedPropertyValue(Of String)("Notes")
            End Get
            Set(ByVal value As String)
                SetDelayedPropertyValue("Notes", value)
            End Set
        End Property
        Private _hospital As Hospital
        <Association("HospitalStaff")>
        Public Property Hospital() As Hospital
            Get
                Return _hospital
            End Get
            Set(ByVal value As Hospital)
                SetPropertyValue(Of Hospital)("Hospital", _hospital, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)> _
        Public Property CreatedBy() As GlobalUser
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)> _
        Public Property CreatedAt() As DateTime
            Get
                Return fcreatedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)> _
        Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)> _
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)> _
        Public Overridable ReadOnly Property FullName() As String
            Get
                Dim ret As String
                If Object.Equals(FirstName, Nothing) Then
                    ret = String.Empty
                Else
                    ret = FirstName.Trim()
                End If
                Dim lastNameTrim As String
                If Object.Equals(LastName, Nothing) Then
                    lastNameTrim = String.Empty
                Else
                    lastNameTrim = LastName.Trim()
                End If
                If lastNameTrim.Length <> 0 Then
                    If ret.Length = 0 Then
                        ret &= (String.Empty) & lastNameTrim
                    Else
                        ret &= (" ") & lastNameTrim
                    End If
                End If
                Return ret
            End Get
        End Property
    End Class
    Public Class HospitalBand
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _HospitalBandType As eHospitalBandType
        Public Property HospitalBandType() As eHospitalBandType
            Get
                Return _HospitalBandType
            End Get
            Set(ByVal value As eHospitalBandType)
                SetPropertyValue(Of eHospitalBandType)("HospitalBandType", _HospitalBandType, value)
            End Set
        End Property
        Private _hospitalBand As String
        <Size(30)> _
        Public Property HospitalBand() As String
            Get
                Return _hospitalBand
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HospitalOption", _hospitalBand, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", HospitalBand)
        End Function
    End Class
End Namespace