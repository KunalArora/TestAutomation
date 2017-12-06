using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
{
    public class DealerAgreementCreateClickPricePage : BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-clickprice-group";
        private const string _url = "/mps/dealer/agreements/manage/click-price";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Selectors
        private const string IsMonoOnly = "data-mono-only";
        private const string DataAttributeMonoCoverage = "mono-coverage";
        private const string DataAttributeMonoVolume = "mono-volume";
        private const string DataAttributeColourCoverage = "colour-coverage";
        private const string DataAttributeColourVolume = "colour-volume";

        //WebElement properties
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;


        public IWebElement SelectClickPriceGroup(string printerName, int findElementTimeout)
        {
            var clickPriceContainer = SeleniumHelper.FindElementByDataAttributeValue("model", printerName, 10);

            return clickPriceContainer;
        }

        public void PopulatePrinterCoverageAndVolume(string printerName,
            int coverageMono,
            int volumeMono,
            int coverageColour,
            int volumeColour,
            int findElementTimeout)
        {
            var printerContainer = SelectClickPriceGroup(printerName, findElementTimeout);
            string isMonoOnly = printerContainer.GetAttribute(IsMonoOnly);

            var monoCoverageInput = SeleniumHelper.FindElementByDataAttributeValue(printerContainer, DataAttributeMonoCoverage, "true", findElementTimeout);
            var monoVolumeDropdownInput = SeleniumHelper.FindElementByDataAttributeValue(printerContainer, DataAttributeMonoVolume, "true", findElementTimeout);

            ClearAndType(monoCoverageInput, coverageMono.ToString());

            // Try & catch used to handle the case of UsageType 'Pay As you Go' & Service 'Pay upfront' in 
            // which data input field is used instead of dropdown for volume
            try { SeleniumHelper.SelectFromDropdownByText(monoVolumeDropdownInput, volumeMono.ToString()); }
            catch { ClearAndType(monoVolumeDropdownInput, volumeMono.ToString()); }
            
            if ((isMonoOnly.ToLower()).Equals("false"))
            {
                var colourCoverageInput = SeleniumHelper.FindElementByDataAttributeValue(printerContainer, DataAttributeColourCoverage, "true", findElementTimeout);
                var colourVolumeDropdownInput = SeleniumHelper.FindElementByDataAttributeValue(printerContainer, DataAttributeColourVolume, "true", findElementTimeout);

                ClearAndType(colourCoverageInput, coverageColour.ToString());

                // Try & catch used to handle the case of UsageType 'Pay As you Go' & Service 'Pay upfront' in 
                // which data input field is used instead of dropdown for volume
                try { SeleniumHelper.SelectFromDropdownByText(colourVolumeDropdownInput, volumeColour.ToString()); }
                catch { ClearAndType(colourVolumeDropdownInput, volumeColour.ToString()); }
            }

        }
    }
}

