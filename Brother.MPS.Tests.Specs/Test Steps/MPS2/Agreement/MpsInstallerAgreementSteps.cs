using Brother.Tests.Common.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Installer;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Agreement
{
    [Binding]
    public class MpsInstallerAgreementSteps
    {
        private readonly IContextData _contextData;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsInstallerAgreementStepActions _mpsInstallerAgreement;

        private InstallationCloudWebPage _installationCloudWebPage;
        private InstallationCloudToolPage _installationCloudToolPage;

        public MpsInstallerAgreementSteps(
            MpsContextData contextData,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            MpsInstallerAgreementStepActions mpsInstallerAgreement)
        {
            _contextData = contextData;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsInstallerAgreement = mpsInstallerAgreement;
        }

        [When(@"a Cloud MPS Installer is able to install devices one by one using ""(.*)"" communication and ""(.*)"" installation")]
        public void WhenACloudMPSInstallerIsAbleToInstallDevicesOneByOneUsingCommunicationAndInstallation(string communicationMethod, string installationType)
        {
            _contextData.CommunicationMethod = communicationMethod;
            _contextData.InstallationType = installationType;
            if (communicationMethod.ToLower().Equals("cloud") && installationType.ToLower().Equals("bor"))
            {
                _mpsInstallerAgreement.InstallDevicesOneByOneForCloudBor();
            }
            else
            {
                Assert.Fail(
                    string.Format(
                    "Single device Installation steps for communication method {0} & installation type {1} not implemented yet", communicationMethod, installationType));
            }
        }

        [When(@"a Cloud MPS Installer is able to bulk install the devices using ""(.*)"" communication and ""(.*)"" installation")]
        public void WhenACloudMPSInstallerIsAbleToBulkInstallTheDevicesUsingCommunicationAndInstallation(string communicationMethod, string installationType)
        {
            _contextData.CommunicationMethod = communicationMethod;
            _contextData.InstallationType = installationType;
            if (communicationMethod.ToLower().Equals("cloud") && installationType.ToLower().Equals("bor"))
            {
                _installationCloudToolPage = _mpsInstallerAgreement.BulkInstallDevicesForCloudBor();
            }
            else if (communicationMethod.ToLower().Equals("cloud") && installationType.ToLower().Equals("web"))
            {
                _installationCloudWebPage = _mpsInstallerAgreement.BulkInstallDevicesForCloudWeb();
            }
            else
            {
                Assert.Fail(
                    string.Format(
                    "Bulk device Installation steps for communication method {0} & installation type {1} not implemented yet", communicationMethod, installationType));
            }
        }

        [StepDefinition(@"a Cloud MPS Installer Verify Single Quantity Model Serial Number are auto assigned")]
        public void WhenACloudMPSInstallerVerifySingleQuantityModelSerialNumberAreAutoAssigned()
        {
            _mpsInstallerAgreement.VerifySingleQuantityModelSerialNumberAreAutoAssigned();
        }


        [When(@"a Cloud MPS Installer is able to do both single device and bulk installation using ""(.*)"" communication and ""(.*)"" installation")]
        public void WhenACloudMPSInstallerIsAbleToDoBothSingleDeviceAndBulkInstallationUsingCommunicationAndInstallation(string communicationMethod, string installationType)
        {
            _contextData.CommunicationMethod = communicationMethod;
            _contextData.InstallationType = installationType;
            if (communicationMethod.ToLower().Equals("cloud") && installationType.ToLower().Equals("usb"))
            {
                _mpsInstallerAgreement.SingleDeviceInstallationForCloudUsb(
                    _contextData.AdditionalDeviceProperties[0]); // Single device installation for 1st device
                _mpsInstallerAgreement.BulkInstallDevicesForCloudUsb();
            }
            else
            {
                Assert.Fail(
                    string.Format(
                    "Parallel Single and Bulk device Installation steps for communication method {0} & installation type {1} not implemented yet", communicationMethod, installationType));
            }
        }

        [When(@"a Cloud MPS Installer resets the devices and reinstalls them")]
        public void WhenACloudMPSInstallerResetsTheDevicesAndReinstallsThem()
        {
            if (_contextData.CommunicationMethod.ToLower().Equals("cloud") && _contextData.InstallationType.ToLower().Equals("bor"))
            {
                _mpsInstallerAgreement.ResetAndReinstallDevices(_installationCloudToolPage);
            }
            else if (_contextData.CommunicationMethod.ToLower().Equals("cloud") && _contextData.InstallationType.ToLower().Equals("web"))
            {
                _mpsInstallerAgreement.ResetAndReinstallDevices(_installationCloudWebPage);
            }
            else
            {
                Assert.Fail(
                    string.Format(
                    "Reset & Reinstall steps for communication method {0} & installation type {1} not implemented yet", _contextData.CommunicationMethod, _contextData.InstallationType));
            }
        }

        [Then(@"a Cloud MPS Installer is able to swap device using ""(.*)"" communication and ""(.*)"" installation")]
        public void ThenACloudMPSInstallerIsAbleToSwapDeviceUsingCommunicationAndInstallation(string swapCommunicationMethod, string swapInstallationType)
        {
            if (swapCommunicationMethod.ToLower().Equals("cloud") && swapInstallationType.ToLower().Equals("bor"))
            {
                foreach(var device in _contextData.AdditionalDeviceProperties)
                {
                    if(device.IsSwap)
                    {
                        _mpsInstallerAgreement.SwapDeviceForCloudBor(device);
                    }
                }
            }
            else
            {
                Assert.Fail(
                    string.Format(
                    "Swap Device Installation steps for communication method {0} & installation type {1} not implemented yet", swapCommunicationMethod, swapInstallationType));
            }
        }

        [When(@"a Cloud MPS Installer is able to reinstall devices using ""(.*)"" communication and ""(.*)"" installation")]
        public void WhenACloudMPSInstallerIsAbleToReinstallDevicesUsingCommunicationAndInstallation(string communicationMethod, string installationType)
        {
            if (communicationMethod.ToLower().Equals("cloud") && installationType.ToLower().Equals("bor"))
            {
                _mpsInstallerAgreement.ReInstallDevicesForCloudBor();
            }
            else
            {
                Assert.Fail(
                    string.Format(
                    "Device Re-Installation steps for communication method {0} & installation type {1} not implemented yet", communicationMethod, installationType));
            }
        }

    }
}