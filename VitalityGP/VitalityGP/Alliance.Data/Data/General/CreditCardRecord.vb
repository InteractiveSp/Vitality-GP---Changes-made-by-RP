Imports DevExpress.Xpo
Imports Alliance.Data
Imports System.Globalization
Imports System
Imports System.Collections.Generic
Imports DevExpress.Data.Filtering

Public Class CreditCardRecord
    Inherits XPObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Sub New(ByVal session As Session, ByVal name As String)
        Me.New(session)
    End Sub
    Private strVPSProtocol As String
    <Size(4)>
       Public Property VPSProtocol As String
        Get
            Return strVPSProtocol
        End Get
        Set(ByVal value As String)
            strVPSProtocol = value
        End Set
    End Property

    Private _Patient As Patient
    Public Property Patient() As Patient
        Get
            Return _Patient
        End Get
        Set(ByVal value As Patient)
            SetPropertyValue(Of Patient)("Patient", _Patient, value)
        End Set
    End Property

    Private _Beneficiary As Beneficiary
    Public Property Beneficiary() As Beneficiary
        Get
            Return _Beneficiary
        End Get
        Set(ByVal value As Beneficiary)
            SetPropertyValue(Of Beneficiary)("Beneficiary", _Beneficiary, value)
        End Set
    End Property
    Private Property _Referral As Referral
    Public Property Referral() As Referral
        Get
            Return _Referral
        End Get
        Set(ByVal value As Referral)
            SetPropertyValue(Of Referral)("Referral", _Referral, value)
        End Set
    End Property


    Private strStatus As String
    <Size(15)>
       Public Property Status As String
        Get
            Return strStatus
        End Get
        Set(ByVal value As String)

            Select Case value.ToUpper
                Case "OK" : strStatus = "OK"
                Case "NOTAUTHED" : strStatus = "NOTAUTHED"
                Case "REJECTED" : strStatus = "REJECTED"
                Case "AUTHENTICATED" : strStatus = "AUTHENTICATED"
                Case "REGISTERED" : strStatus = "REGISTERED"
                Case "3DAUTH" : strStatus = "3DAUTH"
                Case "PPREDIRECT" : strStatus = "PPREDIRECT"
                Case "MALFORMED" : strStatus = "MALFORMED"
                Case "INVALID" : strStatus = "INVALID"
                Case "ERROR" : strStatus = "ERROR"
            End Select
        End Set
    End Property

    Private strStatusDetail As String
    <Size(255)>
       Public Property StatusDetail As String
        Get
            Return strStatusDetail
        End Get
        Set(ByVal value As String)
            strStatusDetail = value
        End Set
    End Property

    Private strVPSTxId As String
    <Size(38)>
       Public Property VPSTxId As String
        Get
            Return strVPSTxId
        End Get
        Set(value As String)
            strVPSTxId = value
        End Set
    End Property

    Private strSecurityKey As String
    <Size(10)>
       Public Property SecurityKey As String
        Get
            Return strSecurityKey
        End Get
        Set(value As String)
            strSecurityKey = value
        End Set
    End Property

    Private strTxAuthNo As String
    <Size(10)>
       Public Property TxAuthNo As String
        Get
            Return strTxAuthNo
        End Get
        Set(value As String)
            strTxAuthNo = value
        End Set
    End Property

    Private strAVSCV2 As String
    <Size(50)>
       Public Property AVSCV2 As String
        Get
            Return strAVSCV2
        End Get
        Set(value As String)
            strAVSCV2 = value
        End Set
    End Property

    Private strAddressResult As String
    <Size(20)>
       Public Property AddressResult As String
        Get
            Return strAddressResult
        End Get
        Set(value As String)
            strAddressResult = value
        End Set
    End Property

    Private strPostCodeResult As String
    <Size(20)>
       Public Property PostCodeResult As String
        Get
            Return strPostCodeResult
        End Get
        Set(value As String)
            strPostCodeResult = value
        End Set
    End Property

    Private strCV2Result As String
    <Size(20)>
       Public Property CV2Result As String
        Get
            Return strCV2Result
        End Get
        Set(value As String)
            strCV2Result = value
        End Set
    End Property

    Private str3DSecureStatus As String
    <Size(50)>
       Public Property _3DSecureStatus As String
        Get
            Return str3DSecureStatus
        End Get
        Set(value As String)
            str3DSecureStatus = value
        End Set
    End Property

    Private strCAVV As String
    <Size(32)>
       Public Property CAVV As String
        Get
            Return strCAVV
        End Get
        Set(value As String)
            If value IsNot Nothing Then
                strCAVV = value
            Else
                strCAVV = ""
            End If
        End Set
    End Property

    Private strToken As String
    <Size(38)>
       Public Property Token As String
        Get
            Return strToken
        End Get
        Set(value As String)
            strToken = value
        End Set
    End Property

    Private strFraudResponse As String
    <Size(10)>
       Public Property FraudResponse As String
        Get
            Return strFraudResponse
        End Get
        Set(value As String)
            If value IsNot Nothing Then
                strFraudResponse = value
            Else
                strFraudResponse = ""
            End If
        End Set
    End Property

    Private strDeclineCode As String
    <Size(2)>
       Public Property DeclineCode As String
        Get
            Return strDeclineCode
        End Get
        Set(value As String)
            strDeclineCode = value
        End Set
    End Property

    Private dtExpiryDate As String
    <Size(4)>
       Public Property ExpiryDate As String
        Get
            Return dtExpiryDate
        End Get
        Set(value As String)
            'dtExpiryDate = DateTime.ParseExact(value, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces).ToString("MMYY")
            dtExpiryDate = value
        End Set
    End Property

    Private strBankAuthCode As String
    <Size(6)>
       Public Property BankAuthCode As String
        Get
            Return strBankAuthCode
        End Get
        Set(value As String)
            strBankAuthCode = value
        End Set
    End Property

    Public Property Surcharge As Decimal

    Private strVendorTxCode As String
    <Size(40)>
       Public Property VendorTxCode As String
        Get
            Return strVendorTxCode
        End Get
        Set(ByVal value As String)
            strVendorTxCode = value
        End Set
    End Property

    Private strLast4digits As String
    <Size(4)>
       Public Property Last4digits As String
        Get
            Return strLast4digits
        End Get
        Set(value As String)
            strLast4digits = value
        End Set
    End Property

    Private strTxType As String
    <Size(15)>
       Public Property TxType As String
        Get
            Return strTxType
        End Get
        Set(ByVal value As String)

            Select Case value.ToUpper
                Case "PAYMENT"
                    strTxType = "PAYMENT"
                Case "DEFERRED"
                    strTxType = "DEFERRED"
                Case "AUTHENTICATE"
                    strTxType = "AUTHENTICATE"
                Case "AUTHORISE"
                    strTxType = "AUTHORISE"
                Case "TOKEN"
                    strTxType = "TOKEN"
                Case "CANCEL"
                    strTxType = "CANCEL"
                Case "REFUND"
                    strTxType = "REFUND"
                Case Else
                    strTxType = "PAYMENT"
            End Select
        End Set
    End Property

    Public Property Amount As Decimal

    Private dtCreatedDate As String
    Public Property CreatedDate As String
        Get
            Return dtCreatedDate
        End Get
        Set(value As String)
            dtCreatedDate = value
        End Set
    End Property

    Private strTransResult As String
    <Size(15)>
    Public Property TransResult As String
        Get
            Return strTransResult
        End Get
        Set(ByVal value As String)
            strTransResult = value
        End Set
    End Property

