using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public static class DealerProposalsCreateNavTabs
    {
        //This module has been designed to cater for the navigation that will occur on the MPS2 top navigational tabs

        private const string DescriptionNavTab = @".nav-tabs a[href='/mps/dealer/proposals/create/description']";
        private const string CustomerInformationNavTab = @".nav-tabs a[href='/mps/dealer/proposals/create/customer-information']";
        private const string TermAndTypeNavTab = @".nav-tabs a[href='/mps/dealer/proposals/create/term-type']";
        private const string ProductsNavTab = @".nav-tabs a[href='/mps/dealer/proposals/create/products']";
        private const string ClickPriceNavTab = @".nav-tabs a[href='/mps/dealer/proposals/create/click-price']";
        private const string SummaryNavTab = @".nav-tabs a[href='/mps/dealer/proposals/create/summary']";


        private static IWebElement FindTab(ISearchContext driver, string tabselector)
        {
            return driver.FindElement(By.CssSelector(tabselector));
        }

        public static DealerProposalsCreateDescriptionPage NavigateToDescriptionTab(IWebDriver driver)
        {
            FindTab(driver, DescriptionNavTab).Click();
            return BasePage.GetInstance<DealerProposalsCreateDescriptionPage>(driver, "", "");
        }

        public static DealerProposalsCreateCustomerInformationPage NavigateToCustomerInformationTab(IWebDriver driver)
        {
            FindTab(driver, CustomerInformationNavTab).Click();
            return BasePage.GetInstance<DealerProposalsCreateCustomerInformationPage>(driver, "", "");
        }

        public static DealerProposalsCreateTermAndTypePage NavigateToTermAndTypeTab(IWebDriver driver)
        {
            FindTab(driver, TermAndTypeNavTab).Click();
            return BasePage.GetInstance<DealerProposalsCreateTermAndTypePage>(driver, "", "");
        }

        public static DealerProposalsCreateProductsPage NavigateToProductsTab(IWebDriver driver)
        {
            FindTab(driver, ProductsNavTab).Click();
            return BasePage.GetInstance<DealerProposalsCreateProductsPage>(driver, "", "");
        }

        public static DealerProposalsCreateClickPricePage NavigateToClickPriceTab(IWebDriver driver)
        {
            FindTab(driver, ClickPriceNavTab).Click();
            return BasePage.GetInstance<DealerProposalsCreateClickPricePage>(driver, "", "");
        }

        public static DealerProposalsCreateSummaryPage NavigateToSummaryTab(IWebDriver driver)
        {
            FindTab(driver, SummaryNavTab).Click();
            return BasePage.GetInstance<DealerProposalsCreateSummaryPage>(driver, "", "");
        }
    }
}