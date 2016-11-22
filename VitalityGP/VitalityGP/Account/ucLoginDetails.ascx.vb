Imports Alliance.Data
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Session

Partial Class ucLoginDetails
    Inherits System.Web.UI.UserControl
    Private _session As New UnitOfWork

    Protected Sub Repeater1_Load(sender As Object, e As EventArgs) Handles Repeater1.Load
        If Not IsPostBack Then
            _session = XpoHelper.GetNewUnitOfWork()

            Dim sSql As String = ""

            sSql = "WITH M AS " _
                & "(" _
                & "SELECT Client.FullName, BusinessUnit.BusinessUnit,GlobalUser.UserName, GlobalUser.Password, " _
                    & "ROW_NUMBER() OVER(PARTITION BY Beneficiary.BusinessUnit " _
                    & "ORDER BY FullName DESC, BusinessUnit.BusinessUnit DESC) AS rownum " _
                    & "FROM Beneficiary INNER JOIN " _
                    & "Client ON Beneficiary.Client = Client.OID INNER JOIN " _
                    & "GlobalUser ON Beneficiary.OID = GlobalUser.Oid INNER JOIN " _
                    & "BusinessUnit ON Beneficiary.BusinessUnit = BusinessUnit.OID  " _
                    & "WHERE (Client.MemberPortal = 1) AND (GlobalUser.ApplicationName = 'Members') " _
                & ") " _
                & "SELECT FullName, BusinessUnit, UserName, Password " _
                & " FROM M WHERE rownum =1 ;"

            Dim dv As New XPDataView()
            Dim data As SelectedData = _session.ExecuteQueryWithMetadata(sSql)

            For Each row As SelectStatementResultRow In data.ResultSet(0).Rows
                dv.AddProperty(DirectCast(row.Values(0), String), DBColumn.[GetType](DirectCast([Enum].Parse(GetType(DBColumnType), DirectCast(row.Values(2), String)), DBColumnType)))
            Next

            dv.LoadData(New SelectedData(data.ResultSet(1)))
            Repeater1.DataSource = dv
            Repeater1.DataBind()
        End If

    End Sub
End Class
