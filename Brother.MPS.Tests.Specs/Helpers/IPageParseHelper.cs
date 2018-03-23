using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.MPSTwo;

namespace Brother.Tests.Specs.Helpers
{
    public interface IPageParseHelper
    {
        SummaryPageValue ParseSummaryPageValues(BankProposalsSummaryPage page);
        SummaryPageValue ParseSummaryPageValues(ISeleniumHelper SeleniumHelper, string targetPrefix = "SummaryTable");
        CustomerInformationPageValue ParseCustomerInformationPageValues(ISeleniumHelper SeleniumHelper);
        ClickPricePageValue ParseClickPricePageValues(ISeleniumHelper SeleniumHelper);
    }
}
