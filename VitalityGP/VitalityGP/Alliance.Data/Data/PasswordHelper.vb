Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports Alliance.Data
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Drawing
Imports DevExpress.Utils
Imports System.Collections
Imports DevExpress.Xpo.Metadata
Imports System.IO
Imports System.Windows.Forms
Imports DevExpress.Utils.Serializing
Imports System.Net.Mail
Imports System.Diagnostics
Imports System.Deployment.Application

Namespace Alliance.Data
    Public Module PasswordHelper
        Public Function Encode(ByVal _object As EntityType, _password As String) As String
            Dim _key As String = GetDesKey(_object)
            If Not String.IsNullOrEmpty(_key) Then
                Dim wrapper As New Simple3Des(_key)
                Return wrapper.EncryptData(_password)
            Else
                Return String.Empty
            End If
        End Function
        Public Function Decode(ByVal _object As EntityType, _password As String) As String
            Dim _key As String = GetDesKey(_object)
            If Not String.IsNullOrEmpty(_password) Then
                Dim wrapper As New Simple3Des(_key)
                Return wrapper.DecryptData(_password)
            Else
                Return String.Empty
            End If
        End Function
        Private Function GetDesKey(ByVal _object As EntityType) As String
            Select Case _object
                Case EntityType.User
                    GetDesKey = "Willow"
                Case EntityType.Beneficiary
                    GetDesKey = "Members"
                Case EntityType.Consultant
                    GetDesKey = "MadCap"
                Case EntityType.ClientStaff
                    GetDesKey = "Clients"
                Case EntityType.Patient
                    GetDesKey = "Patients"
                Case EntityType.VitalityGP
                    GetDesKey = "VitalityGP"
                Case Else
                    GetDesKey = ""
            End Select
        End Function
    End Module

End Namespace

