using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.WebSites.Core.Pages.Base;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPSTwo.Proposal
{
    [Binding]
    public class LocalOfficeApproverSteps : BaseSteps
    {
        [When(@"I navigate to Local Office Approver contract Awaiting Acceptance page")]
        public void WhenINavigateToLocalOfficeApproverContractAwaitingAcceptancePage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I navigate to Local Office Approver contract Rejected page")]
        public void WhenINavigateToLocalOfficeApproverContractRejectedPage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
