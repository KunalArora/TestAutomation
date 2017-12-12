﻿using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Domain.Enums;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Contract
{
    [Binding]
    public sealed class MpsInstallerContractSteps
    {
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly MpsInstallerContractStepActions _mpsInstallerContractStepActions;
        private readonly MpsDealerProposalStepActions _mpsDealerProposalStepActions;

        //PageObjects
        private InstallerDeviceInstallationPage _installerDeviceInstallationPage;
        private InstallerContractReferenceInstallationPage _installerContractReferenceInstallationPage;
        
        public MpsInstallerContractSteps(MpsInstallerContractStepActions mpsInstallerContractStepActions,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            IWebDriver driver,
            MpsContextData contextData)
        {
            _driver = driver;
            _contextData = contextData;
            _mpsInstallerContractStepActions = mpsInstallerContractStepActions;
            _mpsDealerProposalStepActions = mpsDealerProposalStepActions;
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
            var products = _contextData.PrintersProperties;
            var installerWindowHandle = _contextData.WindowHandles[UserType.Installer];
            _mpsInstallerContractStepActions.PopulateSerialNumberAndCompleteInstallation(_installerDeviceInstallationPage, products, _driver, installerWindowHandle);
        }


        [When(@"Enter the serial number for new device ""(.*)"" with new Mono ""(.*)"" and color ""(.*)"" print count and complete Installation")]
        public void WhenEnterTheSerialNumberForNewDeviceWithNewMonoAndColorPrintCountAndCompleteInstallation(string swapNewDeviceSerialNumber, int swapNewDeviceMonoPrintcount, int swapNewDeviceColourPrintcount)
        {
            _contextData.SwapNewDeviceMonoPrintCount = swapNewDeviceMonoPrintcount;
            _contextData.SwapNewDeviceColourPrintCount = swapNewDeviceColourPrintcount;
            var products = _contextData.PrintersProperties;
            var installerWindowHandle = _contextData.WindowHandles[UserType.Installer];
            _mpsInstallerContractStepActions.PopulateSwapSerialNumber(_installerDeviceInstallationPage, products, _driver, swapNewDeviceSerialNumber, installerWindowHandle);
            _mpsInstallerContractStepActions.EnterSwapPrintCountAndCompleteInstallation(_installerDeviceInstallationPage, products, swapNewDeviceSerialNumber, swapNewDeviceMonoPrintcount, swapNewDeviceColourPrintcount);
        }

   }
}