using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using System.Collections.Generic;

namespace Brother.Tests.Common.ContextData
{
    /// <summary>
    /// POCO to store strongly-typed data required during the lifetime of a test scenario
    /// </summary>
    public interface IContextData
    {
        Country Country { get; set; }
        string Culture { get; set; }
        string BaseUrl { get; set; }
        string EnvironmentName { get; set; }
        string Environment { get; set; }
        BusinessType BusinessType { get; set; }

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
        int SwapNewDeviceMonoPrintCount { get; set; }
        int SwapNewDeviceColourPrintCount { get; set; }
        
        void SetBusinessType(string businessTypeId);
        string WebInstallUrl { get; set; }
        Dictionary<UserType, string> WindowHandles { get; set; }
        string CustomerFirstName { get; set; }
        string CustomerLastName { get; set; }
        string WebSwapInstallUrl { get; set; }
        string SwapType { get; set; }
        IEnumerable<SpecialPricingProperties> SpecialPriceList { get; set; }
 
        // Exclusively Type 3
        string AgreementType { get; set; }
        int AgreementId { get; set; }
        string AgreementName { get; set; }
        string LeasingFinanceReference { get; set; }
        string DealerReference { get; set; }
        List<AdditionalDeviceProperties> AdditionalDeviceProperties { get; set; }
        int DeviceCount { get; set; }
    }
}
