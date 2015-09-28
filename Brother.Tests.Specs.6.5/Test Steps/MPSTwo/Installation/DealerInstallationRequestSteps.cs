using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Installation
{
    [Binding]
    class DealerInstallationRequestSteps : BaseSteps
    {
        [Given(@"I generate ""(.*)"" installation request for the contract with ""(.*)"" communication")]
        public void GivenIGenerateInstallationRequestForTheContractWithCommunication(string type, string method)
        {
            WhenINavigateToTheContractManageDeviceScreen();
            WhenISelectLocationInOrderToCreateInstallationRequest();
            WhenISetDeviceCommunicationMethodAs(method);
            WhenISetDeviceInstallationTypeAs(type);
            WhenICompletedTheCreateInstallationProcessFor(type);
            ThenTheInstallationRequestForThatDeviceIsCompleted();
        }

        [Given(@"I extract the installer url from Installation Request")]
        public void GivenIExtractTheInstallerUrlFromInstallationRequest()
        {
            CurrentPage.As<DealerManageDevicesPage>().ClickOnActionButton();
            CurrentPage.As<DealerManageDevicesPage>().ClickToExposeInstallationRequest();
            CurrentPage.As<DealerManageDevicesPage>().IsInstallationRequestScreenDisplayed();
            CurrentPage.As<DealerManageDevicesPage>().GetInstallationLink();
            CurrentPage.As<DealerManageDevicesPage>().CloseInstallationrequestPopUp();
        }

        [Given(@"I navigate to the installer page")]
        public void GivenINavigateToTheInstallerPage()
        {
            
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
