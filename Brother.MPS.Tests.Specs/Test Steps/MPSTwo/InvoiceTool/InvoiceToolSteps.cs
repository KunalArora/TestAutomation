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

        //[Then(@"I enter mono and colour print count")]
        //public void ThenIEnterMonoAndColourPrintCount()
        //{
        //    CurrentPage.As<InvoiceToolsPage>().NavigateToInvoiceToolPrinterPage();
        //    CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(1000, 1000, "0", 0);
        //    CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(1000, 1000, "1", 0);
        //    CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(1000, "2", 0);
        //    CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(1000, "3", 0);
        //    CurrentPage.As<InvoiceToolsPage>().CompleteInstallation();

        //}

        [Then(@"I enter mono and colour print count for a single device")]
        public void ThenIEnterMonoAndColourPrintCountForASingleDevice()
        {
            CurrentPage.As<InvoiceToolsPage>().NavigateToInvoiceToolPrinterPage();
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(1000, 1000, "0", 0);
            CurrentPage.As<InvoiceToolsPage>().CompleteInstallation();
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(2000, 2000, "0", 95);
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(2500, 2500, "0", 190);
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(3500, 3500, "0", 363);
            CurrentPage.As<InvoiceToolsPage>().CompleteInstallation();

        }

        [Then(@"I enter mono and colour print count")]
        public void ThenIEnterMonoAndColourPrintCount()
        {
            CurrentPage.As<InvoiceToolsPage>().NavigateToInvoiceToolPrinterPage();
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(1000, 1000, "0", 0);
            CurrentPage.As<InvoiceToolsPage>().CompleteInstallation();
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(1000, 1000, "1", 0);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(1000, "2", 0);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(1000, "3", 0);
          


            CurrentPage.As<InvoiceToolsPage>().CompleteInstallation();

        }

        [Then(@"I enter ""(.*)"" mono and ""(.*)"" colour print count")]
        public void ThenIEnterMonoAndColourPrintCount(int mono, int colour)
        {
            CurrentPage.As<InvoiceToolsPage>().NavigateToInvoiceToolPrinterPage();

            //Print count for invoice date 1
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono, colour, "0", 0);
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono, colour, "1", 0);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono, "2", 0);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono, "3", 0);

            CurrentPage.As<InvoiceToolsPage>().CompleteInstallation();

            //Print count for invoice date 2
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 1000, colour + 1000, "0", 95);
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 1000, colour + 1000, "1", 95);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono + 1000, "2", 95);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono + 1000, "3", 95);
           


            //Print count for invoice date 3
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 1500, colour + 1500, "0", 190);
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 1500, colour + 1500, "1", 190);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono + 1500, "2", 190);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono + 1500, "3", 190);
           


            //Print count for invoice date 4
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 2000, colour + 2000, "0", 280);
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 2000, colour + 2000, "1", 280);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono + 2000, "2", 280);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono + 2000, "3", 280);
          


            //Print count for invoice date 5
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 2500, colour + 2500, "0", 363);
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 2500, colour + 2500, "1", 363);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono + 2500, "2", 363);
            CurrentPage.As<InvoiceToolsPage>().EnterMonoDevicePrintCounts(mono + 2500, "3", 363);
          



        }


        [Then(@"I enter ""(.*)"" and ""(.*)"" print count for a single device")]
        public void ThenIEnterAndPrintCountForASingleDevice(int mono, int colour)
        {
           ThenIEnterSingleMonoAndColourPrintCount(mono, colour);
        }


        public void ThenIEnterSingleMonoAndColourPrintCount(int mono, int colour)
        {
            CurrentPage.As<InvoiceToolsPage>().NavigateToInvoiceToolPrinterPage();

            //Print count for invoice date 1
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono, colour, "0", 0);
           

            CurrentPage.As<InvoiceToolsPage>().CompleteInstallation();

            //Print count for invoice date 2
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 1000, colour + 1000, "0", 95);



            //Print count for invoice date 3
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 1500, colour + 1500, "0", 190);



            //Print count for invoice date 4
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 2000, colour + 2000, "0", 280);



            //Print count for invoice date 5
            CurrentPage.As<InvoiceToolsPage>().EnterColourDevicePrintCounts(mono + 2500, colour + 2500, "0", 363);




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
