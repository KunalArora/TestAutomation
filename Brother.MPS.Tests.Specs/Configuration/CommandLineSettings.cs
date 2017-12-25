using Brother.Tests.Common.Logging;

namespace Brother.Tests.Specs.Configuration
{
    public class CommandLineSettings : ICommandLineSettings
    {
        public string OutputPath { get; set; }
        public string LoggingLevel { get; set; }
        public string EnvironmentUnderTest { get; set; }
        public string ScenarioName { get; set; }
        
    }
}
