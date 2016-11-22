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

Namespace Alliance.Data
    Public Class ReferralTreatment
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
        Private _insurer As Insurer
        Public Property Insurer() As Insurer
            Get
                Return _insurer
            End Get
            Set(ByVal value As Insurer)
                SetPropertyValue(Of Insurer)("Insurer", _insurer, value)
            End Set
        End Property
        Private _patient As Patient
        Public Property Patient() As Patient
            Get
                Return _patient
            End Get
            Set(ByVal value As Patient)
                SetPropertyValue(Of Patient)("Patient", _patient, value)
            End Set
        End Property
        Private _treatmentType As eTreatmentType
        Public Property TreatmentType() As eTreatmentType
            Get
                Return _treatmentType
            End Get
            Set(ByVal value As eTreatmentType)
                SetPropertyValue(Of eTreatmentType)("TreatmentType", _treatmentType, value)
            End Set
        End Property
        Private _referral As Referral
        <Association("Referral-Treatments")> _
        Public Property Referral() As Referral
            Get
                Return _referral
            End Get
            Set(ByVal value As Referral)
                SetPropertyValue(Of Referral)("Referral", _referral, value)
            End Set
        End Property
        Private _source As eFurtherTreatmentSource
        Public Property Source() As eFurtherTreatmentSource
            Get
                Return _source
            End Get
            Set(ByVal value As eFurtherTreatmentSource)
                SetPropertyValue(Of eFurtherTreatmentSource)("Source", _confirmedBy, value)
            End Set
        End Property
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property SourceComment() As String
            Get
                Return GetDelayedPropertyValue(Of String)("SourceComment")
            End Get
            Set(ByVal value As String)
                SetDelayedPropertyValue("SourceComment", value)
            End Set
        End Property
  
        Private _treatmentDate As Date
        Public Property TreatmentDate() As Date
            Get
                Return _treatmentDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("TreatmentDate", _treatmentDate, value)
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
        Private _status As eFurtherTreatmentStatus
        Public Property Status() As eFurtherTreatmentStatus
            Get
                Return _status
            End Get
            Set(ByVal value As eFurtherTreatmentStatus)
                SetPropertyValue(Of eFurtherTreatmentStatus)("Status", _status, value)
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
        Private fconsultant As Consultant
        Public Property Consultant() As Consultant
            Get
                Return fconsultant
            End Get
            Set(ByVal value As Consultant)
                SetPropertyValue(Of Consultant)("Consultant", fconsultant, value)
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
        Private _authorisationNo As String
        <Size(20)> _
        Public Property AuthorisationNo() As String
            Get
                Return _authorisationNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AuthorisationNo", _authorisationNo, value)
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
        Private _oneStopShop As Boolean
        Public Property OneStopShop As Boolean
            Get
                Return _oneStopShop
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("OneStopShop", _oneStopShop, value)
            End Set
        End Property
        Private _anesthetic As Anesthetic
        Public Property Anesthetic As Anesthetic
            Get
                Return _anesthetic
            End Get
            Set(ByVal value As Anesthetic)
                SetPropertyValue(Of Anesthetic)("Anesthetic", _anesthetic, value)
            End Set
        End Property
        Private _diagnostics As Diagnostic
        Public Property Diagnostics As Diagnostic
            Get
                Return _diagnostics
            End Get
            Set(ByVal value As Diagnostic)
                SetPropertyValue(Of Diagnostic)("Diagnostics", _diagnostics, value)
            End Set
        End Property
        Private _booked As Boolean
        Public Property Booked As Boolean
            Get
                Return _booked
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Booked", _booked, value)
            End Set
        End Property
        Private _physio As Boolean
        Public Property Physio As Boolean
            Get
                Return _physio
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Physio", _physio, value)
            End Set
        End Property
        Private _neuroConsultation As Boolean
        Public Property NeuroConsultation As Boolean
            Get
                Return _neuroConsultation
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("NeuroConsultation", _neuroConsultation, value)
            End Set
        End Property
        Private _didNotAttend As Boolean
        Public Property DidNotAttend As Boolean
            Get
                Return _didNotAttend
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("DidNotAttend", _didNotAttend, value)
            End Set
        End Property
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
        Private _confirmed As Date
        Public Property Confirmed() As Date
            Get
                Return _confirmed
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("Confirmed", _confirmed, value)
            End Set
        End Property
        Private _confirmedBy As eFurtherTreatmentSource
        Public Property ConfirmedBy() As eFurtherTreatmentSource
            Get
                Return _confirmedBy
            End Get
            Set(ByVal value As eFurtherTreatmentSource)
                SetPropertyValue(Of eFurtherTreatmentSource)("ConfirmedBy", _confirmedBy, value)
            End Set
        End Property
        Private _invoiceDate As Date
        Public Property InvoiceDate() As Date
            Get
                Return _invoiceDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("InvoiceDate", _invoiceDate, value)
            End Set
        End Property
        Private _invoiceNo As String
        <Size(10)>
        Public Property InvoiceNo() As String
            Get
                Return _invoiceNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InvoiceNo", _invoiceNo, value)
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
        Private _invoiceValue As Double
        Public Property InvoiceValue() As Double
            Get
                Return _invoiceValue
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("InvoiceValue", _invoiceValue, value)
            End Set
        End Property
        Private _cost As Double
        Public Property Cost() As Double
            Get
                Return _cost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Cost", _cost, value)
            End Set
        End Property
        Private _consultantFee As Double
        Public Property ConsultantFee() As Double
            Get
                Return _consultantFee
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("ConsultantFee", _consultantFee, value)
            End Set
        End Property
        <Association("FurtherTreatment-Procedures")> _
        Public ReadOnly Property Procedures() As XPCollection(Of ReferralProcedure)
            Get
                Return GetCollection(Of ReferralProcedure)("Procedures")
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
    Public Class ReferralProcedure
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
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnDeleting()
            MyBase.OnDeleting()
            DeletedBy = ProjectCurrentUser.GetGlobalUser(Session)
            DeletedAt = DateTime.Now
        End Sub
        Private _position As Integer
        Public Property Position() As Integer
            Get
                Return _position
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Position", _position, value)
            End Set
        End Property
        Private _furtherTreatment As ReferralTreatment
        <Association("FurtherTreatment-Procedures")> _
        Public Property FurtherTreatment() As ReferralTreatment
            Get
                Return _furtherTreatment
            End Get
            Set(ByVal value As ReferralTreatment)
                SetPropertyValue(Of ReferralTreatment)("FurtherTreatment", _furtherTreatment, value)
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
        Public Property TreatmentAttribute As TreatmentAttribute
            Get
                Return fAttribute
            End Get
            Set(ByVal value As TreatmentAttribute)
                SetPropertyValue(Of TreatmentAttribute)("TreatmentAttribute", fAttribute, value)
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
        Private _paymentTotal As Double
        Public Property PaymentTotal() As Double
            Get
                Return _paymentTotal
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("TotalValue", _paymentTotal, value)
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