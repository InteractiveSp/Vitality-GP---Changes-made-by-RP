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
    Public Class InsurerCostTable
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _description As String
        <Size(20)>
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", _description, value)
            End Set
        End Property
        Private _ConsultantRate As Double
        Public Property ConsultantRate() As Double
            Get
                Return _ConsultantRate
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("ConsultantRate", _ConsultantRate, value)
            End Set
        End Property
        Private _ratio1st As Double
        Public Property Ratio1st() As Double
            Get
                Return _ratio1st
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Ratio1", _ratio1st, value)
            End Set
        End Property
        Private _ratio2nd As Double
        Public Property Ratio2nd() As Double
            Get
                Return _ratio2nd
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Ratio2nd", _ratio2nd, value)
            End Set
        End Property
        Private _ratio3rd As Double
        Public Property Ratio3Rd() As Double
            Get
                Return _ratio3rd
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Ratio3Rd", _ratio3rd, value)
            End Set
        End Property
        Private _ratio4th As Double
        Public Property Ratio4th() As Double
            Get
                Return _ratio4th
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Ratio4th", _ratio4th, value)
            End Set
        End Property
        Private _ratio5th As Double
        Public Property Ratio5th() As Double
            Get
                Return _ratio5th
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Ratio5th", _ratio5th, value)
            End Set
        End Property
        <Association("InsurerCostTable-Costs")> _
        Public ReadOnly Property Costs() As XPCollection(Of InsurerCost)
            Get
                Return GetCollection(Of InsurerCost)("Costs")
            End Get
        End Property
        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return String.Format("{0}", Description)
            Else
                Return String.Format("New Insurer Costs Table")
            End If
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
    Public Class InsurerCost
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
        Dim _insurerCostTable As InsurerCostTable
        <Association("InsurerCostTable-Costs")> _
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
        Private _insurercost As Double
        Public Property InsurerCost() As Double
            Get
                Return _insurercost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("insurerCost", _insurercost, value)
            End Set
        End Property
        Private _consultantcost As Double
        Public Property ConsultantCost() As Double
            Get
                Return _consultantcost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("ConsultantCost", _consultantcost, value)
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
End Namespace