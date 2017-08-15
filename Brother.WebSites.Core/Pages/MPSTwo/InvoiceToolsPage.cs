using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class InvoiceToolsPage : BasePage
    {
        private const string Mono = @"PrinterRepeater_PrinterPrintCountMonoTextBox_{0}";
        private const string Colour = @"PrinterRepeater_PrinterPrintCountColourTextBox_{0}";
        private const string DateTimeString = @"PrinterRepeater_PrinterPrintCountDateTextBox_{0}";
        private const string AddButton = @"PrinterRepeater_PrinterPrintCountAddButton_{0}";
        private const string PrintCountGrid = @"PrinterRepeater_PrinterPrintCountGridView_{0}";

        [FindsBy(How = How.CssSelector, Using = "#CountryDropDownList")]
        public IWebElement CountryDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"PrinterRepeater_PrinterPrintCountMonoTextBox_\"]")]
        public IList<IWebElement> MonoPrintCountsElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"PrinterRepeater_PrinterPrintCountColourTextBox_\"]")]
        public IList<IWebElement> ColourPrintCountsElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"PrinterRepeater_PrinterPrintCountAddButton_\"]")]
        public IList<IWebElement> AddPrintCountsElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"PrinterRepeater_PrinterPrintCountDateTextBox_\"]")]
        public IList<IWebElement> DateTimeFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#InvoiceDateTextBox")]
        public IWebElement InvoiceDateElement;
        [FindsBy(How = How.CssSelector, Using = "#RaiseInvoicesButton")]
        public IWebElement RaiseInvoiceButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#InvoiceGridView")]
        public IWebElement InvoiceGridElement;
        [FindsBy(How = How.CssSelector, Using = "a[href*=\"&type=customer\"]")]
        public IList<IWebElement> DownloadCustomerInvoiceElements;
        [FindsBy(How = How.CssSelector, Using = "a[href*=\"&type=dealer\"]")]
        public IList<IWebElement> DownloadDealerInvoiceElements;
        [FindsBy(How = How.CssSelector, Using = "a[href*=\"&type=bank\"]")]
        public IList<IWebElement> DownloadBankInvoiceElements;
        [FindsBy(How = How.CssSelector, Using = "th[scope=\"col\"]")]
        public IList<IWebElement> NumberOfColumnElements;
        [FindsBy(How = How.CssSelector, Using = "[name=\"RadioButtonListOptions\"][value=\"REFRESH\"]")]
        public IWebElement RefreshAllPrintCountsRadioButton;
        [FindsBy(How = How.CssSelector, Using = "[name=\"RadioButtonListOptions\"][value=\"REBUILDSERIAL\"]")]
        public IWebElement RefreshACertainPrintCountsRadioButton;
        [FindsBy(How = How.CssSelector, Using = "#inputSerialNumber")]
        public IWebElement SerialNumberInputField;
        [FindsBy(How = How.CssSelector, Using = "#buttonExecute")]
        public IWebElement RefreshPrintCountsButton;
        
        
        

        
        

        
        public void IsInvoiceToolPageDisplayed()
        {
            if(CountryDropdownElement == null)
                throw new Exception("Country dropdown is not displayed");

            AssertElementPresent(CountryDropdownElement, "Country dropdown");
        }

        public void SelectCountry(string country)
        {
            switch (country)
            {
                case "United Kingdom":
                    country = "UK";
                    break;
                case "Germany":
                    country = "Deutschland";
                    break;
            }
            SpecFlow.SetContext("CountrySelect", country);
            SelectFromDropdown(CountryDropdownElement, country);
        }

        public void EnterDateForInvoicing()
        {
            var todayDate = DateTime.Now;
            var dateString = todayDate.AddDays(390).ToString("ddMMyyyy"); 

            InvoiceDateElement.SendKeys(dateString + Keys.Tab);

            CompleteInstallation();

            WebDriver.Wait(DurationType.Second, 30);

        }

        public void DownloadCustomerInvoices()
        {
            foreach (var downloadInvoiceElement in DownloadCustomerInvoiceElements)
            {
                downloadInvoiceElement.Click();
                WebDriver.Wait(DurationType.Second, 3);
            }

            foreach (var downloadDealerInvoiceElement in DownloadDealerInvoiceElements)
            {
                downloadDealerInvoiceElement.Click();
                WebDriver.Wait(DurationType.Second, 3);
            }

            if (NumberOfColumnElements.Count != 9) return;
            foreach (var downloadBankInvoiceElement in DownloadBankInvoiceElements)
            {
                downloadBankInvoiceElement.Click();
                WebDriver.Wait(DurationType.Second, 3);
            }
        }

        public void IsInvoiceGenerated()
        {
            if (InvoiceGridElement == null)
                throw new Exception("Invoices were not raised");

            AssertElementPresent(InvoiceGridElement, "Invoices were not produced");
        }

        public void GenerateInvoices()
        {
            if (RaiseInvoiceButtonElement == null)
                throw new Exception("Cannot click on Raise Invoice Button Element");
            WebDriver.Wait(DurationType.Second, 30);
            RaiseInvoiceButtonElement.Click();
        }

        public void NavigateToInvoiceToolPrinterPage()
        {

            var env = Env();

            var firstPart = SetBrotherOnlineBaseUrl();
            firstPart = firstPart.Replace("cds", "cms");

            string subUrl;
            var newUrl = "/sitecore/admin/projects/mps2/invoicetools/printers.aspx?proposal={0}";
            var proposalId = SpecFlow.GetContext("SummaryPageContractId");
            newUrl = String.Format(newUrl, proposalId);

            if (env != null && (env.Equals("LOCAL") && IsUKSystem()))
            {
                subUrl = "http://online.brother.co.uk.local";
            }
            else
            {
                subUrl = firstPart;
            }


            var conUrl = subUrl + newUrl;

            Driver.Navigate().GoToUrl(conUrl);

        }

        private string Env()
        {
            var env = Environment.GetEnvironmentVariable("AutoTestComplimentEnv", EnvironmentVariableTarget.Machine);
            return env;
        }

        public void NavigateToInvoiceToolRaiseInvoicePage()
        {

            var env = Env();

            var firstPart = SetBrotherOnlineBaseUrl();
            firstPart = firstPart.Replace("cds", "cms");

            string subUrl;
            var newUrl = "/sitecore/admin/projects/mps2/invoicetools/raise.aspx?proposal={0}";
            var proposalId = SpecFlow.GetContext("SummaryPageContractId");
            var contractRef = SpecFlow.GetContext("ProposalId");
            newUrl = String.Format(newUrl, contractRef);

            if (env != null && (env.Equals("LOCAL") && IsUKSystem()))
            {
                subUrl = "http://online.brother.co.uk.local";
            }
            else
            {
                subUrl = firstPart;
            }


            var conUrl = subUrl + newUrl;

            Driver.Navigate().GoToUrl(conUrl);

        }

        public void NavigateToInvoiceToolViewInvoicesPage()
        {

            var firstPart = SetBrotherOnlineBaseUrl();
            firstPart = firstPart.Replace("cds", "cms");

            var env = Env();

            string subUrl;
            var newUrl = "/sitecore/admin/projects/mps2/invoicetools/view.aspx?proposal={0}";
            var proposalId = SpecFlow.GetContext("SummaryPageContractId");
            newUrl = String.Format(newUrl, proposalId);

            if (env != null && (env.Equals("LOCAL") && IsUKSystem()))
            {
                subUrl = "http://online.brother.co.uk.local";
            }
            else
            {
                subUrl = firstPart;
            }


            var conUrl = subUrl + newUrl;

            Driver.Navigate().GoToUrl(conUrl);

        }

        public void LaunchDailyPrintCountsPage()
        {

            var firstPart = SetBrotherOnlineBaseUrl();
            firstPart = firstPart.Replace("cds", "cms");

            var env = Env();

            string subUrl;
            const string newUrl = "http://online65.co.uk.cms.uat.brother.eu.com/sitecore/admin/projects/mps2/MedioDailyPrintCountProcessor.aspx";
            //var proposalId = SpecFlow.GetContext("SummaryPageContractId");
            //newUrl = String.Format(newUrl, proposalId);

            if (env != null && (env.Equals("LOCAL") && IsUKSystem()))
            {
                subUrl = "http://online.brother.co.uk.local";
            }
            else
            {
                subUrl = firstPart;
            }


            //var conUrl = subUrl + newUrl;

            const string conUrl = newUrl;

            Driver.Navigate().GoToUrl(conUrl);

        }

        public void RefreshPrintCounts()
        {
            RefreshACertainPrintCountsRadioButton.Click();
            var serial = SpecFlow.GetContext("UsedSerialNumber");
            ClearAndType(SerialNumberInputField, serial);
            WebDriver.Wait(DurationType.Second, 1);
            RefreshPrintCountsButton.Click();
        }

        

       public void EnterColourDevicePrintCounts(int mono, int colour, string row, int day)
        {
            var todayDate = TodayDate();
            var dateString = DateString(day, todayDate);
            var timeString = TimeString(todayDate);
            
           
           var monoField = String.Format(Mono, row);
            var colourField = String.Format(Colour, row);
            var dateTimeField = String.Format(DateTimeString, row);
            var addButtonString = String.Format(AddButton, row);
            var printGridString = String.Format(PrintCountGrid, row);


            var monoElement = Driver.FindElement(By.Id(monoField));
            var colourElement = Driver.FindElement(By.Id(colourField));
            var dateTimeElement = Driver.FindElement(By.Id(dateTimeField));
            var addButtonElement = Driver.FindElement(By.Id(addButtonString));
            var printGridElement = Driver.FindElement(By.Id(printGridString));

            ClearAndType(monoElement, mono.ToString());
            ClearAndType(colourElement, colour.ToString());
            dateTimeElement.SendKeys(dateString + timeString);

            addButtonElement.Click();

           WebDriver.Wait(DurationType.Second, 3);

            //AssertElementPresent(printGridElement, "Print count not added");


        }

        public void EnterMonoDevicePrintCounts(int mono, string row, int day)
        {
            var todayDate = TodayDate();
            var dateString = DateString(day, todayDate);
            var timeString = TimeString(todayDate);

            var monoField = String.Format(Mono, row);
            var dateTimeField = String.Format(DateTimeString, row);
            var addButtonString = String.Format(AddButton, row);


            var monoElement = Driver.FindElement(By.Id(monoField));
            var dateTimeElement = Driver.FindElement(By.Id(dateTimeField));
            var addButtonElement = Driver.FindElement(By.Id(addButtonString));


            ClearAndType(monoElement, mono.ToString());
            //ClearAndType(dateTimeElement, dateString);
            dateTimeElement.SendKeys(dateString + timeString);
            addButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 3);

        }

        private static string TimeString(DateTime todayDate)
        {
            var timeString = todayDate.ToString("HH:mm");
            return timeString;
        }

        private static string DateString(int day, DateTime todayDate)
        {
            var dayString = todayDate.AddDays(day).ToString("dd");
            var monthString = todayDate.AddDays(day).ToString("MM");
            var yearString = todayDate.AddDays(day).ToString("yyyy");
            var dateString = String.Format("{0}{1}00{2}", dayString, monthString, yearString);
            return dateString;
        }

        private static DateTime TodayDate()
        {
            var todayDate = DateTime.Now;
            return todayDate;
        }

        public void CompleteInstallation()
        {
            MpsJobRunnerPage.RunCompleteInstallationCommandJob(MpsUtil.CreatedProposal());
        }



    }
}
