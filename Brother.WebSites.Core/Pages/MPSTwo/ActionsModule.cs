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
        private const string ActionButtion = @".js-mps-filter-ignore [type='button']";


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

        private static IList<IWebElement> AllActionsButton(ISearchContext driver)
        {
            return driver.FindElements(By.CssSelector(ActionButtion));
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

        public static IWebElement SearchFieldFucntionality(IWebDriver driver)
        {
            var element = driver.FindElement(By.Id("content_1_ProposalListFilter_InputFilterBy"));
            return element;
        }

        public static void SearchForNewProposal(IWebDriver driver)
        {
            var searchField = SearchFieldFucntionality(driver);
            searchField.SendKeys(MpsUtil.CreatedProposal());
            searchField.SendKeys(Keys.Tab);
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }
        

        public static IWebElement SpecificActionsDropdownElement()
        {

            var actionsElement = SeleniumHelper.FindElementByJs(ProposalCreatedActionButton());
            return actionsElement;
        }

        public static IWebElement InstallerPinElement()
        {

            var actionsElement = SeleniumHelper.FindElementByJs(GeneratedPinForInstallation());
            return actionsElement;
        }

        public static IWebElement SpecificCustomerActionsDropdownElement()
        {

            var actionsElement = SeleniumHelper.FindElementByJs(CreatedEmailActionButton());
            return actionsElement;
        }

        public static void ClickOnSpecificActionsElement()
        {
            if (SpecificActionsDropdownElement() != null)
                SpecificActionsDropdownElement().Click();
        }

        public static void ClickOnSpecificCustomerActionsElement()
        {
            if (SpecificCustomerActionsDropdownElement() != null)
                SpecificCustomerActionsDropdownElement().Click();
        }

        public static bool IsClosedProposalDisplayed()
        {
            return SeleniumHelper.FindElementByJs(ProposalCreatedActionButton()).Displayed;
        }

        public static void OpenTheFirstActionButton(IWebDriver driver)
        {
            AllActionsButton(driver).First().Click();
        }

        private static string ProposalCreatedActionButton()
        {
            return String.Format("return $('td:contains(\"{0}\")').parent('tr').children('td').children('div').children('button')", 
                MpsUtil.CreatedProposal());
            // //div/table/tbody/tr/td[text()='{0}']/parent::tr/td[6]/div/button
        }

        private static string CreatedEmailActionButton()
        {
            return String.Format("return $('td:contains(\"{0}\")').parent('tr').children('td').children('div').children('button')",
                MpsUtil.CreatedEmail());
        }

        private static string GeneratedPinForInstallation()
        {
            return "return $(('#content_0_LabelPinForTool').parent().children('div'))";
        }

       
        private static string CopiedProposalCustomer()
        {
            return String.Format("//td[text()='{0}']/parent::tr/td[4]",
                MpsUtil.CopiedProposal());
        }

        public static IWebElement ProposalCustomerColumn(IWebDriver driver)
        {
            var actionsElement = driver.FindElement(By.XPath(CopiedProposalCustomer()));
            return actionsElement;
        }

        private static string CreatedProposalCustomer()
        {
            return String.Format("//td[text()='{0}']/parent::tr/td[4]",
                MpsUtil.CreatedProposal());
        }

        public static IWebElement CreatedProposalCustomerColumn(IWebDriver driver)
        {
            var actionsElement = driver.FindElement(By.XPath(CreatedProposalCustomer()));
            return actionsElement;
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
