
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Net;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace Brother.Tests.Specs._80.Test_Steps.BrotherMainSite.PublishedPages
{
    [Binding]
    public class PublishedPagesSteps : BaseSteps
    {
        [Given(@"I have navigated to the published url ""(.*)""")]
        public void GivenIHaveNavigatedToTheUrl(string p0)
        {
            CurrentDriver.Navigate().GoToUrl(p0);
            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));
        }

        [Given(@"That I navigate to ""(.*)"" in order to validate a published page")]
        public void GivenThatINavigateToInOrderToValidateTheCmsSite(string url)
        {
            CurrentPage = BasePage.LoadPublishedPage(CurrentDriver, url);
            CurrentPage.As<PublishedPage>().GetPublishedPage(url);
        }

        [Then(@"I can verify that the page header is displayed")]
        public void ThenICanVerifyThatThePageHeaderIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsPageHeaderDisplayed();
        }

        [Then(@"I can validate the product page title is displayed")]
        public void ThenICanValidateTheProductPageTitleIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsPageTitleDisplayed();
        }

        [Then(@"I can validate supply description is displayed")]
        public void ThenICanValidateSupplyDescriptionIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsSupplyDescriptionDisplayed();
        }

        [Then(@"I can validate printers filter section is displayed")]
        public void ThenICanValidatePrintersFilterSectionIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFilterSectionDisplayed();
        }

        [Then(@"I can validate supplies section is displayed")]
        public void ThenICanValidateSuppliesSectionIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFindOutMoreButtonDisplayed();
        }

        [Then(@"I can validate accessory product title is displayed")]
        public void ThenICanValidateAccessoryProductTitleIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsAccessoryProductTitleDisplayed();
        }

        [Then(@"I can validate glossary section is displayed")]
        public void ThenICanValidateGlossarySectionIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsGlossarySectionDisplayed();
        }

        [Then(@"I can validate article is displayed on the page")]
        public void ThenICanValidateArticleIsDisplayedOnThePage()
        {
            CurrentPage.As<PublishedPage>().IsPageArticleDisplayed();
        }

        [Then(@"I can verify that the search icon is displayed")]
        public void ThenICanVerifyThatTheSearchIconIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsSearchIconDisplayed();
        }

        [Then(@"I can verify that the top navigation component is displayed")]
        public void ThenICanVerifyThatTheTopNavigationComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsTopNavDisplayed();
        }

        [Then(@"I can verify that the accordion compoment is displayed")]
        public void ThenICanVerifyThatTheAccordionCompomentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsAccordionDisplayed();
        }

        [Then(@"I can verify that the features carousel component is displayed")]
        public void ThenICanVerifyThatTheFeaturesCarouselComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFeaturesCarouselDisplayed();
        }

        [Then(@"I can verify that a features carousel tile is displayed")]
        public void ThenICanVerifyThatAFeaturesCarouselTileIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFeaturesCarouselTileDisplayed();
        }

        [Then(@"I can verify that a banner bar component is displayed")]
        public void ThenICanVerifyThatABannerBarComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsBannerBarDisplayedDisplayed();
        }

        [Then(@"I can verify that a banner bar tile is displayed")]
        public void ThenICanVerifyThatABannerBarTileIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsBannerBarTileDisplayed();
        }

        [Then(@"I can verify that an info image text module component is displayed")]
        public void ThenICanVerifyThatAnInforImageTextModuleComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsImageTextModuleDisplayed();
        }

        [Then(@"I can verify that the secondary navigation component is displayed")]
        public void ThenICanVerifyThatTheSecondaryNavigationComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsSecondaryNavigationDisplayed();
        }

        [Then(@"I can verify that the breadcrumbs component is displayed")]
        public void ThenICanVerifyThatTheBreadcrumbsComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsBreadcrumbsDisplayed();
        }

        [Then(@"I can verify the case study component is displayed")]
        public void ThenICanVerifyTheCaseStudyComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsCaseStudyDisplayed();
        }

        [Then(@"I can verify that the contact bar component is displayed")]
        public void ThenICanVerifyThatTheContactBarComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsContactBarDisplayed();
        }

        [Then(@"I can verify that the benefit bar component is displayed")]
        public void ThenICanVerifyThatTheBenefitBarComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsBenefitBarDisplayed();
        }

        [Then(@"I can verify that the benefit bar tile component is displayed")]
        public void ThenICanVerifyThatTheBenefitBarTileComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsBenefitBarTileDisplayed();
        }

        [Then(@"I can verify that the latest news component is displayed")]
        public void ThenICanVerifyThatTheLatestNewsComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsLatestNewsDisplayed();
        }

        [Then(@"I can verify that the header bar component is displayed")]
        public void ThenICanVerifyThatTheHeaderBarComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsHeaderBarDisplayed();
        }

        [Then(@"I can verify that the full info tile component is displayed")]
        public void ThenICanVerifyThatTheFullInfoTileComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFullInfoTileDisplayed();
        }

        [Then(@"I can verify that the hero component is displayed")]
        public void ThenICanVerifyThatTheHeroComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsHeroDisplayed();
        }

        [Then(@"I can verify that the secondary hero component is displayed")]
        public void ThenICanVerifyThatTheSecondaryHeroComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsSecondaryHeroDisplayed();
        }

        [Then(@"I can verify that the feature module image left is displayed")]
        public void ThenICanVerifyThatTheFeatureModuleImageLeftIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFeatureModuleLeftDisplayed();
        }


        [Then(@"I can verify that the feature module image right is displayed")]
        public void ThenICanVerifyThatTheFeatureModuleImageRightIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFeatureModuleRightDisplayed();
        }

        [Then(@"I can verify that the feature bar component is displayed")]
        public void ThenICanVerifyThatTheFeatureBarComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFeatureBarComponentDisplayed();
        }

        [Then(@"I can verify that the feature bar tile is displayed")]
        public void ThenICanVerifyThatTheFeatureBarTileIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFeatureBarTileDisplayed();
        }

        [Then(@"I can verify that the super carousel component is displayed")]
        public void ThenICanVerifyThatTheSuperCarouselComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsSuperCarouselDisplayed();
        }

        [Then(@"I can verify that the video list module is displayed")]
        public void ThenICanVerifyThatTheVideoListModuleIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsVideoListModuleDisplayed();
        }

        [Then(@"I can verify that the video tile bar is displayed")]
        public void ThenICanVerifyThatTheVideoTileBarIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsVideoTileBarModuleDisplayed();
        }

        [Then(@"I can verify that the full width hero is displayed")]
        public void ThenICanVerifyThatTheFullWidthHeroIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFullWidthHeroDisplayed();
        }

        [Then(@"I can verify that the special full info is displayed")]
        public void ThenICanVerifyThatTheSpecialFullInfoIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsSpecialFullInfoDisplayed();
        }

        [Then(@"I can verify that the conversion bar is displayed")]
        public void ThenICanVerifyThatTheConversionBarIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsConversionBarDisplayed();
        }

        [Then(@"I can verify that the wizard is displayed")]
        public void ThenICanVerifyThatTheWizardIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsWizardDisplayed();
        }

        [Then(@"I can verify that the special feature is displayed")]
        public void ThenICanVerifyThatTheSpecialFeatureIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsSpecialFeatureDisplayed();
        }

        [Then(@"I can verify that the steps bar is displayed")]
        public void ThenICanVerifyThatTheStepsBarIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsStepsBarDisplayed();
        }

        [Then(@"I can verify that the hero carousel is displayed")]
        public void ThenICanVerifyThatTheHeroCarouselIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsHeroCarouselDisplayed();
        }

        [Then(@"I can verify that the wizard step is displayed")]
        public void ThenICanVerifyThatTheWizardStepIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsWizardStepDisplayed();
        }

        [Then(@"I can verify that the rich text module is displayed")]
        public void ThenICanVerifyThatTheRichTextModuleIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsRichTextModuleDisplayed();
        }

        [Then(@"I can Verify that the link list item is displayed")]
        public void ThenICanVerifyThatTheLinkListItemIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsListItemIsDisplayed();
        }

        [Then(@"I can verify that the Wffm component is displayed")]
        public void ThenICanVerifyThatTheWffmComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsWffmDisplayed();
        }

        [Given(@"I fill in the registration information using a valid email address")]
        public void GivenIFillInTheRegistrationInformationUsingAValidEmailAddress(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<PublishedPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<PublishedPage>().PopulateLastNameTextBox(form.LastName);
            WhenIEnterAValidEmailAddress(string.Empty); // Auto Generates with an empty string
        }

        public void WhenIEnterAValidEmailAddress(string validEmailAddress)
        {
            CurrentPage.As<PublishedPage>().PopulateEmailAddressTextBox(validEmailAddress);
        }

        [Given(@"I enter phone number as ""(.*)""")]
        public void GivenIEnterPhoneNumberAs(string phoneNumber)
        {
            CurrentPage.As<PublishedPage>().PopulatePhoneNumberTextBox(phoneNumber);
        }
        [Given(@"I click Accept Cookie Button")]
        public void GivenIClickAcceptCookieButton()
        {
            CurrentPage.As<PublishedPage>().ClickAcceptCookieButton();
        }
        [Given(@"I have Agreed to the Terms and Conditions")]
        public void GivenIHaveAgreedToTheTermsAndConditions()
        {
            CurrentPage.As<PublishedPage>().CheckTermsAndConditions();
        }

        [Given(@"I press submit button ""(.*)""")]
        public void GivenIPressSubmitButton(string country)
        {
            NextPage = CurrentPage.As<PublishedPage>().ClickSubmitButton(country);
        }

        [Then(@"I should see download page")]
        public void ThenIShouldSeeDownloadPage()
        {
            CurrentPage.As<DownloadPage>().VerifyPageTitleExist();
        }

    }

}

