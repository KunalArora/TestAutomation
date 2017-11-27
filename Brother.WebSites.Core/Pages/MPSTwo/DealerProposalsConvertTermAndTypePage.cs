using Brother.WebSites.Core.Pages.Base;
using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsConvertTermAndTypePage : DealerAgreementCreateTermAndTypePage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/convert/term-type";
        private const string _validationElementSelector = "#content_1_InputUsageType_Input";

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
