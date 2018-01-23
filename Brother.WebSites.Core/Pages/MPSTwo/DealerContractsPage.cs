using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsPage : BasePage, IPageObject
    {
        public static string URL = "/mps/dealer/contracts";

        private const string _validationElementSelector = "a[href=\"/mps/dealer/contracts/accepted\"]"; //Accepted Contracts tab element

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        // Selectors
        private const string ContractFilterSelector = ".mps-filter-search-field-lg";
        private const string ContractsAcceptedActiveTabSelector = ".active a[href=\"/mps/dealer/contracts/accepted\"]";
        private const string PaginateSelector = ".dataTables_paginate";
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string ManageDevicesButtonSelector = ".js-mps-manage-devices";

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

        [FindsBy(How = How.CssSelector, Using = "[id*='content_1_ContractList_List_ContractName']")]
        public IList<IWebElement> newContractNameElement;
        [FindsBy(How = How.CssSelector, Using = "[id*='content_1_ContractList_List_LeadCodeReference']")]
        public IList<IWebElement> newContractReferenceElement;
        [FindsBy(How = How.CssSelector, Using = "li.active [href='/mps/dealer/contracts/awaiting-processing'] span")]
        public IWebElement contractAwaitingProcessingElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/contracts/confirmed-offers\"] span")]
        public IWebElement DealerConfirmedOfferTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSign")]
        public IWebElement DealerContractSignButtonElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/contracts/signed-offers\"] span")]
        public IWebElement DealerSignedOfferTabElement;
        [FindsBy(How = How.CssSelector, Using = "input[id*='content_1_Printers_InstalledPrinters_0_SerialNumber']")]
        public IList<IWebElement> printerSerialNumberFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement PreInstallationNextButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonCompletePreInstallation")]
        public IWebElement PreInstallationCompleteButtonElement;
        [FindsBy(How = How.CssSelector, Using = "label[id*='content_1_Printers_InstalledPrinters_0_SerialNumber']")]
        public IList<IWebElement> printerSerialNumberlabelElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href=\"/mps/dealer/contracts/rejected\"]")]
        public IWebElement RejectedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href=\"/mps/dealer/contracts/awaiting-acceptance\"]")]
        public IWebElement AwaitingAcceptanceTabElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href=\"/mps/dealer/contracts/accepted\"]")]
        public IWebElement AcceptedTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/contracts/approved-proposals\"]")]
        public IWebElement ApprovedProposalTabElement;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/contracts/approved-proposals\"]")]
        public IWebElement OpenedApprovedProposalTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_SimpleContractList_List_HeaderValidUntil")]
        public IWebElement ValidUntilLabelElement;
        
        
        
        
        public void IsContractScreenDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (OpenedApprovedProposalTabElement == null)
                throw new NullReferenceException("Contract Screen is not displayed");
            AssertElementPresent(OpenedApprovedProposalTabElement, "The opened contract screen");
        }

        public void VerifyRejectedContractIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsSignedContractDisplayed();
        }

        public void VerifyAcceptedContractIsNotDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = MpsUtil.CreatedProposal();
            
            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);
            IsNewContractTemplateCreated(false);
        }

        private string CreatedProposalReference()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = ScenarioContext.Current["GeneratedLeadCodeReference"].ToString();
            return createdProposal;
        }

        public void NavigateToConfirmedOfferScreen()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (DealerConfirmedOfferTabElement == null)
                throw new NullReferenceException("Confirmed Offer tab is not displayed");
            DealerConfirmedOfferTabElement.Click();
        }

        public void NavigateToRejectedOfferScreen()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (RejectedLinkElement == null)
                throw new NullReferenceException("Rejected Offer tab is not displayed");
            RejectedLinkElement.Click();
        }

        public void DealerSignNewContract(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            if (DealerContractSignButtonElement == null)
                throw new NullReferenceException("Sign button is not displayed");

            ActionsModule.ClickOnSpecificActionsElement(driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);

            DealerContractSignButtonElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            VerifyAcceptedContractIsNotDisplayed();

        }

        private void NavigateToSignedOfferScreen()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (DealerSignedOfferTabElement == null)
                throw new NullReferenceException("Signed Offer tab is not displayed");
            DealerSignedOfferTabElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }

       
        
        public void DownloadAContractPDF()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.OpenTheFirstActionButton(Driver);
            ActionsModule.DownloadContractPDFAction(Driver);
        }


        public void DownloadAContractInvoicePDF()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.DownloadContractInvoicePdfAction(Driver);
        }

        public void NavigateToAwaitingAcceptance()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (AwaitingAcceptanceTabElement == null)
                throw new Exception("Awaiting Acceptance Tab is not displayed");

            AwaitingAcceptanceTabElement.Click();
        }

        public DealerContractsAcceptedPage NavigateToAcceptedContract()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (AcceptedTabElement == null)
                throw new Exception("Accepted Tab is not displayed");


            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, AcceptedTabElement);

            return GetTabInstance<DealerContractsAcceptedPage>(Driver);
        }

        public void NavigateToRejectedContract()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (RejectedLinkElement == null)
                throw new Exception("Rejected Tab is not displayed");

            RejectedLinkElement.Click();
        }

        private void EnterSerialNumber()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (printerSerialNumberFieldElement == null)
                throw new NullReferenceException("Serial numbers fields not displayed");

            foreach (var serialNumber in printerSerialNumberFieldElement)
            {
                ScrollTo(serialNumber);
                serialNumber.Click();
                serialNumber.SendKeys("C2J298543");
                serialNumber.SendKeys(Keys.Tab);
            }

            printerSerialNumberlabelElement.First().Click();
            
        }

        private void MoveToPreInstallationSummary()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PreInstallationNextButtonElement == null)
                throw new NullReferenceException("Next button not visible");
            PreInstallationNextButtonElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

        private void CompletePreInstallation()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PreInstallationCompleteButtonElement == null)
                throw new NullReferenceException("Complete Installation button not visible");

            PreInstallationCompleteButtonElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

        private IWebElement ActionButtonElementByName(string name, string tdcol)
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = String.Format("//td[text()=\"{0}\"]/parent::tr/td[{1}]/div/button", name, tdcol);                

            return Driver.FindElement(By.XPath(element));
        }

        public DealerContractsSummaryPage NavigateToViewOfferOnApprovedProposalsTab()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<DealerContractsSummaryPage>(Driver);
        }

        public DealerContractsSummaryPage NavigateToViewSummaryOnRejectedTab()
        {
            LoggingService.WriteLogOnMethodEntry();
            string proposalname = "";
            foreach (KeyValuePair<string, object> pair in SpecFlow.GetEnumerator())
            {
                if (pair.Key.Equals("GeneratedProposalName"))
                {
                    proposalname = MpsUtil.CreatedProposal();                    
                }

            }

            // @TODO: ContextKey not found, so avoid it here. But this is not good solution.
            if (proposalname.Equals(string.Empty))
            {
                proposalname = Driver.FindElement(By.XPath("//td[contains(text(),'MPS_')]")).Text;
                SpecFlow.SetContext("GeneratedProposalName", proposalname);
                SpecFlow.SetContext("GeneratedLeadCodeReference", proposalname);
            }

            //IWebElement element = ActionButtonElementByName(proposalname, "8");
            //element.Click();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<DealerContractsSummaryPage>(Driver);
        }

        public void IsApprovedProposalContractPageDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ValidUntilLabelElement == null)
                throw new Exception("Contracts Approved Proposal page not opened");

            AssertElementPresent(ValidUntilLabelElement, "is Contracts Approved Proposal page?");
        }

        public DealerContractsSummaryPage NavigateToDealerContractSummaryPage(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            WebDriver.Wait(DurationType.Second, 3);
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
            return GetInstance<DealerContractsSummaryPage>(Driver);
        }

        
        public void IsAwaitingAcceptanceContractDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (AwaitingAcceptanceTabElement == null)
                throw new Exception("Opened Awaiting Acceptance Tab not displayed");
            AssertElementPresent(AwaitingAcceptanceTabElement, "Is Opened Awaiting Acceptance Tab displayed?");
        }

        public void IsSignedContractDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = MpsUtil.CreatedProposal();
            //var newlyAdded = @"//td[text()='{0}']";
            //newlyAdded = String.Format(newlyAdded, createdProposal);

            //var newProposal = Driver.FindElement(By.XPath(newlyAdded));

            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            //TestCheck.AssertIsEqual(true, newProposal.Displayed, "Is new signed contract displayed?");
            IsNewContractTemplateCreated(true);
        }


        public void IsNewContractTemplateCreated(bool option)
        {
            LoggingService.WriteLogOnMethodEntry(option);
            var proposal = GetElementByCssSelector(".js-mps-filter-ignore", 10).Displayed;

            TestCheck.AssertIsEqual(option, proposal,
                "Is new proposal template created?");
        }

        public void FilterContractUsingProposalId(int proposalId)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId);
            int findElementTimeout = RuntimeSettings.DefaultFindElementTimeout;
            var FilterContractInput = SeleniumHelper.FindElementByCssSelector(ContractFilterSelector, findElementTimeout);
            ClearAndType(FilterContractInput, proposalId.ToString());
        }

        public void MoveToAcceptedContracts()
        {
            LoggingService.WriteLogOnMethodEntry();
            int findElementTimeout = RuntimeSettings.DefaultFindElementTimeout;
            AcceptedTabElement.Click();
            SeleniumHelper.WaitUntilElementAppears(ContractsAcceptedActiveTabSelector, findElementTimeout);
            SeleniumHelper.WaitUntilElementAppears(PaginateSelector, findElementTimeout);
        }

        // Only for first contract displayed in list
        public void ClickOnManageDevicesButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            int findElementTimeout = RuntimeSettings.DefaultFindElementTimeout;
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(ActionsButtonSelector, findElementTimeout);
            ActionsButtonElement.Click();
            var ManageDeviceButtonElement = SeleniumHelper.FindElementByCssSelector(ManageDevicesButtonSelector, findElementTimeout);
            ManageDeviceButtonElement.Click();
        }
    }
}
