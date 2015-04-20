using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement.PaymentMethods;
using Brother.WebSites.Core.Pages.OmniJoin.Plans;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.OmniJoin.Plans
{
    [Binding]
    public class ManagePlanSteps : BaseSteps
    {
        [Then(@"I can validate the correct plan is displayed ""(.*)"" ""(.*)""")]
        public void ThenICanValidateTheCorrectPlanIsDisplayed(string omniJoinPlanType, string omniJoinBillingType)
        {
            Assert.AreEqual(true, CurrentPage.As<ManagePlanPage>().CheckCurrentOmniJoinPlanIsCorrect(omniJoinPlanType, omniJoinBillingType), "OmniJoin - Incorrect Plan displayed");
        }

        [Then(@"I can validate that the plan was changed ""(.*)"" ""(.*)""")]
        public void ThenICanValidateThatThePlanWasChanged(string omniJoinPlanType, string omniJoinBillingType)
        {
            Assert.AreEqual(true, CurrentPage.As<ManagePlanPage>().CheckCurrentOmniJoinPlanIsCorrect(omniJoinPlanType, omniJoinBillingType), "OmniJoin Change Plan - Incorrect Plan selected so change was not successful");
        }

        [Then(@"If I click on Change Plan or Term")]
        public void ThenIfIClickOnChangePlanOrTerm()
        {
            CurrentPage.As<ManagePlanPage>().ChangePlanOrTermLinkClick();
            CurrentPage.As<ManagePlanPage>().IsChangePlanUpdateButtonAvailable();
        }

        [Then(@"If I click on Edit Payment Method")]
        public void ThenIfIClickOnEditPaymentMethod()
        {
            CurrentPage.As<ManagePlanPage>().EditPaymentMethodLinkClick();
            CurrentPage.As<ManagePlanPage>().IsEditPaymentUpdateButtonAvailable();
        }

        [Then(@"I select a payment Method from the Drop Down list as ""(.*)""")]
        public void ThenISelectAPaymentMethodFromTheDropDownListAs(string paymentMethod)
        {
            CurrentPage.As<ManagePlanPage>().SelectPaymentMethod(paymentMethod);
        }

        [Then(@"I can switch plans to ""(.*)"" ""(.*)""")]
        public void ThenICanSwitchPlansTo(string omniJoinPlanType, string omniJoinBillingType)
        {
            CurrentPage.As<ManagePlanPage>().SelectOmniJoinPlan(omniJoinPlanType, omniJoinBillingType);
            CurrentPage.As<ManagePlanPage>().ChangePlanUpdateButtonClick();
        }

        [Then(@"I check that the correct number of payment methods exist as ""(.*)""")]
        public void ThenICheckThatThereIsOnlyASinglePaymentMethodPresentInTheList(int paymentMethodCount)
        {
            CurrentPage.As<ManagePlanPage>().CheckPaymentMethodCount(paymentMethodCount);
        }

        [When(@"I click Add Payment Method")]
        public void WhenIClickAddPaymentMethod()
        {
            NextPage = CurrentPage.As<ManagePlanPage>().AddPaymentMethodButtonClick();
        }

        [When(@"I add a new Payment Method")]
        public void WhenIAddANewPaymentMethod()
        {
            NextPage = CurrentPage.As<MyPaymentMethodsPage>().MyPaymentMethodsAddPaymentMethodButtonClick();
        }

        [When(@"I can click on Update for Payment Method")]
        public void WhenICanClickOnUpdatePaymentMethod()
        {
            CurrentPage.As<ManagePlanPage>().IsEditPaymentUpdateButtonAvailable();
            CurrentPage.As<ManagePlanPage>().EditPaymentUpdateButtonClick();
        }

        [When(@"I can click on Update for Change Plan")]
        public void WhenICanClickOnUpdateChangePlan()
        {
            CurrentPage.As<ManagePlanPage>().IsEditPaymentUpdateButtonAvailable();
            CurrentPage.As<ManagePlanPage>().EditPaymentUpdateButtonClick();
        }

        [When(@"I can validate that the plan was changed")]
        public void WhenICanValidateThatThePlanWasChanged()
        {
            CurrentPage.As<ManagePlanPage>().IsInformationbarDisplayed();
        }

        [Then(@"I can validate that SAP has accepted the change of OmniJoin plan")]
        public void ThenICanValidateThatSapHasAcceptedTheChangeOfOmniJoinPlan()
        {
            NextPage = GlobalNavigationModule.BackToBrotherOnlineButtonClick(CurrentDriver);
            CurrentPage.As<WelcomeBackPage>().NavigateToMyAccountPage("United Kingdom");
            var ordersButton = GlobalNavigationModule.GetMyAccountMenuItem("Orders");
            NextPage = GlobalNavigationModule.OrdersMenuClick(CurrentDriver, ordersButton);
            CurrentPage.As<MyOrdersPage>().ValidateOmniJoinPlanChange();
        }

    }
}
