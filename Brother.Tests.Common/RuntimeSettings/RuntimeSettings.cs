namespace Brother.Tests.Common.RuntimeSettings
{
    public class RuntimeSettings : IRuntimeSettings
    {
        private int _defaultPageLoadTimeout = 10;
        private int _defaultPageObjectTimeout = 10;
        private int _defaultFindElementTimeout = 10;
        private int _defaultRetryCount = 10;
        private int _defaultDeviceSimulatorTimeout = 10;
        private int _defaultRemoteWebDriverTimeout = 30;
        private int _defaultDownloadTimeout = 30;
        private int _defaultAPIResponseTimeout = 30;
        private int _defaultSerialNumberOffset = 0;

        /// <summary>
        /// Initialise runtime settings. Timeout values are in seconds.
        /// If a null parameter is supplied a default will be used as specified.
        /// </summary>
        /// <param name="defaultPageLoadTimeout">Default 10s</param>
        /// <param name="defaultPageObjectTimeout">Default 10s</param>
        /// <param name="defaultFindElementTimeout">Default 10s</param>
        /// <param name="defaultRetryCount">Default 10</param>
        /// <param name="defaultDeviceSimulatorTimeout">Default 10s</param>
        /// <param name="defaultRemoteWebDriverTimeout">Default 30s</param>
        /// <param name="defaultDownloadTimeout">Default 30s</param>
        /// <param name="defaultAPIResponseTimeout">Default 30s</param>
        public RuntimeSettings(
            int? defaultPageLoadTimeout,
            int? defaultPageObjectTimeout,
            int? defaultFindElementTimeout,
            int? defaultRetryCount,
            int? defaultDeviceSimulatorTimeout,
            int? defaultRemoteWebDriverTimeout,
            int? defaultDownloadTimeout,
            int? defaultAPIResponseTimeout,
            int? defaultSerialNumberOffset
            )
        {
            DefaultPageLoadTimeout = defaultPageLoadTimeout ?? _defaultPageLoadTimeout;
            DefaultPageObjectTimeout = defaultPageObjectTimeout ?? _defaultPageObjectTimeout;
            DefaultFindElementTimeout = defaultFindElementTimeout ?? _defaultFindElementTimeout;
            DefaultRetryCount = defaultRetryCount ?? _defaultRetryCount;
            DefaultDeviceSimulatorTimeout = defaultDeviceSimulatorTimeout ?? _defaultDeviceSimulatorTimeout;
            DefaultRemoteWebDriverTimeout = defaultRemoteWebDriverTimeout ?? _defaultRemoteWebDriverTimeout;
            DefaultDownloadTimeout = defaultDownloadTimeout ?? _defaultDownloadTimeout;
            DefaultAPIResponseTimeout = defaultAPIResponseTimeout ?? _defaultAPIResponseTimeout;
            DefaultSerialNumberOffset = defaultSerialNumberOffset ?? _defaultSerialNumberOffset;
        }

        public int DefaultPageLoadTimeout { get; set; }
        public int DefaultPageObjectTimeout { get; set; }
        public int DefaultFindElementTimeout { get; set; }
        public int DefaultRetryCount { get; set; }
        public int DefaultDeviceSimulatorTimeout { get; set; }
        public int DefaultDownloadTimeout { get; set; }
        public int DefaultRemoteWebDriverTimeout { get; set; }
        public int DefaultAPIResponseTimeout { get; set; }
        public int DefaultSerialNumberOffset { get; set; }
    }
}
