using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateProductsPage : BasePage
    {
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
        private IWebElement InputSearchProductElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-display-option[data-display-option=\"flat\"]")]
        private IWebElement flatListClickButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-display-option[data-display-option=\"default\"]")]
        private IWebElement withImagesClickButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-alert")]
        private IWebElement ProductsScreenAlertElement;
        [FindsBy(How = How.Id, Using = "Quantity")]
        private IWebElement ProductQuantityElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputMonoVolumeBreaks_0")]
        private IWebElement monoVolumeDropdownElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputColourVolumeBreaks_0")]
        private IWebElement colourVolumeDropdownElement;
        [FindsBy(How = How.Id, Using = "CostPrice")]
        private IWebElement ProductCostPriceElement;
        [FindsBy(How = How.Id, Using = "SellPrice")]
        private IWebElement ProductSellPriceElement;
        [FindsBy(How = How.Id, Using = "Margin")]
        private IWebElement ProductMarginElement;
        [FindsBy(How = How.Name, Using = "MarginFullPrecision")]
        private IWebElement ProductMarginValueElement;
        [FindsBy(How = How.Id, Using = "InstallationPackCostPrice")]
        private IWebElement InstallationPackCostPriceElement;
        [FindsBy(How = How.Id, Using = "InstallationPackMargin")]
        private IWebElement InstallationPackMarginElement;
        [FindsBy(How = How.Id, Using = "InstallationPackSellPrice")]
        private IWebElement InstallationPackSellPriceElement;
        [FindsBy(How = How.Id, Using = "OptionQuantity0")]
        private IWebElement OptionsQuantityElement;
        [FindsBy(How = How.Id, Using = "OptionCostPrice0")]
        private IWebElement OptionsCostPriceElement;
        [FindsBy(How = How.Id, Using = "OptionSellPrice0")]
        private IWebElement OptionsSellPriceElement;
        [FindsBy(How = How.Id, Using = "OptionMargin0")]
        private IWebElement OptionsMarginElement;
        [FindsBy(How = How.Id, Using = "DeliveryCostPrice")]
        private IWebElement DeliveryCostPriceElement;
        [FindsBy(How = How.Id, Using = "DeliveryMargin")]
        private IWebElement DeliveryMarginElement;
        [FindsBy(How = How.Id, Using = "DeliverySellPrice")]
        private IWebElement DeliverySellPriceElement;
        [FindsBy(How = How.Id, Using = "ClickPriceMonoCoverage")]
        private IWebElement ClickPriceCoverageElement;
        [FindsBy(How = How.Id, Using = "ClickPriceMonoVolume")]
        private IWebElement ClickPriceVolumeElement;
        [FindsBy(How = How.Id, Using = "ClickPriceMonoMargin")]
        private IWebElement ClickPriceMarginElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-configuration-submit")]
        private IWebElement AddToProposalElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-configuration-close")]
        private IWebElement CloseWithoutSavingElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/create/summary\"]")]
        private IWebElement ProposalSummaryScreenElement;
        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        private IWebElement SummaryConfirmationTextElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        private IWebElement NextButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonCalculate")]
        private IWebElement CalculateClickPriceElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-installation .mps-qa-srp")]
        private IWebElement InstallationSRPElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/create/click-price\"]")]
        private IWebElement ClickPriceScreenElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputMonoVolume_0']")]
        private IWebElement MonoVolumeInputFieldElement;



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

        public void IsProductScreenTextDisplayed()
        {
            WebDriver.Wait(DurationType.Second, 5);
            if (ProductsScreenAlertElement == null) throw new
                NullReferenceException("Unable to locate text on Product Screen");

            AssertElementPresent(ProductsScreenAlertElement, "Product Screen Instruction");
        }

        public void TypeIntoRHSFreeTextFilter(string model)
        {
            WebDriver.Wait(Helper.DurationType.Second, 3);
            ClearAndType(InputSearchProductElement, model);
        }

        private IList<IWebElement> DisplayedAllPrintersByFilteringOfFreeTextElement()
        {
            string element = ".js-mps-product-open-container[style=\"display: list-item;\"";

            return GetElementsByCssSelector(element);
        }

        public void IsAllPrintersReturnedThatSearched(string model)
        {
            int count = 0;

            foreach (IWebElement element in DisplayedAllPrintersByFilteringOfFreeTextElement())
            {
                string modelWithPC = element.GetAttribute("id");
                if (modelWithPC.Contains(model)) count++;
            }

            TestCheck.AssertIsEqual(count, DisplayedAllPrintersByFilteringOfFreeTextElement().Count,
                "Displayed all printers are not invalid");
        }

        private IList<IWebElement> DisplayedAllPrintersAsFlatListElement()
        {
            string element = ".mps-product-group";

            return GetElementsByCssSelector(element);
        }

        private IList<IWebElement> DisplayedAllPrintersWithImagesElement()
        {
            string element = ".mps-product-img";

            return GetElementsByCssSelector(element);
        }

        public void VerifyThatAllProductsDisplayedAsAFlatListWithNoImages()
        {
            WebDriver.Wait(Helper.DurationType.Second, 3);
            AssertElementPresent(DisplayedAllPrintersAsFlatListElement()[0], "Displayed with images");
        }

        public void VerifyThatAllProductsDisplayedAsAWithImages()
        {
            WebDriver.Wait(Helper.DurationType.Second, 3);
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

        public void StoreDefaultProductConfiguration()
        {
            if (IsElementPresent(ProductQuantityElement))
                SpecFlow.SetContext("ProductQuantity", ProductQuantityElement.GetAttribute("value"));
            if (IsElementPresent(ProductCostPriceElement))
                SpecFlow.SetContext("ProductCostPrice", ProductCostPriceElement.GetAttribute("value"));
            if (IsElementPresent(ProductMarginElement))
                SpecFlow.SetContext("ProductMargin", ProductMarginElement.GetAttribute("value"));
            if (IsElementPresent(ProductSellPriceElement))
                SpecFlow.SetContext("ProductSellPrice", ProductSellPriceElement.GetAttribute("value"));
            if (IsElementPresent(OptionsQuantityElement))
                SpecFlow.SetContext("OptionsQuantity", OptionsQuantityElement.GetAttribute("value"));
            if (IsElementPresent(DeliveryCostPriceElement))
                SpecFlow.SetContext("DeliveryCostPrice", DeliveryCostPriceElement.GetAttribute("value"));
            if (IsElementPresent(DeliveryMarginElement))
                SpecFlow.SetContext("DeliveryMargin", DeliveryMarginElement.GetAttribute("value"));
            if (IsElementPresent(DeliverySellPriceElement))
                SpecFlow.SetContext("DeliverySellPrice", DeliverySellPriceElement.GetAttribute("value"));
            if (IsElementPresent(InstallationSRPElement))
                SpecFlow.SetContext("InstallationSRP", GetValueInstallationSRPElement());
            if (IsElementPresent(InstallationPackCostPriceElement))
                SpecFlow.SetContext("InstallationPackCostPrice", InstallationPackCostPriceElement.GetAttribute("value"));
            if (IsElementPresent(InstallationPackMarginElement))
                SpecFlow.SetContext("InstallationPackMargin", InstallationPackMarginElement.GetAttribute("value"));
            if (IsElementPresent(InstallationPackSellPriceElement))
                SpecFlow.SetContext("InstallationPackSellPrice", InstallationPackSellPriceElement.GetAttribute("value"));
        }

        private IWebElement ProductFlatListAddElement()
        {
            return GetElementByCssSelector(flatItemsIdentifier, 10);
        }

        public void ClickOnAPrinter(string printer)
        {
            SpecFlow.SetContext("InitialProductPageText", ProductsScreenAlertElement.Text);

            var element = "";

            if (IsElementPresent(ProductFlatListAddElement()))
            {
                element = "#pc-{0} .js-mps-product-open";
            }
            else
            {
                element = "#pc-{0} .js-mps-product-open-add";
            }

            element = string.Format(element, printer.Equals(string.Empty) ? MpsUtil.PrinterUnderTest() : printer);

            var printerClickable = GetElementByCssSelector(element);

            printerClickable.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);

        }

        private IList<IWebElement> QTYForAccessoriesElement()
        {
            const string element = ".mps-qa-option .mps-txt-r [name=\"OptionQuantity\"][data-mps-val-numeric-min]";

            return GetElementsByCssSelector(element);
        }

        public void IsQTYForAccessoriesAreDefaultToZero()
        {
            foreach (IWebElement element in QTYForAccessoriesElement())
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
   

        public void IsFullDeviceScreenDisplayedForPrinterSelected()
        {
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
                IsFullDeviceScreenDisplayedForPrinterSelected();
            }
            else if (option.Equals("Reduced"))
            {
                IsReducedDeviceScreenDisplayedForPrinterSelected();
            }
        }

        public void EnterDeliveryMargin(string value)
        {
            SpecFlow.SetContext("EnteredDeliveryMargin", value);
            ClearAndType(DeliveryMarginElement, value);
            DeliveryMarginElement.SendKeys(Keys.Tab);
        }

        public void AddAllDetailsToProposal()
        {
            ScrollTo(AddToProposalElement);
            AddToProposalElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

        private IWebElement AddToProposalButtonElement()
        {
            const string element = ".js-mps-product-configuration-submit[disabled=\"disabled\"]";

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

        public int InstallationPackCostPrice()
        {
            var priceText = InstallationPackCostPriceElement.GetAttribute("value");

            return Convert.ToInt32(priceText);
        }

        public void EnterInstallationPackCostPriceLessThanDefault()
        {
            int price = InstallationPackCostPrice();
            EnterInstallationPackCostPrice(Convert.ToString(price - 1));
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

            TestCheck.AssertIsEqual(sum, MpsUtil.GetValue(TotalLinePriceElement().Text), "The sum of the Total Price is not equal to the Grand Total Price displayed");
        }

        public void FillProductDetails()
        {
            EnterProductQuantity("2");
            EnterProductCostPrice("50");
            EnterProductSellPrice("60");
            VerifyMarginFieldValues();
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

        public void EnterProductMargin(string value)
        {
            ClearAndType(ProductMarginElement, value);
            ProductMarginElement.SendKeys(Keys.Tab);
        }

        public void VerifyMarginFieldValues()
        {
            WebDriver.Wait(Helper.DurationType.Second, 2);
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

        public void CalculateClickPriceAndNext()
        {
            CalculateClickPriceElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
            NextButtonElement.Click();
        }

        public void NextButtonClick()
        {
            NextButtonElement.Click();
        }

        public void ChangeDeviceInstallationType()
        {
            SelectFromDropdownByValue(GetElementByCssSelector("#InstallationPackId"), "2");
        }

        private string GetValueInstallationSRPElement()
        {
            return InstallationSRPElement.Text;
        }
        public void VerifyThatInstallationSRPValueChange()
        {
            string hoge = GetValueInstallationSRPElement();
            TestCheck.AssertIsNotEqual(SpecFlow.GetContext("InstallationSRP"), GetValueInstallationSRPElement(), "Installation SRP not changed");
            TestCheck.AssertIsNotEqual(SpecFlow.GetContext("InstallationPackCostPrice"), InstallationPackCostPrice().ToString(), "Installation Unit Cost not changed");
            TestCheck.AssertIsNotEqual(SpecFlow.GetContext("InstallationPackSellPrice"), InstallationPackSellPriceElement.GetAttribute("value"), "Installation Unit Price not changed");
        }

        public void EnterDeliverySellPrice(string value)
        {
            ClearAndType(DeliverySellPriceElement, value);
            DeliverySellPriceElement.SendKeys(Keys.Tab);
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
            string element = ".mps-product-configuration .media-heading";

            return GetElementsByCssSelector(element);
        }
        public void IsModelFound(string model)
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
            TestCheck.AssertIsEqual(true, found, "model not found");
        }

        public void MoveToClickPriceScreen()
        {
            ScrollTo(ClickPriceScreenElement);
            ClickPriceScreenElement.Click();
        }
        
        public void VerifyProductAdditionConfirmationMessage()
        {
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

        private void VerifyColourClickPriceValueIsDisplayed()
        {
            for (var i = 0; i < ClickPriceColourValue().Count; i++)
            {
                TestCheck.AssertIsEqual(false, ClickPriceColourValue().ElementAt(i).Text.Equals(string.Empty), "Price Colour Value is Empty");
            }

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
                TestCheck.AssertIsEqual(false, ClickPriceValue().ElementAt(i).Text.Equals(string.Empty), "Price Value is Empty");
            }
        }

        public void CalculateClickPriceAndProceed(string volume, string colour)
        {
            MoveToClickPriceScreen();
            CalculateClickPrice(volume, colour);
            WebDriver.Wait(Helper.DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();
            ProceedToProposalSummaryFromClickPrice();

        }

        public void CalculateEPPClickPriceAndProceed(string volume)
        {
            MoveToClickPriceScreen();
            CalculateEPPClickPrice(volume);
            WebDriver.Wait(Helper.DurationType.Second, 5);
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
            WebDriver.Wait(Helper.DurationType.Second, 2);
            CalculateClickPriceElement.Click();
        }


        public void CalculateEnteredClickPriceAndProceed(string volume)
        {
            MoveToClickPriceScreen();
            EnterMonoVolumeQuantity(volume);
            WebDriver.Wait(Helper.DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();
            ProceedToProposalSummaryFromClickPrice();

        }

    }
}
