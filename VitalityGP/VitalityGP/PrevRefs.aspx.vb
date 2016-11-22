Imports DevExpress.Xpo
Imports Alliance.Data

Public Class PrevRefs
    Inherits System.Web.UI.Page

    Private Sub PrevRefs_Init(sender As Object, e As EventArgs) Handles Me.Init
        'Dim session As Session = XpoHelper.GetNewSession()
        'XpoDataSource2.Session = session


        Dim session As Session = XpoHelper.GetNewSession()
        XpoDataSource1.Session = session

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' MsgBox("Current user logged in is" & HttpContext.Current.User.Identity.Name.ToString)
        Dim u As MembershipUser
        u = Membership.GetUser(User.Identity.Name)
        XpoDataSource1.Criteria = "[Oid]= " & u.ProviderUserKey.ToString
    End Sub

    Protected Sub ASPxGridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs) Handles ASPxGridView1.CustomColumnDisplayText

        'display true false strings (CRM compatibility) to y and no or checked
        If e.Column.FieldName = "ConsentThirdParty" Or e.Column.FieldName = "LeaveMessage" Then
            If Convert.ToBoolean(e.Value) = True Then
                e.DisplayText = "Y"
            ElseIf Convert.ToBoolean(e.Value) = False Then
                e.DisplayText = "N"

            End If
        End If

        If e.Column.FieldName = "DOB" Then
            If IsDate(e.Value) Then
                e.DisplayText = FormatDateTime(e.Value, DateFormat.ShortDate)
            End If
        End If

    End Sub
End Class