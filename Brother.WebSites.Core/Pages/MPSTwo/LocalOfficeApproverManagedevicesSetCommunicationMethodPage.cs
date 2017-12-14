namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManagedevicesSetCommunicationMethodPage : DealerSetCommunicationMethodPage, IPageObject
    {
        private const string _url = "/mps/local-office/manage-devices/set-communication-method";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/manage-devices/set-communication-method\"]";

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
