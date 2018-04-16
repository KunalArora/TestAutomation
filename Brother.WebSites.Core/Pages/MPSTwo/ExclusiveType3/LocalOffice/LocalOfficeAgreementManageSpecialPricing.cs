using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice
{
    public class LocalOfficeAgreementManageSpecialPricing: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".js-mps-val-btn-next"; // Next button
        private const string _url = "/mps/local-office/agreement/{agreementId}/manage/special-pricing"; // TODO: Replace agreementId with dynamic parameter

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

        private const string NextButtonSelector = ".js-mps-val-btn-next";
        private const string ValidateButtonSelector = ".js-mps-submit.js-mps-val-btn-next";
        private const string NavigateClickTabSelector = "#content_1_NavClickTab";
        private const string NavigateInstallTabSelector = "#content_1_NavInstallTab";
        private const string NavigateServiceTabSelector = "#content_1_NavServiceTab";
        private const string InstallTabSelector = "#InstallTab > .row > .col-sm-12";
        private const string ServiceTabSelector = "#ServiceTab > .row > .col-sm-12";
        private const string ClickTabSelector = "#ClickTab > .row > .col-sm-12";
        private const string InstallTabRowSelector = ".js-special-pricing-installation-row";
        private const string ServiceTabRowSelector = ".js-special-pricing-service-row";
        private const string ClickTabRowSelector = ".js-special-pricing-click-row";
        private const string ConfirmationModalSelector = ".js-mps-special-pricing-confirm-modal-content";
        private const string ConfirmationModalAdditionalAuditSelector = ".js-special-pricing-modal-additional-audit";
        private const string ConfirmationModalApplySpecialPricingSelector = ".js-special-pricing-confirm";





        public void VerifyDisplayOfAppropriateTabs(IEnumerable<PrinterProperties> printers, string servicePackType, string culture, out bool isInstallationTab, out bool isServiceTab)
        {
            LoggingService.WriteLogOnMethodEntry(printers, servicePackType, culture);

            isInstallationTab = false;
            isServiceTab = false;

            foreach (var printer in printers)
            {
                if (printer.InstallationPack.ToLower().Equals("yes"))
                {
                    isInstallationTab = true;
                }
                if (printer.ServicePack.ToLower().Equals("yes"))
                {
                    isServiceTab = true;
                }
            }

            ExpectedTranslationService _expectedTranslationService = new ExpectedTranslationService();

            if (servicePackType.Equals(_expectedTranslationService.GetServicePackTypeText(TranslationKeys.ServicePackType.IncludedInClickPrice, culture)))
            {
                isServiceTab = false;
            }

            if (SeleniumHelper.IsElementNotPresent(NavigateClickTabSelector))
            {
                TestCheck.AssertFailTest(string.Format("Click Tab should be displayed on the Manage Special Pricing page but is actually not displayed"));
            }

            if (isInstallationTab && SeleniumHelper.IsElementNotPresent(NavigateInstallTabSelector))
            {
                TestCheck.AssertFailTest(string.Format("Installation Tab should be displayed on the Manage Special Pricing page but is actually not displayed"));
            }
            else if (!isInstallationTab && SeleniumHelper.IsElementPresent(NavigateInstallTabSelector))
            {
                TestCheck.AssertFailTest(string.Format("Installation Tab should not be displayed on the Manage Special Pricing page but is actually displayed"));
            }

            if (isServiceTab && SeleniumHelper.IsElementNotPresent(NavigateServiceTabSelector))
            {
                TestCheck.AssertFailTest(string.Format("Service Tab should be displayed on the Manage Special Pricing page but is actually not displayed"));
            }
            else if (!isServiceTab && SeleniumHelper.IsElementPresent(NavigateServiceTabSelector))
            {
                TestCheck.AssertFailTest(string.Format("Service Tab should not be displayed on the Manage Special Pricing page but is actually displayed"));
            }
        }

        public void EditInstallationPricesAndProceed(IEnumerable<PrinterProperties> printers)
        {
            LoggingService.WriteLogOnMethodEntry(printers);

            var installTabElement = SeleniumHelper.FindElementByCssSelector(InstallTabSelector);

            var rowElements = SeleniumHelper.FindElementsByCssSelector(installTabElement, InstallTabRowSelector);

            foreach (var printer in printers)
            {
                foreach (var rowElement in rowElements)
                {
                    var displayedModelName = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "description", "true").Text;
                    if (displayedModelName.Equals(printer.Model) && printer.InstallationPack.ToLower().Equals("yes"))
                    {
                        var unitPrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "unit-price", "true");
                        var newUnitPrice = (double.Parse(unitPrice.GetAttribute("value")) - 10).ToString();
                        ClearAndType(unitPrice, newUnitPrice);
                        printer.InstallationPackPrice = newUnitPrice; // Save to context data for later verification
                        break;
                    }
                }
            }

            SeleniumHelper.ClickSafety(
                SeleniumHelper.FindElementByCssSelector(NextButtonSelector));
        }

        public void EditServicePricesAndProceed(IEnumerable<PrinterProperties> printers)
        {
            LoggingService.WriteLogOnMethodEntry(printers);

            var serviceTabElement = SeleniumHelper.FindElementByCssSelector(ServiceTabSelector);

            var rowElements = SeleniumHelper.FindElementsByCssSelector(serviceTabElement, ServiceTabRowSelector);

            foreach (var printer in printers)
            {
                foreach (var rowElement in rowElements)
                {
                    var displayedModelName = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "description", "true").Text;
                    if (displayedModelName.Equals(printer.Model) && printer.ServicePack.ToLower().Equals("yes"))
                    {
                        var unitPrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "unit-price", "true");
                        string newUnitPrice = (double.Parse(unitPrice.GetAttribute("value")) - 10).ToString();
                        ClearAndType(unitPrice, newUnitPrice);
                        printer.ServicePackPrice = newUnitPrice; // Save to context data for later verification
                        break;
                    }
                }
            }

            SeleniumHelper.ClickSafety(
                SeleniumHelper.FindElementByCssSelector(NextButtonSelector));
        }

        public void EditClickPricesAndProceed(IEnumerable<PrinterProperties> printers, string servicePackType, string culture)
        {
            LoggingService.WriteLogOnMethodEntry(printers, servicePackType, culture);

            var clickTabElement = SeleniumHelper.FindElementByCssSelector(ClickTabSelector);

            var rowElements = SeleniumHelper.FindElementsByCssSelector(clickTabElement, ClickTabRowSelector);

            ExpectedTranslationService _expectedTranslationService = new ExpectedTranslationService();

            foreach (var printer in printers)
            {
                foreach (var rowElement in rowElements)
                {
                    var displayedModelName = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "description", "true").Text;
                    if (displayedModelName.Equals(printer.Model))
                    {
                        string newServicePrice = null;
                        if (printer.ServicePack.ToLower().Equals("yes") && servicePackType.Equals(_expectedTranslationService.GetServicePackTypeText(TranslationKeys.ServicePackType.IncludedInClickPrice, culture)))
                        {
                            var servicePrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "service-unit-price", "true");
                            newServicePrice = (double.Parse(servicePrice.GetAttribute("value")) - 10).ToString();
                            ClearAndType(servicePrice, newServicePrice);
                        }

                        var monoCoverage = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "mono-coverage", "true");
                        string newMonoCoverage = (double.Parse(monoCoverage.GetAttribute("value")) - 10).ToString();
                        ClearAndType(monoCoverage, newMonoCoverage);

                        var monoVolume = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "mono-volume", "true");
                        string newMonoVolume = (double.Parse(monoVolume.GetAttribute("value")) - 100).ToString();
                        ClearAndType(monoVolume, newMonoVolume);

                        if (!printer.IsMonochrome)
                        {
                            var colourCoverage = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "colour-coverage", "true");
                            string newColourCoverage = (double.Parse(colourCoverage.GetAttribute("value")) - 10).ToString();
                            ClearAndType(colourCoverage, newColourCoverage);

                            var colourVolume = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "colour-volume", "true");
                            string newColourVolume = (double.Parse(colourVolume.GetAttribute("value")) - 100).ToString();
                            ClearAndType(colourVolume, newColourVolume);

                            // Save to context data for later verification (colour)
                            var colourClickPrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "colour-click", "true");
                            printer.CoverageColour = Int32.Parse(newColourCoverage);
                            printer.VolumeColour = Int32.Parse(newColourVolume);
                            printer.ColourClickPrice = colourClickPrice.GetAttribute("value");
                        }

                        // Verify that new click price is different from the older one
                        var monoClickPrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "mono-click", "true");
                        var oldMonoClickPrice = SeleniumHelper.FindElementByCssSelector(rowElement, ".m-1-10");
                        SeleniumHelper.WaitUntil(d => (monoClickPrice.GetAttribute("value") != oldMonoClickPrice.Text.Substring(1)));

                        // Save to context data for later verification (mono)
                        printer.ServicePackPrice = newServicePrice;
                        printer.CoverageMono = Int32.Parse(newMonoCoverage);
                        printer.VolumeMono = Int32.Parse(newMonoVolume);
                        printer.MonoClickPrice = monoClickPrice.GetAttribute("value");

                        break;
                    }
                }
            }

            SeleniumHelper.ClickSafety(
                SeleniumHelper.FindElementByCssSelector(ValidateButtonSelector)); // Click Validate button
        }

        public void ConfirmSpecialPricingAndApply()
        {
            LoggingService.WriteLogOnMethodEntry();

            var confirmationModal = SeleniumHelper.FindElementByCssSelector(ConfirmationModalSelector);

            // Fill Additional Audit Information
            var additionalAudit = SeleniumHelper.FindElementByCssSelector(confirmationModal, ConfirmationModalAdditionalAuditSelector);
            ClearAndType(additionalAudit, "New prices requested for this agreement", true);

            var applySpecialPricingButton = SeleniumHelper.FindElementByCssSelector(confirmationModal, ConfirmationModalApplySpecialPricingSelector);

            SeleniumHelper.WaitUntil(d => applySpecialPricingButton.Enabled);

            // Click Apply Special Pricing button
            SeleniumHelper.ClickSafety(applySpecialPricingButton);
            SeleniumHelper.WaitUntil(d => ExpectedConditions.StalenessOf(applySpecialPricingButton));
        }
    }
}
