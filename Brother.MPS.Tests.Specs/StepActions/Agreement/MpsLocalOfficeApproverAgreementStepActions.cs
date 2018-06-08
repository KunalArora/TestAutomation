using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Agreement
{
    public class MpsLocalOfficeApproverAgreementStepActions : MpsLocalOfficeStepActions
    {
        private readonly IWebDriver _loApproverWebDriver;
        private readonly IContextData _contextData;
        private readonly ITranslationService _translationService;


        public MpsLocalOfficeApproverAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            IRunCommandService runCommandService,
            IDevicesExcelHelper devicesExcelHelper,
            IClickBillExcelHelper clickBillExcelHelper,
            IServiceInstallationBillExcelHelper serviceInstallationBillExcelHelper,
            IUserResolver userResolver,
            ICalculationService calculationService)
            : base(
            webDriverFactory,
            contextData,
            pageService,
            context,
            urlResolver,
            loggingService,
            runtimeSettings,
            translationService,
            runCommandService,
            devicesExcelHelper,
            clickBillExcelHelper,
            serviceInstallationBillExcelHelper,
            userResolver,
            calculationService)
        {
            _loApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            _contextData = contextData;
            _translationService = translationService;
        }

        public DataQueryPage NavigateToReportsDataQuery(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.LocalApprovalReportingElement, localOfficeApproverDashBoardPage);
            var reportingDashboardPage = PageService.GetPageObject<LocalOfficeReportsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _loApproverWebDriver);
            ClickSafety(reportingDashboardPage.DataQueryElement, reportingDashboardPage);
            return PageService.GetPageObject<DataQueryPage>(RuntimeSettings.DefaultPageObjectTimeout, _loApproverWebDriver);
        }

        public LocalOfficeAgreementDevicesPage NavigateToAgreementDevicesPage(DataQueryPage dataQueryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage);
            return NavigateToAgreementDevicesPage(dataQueryPage, _loApproverWebDriver);
        }

        public LocalOfficeAgreementDevicesPage SendBulkInstallationRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return SendBulkInstallationRequest(localOfficeAgreementDevicesPage, _loApproverWebDriver);
        }

        public LocalOfficeAgreementDevicesPage SendSingleInstallationRequests(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return SendSingleInstallationRequests(localOfficeAgreementDevicesPage, _loApproverWebDriver);
        }

        public LocalOfficeAgreementSummaryPage RefinePreInstallAgreementAndNavigateToSummaryPage(DataQueryPage dataQueryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage);
            return RefinePreInstallAgreementAndNavigateToSummaryPage(dataQueryPage, _loApproverWebDriver);
        }

        public LocalOfficeAgreementDetailsPage ApplySpecialPricing(LocalOfficeAgreementSummaryPage localOfficeApproverAgreementSummaryPage, IEnumerable<SpecialPricingProperties> specialPriceList)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverAgreementSummaryPage, specialPriceList);

            bool isInstallationTab, isServiceTab;

            localOfficeApproverAgreementSummaryPage.ClickSpecialPricing();
            var localOfficeApproverAgreementManageSpecialPricing = PageService.GetPageObject<LocalOfficeAgreementManageSpecialPricingPage>(
                RuntimeSettings.DefaultPageObjectTimeout, _loApproverWebDriver);

            localOfficeApproverAgreementManageSpecialPricing.VerifyDisplayOfAppropriateTabs(
                _contextData.PrintersProperties, _contextData.ServicePackType, _contextData.Culture, out isInstallationTab, out isServiceTab);

            if (isInstallationTab)
            {
                localOfficeApproverAgreementManageSpecialPricing.EditInstallationPricesAndProceed(_contextData.PrintersProperties, specialPriceList);
            }

            if(isServiceTab)
            {
                localOfficeApproverAgreementManageSpecialPricing.EditServicePricesAndProceed(_contextData.PrintersProperties, specialPriceList);
            }

            var resourceIncludedInClickPrice = _translationService.GetServicePackTypeText(TranslationKeys.ServicePackType.IncludedInClickPrice, _contextData.Culture);
            var isCheckAutoCalculateClickPrice = _contextData.ServicePackType == resourceIncludedInClickPrice;
            localOfficeApproverAgreementManageSpecialPricing.EditClickPricesAndProceed(
                _contextData.PrintersProperties, _contextData.ServicePackType, specialPriceList, isCheckAutoCalculateClickPrice);

            VerifySpecialPricing(localOfficeApproverAgreementManageSpecialPricing, specialPriceList);
            localOfficeApproverAgreementManageSpecialPricing.ConfirmSpecialPricingAndApply();

            return PageService.GetPageObject<LocalOfficeAgreementDetailsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loApproverWebDriver);
        }

        private void VerifySpecialPricing(LocalOfficeAgreementManageSpecialPricingPage localOfficeApproverAgreementManageSpecialPricing, IEnumerable<SpecialPricingProperties> specialPriceList)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverAgreementManageSpecialPricing, specialPriceList);

            // AuditDetails for example:
            // Model: DCP-8110DN Installation - Unit Cost: £120.00 / Margin: 0.00 % / Unit Price: £120.00\r\n
            // Model: DCP-8110DN Service - Unit Cost: £50.00 / Margin: 0.00 % / Unit Price: £50.00\r\n
            // Model: DCP-8110DN Click Price - Coverage: 15.00 % / Volume: 4,100 / Margin: 0.00 % / Click Price: £0.01068\r\n
            // Model: DCP-L8450CDW Click Price - Colour: Coverage: 30.00 % / Volume: 1,100 / Margin: 0.00 % / Click Price: £0.06141 Mono: Coverage: 15.00 % / Volume: 1,100 / Margin: 0.00 % / Click Price: £0.00774\r\n
            string[] auditDetails = localOfficeApproverAgreementManageSpecialPricing.GetAuditDetails();
            string cs = _contextData.CultureInfo.NumberFormat.CurrencySymbol;
            foreach (var printerProperty in _contextData.PrintersProperties)
            {
                var specialPrice = specialPriceList.First(l => Regex.IsMatch(printerProperty.Model, l.Model)); ;
                var message = "VerifySpecialPricing() error: {1} category = {0}, model = " + printerProperty.Model;
                if (printerProperty._IsApplySpecialPriceInstall)
                {
                    var category = "Installation";
                    var actual = auditDetails.FirstOrDefault(ad => ad.Contains(printerProperty.Model) && ad.Contains(category));
                    Assert.NotNull(actual, message, category, "audit details not found");
                    StringAssert.Contains(string.Format("Unit Cost: {0}{1}", cs, printerProperty.InstallationPackPrice), actual, message, category, "Contains");
                }
                if (printerProperty._IsApplySpecialPriceService)
                {
                    var category = "Service";
                    var actual = auditDetails.FirstOrDefault(ad => ad.Contains(printerProperty.Model) && ad.Contains(category));
                    Assert.NotNull(actual, message, category, "audit details not found");
                    StringAssert.Contains(string.Format("Unit Cost: {0}{1}", cs, printerProperty.ServicePackPrice), actual, message, category, "Contains");
                }
                if (printerProperty._IsApplySpecialPriceClickPrice)
                {
                    var category = "Click Price";
                    var actual = auditDetails.FirstOrDefault(ad => ad.Contains(printerProperty.Model) && ad.Contains(category));
                    Assert.NotNull(actual, message, category, "audit details not found");
                    var indexMono = Math.Max(actual.IndexOf("Mono:"), 0);
                    var indexColour = actual.IndexOf("Colour:");
                    var actualDat = indexMono > indexColour ? actual.Substring(indexMono) : actual.Substring(0, indexColour);
                    StringAssert.Contains(string.Format("Coverage: {0:n2} %", printerProperty.CoverageMono), actualDat, message, category, "Contains CoverageMono" );
                    StringAssert.Contains(string.Format("Volume: {0:n0}", printerProperty.VolumeMono), actualDat, message, category, "Contains VolumeMono" );
                    StringAssert.Contains(string.Format("Click Price: {0}{1}", cs,printerProperty.MonoClickPrice), actualDat, message, category, "Contains MonoClickPrice");

                }
                if (printerProperty._IsApplySpecialPriceClickPrice && printerProperty.IsMonochrome == false)
                {
                    var category = "Click Price";
                    var actual = auditDetails.FirstOrDefault(ad => ad.Contains(printerProperty.Model) && ad.Contains(category));
                    Assert.NotNull(actual, message, category, "audit details not found");
                    var indexMono = actual.IndexOf("Mono:");
                    var indexColour = actual.IndexOf("Colour:");
                    Assert.IsTrue(indexColour >= 0, message, category, "Colour not found");
                    var actualDat = indexMono > indexColour ? actual.Substring(0, indexMono) : actual.Substring(indexColour);
                    StringAssert.Contains(string.Format("Coverage: {0:n2} %", printerProperty.CoverageColour), actualDat, message, category, "Contains CoverageColour");
                    StringAssert.Contains(string.Format("Volume: {0:n0}", printerProperty.VolumeColour), actualDat, message, category, "Contains VolumeColour ");
                    StringAssert.Contains(string.Format("Click Price: {0}{1}", cs, printerProperty.ColourClickPrice), actualDat, message, category, "Contains ColourClickPrice");
                }

            }

        }

        public void VerifySpecialPricing(LocalOfficeAgreementDetailsPage localOfficeApproverAgreementDetailsPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverAgreementDetailsPage);

            localOfficeApproverAgreementDetailsPage.VerifySpecialPricing(_contextData.PrintersProperties, _contextData.ServicePackType);
        }

        public LocalOfficeAgreementDevicesPage SendReinstallDeviceRequest(LocalOfficeAgreementDevicesPage localOfficeApproverAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverAgreementDevicesPage);

            return SendReinstallDeviceRequest(localOfficeApproverAgreementDevicesPage, _loApproverWebDriver);
        }
    }
}
