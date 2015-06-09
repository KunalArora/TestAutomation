using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerDashBoardPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/create-proposal'] .media-body")] 
        private IWebElement CreateProposalLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/proposals'] .media-body")] 
        private IWebElement ExistingProposalLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/contracts'] .media-body")]
        public IWebElement ExistingContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/customers'] .media-body")]
        public IWebElement ExistingCustomerLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/contracts\"] .media-heading")]
        private IWebElement DashboardContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/admin\"] .media-body")]
        private IWebElement AdminLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".separator a[href='/mps/dealer/admin']")]
        private IWebElement DealerAdminTabElement;

        public void IsCreateNewProposalLinkAvailable()
        {
            if (CreateProposalLinkElement == null) 
                throw new Exception("Unable to locate create new proposal link on dashboard page");
            
            AssertElementPresent(CreateProposalLinkElement, "Create New Proposal Link");
        }

        public void IsExistingProposalLinkAvailable()
        {
            if (ExistingProposalLinkElement == null) 
                throw new Exception("Unable to locate existing proposals link on dashboard page");

            AssertElementPresent(ExistingProposalLinkElement, "Existing Proposals Link");
        }

        public void IsExistingContractsLinkAvailable()
        {
            if (ExistingContractLinkElement == null) 
                throw new Exception("Unable to locate existing contracts link on dashboard page");

            AssertElementPresent(ExistingContractLinkElement, "Existing Contracts Link");
        }

        public void IsExistingCustomersLinkAvailable()
        {
            if (ExistingCustomerLinkElement == null) 
                throw new Exception("Unable to locate existing customers link on dashboard page");

            AssertElementPresent(ExistingCustomerLinkElement, "Existing Customers Link");
        }

        private void IsAdminLinkAvailable()
        {
            if (AdminLinkElement == null) 
                throw new Exception("Unable to locate create Admin link on dashboard page");

            AssertElementPresent(AdminLinkElement, "Create Admin Link");
        }

        private void IsAdminTabAvailable()
        {
            if (DealerAdminTabElement == null) 
                throw new Exception("Unable to locate create Admin link on dashboard page");

            AssertElementPresent(DealerAdminTabElement, "Create Admin Tab");
        }

        public CreateNewProposalPage NavigateToCreateNewProposalPage()
        {
            IsCreateNewProposalLinkAvailable();
            CreateProposalLinkElement.Click();
            return GetTabInstance<CreateNewProposalPage>(Driver);
        }

        public DealerAdminDashBoardPage NavigateToAdminPage()
        {
            IsAdminLinkAvailable();
            AdminLinkElement.Click();
            return GetTabInstance<DealerAdminDashBoardPage>(Driver);
        }

        public CloudContractPage NavigateToContractScreenFromDealerDashboard()
        {
            if (DashboardContractLinkElement == null)
                throw new NullReferenceException("Contract link is not Dealer Dashboard");
            DashboardContractLinkElement.Click();
            return GetTabInstance<CloudContractPage>(Driver);
        }

        public DealerAdminDashBoardPage NavigateToAdminPageUsingTab()
        {
            IsAdminTabAvailable();
            DealerAdminTabElement.Click();
            return GetTabInstance<DealerAdminDashBoardPage>(Driver);
        }

        public CloudExistingProposalPage NavigateToExistingProposalPage()
        {
            if(ExistingProposalLinkElement == null)
                throw new Exception("Are you sure you on dealer dashboard page?");
            ExistingProposalLinkElement.Click();

            return GetInstance<CloudExistingProposalPage>(Driver);
        }

    }
}
