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
        private int _defaultInvoiceGenerationTimeout = 20;
        private int _defaultElementNotPresentTimeout = 3;
        private int _defaultWaitForItemTimeout = 60;
        private string _defaultType3DealerUsernameBUK = null;
        private string _defaultType3DealerPasswordBUK = null;
        private string _defaultType1DealerUsernameBUK = null;
        private string _defaultType1DealerPasswordBUK = null;
        private string _defaultType1DealerUsernameBIG = null;
        private string _defaultType1DealerPasswordBIG = null;
        private string _defaultType1DealerUsernameBSW = null;
        private string _defaultType1DealerPasswordBSW = null;


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
        /// <param name="defaultSerialNumberOffset">Default 0</param>
        /// <param name="defaultInvoiceGenerationTimeout">Default 20s</param>
        /// <param name="defaultElementNotPresentTimeout">Default 3s</param>
        /// <param name="defaultWaitForItemTimeout">Default 60s</param>
        /// <param name="defaultType3DealerUsernameBUK">Default null</param>
        /// <param name="defaultType3DealerPasswordBUK">Default null</param>
        /// <param name="defaultType1DealerUsernameBUK">Default null</param>
        /// <param name="defaultType1DealerPasswordBUK">Default null</param>
        /// <param name="defaultType1DealerUsernameBIG">Default null</param>
        /// <param name="defaultType1DealerPasswordBIG">Default null</param>
        /// <param name="defaultType1DealerUsernameBSW">Default null</param>
        /// <param name="defaultType1DealerPasswordBSW">Default null</param>


        public RuntimeSettings(
            int? defaultPageLoadTimeout,
            int? defaultPageObjectTimeout,
            int? defaultFindElementTimeout,
            int? defaultRetryCount,
            int? defaultDeviceSimulatorTimeout,
            int? defaultRemoteWebDriverTimeout,
            int? defaultDownloadTimeout,
            int? defaultAPIResponseTimeout,
            int? defaultSerialNumberOffset,
            int? defaultInvoiceGenerationTimeout,
            int? defaultElementNotPresentTimeout,
            int? defaultWaitForItemTimeout,
            string defaultType3DealerUsernameBUK,
            string defaultType3DealerPasswordBUK,
            string defaultType1DealerUsernameBUK,
            string defaultType1DealerPasswordBUK,
            string defaultType1DealerUsernameBIG,
            string defaultType1DealerPasswordBIG,
            string defaultType1DealerUsernameBSW,
            string defaultType1DealerPasswordBSW
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
            DefaultInvoiceGenerationTimeout = defaultInvoiceGenerationTimeout ?? _defaultInvoiceGenerationTimeout;
            DefaultElementNotPresentTimeout = defaultElementNotPresentTimeout ?? _defaultElementNotPresentTimeout;
            DefaultWaitForItemTimeout = defaultWaitForItemTimeout ?? _defaultWaitForItemTimeout;
            DefaultType3DealerUsernameBUK = defaultType3DealerUsernameBUK ?? _defaultType3DealerUsernameBUK;
            DefaultType3DealerPasswordBUK = defaultType3DealerPasswordBUK ?? _defaultType3DealerPasswordBUK;
            DefaultType1DealerUsernameBUK = defaultType1DealerUsernameBUK ?? _defaultType1DealerUsernameBUK;
            DefaultType1DealerPasswordBUK = defaultType1DealerPasswordBUK ?? _defaultType1DealerPasswordBUK;
            DefaultType1DealerUsernameBIG = defaultType1DealerUsernameBIG ?? _defaultType1DealerUsernameBIG;
            DefaultType1DealerPasswordBIG = defaultType1DealerPasswordBIG ?? _defaultType1DealerPasswordBIG;
            DefaultType1DealerUsernameBSW = defaultType1DealerUsernameBSW ?? _defaultType1DealerUsernameBSW;
            DefaultType1DealerPasswordBSW = defaultType1DealerPasswordBSW ?? _defaultType1DealerPasswordBSW;
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
        public int DefaultInvoiceGenerationTimeout { get; set; }
        public int DefaultElementNotPresentTimeout { get; set; }
        public int DefaultWaitForItemTimeout { get; set; }
        public string DefaultType3DealerUsernameBUK { get; set; }
        public string DefaultType3DealerPasswordBUK { get; set; }
        public string DefaultType1DealerUsernameBUK { get; set; }
        public string DefaultType1DealerPasswordBUK { get; set; }
        public string DefaultType1DealerUsernameBIG { get; set; }
        public string DefaultType1DealerPasswordBIG { get; set; }
        public string DefaultType1DealerUsernameBSW { get; set; }
        public string DefaultType1DealerPasswordBSW { get; set; }
    }
}