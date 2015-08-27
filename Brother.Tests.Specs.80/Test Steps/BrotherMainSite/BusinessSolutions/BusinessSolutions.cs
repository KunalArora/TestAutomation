using System;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages8._0.BrotherMainSite;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs._80.Test_Steps.BrotherMainSite.BusinessSolutions
{
    [Binding]
    public class NavigateMainSiteTopBusinessSolutionsMenuSteps : BaseSteps
    {
        [Given(@"I have clicked the top business solutions menu button")]
        public void GivenIHaveClickedTheTopBusinessSolutionsMenuButton()
        {
            CurrentPage.As<MainSiteHomePage>().HoverBusinessSolutionsMenu(CurrentDriver);
        }
        
        [Given(@"I hover over the top Business Solutions menu button")]
        public void GivenIHoverOverTheTopBusinessSolutionsMenuButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the business solutions page")]
        public void ThenIAmNavigatedToTheBusinessSolutionsPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasBusinessSolutionsPageLoaded();
        }
        
        [Then(@"I hover and click the Manage Print Services option")]
        public void ThenIHoverAndClickTheManagePrintServicesOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View All Print Management page")]
        public void ThenIAmNavigatedToTheViewAllPrintManagementPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I hover and click the Document Capture Workflow option")]
        public void ThenIHoverAndClickTheDocumentCaptureWorkflowOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View All Document Capture and Workflow page")]
        public void ThenIAmNavigatedToTheViewAllDocumentCaptureAndWorkflowPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I hover and click the Cost Control and Security option")]
        public void ThenIHoverAndClickTheCostControlAndSecurityOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View All Cost Control and Security page")]
        public void ThenIAmNavigatedToTheViewAllCostControlAndSecurityPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I hover and click the Mobile and Cloud option")]
        public void ThenIHoverAndClickTheMobileAndCloudOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View All Mobile and Cloud page")]
        public void ThenIAmNavigatedToTheViewAllMobileAndCloudPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I hover and click the Portable Print and Label option")]
        public void ThenIHoverAndClickThePortablePrintAndLabelOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View All Portable Print and Label page")]
        public void ThenIAmNavigatedToTheViewAllPortablePrintAndLabelPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I hover and click the Communication and Collaboration option")]
        public void ThenIHoverAndClickTheCommunicationAndCollaborationOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View All Communication and Collaboration page")]
        public void ThenIAmNavigatedToTheViewAllCommunicationAndCollaborationPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I hover and click the Visitor and Event Management option")]
        public void ThenIHoverAndClickTheVisitorAndEventManagementOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View All Visitor and Event Management page")]
        public void ThenIAmNavigatedToTheViewAllVisitorAndEventManagementPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I hover and click the Search by Industry option")]
        public void ThenIHoverAndClickTheSearchByIndustryOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View All Search by Industry page")]
        public void ThenIAmNavigatedToTheViewAllSearchByIndustryPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I hover and click the View our Industry Partners option")]
        public void ThenIHoverAndClickTheViewOurIndustryPartnersOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View our Industry Partners page")]
        public void ThenIAmNavigatedToTheViewOurIndustryPartnersPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I hover and click the View our Case Studies option")]
        public void ThenIHoverAndClickTheViewOurCaseStudiesOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the View our Case Studies page")]
        public void ThenIAmNavigatedToTheViewOurCaseStudiesPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
