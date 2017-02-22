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
            WhenIEnterTheDeviceIpAddress();
            ThenICanConnectTheDeviceToBrotherEnvironment();
            ThenICanCompleteDeviceInstallation();


        }

        [When(@"I install the device with ""(.*)"" on the contract with ""(.*)"" communication and ""(.*)"" installation")]
        public void WhenIInstallTheDeviceWithOnTheContractWithCommunicationAndInstallation(string serialNumber, string method, string type)
        {
            GivenIGenerateInstallationRequestForTheContractWithCommunicationAndInstallation(method, type);
            GivenIExtractTheInstallerUrlFromInstallationRequest();
            GivenINavigateToTheInstallerPage();
            WhenIEnterTheContractReferenceNumber();
            WhenIEnterDeviceSerialNumberForCommunication(serialNumber, type);
            WhenIEnterTheDeviceIpAddress();
            ThenICanConnectDeviceWithSerialsToBrotherEnvironment("MFC-L8650CDW", serialNumber);
            ThenICanCompleteDeviceInstallation();
        }

        [Then(@"I can create automatic service request for ""(.*)""")]
        public void ThenICanCreateAutomaticServiceRequestFor(string tonerType)
        {
            ActionsModule.ChangeTonerInkStatus(tonerType);
            ActionsModule.RunConsumableOrderCreationJobs();
        }




        [Given(@"I installed the device in the contract through ""(.*)""")]
        public void GivenIInstalledTheDeviceInTheContractThrough(string method)
        {
            GivenIGenerateInstallationRequestForTheContractWithCommunication(method);
            GivenIExtractTheInstallerUrlFromInstallationRequest();
            GivenINavigateToTheInstallerPage();
            WhenIEnterTheContractReferenceNumber();
            WhenIEnterDeviceSerialNumberForCommunication(method);
            WhenIEnterTheDeviceIpAddress();
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
            WhenIEnterTheDeviceIpAddress();
            ThenICanConnectTheDeviceToBrotherEnvironment();
            ThenICanCompleteDeviceInstallation();
        }



        [Given(@"I extract the installer url from Installation Request")]
        public void GivenIExtractTheInstallerUrlFromInstallationRequest()
        {
            CurrentPage.As<DealerManageDevicesPage>().ClickOnActionButtonOnDisplay();
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

        [Then(@"I enter the contract reference number")]
        [When(@"I enter the contract reference number")]
        public void WhenIEnterTheContractReferenceNumber()
        {
          CurrentPage.As<InstallerDeviceInstallationPage>().EnterContractReference();
            CurrentPage.As<InstallerDeviceInstallationPage>().ProceedOnInstaller();
        }


        [When(@"I enter serial numbers ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void WhenIEnterSerialNumbersAndAndAnd(string serial, string serial1, string serial2, string serial3)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().VerifyTimeZoneIsDisplayed("Email");
            CurrentPage.As<InstallerDeviceInstallationPage>().EnterSerialNumber(serial, serial1, serial2, serial3);
        }

        [When(@"I enter serial numbers ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" for ""(.*)"" communication")]
        public void WhenIEnterSerialNumbersAndAndAndForCommunication(string serial, string serial1, string serial2, string serial3, string method)
        {
            WhenIEnterSerialNumbersAndAndAnd(serial, serial1, serial2, serial3, method);
        }


        public void WhenIEnterSerialNumbersAndAndAnd(string serial, string serial1, string serial2, string serial3, string method)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().VerifyTimeZoneIsDisplayed(method);
            CurrentPage.As<InstallerDeviceInstallationPage>().EnterSerialNumber(serial, serial1, serial2, serial3);
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

        [When(@"I enter device serial number ""(.*)"" for ""(.*)"" communication")]
        public void WhenIEnterDeviceSerialNumberForCommunication(string serial, string type)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().VerifyTimeZoneIsDisplayed(type);
            CurrentPage.As<InstallerDeviceInstallationPage>().EnterSingleSerialNumber(serial);

        }

        public void WhenIEnterSwapDeviceSerialNumberForCommunication(string method)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().VerifyTimeZoneIsDisplayed(method);
            CurrentPage.As<InstallerDeviceInstallationPage>().EnterSwapSerialNumber();
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
        public void WhenIEnterTheDeviceIpAddress()
        {

            CurrentPage.As<InstallerDeviceInstallationPage>().EnterIpAddress();
        }

        [When(@"I can connect the device to Brother environment")]
        [Given(@"I can connect the device to Brother environment")]
        [Then(@"I can connect the device to Brother environment")]
        public void ThenICanConnectTheDeviceToBrotherEnvironment()
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDevice();

        }


        [When(@"I can connect device ""(.*)"" with serials ""(.*)"" and ""(.*)"" to serials ""(.*)"" and ""(.*)"" with serials ""(.*)"" and ""(.*)"" with serials ""(.*)"" to Brother environment")]
        public void WhenICanConnectDeviceWithSerialsAndToSerialsAndWithSerialsAndWithSerialsToBrotherEnvironment(string device1, string serial1, string device2, string serial2, 
            string device3, string serial3, string device4, string serial4)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDeviceWithBor(device1, serial1, "1");
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDeviceWithBor(device2, serial2, "2");
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDeviceWithBor(device3, serial3, "3");
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDeviceWithBor(device4, serial4, "4");
            //CurrentPage.As<InstallerDeviceInstallationPage>().RefreshCloudMultipleInstallation();
            CurrentPage.As<InstallerDeviceInstallationPage>().RefreshCloudInstallationBeforeClickingOnCompleteInstallation();
        }



        [Given(@"I can connect device ""(.*)"" with serials ""(.*)"" ""(.*)"" and ""(.*)"" with serials ""(.*)"" and ""(.*)"" to Brother environment")]
        [When(@"I can connect device ""(.*)"" with serials ""(.*)"" ""(.*)"" and ""(.*)"" with serials ""(.*)"" and ""(.*)"" to Brother environment")]
        [Then(@"I can connect device ""(.*)"" with serials ""(.*)"" ""(.*)"" and ""(.*)"" with serials ""(.*)"" and ""(.*)"" to Brother environment")]
        public void ThenICanConnectDeviceWithSerialsAndWithSerialsAndToBrotherEnvironment(string device1, string serial1, string serial2, 
            string device2, string serial3, string serial4)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDeviceWithBor(device1, serial1);
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDeviceWithBor(device1, serial2);
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDeviceWithBor(device2, serial3);
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDeviceWithBor(device2, serial4);
            //CurrentPage.As<InstallerDeviceInstallationPage>().RefreshCloudMultipleInstallation();
            CurrentPage.As<InstallerDeviceInstallationPage>().RefreshCloudInstallation();
        }

        [When(@"I can connect device with serials ""(.*)"" to Brother environment")]
        [Then(@"I can connect device with serials ""(.*)"" to Brother environment")]
        public void ThenICanConnectDeviceWithSerialsToBrotherEnvironment(string serial)
        {
            ThenICanConnectDeviceWithSerialsToBrotherEnvironment("MFC-L8650CDW", serial);
        }

        [Then(@"I can connect device ""(.*)"" with serials ""(.*)"" to Brother environment")]
        public void ThenICanConnectSingleDeviceWithSerialsToBrotherEnvironment(string device, string serial)
        {
            ThenICanConnectDeviceWithSerialsToBrotherEnvironment(device, serial);
        }



        public void ThenICanConnectDeviceWithSerialsToBrotherEnvironment(string device1, string serial1)
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectDeviceWithBor(device1, serial1);
            //CurrentPage.As<InstallerDeviceInstallationPage>().RefreshCloudMultipleInstallation();
            CurrentPage.As<InstallerDeviceInstallationPage>().RefreshCloudInstallation();
        }

        

        public void ThenICanConnectSwapDeviceToBrotherEnvironment()
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().ConnectSwapDevice();

        }

        [Given(@"I can complete device installation")]
        [When(@"I can complete device installation")]
        [Then(@"I can complete device installation")]
        public void ThenICanCompleteDeviceInstallation()
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().CompleteDeviceConnection();
            CurrentPage.As<InstallerDeviceInstallationPage>().ConfirmInstallationSucceed();
            CurrentPage.As<InstallerDeviceInstallationPage>().ConfirmCompleteMessageIsDisplayed();
            NextPage = CurrentPage.As<InstallerDeviceInstallationPage>()._ReturnBackToContractAcceptedPage();
            NextPage = CurrentPage.As<DealerContractsAcceptedPage>().NavigateToManageDevicesPageToConfirmThatInstallationRequestAvailability();
            CurrentPage.As<DealerManageDevicesPage>().IsInstallationCompleted();
        }

        [Given(@"I can complete multiple devices installation")]
        [Then(@"I can complete multiple devices installation")]
        [When(@"I can complete multiple devices installation")]
        public void WhenICanCompleteMultipleDevicesInstallation()
        {
            ThenICanCompleteMultipleDeviceInstallation();
        }

        public void ThenICanCompleteMultipleDeviceInstallation()
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().CompleteDeviceConnection();
            CurrentPage.As<InstallerDeviceInstallationPage>().ConfirmInstallationSucceed("1", "2", "3", "4");
            CurrentPage.As<InstallerDeviceInstallationPage>().ConfirmCompleteMessageIsDisplayed();
            NextPage = CurrentPage.As<InstallerDeviceInstallationPage>()._ReturnBackToContractAcceptedPage();
            NextPage = CurrentPage.As<DealerContractsAcceptedPage>().NavigateToManageDevicesPageToConfirmThatInstallationRequestAvailability();
            CurrentPage.As<DealerManageDevicesPage>().IsInstallationCompleted("1", "2", "3", "4");
        }

        [Then(@"I can reset the installation done above")]
        public void ThenICanResetTheInstallationDoneAbove()
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().ResetInstallation();
            CurrentPage.As<InstallerDeviceInstallationPage>().IsInstallationReset();
        }

        [Then(@"I can reset the installation done above and begin installation again")]
        public void ThenICanResetTheInstallationDoneAboveAndBeginInstallationAgain()
        {
           NextPage = CurrentPage.As<InstallerDeviceInstallationPage>().ResetInstallationAndStartAgain();
            CurrentPage.As<InstallerDeviceInstallationPage>().IsInstallerScreenDisplayed();
        }


        [Then(@"reinstall the device with serial number ""(.*)"" for communication ""(.*)""")]
        public void ThenReinstallTheDeviceWithSerialNumberForCommunication(string serial, string type)
        {
            WhenIEnterDeviceSerialNumberForCommunication(serial, type);
            WhenIEnterTheDeviceIpAddress();
            ThenICanConnectDeviceWithSerialsToBrotherEnvironment("MFC-L8650CDW", serial);
            ThenICanCompleteDeviceInstallation();
        }



        [When(@"I have completed installation for ""(.*)"" communication")]
        public void WhenIHaveCompletedInstallationForCommunication(string type)
        {
            GivenINavigateToTheInstallerPage();
            WhenIEnterTheContractReferenceNumber();
            WhenIEnterDeviceSerialNumberForCommunication(type);
            WhenIEnterTheDeviceIpAddress();
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
            CurrentPage.As<DealerManageDevicesPage>().BeginSwapProcess();
            NextPage = CurrentPage.As<DealerManageDevicesPage>().ConfirmSwapProcessCommencement();
        }

        [When(@"I generate swapping device request")]
        public void WhenIGenerateSwappingDeviceRequest()
        {
            CurrentPage.As<DealerSendInstallationEmailPage>().IsDeviceModelDisplayedOnSwapConfirmationPage();
            CurrentPage.As<DealerSendInstallationEmailPage>().EnterInstallaterEmail();
            NextPage = CurrentPage.As<DealerSendInstallationEmailPage>().SendSwapInstallationRequest();
            CurrentPage.As<DealerManageDevicesPage>().IsSwapInstallationRequestSent();
            CurrentPage.As<DealerManageDevicesPage>().IsSwapProgressTextDisplayed();
            CurrentPage.As<DealerManageDevicesPage>().IsSwapDeviceLineDisplayed();
        }

        [When(@"installer installed the new swap device for ""(.*)"" communication")]
        public void WhenInstallerInstalledTheNewSwapDeviceForCommunication(string type)
        {
            CurrentPage.As<DealerManageDevicesPage>().ClickToExposeSwapInstallationRequest();
            CurrentPage.As<DealerManageDevicesPage>().IsInstallationRequestScreenDisplayed();
            NextPage = CurrentPage.As<DealerManageDevicesPage>().LaunchInstallerPage();
            CurrentPage.As<InstallerDeviceInstallationPage>().EnterContractReference();
            CurrentPage.As<InstallerDeviceInstallationPage>().ProceedOnInstaller();

            WhenIEnterSwapDeviceSerialNumberForCommunication(type);
            WhenIEnterTheDeviceIpAddress();
            ThenICanConnectSwapDeviceToBrotherEnvironment();
           // ThenICanCompleteDeviceInstallation();
        }

        [Then(@"the newly installed device is displayed on Managed Device screen")]
        public void ThenTheNewlyInstalledDeviceIsDisplayedOnManagedDeviceScreen()
        {
            CurrentPage.As<InstallerDeviceInstallationPage>().CompleteDeviceConnection();
            CurrentPage.As<InstallerDeviceInstallationPage>().ConfirmInstallationSucceed();
            CurrentPage.As<InstallerDeviceInstallationPage>().ConfirmCompleteMessageIsDisplayed();
            NextPage = CurrentPage.As<InstallerDeviceInstallationPage>()._ReturnBackToContractAcceptedPage();
            NextPage = CurrentPage.As<DealerContractsAcceptedPage>().NavigateToManageDevicesPageToConfirmThatInstallationRequestAvailability();
        }

        [Then(@"I can complete the swap process")]
        public void ThenICanCompleteTheSwapProcess()
        {
            CurrentPage.As<DealerManageDevicesPage>().IsNewlySwappedDeviceDisplayed();
            NextPage = CurrentPage.As<DealerManageDevicesPage>().CompleteSwapProcess();
            CurrentPage.As<CompleteSwapProcessPage>().IsCompleteSwapProcessScreenDisplayed();
            CurrentPage.As<CompleteSwapProcessPage>().IsNewDeviceSerialNumberDisplayed();
            CurrentPage.As<CompleteSwapProcessPage>().IsOldDeviceSerialNumberDisplayed();
            NextPage = CurrentPage.As<CompleteSwapProcessPage>().CompleteSwapProcessThroughPrintCountSwap();
            CurrentPage.As<DealerManageDevicesPage>().IsSwapInstallationRequestSent();
        }

        [When(@"I navigate to the Local Office Approver device management Screen")]
        public void WhenINavigateToTheLocalOfficeApproverDeviceManagementScreen()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateTOfficeDeviceManagementPage();
            NextPage = CurrentPage.As<LocalOfficeApproverDeviceManagementPage>().NavigateToManageDevicesPage();
            CurrentPage.As<DealerManageDevicesPage>().IsManagedDeviceScreenDisplayed();

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
            CurrentPage.As<DealerManageDevicesPage>().IsManagedDeviceScreenDisplayed();
            CurrentPage.As<DealerManageDevicesPage>().SelectCompanyLocation();
            NextPage =  CurrentPage.As<DealerManageDevicesPage>().CreateInstallationRequest();
        }

        [When(@"I did not select Location but proceed to create installation request")]
        public void WhenIDidNotSelectLocationButProceedToCreateInstallationRequest()
        {
            CurrentPage.As<DealerManageDevicesPage>().IsManagedDeviceScreenDisplayed();
            CurrentPage.As<DealerManageDevicesPage>().ClickOnNextButtonToInvokeError();
        }

        [Then(@"an error message is displayed to prevent further progress")]
        public void ThenAnErrorMessageIsDisplayedToPreventFurtherProgress()
        {
           CurrentPage.As<DealerManageDevicesPage>().SelectLocationErrorIsDisplayed();
        }

        [Then(@"I can progress if Location is selected")]
        public void ThenICanProgressIfLocationIsSelected()
        {
            CurrentPage.As<DealerManageDevicesPage>().SelectCompanyLocation();
            //CurrentPage.As<ManageDevicesPage>().ClickOnNextButtonToInvokeError();
            NextPage = CurrentPage.As<DealerManageDevicesPage>().CreateInstallationRequest();
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

        [Then(@"I can cancel the above created installation request")]
        public void ThenICanCancelTheAboveCreatedInstallationRequest()
        {
            CurrentPage.As<DealerManageDevicesPage>().ClickOnActionButtonOnDisplay();
            CurrentPage.As<DealerManageDevicesPage>().ClickOnCancelRequest();
            //CurrentPage.As<ManageDevicesPage>().RefreshManageDeviceScreen();
            CurrentPage.As<DealerManageDevicesPage>().IsInstallationRequestCancelled();
            
        }


    }
}
