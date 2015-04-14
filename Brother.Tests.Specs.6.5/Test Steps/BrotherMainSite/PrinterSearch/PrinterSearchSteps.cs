using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite;
using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.SuppliesAndAccessories.Printers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherMainSite.PrinterSearch
{
    [Binding]
    public class PrinterSearchSteps : BaseSteps
    {
        [Given(@"I have clicked on Printers")]
        public void GivenIHaveClickedOnPrinters()
        {
            CurrentPage.As<MainSiteHomePage>().IsPrintersLinkAvailable();
            NextPage = CurrentPage.As<MainSiteHomePage>().ClickPrintersLink();
        }

        [Then(@"I should see the Printers page")]
        public void ThenIShouldSeeThePrintersPage()
        {
            CurrentPage.As<PrintersPage>().IsViewOurPrinterRangeButtonAvailable();
        }

        [Then(@"If I click on View All Printers button")]
        public void ThenIfIClickOnViewAllPrintersButton()
        {
            NextPage = CurrentPage.As<PrintersPage>().ViewOurPrinterRangeButtonClick();
        }

        [Then(@"I should see the All Printers page")]
        public void ThenIShouldSeeTheAllPrintersPage()
        {
            CurrentPage.As<AllPrintersPage>().IsViewOurPrinterRangeButtonAvailable();
        }

        [Then(@"I click on View Our All-in-one Printers button")]
        public void ThenIClickOnViewOurAll_In_OnePrintersButton()
        {
            NextPage = CurrentPage.As<AllPrintersPage>().ViewAllInOnePrinterRangeButtonClick();
        }

        [Then(@"I should see a list of All in one printers")]
        public void ThenIShouldSeeAListOfAllInOnePrinters()
        {
            Assert.AreEqual(true,
                CurrentPage.As<AllInOnePrintersPage>().WaitForPrinterSearchResults("matching products"));
        }

        [Then(@"I click on View Our Laser Printers button")]
        public void ThenIClickOnViewOurLaserPrintersButton()
        {
            CurrentPage.As<AllPrintersPage>().IsViewLaserPrinterRangeButtonAvailable();
            NextPage = CurrentPage.As<AllPrintersPage>().ViewLaserPrinterRangeButtonClick();
        }

        [Then(@"I should see a list of Laser printers")]
        public void ThenIShouldSeeAListOfLaserPrinters()
        {
            Assert.Greater(CurrentPage.As<LaserPrintersPage>().WaitForPrinterSearchResults(), 0, "Printer search returned zero");
        }

        [Then(@"I can validate that each printer is a valid printer")]
        public void ThenICanValidateThatEachPrinterIsAValidPrinter()
        {
            Assert.AreEqual(false, CurrentPage.As<LaserPrintersPage>().ValidatePrinters(), "Validating Printers (Main Languages)");
        }

        [Then(@"I can validate that each printer for Spain and Portugal is a valid printer")]
        public void ThenICanValidateThatEachPrinterForSpainAndPortugalIsAValidPrinter()
        {
            Assert.AreEqual(false, CurrentPage.As<LaserPrintersPage>().ValidatePrintersSpainPortugal(), "Validating Printers (Spain and Portugal Languages)");
        }

        //[Then(@"I can validate that each printer for Russia is a valid printer")]
        //public void ThenICanValidateThatEachPrinterForRussiaIsAValidPrinter()
        //{
        //    Assert.AreEqual(false, CurrentPage.As<LaserPrintersPage>().ValidatePrintersRussia(), "Validating Printers (Russian Language)");
        //}

    }
}
