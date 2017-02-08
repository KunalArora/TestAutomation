using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.EnhancedUsageMonitoring
{
    [Binding]
    public class EnhancedUsageMonitoringSteps : BaseSteps
    {
        [When(@"I navigate to Enhanced Usage Monitoring Installed Page")]
        [Then(@"I navigate to Enhanced Usage Monitoring Installed Page")]
        [Given(@"I navigate to Enhanced Usage Monitoring Installed Page")]
        public void GivenINavigateToEnhancedUsageMonitoringInstalledPage()
        {
           CurrentPage.As<BieAdminDashboardPage>().IsBieAdminDashboardDisplayed();
           NextPage = CurrentPage.As<BieAdminDashboardPage>().NavigateToEnhancedUsageMonitoringPage();

        }

        [Given(@"I navigate to Enhanced Usage Monitoring Printer Engine Page")]
        public void GivenINavigateToEnhancedUsageMonitoringPrinterEnginePage()
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().IsInstalledPrinterPageDisplayed();
            NextPage =
                CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>()
                    .NavigateToEnhancedUsageMonitoringPrinterEnginePage();
        }

        [When(@"I select the ""(.*)"" printer engine")]
        public void WhenISelectThePrinterEngine(string country)
        {
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().IsEnhancedUsageMonitoringPrinterEnginePageDisplayed();
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().IsCountryDropdownMenuWorking(country);
        }

        [Then(@"all the printer engine for that country is displayed")]
        public void ThenAllThePrinterEngineForThatCountryIsDisplayed()
        {
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().IsPrinterEngineListDisplayed();
        }


        [When(@"I search for contract using contract id")]
        public void WhenISearchForContractUsingContractId()
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>()
                    .SearchForContract();
        }

        [Then(@"contract printer details are displayed")]
        public void ThenContractPrinterDetailsAreDisplayed()
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>()
                    .IsEnhancedUsageMonitoringProposalInformationDisplayed();
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>()
                    .IsEnhancedUsageMonitoringContractPrinterInfoDisplayed();
        }

        [When(@"I search for an invalid contract id ""(.*)""")]
        public void WhenISearchForAnInvalidContractId(string id)
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>()
                    .SearchForContract(id);
        }

        [Then(@"an error message is displayed")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().IsErrorMessageDisplayed();
        }


        [Then(@"I can enter a threshold of ""(.*)"" into all the thresholds")]
        public void ThenICanEnterAThresholdOfIntoAllTheThresholds(string threshold)
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().EnterThresholdValues(threshold);
        }

        [Then(@"I can enabled all the devices")]
        public void ThenICanEnabledAllTheDevices()
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().EnableAllCheckBoxes();
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().SaveChanges();
        }

        [Then(@"I can verify that all the changes made are with threshold of ""(.*)""")]
        public void ThenICanVerifyThatAllTheChangesMadeAreWithThresholdOf(string threshold)
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().IsThresholdValuesSaved(threshold);
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().IsCheckBoxChecked();
        }

        [Then(@"I can disable all the thresholds")]
        public void ThenICanDisableAllTheThresholds()
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().EnableAllCheckBoxes();
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().SaveChanges();
        }



    }
}
