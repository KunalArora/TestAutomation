using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using System.Collections.Generic;
using System.Globalization;

namespace Brother.Tests.Common.ContextData
{
    /// <summary>
    /// POCO to store strongly-typed data required during the lifetime of a test scenario
    /// </summary>
    public interface IContextData
    {
        Country Country { get; set; }
        string Culture { get; set; }
        CultureInfo CultureInfo { get; set; }
        RegionInfo RegionInfo { get; set; }
        string Language { get; set; }
        string BaseUrl { get; set; }
        string EnvironmentName { get; set; }
        string Environment { get; set; }
        string SpecificDealerUsername { get; set; }
        string SpecificDealerPassword { get; set; }
        string SpecificLocalOfficeApproverUsername { get; set; }
        string SpecificLocalOfficeApproverPassword { get; set; }
        BusinessType BusinessType { get; set; }
        DealerAccountType? DealerAccountType { get; set; }

        string DealerEmail { get; set; }
        
        string ProposalName { get; set; }
        int ProposalId { get; set; }
        string UsageType { get; set; }
        string ContractTerm { get; set; }
        string ContractType { get; set; }
        string LeadCodeReference { get; set; }
        string BillingType { get; set; }
        string ServicePackType { get; set; }
        IEnumerable<PrinterProperties> PrintersProperties { get; set; }
        string CustomerInformationName { get; set; }
        string CustomerEmail { get; set; }
        string CompanyLocation { get; set; }
        string InstallerEmail { get; set; }
        string CustomerPassword { get; set; }
        string SwapOldDeviceSerialNumber { get; set; }
        string SwapNewDeviceSerialNumber { get; set; }
        int SwapNewDeviceMonoPrintCount { get; set; }
        int SwapNewDeviceColourPrintCount { get; set; }
        string PaymentType { get; set; }
        bool SkipBOLRegistration { get; set; }

        string CommunicationMethod { get; set; }
        string InstallationType { get; set; }
        void SetBusinessType(string businessTypeId);
        string WebInstallUrl { get; set; }
        Dictionary<UserType, string> WindowHandles { get; set; }
        string CustomerFirstName { get; set; }
        string CustomerLastName { get; set; }
        string WebSwapInstallUrl { get; set; }
        string SwapType { get; set; }
        IEnumerable<SpecialPricingProperties> SpecialPriceList { get; set; }
        IList<string> RegisteredDeviceIds { get; set; }
        SnapDictionary SnapValues { get;  }
        string SubDealerEmail { get; set; }
        string SubDealerPassword { get; set; }
        string SubDealerFirstName { get; set; }
        string SubDealerLastName { get; set; }
        UserType DriverInstance { get; set; }
        IList<AdditionalChargesItem> AdditionalChargesItemList { get; set; }
        DealerProperties DealerProperties { get; set; }
        DealerDefaultMargins DealerAdminDefaultMargins { get; set; }
        DealerDefaultMargins DealerAdminDefaultMarginsOriginal { get; set; }

        // Exclusively Type 3
        string AgreementDateCreated { get; set; }
        string AgreementStartDate { get; set; }
        string AgreementEndDate { get; set; }
        string AgreementType { get; set; }
        int AgreementId { get; set; }
        string AgreementName { get; set; }
        string LeasingFinanceReference { get; set; }
        string DealerReference { get; set; }
        List<AdditionalDeviceProperties> AdditionalDeviceProperties { get; set; }
        int DeviceCount { get; set; }
        string DealerName { get; set; }
        string DealerSAPAccountNumber { get; set; }
        string LeasingBillingCycle { get; set; }
        int UsableDeviceIndex { get; set; } // DeviceIndex which can be used in serial number generation
        double ClickRateTotal { get; set; }
        double ServicePackTotal { get; set; }
        double InstallationPackTotal { get; set; }
        IEnumerable<PrinterEngineThresholdDetails> PrinterEngineThresholdDetails { get; set; }
        int AgreementShiftDays { get; set; }
        bool IsCustomerSelectedToProposal { get; set; }
    }
}
