using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class CreateActivationCodesPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_btnPreview")] 
        public IWebElement PurchaseCodesButton;

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_ddlProductPlan")]
        public IWebElement ProductPlanDropDownList;

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_ddlLicenseType")]
        public IWebElement LicenseTypeDropDownList;

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_ddlProduct")]
        public IWebElement PaymentMethodDropDownList;

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_txtNumberOfLicences")] 
        public IWebElement NumberOfLicensesSpinner;

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_btnConfirm")] 
        public IWebElement Confirm;

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_btnCancel")] 
        public IWebElement Cancel;

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_txtComment")]
        public IWebElement CommentField;

        public CreateActivationCodesPage ConfirmButtonClick()
        {
            var confirmButton = Driver.FindElement(By.CssSelector("#content_1_innercontent_2_btnConfirm"));
            confirmButton.Click();
            return GetInstance<CreateActivationCodesPage>();
        }

        public SuccessPage IsSuccessAvailable()
        {
            var success = Driver.FindElement(By.CssSelector(".content-unit.six h2"));
            if (success == null)
            {
                throw new NullReferenceException("Success is NULL");
            }
            AssertElementPresent(success, "Success Page");
            return GetInstance<SuccessPage>();
        }

        public CreateActivationCodesPage PurchaseCodesButtonClick()
        {
            var purchaseCodesButton = Driver.FindElement(By.CssSelector("#content_1_innercontent_2_btnPreview"));
            purchaseCodesButton.Click();
            return GetInstance<CreateActivationCodesPage>();
        }

        public void SelectNumberLicenses(int numLicenses)
        {
            NumberOfLicensesSpinner.Clear();
            NumberOfLicensesSpinner.SendKeys(numLicenses.ToString());
        }

        public void AddComment(string comment)
        {
            CommentField.Clear();
            CommentField.SendKeys(comment);
        }

        public void SelectProductPlan(string plan)
        {
            SelectFromDropdown(ProductPlanDropDownList, plan);
        }

        public void SelectPaymentMethod(string paymentMethod)
        {
            SelectFromDropdown(PaymentMethodDropDownList, paymentMethod);
        }

        public void SelectLicenseType(string licenseType)
        {
            SelectFromDropdown(LicenseTypeDropDownList, licenseType);
        }

        public void IsPurchaseCodesButtonAvailable()
        {
            var purchaseCodesButton = Driver.FindElement(By.CssSelector("#content_1_innercontent_2_btnPreview"));
            if (purchaseCodesButton == null)
            {
                throw new NullReferenceException("Purchase Codes button is NULL");
            }
            AssertElementPresent(purchaseCodesButton, "Purchase Codes Button");
        }

        public void IsConfirmButtonAvailable()
        {
            var confirmButton = Driver.FindElement(By.CssSelector("#content_1_innercontent_2_btnConfirm"));
            if (confirmButton == null)
            {
                throw new NullReferenceException("Confirm button is NULL");
            }
            AssertElementPresent(confirmButton, "Confirm Button");
        }
    }
}
