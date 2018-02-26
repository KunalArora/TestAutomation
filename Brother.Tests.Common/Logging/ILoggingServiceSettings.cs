namespace Brother.Tests.Common.Logging
{
    public interface ILoggingServiceSettings
    {
        string LoggingLevel { get; set; }
        string ScenarioName { get; set; }
    }
}
