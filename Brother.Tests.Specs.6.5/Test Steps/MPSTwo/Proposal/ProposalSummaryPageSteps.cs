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

        [Then(@"hardware unit price is correctly calculated")]
        public void ThenHardwareUnitPriceIsCorrectlyCalculated()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsHardwareUnitPriceCorrectlyCalculated();
        }

        [Then(@"hardware total cost is correctly calculated for ""(.*)""")]
        public void ThenHardwareTotalCostIsCorrectlyCalculatedFor(string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryTotalCostCorrectlyCalculate(qty);
        }

        [Then(@"hardware total price is correctly calculated for ""(.*)""")]
        public void ThenHardwareTotalPriceIsCorrectlyCalculatedFor(string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryTotalPriceCorrectlyCalculate(qty);
        }

        [Then(@"accessory unit price is correctly calculated")]
        public void ThenAccessoryUnitPriceIsCorrectlyCalculated()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsAccessoryUnitPriceCorrectlyCalculated();
        }

        [Then(@"accessory total cost is correctly calculated for ""(.*)""")]
        public void ThenAccessoryTotalCostIsCorrectlyCalculatedFor(string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryAccessoryTotalCostCorrectlyCalculate(qty);
        }

        [Then(@"device total prices are correctly added up")]
        public void ThenDeviceTotalPricesAreCorrectlyAddedUp()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsDeviceNetTotalAddedUpCorrectly();
        }

        [Then(@"total mono volume is correctly displayed for ""(.*)""")]
        public void ThenTotalMonoVolumeIsCorrectlyDisplayedFor(string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsMonoVolumeTotalCorrect(qty);
        }

        [Then(@"total colour volume is correctly displayed for ""(.*)""")]
        public void ThenTotalColourVolumeIsCorrectlyDisplayedFor(string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsColourVolumeTotalCorrect(qty);
        }

        [Then(@"total mono line price is correctly calculated for ""(.*)""")]
        public void ThenTotalMonoLinePriceIsCorrectlyCalculatedFor(string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsTotalMonoPriceCorrectlyCalculated(qty);
        }

        [Then(@"total colour line price is correctly calculated for ""(.*)""")]
        public void ThenTotalColourLinePriceIsCorrectlyCalculatedFor(string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsTotalColourPriceCorrectlyCalculated(qty);
        }
        
        [Then(@"total volume correctly added up")]
        public void ThenTotalVolumeCorrectlyAddedUp()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsTotalVolumeCorrectlyAddedUp();
        }

        [Then(@"total price correctly added up")]
        public void ThenTotalPriceCorrectlyAddedUp()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsTotalLinePriceCorrectlyCalculated();
        }
        
        [Then(@"accessory total price is correctly calculated for ""(.*)""")]
        public void ThenAccessoryTotalPriceIsCorrectlyCalculatedFor(string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryAccessoryTotalPriceCorrectlyCalculate(qty); 
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
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyServicePackCostIsConsistent();
        }

        [Then(@"service pack cost is included click as ""(.*)""")]
        public void ThenServicePackCostIsIncludedClickAs(string value)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyServicePackCostIsInclusiveInClick(value);
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


        [Then(@"I can close the proposal on contract summary page")]
        public void ThenICanCloseTheProposalOnContractSummaryPage()
        {
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().CloseProposal();
            CurrentPage.As<DealerClosedProposalPage>().IsClosedProposalTabOpened();
            CurrentPage.As<DealerClosedProposalPage>().IsClosedProposalDisplayed();

        }

        [When(@"I identify and navigate to the approved proposal summary")]
        public void WhenIIdentifyAndNavigateToTheApprovedProposalSummary()
        {
            CurrentPage.As<DealerApprovedProposalPage>().IsApprovedProposalTabOpened();
            NextPage = CurrentPage.As<DealerApprovedProposalPage>().NavigateToDealerContractSummaryPage();
        }
        

        [Then(@"I can close the proposal on the summary page")]
        public void ThenICanCloseTheProposalOnTheSummaryPage()
        {
            NextPage = CurrentPage.As<DealerProposalsCreateSummaryPage>().CloseProposal();
            CurrentPage.As<DealerClosedProposalPage>().IsClosedProposalTabOpened();
            CurrentPage.As<DealerClosedProposalPage>().IsClosedProposalDisplayed();

        }


        [Then(@"the closed proposal summary page has no error message")]
        public void ThenTheClosedProposalSummaryPageHasNoErrorMessage()
        {
            CurrentPage.As<DealerClosedProposalPage>().ClickOnClosedProposal();
            NextPage = CurrentPage.As<DealerClosedProposalPage>().OpenClosedProposalSummary();
            CurrentPage.As<DealerClosedProposalSummaryPage>().IsClosedProposalSummaryPageDisplayed();
            NextPage = CurrentPage.As<DealerClosedProposalSummaryPage>().ReturnToClosedProposalList();
            CurrentPage.As<DealerClosedProposalPage>().IsClosedProposalDisplayed();
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
