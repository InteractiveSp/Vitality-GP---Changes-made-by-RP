Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports System.Drawing
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraNavBar
Imports DevExpress.Utils.Serializing.Helpers
Imports DevExpress.XtraScheduler.Xml
Imports System.Runtime.CompilerServices
Imports DevExpress.XtraEditors.DXErrorProvider
Imports System.Data
Imports Alliance.Data
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data
  
    Public Class SystemConfig
        Inherits XPObject
        Private fcompanyName, faddress1, faddress2, faddress3, faddress4, fpostCode, faddress As String
        Private ftelephone, ffax, femailAddress, fwebSite As String
        Private _cITEMailAddress As String
        Private fmailMergeDesigns, fmailMergeFolder, fattachmentsFolder, fdocumentsFolder, freportsFolder As String
        Private faccountsEnabled, fcompulsoryRef As Boolean
        Private fcreatedBy As GlobalUser
        Private fcreatedAt As DateTime
        Private fmodifiedBy As GlobalUser
        Private fmodifiedAt As DateTime
        Public Event Saved As EventHandler

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            If CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
                ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
                ModifiedAt = DateTime.Now
            End If
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) Then
                If CreatedBy Is Nothing Then
                    CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                    CreatedAt = DateTime.Now
                End If
            End If

            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now

            If (Not Object.Equals(SavedEvent, Nothing)) Then
                RaiseEvent Saved(Me, New EventArgs())
            End If
        End Sub

        Public Overridable ReadOnly Property AllowDelete() As Boolean
            Get
                Return True
            End Get
        End Property
        Protected ReadOnly Property GeneratedIdType() As String
            Get
                Return "System"
            End Get
        End Property

        <Size(30)> <MemberDesignTimeVisibility(True)> _
        Public Property CompanyName() As String
            Get
                Return fcompanyName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CompanyName", fcompanyName, value)
            End Set
        End Property
        <Size(30)> <MemberDesignTimeVisibility(True)> _
        Public Property Address1() As String
            Get
                Return faddress1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Address1", faddress1, value)
            End Set
        End Property
        <Size(30)> <MemberDesignTimeVisibility(True)> _
        Public Property Address2() As String
            Get
                Return faddress2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Address2", faddress2, value)
            End Set
        End Property
        <Size(30)> <MemberDesignTimeVisibility(True)> _
        Public Property Address3() As String
            Get
                Return faddress3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Address3", faddress3, value)
            End Set
        End Property
        <Size(30)> <MemberDesignTimeVisibility(True)> _
        Public Property Address4() As String
            Get
                Return faddress4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Address4", faddress4, value)
            End Set
        End Property
        <Size(30)> <MemberDesignTimeVisibility(True)> _
        Public Property PostCode() As String
            Get
                Return fpostCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", fpostCode, value)
            End Set
        End Property
        Public ReadOnly Property CompanyAddress() As String
            Get
                faddress = CStr(IIf(Address1 <> "", Address1 & " ", ""))
                faddress = faddress & CStr(IIf(Address2 <> "", Address2 & " ", ""))
                faddress = faddress & CStr(IIf(Address3 <> "", Address3 & " ", ""))
                faddress = faddress & CStr(IIf(Address4 <> "", Address4 & " ", ""))
                faddress = faddress & CStr(IIf(PostCode <> "", PostCode & " ", ""))
                Return faddress
            End Get
        End Property
        <Size(20)> <MemberDesignTimeVisibility(True)> _
        Public Property Telephone() As String
            Get
                Return ftelephone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Telephone", ftelephone, value)
            End Set
        End Property
        <Size(20)> <MemberDesignTimeVisibility(True)> _
        Public Property Fax() As String
            Get
                Return ffax
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Fax", ffax, value)
            End Set
        End Property
        <Size(120)> <MemberDesignTimeVisibility(True)>
        Public Property EmailAddress() As String
            Get
                Return femailAddress
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EmailAddress", femailAddress, value)
            End Set
        End Property
        Private _tafEmailAddress As String
        <Size(120)> <MemberDesignTimeVisibility(True)>
        Public Property TafEmailAddress() As String
            Get
                Return _tafEmailAddress
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TafEmailAddress", _tafEmailAddress, value)
            End Set
        End Property
        <Size(120)> <MemberDesignTimeVisibility(True)>
        Public Property CITEMailAddress() As String
            Get
                Return _cITEMailAddress
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CITEMailAddress", _cITEMailAddress, value)
            End Set
        End Property
        Private _modificationsEmailAddress As String
        <Size(120)> <MemberDesignTimeVisibility(True)>
        Public Property ModificationsEmailAddress() As String
            Get
                Return _modificationsEmailAddress
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ModificationsEmailAddress", _modificationsEmailAddress, value)
            End Set
        End Property
        <Size(120)> <MemberDesignTimeVisibility(True)> _
        Public Property WebSite() As String
            Get
                Return fwebSite
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WebSite", fwebSite, value)
            End Set
        End Property
        Private _eMail As String
        <Size(120)> <MemberDesignTimeVisibility(True)> _
        Public Property Email() As String
            Get
                Return _eMail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", _eMail, value)
            End Set
        End Property
        <Size(255)> <Browsable(False)> <MemberDesignTimeVisibility(False)> _
        Public Property MailMergeFolder() As String
            Get
                Return fmailMergeFolder
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MailMergeFolder", fmailMergeFolder, value)
            End Set
        End Property
        <Size(255)> <Browsable(False)> <MemberDesignTimeVisibility(False)> _
        Public Property MergeDesignsFolder() As String
            Get
                Return fmailMergeDesigns
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MergeDesigns", fmailMergeDesigns, value)
            End Set
        End Property
        <Size(255)> <Browsable(False)> <MemberDesignTimeVisibility(False)> _
        Public Property AttachmentsFolder() As String
            Get
                Return fattachmentsFolder
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AttachmentsFolder", fattachmentsFolder, value)
            End Set
        End Property
        <Size(255)> <Browsable(False)> <MemberDesignTimeVisibility(False)> _
        Public Property DocumentsFolder() As String
            Get
                Return fdocumentsFolder
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DocumentsFolder", fdocumentsFolder, value)
            End Set
        End Property
        <Size(255)> <Browsable(False)> <MemberDesignTimeVisibility(False)> _
        Public Property ReportsFolder() As String
            Get
                Return freportsFolder
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReportsFolder", freportsFolder, value)
            End Set
        End Property
        <Browsable(False)> <MemberDesignTimeVisibility(False)> _
        Public Property AccountsEnabled() As Boolean
            Get
                Return faccountsEnabled
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("AccountsEnabled", faccountsEnabled, value)
            End Set
        End Property
        Private _visitorMode As Boolean
        <Browsable(False)> <MemberDesignTimeVisibility(False)> _
        Public Property VisitorMode() As Boolean
            Get
                Return _visitorMode
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("VisitorMode", _visitorMode, value)
            End Set
        End Property
        <Browsable(False)> <MemberDesignTimeVisibility(False)> _
        Public Property CreatedBy() As GlobalUser
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
            End Set
        End Property
        <Browsable(False)> <MemberDesignTimeVisibility(False)> _
        Public Property CreatedAt() As DateTime
            Get
                Return fcreatedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
            End Set
        End Property
        <Browsable(False)> <MemberDesignTimeVisibility(False)> <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)> _
        Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        <Browsable(False)> <MemberDesignTimeVisibility(False)> <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)> _
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property

    End Class
    Public Class Salutation
        Inherits XPObject
        Private fname As String

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
            Me.Name = name
        End Sub
        <Size(15)> _
        Public Property Name() As String
            Get
                Return fname
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Name", fname, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Name)
        End Function
    End Class
    Public Class Gender
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _genderID As Char
        Public Property GenderID() As Char
            Get
                Return _genderID
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("GenderID", _genderID, value)
            End Set
        End Property
        Private _gender As String
        <Size(15)> _
        Public Property Gender() As String
            Get
                Return _gender
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Gender", _gender, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", _gender)
        End Function
    End Class
    Public Class RecentItem
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()

            User = ProjectCurrentUser.GetGlobalUser(Session)

        End Sub
        Private fUser As GlobalUser
        Public Property User() As GlobalUser
            Get
                Return fUser
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("User", fUser, value)
            End Set
        End Property
        Private _accessed As DateTime
        Public Property Accessed() As DateTime
            Get
                Return _accessed
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Accessed", _accessed, value)
            End Set
        End Property
        Private fEntityType As EntityType
        Public Property EntityType() As EntityType
            Get
                Return fEntityType
            End Get
            Set(ByVal value As EntityType)
                SetPropertyValue(Of EntityType)("EntityType", fEntityType, value)
            End Set
        End Property
        Private fEntityOid As Integer
        Public Property EntityOid() As Integer
            Get
                Return fEntityOid
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("EntityOid", fEntityOid, value)
            End Set
        End Property
        Private fDescription As String
        <Size(150)> _
        Public Property Description() As String
            Get
                Return fDescription
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", fDescription, value)
            End Set
        End Property
    End Class
    Public Class TaskCategory
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetCurrentUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private fTaskCategory As String
        <Size(35)> _
        Public Property TaskCategory() As String
            Get
                Return fTaskCategory
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TaskCategory", fTaskCategory, value)
            End Set
        End Property
        Private fSequence As Integer
        Public Property Sequence() As Integer
            Get
                Return fSequence
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Sequence", fSequence, value)
            End Set
        End Property
        Private fcreatedBy As User
        Public Property CreatedBy() As User
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("CreatedBy", fcreatedBy, value)
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
        Private fmodifiedBy As User
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
                Public Property ModifiedBy() As User
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("ModifiedBy", fmodifiedBy, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("{0}", TaskCategory)
        End Function
    End Class
    Public Class PrintRequest
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
            End If
            If Session.IsNewObject(Me) And CreatedAt = DateTime.MinValue Then
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _printRequestType As ePrintRequestType
        Public Property PrintRequestType() As ePrintRequestType
            Get
                Return _printRequestType
            End Get
            Set(ByVal value As ePrintRequestType)
                SetPropertyValue(Of ePrintRequestType)("PrintRequestType", _printRequestType, value)
            End Set
        End Property
        Private _ObjectOid As Integer
        Public Property ObjectOid() As Integer
            Get
                Return _ObjectOid
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ObjectOid", _ObjectOid, value)
            End Set
        End Property
        Private _beneficiary As Beneficiary
        Public Property Beneficiary() As Beneficiary
            Get
                Return _beneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", _beneficiary, value)
            End Set
        End Property
        Private _printed As Boolean
        Public Property Printed() As Boolean
            Get
                Return _printed
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Printed", _printed, value)
            End Set
        End Property
        Private _printedBy As GlobalUser
        Public Property PrintedBy() As GlobalUser
            Get
                Return _printedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("PrintedBy", _printedBy, value)
            End Set
        End Property
        Private _batchno As Integer
        Public Property BatchNo() As Integer
            Get
                Return _batchno
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BatchNo", _batchno, value)
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
    Public Class Communication
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal subject As String)
            Me.New(session)
            Me.Subject = subject
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
        Private _date As DateTime
        Public Property [Date]() As DateTime
            Get
                Return _date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("Date", _date, value)
            End Set
        End Property
        Private _type As eCommunicationType
        Public Property Type() As eCommunicationType
            Get
                Return _type
            End Get
            Set(ByVal value As eCommunicationType)
                SetPropertyValue("Type", _type, value)
            End Set
        End Property
        Private _subject As String
        Public Property Subject() As String
            Get
                Return _subject
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Subject", _subject, value)
            End Set
        End Property
        Private _text As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Text", _text, value)
            End Set
        End Property
        Private _fulltext As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property FullText() As String
            Get
                Return _fulltext
            End Get
            Set(ByVal value As String)
                SetPropertyValue("FullText", _fulltext, value)
            End Set
        End Property
        Private fMailTo As String
        <Size(200)> _
        Public Property [MailTo]() As String
            Get
                Return fMailTo
            End Get
            Set(ByVal value As String)
                SetPropertyValue("MailTo", fMailTo, value)
            End Set
        End Property
        Private fMailFrom As String
        <Size(100)> _
        Public Property [From]() As String
            Get
                Return fMailFrom
            End Get
            Set(ByVal value As String)
                SetPropertyValue("From", fMailFrom, value)
            End Set
        End Property
        Public ReadOnly Property SubjectDisplayText() As String ' string.Format("{1}{0}", Subject, IsReply ? "RE: " : ""); } }
            Get
                Return Subject
            End Get
        End Property
        Private _plaintext As String
        Public ReadOnly Property PlainText() As String
            Get
                Return GetPlainText()
            End Get
        End Property

        Private Function GetPlainText() As String
            If String.IsNullOrEmpty(_plaintext) And _text IsNot Nothing Then
                _plaintext = _text
            End If
            Return _plaintext
        End Function
        Public Sub SetPlainText(ByVal text As String)
            _plaintext = text
        End Sub
        Private _finish As DateTime
        Public Property Finish() As DateTime
            Get
                Return _finish
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("Finish", _finish, value)
            End Set
        End Property

        Private _allDay As Boolean
        Public Property AllDay() As Boolean
            Get
                Return _allDay
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue("AllDay", _allDay, value)
            End Set
        End Property
        Private _taskLabel As eTaskLabel
        Public Property TaskLabel() As eTaskLabel
            Get
                Return _taskLabel
            End Get
            Set(ByVal value As eTaskLabel)
                SetPropertyValue("TaskLabel", _taskLabel, value)
            End Set
        End Property
        Private _location As String
        Public Property Location() As String
            Get
                Return _location
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Location", _location, value)
            End Set
        End Property
        Private _recurrence As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Recurrence() As String
            Get
                Return _recurrence
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Recurrence", _recurrence, value)
            End Set
        End Property
        Private _reminder As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Reminder() As String
            Get
                Return _reminder
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Reminder", _reminder, value)
            End Set
        End Property
        Private _status As Integer
        Public Property Status() As Integer
            Get
                Return _status
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("Status", _status, value)
            End Set
        End Property
        ' Appointment.Type
        Private _appointmentType As Integer
        Public Property AppointmentType() As Integer
            Get
                Return _appointmentType
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("AppointmentType", _appointmentType, value)
            End Set
        End Property
        Private _resourceId As Integer
        Public Property ResourceId() As Integer
            Get
                Return _resourceId
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("ResourceId", _resourceId, value)
            End Set
        End Property
        Private _regarding As Communication
        Public Property Regarding As Communication
            Get
                Return _regarding
            End Get
            Set(ByVal value As Communication)
                SetPropertyValue("Regarding", _regarding, value)
            End Set
        End Property
        Private _priority As Integer
        Public Property Priority() As Integer
            Get
                Return _priority
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Priority", _priority, value)
            End Set
        End Property
        Private fentitytype As EntityType
        Public Property EntityType() As EntityType
            Get
                Return fentitytype
            End Get
            Set(ByVal value As EntityType)
                SetPropertyValue(Of EntityType)("EntityType", fentitytype, value)
            End Set
        End Property
        Private _beneficiary As Beneficiary
        <Association("Beneficiary-Communications")> _
        Public Property Beneficiary() As Beneficiary
            Get
                Return _beneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", _beneficiary, value)
            End Set
        End Property
        Private _claim As Claim
        <Association("Claim-Communications")> _
        Public Property Claim() As Claim
            Get
                Return _claim
            End Get
            Set(ByVal value As Claim)
                SetPropertyValue(Of Claim)("Claim", _claim, value)
            End Set
        End Property
        Private _authorisation As Authorisation
        <Association("Authorisation-Communications")> _
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _referral As Referral
        <Association("Referral-Communications")> _
        Public Property Referral() As Referral
            Get
                Return _referral
            End Get
            Set(ByVal value As Referral)
                SetPropertyValue(Of Referral)("Referral", _referral, value)
            End Set
        End Property
        Private _patient As Patient
        <Association("Patient-Communication")> _
        Public Property Patient() As Patient
            Get
                Return _patient
            End Get
            Set(ByVal value As Patient)
                SetPropertyValue(Of Patient)("Patient", _patient, value)
            End Set
        End Property
        Private fCRMID As Integer
        Public Property CRMID() As Integer
            Get
                Return fCRMID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CRMID", fCRMID, value)
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
        Public Sub Assign(ByVal task As Communication)
            Me.Subject = task.Subject
            '            Me.Priority = task.Priority
            '           Me.PercentComplete = task.PercentComplete
            Me.CreatedAt = task.CreatedAt
            '          Me.fstartdate = task.StartDate
            'Me.DueDate = task.DueDate
            '            Me.CompletedDate = task.CompletedDate
            '            Me.Note = task.Note
            Me.TaskLabel = task.TaskLabel
            Me.Status = task.Status
            '            Me.AssignTo = task.AssignTo
        End Sub
        Public Function Clone() As Communication
            Dim task As New Communication(Session, Me.Subject)
            task.Assign(Me)
            Return task
        End Function
        Public ReadOnly Property DueIn() As String
            Get
                If Finish > DateTime.MinValue Then
                    Dim oDays As Integer = (Date.Today.Subtract(Finish)).Days
                    If oDays > 0 Then
                        Return String.Format("{0} day{1} overdue", oDays, If(oDays > 1, "s", String.Empty))
                    End If
                    If oDays = 0 Then
                        Return "Today"
                    End If
                    If oDays < 0 Then
                        Return String.Format("{0} day{1}", Math.Abs(oDays), If(oDays < 11, "s", String.Empty))
                    End If
                End If
                Return String.Empty
            End Get
        End Property
        Friend ReadOnly Property TimeDiff() As TimeSpan
            Get
                Return (Date.Now.Subtract(CreatedAt))
            End Get
        End Property
        Public ReadOnly Property Overdue() As Boolean
            Get
                If Status = eTaskStatus.Completed OrElse (Not Finish = DateTime.MinValue) Then
                    Return False
                End If
                Dim dDate As Date = Finish.AddDays(1)
                If Date.Now >= dDate Then
                    Return True
                End If
                Return False
            End Get
        End Property
        Public Property Complete() As Boolean
            Get
                Return Status = eTaskStatus.Completed
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    Status = eTaskStatus.Completed
                Else
                    Status = eTaskStatus.NotStarted
                End If
            End Set
        End Property
        Private fpercentComplete As Integer
        Public Property PercentComplete() As Integer
            Get
                Return fpercentComplete
            End Get
            Set(ByVal value As Integer)
                If value < 0 Then
                    value = 0
                End If
                If value > 100 Then
                    value = 100
                End If
                If fpercentComplete = value Then
                    Return
                End If
                fpercentComplete = value
                SetPropertyValue(Of Integer)("PercentComplete", fpercentComplete, value)
                If fpercentComplete = 100 Then
                    Status = eTaskStatus.Completed
                End If
                If fpercentComplete > 0 AndAlso fpercentComplete < 100 Then
                    Status = eTaskStatus.InProgress
                End If
            End Set
        End Property
    End Class
    Public Class ColorValueConverter
        Inherits ValueConverter
        Public Overrides ReadOnly Property StorageType() As Type
            Get
                Return GetType(Int32)
            End Get
        End Property
        Public Overrides Function ConvertToStorageType(ByVal value As Object) As Object
            If Not (TypeOf value Is Color) Then
                Return Nothing
            End If
            Return (CType(value, Color)).ToArgb()
        End Function
        Public Overrides Function ConvertFromStorageType(ByVal value As Object) As Object
            If Not (TypeOf value Is Int32) Then
                Return Nothing
            End If
            Return Color.FromArgb(CInt(Fix(value)))
        End Function
    End Class
    Public Class ControlLayout
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            User = ProjectCurrentUser.GetGlobalUser(Session)
        End Sub
        Private _control As String
        Public Property ControlName() As String
            Get
                Return _control
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ControlName", _control, value)
            End Set
        End Property
        Private _description As String
        <Size(30)> _
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", _description, value)
            End Set
        End Property
        Private _isPublic As Boolean
        Public Property IsShared() As Boolean
            Get
                Return _isPublic
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsPublic", _isPublic, value)
            End Set
        End Property
        Private fUser As GlobalUser
        Public Property User() As GlobalUser
            Get
                Return fUser
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("User", fUser, value)
            End Set
        End Property
        <DevExpress.Xpo.ValueConverter(GetType(MemoryStreamValueConverter))> _
        Public Property ControlLayout() As MemoryStream
            Get
                Return GetPropertyValue(Of MemoryStream)("ControlLayout")
            End Get
            Set(ByVal value As MemoryStream)
                SetPropertyValue(Of MemoryStream)("ControlLayout", value)
            End Set
        End Property
    End Class
End Namespace