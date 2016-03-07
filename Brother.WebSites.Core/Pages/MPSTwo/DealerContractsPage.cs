using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsPage : BasePage
    {
        public static string URL = "/mps/dealer/contracts";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

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
            if (OpenedApprovedProposalTabElement == null)
                throw new NullReferenceException("Contract Screen is not displayed");
            AssertElementPresent(OpenedApprovedProposalTabElement, "The opened contract screen");
        }

        public void VerifyRejectedContractIsDisplayed()
        {
            IsSignedContractDisplayed();
        }

        public void VerifyAcceptedContractIsDisplayed()
        {
            var createdProposal = CreatedProposalReference();
            var newlyAdded = @"//td[text()='{0}']";
            newlyAdded = String.Format(newlyAdded, createdProposal);

            var newProposal = Driver.FindElement(By.XPath(newlyAdded));

            TestCheck.AssertIsEqual(true, newProposal.Displayed, "Is new proposal displayed");
        }

        public void VerifyAcceptedContractIsNotDisplayed()
        {
            var createdProposal = MpsUtil.CreatedProposal();
            
            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);
            IsNewContractTemplateCreated(false);
        }

        private static string CreatedProposalReference()
        {
            var createdProposal = ScenarioContext.Current["GeneratedLeadCodeReference"].ToString();
            return createdProposal;
        }

        public void NavigateToConfirmedOfferScreen()
        {
            if(DealerConfirmedOfferTabElement == null)
                throw new NullReferenceException("Confirmed Offer tab is not displayed");
            DealerConfirmedOfferTabElement.Click();
        }

        public void NavigateToRejectedOfferScreen()
        {
            if (RejectedLinkElement == null)
                throw new NullReferenceException("Rejected Offer tab is not displayed");
            RejectedLinkElement.Click();
        }

        public void DealerSignNewContract(IWebDriver driver)
        {
            if(DealerContractSignButtonElement == null)
                throw new NullReferenceException("Sign button is not displayed");

            ActionsModule.ClickOnSpecificActionsElement(driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);

            DealerContractSignButtonElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            VerifyAcceptedContractIsNotDisplayed();

        }

        private void NavigateToSignedOfferScreen()
        {
            if(DealerSignedOfferTabElement == null)
                throw new NullReferenceException("Signed Offer tab is not displayed");
            DealerSignedOfferTabElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }

       
        
        public void DownloadAContractPDF()
        {
            ActionsModule.OpenTheFirstActionButton(Driver);
            ActionsModule.DownloadContractPDFAction(Driver);
        }


        public void DownloadAContractInvoicePDF()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.DownloadContractInvoicePDFAction(Driver);
        }

        public void NavigateToAwaitingAcceptance()
        {
            if(AwaitingAcceptanceTabElement == null)
                throw new Exception("Awaiting Acceptance Tab is not displayed");

            AwaitingAcceptanceTabElement.Click();
        }

        public DealerContractsApprovedPage NavigateToAcceptedContract()
        {
            if (AcceptedTabElement == null)
                throw new Exception("Accepted Tab is not displayed");


            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, AcceptedTabElement);

            return GetTabInstance<DealerContractsApprovedPage>(Driver);
        }

        public void NavigateToRejectedContract()
        {
            if (RejectedLinkElement == null)
                throw new Exception("Rejected Tab is not displayed");

            RejectedLinkElement.Click();
        }

        private void EnterSerialNumber()
        {
            if(printerSerialNumberFieldElement == null)
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
            if(PreInstallationNextButtonElement == null)
                throw new NullReferenceException("Next button not visible");
            PreInstallationNextButtonElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

        private void CompletePreInstallation()
        {
            if(PreInstallationCompleteButtonElement == null)
                throw new NullReferenceException("Complete Installation button not visible");

            PreInstallationCompleteButtonElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

        private IWebElement ActionButtonElementByName(string name, string tdcol)
        {
            string element = String.Format("//td[text()=\"{0}\"]/parent::tr/td[{1}]/div/button", name, tdcol);                

            return Driver.FindElement(By.XPath(element));
        }

        public DealerContractsSummaryPage NavigateToViewOfferOnApprovedProposalsTab()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<DealerContractsSummaryPage>(Driver);
        }

        public DealerContractsSummaryPage NavigateToViewSummaryOnRejectedTab()
        {
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
            if (ValidUntilLabelElement == null)
                throw new Exception("Contracts Approved Proposal page not opened");

            AssertElementPresent(ValidUntilLabelElement, "is Contracts Approved Proposal page?");
        }

        public DealerContractsSummaryPage NavigateToDealerContractSummaryPage(IWebDriver driver)
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            WebDriver.Wait(DurationType.Second, 3);
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
            return GetInstance<DealerContractsSummaryPage>(Driver);
        }

        
        public void IsAwaitingAcceptanceContractDisplayed()
        {
            if (AwaitingAcceptanceTabElement == null)
                throw new Exception("Opened Awaiting Acceptance Tab not displayed");
            AssertElementPresent(AwaitingAcceptanceTabElement, "Is Opened Awaiting Acceptance Tab displayed?");
        }

        public void IsSignedContractDisplayed()
        {
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
            var proposal = GetElementByCssSelector(".js-mps-filter-ignore", 10).Displayed;

            TestCheck.AssertIsEqual(option, proposal,
                "Is new proposal template created?");
        }
    }
}
