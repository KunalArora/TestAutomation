﻿using System;
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
        public string AddressString { get; set; } // Address string displayed on the devices page
        public string MonoClickPrice { get; set; }
        public string ColourClickPrice { get; set; }
        public int VolumeMono { get; set; }
        public int VolumeColour { get; set; }
        public int CoverageMono { get; set; }
        public int CoverageColour { get; set; }
        public bool IsMonochrome { get; set; }
        public string SerialNumber { get; set; }
        public string CommunicationMethod { get; set; }
        public string ResetDevice { get; set; }
        public string ReInstallDevice { get; set; }
        public bool IsSwap { get; set; }
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
        public string TonerInkBlackRemLife { get; set; }
        public string TonerInkCyanRemLife { get; set; }
        public string TonerInkMagentaRemLife { get; set; }
        public string TonerInkYellowRemLife { get; set; }
        public string TonerInkBlackReplaceCount { get; set; }
        public string TonerInkCyanReplaceCount { get; set; }
        public string TonerInkMagentaReplaceCount { get; set; }
        public string TonerInkYellowReplaceCount { get; set; }
        public int TonerInkBlackOrderCount { get; set; }
        public int TonerInkCyanOrderCount { get; set; }
        public int TonerInkMagentaOrderCount { get; set; }
        public int TonerInkYellowOrderCount { get; set; }

        public void UpdateConsumableOrderCount()
        {
            if (TonerInkBlackStatus.ToLower().Equals("empty") || (double.Parse(TonerInkBlackRemLife) < 10))
            {
                TonerInkBlackOrderCount = TonerInkBlackOrderCount + 1;
            }
            if (TonerInkCyanStatus.ToLower().Equals("empty") || (double.Parse(TonerInkCyanRemLife) < 10))
            {
                TonerInkCyanOrderCount = TonerInkCyanOrderCount + 1;
            }
            if (TonerInkMagentaStatus.ToLower().Equals("empty") || (double.Parse(TonerInkMagentaRemLife) < 10))
            {
                TonerInkMagentaOrderCount = TonerInkMagentaOrderCount + 1;
            }
            if (TonerInkYellowStatus.ToLower().Equals("empty") || (double.Parse(TonerInkYellowRemLife) < 10))
            {
                TonerInkYellowOrderCount = TonerInkYellowOrderCount + 1;
            }
        }

        public bool hasEmptyInkToner
        {
            get
            {
                return new List<string>() {
                    TonerInkBlackStatus,
                    TonerInkCyanStatus,
                    TonerInkMagentaStatus,
                    TonerInkYellowStatus
                }.Exists(s => s.ToLower().Equals("empty"));
            }
        }

        public bool hasLowRemLifeInkToner
        {
            get
            {
                bool hasLowRemLifeInkToner = false;
                try
                {
                    if ((double.Parse(TonerInkBlackRemLife) <= (MonoThresholdValue != null ? double.Parse(MonoThresholdValue) : 10.00)) ||
                        (double.Parse(TonerInkCyanRemLife) <= (ColourThresholdValue != null ? double.Parse(ColourThresholdValue) : 10.00)) ||
                        (double.Parse(TonerInkMagentaRemLife) <= (ColourThresholdValue != null ? double.Parse(ColourThresholdValue) : 10.00)) ||
                        (double.Parse(TonerInkYellowRemLife) <= (ColourThresholdValue != null ? double.Parse(ColourThresholdValue) : 10.00)))
                    {
                        hasLowRemLifeInkToner = true;
                    }

                }
                catch(Exception e) {
                    throw new Exception("Parameter hasLowRemLifeInkToner cannot be determined as the following exception occurred. Exception: " + e);
                }
                return hasLowRemLifeInkToner;
            }
        }

        public string ServiceRequestId { get; set; }
        public string ServiceRequestType { get; set; }
        public string ServiceRequestReplyMessage { get; set; }
        public int OpenServiceRequestCount { get; set; }
        public int ClosedServiceRequestCount { get; set; }
        public int TotalServiceRequestCount
        {
            get
            {
                return OpenServiceRequestCount;
            }
        }
        public string InstallationPack { get; set; }
        public string ServicePack { get; set; }
        public string InstallationPackPrice { get; set; }
        public string ServicePackPrice { get; set; }
        public string SwappedDeviceID { get; set; }
        public bool IsSwappedInDevice { get; set; }
        public string StartDeviceDate { get; set; }
        public string EndDeviceDate { get; set; }
        public int TotalPagesPrintedMono { get; set; }
        public int TotalPagesPrintedColour { get; set; }
        public bool IsResultSerialNumberSelected { get; set; }
        
        //printer engine threshold values
        public string MonoThresholdValue { get; set; }
        public string ColourThresholdValue { get; set; }
    }
}