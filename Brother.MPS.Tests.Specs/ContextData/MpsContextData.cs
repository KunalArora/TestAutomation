using Brother.Tests.Specs.Domain.Enums;
using System;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using System.Collections.Generic;

namespace Brother.Tests.Specs.ContextData
{
    public class MpsContextData : IContextData
    {
        public Country Country { get; set; }
        public string Culture { get; set; }
        public string BaseUrl { get; set; }
        public string Environment { get; set; }
        public string EnvironmentName { get; set; }
        public BusinessType BusinessType { get; set; }

        public string ProposalName { get; set; }
        public int ProposalId { get; set; }
        public string UsageType { get; set; }
        public string ContractTerm { get; set; }
        public string BillingType { get; set; }
        public string ServicePackType { get; set; }
        public string CompanyLocation { get; set; }
        public string InstallerEmail { get; set; }
        public string SwapDeviceSerialNumber { get; set; }


        public void SetBusinessType(string businessTypeId){

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
        public string WebInstallUrl { get; set; }

    }
}
