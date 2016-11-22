Imports System
Imports DevExpress.Xpo
Imports System.Collections.Generic
Imports DevExpress.Xpo.Metadata
Imports System.Collections


Namespace Alliance.Data
    Public Class CloneHelper
        Implements IDisposable

        Private ReadOnly clonedObjects As Dictionary(Of Object, Object)
        Private ReadOnly targetSession As Session

        Public Sub New(ByVal targetSession As Session)
            clonedObjects = New Dictionary(Of Object, Object)()
            Me.targetSession = targetSession
        End Sub

        Public Function Clone(Of T)(ByVal source As T) As T
            Return Clone(Of T)(source, False)
        End Function
        Public Function Clone(Of T)(ByVal source As T, ByVal synchronize As Boolean) As T
            Return CType(Clone(DirectCast(source, Object), synchronize), T)
        End Function
        Public Function Clone(ByVal source As Object) As Object
            Return Clone(source, False)
        End Function

        ''' <param name="synchronize">If set to true, reference properties are only cloned in case
        ''' the reference object does not exist in the targetsession. Otherwise the exising object will be
        ''' reused and synchronized with the source. Set this property to false when knowing at forehand 
        ''' that the targetSession will not contain any of the objects of the source.</param>
        ''' <returns></returns>
        Public Function Clone(ByVal source As Object, ByVal synchronize As Boolean) As Object
            If source Is Nothing Then
                Return Nothing
            End If
            Dim targetClassInfo As XPClassInfo = targetSession.GetClassInfo(source.GetType())
            Dim target As Object = targetClassInfo.CreateNewObject(targetSession)
            clonedObjects.Add(source, target)

            For Each m As XPMemberInfo In targetClassInfo.PersistentProperties
                CloneProperty(m, source, target, synchronize)
            Next m
            For Each m As XPMemberInfo In targetClassInfo.CollectionProperties
                CloneCollection(m, source, target, synchronize)
            Next m
            Return target
        End Function
        Private Sub CloneProperty(ByVal memberInfo As XPMemberInfo, ByVal source As Object, ByVal target As Object, ByVal synchronize As Boolean)
            If TypeOf memberInfo Is DevExpress.Xpo.Metadata.Helpers.ServiceField OrElse memberInfo.IsKey Then
                Return
            End If
            Dim clonedValue As Object = Nothing
            If memberInfo.ReferenceType IsNot Nothing Then
                Dim value As Object = memberInfo.GetValue(source)
                If value IsNot Nothing Then
                    value = CloneValue(value, synchronize, False)
                End If
            Else
                clonedValue = memberInfo.GetValue(source)
            End If
            memberInfo.SetValue(target, clonedValue)
        End Sub
        Private Sub CloneCollection(ByVal memberInfo As XPMemberInfo, ByVal source As Object, ByVal target As Object, ByVal synchronize As Boolean)
            If memberInfo.IsAssociation AndAlso (memberInfo.IsManyToMany OrElse memberInfo.IsAggregated) Then
                Dim colTarget As XPBaseCollection = CType(memberInfo.GetValue(target), XPBaseCollection)
                Dim colSource As XPBaseCollection = CType(memberInfo.GetValue(source), XPBaseCollection)
                For Each obj As IXPSimpleObject In colSource
                    colTarget.BaseAdd(CloneValue(obj, synchronize, (Not memberInfo.IsManyToMany)))
                Next obj
            End If
        End Sub
        Private Function CloneValue(ByVal propertyValue As Object, ByVal synchronize As Boolean, ByVal cloneAlways As Boolean) As Object
            If clonedObjects.ContainsKey(propertyValue) Then
                Return clonedObjects(propertyValue)
            End If
            Dim clonedValue As Object = Nothing
            If synchronize AndAlso (Not cloneAlways) Then
                clonedValue = targetSession.GetObjectByKey(targetSession.GetClassInfo(propertyValue), targetSession.GetKeyValue(propertyValue))
            End If
            If clonedValue Is Nothing Then
                clonedValue = Clone(propertyValue, synchronize)
            End If
            Return clonedValue
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose
            If targetSession IsNot Nothing Then
                targetSession.Dispose()
            End If
        End Sub
    End Class

End Namespace