Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports System.Drawing
Imports DevExpress.Data.Filtering
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data
    Public Class Insurer
        Inherits AuditedBase
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
            Me.CompanyName = name
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
        Private _CompanyName As String
        <Size(30)>
        Public Property CompanyName() As String
            Get
                Return _CompanyName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CompanyName", _CompanyName, value)
            End Set
        End Property
        Private _Prefix As String
        <Size(4)>
        Public Property Prefix() As String
            Get
                Return _Prefix
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Prefix", _Prefix, value)
            End Set
        End Property
        Private _AcCode As String
        <Size(10)>
        Public Property AcCode() As String
            Get
                Return _AcCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AcCode", _AcCode, value)
            End Set
        End Property
        Private _addr1 As String
        <Size(50)>
        Public Property Addr1() As String
            Get
                Return _addr1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr1", _addr1, value)
            End Set
        End Property
        <Size(50)>
        Private _addr2 As String
        Public Property Addr2() As String
            Get
                Return _addr2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr2", _addr2, value)
            End Set
        End Property
        <Size(50)>
        Private _addr3 As String
        Public Property Addr3() As String
            Get
                Return _addr3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr3", _addr3, value)
            End Set
        End Property
        <Size(50)>
        Private _addr4 As String
        Public Property Addr4() As String
            Get
                Return _addr4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr4", _addr4, value)
            End Set
        End Property
        <Size(10)>
        Private _postcode As String
        Public Property PostCode() As String
            Get
                Return _postcode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", _postcode, value)
            End Set
        End Property
        Private _phoneNumber As String
        <Size(15)>
                Public Property PhoneNumber() As String
            Get
                Return _phoneNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PhoneNumber", _phoneNumber, value)
            End Set
        End Property
        <Size(100)>
        Private _email As String
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", _email, value)
            End Set
        End Property
        Private _active As Boolean
        <Size(15)>
        Public Property Active() As Boolean
            Get
                Return _active
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Active", _active, value)
            End Set
        End Property
        <Association("Insurer-LibraryDoc")>
        Public ReadOnly Property LibraryDocuments() As XPCollection(Of LibraryDoc)
            Get
                Return GetCollection(Of LibraryDoc)("LibraryDocuments")
            End Get
        End Property
        Private _insurerCostTable As InsurerCostTable
        Public Property InsurerCostTable() As InsurerCostTable
            Get
                Return _insurerCostTable
            End Get
            Set(ByVal value As InsurerCostTable)
                SetPropertyValue(Of InsurerCostTable)("InsurerCostTable", _insurerCostTable, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited)>
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Comments", _notes, value)
            End Set
        End Property
        <Association("Insurer-Locations")>
        Public ReadOnly Property Locations() As XPCollection(Of InsurerLocation)
            Get
                Return GetCollection(Of InsurerLocation)("Locations")
            End Get
        End Property
        <Association("Insurer-TeamLeaders")>
        Public ReadOnly Property TeamLeaders() As XPCollection(Of InsurerTeamLeader)
            Get
                Return GetCollection(Of InsurerTeamLeader)("TeamLeaders")
            End Get
        End Property
        <Association("Insurer-Agents")>
        Public ReadOnly Property Agents() As XPCollection(Of InsurerAgent)
            Get
                Return GetCollection(Of InsurerAgent)("Agents")
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
        Public Overrides Function ToString() As String
            Return String.Format("{0}", CompanyName)
        End Function
    End Class
    Public Class InsurerLocation
        Inherits XPObject

        Private fcreatedBy As User
        Private fcreatedAt As DateTime
        Private fmodifiedBy As User
        Private fmodifiedAt As DateTime

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal selfId As Integer)
            Me.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            CreatedAt = DateTime.Now
            ModifiedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetCurrentUser(Session)
                ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            End If
            ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _location As String
        <Size(20)>
        Public Property Location() As String
            Get
                Return _location
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Location", _location, value)
            End Set
        End Property
        Private _insurer As Insurer
        <Association("Insurer-Locations")>
        Public Property Insurer() As Insurer
            Get
                Return _insurer
            End Get
            Set(ByVal value As Insurer)
                SetPropertyValue(Of Insurer)("Insurer", _insurer, value)
            End Set
        End Property
        <Association("Location-TeamLeaders")>
        Public ReadOnly Property TeamLeaders() As XPCollection(Of InsurerTeamLeader)
            Get
                Return GetCollection(Of InsurerTeamLeader)("TeamLeaders")
            End Get
        End Property
        <Association("Location-Agents")>
        Public ReadOnly Property Agents() As XPCollection(Of InsurerAgent)
            Get
                Return GetCollection(Of InsurerAgent)("Agents")
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", _location)
        End Function
        <MemberDesignTimeVisibility(False)> _
        Public Property CreatedBy() As User
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("CreatedBy", fcreatedBy, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)> _
        Public Property CreatedAt() As DateTime
            Get
                Return fcreatedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
            End Set
        End Property
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedBy() As User
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
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
    Public Class InsurerTeamLeader
        Inherits XPObject
        Private ffirstName, flastName, fposition, femail As String
        Private fsalutation As Salutation
        Private fcreatedBy As User
        Private fcreatedAt As DateTime
        Private fmodifiedBy As User
        Private fmodifiedAt As DateTime

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal selfId As Integer)
            Me.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            CreatedAt = DateTime.Now
            ModifiedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetCurrentUser(Session)
                ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            End If
            ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _active As Boolean
        Public Property Active() As Boolean
            Get
                Return _active
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Active", _active, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)>
        Public Property Salutation() As Salutation
            Get
                Return fsalutation
            End Get
            Set(ByVal value As Salutation)
                SetPropertyValue(Of Salutation)("Title", fsalutation, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        Public Property FirstName() As String
            Get
                Return ffirstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FirstName", ffirstName, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        Public Property LastName() As String
            Get
                Return flastName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LastName", flastName, value)
            End Set
        End Property
        <Size(120)> <MemberDesignTimeVisibility(True)>
        Public Property Email() As String
            Get
                Return femail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", femail, value)
            End Set
        End Property
        Private fphone As String
        <Size(20)> <MemberDesignTimeVisibility(True)>
        Public Property Phone() As String
            Get
                Return fphone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Phone", fphone, value)
            End Set
        End Property
        Private fextension As String
        <Size(5)> <MemberDesignTimeVisibility(True)>
        Public Property Extension() As String
            Get
                Return fextension
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Extension", fextension, value)
            End Set
        End Property
        <Size(60)> <MemberDesignTimeVisibility(True)>
        Public Property Position() As String
            Get
                Return fposition
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Position", fposition, value)
            End Set
        End Property
        Private _insurer As Insurer
        <Association("Insurer-TeamLeaders")>
        Public Property Insurer() As Insurer
            Get
                Return _insurer
            End Get
            Set(ByVal value As Insurer)
                SetPropertyValue(Of Insurer)("Insurer", _insurer, value)
            End Set
        End Property
        Private _location As InsurerLocation
        <Association("Location-TeamLeaders")>
        Public Property Location() As InsurerLocation
            Get
                Return _location
            End Get
            Set(ByVal value As InsurerLocation)
                SetPropertyValue(Of InsurerLocation)("Location", _location, value)
            End Set
        End Property
        <Association("TeamLeader-Agents")>
        Public ReadOnly Property Agents() As XPCollection(Of InsurerAgent)
            Get
                Return GetCollection(Of InsurerAgent)("Agents")
            End Get
        End Property
        <MemberDesignTimeVisibility(False)>
        Public Property CreatedBy() As User
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("CreatedBy", fcreatedBy, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)>
        Public Property CreatedAt() As DateTime
            Get
                Return fcreatedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
            End Set
        End Property
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedBy() As User
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
                Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        Public Overridable ReadOnly Property FullName() As String
            Get
                Dim ret As String
                If Object.Equals(FirstName, Nothing) Then
                    ret = String.Empty
                Else
                    ret = FirstName.Trim
                End If
                Dim lastNameTrim As String
                If Object.Equals(LastName, Nothing) Then
                    lastNameTrim = String.Empty
                Else
                    lastNameTrim = LastName.Trim
                End If
                If lastNameTrim.Length <> 0 Then
                    If ret.Length = 0 Then
                        ret &= (String.Empty) & lastNameTrim
                    Else
                        ret &= (" ") & lastNameTrim
                    End If
                End If
                Return ret
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0} {1}", FirstName, LastName)
        End Function
    End Class
    Public Class InsurerAgent
        Inherits XPObject
        Private ffirstName, flastName, femail As String
        Private fsalutation As Salutation
        Private fcreatedBy As User
        Private fcreatedAt As DateTime
        Private fmodifiedBy As User
        Private fmodifiedAt As DateTime

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal selfId As Integer)
            Me.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            CreatedAt = DateTime.Now
            ModifiedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetCurrentUser(Session)
                ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            End If
            ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _active As Boolean
        Public Property Active() As Boolean
            Get
                Return _active
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Active", _active, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)>
        Public Property Salutation() As Salutation
            Get
                Return fsalutation
            End Get
            Set(ByVal value As Salutation)
                SetPropertyValue(Of Salutation)("Title", fsalutation, value)
            End Set
        End Property
        Private _title As String
        <Size(20)> <MemberDesignTimeVisibility(True)>
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Title", _title, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        Public Property FirstName() As String
            Get
                Return ffirstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FirstName", ffirstName, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        Public Property LastName() As String
            Get
                Return flastName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LastName", flastName, value)
            End Set
        End Property
        <Size(120)> <MemberDesignTimeVisibility(True)>
        Public Property Email() As String
            Get
                Return femail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", femail, value)
            End Set
        End Property
        Private fphone As String
        <Size(20)> <MemberDesignTimeVisibility(True)>
        Public Property Phone() As String
            Get
                Return fphone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Phone", fphone, value)
            End Set
        End Property
        Private fextension As String
        <Size(5)> <MemberDesignTimeVisibility(True)>
        Public Property Extension() As String
            Get
                Return fextension
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Extension", fextension, value)
            End Set
        End Property
        Private _shortname As String
        <Size(25)> <MemberDesignTimeVisibility(True)>
        Public Property Shortname() As String
            Get
                Return _shortname
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Shortname", _shortname, value)
            End Set
        End Property
        Private _position As String
        <Size(60)> <MemberDesignTimeVisibility(True)>
        Public Property Position() As String
            Get
                Return _position
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Position", _position, value)
            End Set
        End Property
        Private _comment As String
        <Size(60)> <MemberDesignTimeVisibility(True)>
        Public Property Comment() As String
            Get
                Return _comment
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Comment", _comment, value)
            End Set
        End Property
        Private _insurer As Insurer
        <Association("Insurer-Agents")>
        Public Property Insurer() As Insurer
            Get
                Return _insurer
            End Get
            Set(ByVal value As Insurer)
                SetPropertyValue(Of Insurer)("Insurer", _insurer, value)
            End Set
        End Property
        Private _teamLeader As InsurerTeamLeader
        <Association("TeamLeader-Agents")>
        Public Property TeamLeader() As InsurerTeamLeader
            Get
                Return _teamLeader
            End Get
            Set(ByVal value As InsurerTeamLeader)
                SetPropertyValue(Of InsurerTeamLeader)("TeamLeader", _teamLeader, value)
            End Set
        End Property
        Private _location As InsurerLocation
        <Association("Location-Agents")>
        Public Property Location() As InsurerLocation
            Get
                Return _location
            End Get
            Set(ByVal value As InsurerLocation)
                SetPropertyValue(Of InsurerLocation)("Location", _location, value)
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
        <MemberDesignTimeVisibility(False)>
        Public Property CreatedBy() As User
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("CreatedBy", fcreatedBy, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)>
        Public Property CreatedAt() As DateTime
            Get
                Return fcreatedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
            End Set
        End Property
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedBy() As User
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        Public Overridable ReadOnly Property FullName() As String
            Get
                Dim ret As String
                If Object.Equals(FirstName, Nothing) Then
                    ret = String.Empty
                Else
                    ret = FirstName.Trim
                End If
                Dim lastNameTrim As String
                If Object.Equals(LastName, Nothing) Then
                    lastNameTrim = String.Empty
                Else
                    lastNameTrim = LastName.Trim
                End If
                If lastNameTrim.Length <> 0 Then
                    If ret.Length = 0 Then
                        ret &= (String.Empty) & lastNameTrim
                    Else
                        ret &= (" ") & lastNameTrim
                    End If
                End If
                Return ret
            End Get
        End Property
    End Class


    Public Class VitalityGP
        Inherits XPObject
        Private ffirstName, flastName, femail As String
        Private fsalutation As Salutation
        Private fcreatedBy As User
        Private fcreatedAt As DateTime
        Private fmodifiedBy As User
        Private fmodifiedAt As DateTime

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal selfId As Integer)
            Me.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            CreatedAt = DateTime.Now
            ModifiedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetCurrentUser(Session)
                ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            End If
            ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _active As Boolean
        Public Property Active() As Boolean
            Get
                Return _active
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Active", _active, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)>
        Public Property Salutation() As Salutation
            Get
                Return fsalutation
            End Get
            Set(ByVal value As Salutation)
                SetPropertyValue(Of Salutation)("Title", fsalutation, value)
            End Set
        End Property
        Private _title As String
        <Size(20)> <MemberDesignTimeVisibility(True)>
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Title", _title, value)
            End Set
        End Property
        <Size(30)>
        Public Property FirstName() As String
            Get
                Return ffirstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FirstName", ffirstName, value)
            End Set
        End Property
        <Size(30)>
        Public Property LastName() As String
            Get
                Return flastName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LastName", flastName, value)
            End Set
        End Property
        <Size(120)> <MemberDesignTimeVisibility(True)>
        Public Property Email() As String
            Get
                Return femail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", femail, value)
            End Set
        End Property
        Private fphone As String
        <Size(20)> <MemberDesignTimeVisibility(True)>
        Public Property Phone() As String
            Get
                Return fphone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Phone", fphone, value)
            End Set
        End Property


        Private _shortname As String
        <Size(25)> <MemberDesignTimeVisibility(True)>
        Public Property Shortname() As String
            Get
                Return _shortname
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Shortname", _shortname, value)
            End Set
        End Property


        Private _UserID As Guid
        <Indexed(Unique:=False)>
        Public Property UserID() As Guid
            Get
                Return _UserID
            End Get
            Set(ByVal value As Guid)
                SetPropertyValue(Of Guid)("UserID", _UserID, value)
            End Set
        End Property


        Private _CRM As Integer
        <Indexed(Unique:=False)>
        Public Property CRM() As Integer
            Get
                Return _CRM
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CRM", _CRM, value)
            End Set
        End Property

        <MemberDesignTimeVisibility(False)>
        Public Property CreatedBy() As User
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("CreatedBy", fcreatedBy, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)>
        Public Property CreatedAt() As DateTime
            Get
                Return fcreatedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
            End Set
        End Property
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedBy() As User
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("ModifiedBy", fmodifiedBy, value)
            End Set
        End Property
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedAt() As DateTime
            Get
                Return fmodifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", fmodifiedAt, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        Public Overridable ReadOnly Property FullName() As String
            Get
                Dim ret As String
                If Object.Equals(FirstName, Nothing) Then
                    ret = String.Empty
                Else
                    ret = FirstName.Trim
                End If
                Dim lastNameTrim As String
                If Object.Equals(LastName, Nothing) Then
                    lastNameTrim = String.Empty
                Else
                    lastNameTrim = LastName.Trim
                End If
                If lastNameTrim.Length <> 0 Then
                    If ret.Length = 0 Then
                        ret &= (String.Empty) & lastNameTrim
                    Else
                        ret &= (" ") & lastNameTrim
                    End If
                End If
                Return ret
            End Get
        End Property
    End Class

End Namespace