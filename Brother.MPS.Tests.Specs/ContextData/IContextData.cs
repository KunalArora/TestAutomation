using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using System.Collections;
using System.Collections.Generic;

namespace Brother.Tests.Specs.ContextData
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
        string BillingType { get; set; }
        string ServicePackType { get; set; }
        IEnumerable<PrinterProperties> PrinterProperties { get; set; }

        void SetBusinessType(string businessTypeId);  
    }
}
