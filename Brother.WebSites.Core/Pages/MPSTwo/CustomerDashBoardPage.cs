using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CustomerDashBoardPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "div.mps-dashboard";
        private const string _url = "/mps/customer/dashboard";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }
                
        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".separator a[href='/mps/customer/consumables']")]
        public IWebElement CustomerConsumablesTabElement;
        [FindsBy(How = How.CssSelector, Using = ".separator a[href='/mps/customer/service-requests']")]
        public IWebElement CustomerServiceRequestTabElement;

        public string ClickLanguageLink()
        {
            LoggingService.WriteLogOnMethodEntry();
            var languageLinkElement = SeleniumHelper.FindElementByCssSelector(string.Format("a[href='/mps/customer/dashboard?sc_lang={0}']", CultureInfo.Name));
            var language = languageLinkElement.Text;
            SeleniumHelper.ClickSafety(languageLinkElement);
            return language;
        }
    }
}
