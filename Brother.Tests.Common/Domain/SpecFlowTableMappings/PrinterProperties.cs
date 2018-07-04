
namespace Brother.Tests.Common.Domain.SpecFlowTableMappings
{
    public class PrinterProperties
    {
        public string Model { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string LowerTrayPrice { get; set; }
        public string InstallationPack { get; set; }
        public string InstallationPackPrice { get; set; }
        public string ServicePack { get; set; }
        public string ServicePackPrice { get; set; } 
        public string Delivery { get; set; }
        public bool IsMonochrome { get; set; }
        public int CoverageMono { get; set; }
        public int VolumeMono { get; set; }
        public int CoverageColour { get; set; }
        public int VolumeColour { get; set; }
        public string MonoClickPrice { get; set; }
        public string ColourClickPrice { get; set; }
        public string SendInstallationRequest { get; set; }

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
        public bool hasEmptyInkToner
        {
            get
            {
                bool hasEmptyInkToner = false;
                if ((TonerInkBlackStatus.ToLower().Equals("empty")) ||
                    (TonerInkCyanStatus.ToLower().Equals("empty")) ||
                    (TonerInkMagentaStatus.ToLower().Equals("empty")) ||
                    (TonerInkYellowStatus.ToLower().Equals("empty")))
                {
                    hasEmptyInkToner = true;
                }
                return hasEmptyInkToner;
            }
        }
        public string TonerInkBlackRemLife { get; set; }
        public string TonerInkCyanRemLife { get; set; }
        public string TonerInkMagentaRemLife { get; set; }
        public string TonerInkYellowRemLife { get; set; }
        public string TonerInkBlackReplaceCount { get; set; }
        public string TonerInkCyanReplaceCount { get; set; }
        public string TonerInkMagentaReplaceCount { get; set; }
        public string TonerInkYellowReplaceCount { get; set; }
        public string LaserUnit { get; set; }
        public string FuserUnit { get; set; }
        public string PaperFeedingKit1 { get; set; }
        public string PaperFeedingKit2 { get; set; }
        public string PaperFeedingKit3 { get; set; }
        public bool IsSwap { get; set; }
        public bool IsRemove { get; set; }
        public int monoOverusage { get; set; }
        public int colorOverusage { get; set; }
        public string ResetDevice { get; set; }
        public string BocModel { get; set; }
        public string ReInstallDevice { get; set; }
        public string ConsumableCreatedDate { get; set; }

        // apply special price for type3
        public bool _IsApplySpecialPriceInstall { get; set; }
        public bool _IsApplySpecialPriceService { get; set; }
        public bool _IsApplySpecialPriceClickPrice { get; set; }

        //printer engine threshold values
        public string MonoThresholdValue { get; set; }
        public string ColourThresholdValue { get; set; }
    }
}
