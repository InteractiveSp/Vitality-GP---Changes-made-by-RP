Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports Alliance.Data
Imports System.Web.Configuration

Namespace Alliance.Data

    Public NotInheritable Class XpoHelper
        Private Sub New()
        End Sub
        Shared Sub New()
            CreateDefaultObjects()
        End Sub

        Public Shared Function GetNewSession() As Session
            Return New Session(DataLayer)
        End Function

        Public Shared Function GetNewUnitOfWork() As UnitOfWork
            Return New UnitOfWork(DataLayer)
        End Function

        Private Shared ReadOnly lockObject As Object = New Object()

        Public Shared XpoConnectionString As String

        Private Shared fDataLayer As IDataLayer
        Private Shared ReadOnly Property DataLayer() As IDataLayer
            Get
                If fDataLayer Is Nothing Then
                    SyncLock lockObject
                        fDataLayer = GetDataLayer()
                    End SyncLock
                End If
                Return fDataLayer
            End Get
        End Property

        Private Shared Function GetDataLayer() As IDataLayer
            XpoDefault.Session = Nothing

            'Dim ds As New InMemoryDataStore()
            'string connectionString = AccessConnectionProvider.GetConnectionString(@"...\XPO_Membership\App_Data\my.mdb");
            'IDataStore ds = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema);
            '  Dim connectionString As String
            '  connectionString = MSSqlConnectionProvider.GetConnectionString("ALLIANCE-MMOL", "webClient", "longivory58", "Gus")

            Try
                XpoConnectionString = WebConfigurationManager.ConnectionStrings(Environment.MachineName).ConnectionString
            Catch ex As Exception

            End Try


            If XpoConnectionString Is Nothing Then
                Try
                    XpoConnectionString = WebConfigurationManager.ConnectionStrings("Willow").ConnectionString
                Catch ex As Exception

                End Try

            End If

            If XpoConnectionString Is Nothing Then
                XpoConnectionString = "XpoProvider=MSSqlServer;data source=ALLIANCE-MMOL;integrated security=SSPI;initial catalog=Gus"
            End If

            Dim ds As IDataStore = XpoDefault.GetConnectionProvider(XpoConnectionString, AutoCreateOption.SchemaAlreadyExists)
            Dim dict As XPDictionary = New ReflectionDictionary()
            dict.GetDataStoreSchema(GetType(GlobalUser).Assembly)

            Return New ThreadSafeDataLayer(dict, ds)
        End Function

        Private Shared Sub CreateDefaultObjects()
            Dim status As MembershipCreateStatus
            'Membership.CreateUser("test", "test", "just@ask.me", "The answer is ""test""", "test", True, status)
            'Membership.CreateUser("admin", "admin", "admin@ask.me", "The answer is ""admin""", "admin", True, status)
            'Membership.CreateUser("admin3", "admin3", "admin3@ask.me", "The answer is admin", "admin", True, status)
            'for (Int32 i = 0; i < 300; i++) {
            '    Membership.CreateUser(String.Format("test{0}", i), "test", String.Format("just{0}@ask.me", i), "The answer is \"test\"", "test", true, out status);
            '}
        End Sub

        Public Shared Function CreateMadCapUser(_consultant As Consultant, _name As String, _password As String, _email As String) As MembershipCreateStatus
            Dim status As MembershipCreateStatus
            Dim _muser As MembershipUser = Membership.CreateUser(_name, _password, _email, "", "", True, status)
            If _muser IsNot Nothing Then
                Using _session As UnitOfWork = GetNewUnitOfWork()

                    Dim _user As GlobalUser = _session.GetObjectByKey(Of GlobalUser)(_muser.ProviderUserKey)
                    If _user IsNot Nothing Then
                        _user.Save()
                    End If
                    _session.CommitChanges()
                End Using
            End If
            Return status
        End Function
        Public Shared Function GetMadCapUser(ByVal providerUserKey As Object) As MembershipUser

            Dim _muser As MembershipUser = Membership.GetUser(providerUserKey, False)
            Return _muser
        End Function

        Public Shared Function CreateWebClientUser(_client As Client, _name As String, _password As String, _email As String) As MembershipCreateStatus
            Dim status As MembershipCreateStatus
            Dim _muser As MembershipUser = Membership.CreateUser(_name, _password, _email, "", "", True, status)
            If _muser IsNot Nothing Then
                Using _session As UnitOfWork = GetNewUnitOfWork()

                    Dim _user As GlobalUser = _session.GetObjectByKey(Of GlobalUser)(_muser.ProviderUserKey)
                    _session.CommitChanges()
                End Using
            End If
            Return status
        End Function
        Public Shared Function GetWebClientUser(ByVal providerUserKey As Object) As MembershipUser

            Dim _muser As MembershipUser = Membership.GetUser(providerUserKey, False)
            Return _muser
        End Function
    End Class
End Namespace
