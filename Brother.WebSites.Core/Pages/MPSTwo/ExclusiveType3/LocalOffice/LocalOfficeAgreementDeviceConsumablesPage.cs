using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice
{
    public class LocalOfficeAgreementDeviceConsumablesPage : DealerAgreementDeviceConsumablesPage, IPageObject
    {
        private string _validationElementSelector = ".active a[href*=\"/consumables\"]";
        private const string _url = "/mps/local-office/agreement/{agreementId}/consumables/?id={deviceId}"; // TODO: Replace agreementId & deviceId with dynamic parameters

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }
    }
}
