using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
using System.Collections.Generic;

namespace Brother.Tests.Specs.Helpers
{
    public interface IPageParseHelper
    {
        SummaryPageValue ParseSummaryPageValues(BankProposalsSummaryPage page);
        SummaryPageValue ParseSummaryPageValues(ISeleniumHelper SeleniumHelper, string targetPrefix = "SummaryTable");
        CustomerInformationPageValue ParseCustomerInformationPageValues(ISeleniumHelper SeleniumHelper);
        ClickPricePageValue ParseClickPricePageValues(ISeleniumHelper SeleniumHelper);
        DealerAgreementDeviceValue ParseDealerAgreementDevicesPage(DealerAgreementDevicesPage dealerAgreementDevicesPage);
        DealerAgreementServiceRequestsValue ParseDealerAgreementServiceRequestsPage(DealerAgreementServiceRequestsPage dealerAgreementServiceRequestsPage);
        DealerAgreementConsumablesValue ParseDealerAgreementConsumablesPage(DealerAgreementConsumablesPage dealerAgreementConsumablesPage);
        List<Dictionary<string, string>> ToList(Dictionary<string, string> dic, string prefix, int count = -1);
        LocalOfficeAdminContractsEditEndDatePageValue ParseLocalOfficeAdminContractsEditEndDatePage(LocalOfficeAdminContractsEditEndDatePage localOfficeAdminContractsEditEndDatePage);
    }
}
