using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Domain.SpecFlowTableMappings
{
    public class PrinterProperties
    {
        public string Model { get; set; }
        public string Price { get; set; }
        public string Installation { get; set; }
        public string Delivery { get; set; }
        public int CoverageMono { get; set; }
        public int VolumeMono { get; set; }
        public int CoverageColour { get; set; }
        public int VolumeColour { get; set; }
    }
}
