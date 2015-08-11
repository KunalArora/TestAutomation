using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs._80.BrotherOnline
{
    [Binding]
    public class AddDeviceSteps : BaseSteps
    {
        [When(@"I have clicked on Add Device")]
        public void WhenIHaveClickedOnAddDevice()
        {
            TestCheck.AssertIsNotEqual(true, CurrentPage.As<WelcomeBackPage>().IsWarningBarPresent(0, 5), "Warning Bar - account validation");
            NextPage = CurrentPage.As<WelcomeBackPage>().ClickRegisterDeviceLink();
            //TestCheck.AssertIsNotEqual(true, CurrentPage.As<RegistrationPage>().IsWarningBarPresent(0, 5), "Warning Bar - account validation");
        }

        [When(@"I have clicked on add device whilst logged in with the creative center account")]
        public void WhenIHaveClickedOnAddDeviceWithCCLogin()
        {
            TestCheck.AssertIsNotEqual(true, CurrentPage.As<HomePage>().IsWarningBarPresent(0, 5), "Warning Bar - account validation");
            CurrentPage.As<HomePage>().ClickRegisterDeviceLink();
            //TestCheck.AssertIsNotEqual(true, CurrentPage.As<RegistrationPage>().IsWarningBarPresent(0, 5), "Warning Bar - account validation");
        }

        [When(@"I am redirected to the Register Device page")]
        public void WhenIAmRedirectedToTheRegisterDevicePage()
        {
            CurrentPage.As<RegisterDevicePage>().IsSerialNumberTextBoxAvailable();
            TestCheck.AssertIsEqual(true, Validation.ValidateWarningMessageBarStatus(false), "Account Not Validated Warning Message Present");
        }

        [When(@"I am redirected to the Register device page with the creative center login")]
        public void WhenIAmRedirectedToTheRegisterDevicePageWithCreativeCenterLogin()
        {
            CurrentPage.As<HomePage>().IsSerialNumberTextBoxAvailable();
            TestCheck.AssertIsEqual(true, Validation.ValidateWarningMessageBarStatus(false), "Account Not Validated Warning Message Present");
        }

        [When(@"I have entered my product information")]
        public void WhenIHaveEnteredMyProductInformation(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            var productCode = Helper.GetDeviceCodeSeed();

            GivenIHaveEnteredMyProductSerialCode(productCode);
            GivenIHaveEnteredMyPurchaseDate("02/02/2015");
            GivenIHaveEnteredMyPromoCode(form.PromoCode);
            GivenIHaveEnteredMyProductSupplier(form.Supplier);
            WhenIHaveTickedTheExtendedWarrantyOption(form.ExtendedWarranty);
        }

        [Given(@"I have entered my Purchase Date ""(.*)""")]
        public void GivenIHaveEnteredMyPurchaseDate(string purchaseDate)
        {
            CurrentPage.As<RegisterDevicePage>().EnterPurchaseDate(purchaseDate);
        }

        [Then(@"I can validate that an error message was displayed")]
        public void ThenICanValidateThatAnErrorMessageWasDisplayed()
        {
            TestCheck.AssertIsEqual(true, CurrentPage.As<RegisterDevicePage>().IsErrorIconPresent(), "Is Error Icon Present");
        }

        [Then(@"I can validate that an error message is displayed due to serial number")]
        public void ThenICanValidateThatAnErrorMessageWasDisplayedDueToSerialNumber()
        {
            TestCheck.AssertIsEqual(true, CurrentPage.As<HomePage>().IsErrorIconPresent(), "Is Error Icon Present");
        }

        [Then(@"I should see the account not validated error message preventing device registration")]
        public void ThenIShouldSeeAccountNotValidatedErrorMessage()
        {
            CurrentPage.As<RegisterDevicePage>().AccountNotValidatedErrorMessageDisplayed();
        }

        [Given(@"I have entered my Product Serial Code ""(.*)""")]
        public void GivenIHaveEnteredMyProductSerialCode(string productSerialCode)
        {
            CurrentPage.As<RegisterDevicePage>().EnterProductSerialCode(productSerialCode);
        }

        [Then(@"I have entered my Product Serial Code whilst logged in with a creative center account ""(.*)""")]
        public void GivenIHaveEnteredMyProductSerialCodeWhilstLoggedInWithCCAcc(string productSerialCode)
        {
            CurrentPage.As<HomePage>().EnterProductSerialCode(productSerialCode);
        }

        [When(@"I have Ticked the Extended Warranty option ""(.*)""")]
        public void WhenIHaveTickedTheExtendedWarrantyOption(bool extendedWarranty)
        {
            CurrentPage.As<RegisterDevicePage>().TickExtendedWarrantyOption(extendedWarranty);
        }

        [When(@"I have Agreed to Brothers Warranty Conditions")]
        public void WhenIHaveAgreedToBrothersWarrantyConditions()
        {
            CurrentPage.As<RegisterDevicePage>().AgreeToBrotherTermsAndConditions();
        }

        [Given(@"I have entered my Promo Code ""(.*)""")]
        public void GivenIHaveEnteredMyPromoCode(string promoCode)
        {
            CurrentPage.As<RegisterDevicePage>().EnterPromoCode(promoCode);
        }

        [Then(@"If I click Back To Brother online")]
        public void ThenIfIClickBackToBrotherOnline()
        {
            NextPage = CurrentPage.As<MyPrintersAndDevicesPage>().GoBackToBrotherOnlineHomeButtonClick();
        }

        [Given(@"I have entered my product Supplier ""(.*)""")]
        public void GivenIHaveEnteredMyProductSupplier(string supplierName)
        {
            CurrentPage.As<RegisterDevicePage>().EnterSupplier(supplierName);
        }

        [When(@"I click Continue")]
        public void WhenIClickContinue()
        {
            CurrentPage.As<RegisterDevicePage>().IsContinueButtonAvailable();
            NextPage = CurrentPage.As<RegisterDevicePage>().ClickContinueButton();
        }

        [Then(@"my device should be successfully registered")]
        public void ThenMyDeviceShouldBeSuccessfullyRegistered()
        {
            CurrentPage.As<MyPrintersAndDevicesPage>().IsBackToBrotherOnlineHomeButtonAvailable();
            CurrentPage.As<MyPrintersAndDevicesPage>().ValidateDeviceRegistrationInfo();
        }
    }
}
