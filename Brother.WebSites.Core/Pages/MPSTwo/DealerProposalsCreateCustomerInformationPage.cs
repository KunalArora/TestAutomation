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
    public class DealerProposalsCreateCustomerInformationPage : BasePage
    {
        public static string URL = "/mps/dealer/proposals/create/customer-information";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string colourElement = @"#ClickPriceColourCoverage";

        private const string nthCustomerChoice = @"input#content_1_PersonList_List_InputChoice_{0}";
        private const string nthCustomerOrg = @"#content_1_PersonList_List_Organisation_{0}";
        private const string nthCustomerName = @"#content_1_PersonList_List_CustomerName_{0}";
        private const string nthCustomerEmail = @"#content_1_PersonList_List_CustomerEmail_{0}";
        private const string CustomerSearchData = @"20151111";

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
        

        public void SelectARandomExistingContact()
        {
           SelectAnExistingCustomer();
            
        }


        private void SelectAnExistingCustomer()
        {
            var ranClick = new Random().Next(0, 20);
            var customerString = String.Format(nthCustomerChoice, ranClick);

            var customerChoice = Driver.FindElement(By.CssSelector(customerString));
            customerChoice.Click();
        }


        public void SearchForACustomer()
        {
            if(ExistingCustomerFilterElement == null)
                throw new Exception("Filter for existing customer during proposal creation is missing");
            ExistingCustomerFilterElement.SendKeys(CustomerSearchData);
            ExistingCustomerFilterElement.SendKeys(Keys.Tab);
            WebDriver.Wait(DurationType.Second, 3);
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

        private void _ClickNextButton()
        {
            ScrollTo(NextButton);
            NextButton.Click();
        }

        public DealerProposalsCreateTermAndTypePage ClickNextButton()
        {
            //WebDriver.Wait(Helper.DurationType.Second, 2);
            ScrollTo(NextButton);
            NextButton.Click();
            return GetTabInstance<DealerProposalsCreateTermAndTypePage>(Driver);
        }

       public void ClickBackButtonDuringProposalProcess()
       {
           ScrollTo(proposalProcessBackButtonElement);
           proposalProcessBackButtonElement.Click();
       }

       public void ClickCreateNewCustomerButtonAndProceed()
       {
           ScrollTo(CreateNewCustomerElement);
           CreateNewCustomerElement.Click();
           _ClickNextButton();
       }

       public void ClickSelectExistingCustomerButtonAndProceed()
       {
           ScrollTo(SelectExistingCustomerElement);
           SelectExistingCustomerElement.Click();
           _ClickNextButton();
       }

       public DealerProposalsCreateTermAndTypePage ClickSkipCustomerButtonAndProceed()
       {
           ScrollTo(SkipCustomerElement);
           SkipCustomerElement.Click();

           return ClickNextButton();
       }

       public void CustomerCreationOptions(string option)
       {
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

       private IWebElement ColourClickPriceElement()
       {
           return GetElementByCssSelector(colourElement, 10);
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
            PropertyAreaElement.SendKeys(MpsUtil.FirstName());
        }

        public void EnterPropertyTown()
        {
            if (PropertyTownElement.Displayed)
                PropertyTownElement.SendKeys(MpsUtil.PropertyTown());
        }

        public void EnterPropertyPostCode()
        {
            PropertyPostcodeElement.SendKeys(!IsGermanSystem() ? MpsUtil.PostCodeGB() : MpsUtil.PostCode());
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



        public void EditProposalCustomerInformation(IWebDriver driver, int nth = 0)
        {
            var choiceselector = string.Format(nthCustomerChoice, nth);
            var orgselector = string.Format(nthCustomerOrg, nth);
            var nameselector = string.Format(nthCustomerName, nth);
            var emailselector = string.Format(nthCustomerEmail, nth);

            driver.FindElement(By.CssSelector(choiceselector)).Click();

            var org = driver.FindElement(By.CssSelector(orgselector)).Text;
            SpecFlow.SetContext("DealerLatestEditedCustomerOrg", org);

            var name = driver.FindElement(By.CssSelector(nameselector)).Text;
            SpecFlow.SetContext("DealerLatestEditedCustomerName", name);

            var email = driver.FindElement(By.CssSelector(emailselector)).Text;
            SpecFlow.SetContext("DealerLatestEditedCustomerEmail", email);
        }
    }
}
