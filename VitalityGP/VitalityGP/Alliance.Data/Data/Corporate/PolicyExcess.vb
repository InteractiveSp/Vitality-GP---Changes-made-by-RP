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
    Public Class PolicyExcess
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            Me.New(session)
        End Sub
        Private _client As Client
        Public Property Client() As Client
            Get
                Return _client
            End Get
            Set(ByVal value As Client)
                SetPropertyValue(Of Client)("Client", _client, value)
            End Set
        End Property
        Private _policy As Policy
        Public Property Policy() As Policy
            Get
                Return _policy
            End Get
            Set(ByVal value As Policy)
                SetPropertyValue(Of Policy)("Policy", _policy, value)
            End Set
        End Property
        Private _Employee As Beneficiary
        Public Property Employee() As Beneficiary
            Get
                Return _Employee
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Employee", _Employee, value)
            End Set
        End Property
        Private _Beneficiary As Beneficiary
        <Association("Beneficiary-PolicyExcess")> _
        Public Property Beneficiary() As Beneficiary
            Get
                Return _Beneficiary
            End Get
            Set(ByVal value As Beneficiary)
                SetPropertyValue(Of Beneficiary)("Beneficiary", _Beneficiary, value)
            End Set
        End Property
        <Association("PolicyeXcess-InvoiceLines")> _
        Public ReadOnly Property InvoiceLines() As XPCollection(Of InvoiceLine)
            Get
                Return GetCollection(Of InvoiceLine)("InvoiceLines")
            End Get
        End Property
        Private _ExcessType As eeXcessType
        Public Property ExcessType() As eeXcessType
            Get
                Return _ExcessType
            End Get
            Set(ByVal value As eeXcessType)
                SetPropertyValue(Of eeXcessType)("ExcessType", _ExcessType, value)
            End Set
        End Property
        Private _excess As Double
        Public Property Excess() As Double
            Get
                Return _excess
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Excess", _excess, value)
            End Set
        End Property
        Private _costshare As Double
        Public Property CostSharePerc() As Double
            Get
                Return _costshare
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("CostSharePerc", _costshare, value)
            End Set
        End Property
        Private _incurred As Double
        Public Property Incurred() As Double
            Get
                Return _incurred
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Incurred", _incurred, value)
            End Set
        End Property
        Private _incurredDate As Date
        Public Property IncurredDate() As Date
            Get
                Return _incurredDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("IncurredDate", _incurredDate, value)
            End Set
        End Property
        Private _paid As Double
        Public Property Paid() As Double
            Get
                Return _paid
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Paid", _paid, value)
            End Set
        End Property
        Private _Letter As Integer
        Public Property Letter() As Integer
            Get
                Return _Letter
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Letter", _Letter, value)
            End Set
        End Property
        Private _Letterdate As DateTime
        Public Property LetterDate() As DateTime
            Get
                Return _Letterdate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LetterDate", _Letterdate, value)
            End Set
        End Property

        Private _Letterdate2 As DateTime
        Public Property LetterDate2() As DateTime
            Get
                Return _Letterdate2
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LetterDate2", _Letterdate2, value)
            End Set
        End Property

        Private _Letterdate3 As DateTime
        Public Property LetterDate3() As DateTime
            Get
                Return _Letterdate3
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LetterDate3", _Letterdate3, value)
            End Set
        End Property

        Private _printbatch As Integer
        Public Property PrintBatch() As Integer
            Get
                Return _printbatch
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PrintBatch", _printbatch, value)
            End Set
        End Property


    End Class

    'Public Class PolicyExcessDetail
    '    Inherits XPObject
    '    Public Sub New(ByVal session As Session)
    '        MyBase.New(session)
    '    End Sub
    '    Public Sub New(ByVal session As Session, ByVal name As String)
    '        Me.New(session)
    '    End Sub
    '    Private _PolicyExcess As PolicyExcess
    '    <Association("PolicyExcess-Incurred")> _
    '    Public Property PolicyExcess() As PolicyExcess
    '        Get
    '            Return _PolicyExcess
    '        End Get
    '        Set(ByVal value As PolicyExcess)
    '            SetPropertyValue(Of PolicyExcess)("PolicyExcess", _PolicyExcess, value)
    '        End Set
    '    End Property
    '    Private _invoiceLine As InvoiceLine
    '    Public Property InvoiceLine() As InvoiceLine
    '        Get
    '            Return _invoiceLine
    '        End Get
    '        Set(ByVal value As InvoiceLine)
    '            SetPropertyValue(Of InvoiceLine)("InvoiceLine", _invoiceLine, value)
    '        End Set
    '    End Property
    '    Private _incurred As Double
    '    Public Property Incurred() As Double
    '        Get
    '            Return _incurred
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Incurred", _incurred, value)
    '        End Set
    '    End Property
    '    Private _paid As Double
    '    Public Property Paid() As Double
    '        Get
    '            Return _paid
    '        End Get
    '        Set(ByVal value As Double)
    '            SetPropertyValue(Of Double)("Paid", _paid, value)
    '        End Set
    '    End Property
    '    Private _ExternallyCollected As Boolean
    '    Public Property ExternallyCollected() As Boolean
    '        Get
    '            Return _ExternallyCollected
    '        End Get
    '        Set(ByVal value As Boolean)
    '            SetPropertyValue(Of Boolean)("ExternallyCollected", _ExternallyCollected, value)
    '        End Set
    '    End Property
    '    Private _paymentRecord As PaymentRecord
    '    Public Property PaymentRecord() As PaymentRecord
    '        Get
    '            Return _paymentRecord
    '        End Get
    '        Set(ByVal value As PaymentRecord)
    '            SetPropertyValue(Of PaymentRecord)("Payment", _paymentRecord, value)
    '        End Set
    '    End Property
    'End Class
End Namespace