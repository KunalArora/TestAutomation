using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;

namespace Brother.Tests.Specs.StepActions.Contract
{
    public class MpsDealerContractStepActions: StepActionBase
    {
        private readonly IWebDriver _dealerWebDriver;
        private readonly IContextData _contextData;

        public MpsDealerContractStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            RuntimeSettings runtimeSettings
            )
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _contextData = contextData;        
        }

        public DealerContractsPage NavigateToContractsPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.ExistingContractLinkElement.Click();
            return PageService.GetPageObject<DealerContractsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerContractsAcceptedPage NavigateToContractsAcceptedPage(DealerContractsPage dealerContractsPage)
        {
            dealerContractsPage.AcceptedTabElement.Click();
            return PageService.GetPageObject<DealerContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage NavigateToManageDevicesPage(DealerContractsAcceptedPage dealerContractsAcceptedPage, int proposalId)
        {
            dealerContractsAcceptedPage.NavigateToSpecificManageDevicesPage(proposalId, RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void InstallationCompleteCheck(DealerManageDevicesPage _dealerManageDevicesPage, IEnumerable<PrinterProperties> products)
        {
            foreach (var product in products)
            {
                _dealerManageDevicesPage.InstallationCompleteCheck(product.SerialNumber, RuntimeSettings.DefaultFindElementTimeout);
            }
        }

        //Similar function is already present in this file so, refactor this particular function.
        public void MoveToAcceptedContractsTab(DealerContractsPage dealerContractsPage)
        {
            dealerContractsPage.MoveToAcceptedContracts(RuntimeSettings.DefaultFindElementTimeout);
        }
        
        public void FilterContractUsingProposalId(DealerContractsPage dealerContractsPage, int proposalId)
        {
            dealerContractsPage.FilterContractUsingProposalId(proposalId, RuntimeSettings.DefaultFindElementTimeout);
        }

        public DealerManageDevicesPage ClickOnManageDevicesAndProceed(DealerContractsPage dealerContractsPage)
        {
            // Click on Actions & Manage Devices link
            dealerContractsPage.ClickOnManageDevicesButton(RuntimeSettings.DefaultFindElementTimeout);
            // Move to Manage Devices Page
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSetCommunicationMethodPage CreateInstallationRequest(DealerManageDevicesPage dealerManageDevicesPage)
        {
            // Filter Location
            _contextData.CompanyLocation = dealerManageDevicesPage.SelectLocation();
            
            dealerManageDevicesPage.ClickCreateRequest();
            return PageService.GetPageObject<DealerSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSetInstallationTypePage SelectCommunicationMethodAndProceed(DealerSetCommunicationMethodPage dealerSetCommunicationMethodPage, string communicationMethod)
        {
            switch(communicationMethod)
            {
                case "Cloud":
                    dealerSetCommunicationMethodPage.SetCloudCommunicationMethod();
                    break;
                case "Email":
                    dealerSetCommunicationMethodPage.SetEmailCommunicationMethod();
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
            dealerSetCommunicationMethodPage.ProceedElement.Click();
            return PageService.GetPageObject<DealerSetInstallationTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSendInstallationEmailPage SelectInstallationTypeAndProceed(DealerSetInstallationTypePage dealerSetInstallationTypePage, string installationType)
        {
            switch (installationType)
            {
                case "Web":
                    dealerSetInstallationTypePage.SetWebInstallationType();
                    break;
                case "BOR":
                    dealerSetInstallationTypePage.SetBORInstallationType();
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
            dealerSetInstallationTypePage.NextElement.Click();
            return PageService.GetPageObject<DealerSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage PopulateInstallerEmailAndSendEmail(DealerSendInstallationEmailPage dealerSendInstallationEmailPage)
        {
            _contextData.InstallerEmail = dealerSendInstallationEmailPage.EnterInstallerEmailAndProceed(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifyInstallationRequestCreated(DealerManageDevicesPage dealerManageDevicesPage, string installerEmail, string companyLocation)
        {
            bool exists = dealerManageDevicesPage.VerifyInstallationRequestCreated(installerEmail, companyLocation, RuntimeSettings.DefaultFindElementTimeout);
            
            if (exists)
            {
                return;
            }
            else
            {
                throw new NullReferenceException(string.Format("Installation Request not found"));
            }             
        }
    }
}
