namespace Brother.Tests.Specs.Configuration
{
    public interface IRuntimeSettings
    {
        int DefaultPageLoadTimeout { get; set; }
        int DefaultPageObjectTimeout { get; set; }
        int DefaultFindElementTimeout { get; set; }
        int DefaultRetryCount { get; set; }
        int DefaultDeviceSimulatorTimeout { get; set; }
        int DefaultRemoteWebDriverTimeout { get; set; }
    }
}
