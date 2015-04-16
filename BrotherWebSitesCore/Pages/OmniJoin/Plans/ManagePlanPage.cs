using System;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.BrotherOnline.AccountManagement.PaymentMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.OmniJoin.Plans
{
    public class ManagePlanPage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = @"[href*='conference-control']")]
        public IList<IWebElement> ConferenceControlMenu;

        [FindsBy(How = How.CssSelector, Using = @".styled-radio [id*='monthlyChk']")]
        public IWebElement PlanOptionButtonMonthlySet;

        [FindsBy(How = How.CssSelector, Using = @".styled-radio [id*='annualyChk']")]
        public IWebElement PlanOptionButtonAnnualSet;

        [FindsBy(How = How.CssSelector, Using = @"[id*='PaymentTypesDropdownList']")]
        public IWebElement EditPaymentMethodDropDownList;

        [FindsBy(How = How.CssSelector, Using = @"#addpaymentbtn")]
        public IWebElement AddPaymentMethodLink;

        private const string ManagePlanLinkId = "Manage Plan";
        private const string EditPaymentMethodLinkId = "Edit payment method";
        private const string ChangePlanOrTermLinkId = "Change plan or term";
        private const string CancelSubscriptionLinkId = "Cancel Subscription";
        private IWebElement EditPaymentUpdateButton;
        private IWebElement ChangePlanUpdateButton;

        public void CheckPaymentMethodCount(int expectedCount)
        {
            if (EditPaymentMethodDropDownList != null)
            {
                TestCheck.AssertIsEqual(expectedCount, GetDropdownListItemCount(EditPaymentMethodDropDownList, "Payment Methods Drop Down List"), "Comparing Payment Methods");
            }
        }

        public void SelectPaymentMethod(string paymentMethod)
        {
            //GetDropdownListItemCount(EditPaymentMethodDropDownList, "Payment Methods");
            //SelectFromDropdownByValue(EditPaymentMethodDropDownList, paymentMethod);
            SelectFromDropdown(EditPaymentMethodDropDownList, paymentMethod);
            AssertItemIsSelected(EditPaymentMethodDropDownList, paymentMethod, "OJ Payment Method Drop Down List");
        }

        public bool IsInformationbarDisplayed()
        {
            var infoBar = Driver.FindElement(By.Id("#Information"));
            if (infoBar == null)
            {
                throw new NullReferenceException("Unable to locate Information bar");
            }

            return infoBar.Displayed;
        }

        public void IsChangePlanUpdateButtonAvailable()
        {
            ChangePlanUpdateButton = Driver.FindElement(By.CssSelector("#content_2_innercontent_1_innercontentbody_0_UpdateBtn"));
            if (ChangePlanUpdateButton == null)
            {
                throw new NullReferenceException("Unable to locate Change Plan Update Button");
            }

            AssertElementPresent(ChangePlanUpdateButton, "Change Plan Update Button");
        }

        public void IsEditPaymentUpdateButtonAvailable()
        {
            EditPaymentUpdateButton = Driver.FindElement(By.CssSelector("#content_2_innercontent_1_innercontentbody_0_Updatebtn"));
            if (EditPaymentUpdateButton == null)
            {
                throw new NullReferenceException("Unable to locale Edit Payment Update Button");
            }

            AssertElementPresent(EditPaymentUpdateButton, "Edit Payment Update Button");
        }

        public void ChangePlanUpdateButtonClick()
        {
            if (ChangePlanUpdateButton == null)
            {
                throw new NullReferenceException("Unable to locale Change Plan Update Button");
            }
            ChangePlanUpdateButton.Click();
        }

        public void EditPaymentUpdateButtonClick()
        {
            if (EditPaymentUpdateButton == null)
            {
                throw new NullReferenceException("Unable to locale Edit Payment Update Button");
            }
            EditPaymentUpdateButton.Click();
        }

        public MyPaymentMethodsPage AddPaymentMethodButtonClick()
        {
            if (AddPaymentMethodLink == null)
            {
                throw new NullReferenceException("Unable to locale Add Payment Button link");
            }
            AddPaymentMethodLink.Click();
            return GetInstance<MyPaymentMethodsPage>();
        }

        public void SelectOmniJoinPlan(string planType, string billingType)
        {
            IWebElement omniJoinPlan = null;
            var radioButtonNumber = -1;

            switch (planType)
            {
                case "OmniJoin Lite":
                    radioButtonNumber = 0;
                    break;
                case "OmniJoin":
                    radioButtonNumber = 1;
                    break;
                case "OmniJoin Pro":
                    radioButtonNumber = 2;
                    break;
            }

            omniJoinPlan = Driver.FindElement(billingType.Equals("Annual") ? By.CssSelector(string.Format(".styled-radio [id*='annualyChk_{0}']", radioButtonNumber)) : By.CssSelector(string.Format(".styled-radio [id*='monthlyChk_{0}']", radioButtonNumber)));
            if (omniJoinPlan != null)
            {
                omniJoinPlan.Click();
            }
        }

        public bool CheckCurrentOmniJoinPlanIsCorrect(string planType, string billingType)
        {
            var radioButtonNumber = -1;

            switch (planType)
            {
                case "OmniJoin Lite":
                    radioButtonNumber = 0;
                    break;
                case "OmniJoin":
                    radioButtonNumber = 1;
                    break;
                case "OmniJoin Pro":
                    radioButtonNumber = 2;
                    break;
            }

            if (billingType.Equals("Annual"))
            {
                var omniJoinBillingType = Driver.FindElement(By.CssSelector(string.Format(".styled-radio [id*='annualyChk_{0}']", radioButtonNumber)));
                if (omniJoinBillingType.Selected)
                {
                    Helper.MsgOutput(string.Format("Correct OmniJoin Plan is selected. [{0}] with Annual Billing", planType));
                    return true;
                }
            }
            else
            {
                var omniJoinPlanType = Driver.FindElement(By.CssSelector(string.Format(".styled-radio [id*='monthlyChk_{0}']", radioButtonNumber)));
                if (omniJoinPlanType.Selected)
                {
                    Helper.MsgOutput(string.Format("Correct OmniJoin Plan is selected. [{0}] with Monthly Billing", planType));
                    return true;
                }
            }
            Helper.MsgOutput("Incorrect OmniJoin Plan selected");
            return false;
        }

        public void EditPaymentMethodLinkClick()
        {
            var editPaymentLink = GetConferenceMenuLink(EditPaymentMethodLinkId);
            if (editPaymentLink == null)
            {
                throw new NullReferenceException("Unable to find Edit Payment Method link");
            }
            editPaymentLink.Click();
        }
        
        public void ManagePlanLinkClick()
        {
            var managePlanLink = GetConferenceMenuLink(ManagePlanLinkId);
            if (managePlanLink == null)
            {
                throw new NullReferenceException("Unable to find Manage Plan link");
            }
            managePlanLink.Click();
        }

        public void ChangePlanOrTermLinkClick()
        {
            var changePlanOrTermLink = GetConferenceMenuLink(ChangePlanOrTermLinkId);
            if (changePlanOrTermLink == null)
            {
                throw new NullReferenceException("Unable to find Change Plan Or Term link");
            }
            changePlanOrTermLink.Click();
        }

        public void CancelSubscriptionLinkClick()
        {
            var cancelSubscriptionLink = GetConferenceMenuLink(CancelSubscriptionLinkId);
            if (cancelSubscriptionLink == null)
            {
                throw new NullReferenceException("Unable to find Cancel Subscription link");
            }
            cancelSubscriptionLink.Click();
        }

        private IWebElement GetConferenceMenuLink(string menuName)
        {
            try
            {
                if (ConferenceControlMenu == null)
                {
                    return null;
                }

                foreach (var menuItem in ConferenceControlMenu)
                {
                    if (menuItem.Text.ToLower().Contains(menuName.ToLower()))
                    {
                        return menuItem;
                    }

                }
            }
            catch (Exception)
            {
                
                
            }
            return null;
        }
    }
}
