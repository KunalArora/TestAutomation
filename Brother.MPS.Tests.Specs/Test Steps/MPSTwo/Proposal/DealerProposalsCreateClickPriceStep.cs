using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class DealerProposalsCreateClickPriceStep : BaseSteps
    {
        [When(@"I enter click price volume of ""(.*)"" and ""(.*)""")]
        public void WhenIEnterClickPriceVolumeOf(string clickprice, string colour)
        {
            NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateClickPriceAndProceed(clickprice, colour);
        }

        [When(@"I type click price volume of ""(.*)"" and ""(.*)""")]
        public void WhenITypeClickPriceVolumeOfAnd(string clickprice, string colour)
        {
            NextPage =
                CurrentPage.As<DealerProposalsCreateClickPricePage>()
                    .CalculateEnteredClickPriceForMonoAndColourAndProceed(clickprice, colour);
        }

        [When(@"Service Pack In Click line is displayed")]
        public void WhenServicePackInClickLineIsDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().IsServiceInClickLineDisplayedOnClickPricePage();
        }

        public void WhenISelectMultipleClickPrice(string mono, string colour)
        {
            NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>()
                .CalculateSelectedMultipleClickPrice(mono, colour);
        }

        public void WhenIEnterMultipleClickPriceVolumeOf(string clickprice, string colour)
        {
            NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateMultipleClickPriceAndProceed(clickprice, colour);
        }

        [Then(@"I note the calculated click price using ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void ThenINoteTheCalculatedClickPriceUsingAnd(string contract, string paymentMethod, string printer, string clickVol, string monoCoverage, string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().WritePrinterParametersToCsv(printer, paymentMethod, monoCoverage, "Nil", qty, clickVol, "Nil", contract);
        }

        [Then(@"I note the calculated click price using ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", and ""(.*)""")]
        public void ThenINoteTheCalculatedClickPriceUsingAnd(string contract, string paymentMethod, string printer, string clickVol, string colourVol, string monoCoverage, string colourCoverage, string qty)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().WritePrinterParametersToCsv(printer, paymentMethod, monoCoverage, colourCoverage, qty, clickVol, colourVol, contract);
            
        }


        [When(@"I type in click price volume of ""(.*)""")]
        public void WhenITypeInClickPriceVolumeOf(string monoVol)
        {
            NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredClickPriceAndProceed(monoVol);
        }

        [When(@"I calculate click price volume of ""(.*)""")]
        public void WhenICalculateClickPriceVolumeOf(string monoVol)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredClickPrice(monoVol);
        }

        [When(@"I calculate ""(.*)"" click price volume of ""(.*)""")]
        public void WhenICalculateClickPriceVolumeOf(string payment, string volume)
        {
            if (payment.Equals("Pay As You Go") || payment.Equals("Paiement selon la consommation réelle de pages"))
            {
                CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredClickPrice(volume);
            }
            else if (payment.Equals("Minimum Volume") || payment.Equals("Engagement sur un minimum volume de pages"))
            {
               CurrentPage.As<DealerProposalsCreateClickPricePage>().SelectMonoVolume(volume, "0"); 
               CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateClickPriceAndStoreVal();
               CurrentPage.As<DealerProposalsCreateClickPricePage>().StoreMonoClickPrice();
            }

            NextPage =
                CurrentPage.As<DealerProposalsCreateClickPricePage>()
                    .ClickAndProceedOnDealerProposalsCreateSummaryPage();
        }


        [When(@"I calculate click price volume of ""(.*)"" and ""(.*)"" without proceeding")]
        public void WhenICalculateClickPriceVolumeOfAnd(string monoVol, string colourVol)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateClickPrice(monoVol, colourVol);
        }

        [When(@"I calculate ""(.*)"" click price volume of ""(.*)"" and ""(.*)"" without proceeding")]
        public void WhenICalculateClickPriceVolumeOfAndWithoutProceeding(string payment, string monoVol, string colourVol)
        {
            if (payment.Equals("Minimum Volume") || payment.Equals("Engagement sur un minimum volume de pages"))
            {
                CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateClickPrice(monoVol, colourVol);
            }
            else if (payment.Equals("Pay As You Go") || payment.Equals("Paiement selon la consommation réelle de pages"))
            {
                CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredMonoAndColourClickPrice(monoVol, colourVol);
            }

            NextPage =
                CurrentPage.As<DealerProposalsCreateClickPricePage>()
                    .ClickAndProceedOnDealerProposalsCreateSummaryPage();
        }



        [When(@"I type in large click volume of ""(.*)""")]
        public void WhenITypeInLargeClickVolumeOf(string volume)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredErrorClickPrice(volume);
        }


        [Then(@"appropriate error message is displayed")]
        public void ThenAppropriateErrorMessageIsDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().IsLargeEstimatedVolumeErrorMessageDisplayed();
        }

        [Then(@"calculate button is disabled")]
        public void ThenCalculateButtonIsDisabled()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().IsCalculateButtonDisabled();
        }

        [When(@"I calculate click price for the printer")]
        public void WhenICalculateClickPriceForThePrinter()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateClickPrice();
        }

        [Then(@"the click price displayed for the Colour is changed accordingly")]
        public void ThenTheClickPriceDisplayedForTheColourIsChangedAccordingly()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceDisplayedForTheColourIsChangedAccordingly();
        }

        [Then(@"the click price displayed for the Mono is changed accordingly")]
        public void ThenTheClickPriceDisplayedForTheMonoIsChangedAccordingly()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceDisplayedForTheMonoIsChangedAccordingly();
        }

        [Then(@"the click price for Mono is not changed")]
        public void ThenTheClickPriceForMonoIsNotChanged()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForMonoIsNotChanged("0");
        }

        [Then(@"the click price for Mono field(.*) is changed")]
        public void ThenTheClickPriceForMonoFieldIsChanged(string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForMonoIsChanged(row);
        }

        [Then(@"the click price for Mono field(.*) is not changed")]
        public void ThenTheClickPriceForMonoFieldIsNotChanged(string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForMonoIsNotChanged(row);
        }

        [Then(@"the click price for Colour field(.*) is changed")]
        public void ThenTheClickPriceForColourFieldIsChanged(string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForColourIsChanged(row);
        }

        [Then(@"the click price for Colour field(.*) is not changed")]
        public void ThenTheClickPriceForColourFieldIsNotChanged(string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForColourIsNotChanged(row);
        }


        [Then(@"the Click Price value for Volume value become smaller and smaller")]
        public void ThenTheClickPriceValueForVolumeValueBecomeSmallerAndSmaller()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceValueForVolumeValueBecomeSmallerAndSmaller();
        }

        [Then(@"the Click Price value for Volume value is all equal")]
        public void ThenTheClickPriceValueForVolumeValueIsAllEqual()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyClickPriceValueForVolumeValueIsAllEqual();
        }

        [When(@"I choose to pay Service Packs ""(.*)""")]
        public void WhenIChooseToPayServicePacks(string pay)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().PayServicePackMethod(pay);
        }

        [When(@"I enter ""(.*)"" into Mono Coverage field")]
        public void WhenIEnterIntoMonoCoverageField(string coverage)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterMonoCoverage(coverage);
        }

        [When(@"I enter ""(.*)"" into Mono Volume field")]
        public void WhenIEnterIntoMonoVolumeField(string volume)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterMonoVolume(volume, "0");
        }

        [When(@"I enter ""(.*)"" into Colour Coverage field")]
        public void WhenIEnterIntoColourCoverageField(string coverage)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterColourCoverage(coverage);
        }

        [When(@"I enter ""(.*)"" into Colour Volume field")]
        public void WhenIEnterIntoColourVolumeField(string volume)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterColourVolume(volume, "0");
        }

        [When(@"I select ""(.*)"" from Mono Volume field")]
        public void WhenISelectFromMonoVolumeField(string volume)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().SelectMonoVolume(volume, "0");
        }

        [When(@"I select ""(.*)"" from Mono Volume field by indicating row(.*)")]
        public void WhenISelectFromMonoVolumeFieldByIndicatingRow(string volume, string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().SelectMonoVolume(volume, row);
        }

        [When(@"I select ""(.*)"" from Colour Volume field by indicating row(.*)")]
        public void WhenISelectFromColourVolumeFieldByIndicatingRow(string volume, string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().SelectColorVolume(volume, row);
        }

        [When(@"I enter ""(.*)"" from Colour Volume field by indicating row(.*)")]
        public void WhenIEnterFromColourVolumeFieldByIndicatingRow(string volume, string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterColourVolume(volume, row);
        }

        [When(@"I enter ""(.*)"" from Mono Volume field by indicating row(.*)")]
        public void WhenIEnterFromMonoVolumeFieldByIndicatingRow(string volume, string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterMonoVolume(volume, row);
        }

        [When(@"Service Pack payment method is not displayed")]
        [Then(@"Service Pack payment method is not displayed")]
        public void WhenServicePackPaymentMethodIsNotDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyPaymentMethodIsNotDisplayed();
        }

        [Then(@"the coverage error is displayed")]
        public void ThenTheCoverageErrorIsDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().IsCoverageErrorDisplayed();
        }

        [When(@"Service Pack payment method is displayed")]
        [Then(@"Service Pack payment method is displayed")]
        public void WhenServicePackPaymentMethodIsDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyPaymentMethodIsDisplayed();
        }

        public void EditClickPrice(string clickprice, string colour, string row)
        {
            var page = CurrentPage.As<DealerProposalsCreateClickPricePage>();
            page.CalculateClickPrice(clickprice, colour, "0");
            NextPage = page.ProceedToProposalSummaryFromClickPrice();
        }
    }
}
