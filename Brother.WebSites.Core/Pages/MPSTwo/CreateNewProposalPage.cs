using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CreateNewProposalPage : BasePage
    {
        public static string URL = "/mps/proposals/create/description?new=true";
        private const string optionTab = @"a[href='#tab-options']";
        private const string colourElement = @"#ClickPriceColourCoverage";
        private const string flatItemsIdentifier = @".mps-product-group";
        private const string contractSelector = @"#content_1_InputContractType_Input";
        private const string clickPriceValue = @"[class='mps-col mps-top mps-clickprice-line2'][data-click-price-mono='true']";
        private const string clickPriceColourValue = @"[data-mono-only='False'] [class='mps-col mps-top mps-clickprice-line2'][data-click-price-colour='true']";
        private const string clickPricePageNext = @"#content_1_ButtonNext";
        private const string installationCostPrice = @"#InstallationCostPrice";
        private const string installationMargin = @"#InstallationMargin";
        private const string optionSaveButton = @".js-mps-product-option-save";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        private IWebElement PromptText;
        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        private IWebElement CustomerInfomationElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalName_Input")]
        private IWebElement ProposalNameField;
        [FindsBy(How = How.Id, Using = "content_1_InputLeadCodeReference_Input")]
        private IWebElement LeadCodeRef;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        private IWebElement NextButton;
        [FindsBy(How = How.Id, Using = "content_1_InputCustomerChoiceNew")]
        private IWebElement CreateNewCustomerElement;
        [FindsBy(How = How.Id, Using = "content_1_InputCustomerChoiceExisting")]
        private IWebElement SelectExistingCustomerElement;
        [FindsBy(How = How.Id, Using = "content_1_InputCustomerChoiceSkip")]
        private IWebElement SkipCustomerElement;
        [FindsBy(How = How.Id, Using = "content_1_NewOrganisation")]
        private IWebElement NewOrganisationElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputIsPrivatelyLiable_Input")]
        private IWebElement PrivateLiableElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputCompanyName")]
        private IWebElement CompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPropertyNumber_Input")]
        private IWebElement PropertyNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPropertyStreet_Input")]
        private IWebElement PropertyStreetElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPropertyArea_Input")]
        private IWebElement PropertyAreaElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPropertyTown_Input")]
        private IWebElement PropertyTownElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPropertyPostCode_Input")]
        private IWebElement PropertyPostcodeElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputRegion_Input")]
        private IWebElement RegionElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputTitle_Input")]
        private IWebElement ContactTitleElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputFirstName_Input")]
        private IWebElement FirstNameElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputLastName_Input")]
        private IWebElement LastNameElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPosition_Input")]
        private IWebElement PositionElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputTelephone_Input")]
        private IWebElement TelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputEmail_Input")]
        private IWebElement EmailElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputCanOrderConsumables_Input")]
        private IWebElement OrderConsumableElement;
        [FindsBy(How = How.Id, Using = "content_1_InputContractLength_Input")]
        private IWebElement ContractLengthElement;
        [FindsBy(How = How.Id, Using = "content_1_InputLeasingRateBillingCycle_Input")]
        private IWebElement LeaseBillingCycleElement;
        [FindsBy(How = How.Id, Using = "content_1_InputClickRateBillingCycle_Input")]
        private IWebElement PayPerClickBillingElement;
        [FindsBy(How = How.Id, Using = "content_1_InputUsageType_Input")]
        private IWebElement UsageTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        private IWebElement TermAndTypeScreenTextElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-alert")]
        private IWebElement ProductsScreenAlertElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-option-save")]
        private IWebElement OptionsSaveButtonElement;
        [FindsBy(How = How.Id, Using = "Quantity")]
        private IWebElement ProductQuantityElement;
        [FindsBy(How = How.Id, Using = "CostPrice")]
        private IWebElement ProductCostPriceElement;
        [FindsBy(How = How.Id, Using = "SellPrice")]
        private IWebElement ProductSellPriceElement;
        [FindsBy(How = How.Id, Using = "Margin")]
        private IWebElement ProductMarginElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#tab-installation\"]")]
        private IWebElement InstallationScreenElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/create/summary\"]")]
        private IWebElement ProposalSummaryScreenElement;
        [FindsBy(How = How.Id, Using = "InstallationCostPrice")]
        private IWebElement InstallationCostPriceElement;
        [FindsBy(How = How.Id, Using = "InstallationSellPrice")]
        private IWebElement InstallationSellPriceElement;
        [FindsBy(How = How.Id, Using = "InstallationMargin")]
        private IWebElement InstallationMarginElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#tab-options\"]")]
        private IWebElement OptionsScreenElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/create/click-price\"]")]
        private IWebElement ClickPriceScreenElement;
        [FindsBy(How = How.Id, Using = "Options")]
        private IWebElement OptionsDropDownElement;
        [FindsBy(How = How.Id, Using = "OptionQuantity")]
        private IWebElement OptionsQuantityElement;
        [FindsBy(How = How.Id, Using = "OptionCostPrice")]
        private IWebElement OptionsCostPriceElement;
        [FindsBy(How = How.Id, Using = "OptionSellPrice")]
        private IWebElement OptionsSellPriceElement;
        [FindsBy(How = How.Id, Using = "OptionMargin")]
        private IWebElement OptionsMarginElement;
        [FindsBy(How = How.Id, Using = "ClickPriceMonoCoverage")]
        private IWebElement ClickPriceCoverageElement;
        [FindsBy(How = How.Id, Using = "ClickPriceMonoVolume")]
        private IWebElement ClickPriceVolumeElement;
        [FindsBy(How = How.Id, Using = "ClickPriceMonoMargin")]
        private IWebElement ClickPriceMarginElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-configuration-submit")]
        private IWebElement AddToProposalElement;
        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        private IWebElement SummaryConfirmationTextElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveProposal")]
        private IWebElement SaveProposalElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveAsTemplate")]
        private IWebElement SaveAsTemplateElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonDownloadProposalPdf")]
        public IWebElement DownloadProposalPdfElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonDownloadProposalPdfWithCalcs")]
        private IWebElement DownloadProposalPdfWithCalcElement;
        [FindsBy(How = How.CssSelector, Using = "#ClickPriceColourCoverage")]
        private IWebElement ColourCoverageElement;
        [FindsBy(How = How.Id, Using = "ClickPriceColourVolume")]
        private IWebElement ColourVolumeElement;
        [FindsBy(How = How.Id, Using = "ClickPriceColourMargin")]
        private IWebElement ColourMarginElement;
        [FindsBy(How = How.CssSelector, Using = "input[id*=\"content_1_CustomerList_List_InputChoice\"]")]
        private IList<IWebElement> ExistingContactRadioButtonElement;
        [FindsBy(How = How.CssSelector, Using = "[class='alert-link js-mps-product-link']")]
        private IList<IWebElement> SelectedPrintersElement;
        [FindsBy(How = How.CssSelector, Using = "[class*=\"panel panel-default mps-summary-panel mps-qa-printer mps-qa-printer-\"]")]
        private IList<IWebElement> SelectedPrintersOnSummaryPageElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/proposals/create/customer-information\"]")]
        private IWebElement customerInformationTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/create/description\"]")]
        private IWebElement proposalDescriptionTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/proposals/create/term-type\"]")]
        private IWebElement termsAndTypeTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/proposals/create/products\"]")]
        private IWebElement productsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/proposals/create/summary\"]")]
        private IWebElement proposalSummaryTabElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonBack")]
        private IWebElement proposalProcessBackButtonElement;
        [FindsBy(How = How.CssSelector, Using = "a[class*=\"js-mps-product-link\"]")]
        private IWebElement selectedPrinterElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputContractLength_Input [selected]")]
        private IWebElement retainedContractLengthElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputLeasingRateBillingCycle_Input [selected]")]
        private IWebElement retainedLeaseBillingCycleElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputClickRateBillingCycle_Input [selected]")]
        private IWebElement retainedClickRateElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_1_CustomerList_InputCustomerChoice\"][checked]")]
        private IWebElement checkedCustomerInformationElement;
        [FindsBy(How = How.CssSelector, Using = "[id*='content_1_CustomerList_List_InputChoice'][checked]")]
        private IWebElement checkedCustomerInformationConversionMode;
        [FindsBy(How = How.CssSelector, Using = "[class='mps-product-col mps-product-model']")]
        private IWebElement flatListVerificationElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-display-option[data-display-option='flat']")]
        private IWebElement flatListClickButtonElement;
        [FindsBy(How = How.CssSelector, Using = "[name='CostPriceFullPrecision']")]
        private IWebElement modelCostPriceValueElement;
        [FindsBy(How = How.CssSelector, Using = "[name='SellPriceFullPrecision']")]
        private IWebElement modelSellPriceValueElement;
        [FindsBy(How = How.CssSelector, Using = "[name='MarginFullPrecision']")]
        private IWebElement modelMarginValueElement;
        [FindsBy(How = How.CssSelector, Using = "[name='InstallationCostPriceFullPrecision']")]
        private IWebElement installationCostPriceValueElement;
        [FindsBy(How = How.CssSelector, Using = "[name='InstallationSellPriceFullPrecision']")]
        private IWebElement installationSellPriceValueElement;
        [FindsBy(How = How.CssSelector, Using = "[name='InstallationMarginFullPrecision']")]
        private IWebElement installationMarginValueElement;
        [FindsBy(How = How.CssSelector, Using = "[name='OptionCostPriceFullPrecision']")]
        private IWebElement optionCostPriceValueElement;
        [FindsBy(How = How.CssSelector, Using = "[name='OptionSellPriceFullPrecision']")]
        private IWebElement optionSellPriceValueElement;
        [FindsBy(How = How.CssSelector, Using = "span[data-click-price-mono='true']")]
        private IWebElement clickPriceMonoCostElement;
        [FindsBy(How = How.CssSelector, Using = "#SellClickPriceMono[data-sale-click-price-mono='true']")]
        private IWebElement clickPriceMonoSellElement;
        [FindsBy(How = How.CssSelector, Using = "span[data-click-price-colour='true']")]
        private IWebElement clickPriceColourCostElement;
        [FindsBy(How = How.CssSelector, Using = "#SellClickPriceColour[data-sale-click-price-colour='true']")]
        private IWebElement clickPriceColourSellElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-open-edit")]
        private IList<IWebElement> productImageEditElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-product-open-add.hidden")]
        private IList<IWebElement> productAddElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/customer-information\"]")]
        private IWebElement customerInformationTabConversionMode;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/description\"]")]
        private IWebElement proposalDescriptionTabConversionMode;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/click-price\"]")]
        private IWebElement clickPriceTabConversionMode;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/term-type\"]")]
        private IWebElement termsAndTypeTabConversionMode;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/products\"]")]
        private IWebElement productsTabConversionMode;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/summary\"]")]
        private IWebElement proposalSummaryTabConversionMode;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputContractType_Input")]
        private IWebElement ContractTypeSelector;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputUsageType_Input")]
        private IWebElement UsageTypeSelector;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"#tab-service-pack\"]")]
        private IWebElement PrinterServicePack;
        [FindsBy(How = How.Id, Using = "ServicePackMargin")]
        private IWebElement MonoVolumeDropDownElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputMonoVolumeBreaks_0")]
        private IWebElement ColourVolumeDropdownElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputColourVolumeBreaks_0")]
        private IWebElement ClickVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonCalculate")]
        private IWebElement CalculateClickPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        private IWebElement ProceedOnClickPricePageElement;
        [FindsBy(How = How.CssSelector, Using = "[id*='content_1_LineItems_InputMonoVolumeBreaks_']")]
        private IList<IWebElement> MultipleColourVolumeDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "[id*='content_1_LineItems_InputColourVolumeBreaks_']")]
        private IList<IWebElement> MultipleClickVolumeElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputMonoCoverage_0']")]
        private IWebElement ClickCoverageElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputMonoMargin_0']")]
        private IWebElement ClickMarginElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputColourCoverage_0']")]
        private IWebElement ClickColourCoverageElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputColourMargin_0']")]
        private IWebElement ClickColourMarginElement;
        [FindsBy(How = How.CssSelector, Using = "[id='content_1_LineItems_InputMonoVolume_0']")]
        private IWebElement MonoVolumeInputFieldElement;
        

        
        

        
        public void IsPromptTextDisplayed()
        {
            if (PromptText == null) throw new 
                NullReferenceException("Unable to locate text on New Proposal Process Screen");
           
            AssertElementPresent(PromptText, "Leading Instruction");
        }

        public void IsProductScreenTextDisplayed()
        {

            if (ProductsScreenAlertElement == null) throw new 
                NullReferenceException("Unable to locate text on Product Screen");
      
            AssertElementPresent(ProductsScreenAlertElement, "Product Screen Instruction");
        }

        public void IsProductScreenDisplayed()
        {
            
            if (ProductsScreenAlertElement == null) throw new 
                NullReferenceException("Unable to locate Product message element on Product Screen");
       
           TestCheck.AssertIsEqual(true, ProductsScreenAlertElement.Displayed, "Is product screen displayed?");
        }

        public void IsOptionScreenTextDisplayed()
        {
            if (ProductsScreenAlertElement == null) throw new 
                NullReferenceException("Unable to locate text on the page");
         
            AssertElementPresent(ProductsScreenAlertElement, "Product Screen Instruction");
        }

        public void IsTermAndTypeTextDisplayed()
        {
            if (TermAndTypeScreenTextElement == null) throw new 
                NullReferenceException("Unable to locate text on Term and Type Screen");
        
            AssertElementPresent(TermAndTypeScreenTextElement, "Terms and Type Instruction");
        }

        public void IsCustomerInfoTextDisplayed()
        {
            if (CustomerInfomationElement == null) throw new 
                NullReferenceException("Unable to locate text on Customer Information Screen");

            AssertElementPresent(CustomerInfomationElement, "Customer information leading instruction");
        }

        public void IsProposalSummaryTextDisplayed()
        {
            if (CustomerInfomationElement == null)
            {
                throw new NullReferenceException("Unable to locate text on the page");
            }
            AssertElementText(CustomerInfomationElement, "Please confirm your proposal information",
                                            "Proposal Summary confirmation instruction");
        }

        public void IsPrivateLiableCheckBoxDiplayed()
        {
            if (PrivateLiableElement == null)
            {
                throw new NullReferenceException("Unable to locate tick box on the page");
            }
            AssertElementPresent(PrivateLiableElement, "Is Private Liable Check Box");
        }

        public CreateNewProposalPage ClickNextButton()
        {
            ScrollTo(NextButton);
            NextButton.Click();
            return GetTabInstance<CreateNewProposalPage>(Driver);
        }

        public void EnterProposalName(string proposalName)
        {
            if (proposalName.Equals(string.Empty))
            {
                proposalName = MpsUtil.GenerateUniqueProposalName();
                try
                {
                    SpecFlow.SetContext("GeneratedProposalName", proposalName);
                }
                catch
                {
                    throw new NullReferenceException("Session cannot store proposalName");
                }
                
            }

            ProposalNameField.SendKeys(proposalName);
        }

        public void EnterLeadCodeRef(string leadCodeRef)
        {
            if (leadCodeRef.Equals(string.Empty))
            {
                leadCodeRef = MpsUtil.GenerateUniqueLeadCodeRef();
                try
                {
                    SpecFlow.SetContext("GeneratedLeadCodeReference", leadCodeRef);
                }
                catch
                {
                    throw new NullReferenceException("Session cannot store leadCodeRef");
                }
            }

            LeadCodeRef.SendKeys(leadCodeRef);
        }

        public void VerifyEarlierSelectedPrinter()
        {
            var earlierSelectedPrinter = SpecFlow.GetContext("GeneratedPrinterName");
            var retainedprinter = selectedPrinterElement.Text;
            var message = "The printer selected initially, {0}, is not equal to the printer retained, {1}";
            message = string.Format(message, earlierSelectedPrinter, retainedprinter);


            TestCheck.AssertIsEqual(earlierSelectedPrinter, retainedprinter, message);
        }

        private void VerifyProposalDescriptionFieldsAreDisabled()
        {
            TestCheck.AssertIsEqual(false, ProposalNameField.Enabled, "Is proposal name field disabled?");
            TestCheck.AssertIsEqual(false, LeadCodeRef.Enabled, "Is lead code ref disabled?");
        }

        public void VerifyProposalDescriptionValuesAreRetained()
        {
            var retainedProposalName = SpecFlow.GetContext("GeneratedProposalName");
            var retainedLeadCodeRef = SpecFlow.GetContext("GeneratedLeadCodeReference");

            var presentProposalName = ProposalNameField.GetAttribute("value");
            var presentLeadCodeRef = LeadCodeRef.GetAttribute("value");

            TestCheck.AssertIsEqual(presentProposalName, retainedProposalName, "Verify retained proposal name");
            TestCheck.AssertIsEqual(presentLeadCodeRef, retainedLeadCodeRef, "Verify retained lead code ref");
        }


        public void ClickOnProposalTabsTransform(string tab)
        {
            //Use this method if you are going through the proposal creation landscape
            switch (tab)
            {
                case "Customer Information":
                    customerInformationTabElement.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Term & Type":
                    termsAndTypeTabElement.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Products":
                    productsTabElement.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Summary":
                    proposalSummaryTabElement.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Proposal Description":
                    proposalDescriptionTabElement.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
            }

        }


        public void ClickOnProposalTabsDuringContractConversionTransform(string tab)
        {
            //Use this method if you are going through the proposal creation landscape
            switch (tab)
            {
                case "Customer Information":
                    customerInformationTabConversionMode.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Term & Type":
                    termsAndTypeTabConversionMode.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Products":
                    productsTabConversionMode.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Summary":
                    proposalSummaryTabConversionMode.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Proposal Description":
                    proposalDescriptionTabConversionMode.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
                case "Click Price":
                    clickPriceTabConversionMode.Click();
                    WebDriver.Wait(Helper.DurationType.Second, 3);
                    break;
            }

        }

        private void VerifyCustomerInformationRemainedChecked()
        {
           TestCheck.AssertIsEqual(true, checkedCustomerInformationElement.Displayed, "Is customer information element displayed?");
        }

        public void VerifyProposalScreensRetainValuesAfterbackNavigation(string tab)
        {
            switch (tab)
            {
                case "Proposal Description":
                    IsPromptTextDisplayed();
                    VerifyProposalDescriptionValuesAreRetained();
                    break;
                case "Customer Information":
                    VerifyCustomerInformationRemainedChecked();
                    ClickBackButtonDuringProposalProcess();
                    IsCustomerInfoTextDisplayed();
                    ClickBackButtonDuringProposalProcess();
                    break;
                case "Term & Type":
                    IsTermAndTypeTextDisplayed();
                    VerifyTermAndTypeValuesAreRetained();
                    ClickBackButtonDuringProposalProcess();
                    break;
            }

        }

        public void VerifyFieldsOnScreensAreDisabled(string tab)
        {
            switch (tab)
            {
                case "Proposal Description" :
                    VerifyProposalDescriptionFieldsAreDisabled();
                    break;
                case "Customer Information" :
                    VerifyCustomerInformationRadioButtonsAreDisabled();
                    break;
                case "Term & Type" :
                    VerifyTermAndTypeFieldsAreDisabled();
                    break;
                case "Click Price":
                    VerifyClickPriceMonoFieldsAreDisabled();
                    VerifyClickPriceColourFieldsAreDisabled();
                    break;
            }
        }

        private void VerifyCustomerInformationRadioButtonsAreDisabled()
        {
            TestCheck.AssertIsEqual(false, checkedCustomerInformationConversionMode.Enabled, "Customer Information Radio Buttons disabled?");
        }

        private void VerifyTermAndTypeFieldsAreDisabled()
        {
            TestCheck.AssertIsEqual(false, retainedContractLengthElement.Enabled, "Retained Contract Length Element disabled?");
            TestCheck.AssertIsEqual(false, retainedLeaseBillingCycleElement.Enabled, "Retained lease billing cycle element displayed?");
            TestCheck.AssertIsEqual(false, retainedClickRateElement.Enabled, "Retained click rate element displayed?"); 
        }

        private void VerifyClickPriceMonoFieldsAreDisabled()
        {
            TestCheck.AssertIsEqual(false, ColourVolumeDropdownElement.Enabled, "Colour Volume DropDown Element disabled?");
            TestCheck.AssertIsEqual(false, ClickCoverageElement.Enabled, "Click coverage Element disabled?");
            TestCheck.AssertIsEqual(false, ClickMarginElement.Enabled, "Click margin Element disabled?");
        }

        private void VerifyClickPriceColourFieldsAreDisabled()
        {
            TestCheck.AssertIsEqual(false, ClickVolumeElement.Enabled, "Click Volume Element disabled?");
            TestCheck.AssertIsEqual(false, ClickColourCoverageElement.Enabled, "Click colour coverage Element disabled?");
            TestCheck.AssertIsEqual(false, ClickColourMarginElement.Enabled, "Click colour margin Element disabled?");
        }

        private void VerifyTermAndTypeValuesAreRetained()
        {
            var retainedContractLength = retainedContractLengthElement.Text;
            var retainedLeaseBill = retainedLeaseBillingCycleElement.Text;
            var retainedClickBill = retainedClickRateElement.Text;

            var selectedContractLength = SpecFlow.GetContext("GeneratedContractLength");
            var selectedLeaseBill = SpecFlow.GetContext("GeneratedLeaseBillingCycle");
            var selectedClickBill = SpecFlow.GetContext("GeneratedPayLeaseBillingCycle");

            TestCheck.AssertIsEqual(retainedContractLength, selectedContractLength, "Retained Contract Length");
            TestCheck.AssertIsEqual(retainedLeaseBill, selectedLeaseBill, "Retianed Lease Bill");
            TestCheck.AssertIsEqual(retainedClickBill, selectedClickBill, "Retained Click Bill");
        }

        public void VerifyProposalScreenAfterNavigation(string tab)
        {
            switch (tab)
            {
                case "New Proposal":
                    IsPromptTextDisplayed();
                    break;
                case "Customer Information":
                    IsCustomerInfoTextDisplayed();
                    break;
                case "Term & Type":
                    IsTermAndTypeTextDisplayed();
                    break;
                case "Products":
                    IsProductScreenTextDisplayed();
                    break;
                case "Summary":
                    IsProposalSummaryTextDisplayed();
                    break;
            }

        }

        public void ClickBackButtonDuringProposalProcess()
        {
            ScrollTo(proposalProcessBackButtonElement);
            proposalProcessBackButtonElement.Click();
        }

        public void ClickCreateNewCustomerRadioButton()
        {
            ScrollTo(CreateNewCustomerElement);
            CreateNewCustomerElement.Click();
        }

        public void ClickSelectExistingCustomerRadioButton()
        {
            ScrollTo(SelectExistingCustomerElement);
            SelectExistingCustomerElement.Click();
        }

        public void ClickSkipCustomerRadioButton()
        {
            ScrollTo(SkipCustomerElement);
            SkipCustomerElement.Click();
        }

        public void ClickNewOrganisationButton()
        {
            ScrollTo(NewOrganisationElement);
            NewOrganisationElement.Click();
        }

        public void FillOrganisationDetails()
        {
            EnterCompanyName();
            EnterPropertyNumber();
            EnterPropertyStreet();
            EnterPropertyArea();
            EnterPropertyTown();
            EnterPropertyPostCode();
            SelectRegionFromDropdown("Niedersachsen");
        }


        public void FillOrganisationContactDetail()
        {
            SelectTitleFromDropdown();
            EnterContactFirstName();
            EnterContactSurName();
            EnterContactPosition();
            EnterContactTelephone();
            EnterContactEmailAdress();
        }

        public void FillProductDetails()
        {
            EnterProductQuantity("2");
            EnterProductCostPrice("50");
            EnterProductSellPrice("60");
            VerifyMarginFieldValues();
        }

        private IWebElement ColourClickPriceElement()
        {
            return GetElementByCssSelector(colourElement, 10);
        }

        public void FillClickPriceDetails()
        {
            EnterVolumeValue("1000");

            if (ColourClickPriceElement() == null) return;
            EnterColourVolume("1000");
        }

        public void EnterCompanyName()
        {
            CompanyNameElement.SendKeys(MpsUtil.CompanyName());
        }

        public void EnterPropertyNumber()
        {
            PropertyNumberElement.SendKeys(MpsUtil.PropertyNumber());
        }

        public void EnterPropertyStreet()
        {
            PropertyStreetElement.SendKeys(MpsUtil.PropertyStreet());
        }

        public void EnterPropertyArea()
        {
            PropertyAreaElement.SendKeys(MpsUtil.FirstName());
        }

        public void EnterPropertyTown()
        {
            PropertyTownElement.SendKeys(MpsUtil.PropertyTown());
        }

        public void EnterPropertyPostCode()
        {
            PropertyPostcodeElement.SendKeys(MpsUtil.PostCode());
        }

        public void SelectRegionFromDropdown(string region)
        {
            SelectFromDropdown(RegionElement, region);
        }

        public void SelectTitleFromDropdown()
        {
            if (ContactTitleElement.Displayed) 
                //SelectFromDropdownByValue(ContactTitleElement, MpsUtil.ContactTitle());
                SelectFromDropdownByValue(ContactTitleElement, "2");
        }

        private IWebElement ContractTypeSelectorDropdown()
        {
            return GetElementByCssSelector(contractSelector);
        }


        public void SelectingContractType(string contract)
        {
            if (IsElementPresent(ContractTypeSelectorDropdown()))
                    SelectContractType(contract);
         
        }

        public void SelectContractType(string contract)
        {
            var selectable = "";

            switch (contract)
            {
                case "AIC" :
                    selectable = "1";
                    break;
                case "Purchase-and-Click":
                    selectable = "3";
                    break;
                case "Leasing" :
                    selectable = "2";
                    break;
                default:
                    throw new InvalidEnumArgumentException(String.Format("{0} is not a valid contract type", contract));
            }

            if(ContractTypeSelector.Displayed)
                SelectFromDropdownByValue(ContractTypeSelector, selectable);
        }

        public void SelectingContractUsageType(string contract)
        {
            if (IsElementPresent(ContractTypeSelectorDropdown()))
                SelectContractUsageType(contract);
         
        }

        public void SelectContractUsageType(string contract)
        {
            var selectable = "";

            switch (contract)
            {
                case "Minimum Volume" :
                    selectable = "1";
                    break;
                case "Pay As You Go" :
                    selectable = "2";
                    break;
                default:
                    throw new InvalidEnumArgumentException(String.Format("{0} is not a valid contract type", contract));
            }

            if (UsageTypeSelector.Displayed)
                SelectFromDropdownByValue(UsageTypeSelector, selectable);
        }
        

        public void EnterContactFirstName()
        {
            FirstNameElement.SendKeys(MpsUtil.FirstName());
        }

        public void EnterContactSurName()
        {
            LastNameElement.SendKeys(MpsUtil.SurName());
        }

        public void EnterContactPosition()
        {
            PositionElement.SendKeys(MpsUtil.ContactPosition());
        }

        public void EnterContactTelephone()
        {
            TelephoneElement.SendKeys(MpsUtil.CompanyTelephone());
        }

        public void EnterContactEmailAdress()
        {
            EmailElement.SendKeys(MpsUtil.GenerateUniqueEmail());
        }

        public void TickOrderConsumables()
        {
            OrderConsumableElement.Click();
        }

        public void SelectContractLength(string length)
        {
            SelectFromDropdown(ContractLengthElement, length);
        }

        public void SelectLeaseBillingCycle(string lease)
        {
            SelectFromDropdown(LeaseBillingCycleElement, lease);
        }

        public void SelectPayPerClickBillingCycle(string billing)
        {
            SelectFromDropdown(PayPerClickBillingElement, billing);
        }

        public void SelectUsageType(string usage)
        {
            SelectFromDropdown(UsageTypeElement, usage);
        }

        

        private IWebElement ProductFlatListAddElement()
        {
            return GetElementByCssSelector(flatItemsIdentifier, 10);
        }

        private void ClickOnAPrinter(string printer)
        {
           SpecFlow.SetContext("InitialProductPageText", ProductsScreenAlertElement.Text);

            var element = "";

            if (IsElementPresent(ProductFlatListAddElement()))
            {
                element = "#pc-{0} .js-mps-product-open";
            }
            else
            {
                element = "#pc-{0} .js-mps-product-open-add";
            }
            
            element = string.Format(element, printer.Equals(string.Empty) ? MpsUtil.PrinterUnderTest() : printer);

            var printerClickable = GetElementByCssSelector(element);

            printerClickable.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);

        }


        public void EnterProductQuantity(string value)
        {
            ClearAndType(ProductQuantityElement, value);
        }

        public void EnterProductCostPrice(string value)
        {
            ClearAndType(ProductCostPriceElement, value);
        }

        public void EnterProductSellPrice(string value)
        {
            ClearAndType(ProductSellPriceElement, value);
            ProductSellPriceElement.SendKeys(Keys.Tab);
        }

        public void VerifyMarginFieldValues()
        {
            WebDriver.Wait(Helper.DurationType.Second, 2);
            var marginText = ProductMarginElement.Text;
            TestCheck.AssertIsNotNull(ProductMarginElement.GetAttribute("value"), "Product Margin Element");
            TestCheck.AssertIsEqual(false, marginText.StartsWith("-"), "Margin Text starts with -");

        }

        private void MoveToServicePack()
        {
            ScrollTo(PrinterServicePack);
            PrinterServicePack.Click();
        }

        private void MoveToClickPriceScreen()
        {
            ScrollTo(ClickPriceScreenElement);
            ClickPriceScreenElement.Click();
        }

        private void CalculateClickPrice(string volume, string colour)
        {
            if (ClickVolumeElement == null)
                throw new NullReferenceException("ClickVolumeElement can not be found");
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");
            if (ColourVolumeDropdownElement == null)
                throw new NullReferenceException("ColourVolumeDropdownElement can not be found");

            SelectFromDropdown(ClickVolumeElement, volume);
            SelectFromDropdown(ColourVolumeDropdownElement, colour);
            CalculateClickPriceElement.Click();
        }

        private void CalculateEPPClickPrice(string volume)
        {
            if (ColourVolumeDropdownElement == null)
                throw new NullReferenceException("ClickVolumeElement can not be found");
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");

            SelectFromDropdown(ColourVolumeDropdownElement, volume);
            CalculateClickPriceElement.Click();
        }

        private void EnterMonoVolumeQuantity(string volume)
        {
            if (MonoVolumeInputFieldElement == null)
                throw new NullReferenceException("Mono Volume field can not be found");
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");

            MonoVolumeInputFieldElement.SendKeys(volume);
            CalculateClickPriceElement.Click();
        }

        private void SelectVolumeForMultiplePrinters(string volume, string colour)
        {
            if (ClickVolumeElement == null)
                throw new NullReferenceException("ClickVolumeElement can not be found");
            if (CalculateClickPriceElement == null)
                throw new NullReferenceException("CalculateClickPriceElement can not be found");
            if (ColourVolumeDropdownElement == null)
                throw new NullReferenceException("ColourVolumeDropdownElement can not be found");

            for (var i = 0; i < MultipleClickVolumeElement.Count; i++)
            {
                SelectFromDropdown(MultipleClickVolumeElement.ElementAt(i), volume);
            }

            for (var i = 0; i < MultipleColourVolumeDropdownElement.Count; i++)
            {
                SelectFromDropdown(MultipleColourVolumeDropdownElement.ElementAt(i), colour);
            }
            
            CalculateClickPriceElement.Click();
        }

        public void CalculateMultipleClickPriceAndProceed(string volume, string colour)
        {
            MoveToClickPriceScreen();
            SelectVolumeForMultiplePrinters(volume, colour);
            WebDriver.Wait(Helper.DurationType.Second, 2);
            VerifyClickPriceValueIsDisplayed();
            VerifyColourClickPriceValueIsDisplayed();
            ProceedToProposalSummaryFromClickPrice();

        }

        private IList<IWebElement> ClickPriceValue()
        {
            return GetElementsByCssSelector(clickPriceValue);
        }

        private IList<IWebElement> ClickPriceColourValue()
        {
            return GetElementsByCssSelector(clickPriceColourValue);
        }

        private void VerifyColourClickPriceValueIsDisplayed()
        {
            for (var i = 0; i < ClickPriceColourValue().Count; i++)
            {
                TestCheck.AssertIsEqual(false, ClickPriceColourValue().ElementAt(i).Text.Equals(string.Empty), "Price Colour Value is Empty"); 
            }
            
        }

        private void VerifyClickPriceValueIsDisplayed()
        {
            for (var i = 0; i < ClickPriceValue().Count; i++)
            {
                TestCheck.AssertIsEqual(false, ClickPriceValue().ElementAt(i).Text.Equals(string.Empty), "Price Value is Empty");
            }
        }

        private IWebElement ClickPriceNextButton()
        {
            return GetElementByCssSelector(clickPricePageNext);
        }

        private void ProceedToProposalSummaryFromClickPrice()
        {
            ClickPriceNextButton().Click();
        }

        public void CalculateClickPriceAndProceed(string volume, string colour)
        {
            MoveToClickPriceScreen();
            CalculateClickPrice(volume, colour);
            WebDriver.Wait(Helper.DurationType.Second, 2);
            VerifyClickPriceValueIsDisplayed();
            ProceedToProposalSummaryFromClickPrice();

        }

        public void CalculateEPPClickPriceAndProceed(string volume)
        {
            MoveToClickPriceScreen();
            CalculateEPPClickPrice(volume);
            WebDriver.Wait(Helper.DurationType.Second, 2);
            VerifyClickPriceValueIsDisplayed();
            ProceedToProposalSummaryFromClickPrice();

        }

        public void CalculateEnteredClickPriceAndProceed(string volume)
        {
            MoveToClickPriceScreen();
            EnterMonoVolumeQuantity(volume);
            WebDriver.Wait(Helper.DurationType.Second, 2);
            VerifyClickPriceValueIsDisplayed();
            ProceedToProposalSummaryFromClickPrice();

        }

        
        public void MoveToInstallationScreen()
        {
            ScrollTo(InstallationScreenElement);
            InstallationScreenElement.Click();
        }

        private IWebElement InstallationCostPriceField()
        {
            return GetElementByCssSelector(installationCostPrice, 2);
        }

        public void EnterInstallationCostPrice(string value)
        {
            if (IsElementPresent(InstallationCostPriceField()))
            {
                ClearAndType(InstallationCostPriceElement, value);
            }
        }
        
        public void EnterInstallationSellPrice(string value)
        {
            ClearAndType(InstallationSellPriceElement, value);
            InstallationSellPriceElement.SendKeys(Keys.Tab);
        }

        private IWebElement InstallationMarginField()
        {
            return GetElementByCssSelector(installationMargin, 2);
        }

        public void VerifyThatServicePackFieldIsNotEmpty()
        {
            TestCheck.AssertIsEqual(false, MonoVolumeDropDownElement.GetAttribute("value").Equals(string.Empty), "Service pack field is not empty");
        }

        public void VerifyInstallationMarginValue()
        {
            if (!IsElementPresent(InstallationMarginField())) return;
            WebDriver.Wait(Helper.DurationType.Second, 2);
            var marginText = InstallationMarginElement.Text;
            TestCheck.AssertIsNotNull(InstallationMarginElement.GetAttribute("value"), "Installation Margin Element");
            TestCheck.AssertIsEqual(false, marginText.StartsWith("-"), "Margin starts with -");
        }

        public void VerifyOptionMarginValue()
        {
            WebDriver.Wait(Helper.DurationType.Second, 2);
            var marginText = OptionsMarginElement.Text;
            TestCheck.AssertIsNotNull(OptionsMarginElement.GetAttribute("value"), "Options Margin Element");
            TestCheck.AssertIsEqual(false, marginText.StartsWith("-"), "Margin starts with -");
        }

        public void SelectADuplexOptions()
        {
            SelectFromDropdown(OptionsDropDownElement, "USB 2.0 Cable (USB 2.0 Kabel)");
        }

        private IWebElement OptionTabElement()
        {
            return GetElementByCssSelector(optionTab, 10);
        }

        private IWebElement optionSaveElement()
        {
            return GetElementByCssSelector(optionSaveButton, 10);
        }

        public void MoveToOptionScreenAndEnterDetails()
        {

            if (!IsElementPresent(OptionTabElement()))
            {
                MoveToServicePack();
            }
            else
            {
                ScrollTo(OptionTabElement());
                OptionTabElement().Click();

                IsOptionScreenTextDisplayed();
                SelectADuplexOptions();
                ClearAndType(OptionsQuantityElement, "1");
                ClearAndType(OptionsCostPriceElement, "100");
                ClearAndType(OptionsSellPriceElement, "110");
                VerifyOptionMarginValue();
                //optionSaveElement().Click();

                MoveToServicePack();
            }
            
                
            
        }

        public void EnterCoverageValue(string value)
        {
            ClearAndType(ClickPriceCoverageElement, value);
        }

        public void EnterVolumeValue(string value)
        {
            ClearAndType(ClickPriceVolumeElement, value);
            ClickPriceVolumeElement.SendKeys(Keys.Tab);
        }

        public void EnterClickPriceMargin(string value)
        {
            ClearAndType(ClickPriceMarginElement, value);
            ClickPriceMarginElement.SendKeys(Keys.Tab);
        }

        public void EnterColourCoverage(string value)
        {
            ClearAndType(ColourCoverageElement, value);
            ColourCoverageElement.SendKeys(Keys.Tab);
        }

        public void EnterColourVolume(string value)
        {
            ClearAndType(ColourVolumeElement, value);
            ColourVolumeElement.SendKeys(Keys.Tab);
        }

        public void EnterColourMargin(string value)
        {
            ClearAndType(ColourMarginElement, value);
            ColourMarginElement.SendKeys(Keys.Tab);
        }

        public void AddAllDetailsToProposal()
        {
            ScrollTo(AddToProposalElement);
            AddToProposalElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);
           
        }

        public void VerifyProductAdditionConfirmationMessage()
        {
            ScrollTo(ProductsScreenAlertElement);
            var storedProductScreenText = SpecFlow.GetContext("InitialProductPageText");
            var finalProductScreenText = ProductsScreenAlertElement.Text;
            TestCheck.AssertIsEqual(false, storedProductScreenText.Equals(finalProductScreenText), "Product Screen Text");
        }

        public void MoveToProposalSummaryScreen()
        {
            ScrollTo(ProposalSummaryScreenElement);
            ProposalSummaryScreenElement.Click();
            AssertElementPresent(SummaryConfirmationTextElement, "Product Confirmation Message");
        }

        public CloudExistingProposalPage SaveProposalAsTemplate()
        {
            WebDriver.Wait(Helper.DurationType.Second, 3);
            ScrollTo(SaveAsTemplateElement);
            SaveAsTemplateElement.Click();
            return GetTabInstance<CloudExistingProposalPage>(Driver);
        }

        public CloudExistingProposalPage SaveProposal()
        {
            WebDriver.Wait(Helper.DurationType.Second, 3);
            ScrollTo(SaveProposalElement);
            SaveProposalElement.Click();
            return GetTabInstance<CloudExistingProposalPage>(Driver);
        }

        public void VerifyTheNumberOfPrintersOnSummaryPage(int printerNo)
        {
            TestCheck.AssertIsEqual(printerNo, SelectedPrintersOnSummaryPageElement.Count, "Verify number of printers on summary page");
        }

        public void VerifyHowManyPrinterWasAddedOnProductScreen(int printerSize)
        {
            TestCheck.AssertIsEqual(printerSize, SelectedPrintersElement.Count(), "Verify how many printers on Product Screen");
        }

        public void ChooseADeviceFromProductSelectionScreen(string printer, string costprice, string sellprice)
        {
            ClickOnAPrinter(printer);

            FillProductDetails();
            MoveToInstallationScreen();

            EnterInstallationCostPrice(costprice);
            EnterInstallationSellPrice(sellprice);
            VerifyInstallationMarginValue();
            MoveToOptionScreenAndEnterDetails();
            VerifyThatServicePackFieldIsNotEmpty();

            AddAllDetailsToProposal();
        }

        public void ChooseADeviceFromProductFlatListScreen(string printer, string costprice, string sellprice)
        {
            FillProductDetails();
            MoveToInstallationScreen();

            EnterInstallationCostPrice(costprice);
            EnterInstallationSellPrice(sellprice);
            VerifyInstallationMarginValue();
            MoveToOptionScreenAndEnterDetails();
            VerifyThatServicePackFieldIsNotEmpty();

            
            AddAllDetailsToProposal();
        }

        public void SelectARandomExistingContact()
        {
            var noOfContacts = ExistingContactRadioButtonElement.Count;

            var ranClick = new Random().Next(0, noOfContacts - 1);


            ExistingContactRadioButtonElement[ranClick].Click();

        }

        public void ChangeProductViewToFlatList()
        {
            if(flatListClickButtonElement == null) 
                throw new NullReferenceException("Button to change product view is not displayed");

            flatListClickButtonElement.Click();
            
        }

        public void VerifyThatFlatListIsDisplayed()
        {
            if (flatListVerificationElement == null)
                throw new NullReferenceException("Product view was not changed to flat list");

            AssertElementPresent(flatListVerificationElement, "Product view as flat list");

        }

        public void SelectAPrinterFromTheList(string printer)
        {
            ClickOnAPrinter(printer);
        }

        public void ProductFieldsArePopulatedWhereNecessary(string screen)
        {
            switch (screen)
            {
                case "Model":
                {
                    VerifyProductModelFieldsArePrepopulated();
                    break;
                }
                case "Installation":
                {
                    MoveToInstallationScreen();
                    VerifyProductInstallationFieldsArePopulatedOrNot();
                    break;
                }
                case "Options":
                {
                    VerifyProductOptionFieldsArePopulatedOrNot();
                    break;
                }
                case "Click Price":
                {
                    VerifyClickPriceFieldsArePopulatedOrNot();
                    break;
                }
            }
        }

        private void VerifyProductModelFieldsArePrepopulated()
        {
            if(modelCostPriceValueElement == null)
                throw new NullReferenceException("Model Cost Price Field might not be displayed");
            if (modelSellPriceValueElement == null)
                throw new NullReferenceException("Model Sell Price Field might not be displayed");
            if (modelMarginValueElement == null)
                throw new NullReferenceException("Model Margin Field might not be displayed");
            if (ProductQuantityElement == null)
                throw new NullReferenceException("Model Quantity Field might not be displayed");

            TestCheck.AssertIsNotNullOrEmpty(ProductQuantityElement.GetAttribute("value"), "Product Quantity");
            TestCheck.AssertIsNotNullOrEmpty(modelCostPriceValueElement.GetAttribute("value"), "Cost Price Value");
            TestCheck.AssertIsNotNullOrEmpty(modelMarginValueElement.GetAttribute("value"), "Margin Value");
            TestCheck.AssertIsNotNullOrEmpty(modelSellPriceValueElement.GetAttribute("value"), "Sell Price Value"); 
            
        }

        private void VerifyProductInstallationFieldsArePopulatedOrNot()
        {
            if(installationCostPriceValueElement == null)
                throw new NullReferenceException("Installation Cost Price Field might not be displayed");
            if (installationSellPriceValueElement == null)
                throw new NullReferenceException("Installation Sell Price Field might not be displayed");
            if (installationMarginValueElement == null)
                throw new NullReferenceException("Installation Margin Field might not be displayed");

            TestCheck.AssertIsNullOrEmpty(installationCostPriceValueElement.GetAttribute("value"), "Installation Cost Price Value");
            TestCheck.AssertIsNullOrEmpty(installationSellPriceValueElement.GetAttribute("value"), "Installation Sell Price Value");
            TestCheck.AssertIsNotNullOrEmpty(installationMarginValueElement.GetAttribute("value"), "Installation Margin Price Value");
        }

        public void VerifyThatTheNumbersOfPrintersEqualTheNumbersOfDetailButtonDisplayed()
        {
            var printerNumber = SelectedPrintersElement.Count;
            var detailButtonNumber = productImageEditElement.Count;

            TestCheck.AssertIsEqual(printerNumber, detailButtonNumber, "Number of printers equals number of detail button displayed");
        }

        public void NoAddButtonIsDisplayed()
        {
            TestCheck.AssertIsEqual(true, productAddElement.Count > 0, "Add Button is Displayed");
        }


        private void VerifyProductOptionFieldsArePopulatedOrNot()
        {
            if (!IsElementPresent(OptionTabElement()))
                {
                    MoveToClickPriceScreen();
                }
                else
                {
                    ScrollTo(OptionTabElement());
                    OptionTabElement().Click();

                    IsOptionScreenTextDisplayed();
                    SelectADuplexOptions();
                    TestCheck.AssertIsNotNullOrEmpty(optionCostPriceValueElement.GetAttribute("value"), "Option Cost Price Value");
                    TestCheck.AssertIsNotNullOrEmpty(optionSellPriceValueElement.GetAttribute("value"), "Option Sell Price Value");
                    VerifyOptionMarginValue();

                    MoveToClickPriceScreen();
                }
           
        }

        

        private void VerifyClickPriceFieldsArePopulatedOrNot()
        {
            TestCheck.AssertIsNotNullOrEmpty(ClickPriceCoverageElement.GetAttribute("value"), "Price Coverage Value");
            TestCheck.AssertIsNullOrEmpty(ClickPriceVolumeElement.GetAttribute("value"), "Price Volume Value");
            TestCheck.AssertIsNotNullOrEmpty(ClickPriceMarginElement.GetAttribute("value"), "Price Margin Value");

            if (ColourClickPriceElement() == null) return;
            TestCheck.AssertIsNotNullOrEmpty(ColourCoverageElement.GetAttribute("value"), "Price Colour Coverage Value");
            TestCheck.AssertIsNullOrEmpty(ColourVolumeElement.GetAttribute("value"), "Price Colour Volume Value");
            TestCheck.AssertIsNotNullOrEmpty(ColourMarginElement.GetAttribute("value"), "Price Colour Margin Value");
        }

        public void VerifyThatModelScreenFieldsRespondToChanges()
        {
            var prepopulatedModelSale = ProductSellPriceElement.GetAttribute("value");
            var prepopulatedModelMargin = ProductMarginElement.GetAttribute("value");

            //Change cost price and verify the reaction of the other fields
            EnterProductCostPrice("500");
            ProductCostPriceElement.SendKeys(Keys.Tab);

            var changedModelSale = ProductSellPriceElement.GetAttribute("value");
            var changedModelMargin = ProductMarginElement.GetAttribute("value");
            var prepopulatedModelCost = ProductCostPriceElement.GetAttribute("value");

            TestCheck.AssertIsEqual(false, prepopulatedModelSale.Equals(changedModelSale), "Prepopulated Model Sale");
            TestCheck.AssertIsEqual(true, prepopulatedModelMargin.Equals(changedModelMargin), "Prepopulated Model Margin");

            //Change sell price and verify the reaction of the other fields
            EnterProductSellPrice("530");
            ProductSellPriceElement.SendKeys(Keys.Tab);

            var nonChangedModelCost = ProductCostPriceElement.GetAttribute("value");
            var reChangedModelMargin = ProductMarginElement.GetAttribute("value");
            var reChangedModelSale = ProductSellPriceElement.GetAttribute("value");

            TestCheck.AssertIsEqual(true, prepopulatedModelCost.Equals(nonChangedModelCost), "Prepopulated Model Cost");
            TestCheck.AssertIsEqual(false, prepopulatedModelMargin.Equals(reChangedModelMargin), "Prepopulated Model Margin");

            //Change margin and verify the reaction of the other fields
            ClearAndType(ProductMarginElement, "40");
            ProductQuantityElement.SendKeys(Keys.Tab);

            var notChangedModelCost = ProductCostPriceElement.GetAttribute("value");
            var lastChangedModelSale = ProductSellPriceElement.GetAttribute("value");

            TestCheck.AssertIsEqual(true, nonChangedModelCost.Equals(notChangedModelCost), "None Changed Model Cost");
            TestCheck.AssertIsEqual(false, reChangedModelSale.Equals(lastChangedModelSale), "ReChanged Model State");
        }

        private String ClickPriceMonoCoverage()
        {
            return ClickPriceCoverageElement.GetAttribute("value");
        }

        private String ClickPriceMonoVolume()
        {
            return ClickPriceVolumeElement.GetAttribute("value");
        }

        private String ClickPriceMonoMargin()
        {
            return ClickPriceMarginElement.GetAttribute("value");
        }

        private String ClickPriceColourCoverage()
        {
            return ColourCoverageElement.GetAttribute("value");
        }

        private String ClickPriceColourVolume()
        {
            return ColourVolumeElement.GetAttribute("value");
        }

        private String ClickPriceColourMargin()
        {
            return ColourMarginElement.GetAttribute("value");
        }

        public void VerifyThatClickPriceFieldsArePopulatedOrNot()
        {
            //Verify that Mono fields are as they should be
            TestCheck.AssertIsNotNullOrEmpty(ClickPriceMonoCoverage(), "Price Mono Coverage");
            TestCheck.AssertIsNullOrEmpty(ClickPriceMonoVolume(), "Price Mono Volume");
            TestCheck.AssertIsNotNullOrEmpty(ClickPriceMonoMargin(), "Price Mono Margin");

            //Verify that Colour fields are as they should be
            TestCheck.AssertIsNotNullOrEmpty(ClickPriceColourCoverage(), "Price Colour Coverage");
            TestCheck.AssertIsNullOrEmpty(ClickPriceColourVolume(), "Price Colour Volume");
            TestCheck.AssertIsNotNullOrEmpty(ClickPriceColourMargin(), "Price Colour Margin");
        }

        private String GetClickPriceMonoCost()
        {
            return clickPriceMonoCostElement.Text;
        }

        private String GetClickPriceMonoSell()
        {
            return clickPriceMonoSellElement.Text;
        }

        private String GetClickPriceColourCost()
        {
            return clickPriceColourCostElement.Text;
        }

        private String GetClickPriceColourSell()
        {
            return clickPriceColourSellElement.Text;
        }

        private String GetInstallationCost()
        {
            return InstallationCostPriceElement.GetAttribute("value");
        }

        private String GetInstallationSell()
        {
            return InstallationSellPriceElement.GetAttribute("value");
        }

        private String GetInstallationMargin()
        {
            return InstallationMarginElement.GetAttribute("value");
        }

        private String GetPrinterOptionCost()
        {
            return OptionsCostPriceElement.GetAttribute("value");
        }

        private String GetPrinterOptionSell()
        {
            return OptionsSellPriceElement.GetAttribute("value");
        }

        private String GetPrinterOptionMargin()
        {
            return OptionsMarginElement.GetAttribute("value");
        }

        public void VerifyInstallationScreenFieldsRespondToChanges()
        {
            MoveToInstallationScreen();

            //Save the initial installation margin 
            var initialInstallMargin = GetInstallationMargin();

            //Enter installation values
            EnterInstallationCostPrice("230");
            EnterInstallationSellPrice("250");
            InstallationSellPriceElement.SendKeys(Keys.Tab);
            WebDriver.Wait(Helper.DurationType.Millisecond, 3);

            //Verify if the installation margin changed wrt these values
            var firstChangedInstallMargin = GetInstallationMargin();
            var initialInstallCost = GetInstallationCost();


            TestCheck.AssertIsEqual(false, firstChangedInstallMargin.Equals(initialInstallMargin), "First Changed Install Margin");

            //Change the Install Sell Price and verify how Install Cost price and margin react
            EnterInstallationSellPrice("300");
            InstallationSellPriceElement.SendKeys(Keys.Tab);
            WebDriver.Wait(Helper.DurationType.Millisecond, 3);

            var secondChangedInstallMargin = GetInstallationMargin();
            var firstInstallCost = GetInstallationCost();
            var firstInstallSell = GetInstallationSell();

            TestCheck.AssertIsEqual(true, initialInstallCost.Equals(firstInstallCost), "Initial Install Cost");
            TestCheck.AssertIsEqual(false, firstChangedInstallMargin.Equals(secondChangedInstallMargin), "First Changed Install Margin");

            //Change the Install Margin and verify how Install Cost price and Sell Price react
            ClearAndType(InstallationMarginElement, "40");
            InstallationMarginElement.SendKeys(Keys.Tab);
            WebDriver.Wait(Helper.DurationType.Millisecond, 3);

            var secondInstallSell = GetInstallationSell();
            var secondInstallCost = GetInstallationCost();

            TestCheck.AssertIsEqual(false, firstInstallSell.Equals(secondInstallSell), "First Install Sell");
            TestCheck.AssertIsEqual(true, secondInstallCost.Equals(firstInstallCost), "Second Install Cost");

        }

        public void VerifyProductOptionFieldsRespondToChangesAppropriately()
        {
            if (!IsElementPresent(OptionTabElement()))
                {
                    MoveToClickPriceScreen();
                }
                else
                {

                    ScrollTo(OptionTabElement());
                    OptionTabElement().Click();

                    IsOptionScreenTextDisplayed();
                    SelectADuplexOptions();
                    PrinterOptionsCostPriceChangesEffect();
                    PrinterOptionsSellPriceChangesEffect();
                    PrinterOptionsMarginChangesEffect();

                    MoveToClickPriceScreen();
                }
            
        }

        private void PrinterOptionsCostPriceChangesEffect()
        {
            var initialOptionSell = GetPrinterOptionSell();
            var initialOptionMargin = GetPrinterOptionMargin();

            //Change the cost price and verify how sell price and margin react
            ClearAndType(OptionsCostPriceElement, "100");
            WebDriver.Wait(Helper.DurationType.Millisecond, 3);

            var changedOptionSell = GetPrinterOptionSell();
            var changedOptionMargin = GetPrinterOptionMargin();

            //Only Selling price changes while Margin remain the same.
            TestCheck.AssertIsEqual(false, changedOptionSell.Equals(initialOptionSell), "Changed Option Sell");
            TestCheck.AssertIsEqual(true, changedOptionMargin.Equals(initialOptionMargin), "Changed Option Margin");


        }

        private void PrinterOptionsSellPriceChangesEffect()
        {
            var initialOptionCost = GetPrinterOptionCost();
            var initialOptionMargin = GetPrinterOptionMargin();

            //Change the sell price and verify how cost price and margin react
            ClearAndType(OptionsSellPriceElement, "300");
            OptionsSellPriceElement.SendKeys(Keys.Tab);
            WebDriver.Wait(Helper.DurationType.Millisecond, 3);

            var changedOptionCost = GetPrinterOptionCost();
            var changedOptionMargin = GetPrinterOptionMargin();

            //Only Margin changes while cost price remain the same
            TestCheck.AssertIsEqual(true, changedOptionCost.Equals(initialOptionCost), "Changed Option Cost");
            TestCheck.AssertIsEqual(false, changedOptionMargin.Equals(initialOptionMargin), "Changed Option Margin");

        }

        private void PrinterOptionsMarginChangesEffect()
        {
            var initialOptionCost = GetPrinterOptionCost();
            var initialOptionSell = GetPrinterOptionSell();


            //Change the margin and verify how cost and sell price react
            ClearAndType(OptionsMarginElement, "30");
            WebDriver.Wait(Helper.DurationType.Millisecond, 3);

            var changedOptionCost = GetPrinterOptionCost();
            var changedOptionSell = GetPrinterOptionSell();

            //Only Sell Price changes while Cost price remain the same
            TestCheck.AssertIsEqual(true, changedOptionCost.Equals(initialOptionCost), "Changed Option Cost");
            TestCheck.AssertIsEqual(false, changedOptionSell.Equals(initialOptionSell), "Changed Option Sell");


        }

        public void VerifyChangesToClickPricesGetCascaded()
        {
            //Save all the click prices values both mono and colour
            var monoClickPriceCost = GetClickPriceMonoCost();
            var monoClickPriceSell = GetClickPriceMonoSell();
            var colourClickPriceCost = GetClickPriceColourCost();
            var colourClickPriceSell = GetClickPriceColourSell();

            //Change the mono coverage value and verify how all the click prices react
            EnterCoverageValue("4");
            ClickPriceCoverageElement.SendKeys("0");
            clickPriceMonoCostElement.Click();
            WebDriver.Wait(Helper.DurationType.Millisecond, 5);

            var monoClickPriceCostFirstChange = GetClickPriceMonoCost();
            var monoClickPriceSellFirstChange = GetClickPriceMonoSell();
            var colourClickPriceCostFirstChange = GetClickPriceColourCost();
            var colourClickPriceSellFirstChange = GetClickPriceColourSell();

            //All click price values must change as a result of changes to Mono Coverage
            TestCheck.AssertIsEqual(false, monoClickPriceCost.Equals(monoClickPriceCostFirstChange), "Mono Click Price Cost");
            TestCheck.AssertIsEqual(false, monoClickPriceSell.Equals(monoClickPriceSellFirstChange), "mono Click Price Sell");
            TestCheck.AssertIsEqual(false, colourClickPriceCost.Equals(colourClickPriceCostFirstChange), "Colour Click Price Cost");
            TestCheck.AssertIsEqual(false, colourClickPriceSell.Equals(colourClickPriceSellFirstChange), "Colour Click Price Sell");

            //Change the mono margin value and verify how all the click prices react
            EnterClickPriceMargin("4");
            ClickPriceMarginElement.SendKeys("0");
            //ClickPriceMarginElement.SendKeys(Keys.Tab);
            WebDriver.Wait(Helper.DurationType.Millisecond, 5);

            var monoClickPriceCostSecondChange = GetClickPriceMonoCost();
            var monoClickPriceSellSecondChange = GetClickPriceMonoSell();
            var colourClickPriceCostSecondChange = GetClickPriceColourCost();
            var colourClickPriceSellSecondChange = GetClickPriceColourSell();

            //All the sell click price changes
            TestCheck.AssertIsEqual(true, monoClickPriceCostFirstChange.Equals(monoClickPriceCostSecondChange), "Price Cost First Change");
            TestCheck.AssertIsEqual(false, monoClickPriceSellFirstChange.Equals(monoClickPriceSellSecondChange), "Price Sell First Change");
            TestCheck.AssertIsEqual(true, colourClickPriceCostFirstChange.Equals(colourClickPriceCostSecondChange), "Colour Price Cost First Change");
            TestCheck.AssertIsEqual(true, colourClickPriceSellFirstChange.Equals(colourClickPriceSellSecondChange), "Colour Price Cost Sell First Change");

            //Change the colour coverage values and verify how all click prices react
            EnterColourCoverage("4");
            ColourCoverageElement.SendKeys("0");
            clickPriceColourCostElement.Click();
            WebDriver.Wait(Helper.DurationType.Millisecond, 5);

            var monoClickPriceCostThirdChange = GetClickPriceMonoCost();
            var monoClickPriceSellThirdChange = GetClickPriceMonoSell();
            var colourClickPriceCostThirdChange = GetClickPriceColourCost();
            var colourClickPriceSellThirdChange = GetClickPriceColourSell();

            //Only the colour click prices cost and sell prices are changed
            TestCheck.AssertIsEqual(true, monoClickPriceCostSecondChange.Equals(monoClickPriceCostThirdChange), "Mono Price Cost Second Change");
            TestCheck.AssertIsEqual(true, monoClickPriceSellSecondChange.Equals(monoClickPriceSellThirdChange), "Mono Price Sell Second Change");
            TestCheck.AssertIsEqual(false, colourClickPriceCostSecondChange.Equals(colourClickPriceCostThirdChange), "Colour Price Costs Second Change");
            TestCheck.AssertIsEqual(false, colourClickPriceSellSecondChange.Equals(colourClickPriceSellThirdChange), "Colour Price Costs Sell Second Change");

            //Change the colour margin values and verify how all click prices react
            EnterColourMargin("4");
            ColourMarginElement.SendKeys("0");
            WebDriver.Wait(Helper.DurationType.Millisecond, 5);

            var monoClickPriceCostFourthChange = GetClickPriceMonoCost();
            var monoClickPriceSellFourthChange = GetClickPriceMonoSell();
            var colourClickPriceCostFourthChange = GetClickPriceColourCost();
            var colourClickPriceSellFourthChange = GetClickPriceColourSell();

            //Only the colour click price sell price is changed
            TestCheck.AssertIsEqual(true, monoClickPriceCostThirdChange.Equals(monoClickPriceCostFourthChange), "Mono Price Cost Third Change");
            TestCheck.AssertIsEqual(true, monoClickPriceSellThirdChange.Equals(monoClickPriceSellFourthChange), "Mono Price Sell Third Change");
            TestCheck.AssertIsEqual(true, colourClickPriceCostThirdChange.Equals(colourClickPriceCostFourthChange), "Colour Price Cost Third Change");
            TestCheck.AssertIsEqual(false, colourClickPriceSellThirdChange.Equals(colourClickPriceSellFourthChange), "Colour Price Sell Third Change");

        }

    }
}
