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

    Public Class PrinterOutPut
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _documentType As String
        <Size(30)>
        Public Property DocumentType() As String
            Get
                Return _documentType
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DocumentType", _documentType, value)
            End Set
        End Property
        Private _destination As String
        <Size(60)>
        Public Property Destination() As String
            Get
                Return _destination
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Destination", _destination, value)
            End Set
        End Property
    End Class

End Namespace