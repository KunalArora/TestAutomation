using Brother.Tests.Selenium.Lib.Support.HelperClasses;
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

        [Given(@"I generate installation request for the contract with ""(.*)"" communication and ""(.*)"" installation")]
        public void GivenIGenerateInstallationRequestForTheContractWithCommunicationAndInstallation(string method, string type)
        {
            WhenINavigateToTheContractManageDeviceScreen();
            WhenISelectLocationInOrderToCreateInstallationRequest();
            WhenISetDeviceCommunicationMethodAs(method);
            WhenISetDeviceInstallationTypeAs(type);
            WhenICompletedTheCreateInstallationProcessFor(type);
            ThenTheInstallationRequestForThatDeviceIsCompleted();
        }

        [When(@"I install the device on the contract with ""(.*)"" communication and ""(.*)"" installation")]
        public void WhenIInstallTheDeviceOnTheContractWithCommunicationAndInstallation(string method, string type)
        {
            GivenIGenerateInstallationRequestForTheContractWithCommunicationAndInstallation(method, type);
            GivenIExtractTheInstallerUrlFromInstallationRequest();
            GivenINavigateToTheInstallerPage();
            WhenIEnterTheContractReferenceNumber();
            WhenIEnterDeviceSerialNumberForCommunication(type);
            WhenIEnterTheDeviceIPAddress();
            ThenICanConnectTheDeviceToBrotherEnvironment();
            ThenICanCompleteDeviceInstallation();


        }


        [Given(@"I installed the device in the contract through ""(.*)""")]
        public void GivenIInstalledTheDeviceInTheContractThrough(string method)
        {
            GivenIGenerateInstallationRequestForTheContractWithCommunication(method);
            GivenIExtractTheInstallerUrlFromInstallationRequest();
            GivenINavigateToTheInstallerPage();
            WhenIEnterTheContractReferenceNumber();
            WhenIEnterDeviceSerialNumberForCommunication(method);
            WhenIEnterTheDeviceIPAddress();
            ThenICanConnectTheDeviceToBrotherEnvironment();
            ThenICanCompleteDeviceInstallation();
        }

        [Given(@"I installed existing device in the contract through ""(.*)""")]
        public void GivenIInstalledExistingDeviceInTheContractThrough(string method)
        {
            GivenIGenerateInstallationRequestForTheContractWithCommunication(method);
            GivenIExtractTheInstallerUrlFromInstallationRequest();
            GivenINavigateToTheInstallerPage();
            WhenIEnterTheContractReferenceNumber();
            WhenIEnterDeviceSerialNumberForCommunication(method);
            WhenIEnterTheDeviceIPAddress();
            ThenICanConnectTheDeviceToBrotherEnvironment();
            ThenICanCompleteDeviceInstallation();
        }



        [Given(@"I extract the installer url from Installation Request")]
        public void GivenIExtractTheInstallerUrlFromInstallationRequest()
        {
            CurrentPage.As<ManageDevicesPage>().ClickOnActionButton();
            CurrentPage.As<ManageDevicesPage>().ClickToExposeInstallationRequest();
            CurrentPage.As<ManageDevicesPage>().IsInstallationRequestScreenDisplayed();
            CurrentPage.As<ManageDevicesPage>().GetInstallationLink();
            //CurrentPage.As<DealerManageDevicesPage>().CloseInstallationrequestPopUp();
        }

        [When(@"I navigate to the installer page")]
        [Given(@"I navigate to the installer page")]
        public void GivenINavigateToTheInstallerPage()
        {
            NextPage = CurrentPage.As<ManageDevicesPage>().LaunchInstallerPage();
            CurrentPage.As<InstallerDeviceInstallationPage>().IsInstallerScreenDisplayed();
        }


        [When(@"I enter the contract reference number")]
        public void WhenIEnterTheContractReferenceNumber()
        {
          CurrentPage.As<InstallerDeviceInstallationPage>().EnterContractReference();
            CurrentPage.As<InstallerDeviceInstallationPage>().ProceedOnInstaller();
        }

        [When(@"I enter device serial number for ""(.*)"" communication")]
        public void WhenIEnterDeviceSerialNumberForCommunication(string method)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().VerifyTimeZoneIsDisplayed(method);
            if (method == "Email")
            {
                CurrentPage.As<InstallerDeviceInstallationPage>().EnterSerialNumber();
            }
            else
            {
                CurrentPage.As<InstallerDeviceInstallationPage>().EnterExistingSerialNumber(); 
            }
            
        }

        [When(@"I enter existing device serial number for ""(.*)"" communication")]
        public void WhenIEnterExistingDeviceSerialNumberForCommunication(string method)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().VerifyTimeZoneIsDisplayed(method);
            CurrentPage.As<InstallerDeviceInstallationPage>().IsInstallationPinCloudInstallationDisplayed();
            if (method == "BOR") return;
            CurrentPage.As<InstallerDeviceInstallationPage>().EnterExistingSerialNumber();
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
            CurrentPage.As<InstallerDeviceInstallationPage>().ConfirmCompleteMessageIsDisplayed();
            NextPage = CurrentPage.As<InstallerDeviceInstallationPage>()._ReturnBackToContractAcceptedPage();
            NextPage = CurrentPage.As<DealerContractsAcceptedPage>().ConfirmThatInstallationRequestIsNoLongerDisplayed();
            CurrentPage.As<ManageDevicesPage>().IsInstallationCompleted();
        }


        [When(@"I have completed installation for ""(.*)"" communication")]
        public void WhenIHaveCompletedInstallationForCommunication(string type)
        {
            GivenINavigateToTheInstallerPage();
            WhenIEnterTheContractReferenceNumber();
            WhenIEnterDeviceSerialNumberForCommunication(type);
            WhenIEnterTheDeviceIPAddress();
            ThenICanConnectTheDeviceToBrotherEnvironment();
            ThenICanCompleteDeviceInstallation();
        }


        [When(@"I navigate to the contract Manage Device Screen")]
        public void WhenINavigateToTheContractManageDeviceScreen()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToAcceptedContract();
            NextPage = CurrentPage.As<DealerContractsAcceptedPage>().NavigateToManageDevicesPage();

        }

        [When(@"I begin device swapping process")]
        public void WhenIBeginDeviceSwappingProcess()
        {
            
        }

        [When(@"I generate swapping device request")]
        public void WhenIGenerateSwappingDeviceRequest()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"installer installed the new swap device")]
        public void WhenInstallerInstalledTheNewSwapDevice()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the newly installed device is displayed on Managed Device screen")]
        public void ThenTheNewlyInstalledDeviceIsDisplayedOnManagedDeviceScreen()
        {
            ScenarioContext.Current.Pending();
        }



        [When(@"I navigate to the Local Office Approver device management Screen")]
        public void WhenINavigateToTheLocalOfficeApproverDeviceManagementScreen()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateTOfficeDeviceManagementPage();
            NextPage = CurrentPage.As<LocalOfficeApproverDeviceManagementPage>().NavigateToManageDevicesPage();
            CurrentPage.As<ManageDevicesPage>().IsManagedDeviceScreenDisplayed();

        }

        [When(@"I navigate to the signed contract Manage Device Screen")]
        public void WhenINavigateToTheSignedContractManageDeviceScreen()
        {
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().IsContractAwaitingAcceptanceTabDisplayed();
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().VerifyAcceptedContractIsDisplayed();
            NextPage = CurrentPage.As<DealerContractsAwaitingAcceptancePage>().NavigateToManageDevicesPage();

        }


        
        [When(@"I select Location in order to create installation request")]
        public void WhenISelectLocationInOrderToCreateInstallationRequest()
        {
            CurrentPage.As<ManageDevicesPage>().IsManagedDeviceScreenDisplayed();
            CurrentPage.As<ManageDevicesPage>().SelectCompanyLocation();
            NextPage =  CurrentPage.As<ManageDevicesPage>().CreateInstallationRequest();
        }

        [When(@"I did not select Location but proceed to create installation request")]
        public void WhenIDidNotSelectLocationButProceedToCreateInstallationRequest()
        {
            CurrentPage.As<ManageDevicesPage>().IsManagedDeviceScreenDisplayed();
            CurrentPage.As<ManageDevicesPage>().ClickOnNextButtonToInvokeError();
        }

        [Then(@"an error message is displayed to prevent further progress")]
        public void ThenAnErrorMessageIsDisplayedToPreventFurtherProgress()
        {
           CurrentPage.As<ManageDevicesPage>().SelectLocationErrorIsDisplayed();
        }

        [Then(@"I can progress if Location is selected")]
        public void ThenICanProgressIfLocationIsSelected()
        {
            CurrentPage.As<ManageDevicesPage>().SelectCompanyLocation();
            //CurrentPage.As<ManageDevicesPage>().ClickOnNextButtonToInvokeError();
            NextPage = CurrentPage.As<ManageDevicesPage>().CreateInstallationRequest();
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
            CurrentPage.As<ManageDevicesPage>().IsManagedDeviceScreenDisplayed();
            CurrentPage.As<ManageDevicesPage>().IsInstallationRequestDisplayed();
        }

        [Then(@"I can cancel the above created installation request")]
        public void ThenICanCancelTheAboveCreatedInstallationRequest()
        {
            CurrentPage.As<ManageDevicesPage>().ClickOnActionButton();
            CurrentPage.As<ManageDevicesPage>().ClickOnCancelRequest();
            //CurrentPage.As<ManageDevicesPage>().RefreshManageDeviceScreen();
            CurrentPage.As<ManageDevicesPage>().IsInstallationRequestCancelled();
            
        }


    }
}
