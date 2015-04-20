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
            var menuItem  = GlobalNavigationModule.GetProductNavigationMenu("InstantInk");
            Assert.AreEqual(null, menuItem, "Unable to detect Instant Ink Menu Item");
        }

        [Then(@"I can see the Instant Ink menu option from the BOL home page")]
        public void ThenICanSeeTheInstantInkMenuOptionFromTheBolHomePage()
        {
            var menuItem = GlobalNavigationModule.GetProductNavigationMenu("InstantInk");
            Assert.AreNotEqual(null, menuItem);
        }

        [Then(@"If I click on Ink Supply")]
        public void ThenIfIClickOnInkSupply()
        {
            var menuItem  = GlobalNavigationModule.GetProductNavigationMenu("InstantInk");
            menuItem.Click();
        }

        [Then(@"I can see the Ink Supply Status Monitor button")]
        public void ThenICanSeeTheInkSupplyStatusMonitorButton()
        {
            var statusMonitorButton = GlobalNavigationModule.GetInstantInkMenuButton("StatusMonitor");
            Assert.AreNotEqual(null, statusMonitorButton);
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
