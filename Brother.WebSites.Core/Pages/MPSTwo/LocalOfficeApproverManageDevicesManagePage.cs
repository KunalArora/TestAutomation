namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManageDevicesManagePage : DealerManageDevicesPage, IPageObject
    {

        private const string _url = "/mps/local-office/manage-devices/manage";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/manage-devices/manage\"]";
        public new string PageUrl
        {
            get
            {
                return _url;
            }
        }
        public new string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

    }
}
