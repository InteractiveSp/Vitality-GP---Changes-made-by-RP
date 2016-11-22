Imports Microsoft.VisualBasic
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data

    Public Enum DocType
        HandBook
        Letter
        Email
        Report
    End Enum

    Public Class LibraryDoc
        Inherits XPObject

        Private fBeneficiary As Beneficiary
        Private fClaim As Claim
        Private fAuthorisation As Authorisation
        Private fdocumentType As String
        Private ffilePath As String
        Private ffileName As String
        Private frevision As String
        Private fNote As String
        Private fcontents As Byte()
        Private fcreatedBy As GlobalUser
        Private fcreatedAt As DateTime
        Private fmodifiedBy As GlobalUser
        Private fmodifiedAt As DateTime

        Private fClient As Client
        <Association("Client-LibraryDoc")> _
        Public Property Client() As Client
            Get
                Return fClient
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", fClient, value)
            End Set
        End Property
        Private _insurer As Insurer
        <Association("Insurer-LibraryDoc")> _
        Public Property Insurer() As Insurer
            Get
                Return _insurer
            End Get
            Set(ByVal value As Insurer)
                SetPropertyValue(Of Insurer)("Insurer", _insurer, value)
            End Set
        End Property
        <Association("Beneficiary-LibraryDoc")> _
        Public Property Beneficiary() As Beneficiary
            Get
                Return fBeneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", fBeneficiary, value)
            End Set
        End Property
        Private _patient As Patient
        <Association("Patient-LibraryDoc")> _
        Public Property Patient() As Patient
            Get
                Return _patient
            End Get
            Set(ByVal value As Patient)
                SetPropertyValue(Of Patient)("Patient", _patient, value)
            End Set
        End Property
        <Association("Claim-LibraryDoc")> _
        Public Property Claim() As Claim
            Get
                Return fClaim
            End Get
            Set(ByVal value As Claim)
                SetPropertyValue(Of Claim)("Claim", fClaim, value)
            End Set
        End Property
        Private _referral As Referral
        <Association("Referral-LibraryDoc")> _
        Public Property Referral() As Referral
            Get
                Return _referral
            End Get
            Set(ByVal value As Referral)
                SetPropertyValue(Of Referral)("Referral", _referral, value)
            End Set
        End Property
        <Association("Authorisation-LibraryDoc")> _
        Public Property Authorisation() As Authorisation
            Get
                Return fAuthorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", fAuthorisation, value)
            End Set
        End Property
        Private fdoctype As DocType
        Public Property DocType() As DocType
            Get
                Return fdoctype
            End Get
            Set(ByVal value As DocType)
                SetPropertyValue(Of DocType)("DocType", fdoctype, value)
            End Set
        End Property
        Private _contentType As eFileType
        Public Property ContentType() As eFileType
            Get
                Return _contentType
            End Get
            Set(ByVal value As eFileType)
                SetPropertyValue(Of eFileType)("ContentType", _contentType, value)
            End Set
        End Property
        <Size(255)> _
        Public Property FilePath() As String
            Get
                Return ffilePath
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FilePath", ffilePath, value)
            End Set
        End Property
        <Size(255)> _
        Public Property FileName() As String
            Get
                Return ffileName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FileName", ffileName, value)
            End Set
        End Property
        Private _title As String
        <Size(150)> _
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", _title, value)
            End Set
        End Property
        <Size(SizeAttribute.Unlimited)> _
        Public Property Note() As String
            Get
                Return fNote
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Note", fNote, value)
            End Set
        End Property
        <Delayed(True)> _
        Public Property FileContents() As Byte()
            Get
                Return GetDelayedPropertyValue(Of System.Byte())("FileContents")
            End Get
            Set(ByVal value As Byte())
                SetDelayedPropertyValue(Of System.Byte())("FileContents", value)
            End Set
        End Property
        <Association("LibraryDoc-Attachments")> _
        Public ReadOnly Property Attachments() As XPCollection(Of LibraryDocAttachment)
            Get
                Return GetCollection(Of LibraryDocAttachment)("Attachments")
            End Get
        End Property
        Public Property CreatedBy() As GlobalUser
            Get
                Return fcreatedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("CreatedBy", fcreatedBy, value)
            End Set
        End Property
        Public Property CreatedAt() As DateTime
            Get
                Return fcreatedAt
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreatedAt", fcreatedAt, value)
            End Set
        End Property
        <MergeCollisionBehavior(OptimisticLockingReadMergeBehavior.Ignore)>
                Public Property ModifiedBy() As GlobalUser
            Get
                Return fmodifiedBy
            End Get
            Set(ByVal value As GlobalUser)
                SetPropertyValue(Of GlobalUser)("ModifiedBy", fmodifiedBy, value)
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
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
            CreatedAt = DateTime.Now
        End Sub
        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Session.IsNewObject(Me) Then
                CreatedBy = ProjectCurrentUser.GetGlobalUser(Session)
                CreatedAt = DateTime.Now
            End If
            ModifiedBy = ProjectCurrentUser.GetGlobalUser(Session)
            ModifiedAt = DateTime.Now

        End Sub
    End Class
    Public Class LibraryDocAttachment
        Inherits XPObject

        Private _LibraryDoc As LibraryDoc
        Private _attachments As Byte()
        <Association("LibraryDoc-Attachments")> _
          Public Property LibraryDoc() As LibraryDoc
            Get
                Return _LibraryDoc
            End Get
            Set(ByVal value As LibraryDoc)
                SetPropertyValue(Of LibraryDoc)("LibraryDoc", _LibraryDoc, value)
            End Set
        End Property
        Private _filePath As String
        <Size(255)> _
        Public Property FilePath() As String
            Get
                Return _filePath
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FilePath", _filePath, value)
            End Set
        End Property
        Private _fileName As String
        <Size(255)> _
        Public Property FileName() As String
            Get
                Return _fileName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FileName", _fileName, value)
            End Set
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
End Namespace