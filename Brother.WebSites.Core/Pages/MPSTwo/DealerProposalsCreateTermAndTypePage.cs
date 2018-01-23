using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateTermAndTypePage : BasePage, IPageObject
    {
        public static string URL = "/mps/dealer/proposals/create/term-type";
        private const string _validationElementSelector = "#content_1_InputUsageType_Input";
        private const string _url = "/mps/dealer/proposals/create/term-type";

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

        public ISeleniumHelper SeleniumHelper { get; set; }

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string usageTypeSelector = "#content_1_InputUsageType_Input";
        private const string contractLengthSelector = "#content_1_InputContractLength_Input";
        private const string billingTypeSelector = "#content_1_InputClickRateBillingCycle_Input";
        private const string servicePackOptionSelector = "#content_1_InputServicePaymentOption_Input";

        private const string priceHardwareTickBox = @"#content_1_InputPriceHardware_Input";

        [FindsBy(How = How.Id, Using = "content_1_InputContractLength_Input")]
        public IWebElement ContractLengthElement;
        [FindsBy(How = How.Id, Using = "content_1_InputLeasingRateBillingCycle_Input")]
        public IWebElement LeaseBillingCycleElement;
        [FindsBy(How = How.Id, Using = "content_1_InputClickRateBillingCycle_Input")]
        public IWebElement PayPerClickBillingElement;
        [FindsBy(How = How.Id, Using = "content_1_InputUsageType_Input")]
        public IWebElement UsageTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_InputPriceHardware_Input")]
        public IWebElement PriceHardwareElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;
        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        public IWebElement TermAndTypeScreenTextElement;
        [FindsBy(How = How.Id, Using = "content_1_InputServicePaymentOption_Input")]
        public IWebElement PaymentMethodElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputServicePaymentOption_Input [selected=\"selected\"]")]
        public IWebElement SelectedPaymentMethodElement;


        public void IsTheRightPaymentMethodSelected(string pay)
        {
            LoggingService.WriteLogOnMethodEntry(pay);
            var text = SelectedPaymentMethodElement.Text;
            TestCheck.AssertTextContains(text, pay);
        }

        public void HowManyServicePackPaymentIsDisplayed(int number)
        {
            LoggingService.WriteLogOnMethodEntry(number);
            TestCheck.AssertIsEqual(number, NumberOfSelectOption(PaymentMethodElement), "The correct number of select option is not displayed"); 
        }

        public void PayServicePackMethod(string option)
        {
            LoggingService.WriteLogOnMethodEntry(option);
            //var paymentMethod = "";

            //if (IsSpainSystem() || IsBelgiumSystem() || IsPolandSystem() || IsIrelandSystem() || IsNetherlandSystem()) return;
            //if (
            //        option.Equals("Pay upfront")
            //        || option.Equals("Im Voraus bezahlen") 
            //        || option.Equals("Betale på forskud")
            //        || option.Equals("Paiement au démarrage du contrat") 
            //        || option.Equals("Pagamento anticipato") 
            //        || option.Equals("Förskott")
            //        || option.Equals("Betaling bij aanvang van het contract") 
            //        || option.Equals("Płatność z góry")
            //        || option.Equals("Maksu etukäteen")
            //        || option.Equals("På forskudd")

            //    )
            //{
            //    paymentMethod = "Pay upfront";
            //}
            //else if (
            //            option.Equals("Included in Click Price")
            //            || option.Equals("über den Seitenpreis zahlen") 
            //            || option.Equals("Inkluderet i klikpris")
            //            || option.Equals("Inclus dans le coût à la page") 
            //            || option.Equals("Incluso nel click") 
            //            || option.Equals("Per utskrift")
            //            || option.Equals("Inbegrepen in de clickprijs") 
            //            || option.Equals("Inclus dans le prix click") 
            //            || option.Equals("Wliczyć w cenę za wydruk strony")
            //            || option.Equals("Über den Seitenpreis zahlen")
            //            || option.Equals("Sisältyy klikkihintaan")
            //            || option.Equals("I klikk")
            //    )
            //{
            //    paymentMethod = "Included in Click Price";
            //}

            SelectFromDropdown(PaymentMethodElement, option);
         }
            

        public void IsTermAndTypeTextDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (TermAndTypeScreenTextElement == null) throw new
                NullReferenceException("Unable to locate text on Term and Type Screen");

            AssertElementPresent(TermAndTypeScreenTextElement, "Terms and Type Instruction");
        }

        private IWebElement PriceHardwareElementMissing()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetElementByCssSelector(priceHardwareTickBox, 10);
        }

        public void VerifyPriceHardwareIsNotDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(false, PriceHardwareElementMissing().Displayed, "Price hardware checkbox is displayed");
        }

        public void VerifyPriceHardwareIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, PriceHardwareElementMissing().Displayed, "Price hardware checkbox is displayed");
        }

        public void TickPriceHardware()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PriceHardwareElement.Selected)
            {
                return;
            }
        }

        public void UntickPriceHardware()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PriceHardwareElement.Selected)
            {
                PriceHardwareElement.Click();
            }
        }

        public void IsNotPriceHardwareElement()
        {
            LoggingService.WriteLogOnMethodEntry();
            Boolean ret = IsElementPresent(GetElementByCssSelector("#content_1_InputPriceHardware_Input", 5));
            TestCheck.AssertIsEqual(false, ret, "PriceHardwareElement is displayed");
        }

        public void TickPriceHardware(string tickOption)
        {
            LoggingService.WriteLogOnMethodEntry(tickOption);
            if (tickOption.Equals("Untick"))
            {
                PriceHardwareElement.Click();
            }
            else if (tickOption.Equals("Tick"))
            {
                //do nothing
            }
        }

        public void SelectContractLength(string length)
        {
            LoggingService.WriteLogOnMethodEntry(length);
            if (!IsElementPresent(GetElementByCssSelector("#content_1_InputContractLength_Input", 10))) return;
            SpecFlow.SetContext("DealerLatestEditedContractTerm", length);
            SelectFromDropdown(ContractLengthElement, length);
        }

        public void SelectLeaseBillingCycle(string lease)
        {
            LoggingService.WriteLogOnMethodEntry(lease);
            if (!IsElementPresent(GetElementByCssSelector("#content_1_InputLeasingRateBillingCycle_Input", 10))) return;
            SelectFromDropdown(LeaseBillingCycleElement, lease);
        }

        public void SelectPayPerClickBillingCycle(string billing)
        {
            LoggingService.WriteLogOnMethodEntry(billing);
            if (!IsElementPresent(GetElementByCssSelector("#content_1_InputClickRateBillingCycle_Input", 10))) return;
            SelectFromDropdown(PayPerClickBillingElement, billing);
        }


        
        public void SelectUsageType(string usage)
        {
            LoggingService.WriteLogOnMethodEntry(usage);
            if (!IsElementPresent(GetElementByCssSelector("#content_1_InputUsageType_Input", 10))) return;
            SpecFlow.SetContext("DealerLatestEditedUsageType", usage);
            SelectFromDropdown(UsageTypeElement, usage);
            //WebDriver.Wait(DurationType.Second, 5);
        }

        public DealerProposalsCreateProductsPage ClickNextButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(NextButton);
            //NextButton.Click();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, NextButton);
            return GetTabInstance<DealerProposalsCreateProductsPage>(Driver);
        }

        public void PopulateTermAndTypeForType1(string usageType, string contractLength, string billingType, string servicePackOption)
        {
            LoggingService.WriteLogOnMethodEntry(usageType,contractLength,billingType,servicePackOption);
            int findElementTimeout = RuntimeSettings.DefaultFindElementTimeout;
            var usageTypeElement = SeleniumHelper.FindElementByCssSelector(usageTypeSelector, findElementTimeout);
            var contractLengthElement = SeleniumHelper.FindElementByCssSelector(contractLengthSelector, findElementTimeout);
            SeleniumHelper.SelectFromDropdownByText(usageTypeElement, usageType);
            SeleniumHelper.SelectFromDropdownByText(ContractLengthElement, contractLength);
 
            var billingTypeElement = SeleniumHelper.FindElementByCssSelector(billingTypeSelector, findElementTimeout);
            var servicePackOptionElement = SeleniumHelper.FindElementByCssSelector(servicePackOptionSelector, findElementTimeout);
            SeleniumHelper.SelectFromDropdownByText(billingTypeElement, billingType);
            SeleniumHelper.SelectFromDropdownByText(servicePackOptionElement, servicePackOption);
        }
    }
}
