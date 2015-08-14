using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs
{
    [Binding]
    public class RoleValidation : BaseSteps
    {
        [Given(@"I cannot see the Instant Ink menu option from the BOL home page")]
        public void GivenICannotSeeTheInstantInkMenuOptionFromTheBolHomePage()
        {
            //var menuItem  = GlobalNavigationModule.GetProductNavigationMenu("InstantInk");

            TestCheck.AssertIsEqual(true, CurrentPage.As<WelcomeBackPage>().IsInkSupplyMenuItemMissing(),
                "Ink Supply Menu does not exist");
        }

        [Then(@"I can see the Instant Ink menu option from the BOL home page")]
        public void ThenICanSeeTheInstantInkMenuOptionFromTheBolHomePage()
        {
            CurrentPage.As<WelcomeBackPage>().IsInkSupplyMenuItemAvailable();
        }

        [Then(@"I can see the Ink Supply Status Monitor button")]
        public void ThenICanSeeTheInkSupplyStatusMonitorButton()
        {
            var statusMonitorButton = GlobalNavigationModule.GetInstantInkMenuButton("StatusMonitor");
            TestCheck.AssertIsNotEqual(null, statusMonitorButton, "Check Status Monitor button is present");
        }

        [When(@"I click on Status Monitor")]
        [Then(@"If I click on Status Monitor")]
        public void ThenIfIClickOnStatusMonitor()
        {
            var statusMonitorButton = GlobalNavigationModule.GetInstantInkMenuButton("StatusMonitor");
            NextPage = GlobalNavigationModule.StatusMonitorButtonClick(CurrentDriver, statusMonitorButton);
        }

        [Then(@"I can see the Status Monitor page")]
        public void ThenICanSeeTheStatusMonitorPage()
        {

        }
    }
}
