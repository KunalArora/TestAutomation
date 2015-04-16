using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Basket;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin.Plans;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.OmniJoin.Plans;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.OmniJoin.Plans
{
    [Binding]
    public class PurchaseAPlan : BaseSteps
    {
        // Full scenario in a single step. This is use by the Manage Plans feature
        [When(@"I purchase an OmniJoin ""(.*)"" plan with ""(.*)"" billing with valid payment details")]
        public void WhenIPurchaseAnOmniJoinLitePlanWithMonthlyBillingWithValidPaymentDetails(string omniJoinPlanType, string omniJoinBillingMethod)
        {
            Then("I have clicked on Buy");
            Then("I should be redirected to the Plans page");
            Then(string.Format("If I then Choose the \"{0}\" Plan option column", omniJoinPlanType));
            Then("I should be directed to the relevant plan page");
            When("I click Agree to terms and conditions");
            And("I Click Buy Now At Brother Online");
            Then("I should be directed to the Brother Online Basket page");
            And("When I click CheckOut");
            Then("I can add billing address details for Country \"United Kingdom\"");
	        And("I can go through the order process for Country \"United Kingdom\" with order info \"1\"");
            Then("I should see the Order Confirmation page");
            And(string.Format("The purchased plan billing type is correct \"{0}\"", omniJoinBillingMethod));
            And("If I click on My Account");
            And("I can validate the order \"1\" of \"OmniJoin Lite\" @ \"£18.00\" on My Account page");
            And("I can validate an Order Confirmation email was received");
        }

        // Full scenario in a single step. This is use by the Manage Plans feature
        [When(@"I purchase an OmniJoin ""(.*)"" plan with ""(.*)"" billing with invalid payment details")]
        public void WhenIPurchaseAnOmniJoinLitePlanWithMonthlyBillingWithInvalidPaymentDetails(string omniJoinPlanType, string omniJoinBillingMethod)
        {
            Then("I have clicked on Buy");
            Then("I should be redirected to the Plans page");
            Then(string.Format("If I then Choose the \"{0}\" Plan option column", omniJoinPlanType));
            Then("I should be directed to the relevant plan page");
            When("I click Agree to terms and conditions");
            And("I Click Buy Now At Brother Online");
            Then("I should be directed to the Brother Online Basket page");
            And("When I click CheckOut");
            Then("I can add billing address details for Country \"United Kingdom\"");
            And("I can go through the order process for Country \"United Kingdom\" with order info \"1\"");
            Then("I should see the Order Confirmation page");
            And(string.Format("The purchased plan billing type is correct \"{0}\"", omniJoinBillingMethod));
            And("If I click on My Account");
            And("I can validate the order \"1\" of \"OmniJoin Lite\" @ \"£18.00\" on My Account page");
            And("I can validate an Order Confirmation email was received");
        }

        [Then(@"I should be redirected to the Plans page")]
        public void ThenIShouldBeRedirectedToThePlansPage()
        {
            CurrentPage.As<PlansHomePage>().IsStartFreeTrialButtonAvailable();
        }

        [Then(@"If I then Choose the ""(.*)"" Plan option column")]
        public void ThenIfIThenClickOnChoosePlanUnderTheLiteUseColumn(string planType)
        {
            switch (planType)
            {
                case "Lite":
                    NextPage = CurrentPage.As<PlansHomePage>().ChooseLitePlanButtonClick();
                    break;

                case "Professional":
                    NextPage = CurrentPage.As<PlansHomePage>().ChooseProPlanButtonClick();
                    break;

                case "Business":
                    NextPage = CurrentPage.As<PlansHomePage>().ChooseBusinessPlanButtonClick();
                    break;

            }
            
        }

        [Then(@"I check the correct billing type as ""(.*)""")]
        public void ThenICheckTheCorrectBillingTypeAs(string billingType)
        {
            if (billingType.Equals("Annual"))
            {
                PlansModule.SwitchBillingButtonClick(CurrentDriver);
            }
        }

        //[Then(@"If I switch billing type to annual billing")]
        //public void ThenIfISwitchBillingTypeToAnnualBilling()
        //{
        //    PlansModule.SwitchBillingButtonClick(CurrentDriver);
        //}

        [Then(@"I should be directed to the relevant plan page")]
        public void ThenIShouldBeDirectedToTheRelevantPlanPage()
        {
            PlansModule.IsBuyNowAtBrotherOnlineButtonAvailable(CurrentDriver);
        }

        [When(@"I click Agree to terms and conditions")]
        public void WhenIClickAgreeToTermsAndConditions()
        {
            PlansModule.AgreeToTermsAndConditionsClick(CurrentDriver);
        }

       
        [When(@"I Click Buy Now At Brother Online")]
        public void WhenIClickBuyNowAtBrotherOnline()
        {
            NextPage = PlansModule.BuyNowAtBrotherOnlineButtonClick(CurrentDriver);
        }

        [Then(@"I should be directed to the Brother Online Basket page")]
        public void ThenIShouldBeDirectedToTheBrotherOnlineBasketPage()
        {
            CurrentPage.As<BasketPage>().IsCheckoutButtonAvailable();
        }

        [Then(@"When I click CheckOut")]
        public void ThenWhenIClickCheckOut()
        {
            NextPage = CurrentPage.As<BasketPage>().OmniJoinCheckOutButtonClick();
        }
    }
}
