namespace Brother.Tests.Common.Logging
{
    public interface ILoggingServiceSettings : ICommandLineSettings
    {
        string ScenarioName { get; set; }
    }
}
