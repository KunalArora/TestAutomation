﻿namespace Brother.Tests.Common.RuntimeSettings
{
    public interface IRuntimeSettings
    {
        int DefaultPageLoadTimeout { get; set; }
        int DefaultPageObjectTimeout { get; set; }
        int DefaultFindElementTimeout { get; set; }
        int DefaultRetryCount { get; set; }
        int DefaultDeviceSimulatorTimeout { get; set; }
        int DefaultRemoteWebDriverTimeout { get; set; }
        int DefaultDownloadTimeout { get; set; }
        int DefaultAPIResponseTimeout { get; set; }
        int DefaultSerialNumberOffset { get; set; }
        int DefaultInvoiceGenerationTimeout { get; set; }
        int DefaultElementNotPresentTimeout { get; set; }
        int DefaultWaitForItemTimeout { get; set; }
        string DefaultType3DealerUsername { get; set; }
        string DefaultType3DealerPassword { get; set; }
    }
}
