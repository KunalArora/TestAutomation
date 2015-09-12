using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
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
            CurrentPage.As<FooterNavigationPage>().ClickPrinterFooterLink();
        }

        [Then(@"I am navigated to the printers page via the footer link")]
        public void ThenIAmNavigatedToPrintersPageViaFooterLink()
        {
            CurrentPage.As<FooterNavigationPage>().HasPrintersPageLoaded();
        }
        
        [Then(@"I click the scanners option under the products page footer")]
        public void ThenIClickTheScannersOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<FooterNavigationPage>().ClickScannerFooterLink();
        }
        
        [Then(@"I am navigated to the scanners page")]
        public void ThenIAmNavigatedToTheScannersPage()
        {
            CurrentPage.As<FooterNavigationPage>().HasScannersPageLoaded();
        }
        
        [Then(@"I click the label printers option under the products page footer")]
        public void ThenIClickTheLabelPrintersOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<FooterNavigationPage>().ClickLabelPrinterFooterLink();
        }
        
        [Then(@"I am navigated to the label printers page")]
        public void ThenIAmNavigatedToTheLabelPrintersPage()
        {
            CurrentPage.As<FooterNavigationPage>().HasLabelPrintersPageLoaded();
        }
        
        [Then(@"I click the fax machines option under the products page footer")]
        public void ThenIClickTheFaxMachinesOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<FooterNavigationPage>().ClickFaxMachinesFooterLink();
        }
        
        [Then(@"I am navigated to the fax machines page")]
        public void ThenIAmNavigatedToTheFaxMachinesPage()
        {
            CurrentPage.As<FooterNavigationPage>().HasFaxMachinesPageLoaded();
        }
        
        [Then(@"I click the supplies and accessories option under the products page footer")]
        public void ThenIClickTheSuppliesAndAccessoriesOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<FooterNavigationPage>().ClickSuppliesAndAccessoriesLink();
        }
        
        [Then(@"I am navigated to the supplies and accessories page")]
        public void ThenIAmNavigatedToTheSuppliesAndAccessoriesPage()
        {
            CurrentPage.As<FooterNavigationPage>().HasSuppliesAndAccessoriesPageLoaded();
        }

        [Then(@"I click the latest promotions option under the products page footer")]
        public void ThenIClickTheLatestPromotionsOptionUnderTheProductsPageFooter()
        {
            CurrentPage.As<FooterNavigationPage>().ClickLatestPromotionsLink();
        }

        [Then(@"I am navigated to the latest promotions page")]
        public void ThenIAmNavigatedToTheLatestPromotionsPage()
        {
            CurrentPage.As<FooterNavigationPage>().HasLatestPromotionsPageLoaded();
        }


    }
}
