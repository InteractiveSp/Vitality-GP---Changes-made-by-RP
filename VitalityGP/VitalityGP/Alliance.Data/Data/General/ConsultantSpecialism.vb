Imports DevExpress.Xpo
Imports Alliance.Data

Public Class ConsultantSpecialism
    Inherits AuditedBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    '<Key(True), Persistent("Oid")> _
    'Private _Oid As Integer
    '<PersistentAlias("_Oid")> _
    'Public ReadOnly Property Oid As Integer
    '    Get
    '        Return _Oid
    '    End Get
    'End Property
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
    Private _Specialism As Specialism
    <Association>
    Public Property Specialism() As Specialism
        Get
            Return _Specialism
        End Get
        Set(ByVal value As Specialism)
            SetPropertyValue(Of Specialism)("Specialism", _Specialism, value)
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
