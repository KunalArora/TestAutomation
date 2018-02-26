using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using System;
using System.Collections.Generic;

namespace Brother.Tests.Common.ContextData
{
    public class MpsContextData : IContextData
    {
        public Country Country { get; set; }
        public string Culture { get; set; }
        public string BaseUrl { get; set; }
        public string Environment { get; set; }
        public string EnvironmentName { get; set; }
        public BusinessType BusinessType { get; set; }
        public string SpecificDealerUsername { get; set; }
        public string SpecificDealerPassword { get; set; }

        public string ProposalName { get; set; }
        public int ProposalId { get; set; }
        public string UsageType { get; set; }
        public string LeadCodeReference { get; set; }
        public string ContractType { get; set; }
        public string ContractTerm { get; set; }
        public string BillingType { get; set; }
        public string ServicePackType { get; set; }
        public string CompanyLocation { get; set; }
        public string InstallerEmail { get; set; }
        public string SwapOldDeviceSerialNumber { get; set; }
        public string SwapNewDeviceSerialNumber { get; set; }
        public int SwapNewDeviceMonoPrintCount { get; set; }
        public int SwapNewDeviceColourPrintCount { get; set; }

        public string CommunicationMethod { get; set; }
        public string InstallationType { get; set; }

        public MpsContextData()
        {
            WindowHandles = new Dictionary<UserType, string>();
            CustomerPassword = "password";
        }

        public void SetBusinessType(string businessTypeId)
        {

            int businessType;

            if (!int.TryParse(businessTypeId, out businessType))
            {
                throw new Exception("Supplied business type id (" + businessTypeId + ") must be a number");
            }

            var enumName = Enum.GetName(typeof(BusinessType), businessType);
            if (enumName == null)
            {
                throw new Exception("Business type for value " + businessTypeId + " does not exist");
            }

            BusinessType = (BusinessType)Enum.Parse(typeof(BusinessType), enumName);
        }

        public IEnumerable<PrinterProperties> PrintersProperties { get; set; }
        public string CustomerInformationName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPassword { get; set; }
        public string WebInstallUrl { get; set; }
        public Dictionary<UserType, string> WindowHandles { get; set; }
        public string WebSwapInstallUrl { get; set; }
        public IEnumerable<SpecialPricingProperties> SpecialPriceList { get; set; }
        public string SwapType { get; set; }

        // Exclusively Type 3
        public string AgreementType { get; set; }
        public int AgreementId { get; set; }
        public string AgreementName { get; set; }
        public string LeasingFinanceReference { get; set; }
        public string DealerReference { get; set; }
        public List<AdditionalDeviceProperties> AdditionalDeviceProperties { get; set; }
        public int DeviceCount { get; set; }
        public string DealerName { get; set; }
        public string DealerSAPAccountNumber { get; set; }
    }
}
