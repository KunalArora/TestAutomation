using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.InvoiceTool
{
    [Binding]
    public class InvoiceToolSpteps : BaseSteps
    {
        [Then(@"I navigate to the Invoice tool homepage")]
        public void ThenINavigateToTheInvoiceToolHomepage()
        {
            NextPage = CurrentPage.As<HomePage>().NavigateToInvoiceToolsPage();
            CurrentPage.As<InvoiceToolsPage>().IsInvoiceToolPageDisplayed();
        }

        [Then(@"I select ""(.*)"" of interest")]
        public void ThenISelectOfInterest(string country)
        {
            CurrentPage.As<InvoiceToolsPage>().SelectCountry(country);

        }

        [Then(@"I enter mono and colour print count")]
        public void ThenIEnterMonoAndColourPrintCount()
        {
            CurrentPage.As<InvoiceToolsPage>().NavigateToInvoiceToolPrinterPage();
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(1000, 1000, "0", 0);
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(1000, 1000, "1", 0);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(1000, "2", 0);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(1000, "3", 0);
            CurrentPage.As<InvoiceToolsPage>().CompleteInstallation();

        }

        [Then(@"I generate invoices for the contract above")]
        public void ThenIGenerateInvoicesForTheContractAbove()
        {
            CurrentPage.As<InvoiceToolsPage>().NavigateToInvoiceToolRaiseInvoicePage();
            CurrentPage.As<InvoiceToolsPage>().EnterDateForInvoicing();
            CurrentPage.As<InvoiceToolsPage>().GenerateInvoices();
            CurrentPage.As<InvoiceToolsPage>().IsInvoiceGenerated();
        }

        [Then(@"I download customer invoices pdf")]
        public void ThenIDownloadCustomerInvoicesPdf()
        {
            CurrentPage.As<InvoiceToolsPage>().DownloadCustomerInvoices();
        }



    }
}
