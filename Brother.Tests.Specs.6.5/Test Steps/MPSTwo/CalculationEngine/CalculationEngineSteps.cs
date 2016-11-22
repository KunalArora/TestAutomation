using System;
using System.Collections.Generic;
using System.Net;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.BrotherOnline.Account;
using Brother.Tests.Specs.MPSTwo.Approver;
using Brother.Tests.Specs.MPSTwo.Proposal;
using Brother.Tests.Specs.MPSTwo.SendToBank;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.CalculationEngine
{
    [Binding]
    public class CalculationEngineSteps : BaseSteps
    {


        [Given(@"""(.*)"" Dealer have created ""(.*)"" contract with ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedContractWithAndAndAndAndAndAndAnd(string country, string contractType, string usageType, string length, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            if (country.Equals("Germany") || country.Equals("Austria"))
            {
                GivenDealerHaveCreatedPurchaseAndClickGermanContractWithAndAndAndAndAndAndAnd(country, contractType,
                    usageType, length, billing,
                    servicePack, installation, delivery, device1, device2);
            }
            else
            {
                GivenDealerHaveCreatedAContractWithMultipleVariables(country, contractType, usageType, length, billing,
                 servicePack, installation, delivery, device1, device2); 
            }
            
        }


        [Given(@"""(.*)"" Dealer ""(.*)"" have created ""(.*)"" contract with ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedContractWithAndAndAndAndAndAndAnd(string country, string language, string contractType, string usageType, string length, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            Selenium.Lib.Support.HelperClasses.SpecFlow.SetContext("BelgianLanguage", language);

            GivenDealerHaveCreatedAContractWithMultipleVariables(country, contractType, usageType, length, billing,
                 servicePack, installation, delivery, device1, device2); 
        }


        public void GivenDealerHaveCreatedPurchaseAndClickGermanContractWithAndAndAndAndAndAndAnd(string country, string contractType, string usageType, string length, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            GivenGermanDealerHaveCreatedAPurchaseAndClickContractOfAndWithMultipleVariables(country, contractType, usageType, length, billing,
                servicePack, installation, delivery, device1, device2);
        }

        [Given(@"""(.*)"" Dealer have created ""(.*)"" with contract ""(.*)"" ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedWithContractAndAndAndAndAndAndAnd(string country, string contractType, string usageType, string length,
            string leasing, string billing, string servicePack, string installation, string delivery, string device1, string device2)
        {
            GivenDealerHaveCreatedLeasingAndClickGermanContractWithAndAndAndAndAndAndAnd(country, contractType, usageType, length, leasing, billing,
                servicePack, installation, delivery, device1, device2);
        }


        public void GivenDealerHaveCreatedLeasingAndClickGermanContractWithAndAndAndAndAndAndAnd(string country, string contractType, string usageType, string length, 
            string leasing, string billing, string servicePack, string installation, string delivery, string device1, string device2)
        {
            GivenGermanDealerHaveCreatedALeasingAndClickContractOfAnd(country, contractType, usageType, length, leasing, billing,
                servicePack, installation, delivery, device1, device2);
        }


        public void GivenDealerHaveCreatedAContractWithMultipleVariables(string country, string contractType, string usageType, string length, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            var instance = new CreateATemplateSteps();

            contractType = instance.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApprovalWithMultipleVariables(country, contractType, usageType, length, billing,
                    servicePack, installation, delivery, device1, device2);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                    instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                    instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    CalculationEngineModule.DownloadContractPdf(CurrentDriver);
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    CalculationEngineModule.DownloadPageHtml(CurrentDriver, "Bank_AwaitingApprovalSummary");
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                instance.WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApprovalWithMultipleVariables(country, contractType, usageType, length, billing,
                    servicePack, installation, delivery, device1, device2);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                    instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                    instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    CalculationEngineModule.DownloadContractPdf(CurrentDriver);
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    CalculationEngineModule.DownloadPageHtml(CurrentDriver, "LO_AwaitingApprovalSummary");
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }

        public void GivenDealerHaveCreatedProposalOfAwaitingApprovalWithMultipleVariables(string country, string contractType, string usageType, string length, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            var instance = new CreateATemplateSteps();

            contractType = instance.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpenWithMultipleVariables(country, contractType, usageType, length, billing, 
                    servicePack, installation, delivery, device1, device2);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                NextPage = CurrentPage.As<DealerConvertProposalSummaryPage>().DownloadAndSaveProposalAsAContract();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                    CalculationEngineModule.DownloadContractPdf(CurrentDriver);
                    instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                    CalculationEngineModule.DownloadPageHtml(CurrentDriver, "Dealer_AwaitingApprovalSummary");
                    CalculationEngineModule.DownloadProposalPdfOnSummaryPage(CurrentDriver);
                }

                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpenWithMultipleVariables(country, contractType, usageType, length, billing, 
                    servicePack, installation, delivery, device1, device2);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                NextPage = CurrentPage.As<DealerConvertProposalSummaryPage>().DownloadAndSaveProposalAsAContract();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                    CalculationEngineModule.DownloadContractPdf(CurrentDriver);
                    instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                    CalculationEngineModule.DownloadPageHtml(CurrentDriver, "Dealer_AwaitingApprovalSummary");
                    CalculationEngineModule.DownloadProposalPdfOnSummaryPage(CurrentDriver);
                }
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        public void GivenDealerHaveCreatedProposalOfOpenWithMultipleVariables(string country, string contractType, string usageType, string length, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            var instance1 = new CreateATemplateSteps();
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);

            contractType = instance1.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposalWithMultipleVariables(contractType, usageType, length, billing);
                NextPage = CurrentPage.As<DealerProposalsCreateSummaryPage>().DownloadPdfAndSaveProposal();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposalWithMultipleVariables(contractType, usageType, length, billing, 
                    servicePack, installation, delivery, device1, device2);
                NextPage = CurrentPage.As<DealerProposalsCreateSummaryPage>().DownloadPdfAndSaveProposal();
            }
        }

        private void GivenIHaveCreatedLeasingAndClickProposalWithMultipleVariables(string contractType, string usageType, string length, string billing)
        {
            var instance1 = new CreateATemplateSteps();
            contractType = instance1.ContractType(contractType);
            instance1.GivenIamOnMpsNewProposalPage();
            instance1.WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            var termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, length, "Quarterly in Advance", billing);

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }

        private void GivenIHaveCreatedPurchaseAndClickProposalWithMultipleVariables(string contractType, string usageType, string length, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            var instance1 = new CreateATemplateSteps();
            contractType = instance1.ContractType(contractType);

            try
            {
                var language = Selenium.Lib.Support.HelperClasses.SpecFlow.GetContext("BelgianLanguage");
                instance1.GivenIChangeTheLanguageDisplayed(language);
            }
            catch (KeyNotFoundException)
            {
                //Language switch is not needed
            }
            

            instance1.GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);

            if (!(CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local")))
            {
                var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
                customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            }

            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            
            WhenIDisplayDeviceScreen(device1);
            WhenIAcceptTheDefaultValuesOfTheDevice(delivery, installation);

            WhenIDisplayDeviceScreen(device2);
            WhenIAcceptTheDefaultValuesOfTheDevice(delivery, installation);

            WhenIMoveToClickPricePage();
            if (UsageType(usageType).Equals("Minimum Volume"))
            {
                CurrentPage.As<DealerProposalsCreateClickPricePage>().PayServicePackMethod(servicePack);
                NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateSelectedMultipleClickPrice("1000", "1000");
            }
            else if (UsageType(usageType).Equals("Pay As You Go"))
            {
                NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredMultipleClickPrice("1000", "1000");
            }
        }


        private bool IsBelgiumSystem()
        {
            return CurrentPage.As<DealerProposalsCreateClickPricePage>().IsBelgiumSystem();
        }


        private string UsageType(string usageType)
        {
            var type = "";
            if (usageType.Equals("Minimum Volume") 
                || usageType.Equals("Engagement sur un minimum volume de pages") 
                || usageType.Equals("Volume minimo") 
                || usageType.Equals("Volúmen mínimo") 
                || usageType.Equals("Minimumvolume") 
                || usageType.Equals("Minimum volum") 
                || usageType.Equals("Minimum volym") 
                || usageType.Equals("Minimumsvolumen")
                || usageType.Equals("Minimumsvolumen") 
                || usageType.Equals("Pakiet wydruków")
                || usageType.Equals("Mindestvolumen")
                || usageType.Equals("Volume minimum")
                || usageType.Equals("Minimitulostusmäärä")
                || usageType.Equals("Per kwartaal achteraf"))
                
            {
                type = "Minimum Volume";
            }
            else if (usageType.Equals("Pay As You Go") 
                || usageType.Equals("Pago por Uso") 
                || usageType.Equals("Betale ved forbruk") 
                || usageType.Equals("Betala per utskrift") 
                || usageType.Equals("Betalen naar verbruik")
                || usageType.Equals("Bez pakietu wydruków")
                || usageType.Equals("Consommation réelle")
                || usageType.Equals("Maksu tulosteiden mukaan")
                || usageType.Equals("Paiement selon la consommation réelle de pages")
                || usageType.Equals("Werkelijk verbruik"))
            {
                type = "Pay As You Go";
            }

            return type;
        }

        private void WhenIFillProposalDescriptionForContractType(string contract)
        {
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().IsPromptTextDisplayed();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().SelectingContractType(contract);
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterProposalName(CalculationEngineModule.ProposalName());
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterLeadCodeRef("");
            if (CurrentPage.As<DealerProposalsCreateDescriptionPage>().IsBigAtSystem())
            {
                NextPage = CurrentPage.As<DealerProposalsCreateDescriptionPage>().ClickNextButtonGermany();
            }
            else
            {
                NextPage = CurrentPage.As<DealerProposalsCreateDescriptionPage>().ClickNextButton();
            }

        }

        public void WhenIDisplayDeviceScreen(string printer)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductScreenTextDisplayed();
            CurrentPage.As<DealerProposalsCreateProductsPage>().ClickOnAPrinter(printer);
        }

        private void WhenIAcceptTheDefaultValuesOfTheDevice(string delivery, string installation)
        {

            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity("2");

            if (!(CurrentPage.As<DealerProposalsCreateProductsPage>().IsGermanSystem()
                && CurrentPage.As<DealerProposalsCreateProductsPage>().GetContractType() == "Easy Print Pro & Service"))
            {
                //CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity("2");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductMargin("12");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterModelUnitCost();
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionsQuantity0("2");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionCostPrice();
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionMargin("12", "0");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterDeliveryCost(delivery);
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterDeliveryMargin("12");
                CurrentPage.As<DealerProposalsCreateProductsPage>().SelectDeviceInstallationType(installation);
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterInstallationPackMargin("12");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterServicePackMargin("12");
            }

            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
            //CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyProductAdditionConfirmationMessage();
            
        }

        private void WhenIMoveToClickPricePage()
        {
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().MoveToClickPriceScreen();
        }




        public void GivenGermanDealerHaveCreatedALeasingAndClickContractOfAnd(string country,
            string contractType, string usageType, string length, string leasing, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            var instance4 = new CreateNewAccountSteps();


            GivenGermanDealerHaveCreatedLeaseAndClickProposalOfAwaitingApprovalWithMultipleVariables(country, contractType, usageType, length,
                leasing, billing, servicePack, installation, delivery, device1, device2);
            var instance2 = new SendProposalToApprover();
            var instance3 = new AccountManagementSteps();

            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                CalculationEngineModule.DownloadContractPdf(CurrentDriver);
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                CalculationEngineModule.DownloadPageHtml(CurrentDriver, "Bank_AwaitingApprovalSummary");
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
            }


            instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
            WhenISignTheContractAsADealer();
            instance3.ThenIfISignOutOfBrotherOnline();
            
        }

        public void GivenGermanDealerHaveCreatedAPurchaseAndClickContractOfAndWithMultipleVariables(string country,
            string contractType, string usageType, string length, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            var instance4 = new CreateNewAccountSteps();

            GivenGermanDealerHaveCreatedPurchaseAndClickProposalOfAwaitingApprovalWithMultipleVariables(country, contractType, usageType, length, billing,
            servicePack, installation, delivery, device1, device2);
            var instance2 = new SendProposalToApprover();
            var instance3 = new AccountManagementSteps();

            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                CalculationEngineModule.DownloadContractPdf(CurrentDriver);
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                CalculationEngineModule.DownloadPageHtml(CurrentDriver, "LO_AwaitingApprovalSummary");
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
            }

            instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
            WhenISignTheContractAsADealer();
            instance3.ThenIfISignOutOfBrotherOnline();
            
        }

        public void WhenISignTheContractAsADealer()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CalculationEngineModule.DownloadContractPdf(CurrentDriver);
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToViewOfferOnApprovedProposalsTab();
            CalculationEngineModule.DownloadPageHtml(CurrentDriver, "Dealer_ApprovedSummary");
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickSignButtonToNavigateToAwaitingAcceptance();
        }


        public void GivenGermanDealerHaveCreatedLeaseAndClickProposalOfAwaitingApprovalWithMultipleVariables(string country,
            string contractType, string usageType, string length, string leasing, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);
            instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);

           
            GivenIHaveCreatedGermanLeasingAndClickProposalWithMultipleVariables(contractType, usageType, length,
                leasing, billing, servicePack, installation, delivery, device1, device2);

            NextPage = CurrentPage.As<DealerProposalsCreateSummaryPage>().DownloadPdfAndSaveProposal();

            var instance2 = new SendProposalToApprover();
            instance2.GivenISendTheCreatedGermanProposalForApprovalWithDownload();

            var instance3 = new AccountManagementSteps();
            instance3.ThenIfISignOutOfBrotherOnline();
           
        }

        public void GivenGermanDealerHaveCreatedPurchaseAndClickProposalOfAwaitingApprovalWithMultipleVariables(string country, string contractType, string usageType, 
            string length, string billing, string servicePack, string installation, string delivery, string device1, string device2)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);
            instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);

            GivenIHaveCreatedGermanPurchaseAndClickProposalWithMultipleVariables(contractType, usageType, length, billing,
            servicePack, installation, delivery, device1, device2);

            NextPage = CurrentPage.As<DealerProposalsCreateSummaryPage>().DownloadPdfAndSaveProposal();

            var instance2 = new SendProposalToApprover();
            instance2.GivenISendTheCreatedGermanProposalForApprovalWithDownload();

            var instance3 = new AccountManagementSteps();
            instance3.ThenIfISignOutOfBrotherOnline();
          
        }

        private void GivenIHaveCreatedGermanLeasingAndClickProposalWithMultipleVariables(string contractType, string usageType, string length, string leasing, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {

            if (usageType.Equals(string.Empty))
                usageType = "Mindestvolumen";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            var termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, length, leasing, billing);

            WhenIDisplayDeviceScreen(device1);
            WhenIAcceptTheDefaultValuesOfTheDevice(delivery, installation);

            WhenIDisplayDeviceScreen(device2);
            WhenIAcceptTheDefaultValuesOfTheDevice(delivery, installation);

            WhenIMoveToClickPricePage();
            if (UsageType(usageType).Equals("Minimum Volume"))
            {
                try
                {
                    CurrentPage.As<DealerProposalsCreateClickPricePage>().PayServicePackMethod(servicePack);
                }
                catch (NullReferenceException nre)
                {

                    Helper.MsgOutput(String.Format("Click price was selected due to {0}", nre));
                }
                
                //NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateSelectedMultipleClickPrice("1000", "1000");
                try
                {
                    NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredMultipleClickPrice("1000", "1000");
                }
                catch (WebDriverException wex)
                {
                    NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateSelectedMultipleClickPrice("1000", "1000");
                    Helper.MsgOutput(String.Format("Click price was selected due to {0}", wex));
                }
            }
            else if (UsageType(usageType).Equals("Pay As You Go"))
            {
                //NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredMultipleClickPrice("1000", "1000");
               // NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateSelectedMultipleClickPrice("1000", "1000");

                try
                {
                    NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredMultipleClickPrice("1000", "1000");
                }
                catch (WebDriverException wex)
                {
                    NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateSelectedMultipleClickPrice("1000", "1000");
                    Helper.MsgOutput(String.Format("Click price was selected due to {0}", wex));
                }
            }
        }


        private void GivenIHaveCreatedGermanPurchaseAndClickProposalWithMultipleVariables(string contractType, string usageType, string length, string billing,
            string servicePack, string installation, string delivery, string device1, string device2)
        {
            if (usageType.Equals(string.Empty))
                usageType = "Mindestvolumen";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);

            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.EditTermAndTypeTabForPurchaseOffer(usageType, length, billing);

            WhenIDisplayDeviceScreen(device1);
            WhenIAcceptTheDefaultValuesOfTheDevice(delivery, installation);

            WhenIDisplayDeviceScreen(device2);
            WhenIAcceptTheDefaultValuesOfTheDevice(delivery, installation);

            WhenIMoveToClickPricePage();
            if (UsageType(usageType).Equals("Minimum Volume"))
            {
                //CurrentPage.As<DealerProposalsCreateClickPricePage>().PayServicePackMethod(servicePack);
                try
                {
                    NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateSelectedMultipleClickPrice("1000", "1000");
                }
                catch (WebDriverException wex)
                {
                    Helper.MsgOutput(String.Format("Click price was entered due to {0}", wex));
                    NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredMultipleClickPrice("1000", "1000");
                }
               
            }
            else if (UsageType(usageType).Equals("Pay As You Go"))
            {
                //NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredMultipleClickPrice("1000", "1000");
                //NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateSelectedMultipleClickPrice("1000", "1000");

                try
                {
                    NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateSelectedMultipleClickPrice("1000", "1000");
                }
                catch (WebDriverException wex)
                {
                    Helper.MsgOutput(String.Format("Click price was entered due to {0}", wex));
                    NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredMultipleClickPrice("1000", "1000");
                }
            }
            
        }

        public void GivenIamOnMpsNewProposalPage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToCreateNewProposalPage();
        }

        
      }


}
