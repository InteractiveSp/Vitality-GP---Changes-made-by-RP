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
Imports DevExpress.Data.Filtering

Namespace Alliance.Data
    Public Class LevelofCover
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
            Me.LevelofCover = name
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
        Private fLevelofCover As String
        <Size(20)>
        Public Property LevelofCover() As String
            Get
                Return fLevelofCover
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LevelofCover", fLevelofCover, value)
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
            Return String.Format("{0}", LevelofCover)
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


    End Class
    Public Class RelationShip
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
            Me.RelationShip = name
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
        Private fRelationShip As String
        <Size(20)>
        Public Property RelationShip() As String
            Get
                Return fRelationShip
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RelationShip", fRelationShip, value)
            End Set
        End Property
        Private fRelationShipGroup As String
        <Size(20)>
        Public Property RelationShipGroup() As String
            Get
                Return fRelationShipGroup
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RelationShipGroup", fRelationShipGroup, value)
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
        Private _validFor As String
        <Size(20)>
        Public Property ValidFor() As String
            Get
                Return _validFor
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ValidFor", _validFor, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", RelationShip)
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
    End Class
    Public Class Beneficiary
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
            Dim miPostCode As XPMemberInfo = Me.ClassInfo.GetMember("PostCode")
            If miPostCode.GetOldValue(Me) IsNot Nothing Or Session.IsNewObject(Me) Then
                If miPostCode.GetOldValue(Me) <> PostCode Then
                    Dim ll As New LatLong()
                    ll = GoogleAPI.GetLatLong(PostCode)
                    If ll IsNot Nothing Then
                        Latitude = ll.Latitude
                        Longitude = ll.Longitude
                    End If
                End If
            End If        
        End Sub
        Protected Overrides Sub OnDeleting()
            MyBase.OnDeleting()
            DeletedBy = ProjectCurrentUser.GetGlobalUser(Session)
            DeletedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnSaved()
            MyBase.OnSaved()
        End Sub
        Private _personId As Integer
        Public Property Pers_PersonId() As Integer
            Get
                Return _personId
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CRMID", _personId, value)
            End Set
        End Property
        Private fclient As Client
        <Association("Client-Beneficiaries")> _
        Public Property Client() As Client
            Get
                Return fclient
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", fclient, value)
            End Set
        End Property
        Private _clientType As eClientType
        Public Property ClientType() As eClientType
            Get
                Return _clientType
            End Get
            Set(ByVal value As eClientType)
                SetPropertyValue(Of eClientType)("ClientType", _clientType, value)
            End Set
        End Property
        Private fTitle As String
        <Size(10)> _
        Public Property Title() As String
            Get
                Return fTitle
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Title", fTitle, value)
            End Set
        End Property
        Private fFirstName As String
        <Size(50)> _
        Public Property FirstName() As String
            Get
                Return fFirstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FirstName", fFirstName, value)
            End Set
        End Property
        Private fSurName As String
        <Size(50)> _
        Public Property SurName() As String
            Get
                Return fSurName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SurName", fSurName, value)
            End Set
        End Property
        Private finitials As String
        <Size(10)> _
        Public Property Initials() As String
            Get
                Return finitials
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Initials", finitials, value)
            End Set
        End Property
        Public ReadOnly Property DPA() As String
            Get
                Dim ret As String = String.Empty
                If Object.Equals(FirstName, Nothing) Then
                    ret &= String.Empty
                Else
                    ret &= Left(FirstName, 1)
                End If
                If Not Object.Equals(SurName, Nothing) Then
                    If ret.Length = 0 Then
                        ret &= (String.Empty) & Left(SurName, 1)
                    Else
                        ret &= ("") & Left(SurName, 1)
                    End If
                End If
                Return ret & String.Format(" ({0}) ", Oid)
            End Get
        End Property
        Public ReadOnly Property FullName() As String
            Get
                Return GetFullName(FirstName, Initials, SurName, Nothing)
            End Get
        End Property
        Public ReadOnly Property TitledName() As String
            Get
                Return GetFullName(Title, FirstName, Initials, SurName)
            End Get
        End Property
        Public ReadOnly Property FullNameSorting() As String
            Get
                Return GetFullName(SurName, Title, FirstName, Initials)
            End Get
        End Property
        Public Shared Function GetFullName(ByVal first As String, ByVal second As String, ByVal third As String, ByVal fourth As String) As String
            Dim ret As String
            If Object.Equals(first, Nothing) Then
                ret = String.Empty
            Else
                ret = first.Trim()
            End If
            Dim secondTrim As String
            If Object.Equals(second, Nothing) Then
                secondTrim = String.Empty
            Else
                secondTrim = second.Trim()
            End If
            If secondTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & secondTrim
                Else
                    ret &= (" ") & secondTrim
                End If
            End If
            Dim thirdTrim As String
            If Object.Equals(third, Nothing) Then
                thirdTrim = String.Empty
            Else
                thirdTrim = third.Trim()
            End If
            If thirdTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & thirdTrim
                Else
                    ret &= (" ") & thirdTrim
                End If
            End If
            Dim fourthTrim As String
            If Object.Equals(fourth, Nothing) Then
                fourthTrim = String.Empty
            Else
                fourthTrim = fourth.Trim()
            End If
            If fourthTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & fourthTrim
                Else
                    ret &= (" ") & fourthTrim
                End If
            End If
            Return ret
        End Function
        Public ReadOnly Property FullAddressLine() As String
            Get
                Return GetFullAddressLine()
            End Get
        End Property
        Public ReadOnly Property FullAddressBlock() As String
            Get
                Return GetFullAddressBlock()
            End Get
        End Property
        Public Function GetFullAddressLine() As String
            Dim ret As String = String.Empty
            If Addr1 IsNot Nothing And Addr1 IsNot String.Empty Then
                ret = String.Format("{0}", Addr1)
            End If
            If Addr2 IsNot Nothing And Addr2 IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, Addr2)
            End If
            If Addr3 IsNot Nothing And Addr3 IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, Addr3)
            End If
            If City IsNot Nothing And City IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, City)
            End If
            If County IsNot Nothing And County IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, County)
            End If
            If PostCode IsNot Nothing And PostCode IsNot String.Empty Then
                ret = String.Format("{0}, {1}", ret, PostCode)
            End If
            Return ret
        End Function
        Public Function GetFullAddressBlock() As String
            Dim ret As String = String.Empty
            If Addr1 IsNot Nothing And Addr1 IsNot String.Empty Then
                ret = String.Format("{0}", Addr1)
            End If
            If Addr2 IsNot Nothing And Addr2 IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, Addr2)
            End If
            If Addr3 IsNot Nothing And Addr3 IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, Addr3)
            End If
            If City IsNot Nothing And City IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, City)
            End If
            If County IsNot Nothing And County IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCr, County)
            End If
            If PostCode IsNot Nothing And PostCode IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, vbCr, PostCode)
            End If
            Return ret
        End Function
        Public Function GetWarning() As String
            Dim ret As String = String.Empty
            If Client Is Nothing Then
                Return Nothing
            End If
            If Client.Schemes.Count > 1 Then
                ret = String.Format("Scheme {0}", Scheme)
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, "===================")
            End If
            If Deceased = "Y" Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, String.Format("<b><color={0}> Is Deceased</color></href></b>", ConstDataStrings.DeceasedColorHex))
            Else
                If LeaveDate <> Date.MinValue Then
                    If HasLeft = "Y" Then
                        ret = String.Format("{0}{1}{2}", ret, vbCrLf, String.Format("<b><color={0}>Has Left {1:dd/MM/yyyy}</color></b>", ConstDataStrings.LeftColorHex, LeaveDate))
                    Else
                        ret = String.Format("{0}{1}{2}", ret, vbCrLf, String.Format("<b><color={0}>Is Leaving {1:dd/MM/yyyy}</color></b>", ConstDataStrings.LeftColorHex, LeaveDate))
                    End If
                End If
            End If
            If Vip = "Y" Then
                If Deceased = "Y" Or HasLeft = "Y" Then
                    ret = String.Format("{0}{1}{2}", ret, vbCrLf, String.Format("<b><color={0}>they were a VIP </color></b>", ConstDataStrings.VIPColourHex))
                Else
                    ret = String.Format("{0}{1}{2}", ret, vbCrLf, String.Format("<b><color={0}>is a VIP </color></b>", ConstDataStrings.VIPColourHex))
                End If
            End If
            If ClientType = eClientType.RTH Then
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, String.Format("<b>Is a <color={0}>Return to Health</color> Patient</b>", ConstDataStrings.RTWColourHex))
            End If
            If Exclusions.Count > 0 Then
                ret = String.Format("{1}{0}", ret, vbCrLf)
                ret = String.Format("{1}{0}{1}{2}", ret, vbCrLf, "<b>Has Exclusions</b>")
                ret = String.Format("{0}{1}{2}", ret, vbCrLf, "<b>==============</b>")
                For Each oExclusion As BeneficiaryExclusion In Exclusions
                    If oExclusion.ReviewDate = Date.MinValue Then
                        ret = String.Format("{0}{1}{2}", ret, vbCrLf, oExclusion.Exclusion)
                    Else
                        ret = String.Format("{0}{1}{2}", ret, vbCrLf, String.Format("{0} {1:dd/MM/yyyy}", oExclusion.Exclusion, oExclusion.ReviewDate))
                    End If
                Next
            End If
            If ret <> String.Empty Then
                ret = String.Format("{0}{1}{2}", String.Format("<b>{0}</b>", FirstName), vbCrLf, ret)
            End If
            Return ret
        End Function
        Private fGender As Char
        Public Property Gender() As Char
            Get
                Return fGender
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("Gender", fGender, value)
            End Set
        End Property
        Private fVip As Char
        Public Property Vip() As Char
            Get
                Return fVip
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("Vip", fVip, value)
            End Set
        End Property
        Private fStudent As Char
        Public Property Student() As Char
            Get
                Return fStudent
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("Student", fStudent, value)
            End Set
        End Property
        Private fdeceased As Char
        Public Property Deceased() As Char
            Get
                Return fdeceased
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("Deceased", fdeceased, value)
            End Set
        End Property

        Private fNINumber As String
        <Size(20)> _
        Public Property NINumber() As String
            Get
                Return fNINumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NINumber", fNINumber, value)
            End Set
        End Property
        Private fPosition As String
        <Size(60)> _
        Public Property Position() As String
            Get
                Return fPosition
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Position", fPosition, value)
            End Set
        End Property
        Private _scheme As Scheme
        Public Property Scheme() As Scheme
            Get
                Return _scheme
            End Get
            Set(ByVal value As Scheme)
                SetPropertyValue(Of Scheme)("Scheme", _scheme, value)
            End Set
        End Property
        Private fBand As String
        <Size(40)> _
        Public Property Band() As String
            Get
                Return fBand
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Band", fBand, value)
            End Set
        End Property
        Private fDOB As Date
        Public Property DOB() As Date
            Get
                Return fDOB
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("DOB", fDOB, value)
            End Set
        End Property
        Public ReadOnly Property Age() As String
            Get
                Dim dAge As Integer = Today.Year - DOB.Year
                If (DOB > Today.AddYears(-dAge)) Then
                    dAge = dAge - 1
                End If
                If dAge < 10 Then
                    Dim dMonths As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Month, DOB, Date.Today) - dAge * 12
                    If DOB.Month > Today.Month Then
                        dMonths = dMonths - 1
                    End If
                    If dAge = 0 Then
                        Return String.Format("{0} Mths", dMonths)
                    Else
                        Return String.Format("{0} Yrs {1} Mths", dAge, dMonths)
                    End If
                Else
                    Return String.Format("{0} Yrs ", dAge)
                End If
            End Get
        End Property
        Private _joinDate As Date
        Public Property JoinDate() As Date
            Get
                Return _joinDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("JoinDate", _joinDate, value)
            End Set
        End Property
        Private _hasLeft As Char
        Public Property HasLeft() As Char
            Get
                If LeaveDate Is Nothing Then
                    _hasLeft = Convert.ToChar("N")
                Else
                    _hasLeft = Convert.ToChar("Y")
                End If
                Return _hasLeft
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("HasLeft", _hasLeft, value)
            End Set
        End Property
        Private _leaveDate As Date?
        Public Property LeaveDate() As Date?
            Get
                Return _leaveDate
            End Get
            Set(ByVal value As Date?)
                SetPropertyValue(Of Date?)("LeaveDate", _leaveDate, value)
            End Set
        End Property
        Private _reasonLeft As ReasonLeft
        Public Property ReasonLeft() As ReasonLeft
            Get
                Return _reasonLeft
            End Get
            Set(ByVal value As ReasonLeft)
                SetPropertyValue(Of ReasonLeft)("ReasonLeft", _reasonLeft, value)
            End Set
        End Property
        Private _creditCardLastTaken As Date?
        Public Property CreditCardLastTaken() As Date?
            Get
                Return _creditCardLastTaken
            End Get
            Set(ByVal value As Date?)
                SetPropertyValue(Of Date?)("CreditCardLastTaken", _creditCardLastTaken, value)
            End Set
        End Property
        Private _addr1 As String
        <Size(50)> _
        Public Property Addr1() As String
            Get
                Return _addr1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr1", _addr1, value)
            End Set
        End Property
        Private _addr2 As String
        <Size(50)> _
        Public Property Addr2() As String
            Get
                Return _addr2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr2", _addr2, value)
            End Set
        End Property
        Private _addr3 As String
        <Size(50)> _
        Public Property Addr3() As String
            Get
                Return _addr3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr3", _addr3, value)
            End Set
        End Property
        Private _city As String
        <Size(50)> _
        Public Property City() As String
            Get
                Return _city
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("City", _city, value)
            End Set
        End Property
        Private _county As String
        <Size(50)> _
        Public Property County() As String
            Get
                Return _county
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("County", _county, value)
            End Set
        End Property
        Private _postcode As String
        <Size(10)> _
        Public Property PostCode() As String
            Get
                Return _postcode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", _postcode, value)
            End Set
        End Property
        Private _latitude As Double
        Public Property Latitude As Double
            Get
                Return _latitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Latitude", _latitude, value)
            End Set
        End Property
        Private _longitude As Double
        Public Property Longitude As Double
            Get
                Return _longitude
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Longitude", _longitude, value)
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
                    Return PasswordHelper.Decode(EntityType.Beneficiary, Password)
                Else
                    Return String.Empty
                End If
            End Get
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
        Private fDivision As Division
        <Association("Division-Beneficiaries")> _
        Public Property Division() As Division
            Get
                Return fDivision
            End Get
            Set(ByVal value As Division)
                SetPropertyValue(Of Division)("Divison", fDivision, value)
            End Set
        End Property
        Private fReportingDivision As ReportingDivision
        <Association("ReportingDivision-Beneficiaries")> _
        Public Property ReportingDivision() As ReportingDivision
            Get
                Return fReportingDivision
            End Get
            Set(ByVal value As ReportingDivision)
                SetPropertyValue(Of ReportingDivision)("ReportingDivision", fReportingDivision, value)
            End Set
        End Property
        Private fBusinessUnit As BusinessUnit
        <Association("BusinessUnit-Beneficiaries")> _
        Public Property BusinessUnit() As BusinessUnit
            Get
                Return fBusinessUnit
            End Get
            Set(ByVal value As BusinessUnit)
                SetPropertyValue(Of BusinessUnit)("BusinessUnit", fBusinessUnit, value)
            End Set
        End Property
        Private fLevelofCover As LevelofCover
        Public Property LevelofCover() As LevelofCover
            Get
                Return fLevelofCover
            End Get
            Set(ByVal value As LevelofCover)
                SetPropertyValue(Of LevelofCover)("LevelofCover", fLevelofCover, value)
            End Set
        End Property
        Private fRelationShip As RelationShip
        Public Property RelationShip() As RelationShip
            Get
                Return fRelationShip
            End Get
            Set(ByVal value As RelationShip)
                SetPropertyValue(Of RelationShip)("RelationShip", fRelationShip, value)
            End Set
        End Property
        Private _dependant As Boolean
        Public Property Dependant() As Boolean
            Get
                Return _dependant
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Dependant", _dependant, value)
            End Set
        End Property

        Private _email As String
        <Size(120)> _
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", _email, value)
            End Set
        End Property
        Private _workPhone As String
        <Size(20)> _
        Public Property WorkPhone() As String
            Get
                Return _workPhone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WorkPhone", _workPhone, value)
            End Set
        End Property
        Private _homePhone As String
        <Size(20)> _
        Public Property HomePhone() As String
            Get
                Return _homePhone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HomePhone", _homePhone, value)
            End Set
        End Property
        Private fMobilePhone As String
        <Size(20)> _
        Public Property MobilePhone() As String
            Get
                Return fMobilePhone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MobilePhone ", fMobilePhone, value)
            End Set
        End Property
        Private fEmployeeNo As String
        <Size(20)> _
        Public Property EmployeeNo() As String
            Get
                Return fEmployeeNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EmployeeNo", fEmployeeNo, value)
            End Set
        End Property
        Private fContribution As Double
        Public Property EmployeeContribution() As Double
            Get
                Return fContribution
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("EmployeeContribution", fContribution, value)
            End Set
        End Property
        Private fnote As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Note() As String
            Get
                Return fnote
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Note", fnote, value)
            End Set
        End Property
        <Association("Beneficiary-PolicyExcess")> _
          Public ReadOnly Property PolicyExcess() As XPCollection(Of PolicyExcess)
            Get
                Return GetCollection(Of PolicyExcess)("PolicyExcess")
            End Get
        End Property
        <Association("Beneficiary-Exclusions")> _
        Public ReadOnly Property Exclusions() As XPCollection(Of BeneficiaryExclusion)
            Get
                Return GetCollection(Of BeneficiaryExclusion)("Exclusions")
            End Get
        End Property
        <Association("Beneficiary-LibraryDoc")> _
        Public ReadOnly Property LibraryDocuments() As XPCollection(Of LibraryDoc)
            Get
                Return GetCollection(Of LibraryDoc)("LibraryDocuments")
            End Get
        End Property
        <Association("Beneficiary-Communications")> _
        Public ReadOnly Property Communications() As XPCollection(Of Communication)
            Get
                Return GetCollection(Of Communication)("Communications")
            End Get
        End Property
        <Association("Beneficiary-Invoices")> _
        Public ReadOnly Property Invoices() As XPCollection(Of Invoice)
            Get
                Return GetCollection(Of Invoice)("Invoices")
            End Get
        End Property
        <Association("Beneficiary-TrackingNotes")> _
        Public ReadOnly Property TrackingNotes() As XPCollection(Of TrackingNote)
            Get
                Return GetCollection(Of TrackingNote)("TrackingNotes")
            End Get
        End Property
        <Association("Beneficiary-Documents")> _
        Public ReadOnly Property Documents() As XPCollection(Of LinkedDocument)
            Get
                Return GetCollection(Of LinkedDocument)("Documents")
            End Get
        End Property
        Private _FamilyGroup As Integer
        Public Property FamilyGroup() As Integer
            Get
                Return _FamilyGroup
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("FamilyGroup", _FamilyGroup, value)
            End Set
        End Property
        Private fEmployee As Beneficiary
        <Association("EmployeeDependants")> _
        Public Property Employee() As Beneficiary
            Get
                Return fEmployee
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue("Beneficiary", fEmployee, value)
            End Set
        End Property
        <Association("EmployeeDependants")> _
        Public ReadOnly Property Dependants() As XPCollection(Of Beneficiary)
            Get
                Return GetCollection(Of Beneficiary)("Dependants")
            End Get
        End Property
        Public Function GetBeneficiaryInfoHtml() As String
            Dim ret As String = String.Format("<b><href=Beneficary={0}>{1}</href></b>", Oid, FullName)
            If Vip = "Y" Then
                ret &= String.Format("<b><color='red'>VIP</color></b>")
            End If
            If (Not Object.Equals(DOB, Nothing)) AndAlso (Not Object.Equals(DOB, DateTime.MinValue)) Then
                ret &= String.Format(Constants.vbCrLf & "DOB: <b>{0:d}</b>", DOB)
            End If
            'If (FamilyGroup <> Oid) Then
            '    ret &= String.Format(Constants.vbCrLf & "Main Beneficiary: <i><href=Beneficary={0}>{1}</href></i>", FamilyGroup.Oid, FamilyGroup.FullName)
            'End If
            ret &= String.Format(Constants.vbCrLf & "Employee No: <b>{0}</b>", EmployeeNo)
            If (Not String.IsNullOrEmpty(Email)) Then
                ret &= String.Format(Constants.vbCrLf & "Email: <b>{0}</b>", Email)
            End If
            If (Not String.IsNullOrEmpty(HomePhone)) Then
                ret &= String.Format(Constants.vbCrLf & "Phone: <b>{0}</b>", HomePhone)
            End If
            'If (Not String.IsNullOrEmpty(Address)) Then
            '    ret &= String.Format(Constants.vbCrLf & "Address: <b>{0}</b>", Address)
            'End If
            If (Not String.IsNullOrEmpty(Note)) Then
                ret &= String.Format(Constants.vbCrLf & "Comments: <i>{0}</i>", Note)
            End If

            Return ret
        End Function
        Public Sub UpdateGeoCooordinates()
            Dim ll As New LatLong()
            If String.IsNullOrWhiteSpace(PostCode) = False Then
                ll = GoogleAPI.GetLatLong(PostCode)
                If ll IsNot Nothing Then
                    Latitude = ll.Latitude
                    Longitude = ll.Longitude
                End If
            End If
        End Sub
        Public Function ExcessGetTotal(_startdate As Date, _enddate As Date) As Double
            Dim _str As String = "SELECT sum(InvoiceLine.eXcess) FROM InvoiceLine INNER JOIN Invoice ON InvoiceLine.Invoice = Invoice.OID where Invoiceline.InvoiceStatus in (5,10) and Invoice.Beneficiary = {0} and invoiceline.TreatmentDate between {1:dd/MM/yyyy} and {2:dd/MM/yyyy} "
            Return CDbl(Session.ExecuteScalar(String.Format(_str, Oid, _startdate, _enddate)))
        End Function

        <Association("Beneficiary-Claims")> _
        Public ReadOnly Property Claims() As XPCollection(Of Claim)
            Get
                Return GetCollection(Of Claim)("Claims")
            End Get
        End Property
        <Association("Beneficiary-Authorisations")> _
        Public ReadOnly Property Authorisations() As XPCollection(Of Authorisation)
            Get
                Return GetCollection(Of Authorisation)("Authorisations")
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("{0}", FullName)
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
    Public Class BeneficiaryExclusion
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
        Private _Beneficiary As Beneficiary
        <Association("Beneficiary-Exclusions")> _
        Public Property Beneficiary() As Beneficiary
            Get
                Return _Beneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", _Beneficiary, value)
            End Set
        End Property
        Private _exclusion As String
        <Size(255)> _
        Public Property Exclusion() As String
            Get
                Return _exclusion
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Exclusion", _exclusion, value)
            End Set
        End Property
        Private _reviewDate As Date
        Public Property ReviewDate() As Date
            Get
                Return _reviewDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("ReviewDate", _reviewDate, value)
            End Set
        End Property
        Private _active As Char
        Public Property Active() As Char
            Get
                Return _active
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("Active", _active, value)
            End Set
        End Property
        Private _createdBy As GlobalUser
        Public Property CreatedBy() As GlobalUser
            Get
                Return _createdBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("CreatedBy", _createdBy, value)
            End Set
        End Property
        Private _createdAt As DateTime
        Public Property CreatedAt() As DateTime
            Get
                Return _createdAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", _createdAt, value)
            End Set
        End Property
        Private _modifiedBy As GlobalUser
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedBy() As GlobalUser
            Get
                Return _modifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", _modifiedBy, value)
            End Set
        End Property
        Private _modifiedAt As DateTime
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
        Public Property ModifiedAt() As DateTime
            Get
                Return _modifiedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ModifiedAt", _modifiedAt, value)
            End Set
        End Property
    End Class
End Namespace