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
Imports DevExpress.Xpo.DB

Namespace Alliance.Data
    Public Enum eMemberStatus
        None = 0
        Associate = 1
        FounderMember = 2
        Recommended = 3
    End Enum

    Public Class MemberStatus
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal MemberStatus As String)
            Me.New(session)
            Me.fMemberStatus = MemberStatus
        End Sub
        Private fsequenceNo As Integer
        Public Property SequenceNo() As Integer
            Get
                Return fsequenceNo
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SequenceNo", fsequenceNo, value)
            End Set
        End Property
        Private fMemberStatus As String
        <Size(20)>
        Public Property MemberStatus() As String
            Get
                Return fMemberStatus
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MemberStatus", fMemberStatus, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", MemberStatus)
        End Function
    End Class
    Public Class Specialism
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
        Dim fSpecialism As String
        <Size(50)>
        Public Property Specialism() As String
            Get
                Return fSpecialism
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Specialism", fSpecialism, value)
            End Set
        End Property
        <Association, Browsable(False)>
        Public ReadOnly Property ConsultantSpecialisms() As IList(Of ConsultantSpecialism)
            Get
                Return GetList(Of ConsultantSpecialism)("ConsultantSpecialisms")
            End Get
        End Property
        <ManyToManyAlias("ConsultantSpecialisms", "Consultant")>
        Public ReadOnly Property Consultants() As IList(Of Consultant)
            Get
                Return GetList(Of Consultant)("Consultants")
            End Get
        End Property
        <PersistentAlias("Consultants[Status=0  and (MemberStatus=1 or MemberStatus=2)].Count")>
        Public ReadOnly Property Active() As Integer
            Get
                Return CType(EvaluateAlias("Active"), Integer)
            End Get
        End Property
        <PersistentAlias("Consultants[Status=0 and MemberStatus=2].Count")>
        Public ReadOnly Property ActiveFounders() As Integer
            Get
                Return CType(EvaluateAlias("ActiveFounders"), Integer)
            End Get
        End Property
        <PersistentAlias("Consultants[Status=0 and MemberStatus=1].Count")>
        Public ReadOnly Property ActiveAssociates() As Integer
            Get
                Return CType(EvaluateAlias("ActiveAssociates"), Integer)
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Specialism)
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
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        Private fmodifiedAt As DateTime
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property
    End Class
    Public Class SubSpecialism
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
        End Sub
        Dim _code As String
        <Size(30)>
        Public Property Code() As String
            Get
                Return _code
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", _code, value)
            End Set
        End Property
        Dim _subSpecialism As String
        <Size(50)>
        Public Property SubSpecialism() As String
            Get
                Return _subSpecialism
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SubSpecialism", _subSpecialism, value)
            End Set
        End Property
        <Association, Browsable(False)>
        Public ReadOnly Property ConsultantSubSpecialisms() As IList(Of ConsultantSubSpecialism)
            Get
                Return GetList(Of ConsultantSubSpecialism)("ConsultantSubSpecialisms")
            End Get
        End Property
        <ManyToManyAlias("ConsultantSubSpecialisms", "Consultant")>
        Public ReadOnly Property Consultants() As IList(Of Consultant)
            Get
                Return GetList(Of Consultant)("Consultants")
            End Get
        End Property
        <PersistentAlias("Consultants[Status=0  and (MemberStatus=1 or MemberStatus=2)].Count")>
        Public ReadOnly Property Active() As Integer
            Get
                Return CType(EvaluateAlias("Active"), Integer)
            End Get
        End Property
        <PersistentAlias("Consultants[Status=0 and MemberStatus=3].Count")>
        Public ReadOnly Property ActiveFounders() As Integer
            Get
                Return CType(EvaluateAlias("ActiveFounders"), Integer)
            End Get
        End Property
        <PersistentAlias("Consultants[Status=0 and MemberStatus=2].Count")>
        Public ReadOnly Property ActiveAssociates() As Integer
            Get
                Return CType(EvaluateAlias("ActiveAssociates"), Integer)
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", SubSpecialism)
        End Function
    End Class
    Public Class ConsultantGroup
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
        Private _Code As String
        <Size(10)>
        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", _Code, value)
            End Set
        End Property
        Private _consultantGroup As String
        <Size(25)>
        Public Property ConsultantGroup() As String
            Get
                Return _consultantGroup
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ConsultantGroup", _consultantGroup, value)
            End Set
        End Property
        Private _phoneNumber As String
        <Size(25)>
        Public Property PhoneNumber() As String
            Get
                Return _phoneNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PhoneNumber", _phoneNumber, value)
            End Set
        End Property
        Private _faxNumber As String
        <Size(15)>
        Public Property FaxNumber() As String
            Get
                Return _faxNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FaxNumber", _faxNumber, value)
            End Set
        End Property
        Private _contact As String
        <Size(30)>
        Public Property Contact() As String
            Get
                Return _contact
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Contact", _contact, value)
            End Set
        End Property
        Private femail As String
        <Size(150)>
        Public Property Email() As String
            Get
                Return femail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", femail, value)
            End Set
        End Property
        Private fAddr1 As String
        <Size(50)>
        Public Property Addr1() As String
            Get
                Return fAddr1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr1", fAddr1, value)
            End Set
        End Property
        Private fAddr2 As String
        <Size(50)>
        Public Property Addr2() As String
            Get
                Return fAddr2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr2", fAddr2, value)
            End Set
        End Property
        Private fCity As String
        <Size(50)>
        Public Property City() As String
            Get
                Return fCity
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("City", fCity, value)
            End Set
        End Property
        Private fCounty As String
        <Size(50)>
        Public Property County() As String
            Get
                Return fCounty
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("County", fCounty, value)
            End Set
        End Property
        Private fPostcode As String
        <Size(10)>
        Public Property PostCode() As String
            Get
                Return fPostcode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", fPostcode, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Code)
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
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        Private fmodifiedAt As DateTime
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property

    End Class
    Public Class Consultant
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
        End Sub
        Dim _title As String
        <Size(15)>
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Title", _title, value)
            End Set
        End Property
        Private _firstName As String
        <Size(30)>
        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FirstName", _firstName, value)
            End Set
        End Property
        Private _initials As String
        <Size(10)>
        Public Property Initials() As String
            Get
                Return _initials
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Initials", _initials, value)
            End Set
        End Property
        Private _surName As String
        <Size(45)>
        Public Property SurName() As String
            Get
                Return _surName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SurName", _surName, value)
            End Set
        End Property
        Private fGender As Char
        Public Property Gender() As Char
            Get
                Return fGender
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("Gender", fGender, value)
            End Set
        End Property
        Private fDOB As Date?
        Public Property DOB() As Date?
            Get
                Return fDOB
            End Get
            Set(ByVal value As Date?)
                SetPropertyValue(Of Date?)("DOB", fDOB, value)
            End Set
        End Property

        Private femail As String
        <Size(150)>
        Public Property Email() As String
            Get
                Return femail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", femail, value)
            End Set
        End Property
        Private _phoneNumber As String
        <Size(30)>
        Public Property PhoneNumber() As String
            Get
                Return _phoneNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PhoneNumber", _phoneNumber, value)
            End Set
        End Property
        Private fMobilePhone As String
        <Size(20)>
        Public Property MobilePhone() As String
            Get
                Return fMobilePhone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MobilePhone ", fMobilePhone, value)
            End Set
        End Property
        Private ffax As String
        <Size(20)>
        Public Property Fax() As String
            Get
                Return ffax
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Fax ", ffax, value)
            End Set
        End Property
        Private fhomePhone As String
        <Size(20)>
        Public Property HomePhone() As String
            Get
                Return fhomePhone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HomePhone", fhomePhone, value)
            End Set
        End Property
        Private _bookingInstructions As String
        <Size(40)>
        Public Property BookingInstructions() As String
            Get
                Return _bookingInstructions
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BookingInstructions", _bookingInstructions, value)
            End Set
        End Property
        Private fJoinDate As Date
        Public Property JoinDate() As Date
            Get
                Return fJoinDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("JoinDate", fJoinDate, value)
            End Set
        End Property
        Private fLeaveDate As Date?
        Public Property LeaveDate() As Date?
            Get
                Return fLeaveDate
            End Get
            Set(ByVal value As Date?)
                SetPropertyValue(Of Date?)("LeaveDate", fLeaveDate, value)
            End Set
        End Property
        Private _hasCV As Boolean
        Public Property HasCV() As Boolean
            Get
                Return _hasCV
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("HasCV", _hasCV, value)
            End Set
        End Property

        Private _lastReviewed As Date
        Public Property LastReviewed() As Date
            Get
                Return _lastReviewed
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("LastReviewed", _lastReviewed, value)
            End Set
        End Property
        Private _consultantType As eProviderType
        Public Property Type() As eProviderType
            Get
                Return _consultantType
            End Get
            Set(ByVal value As eProviderType)
                SetPropertyValue(Of eProviderType)("Type", _consultantType, value)
            End Set
        End Property
        Private fAcCode As String
        <Size(10)>
        Public Property AcCode() As String
            Get
                Return fAcCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AcCode", fAcCode, value)
            End Set
        End Property
        Private fAddr1 As String
        <Size(50)>
        Public Property Addr1() As String
            Get
                Return fAddr1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr1", fAddr1, value)
            End Set
        End Property
        <Size(50)>
        Private fAddr2 As String
        Public Property Addr2() As String
            Get
                Return fAddr2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr2", fAddr2, value)
            End Set
        End Property
        <Size(50)>
        Private fAddr3 As String
        Public Property Addr3() As String
            Get
                Return fAddr3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr3", fAddr3, value)
            End Set
        End Property
        <Size(50)>
        Private fCity As String
        Public Property City() As String
            Get
                Return fCity
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("City", fCity, value)
            End Set
        End Property
        <Size(50)>
        Private fCounty As String
        Public Property County() As String
            Get
                Return fCounty
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("County", fCounty, value)
            End Set
        End Property
        <Size(10)>
        Private fPostcode As String
        Public Property PostCode() As String
            Get
                Return fPostcode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", fPostcode, value)
            End Set
        End Property
        Private _consultantGroup As ConsultantGroup
        Public Property ConsultantGroup() As ConsultantGroup
            Get
                Return _consultantGroup
            End Get
            Set(ByVal value As ConsultantGroup)
                SetPropertyValue(Of ConsultantGroup)("ConsultantGroup", _consultantGroup, value)
            End Set
        End Property
        Private _psp As PSP
        <Association("PSPConsultants")>
        Public Property PSP() As PSP
            Get
                Return _psp
            End Get
            Set(ByVal value As PSP)
                SetPropertyValue(Of PSP)("PSP", _psp, value)
            End Set
        End Property
        <Association, Browsable(False)>
        Public ReadOnly Property ConsultantSpecialisms() As IList(Of ConsultantSpecialism)
            Get
                Return GetList(Of ConsultantSpecialism)("ConsultantSpecialisms")
            End Get
        End Property
        <ManyToManyAlias("ConsultantSpecialisms", "Specialism")>
        Public ReadOnly Property Specialisms() As IList(Of Specialism)
            Get
                Return GetList(Of Specialism)("Specialisms")
            End Get
        End Property
        <Association, Browsable(False)>
        Public ReadOnly Property ConsultantSubSpecialisms() As IList(Of ConsultantSubSpecialism)
            Get
                Return GetList(Of ConsultantSubSpecialism)("ConsultantSubSpecialisms")
            End Get
        End Property
        '<Association, Browsable(False)> _
        'Public ReadOnly Property ConsultantSubSpecialisms() As XPCollection(Of ConsultantSubSpecialism)
        '    Get
        '        Return GetCollection(Of ConsultantSubSpecialism)("ConsultantSubSpecialisms")
        '    End Get
        'End Property
        <ManyToManyAlias("ConsultantSubSpecialisms", "SubSpecialism")>
        Public ReadOnly Property SubSpecialisms() As IList(Of SubSpecialism)
            Get
                Return GetList(Of SubSpecialism)("SubSpecialisms")
            End Get
        End Property
        'Public ReadOnly Property ConsultantHospitals() As IList(Of ConsultantHospital)
        '    Get
        '        Return GetList(Of ConsultantHospital)("ConsultantHospitals")
        '    End Get
        'End Property
        <Association>
        Public ReadOnly Property ConsultantHospitals() As XPCollection(Of ConsultantHospital)
            Get
                Return GetCollection(Of ConsultantHospital)("ConsultantHospitals")
            End Get
        End Property
        <ManyToManyAlias("ConsultantHospitals", "Hospital")>
        Public ReadOnly Property Hospitals() As IList(Of Hospital)
            Get
                Return GetList(Of Hospital)("Hospitals")
            End Get
        End Property
        <PersistentAlias("Hospitals.Count")>
        Public ReadOnly Property HospitalCount() As Integer
            Get
                Return CType(EvaluateAlias("HospitalCount"), Integer)
            End Get
        End Property
        <Association("ConsultantStaff")>
        Public ReadOnly Property Staff() As XPCollection(Of ConsultantStaff)
            Get
                Return GetCollection(Of ConsultantStaff)("Staff")
            End Get
        End Property
        <Association("ConsultantCosts")>
        Public ReadOnly Property Prices() As XPCollection(Of ConsultantCost)
            Get
                Return GetCollection(Of ConsultantCost)("Prices")
            End Get
        End Property
        Private _ccbookingEmail As Boolean
        Public Property ccBookingEmail() As Boolean
            Get
                Return _ccbookingEmail
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ccBookingEmail", _ccbookingEmail, value)
            End Set
        End Property
        Private _ccinvoiceEmail As Boolean
        Public Property ccInvoiceEmail() As Boolean
            Get
                Return _ccinvoiceEmail
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ccInvoiceEmail", _ccinvoiceEmail, value)
            End Set
        End Property
        Private fGMCNo As String
        <Size(15)>
        Public Property GMCNo() As String
            Get
                Return fGMCNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GMCNo", fGMCNo, value)
            End Set
        End Property
        Private _yearqualified As String
        <Size(7)>
        Public Property YearQualified() As String
            Get
                Return _yearqualified
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("YearQualified", _yearqualified, value)
            End Set
        End Property
        Private _personId As Integer
        Public Property Pers_PersonId() As Integer
            Get
                Return _personId
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Pers_PersonId", _personId, value)
            End Set
        End Property
        Private _founderMember As Boolean
        Public Property FounderMember() As Boolean
            Get
                Return _founderMember
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("FounderMember", _founderMember, value)
            End Set
        End Property
        Private _status As eProviderStatus
        Public Property Status() As eProviderStatus
            Get
                Return _status
            End Get
            Set(ByVal value As eProviderStatus)
                SetPropertyValue(Of eProviderStatus)("Status", _status, value)
            End Set
        End Property
        Private _memberstatus As eMemberStatus
        Public Property MemberStatus() As eMemberStatus
            Get
                Return _memberstatus
            End Get
            Set(ByVal value As eMemberStatus)
                SetPropertyValue(Of eMemberStatus)("MemberStatus", _memberstatus, value)
            End Set
        End Property
        Private _paediatrics As Boolean
        Public Property Paediatrics() As Boolean
            Get
                Return _paediatrics
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Paediatrics", _paediatrics, value)
            End Set
        End Property
        Private _availableforGPSelection As Boolean
        Public Property AvailableforGPSelection() As Boolean
            Get
                Return _availableforGPSelection
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("AvailableforGPSelection", _availableforGPSelection, value)
            End Set
        End Property
        Private _password As String
        Public Property Password() As String
            Get
                Return _password
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Password", _password, value)
            End Set
        End Property
        Private _CITuser As Boolean
        Public Property CITUser() As Boolean
            Get
                Return _CITuser
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("CITuser", _CITuser, value)
            End Set
        End Property
        Private _CITDiagnosisCost As Double
        Public Property CITDiagnosisCost() As Double
            Get
                Return _CITDiagnosisCost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("CITDiagnosisCost", _CITDiagnosisCost, value)
            End Set
        End Property
        Private _MITCost As Double
        Public Property MITCost() As Double
            Get
                Return _MITCost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("MITCost", _MITCost, value)
            End Set
        End Property

        Private _CITFullCost As Double
        Public Property CITFullCost() As Double
            Get
                Return _CITFullCost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("CITFullCost", _CITFullCost, value)
            End Set
        End Property
        Private _CITResponseTime As Integer
        Public Property CITResponseTime() As Integer
            Get
                Return _CITResponseTime
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CITResponseTime", _CITResponseTime, value)
            End Set
        End Property
        Private _CITReplyTime As Integer
        Public Property CITReplyTime() As Integer
            Get
                Return _CITReplyTime
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CITReplyTime", _CITReplyTime, value)
            End Set
        End Property

        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)>
        Public Property Notes() As String
            Get
                Return GetDelayedPropertyValue(Of String)("Notes")
            End Get
            Set(ByVal value As String)
                SetDelayedPropertyValue("Notes", value)
            End Set
        End Property
        Private _triagenotes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)>
        Public Property TriageNotes() As String
            Get
                Return GetDelayedPropertyValue(Of String)("TriageNotes")
            End Get
            Set(ByVal value As String)
                SetDelayedPropertyValue("TriageNotes", value)
            End Set
        End Property
