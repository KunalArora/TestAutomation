namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManagedevicesSendInstallationEmailPage :DealerSendInstallationEmailPage
    {
        private const string _url = "/mps/local-office/manage-devices/send-installation-email";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/manage-devices/send-installation-email\"]";

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
