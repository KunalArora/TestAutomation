using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Pages.MPSTwo;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace BrotherWebSitesCore.Pages.MPSTwo
{
    public class CloudContractPage : BasePage
    {
        public static string URL = "/mps/dealer/contract";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "[id*='content_1_ContractList_List_ContractName']")]
        private IList<IWebElement> newContractNameElement;
        [FindsBy(How = How.CssSelector, Using = "[id*='content_1_ContractList_List_LeadCodeReference']")]
        private IList<IWebElement> newContractReferenceElement;
        [FindsBy(How = How.CssSelector, Using = "li.active [href='/mps/dealer/contracts/awaiting-processing'] span")]
        private IWebElement contractAwaitingProcessingElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/contracts/confirmed-offers\"] span")]
        private IWebElement DealerConfirmedOfferTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSign")]
        private IWebElement DealerContractSignButtonElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/contracts/signed-offers\"] span")]
        private IWebElement DealerSignedOfferTabElement;
        [FindsBy(How = How.CssSelector, Using = "input[id*='content_1_Printers_InstalledPrinters_0_SerialNumber']")]
        private IList<IWebElement> printerSerialNumberFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        private IWebElement PreInstallationNextButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonCompletePreInstallation")]
        private IWebElement PreInstallationCompleteButtonElement;
        [FindsBy(How = How.CssSelector, Using = "label[id*='content_1_Printers_InstalledPrinters_0_SerialNumber']")]
        private IList<IWebElement> printerSerialNumberlabelElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/contracts/rejected-offers\"] span")]
        private IWebElement DealerRejectOfferTabElement;
        
        
        
        public void IsContractScreenDisplayed()
        {
            if(contractAwaitingProcessingElement == null)
                throw new NullReferenceException("Contract Screen is not displayed");
            AssertElementPresent(contractAwaitingProcessingElement, "The opened contract screen");
        }

        public void VerifyRejectedContractIsDisplayed()
        {
            VerifyAcceptedContractIsDisplayed();
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
            var createdProposal = CreatedProposalReference();
            var expectedContractContainer = new ArrayList();

            foreach (var reference in newContractReferenceElement)
            {
                expectedContractContainer.Add(reference.Text);
            }

            TestCheck.AssertIsEqual(false, expectedContractContainer.Contains(createdProposal), "Accepted Contract is not displayed");
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
            if (DealerRejectOfferTabElement == null)
                throw new NullReferenceException("Rejected Offer tab is not displayed");
            DealerRejectOfferTabElement.Click();
        }

        public void DealerSignNewContract(IWebDriver driver)
        {
            if(DealerContractSignButtonElement == null)
                throw new NullReferenceException("Sign button is not displayed");

            ActionsModule.ClickOnTheActionsDropdown(driver);
            ActionsModule.NavigateToBankContractSummary(driver);

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

        public void DealerCompletePreInstallationProcess(IWebDriver driver)
        {
            NavigateToSignedOfferScreen();
            VerifyAcceptedContractIsDisplayed();

            ActionsModule.ClickOnTheActionsDropdown(driver);
            ActionsModule.NavigateToPreInstallationScreen(driver);
           
            EnterSerialNumber();
            MoveToPreInstallationSummary();
            CompletePreInstallation();

            IsContractScreenDisplayed();
            
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
        
    }
}
