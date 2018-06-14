using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.Resources.Binary;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Dealership
{
    [Binding]
    public class MpsDealerDealershipStepActions : StepActionBase
    {

        private readonly ILoggingService _loggingService;
        private readonly IContextData _contextData;
        private readonly IUrlResolver _urlResolver;
        private readonly IWebDriver _dealerWebDriver;
        private readonly IMpsWebToolsService _webToolService;
        private readonly IRunCommandService _runCommandService;
        private readonly ITranslationService _translationService;

        public MpsDealerDealershipStepActions(
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService,
            IMpsWebToolsService webToolService,
            IRunCommandService runCommandService,
            ITranslationService translationService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _loggingService = loggingService;
            _webToolService = webToolService;
            _runCommandService = runCommandService;
            _translationService = translationService;
        }

        public DealerAdminDashBoardPage NavigateToDealerAdminDashboardPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            dealerDashboardPage.NavigateToDealerAdminDashboardPage();

            return PageService.GetPageObject<DealerAdminDashBoardPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAdminDealershipUsersPage NavigateToDealershipUsersPage(DealerAdminDashBoardPage dealerAdminDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDashBoardPage);
            dealerAdminDashBoardPage.NavigateToDealershipUsersPage();

            return PageService.GetPageObject<DealerAdminDealershipUsersPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAdminDealershipUsersCreationPage ClickOnAddStaffMember(DealerAdminDealershipUsersPage dealerAdminDealershipUsersPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipUsersPage);
            dealerAdminDealershipUsersPage.ClickOnAddButton();

            return PageService.GetPageObject<DealerAdminDealershipUsersCreationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAdminDealershipUsersPage EnterSubDealerDetailsAndSave(DealerAdminDealershipUsersCreationPage dealerAdminDealershipUsersCreationPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipUsersCreationPage);
            dealerAdminDealershipUsersCreationPage.EnterSubDealerDetails();

            _contextData.SubDealerEmail = dealerAdminDealershipUsersCreationPage.GetEmail();
            _contextData.SubDealerFirstName = dealerAdminDealershipUsersCreationPage.GetFirstName();
            _contextData.SubDealerLastName = dealerAdminDealershipUsersCreationPage.GetLastName();

            _webToolService.RegisterCustomer(_contextData.SubDealerEmail, _contextData.SubDealerPassword, _contextData.SubDealerFirstName, _contextData.SubDealerLastName, _contextData.Country.CountryIso);

            dealerAdminDealershipUsersCreationPage.ClickOnCreate();
            return PageService.GetPageObject<DealerAdminDealershipUsersPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifySubDealer(DealerAdminDealershipUsersPage dealerAdminDealershipUsersPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipUsersPage);

            var resourceStaffAccessPermissionRestricted = _translationService.GetStaffAccessPermission(TranslationKeys.StaffAccessPermission.Restricted, _contextData.Culture);
            dealerAdminDealershipUsersPage.VerifySubDealer(_contextData.SubDealerEmail, resourceStaffAccessPermissionRestricted);
        }

        public  void ValidateDealershipProfileTab(DealerAdminProfileDealershipPage dealerAdminDealershipProfilePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipProfilePage);
            Assert.True(dealerAdminDealershipProfilePage.DealershipProfileTabElement.Displayed, "'Dealership Profile' tab not found");           
        }

        public string CreateUploadLogoFile()
        {
            LoggingService.WriteLogOnMethodEntry();
            var fullpath = Path.Combine(TestController.DownloadPath, string.Format("logotest-{0}.jpg",DateTime.Now.Ticks));
            using (var fs = File.Create(fullpath))
            {
                var jpegBinary = BinaryResource.onaka_heru_man_jpg;
                fs.Write(jpegBinary, 0, jpegBinary.Length);
            }
            return fullpath;
        }

        public DealerAdminProfileDealershipPage NavigateToDealershipProfilePage(DealerAdminDashBoardPage dealerAdminDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDashboardPage);
            dealerAdminDashboardPage.SeleniumHelper.ClickSafety(dealerAdminDashboardPage.DealershipProfileElement, IsUntilUrlChanges: true);
            return PageService.GetPageObject<DealerAdminProfileDealershipPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void UploadLogoToProfile(DealerAdminProfileDealershipPage dealerAdminDealershipProfilePage, string filePath)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipProfilePage,filePath);
            dealerAdminDealershipProfilePage.UploadLogo(filePath);
        }

        public void VerifyDealershipProfileWasUpdatedSuccessfully(DealerAdminProfileDealershipPage dealerAdminDealershipProfilePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipProfilePage);
            var SeleniumHelper = dealerAdminDealershipProfilePage.SeleniumHelper;
            if (SeleniumHelper.IsElementDisplayed(dealerAdminDealershipProfilePage.ValidationErrorsErrorContainerElement))
            {
                Assert.Fail("VerifyDealershipProfileWasUpdatedSuccessfully() may upload error. message={0}", dealerAdminDealershipProfilePage.ValidationErrorsErrorContainerElement.Text);
            }
            Assert.True(SeleniumHelper.IsElementDisplayed(dealerAdminDealershipProfilePage.CloseAlertSuccessElement), 
                "VerifyDealershipProfileWasUpdatedSuccessfully() updated successflly alert not found");
        }

        public void RemoveProfileLogo(DealerAdminProfileDealershipPage dealerAdminDealershipProfilePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipProfilePage);
            dealerAdminDealershipProfilePage.RemoveLogo();
        }
    }
}
