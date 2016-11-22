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
    Public Enum eReasonClosed
        Discharged = 10
        Passback = 20
        Duplicate = 30
        IncorrectReferral = 40
    End Enum
    Public Class PassBackCategory
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
        Private _passBackCategory As String
        <Size(120)>
        Public Property PassBackCategory() As String
            Get
                Return _passBackCategory
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PassBackCategory", _passBackCategory, value)
            End Set
        End Property
        Private _code As String
        <Size(40)>
        Public Property Code() As String
            Get
                Return _code
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", _code, value)
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
        Private _Sequence As Integer
        Public Property Sequence() As Integer
            Get
                Return _Sequence
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Sequence", _Sequence, value)
            End Set
        End Property

        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return Me.PassBackCategory
            Else
                Return String.Format("(New {0}) ", "PassBack")
            End If

        End Function
        <NonPersistent()>
        Public ReadOnly Property Description() As String
            Get
                Return Me.PassBackCategory
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
    Public Class PCASource
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
        Private _pCASource As String
        <Size(20)>
        Public Property PCASource() As String
            Get
                Return _pCASource
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PCASource", _pCASource, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return Me.PCASource
            Else
                Return String.Format("(New {0}) ", "PCASource")
            End If

        End Function
        <NonPersistent()> _
        Public ReadOnly Property Description() As String
            Get
                Return Me.PCASource
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
    Public Class ReferralSource
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
        Private _referralSource As String
        <Size(20)>
        Public Property ReferralSource() As String
            Get
                Return _referralSource
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReferralSource", _referralSource, value)
            End Set
        End Property
        Private _Code As String
        <Size(40)>
        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", _Code, value)
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
            If Oid <> -1 Then
                Return Me.ReferralSource
            Else
                Return String.Format("(New {0}) ", "ReferralSource")
            End If
        End Function
        <NonPersistent()>
        Public ReadOnly Property Description() As String
            Get
                Return Me.ReferralSource
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
    Public Class ReferralType
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
        Private _referralType As String
        <Size(40)>
        Public Property ReferralType() As String
            Get
                Return _referralType
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReferralType", _referralType, value)
            End Set
        End Property
        Private _Code As String
        <Size(40)>
        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", _Code, value)
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
        Private _order As Integer
        Public Property Order() As Integer
            Get
                Return _order
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Order", _order, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return ReferralType
            Else
                Return String.Format("(New {0}) ", "Referral Type")
            End If

        End Function
        <NonPersistent()>
        Public ReadOnly Property Description() As String
            Get
                Return ReferralType
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
    Public Class ReferralCategory
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
        Private _referralCategory As String
        <Size(40)>
        Public Property ReferralCategory() As String
            Get
                Return _referralCategory
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReferralCategory", _referralCategory, value)
            End Set
        End Property
        Private _Code As String
        <Size(40)>
        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", _Code, value)
            End Set
        End Property
        Private _insurers As String
        <Size(40)>
        Public Property Insurers() As String
            Get
                Return _insurers
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Insurers", _insurers, value)
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
        Private _order As Integer
        Public Property Order() As Integer
            Get
                Return _order
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Order", _order, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return ReferralCategory
            Else
                Return String.Format("(New {0}) ", "Referral Category")
            End If

        End Function
        <NonPersistent()> _
        Public ReadOnly Property Description() As String
            Get
                Return Me.ReferralCategory
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
    Public Class ReferralStage
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
        Private _referralStage As String
        <Size(40)>
        Public Property ReferralStage() As String
            Get
                Return _referralStage
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReferralStage", _referralStage, value)
            End Set
        End Property
        Private _Code As String
        <Size(40)>
        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", _Code, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return Me._referralStage
            Else
                Return String.Format("(New {0}) ", "Referral Stage")
            End If
        End Function
        <NonPersistent()> _
        Public ReadOnly Property Description() As String
            Get
                Return Me._referralStage
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
    Public Class ReferralStatus
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
        Private _referralStatus As String
        <Size(20)>
        Public Property ReferralStatus() As String
            Get
                Return _referralStatus
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReferralStatus", _referralStatus, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return Me._referralStatus
            Else
                Return String.Format("(New {0}) ", "Referral Status")
            End If
        End Function
        <NonPersistent()> _
        Public ReadOnly Property Description() As String
            Get
                Return Me._referralStatus
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
    Public Class ReferralReasonClosed
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
        Private _closedReason As String
        <Size(20)>
        Public Property ClosedReason() As String
            Get
                Return _closedReason
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ClosedReason", _closedReason, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return Me.ClosedReason
            Else
                Return String.Format("(New {0}) ", "Closed Reason")
            End If
        End Function
        <NonPersistent()> _
        Public ReadOnly Property Description() As String
            Get
                Return Me.ClosedReason
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
    Public Class TreatmentType
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
        Private _treatmentType As String
        <Size(20)>
        Public Property TreatmentType() As String
            Get
                Return _treatmentType
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TreatmentType", _treatmentType, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return Me.TreatmentType
            Else
                Return String.Format("(New {0}) ", "Treatment Type")
            End If
        End Function
        <NonPersistent()> _
        Public ReadOnly Property Description() As String
            Get
                Return Me.TreatmentType
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
End Namespace