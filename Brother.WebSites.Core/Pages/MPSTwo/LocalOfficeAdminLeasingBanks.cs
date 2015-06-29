using System;
using System.Collections.Generic;
using System.ComponentModel;
using Brother.WebSites.Core.Pages.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminLeasingBanks : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using =@".js-mps-edit-leasing-bank")]
        private IList<IWebElement> EditButtonElements;
        [FindsBy(How = How.Id, Using = @"content_1_InputSRPConstraintPercentage_Input")]
        private IWebElement SellPriceVsSrpConstraintTextboxElement;
        [FindsBy(How = How.Id, Using =@"content_1_ButtonNext")]
        private IWebElement SaveButtonElement;


        private void IsEditButtonElementAvaialble()
        {
            if (EditButtonElements.Last() == null)
                throw new Exception("Unable to locate edit button link");

            AssertElementPresent(EditButtonElements.Last(), "Edit Existing Bank Button Link");
        }

        public void ClickEditButton()
        {
            IsEditButtonElementAvaialble();
            EditButtonElements.Last().Click();
        }

        private void IsSellPriceVsSrpConstraintElementAvailable()
        {
            if (SellPriceVsSrpConstraintTextboxElement == null)
                throw new Exception("Unable to locate Sell Price vs SRP Constraint % Dropdown");

            AssertElementPresent(SellPriceVsSrpConstraintTextboxElement, "Sell Price vs SRP Constraint % Dropdown");
        }

        private void IsSaveButtonElementAvailable()
        {
            if (SaveButtonElement == null)
                throw new Exception("Unable to locate Save Button link");

            AssertElementPresent(SaveButtonElement, "Save Button Link");
        }

        public void EditSellPriceVsSrpConstraint()
        {
            IsSellPriceVsSrpConstraintElementAvailable();
            var targetText = "15";
            SelectFromDropdown(SellPriceVsSrpConstraintTextboxElement, targetText);
            SpecFlow.SetContext("SelectedSellPrice", targetText);
        }

        public void ClickSaveButton()
        {
            IsSaveButtonElementAvailable();
            SaveButtonElement.Click();
        }

        public void VerifyEditedSellPriceValue()
        {
            IsSellPriceVsSrpConstraintElementAvailable();
            var target = SpecFlow.GetContext("SelectedSellPrice");
            AssertElementText(new SelectElement(SellPriceVsSrpConstraintTextboxElement).SelectedOption, target, "Modified Sell Price vs SRP Constraint Mismatch");
        }
    }
}
