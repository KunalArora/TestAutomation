﻿﻿using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice
{
    public class LocalOfficeAgreementDevicesPage : DealerAgreementDevicesPage, IPageObject // Inherit DealerAgreementDevicesPage as properties are exactly same
    {
        private const string _validationElementSelector = ".mps-dataTables-footer"; // Device data table footer
        private const string _url = "/mps/local-office/agreement/{agreementId}/devices"; // TODO: Replace agreementId with dynamic parameter

        public new string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public new string PageUrl
        {
            get
            {
                return _url;
            }
        }

        private const string InstallationOptionIdSelector = "installation-option-id";
        private const string CustomiseInstallOptionsModalSelector = ".js-mps-manage-customise-install-options-modal";

        // Tab link selectors
        private const string MpsTabsSelector = ".mps-tabs-main";
        private const string MpsTabsAgreementSelector = " a[href=\"/mps/local-office/agreement/";

        // Web Elements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-ribbon-customise-installation-options-data")]
        public IWebElement CustomiseButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-save-installation-options-modal")]
        public IWebElement InstallationOptionSaveButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".separator [href=\"/mps/local-office/dashboard\"]")]
        public IWebElement LocalOfficeDashboardButtonLink;
        

        public void EnableInstallationOption(string communicationMethod, string installationType)
        {
            LoggingService.WriteLogOnMethodEntry(communicationMethod, installationType);
            SeleniumHelper.FindElementByCssSelector(CustomiseInstallOptionsModalSelector);

            IWebElement element = null;
            switch(communicationMethod.ToLower())
            {
                case "cloud":
                    {
                        element = GetInstallationTypeElementForCloudDevice(installationType.ToLower());
                        break;
                    }
                case "email":
                    {
                        element = GetInstallationTypeElementForEmailDevice(installationType.ToLower());
                        break;
                    }
                default:
                    throw new Exception(
                            string.Format("No such communication = {0} exists", communicationMethod));

            }

            if (element != null)
            {
                if (!element.Selected)
                {
                    SeleniumHelper.ClickSafety(element);
                }
            }
            else
            {
                throw new Exception("Checkbox on Installation Option selection modal could not be selected");
            }
        }

        #region private methods

        private IWebElement GetInstallationTypeElementForCloudDevice(string installationType)
        {
            LoggingService.WriteLogOnMethodEntry(installationType);
            string dataAttributeValue;
            switch (installationType)
            {
                case "bor":
                    {
                        dataAttributeValue = "1";
                        break;
                    }
                case "web":
                    {
                        dataAttributeValue = "2";
                        break;
                    }
                case "usb":
                    {
                        dataAttributeValue = "4";
                        break;
                    }
                case "singlepc":
                    {
                        dataAttributeValue = "5";
                        break;
                    }
                default:
                    throw new Exception(
                        string.Format(
                        "No such installation option ({0}) exists for cloud communication",
                        installationType));
            }

            return SeleniumHelper.FindElementByDataAttributeValue(InstallationOptionIdSelector, dataAttributeValue);
        }

        private IWebElement GetInstallationTypeElementForEmailDevice(string installationType)
        {
            LoggingService.WriteLogOnMethodEntry(installationType);
            IWebElement element;
            switch (installationType)
            {
                case "web":
                    {
                        element = SeleniumHelper.FindElementByDataAttributeValue(InstallationOptionIdSelector, "3");
                        break;
                    }
                default:
                    throw new Exception(
                        string.Format(
                        "No such installation option ({0}) exists for email communication",
                        installationType));
            }

            return element;
        }

        public IWebElement ConsumablesTabElement(int agreementId)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);
            return SeleniumHelper.FindElementByCssSelector(
                string.Format(MpsTabsSelector + MpsTabsAgreementSelector + "{0}/consumables\"]", agreementId.ToString()));
        }

        public IWebElement BillingTabElement(int agreementId)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);
            return SeleniumHelper.FindElementByCssSelector(
                string.Format(MpsTabsSelector + MpsTabsAgreementSelector + "{0}/billing\"]", agreementId.ToString()));
        }
        #endregion
    }
}
