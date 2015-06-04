using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class ProposalSummaryPageSteps : BaseSteps
    {
        [Then(@"the billing basis for product is ""(.*)""")]
        public void ThenTheBillingBasisForProductIs(string billing)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyThatCorrectModelBillingBasisIsDisplayed(billing);
        }

        [Then(@"the billing basis for Accessory is ""(.*)""")]
        public void ThenTheBillingBasisForAccessoryIs(string billing)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyThatCorrectAccessoryBillingBasisIsDisplayed(billing);
        }

        [Then(@"the billing basis for Installation is ""(.*)""")]
        public void ThenTheBillingBasisForInstallationIs(string billing)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyThatCorrectInstallationBillingBasisIsDisplayed(billing);
        }

        [Then(@"the billing basis for Service Pack is ""(.*)""")]
        public void ThenTheBillingBasisForServicePackIs(string billing)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyThatCorrectServicePackBillingBasisIsDisplayed(billing);
        }

        [Then(@"the installation type displayed is correct")]
        public void ThenTheInstallationTypeDisplayedIsCorrect()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyInstallationTypeIsConsistent();
        }

        [Then(@"the installation cost displayed is correct")]
        public void ThenTheInstallationCostDisplayedIsCorrect()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyInstallationCostIsConsistent();
        }

        [Then(@"the quantity displayed is the same as the one entered")]
        public void ThenTheQuantityDisplayedIsTheSameAsTheOneEntered()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyProductQuantityIsConsistent();
        }

        [Then(@"the service pack name and price displayed are correct")]
        public void ThenTheServicePackNameAndPriceDisplayedAreCorrect()
        {
            //CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyServicePackNameIsConsistent();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyServicePackCostIsConssistent();
        }

        [Then(@"the displayed volume value for mono click price is ""(.*)""")]
        public void ThenTheDisplayedVolumeValueForMonoClickPriceIs(string mono)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyCorrectMonoVolumeIsDisplayed(mono);
        }

        [Then(@"the displayed volume value for colour click price is ""(.*)""")]
        public void ThenTheDisplayedVolumeValueForColourClickPriceIs(string colour)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyCorrectColourVolumeIsDisplayed(colour);
        }


        [Then(@"the bank displayed for leasing is ""(.*)""")]
        public void ThenTheBankDisplayedForLeasingIs(string bank)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyThatCorrectBankIsDisplayed(bank);
        }

        
        [Then(@"the calculations are not based on estimated values")]
        public void ThenTheCalculationsAreNotBasedOnEstimatedValues()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyThatCalculationsAreNotBasedOnEstimates();
        }

        [Then(@"leasing panels displayed")]
        public void ThenLeasingPanelsDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyLeasingPanelDiplsayed();
        }

        [Then(@"clicking on the displayed printer ""(.*)"" link takes me back to the device screen")]
        public void ThenClickingOnTheDisplayedPrinterLinkTakesMeBackToTheDeviceScreen(string printer)
        {
            NextPage = CurrentPage.As<DealerProposalsCreateSummaryPage>().ClickOnDisplayedPrinterLink(printer);
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsDeviceScreenDisplayed();
        }

        [When(@"enter a quantity of ""(.*)"" for accessory for ""(.*)""")]
        public void WhenEnterAQuantityOfForAccessoryFor(string quantity, string printer)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().ClickOnAPrinter(printer);
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionsQuantity0(quantity);
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
        }

        [Then(@"the displayed mono click price is correct")]
        public void ThenTheDisplayedMonoClickPriceIsCorrect()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsMonoClickPriceDisplayedCorrectly();
        }

        [Then(@"the displayed colour click price is correct")]
        public void ThenTheDisplayedColourClickPriceIsCorrect()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsColourClickPriceDisplayedCorrectly();
        }


        [When(@"enter a quantity of ""(.*)"" for model")]
        public void WhenEnterAQuantityOfForModel(string quantity)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity(quantity);
        }

        [When(@"enter a quantity of ""(.*)"" for accessory")]
        public void WhenEnterAQuantityOfForAccessory(string quantity)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionsQuantity0(quantity);
        }

        [When(@"I accept the default values of the device")]
        public void WhenIAcceptTheDefaultValuesOfTheDevice()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyProductAdditionConfirmationMessage();
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().MoveToClickPriceScreen();
        }

        [When(@"I confirm the values entered for the device")]
        public void WhenIconfirmTheValuesEntereForTheDevice()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
            //CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyProductAdditionConfirmationMessage();
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().MoveToClickPriceScreen();
        }


        [When(@"I display ""(.*)"" device screen")]
        [Then(@"I display ""(.*)"" device screen")]
        public void WhenIDisplayDeviceScreen(string printer)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductScreenTextDisplayed();
            CurrentPage.As<DealerProposalsCreateProductsPage>().ClickOnAPrinter(printer);
            CurrentPage.As<DealerProposalsCreateProductsPage>().StoreDefaultProductConfiguration();
        }


        [Then(@"the calculated consumable net totals are equal in all places")]
        public void ThenTheCalculatedConsumableNetTotalsAreEqualInAllPlaces()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyThatNetTotalsAreMatching();
        }

        [Then(@"the calculated consumable gross totals are equal in all places")]
        public void ThenTheCalculatedConsumableGrossTotalsAreEqualInAllPlaces()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyThatGrossTotalsAreMatching();
        }

        [Then(@"the calculations are based on estimated values")]
        public void ThenTheCalculationsAreBasedOnEstimatedValues()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyThatCalculationsAreBasedOnEstimates();
        }

        [Then(@"""(.*)"" displayed on proposal Summary Page corresponds to ""(.*)""")]
        public void ThenDisplayedOnProposalSummaryPageCorrespondsTo(string parameter, string value)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyCreatedProposalSummaryPageElements(parameter, value);
        }


    }
}
