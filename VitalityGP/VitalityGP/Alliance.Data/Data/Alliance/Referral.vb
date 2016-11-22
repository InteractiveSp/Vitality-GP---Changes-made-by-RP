Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports System.Drawing
Imports Alliance.Data.ConnectionHelper
Imports DevExpress.Data.Filtering
Imports Alliance.Shared

Namespace Alliance.Data
 
    Public Class Referral
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
            'If miPostCode.GetOldValue(Me) <> Nothing Or Session.IsNewObject(Me) Then
            If miPostCode.GetOldValue(Me) <> PostCode Then
                Dim ll As New LatLong()
                ll = GoogleAPI.GetLatLong(PostCode)
                If ll IsNot Nothing Then
                    Latitude = ll.Latitude
                    Longitude = ll.Longitude
                End If
            End If
            'End If

        End Sub
        Protected Overrides Sub OnDeleting()
            MyBase.OnDeleting()
            DeletedBy = ProjectCurrentUser.GetGlobalUser(Session)
            DeletedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnLoaded()
            Reset()
            MyBase.OnLoaded()
        End Sub
        Private _referralSource As ReferralSource
        Public Property Source() As ReferralSource
            Get
                Return _referralSource
            End Get
            Set(ByVal value As ReferralSource)
                SetPropertyValue(Of ReferralSource)("Source", _referralSource, value)
            End Set
        End Property
        Private _tertiaryReferral As Referral
        Public Property TertiaryReferral() As Referral
            Get
                Return _tertiaryReferral
            End Get
            Set(ByVal value As Referral)
                SetPropertyValue(Of Referral)("TertiaryReferral", _tertiaryReferral, value)
            End Set
        End Property
        Private _insurer As Insurer
        Public Property Insurer() As Insurer
            Get
                Return _insurer
            End Get
            Set(ByVal value As Insurer)
                SetPropertyValue(Of Insurer)("Insurer", _insurer, value)
            End Set
        End Property
        Private _insurerAgent As InsurerAgent
        Public Property InsurerAgent() As InsurerAgent
            Get
                Return _insurerAgent
            End Get
            Set(ByVal value As InsurerAgent)
                SetPropertyValue(Of InsurerAgent)("InsurerAgent", _insurerAgent, value)
            End Set
        End Property
        Private _patient As Patient
        <Association("Patient-Referrals")> _
        Public Property Patient() As Patient
            Get
                Return _patient
            End Get
            Set(ByVal value As Patient)
                SetPropertyValue(Of Patient)("Patient", _patient, value)
            End Set
        End Property
        Private _client As Client
        Public Property Client() As Client
            Get
                Return _client
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", _client, value)
            End Set
        End Property
        Private _claim As Claim
        Public Property Claim() As Claim
            Get
                Return _claim
            End Get
            Set(ByVal value As Claim)
                SetPropertyValue(Of Claim)("Claim", _claim, value)
            End Set
        End Property
        Private _opportunityid As Integer
        Public Property Opportunityid() As Integer
            Get
                Return _opportunityid
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Opportunityid", _opportunityid, value)
            End Set
        End Property
        Private _referralDate As Date
        Public Property ReferralDate() As Date
            Get
                Return _referralDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("ReferralDate", _referralDate, value)
            End Set
        End Property
        Private _authorisationNo As String
        <Size(25)> _
        Public Property AuthorisationNo() As String
            Get
                Return _authorisationNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AuthorisationNo", _authorisationNo, value)
            End Set
        End Property
        Private _membershipNo As String
        <Size(20)> _
        Public Property MembershipNo() As String
            Get
                Return _membershipNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MembershipNo", _membershipNo, value)
            End Set
        End Property
        Private _policyNo As String
        <Size(20)> _
        Public Property PolicyNo() As String
            Get
                Return _policyNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PolicyNo", _policyNo, value)
            End Set
        End Property
        Private _system As String
        <Size(10)>
        Public Property System() As String
            Get
                Return _system
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("System", _system, value)
            End Set
        End Property
        Private _referralType As ReferralType
        Public Property ReferralType() As ReferralType
            Get
                Return _referralType
            End Get
            Set(ByVal value As ReferralType)
                SetPropertyValue(Of ReferralType)("ReferralType", _referralType, value)
            End Set
        End Property
        Private _referralCategory As ReferralCategory
        Public Property ReferralCategory() As ReferralCategory
            Get
                Return _referralCategory
            End Get
            Set(ByVal value As ReferralCategory)
                SetPropertyValue(Of ReferralCategory)("ReferralCategory", _referralCategory, value)
            End Set
        End Property
        Private _f2FPractice As String
        <Size(20)> _
        Public Property F2FPractice() As String
            Get
                Return _f2FPractice
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("F2FPractice", _f2FPractice, value)
            End Set
        End Property
        Private _hospitalList As String
        <Size(20)> _
        Public Property HospitalList() As String
            Get
                Return _hospitalList
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HospitalList", _hospitalList, value)
            End Set
        End Property
        Private _namedconsultant As Consultant   
        Public Property NamedConsultant() As Consultant
            Get
                Return _namedconsultant
            End Get
            Set(ByVal value As Consultant)
                SetPropertyValue(Of Consultant)("NamedConsultant", _namedconsultant, value)
            End Set
        End Property
        Private fexcess As Double
        Public Property Excess() As Double
            Get
                Return fexcess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Excess", fexcess, value)
            End Set
        End Property
        Private _excessRemaining As Double
        Public Property ExcessRemaining() As Double
            Get
                Return _excessRemaining
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("ExcessRemaining", _excessRemaining, value)
            End Set
        End Property
        Private _OutPatientFull As Boolean
        Public Property OutPatientFull() As Boolean
            Get
                Return _OutPatientFull
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("OutPatientFull", _OutPatientFull, value)
            End Set
        End Property
        Private _OutPatientLimit As Double
        Public Property OutPatientLimit() As Double
            Get
                Return _OutPatientLimit
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("OutPatientLimit", _OutPatientLimit, value)
            End Set
        End Property
        Private _OutPatientLimitRemaining As Double
        Public Property OutPatientLimitRemaining() As Double
            Get
                Return _OutPatientLimitRemaining
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("OutPatientLimitRemaining", _OutPatientLimitRemaining, value)
            End Set
        End Property

        Private _staffClaim As Boolean
        Public Property StaffClaim() As Boolean
            Get
                Return _staffClaim
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("StaffClaim", _staffClaim, value)
            End Set
        End Property
        Private _policyRenewalDate As Date
        Public Property PolicyRenewalDate() As Date
            Get
                Return _policyRenewalDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("PolicyRenewalDate", _policyRenewalDate, value)
            End Set
        End Property
        Private _symptom As Symptom
        Public Property Symptom() As Symptom
            Get
                Return _symptom
            End Get
            Set(ByVal value As Symptom)
                SetPropertyValue(Of Symptom)("Symptom", _symptom, value)
            End Set
        End Property
        Private _symptomdetails As String
        <Size(50)> _
        Public Property SymptomDetails() As String
            Get
                Return _symptomdetails
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SymptomDetails", _symptomdetails, value)
            End Set
        End Property
        Private _details As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Details() As String
            Get
                Return _details
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Details", _details, value)
            End Set
        End Property
        Private _newProcess As Boolean
        Public Property NewProcess() As Boolean
            Get
                Return _newProcess
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("NewProcess", _newProcess, value)
            End Set
        End Property
        Private _triaged As Boolean
        Public Property Triaged() As Boolean
            Get
                Return _triaged
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Triaged", _triaged, value)
            End Set
        End Property
        Private _complexTriage As Boolean
        Public Property ComplexTriage() As Boolean
            Get
                Return _complexTriage
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ComplexTriage", _complexTriage, value)
            End Set
        End Property
        Private _consultantTaffed As Boolean
        Public Property ConsultantTaffed() As Boolean
            Get
                Return _consultantTaffed
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ConsultantTaffed", _consultantTaffed, value)
            End Set
        End Property
        Private _patientTaffed As Boolean
        Public Property PatientTaffed() As Boolean
            Get
                Return _patientTaffed
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("PatientTaffed", _patientTaffed, value)
            End Set
        End Property
        Private _datePatientTaffed As Date
        Public Property DatePatientTaffed() As Date
            Get
                Return _datePatientTaffed
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("DatePatientTaffed", _datePatientTaffed, value)
            End Set
        End Property
        Public ReadOnly Property isTaffed() As Boolean
            Get
                Return PatientTaffed = True And ConsultantTaffed = True
            End Get
        End Property
        <NonPersistent()>
        Public ReadOnly Property IsBooked() As Boolean
            Get
                Return FirstConsultation <> DateTime.MinValue
            End Get
        End Property
        Private _bookedBy As GlobalUser
        Public Property BookedBy() As GlobalUser
            Get
                Return _bookedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("BookedBy", _bookedBy, value)
            End Set
        End Property
        Private _bookedDate As Date
        Public Property BookedDate() As Date
            Get
                Return _bookedDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("BookedDate", _bookedDate, value)
            End Set
        End Property
        Private _cCardAuthorised As Date
        Public Property CCardAuthorised() As Date
            Get
                Return _cCardAuthorised
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("CCardAuthorised", _cCardAuthorised, value)
            End Set
        End Property
        Private _cCardFirstPayment As Date
        Public Property CardFirstPayment() As Date
            Get
                Return _cCardFirstPayment
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("CardFirstPayment", _cCardFirstPayment, value)
            End Set
        End Property
        Private _triageconsultant As Consultant
        Public Property Triageconsultant() As Consultant
            Get
                Return _triageconsultant
            End Get
            Set(ByVal value As Consultant)
                SetPropertyValue(Of Consultant)("Triageconsultant", _triageconsultant, value)
            End Set
        End Property
        Private _hcaAvoided As Boolean
        Public Property HCAAvoided() As Boolean
            Get
                Return _hcaAvoided
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("HCAAvoided", _hcaAvoided, value)
            End Set
        End Property
        Private _specialInstructions As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property SpecialInstructions() As String
            Get
                Return _specialInstructions
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SpecialInstructions", _specialInstructions, value)
            End Set
        End Property
        Private _status As eReferralStatus
        Public Property Status() As eReferralStatus
            Get
                Return _status
            End Get
            Set(ByVal value As eReferralStatus)
                SetPropertyValue(Of eReferralStatus)("Status", _status, value)
            End Set
        End Property
        Private _stage As eReferralStage
        Public Property Stage() As eReferralStage
            Get
                Return _stage
            End Get
            Set(ByVal value As eReferralStage)
                SetPropertyValue(Of eReferralStage)("Stage", _stage, value)
            End Set
        End Property
        Private _pCASource As PCASource
        Public Property PCASource() As PCASource
            Get
                Return _pCASource
            End Get
            Set(ByVal value As PCASource)
                SetPropertyValue(Of PCASource)("PCASource", _pCASource, value)
            End Set
        End Property
        Private _team As Team
        Public Property AssignedTeam() As Team
            Get
                Return _team
            End Get
            Set(ByVal value As Team)
                SetPropertyValue(Of Team)("AssignedTeam", _team, value)
            End Set
        End Property
        Private _assignedto As User
        Public Property AssignedUser() As User
            Get
                Return _assignedto
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("AssignedUser", _assignedto, value)
            End Set
        End Property
        'Private _referringGP As String
        '<Size(40)>
        'Public Property ReferringGP() As String
        '    Get
        '        Return _referringGP
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ReferringGP", _referringGP, value)
        '    End Set
        'End Property

        'Private _referringPractice As String
        '<Size(40)>
        'Public Property ReferringPractice() As String
        '    Get
        '        Return _referringPractice
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ReferringPractice", _referringPractice, value)
        '    End Set
        'End Property
        Private _seenGP As Char
        Public Property SeenGP() As Char
            Get
                Return _seenGP
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("SeenGP ", _seenGP, value)
            End Set
        End Property
        Private _referralLetter As Char
        Public Property ReferralLetter() As Char
            Get
                Return _referralLetter
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("ReferralLetter ", _referralLetter, value)
            End Set
        End Property
        Private _recommendedSpecialism As Specialism
        Public Property RecommendedSpecialism() As Specialism
            Get
                Return _recommendedSpecialism
            End Get
            Set(ByVal value As Specialism)
                SetPropertyValue(Of Specialism)("RecommendedSpecialism", _recommendedSpecialism, value)
            End Set
        End Property
        Private _specialism As Specialism
        Public Property Specialism() As Specialism
            Get
                Return _specialism
            End Get
            Set(ByVal value As Specialism)
                SetPropertyValue(Of Specialism)("Specialism", _specialism, value)
            End Set
        End Property
        Private fconsultant As Consultant
        Public Property Consultant() As Consultant
            Get
                Return fconsultant
            End Get
            Set(ByVal value As Consultant)
                SetPropertyValue(Of Consultant)("Consultant", fconsultant, value)
            End Set
        End Property
  
        Private _Hospital As Hospital
        Public Property Hospital() As Hospital
            Get
                Return _Hospital
            End Get
            Set(ByVal value As Hospital)
                SetPropertyValue(Of Hospital)("Hospital", _Hospital, value)
            End Set
        End Property
   
        Private _firstConsultation As Date
        Public Property FirstConsultation() As Date
            Get
                Return _firstConsultation
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("FirstConsultation", _firstConsultation, value)
            End Set
        End Property
        Private _postCode As String
        <Size(10)> _
        Public Property PostCode() As String
            Get
                Return _postCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Postcode", _postCode, value)
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
                Return _longitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Longitude", _longitude, value)
            End Set
        End Property
        Private _distance As Double
        Public Property Distance As Double
            Get
                Return _distance
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Distance", _distance, value)
            End Set
        End Property
        Private _travelTime As Integer
        Public Property TravelTime As Integer
            Get
                Return _travelTime
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TravelTime", _travelTime, value)
            End Set
        End Property
        Private _failed As Boolean
        Public Property Failed As Boolean
            Get
                Return _failed
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Failed", _failed, value)
            End Set
        End Property
        Private _ReasonClosed As eReasonClosed
        Public Property ReasonClosed() As eReasonClosed
            Get
                Return _ReasonClosed
            End Get
            Set(ByVal value As eReasonClosed)
                SetPropertyValue(Of eReasonClosed)("ReasonClosed", _ReasonClosed, value)
            End Set
        End Property
        Private _passBackType As PassBackCategory
        Public Property PassBackType() As PassBackCategory
            Get
                Return _passBackType
            End Get
            Set(ByVal value As PassBackCategory)
                SetPropertyValue(Of PassBackCategory)("PassBackType", _passBackType, value)
            End Set
        End Property
        Private _passBackDate As Date
        Public Property PassBackDate() As Date
            Get
                Return _passBackDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("PassBackDate", _passBackDate, value)
            End Set
        End Property
        Private _passBackBy As GlobalUser
        Public Property PassBackBy() As GlobalUser
            Get
                Return _passBackBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("PassBackBy", _passBackBy, value)
            End Set
        End Property
        Private _dischargeDate As Date
        Public Property DischargeDate() As Date
            Get
                Return _dischargeDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("DischargeDate", _dischargeDate, value)
            End Set
        End Property
        <Association("Referral-Appointments")> _
        Public ReadOnly Property Appointments() As XPCollection(Of AppointmentOption)
            Get
                Return GetCollection(Of AppointmentOption)("Appointments")
            End Get
        End Property
        <Association("Referral-LibraryDoc")> _
        Public ReadOnly Property LibraryDocuments() As XPCollection(Of LibraryDoc)
            Get
                Return GetCollection(Of LibraryDoc)("LibraryDocuments")
            End Get
        End Property
        <Association("Referral-Treatments")> _
        Public ReadOnly Property Treatments() As XPCollection(Of ReferralTreatment)
            Get
                Return GetCollection(Of ReferralTreatment)("Treatments")
            End Get
        End Property
        <Association("Referral-Communications")> _
        Public ReadOnly Property Communications() As XPCollection(Of Communication)
            Get
                Return GetCollection(Of Communication)("Communications")
            End Get
        End Property
        <Association("Referral-TrackingNotes")> _
        Public ReadOnly Property TrackingNotes() As XPCollection(Of TrackingNote)
            Get
                Return GetCollection(Of TrackingNote)("TrackingNotes")
            End Get
        End Property
        <Association("Referral-Documents")> _
        Public ReadOnly Property Documents() As XPCollection(Of LinkedDocument)
            Get
                Return GetCollection(Of LinkedDocument)("Documents")
            End Get
        End Property
        <Persistent("InvoicedValue")> _
        Private fInvoicedValue As Nullable(Of Double) = Nothing
        <PersistentAlias("fInvoicedValue")> _
        Public ReadOnly Property InvoicedValue() As Nullable(Of Double)
            Get
                If (Not IsLoading) AndAlso (Not IsSaving) AndAlso Not fInvoicedValue.HasValue Then
                    UpdateInvoicedValue(False)
                End If
                Return fInvoicedValue
            End Get
        End Property
        <Persistent("ConsultantValue")> _
        Private fConsultantValue As Nullable(Of Double) = Nothing
        <PersistentAlias("fConsultantValue")> _
        Public ReadOnly Property ConsultantValue() As Nullable(Of Double)
            Get
                If (Not IsLoading) AndAlso (Not IsSaving) AndAlso Not fConsultantValue.HasValue Then
                    UpdateInvoicedValue(False)
                End If
                Return fInvoicedValue
            End Get
        End Property
        Public Sub UpdateConsultantValue(ByVal forceChangeEvents As Boolean)
            Dim oldConsultantValue As Nullable(Of Double) = fInvoicedValue
            fConsultantValue = Convert.ToDouble(Session.Evaluate(GetType(ReferralTreatment), CriteriaOperator.Parse("sum(ConsultantValue)"), CriteriaOperator.Parse("Referral= ? ", Oid)))
            If forceChangeEvents Then
                OnChanged("ConsultantValue", oldConsultantValue, fConsultantValue)
            End If
        End Sub
        Public Sub UpdateInvoicedValue(ByVal forceChangeEvents As Boolean)
            Dim oldInvoiceValue As Nullable(Of Double) = fInvoicedValue
            fInvoicedValue = Convert.ToDouble(Session.Evaluate(GetType(ReferralTreatment), CriteriaOperator.Parse("sum(InvoiceValue)"), CriteriaOperator.Parse("Referral= ? ", Oid)))
            If forceChangeEvents Then
                OnChanged("InvoicedValue", oldInvoiceValue, fInvoicedValue)
            End If
        End Sub
    
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return String.Format("({0} {1} {2}) ", ConstDataStrings.Referral, Oid, Stage)
            Else
                Return String.Format("(New {0}) ", ConstDataStrings.Referral)
            End If
        End Function
        <NonPersistent()> _
        Public ReadOnly Property Description() As String
            Get
                Return Me.ToString
            End Get
        End Property
        Public ReadOnly Property DPA() As String
            Get
                Dim ret As String = String.Format("({0}) ", Oid)
                If Object.Equals(SymptomDetails, Nothing) Then
                    ret &= String.Empty
                Else
                    ret &= SymptomDetails
                End If
                Return ret
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
        Private _deletedBy As GlobalUser
        Public Property DeletedBy() As GlobalUser
            Get
                Return _deletedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("DeletedBy", _deletedBy, value)
            End Set
        End Property
        Private _deletedAt As DateTime
        Public Property DeletedAt() As DateTime
            Get
                Return _deletedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DeletedAt", _deletedAt, value)
            End Set
        End Property
    End Class
End Namespace