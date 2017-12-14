namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManagedevicesManagePage : DealerManageDevicesPage, IPageObject
    {

        private const string _url = "/mps/local-office/manage-devices/manage";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/manage-devices/manage\"]";
        public override string PageUrl
        {
            get
            {
                return _url;
            }
        }
        public override string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

    }
}
