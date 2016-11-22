Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports Alliance.Data
Imports DevExpress.Data.Filtering
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data
    Public Class ClaimSource
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal source As String)
            Me.New(session)
            Me._source = source
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
        Private fsequenceNo As Integer
        Public Property SequenceNo() As Integer
            Get
                Return fsequenceNo
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SequenceNo", fsequenceNo, value)
            End Set
        End Property
        Private _source As String
        <Size(10)> _
        Public Property Source() As String
            Get
                Return _source
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Source", _source, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Source)
        End Function
    End Class
    Public Class ClaimStatus
        Inherits XPCustomObject
        Private fsequenceNo As Integer

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal Status As String)
            Me.New(session)
            Me.fStatus = Status
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
        Public Property SequenceNo() As Integer
            Get
                Return fsequenceNo
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SequenceNo", fsequenceNo, value)
            End Set
        End Property
        Private fStatus As String
        <Size(30)> _
        Public Property Status() As String
            Get
                Return fStatus
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Status", fStatus, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Status)
        End Function
    End Class
    Public Class ActionItem
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
        Private _claim As Claim
        Public Property Claim() As Claim
            Get
                Return _claim
            End Get
            Set(ByVal value As Claim)
                SetPropertyValue(Of Claim)("Claim", _claim, value)
            End Set
        End Property
        Private _actionType As eActionType
        Public Property ActionType() As eActionType
            Get
                Return _actionType
            End Get
            Set(ByVal value As eActionType)
                SetPropertyValue(Of eActionType)("ActionClaimType", _actionType, value)
            End Set
        End Property
        Private _comment As String
        Public Property Comment() As String
            Get
                Return _comment
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Comment", _comment, value)
            End Set
        End Property
        Private _status As eActionStatus
        Public Property Status() As eActionStatus
            Get
                Return _status
            End Get
            Set(ByVal value As eActionStatus)
                SetPropertyValue(Of eActionStatus)("Status", _status, value)
            End Set
        End Property
        Private _closedDate As Nullable(Of DateTime)
        Public Property CLosedDate() As Nullable(Of DateTime)
            Get
                Return _closedDate
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                SetPropertyValue(Of Nullable(Of DateTime))("CLosedDate", _closedDate, value)
            End Set
        End Property
        Private _closedBy As GlobalUser
        Public Property ClosedBy() As GlobalUser
            Get
                Return _closedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ClosedBy", _closedBy, value)
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
    Public Class Claim
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
        Protected Overrides Sub OnLoaded()
            Reset()
            MyBase.OnLoaded()
        End Sub
        Private Sub Reset()
            fIncurredCost = Nothing
        End Sub
        Private _claimSource As eClaimSource
        Public Property Source() As eClaimSource
            Get
                Return _claimSource
            End Get
            Set(ByVal value As eClaimSource)
                SetPropertyValue(Of eClaimSource)("Source", _claimSource, value)
            End Set
        End Property
        Private fclient As Client
        Public Property Client() As Client
            Get
                Return fclient
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", fclient, value)
            End Set
        End Property
        Property _clientType As eClientType
        Public Property ClientType() As eClientType
            Get
                Return _clientType
            End Get
            Set(ByVal value As eClientType)
                SetPropertyValue(Of eClientType)("ClientType", _clientType, value)
            End Set
        End Property
        Private fBeneficiary As Beneficiary
        <Association("Beneficiary-Claims")> _
        Public Property Beneficiary() As Beneficiary
            Get
                Return fBeneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", fBeneficiary, value)
            End Set
        End Property
        Private fGP As GP
        Public Property GP() As GP
            Get
                Return fGP
            End Get
            Set(ByVal value As GP)
                SetPropertyValue(Of GP)("GP", fGP, value)
            End Set
        End Property
        Private fGPPractice As Practice
        Public Property Practice() As Practice
            Get
                Return fGPPractice
            End Get
            Set(ByVal value As Practice)
                SetPropertyValue(Of Practice)("GP", fGPPractice, value)
            End Set
        End Property
        Private _preferredhospital As Hospital
        Public Property PreferredHospital() As Hospital
            Get
                Return _preferredhospital
            End Get
            Set(ByVal value As Hospital)
                SetPropertyValue(Of Hospital)("PreferredHospital", _preferredhospital, value)
            End Set
        End Property
        Private _hospital As Hospital
        Public Property Hospital() As Hospital
            Get
                Return _hospital
            End Get
            Set(ByVal value As Hospital)
                SetPropertyValue(Of Hospital)("Hospital", _hospital, value)
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
        Private _opportunityId As Integer
        Public Property Oppo_OpportunityId() As Integer
            Get
                Return _opportunityId
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CRMID", _opportunityId, value)
            End Set
        End Property
        Private fClaimDate As Date
        Public Property ClaimDate() As Date
            Get
                Return fClaimDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("ClaimDate", fClaimDate, value)
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
        Private _iCD10 As ICD10
        Public Property ICD10() As ICD10
            Get
                Return _iCD10
            End Get
            Set(ByVal value As ICD10)
                SetPropertyValue(Of ICD10)("ICD10", _iCD10, value)
            End Set
        End Property
        Private _incurredCategory As IncurredCategory
        Public Property IncurredCategory() As IncurredCategory
            Get
                Return _incurredCategory
            End Get
            Set(ByVal value As IncurredCategory)
                SetPropertyValue(Of IncurredCategory)("IncurredCategory", _incurredCategory, value)
            End Set
        End Property
        Private _incurredSubCategory As IncurredCategory
        Public Property IncurredSubCategory() As IncurredCategory
            Get
                Return _incurredSubCategory
            End Get
            Set(ByVal value As IncurredCategory)
                SetPropertyValue(Of IncurredCategory)("IncurredSubCategory", _incurredSubCategory, value)
            End Set
        End Property
        Private _Triage As Communication
        Public Property Triage() As Communication
            Get
                Return _Triage
            End Get
            Set(ByVal value As Communication)
                SetPropertyValue(Of Communication)("Triage", _Triage, value)
            End Set
        End Property
        Private _firstSymptomDate As Date
        Public Property FirstSymptomDate() As Date
            Get
                Return _firstSymptomDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("FirstSymptomDate", _firstSymptomDate, value)
            End Set
        End Property
        Private _firstConsultationDate As Date
        Public Property FirstConsultationDate() As Date
            Get
                Return _firstConsultationDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("FirstConsultationDate", _firstConsultationDate, value)
            End Set
        End Property
        Private _lastConsultationDate As Date
        Public Property LastConsultationDate() As Date
            Get
                Return _lastConsultationDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("LastConsultationDate", _lastConsultationDate, value)
            End Set
        End Property
        Private fStatus As eClaimStatus
        Public Property Status() As eClaimStatus
            Get
                Return fStatus
            End Get
            Set(ByVal value As eClaimStatus)
                SetPropertyValue(Of eClaimStatus)("Status", fStatus, value)
            End Set
        End Property
        Private _completedEAP As Boolean
        Public Property CompletedEAP() As Boolean
            Get
                Return _completedEAP
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ReferredToEAP", _completedEAP, value)
            End Set
        End Property
        Private fHeldReason As Integer
        Public Property HeldReason() As Integer
            Get
                Return fHeldReason
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("HeldReason", fHeldReason, value)
            End Set
        End Property
        Private fDateHeld As Date?
        Public Property DateHeld() As Date?
            Get
                Return fDateHeld
            End Get
            Set(ByVal value As Date?)
                SetPropertyValue(Of Date?)("DateHeld", fDateHeld, value)
            End Set
        End Property
        Private fDivision As Division
        Public Property Division() As Division
            Get
                Return fDivision
            End Get
            Set(ByVal value As Division)
                SetPropertyValue(Of Division)("Division", fDivision, value)
            End Set
        End Property
        Private fReportingDivision As ReportingDivision
        Public Property ReportingDivision() As ReportingDivision
            Get
                Return fReportingDivision
            End Get
            Set(ByVal value As ReportingDivision)
                SetPropertyValue(Of ReportingDivision)("ReportingDivision", fReportingDivision, value)
            End Set
        End Property
        Private _BusinessUnit As BusinessUnit
        <Association("BusinessUnit-Claims")> _
        Public Property BusinessUnit() As BusinessUnit
            Get
                Return _BusinessUnit
            End Get
            Set(ByVal value As BusinessUnit)
                SetPropertyValue(Of BusinessUnit)("BusinessUnit", _BusinessUnit, value)
            End Set
        End Property
        Private fGPformsreceived As Date
        Public Property GPformsreceived() As Date
            Get
                Return fGPformsreceived
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("GPformsreceived", fGPformsreceived, value)
            End Set
        End Property
        Private flegacy As Boolean
        Public Property Legacy() As Boolean
            Get
                Return flegacy
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Legacy", flegacy, value)
            End Set
        End Property
        Private _outOfNetWork As Boolean
        Public Property OutOfNetWork() As Boolean
            Get
                Return _outOfNetWork
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("OutOfNetWork", _outOfNetWork, value)
            End Set
        End Property
        Private _offWork As Char
        Public Property OffWork() As Char
            Get
                Return _offWork
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("OffWork", _offWork, value)
            End Set
        End Property
        Private fClaimClosed As Boolean
        Public Property ClaimClosed() As Boolean
            Get
                Return fClaimClosed
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ClaimClosed", fClaimClosed, value)
            End Set
        End Property
        Private fClaimReOpened As Boolean
        Public Property ClaimReOpened() As Boolean
            Get
                Return fClaimReOpened
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ClaimReOpened", fClaimReOpened, value)
            End Set
        End Property
        Private fClaimCloseReason As Integer
        Public Property ClaimCloseReason() As Integer
            Get
                Return fClaimCloseReason
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ClaimCloseReason", fClaimCloseReason, value)
            End Set
        End Property
        <Association("Claim-LibraryDoc")> _
        Public ReadOnly Property LibraryDocuments() As XPCollection(Of LibraryDoc)
            Get
                Return GetCollection(Of LibraryDoc)("LibraryDocuments")
            End Get
        End Property
        <Association("Claim-Authorisations")> _
        Public ReadOnly Property Authorisations() As XPCollection(Of Authorisation)
            Get
                Return GetCollection(Of Authorisation)("Authorisations")
            End Get
        End Property
        <Association("Claim-Communications")> _
        Public ReadOnly Property Communications() As XPCollection(Of Communication)
            Get
                Return GetCollection(Of Communication)("Communications")
            End Get
        End Property
        <Association("Claim-TrackingNotes")> _
        Public ReadOnly Property TrackingNotes() As XPCollection(Of TrackingNote)
            Get
                Return GetCollection(Of TrackingNote)("TrackingNotes")
            End Get
        End Property
        <Association("Claim-Documents")> _
        Public ReadOnly Property Documents() As XPCollection(Of LinkedDocument)
            Get
                Return GetCollection(Of LinkedDocument)("Documents")
            End Get
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
        Private _invoiced As Double
        Public Property Invoiced() As Double
            Get
                Return _invoiced
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Invoiced", _invoiced, value)
            End Set
        End Property
        <Persistent("IncurredCost")> _
        Private fIncurredCost As Nullable(Of Double) = Nothing
        <PersistentAlias("fIncurredCost")> _
        Public ReadOnly Property IncurredCost() As Nullable(Of Double)
            Get
                If (Not IsLoading) AndAlso (Not IsSaving) AndAlso Not fIncurredCost.HasValue Then
                    UpdateIncurredCost(False)
                End If
                Return fIncurredCost
            End Get
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
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                If Symptom Is Nothing Then
                    Return String.Format("{0:dd/MM/yyyy} {1} ({2}) ", ClaimDate, "TBC", Oid)
                Else
                    Return String.Format("{0:dd/MM/yyyy} {1} ({2}) ", ClaimDate, Symptom.Symptom, Oid)
                End If
            Else
                Return String.Format("(New {0}) ", ConstDataStrings.Claim)
            End If

        End Function
        'Public Sub CalcCosts()
        '    Dim dCosts As Decimal = 0
        '    For Each oLine As Authorisation In Authorisations
        '        dCosts += oLine.InCurredCost
        '    Next
        '    IncurredCost = dCosts
        'End Sub
        Public Sub CalcBudget()
            Dim _budget As Double = 0
            For Each oLine As Authorisation In Authorisations
                _budget += oLine.Budget
            Next
            Budget = _budget
        End Sub
        Public ReadOnly Property HasActiveActions() As Integer
            Get
                Return Convert.ToInt32(Session.Evaluate(Of ActionItem)(CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Claim = ? and Status=?", Oid, eActionStatus.Active)))
            End Get
        End Property
        Public Function GetActiveActions() As XPCollection(Of ActionItem)
            Return New XPCollection(Of ActionItem)(Session, (CriteriaOperator.Parse("Claim = ? and Status=?", Oid, eActionStatus.Active)), New DevExpress.Xpo.SortProperty("[CreatedAt]", DevExpress.Xpo.DB.SortingDirection.Ascending))
        End Function
        <NonPersistent()> _
        Public ReadOnly Property Description() As String
            Get
                Return Me.ToString
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
        Public Sub UpdateIncurredCost(ByVal forceChangeEvents As Boolean)
            Dim oldIncurredCost As Nullable(Of Double) = fIncurredCost
            fIncurredCost = Convert.ToDouble(Session.Evaluate(GetType(vw_IncurredCost), CriteriaOperator.Parse("sum(IncurredTotal)"), CriteriaOperator.Parse("Claim= ? ", Oid)))
            If forceChangeEvents Then
                OnChanged("IncurredCost", oldIncurredCost, fIncurredCost)
            End If
        End Sub
    End Class
End Namespace