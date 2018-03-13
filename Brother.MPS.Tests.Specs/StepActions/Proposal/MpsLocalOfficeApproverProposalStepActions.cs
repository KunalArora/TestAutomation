using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Proposal
{
    public class MpsLocalOfficeApproverProposalStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IWebDriver _localOfficeApproverWebDriver;
        private readonly IContextData _contextData;
        private readonly ITranslationService _translationService;

        public MpsLocalOfficeApproverProposalStepActions(IWebDriverFactory webDriverFactory,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            ILoggingService loggingService,
            MpsContextData contextData,
            MpsSignInStepActions mpsSignIn)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _localOfficeApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            _translationService = translationService;
        }

        public LocalOfficeApproverDashBoardPage SignInAsLocalOfficeApproverAndNavigateToDashboard(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            return _mpsSignIn.SignInAsLocalOfficeApprover(email, password, url);
        }

        public LocalOfficeApproverApprovalPage NavigateToApprovalDashboard(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.ApprovalTabElement, localOfficeApproverDashBoardPage);
            return PageService.GetPageObject<LocalOfficeApproverApprovalPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverProposalsPage NavigateToApprovalListPage(LocalOfficeApproverApprovalPage localOfficeApproverApprovalPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalPage);
            ClickSafety( localOfficeApproverApprovalPage.ProposalLinkElement, localOfficeApproverApprovalPage );
            return PageService.GetPageObject<LocalOfficeApproverProposalsPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalProposalsSummaryPage NavigateToViewSummary(LocalOfficeApproverProposalsPage localOfficeApproverProposalsPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverProposalsPage);
            int proposalId = _contextData.ProposalId;
            localOfficeApproverProposalsPage.ClickOnSummaryPage(proposalId, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalProposalsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalProposalsApprovedPage ApproveProposal(LocalOfficeApproverApprovalProposalsSummaryPage localOfficeApproverAprovalProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverAprovalProposalsSummaryPage);
            localOfficeApproverAprovalProposalsSummaryPage.ClickOnAccept();
            return PageService.GetPageObject<LocalOfficeApproverApprovalProposalsApprovedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverReportsDataQueryPage NavigateToReportsDataQueryPage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.LocalApprovalReportingElement, localOfficeApproverDashBoardPage);
            var localOfficeApproverReportsDashboardPage =  PageService.GetPageObject<LocalOfficeApproverReportsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            ClickSafety( localOfficeApproverReportsDashboardPage.DataQueryElement, localOfficeApproverReportsDashboardPage);
            return PageService.GetPageObject<LocalOfficeApproverReportsDataQueryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverReportsProposalSummaryPage ClickOnValidateAndApplySpecialPricing(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalSpecialPricingPage);
            localOfficeApproverApprovalSpecialPricingPage.SeleniumHelper.WaitUntil(d => {
                var isDisplayed = localOfficeApproverApprovalSpecialPricingPage.NextButton.Displayed;
                var isHidden = localOfficeApproverApprovalSpecialPricingPage.NextButton.GetAttribute("class").Contains("hidden");
                if (isDisplayed == false || isHidden) return true; 
                ClickSafety(localOfficeApproverApprovalSpecialPricingPage.NextButton, localOfficeApproverApprovalSpecialPricingPage);
                return false;
            });
            ClickSafety(localOfficeApproverApprovalSpecialPricingPage.ValidateButton, localOfficeApproverApprovalSpecialPricingPage);
            localOfficeApproverApprovalSpecialPricingPage.EnterAdditionalAuditInformation();
            ClickSafety(localOfficeApproverApprovalSpecialPricingPage.ApplySpecialPricing, localOfficeApproverApprovalSpecialPricingPage, IsUntilUrlChanges:true);
            return PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);            
        }

        public LocalOfficeApproverReportsProposalSummaryPage NavigateToReportsProposalSummaryPage(LocalOfficeApproverReportsDataQueryPage localOfficeApproverReportsDataQueryPage, int proposalId )
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsDataQueryPage, proposalId);
            var proposalIdString = proposalId.ToString();
            localOfficeApproverReportsDataQueryPage.ClickOnSearchedProposal(proposalId);
            return PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void PopulateSpecialPricingInstallation(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage, IEnumerable<SpecialPricingProperties> specialPriceList)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalSpecialPricingPage, specialPriceList);
            localOfficeApproverApprovalSpecialPricingPage.SwitchNavInstallTab();

            foreach (var specialPrice in specialPriceList)
            {
                localOfficeApproverApprovalSpecialPricingPage.EnterSpecialPriceInstallation(specialPrice);
            }
        }
        public void PopulateSpecialPricingService(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage, IEnumerable<SpecialPricingProperties> specialPriceList)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalSpecialPricingPage, specialPriceList);
            localOfficeApproverApprovalSpecialPricingPage.SwitchNavServiceTab();

            foreach (var specialPrice in specialPriceList)
            {
                localOfficeApproverApprovalSpecialPricingPage.EnterSpecialPriceService(specialPrice);
            }
        }

        public void PopulateSpecialPricingClickPrice(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage, IEnumerable<SpecialPricingProperties> specialPriceClickList)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalSpecialPricingPage, specialPriceClickList);
            localOfficeApproverApprovalSpecialPricingPage.SwitchNavClickTab();

            foreach( var specialPrice in specialPriceClickList) {
                localOfficeApproverApprovalSpecialPricingPage.EnterSpecialPriceClick(specialPrice);
            }
            
        }

        public void AssertSpecialPriceInTheAudit(IEnumerable<SpecialPricingProperties> expectedSpecialPriceList, LocalOfficeApproverReportsProposalSummaryPage localOfficeApproverReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(expectedSpecialPriceList, localOfficeApproverReportsProposalSummaryPage);
            var regexModelService = new Regex("^Model: \\S+ Service$");
            var regexModelClickPrice = new Regex("^Model: \\S+ Click Price$");
            // for example logItem:
            // Model: DCP-8110DN Service - Unit Cost: £120.00 / Margin: 50.00 % / Unit Price: £240.00
            // Model: DCP-8110DN Service - Unit Cost: 120,00 € / Margin: 50,00% / Unit Price: 240,00 €"
            // Model: DCP-8250DN Click Price - Coverage: 10,00% / Volume: 100 / Margin: 50,00% / Click Price: 0,01300 €
            // Model: DCP-L8450CDW Click Price - Colour: Coverage: 40,00% / Volume: 300 / Margin: 50,00% / Click Price: 0,10700 € Mono: Coverage: 10,00% / Volume: 100 / Margin: 50,00% / Click Price: 0,01300 €
            var logList = localOfficeApproverReportsProposalSummaryPage.GetAuditLogDetailsList();
            var currencySymbol = MpsUtil.GetCurrencySymbol(ContextData.Country.CountryIso);
            foreach (var logItem in logList)
            {
                var logItemArr = logItem.Split(new string[] { " - " }, StringSplitOptions.None);
                var logCmd = logItemArr[0].Trim();
                if (regexModelService.IsMatch(logCmd))
                {
                    var model = logCmd.Split(' ')[1].Trim(); // ex. DCP-8110DN
                    var specialPrice = expectedSpecialPriceList.FirstOrDefault(sp => Regex.IsMatch(model, sp.Model));
                    Assert.NotNull(specialPrice, "not found special price model in Garkin, find model=", model);
                    var actualFull = logItemArr[1].Trim();
                    var actualValue = actualFull.Replace(currencySymbol, "").Replace("%", "");
                    var logAppend = "model = " + model + ", actual = " + actualFull;

                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.ServiceUnitCost) 
                        || actualValue.Contains("Unit Cost: "+specialPrice.ServiceUnitCost), 
                        "Service/Unit Cost "+logAppend);
                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.ServiceMargin) 
                        || actualValue.Contains("Margin: "+specialPrice.ServiceMargin), 
                        "Service/Margin "+logAppend);
                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.ServiceUnitPrice) 
                        || actualValue.Contains("Unit Price: "+specialPrice.ServiceMargin), 
                        "Service/Unit Price "+logAppend);

                }
                if (regexModelClickPrice.IsMatch(logCmd))
                {
                    var model = logCmd.Split(' ')[1].Trim(); // ex. DCP-8110DN
                    var specialPrice = expectedSpecialPriceList.FirstOrDefault(sp => Regex.IsMatch(model, sp.Model));
                    Assert.NotNull(specialPrice, "not found special price model in Garkin, find model=", model);
                    var actualFull = logItemArr[1].Trim();
                    var actualValue = actualFull.Replace(currencySymbol, "").Replace("%", "");
                    var indexOfMono = actualValue.IndexOf("Mono:");
                    var indexOfColour = actualValue.IndexOf("Colour:");
                    var actualColorLog = (indexOfColour >= 0) ? actualValue.Substring(0, indexOfMono) : "";
                    var actualMonoLog = (indexOfColour >= 0) ? actualValue.Substring(indexOfMono) : actualValue;
                    var logAppend = string.Format("model={0}, actual={1} ", model, actualFull);

                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.MonoClickCoverage)
                        || actualMonoLog.Contains("Coverage: "+specialPrice.MonoClickCoverage),
                        "Click Price/Coverage(Mono) "+logAppend);
                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.MonoClickVolume)
                        || actualMonoLog.Contains("Volume: "+specialPrice.MonoClickVolume),
                        "Click Price/Volume(Mono) "+logAppend);
                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.MonoClickMargin)
                        || actualMonoLog.Contains("Margin: "+specialPrice.MonoClickMargin),
                        "Click Price/Margin(Mono) "+logAppend);
                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.MonoClick)
                        || actualMonoLog.Contains("Click Price: "+specialPrice.MonoClick),
                        "Click Price/Click Price(Mono) "+logAppend);

                    if (string.IsNullOrWhiteSpace(actualColorLog)) { continue; }

                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.ColourClickCoverage)
                        || actualColorLog.Contains("Coverage: " + specialPrice.ColourClickCoverage),
                        "Click Price/Coverage(Colour) "+logAppend);
                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.ColourClickVolume)
                        || actualColorLog.Contains("Volume: " + specialPrice.ColourClickVolume),
                        "Click Price/Volume(Colour) "+logAppend);
                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.ColourClickMargin)
                        || actualColorLog.Contains("Margin: " + specialPrice.ColourClickMargin),
                        "Click Price/Margin(Colour) "+logAppend);
                    Assert.True(string.IsNullOrWhiteSpace(specialPrice.ColourClick)
                        || actualColorLog.Contains("Click Price: " + specialPrice.ColourClick),
                        "Click Price/Click Price(Colour) "+logAppend);

                }
            }
        }

        public LocalOfficeApproverApprovalSpecialPricingPage ClickOnSpecialPricing(LocalOfficeApproverReportsProposalSummaryPage localOfficeApproverReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalSummaryPage);
            ClickSafety(localOfficeApproverReportsProposalSummaryPage.ButtonSpecialPricing, localOfficeApproverReportsProposalSummaryPage);
            return PageService.GetPageObject<LocalOfficeApproverApprovalSpecialPricingPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsSummaryPage ClickViewSummary(LocalOfficeApproverContractsAwaitingAcceptancePage localofficeApproverApprovalContractsAwaitingAcceptancePage, int proposalId)
        {
            LoggingService.WriteLogOnMethodEntry(localofficeApproverApprovalContractsAwaitingAcceptancePage, proposalId);
            localofficeApproverApprovalContractsAwaitingAcceptancePage.ClickOnViewSummary(proposalId, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsAcceptedPage AcceptContract(LocalOfficeApproverApprovalContractsSummaryPage localOfficeApproverApprovalContractsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalContractsSummaryPage);
            localOfficeApproverApprovalContractsSummaryPage.OnClickAccept();
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void VerifyAcceptContract(LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage, int proposalId, string proposalName)
        {
            LoggingService.WriteLogOnMethodEntry(_localOfficeApproverApprovalContractsAcceptedPage, proposalId, proposalName);
            _localOfficeApproverApprovalContractsAcceptedPage.VerifyContractFilter(proposalId, proposalName);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject, bool IsUntilUrlChanges = false)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element, IsUntilUrlChanges: IsUntilUrlChanges);
        }


        public LocalOfficeApproverApprovalProposalsDeclinedPage DeclineProposal(LocalOfficeApproverApprovalProposalsSummaryPage localOfficeApproverApprovalProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalProposalsSummaryPage);
            string proposalDeclineReasonExpired = _translationService.GetProposalDeclineReasonText(TranslationKeys.ProposalDeclineReason.Expired, _contextData.Culture);

            localOfficeApproverApprovalProposalsSummaryPage.DeclineProposal(proposalDeclineReasonExpired);
            return PageService.GetPageObject<LocalOfficeApproverApprovalProposalsDeclinedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

    }
}
