Imports System
Imports System.ComponentModel
Imports System.Reflection

Namespace Alliance.Data
    Public NotInheritable Class EnumHelper
        Private Sub New()
        End Sub
        Public Shared Function GetDescription(en As [Enum]) As String
            Dim type As Type = en.[GetType]()

            Dim memInfo As MemberInfo() = type.GetMember(en.ToString())

            If memInfo IsNot Nothing AndAlso memInfo.Length > 0 Then
                Dim attrs As Object() = memInfo(0).GetCustomAttributes(GetType(DescriptionAttribute), False)

                If attrs IsNot Nothing AndAlso attrs.Length > 0 Then
                    Return DirectCast(attrs(0), DescriptionAttribute).Description
                End If
            End If

            Return en.ToString()
        End Function

    End Class
End Namespace