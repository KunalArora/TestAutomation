using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.MPSTwo
{
    public class CloudExistingProposalPage : BasePage
    {
        public static string URL = "/mps/proposals/in-progress";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string proposalTableColumn = @".js-mps-delete-remove td";
        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";

        [FindsBy(How = How.CssSelector, Using = "li.separator a[href=\"/mps/proposals/create?new=true\"]")]
        private IWebElement NewProposalButton;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/proposals/templates\"] span")]
        private IWebElement ProposalListTemplateScreenElement;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/proposals/in-progress\"] span")]
        private IWebElement ProposalListProposalsScreenElement;
        [FindsBy(How = How.CssSelector, Using = "tr.js-mps-delete-remove td")]
        private IList<IWebElement> ProposalListProposalNameElement;
        [FindsBy(How = How.Id, Using = "content_1_ProposalListFilter_InputFilterBy")]
        private IWebElement ProposalFilter;
        [FindsBy(How = How.CssSelector, Using = ".panel-default .panel-body [class='col-sm-3']")]
        private IList<IWebElement> ProposalName;
        [FindsBy(How = How.Id, Using = "content_1_InputEnvisagedStartDate_Input")]
        private IWebElement ProposedStartDate;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveAsContract")]
        private IWebElement SaveAsContractButton;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/proposals/ready-for-approver\"] span")]
        private IWebElement SendToBankScreenElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/proposals/in-progress']")]
        private IWebElement InActiveProposalListProposalsScreenElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/customer-information\"]")]
        private IWebElement customerInformationTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/description\"]")]
        private IWebElement proposalDescriptionTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/term-type\"]")]
        private IWebElement termsAndTypeTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/products\"]")]
        private IWebElement productsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/summary\"]")]
        private IWebElement proposalSummaryTabElement;

        
        

        public void IsProposalFilterDiplayed()
        {
            if (ProposalFilter == null)
            {
                throw new NullReferenceException("Unable to locate text on the page");
            }
            AssertElementPresent(ProposalFilter, "Search box for proposal list");
        }

        public void IsSendToBankScreenDiplayed()
        {
            if (SendToBankScreenElement == null)
            {
                throw new NullReferenceException("Unable to locate send to bank element on the page");
            }
            AssertElementPresent(SendToBankScreenElement, "Send To Bar Tab element");
        }

        public void IsProposalListTemplateScreenDiplayed()
        {
            if (ProposalListTemplateScreenElement == null)
            {
                throw new NullReferenceException("Unable to locate text on the page");
            }
            AssertElementPresent(ProposalListTemplateScreenElement, "Confirm that proposal list template screen is displayed");
            AssertElementPresent(ProposalFilter, "Search box for proposal list");
        }

        public void IsProposalListProposalScreenDiplayed()
        {
            if (ProposalListProposalsScreenElement == null)
            {
                throw new NullReferenceException("Unable to locate text on the page");
            }
            AssertElementPresent(ProposalListProposalsScreenElement, "Confirm that proposal list proposal screen is displayed");
            AssertElementPresent(ProposalFilter, "Search box for proposal list");
        }

        public CreateNewProposalPage ClickOnNewProposalTab()
        {
            NewProposalButton.Click();
            return GetTabInstance<CreateNewProposalPage>(Driver);
        }


        public void IsNewProposalTemplateCreated()
        {
            var createdProposal = CreatedProposal();
            var newlyAdded = @"//td[text()='{0}']";
            newlyAdded = String.Format(newlyAdded, createdProposal);

            var newProposal = Driver.FindElement(By.XPath(newlyAdded));

            TestCheck.AssertIsEqual(true, newProposal.Displayed, "Is new proposal template created?");
        }

        public void IsProposalSuccessfullySentToBank()
        {
            var createdProposal = CreatedProposal();
            var proposalContainer = new ArrayList();
            var proposalItems = ProposalItemsElements(proposalTableColumn);

            foreach (var propopsalItem in proposalItems)
            {
                proposalContainer.Add(propopsalItem);
            }

            TestCheck.AssertIsEqual(false, proposalContainer.Contains(createdProposal), "Is proposal successfully sent to bank?");

            // var newlyAdded = @"//td[text()='{0}']";
            // newlyAdded = String.Format(newlyAdded, createdProposal);

            //// var newProposal = Driver.FindElement(By.XPath(newlyAdded));

            // Assert.IsNull(Driver.FindElement(By.XPath(newlyAdded)), 
            //     "The proposal " + createdProposal + " is still displayed on In-Progress screen");


        }

        public void ClickOnActionButtonAgainstRelevantProposal()
        {
            var actionsElement = ActionsDropdownElement(actionsButton);
            ScrollTo(actionsElement.Last());
            actionsElement.Last().Click();
        }

        private ReadOnlyCollection<IWebElement> ActionsDropdownElement(string actionsButton)
        {
            var actionsElement = Driver.FindElements(By.CssSelector(actionsButton));
            return actionsElement;
        }

        private ReadOnlyCollection<IWebElement> ProposalItemsElements(string proposalTableColumn)
        {
            var proposalItems = Driver.FindElements(By.CssSelector(proposalTableColumn));
            return proposalItems;
        }

        private static string CreatedProposal()
        {
            var createdProposal = SpecFlow.GetContext("GeneratedProposalName");
            return createdProposal;
        }

        public void NavigateToConversionSummaryScreen(IWebDriver driver)
        {
            ActionsModule.NavigateToProposalSummary(driver);
            VerifyThatTheCorrectProposalOpened();

        }

        private void VerifyThatTheCorrectProposalOpened()
        {
            AssertElementText(ProposalName.First(), CreatedProposal(), "Verify proposal name is correct");
        }

        public void EnterProposedStartDateForContract()
        {
            if (ProposedStartDate == null) 
                throw new NullReferenceException("Contract start date field not displayed");
            ProposedStartDate.SendKeys(MpsUtil.SomeDaysFromToday());
            
        }

        

        public void SaveProposalAsAContract()
        {
            if(SaveAsContractButton == null) 
                throw new NullReferenceException("Save Contract button not available");
            SaveAsContractButton.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
            IsSendToBankScreenDiplayed();

        }

        public void IsTheProposalSuccessfullyConverted()
        {
            IsNewProposalTemplateCreated();
        }

        public SendToBankPage StartSendToBankProcess(IWebDriver driver)
        {
            var actionsElement = ActionsDropdownElement(actionsButton);
            actionsElement.Last().Click();
            ActionsModule.SendProposalToBankButton(driver);
            return GetInstance<SendToBankPage>(Driver);
        }

        public CreateNewProposalPage ClickOnProposalTabsDuringContractConversionTransform(string tab)
        {
            //Use this method only if the workflow goes 
            //from conversion summary screen to any other proposal screens
            switch (tab)
            {
                case "Customer Information":
                    customerInformationTabElement.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Term & Type":
                    termsAndTypeTabElement.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Products":
                    productsTabElement.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Proposal Description":
                    proposalDescriptionTabElement.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
            }
            return GetInstance<CreateNewProposalPage>(Driver);

        }

        private CreateNewProposalPage ClickOnProductsPage()
        {
            productsTabElement.Click();
            return GetInstance<CreateNewProposalPage>(Driver);
        }

    }
}
