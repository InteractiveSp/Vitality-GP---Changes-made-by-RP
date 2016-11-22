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

    Public Class ExchequerLookup
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _fieldname As String
        <Size(10)>
        Public Property Fieldname() As String
            Get
                Return _fieldname
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Fieldname", _fieldname, value)
            End Set
        End Property
        Private _code As String
        <Size(10)>
        Public Property Code() As String
            Get
                Return _code
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", _code, value)
            End Set
        End Property
        Private _description As String
        <Size(40)>
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", _description, value)
            End Set
        End Property
        Private _CodeType As String
        <Size(1)>
        Public Property CodeType() As String
            Get
                Return _CodeType
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CodeType", _CodeType, value)
            End Set
        End Property
        Private _JobCostingAnalysis As String
        <Size(7)>
        Public Property JobCostingAnalysis() As String
            Get
                Return _JobCostingAnalysis
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("JobCostingAnalysis", _JobCostingAnalysis, value)
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0} {1}", Code, Description)
        End Function
    End Class

End Namespace