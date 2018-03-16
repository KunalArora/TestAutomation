using System;
using System.Globalization;
using Brother.Tests.Common.Resources;

namespace Brother.Tests.Common.Services
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

        public string GetContractTermText(string name, string culture)
        {
            return GetText(Resources.ContractTerm.ContractTerm.ResourceManager, name, culture);
        }

        public string GetContractTypeText(string name, string culture)
        {
            return GetText(Resources.ContractType.ContractType.ResourceManager, name, culture);
        }

        public string GetUsageTypeText(string name, string culture)
        {
            return GetText(Resources.UsageType.UsageType.ResourceManager, name, culture);
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

        public string GetConsumableOrderStatusText(string name, string culture)
        {
            return GetText(Resources.ConsumableOrderStatus.ConsumableOrderStatus.ResourceManager, name, culture);
        }

        public string GetServiceRequestStatusText(string name, string culture)
        {
            return GetText(Resources.ServiceRequestStatus.ServiceRequestStatus.ResourceManager, name, culture);
        }

        public string GetOverusageText(string name, string culture)
        {
            return GetText(Resources.OverusageText.OverusageText.ResourceManager, name, culture);
        }

        public string GetContractRejectReason(string name, string culture)
        {
            return GetText(Resources.ContractRejectReason.ContractRejectReason.ResourceManager, name, culture);
        }

        public string GetDisplayMessageText(string name, string culture)
        {
            return GetText(Resources.DisplayMessage.DisplayMessage.ResourceManager, name, culture);
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

        public string GetLeasingBillingCycle(string name, string culture)
        {
            return GetText(Resources.LeasingBillingCycle.LeasingBillingCycle.ResourceManager, name, culture);
        }
    }
}
