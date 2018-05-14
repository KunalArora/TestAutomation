using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateCustomerInformationPage : BasePage, IPageObject
    {
        public static string URL = "/mps/dealer/proposals/create/customer-information";
        private const string _validationElementSelector = "#content_1_ButtonNext"; //initial load to select new, existing or skip
        private const string _url = "/mps/dealer/proposals/create/customer-information";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }


        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string ColourElement = @"#ClickPriceColourCoverage";
        private const string CustomerContainer = @"#DataTables_Table_0";
        private const string CustomerString = "#DataTables_Table_0 tbody tr:first-child td:first-child";

        private const string NthCustomerChoice = @"input#content_1_PersonList_List_InputChoice_{0}";
        private const string NthCustomerOrg = @"#content_1_PersonList_List_Organisation_{0}";
        private const string NthCustomerName = @"#content_1_PersonList_List_CustomerName_{0}";
        private const string NthCustomerEmail = @"#content_1_PersonList_List_CustomerEmail_{0}";
        private const string CustomerSearchData = @"20151111";
        private const string NthChildRadioButtion = "[id*=\"content_1_PersonList_List_Choice\"]";
        private const string AcceptancePanel = @".js-mps-acceptance-panel";

        [FindsBy(How = How.CssSelector, Using = "input[id*=\"content_1_PersonList_List_InputChoice\"]")]
        public IList<IWebElement> ExistingContactRadioButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        public IWebElement CustomerInfomationElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputIsPrivatelyLiable_Input")]
        public IWebElement PrivateLiableElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;
        [FindsBy(How = How.Id, Using = "content_1_ButtonBack")]
        public IWebElement proposalProcessBackButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputCustomerChoiceNew")]
        public IWebElement CreateNewCustomerElement;
        [FindsBy(How = How.Id, Using = "content_1_InputCustomerChoiceExisting")]
        public IWebElement SelectExistingCustomerElement;
        [FindsBy(How = How.Id, Using = "content_1_InputCustomerChoiceSkip")]
        public IWebElement SkipCustomerElement;
        [FindsBy(How = How.Id, Using = "content_1_NewOrganisation")]
        public IWebElement NewOrganisationElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonFirstName_Input")]
        public IWebElement FirstNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonLastName_Input")]
        public IWebElement LastNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTelephone_Input")]
        public IWebElement TelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonEmail_Input")]
        public IWebElement EmailElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerName")]
        public IWebElement CompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputNumber_Input")]
        public IWebElement PropertyNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputStreet_Input")]
        public IWebElement PropertyStreetElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPropertyArea_Input")]
        public IWebElement PropertyAreaElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputTown_Input")]
        public IWebElement PropertyTownElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputPostCode_Input")]
        public IWebElement PropertyPostcodeElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputRegion_Input")]
        public IWebElement RegionElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTitle_Input")]
        public IWebElement ContactTitleElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonListFilter_InputFilterBy")]
        public IWebElement ExistingCustomerFilterElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerCompanyRegistrationNumber_Input")]
        public IWebElement CompanyRegistrationNumerElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerVatRegistrationNumber_Input")]
        public IWebElement VatFieldElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonCulture_Input")]
        public IWebElement CustomerMultipleLanguageElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerLegalForm_Input")]
        public IWebElement LegalFormDropdown;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonMobile_Input")]
        public IWebElement MobileElement;

        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_PersonList_List_InputChoice_]")]
        public IList<IWebElement> CustomerRadioButtonElement;
        
        
        public void SelectExistingCustomer(string customerEmail)
        {
            LoggingService.WriteLogOnMethodEntry(customerEmail);
            SelectAnExistingContact(customerEmail);
        }

        private void SelectAnExistingContact(string customerEmail)
        {
            LoggingService.WriteLogOnMethodEntry(customerEmail);
            var ContainerElement = SeleniumHelper.FindElementByCssSelector(CustomerContainer);
            SeleniumHelper.SetListFilter(ExistingCustomerFilterElement, customerEmail, CustomerRadioButtonElement);
            var CustomerRadioButton = SeleniumHelper.FindElementByCssSelector(ContainerElement, NthChildRadioButtion);
            SeleniumHelper.ClickSafety(CustomerRadioButton);

        }

        public void SelectARandomExistingContact()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectAnExistingCustomer();
            
        }

        public void SelectASpecificExistingContact(string contact)
        {
            LoggingService.WriteLogOnMethodEntry(contact);
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

        }


        private void SelectAnExistingCustomer()
        {
            LoggingService.WriteLogOnMethodEntry();
            WaitForElementToExistByCssSelector(CustomerContainer);
            try
                {
                    var customerChoice =
                    Driver.FindElements(By.CssSelector(NthChildRadioButtion));

                    var cust = customerChoice.Count <= 9 ? customerChoice.Count : 9;

                    var ranClick = new Random().Next(0, cust);

                    WaitForElementToExistByCssSelector(CustomerContainer);
           
                    customerChoice.ElementAt(ranClick).Click();
                }
                catch (StaleElementReferenceException stale)
                {
                    SelectAnExistingCustomer();
                    MsgOutput(String.Format("The element went stale with message {0}", stale));
                }
            
                
            
        }


        public void IsCustomerInfoTextDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsBigAtSystem()) return;
            if (CustomerInfomationElement == null) throw new 
                NullReferenceException("Unable to locate text on Customer Information Screen");

            AssertElementPresent(CustomerInfomationElement, "Customer information leading instruction");
        }


        public void CheckPrivateLiableBox(string liable)
        {
            LoggingService.WriteLogOnMethodEntry(liable);
            if (liable.ToLower().Equals("tick"))
            {
                PrivateLiableElement.Click();
            }
            
        }

        private void _ClickNextButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(NextButton);
            NextButton.Click();
        }

        public DealerProposalsCreateTermAndTypePage ClickNextButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            //WebDriver.Wait(Helper.DurationType.Second, 2);
            ScrollTo(NextButton);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, NextButton);
            //NextButton.Click();
            return GetTabInstance<DealerProposalsCreateTermAndTypePage>(Driver);
        }

       public void ClickBackButtonDuringProposalProcess()
       {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(proposalProcessBackButtonElement);
           proposalProcessBackButtonElement.Click();
       }

       public void ClickCreateNewCustomerButtonAndProceed()
       {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(CreateNewCustomerElement);
           CreateNewCustomerElement.Click();
           _ClickNextButton();
       }

       public void ClickSelectExistingCustomerButtonAndProceed()
       {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SelectExistingCustomerElement);
           SelectExistingCustomerElement.Click();
           _ClickNextButton();
       }

       public DealerProposalsCreateTermAndTypePage ClickSkipCustomerButtonAndProceed()
       {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SkipCustomerElement);
           SkipCustomerElement.Click();

           return ClickNextButton();
       }

       public void CustomerCreationOptions(string option)
       {
            LoggingService.WriteLogOnMethodEntry(option);
            switch (option)
           {
               case "Create new customer":
                   ClickCreateNewCustomerButtonAndProceed();
                   break;
               case "Selecting existing customer":
                   ClickSelectExistingCustomerButtonAndProceed();
                   break;
               case "Skip customer creation":
                   ClickSkipCustomerButtonAndProceed();
                   break;
               default:
                   throw new InvalidEnumArgumentException(String.Format("{0} is not a valid customer create option", option));
           }
       }

       public void ClickNewOrganisationButton()
       {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(NewOrganisationElement);
           NewOrganisationElement.Click();
       }

       public void SelectSwissCustomerLanguage(string lang)
       {
            LoggingService.WriteLogOnMethodEntry(lang);
            string language;

           switch (lang)
           {
               case "":
               case "Fran軋is":
                   language = "Fran軋is";
                   break;
               case "Deutsch":
                   language = "Deutsch";
                   break;
               default:
                   language = lang;
                   break;
           }


           SelectFromDropdown(CustomerMultipleLanguageElement, language);

       }

        public void SelectBelgianCustomerLanguage(string lang)
        {
            LoggingService.WriteLogOnMethodEntry(lang);
            string language;
            
            switch (lang)
            {
                case "" :
                case "French":
                    language = "Fran軋is";
                    break;
                case "Dutch":
                    language = "Nederlands";
                    break;
                default:
                    language = lang;
                    break;
            }


           SelectFromDropdown(CustomerMultipleLanguageElement, language);
          
        }

        public void MultipleLanguageSelectorNotDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsBelgiumSystem()) return;
            try
            {
                TestCheck.AssertIsEqual(false, GetElementByCssSelector(AcceptancePanel, 5).Displayed,
                    "Multiple Language Selector is displayed when it is not meant to");
            }
            catch (NullReferenceException wbe)
            {
                MsgOutput(String.Format("Element was not displayed as expected because the following error {0}", wbe.Message));
            }
        }

        public void FillOrganisationDetails()
       {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName();

            if (IsPolandSystem()) return;
            EnterPropertyNumber();
            EnterPropertyStreet();
            EnterRegistrationNumber();
            //EnterPropertyArea();
            EnterPropertyTown();
            EnterPropertyPostCode();
            EnterInitialVat();
            MultipleLanguageSelectorNotDisplayed();
            //SelectRegionFromDropdown("Greater Manchester");
            if (IsBelgiumSystem())
            {
                try
                {
                    var language = SpecFlow.GetContext("BelgianLanguage");
                    SelectBelgianCustomerLanguage(language);
                }
                catch (KeyNotFoundException keyNotFound)
                {
                   //Do nothing
                }

                
            }

            if (IsSwissSystem())
            {
                try
                {
                    var language = SpecFlow.GetContext("BelgianLanguage");
                    SelectSwissCustomerLanguage(language);
                }
                catch (KeyNotFoundException)
                {
                    //Do nothing
                }
            }
       }

        private void EnterMobileNumber()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsDenmarkSystem() || IsFinlandSystem() || IsNorwaySystem() || IsSwedenSystem())
            {
                MobileElement.SendKeys("01234567890");
            }
            
        }

        public void EnterRegistrationNumber()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsFranceSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "RCS PARIS 453 983 245");
            }
            else if (IsUKSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "06488522");
            }
            else if (IsIrelandSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "159555");
            }
            else if (IsPolandSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "8522470967");
            }
            else if (IsNetherlandSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "66019702");
            }
            else if (IsSwedenSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "556026-6883");
            }
            else if (IsBelgiumSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "47706706");
            }
            else if (IsDenmarkSystem())
            {
              //  ClearAndType(CompanyRegistrationNumerElement, "35679626");
            }
            else if (IsNorwaySystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "913992415");
            }
            //else if (IsSwissSystem())
            //{
            //    ClearAndType(CompanyRegistrationNumerElement, "CHE-106.568.179");
            //}
            //else if (IsFinlandSystem())
            //{
            //    ClearAndType(CompanyRegistrationNumerElement, "0572355-8");
            //}
        }

        public void EnterInitialVat()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsItalySystem())
            {
                ClearAndType(VatFieldElement, "IT00743110157");
            }
            else if (IsFranceSystem())
            {
                ClearAndType(VatFieldElement, "FR40303265045");
            } 
            else if (IsUKSystem())
            {
                ClearAndType(VatFieldElement, "GB980780684");
            }
            else if (IsSpainSystem())
            {
                ClearAndType(VatFieldElement, "ES54362315K");
            }
            else if (IsIrelandSystem())
            {
                ClearAndType(VatFieldElement, "IE6433435F");
            }
            else if (IsBelgiumSystem())
            {
                ClearAndType(VatFieldElement, "BE0428759497");
            }
            else if (IsPolandSystem())
            {
                ClearAndType(VatFieldElement, "PL8567346215");
            }
            else if (IsNetherlandSystem())
            {
                ClearAndType(VatFieldElement, "NL004495445B01");
            }
            else if (IsSwissSystem())
            {
                ClearAndType(VatFieldElement, "CHE-106.568.179 MWST");
            }
            else if (IsFinlandSystem())
            {
                ClearAndType(VatFieldElement, "FI20774740");
            }
            else if (IsDenmarkSystem())
            {
                ClearAndType(VatFieldElement, "DK13585628");
            }
            //else if (IsNorwaySystem())
            //{
            //    ClearAndType(VatFieldElement, "NO980395898");
            //}
        }

       public void EnterContactFirstName()
       {
            LoggingService.WriteLogOnMethodEntry();
            FirstNameElement.SendKeys(MpsUtil.FirstName());
       }

       public void EnterContactSurName()
       {
            LoggingService.WriteLogOnMethodEntry();
            LastNameElement.SendKeys(MpsUtil.SurName());
       }

       public void EnterContactTelephone()
       {
            LoggingService.WriteLogOnMethodEntry();
            TelephoneElement.SendKeys(MpsUtil.CompanyTelephone());
       }

       public void EnterContactEmailAdress()
       {
            LoggingService.WriteLogOnMethodEntry();
            var email = MpsUtil.GenerateUniqueEmail();
           SpecFlow.SetContext("DealerLatestCreatedCustomerEmail", email);
           EmailElement.SendKeys(email);
       }

       public void FillOrganisationContactDetail(string language = null)
       {
            LoggingService.WriteLogOnMethodEntry();
            if (IsPolandSystem()) return;
           SelectTitleFromDropdown();
           EnterContactFirstName();
           EnterContactSurName();
           EnterContactTelephone();
           EnterContactEmailAdress();
           SelectALegalForm(language);
           EnterMobileNumber();
       }

       private String SwissLegalForm(string language)
       {
           LoggingService.WriteLogOnMethodEntry();
           string lang;

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


       public void SelectALegalForm(string language)
       {
            LoggingService.WriteLogOnMethodEntry();
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
           else if (IsPolandSystem())
           {
               SelectFromDropdown(LegalFormDropdown, "Church");
           }
           else if (IsFinlandSystem())
           {
               SelectFromDropdown(LegalFormDropdown, "Oyj");
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
               var legalForm = SwissLegalForm(language);
               SelectFromDropdown(LegalFormDropdown, legalForm);
           }
           else if (IsBelgiumSystem())
           {
               language = BelgianLegalForm();
               SelectFromDropdown(LegalFormDropdown, language);
           }
           //else if (IsSwedenSystem())
           //{
           //    SelectFromDropdown(LegalFormDropdown, "Aktiebolag");
           //}

           WebDriver.Wait(DurationType.Second, 3);
       }


       private String BelgianLegalForm()
       {
            LoggingService.WriteLogOnMethodEntry();
            string lang;
           string language;

           try
           {
               language = SpecFlow.GetContext("BelgianLanguage");
           }
           catch (KeyNotFoundException keyNotFound)
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

      
        public void EnterCompanyName()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CompanyNameElement == null) return;
            CompanyNameElement.SendKeys(MpsUtil.CompanyName());
        }

        public void EnterPropertyNumber()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (
                IsFranceSystem()
                ||IsSpainSystem()
                ||IsItalySystem()
                || IsDenmarkSystem()
                ||IsFinlandSystem() 
                || IsSwedenSystem()
                || IsBelgiumSystem()
                || IsNetherlandSystem()
                || IsSwissSystem()
                || IsNorwaySystem()
                || IsIrelandSystem()
                                        ) return;
            PropertyNumberElement.SendKeys(MpsUtil.PropertyNumber());
        }

        public void EnterPropertyStreet()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PropertyStreetElement == null) return;
            PropertyStreetElement.SendKeys(MpsUtil.PropertyStreet());
        }

        

        public void EnterPropertyArea()
        {
            LoggingService.WriteLogOnMethodEntry();
            PropertyAreaElement.SendKeys(MpsUtil.FirstName());
        }

        public void EnterPropertyTown()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PropertyTownElement == null) return;
                PropertyTownElement.SendKeys(MpsUtil.PropertyTown());
        }


        private string PostCode()
        {
            LoggingService.WriteLogOnMethodEntry();
            string code = null;

            if (IsGermanSystem())
            {
                code = MpsUtil.PostCode();

            } else if (IsFranceSystem())
            {
                code = MpsUtil.PostCodeFr();

            }else if (IsUKSystem())
            {
                code = MpsUtil.PostCodeGb();

            } else if (IsItalySystem())
            {
                code = MpsUtil.PostCodeIt();

            } else if (IsSpainSystem())
            {
                code = MpsUtil.PostCodeSp();

            }
            else if (IsIrelandSystem())
            {
                code = MpsUtil.PostCodeIr();

            }
            else if (IsPolandSystem())
            {
                code = MpsUtil.PostCodePl();

            }
            else if (IsNetherlandSystem())
            {
                code = MpsUtil.PostCodeNl();

            }
            else if (IsSwedenSystem())
            {
                code = MpsUtil.PostCodeNs();

            }
            else if (IsBelgiumSystem())
            {
                code = MpsUtil.PostCodeBe();
            }
            else if (IsSwissSystem())
            {
                code = MpsUtil.PostCodeSw();
            }
            else if (IsFinlandSystem())
            {
                code = MpsUtil.PostCodeFi();

            }
            else if (IsDenmarkSystem())
            {
                code = MpsUtil.PostCodeDk();
            }
            else if (IsNorwaySystem())
            {
                code = MpsUtil.PostCodeNo();
            }


            return code;
        }


        public void EnterPropertyPostCode()
        {
            LoggingService.WriteLogOnMethodEntry();
            PropertyPostcodeElement.SendKeys(PostCode());
        }

        public void SelectRegionFromDropdown(string region)
        {
            LoggingService.WriteLogOnMethodEntry(region);
            SelectFromDropdown(RegionElement, region);
        }

        public void SelectTitleFromDropdown()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsSwedenSystem()||IsDenmarkSystem() || IsFinlandSystem() || IsNorwaySystem()) return;
                //SelectFromDropdownByValue(ContactTitleElement, "0002");
                SelectFromDropDownByIndex(ContactTitleElement, 2);
        }



        public void EditProposalCustomerInformation(IWebDriver driver, int nth = 0)
        {
            LoggingService.WriteLogOnMethodEntry(driver,nth);
            var choiceselector = string.Format(NthCustomerChoice, nth);
            var orgselector = string.Format(NthCustomerOrg, nth);
            var nameselector = string.Format(NthCustomerName, nth);
            var emailselector = string.Format(NthCustomerEmail, nth);

            driver.FindElement(By.CssSelector(choiceselector)).Click();

            var org = driver.FindElement(By.CssSelector(orgselector)).Text;
            SpecFlow.SetContext("DealerLatestEditedCustomerOrg", org);

            var name = driver.FindElement(By.CssSelector(nameselector)).Text;
            SpecFlow.SetContext("DealerLatestEditedCustomerName", name);

            var email = driver.FindElement(By.CssSelector(emailselector)).Text;
            SpecFlow.SetContext("DealerLatestEditedCustomerEmail", email);
        }

        private string GetFieldValue(IWebElement element)
        {
            LoggingService.WriteLogOnMethodEntry(element);
            return element.GetAttribute("value");
        }

        public string GetCompanyName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(CompanyNameElement);
        }

        public string GetEmail()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(EmailElement);
        }

        public string GetFirstName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(FirstNameElement);
        }

        public string GetLastName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(LastNameElement);
        }

    }
}
