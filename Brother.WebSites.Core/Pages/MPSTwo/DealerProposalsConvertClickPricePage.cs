using Brother.WebSites.Core.Pages.Base;
using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    // see refer DealerProposalsCreateClickPricePage
    public class DealerProposalsConvertClickPricePage : DealerProposalsCreateClickPricePage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/convert/click-price";
        private const string _validationElementSelector = ".mps-clickprice-group";

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
