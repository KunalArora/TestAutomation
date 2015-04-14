using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Account;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin.PartnerPortal;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs
{
    [Binding]
    public class DealerActionsSteps : BaseSteps
    {
        [Then(@"I can see the Partner Portal Home Page")]
        public void ThenICanSeeThePartnerPortalHomePage()
        {
            CurrentPage.As<PartnerPortalPage>().IsHomeButtonAvailable();
        }

        [When(@"I click on Manage Services")]
        public void WhenIClickOnManageServices()
        {
            NextPage = CurrentPage.As<PartnerPortalPage>().ManageServicesButtonClick();
        }

        [Then(@"I should see the OmniJoin Services page")]
        public void ThenIShouldSeeTheOmniJoinServicesPage()
        {
            CurrentPage.As<ManageServicePage>().IsPurchaseActivateCodesButtonAvailable();
        }

        [When(@"I click on Purchase Activation Codes")]
        public void WhenIClickOnPurchaseActivationCodes()
        {
          NextPage = CurrentPage.As<ManageServicePage>().PurchaseCodesButtonClick();
        }

        [Then(@"I should see the Activation Codes creation page")]
        public void ThenIShouldSeeTheActivationCodesCreationPage()
        {
            CurrentPage.As<CreateActivationCodesPage>().IsPurchaseCodesButtonAvailable();
        }

        [When(@"I enter the following information")]
        public void WhenIEnterTheFollowingInformation(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<CreateActivationCodesPage>().SelectProductPlan(form.OJProductPlan);
            CurrentPage.As<CreateActivationCodesPage>().SelectLicenseType(form.LicenseType);
            CurrentPage.As<CreateActivationCodesPage>().SelectPaymentMethod(form.Term);
            CurrentPage.As<CreateActivationCodesPage>().SelectNumberLicenses(form.Qty);
        }

        [Then(@"I click Create Activation Codes")]
        public void ThenIClickCreateActivationCodes()
        {
            NextPage = CurrentPage.As<CreateActivationCodesPage>().PurchaseCodesButtonClick();
        }

        [Then(@"I review the order information")]
        public void ThenIReviewTheOrderInformation()
        {
            CurrentPage.As<CreateActivationCodesPage>().IsConfirmButtonAvailable();
        }

        [When(@"I click Confirm")]
        public void WhenIClickConfirm()
        {
            CurrentPage.As<CreateActivationCodesPage>().ConfirmButtonClick();
        }

        [Then(@"I should see the order success screen")]
        public void ThenIShouldSeeTheOrderSuccessScreen()
        {
            CurrentPage.As<CreateActivationCodesPage>().IsSuccessAvailable();
        }
    }
}
