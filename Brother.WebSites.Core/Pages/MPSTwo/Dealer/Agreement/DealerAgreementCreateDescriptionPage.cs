using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
{
    public class DealerAgreementCreateDescriptionPage : BasePage, IPageObject
    {
        /// <summary>
        /// 
        /// </summary>

        private const string _validationElementSelector = "#content_1_InputProposalName_Input";
        private const string _url = "/mps/dealer/agreements/manage/description?new=true";

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

        //WebElement properties
        [FindsBy(How = How.Id, Using = "content_1_InputProposalName_Input")]
        public IWebElement AgreementNameField;

        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;
    }
}
