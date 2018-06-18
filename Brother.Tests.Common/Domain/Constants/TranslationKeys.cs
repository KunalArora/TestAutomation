namespace Brother.Tests.Common.Domain.Constants
{
    public static class TranslationKeys
    {
        public static class ContractType
        {
            public static string LeaseAndClick { get { return "LEASE_AND_CLICK"; } }
            public static string LeasingAndService { get { return "LEASING_AND_SERVICE"; } }
            public static string PurchaseAndClick { get { return "PURCHASE_AND_CLICK"; } }
            public static string EasyPrintProAndService { get { return "EASY_PRINT_PRO_AND_SERVICE"; } }
        }

        public static class AgreementType
        {
            public static string CppAgreement { get { return "CPP_AGREEMENT"; } }
        }

        public static class UsageType
        {
            public static string MinimumVolume { get { return "MINIMUM_VOLUME"; } }
            public static string PayAsYouGo { get { return "PAY_AS_YOU_GO"; } }
        }

        public static class ContractTerm
        {
            public static string OneYear { get { return "ONE_YEAR"; } }
            public static string TwoYears { get { return "TWO_YEARS"; } }
            public static string ThreeYears { get { return "THREE_YEARS"; } }
            public static string FourYears { get { return "FOUR_YEARS"; } }
            public static string FiveYears { get { return "FIVE_YEARS"; } }
        }

        public static class BillingType
        {
            public static string HalfYearlyInArrears { get { return "HALF_YEARLY_IN_ARREARS"; } }
            public static string Monthly { get { return "MONTHLY"; } }
            public static string MonthlyInAdvance { get { return "MONTHLY_IN_ADVANCE"; } }
            public static string PolandSixMonthly { get { return "POLAND_SIX_MONTHLY"; } }
            public static string QuarterlyInAdvance { get { return "QUARTERLY_IN_ADVANCE"; } }
            public static string QuarterlyInArrears { get { return "QUARTERLY_IN_ARREARS"; } }
            public static string TestMin { get { return "TEST_MIN"; } }
        }

        public static class ServicePackType
        {
            public static string PayUpfront { get { return "PAY_UPFRONT"; } }
            public static string IncludedInClickPrice { get { return "INCLUDED_IN_CLICK_PRICE"; } }
            public static string AddToTheLeasingRate { get { return "ADD_TO_THE_LEASING_RATE"; } }
        }

        public static class InstallationPack
        {
            public static string BrotherInstallation { get { return "BROTHER_INSTALLATION"; } }
            public static string DealerInstallationType1 { get { return "DEALER_INSTALLATION_TYPE1"; } }
        }

        public static class PaymentType
        {
            public static string Invoice { get { return "INVOICE"; } }
            public static string DirectDebit { get { return "DIRECT_DEBIT"; } }
        }

        public static class InstallationStatus
        {
            public static string NotStarted {  get { return "NOT_STARTED"; } }
            public static string Completed { get { return "COMPLETED"; } }
        }

        public static class InstalledPrinterStatus
        {
            public static string BeingReplaced { get { return "BEING_REPLACED"; } }
            public static string AwaitingCommissioning { get { return "AWAITING_COMMISSIONING"; } }
            public static string AddressRequiredType3 { get { return "ADDRESS_REQUIRED_TYPE3"; } }
            public static string ReadyForInstallType3 { get { return "READY_FOR_INSTALL_TYPE3"; } }
            public static string InstalledType3 { get { return "INSTALLED_TYPE3"; } }
            public static string Replaced { get { return "REPLACED"; } }
            public static string ReadyForReInstallType3 { get { return "READY_FOR_RE_INSTALL_TYPE3"; } }
        }

        public static class ProposalDeclineReason
        {
            public static string Expired { get { return "EXPIRED"; } }
            public static string Other { get { return "OTHER"; } }
        }

        public static class ContractRejectReason
        {
            public static string Expired { get { return "EXPIRED"; } }
            public static string Other { get { return "OTHER"; } }
        }

        public static class SwapType
        {
            public static string ReplaceThePcb { get { return "REPLACE_THE_PCB"; } }
            public static string ReplaceWithDifferentModel { get { return "REPLACE_WITH_DIFFERENT_MODEL"; } }
            public static string ReplaceWithSameModel { get { return "REPLACE_WITH_SAME_MODEL"; } }
        }

        public static class PdfTranslations
        {
            public static string AgreementPeriod { get { return "AGREEMENT_PERIOD"; } }
            public static string TotalInstalledPurchasePrice { get { return "TOTAL_INSTALLED_PURCHASE_PRICE"; } }
            public static string MinimumClickCharge { get { return "MINIMUM_CLICK_CHARGE"; } }
            public static string PagePriceBlackWhitePrint { get {return "PAGE_PRICE_BLACK_WHITE_PRINT"; }}
            public static string PagePriceColorPrint { get { return "PAGE_PRICE_COLOR_PRINT"; } }
            public static string MinimumVolumePerQuarter { get { return "MINIMUM_VOLUME_PER_QUARTER"; } }
        }

        public static class DeviceConnectionStatus
        {
            public static string NotConnected { get { return "NOT_CONNECTED"; } }
            public static string Responding { get { return "RESPONDING"; } }
            public static string Swapped { get { return "SWAPPED"; } }
            public static string Silent { get { return "SILENT"; } }
        }

        // for type string on hover message
        public static class CommunicationMethod
        {
            public static string Cloud { get { return "CLOUD"; } }
            public static string Web { get { return "WEB"; } }
        }

        public static class ConsumableOrderStatus
        {
            public static string InProgress { get { return "IN_PROGRESS"; } }
            public static string InProcessing { get { return "IN_PROCESSING"; } }
        }

        public static class ServiceRequestStatus
        {
            public static string New { get { return "NEW"; } }
            public static string Closed { get { return "CLOSED"; } }
        }

        public static class OverusageText
        {
            public static string ColourText { get { return "COLOUR_TEXT"; } }
            public static string MonoText { get { return "MONO_TEXT"; } }
        }

        public static class DisplayMessage
        {
            public static string EmailSendSuccess { get { return "EMAIL_SEND_SUCCESS"; } }
            public static string ContractNotYetSet { get { return "CONTRACT_NOT_YET_SET"; } }
            public static string EmailSendFailure { get { return "EMAIL_SEND_FAILURE"; } }
            public static string AreYouSureUnmatch { get { return "ARE_YOU_SURE_UNMATCH"; } }
        }

        public static class OrderedConsumable
        {
            public static string BlackToner { get { return "BLACK_TONER"; } }
            public static string CyanToner { get { return "CYAN_TONER"; } }
            public static string MagentaToner { get { return "MAGENTA_TONER"; } }
            public static string YellowToner { get { return "YELLOW_TONER"; } }
        }

        public static class AgreementStatus
        {
            public static string Draft { get { return "DRAFT"; } }
            public static string PreInstall { get { return "PRE_INSTALL"; } }
            public static string Running { get { return "RUNNING"; } }
        }

        public static class StaffAccessPermission
        {
            public static string Restricted { get { return "RESTRICTED"; } }
            public static string ContractManager { get { return "CONTRACT_MANAGER"; } }
            public static string Full { get { return "FULL"; } }
        }

        public static class ConsumableOrderMethod
        {
            public static string Manual { get { return "MANUAL"; } }
            public static string Automatic { get { return "AUTOMATIC"; } }
        }

        public static class DealerCulture
        {
            public static string English { get { return "ENGLISH"; } }
            public static string French { get { return "FRENCH"; } }
        }

        public static class CsvTranslations
        {
            public static string SerialNumber { get { return "SERIAL_NUMBER"; } }
        }
    }
}
