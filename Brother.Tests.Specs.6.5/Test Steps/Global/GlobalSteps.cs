using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
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
            TestCheck.AssertIsEqual(true, Validation.ValidateWarningMessageBarStatus(true), "Warning Message Bar");
        }

        [Then(@"I should see the Information Bar activated and displaying an Information message")]
        public void ThenIShouldSeeTheInformationBarActivatedAndDisplayingAnInformationMessage()
        {
            TestCheck.AssertIsEqual(true, Validation.ValidateInformationMessageBarStatus(true), "Information Message Bar");
        }

        [Then(@"I should see the Error Message activated and displaying an Error message")]
        public void ThenIShouldSeeTheErrorMessageActivatedAndDisplayingAnErrorMessage()
        {
            Validation.CheckForErrorNotifications(true);
        }
    }
}
