using Brother.Tests.Specs.Domain;

namespace Brother.Tests.Specs.ContextData
{
    public class MpsContextData : IContextData
    {
        public Country Country { get; set; }
        public string Culture { get; set; }
        public string BaseUrl { get; set; }
        public string Environment { get; set; }
        public string EnvironmentName { get; set; }
    }
}
