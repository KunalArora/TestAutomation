using System.Diagnostics;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class LocalOfficeAdminSteps : BaseSteps
    {
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
            NextPage = CurrentPage.As<LocalOfficeAdminDealerDefaultsPage>().SaveDealerDefaults();
        }

        [Given(@"I enable product to be displayed as a flat list for a paticular contract type")]
        public void GivenIEnableProductToBeDisplayedAsAFlatListForAPaticularContractType()
        {
            When(@"I navigate to Purchase And Click page");
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().TickDisplayProductsAsList();
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().ClickSave();
        }

        [Then(@"I enable product to be displayed with images for a paticular contract type")]
        public void GivenIEnableProductToBeDisplayedWithImagesForAPaticularContractType()
        {
            When(@"I navigate to Purchase And Click page");
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().UntickDisplayProductsAsList();
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().ClickSave();
        }

        [Given(@"I navigate to Purchase And Click page")]
        [When(@"I navigate to Purchase And Click page")]
        public void WhenINavigateToPurchaseAndClickPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToPurchaseAndClickPage();
        }

        [Given(@"I navigate to Lease And Click page")]
        [When(@"I navigate to admin Lease And Click page")]
        public void WhenINavigateToLeaseAndClickPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToLeaseAndClickPage();
        }

        [When(@"I navigate to All In Click Page")]
        public void WhenINavigateToAllInClickPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToAllInClickPage();
        }

        [When(@"I tick Dispaly Product as List Button")]
        public void WhenITickDispalyProductAsListButton()
        {
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().TickDisplayProductsAsList();
        }

        [Given(@"I navigate to Printers page on Purchase And Click as a Local Office Admin")]
        [When(@"I navigate to Printers page on Purchase And Click as a Local Office Admin")]
        public void WhenINavigateToPurchasePrintersPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminProgramSettingPage>().NavigateToLocalOfficePurchasePrintersPage();
        }

        [Given(@"I navigate to Printers page on Lease And Click as a Local Office Admin")]
        [When(@"I navigate to Printers page on Lease And Click as a Local Office Admin")]
        public void WhenINavigateToLeasePrintersPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminProgramSettingPage>().NavigateToLocalOfficeLeasePrintersPage();
        }

        [Given(@"I enabled ""(.*)"" within the Printer screen")]
        public void GivenIEnabledWithinThePrinterScreen(string model)
        {
            CurrentPage.As<LocalOfficeAdminPrintersPage>().EnablePrinter(model);
        }

        [Given(@"I disabled ""(.*)"" within the Printer screen")]
        public void GivenIDisabledWithinThePrinterScreen(string model)
        {
            CurrentPage.As<LocalOfficeAdminPrintersPage>().DisablePrinter(model);
        }

        [Given(@"I save printers on Available Printers page")]
        public void GivenISavePrintersOnAvailablePrintersPage()
        {
            CurrentPage.As<LocalOfficeAdminPrintersPage>().ClickSaveButton();
        }

        [When(@"I navigate to Leasing Bank screen")]
        public void WhenINavigateToLeasingBankScreen()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminProgramSettingPage>().NavigateToLocalOfficeLeasingBanksPage();
        }

        [Then(@"I can edit the Sell Price vs SRP Constraint % for an existing Leasing bank")]
        public void ThenICanEditTheSellPriceVsSRPConstraintForAnExistingLeasingBank()
        {
            var page = CurrentPage.As<LocalOfficeAdminLeasingBanks>();
            page.ClickEditButton();
            page.EditSellPriceVsSrpConstraint();
            page.ClickSaveButton();
            page.ClickEditButton();
            page.VerifyEditedSellPriceValue();
        }

        [Then(@"I can set one-off dealer ""(.*)"" margin")]
        public void ThenICanSetOne_OffDealerMargin(string marginType)
        {
            var page = CurrentPage.As<LocalOfficeAdminDealerDefaultsPage>();
            switch (marginType)
            {
                case "Hardware":
                    page.SelectHardwareDefaultMargin();
                    page.ReloadPage();
                    page.CheckHardwareDefaultMargin();
                    break;
                case "Delivery":
                    page.SelectDeliveryDefaultMargin();
                    page.ReloadPage();
                    page.CheckDeliveryDefaultMargin();
                    break;
                case "Accessories":
                    page.SelectAccesoriesDefaultMargin();
                    page.ReloadPage();
                    page.CheckAccesoriesDefaultMargin();
                    break;
                case "Installation":
                    page.SelectInstallationDefaultMargin();
                    page.ReloadPage();
                    page.CheckInstallationDefaultMargin();
                    break;
                case "Service Pack":
                    page.SelectServicePackDefaultMargin();
                    page.ReloadPage();
                    page.CheckServicePackDefaultMargin();
                    break;
                case "Mono Click":
                    page.SelectMonoClickDefaultMargin();
                    page.ReloadPage();
                    page.CheckMonoClickDefaultMargin();
                    break;
                case "Colour Click":
                    page.SelectColourClickDefaultMargin();
                    page.ReloadPage();
                    page.CheckColourClickDefaultMargin();
                    break;
                case "All Inclusive":
                    page.SelectAllInclusiveDefaultMargin();
                    page.ReloadPage();
                    page.CheckAllInclusiveDefaultMargin();
                    break;
            }
        }

        [When(@"I navigate to Program Setting page of ""(.*)"" page")]
        public void WhenINavigateToProgramSettingPageOfPage(string page)
        {
            switch (page)
            {
                case "Lease and Click":
                    When(@"I navigate to admin Lease And Click page");
                    break;

                case "Purchase and Click":
                    When(@"I navigate to Purchase And Click page");
                    break;

                case "All In Click":
                    When(@"I navigate to All In Click Page");
                    break;
            }
        }

        [Then(@"I can switch ""(.*)"" ""(.*)"" Usage Type")]
        public void ThenICanSwitchUsageType(string newState, string usageType)
        {
            var page = CurrentPage.As<LocalOfficeAdminProgramSettingPage>();
            switch (usageType)
            {
                case "Minimum Volume":
                    if (newState == "On")
                    {
                        page.TryTickMinimumVolume();
                        page.ClickSave();
                        page.IsMinimumVolumeTicked();

                    }
                    else
                    {
                        page.TryUntickMinimumVolume();
                        page.ClickSave();
                        page.IsMinimumVolumeUnticked();
                    }
                    break;

                case "Pay As You Go":
                    if (newState == "On")
                    {
                        page.TryTickPayAsYouGo();
                        page.ClickSave();
                        page.IsPayAsYouGoTicked();
                    }
                    else
                    {
                        page.TryUntickPayAsYouGo();
                        page.ClickSave();
                        page.IsPayAsYouGoUnticked();
                    }
                    break;
            }
        }
    }
}