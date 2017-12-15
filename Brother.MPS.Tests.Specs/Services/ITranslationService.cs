namespace Brother.Tests.Specs.Services
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
    }
}
