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
    Public Class Patient
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
            '   If miPostCode.GetOldValue(Me) <> Nothing Or Session.IsNewObject(Me) Then
            If miPostCode.GetOldValue(Me) <> PostCode Then
                Dim ll As New LatLong()
                ll = GoogleAPI.GetLatLong(PostCode)
                If ll IsNot Nothing Then
                    Latitude = ll.Latitude
                    Longitude = ll.Longitude
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
        <Indexed(Unique:=False)>
       Public Property Pers_PersonId() As Integer
            Get
                Return _personId
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CRMID", _personId, value)
            End Set
        End Property
        Private _beneficiary As Beneficiary
        Public Property Beneficiary() As Beneficiary
            Get
                Return _beneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", _beneficiary, value)
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
        Private _title As String
        <Size(10)>
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Title", _title, value)
            End Set
        End Property
        'Private fTitle As String
        '<Size(10)> _
        'Public Property Title() As String
        '    Get
        '        Return fTitle
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("Title", fTitle, value)
        '    End Set
        'End Property
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
        <Size(50)>
        Public Property SurName() As String
            Get
                Return fSurName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SurName", fSurName, value)
            End Set
        End Property
        <PersistentAlias("SUBSTRING(isnull(FirstName,' '),0,1) + SUBSTRING(isnull(SurName,' '),0,1)")>
        Public ReadOnly Property DPA() As String
            Get
                Return CType(EvaluateAlias("DPA"), String)
            End Get
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
        Private _guardianTitle As String
        <Size(10)>
        Public Property GuardianTitle() As String
            Get
                Return _guardianTitle
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GuardianTitle", _guardianTitle, value)
            End Set
        End Property
        Private _guardianFirstName As String
        <Size(50)>
        Public Property GuardianFirstName() As String
            Get
                Return _guardianFirstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GuardianFirstName", _guardianFirstName, value)
            End Set
        End Property
        Private _guardianSurName As String
        <Size(50)>
        Public Property GuardianSurName() As String
            Get
                Return _guardianSurName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GuardianSurName", _guardianSurName, value)
            End Set
        End Property
        Private _guardianinitials As String
        <Size(10)>
        Public Property GuardianInitials() As String
            Get
                Return _guardianinitials
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GuardianInitials", _guardianinitials, value)
            End Set
        End Property
        <PersistentAlias("isnull(FirstName,'') + ' ' + isnull(SurName,'')")>
        Public ReadOnly Property SearchName() As String
            Get
                Return CType(EvaluateAlias("SearchName"), String)
            End Get
        End Property

        Public ReadOnly Property FullName() As String
            Get
                Return GetFullName(FirstName, SurName, Nothing)
            End Get
        End Property
        Public ReadOnly Property TitledName() As String
            Get
                Return GetFullName(Title, FirstName, SurName)
            End Get
        End Property
        Public ReadOnly Property FullNameLastSorting() As String
            Get
                Return GetFullName(SurName, FirstName, Nothing)
            End Get
        End Property
        Public Shared Function GetFullName(ByVal first As String, ByVal second As String, ByVal third As String) As String
            Dim ret As String
            If Object.Equals(first, Nothing) Then
                ret = String.Empty
            Else
                ret = first
            End If
            Dim secondTrim As String
            If Object.Equals(second, Nothing) Then
                secondTrim = String.Empty
            Else
                secondTrim = second
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
                thirdTrim = third
            End If
            If thirdTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & thirdTrim
                Else
                    ret &= (" ") & thirdTrim
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
        Public ReadOnly Property ContactNumbers() As String
            Get
                Return GetContactNumbers()
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
        Public Function GetContactNumbers() As String
            Dim ret As String = String.Empty
            If MobilePhone IsNot Nothing And MobilePhone IsNot String.Empty Then
                ret = String.Format("{0}", MobilePhone)
            End If
            If HomePhone IsNot Nothing And HomePhone IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, IIf(ret IsNot String.Empty, ", ", ""), HomePhone)
            End If
            If WorkPhone IsNot Nothing And WorkPhone IsNot String.Empty Then
                ret = String.Format("{0}{1}{2}", ret, IIf(ret IsNot String.Empty, ", ", ""), WorkPhone)
            End If
            Return ret.TrimEnd
        End Function

        Public ReadOnly Property Salutation() As String
            Get
                If DateDiff(DateInterval.Year, DOB, DateTime.Today) < 16 Then
                    Return GetFullName(GuardianTitle, GuardianSurName, Nothing)
                Else
                    Return GetFullName(Title, SurName, Nothing)
                End If
            End Get
        End Property
        Public ReadOnly Property Guardian() As String
            Get
                Return GetFullName(GuardianTitle, GuardianFirstName, GuardianSurName)
            End Get
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
                Dim dAge As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Year, DOB, Date.Today)
                If dAge < 10 Then
                    Dim dMonths As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Month, DOB, Date.Today) - dAge * 12
                    If dAge = 1 Then
                        Return String.Format("{0} Yr {1} Mths", dAge, dMonths)
                    Else
                        Return String.Format("{0} Yrs {1} Mths", dAge, dMonths)
                    End If
                Else
                    Return String.Format("{0} Yrs ", dAge)
                End If
            End Get
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
        Private _addr2 As String
        <Size(50)>
        Public Property Addr2() As String
            Get
                Return _addr2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr2", _addr2, value)
            End Set
        End Property
        Private _addr3 As String
        <Size(50)>
        Public Property Addr3() As String
            Get
                Return _addr3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr3", _addr3, value)
            End Set
        End Property
        Private _city As String
        <Size(50)>
        Public Property City() As String
            Get
                Return _city
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("City", _city, value)
            End Set
        End Property
        Private _county As String
        <Size(50)>
        Public Property County() As String
            Get
                Return _county
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("County", _county, value)
            End Set
        End Property
        Private _postcode As String
        <Size(10)>
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
        <Association("Patient-TrackingNotes")>
        Public ReadOnly Property TrackingNotes() As XPCollection(Of TrackingNote)
            Get
                Return GetCollection(Of TrackingNote)("TrackingNotes")
            End Get
        End Property
        Private _referringGP As String
        <Size(40)>
        Public Property ReferringGP() As String
            Get
                Return _referringGP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReferringGP", _referringGP, value)
            End Set
        End Property

        Private _referringPractice As String
        <Size(40)>
        Public Property ReferringPractice() As String
            Get
                Return _referringPractice
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReferringPractice", _referringPractice, value)
            End Set
        End Property
        Private _email As String
        <Size(120)>
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", _email, value)
            End Set
        End Property
        Private _workPhone As String
        <Size(20)>
        Public Property WorkPhone() As String
            Get
                Return _workPhone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WorkPhone", _workPhone, value)
            End Set
        End Property
        Private _homePhone As String
        <Size(20)>
        Public Property HomePhone() As String
            Get
                Return _homePhone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HomePhone", _homePhone, value)
            End Set
        End Property
        Private fMobilePhone As String
        <Size(20)>
        Public Property MobilePhone() As String
            Get
                Return fMobilePhone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MobilePhone ", fMobilePhone, value)
            End Set
        End Property
        Private _consenttoLeaveMessage As Char
        Public Property ConsentToLeaveMessage() As Char
            Get
                Return _consenttoLeaveMessage
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("ConsentToLeaveMessage ", _consenttoLeaveMessage, value)
            End Set
        End Property
        Private _PatientApp As Char
        Public Property PatientApp() As Char
            Get
                Return _PatientApp
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("_PatientApp ", _PatientApp, value)
            End Set
        End Property
        Private _ccAuthorised As Char
        Public Property CCAuthorised() As Char
            Get
                Return _ccAuthorised
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("CCAuthorised", _ccAuthorised, value)
            End Set
        End Property
        Private fnote As String
        <Size(SizeAttribute.Unlimited)>
        Public Property Note() As String
            Get
                Return fnote
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Note", fnote, value)
            End Set
        End Property
        <Association("Patient-LibraryDoc")>
        Public ReadOnly Property LibraryDocuments() As XPCollection(Of LibraryDoc)
            Get
                Return GetCollection(Of LibraryDoc)("LibraryDocuments")
            End Get
        End Property
        <Association("Patient-Communication")>
        Public ReadOnly Property Communications() As XPCollection(Of Communication)
            Get
                Return GetCollection(Of Communication)("Communications")
            End Get
        End Property
        <Association("Patient-Documents")>
        Public ReadOnly Property Documents() As XPCollection(Of LinkedDocument)
            Get
                Return GetCollection(Of LinkedDocument)("Documents")
            End Get
        End Property
        Public Function GetPatientInfoHtml() As String
            Dim ret As String = String.Format("<b><href=Beneficary={0}>{1}</href></b>", Oid, FullName)
            If (Not Object.Equals(DOB, Nothing)) AndAlso (Not Object.Equals(DOB, DateTime.MinValue)) Then
                ret &= String.Format(Constants.vbCrLf & "DOB: <b>{0:d}</b>", DOB)
            End If
            'If (FamilyGroup <> Oid) Then
            '    ret &= String.Format(Constants.vbCrLf & "Main Beneficiary: <i><href=Beneficary={0}>{1}</href></i>", FamilyGroup.Oid, FamilyGroup.FullName)
            'End If
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
        <Association("Patient-Referrals")>
        Public ReadOnly Property Referrals() As XPCollection(Of Referral)
            Get
                Return GetCollection(Of Referral)("Referrals")
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
End Namespace