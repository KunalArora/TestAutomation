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
        private const string priceHardwareTickBox = @"#content_1_InputPriceHardware_Input";
        private const string monoVolume = @"#content_1_LineItems_InputMonoVolumeBreaks_0";
        private const string colourVolume = @"#content_1_LineItems_InputColourVolumeBreaks_0";
        private const string hardwareTick = @"#content_1_InputPriceHardware_Input";

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
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerName")]
        private IWebElement CompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyNumber_Input")]
        private IWebElement PropertyNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyStreet_Input")]
        private IWebElement PropertyStreetElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPropertyArea_Input")]
        private IWebElement PropertyAreaElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyTown_Input")]
        private IWebElement PropertyTownElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyPostCode_Input")]
        private IWebElement PropertyPostcodeElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyCounty_Input")]
        private IWebElement PropertyCountyElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputRegion_Input")]
        private IWebElement RegionElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTitle_Input")]
        private IWebElement ContactTitleElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonFirstName_Input")]
        private IWebElement FirstNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonLastName_Input")]
        private IWebElement LastNameElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPosition_Input")]
        private IWebElement PositionElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTelephone_Input")]
        private IWebElement TelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonEmail_Input")]
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
        [FindsBy(How = How.Id, Using = "content_1_InputPriceHardware_Input")]
        private IWebElement PriceHardwareElement;        
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
        [FindsBy(How = How.Id, Using = "InstallationPackCostPrice")]
        private IWebElement InstallationPackCostPriceElement;
        [FindsBy(How = How.Id, Using = "InstallationPackMargin")]
        private IWebElement InstallationPackMarginElement;
        [FindsBy(How = How.Id, Using = "InstallationPackSellPrice")]
        private IWebElement InstallationPackSellPriceElement;
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
        [FindsBy(How = How.Id, Using = "OptionQuantity0")]
        private IWebElement OptionsQuantityElement;
        [FindsBy(How = How.Id, Using = "OptionCostPrice0")]
        private IWebElement OptionsCostPriceElement;
        [FindsBy(How = How.Id, Using = "OptionSellPrice0")]
        private IWebElement OptionsSellPriceElement;
        [FindsBy(How = How.Id, Using = "OptionMargin0")]
        private IWebElement OptionsMarginElement;
        [FindsBy(How = How.Id, Using = "DeliveryCostPrice")]
        private IWebElement DeliveryCostPriceElement;
        [FindsBy(How = How.Id, Using = "DeliveryMargin")]
        private IWebElement DeliveryMarginElement;
        [FindsBy(How = How.Id, Using = "DeliverySellPrice")]
        private IWebElement DeliverySellPriceElement;
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
        [FindsBy(How = How.CssSelector, Using = "#ClickPriceColourCoverage")]
        private IWebElement ColourCoverageElement;
        [FindsBy(How = How.Id, Using = "ClickPriceColourVolume")]
        private IWebElement ColourVolumeElement;
        [FindsBy(How = How.Id, Using = "ClickPriceColourMargin")]
        private IWebElement ColourMarginElement;
        [FindsBy(How = How.CssSelector, Using = "input[id*=\"content_1_PersonList_List_InputChoice\"]")]
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
        private IWebElement servicePackMarginElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputMonoVolumeBreaks_0")]
        private IWebElement monoVolumeDropdownElement;
        [FindsBy(How = How.Id, Using = "content_1_LineItems_InputColourVolumeBreaks_0")]
        private IWebElement colourVolumeDropdownElement;
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
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractType")]
        private IWebElement SummaryContractTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractTerm")]
        private IWebElement SummaryContractTermElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_UsageType")]
        private IWebElement SummaryUsageTermElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_UsageBillingFrequency")]
        private IWebElement SummaryUsageBillingFrequencyElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LeaseRentalFrequency")]
        private IWebElement SummaryLeaseRentalFrequencyElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareBillingBasis")]
        private IList<IWebElement> SummaryBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareSku_0")]
        private IWebElement SummaryItemizedPrinterElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareSku")]
        private IList<IWebElement> SummaryItemizedPrintersElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoVolume_0")]
        private IWebElement SummaryMonoClickVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourVolume_0")]
        private IWebElement SummaryColourClickVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoVolume")]
        private IList<IWebElement> SummaryMonoClickVolumeElements;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourVolume")]
        private IList<IWebElement> SummaryColourClickVolumeElements;

        
        public void IsPromptTextDisplayed()
        {
            if (PromptText == null) throw new 
                NullReferenceException("Unable to locate text on New Proposal Process Screen");
           
            AssertElementPresent(PromptText, "Leading Instruction");
        }


        public void IsCustomerInfoTextDisplayed()
        {
            if (CustomerInfomationElement == null) throw new 
                NullReferenceException("Unable to locate text on Customer Information Screen");

            AssertElementPresent(CustomerInfomationElement, "Customer information leading instruction");
        }


        public void CheckPrivateLiableBox(string liable)
        {
            if (liable.Equals("tick"))
            {
                PrivateLiableElement.Click();
            }
            
        }

        public CreateNewProposalPage ClickNextButton_old()
        {
            ScrollTo(NextButton);
            NextButton.Click();
            return GetTabInstance<CreateNewProposalPage>(Driver);
        }

        public DealerProposalsCreateTermAndTypePage ClickNextButton()
        {
            ScrollTo(NextButton);
            NextButton.Click();
            return GetTabInstance<DealerProposalsCreateTermAndTypePage>(Driver);
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

        private void VerifyProposalDescriptionFieldsAreDisabled()
        {
            TestCheck.AssertIsEqual(false, ProposalNameField.Enabled, "Is proposal name field disabled?");
            TestCheck.AssertIsEqual(false, LeadCodeRef.Enabled, "Is lead code ref disabled?");
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
                default:
                    throw new InvalidEnumArgumentException(String.Format("{0} is not a valid contract type", tab));
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
                default:
                    throw new InvalidEnumArgumentException(String.Format("{0} is not a valid contract type", tab));
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
            TestCheck.AssertIsEqual(false, monoVolumeDropdownElement.Enabled, "Colour Volume DropDown Element disabled?");
            TestCheck.AssertIsEqual(false, ClickCoverageElement.Enabled, "Click coverage Element disabled?");
            TestCheck.AssertIsEqual(false, ClickMarginElement.Enabled, "Click margin Element disabled?");
        }

        private void VerifyClickPriceColourFieldsAreDisabled()
        {
            TestCheck.AssertIsEqual(false, colourVolumeDropdownElement.Enabled, "Click Volume Element disabled?");
            TestCheck.AssertIsEqual(false, ClickColourCoverageElement.Enabled, "Click colour coverage Element disabled?");
            TestCheck.AssertIsEqual(false, ClickColourMarginElement.Enabled, "Click colour margin Element disabled?");
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

        public void CustomerCreationOptions(string option)
        {
            switch (option)
            {
                case "Create new customer":
                    ClickCreateNewCustomerRadioButton();
                    break;
                case "Selecting existing customer":
                    ClickSelectExistingCustomerRadioButton();
                    break;
                case "Skip customer creation":
                    ClickSkipCustomerRadioButton();
                    break;
                default:
                    throw new InvalidEnumArgumentException(String.Format("{0} is not a valid contract type", option));
            }
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
            //EnterPropertyArea();
            EnterPropertyTown();
            EnterPropertyPostCode();
            //SelectRegionFromDropdown("Greater Manchester");
        }


        public void FillOrganisationContactDetail()
        {
            SelectTitleFromDropdown();
            EnterContactFirstName();
            EnterContactSurName();
            //EnterContactPosition();
            EnterContactTelephone();
            EnterContactEmailAdress();
        }

        private IWebElement ColourClickPriceElement()
        {
            return GetElementByCssSelector(colourElement, 10);
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
            return GetElementByCssSelector(contractSelector, 10);
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
                case "Purchase & Click with Service":
                    selectable = "3";
                    break;
                case "Lease & Click with Service":
                    selectable = "2";
                    break;
                default:
                    throw new InvalidEnumArgumentException(String.Format("{0} is not a valid contract type", contract));
            }

            if (ContractTypeSelector.Displayed)
            {
                SelectFromDropdownByValue(ContractTypeSelector, selectable);
                SpecFlow.SetContext("CreateContractType", contract);
            }
        }

        public void SelectingContractUsageType(string contract)
        {
            if (IsElementPresent(ContractTypeSelectorDropdown()))
                SelectContractUsageType(contract);
         
        }

        public void SelectContractUsageType(string usage)
        {
            var selectable = "";

            switch (usage)
            {
                case "Minimum Volume" :
                    selectable = "1";
                    break;
                case "Pay As You Go" :
                    selectable = "2";
                    break;
                default:
                    throw new InvalidEnumArgumentException(String.Format("{0} is not a valid contract type", usage));
            }

            if (UsageTypeSelector.Displayed)
            {
                SelectFromDropdownByValue(UsageTypeSelector, selectable);
                SpecFlow.SetContext("CreateUsageType", usage);
            }
        }
        

        public void EnterContactFirstName()
        {
            FirstNameElement.SendKeys(MpsUtil.FirstName());
        }

        public void EnterContactSurName()
        {
            LastNameElement.SendKeys(MpsUtil.SurName());
        }

        public void EnterContactTelephone()
        {
            TelephoneElement.SendKeys(MpsUtil.CompanyTelephone());
        }

        public void EnterContactEmailAdress()
        {
            EmailElement.SendKeys(MpsUtil.GenerateUniqueEmail());
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


        public void SelectARandomExistingContact()
        {
            var noOfContacts = ExistingContactRadioButtonElement.Count;

            var ranClick = new Random().Next(0, noOfContacts - 1);


            ExistingContactRadioButtonElement[ranClick].Click();

        }

        public void SelectAPrinterFromTheList(string printer)
        {
           // ClickOnAPrinter(printer);
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
    }
}
