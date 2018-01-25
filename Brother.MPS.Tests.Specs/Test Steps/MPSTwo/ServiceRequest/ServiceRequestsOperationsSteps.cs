using Brother.Tests.Specs.MPSTwo.Proposal;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.ServiceRequest
{
    [Binding]
    public class ServiceRequestsOperationsSteps : BaseSteps
    {

        [Given(@"I navigate to customer request page")]
        [When(@"I navigate to customer request page")]
        [Then(@"I navigate to customer request page")]
        public void GivenINavigateToCustomerRequestPage()
        {
            NextPage = CurrentPage.As<CustomerPortalDashboardPage>().NavigateToCustomerServiceRequestsPage();
            CurrentPage.As<CustomerPortalServiceRequestsPage>().IsServiceRequestPageDisplayed();
        }
        
        [When(@"I raise a service request")]
        public void WhenIRaiseAServiceRequest()
        {
            CurrentPage.As<CustomerPortalServiceRequestsPage>().CreateANewServiceRequest();
        }

        [Then(@"the service request is created and displayed")]
        [When(@"the service request is created and displayed")]
        public void WhenTheServiceRequestIsCreatedAndDisplayed()
        {
            CurrentPage.As<CustomerPortalServiceRequestsPage>().IsServiceRequestCreated();
            CurrentPage.As<CustomerPortalServiceRequestsPage>().IsCorrectServiceRequestTypeDisplayed();
        }

        [Then(@"consumable can be automatically created")]
        public void ThenConsumableCanBeAutomaticallyCreated()
        {
            CurrentPage.As<CustomerPortalServiceRequestsPage>().IsServiceRequestCreatedByEmail();
        }


        [When(@"all the functionalities of the service request work")]
        public void WhenAllTheFunctionalitiesOfTheServiceRequestWork()
        {
            CurrentPage.As<CustomerPortalServiceRequestsPage>().ExpandCreatedServiceRequestRow();
            CurrentPage.As<CustomerPortalServiceRequestsPage>().IsServiceRequestDetailDisplayed();
            CurrentPage.As<CustomerPortalServiceRequestsPage>().VerifyContactPersonPopUpWorks();
            CurrentPage.As<CustomerPortalServiceRequestsPage>().VerifyDeviceLocationPopUpWorks();
            CurrentPage.As<CustomerPortalServiceRequestsPage>().VerifyMeterReadingPopUpWorks();
            CurrentPage.As<CustomerPortalServiceRequestsPage>().CloseServiceRequestDetailPanel();
        }

        
        [Then(@"the created service request is displayed for Service Desk")]
        public void ThenTheCreatedServiceRequestIsDisplayedForServiceDesk()
        {
            CurrentPage.As<ServiceDeskDashBoardPage>().IsDashboardPageDisplayed();
            NextPage = CurrentPage.As<ServiceDeskDashBoardPage>().NavigateToServiceDeskPage();
            CurrentPage.As<ServiceDeskServiceRequestsPage>().IsServiceRequestDashBoardDisplayed();
            NextPage = CurrentPage.As<ServiceDeskServiceRequestsPage>().NavigateToServiceRequestsPage();
            CurrentPage.As<ServiceDeskServiceRequestsActivePage>().IsServiceRequestPageDisplayed();
            CurrentPage.As<ServiceDeskServiceRequestsActivePage>().IsCreatedServiceRequestDisplayed();

        }

        [Then(@"Service Desk can close the service request")]
        public void ThenServiceDeskCanCloseTheServiceRequest()
        {
            CurrentPage.As<ServiceDeskServiceRequestsActivePage>().OpenServiceRequestDetail();
            CurrentPage.As<ServiceDeskServiceRequestsActivePage>().CloseServiceRequest();
        }

        [When(@"I can send message to Service Desk user")]
        public void WhenICanSendMessageToServiceDeskUser()
        {
            CurrentPage.As<CustomerPortalServiceRequestsPage>().CustomerSendMessage();
        }

        [Then(@"I can see the message sent by customer and reply")]
        public void ThenICanSeeTheMessageSentByCustomerAndReply()
        {
            CurrentPage.As<ServiceDeskServiceRequestsActivePage>().OpenServiceRequestDetail();
            CurrentPage.As<ServiceDeskServiceRequestsActivePage>().IsServiceDeskMessageDisplayed(1);
            CurrentPage.As<ServiceDeskServiceRequestsActivePage>().ServiceDeskSendMessage();
        }

        [Then(@"I can see the reply from Service Desk")]
        public void ThenICanSeeTheReplyFromServiceDesk()
        {
            var page = new CustomerRunPortionSteps();
            page.WhenINavigateToCustomerDashboardPage();

            GivenINavigateToCustomerRequestPage();
            CurrentPage.As<CustomerPortalServiceRequestsPage>().ExpandCreatedServiceRequestRow();
            CurrentPage.As<CustomerPortalServiceRequestsPage>().IsServiceDeskMessageDisplayed(2);
        }





    }
}
