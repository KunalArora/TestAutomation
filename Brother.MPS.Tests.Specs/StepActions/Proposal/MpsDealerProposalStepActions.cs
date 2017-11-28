using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
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
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Proposal
{
    public class MpsDealerProposalStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IContextData _contextData;
        private readonly IWebDriver _dealerWebDriver;
        private readonly IPdfHelper _pdfHelper;

        public MpsDealerProposalStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IPdfHelper pdfHelper,
            RuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _pdfHelper = pdfHelper;
        }
        
        public DealerDashBoardPage SignInAsDealerAndNavigateToDashboard(string email, string password, string url)
        {
            return _mpsSignIn.SignInAsDealer(email, password, url);
        }

        public DealerProposalsCreateDescriptionPage NavigateToCreateProposalPage(DealerDashBoardPage dealerDashboardPage)
        {
            ClickSafety( dealerDashboardPage.CreateProposalLinkElement, dealerDashboardPage) ;
            return PageService.GetPageObject<DealerProposalsCreateDescriptionPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateCustomerInformationPage PopulateProposalDescriptionAndProceed(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage,
            string proposalName,
            string leadCodeReference,
            string contractType)
        {
            PopulateProposalDescription(dealerProposalsCreateDescriptionPage, proposalName, leadCodeReference, contractType);

            dealerProposalsCreateDescriptionPage.NextButton.Click();
            return PageService.GetPageObject<DealerProposalsCreateCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateTermAndTypePage PopulateProposalCustomerInformationAndProceed(DealerProposalsCreateCustomerInformationPage dealerProposalsCreateCustomerInformationPage, CustomerInformationOption customerInformationOption)
        {
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
            ClickSafety( dealerProposalsCreateCustomerInformationPage.SkipCustomerElement, dealerProposalsCreateCustomerInformationPage ) ;
            ClickSafety( dealerProposalsCreateCustomerInformationPage.NextButton, dealerProposalsCreateCustomerInformationPage ) ;
            return PageService.GetPageObject<DealerProposalsCreateTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateTermAndTypePage CreateCustomerForProposal(DealerProposalsCreateCustomerInformationPage dealerProposalsCreateCustomerInformationPage)
        {
            ClickSafety( dealerProposalsCreateCustomerInformationPage.CreateNewCustomerElement, dealerProposalsCreateCustomerInformationPage )  ;
            ClickSafety( dealerProposalsCreateCustomerInformationPage.NextButton, dealerProposalsCreateCustomerInformationPage ) ;
            var detailInputPage = PageService.GetPageObject<DealerProposalsCreateCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            detailInputPage.FillOrganisationDetails();
            detailInputPage.FillOrganisationContactDetail();
            ClickSafety( detailInputPage.NextButton, detailInputPage ) ;
            return PageService.GetPageObject<DealerProposalsCreateTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertTermAndTypePage CreateCustomerForProposal(DealerProposalsConvertCustomerInformationPage dealerProposalsConvertCustomerInformationPage)
        {
            ClickSafety( dealerProposalsConvertCustomerInformationPage.CreateNewCustomerElement, dealerProposalsConvertCustomerInformationPage ) ;
            ClickSafety( dealerProposalsConvertCustomerInformationPage.NextButton, dealerProposalsConvertCustomerInformationPage  ) ;
            var dealerProposalsConvertCustomerInformationPage2 = PageService.GetPageObject<DealerProposalsConvertCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            dealerProposalsConvertCustomerInformationPage2.FillOrganisationDetails();
            dealerProposalsConvertCustomerInformationPage2.FillOrganisationContactDetail();
            dealerProposalsConvertCustomerInformationPage2.FillOrganisationBankDetail("Invoice");
            ClickSafety( dealerProposalsConvertCustomerInformationPage2.NextButton, dealerProposalsConvertCustomerInformationPage2 ) ;
            return PageService.GetPageObject<DealerProposalsConvertTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }


        public DealerProposalsCreateProductsPage PopulateAgreementTermAndTypeAndProceed(DealerProposalsCreateTermAndTypePage dealerProposalsCreateTermAndTypePage,
            string usageType,
            string contractLength,
            string servicePackOption)
        {
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
            // Populate Term and Type page for Type 1
            dealerProposalsCreateTermAndTypePage.PopulateTermAndTypeForType1(usageType, contractLength, billingType, servicePackOption, RuntimeSettings.DefaultFindElementTimeout);
            ClickSafety(dealerProposalsCreateTermAndTypePage.NextButton, dealerProposalsCreateTermAndTypePage) ;
            return PageService.GetPageObject<DealerProposalsCreateProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateClickPricePage AddPrinterToProposalAndProceed(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage,
            IEnumerable<PrinterProperties> products)
        {
            foreach (var product in products)
            {
                PopulatePrinterDetails(dealerProposalsCreateProductsPage, product.Model, product.Price, product.Installation, product.IncludeDelivery);
            }
            ClickSafety( dealerProposalsCreateProductsPage.NextButtonElement, dealerProposalsCreateProductsPage)  ;
            return PageService.GetPageObject<DealerProposalsCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateSummaryPage CalculateClickPriceAndProceed(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage,
            IEnumerable<PrinterProperties> products)
        {
            foreach (var product in products)
            {
                PopulatePrinterCoverageAndVolume(dealerProposalsCreateClickPricePage, product.Model, product.CoverageMono, product.CoverageColour, product.VolumeMono, product.VolumeColour);
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
            int proposalId = dealerProposalsCreateSummaryPage.SaveProposalAndReturnContractId();
            _contextData.ProposalId = proposalId;
            return PageService.GetPageObject<CloudExistingProposalPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifySavedProposalInOpenProposalsList(CloudExistingProposalPage cloudExistingProposalPage, int proposalId, string proposalName)
        {
            bool exists = cloudExistingProposalPage.VerifySavedProposalInOpenProposalsList( proposalId, proposalName, RuntimeSettings.DefaultFindElementTimeout);
            if (exists)
            {
                return;
            }
            else
            {
                new NullReferenceException(string.Format("Proposal = {0} not found ", proposalId));
            }             
        }

        public DealerProposalsConvertCustomerInformationPage SubmitForApproval(CloudExistingProposalPage _cloudExistingProposalPage, int proposalId, string proposalName)
        {
            _cloudExistingProposalPage.ClickOnSubmitForApproval(proposalId, proposalName, RuntimeSettings.DefaultFindElementTimeout, _dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsConvertCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertTermAndTypePage SetForApprovalInformationAndProceed(DealerProposalsConvertCustomerInformationPage dealerProposalsConvertCustomerInformationPage, Country country, string payment = "Invoice")
        {
            dealerProposalsConvertCustomerInformationPage.FillCustomerDetails(payment, country.Name);
            dealerProposalsConvertCustomerInformationPage.nextButtonElement.Click();
            return PageService.GetPageObject<DealerProposalsConvertTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerDashBoardPage NavigateToDashboardPage(string baseUrl)
        {
            var dashBoardPage = new DealerDashBoardPage();
            return PageService.LoadUrl<DealerDashBoardPage>(baseUrl + dashBoardPage.PageUrl, RuntimeSettings.DefaultPageLoadTimeout, dashBoardPage.ValidationElementSelector, true, _dealerWebDriver);
        }

        public DealerProposalsApprovedPage NavigateToDealerProposalsApprovedPage(DealerDashBoardPage dealerDashboardPage)
        {
            ClickSafety(dealerDashboardPage.ExistingProposalLinkElement, dealerDashboardPage);
            var dealerProposalsInprogressPage =  PageService.GetPageObject<DealerProposalsInprogressPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            ClickSafety(dealerProposalsInprogressPage.approvedProposalsTabElement, dealerProposalsInprogressPage);
            return PageService.GetPageObject<DealerProposalsApprovedPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver); ;
        }

        public void DeletePdfFileErrorIgnored(string pdfFile)
        {
            try { _pdfHelper.DeletePdf(pdfFile); }catch { /* ignored */}
        }

        public void AssertAreEqualSummaryValues(string pdfFile, Country country, SummaryValue summaryValue)
        {
            if (_pdfHelper.PdfExists(pdfFile) == false)
            {
                throw new Exception("pdf not exists file=" + pdfFile);
            }
            var contractTermDigitString = new Regex(@"[^0-9]").Replace(summaryValue.SummaryTable_ContractTerm,"");
            string[] searchTextArray =
            {
                // TODO need localize to be implement MPS-4975.
                string.Format("{0} {1}", "Agreement period:", int.Parse(contractTermDigitString)*12),
                string.Format("{0} {1}", "Total Installed Purchase Price:", summaryValue.SummaryTable_DeviceTotalsTotalPriceNet),
                string.Format("{0} {1}", "Total Quarterly in Arrears Minimum Click Charge:", summaryValue.SummaryTable_ConsumableTotalsTotalPriceNet)
            };
            searchTextArray.ToList().ForEach(expected =>
               {
                   if( _pdfHelper.PdfContainsText(pdfFile, expected) == false)
                   {
                       throw new Exception(string.Format("string not found in pdf. pdfFile=[{0}], expected=[{1}]", pdfFile, expected)) ;
                   }
               });
        }
 
        public DealerProposalsSummaryPage ClickOnViewSummary(DealerProposalsApprovedPage dealerProposalsApprovedPage, string proposalId)
        {
            dealerProposalsApprovedPage.ClickOnSummaryPage(proposalId, RuntimeSettings.DefaultPageLoadTimeout, _dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertProductsPage ClickNext(DealerProposalsConvertTermAndTypePage dealerProposalsConvertTermAndTypePage)
        {
            dealerProposalsConvertTermAndTypePage.NextButton.Click();
            return PageService.GetPageObject<DealerProposalsConvertProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public string DownloadPdf(DealerProposalsSummaryPage dealerProposalsSummaryPage)
        {
            var fileList = ListDownloadsFolder();
            ClickSafety(dealerProposalsSummaryPage.DownloadProposalPdfElement, dealerProposalsSummaryPage);
            var task = WaitforNewfile(fileList);
            if (task.Wait(new TimeSpan(0, 0, RuntimeSettings.DefaultDownLoadTimeout)))
            {
                return task.Result;
            }else
            {
                throw new Exception("download pdf timeout");
            }
        }

        private async Task<string> WaitforNewfile(string[] orglist, string pattern = "*.pdf")
        {
            // note: FileWatcher is not detecting file...
            for (int safetycount=0;safetycount < 1000; safetycount++)
            {
                var newlist = ListDownloadsFolder(pattern);
                var difflist = newlist.Except(orglist);
                if(difflist.Count() > 0)
                {
                    return difflist.First();
                }
                await Task.Delay(new TimeSpan(0, 0, 1));
            }
            throw new Exception("safety count retryout");
        }

        private string[] ListDownloadsFolder(string pattern="*.pdf")
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(TestController.DownloadPath, pattern, System.IO.SearchOption.AllDirectories);
                return files;
            }catch
            {
                return new string[0];
            }
            
            
        }

        public DealerProposalsConvertClickPricePage ClickNext(DealerProposalsConvertProductsPage dealerProposalsConvertProductsPage)
        {
            dealerProposalsConvertProductsPage.NextButtonElement.Click();
            return PageService.GetPageObject<DealerProposalsConvertClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsInprogressPage NavigateToDealerProposalsInprogressPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.proposalTopElement.Click();
            return PageService.GetPageObject<DealerProposalsInprogressPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertSummaryPage SetInformationAndClickSubmitForApproval(DealerProposalsConvertClickPricePage dealerProposalsConvertClickPricePage)
        {
            dealerProposalsConvertClickPricePage.ProceedOnClickPricePageElement.Click();
            return PageService.GetPageObject<DealerProposalsConvertSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void SubmitForApproval(DealerProposalsConvertSummaryPage dealerProposalsConvertSummaryPage)
        {
            dealerProposalsConvertSummaryPage.EnterProposedStartDateForContract(); // Envisaged Start Date
            dealerProposalsConvertSummaryPage.GiveThirdPartyCheckApproval();       // Approval Has Been Given To Send Information To Brother
            dealerProposalsConvertSummaryPage.SaveAsContractButton.Click();
            // if you may return to PageObject, 
            // /mps/dealer/proposals/awaiting-approval
            //return PageService.GetPageObject<>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsConvertCustomerInformationPage SubmitForApproval(DealerProposalsInprogressPage dealerProposalsInprogressPage)
        {
            dealerProposalsInprogressPage.ClickOnSubmitForApproval(_contextData.ProposalId, RuntimeSettings.DefaultFindElementTimeout, _dealerWebDriver);
            return PageService.GetPageObject<DealerProposalsConvertCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }


        public DealerCustomersExistingPage NavigateToCustomersContractPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.ExistingCustomerLinkElement.Click();
            var nextPage = PageService.GetPageObject<DealerCustomersExistingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            return nextPage;
        }

        public DealerCustomersExistingPage ProceedCreateAndSaveANewCustomer(DealerCustomersManagePage dealerCustomersManagePage, out string customerName, Country country, string payment = "Invoice")
        {
            dealerCustomersManagePage.FillCustomerDetails(payment, country.Name);
            customerName = dealerCustomersManagePage.GetCompanyName();
            dealerCustomersManagePage.saveButtonElement.Click();
            var nextPage = PageService.GetPageObject<DealerCustomersExistingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            return nextPage;
        }

        public void ThenICanSeeTheCustomerCreatedAboveInTheCustomersContactsList(DealerCustomersExistingPage _dealerCustomersExistingPage, string customerInformationName, string customerEmail)
        {
            bool exists = _dealerCustomersExistingPage.VerifyItemByName(customerInformationName, customerEmail, RuntimeSettings.DefaultFindElementTimeout);
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
            dealerDashboardPage.ExistingContractLinkElement.Click();
            return PageService.GetPageObject<DealerContractsApprovedProposalPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerContractsSummaryPage ClickViewOffer(DealerContractsApprovedProposalPage dealerProposalsApprovedPage, int proposalId)
        {
            dealerProposalsApprovedPage.ClickOnViewOffer(_contextData.ProposalId, RuntimeSettings.DefaultFindElementTimeout, _dealerWebDriver);
            return PageService.GetPageObject<DealerContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerContractsAwaitingAcceptancePage SignToContract(DealerContractsSummaryPage dealerContractsSummaryPage)
        {
            dealerContractsSummaryPage.SignButtonElement.Click();
            return PageService.GetPageObject<DealerContractsAwaitingAcceptancePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        #region private methods

        private void PopulateProposalDescription(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage,
            string proposalName,
            string leadCodeReference,
            string contractType)
        {
            dealerProposalsCreateDescriptionPage.PopulateProposalName(proposalName);
        }

        private void PopulatePrinterDetails(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage,
            string printerName,
            string printerPrice,
            string installationPack,
            bool delivery)
        {
            dealerProposalsCreateProductsPage.PopulatePrinterDetails(printerName, printerPrice, installationPack, delivery, RuntimeSettings.DefaultFindElementTimeout);
        }

        private void PopulatePrinterCoverageAndVolume( DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage,
            string printerName, int coverageMono, int coverageColour, int volumeMono, int volumeColour)
        {
            dealerProposalsCreateClickPricePage.PopulatePrinterCoverageAndVolume( 
                printerName, 
                coverageMono, 
                coverageColour, 
                volumeMono, 
                volumeColour, 
                RuntimeSettings.DefaultFindElementTimeout );
        }

        private bool VerifyClickPriceValues(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage)
        {
            return dealerProposalsCreateClickPricePage.VerifyClickPriceValues(RuntimeSettings.DefaultFindElementTimeout);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }
        #endregion
    }
 }