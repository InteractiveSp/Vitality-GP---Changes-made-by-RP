Imports DevExpress.Xpo
Imports Alliance.Data
Imports Microsoft.VisualBasic
Imports System
Namespace Alliance.Data
    Public Class HospitalAttribute
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _attribute As Attrib
        <Association>
        Public Property Attrib() As Attrib
            Get
                Return _attribute
            End Get
            Set(ByVal value As Attrib)
                SetPropertyValue(Of Attrib)("Attrib", _attribute, value)
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

    End Class
End Namespace