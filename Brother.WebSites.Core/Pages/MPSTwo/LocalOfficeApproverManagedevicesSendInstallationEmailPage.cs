namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManageDevicesSendInstallationEmailPage :DealerSendInstallationEmailPage, IPageObject
    {
        private const string _url = "/mps/local-office/manage-devices/send-installation-email";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/manage-devices/send-installation-email\"]";

        public new string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }
        public new string PageUrl
        {
            get
            {
                return _url;
            }
        }

    }
}
