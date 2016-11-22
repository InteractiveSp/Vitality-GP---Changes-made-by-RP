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
    Public Class AuthorisationType
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal AuthorisationType As String)
            Me.New(session)
            Me.fAuthorisationType = AuthorisationType
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
        Private fAuthorisationType As String
        <Size(30)> _
        Public Property AuthorisationType() As String
            Get
                Return fAuthorisationType
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AuthorisationType", fAuthorisationType, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", AuthorisationType)
        End Function
    End Class
    Public Class AuthorisationStatus
        Inherits XPCustomObject
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
        Private fsequenceNo As Integer
        Public Property SequenceNo() As Integer
            Get
                Return fsequenceNo
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SequenceNo", fsequenceNo, value)
            End Set
        End Property
        Private fStatus As String
        <Size(15)> _
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
    Public Class AuthorisationSource
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
    Public Class Authorisation
        Inherits AuditedBase
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) Then
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now

            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
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
        Private Sub Reset()
            fIncurredCost = Nothing
        End Sub
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
        <Association("Beneficiary-Authorisations")> _
        Public Property Beneficiary() As Beneficiary
            Get
                Return fBeneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", fBeneficiary, value)
            End Set
        End Property
        Private fAuthorisationType As eAuthorisationType
        Public Property AuthorisationType() As eAuthorisationType
            Get
                Return fAuthorisationType
            End Get
            Set(ByVal value As eAuthorisationType)
                SetPropertyValue(Of eAuthorisationType)("AuthorisationType", fAuthorisationType, value)
            End Set
        End Property
        Private _authorisationSource As eAuthorisationSource
        Public Property Source() As eAuthorisationSource
            Get
                Return _authorisationSource
            End Get
            Set(ByVal value As eAuthorisationSource)
                SetPropertyValue(Of eAuthorisationSource)("AuthorisationSource", _authorisationSource, value)
            End Set
        End Property
        Private fClaim As Claim
        <Association("Claim-Authorisations")> _
        Public Property Claim() As Claim
            Get
                Return fClaim
            End Get
            Set(ByVal value As Claim)
                SetPropertyValue(Of Claim)("Claim", fClaim, value)
            End Set
        End Property

        Private _authorised As Boolean
        Public Property Authorised() As Boolean
            Get
                Return _authorised
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Authorised", _authorised, value)
            End Set
        End Property
        Private fAuthorisationDate As Date
        Public Property AuthorisationDate() As Date
            Get
                Return fAuthorisationDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("AuthorisationDate", fAuthorisationDate, value)
            End Set
        End Property
        Private _authorisedBy As GlobalUser
        Public Property AuthorisedBy() As GlobalUser
            Get
                Return _authorisedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("AuthorisedBy", _authorisedBy, value)
            End Set
        End Property
        Private _cITType As eCITType
        Public Property CITType() As eCITType
            Get
                Return _cITType
            End Get
            Set(ByVal value As eCITType)
                SetPropertyValue(Of eCITType)("CITType", _cITType, value)
            End Set
        End Property
        Private _cITComplete As Date?
        Public Property CITComplete() As Date?
            Get
                Return _cITComplete
            End Get
            Set(ByVal value As Date?)
                SetPropertyValue(Of Date?)("CITComplete", _cITComplete, value)
            End Set
        End Property
        Private fproposedTreatmentDate As Date
        Public Property ProposedDate() As Date
            Get
                Return fproposedTreatmentDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("ProposedDate", fproposedTreatmentDate, value)
            End Set
        End Property
        Private fAuthorisationNo As String
        <Indexed(Unique:=False), Size(10)> _
        Public Property AuthorisationNo() As String
            Get
                Return fAuthorisationNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AuthorisationNo", fAuthorisationNo, value)
            End Set
        End Property
        Private _furtherId As Integer
        Public Property Furt_Furtherid() As Integer
            Get
                Return _furtherId
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Furt_Furtherid", _furtherId, value)
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
        Private _diagnosis As ICD10
        Public Property ICD10() As ICD10
            Get
                Return _diagnosis
            End Get
            Set(ByVal value As ICD10)
                SetPropertyValue(Of ICD10)("ICD10", _diagnosis, value)
            End Set
        End Property
        Private fTreatment As Treatment
        Public Property Treatment() As Treatment
            Get
                Return fTreatment
            End Get
            Set(ByVal value As Treatment)
                SetPropertyValue(Of Treatment)("Treatment", fTreatment, value)
            End Set
        End Property
        Private fQty As Integer
        Public Property Qty() As Integer
            Get
                Return fQty
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Qty", fQty, value)
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
                SetPropertyValue(Of Double)("Budget", _budget, value)
            End Set
        End Property
        Private _consultantbudget As Double
        Public Property Consultantbudget() As Double
            Get
                Return _consultantbudget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Consultantbudget", _consultantbudget, value)
            End Set
        End Property
        Private __consultantBudgetSource As eBudgetSource
        Public Property ConsultantBudgetSource() As eBudgetSource
            Get
                Return __consultantBudgetSource
            End Get
            Set(ByVal value As eBudgetSource)
                SetPropertyValue(Of eBudgetSource)("ConsultantBudgetSource", __consultantBudgetSource, value)
            End Set
        End Property
        Private _consultantIncurred As Double
        Public Property ConsultantIncurred() As Double
            Get
                Return _consultantIncurred
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("ConsultantIncurred", _consultantIncurred, value)
            End Set
        End Property
        Private _hospitalBudget As Double
        Public Property HospitalBudget() As Double
            Get
                Return _hospitalBudget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("HospitalBudget", _hospitalBudget, value)
            End Set
        End Property
        Private _hospitalBudgetSource As eBudgetSource
        Public Property HospitalBudgetSource() As eBudgetSource
            Get
                Return _hospitalBudgetSource
            End Get
            Set(ByVal value As eBudgetSource)
                SetPropertyValue(Of eBudgetSource)("HospitalBudgetSource", _hospitalBudgetSource, value)
            End Set
        End Property
        Private _hospitalIncurred As Double
        Public Property HospitalIncurred() As Double
            Get
                Return _hospitalIncurred
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("HospitalIncurred", _hospitalIncurred, value)
            End Set
        End Property
        Private _anaesthetistBudget As Double
        Public Property AnaesthetistBudget() As Double
            Get
                Return _anaesthetistBudget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("AnaesthetistBudget", _anaesthetistBudget, value)
            End Set
        End Property
        Private _anaesthetistBudgetSource As eBudgetSource
        Public Property AnaesthetistBudgetSource() As eBudgetSource
            Get
                Return _anaesthetistBudgetSource
            End Get
            Set(ByVal value As eBudgetSource)
                SetPropertyValue(Of eBudgetSource)("AnaesthetistBudgetSource", _anaesthetistBudgetSource, value)
            End Set
        End Property
        Private _anaesthetistIncurred As Double
        Public Property AnaesthetistIncurred() As Double
            Get
                Return _anaesthetistIncurred
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("AnaesthetistIncurred", _anaesthetistIncurred, value)
            End Set
        End Property
        Private _accommodationBudget As Double
        Public Property AccommodationBudget() As Double
            Get
                Return _accommodationBudget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("AccommodationBudget", _accommodationBudget, value)
            End Set
        End Property
        Private _accommodationBudgetSource As eBudgetSource
        Public Property AccommodationBudgetSource() As eBudgetSource
            Get
                Return _accommodationBudgetSource
            End Get
            Set(ByVal value As eBudgetSource)
                SetPropertyValue(Of eBudgetSource)("AccommodationBudgetSource", _accommodationBudgetSource, value)
            End Set
        End Property
        Private _accommodationIncurred As Double
        Public Property AccommodationIncurred() As Double
            Get
                Return _accommodationIncurred
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("AccommodationIncurred", _accommodationIncurred, value)
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
        Private fStatus As eAuthorisationStatus
        Public Property Status() As eAuthorisationStatus
            Get
                Return fStatus
            End Get
            Set(ByVal value As eAuthorisationStatus)
                SetPropertyValue(Of eAuthorisationStatus)("Status", fStatus, value)
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
        Private _practionerReferred As Boolean
        Public Property PractionerReferred() As Boolean
            Get
                Return _practionerReferred
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("PractionerReferred", _practionerReferred, value)
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
        Private fAdmissionStatus As eAdmissionStatus
        Public Property AdmissionStatus() As eAdmissionStatus
            Get
                Return fAdmissionStatus
            End Get
            Set(ByVal value As eAdmissionStatus)
                SetPropertyValue(Of eAdmissionStatus)("AdmissionStatus", fAdmissionStatus, value)
            End Set
        End Property
        Private _benefit As BenefitLimit
        Public Property Benefit() As BenefitLimit
            Get
                Return _benefit
            End Get
            Set(ByVal value As BenefitLimit)
                SetPropertyValue(Of BenefitLimit)("Benefit", _benefit, value)
            End Set
        End Property
        Private _benefitSubType As BenefitLimit
        Public Property SubBenefit() As BenefitLimit
            Get
                Return _benefitSubType
            End Get
            Set(ByVal value As BenefitLimit)
                SetPropertyValue(Of BenefitLimit)("BenefitSubType", _benefitSubType, value)
            End Set
        End Property
        Private _benefitDetail As BenefitLimit
        Public Property BenefitDetail() As BenefitLimit
            Get
                Return _benefitDetail
            End Get
            Set(ByVal value As BenefitLimit)
                SetPropertyValue(Of BenefitLimit)("BenefitDetail", _benefitDetail, value)
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
        <Association("BusinessUnit-Authorisations")> _
        Public Property BusinessUnit() As BusinessUnit
            Get
                Return _BusinessUnit
            End Get
            Set(ByVal value As BusinessUnit)
                SetPropertyValue(Of BusinessUnit)("BusinessUnit", _BusinessUnit, value)
            End Set
        End Property
        Private fInvoiced As Double
        Public Property Invoiced() As Double
            Get
                Return fInvoiced
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Invoiced", fInvoiced, value)
            End Set
        End Property
        'Start Of TBD ----------------
        Private _InvoiceBenefit As String
        Public Property InvoiceBenefit() As String
            Get
                Return _InvoiceBenefit
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InvoiceBenefit", _InvoiceBenefit, value)
            End Set
        End Property
        Private _InvoiceSubBenefit As String
        Public Property InvoiceSubBenefit() As String
            Get
                Return _InvoiceLineDetail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InvoiceSubBenefit", _InvoiceSubBenefit, value)
            End Set
        End Property
        Private _InvoiceLineDetail As String
        Public Property InvoiceLineDetail() As String
            Get
                Return _InvoiceLineDetail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InvoiceLineDetail", _InvoiceLineDetail, value)
            End Set
        End Property
        Private _diverted As Boolean
        Public Property Diverted() As Boolean
            Get
                Return _diverted
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Diverted", _diverted, value)
            End Set
        End Property
        Private _creditCardTaken As Boolean
        Public Property CreditCardTaken() As Boolean
            Get
                Return _creditCardTaken
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("CreditCardTaken", _creditCardTaken, value)
            End Set
        End Property
        Private _creditCardTakenBy As GlobalUser
        Public Property CreditCardTakenBy() As GlobalUser
            Get
                Return _creditCardTakenBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("CreditCardTakenBy", _creditCardTakenBy, value)
            End Set
        End Property
        Private _reviewedBy As GlobalUser
        Public Property ReviewedBy() As GlobalUser
            Get
                Return _reviewedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ReviewedBy", _reviewedBy, value)
            End Set
        End Property
        '        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return GetDelayedPropertyValue(Of String)("Notes")
            End Get
            Set(ByVal value As String)
                SetDelayedPropertyValue("Notes", value)
            End Set
        End Property
        <Association("Authorisation-LibraryDoc")> _
        Public ReadOnly Property LibraryDocuments() As XPCollection(Of LibraryDoc)
            Get
                Return GetCollection(Of LibraryDoc)("LibraryDocuments")
            End Get
        End Property
        <Association("Authorisation-Documents")> _
        Public ReadOnly Property Documents() As XPCollection(Of LinkedDocument)
            Get
                Return GetCollection(Of LinkedDocument)("Documents")
            End Get
        End Property
        Public Overrides Function ToString() As String
            If Oid <> -1 And Treatment IsNot Nothing Then
                Return String.Format("{0:dd/MM/yyyy} {1} {2} ({2}) ", CreatedAt, Treatment.Code, Treatment.Description, AuthorisationNo)
            ElseIf Oid = -1 And Treatment IsNot Nothing Then
                Return String.Format("(New {0}) {1} {2} ", ConstDataStrings.Authorisation, Treatment.Code, Treatment.Description)
            Else
                Return String.Format("(New {0}) ", ConstDataStrings.Authorisation)
            End If
        End Function
        Public Sub UpdateIncurredCost(ByVal forceChangeEvents As Boolean)
            Dim oldIncurredCost As Nullable(Of Double) = fIncurredCost
            fIncurredCost = Convert.ToDouble(Session.Evaluate(GetType(vw_IncurredCost), CriteriaOperator.Parse("sum(IncurredTotal)"), CriteriaOperator.Parse("AuthorisationID= ? ", Oid)))
            If forceChangeEvents Then
                OnChanged("IncurredCost", oldIncurredCost, fIncurredCost)
            End If
        End Sub
        'Public Sub CalcCosts()
        '    Dim dCosts As Decimal = 0
        '    For Each oLine As InvoiceLine In InvoiceLines
        '        dCosts += oLine.IncurredTotal
        '    Next
        '    'InCurredCost = dCosts
        'End Sub
        Public Sub CalcBudget()
            Dim _isPackage As Boolean = False
            If Treatment Is Nothing Then
                Consultantbudget = 0
                HospitalBudget = 0
                AccommodationBudget = 0
                AnaesthetistBudget = 0
                Budget = 0
                Return
            End If

            Consultantbudget = Treatment.ConsultantBudget
            ConsultantBudgetSource = eBudgetSource.Treatment
            HospitalBudget = Treatment.HospitalBudget
            HospitalBudgetSource = eBudgetSource.Treatment
            AnaesthetistBudget = Treatment.AnaesthetistBudget
            AnaesthetistBudgetSource = eBudgetSource.Treatment
            AccommodationBudget = Treatment.AccommodationBudget
            AccommodationBudgetSource = eBudgetSource.Treatment

            If Consultant IsNot Nothing Then
                Dim _insurer As Insurer = Claim.Client.Insurer
                If _insurer IsNot Nothing And _insurer.InsurerCostTable IsNot Nothing Then
                    Dim _consultantCost As ConsultantCost = Session.FindObject(Of ConsultantCost)(CriteriaOperator.Parse("InsurerCostTable = ? and Consultant = ? and Treatment = ?", _insurer.InsurerCostTable.Oid, Consultant.Oid, Treatment.Oid))
                    If _consultantCost IsNot Nothing Then
                        Consultantbudget = _consultantCost.insurerCost
                        ConsultantBudgetSource = eBudgetSource.ConsultantTreatment
                    Else
                        Dim _insurerCost As InsurerCost = Session.FindObject(Of InsurerCost)(CriteriaOperator.Parse("[InsurerCostTable] = ? and Treatment = ?", _insurer.InsurerCostTable.Oid, Treatment.Oid))
                        If _insurerCost IsNot Nothing Then
                            Consultantbudget = _insurerCost.InsurerCost
                            ConsultantBudgetSource = eBudgetSource.InsurerTreatment
                        End If
                    End If
                End If
            Else
                Dim _insurer As Insurer = Claim.Client.Insurer
                If _insurer.InsurerCostTable IsNot Nothing Then
                    Dim _insurerCost As InsurerCost = Session.FindObject(Of InsurerCost)(CriteriaOperator.Parse("[InsurerCostTable] = ? and Treatment = ?", _insurer.InsurerCostTable.Oid, Treatment.Oid))
                    If _insurerCost IsNot Nothing Then
                        Consultantbudget = _insurerCost.InsurerCost
                        ConsultantBudgetSource = eBudgetSource.InsurerTreatment
                    End If
                End If
            End If
            Dim tRate As HospitalMaxima = Nothing
            If Hospital IsNot Nothing Then
                If Hospital.HospitalGroup IsNot Nothing Then
                    Dim _GroupRate As HospitalEstimate = Session.FindObject(Of HospitalEstimate)(CriteriaOperator.Parse("HospitalGroup = ? and Treatment = ?", Hospital.HospitalGroup.Oid, Treatment.Oid))
                    If _GroupRate IsNot Nothing Then
                        HospitalBudget = _GroupRate.Estimate
                        HospitalBudgetSource = eBudgetSource.HospitalTreatment
                        If _GroupRate.IsPackage = "Y" Then
                            _isPackage = True
                            AccommodationBudget = 0
                            AnaesthetistBudget = 0
                            HospitalBudgetSource = eBudgetSource.Package
                        End If
                    Else
                        If Treatment.HospitalMaxima IsNot Nothing Then
                            If Hospital.HospitalGroup IsNot Nothing Then
                                tRate = Session.FindObject(Of HospitalMaxima)(CriteriaOperator.Parse("HospitalGroup = ? and Maxima = ?", Hospital.HospitalGroup.Oid, Treatment.HospitalMaxima.Oid))
                                If tRate IsNot Nothing Then
                                    HospitalBudget = tRate.Budget
                                    HospitalBudgetSource = eBudgetSource.HospitalMaxima
                                End If
                            End If
                        End If
                    End If
                    If _isPackage = False Then
                        AnaesthetistBudget = Treatment.AnaesthetistBudget
                        AnaesthetistBudgetSource = eBudgetSource.Treatment
                        If Hospital.AccomodationBand IsNot Nothing Then
                            AccommodationBudget = 0
                            AccommodationBudgetSource = eBudgetSource.HospitalAccomodation
                            If Not String.IsNullOrWhiteSpace(Treatment.LengthOfStay) Then
                                Dim _hospitalAccomodationRate As HospitalAccomodationRate = Session.FindObject(Of HospitalAccomodationRate)(CriteriaOperator.Parse("HospitalGroup = ? and AccommodationBand = ? and AccommodationType = ? and LengthOfStay = ?", Hospital.HospitalGroup.Oid, Hospital.AccomodationBand.Oid, eAccommodationType.Day, LengthOfStay))
                                If _hospitalAccomodationRate IsNot Nothing Then
                                    AccommodationBudget += _hospitalAccomodationRate.Budget
                                End If
                            End If
                            If Treatment.IClevel2 > 0 Then
                                Dim _hospitalAccomodationRate As HospitalAccomodationRate = Session.FindObject(Of HospitalAccomodationRate)(CriteriaOperator.Parse("HospitalGroup = ? and AccommodationBand = ? and AccommodationType = ? and LengthOfStay = ?", Hospital.HospitalGroup.Oid, Hospital.AccomodationBand.Oid, eAccommodationType.Day, LengthOfStay))
                                If _hospitalAccomodationRate IsNot Nothing Then
                                    AccommodationBudget += _hospitalAccomodationRate.Budget
                                End If
                            End If
                            If Treatment.IClevel3 > 0 Then
                                Dim _hospitalAccomodationRate As HospitalAccomodationRate = Session.FindObject(Of HospitalAccomodationRate)(CriteriaOperator.Parse("HospitalGroup = ? and AccommodationBand = ? and AccommodationType = ? and LengthOfStay = ?", Hospital.HospitalGroup.Oid, Hospital.AccomodationBand.Oid, eAccommodationType.Day, LengthOfStay))
                                If _hospitalAccomodationRate IsNot Nothing Then
                                    AccommodationBudget += _hospitalAccomodationRate.Budget
                                End If
                            End If
                        Else
                            AccommodationBudgetSource = eBudgetSource.System
                        End If
                    Else
                        AnaesthetistBudgetSource = eBudgetSource.Package
                        AccommodationBudgetSource = eBudgetSource.Package
                    End If
                End If
            End If
            If HospitalBudget > 0 And OutOfNetWork = True And Claim.Client.MarkUp > 0 And Treatment.ExcludefromMarkup = False Then
                HospitalBudget = HospitalBudget * (1 + Claim.Client.MarkUp)
            End If
            Budget = (Consultantbudget + HospitalBudget + AccommodationBudget + AnaesthetistBudget) * Qty

        End Sub
        <Association("Authorisation-InvoiceLines")> _
        Public ReadOnly Property InvoiceLines() As XPCollection(Of InvoiceLine)
            Get
                Return GetCollection(Of InvoiceLine)("InvoiceLines")
            End Get
        End Property
        <Association("Authorisation-Communications")> _
        Public ReadOnly Property Communications() As XPCollection(Of Communication)
            Get
                Return GetCollection(Of Communication)("Communications")
            End Get
        End Property
        <Association("Authorisation-TrackingNotes")> _
        Public ReadOnly Property TrackingNotes() As XPCollection(Of TrackingNote)
            Get
                Return GetCollection(Of TrackingNote)("TrackingNotes")
            End Get
        End Property
        Public ReadOnly Property AverageCost() As Double
            Get
                Return Convert.ToDouble(Session.Evaluate(GetType(vw_InvoiceDetail), CriteriaOperator.Parse("sum(InvoiceTotal)"), CriteriaOperator.Parse("TreatmentOid= ? ", Treatment)))
            End Get
        End Property
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
    Public Class EAPResponse
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
        Private _completed As Char
        Public Property Completed() As Char
            Get
                Return _completed
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("Completed", _completed, value)
            End Set
        End Property
        Private _sessions As Integer
        Public Property Sessions() As Integer
            Get
                Return _sessions
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Claim", _sessions, value)
            End Set
        End Property
        Private _overriddenBy As User
        Public Property OverRiddenBy() As User
            Get
                Return _overriddenBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("OverRiddenBy", _overriddenBy, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("EAP {0}", Claim)
        End Function
    End Class
End Namespace