using Brother.Tests.Common.Domain.SpecFlowTableMappings;
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

        private const string JsSpecialPricingInstallationRowSelector = "div.mps-special-pricing-group.js-special-pricing-installation-row";
        private const string JsSpecialPricingServiceRowSelector = "div.mps-special-pricing-group.js-special-pricing-service-row";
        private const string JsSpecialPricingClickRowSelector = "div.mps-special-pricing-group.js-special-pricing-click-row";
        private const string MpsSpecialPricingModelSelector = "span.mps-col.mps-top.mps-special-pricing-model";



        public void SwitchNavInstallTab()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(NavInstallTabA);
            SeleniumHelper.WaitUntil(d => NavInstallTab.GetAttribute("class") == "active");
        }

        public void SwitchNavServiceTab()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(NavServiceTabA);
            SeleniumHelper.WaitUntil(d => NavServiceTab.GetAttribute("class") == "active");
        }

        public void SwitchNavClickTab()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(NavClickTabA);
            SeleniumHelper.WaitUntil(d => NavClickTab.GetAttribute("class") == "active");
        }

        public void EnterAdditionalAuditInformation(string message = @"This is automation changes added to special pricing" )
        {
            LoggingService.WriteLogOnMethodEntry(message);
            SeleniumHelper.WaitUntil(d =>
            {
                try
                {
                    ClearAndType(ConfirmationAdditionalInformation, message);
                    ConfirmationAdditionalInformation.SendKeys(Keys.Tab);

                    return true;
                }
                catch { return false; }
            });
        }

        public void EnterSpecialPriceInstallation(SpecialPricingProperties specialPrice)
        {
            LoggingService.WriteLogOnMethodEntry(specialPrice);
            var modelRegex = new Regex(specialPrice.Model, RegexOptions.IgnoreCase);
            var modelElementList = SeleniumHelper.FindElementsByCssSelector(JsSpecialPricingInstallationRowSelector);
            foreach (var modelElement in modelElementList)
            {
                var elementModelName = modelElement
                    .FindElement(By.CssSelector(MpsSpecialPricingModelSelector))
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

        public void EnterSpecialPriceService(SpecialPricingProperties specialPrice)
        {
            LoggingService.WriteLogOnMethodEntry(specialPrice);
            var modelRegex = new Regex(specialPrice.Model, RegexOptions.IgnoreCase);
            var modelElementList = SeleniumHelper.FindElementsByCssSelector(JsSpecialPricingServiceRowSelector);
            foreach (var modelElement in modelElementList)
            {
                var elementModelName = modelElement
                    .FindElement(By.CssSelector(MpsSpecialPricingModelSelector))
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


        public void EnterSpecialPriceClick(SpecialPricingProperties specialPrice)
        {
            LoggingService.WriteLogOnMethodEntry(specialPrice);
            var modelRegex = new Regex(specialPrice.Model,RegexOptions.IgnoreCase);
            var modelElementList = SeleniumHelper.FindElementsByCssSelector(JsSpecialPricingClickRowSelector);
            foreach( var modelElement in modelElementList)
            {
                var elementModelName = modelElement
                    .FindElement(By.CssSelector(MpsSpecialPricingModelSelector))
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

        private void EnterSpecialPrice(IWebElement modelElement,  string byName , string itemValue)
        {
            LoggingService.WriteLogOnMethodEntry(modelElement,byName,itemValue);
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
}
