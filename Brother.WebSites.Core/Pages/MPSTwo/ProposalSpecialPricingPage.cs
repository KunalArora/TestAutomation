using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public IWebElement InstallationProductUnitCostMargin;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-installation-row .form-control.input-sm[name=\"UnitPrice\"]")]
        public IWebElement InstallationProductUnitCostPrice;
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
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"MonoClickCoverage\"]")]
        public IWebElement ClickPriceMonoCoverage;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"MonoClickVolume\"]")]
        public IWebElement ClickPriceMonoVolume;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"MonoClickMargin\"]")]
        public IWebElement ClickPriceMonoMargin;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"MonoClick\"]")]
        public IWebElement MonoClickPrice;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"ColourClickCoverage\"]")]
        public IWebElement ClickPriceColourCoverage;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"ColourClickVolume\"]")]
        public IWebElement ClickPriceColourVolume;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"ColourClickMargin\"]")]
        public IWebElement ClickPriceColourMargin;
        [FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"ColourClick\"]")]
        public IWebElement ColourClickPrice;
        [FindsBy(How = How.CssSelector, Using = "#InputAdditionalAudit")]
        public IWebElement ConfirmationAdditionalInformation;
        



        

    }
}
