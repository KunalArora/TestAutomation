﻿using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsSummaryPage : BaseSummaryPage, IPageObject
    {
        public static string _url = "/mps/dealer/contracts/summary";
        private const string _validationElementSelector = "#content_1_ButtonDownloadProposalPdfWithCalcs"; // Download PDF

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

        public ISeleniumHelper SeleniumHelper
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonDownloadProposalPdf")]
        public IWebElement DownloadProposalPdfElement;


    }

}