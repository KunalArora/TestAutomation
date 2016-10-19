using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Serialization;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateProductsPage : BasePage
    {

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
        
        

        
        private const string QuantityElementString = "[data-quantity=\"true\"]";
        private const string ServicePackElementString = ".mps-qa-service-pack";
        private const string InstallationQuantityElementString = ".mps-qa-installation";
        private const string DeliveryQuantityElementString = ".mps-qa-delivery";
        
        
        private IWebElement FaxCheckboxElement()
        {
            string element = "input[data-name=\"fax\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement ScannerCheckboxElement()
        {
            string element = "input[data-name=\"scanner\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement DuplexCheckboxElement()
        {
            string element = "input[data-name=\"duplex\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement AdditionalTrayCheckboxElement()
        {
            string element = "input[data-name=\"additionalTray\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement A4CheckboxElement()
        {
            string element = "input[data-name=\"a4\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement A3CheckboxElement()
        {
            var element = "input[data-name=\"a3\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement MonoCheckboxElement()
        {
            string element = "input[data-name=\"mono\"]";

            return GetElementByCssSelector(element);
        }

        private IWebElement ColourCheckboxElement()
        {
            string element = "input[data-name=\"colour\"]";

            return GetElementByCssSelector(element);
        }

        public void TickRelineSearchFax()
        {
            IWebElement element = FaxCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchScanner()
        {
            IWebElement element = ScannerCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchDuplex()
        {
            IWebElement element = DuplexCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchAdditionalTray()
        {
            IWebElement element = AdditionalTrayCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchA4()
        {
            IWebElement element = A4CheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchA3()
        {
            IWebElement element = A3CheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchMono()
        {
            IWebElement element = MonoCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
            if (!element.Selected)
                element.Click();
        }

        public void TickRelineSearchColour()
        {
            IWebElement element = ColourCheckboxElement();

            WebDriver.Wait(DurationType.Second, 3);
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
            for(var i=0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterFaxproperty.Displayed, 
                    "Some printers displayed do not contain fax properties");
            }
        }

        public void IsAllPrintersHaveScanFacility()
        {
            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterScanproperty.Displayed, 
                    "Some printers displayed do not contain scan properties");
            }

        }

        public void IsAllPrintersHaveDuplexFacility()
        {
            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterDuplexproperty.Displayed, 
                    "Some printers displayed do not contain duplex properties");
            }
        }

        public void IsAllPrintersHaveAdditionalTrayFacility()
        {
            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterTrayproperty.Displayed, 
                    "Some printers displayed do not contain tray properties");
            }
        }

        public void IsAllPrintersHaveA4Facility()
        {

            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterA4property.Displayed,
                    "Some printers displayed do not contain tray properties");
            }
        }

        public void IsAllPrintersHaveA3Facility()
        {

            for (var i = 0; i <= PropertyContainerElement.Count; i++)
            {
                TestCheck.AssertIsEqual(true, PrinterA3property.Displayed,
                    "Some printers displayed do not contain tray properties");
            }
        }

        public void IsAllPrintersHaveMonoFacility()
        {
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
            WebDriver.Wait(DurationType.Second, 1);
            if (ProductsScreenAlertElement == null) throw new
                NullReferenceException("Unable to locate text on Product Screen");

            AssertElementPresent(ProductsScreenAlertElement, "Product Screen Instruction");
        }

        public void IsDeviceScreenDisplayed()
        {
            WebDriver.Wait(DurationType.Second, 1);
            TestCheck.AssertIsEqual(true, 
                DeviceScreenValidator.Displayed, 
                "Device screen is not displayed");
            WaitForElementToBeClickableByCssSelector("a[href=\"/sign-out\"]", 5, 10);
        }

        public void TypeIntoRHSFreeTextFilter(string model)
        {
            WebDriver.Wait(DurationType.Second, 4);
            ClearAndType(InputSearchProductElement, model);
            WebDriver.Wait(DurationType.Second, 1);
        }

        private IList<IWebElement> DisplayedAllPrintersByFilteringOfFreeTextElement()
        {
            string element = ".js-mps-product-open-container[style=\"display: list-item;\"]";

            return GetElementsByCssSelector(element);
        }

        private IList<IWebElement> DisplayedPrintersAfterFreeTextFiltering(string model)
        {
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
            string element = ".mps-product-configuration-container-flat";

            return GetElementsByCssSelector(element);
        }

        private IList<IWebElement> DisplayedAllPrintersWithImagesElement()
        {
            string element = ".mps-product-img";

            return GetElementsByCssSelector(element);
        }

        public void VerifyThatAllProductsDisplayedAsAFlatListWithNoImages()
        {
            WebDriver.Wait(DurationType.Second, 1);
            AssertElementPresent(DisplayedAllPrintersAsFlatListElement()[0], "Displayed with images");
        }

        public void VerifyThatAllProductsDisplayedAsAWithImages()
        {
            WebDriver.Wait(DurationType.Second, 1);
            AssertElementPresent(DisplayedAllPrintersWithImagesElement()[0], "Displayed as flat list");
        }

        public void ChangeProductViewToWithImages()
        {
            if (withImagesClickButtonElement == null)
                throw new NullReferenceException("Button to change product view is not displayed");

            withImagesClickButtonElement.Click();
        }

        public void ChangeProductViewToFlatList()
        {
            if (flatListClickButtonElement == null)
                throw new NullReferenceException("Button to change product view is not displayed");

            flatListClickButtonElement.Click();
        }

        private IWebElement OptionQuantity0Element()
        {
            return GetElementByCssSelector("#OptionQuantity0", 5);
        }

        private IWebElement OptionCostPrice0Element()
        {
            return GetElementByCssSelector("#OptionCostPrice0", 5);
        }

        private IWebElement OptionsSellPrice0Element()
        {
            return GetElementByCssSelector("OptionSellPrice0", 5);
        }

        private IWebElement OptionsMargin0Element()
        {
            return GetElementByCssSelector("OptionMargin0", 5);
        }

        public void StoreDefaultProductConfiguration()
        {
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
            if (delivery.Equals("Yes"))
            {
                ClearAndType(DeliveryCostPriceElement, "100");
            }
        }

        public void SetInstallationDetails()
        {
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
            return GetElementByCssSelector(flatItemsIdentifier, 10);
        }

        public void ClickOnAPrinter(string printer)
        {
            SpecFlow.SetContext("InitialProductPageText", ProductsScreenAlertElement.Text);

            var element = IsElementPresent(ProductFlatListAddElement()) ? "#pc-{0} .js-mps-product-open" : "#pc-{0} .js-mps-product-open-add";

            element = string.Format(element, printer.Equals(string.Empty) ? MpsUtil.PrinterUnderTest() : printer);

            var printerClickable = GetElementByCssSelector(element);

            printerClickable.Click();
            WebDriver.Wait(DurationType.Second, 1);

        }

        private IEnumerable<IWebElement> QtyForAccessoriesElement()
        {
            const string element = ".mps-qa-option .mps-txt-r [name=\"OptionQuantity\"][data-mps-val-numeric-min]";

            return GetElementsByCssSelector(element);
        }

        public void IsQtyForAccessoriesAreDefaultToZero()
        {
            foreach (IWebElement element in QtyForAccessoriesElement())
            {
                TestCheck.AssertIsEqual("0", element.GetAttribute("data-mps-val-numeric-min"), "Quantity For Accessory is not defaulted zero");
            }
        }

        private string GetValueOfProductMarginValueElement()
        {
            return ProductMarginValueElement.GetAttribute("value");
        }

        public void StrictVerifyMarginFieldValues()
        {
            string before = SpecFlow.GetContext("HardwareDefaultMargin");
            string after = GetValueOfProductMarginValueElement();
            TestCheck.AssertIsEqual(before, after, "Hardware Default Margin value is not equal to the value of Local Office Dealer Default");
        }

        public void EnterAllMarginRandomly()
        {
            EnterProductMargin(Math.Round((new Random().NextDouble()+1) * new Random().Next(5, 20), 1).ToString());
            EnterOptionMargin(Math.Round((new Random().NextDouble() + 1) * new Random().Next(5, 20), 1).ToString(), "0");
            EnterOptionsQuantity0("1");
            EnterDeliveryMargin(Math.Round((new Random().NextDouble() + 1) * new Random().Next(5, 20), 1).ToString());
            EnterInstallationPackMargin(Math.Round((new Random().NextDouble() + 1) * new Random().Next(5, 20), 1).ToString());
            EnterServicePackMargin(Math.Round((new Random().NextDouble() + 1) * new Random().Next(5, 20), 1).ToString());
        }

        public void EnterProductMargin(string value)
        {
            SpecFlow.SetContext("EnteredProductMargin", value);
            ClearAndType(ProductMarginElement, value);
            ProductMarginElement.SendKeys(Keys.Tab);
        }

        public void EnterOptionMargin(string value, string row)
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

        public void EnterDeliveryMargin(string value)
        {
            SpecFlow.SetContext("EnteredDeliveryMargin", value);
            ClearAndType(DeliveryMarginElement, value);
            DeliveryMarginElement.SendKeys(Keys.Tab);
        }

        public void EnterInstallationPackMargin(string value)
        {
            SpecFlow.SetContext("EnteredInstallationPackMargin", value);
            ClearAndType(InstallationPackMarginElement, value);
            InstallationPackMarginElement.SendKeys(Keys.Tab);
        }

        public void EnterServicePackMargin(string value)
        {
            SpecFlow.SetContext("EnteredServicePackMargin", value);
            ClearAndType(ServicePackMarginElement, value);
            ServicePackMarginElement.SendKeys(Keys.Tab);
        }

        public void EnterProductQuantity(string value)
        {
            ClearAndType(ProductQuantityElement, value);
        }

        public void EnterProductCostPrice(string value)
        {
            ClearAndType(ProductCostPriceElement, value);
        }

        public void EnterProductSellPrice(string value)
        {
            ClearAndType(ProductSellPriceElement, value);
            ProductSellPriceElement.SendKeys(Keys.Tab);
        }

        public void EnterOptionsQuantity0(string value)
        {
            ClearAndType(OptionsQuantityElement, value);
        }

        public void EnterDeliverySellPrice(string value)
        {
            ClearAndType(DeliverySellPriceElement, value);
            DeliverySellPriceElement.SendKeys(Keys.Tab);
        }

        public void AddAllDetailsToProposal()
        {
            ScrollTo(AddToProposalElement);
            AddToProposalElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        private IWebElement AddToProposalButtonElement()
        {
            const string element = ".js-mps-product-configuration-submit.disabled";

            return GetElementByCssSelector(element);
        }

        public void IsAddToProposalButtonGrayout()
        {
            ScrollTo(AddToProposalElement);
            AssertElementPresent(AddToProposalButtonElement(), "add to proposal grayout");
        }

        private string GetValueOfDeliveryMarginValueElement()
        {
            return ProductMarginValueElement.GetAttribute("value");
        }

        public void IsDealerMarginRevertedToTheOriginalValue()
        {
            string before = SpecFlow.GetContext("EnteredDeliveryMargin");
            string after = GetValueOfDeliveryMarginValueElement();
            TestCheck.AssertIsNotEqual(before, after, "Delivery Margin value is not reverted to the original value");
        }

        public void IsDealerMarginRetainedByDealerAdminDefaultMargin()
        {
            string before = SpecFlow.GetContext("DealerAdminHardwareDefaultMargin");
            string after = ProductMarginElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Dealer Admin Hardware default margin value is not retained");
        }

        private IWebElement InstallationPackUnitCostLessThanErrorElement()
        {
            const string element = ".alert-danger";

            return GetElementByCssSelector(element);
        }

        public void IsInstallationPackUnitCostLessThanErrorDisplayed()
        {
            AssertElementPresent(InstallationPackUnitCostLessThanErrorElement(), "installation pack unit cost less than error");
        }

        public void EnterInstallationPackCostPrice(string value)
        {
            ClearAndType(InstallationPackCostPriceElement, value);
        }

        public decimal InstallationPackCostPrice()
        {

            
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
            var priceText = InstallationPackCostPriceElement.GetAttribute("value");
            var decimalVal = Decimal.Parse(priceText);

            return decimalVal;

        }

        public void EnterInstallationPackCostPriceLessThanDefault()
        {
            var price = InstallationPackUnitPrice();
            EnterInstallationPackCostPrice((price - 1).ToString());
        }

        public void IsNotTheProductAddedToTheProposal()
        {
            AssertElementPresent(CloseWithoutSavingElement, "Close without saving button element");            
        }

        private IWebElement FullDeviceScreenElement()
        {
            const string element = ".js-mps-product-configuration[data-price-hardware=\"true\"]";
            return GetElementByCssSelector(element);
        }

        public void IsFullDeviceScreenDisplayed()
        {
            AssertElementPresent(FullDeviceScreenElement(), "Full device screen is not displayed");
        }

        private IWebElement ReducedDeviceScreenElement()
        {
            const string element = ".js-mps-product-configuration[data-price-hardware=\"false\"]";

            return GetElementByCssSelector(element);
        }

        public void IsReducedDeviceScreenDisplayed()
        {
            AssertElementPresent(ReducedDeviceScreenElement(), "Reduced device screen is not displayed");
        }

        private bool hogeIsFullDeviceScreenDisplayed()
        {
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
            ScrollTo(ProposalSummaryScreenElement);
            ProposalSummaryScreenElement.Click();
            AssertElementPresent(SummaryConfirmationTextElement, "Product Confirmation Message");
        }

        private IList<IWebElement> TotalPriceForAllItem()
        {
            const string element = "[data-total-price=\"true\"]";

            return GetElementsByCssSelector(element);
        }

        private IWebElement TotalLinePriceElement()
        {
            const string element = "[data-total-line-price=\"true\"]";

            return GetElementByCssSelector(element);
        }

        public void IsGrandTotalPriceCorrect()
        {
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
            string Quantity = OptionsQuantityElement.GetAttribute("value");
            string UnitPrice = OptionsSellPriceElement.GetAttribute("value");
            decimal calcurated = Convert.ToDecimal(Quantity) * Convert.ToDecimal(UnitPrice);
            string TotalStr = TotalForAllAccessoriesElement()[0].Text;
            decimal Total = MpsUtil.GetValue(TotalStr);
            TestCheck.AssertIsEqual(calcurated, Total, "TotalPriceOfAccessory is not correct");
        }

        public void FillProductDetails()
        {
            EnterProductQuantity("2");
            EnterProductCostPrice("50");
            EnterProductSellPrice("60");
            EnterOptionsQuantity0("3");
            VerifyMarginFieldValues();
        }

        public void VerifyMarginFieldValues()
        {
            WebDriver.Wait(DurationType.Second, 2);
            var marginText = ProductMarginElement.Text;
            TestCheck.AssertIsNotNull(ProductMarginElement.GetAttribute("value"), "Product Margin Element");
            TestCheck.AssertIsEqual(false, marginText.StartsWith("-"), "Margin Text starts with -");
        }

        private IList<IWebElement> TotalForAllAccessoriesElement()
        {
            const string element = ".mps-qa-option  [data-total-price=\"true\"]";

            return GetElementsByCssSelector(element);
        }

        public void IsTotalForAllAccessoriesAreDefaultToZero()
        {
            foreach (IWebElement element in TotalForAllAccessoriesElement())
                TestCheck.AssertIsEqual((decimal)0, MpsUtil.GetValue(element.Text), "Total for all accessories are not defaulted zero");
        }

        public DealerProposalsCreateClickPricePage NextButtonClick()
        {
            NextButtonElement.Click();
            return GetTabInstance<DealerProposalsCreateClickPricePage>(Driver);
        }

        public void ChangeDeviceInstallationType()
        {
            SelectFromDropdownByValue(GetElementByCssSelector("#InstallationPackId"), "1");
            var installationCost = InstallationSRPElement.Text;

            ClearAndType(InstallationPackCostPriceElement, MpsUtil.GetValue(installationCost).ToString());
            WebDriver.Wait(DurationType.Second, 1);

            SetInstallationDetails();
        }

        public void SelectDeviceInstallationType(string type)
        {
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

            if(!IsBigAtSystem())
            {
                SelectFromDropdownByValue(GetElementByCssSelector("#InstallationPackId"), install);
            }
           
        }

        private string GetValueInstallationSrpElement()
        {
            return InstallationSRPElement.Text;
        }
        public void VerifyThatInstallationSrpValueChange()
        {
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
            string before = SpecFlow.GetContext("ProductSellPrice");
            string after = ProductSellPriceElement.GetAttribute("value");
            TestCheck.AssertIsNotEqual(before, after, "Product sell price should changed");
        }

        public void IsProductMarginChanged()
        {
            string before = SpecFlow.GetContext("ProductMargin");
            string after = ProductMarginElement.GetAttribute("value");
            TestCheck.AssertIsNotEqual(before, after, "Product sell price should changed");
        }

        public void IsNotProductMarginChanged()
        {
            string before = SpecFlow.GetContext("ProductMargin");
            string after = ProductMarginElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Product margin should not change");
        }

        public void IsNotProductUnitCostChanged()
        {
            string before = SpecFlow.GetContext("ProductCostPrice");
            string after = ProductCostPriceElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Product cost price should not change");
        }

        public void IsNotDeliveryCostPriceChanged()
        {
            string before = SpecFlow.GetContext("DeliveryCostPrice");
            string after = DeliveryCostPriceElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Delivery cost price should not change");
        }

        public void IsNotDeliverySellPriceChanged()
        {
            string before = SpecFlow.GetContext("DeliverySellPrice");
            string after = DeliverySellPriceElement.GetAttribute("value");
            TestCheck.AssertIsEqual(before, after, "Delivery sell price should not change");
        }

        private IList<IWebElement> ModelNameElement()
        {
            string element = ".mps-product-configuration .col-xs-8 h4";

            return GetElementsByCssSelector(element);
        }

        private bool SearchModelName(string model)
        {
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
            TestCheck.AssertIsEqual(true, SearchModelName(model), "model not found");
        }

        public void IsNotModelFound(string model)
        {
            WebDriver.Wait(DurationType.Second, 5);
            TestCheck.AssertIsEqual(false, SearchModelName(model), "model found");            
        }

        private IList<IWebElement> AllSRPElement()
        {
            const string element = ".mps-qa-srp";

            return GetElementsByCssSelector(element);
        }

        public void IsAllSRPNotEditable()
        {
            TestCheck.AssertIsNotEqual(0, AllSRPElement().Count, "srp field nothing");
            IList<IWebElement> element = GetElementsByCssSelector(".mps-qa-srp input", 5);
            TestCheck.AssertIsEqual(0, element.Count, "element is not null");
            if (IsElementPresent(ProductQuantityElement))
                SpecFlow.SetContext("ProductQuantity", ProductQuantityElement.GetAttribute("value"));
        }

        private IWebElement DeliveryQuantityElement()
        {
            string element = String.Format("{0} {1}", DeliveryQuantityElementString, QuantityElementString);

            return GetElementByCssSelector(element);
        }

        public void IsDeliveryQuantityNotEditable()
        {
            string element = String.Format("{0} {1} input", DeliveryQuantityElementString, QuantityElementString);

            TestCheck.AssertIsNotEqual(0, DeliveryQuantityElement(), "Unable to locate Delivery Quantity field");
            if (GetElementByCssSelector(element, 5) == null)
                TestCheck.AssertIsNotNull(DeliveryQuantityElement(), "Delivery Quantity is editable");
        }

        public string OptionSrpText()
        {
            return OptionSrpElement.Text;
        }

        public void EnterOptionCostPrice()
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
        public void EnterModelUnitCost()
        {
            //if (!ModelSrpElement.Text.Contains("£")) return;
            if (IsAustriaSystem() || IsGermanSystem() || IsSwedenSystem()
                || IsDenmarkSystem())
            {
                //do nothing
            } 
            else if (IsNorwaySystem() || IsPolandSystem())
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
            var value = text.Replace(" ", "");

            if (IsNorwaySystem())
            {
                value = value.Replace("kr", "");
            }
            else if (IsPolandSystem())
            {
                value = value.Replace("zł", "").TrimEnd();
            }

            return value;
        }


        public void SetProductCostPrice()
        {
            if (IsElementPresent(ProductCostPriceElement))
                SpecFlow.SetContext("ProductCostPrice", ProductCostPriceElement.GetAttribute("value"));
        }

        private IWebElement InstallationQuantityElement()
        {
            var element = String.Format("{0} {1}", InstallationQuantityElementString, QuantityElementString);

            return GetElementByCssSelector(element);
        }

        public void IsInstallationQuantityNotEditable()
        {
            var element = String.Format("{0} {1} input", InstallationQuantityElementString, QuantityElementString);

            TestCheck.AssertIsNotEqual(0, InstallationQuantityElement(), "Unable to locate Installation Quantity field");
            if (GetElementByCssSelector(element, 5) == null)
                TestCheck.AssertIsNotNull(InstallationQuantityElement(), "Installation Quantity is editable");
        }

        private IWebElement ServicepackQuantityElement()
        {
            var element = String.Format("{0} {1}", ServicePackElementString, QuantityElementString);

            return GetElementByCssSelector(element);
        }

        public void IsServicepackQuantityNotEditable()
        {
            var element = String.Format("{0} {1} input", ServicePackElementString, QuantityElementString);

            TestCheck.AssertIsNotEqual(0, ServicepackQuantityElement(), "Unable to locate Servicepack Quantity field");
            if (GetElementByCssSelector(element, 5) == null)
                TestCheck.AssertIsNotNull(ServicepackQuantityElement(), "Servicepack Quantity field is editable");
        }

        public void VerifyThatProductQuantityElementChanged()
        {
            var before = SpecFlow.GetContext("ProductQuantity");
            var after = ProductQuantityElement.GetAttribute("value");
            TestCheck.AssertIsNotEqual(before, after, "ProductQuantity value is changed");
        }

        public void IsFullDeviceScreenDisplayedForPrinterSelected()
        {
            WebDriver.Wait(DurationType.Second, 5);
            AssertElementPresent(FullDeviceScreenElement(), "Full device screen is not displayed");
        }

        public void IsReducedDeviceScreenDisplayedForPrinterSelected()
        {
            AssertElementPresent(ReducedDeviceScreenElement(), "Reduced device screen is not displayed");
        }

        public void VerifyTypeOfDeviceScreenDisplayed(string option)
        {
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
            ScrollTo(ClickPriceScreenElement);
            ClickPriceScreenElement.Click();

            return GetTabInstance<DealerProposalsCreateClickPricePage>(Driver);
        }

        public DealerProposalsCreateClickPricePage MoveToClickPriceScreenWithButton()
        {
            ScrollTo(MoveToClickPriceButton);
            MoveToClickPriceButton.Click();

            return GetTabInstance<DealerProposalsCreateClickPricePage>(Driver);
        }

        public void VerifyProductAdditionConfirmationMessage()
        {
            WebDriver.Wait(DurationType.Millisecond, 2000);
            ScrollTo(ProductsScreenAlertElement);
            var storedProductScreenText = SpecFlow.GetContext("InitialProductPageText");
            var finalProductScreenText = ProductsScreenAlertElement.Text;
            TestCheck.AssertIsEqual(false, storedProductScreenText.Equals(finalProductScreenText), "Product Screen Text");
        }

        private IWebElement PaymentMethodElement()
        {
            return GetElementByCssSelector(paymentMethod, 10);
        }

        public void VerifyPaymentMethodIsDisplayed()
        {
            TestCheck.AssertIsEqual(true, PaymentMethodElement().Displayed, "Payment method is not displayed");
        }

        public void VerifyPaymentMethodIsNotDisplayed()
        {

            if (!IsElementPresent(PaymentMethodElement()))
            {
                TestCheck.AssertIsEqual(false, PaymentMethodElement().Displayed, "Payment method is displayed");
            }
        }

        private IWebElement MonoVolumeElementClickPrice()
        {
            return GetElementByCssSelector(monoVolume);
        }

        private IWebElement ColourVolumeElementClickPrice()
        {
            return GetElementByCssSelector(colourVolume);
        }

        private void CalculateClickPrice(string volume, string colour)
        {
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
            if (monoVolumeDropdownElement == null)
                throw new NullReferenceException("ClickVolumeElement can not be found");
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");

            SelectFromDropdown(monoVolumeDropdownElement, volume);
            CalculateClickPriceElement.Click();
        }

        private IList<IWebElement> ClickPriceValue()
        {
            return GetElementsByCssSelector(clickPriceValue);
        }

        private IList<IWebElement> ClickPriceColourValue()
        {
            return GetElementsByCssSelector(clickPriceColourValue);
        }

        private IWebElement ClickPriceNextButton()
        {
            return GetElementByCssSelector(clickPricePageNext);
        }

        private void ProceedToProposalSummaryFromClickPrice()
        {
            ClickPriceNextButton().Click();
        }

        private void VerifyClickPriceValueIsDisplayed()
        {
            for (var i = 0; i < ClickPriceValue().Count; i++)
            {
                TestCheck.AssertIsEqual(false, 
                    ClickPriceValue().ElementAt(i).Text.Equals(string.Empty), 
                    "Price Value is Empty");
            }
        }

        public void CalculateClickPriceAndProceed(string volume, string colour)
        {
            MoveToClickPriceScreen();
            CalculateClickPrice(volume, colour);
            WebDriver.Wait(DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();
            ProceedToProposalSummaryFromClickPrice();

        }


        private void EnterMonoVolumeQuantity(string volume)
        {
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
            var str = RemoveUnites(item);
            var d = int.Parse(str);
            d += 1;
            return d.ToString();
        }

        private string UpdateDoubleNumber(string item)
        {
            var str = RemoveUnites(item);
            var d = double.Parse(str);
            d += 0.1;
            return d.ToString("F2");
        }

        private string RemoveUnites(string str)
        {
            string[] units = {"£", " %"};

            return units.Aggregate(str, (current, u) => current.Replace(u, ""));
        }

        private void UpdateExistingProduxts(IWebDriver driver, string selector)
        {
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
    }
}
