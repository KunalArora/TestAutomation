using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsAcceptedPage : BasePage, IPageObject
    {
        public static string URL = "/mps/dealer/contracts";
        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/contracts/accepted\"]";

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
                return URL;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-manage-devices")]
        public IWebElement ManageDevicesElement;

        private const string SearchFieldSelector = ".js-mps-filter-search-field";
        private const string ActionsButtonSelector = ".btn.btn-primary.btn-xs.dropdown-toggle";
        private const string ManageDevicesSelector = ".js-mps-manage-devices";
       
        public void NavigateToSpecificManageDevicesPage(int proposalId, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, findElementTimeout);
            if (ManageDevicesElement == null)
                throw new Exception("Manage Device Element is not displayed");

            var SearchFieldElement = SeleniumHelper.FindElementByCssSelector(SearchFieldSelector, findElementTimeout);
            ClearAndType(SearchFieldElement, proposalId.ToString());
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(ActionsButtonSelector, findElementTimeout);
            ActionsButtonElement.Click();
            var ManageDevicesAction = SeleniumHelper.FindElementByCssSelector(ManageDevicesSelector, findElementTimeout);
            ScrollTo(ManageDevicesAction);
            ManageDevicesAction.Click();
        }

        public DealerManageDevicesPage NavigateToManageDevicesPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ManageDevicesElement == null)
                throw new Exception("Manage Device Element is not displayed");

            ActionsModule.ClickOnSpecificActionsElement(Driver);
            
            ScrollTo(ManageDevicesElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ManageDevicesElement);
            MpsJobRunnerPage.RunCreateCustomerAndPersonCommandJob();
            return GetInstance<DealerManageDevicesPage>(Driver);
        }

        public DealerManageDevicesPage NavigateToManageDevicesPageToConfirmThatInstallationRequestAvailability()
        {
            LoggingService.WriteLogOnMethodEntry();
            MpsJobRunnerPage.RunCompleteInstallationCommandJob(MpsUtil.CreatedProposal());
            MpsJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob(MpsUtil.CreatedProposal(), Locale);
            MpsJobRunnerPage.RunRefreshPrintCountsFromEmailCommandJob(Locale);
            WebDriver.Wait(DurationType.Second,  10);
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ScrollTo(ManageDevicesElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ManageDevicesElement);

            return GetInstance<DealerManageDevicesPage>();
        }
    
    }
}
