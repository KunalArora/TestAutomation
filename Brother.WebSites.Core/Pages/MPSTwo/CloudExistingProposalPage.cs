using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CloudExistingProposalPage : BasePage
    {
        public static string URL = "/mps/proposals/in-progress";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string DealerDeletingItem = "DealerDeletingItem";


        private const string proposalTableColumn = @".js-mps-delete-remove td";
        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";
        private const string ProposalItemsSelecterFormat = "div.js-mps-proposal-list-container tr.js-mps-delete-remove";
        private const string ProposalNthItemSelecterFormat = "div.js-mps-proposal-list-container tr.js-mps-delete-remove:nth-child({0})";

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/dashboard\"]")]
        private IWebElement DashboradLink;
        [FindsBy(How = How.CssSelector, Using = "li.separator a[href=\"/mps/proposals/create?new=true\"]")]
        public IWebElement NewProposalButton;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/proposals/templates\"] span")]
        public IWebElement ProposalListTemplateScreenElement;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/proposals/in-progress\"] span")]
        public IWebElement ProposalListProposalsScreenElement;
        [FindsBy(How = How.CssSelector, Using = "tr.js-mps-delete-remove td")]
        public IList<IWebElement> ProposalListProposalNameElement;
        [FindsBy(How = How.Id, Using = "content_1_ProposalListFilter_InputFilterBy")]
        public IWebElement ProposalFilter;
        [FindsBy(How = How.CssSelector, Using = ".panel-default .panel-body [class='col-sm-3']")]
        public IList<IWebElement> ProposalName;
        [FindsBy(How = How.Id, Using = "content_1_InputEnvisagedStartDate_Input")]
        public IWebElement ProposedStartDate;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveAsContract")]
        public IWebElement SaveAsContractButton;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/proposals/ready-for-approver\"] span")]
        public IWebElement SendToBankScreenElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-delete")]
        public IList<IWebElement> AttachedProposalId;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/customer-information\"]")]
        public IWebElement customerInformationTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/description\"]")]
        public IWebElement proposalDescriptionTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/term-type\"]")]
        public IWebElement termsAndTypeTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/products\"]")]
        public IWebElement productsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/summary\"]")]
        public IWebElement proposalSummaryTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/declined\"] span")]
        public IWebElement proposalDeclinedTabElement;
        [FindsBy(How = How.CssSelector, Using = "div.js-mps-proposal-list-container>table")]
        public IWebElement proposalListContainerElement;
        private const string DealerLatestOperatingItemId = "DealerLatestOperatingItemId";
        private const string DealerLatestOperatingItemName = "DealerLatestOperatingItemName";
        private const string DealerLatestOperatingItemCustomer = "DealerLatestOperatingItemCustomer";
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable tr:first-child")]
        public IWebElement proposalTopItemElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/approved\"]")]
        public IWebElement approvedProposalsTabElement;
        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success.fade.in.mps-alert.js-mps-alert")]
        public IWebElement deleteConfirmationElement;
        
        
        
        
        

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

        public void NavigateToDeclinedProposalScreen()
        {
            if(proposalDeclinedTabElement == null)
                throw new Exception("Cannot fine Declined Tab");
            proposalDeclinedTabElement.Click();
        }

        public DealerProposalsRejectedPage NavigateToDeclinedProposalPage()
        {
            if (proposalDeclinedTabElement == null)
                throw new Exception("Cannot find Declined Tab");
            proposalDeclinedTabElement.Click();

            return GetInstance<DealerProposalsRejectedPage>();
        }

        public void IsProposalCopiedWithoutCustomer(IWebDriver driver)
        {
            TestCheck.AssertIsEqual(true, 
                ActionsModule.ProposalCustomerColumn(driver).Text.Equals("-"), 
                "Proposal was copied with customer detail");
        }

        public void IsProposalCopiedWithCustomer(IWebDriver driver)
        {
            TestCheck.AssertIsEqual(false,
                ActionsModule.ProposalCustomerColumn(driver).Text.Equals("-"),
                "Proposal was copied with customer detail");
        }

        public void IsNewProposalTemplateCreated()
        {
            var createdProposal = CreatedProposal();
            var newlyAdded = @"//td[text()='{0}']";
            newlyAdded = String.Format(newlyAdded, createdProposal);

            var newProposal = Driver.FindElement(By.XPath(newlyAdded));

            TestCheck.AssertIsEqual(true, newProposal.Displayed, 
                "Is new proposal template created?");
        }



        public void IsProposalSuccessfullyDeletedFromTheList()
        {
            WaitForElementToExistByCssSelector(".alert.alert-success.fade.in.mps-alert.js-mps-alert");

            var createdProposal = CreatedProposal();
            var proposalContainer = new ArrayList();
            var proposalItems = ProposalItemsElements(proposalTableColumn);

            foreach (var propopsalItem in proposalItems)
            {
                proposalContainer.Add(propopsalItem);
            }

            TestCheck.AssertIsEqual(false, proposalContainer.Contains(createdProposal), 
                "Is proposal successfully sent to bank?");
        }


        public void CopyAProposalWithoutCustomer(IWebDriver driver)
        {
            ActionsModule.CopyAProposal(driver);
            WebDriver.Wait(DurationType.Second, 5);
            IsProposalCopied();
         }

        public void CopyAProposalWithCustomer(IWebDriver driver)
        {
            ActionsModule.CopyAProposalWithCustomer(driver);
            IsProposalCopied();
        }

        public void IsProposalCopied()
        {
            var copiedProposal = MpsUtil.CopiedProposal();
            var newlyCopied = @"//td[text()='{0}']";
            newlyCopied = String.Format(newlyCopied, copiedProposal);

            var newlyCopiedProposal = Driver.FindElement(By.XPath(newlyCopied));

            AssertElementPresent(newlyCopiedProposal, "Newly Copied proposal is not displayed");
            
        }


        
        public void ClickOnActionButtonAgainstRelevantProposal()
        {
            ScrollTo(ActionsModule.SpecificActionsDropdownElement());
            ActionsModule.ClickOnSpecificActionsElement();
        }

        public void DeleteOpenProposal()
        {
            ScrollTo(ActionsModule.SpecificActionsDropdownElement());
            ActionsModule.ClickOnSpecificActionsElement();

            HeadlessDismissAlertOk();
            ActionsModule.DeleteAProposal(Driver);
            WebDriver.Wait(DurationType.Second, 2);
        }
        

        public void ClickOnActionButtonAgainstDeclinedProposal()
        {

            ScrollTo(ActionsModule.SpecificActionsDropdownElement());
            ActionsModule.ClickOnSpecificActionsElement();
            WebDriver.Wait(DurationType.Second, 2);
        }


        public void ClickOnActionButtonAgainstCopiedProposal()
        {
            ScrollTo(ActionsModule.SpecificActionsDropdownElement());
            ActionsModule.ClickOnSpecificActionsElement();
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

        public ConvertProposalCustomerInfo ClickOnConvertToContractButton(IWebDriver driver)
        {
            ActionsModule.StartConvertToContractProcess(driver);
            return GetTabInstance<ConvertProposalCustomerInfo>(Driver);

        }

        public ConvertProposalSummaryPage ClickOnConvertToContractButtonForCopiedProposalWithCustomer(IWebDriver driver)
        {
            ActionsModule.StartConvertToContractProcess(driver);
            //VerifyThatTheCorrectProposalOpened();
            return GetTabInstance<ConvertProposalSummaryPage>(Driver);

        }

        public DealerApprovedProposalPage NavigateToDealerApprovedProposalPage()
        {
            approvedProposalsTabElement.Click();
            return GetTabInstance<DealerApprovedProposalPage>(Driver);
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

        public void ClickOnEditOnActionItem()
        {
            ActionsModule.ClickOnSpecificActionsElement();
            ActionsModule.StartTheProposalEditProcess(Driver);
        }

        private IWebElement GetNthProposalOfferElement(IWebDriver driver, int nth = 1)
        {
            var format = string.Format(ProposalNthItemSelecterFormat, nth);
            return driver.FindElement(By.CssSelector(format));
        }

        private IWebElement GetNewlyCreatedProposalOfferElement(IWebDriver driver)
        {
            var created = CreatedProposal();
            return
                driver.FindElements(By.CssSelector(ProposalItemsSelecterFormat))
                .Reverse()
                .First(x => x.FindElements(By.CssSelector("td"))
                             .Select(y => y.Text)
                             .Contains(created));
        }

        private IWebElement GetProposalOfferWithoutCustomerElement(IWebDriver driver)
        {
            return
                driver.FindElements(By.CssSelector(ProposalItemsSelecterFormat))
                .First(x => x.FindElement(By.CssSelector("td:nth-child(4)")).Text == "-");
        }

        private IWebElement GetProposalOfferWithCustomerElement(IWebDriver driver)
        {
            return
                driver.FindElements(By.CssSelector(ProposalItemsSelecterFormat))
                .First(x => x.FindElement(By.CssSelector("td:nth-child(4)")).Text != "-");
        }

        private void ClickActionButtonOnOffer(IWebElement offerElement)
        {
            var actionitem = offerElement.FindElement(By.CssSelector(actionsButton));
            actionitem.Click();
        }

        public void ClickOnDeleteOnActionItem(IWebDriver driver)
        {
            var offer = GetNthProposalOfferElement(driver);
            ClickActionButtonOnOffer(offer);
            var deleteElem = offer.FindElement(By.CssSelector(".js-mps-delete"));
            var id = deleteElem.GetAttribute("data-proposal-id");
            SpecFlow.SetContext(DealerLatestOperatingItemId, id);
            deleteElem.Click();
        }


        public void ClickOnDeleteOnActionItemAgainstNewlyCreated(IWebDriver driver)
        {
            var offer = GetNewlyCreatedProposalOfferElement(driver);
            ClickActionButtonOnOffer(offer);
            var deleteElem = offer.FindElement(By.CssSelector(".js-mps-delete"));
            var id = deleteElem.GetAttribute("data-proposal-id");
            SpecFlow.SetContext(DealerLatestOperatingItemId, id);
            deleteElem.Click();
        }

        public void ClickOnCopyOnActionItemWithoutCustomer(IWebDriver driver, string operation, string target)
        {
            IWebElement offer;
            if (target == "With")
            {
                offer = GetProposalOfferWithCustomerElement(driver);
            }
            else
            {
                offer = GetProposalOfferWithoutCustomerElement(driver);
            }

            string selector;
            if (operation == "With")
            {
                selector = ".js-mps-copy-with-customer";
            }
            else
            {
                selector = ".js-mps-copy";
            }

            ClickActionButtonOnOffer(offer);
            var copyElem = offer.FindElement(By.CssSelector(selector));
            var id = copyElem.GetAttribute("data-proposal-id");
            var name = offer.FindElement(By.CssSelector("td:nth-child(1)")).Text;
            var customer = offer.FindElement(By.CssSelector("td:nth-child(4)")).Text;
            SpecFlow.SetContext(DealerLatestOperatingItemId, id);
            SpecFlow.SetContext(DealerLatestOperatingItemName, name);
            SpecFlow.SetContext(DealerLatestOperatingItemCustomer, customer);
            copyElem.Click();
        }

        public void ExistsCopiedProposalOffer(IWebDriver driver, string operation)
        {
            WebDriver.Wait(DurationType.Millisecond, 4000);
            var name = SpecFlow.GetContext(DealerLatestOperatingItemName);
            var copiedOffer = FindCopiedPoposalOfferByName(driver, name);
            var copiedname = copiedOffer.FindElement(By.CssSelector("td:nth-child(1)")).Text;

            TestCheck.AssertIsNotNull(copiedname,
                "Copied Item does not exist on table.");

            var customer = SpecFlow.GetContext(DealerLatestOperatingItemCustomer);
            var copiedcustomer = copiedOffer.FindElement(By.CssSelector("td:nth-child(4)")).Text;

            if (operation == "With")
            {
                TestCheck.AssertIsEqual(customer, copiedcustomer, "CopyWithCustomer does not copy customer.");
            }
            else
            {
                TestCheck.AssertIsEqual("-", copiedcustomer, "CopyWithoutCustomer does not work.");
            }
        }

        private IWebElement FindCopiedPoposalOfferByName(IWebDriver driver, string name)
        {
            return
                driver.FindElements(By.CssSelector(ProposalItemsSelecterFormat))
                .Reverse()
                .First(x => x.FindElement(By.CssSelector("td:nth-child(1)")).Text.Contains(name));
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

        public void FindExistingPoposalList()
        {
            TestCheck.AssertIsNotNull(proposalListContainerElement,
                "Existing proposal table is not found.");
        }

        public void ClickAcceptOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 1000);
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert(driver);
        }

        public void ClickDismissOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 1000);
            HeadlessDismissAlertOk();
            ClickDismissOnJsAlert(driver);
        }

        public void NotExistTheDeletedItem(IWebDriver driver)
        {
            var id = SpecFlow.GetContext(DealerLatestOperatingItemId);
            var exisitng = ContainsItemById(driver, id);

            TestCheck.AssertIsEqual(false, exisitng,
                "Deleted Item still exists on table.");
        }

        public void ExistsNotDeletedItem(IWebDriver driver)
        {
            var id = SpecFlow.GetContext(DealerLatestOperatingItemId);
            var exisitng = ContainsItemById(driver, id);

            TestCheck.AssertIsEqual(true, exisitng,
                "Deleted Item does not exist on table.");
        }

        private static bool ContainsItemById(IWebDriver driver, string id)
        {
            return
                driver.FindElements(By.CssSelector(".js-mps-delete"))
                .Select(x => x.GetAttribute("data-proposal-id"))
                .Contains(id);
        }

        public DealerDashBoardPage NavigateToDashboard(IWebDriver driver)
        {
            DashboradLink.Click();
            return GetInstance<DealerDashBoardPage>();
        }

        public DealerProposalsCreateDescriptionPage NavigateToEditProposalPage()
        {
            return GetTabInstance<DealerProposalsCreateDescriptionPage>(Driver);
        }
        public void IsDuplicateProposalDisplayed()
        {
            var container = new List<string>();
            var noOfProposalId = AttachedProposalId.Count;


            for (var i = 0; i < AttachedProposalId.Count; i++)
            {
                ActionsModule.ClickOnTheActionsDropdown(i, Driver);
                var proposalId = AttachedProposalId.ElementAt(i).GetAttribute("data-proposal-id");

                container.Add(proposalId);

                ActionsModule.ClickOnTheActionsDropdown(i, Driver);
            }

            var numberOfDistinct = container.Distinct().Count();

            TestCheck.AssertIsEqual(true, noOfProposalId == (numberOfDistinct), "");
        }

    }
}
