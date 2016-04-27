using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsAwaitingAcceptancePage : BasePage
    {
        public static string Url = "/mps/dealer/contracts";
        private const string UkText = @"Purchase + Click Agreement Number";
        private const string DeText = @"Mehrwertsteuer";
        private const string AtText = @"Deckungsgrades";
        private const string ItText = @"Durata del Contratto";
        private const string FrText = @"CONTRAT DE SERVICE PRINTSMART";
        private const string SpText = @"Referencia número contrato";
        private const string DownloadDirectory = @"C:/Users/afolabsa/Downloads";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".active [href=\"/mps/dealer/contracts/awaiting-acceptance\"]")]
        public IWebElement ContractAwaitingAcceptanceTabElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-manage-devices")]
        public IWebElement ManageDevicesElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-download-contract-pdf")]
        public IWebElement DownloadContractPdfElement;


        public void IsContractAwaitingAcceptanceTabDisplayed()
        {
            if(ContractAwaitingAcceptanceTabElement == null)
                throw new Exception("Dealer Contract Awaiting Acceptance tab is not displayed");
            AssertElementPresent(ContractAwaitingAcceptanceTabElement, "Dealer Contract Awaiting Acceptance tab");
        }


        public void VerifyAcceptedContractIsDisplayed()
        {
            var createdProposal = MpsUtil.CreatedProposal();
            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);
            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public ManageDevicesPage NavigateToManageDevicesPage()
        {
            if (ManageDevicesElement == null)
                throw new Exception("Manage Device Element is not displayed");

            ActionsModule.ClickOnSpecificActionsElement(Driver);

            ScrollTo(ManageDevicesElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ManageDevicesElement);
            MPSJobRunnerPage.RunCreateCustomerAndPersonCommandJob();
            return GetInstance<ManageDevicesPage>(Driver);
        }

        public void DownloadContractPdfOnDealerAwaitingAcceptanceContractPages()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.DownloadContractInvoicePDFAction(Driver);
        }

        private string DownloadFolderPath()
        {
            var path = "";

            if (IsAustriaSystem() || IsGermanSystem())
            {
                path = "file:///C:/Users/afolabsa/Downloads/{0}-Vertrag.pdf";

            }
            else if (IsUKSystem())
            {
                path = "file:///C:/Users/afolabsa/Downloads/{0}-Contract.pdf";

            }
            else if (IsFranceSystem())
            {
                path = "file:///C:/Users/afolabsa/Downloads/{0}-Contrat.pdf";
                
            }
            else if (IsItalySystem())
            {
                path = "file:///C:/Users/afolabsa/Downloads/{0}-Contratto.pdf";
            }
            else if (IsSpainSystem())
            {
                //path = "file:///C:/Users/afolabsa/Downloads/{0}-Contrato.pdf";
                path = "file:///C:/Users/afolabsa/Downloads/{0}-Contract.pdf";
            }

            return path;
        }


        public void GetDownloadedPdfPath()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            var contractid = DownloadContractPdfElement.GetAttribute("data-contract-id");
            SpecFlow.SetContext("DownloadedContractId", contractid);
            var downloadPath = String.Format(DownloadFolderPath(), contractid);
            SpecFlow.SetContext("DownloadedPdfPath", downloadPath);
            ActionsModule.DownloadContractPDFAction(Driver);
            WebDriver.Wait(DurationType.Second, 2);

        }

        public void DisplayDownloadedPdf()
        {
            var downloadedPdf = DownloadedPdf();
            Driver.Navigate().GoToUrl(downloadedPdf);
        }

        private static string DownloadedPdf()
        {
            var downloadedPdf = SpecFlow.GetContext("DownloadedPdfPath");
            return downloadedPdf;
        }

        public void DoesPdfContentContainSomeText()
        {
            var contractId = SpecFlow.GetContext("DownloadedContractId");
            TestCheck.AssertTextContains(contractId, ExtractTextFromPdf(DownloadedPdf()), 
                "Contract Id is not available in the PDF");
            
        }

        

        public void PurgeDownloadsDirectory()
        {
            //Driver.Navigate().Back();
            PurgeDownloads(DownloadDirectory);
        }

        public void IsCustomerEmailPresentInPdf()
        {
            if(IsBigAtSystem() || IsSpainSystem()) return;
            var customerEmail = SpecFlow.GetContext("SummaryCustomerEmail");
            TestCheck.AssertTextContains(customerEmail, ExtractTextFromPdf(DownloadedPdf()),
                "Customer Email is not available in the PDF");
        }

        public void IsCustomerNamePresentInPdf()
        {
            if (IsSpainSystem()) return;
            var customerName = SpecFlow.GetContext("SummaryCustomerOrCompanyName");
            TestCheck.AssertTextContains(customerName, ExtractTextFromPdf(DownloadedPdf()),
                "Customer Name is not available in the PDF");
        }

        private string ConvertTermForUk(string term)
        {
            var convertedTerm = "";
            if (!IsUKSystem()) return convertedTerm;
            switch (term)
            {
                case "3 years":
                    convertedTerm = "36";
                    break;

                case "4 years":
                    convertedTerm = "48";
                    break;

                case "5 years":
                    convertedTerm = "60";
                    break;
            }
            return convertedTerm;
        }

        public void IsSummaryContractTermPresentInPdf()
        {
            if (IsBigAtSystem()) return;
            var contractTerm = SpecFlow.GetContext("SummaryContractTerm");
            contractTerm = ConvertTermForUk(contractTerm);
            TestCheck.AssertTextContains(contractTerm, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Contract Term is not available in the PDF");
        }

        public void IsSummaryContractTypePresentInPdf()
        {
            var contractType = "";

            if (IsBigAtSystem()) return;
            contractType = IsItalySystem() ? "Programma \"Pagine+ Cloud\"" : SpecFlow.GetContext("SummaryContractType");
            TestCheck.AssertTextContains(contractType, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Contract Type is not available in the PDF");
        }

        public void IsSummaryMonoClickRatePresentInPdf()
        {
            var monoClickRate = SpecFlow.GetContext("SummaryMonoClickRate");
            monoClickRate = ConvertClickRatePrice(monoClickRate);
            TestCheck.AssertTextContains(monoClickRate, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Mono Click Rate is not available in the PDF");
        }

        private string ConvertClickRatePrice(string clickPrice)
        {
            
            decimal clickDecimal = 0;

            if (IsBigAtSystem())
            {
                clickDecimal = MpsUtil.GetEuroValue(clickPrice);
            }

            
            return clickDecimal.ToString();
        }

        private string AddCommaToColourClickPrice(string clickRate)
        {
            var sectionOne = clickRate.Substring(0, 1);
            var sectionTwo = clickRate.Substring(1);

            var coJoin = sectionOne + "," + sectionTwo;

            return coJoin;

        }

        public void IsSummaryColourClickRatePresentInPdf()
        {
            var colourClickRate = SpecFlow.GetContext("SummaryColourClickRate");
            colourClickRate = ConvertClickRatePrice(colourClickRate);
            if (IsBigAtSystem())
            {
                colourClickRate = AddCommaToColourClickPrice(colourClickRate);
            }
            TestCheck.AssertTextContains(colourClickRate, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Colour Click Rate is not available in the PDF");
        }

        private string SpecificLanguageText()
        {
            var lang = "";

            if (IsAustriaSystem())
            {
                lang = AtText;
            } else if (IsUKSystem())
            {
                lang = UkText;
            } else if (IsGermanSystem())
            {
                lang = DeText;
            } else if (IsFranceSystem())
            {
                lang = FrText;
            } else if (IsItalySystem())
            {
                lang = ItText;
            } else if (IsSpainSystem())
            {
                lang = SpText;
            }

            

            return lang;

        }

        public void IsCorrectLanguagePdfDownloaded()
        {
            TestCheck.AssertTextContains(SpecificLanguageText(), ExtractTextFromPdf(DownloadedPdf()),
                "The correct language PDF is not downloaded");
        }


    }
}