End Class

Public Class CardRecord
    Inherits XPObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Private _Patient As Patient
    Public Property Patient() As Patient
        Get
            Return _Patient
        End Get
        Set(ByVal value As Patient)
            SetPropertyValue(Of Patient)("Patient", _Patient, value)
        End Set
    End Property

    Private _Beneficiary As Beneficiary
    Public Property Beneficiary() As Beneficiary
        Get
            Return _Beneficiary
        End Get
        Set(ByVal value As Beneficiary)
            SetPropertyValue(Of Beneficiary)("Beneficiary", _Beneficiary, value)
        End Set
    End Property
    Private _Referral As Referral
    Public Property Referral() As Referral
        Get
            Return _Referral
        End Get
        Set(ByVal value As Referral)
            SetPropertyValue(Of Referral)("Referral", _Referral, value)
        End Set
    End Property
    Private strToken As String
    <Size(38)>
       Public Property Token As String
        Get
            Return strToken
        End Get
        Set(value As String)
            strToken = value
        End Set
    End Property
    Private strLast4digits As String
    <Size(4)>
       Public Property Last4digits As String
        Get
            Return strLast4digits
        End Get
        Set(value As String)
            strLast4digits = value
        End Set
    End Property

    Private dtCreatedDate As String
    Public Property CreatedDate As String
        Get
            Return dtCreatedDate
        End Get
        Set(value As String)
            'dtCreatedDate = Date.ParseExact(value.ToString, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.CurrentCulture).ToString("dddd, d MMMM yyyy hh:mm:ss tt")
            'dtCreatedDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yy"), "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces).ToString("dddd, d MMMM yyyy hh:mm:ss tt")
            'dtCreatedDate = DateTime.ParseExact(value, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces).ToString("YYYYMMDD")
            'dtCreatedDate = DateTime.ParseExact(value, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces).ToString("YYYYMMDD")
            'dtCreatedDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces).ToString("MMyy")
            dtCreatedDate = value
        End Set
    End Property
    Private strCV2 As String
    <Size(4)>
    Public Property CV2 As String
        Get
            Return strCV2
        End Get
        Set(ByVal value As String)
            strCV2 = value
        End Set
    End Property

