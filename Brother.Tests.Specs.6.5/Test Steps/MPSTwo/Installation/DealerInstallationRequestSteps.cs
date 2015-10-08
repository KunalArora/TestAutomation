﻿using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Installation
{
    [Binding]
    class DealerInstallationRequestSteps : BaseSteps
    {
        [Given(@"I generate installation request for the contract with ""(.*)"" communication")]
        public void GivenIGenerateInstallationRequestForTheContractWithCommunication(string method)
        {
            WhenINavigateToTheContractManageDeviceScreen();
            WhenISelectLocationInOrderToCreateInstallationRequest();
            WhenISetDeviceCommunicationMethodAs(method);
            WhenICompletedTheCreateInstallationProcessFor(method);
            ThenTheInstallationRequestForThatDeviceIsCompleted();
        }

        [Given(@"I extract the installer url from Installation Request")]
        public void GivenIExtractTheInstallerUrlFromInstallationRequest()
        {
            CurrentPage.As<DealerManageDevicesPage>().ClickOnActionButton();
            CurrentPage.As<DealerManageDevicesPage>().ClickToExposeInstallationRequest();
            CurrentPage.As<DealerManageDevicesPage>().IsInstallationRequestScreenDisplayed();
            CurrentPage.As<DealerManageDevicesPage>().GetInstallationLink();
            //CurrentPage.As<DealerManageDevicesPage>().CloseInstallationrequestPopUp();
        }

        [When(@"I navigate to the installer page")]
        [Given(@"I navigate to the installer page")]
        public void GivenINavigateToTheInstallerPage()
        {
            NextPage = CurrentPage.As<DealerManageDevicesPage>().LaunchInstallerPage();
            CurrentPage.As<InstallerDeviceInstallationPage>().IsInstallerScreenDisplayed();
        }


        [When(@"I enter the contract reference number")]
        public void WhenIEnterTheContractReferenceNumber()
        {
          CurrentPage.As<InstallerDeviceInstallationPage>().EnterContractReference();
            CurrentPage.As<InstallerDeviceInstallationPage>().ProceedOnInstaller();
        }

        [When(@"I enter ""(.*)"" device serial number")]
        public void WhenIEnterTheDeviceSerialNumber(string country)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().EnterSerialNumber(country);
            
        }

        [When(@"I enter the device IP address")]
        public void WhenIEnterTheDeviceIPAddress()
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().EnterIpAddress();
        }

        [Then(@"I can connect the device to Brother environment")]
        public void ThenICanConnectTheDeviceToBrotherEnvironment()
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDevice();

        }

        [Then(@"I can complete device installation")]
        public void ThenICanCompleteDeviceInstallation()
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().CompleteDeviceConnection();
            CurrentPage.As<InstallerDeviceInstallationPage>().ConfirmInstallationSucceed();
        }



        [When(@"I navigate to the contract Manage Device Screen")]
        public void WhenINavigateToTheContractManageDeviceScreen()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToAcceptedContract();
            NextPage = CurrentPage.As<DealerContractsApprovedPage>().NavigateToManageDevicesPage();

        }


        [When(@"I select Location in order to create installation request")]
        public void WhenISelectLocationInOrderToCreateInstallationRequest()
        {
            CurrentPage.As<DealerManageDevicesPage>().IsManagedDeviceScreenDisplayed();
            CurrentPage.As<DealerManageDevicesPage>().SelectCompanyLocation();
            NextPage =  CurrentPage.As<DealerManageDevicesPage>().CreateInstallationRequest();
        }

        [When(@"I set device communication method as ""(.*)""")]
        public void WhenISetDeviceCommunicationMethodAs(string method)
        {
            CurrentPage.As<DealerSetCommunicationMethodPage>().IsSetCommunicationTabDisplayed();
            CurrentPage.As<DealerSetCommunicationMethodPage>().SetCommunicationMethod(method);

            switch (method)
            {
                case "Email" :
                    NextPage = CurrentPage.As<DealerSetCommunicationMethodPage>().ProceedToNextPageForEmail();
                    break;
                case "Cloud" :
                    NextPage = CurrentPage.As<DealerSetCommunicationMethodPage>().ProceedToNextPage();
                    break;
            }
            
        }

        [When(@"I set device installation type as ""(.*)""")]
        public void WhenISetDeviceInstallationTypeAs(string type)
        {
            CurrentPage.As<DealerSetInstallationTypePage>().IsInstallationTypeTabDisplayed();
            CurrentPage.As<DealerSetInstallationTypePage>().SetInstallationType(type);
            NextPage = CurrentPage.As<DealerSetInstallationTypePage>().ProccedToDealerSendInstallationEmailPage();
        }


        [When(@"I completed the create installation process for ""(.*)""")]
        public void WhenICompletedTheCreateInstallationProcessFor(string method)
        {
            CurrentPage.As<DealerSendInstallationEmailPage>().IsSendCommunicationScreenDisplayed();
            if (method.Equals("BOR"))
            {
                CurrentPage.As<DealerSendInstallationEmailPage>().ArePinAndLabelFieldPopulated();  
            }
            else
            {
                CurrentPage.As<DealerSendInstallationEmailPage>().IsPinFieldPopulated();
            }
            
            CurrentPage.As<DealerSendInstallationEmailPage>().EnterInstallaterEmail();
            CurrentPage.As<DealerSendInstallationEmailPage>().SendInstallationRequest();
            NextPage = CurrentPage.As<DealerSendInstallationEmailPage>().CompleteInstallation();
        }

        [Then(@"the installation request for that device is completed")]
        public void ThenTheInstallationRequestForThatDeviceIsCompleted()
        {
            CurrentPage.As<DealerManageDevicesPage>().IsManagedDeviceScreenDisplayed();
            CurrentPage.As<DealerManageDevicesPage>().IsInstallationRequestDisplayed();
        }

    }
}
