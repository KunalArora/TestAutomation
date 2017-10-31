﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateClickPricePage : BasePage, IPageObject
    {
        public static string URL = "/mps/dealer/proposals/create/click-price";
        private const string _validationElementSelector = ".mps-clickprice-group";
        private const string _url = "/mps/dealer/proposals/create/click-price";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }
        

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string paymentMethod = @".mps-paymentoptions";
        private const string clickPriceValue = @"[class='mps-col mps-top mps-clickprice-line2'][data-click-price-mono='true']";
        private const string clickPriceColourValue = @"[class='mps-col mps-top mps-clickprice-line2'][data-click-price-colour='true']";
        private const string clickPricePageNext = @"#content_1_ButtonNext";
        private const string ClickPricePath = @"C:\DataTest\ClickPrice";
        private const string CsvFile = @"ClickPrice.csv";
        private const string IsMonoOnly = "data-mono-only";

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/create/summary\"]")]
        public IWebElement ProposalSummaryScreenElement;
        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        public IWebElement SummaryConfirmationTextElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputMonoVolumeBreaks_0")]
        public IWebElement monoVolumeDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_LineItems_InputMonoVolumeBreaks_]")]
        public IList<IWebElement> MultiMonoVolumeDropdownElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputColourVolumeBreaks_0")]
        public IWebElement colourVolumeDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_LineItems_InputColourVolumeBreaks_]")]
        public IList<IWebElement> MultiColourVolumeDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputMonoVolume_0']")]
        public IWebElement MonoVolumeInputFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id*='content_1_LineItems_InputMonoVolume_']")]
        public IList<IWebElement> MultiMonoVolumeInputFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputColourVolume_0']")]
        public IWebElement ColourVolumeInputFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id*='content_1_LineItems_InputColourVolume_']")]
        public IList<IWebElement> MultiColourVolumeInputFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputMonoCoverage_0']")]
        public IWebElement MonoCoverageInputFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputColourCoverage_0']")]
        public IWebElement ColourCoverageInputFieldElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonCalculate")]
        public IWebElement CalculateClickPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement ProceedOnClickPricePageElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-calculate.disabled")]
        public IWebElement DisabledCalculateButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".alert-danger.mps-alert.js-mps-alert strong")]
        public IWebElement WarningAlertElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_1_LineItems_InputMonoMargin_\"]")]
        public IList<IWebElement> MonoClickPriceMarginElements;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_1_LineItems_InputColourMargin_\"]")]
        public IList<IWebElement> ColourClickPriceMarginElements;
        [FindsBy(How = How.CssSelector, Using = ".col-sm-12.mps-paymentoptions")]
        public IWebElement ServicePackContainerElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputServicePaymentOption")]
        public IWebElement ServicePackHiddenValueElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_LineItems_ServicePackUnitCost_0")]
        public IWebElement ServicePackUnitCostElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_LineItems_ServicePackUnitPrice_0")]
        public IWebElement ServicePackUnitPriceElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_LineItems_ServicePackTotalPrice_0")]
        public IWebElement ServicePackTotalPriceElement;




        public void IsServiceInClickLineDisplayedOnClickPricePage()
        {
            TestCheck.AssertIsEqual(true, ServicePackUnitCostElement.Displayed, "Service Pack Unit Cost is not displayed");
            TestCheck.AssertIsEqual(true, ServicePackUnitPriceElement.Displayed, "Service Pack Unit Price is not displayed");
            TestCheck.AssertIsEqual(true, ServicePackTotalPriceElement.Displayed, "Service Pack Unit Total Price is not displayed");
        }
        

        private IWebElement PaymentMethodElement()
        {
            return GetElementByCssSelector(paymentMethod, 10);
        }

        public void VerifyPaymentMethodIsDisplayed()
        {
            if (IsSpainSystem() 
                || IsBelgiumSystem() 
                || IsNetherlandSystem()
                || IsPolandSystem()) return;
            TestCheck.AssertIsEqual(true, PaymentMethodElement().Displayed, "Payment method is not displayed");
        }

        public void VerifyPaymentMethodIsNotDisplayed()
        {
            var element = PaymentMethodElement();
            if (element != null)
                TestCheck.AssertIsNotNull(element, "Payment method is displayed");
        }

        private IWebElement PayUpfrontElement()
        {
            return GetElementByCssSelector("#content_1_InputServicePaymentOptions_Input_0");
        }

        private IWebElement InClickPriceElement()
        {
            return GetElementByCssSelector("#content_1_InputServicePaymentOptions_Input_1");
        }

        public void PayServicePackMethod(string option)
        {
            //if (GetElementByCssSelector(".col-sm-12.mps-paymentoptions").Displayed)

            try
            {
                if (IsSpainSystem() || IsBelgiumSystem() || IsPolandSystem() || IsIrelandSystem() || IsNetherlandSystem()) return;
                if (
                        option.Equals("Pay upfront") 
                        || option.Equals("im Voraus bezahlen") 
                        || option.Equals("Betale på forskud")
                        || option.Equals("Paiement au démarrage du contrat") 
                        || option.Equals("Pagamento anticipato") 
                        || option.Equals("Förskott")
                        || option.Equals("Betaling bij aanvang van het contract") 
                        || option.Equals("Płatność z góry")
                        || option.Equals("Maksu etukäteen")
                        || option.Equals("På forskudd")
                    
                    )
                {
                    PayUpfrontElement().Click();
                    WebDriver.Wait(DurationType.Second, 1);
                }
                else if (
                            option.Equals("Included in Click Price")
                            || option.Equals("über den Seitenpreis zahlen") 
                            || option.Equals("Inkluderet i klikpris")
                            || option.Equals("Inclus dans le coût à la page") 
                            || option.Equals("Incluso nel click") 
                            || option.Equals("Per utskrift")
                            || option.Equals("Inbegrepen in de clickprijs") 
                            || option.Equals("Inclus dans le prix click") 
                            || option.Equals("Wliczyć w cenę za wydruk strony")
                            || option.Equals("Über den Seitenpreis zahlen")
                            || option.Equals("Sisältyy klikkihintaan")
                            || option.Equals("I klikk")
                    )
                {
                    InClickPriceElement().Click();
                    WebDriver.Wait(DurationType.Second, 1);
                }
            }
            catch (NullReferenceException nre)
            {
                var servicePackType = ServicePackHiddenValueElement.GetAttribute("value");
                servicePackType = PreSelectedServicePack(servicePackType);
                MsgOutput(String.Format("The service pack pre-selected is {0}", servicePackType));

            }
            

           
        }

        private string PreSelectedServicePack(string pre)
        {
            switch (pre)
            {
                case "1"     :
                    pre = "Upfront";
                    break;

                case "2":
                    pre = "LeaseRental";
                    break;

                case "3":
                    pre = "Monthly";
                    break;

                case "4":
                    pre = "InClick";
                    break;
            }

            return pre;
        }

        private IWebElement ColourVolumeElementClickPrice(string row)
        {
            string element = String.Format("#content_1_LineItems_InputColourVolumeBreaks_{0}", row);

            return GetElementByCssSelector(element);
        }

        public IWebElement MonoVolumeElementClickPrice(string row)
        {
            string element = String.Format("#content_1_LineItems_InputMonoVolumeBreaks_{0}",row);

            return GetElementByCssSelector(element, 5);
        }

        private void SelectClickPriceAndCalculate(string volume, string colour, string row)
        {
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");

            SelectMonoVolume(volume, row);
            SelectColorVolume(colour, row);
            WebDriver.Wait(DurationType.Second, 1);
            CalculateClickPriceElement.Click();
            WebDriver.Wait(DurationType.Second, 4);

            int r = int.Parse(row);
            var monovalue = ClickPriceValue().Skip(r).First().Text;
            var colourvalue = ClickPriceColourValue().Skip(r).First().Text;
            SpecFlow.SetContext("ClickPriceMonoValue#" + row, monovalue);
            SpecFlow.SetContext("ClickPriceColourValue#" + row, colourvalue);
        }

       
        public DealerProposalsCreateSummaryPage CalculateMultipleClickPriceAndProceed(string volume, string colour)
        {
            
            CalculateMultipleClickPrice(volume, colour, "0");
            CalculateMultipleClickPrice(volume, colour, "1");


            CalculateClickPriceElement.Click();
            WebDriver.Wait(DurationType.Second, 5);
            return ProceedToProposalSummaryFromClickPrice();
        }



        private void SelectMultipleClickPriceAndCalculate(string volume, string colour, string row)
        {
            

            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");

            SelectMonoVolume(volume, row);
            SelectColorVolume(colour, row);
            WebDriver.Wait(DurationType.Second, 1);
            

        }

        public void CalculateMultipleClickPrice(string volume, string colour, string row, bool resetBeforeInput = false)
        {
            var instance = new DealerProposalsCreateClickPricePage();

            if (instance.MonoVolumeElement(row) != null)
                EnterMultipleClickPriceValueAndCalculate(volume, colour, row);
            if (instance.MonoVolumeElementClickPrice(row) != null)
            {
                if (resetBeforeInput)
                    ResetClickPrice(row);

                SelectMultipleClickPriceAndCalculate(volume, colour, row);
            }
            //VerifyClickPriceValueIsDisplayed();
        }


        public DealerProposalsCreateSummaryPage CalculateSelectedMultipleClickPrice(string mono, string colour)
        {
            var monoCount = MultiMonoVolumeDropdownElement.Count;
            var colourCount = MultiColourVolumeDropdownElement.Count;

            for (var i = 0; i < monoCount; i++)
            {
                SelectFromDropdown(MultiMonoVolumeDropdownElement.ElementAt(i), mono);
            }

            for (var i = 0; i < colourCount; i++)
            {
                SelectFromDropdown(MultiColourVolumeDropdownElement.ElementAt(i), colour);
            }

            EnterClickPriceMargin("16");

            WebDriver.Wait(DurationType.Second, 2);

            CalculateClickPriceElement.Click();

            WebDriver.Wait(DurationType.Second, 5);
            ClickPriceNextButton().Click();

            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);
        }


        public DealerProposalsCreateSummaryPage CalculateEnteredMultipleClickPrice(string mono, string colour)
        {
            var monoCount = MultiMonoVolumeInputFieldElement.Count;
            var colourCount = MultiColourVolumeInputFieldElement.Count;

            for (var i = 0; i < monoCount; i++)
            {
                ClearAndType(MultiMonoVolumeInputFieldElement.ElementAt(i), mono);
            }

            for (var i = 0; i < colourCount; i++)
            {
                ClearAndType(MultiColourVolumeInputFieldElement.ElementAt(i), colour);
            }

            EnterClickPriceMargin("16");

            WebDriver.Wait(DurationType.Second, 2);

            CalculateClickPriceElement.Click();

            WebDriver.Wait(DurationType.Second, 5);
            ClickPriceNextButton().Click();

            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);
        }

        

        public void EnterClickPriceMargin(string value)
        {
            if (MonoClickPriceMarginElements != null && (MonoClickPriceMarginElements != null || MonoClickPriceMarginElements.Any()))
            {
                foreach (var monoClickPriceMarginElement in MonoClickPriceMarginElements)
                {
                    ClearAndType(monoClickPriceMarginElement, value);
                }
                
            }

            if (ColourClickPriceMarginElements != null && (ColourClickPriceMarginElements != null || ColourClickPriceMarginElements.Any()))
            {
                foreach (var colourClickPriceMarginElement in ColourClickPriceMarginElements)
                {
                    ClearAndType(colourClickPriceMarginElement, value);
                }

            }
            
        }

        private void EnterMultipleClickPriceValueAndCalculate(string volume, string colour, string row)
        {
            EnterMonoVolume(volume, row);
            EnterColourVolume(colour, row);
            WebDriver.Wait(DurationType.Second, 5);
            CalculateClickPriceElement.Click();
        }

        public void CalculateClickPriceAndStoreVal()
        {
            CalculateClickPriceElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void StoreMonoClickPrice()
        {
            SpecFlow.SetContext("ClickPriceMonoValue", ClickPriceValue().First().Text);
        }

        public void StoreColourClickPrice()
        {
            SpecFlow.SetContext("ClickPriceColourValue", ClickPriceColourValue().First().Text);
        }

        public void IsSpecialPricingNewMonoClickPriceDisplayed()
        {
            var displayedMono = ClickPriceValue().First().Text;
            var enterSpecialPricing = SpecFlow.GetContext("SpecialPriceMonoClickPrice");

            TestCheck.AssertIsEqual(true, displayedMono.Equals(enterSpecialPricing), 
                                string.Format("{0} is the not same as {1}", displayedMono, enterSpecialPricing));
        }

        public void IsSpecialPricingNewColourClickPriceDisplayed()
        {
            var displayedColour = ClickPriceValue().First().Text;
            var enterSpecialPricing = SpecFlow.GetContext("SpecialPriceColourClickPrice");

            TestCheck.AssertIsEqual(true, displayedColour.Equals(enterSpecialPricing),
                                string.Format("{0} is the not same as {1}", displayedColour, enterSpecialPricing));
        }

        public void SelectMonoVolume(string volume, string row)
        {
            if (monoVolumeDropdownElement == null)
                throw new NullReferenceException("monoVolumeDropdownElement can not be found");
            IWebElement element = MonoVolumeElementClickPrice(row);
            if (IsElementPresent(element))
                SelectFromDropdown(element, volume);
        }

        public void SelectColorVolume(string volume, string row)
        {
            if (colourVolumeDropdownElement == null)
                throw new NullReferenceException("monoVolumeDropdownElement can not be found");
            IWebElement element = ColourVolumeElementClickPrice(row);
            if (IsElementPresent(element))
                SelectFromDropdown(element, volume);
        }

        private IList<IWebElement> ClickPriceColourValue()
        {
            return GetElementsByCssSelector(clickPriceColourValue);
        }

        private IList<IWebElement> ClickPriceValue()
        {
            return GetElementsByCssSelector(clickPriceValue);
        }

        public void VerifyClickPriceValueIsDisplayed()
        {
            for (var i = 0; i < ClickPriceValue().Count; i++)
            {
                TestCheck.AssertIsEqual(false, ClickPriceValue().ElementAt(i).Text.Equals(string.Empty), "Price Value is Empty");
            }
        }

        public void VerifyClickPriceValueIsNotDisplayed()
        {
            for (var i = 0; i < ClickPriceValue().Count; i++)
            {
                TestCheck.AssertIsEqual(true, ClickPriceValue().ElementAt(i).Text.Equals(string.Empty), "Price Value is Empty");
            }
        }

        private void VerifyClickPriceColourValueIsDisplayed()
        {
            for (var i = 0; i < ClickPriceValue().Count; i++)
            {
                TestCheck.AssertIsEqual(false, ClickPriceColourValue().ElementAt(i).Text.Equals(string.Empty), "Price Value is Empty");
            }
        }

        private IWebElement ClickPriceNextButton()
        {
            return GetElementByCssSelector(clickPricePageNext);
        }

        public DealerProposalsCreateSummaryPage ClickAndProceedOnDealerProposalsCreateSummaryPage()
        {
            ClickPriceNextButton().Click();

            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);
        }

        public DealerProposalsCreateSummaryPage ProceedToProposalSummaryFromClickPrice()
        {
            var mono = ClickPriceValue().First().Text;
            var colour = ClickPriceColourValue().First().Text;
            SpecFlow.SetContext("ClickPriceMonoValue", mono);
            SpecFlow.SetContext("ClickPriceColourValue", colour);
            
            ClickPriceNextButton().Click();

            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);
        }

        public DealerProposalsCreateSummaryPage CalculateClickPriceAndProceed(string volume, string colour)
        {
            //MoveToClickPriceScreen();
            CalculateClickPrice(volume, colour, "0");
            //WebDriver.Wait(Helper.DurationType.Second, 1);
            SpecFlow.SetContext("ClickPriceMonoValue", ClickPriceValue().First().Text);
            SpecFlow.SetContext("ClickPriceColourValue", ClickPriceColourValue().First().Text);
			//VerifyClickPriceValueIsDisplayed();
            WebDriver.Wait(DurationType.Second, 2);
            return ProceedToProposalSummaryFromClickPrice();
        }

        public void CalculateClickPrice(string volume, string colour)
        {
            //MoveToClickPriceScreen();
            CalculateClickPrice(volume, colour, "0");
            //WebDriver.Wait(Helper.DurationType.Second, 1);
            SpecFlow.SetContext("ClickPriceMonoValue", ClickPriceValue().First().Text);
            SpecFlow.SetContext("ClickPriceColourValue", ClickPriceColourValue().First().Text);
            //VerifyClickPriceValueIsDisplayed();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void CalculateClickPrice(string volume, string colour, string row, bool resetBeforeInput = false)
        {
            if (MonoVolumeElement(row) != null)
                EnterClickPriceValueAndCalculate(volume, colour, row);
            if (MonoVolumeElementClickPrice(row) != null)
            {
                if (resetBeforeInput)
                    ResetClickPrice(row);

                SelectClickPriceAndCalculate(volume, colour, row);
            }
            //VerifyClickPriceValueIsDisplayed();
        }

        private void ResetClickPrice(string row)
        {
            SelectMonoVolume("0", row);
            SelectColorVolume("250", row);
        }

        public void CalculateClickPrice()
        {
            CalculateClickPriceElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
            MonoClickPriceValue();
            ColourClickPriceValue();
        }

        public DealerProposalsCreateSummaryPage ForceGoThrowThisTab(IWebDriver driver, bool fillVolume = false)
        {
            if (fillVolume)
            {
                FillVolume(driver, ".mps-line1", "Mono");
                FillVolume(driver, ".mps-line2", "Colour");
            }

            if (CalculateClickPriceElement != null && CalculateClickPriceElement.Displayed)
                CalculateClickPrice();

            return ProceedToProposalSummaryFromClickPrice();
        }

        private void FillVolume(IWebDriver driver, string lineselector, string type)
        {
            var lines = GetElementsByCssSelector(lineselector);
            var inputselectorformat = "#content_1_LineItems_Input{0}Volume_{1}";

            for (int i = 0; i < lines.Count(); i++)
            {
                var inputselector = string.Format(inputselectorformat, type, i);
                var input = GetElementByCssSelector(lines[i], inputselector, 5);
                if(input == null) continue;

                if (IsElementPresent(input))
                    SelectFromDropdown(input, "1000");
                WebDriver.Wait(DurationType.Millisecond, 100);
            }
        }

        public DealerProposalsCreateSummaryPage MoveToProposalSummaryScreen()
        {
            ScrollTo(ProposalSummaryScreenElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ProposalSummaryScreenElement);
//            AssertElementPresent(SummaryConfirmationTextElement, "Product Confirmation Message");
            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);

        }

        public void EnterCoverageAndVolumeThenCalculate(string coverage, string volume)
        {
            EnterMonoCoverage(coverage);
            EnterMonoVolumeQuantity(volume);
        }

        private void EnterMonoVolumeQuantity(string volume)
        {
            if (MonoVolumeInputFieldElement == null)
                throw new NullReferenceException("Mono Volume field can not be found");
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");

            MonoVolumeInputFieldElement.SendKeys(volume);
            MonoVolumeInputFieldElement.SendKeys(Keys.Tab);
            WebDriver.Wait(DurationType.Second, 2);
            CalculateClickPriceElement.Click();
        }

        public void EnterMonoCoverage(string coverage)
        {
            if (MonoCoverageInputFieldElement == null)
                throw new NullReferenceException("Mono Coverage field can not be found");

            ClearAndType(MonoCoverageInputFieldElement, coverage);
            WebDriver.Wait(DurationType.Second, 2);
        }

        public IWebElement MonoVolumeElement(string row)
        {
            string str = String.Format("#content_1_LineItems_InputMonoVolume_{0}", row);

            return GetElementByCssSelector(str, 5);
        }

        public IWebElement MonoVolumeDropdownElement(string row)
        {
            string str = String.Format("#content_1_LineItems_InputMonoVolumeBreaks_{0}", row);
            return SeleniumHelper.FindElementByCssSelector(str, 5);
        }

        public IWebElement ColourVolumeDropdownElement(string row)
        {
            string str = String.Format("#content_1_LineItems_InputColourVolumeBreaks_{0}", row);

            return GetElementByCssSelector(str, 5);
        }

        public IWebElement MonoCoverageElement(string row)
        {
            string str = String.Format("#content_1_LineItems_InputMonoCoverage_{0}", row);

            return SeleniumHelper.FindElementByCssSelector(str, 5);
        }

        public IWebElement ColourCoverageElement(string row)
        {
            string str = String.Format("#content_1_LineItems_InputColourCoverage_{0}", row);

            return GetElementByCssSelector(str, 5);
        }

        public void EnterMonoVolume(string volume, string row)
        {
            IWebElement element = MonoVolumeElement(row);

            if (element == null)
                throw new NullReferenceException("Mono Volume field can not be found");

            ClearAndType(element, volume);
            WebDriver.Wait(Helper.DurationType.Second, 2);
            SpecFlow.SetContext(String.Format("MonoVolume{0}-{1}", row, DateTime.Now.ToString("yyyyMMddHHmmss")), volume);
        }

        public void EnterColourCoverage(string coverage)
        {
            if (ColourCoverageInputFieldElement == null)
                throw new NullReferenceException("Mono Coverage field can not be found");

            ClearAndType(ColourCoverageInputFieldElement, coverage);
            WebDriver.Wait(Helper.DurationType.Second, 2);
        }

        private IWebElement ColourVolumeElement(string row)
        {
            string str = String.Format("#content_1_LineItems_InputColourVolume_{0}", row);

            return GetElementByCssSelector(str, 5);
        }

        public void EnterColourVolume(string volume, string row)
        {
            try
            {
                IWebElement element = ColourVolumeElement(row);

                if (element == null)
                    throw new NullReferenceException("Colour Volume field can not be found");

                ClearAndType(element, volume);
                WebDriver.Wait(DurationType.Second, 2);
                SpecFlow.SetContext(String.Format("ColourVolume{0}-{1}", row, DateTime.Now.ToString("yyyyMMddHHmmss")), volume);
            }
            catch (NullReferenceException nre)
            {
                string.Format("Colour volume is not found because {0}", nre);
            }
            catch (WebDriverException web)
            {
                string.Format("Colour volume is not found because {0}", web);
            }
            
        }

        private void EnterClickPriceValueAndCalculate(string volume, string colour, string row)
        {
            EnterMonoVolume(volume, row);
            EnterColourVolume(colour, row);
            WebDriver.Wait(DurationType.Second, 5);
            CalculateClickPriceElement.Click();
        }


        public DealerProposalsCreateSummaryPage CalculateEnteredClickPriceForMonoAndColourAndProceed(string volume, string colour)
        {
            //            MoveToClickPriceScreen();
            EnterColourVolume(colour, "0");
            EnterMonoVolumeQuantity(volume);
            WebDriver.Wait(DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();
            SpecFlow.SetContext("ClickPriceMonoValue", ClickPriceValue().First().Text);
            SpecFlow.SetContext("ClickPriceColourValue", ClickPriceColourValue().First().Text);

            return ProceedToProposalSummaryFromClickPrice();
        }

        public DealerProposalsCreateSummaryPage CalculateEnteredClickPriceAndProceed(string volume)
        {
//            MoveToClickPriceScreen();
            EnterMonoVolumeQuantity(volume);
            WebDriver.Wait(DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();
            SpecFlow.SetContext("ClickPriceMonoValue", ClickPriceValue().First().Text);

            return ProceedToProposalSummaryFromClickPrice();
        }

        public void WritePrinterParametersToCsv(string printer, string servicePayment, string monoCoverage, string colourCoverage, string qty,
            string monoVol, string colourVol, string duration)
        {
            //before your loop
            var csv = new StringBuilder();
            StreamWriter log;

            var monoPrice = SpecFlow.GetContext("ClickPriceMonoValue");
            string colourPrice;

            try
            {
                colourPrice = SpecFlow.GetContext("ClickPriceColourValue");
            }
            catch (KeyNotFoundException)
            {
                colourPrice = "Nil";
            }
                

            var newLine = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\"", 
                                            printer, servicePayment, monoCoverage, colourCoverage, qty, monoVol, colourVol, duration, monoPrice, colourPrice);
            //csv.AppendLine(newLine);

            if (!Directory.Exists(ClickPricePath))
            {
                Directory.CreateDirectory(ClickPricePath);
            }

            var filePath = Path.Combine(ClickPricePath, CsvFile);

            

            if (!File.Exists(filePath))
            {
                log = new StreamWriter(filePath);
                log.WriteLine("\"Printer\",\"ServicePayment\",\"MonoCoverage\",\"ColourCoverage\",\"Quantity\",\"MonoVol\",\"ColourVol\",\"Duration\",\"MonoPrice\",\"ColourPrice\"");
            }
            else
            {
                log = File.AppendText(filePath);
            }

            // Write to the file:
            
            log.WriteLine(newLine);
            
            // Close the stream:
            log.Close();

        }

        public void CalculateEnteredClickPrice(string volume)
        {
            //            MoveToClickPriceScreen();
            EnterMonoVolumeQuantity(volume);
            WebDriver.Wait(DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();
            SpecFlow.SetContext("ClickPriceMonoValue", ClickPriceValue().First().Text);
        }

        public void CalculateEnteredErrorClickPrice(string volume)
        {
            EnterMonoVolumeQuantity(volume);
            WebDriver.Wait(DurationType.Second, 5);
            VerifyClickPriceValueIsNotDisplayed();
        }

        public void CalculateEnteredMonoAndColourClickPrice(string mono, string colour)
        {
            //            MoveToClickPriceScreen();
            EnterColourVolume(colour, "0");
            EnterMonoVolumeQuantity(mono);
            WebDriver.Wait(DurationType.Second, 5);
            StoreMonoClickPrice();
            StoreColourClickPrice();
        }

        public void IsLargeEstimatedVolumeErrorMessageDisplayed()
        {
            if(WarningAlertElement == null)
                throw new Exception("Expected warning not displayed");

            TestCheck.AssertIsEqual(true, WarningAlertElement.Displayed, "Warning error is not displayed");
        }

        public void IsCalculateButtonDisabled()
        {
            if(DisabledCalculateButtonElement == null)
                throw new Exception("Calculate button is not disabled");

            TestCheck.AssertIsEqual(true, DisabledCalculateButtonElement.Displayed, "Calculate button is not disabled");
        }

        public void IsCoverageErrorDisplayed()
        {
            const string element = ".js-mps-alert";

            AssertElementPresent(GetElementByCssSelector(element, 5), "Coverage error is not displayed");
        }

        private void MonoClickPriceValue()
        {
            var str = ".mps-clickprice-group [data-click-price-mono=\"true\"]";
            var i = 0;
            foreach (var element in GetElementsByCssSelector(str, 5))
            {
                var val = element.Text;
                if (!val.Equals("")) 
                    SpecFlow.SetContext(String.Format("MonoClickPrice{0}-{1}", i, DateTime.Now.ToString("yyyyMMddHHmmss")), val);
                i++;
            }
        }

        private void ColourClickPriceValue()
        {
            string str = ".mps-clickprice-group [data-click-price-colour=\"true\"]";
            string val = "";
            int i = 0;
            IList<IWebElement> elements = GetElementsByCssSelector(str, 5);
            if (elements.Count != 0)
            {
                foreach (IWebElement element in elements)
                {
                    val = element.Text;
                    if (!val.Equals("")) 
                        SpecFlow.SetContext(String.Format("ColourClickPrice{0}-{1}", i, DateTime.Now.ToString("yyyyMMddHHmmss")), val);
                    i++;
                }
            }
        }

        public void VerifyThatClickPriceValueForVolumeValueBecomeSmallerAndSmaller()
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, object> item in SpecFlow.GetEnumerator())
            {
                if (item.Key.Contains("MonoClickPrice"))
                    list.Add(item.Value.ToString());
            }
            if (Convert.ToDouble(list[0]) < Convert.ToDouble(list[1]) ||
                Convert.ToDouble(list[1]) < Convert.ToDouble(list[2]))
                TestCheck.AssertFailTest("Click Price calculation is invalid");

        }

        public void VerifyClickPriceValueForVolumeValueIsAllEqual()
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, object> item in SpecFlow.GetEnumerator())
            {
                if (item.Key.Contains("MonoClickPrice"))
                    list.Add(item.Value.ToString());
            }
            if (Convert.ToDouble(list[0]) != Convert.ToDouble(list[1]) ||
                Convert.ToDouble(list[1]) != Convert.ToDouble(list[2]))
                TestCheck.AssertFailTest("Click Price calculation is invalid");
        }

        public void VerifyThatClickPriceDisplayedForTheColourIsChangedAccordingly()
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, object> item in SpecFlow.GetEnumerator())
            {
                if (item.Key.Contains("ColourClickPrice"))
                    list.Add(item.Value.ToString());
            }
            if (Convert.ToDouble(list[0]) == Convert.ToDouble(list[1]))
                TestCheck.AssertFailTest("Colour Click Price calculation is invalid");
        }

        public void VerifyThatClickPriceDisplayedForTheMonoIsChangedAccordingly()
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, object> item in SpecFlow.GetEnumerator())
            {
                if (item.Key.Contains("MonoClickPrice"))
                    list.Add(item.Value.ToString());
            }
            if (Convert.ToDouble(list[0]) == Convert.ToDouble(list[1]))
                TestCheck.AssertFailTest("Colour Click Price calculation is invalid");
            
        }

        public void VerifyThatClickPriceForMonoIsNotChanged(string row)
        {
            List<string> list = new List<string>();

            string key = String.Format("MonoClickPrice{0}", row);
            foreach (KeyValuePair<string, object> item in SpecFlow.GetEnumerator())
            {
                if (item.Key.Contains(key))
                    list.Add(item.Value.ToString());
            }
            if (Convert.ToDouble(list[0]) != Convert.ToDouble(list[1]))
                TestCheck.AssertFailTest("Mono Click Price calculation is invalid");
            
        }

        public void VerifyThatClickPriceForMonoIsChanged(string row)
        {
            List<string> list = new List<string>();

            string key = String.Format("MonoClickPrice{0}", row);
            foreach (KeyValuePair<string, object> item in SpecFlow.GetEnumerator())
            {
                if (item.Key.Contains(key))
                    list.Add(item.Value.ToString());
            }
            if (Convert.ToDouble(list[0]) == Convert.ToDouble(list[1]))
                TestCheck.AssertFailTest("Mono Click Price calculation is invalid");
        }

        public void VerifyThatClickPriceForColourIsChanged(string row)
        {
            List<string> list = new List<string>();

            string key = String.Format("ColourClickPrice{0}", row);
            foreach (KeyValuePair<string, object> item in SpecFlow.GetEnumerator())
            {
                if (item.Key.Contains(key))
                    list.Add(item.Value.ToString());
            }
            if (Convert.ToDouble(list[0]) == Convert.ToDouble(list[1]))
                TestCheck.AssertFailTest("Mono Click Price calculation is invalid");
        }

        public void VerifyThatClickPriceForColourIsNotChanged(string row)
        {
            List<string> list = new List<string>();

            string key = String.Format("ColourClickPrice{0}", row);
            foreach (KeyValuePair<string, object> item in SpecFlow.GetEnumerator())
            {
                if (item.Key.Contains(key))
                    list.Add(item.Value.ToString());
            }
            if (Convert.ToDouble(list[0]) != Convert.ToDouble(list[1]))
                TestCheck.AssertFailTest("Mono Click Price calculation is invalid");
        }

        public IWebElement getPrinterElement(string printerName)
        {
            string attributeName = printerName;
            var printerElement = SeleniumHelper.FindElementByDataAttributeValue("model", printerName, 10);
            return printerElement;
        }
        
        public void PopulatePrinterCoverageAndVolume(string printerName, int coverageMono, int coverageColour, int volumeMono, int volumeColour )
        {
            var printerContainer = getPrinterElement(printerName);
            string id = printerContainer.GetAttribute("id");
            string row = id.Substring(id.Length - 1, 1);
            string isMonoOnly = printerContainer.GetAttribute(IsMonoOnly);

            var monoCoverageInput = MonoCoverageElement(row);
            var monoVolumeDropdownInput =  MonoVolumeDropdownElement(row);

            ClearAndType(monoCoverageInput, coverageMono.ToString());
            SeleniumHelper.SelectFromDropdownByText(monoVolumeDropdownInput, volumeMono.ToString());


            if (isMonoOnly == "False")
            {
                var colourCoverageInput = ColourCoverageElement(row);
                var colourVolumeDropdownInput = ColourVolumeDropdownElement(row);

                ClearAndType(colourCoverageInput, coverageColour.ToString());
                SeleniumHelper.SelectFromDropdownByText(colourVolumeDropdownInput, volumeColour.ToString());
            }
        }

        public bool VerifyClickPriceValues()
        {
            SeleniumHelper.WaitUntilElementAppears(clickPricePageNext, 10);
            try
            {
                VerifyClickPriceValueIsDisplayed();
                return true;
            }
            catch
            {
                //catch Assertion exception
                return false;
            }                
        }
    }
}
