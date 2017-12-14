namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManagedevicesSendSwapDeviceInstallationEmail : DealerSendSwapInstallationEmailPage
    {
        public static string _url = "/mps/local-office/manage-devices/send-swap-device-installation-email";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/manage-devices/send-swap-device-installation-email\"]";

        public override string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public override string PageUrl
        {
            get
            {
                return _url;
            }
        }

    }
}
