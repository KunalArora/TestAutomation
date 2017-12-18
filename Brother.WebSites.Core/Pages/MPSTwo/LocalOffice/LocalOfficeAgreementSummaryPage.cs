﻿using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.LocalOffice
{
    public class LocalOfficeAgreementSummaryPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_SummaryTable_ProposalDetailsContainer"; // Agreement Details Container
        private const string _url = "/mps/local-office/agreement/{agreementId}/summary"; // TODO: Replace agreementId with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Selectors
        private const string MpsTabsSelector = ".mps-tabs-main";
        private const string MpsTabsAgreementSelector = " a[href=\"/mps/local-office/agreement/";

        public IWebElement DevicesTabElement(int agreementId, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByCssSelector(
                string.Format(MpsTabsSelector + MpsTabsAgreementSelector + "{0}/devices\"]", agreementId.ToString()), findElementTimeout);
        }
    }
}