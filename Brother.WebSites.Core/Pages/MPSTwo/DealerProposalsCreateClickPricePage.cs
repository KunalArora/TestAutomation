using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateClickPricePage : BasePage
    {
        public static string URL = "/mps/dealer/proposals/create/click-price";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string paymentMethod = @".mps-paymentoptions";
        private const string clickPriceValue = @"[class='mps-col mps-top mps-clickprice-line2'][data-click-price-mono='true']";
        private const string clickPriceColourValue = @"[class='mps-col mps-top mps-clickprice-line2'][data-click-price-colour='true']";
        private const string clickPricePageNext = @"#content_1_ButtonNext";

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
        
        
        


        private IWebElement PaymentMethodElement()
        {
            return GetElementByCssSelector(paymentMethod, 10);
        }

        public void VerifyPaymentMethodIsDisplayed()
        {
            if (IsSpainSystem() || IsBelgiumSystem()) return;
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
            if (IsSpainSystem()|| IsBelgiumSystem()) return;
            if (option.Equals("Pay upfront") || option.Equals("im Voraus bezahlen") || option.Equals("Betale på forskud")
                || option.Equals("Paiement au démarrage du contrat") || option.Equals("Pagamento anticipato") || option.Equals("Förskott")
                || option.Equals("Betaling bij aanvang van het contract") || option.Equals("Płatność z góry"))
            {
                PayUpfrontElement().Click();
                WebDriver.Wait(DurationType.Second, 1);
            }
            else if (option.Equals("Included in Click Price") || option.Equals("über den Seitenpreis zahlen") || option.Equals("Inkluderet i klikpris")
                     || option.Equals("Inclus dans le coût à la page") || option.Equals("Incluso nel click") || option.Equals("Per utskrift")
                     || option.Equals("Inbegrepen in de clickprijs") || option.Equals("Inclus dans le prix click") || option.Equals("Wliczyć w cenę za wydruk strony")) 
            {
                InClickPriceElement().Click();
                WebDriver.Wait(DurationType.Second, 1);
            }
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
            IWebElement element = ColourVolumeElement(row);

            if (element == null)
                throw new NullReferenceException("Colour Volume field can not be found");

            ClearAndType(element, volume);
            WebDriver.Wait(DurationType.Second, 2);
            SpecFlow.SetContext(String.Format("ColourVolume{0}-{1}", row, DateTime.Now.ToString("yyyyMMddHHmmss")), volume);
        }

        private void EnterClickPriceValueAndCalculate(string volume, string colour, string row)
        {
            EnterMonoVolume(volume, row);
            EnterColourVolume(colour, row);
            WebDriver.Wait(DurationType.Second, 5);
            CalculateClickPriceElement.Click();
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

        public void CalculateEnteredErrorClickPrice(string volume)
        {
            EnterMonoVolumeQuantity(volume);
            WebDriver.Wait(DurationType.Second, 5);
            VerifyClickPriceValueIsNotDisplayed();
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
        
    }
}
