Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo.DB.Exceptions
Imports System.Threading
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Security.Cryptography
Imports System.Collections
Imports DevExpress.Xpo.Metadata
Imports System.Reflection
Imports System.ComponentModel

Namespace Alliance.Shared.Helpers
    Public Interface IExceptionProcesser
        Sub Process(ByVal e As Exception)
    End Interface
    Public Class SessionHelper

        Private Const xpoPrefix As String = "DevExpress.Xpo."
        Private Shared xpoServicesClasses() As String = {"PersistentBase", "XPBaseObject", "XPObjectType"}

        Private Shared _CommitInBackgroundWorker As IBackgroundWorker
        Private Shared _CommitInBackgroundSaveSessionPercentProgress As Double
        Private Shared _SaveSessionPercentPerObject As Double
        Public Shared Function CommitSession(ByVal session As UnitOfWork, ByVal exceptionProcesser As IExceptionProcesser) As Exception
            Try
                session.CommitChanges()
                Return Nothing
            Catch e As Exception
                If (Not Object.Equals(exceptionProcesser, Nothing)) Then
                    exceptionProcesser.Process(e)
                    Return e
                Else
                    Throw
                End If
            End Try
        End Function
        Public Shared Function GetObject(ByVal obj As Object, ByVal session As Session) As Object
            Dim xpObject As IXPSimpleObject = TryCast(obj, IXPSimpleObject)
            If Object.Equals(xpObject, Nothing) Then
                Return Nothing
            End If
            Do While xpObject.Session IsNot session AndAlso TypeOf xpObject.Session Is NestedUnitOfWork
                xpObject = CType((CType(xpObject.Session, NestedUnitOfWork)).GetParentObject(xpObject), IXPSimpleObject)
            Loop
            If xpObject.Session Is session Then
                Return xpObject
            End If
            Dim targetClassInfo As XPClassInfo = session.GetClassInfo(CType(xpObject, Object).GetType())
            Return session.GetObjectByKey(targetClassInfo, xpObject.Session.GetKeyValue(xpObject))
        End Function
        Public Shared Function GetObject(Of T)(ByVal obj As T, ByVal session As Session) As T
            Return CType(GetObject(CObj(obj), session), T)
        End Function
        Private Shared _CopySessionPercentProgress As Double
        Private Shared _CopySessionPercentProgressPerObject As Double
        Private Shared _CopySessionWorker As IBackgroundWorker
        Public Shared Sub CopySession(ByVal source As Session, ByVal target As Session, ByVal classes() As XPClassInfo, ByVal worker As IBackgroundWorker, ByVal maxProgress As Integer)
            _CopySessionWorker = worker
            Dim copiedObjects As New Dictionary(Of IXPSimpleObject, IXPSimpleObject)()
            If Object.Equals(_CopySessionWorker, Nothing) Then
                _CopySessionPercentProgress = 0
            Else
                _CopySessionPercentProgress = _CopySessionWorker.ReportedProgress
            End If
            Dim objectsForCopy As Dictionary(Of IXPSimpleObject, Boolean) = GetObjectsForCopy(source, classes)
            Dim percentInterval As Double = maxProgress - _CopySessionPercentProgress
            _CopySessionPercentProgressPerObject = 0.97 * percentInterval / objectsForCopy.Keys.Count
            _CopySessionPercentProgress += 0.03 * percentInterval
            If (Not Object.Equals(_CopySessionWorker, Nothing)) Then
                _CopySessionWorker.ReportProgress(CInt(Fix(_CopySessionPercentProgress)))
            End If
            Dim cloneHelper As New XPObjectCloneHelper(target, copiedObjects, AddressOf AnonymousMethod1)
            For Each obj As IXPSimpleObject In objectsForCopy.Keys
                If (Not copiedObjects.ContainsKey(obj)) Then
                    cloneHelper.Clone(obj)
                End If
            Next obj
            If (Not Object.Equals(_CopySessionWorker, Nothing)) Then
                _CopySessionWorker.ReportProgress(maxProgress)
            End If
        End Sub

        Private Shared Sub AnonymousMethod1(ByVal sender As Object, ByVal e As EventArgs)
            OnObjectCopied()
        End Sub
        Private Shared Sub OnObjectCopied()
            _CopySessionPercentProgress += _CopySessionPercentProgressPerObject
            If (Not Object.Equals(_CopySessionWorker, Nothing)) Then
                _CopySessionWorker.ReportProgress(CInt(Fix(_CopySessionPercentProgress)))
            End If
        End Sub
        Private Shared Function GetObjectsForCopy(ByVal session As Session, ByVal classes() As XPClassInfo) As Dictionary(Of IXPSimpleObject, Boolean)
            Dim objectsForCopy As New Dictionary(Of IXPSimpleObject, Boolean)()
            For Each classInfo As XPClassInfo In classes
                Dim isServiceClass As Boolean = False
                For Each className As String In xpoServicesClasses
                    If classInfo.FullName = xpoPrefix & className Then
                        isServiceClass = True
                        Exit For
                    End If
                Next className
                If isServiceClass Then
                    Continue For
                End If
                Dim objects As New XPCollection(session, classInfo)
                For Each obj As IXPSimpleObject In objects
                    If TypeOf obj Is DevExpress.Xpo.Metadata.Helpers.IntermediateObject Then
                        Continue For
                    End If
                    If objectsForCopy.ContainsKey(obj) Then
                        Continue For
                    End If
                    objectsForCopy.Add(obj, True)
                Next obj
            Next classInfo
            Return objectsForCopy
        End Function
    End Class
    Public Class MD5StringEncoder
        Public Shared Function CalcHash(ByVal data As String) As String
            Dim ret As String = ""
            Try
                Using mem As New MemoryStream()
                    Dim bWriter As New BinaryWriter(mem)
                    bWriter.Write(data)
                    mem.Position = 0
                    Dim md5 As System.Security.Cryptography.MD5 = New System.Security.Cryptography.MD5CryptoServiceProvider()
                    Dim res() As Byte = md5.ComputeHash(mem)
                    bWriter.Close()
                    For i As Integer = 0 To res.Length - 1
                        ret &= ChrW(res(i))
                    Next i
                End Using
            Catch
                ret = "N/A"
            End Try
            Return ret
        End Function
    End Class
    Public Interface IBackgroundWorker
        Event DoWork As DoWorkEventHandler
        Event RunWorkerCompleted As RunWorkerCompletedEventHandler
        Event ProgressChanged As ProgressChangedEventHandler
        ReadOnly Property CancellationPending() As Boolean
        ReadOnly Property IsBusy() As Boolean
        Property WorkerReportsProgress() As Boolean
        Property WorkerSupportsCancellation() As Boolean
        Sub CancelAsync()
        Sub ReportProgress(ByVal percentProgress As Integer)
        Sub ReportProgress(ByVal percentProgress As Integer, ByVal userState As Object)
        Sub RunWorkerAsync()
        Sub RunWorkerAsync(ByVal argument As Object)
        ReadOnly Property ReportedProgress() As Integer
    End Interface
    Public Class StandartBackgroundWorker
        Implements IBackgroundWorker
        Private worker As New BackgroundWorker()
        Private freportedProgress As Integer = 0
        Public Event DoWork As DoWorkEventHandler Implements IBackgroundWorker.DoWork
        Public Event RunWorkerCompleted As RunWorkerCompletedEventHandler Implements IBackgroundWorker.RunWorkerCompleted
        Public Event ProgressChanged As ProgressChangedEventHandler Implements IBackgroundWorker.ProgressChanged
        Public Sub New()
            MyBase.New()
            worker.WorkerReportsProgress = True
            AddHandler worker.DoWork, AddressOf worker_DoWork
            AddHandler worker.RunWorkerCompleted, AddressOf worker_RunWorkerCompleted
            AddHandler worker.ProgressChanged, AddressOf worker_ProgressChanged
        End Sub
        Public ReadOnly Property CancellationPending() As Boolean Implements IBackgroundWorker.CancellationPending
            Get
                Return worker.CancellationPending
            End Get
        End Property
        Public ReadOnly Property IsBusy() As Boolean Implements IBackgroundWorker.IsBusy
            Get
                Return worker.IsBusy
            End Get
        End Property
        <DefaultValue(True)> _
        Public Property WorkerReportsProgress() As Boolean Implements IBackgroundWorker.WorkerReportsProgress
            Get
                Return worker.WorkerReportsProgress
            End Get
            Set(ByVal value As Boolean)
                worker.WorkerReportsProgress = value
            End Set
        End Property
        <DefaultValue(False)> _
        Public Property WorkerSupportsCancellation() As Boolean Implements IBackgroundWorker.WorkerSupportsCancellation
            Get
                Return worker.WorkerSupportsCancellation
            End Get
            Set(ByVal value As Boolean)
                worker.WorkerSupportsCancellation = value
            End Set
        End Property
        Public Sub CancelAsync() Implements IBackgroundWorker.CancelAsync
            worker.CancelAsync()
        End Sub
        Public Sub ReportProgress(ByVal percentProgress As Integer) Implements IBackgroundWorker.ReportProgress
            If percentProgress <= freportedProgress Then
                Return
            End If
            freportedProgress = percentProgress
            worker.ReportProgress(freportedProgress)
        End Sub
        Public Sub ReportProgress(ByVal percentProgress As Integer, ByVal userState As Object) Implements IBackgroundWorker.ReportProgress
            If percentProgress <= freportedProgress Then
                Return
            End If
            freportedProgress = percentProgress
            worker.ReportProgress(freportedProgress, userState)
        End Sub
        Public Sub RunWorkerAsync() Implements IBackgroundWorker.RunWorkerAsync
            worker.RunWorkerAsync()
        End Sub
        Public Sub RunWorkerAsync(ByVal argument As Object) Implements IBackgroundWorker.RunWorkerAsync
            worker.RunWorkerAsync(argument)
        End Sub
        Private Sub worker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
            If (Not Object.Equals(DoWorkEvent, Nothing)) Then
                RaiseEvent DoWork(Me, e)
            End If
        End Sub
        Private Sub worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
            If (Not Object.Equals(RunWorkerCompletedEvent, Nothing)) Then
                RaiseEvent RunWorkerCompleted(Me, e)
            End If
        End Sub
        Private Sub worker_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
            If (Not Object.Equals(ProgressChangedEvent, Nothing)) Then
                RaiseEvent ProgressChanged(Me, e)
            End If
        End Sub
        Public ReadOnly Property ReportedProgress() As Integer Implements IBackgroundWorker.ReportedProgress
            Get
                Return freportedProgress
            End Get
        End Property
    End Class
    Public Class XPObjectCloneHelper
        Private targetSession As Session
        Private copiedObjects As Dictionary(Of IXPSimpleObject, IXPSimpleObject)
        Private objectCopied As EventHandler

        Public Sub New(ByVal targetSession As Session, ByVal copiedObjects As Dictionary(Of IXPSimpleObject, IXPSimpleObject), ByVal objectCopied As EventHandler)
            Me.targetSession = targetSession
            If (Not Object.Equals(copiedObjects, Nothing)) Then
                Me.copiedObjects = copiedObjects
            Else
                Me.copiedObjects = New Dictionary(Of IXPSimpleObject, IXPSimpleObject)()
            End If
            Me.objectCopied = objectCopied
        End Sub
        Public Function Clone(ByVal source As IXPSimpleObject) As IXPSimpleObject
            If source Is Nothing Then
                Return Nothing
            End If
            If copiedObjects.ContainsKey(source) Then
                Return copiedObjects(source)
            End If
            Dim targetClassInfo As XPClassInfo = targetSession.GetClassInfo(CType(source, Object).GetType())
            Dim clonedObject As IXPSimpleObject = CType(targetClassInfo.CreateNewObject(targetSession), IXPSimpleObject)
            copiedObjects.Add(source, clonedObject)
            If objectCopied IsNot Nothing Then
                objectCopied(Me, EventArgs.Empty)
            End If
            For Each m As XPMemberInfo In targetClassInfo.PersistentProperties
                If TypeOf m Is DevExpress.Xpo.Metadata.Helpers.ServiceField OrElse m.IsKey Then
                    Continue For
                End If
                Dim val As Object
                If m.ReferenceType IsNot Nothing Then
                    val = Me.Clone(CType(m.GetValue(source), IXPSimpleObject))
                Else
                    val = m.GetValue(source)
                End If
                m.SetValue(clonedObject, val)
            Next m
            For Each m As XPMemberInfo In targetClassInfo.CollectionProperties
                Dim col As XPBaseCollection = CType(m.GetValue(clonedObject), XPBaseCollection)
                Dim colSource As XPBaseCollection = CType(m.GetValue(source), XPBaseCollection)
                For Each obj As IXPSimpleObject In New ArrayList(colSource)
                    col.BaseAdd(Me.Clone(obj))
                Next obj
            Next m
            Dim indexedProperties As Dictionary(Of String, Object) = RetrieveIndexedProperties(targetClassInfo, clonedObject)
            If indexedProperties.Count > 0 Then
                Dim requestString As String = BuildRequest(indexedProperties)
                Dim values() As Object = BuildValuesArray(indexedProperties)
                Dim foundedClone As IXPSimpleObject = CType(targetSession.FindObject(PersistentCriteriaEvaluationBehavior.InTransaction, targetClassInfo, CriteriaOperator.Parse(requestString, values)), IXPSimpleObject)
                If foundedClone IsNot Nothing AndAlso foundedClone IsNot clonedObject Then
                    CType(foundedClone, XPBaseObject).Delete()
                End If
            End If
            Return clonedObject
        End Function
        Private Shared Function BuildValuesArray(ByVal indexedProperties As Dictionary(Of String, Object)) As Object()
            Dim values As New List(Of Object)()
            For Each name As String In indexedProperties.Keys
                values.Add(indexedProperties(name))
            Next name
            Return values.ToArray()
        End Function
        Private Shared Function BuildRequest(ByVal indexedProperties As Dictionary(Of String, Object)) As String
            Dim fieldNames As New StringBuilder()
            Dim isFirst As Boolean = True
            For Each name As String In indexedProperties.Keys
                If isFirst Then
                    isFirst = False
                    fieldNames.AppendFormat("{0} = ?", name)
                Else
                    fieldNames.AppendFormat(" and {0} = ?", name)
                End If
            Next name
            Return fieldNames.ToString()
        End Function
        Private Shared Function RetrieveIndexedProperties(ByVal classInfo As XPClassInfo, ByVal source As IXPSimpleObject) As Dictionary(Of String, Object)
            Dim indexedProperties As New Dictionary(Of String, Object)()
            For Each item As XPMemberInfo In classInfo.PersistentProperties
                If item.HasAttribute(GetType(IndexedAttribute)) Then
                    Dim attribute As IndexedAttribute = CType(item.GetAttributeInfo(GetType(IndexedAttribute)), IndexedAttribute)
                    If attribute.Unique Then
                        indexedProperties.Add(item.Name, item.GetValue(source))
                    Else
                        Continue For
                    End If
                    If attribute.AdditionalFields IsNot Nothing AndAlso attribute.AdditionalFields.Count > 0 Then
                        For Each fieldName As String In attribute.AdditionalFields
                            indexedProperties.Add(fieldName, classInfo.GetMember(fieldName).GetValue(source))
                        Next fieldName
                    End If
                End If
            Next item
            Return indexedProperties
        End Function
    End Class
    Public Class ResourcesHelper
        Public Shared Function GetXmlDbFileFromResource() As String
            Dim _Path As String = Path.GetTempFileName()
            Using file As New FileStream(_Path, FileMode.Open)
                Using writer As New BinaryWriter(file)
                    ' writer.Write(My.Resources.VideoRent, 0, My.Resources.VideoRent.Length)
                End Using
            End Using
            Return _Path
        End Function
    End Class
End Namespace
