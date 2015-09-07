using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages8._0.BrotherMainSite;
using TechTalk.SpecFlow;
using MainSiteHomePage = Brother.WebSites.Core.Pages.BrotherMainSite.MainSiteHomePage;

namespace Brother.Tests.Specs._80.Test_Steps.BrotherMainSite.FooterNavigation
{
    [Binding]
    public class ProductsFooterSteps: BaseSteps
    {
        [Then(@"I click the printers option under the products page footer")]
        public void ThenIClickThePrintersOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<MainSiteHomePage>().ClickPrinterFooterLink();
        }

        [Then(@"I am navigated to the printers page via the footer link")]
        public void ThenIAmNavigatedToPrintersPageViaFooterLink()
        {
            CurrentPage.As<MainSiteHomePage>().HasPrintersPageLoaded();
        }
        
        [Then(@"I click the scanners option under the products page footer")]
        public void ThenIClickTheScannersOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<MainSiteHomePage>().ClickScannerFooterLink();
        }
        
        [Then(@"I am navigated to the scanners page")]
        public void ThenIAmNavigatedToTheScannersPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasScannersPageLoaded();
        }
        
        [Then(@"I click the label printers option under the products page footer")]
        public void ThenIClickTheLabelPrintersOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<MainSiteHomePage>().ClickLabelPrinterFooterLink();
        }
        
        [Then(@"I am navigated to the label printers page")]
        public void ThenIAmNavigatedToTheLabelPrintersPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasLabelPrintersPageLoaded();
        }
        
        [Then(@"I click the fax machines option under the products page footer")]
        public void ThenIClickTheFaxMachinesOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<MainSiteHomePage>().ClickFaxMachinesFooterLink();
        }
        
        [Then(@"I am navigated to the fax machines page")]
        public void ThenIAmNavigatedToTheFaxMachinesPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasFaxMachinesPageLoaded();
        }
        
        [Then(@"I click the supplies and accessories option under the products page footer")]
        public void ThenIClickTheSuppliesAndAccessoriesOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<MainSiteHomePage>().ClickSuppliesAndAccessoriesLink();
        }
        
        [Then(@"I am navigated to the supplies and accessories page")]
        public void ThenIAmNavigatedToTheSuppliesAndAccessoriesPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasSuppliesAndAccessoriesPageLoaded();
        }

        [Then(@"I click the latest promotions option under the products page footer")]
        public void ThenIClickTheLatestPromotionsOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<MainSiteHomePage>().ClickLatestPromotionsLink();
        }

        [Then(@"I am navigated to the latest promotions page")]
        public void ThenIAmNavigatedToTheLatestPromotionsPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasLatestPromotionsPageLoaded();
        }


    }
}
