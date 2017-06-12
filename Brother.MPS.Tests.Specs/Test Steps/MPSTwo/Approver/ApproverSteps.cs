using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using Brother.Tests.Specs.BrotherOnline.Account;
using Brother.Tests.Specs.MPSTwo.Contract;
using Brother.Tests.Specs.MPSTwo.Proposal;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Approver
{
    [Binding]
    public class ApproverSteps : BaseSteps
    {
        private bool PurchaseAndClick = false;
        private bool LeaseAndClick = false;
        private bool PayAsYouGo = false;
        private bool MinimumVolume = false;
        public ApproverSteps()
        {
            string ContractType = "";
            string UsageType = "";
            foreach (KeyValuePair<string, object> kv in Selenium.Lib.Support.HelperClasses.SpecFlow.GetEnumerator())
            {
                if (kv.Key.Equals("CreateContractType"))
                    ContractType = kv.Value.ToString();
                if (kv.Key.Equals("CreateUsageType"))
                    UsageType = kv.Value.ToString();
            }
            if (ContractType.Equals("Purchase & Click with Service") || ContractType.Equals(string.Empty)
                || ContractType.Equals("Easy Print Pro & Service") || ContractType.Equals("Buy & Click")
                || ContractType.Equals("Acquisto + Consumo con assistenza") || ContractType.Equals("Purchase & Click con Service")
                || ContractType.Equals("Kjøp og klikk med service") || ContractType.Equals("Purchase & click inklusive service")
                || ContractType.Equals("Purchase + Click met Service") || ContractType.Equals("Køb & Klik med service") || ContractType.Equals("Buy + Click")
                || ContractType.Equals("Click tarvikesopimus")) 
                PurchaseAndClick = true;
            if (ContractType.Equals("Lease & Click with Service") || ContractType.Equals("Leasing & Service"))
                LeaseAndClick = true;
            if (UsageType.Equals("Minimum Volume") || UsageType.Equals("Engagement sur un minimum volume de pages") ||
                UsageType.Equals("Volume minimo") || UsageType.Equals("Volúmen mínimo") || UsageType.Equals("Minimumvolume")
                || UsageType.Equals("Minimum volum") || UsageType.Equals("Minimum volym") || UsageType.Equals("Minimumsvolumen")
                || UsageType.Equals("Minimumsvolumen") || UsageType.Equals("Pakiet wydruków") || UsageType.Equals("Per kwartaal achteraf")
                || UsageType.Equals("Volume minimum") || UsageType.Equals("Minimitulostusmäärä") || UsageType.Equals("Volume minimal"))
                MinimumVolume = true;
            if (UsageType.Equals("Pay As You Go") || UsageType.Equals("Pago por Uso") || UsageType.Equals("Betale ved forbruk")
                || UsageType.Equals("Betala per utskrift") || UsageType.Equals("Betalen naar verbruik") || UsageType.Equals("Bez pakietu wydruków")
                || UsageType.Equals("Maksu tulosteiden mukaan") || UsageType.Equals("Paiement selon la consommation réelle de pages")
                || UsageType.Equals("Consommation réelle") || UsageType.Equals("Mode prépayé"))
                PayAsYouGo = true;

        }

        [Given(@"Approver navigate to ProposalsPage")]
        public void WhenApproverNavigateToOfferPage()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToOffersPage();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
                NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToProposalsPage();
            }
        }

        [Given(@"Approver navigate to Awaiting Approval screen under Proposals page")]
        public void GivenApproverNavigateToAwaitingApprovalScreenUnderProposalsPage()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankOffersPage>().NavigateToAwaitingApprovalPage();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToAwaitingApprovalPage();
            }
        }

        [Given(@"I navigate to Report page")]
        [Then(@"I navigate to Report page")]
        [When(@"I navigate to Report page")]
        public void WhenINavigateToReportPage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToLocalOfficeApproverReportingPage();
        }

        [Then(@"I navigate to Report page from Approved proposal page")]
        [When(@"I navigate to Report page from Approved proposal page")]
        [Given(@"I navigate to Report page from Approved proposal page")]
        public void GivenINavigateToReportPageFromApprovedProposalPage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToReportDashboardPage();
        }


        [Then(@"I can download ""(.*)"" from the page")]
        public void ThenICanDownloadFromThePage(string downloadType)
        {
            CurrentPage.As<LocalOfficeApprovalReportingDashboardPage>().DownloadASpecifiedReport(downloadType);
        }

        [Given(@"Approver navigate to Data Query page")]
        [Then(@"Approver navigate to Data Query page")]
        [When(@"Approver navigate to Data Query page")]
        public void GivenApproverNavigateToDataQueryPage()
        {
            NextPage = CurrentPage.As<LocalOfficeApprovalReportingDashboardPage>().NavigateToDataQueryPage();
        }

        [Given(@"Approver navigates to special pricing page for the proposal")]
        [Then(@"Approver navigates to special pricing page for the proposal")]
        [When(@"Approver navigates to special pricing page for the proposal")]
        public void WhenApproverNavigatesToSpecialPricingPageForTheProposal()
        {
            CurrentPage.As<DataQueryPage>().SearchForNewlyCreatedProposalByProposalId();
            NextPage = CurrentPage.As<DataQueryPage>().ClickOnSearchedProposal();
            NextPage = CurrentPage.As<ReportProposalSummaryPage>().NavigateToProposalSpecialPricingPage();
        }

        [Then(@"Approver navigates to customer information page for the proposal")]
        [Given(@"Approver navigates to customer information page for the proposal")]
        [When(@"Approver navigates to customer information page for the proposal")]
        public void WhenApproverNavigatesToCustomerInformationPageForTheProposal()
        {
            CurrentPage.As<DataQueryPage>().SearchForNewlyCreatedProposalByProposalId();
            NextPage = CurrentPage.As<DataQueryPage>().ClickOnSearchedProposal();
            NextPage = CurrentPage.As<ReportProposalSummaryPage>().NavigateToLocalOfficeCustomerInformationPage();
        }

        [When(@"Approver navigate to manage customer page for the first address")]
        public void WhenApproverNavigateToManageCustomerPageForTheFirstAddress()
        {
            NextPage = CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().StartCustomerEdit();
        }


        [Then(@"approver can edit first customer street name")]
        public void ThenApproverCanEditFirstCustomerStreetName()
        {
            CurrentPage.As<LocalOfficeApprovalReportManageCustomerPage>().EditCustomerStreet();
        }

        [Then(@"approver can edit first customer town name")]
        public void ThenApproverCanEditFirstCustomerTownName()
        {
            CurrentPage.As<LocalOfficeApprovalReportManageCustomerPage>().EditCustomerTown();
        }

        [Then(@"approver can edit first customer area name")]
        public void ThenApproverCanEditFirstCustomerAreaName()
        {
            CurrentPage.As<LocalOfficeApprovalReportManageCustomerPage>().EditCustomerArea();
        }

        [Then(@"approver can edit first customer cost centre")]
        public void ThenApproverCanEditFirstCustomerCostCentre()
        {
            CurrentPage.As<LocalOfficeApprovalReportManageCustomerPage>().EditCustomerCostCentre();
        }

        [Then(@"approver can update the changes made to customer details")]
        public void ThenApproverCanUpdateTheChangesMadeToCustomerDetails()
        {
            NextPage = CurrentPage.As<LocalOfficeApprovalReportManageCustomerPage>().UpdateEditedCustomerInformation();
        }



        [Then(@"I can edit customer street name")]
        public void ThenICanEditCustomerStreetName()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().EditCustomerStreetName();
        }

        [Then(@"I can edit customer contact first name")]
        public void ThenICanEditCustomerContactFirstName()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().EditCustomerContactFirstName();
        }

        [Then(@"the changes made above are displayed on summary page")]
        public void ThenTheChangesMadeAboveAreDisplayedOnSummaryPage()
        {
            CurrentPage.As<ReportProposalSummaryPage>().IsCustomerContactNameEdited();
            CurrentPage.As<ReportProposalSummaryPage>().IsCustomerCustomerCityEdited();
        }


        [Then(@"I can edit customer contact last name")]
        public void ThenICanEditCustomerContactLastName()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().EditCustomerContactLastName();
        }

        [Then(@"I can update the changes made to customer details")]
        public void ThenICanUpdateTheChangesMadeToCustomerDetails()
        {
            NextPage = CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().UpdateChangesMade();
        }



        [Then(@"Customer name field is disabled")]
        public void ThenCustomerNameFieldIsDisabled()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().IsCustomerNameReadOnly();
        }

        [Then(@"Customer cost centre is disabled")]
        public void ThenCustomerCostCentreIsDisabled()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().IsCustomerCostCentreDisabled();
        }

        [Then(@"customer legal form is disabled")]
        public void ThenCustomerLegalFormIsDisabled()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().IsCustomerLegalFormDisabled();
        }

        [Then(@"company registration number field is disabled")]
        public void ThenCompanyRegistrationNumberFieldIsDisabled()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().IsCustomerCompanyRegistrationNumberDisabled();
        }

        [Then(@"company vat registration number field is disabled")]
        public void ThenCompanyVatRegistrationNumberFieldIsDisabled()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().IsCustomerCompanyVatRegistrationNumberDisabled();
        }

        [Then(@"customer trading style field is disabled")]
        public void ThenCustomerTradingStyleFieldIsDisabled()
        {
           CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().IsCustomerTradingStyleReadOnly();
        }

        [Then(@"customer autorised signatories")]
        public void ThenCustomerAutorisedSignatories()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().IsCustomerAuthorisedSignatoryReadOnly();
        }

        [Then(@"contact customer email field is disabled")]
        public void ThenContactCustomerEmailFieldIsDisabled()
        {
            CurrentPage.As<LocalOfficeApprovalCustomerInformationPage>().IsCustomerPersonEmailReadOnly();
        }


        [Given(@"Approver validates installation unit price calculation")]
        [Then(@"Approver validates installation unit price calculation")]
        [When(@"Approver validates installation unit price calculation")]
        public void WhenApproverValidatesInstallationUnitPriceCalculation()
        {
            CurrentPage.As<ProposalSpecialPricingPage>().IsInstallationPriceCorrectlyCalculated();
            CurrentPage.As<ProposalSpecialPricingPage>().SetInstallationUnitPrice();
            CurrentPage.As<ProposalSpecialPricingPage>().ProceedOnSpecialPricingPage();
        }

        [Then(@"Approver validates Service Pack unit price calculation")]
        [Given(@"Approver validates Service Pack unit price calculation")]
        [When(@"Approver validates Service Pack unit price calculation")]
        public void WhenApproverValidatesServicePackUnitPriceCalculation()
        {
            CurrentPage.As<ProposalSpecialPricingPage>().IsServicePackPriceCorrectlyCalculated();
            CurrentPage.As<ProposalSpecialPricingPage>().SetServicePackUnitPrice();
            CurrentPage.As<ProposalSpecialPricingPage>().ProceedOnSpecialPricingPage();
        }

        [When(@"Approver makes changes to installation costing")]
        public void WhenApproverMakesChangesToInstallationCosting()
        {
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewInstallationUnitCost(10);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewInstallationMarginValue(-1);
            CurrentPage.As<ProposalSpecialPricingPage>().SetInstallationUnitPrice();
            CurrentPage.As<ProposalSpecialPricingPage>().ProceedOnSpecialPricingPage();

        }

         [When(@"Approver makes changes to multiple installation costing")]
        public void WhenApproverMakesChangesToMultipleInstallationCosting()
        {

            //printer 1
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewInstallationUnitCost(0, 10);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewInstallationMarginValue(0, 1);
            CurrentPage.As<ProposalSpecialPricingPage>().IsInstallationPriceCorrectlyCalculated(0);
            CurrentPage.As<ProposalSpecialPricingPage>().SetInstallationUnitPrice(0);

            //printer 2
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewInstallationUnitCost(1, -10);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewInstallationMarginValue(1, -1);
            CurrentPage.As<ProposalSpecialPricingPage>().IsInstallationPriceCorrectlyCalculated(1);
            CurrentPage.As<ProposalSpecialPricingPage>().SetInstallationUnitPrice(1);

            //printer 3
            CurrentPage.As<ProposalSpecialPricingPage>().EnterZeroInstallationUnitCost(2);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterZeroInstallationMarginValue(2);
            CurrentPage.As<ProposalSpecialPricingPage>().IsInstallationPriceCorrectlyCalculated(2);
            CurrentPage.As<ProposalSpecialPricingPage>().SetInstallationUnitPrice(2);
            
            
            //printer 4
            CurrentPage.As<ProposalSpecialPricingPage>().IsInstallationPriceCorrectlyCalculated(3);
            CurrentPage.As<ProposalSpecialPricingPage>().SetInstallationUnitPrice(3);

            //proceed
            CurrentPage.As<ProposalSpecialPricingPage>().ProceedOnSpecialPricingPage();

        }

        [When(@"Approver makes changes to Service Pack costing")]
        public void WhenApproverMakesChangesToServicePackCosting()
        {
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewServicePackValue(5);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewServicePackMarginValue(1);
            CurrentPage.As<ProposalSpecialPricingPage>().SetServicePackUnitPrice();
            CurrentPage.As<ProposalSpecialPricingPage>().ProceedOnSpecialPricingPage();
        }

       
        [When(@"Approver makes changes to multiple Service Pack costing")]
        public void WhenApproverMakesChangesToMultipleServicePackCosting()
        {
            //printer 1
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewServicePackValue(0, -5);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewServicePackMarginValue(0, -1);
            CurrentPage.As<ProposalSpecialPricingPage>().IsServicePackPriceCorrectlyCalculated(0);
            CurrentPage.As<ProposalSpecialPricingPage>().SetServicePackUnitPrice(0);

            //printer 2
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewServicePackValue(1, 5);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewServicePackMarginValue(1, 1);
            CurrentPage.As<ProposalSpecialPricingPage>().IsServicePackPriceCorrectlyCalculated(1);
            CurrentPage.As<ProposalSpecialPricingPage>().SetServicePackUnitPrice(1);

            //printer 3
            CurrentPage.As<ProposalSpecialPricingPage>().EnterZeroServicePackValue(2);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterZeroServicePackMarginValue(2);
            CurrentPage.As<ProposalSpecialPricingPage>().IsServicePackPriceCorrectlyCalculated(2);
            CurrentPage.As<ProposalSpecialPricingPage>().SetServicePackUnitPrice(2);

            //printer 4
            CurrentPage.As<ProposalSpecialPricingPage>().SetServicePackUnitPrice(3);
            CurrentPage.As<ProposalSpecialPricingPage>().IsServicePackPriceCorrectlyCalculated(3);


            CurrentPage.As<ProposalSpecialPricingPage>().ProceedOnSpecialPricingPage();
        }

        [When(@"Approver makes changes to Click Price costing")]
        public void WhenApproverMakesChangesToClickPriceCosting()
        {
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceMonoVolume(500);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceMonoMargin(-1);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewMonoClickPriceValue("-0.00005");
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceColourVolume(200);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceColourMargin(1);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewColourClickPriceValue("-0.0001");
            CurrentPage.As<ProposalSpecialPricingPage>().ValidateSpecialPricesEntered();
            CurrentPage.As<ProposalSpecialPricingPage>().EnterAdditionalAuditInformation();
            NextPage = CurrentPage.As<ProposalSpecialPricingPage>().ApplyEnteredSpecialPricing();
        }

        [When(@"Approver makes changes to multiple Click Price costing")]
        public void WhenApproverMakesChangesToMultipleClickPriceCosting()
        {
            //mono
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceMonoVolume(0, 500);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceMonoVolume(1, -50);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceMonoVolume(2, 300);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceMonoMargin(0, -1);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceMonoMargin(1, 1);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceMonoMargin(2, 0);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewMonoClickPriceValue(0, "0.00005");
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewMonoClickPriceValue(1, "-0.00005");
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewMonoClickPriceValue(2, "0.00010");

            //colour
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceColourVolume(0, 200);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceColourVolume(1, -200);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceColourVolume(2, 300);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceColourMargin(0, 1);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceColourMargin(1, -1);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewClickPriceColourMargin(2, 2);
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewColourClickPriceValue(0, "-0.0001");
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewColourClickPriceValue(1, "0.0001");
            CurrentPage.As<ProposalSpecialPricingPage>().EnterNewColourClickPriceValue(2, "-0.0002");


            CurrentPage.As<ProposalSpecialPricingPage>().ValidateSpecialPricesEntered();
            CurrentPage.As<ProposalSpecialPricingPage>().EnterAdditionalAuditInformation();
            NextPage = CurrentPage.As<ProposalSpecialPricingPage>().ApplyEnteredSpecialPricing();
        }

        [Then(@"the changes made are displayed on the summary page")]
        public void ThenTheChangesMadeAreDisplayedOnTheSummaryPage()
        {
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredColourClickPriceDisplayed();
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredInstallationUnitPriceDisplayed();
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredMonoClickPriceDisplayed();
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredServicePackUnitPriceDisplayed();
        }


        [Then(@"the changes to installation cost made are displayed on the summary page")]
        public void ThenTheChangesToInstallationCostMadeAreDisplayedOnTheSummaryPage()
        {
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredInstallationUnitPriceDisplayed("0");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredInstallationUnitPriceDisplayed("1");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredInstallationUnitPriceDisplayed("2");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredInstallationUnitPriceDisplayed("3");
        }

        [Then(@"the changes to service pack cost made are displayed on the summary page")]
        public void ThenTheChangesToServicePackCostMadeAreDisplayedOnTheSummaryPage()
        {
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredServicePackUnitPriceDisplayed("0");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredServicePackUnitPriceDisplayed("1");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredServicePackUnitPriceDisplayed("2");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredServicePackUnitPriceDisplayed("3");
        }

        [Then(@"the changes to mono click price made are displayed on the summary page")]
        public void ThenTheChangesToMonoClickPriceMadeAreDisplayedOnTheSummaryPage()
        {
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredMonoClickPriceDisplayed("0");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredMonoClickPriceDisplayed("1");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredMonoClickPriceDisplayed("2");
        }

        [Then(@"the changes to colour click price made are displayed on the summary page")]
        public void ThenTheChangesToColourClickPriceMadeAreDisplayedOnTheSummaryPage()
        {
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredColourClickPriceDisplayed("0");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredColourClickPriceDisplayed("1");
            CurrentPage.As<ReportProposalSummaryPage>().IsNewlyEnteredColourClickPriceDisplayed("2");
        }




        [When(@"audit log is displayed on report proposal summary page")]
        [Then(@"audit log is displayed on report proposal summary page")]
        public void ThenAuditLogIsDisplayedOnReportProposalSummaryPage()
        {
            CurrentPage.As<ReportProposalSummaryPage>().IsAuditSectionDisplayed();
        }



        [Then(@"the dealer navigates to Proposal Summary page from Proposal Awaiting Approval page")]
        public void ThenTheDealerNavigatesToProposalSummaryPageFromProposalAwaitingApprovalPage()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            NextPage = CurrentPage.As<CloudExistingProposalPage>().NavigateToProposalsAwaitingApproval();
            NextPage = CurrentPage.As<DealerProposalsAwaitingApprovalPage>().NavigateToViewSummary();

            //NextPage =
            //    CurrentPage.As<DealerProposalsCreateDescriptionPage>().NavigateToDealerProposalsCreateClickPricePage();
            //CurrentPage.As<DealerProposalsCreateClickPricePage>().IsSpecialPricingNewColourClickPriceDisplayed();
            //CurrentPage.As<DealerProposalsCreateClickPricePage>().IsSpecialPricingNewMonoClickPriceDisplayed();
            //NextPage =
            //    CurrentPage.As<DealerProposalsCreateClickPricePage>()
            //        .ClickAndProceedOnDealerProposalsCreateSummaryPage();

        }


        [Then(@"the dealer navigates to Proposal Summary page from Approved Proposal page")]
        public void ThenTheDealerNavigatesToProposalSummaryPageFromApprovedProposalPage()
        {
            var instance1 = new SigningContracts();
            instance1.ThenICanStartTheProcessOfSigningTheContract();
        }



        [Then(@"the changes are also on Proposal Summary page")]
        public void ThenTheChangesAreAlsoOnProposalSummaryPage()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSpecialPricingColourClickPriceDisplayed();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSpecialPricingInstallationUnitPriceDisplayed();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSpecialPricingMonoClickPriceDisplayed();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSpecialPricingServicePackUnitPriceDisplayed();
        }


        [Then(@"the changes are also on Approved Proposal Summary page")]
        public void ThenTheChangesAreAlsoOnApprovedProposalSummaryPage()
        {
            CurrentPage.As<DealerContractsSummaryPage>().IsSpecialPricingColourClickPriceDisplayed();
            CurrentPage.As<DealerContractsSummaryPage>().IsSpecialPricingInstallationUnitPriceDisplayed();
            CurrentPage.As<DealerContractsSummaryPage>().IsSpecialPricingMonoClickPriceDisplayed();
            CurrentPage.As<DealerContractsSummaryPage>().IsSpecialPricingServicePackUnitPriceDisplayed();
        }





        [When(@"Approver select the proposal on Awaiting Proposal")]
        [Then(@"Approver select the proposal on Awaiting Proposal")]
        public void ThenApproverSelectTheProposalOnAwaitingProposal()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankOffersPage>().NavigateToViewSummary();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToViewSummary();
            }
        }

        [Then(@"Approver should be able to decline that proposal with ""(.*)""")]
        public void ThenApproverShouldBeAbleToDeclineThatProposalWith(string reason)
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<BankProposalsSummaryPage>().SelectDeclineReason();
                NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickRejectButton();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().SelectDeclineReason();
                NextPage = CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickRejectButton();
            }
        }


        [Then(@"Approver should be able to decline that proposal")]
        public void ThenApproverShouldBeAbleToDeclineThatProposal()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<BankProposalsSummaryPage>().SelectDeclineReason();
                NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickRejectButton();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().SelectDeclineReason();
                NextPage = CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickRejectButton();
            }
        }

        [When(@"Approver navigate to Contract Awaiting Acceptance page from Dashboard")]
        [Then(@"Approver navigate to Contract Awaiting Acceptance page from Dashboard")]
        public void WhenApproverNavigateToContractAwaitingAcceptancePage()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToContractsPage();
                CurrentPage.As<BankContractsPage>().NavigateToAwaitingAcceptancePage();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
                NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToContractsPage();
                CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAwaitingAcceptancePage();
            }
        }

        [Then(@"the decline proposal should be displayed under Declined tab by Approver")]
        public void ThenTheDeclineProposalShouldBeDisplayedUnderDeclinedTabByApprover()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankOffersPage>().VerifyDeclinedProposalIsDisplayed();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsPage>().VerifyDeclinedProposalIsDisplayed();
            }
        }

        [Then(@"Approver can view all the contracts that have been signed by dealer")]
        public void ThenApproverCanViewAllTheContractsThatHaveBeenSignedByDealer()
        {
            if (LeaseAndClick)
                CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
            else if (PurchaseAndClick)
                CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
        }

        [Then(@"Approver can either reject or approve the contract")]
        public void ThenApproverCanEitherRejectOrApproveTheContract()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
                CurrentPage.As<BankContractsSummaryPage>().IsAcceptButtonAvailable();
                CurrentPage.As<BankContractsSummaryPage>().IsRejectButtonAvailable();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().IsAcceptButtonAvailable();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().IsRejectButtonAvailable();
            }
        }

        [Then(@"Approver can successfully approve the contract")]
        public void ThenApproverCanSuccessfullyApproveTheContract()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
