using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal  
{
    [Binding]
    public class VerificationOnClickPricesVolumeAndMargin : BaseSteps
    {
        [Then(@"changes in a field affect the values in the corresponding fields")]
        public void ThenChangesInAFieldAffectTheValuesInTheCorrespondingFields()
        {
           CurrentPage.As<CreateNewProposalPage>().VerifyThatModelScreenFieldsRespondToChanges();
           //CurrentPage.As<CreateNewProposalPage>().VerifyInstallationScreenFieldsRespondToChanges();
           CurrentPage.As<CreateNewProposalPage>().VerifyProductOptionFieldsRespondToChangesAppropriately();
        }

        [Then(@"click prices are changed accordingly")]
        public void ThenClickPricesAreChangedAccordingly()
        {
            CurrentPage.As<CreateNewProposalPage>().VerifyThatClickPriceFieldsArePopulatedOrNot();
            CurrentPage.As<CreateNewProposalPage>().VerifyChangesToClickPricesGetCascaded();
        }

    }
}