#Region "CV"
        Private _professionalQualifications As XPDelayedProperty = New XPDelayedProperty()
        <Size(SizeAttribute.Unlimited)>
        Public Property ProfessionalQualifications() As String
            Get
                Return CType(_professionalQualifications.Value, String)
            End Get
            Set(ByVal value As String)
                _professionalQualifications.Value = value
            End Set
        End Property
        Private _qualifications As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_qualifications", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property Qualifications() As String
            Get
                Return CType(_qualifications.Value, String)
            End Get
            Set(ByVal value As String)
                _qualifications.Value = value
            End Set
        End Property
        Private _researchInterests As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_researchInterests", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property ResearchInterests() As String
            Get
                Return CType(_researchInterests.Value, String)
            End Get
            Set(ByVal value As String)
                _researchInterests.Value = value
            End Set
        End Property
        Private _clinicalInterests As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_clinicalInterests", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property ClinicalInterests() As String
            Get
                Return CType(_clinicalInterests.Value, String)
            End Get
            Set(ByVal value As String)
                _clinicalInterests.Value = value
            End Set
        End Property
        Private _positionsHeld As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_positionsHeld", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property PositionsHeld() As String
            Get
                Return CType(_positionsHeld.Value, String)
            End Get
            Set(ByVal value As String)
                _positionsHeld.Value = value
            End Set
        End Property
        Private _medicoLegal As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_medicoLegal", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property MedicoLegal() As String
            Get
                Return CType(_medicoLegal.Value, String)
            End Get
            Set(ByVal value As String)
                _medicoLegal.Value = value
            End Set
        End Property
        Private _cvgeneral As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_cvgeneral", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property CVGeneral() As String
            Get
                Return CType(_cvgeneral.Value, String)
            End Get
            Set(ByVal value As String)
                _cvgeneral.Value = value
            End Set
        End Property
        Private _cvadditionalInfo As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_cvadditionalInfo", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property CVAdditionalNotes() As String
            Get
                Return CType(_cvadditionalInfo.Value, String)
            End Get
            Set(ByVal value As String)
                _cvadditionalInfo.Value = value
            End Set
        End Property
        Private _cvfile As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_cvfile", "CVFile", True), Size(120)>
        Public Property CVFile() As String
            Get
                Return CType(_cvfile.Value, String)
            End Get
            Set(ByVal value As String)
                _cvfile.Value = value
            End Set
        End Property
