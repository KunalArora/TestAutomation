using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;

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

        void SetBusinessType(string businessTypeId);
    }
}