End Class

Public Class SagePayXMLResponse
    Private strErrorCode As String
    <Size(4)>
    Public Property ErrorCode As String
        Get
            Return strErrorCode
        End Get
        Set(ByVal value As String)
            strErrorCode = value
        End Set
    End Property

    Private str_Error As String
    <Size(50)>
    Public Property _Error As String
        Get
            Return str_Error
        End Get
        Set(ByVal value As String)
            str_Error = value
        End Set
    End Property

    Private strVersion As String
    <Size(4)>
    Public Property Version As String
        Get
            Return strVersion
        End Get
        Set(ByVal value As String)
            strVersion = value
        End Set
    End Property

    Private strTimestamp As DateTime
    <Size(20)>
    Public Property Timestamp As DateTime
        Get
            Return strTimestamp
        End Get
        Set(ByVal value As DateTime)
            strTimestamp = value
        End Set
    End Property

    Private strTxType As String
    <Size(15)>
    Public Property TxType As String
        Get
            Return strTxType
        End Get
        Set(ByVal value As String)
            strTxType = value
        End Set
    End Property

    Private strServiceUrl As String
    <Size(20)>
    Public Property ServiceUrl As String
        Get
            Return strServiceUrl
        End Get
        Set(ByVal value As String)
            strServiceUrl = value
        End Set
    End Property


End Class
'Public Class SagePayCancelResponse
'    Inherits CreditCardRecord
'    Public Sub New(ByVal session As Session)
'        MyBase.New(session)
'    End Sub
'    Public Sub New(ByVal session As Session, ByVal name As String)
'        Me.New(session)
'    End Sub
'End Class

'Public Class SagePayCreateTokenResponse
'    Inherits CreditCardRecord
'    Public Sub New(ByVal session As Session)
'        MyBase.New(session)
'    End Sub
'End Class

'Public Class SagePayAuthoriseResponse
'    Inherits CreditCardRecord
'    Public Sub New(ByVal session As Session)
'        MyBase.New(session)
'    End Sub
'    Public Sub New(ByVal session As Session, ByVal name As String)
'        Me.New(session)
'    End Sub
'End Class

'Public Class SagePayRefundResponse
'    Inherits CreditCardRecord
'    Public Sub New(ByVal session As Session)
'        MyBase.New(session)
'    End Sub
'    Public Sub New(ByVal session As Session, ByVal name As String)
'        Me.New(session)
'    End Sub

'End Class