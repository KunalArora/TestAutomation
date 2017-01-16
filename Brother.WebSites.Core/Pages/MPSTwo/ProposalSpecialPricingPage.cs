using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ProposalSpecialPricingPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-installation-row .form-control.input-sm[name=\"UnitCost\"]")]
        public IWebElement InstallationProductUnitCost;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-installation-row .form-control.input-sm[name=\"Margin\"]")]
        public IWebElement InstallationProductUnitMargin;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-installation-row .form-control.input-sm[name=\"UnitPrice\"]")]
        public IWebElement InstallationProductUnitPrice;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement NextButton;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonValidate")]
        public IWebElement ValidateButton;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"UnitCost\"]")]
        public IWebElement ServicePackUnitCost;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"Margin\"]")]
        public IWebElement ServicePackUnitMargin;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"UnitPrice\"]")]
        public IWebElement ServicePackUnitPrice;
        [FindsBy(How = How.CssSelector, Using = "[name=\"MonoClickCoverage\"]")]
        public IWebElement ClickPriceMonoCoverage;
        [FindsBy(How = How.CssSelector, Using = "[name=\"MonoClickVolume\"]")]
        public IWebElement ClickPriceMonoVolume;
        [FindsBy(How = How.CssSelector, Using = "[name=\"MonoClickMargin\"]")]
        public IWebElement ClickPriceMonoMargin;
        [FindsBy(How = How.CssSelector, Using = "[name=\"MonoClick\"]")]
        public IWebElement MonoClickPrice;
        [FindsBy(How = How.CssSelector, Using = "[name=\"ColourClickCoverage\"]")]
        public IWebElement ClickPriceColourCoverage;
        [FindsBy(How = How.CssSelector, Using = "[name=\"ColourClickVolume\"]")]
        public IWebElement ClickPriceColourVolume;
        [FindsBy(How = How.CssSelector, Using = "[name=\"ColourClickMargin\"]")]
        public IWebElement ClickPriceColourMargin;
        [FindsBy(How = How.CssSelector, Using = "[name=\"ColourClick\"]")]
        public IWebElement ColourClickPrice;
        [FindsBy(How = How.CssSelector, Using = "#InputAdditionalAudit")]
        public IWebElement ConfirmationAdditionalInformation;
        [FindsBy(How = How.CssSelector, Using = ".btn.btn-success.pull-right.js-special-pricing-confirm.js-mps-val-btn-next")]
        public IWebElement ApplySpecialPricing;
        



        private decimal GetFieldValue(IWebElement element)
        {
            var fieldValue = element.GetAttribute("value");

            var decimalValue = Decimal.Parse(fieldValue,
                 System.Globalization.NumberStyles.AllowParentheses |
                 System.Globalization.NumberStyles.AllowLeadingWhite |
                 System.Globalization.NumberStyles.AllowTrailingWhite |
                 System.Globalization.NumberStyles.AllowThousands |
                 System.Globalization.NumberStyles.AllowDecimalPoint |
                 System.Globalization.NumberStyles.AllowLeadingSign);

            return decimalValue;
        }


        public void EnterNewInstallationUnitCost(decimal dec)
        {
            var value = GetFieldValue(InstallationProductUnitCost);
            value = value + dec;

            ClearAndType(InstallationProductUnitCost, value.ToString());

        }

        public void EnterNewInstallationMarginValue(decimal dec)
        {
            var value = GetFieldValue(InstallationProductUnitMargin);
            value = value + dec;

            ClearAndType(InstallationProductUnitMargin, value.ToString());
            InstallationProductUnitMargin.SendKeys(Keys.Tab);
        }

        public void SetInstallationUnitPrice()
        {
            WebDriver.Wait(DurationType.Second, 3);
            var value = GetFieldValue(InstallationProductUnitPrice);

            SpecFlow.SetContext("SpecialPriceInstallation", value.ToString());
        }

        public void ProceedOnSpecialPricingPage()
        {
            NextButton.Click();
        }

        public void EnterNewServicePackValue(decimal dec)
        {
            var value = GetFieldValue(ServicePackUnitCost);
            value = value + dec;

            ClearAndType(ServicePackUnitCost, value.ToString());

        }

        public void EnterNewServicePackMarginValue(decimal dec)
        {
            var value = GetFieldValue(ServicePackUnitMargin);
            value = value + dec;

            ClearAndType(ServicePackUnitMargin, value.ToString());
            ServicePackUnitMargin.SendKeys(Keys.Tab);
        }

        public void IsInstallationPriceCorrectlyCalculated()
        {
            var cost = InstallationProductUnitCost.GetAttribute("value");
            var margin = MarginDecimal(InstallationProductUnitMargin.GetAttribute("value"));
            var displayedPrice = InstallationProductUnitPrice.GetAttribute("value");

            var calculatedPrice = CalculatePriceFromCostUsingMargin(cost, margin);

            TestCheck.AssertTextContains(displayedPrice, calculatedPrice);
        }

        private decimal MarginDecimal(string element)
        {
            var splitElement = new string[] { };

            if (element.Contains(","))
            {
                splitElement = element.Split(',');
            }
            else if (element.Contains("."))
            {
                splitElement = element.Split('.');
            }

            var margDecimal = decimal.Parse(splitElement[0]);

            return margDecimal / 100;
        }

        private decimal RoundUpValue(decimal value, int places)
        {
            return Math.Round(value, places);
        }

        private string CalculatePriceFromCostUsingMargin(string cost, decimal margin)
        {
            var number = decimal.Parse(cost);
            var costDecimal = (number / (1 - margin));
            costDecimal = RoundUpValue(costDecimal, 2);

            return costDecimal.ToString();
        }

        public void IsServicePackPriceCorrectlyCalculated()
        {
            var cost = ServicePackUnitCost.GetAttribute("value");
            var margin = MarginDecimal(ServicePackUnitMargin.GetAttribute("value"));
            var displayedPrice = ServicePackUnitPrice.GetAttribute("value");

            var calculatedPrice = CalculatePriceFromCostUsingMargin(cost, margin);

            TestCheck.AssertTextContains(displayedPrice, calculatedPrice);
        }

        public void SetServicePackUnitPrice()
        {
            WebDriver.Wait(DurationType.Second, 3);
            var value = GetFieldValue(ServicePackUnitPrice);

            SpecFlow.SetContext("SpecialPriceServicePack", value.ToString());
        }

        public void EnterNewClickPriceMonoCoverage(decimal dec)
        {
            var value = GetFieldValue(ClickPriceMonoCoverage);
            value = value + dec;

            ClearAndType(ClickPriceMonoCoverage, value.ToString());

        }

        public void EnterNewClickPriceColourCoverage(decimal dec)
        {
            var value = GetFieldValue(ClickPriceColourCoverage);
            value = value + dec;

            ClearAndType(ClickPriceColourCoverage, value.ToString());

        }

        public void EnterNewClickPriceMonoVolume(decimal dec)
        {
            var value = GetFieldValue(ClickPriceMonoVolume);
            value = value + dec;

            ClearAndType(ClickPriceMonoVolume, value.ToString());
        }

        public void EnterNewClickPriceColourVolume(decimal dec)
        {
            var value = GetFieldValue(ClickPriceColourVolume);
            value = value + dec;

            ClearAndType(ClickPriceColourVolume, value.ToString());
        }


        public void EnterNewClickPriceMonoMargin(decimal dec)
        {
            var value = GetFieldValue(ClickPriceMonoMargin);
            value = value + dec;

            ClearAndType(ClickPriceMonoMargin, value.ToString());
        }

        
        public void EnterNewClickPriceColourMargin(decimal dec)
        {
            var value = GetFieldValue(ClickPriceColourMargin);
            value = value + dec;

            ClearAndType(ClickPriceColourMargin, value.ToString());
        }

        public void EnterNewMonoClickPriceValue(string dec)
        {
            var value = GetFieldValue(MonoClickPrice);

            var decVal = decimal.Parse(dec,
                 System.Globalization.NumberStyles.AllowParentheses |
                 System.Globalization.NumberStyles.AllowLeadingWhite |
                 System.Globalization.NumberStyles.AllowTrailingWhite |
                 System.Globalization.NumberStyles.AllowThousands |
                 System.Globalization.NumberStyles.AllowDecimalPoint |
                 System.Globalization.NumberStyles.AllowLeadingSign);

            value = value + decVal;

            SpecFlow.SetContext("SpecialPriceMonoClickPrice", value.ToString());

            ClearAndType(MonoClickPrice, value.ToString());
        }

        public void EnterNewColourClickPriceValue(string dec)
        {
            var value = GetFieldValue(ColourClickPrice);

            var decVal = decimal.Parse(dec,
                System.Globalization.NumberStyles.AllowParentheses |
                System.Globalization.NumberStyles.AllowLeadingWhite |
                System.Globalization.NumberStyles.AllowTrailingWhite |
                System.Globalization.NumberStyles.AllowThousands |
                System.Globalization.NumberStyles.AllowDecimalPoint |
                System.Globalization.NumberStyles.AllowLeadingSign);

            value = value + decVal;

            SpecFlow.SetContext("SpecialPriceColourClickPrice", value.ToString());

            ClearAndType(ColourClickPrice, value.ToString());
        }

        public void ValidateSpecialPricesEntered()
        {
            if (ValidateButton == null)
                throw new Exception("Validate Button is returned as null");

            ValidateButton.Click();
        }

        public void EnterAdditionalAuditInformation()
        {
            const string message = @"This is automation changes added to special pricing";

            WaitForElementToExistByCssSelector("#InputAdditionalAudit");

            ClearAndType(ConfirmationAdditionalInformation, message);
            ConfirmationAdditionalInformation.SendKeys(Keys.Tab);
        }

        public ReportProposalSummaryPage ApplyEnteredSpecialPricing()
        {
            if (ApplySpecialPricing == null)
                throw new Exception("apply special pricing button is returned as null");

            ApplySpecialPricing.Click();

            return GetInstance<ReportProposalSummaryPage>();
        }

        
    }
}
