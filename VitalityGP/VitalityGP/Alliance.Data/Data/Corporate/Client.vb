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
    ''' <summary>
    ''' Clients
    ''' </summary>
    ''' lar de lar
    ''' <remarks>remarks go here</remarks>
    Public Class Client
        Inherits AuditedBase
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
            Me.FullName = name
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
        Private _clientType As eClientType
        Public Property ClientType() As eClientType
            Get
                Return _clientType
            End Get
            Set(ByVal value As eClientType)
                SetPropertyValue(Of eClientType)("ClientType", _clientType, value)
            End Set
        End Property
        Private _Insurer As Insurer
        Public Property Insurer() As Insurer
            Get
                Return _Insurer
            End Get
            Set(ByVal value As Insurer)
                SetPropertyValue(Of Insurer)("Insurer", _Insurer, value)
            End Set
        End Property
        Private fFullName As String
        <Size(30)> _
        Public Property FullName() As String
            Get
                Return fFullName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FullName", fFullName, value)
            End Set
        End Property
        Property fCRMID As Integer
        Public Property CRMID() As Integer
            Get
                Return fCRMID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CRMID", fCRMID, value)
            End Set
        End Property
        Private fClient As String
        <Size(3)> _
        Public Property Client() As String
            Get
                Return fClient
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Client", fClient, value)
            End Set
        End Property
        Private fAcCode As String
        <Size(10)> _
        Public Property AcCode() As String
            Get
                Return fAcCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AcCode", fAcCode, value)
            End Set
        End Property
        Private _costCentre As String
        <Size(4)> _
        Public Property CostCentre() As String
            Get
                Return _costCentre
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CostCentre", _costCentre, value)
            End Set
        End Property
        Private _dept As String
        <Size(3)> _
        Public Property Dept() As String
            Get
                Return _dept
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Dept", _dept, value)
            End Set
        End Property
        Private fAddr1 As String
        <Size(50)> _
        Public Property Addr1() As String
            Get
                Return fAddr1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr1", fAddr1, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr2 As String
        Public Property Addr2() As String
            Get
                Return fAddr2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr2", fAddr2, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr3 As String
        Public Property Addr3() As String
            Get
                Return fAddr3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr3", fAddr3, value)
            End Set
        End Property
        <Size(50)> _
        Private fAddr4 As String
        Public Property Addr4() As String
            Get
                Return fAddr4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Addr4", fAddr4, value)
            End Set
        End Property
        <Size(10)> _
        Private fPostcode As String
        Public Property PostCode() As String
            Get
                Return fPostcode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PostCode", fPostcode, value)
            End Set
        End Property
        <Size(15)> _
        Private _phoneNumber As String
        Public Property PhoneNumber() As String
            Get
                Return _phoneNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PhoneNumber", _phoneNumber, value)
            End Set
        End Property
        Private _eapHotline As String
        <Size(15)> _
        Public Property EapHotline() As String
            Get
                Return _eapHotline
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EapHotline", _eapHotline, value)
            End Set
        End Property
        Private _helpline As String
        <Size(15)> _
        Public Property HelpLine() As String
            Get
                Return _helpline
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HelpLine", _helpline, value)
            End Set
        End Property
        <Size(100)> _
        Private _email As String
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", _email, value)
            End Set
        End Property
        Private fOriginalPolicyStarted As Date
        Public Property OriginalPolicyStarted() As Date
            Get
                Return fOriginalPolicyStarted
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("OriginalPolicyStarted", fOriginalPolicyStarted, value)
            End Set
        End Property
        Private fpolicyStartDate As Date
        Public Property PolicyStartDate() As Date
            Get
                Return fpolicyStartDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("PolicyStartDate", fpolicyStartDate, value)
            End Set
        End Property
        Private fpolicyEndDate As Date
        Public Property PolicyEndDate() As Date
            Get
                Return fpolicyEndDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("PolicyEndDate", fpolicyEndDate, value)
            End Set
        End Property
        Private fFundValue As Double
        Public Property FundValue() As Double
            Get
                Return fFundValue
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("FundValue", fFundValue, value)
            End Set
        End Property
        Private _markUp As Double
        Public Property MarkUp() As Double
            Get
                Return _markUp
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("MarkUp", _markUp, value)
            End Set
        End Property
        Private fStyle As String
        <Size(20)> _
        Public Property Style() As String
            Get
                Return fStyle
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Style", fStyle, value)
            End Set
        End Property
        Private fBrandColour As Integer
        Public Property BrandColour() As Integer
            Get
                Return fBrandColour
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BrandColour", fBrandColour, value)
            End Set
        End Property
        Private _checkBenefit As Boolean
        Public Property CheckBenefit() As Boolean
            Get
                Return _checkBenefit
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("CheckBenefit", _checkBenefit, value)
            End Set
        End Property
        Private _validforInvoicing As Boolean
        Public Property ValidForInvoicing() As Boolean
            Get
                Return _validforInvoicing
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ValidForInvoicing", _validforInvoicing, value)
            End Set
        End Property
        Private _checkBenefitDetail As Boolean
        Public Property CheckBenefitDetail() As Boolean
            Get
                Return _checkBenefitDetail
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("CheckBenefitDetail", _checkBenefitDetail, value)
            End Set
        End Property
        Private fcomments As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Comments() As String
            Get
                Return fcomments
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Comments", fcomments, value)
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
        <Association("Client-WebClientUsers")> _
        Public ReadOnly Property WebClientUsers() As XPCollection(Of WebClientUser)
            Get
                Return GetCollection(Of WebClientUser)("WebClientUsers")
            End Get
        End Property
        <Association("Client-Beneficiaries")> _
        Public ReadOnly Property Beneficiaries() As XPCollection(Of Beneficiary)
            Get
                Return GetCollection(Of Beneficiary)("Beneficiaries")
            End Get
        End Property
        <Association("Client-BenefitLimits")> _
        Public ReadOnly Property BenefitLimits() As XPCollection(Of BenefitLimit)
            Get
                Return GetCollection(Of BenefitLimit)("BenefitLimits")
            End Get
        End Property
        <Association("Client-LibraryDoc")> _
        Public ReadOnly Property LibraryDocuments() As XPCollection(Of LibraryDoc)
            Get
                Return GetCollection(Of LibraryDoc)("LibraryDocuments")
            End Get
        End Property
        <Association("Client-Scheme")> _
        Public ReadOnly Property Schemes() As XPCollection(Of Scheme)
            Get
                Return GetCollection(Of Scheme)("Schemes")
            End Get
        End Property

        <Association("Client-Policy")> _
        Public ReadOnly Property Policies() As XPCollection(Of Policy)
            Get
                Return GetCollection(Of Policy)("Policies")
            End Get
        End Property
        <Delayed>
        Public ReadOnly Property EmployeeCount As Integer
            Get
                'GCRecord IS NULL AND Client = 114 AND JoinDate <= '2015/07/27') AND (LeaveDate IS NULL OR LeaveDate > '2015/07/27') and RelationShip = 11
                If Oid = 1 Then
                    Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("JoinDate < ? and (LeaveDate > ? or LeaveDate is null) and [RelationShip] = ?", DateTime.Today, DateTime.Today, eRelationship.Employee)))
                Else
                    Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Client = ? and JoinDate < ? and (LeaveDate > ? or LeaveDate is null) and [RelationShip] = ?", Oid, DateTime.Today, DateTime.Today, eRelationship.Employee)))
                End If

            End Get
        End Property
        <Delayed>
        Public ReadOnly Property DependantCount() As Integer
            Get
                If Oid = 1 Then
                    Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("JoinDate < ? and (LeaveDate > ? or LeaveDate is null) and [RelationShip] <> ?", DateTime.Today, DateTime.Today, eRelationship.Employee)))
                Else
                    Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Client = ? and JoinDate < ? and (LeaveDate > ? or LeaveDate is null) and [RelationShip] <> ?", Oid, DateTime.Today, DateTime.Today, eRelationship.Employee)))
                End If

            End Get
        End Property
        <Delayed>
        Public ReadOnly Property LivesCount() As Integer
            Get
                If Oid = 1 Then
                    Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("JoinDate < ? and (LeaveDate > ? or LeaveDate is null) ", DateTime.Today, DateTime.Today)))
                Else

                    Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Client = ? and JoinDate < ? and (LeaveDate > ? or LeaveDate is null) ", Oid, DateTime.Today, DateTime.Today)))
                End If

            End Get
        End Property

        'Private fEmployeeCount As Integer
        'Public Property EmployeeCount() As Integer
        '    Get
        '        Return fEmployeeCount
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("EmployeeCount", fEmployeeCount, value)
        '    End Set
        'End Property
        Private _beneficiaryLiveCount As Integer
        Public Property BeneficiaryCount() As Integer
            Get
                Return _beneficiaryLiveCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BeneficiaryCount", _beneficiaryLiveCount, value)
            End Set
        End Property
        Private fBeneficiaryLeftCount As Integer
        Public Property BeneficiaryLeftCount() As Integer
            Get
                Return fBeneficiaryLeftCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BeneficiaryLeftCount", fBeneficiaryLeftCount, value)
            End Set
        End Property
        'Private fDependantsCount As Integer
        'Public Property DependantsCount() As Integer
        '    Get
        '        Return fDependantsCount
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("DependantsCount", fDependantsCount, value)
        '    End Set
        'End Property
        <Association("Client-Divisions")> _
        Public ReadOnly Property Divisions() As XPCollection(Of Division)
            Get
                Return GetCollection(Of Division)("Divisions")
            End Get
        End Property
        <Association("Client-ReportingDivisions")> _
        Public ReadOnly Property ReportingDivisions() As XPCollection(Of ReportingDivision)
            Get
                Return GetCollection(Of ReportingDivision)("ReportingDivisions")
            End Get
        End Property
        <Association("Client-BusinessUnits")> _
        Public ReadOnly Property BusinessUnits() As XPCollection(Of BusinessUnit)
            Get
                Return GetCollection(Of BusinessUnit)("BusinessUnits")
            End Get
        End Property
        <Association("Client-Staff")> _
        Public ReadOnly Property Staff() As XPCollection(Of ClientStaff)
            Get
                Return GetCollection(Of ClientStaff)("Staff")
            End Get
        End Property
        Private _memberPortal As Boolean
        Public Property MemberPortal() As Boolean
            Get
                Return _memberPortal
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("MemberPortal", _memberPortal, value)
            End Set
        End Property
        Private _excessFromFund As Boolean
        Public Property ExcessFromFund() As Boolean
            Get
                Return _excessFromFund
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ExcessFromFund", _excessFromFund, value)
            End Set
        End Property
        Public Sub UpdateStatistics()
            UpdateEmployeeCount()
            UpdateDependantsCount()
            UpdateBeneficiaryLeftCount()
            UpdateBeneficiaryCount()

        End Sub

        Public Sub UpdateEmployeeCount()
            'aaa
            ' EmployeeCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Client = ? and isnull(LeaveDate) and [RelationShip] = 11", Oid))
        End Sub
        Public Sub UpdateDependantsCount()
            'DependantsCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Client = ? and isnull(LeaveDate) and [RelationShip] <> 11", Oid))
        End Sub
        Public Sub UpdateBeneficiaryLeftCount()
            'BeneficiaryLeftCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Client = ? and not isnull(LeaveDate)", Oid))
        End Sub
        Public Sub UpdateBeneficiaryCount()
            ' BeneficiaryCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Client = ? and isnull(LeaveDate)", Oid))
        End Sub

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
    Public Class ClientStaff
        Inherits XPObject
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
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _Client As Client
        <Association("Client-Staff")> _
        Public Property Client() As Client
            Get
                Return _Client
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", _Client, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(False)>
        <Size(10)>
        Private _salutation As String
        Public Property Salutation() As String
            Get
                Return _salutation
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Title", _salutation, value)
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
        Private _firstName As String
        <Size(20)>
        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FirstName", _firstName, value)
            End Set
        End Property
        <MemberDesignTimeVisibility(True)>
        <Size(30)>
        Private _lastName As String
        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LastName", _lastName, value)
            End Set
        End Property
        <Size(120)> <MemberDesignTimeVisibility(True)>
        Private _email As String
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Email", _email, value)
            End Set
        End Property
        Private _phone As String
        <Size(20)> <MemberDesignTimeVisibility(True)>
        Public Property Phone() As String
            Get
                Return _phone
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Phone", _phone, value)
            End Set
        End Property
        Private _extension As String
        <Size(5)> <MemberDesignTimeVisibility(True)>
        Public Property Extension() As String
            Get
                Return _extension
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Extension", _extension, value)
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
                    Return PasswordHelper.Decode(EntityType.ClientStaff, Password)
                Else
                    Return String.Empty
                End If
            End Get
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return GetDelayedPropertyValue(Of String)("Notes")
            End Get
            Set(ByVal value As String)
                SetDelayedPropertyValue("Notes", value)
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
        Private _BusinessUnit As BusinessUnit
        Public Property BusinessUnit() As BusinessUnit
            Get
                Return _BusinessUnit
            End Get
            Set(ByVal value As BusinessUnit)
                SetPropertyValue(Of BusinessUnit)("BusinessUnit", _BusinessUnit, value)
            End Set
        End Property
        Private _division As Division
        Public Property Division() As Division
            Get
                Return _division
            End Get
            Set(ByVal value As Division)
                SetPropertyValue(Of Division)("Division", _division, value)
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
        <MemberDesignTimeVisibility(True)> _
        Public Overridable ReadOnly Property FullName() As String
            Get
                Dim ret As String
                If Object.Equals(FirstName, Nothing) Then
                    ret = String.Empty
                Else
                    ret = FirstName.Trim()
                End If
                Dim lastNameTrim As String
                If Object.Equals(LastName, Nothing) Then
                    lastNameTrim = String.Empty
                Else
                    lastNameTrim = LastName.Trim()
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
    Public Class BusinessUnit
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
            Me.BusinessUnit = name
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
        Private fclient As Client
        <Association("Client-BusinessUnits")> _
        Public Property Client() As Client
            Get
                Return fclient
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", fclient, value)
            End Set
        End Property
        Private fBusinessUnit As String
        Public Property BusinessUnit() As String
            Get
                Return fBusinessUnit
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BusinessUnit", fBusinessUnit, value)
            End Set
        End Property
        Private _excess As Double
        Public Property Excess() As Double
            Get
                Return _excess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Excess", _excess, value)
            End Set
        End Property
        Private _dependantexcess As Double
        Public Property DependantExcess() As Double
            Get
                Return _dependantexcess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("DependantExcess", _dependantexcess, value)
            End Set
        End Property
        Private _moratorium As Integer
        Public Property Moratorium() As Integer
            Get
                Return _moratorium
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Moratorium", _moratorium, value)
            End Set
        End Property
        Private fcomments As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Comments() As String
            Get
                Return fcomments
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Comments", fcomments, value)
            End Set
        End Property
        <Association("BusinessUnit-Beneficiaries")> _
        Public ReadOnly Property Beneficiaries() As XPCollection(Of Beneficiary)
            Get
                Return GetCollection(Of Beneficiary)("Beneficiaries")
            End Get
        End Property
        <Association("BusinessUnit-Claims")> _
        Public ReadOnly Property Claims() As XPCollection(Of Claim)
            Get
                Return GetCollection(Of Claim)("Claims")
            End Get
        End Property
        <Association("BusinessUnit-Authorisations")> _
        Public ReadOnly Property Authorisations() As XPCollection(Of Authorisation)
            Get
                Return GetCollection(Of Authorisation)("Authorisations")
            End Get
        End Property
        <Association("BusinessUnit-Invoices")> _
        Public ReadOnly Property Invoices() As XPCollection(Of Invoice)
            Get
                Return GetCollection(Of Invoice)("Invoices")
            End Get
        End Property
        <Delayed>
        Public ReadOnly Property EmployeeCount As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("BusinessUnit = ? and isnull(LeaveDate) and [RelationShip] = ?", Oid, eRelationship.Employee)))
            End Get
        End Property
        <Delayed>
        Public ReadOnly Property DependantCount() As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("BusinessUnit = ? and isnull(LeaveDate) and [RelationShip] <> ?", Oid, eRelationship.Employee)))
            End Get
        End Property
        <Delayed>
        Public ReadOnly Property LivesCount() As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("BusinessUnit = ? and isnull(LeaveDate) ", Oid)))
            End Get
        End Property

        Private fBeneficiaryLiveCount As Integer
        Public Property BeneficiaryCount() As Integer
            Get
                Return fBeneficiaryLiveCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BeneficiaryCount", fBeneficiaryLiveCount, value)
            End Set
        End Property
        Private fBeneficiaryLeftCount As Integer
        Public Property BeneficiaryLeftCount() As Integer
            Get
                Return fBeneficiaryLeftCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BeneficiaryLeftCount", fBeneficiaryLeftCount, value)
            End Set
        End Property

        Public Sub UpdateStatistics()
            UpdateEmployeeCount()
            UpdateDependantsCount()
            UpdateBeneficiaryLeftCount()
            UpdateBeneficiaryCount()

        End Sub
        Public Sub UpdateEmployeeCount()
            '   EmployeeCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("BusinessUnit = ? and isnull(LeaveDate) and [RelationShip] = ?", Oid, 11))
        End Sub
        Public Sub UpdateDependantsCount()
            ' DependantsCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("BusinessUnit = ? and isnull(LeaveDate) and [RelationShip] <> ?", Oid, 11))
        End Sub
        Public Sub UpdateBeneficiaryLeftCount()
            BeneficiaryLeftCount = CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("BusinessUnit = ? and not isnull(LeaveDate)", Oid)))
        End Sub
        Public Sub UpdateBeneficiaryCount()
            BeneficiaryCount = CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("BusinessUnit = ? and isnull(LeaveDate)", Oid)))
        End Sub
        Public Overrides Function ToString() As String
            Return String.Format("{0}", BusinessUnit)
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
    Public Class Division
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
            Me.Division = name
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
        Private fclient As Client
        <Association("Client-Divisions")> _
        Public Property Client() As Client
            Get
                Return fclient
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", fclient, value)
            End Set
        End Property
        Private fDivision As String
        Public Property Division() As String
            Get
                Return fDivision
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Division", fDivision, value)
            End Set
        End Property
        Private fcomments As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Comments() As String
            Get
                Return fcomments
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Comments", fcomments, value)
            End Set
        End Property
        <Association("Division-Beneficiaries")> _
        Public ReadOnly Property Beneficiaries() As XPCollection(Of Beneficiary)
            Get
                Return GetCollection(Of Beneficiary)("Beneficiaries")
            End Get
        End Property
        <Delayed>
        Public ReadOnly Property EmployeeCount As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Division = ? and isnull(LeaveDate) and [RelationShip] = ?", Oid, eRelationship.Employee)))
            End Get
        End Property
        <Delayed>
        Public ReadOnly Property DependantCount() As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Division = ? and isnull(LeaveDate) and [RelationShip] <> ?", Oid, eRelationship.Employee)))
            End Get
        End Property
        <Delayed>
        Public ReadOnly Property LivesCount() As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Division = ? and isnull(LeaveDate) ", Oid)))
            End Get
        End Property
        'Private fEmployeeCount As Integer
        'Public Property EmployeeCount() As Integer
        '    Get
        '        Return fEmployeeCount
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("EmployeeCount", fEmployeeCount, value)
        '    End Set
        'End Property
        Private fBeneficiaryLiveCount As Integer
        Public Property BeneficiaryCount() As Integer
            Get
                Return fBeneficiaryLiveCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BeneficiaryCount", fBeneficiaryLiveCount, value)
            End Set
        End Property
        Private fBeneficiaryLeftCount As Integer
        Public Property BeneficiaryLeftCount() As Integer
            Get
                Return fBeneficiaryLeftCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BeneficiaryLeftCount", fBeneficiaryLeftCount, value)
            End Set
        End Property
        'Private fDependantsCount As Integer
        'Public Property DependantsCount() As Integer
        '    Get
        '        Return fDependantsCount
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("DependantsCount", fDependantsCount, value)
        '    End Set
        'End Property
        Public Sub UpdateStatistics()
            UpdateEmployeeCount()
            UpdateDependantsCount()
            UpdateBeneficiaryLeftCount()
            UpdateBeneficiaryCount()

        End Sub
        Public Sub UpdateEmployeeCount()
            ' EmployeeCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Division = ? and isnull(LeaveDate) and [RelationShip] = ?", Oid, 11))
        End Sub
        Public Sub UpdateDependantsCount()
            '   DependantsCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Division = ? and isnull(LeaveDate) and [RelationShip] <> ?", Oid, 11))
        End Sub
        Public Sub UpdateBeneficiaryLeftCount()
            BeneficiaryLeftCount = CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Division = ? and not isnull(LeaveDate)", Oid)))
        End Sub
        Public Sub UpdateBeneficiaryCount()
            BeneficiaryCount = CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Division = ? and isnull(LeaveDate)", Oid)))
        End Sub
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Division)
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
    Public Class ReportingDivision
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
            Me.ReportingDivision = name
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
        Private fReportingDivision As String
        Public Property ReportingDivision() As String
            Get
                Return fReportingDivision
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReportingDivision", fReportingDivision, value)
            End Set
        End Property
        Private fcomments As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Comments() As String
            Get
                Return fcomments
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Comments", fcomments, value)
            End Set
        End Property
        Private fclient As Client
        <Association("Client-ReportingDivisions")> _
        Public Property Client() As Client
            Get
                Return fclient
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", fclient, value)
            End Set
        End Property
        Public ReadOnly Property EmployeeCount As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("ReportingDivision = ? and isnull(LeaveDate) and [RelationShip] = ?", Oid, eRelationship.Employee)))
            End Get
        End Property
        <Delayed>
        Public ReadOnly Property DependantsCount() As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("ReportingDivision = ? and isnull(LeaveDate) and [RelationShip] <> ?", Oid, eRelationship.Employee)))
            End Get
        End Property
        <Delayed>
        Public ReadOnly Property LivesCount() As Integer
            Get
                Return CInt(Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("ReportingDivision = ? and isnull(LeaveDate) ", Oid)))
            End Get
        End Property
        'Private fEmployeeCount As Integer
        'Public Property EmployeeCount() As Integer
        '    Get
        '        Return fEmployeeCount
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("EmployeeCount", fEmployeeCount, value)
        '    End Set
        'End Property
        Private fBeneficiaryLiveCount As Integer
        Public Property BeneficiaryCount() As Integer
            Get
                Return fBeneficiaryLiveCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BeneficiaryCount", fBeneficiaryLiveCount, value)
            End Set
        End Property
        Private fBeneficiaryLeftCount As Integer
        Public Property BeneficiaryLeftCount() As Integer
            Get
                Return fBeneficiaryLeftCount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BeneficiaryLeftCount", fBeneficiaryLeftCount, value)
            End Set
        End Property
        'Private fDependantsCount As Integer
        'Public Property DependantsCount() As Integer
        '    Get
        '        Return fDependantsCount
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("DependantsCount", fDependantsCount, value)
        '    End Set
        'End Property
        Public Sub UpdateStatistics()
            UpdateEmployeeCount()
            UpdateDependantsCount()
            UpdateBeneficiaryLeftCount()
            UpdateBeneficiaryCount()

        End Sub
        Public Sub UpdateEmployeeCount()
            '  EmployeeCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("ReportingDivision = ? and isnull(LeaveDate) and [RelationShip] = 11", Oid))
        End Sub
        Public Sub UpdateDependantsCount()
            '  DependantsCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("ReportingDivision = ? and isnull(LeaveDate) and [RelationShip] <> 11", Oid))
        End Sub
        Public Sub UpdateBeneficiaryLeftCount()
            '  BeneficiaryLeftCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("ReportingDivision = ? and not isnull(LeaveDate)", Oid))
        End Sub
        Public Sub UpdateBeneficiaryCount()
            ' BeneficiaryCount = Session.Evaluate(GetType(Beneficiary), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("ReportingDivision = ? and isnull(LeaveDate)", Oid))
        End Sub

        <Association("ReportingDivision-Beneficiaries"), Delayed> _
        Public ReadOnly Property Beneficiaries() As XPCollection(Of Beneficiary)
            Get
                Return GetCollection(Of Beneficiary)("Beneficiaries")
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", ReportingDivision)
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
    Public Class Period
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
        Private fperiod As String
        <Size(15)> _
        Public Property Period() As String
            Get
                Return fperiod
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Period", fperiod, value)
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
    Public Class BenefitLimit
        Inherits AuditedBase
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal _policy As Policy)
            MyBase.New(session)
            Me.Policy = _policy
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
        Private fclient As Client
        <Association("Client-BenefitLimits")> _
        Public Property Client() As Client
            Get
                Return fclient
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", fclient, value)
            End Set
        End Property
        Private _policy As Policy
        <Association("Policy-BenefitLimits")> _
        Public Property Policy() As Policy
            Get
                Return _policy
            End Get
            Set(ByVal value As Policy)
                SetPropertyValue(Of Policy)("Policy", _policy, value)
            End Set
        End Property
        Private _parent As BenefitLimit
        <Association("BenefitLimitChildren")> _
        Public Property Parent() As BenefitLimit
            Get
                Return _parent
            End Get
            Set(ByVal value As BenefitLimit)
                SetPropertyValue("Parent", _parent, value)
            End Set
        End Property
        <Association("BenefitLimit-SubBenefitLimit")> _
        Public ReadOnly Property SubBenefitLimits() As XPCollection(Of SubBenefitLimit)
            Get
                Return GetCollection(Of SubBenefitLimit)("SubBenefitLimits")
            End Get
        End Property
        <Association("BenefitLimitChildren")> _
        Public ReadOnly Property Children() As XPCollection(Of BenefitLimit)
            Get
                Return GetCollection(Of BenefitLimit)("Children")
            End Get
        End Property
        Private _benefitLimit As String
        Public Property BenefitLimit() As String
            Get
                Return _benefitLimit
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BenefitLimit", _benefitLimit, value)
            End Set
        End Property
        Private _OverRidden As Boolean
        <NonPersistent()> _
        Public Property OverRidden() As Boolean
            Get
                Return _OverRidden
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("OverRidden", _OverRidden, value)
            End Set
        End Property
        Private fstartDate As Date?
        Public Property StartDate() As Date?
            Get
                Return fstartDate
            End Get
            Set(ByVal value As Date?)
                SetPropertyValue(Of Date?)("StartDate", fstartDate, value)
            End Set
        End Property
        Private fendDate As Date?
        Public Property EndDate() As Date?
            Get
                Return fendDate
            End Get
            Set(ByVal value As Date?)
                SetPropertyValue(Of Date?)("EndDate", fendDate, value)
            End Set
        End Property
        Private _excludereferred As Boolean
        Public Property ExcludeReferrred() As Boolean
            Get
                Return _excludereferred
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ExcludeReferrred", _excludereferred, value)
            End Set
        End Property
        Private _distribution As eBenefitDistribution
        Public Property Distribution() As eBenefitDistribution
            Get
                Return _distribution
            End Get
            Set(ByVal value As eBenefitDistribution)
                SetPropertyValue(Of eBenefitDistribution)("Distribution", _distribution, value)
            End Set
        End Property
        Private _period As eBenefitPeriod
        Public Property Period() As eBenefitPeriod
            Get
                Return _period
            End Get
            Set(ByVal value As eBenefitPeriod)
                SetPropertyValue(Of eBenefitPeriod)("Period", _period, value)
            End Set
        End Property
        Private fAuthorisationType As eAuthorisationType
        Public Property AuthorisationType() As eAuthorisationType
            Get
                Return fAuthorisationType
            End Get
            Set(ByVal value As eAuthorisationType)
                SetPropertyValue(Of eAuthorisationType)("AuthorisationType", fAuthorisationType, value)
            End Set
        End Property
        Private _sessions As Integer
        Public Property Sessions() As Integer
            Get
                Return _sessions
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Sessions", _sessions, value)
            End Set
        End Property
        Private _incurredSessions As Integer
        <NonPersistent()> _
        Public Property IncurredSessions() As Integer
            Get
                Return _incurredSessions
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IncurredSessions", _incurredSessions, value)
            End Set
        End Property
        Private _limit As Double
        Public Property Limit() As Double
            Get
                Return _limit
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Limit", _limit, value)
            End Set
        End Property
        Private _incurredLimit As Double
        <NonPersistent()> _
        Public Property IncurredLimit() As Double
            Get
                Return _incurredLimit
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("IncurredLimit", _incurredLimit, value)
            End Set
        End Property
        Private _annualSessions As Integer
        Public Property AnnualSessions() As Integer
            Get
                Return _annualSessions
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("AnnualIncidence", _annualSessions, value)
            End Set
        End Property
        Private _incurredAnnualSessions As Integer
        <NonPersistent()> _
        Public Property IncurredAnnualSessions() As Integer
            Get
                Return _incurredAnnualSessions
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IncurredAnnualSessions", _incurredAnnualSessions, value)
            End Set
        End Property
        Private _annualLimit As Double
        Public Property AnnualLimit() As Double
            Get
                Return _annualLimit
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("AnnualLimit", _annualLimit, value)
            End Set
        End Property
        Private _incurredAnnualLimit As Double
        <NonPersistent()> _
        Public Property IncurredAnnualLimit() As Double
            Get
                Return _incurredAnnualLimit
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("IncurredAnnualLimit", _incurredAnnualLimit, value)
            End Set
        End Property

        Private _lowerAgeLimit As Integer
        Public Property LowerAgeLimit() As Integer
            Get
                Return _lowerAgeLimit
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("LowerAgeLimit", _lowerAgeLimit, value)
            End Set
        End Property

        Private _allowOverRide As Boolean
        Public Property AllowOverRide() As Boolean
            Get
                Return _allowOverRide
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("AllowOverRide", _allowOverRide, value)
            End Set
        End Property
        Private _fullRefund As Boolean
        Public Property FullRefund() As Boolean
            Get
                Return _fullRefund
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("FullRefund", _fullRefund, value)
            End Set
        End Property
        Private _percentageToPay As Double
        Public Property PercentageToPay() As Double
            Get
                Return _percentageToPay
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("PercentageToPay", _percentageToPay, value)
            End Set
        End Property
        Private _excess As Double
        <NonPersistent()> _
        Public Property Excess() As Double
            Get
                Return _excess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Excess", _excess, value)
            End Set
        End Property
        Private _dependantexcess As Double
        <NonPersistent()> _
        Public Property DependantExcess() As Double
            Get
                Return _dependantexcess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("DependantExcess", _dependantexcess, value)
            End Set
        End Property
        Private _moratorium As Integer
        <NonPersistent()> _
        Public Property Moratorium() As Integer
            Get
                Return _moratorium
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Moratorium", _moratorium, value)
            End Set
        End Property
        Private fcomments As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Comments() As String
            Get
                Return fcomments
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Comments", fcomments, value)
            End Set
        End Property
        Private _age As Integer
        <NonPersistent()> _
        Public Property Age() As Integer
            Get
                Return _age
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Age", _age, value)
            End Set
        End Property
        Private _treatmentDate As Date
        <NonPersistent()> _
        Public Property TreatmentDate() As Date
            Get
                Return _treatmentDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("TreatmentDate", _treatmentDate, value)
            End Set
        End Property

        Private _beneficiary As Beneficiary
        <NonPersistent()> _
        Public Property Beneficiary() As Beneficiary
            Get
                Return _beneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", _beneficiary, value)
            End Set
        End Property
        Private _Claim As Claim
        <NonPersistent()> _
        Public Property Claim() As Claim
            Get
                Return _Claim
            End Get
            Set(ByVal value As Claim)
                SetPropertyValue(Of Claim)("Claim", _Claim, value)
            End Set
        End Property
        Private _authorisation As Authorisation
        <NonPersistent()> _
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", BenefitLimit)
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
        Public Function GetBenefitLimitInfoHtml() As String
            Dim ret As String = String.Format("<size=+1><b>{0}</b><size=-1>", BenefitLimit)
            ret &= "<br>"
            ret &= String.Format("<br>BenefitDetail: <b>{0}</b>", BenefitLimit)
            If Not String.IsNullOrEmpty(Comments) Then
                ret &= String.Format("<br>Notes: <b>{0}", Comments)
            End If
            Return ret
        End Function
    End Class
    Public Class SubBenefitLimit
        Inherits AuditedBase
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
        Private _benefitLimit As BenefitLimit
        <Association("BenefitLimit-SubBenefitLimit")> _
        Public Property benefitLimit() As BenefitLimit
            Get
                Return _benefitLimit
            End Get
            Set(ByVal value As BenefitLimit)
                SetPropertyValue(Of BenefitLimit)("BenefitLimit", _benefitLimit, value)
            End Set
        End Property
        Private _businessunit As BusinessUnit
        Public Property BusinessUnit() As BusinessUnit
            Get
                Return _businessunit
            End Get
            Set(ByVal value As BusinessUnit)
                SetPropertyValue(Of BusinessUnit)("BusinessUnit", _businessunit, value)
            End Set
        End Property
        Private _excludereferred As Boolean
        Public Property ExcludeReferrred() As Boolean
            Get
                Return _excludereferred
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ExcludeReferrred", _excludereferred, value)
            End Set
        End Property
        Private _distribution As eBenefitDistribution
        Public Property Distribution() As eBenefitDistribution
            Get
                Return _distribution
            End Get
            Set(ByVal value As eBenefitDistribution)
                SetPropertyValue(Of eBenefitDistribution)("Distribution", _distribution, value)
            End Set
        End Property
        Private _sessions As Integer
        Public Property Sessions() As Integer
            Get
                Return _sessions
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Sessions", _sessions, value)
            End Set
        End Property
        Private _limit As Double
        Public Property Limit() As Double
            Get
                Return _limit
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Limit", _limit, value)
            End Set
        End Property
        Private _annualSessions As Integer
        Public Property AnnualSessions() As Integer
            Get
                Return _annualSessions
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("AnnualIncidence", _annualSessions, value)
            End Set
        End Property
        Private _annualLimit As Double
        Public Property AnnualLimit() As Double
            Get
                Return _annualLimit
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("AnnualLimit", _annualLimit, value)
            End Set
        End Property
        Private _lowerAgeLimit As Integer
        Public Property LowerAgeLimit() As Integer
            Get
                Return _lowerAgeLimit
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("LowerAgeLimit", _lowerAgeLimit, value)
            End Set
        End Property
        Private _allowOverRide As Boolean
        Public Property AllowOverRide() As Boolean
            Get
                Return _allowOverRide
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("AllowOverRide", _allowOverRide, value)
            End Set
        End Property
        Private _fullRefund As Boolean
        Public Property FullRefund() As Boolean
            Get
                Return _fullRefund
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("FullRefund", _fullRefund, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", benefitLimit)
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
    Public Class Scheme
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
        Private fclient As Client
        <Association("Client-Scheme")> _
        Public Property Client() As Client
            Get
                Return fclient
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", fclient, value)
            End Set
        End Property
        Private _scheme As String
        <Size(20)> _
        Public Property Scheme() As String
            Get
                Return _scheme
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Scheme", _scheme, value)
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
        <Association("Scheme-Policies")> _
        Public ReadOnly Property Policies() As XPCollection(Of Policy)
            Get
                Return GetCollection(Of Policy)("Policies")
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Scheme)
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
    Public Class Policy
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
        Private fclient As Client
        <Association("Client-Policy")> _
        Public Property Client() As Client
            Get
                Return fclient
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", fclient, value)
            End Set
        End Property
        Private _scheme As Scheme
        <Association("Scheme-Policies")> _
        Public Property Scheme() As Scheme
            Get
                Return _scheme
            End Get
            Set(ByVal value As Scheme)
                SetPropertyValue(Of Scheme)("Scheme", _scheme, value)
            End Set
        End Property
        Private fPolicy As String
        <Size(10)> _
        Public Property Policy() As String
            Get
                Return fPolicy
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Policy", fPolicy, value)
            End Set
        End Property
        Private fcurrent As Boolean
        Public Property Current() As Boolean
            Get
                Return fcurrent
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Current", fcurrent, value)
            End Set
        End Property
        Private fStartDate As Date
        Public Property StartDate() As Date
            Get
                Return fStartDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("StartDate", fStartDate, value)
            End Set
        End Property
        Private fEndDate As Date
        Public Property EndDate() As Date
            Get
                Return fEndDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("EndDate", fEndDate, value)
            End Set
        End Property
        Private _reportDate As Date
        <NonPersistent()> _
        Public Property ReportDate() As Date
            Get
                Return _reportDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("ReportDate", _reportDate, value)
            End Set
        End Property
        Private _excess As Double
        Public Property Excess() As Double
            Get
                Return _excess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Excess", _excess, value)
            End Set
        End Property
        Private _dependantexcess As Double
        Public Property DependantExcess() As Double
            Get
                Return _dependantexcess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("DependantExcess", _dependantexcess, value)
            End Set
        End Property
        Private _costshare As Double
        Public Property CostSharePerc() As Double
            Get
                Return _costshare
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("CostSharePerc", _costshare, value)
            End Set
        End Property
        Private _costsharelimit As Double
        Public Property Costsharelimit() As Double
            Get
                Return _costsharelimit
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("CostSharelimit", _costsharelimit, value)
            End Set
        End Property
        Private _moratoriumdate As Date
        Public Property MoratoriumDate() As Date
            Get
                Return _moratoriumdate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("MoratoriumDate", _moratoriumdate, value)
            End Set
        End Property
        Private _moratorium As Integer
        Public Property Moratorium() As Integer
            Get
                Return _moratorium
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Moratorium", _moratorium, value)
            End Set
        End Property
        Private _budget As Double
        Public Property Budget() As Double
            Get
                Return _budget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Budget", _budget, value)
            End Set
        End Property
        <Association("Policy-BenefitLimits")> _
        Public ReadOnly Property BenefitLimits() As XPCollection(Of BenefitLimit)
            Get
                Return GetCollection(Of BenefitLimit)("BenefitLimits")
            End Get
        End Property
        <Association("Policy-Budgets")> _
        Public ReadOnly Property Budgets() As XPCollection(Of Budget)
            Get
                Return GetCollection(Of Budget)("Budgets")
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Policy)
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
    Public Class Budget
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
        Private fPolicy As Policy
        <Association("Policy-Budgets")> _
           Public Property Policy() As Policy
            Get
                Return fPolicy
            End Get
            Set(ByVal value As Policy)
                SetPropertyValue(Of Policy)("Policy", fPolicy, value)
            End Set
        End Property

        Private fPeriod As Integer
        Public Property Period() As Integer
            Get
                Return fPeriod
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Period", fPeriod, value)
            End Set
        End Property
        Private fPercentage As Double
        Public Property Percentage() As Double
            Get
                Return fPercentage
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Percentage", fPercentage, value)
            End Set
        End Property
        Private fBudget As Double
        Public Property Budget() As Double
            Get
                Return fBudget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Budget", fBudget, value)
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