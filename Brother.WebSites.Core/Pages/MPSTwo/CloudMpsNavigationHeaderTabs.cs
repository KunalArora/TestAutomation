using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CloudMpsNavigationHeaderTabs
    {
        //This module has been designed to cater for the navigation that will occur on the MPS2 top navigational tabs

        private const string DashboardNavTab = @".separator a[href='/mps/dealer/dashboard']";
        private const string ProposalNavTab = @".separator a[href='/mps/dealer/proposals']";
        private const string ContractNavTab = @".separator a[href='/mps/dealer/contracts']";
        private const string CustomerNavTab = @".separator a[href='/mps/dealer/customers']";


        private static IWebElement CustomerTab(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(CustomerNavTab));
        }

        public static DealerCustomersExistingPage NavigateToCustomerScreen(IWebDriver driver)
        {
            CustomerTab(driver).Click();
            return BasePage.GetInstance<DealerCustomersExistingPage>(driver, "", "");
        }

        private static IWebElement ContractTab(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ContractNavTab));
        }

        public static DealerContractsPage NavigateToContractScreen(IWebDriver driver)
        {
            ContractTab(driver).Click();
            return BasePage.GetInstance<DealerContractsPage>(driver, "", "");
        }

        private static IWebElement DashboardTab(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(DashboardNavTab));
        }

        public static DealerDashBoardPage NavigateToDashboardScreen(IWebDriver driver)
        {
            DashboardTab(driver).Click();
            return BasePage.GetInstance<DealerDashBoardPage>(driver, "", "");
        }

        private static IWebElement ProposalTab(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProposalNavTab));
        }

        public static CloudExistingProposalPage NavigateToProposalScreen(IWebDriver driver)
        {
            ProposalTab(driver).Click();
            return BasePage.GetInstance<CloudExistingProposalPage>(driver, "", "");
        }
    }
}