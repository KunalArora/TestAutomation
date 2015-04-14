using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement;
using Brother.Tests.Selenium.Lib.Pages.MPSOne;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSOne 
{
    [Binding]
    public class MpsOneSteps : BaseSteps
    {
        
        [Then(@"I am signed in with ""(.*)"" priviledges")]
        public void ThenIAmSignedInWithDealerPriviledges(string role)
        {
            ValidateMpsRolePrivileges(role);
        }

        private void ValidateMpsRolePrivileges(string role)
        {
            switch (role)
            {
                case "Dealer" :
                {
                    CurrentPage.As<WelcomeBackPage>().VerifyDealerPrivilege();
                    break;
                }
                case "Customer":
                {
                    CurrentPage.As<WelcomeBackPage>().VerifyCustomerPrivilege();
                    break;
                }
                case "Sales Dealer":
                {
                    CurrentPage.As<WelcomeBackPage>().VerifyDealerPrivilege();
                    break;
                }
            }
        }

        private void ValidatePageNavigatedToFromWelcomePage(string page, string country)
        {
            switch (page)
            {
                case "Contract":
                    {
                       NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToContractPage(country);
                        break;
                    }
                case "Proposal":
                    {
                        NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToProposalPage(country);
                        break;
                    }
                case "Technical Service":
                    {
                        NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToTechnicalServicePage(country);
                        break;
                    }
                case "Consumable":
                    {
                        NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToConsumablePage(country);
                        break;
                    }
                case "List of Organisation":
                    {
                        NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToListOfOrganisationsPage(country);
                        break;
                    }
            }
        }

       private void VerifyCorrectPageIsDisplayed(string page)
        {
            switch (page)
           {
               case "Contract":
               {
                    CurrentPage.As<ExistingContractPage>().IsContractHeaderAvailable();
                    break;
                }
                case "Proposal":
                {
                    CurrentPage.As<ExistingProposalPage>().IsProposalHeaderAvailable();
                    break;
                }
                case "List of Organisation":
                {
                    CurrentPage.As<ListOfOrganisationsPage>().IsOrganisationHeaderAvailable();
                    break;
                }
           }
        }

        [Given(@"""(.*)"" privileges are available for use")]
        public void GivenPrivilegesAreAvailableForUse(string role)
        {
            ThenIAmSignedInWithDealerPriviledges(role);
        }

        [Given(@"I navigate to ""(.*)"" page from ""(.*)"" Welcome page")]
        [When(@"I navigate to ""(.*)"" page from ""(.*)"" Welcome page")]
        public void WhenINavigateToPageFromWelcomePage(string page, string country)
        {
            ValidatePageNavigatedToFromWelcomePage(page, country);
        }

        //[Given(@"I navigate to ""(.*)"" page from ""(.*)"" Welcome page")]
        //public void GivenINavigateToPageFromWelcomePage(string page, string country)
        //{
        //    ValidatePageNavigatedToFromWelcomePage(page, country);
        //}


        [Then(@"""(.*)"" page is displayed")]
        public void ThenPageIsDisplayed(string page)
        {
            VerifyCorrectPageIsDisplayed(page);


        }

        [Then(@"I can get to ""(.*)"" contract overview page for the contract")]
        public void ThenICanGetToContractOverviewPageForTheContract(string country)
        {
           // CurrentPage.As<ExistingContractPage>().IsContractHeaderAvailable();
            NextPage = CurrentPage.As<ExistingContractPage>().ClickTheFirstContractOnTheList(country);
            CurrentPage.As<ContractConfirmationPage>().IsExistingContractDescriptionAvailable();
            CurrentPage.As<ContractConfirmationPage>().VerifyTheCorrectContractIdIsDisplayed();
        }

    }


}
