namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManagedevicesSetInstallationTypePage : DealerSetInstallationTypePage, IPageObject
    {
        private const string _url = "/mps/local-office/manage-devices/set-installation-type";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/manage-devices/set-installation-type\"]";

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
