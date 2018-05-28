using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
using System.Collections.Generic;
using System.Globalization;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice
{
    public class LocalOfficeAgreementDetailsPage: DealerAgreementDetailsPage, IPageObject
    {
        private string _validationElementSelector = ".mps-qa-printer";
        private const string _url = "/mps/local-office/agreement/{agreementId}/details"; // TODO: Replace agreementId with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        private const string MonoClickRateSelector = "[id*=content_1_SummaryTable_RepeaterModels_MonoClickRate_]";
        private const string MonoVolumeSelector = "[id*=content_1_SummaryTable_RepeaterModels_MonoVolume_]";
        private const string ColourClickRateSelector = "[id*=content_1_SummaryTable_RepeaterModels_ColourClickRate_]";
        private const string ColourVolumeSelector = "[id*=content_1_SummaryTable_RepeaterModels_ColourVolume_]";
        private const string InstallationPackPriceSelector = "[id*=InstallationPackUnitPrice]";
        private const string ServicePackPriceSelector = "[id*=ServicePackUnitPrice]";
        private const string PrinterContainerPrefixSelector = ".mps-qa-printer-";
        

        public void VerifySpecialPricing(IEnumerable<PrinterProperties> printers, string servicePackType, CultureInfo cultureInfo)
        {
            LoggingService.WriteLogOnMethodEntry(printers, servicePackType, cultureInfo);

            string culture = cultureInfo.Name;

            ExpectedTranslationService _expectedTranslationService = new ExpectedTranslationService();

            foreach(var printer in printers)
            {
                var printerContainer = SeleniumHelper.FindElementByCssSelector(PrinterContainerPrefixSelector + printer.Model);

                var displayedMonoClickPrice = PageObjectExtensions.ConvertCultureNumericStringToInvariantNumericString(SeleniumHelper.FindElementByCssSelector(printerContainer, MonoClickRateSelector).Text, cultureInfo);
                TestCheck.AssertIsEqualValueInvariant(printer.MonoClickPrice, displayedMonoClickPrice, string.Format(
                    "Mono Click Price for printer {0} could not be verified after Special Pricing was applied", printer.Model));

                var displayedMonoVolume = PageObjectExtensions.ConvertCultureNumericStringToInvariantNumericString(SeleniumHelper.FindElementByCssSelector(printerContainer, MonoVolumeSelector).Text, cultureInfo);
                TestCheck.AssertIsEqualValueInvariant(printer.VolumeMono.ToString(), displayedMonoVolume, string.Format(
                    "Mono Volume for printer {0} could not be verified after Special Pricing was applied", printer.Model));

                if(!printer.IsMonochrome)
                {
                    var displayedColourClickPrice = PageObjectExtensions.ConvertCultureNumericStringToInvariantNumericString(SeleniumHelper.FindElementByCssSelector(printerContainer, ColourClickRateSelector).Text, cultureInfo);
                    TestCheck.AssertIsEqualValueInvariant(printer.ColourClickPrice, displayedColourClickPrice, string.Format(
                        "Colour Click Price for printer {0} could not be verified after Special Pricing was applied", printer.Model));

                    var displayedColourVolume = PageObjectExtensions.ConvertCultureNumericStringToInvariantNumericString(SeleniumHelper.FindElementByCssSelector(printerContainer, ColourVolumeSelector).Text, cultureInfo);
                    TestCheck.AssertIsEqualValueInvariant(printer.VolumeColour.ToString(), displayedColourVolume, string.Format(
                        "Colour Volume for printer {0} could not be verified after Special Pricing was applied", printer.Model));
                }

                if (printer.InstallationPack.ToLower().Equals("yes"))
                {
                    var displayedInvariantInstallationPrice = PageObjectExtensions.ConvertCultureNumericStringToInvariantNumericString(SeleniumHelper.FindElementByCssSelector(printerContainer, InstallationPackPriceSelector).Text, cultureInfo);
                    TestCheck.AssertIsEqualValueInvariant(printer.InstallationPackPrice, displayedInvariantInstallationPrice, string.Format(
                        "Installation Pack Price for printer {0} could not be verified after Special Pricing was applied", printer.Model));
                }

                if (printer.ServicePack.ToLower().Equals("yes") && servicePackType.Equals(_expectedTranslationService.GetServicePackTypeText(TranslationKeys.ServicePackType.PayUpfront, culture)))
                {
                    var displayedServicePrice = PageObjectExtensions.ConvertCultureNumericStringToInvariantNumericString(SeleniumHelper.FindElementByCssSelector(printerContainer, ServicePackPriceSelector).Text, cultureInfo);
                    TestCheck.AssertIsEqualValueInvariant(printer.ServicePackPrice, displayedServicePrice, string.Format(
                        "Service Pack Price for printer {0} could not be verified after Special Pricing was applied", printer.Model));
                }
            }
        }
    }
}