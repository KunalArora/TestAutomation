using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerCustomersExistingPage : BasePage
    {
        public static string URL = "/mps/dealer/customers/existing";

        public const string DealerLatestCreatedOrganization = "DealerLatestCreatedOrganization";
        public const string DealerLatestCreatedContact = "DealerLatestCreatedContact";
        public const string DealerLatestCreatedBank = "DealerLatestCreatedBank";
        private const string DealerLatestOperatingCustomerItemId = "DealerLatestOperatingCustomerItemId";
        private const string ActionsButton = @".js-mps-filter-ignore .dropdown-toggle";
        private const string CustomerItemsSelecterFormat = "div.js-mps-customer-list-container tr.js-mps-delete-remove";
        private const string CustomerNthItemSelecterFormat = "div.js-mps-customer-list-container tr.js-mps-delete-remove:nth-child({0})";

        [FindsBy(How = How.CssSelector, Using = "div.js-mps-customer-list-container>table")]
        public IWebElement customerListContainerElement;

        [FindsBy(How = How.CssSelector, Using = "input[type=\"submit\"]#content_1_CustomerListActions_ActionList_Button_0")]
        public IWebElement createCustomerButtonElement;

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        public void FindExistingCustomerList()
        {
            TestCheck.AssertIsNotNull(customerListContainerElement,
                "Existing customer table is not found.");
        }

        public void FindCreateCustomerButton()
        {
            TestCheck.AssertIsNotNull(createCustomerButtonElement,
                "Create Customer Button is not found.");
        }

        public DealerCustomersManagePage ClickCreateCustomerPage()
        {
            createCustomerButtonElement.Click();
            return GetInstance<DealerCustomersManagePage>();
        }

        public void ConfirmCreatedCustomer()
        {
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
            var createdEmail = String.Format("//td[text()=\"{0}\"]", SavedEmailAddress());

            return Driver.FindElement(By.XPath(createdEmail));
        }

        private IWebElement FindExistingCustomerByEmail()
        {
            return CreatedCreated();
        }

        private IWebElement FindNthProposalOfferElement(IWebDriver driver, int nth = 1)
        {
            var format = string.Format(CustomerNthItemSelecterFormat, nth);
            return driver.FindElement(By.CssSelector(format));
        }


        public void ClickAcceptOnConfrimation()
        {
            WebDriver.Wait(DurationType.Millisecond, 3000);
            //AcceptAlert();
            ClickAcceptOnJsAlert();
            HeadlessDismissAlertOk();
            
        }

        public void ClickDismissOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 100);
            ClickDismissOnJsAlert();
            HeadlessDismissAlertCancel();
            
        }

        private string SavedEmailAddress()
        {
            return SpecFlow.GetContext("GeneratedEmailAddress");
        }

        private void ClickActionButtonOnOffer()
        {
           ActionsModule.ClickOnSpecificCustomerActions(Driver);
        }

        private bool ContainsItemById(ISearchContext driver, string id)
        {
            return
                driver.FindElements(By.CssSelector(".js-mps-delete"))
                .Select(x => x.GetAttribute("data-person-id"))
                .Contains(id);
        }

        public void ClickOnDeleteOnActionItemAgainstNewlyCreated()
        {
            ClickDelete();
        }

        public void ClickOnDeleteOnActionItemAgainstNewlyCreatedProposalCustomer()
        {
           ClickDelete();
        }

        private void ClickDelete()
        {
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
            
            var id = SpecFlow.GetContext(DealerLatestOperatingCustomerItemId);
            var exisitng = ContainsItemById(driver, id);

            WebDriver.Wait(DurationType.Second, 5);

            TestCheck.AssertIsEqual(false, exisitng,
                "Deleted Item still exists on table.");
        }

        public void CustomerIsDisplayed()
        {
            ActionsModule.IsNewlyCreatedCustomerDisplayed(Driver);
        }

        public void IsCustomerDeleted()
        {
           var cust = GetElementsByCssSelector(".js-mps-filter-ignore", 10).Count == 0;

            TestCheck.AssertIsEqual(true, cust, "Customer is not deleted");

        }

        public void IsEditedCustomerCreated()
        {
            CustomerIsDisplayed();

        }

        public void ExistsNotDeletedItem(IWebDriver driver)
        {
            CustomerIsDisplayed();
        }

        public DealerCustomersManagePage ClickOnEditOnActionItemAgainstNewlyCreated()
        {
            ActionsModule.ClickOnSpecificCustomerActions(Driver);
            var editElem = Driver.FindElement(By.CssSelector(".open .js-mps-edit"));
            var id = editElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);
            editElem.Click();
            return GetInstance<DealerCustomersManagePage>();
        }

    }
}
