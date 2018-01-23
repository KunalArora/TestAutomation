using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerDashBoardPage : BasePage, IPageObject
    {
        public static string Url = "/mps/dealer/dashboard";
        private const string _validationElementSelector = "div.mps-dashboard";
        private const string _url = "/mps/dealer/dashboard";

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

        public ISeleniumHelper SeleniumHelper { get; set; }

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/create-proposal'] .media-body")] 
        public IWebElement CreateProposalLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/create-agreement'] .media-body")]
        public IWebElement CreateAgreementLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/proposals'] .media-body")] 
        public IWebElement ExistingProposalLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/agreements'] .media-body")]
        public IWebElement ExistingAgreementLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".separator a[href=\"/mps/dealer/proposals\"]")]
        public IWebElement proposalTopElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/contracts'] .media-body")]
        public IWebElement ExistingContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/reports\"] .media-body")]
        public IWebElement DealerReportLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/customers'] .media-body")]
        public IWebElement ExistingCustomerLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/contracts\"] .media-heading")]
        public IWebElement DashboardContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/admin\"] .media-body")]
        public IWebElement AdminLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".separator a[href='/mps/dealer/admin']")]
        public IWebElement DealerAdminTabElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-lang > span > a")]
        public IList<IWebElement> MultipleLanguagesElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/contracts'] .media-body .media-heading")]
        public IWebElement SwitchedLanguageIdentifierElement;
        
        

        public void IsCreateNewProposalLinkAvailable()
        {
            if (CreateProposalLinkElement == null) 
                throw new Exception("Unable to locate create new proposal link on dashboard page");
            
            AssertElementPresent(CreateProposalLinkElement, "Create New Proposal Link");
        }

        public void SwitchBetweenMultipleLanguages(string language)
        {
            if (IsBelgiumSystem())
            {
                SwitchBelgianLanguage(language);

            } else if (IsFinlandSystem())
            {
                SwitchFinnishLanguage(language);
            }
            else if (IsSwissSystem())
            {
             SwitchSwissLanguage(language);   
            }

            SpecFlow.SetContext("BelgianLanguage", language);
        }

        public void SwitchBelgianLanguage(string lang)
        {
            if (lang.Equals("French") || lang.Equals("Français"))
            {
                MultipleLanguagesElement.First().Click();
                IsSwitchedLanguageSelected("Contrats");
            }
            else if (lang.Equals("Dutch") || lang.Equals("Nederlands"))
            {
                MultipleLanguagesElement.Last().Click();
                IsSwitchedLanguageSelected("Contracten");
            }
        }

        public void SwitchSwissLanguage(string lang)
        {
            if (lang.Equals("Deutsch"))
            {
                MultipleLanguagesElement.First().Click();
                IsSwitchedLanguageSelected("Verträge");
            }
            else if (lang.Equals("Français"))
            {
                MultipleLanguagesElement.Last().Click();
                IsSwitchedLanguageSelected("Contrats");
            }
        }

        public void SwitchFinnishLanguage(string lang)
        {
            if (lang.Equals("Suomi"))
            {
                MultipleLanguagesElement.First().Click();
                IsSwitchedLanguageSelected("Sopimukset");
            }
            else if (lang.Equals("Svenska"))
            {
                MultipleLanguagesElement.Last().Click();
                IsSwitchedLanguageSelected("Avtal");
            }
        }

        public void IsSwitchedLanguageSelected(string text)
        {
            
            try
            {
                WaitForElementToExistByCssSelector("a[href='/mps/dealer/contracts'] .media-body .media-heading", 3, 5);

                if (SwitchedLanguageIdentifierElement == null)
                    throw new Exception("Unable to locate existing proposals link on dashboard page");

                AssertElementContainsText(SwitchedLanguageIdentifierElement, text,
                                    String.Format("The word displayed was {0}", SwitchedLanguageIdentifierElement.Text));
            }
            catch (StaleElementReferenceException e)
            {
                throw new Exception("The page refreshed and the element became stale with the following error" + e);
              
            }
            
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

        public ReportingDashboardPage NavigateToReportPage()
        {
            IsCreateNewProposalLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, DealerReportLinkElement);
            return GetTabInstance<ReportingDashboardPage>();
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
