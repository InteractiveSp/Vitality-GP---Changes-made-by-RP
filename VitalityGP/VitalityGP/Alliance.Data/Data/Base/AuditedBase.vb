Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports Alliance.Data
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data
    <NonPersistent()> _
    Public Class AuditedBase
        Inherits XPObject

        Dim asNotMonitoredFields() As String = {"Oid", "Details", "SpecialInstructions", "Note", "Notes", "OptimisticLockField", "OptimisticLockFieldInDataLayer", "CreatedBy", "CreatedAt", "ModifiedBy", "ModifiedAt", "GCRecord", "EmployeeCount", "BeneficiaryCount", "BeneficiaryLeftCount", "DependantsCount", "TriageNotes", "Latitude", "Longitude"}

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private Sub UpdateAudit(ByVal act As Action)
            'Dim audit As New Audit(Session)
            'audit.Action = act
            'audit.Date = DateTime.Now
            'audit.AuditedRecordType = String.Format("{0}", ClassInfo.TableName)
            'audit.AuditedRecordID = Session.GetKeyValue(Me)
            'audit.User = CurrentUser.GetCurrentUser(Session)
            Dim EntityType As EntityType = Nothing

            EntityType = DirectCast([Enum].Parse(GetType(EntityType), ClassInfo.TableName), EntityType)

            For Each change As Change In changes
                If Array.IndexOf(asNotMonitoredFields, change.PropertyName) = -1 Then
                    If change.PrevValue = "<NULL>" And change.Value = "" Then
                        ' skip not neccessary to check
                    ElseIf change.Value.Length < 255 Then
                        Dim modInfo As New ModificationInfo(Session)
                        'modInfo.Audit = Audit
                        modInfo.Action = act
                        modInfo.ModificationDate = DateTime.Now
                        'modInfo.AuditedRecordType = String.Format("{0}", ClassInfo.TableName)
                        modInfo.EntityType = EntityType
                        modInfo.AuditedRecordID = CInt(Session.GetKeyValue(Me))
                        modInfo.User = ProjectCurrentUser.Oid
                        modInfo.FieldName = change.PropertyName
                        modInfo.OldValue = change.PrevValue
                        modInfo.NewValue = change.Value
                        modInfo.Save()
                    End If

                End If


            Next change
            ' audit.Save()
        End Sub

        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) Then
                '  UpdateAudit(Action.Insert)
            Else
                UpdateAudit(Action.Update)
            End If
        End Sub

        Protected Overrides Sub OnDeleting()
            MyBase.OnDeleting()
            Dim change As New Change()
            change.PropertyName = Me.ClassInfo.KeyProperty.Name
            change.PrevValue = Me.Session.GetKeyValue(Me).ToString()
            change.Value = "<DELETED>"
            changes.Add(change)
            UpdateAudit(Action.Delete)
        End Sub
        Private changes As New List(Of Change)()

        Protected Overrides Sub OnChanged(ByVal propertyName As String, ByVal oldValue As Object, ByVal newValue As Object)
            MyBase.OnChanged(propertyName, oldValue, newValue)
            Dim change As New Change()
            change.PropertyName = propertyName
            change.PrevValue = If(oldValue Is Nothing, "<NULL>", oldValue.ToString())
            change.Value = If(newValue Is Nothing, "<NULL>", newValue.ToString())
            changes.Add(change)
        End Sub

        Private Structure Change
            Public PropertyName As String
            Public PrevValue As String
            Public Value As String
        End Structure
    End Class
    Public Class ModificationInfo
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private fUser As Integer
        Public Property User() As Integer
            Get
                Return fUser
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("User", fUser, value)
            End Set
        End Property
        Private fDate As DateTime
        Public Property ModificationDate() As DateTime
            Get
                Return fDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Date", fDate, value)
            End Set
        End Property
        Private fAction As Action
        Public Property Action() As Action
            Get
                Return fAction
            End Get
            Set(ByVal value As Action)
                SetPropertyValue(Of Action)("Action", fAction, value)
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
        Private fAuditedRecordID As Integer
        Public Property AuditedRecordID() As Integer
            Get
                Return fAuditedRecordID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("AuditedRecordID", fAuditedRecordID, value)
            End Set
        End Property
        Private fPropertyName As String
        <Size(40)> _
        Public Property FieldName() As String
            Get
                Return fPropertyName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PropertyName", fPropertyName, value)
            End Set
        End Property

        Private fOldValue As String
        <Size(250)> _
        Public Property OldValue() As String
            Get
                Return fOldValue
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("OldValue", fOldValue, value)
            End Set
        End Property

        Private fNewValue As String
        <Size(250)> _
        Public Property NewValue() As String
            Get
                Return fNewValue
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NewValue", fNewValue, value)
            End Set
        End Property

    End Class

    Public Enum Action
        Insert
        Update
        Delete
    End Enum

    Public Class CriticalField
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private fFieldName As String
        <Size(20)>
        Public Property FieldName() As String
            Get
                Return fFieldName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FieldName", fFieldName, value)
            End Set
        End Property
    End Class

End Namespace

