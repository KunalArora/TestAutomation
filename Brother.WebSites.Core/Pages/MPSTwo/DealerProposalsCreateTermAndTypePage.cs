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
    public class DealerProposalsCreateTermAndTypePage : BasePage
    {
        public static string URL = "/mps/dealer/proposals/create/term-type";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

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

        public void IsTermAndTypeTextDisplayed()
        {
            if (TermAndTypeScreenTextElement == null) throw new
                NullReferenceException("Unable to locate text on Term and Type Screen");

            AssertElementPresent(TermAndTypeScreenTextElement, "Terms and Type Instruction");
        }

        private IWebElement PriceHardwareElementMissing()
        {
            return GetElementByCssSelector(priceHardwareTickBox, 10);
        }

        public void VerifyPriceHardwareIsNotDisplayed()
        {
            TestCheck.AssertIsEqual(false, PriceHardwareElementMissing().Displayed, "Price hardware checkbox is displayed");
        }

        public void VerifyPriceHardwareIsDisplayed()
        {
            TestCheck.AssertIsEqual(true, PriceHardwareElementMissing().Displayed, "Price hardware checkbox is displayed");
        }

        public void TickPriceHardware()
        {
            if (PriceHardwareElement.Selected)
            {
                return;
            }
        }

        public void UntickPriceHardware()
        {
            if (PriceHardwareElement.Selected)
            {
                PriceHardwareElement.Click();
            }
        }

        public void IsNotPriceHardwareElement()
        {
            Boolean ret = IsElementPresent(GetElementByCssSelector("#content_1_InputPriceHardware_Input", 5));
            TestCheck.AssertIsEqual(false, ret, "PriceHardwareElement is displayed");
        }

        public void TickPriceHardware(string tickOption)
        {
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
            if (!IsElementPresent(GetElementByCssSelector("#content_1_InputContractLength_Input", 10))) return;
            SpecFlow.SetContext("DealerLatestEditedContractTerm", length);
            SelectFromDropdown(ContractLengthElement, length);
        }

        public void SelectLeaseBillingCycle(string lease)
        {
            if (!IsElementPresent(GetElementByCssSelector("#content_1_InputLeasingRateBillingCycle_Input", 10))) return;
            SelectFromDropdown(LeaseBillingCycleElement, lease);
        }

        public void SelectPayPerClickBillingCycle(string billing)
        {
            if (!IsElementPresent(GetElementByCssSelector("#content_1_InputClickRateBillingCycle_Input", 10))) return;
            SelectFromDropdown(PayPerClickBillingElement, billing);
        }


        
        public void SelectUsageType(string usage)
        {
            if (!IsElementPresent(GetElementByCssSelector("#content_1_InputUsageType_Input", 10))) return;
            SpecFlow.SetContext("DealerLatestEditedUsageType", usage);
            SelectFromDropdown(UsageTypeElement, usage);
            WebDriver.Wait(DurationType.Second, 5);
        }

        public DealerProposalsCreateProductsPage ClickNextButton()
        {
            ScrollTo(NextButton);
            //NextButton.Click();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, NextButton);
            return GetTabInstance<DealerProposalsCreateProductsPage>(Driver);
        }
    }
}
