﻿namespace Brother.Tests.Specs.Configuration
{
    public class RuntimeSettings
    {
        public RuntimeSettings()
        {
            DefaultPageLoadTimeout = 10;
            DefaultPageObjectTimeout = 10;
            DefaultFindElementTimeout = 10;
            DefaultRetryCount = 10;
            DefaultDeviceSimulatorTimeout = 10;
            DefaultDownLoadTimeout = 30;
        }

        public int DefaultPageLoadTimeout { get; set; }
        public int DefaultPageObjectTimeout { get; set; }
        public int DefaultFindElementTimeout { get; set; }
        public int DefaultRetryCount { get; set; }
        public int DefaultDeviceSimulatorTimeout { get; set; }
        public int DefaultDownLoadTimeout { get; set; }
    }
}
