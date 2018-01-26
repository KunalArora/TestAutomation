using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementCreateTermAndTypePage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_InputUsageType_Input";
        private const string _url = "/mps/dealer/agreements/manage/term-type";

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
        [FindsBy(How = How.Id, Using = "content_1_InputUsageType_Input")]
        public IWebElement UsageTypeElement;

        [FindsBy(How = How.Id, Using = "content_1_InputContractLength_Input")]
        public IWebElement ContractLengthElement;

        [FindsBy(How = How.Id, Using = "content_1_InputServicePaymentOption_Input")]
        public IWebElement ServiceElement;

        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;

        public void SelectUsageType(string usage)
        {
            LoggingService.WriteLogOnMethodEntry(usage);
            SelectFromDropdown(UsageTypeElement, usage);
        }

        public void SelectContractLength(string contractLength)
        {
            LoggingService.WriteLogOnMethodEntry(contractLength);
            SelectFromDropdown(ContractLengthElement, contractLength);
        }

        public void SelectService(string service)
        {
            LoggingService.WriteLogOnMethodEntry(service);
            SelectFromDropdown(ServiceElement, service);
        }

        public void ValidateServicePackAvailableOptions(string resourceUsageTypePayAsYouGo, string resourceServiceTypeIncludedInClickPrice)
        {
            LoggingService.WriteLogOnMethodEntry(resourceUsageTypePayAsYouGo,resourceServiceTypeIncludedInClickPrice);
            SelectUsageType(resourceUsageTypePayAsYouGo);
            List<string> dropdownValues = SeleniumHelper.GetAllValuesOfDropdown(ServiceElement);
            if (dropdownValues.Exists(value => string.Equals(value, resourceServiceTypeIncludedInClickPrice, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Content could not be validated on Term & Type page");
            }
        }
    }
}

