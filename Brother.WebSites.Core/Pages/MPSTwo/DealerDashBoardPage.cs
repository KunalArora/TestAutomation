using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
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
        public IWebElement CreateProposalLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/proposals'] .media-body")] 
        public IWebElement ExistingProposalLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".separator a[href=\"/mps/dealer/proposals\"]")]
        public IWebElement proposalTopElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/contracts'] .media-body")]
        public IWebElement ExistingContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/customers'] .media-body")]
        public IWebElement ExistingCustomerLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/contracts\"] .media-heading")]
        public IWebElement DashboardContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/admin\"] .media-body")]
        public IWebElement AdminLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".separator a[href='/mps/dealer/admin']")]
        public IWebElement DealerAdminTabElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-lang > span > a")]
        public IList<IWebElement> BelgianLanguageElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/contracts'] .media-body .media-heading")]
        public IWebElement BelgianLanguageIdentifierElement;
        
        

        public void IsCreateNewProposalLinkAvailable()
        {
            if (CreateProposalLinkElement == null) 
                throw new Exception("Unable to locate create new proposal link on dashboard page");
            
            AssertElementPresent(CreateProposalLinkElement, "Create New Proposal Link");
        }

        public void ChangeBelgianLanguage(string language)
        {
            if (!IsBelgiumSystem()) return;
            if (language.Equals("French"))
            {
                BelgianLanguageElement.First().Click();
                IsBelgianLanguageSelected("Contrats");
            }
            else if (language.Equals("Dutch"))
            {
                BelgianLanguageElement.Last().Click();
                IsBelgianLanguageSelected("Contracten");
            }

            SpecFlow.SetContext("BelgianLanguage", language);
        }

        public void IsBelgianLanguageSelected(string text)
        {
            if (BelgianLanguageElement == null) 
                throw new Exception("Unable to locate existing proposals link on dashboard page");

            AssertElementContainsText(BelgianLanguageIdentifierElement, text, 
                                    String.Format("The word displayed was {0}", BelgianLanguageIdentifierElement.Text));
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

        public DealerProposalsCreateDescriptionPage NavigateToCreateNewProposalPage()
        {
            IsCreateNewProposalLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, CreateProposalLinkElement);
            return GetTabInstance<DealerProposalsCreateDescriptionPage>(Driver);
        }

        public DealerAdminDashBoardPage NavigateToAdminPage()
        {
            IsAdminLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, AdminLinkElement);
            return GetTabInstance<DealerAdminDashBoardPage>(Driver);
        }

        public DealerContractsPage NavigateToContractScreenFromDealerDashboard()
        {
            if (DashboardContractLinkElement == null)
                throw new NullReferenceException("Contract link is not Dealer Dashboard");
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, DashboardContractLinkElement);
            return GetTabInstance<DealerContractsPage>(Driver);
        }

        public DealerAdminDashBoardPage NavigateToAdminPageUsingTab()
        {
            IsAdminTabAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, DealerAdminTabElement);
            return GetTabInstance<DealerAdminDashBoardPage>(Driver);
        }

        public CloudExistingProposalPage NavigateToExistingProposalPage()
        {
            if(ExistingProposalLinkElement == null)
                throw new Exception("Are you sure you on dealer dashboard page?");
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, proposalTopElement);

            return GetInstance<CloudExistingProposalPage>(Driver);
        }

        public DealerCustomersExistingPage NavigateToExistingCustomerPage()
        {
            if (ExistingCustomerLinkElement == null)
                throw new Exception("Are you sure you on dealer dashboard page?");
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ExistingCustomerLinkElement);

            return GetInstance<DealerCustomersExistingPage>(Driver);
        }

    }
}
