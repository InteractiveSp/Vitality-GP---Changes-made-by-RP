Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports System.Drawing
Imports Alliance.Data.ConnectionHelper
Imports DevExpress.Data.Filtering

Namespace Alliance.Data
    'Public Class CardRecord
    '    Inherits XPObject
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Public Sub New(ByVal session As Session, ByVal name As String)
    '        Me.New(session)
    '    End Sub
    '    Private _createdDate As Date
    '    Public Property CreatedDate() As Date
    '        Get
    '            Return _createdDate
    '        End Get
    '        Set(ByVal value As Date)
    '            SetPropertyValue(Of Date)("CreatedDate", _createdDate, value)
    '        End Set
    '    End Property
    '    Private _token As String
    '    <Size(40)> _
    '    Public Property Token() As String
    '        Get
    '            Return _token
    '        End Get
    '        Set(ByVal value As String)
    '            SetPropertyValue(Of String)("Token", _token, value)
    '        End Set
    '    End Property
    '    Private _patient As Patient
    '    Public Property Patient() As Patient
    '        Get
    '            Return _patient
    '        End Get
    '        Set(ByVal value As Patient)
    '            SetPropertyValue(Of Patient)("Patient", _patient, value)
    '        End Set
    '    End Property
    'End Class
    Public Class PaymentRecord
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
        End Sub
        Private _paymentDate As Date
        Public Property PaymentDate() As Date
            Get
                Return _paymentDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("PaymentDate", _paymentDate, value)
            End Set
        End Property
        Private _value As Double
        Public Property Value() As Double
            Get
                Return _value
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Value", _value, value)
            End Set
        End Property
    End Class
End Namespace
