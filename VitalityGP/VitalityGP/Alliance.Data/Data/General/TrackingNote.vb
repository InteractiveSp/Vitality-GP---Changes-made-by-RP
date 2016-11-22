Imports System
Imports DevExpress.Xpo
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data
    Public Class TrackingNote
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
        Private fentitytype As EntityType
        Public Property EntityType() As EntityType
            Get
                Return fentitytype
            End Get
            Set(ByVal value As EntityType)
                SetPropertyValue(Of EntityType)("EntityType", fentitytype, value)
            End Set
        End Property
        Private _crmID As Integer
        <Indexed(Unique:=False)>
        Public Property CrmID() As Integer
            Get
                Return _crmID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CrmID", _crmID, value)
            End Set
        End Property
        Private _stage As String
        <Size(10)>
        Public Property Stage() As String
            Get
                Return _stage
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Stage", _stage, value)
            End Set
        End Property
        Private _patient As Patient
        <Association("Patient-TrackingNotes")> _
        Public Property Patient() As Patient
            Get
                Return _patient
            End Get
            Set(ByVal value As Patient)
                SetPropertyValue(Of Patient)("Patient", _patient, value)
            End Set
        End Property
        Private _beneficiary As Beneficiary
        <Association("Beneficiary-TrackingNotes")> _
        Public Property Beneficiary() As Beneficiary
            Get
                Return _beneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", _beneficiary, value)
            End Set
        End Property
        Private _claim As Claim
        <Association("Claim-TrackingNotes")> _
        Public Property Claim() As Claim
            Get
                Return _claim
            End Get
            Set(ByVal value As Claim)
                SetPropertyValue(Of Claim)("Claim", _claim, value)
            End Set
        End Property
        Private _authorisation As Authorisation
        <Association("Authorisation-TrackingNotes")> _
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _referral As Referral
        <Association("Referral-TrackingNotes")> _
        Public Property Referral() As Referral
            Get
                Return _referral
            End Get
            Set(ByVal value As Referral)
                SetPropertyValue(Of Referral)("Referral", _referral, value)
            End Set
        End Property
        Private _parent As TrackingNote
        Public Property Parent() As TrackingNote
            Get
                Return _parent
            End Get
            Set(ByVal value As TrackingNote)
                SetPropertyValue("Parent", _parent, value)
            End Set
        End Property
        Private _nextAction As eNextActionType
        Public Property NextAction() As eNextActionType
            Get
                Return _nextAction
            End Get
            Set(ByVal value As eNextActionType)
                SetPropertyValue("NextActionType", _nextAction, value)
            End Set
        End Property
        Private _nextActionDue As DateTime
        <Indexed(Unique:=False)>
       Public Property NextActionDue() As DateTime
            Get
                Return _nextActionDue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("NextActionDue", _nextActionDue, value)
            End Set
        End Property
        Private _nextActionCompleted As DateTime
        Public Property NextActionCompleted() As DateTime
            Get
                Return _nextActionCompleted
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("NextActionCompleted", _nextActionCompleted, value)
            End Set
        End Property
        Private _assigneduser As User
        Public Property AssignedUser() As User
            Get
                Return _assigneduser
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("AssignedUser", _assigneduser, value)
            End Set
        End Property
        Private _assignedteam As Team
        Public Property AssignedTeam() As Team
            Get
                Return _assignedteam
            End Get
            Set(ByVal value As Team)
                SetPropertyValue(Of Team)("AssignedTeam", _assignedteam, value)
            End Set
        End Property
        Private _deferredCount As Integer
        Public Property DeferredCount() As Integer
            Get
                Return _deferredCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DeferredCount", _deferredCount, value)
            End Set
        End Property
        Private _linkedDocument As LinkedDocument
        Public Property LinkedDocument() As LinkedDocument
            Get
                Return _linkedDocument
            End Get
            Set(ByVal value As LinkedDocument)
                SetPropertyValue(Of LinkedDocument)("LinkedDocument", _linkedDocument, value)
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
End Namespace