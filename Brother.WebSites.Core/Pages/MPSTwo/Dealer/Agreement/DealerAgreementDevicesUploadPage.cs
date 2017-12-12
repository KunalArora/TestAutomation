using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
{
    public class DealerAgreementDevicesUploadPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_InputExcel_Input";
        private const string _url = "/mps/dealer/agreement/{agreementId}/devices/upload"; // TODO: Replace agreementId with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url; 
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Web Elements
        [FindsBy(How = How.Id, Using = "content_1_InputExcel_Input")]
        public IWebElement ChooseFileElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonUpload")]
        public IWebElement UploadButtonElement;

    }
}
