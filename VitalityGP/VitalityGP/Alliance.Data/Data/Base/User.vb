Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports System.Drawing
Imports Alliance.Shared.Helpers
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data

    Public Enum eTeam
        Alliance = 0
        CT = 1
        CCAT = 2
        Triage = 3
        Mapping = 4
        PassBack = 5
        Purchasing = 6
    End Enum
    Public Class Team
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
        Private _team As String
        <Size(20)>
        Public Property Team() As String
            Get
                Return _team
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Team", _team, value)
            End Set
        End Property
        Private _isActive As Boolean
        Public Property IsActive() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsActive", _isActive, value)
            End Set
        End Property

        Public Overrides Function ToString() As String
            If Oid <> -1 Then
                Return Me.Team
            Else
                Return String.Format("(New {0}) ", "Team")
            End If

        End Function
        <NonPersistent()> _
        Public ReadOnly Property Description() As String
            Get
                Return Me.Team
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
    Public Class User
        Inherits XPObject
        Private ffirstName, fmiddleName, flastName, fposition, femail As String
        Private fsalutation As Salutation

        Private flogin As String
        Private fLoggedIn As Boolean
        Private fpasswordHash As String
        Private fshortName As String

        Private _loggedOnGus As Boolean
        Private _loggedOnMaisie As Boolean
        Private fAccessManagerReports As Boolean
        Private fTestEmail As Boolean
        Private _gusVersion As String
        Private _maisieVersion As String
        <ValueConverter(GetType(ColorValueConverter))> _
        Public Image As Image

        Private flastLogonGus As DateTime
        Private flastLogonMaisie As DateTime
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
        Public Sub New(ByVal session As Session, ByVal login As String, ByVal password As String)
            Me.New(session)
            Me.Login = login
            Me.Password = password
        End Sub
        Public Sub New(ByVal session As Session, ByVal login As String, ByVal password As String, ByVal firstName As String, ByVal lastName As String)
            Me.New(session, login, password)
            Me.FirstName = firstName
            Me.LastName = lastName
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
            If ShortName Is Nothing Then
                ShortName = Login
            End If
            ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            ModifiedAt = DateTime.Now

        End Sub
        Private _role As eUserRole
        Public Property Role() As eUserRole
            Get
                Return _role
            End Get
            Set(ByVal value As eUserRole)
                SetPropertyValue(Of eUserRole)("Role", _role, value)
            End Set
        End Property
        Private _team As Team
        Public Property Team() As Team
            Get
                Return _team
            End Get
            Set(ByVal value As Team)
                SetPropertyValue(Of Team)("Team", _team, value)
            End Set
        End Property
        Private _clientAccess As eModuleAccess
        Public Property ClientAccess() As eModuleAccess
            Get
                Return _clientAccess
            End Get
            Set(ByVal value As eModuleAccess)
                SetPropertyValue(Of eModuleAccess)("ClientAccess ", _clientAccess, value)
            End Set
        End Property
        Private _claimsAccess As eModuleAccess
        Public Property ClaimsAccess() As eModuleAccess
            Get
                Return _claimsAccess
            End Get
            Set(ByVal value As eModuleAccess)
                SetPropertyValue(Of eModuleAccess)("ClaimsAccess", _claimsAccess, value)
            End Set
        End Property
        Private _InvoiceAccess As eModuleAccess
        Public Property InvoiceAccess() As eModuleAccess
            Get
                Return _InvoiceAccess
            End Get
            Set(ByVal value As eModuleAccess)
                SetPropertyValue(Of eModuleAccess)("InvoiceAccess ", _InvoiceAccess, value)
            End Set
        End Property
        Private fIsResource As Boolean
        Public Property IsResource() As Boolean
            Get
                Return fIsResource
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsResource", fIsResource, value)
            End Set
        End Property
        Private _overRideEAP As Boolean
        Public Property OverRideEAP() As Boolean
            Get
                Return _overRideEAP
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("OverRideEAP", _overRideEAP, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)> _
        Public Property Login() As String
            Get
                Return flogin
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Login", flogin, value)
            End Set
        End Property
        Private _password As String
        <Size(128)> _
        Public Property Password() As String
            Get
                Return _password
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Password", _password, value)
            End Set
        End Property
        <NonPersistent>
        Public ReadOnly Property ClearPassword As String
            Get
                If Not String.IsNullOrEmpty(Password) Then
                    Return PasswordHelper.Decode(EntityType.User, Password)
                Else
                    Return String.Empty
                End If
            End Get
        End Property
        Private fenabled As Boolean
        <MemberDesignTimeVisibility(False)> _
        Public Property Enabled() As Boolean
            Get
                Return fenabled
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Enabled", fenabled, value)
            End Set
        End Property
        Private _userId As Integer
        <Indexed(Unique:=False)>
       Public Property User_UserId() As Integer
            Get
                Return _userId
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("[User_UserId]", _userId, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)> _
        Public Property Salutation() As Salutation
            Get
                Return fsalutation
            End Get
            Set(ByVal value As Salutation)
                SetPropertyValue(Of Salutation)("Salutation", fsalutation, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)> _
        Public Property FirstName() As String
            Get
                Return ffirstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FirstName", ffirstName, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)> _
        Public Property MiddleName() As String
            Get
                Return fmiddleName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MiddleName", fmiddleName, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)> _
        Public Property LastName() As String
            Get
                Return flastName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LastName", flastName, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)> _
        Public Property ShortName() As String
            Get
                Return fshortName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ShortName", fshortName, value)
            End Set
        End Property
        <Size(120)> <MemberDesignTimeVisibility(True)> _
        Public Property Email() As String
            Get
                Return femail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", femail, value)
            End Set
        End Property
        Private _testEmail As Boolean
        <MemberDesignTimeVisibility(False)> _
        Public Property TestEmail() As Boolean
            Get
                Return _testEmail
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("TestEmail", _testEmail, value)
            End Set
        End Property
        Private fphone As String
        <Size(20)> <MemberDesignTimeVisibility(True)> _
        Public Property Phone() As String
            Get
                Return fphone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Phone", fphone, value)
            End Set
        End Property
        Private fextension As String
        <Size(5)> <MemberDesignTimeVisibility(True)> _
        Public Property Extension() As String
            Get
                Return fextension
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Extension", fextension, value)
            End Set
        End Property

        <Size(60)> <MemberDesignTimeVisibility(True)> _
        Public Property Position() As String
            Get
                Return fposition
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Position", fposition, value)
            End Set
        End Property
        Private fphoto As Image
        <DevExpress.Xpo.ValueConverter(GetType(DevExpress.Xpo.Metadata.ImageValueConverter))> _
        Public Property Photo() As Image
            Get
                Return fphoto
            End Get
            Set(ByVal value As Image)
                SetPropertyValue(Of Image)("Photo", fphoto, value)
            End Set
        End Property
        Public ReadOnly Property PhotoExist() As Image
            Get
                If Object.Equals(fphoto, Nothing) Then
                    Return ReferenceImages.UnknownPerson
                End If
                Return fphoto
            End Get
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
        <MemberDesignTimeVisibility(True)> _
        Public Property LoggedOnGus() As Boolean
            Get
                Return _loggedOnGus
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("GusLoggedOn", _loggedOnGus, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)> _
        Public Property LoggedOnMaisie() As Boolean
            Get
                Return _loggedOnMaisie
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("LoggedOnMaisie", _loggedOnMaisie, value)
            End Set
        End Property

        <MemberDesignTimeVisibility(True)> _
        Public Property AccessManagerReports() As Boolean
            Get
                Return fAccessManagerReports
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("AccessManagerReports", fAccessManagerReports, value)
            End Set
        End Property
        Private fViewCosts As Boolean
        <MemberDesignTimeVisibility(True)> _
        Public Property ViewCosts() As Boolean
            Get
                Return fViewCosts
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ViewCosts", fViewCosts, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)> _
        Public Property LastLogonGus() As DateTime
            Get
                Return flastLogonGus
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LastLogonGus", flastLogonGus, value)
            End Set
        End Property
        <Size(60)> <MemberDesignTimeVisibility(False)> _
        Public Property GusVersion() As String
            Get
                Return _gusVersion
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GusVersion", _gusVersion, value)
            End Set
        End Property
        <Size(60)> <MemberDesignTimeVisibility(False)> _
        Public Property MaisieVersion() As String
            Get
                Return _maisieVersion
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MaisieVersion", _maisieVersion, value)
            End Set
        End Property
        Public Property LastLogonMaisie() As DateTime
            Get
                Return flastLogonMaisie
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LastLogonMaisie", flastLogonMaisie, value)
            End Set
        End Property
        Private _skinNameGus As String
        <Size(60)> <MemberDesignTimeVisibility(False)> _
        Public Property SkinNameGus() As String
            Get
                Return _skinNameGus
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GusSkinName", _skinNameGus, value)
            End Set
        End Property
        Private _skinNameMaisie As String
        <Size(60)> <MemberDesignTimeVisibility(False)> _
        Public Property SkinNameMaisie() As String
            Get
                Return _skinNameMaisie
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MaisieSkinName", _skinNameMaisie, value)
            End Set
        End Property

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
        <MemberDesignTimeVisibility(True)> _
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
        Public Function GetUserInfoHtml() As String
            Dim ret As String = String.Format("<size=+2><b>{0}</b><size=-2>", FullName)
            ret &= "<br>"
            If Not String.IsNullOrEmpty(Email) Then
                ret &= String.Format("<br>Email: <b>{0}</b>", Email)
            End If
            If Not String.IsNullOrEmpty(Phone) Then
                ret &= String.Format("<br>Phone: <b>{0} Ext {1}</b>", Phone, Extension)
            End If
            ret &= String.Format("<br><b>{0}</b>", IIf(LoggedOnGus = True, "Logged In", "Logged Out"))

            Return ret
        End Function
    End Class
    Public Class GlobalUser
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
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
        Private _ApplicationName As String
        '     <Size(255), Indexed("UserName", Unique:=True)> _
        Public Property ApplicationName() As String
            Get
                Return _ApplicationName
            End Get
            Set(ByVal value As String)
                SetPropertyValue("ApplicationName", _ApplicationName, value)
            End Set
        End Property
        Private _UserName As String
        '    <Size(255), Indexed("ApplicationName", Unique:=True)> _
        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                SetPropertyValue("UserName", _UserName, value)
            End Set
        End Property
        Private _shortName As String
        <Size(25)> _
        Public Property ShortName() As String
            Get
                Return _shortName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ShortName", _shortName, value)
            End Set
        End Property
        Private _Email As String
        <Size(128)> _
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Email", _Email, value)
            End Set
        End Property
        Private _userType As EntityType
        Public Property Entity As EntityType
            Get
                Return _userType
            End Get
            Set(ByVal value As EntityType)
                SetPropertyValue("UserType", _userType, value)
            End Set
        End Property
        Private _Comment As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Comment() As String
            Get
                Return _Comment
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Comment", _Comment, value)
            End Set
        End Property
        Private _Password As String
        <Size(128)> _
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Password", _Password, value)
            End Set
        End Property
        Private _PasswordQuestion As String
        <Size(255)> _
        Public Property PasswordQuestion() As String
            Get
                Return _PasswordQuestion
            End Get
            Set(ByVal value As String)
                SetPropertyValue("PasswordQuestion", _PasswordQuestion, value)
            End Set
        End Property
        Private _PasswordAnswer As String
        <Size(255)> _
        Public Property PasswordAnswer() As String
            Get
                Return _PasswordAnswer
            End Get
            Set(ByVal value As String)
                SetPropertyValue("PasswordAnswer", _PasswordAnswer, value)
            End Set
        End Property
        Private _IsApproved As Boolean
        Public Property IsApproved() As Boolean
            Get
                Return _IsApproved
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue("IsApproved", _IsApproved, value)
            End Set
        End Property
        Private _LastActivityDate As DateTime
        Public Property LastActivityDate() As DateTime
            Get
                Return _LastActivityDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("LastActivityDate", _LastActivityDate, value)
            End Set
        End Property
        Private _LastIP As String
        <Size(50)>
        Public Property LastIPAddress() As String
            Get
                Return _LastIP
            End Get
            Set(ByVal value As String)
                SetPropertyValue("LastIPAddress", _LastIP, value)
            End Set
        End Property
        Private _LastLoginDate As DateTime
        Public Property LastLoginDate() As DateTime
            Get
                Return _LastLoginDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("LastLoginDate", _LastLoginDate, value)
            End Set
        End Property
        Private _LastPasswordChangedDate As DateTime
        Public Property LastPasswordChangedDate() As DateTime
            Get
                Return _LastPasswordChangedDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("LastPasswordChangedDate", _LastPasswordChangedDate, value)
            End Set
        End Property
        Private _CreationDate As DateTime
        Public Property CreationDate() As DateTime
            Get
                Return _CreationDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("CreationDate", _CreationDate, value)
            End Set
        End Property
        Public ReadOnly Property IsOnline() As Boolean
            Get
                Dim span As New TimeSpan(0, System.Web.Security.Membership.UserIsOnlineTimeWindow, 0)
                Dim time As DateTime = DateTime.UtcNow.Subtract(span)
                Return (Me.LastActivityDate.ToUniversalTime() > time)
            End Get
        End Property
        Private _IsLockedOut As Boolean
        Public Property IsLockedOut() As Boolean
            Get
                Return _IsLockedOut
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue("IsLockedOut", _IsLockedOut, value)
            End Set
        End Property
        Private _LastLockedOutDate As DateTime
        Public Property LastLockedOutDate() As DateTime
            Get
                Return _LastLockedOutDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("LastLockedOutDate", _LastLockedOutDate, value)
            End Set
        End Property
        Private _FailedPasswordAttemptCount As Integer
        Public Property FailedPasswordAttemptCount() As Integer
            Get
                Return _FailedPasswordAttemptCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("FailedPasswordAttemptCount", _FailedPasswordAttemptCount, value)
            End Set
        End Property
        Private _FailedPasswordAttemptWindowStart As DateTime
        Public Property FailedPasswordAttemptWindowStart() As DateTime
            Get
                Return _FailedPasswordAttemptWindowStart
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("FailedPasswordAttemptWindowStart", _FailedPasswordAttemptWindowStart, value)
            End Set
        End Property
        Private _FailedPasswordAnswerAttemptCount As Integer
        Public Property FailedPasswordAnswerAttemptCount() As Integer
            Get
                Return _FailedPasswordAnswerAttemptCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("FailedPasswordAnswerAttemptCount", _FailedPasswordAnswerAttemptCount, value)
            End Set
        End Property
        Private _FailedPasswordAnswerAttemptWindowStart As DateTime
        Public Property FailedPasswordAnswerAttemptWindowStart() As DateTime
            Get
                Return _FailedPasswordAnswerAttemptWindowStart
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("FailedPasswordAnswerAttemptWindowStart", _FailedPasswordAnswerAttemptWindowStart, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", UserName)
        End Function
    End Class
End Namespace