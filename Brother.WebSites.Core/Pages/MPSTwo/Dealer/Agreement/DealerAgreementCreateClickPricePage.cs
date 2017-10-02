using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
{
    public class DealerAgreementCreateClickPricePage : BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-clickprice-group";
        private const string _url = "/mps/dealer/agreements/manage/click-price";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        //WebElement properties
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;
    }
}

