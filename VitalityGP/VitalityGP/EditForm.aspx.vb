Imports DevExpress.Xpo
Imports System.Web.SessionState
Imports DevExpress.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Data.Filtering


Public Class EditForm
    Inherits System.Web.UI.Page
    Dim strOid As String


    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        'Dim session As Session = XpoHelper.GetNewSession()
        'XpoDataSource2.Session = session


        Dim session As Session = XpoHelper2.GetNewSession(XpoHelper2.Database.XpoWebTest)
        XpoDataSource1.Session = session


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Get our membership info
        Dim u As MembershipUser
        u = Membership.GetUser(User.Identity.Name)





        ' Alternative to using bound text box to save on realestate just query xpo object with id and display referral in Referral Detail group section header
        If CInt(Request.QueryString("id")) Then
            Using collection As New XPCollection(XpoDataSource1.Session, GetType(vitop))

                collection.Filter = CriteriaOperator.Parse("Oid = " & Request.QueryString("id"))

                Dim viewRef As vitop = CType(collection(0), vitop)

                ASPxFormLayout1.Items(3).Caption = "AS Ref " & viewRef.AsRef.ToString() & " Details"
            End Using

        End If

      


        ' u.ProviderUserKey 'userid guid
        'u.UserName 'username
    End Sub




    'Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    '    Dim u As MembershipUser
    '    u = Membership.GetUser(User.Identity.Name)

    '    'get the GPID from CRm from the profile object
    '    Dim intPersonID = Context.Profile.GetPropertyValue("PersonID")


    '    Try
    '        Using collection As New XPCollection(XpoDataSource1.Session, GetType(vitop))

    '            collection.Filter = CriteriaOperator.Parse("Oid = " & spinOid.Text.ToString())
    '            Dim save As vitop = CType(collection(0), vitop)

    '            save.Title = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Title"), ASPxComboBox)).SelectedItem.Value
    '            save.Firstname = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Firstname"), ASPxTextBox)).Text
    '            save.Lastname = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Lastname"), ASPxTextBox)).Text
    '            save.DOB = (CType(ASPxFormLayout1.FindNestedControlByFieldName("DOB"), ASPxDateEdit)).Text
    '            save.Gender = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Gender"), ASPxComboBox)).SelectedItem.Value
    '            save.Address1 = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Address1"), ASPxTextBox)).Text
    '            save.Address2 = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Address2"), ASPxTextBox)).Text
    '            save.Address3 = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Address3"), ASPxTextBox)).Text
    '            save.Address4 = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Address4"), ASPxTextBox)).Text
    '            save.Postcode = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Postcode"), ASPxTextBox)).Text
    '            save.Telephone = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Telephone"), ASPxTextBox)).Text
    '            save.LeaveMessage = (CType(ASPxFormLayout1.FindNestedControlByFieldName("LeaveMessage"), ASPxCheckBox)).Value
    '            save.ConsentThirdParty = (CType(ASPxFormLayout1.FindNestedControlByFieldName("ConsentThirdParty"), ASPxCheckBox)).Value
    '            save.PolicyNumber = (CType(ASPxFormLayout1.FindNestedControlByFieldName("PolicyNumber"), ASPxTextBox)).Value
    '            save.AuthNumber = (CType(ASPxFormLayout1.FindNestedControlByFieldName("AuthNumber"), ASPxTextBox)).Value
    '            save.PresentingCondition = (CType(ASPxFormLayout1.FindNestedControlByFieldName("PresentingCondition"), ASPxTextBox)).Value
    '            save.Symptoms = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Symptoms"), ASPxMemo)).Value
    '            save.Excess = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Excess"), ASPxSpinEdit)).Value
    '            save.OutpatientLimit = (CType(ASPxFormLayout1.FindNestedControlByFieldName("OutpatientLimit"), ASPxSpinEdit)).Value
    '            save.GPSelect = (CType(ASPxFormLayout1.FindNestedControlByFieldName("GPSelect"), ASPxComboBox)).Value
    '            save.SelfPaying = (CType(ASPxFormLayout1.FindNestedControlByFieldName("SelfPaying"), ASPxCheckBox)).Value


    '            If cboGPSelect.SelectedItem.Value = "No" Then
    '                ' we only want to pass a Hospital value if GPSelect is No
    '                save.HospitalList = (CType(ASPxFormLayout1.FindNestedControlByFieldName("HospitalList"), ASPxComboBox)).SelectedItem.Value
    '            Else
    '                save.HospitalList = DBNull.Value.ToString
    '            End If


    '            'check for optional(null) callback time
    '            Dim testcallback As ASPxTimeEdit
    '            testcallback = CType(ASPxFormLayout1.FindNestedControlByFieldName("Callback"), ASPxTimeEdit)
    '            If Not testcallback.Text = "" Then
    '                save.Callback = (CType(ASPxFormLayout1.FindNestedControlByFieldName("Callback"), ASPxTimeEdit)).DateTime
    '            End If
    '            save.userID = u.ProviderUserKey
    '            save.GPID = intPersonID
    '            save.Save()




    '        End Using

    '    Catch ex As Exception

    '    End Try


    'End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, btnCancel.Click
        Response.Redirect("~/prevrefs.aspx")
    End Sub
End Class