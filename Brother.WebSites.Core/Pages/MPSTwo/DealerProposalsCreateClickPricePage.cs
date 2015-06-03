using System;
using System.Collections.Generic;
using System.Linq;
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
        private const string colourVolume = @"#content_1_LineItems_InputColourVolumeBreaks_0";
        private const string monoVolume = @"#content_1_LineItems_InputMonoVolumeBreaks_0";
        private const string clickPriceValue = @"[class='mps-col mps-top mps-clickprice-line2'][data-click-price-mono='true']";
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
            TestCheck.AssertIsEqual(false, PaymentMethodElement().Displayed, "Payment method is displayed");
            //AssertElementPresent(PaymentMethodElement(), "Payment method is displayed");
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

        private IWebElement ColourVolumeElementClickPrice()
        {
            return GetElementByCssSelector(colourVolume);
        }
        public void CalculateClickPriceAndNext()
        {
            CalculateClickPriceElement.Click();
            ProceedOnClickPricePageElement.Click();
        }

        private IWebElement MonoVolumeElementClickPrice()
        {
            return GetElementByCssSelector(monoVolume);
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

        private IList<IWebElement> ClickPriceValue()
        {
            return GetElementsByCssSelector(clickPriceValue);
        }

        private void VerifyClickPriceValueIsDisplayed()
        {
            for (var i = 0; i < ClickPriceValue().Count; i++)
            {
                TestCheck.AssertIsEqual(false, ClickPriceValue().ElementAt(i).Text.Equals(string.Empty), "Price Value is Empty");
            }
        }

        private IWebElement ClickPriceNextButton()
        {
            return GetElementByCssSelector(clickPricePageNext);
        }

        public DealerProposalsCreateSummaryPage ProceedToProposalSummaryFromClickPrice()
        {
            ClickPriceNextButton().Click();

            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);
        }

        public DealerProposalsCreateSummaryPage CalculateClickPriceAndProceed(string volume, string colour)
        {
            //MoveToClickPriceScreen();
            CalculateClickPrice(volume, colour);
            WebDriver.Wait(Helper.DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();
            
            return ProceedToProposalSummaryFromClickPrice();
        }

        public DealerProposalsCreateSummaryPage MoveToProposalSummaryScreen()
        {
            ScrollTo(ProposalSummaryScreenElement);
            ProposalSummaryScreenElement.Click();
//            AssertElementPresent(SummaryConfirmationTextElement, "Product Confirmation Message");
            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);

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

        public DealerProposalsCreateSummaryPage CalculateEnteredClickPriceAndProceed(string volume)
        {
//            MoveToClickPriceScreen();
            EnterMonoVolumeQuantity(volume);
            WebDriver.Wait(Helper.DurationType.Second, 5);
            VerifyClickPriceValueIsDisplayed();

            return ProceedToProposalSummaryFromClickPrice();
        }
    }
}
