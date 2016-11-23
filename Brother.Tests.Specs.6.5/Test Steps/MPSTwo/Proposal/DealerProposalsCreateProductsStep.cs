using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class DealerProposalsCreateProductsStep : BaseSteps
    {
        [Then(@"all the margin set above should be displayed in the right fields")]
        public void ThenPartOfMarginSetAboveShouldBeDisplayedInTheRightFields()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().StrictVerifyMarginFieldValues();
        }

        [When(@"I check Fax checkbox")]
        public void WhenICheckFaxCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchFax();
        }

        [Then(@"All printers that have Fax facility are returned")]
        public void ThenAllPrintersThatHaveFaxFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveFaxFacility();
        }

        [When(@"I check Scanner checkbox")]
        public void WhenICheckScannerCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchScanner();
        }

        [Then(@"All printers that have Scanner facility are returned")]
        public void ThenAllPrintersThatHaveScannerFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveScanFacility();
        }

        [When(@"I check Duplex checkbox")]
        public void WhenICheckDuplexCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchDuplex();
        }

        [Then(@"All printers that have Duplex facility are returned")]
        public void ThenAllPrintersThatHaveDuplexFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveDuplexFacility();
        }

        [When(@"I check Additional Tray checkbox")]
        public void WhenICheckAdditionalTrayCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchAdditionalTray();
        }

        [Then(@"All printers that have Additional Tray facility are returned")]
        public void ThenAllPrintersThatHaveAdditionalTrayFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveAdditionalTrayFacility();
        }

        [When(@"I check A4 checkbox")]
        public void WhenICheckA4Checkbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchA4();
        }

        [Then(@"All printers that have A4 facility are returned")]
        public void ThenAllPrintersThatHaveA4FacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveA4Facility();
        }

        [When(@"I check A3 checkbox")]
        public void WhenICheckA3Checkbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchA3();
        }

        [Then(@"All printers that have A3 facility are returned")]
        public void ThenAllPrintersThatHaveA3FacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveA3Facility();
        }

        [When(@"I check Mono checkbox")]
        public void WhenICheckMonoCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchMono();
        }

        [Then(@"All printers that have Mono facility are returned")]
        public void ThenAllPrintersThatHaveMonoFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveMonoFacility();
        }

        [When(@"I check Colour checkbox")]
        public void WhenICheckColourCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchColour();
        }

        [Then(@"All printers that have Colour facility are returned")]
        public void ThenAllPrintersThatHaveColourFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveColourFacility();
        }

        [When(@"I check Fax and Scanner checkbox")]
        public void WhenICheckFaxAndScannerCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchFax();
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchScanner();
        }

        [Then(@"All printers that have Fax and Scanner facility are returned")]
        public void ThenAllPrintersThatHaveFaxAndScannerFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveFaxFacility();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveScanFacility();
        }

        [When(@"I check Duplex and Colour checkbox")]
        public void WhenICheckDuplexAndColourCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchDuplex();
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchColour();
        }

        [Then(@"All printers that have Duplex and Colour facility are returned")]
        public void ThenAllPrintersThatHaveDuplexAndColourFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveDuplexFacility();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveColourFacility();
        }

        [When(@"I type in ""(.*)"" into the top RHS free-text filter")]
        public void WhenITypeInIntoTheTopRHSFree_TextFilter(string model)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TypeIntoRHSFreeTextFilter(model);
        }

        [Then(@"All printers that contain ""(.*)"" is returned")]
        public void ThenAllPrintersThatContainIsReturned(string model)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersReturnedThatSearched(model);
        }

        [Then(@"all products are displayed as a flat list with no images")]
        [When(@"the products are displayed as Flat List")]
        public void ThenAllProductsAreDisplayedAsAFlatListWithNoImages()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyThatAllProductsDisplayedAsAFlatListWithNoImages();
        }

        [When(@"I changed the Product view to with images")]
        public void WhenIChangedTheProductViewToFlatList()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().ChangeProductViewToWithImages();
        }

        [Then(@"all products are displayed with images")]
        public void ThenAllProductsAreDisplayedWithImages()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyThatAllProductsDisplayedAsAWithImages();
        }

        [Then(@"this change to dealer margin is reverted to the original value")]
        public void ThenThisChangeToDealerMarginIsRevertedToTheOriginalValue()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsDealerMarginRevertedToTheOriginalValue();
        }

        [Then(@"this change to dealer margin is retained")]
        public void ThenThisChangeToDealerMarginIsRetained()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsDealerMarginRetainedByDealerAdminDefaultMargin();
        }

        [When(@"I change device installation type")]
        public void WhenIChangeDeviceInstallationType()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().ChangeDeviceInstallationType();
        }

        [Then(@"installation SRP value should change")]
        public void ThenInstallationSRPValueShouldChange()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyThatInstallationSrpValueChange();
        }

        [Then(@"the printers ""(.*)"" enabled in Local Office Admin are displayed on product screen")]
        public void ThenThePrintersEnabledInLocalOfficeAdminAreDisplayedOnProductScreen(string model)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsModelFound(model);
        }

        [Then(@"the printers ""(.*)"" disabled in Local Office Admin are not displayed on product screen")]
        [Then(@"the printers ""(.*)"" enabled in Local Office Admin are not displayed on product screen")]
        public void ThenThePrintersDisabledInLocalOfficeAdminAreNotDisplayedOnProductScreen(string model)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotModelFound(model);
        }

        [Then(@"all the SRP are not editable")]
        public void ThenAllTheSRPAreNotEditable()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllSRPNotEditable();
        }

        [Then(@"the QTY for Delivery Cost, Installation Cost and Service Pack are not editable")]
        public void ThenTheQTYForDeliveryCostInstallationCostAndServicePackAreNotEditable()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsDeliveryQuantityNotEditable();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsInstallationQuantityNotEditable();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsServicepackQuantityNotEditable();
        }

        [Then(@"a change in product quantity affect the product TotalPrice")]
        public void ThenAChangeInProductQuantityAffectTheProductTotalPrice()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity("4");
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyThatProductQuantityElementChanged();
        }

        [Then(@"on product page all the device have full detail screen")]
        public void ThenOnProductPageAllTheDeviceHaveFullDetailScreen()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsFullDeviceScreenDisplayed();
        }

        [Then(@"on product page all the devices have reduced detail screen")]
        public void ThenOnProductPageAllTheDevicesHaveReducedDetailScreen()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsReducedDeviceScreenDisplayed();
        }

        [Then(@"on product page QTY for accessories are default to zero")]
        [When(@"on product page all the accessories all left with zero QTY")]
        public void ThenOnProductPageQTYForAccessoriesAreDefaultToZero()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsQtyForAccessoriesAreDefaultToZero();
        }

        [Then(@"the default total for all accessories are defaulted to zero")]
        public void ThenTheDefaultTotalForAllAccessoriesAreDefaultedToZero()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsTotalForAllAccessoriesAreDefaultToZero();
        }

        [When(@"enter a quantity value into an accessory field")]
        public void WhenEnterAQuantityValueIntoAnAccessoryField()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().FillProductDetails();
        }

        [When(@"I change the Unit Cost of an item")]
        public void WhenIChangeTheUnitCostOfAnItem()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductCostPrice("10");
        }

        [When(@"I change the Unit Price of an item")]
        public void WhenIChangeTheUnitPriceOfAnItem()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductSellPrice("10");
        }

        [When(@"I change the Margin of an item whose Unit Cost bigger than zero")]
        public void WhenIChangeTheMarginOfAnItemWhoseUnitCost()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterModelUnitCost();
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductMargin("7");
        }

        [When(@"I change the Margin of an item whose Unit Cost is equal to zero")]
        public void WhenIChangeTheMarginOfAnItemWhoseUnitCostIsEqualToZero()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterDeliveryMargin("7");
        }

        [When(@"I change all the margin")]
        public void WhenIChangeAllTheMargin()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterAllMarginRandomly();
        }

        [Then(@"the Unit Price changed accordingly")]
        public void ThenTheUnitPriceChangedAccordingly()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductUnitPriceChanged();
        }

        [Then(@"the Margin changes accordingly")]
        public void ThenTheMarginChangesAccordingly()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductMarginChanged();
        }

        [Then(@"the associated margin does not changed")]
        public void ThenProductdMarginDoesNotChanged()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotProductMarginChanged();
        }

        [Then(@"the associated Unit Cost dos not changed")]
        public void ThenTheAssociatedUnitCostDosNotChanged()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotProductUnitCostChanged();
        }

        [Then(@"the Unit Price and Unit Cost does not change")]
        public void ThenTheUnitPriceAndUnitCostDoesNotChange()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotDeliveryCostPriceChanged();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotDeliverySellPriceChanged();
        }

        [Then(@"on product page the sum of the Total Price is equal to the Grand Total Price displayed")]
        public void ThenOnProductPageTheSumOfTheTotalPriceIsEqualToTheGrandTotalPriceDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsGrandTotalPriceCorrect();
        }

        [Then(@"on product page the Total Price is the product of QTY and Unit Price")]
        public void ThenOnProductPageTheTotalPriceIsTheProductOfQTYAndUnitPrice()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsTheTotalPriceTheProductOfQTYAndUnitPrice();
        }

        [When(@"I change the Installation Pack Unit Cost displayed to a value lower than the displayed Unit Cost")]
        public void WhenIChangeTheInstallationPackUnitCostDisplayedToAValueLowerThanTheDisplayedUnitCost()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterModelUnitCost();
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterInstallationPackCostPriceLessThanDefault();
        }

        [When(@"""(.*)"" device screen is displayed")]
        public void WhenDeviceScreenIsDisplayed(string option)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyTypeOfDeviceScreenDisplayed(option);
        }

        [When(@"I add the device that changed the default values")]
        public void WhenIChangeTheDefaultValuesOfTheDevice()
        {
            if (!(CurrentPage.As<DealerProposalsCreateProductsPage>().IsGermanSystem()
                && CurrentPage.As<DealerProposalsCreateProductsPage>().GetContractType() == "Easy Print Pro & Service"))
            {
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity("1");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterModelUnitCost();
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionsQuantity0("1");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionCostPrice();
            }
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyProductAdditionConfirmationMessage();
        }

        [When(@"I accept the default values of the device")]
        public void WhenIAcceptTheDefaultValuesOfTheDevice()
        {
            if (!(CurrentPage.As<DealerProposalsCreateProductsPage>().IsGermanSystem()
                && CurrentPage.As<DealerProposalsCreateProductsPage>().GetContractType() == "Easy Print Pro & Service"))
            {
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity("1");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterModelUnitCost();
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionsQuantity0("1");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionCostPrice(); 
            }
            
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyProductAdditionConfirmationMessage();
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().MoveToClickPriceScreen();
        }

        [When(@"I enter some values for the device")]
        public void WhenIEnterSomeValuesOfTheDevice()
        {
            if (!(CurrentPage.As<DealerProposalsCreateProductsPage>().IsGermanSystem()
                && CurrentPage.As<DealerProposalsCreateProductsPage>().GetContractType() == "Easy Print Pro & Service"))
            {
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity("1");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterModelUnitCost();
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionsQuantity0("1");
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionCostPrice();
            }

            
            //CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyProductAdditionConfirmationMessage();
            //NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().MoveToClickPriceScreen();
        }

        [When(@"I enter incorrect installation cost of ""(.*)""")]
        public void WhenIEnterIncorrectInstallationCost(string value)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterInstallationPackCostPrice(value);
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
        }

        [Then(@"error message displayed contains the ""(.*)"" of the specified country")]
        public void ThenErrorMessageDisplayedContainsTheCurrencyOfTheSpecifiedCountry(string currency)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsErrorMessageDisplayed();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsCurrencyInErrorMessageCorrect(currency);
        }
        
        [When(@"I display ""(.*)"" device screen")]
        [Then(@"I display ""(.*)"" device screen")]
        public void WhenIDisplayDeviceScreen(string printer)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductScreenTextDisplayed();
            CurrentPage.As<DealerProposalsCreateProductsPage>().ClickOnAPrinter(printer);
            CurrentPage.As<DealerProposalsCreateProductsPage>().StoreDefaultProductConfiguration();
        }

        [When(@"I changed the Margin on any field to (.*)")]
        public void WhenIChangedTheMarginOnAnyFieldTo(string percent)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterDeliveryMargin(percent);
        }

        [When(@"I changed a Unit Price (.*) so that Margin is 100")]
        public void WhenIChangedAUnitPriceSoThatMarginIs(string percent)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterDeliverySellPrice(percent);
        }

        [When(@"I Click Add to Proposal button")]
        public void WhenIClickAddToProposalButton()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
        }

        [When(@"I Add the device to Proposal")]
        public void WhenIAddTheDeviceToProposal()
        {
            When(@"I Click Add to Proposal button");
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().NextButtonClick();
        }

        [Then(@"Add to proposal button become grayout")]
        public void ThenAddToProposalButtonBecomeGrayout()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAddToProposalButtonGrayout();
        }

        [Then(@"InstallationPackUnitCostLessThanError is displayed")]
        public void ThenInstallationPackUnitCostLessThanErrorIsDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsInstallationPackUnitCostLessThanErrorDisplayed();
        }

        [Then(@"the product can not be added to the proposal")]
        public void ThenTheProductCanNotBeAddedToTheProposal()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotTheProductAddedToTheProposal();
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().MoveToClickPriceScreen();
        }

        [When(@"enter a quantity of ""(.*)"" for model")]
        public void WhenEnterAQuantityOfForModel(string quantity)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity(quantity);
        }

        [When(@"enter a quantity of ""(.*)"" for accessory")]
        public void WhenEnterAQuantityOfForAccessory(string quantity)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionsQuantity0(quantity);
        }

        [When(@"I confirm the values entered for the device")]
        public void WhenIconfirmTheValuesEntereForTheDevice()
        {
            if (!(CurrentPage.As<DealerProposalsCreateProductsPage>().IsGermanSystem()
                && CurrentPage.As<DealerProposalsCreateProductsPage>().GetContractType() == "Easy Print Pro & Service"))
            {
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterModelUnitCost();
            }
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
            //CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyProductAdditionConfirmationMessage();
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().MoveToClickPriceScreen();
        }

        [When(@"I move to Click Price page")]
        public void WhenIMoveToClickPricePage()
        {
            if (!(CurrentPage.As<DealerProposalsCreateProductsPage>().IsGermanSystem()
                && CurrentPage.As<DealerProposalsCreateProductsPage>().GetContractType() == "Easy Print Pro & Service"))
            {
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterModelUnitCost();
            }
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().MoveToClickPriceScreenWithButton();
        }


        [When(@"I redisplay ""(.*)"" device screen")]
        [Then(@"I redisplay ""(.*)"" device screen")]
        public void WhenIRedisplayDeviceScreen(string printer)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().ClickOnAPrinter(printer);
            CurrentPage.As<DealerProposalsCreateProductsPage>().StoreExtraValuesOnProductPage();
        }

        [When(@"enter a quantity of ""(.*)"" for accessory for ""(.*)""")]
        public void WhenEnterAQuantityOfForAccessoryFor(string quantity, string printer)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().ClickOnAPrinter(printer);
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity(quantity);
            if (!(CurrentPage.As<DealerProposalsCreateProductsPage>().IsGermanSystem()
                && CurrentPage.As<DealerProposalsCreateProductsPage>().GetContractType() == "Easy Print Pro & Service"))
            {
                
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterModelUnitCost();
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionCostPrice();
                CurrentPage.As<DealerProposalsCreateProductsPage>().EnterOptionsQuantity0(quantity);
            }
           
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
        }

        [When(@"I edit Products Tab and ""(.*)"" in Proposal")]
        public void WhenIEditProductsTabAndInProposal(string action)
        {
            EditProducts(action);
            GoThrowClickPriceTab();
        }

        public void EditProducts()
        {
            var page = CurrentPage.As<DealerProposalsCreateProductsPage>();
            NextPage = page.EditAndUpdateExistingProducts(CurrentDriver);
        }

        public void EditProducts(string action)
        {
            var page = CurrentPage.As<DealerProposalsCreateProductsPage>();

            switch (action)
            {
                case "Add":
                    page.AddNewProduct(CurrentDriver);
                    NextPage = page.GoNextPage(CurrentDriver);

                    break;
                case "Remove":
                    page.AddNewProduct(CurrentDriver);
                    page.RemoveOldProduct(CurrentDriver);
                    NextPage = page.GoNextPage(CurrentDriver);
                    break;
            }
        }

        public void GoThrowClickPriceTab(bool fillVolume = false)
        {
            var page = CurrentPage.As<DealerProposalsCreateClickPricePage>();
            NextPage = page.ForceGoThrowThisTab(CurrentDriver, fillVolume);
        }
    }
}
