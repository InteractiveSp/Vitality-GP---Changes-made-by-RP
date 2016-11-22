Imports Alliance.Data
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo

Public Class _Default1
    Inherits System.Web.UI.Page

    Private Sub _Default1_Init(sender As Object, e As EventArgs) Handles Me.Init
        'Dim session As Session = XpoHelper.GetNewSession()
        'XpoDataSource2.Session = session


        Dim session As Session = XpoHelper2.GetNewSession(XpoHelper2.Database.CRM)
        XpoDataSource2.Session = session

    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim u As MembershipUser
        u = Membership.GetUser(User.Identity.Name)

        'get the GPID from CRm from the profile object
        ' Dim intPersonID = Context.Profile.GetPropertyValue("PersonID")

        Try
            'Equivalent of an Insert Statement in SQL
            Using uow = New UnitOfWork()

                Dim _patient As New Patient(uow)
                _patient.Title = cboTitle.SelectedItem.Value
                _patient.FirstName = txtFirstName.Text
                _patient.SurName = txtLastname.Text
                _patient.DOB = dtDOB.Text
                _patient.Gender = cboGender.SelectedItem.Value
                _patient.Addr1 = txtAddress1.Text
                _patient.Addr2 = txtAddress2.Text
                _patient.Addr3 = txtAddress3.Text
                _patient.PostCode = txtPostcode.Text
                If txtTelephone.Text.StartsWith("07") Then
                    _patient.MobilePhone = txtTelephone.Text
                Else
                    _patient.WorkPhone = txtTelephone.Text
                End If

                _patient.ConsentToLeaveMessage = chkLeaveMessage.Checked.ToString

                _patient.Save()

                Dim _referral As New Referral(uow)

                '  _patient.ConsentThirdParty = chkThirdParty.Checked.ToString
                _referral.Patient = _patient
                _referral.PolicyNo = txtPolicyNumber.Text
                'save.AuthNumber = txtAuthnumber.Text
                _referral.Details = txtPresentingCondition.Text
                _referral.SpecialInstructions = txtSymptoms.Text
                _referral.Symptom = uow.FindObject(Of Symptom)(CriteriaOperator.Parse("Symptom = ?", "WebReferral"))
                _referral.Insurer = uow.GetObjectByKey(Of Insurer)(9531)
                ' Session.FindObject(Of Practice)(CriteriaOperator.Parse("Oid = ?", pOid))
                _referral.StaffClaim = chkStaffClaim.Checked.ToString
                If spinExcess.Text = "" Then
                    _referral.Excess = 0
                Else
                    _referral.Excess = spinExcess.Text
                End If
                If spinOutPatientLimit.Text = "" Then
                    _referral.OutPatientLimit = 0
                Else
                    _referral.OutPatientLimit = spinOutPatientLimit.Text
                End If

                ' _referral.GPSelect = cboGPSelect.SelectedItem.Value
                ' _referral.AltContact = txtAltContact.Text

                If cboGPSelect.SelectedItem.Value = "No" Then
                    ' we only want to pass a Hospital value if GPSelect is No
                    _referral.HospitalList = cboHospitalList.SelectedItem.Value
                Else
                    _referral.HospitalList = DBNull.Value.ToString
                End If


                ' _referral.Callback = dtCallBack.Value
                ' _referral.SelfPaying = chkSelfPay.Checked.ToString


                ' _referral.userID = u.ProviderUserKey()
                '  _referral.GPID = intPersonID 'gpid
                _referral.Save()

                '.Save() will persistent your changes to the object but uow.CommitChanges() will save those changes back to the database
                uow.CommitChanges()
            End Using


        Catch ex As Exception
            MsgBox(ex.Message)
            '  errorMessageLabel.Visible = True
        End Try
    End Sub

    Private Sub _Default1_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

    End Sub

    Private Sub dtCallBack_Init(sender As Object, e As EventArgs) Handles dtCallBack.Init
        dtCallBack.Date = Now.AddHours(2)
        dtCallBack.MinDate = Now.AddHours(2)
    End Sub


End Class