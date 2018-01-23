using System;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Brother.WebSites.Core.Pages.Base;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using System.Runtime.Serialization;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsConvertCustomerInformationPage : DealerCustomersManagePage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/convert/customer-information";
        private const string _validationElementSelector = ".js-mps-val-btn-next"; // #content_1_ButtonNext

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[type=\"submit\"]#content_1_ButtonNext")]
        public IWebElement nextButtonElement;

        [FindsBy(How = How.Id, Using = "content_1_InputCustomerChoiceNew")]
        public IWebElement CreateNewCustomerElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;

    }

}
