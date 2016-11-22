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
    Public Class ConnectionHelper
        Public Class ReferenceData
            Public Const AdministratorString As String = "Administrator"
            '  Public Shared CompanyTypes() As String = {"Hospital", "Healthcare Provider", "Treatment Unit"}
        End Class
        Public Shared dataSession As UnitOfWork = Nothing
        Public Shared XpoConnectionString As String = "XpoProvider=MSSqlServer;data source=ALLIANCE-MMOL\EXCHEQUER;integrated security=SSPI;initial catalog=Project360Dev"
        Public Shared Sub Connect(ByVal autoCreationOption As DB.AutoCreateOption)
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(XpoConnectionString, autoCreationOption)
            XpoDefault.Session = Nothing
            XpoDefault.TrackPropertiesModifications = True
        End Sub
        Public Shared Function GetConnectionProvider(ByVal autoCreationOption As DB.AutoCreateOption) As DB.IDataStore
            Return XpoDefault.GetConnectionProvider(XpoConnectionString, autoCreationOption)
        End Function
        Public Shared Function GetConnectionProvider(ByVal autoCreationOption As DB.AutoCreateOption, ByRef objectsToDisposeOnDisconnect() As IDisposable) As DB.IDataStore
            Return XpoDefault.GetConnectionProvider(XpoConnectionString, autoCreationOption, objectsToDisposeOnDisconnect)
        End Function
        Public Shared Function GetDataLayer(ByVal autoCreationOption As DB.AutoCreateOption) As IDataLayer
            Return XpoDefault.GetDataLayer(XpoConnectionString, autoCreationOption)
        End Function
        Public Shared Function VersionNo() As String
            If Debugger.IsAttached Then
                Return Nothing
            End If
            Try
                Return String.Format("Ver {0}", ApplicationDeployment.CurrentDeployment.CurrentVersion)
            Catch ex As Exception

            End Try
            Return Nothing
        End Function
        Private Shared Sub CheckForDefaultAdministrator(ByVal session As Session)
            If ((Not Object.Equals(session.FindObject(Of User)(CriteriaOperator.Parse("Login = ?", ReferenceData.AdministratorString)), Nothing))) Then
                Return
            End If
            CType(New User(session, ReferenceData.AdministratorString, String.Empty), User).Role = eUserRole.Administrator
        End Sub
        Public Shared Function SaveControlLayout(ByVal control As ISupportXtraSerializer) As MemoryStream
            If Object.Equals(control, Nothing) Then
                Return Nothing
            End If
            Dim stream As MemoryStream = New System.IO.MemoryStream()
            control.SaveLayoutToStream(stream)
            Return stream
        End Function
        Public Shared Sub RestoreControlLayout(ByVal layout As MemoryStream, ByVal control As ISupportXtraSerializer)
            If Object.Equals(layout, Nothing) OrElse Object.Equals(layout, MemoryStream.Null) OrElse Object.Equals(control, Nothing) Then
                Return
            End If
            layout.Seek(0, SeekOrigin.Begin)
            control.RestoreLayoutFromStream(layout)
        End Sub
        Public Shared Sub CheckForInitialRecords(ByVal session As Session)
            Using saver As New UnitOfWork(session.DataLayer)

                CheckForDefaultAdministrator(saver)
                CheckForTables(saver)
                CheckForDefaults(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForAWGBenefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForNWLBenefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try


                CheckForNWRBenefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)

                End Try
                CheckForTSGBenefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForRRBenefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForRRRBenefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForHMT1Benefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForHMT2Benefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForHMT3Benefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForHMT4Benefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try


                CheckForHMT5Benefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForHMT6Benefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForHMT7Benefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForHMT8Benefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForHMTXBenefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckFor9JL2Benefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                CheckForG9RBBenefits(saver)
                Try
                    saver.CommitChanges()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try


                '    DeleteDummyRecords(saver)
                '  Try
                'saver.CommitChanges()
                '  saver.PurgeDeletedObjects()
                '  Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Critical)
                '  End Try
            End Using
        End Sub
        Public Shared Function GetPostcodePosition(ByVal address1 As String, ByVal city As String, ByVal country As String) As String()

            Dim addressxml As String = String.Empty
            Dim zipCode As String = String.Empty
            Dim sPosition() As String = {"", ""}

            Try

                'Create an object of web client
                Dim wsClient As New Net.WebClient()

                'Construct the URL concating the address values with it
                Dim zipcodeurl As String = "?address={0},+{1},+{2}&sensor=false"
                'Here in constructing the URL sensor(is required) indicates whether or not the geocoding request comes from a device with a location sensor.
                ' Dim url As String = "http://maps.googleapis.com/maps/api/geocode/json?address=SE17PB,uk&sensor=false"
                Dim url As String = "http://maps.googleapis.com/maps/api/geocode/xml" & zipcodeurl
                url = String.Format(url, address1.Replace(" ", "+"), city.Replace(" ", "+"), country.Replace(" ", "+"))

                'Download the data in XML format as string by making a web request
                addressxml = wsClient.DownloadString(url)

                'Check if status is OK then proceed
                If addressxml.Contains("OK") Then

                    'Check if postal_code section is there in the string then proceed
                    If addressxml.Contains("location") Then
                        Dim xmlDoc As New Xml.XmlDocument()
                        xmlDoc.LoadXml(addressxml)
                        Dim m_nodelist As Xml.XmlNodeList

                        m_nodelist = xmlDoc.SelectNodes("/GeocodeResponse/result/location")
                        For Each m_node As Xml.XmlNode In m_nodelist
                            Dim m_shortname As String = m_node.ChildNodes.Item(0).InnerText
                        Next

                        'Get the list of all address_companent nodes as this component only contans the address information
                        m_nodelist = xmlDoc.SelectNodes("/GeocodeResponse/result/geometry/location")

                        'From each component check for the type section for getting the particular postal_code section
                        For Each m_node As Xml.XmlNode In m_nodelist
                            sPosition(Coords.Latitude) = m_node.ChildNodes.Item(Coords.Latitude).InnerText
                            sPosition(Coords.Longitude) = m_node.ChildNodes.Item(Coords.Longitude).InnerText
                        Next


                    End If

                End If


            Catch ex As Exception


            End Try

            Return sPosition


        End Function

        Private Shared Sub CheckForTables(ByVal session As UnitOfWork)
            Try

                session.UpdateSchema()

                Dim eText As String
                Dim iRows As Integer = 1
                Dim iCount As Integer = 1

                Dim eCategory() As String = {"Musculoskeletal", "Urology", "Gastrointestinal(GI)", "ENT", "Cardiovascular", "Physiotherapy", "Dermatology", "Ophthalmology", "Gynaecology", "Rheumatology", "Neurological", "Homeostatic", "Respiratory", "Blood & Lymph", "General Surgery", "Endocrine", "General", "Mental Health", "Women's Health", "Oral & Maxillofacial", "Renal", "Oncology"}
                Dim eSubCategory() As String = {""}
                Dim _incurredCategory As IncurredCategory
                Dim _subIncurredCategory As IncurredCategory

                For Each Category As String In eCategory
                    If ((Object.Equals(session.FindObject(Of IncurredCategory)(CriteriaOperator.Parse("IncurredCategory =  ?", Category)), Nothing))) Then
                        _incurredCategory = New IncurredCategory(session)
                        iCount += 1
                        _incurredCategory.SequenceNo = iCount
                        _incurredCategory.IncurredCategory = Category
                        _incurredCategory.Save()
                        session.CommitChanges()
                        If Category = "Musculoskeletal" Then
                            eSubCategory = {"Hip", "Shoulder", "Knee", "Foot & Ankle", "Spine", "Acute Joint Pain & Swelling", "Neck", "Rheumatoid Arthritis", "Wrist & Arm", "Leg"}
                        End If
                        If Category = "Mental Health" Then
                            eSubCategory = {"Depression", "Anxiety", "Stress", "Other"}
                        End If
                        If eSubCategory.Length > 1 Then
                            For Each sCategory As String In eSubCategory
                                If ((Object.Equals(session.FindObject(Of IncurredCategory)(CriteriaOperator.Parse("IncurredCategory =  ?", Category)), Nothing))) Then
                                    _subIncurredCategory = New IncurredCategory(session)
                                    iCount += 1
                                    _subIncurredCategory.SequenceNo = iCount
                                    _subIncurredCategory.IncurredCategory = sCategory
                                    _subIncurredCategory.Parent = _incurredCategory
                                    _subIncurredCategory.Save()
                                    session.CommitChanges()
                                End If
                            Next
                            eSubCategory = {""}
                        End If
                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eProviderType))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eProviderType), eText)))
                    If ((Object.Equals(session.FindObject(Of ProviderType)(CriteriaOperator.Parse("Oid = ?", Id)), Nothing))) Then
                        Dim EObj As New ProviderType(session)
                        EObj.Oid = Id
                        EObj.SequenceNo = Id
                        EObj.ProviderType = eText
                        EObj.Save()
                        session.CommitChanges()
                    End If
                Next

                Dim eBupaCategory() As String = {"Cash Value"}
                For iRows = 1 To 6
                    If iRows = 2 Then
                        eBupaCategory = {"MINOR 1", "MINOR 2", "MINOR 3", "MINOR 4", "MINOR 5"}
                    ElseIf iRows = 3 Then
                        eBupaCategory = {"INTER 1", "INTER 2", "INTER 3", "INTER 4", "INTER 5"}
                    ElseIf iRows = 4 Then
                        eBupaCategory = {"MAJOR 1", "MAJOR 2", "MAJOR 3", "MAJOR 4", "MAJOR 5"}
                    ElseIf iRows = 5 Then
                        eBupaCategory = {"MAJOR+ 1", "MAJOR+ 2", "MAJOR+ 3", "MAJOR+ 4", "MAJOR+ 5"}
                    ElseIf iRows = 6 Then
                        eBupaCategory = {"CMO 1", "CMO 2", "CMO 3", "CMO 4", "CMO 5"}
                    End If

                    For Each Category As String In eBupaCategory
                        If ((Object.Equals(session.FindObject(Of Maxima)(CriteriaOperator.Parse("Category = 'A' and MaximaCategory =  ?", Category)), Nothing))) Then
                            Dim EObj As New Maxima(session)
                            EObj.Oid = iCount
                            iCount += 1
                            EObj.SequenceNo = iCount
                            EObj.Category = "A"
                            EObj.MaximaCategory = Category
                            EObj.Save()
                            session.CommitChanges()

                        End If

                    Next
                Next

                eBupaCategory = {"Cash Value"}
                For iRows = 1 To 6
                    If iRows = 2 Then
                        eBupaCategory = {"MINOR 1", "MINOR 2", "MINOR 3", "MINOR 4", "MINOR 5"}
                    ElseIf iRows = 3 Then
                        eBupaCategory = {"INTER 1", "INTER 2", "INTER 3", "INTER 4", "INTER 5"}
                    ElseIf iRows = 4 Then
                        eBupaCategory = {"MAJOR 1", "MAJOR 2", "MAJOR 3", "MAJOR 4", "MAJOR 5"}
                    ElseIf iRows = 5 Then
                        eBupaCategory = {"MAJOR+ 1", "MAJOR+ 2", "MAJOR+ 3", "MAJOR+ 4", "MAJOR+ 5"}
                    ElseIf iRows = 6 Then
                        eBupaCategory = {"CMO 1", "CMO 2", "CMO 3", "CMO 4", "CMO 5"}
                    End If

                    For Each Category As String In eBupaCategory
                        If ((Object.Equals(session.FindObject(Of Maxima)(CriteriaOperator.Parse("Category = 'C' and MaximaCategory =  ?", Category)), Nothing))) Then
                            Dim EObj As New Maxima(session)
                            EObj.Oid = iCount
                            iCount += 1
                            EObj.SequenceNo = iCount
                            EObj.Category = "C"
                            EObj.MaximaCategory = Category
                            EObj.Save()
                            session.CommitChanges()

                        End If

                    Next
                Next

                eBupaCategory = {"Cash Value"}
                For iRows = 1 To 6
                    If iRows = 2 Then
                        eBupaCategory = {"MINOR"}
                    ElseIf iRows = 3 Then
                        eBupaCategory = {"INTER"}
                    ElseIf iRows = 4 Then
                        eBupaCategory = {"MAJOR"}
                    ElseIf iRows = 5 Then
                        eBupaCategory = {"MAJOR+"}
                    ElseIf iRows = 6 Then
                        eBupaCategory = {"CMO 1", "CMO 2", "CMO 3", "CMO 4", "CMO 5"}
                    End If

                    For Each Category As String In eBupaCategory
                        If ((Object.Equals(session.FindObject(Of Maxima)(CriteriaOperator.Parse("Category = 'H' and MaximaCategory =  ?", Category)), Nothing))) Then
                            Dim EObj As New Maxima(session)
                            EObj.Oid = iCount
                            iCount += 1
                            EObj.SequenceNo = iCount
                            EObj.Category = "H"
                            EObj.MaximaCategory = Category
                            EObj.Save()
                            session.CommitChanges()

                        End If

                    Next
                Next

                For Each eText In [Enum].GetNames(GetType(eHospitalCategory))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eHospitalCategory), eText)))
                    If ((Object.Equals(session.FindObject(Of HospitalCategory)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New HospitalCategory(session)
                        EObj.Oid = Id
                        EObj.HospitalCategory = eText
                        EObj.Save()
                        session.CommitChanges()

                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eAdmissionStatus))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eAdmissionStatus), eText)))
                    If ((Object.Equals(session.FindObject(Of AdmissionStatus)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New AdmissionStatus(session)
                        EObj.Oid = Id
                        EObj.SequenceNo = Id
                        EObj.AdmissionStatus = eText
                        EObj.Save()
                        session.CommitChanges()

                    End If
                Next


                For Each eText In [Enum].GetNames(GetType(eInvoiceSource))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eInvoiceSource), eText)))
                    If ((Object.Equals(session.FindObject(Of InvoiceSource)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New InvoiceSource(session)
                        EObj.Oid = Id
                        EObj.SequenceNo = Id
                        EObj.Source = eText
                        EObj.Save()
                        session.CommitChanges()

                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eInvoiceStatus))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eInvoiceStatus), eText)))
                    If ((Object.Equals(session.FindObject(Of InvoiceStatus)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New InvoiceStatus(session)
                        EObj.Oid = Id
                        EObj.SequenceNo = Id
                        EObj.Status = eText
                        EObj.Save()
                        session.CommitChanges()

                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eClaimStatus))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eClaimStatus), eText)))
                    If Id > 0 Then
                        If ((Object.Equals(session.FindObject(Of ClaimStatus)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                            Dim EObj As New ClaimStatus(session)
                            EObj.Oid = Id
                            EObj.SequenceNo = Id
                            EObj.Status = eText
                            EObj.Save()
                            session.CommitChanges()

                        End If
                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eAuthorisationType))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eAuthorisationType), eText)))
                    If Id > 0 Then
                        If ((Object.Equals(session.FindObject(Of AuthorisationType)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                            Dim EObj As New AuthorisationType(session)
                            EObj.Oid = Id
                            EObj.SequenceNo = Id
                            EObj.AuthorisationType = eText
                            EObj.Save()
                            session.CommitChanges()

                        End If
                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eAuthorisationStatus))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eAuthorisationStatus), eText)))
                    If Id > 0 Then
                        If ((Object.Equals(session.FindObject(Of AuthorisationStatus)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                            Dim EObj As New AuthorisationStatus(session)
                            EObj.Oid = Id
                            EObj.SequenceNo = Id
                            EObj.Status = eText
                            EObj.Save()
                            session.CommitChanges()
                        End If
                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eClaimSource))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eClaimSource), eText)))
                    If Id > 0 Then
                        If ((Object.Equals(session.FindObject(Of ClaimSource)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                            Dim EObj As New ClaimSource(session)
                            EObj.Oid = Id
                            EObj.SequenceNo = Id
                            EObj.Source = eText
                        End If
                    End If
                Next
                For Each eText In [Enum].GetNames(GetType(eAuthorisationSource))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eAuthorisationSource), eText)))
                    If Id > 0 Then
                        If ((Object.Equals(session.FindObject(Of AuthorisationSource)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                            Dim EObj As New AuthorisationSource(session)
                            EObj.Oid = Id
                            EObj.SequenceNo = Id
                            EObj.Source = eText
                        End If
                    End If
                Next
                For Each eText In [Enum].GetNames(GetType(eTaskLabel))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eTaskLabel), eText)))
                    If ((Object.Equals(session.FindObject(Of TaskLabel)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New TaskLabel(session)
                        EObj.Oid = Id
                        If Id = 2 Then
                            EObj.Default = True
                        End If
                        If Id = 4 Or Id = 6 Then
                            EObj.IsTask = True
                        End If
                        EObj.SequenceNo = Id
                        EObj.TaskLabel = eText
                        EObj.FullName = eText
                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eBenefitPeriod))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eBenefitPeriod), eText)))
                    If ((Object.Equals(session.FindObject(Of Period)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New Period(session)
                        EObj.Oid = Id
                        EObj.SequenceNo = Id
                        EObj.Period = eText
                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eCallOut))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eCallOut), eText)))
                    If Id > 0 Then
                        If ((Object.Equals(session.FindObject(Of Callout)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                            Dim EObj As New Callout(session)
                            EObj.Oid = Id
                            EObj.Description = eText
                        End If
                    End If
                Next


                For Each eText In [Enum].GetNames(GetType(eMemberStatus))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eMemberStatus), eText)))
                    If Id > 0 Then
                        If ((Object.Equals(session.FindObject(Of MemberStatus)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                            Dim EObj As New MemberStatus(session)
                            EObj.Oid = Id
                            EObj.SequenceNo = Id
                            EObj.MemberStatus = eText
                        End If
                    End If
                Next

                'For Each eText In [Enum].GetNames(GetType(eReasonLeft))
                '    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eReasonLeft), eText)))
                '    If ((Object.Equals(session.FindObject(Of ReasonLeft)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                '        Dim EObj As New ReasonLeft(session)
                '        EObj.Oid = Id
                '        EObj.SequenceNo = Id
                '        EObj.ReasonLeft = eText
                '    End If
                'Next

                For Each _reasonLeft As eReasonLeft In [Enum].GetValues(GetType(eReasonLeft))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eReasonLeft), _reasonLeft)))
                    If ((Object.Equals(session.FindObject(Of ReasonLeft)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New ReasonLeft(session)
                        EObj.Oid = Id
                        EObj.SequenceNo = Id
                        EObj.ReasonLeft = EnumHelper.GetDescription(_reasonLeft)
                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eLevelOfCover))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eLevelOfCover), eText)))
                    If ((Object.Equals(session.FindObject(Of LevelofCover)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New LevelofCover(session)
                        EObj.Oid = Id
                        EObj.LevelofCover = eText
                    End If
                Next


                For Each eText In [Enum].GetNames(GetType(eRelationship))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eRelationship), eText)))
                    If ((Object.Equals(session.FindObject(Of RelationShip)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New RelationShip(session)
                        EObj.Oid = Id
                        EObj.RelationShip = eText
                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eReasonClosed))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eReasonClosed), eText)))
                    If ((Object.Equals(session.FindObject(Of ReferralReasonClosed)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New ReferralReasonClosed(session)
                        EObj.Oid = Id
                        EObj.ClosedReason = eText
                    End If
                Next

                For Each _referralStage As eReferralStage In System.Enum.GetValues(GetType(eReferralStage))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eReferralStage), _referralStage)))
                    If ((Object.Equals(session.FindObject(Of ReferralStage)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New ReferralStage(session)
                        EObj.Oid = Id
                        EObj.ReferralStage = Enums.GetNumDescription(_referralStage)
                    End If
                Next


                For Each eText In [Enum].GetNames(GetType(eActionType))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eActionType), eText)))
                    If ((Object.Equals(session.FindObject(Of ActionType)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New ActionType(session)
                        EObj.Oid = Id
                        EObj.ActionItem = eText
                    End If
                Next

                For Each eText In [Enum].GetNames(GetType(eNextActionType))
                    Dim Id As Integer = CInt(String.Format("{0:D}", [Enum].Parse(GetType(eNextActionType), eText)))
                    If ((Object.Equals(session.FindObject(Of NextActionType)(CriteriaOperator.Parse("Oid =  ?", Id)), Nothing))) Then
                        Dim EObj As New NextActionType(session)
                        EObj.Oid = Id
                        EObj.NextAction = eText
                    End If
                Next

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End Sub
        Private Shared Sub CheckForDefaults(ByVal session As UnitOfWork)
            Try

                Dim oSymptom As Symptom = session.FindObject(Of Symptom)(CriteriaOperator.Parse("Symptom= ?", "WebReferral"))
                If oSymptom Is Nothing Then
                    Dim _Symptom As New Symptom(session)
                    _Symptom.Symptom = "WebReferral"
                    _Symptom.AffectedSystem = session.FindObject(Of AffectedSystem)(CriteriaOperator.Parse("AffectedSystem= ?", "Other"))
                    _Symptom.Save()
                End If

            Catch ex As Exception

            End Try

            Try

                Dim oGender As Gender = session.FindObject(Of Gender)(CriteriaOperator.Parse("GenderID= ?", "M"))
                If oGender Is Nothing Then
                    Dim _Gender As New Gender(session)
                    _Gender.GenderID = Convert.ToChar("M")
                    _Gender.Gender = "Male"
                    _Gender.Save()
                End If

            Catch ex As Exception

            End Try
            Try

                Dim oGender As Gender = session.FindObject(Of Gender)(CriteriaOperator.Parse("GenderID= ?", "F"))
                If oGender Is Nothing Then
                    Dim _Gender As New Gender(session)
                    _Gender.GenderID = Convert.ToChar("F")
                    _Gender.Gender = "Female"
                    _Gender.Save()
                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Shared Sub CheckForAWGBenefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 114))
                If oClient Is Nothing Then
                    Return
                End If

                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=?", oClient.Oid))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Policy=?", oScheme.Oid, "2014/15"))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2014/15"
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.Moratorium = 0
                    oPolicy.StartDate = DateTime.Parse("2014-07-01")
                    oPolicy.EndDate = DateTime.Parse("2015-06-30")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session, oPolicy)
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sConsFee As New BenefitLimit(session, oPolicy)
                sConsFee.Client = oClient
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.FullRefund = True
                sConsFee.PercentageToPay = 100
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sTheatre As New BenefitLimit(session, oPolicy)
                sTheatre.Client = oClient
                sTheatre.BenefitLimit = "Treatment/Theatre Costs"
                sTheatre.FullRefund = True
                sTheatre.PercentageToPay = 100
                sTheatre.Parent = sDayCase
                sTheatre.Save()

                Dim sInCancer As New BenefitLimit(session, oPolicy)
                sInCancer.Client = oClient
                sInCancer.BenefitLimit = "Cancer - Diagnostic Treatment, Specialist Fees and Surgery"
                sInCancer.FullRefund = True
                sInCancer.PercentageToPay = 100
                sInCancer.Parent = sDayCase
                sInCancer.Save()

                Dim sInCancerDrug As New BenefitLimit(session, oPolicy)
                sInCancerDrug.Client = oClient
                sInCancerDrug.BenefitLimit = "Cancer - Drug Treatment"
                sInCancerDrug.FullRefund = True
                sInCancerDrug.PercentageToPay = 100
                sInCancerDrug.Parent = sDayCase
                sInCancerDrug.Save()

                Dim sNursing As New BenefitLimit(session, oPolicy)
                sNursing.Client = oClient
                sNursing.BenefitLimit = "Charges for Nursing Care/Drugs/Surgical Dressings"
                sNursing.FullRefund = True
                sNursing.PercentageToPay = 100
                sNursing.Parent = sDayCase
                sNursing.Save()

                Dim sPath As New BenefitLimit(session, oPolicy)
                sPath.Client = oClient
                sPath.BenefitLimit = "Pathology, Radiology and Diagnostic tests"
                sPath.AuthorisationType = eAuthorisationType.Diagnostics
                sPath.FullRefund = True
                sPath.PercentageToPay = 100
                sPath.Parent = sDayCase
                sPath.Save()

                Dim sScans As New BenefitLimit(session, oPolicy)
                sScans.Client = oClient
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sPros As New BenefitLimit(session, oPolicy)
                sPros.Client = oClient
                sPros.BenefitLimit = "Prostheses and Appliances"
                sPros.FullRefund = True
                sPros.PercentageToPay = 100
                sPros.Parent = sDayCase
                sPros.Save()

                Dim sDCAccomodation As New BenefitLimit(session, oPolicy)
                sDCAccomodation.Client = oClient
                sDCAccomodation.BenefitLimit = "Accommodation"
                sDCAccomodation.FullRefund = True
                sDCAccomodation.PercentageToPay = 100
                sDCAccomodation.Parent = sDayCase
                sDCAccomodation.Save()

                Dim sParentAcc As New BenefitLimit(session, oPolicy)
                sParentAcc.Client = oClient
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (staying with a child under 14)"
                sParentAcc.FullRefund = True
                sParentAcc.LowerAgeLimit = 14
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session, oPolicy)
                sOther.Client = oClient
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehabHdr As New BenefitLimit(session, oPolicy)
                sRehabHdr.Client = oClient
                sRehabHdr.Policy = oPolicy
                sRehabHdr.BenefitLimit = "Rehab"
                sRehabHdr.Parent = sOther
                sRehabHdr.Save()

                Dim sRehab As New BenefitLimit(session, oPolicy)
                sRehab.Client = oClient
                sRehab.BenefitLimit = "Charges for functional capability assessment and physiotherapy"
                sRehab.Parent = sRehabHdr
                sRehab.Save()

                Dim sSubCashBenefitHdr As New BenefitLimit(session, oPolicy)
                sSubCashBenefitHdr.Client = oClient
                sSubCashBenefitHdr.BenefitLimit = "Cash Benefit"
                sSubCashBenefitHdr.Parent = sOther
                sSubCashBenefitHdr.Save()

                Dim sSubCashBenefit2 As New BenefitLimit(session, oPolicy)
                sSubCashBenefit2.Client = oClient
                sSubCashBenefit2.Period = eBenefitPeriod.Daily
                sSubCashBenefit2.Limit = 200.0
                sSubCashBenefit2.AnnualLimit = 2800.0
                sSubCashBenefit2.AnnualSessions = 14
                sSubCashBenefit2.BenefitLimit = "NHS Cash Benefit"
                sSubCashBenefit2.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sSubCashBenefit2.Parent = sSubCashBenefitHdr
                sSubCashBenefit2.Save()

                Dim sHomeNursingHdr As New BenefitLimit(session, oPolicy)
                sHomeNursingHdr.Client = oClient
                sHomeNursingHdr.BenefitLimit = "Nursing"
                sHomeNursingHdr.Parent = sOther
                sHomeNursingHdr.Save()

                Dim sHomeNursing As New BenefitLimit(session, oPolicy)
                sHomeNursing.Client = oClient
                sHomeNursing.BenefitLimit = "Home Nursing"
                sHomeNursing.Period = eBenefitPeriod.Annual
                sHomeNursing.Limit = 600
                sHomeNursing.Parent = sHomeNursingHdr
                sHomeNursing.Save()

                Dim sAmbulanceHdr As New BenefitLimit(session, oPolicy)
                sAmbulanceHdr.Client = oClient
                sAmbulanceHdr.BenefitLimit = "Private Ambulance"
                sAmbulanceHdr.Parent = sOther
                sAmbulanceHdr.Save()

                Dim sAmbulance1 As New BenefitLimit(session, oPolicy)
                sAmbulance1.Client = oClient
                sAmbulance1.BenefitLimit = "Private ambulance - Other"
                sAmbulance1.Period = eBenefitPeriod.Claim
                sAmbulance1.Limit = 80
                sAmbulance1.Parent = sAmbulanceHdr
                sAmbulance1.Save()

                Dim sAmbulance2 As New BenefitLimit(session, oPolicy)
                sAmbulance2.Client = oClient
                sAmbulance2.BenefitLimit = "Private ambulance - Transfer between medical facilities"
                sAmbulance2.Parent = sAmbulanceHdr
                sAmbulance2.Save()


                Dim sOutPatient As New BenefitLimit(session, oPolicy)
                sOutPatient.Client = oClient
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sOutsConsFee As New BenefitLimit(session, oPolicy)
                sOutsConsFee.Client = oClient
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.FullRefund = True
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutTheatre As New BenefitLimit(session, oPolicy)
                sOutTheatre.Client = oClient
                sOutTheatre.BenefitLimit = "Theatre Costs"
                sOutTheatre.FullRefund = True
                sOutTheatre.PercentageToPay = 100
                sOutTheatre.Parent = sOutPatient
                sOutTheatre.Save()

                Dim sOutCancer As New BenefitLimit(session, oPolicy)
                sOutCancer.Client = oClient
                sOutCancer.BenefitLimit = "Cancer - Diagnostic Treatment, Specialist Fees and Surgery "
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()

                Dim sOutCancerDr As New BenefitLimit(session, oPolicy)
                sOutCancerDr.Client = oClient
                sOutCancerDr.BenefitLimit = "Cancer - Drug Treatment"
                sOutCancerDr.FullRefund = True
                sOutCancerDr.PercentageToPay = 100
                sOutCancerDr.Parent = sOutPatient
                sOutCancerDr.Save()

                Dim sOutPath As New BenefitLimit(session, oPolicy)
                sOutPath.Client = oClient
                sOutPath.BenefitLimit = "Pathology, Radiology and Diagnostic Tests"
                sOutPath.AuthorisationType = eAuthorisationType.Diagnostics
                sOutPath.FullRefund = True
                sOutPath.PercentageToPay = 100
                sOutPath.Parent = sOutPatient
                sOutPath.Save()

                Dim sOutScan As New BenefitLimit(session, oPolicy)
                sOutScan.Client = oClient
                sOutScan.BenefitLimit = "MRI, CT and PET scans "
                sOutScan.AuthorisationType = eAuthorisationType.Diagnostics
                sOutScan.FullRefund = True
                sOutScan.PercentageToPay = 100
                sOutScan.Parent = sOutPatient
                sOutScan.Save()

                Dim sOutPsy As New BenefitLimit(session, oPolicy)
                sOutPsy.Client = oClient
                sOutPsy.BenefitLimit = "Psychiatric Fees"
                sOutPsy.AuthorisationType = eAuthorisationType.Consultation
                sOutPsy.AnnualLimit = 2000
                sOutPsy.FullRefund = True
                sOutPsy.PercentageToPay = 100
                sOutPsy.Parent = sOutPatient
                sOutPsy.Save()

                Dim sTherapists As New BenefitLimit(session, oPolicy)
                sTherapists.Client = oClient
                sTherapists.BenefitLimit = "Therapists Fees"
                sTherapists.Period = eBenefitPeriod.Annual
                sTherapists.AuthorisationType = eAuthorisationType.Consultation
                sTherapists.FullRefund = True
                sTherapists.PercentageToPay = 100
                sTherapists.Parent = sOutPatient
                sTherapists.Save()

                Dim sComplimentary As New BenefitLimit(session, oPolicy)
                sComplimentary.Client = oClient
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualLimit = 250
                sComplimentary.AnnualSessions = 10
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

            Catch ex As Exception

            End Try
        End Sub
        Private Shared Sub CheckForNWLBenefits(ByVal session As UnitOfWork)
            Try
                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 117))
                If oClient Is Nothing Then
                    Return
                End If

                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=?", oClient.Oid))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Policy=?", oScheme.Oid, "2015/16"))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2015/16"
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.Moratorium = 0
                    oPolicy.StartDate = DateTime.Parse("2015-04-01")
                    oPolicy.EndDate = DateTime.Parse("2016-03-31")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session, oPolicy)
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session, oPolicy)
                sHospFee.Client = oClient
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Annual
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session, oPolicy)
                sConsFee.Client = oClient
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session, oPolicy)
                sDCCancer.Client = oClient
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session, oPolicy)
                sScans.Client = oClient
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session, oPolicy)
                sParentAcc.Client = oClient
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                Dim sPhych As New BenefitLimit(session, oPolicy)
                sPhych.Client = oClient
                sPhych.BenefitLimit = "Psychiatric treatment"
                sPhych.Period = eBenefitPeriod.Annual
                sPhych.AnnualSessions = 28
                sPhych.FullRefund = True
                sPhych.PercentageToPay = 100
                sPhych.Parent = sDayCase
                sPhych.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session, oPolicy)
                sOther.Client = oClient
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session, oPolicy)
                sRehab.Client = oClient
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session, oPolicy)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()

                Dim sHome As New BenefitLimit(session, oPolicy)
                sHome.Client = oClient
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sGPHelpLine As New BenefitLimit(session, oPolicy)
                sGPHelpLine.Client = oClient
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session, oPolicy)
                sOutPatient.Client = oClient
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session, oPolicy)
                sHospFeeOP.Client = oClient
                sHospFeeOP.BenefitLimit = "Treatment/Theatre Costs"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session, oPolicy)
                sOutsConsFee.Client = oClient
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session, oPolicy)
                sOutCancer.Client = oClient
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session, oPolicy)
                sClinical.Client = oClient
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session, oPolicy)
                sComplimentary.Client = oClient
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session, oPolicy)
                sScansOP.Client = oClient
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

                Dim sOutPsy As New BenefitLimit(session, oPolicy)
                sOutPsy.Client = oClient
                sOutPsy.BenefitLimit = "Psychiatric Fees"
                sOutPsy.Period = eBenefitPeriod.Annual
                sOutPsy.AuthorisationType = eAuthorisationType.Consultation
                sOutPsy.FullRefund = True
                sOutPsy.PercentageToPay = 100
                sOutPsy.Parent = sOutPatient
                sOutPsy.Save()

            Catch ex As Exception

            End Try
        End Sub
        Private Shared Sub CheckForNWRBenefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 118))
                If oClient Is Nothing Then
                    Return
                End If

                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=?", oClient.Oid))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Policy=?", oScheme.Oid, "2015/16"))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2015/16"
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.Moratorium = 0
                    oPolicy.StartDate = DateTime.Parse("2015-04-01")
                    oPolicy.EndDate = DateTime.Parse("2016-03-31")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If


                Dim sDayCase As New BenefitLimit(session, oPolicy)
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session, oPolicy)
                sHospFee.Client = oClient
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Claim
                sHospFee.FullRefund = True
                sHospFee.Limit = 0
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session, oPolicy)
                sConsFee.Client = oClient
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Claim
                sConsFee.Limit = 1
                sConsFee.FullRefund = True
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session, oPolicy)
                sDCCancer.Client = oClient
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Claim
                sDCCancer.FullRefund = True
                sDCCancer.PercentageToPay = 100
                sDCCancer.Limit = 0
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session, oPolicy)
                sScans.Client = oClient
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Claim
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Limit = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sPhych As New BenefitLimit(session, oPolicy)
                sPhych.Client = oClient
                sPhych.BenefitLimit = "Psychiatric treatment"
                sPhych.Period = eBenefitPeriod.Claim
                sPhych.AnnualSessions = 0
                sPhych.FullRefund = True
                sPhych.Limit = 0
                sPhych.PercentageToPay = 100
                sPhych.Parent = sDayCase
                sPhych.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session, oPolicy)
                sOther.Client = oClient
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session, oPolicy)
                sRehab.Client = oClient
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session, oPolicy)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit.Limit = 0
                sNHSCashBenefit.Period = eBenefitPeriod.Claim
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()

                Dim sHome As New BenefitLimit(session, oPolicy)
                sHome.Client = oClient
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sGPHelpLine As New BenefitLimit(session, oPolicy)
                sGPHelpLine.Client = oClient
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session, oPolicy)
                sOutPatient.Client = oClient
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session, oPolicy)
                sHospFeeOP.Client = oClient
                sHospFeeOP.BenefitLimit = "Treatment/Theatre Costs"
                sHospFeeOP.Period = eBenefitPeriod.Claim
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.Limit = 0
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session, oPolicy)
                sOutsConsFee.Client = oClient
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Claim
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Limit = 1
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session, oPolicy)
                sOutCancer.Client = oClient
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Claim
                sOutCancer.Limit = 1
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session, oPolicy)
                sClinical.Client = oClient
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Claim
                sClinical.Parent = sOutPatient
                sClinical.Limit = 0
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session, oPolicy)
                sComplimentary.Client = oClient
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Claim
                sComplimentary.AnnualSessions = 0
                sComplimentary.Limit = 0
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session, oPolicy)
                sScansOP.Client = oClient
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Claim
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.Limit = 0
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

                Dim sOutPsy As New BenefitLimit(session, oPolicy)
                sOutPsy.Client = oClient
                sOutPsy.BenefitLimit = "Psychiatric Fees"
                sOutPsy.Period = eBenefitPeriod.Claim
                sOutPsy.AuthorisationType = eAuthorisationType.Consultation
                sOutPsy.FullRefund = True
                sOutPsy.Limit = 0
                sOutPsy.PercentageToPay = 100
                sOutPsy.Parent = sOutPatient
                sOutPsy.Save()

            Catch ex As Exception

            End Try
        End Sub
        Private Shared Sub CheckForTSGBenefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 115))
                If oClient Is Nothing Then
                    Return
                End If

                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=?", oClient.Oid))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Policy=?", oScheme.Oid, "2013/14"))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2013/14"
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.Moratorium = 0
                    oPolicy.StartDate = DateTime.Parse("2013-09-01")
                    oPolicy.EndDate = DateTime.Parse("2014-08-31")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If
          


                Dim sDayCase As New BenefitLimit(session, oPolicy)
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sConsFee As New BenefitLimit(session, oPolicy)
                sConsFee.Client = oClient
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.FullRefund = True
                sConsFee.PercentageToPay = 100
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sTheatre As New BenefitLimit(session, oPolicy)
                sTheatre.Client = oClient
                sTheatre.BenefitLimit = "Treatment/Theatre Costs"
                sTheatre.FullRefund = True
                sTheatre.PercentageToPay = 100

                sTheatre.Parent = sDayCase
                sTheatre.Save()

                Dim sInCancer As New BenefitLimit(session, oPolicy)
                sInCancer.Client = oClient
                sInCancer.BenefitLimit = "Cancer - Diagnostic Treatment, Specialist Fees and Surgery "

                sInCancer.FullRefund = True
                sInCancer.PercentageToPay = 100
                sInCancer.Parent = sDayCase
                sInCancer.Save()

                Dim sInCancerDrug As New BenefitLimit(session, oPolicy)
                sInCancerDrug.Client = oClient
                sInCancerDrug.BenefitLimit = "Cancer - Drug Treatment"
                sInCancerDrug.FullRefund = True
                sInCancerDrug.PercentageToPay = 100
                sInCancerDrug.Parent = sDayCase
                sInCancerDrug.Save()

                Dim sNursing As New BenefitLimit(session, oPolicy)
                sNursing.Client = oClient
                sNursing.BenefitLimit = "Charges for Nursing Care/Drugs/Surgical Dressings"
                sNursing.FullRefund = True
                sNursing.PercentageToPay = 100
                sNursing.Parent = sDayCase
                sNursing.Save()

                Dim sPath As New BenefitLimit(session, oPolicy)
                sPath.Client = oClient
                sPath.BenefitLimit = "Pathology, Radiology and Diagnostic tests"
                sPath.AuthorisationType = eAuthorisationType.Diagnostics
                sPath.FullRefund = True
                sPath.PercentageToPay = 100
                sPath.Parent = sDayCase
                sPath.Save()

                Dim sScans As New BenefitLimit(session, oPolicy)
                sScans.Client = oClient
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sPros As New BenefitLimit(session, oPolicy)
                sPros.Client = oClient
                sPros.BenefitLimit = "Prostheses and Appliances"
                sPros.FullRefund = True
                sPros.PercentageToPay = 100
                sPros.Parent = sDayCase
                sPros.Save()

                Dim sDCAccomodation As New BenefitLimit(session, oPolicy)
                sDCAccomodation.Client = oClient
                sDCAccomodation.BenefitLimit = "Accommodation"
                sDCAccomodation.FullRefund = True
                sDCAccomodation.PercentageToPay = 100
                sDCAccomodation.Parent = sDayCase
                sDCAccomodation.Save()

                Dim sParentAcc As New BenefitLimit(session, oPolicy)
                sParentAcc.Client = oClient
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (staying with a child under 16)"
                sParentAcc.FullRefund = True
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100

                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session, oPolicy)
                sOther.Client = oClient
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehabHdr As New BenefitLimit(session, oPolicy)
                sRehabHdr.Client = oClient
                sRehabHdr.BenefitLimit = "Rehab"
                sRehabHdr.Parent = sOther
                sRehabHdr.Save()

                Dim sRehab As New BenefitLimit(session, oPolicy)
                sRehab.Client = oClient
                sRehab.BenefitLimit = "Charges for functional capability assessment and physiotherapy"
                sRehab.Parent = sRehabHdr
                sRehab.Save()

                Dim sSubCashBenefitHdr As New BenefitLimit(session, oPolicy)
                sSubCashBenefitHdr.Client = oClient
                sSubCashBenefitHdr.BenefitLimit = "Cash Benefit"
                sSubCashBenefitHdr.Parent = sOther
                sSubCashBenefitHdr.Save()

                Dim sSubCashBenefit2 As New BenefitLimit(session, oPolicy)
                sSubCashBenefit2.Client = oClient
                sSubCashBenefit2.Period = eBenefitPeriod.Daily
                sSubCashBenefit2.Limit = 150.0
                sSubCashBenefit2.AnnualLimit = 5250.0
                sSubCashBenefit2.AnnualSessions = 35
                sSubCashBenefit2.BenefitLimit = "NHS Cash Benefit"
                sSubCashBenefit2.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sSubCashBenefit2.Parent = sSubCashBenefitHdr
                sSubCashBenefit2.Save()

                Dim sSubCashBenefit1 As New BenefitLimit(session, oPolicy)
                sSubCashBenefit1.Client = oClient
                sSubCashBenefit1.BenefitLimit = "NHS out-patient or day-patient treatment - cancer"
                sSubCashBenefit1.Parent = sSubCashBenefitHdr
                sSubCashBenefit1.Save()

                Dim sSubCashBenefit3 As New BenefitLimit(session, oPolicy)
                sSubCashBenefit3.Client = oClient
                sSubCashBenefit3.BenefitLimit = "NHS in-patient treatment for or directly related to cancer"
                sSubCashBenefit3.Parent = sSubCashBenefitHdr
                sSubCashBenefit3.Save()


                Dim sHomeNursingHdr As New BenefitLimit(session, oPolicy)
                sHomeNursingHdr.Client = oClient
                sHomeNursingHdr.BenefitLimit = "Nursing"
                sHomeNursingHdr.Parent = sOther
                sHomeNursingHdr.Save()

                Dim sHomeNursing As New BenefitLimit(session, oPolicy)
                sHomeNursing.Client = oClient
                sHomeNursing.BenefitLimit = "Home Nursing"
                sHomeNursing.AnnualLimit = 2000
                sHomeNursing.Parent = sHomeNursingHdr
                sHomeNursing.Save()

                Dim sAmbulanceHdr As New BenefitLimit(session, oPolicy)
                sAmbulanceHdr.Client = oClient
                sAmbulanceHdr.BenefitLimit = "Private Ambulance"
                sAmbulanceHdr.Parent = sOther
                sAmbulanceHdr.Save()

                Dim sAmbulance1 As New BenefitLimit(session, oPolicy)
                sAmbulance1.Client = oClient
                sAmbulance1.BenefitLimit = "Private ambulance - Other"
                sAmbulance1.Period = eBenefitPeriod.Claim
                sAmbulance1.Limit = 80
                sAmbulance1.Parent = sAmbulanceHdr
                sAmbulance1.Save()

                Dim sAmbulance2 As New BenefitLimit(session, oPolicy)
                sAmbulance2.Client = oClient
                sAmbulance2.BenefitLimit = "Private ambulance - Transfer between medical facilities"
                sAmbulance2.Parent = sAmbulanceHdr
                sAmbulance2.Save()


                Dim sOutPatient As New BenefitLimit(session, oPolicy)
                sOutPatient.Client = oClient
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sOutsConsFee As New BenefitLimit(session, oPolicy)
                sOutsConsFee.Client = oClient
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.FullRefund = True
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutTheatre As New BenefitLimit(session, oPolicy)
                sOutTheatre.Client = oClient
                sOutTheatre.BenefitLimit = "Treatment/Theatre Costs"
                sOutTheatre.FullRefund = True
                sOutTheatre.PercentageToPay = 100

                sOutTheatre.Parent = sOutPatient
                sOutTheatre.Save()

                Dim sOutCancer As New BenefitLimit(session, oPolicy)
                sOutCancer.Client = oClient
                sOutCancer.BenefitLimit = "Cancer - Diagnostic Treatment, Specialist Fees and Surgery "
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()

                Dim sOutCancerDr As New BenefitLimit(session, oPolicy)
                sOutCancerDr.Client = oClient
                sOutCancerDr.BenefitLimit = "Cancer - Drug Treatment"
                sOutCancerDr.FullRefund = True
                sOutCancerDr.PercentageToPay = 100
                sOutCancerDr.Parent = sOutPatient
                sOutCancerDr.Save()


                Dim sOutPath As New BenefitLimit(session, oPolicy)
                sOutPath.Client = oClient
                sOutPath.BenefitLimit = "Pathology, Radiology and Diagnostic Tests"
                sOutPath.AuthorisationType = eAuthorisationType.Diagnostics
                sOutPath.FullRefund = True
                sOutPath.PercentageToPay = 100

                sOutPath.Parent = sOutPatient
                sOutPath.Save()

                Dim sOutScan As New BenefitLimit(session, oPolicy)
                sOutScan.Client = oClient
                sOutScan.BenefitLimit = "MRI, CT and PET scans "
                sOutScan.AuthorisationType = eAuthorisationType.Diagnostics
                sOutScan.FullRefund = True
                sOutScan.PercentageToPay = 100

                sOutScan.Parent = sOutPatient
                sOutScan.Save()

                Dim sOutPsy As New BenefitLimit(session, oPolicy)
                sOutPsy.Client = oClient
                sOutPsy.BenefitLimit = "Psychiatric Fees"
                sOutPsy.BenefitLimit = "Psychiatric Fees"
                sOutPsy.AuthorisationType = eAuthorisationType.Consultation
                sOutPsy.AnnualLimit = 2000
                sOutPsy.FullRefund = True
                sOutPsy.PercentageToPay = 100

                sOutPsy.Parent = sOutPatient
                sOutPsy.Save()

                Dim sTherapists As New BenefitLimit(session, oPolicy)
                sTherapists.Client = oClient
                sTherapists.BenefitLimit = "Therapists Fees"
                sTherapists.Period = eBenefitPeriod.Annual
                sTherapists.AuthorisationType = eAuthorisationType.Consultation
                sTherapists.FullRefund = True
                sTherapists.PercentageToPay = 100

                sTherapists.Parent = sOutPatient
                sTherapists.Save()

                Dim sComplimentary As New BenefitLimit(session, oPolicy)
                sComplimentary.Client = oClient
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualLimit = 250
                sComplimentary.AnnualSessions = 10

                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

            Catch ex As Exception

            End Try
        End Sub
        Private Shared Sub CheckForRRBenefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 116))
                If oClient Is Nothing Then
                    Return
                End If

                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=?", oClient.Oid))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Policy=?", oScheme.Oid, "2014/15"))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2014/1"
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.Moratorium = 0
                    oPolicy.StartDate = DateTime.Parse("2014-10-01")
                    oPolicy.EndDate = DateTime.Parse("2015-09-30")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session, oPolicy)
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sConsFee As New BenefitLimit(session, oPolicy)
                sConsFee.Client = oClient
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.FullRefund = True
                sConsFee.PercentageToPay = 100
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sTheatre As New BenefitLimit(session, oPolicy)
                sTheatre.Client = oClient
                sTheatre.BenefitLimit = "Theatre Costs"
                sTheatre.FullRefund = True
                sTheatre.PercentageToPay = 100

                sTheatre.Parent = sDayCase
                sTheatre.Save()

                Dim sInCancer As New BenefitLimit(session, oPolicy)
                sInCancer.Client = oClient
                sInCancer.BenefitLimit = "Cancer - Diagnostic Treatment, Specialist Fees and Surgery "

                sInCancer.FullRefund = True
                sInCancer.PercentageToPay = 100
                sInCancer.Parent = sDayCase
                sInCancer.Save()

                Dim sInCancerDrug As New BenefitLimit(session, oPolicy)
                sInCancerDrug.Client = oClient
                sInCancerDrug.BenefitLimit = "Cancer - Drug Treatment"
                sInCancerDrug.FullRefund = True
                sInCancerDrug.PercentageToPay = 100
                sInCancerDrug.Parent = sDayCase
                sInCancerDrug.Save()

                Dim sNursing As New BenefitLimit(session, oPolicy)
                sNursing.Client = oClient
                sNursing.BenefitLimit = "Charges for Nursing Care/Drugs/Surgical Dressings"
                sNursing.FullRefund = True
                sNursing.PercentageToPay = 100
                sNursing.Parent = sDayCase
                sNursing.Save()

                Dim sInExcl1 As New BenefitLimit(session, oPolicy)
                sInExcl1.Client = oClient
                sInExcl1.BenefitLimit = "Excluded Hospital Day-Patient Treatment"
                sInExcl1.Limit = 200
                sInExcl1.Period = eBenefitPeriod.Daily
                sInExcl1.FullRefund = True
                sInExcl1.PercentageToPay = 100

                sInExcl1.Parent = sDayCase
                sInExcl1.Save()

                Dim sInExcl2 As New BenefitLimit(session, oPolicy)
                sInExcl2.Client = oClient
                sInExcl2.BenefitLimit = "Excluded Hospital In-Patient Treatment"
                sInExcl1.Limit = 250
                sInExcl1.Period = eBenefitPeriod.Daily
                sInExcl2.FullRefund = True
                sInExcl2.PercentageToPay = 100
                sInExcl2.Parent = sDayCase
                sInExcl2.Save()

                Dim sInPsy As New BenefitLimit(session, oPolicy)
                sInPsy.Client = oClient
                sInPsy.BenefitLimit = "Psychiatric Fees"
                sInPsy.AuthorisationType = eAuthorisationType.Consultation
                sInPsy.AnnualSessions = 28
                sInPsy.FullRefund = True
                sInPsy.PercentageToPay = 100

                sInPsy.Parent = sDayCase
                sInPsy.Save()

                Dim sPath As New BenefitLimit(session, oPolicy)
                sPath.Client = oClient
                sPath.BenefitLimit = "Pathology, Radiology and Diagnostic tests"
                sPath.AuthorisationType = eAuthorisationType.Diagnostics
                sPath.FullRefund = True
                sPath.PercentageToPay = 100
                sPath.Parent = sDayCase
                sPath.Save()

                Dim sScans As New BenefitLimit(session, oPolicy)
                sScans.Client = oClient
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sPros As New BenefitLimit(session, oPolicy)
                sPros.Client = oClient
                sPros.BenefitLimit = "Prostheses and Appliances"
                sPros.FullRefund = True
                sPros.PercentageToPay = 100
                sPros.Parent = sDayCase
                sPros.Save()

                Dim sDCAccomodation As New BenefitLimit(session, oPolicy)
                sDCAccomodation.Client = oClient
                sDCAccomodation.BenefitLimit = "Accommodation"
                sDCAccomodation.FullRefund = True
                sDCAccomodation.PercentageToPay = 100
                sDCAccomodation.Parent = sDayCase
                sDCAccomodation.Save()

                Dim sParentAcc As New BenefitLimit(session, oPolicy)
                sParentAcc.Client = oClient
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (staying with a child under 12)"
                sParentAcc.FullRefund = True
                sParentAcc.LowerAgeLimit = 12
                sParentAcc.PercentageToPay = 100

                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session, oPolicy)
                sOther.Client = oClient
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sOtherHdr As New BenefitLimit(session, oPolicy)
                sOtherHdr.Client = oClient
                sOtherHdr.BenefitLimit = "Other"
                sOtherHdr.Parent = sOther
                sOtherHdr.Save()




                Dim sHospice As New BenefitLimit(session, oPolicy)
                sHospice.Client = oClient
                sHospice.Period = eBenefitPeriod.Daily
                sHospice.Limit = 70
                sHospice.AnnualSessions = 10
                sHospice.BenefitLimit = "Hospice Donation"
                sHospice.AuthorisationType = eAuthorisationType.Hospice
                sHospice.Parent = sOtherHdr
                sHospice.Save()

                Dim sOverseas As New BenefitLimit(session, oPolicy)
                sOverseas.Client = oClient
                sOverseas.Period = eBenefitPeriod.Daily
                sOverseas.BenefitLimit = "Limited Emergency Overseas Treatment"
                sOverseas.Parent = sOtherHdr
                sOverseas.Save()

                Dim sMinor As New BenefitLimit(session, oPolicy)
                sMinor.Client = oClient
                sMinor.Period = eBenefitPeriod.Daily
                sMinor.BenefitLimit = "Minor Surgery"
                sMinor.Limit = 70
                sMinor.Period = eBenefitPeriod.Claim
                sMinor.Parent = sOtherHdr
                sMinor.Save()

                Dim sSleep As New BenefitLimit(session, oPolicy)
                sSleep.Client = oClient
                sSleep.Period = eBenefitPeriod.Daily
                sSleep.BenefitLimit = "Sleep disorders and Sleep problems"
                sSleep.AnnualLimit = 1000
                sSleep.Parent = sOtherHdr
                sSleep.Save()

                Dim sWarts As New BenefitLimit(session, oPolicy)
                sWarts.Client = oClient
                sWarts.Period = eBenefitPeriod.Daily
                sWarts.BenefitLimit = "Warts and Verrucas"
                sWarts.AnnualLimit = 1000
                sWarts.Parent = sOtherHdr
                sWarts.Save()

                Dim sChildBirthHdr As New BenefitLimit(session, oPolicy)
                sChildBirthHdr.Client = oClient
                sChildBirthHdr.BenefitLimit = "Child Birth and Pregnancy Treatment"
                sChildBirthHdr.Parent = sOther
                sChildBirthHdr.Save()

                Dim sChildBirth1 As New BenefitLimit(session, oPolicy)
                sChildBirth1.Client = oClient
                sChildBirth1.BenefitLimit = "Child Birth and Pregnancy complications"
                sChildBirth1.Parent = sChildBirthHdr
                sChildBirth1.Save()

                Dim sChildBirth2 As New BenefitLimit(session, oPolicy)
                sChildBirth2.Client = oClient
                sChildBirth2.BenefitLimit = "Consultations - Infertility"
                sChildBirth2.AuthorisationType = eAuthorisationType.Consultation
                sChildBirth2.Parent = sChildBirthHdr
                sChildBirth2.Save()

                Dim sChildBirth3 As New BenefitLimit(session, oPolicy)
                sChildBirth3.Client = oClient
                sChildBirth3.BenefitLimit = "Diagnostic tests - Infertility"
                sChildBirth3.AuthorisationType = eAuthorisationType.Diagnostics
                sChildBirth3.Parent = sChildBirthHdr
                sChildBirth3.Save()


                Dim sHomeNursingHdr As New BenefitLimit(session, oPolicy)
                sHomeNursingHdr.Client = oClient
                sHomeNursingHdr.BenefitLimit = "Nursing"
                sHomeNursingHdr.Parent = sOther
                sHomeNursingHdr.Save()

                Dim sHomeNursing As New BenefitLimit(session, oPolicy)
                sHomeNursing.Client = oClient
                sHomeNursing.BenefitLimit = "Home Nursing"
                sHomeNursing.AnnualLimit = 2000
                sHomeNursing.Parent = sHomeNursingHdr
                sHomeNursing.Save()

                Dim sAmbulanceHdr As New BenefitLimit(session, oPolicy)
                sAmbulanceHdr.Client = oClient
                sAmbulanceHdr.BenefitLimit = "Private Ambulance"
                sAmbulanceHdr.Parent = sOther
                sAmbulanceHdr.Save()

                Dim sAmbulance1 As New BenefitLimit(session, oPolicy)
                sAmbulance1.Client = oClient
                sAmbulance1.BenefitLimit = "Private ambulance - Other"
                sAmbulance1.Parent = sAmbulanceHdr
                sAmbulance1.Save()

                Dim sAmbulance2 As New BenefitLimit(session, oPolicy)
                sAmbulance2.Client = oClient
                sAmbulance2.BenefitLimit = "Private ambulance - Transfer between medical facilities"
                sAmbulance2.Parent = sAmbulanceHdr
                sAmbulance2.Save()


                Dim sOutPatient As New BenefitLimit(session, oPolicy)
                sOutPatient.Client = oClient
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sOutsConsFee As New BenefitLimit(session, oPolicy)
                sOutsConsFee.Client = oClient
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.FullRefund = True
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutTheatre As New BenefitLimit(session, oPolicy)
                sOutTheatre.Client = oClient
                sOutTheatre.BenefitLimit = "Theatre Costs"
                sOutTheatre.FullRefund = True
                sOutTheatre.PercentageToPay = 100

                sOutTheatre.Parent = sOutPatient
                sOutTheatre.Save()

                Dim sOutCancer As New BenefitLimit(session, oPolicy)
                sOutCancer.Client = oClient
                sOutCancer.BenefitLimit = "Cancer - Diagnostic Treatment, Specialist Fees and Surgery "
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()

                Dim sOutCancerDr As New BenefitLimit(session, oPolicy)
                sOutCancerDr.Client = oClient
                sOutCancerDr.BenefitLimit = "Cancer - Drug Treatment"
                sOutCancerDr.FullRefund = True
                sOutCancerDr.PercentageToPay = 100
                sOutCancerDr.Parent = sOutPatient
                sOutCancerDr.Save()

                Dim sCancerDrugTherap As New BenefitLimit(session, oPolicy)
                sCancerDrugTherap.Client = oClient
                sCancerDrugTherap.BenefitLimit = "Cancer Drug Therapy"
                sCancerDrugTherap.Parent = sOutPatient
                sCancerDrugTherap.Save()

                Dim sMusc As New BenefitLimit(session, oPolicy)
                sMusc.Client = oClient
                sMusc.BenefitLimit = "Musculoskeletal Conditions"
                sMusc.Period = eBenefitPeriod.Annual
                sMusc.FullRefund = True
                sMusc.PercentageToPay = 100

                sMusc.Parent = sOutPatient
                sMusc.Save()


                Dim sChemo As New BenefitLimit(session, oPolicy)
                sChemo.Client = oClient
                sChemo.BenefitLimit = "Radiotherapy / Chemotherapy Fees"
                sChemo.Parent = sOutPatient
                sChemo.Save()

                Dim sOutPath As New BenefitLimit(session, oPolicy)
                sOutPath.Client = oClient
                sOutPath.BenefitLimit = "Pathology, Radiology and Diagnostic Tests"
                sOutPath.AuthorisationType = eAuthorisationType.Diagnostics
                sOutPath.FullRefund = True
                sOutPath.PercentageToPay = 100

                sOutPath.Parent = sOutPatient
                sOutPath.Save()

                Dim sOutScan As New BenefitLimit(session, oPolicy)
                sOutScan.Client = oClient
                sOutScan.BenefitLimit = "MRI, CT and PET scans "
                sOutScan.AuthorisationType = eAuthorisationType.Diagnostics
                sOutScan.FullRefund = True
                sOutScan.PercentageToPay = 100

                sOutScan.Parent = sOutPatient
                sOutScan.Save()

                Dim sOutPsy As New BenefitLimit(session, oPolicy)
                sOutPsy.Client = oClient
                sOutPsy.BenefitLimit = "Psychiatric Fees"
                sOutPsy.AuthorisationType = eAuthorisationType.Consultation
                sOutPsy.AnnualLimit = 1000
                sOutPsy.FullRefund = True
                sOutPsy.PercentageToPay = 100

                sOutPsy.Parent = sOutPatient
                sOutPsy.Save()

                Dim sTherapists As New BenefitLimit(session, oPolicy)
                sTherapists.Client = oClient
                sTherapists.BenefitLimit = "Therapists Fees"
                sTherapists.AuthorisationType = eAuthorisationType.Consultation
                sTherapists.Period = eBenefitPeriod.Annual
                sTherapists.FullRefund = True
                sTherapists.PercentageToPay = 100

                sTherapists.Parent = sOutPatient
                sTherapists.Save()

                Dim sComplimentary As New BenefitLimit(session, oPolicy)
                sComplimentary.Client = oClient
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualLimit = 250
                sComplimentary.AnnualSessions = 10

                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()


            Catch ex As Exception

            End Try
        End Sub
        Private Shared Sub CheckForRRRBenefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 119))
                If oClient Is Nothing Then
                    Return
                End If

                If oClient.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Claim
                sHospFee.FullRefund = True
                sHospFee.Limit = 0
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Claim
                sConsFee.Limit = 1
                sConsFee.FullRefund = True
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Claim
                sDCCancer.FullRefund = True
                sDCCancer.PercentageToPay = 100
                sDCCancer.Limit = 0
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Claim
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Limit = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sPhych As New BenefitLimit(session)
                sPhych.Client = oClient
                sPhych.BenefitLimit = "Psychiatric treatment"
                sPhych.Period = eBenefitPeriod.Claim
                sPhych.AnnualSessions = 0
                sPhych.FullRefund = True
                sPhych.Limit = 0
                sPhych.PercentageToPay = 100
                sPhych.Parent = sDayCase
                sPhych.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit.Limit = 0
                sNHSCashBenefit.Period = eBenefitPeriod.Claim
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.BenefitLimit = "Treatment/Theatre Costs"
                sHospFeeOP.Period = eBenefitPeriod.Claim
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.Limit = 0
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Claim
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Limit = 1
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Claim
                sOutCancer.Limit = 1
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Claim
                sClinical.Parent = sOutPatient
                sClinical.Limit = 0
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Claim
                sComplimentary.AnnualSessions = 0
                sComplimentary.Limit = 0
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Claim
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.Limit = 0
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

                Dim sOutPsy As New BenefitLimit(session)
                sOutPsy.Client = oClient
                sOutPsy.BenefitLimit = "Psychiatric Fees"
                sOutPsy.Period = eBenefitPeriod.Claim
                sOutPsy.AuthorisationType = eAuthorisationType.Consultation
                sOutPsy.FullRefund = True
                sOutPsy.Limit = 0
                sOutPsy.PercentageToPay = 100
                sOutPsy.Parent = sOutPatient
                sOutPsy.Save()

            Catch ex As Exception

            End Try
        End Sub
        Private Shared Sub CheckForHMT1Benefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If

                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "HMT1"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.Moratorium = 0
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                Dim sPhyIn As New BenefitLimit(session)
                sPhyIn.Client = oClient
                sPhyIn.Policy = oPolicy
                sPhyIn.BenefitLimit = "Psychiatric treatment "
                sPhyIn.Period = eBenefitPeriod.Annual
                sPhyIn.FullRefund = True
                sPhyIn.Sessions = 28
                sPhyIn.LowerAgeLimit = 0
                sPhyIn.PercentageToPay = 100
                sPhyIn.Parent = sDayCase
                sPhyIn.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans"
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()


                Dim sPhyOut As New BenefitLimit(session)
                sPhyOut.Client = oClient
                sPhyOut.Policy = oPolicy
                sPhyOut.BenefitLimit = "Psychiatric treatment"
                sPhyOut.Period = eBenefitPeriod.Annual
                sPhyOut.FullRefund = True
                sPhyOut.Sessions = 0
                sPhyOut.AnnualLimit = 1000
                sPhyOut.LowerAgeLimit = 0
                sPhyOut.PercentageToPay = 100
                sPhyOut.Parent = sOutPatient
                sPhyOut.Save()

                Dim sKidney As New BenefitLimit(session)
                sKidney.Client = oClient
                sKidney.Policy = oPolicy
                sKidney.BenefitLimit = "Kidney Dialysis preparation"
                sKidney.Period = eBenefitPeriod.Annual
                sKidney.FullRefund = True
                sKidney.Sessions = -1
                sKidney.AnnualLimit = 0
                sKidney.LowerAgeLimit = 0
                sKidney.PercentageToPay = 100
                sKidney.Parent = sOutPatient
                sKidney.Save()


            Catch ex As Exception

            End Try
        End Sub
        Private Shared Sub CheckForHMT2Benefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If

                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "HMT2"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.Moratorium = 24
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                Dim sPhyIn As New BenefitLimit(session)
                sPhyIn.Client = oClient
                sPhyIn.Policy = oPolicy
                sPhyIn.BenefitLimit = "Psychiatric treatment "
                sPhyIn.Period = eBenefitPeriod.Annual
                sPhyIn.FullRefund = True
                sPhyIn.Sessions = 28
                sPhyIn.LowerAgeLimit = 0
                sPhyIn.PercentageToPay = 100
                sPhyIn.Parent = sDayCase
                sPhyIn.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()


                Dim sPhyOut As New BenefitLimit(session)
                sPhyOut.Client = oClient
                sPhyOut.Policy = oPolicy
                sPhyOut.BenefitLimit = "Psychiatric treatment "
                sPhyOut.Period = eBenefitPeriod.Annual
                sPhyOut.FullRefund = True
                sPhyOut.Sessions = 0
                sPhyOut.AnnualLimit = 1000
                sPhyOut.LowerAgeLimit = 0
                sPhyOut.PercentageToPay = 100
                sPhyOut.Parent = sOutPatient
                sPhyOut.Save()

                Dim sKidney As New BenefitLimit(session)
                sKidney.Client = oClient
                sKidney.Policy = oPolicy
                sKidney.BenefitLimit = "Kidney Dialysis preparation"
                sKidney.Period = eBenefitPeriod.Annual
                sKidney.FullRefund = True
                sKidney.Sessions = -1
                sKidney.AnnualLimit = 0
                sKidney.LowerAgeLimit = 0
                sKidney.PercentageToPay = 100
                sKidney.Parent = sOutPatient
                sKidney.Save()
            Catch ex As Exception

            End Try
        End Sub
        Private Shared Sub CheckForHMT3Benefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If

                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "HMT3"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Scheme = oScheme
                    oPolicy.Moratorium = 0
                    oPolicy.Excess = 100
                    oPolicy.DependantExcess = 100
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Chemo/Radiotherapy Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

            Catch ex As Exception

            End Try
        End Sub
        Private Shared Sub CheckForHMT4Benefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If
                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "HMT4"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Moratorium = 0
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.CostSharePerc = 10
                    oPolicy.Costsharelimit = 250
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Chemo/Radiotherapy Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()



                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

            Catch ex As Exception
                Dim y = ex
            End Try
        End Sub
        Private Shared Sub CheckForHMT5Benefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If
                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "HMT5"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Moratorium = 24
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 100
                    oPolicy.DependantExcess = 100
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

            Catch ex As Exception
                Dim y = ex
            End Try
        End Sub
        Private Shared Sub CheckForHMT6Benefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If
                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "HMT6"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Moratorium = 0
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 50
                    oPolicy.DependantExcess = 50
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Chemo/Radiotherapy Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()



                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sCancer As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Cancer Treatment"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 0
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

            Catch ex As Exception
                Dim y = ex
            End Try
        End Sub
        Private Shared Sub CheckForHMT7Benefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If
                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "HMT7"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Moratorium = 0
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                Dim sPsyIn As New BenefitLimit(session)
                sPsyIn.Client = oClient
                sPsyIn.Policy = oPolicy
                sPsyIn.BenefitLimit = "Psychiatric Treatment"
                sPsyIn.Period = eBenefitPeriod.Annual
                sPsyIn.FullRefund = True
                sPsyIn.AnnualSessions = 0
                sPsyIn.AnnualLimit = 10000
                sPsyIn.LowerAgeLimit = 0
                sPsyIn.PercentageToPay = 100
                sPsyIn.Parent = sDayCase
                sPsyIn.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit.Limit = 150
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5250
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()

                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

                Dim sPsyOut As New BenefitLimit(session)
                sPsyOut.Client = oClient
                sPsyOut.Policy = oPolicy
                sPsyOut.BenefitLimit = "Psychiatric Treatment"
                sPsyOut.Period = eBenefitPeriod.Annual
                sPsyOut.FullRefund = True
                sPsyOut.AnnualLimit = 1000
                sPsyOut.LowerAgeLimit = 0
                sPsyOut.PercentageToPay = 100
                sPsyOut.Parent = sOutPatient
                sPsyOut.Save()

            Catch ex As Exception
                Dim y = ex
            End Try
        End Sub
        Private Shared Sub CheckForHMT8Benefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If
                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "HMT8"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Moratorium = 0
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                Dim sPsyIn As New BenefitLimit(session)
                sPsyIn.Client = oClient
                sPsyIn.Policy = oPolicy
                sPsyIn.BenefitLimit = "Psychiatric Treatment"
                sPsyIn.Period = eBenefitPeriod.Annual
                sPsyIn.FullRefund = True
                sPsyIn.AnnualLimit = 10000
                sPsyIn.LowerAgeLimit = 0
                sPsyIn.PercentageToPay = 100
                sPsyIn.Parent = sDayCase
                sPsyIn.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()

                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

                Dim sPsyOut As New BenefitLimit(session)
                sPsyOut.Client = oClient
                sPsyOut.Policy = oPolicy
                sPsyOut.BenefitLimit = "Psychiatric Treatment"
                sPsyOut.Period = eBenefitPeriod.Annual
                sPsyOut.FullRefund = True
                sPsyOut.AnnualLimit = 1000
                sPsyOut.LowerAgeLimit = 0
                sPsyOut.PercentageToPay = 100
                sPsyOut.Parent = sOutPatient
                sPsyOut.Save()

                Dim sKidney As New BenefitLimit(session)
                sKidney.Client = oClient
                sKidney.Policy = oPolicy
                sKidney.BenefitLimit = "Kidney Dialysis preparation"
                sKidney.FullRefund = True
                sKidney.Sessions = -1
                sKidney.PercentageToPay = 100
                sKidney.Parent = sOutPatient
                sKidney.Save()

            Catch ex As Exception
                Dim y = ex
            End Try
        End Sub
        Private Shared Sub CheckFor9JL2Benefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If
                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "9JL2"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Moratorium = 0
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sComp As New BenefitLimit(session)
                sComp.Client = oClient
                sComp.Policy = oPolicy
                sComp.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComp.Period = eBenefitPeriod.Lifetime
                sComp.FullRefund = True
                sComp.Limit = 250
                sComp.AnnualLimit = 250
                sComp.LowerAgeLimit = 0
                sComp.PercentageToPay = 100
                sComp.Parent = sDayCase
                sComp.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                Dim sPsyIn As New BenefitLimit(session)
                sPsyIn.Client = oClient
                sPsyIn.Policy = oPolicy
                sPsyIn.BenefitLimit = "Psychiatric Treatment"
                sPsyIn.Period = eBenefitPeriod.Lifetime
                sPsyIn.FullRefund = True
                sPsyIn.Limit = 100
                sPsyIn.LowerAgeLimit = 0
                sPsyIn.PercentageToPay = 100
                sPsyIn.Parent = sDayCase
                sPsyIn.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Chemo/Radiotherapy Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 2000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()


                Dim sNHSCashBenefit2 As New BenefitLimit(session)
                sNHSCashBenefit2.Client = oClient
                sNHSCashBenefit2.Policy = oPolicy
                sNHSCashBenefit2.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit2.Limit = 50
                sNHSCashBenefit2.Period = eBenefitPeriod.Daily
                sNHSCashBenefit2.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit2.AnnualLimit = 2000
                sNHSCashBenefit2.Parent = sOther
                sNHSCashBenefit2.Save()


                Dim sTransport As New BenefitLimit(session)
                sTransport.Client = oClient
                sTransport.Policy = oPolicy
                sTransport.BenefitLimit = "Transport from Jersey to UK (Channel Island)"
                sTransport.Limit = 50
                sTransport.Period = eBenefitPeriod.Annual
                sTransport.AnnualLimit = 1500
                sTransport.Parent = sOther
                sTransport.Save()

                Dim sDental As New BenefitLimit(session)
                sDental.Client = oClient
                sDental.Policy = oPolicy
                sDental.BenefitLimit = "Accidental dental damage"
                sDental.Limit = 0
                sDental.Period = eBenefitPeriod.Annual
                sDental.AnnualLimit = 1000
                sDental.Parent = sOther
                sDental.Save()



                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

                Dim sPsyOut As New BenefitLimit(session)
                sPsyOut.Client = oClient
                sPsyOut.Policy = oPolicy
                sPsyOut.BenefitLimit = "Psychiatric Treatment"
                sPsyOut.Period = eBenefitPeriod.Annual
                sPsyOut.FullRefund = True
                sPsyOut.AnnualLimit = 1000
                sPsyOut.LowerAgeLimit = 0
                sPsyOut.PercentageToPay = 100
                sPsyOut.Parent = sOutPatient
                sPsyOut.Save()

                Dim sPhysio As New BenefitLimit(session)
                sPhysio.Client = oClient
                sPhysio.Policy = oPolicy
                sPhysio.BenefitLimit = "Physiotherapy"
                sPhysio.FullRefund = True
                sPhysio.AnnualLimit = 0
                sPhysio.LowerAgeLimit = 0
                sPhysio.PercentageToPay = 100
                sPhysio.Parent = sOutPatient
                sPhysio.Save()

            Catch ex As Exception
                Dim y = ex
            End Try
        End Sub
        Private Shared Sub CheckForG9RBBenefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If
                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "G9RB"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Moratorium = 0
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 0
                    oPolicy.DependantExcess = 0
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sComp As New BenefitLimit(session)
                sComp.Client = oClient
                sComp.Policy = oPolicy
                sComp.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComp.Period = eBenefitPeriod.Lifetime
                sComp.FullRefund = True
                sComp.Limit = 250
                sComp.AnnualLimit = 250
                sComp.LowerAgeLimit = 0
                sComp.PercentageToPay = 100
                sComp.Parent = sDayCase
                sComp.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                Dim sAmtBed As New BenefitLimit(session)
                sAmtBed.Client = oClient
                sAmtBed.Policy = oPolicy
                sAmtBed.BenefitLimit = "Amenity Bed Contribution"
                sAmtBed.FullRefund = True
                sAmtBed.Limit = 140
                sAmtBed.AnnualLimit = 2100
                sAmtBed.LowerAgeLimit = 0
                sAmtBed.PercentageToPay = 100
                sAmtBed.Parent = sDayCase
                sAmtBed.Save()

                Dim sPsyIn As New BenefitLimit(session)
                sPsyIn.Client = oClient
                sPsyIn.Policy = oPolicy
                sPsyIn.BenefitLimit = "Psychiatric Treatment"
                sPsyIn.Period = eBenefitPeriod.Lifetime
                sPsyIn.FullRefund = True
                sPsyIn.Limit = 100
                sPsyIn.LowerAgeLimit = 0
                sPsyIn.PercentageToPay = 100
                sPsyIn.Parent = sDayCase
                sPsyIn.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Chemo/Radiotherapy Cash Benefit"
                sNHSCashBenefit.Limit = 50
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 2000
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()


                Dim sNHSCashBenefit2 As New BenefitLimit(session)
                sNHSCashBenefit2.Client = oClient
                sNHSCashBenefit2.Policy = oPolicy
                sNHSCashBenefit2.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit2.Limit = 50
                sNHSCashBenefit2.Period = eBenefitPeriod.Daily
                sNHSCashBenefit2.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit2.AnnualLimit = 2000
                sNHSCashBenefit2.Parent = sOther
                sNHSCashBenefit2.Save()


                Dim sTransport As New BenefitLimit(session)
                sTransport.Client = oClient
                sTransport.Policy = oPolicy
                sTransport.BenefitLimit = "Transport from Guernsey to UK (Channel Island)"
                sTransport.Limit = 50
                sTransport.Period = eBenefitPeriod.Annual
                sTransport.AnnualLimit = 1500
                sTransport.Parent = sOther
                sTransport.Save()

                Dim sDental As New BenefitLimit(session)
                sDental.Client = oClient
                sDental.Policy = oPolicy
                sDental.BenefitLimit = "Accidental dental damage"
                sDental.Limit = 0
                sDental.Period = eBenefitPeriod.Annual
                sDental.AnnualLimit = 1000
                sDental.Parent = sOther
                sDental.Save()



                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

                Dim sPsyOut As New BenefitLimit(session)
                sPsyOut.Client = oClient
                sPsyOut.Policy = oPolicy
                sPsyOut.BenefitLimit = "Psychiatric Treatment"
                sPsyOut.Period = eBenefitPeriod.Annual
                sPsyOut.FullRefund = True
                sPsyOut.AnnualLimit = 1000
                sPsyOut.LowerAgeLimit = 0
                sPsyOut.PercentageToPay = 100
                sPsyOut.Parent = sOutPatient
                sPsyOut.Save()

                Dim sPhysio As New BenefitLimit(session)
                sPhysio.Client = oClient
                sPhysio.Policy = oPolicy
                sPhysio.BenefitLimit = "Physiotherapy"
                sPhysio.FullRefund = True
                sPhysio.AnnualLimit = 0
                sPhysio.LowerAgeLimit = 0
                sPhysio.PercentageToPay = 100
                sPhysio.Parent = sOutPatient
                sPhysio.Save()

                Dim sGPServices As New BenefitLimit(session)
                sGPServices.Client = oClient
                sGPServices.Policy = oPolicy
                sGPServices.BenefitLimit = "GP Services"
                sGPServices.FullRefund = True
                sGPServices.AnnualLimit = 400
                sGPServices.LowerAgeLimit = 0
                sGPServices.PercentageToPay = 100
                sGPServices.Parent = sOutPatient
                sGPServices.Save()

                Dim sHealthCheck As New BenefitLimit(session)
                sHealthCheck.Client = oClient
                sHealthCheck.Policy = oPolicy
                sHealthCheck.BenefitLimit = "Health Check (every 2 years)"
                sHealthCheck.Period = eBenefitPeriod.BiAnnual
                sHealthCheck.FullRefund = True
                sHealthCheck.AnnualLimit = 400
                sHealthCheck.LowerAgeLimit = 0
                sHealthCheck.PercentageToPay = 100
                sHealthCheck.Parent = sOutPatient
                sHealthCheck.Save()

                Dim sOptical As New BenefitLimit(session)
                sOptical.Client = oClient
                sOptical.Policy = oPolicy
                sOptical.BenefitLimit = "Optical Cover"
                sOptical.Period = eBenefitPeriod.Annual
                sOptical.FullRefund = True
                sOptical.AnnualLimit = 25
                sOptical.LowerAgeLimit = 0
                sOptical.PercentageToPay = 100
                sOptical.Parent = sOutPatient
                sOptical.Save()
            Catch ex As Exception
                Dim y = ex
            End Try
        End Sub
        Private Shared Sub CheckForHMTXBenefits(ByVal session As UnitOfWork)
            Try

                Dim oClient As Client = session.FindObject(Of Client)(CriteriaOperator.Parse("Oid= ?", 120))
                If oClient Is Nothing Then
                    Return
                End If
                Dim oScheme As Scheme = session.FindObject(Of Scheme)(CriteriaOperator.Parse(" Client=? and Contains(Scheme,?)", oClient.Oid, "HMTX"))
                If oScheme Is Nothing Then
                    Return
                End If

                Dim oPolicy As Policy = session.FindObject(Of Policy)(CriteriaOperator.Parse("Scheme= ? and Client=?", oScheme.Oid, oClient.Oid))
                If oPolicy Is Nothing Then
                    oPolicy = New Policy(session)
                    oPolicy.Client = oClient
                    oPolicy.Policy = "2016/17"
                    oPolicy.Moratorium = 0
                    oPolicy.Scheme = oScheme
                    oPolicy.Excess = 100
                    oPolicy.DependantExcess = 100
                    oPolicy.StartDate = DateTime.Parse("01 Apr 2016")
                    oPolicy.EndDate = DateTime.Parse("31 Mar 2017")
                    oPolicy.Save()
                    session.CommitChanges()
                End If

                If oPolicy.BenefitLimits.Count > 0 Then
                    Return
                End If

                Dim sDayCase As New BenefitLimit(session)
                sDayCase.Policy = oPolicy
                sDayCase.Client = oClient
                sDayCase.BenefitLimit = "Day-Case/In-Patient"
                sDayCase.Save()

                'Day Case/InPatient
                Dim sHospFee As New BenefitLimit(session)
                sHospFee.Client = oClient
                sHospFee.Policy = oPolicy
                sHospFee.BenefitLimit = "Treatment/Theatre Costs"
                sHospFee.Period = eBenefitPeriod.Daily
                sHospFee.Sessions = 0
                sHospFee.FullRefund = True
                sHospFee.PercentageToPay = 100
                sHospFee.AuthorisationType = eAuthorisationType.Treatment
                sHospFee.Parent = sDayCase
                sHospFee.Save()

                Dim sConsFee As New BenefitLimit(session)
                sConsFee.Client = oClient
                sConsFee.Policy = oPolicy
                sConsFee.BenefitLimit = "Consultant Fees"
                sConsFee.Period = eBenefitPeriod.Annual
                sConsFee.FullRefund = True
                sConsFee.Sessions = 0
                sConsFee.PercentageToPay = 100
                sConsFee.AuthorisationType = eAuthorisationType.Consultation
                sConsFee.Parent = sDayCase
                sConsFee.Save()

                Dim sDCCancer As New BenefitLimit(session)
                sDCCancer.Client = oClient
                sDCCancer.Policy = oPolicy
                sDCCancer.BenefitLimit = "Diagnostic Tests"
                sDCCancer.Period = eBenefitPeriod.Annual
                sDCCancer.FullRefund = True
                sDCCancer.Sessions = 0
                sDCCancer.PercentageToPay = 100
                sDCCancer.AuthorisationType = eAuthorisationType.Diagnostics
                sDCCancer.Parent = sDayCase
                sDCCancer.Save()

                Dim sScans As New BenefitLimit(session)
                sScans.Client = oClient
                sScans.Policy = oPolicy
                sScans.BenefitLimit = "MRI, CT and PET scans "
                sScans.Period = eBenefitPeriod.Annual
                sScans.AuthorisationType = eAuthorisationType.Diagnostics
                sScans.FullRefund = True
                sScans.Sessions = 0
                sScans.PercentageToPay = 100
                sScans.Parent = sDayCase
                sScans.Save()

                Dim sParentAcc As New BenefitLimit(session)
                sParentAcc.Client = oClient
                sParentAcc.Policy = oPolicy
                sParentAcc.BenefitLimit = "Charges for Parent Accommodation (one parent staying with a child up to 16)"
                sParentAcc.Period = eBenefitPeriod.Annual
                sParentAcc.FullRefund = True
                sParentAcc.Sessions = 0
                sParentAcc.LowerAgeLimit = 16
                sParentAcc.PercentageToPay = 100
                sParentAcc.Parent = sDayCase
                sParentAcc.Save()

                'Other Benefits

                Dim sOther As New BenefitLimit(session)
                sOther.Client = oClient
                sOther.Policy = oPolicy
                sOther.BenefitLimit = "Other Benefits"
                sOther.Save()

                Dim sRehab As New BenefitLimit(session)
                sRehab.Client = oClient
                sRehab.Policy = oPolicy
                sRehab.BenefitLimit = "Private Ambulance"
                sRehab.FullRefund = True
                sRehab.PercentageToPay = 100
                sRehab.Parent = sOther
                sRehab.Save()

                Dim sHome As New BenefitLimit(session)
                sHome.Client = oClient
                sHome.Policy = oPolicy
                sHome.BenefitLimit = "Home Nursing"
                sHome.FullRefund = True
                sHome.PercentageToPay = 100
                sHome.Parent = sOther
                sHome.Save()

                Dim sNHSCashBenefit As New BenefitLimit(session)
                sNHSCashBenefit.Client = oClient
                sNHSCashBenefit.Policy = oPolicy
                sNHSCashBenefit.BenefitLimit = "NHS Cash Benefit"
                sNHSCashBenefit.Limit = 150
                sNHSCashBenefit.Period = eBenefitPeriod.Daily
                sNHSCashBenefit.AuthorisationType = eAuthorisationType.NHSCashBenefit
                sNHSCashBenefit.AnnualLimit = 5250
                sNHSCashBenefit.Parent = sOther
                sNHSCashBenefit.Save()



                Dim sGPHelpLine As New BenefitLimit(session)
                sGPHelpLine.Client = oClient
                sGPHelpLine.Policy = oPolicy
                sGPHelpLine.BenefitLimit = "GP Help Line"
                sGPHelpLine.FullRefund = True
                sGPHelpLine.PercentageToPay = 100
                sGPHelpLine.Parent = sOther
                sGPHelpLine.Save()

                Dim sOutPatient As New BenefitLimit(session)
                sOutPatient.Client = oClient
                sOutPatient.Policy = oPolicy
                sOutPatient.BenefitLimit = "OutPatient"
                sOutPatient.Save()

                Dim sHospFeeOP As New BenefitLimit(session)
                sHospFeeOP.Client = oClient
                sHospFeeOP.Policy = oPolicy
                sHospFeeOP.BenefitLimit = "Hospital Charges"
                sHospFeeOP.Period = eBenefitPeriod.Annual
                sHospFeeOP.FullRefund = True
                sHospFeeOP.PercentageToPay = 100
                sHospFeeOP.AuthorisationType = eAuthorisationType.Treatment
                sHospFeeOP.Parent = sOutPatient
                sHospFeeOP.Save()

                Dim sOutsConsFee As New BenefitLimit(session)
                sOutsConsFee.Client = oClient
                sOutsConsFee.Policy = oPolicy
                sOutsConsFee.BenefitLimit = "Consultant Fees"
                sOutsConsFee.Period = eBenefitPeriod.Annual
                sOutsConsFee.FullRefund = True
                sOutsConsFee.Sessions = 6
                sOutsConsFee.PercentageToPay = 100
                sOutsConsFee.AuthorisationType = eAuthorisationType.Consultation
                sOutsConsFee.Parent = sOutPatient
                sOutsConsFee.Save()

                Dim sOutCancer As New BenefitLimit(session)
                sOutCancer.Client = oClient
                sOutCancer.Policy = oPolicy
                sOutCancer.BenefitLimit = "Cancer Treatment"
                sOutCancer.Period = eBenefitPeriod.Annual
                sOutCancer.FullRefund = True
                sOutCancer.PercentageToPay = 100
                sOutCancer.Parent = sOutPatient
                sOutCancer.Save()


                Dim sClinical As New BenefitLimit(session)
                sClinical.Client = oClient
                sClinical.Policy = oPolicy
                sClinical.BenefitLimit = "Clinical Practitioner"
                sClinical.Period = eBenefitPeriod.Annual
                sClinical.Parent = sOutPatient
                sClinical.Sessions = 4
                sClinical.AuthorisationType = eAuthorisationType.Consultation
                sClinical.Save()

                Dim sComplimentary As New BenefitLimit(session)
                sComplimentary.Client = oClient
                sComplimentary.Policy = oPolicy
                sComplimentary.BenefitLimit = "Complimentary Medicine Practitioners Fees"
                sComplimentary.AuthorisationType = eAuthorisationType.Complementary
                sComplimentary.Period = eBenefitPeriod.Annual
                sComplimentary.AnnualSessions = 10
                sComplimentary.Sessions = 6
                sComplimentary.FullRefund = True
                sComplimentary.PercentageToPay = 100
                sComplimentary.Parent = sOutPatient
                sComplimentary.Save()

                Dim sScansOP As New BenefitLimit(session)
                sScansOP.Client = oClient
                sScansOP.Policy = oPolicy
                sScansOP.BenefitLimit = "MRI, CT and PET scans "
                sScansOP.Period = eBenefitPeriod.Annual
                sScansOP.AuthorisationType = eAuthorisationType.Diagnostics
                sScansOP.FullRefund = True
                sScansOP.PercentageToPay = 100
                sScansOP.Parent = sOutPatient
                sScansOP.Save()

            Catch ex As Exception
                Dim y = ex
            End Try
        End Sub
        Public Class ProjectCurrentUser
            '<ThreadStatic> Public Shared Oid As Integer
            Public Shared Oid As Integer
            Public Shared Function Login(ByVal session As UnitOfWork, ByVal flogin As String) As Boolean
                Return ProjectCurrentUser.Login(session, flogin, String.Empty)
            End Function
            Public Shared Function Login(ByVal session As UnitOfWork, ByVal flogin As String, ByVal password As String) As Boolean
                Dim wrapper As New Simple3Des("Willow")
                Dim _password As String = wrapper.EncryptData(password)

                'Dim user As User = session.FindObject(Of User)(CriteriaOperator.Parse("Login = ? ", UCase(flogin)))
                'If Debugger.IsAttached Then
                '    GlobalVariables.thisUser = session.FindObject(Of User)(CriteriaOperator.Parse("Login = ? and [Enabled] = True", UCase(flogin)))
                'Else
                GlobalVariables.thisUser = session.FindObject(Of User)(CriteriaOperator.Parse("Login = ? And Password = ? and [Enabled] = True", UCase(flogin), _password))

                '   End If

                If Object.Equals(GlobalVariables.thisUser, Nothing) Then
                    Return False
                End If
                Oid = GlobalVariables.thisUser.Oid
                If GlobalVariables.thisUser.TestEmail = False And GlobalVariables.SystemType = eSystemType.Live Then
                    GlobalVariables.thisUser.TestEmail = TestEmail()
                End If
                If Debugger.IsAttached = False Then

                    If GlobalVariables.Application = eApplication.Gus Then
                        GlobalVariables.thisUser.GusVersion = VersionNo()
                        GlobalVariables.thisUser.LastLogonGus = DateTime.Now
                        GlobalVariables.thisUser.LoggedOnGus = True
                    Else
                        GlobalVariables.thisUser.MaisieVersion = VersionNo()
                        GlobalVariables.thisUser.LastLogonMaisie = DateTime.Now
                        GlobalVariables.thisUser.LoggedOnMaisie = True
                    End If
                End If
                If Not Debugger.IsAttached Then
                    GlobalVariables.thisUser.Save()
                    session.CommitChanges()
                End If

                If Debugger.IsAttached Then
                    ConnectionHelper.CheckForInitialRecords(session)
                End If
                Return True
            End Function
            Public Shared Function TestEmail() As Boolean
                TestEmail = True
                If Environment.MachineName <> "JOHN-PC2" Then
                    Dim Smtp_Server As New SmtpClient
                    Dim e_mail As New MailMessage()
                    Smtp_Server.UseDefaultCredentials = True
                    Smtp_Server.EnableSsl = False
                    Smtp_Server.Host = GlobalVariables.SmtpServer
                    Smtp_Server.DeliveryMethod = SmtpDeliveryMethod.Network

                    e_mail = New MailMessage()
                    e_mail.From = New MailAddress(GlobalVariables.thisUser.Email)

                    e_mail.To.Add("Developers@allsurgical.co.uk")
                    e_mail.Subject = "First Login " + GlobalVariables.thisUser.FullName
                    e_mail.IsBodyHtml = False
                    e_mail.Body = "Successful Login for " + GlobalVariables.thisUser.FullName
                    Try
                        Smtp_Server.Send(e_mail)
                    Catch ex1 As Exception
                        MessageBox.Show(ex1.Message, "Error Sending Test Email From" + e_mail.From.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        TestEmail = False
                    End Try
                End If

            End Function

            Public Shared Function GetCurrentUser(ByVal session As Session) As User
                If Object.Equals(Oid, Guid.Empty) Then
                    Return Nothing
                Else
                    Return session.GetObjectByKey(Of User)(Oid)
                End If
            End Function
            Public Shared Function GetGlobalUser(ByVal session As Session) As GlobalUser
                If Object.Equals(Oid, Guid.Empty) Then
                    Return Nothing
                Else
                    Return session.GetObjectByKey(Of GlobalUser)(Oid)
                End If
            End Function
            Public Shared Sub SetGlobalUser(_oid As Integer)
                Oid = _oid
            End Sub
        End Class
        Public Class MemoryStreamValueConverter
            Inherits ValueConverter
            Public Overrides Function ConvertFromStorageType(ByVal val As Object) As Object
                Try
                    If TypeOf val Is Byte() Then
                        Dim stream As MemoryStream = New System.IO.MemoryStream(TryCast(val, Byte()))
                        Dim formatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                        Return formatter.Deserialize(stream)
                    End If
                Catch
                End Try
                Return Nothing
            End Function
            Public Overrides Function ConvertToStorageType(ByVal val As Object) As Object
                Try
                    If Object.Equals(val, Nothing) Then
                        Return Nothing
                    End If
                    Dim stream As New MemoryStream()
                    Dim formatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    formatter.Serialize(stream, val)
                    Return stream.GetBuffer()
                Catch
                End Try
                Return Nothing
            End Function
            Public Overrides ReadOnly Property StorageType() As Type
                Get
                    Return GetType(Byte())
                End Get
            End Property
        End Class
        Public Class RectangleValueConverter
            Inherits ValueConverter
            Public Overrides ReadOnly Property StorageType() As Type
                Get
                    Return GetType(String)
                End Get
            End Property
            Public Overrides Function ConvertToStorageType(ByVal val As Object) As Object
                If Not (TypeOf val Is Rectangle) Then
                    Return Nothing
                End If
                Dim rect As Rectangle = CType(val, Rectangle)
                Return String.Format("{0}@{1}@{2}@{3}", rect.X, rect.Y, rect.Width, rect.Height)
            End Function
            Public Overrides Function ConvertFromStorageType(ByVal val As Object) As Object
                Dim data() As String = String.Format("{0}", val).Split("@"c)
                If data.Length < 2 Then
                    Return Nothing
                End If
                Return New Rectangle(Convert.ToInt32(data(0)), Convert.ToInt32(data(1)), Convert.ToInt32(data(2)), Convert.ToInt32(data(3)))
            End Function
        End Class
        Public Class MD5StringEncoder
            Public Shared Function CalcHash(ByVal data As String) As String
                Dim ret As String = ""
                Try
                    Using mem As New MemoryStream()
                        Dim bWriter As New BinaryWriter(mem)
                        bWriter.Write(data)
                        mem.Position = 0
                        Dim md5 As System.Security.Cryptography.MD5 = New System.Security.Cryptography.MD5CryptoServiceProvider()
                        Dim res() As Byte = md5.ComputeHash(mem)
                        bWriter.Close()
                        For i As Integer = 0 To res.Length - 1
                            ret &= ChrW(res(i))
                        Next i
                    End Using
                Catch
                    ret = "N/A"
                End Try
                Return ret
            End Function
        End Class
    End Class

End Namespace

