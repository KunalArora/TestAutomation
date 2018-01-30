using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Common.Domain.SpecFlowTableMappings
{
    // This class contains the fields which are present in Devices Excel sheet for Type 3 plus some additional properties
    public class AdditionalDeviceProperties
    {
        public string AgreementId { get; set; }
        public string MpsDeviceId { get; set; }
        public string BocDeviceId { get; set; }
        public string Model { get; set; }
        public string ConnectionStatus { get; set; }
        public string InstallationLink { get; set; }
        public string DeviceStatus { get; set; }
        public string RegistrationPin { get; set; }

        public string CustomerName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string AddressNumber { get; set; }
        public string AddressStreet { get; set; }
        public string AddressArea { get; set; }
        public string AddressTown { get; set; }
        public string AddressPostCode { get; set; }
        public string DeviceLocation { get; set; }
        public string CostCentre { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Reference3 { get; set; }
        public string InstallationNotes { get; set; }

        public string AdvancedInstallationLink { get; set; }

        // Extra properties not in Excel
        public string SerialNumber { get; set; }
        public string CommunicationMethod { get; set; }
        public int DeviceIndex { get; set; }
        public bool IsRegisteredOnBoc { get; set; }
        public int MonoPrintCount { get; set; }
        public int ColorPrintCount { get; set; }
        public int TotalPrintCount 
        {
            get
            {
                return MonoPrintCount + ColorPrintCount;
            }
        }
        public string TonerInkBlackStatus { get; set; }
        public string TonerInkCyanStatus { get; set; }
        public string TonerInkMagentaStatus { get; set; }
        public string TonerInkYellowStatus { get; set; }

        public bool hasEmptyInkToner
        {
            get
            {
                bool hasEmptyInkToner = false;
                if (TonerInkBlackStatus.ToLower().Equals("empty") ||
                    TonerInkCyanStatus.ToLower().Equals("empty") ||
                    TonerInkMagentaStatus.ToLower().Equals("empty") ||
                    TonerInkYellowStatus.ToLower().Equals("empty"))
                {
                    hasEmptyInkToner = true;
                }
                return hasEmptyInkToner;
            }
        }

        public string ServiceRequestId { get; set; }
        public string ServiceRequestType { get; set; }
        public string ServiceRequestReplyMessage { get; set; }
    }
}