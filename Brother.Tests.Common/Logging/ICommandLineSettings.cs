namespace Brother.Tests.Common.Logging
{
    public interface ICommandLineSettings
    {
        string OutputPath { get; set; }
        string LoggingLevel { get; set; }
        string EnvironmentUnderTest { get; set; }

    }
}
