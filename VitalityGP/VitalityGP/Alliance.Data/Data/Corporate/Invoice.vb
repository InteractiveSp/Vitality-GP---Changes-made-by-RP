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
    Public Class InvoiceStatus
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal Status As String)
            Me.New(session)
            Me.fStatus = Status
        End Sub
        Private _oID As Integer
        <Key>
        Public Property Oid() As Integer
            Get
                Return _oID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Oid", _oID, value)
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
        <Size(20)> _
        Public Property Status() As String
            Get
                Return fStatus
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InvoiceSource", fStatus, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Status)
        End Function
    End Class
    Public Class InvoiceSource
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal Source As String)
            Me.New(session)
            Me.Source = Source
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
        Private fSource As String
        <Size(10)> _
        Public Property Source() As String
            Get
                Return fSource
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Source", fSource, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Source)
        End Function
    End Class
    Public Class Invoice
        Inherits AuditedBase
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
        Protected Overrides Sub OnDeleting()
            MyBase.OnDeleting()
            DeletedBy = ProjectCurrentUser.GetGlobalUser(Session)
            DeletedAt = DateTime.Now
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
        <Association("Beneficiary-Invoices")> _
           Public Property Beneficiary() As Beneficiary
            Get
                Return fBeneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", fBeneficiary, value)
            End Set
        End Property
        Private fProvider As Provider
        <NoForeignKey()>
        Public Property Provider() As Provider
            Get
                Return fProvider
            End Get
            Set(ByVal value As Provider)
                SetPropertyValue(Of Provider)("Provider", fProvider, value)
            End Set
        End Property
        Private fclaim As Claim
        Public Property Claim() As Claim
            Get
                Return fclaim
            End Get
            Set(ByVal value As Claim)
                Dim oldClaim As Claim = fclaim
                SetPropertyValue(Of Claim)("Claim", fclaim, value)
                If (Not IsLoading) AndAlso (Not IsSaving) AndAlso oldClaim IsNot fclaim Then
                    oldClaim = If((oldClaim IsNot Nothing), oldClaim, fclaim)
                    oldClaim.UpdateIncurredCost(True)
                End If
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
        <Association("BusinessUnit-Invoices")> _
        Public Property BusinessUnit() As BusinessUnit
            Get
                Return _BusinessUnit
            End Get
            Set(ByVal value As BusinessUnit)
                SetPropertyValue(Of BusinessUnit)("BusinessUnit", _BusinessUnit, value)
            End Set
        End Property
        Private fmajorCode As Treatment
        Public Property MajorCode As Treatment
            Get
                Return fmajorCode
            End Get
            Set(ByVal value As Treatment)
                SetPropertyValue(Of Treatment)("MajorCode", fmajorCode, value)
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
        Private fOpportunityID As Integer
        Public Property OpportunityID() As Integer
            Get
                Return fOpportunityID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("OpportunityID", fOpportunityID, value)
            End Set
        End Property
        Private ffurtherID As Integer
        Public Property furtherID() As Integer
            Get
                Return ffurtherID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("furtherID", ffurtherID, value)
            End Set
        End Property
        Private _invoiceSource As eInvoiceSource
        Public Property InvoiceSource() As eInvoiceSource
            Get
                Return _invoiceSource
            End Get
            Set(ByVal value As eInvoiceSource)
                SetPropertyValue(Of eInvoiceSource)("InvoiceSource", _invoiceSource, value)
            End Set
        End Property
        Private _status As eInvoiceStatus
        Public Property InvoiceStatus() As eInvoiceStatus
            Get
                Return _status
            End Get
            Set(ByVal value As eInvoiceStatus)
                SetPropertyValue(Of eInvoiceStatus)("Status", _status, value)
            End Set
        End Property
        Private fExceptional As Boolean
        Public Property Exceptional() As Boolean
            Get
                Return fExceptional
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Exceptional", fExceptional, value)
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
        Private finvoiceScan As String
        <Size(255)> _
        Public Property Image() As String
            Get
                Return finvoiceScan
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InvoiceScan", finvoiceScan, value)
            End Set
        End Property
        Private fPackage As Boolean
        Public Property Package() As Boolean
            Get
                Return fPackage
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Package", fPackage, value)
            End Set
        End Property
        'Private fanalysisCode As String
        '<Size(10)> _
        'Public Property AnalysisCode() As String
        '    Get
        '        Return fanalysisCode
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("AnalysisCode", fanalysisCode, value)
        '    End Set
        'End Property
        Private _lengthofStay As String
        <Size(3)> _
        Public Property LengthOfStay() As String
            Get
                Return _lengthofStay
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LengthOfStay", _lengthofStay, value)
            End Set
        End Property
        Private fTreatmentDate As Date
        Public Property TreatmentDate() As Date
            Get
                Return fTreatmentDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("TreatmentDate", fTreatmentDate, value)
            End Set
        End Property
        Private fAdmissionDate As Date
        Public Property AdmissionDate() As Date
            Get
                Return fAdmissionDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("AdmissionDate", fAdmissionDate, value)
            End Set
        End Property
        Private fdischargeDate As Date
        Public Property DischargeDate() As Date
            Get
                Return fdischargeDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("DischargeDate", fdischargeDate, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
            End Set
        End Property
        Private finvoiceType As Char
        Public Property InvoiceType() As Char
            Get
                Return finvoiceType
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("InvoiceType", finvoiceType, value)
            End Set
        End Property
        Private _Invoice As Invoice
        Public Property LinkedInvoice() As Invoice
            Get
                Return _Invoice
            End Get
            Set(ByVal value As Invoice)
                SetPropertyValue("LinkedInvoice", _Invoice, value)
            End Set
        End Property
        Private fDate As Date
        Public Property [Date]() As Date
            Get
                Return fDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("Date", fDate, value)
            End Set
        End Property
        Private fReceived As Date
        Public Property Received() As DateTime
            Get
                Return fReceived
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Received", fReceived, value)
            End Set
        End Property
        Private fDateAuthorised As Date
        Public Property DateAuthorised() As DateTime
            Get
                Return fDateAuthorised
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DateAuthorised", fDateAuthorised, value)
            End Set
        End Property
        Private _paymentStatus As ePaymentStatus
        Public Property PaymentStatus() As ePaymentStatus
            Get
                Return _paymentStatus
            End Get
            Set(ByVal value As ePaymentStatus)
                SetPropertyValue(Of ePaymentStatus)("PaymentStatus", _paymentStatus, value)
            End Set
        End Property
        Private fDatePosted As Date
        Public Property DatePosted() As DateTime
            Get
                Return fDatePosted
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DatePosted", fDatePosted, value)
            End Set
        End Property
        Private fDatePostedExchequer As Date
        Public Property DatePostedExchequer() As DateTime
            Get
                Return fDatePostedExchequer
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DatePostedExchequer", fDatePostedExchequer, value)
            End Set
        End Property
        Private fPlAccount As String
        <Size(10)> _
        Public Property PlAccount() As String
            Get
                Return fPlAccount
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PlAccount", fPlAccount, value)
            End Set
        End Property
        Private fSlAccount As String
        <Size(10)> _
        Public Property SlAccount() As String
            Get
                Return fSlAccount
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SlAccount", fSlAccount, value)
            End Set
        End Property
        Private fReference As String
        <Size(20)> _
        Public Property Reference() As String
            Get
                Return fReference
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reference", fReference, value)
            End Set
        End Property
        Private fSIN As String
        <Size(15)> _
        Public Property SIN() As String
            Get
                Return fSIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SIN", fSIN, value)
            End Set
        End Property
        Private fSlDocState As String
        <Size(10)> _
        Public Property SlDocState() As String
            Get
                Return fSlDocState
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SlDocState", fSlDocState, value)
            End Set
        End Property

        Private fSINPaid As Date
        Public Property SINPaid() As Date
            Get
                Return fSINPaid
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("SINPaid", fSINPaid, value)
            End Set
        End Property
        Private fPIN As String
        <Size(15)> _
        Public Property PIN() As String
            Get
                Return fPIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PIN", fPIN, value)
            End Set
        End Property
        Private _DueDate As Date
        Public Property DueDate() As Date
            Get
                Return _DueDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("DueDate", _DueDate, value)
            End Set
        End Property

        Private fPlDocState As String
        <Size(1)> _
        Public Property PlDocState() As String
            Get
                Return fPlDocState
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PlDocState", fPlDocState, value)
            End Set
        End Property
        Private fPINPaid As Date
        Public Property PINPaid() As Date
            Get
                Return fPINPaid
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("PINPaid", fPINPaid, value)
            End Set
        End Property
        Private fPaymentDays As Integer
        Public Property PaymentDays() As Integer
            Get
                Return fPaymentDays
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PaymentDays", fPaymentDays, value)
            End Set
        End Property
        Private fpaymentDate As Date
        Public Property PaymentDate() As Date
            Get
                Return fpaymentDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("PaymentDate", fpaymentDate, value)
            End Set
        End Property
        Private _InvoiceTotal As Double
        Public Property InvoiceTotal() As Double
            Get
                Return _InvoiceTotal
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("TotalCost", _InvoiceTotal, value)
            End Set
        End Property
        Private _paymentTotal As Double
        Public Property PaymentTotal() As Double
            Get
                Return _paymentTotal
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("TotalValue", _paymentTotal, value)
            End Set
        End Property
        Private _rechargeTotal As Double
        Public Property RechargeTotal() As Double
            Get
                Return _rechargeTotal
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("RechargeTotalValue", _rechargeTotal, value)
            End Set
        End Property
        Private _incurredTotal As Double
        Public Property IncurredTotal() As Double
            Get
                Return _incurredTotal
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("IncurredTotal", _incurredTotal, value)
            End Set
        End Property
        Private _remittance As Remittance
        Public Property Remittance() As Remittance
            Get
                Return _remittance
            End Get
            Set(ByVal value As Remittance)
                SetPropertyValue(Of Remittance)("Remittance", _remittance, value)
            End Set
        End Property
        Private _eXcess As Double
        Public Property eXcess() As Double
            Get
                Return _eXcess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("eXcess", _eXcess, value)
            End Set
        End Property
        Private _eXcessLetterSent As Date
        Public Property eXcessLetterSent() As Date
            Get
                Return _eXcessLetterSent
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("eXcessLetterSent", _eXcessLetterSent, value)
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
        <Association("Invoice-InvoiceDetail")> _
        Public ReadOnly Property InvoiceLines() As XPCollection(Of InvoiceLine)
            Get
                Return GetCollection(Of InvoiceLine)("InvoiceLines")
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Reference)
        End Function
    End Class
    Public Class InvoiceLine
        Inherits AuditedBase

        Private fAttribute As TreatmentAttribute
        Private fTreatmentDate As DateTime

        Private fQty, fPaymentQty, fRechargeQty, fVATRate As Double

        Private fBenefitID, fSubBenefitID, fBenefitDetailsID, fchargeUnitId, fAnalysisID As String
        Private fGLCode As String

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
                IsMajorcode = False
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnDeleting()
            MyBase.OnDeleting()
            DeletedBy = ProjectCurrentUser.GetGlobalUser(Session)
            DeletedAt = DateTime.Now
        End Sub
        Private fInvoice As Invoice
        <Association("Invoice-InvoiceDetail")> _
        Public Property Invoice() As Invoice
            Get
                Return fInvoice
            End Get
            Set(ByVal value As Invoice)
                SetPropertyValue(Of Invoice)("Invoice", fInvoice, value)
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
        Private fAuthorisation As Authorisation
        <Association("Authorisation-InvoiceLines")> _
        Public Property Authorisation() As Authorisation
            Get
                Return fAuthorisation
            End Get
            Set(ByVal value As Authorisation)
                Dim oldAuthorisation As Authorisation = fAuthorisation
                SetPropertyValue(Of Authorisation)("Authorisation", fAuthorisation, value)
                If (Not IsLoading) AndAlso (Not IsSaving) AndAlso oldAuthorisation IsNot fAuthorisation Then
                    oldAuthorisation = If((oldAuthorisation IsNot Nothing), oldAuthorisation, fAuthorisation)
                    oldAuthorisation.UpdateIncurredCost(True)
                End If
            End Set
        End Property
        Private _paymentStatus As ePaymentStatus
        Public Property PaymentStatus() As ePaymentStatus
            Get
                Return _paymentStatus
            End Get
            Set(ByVal value As ePaymentStatus)
                SetPropertyValue(Of ePaymentStatus)("PaymentStatus", _paymentStatus, value)
            End Set
        End Property
        Private fLineno As Integer
        Public Property Lineno() As Integer
            Get
                Return fLineno
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Lineno", fLineno, value)
            End Set
        End Property
        Private fpolicy As Policy
        Public Property Policy() As Policy
            Get
                Return fpolicy
            End Get
            Set(ByVal value As Policy)
                SetPropertyValue(Of Policy)("Policy", fpolicy, value)
            End Set
        End Property
        Private _policyExcess As PolicyExcess
        <Association("PolicyeXcess-InvoiceLines")> _
        Public Property PolicyExcess() As PolicyExcess
            Get
                Return _policyExcess
            End Get
            Set(ByVal value As PolicyExcess)
                SetPropertyValue(Of PolicyExcess)("PolicyExcess", _policyExcess, value)
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
        Private fdescription As String
        <Size(250)> _
        Public Property Description() As String
            Get
                Return fdescription
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", fdescription, value)
            End Set
        End Property
        Public Property TreatmentAttribute As TreatmentAttribute
            Get
                Return fAttribute
            End Get
            Set(ByVal value As TreatmentAttribute)
                SetPropertyValue(Of TreatmentAttribute)("TreatmentAttribute", fAttribute, value)
            End Set
        End Property
        Private fisMajorcode As Boolean
        Public Property IsMajorcode() As Boolean
            Get
                Return fisMajorcode
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsMajorcode", fisMajorcode, value)
            End Set
        End Property
        Public Property TreatmentDate() As Date
            Get
                Return fTreatmentDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("TreatmentDate", fTreatmentDate, value)
            End Set
        End Property
        Public Property InvoiceQty() As Double
            Get
                Return fQty
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Qty", fQty, value)
            End Set
        End Property
        Private funitCost As Double
        Public Property InvoiceUnitCost() As Double
            Get
                Return funitCost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("UnitCost", funitCost, value)
            End Set
        End Property
        Private _invoiceTotal As Double
        Public Property InvoiceTotal() As Double
            Get
                Return _invoiceTotal
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("TotalValue", _invoiceTotal, value)
            End Set
        End Property
        Private _excessApplied As Double
        Public Property ExcessApplied() As Double
            Get
                Return _excessApplied
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("ExcessApplied", _excessApplied, value)
            End Set
        End Property
        Public Property PaymentQty() As Double
            Get
                Return fPaymentQty
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("PaymentQty", fPaymentQty, value)
            End Set
        End Property
        Private fUnitPrice As Double
        Public Property PaymentUnitCost() As Double
            Get
                Return fUnitPrice
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("UnitPrice", fUnitPrice, value)
            End Set
        End Property
        Private _paymentTotal As Double
        Public Property PaymentTotal() As Double
            Get
                Return _paymentTotal
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("TotalValue", _paymentTotal, value)
            End Set
        End Property
        Private _incurredQty As Double
        Public Property IncurredQty() As Double
            Get
                Return _incurredQty
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("IncurredQty", _incurredQty, value)
            End Set
        End Property
        Private fIncurredTotal As Double
        Public Property IncurredTotal() As Double
            Get
                Return fIncurredTotal
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("IncurredTotal", fIncurredTotal, value)
            End Set
        End Property
        Private fpaymentDate As Date
        Public Property PaymentDate() As Date
            Get
                Return fpaymentDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("PaymentDate", fpaymentDate, value)
            End Set
        End Property
        Public Property RechargeQty() As Double
            Get
                Return fRechargeQty
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("RechargeQty", fRechargeQty, value)
            End Set
        End Property
        Private fRechargePrice As Double
        Public Property RechargeUnitCost() As Double
            Get
                Return fRechargePrice
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("RechargeUnitCost", fRechargePrice, value)
            End Set
        End Property
        Private fRechargeTotal As Double
        Public Property RechargeTotal() As Double
            Get
                Return fRechargeTotal
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("RechargeTotal", fRechargeTotal, value)
            End Set
        End Property
        Private _eXcess As Double
        Public Property eXcess() As Double
            Get
                Return _eXcess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("eXcess", _eXcess, value)
            End Set
        End Property
        Private fadmissionStatus As eAdmissionStatus
        Public Property AdmissionStatus() As eAdmissionStatus
            Get
                Return fadmissionStatus
            End Get
            Set(ByVal value As eAdmissionStatus)
                SetPropertyValue(Of eAdmissionStatus)("AdmissionStatus", fadmissionStatus, value)
            End Set
        End Property
        Private fBenefit As BenefitLimit
        Public Property Benefit() As BenefitLimit
            Get
                Return fBenefit
            End Get
            Set(ByVal value As BenefitLimit)
                SetPropertyValue(Of BenefitLimit)("Benefit", fBenefit, value)
            End Set
        End Property
        Private _subBenefit As BenefitLimit
        Public Property SubBenefit() As BenefitLimit
            Get
                Return _subBenefit
            End Get
            Set(ByVal value As BenefitLimit)
                SetPropertyValue(Of BenefitLimit)("SubBenefit", _subBenefit, value)
            End Set
        End Property
        Private fBenefitDetail As BenefitLimit
        Public Property BenefitDetail() As BenefitLimit
            Get
                Return fBenefitDetail
            End Get
            Set(ByVal value As BenefitLimit)
                SetPropertyValue(Of BenefitLimit)("BenefitDetail", fBenefitDetail, value)
            End Set
        End Property

        Private fpaymentID As Integer
        Public Property PaymentID() As Integer
            Get
                Return fpaymentID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("paymentID", fpaymentID, value)
            End Set
        End Property
        'Private ftransferNumber As Integer
        'Public Property TransferNumber() As Integer
        '    Get
        '        Return ftransferNumber
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("TransferNumber", ftransferNumber, value)
        '    End Set
        'End Property

        Private fStatus As eInvoiceStatus
        Public Property InvoiceStatus() As eInvoiceStatus
            Get
                Return fStatus
            End Get
            Set(ByVal value As eInvoiceStatus)
                SetPropertyValue(Of eInvoiceStatus)("InvoiceStatus", fStatus, value)
            End Set
        End Property
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return GetDelayedPropertyValue(Of String)("Notes")
            End Get
            Set(ByVal value As String)
                SetDelayedPropertyValue("Notes", value)
            End Set
        End Property
        'Start Of TBD ----------------
        Private _Old360ID As Integer
        Public Property Old360ID() As Integer
            Get
                Return _Old360ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Old360ID", _Old360ID, value)
            End Set
        End Property
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
        'End Of TBD ----------------
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
    Public Class Payment
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
        Private fType As Integer
        Public Property Type() As Integer
            Get
                Return fType
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Type", fType, value)
            End Set
        End Property

        Private fStatus As Integer
        Public Property Status() As Integer
            Get
                Return fStatus
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Status", fStatus, value)
            End Set
        End Property
        Private fDate As Date
        Public Property [Date]() As Date
            Get
                Return fDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("Date", fDate, value)
            End Set
        End Property
        Private fReference As String
        <Size(20)> _
        Public Property Reference() As String
            Get
                Return fReference
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reference", fReference, value)
            End Set
        End Property
        Private fValue As Double
        Public Property Value() As Double
            Get
                Return fValue
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Value", fValue, value)
            End Set
        End Property
        Private _invoice As Invoice
        Public Property Invoice() As Invoice
            Get
                Return _invoice
            End Get
            Set(ByVal value As Invoice)
                SetPropertyValue(Of Invoice)("Invoice", _invoice, value)
            End Set
        End Property
        Private _invoiceReference As String
        <Size(20)> _
        Public Property InvoiceReference() As String
            Get
                Return _invoiceReference
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InvoiceReference", _invoiceReference, value)
            End Set
        End Property
        Private fInvoiceDetail As InvoiceLine
        Public Property InvoiceDetail() As InvoiceLine
            Get
                Return fInvoiceDetail
            End Get
            Set(ByVal value As InvoiceLine)
                SetPropertyValue(Of InvoiceLine)("InvoiceDetail", fInvoiceDetail, value)
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
    Public Class Remittance
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
        Private fDate As Date
        Public Property [Date]() As Date
            Get
                Return fDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("Date", fDate, value)
            End Set
        End Property
        Private _reference As String
        <Size(30)> _
        Public Property Reference() As String
            Get
                Return _reference
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reference", _reference, value)
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
        Private _Insurer As Insurer
        Public Property Insurer() As Insurer
            Get
                Return _Insurer
            End Get
            Set(ByVal value As Insurer)
                SetPropertyValue(Of Insurer)("Insurer", _Insurer, value)
            End Set
        End Property
        Private _RemitNo As String
        <Size(10)> _
        Public Property RemitNo() As String
            Get
                Return _RemitNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RemitNo", _RemitNo, value)
            End Set
        End Property
        Private fValue As Double
        Public Property Value() As Double
            Get
                Return fValue
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Value", fValue, value)
            End Set
        End Property
        Private _document As LibraryDoc
        Public Property Document() As LibraryDoc
            Get
                Return _document
            End Get
            Set(ByVal value As LibraryDoc)
                SetPropertyValue(Of LibraryDoc)("Document", _document, value)
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
