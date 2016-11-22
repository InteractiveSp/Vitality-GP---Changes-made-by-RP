Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports DevExpress.Utils
Imports System.Collections

Namespace Alliance.Data
    <Flags> _
    Public Enum PersonGender
        Male
        Female
    End Enum
    Public Class StringHelper
        Public Shared Function GetStringByArrayList(ByVal array As ArrayList) As String
            Dim ret As String = String.Empty
            If Object.Equals(array, Nothing) Then
                Return ret
            End If
            array.Sort()
            For i As Integer = 0 To array.Count - 1
                If i = array.Count - 1 Then
                    ret &= String.Format("{0}{1}", array(i), String.Empty)
                Else
                    ret &= String.Format("{0}{1}", array(i), ", ")
                End If
            Next i
            Return ret
        End Function
    End Class
    Public Class ReferenceImages
        Private Shared person As Image = Nothing, person_small As Image = Nothing, movie As Image = Nothing
        Public Shared ReadOnly Property UnknownPerson() As Image
            Get
                If Object.Equals(person, Nothing) Then
                    person = ResourceImageHelper.CreateImageFromResources("Unknown-user.png", GetType(Client).Assembly)
                End If
                Return person
            End Get
        End Property
        Public Shared ReadOnly Property UnknownPerson_Small() As Image
            Get
                If Object.Equals(person_small, Nothing) Then
                    person_small = ResourceImageHelper.CreateImageFromResources("Unknown-user-small.png", GetType(Client).Assembly)
                End If
                Return person_small
            End Get
        End Property
        Public Shared ReadOnly Property UnknownMovie() As Image
            Get
                If Object.Equals(movie, Nothing) Then
                    movie = ResourceImageHelper.CreateImageFromResources("Unknown-movie.png", GetType(Client).Assembly)
                End If
                Return movie
            End Get
        End Property
    End Class
End Namespace
