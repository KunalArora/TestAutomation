using System;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateProductsPage : BasePage
    {
        public static string URL = "/mps/dealer/proposals/create/products";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private IWebElement FaxCheckboxElement()
        {
            string element = "input[data-filter-for=\"fax\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement ScannerCheckboxElement()
        {
            string element = "input[data-filter-for=\"scanner\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement DuplexCheckboxElement()
        {
            string element = "input[data-filter-for=\"duplex\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement AdditionalTrayCheckboxElement()
        {
            string element = "input[data-filter-for=\"additional-tray\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement A4CheckboxElement()
        {
            string element = "input[data-filter-for=\"a4\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement A3CheckboxElement()
        {
            string element = "input[data-filter-for=\"a3\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement MonoCheckboxElement()
        {
            string element = "input[data-filter-for=\"mono\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement ColourCheckboxElement()
        {
            string element = "input[data-filter-for=\"colour\"]";

            return GetElementByCssSelector(element);
        }

        public void TickRelineSearchFax()
        {
            IWebElement element = FaxCheckboxElement();

            WebDriver.Wait(Helper.DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchScanner()
        {
            IWebElement element = ScannerCheckboxElement();

            WebDriver.Wait(Helper.DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchDuplex()
        {
            IWebElement element = DuplexCheckboxElement();

            WebDriver.Wait(Helper.DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchAdditionalTray()
        {
            IWebElement element = AdditionalTrayCheckboxElement();

            WebDriver.Wait(Helper.DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchA4()
        {
            IWebElement element = A4CheckboxElement();

            WebDriver.Wait(Helper.DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchA3()
        {
            IWebElement element = A3CheckboxElement();

            WebDriver.Wait(Helper.DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchMono()
        {
            IWebElement element = MonoCheckboxElement();

            WebDriver.Wait(Helper.DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchColour()
        {
            IWebElement element = ColourCheckboxElement();

            WebDriver.Wait(Helper.DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        private IList<IWebElement> DisplayedPrintersElements()
        {
            string element = ".mps-product-configuration";

            return GetElementsByCssSelector(element);
        }

        public void IsAllPrintersHaveFaxFacility()
        {
            IList<IWebElement> PrinterElements = DisplayedPrintersElements();

            // @TODO: change xpath into cssselector
            IList<IWebElement> FaxElements = Driver.FindElements(By.XPath("//span[text()='Fax']"));
            TestCheck.AssertIsEqual(PrinterElements.Count, FaxElements.Count, "DisplayedPrintersElements number is not equal to FaxElements one ");
        }

        public void IsAllPrintersHaveScanFacility()
        {
            IList<IWebElement> PrinterElements = DisplayedPrintersElements();

            // @TODO: change xpath into cssselector
            IList<IWebElement> ScanElements = Driver.FindElements(By.XPath("//span[text()='Scan']"));
            TestCheck.AssertIsEqual(PrinterElements.Count, ScanElements.Count, "DisplayedPrintersElements number is not equal to ScanElements one ");
        }

        public void IsAllPrintersHaveDuplexFacility()
        {
            IList<IWebElement> PrinterElements = DisplayedPrintersElements();

            // @TODO: change xpath into cssselector
            IList<IWebElement> DuplexElements = Driver.FindElements(By.XPath("//span[text()='Duplex']"));
            TestCheck.AssertIsEqual(PrinterElements.Count, DuplexElements.Count, "DisplayedPrintersElements number is not equal to DuplexElements one ");
        }

        public void IsAllPrintersHaveAdditionalTrayFacility()
        {
            IList<IWebElement> PrinterElements = DisplayedPrintersElements();

            // @TODO: change xpath into cssselector
            IList<IWebElement> AdditionalTrayElements = Driver.FindElements(By.XPath("//span[text()='Additional Tray']"));
            TestCheck.AssertIsEqual(PrinterElements.Count, AdditionalTrayElements.Count, "DisplayedPrintersElements number is not equal to AdditionalTrayElements one ");
        }

        public void IsAllPrintersHaveA4Facility()
        {
            IList<IWebElement> PrinterElements = DisplayedPrintersElements();

            // @TODO: change xpath into cssselector
            IList<IWebElement> A4Elements = Driver.FindElements(By.XPath("//span[text()='A4']"));
            TestCheck.AssertIsEqual(PrinterElements.Count, A4Elements.Count, "DisplayedPrintersElements number is not equal to A4Elements one ");
        }

        public void IsAllPrintersHaveA3Facility()
        {
            IList<IWebElement> PrinterElements = DisplayedPrintersElements();

            // @TODO: change xpath into cssselector
            IList<IWebElement> A3Elements = Driver.FindElements(By.XPath("//span[text()='A3']"));
            TestCheck.AssertIsEqual(PrinterElements.Count, A3Elements.Count, "DisplayedPrintersElements number is not equal to A3Elements one ");
        }

        public void IsAllPrintersHaveMonoFacility()
        {
            // @TODO: not implement
        }

        public void IsAllPrintersHaveColourFacility()
        {
            // @TODO: not implement
        }
    }
}
