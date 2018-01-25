using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementServiceRequestsCreatePage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".js-mps-create-service-request-raise";
        private const string _url = "/mps/dealer/agreement/{agreementId}/service-requests/create/?id={mpsDeviceId}"; // TODO: Replace agreementId & mpsDeviceId with dynamic parameters

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

        // Problem Description box
        [FindsBy(How = How.Id, Using = "content_1_InputSubject_Input")]
        public IWebElement SubjectInputElement;
        [FindsBy(How = How.Id, Using = "content_1_InputRequestType_Input")]
        public IWebElement RequestTypeDropdownElement;
        [FindsBy(How = How.Id, Using = "content_1_InputDescription_Input")]
        public IWebElement DescriptionInputElement;

        // Buttons
        [FindsBy(How = How.CssSelector, Using = ".js-mps-create-service-request-raise")]
        public IWebElement RaiseServiceRequestButtonElement;

        public string FillProblemDescription()
        {
            ClearAndType(SubjectInputElement, MpsUtil.ServiceRequestSubject());
            string requestType = SeleniumHelper.SelectDropdownElementTextByIndex(
                RequestTypeDropdownElement, new Random().Next(1, 7));
            SelectFromDropdown(RequestTypeDropdownElement, requestType);
            ClearAndType(DescriptionInputElement, MpsUtil.ServiceRequestDescription());

            return requestType;
        }
    }
}
