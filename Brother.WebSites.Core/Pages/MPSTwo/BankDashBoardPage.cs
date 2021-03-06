﻿using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankDashBoardPage : BasePage, IPageObject
    {
        public static string Url = "/mps/bank/dashboard";
        private const string _validationElementSelector = "div.mps-dashboard";
        private const string _url = "/mps/bank/dashboard";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

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

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/bank/leasing-factors'] .media-body")]
        public IWebElement LeasingFactorsLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/bank/proposals'] .media-body")]
        public IWebElement OffersLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/bank/contracts'] .media-body")]
        public IWebElement ContractsLinkElement;

        public void IsLeasingFactorsLinkAvailable()
        {
            if (LeasingFactorsLinkElement == null) 
                throw new Exception("Unable to locate leasing contract link on dashboard page");

            AssertElementPresent(LeasingFactorsLinkElement, "Create New Leasing Factors Link");
        }

        public void IsOffersLinkAvailable()
        {
            if (OffersLinkElement == null)
                throw new Exception("Unable to locate Offers link on dashboard page");
           

            AssertElementPresent(OffersLinkElement, "Create New Offers Link");
        }

        public void IsContractsLinkAvailable()
        {
            if (ContractsLinkElement == null)
                throw new Exception("Unable to locate Contracts link on dashboard page");

            AssertElementPresent(ContractsLinkElement, "Create New Contracts Link");
        }

        public BankOffersPage NavigateToOffersPage()
        {
            IsOffersLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, OffersLinkElement);
            return GetTabInstance<BankOffersPage>(Driver);
        }

        public BankContractsPage NavigateToContractApprovedProposalPage()
        {
            IsOffersLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ContractsLinkElement);
            return GetTabInstance<BankContractsPage>(Driver);
        }
	
        public BankContractsPage NavigateToContractsPage()
        {
            IsContractsLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ContractsLinkElement);
            return GetTabInstance<BankContractsPage>(Driver);
        }
 

    }
}
