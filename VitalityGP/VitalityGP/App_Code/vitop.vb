Imports System
Imports DevExpress.Xpo

Public Class vitop
    Inherits XPObject

    Public Sub New()
        MyBase.New()
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here.			
    End Sub

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here.			
    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code.
    End Sub

    Public userID As Guid
    Public Title As String
    Public Firstname As String
    Public Lastname As String
    Public DOB As Date
    Public Gender As String
    Public Address1 As String
    Public Address2 As String
    Public Address3 As String
    Public Address4 As String
    Public Postcode As String
    Public Telephone As String
    Public LeaveMessage As String
    Public ConsentThirdParty As String
    Public PolicyNumber As String
    Public AuthNumber As String
    Public PresentingCondition As String
    Public Symptoms As String
    Public Excess As Decimal
    Public OutpatientLimit As Decimal
    Public HospitalList As String
    Public GPSelect As String
    Public SelfPaying As String
    Public Callback As Date
    Public last_crm_post As Date
    Public AsRef As Integer
    Public GPID As Integer
    Public AltContact As String
    Public StaffClaim As String

End Class