#End Region
        <PersistentAlias("isnull(FirstName,'') + ' ' + isnull(SurName,'')")>
        Public ReadOnly Property SearchName() As String
            Get
                Return CType(EvaluateAlias("SearchName"), String)
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return GetFullName(Title, FirstName, Initials, SurName)
        End Function
        Public ReadOnly Property TitledName() As String
            Get
                Return GetFullName(Title, FirstName, SurName, Nothing)
            End Get
        End Property
        Public Shared Function GetFullName(ByVal title As String, ByVal first As String, ByVal second As String, ByVal third As String) As String
            Dim ret As String
            If Object.Equals(title, Nothing) Then
                ret = String.Empty
            Else
                ret = title.Trim()
            End If
            Dim firstTrim As String
            If Object.Equals(first, Nothing) Then
                firstTrim = String.Empty
            Else
                firstTrim = first.Trim
            End If
            If firstTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & firstTrim
                Else
                    ret &= (" ") & firstTrim
                End If
            End If
            Dim secondTrim As String
            If Object.Equals(second, Nothing) Then
                secondTrim = String.Empty
            Else
                secondTrim = second.Trim()
            End If
            If secondTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & secondTrim
                Else
                    ret &= (" ") & secondTrim
                End If
            End If
            Dim thirdTrim As String
            If Object.Equals(third, Nothing) Then
                thirdTrim = String.Empty
            Else
                thirdTrim = third.Trim()
            End If
            If thirdTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & thirdTrim
                Else
                    ret &= (" ") & thirdTrim
                End If
            End If
            Return ret
        End Function
        Public Overridable ReadOnly Property BookingPhones() As String
            Get
                Return GetBookingPhones()
            End Get
        End Property
        Private Function GetBookingPhones() As String

            Dim ret As String = String.Empty
            If ccBookingEmail = True Then
                If Object.Equals(Email, Nothing) Then
                    ret = String.Empty
                Else
                    ret = Email.Trim()
                End If
            End If
            For Each _staff As ConsultantStaff In Staff
                If _staff.ccBookingEmail = True Then
                    If Not Object.Equals(_staff.Phone, Nothing) Then
                        ret &= IIf(ret IsNot String.Empty, ";", "") & _staff.Phone.Trim()
                    End If
                End If
            Next
            Return ret

        End Function

        Public Overridable ReadOnly Property BookingEmails() As String
            Get
                Return GetBookingEmails()
            End Get
        End Property
        Private Function GetBookingEmails() As String

            Dim ret As String = String.Empty
            If ccBookingEmail = True Then
                If Object.Equals(Email, Nothing) Then
                    ret = String.Empty
                Else
                    ret = Email.Trim()
                End If
            End If
            For Each _staff As ConsultantStaff In Staff
                If _staff.ccBookingEmail = True Then
                    If Not Object.Equals(_staff.Email, Nothing) Then
                        ret &= IIf(ret IsNot String.Empty, ";", "") & _staff.Email.Trim()
                    End If
                End If
            Next
            Return ret

        End Function
        Public Overridable ReadOnly Property InvoiceEmails() As String
            Get
                Return GetInvoiceEmails()
            End Get
        End Property
        Private Function GetInvoiceEmails() As String

            Dim ret As String = String.Empty
            If ccInvoiceEmail = True Then
                If Object.Equals(Email, Nothing) Then
                    ret = String.Empty
                Else
                    ret = Email.Trim()
                End If
            End If
            For Each _staff As ConsultantStaff In Staff
                If _staff.ccInvoiceEmail = True Then
                    If Not Object.Equals(_staff.Email, Nothing) Then
                        ret &= IIf(ret IsNot String.Empty, ";", "") & _staff.Email.Trim()
                    End If
                End If
            Next
            Return ret

        End Function

        Public Overridable ReadOnly Property ShortName() As String
            Get
                Return GetFullName(Title, Left(FirstName, 1), SurName, Nothing)
            End Get
        End Property
        Public Overridable ReadOnly Property FullName() As String
            Get
                Return GetFullName(Title, FirstName, Initials, SurName)
            End Get
        End Property
        Public ReadOnly Property FullNameSorting() As String
            Get
                Return GetFullName(SurName, Title, FirstName, Initials)
            End Get
        End Property
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
        Public Function GetFullAddressLine() As String
            Dim ret As String = String.Empty
            If Addr1 IsNot Nothing And Addr1 IsNot String.Empty Then
                ret = String.Format("{0}", Addr1)
            End If
            If Addr2 IsNot Nothing And Addr2 IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, Addr2)
            End If
            If Addr3 IsNot Nothing And Addr3 IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, Addr3)
            End If
            If City IsNot Nothing And City IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, City)
            End If
            If County IsNot Nothing And County IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, County)
            End If
            If PostCode IsNot Nothing And PostCode IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, PostCode)
            End If
            Return ret
        End Function
        Public Function GetFullAddressBlock() As String
            Dim ret As String = String.Empty
            If Addr1 IsNot Nothing And Addr1 IsNot String.Empty Then
                ret = String.Format("{0}", Addr1)
            End If
            If Addr2 IsNot Nothing And Addr2 IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, Addr2)
            End If
            If Addr3 IsNot Nothing And Addr3 IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, Addr3)
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
        Public ReadOnly Property AvailableHospitals(_attrib As String, Optional _currentHospital As Integer = 0) As XPDataView
            Get
                Return GetAvailableHospitals(_attrib, _currentHospital)
            End Get
        End Property
        Public ReadOnly Property ExcludedHospitals(_attrib As String) As XPDataView
            Get
                Return GetExcludedHospitals(_attrib)
            End Get
        End Property
        Private Function GetAvailableHospitals(_attrib As String, Optional _currentHospital As Integer = 0) As XPDataView

            Dim _sql As String = ""


            _sql = "SELECT DISTINCT Hospital.Oid, Hospital.HospitalName,ConsultantHospital.Comment,Hospital.BookingNumber " _
                & "FROM ConsultantHospital INNER JOIN " _
                & "Hospital ON Hospital.OID = ConsultantHospital.Hospital  "

            Dim _where As String = String.Format("where ConsultantHospital.Consultant = {0} and Hospital.HospitalType in(1,6,7,8,9) ", Oid)
            If _currentHospital > 0 Then
                _where &= String.Format("and Hospital.oid <> {0} ", _currentHospital)
            End If

            If Not String.IsNullOrWhiteSpace(_attrib) Then
                _where &= "and (exists(SELECT A.OID, A.Attribute FROM  HospitalAttribute AS HA INNER JOIN " _
                & "Attrib as A ON HA.Attrib = A.OID " _
                & String.Format("WHERE  HA.Hospital = Hospital.OID and A.Attribute= '{0}'))", _attrib)
            End If

            _sql &= _where

            Dim dv As New XPDataView()
            Dim data As SelectedData = Session.ExecuteQueryWithMetadata(_sql)
            For Each row As SelectStatementResultRow In data.ResultSet(0).Rows
                dv.AddProperty(DirectCast(row.Values(0), String), DBColumn.[GetType](DirectCast([Enum].Parse(GetType(DBColumnType), DirectCast(row.Values(2), String)), DBColumnType)))
            Next
            dv.LoadData(New SelectedData(data.ResultSet(1)))

            Return dv

        End Function
        Private Function GetExcludedHospitals(_attrib As String) As XPDataView

            If String.IsNullOrEmpty(_attrib) Then
                _attrib = "........."
            End If
            Dim _sql As String = ""

            _sql = "Select Distinct Hospital.HospitalName, ConsultantHospital.Comment,Hospital.BookingNumber " _
                & "FROM HospitalAttribute INNER JOIN " _
                & "Attrib ON HospitalAttribute.Attrib = Attrib.OID INNER JOIN " _
                & "Hospital ON HospitalAttribute.Hospital = Hospital.OID INNER JOIN " _
                & "ConsultantHospital ON Hospital.OID = ConsultantHospital.Hospital " _
                & String.Format("WHERE (Attrib.Attribute <> '{0}') AND (ConsultantHospital.Consultant = {1})", _attrib, Oid) _
                & "And Not exists (select HospitalAttribute.hospital from HospitalAttribute  INNER JOIN " _
                & "Attrib ON HospitalAttribute.Attrib = Attrib.OID " _
                & String.Format("WHERE HospitalAttribute.Hospital = Hospital.OID  and Attrib.Attribute <> '{0}')", _attrib)

            Dim dv As New XPDataView()
            Dim data As SelectedData = Session.ExecuteQueryWithMetadata(_sql)
            For Each row As SelectStatementResultRow In data.ResultSet(0).Rows
                dv.AddProperty(DirectCast(row.Values(0), String), DBColumn.[GetType](DirectCast([Enum].Parse(GetType(DBColumnType), DirectCast(row.Values(2), String)), DBColumnType)))
            Next
            dv.LoadData(New SelectedData(data.ResultSet(1)))

            Return dv
        End Function
        <NonPersistent>
        Public ReadOnly Property ClearPassword As String
            Get
                If Not String.IsNullOrEmpty(Password) Then
                    Return PasswordHelper.Decode(EntityType.Consultant, Password)
                Else
                    Return String.Empty
                End If
            End Get
        End Property
        Public ReadOnly Property SpecialismList() As String
            Get
                Dim ret As String = String.Empty
                For Each oSpecialism As Specialism In Specialisms
                    ret &= String.Format("{0},", oSpecialism.Specialism)
                Next
                If ret.Length > 0 Then
                    ret = ret.ToString.Substring(0, ret.Length - 1)
                End If
                Return ret
            End Get
        End Property
        <NonPersistent>
        Public ReadOnly Property FirstReferral As Date
            Get
                Return CDate(Session.Evaluate(GetType(Referral), CriteriaOperator.Parse("Min(ReferralDate)"), CriteriaOperator.Parse("Consultant= ?", Oid)))
            End Get
        End Property
        <NonPersistent>
        Public ReadOnly Property LastReferral As Date
            Get
                Return CDate(Session.Evaluate(GetType(Referral), CriteriaOperator.Parse("Max(ReferralDate)"), CriteriaOperator.Parse("Consultant= ?", Oid)))
            End Get
        End Property
        <NonPersistent>
        Public ReadOnly Property NoReferrals As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Referral), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Consultant= ?", Oid)))
            End Get
        End Property
        <NonPersistent>
        Public ReadOnly Property NoReferralsThisYear As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Referral), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Consultant= ? and ReferralDate > ?", Oid, DateTime.Today.AddYears(-1))))
            End Get
        End Property
        <NonPersistent>
        Public ReadOnly Property AvgCost As Double
            Get
                Return CDbl(Session.Evaluate(GetType(ReferralTreatment), CriteriaOperator.Parse("Sum(Cost)"), CriteriaOperator.Parse("Consultant= ?", Oid)))
            End Get
        End Property
        <NonPersistent>
        Public ReadOnly Property AvgCostThisYear As Double
            Get
                Return CDbl(Session.Evaluate(GetType(ReferralTreatment), CriteriaOperator.Parse("Sum(Cost)"), CriteriaOperator.Parse("Consultant= ? and InvoiceDate > ?", Oid, DateTime.Today.AddYears(-1))))
            End Get
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
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        Private fmodifiedAt As DateTime
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property
    End Class
    Public Class ConsultantCost
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
        Dim _consultant As Consultant
        <Association("ConsultantCosts")>
        Public Property Consultant() As Consultant
            Get
                Return _consultant
            End Get
            Set(ByVal value As Consultant)
                SetPropertyValue(Of Consultant)("Consultant", _consultant, value)
            End Set
        End Property
        Dim _insurerCostTable As InsurerCostTable
        Public Property InsurerCostTable() As InsurerCostTable
            Get
                Return _insurerCostTable
            End Get
            Set(ByVal value As InsurerCostTable)
                SetPropertyValue(Of InsurerCostTable)("InsurerCostTable", _insurerCostTable, value)
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
        Private _insurerCost As Double
        Public Property insurerCost() As Double
            Get
                Return _insurerCost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("insurerCost", _insurerCost, value)
            End Set
        End Property
        Private _consultantCost As Double
        Public Property ConsultantCost() As Double
            Get
                Return _consultantCost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("ConsultantCost", _consultantCost, value)
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
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        Private fmodifiedAt As DateTime
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property

    End Class
    Public Class ConsultantStaff
        Inherits XPObject
        Private ffirstName, flastName, fposition, femail As String
        Private fsalutation As String
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
        Private _ccbookingEmail As Boolean
        Public Property ccBookingEmail() As Boolean
            Get
                Return _ccbookingEmail
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ccBookingEmail", _ccbookingEmail, value)
            End Set
        End Property
        Private _ccinvoiceEmail As Boolean
        Public Property ccInvoiceEmail() As Boolean
            Get
                Return _ccinvoiceEmail
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ccInvoiceEmail", _ccinvoiceEmail, value)
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
        Private _consultant As Consultant
        <Association("ConsultantStaff")>
        Public Property Consultant() As Consultant
            Get
                Return _consultant
            End Get
            Set(ByVal value As Consultant)
                SetPropertyValue(Of Consultant)("Consultant", _consultant, value)
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
        <MemberDesignTimeVisibility(False)> <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)> _
        Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)> <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)> _
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
    Public Class ConsultantCV
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _consultant As Consultant
        Public Property Consultant() As Consultant
            Get
                Return _consultant
            End Get
            Set(ByVal value As Consultant)
                SetPropertyValue(Of Consultant)("Consultant", _consultant, value)
            End Set
        End Property
        Private _professionalQualifications As String
        <Size(SizeAttribute.Unlimited)>
        Public Property ProfessionalQualifications() As String
            Get
                Return _professionalQualifications
            End Get
            Set(ByVal value As String)
                _yearqualified.Value = value
            End Set
        End Property
        Private _yearqualified As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_yearqualified", "CV", True), Size(10)>
        Public Property YearQualified() As String
            Get
                Return CType(_yearqualified.Value, String)
            End Get
            Set(ByVal value As String)
                _yearqualified.Value = value
            End Set
        End Property
        Private _qualifications As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_qualifications", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property Qualifications() As String
            Get
                Return _qualifications.Value
            End Get
            Set
                _qualifications.Value = Value
            End Set
        End Property
        Private _researchInterests As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_researchInterests", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property ResearchInterests() As String
            Get
                Return _researchInterests.Value
            End Get
            Set
                _researchInterests.Value = Value
            End Set
        End Property
        Private _clinicalInterests As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_clinicalInterests", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property ClinicalInterests() As String
            Get
                Return _clinicalInterests.Value
            End Get
            Set
                _clinicalInterests.Value = Value
            End Set
        End Property
        Private _positionsHeld As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_positionsHeld", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property PositionsHeld() As String
            Get
                Return _positionsHeld.value
            End Get
            Set
                _positionsHeld.Value = Value
            End Set
        End Property
        Private _medicoLegal As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_medicoLegal", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property MedicoLegal() As String
            Get
                Return _medicoLegal.Value
            End Get
            Set
                _medicoLegal.Value = Value
            End Set
        End Property
        Private _notes As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_notes", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property Notes() As String
            Get
                Return _notes.value
            End Get
            Set
                _notes.Value = Value
            End Set
        End Property
        Private _additionalInfo As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_additionalInfo", "CV", True), Size(SizeAttribute.Unlimited)>
        Public Property AdditionalInfo() As String
            Get
                Return _additionalInfo.Value
            End Get
            Set
                _additionalInfo.Value = Value
            End Set
        End Property
        Private _cvfile As XPDelayedProperty = New XPDelayedProperty()
        <Delayed("_cvfile", "CVFile", True), Size(120)>
        Public Property CVFile() As String
            Get
                Return _cvfile.Value
            End Get
            Set
                _cvfile.Value = Value
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0} (CV)", Consultant.FullName)
        End Function
    End Class
    Public Class PSP
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _psp As String
        <Size(40)>
        Public Property PSP() As String
            Get
                Return _psp
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PSP", _psp, value)
            End Set
        End Property
        <Association("PSPConsultants")> _
        Public ReadOnly Property Consultants() As XPCollection(Of Consultant)
            Get
                Return GetCollection(Of Consultant)("Consultants")
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", PSP)
        End Function
    End Class
End Namespace