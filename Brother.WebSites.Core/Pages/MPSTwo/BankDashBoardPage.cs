﻿using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankDashBoardPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/bank/leasing-factors'] .media-body")]
        private IWebElement LeasingFactorsLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/bank/proposals'] .media-body")]
        private IWebElement OffersLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/bank/contracts'] .media-body")]
        private IWebElement ContractsLinkElement;

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

            AssertElementPresent(OffersLinkElement, "Offers Link not found");
        }
        public void IsContractLinkAvailable()
        {
            if (ContractsLinkElement == null)
                throw new Exception("Unable to locate Contract link on dashboard page");

            AssertElementPresent(ContractsLinkElement, "Contract Link not found");
        }

        public BankOffersPage NavigateToOffersPage()
        {
            IsOffersLinkAvailable();
            OffersLinkElement.Click();
            return GetTabInstance<BankOffersPage>(Driver);
        }

        public BankContractsPage NavigateToContractApprovedProposalPage()
        {
            IsOffersLinkAvailable();
            ContractsLinkElement.Click();
            return GetTabInstance<BankContractsPage>(Driver);
        }

 

    }
}
