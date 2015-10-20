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

        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";
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
            //driver.FindElements(By.CssSelector(CustomerItemsSelecterFormat))
            //    .FirstOrDefault(x => x.FindElement(By.CssSelector("td:nth-child(3)")).Text == email);
        }

        private IWebElement FindNthProposalOfferElement(IWebDriver driver, int nth = 1)
        {
            var format = string.Format(CustomerNthItemSelecterFormat, nth);
            return driver.FindElement(By.CssSelector(format));
        }


        public void ClickAcceptOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 3000);
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert(driver);
            //AcceptAlert();
        }

        public void ClickDismissOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 100);
            HeadlessDismissAlertCancel();
            ClickDismissOnJsAlert(driver);
        }

        private string SavedEmailAddress()
        {
            return SpecFlow.GetContext("GeneratedEmailAddress");
        }

        private void ClickActionButtonOnOffer()
        {
           
            var actionString =
                                String.Format(
                                    "return $('td:contains(\"{0}\")').parent('tr').children('td').children('div').children('button')",
                                    SavedEmailAddress());

            var actionitem = FindElementByJs(actionString);
            actionitem.Click();
        }

        private bool ContainsItemById(IWebDriver driver, string id)
        {
            return
                driver.FindElements(By.CssSelector(".js-mps-delete"))
                .Select(x => x.GetAttribute("data-person-id"))
                .Contains(id);
        }

        public void ClickOnDeleteOnActionItemAgainstNewlyCreated(IWebDriver driver)
        {
            //var contact = SpecFlow.GetObject<DealerCustomersManagePage.OrganisationContactDetail>(DealerLatestCreatedContact);

            //ClickDelete(driver, contact.Email);

            ClickDelete();
        }

        public void ClickOnDeleteOnActionItemAgainstNewlyCreatedProposalCustomer(IWebDriver driver)
        {
            //var email = SpecFlow.GetContext("DealerLatestCreatedCustomerEmail");

            //ClickDelete(driver, email);]

            ClickDelete();
        }

        private void ClickDelete()
        {
            HeadlessDismissAlertOk();
           // var customerelem = FindExistingCustomerByEmail();
            ClickActionButtonOnOffer();
            WaitForElementToExistByCssSelector(".open .js-mps-delete");
            var deleteElem = Driver.FindElement(By.CssSelector(".open .js-mps-delete"));
            var id = deleteElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);
            deleteElem.Click();
            
        }

        public void ClickOnDeleteOnActionItem(IWebDriver driver)
        {
            HeadlessDismissAlertOk();
           // var customerelem = FindNthProposalOfferElement(driver);
            //ClickActionButtonOnOffer();
            ActionsModule.OpenTheFirstActionButton(driver);
            WaitForElementToExistByCssSelector(".open .js-mps-delete");
            var deleteElem = Driver.FindElement(By.CssSelector(".open .js-mps-delete"));
            var id = deleteElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);
            deleteElem.Click();
            WebDriver.Wait(DurationType.Second, 5);
            
        }

        public void NotExistTheDeletedItem(IWebDriver driver)
        {
            
            var id = SpecFlow.GetContext(DealerLatestOperatingCustomerItemId);
            var exisitng = ContainsItemById(driver, id);

            WebDriver.Wait(DurationType.Second, 5);

            TestCheck.AssertIsEqual(false, exisitng,
                "Deleted Item still exists on table.");
        }

        public void NotExistTheDeletedItem()
        {

            var email = SpecFlow.GetContext("GeneratedEmailAddress");
            var createdEmail = String.Format("//td[text()=\"{0}\"]", email);
            var deletedCustomer = Driver.FindElement(By.XPath(createdEmail));
            var isDeleted = deletedCustomer.Displayed;

            WebDriver.Wait(DurationType.Second, 5);

            TestCheck.AssertIsEqual(false, isDeleted,
                "Deleted Item still exists on table.");
        }

        public void CustomerIsDisplayed()
        {

            var email = SpecFlow.GetContext("GeneratedEmailAddress");
            var createdEmail = String.Format("//td[text()=\"{0}\"]", email);
            var deletedCustomer = Driver.FindElement(By.XPath(createdEmail));
            var isDeleted = deletedCustomer.Displayed;

            WebDriver.Wait(DurationType.Second, 5);

            TestCheck.AssertIsEqual(true, isDeleted,
                "Deleted Item still exists on table.");
        }

        public void IsCustomerDeleted()
        {
            var email = SpecFlow.GetContext("GeneratedEmailAddress");
            var customersEmail = Driver.FindElements(By.CssSelector(".js-mps-searchable  td[id*=content_1_PersonList_List_CustomerEmail]"));
            var customerEmailList = new ArrayList();

            foreach (var element in customersEmail)
            {
                var customerEmail = element.Text;
                customerEmailList.Add(customerEmail);
            }

            var message = String.Format("Deleted customer with email address {0} is still displayed", email);

            TestCheck.AssertIsEqual(false, customerEmailList.Contains(email), message);

        }

        public void IsEditedCustomerCreated()
        {
            //var email = SpecFlow.GetContext("GeneratedEmailAddress");
            //var customersEmail = Driver.FindElements(By.CssSelector(".js-mps-searchable  td[id*=content_1_PersonList_List_CustomerEmail]"));
            //var customerEmailList = new ArrayList();

            //foreach (var element in customersEmail)
            //{
            //    var customerEmail = element.Text;
            //    customerEmailList.Add(customerEmail);
            //}

            //var message = String.Format("Edited customer with email address {0} is displayed", email);

            //TestCheck.AssertIsEqual(true, customerEmailList.Contains(email), message);

            CustomerIsDisplayed();

        }

        public void ExistsNotDeletedItem(IWebDriver driver)
        {
            //var id = SpecFlow.GetContext(DealerLatestOperatingCustomerItemId);
            //var exisitng = ContainsItemById(driver, id);

            //TestCheck.AssertIsEqual(true, exisitng,
            //    "Cancelled Item does not exist on table.");

            CustomerIsDisplayed();
        }

        public DealerCustomersManagePage ClickOnEditOnActionItemAgainstNewlyCreated()
        {
            var contact = SpecFlow.GetObject<DealerCustomersManagePage.OrganisationContactDetail>(DealerLatestCreatedContact);

            var customerelem = FindExistingCustomerByEmail();
            ScrollTo(ActionsModule.SpecificCustomerActionsDropdownElement());
            ClickActionButtonOnOffer();
            var editElem = Driver.FindElement(By.CssSelector(".open .js-mps-edit"));
            var id = editElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);
            editElem.Click();
            return GetInstance<DealerCustomersManagePage>();
        }

    }
}
