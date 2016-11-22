Imports System
Imports DevExpress.Xpo
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data
    Public Class Treatment
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
            ' This constructor is used when an object is loaded from a persistent storage.
            ' Do not place any code here.			
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
                CreatedBy = ProjectCurrentUser.GetCurrentUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetCurrentUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            ' Place here your initialization code.
        End Sub
        Private fCode As String
        <Size(16)> _
        Public Property Code() As String
            Get
                Return fCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", fCode, value)
            End Set
        End Property
        Private fDescription As String
        <Size(255)> _
        Public Property Description() As String
            Get
                Return fDescription
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Narrative", fDescription, value)
            End Set
        End Property
        Private fChapter As String
        <Size(60)> _
        Public Property Chapter() As String
            Get
                Return fChapter
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Chapter", fChapter, value)
            End Set
        End Property
        Private fsubSection As String
        <Size(100)> _
        Public Property SubSection() As String
            Get
                Return fsubSection
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SubSection", fsubSection, value)
            End Set
        End Property
        Private _incurredCategory As IncurredCategory
        Public Property IncurredCategory() As IncurredCategory
            Get
                Return _incurredCategory
            End Get
            Set(ByVal value As IncurredCategory)
                SetPropertyValue(Of IncurredCategory)("IncurredCategory", _incurredCategory, value)
            End Set
        End Property
        Private _consultantCategory As Maxima
        Public Property ConsultantMaxima() As Maxima
            Get
                Return _consultantCategory
            End Get
            Set(ByVal value As Maxima)
                SetPropertyValue(Of Maxima)("ConsultantMaxima", _consultantCategory, value)
            End Set
        End Property
        Private _consultantRate As Double
        Public Property ConsultantBudget() As Double
            Get
                Return _consultantRate
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("ConsultantBudget", _consultantRate, value)
            End Set
        End Property
        Private _anaesthetistMaxima As Maxima
        Public Property AnaesthetistMaxima() As Maxima
            Get
                Return _anaesthetistMaxima
            End Get
            Set(ByVal value As Maxima)
                SetPropertyValue(Of Maxima)("AnaesthetistMaxima", _anaesthetistMaxima, value)
            End Set
        End Property
        Private _anaesthetistRate As Double
        Public Property AnaesthetistBudget() As Double
            Get
                Return _anaesthetistRate
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("AnaesthetistBudget", _anaesthetistRate, value)
            End Set
        End Property
        Private _hospitalMaxima As Maxima
        Public Property HospitalMaxima() As Maxima
            Get
                Return _hospitalMaxima
            End Get
            Set(ByVal value As Maxima)
                SetPropertyValue(Of Maxima)("HospitalMaxima", _hospitalMaxima, value)
            End Set
        End Property
        Private _hospitalRate As Double
        Public Property HospitalBudget() As Double
            Get
                Return _hospitalRate
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("HospitalBudget", _hospitalRate, value)
            End Set
        End Property
        Private _lengthofStay As String
        <Size(3)> _
        Public Property LengthOfStay() As String
            Get
                Return _lengthofStay
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LengthOfStay", _lengthofStay, value)
            End Set
        End Property
        Private _IClevel2 As Integer
        Public Property IClevel2() As Integer
            Get
                Return _IClevel2
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IClevel2", _IClevel2, value)
            End Set
        End Property
        Private _IClevel3 As Integer
        Public Property IClevel3() As Integer
            Get
                Return _IClevel3
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IClevel3", _IClevel3, value)
            End Set
        End Property
        Private _accommodationBudget As Double
        Public Property AccommodationBudget() As Double
            Get
                Return _accommodationBudget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("AccommodationBudget", _accommodationBudget, value)
            End Set
        End Property

        Private fCost As Double
        Public Property Cost() As Double
            Get
                Return fCost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Cost", fCost, value)
            End Set
        End Property
        Private _actualCost As Double
        Public Property ActualCost() As Double
            Get
                Return fCost
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Cost", fCost, value)
            End Set
        End Property
        Private fRecharge As Double
        Public Property Recharge() As Double
            Get
                Return fRecharge
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Recharge", fRecharge, value)
            End Set
        End Property
        Private fbudget As Double
        Public Property Budget() As Double
            Get
                Return fbudget
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Budget", fbudget, value)
            End Set
        End Property
        Private festimate As Double
        Public Property Estimate() As Double
            Get
                Return festimate
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Estimate", festimate, value)
            End Set
        End Property
        Private _excludefromMarkup As Boolean
        Public Property ExcludefromMarkup() As Boolean
            Get
                Return _excludefromMarkup
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ExcludefromMarkup", _excludefromMarkup, value)
            End Set
        End Property
        Private fraiseAlert As Char
        Public Property RaiseAlert() As Char
            Get
                Return fraiseAlert
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("RaiseAlert", fraiseAlert, value)
            End Set
        End Property
        <Association("Treatment-Attributes")> _
        Public ReadOnly Property Attributes() As XPCollection(Of TreatmentAttribute)
            Get
                Return GetCollection(Of TreatmentAttribute)("Attributes")
            End Get
        End Property
        Public Function GetFullDescription() As String
            Return String.Format("{0} {1}", Code, Description)
        End Function
        Private fSubAnalize As Boolean
        Public Property SubAnalize() As Boolean
            Get
                Return fSubAnalize
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("SubAnalize", fSubAnalize, value)
            End Set
        End Property

        Private fNotes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return fNotes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", fNotes, value)
            End Set
        End Property

        Private _authorisationType As eAuthorisationType
        Public Property AuthorisationType() As eAuthorisationType
            Get
                Return _authorisationType
            End Get
            Set(ByVal value As eAuthorisationType)
                SetPropertyValue(Of eAuthorisationType)("AuthorisationType", _authorisationType, value)
            End Set
        End Property
        Private fadmissionStatus As AdmissionStatus
        Public Property AdmissionStatus() As AdmissionStatus
            Get
                Return fadmissionStatus
            End Get
            Set(ByVal value As AdmissionStatus)
                SetPropertyValue(Of AdmissionStatus)("AdmissionStatus", fadmissionStatus, value)
            End Set
        End Property
        Private fHistory As String
        <Size(SizeAttribute.Unlimited)>
        Public Property History() As String
            Get
                Return fHistory
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("History", fHistory, value)
            End Set
        End Property
        Private _stNomCode1 As ExchequerLookup
        <Size(5)>
        Public Property stNomCode1() As ExchequerLookup
            Get
                Return _stNomCode1
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("stNomCode1", _stNomCode1, value)
            End Set
        End Property
        Private _stNomCode2 As ExchequerLookup
        <Size(5)>
        Public Property stNomCode2() As ExchequerLookup
            Get
                Return _stNomCode2
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("stNomCode2", _stNomCode2, value)
            End Set
        End Property
        Private _stNomCode3 As ExchequerLookup
        <Size(5)>
        Public Property stNomCode3() As ExchequerLookup
            Get
                Return _stNomCode3
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("stNomCode3", _stNomCode3, value)
            End Set
        End Property
        Private _stNomCode4 As ExchequerLookup
        <Size(5)>
        Public Property stNomCode4() As ExchequerLookup
            Get
                Return _stNomCode4
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("stNomCode4", _stNomCode4, value)
            End Set
        End Property
        Private _stNomCode5 As ExchequerLookup
        <Size(5)>
        Public Property stNomCode5() As ExchequerLookup
            Get
                Return _stNomCode5
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("stNomCode5", _stNomCode5, value)
            End Set
        End Property

        Private _HstNomCode1 As ExchequerLookup
        <Size(5)>
        Public Property HstNomCode1() As ExchequerLookup
            Get
                Return _HstNomCode1
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("HstNomCode1", _HstNomCode1, value)
            End Set
        End Property
        Private _HstNomCode2 As ExchequerLookup
        <Size(5)>
        Public Property HstNomCode2() As ExchequerLookup
            Get
                Return _HstNomCode2
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("HstNomCode2", _HstNomCode2, value)
            End Set
        End Property
        Private _HstNomCode3 As ExchequerLookup
        <Size(5)>
        Public Property HstNomCode3() As ExchequerLookup
            Get
                Return _HstNomCode3
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("HstNomCode3", _HstNomCode3, value)
            End Set
        End Property
        Private _HstNomCode4 As ExchequerLookup
        <Size(5)>
        Public Property HstNomCode4() As ExchequerLookup
            Get
                Return _HstNomCode4
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("HstNomCode4", _HstNomCode4, value)
            End Set
        End Property
        Private _HstNomCode5 As ExchequerLookup
        <Size(5)>
        Public Property HstNomCode5() As ExchequerLookup
            Get
                Return _HstNomCode5
            End Get
            Set(ByVal value As ExchequerLookup)
                SetPropertyValue(Of ExchequerLookup)("HstNomCode5", _HstNomCode5, value)
            End Set
        End Property


        Public Sub CalcBudget()
            Dim _budget As Double = ConsultantBudget
            _budget += AnaesthetistBudget
            If Object.Equals(LengthOfStay, Nothing) Then
                Return
            End If
            If LengthOfStay = "D/C" Then
                AccommodationBudget = 50
            ElseIf Microsoft.VisualBasic.IsNumeric(LengthOfStay) Then
                AccommodationBudget = 125 * CDbl(LengthOfStay)
            End If
            Budget = _budget + AccommodationBudget
        End Sub
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Code)
        End Function
        Private fcreatedBy As User
        Public Property CreatedBy() As User
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("CreatedBy", fcreatedBy, value)
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
        Private fmodifiedBy As User
        Public Property ModifiedBy() As User
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As User)
                SetPropertyValue(Of User)("ModifiedBy", fmodifiedBy, value)
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
    'Public Class SpecialPrice
    '    Inherits AuditedBase
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Public Sub New(ByVal session As Session, ByVal name As String)
    '        Me.New(session)
    '    End Sub
    '    Protected Overrides Sub OnSaving()
    '        MyBase.OnSaving()
    '        If Session.IsNewObject(Me) And CreatedBy Is Nothing Then
    '            CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '            CreatedAt = DateTime.Now
    '        End If
    '        ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
    '        ModifiedAt = DateTime.Now

    '    End Sub
    '    Private ftreatment As Treatment
    '    Public Property Treatment() As Treatment
    '        Get
    '            Return ftreatment
    '        End Get
    '        Set(ByVal value As Treatment)
    '            SetPropertyValue(Of Treatment)("Treatment", ftreatment, value)
    '        End Set
    '    End Property
    '    Private _code As String
    '    <Size(20)> _
    '    Public Property Code() As String
    '        Get
    '            Return _code
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Code", _code, value)
    '        End Set
    '    End Property
    '    Private _providerGroup As ProviderGroup
    '    Public Property ProviderGroup() As ProviderGroup
    '        Get
    '            Return _providerGroup
    '        End Get
    '        Set(ByVal value As ProviderGroup)
    '            SetPropertyValue(Of ProviderGroup)("ProviderGroup", _providerGroup, value)
    '        End Set
    '    End Property
    '    Private fCost As Double
    '    Public Property Cost() As Double
    '        Get
    '            Return fCost
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Cost", fCost, value)
    '        End Set
    '    End Property
    '    Private fRecharge As Double
    '    Public Property Recharge() As Double
    '        Get
    '            Return fRecharge
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Recharge", fRecharge, value)
    '        End Set
    '    End Property
    '    Private fNotes As String
    '    <Size(SizeAttribute.Unlimited), Delayed(True)> _
    '    Public Property Notes() As String
    '        Get
    '            Return fNotes
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Notes", fNotes, value)
    '        End Set
    '    End Property
    '    Private fcreatedBy As GlobalUser
    '    Public Property CreatedBy() As GlobalUser
    '        Get
    '            Return fcreatedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
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
    '    Private fmodifiedBy As GlobalUser
    '    Public Property ModifiedBy() As GlobalUser
    '        Get
    '            Return fmodifiedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
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
    '    Private _IsDeleted As Boolean
    '    Public Property IsDeleted() As Boolean
    '        Get
    '            Return _IsDeleted
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("IsDeleted ", _IsDeleted, value)
    '        End Set
    '    End Property
    '    Private _deletedBy As GlobalUser
    '    Public Property DeletedBy() As GlobalUser
    '        Get
    '            Return _deletedBy
    '        End Get
    '        Set(ByVal value As GlobalUser)
    '            SetPropertyValue(Of GlobalUser)("DeletedBy", _deletedBy, value)
    '        End Set
    '    End Property
    'End Class
    Public Class TreatmentAttribute
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
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            ' Place here your initialization code.
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
        Private fTreatment As Treatment
        <Association("Treatment-Attributes")> _
        Public Property Treatment() As Treatment
            Get
                Return fTreatment
            End Get
            Set(ByVal value As Treatment)
                SetPropertyValue(Of Treatment)("Treatment", fTreatment, value)
            End Set
        End Property
        Private _attribute As String
        <Size(30)> _
        Public Property Attribute() As String
            Get
                Return _attribute
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Attribute", _attribute, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Attribute)
        End Function
    End Class
    Public Class TreatmentExclusion
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
            ' This constructor is used when an object is loaded from a persistent storage.
            ' Do not place any code here.			
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
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            ' Place here your initialization code.
        End Sub
        Private fCode As String
        <Size(10)> _
        Public Property Code() As String
            Get
                Return fCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", fCode, value)
            End Set
        End Property
        Private fExcluded As String
        <Size(10)> _
        Public Property Excluded() As String
            Get
                Return fExcluded
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Excluded", fExcluded, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Code)
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
End Namespace