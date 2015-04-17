using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;

namespace BrotherWebSitesCore.Pages.MPSTwo
{
    public class ActionsModule
    {
        private const string ConvertButton = @".open .js-mps-convert";
        private const string ProposalEditButton = @".open .js-mps-edit";
        private const string ProposalDeleteButton = @".open .js-mps-delete";
        private const string SendToBankButton = @".open ul.dropdown-menu .js-mps-send-to-approver";
        private const string OpenOfferViewSummaryButton = @".open ul.dropdown-menu .js-mps-view-summary";
        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";
        private const string PreInstallationButton = @".open ul.dropdown-menu .js-mps-pre-installation";
        private const string MaintainOfferButton = @".open ul.dropdown-menu .js-mps-maintain-offer";

        
        


        private static IWebElement ConvertButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ConvertButton));
        }

        private static IWebElement MaintainOfferElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(MaintainOfferButton));
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

        public static void ClickOnTheActionsDropdown(IWebDriver driver)
        {
            var actionsElement = ActionsDropdownElement(driver);
            actionsElement.Last().Click();
        }

        public static void NavigateToPreInstallationScreen(IWebDriver driver)
        {
            var actionsElement = PreInstallationElement(driver);
            actionsElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

        public static void NavigateToMaintainOfferScreen(IWebDriver driver)
        {
            var actionsElement = MaintainOfferElement(driver);
            actionsElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

        public static void NavigateToProposalSummary(IWebDriver driver)
        {
            WebDriver.Wait(Helper.DurationType.Second, 5); //Wait for the Action pop up to appear
            ConvertButtonElement(driver).Click();
        }

        public static void NavigateToBankContractSummary(IWebDriver driver)
        {
            WebDriver.Wait(Helper.DurationType.Second, 5); //Wait for the Action pop up to appear
            OpenOfferViewSummaryElement(driver).Click();
            WebDriver.Wait(Helper.DurationType.Second, 5); //Wait for the page to load
        }

        public static void StartTheProposalEditProcess(IWebDriver driver)
        {
            WebDriver.Wait(Helper.DurationType.Second, 3); //Wait for the Action pop up to appear
            ProposalEditButtonElement(driver).Click();
        }
        public static void DeleteAProposal(IWebDriver driver)
        {
            WebDriver.Wait(Helper.DurationType.Second, 3); //Wait for the Action pop up to appear
            ProposalDeleteButtonElement(driver).Click();
        }
        public static void SendProposalToBankButton(IWebDriver driver)
        {
            WebDriver.Wait(Helper.DurationType.Second, 3); //Wait for the Action pop up to appear
            SendToBankButtonElement(driver).Last().Click();
        }
    }
}
