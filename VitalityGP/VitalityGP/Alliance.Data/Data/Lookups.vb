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
    Public Class NextActionType
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _OID As Integer
        <Key>
        Public Property Oid() As Integer
            Get
                Return _OID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Oid", _OID, value)
            End Set
        End Property
        Private _actionName As String
        <Size(20)>
        Public Property NextAction() As String
            Get
                Return _actionName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NextAction", _actionName, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", NextAction)
        End Function
    End Class
    Public Class ActionType
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _OID As Integer
        <Key>
        Public Property Oid() As Integer
            Get
                Return _OID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Oid", _OID, value)
            End Set
        End Property
        Private _actionName As String
        <Size(15)> _
        Public Property ActionItem() As String
            Get
                Return _actionName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ActionName", _actionName, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", ActionItem)
        End Function
    End Class
    Public Class AffectedSystem
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
        Private fAffectedSystem As String
        <Size(50)> _
        Public Property AffectedSystem() As String
            Get
                Return fAffectedSystem
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AffectedSystem", fAffectedSystem, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", AffectedSystem)
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
    Public Class Symptom
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
        Private fSymptom As String
        <Size(75)> _
        Public Property Symptom() As String
            Get
                Return fSymptom
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Symptom", fSymptom, value)
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
        Private _affectedSystem As AffectedSystem
        Public Property AffectedSystem() As AffectedSystem
            Get
                Return _affectedSystem
            End Get
            Set(ByVal value As AffectedSystem)
                SetPropertyValue(Of AffectedSystem)("AffectedSystem", _affectedSystem, value)
            End Set
        End Property
        Private _subSpecialism As SubSpecialism
        Public Property SubSpecialism() As SubSpecialism
            Get
                Return _subSpecialism
            End Get
            Set(ByVal value As SubSpecialism)
                SetPropertyValue(Of SubSpecialism)("SubSpecialism", _subSpecialism, value)
            End Set
        End Property
        Private _claimActionType As eActionType
        Public Property ClaimActionType() As eActionType
            Get
                Return _claimActionType
            End Get
            Set(ByVal value As eActionType)
                SetPropertyValue(Of eActionType)("ClaimActionType", _claimActionType, value)
            End Set
        End Property
        Private _complexTraige As Boolean
        Public Property ComplexTraige() As Boolean
            Get
                Return _complexTraige
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ComplexTraige", _complexTraige, value)
            End Set
        End Property
        Private _active As Boolean
        Public Property Active() As Boolean
            Get
                Return _active
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Active", _active, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Symptom)
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
    'Public Class Diagnosis
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
    '    Private fDiagnosis As String
    '    <Size(75)> _
    '    Public Property Diagnosis() As String
    '        Get
    '            Return fDiagnosis
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Diagnosis", fDiagnosis, value)
    '        End Set
    '    End Property
    '    Private fICD9 As String
    '    <Size(10)> _
    '    Public Property ICD9() As String
    '        Get
    '            Return fICD9
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("ICD9", fICD9, value)
    '        End Set
    '    End Property
    '    Private fICD10 As String
    '    <Size(10)> _
    '    Public Property ICD10() As String
    '        Get
    '            Return fICD10
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("ICD10", fICD10, value)
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
    '    Private fAffectedSystem As Integer
    '    Public Property AffectedSystem() As Integer
    '        Get
    '            Return fAffectedSystem
    '        End Get
    '        Set(ByVal value As Integer)
    '            SetPropertyValue(Of Integer)("AffectedSystem", fAffectedSystem, value)
    '        End Set
    '    End Property
    '    Public Overrides Function ToString() As String
    '        Return String.Format("{0}", Diagnosis)
    '    End Function
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
    'Public Class Benefit
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
    '    Private fBenefit As String
    '    <Size(35)> _
    '    Public Property Benefit() As String
    '        Get
    '            Return fBenefit
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Benefit", fBenefit, value)
    '        End Set
    '    End Property
    '    Private fSequence As Integer
    '    Public Property Sequence() As Integer
    '        Get
    '            Return fSequence
    '        End Get
    '        Set(ByVal value As Integer)
    '            SetPropertyValue(Of Integer)("Sequence", fSequence, value)
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
    '    Public Overrides Function ToString() As String
    '        Return String.Format("{0}", Benefit)
    '    End Function
    'End Class
    'Public Class BenefitSubDetail
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
    '    Private fSubBenefit As String
    '    <Size(35)> _
    '    Public Property SubBenefit() As String
    '        Get
    '            Return fSubBenefit
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("SubBenefit", fSubBenefit, value)
    '        End Set
    '    End Property
    '    Private fSequence As Integer
    '    Public Property Sequence() As Integer
    '        Get
    '            Return fSequence
    '        End Get
    '        Set(ByVal value As Integer)
    '            SetPropertyValue(Of Integer)("Sequence", fSequence, value)
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
    'Public Class BenefitDetail
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
    '    Private fBenefitDetail As String
    '    <Size(35)> _
    '    Public Property BenefitDetail() As String
    '        Get
    '            Return fBenefitDetail
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("BenefitDetail", fBenefitDetail, value)
    '        End Set
    '    End Property
    '    Private fSequence As Integer
    '    Public Property Sequence() As Integer
    '        Get
    '            Return fSequence
    '        End Get
    '        Set(ByVal value As Integer)
    '            SetPropertyValue(Of Integer)("Sequence", fSequence, value)
    '        End Set
    '    End Property
    '    Private frestrictedBenefit As Benefit
    '    Public Property RestrictedBenefit() As Benefit
    '        Get
    '            Return frestrictedBenefit
    '        End Get
    '        Set(ByVal value As Benefit)
    '            SetPropertyValue(Of Benefit)("RestrictedBenefit", frestrictedBenefit, value)
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
    '    Public Overrides Function ToString() As String
    '        Return String.Format("{0}", BenefitDetail)
    '    End Function
    'End Class
    Public Class AdmissionStatus
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _OID As Integer
        <Key>
        Public Property Oid() As Integer
            Get
                Return _OID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Oid", _OID, value)
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
        Private fAdmissionStatus As String
        <Size(20)> _
        Public Property AdmissionStatus() As String
            Get
                Return fAdmissionStatus
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AdmissionStatus", fAdmissionStatus, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("{0}", AdmissionStatus)
        End Function
    End Class
    Public Class Maxima
        Inherits XPCustomObject
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
        Private _OID As Integer
        <Key>
        Public Property Oid() As Integer
            Get
                Return _OID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Oid", _OID, value)
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
        Private _category As String
        <Size(1)> _
        Public Property Category() As String
            Get
                Return _category
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Category", _category, value)
            End Set
        End Property
        Private _maximaCategory As String
        <Size(10)> _
        Public Property MaximaCategory() As String
            Get
                Return _maximaCategory
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MaximaCategory", _maximaCategory, value)
            End Set
        End Property

        Private _budget As Decimal
        Public Property Budget() As Decimal
            Get
                Return _budget
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Budget", _budget, value)
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
    Public Class IncurredCategory
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
        Private _incurredCategory As String
        <Size(35)> _
        Public Property IncurredCategory() As String
            Get
                Return _incurredCategory
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("IncurredCategory", _incurredCategory, value)
            End Set
        End Property
        Private _sequenceNo As Integer
        Public Property SequenceNo() As Integer
            Get
                Return _sequenceNo
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Sequence", _sequenceNo, value)
            End Set
        End Property
        Private _parent As IncurredCategory
        <Association("IncurredCategoryChildren")> _
        Public Property Parent() As IncurredCategory
            Get
                Return _parent
            End Get
            Set(ByVal value As IncurredCategory)
                SetPropertyValue("Parent", _parent, value)
            End Set
        End Property
        <Association("IncurredCategoryChildren")> _
        Public ReadOnly Property Children() As XPCollection(Of IncurredCategory)
            Get
                Return GetCollection(Of IncurredCategory)("Children")
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", IncurredCategory)
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
    'Public Class AnalysisCode
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
    '    Private fAnalysisCode As String
    '    <Size(20)> _
    '    Public Property AnalysisCode() As String
    '        Get
    '            Return fAnalysisCode
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("AnalysisCode", fAnalysisCode, value)
    '        End Set
    '    End Property
    '    Private fSequence As Integer
    '    Public Property Sequence() As Integer
    '        Get
    '            Return fSequence
    '        End Get
    '        Set(ByVal value As Integer)
    '            SetPropertyValue(Of Integer)("Sequence", fSequence, value)
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
    Public Class ReasonHeld
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
        Private fHeldReason As String
        <Size(20)> _
        Public Property HeldReason() As String
            Get
                Return fHeldReason
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HeldReason", fHeldReason, value)
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
        Private fSequence As Integer
        Public Property Sequence() As Integer
            Get
                Return fSequence
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Sequence", fSequence, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", HeldReason)
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
    Public Class ReasonLeft
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
        Private _sequenceNo As Integer
        Public Property SequenceNo() As Integer
            Get
                Return _sequenceNo
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SequenceNo", _sequenceNo, value)
            End Set
        End Property
        Private _reasonLeft As String
        <Size(20)> _
        Public Property ReasonLeft() As String
            Get
                Return _reasonLeft
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReasonLeft", _reasonLeft, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("{0}", ReasonLeft)
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
    Public Class TaskLabel
        Inherits XPCustomObject
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
        Private _OID As Integer
        <Key>
        Public Property Oid() As Integer
            Get
                Return _OID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Oid", _OID, value)
            End Set
        End Property
        Private ftaskLabel As String
        <Size(15)> _
        Public Property TaskLabel() As String
            Get
                Return ftaskLabel
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TaskLabel", ftaskLabel, value)
            End Set
        End Property
        Private ffullName As String
        Public Property FullName() As String
            Get
                Return ffullName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FullName", ffullName, value)
            End Set
        End Property
        Private _color As Integer
        Public Property Color() As Integer
            Get
                Return _color
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("Color", _color, value)
            End Set
        End Property
        Private fSequenceNo As Integer
        Public Property SequenceNo() As Integer
            Get
                Return fSequenceNo
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Sequence", fSequenceNo, value)
            End Set
        End Property
        Private fDefault As Boolean
        Public Property [Default]() As Boolean
            Get
                Return fDefault
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Default ", fDefault, value)
            End Set
        End Property
        Private fIsTask As Boolean
        Public Property IsTask() As Boolean
            Get
                Return fIsTask
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsTask ", fIsTask, value)
            End Set
        End Property
        Private fDefaultAllDay As Boolean
        Public Property DefaultAllDay() As Boolean
            Get
                Return fDefaultAllDay
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("DefaultAllDay ", fDefaultAllDay, value)
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
    Public Class ComboBoxItem
        Private _value As String
        Private _text As String

        Public Sub New(ByVal value As String, ByVal text As String)
            _value = value
            _text = text
        End Sub

        Public Overrides Function ToString() As String
            Return _text
        End Function
    End Class
    Public Class ICD10
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
        End Sub
        Private _OID As Integer
        <Key>
        Public Property Oid() As Integer
            Get
                Return _OID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Oid", _OID, value)
            End Set
        End Property
        Private _parent As ICD10
        <Association("ICD10Children")> _
        Public Property Parent() As ICD10
            Get
                Return _parent
            End Get
            Set(ByVal value As ICD10)
                SetPropertyValue("Parent", _parent, value)
            End Set
        End Property
        <Association("ICD10Children")> _
        Public ReadOnly Property Children() As XPCollection(Of ICD10)
            Get
                Return GetCollection(Of ICD10)("Children")
            End Get
        End Property
        Private _level As Integer
        <Indexed>
        Public Property Level() As Integer
            Get
                Return _level
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Level", _level, value)
            End Set
        End Property
        Private _code As String
        Public Property Code() As String
            Get
                Return _code
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", _code, value)
            End Set
        End Property
        Private _header As Integer
        Public Property Header() As Integer
            Get
                Return _header
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Header", _header, value)
            End Set
        End Property
        Private _diagnosis As String
        <Size(60)> _
        Public Property Diagnosis() As String
            Get
                Return _diagnosis
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Diagnosis", _diagnosis, value)
            End Set
        End Property
    End Class
End Namespace