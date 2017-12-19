using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Text.RegularExpressions;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalSpecialPricingPage : ProposalSpecialPricingPage, IPageObject
    {
        private const string _url = "/mps/local-office/approval/special-pricing?proposalid={proposalId}"; // TODO
        private const string _validationElementSelector = "#content_1_ButtonNext"; // next button 
        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }


        [FindsBy(How = How.CssSelector, Using = "#content_1_NavInstallTab > a")]
        public IWebElement NavInstallTabA;
        [FindsBy(How = How.CssSelector, Using = "#content_1_NavInstallTab")]
        public IWebElement NavInstallTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_NavServiceTab > a")]
        public IWebElement NavServiceTabA;
        [FindsBy(How = How.CssSelector, Using = "#content_1_NavServiceTab")]
        public IWebElement NavServiceTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_NavClickTab > a")]
        public IWebElement NavClickTabA; // Click Price (for Click())
        [FindsBy(How = How.CssSelector, Using = "#content_1_NavClickTab")]
        public IWebElement NavClickTab; // Click Price (for check Active)


        public void SwitchNavInstallTab(int findElementTimeout)
        {
            SeleniumHelper.ClickSafety(NavInstallTabA, findElementTimeout);
            SeleniumHelper.WaitUntil(d => NavInstallTab.GetAttribute("class") == "active", findElementTimeout);
        }

        public void SwitchNavServiceTab(int findElementTimeout)
        {
            SeleniumHelper.ClickSafety(NavServiceTabA, findElementTimeout);
            SeleniumHelper.WaitUntil(d => NavServiceTab.GetAttribute("class") == "active", findElementTimeout);
        }

        public void SwitchNavClickTab(int findElementTimeout )
        {
            SeleniumHelper.ClickSafety(NavClickTabA, findElementTimeout);
            SeleniumHelper.WaitUntil(d => NavClickTab.GetAttribute("class") == "active", findElementTimeout);
        }

        public void EnterAdditionalAuditInformation(int findElementTimeout, string message = @"This is automation changes added to special pricing" )
        {
            SeleniumHelper.WaitUntil(d =>
            {
                try
                {
                    ClearAndType(ConfirmationAdditionalInformation, message);
                    ConfirmationAdditionalInformation.SendKeys(Keys.Tab);

                    return true;
                }
                catch { return false; }
            }, findElementTimeout);
        }
        public void EnterSpecialPriceInstallation(SpecialPriceParameter specialPrice, int defaultFindElementTimeout)
        {
            var modelRegex = new Regex(specialPrice.Model, RegexOptions.IgnoreCase);
            var modelElementList = SeleniumHelper.FindElementsByCssSelector("div.mps-special-pricing-group.js-special-pricing-installation-row");
            foreach (var modelElement in modelElementList)
            {
                var elementModelName = modelElement
                    .FindElement(By.CssSelector("span.mps-col.mps-top.mps-special-pricing-model"))
                    .FindElement(By.TagName("strong"))
                    .Text;
                if (modelRegex.IsMatch(specialPrice.Model) == false)
                {
                    continue;
                }

                EnterSpecialPrice(modelElement, "UnitCost", specialPrice.InstallUnitCost);
                EnterSpecialPrice(modelElement, "Margin", specialPrice.InstallMargin);
                EnterSpecialPrice(modelElement, "UnitPrice", specialPrice.InstallUnitPrice);
            }
        }

        public void EnterSpecialPriceService(SpecialPriceParameter specialPrice, int defaultFindElementTimeout)
        {
            var modelRegex = new Regex(specialPrice.Model, RegexOptions.IgnoreCase);
            var modelElementList = SeleniumHelper.FindElementsByCssSelector("div.mps-special-pricing-group.js-special-pricing-service-row");
            foreach (var modelElement in modelElementList)
            {
                var elementModelName = modelElement
                    .FindElement(By.CssSelector("span.mps-col.mps-top.mps-special-pricing-model"))
                    .FindElement(By.TagName("strong"))
                    .Text;
                if (modelRegex.IsMatch(specialPrice.Model) == false)
                {
                    continue;
                }

                EnterSpecialPrice(modelElement, "UnitCost", specialPrice.ServiceUnitCost);
                EnterSpecialPrice(modelElement, "Margin", specialPrice.ServiceMargin);
                EnterSpecialPrice(modelElement, "UnitPrice", specialPrice.ServiceUnitPrice);
            }
        }

        public void EnterSpecialPriceClick(SpecialPriceParameter specialPrice, int defaultFindElementTimeout)
        {
            var modelRegex = new Regex(specialPrice.Model,RegexOptions.IgnoreCase);
            var modelElementList = SeleniumHelper.FindElementsByCssSelector("div.mps-special-pricing-group.js-special-pricing-click-row");
            foreach( var modelElement in modelElementList)
            {
                var elementModelName = modelElement
                    .FindElement(By.CssSelector("span.mps-col.mps-top.mps-special-pricing-model"))
                    .FindElement(By.TagName("strong"))
                    .Text;
                if(modelRegex.IsMatch(elementModelName) == false)
                {
                    continue;
                }

                EnterSpecialPrice(modelElement, "MonoClickServiceCost", specialPrice.MonoClickServiceCost);
                EnterSpecialPrice(modelElement, "MonoClickServicePrice", specialPrice.MonoClickServicePrice);

                EnterSpecialPrice(modelElement, "MonoClickCoverage", specialPrice.MonoClickCoverage);
                EnterSpecialPrice(modelElement, "MonoClickVolume", specialPrice.MonoClickVolume);
                EnterSpecialPrice(modelElement, "MonoClickMargin", specialPrice.MonoClickMargin);
                EnterSpecialPrice(modelElement, "MonoClick", specialPrice.MonoClick);

                EnterSpecialPrice(modelElement, "ColourClickServiceCost", specialPrice.ColourClickServiceCost);
                EnterSpecialPrice(modelElement, "ColourClickServicePrice", specialPrice.ColourClickServicePrice);

                EnterSpecialPrice(modelElement, "ColourClickCoverage", specialPrice.ColourClickCoverage);
                EnterSpecialPrice(modelElement, "ColourClickVolume", specialPrice.ColourClickVolume);
                EnterSpecialPrice(modelElement, "ColourClickMargin", specialPrice.ColourClickMargin);
                EnterSpecialPrice(modelElement, "ColourClick", specialPrice.ColourClick );

            }
        }

        private void EnterSpecialPrice(IWebElement modelElement,  string byName , string itemValue )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(itemValue)  ) return;
                var element = modelElement.FindElement(By.Name(byName));
                bool isReadOnly;
                if (bool.TryParse(element.GetAttribute("readonly"), out isReadOnly) ? isReadOnly : false) return;
                ClearAndType(element, itemValue);
            }
            catch (NoSuchElementException) { /* no color elements in the monochrome model */}
        }

    }

    public class SpecialPriceParameter
    {
        public string Model;            // ex. DCP-8110DN

        /**
         * Installation TAB
         */
        public string InstallUnitCost;  // ex. 200.00
        public string InstallMargin;    // ex. 20.00
        public string InstallUnitPrice; // ex. 250.00

        /**
         * Service TAB
         */
        public string ServiceUnitCost;
        public string ServiceMargin;
        public string ServiceUnitPrice;

        /**
         * Click Price TAB
         */
        public string MonoClickServiceCost;     // ex. 36.15
        public string MonoClickServicePrice;    // ex. 72.19

        public string MonoClickCoverage;        // ex. 5
        public string MonoClickVolume;          // ex. 1000
        public string MonoClickMargin;          // ex. 17.00
        public string MonoClick;                // ex. 0.01078

        public string ColourClickServiceCost;
        public string ColourClickServicePrice;

        public string ColourClickCoverage;
        public string ColourClickVolume;
        public string ColourClickMargin;
        public string ColourClick;
    }

}
