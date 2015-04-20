using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.OmniJoin;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.OmniJoin
{
    [Binding]
    public class WebConferencingHomePageSteps : BaseSteps
    {
        [Given(@"I have navigated to the OmniJoin WebConferencing Home Page")]
        [Given(@"I have navigated to the OmniJoin home page")]
        public void GivenIHaveNavigatedToTheOmniJoinHomePage()
        {
            CurrentPage = BasePage.LoadWebConferencingHomePage(CurrentDriver, BasePage.BaseUrl);
            CurrentPage.As<WebConferencingHomePage>().IsBuyButtonAvailable();
        }

        [Then(@"I have clicked on Buy")]
        [Given(@"I have clicked on Buy")]
        public void GivenIHaveClickedOnBuy()
        {
            NextPage = CurrentPage.As<WebConferencingHomePage>().BuyButtonClick();
        }

    }
}
