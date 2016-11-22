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
    Public Class Attrib
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _attributeType As eAttributeType
        Public Property AttributeType() As eAttributeType
            Get
                Return _attributeType
            End Get
            Set(ByVal value As eAttributeType)
                SetPropertyValue(Of eAttributeType)("AttributeType", _attributeType, value)
            End Set
        End Property
        Private _attribute As String
        <Size(20)> _
        Public Property Attribute() As String
            Get
                Return _attribute
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Attribute", _attribute, value)
            End Set
        End Property
        <Association, Browsable(False)> _
        Public ReadOnly Property HospitalAttributes() As IList(Of HospitalAttribute)
            Get
                Return GetList(Of HospitalAttribute)("HospitalAttributes")
            End Get
        End Property
        <ManyToManyAlias("HospitalAttributes", "Hospital")> _
        Public ReadOnly Property Hospitals() As IList(Of Hospital)
            Get
                Return GetList(Of Hospital)("Hospitals")
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return String.Format("{0}", Attribute)
        End Function
    End Class
End Namespace