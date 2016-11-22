Imports Alliance.Data
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.FileIO
Imports System.Text


Public Enum eApplication
    '  Dummy = 0
    Gus = 1
    Maisie = 2
End Enum

Public Class GlobalVariables
    Public Shared _SystemIsLive As Boolean = True
    Public Shared _UserOid As Integer
    Public Shared thisUser As User

    Public Shared project360cn As String = "Data Source=ALLIANCE-SQL;Initial Catalog=Project360;Persist Security Info=True;User ID=Project43;Password=kixiqa33"
    Public Shared project360Server As String = "ALLIANCE-SQL"
    Public Shared project360DB As String = "Project360Dev"
    Public Shared SmtpServer As String = "Alliance-RS"
    'Public Shared SmtpServer As String = "outbound.mailhop.org"
    Public Shared SmtpLogin As String = "alliance-surgical-relay"
    Public Shared SmtpPassword As String = "Gr33nSKIES"

    Public Shared SystemType As eSystemType = eSystemType.Development
    Public Shared TestEmailAddress As String = "Developers@allsurgical.co.uk"
    Public Shared DevelopersEmailAddress As String = "Developers@allsurgical.co.uk"
    Public Shared TestSMSNumber As String = "07825559431"
    Public Shared LibraryFolder As String = "\\ALLIANCE-FS\CompanyData\IT Code\Library\EmailTemplates"
    Public Shared CRMLibraryFolder As String = "\\ALLIANCE-CRM\Library"
    Public Shared ConsultantCVFolder As String = "\\ALLIANCE-FS\CompanyData\Consultant Info\CV"
    Public Shared Application As eApplication
    Public Shared DefaultActionInterval As Integer = 120
End Class

Public Class MakePassword
    Public Function RandomCharacters(_len As Integer) As String
        Dim _possibleChars As String = "ABCDEFGHIJKLMNPQRSTUVWXYZabcdefghjkmnopqrstuvwxyz0123456789"
        Dim cpossibleChars() As Char
        cpossibleChars = _possibleChars.ToCharArray()


        Dim builder As New StringBuilder()

        For i As Integer = 0 To _len - 1
            Dim rndNumber As Integer = GetRandom(0, cpossibleChars.Length)

            Dim c As Char = cpossibleChars(rndNumber)
            builder.Append(c)
        Next
        Return builder.ToString()
    End Function
    Public Function Generate(ByVal Capatilise As Boolean) As String
        Dim Word1 As String = ""
        Dim Word2 As String = ""
        Dim WordList As List(Of String) = LoadWordList()

        'Kry nommer
        '   Dim RandomClass As New System.Random(System.DateTime.Now.Millisecond)
        '  Dim rndNumber As Integer = RandomClass.Next(0, 99)
        Dim rndNumber As Integer = 69
        Do While rndNumber = 69
            rndNumber = GetRandom(1, 99)
        Loop

        'Get 2 random words from the list
        Word1 = GetWord(WordList, Capatilise)

        'Test if the 2 words are the same
        Do
            Word2 = GetWord(WordList, Capatilise)
        Loop Until Word1 <> Word2

        'Decide the order of the words
        Dim PasswordPosition As Integer = GetRandom(0, 3)
        Return OrderWords(PasswordPosition, Word1, Word2, rndNumber)
    End Function

    ''' <summary>
    ''' Converts the supplied word to a lowercase word with the first Character Capitilised 
    ''' </summary>
    ''' <param name="Word">The word to convert</param>
    ''' <returns>a Lowercase word with the first Character Capitilised </returns>
    ''' <remarks></remarks>
    Private Function Mixedcase(ByVal Word As String) As String
        If Word.Length = 0 Then Return Word
        If Word.Length = 1 Then Return Word.ToUpper
        Return Word.Substring(0, 1).ToUpper & Word.Substring(1).ToLower
    End Function

    Private Function LoadWordList() As List(Of String)
        Dim WordList As New List(Of String)
        If My.Computer.FileSystem.FileExists(ConstDataStrings.WordList) Then
            Dim fields As String()
            Dim delimiter As String = ","
            Using parser As New TextFieldParser(ConstDataStrings.WordList)
                parser.SetDelimiters(delimiter)
                While Not parser.EndOfData
                    ' Read in the fields for the current line
                    fields = parser.ReadFields()
                    For Each word As String In fields
                        WordList.Add(word)
                    Next
                End While
            End Using

        Else
            Throw New System.Exception(ConstDataStrings.WordList & " doesn't Exist!")
        End If
        Return WordList
    End Function
    Private Function GetWord(ByVal WordList As List(Of String), ByVal Capatilise As Boolean) As String
        'Dim Position As New System.Random(System.DateTime.Now.Millisecond)
        Dim wordnumber As Integer = GetRandom(0, WordList.Count - 1)
        If Capatilise Then
            Return Mixedcase(WordList(wordnumber))
        Else
            Return WordList(wordnumber)
        End If
    End Function
    Private Function OrderWords(ByVal PasswordPosition As Integer, ByVal Word1 As String, ByVal Word2 As String, ByVal rndNumber As Integer) As String
        Select Case PasswordPosition
            Case 0 : Return Word1 & Word2 & rndNumber
            Case 1 : Return Word1 & rndNumber & Word2
            Case 2 : Return Word2 & Word1 & rndNumber
            Case 3 : Return Word2 & rndNumber & Word1
            Case Else : Return Word1 & Word2
        End Select
    End Function
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
End Class