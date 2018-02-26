namespace Brother.Tests.Common.CommandLineSettings
{
    public interface ICommandLineSettings
    {
        string OutputPath { get; set; }
        string LoggingLevel { get; set; }
        string EnvironmentUnderTest { get; set; }
        string BaseUrl { get; set; }
        string Culture { get; set; }
        string DealerUsername { get; set; }
        string DealerPassword { get; set; }

    }
}
