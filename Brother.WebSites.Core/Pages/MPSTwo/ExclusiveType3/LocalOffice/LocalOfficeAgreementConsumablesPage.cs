using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice
{
    public class LocalOfficeAgreementConsumablesPage : DealerAgreementConsumablesPage, IPageObject
    {
        private string _validationElementSelector = ".active a[href*=\"/consumables\"]";
        private const string _url = "/mps/local-office/agreement/{agreementId}/consumables"; // TODO: Replace agreementId with dynamic parameter

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
