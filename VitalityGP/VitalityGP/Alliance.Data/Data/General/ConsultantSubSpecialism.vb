Imports DevExpress.Xpo
Imports Alliance.Data

Public Class ConsultantSubSpecialism
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
    Private _subSpecialism As SubSpecialism
    <Association>
    Public Property SubSpecialism() As SubSpecialism
        Get
            Return _subSpecialism
        End Get
        Set(ByVal value As SubSpecialism)
            SetPropertyValue(Of SubSpecialism)("SubSpecialism", _subSpecialism, value)
        End Set
    End Property
    Private _Comment As String
    Public Property Comment() As String
        Get
            Return _Comment
        End Get
        Set(ByVal value As String)
            SetPropertyValue(Of String)("Comment", _Comment, value)
        End Set
    End Property
End Class

