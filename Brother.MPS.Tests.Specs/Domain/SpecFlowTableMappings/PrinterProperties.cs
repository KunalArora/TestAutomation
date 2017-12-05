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

        public bool IncludeDelivery
        {
            get
            {
                var includeDelivery = false;
                if (!string.IsNullOrEmpty(Delivery))
                {
                    var deliveryInput = Delivery.ToLower();
                    includeDelivery = deliveryInput == "yes";
                }
                return includeDelivery;
            }
        }

        public string SerialNumber { get; set; }
        public string DeviceId { get; set; }
        public int MonoPrintCount { get; set; }
        public int ColorPrintCount { get; set; }
        public int TotalPageCount { get; set; }
        public string TonerInkBlackStatus { get; set; }
        public string TonerInkCyanStatus { get; set; }
        public string TonerInkMagentaStatus { get; set; }
        public string TonerInkYellowStatus { get; set; }
        public string LaserUnit { get; set; }
        public string FuserUnit { get; set; }
        public string PaperFeedingKit1 { get; set; }
        public string PaperFeedingKit2 { get; set; }
        public string PaperFeedingKit3 { get; set; }
        public bool IsSwap { get; set; }
    }
}
