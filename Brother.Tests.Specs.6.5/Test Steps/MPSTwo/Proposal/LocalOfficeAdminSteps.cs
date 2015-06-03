using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class LocalOfficeAdminSteps : BaseSteps
    {
        [Given(@"I enable Easy Print Pro contract")]
        public void GivenIEnableEasyPrintProContract()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToPurchaseAndClickPage();
            CurrentPage.As<EasyPrintProPage>().EnableContractType();
        }

        [Given(@"I navigate to Local Office Admin Dashboard page")]
        public void GivenINavigateToLocalOfficeAdminDashboardPage()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToLOAdminDashboard();
        }

        [When(@"I navigate to Dealer Defaults page")]
        public void WhenINavigateToDealerDefaultsPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToDealerDefaultsPage();
        }

        [When(@"I can set the default margins for all contracts")]
        public void WhenICanSetTheDefaultMarginsForAllContracts()
        {
            NextPage = CurrentPage.As<DealerDefaultsPage>().SaveDealerDefaults();
        }


        [Given(@"I enable product to be displayed as a flat list for a paticular contract type")]
        public void GivenIEnableProductToBeDisplayedAsAFlatListForAPaticularContractType()
        {
            When(@"I navigate to Purchase And Click page");
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().TickDisplayProductsAsList();
        }

        [Given(@"I navigate to Purchase And Click page")]
        [When(@"I navigate to Purchase And Click page")]
        public void WhenINavigateToPurchaseAndClickPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToPurchaseAndClickPage();
        }

        [When(@"I navigate to Lease And Click page")]
        public void WhenINavigateToLeaseAndClickPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToLeaseAndClickPage();
        }

        [When(@"I tick Dispaly Product as List Button")]
        public void WhenITickDispalyProductAsListButton()
        {
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().TickDisplayProductsAsList();
        }

        [Given(@"I navigate to Printers page")]
        [When(@"I navigate to Printers page")]
        public void WhenINavigateToPrintersPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminProgramSettingPage>().NavigateToLocalOfficePrintersPage();
        }

        [Given(@"I enabled ""(.*)"" within the Printer screen")]
        public void GivenIEnabledWithinThePrinterScreen(string model)
        {
            CurrentPage.As<LocalOfficePrintersPage>().EnablePrinter(model);
        }

        [Given(@"I disabled ""(.*)"" within the Printer screen")]
        public void GivenIDisabledWithinThePrinterScreen(string model)
        {
            CurrentPage.As<LocalOfficePrintersPage>().DisablePrinter(model);
        }

        [Given(@"I save printers on Available Printers page")]
        public void GivenISavePrintersOnAvailablePrintersPage()
        {
            CurrentPage.As<LocalOfficePrintersPage>().ClickSaveButton();
        }

    }
}
