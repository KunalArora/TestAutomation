using Brother.Tests.Common.Logging;

namespace Brother.Tests.Specs.Configuration
{
    public class LoggingServiceSettings : CommandLineSettings, ILoggingServiceSettings
    {
        public string ScenarioName { get; set; }
    }
    public class CommandLineSettings : ICommandLineSettings
    {
        public string OutputPath { get; set; }
        public string LoggingLevel { get; set; }
        public string EnvironmentUnderTest { get; set; }
        
    }
}
