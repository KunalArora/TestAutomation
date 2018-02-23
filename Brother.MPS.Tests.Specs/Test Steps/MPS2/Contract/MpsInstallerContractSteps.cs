using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Services;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Contract
{
    [Binding]
    public sealed class MpsInstallerContractSteps
    {
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly MpsInstallerContractStepActions _mpsInstallerContractStepActions;
        private readonly MpsDealerProposalStepActions _mpsDealerProposalStepActions;
        private readonly ITranslationService _translationService;

        //PageObjects
        private InstallerDeviceInstallationPage _installerDeviceInstallationPage;
        private InstallerContractReferenceInstallationPage _installerContractReferenceInstallationPage;

        public MpsInstallerContractSteps(MpsInstallerContractStepActions mpsInstallerContractStepActions,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            IWebDriver driver,
            ITranslationService translationService,
            MpsContextData contextData)
        {
            _driver = driver;
            _contextData = contextData;
            _mpsInstallerContractStepActions = mpsInstallerContractStepActions;
            _mpsDealerProposalStepActions = mpsDealerProposalStepActions;
            _translationService = translationService;
        }

        [When(@"a Brother installer has navigated to the Web Installation page and verify Contract Reference")]
        public void WhenABrotherInstallerHasNavigatedToTheWebInstallationPageAndVerifyContractReference()
        {
            var proposalId = _contextData.ProposalId;
            _installerContractReferenceInstallationPage = _mpsInstallerContractStepActions.NavigateToWebInstallationPage(_contextData.WebInstallUrl);
            _installerDeviceInstallationPage = _mpsInstallerContractStepActions.PopluateContractReferenceAndProceed(_installerContractReferenceInstallationPage, proposalId);
        }

        [When(@"a Brother installer has navigated to the Web Swap Installation page and verify Contract Reference")]
        public void WhenABrotherInstallerHasNavigatedToTheWebSwapInstallationPageAndVerifyContractReference()
        {
            var proposalId = _contextData.ProposalId;
            _installerContractReferenceInstallationPage = _mpsInstallerContractStepActions.NavigateToWebInstallationPage(_contextData.WebSwapInstallUrl);
            _installerDeviceInstallationPage = _mpsInstallerContractStepActions.PopluateContractReferenceAndProceed(_installerContractReferenceInstallationPage, proposalId);
        }

        [Given(@"that a Brother installer has navigated to the Web Installation page at ""(.*)""")]
        public void GivenThatABrotherInstallerHasNavigatedToTheWebInstallationPageAt(string url)
        {
            _installerContractReferenceInstallationPage = _mpsInstallerContractStepActions.NavigateToWebInstallationPage(url);
        }

        [When(@"I verify the Contract Reference for ""(.*)"" and store Serial Numbers for printers")]
        public void WhenIVerifyTheContractReferenceForAndStoreSerialNumbersForPrinters(int proposalId, Table printers)
        {
            var products = printers.CreateSet<PrinterProperties>();
            _contextData.PrintersProperties = products;
            _installerDeviceInstallationPage = _mpsInstallerContractStepActions.PopluateContractReferenceAndProceed(_installerContractReferenceInstallationPage, proposalId);
        }


        [When(@"Enter the serial numbers and complete installation")]
        public void WhenEnterTheSerialNumbersAndCompleteInstallation()
        {
            _mpsInstallerContractStepActions.PopulateSerialNumberAndCompleteInstallation(_installerDeviceInstallationPage, _driver);
        }


        [When(@"Enter the serial number for new device ""(.*)"" with new Mono ""(.*)"" and color ""(.*)"" print count and complete Installation")]
        public void WhenEnterTheSerialNumberForNewDeviceWithNewMonoAndColorPrintCountAndCompleteInstallation(string swapNewDeviceSerialNumber, int swapNewDeviceMonoPrintcount, int swapNewDeviceColourPrintcount )
        {
            string resourceSwapTypeReplaceThePcb = _translationService.GetSwapTypeText(TranslationKeys.SwapType.ReplaceThePcb, _contextData.Culture);
            _contextData.SwapNewDeviceMonoPrintCount = swapNewDeviceMonoPrintcount;
            _contextData.SwapNewDeviceColourPrintCount = swapNewDeviceColourPrintcount;
            if( resourceSwapTypeReplaceThePcb.Equals(_contextData.SwapType, StringComparison.OrdinalIgnoreCase) == false)
            {
                _mpsInstallerContractStepActions.PopulateSwapSerialNumber(_installerDeviceInstallationPage, _driver, swapNewDeviceSerialNumber);
            }
            _mpsInstallerContractStepActions.EnterSwapPrintCountAndCompleteInstallation(_installerDeviceInstallationPage, _contextData.SwapNewDeviceSerialNumber, swapNewDeviceMonoPrintcount, swapNewDeviceColourPrintcount);
        }

   }
}
