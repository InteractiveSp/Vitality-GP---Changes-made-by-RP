Imports System
Imports System.Reflection
Imports System.ComponentModel
Imports System.Security.Cryptography

Namespace Alliance.Data
    Public Class Enums
        Public Shared Function GetNumDescription(ByVal EnumConstant As [Enum]) As String
            Try
                Dim fi As FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())

                Dim attr() As DescriptionAttribute = DirectCast(
                    fi.GetCustomAttributes(GetType(DescriptionAttribute), False), 
                       DescriptionAttribute())
                If attr.Length > 0 Then
                    Return attr(0).Description
                Else
                    Return EnumConstant.ToString()
                End If

            Catch ex As Exception
                Return String.Empty
            End Try
        End Function
    End Class
  
End Namespace
