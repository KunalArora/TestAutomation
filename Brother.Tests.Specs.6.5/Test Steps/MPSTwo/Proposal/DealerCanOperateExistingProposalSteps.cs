using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPSTwo.Proposal
{
    [Binding]
    public class DealerCanOperateProposalOffersSteps : BaseSteps
    {
        [Given(@"I navigate to existing proposal screen")]
        public void GivenINavigateToExistingProposalScreen()
        {
            var page = CurrentPage.As<DealerDashBoardPage>();
            NextPage = page.NavigateToExistingProposalPage();
        }

        [Then(@"I can see the Existing Proposal table")]
        public void ThenICanSeeTheExistingProposalTable()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
        }

        [When(@"I can click edit button on proposal item of Exisiting Proposal table")]
        public void WhenICanClickEditButtonOnProposalItemOfExisitingProposalTable()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            page.ClickOnEditOnActionItem(CurrentDriver);
            NextPage = page.NavigateToEditProposalPage();
        }

        private void EditDescriptionTab(string contract)
        {
            var page = CurrentPage.As<DealerProposalsCreateDescriptionPage>();
            page.IsPromptTextDisplayed();
            page.SelectingContractType(contract);
            page.EnterProposalName("");
            page.EnterLeadCodeRef("");
            NextPage = page.ClickNextButton();
        }

        private void EditCustomerInformationTab()
        {
            var page = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>();
            page.EditProposalCustomerInformation(CurrentDriver);
            NextPage = page.ClickNextButton();
        }

        private void EditTermAndTypeTab(string usage, string contract, string leasing, string billing)
        {
            var page = CurrentPage.As<DealerProposalsCreateTermAndTypePage>();

            page.IsTermAndTypeTextDisplayed();
            page.SelectUsageType(usage);
            page.SelectContractLength(contract);
            //page.SelectLeaseBillingCycle(leasing);
            page.SelectPayPerClickBillingCycle(billing);

            NextPage = page.ClickNextButton();
        }

        private void EditProducts()
        {
            var page = CurrentPage.As<DealerProposalsCreateProductsPage>();
            NextPage = page.EditAndUpdateExistingProducts(CurrentDriver);
        }

        private void EditProducts(string action)
        {
            var page = CurrentPage.As<DealerProposalsCreateProductsPage>();

            switch (action)
            {
                case "Add":
                    page.AddNewProduct(CurrentDriver);
                    NextPage = page.GoNextPage(CurrentDriver);

                    break;
                case "Remove":
                    page.AddNewProduct(CurrentDriver);
                    page.RemoveOldProduct(CurrentDriver);
                    NextPage = page.GoNextPage(CurrentDriver);
                    break;
            }
        }

        private void EditClickPrice(string clickprice, string colour, string row)
        {
            var page = CurrentPage.As<DealerProposalsCreateClickPricePage>();
            page.CalculateClickPrice(clickprice, colour, "0");
            NextPage = page.ProceedToProposalSummaryFromClickPrice();
        }

        private void GoThrowProductsTab()
        {
            var page = CurrentPage.As<DealerProposalsCreateProductsPage>();
            NextPage = page.ForceGoThrowThisTab(CurrentDriver);
        }

        private void GoThrowClickPriceTab(bool fillVolume = false)
        {
            var page = CurrentPage.As<DealerProposalsCreateClickPricePage>();
            NextPage = page.ForceGoThrowThisTab( CurrentDriver, fillVolume);
        }


        [When(@"I edit Products Tab and ""(.*)"" in Proposal")]
        public void WhenIEditProductsTabAndInProposal(string action)
        {
            EditProducts(action);
            GoThrowClickPriceTab(false);
        }

        [Then(@"I can confirm Products and ""(.*)"" on Summary Tab in Proposal")]
        public void ThenICanConfirmProductsAndOnSummaryTabInProposal(string action)
        {
            var page = CurrentPage.As<DealerProposalsCreateSummaryPage>();
            page.VerifyProductsCount(CurrentDriver, action);
        }

        [When(@"I edit ""(.*)"" Tab in Proposal")]
        public void WhenIEditTabInProposal(string tabname)
        {
            switch (tabname)
            {
                case "Description":
                    EditDescriptionTab("Lease & Click with Service");
                    break;

                case "CustomerInformation":
                    EditCustomerInformationTab();
                    break;

                case "TermAndType":
                    EditTermAndTypeTab("Pay As You Go", "5 years", "Quarterly", "Quarterly");
                    GoThrowProductsTab();
                    GoThrowClickPriceTab();
                    break;

                case "Products":
                    EditProducts();
                    GoThrowClickPriceTab();
                    break;

                case "ClickPrice":
                    EditClickPrice("1000", "1000", "0");
                    break;

                case "Summary":
                    break;
            }
        }

        [When(@"I go to ""(.*)"" Tab in Proposal")]
        public void WhenIGoToTabInProposal(string tabname)
        {
            switch (tabname)
            {
                case "Description":
                    NextPage = DealerProposalsCreateNavTabs.NavigateToDescriptionTab(CurrentDriver);
                    break;

                case"CustomerInformation":
                    NextPage = DealerProposalsCreateNavTabs.NavigateToCustomerInformationTab(CurrentDriver);
                    break;

                case "TermAndType":
                    NextPage = DealerProposalsCreateNavTabs.NavigateToTermAndTypeTab(CurrentDriver);
                    break;

                case "Products":
                    NextPage = DealerProposalsCreateNavTabs.NavigateToProductsTab(CurrentDriver);
                    break;

                case "ClickPrice":
                    NextPage = DealerProposalsCreateNavTabs.NavigateToClickPriceTab(CurrentDriver);
                    break;

                case "Summary":
                    NextPage = DealerProposalsCreateNavTabs.NavigateToSummaryTab(CurrentDriver);
                    break;
            }
        }

        [Then(@"I can confirm ""(.*)"" on Summary Tab in Proposal")]
        public void ThenICanConfirmOnSummaryTabInProposal(string tabname)
        {
            var page = CurrentPage.As<DealerProposalsCreateSummaryPage>();
            switch (tabname)
            {
                case "Description":
                    page.VerifyDescriptionTabInput();
                    break;

                case "CustomerInformation":
                    page.VerifyCustomerInformationTabInput();
                    break;

                case "TermAndType":
                    page.VerifyTermAndTypeTabInput();
                    break;

                case "Products":
                    page.VerifyProductsTabInput(CurrentDriver);
                    break;

                case "ClickPrice":
                    page.VerifyClickPriceTabInput(CurrentDriver);
                    break;

                case "Summary":
                    break;
            }
        }


        [When(@"I click the delete button against ""(.*)"" on Exisiting Proposal table")]
        public void WhenIClickTheDeleteButtonAgainstAnItemOnExisitingProposalTable(string targertitem)
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            if (targertitem == "NewlyCreatedItem")
            {
                page.ClickOnDeleteOnActionItemAgainstNewlyCreated(CurrentDriver);
            }
            else
            {
                page.ClickOnDeleteOnActionItem(CurrentDriver);
            }
        }

        [When(@"I click the ""(.*)"" button on Confirmation Dialog")]
        public void WhenIClickTheButtonOnConfirmationDialog(string confirm)
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            if (confirm == "OK")
            {
                page.ClickAcceptOnConfrimation(CurrentDriver);
            }
            else
            {
                page.ClickDismissOnConfrimation(CurrentDriver);
            }
        }

        [Then(@"I can see the deleted item does not exist on the table")]
        public void ThenICanSeeTheDeletedItemDoesNotExistOnTheTable()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.NotExistTheDeletedItem(CurrentDriver);
        }

        [Then(@"I can see the deleted item still exists on the table")]
        public void ThenICanSeeTheDeletedItemStillExistsOnTheTable()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.ExistsNotDeletedItem(CurrentDriver);
        }

        [When(@"I can Copy ""(.*)"" Customer an item of Exisiting Proposal table ""(.*)"" Customer")]
        public void WhenICanCopyCustomerAnItemOfExisitingProposalTableCustomer(string operation, string target)
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            page.ClickOnCopyOnActionItemWithoutCustomer(CurrentDriver, operation, target);
        }

        [Then(@"I can see the Proposal offer which copied ""(.*)"" Customer")]
        public void ThenICanSeeTheProposalOfferWhichCopiedCustomer(string operation)
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            page.ExistsCopiedProposalOffer(CurrentDriver, operation);
        }

        [Given(@"I navigate to Dealer Dashboard page from Dealer Proposal page")]
        public void GivenINavigateToDealerDashboardPageFromDealerProposalPage()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            NextPage = page.NavigateToDashboard(CurrentDriver);
        }
    }
}