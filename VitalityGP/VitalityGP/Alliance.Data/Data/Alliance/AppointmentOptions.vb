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


Namespace Alliance.Data
    Public Class AppointmentOption
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _referral As Referral
        <Association("Referral-Appointments")> _
            Public Property Referral() As Referral
            Get
                Return _referral
            End Get
            Set(ByVal value As Referral)
                SetPropertyValue(Of Referral)("Referral", _referral, value)
            End Set
        End Property
        Private _hospital As Hospital
        Public Property Hospital() As Hospital
            Get
                Return _hospital
            End Get
            Set(ByVal value As Hospital)
                SetPropertyValue(Of Hospital)("Hospital", _hospital, value)
            End Set
        End Property
        Private _consultant As Consultant
        Public Property Consultant() As Consultant
            Get
                Return _consultant
            End Get
            Set(ByVal value As Consultant)
                SetPropertyValue(Of Consultant)("Consultant", _consultant, value)
            End Set
        End Property
        Private _datetime As DateTime
        Public Property DateTime() As DateTime
            Get
                Return _datetime
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DateTime", _datetime, value)
            End Set
        End Property
        Private _preferred As Boolean
        Public Property Provisional() As Boolean
            Get
                Return _preferred
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Preferred", _preferred, value)
            End Set
        End Property

    End Class
End Namespace