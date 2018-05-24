using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice
{
    public class LocalOfficeAgreementManageSpecialPricingPage: BasePage, IPageObject
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
        private const string AuditDetailsSelector = "div > div.modal-body.mps-special-pricing-modal-body > div > div.panel.panel-default > div.panel-body > table > tbody";





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

        public void EditInstallationPricesAndProceed(IEnumerable<PrinterProperties> printers, IEnumerable<SpecialPricingProperties> specialPriceList)
        {
            LoggingService.WriteLogOnMethodEntry(printers, specialPriceList);

            var installTabElement = SeleniumHelper.FindElementByCssSelector(InstallTabSelector);

            var rowElements = SeleniumHelper.FindElementsByCssSelector(installTabElement, InstallTabRowSelector);

            foreach (var printer in printers)
            {
                foreach (var rowElement in rowElements)
                {
                    var displayedModelName = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "description", "true").Text;
                    if (displayedModelName.Equals(printer.Model) && printer.InstallationPack.ToLower().Equals("yes"))
                    {
                        var specialPrice = specialPriceList.First(l => Regex.IsMatch(displayedModelName, l.Model));
                        var unitPrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "unit-price", "true");
                        var newUnitPrice = specialPrice.AdjustValue(unitPrice.GetAttribute("value"), specialPrice.InstallUnitPrice, Culture) ;
                        ClearAndType(unitPrice, newUnitPrice);
                        printer.InstallationPackPrice = newUnitPrice; // Save to context data for later verification
                        printer._IsApplySpecialPriceInstall = true;
                        break;
                    }
                }
            }

            SeleniumHelper.ClickSafety(
                SeleniumHelper.FindElementByCssSelector(NextButtonSelector));
        }
       
        public void EditServicePricesAndProceed(IEnumerable<PrinterProperties> printers, IEnumerable<SpecialPricingProperties> specialPriceList)
        {
            LoggingService.WriteLogOnMethodEntry(printers, specialPriceList);

            var serviceTabElement = SeleniumHelper.FindElementByCssSelector(ServiceTabSelector);

            var rowElements = SeleniumHelper.FindElementsByCssSelector(serviceTabElement, ServiceTabRowSelector);

            foreach (var printer in printers)
            {
                foreach (var rowElement in rowElements)
                {
                    var displayedModelName = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "description", "true").Text;
                    if (displayedModelName.Equals(printer.Model) && printer.ServicePack.ToLower().Equals("yes"))
                    {
                        var specialPrice = specialPriceList.First(l => Regex.IsMatch(displayedModelName, l.Model));
                        var unitPrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "unit-price", "true");
                        var newUnitPrice = specialPrice.AdjustValue(unitPrice.GetAttribute("value"),specialPrice.ServiceUnitPrice,Culture) ;
                        ClearAndType(unitPrice, newUnitPrice);
                        printer.ServicePackPrice = newUnitPrice; // Save to context data for later verification
                        printer._IsApplySpecialPriceService = true;
                        break;
                    }
                }
            }

            SeleniumHelper.ClickSafety(
                SeleniumHelper.FindElementByCssSelector(NextButtonSelector));
        }

        public void EditClickPricesAndProceed(IEnumerable<PrinterProperties> printers, string servicePackType, string culture, IEnumerable<SpecialPricingProperties> specialPriceList, bool isCheckAutoCalculateClickPrice, CultureInfo cultureInfo)
        {
            LoggingService.WriteLogOnMethodEntry(printers, servicePackType, culture, specialPriceList);

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
                        var specialPrice = specialPriceList.First(l => Regex.IsMatch(displayedModelName, l.Model));
                        string newServicePrice = null;
                        if (printer.ServicePack.ToLower().Equals("yes") && servicePackType.Equals(_expectedTranslationService.GetServicePackTypeText(TranslationKeys.ServicePackType.IncludedInClickPrice, culture)))
                        {
                            var servicePrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "service-unit-price", "true");
                            newServicePrice = specialPrice.AdjustValue(servicePrice.GetAttribute("value"), specialPrice.ServiceUnitPrice, culture);
                            ClearAndType(servicePrice, newServicePrice);
                        }

                        var monoCoverage = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "mono-coverage", "true");
                        string newMonoCoverage = specialPrice.AdjustValue(monoCoverage.GetAttribute("value"), specialPrice.MonoClickCoverage, culture);
                        ClearAndType(monoCoverage, newMonoCoverage);

                        var monoVolume = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "mono-volume", "true");
                        string newMonoVolume = specialPrice.AdjustValue(monoVolume.GetAttribute("value"), specialPrice.MonoClickVolume, culture);

                        ClearAndType(monoVolume, newMonoVolume);

                        if (!printer.IsMonochrome)
                        {
                            var colourCoverage = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "colour-coverage", "true");
                            var newColourCoverage = specialPrice.AdjustValue(colourCoverage.GetAttribute("value"), specialPrice.ColourClickCoverage, culture);
                            ClearAndType(colourCoverage, newColourCoverage);

                            var colourVolume = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "colour-volume", "true");
                            var newColourVolume = specialPrice.AdjustValue(colourVolume.GetAttribute("value"), specialPrice.ColourClickVolume, culture);
                            ClearAndType(colourVolume, newColourVolume);

                            // Save to context data for later verification (colour)
                            var colourClickPrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "colour-click", "true");
                            printer.CoverageColour = Int32.Parse(newColourCoverage, NumberStyles.AllowThousands);
                            printer.VolumeColour = Int32.Parse(newColourVolume, NumberStyles.AllowThousands);
                            printer.ColourClickPrice = colourClickPrice.GetAttribute("value");
                        }

                        // Verify that new click price is different from the older one
                        var monoClickPrice = SeleniumHelper.FindElementByDataAttributeValue(rowElement, "mono-click", "true");
                        var oldMonoClickPrice = SeleniumHelper.FindElementByCssSelector(rowElement, ".m-1-10");
                        if( isCheckAutoCalculateClickPrice)
                        {
                            SeleniumHelper.WaitUntil(d => (monoClickPrice.GetAttribute("value") != PageObjectExtensions.ConvertCultureNumericStringToInvariantNumericString(oldMonoClickPrice.Text, cultureInfo)));
                        }

                        // Save to context data for later verification (mono)
                        printer.ServicePackPrice = newServicePrice;
                        printer.CoverageMono = Int32.Parse(newMonoCoverage, NumberStyles.AllowThousands);
                        printer.VolumeMono = Int32.Parse(newMonoVolume, NumberStyles.AllowThousands);
                        printer.MonoClickPrice = monoClickPrice.GetAttribute("value");
                        printer._IsApplySpecialPriceClickPrice = true;
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

        public string[] GetAuditDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            var confirmationModal = SeleniumHelper.FindElementByCssSelector(ConfirmationModalSelector);
            var tbodyElement = SeleniumHelper.FindElementByCssSelector(confirmationModal, AuditDetailsSelector);
            var text = SeleniumHelper.WaitUntil(d => string.IsNullOrWhiteSpace(tbodyElement.Text) ? null : tbodyElement.Text);
            var array = text.Replace("\r", "").Split('\n');
            return array;
        }
    }

}
