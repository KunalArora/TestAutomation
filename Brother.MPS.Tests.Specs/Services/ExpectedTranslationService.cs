﻿using System;
using System.Globalization;

namespace Brother.Tests.Specs.Services
{
    public class ExpectedTranslationService : ITranslationService
    {
        public string GetInstallationPackText(string name, string culture)
        {
            return GetText(Resources.InstallationPack.InstallationPack.ResourceManager, name, culture);
        }

        public string GetServicePackTypeText(string name, string culture)
        {
            return GetText(Resources.ServicePackType.ServicePackType.ResourceManager, name, culture);
        }

        public string GetContractTypeText(string name, string culture)
        {
            return GetText(Resources.ContractType.ContractType.ResourceManager, name, culture);
        }

        public string GetUsageTypeText(string name, string culture)
        {
            return GetText(Resources.UsageType.UsageType.ResourceManager, name, culture);
        }

        public string GetContractTermText(string name, string culture)
        {
            return GetText(Resources.ContractTerm.ContractTerm.ResourceManager, name, culture);
        }

        public string GetBillingTypeText(string name, string culture)
        {
            return GetText(Resources.BillingType.BillingType.ResourceManager, name, culture);
        }

        public string GetPaymentTypeText(string name, string culture)
        {
            return GetText(Resources.PaymentType.PaymentType.ResourceManager, name, culture);
        }

        public string GetSwapTypeText(string name, string culture)
        {
            return GetText(Resources.SwapType.SwapType.ResourceManager, name, culture);
        }

        public string GetInstallationStatusText(string name, string culture)
        {
            return GetText(Resources.InstallationRequestStatus.InstallationRequestStatus.ResourceManager, name, culture);
        }

        public string GetInstalledPrinterStatusText(string name, string culture)
        {
            return GetText(Resources.InstalledPrinterStatus.InstalledPrinterStatus.ResourceManager, name, culture);
        }

        public string GetProposalDeclineReasonText(string name, string culture)
        {
            return GetText(Resources.ProposalDeclineReason.ProposalDeclineReason.ResourceManager, name, culture);
        }

        #region Exclusively Type 3

        public string GetAgreementTypeText(string name, string culture)
        {
            return GetText(Resources.AgreementType.AgreementType.ResourceManager, name, culture);
        }

        public string GetDeviceConnectionStatusText(string name, string culture)
        {
            return GetText(Resources.DeviceConnectionStatus.DeviceConnectionStatus.ResourceManager, name, culture);
        }

        #endregion


        private string GetText(System.Resources.ResourceManager resourceManager, string name, string culture)
        {
            string result = string.Empty;
            var cultureInfo = new CultureInfo(culture);
            try
            {
                result = resourceManager.GetString(name, cultureInfo);
            }
            catch (Exception ex)
            {
                //TODO: re-throw and categorise this
                var message = ex.Message;
            }
            return result;
        }

        public string GetProposalPdfText(string name, string culture)
        {
            return GetText(Resources.ProposalPDF.ProposalPDF.ResourceManager, name, culture);
        }
    }
}
