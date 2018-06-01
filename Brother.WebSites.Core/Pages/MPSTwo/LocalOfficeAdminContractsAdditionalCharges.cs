using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminContractsAdditionalCharges : BasePage, IPageObject
    {
        private const string _url = "/mps/local-office/admin/contracts/additional-charges";
        private const string _validationElementSelector = ".js-mps-additional-charges-title-row"; // row of 'New Charges' > 'Chaeges Types'

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

        //# content_1_AdditionalChargesContainer > div.tab-pane.active.container-fluid > div.js-mps-additional-charges-list-container > div > div > div:nth-child(2) > div.panel-body.responsive > div.row.mps-additional-charges-row > div > div > span.mps-col.mps-additional-charges-charge-type > select
        //<option value = "1" > Device Return Management Fee</option>
        //<option value = "2" > Consumables Return Management Fee</option>
        //<option value = "3" > Software Return Management Fee</option>
        //<option value = "4" > Contract Cancellation Administration Fee</option>
        //<option value = "5" > Contract Termination Administration Fee</option>
        [FindsBy(How = How.CssSelector, Using = "div.row.mps-additional-charges-row select.js-mps-charge-type")]
        public IWebElement ChargeTypeSelectorElement;

        public enum ChargeTypeSelectorElementValue
        {
            Device_Return_Management_Fee=1,
            Consumables_Return_Management_Fee,
            Software_Return_Management_Fee,
            Contract_Cancellation_Administration_Fee,
            Contract_Termination_Administration_Fee,
        }

        // input.form-control.input-sm.js-mps-cost-price
        [FindsBy(How = How.CssSelector, Using = "div.row.mps-additional-charges-row input.js-mps-cost-price")]
        public IWebElement ConstPriceElement; // ex. 0.00
        // input.form-control.input-sm.js-mps-dealer-margin
        [FindsBy(How = How.CssSelector, Using = "div.row.mps-additional-charges-row input.js-mps-dealer-margin")]
        public IWebElement DealerMarginElement; // ex. 0.00
        // input.form-control.input-sm.js-mps-customer-price
        [FindsBy(How = How.CssSelector, Using = "div.row.mps-additional-charges-row input.js-mps-customer-price")]
        public IWebElement CustomerPriceElement; // ex. 0.00
        // if can   click                : js-mps-add-additional-charge-button  btn.btn-primary pull-right mps-additional-charges-row-button btn-sm
        // if can't click(validate error): js-mps-add-additional-charge-button  btn btn-primary pull-right mps-additional-charges-row-button btn-sm disabled
        [FindsBy(How = How.CssSelector, Using = "div.row.mps-additional-charges-row button.mps-additional-charges-row-button")]
        public IWebElement AddButtonElement;

        //<input type="submit" name="content_1$ButtonBack" value="Back" id="content_1_ButtonBack" class="btn btn-link pull-left">
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonBack")]
        public IWebElement BackElement;

        public void EnterAdditionalChargesValue(ChargeTypeSelectorElementValue? chargeType=null, double? costPrice = null, double? marginPercent = null, double? customerPrice = null)
        {
            LoggingService.WriteLogOnMethodEntry(chargeType, costPrice, marginPercent, customerPrice);
            if (chargeType != null) { new SelectElement(ChargeTypeSelectorElement).SelectByValue( ((int)chargeType).ToString()); }
            if (costPrice != null) { ClearAndType(ConstPriceElement, string.Format("{0:n2}", costPrice, CultureInfo)); }
            if (marginPercent != null) { ClearAndType(DealerMarginElement, string.Format("{0:n2}", marginPercent, CultureInfo)); }
            if (customerPrice != null) { ClearAndType(CustomerPriceElement, string.Format("{0:n2}", customerPrice, CultureInfo)); }
        }

        // exist
        // #content_1_AdditionalChargesContainer > div.tab-pane.active.container-fluid > div.js-mps-additional-charges-list-container > div > div > div:nth-child(1) > div.panel-body.responsive.js-mps-additional-charges-existing-charges-container > div.js-additional-charge-list-container > div.row.js-mps-additional-charge-row-template > div > div > span.mps-col.mps-additional-charges-charge-type > select
        // add
        // #content_1_AdditionalChargesContainer > div.tab-pane.active.container-fluid > div.js-mps-additional-charges-list-container > div > div > div:nth-child(2) > div.panel-body.responsive > div.row.mps-additional-charges-row > div > div > span.mps-col.mps-additional-charges-charge-type > select
    }
}
