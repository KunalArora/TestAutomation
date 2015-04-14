using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Account;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Global
{
    [Binding]
    public class GlobalSteps : BaseSteps
    {
        [Then(@"I should see the Warning Bar activated and displaying a warning message")]
        public void ThenIShouldSeeTheWarningBarActivatedAndDisplayingAWarningMessage()
        {
            Assert.AreEqual(true, Validation.ValidateWarningMessageBarStatus(true), "Warning Message Bar");
        }

        [Then(@"I should see the Information Bar activated and displaying an Information message")]
        public void ThenIShouldSeeTheInformationBarActivatedAndDisplayingAnInformationMessage()
        {
            Assert.AreEqual(true, Validation.ValidateInformationMessageBarStatus(true), "Information Message Bar");
        }
    }
}
