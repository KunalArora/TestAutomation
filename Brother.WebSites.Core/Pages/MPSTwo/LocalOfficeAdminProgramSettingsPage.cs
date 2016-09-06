using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

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
        public IWebElement ProgramEnabledElement;
        [FindsBy(How = How.Id, Using = "content_1_InputDisplayProductAsList_Input")]
        public IWebElement DisplayProductAsListElement;
        [FindsBy(How = How.Id, Using = "content_1_InputHideProposalCustomerCreationStep_Input")]
        public IWebElement HideProposalCustomerCreationStepElement;
        [FindsBy(How = How.Id, Using = "content_1_InputUsageTypes_Input_0")]
        public IWebElement MinimumVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_InputUsageTypes_Input_1")]
        public IWebElement PayAsYouGoElement;
        [FindsBy(How = How.Id, Using = "content_1_InputDurations_Input_0")]
        public IWebElement ContactTerm3YearsElement;
        [FindsBy(How = How.Id, Using = "content_1_InputDurations_Input_1")]
        public IWebElement ContactTerm4YearsElement;
        [FindsBy(How = How.Id, Using = "content_1_InputDurations_Input_2")]
        public IWebElement ContactTerm5YearsElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSave")]
        public IWebElement SaveButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/programs/purchase-and-click/printers']")]
        public IWebElement PurchasePrintersLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/programs/purchase-and-click/approval-defaults']")]
        public IWebElement PurchaseApprovalDefaultsLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/programs/purchase-and-click/changable-items']")]
        public IWebElement PurchaseChangableItemsElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/programs/lease-and-click/printers']")]
        public IWebElement LeasingPrintersLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/programs/lease-and-click/approval-defaults']")]
        public IWebElement LeasingApprovalDefaultsLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/programs/lease-and-click/leasing-banks']")]
        public IWebElement LeasingBanksLinkElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputAutomaticProposalApproval_Input")]
        public IWebElement AutomaticProposalApprovalTickBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_MpsInstallationEnableAtPoint_Input_0")]
        public IWebElement InstallationPointAfterContractAcceptedTickBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_MpsInstallationEnableAtPoint_Input_1")]
        public IWebElement InstallationPointAfterContractSignedTickBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_MpsCustomerCreationPoint_Input_0")]
        public IWebElement CustomerPointAfterContractAcceptedTickBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_MpsCustomerCreationPoint_Input_1")]
        public IWebElement CustomerPointAfterContractSignedTickBoxElement;

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

        public void UntickHideProposalCustomerCreationStep()
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

        public void UntickMinimumVolume()
        {
            if (MinimumVolumeElement.Selected)
            {
                MinimumVolumeElement.Click();
            }
        }

        public void TryTickMinimumVolume()
        {
            SpecFlow.SetContext("OriginalMinimumVolume", MinimumVolumeElement.Selected.ToString());
            TickMinimumVolume();
        }

        public void SetProposalByPassOption()
        {
            var byPass = AutomaticProposalApprovalTickBoxElement.Selected ? "Ticked" : "Unticked";

            SpecFlow.SetContext("BypassOption", byPass);

            MsgOutput(String.Format("Bypass has been set as {0}", byPass));
        }

        public void SetInstallationPointOption()
        {
            var byPass = "";

            if (InstallationPointAfterContractAcceptedTickBoxElement.Selected)
            {
                byPass = "Contract Accepted";
            }
            else if(InstallationPointAfterContractSignedTickBoxElement.Selected)
            {
                byPass = "Contract Signed";
            }

            SpecFlow.SetContext("InstallationPointOption", byPass);

            MsgOutput(String.Format("Installation Point Option has been set as {0}", byPass));
        }

        public void SetCustomerCreationPointOption()
        {
            var byPass = "";

            if (CustomerPointAfterContractAcceptedTickBoxElement.Selected)
            {
                byPass = "Contract Accepted";
            }
            else if (CustomerPointAfterContractSignedTickBoxElement.Selected)
            {
                byPass = "Contract Signed";
            }

            SpecFlow.SetContext("CustomerCreationPointOption", byPass);

            MsgOutput(String.Format("Customer Creation Point has been set as {0}", byPass));
        }

        public void TryUntickMinimumVolume()
        {
            SpecFlow.SetContext("OriginalMinimumVolume", MinimumVolumeElement.Selected.ToString());
            UntickMinimumVolume();
        }

        public void IsMinimumVolumeTicked()
        {
            AssertElementIsChecked(MinimumVolumeElement, "true", "Minimum Volume");
            TeardownMinimumVolumeState();
        }

        public void IsMinimumVolumeUnticked()
        {
            AssertElementIsChecked(MinimumVolumeElement, null, "Minimum Volume");
            TeardownMinimumVolumeState();
        }

        private void TeardownMinimumVolumeState()
        {
            bool value;
            if (bool.TryParse(SpecFlow.GetContext("OriginalMinimumVolume"), out value))
            {
                if (value)
                {
                    TickMinimumVolume();
                }
                else
                {
                    UntickMinimumVolume();
                }
                SaveButtonElement.Click();
            }
        }

        public void TickPayAsYouGo()
        {
            if (!PayAsYouGoElement.Selected)
            {
                PayAsYouGoElement.Click();
            }
        }

        public void UntickPayAsYouGo()
        {
            if (PayAsYouGoElement.Selected)
            {
                PayAsYouGoElement.Click();
            }
        }

        public void TryTickPayAsYouGo()
        {
            SpecFlow.SetContext("OriginalPayAsYouGo", PayAsYouGoElement.Selected.ToString());
            TickPayAsYouGo();
        }

        public void TryUntickPayAsYouGo()
        {
            SpecFlow.SetContext("OriginalPayAsYouGo", PayAsYouGoElement.Selected.ToString());
            UntickPayAsYouGo();
        }

        public void IsPayAsYouGoTicked()
        {
            AssertElementIsChecked(PayAsYouGoElement, "true", "Pay As You Go");
            TeardownPayAsYouGoState();
        }

        public void IsPayAsYouGoUnticked()
        {
            AssertElementIsChecked(PayAsYouGoElement, null, "Pay As You Go");
            TeardownPayAsYouGoState();
        }

        private void TeardownPayAsYouGoState()
        {
            bool value;
            if (bool.TryParse(SpecFlow.GetContext("OriginalPayAsYouGo"), out value))
            {
                if (value)
                {
                    TickPayAsYouGo();
                }
                else
                {
                    UntickPayAsYouGo();
                }
                SaveButtonElement.Click();
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
