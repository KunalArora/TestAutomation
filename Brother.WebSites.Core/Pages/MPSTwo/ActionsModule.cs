using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Brother.Tests.Selenium.Lib.Mail;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public static class ActionsModule
    {
        private const string ConvertToContractButton = @".open .js-mps-convert";
        private const string ProposalEditButton = @".open .js-mps-edit";
        private const string ProposalDeleteButton = @".open .js-mps-delete";
        private const string SendToBankButton = @".open ul.dropdown-menu .js-mps-send-to-approver";
        private const string OpenOfferViewSummaryButton = @".open ul.dropdown-menu .js-mps-view-summary";
        private const string ActionsButton = @".js-mps-filter-ignore .dropdown-toggle";
        private const string PreInstallationButton = @".open ul.dropdown-menu .js-mps-pre-installation";
        private const string MaintainOfferButton = @".open ul.dropdown-menu .js-mps-maintain-offer";
        private const string ProposalCopyElement = @".open .js-mps-copy";
        private const string ProposalCopyElementWithCustomer = @".open .js-mps-copy-with-customer";
        private const string ContractDownloadPdf = @".open .js-mps-download-contract-pdf";
        private const string ContractDownloadInvoicePdf = @".open .js-mps-download-contract-invoice-pdf";
        private const string ActionButtion = @".js-mps-filter-ignore [type='button']";
        private const string SearchField = @"#content_1_ProposalListFilter_InputFilterBy";
        private const string CustomerSearchFieldElement = @"#content_1_PersonListFilter_InputFilterBy";
        private const string ContractSearchField = @"#content_1_ContractListFilter_InputFilterBy";
        private const string BelgianLanguages = @".mps-lang > span > a";
       
        

        private static IWebElement CopyProposalButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProposalCopyElement));
        }

        private static IWebElement SearchFieldElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(SearchField));
        }

        private static IWebElement ContractSearchFieldElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ContractSearchField));
        }

        private static IWebElement CopyProposalWithCustomerButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProposalCopyElementWithCustomer));
        }

        public static IWebElement ConvertButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ConvertToContractButton));
        }

        private static IWebElement MaintainOfferElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(MaintainOfferButton));
        }

        private static IWebElement DownloadContractPDFElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ContractDownloadPdf));
        }

        private static IWebElement DownloadContractInvoicePDFElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ContractDownloadInvoicePdf));
        }

        private static IWebElement PreInstallationElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(PreInstallationButton));
        }

        private static IWebElement OpenOfferViewSummaryElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(OpenOfferViewSummaryButton));
        }

        private static IWebElement ProposalEditButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProposalEditButton));
        }

        private static IWebElement CustomerSearchField(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(CustomerSearchFieldElement));
        }

        private static IWebElement ProposalDeleteButtonElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProposalDeleteButton));
        }
        private static IList<IWebElement> SendToBankButtonElement(ISearchContext driver)
        {
            return driver.FindElements(By.CssSelector(SendToBankButton));
        }

        private static IList<IWebElement> BelgianLanguageSelectorElement(ISearchContext driver)
        {
            return driver.FindElements(By.CssSelector(BelgianLanguages));
        }

        private static IList<IWebElement> AllActionsButton(ISearchContext driver)
        {
            return driver.FindElements(By.CssSelector(ActionButtion));
        }

        private static IList<IWebElement> ActionsDropdownElement(ISearchContext driver)
        {

            var actionsElement = driver.FindElements(By.CssSelector(ActionsButton));
            return actionsElement;
        }

        public static void DownloadContractPDFAction(IWebDriver driver)
        {
            var action = DownloadContractPDFElement(driver);
            action.Click();
            
        }

        private static string UrlValue(IWebDriver driver)
        {
            return driver.Url.ToLower();
        }

        private static void WaitForRowToAppearBeforeProceeding()
        {
            SeleniumHelper.WaitForElementToExistByCssSelector("#DataTables_Table_0 .js-mps-searchable tr", 5, 10);
        }

        public static void SearchForNewlyProposalItem(IWebDriver driver, string search)
        {
            WaitForRowToAppearBeforeProceeding();
            var action = UrlValue(driver).Contains("contracts") ? ContractSearchFieldElement(driver) : SearchFieldElement(driver);
            action.Clear();
            action.SendKeys(search);
            action.SendKeys(Keys.Tab);
            WaitForRowToAppearBeforeProceeding();
        }

        private static IWebElement BelgianLanguageOption(ISearchContext driver, int count)
        {
            return BelgianLanguageSelectorElement(driver).ElementAt(count);
        }

        public static void SelectBelgianFrenchLanguageOption(ISearchContext driver)
        {
            BelgianLanguageOption(driver, 0).Click();
        }

        public static void SelectBelgianDutchLanguageOption(ISearchContext driver)
        {
            BelgianLanguageOption(driver, 1).Click();
        }

       
        public static void SearchForNewCustomer(IWebDriver driver)
        {
            var search = CustomerSearchField(driver);
            search.Clear();
            search.SendKeys(SpecFlow.GetContext("GeneratedEmailAddress"));
            WaitForRowToAppearBeforeProceeding();
        }

        public static void SearchForNewCustomerByName(IWebDriver driver)
        {
            var search = CustomerSearchField(driver);
            search.Clear();
            search.SendKeys(SpecFlow.GetContext("GeneratedCompanyName"));
            WaitForRowToAppearBeforeProceeding();
        }


        public static void ModifyXmlValues(string model, string serial, string total, string colour, string mono)
        {
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(@"C:\Email\Report.xml");

            serial = string.Format("X00000{0}", serial);
            model = string.Format("Brother {0}", model);

            var nsMgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsMgr.AddNamespace("xbpsdManagedInfo", "http://schemas.brother.info/mfc/mailreports/");
            nsMgr.AddNamespace("bpsdm", "http://schemas.brother.info/mfc/mailreports/1.00");

            var modelName = xmlDoc.SelectSingleNode("/xbpsdManagedInfo:xbpsdManagedInfo/bpsdm:DeviceInfo/bpsdm:ModelName", nsMgr);
            var serialNumber = xmlDoc.SelectSingleNode("/xbpsdManagedInfo:xbpsdManagedInfo/bpsdm:DeviceInfo/bpsdm:SerialNumber", nsMgr);
            var totalPrint = xmlDoc.SelectSingleNode("/xbpsdManagedInfo:xbpsdManagedInfo/bpsdm:DeviceReport/bpsdm:DeviceCounter/bpsdm:PageCount/bpsdm:Total", nsMgr);
            var colourPrint = xmlDoc.SelectSingleNode("/xbpsdManagedInfo:xbpsdManagedInfo/bpsdm:DeviceReport/bpsdm:DeviceCounter/bpsdm:PageCount/bpsdm:Color", nsMgr);
            var monoPrint = xmlDoc.SelectSingleNode("/xbpsdManagedInfo:xbpsdManagedInfo/bpsdm:DeviceReport/bpsdm:DeviceCounter/bpsdm:PageCount/bpsdm:Monochrome", nsMgr);


            if (modelName != null)
            {
                modelName.InnerText = model;
            }

            if (serialNumber!= null)
            {
                serialNumber.InnerText = serial;
            }

            if (totalPrint != null)
            {
                totalPrint.InnerText = total;
            }

            if (colourPrint != null)
            {
                colourPrint.InnerText = colour;
            }

            if (monoPrint != null)
            {
                monoPrint.InnerText = mono;
            }
            

            Helper.DeleteFileFromDirectory(@"C:\Email\Edited\Report.xml");
            xmlDoc.Save(@"C:\Email\Edited\Report.xml");

         }

        public static void SendXml(string email, string subject)
        {
            Mailer.SendEmailWithAttachment(email, subject, "", @"C:\Email\Edited\Report.xml");
        }


        public static void SendServiceRequestEmail(string address, string subject, string body)
        {
            Mailer.SendEmailWithoutAttachment(address, subject, body);
        }


        public static void DownloadContractInvoicePdfAction(IWebDriver driver)
        {
            var action = DownloadContractInvoicePDFElement(driver);
            action.Click();

        }

        public static IWebElement SearchFieldFucntionality(IWebDriver driver)
        {
            var element = driver.FindElement(By.Id("content_1_ProposalListFilter_InputFilterBy"));
            return element;
        }

        
        public static IWebElement SpecificActionsDropdownElement(IWebDriver driver)
        {
            return AllActionsButton(driver).First();


        }

        public static int NumberOfActionButtonDisplayed(IWebDriver driver)
        {
            return AllActionsButton(driver).Count;
        }

      
        public static IWebElement SpecificCustomerActionsDropdownElement()
        {

            var actionsElement = SeleniumHelper.FindElementByJs(CreatedEmailActionButton());
            return actionsElement;
        }

        public static IWebElement SpecificSubDealerActionsDropdownElement()
        {

            var actionsElement = SeleniumHelper.FindElementByJs(SubDealerEmailActionButton());
            return actionsElement;
        }

        public static void DeleteSubdealer(IWebDriver driver)
        {
            SpecificSubDealerActionsDropdownElement().Click();
            WebDriver.Wait(Helper.DurationType.Second, 2);
            ProposalDeleteButtonElement(driver).Click();
        }

        public static void EditSubdealer(IWebDriver driver)
        {
            SpecificSubDealerActionsDropdownElement().Click();
            WebDriver.Wait(Helper.DurationType.Second, 2);
            ProposalEditButtonElement(driver).Click();
        }

        public static void ClickOnSpecificActionsElement(IWebDriver driver)
        {
            SearchForNewlyProposalItem(driver, MpsUtil.CreatedProposal());

            ClickOnTheActionsDropdown(0, driver);
        }

        public static void ClickOnSpecificActionsElement(IWebDriver driver, string proposal)
        {
            SearchForNewlyProposalItem(driver, proposal);

            ClickOnTheActionsDropdown(0, driver);
        }

        public static void ClickOnSpecificCustomerActions(IWebDriver driver)
        {
            SearchForNewCustomer(driver);
            ClickOnTheActionsDropdown(0, driver);
        }

        public static void ClickOnCustomerSearchedByNameActions(IWebDriver driver)
        {
            SearchForNewCustomerByName(driver);
            ClickOnTheActionsDropdown(0, driver);
        }

        public static void ClickOnCopiedProposalActionsElement(IWebDriver driver)
        {
            SearchForNewlyProposalItem(driver, MpsUtil.CopiedProposal());
            ClickOnTheActionsDropdown(0, driver);
        }

        public static void IsNewlyCreatedItemDisplayed(IWebDriver driver)
        {
            SearchForNewlyProposalItem(driver, MpsUtil.CreatedProposal());
            var actionCount = AllActionsButton(driver).Count.Equals(1);

            var message = String.Format("{0} is not displayed", MpsUtil.CreatedProposal());

            TestCheck.AssertIsEqual(true, actionCount, message);
        }


        public static void IsNewlyCopiedItemDisplayed(IWebDriver driver)
        {
            SearchForNewlyProposalItem(driver, MpsUtil.CopiedProposal());
            var actionCount = AllActionsButton(driver).Count.Equals(1);

            var message = String.Format("{0} is not displayed", MpsUtil.CreatedProposal());

            TestCheck.AssertIsEqual(true, actionCount, message);
        }

        public static void IsNewlyCreatedCustomerDisplayed(IWebDriver driver)
        {
            SearchForNewCustomer(driver);
            var actionCount = AllActionsButton(driver).Count.Equals(1);

            var message = String.Format("{0} is not displayed", SpecFlow.GetContext("GeneratedEmailAddress"));

            TestCheck.AssertIsEqual(true, actionCount, message);
        }

        public static void OpenTheFirstActionButton(IWebDriver driver)
        {
            WaitForRowToAppearBeforeProceeding();

            try
            {
                AllActionsButton(driver).First().Click();
            }
            catch(Exception ex)
            {
                //Do nothing
            }
            
        }

        private static string ProposalCreatedActionButton()
        {
            return String.Format("return $('td:contains(\"{0}\")').parent('tr').children('td').children('div').children('button')", 
                MpsUtil.CreatedProposal());

        }

        private static string CreatedEmailActionButton()
        {
            return String.Format("return $('td:contains(\"{0}\")').parent('tr').children('td').children('div').children('button')",
                MpsUtil.CreatedEmail());
        }

        private static string SubDealerEmailActionButton()
        {
            return String.Format("return $('td:contains(\"{0}\")').parent('tr').children('td').children('div').children('button')",
                MpsUtil.SubdealerEmail());
        }


        private static string GeneratedPinForInstallation()
        {
            return "return $(('#content_0_LabelPinForTool').parent().children('div'))";
        }

       
        private static string CopiedProposalCustomer()
        {
            //return String.Format("//td[text()='{0}']/parent::tr/td[4]",
            //    MpsUtil.CopiedProposal());

            return "return $(('.js-mps-filter-ignore').parent('td').parent('tr').children('td'))[3]";
        }

        public static IWebElement ProposalCustomerColumn()
        {
            var actionsElement = SeleniumHelper.FindElementByJs(CopiedProposalCustomer());
            return actionsElement;
        }

        private static string CreatedProposalCustomer()
        {
            //return String.Format("//td[text()='{0}']/parent::tr/td[4]",
            //    MpsUtil.CreatedProposal());

            return "return $(('.js-mps-filter-ignore').parent().parent().children('td'))[3]";
        }

        public static IWebElement CreatedProposalCustomerColumn()
        {
            var actionsElement = SeleniumHelper.FindElementByJs(CreatedProposalCustomer());
            return actionsElement;
        }

        public static void ClickOnTheActionsDropdown(int index, IWebDriver driver)
        {
            var actionsElement = ActionsDropdownElement(driver);
            actionsElement.ElementAt(index).Click();
        }

        public static void CopyAProposal(IWebDriver driver)
        {
            var copyButton = CopyProposalButtonElement(driver);
            copyButton.Click();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            SearchFieldFucntionality(driver).Clear();
        }

        public static void CopyAProposalWithCustomer(IWebDriver driver)
        {
            var copyButton = CopyProposalWithCustomerButtonElement(driver);
            copyButton.Click();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            SearchFieldFucntionality(driver).Clear();
        }

        public static void NavigateToPreInstallationScreen(IWebDriver driver)
        {
            var actionsElement = PreInstallationElement(driver);
            actionsElement.Click();
           
        }

        public static void NavigateToMaintainOfferScreen(IWebDriver driver)
        {
            var actionsElement = MaintainOfferElement(driver);
            actionsElement.Click();
            
        }

        public static void StartConvertToContractProcess(IWebDriver driver)
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(driver, ConvertButtonElement(driver));
        }

        public static void NavigateToSummaryPageUsingActionButton(IWebDriver driver)
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(driver, OpenOfferViewSummaryElement(driver));
        }

        public static void StartTheProposalEditProcess(IWebDriver driver)
        {
            
            ProposalEditButtonElement(driver).Click();
            
        }
        public static void DeleteAProposal(IWebDriver driver)
        {
            ProposalDeleteButtonElement(driver).Click();
           
        }
        public static void SendProposalToBankButton(IWebDriver driver)
        {
            SendToBankButtonElement(driver).Last().Click();
        }

        public static void ChangeTonerInkStatus(string toner)
        {
            MpsJobRunnerPage.SetTonerInkStatusForNewPrinter(toner);
            MpsJobRunnerPage.NotifyBocOfNewChanges();
        }

        public static void RunConsumableOrderCreationJobs()
        {
            MpsJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob(MpsUtil.CreatedProposal(), Helper.Locale);
            MpsJobRunnerPage.RunRefreshPrintCountsFromEmailCommandJob(Helper.Locale);
            //MpsJobRunnerPage.RunCreateOrderAndServiceRequestsCommandJob();
            MpsJobRunnerPage.RunConsumableOrderRequestsCommandJob();

        }

       
    }
}
