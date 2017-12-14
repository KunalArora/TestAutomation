namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManagedevicesSetCommunicationMethodPage : DealerSetCommunicationMethodPage
    {
        private const string _url = "/mps/local-office/manage-devices/set-communication-method";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/manage-devices/set-communication-method\"]";

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
