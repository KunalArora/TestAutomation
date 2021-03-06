﻿using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsAwaitingAcceptancePage : BasePage, IPageObject
    {
        private static string _url = "/mps/dealer/contracts/awaiting-acceptance";
        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/contracts/awaiting-acceptance\"]"; //list Next

        public static string Url = "/mps/dealer/contracts";
        private const string UkText = @"Purchase + Click Agreement Number";
        private const string DeText = @"Mehrwertsteuer";
        private const string AtText = @"Deckungsgrades";
        private const string ItText = @"Durata del Contratto";
        private const string FrText = @"CONTRAT DE SERVICE PRINTSMART";
        private const string SpText = @"Referencia número contrato";
        private const string DownloadDirectory = @"C:/DataTest";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }


        [FindsBy(How = How.CssSelector, Using = ".active [href=\"/mps/dealer/contracts/awaiting-acceptance\"]")]
        public IWebElement ContractAwaitingAcceptanceTabElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-manage-devices")]
        public IWebElement ManageDevicesElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-download-contract-pdf")]
        public IWebElement DownloadContractPdfElement;


        public void IsContractAwaitingAcceptanceTabDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ContractAwaitingAcceptanceTabElement == null)
                throw new Exception("Dealer Contract Awaiting Acceptance tab is not displayed");
            AssertElementPresent(ContractAwaitingAcceptanceTabElement, "Dealer Contract Awaiting Acceptance tab");
        }


        public void VerifyAcceptedContractIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = MpsUtil.CreatedProposal();
            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);
            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public DealerManageDevicesPage NavigateToManageDevicesPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ManageDevicesElement == null)
                throw new Exception("Manage Device Element is not displayed");

            ActionsModule.ClickOnSpecificActionsElement(Driver);

            ScrollTo(ManageDevicesElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ManageDevicesElement);
            MpsJobRunnerPage.RunCreateCustomerAndPersonCommandJob();
            return GetInstance<DealerManageDevicesPage>(Driver);
        }

        public void DownloadContractPdfOnDealerAwaitingAcceptanceContractPages()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.DownloadContractInvoicePdfAction(Driver);
        }

        private string DownloadFolderPath()
        {
            LoggingService.WriteLogOnMethodEntry();
            var path = "";

            if (IsAustriaSystem() || IsGermanSystem() || IsSwissSystem())
            {
                path = "file:///C:/DataTest/{0}-Vertrag.pdf";

            }
            else if (IsUKSystem() || IsIrelandSystem())
            {
                path = "file:///C:/DataTest/{0}-Contract.pdf";

            }
            else if (IsFranceSystem())
            {
                path = "file:///C:/DataTest/{0}-Contrat.pdf";
                
            }
            else if (IsItalySystem())
            {
                path = "file:///C:/DataTest/{0}-Contratto.pdf";
            }
            else if (IsSpainSystem())
            {
                path = "file:///C:/DataTest/{0}-Contrato.pdf";
            }
            else if (IsSwedenSystem())
            {
                path = "file:///C:/DataTest/{0}-Avtal.pdf";
            }
            else if (IsNetherlandSystem())
            {
                path = "file:///C:/DataTest/{0}-Contract.pdf";
            }else if (IsDenmarkSystem())
            {
                path = "file:///C:/DataTest/{0}-Kontrakt.pdf";
            }
            else if (IsBelgiumSystem())
            {
                path = "file:///C:/DataTest/{0}-Contrat.pdf";

            }
            else if (IsPolandSystem())
            {
                path = "file:///C:/DataTest/{0}-Contract.pdf";

            }
            else if (IsFinlandSystem())
            {
                path = "file:///C:/DataTest/{0}-Sopimus.pdf";

            }
            else if (IsNorwaySystem())
            {
                path = "file:///C:/DataTest/{0}-Avtale.pdf";

            }
            
            return path;
        }


        public void GetDownloadedPdfPath()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            var downloadedPdf = DownloadedPdf();
            Driver.Navigate().GoToUrl(downloadedPdf);
        }

        private string DownloadedPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            var downloadedPdf = SpecFlow.GetContext("DownloadedPdfPath");
            return downloadedPdf;
        }

        public void DoesPdfContentContainSomeText()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 10);

            var contractType = MpsUtil.GetContractType();
            var leasing = contractType.Equals("Leasing & Service");

            var country = SpecFlow.GetContext("CountryOfTest");
            var germany = country.Equals("Germany");
            var germanyLeasing = germany && leasing;

            var customerRef = germanyLeasing ? SpecFlow.GetContext("GeneratedCustomerReference") : SpecFlow.GetContext("DownloadedContractId");

            var contractId = customerRef;

            if (!Driver.Url.Contains("Vertrag"))
            {
                TestCheck.AssertTextContains(contractId, ExtractTextFromPdf(DownloadedPdf()),
                "Contract Id is not available in the PDF");
            }
            
        }
        
        public void PurgeDownloadsDirectory()
        {
            LoggingService.WriteLogOnMethodEntry();
            //Driver.Navigate().Back();
            PurgeDownloads(DownloadDirectory);
        }

        public void IsCustomerEmailPresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsBigAtSystem() || IsSpainSystem() || IsPolandSystem()) return;
            var customerEmail = SpecFlow.GetContext("SummaryCustomerEmail");
            TestCheck.AssertTextContains(customerEmail, ExtractTextFromPdf(DownloadedPdf()),
                "Customer Email is not available in the PDF");
        }

        public void IsCustomerNamePresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsSpainSystem()) return;
            var customerName = SpecFlow.GetContext("SummaryCustomerOrCompanyName");
            TestCheck.AssertTextContains(customerName.Substring(0, 9), ExtractTextFromPdf(DownloadedPdf()),
                "Customer Name is not available in the PDF");
        }

        private string ConvertTermForUk(string term)
        {
            LoggingService.WriteLogOnMethodEntry(term);
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
            LoggingService.WriteLogOnMethodEntry();
            if (IsBigAtSystem()) return;
            var contractTerm = SpecFlow.GetContext("SummaryContractTerm");
            contractTerm = ConvertTermForUk(contractTerm);
            TestCheck.AssertTextContains(contractTerm, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Contract Term is not available in the PDF");
        }

        public void IsSummaryContractTypePresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsBigAtSystem() || IsPolandSystem() || IsDenmarkSystem()) return;
            var contractType = IsItalySystem() ? "Programma \"Pagine+ Cloud\"" : SpecFlow.GetContext("SummaryContractType");

            if (IsFinlandSystem())
            {
                contractType = contractType.Replace(" ", "-");
            }

            if (IsNorwaySystem())
            {
                contractType = contractType.Substring(0, 13).TrimEnd();
            }
            TestCheck.AssertTextContains(contractType, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Contract Type is not available in the PDF");
        }

        public void IsSummaryMonoClickRatePresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            var monoClickRate = SpecFlow.GetContext("SummaryMonoClickRate");
           // monoClickRate = ConvertClickRatePrice(monoClickRate);
            var colourClickRateFormat = IsBigAtSystem() ? AddCommaToColourClickPrice(monoClickRate) : ConvertClickRatePrice(monoClickRate);
            TestCheck.AssertTextContains(colourClickRateFormat, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Mono Click Rate is not available in the PDF");
        }

        private string ConvertClickRatePrice(string clickPrice)
        {
            LoggingService.WriteLogOnMethodEntry(clickPrice);
            decimal clickDecimal = 0;

            if (IsBigAtSystem())
            {
                clickDecimal = MpsUtil.GetEuroValue(clickPrice);
            }

            
            return clickDecimal.ToString();
        }

        private string AddCommaToColourClickPrice(string clickRate)
        {
            LoggingService.WriteLogOnMethodEntry(clickRate);
            string coJoin = null;

            if ((IsAustriaSystem() && GetContractType() == "Leasing & Service"))
            {
                coJoin = clickRate.Replace("€", ""); 
            }
            else
            {
                var stringToUse = clickRate.Replace(",", ".").Replace("€", "");
                decimal number;
                if (Decimal.TryParse(stringToUse, out number))
                {
                    number = number * 100;
                    coJoin = number.ToString().Replace(".", ",").TrimEnd('0');
                }
            }

            return coJoin;

        }

        public void IsSummaryColourClickRatePresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            var colourClickRate = SpecFlow.GetContext("SummaryColourClickRate");

            var colourClickRateFormat = IsBigAtSystem() ? AddCommaToColourClickPrice(colourClickRate) : ConvertClickRatePrice(colourClickRate);

            TestCheck.AssertTextContains(colourClickRateFormat, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Colour Click Rate is not available in the PDF");
        }

        private string SpecificLanguageText()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertTextContains(SpecificLanguageText(), ExtractTextFromPdf(DownloadedPdf()),
                "The correct language PDF is not downloaded");
        }


    }
}
