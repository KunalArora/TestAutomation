using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs
{
    [Binding]
    public class DealerActionsSteps : BaseSteps
    {
        [Then(@"when I click Manage Customers and Orders")]
        public void ThenWhenIClickManageCustomersAndOrders()
        {
            NextPage = CurrentPage.As<PartnerPortalPage>().ManageCustomersAndOrdersButtonClick();
        }


        [When(@"I create a new Customer Account")]
        public void WhenICreateANewCustomerAccount()
        {
            //CurrentPage.As<>().
        }


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
            var term = form.Term.Equals("Annual") ? 12 : 1;
            Helper.OrpLicenseTerm = term;
            CurrentPage.As<CreateActivationCodesPage>().SelectNumberLicenses(form.Qty);
            Helper.OrpNumLicenses = Convert.ToInt32(form.Qty);
            var commentField = string.Empty;
            if (form.Comment.Equals("@@@@@"))
            {
                // Auto Generate Date for Comment field
                commentField = DateTime.Now.ToShortDateString();
            }
            CurrentPage.As<CreateActivationCodesPage>().AddComment(commentField);
            Helper.OrpComment = commentField;
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

        [Then(@"I can store the Order Details for ""(.*)"" as they are required later")]
        public void ThenICanStoreTheOrderDetailsForAsTheyAreRequiredLater(string dealerEmailAddress)
        {
            Helper.OrpDealerEmail = dealerEmailAddress;
            Helper.OrpActivationCode = Utils.GetOrpActivationCode(Utils.GetOrpDealerId(Helper.OrpDealerEmail),
                Helper.OrpLicenseTerm, Helper.OrpNumLicenses, Helper.OrpComment);
        }

    }
}
