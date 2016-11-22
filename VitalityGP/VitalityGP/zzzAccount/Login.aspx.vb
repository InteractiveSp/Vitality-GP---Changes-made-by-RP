Imports Alliance.Data
Public Class Login
    Inherits System.Web.UI.Page
    Shadows _session As DevExpress.Xpo.Session ' added by rp
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'If Membership.ValidateUser(tbUserName.Text, tbPassword.Text) Then


        '    If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
        '        FormsAuthentication.SetAuthCookie(tbUserName.Text, False)
        '        Response.Redirect("~/")
        '    Else
        '        FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, False)
        '    End If
        'Else
        '    tbUserName.ErrorText = "Invalid user"
        '    tbUserName.IsValid = False
        'End If
    End Sub
End Class