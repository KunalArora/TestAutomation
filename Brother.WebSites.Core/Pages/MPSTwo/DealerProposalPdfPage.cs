using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalPdfPage : BasePage
    {

        private const string DownloadPath = @"file:///C:/Users/afolabsa/Downloads/";
        private const string UkText = @"Total Quarterly In Arrears";
        private const string DeText = @"Brother EasyPrint Pro";
        private const string AtText = @"Bedingung";
        private const string ItText = @"Pacchetto assistenza MPS per inkjet";
        private const string FrText = @"COUT D’ACQUISITION";
        private const string SpText = @"Propuesta";
        private const string DownloadDirectory = @"C:/Users/afolabsa/Downloads";


        [FindsBy(How = How.CssSelector, Using = "#content_1_SummaryTable_ProposalDetailsContainer")]
        public IWebElement SummaryPageContractIdElement;

        private string DownloadFolderPath()
        {

            var propRef = MpsUtil.GeneratedLeadCodeRef();
            var propName = MpsUtil.CreatedProposal();

            var partialPath = DownloadPath + propName + "-" + propRef + "-";

            return partialPath;
        }

        public void GetDownloadedPdfPath()
        {
            var contractid = SummaryPageContractIdElement.GetAttribute("data-mps-qa-id");
            SpecFlow.SetContext("SummaryPageContractId", contractid);

            var downloadPath = DownloadFolderPath() + contractid;
            SpecFlow.SetContext("DownloadedPdfPath", downloadPath);

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

        public void DoesPdfContentContainContractId()
        {
            var contractId = SpecFlow.GetContext("SummaryPageContractId");
            TestCheck.AssertTextContains(contractId, ExtractTextFromPdf(DownloadedPdf()),
                "Contract Id is not available in the PDF");

        }

        public DealerProposalsCreateSummaryPage PurgeDownloadsDirectory()
        {
            Driver.Navigate().Back();
            PurgeDownloads(DownloadDirectory);

            return GetInstance<DealerProposalsCreateSummaryPage>();
        }

        public void IsCustomerEmailPresentInPdf()
        {
            if (IsBigAtSystem()) return;
            var customerEmail = SpecFlow.GetContext("SummaryCustomerEmail");
            TestCheck.AssertTextContains(customerEmail, ExtractTextFromPdf(DownloadedPdf()),
                "Customer Email is not available in the PDF");
        }

        public void IsCustomerNamePresentInPdf()
        {
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
            if (IsBigAtSystem()) return;
            var contractType = SpecFlow.GetContext("SummaryContractType");
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
            }
            else if (IsUKSystem())
            {
                lang = UkText;
            }
            else if (IsGermanSystem())
            {
                lang = DeText;
            }
            else if (IsFranceSystem())
            {
                lang = FrText;
            }
            else if (IsItalySystem())
            {
                lang = ItText;
            }
            else if (IsItalySystem())
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
