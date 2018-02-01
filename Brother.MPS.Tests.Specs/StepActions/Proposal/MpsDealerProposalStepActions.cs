using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Proposal
{
    public class MpsDealerProposalStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IContextData _contextData;
        private readonly ICalculationService _calculationService;
        private readonly IWebDriver _dealerWebDriver;
        private readonly IPdfHelper _pdfHelper;
        private readonly IMpsWebToolsService _webToolService;
        private readonly ILoggingService _loggingService;
        private readonly ITranslationService _translationService;

        public MpsDealerProposalStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ICalculationService calculationService,
            IPdfHelper pdfHelper,
            IRuntimeSettings runtimeSettings,
            IMpsWebToolsService webToolService,
            ILoggingService loggingService,
            ITranslationService translationService,
            MpsSignInStepActions mpsSignIn)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _calculationService = calculationService;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _pdfHelper = pdfHelper;
            _webToolService = webToolService;
            _loggingService = loggingService;
            _translationService = translationService;
        }
        
        public DealerDashBoardPage SignInAsDealerAndNavigateToDashboard(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            return _mpsSignIn.SignInAsDealer(email, password, url);
        }

        public DealerProposalsCreateDescriptionPage NavigateToCreateProposalPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            ClickSafety( dealerDashboardPage.CreateProposalLinkElement, dealerDashboardPage) ;
            return PageService.GetPageObject<DealerProposalsCreateDescriptionPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateCustomerInformationPage PopulateProposalDescriptionAndProceed(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage,
            string proposalName,
            string leadCodeReference,
            string contractType)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateDescriptionPage, proposalName, leadCodeReference, contractType);
            PopulateProposalDescription(dealerProposalsCreateDescriptionPage, proposalName, leadCodeReference, contractType);

            ClickSafety( dealerProposalsCreateDescriptionPage.NextButton, dealerProposalsCreateDescriptionPage);
            return PageService.GetPageObject<DealerProposalsCreateCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateTermAndTypePage PopulateProposalCustomerInformationAndProceed(DealerProposalsCreateCustomerInformationPage dealerProposalsCreateCustomerInformationPage, CustomerInformationOption customerInformationOption)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateCustomerInformationPage, customerInformationOption);
            switch (customerInformationOption)
            {
                case CustomerInformationOption.Existing:
                    //SelectExistingCustomer()
                    //break;
                    throw new NotImplementedException();
                case CustomerInformationOption.New:
                    return CreateCustomerForProposal(dealerProposalsCreateCustomerInformationPage);
                    
                case CustomerInformationOption.Skip:
                    return SkipCustomerCreationForProposal(dealerProposalsCreateCustomerInformationPage);

                default:
                    throw new NotImplementedException();
            }
        }

        public DealerProposalsCreateTermAndTypePage SkipCustomerCreationForProposal(DealerProposalsCreateCustomerInformationPage dealerProposalsCreateCustomerInformationPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateCustomerInformationPage);
            ClickSafety( dealerProposalsCreateCustomerInformationPage.SkipCustomerElement, dealerProposalsCreateCustomerInformationPage ) ;
            ClickSafety( dealerProposalsCreateCustomerInformationPage.NextButton, dealerProposalsCreateCustomerInformationPage ) ;
            return PageService.GetPageObject<DealerProposalsCreateTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateTermAndTypePage CreateCustomerForProposal(DealerProposalsCreateCustomerInformationPage dealerProposalsCreateCustomerInformationPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateCustomerInformationPage);
            ClickSafety( dealerProposalsCreateCustomerInformationPage.CreateNewCustomerElement, dealerProposalsCreateCustomerInformationPage )  ;
            ClickSafety( dealerProposalsCreateCustomerInformationPage.NextButton, dealerProposalsCreateCustomerInformationPage ) ;
            var detailInputPage = PageService.GetPageObject<DealerProposalsCreateCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            detailInputPage.FillOrganisationDetails();
            detailInputPage.FillOrganisationContactDetail();
            _contextData.CustomerEmail = dealerProposalsCreateCustomerInformationPage.GetEmail();
            _contextData.CustomerInformationName = dealerProposalsCreateCustomerInformationPage.GetCompanyName();
            _contextData.CustomerFirstName = dealerProposalsCreateCustomerInformationPage.GetFirstName();
            _contextData.CustomerLastName = dealerProposalsCreateCustomerInformationPage.GetLastName();
            ClickSafety( detailInputPage.NextButton, detailInputPage ) ;
            return PageService.GetPageObject<DealerProposalsCreateTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertTermAndTypePage CreateCustomerForProposal(DealerProposalsConvertCustomerInformationPage dealerProposalsConvertCustomerInformationPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsConvertCustomerInformationPage);
            ClickSafety( dealerProposalsConvertCustomerInformationPage.CreateNewCustomerElement, dealerProposalsConvertCustomerInformationPage ) ;
            ClickSafety( dealerProposalsConvertCustomerInformationPage.NextButton, dealerProposalsConvertCustomerInformationPage  ) ;
            var dealerProposalsConvertCustomerInformationPage2 = PageService.GetPageObject<DealerProposalsConvertCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            dealerProposalsConvertCustomerInformationPage2.FillOrganisationDetails();
            dealerProposalsConvertCustomerInformationPage2.FillOrganisationContactDetail();
            dealerProposalsConvertCustomerInformationPage2.FillOrganisationBankDetail("Invoice");
            ClickSafety( dealerProposalsConvertCustomerInformationPage2.NextButton, dealerProposalsConvertCustomerInformationPage2 ) ;
            return PageService.GetPageObject<DealerProposalsConvertTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateTermAndTypePage SelectExistingCustomerForProposal(DealerProposalsCreateCustomerInformationPage dealerProposalsCreateCustomerInformationPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateCustomerInformationPage);
            ClickSafety(dealerProposalsCreateCustomerInformationPage.SelectExistingCustomerElement, dealerProposalsCreateCustomerInformationPage);
            ClickSafety(dealerProposalsCreateCustomerInformationPage.NextButton, dealerProposalsCreateCustomerInformationPage);
            var dealerProposalsCreateCustomerInformationPage2 = PageService.GetPageObject<DealerProposalsCreateCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            dealerProposalsCreateCustomerInformationPage2.SelectExistingCustomer(_contextData.CustomerEmail);
            ClickSafety(dealerProposalsCreateCustomerInformationPage2.NextButton, dealerProposalsCreateCustomerInformationPage2);
            return PageService.GetPageObject<DealerProposalsCreateTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateProductsPage PopulateAgreementTermAndTypeAndProceed(DealerProposalsCreateTermAndTypePage dealerProposalsCreateTermAndTypePage,
            string usageType,
            string contractLength,
            string servicePackOption)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateTermAndTypePage, usageType, contractLength, servicePackOption);
            dealerProposalsCreateTermAndTypePage.SelectUsageType(usageType);
            dealerProposalsCreateTermAndTypePage.SelectContractLength(contractLength);

            ClickSafety( dealerProposalsCreateTermAndTypePage.NextButton, dealerProposalsCreateTermAndTypePage) ;
            return PageService.GetPageObject<DealerProposalsCreateProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateProductsPage PopulateProposalTermAndTypeAndProceed(DealerProposalsCreateTermAndTypePage dealerProposalsCreateTermAndTypePage,
            string usageType,
            string contractLength,
            string billingType,
            string servicePackOption)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateTermAndTypePage, usageType, contractLength, billingType, servicePackOption);
            // Populate Term and Type page for Type 1
            dealerProposalsCreateTermAndTypePage.PopulateTermAndTypeForType1(usageType, contractLength, billingType, servicePackOption);
            ClickSafety(dealerProposalsCreateTermAndTypePage.NextButton, dealerProposalsCreateTermAndTypePage) ;
            return PageService.GetPageObject<DealerProposalsCreateProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateClickPricePage AddPrinterToProposalAndProceed(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateProductsPage);
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                PopulatePrinterDetails(dealerProposalsCreateProductsPage, product.Model, product.Price, product.InstallationPack, product.IncludeDelivery);
            }
            ClickSafety( dealerProposalsCreateProductsPage.NextButtonElement, dealerProposalsCreateProductsPage)  ;
            return PageService.GetPageObject<DealerProposalsCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateSummaryPage CalculateClickPriceAndProceed(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateClickPricePage);
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                PopulatePrinterCoverageAndVolume(
                    dealerProposalsCreateClickPricePage, 
                    product.Model, 
                    product.CoverageMono, 
                    product.CoverageColour, 
                    product.VolumeMono, 
                    product.VolumeColour);
            }

            ClickSafety( dealerProposalsCreateClickPricePage.CalculateClickPriceElement, dealerProposalsCreateClickPricePage ) ;
            
            if(VerifyClickPriceValues(dealerProposalsCreateClickPricePage))
            {
                ClickSafety( dealerProposalsCreateClickPricePage.ProceedOnClickPricePageElement, dealerProposalsCreateClickPricePage) ;
                return PageService.GetPageObject<DealerProposalsCreateSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }
             
            return null;
        }

        public CloudExistingProposalPage SaveTheProposalAndProceed(DealerProposalsCreateSummaryPage dealerProposalsCreateSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateSummaryPage);
            int proposalId = dealerProposalsCreateSummaryPage.ReturnContractId();
            _contextData.ProposalId = proposalId;
            string resourceServicePackTypeIncludedInClickPrice = _translationService.GetServicePackTypeText(TranslationKeys.ServicePackType.IncludedInClickPrice, _contextData.Culture);


            // Validate calculations on Summary page           
            List<String> deviceTotalsElements = new List<String>();
            deviceTotalsElements.Add(dealerProposalsCreateSummaryPage.DeviceTotalsTotalCostNetElement.Text.Substring(1));
            deviceTotalsElements.Add(dealerProposalsCreateSummaryPage.DeviceTotalsTotalMarginNetElement.Text.Substring(1));

            _calculationService.VerifySum(
                deviceTotalsElements,
                dealerProposalsCreateSummaryPage.SummaryGrandDeviceTotalPriceElement.Text.Substring(1));
            _calculationService.VerifyGrossPrice(
                dealerProposalsCreateSummaryPage.SummaryGrandDeviceTotalPriceElement.Text.Substring(1),
                dealerProposalsCreateSummaryPage.SummaryContractGrandTotalPriceGrossElement.Text.Substring(1));
            
            // Validate content on Summary page 
            dealerProposalsCreateSummaryPage.VerifyProposalName(_contextData.ProposalName);
            dealerProposalsCreateSummaryPage.VerifyCustomerOrgName(_contextData.CustomerInformationName);
            dealerProposalsCreateSummaryPage.VerifyCorrectContractTermIsDisplayedOnSummaryPage(_contextData.ContractTerm);
            dealerProposalsCreateSummaryPage.VerifyCorrectBillingTermIsDisplayedOnSummaryPage(_contextData.BillingType);
            dealerProposalsCreateSummaryPage.VerifyCorrectUsageTypeIsDisplayedOnSummaryPage(_contextData.UsageType);
            dealerProposalsCreateSummaryPage.VerifyThatServicePackIsCorrectOnSummaryPage(_contextData.ServicePackType, resourceServicePackTypeIncludedInClickPrice);
            dealerProposalsCreateSummaryPage.VerifyTheCorrectPositionOfCurrencySymbol(_contextData.Country.CountryIso);

            dealerProposalsCreateSummaryPage.ClickSaveProposal();
            return PageService.GetPageObject<CloudExistingProposalPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifySavedProposalInOpenProposalsList(CloudExistingProposalPage cloudExistingProposalPage)
        {
            LoggingService.WriteLogOnMethodEntry(cloudExistingProposalPage);
            int proposalId = _contextData.ProposalId;
            string proposalName = _contextData.ProposalName;
            bool exists = cloudExistingProposalPage.VerifySavedProposalInOpenProposalsList(proposalId, proposalName);
            if (exists)
            {
                return;
            }
            else
            {
                new NullReferenceException(string.Format("Proposal = {0} not found ", proposalId));
            }             
        }

        public DealerProposalsConvertSummaryPage SubmitForTheApproval(CloudExistingProposalPage _cloudExistingProposalPage)
        {
            LoggingService.WriteLogOnMethodEntry(_cloudExistingProposalPage);
            int proposalId = _contextData.ProposalId;
            string proposalName = _contextData.ProposalName;

            _cloudExistingProposalPage.ClickOnSubmitForApproval(proposalId, proposalName, _dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsConvertSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateDescriptionPage ClickOnEditActionButton(CloudExistingProposalPage _cloudExistingProposalPage)
        {
            LoggingService.WriteLogOnMethodEntry(_cloudExistingProposalPage);
            int proposalId = _contextData.ProposalId;
            string proposalName = _contextData.ProposalName;

            _cloudExistingProposalPage.ClickOnEditActionButton(proposalId, proposalName, _dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsCreateDescriptionPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertCustomerInformationPage SubmitForApproval(CloudExistingProposalPage _cloudExistingProposalPage)
        {
            LoggingService.WriteLogOnMethodEntry(_cloudExistingProposalPage);
            int proposalId = _contextData.ProposalId;
            string proposalName = _contextData.ProposalName;

            _cloudExistingProposalPage.ClickOnSubmitForApproval(proposalId, proposalName, _dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsConvertCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertTermAndTypePage SetForApprovalInformationAndProceed(DealerProposalsConvertCustomerInformationPage dealerProposalsConvertCustomerInformationPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsConvertCustomerInformationPage);
            string paymentType = _translationService.GetPaymentTypeText(TranslationKeys.PaymentType.Invoice, _contextData.Culture);
            Country country = _contextData.Country;
            dealerProposalsConvertCustomerInformationPage.FillCustomerDetails(paymentType, country.Name);
            _contextData.CustomerEmail = dealerProposalsConvertCustomerInformationPage.GetEmail();
            _contextData.CustomerFirstName = dealerProposalsConvertCustomerInformationPage.GetFirstName();
            _contextData.CustomerLastName = dealerProposalsConvertCustomerInformationPage.GetLastName();
            _webToolService.RegisterCustomer(_contextData.CustomerEmail, _contextData.CustomerPassword, _contextData.CustomerFirstName, _contextData.CustomerLastName, country.CountryIso);


            ClickSafety(dealerProposalsConvertCustomerInformationPage.nextButtonElement, dealerProposalsConvertCustomerInformationPage);
            return PageService.GetPageObject<DealerProposalsConvertTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }


        public DealerDashBoardPage NavigateToDashboardPage(string baseUrl)
        {
            LoggingService.WriteLogOnMethodEntry(baseUrl);
            var dashBoardPage = new DealerDashBoardPage();
            return PageService.LoadUrl<DealerDashBoardPage>(baseUrl + dashBoardPage.PageUrl, RuntimeSettings.DefaultPageLoadTimeout, dashBoardPage.ValidationElementSelector, true, _dealerWebDriver);
        }

        public DealerProposalsApprovedPage NavigateToDealerProposalsApprovedPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            ClickSafety(dealerDashboardPage.ExistingProposalLinkElement, dealerDashboardPage);
            var dealerProposalsInprogressPage =  PageService.GetPageObject<DealerProposalsInprogressPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            ClickSafety(dealerProposalsInprogressPage.approvedProposalsTabElement, dealerProposalsInprogressPage);
            return PageService.GetPageObject<DealerProposalsApprovedPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver); ;
        }

        public void DeletePdfFileErrorIgnored(string pdfFile)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFile);
            try { _pdfHelper.DeletePdf(pdfFile); }catch { /* ignored */}
        }

        public void AssertAreAffectSpecialPricing(SummaryValue proposalSummaryValues)
        {
            LoggingService.WriteLogOnMethodEntry(proposalSummaryValues);
            var specialPriceClickList = _contextData.SpecialPriceList;
            foreach( var specialPriceClick in specialPriceClickList)
            {
                AssertAreAffectSpecialPricing(proposalSummaryValues, specialPriceClick);
            }
        }

        public void AssertAreAffectSpecialPricing(SummaryValue proposalSummaryValues, SpecialPricingProperties specialPriceClick)
        {
            LoggingService.WriteLogOnMethodEntry(proposalSummaryValues, specialPriceClick);
            var resourceServicePackTypeIncludedInClickPrice = _translationService.GetServicePackTypeText(TranslationKeys.ServicePackType.IncludedInClickPrice, _contextData.Culture);
            var model = specialPriceClick.Model;

            /**
             * Installation
             */
            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "InstallationPackUnitCost", specialPriceClick.InstallUnitCost);
            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "InstallationPackMarginPercentage", specialPriceClick.InstallMargin);
            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "InstallationPackUnitPrice", specialPriceClick.InstallUnitPrice);

            /**
             * Service
             */
            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "ServicePackUnitCost", specialPriceClick.ServiceUnitCost);
            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "ServicePackMarginPercentage", specialPriceClick.ServiceMargin);
            if(string.IsNullOrWhiteSpace(specialPriceClick.ServiceUnitPrice) == false)
            {
                var ServiceUnitPrice = _contextData.ServicePackType != resourceServicePackTypeIncludedInClickPrice ? specialPriceClick.ServiceUnitPrice : "0.00";
                AssertAreAffectSpecialPricing(proposalSummaryValues, model, "ServicePackUnitPrice", ServiceUnitPrice);
            }

            /**
             * Click Price
             */
            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "ServicePackUnitCost", specialPriceClick.MonoClickServiceCost);
            //AssertAreAffectSpecialPricing(proposalSummaryValues, model, "N/A", specialPriceClick.MonoClickServicePrice);

            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "MonoVolume", specialPriceClick.MonoClickVolume);
            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "MonoMarginPercentage", specialPriceClick.MonoClickMargin);
            // TODO bug? when INCLUDED_IN_CLICK_PRICE MPSBAU-1254 
            //AssertAreAffectSpecialPricing(proposalSummaryValues, model, "MonoClickRate", specialPriceClick.MonoClick);

            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "ColourVolume", specialPriceClick.ColourClickVolume);
            AssertAreAffectSpecialPricing(proposalSummaryValues, model, "ColourMarginPercentage", specialPriceClick.ColourClickMargin);
            // TODO bug? when INCLUDED_IN_CLICK_PRICE MPSBAU-1254 
            //AssertAreAffectSpecialPricing(proposalSummaryValues, model, "ColourClickRate", specialPriceClick.ColourClick);

        }
        private void AssertAreAffectSpecialPricing(SummaryValue proposalSummaryValues, string model, string itemKey, string expected )
        {
            LoggingService.WriteLogOnMethodEntry(proposalSummaryValues, model, itemKey, expected);
            if (string.IsNullOrEmpty(expected))
            {
                return; // check skipped
            }
            var itemRegex = new Regex(string.Format(@"{0}\.{1}",model,itemKey), RegexOptions.IgnoreCase);
            try
            {
                var wrongItem = proposalSummaryValues
                    .Where(item => itemRegex.IsMatch(item.Key))
                    .First(item => item.Value.CollectDigitOnly() != expected);
                var wrongModel = proposalSummaryValues.GetModel(wrongItem.Key);
                if (itemKey.Contains("Colour") && IsColourModel(proposalSummaryValues, wrongModel) == false)
                {
                    return; // no colour model
                }
                throw new Exception(string.Format("Special pricing not affected key={0} actual={1} expected={2}", wrongItem.Key, wrongItem.Value, expected));

            }
            catch (InvalidOperationException ) {/* no wrongItem is good news. */ }
        }

        private bool IsColourModel(SummaryValue proposalSummaryValues,string wrongModel)
        {
            LoggingService.WriteLogOnMethodEntry(proposalSummaryValues, wrongModel);
            var ckey = wrongModel + ".ColourVolume";
            string cvalue=null;
            if (proposalSummaryValues.TryGetValue(ckey, out cvalue) == false)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(cvalue) || cvalue == "0")
            {
                return false;
            }
            return true;
        }

        public void AssertAreEqualSummaryValues(string pdfFile, SummaryValue summaryValue)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFile, summaryValue);
            var resourcePdfFileAgreementPeriod = _translationService.GetProposalPdfText(TranslationKeys.ProposalPdf.AgreementPeriod, _contextData.Culture);
            var resourcePdfFileTotalInstalledPurchasePrice = _translationService.GetProposalPdfText(TranslationKeys.ProposalPdf.TotalInstalledPurchasePrice, _contextData.Culture);
            var resourcePdfFileMinimumClickCharge = _translationService.GetProposalPdfText(TranslationKeys.ProposalPdf.MinimumClickCharge, _contextData.Culture);
            Country country = _contextData.Country;

            if (_pdfHelper.PdfExists(pdfFile) == false)
            {
                throw new Exception("pdf not exists file=" + pdfFile);
            }
            var contractTermDigitString = new Regex(@"[^0-9]").Replace(summaryValue.SummaryTable_ContractTerm,"");
            string[] searchTextArray =
            {
                string.Format("{0} {1}", resourcePdfFileAgreementPeriod , int.Parse(contractTermDigitString)*12),
                string.Format("{0} {1}", resourcePdfFileTotalInstalledPurchasePrice, summaryValue.SummaryTable_DeviceTotalsTotalPriceNet),
                //TODO need to change the hard coded strings according to values of the Proposal. E.g:- Total Half Yearly Minimum Click Charge for UJ2
                string.Format("{0} {1}", resourcePdfFileMinimumClickCharge, summaryValue.SummaryTable_ConsumableTotalsTotalPriceNet)
            };
            searchTextArray.ToList().ForEach(expected =>
               {
                   if( _pdfHelper.PdfContainsText(pdfFile, expected) == false)
                   {
                       throw new Exception(string.Format("string not found in pdf. pdfFile=[{0}], expected=[{1}]", pdfFile, expected)) ;
                   }
               });
        }

        public DealerProposalsCreateCustomerInformationPage ClickOnNext(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateDescriptionPage);
            ClickSafety(dealerProposalsCreateDescriptionPage.NextButton, dealerProposalsCreateDescriptionPage);
            return PageService.GetPageObject<DealerProposalsCreateCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateSummaryPage ClickOnNext(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateClickPricePage);
            ClickSafety(dealerProposalsCreateClickPricePage.ProceedOnClickPricePageElement, dealerProposalsCreateClickPricePage);
            return PageService.GetPageObject<DealerProposalsCreateSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateClickPricePage ClickOnNext(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateProductsPage);
            ClickSafety(dealerProposalsCreateProductsPage.NextButtonElement, dealerProposalsCreateProductsPage);
            return PageService.GetPageObject<DealerProposalsCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateDescriptionPage ClickOnActionsEdit(DealerProposalsInprogressPage dealerProposalsInprogressPage, string filterString)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsInprogressPage, filterString);
            ActionsModule.SetFilter(filterString, dealerProposalsInprogressPage.ProposalFilter, dealerProposalsInprogressPage.ProposalListProposalNameRowElement, RuntimeSettings.DefaultFindElementTimeout, _dealerWebDriver);
            ActionsModule.ClickOnTheActionsDropdown(0, _dealerWebDriver);
            ActionsModule.StartTheProposalEditProcess(_dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsCreateDescriptionPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver); ;
        }

        public DealerProposalsInprogressPage ClickOnActionsCopy(DealerProposalsDeclinedPage dealerProposalsDeclinedPage, string filterString, out string proposalNameForSearch)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsDeclinedPage, filterString);
            ActionsModule.SetFilter(filterString, dealerProposalsDeclinedPage.InputFilterByElement, dealerProposalsDeclinedPage.NameRowElementList, RuntimeSettings.DefaultFindElementTimeout, _dealerWebDriver);
            proposalNameForSearch = dealerProposalsDeclinedPage.NameRowElementList[0].Text;
            ActionsModule.ClickOnTheActionsDropdown(0, _dealerWebDriver);
            ActionsModule.CopyAProposal(_dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsInprogressPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver); ;
        }

        public DealerProposalsDeclinedPage NavigateToDealerProposalsDeclinedPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            ClickSafety(dealerDashboardPage.ExistingProposalLinkElement, dealerDashboardPage);
            var dealerProposalsInprogressPage = PageService.GetPageObject<DealerProposalsInprogressPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            ClickSafety(dealerProposalsInprogressPage.DeclinedTabElement, dealerProposalsInprogressPage);
            return PageService.GetPageObject<DealerProposalsDeclinedPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsSummaryPage ClickOnViewSummary(DealerProposalsApprovedPage dealerProposalsApprovedPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsApprovedPage);
            int proposalId = _contextData.ProposalId;
            dealerProposalsApprovedPage.ClickOnSummaryPage(proposalId, _dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertProductsPage ClickNext(DealerProposalsConvertTermAndTypePage dealerProposalsConvertTermAndTypePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsConvertTermAndTypePage);
            ClickSafety( dealerProposalsConvertTermAndTypePage.NextButton, dealerProposalsConvertTermAndTypePage) ;
            return PageService.GetPageObject<DealerProposalsConvertProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public string DownloadPdf(DealerProposalsSummaryPage dealerProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsSummaryPage);
            var fileList = _pdfHelper.ListDownloadsFolder();
            ClickSafety(dealerProposalsSummaryPage.DownloadProposalPdfElement, dealerProposalsSummaryPage);
            var task = _pdfHelper.WaitforNewfile(fileList);
            if (task.Wait(new TimeSpan(0, 0, RuntimeSettings.DefaultDownloadTimeout)))
            {
                return task.Result;
            }else
            {
                throw new Exception("download pdf timeout");
            }
        }

        public DealerProposalsConvertClickPricePage ClickNext(DealerProposalsConvertProductsPage dealerProposalsConvertProductsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsConvertProductsPage);
            ClickSafety( dealerProposalsConvertProductsPage.NextButtonElement, dealerProposalsConvertProductsPage ) ;
            return PageService.GetPageObject<DealerProposalsConvertClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsInprogressPage NavigateToDealerProposalsInprogressPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            ClickSafety( dealerDashboardPage.proposalTopElement, dealerDashboardPage) ;
            return PageService.GetPageObject<DealerProposalsInprogressPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertSummaryPage SetInformationAndClickSubmitForApproval(DealerProposalsConvertClickPricePage dealerProposalsConvertClickPricePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsConvertClickPricePage);
            ClickSafety(dealerProposalsConvertClickPricePage.ProceedOnClickPricePageElement, dealerProposalsConvertClickPricePage);
            return PageService.GetPageObject<DealerProposalsConvertSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsAwaitingApprovalPage SubmitForApproval(DealerProposalsConvertSummaryPage dealerProposalsConvertSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsConvertSummaryPage);
            dealerProposalsConvertSummaryPage.EnterProposedStartDateForContract(); // Envisaged Start Date
            dealerProposalsConvertSummaryPage.GiveThirdPartyCheckApproval();       // Approval Has Been Given To Send Information To Brother
            ClickSafety( dealerProposalsConvertSummaryPage.SaveAsContractButton, dealerProposalsConvertSummaryPage) ;
            return PageService.GetPageObject<DealerProposalsAwaitingApprovalPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertCustomerInformationPage SubmitForApproval(DealerProposalsInprogressPage dealerProposalsInprogressPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsInprogressPage);
            dealerProposalsInprogressPage.ClickOnSubmitForApproval(_contextData.ProposalId, _dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsConvertCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }


        public DealerCustomersExistingPage NavigateToCustomersContractPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            ClickSafety( dealerDashboardPage.ExistingCustomerLinkElement, dealerDashboardPage);
            var nextPage = PageService.GetPageObject<DealerCustomersExistingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            return nextPage;
        }

        public DealerCustomersExistingPage CreateAndSaveANewCustomer(DealerCustomersManagePage dealerCustomersManagePage, Country country, string payment)
        {
            LoggingService.WriteLogOnMethodEntry(dealerCustomersManagePage, country, payment);
            dealerCustomersManagePage.FillCustomerDetails(payment, country.Name);
            _contextData.CustomerInformationName = dealerCustomersManagePage.GetCompanyName();
            _contextData.CustomerEmail = dealerCustomersManagePage.GetEmail();
            _contextData.CustomerFirstName = dealerCustomersManagePage.GetFirstName();
            _contextData.CustomerLastName = dealerCustomersManagePage.GetLastName();
            dealerCustomersManagePage.saveButtonElement.Click();
            _webToolService.RegisterCustomer(_contextData.CustomerEmail, _contextData.CustomerPassword, _contextData.CustomerFirstName, _contextData.CustomerLastName, _contextData.Country.CountryIso);
            var nextPage = PageService.GetPageObject<DealerCustomersExistingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            return nextPage;
        }

        public void ThenICanSeeTheCustomerCreatedAboveInTheCustomersContactsList(DealerCustomersExistingPage _dealerCustomersExistingPage, string customerInformationName, string customerEmail)
        {
            LoggingService.WriteLogOnMethodEntry(_dealerCustomersExistingPage, customerInformationName, customerEmail);
            bool exists = _dealerCustomersExistingPage.VerifyItemByName(customerInformationName, customerEmail);
            if (exists)
            {
                return;
            }
            else
            {
                new Exception(string.Format("Customer  = {0} not found ", customerInformationName));
            }
        }

        public DealerContractsApprovedProposalPage NavigateToDealerContractsApprovedProposalPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            ClickSafety( dealerDashboardPage.ExistingContractLinkElement, dealerDashboardPage );
            return PageService.GetPageObject<DealerContractsApprovedProposalPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerContractsSummaryPage ClickViewOffer(DealerContractsApprovedProposalPage dealerContractsApprovedProposalPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerContractsApprovedProposalPage);
            int proposalId = _contextData.ProposalId;
            dealerContractsApprovedProposalPage.ClickOnViewOffer(proposalId, _dealerWebDriver);
            return PageService.GetPageObject<DealerContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerContractsAwaitingAcceptancePage SignToContract(DealerContractsSummaryPage dealerContractsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerContractsSummaryPage);
            ClickSafety( dealerContractsSummaryPage.SignButtonElement, dealerContractsSummaryPage) ;
            return PageService.GetPageObject<DealerContractsAwaitingAcceptancePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerCustomersExistingPage NavigateToCustomersExistingPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            ClickSafety(dealerDashboardPage.ExistingCustomerLinkElement, dealerDashboardPage);
            return PageService.GetPageObject<DealerCustomersExistingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerCustomersManagePage NavigateToCustomersManagePage(DealerCustomersExistingPage dealerCustomersExistingPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerCustomersExistingPage);
            ClickSafety(dealerCustomersExistingPage.createCustomerButtonElement, dealerCustomersExistingPage);
            return PageService.GetPageObject<DealerCustomersManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public CloudExistingProposalPage ClickOnCopyWithCustomerTab(DealerProposalsDeclinedPage dealerProposalsDeclinedPage, int proposalId)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsDeclinedPage, proposalId);
            dealerProposalsDeclinedPage.ClickOnCopyWithCustomerActionItem(proposalId, _dealerWebDriver);
            return PageService.GetPageObject<CloudExistingProposalPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateCustomerInformationPage NavigateToProposalsCustomersPage(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateDescriptionPage);
            _contextData.ProposalName = dealerProposalsCreateDescriptionPage.GetProposalName();
            ClickSafety(dealerProposalsCreateDescriptionPage.NextButton, dealerProposalsCreateDescriptionPage);
            return PageService.GetPageObject<DealerProposalsCreateCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateTermAndTypePage NavigateToProposalTermAndTypePage(DealerProposalsCreateCustomerInformationPage dealerProposalsCreateCustomerInformationPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateCustomerInformationPage);
            ClickSafety(dealerProposalsCreateCustomerInformationPage.NextButton, dealerProposalsCreateCustomerInformationPage);
            return PageService.GetPageObject<DealerProposalsCreateTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateProductsPage NavigateToProposalProductsPage(DealerProposalsCreateTermAndTypePage dealerProposalsCreateTermAndTypePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateTermAndTypePage);
            ClickSafety(dealerProposalsCreateTermAndTypePage.NextButton, dealerProposalsCreateTermAndTypePage);
            return PageService.GetPageObject<DealerProposalsCreateProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateClickPricePage NavigateToProposalClickPricePage(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateProductsPage);
            ClickSafety(dealerProposalsCreateProductsPage.NextButtonElement, dealerProposalsCreateProductsPage);
            return PageService.GetPageObject<DealerProposalsCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateSummaryPage NavigateToCreateSummaryPage(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateClickPricePage);
            ClickSafety(dealerProposalsCreateClickPricePage.ProceedOnClickPricePageElement, dealerProposalsCreateClickPricePage);
            return PageService.GetPageObject<DealerProposalsCreateSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        #region private methods

        private void PopulateProposalDescription(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage,
            string proposalName,
            string leadCodeReference,
            string contractType)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateDescriptionPage, proposalName, leadCodeReference, contractType);
            dealerProposalsCreateDescriptionPage.PopulateProposalName(proposalName);
        }

        private void PopulatePrinterDetails(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage,
            string printerName,
            string printerPrice,
            string installationPack,
            bool delivery)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateProductsPage, printerName, printerPrice, installationPack, delivery);
            string margin, unitPrice, expectedTotalLinePrice;
            IWebElement printerContainer;

            string resourceServicePackTypeIncludedInClickPrice = _translationService.GetServicePackTypeText(TranslationKeys.ServicePackType.IncludedInClickPrice, _contextData.Culture);
            string servicePackType = _contextData.ServicePackType;

            var addProposalButton = dealerProposalsCreateProductsPage.PopulatePrinterDetails(
                printerName,
                printerPrice,
                installationPack,
                delivery,
                servicePackType,
                resourceServicePackTypeIncludedInClickPrice,
                out margin,
                out unitPrice,
                out printerContainer);

            List<string> totalPriceValues = dealerProposalsCreateProductsPage.RetrieveAllTotalPriceValues(
                printerContainer,
                out expectedTotalLinePrice);

            // Validate calculations on Products page
            _calculationService.VerifyTotalPrice(printerPrice, margin, unitPrice);
            _calculationService.VerifySum(totalPriceValues, expectedTotalLinePrice);

            dealerProposalsCreateProductsPage.ClickAddProposalButton(
                printerContainer, addProposalButton);
        }

        private void PopulatePrinterCoverageAndVolume( DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage,
            string printerName, int coverageMono, int coverageColour, int volumeMono, int volumeColour)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateClickPricePage, printerName, coverageMono, coverageColour, volumeMono, volumeColour);
            string resourceUsageTypePayAsYouGo = _translationService.GetUsageTypeText(TranslationKeys.UsageType.PayAsYouGo, _contextData.Culture);
            string usageType = _contextData.UsageType;

            IWebElement printerContainer = dealerProposalsCreateClickPricePage.PopulatePrinterCoverageAndVolume(
                printerName,
                coverageMono,
                coverageColour,
                volumeMono,
                volumeColour,
                usageType,
                resourceUsageTypePayAsYouGo
            );

            ValidateContentOnClickPricePage(dealerProposalsCreateClickPricePage, printerContainer);
        }

        private void ValidateContentOnClickPricePage(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage,
            IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateClickPricePage, printerContainer);
            string monoMargin, servicePackUnitCost, servicePackUnitPrice;
            string resourceServicePackTypeIncludedInClickPrice = _translationService.GetServicePackTypeText(TranslationKeys.ServicePackType.IncludedInClickPrice, _contextData.Culture);

            // Validate Service pack unit price when pack is 'Included in Click Price'     
            dealerProposalsCreateClickPricePage.ValidateServicePackContentOnClickPricePage(printerContainer,
                _contextData.ServicePackType, resourceServicePackTypeIncludedInClickPrice, 
                out monoMargin, out servicePackUnitCost, out servicePackUnitPrice);

            if ((new string[] { monoMargin, servicePackUnitCost, servicePackUnitPrice }).All(v => v != ""))
            {
                _calculationService.VerifyTotalPrice(
                                servicePackUnitCost, monoMargin, servicePackUnitPrice);
            }
        }

        private bool VerifyClickPriceValues(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerProposalsCreateClickPricePage);
            return dealerProposalsCreateClickPricePage.VerifyClickPriceValues();
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element);
        }
        #endregion
    }
 }
