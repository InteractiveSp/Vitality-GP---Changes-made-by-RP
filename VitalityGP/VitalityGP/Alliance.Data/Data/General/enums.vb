Imports System.ComponentModel
Imports System
Namespace Alliance.Data
    <Flags> _
      Public Enum eSystemType
        Development = 1
        Training = 2
        Live = 3
        '   Reporting = 4
        Converted = 5
        NewEmpty = 6
        Archive = 7
        NewClient = 8
        Test = 9
    End Enum

    Public Enum eAttributeType
        Hospital = 10
        Consultant = 20
    End Enum
    Public Enum PasswordKeys
        Willow = EntityType.User
        GUSBeneficary = EntityType.Beneficiary
        Consultant = EntityType.Consultant
        ConsultantStaff = EntityType.ConsultantStaff
    End Enum

    Public Enum Coords
        Latitude = 0
        Longitude = 1
    End Enum
    Public Enum Anesthetic
        None = 0
        General = 1
        Local = 2
        Regional = 3
    End Enum
    Public Enum eCallOut
        <Description("Referral")> Referral = 100
        <Description("Referral Named")> ReferralNamed = 110
        <Description("Referral Corrective")> ReferralCorrective = 120
        <Description("Referral Cosmetic")> ReferralCosmetic = 130
        <Description("Referral VHGP")> ReferralVHGP = 140
        <Description("Referral EMIS")> ReferralEMIS = 150
        <Description("Closing")> Closing = 500
        <Description("Closing Named/UnNamed")> ClosingNamedUnamed = 510
        <Description("Closing Corrective")> ClosingCorrective = 520
        <Description("Closing Cosmetic")> ClosingCosmetic = 530
        <Description("CreditCardAuthorise")> CreditCardAuthorise = 600
    End Enum
    Public Enum Diagnostic
        None = 0
        CT = 1
        MRI = 2
        XRAY = 3
        Ultrasound = 4
        PETScan = 5
        Other = 10
    End Enum
    Public Enum eBenefitDistribution
        Individual = 1
        Family = 2
    End Enum
    Public Enum MailFolder
        All = 0
        FollowUp = 1
        Info = 2
        Request = 4
        General = 8
        Invoicing = 16
        Deleted = 32
        Custom = 1024
    End Enum
    Public Enum eCommunicationType
        PhoneCall = 1
        Email = 2
        Letter = 3
    End Enum
    Public Enum eDocumentType
        File = 1
        Email = 2
        HTML = 3
    End Enum
    Public Enum MailType
        Inbox
        Deleted
        Sent
        Draft
    End Enum
    Public Enum eEditMode
        [ReadOnly] = 1
        [Edit] = 2
        [NoMenu] = 3
    End Enum

    Public Enum eMailTemplate
        Standard
        CITClaim
        ConsultantCV
    End Enum
    Public Enum eBeneficaryType
        NotSet = 0
        Employee = 1
        Dependant = 2
    End Enum
    Public Enum eClientType
        NotSet = 0
        Corp = 1
        RTH = 2
    End Enum
    Public Enum eClientlist
        AWG = 114
        TSG = 115
        RR = 116
        NWL = 117
    End Enum
    Public Enum ContactGender
        Male
        Female
    End Enum
    Public Enum DialogRole
        [New]
        Edit
    End Enum
    Public Enum eTaskLabel
        <Description("Comment")> Comment = 1
        <Description("Called")> Called = 2
        <Description("We Called")> WeCalled = 3
        <Description("Requires CallBack")> CallBack = 4
        <Description("Triage")> Triage = 5
        <Description("GP Letter")> GPLetter = 6
        <Description("CRM")> CRM = 10
        <Description("Reviewed")> Reviewed = 20
    End Enum
    Public Enum eTaskStatus
        <Description("Not Started")> NotStarted = 1
        <Description("In Progress")> InProgress = 2
        <Description("Deferred")> Deferred = 3
        <Description("Need Assistance")> WaitingOnSomeoneElse = 4
        <Description("Completed")> Completed = 5
    End Enum

    '' Action Item Types

    Public Enum eActionStatus
        Active = 10
        Cancelled = 20
        Complete = 30
    End Enum

    Public Enum eNextActionType
        <Description("Contact Patient")> ContactPatient = 50
        <Description("First Call")> FirstCall = 55
        <Description("Ring Patient")> RingPatient = 100
        <Description("Ring Secretary")> RingSecretary = 200
        <Description("Ring Hospital")> RingHospital = 300
        <Description("Wait Patient Call")> WaitPatientCall = 400
        <Description("Requires Triage")> Triage = 500
        <Description("Mapping")> Mapping = 600
        <Description("Requires Booking")> Book = 700
        <Description("Authorise Credit Card")> CreditCard = 800
        <Description("Cancel Booking")> CancelBooking = 900
        <Description("Cancel Provisional")> CancelProvisional = 910
        <Description("Fail Referral")> FailReferral = 920
    End Enum

    Public Enum eActionType
        <Description("EAP")> EAP = 100
    End Enum
    Public Enum eActionAuthorisationType
        <Description("TBC")> TBC = 200
    End Enum

    Public Enum FlagStatus
        Today
        Tomorrow
        ThisWeek
        NextWeek
        NoDate
        Custom
        Completed
    End Enum
    Public Enum eUserRole
        Administrator = 10
        CTAdmin = 110
        CT = 120
        FinanceAdmin = 210
        Finance = 220
        Membership = 300
        MembershipAdmin = 310
        ViewOnly = 510
        ExternalAdmin = 600
        ExternalViewer = 610
    End Enum
    Public Enum eFileType
        Text = 0
        Html = 1
        MHT = 2
    End Enum

    Public Enum eModuleAccess
        None = 10
        ViewOnly = 20
        Edit = 30
        Create = 40
        Delete = 50
    End Enum
    Public Enum eSalutation
        Mr
        Mrs
        Miss
        Ms
        Master
        Dr
    End Enum
    Public Enum eGender
        M
        F
    End Enum
    Public Enum eLevelOfCover
        Family = 1
        Married = 2
        [Single] = 3
        [SingleParent] = 4
        RTH = 10
    End Enum
    Public Enum eeXcessType
        None = 0
        eXcess = 10
        CostShare = 20
    End Enum
    Public Enum eHospitalList
        <Description("Local")> Local
        <Description("Country Wide")> CountryWide
        <Description("CountryWide Plus")> CountryWidePlus
        <Description("Premier Plus")> PremierPlus

    End Enum
    Public Enum cdCardType
        <Description("VISA")> VISA
        <Description("VISA Corporate")> VISACorporate
        <Description("VISA Debit")> VISADebit
        <Description("VISA Electron")> VISAElectron
        '<Description("MasterCard")> MasterCard
        '<Description("Debit MasterCard")> DebitMasterCard
        '<Description("Maestro (UK Issued)")> MaestroUKIssued
        '<Description("Maestro (German Issued)")> MaestroGermanIssued
        '<Description("Maestro (Irish Issued)")> MaestroIrishIssued
        '<Description("Maestro (Spanish Issued)")> MaestroSpanishIssued
        '<Description("American Express")> AmericanExpress
        '<Description("Diners Club/Discover")> DinersClubDiscover
        '<Description("JCB")> JCB
        '<Description("PayPal")> PayPal
    End Enum
    Public Enum ConsultantCVFields
        ClinicalInterests
        CVAdditionalNotes
        CVFile
        CVGeneral
        MedicoLegal
        PositionsHeld
        PrimarySpeciality
        ProfessionalQualifications
        Qualifications
        ResearchInterests
        SecondarySpeciality
        YearQualified
    End Enum
    Public Enum cdCardResults
        <Description("Ok")> Ok
        <Description("Declined By Bank")> DeclinedByBank
        <Description("Patient Declined")> PatientDeclined
    End Enum

    Public Enum eRelationship
        NotSet = 0
        Spouse = 4
        MarriedChild = 8
        UnmarriedChild = 10
        Employee = 11
        Child = 12
        Partner = 100
        Husband = 101
        Wife = 102
        Son = 103
        Daughter = 104
        AdultRelation = 105
        ChildRelation = 106
    End Enum
    Public Enum eReasonLeft
        <Description("Left Company")> LeftCompany = 1
        <Description("Deceased")> Deceased = 2
        <Description("Exceeded Student Age")> ExStudent = 3
        <Description("Non Payment")> NonPayment = 4
        <Description("Did Not Start")> DidNotStart = 5
        <Description("SetUp in Error")> SetUpInError = 10
        <Description("Benefciary Cancelled MBship")> Cancelled = 11
    End Enum
    Public Enum eAlertType
        '<Description("New Beneficiary")> NewBeneficary = 10
        '<Description("New Claim")> NewClaim = 20
        '<Description("New Authorisation")> NewAuthorisation = 30
        '<Description("High Cost Authorisation")> HighCostAuthorisation = 40
        '<Description("Beneficary Left")> BeneficaryLeft = 50
        '<Description("Beneficary ReJoined")> BeneficaryReJoined = 60
        NewBeneficary = 10
        NewRTH = 11
        NewClaim = 20
        NewAuthorisation = 30
        HighCostAuthorisation = 40
        BeneficaryLeft = 50
        BeneficaryReJoined = 60
        NewConsultant = 70
        NewFacility = 80
    End Enum
    'Public Enum EmployeeTaskStatus
    '    <Description("Not Started")> NotStarted = 0
    '    <Description("Completed")> Completed
    '    <Description("In Progress")> InProgress
    '    <Description("Need Assistance")> NeedAssistance
    '    <Description("Deferred")> Deferred
    'End Enum
    Public Enum EmployeeTaskPriority
        Low
        Normal
        High
        Urgent
    End Enum
    Public Enum ImportType
        CCSD
        Employee
        Dependant
    End Enum
    Public Enum EntityType
        AdmissionStatus = 10
        AffectedSystem = 11
        Condition = 12
        LevelofCover = 20
        RelationShip = 21
        Benefit = 20
        SubBenefit = 21
        BenefitDetail = 22
        IncurredCategory = 23
        Client = 100
        ClientStaff = 101 ' Seed Value 7000000
        Division = 110
        ReportingDivision = 111
        BusinessUnit = 111
        BenefitLimit = 120
        Beneficiary = 150
        Address = 160
        Claim = 200
        Authorisation = 210
        Invoice = 220
        InvoiceLine = 221
        Treatment = 250
        TreatmentAttribute = 251
        SpecialPrice = 252
        AnalysisCode = 260
        Practice = 300
        GP = 301
        Provider = 310
        Hospital = 320 ' Seed Value 2000000
        Consultant = 330 ' Seed Value 3000000
        ConsultantHospital = 340
        ConsultantStaff = 350 ' Seed 4000000
        User = 500
        Comment = 501
        RecentItem = 502
        Task = 503
        Patient = 600 ' Seed Value 8000000
        Referral = 610 ' Seed Value 1000000
        Insurer = 620
        VitalityGP = 630 ' Seed Value 7500000
    End Enum
    Public Enum eProviderType
        NotSet = 0
        Hospital = 1
        Consultant = 2
        Anaesthetist = 3
        AlternativeMedicine = 4
        Other = 5
        ConsultingRoom = 6
        '   Physio = 7
        MedicalCenter = 8
        Clinic = 9
        MRICenter = 10
    End Enum
    Public Enum eInvoiceType
        Invoice = 1
        Credit = 2
    End Enum
    Public Enum eInvoiceSource
        NotSet = 0
        Manual = 1
        CRM = 2
        RehabWorks = 3
        CorpDirect = 4
        Actisure = 5
        CIT = 6
        All = 9
    End Enum
    Public Enum eInvoiceStatus
        NotSet = 0
        WaitingApproval = 1
        Held = 2
        Authorised = 3
        Disputed = 4
        Posted = 5
        QA = 6
        Declined = 7
        Transfer = 9
        Paid = 10
        PaidToZero = 11
        PaidToZeroXs = 12
        ExGratia = 13
    End Enum
    Public Enum eClaimStatus
        NotSet = 0
        Pended = 1
        Declined = 2
        Active = 3
        Closed = 4
        Web = 5
        ClaimFormRequired = 6
        Waiting = 7
        Diverted = 8
        RequiresEAP = 9
    End Enum
    Public Enum eAdmissionStatus
        NotSet = 0
        NA = 1
        DayCase = 2
        InPatient = 3
        OutPatient = 4
        Mixed = 5
    End Enum
    Public Enum eAccommodationType
        Day = 1
        IC1 = 2
        IC2 = 3
    End Enum
    Public Enum eClaimSource As Integer
        NotSet = 0
        Phone = 10
        Web = 20
    End Enum
    Public Enum eAuthorisationSource As Integer
        NotSet = 0
        CT = 10
        Finance = 20
        CRM = 30
        Actisure = 40
        WebClaim = 50
        Import = 99
    End Enum
    Public Enum eAuthorisationType
        NotSet = 0
        Consultation = 10
        Treatment = 20
        Diagnostics = 30
        Therapist = 40
        Physio = 50
        Complementary = 60
        NHSCashBenefit = 70
        Hospice = 80
        CITConsultation = 90
    End Enum
    Public Enum eBudgetSource
        System = 0
        Treatment = 10
        HospitalTreatment = 20
        Package = 25
        ConsultantTreatment = 30
        InsurerTreatment = 40
        HospitalMaxima = 50
        HospitalAccomodation = 60
    End Enum
    Public Enum eCITType
        Breast = 10
        Cardiology = 20
        Gastroenterology = 30
        MentalHealth = 35
        MSKGeneral = 40
        MSKHip = 50
        MSKKnee = 60
    End Enum
    Public Enum eCITStage
        Response = 1
        Reply = 2
        Completed = 10
        Invoiced = 20
    End Enum
    Public Enum eCITOutCome
        NoResponse = 10
        Consultation = 20
        NHS = 30
    End Enum
    Public Enum eAuthorisationStatus As Integer
        NotSet = 0
        Pended = 1
        Declined = 2
        Active = 3
        Closed = 4
    End Enum
    Public Enum ePaymentStatus As Integer
        NotSet = 0
        Pended = 10
        Declined = 20
        Authorised = 30
        WaitingClearance = 35
        InPart = 40
        Paid = 50
    End Enum
    Public Enum eDatevalue
        FirstDayLastMonth
        FirstDayThisMonth
        FirstOfDayWeek
        FirstDayNextMonth
        LastDayLastMonth
        LastDayThisMonth
        LastDayNextMonth
    End Enum
    Public Enum ePeriod
        All = 0
        ToDay = 1
        Thisweek = 2
        ThisMonth = 3
        ThisQtr = 4
        ThisYear = 5
        LastWeek = 6
        LastMonth = 7
        LastQtr = 8
        LastYear = 9
        YearToDate = 10
    End Enum
    Public Enum eBenefitPeriod
        Annual = 1
        Daily = 2
        Weekly = 3
        Monthly = 4
        Quarterly = 5
        Lifetime = 6
        Policy = 7
        Claim = 8
        Authorisation = 9
        BiAnnual = 10
    End Enum
    Public Enum ePrintRequestType
        ClaimForm = 10
    End Enum
    Public Enum eReferralSource
        Unknown = 0
        Vitality = 1
        Advertisement = 690
        ASONE = 15590
        CORPORATE = 15414
        DOCMAN = 15631
        DRCARE = 15733
        DUP = 14930
        Email = 376
        EMIS = 14929
        Employee = 708
        Fax = 375
        GP = 12686
        HC = 9945
        Import = 688
        IPRS = 15642
        Letter = 689
        MLQ = 14979
        Referral = 373
        SMS = 9946
        SystmOne = 15426
        Telephone = 374
        TERT = 14927
        Trade_Press = 691
        Tradeshow = 687
        Vision = 15425
        VitalityGP = 15774
        VitalityGPSel = 15775
        Web = 372
    End Enum
    Public Enum eReferralStatus
        NotSet = 0
        Pended = 1
        InProgress = 2
        Closed = 3
    End Enum
    Public Enum eReferralStage
        <Description("Received")> Received = 8723
        <Description("Mapped")> Mapped = 8724
        <Description("Booked")> Booked = 8725
        <Description("Notified")> Notified = 8726
        <Description("PCA Completion")> PCA = 8727
        <Description("Treatment")> Treatment = 8728
        <Description("Payment")> Payment = 8729
        <Description("10 Min Call")> CallComp10 = 9956
        <Description("Closed ")> Closed = 9994
        <Description("Discharged")> Discharged = 12627
        <Description("Triage")> Triage = 10000
    End Enum
    Public Enum eTreatmentType
        NotSet = 0
        Consultation = 10
        FollowUp = 20
        Treatment = 30
        Diagnostics = 40
    End Enum
    Public Enum eFurtherTreatmentStatus As Integer
        NotSet = 0
        Active = 1
        Invoiced = 2
    End Enum
    Public Enum eFurtherTreatmentSource As Integer
        Other = 0
        Audit = 1
        DecemberAudit = 2
        Email = 3
        FebAudit = 4
        Fax = 5
        Insurer = 6
        Invoice = 7
        PhoneConsultant = 8
        PhoneHospital = 9
        PhoneOther = 10
        PhonePatient = 11
        PhoneSecretary = 12
        TAF = 13
    End Enum
End Namespace