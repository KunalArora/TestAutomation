using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
using System.Collections.Generic;

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


        public void VerifySpecialPricing(IEnumerable<PrinterProperties> printers, string servicePackType, string culture)
        {
            LoggingService.WriteLogOnMethodEntry(printers, servicePackType, culture);
            
            ExpectedTranslationService _expectedTranslationService = new ExpectedTranslationService();

            foreach(var printer in printers)
            {
                var printerContainer = SeleniumHelper.FindElementByCssSelector(PrinterContainerPrefixSelector + printer.Model);

                var displayedMonoClickPrice = SeleniumHelper.FindElementByCssSelector(printerContainer, MonoClickRateSelector).Text.Substring(1);
                TestCheck.AssertIsEqual(printer.MonoClickPrice, displayedMonoClickPrice, string.Format(
                    "Mono Click Price for printer {0} could not be verified after Special Pricing was applied", printer.Model));

                var displayedMonoVolume = SeleniumHelper.FindElementByCssSelector(printerContainer, MonoVolumeSelector).Text.Replace(",", "");
                TestCheck.AssertIsEqual(printer.VolumeMono.ToString(), displayedMonoVolume, string.Format(
                    "Mono Volume for printer {0} could not be verified after Special Pricing was applied", printer.Model));

                if(!printer.IsMonochrome)
                {
                    var displayedColourClickPrice = SeleniumHelper.FindElementByCssSelector(printerContainer, ColourClickRateSelector).Text.Substring(1);
                    TestCheck.AssertIsEqual(printer.ColourClickPrice, displayedColourClickPrice, string.Format(
                        "Colour Click Price for printer {0} could not be verified after Special Pricing was applied", printer.Model));

                    var displayedColourVolume = SeleniumHelper.FindElementByCssSelector(printerContainer, ColourVolumeSelector).Text.Replace(",", "");
                    TestCheck.AssertIsEqual(printer.VolumeColour.ToString(), displayedColourVolume, string.Format(
                        "Colour Volume for printer {0} could not be verified after Special Pricing was applied", printer.Model));
                }

                if (printer.InstallationPack.ToLower().Equals("yes"))
                {
                    var displayedInstallationPrice = SeleniumHelper.FindElementByCssSelector(printerContainer, InstallationPackPriceSelector).Text.Substring(1);
                    TestCheck.AssertIsEqual(double.Parse(printer.InstallationPackPrice), double.Parse(displayedInstallationPrice), string.Format(
                        "Installation Pack Price for printer {0} could not be verified after Special Pricing was applied", printer.Model));
                }

                if (printer.ServicePack.ToLower().Equals("yes") && servicePackType.Equals(_expectedTranslationService.GetServicePackTypeText(TranslationKeys.ServicePackType.PayUpfront, culture)))
                {
                    var displayedServicePrice = SeleniumHelper.FindElementByCssSelector(printerContainer, ServicePackPriceSelector).Text.Substring(1);
                    TestCheck.AssertIsEqual(printer.ServicePackPrice, displayedServicePrice, string.Format(
                        "Service Pack Price for printer {0} could not be verified after Special Pricing was applied", printer.Model));
                }
            }
        }
    }
}