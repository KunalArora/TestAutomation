using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeFinanceDashBoardPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_0_dashboardmain_0_Cols_Col_0 > ul > li > a > div > h4";
        private const string _url = "/mps/local-office/finance/dashboard";

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

        [FindsBy(How = How.CssSelector, Using = ".separator [href=\"/mps/local-office/finance\"]")]
        public IWebElement FinanceTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/finance/accruals\"] .media-heading")]
        public IWebElement AccrualsElement;


    }
}
