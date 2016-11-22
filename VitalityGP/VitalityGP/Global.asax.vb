Imports System.Web.SessionState
Imports DevExpress.Web
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error

        ' Fires when the application is started

        ' Code that runs on application startup 
        ' Specify the connection string, which is used to open a database. _ 

        'Dim session As New Session()

        '  Dim session As Session = XpoHelper.GetNewSession()
        '  XpoDataSource1.Session = session


        XpoDefault.Session = Nothing
        If Environment.MachineName = "JOHN-PC2" Then
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(MSSqlConnectionProvider.GetConnectionString("JOHN-PC2\SQLEXPRESS", "madcap", "ferrett", "VitalityGP"), AutoCreateOption.SchemaOnly)
        Else
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(MSSqlConnectionProvider.GetConnectionString("ALLIANCE-RS", "CRM", "ferrett", "VitalityGP"), AutoCreateOption.DatabaseAndSchema)
        End If

        ' XpoDefault.Session = 
        '   session = XpoHelper.GetDataLayer()
        ' XpoDefault.Session = session
        '   XpoDefault.Session = XpoHelper.GetDataLayer()




    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class