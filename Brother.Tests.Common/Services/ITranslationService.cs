﻿namespace Brother.Tests.Common.Services
{
    public interface ITranslationService
    {
        string GetInstallationPackText(string name, string culture);
        string GetServicePackTypeText(string name, string culture);
        string GetContractTypeText(string name, string culture);
        string GetUsageTypeText(string name, string culture);
        string GetContractTermText(string name, string culture);
        string GetBillingTypeText(string name, string culture);
        string GetPaymentTypeText(string name, string culture);
        string GetSwapTypeText(string name, string culture);
        string GetInstallationStatusText(string name, string culture);
        string GetInstalledPrinterStatusText(string name, string culture);
        string GetProposalDeclineReasonText(string name, string culture);
        string GetPdfTranslationsText(string name, string culture);
        string GetConsumableOrderStatusText(string name, string culture);
        string GetServiceRequestStatusText(string name, string culture);
        string GetOverusageText(string name, string culture);
        string GetContractRejectReason(string name, string culture);
        string GetDisplayMessageText(string name, string culture);
        string GetLeasingBillingCycle(string leasingBillingCycle, string culture);
        string GetOrderedConsumable(string name, string culture);
        string GetStaffAccessPermission(string name, string culture);
        string GetDealerCulture(string name, string culture);
        string GetCsvTranslations(string name, string culture);
        string GetSupplyItemType(string name, string culture);
        string GetBillingPaymentTypeText(string name, string culture);
        string GetBillingCycleStatusText(string name, string culture);
        // Exclusively Type 3
        string GetAgreementTypeText(string name, string culture);
        string GetAgreementStatusText(string name, string culture);
        string GetDeviceConnectionStatusText(string name, string culture);
        string GetCommunicationMethodText(string cloud, string culture);
        string GetConsumableOrderMethodText(string name, string culture);
    }
}
