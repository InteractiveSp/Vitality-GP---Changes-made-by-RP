Imports DevExpress.Xpo
Imports Alliance.Data
Imports Microsoft.VisualBasic
Imports System
Namespace Alliance.Data

    Public Class ConsultantHospital
        Inherits AuditedBase
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _Consultant As Consultant
        <Association>
        Public Property Consultant() As Consultant
            Get
                Return _Consultant
            End Get
            Set(ByVal value As Consultant)
                SetPropertyValue(Of Consultant)("Consultant", _Consultant, value)
            End Set
        End Property
        Private _consultantid As Integer
        Public Property Consultantid() As Integer
            Get
                Return _consultantid
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Consultantid", _consultantid, value)
            End Set
        End Property
        Private _Hospital As Hospital
        <Association>
        Public Property Hospital() As Hospital
            Get
                Return _Hospital
            End Get
            Set(ByVal value As Hospital)
                SetPropertyValue(Of Hospital)("Hospital", _Hospital, value)
            End Set
        End Property
        Private _Hospitalid As Integer
        Public Property HospitalID() As Integer
            Get
                Return _Hospitalid
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("HospitalID", _Hospitalid, value)
            End Set
        End Property
        Private _Comment As String
        <Size(SizeAttribute.Unlimited), Delayed(True)> _
        Public Property Comment() As String
            Get
                Return GetDelayedPropertyValue(Of String)("Comment")
            End Get
            Set(ByVal value As String)
                SetDelayedPropertyValue("Comment", value)
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