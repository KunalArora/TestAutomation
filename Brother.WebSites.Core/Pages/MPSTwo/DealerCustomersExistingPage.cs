using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerCustomersExistingPage : BasePage, IPageObject
    {
        public static string URL = "/mps/dealer/customers/existing";
        private const string _validationElementSelector = "div.mps-dataTables-footer";

        public const string DealerLatestCreatedOrganization = "DealerLatestCreatedOrganization";
        public const string DealerLatestCreatedContact = "DealerLatestCreatedContact";
        public const string DealerLatestCreatedBank = "DealerLatestCreatedBank";
        private const string DealerLatestOperatingCustomerItemId = "DealerLatestOperatingCustomerItemId";
        private const string ActionsButton = @".js-mps-filter-ignore .dropdown-toggle";
        private const string CustomerItemsSelecterFormat = "div.js-mps-customer-list-container tr.js-mps-delete-remove";
        private const string CustomerNthItemSelecterFormat = "div.js-mps-customer-list-container tr.js-mps-delete-remove:nth-child({0})";
        private const string CreateCustomerButtonSelector = "input[type=\"submit\"]#content_1_CustomerViewActions_ActionList_Button_0";

        [FindsBy(How = How.CssSelector, Using = "div.js-mps-customer-list-container>table")]
        public IWebElement customerListContainerElement;

        [FindsBy(How = How.CssSelector, Using = "input[type=\"submit\"]#content_1_CustomerViewActions_ActionList_Button_0")]
        public IWebElement createCustomerButtonElement;

        [FindsBy(How = How.Id, Using = "content_1_PersonListFilter_InputFilterBy")]
        public IWebElement PersonListFilter;

        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_PersonList_List_Organisation_]")]
        public IList<IWebElement> PersonListNameRowElement;

        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_PersonList_List_CustomerEmail_]")]
        public IList<IWebElement> PersonListEmailRowElement;

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return URL;
            }
        }

        public void FindExistingCustomerList()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsNotNull(customerListContainerElement,
                "Existing customer table is not found.");
        }

        public void FindCreateCustomerButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsNotNull(createCustomerButtonElement,
                "Create Customer Button is not found.");
        }


        public DealerCustomersManagePage ClickCreateCustomerPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            var _createCustomerElement = SeleniumHelper.FindElementByCssSelector(CreateCustomerButtonSelector, 10);
            _createCustomerElement.Click();
            
            return GetInstance<DealerCustomersManagePage>();
        }

        public void ConfirmCreatedCustomer()
        {
            LoggingService.WriteLogOnMethodEntry();
            var contact = SpecFlow.GetObject<DealerCustomersManagePage.OrganisationContactDetail>(DealerLatestCreatedContact);

            var org = SpecFlow.GetObject<DealerCustomersManagePage.OrganisationDetail>(DealerLatestCreatedOrganization);

            var email = contact.Email;

            var customerelem = FindExistingCustomerByEmail();

            TestCheck.AssertIsNotNull(customerelem, "Created Customer is not found");
            var orgname = customerelem.FindElement(By.CssSelector("td:nth-child(1)")).Text;
            TestCheck.AssertIsEqual(org.Name, orgname, "Created customer org name is not same");
        }

        private IWebElement CreatedCreated()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdEmail = String.Format("//td[text()=\"{0}\"]", SavedEmailAddress());

            return Driver.FindElement(By.XPath(createdEmail));
        }

        private IWebElement FindExistingCustomerByEmail()
        {
            LoggingService.WriteLogOnMethodEntry();
            return CreatedCreated();
        }

        private IWebElement FindNthProposalOfferElement(IWebDriver driver, int nth = 1)
        {
            LoggingService.WriteLogOnMethodEntry();
            var format = string.Format(CustomerNthItemSelecterFormat, nth);
            return driver.FindElement(By.CssSelector(format));
        }


        public void ClickAcceptOnConfrimation()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Millisecond, 3000);
            //AcceptAlert();
            ClickAcceptOnJsAlert();
            HeadlessDismissAlertOk();
            
        }

        public void ClickDismissOnConfrimation(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Millisecond, 100);
            ClickDismissOnJsAlert();
            HeadlessDismissAlertCancel();
            
        }

        private string SavedEmailAddress()
        {
            LoggingService.WriteLogOnMethodEntry();
            return SpecFlow.GetContext("GeneratedEmailAddress");
        }

        private void ClickActionButtonOnOffer()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificCustomerActions(Driver);
        }

        private bool ContainsItemById(ISearchContext driver, string id)
        {
            LoggingService.WriteLogOnMethodEntry(driver,id);
            return
                driver.FindElements(By.CssSelector(".js-mps-delete"))
                .Select(x => x.GetAttribute("data-person-id"))
                .Contains(id);
        }

        public void ClickOnDeleteOnActionItemAgainstNewlyCreated()
        {
            LoggingService.WriteLogOnMethodEntry();
            ClickDelete();
        }

        public void ClickOnDeleteOnActionItemAgainstNewlyCreatedProposalCustomer()
        {
            LoggingService.WriteLogOnMethodEntry();
            ClickDelete();
        }

        private void ClickDelete()
        {
            LoggingService.WriteLogOnMethodEntry();
            const string deleteButton = @".open .js-mps-delete";
            
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
           // var customerelem = FindExistingCustomerByEmail();
            ClickActionButtonOnOffer();
            WaitForElementToExistByCssSelector(deleteButton);
            var deleteElem = Driver.FindElement(By.CssSelector(deleteButton));
            var id = deleteElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);

            deleteElem.Click();
            WebDriver.Wait(DurationType.Second, 3);
            
            
        }

        public void ClickOnDeleteOnActionItem(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            HeadlessDismissAlertOk();
           // var customerelem = FindNthProposalOfferElement(driver);
            //ClickActionButtonOnOffer();
            ClickAcceptOnJsAlert();
            ActionsModule.OpenTheFirstActionButton(driver);
            WaitForElementToExistByCssSelector(".open .js-mps-delete");
            var deleteElem = Driver.FindElement(By.CssSelector(".open .js-mps-delete"));
            var id = deleteElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);
            try
            {
                deleteElem.Click();
                WebDriver.Wait(DurationType.Second, 5);
            }
            catch (UnhandledAlertException uae)
            {
                // do nothing;
            }

            
            
        }

        public void NotExistTheDeletedItem(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);

            var id = SpecFlow.GetContext(DealerLatestOperatingCustomerItemId);
            var exisitng = ContainsItemById(driver, id);

            WebDriver.Wait(DurationType.Second, 5);

            TestCheck.AssertIsEqual(false, exisitng,
                "Deleted Item still exists on table.");
        }

        public void CustomerIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.IsNewlyCreatedCustomerDisplayed(Driver);
        }

        public void IsCustomerDeleted()
        {
            LoggingService.WriteLogOnMethodEntry();
            var cust = GetElementsByCssSelector(".js-mps-filter-ignore", 10).Count == 0;

            TestCheck.AssertIsEqual(true, cust, "Customer is not deleted");

        }

        public void IsEditedCustomerCreated()
        {
            LoggingService.WriteLogOnMethodEntry();
            CustomerIsDisplayed();

        }

        public void ExistsNotDeletedItem(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry();
            CustomerIsDisplayed();
        }

        public DealerCustomersManagePage ClickOnEditOnActionItemAgainstNewlyCreated()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificCustomerActions(Driver);
            var editElem = Driver.FindElement(By.CssSelector(".open .js-mps-edit"));
            var id = editElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);
            editElem.Click();
            return GetInstance<DealerCustomersManagePage>();
        }

        public DealerCustomersManagePage ClickOnEditOnActionItemAgainstNewlyEditedCustomer()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificCustomerActions(Driver);
            var editElem = Driver.FindElement(By.CssSelector(".open .js-mps-edit"));
            editElem.Click();
            return GetInstance<DealerCustomersManagePage>();
        }

        public bool VerifyItemByName(string customerInformationName, string customerEmail, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry();
            ClearAndType(PersonListFilter, customerEmail);
            try
            {
                SeleniumHelper.WaitUntil(d => PersonListNameRowElement.First(element => element.Text == customerInformationName), timeout);
                SeleniumHelper.WaitUntil(d => PersonListEmailRowElement.First(element => element.Text == customerEmail), timeout);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
