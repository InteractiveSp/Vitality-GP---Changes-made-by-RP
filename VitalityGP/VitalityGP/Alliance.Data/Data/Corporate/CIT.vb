Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data
    Public Class CITBreast
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
                CITType = eCITType.Breast
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _authorisation As Authorisation
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _CITType As eCITType
        Public Property CITType() As eCITType
            Get
                Return _CITType
            End Get
            Set(ByVal value As eCITType)
                SetPropertyValue(Of eCITType)("CITType", _CITType, value)
            End Set
        End Property
        Private _CITStage As eCITStage
        Public Property CITStage() As eCITStage
            Get
                Return _CITStage
            End Get
            Set(ByVal value As eCITStage)
                SetPropertyValue(Of eCITStage)("CITStage", _CITStage, value)
            End Set
        End Property
        Private _lump As String
        <Size(3)> _
        Public Property Lump() As String
            Get
                Return _lump
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Lump", _lump, value)
            End Set
        End Property
        Private _pain As String
        <Size(3)> _
        Public Property Pain() As String
            Get
                Return _pain
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Pain", _pain, value)
            End Set
        End Property
        Private _nippledischarge As String
        <Size(3)> _
        Public Property Nippledischarge() As String
            Get
                Return _nippledischarge
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Nippledischarge", _nippledischarge, value)
            End Set
        End Property
        Private _changeinshape As String
        <Size(3)> _
        Public Property ChangeInShape() As String
            Get
                Return _changeinshape
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ChangeInShape", _changeinshape, value)
            End Set
        End Property
        Private _skinTethering As String
        <Size(3)> _
        Public Property SkinTethering() As String
            Get
                Return _skinTethering
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SkinTethering", _skinTethering, value)
            End Set
        End Property
        Private _LengthofSymptoms As String
        <Size(15)> _
        Public Property WhenStarted() As String
            Get
                Return _LengthofSymptoms
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LengthofSymptoms", _LengthofSymptoms, value)
            End Set
        End Property
        Private _HistoryofBreastCancer As String
        <Size(3)> _
        Public Property HistoryofBreastCancer() As String
            Get
                Return _HistoryofBreastCancer
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HistoryofBreastCancer", _HistoryofBreastCancer, value)
            End Set
        End Property
        Private _LastMammogram As String
        <Size(15)> _
        Public Property LastMammogram() As String
            Get
                Return _LastMammogram
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LastMammogram", _LastMammogram, value)
            End Set
        End Property
        Private _clinicvisited As String
        Public Property VisitedClinic() As String
            Get
                Return _clinicvisited
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ClinicVisited", _clinicvisited, value)
            End Set
        End Property
        Private _clinicname As String
        <Size(30)> _
        Public Property ClinicName() As String
            Get
                Return _clinicname
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ClinicName", _clinicname, value)
            End Set
        End Property
        Private _ClinicVisitDate As String
        <Size(30)> _
        Public Property ClinicVisitDate() As String
            Get
                Return _ClinicVisitDate
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ClinicVisitDate ", _ClinicVisitDate, value)
            End Set
        End Property
        Private _clinicoutcome As String
        <Size(50)> _
        Public Property ClinicOutCome() As String
            Get
                Return _clinicoutcome
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ClinicOutCome", _clinicoutcome, value)
            End Set
        End Property
        Private _previousSurgery As String
        Public Property PreviousSurgery() As String
            Get
                Return _previousSurgery
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PreviousSurgery", _previousSurgery, value)
            End Set
        End Property
        Private _generalHealthProblems As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property GeneralHealthProblems() As String
            Get
                Return _generalHealthProblems
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GeneralHealthProblems", _generalHealthProblems, value)
            End Set
        End Property
        Private _allergies As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Allergies() As String
            Get
                Return _allergies
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Allergies", _allergies, value)
            End Set
        End Property
        Private _xrayLocation As String
        <Size(50)> _
        Public Property XrayLocation() As String
            Get
                Return _xrayLocation
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("XrayLocation", _xrayLocation, value)
            End Set
        End Property
        Private _xRayWhen As String
        <Size(20)> _
        Public Property xRayDate() As String
            Get
                Return _xRayWhen
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("xRayDate", _xRayWhen, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
            End Set
        End Property
        Private _responsedue As DateTime
        Public Property ResponseDue() As DateTime
            Get
                Return _responsedue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ResponseDue", _responsedue, value)
            End Set
        End Property
        Private _responded As DateTime
        Public Property Responded() As DateTime
            Get
                Return _responded
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Responded", _responded, value)
            End Set
        End Property
        Private _replydue As DateTime
        Public Property ReplyDue() As DateTime
            Get
                Return _replydue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ReplyDue", _replydue, value)
            End Set
        End Property
        Private _replied As DateTime
        Public Property Replied() As DateTime
            Get
                Return _replied
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Replied", _replied, value)
            End Set
        End Property
        Private _outcome As eCITOutCome
        Public Property OutCome() As eCITOutCome
            Get
                Return _outcome
            End Get
            Set(ByVal value As eCITOutCome)
                SetPropertyValue(Of eCITOutCome)("OutCome", _outcome, value)
            End Set
        End Property
        Private _reply As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Reply() As String
            Get
                Return _reply
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reply", _reply, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("CIT BreastLump {0}", Oid)
        End Function
    End Class
    Public Class CITCardiology
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
                CITType = eCITType.Cardiology
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _authorisation As Authorisation
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _CITType As eCITType
        Public Property CITType() As eCITType
            Get
                Return _CITType
            End Get
            Set(ByVal value As eCITType)
                SetPropertyValue(Of eCITType)("CITType", _CITType, value)
            End Set
        End Property
        Private _CITStage As eCITStage
        Public Property CITStage() As eCITStage
            Get
                Return _CITStage
            End Get
            Set(ByVal value As eCITStage)
                SetPropertyValue(Of eCITStage)("CITStage", _CITStage, value)
            End Set
        End Property
        Private _ChestPain As String
        <Size(3)> _
        Public Property ChestPain() As String
            Get
                Return _ChestPain
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ChestPain", _ChestPain, value)
            End Set
        End Property
        Private _chestPainTime As String
        <Size(30)> _
        Public Property ChestPainTime() As String
            Get
                Return _chestPainTime
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ChestPainTime", _chestPainTime, value)
            End Set
        End Property
        Private _DescriptionofPain As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property DescriptionOfPain() As String
            Get
                Return _DescriptionofPain
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DescriptionOfPain", _DescriptionofPain, value)
            End Set
        End Property
        Private _Breathlessness As String
        <Size(3)> _
        Public Property Breathlessness() As String
            Get
                Return _Breathlessness
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Breathlessness", _Breathlessness, value)
            End Set
        End Property
        Private _ECG As String
        <Size(3)> _
        Public Property ECG() As String
            Get
                Return _ECG
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ECG", _ECG, value)
            End Set
        End Property
        Private _bloodTest As String
        <Size(3)> _
        Public Property BloodTest() As String
            Get
                Return _bloodTest
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BloodTest", _bloodTest, value)
            End Set
        End Property
        Private _EchoCardiogram As String
        <Size(3)> _
        Public Property EchoCardiogram() As String
            Get
                Return _EchoCardiogram
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("_EchoCardiogram", _EchoCardiogram, value)
            End Set
        End Property
        Private _testsLocation As String
        <Size(30)> _
        Public Property TestsLocation() As String
            Get
                Return _testsLocation
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TestsLocation", _testsLocation, value)
            End Set
        End Property
        Private _responsedue As DateTime
        Public Property ResponseDue() As DateTime
            Get
                Return _responsedue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ResponseDue", _responsedue, value)
            End Set
        End Property
        Private _responded As DateTime
        Public Property Responded() As DateTime
            Get
                Return _responded
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Responded", _responded, value)
            End Set
        End Property
        Private _replydue As DateTime
        Public Property ReplyDue() As DateTime
            Get
                Return _replydue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ReplyDue", _replydue, value)
            End Set
        End Property
        Private _replied As DateTime
        Public Property Replied() As DateTime
            Get
                Return _replied
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Replied", _replied, value)
            End Set
        End Property
        Private _outcome As eCITOutCome
        Public Property OutCome() As eCITOutCome
            Get
                Return _outcome
            End Get
            Set(ByVal value As eCITOutCome)
                SetPropertyValue(Of eCITOutCome)("OutCome", _outcome, value)
            End Set
        End Property
        Private _reply As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Reply() As String
            Get
                Return _reply
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reply", _reply, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("CIT Cardiology {0}", Oid)
        End Function
    End Class
    Public Class CITGastroenterology
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
                CITType = eCITType.Gastroenterology
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _authorisation As Authorisation
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _CITType As eCITType
        Public Property CITType() As eCITType
            Get
                Return _CITType
            End Get
            Set(ByVal value As eCITType)
                SetPropertyValue(Of eCITType)("CITType", _CITType, value)
            End Set
        End Property
        Private _CITStage As eCITStage
        Public Property CITStage() As eCITStage
            Get
                Return _CITStage
            End Get
            Set(ByVal value As eCITStage)
                SetPropertyValue(Of eCITStage)("CITStage", _CITStage, value)
            End Set
        End Property
        Private _abdominalPain As String
        <Size(3)> _
        Public Property AbdominalPain() As String
            Get
                Return _abdominalPain
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AbdominalPain", _abdominalPain, value)
            End Set
        End Property
        Private _sidePainLocation As String
        <Size(10)> _
        Public Property SidePainLocation() As String
            Get
                Return _sidePainLocation
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SidePainLocation", _sidePainLocation, value)
            End Set
        End Property
        Private _sidePainTime As String
        <Size(30)> _
        Public Property SidePainTime() As String
            Get
                Return _sidePainTime
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SidePainTime", _sidePainTime, value)
            End Set
        End Property
        Private _abdominalPainLocation As String
        <Size(10)> _
        Public Property AbdominalPainLocation() As String
            Get
                Return _abdominalPainLocation
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AbdominalPainLocation", _abdominalPainLocation, value)
            End Set
        End Property
        Private _painDescription As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property PainDescription() As String
            Get
                Return _painDescription
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PainDescription", _painDescription, value)
            End Set
        End Property
        Private _nausea As String
        <Size(3)> _
        Public Property Nausea() As String
            Get
                Return _nausea
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Nausea", _nausea, value)
            End Set
        End Property
        Private _sickness As String
        <Size(3)> _
        Public Property Sickness() As String
            Get
                Return _sickness
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Sickness", _sickness, value)
            End Set
        End Property
        Private _diarrhoea As String
        <Size(3)> _
        Public Property Diarrhoea() As String
            Get
                Return _diarrhoea
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Diarrhoea", _diarrhoea, value)
            End Set
        End Property
        Private _bloodinstools As String
        <Size(3)> _
        Public Property BloodInStools() As String
            Get
                Return _bloodinstools
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BloodInStools", _bloodinstools, value)
            End Set
        End Property
        Private _rectalbleeding As String
        <Size(3)> _
        Public Property Rectalbleeding() As String
            Get
                Return _rectalbleeding
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Rectalbleeding", _rectalbleeding, value)
            End Set
        End Property
        Private _bloodTests As String
        <Size(3)> _
        Public Property BloodTests() As String
            Get
                Return _bloodTests
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BloodTests", _bloodTests, value)
            End Set
        End Property
        Private _scans As String
        <Size(3)> _
        Public Property Scans() As String
            Get
                Return _scans
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Scans", _scans, value)
            End Set
        End Property
        Private _testLocation As String
        <Size(30)> _
        Public Property TestLocation() As String
            Get
                Return _testLocation
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TestLocation", _testLocation, value)
            End Set
        End Property
        Private _responsedue As DateTime
        Public Property ResponseDue() As DateTime
            Get
                Return _responsedue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ResponseDue", _responsedue, value)
            End Set
        End Property
        Private _responded As DateTime
        Public Property Responded() As DateTime
            Get
                Return _responded
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Responded", _responded, value)
            End Set
        End Property
        Private _replydue As DateTime
        Public Property ReplyDue() As DateTime
            Get
                Return _replydue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ReplyDue", _replydue, value)
            End Set
        End Property
        Private _replied As DateTime
        Public Property Replied() As DateTime
            Get
                Return _replied
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Replied", _replied, value)
            End Set
        End Property
        Private _outcome As eCITOutCome
        Public Property OutCome() As eCITOutCome
            Get
                Return _outcome
            End Get
            Set(ByVal value As eCITOutCome)
                SetPropertyValue(Of eCITOutCome)("OutCome", _outcome, value)
            End Set
        End Property
        Private _reply As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Reply() As String
            Get
                Return _reply
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reply", _reply, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("CIT Gastroenterology {0}", Oid)
        End Function
    End Class
    Public Class CITMentalHealth
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
                CITType = eCITType.MentalHealth
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _authorisation As Authorisation
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _CITType As eCITType
        Public Property CITType() As eCITType
            Get
                Return _CITType
            End Get
            Set(ByVal value As eCITType)
                SetPropertyValue(Of eCITType)("CITType", _CITType, value)
            End Set
        End Property
        Private _CITStage As eCITStage
        Public Property CITStage() As eCITStage
            Get
                Return _CITStage
            End Get
            Set(ByVal value As eCITStage)
                SetPropertyValue(Of eCITStage)("CITStage", _CITStage, value)
            End Set
        End Property
        Private _Symptoms As String
        <Size(SizeAttribute.Unlimited)> _
       Public Property Symptoms() As String
            Get
                Return _Symptoms
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Symptoms", _Symptoms, value)
            End Set
        End Property
        Private _symptomsWorsened As String
        <Size(3)> _
        Public Property SymptomsWorsened() As String
            Get
                Return _symptomsWorsened
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SymptomsWorsened", _symptomsWorsened, value)
            End Set
        End Property
        Private _lowPoint As String
        <Size(3)> _
        Public Property LowPoint() As String
            Get
                Return _lowPoint
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LowPoint", _lowPoint, value)
            End Set
        End Property
        Private _triedSucide As String
        <Size(3)> _
        Public Property TriedSucide() As String
            Get
                Return _triedSucide
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TriedSucide", _triedSucide, value)
            End Set
        End Property
        Private _hadCounselling As String
        <Size(3)> _
        Public Property HadCounselling() As String
            Get
                Return _hadCounselling
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HadCounselling", _hadCounselling, value)
            End Set
        End Property
        Private _hadCBT As String
        <Size(3)> _
        Public Property HadCBT() As String
            Get
                Return _hadCBT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HadCBT", _hadCBT, value)
            End Set
        End Property
        Private _seenpsychiatrist As String
        <Size(3)> _
        Public Property SeenPsychiatrist() As String
            Get
                Return _seenpsychiatrist
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SeenPsychiatrist", _seenpsychiatrist, value)
            End Set
        End Property
        Private _takingmedication As String
        <Size(3)> _
        Public Property TakingMedication() As String
            Get
                Return _takingmedication
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TakingMedication", _takingmedication, value)
            End Set
        End Property
        Private _prescribedby As String
        <Size(50)> _
        Public Property PrescribedBy() As String
            Get
                Return _prescribedby
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PrescribedBy", _prescribedby, value)
            End Set
        End Property
        Private _medication As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Medication() As String
            Get
                Return _medication
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Medication", _medication, value)
            End Set
        End Property
        Private _wantsCounselling As String
        <Size(3)> _
        Public Property WantsCounselling() As String
            Get
                Return _wantsCounselling
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WantsCounselling", _wantsCounselling, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
            End Set
        End Property
        Private _responsedue As DateTime
        Public Property ResponseDue() As DateTime
            Get
                Return _responsedue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ResponseDue", _responsedue, value)
            End Set
        End Property
        Private _responded As DateTime
        Public Property Responded() As DateTime
            Get
                Return _responded
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Responded", _responded, value)
            End Set
        End Property
        Private _replydue As DateTime
        Public Property ReplyDue() As DateTime
            Get
                Return _replydue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ReplyDue", _replydue, value)
            End Set
        End Property
        Private _replied As DateTime
        Public Property Replied() As DateTime
            Get
                Return _replied
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Replied", _replied, value)
            End Set
        End Property
        Private _outcome As eCITOutCome
        Public Property OutCome() As eCITOutCome
            Get
                Return _outcome
            End Get
            Set(ByVal value As eCITOutCome)
                SetPropertyValue(Of eCITOutCome)("OutCome", _outcome, value)
            End Set
        End Property
        Private _reply As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Reply() As String
            Get
                Return _reply
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reply", _reply, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("CIT BreastLump {0}", Oid)
        End Function
    End Class
    Public Class CITMSKHip
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
                CITType = eCITType.MSKHip
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _authorisation As Authorisation
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _CITType As eCITType
        Public Property CITType() As eCITType
            Get
                Return _CITType
            End Get
            Set(ByVal value As eCITType)
                SetPropertyValue(Of eCITType)("CITType", _CITType, value)
            End Set
        End Property
        Private _CITStage As eCITStage
        Public Property CITStage() As eCITStage
            Get
                Return _CITStage
            End Get
            Set(ByVal value As eCITStage)
                SetPropertyValue(Of eCITStage)("CITStage", _CITStage, value)
            End Set
        End Property
        Private _whichHip As String
        <Size(4)> _
        Public Property WhichHip() As String
            Get
                Return _whichHip
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WhichHip", _whichHip, value)
            End Set
        End Property
        Private _dateStarted As String
        <Size(20)> _
        Public Property DateStarted() As String
            Get
                Return _dateStarted
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DateStarted", _dateStarted, value)
            End Set
        End Property
        Private _groinPain As String
        <Size(3)> _
        Public Property GroinPain() As String
            Get
                Return _groinPain
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GroinPain", _groinPain, value)
            End Set
        End Property
        Private _painBelowKnee As String
        <Size(3)> _
        Public Property PainBelowKnee() As String
            Get
                Return _painBelowKnee
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PainBelowKnee", _painBelowKnee, value)
            End Set
        End Property
        Private _towardsKnee As String
        <Size(3)> _
        Public Property TowardsKnee() As String
            Get
                Return _towardsKnee
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TowardsKnee", _towardsKnee, value)
            End Set
        End Property
        Private _belowKnee As String
        <Size(3)> _
        Public Property BelowKnee() As String
            Get
                Return _belowKnee
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BelowKnee", _belowKnee, value)
            End Set
        End Property
        Private _troubleWithSocks As String
        <Size(3)> _
        Public Property TroubleWithSocks() As String
            Get
                Return _troubleWithSocks
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TroubleWithSocks", _troubleWithSocks, value)
            End Set
        End Property
        Private _walkingTime As String
        <Size(15)> _
        Public Property WalkingTime() As String
            Get
                Return _walkingTime
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WalkingTime", _walkingTime, value)
            End Set
        End Property
        Private _usesStick As String
        <Size(3)> _
        Public Property UsesStick() As String
            Get
                Return _usesStick
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UsesStick", _usesStick, value)
            End Set
        End Property
        Private _problemWithStairs As String
        <Size(3)> _
        Public Property ProblemWithStairs() As String
            Get
                Return _problemWithStairs
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ProblemWithStairs", _problemWithStairs, value)
            End Set
        End Property
        Private _experiencesBackPain As String
        <Size(3)> _
        Public Property ExperiencesBackPain() As String
            Get
                Return _experiencesBackPain
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ExperiencesBackPain", _experiencesBackPain, value)
            End Set
        End Property
        Private _responsedue As DateTime
        Public Property ResponseDue() As DateTime
            Get
                Return _responsedue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ResponseDue", _responsedue, value)
            End Set
        End Property
        Private _responded As DateTime
        Public Property Responded() As DateTime
            Get
                Return _responded
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Responded", _responded, value)
            End Set
        End Property
        Private _replydue As DateTime
        Public Property ReplyDue() As DateTime
            Get
                Return _replydue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ReplyDue", _replydue, value)
            End Set
        End Property
        Private _replied As DateTime
        Public Property Replied() As DateTime
            Get
                Return _replied
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Replied", _replied, value)
            End Set
        End Property
        Private _outcome As eCITOutCome
        Public Property OutCome() As eCITOutCome
            Get
                Return _outcome
            End Get
            Set(ByVal value As eCITOutCome)
                SetPropertyValue(Of eCITOutCome)("OutCome", _outcome, value)
            End Set
        End Property
        Private _reply As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Reply() As String
            Get
                Return _reply
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reply", _reply, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("CIT Musculoskeletal Hip {0}", Oid)
        End Function
    End Class
    Public Class CITMSKGeneral
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
                CITType = eCITType.MSKGeneral
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
       
        Private _authorisation As Authorisation
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _CITType As eCITType
        Public Property CITType() As eCITType
            Get
                Return _CITType
            End Get
            Set(ByVal value As eCITType)
                SetPropertyValue(Of eCITType)("CITType", _CITType, value)
            End Set
        End Property
        Private _CITStage As eCITStage
        Public Property CITStage() As eCITStage
            Get
                Return _CITStage
            End Get
            Set(ByVal value As eCITStage)
                SetPropertyValue(Of eCITStage)("CITStage", _CITStage, value)
            End Set
        End Property
        Private _effectedArea As String
        <Size(8)> _
        Public Property EffectedArea() As String
            Get
                Return _effectedArea
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EffectedArea", _effectedArea, value)
            End Set
        End Property
        Private _painLength As String
        <Size(20)> _
        Public Property PainLength() As String
            Get
                Return _painLength
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PainLength", _painLength, value)
            End Set
        End Property
        Private _DescriptionofPain As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property DescriptionOfPain() As String
            Get
                Return _DescriptionofPain
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DescriptionOfPain", _DescriptionofPain, value)
            End Set
        End Property
        Private _paintravel As String
        <Size(10)> _
        Public Property Paintravel() As String
            Get
                Return _paintravel
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Paintravel", _paintravel, value)
            End Set
        End Property
        Private _recentScans As String
        <Size(3)> _
        Public Property RecentScans() As String
            Get
                Return _recentScans
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RecentScans", _recentScans, value)
            End Set
        End Property
        Private _recentScanLocation As String
        <Size(30)> _
        Public Property RecentScanLocation() As String
            Get
                Return _recentScanLocation
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RecentScanLocation", _recentScanLocation, value)
            End Set
        End Property
        Private _recentTreatment As String
        <Size(3)> _
        Public Property RecentTreatment() As String
            Get
                Return _recentTreatment
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RecentTreatment", _recentTreatment, value)
            End Set
        End Property
        Private _recentTreatmentLocation As String
        <Size(30)> _
        Public Property RecentTreatmentLocation() As String
            Get
                Return _recentTreatmentLocation
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RecentTestLocation", _recentTreatmentLocation, value)
            End Set
        End Property
        Private _responsedue As DateTime
        Public Property ResponseDue() As DateTime
            Get
                Return _responsedue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ResponseDue", _responsedue, value)
            End Set
        End Property
        Private _responded As DateTime
        Public Property Responded() As DateTime
            Get
                Return _responded
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Responded", _responded, value)
            End Set
        End Property
        Private _replydue As DateTime
        Public Property ReplyDue() As DateTime
            Get
                Return _replydue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ReplyDue", _replydue, value)
            End Set
        End Property
        Private _replied As DateTime
        Public Property Replied() As DateTime
            Get
                Return _replied
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Replied", _replied, value)
            End Set
        End Property
        Private _outcome As eCITOutCome
        Public Property OutCome() As eCITOutCome
            Get
                Return _outcome
            End Get
            Set(ByVal value As eCITOutCome)
                SetPropertyValue(Of eCITOutCome)("OutCome", _outcome, value)
            End Set
        End Property
        Private _reply As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Reply() As String
            Get
                Return _reply
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reply", _reply, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("CIT Musculoskeletal Hip {0}", Oid)
        End Function
    End Class
    Public Class CITMSKKnee
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
                CITType = eCITType.MSKKnee
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now
        End Sub
        Private _authorisation As Authorisation
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _CITType As eCITType
        Public Property CITType() As eCITType
            Get
                Return _CITType
            End Get
            Set(ByVal value As eCITType)
                SetPropertyValue(Of eCITType)("CITType", _CITType, value)
            End Set
        End Property
        Private _CITStage As eCITStage
        Public Property CITStage() As eCITStage
            Get
                Return _CITStage
            End Get
            Set(ByVal value As eCITStage)
                SetPropertyValue(Of eCITStage)("CITStage", _CITStage, value)
            End Set
        End Property
        Private _whichKnee As String
        <Size(5)> _
        Public Property WhichKnee() As String
            Get
                Return _whichKnee
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WhichKnee", _whichKnee, value)
            End Set
        End Property
        Private _whenStarted As String
        <Size(20)> _
        Public Property DateStarted() As String
            Get
                Return _whenStarted
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WhenStarted", _whenStarted, value)
            End Set
        End Property
        Private _AllOver As String
        <Size(3)> _
        Public Property AllOver() As String
            Get
                Return _AllOver
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AllOver", _AllOver, value)
            End Set
        End Property
        Private _OutSide As String
        <Size(3)> _
        Public Property OutSide() As String
            Get
                Return _OutSide
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("OutSide", _OutSide, value)
            End Set
        End Property
        Private _inside As String
        <Size(3)> _
        Public Property InSide() As String
            Get
                Return _inside
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InSide", _inside, value)
            End Set
        End Property
        Private _underKnee As String
        <Size(3)> _
        Public Property UnderKnee() As String
            Get
                Return _underKnee
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UnderKnee", _underKnee, value)
            End Set
        End Property
        Private _specificInjury As String
        <Size(3)> _
        Public Property SpecificInjury() As String
            Get
                Return _specificInjury
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SpecificInjury", _specificInjury, value)
            End Set
        End Property
        Private _injuryOccured As String
        <Size(20)> _
        Public Property InjuryOccured() As String
            Get
                Return _injuryOccured
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InjuryOccured", _injuryOccured, value)
            End Set
        End Property
        Private _WalkingTime As String
        <Size(3)> _
        Public Property WalkingTime() As String
            Get
                Return _WalkingTime
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WalkingTime", _WalkingTime, value)
            End Set
        End Property
        Private _usesStick As String
        <Size(3)> _
        Public Property UsesStick() As String
            Get
                Return _usesStick
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UsesStick", _usesStick, value)
            End Set
        End Property
        Private _problemWithStairs As String
        <Size(3)> _
        Public Property ProblemWithStairs() As String
            Get
                Return _problemWithStairs
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ProblemWithStairs", _problemWithStairs, value)
            End Set
        End Property
        Private _betterWalking As String
        <Size(8)> _
        Public Property BetterWalking() As String
            Get
                Return _betterWalking
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BetterWalking", _betterWalking, value)
            End Set
        End Property
        Private _groinPain As String
        <Size(3)> _
        Public Property GroinPain() As String
            Get
                Return _groinPain
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GroinPain", _groinPain, value)
            End Set
        End Property
        Private _belowKnee As String
        <Size(3)> _
        Public Property BelowKnee() As String
            Get
                Return _belowKnee
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BelowKnee", _belowKnee, value)
            End Set
        End Property
        Private _troubleWithSocks As String
        <Size(3)> _
        Public Property TroubleWithSocks() As String
            Get
                Return _troubleWithSocks
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TroubleWithSocks", _troubleWithSocks, value)
            End Set
        End Property

        Private _experiencesBackPain As String
        <Size(3)> _
        Public Property ExperiencesBackPain() As String
            Get
                Return _experiencesBackPain
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ExperiencesBackPain", _experiencesBackPain, value)
            End Set
        End Property
        Private _Twisted As String
        <Size(3)> _
        Public Property Twisted() As String
            Get
                Return _Twisted
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Twisted", _Twisted, value)
            End Set
        End Property
        Private _collision As String
        <Size(3)> _
        Public Property Collision() As String
            Get
                Return _collision
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Collision", _collision, value)
            End Set
        End Property
        Private _fall As String
        <Size(3)> _
        Public Property Fall() As String
            Get
                Return _fall
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Fall", _fall, value)
            End Set
        End Property
        Private _trip As String
        <Size(3)> _
        Public Property Tripped() As String
            Get
                Return _trip
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Trip", _trip, value)
            End Set
        End Property
        Private _popOrSnapped As String
        <Size(3)> _
        Public Property PopOrSnapped() As String
            Get
                Return _popOrSnapped
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PopOrSnapped", _popOrSnapped, value)
            End Set
        End Property
        Private _swelledUp As String
        <Size(3)> _
        Public Property SwelledUp() As String
            Get
                Return _swelledUp
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SwelledUp", _swelledUp, value)
            End Set
        End Property
        Private _locks As String
        <Size(3)> _
        Public Property Locks() As String
            Get
                Return _locks
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Locks", _locks, value)
            End Set
        End Property
        Private _givesway As String
        <Size(3)> _
        Public Property Givesway() As String
            Get
                Return _givesway
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Givesway", _givesway, value)
            End Set
        End Property
        Private _ableToPlaySports As String
        <Size(3)> _
        Public Property AbleToPlaySports() As String
            Get
                Return _ableToPlaySports
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AbleToPlaySports", _ableToPlaySports, value)
            End Set
        End Property
        Private _canWork As String
        <Size(3)> _
        Public Property CanWork() As String
            Get
                Return _canWork
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CanWork", _canWork, value)
            End Set
        End Property
        Private _difficultySleeping As String
        <Size(3)> _
        Public Property DifficultySleeping() As String
            Get
                Return _difficultySleeping
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DifficultySleeping", _difficultySleeping, value)
            End Set
        End Property
        Private _seenAE As String
        <Size(3)> _
        Public Property SeenAE() As String
            Get
                Return _seenAE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SeenAE", _seenAE, value)
            End Set
        End Property
        Private _seenGP As String
        <Size(3)> _
        Public Property SeenGP() As String
            Get
                Return _seenGP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SeenGP", _seenGP, value)
            End Set
        End Property
        Private _seenSpecialist As String
        <Size(3)> _
        Public Property SeenSpecialist() As String
            Get
                Return _seenSpecialist
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SeenSpecialist", _seenSpecialist, value)
            End Set
        End Property
        Private _responsedue As DateTime
        Public Property ResponseDue() As DateTime
            Get
                Return _responsedue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ResponseDue", _responsedue, value)
            End Set
        End Property
        Private _responded As DateTime
        Public Property Responded() As DateTime
            Get
                Return _responded
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Responded", _responded, value)
            End Set
        End Property
        Private _replydue As DateTime
        Public Property ReplyDue() As DateTime
            Get
                Return _replydue
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ReplyDue", _replydue, value)
            End Set
        End Property
        Private _replied As DateTime
        Public Property Replied() As DateTime
            Get
                Return _replied
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Replied", _replied, value)
            End Set
        End Property
        Private _outcome As eCITOutCome
        Public Property OutCome() As eCITOutCome
            Get
                Return _outcome
            End Get
            Set(ByVal value As eCITOutCome)
                SetPropertyValue(Of eCITOutCome)("OutCome", _outcome, value)
            End Set
        End Property
        Private _reply As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Reply() As String
            Get
                Return _reply
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reply", _reply, value)
            End Set
        End Property
        Private _notes As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
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
        Public Overrides Function ToString() As String
            Return String.Format("CIT Musculoskeletal Knee {0}", Oid)
        End Function
    End Class

End Namespace

