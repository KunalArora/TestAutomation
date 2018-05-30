using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Brother.Tests.Common.ContextData
{
    public class MpsContextData : IContextData
    {
        public Country Country { get; set; }
        public string Culture { get; set; }
        public CultureInfo CultureInfo { get; set; }
        public RegionInfo RegionInfo { get; set; }
        public string Language { get; set; }
        public string BaseUrl { get; set; }
        public string Environment { get; set; }
        public string EnvironmentName { get; set; }
        public BusinessType BusinessType { get; set; }
        public string SpecificDealerUsername { get; set; }
        public string SpecificDealerPassword { get; set; }
        public string SpecificLocalOfficeApproverUsername { get; set; }
        public string SpecificLocalOfficeApproverPassword { get; set; }

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
        public string PaymentType { get; set; }
        public bool SkipBOLRegistration { get; set; }

        public string CommunicationMethod { get; set; }
        public string InstallationType { get; set; }


        public MpsContextData()
        {
            WindowHandles = new Dictionary<UserType, string>();
            CustomerPassword = "password";
            SubDealerPassword = "password";
            CreatedDealerPassword = "password";
            RegisteredDeviceIds = new List<string>();
            //SnapClickPricePageValues = new Dictionary<string,string>();
            //SnapCreateProductsPageValues = new Dictionary<string, string>();
            SnapValues = new SnapDictionary();
            SkipBOLRegistration = false;
            AdditionalChargesItemList = new List<AdditionalChargesItem>();
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
        public IList<string> RegisteredDeviceIds { get; set; }
        public string LeasingBillingCycle { get; set; }
        public SnapDictionary SnapValues { get; private set; }
        public string SubDealerEmail { get; set; }
        public string SubDealerPassword { get; set; }
        public string SubDealerFirstName { get; set; }
        public string SubDealerLastName { get; set; }
        public UserType DriverInstance { get; set; }
        public IList<AdditionalChargesItem> AdditionalChargesItemList { get; set; }
        public string CreatedDealerEmail { get; set; }
        public string CreatedDealerPassword { get; set; }
        public string CreatedDealerFirstName { get; set; }
        public string CreatedDealerLastName { get; set; }

        // Exclusively Type 3
        public string AgreementDateCreated { get; set; }
        public string AgreementStartDate { get; set; }
        public string AgreementEndDate { get; set; }
        public string AgreementType { get; set; }
        public int AgreementId { get; set; }
        public string AgreementName { get; set; }
        public string LeasingFinanceReference { get; set; }
        public string DealerReference { get; set; }
        public List<AdditionalDeviceProperties> AdditionalDeviceProperties { get; set; }
        public int DeviceCount { get; set; }
        public string DealerName { get; set; }
        public string DealerSAPAccountNumber { get; set; }
        public int UsableDeviceIndex { get; set; }
        public double ClickRateTotal { get; set; }
        public double ServicePackTotal { get; set; }
        public double InstallationPackTotal { get; set; }

        public IEnumerable<PrinterEngineThresholdDetails> PrinterEngineThresholdDetails { get; set; }
    }

    public class SnapDictionary : Dictionary<string, Dictionary<string, string>>
    {
        public Dictionary<string, string> this[Type pageClass] {
            get {
                if(base.ContainsKey(pageClass.FullName) == false)
                {
                    base.Add(pageClass.FullName, new Dictionary<string, string>() );
                }
                return  base[pageClass.FullName]  ;
            }
            set { base[pageClass.FullName] = value; }
        }
    }

    public class AdditionalChargesItem
    {

        public int chargeTypeValue { get; set; } // (int)ChargeTypeSelectorElementValue
        public double costPrice { get; set; }
        public double marginPercent { get; set; }
    }

    // use for LocalOfficeAdminContractsAdditionalCharges#ChargeTypeSelectorElement

}
