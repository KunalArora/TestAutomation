using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Common.Domain.SpecFlowTableMappings
{
    public class SpecialPricingProperties
    {
        public string Model;            // ex. DCP-8110DN

        /**
         * Installation TAB
         */
        public string InstallUnitCost;  // ex. 200.00
        public string InstallMargin;    // ex. 20.00
        public string InstallUnitPrice; // ex. 250.00

        /**
         * Service TAB
         */
        public string ServiceUnitCost;
        public string ServiceMargin;
        public string ServiceUnitPrice;

        /**
         * Click Price TAB
         */
        public string MonoClickServiceCost;     // ex. 36.15
        public string MonoClickServicePrice;    // ex. 72.19

        public string MonoClickCoverage;        // ex. 5
        public string MonoClickVolume;          // ex. 1000
        public string MonoClickMargin;          // ex. 17.00
        public string MonoClick;                // ex. 0.01078

        public string ColourClickServiceCost;
        public string ColourClickServicePrice;

        public string ColourClickCoverage;
        public string ColourClickVolume;
        public string ColourClickMargin;
        public string ColourClick;
    }
}
