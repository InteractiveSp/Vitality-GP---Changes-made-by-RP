Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports DevExpress.Utils

Namespace Alliance.Data
    Public Class ConstDataStrings

        Public Const UnableOpenDb As String = "Unable to open the database. A new database will be created."
        Public Const UnableCreateDb As String = "Unable to create a database. Please check the connection settings."
        Public Const ObjectCanNotBeDeleted As String = "This object cannot be deleted."
        Public Const NotAllItemsCanBeDeleted As String = "Some of items cannot be deleted. Do you want to continue?"


        'Public Const DatabaseCreating As String = "To run the application, a sample database needs to be created and populated with data." & Constants.vbCrLf & "Please select the database type and connection options below."
        'Public Const CustomerDetailTooltip As String = "Double click here to show the current customer details"
        'Public Const CurrentClaim As String = "Current customer: {0}"
        'Public Const CurrentAuthorisation As String = "Current customer: {0}"
        'Public Const CurrentBeneficiary As String = "Current customer: {0}"

        Public Const [Nothing] As String = "nothing"

        Public Const Client As String = "Customer"
        Public Const ReturnToHealth As String = "RTH"
        Public Const Beneficiary As String = "Beneficiary"
        Public Const Claim As String = "Claim"
        Public Const Company As String = "Company"
        Public Const Consultant As String = "Consultant"
        Public Const Hospital As String = "Hospital"
        Public Const Provider As String = "Provider"
        Public Const Authorisation As String = "Authorisation"
        Public Const GP As String = "GP"
        Public Const Practice As String = "Practice"
        Public Const Receipt As String = "Receipt"
        Public Const Referral As String = "Referral"
        Public Const Treatment As String = "Treatment"
        Public Const Task As String = "Task"
        Public Const Invoice As String = "Invoice"

        Public Const Clients As String = "Customers"
        Public Const Claims As String = "Claims"
        Public Const Authorisations As String = "Authorisation"
        Public Const Companies As String = "Companies"
        Public Const Consultants As String = "Consultants "
        Public Const Facilities As String = "Facilities"
        Public Const Treatments As String = "Treatments"
        Public Const GPPracticeModule As String = "Practices"
        Public Const Tasks As String = "Tasks"
        Public Const TaskSchedule As String = "Schedule"
        Public Const Invoices As String = "Invoices"
        Public Const ImportantActions As String = "Review"

        Public Const Photo As String = "photo"
        Public Const Screens As String = "Photo Gallery"
        Public Const NullString As String = "(null)"
        Public Const TimePeriod As String = "Time Period ({0:d} - {1:d})"
        Public Const ComparePeriod As String = "Period Comparison ({0:d} - {1:d})"
        Public Const Total As String = "Total"
        Public Const SubclassError As String = "Class has to be inherited from Form"
        Public Const PublicConstructorError As String = "{0} doesn't have public constructor with empty parameters"
        Public Const LookupDetails As String = "Lookup details..."
        Public Const DatePeriodCaption As String = "From {0:d} to {1:d}"
        Public Const ViewOptions As String = "List View Options"
        Public Const ShowReportDesigner As String = "Show Report Designer"
        Public Const AllFormats As String = "All Formats"

        Public Const VIPBackGroundHex As String = "#FCF1A5"
        Public Const VIPColourHex As String = "#FF4040"
        Public Const RTWColourHex As String = "#78C485"
        Public Const RTWBackGroundHex As String = "#9DB68C"
        Public Const DeceasedBackGroundHex As String = "#CFCFC4"
        Public Const DeceasedColorHex As String = "#DC143C"
        Public Const LeftBackGroundHex As String = "#CFCFC4"
        Public Const LeftColorHex As String = "#000000"

        Public Const WordList As String = "randomwords.txt"
    End Class

End Namespace
