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
        private string AddButton = @"PrinterRepeater_PrinterPrintCountAddButton_{0}";

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
            SelectFromDropdown(CountryDropdownElement, country);
        }

        public void NavigateToInvoiceToolPrinterPage()
        {
            var subUrl = Driver.Url;
            var newUrl = "test/mps2/invoicetools/printers.aspx?proposal={0}";
            var proposalId = SpecFlow.GetContext("SummaryPageContractId");
            newUrl = String.Format(newUrl, proposalId);
            subUrl = subUrl.Substring(0, 31);

            var conUrl = subUrl + newUrl;

            Driver.Navigate().GoToUrl(conUrl);

        }

        public void EnterColourDevicePrintCounts(int mono, int colour)
        {
            foreach (var item in MonoPrintCountsElement)
            {
                ClearAndType(item, mono.ToString());
                mono += 500;
            }

            foreach (var item in ColourPrintCountsElement)
            {
                ClearAndType(item, colour.ToString());
                colour += 500;
            }

            
        }

        public void EnterColourDevicePrintCounts(int mono, int colour, string row, int day)
        {
            var todayDate = DateTime.Now;
            var dateString = todayDate.AddDays(day).ToString("ddMMyyyy");
            var timeString = todayDate.ToString("HH:mm");
            var monoField = String.Format(Mono, row);
            var colourField = String.Format(Colour, row);
            var dateTimeField = String.Format(DateTimeString, row);
            var addButtonString = String.Format(AddButton, row);


            var monoElement = Driver.FindElement(By.Id(monoField));
            var colourElement = Driver.FindElement(By.Id(colourField));
            var dateTimeElement = Driver.FindElement(By.Id(dateTimeField));
            var addButtonElement = Driver.FindElement(By.Id(addButtonString));
            

            ClearAndType(monoElement, mono.ToString());
            ClearAndType(colourElement, colour.ToString());
//            ClearAndType(dateTimeElement, dateString);
            dateTimeElement.SendKeys(dateString + " " + timeString);
           // dateTimeElement.SendKeys();
            addButtonElement.Click();


        }

        public void EnterMonoDevicePrintCounts(int mono, string row, int day)
        {
            var todayDate = DateTime.Now;
            var dateString = todayDate.AddDays(day).ToString("ddMMyyyy HHmm");
            var monoField = String.Format(Mono, row);
            var dateTimeField = String.Format(DateTimeString, row);
            var addButtonString = String.Format(AddButton, row);


            var monoElement = Driver.FindElement(By.Id(monoField));
            var dateTimeElement = Driver.FindElement(By.Id(dateTimeField));
            var addButtonElement = Driver.FindElement(By.Id(addButtonString));


            ClearAndType(monoElement, mono.ToString());
            //ClearAndType(dateTimeElement, dateString);
            dateTimeElement.SendKeys(dateString);
            addButtonElement.Click();


        }

        public void CompleteInstallation()
        {
            MpsJobRunnerPage.RunCompleteInstallationCommandJob();
        }



    }
}
