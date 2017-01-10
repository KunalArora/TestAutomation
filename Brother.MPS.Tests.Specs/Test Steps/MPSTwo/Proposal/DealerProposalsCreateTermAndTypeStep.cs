using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class DealerProposalsCreateTermAndTypeStep : BaseSteps
    {
        [When(@"I Enter usage type of ""(.*)"" and ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails(string usage, string contract, string leasing, string billing)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTermAndTypeTextDisplayed();
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectUsageType(usage);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectContractLength(contract);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectLeaseBillingCycle(leasing);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);

            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        [When(@"I tick Price Hardware radio button")]
        public void WhenITickPriceHardwareRadioButton()
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().TickPriceHardware();

            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        [When(@"I untick Price Hardware radio button")]
        public void WhenIUntickPriceHardwareRadioButton()
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().UntickPriceHardware();

            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        [Then(@"I should not see Price Hardware radio button on Term and Type screen")]
        public void ThenIShouldNotSeePriceHardwareRadioButtonOnTermAndTypeScreen()
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsNotPriceHardwareElement();
            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        [When(@"I ""(.*)"" Price Hardware radio button")]
        public void WhenIPriceHardwareRadioButton(string option)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().TickPriceHardware(option);
            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        [Given(@"I Enter ""(.*)"" usage type ""(.*)"" contract length and ""(.*)"" billing on Term and Type details")]
        [When(@"I Enter ""(.*)"" usage type ""(.*)"" contract length and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails(string usage, string contract,
            string billing)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTermAndTypeTextDisplayed();
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectUsageType(usage);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectContractLength(contract);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);
        }

        [Given(@"I select service pack ""(.*)"" payment method")]
        [Then(@"I select service pack ""(.*)"" payment method")]
        [When(@"I select service pack ""(.*)"" payment method")]
        public void WhenISelectServicePackPaymentMethod(string pay)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().PayServicePackMethod(pay);
        }

        [Given(@"the right payment type is displayed as ""(.*)""")]
        [When(@"the right payment type is displayed as ""(.*)""")]
        [Then(@"the right payment type is displayed as ""(.*)""")]
        public void ThenTheRightPaymentTypeIsDisplayedAs(string pay)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTheRightPaymentMethodSelected(pay);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().HowManyServicePackPaymentIsDisplayed(1);
        }



        private void WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetails(string contract, string leasing,
    string billing)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTermAndTypeTextDisplayed();

            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectContractLength(contract);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectLeaseBillingCycle(leasing);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);
        }

        [Given(@"I Enter ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details")]
        [When(@"I Enter ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetailsAndClick(string contract, string leasing,
            string billing)
        {
            WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetails(contract, leasing, billing);

            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
        }

        [When(@"I Enter ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details\(only input\)")]
        public void WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetailsOnlyInput(string contract, string leasing,
            string billing)
        {
            WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetails(contract, leasing, billing);
        }

        [When(@"I Enter ""(.*)"" contract terms and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterContractTermsAndBillingOnTermAndTypeDetails(string contract, string billing)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTermAndTypeTextDisplayed();

            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectContractLength(contract);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);
        }

        public void EditTermAndTypeTab(string usage, string contract, string leasing, string billing)
        {
            var page = CurrentPage.As<DealerProposalsCreateTermAndTypePage>();

            page.IsTermAndTypeTextDisplayed();
            page.SelectUsageType(usage);
            page.SelectContractLength(contract);
            page.SelectLeaseBillingCycle(leasing);
            page.SelectPayPerClickBillingCycle(billing);

            NextPage = page.ClickNextButton();
        }

        public void EditTermAndTypeTabForPurchaseOffer(string usage, string contract, string billing)
        {
            var page = CurrentPage.As<DealerProposalsCreateTermAndTypePage>();

            page.IsTermAndTypeTextDisplayed();
            page.SelectUsageType(usage);
            page.SelectContractLength(contract);
            //page.SelectLeaseBillingCycle(leasing);
            page.SelectPayPerClickBillingCycle(billing);

            NextPage = page.ClickNextButton();
        }
    }
}
