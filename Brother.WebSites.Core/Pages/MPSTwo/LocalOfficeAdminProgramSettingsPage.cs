﻿using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminProgramSettingPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_InputProgramEnabled_Input")]
        private IWebElement ProgramEnabledElement;
        [FindsBy(How = How.Id, Using = "content_1_InputDisplayProductAsList_Input")]
        private IWebElement DisplayProductAsListElement;
        [FindsBy(How = How.Id, Using = "content_1_InputHideProposalCustomerCreationStep_Input")]
        private IWebElement HideProposalCustomerCreationStepElement;
        [FindsBy(How = How.Id, Using = "content_1_InputUsageTypes_Input_0")]
        private IWebElement MinimumVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_InputUsageTypes_Input_1")]
        private IWebElement PayAsYouGoElement;
        [FindsBy(How = How.Id, Using = "content_1_InputDurations_Input_0")]
        private IWebElement ContactTerm3YearsElement;
        [FindsBy(How = How.Id, Using = "content_1_InputDurations_Input_1")]
        private IWebElement ContactTerm4YearsElement;
        [FindsBy(How = How.Id, Using = "content_1_InputDurations_Input_2")]
        private IWebElement ContactTerm5YearsElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSave")]
        private IWebElement SaveButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/purchase-and-click/printers']")]
        private IWebElement PurchasePrintersLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/purchase-and-click/approval-defaults']")]
        private IWebElement PurchaseApprovalDefaultsLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/purchase-and-click/changable-items']")]
        private IWebElement PurchaseChangableItemsElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/lease-and-click/printers']")]
        private IWebElement LeasingPrintersLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/lease-and-click/approval-defaults']")]
        private IWebElement LeasingApprovalDefaultsLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/lease-and-click/leasing-banks']")]
        private IWebElement LeasingBanksLinkElement;

        public void TickProgramEnabled()
        {
            if (!ProgramEnabledElement.Selected)
            {
                ProgramEnabledElement.Click();
            }
        }

        public void UntickProgramEnabled()
        {
            if (ProgramEnabledElement.Selected)
            {
                ProgramEnabledElement.Click();
            }
        }

        public void TickDisplayProductsAsList()
        {
            if (!DisplayProductAsListElement.Selected)
            {
                DisplayProductAsListElement.Click();
            }
        }

        public void UntickDisplayProductsAsList()
        {
            if (DisplayProductAsListElement.Selected)
            {
                DisplayProductAsListElement.Click();
            }
        }

        public void TickHideProposalCustomerCreationStep()
        {
            if (!HideProposalCustomerCreationStepElement.Selected)
            {
                HideProposalCustomerCreationStepElement.Click();
            }
        }

        public void untickHideProposalCustomerCreationStep()
        {
            if (HideProposalCustomerCreationStepElement.Selected)
            {
                HideProposalCustomerCreationStepElement.Click();
            }
        }

        public void TickMinimumVolume()
        {
            if (!MinimumVolumeElement.Selected)
            {
                MinimumVolumeElement.Click();
            }
        }

        public void untickMinimumVolume()
        {
            if (MinimumVolumeElement.Selected)
            {
                MinimumVolumeElement.Click();
            }
        }

        public void TickPayAsYouGo()
        {
            if (!PayAsYouGoElement.Selected)
            {
                PayAsYouGoElement.Click();
            }
        }

        public void untickPayAsYouGo()
        {
            if (PayAsYouGoElement.Selected)
            {
                PayAsYouGoElement.Click();
            }
        }

        public void TickContractTerm3Years()
        {
            if (!ContactTerm3YearsElement.Selected)
            {
                ContactTerm3YearsElement.Click();
            }
        }

        public void untickContractTerm3Years()
        {
            if (ContactTerm3YearsElement.Selected)
            {
                ContactTerm3YearsElement.Click();
            }
        }

        public void TickContractTerm4Years()
        {
            if (!ContactTerm4YearsElement.Selected)
            {
                ContactTerm4YearsElement.Click();
            }
        }

        public void untickContractTerm4Years()
        {
            if (ContactTerm4YearsElement.Selected)
            {
                ContactTerm4YearsElement.Click();
            }
        }

        public void TickContractTerm5Years()
        {
            if (!ContactTerm5YearsElement.Selected)
            {
                ContactTerm5YearsElement.Click();
            }
        }

        public void untickContractTerm5Years()
        {
            if (ContactTerm5YearsElement.Selected)
            {
                ContactTerm5YearsElement.Click();
            }
        }

        public void ClickSave()
        {
                SaveButtonElement.Click();
        }

        private void IsPurchasePrintersLinkAvailable()
        {
            if (PurchasePrintersLinkElement == null)
                throw new Exception("Unable to locate Purchase Printers link element");
        }

        public LocalOfficeAdminPrintersPage NavigateToLocalOfficePurchasePrintersPage()
        {
            IsPurchasePrintersLinkAvailable();
            PurchasePrintersLinkElement.Click();
            return GetTabInstance<LocalOfficeAdminPrintersPage>(Driver);
        }

        private void IsLeasePrintersLinkAvailable()
        {
            if (PurchasePrintersLinkElement == null)
                throw new Exception("Unable to locate Lease Printers link element");
        }

        public LocalOfficeAdminPrintersPage NavigateToLocalOfficeLeasePrintersPage()
        {
            IsLeasePrintersLinkAvailable();
            LeasingPrintersLinkElement.Click();
            return GetTabInstance<LocalOfficeAdminPrintersPage>(Driver);
        }

        private void IsLeasingBanksLinkAvailable()
        {
            if (LeasingBanksLinkElement == null)
                throw new Exception("Unable to locate Leasing Banks link element");

            AssertElementPresent(LeasingBanksLinkElement, "Leasing Banks Link");
        }

        public LocalOfficeAdminLeasingBanks NavigateToLocalOfficeLeasingBanksPage()
        {
            IsLeasingBanksLinkAvailable();
            LeasingBanksLinkElement.Click();
            return GetTabInstance<LocalOfficeAdminLeasingBanks>(Driver);
        }
    }
}
