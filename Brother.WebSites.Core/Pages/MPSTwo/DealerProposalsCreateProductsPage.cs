﻿using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateProductsPage : BasePage,  IPageObject
    {

        private const string _validationElementSelector = "div.media-body.mps-product-configuration";
        private const string _url = "/mps/dealer/proposals/create/products";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        
        #region ViewModels

        [DataContract]
        public class ItemDetail
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string SRP { get; set; }
            [DataMember]
            public string Quantity { get; set; }
            [DataMember]
            public string UnitCost { get; set; }
            [DataMember]
            public string Margin { get; set; }
            [DataMember]
            public string UnitPrice { get; set; }
            [DataMember]
            public string TotalPrice { get; set; }
        }

        [DataContract]
        public class ProductDetail
        {
            [DataMember]
            public string TotalPrice { get; set; }
            [DataMember]
            public ItemDetail Model { get; set; }
            [DataMember]
            public ItemDetail LowerTray { get; set; }
            [DataMember]
            public ItemDetail Usb2Cable { get; set; }
            [DataMember]
            public ItemDetail Delivery { get; set; }
            [DataMember]
            public ItemDetail Brother { get; set; }
            [DataMember]
            public ItemDetail Dealer { get; set; }
            [DataMember]
            public ItemDetail MpsServicePack { get; set; }
        }
        #endregion 

        private const string flatItemsIdentifier = @".mps-product-group";

        public static string URL = "/mps/dealer/proposals/create/products";
        private const string paymentMethod = @".mps-paymentoptions";
        private const string monoVolume = @"#content_1_LineItems_InputMonoVolumeBreaks_0";
        private const string colourVolume = @"#content_1_LineItems_InputColourVolumeBreaks_0";
        private const string clickPriceValue = @"[class='mps-col mps-top mps-clickprice-line2'][data-click-price-mono='true']";
        private const string clickPriceColourValue = @"[data-mono-only='False'] [class='mps-col mps-top mps-clickprice-line2'][data-click-price-colour='true']";
        private const string clickPricePageNext = @"#content_1_ButtonNext";
        private const string printerPriceSelector = "#CostPrice";
        private const string optionCostPrice0Selector = "#OptionCostPrice0";
        private const string optionQuantity0Selector = "#OptionQuantity0";
        private const string installationPackInputSelector = "#InstallationPackId";
        private const string addToProposalButtonSelector = ".js-mps-product-configuration-submit";
        private const string deliveryInputSelector = "#DeliveryCostPrice";
        private const string printerMarginSelector = "#Margin";
        private const string printerUnitPriceSelector = "#SellPrice";
        private const string printerTableBodySelector = "table.table-condensed > tbody";
        private const string printerTableFootSelector = "table.table-condensed > tfoot";
        private const string printerTotalPriceDataAttributeSelector = "total-price";
        private const string printerTotalLinePriceDataAttributeSelector = "total-line-price";
        private const string alertSuccessContinueSelector = "a.alert-link.js-mps-trigger-next";
        private const string PreloaderSelector = ".js-mps-preloader";
        private const string productAddedToProposalSelector = ".alert-info.fade.in.mps-alert.js-mps-alert";
        private const string addButtonSelector = ".js-mps-product-open-add";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_InputSearchProduct")]
        public IWebElement InputSearchProductElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-display-option[data-display-option=\"flat\"]")]
        public IWebElement flatListClickButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-display-option[data-display-option=\"default\"]")]
        public IWebElement withImagesClickButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-alert")]
        public IWebElement ProductsScreenAlertElement;
        [FindsBy(How = How.Id, Using = "Quantity")]
        public IWebElement ProductQuantityElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputMonoVolumeBreaks_0")]
        public IWebElement monoVolumeDropdownElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputColourVolumeBreaks_0")]
        public IWebElement colourVolumeDropdownElement;
        [FindsBy(How = How.Id, Using = "CostPrice")]
        public IWebElement ProductCostPriceElement;
        [FindsBy(How = How.Id, Using = "SellPrice")]
        public IWebElement ProductSellPriceElement;
        [FindsBy(How = How.Id, Using = "Margin")]
        public IWebElement ProductMarginElement;
        [FindsBy(How = How.Name, Using = "MarginFullPrecision")]
        public IWebElement ProductMarginValueElement;
        [FindsBy(How = How.Id, Using = "InstallationPackCostPrice")]
        public IWebElement InstallationPackCostPriceElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-installation.mps-qa-installation [readonly]")]
        public IWebElement InstallationPackReadOnlyCostPriceElement;
        [FindsBy(How = How.Id, Using = "InstallationPackMargin")]
        public IWebElement InstallationPackMarginElement;
        [FindsBy(How = How.Id, Using = "InstallationPackSellPrice")]
        public IWebElement InstallationPackSellPriceElement;
        [FindsBy(How = How.Id, Using = "OptionQuantity0")]
        public IWebElement OptionsQuantityElement;
        [FindsBy(How = How.Id, Using = "OptionCostPrice0")]
        public IWebElement OptionsCostPriceElement;
        [FindsBy(How = How.Id, Using = "OptionSellPrice0")]
        public IWebElement OptionsSellPriceElement;
        [FindsBy(How = How.Id, Using = "OptionMargin0")]
        public IWebElement OptionsMarginElement;
        [FindsBy(How = How.Id, Using = "DeliveryCostPrice")]
        public IWebElement DeliveryCostPriceElement;
        [FindsBy(How = How.Id, Using = "DeliveryMargin")]
        public IWebElement DeliveryMarginElement;
        [FindsBy(How = How.Id, Using = "DeliverySellPrice")]
        public IWebElement DeliverySellPriceElement;
        [FindsBy(How = How.Id, Using = "ServicePackMargin")]
        public IWebElement ServicePackMarginElement;
        [FindsBy(How = How.Id, Using = "ServicePackSellPrice")]
        public IWebElement ServicePackSellPriceElement;
        [FindsBy(How = How.Id, Using = "ClickPriceMonoCoverage")]
        public IWebElement ClickPriceCoverageElement;
        [FindsBy(How = How.Id, Using = "ClickPriceMonoVolume")]
        public IWebElement ClickPriceVolumeElement;
        [FindsBy(How = How.Id, Using = "ClickPriceMonoMargin")]
        public IWebElement ClickPriceMarginElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-configuration-submit")]
        public IWebElement AddToProposalElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-configuration-close")]
        public IWebElement CloseWithoutSavingElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/create/summary\"]")]
        public IWebElement ProposalSummaryScreenElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/create/click-price\"]")]
        public IWebElement ClickPriceScreenElement;
        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        public IWebElement SummaryConfirmationTextElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonCalculate")]
        public IWebElement CalculateClickPriceElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-installation .mps-qa-srp")]
        public IWebElement InstallationSRPElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputMonoVolume_0']")]
        public IWebElement MonoVolumeInputFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#InstallationPackId [selected=\"true\"]")]
        public IWebElement SelectedInstallationTypeElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-installation.mps-qa-installation td")]
        public IList<IWebElement> DisplayedInstallationTypeElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-installation [data-total-price=\"true\"]")]
        public IWebElement SelectedInstallationPriceElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-service-pack td")]
        public IList<IWebElement> SelectedServicePackNameElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-service-pack [data-total-price=\"true\"]")]
        public IWebElement SelectedServicePackPriceElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-tab")]
        public IWebElement DeviceScreenValidator;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-model .mps-qa-srp")]
        public IWebElement ModelSrpElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-option .mps-qa-srp")]
        public IWebElement OptionSrpElement;
        [FindsBy(How = How.CssSelector, Using = "[class*=\"js-mps-product-open-container\"]")]
        public IList<IWebElement> PropertyContainerElement;
        [FindsBy(How = How.CssSelector, Using = "[data-mps-product-auto-fax=\"true\"]")]
        public IWebElement PrinterFaxproperty;
        [FindsBy(How = How.CssSelector, Using = "[data-mps-product-auto-scan=\"true\"]")]
        public IWebElement PrinterScanproperty;
        [FindsBy(How = How.CssSelector, Using = "[data-mps-product-auto-duplex=\"true\"]")]
        public IWebElement PrinterDuplexproperty;
        [FindsBy(How = How.CssSelector, Using = "[data-mps-product-auto-tray=\"true\"]")]
        public IWebElement PrinterTrayproperty;
        [FindsBy(How = How.CssSelector, Using = "[data-mps-product-auto-paper-size=\"A4\"]")]
        public IWebElement PrinterA4property;
        [FindsBy(How = How.CssSelector, Using = "[data-mps-product-auto-paper-size=\"A3\"]")]
        public IWebElement PrinterA3property;
        [FindsBy(How = How.CssSelector, Using = ".mps-product-configuration-container-flat")]
        public IList<IWebElement> ProductPageFlatVerifier;
        [FindsBy(How = How.CssSelector, Using = ".mps-product-img")]
        public IList<IWebElement> ProductPageImageVerifier;
        [FindsBy(How = How.CssSelector, Using = "[data-mps-product-auto-colour-type=\"C\"]")]
        public IWebElement ImageColourproperty;
        [FindsBy(How = How.CssSelector, Using = "[data-mps-product-auto-colour-type=\"M\"]")]
        public IWebElement ImageMonoproperty;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product .mps-product-colour")]
        public IWebElement FlatColourProperty;
        [FindsBy(How = How.CssSelector, Using = ".mps-product-mono")]
        public IWebElement FlatMonoProperty;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-alert .js-mps-trigger-next")]
        public IWebElement MoveToClickPriceButton;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-configuration-container .js-mps-alert li")]
        public IWebElement ErrorMessageForInstallationCost;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-search-field")]
        public IWebElement FilterProductElement;
        
        
        

        
        private const string QuantityElementString = "[data-quantity=\"true\"]";
        private const string ServicePackElementString = ".mps-qa-service-pack";
        private const string InstallationQuantityElementString = ".mps-qa-installation";
        private const string DeliveryQuantityElementString = ".mps-qa-delivery";
        
        
        private IWebElement FaxCheckboxElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = "input[data-name=\"fax\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement ScannerCheckboxElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = "input[data-name=\"scanner\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement DuplexCheckboxElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = "input[data-name=\"duplex\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement AdditionalTrayCheckboxElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = "input[data-name=\"additionalTray\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement A4CheckboxElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = "input[data-name=\"a4\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement A3CheckboxElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            var element = "input[data-name=\"a3\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement MonoCheckboxElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = "input[data-name=\"mono\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement ColourCheckboxElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = "input[data-name=\"colour\"]";

            return GetElementByCssSelector(element);
        }

        public void TickRelineSearchFax()
        {
            LoggingService.WriteLogOnMethodEntry();
            IWebElement element = FaxCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchScanner()
        {
            LoggingService.WriteLogOnMethodEntry();
            IWebElement element = ScannerCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchDuplex()
        {
            LoggingService.WriteLogOnMethodEntry();
            IWebElement element = DuplexCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchAdditionalTray()
        {
            LoggingService.WriteLogOnMethodEntry();
            IWebElement element = AdditionalTrayCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchA4()
        {
            LoggingService.WriteLogOnMethodEntry();
            IWebElement element = A4CheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchA3()
        {
            LoggingService.WriteLogOnMethodEntry();
            IWebElement element = A3CheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchMono()
        {
            LoggingService.WriteLogOnMethodEntry();
            IWebElement element = MonoCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchColour()
        {
            LoggingService.WriteLogOnMethodEntry();
            IWebElement element = ColourCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        private IList<IWebElement> DisplayedPrintersElements()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = ".mps-product-configuration";

            return GetElementsByCssSelector(element);
        }

        public void IsAllPrintersHaveFaxFacility()
        {
            LoggingService.WriteLogOnMethodEntry();
            for (var i=0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterFaxproperty.Displayed, 
                    "Some printers displayed do not contain fax properties");
            }
        }

        public void IsAllPrintersHaveScanFacility()
        {
            LoggingService.WriteLogOnMethodEntry();
            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterScanproperty.Displayed, 
                    "Some printers displayed do not contain scan properties");
            }

        }

        public void IsAllPrintersHaveDuplexFacility()
        {
            LoggingService.WriteLogOnMethodEntry();
            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterDuplexproperty.Displayed, 
                    "Some printers displayed do not contain duplex properties");
            }
        }

        public void IsAllPrintersHaveAdditionalTrayFacility()
        {
            LoggingService.WriteLogOnMethodEntry();
            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterTrayproperty.Displayed, 
                    "Some printers displayed do not contain tray properties");
            }
        }

        public void IsAllPrintersHaveA4Facility()
        {
            LoggingService.WriteLogOnMethodEntry();
            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterA4property.Displayed,
                    "Some printers displayed do not contain tray properties");
            }
        }

        public void IsAllPrintersHaveA3Facility()
        {
            LoggingService.WriteLogOnMethodEntry();
            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterA3property.Displayed,
                    "Some printers displayed do not contain tray properties");
            }
        }

        public void IsAllPrintersHaveMonoFacility()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ProductPageImageVerifier != null)
            {
                for (var i = 0; i <= PropertyContainerElement.Count; i++)
                {
                    TestCheck.AssertIsEqual(true, ImageMonoproperty.Displayed,
                        "Some printers displayed do not contain mono properties");
                }
                
            }
            else
            {

                for (var i = 0; i <= PropertyContainerElement.Count; i++)
                {
                    TestCheck.AssertIsEqual(true, FlatColourProperty.Text.Equals("-"),
                        "Some printers in flat view do not contain mono properties");
                    TestCheck.AssertIsEqual(false, FlatMonoProperty.Text.Equals("-"),
                        "Some printers in flat view do not contain mono properties");
                }

                
                
            }
        }

        public void IsAllPrintersHaveColourFacility()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ProductPageImageVerifier != null)
            {
                for (var i = 0; i <= PropertyContainerElement.Count; i++)
                {
                    TestCheck.AssertIsEqual(true, ImageColourproperty.Displayed,
                        "Some printers displayed do not contain mono properties");
                }

                
            }
            else
            {
                for (var i = 0; i <= PropertyContainerElement.Count; i++)
                {
                    TestCheck.AssertIsEqual(false, FlatColourProperty.Text.Equals("-"),
                        "Some printers in flat view do not contain mono properties");
                    TestCheck.AssertIsEqual(false, FlatMonoProperty.Text.Equals("-"),
                        "Some printers in flat view do not contain mono properties");
                }
            }
        }

        public void IsProductScreenTextDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 1);
            if (ProductsScreenAlertElement == null) throw new
                NullReferenceException("Unable to locate text on Product Screen");

            AssertElementPresent(ProductsScreenAlertElement, "Product Screen Instruction");
        }

        public void IsDeviceScreenDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 1);
            TestCheck.AssertIsEqual(true, 
                DeviceScreenValidator.Displayed, 
                "Device screen is not displayed");
            WaitForElementToBeClickableByCssSelector("a[href=\"/sign-out\"]", 5, 10);
        }

        public void TypeIntoRHSFreeTextFilter(string model)
        {
            LoggingService.WriteLogOnMethodEntry(model);
            WebDriver.Wait(DurationType.Second, 4);
            ClearAndType(InputSearchProductElement, model);
            WebDriver.Wait(DurationType.Second, 1);
        }

        private IList<IWebElement> DisplayedAllPrintersByFilteringOfFreeTextElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = ".js-mps-product-open-container[style=\"display: list-item;\"]";

            return GetElementsByCssSelector(element);
        }

        private IList<IWebElement> DisplayedPrintersAfterFreeTextFiltering(string model)
        {
            LoggingService.WriteLogOnMethodEntry(model);
            var element = String.Format("#pc-{0}", model);
            return GetElementsByCssSelector(element);
        }

        public void IsAllPrintersReturnedThatSearched(string model)
        {
            int count = 0;

            foreach (IWebElement element in DisplayedPrintersAfterFreeTextFiltering(model))
            {
                var modelWithPC = element;
                if (modelWithPC.Displayed) count++;
            }

            TestCheck.AssertIsEqual(count, DisplayedPrintersAfterFreeTextFiltering(model).Count,
                "Displayed all printers are not invalid");
        }

        private IList<IWebElement> DisplayedAllPrintersAsFlatListElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = ".mps-product-configuration-container-flat";

            return GetElementsByCssSelector(element);
        }

        private IList<IWebElement> DisplayedAllPrintersWithImagesElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = ".mps-product-img";

            return GetElementsByCssSelector(element);
        }

        public void VerifyThatAllProductsDisplayedAsAFlatListWithNoImages()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 1);
            AssertElementPresent(DisplayedAllPrintersAsFlatListElement()[0], "Displayed with images");
        }

        public void VerifyThatAllProductsDisplayedAsAWithImages()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 1);
            AssertElementPresent(DisplayedAllPrintersWithImagesElement()[0], "Displayed as flat list");
        }

        public void ChangeProductViewToWithImages()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (withImagesClickButtonElement == null)
                throw new NullReferenceException("Button to change product view is not displayed");

            withImagesClickButtonElement.Click();
        }

        public void ChangeProductViewToFlatList()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (flatListClickButtonElement == null)
                throw new NullReferenceException("Button to change product view is not displayed");

            flatListClickButtonElement.Click();
        }

        private IWebElement OptionQuantity0Element()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector("#OptionQuantity0", 5);
        }

        private IWebElement OptionCostPrice0Element()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector("#OptionCostPrice0", 5);
        }

        private IWebElement OptionsSellPrice0Element()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector("OptionSellPrice0", 5);
        }

        private IWebElement OptionsMargin0Element()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector("OptionMargin0", 5);
        }

        public void StoreDefaultProductConfiguration()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (hogeIsFullDeviceScreenDisplayed())
            {
                if (IsElementPresent(ProductQuantityElement))
                    SpecFlow.SetContext("ProductQuantity", ProductQuantityElement.GetAttribute("value"));

                SetProductCostPrice();

                if (IsElementPresent(ProductMarginElement))
                    SpecFlow.SetContext("ProductMargin", ProductMarginElement.GetAttribute("value"));
                if (IsElementPresent(ProductSellPriceElement))
                    SpecFlow.SetContext("ProductSellPrice", ProductSellPriceElement.GetAttribute("value"));
                if (OptionQuantity0Element() != null)
                    SpecFlow.SetContext("OptionsQuantity", OptionsQuantityElement.GetAttribute("value"));
                if (IsElementPresent(DeliveryCostPriceElement))
                    SpecFlow.SetContext("DeliveryCostPrice", DeliveryCostPriceElement.GetAttribute("value"));
                if (IsElementPresent(DeliveryMarginElement))
                    SpecFlow.SetContext("DeliveryMargin", DeliveryMarginElement.GetAttribute("value"));
                if (IsElementPresent(DeliverySellPriceElement))
                    SpecFlow.SetContext("DeliverySellPrice", DeliverySellPriceElement.GetAttribute("value"));
                
                SetInstallationDetails();
            }
        }

        public void EnterDeliveryCost(string delivery)
        {
            LoggingService.WriteLogOnMethodEntry(delivery);
            if (delivery.Equals("Yes"))
            {
                ClearAndType(DeliveryCostPriceElement, "100");
            }
        }

        public void SetInstallationDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsElementPresent(InstallationSRPElement))
                SpecFlow.SetContext("InstallationSRP", GetValueInstallationSrpElement());
            if (IsElementPresent(InstallationPackCostPriceElement))
                SpecFlow.SetContext("InstallationPackCostPrice", InstallationPackCostPriceElement.GetAttribute("value"));
            if (IsElementPresent(InstallationPackMarginElement))
                SpecFlow.SetContext("InstallationPackMargin", InstallationPackMarginElement.GetAttribute("value"));
            if (IsElementPresent(InstallationPackSellPriceElement))
                SpecFlow.SetContext("InstallationPackSellPrice", InstallationPackSellPriceElement.GetAttribute("value"));
        }


        public void StoreExtraValuesOnProductPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (hogeIsFullDeviceScreenDisplayed())
            {
                if (IsElementPresent(ProductQuantityElement))
                    SpecFlow.SetContext("ProductQuantity", ProductQuantityElement.GetAttribute("value"));

               
                if (IsElementPresent(GetElementByCssSelector("#InstallationPackId [selected=\"true\"]", 5)))
                    SpecFlow.SetContext("SelectedInstallationType", SelectedInstallationTypeElement.Text);

                if (IsElementPresent(GetElementByCssSelector(".js-mps-installation.mps-qa-installation", 5)))
                    SpecFlow.SetContext("SelectedInstallationType", DisplayedInstallationTypeElement.First().Text);

                if (IsElementPresent(SelectedServicePackPriceElement))
                    SpecFlow.SetContext("SelectedServicePackPrice", SelectedServicePackPriceElement.Text);

                if (IsElementPresent(SelectedServicePackNameElement.First()))
                    SpecFlow.SetContext("ServicePackName", SelectedServicePackNameElement.First().Text);

                if (IsElementPresent(SelectedInstallationPriceElement))
                    SpecFlow.SetContext("SelectedInstallationPrice", SelectedInstallationPriceElement.Text);
            }
        }

        private IWebElement ProductFlatListAddElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector(flatItemsIdentifier, 10);
        }

        public void ClickOnAPrinter(string printer)
        {
            LoggingService.WriteLogOnMethodEntry(printer);
            SpecFlow.SetContext("InitialProductPageText", ProductsScreenAlertElement.Text);

            var element = IsElementPresent(ProductFlatListAddElement()) ? "#pc-{0} .js-mps-product-open" : "#pc-{0} .js-mps-product-open-add";

            element = string.Format(element, printer.Equals(string.Empty) ? MpsUtil.PrinterUnderTest() : printer);

            var printerClickable = GetElementByCssSelector(element);

            printerClickable.Click();
            WebDriver.Wait(DurationType.Second, 1);

        }

        public void EnterPrinterUnitCost(string price)
        {
            LoggingService.WriteLogOnMethodEntry(price);
            var element = "input#CostPrice.form-control.input-sm";
            var productUnitCostField = GetElementByCssSelector(element);
            ClearAndType(productUnitCostField, price);
        }

        public void EnterDeliveryUnitCost(string delivery)
        {
            LoggingService.WriteLogOnMethodEntry(delivery);
            var delivery_cost = (delivery.Equals("Yes")) ? "1" : "0";
            var element = "input#DeliveryCostPrice.form-control.input-sm";
            var deliveryUnitCostField = GetElementByCssSelector(element);
            ClearAndType(deliveryUnitCostField, delivery_cost);
        }

        private IEnumerable<IWebElement> QtyForAccessoriesElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = ".mps-qa-option .mps-txt-r [name=\"OptionQuantity\"][data-mps-val-numeric-min]";

            return GetElementsByCssSelector(element);
        }

        public void IsQtyForAccessoriesAreDefaultToZero()
        {
            LoggingService.WriteLogOnMethodEntry();
            foreach (IWebElement element in QtyForAccessoriesElement())
            {
                TestCheck.AssertIsEqual("0", element.GetAttribute("data-mps-val-numeric-min"), "Quantity For Accessory is not defaulted zero");
            }
        }

        private string GetValueOfProductMarginValueElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            return ProductMarginValueElement.GetAttribute("value");
        }

        public void StrictVerifyMarginFieldValues()
        {
            LoggingService.WriteLogOnMethodEntry();
            string before = SpecFlow.GetContext("HardwareDefaultMargin");
            string after = GetValueOfProductMarginValueElement();
            TestCheck.AssertIsEqual(before, after, "Hardware Default Margin value is not equal to the value of Local Office Dealer Default");
        }

        public void EnterAllMarginRandomly()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterProductMargin(Math.Round((new Random().NextDouble()+1) * new Random().Next(5, 20), 1).ToString());
            EnterOptionMargin(Math.Round((new Random().NextDouble() + 1) * new Random().Next(5, 20), 1).ToString(), "0");
            EnterOptionsQuantity0("1");
            EnterDeliveryMargin(Math.Round((new Random().NextDouble() + 1) * new Random().Next(5, 20), 1).ToString());
            EnterInstallationPackMargin(Math.Round((new Random().NextDouble() + 1) * new Random().Next(5, 20), 1).ToString());
            EnterServicePackMargin(Math.Round((new Random().NextDouble() + 1) * new Random().Next(5, 20), 1).ToString());
        }

        public void EnterProductMargin(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SpecFlow.SetContext("EnteredProductMargin", value);
            ClearAndType(ProductMarginElement, value);
            ProductMarginElement.SendKeys(Keys.Tab);
        }

        public void EnterOptionMargin(string value, string row)
        {
            LoggingService.WriteLogOnMethodEntry(value,row);
            try
            {
                string sel = String.Format("#OptionMargin{0}", row);
                IWebElement element = GetElementByCssSelector(sel, 5);
                if (element != null)
                {
                    SpecFlow.SetContext(String.Format("EnteredOptionMargin{0}", row), value);
                    ClearAndType(element, value);
                    DeliveryMarginElement.SendKeys(Keys.Tab);
                }

            }
            catch (NullReferenceException nre)
            {

                string.Format("Options margin is not found because {0}", nre);
            }
            catch (WebDriverException web)
            {

                string.Format("Options margin is not found because {0}", web);
            }
           
        }

        public void EnterDeliveryMargin(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SpecFlow.SetContext("EnteredDeliveryMargin", value);
            ClearAndType(DeliveryMarginElement, value);
            DeliveryMarginElement.SendKeys(Keys.Tab);
        }

        public void EnterInstallationPackMargin(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SpecFlow.SetContext("EnteredInstallationPackMargin", value);
            ClearAndType(InstallationPackMarginElement, value);
            InstallationPackMarginElement.SendKeys(Keys.Tab);
        }

        public void EnterServicePackMargin(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SpecFlow.SetContext("EnteredServicePackMargin", value);
            ClearAndType(ServicePackMarginElement, value);
            ServicePackMarginElement.SendKeys(Keys.Tab);
        }

        public void EnterProductQuantity(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            ClearAndType(ProductQuantityElement, value);
        }

        public void EnterProductCostPrice(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            ClearAndType(ProductCostPriceElement, value);
        }

        public void EnterProductSellPrice(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            ClearAndType(ProductSellPriceElement, value);
            ProductSellPriceElement.SendKeys(Keys.Tab);
        }

        public void EnterOptionsQuantity0(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            try
            {
                ClearAndType(OptionsQuantityElement, value);
            }
            catch (NullReferenceException nre)
            {

                string.Format("Options Qty is not found because {0}", nre);
            }
            catch (WebDriverException web)
            {

                string.Format("Options Qty is not found because {0}", web);
            }
        }

        public void EnterDeliverySellPrice(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            ClearAndType(DeliverySellPriceElement, value);
            DeliverySellPriceElement.SendKeys(Keys.Tab);
        }

        public void AddAllDetailsToProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(AddToProposalElement);
            AddToProposalElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        private IWebElement AddToProposalButtonElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = ".js-mps-product-configuration-submit.disabled";

            return GetElementByCssSelector(element);
        }

        public void IsAddToProposalButtonGrayout()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(AddToProposalElement);
            AssertElementPresent(AddToProposalButtonElement(), "add to proposal grayout");
        }

        private string GetValueOfDeliveryMarginValueElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            return ProductMarginValueElement.GetAttribute("value");
        }

        public void IsDealerMarginRevertedToTheOriginalValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            string before = SpecFlow.GetContext("EnteredDeliveryMargin");
            string after = GetValueOfDeliveryMarginValueElement();
            TestCheck.AssertIsNotEqual(before, after, "Delivery Margin value is not reverted to the original value");
        }

        public void IsDealerMarginRetainedByDealerAdminDefaultMargin()
        {
            LoggingService.WriteLogOnMethodEntry();
            string before = SpecFlow.GetContext("DealerAdminHardwareDefaultMargin");
            string after = ProductMarginElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Dealer Admin Hardware default margin value is not retained");
        }

        private IWebElement InstallationPackUnitCostLessThanErrorElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = ".alert-danger";

            return GetElementByCssSelector(element);
        }

        public void IsInstallationPackUnitCostLessThanErrorDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            AssertElementPresent(InstallationPackUnitCostLessThanErrorElement(), "installation pack unit cost less than error");
        }

        public void EnterInstallationPackCostPrice(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            ClearAndType(InstallationPackCostPriceElement, value);
            
        }

        public void IsInstallationCostReadOnly()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, InstallationPackReadOnlyCostPriceElement.Displayed, 
                                            "Installation cost is not read only");
        }


        public void IsErrorMessageDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, ErrorMessageForInstallationCost.Displayed, "Installation Error was not displayed");
        }

        public void IsCurrencyInErrorMessageCorrect(string currency)
        {
            LoggingService.WriteLogOnMethodEntry(currency);
            TestCheck.AssertTextContains(ErrorMessageForInstallationCost.Text, currency);    
        }

        public decimal InstallationPackCostPrice()
        {
            LoggingService.WriteLogOnMethodEntry();

            var priceText = InstallationSRPElement.Text;

            var priceTag = MpsUtil.GetValue(priceText);

            try
            {
                return Convert.ToDecimal(priceTag);
            }
            catch (FormatException formatException)
            {
                throw new Exception(formatException.ToString());
            }

        }

        public decimal InstallationPackUnitPrice()
        {
            LoggingService.WriteLogOnMethodEntry();
            var priceText = InstallationPackCostPriceElement.GetAttribute("value");
            var decimalVal = Decimal.Parse(priceText);

            return decimalVal;

        }

        public void EnterInstallationPackCostPriceLessThanDefault()
        {
            LoggingService.WriteLogOnMethodEntry();
            var price = InstallationPackUnitPrice();
            EnterInstallationPackCostPrice((price - 1).ToString());
        }

        public void IsNotTheProductAddedToTheProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            AssertElementPresent(CloseWithoutSavingElement, "Close without saving button element");            
        }

        private IWebElement FullDeviceScreenElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = ".js-mps-product-configuration[data-price-hardware=\"true\"]";
            return GetElementByCssSelector(element);
        }

        public void IsFullDeviceScreenDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            AssertElementPresent(FullDeviceScreenElement(), "Full device screen is not displayed");
        }

        private IWebElement ReducedDeviceScreenElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = ".js-mps-product-configuration[data-price-hardware=\"false\"]";

            return GetElementByCssSelector(element);
        }

        public void IsReducedDeviceScreenDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            AssertElementPresent(ReducedDeviceScreenElement(), "Reduced device screen is not displayed");
        }

        private bool hogeIsFullDeviceScreenDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = ".js-mps-product-configuration";
            string ret = GetElementByCssSelector(element).GetAttribute("data-price-hardware");

            if (ret.Equals("true"))
                return true;
            else
            {
                return false;
            }
        }

        public void MoveToProposalSummaryScreen()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(ProposalSummaryScreenElement);
            ProposalSummaryScreenElement.Click();
            AssertElementPresent(SummaryConfirmationTextElement, "Product Confirmation Message");
        }

        private IList<IWebElement> TotalPriceForAllItem()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = "[data-total-price=\"true\"]";

            return GetElementsByCssSelector(element);
        }

        private IWebElement TotalLinePriceElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = "[data-total-line-price=\"true\"]";

            return GetElementByCssSelector(element);
        }

        public void IsGrandTotalPriceCorrect()
        {
            LoggingService.WriteLogOnMethodEntry();
            decimal sum = 0;
            foreach (IWebElement element in TotalPriceForAllItem())
            {
                sum += MpsUtil.GetValue(element.Text);
            }

            TestCheck.AssertIsEqual(sum, MpsUtil.GetValue(TotalLinePriceElement().Text), 
                "The sum of the Total Price is not equal to the Grand Total Price displayed");
        }

        public void IsTheTotalPriceTheProductOfQTYAndUnitPrice()
        {
            LoggingService.WriteLogOnMethodEntry();
            string Quantity = OptionsQuantityElement.GetAttribute("value");
            string UnitPrice = OptionsSellPriceElement.GetAttribute("value");
            decimal calcurated = Convert.ToDecimal(Quantity) * Convert.ToDecimal(UnitPrice);
            string TotalStr = TotalForAllAccessoriesElement()[0].Text;
            decimal Total = MpsUtil.GetValue(TotalStr);
            TestCheck.AssertIsEqual(calcurated, Total, "TotalPriceOfAccessory is not correct");
        }

        public void FillProductDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterProductQuantity("2");
            EnterProductCostPrice("50");
            EnterProductSellPrice("60");
            EnterOptionsQuantity0("3");
            VerifyMarginFieldValues();
        }

        public void VerifyMarginFieldValues()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 2);
            var marginText = ProductMarginElement.Text;
            TestCheck.AssertIsNotNull(ProductMarginElement.GetAttribute("value"), "Product Margin Element");
            TestCheck.AssertIsEqual(false, marginText.StartsWith("-"), "Margin Text starts with -");
        }

        private IList<IWebElement> TotalForAllAccessoriesElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = ".mps-qa-option  [data-total-price=\"true\"]";

            return GetElementsByCssSelector(element);
        }

        public void IsTotalForAllAccessoriesAreDefaultToZero()
        {
            LoggingService.WriteLogOnMethodEntry();
            foreach (IWebElement element in TotalForAllAccessoriesElement())
                TestCheck.AssertIsEqual((decimal)0, MpsUtil.GetValue(element.Text), "Total for all accessories are not defaulted zero");
        }

        public DealerProposalsCreateClickPricePage NextButtonClick()
        {
            LoggingService.WriteLogOnMethodEntry();
            NextButtonElement.Click();
            return GetTabInstance<DealerProposalsCreateClickPricePage>(Driver);
        }

        public void ChangeDeviceInstallationType()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectFromDropdownByValue(GetElementByCssSelector("#InstallationPackId"), "1");
            var installationCost = InstallationSRPElement.Text;

            ClearAndType(InstallationPackCostPriceElement, MpsUtil.GetValue(installationCost).ToString());
            WebDriver.Wait(DurationType.Second, 1);

            SetInstallationDetails();
        }

        public void SelectDeviceInstallationType(string type)
        {
            LoggingService.WriteLogOnMethodEntry(type);
            var install = "";

            switch (type)
            {
                case "Brother":
                    install = "1";
                    break;
                case "Dealer":
                    install = "2";
                    break;
            }

            if(!(IsBigAtSystem() || IsPolandSystem()))
            {
                SelectFromDropdownByValue(GetElementByCssSelector("#InstallationPackId"), install);
            }
           
        }

        private string GetValueInstallationSrpElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            return InstallationSRPElement.Text;
        }
        public void VerifyThatInstallationSrpValueChange()
        {
            LoggingService.WriteLogOnMethodEntry();
            string hoge = GetValueInstallationSrpElement();
            TestCheck.AssertIsNotEqual(SpecFlow.GetContext("InstallationSRP"), 
                GetValueInstallationSrpElement(), "Installation SRP not changed");
            TestCheck.AssertIsNotEqual(SpecFlow.GetContext("InstallationPackCostPrice"), 
                InstallationPackCostPrice().ToString(), "Installation Unit Cost not changed");
            TestCheck.AssertIsNotEqual(SpecFlow.GetContext("InstallationPackSellPrice"), 
                InstallationPackSellPriceElement.GetAttribute("value"), "Installation Unit Price not changed");
        }
        
        public void IsProductUnitPriceChanged()
        {
            LoggingService.WriteLogOnMethodEntry();
            string before = SpecFlow.GetContext("ProductSellPrice");
            string after = ProductSellPriceElement.GetAttribute("value");
            TestCheck.AssertIsNotEqual(before, after, "Product sell price should changed");
        }

        public void IsProductMarginChanged()
        {
            LoggingService.WriteLogOnMethodEntry();
            string before = SpecFlow.GetContext("ProductMargin");
            string after = ProductMarginElement.GetAttribute("value");
            TestCheck.AssertIsNotEqual(before, after, "Product sell price should changed");
        }

        public void IsNotProductMarginChanged()
        {
            LoggingService.WriteLogOnMethodEntry();
            string before = SpecFlow.GetContext("ProductMargin");
            string after = ProductMarginElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Product margin should not change");
        }

        public void IsNotProductUnitCostChanged()
        {
            LoggingService.WriteLogOnMethodEntry();
            string before = SpecFlow.GetContext("ProductCostPrice");
            string after = ProductCostPriceElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Product cost price should not change");
        }

        public void IsNotDeliveryCostPriceChanged()
        {
            LoggingService.WriteLogOnMethodEntry();
            string before = SpecFlow.GetContext("DeliveryCostPrice");
            string after = DeliveryCostPriceElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Delivery cost price should not change");
        }

        public void IsNotDeliverySellPriceChanged()
        {
            LoggingService.WriteLogOnMethodEntry();
            string before = SpecFlow.GetContext("DeliverySellPrice");
            string after = DeliverySellPriceElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Delivery sell price should not change");
        }

        private IList<IWebElement> ModelNameElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = ".mps-product-configuration .col-xs-8 h4";

            return GetElementsByCssSelector(element);
        }

        private bool SearchModelName(string model)
        {
            LoggingService.WriteLogOnMethodEntry(model);
            bool found = false;
            foreach (IWebElement element in ModelNameElement())
            {
                if (element.Text.Equals(model))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public void IsModelFound(string model)
        {
            LoggingService.WriteLogOnMethodEntry(model);
            TestCheck.AssertIsEqual(true, SearchModelName(model), "model not found");
        }

        public void IsNotModelFound(string model)
        {
            LoggingService.WriteLogOnMethodEntry(model);
            WebDriver.Wait(DurationType.Second, 5);
            TestCheck.AssertIsEqual(false, SearchModelName(model), "model found");            
        }

        private IList<IWebElement> AllSRPElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string element = ".mps-qa-srp";

            return GetElementsByCssSelector(element);
        }

        public void IsAllSRPNotEditable()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsNotEqual(0, AllSRPElement().Count, "srp field nothing");
            IList<IWebElement> element = GetElementsByCssSelector(".mps-qa-srp input", 5);
            TestCheck.AssertIsEqual(0, element.Count, "element is not null");
            if (IsElementPresent(ProductQuantityElement))
                SpecFlow.SetContext("ProductQuantity", ProductQuantityElement.GetAttribute("value"));
        }

        private IWebElement DeliveryQuantityElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = String.Format("{0} {1}", DeliveryQuantityElementString, QuantityElementString);

            return GetElementByCssSelector(element);
        }

        public void IsDeliveryQuantityNotEditable()
        {
            LoggingService.WriteLogOnMethodEntry();
            string element = String.Format("{0} {1} input", DeliveryQuantityElementString, QuantityElementString);

            TestCheck.AssertIsNotEqual(0, DeliveryQuantityElement(), "Unable to locate Delivery Quantity field");
            if (GetElementByCssSelector(element, 5) == null)
                TestCheck.AssertIsNotNull(DeliveryQuantityElement(), "Delivery Quantity is editable");
        }

        public string OptionSrpText()
        {
            LoggingService.WriteLogOnMethodEntry();
            return OptionSrpElement.Text;
        }

        public void EnterOptionCostPrice()
        {
            LoggingService.WriteLogOnMethodEntry();
            try
            {
                if (IsSwedenSystem() || IsDenmarkSystem())
                {
                    // do nothing
                }
                else if (IsNorwaySystem() || IsPolandSystem())
                {
                    var optionText = GetValueFromCurrencyText(ModelSrpElement.Text);
                    ClearAndType(OptionCostPrice0Element(), optionText);
                }
                else
                {
                    var srpOption = MpsUtil.GetValue(OptionSrpText());
                    var optionText = srpOption.ToString().Substring(0, 3);
                    if (OptionCostPrice0Element() != null)
                        ClearAndType(OptionCostPrice0Element(), optionText);
                }
            }
            catch (NullReferenceException nre)
            {
                string.Format("Option Cost Price is not found because {0}", nre);
            }
            catch (WebDriverException web)
            {
                string.Format("Option Cost Price is not found because {0}", web);
            }

            
        }
        public void EnterModelUnitCost()
        {
            LoggingService.WriteLogOnMethodEntry();
            //if (!ModelSrpElement.Text.Contains("£")) return;
            if (IsAustriaSystem() || IsGermanSystem() || IsSwedenSystem()
                || IsDenmarkSystem())
            {
                //do nothing
            } 
            else if (IsNorwaySystem() || IsPolandSystem() || IsNetherlandSystem() || IsSwissSystem())
            {
                var optionText = GetValueFromCurrencyText(ModelSrpElement.Text);
                ClearAndType(ProductCostPriceElement, optionText);
            }
            else
            {
                var srpCost = MpsUtil.GetValue(ModelSrpElement.Text);
                var costText = srpCost.ToString();
                var optionText = costText.Substring(0, 3);
                ClearAndType(ProductCostPriceElement, optionText);  
            }

            

            if(IsPolandSystem()) return;
            SetProductCostPrice();
        }

        private string GetValueFromCurrencyText(string text)
        {
            LoggingService.WriteLogOnMethodEntry();
            var value = text.Replace(" ", "");

            if (IsNorwaySystem())
            {
                value = value.Replace("kr", "");
            }
            else if (IsPolandSystem())
            {
                value = value.Replace("zł", "").TrimEnd();
            }
            else if (IsSwissSystem())
            {
                value = value.Replace("CHF", "").TrimEnd();
            }
            else if (IsNetherlandSystem())
            {
                value = value.Replace("€", "").TrimEnd();
            }

            return value;
        }


        public void SetProductCostPrice()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsElementPresent(ProductCostPriceElement))
                SpecFlow.SetContext("ProductCostPrice", ProductCostPriceElement.GetAttribute("value"));
        }

        private IWebElement InstallationQuantityElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            var element = String.Format("{0} {1}", InstallationQuantityElementString, QuantityElementString);

            return GetElementByCssSelector(element);
        }

        public void IsInstallationQuantityNotEditable()
        {
            LoggingService.WriteLogOnMethodEntry();
            var element = String.Format("{0} {1} input", InstallationQuantityElementString, QuantityElementString);

            TestCheck.AssertIsNotEqual(0, InstallationQuantityElement(), "Unable to locate Installation Quantity field");
            if (GetElementByCssSelector(element, 5) == null)
                TestCheck.AssertIsNotNull(InstallationQuantityElement(), "Installation Quantity is editable");
        }

        private IWebElement ServicepackQuantityElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            var element = String.Format("{0} {1}", ServicePackElementString, QuantityElementString);

            return GetElementByCssSelector(element);
        }

        public void IsServicepackQuantityNotEditable()
        {
            LoggingService.WriteLogOnMethodEntry();
            var element = String.Format("{0} {1} input", ServicePackElementString, QuantityElementString);

            TestCheck.AssertIsNotEqual(0, ServicepackQuantityElement(), "Unable to locate Servicepack Quantity field");
            if (GetElementByCssSelector(element, 5) == null)
                TestCheck.AssertIsNotNull(ServicepackQuantityElement(), "Servicepack Quantity field is editable");
        }

        public void VerifyThatProductQuantityElementChanged()
        {
            LoggingService.WriteLogOnMethodEntry();
            var before = SpecFlow.GetContext("ProductQuantity");
            var after = ProductQuantityElement.GetAttribute("value");
            TestCheck.AssertIsNotEqual(before, after, "ProductQuantity value is changed");
        }

        public void IsFullDeviceScreenDisplayedForPrinterSelected()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 5);
            AssertElementPresent(FullDeviceScreenElement(), "Full device screen is not displayed");
        }

        public void IsReducedDeviceScreenDisplayedForPrinterSelected()
        {
            LoggingService.WriteLogOnMethodEntry();
            AssertElementPresent(ReducedDeviceScreenElement(), "Reduced device screen is not displayed");
        }

        public void VerifyTypeOfDeviceScreenDisplayed(string option)
        {
            LoggingService.WriteLogOnMethodEntry(option);
            if (option.Equals("Full"))
            {
               // IsFullDeviceScreenDisplayedForPrinterSelected();
            }
            else if (option.Equals("Reduced"))
            {
                IsReducedDeviceScreenDisplayedForPrinterSelected();
            }
        }

        

        public DealerProposalsCreateClickPricePage MoveToClickPriceScreen()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(ClickPriceScreenElement);
            ClickPriceScreenElement.Click();

            return GetTabInstance<DealerProposalsCreateClickPricePage>(Driver);
        }

        public DealerProposalsCreateClickPricePage MoveToClickPriceScreenWithButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(MoveToClickPriceButton);
            MoveToClickPriceButton.Click();

            return GetTabInstance<DealerProposalsCreateClickPricePage>(Driver);
        }

        public void VerifyProductAdditionConfirmationMessage()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Millisecond, 2000);
            ScrollTo(ProductsScreenAlertElement);
            var storedProductScreenText = SpecFlow.GetContext("InitialProductPageText");
            var finalProductScreenText = ProductsScreenAlertElement.Text;
            TestCheck.AssertIsEqual(false, storedProductScreenText.Equals(finalProductScreenText), "Product Screen Text");
        }

        private IWebElement PaymentMethodElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector(paymentMethod, 10);
        }

        public void VerifyPaymentMethodIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, PaymentMethodElement().Displayed, "Payment method is not displayed");
        }

        public void VerifyPaymentMethodIsNotDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (!IsElementPresent(PaymentMethodElement()))
            {
                TestCheck.AssertIsEqual(false, PaymentMethodElement().Displayed, "Payment method is displayed");
            }
        }

        private IWebElement MonoVolumeElementClickPrice()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector(monoVolume);
        }

        private IWebElement ColourVolumeElementClickPrice()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector(colourVolume);
        }

        private void CalculateClickPrice(string volume, string colour)
        {
            LoggingService.WriteLogOnMethodEntry(volume,colour);
            if (colourVolumeDropdownElement == null)
                throw new NullReferenceException("ClickVolumeElement can not be found");
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");
            if (monoVolumeDropdownElement == null)
                throw new NullReferenceException("ColourVolumeDropdownElement can not be found");

            if (IsElementPresent(ColourVolumeElementClickPrice()))
                SelectFromDropdown(colourVolumeDropdownElement, colour);
            if (IsElementPresent(MonoVolumeElementClickPrice()))
                SelectFromDropdown(monoVolumeDropdownElement, volume);
            WebDriver.Wait(DurationType.Second, 3);
            CalculateClickPriceElement.Click();
        }

        private void CalculateEPPClickPrice(string volume)
        {
            LoggingService.WriteLogOnMethodEntry(volume);
            if (monoVolumeDropdownElement == null)
                throw new NullReferenceException("ClickVolumeElement can not be found");
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");

            SelectFromDropdown(monoVolumeDropdownElement, volume);
            CalculateClickPriceElement.Click();
        }

        private IList<IWebElement> ClickPriceValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementsByCssSelector(clickPriceValue);
        }

        private IList<IWebElement> ClickPriceColourValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementsByCssSelector(clickPriceColourValue);
        }

        private IWebElement ClickPriceNextButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector(clickPricePageNext);
        }

        private void ProceedToProposalSummaryFromClickPrice()
        {
            LoggingService.WriteLogOnMethodEntry();
            ClickPriceNextButton().Click();
        }

        private void VerifyClickPriceValueIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            for (var i = 0; i < ClickPriceValue().Count; i++)
            {
                TestCheck.AssertIsEqual(false, 
                    ClickPriceValue().ElementAt(i).Text.Equals(string.Empty), 
                    "Price Value is Empty");
            }
        }

        public void CalculateClickPriceAndProceed(string volume, string colour)
        {
            LoggingService.WriteLogOnMethodEntry(volume,colour);
            MoveToClickPriceScreen();
            CalculateClickPrice(volume, colour);
            WebDriver.Wait(DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();
            ProceedToProposalSummaryFromClickPrice();

        }


        private void EnterMonoVolumeQuantity(string volume)
        {
            LoggingService.WriteLogOnMethodEntry(volume);
            if (MonoVolumeInputFieldElement == null)
                throw new NullReferenceException("Mono Volume field can not be found");
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");

            MonoVolumeInputFieldElement.SendKeys(volume);
            WebDriver.Wait(DurationType.Second, 2);
            CalculateClickPriceElement.Click();
        }


      
        public DealerProposalsCreateClickPricePage EditAndUpdateExistingProducts(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            string infoalertselector = @"div.alert-info.js-mps-alert";
            var infoalert = GetElementByCssSelector(infoalertselector, 5);
            if (infoalert != null)
            {
                EditProducts(driver, infoalertselector);
            }
            else
            {
                //danger
                string dangeralertselector = @"div.alert-danger.js-mps-alert";
                var dangeralert = GetElementByCssSelector(dangeralertselector, 5);

                if (dangeralert != null)
                {
                    UpdateExistingProduxts(driver, dangeralertselector);
                }
            }

            ProceedToProposalSummaryFromClickPrice();
            return GetInstance<DealerProposalsCreateClickPricePage>();
        }


        public DealerProposalsCreateClickPricePage ForceGoThrowThisTab(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            //danger
            string selector = @"div.alert-danger.js-mps-alert";
            var alert = GetElementByCssSelector(selector, 5);

            if (alert != null)
            {
                UpdateExistingProduxts(driver, selector);
            }

            ProceedToProposalSummaryFromClickPrice();
            return GetInstance<DealerProposalsCreateClickPricePage>();
        }

        private void EditProducts(IWebDriver driver, string infoalertselector)
        {
            LoggingService.WriteLogOnMethodEntry(driver,infoalertselector);
            string linkselector = @"a.alert-link.js-mps-product-link";

            var links = GetElementsByCssSelector(linkselector);

            if (links != null && links.Any())
            {
                var productlink = links.First();
                var name = productlink.Text;
                productlink.Click();
                var product = EditProduct(driver, name);

                SpecFlow.SetObject("DealerRecentEditProduct", product);
            }
            else
            {
                
            }
        }

        private ProductDetail EditProduct(IWebDriver driver, string name)
        {
            LoggingService.WriteLogOnMethodEntry(driver,name);
            var productselector = string.Format(@"li#pc-{0}", name);
            var productlistitem = GetElementByCssSelector(productselector, 5);
            var producttable = GetElementByCssSelector(productlistitem, "table.table-condensed", 5);

            var product = new ProductDetail
            {
                Model = EditItemDetail(producttable, 1),
                LowerTray = EditItemDetail(producttable, 2),
                Usb2Cable = EditItemDetail(producttable, 3),
                Delivery = EditItemDetail(producttable, 4),
                Brother = EditItemDetail(producttable, 5),
                //Dealer = EditItemDetail(producttable,5),
                MpsServicePack = EditItemDetail(producttable, 6)
            };

            string buttonselector = @"button.btn.js-mps-product-configuration-submit";
            var button = driver.FindElement(By.CssSelector(buttonselector));
            button.Click();
            WebDriver.Wait(DurationType.Millisecond, 2000);

            return product;
        }

        private ItemDetail EditItemDetail(IWebElement table, int row)
        {
            LoggingService.WriteLogOnMethodEntry(table,row);
            var rowselector = string.Format(@"tbody>tr:nth-child({0})", row);
            var tr = table.FindElement(By.CssSelector(rowselector));

            var item = new ItemDetail();

            item.Name = tr.FindElement(By.CssSelector("td:nth-child(1)")).Text;
            item.SRP = RemoveUnites(tr.FindElement(By.CssSelector("td:nth-child(2)")).Text);

            var quantity = tr.FindElement(By.CssSelector("td:nth-child(3)")).Text;
            if (string.IsNullOrEmpty(quantity))
            {
                var quantityelem = tr.FindElement(By.CssSelector("td:nth-child(3)>input"));
                quantity = UpdateIntegerNumber(quantityelem.GetAttribute("value"));

                ClearAndType(quantityelem, quantity);
                WebDriver.Wait(DurationType.Millisecond, 100);
            }
            item.Quantity = quantity;

            var unitcostelem = tr.FindElement(By.CssSelector("td:nth-child(4)>input"));
            item.UnitCost = UpdateDoubleNumber(unitcostelem.GetAttribute("value"));
            ClearAndType(unitcostelem, item.UnitCost);
            WebDriver.Wait(DurationType.Millisecond, 100);

            var marginelem = tr.FindElement(By.CssSelector("td:nth-child(5)>input"));
            item.Margin = UpdateDoubleNumber(marginelem.GetAttribute("value"));
            ClearAndType(marginelem, item.Margin);
            WebDriver.Wait(DurationType.Millisecond, 100);

            item.UnitPrice = tr.FindElement(By.CssSelector("td:nth-child(6)>input")).GetAttribute("value");
            item.TotalPrice = RemoveUnites(tr.FindElement(By.CssSelector("td:nth-child(7)")).Text);

            return item;
        }

        private string UpdateIntegerNumber(string item)
        {
            LoggingService.WriteLogOnMethodEntry(item);
            var str = RemoveUnites(item);
            var d = int.Parse(str);
            d += 1;
            return d.ToString();
        }

        private string UpdateDoubleNumber(string item)
        {
            LoggingService.WriteLogOnMethodEntry(item);
            var str = RemoveUnites(item);
            var d = double.Parse(str);
            d += 0.1;
            return d.ToString("F2");
        }

        private string RemoveUnites(string str)
        {
            LoggingService.WriteLogOnMethodEntry(str);
            string[] units = {"£", " %"};

            return units.Aggregate(str, (current, u) => current.Replace(u, ""));
        }

        private void UpdateExistingProduxts(IWebDriver driver, string selector)
        {
            LoggingService.WriteLogOnMethodEntry(driver,selector);
            string linkselector = @"a.alert-link.js-mps-product-link";

            while (true)
            {
                IWebElement alert = GetElementByCssSelector(selector, 5);
                if (alert == null) break;

                var links = GetElementsByCssSelector(linkselector);

                if (links == null || !links.Any()) break;

                WebDriver.Wait(DurationType.Millisecond, 2000);
                var link = links.First();
                link.Click();

                string buttonselector = @"button.btn.js-mps-product-configuration-submit";
                WaitForElementToExistByCssSelector(buttonselector);
                WebDriver.Wait(DurationType.Millisecond, 2000);
                var button = driver.FindElement(By.CssSelector(buttonselector));
                button.Click();
                WebDriver.Wait(DurationType.Millisecond, 2000);
            }
        }


        public void AddNewProduct(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            var printer = "DCP-8110DN";

            ClickOnAPrinter(printer);

            EnterProductQuantity("1");

            if(IsPolandSystem()) return;
            EnterModelUnitCost();
            EnterOptionsQuantity0("1");
            EnterOptionCostPrice();

            const string buttonselector = @"button.btn.js-mps-product-configuration-submit";
            var button = driver.FindElement(By.CssSelector(buttonselector));
            button.Click();

        }

        public DealerProposalsCreateClickPricePage GoNextPage(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            WebDriver.Wait(DurationType.Second, 5);

            if (!IsPolandSystem())
            {
                const string linkselector = @"a.alert-link.js-mps-product-link";

                var count = GetElementsByCssSelector(linkselector).Count();

                SpecFlow.SetContext("DealerEditProductCount", count.ToString());
            }
           

            ProceedToProposalSummaryFromClickPrice();
            return GetInstance<DealerProposalsCreateClickPricePage>();
        }

        public void RemoveOldProduct(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            var linkselector = @"a.alert-link.js-mps-product-link";

            var links = GetElementsByCssSelector(linkselector);
            links.First().Click();

            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();

            WebDriver.Wait(DurationType.Second, 3);
            const string removebuttonselector = @"button.btn.js-mps-product-configuration-remove";
            var removebutton = driver.FindElement(By.CssSelector(removebuttonselector));
            removebutton.Click();

            //alert
            
            ClickAcceptOnJsAlert();
        }

        public IWebElement SelectPrinter(string printerName)
        {
            LoggingService.WriteLogOnMethodEntry(printerName);
            string containerSelector = string.Format("li#pc-{0}", printerName);
            string addButtonSelector = ".js-mps-product-open-add";

            var printerContainer = SeleniumHelper.FindElementByCssSelector(containerSelector);
            var addButton = SeleniumHelper.FindElementByCssSelector(printerContainer, addButtonSelector);

            SeleniumHelper.ClickSafety(addButton);
            
            // Note: Repeatedly click Add button if it doesn't succeed (Either the preloader or the add to proposal button, i.e, product configuration box doesn't load)
            while (!(SeleniumHelper.FindElementByCssSelector(printerContainer, PreloaderSelector).Displayed || 
                SeleniumHelper.FindElementByCssSelector(printerContainer, addToProposalButtonSelector).Displayed))
            {
                SeleniumHelper.ClickSafety(addButton);
            }

            return printerContainer;
        }

        public IWebElement PopulatePrinterDetails(string printerName,
            string printerPrice,
            string lowerTrayPrice,
            string installationPack,
            bool delivery,
            string servicePackType,
            string resourceServicePackTypeIncludedInClickPrice,
            string countryIso,
            out string margin,
            out string unitPrice,
            out IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerName, printerPrice, installationPack, delivery, servicePackType, resourceServicePackTypeIncludedInClickPrice, countryIso);
            // Filter the product
            ClearAndType(FilterProductElement, printerName);

            printerContainer = SelectPrinter(printerName);
            ScrollTo(printerContainer);
            var printerPriceInput = SeleniumHelper.FindElementByCssSelector(printerContainer, printerPriceSelector);
            var installationPackInput = SeleniumHelper.FindElementByCssSelector(printerContainer, installationPackInputSelector);
            var deliveryPriceInput = SeleniumHelper.FindElementByCssSelector(printerContainer, deliveryInputSelector);
            var addToProposalButton = SeleniumHelper.FindElementByCssSelector(printerContainer, addToProposalButtonSelector);
            var optionCostPriceInput = SeleniumHelper.IsElementDisplayed(printerContainer, optionCostPrice0Selector) ? SeleniumHelper.FindElementByCssSelector(printerContainer, optionCostPrice0Selector) : null ;
            var optionQuantity0Input = SeleniumHelper.IsElementDisplayed(printerContainer, optionQuantity0Selector) ? SeleniumHelper.FindElementByCssSelector(printerContainer, optionQuantity0Selector) : null;

            ClearAndType(printerPriceInput, printerPrice.ToString());

            if (delivery)
            {
                ClearAndType(deliveryPriceInput, "1");
            }
 
            if(string.IsNullOrWhiteSpace(installationPack) == false)
            {
                SeleniumHelper.SelectFromDropdownByText(installationPackInput, installationPack);
            }

            if( string.IsNullOrWhiteSpace(lowerTrayPrice) == false)
            {
                TestCheck.AssertIsNotNull(optionCostPriceInput,"lower tray price field not found");
                TestCheck.AssertIsNotNull(optionQuantity0Input, "lower tray quantity field not found");
                ClearAndType(optionQuantity0Input, "1");
                ClearAndType(optionCostPriceInput, lowerTrayPrice);
            }

            margin = SeleniumHelper.FindElementByCssSelector(printerContainer, printerMarginSelector).GetAttribute("value");            
            unitPrice = SeleniumHelper.FindElementByCssSelector(printerContainer, printerUnitPriceSelector).GetAttribute("value");

            // Validate that service pack margin & unit price input fields are disabled in case of "Included in Click Price" service packs
            if (servicePackType.Equals(resourceServicePackTypeIncludedInClickPrice))
            {
                if (!(SeleniumHelper.IsReadOnly(ServicePackMarginElement) && SeleniumHelper.IsReadOnly(ServicePackSellPriceElement)))
                {
                    throw new Exception("Service Pack Content did not get validated");
                }
            }

            
            return addToProposalButton;
        }

        public IWebElement PopulatePrinterDetailsforEPP(string printerName, out IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerName);
            // Filter the product
            ClearAndType(FilterProductElement, printerName);

            printerContainer = SelectPrinter(printerName);
            ScrollTo(printerContainer);
            var addToProposalButton = SeleniumHelper.FindElementByCssSelector(printerContainer, addToProposalButtonSelector);

            return addToProposalButton;
        }

        public void ClickAddProposalButton(IWebElement printerContainer, IWebElement addToProposalButton)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer, addToProposalButton);
            SeleniumHelper.ClickSafety(addToProposalButton);
            SeleniumHelper.FindElementByCssSelector(printerContainer, alertSuccessContinueSelector);
        }

        public List<string> RetrieveAllTotalPriceValues(IWebElement printerContainer, out string expectedTotalPrice)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            var totalPriceValues = new List<string>();
            var tableBodyContainer = SeleniumHelper.FindElementByCssSelector(printerContainer, printerTableBodySelector);
            var bodyRowElements = SeleniumHelper.FindRowElementsWithinTable(tableBodyContainer);
            foreach (var element in bodyRowElements)
            {
                var textTotalPrice = SeleniumHelper.FindElementByDataAttributeValue(element, printerTotalPriceDataAttributeSelector, "true").Text;
                totalPriceValues.Add(textTotalPrice);
            }
            var tableFootContainer = SeleniumHelper.FindElementByCssSelector(printerContainer, printerTableFootSelector);
            var textFootContainer = SeleniumHelper.FindElementByDataAttributeValue(tableFootContainer, printerTotalLinePriceDataAttributeSelector, "true").Text;
            expectedTotalPrice = textFootContainer;
            return totalPriceValues;
        }

        public void VerifyAddPrinterToProposal(string printerName)
        {
            LoggingService.WriteLogOnMethodEntry(printerName);
            var productAddedToProposal = SeleniumHelper.FindElementByCssSelector(productAddedToProposalSelector);
            TestCheck.AssertTextContains(printerName, productAddedToProposal.Text, string.Format("This product isn't displayed as added to Proposal:{0}", printerName));
        }

        public void RemoveTheProduct(string printerName)
        {
            LoggingService.WriteLogOnMethodEntry(printerName);
            string containerSelector = string.Format("li#pc-{0}", printerName);
            string removeButtonSelector = ".js-mps-product-configuration-remove";

            var printerContainer = SeleniumHelper.FindElementByCssSelector(containerSelector);
            var editButtonElement = SeleniumHelper.FindElementByCssSelector(printerContainer, addButtonSelector);

            SeleniumHelper.ClickSafety(editButtonElement);

            var removeButtonElement = SeleniumHelper.FindElementByCssSelector(removeButtonSelector);
            SeleniumHelper.ClickSafety(removeButtonElement);
            AcceptJavascriptPopupOnCompleteSetup();
        }

        public void VerifyRemovePrinterToProposal(string printerName)
        {
            LoggingService.WriteLogOnMethodEntry(printerName);

            try
            {
                SeleniumHelper.WaitUntil(d => !SeleniumHelper.FindElementByCssSelector(productAddedToProposalSelector).Text.Contains(printerName));
            }
            catch (Exception e)
            {
                TestCheck.AssertFailTest(string.Format("This product isn't removed from the proposal:{0} due to the error:{1}", printerName, e));
            }
        }

        public void AcceptJavascriptPopupOnCompleteSetup()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.AcceptJavascriptAlert();
        }
    }
}
