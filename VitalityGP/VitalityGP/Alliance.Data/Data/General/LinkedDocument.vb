Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports System.Drawing
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraNavBar
Imports DevExpress.Utils.Serializing.Helpers
Imports DevExpress.XtraScheduler.Xml
Imports System.Runtime.CompilerServices
Imports DevExpress.XtraEditors.DXErrorProvider
Imports System.Data
Imports Alliance.Data
Imports Alliance.Data.ConnectionHelper

Namespace Alliance.Data
    Public Class LinkedDocument
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
        Private _date As DateTime
        Public Property [Date]() As DateTime
            Get
                Return _date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("Date", _date, value)
            End Set
        End Property
        Private _type As eDocumentType
        Public Property Type() As eDocumentType
            Get
                Return _type
            End Get
            Set(ByVal value As eDocumentType)
                SetPropertyValue("Type", _type, value)
            End Set
        End Property
        Private _subject As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Subject() As String
            Get
                Return _subject
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Subject", _subject, value)
            End Set
        End Property
        Private _folder As String
        <Size(120)>
        Public Property Folder() As String
            Get
                Return _folder
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Folder", _folder, value)
            End Set
        End Property
        Private _filename As String
        <Size(250)>
        Public Property Filename() As String
            Get
                Return _filename
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Filename", _filename, value)
            End Set
        End Property
        Private _submitted As DateTime
        Public Property SentOn() As DateTime
            Get
                Return _submitted
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("Submitted", _submitted, value)
            End Set
        End Property
        Private _received As DateTime
        Public Property Received() As DateTime
            Get
                Return _received
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("Received", _received, value)
            End Set
        End Property
        Private _emailFrom As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property EmailFrom() As String
            Get
                Return _emailFrom
            End Get
            Set(ByVal value As String)
                SetPropertyValue("EmailFrom", _emailFrom, value)
            End Set
        End Property
        Private _emailTo As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property EmailTo() As String
            Get
                Return _emailTo
            End Get
            Set(ByVal value As String)
                SetPropertyValue("EmailTo", _emailTo, value)
            End Set
        End Property
        Private _emailCC As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property EmailCC() As String
            Get
                Return _emailCC
            End Get
            Set(ByVal value As String)
                SetPropertyValue("EmailCC", _emailCC, value)
            End Set
        End Property
        Private _emailBody As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property EmailBody() As String
            Get
                Return _emailBody
            End Get
            Set(ByVal value As String)
                SetPropertyValue("EmailBody", _emailBody, value)
            End Set
        End Property
        <Association("Document-Attachments")> _
        Public ReadOnly Property Attachments() As XPCollection(Of LinkedDocumentAttachment)
            Get
                Return GetCollection(Of LinkedDocumentAttachment)("Attachments")
            End Get
        End Property
        Private _beneficiary As Beneficiary
        <Association("Beneficiary-Documents")> _
        Public Property Beneficiary() As Beneficiary
            Get
                Return _beneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", _beneficiary, value)
            End Set
        End Property
        Private _claim As Claim
        <Association("Claim-Documents")> _
        Public Property Claim() As Claim
            Get
                Return _claim
            End Get
            Set(ByVal value As Claim)
                SetPropertyValue(Of Claim)("Claim", _claim, value)
            End Set
        End Property
        Private _authorisation As Authorisation
        <Association("Authorisation-Documents")> _
        Public Property Authorisation() As Authorisation
            Get
                Return _authorisation
            End Get
            Set(ByVal value As Authorisation)
                SetPropertyValue(Of Authorisation)("Authorisation", _authorisation, value)
            End Set
        End Property
        Private _referral As Referral
        <Association("Referral-Documents")> _
        Public Property Referral() As Referral
            Get
                Return _referral
            End Get
            Set(ByVal value As Referral)
                SetPropertyValue(Of Referral)("Referral", _referral, value)
            End Set
        End Property
        Private _patient As Patient
        <Association("Patient-Documents")> _
        Public Property Patient() As Patient
            Get
                Return _patient
            End Get
            Set(ByVal value As Patient)
                SetPropertyValue(Of Patient)("Patient", _patient, value)
            End Set
        End Property
        Private _commid As Integer
        Public Property Commid() As Integer
            Get
                Return _commid
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("Commid", _commid, value)
            End Set
        End Property
        Private _libid As Integer
        Public Property Libid() As Integer
            Get
                Return _libid
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue("Libid", _libid, value)
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
    End Class
    Public Class LinkedDocumentAttachment
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
        Private _date As DateTime
        Public Property [Date]() As DateTime
            Get
                Return _date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue("Date", _date, value)
            End Set
        End Property
        Private _folder As String
        <Size(250)>
        Public Property Folder() As String
            Get
                Return _folder
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Folder", _folder, value)
            End Set
        End Property
        Private _filename As String
        <Size(250)>
        Public Property Filename() As String
            Get
                Return _filename
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Filename", _filename, value)
            End Set
        End Property
        Private _linkedDocument As LinkedDocument
        <Association("Document-Attachments")> _
        Public Property LinkedDocument() As LinkedDocument
            Get
                Return _linkedDocument
            End Get
            Set(ByVal value As LinkedDocument)
                SetPropertyValue("LinkedDocument", _linkedDocument, value)
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
    End Class
End Namespace