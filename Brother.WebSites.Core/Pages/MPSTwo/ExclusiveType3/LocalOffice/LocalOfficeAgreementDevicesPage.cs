using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice
{
    public class LocalOfficeAgreementDevicesPage : DealerAgreementDevicesPage, IPageObject // Inherit DealerAgreementDevicesPage as properties are exactly same
    {
        private const string _validationElementSelector = ".mps-dataTables-footer"; // Device data table footer
        private const string _url = "/mps/local-office/agreement/{agreementId}/devices"; // TODO: Replace agreementId with dynamic parameter

        public new string ValidationElementSelector
        {
            get { return _validationElementSelector; }
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
