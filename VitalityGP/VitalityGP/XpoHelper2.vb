Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports System.Threading
Imports System.Collections.Concurrent

Public NotInheritable Class XpoHelper2
    Private Sub New()
    End Sub
    Public Enum Database
        XpoWebTest = 0
        CRM = 1
    End Enum
    Private Shared ReadOnly lockObject As New Object()
    Private Shared ConcurrentLayerDictionary As New ConcurrentDictionary(Of Database, IDataLayer)()
    Public Shared Function GetNewSession(db As Database) As Session
        Return New Session(GetDataLayer(db))
    End Function
    Private Shared Function GetDataLayer(db As Database) As IDataLayer
        Dim dal As IDataLayer
        If ConcurrentLayerDictionary.TryGetValue(db, dal) Then
            Return dal
        End If
        SyncLock lockObject
            Return ConcurrentLayerDictionary.GetOrAdd(db, CreateDataLayer)
        End SyncLock
    End Function
    Private Shared CreateDataLayer As  _
    Func(Of Database, IDataLayer) = _
    Function(db)
        Dim conn As String
        Dim dict As XPDictionary
        Dim store As IDataStore
        Dim dl As IDataLayer

        Select Case db
            Case Database.XpoWebTest

                If Environment.MachineName = "JOHN-PC2" Then
                    conn = MSSqlConnectionProvider.GetConnectionString("JOHN-PC2\SQLEXPRESS", "madcap", "ferrett", "VitalityGP")
                Else
                    conn = MSSqlConnectionProvider.GetConnectionString("ALLIANCE-RS", "CRM", "ferrett", "VitalityGP") + ";Connect Timeout=60"
                End If

                dict = New ReflectionDictionary()
                store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaOnly)
                dict.GetDataStoreSchema(GetType(vitop).Assembly)
                Exit Select
            Case Database.CRM


                '   CRM.ConnectionHelper.Connect(..Connect(AutoCreateOption.SchemaAlreadyExists

                If Environment.MachineName = "JOHN-PC2" Then
                    conn = MSSqlConnectionProvider.GetConnectionString("JOHN-PC2\SQLEXPRESS", "madcap", "ferrett", "VitalityGP")
                Else
                    conn = MSSqlConnectionProvider.GetConnectionString("ALLIANCE-RS", "madcap", "ferrett", "CRM")
                End If
                dict = New ReflectionDictionary()
                store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists)
                '    dict.GetDataStoreSchema(GetType(VitGP).Assembly)
                Exit Select
            Case Else
                Throw New Exception("Unknown database")
        End Select
        dl = New ThreadSafeDataLayer(dict, store)
        Return dl

    End Function

End Class