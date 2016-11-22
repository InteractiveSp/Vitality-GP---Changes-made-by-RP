Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports Alliance.Data.ConnectionHelper
Imports DevExpress.Data.Filtering

Namespace Alliance.Data
    Public Class Callout
        Inherits XPCustomObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _OID As Integer
        <Key>
        Public Property Oid() As Integer
            Get
                Return _OID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Oid", _OID, value)
            End Set
        End Property
        Private _callOutNo As eCallOut
        Public Property CallOutNo() As eCallOut
            Get
                Return _callOutNo
            End Get
            Set(ByVal value As eCallOut)
                SetPropertyValue(Of eCallOut)("CallOutNo", _callOutNo, value)
            End Set
        End Property
        Private _description As String
        <Size(50)>
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", _description, value)
            End Set
        End Property
        Private _richtext As String
        <Size(SizeAttribute.Unlimited)>
        Public Property Richtext() As String
            Get
                Return _richtext
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Richtext", _richtext, value)
            End Set
        End Property
    End Class
End Namespace