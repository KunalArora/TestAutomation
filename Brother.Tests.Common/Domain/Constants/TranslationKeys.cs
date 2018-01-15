namespace Brother.Tests.Common.Domain.Constants
{
    public static class TranslationKeys
    {
        public static class ContractType
        {
            public static string LeaseAndClick { get { return "LEASE_AND_CLICK"; } }
            public static string PurchaseAndClick { get { return "PURCHASE_AND_CLICK"; } }
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
            public static string HalfYearly { get { return "HALF_YEARLY"; } }
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
        }

        public static class InstalledPrinterStatus
        {
            public static string BeingReplaced { get { return "BEING_REPLACED"; } }
            public static string AwaitingCommissioning { get { return "AWAITING_COMMISSIONING"; } }
            public static string AddressRequiredType3 { get { return "ADDRESS_REQUIRED_TYPE3"; } }
            public static string ReadyForInstallType3 { get { return "READY_FOR_INSTALL_TYPE3"; } }
            public static string InstalledType3 { get { return "INSTALLED_TYPE3"; } }   
        }

        public static class ProposalDeclineReason
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

        public static class ProposalPdf
        {
            public static string AgreementPeriod { get { return "AGREEMENT_PERIOD"; } }
            public static string TotalInstalledPurchasePrice { get { return "TOTAL_INSTALLED_PURCHASE_PRICE"; } }
            public static string MinimumClickCharge { get { return "MINIMUM_CLICK_CHARGE"; } }

        }

        public static class DeviceConnectionStatus
        {
            public static string NotConnected { get { return "NOT_CONNECTED"; } }
            public static string Responding { get { return "RESPONDING"; } }
        }

    }
}
