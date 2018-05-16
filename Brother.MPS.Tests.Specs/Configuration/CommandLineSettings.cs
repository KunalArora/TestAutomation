using Brother.Tests.Common.CommandLineSettings;
using NUnit.Framework;

namespace Brother.Tests.Specs.Configuration
{
    public class CommandLineSettings : ICommandLineSettings
    {
        public CommandLineSettings()
        {
            OutputPath = TestContext.Parameters.Get("output_path", null);
            LoggingLevel = TestContext.Parameters.Get("logging_level", null);
            EnvironmentUnderTest = TestContext.Parameters.Get("env", null);
            BaseUrl = TestContext.Parameters.Get("base_url", null);
            Culture = TestContext.Parameters.Get("culture", null);
            DealerUsername = TestContext.Parameters.Get("dealer_username", null);
            DealerPassword = TestContext.Parameters.Get("dealer_password", null);
            LoggingStreamType = TestContext.Parameters.Get("logging_stream_type", null);

            if (OutputPath != null)
            {
                //Replace escape characters required by Powershell 
                OutputPath = OutputPath.Replace("\'", "");
            }
        }

        public string OutputPath { get; set; }
        public string LoggingLevel { get; set; }
        public string EnvironmentUnderTest { get; set; }
        public string BaseUrl { get; set; }
        public string Culture { get; set; }
        public string DealerUsername { get; set; }
        public string DealerPassword { get; set; }
        public string LoggingStreamType { get; set; }
    }
}
