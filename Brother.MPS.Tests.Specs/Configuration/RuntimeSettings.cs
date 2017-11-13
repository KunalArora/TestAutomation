using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Configuration
{
    public class RuntimeSettings
    {
        public RuntimeSettings()
        {
            DefaultPageLoadTimeout = 10;
            DefaultPageObjectTimeout = 10;
            DefaultFindElementTimeout = 10;
            DefaultRetryCount = 10;
        }

        public int DefaultPageLoadTimeout { get; set; }
        public int DefaultPageObjectTimeout { get; set; }
        public int DefaultFindElementTimeout { get; set; }
        public int DefaultRetryCount { get; set; }
    }
}
