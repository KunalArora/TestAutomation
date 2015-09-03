using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ActionsModule
    {
        private const string ConvertToContractButton = @".open .js-mps-convert";
        private const string ProposalEditButton = @".open .js-mps-edit";
        private const string ProposalDeleteButton = @".open .js-mps-delete";
        private const string SendToBankButton = @".open ul.dropdown-menu .js-mps-send-to-approver";
        private const string OpenOfferViewSummaryButton = @".open ul.dropdown-menu .js-mps-view-summary";
        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";
        private const string PreInstallationButton = @".open ul.dropdown-menu .js-mps-pre-installation";
        private const string MaintainOfferButton = @".open ul.dropdown-menu .js-mps-maintain-offer";
        private const string ProposalCopyElement = @".open .js-mps-copy";
        private const string ProposalCopyElementWithCustomer = @".open .js-mps-copy-with-customer";
        private const string ContractDownloadPDF = @".open .js-mps-download-contract-pdf";
        private const string ContractDownloadInvoicePDF = @".open .js-mps-download-contract-invoice-pdf";


        private static IWebElement CopyProposalButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProposalCopyElement));
        }

        private static IWebElement CopyProposalWithCustomerButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProposalCopyElementWithCustomer));
        }

        public static IWebElement ConvertButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ConvertToContractButton));
        }

        private static IWebElement MaintainOfferElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(MaintainOfferButton));
        }

        private static IWebElement DownloadContractPDFElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ContractDownloadPDF));
        }

        private static IWebElement DownloadContractInvoicePDFElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ContractDownloadInvoicePDF));
        }

        private static IWebElement PreInstallationElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(PreInstallationButton));
        }

        private static IWebElement OpenOfferViewSummaryElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(OpenOfferViewSummaryButton));
        }

        private static IWebElement ProposalEditButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProposalEditButton));
        }

        private static IWebElement ProposalDeleteButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProposalDeleteButton));
        }
        private static IList<IWebElement> SendToBankButtonElement(ISearchContext driver)
        {
            return driver.FindElements(By.CssSelector(SendToBankButton));
        }

        private static IList<IWebElement> ActionsDropdownElement(ISearchContext driver)
        {

            var actionsElement = driver.FindElements(By.CssSelector(actionsButton));
            return actionsElement;
        }

        public static void DownloadContractPDFAction(IWebDriver driver)
        {
            var action = DownloadContractPDFElement(driver);
            action.Click();
            
        }

        public static void DownloadContractInvoicePDFAction(IWebDriver driver)
        {
            var action = DownloadContractInvoicePDFElement(driver);
            action.Click();

        }

        

        public static IWebElement SpecificActionsDropdownElement(ISearchContext driver)
        {

            var actionsElement = driver.FindElement(By.XPath(ProposalCreatedActionButton()));
            return actionsElement;
        }

        private static string ProposalCreatedActionButton()
        {
            return String.Format("//td[text()='{0}']/parent::tr/td[6]/div/button", 
                MpsUtil.CreatedProposal());
        }

        private static string ContractApprovedProposalActionButton()
        {
            return String.Format("//td[text()='{0}']/parent::tr/td[9]/div/button", 
                MpsUtil.CreatedProposal());
        }

        private static string DeclinedProposalActionButton()
        {
            return String.Format("//td[text()='{0}']/parent::tr/td[7]/div/button", 
                MpsUtil.CreatedProposal());
        }

        private static string ProposalCopiedActionButton()
        {
            return String.Format("//td[text()='{0}']/parent::tr/td[6]/div/button", 
                MpsUtil.CopiedProposal());
        }

        private static string ProposalCustomer()
        {
            return String.Format("//td[text()='{0}']/parent::tr/td[4]", 
                MpsUtil.CopiedProposal());
        }

        public static IWebElement ProposalCustomerColumn(IWebDriver driver)
        {
            var actionsElement = driver.FindElement(By.XPath(ProposalCustomer()));
            return actionsElement;
        }

        public static IWebElement DeclinedProposalActionDropdown(IWebDriver driver)
        {
            var actionsElement = driver.FindElement(By.XPath(DeclinedProposalActionButton()));
            return actionsElement;
        }

        public static IWebElement ContractApprovedProposalActionDropdown(IWebDriver driver)
        {
            var actionsElement = driver.FindElement(By.XPath(ContractApprovedProposalActionButton()));
            return actionsElement;
        }


        public static IWebElement CopiedProposalActionButton(IWebDriver driver)
        {
            var actionsElement = driver.FindElement(By.XPath(ProposalCopiedActionButton()));
            return actionsElement;
        }

        public static void ClickOnSpecificCopiedProposalActionsDropdown(IWebDriver driver)
        {
            var actionsElement = CopiedProposalActionButton(driver);
            actionsElement.Click();
        }

        public static void ClickOnSpecificContractApprovedProposalActionsDropdown(IWebDriver driver)
        {
            var actionsElement = ContractApprovedProposalActionDropdown(driver);
            actionsElement.Click();
        }

        public static void ClickOnSpecificDeclinedProposalActionsDropdown(IWebDriver driver)
        {
            var actionsElement = DeclinedProposalActionDropdown(driver);
            actionsElement.Click();
        }

        public static void SpecificClickOnTheActionsDropdown(IWebDriver driver)
        {
            SeleniumHelper.WaitForElementToExistByCssSelector(ProposalCreatedActionButton());
            var actionsElement = SpecificActionsDropdownElement(driver);
            actionsElement.Click();
        }

        public static void ClickOnTheActionsDropdown(IWebDriver driver)
        {
            var actionsElement = ActionsDropdownElement(driver);
            actionsElement.Last().Click();
        }

        public static void ClickOnTheActionsDropdown(int index, IWebDriver driver)
        {
            var actionsElement = ActionsDropdownElement(driver);
            actionsElement.ElementAt(index).Click();
        }

        public static void CopyAProposal(IWebDriver driver)
        {
            var copyButton = CopyProposalButtonElement(driver);
            copyButton.Click();
        }

        public static void CopyAProposalWithCustomer(IWebDriver driver)
        {
            var copyButton = CopyProposalWithCustomerButtonElement(driver);
            copyButton.Click();
        }

        public static void NavigateToPreInstallationScreen(IWebDriver driver)
        {
            var actionsElement = PreInstallationElement(driver);
            actionsElement.Click();
           
        }

        public static void NavigateToMaintainOfferScreen(IWebDriver driver)
        {
            var actionsElement = MaintainOfferElement(driver);
            actionsElement.Click();
            
        }

        public static void StartConvertToContractProcess(IWebDriver driver)
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(driver, ConvertButtonElement(driver));
        }

        public static void NavigateToSummaryPageUsingActionButton(IWebDriver driver)
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(driver, OpenOfferViewSummaryElement(driver));
        }

        public static void StartTheProposalEditProcess(IWebDriver driver)
        {
            ProposalEditButtonElement(driver).Click();
        }
        public static void DeleteAProposal(IWebDriver driver)
        {
            ProposalDeleteButtonElement(driver).Click();
        }
        public static void SendProposalToBankButton(IWebDriver driver)
        {
            SendToBankButtonElement(driver).Last().Click();
        }
    }
}
