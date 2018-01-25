using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsConvertCustomerInformationPage : DealerCustomersManagePage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/convert/customer-information";
        private const string _validationElementSelector = ".js-mps-val-btn-next"; // #content_1_ButtonNext

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        [FindsBy(How = How.CssSelector, Using = "input[type=\"submit\"]#content_1_ButtonNext")]
        public IWebElement nextButtonElement;

        [FindsBy(How = How.Id, Using = "content_1_InputCustomerChoiceNew")]
        public IWebElement CreateNewCustomerElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;

    }

}
