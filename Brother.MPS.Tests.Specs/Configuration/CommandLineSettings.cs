using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Configuration
{
    public class CommandLineSettings
    {
        public string OutputPath { get; set; }
        public string LoggingLevel { get; set; }
        public string EnvironmentUnderTest { get; set; }
    }
}
