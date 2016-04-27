using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerConvertProposalCustomerInfo : BasePage
    {
        public static string Url = "/";

        private const string germanUrl = @"online.de";
        private const string austriaUrl = @"online.at";
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
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonCanOrderConsumables_Label")]
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
            else if (IsFranceSystem())
            {
                SelectFromDropdown(LegalFormDropdown, "Administration"); 
            }
                
            WebDriver.Wait(DurationType.Second, 3);
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
                
        }

        public void EnterAuthoriisedSignatoryNumber()
        {
            ClearAndType(AuthorizedSignatoryElement, "Mensha Uston");
        }


        private string TradingStyle()
        {
            var trading = "";

            if (IsUKSystem() || IsFranceSystem())
            {
                trading = "Non-Regulated";
            } else if (IsItalySystem())
            {
                trading = "Non regolamentato";
            }
            else if (IsSpainSystem())
            {
                trading = "No Regulado";
            }

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

            if (IsGermanSystem() || IsAustriaSystem())
            {
                SelectFromDropdown(PaymentTypeDropdown, "Bankeinzug");

            }
            else if (IsUKSystem())
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
            
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void EnterBankName()
        {
            ClearAndType(BankNameElement, "BNP Paribus");
        }

        public void EnterBankAccountNumber()
        {
            ClearAndType(BankAccountNumberElement, "45789635");
        }

        public void EnterBankSortCode()
        {
            ClearAndType(BankSortCodeElement, "014215");
        }

        public void EnterIbanNumber()
        {
            if(!IsItalySystem())
            ClearAndType(IBANElement, "GB15MIDL40051512345678");
        }

        public void EnterBicNumber()
        {
            if (!IsItalySystem())
            ClearAndType(BICElement, "MIDLGB22");
        }

        public void EnterBankPropertyNumber()
        {
            if (IsUKSystem())
                 ClearAndType(BankPropertyNumberElement, "12345");
        }

        public void EnterBankPropertyStreet()
        {
            if (!(IsGermanSystem() || IsAustriaSystem()))
                 ClearAndType(BankPropertyStreetElement, "Lloyds House");
        }

        public void EnterBankPropertyTown()
        {
            if (!(IsGermanSystem()|| IsAustriaSystem()))
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
            else if (IsSpainSystem())
            {
                ClearAndType(BankPropertyPostcodeElement, MpsUtil.PostCodeSp());
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
            SelectALegalForm();
            EnterCompanyRegistration();
            EnterVatNumber();
            SelectATradingStyle();
            EnterAuthoriisedSignatoryNumber();
            EnterRegionNameForCustomer();
        }

        public void EnterPrivateLiableCustomerInfo(string company)
        {
                SelectAPrivatelyLiableCustomer(company);
                EnterCompanyRegistration();
                EnterVatNumber();
                SelectATradingStyle();
                EnterAuthoriisedSignatoryNumber();
            
        }

        public void EnterAllBankInformation()
        {
            SelectAPaymentType();
            EnterBankName();
            EnterBankAccountNumber();
            EnterBankSortCode();
            EnterIbanNumber();
            EnterBicNumber();
            EnterBankPropertyNumber();
            EnterBankPropertyStreet();
            EnterBankPropertyTown();
            EnterBankPropertyPostcode();
        }

        private void SelectPrivateLiableTitle()
        {
            SelectFromDropdown(PrivateLiableTitleElement, "Mrs");
        }

        private void EnterPrivateLiableFirstName()
        {
            ClearAndType(PrivateLiableFirstNameElement, "Private");
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
            EnterCompanyName();
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

        public void EnterGermanStreetName()
        {
            StraßeElement.SendKeys("Friedrichstraße");
        }

        public void EnterGermanStreetNumber()
        {
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

            SelectFromDropdown(GermanBundeslandElement, regionName);
             
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
            if (ContactTitleElement.Displayed)
                //SelectFromDropdownByValue(ContactTitleElement, MpsUtil.ContactTitle());
                SelectFromDropdownByValue(ContactTitleElement, "0002");
        }


        public DealerConvertProposalTermAndType ProceedToConvertProposalTermAndType()
        {
            //NextElement.Click();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, NextElement);
            return GetInstance<DealerConvertProposalTermAndType>(Driver);
        }
        
    }
}
