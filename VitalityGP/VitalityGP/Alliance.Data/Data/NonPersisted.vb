Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports Alliance.Data

Namespace Alliance.Data
    <Persistent("vw_ProviderGroup")> _
    Public Class ProviderGroup
        Inherits XPLiteObject
        <Key, Persistent> _
        Public OID As Integer
        Public ProviderGroup As String

        Public Overrides Function ToString() As String
            Return ProviderGroup
        End Function
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
    <Persistent("vw_Provider")> _
    Public Class Provider
        Inherits XPLiteObject
        <Key, Persistent> _
        Public OID As Integer
        Public ProviderType As Integer
        Public AcCode As String
        Public Provider As String
        Public Email As String
        Public PhoneNumber As String
        Public Addr1 As String
        Public Addr2 As String
        Public City As String
        Public County As String
        Public PostCode As String
        Public Status As eHospitalStatus
        Public Latitude As Double
        Public Longitude As Double
        Public ProviderGroup As Providergroup

        Public Overrides Function ToString() As String
            Dim ret As String
            If Object.Equals(Provider, Nothing) Then
                ret = String.Empty
            Else
                ret = Provider.Trim
            End If
            Dim secondTrim As String
            If Object.Equals(City, Nothing) Then
                secondTrim = String.Empty
            Else
                secondTrim = City.Trim
            End If
            If secondTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & secondTrim
                Else
                    ret &= (", ") & secondTrim
                End If
            End If
            Dim thirdTrim As String
            If Object.Equals(PostCode, Nothing) Then
                thirdTrim = String.Empty
            Else
                thirdTrim = PostCode.Trim
            End If
            If thirdTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & thirdTrim
                Else
                    ret &= (", ") & thirdTrim
                End If
            End If
            Dim fourthTrim As String
            If Object.Equals(AcCode, Nothing) Then
                fourthTrim = String.Empty
            Else
                fourthTrim = AcCode.Trim
            End If
            If fourthTrim.Length <> 0 Then
                If ret.Length = 0 Then
                    ret &= (String.Empty) & fourthTrim
                Else
                    ret &= (", ") & fourthTrim
                End If
            End If

            Return ret
        End Function
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class

    <Persistent("vw_Beneficiary")> _
    Public Class BeneficiaryView
        Inherits XPLiteObject
        <Key, Persistent> _
        Public OID As Integer
        Public Client As String
        Public FullName As String
        Public Gender As String
        Public Vip As String
        Public Student As String
        Public Deceased As String
        Public BusinessUnit As String
        Public NINumber As String
        Public Position As String
        Public Band As String
        Public DOB As String
        Public JoinDate As Date
        Public LeaveDate As Date
        Public Email As String
        Public WorkPhone As String
        Public HomePhone As String
        Public MobilePhone As String
        Public EmployeeNo As String
        Public FamilyGroup As String
        Public ReportingDivision As String
        Public Division As String
        Public RelationShip As String
        Public LevelofCover As String
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
    <Persistent("vw_InvoiceDetail")> _
    Public Class vw_InvoiceDetail
        Inherits XPLiteObject
        <Key, Persistent> _
        Public InvoiceDetailID As Integer
        Public InvoiceID As Integer
        Public Beneficiary As Integer
        Public BenefitID As Integer
        Public Benefit As String
        Public BenefitDetailID As Integer
        Public BenefitDetail As String
        Public InvoiceDate As Date
        Public InvoiceNo As String
        Public Code As String
        Public Description As String
        Public TreatmentDate As Date
        Public PaymentQty As Double
        Public PaymentTotal As Double
        Public Limit As Double
        Public LimitClaimed As Double
        Public Remainder As Double
        Public Incidents As Double
        Public IncidentsClaimed As Double
        <NoForeignKey()>
        Public ProviderOid As Provider
        Public TreatmentOid As Treatment
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
    <NonPersistent()> _
    Public Class BenefitSummary
        Inherits XPObject
        Public Client As Client
        Public Division As Division
        Public ReportingDivision As ReportingDivision
        Public Beneficiary As Beneficiary
        Public BenefitLimit As Integer
        Public Benefit As Integer
        Public BenefitDetail As Integer
        Public IncurredQty As Double
        Public IncurredTotal As Double
        Public Limit As Double

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
    <Persistent("vw_AwaitingPayment")> _
    Public Class AwaitingPayment
        Inherits XPLiteObject
        <Key, Persistent> _
        Public OID As Integer
        Public Client As Integer
        Public ClientType As Integer
        Public AcCode As String
        Public Provider As String
        Public InvoiceType As String
        Public InvoiceStatus As Integer
        Public Source As String
        Public [Date] As Date
        Public Reference As String
        Public InvoiceTotal As Double
        Public PaymentTotal As Double
        Public RechargeTotal As Double
        Public IncurredTotal As Double
        Public Excess As Double
        Public Beneficiary As String
        Public VIP As String
        Public Deceased As String
        Public LeaveDate As Date
        Public SIN As String
        Public PIN As String
        Public DueDate As Date
        Public Days As Integer
        Public DaysTillDue As Integer
        Public Paid As Boolean

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
    <Persistent("vw_IncurredCosts")> _
    Public Class vw_IncurredCost
        Inherits XPLiteObject
        <Key, Persistent> _
        Public OID As Integer
        Public Source As String
        Public Client As String
        Public FullName As String
        Public Provider As String
        Public InvoiceType As String
        Public Reference As String
        Public Package As Boolean
        Public [Date] As Date
        Public Code As String
        Public Description As String
        Public TreatmentDate As Date
        Public AdmissionStatus As String
        Public IncurredTotal As Double
        Public IncurredQty As Double
        Public UnitCost As Double
        Public PaymentDate As Date
        Public LengthOfStay As String
        Public VIP As String
        '        Public Age As Integer
        '       Public Deceased As String
        Public LeaveDate As Date?
        Public Claim As Claim
        Public Invoice As Invoice
        Public DPAClaim As String
        Public DPA As String
        Public SIN As String
        Public InvoiceStatus As eInvoiceStatus
        Public TransferNumber As Integer
        Public Division As String
        Public ReportingDivision As String
        Public Benefit As String
        Public BenefitDetail As String
        Public DOB As Date
        Public JoinDate As Date
        Public Position As String
        Public Student As String
        Public Gender As String
        Public AuthorisationDate As Date
        Public Symptom As String
        Public Band As String
        Public RelationShip As String
        Public RelationShipGroup As String
        Public AffectedSystem As String
        Public LevelofCover As String
        Public BusinessUnit As String
        Public Policy As String
        Public DivisionOid As Division
        Public ReportingDivisionOid As ReportingDivision
        Public AcCode As String
        Public ProviderGroup As String
        Public ProviderType As String
        Public Dependant As Integer
        Public IncurredCategory As String
        Public AuthorisationNo As String
        Public AuthorisationID As Integer
        Public Diverted As Boolean
        Public AuthorisationType As String
        Public OutOfNetWork As Boolean

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
    <Persistent("vw_GenderMatch")> _
    Public Class GenderMatch
        Inherits XPLiteObject
        <Key, Persistent> _
        Public FirstName As String
        Public Gender As String
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
    <Persistent("vw_CITClaims")>
    Public Class CITClaim
        Inherits XPLiteObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _Authorisation As Integer
        <Key>
        Public Property Authorisation() As Integer
            Get
                Return _Authorisation
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Authorisation", _Authorisation, value)
            End Set
        End Property
        Public OID As Integer
        Public CITType As eCITType
        Public CITStage As eCITStage
        Public AuthorisationNo As String
        Public ResponseDue As DateTime
        Public Responded As DateTime
        Public ReplyDue As DateTime
        Public Replied As DateTime
        Public OutCome As eCITOutCome
        Public CreatedBy As String
        Public CreatedAt As DateTime
        Public Consultant As String
        Public Beneficiary As String
        Public Client As String
        Public ShortName As String
    End Class
    <Persistent("vw_Claim")>
    Public Class vw_Claim
        Inherits XPLiteObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        <Key, Persistent> _
        Public OID As Integer
        Public Client As String
        Public ClientOid As Integer
        Public Division As String
        Public ReportingDivision As String
        Public RelationShip As String
        Public RelationShipGroup As String
        Public LevelofCover As String
        Public AffectedSystem As String
        Public Vip As String
        Public PostCode As String
        Public FullName As String
        Public LeaveDate As Date
        Public Gender As String
        Public DOB As Date
        Public FirstName As String
        Public SurName As String
        Public Title As String
        Public Addr1 As String
        Public Addr2 As String
        Public City As String
        Public County As String
        Public Email As String
        Public WorkPhone As String
        Public MobilePhone As String
        Public Symptom As String
        Public ClaimDate As Date
        Public Status As String
        Public FirstSymptomDate As Date
        Public FirstConsultationDate As Date
        Public LastConsultationDate As Date
        Public StatusOID As String
        Public GPformsreceived As Date
        Public ClaimClosed As Boolean
        Public ClaimReOpened As Boolean
        Public ClaimCloseReason As String
        Public BusinessUnit As String
        Public SymptomOID As Integer
        Public GPOID As Integer
        Public PracticeOID As Integer
        Public HospitalOid As Integer
        Public ConsultantOID As Integer
        Public DivisionOid As Integer
        Public ReportingDivisionOid As Integer
        <Size(SizeAttribute.Unlimited)> _
        Public TriageNotes As String
    End Class
    Public Class TempPaymentItems
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _client As Client
        Public Property Client() As Client
            Get
                Return _client
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", _client, value)
            End Set
        End Property
        Private _Invoice As Invoice
        Public Property Invoice() As Invoice
            Get
                Return _Invoice
            End Get
            Set(ByVal value As Invoice)
                SetPropertyValue(Of Invoice)("Invoice", _Invoice, value)
            End Set
        End Property
        Private _Incurred As Double
        Public Property Incurred() As Double
            Get
                Return _Incurred
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Incurred", _Incurred, value)
            End Set
        End Property
    End Class
    '
End Namespace