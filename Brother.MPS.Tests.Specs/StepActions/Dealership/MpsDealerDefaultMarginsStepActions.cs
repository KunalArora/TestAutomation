using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Dealership
{
    public class MpsDealerDefaultMarginsStepActions : StepActionBase
    {
        private readonly ILoggingService _loggingService;
        private readonly IContextData _contextData;
        private readonly IWebDriver _dealerWebDriver;
        private readonly IMpsWebToolsService _webToolService;
        private readonly IRunCommandService _runCommandService;
        private readonly ITranslationService _translationService;
        private readonly IPageParseHelper _pageParseHelper;

        public MpsDealerDefaultMarginsStepActions(
            IPageParseHelper pageParseHelper,
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
            _pageParseHelper = pageParseHelper;
        }

        public DealerAdminDefaultMarginsPage NavigateToDealerMarginsPage(DealerAdminDashBoardPage dealerAdminDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDashboardPage);
            dealerAdminDashboardPage.SeleniumHelper.ClickSafety(dealerAdminDashboardPage.DefaultMarginsElement, IsUntilUrlChanges: true);
            return PageService.GetPageObject<DealerAdminDefaultMarginsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void AssertAreSelectDefaultMarginsTab(DealerAdminDefaultMarginsPage dealerAdminDefaultMarginsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDefaultMarginsPage);
            Assert.True(dealerAdminDefaultMarginsPage.DefaultMarginsElement.Displayed, "AssertAreSelectDefaultMarginsTab() Default Margins tab not found");
        }

        public DealerDefaultMargins SetDealerMargins(DealerAdminDefaultMarginsPage dealerAdminDefaultMarginsPage, DealerDefaultMargins dealerAdminDefaultMargins )
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDefaultMarginsPage, dealerAdminDefaultMargins);

            var originalMarginsForRestore = new DealerDefaultMargins();
            originalMarginsForRestore.HardwareDefaultMargin = double.Parse(dealerAdminDefaultMarginsPage.HardwareDefaultMargin.GetAttribute("value"), _contextData.CultureInfo);
            originalMarginsForRestore.AccessoriesDefaultMargin = double.Parse(dealerAdminDefaultMarginsPage.AccessoriesDefaultMargin.GetAttribute("value"), _contextData.CultureInfo);
            originalMarginsForRestore.DeliveryDefaultMargin = double.Parse(dealerAdminDefaultMarginsPage.DeliveryDefaultMargin.GetAttribute("value"), _contextData.CultureInfo);
            originalMarginsForRestore.InstallationDefaultMargin = double.Parse(dealerAdminDefaultMarginsPage.InstallationDefaultMargin.GetAttribute("value"), _contextData.CultureInfo);
            originalMarginsForRestore.ServicePackDefaultMargin = double.Parse(dealerAdminDefaultMarginsPage.ServicePackDefaultMargin.GetAttribute("value"), _contextData.CultureInfo);
            originalMarginsForRestore.MonoClickDefaultCommission = double.Parse(dealerAdminDefaultMarginsPage.MonoClickDefaultMargin.GetAttribute("value"), _contextData.CultureInfo);
            originalMarginsForRestore.ColourClickDefaultCommission = double.Parse(dealerAdminDefaultMarginsPage.ColourClickDefaultMargin.GetAttribute("value"), _contextData.CultureInfo);
            
            dealerAdminDefaultMarginsPage.ClearAndType(dealerAdminDefaultMarginsPage.HardwareDefaultMargin, dealerAdminDefaultMargins.HardwareDefaultMargin.ToString("N2", _contextData.CultureInfo));
            dealerAdminDefaultMarginsPage.ClearAndType(dealerAdminDefaultMarginsPage.AccessoriesDefaultMargin, dealerAdminDefaultMargins.AccessoriesDefaultMargin.ToString("N2", _contextData.CultureInfo));
            dealerAdminDefaultMarginsPage.ClearAndType(dealerAdminDefaultMarginsPage.DeliveryDefaultMargin, dealerAdminDefaultMargins.DeliveryDefaultMargin.ToString("N2", _contextData.CultureInfo));
            dealerAdminDefaultMarginsPage.ClearAndType(dealerAdminDefaultMarginsPage.InstallationDefaultMargin, dealerAdminDefaultMargins.InstallationDefaultMargin.ToString("N2", _contextData.CultureInfo));
            dealerAdminDefaultMarginsPage.ClearAndType(dealerAdminDefaultMarginsPage.ServicePackDefaultMargin, dealerAdminDefaultMargins.ServicePackDefaultMargin.ToString("N2", _contextData.CultureInfo));
            dealerAdminDefaultMarginsPage.ClearAndType(dealerAdminDefaultMarginsPage.MonoClickDefaultMargin, dealerAdminDefaultMargins.MonoClickDefaultCommission.ToString("N2", _contextData.CultureInfo));
            dealerAdminDefaultMarginsPage.ClearAndType(dealerAdminDefaultMarginsPage.ColourClickDefaultMargin, dealerAdminDefaultMargins.ColourClickDefaultCommission.ToString("N2", _contextData.CultureInfo));

            return originalMarginsForRestore;
        }


        public DealerAdminDefaultMarginsPage ClickOnSave(DealerAdminDefaultMarginsPage dealerAdminDefaultMarginsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDefaultMarginsPage);
            dealerAdminDefaultMarginsPage.SeleniumHelper.ClickSafety(dealerAdminDefaultMarginsPage.DealerDefaultsSaveButton);
            return PageService.GetPageObject<DealerAdminDefaultMarginsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifyDefaultMarginsWillBeAmended(DealerDefaultMargins expectedDealerAdminDefaultMargins, IEnumerable<PrinterProperties> printersProperties)
        {
            LoggingService.WriteLogOnMethodEntry(expectedDealerAdminDefaultMargins, printersProperties);
            var dealerProposalsCreateSummaryPage = PageService.GetPageObject<DealerProposalsCreateSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            var actualValues = _pageParseHelper.ParseSummaryPageValues(dealerProposalsCreateSummaryPage.SeleniumHelper);
            foreach( var prop in printersProperties)
            {
                VerifyDefaultMarginsWillBeAmended(expectedDealerAdminDefaultMargins, actualValues, prop.Model, prop.IsMonochrome);
            }
        }

        private void VerifyDefaultMarginsWillBeAmended(DealerDefaultMargins expected, Dictionary<string,string> actualValues,  string model, bool isMonochrome)
        {
            LoggingService.WriteLogOnMethodEntry(expected, actualValues, model, isMonochrome);
            Assert.AreEqual(SPrintN2(expected.HardwareDefaultMargin), actualValues[model + ".HardwareMarginPercentage"], "Incorrect HardwareMarginPercentage");
            Assert.AreEqual(SPrintN2(expected.AccessoriesDefaultMargin), actualValues[model + ".AccessoryMarginPercentage"], "Incorrect AccessoryMarginPercentage");
            Assert.AreEqual(SPrintN2(expected.DeliveryDefaultMargin), actualValues[model + ".DeliveryMarginPercentage"], "Incorrect DeliveryMarginPercentage");
            Assert.AreEqual(SPrintN2(expected.InstallationDefaultMargin), actualValues[model + ".InstallationPackMarginPercentage"], "Incorrect InstallationPackMarginPercentage");
            Assert.AreEqual(SPrintN2(expected.ServicePackDefaultMargin), actualValues[model + ".ServicePackMarginPercentage"], "Incorrect ServicePackMarginPercentage");
            Assert.AreEqual(SPrintN2(expected.MonoClickDefaultCommission), actualValues[model + ".MonoMarginPercentage"], "Incorrect MonoMarginPercentage");
            if(isMonochrome == false)
            {
                Assert.AreEqual(SPrintN2(expected.ColourClickDefaultCommission), actualValues[model + ".ColourMarginPercentage"], "Incorrect ColourMarginPercentage");
            }            
        }

        private string SPrintN2(double arg)
        {
            return string.Format("{0:N2} %", arg, _contextData.CultureInfo);
        }

    }


}
