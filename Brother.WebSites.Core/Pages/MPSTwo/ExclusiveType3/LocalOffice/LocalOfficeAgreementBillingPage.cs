using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice
{
    public class LocalOfficeAgreementBillingPage: DealerAgreementBillingPage, IPageObject
    {
        private string _validationElementSelector = ".js-mps-billing-dates-container";
        private const string _url = "/mps/local-office/agreement/{agreementId}/billing"; // TODO: Replace agreementId with dynamic parameter

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
