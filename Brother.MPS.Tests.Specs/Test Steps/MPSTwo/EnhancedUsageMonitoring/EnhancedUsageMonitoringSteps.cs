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

        [Then(@"I navigate to Enhanced Usage Monitoring Printer Engine Page")]
        [When(@"I navigate to Enhanced Usage Monitoring Printer Engine Page")]
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

        [When(@"I select ""(.*)"" as country of interest")]
        public void WhenISelectAsCountryOfInterest(string country)
        {
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().IsCountryDropdownMenuWorking(country);
        }


        [When(@"I enable the mono threshold ""(.*)""")]
        public void WhenIEnableTheMonoThreshold(string threshold)
        {
            //BC2 mono threshold and tickbox enabled
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnterPrinterThreshold(threshold, "0");
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnablePrinterMonoThreshold("0");

            //DCL mono threshold and tickbox enabled
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnterPrinterThreshold(threshold, "17");
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnablePrinterMonoThreshold("17");

            //DLL mono threshold and tickbox enabled
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnterPrinterThreshold(threshold, "22");
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnablePrinterMonoThreshold("22");

            //DLH Step mono threshold and tickbox enabled
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnterPrinterThreshold(threshold, "21");
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnablePrinterMonoThreshold("21");
        }

        [When(@"I enable the colour threshold ""(.*)""")]
        public void WhenIEnableTheColourThreshold(string threshold)
        {
            //BC2 mono threshold and tickbox enabled
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnterPrinterThreshold(threshold, "1");
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnablePrinterColourThreshold("1");

            //DCL mono threshold and tickbox enabled
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnterPrinterThreshold(threshold, "18");
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().EnablePrinterColourThreshold("18");

        }

        [When(@"I disable Engine threshold")]
        public void WhenIDisableTheEngineThreshold()
        {
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().DisablePrinterThreshold("0");
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().DisablePrinterThreshold("1");
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().DisablePrinterThreshold("17");
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().DisablePrinterThreshold("21");
        }


        [When(@"I save the changes made above")]
        public void WhenISaveTheChangesMadeAbove()
        {
            CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>().SaveChanges();
        }


        [When(@"I navigate to installed printer page")]
        public void WhenINavigateToInstalledPrinterPage()
        {
            NextPage =
                CurrentPage.As<EnhancedUsageMonitoringPrinterEnginePage>()
                    .NavigateToEnhancedUsageMonitoringInstalledPrinterPage();
        }

        [When(@"I enter toner ink threshold of ""(.*)"" for all the printers")]
        public void WhenIEnterTonerInkThresholdOfForAllThePrinters(string threshold)
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().EnterThresholdValues(threshold);
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().SaveChanges();
        }

        [When(@"I enable the threshold for all the printers")]
        public void WhenIEnableTheThresholdForAllThePrinters()
        {
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().EnableAllCheckBoxes();
            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().SaveChanges();
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

            CurrentPage.As<EnhancedUsageMonitoringInstalledPrinterPage>().IsCheckBoxUnChecked();
        }



    }
}
