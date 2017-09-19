using Brother.Tests.Specs.Domain;

namespace Brother.Tests.Specs.ContextData
{
    public interface IContextData
    {
        Country Country { get; set; }
        string Culture { get; set; }
        string BaseUrl { get; set; }
        string EnvironmentName { get; set; }
        string Environment { get; set; }
    }
}
