﻿using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CloudExistingProposalPage : BasePage, IPageObject
    {
        public static string URL = "/mps/proposals/in-progress";
        private const string _validationElementSelector = "input#content_1_InProgressListActions_ActionList_Button_0"; //CreateProposal button

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

        
        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string DealerDeletingItem = "DealerDeletingItem";
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string SubmitForApprovalButtonSelector = ".js-mps-convert";




        private const string proposalTableColumn = @".js-mps-delete-remove td";
        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";
        private const string ProposalItemsSelecterFormat = "div.js-mps-proposal-list-container tr.js-mps-delete-remove";
        private const string ProposalNthItemSelecterFormat = "div.js-mps-proposal-list-container tr.js-mps-delete-remove:nth-child({0})";
        private const string ProposalFilterSelectorFormat = "#content_1_ProposalListFilter_InputFilterBy";
        private const string DataTablesFooterSelector = ".mps-dataTables-footer";
        private const string editActionButtonSelector = ".js-mps-edit";

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
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-copy-with-customer")]
        public IWebElement copyProposalWithCustomerElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-copy")]
        public IWebElement copyProposalWithoutCustomerElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InProgressListActions_ActionList_Button_0")]
        public IWebElement CreateNewProposalButtonElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/awaiting-approval\"]")]
        public IWebElement AwaitingProposalTabElement;
        [FindsBy(How = How.CssSelector, Using = "#DataTables_Table_0_next a")]
        public IWebElement DataTableNextButtonElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleProposalList_List_ProposalNameRow_]")]
        public IList<IWebElement> ProposalListProposalNameRowElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/declined\"]")]
        public IWebElement declinedProposalsTabElement;
        
        
        
        
        
        

        public DealerProposalsCreateDescriptionPage NavigateToProposalsCreateDescriptionPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CreateNewProposalButtonElement == null)
                throw new Exception("Create a new proposal button is not displayed");

            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, CreateNewProposalButtonElement);
            return GetInstance<DealerProposalsCreateDescriptionPage>();
        }


        public DealerProposalsAwaitingApprovalPage NavigateToProposalsAwaitingApproval()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (AwaitingProposalTabElement == null)
                throw new Exception("Create a new proposal button is not displayed");

            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, AwaitingProposalTabElement);
            return GetInstance<DealerProposalsAwaitingApprovalPage>();
        }
        
        

        public void IsProposalFilterDiplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ProposalFilter == null)
            {
                throw new NullReferenceException("Unable to locate text on the page");
            }
            AssertElementPresent(ProposalFilter, "Search box for proposal list");
        }

        public void IsSendToBankScreenDiplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (SendToBankScreenElement == null)
            {
                throw new NullReferenceException("Unable to locate send to bank element on the page");
            }
            AssertElementPresent(SendToBankScreenElement, "Send To Bar Tab element");
        }

        public void IsProposalListTemplateScreenDiplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ProposalListTemplateScreenElement == null)
            {
                throw new NullReferenceException("Unable to locate text on the page");
            }
            AssertElementPresent(ProposalListTemplateScreenElement, "Confirm that proposal list template screen is displayed");
            AssertElementPresent(ProposalFilter, "Search box for proposal list");
        }

        public void IsProposalListProposalScreenDiplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ProposalListProposalsScreenElement == null)
            {
                throw new NullReferenceException("Unable to locate text on the page");
            }
            AssertElementPresent(ProposalListProposalsScreenElement, "Confirm that proposal list proposal screen is displayed");
            AssertElementPresent(ProposalFilter, "Search box for proposal list");
        }

        public void NavigateToDeclinedProposalScreen()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (proposalDeclinedTabElement == null)
                throw new Exception("Cannot fine Declined Tab");
            proposalDeclinedTabElement.Click();
        }

        public DealerProposalsDeclinedPage NavigateToDeclinedProposalPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (proposalDeclinedTabElement == null)
                throw new Exception("Cannot find Declined Tab");
            proposalDeclinedTabElement.Click();

            return GetInstance<DealerProposalsDeclinedPage>();
        }


        public void IsProposalCopiedWithoutCustomer()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true,
                ActionsModule.NumberOfActionButtonDisplayed(Driver).Equals(1),
                "Proposal was copied with customer detail");  

        }

        public void IsProposalCopiedWithCustomer()
        {
            LoggingService.WriteLogOnMethodEntry();
            var companyName = SpecFlow.GetContext("GeneratedCompanyName");

            ActionsModule.SearchForNewlyProposalItem(Driver, companyName);

            TestCheck.AssertIsEqual(true,
                ActionsModule.NumberOfActionButtonDisplayed(Driver).Equals(1),
                "Proposal was copied with customer detail");
        }

        public void IsNewProposalTemplateCreated()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = CreatedProposal();
            
            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            IsNewProposalTemplateCreated(true);
        }

        public void IsNewProposalTemplateCreated(bool option)
        {
            LoggingService.WriteLogOnMethodEntry(option);
           var proposal = GetElementByCssSelector(".js-mps-filter-ignore", 10).Displayed;

            TestCheck.AssertIsEqual(option, proposal,
                "Is new proposal template created?");
        }

        public void ActionButtonCount()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, GetElementByCssSelector(".dataTables_empty").Displayed, 
                                                                            "Is new proposal template created?");
        }


        public void IsProposalSuccessfullyDeletedFromTheList()
        {
            LoggingService.WriteLogOnMethodEntry();
            WaitForElementToExistByCssSelector(".alert.alert-success.fade.in.mps-alert.js-mps-alert");

            TestCheck.AssertIsEqual(true, GetElementByCssSelector(".alert.alert-success.fade.in.mps-alert.js-mps-alert").Displayed, 
                                                "Proposal was not deleted");

            //ActionsModule.SearchForNewProposal(Driver);

            //ActionButtonCount();
        }

        
        public void CopyAProposalWithoutCustomer(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            ActionsModule.CopyAProposal(driver);
            WebDriver.Wait(DurationType.Second, 5);
            IsProposalCopied();
         }

        public void CopyAProposalWithCustomer(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            ActionsModule.CopyAProposalWithCustomer(driver);
            IsProposalCopied();
        }

        public void IsProposalCopied()
        {
            LoggingService.WriteLogOnMethodEntry();
            var copiedProposal = MpsUtil.CopiedProposal();
            //var newlyCopied = @"//td[text()='{0}']";
            //newlyCopied = String.Format(newlyCopied, copiedProposal);

            ActionsModule.SearchForNewlyProposalItem(Driver, copiedProposal);

            //var newlyCopiedProposal = Driver.FindElement(By.XPath(newlyCopied));

            //AssertElementPresent(newlyCopiedProposal, "Newly Copied proposal is not displayed");

            IsNewProposalTemplateCreated(true);
            
        }


        
        public void ClickOnActionButtonAgainstRelevantProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            //var proposal = GetElementByCssSelector(".js-mps-filter-ignore", 10);

            ActionsModule.ClickOnSpecificActionsElement(Driver);

            //ScrollTo(proposal);
            //proposal.Click();
        }

        public void DeleteOpenProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);

            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
            ActionsModule.DeleteAProposal(Driver);
            WebDriver.Wait(DurationType.Second, 2);
        }
        

        public void ClickOnActionButtonAgainstDeclinedProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            WebDriver.Wait(DurationType.Second, 2);
        }


        public void ClickOnActionButtonAgainstCopiedProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnCopiedProposalActionsElement(Driver);
        }

        private ReadOnlyCollection<IWebElement> ActionsDropdownElement(string actionsButton)
        {
            LoggingService.WriteLogOnMethodEntry(actionsButton);
            var actionsElement = Driver.FindElements(By.CssSelector(actionsButton));
            return actionsElement;
        }

        private ReadOnlyCollection<IWebElement> ProposalItemsElements(string proposalTableColumn)
        {
            LoggingService.WriteLogOnMethodEntry(proposalTableColumn);
            var proposalItems = Driver.FindElements(By.CssSelector(proposalTableColumn));
            return proposalItems;
        }

        private string CreatedProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = SpecFlow.GetContext("GeneratedProposalName");
            return createdProposal;
        }

        public DealerConvertProposalCustomerInfo ClickOnConvertToContractButton(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            ActionsModule.StartConvertToContractProcess(driver);
            return GetTabInstance<DealerConvertProposalCustomerInfo>(Driver);

        }

        public DealerConvertProposalSummaryPage ClickOnConvertToContractButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.StartConvertToContractProcess(Driver);
            return GetTabInstance<DealerConvertProposalSummaryPage>(Driver);

        }

        public DealerConvertProposalSummaryPage ClickOnConvertToContractButtonForCopiedProposalWithCustomer(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            ActionsModule.StartConvertToContractProcess(driver);
            //VerifyThatTheCorrectProposalOpened();
            return GetTabInstance<DealerConvertProposalSummaryPage>(Driver);

        }

        public DealerApprovedProposalPage NavigateToDealerApprovedProposalPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            approvedProposalsTabElement.Click();
            return GetTabInstance<DealerApprovedProposalPage>(Driver);
        }

        public void ClickOnEditOnActionItem()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.StartTheProposalEditProcess(Driver);
        }

        private IWebElement GetNthProposalOfferElement(IWebDriver driver, int nth = 1)
        {
            LoggingService.WriteLogOnMethodEntry(driver, nth);
            var format = string.Format(ProposalNthItemSelecterFormat, nth);
            return driver.FindElement(By.CssSelector(format));
        }

        private IWebElement GetNewlyCreatedProposalOfferElement(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
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
            LoggingService.WriteLogOnMethodEntry(driver);
            return
                driver.FindElements(By.CssSelector(ProposalItemsSelecterFormat))
                .First(x => x.FindElement(By.CssSelector("td:nth-child(4)")).Text == "-");
        }

        private IWebElement GetProposalOfferWithCustomerElement(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            return
                driver.FindElements(By.CssSelector(ProposalItemsSelecterFormat))
                .First(x => x.FindElement(By.CssSelector("td:nth-child(4)")).Text != "-");
        }

        private void ClickActionButtonOnOffer(IWebElement offerElement)
        {
            LoggingService.WriteLogOnMethodEntry(offerElement);
            var actionitem = offerElement.FindElement(By.CssSelector(actionsButton));
            actionitem.Click();
        }

        public void CopyProposalWithOptions(string option)
        {
            LoggingService.WriteLogOnMethodEntry(option);
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.ClickOnTheActionsDropdown(0, Driver);
            //var originCustomer = ActionsModule.CreatedProposalCustomerColumn().Text;
            //SpecFlow.SetContext("Original Customer", originCustomer);

            if (option.Equals("Without"))
            {
                ActionsModule.CopyAProposal(Driver);
                WebDriver.Wait(DurationType.Second, 5);
            } else if(option.Equals("With"))
            {
                ActionsModule.CopyAProposalWithCustomer(Driver);
                WebDriver.Wait(DurationType.Second, 5);
            }
        }

        public void IsProposalCustomerCopied()
        {
            LoggingService.WriteLogOnMethodEntry();
            //var copiedProposalCustomer = SpecFlow.GetContext("Original Customer");
            //var displayedCopiedCustomer = ActionsModule.ProposalCustomerColumn().Text;

            //TestCheck.AssertIsEqual(copiedProposalCustomer, displayedCopiedCustomer, 
            //    "customer in copied proposal not equal to customer in original proposal");

            ActionsModule.IsNewlyCopiedItemDisplayed(Driver);
        }

        public void ClickOnDeleteOnActionItem(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            var offer = GetNthProposalOfferElement(driver);
            ClickActionButtonOnOffer(offer);
            var deleteElem = offer.FindElement(By.CssSelector(".js-mps-delete"));
            var id = deleteElem.GetAttribute("data-proposal-id");
            SpecFlow.SetContext(DealerLatestOperatingItemId, id);
            deleteElem.Click();
        }

        public void AcceptConfirmationOnWarning()
        {
            LoggingService.WriteLogOnMethodEntry();
            HeadlessDismissAlertOk();
        }

        public void DismissWarningMessage()
        {
            LoggingService.WriteLogOnMethodEntry();
            HeadlessDismissAlertCancel();
        }


        public void ClickOnDeleteOnActionItemAgainstNewlyCreated(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            //var offer = GetNewlyCreatedProposalOfferElement(driver);
            //ClickActionButtonOnOffer(offer);
            //var deleteElem = offer.FindElement(By.CssSelector(".js-mps-delete"));
            //var id = deleteElem.GetAttribute("data-proposal-id");
            //SpecFlow.SetContext(DealerLatestOperatingItemId, id);
            //deleteElem.Click();

            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.DeleteAProposal(driver);
        }

        public void ClickOnCopyOnActionItemWithoutCustomer(IWebDriver driver, string operation, string target)
        {
            LoggingService.WriteLogOnMethodEntry(driver, operation, target);
            IWebElement offer = null;
            string selector;
            var displayed = false;
            var tryCount = 0;

            while (displayed != true)
            {
                try
                {
                    offer = target == "With" ? GetProposalOfferWithCustomerElement(driver) : GetProposalOfferWithoutCustomerElement(driver);
                    displayed = offer.Displayed;
                }
                catch (InvalidOperationException)
                {

                    DataTableNextButtonElement.Click();
                }

                tryCount++;
            }
           
            if (operation == "With")
            {
                selector = ".js-mps-copy-with-customer";
            }
            else
            {
                selector = ".js-mps-copy";
            }

            ClickActionButtonOnOffer(offer);

            if (offer != null)
            {
                var copyElem = offer.FindElement(By.CssSelector(selector));
                var id = copyElem.GetAttribute("data-proposal-id");
                var name = offer.FindElement(By.CssSelector("td:nth-child(1)")).Text;
                var customer = offer.FindElement(By.CssSelector("td:nth-child(4)")).Text;
                SpecFlow.SetContext(DealerLatestOperatingItemId, id);
                SpecFlow.SetContext(DealerLatestOperatingItemName, name);
                SpecFlow.SetContext(DealerLatestOperatingItemCustomer, customer);
                copyElem.Click();
            }
        }

        public void ExistsCopiedProposalOffer(IWebDriver driver, string operation)
        {
            LoggingService.WriteLogOnMethodEntry(driver, operation);
            WebDriver.Wait(DurationType.Millisecond, 4000);
            var name = SpecFlow.GetContext(DealerLatestOperatingItemName);
            IWebElement copiedOffer;
            string copiedname;
            try
            {
                copiedOffer = FindCopiedPoposalOfferByName(driver, name);
                copiedname = copiedOffer.FindElement(By.CssSelector("td:nth-child(1)")).Text;
            }
            catch (StaleElementReferenceException stale)
            {
                WebDriver.Wait(DurationType.Millisecond, 4000);
                copiedOffer = FindCopiedPoposalOfferByName(driver, name);
                copiedname = copiedOffer.FindElement(By.CssSelector("td:nth-child(1)")).Text;
            }
            

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
            LoggingService.WriteLogOnMethodEntry(driver, name);
            return
                driver.FindElements(By.CssSelector(ProposalItemsSelecterFormat))
                .Reverse()
                .First(x => x.FindElement(By.CssSelector("td:nth-child(1)")).Text.Contains(name));
        }

        public void SaveProposalAsAContract()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (SaveAsContractButton == null) 
                throw new NullReferenceException("Save Contract button not available");
            SaveAsContractButton.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
            IsSendToBankScreenDiplayed();

        }

        public void IsTheProposalSuccessfullyConverted()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsNewProposalTemplateCreated();
        }

        public DealerSendForApproverPage StartSendToBankProcess(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            var actionsElement = ActionsDropdownElement(actionsButton);
            actionsElement.Last().Click();
            ActionsModule.SendProposalToBankButton(driver);
            return GetInstance<DealerSendForApproverPage>(Driver);
        }

        public void ClickOnSubmitForApproval(int proposalId, string proposalName, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, proposalName, driver);
            ClearAndType(ProposalFilter, proposalId.ToString() + " " + proposalName);
            SeleniumHelper.WaitUntil(d => ProposalListProposalNameRowElement.First(element => element.Text == proposalName));
            var actionsElement = ActionsDropdownElement(actionsButton);
            actionsElement.Last().Click();
            var submitForApprovalElement = ActionsModule.ConvertButtonElement(driver);
            submitForApprovalElement.Click();
        }

        public void ClickOnEditActionButton(string proposalName, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalName, driver);
            SeleniumHelper.SetListFilter(ProposalFilter, proposalName, ProposalListProposalNameRowElement); // Search using proposal Name only as this is the case of copy proposal (hence proposal ID yet to be found out)
            var actionButtonElement = SeleniumHelper.FindElementByCssSelector(ActionsButtonSelector,isWaitforEnabled:true);
            actionButtonElement.Click();
            var proposalEditButtonElement = SeleniumHelper.FindElementByCssSelector(editActionButtonSelector, isWaitforEnabled: true);
            proposalEditButtonElement.Click();
        }

        public void FindExistingPoposalList()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsNotNull(proposalListContainerElement,
                "Existing proposal table is not found.");
        }

        public void HeadlessConfimation(string confirm)
        {
            LoggingService.WriteLogOnMethodEntry(confirm);
            if (confirm != "OK")
            {
                HeadlessDismissAlertCancel();
                ClickDismissOnJsAlert();
            }
            else
            {
                HeadlessDismissAlertOk();
                ClickAcceptOnJsAlert();
            }
        }

        public void ClickAcceptOnConfrimation(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
        }

        public void ClickDismissOnConfrimation(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            WebDriver.Wait(DurationType.Millisecond, 1000);
            HeadlessDismissAlertCancel();
            ClickDismissOnJsAlert();
        }

        public void NotExistTheDeletedItem(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            var id = SpecFlow.GetContext(DealerLatestOperatingItemId);
            var exisitng = ContainsItemById(driver, id);

            TestCheck.AssertIsEqual(false, exisitng,
                "Deleted Item still exists on table.");
        }

        public void ExistsNotDeletedItem(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            var id = SpecFlow.GetContext(DealerLatestOperatingItemId);
            var exisitng = ContainsItemById(driver, id);

            TestCheck.AssertIsEqual(true, exisitng,
                "Deleted Item does not exist on table.");
        }

        private bool ContainsItemById(IWebDriver driver, string id)
        {
            LoggingService.WriteLogOnMethodEntry(driver,id);
            return
                driver.FindElements(By.CssSelector(".js-mps-delete"))
                .Select(x => x.GetAttribute("data-proposal-id"))
                .Contains(id);
        }

        public DealerDashBoardPage NavigateToDashboard(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            DashboradLink.Click();
            return GetInstance<DealerDashBoardPage>();
        }

        public DealerProposalsCreateDescriptionPage NavigateToEditProposalPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetTabInstance<DealerProposalsCreateDescriptionPage>(Driver);
        }
        public void IsDuplicateProposalDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
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

        public bool VerifySavedProposalInOpenProposalsList(int proposalId, string proposalName)
        {
            return VerifyProposalInProposalsList(proposalId, proposalName);
        }

        protected bool VerifyProposalInProposalsList(int proposalId, string proposalName, IWebElement filterElement = null, IList<IWebElement> nameRowElement = null)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, proposalName);

            filterElement = filterElement ?? ProposalFilter;
            nameRowElement = nameRowElement ?? ProposalListProposalNameRowElement;

            // Wait for footer to load & then filter out the proposal
            SeleniumHelper.FindElementByCssSelector(DataTablesFooterSelector);
            ClearAndType(filterElement, proposalId.ToString() + " " + proposalName);
            try
            {
                SeleniumHelper.WaitUntil(d => nameRowElement.First(element => element.Text == proposalName));
                return true;
            }
            catch
            {
                return false;
            }
        }

//        public void ClickOnSubmitForApprovalForAlreadyCreatedCustomerFlow(int findElementTimeout)
//        {
//           var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(ActionsButtonSelector, findElementTimeout);
//           ActionsButtonElement.Click();
//           var SubmitForApprovalButtonElement = SeleniumHelper.FindElementByCssSelector(SubmitForApprovalButtonSelector, findElementTimeout);
//           SubmitForApprovalButtonElement.Click();
//        }       
    }
}