//                CurrentPage.As<BankContractsSummaryPage>().VerifyThatTheContractDataIsEqualToProposalCreatedByDealer();
                CurrentPage.As<BankContractsSummaryPage>().ClickAcceptButton();
                CurrentPage.As<BankContractsSummaryPage>().EnterContractApprovalDetails();
                NextPage = CurrentPage.As<BankContractsSummaryPage>().ClickFinalAcceptButton();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
//                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().VerifyThatTheContractDataIsEqualToProposalCreatedByDealer();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickAcceptButton();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().EnterContractApprovalDetails();
                NextPage = CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickFinalAcceptButton();
            }
        }

        [Then(@"Approver can successfully reject the contract")]
        public void ThenApproverCanSuccessfullyRejectTheContract()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
                CurrentPage.As<BankContractsSummaryPage>().ClickRejectButton();
                CurrentPage.As<BankContractsSummaryPage>().SelectRejectionReason();
                NextPage = CurrentPage.As<BankContractsSummaryPage>().ClickFinalRejectButton();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickRejectButton();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().SelectRejectionReason();
                NextPage = CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickFinalRejectButton();  
            }
        }

        [Then(@"Approver can successfully reject the contract with ""(.*)"" option")]
        public void ThenApproverCanSuccessfullyRejectTheContractWithOption(string option)
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
                CurrentPage.As<BankContractsSummaryPage>().ClickRejectButton();
                CurrentPage.As<BankContractsSummaryPage>().SelectRejectionReason();
                NextPage = CurrentPage.As<BankContractsSummaryPage>().ClickFinalRejectButton();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickRejectButton();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().SelectRejectionReason();
                NextPage = CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickFinalRejectButton();
            }
        }

        [Given(@"the contract created above is approved")]
        [Then(@"the contract created above is approved")]
        [When(@"the contract created above is approved")]
        public void ThenTheContractCreatedAboveIsApprovedWithCreditCheck()
        {
             var instance3 = new AccountManagementSteps();
            WhenApproverNavigateToContractAwaitingAcceptancePage();
            ThenApproverCanViewAllTheContractsThatHaveBeenSignedByDealer();
            ThenApproverCanSuccessfullyApproveTheContract();
            ThenTheAcceptedContractByApproverIsDisplayedOnContractAcceptedScreen();
            instance3.ThenIfISignOutOfBrotherOnline();
        }

        public void ThenTheContractCreatedAboveIsApproved()
        {
            var instance3 = new AccountManagementSteps();
            WhenApproverNavigateToContractAwaitingAcceptancePage();
            ThenApproverCanViewAllTheContractsThatHaveBeenSignedByDealer();
            ThenApproverCanSuccessfullyApproveTheContract();
            ThenTheAcceptedContractByApproverIsDisplayedOnContractAcceptedScreen();
            instance3.ThenIfISignOutOfBrotherOnline();
        }

        [Given(@"the contract created above is approved without signing out")]
        [Then(@"the contract created above is approved without signing out")]
        public void ThenTheContractCreatedAboveIsApprovedWithoutSigningOut()
        {
            
            WhenApproverNavigateToContractAwaitingAcceptancePage();
            ThenApproverCanViewAllTheContractsThatHaveBeenSignedByDealer();
            ThenApproverCanSuccessfullyApproveTheContract();
            ThenTheAcceptedContractByApproverIsDisplayedOnContractAcceptedScreen();
            
        }


        [Then(@"the accepted contract by Approver is displayed on contract Accepted screen")]
        public void ThenTheAcceptedContractByApproverIsDisplayedOnContractAcceptedScreen()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankContractsPage>().NavigateToAcceptedPage();
                CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAcceptedPage();
                CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
            }
        }

        [Then(@"the rejected contract by Approver is displayed on contract Rejected screen")]
        public void ThenTheRejectedContractByApproverIsDisplayedOnContractRejectedScreen()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankContractsPage>().NavigateToRejectedPage();
                CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToRejectedPage();
                CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
            }
        }

        [Given(@"I should be able to approve that proposal")]
        [When(@"I should be able to approve that proposal")]
        [Then(@"I should be able to approve that proposal")]
        public void ThenIShouldBeAbleToApproveThatProposal()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankProposalsSummaryPage>().ClickApproveButton();
                CurrentPage.As<BankProposalsSummaryPage>().EnterApprovalInformation();
                NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickAccpetButton();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickApproveButton();
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().EnterApprovalInformation();
                NextPage = CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickAccpetButton();
            }
        }

        [Then(@"I should be able to decline that proposal")]
        public void ThenIShouldBeAbleToDeclineThatProposal()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<BankProposalsSummaryPage>().SelectDeclineReason();
                NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickRejectButton();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().SelectDeclineReason();
                NextPage = CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickRejectButton();
            }
        }


        [When(@"dealer navigates to the contract summary page")]
        public void WhenDealerNavigatesToTheContractSummaryPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"dealer makes note of some key values on the summary page")]
        public void WhenDealerMakesNoteOfSomeKeyValuesOnTheSummaryPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the dealer return to awaiting acceptance contract list page")]
        public void WhenTheDealerReturnToAwaitingAcceptanceContractListPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the dealer downloads PDF for the created contract")]
        public void WhenTheDealerDownloadsPdfForTheCreatedContract()
        {
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().GetDownloadedPdfPath();
            
        }

        [Then(@"the noted values above are available in the PDF content")]
        public void ThenTheNotedValuesAboveAreAvailableInThePdfContent()
        {
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().DoesPdfContentContainSomeText();
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().IsCustomerEmailPresentInPdf();
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().IsCustomerNamePresentInPdf();
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().IsSummaryColourClickRatePresentInPdf();
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().IsSummaryContractTermPresentInPdf();
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().IsSummaryContractTypePresentInPdf();
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().IsSummaryMonoClickRatePresentInPdf();
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().IsCorrectLanguagePdfDownloaded();
            CurrentPage.As<DealerContractsAwaitingAcceptancePage>().PurgeDownloadsDirectory();
        }

    }
}
