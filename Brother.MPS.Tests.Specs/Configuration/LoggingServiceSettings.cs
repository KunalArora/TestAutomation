using Brother.Tests.Common.Logging;

namespace Brother.Tests.Specs.Configuration
{
    public class LoggingServiceSettings : ILoggingServiceSettings
    {
        public string ScenarioName { get; set; }
        public string LoggingLevel { get; set; }
        public string LoggingStreamType { get; set; }
    }
}
