using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
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
        private IWebElement ProposalSummaryScreenElement;
        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        private IWebElement SummaryConfirmationTextElement;
        [FindsBy(How = How.Id, Using = "content_1_InputServicePaymentOptions_Input_0")]
        private IWebElement PayUpfrontElement;
        [FindsBy(How = How.Id, Using = "content_1_InputServicePaymentOptions_Input_1")]
        private IWebElement InClickPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputMonoVolumeBreaks_0")]
        private IWebElement monoVolumeDropdownElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputColourVolumeBreaks_0")]
        private IWebElement colourVolumeDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputMonoVolume_0']")]
        private IWebElement MonoVolumeInputFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputColourVolume_0']")]
        private IWebElement ColourVolumeInputFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputMonoCoverage_0']")]
        private IWebElement MonoCoverageInputFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputColourCoverage_0']")]
        private IWebElement ColourCoverageInputFieldElement;
        
        [FindsBy(How = How.Id, Using = "content_1_ButtonCalculate")]
        private IWebElement CalculateClickPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        private IWebElement ProceedOnClickPricePageElement;

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
            IWebElement element = PaymentMethodElement();
            if (element != null)
                TestCheck.AssertIsNotNull(element, "Payment method is displayed");
        }

        public void PayServicePackMethod(string option)
        {
            if (option.Equals("Pay upfront"))
            {
                PayUpfrontElement.Click();
                WebDriver.Wait(DurationType.Second, 5);
            }
            else if (option.Equals("Included in Click Price"))
            {
                InClickPriceElement.Click();
                WebDriver.Wait(DurationType.Second, 5);
            }
        }

        private IWebElement ColourVolumeElementClickPrice(string row)
        {
            string element = String.Format("#content_1_LineItems_InputColourVolumeBreaks_{0}", row);

            return GetElementByCssSelector(element);
        }

        private IWebElement MonoVolumeElementClickPrice(string row)
        {
            string element = String.Format("#content_1_LineItems_InputMonoVolumeBreaks_{0}",row);

            return GetElementByCssSelector(element, 5);
        }

        private void SelectClickPriceAndCalculate(string volume, string colour)
        {
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");

            SelectMonoVolume(volume, "0");
            SelectColorVolume(colour);
            WebDriver.Wait(DurationType.Second, 5);
            CalculateClickPriceElement.Click();
            //WebDriver.Wait(DurationType.Second, 3);
        }


        public void SelectMonoVolume(string volume, string row)
        {
            if (monoVolumeDropdownElement == null)
                throw new NullReferenceException("monoVolumeDropdownElement can not be found");
            IWebElement element = MonoVolumeElementClickPrice(row);
            if (IsElementPresent(element))
                SelectFromDropdown(element, volume);
        }

        public void SelectColorVolume(string volume)
        {
            if (colourVolumeDropdownElement == null)
                throw new NullReferenceException("colourVolumeDropdownElement can not be found");
            if (IsElementPresent(ColourVolumeElementClickPrice("0")))
                SelectFromDropdown(colourVolumeDropdownElement, volume);
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
            SpecFlow.SetContext("ClickPriceMonoValue", ClickPriceValue().First().Text);
            SpecFlow.SetContext("ClickPriceColourValue", ClickPriceColourValue().First().Text);
            
            ClickPriceNextButton().Click();

            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);
        }

        public DealerProposalsCreateSummaryPage CalculateClickPriceAndProceed(string volume, string colour)
        {
            //MoveToClickPriceScreen();
            CalculateClickPrice(volume, colour);
            //WebDriver.Wait(Helper.DurationType.Second, 1);
            SpecFlow.SetContext("ClickPriceMonoValue", ClickPriceValue().First().Text);
            SpecFlow.SetContext("ClickPriceColourValue", ClickPriceColourValue().First().Text);
			//VerifyClickPriceValueIsDisplayed();
            WebDriver.Wait(Helper.DurationType.Second, 2);
            return ProceedToProposalSummaryFromClickPrice();
        }

        public void CalculateClickPrice(string volume, string colour)
        {
            if (MonoVolumeElement("0") != null)
                EnterClickPriceValueAndCalculate(volume, colour);
            if (MonoVolumeElementClickPrice("0") != null)
                SelectClickPriceAndCalculate(volume, colour);
            //VerifyClickPriceValueIsDisplayed();
        }

        public void CalculateClickPrice()
        {
            CalculateClickPriceElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
            MonoClickPriceValue();
            ColourClickPriceValue();
        }

        public DealerProposalsCreateSummaryPage MoveToProposalSummaryScreen()
        {
            ScrollTo(ProposalSummaryScreenElement);
            ProposalSummaryScreenElement.Click();
//            AssertElementPresent(SummaryConfirmationTextElement, "Product Confirmation Message");
            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver, BaseURL, true);

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
            WebDriver.Wait(Helper.DurationType.Second, 2);
            CalculateClickPriceElement.Click();
        }

        public void EnterMonoCoverage(string coverage)
        {
            if (MonoCoverageInputFieldElement == null)
                throw new NullReferenceException("Mono Coverage field can not be found");

            ClearAndType(MonoCoverageInputFieldElement, coverage);
            WebDriver.Wait(Helper.DurationType.Second, 2);
        }

        private IWebElement MonoVolumeElement(string row)
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
            WebDriver.Wait(Helper.DurationType.Second, 2);
            SpecFlow.SetContext(String.Format("ColourVolume{0}-{1}", row, DateTime.Now.ToString("yyyyMMddHHmmss")), volume);
        }

        private void EnterClickPriceValueAndCalculate(string volume, string colour)
        {
            EnterMonoVolume(volume, "0");
            EnterColourVolume(colour, "0");
            WebDriver.Wait(DurationType.Second, 5);
            CalculateClickPriceElement.Click();
        }

        public DealerProposalsCreateSummaryPage CalculateEnteredClickPriceAndProceed(string volume)
        {
//            MoveToClickPriceScreen();
            EnterMonoVolumeQuantity(volume);
            WebDriver.Wait(Helper.DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();
            SpecFlow.SetContext("ClickPriceMonoValue", ClickPriceValue().First().Text);

            return ProceedToProposalSummaryFromClickPrice();
        }

        public void IsCoverageErrorDisplayed()
        {
            string element = ".js-mps-alert";

            AssertElementPresent(GetElementByCssSelector(element, 5), "Coverage error is not displayed");
        }

        private void MonoClickPriceValue()
        {
            string str = ".mps-clickprice-group [data-click-price-mono=\"true\"]";
            int i = 0;
            foreach (IWebElement element in GetElementsByCssSelector(str, 5))
            {
                string val = element.Text;
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
