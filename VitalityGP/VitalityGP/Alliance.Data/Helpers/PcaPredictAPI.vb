Imports System.Data

Public Module PcaPredictAPI
    Dim _key As String = "XX38-FN86-RU29-FG56"

    Public Function CapturePlus_Interactive_Retrieve(Id As String) As DataRow
        Return CapturePlus_Interactive_Retrieve_v2_10(Id)
    End Function
    Public Function CapturePlus_Interactive_Find(SearchTerm As String, SearchFor As String, PreviousID As String) As DataSet
        Return CapturePlus_Interactive_Find_v2_10(SearchTerm, SearchFor, PreviousID)
    End Function
    Public Function PostcodeAnywhere_Interactive_RetrieveByParts(Postcode As String, UserName As String) As DataSet
        Return PostcodeAnywhere_Interactive_RetrieveByParts(Postcode, UserName)
    End Function
    Private Function CapturePlus_Interactive_Retrieve_v2_10(Id As String) As DataRow

        Dim _strUrl As String
        Dim _ds As DataSet

        'Build the url
        _strUrl = "http://services.postcodeanywhere.co.uk/CapturePlus/Interactive/Retrieve/v2.10/dataset.ws?"
        _strUrl &= "&Key=" & System.Web.HttpUtility.UrlEncode(_key)
        _strUrl &= "&Id=" & System.Web.HttpUtility.UrlEncode(Id)

        'Create the dataset
        _ds = New DataSet
        _ds.ReadXml(_strUrl)

        'Check for an error
        If _ds.Tables.Count = 1 AndAlso _ds.Tables(0).Columns.Count = 4 AndAlso _ds.Tables(0).Columns(0).ColumnName = "Error" Then
            '  XtraMessageBox.Show(_ds.Tables(0).Rows(0).Item(1).ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
        Else
            Return _ds.Tables(0).Rows(0)
        End If

        'FYI: The dataset contains the following columns:
        'Id,DomesticId,Language,LanguageAlternatives,Department,Company,SubBuilding,BuildingNumber,BuildingName,SecondaryStreet,Street,Block,Neighbourhood,District,City,
        'Line1,Line2,Line3,Line4,Line5,AdminAreaName, AdminAreaCode,Province,ProvinceName,ProvinceCode,PostalCode,CountryName,CountryIso2,CountryIso3,CountryIsoNumber
        'SortingNumber1,SortingNumber2,Barcode,POBoxNumber,Label,Type,ataLevel


    End Function

    Private Function CapturePlus_Interactive_Find_v2_10(SearchTerm As String, SearchFor As String, PreviousID As String) As DataSet

        Dim _strUrl As String
        Dim _ds As DataSet

        '   Dim LastId As String = ""
        Dim Country As String = "GBR"
        Dim LanguagePreference As String = "EN"
        Dim MaxSuggestions As String = 25
        Dim MaxResults As String = 50

        'Build the url
        _strUrl = "http://services.postcodeanywhere.co.uk/CapturePlus/Interactive/Find/v2.10/dataset.ws?"
        _strUrl &= "&Key=" & System.Web.HttpUtility.UrlEncode(_key)
        _strUrl &= "&SearchTerm=" & System.Web.HttpUtility.UrlEncode(SearchTerm)
        _strUrl &= "&LastId=" & System.Web.HttpUtility.UrlEncode(PreviousID)
        _strUrl &= "&SearchFor=" & System.Web.HttpUtility.UrlEncode(SearchFor)
        _strUrl &= "&Country=" & System.Web.HttpUtility.UrlEncode(Country)
        _strUrl &= "&LanguagePreference=" & System.Web.HttpUtility.UrlEncode(LanguagePreference)
        _strUrl &= "&MaxSuggestions=" & System.Web.HttpUtility.UrlEncode(MaxSuggestions)
        _strUrl &= "&MaxResults=" & System.Web.HttpUtility.UrlEncode(MaxResults)

        'Create the dataset
        _ds = New DataSet
        _ds.ReadXml(_strUrl)

        'Check for an error
        If _ds.Tables.Count = 1 AndAlso _ds.Tables(0).Columns.Count = 4 AndAlso _ds.Tables(0).Columns(0).ColumnName = "Error" Then
            '  XtraMessageBox.Show(_ds.Tables(0).Rows(0).Item(1).ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
        Else
            Return _ds
        End If

        'FYI: The dataset contains the following columns:
        'Id,Text,Highlight,Cursor,Description,Next

    End Function

    Private Function PostcodeAnywhere_Interactive_RetrieveByParts_v1_00(Postcode As String, UserName As String) As DataSet

        Dim _strUrl As String
        Dim _ds As DataSet

        'Build the url
        _strUrl = "http://services.postcodeanywhere.co.uk/PostcodeAnywhere/Interactive/RetrieveByParts/v1.00/dataset.ws?"
        _strUrl &= "&Key=" & System.Web.HttpUtility.UrlEncode(_key)

        '        _strUrl &= "&Organisation=" & System.Web.HttpUtility.UrlEncode(Organisation)
        '       _strUrl &= "&Building=" & System.Web.HttpUtility.UrlEncode(Building)
        '      _strUrl &= "&Street=" & System.Web.HttpUtility.UrlEncode(Street)
        '     _strUrl &= "&Locality=" & System.Web.HttpUtility.UrlEncode(Locality)

        _strUrl &= "&Postcode=" & System.Web.HttpUtility.UrlEncode(Postcode)
        _strUrl &= "&UserName=" & System.Web.HttpUtility.UrlEncode(UserName)

        'Create the dataset
        _ds = New DataSet
        _ds.ReadXml(_strUrl)

        'Check for an error
        If _ds.Tables.Count = 1 AndAlso _ds.Tables(0).Columns.Count = 4 AndAlso _ds.Tables(0).Columns(0).ColumnName = "Error" Then
            ' XtraMessageBox.Show(_ds.Tables(0).Rows(0).Item(1).ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
        End If

        Return _ds

        'FYI: The dataset contains the following columns:
        'Udprn,Company,Department,Line1,Line2,Line3,Line4,Line5,PostTown,County,Postcode
        'Mailsort,Barcode,Type,DeliveryPointSuffix,SubBuilding,BuildingName,BuildingNumber,PrimaryStreet,SecondaryStreet
        'DoubleDependentLocality,DependentLocality,PoBox,PrimaryStreetName,PrimaryStreetType,SecondaryStreetName,SecondaryStreetType,CountryName

    End Function
End Module
