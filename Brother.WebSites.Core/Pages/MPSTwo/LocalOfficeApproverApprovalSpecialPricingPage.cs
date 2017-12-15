using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
        [FindsBy(How = How.CssSelector, Using = "#content_1_NavClickTab > a")]
        public IWebElement NavClickTabA; // Click Price (for Click())
        [FindsBy(How = How.CssSelector, Using = "#content_1_NavClickTab")]
        public IWebElement NavClickTab; // Click Price (for check Active)

        // MonoClickServiceCost
        // ColourClickServiceCost

        // class="mps-special-pricing-group js-special-pricing-installation-row"
        // class="form-control input-sm"
        // name="UnitCost"
        //[FindsBy(How = How.CssSelector, Using = ".mps-special-pricing-group.js-special-pricing-service-row .form-control.input-sm[name=\"Margin\"]")]
        //public IWebElement ServicePackUnitMargin;

        //class="mps-special-pricing-group js-special-pricing-click-row"
        // class="form-control input-sm"
        //name="MonoClickServiceCost"

        // <input type="text" name="MonoClickServiceCost" value="60.00" data-original="60.00000000" class="form-control input-sm mps-special-pricing-changed" data-service-unit-cost="true" data-full-precision="60.00000000" data-mps-val-numeric="true" data-mps-val-required="true" data-mps-val-numeric-min="0" autofill="off" maxlength="8" aria-required="true" aria-invalid="false">



        public void SwitchNavInstallTab(int findElementTimeout)
        {
            SeleniumHelper.ClickSafety(NavInstallTabA, findElementTimeout);
            SeleniumHelper.WaitUntil(d => NavInstallTab.GetAttribute("class") == "active", findElementTimeout);
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
    }
}
