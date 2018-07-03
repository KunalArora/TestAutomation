using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminProgramPurchaseAndClickPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_ButtonSave";
        private const string _url = "/mps/local-office/programs/purchase-and-click/program-settings";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNewPrintAndConsumablesBillingCycle")]
        public IWebElement AddBillingCycleButtonElement;

        //Add billing cycle selectors
        private const string BillingCycleNameInputSelector = "#content_1_InputName_Input";
        private const string BillingUsageTypeInputSelector = "#content_1_InputUsageType_Input";
        private const string BillingPaymentTypetSelector = "#content_1_InputPaymentType_Input";
        private const string BillingFrequencyInputSelector = "#content_1_InputFrequency_Input";
        private const string NextButtonSelector = "#content_1_ButtonNext";
        
        //Billing cycle list selectors
        private const string BillingCycleListBodySelector = ".js-mps-searchable";
        private const string BillingCycleListNameSelector = "[id*=content_1_PrintAndConsumablesBillingCyclesList_BillingCyclesList_FieldName_]";
        private const string BillingCycleListUsageTypeSelector = "[id*=content_1_PrintAndConsumablesBillingCyclesList_BillingCyclesList_FieldUsageType_]";
        private const string BillingCycleListPaymentTypeSelector = "[id*=content_1_PrintAndConsumablesBillingCyclesList_BillingCyclesList_FieldPaymentType_]";
        private const string BillingCycleListFequencySelector = "[id*=content_1_PrintAndConsumablesBillingCyclesList_BillingCyclesList_FieldFrequency_]";
        private const string BillingCycleListStatusSelector = "[id*=content_1_PrintAndConsumablesBillingCyclesList_BillingCyclesList_FieldStatus_]";
        private const string BillingCycleListActionsSelector = "[id*=content_1_PrintAndConsumablesBillingCyclesList_BillingCyclesList_FieldActions_]";
        private const string BillingCycleListActionsShowSelector = ".js-mps-show-billing-cycle";
        private const string BillingCycleListActionsDeleteSelector = ".js-mps-delete-billing-cycle";

        public void CreateANewBillingCycleDetails(string billingName, string billingUsage, string billingPattern)
        {
            LoggingService.WriteLogOnMethodEntry(billingName, billingUsage, billingPattern);
            var BillingCycleNameInputElement = SeleniumHelper.FindElementByCssSelector(BillingCycleNameInputSelector);
            var BillingUsageTypeInputElement = SeleniumHelper.FindElementByCssSelector(BillingUsageTypeInputSelector);
            var BillingPaymentTypeElement = SeleniumHelper.FindElementByCssSelector(BillingPaymentTypetSelector);
            var BillingFrequencyInputElement = SeleniumHelper.FindElementByCssSelector(BillingFrequencyInputSelector);

   //         SeleniumHelper.WaitUntil(d => BillingCycleNameInputElement.Text == string.Empty);

            if(SeleniumHelper.WaitUntil( d => SeleniumHelper.IsElementDisplayed(BillingCycleNameInputElement)))
            {
                ClearAndType(BillingCycleNameInputElement, billingName, true);
                SeleniumHelper.SelectFromDropdownByText(BillingUsageTypeInputElement, billingUsage);
                SeleniumHelper.SelectFromDropdownByText(BillingPaymentTypeElement, billingPattern);
                SeleniumHelper.SelectFromDropdownByText(BillingFrequencyInputElement, "1");
            }

            SeleniumHelper.ClickSafety(
                SeleniumHelper.FindElementByCssSelector(NextButtonSelector));
        }

        public void VerifyAndEnableNewlyCreatedBillingCycle(string billingName, string billingUsage, string billingPaymentType, string resourceBillingCysleStatusDisabled)
        {
            LoggingService.WriteLogOnMethodEntry(billingName, billingUsage, billingPaymentType, resourceBillingCysleStatusDisabled);
            var IsPresent = false;
            var BillingCycleListBodyElement = SeleniumHelper.FindElementByCssSelector(BillingCycleListBodySelector);
            var BillingCycleListRows = SeleniumHelper.FindRowElementsWithinTable(BillingCycleListBodyElement);

            if (SeleniumHelper.WaitUntil(d => SeleniumHelper.IsElementDisplayed(BillingCycleListBodyElement)))
            {
                foreach (var row in BillingCycleListRows)
                {
                    var BillingCycleListNameElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListNameSelector);
                    var BillingCycleListUsageTypeElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListUsageTypeSelector);
                    var BillingCycleListPaymentTypeElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListPaymentTypeSelector);
                    var BillingCycleListFequencyElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListFequencySelector);

                    if (BillingCycleListNameElement.Text.Equals(billingName) && BillingCycleListUsageTypeElement.Text.Equals(billingUsage) &&
                        BillingCycleListPaymentTypeElement.Text.Equals(billingPaymentType) && BillingCycleListFequencyElement.Text.Equals("1"))
                    {
                        IsPresent = true;
                        var BillingCycleListStatusElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListStatusSelector);
                        if (BillingCycleListStatusElement.Text.Equals(resourceBillingCysleStatusDisabled))
                        {
                            SeleniumHelper.ClickSafety(SeleniumHelper.FindElementByCssSelector(row, BillingCycleListActionsSelector));
                            SeleniumHelper.ClickSafety(SeleniumHelper.FindElementByCssSelector(row, BillingCycleListActionsShowSelector));
                            break;
                        }
                        else
                        {
                            LoggingService.WriteLog(LoggingLevel.WARNING, "The newly created billing cycle is already enabled when it should be disabled");
                            break;
                        }
                    }
                }
                TestCheck.AssertIsEqual(IsPresent, true, "Newly created billing cycle is not present in the billing cycles list");
            }
        }

        public void DeleteNewlyCreatedBillingCycle(string billingName, string billingUsage, string billingPaymentType, string resourceBillingCysleStatusEnabled)
        {
            LoggingService.WriteLogOnMethodEntry(billingName, billingUsage, billingPaymentType, resourceBillingCysleStatusEnabled);
            var IsPresent = false;
            var BillingCycleListBodyElement = SeleniumHelper.FindElementByCssSelector(BillingCycleListBodySelector);
            var BillingCycleListRows = SeleniumHelper.FindRowElementsWithinTable(BillingCycleListBodyElement);

            if (SeleniumHelper.WaitUntil(d => SeleniumHelper.IsElementDisplayed(BillingCycleListBodyElement)))
            {
                foreach (var row in BillingCycleListRows)
                {
                    var BillingCycleListNameElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListNameSelector);
                    var BillingCycleListUsageTypeElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListUsageTypeSelector);
                    var BillingCycleListPaymentTypeElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListPaymentTypeSelector);
                    var BillingCycleListFequencyElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListFequencySelector);

                    if (BillingCycleListNameElement.Text.Equals(billingName) && BillingCycleListUsageTypeElement.Text.Equals(billingUsage) &&
                        BillingCycleListPaymentTypeElement.Text.Equals(billingPaymentType) && BillingCycleListFequencyElement.Text.Equals("1"))
                    {
                        IsPresent = true;
                        var BillingCycleListStatusElement = SeleniumHelper.FindElementByCssSelector(row, BillingCycleListStatusSelector);
                        if (BillingCycleListStatusElement.Text.Equals(resourceBillingCysleStatusEnabled))
                        {
                            SeleniumHelper.ClickSafety(SeleniumHelper.FindElementByCssSelector(row, BillingCycleListActionsSelector));
                            SeleniumHelper.ClickSafety(SeleniumHelper.FindElementByCssSelector(row, BillingCycleListActionsDeleteSelector));
                            break;
                        }
                        else
                        {
                            LoggingService.WriteLog(LoggingLevel.WARNING, "The newly created billing cycle is already diabled when it should be enabled");
                            break;
                        }
                    }
                }
                TestCheck.AssertIsEqual(IsPresent, true, "Newly created billing cycle is not present in the billing cycles list");
            }
        }
    }
}
