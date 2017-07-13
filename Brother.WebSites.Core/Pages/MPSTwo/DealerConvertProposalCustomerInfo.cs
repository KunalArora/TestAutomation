using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerConvertProposalCustomerInfo : BasePage
    {
        public static string Url = "/";

        private const string CustomerString = "#DataTables_Table_0 tbody tr:first-child td:first-child";
        private const string CustomerContainer = @"#DataTables_Table_0";
       

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }



        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCustomerChoiceNew")]
        public IWebElement ConvertCreateNewCustomer;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCustomerChoiceExisting")]
        public IWebElement ConvertExistingCustomer;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonCanOrderConsumables_Input")]
        public IWebElement CanOrderConsumablesTick;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerLegalForm_Input")]
        public IWebElement LegalFormDropdown;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerCompanyRegistrationNumber_Input")]
        public IWebElement CompanyRegistrationNumberField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerVatRegistrationNumber_Input")]
        public IWebElement VATNumberField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerTradingStyle_Input")]
        public IWebElement TradingStyleElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerAuthorisedSignatory_Input")]
        public IWebElement AuthorizedSignatoryElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankPaymentType_Input")]
        public IWebElement PaymentTypeDropdown;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankName_Input")]
        public IWebElement BankNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankAccountNumber_Input")]
        public IWebElement BankAccountNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankSortCode_Input")]
        public IWebElement BankSortCodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankIban_Input")]
        public IWebElement IBANElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankBic_Input")]
        public IWebElement BICElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_BankLocation_InputNumber_Input")]
        public IWebElement BankPropertyNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_BankLocation_InputStreet_Input")]
        public IWebElement BankPropertyStreetElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_BankLocation_InputTown_Input")]
        public IWebElement BankPropertyTownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_BankLocation_InputPostCode_Input")]
        public IWebElement BankPropertyPostcodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement NextElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerName")]
        public IWebElement CompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyNumber_Input")]
        public IWebElement PropertyNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyStreet_Input")]
        public IWebElement PropertyStreetElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPropertyArea_Input")]
        public IWebElement PropertyAreaElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyTown_Input")]
        public IWebElement PropertyTownElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyPostCode_Input")]
        public IWebElement PropertyPostcodeElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputRegion_Input")]
        public IWebElement RegionElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonFirstName_Input")]
        public IWebElement FirstNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonLastName_Input")]
        public IWebElement LastNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTelephone_Input")]
        public IWebElement TelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonEmail_Input")]
        public IWebElement EmailElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTitle_Input")]
        public IWebElement ContactTitleElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityTitle_Input")]
        public IWebElement PrivateLiableTitleElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityFirstName_Input")]
        public IWebElement PrivateLiableFirstNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityLastName_Input")]
        public IWebElement PrivateLiableLastNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityDateOfBirth_Input")]
        public IWebElement PrivateLiableDOBElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityPropertyNumber_Input")]
        public IWebElement PrivateLiablePropertyNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityPropertyStreet_Input")]
        public IWebElement PrivateLiablePropertyStreetElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityPropertyTown_Input")]
        public IWebElement PrivateLiablePropertyTownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityPropertyPostCode_Input")]
        public IWebElement PrivateLiablePropertyPostCodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityRegion_Input")]
        public IWebElement PrivateLiablePropertyRegionElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCustomerChoiceNew")]
        public IWebElement CreateNewCustomerRadioButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_CustomerLocation_InputStreet_Input")]
        public IWebElement StraßeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_CustomerLocation_InputNumber_Input")]
        public IWebElement HausnummberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_CustomerLocation_InputPostCode_Input")]
        public IWebElement GermanPostCodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_CustomerLocation_InputTown_Input")]
        public IWebElement GermanStadtElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_CustomerLocation_InputArea_Input")]
        public IWebElement GermanGeschäftsfeldElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_CustomerLocation_InputRegion_Input")]
        public IWebElement GermanBundeslandElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerCostCentre_Input")]
        public IWebElement GermanKostenstelleElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerLegalForm_Input")]
        public IWebElement GermanRechtsformElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerVatRegistrationNumber_Input")]
        public IWebElement GermanUstIDNrElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerCompanyRegistrationNumber_Input")]
        public IWebElement GermanHandelsregisternummerElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerCreditReformNumber_Input")]
        public IWebElement GermanCreditreformNummerElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerAuthorisedSignatory_Input")]
        public IWebElement GermanZeichnungsberechtigterElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonListFilter_InputFilterBy")]
        public IWebElement ExistingCustomerFilterElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonPosition_Input")]
        public IWebElement CustomerPositionElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerCostCentre_Input")]
        public IWebElement CostCentreElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonMobile_Input")]
        public IWebElement MobileElement;
        

        

        
        



        public void IsConvertCustomerInfoScreenDisplayed()
        {
            if(CreateNewCustomerRadioButtonElement == null)
                throw new Exception("Customer Info page for conversion is not displayed");
            AssertElementPresent(CreateNewCustomerRadioButtonElement, "Customer radio button not displayed");
        }

        public void CreateANewCustomerInConvertProcess()
        {
            if(ConvertCreateNewCustomer == null)
                throw new Exception("Cannot choose customer creation option");
            ConvertCreateNewCustomer.Click();
            NextElement.Click();
        }

        public void ChooseExistingCustomerInConvertProcess()
        {
            if (ConvertExistingCustomer == null)
                throw new Exception("Cannot choose customer creation option");
            ConvertExistingCustomer.Click();
            NextElement.Click();
        }

        
        public void SelectASpecificExistingContact(string contact)
        {

            WaitForElementToExistByCssSelector(CustomerContainer);
            ClearAndType(ExistingCustomerFilterElement, contact);
            WebDriver.Wait(DurationType.Second, 3);

            try
            {
                var customerChoice =
                    Driver.FindElement(By.CssSelector(CustomerString));

                WaitForElementToExistByCssSelector(CustomerContainer);

                customerChoice.Click();
            }
            catch (WebDriverException wde)
            {
                MsgOutput(String.Format("The exception thrown was {0}", wde));
            }

            NextElement.Click();

        }

        
        public void CustomerCanOrderConsumables()
        {
            CanOrderConsumablesTick.Click();
         }

        public void SelectALegalForm()
        {
            if (IsGermanSystem() || IsAustriaSystem())
            {
                SelectFromDropdown(LegalFormDropdown, "Aktiengesellschaft");

            }
            else if (IsUKSystem() || IsItalySystem())
            {
               SelectFromDropdown(LegalFormDropdown, "Church");
            }
            else if (IsIrelandSystem())
            {
                SelectFromDropdown(LegalFormDropdown, "School");
            }
            else if (IsFranceSystem())
            {
                SelectFromDropdown(LegalFormDropdown, "Administration");
            }
            else if (IsNorwaySystem())
            {
                SelectFromDropdown(LegalFormDropdown, "Enkeltpersonforetak");
            }
            else if (IsDenmarkSystem())
            {
                SelectFromDropdown(LegalFormDropdown, "Enkeltmandsvirksomhed");
            }
            else if (IsSwissSystem())
            {
                var language = SwissLegalForm();
                SelectFromDropdown(LegalFormDropdown, language);
            }
            else if (IsBelgiumSystem())
            {
                var language = BelgianLegalForm();
                SelectFromDropdown(LegalFormDropdown, language);
            }
            //else if (IsSwedenSystem())
            //{
            //    SelectFromDropdown(LegalFormDropdown, "Aktiebolag");
            //}
                
            WebDriver.Wait(DurationType.Second, 3);
        }

        private String SwissLegalForm()
        {
            string lang;
            string language;

            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "Deutsch";
            }

            switch (language)
            {
                case "Français":
                    lang = "Fondation";
                    break;
                case "Deutsch":
                    lang = "Einzelfirma";
                    break;

                default:
                    lang = "Einzelfirma";
                    break;
            }

            return lang;
        }

        private String BelgianLegalForm()
        {
            string lang;

            string language;

            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "French";
            }

            switch (language)
            {
                case "" :
                case "French":
                    lang = "Gouvernement";
                    break;
                case "Dutch":
                    lang = "Overheid";
                    break;

                default:
                    lang = "Overheid";
                    break;
            }

            return lang;
        }

        public void SelectAPrivatelyLiableCustomer(string company)
        {
            
            SelectFromDropdown(LegalFormDropdown, company);
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void EnterCompanyRegistration()
        {
            if (IsUKSystem())
            {
                ClearAndType(CompanyRegistrationNumberField, "00664172");
            }
            else if (IsFranceSystem())
            {
                ClearAndType(CompanyRegistrationNumberField, "453983245");
            }
            //else if (IsSpainSystem())
            //{
            //    ClearAndType(CompanyRegistrationNumberField, "N0032484H");
            //}
            //else if (IsSwissSystem())
            //{
            //    ClearAndType(CompanyRegistrationNumberField, "CHE-106.568.179");
            //}
            //else if (IsSwedenSystem())
            //{
            //    ClearAndType(CompanyRegistrationNumberField, "556026-6883");
            //}
                
            
        }

        public void EnterVatNumber()
        {
            if (IsUKSystem())
            {
                ClearAndType(VATNumberField, "GB100000132");
            }
            else if(IsFranceSystem())
            {
                ClearAndType(VATNumberField, "FR40303265045");
            } else if (IsItalySystem())
            {
                ClearAndType(VATNumberField, "IT00743110157");
            } else if (IsSpainSystem())
            {
                ClearAndType(VATNumberField, "ES54362315K");
            }
            else if (IsSwedenSystem())
            {
                ClearAndType(VATNumberField, "SE123456789701");
            }
            else if (IsPolandSystem())
            {
                ClearAndType(VATNumberField, "PL8567346215");
            }
            else if (IsSwissSystem())
            {
                ClearAndType(VATNumberField, "CHE-106.568.179 MWST");
            }
        }

        public void EnterAuthoriisedSignatoryNumber()
        {
            ClearAndType(AuthorizedSignatoryElement, "Mensha Uston");
        }


        private string TradingStyle()
        {
            var trading = "";

            if (IsUKSystem() || IsFranceSystem()||IsIrelandSystem())
            {
                trading = "Non-Regulated";
            } else if (IsItalySystem())
            {
                trading = "Non regolamentato";
            }
            else if (IsSpainSystem())
            {
                trading = "No regulado";
                //trading = "Persona Física";
            }
            else if (IsNetherlandSystem())
            {
                trading = "Non-Regulated";
            }
            else if (IsBelgiumSystem())
            {
                trading = "Non-Regulated";
            }
            else if (IsPolandSystem())
            {
                trading = "Non-Regulated";
            }
            else if (IsNorwaySystem())
            {
                trading = "Ikke regulert";
            }
            else if (IsDenmarkSystem())
            {
                trading = "Ikke-reguleret";
            }
            else if (IsFinlandSystem())
            {
                trading = "Ei-säännelty";
            }
            else if (IsSwissSystem())
            {
                trading = "Non-Regulated";
            }
            //else if (IsSwedenSystem())
            //{
            //    trading = "Icke reglerad";
            //}

            
            return trading;
        }

        public void SelectATradingStyle()
        {
            if (IsUKSystem()||IsSpainSystem())
                SelectFromDropdown(TradingStyleElement, TradingStyle());
                WebDriver.Wait(DurationType.Second, 3);
        }

        public void SelectAPaymentType()
        {
            if (IsElementPresent(GetElementByCssSelector("#content_1_PersonManage_InputBankPaymentType_Input", 10)))
            {
                if (IsGermanSystem() || IsAustriaSystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Bankeinzug");

                }
                else if (IsUKSystem()|| IsIrelandSystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Direct Debit");

                } else if (IsFranceSystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Débit direct");

                } else if (IsItalySystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Addebito diretto");
                } else if (IsSpainSystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Debito directo");
                }
                else if (IsNetherlandSystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Automatische incasso");
                }
                else if (IsSwedenSystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Direktbetalning");
                }
                else if (IsPolandSystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Polecenie zapłaty");
                }
                else if (IsBelgiumSystem())
                {
                    var language = BelgianLanguage();
                    SelectFromDropdown(PaymentTypeDropdown, language);
                }
                else if (IsNorwaySystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Fast trekk");
                }
                else if (IsFinlandSystem())
                {
                    var language = FinnishLanguage();
                    SelectFromDropdown(PaymentTypeDropdown, language);
                }
                else if (IsSwissSystem())
                {
                    var language = SwissLanguage();
                    SelectFromDropdown(PaymentTypeDropdown, language);
                }
                else if (IsDenmarkSystem())
                {
                    SelectFromDropdown(PaymentTypeDropdown, "Betalingsservice");
                }
            }
            
            WebDriver.Wait(DurationType.Second, 3);
        }

        private String BelgianLanguage()
        {
            string lang;
            string language;

            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "French";
            }

            switch (language)
            {
                case "French" :
                    lang = "Domiciliation";
                    break;
                case "Dutch" :
                    lang = "Domiciliëring";
                    break;

                default :
                    lang = "Domiciliation";
                    break;
            }

            return lang;
        }

        private String FinnishLanguage()
        {
            string lang;

            string language;
            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "Suomi";
            }

            switch (language)
            {
                case "Suomi":
                    lang = "Suoraveloitus";
                    break;
                case "Svenska":
                    lang = "Direct Debit";
                    break;

                default:
                    lang = "Suoraveloitus";
                    break;
            }

            return lang;
        }

        private String SwissLanguage()
        {
            string lang;

            string language;
            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "Deutsch";
            }

            switch (language)
            {
                case "Français":
                    //lang = "Débit direct";
                    lang = "Prélèvement automatique";
                    break;
                case "Deutsch":
                    //lang = "Bankeinzug";
                    lang = "LSV";
                    break;

                default:
                    lang = "LSV";
                    break;
            }

            return lang;
        }

        public void EnterBankName()
        {
            if (IsNetherlandSystem()|| IsNorwaySystem()) return;
            ClearAndType(BankNameElement, "BNP Paribus");
        }

        public void EnterBankAccountNumber()
        {
            if (IsNetherlandSystem() || IsSpainSystem() || IsNorwaySystem()) return;
            ClearAndType(BankAccountNumberElement, "45789635");
        }

        public void EnterBankSortCode()
        {
            if (IsNetherlandSystem() || IsBelgiumSystem() || IsPolandSystem() || IsSpainSystem() || IsNorwaySystem()) return;
            ClearAndType(BankSortCodeElement, "014215");
        }

        public void EnterIbanNumber()
        {
            if (IsPolandSystem()) return;
            if (!(IsItalySystem() || IsNetherlandSystem()))
            {
                ClearAndType(IBANElement, "GB15MIDL40051512345678");

            } else if (IsNetherlandSystem())
            {
                ClearAndType(IBANElement, "NL91 ABNA 0417 1643 00"); 
            } else if (IsBelgiumSystem())
            {
                ClearAndType(IBANElement, "BE68539007547034");
            }
            
        }

        public void EnterBicNumber()
        {
            if (IsBelgiumSystem())
            {
                ClearAndType(BICElement, "ACCOBEB3");
            } else if (!(IsItalySystem() || IsNetherlandSystem() || IsSpainSystem()))
            {
                ClearAndType(BICElement, "MIDLGB22"); 
            }
            
        }

        public void EnterBankPropertyNumber()
        {
            if (!(IsBigAtSystem() 
                || IsFranceSystem() 
                || IsSpainSystem() 
                || IsItalySystem() 
                || IsNetherlandSystem() 
                || IsBelgiumSystem() 
                || IsSwissSystem()))
            {
                ClearAndType(BankPropertyNumberElement, "12345");
            }
                 
        }

        public void EnterBankPropertyStreet()
        {
            if (IsBigAtSystem() 
                || IsNetherlandSystem() 
                || IsBelgiumSystem() 
                || IsSpainSystem()
                || IsSwissSystem()) return;
            ClearAndType(BankPropertyStreetElement, "Lloyds House");
        }

        public void EnterBankPropertyTown()
        {
            if (IsBigAtSystem() 
                || IsNetherlandSystem() 
                || IsBelgiumSystem() 
                || IsSpainSystem()
                || IsSwissSystem()) return;
            ClearAndType(BankPropertyTownElement, "Cockney");
        }

        public void EnterBankPropertyPostcode()
        {
            if (IsUKSystem())
            {
                ClearAndType(BankPropertyPostcodeElement, "M1 3ED");
            }
            else if (IsFranceSystem())
            {
                ClearAndType(BankPropertyPostcodeElement, "25310");
            }
            else if (IsItalySystem())
            {
                ClearAndType(BankPropertyPostcodeElement, "01100");
            }
            else if (IsIrelandSystem())
            {
                ClearAndType(BankPropertyPostcodeElement, MpsUtil.PostCodeIr());
            }
            else if (IsSwedenSystem())
            {
                ClearAndType(BankPropertyPostcodeElement, MpsUtil.PostCodeNs());
            }
            else if (IsPolandSystem())
            {
                ClearAndType(BankPropertyPostcodeElement, MpsUtil.PostCodePl());
            }
            else if (IsDenmarkSystem())
            {
                ClearAndType(BankPropertyPostcodeElement, MpsUtil.PostCodeDk());
            }
            else if (IsFinlandSystem())
            {
                ClearAndType(BankPropertyPostcodeElement, MpsUtil.PostCodeFi());
            }
            else if (IsNorwaySystem())
            {
                ClearAndType(BankPropertyPostcodeElement, MpsUtil.PostCodeNo());
            }
            //else if (IsSwissSystem())
            //{
            //    ClearAndType(BankPropertyPostcodeElement, MpsUtil.PostCodeSw());
            //}
            //else if (IsSpainSystem())
            //{
            //    ClearAndType(BankPropertyPostcodeElement, MpsUtil.PostCodeSp());
            //}
        }

        private void EnterCostCentre()
        {
            if (IsSwedenSystem() || IsDenmarkSystem() || IsNorwaySystem())
            {
                ClearAndType(CostCentreElement, "Marketing");
            }
        }

        public void FillAllCustomerDetailsOnConvert()
        {
            if (!(IsGermanSystem() || IsAustriaSystem())) return;
            CreateANewCustomerInConvertProcess();
            FillGermanOrganisationDetails();
            FillOrganisationContactDetail();
            
        }

        public void EnterRemainingCustomerInfo()
        {
            //if (IsSwissSystem())
            //{
            //    CreateANewCustomerInConvertProcess();
            //}

            SelectTitleFromDropdown();
            SelectALegalForm();
            EnterCompanyRegistration();
            EnterVatNumber();
            EnterCostCentre();
            SelectATradingStyle();
            EnterAuthoriisedSignatoryNumber();
            EnterContactPosition();
            EnterRegionNameForCustomer();
            EnterGermanStreetNumber();

            if (IsPolandSystem())
            {
                FillOrganisationContactDetail();
                FillPolandOrgDetail();
            }

            if (IsBelgiumSystem()||IsFranceSystem())
            {
                MobileElement.SendKeys("01234567890");
            }

            //FillSwissOrgDetail();

            if(IsNetherlandSystem())
                CustomerCanOrderConsumables();
        }

        public void EnterPrivateLiableCustomerInfo(string company)
        {
            SelectAPrivatelyLiableCustomer(company);
            EnterCompanyRegistration();
            EnterVatNumber();
            EnterContactPosition();
            SelectATradingStyle();
            EnterAuthoriisedSignatoryNumber();
            
        }

        public void EnterAllBankInformation()
        {
            if (IsSwedenSystem()) return;
            SelectAPaymentType();
            if (IsNorwaySystem() || IsFinlandSystem() || IsDenmarkSystem()) return;
            EnterBankName();
            EnterBankAccountNumber();
            EnterBankSortCode();
            EnterIbanNumber();
            EnterBicNumber();
            EnterBankPropertyNumber();
            EnterBankPropertyStreet();
            EnterBankPropertyTown();
            EnterBankPropertyPostcode();
            if(IsPolandSystem())
            CustomerCanOrderConsumables();
        }

        private void SelectPrivateLiableTitle()
        {
            SelectFromDropdown(PrivateLiableTitleElement, "Mrs");
        }

        private void EnterPrivateLiableFirstName()
        {
            ClearAndType(PrivateLiableFirstNameElement, "Private");
        }

        private void EnterContactPosition()
        {
            if(IsIrelandSystem()|| IsPolandSystem())
            ClearAndType(CustomerPositionElement, "Manager");
        }

        private void EnterPrivateLiableLastName()
        {
            ClearAndType(PrivateLiableLastNameElement, "Liable");
        }

        private void EnterPrivateLiableDateOfBirth()
        {
            PrivateLiableDOBElement.SendKeys(MpsUtil.DateOfBirth());
        }

        private void EnterPrivatePropertyNumber()
        {
            ClearAndType(PrivateLiablePropertyNumberElement, "25");
        }

        private void EnterPrivatePropertyStreet()
        {
            ClearAndType(PrivateLiablePropertyStreetElement, "Privately Liable");
        }

        private void EnterPrivatePropertyTown()
        {
            ClearAndType(PrivateLiablePropertyTownElement, "Manchester");
        }

        private void EnterPrivatePropertyPostCode()
        {
            ClearAndType(PrivateLiablePropertyPostCodeElement, "M34 5JE");
        }

        private void SelectPrivatePropertyRegion()
        {
            SelectFromDropdown(PrivateLiablePropertyRegionElement, "Greater Manchester");
        }

        public void EnterPrivateLiableInfo()
        {
            SelectPrivateLiableTitle();
            EnterPrivateLiableFirstName();
            EnterPrivateLiableLastName();
            EnterPrivateLiableDateOfBirth();
            EnterPrivatePropertyNumber();
            EnterPrivatePropertyStreet();
            EnterPrivatePropertyTown();
            EnterPrivatePropertyPostCode();
            SelectPrivatePropertyRegion();
            
        }


        public void FillOrganisationDetails()
        {
            //EnterCompanyName();
            EnterPropertyNumber();
            EnterPropertyStreet();
            //EnterPropertyArea();
            EnterPropertyTown();
            EnterPropertyPostCode();
            //SelectRegionFromDropdown("Greater Manchester");
           
        }

        public void FillGermanOrganisationDetails()
        {
            EnterCompanyName();
            EnterGermanAreaName();
            EnterGermanKostenstelleName();
            EnterGermanPostCode();
            EnterRegionNameForCustomer();
            EnterGermanStadtName();
            EnterGermanStreetName();
            EnterGermanStreetNumber();
            SelectGermanRechtsformName();
            EnterAuthorizedSignatory();
            EnterCompanyRegistrationNumber();
            EnterCompanyVATNumber();
            EnterCreditReformNumber();
            
        }

        public void FillPolandOrgDetail()
        {
            if(IsPolandSystem())
            ClearAndType(StraßeElement, "Poznan");
            ClearAndType(HausnummberElement, "23");
            ClearAndType(GermanPostCodeElement, MpsUtil.PostCodePl());
            ClearAndType(GermanStadtElement, "Town");

        }

        public void FillSwissOrgDetail()
        {
            if (!IsSwissSystem()) return;
            EnterCompanyName();
            FillOrganisationContactDetail();
            ClearAndType(StraßeElement, "Geneve");
            ClearAndType(HausnummberElement, "23");
            ClearAndType(GermanPostCodeElement, MpsUtil.PostCodeSw());
            ClearAndType(GermanStadtElement, "Town");
        }

        public void EnterGermanStreetName()
        {
            StraßeElement.SendKeys("Friedrichstraße");
        }

        public void EnterGermanStreetNumber()
        {
            if(IsBigAtSystem())
            HausnummberElement.SendKeys("23");
        }

        public void EnterGermanPostCode()
        {
            if (IsGermanSystem())
            {
                GermanPostCodeElement.SendKeys(MpsUtil.GermanPostCodeNumber());

            } else if (IsAustriaSystem())
            {
                GermanPostCodeElement.SendKeys("1245");
            }

        }

        public void EnterGermanStadtName()
        {
            GermanStadtElement.SendKeys("Bavaria");
        }

        public void EnterGermanAreaName()
        {
            GermanGeschäftsfeldElement.SendKeys("German Town");
        }

        public void EnterRegionNameForCustomer()
        {
            var regionName = "";
            
            if (IsGermanSystem())
            {
                regionName = "Hamburg";

            } else if (IsAustriaSystem())
            {
                regionName =  "Salzburg";
            }
            else if (IsSpainSystem())
            {
                regionName = "Barcelona";

            }
            else if (IsUKSystem())
            {
                regionName = "Manchester";

            }
            else if (IsItalySystem())
            {
                regionName = "Alessandria";
            }
            else if (IsFranceSystem())
            {
                regionName = "Paris";
            }
            else if (IsIrelandSystem())
            {
                regionName = "DUBLIN";
            }
            else if (IsSwedenSystem())
            {
                regionName = "";
            }
            else if (IsBelgiumSystem())
            {
                regionName = BelgianRegionaLanguage();
            }

            if (String.IsNullOrWhiteSpace(regionName)) return;
                SelectFromDropdown(GermanBundeslandElement, regionName);
             
        }


        private String BelgianRegionaLanguage()
        {
            string lang;
            string language;

            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "French";
            }

            switch (language)
            {
                case "French":
                    lang = "Région wallonne";
                    break;
                case "Dutch":
                    lang = "Brussels Gewest";
                    break;

                default:
                    lang = "Région wallonne";
                    break;
            }

            return lang;
        }

        public void EnterGermanKostenstelleName()
        {
            GermanKostenstelleElement.SendKeys("Marketing");
        }

        public void SelectGermanRechtsformName()
        {
            SelectFromDropdown(GermanRechtsformElement, "Gewerbebetrieb");
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void EnterCompanyRegistrationNumber()
        {
            GermanHandelsregisternummerElement.SendKeys("DE12345678");
        }

        public void EnterCompanyVATNumber()
        {
            if (IsGermanSystem())
            {
                GermanUstIDNrElement.SendKeys("DE113298780");
            }
            else if (IsAustriaSystem())
            {
                GermanUstIDNrElement.SendKeys("ATU13585627");
            }
            

        }

        public void EnterCreditReformNumber()
        {
            GermanCreditreformNummerElement.SendKeys(MpsUtil.CreditReformNumber());
        }

        public void EnterAuthorizedSignatory()
        {
            GermanZeichnungsberechtigterElement.SendKeys("German Signatory");
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
            var email = MpsUtil.GenerateUniqueEmail();
            SpecFlow.SetContext("DealerLatestCreatedCustomerEmail", email);
            EmailElement.SendKeys(email);
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

        

        public void EnterCompanyName()
        {
            if (CompanyNameElement.Displayed)
            CompanyNameElement.SendKeys(MpsUtil.CompanyName());
        }

        public void EnterPropertyNumber()
        {
            if (PropertyNumberElement.Displayed)
            PropertyNumberElement.SendKeys(MpsUtil.PropertyNumber());
        }

        public void EnterPropertyStreet()
        {
            if (PropertyStreetElement.Displayed)
            PropertyStreetElement.SendKeys(MpsUtil.PropertyStreet());
        }

        public void EnterPropertyArea()
        {
            if (PropertyAreaElement.Displayed)
            PropertyAreaElement.SendKeys(MpsUtil.FirstName());
        }

        public void EnterPropertyTown()
        {
            if (PropertyTownElement.Displayed)
            PropertyTownElement.SendKeys(MpsUtil.PropertyTown());
        }

        public void EnterPropertyPostCode()
        {
            if (PropertyPostcodeElement.Displayed)
            PropertyPostcodeElement.SendKeys(MpsUtil.PostCode());
        }

        public void SelectRegionFromDropdown(string region)
        {
            SelectFromDropdown(RegionElement, region);
        }

        public void SelectTitleFromDropdown()
        {
            if (IsSwedenSystem() || IsDenmarkSystem() || IsFinlandSystem() || IsNorwaySystem() || IsPolandSystem()) return;
            if (ContactTitleElement.Displayed)
                //SelectFromDropdownByValue(ContactTitleElement, MpsUtil.ContactTitle());
                //SelectFromDropdownByValue(ContactTitleElement, "0002");
                SelectFromDropDownByIndex(ContactTitleElement, 2);
        }


        public DealerConvertProposalTermAndType ProceedToConvertProposalTermAndType()
        {
            //NextElement.Click();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, NextElement);
            return GetInstance<DealerConvertProposalTermAndType>(Driver);
        }
        
    }
}
