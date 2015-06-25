using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
        private IWebElement customerListContainerElement;

        [FindsBy(How = How.CssSelector, Using = "input[type=\"submit\"]#content_1_CustomerListActions_ActionList_Button_0")]
        private IWebElement createCustomerButtonElement;

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

        public DealerCustomersMangePage ClickCreateCustomerPage()
        {
            createCustomerButtonElement.Click();
            return GetInstance<DealerCustomersMangePage>();
        }

        public void ConfirmCreatedCustomer(IWebDriver driver)
        {
            var contact = SpecFlow.GetObject<DealerCustomersMangePage.OrganisationContactDetail>(DealerLatestCreatedContact);

            var org = SpecFlow.GetObject<DealerCustomersMangePage.OrganisationDetail>(DealerLatestCreatedOrganization);

            var email = contact.Email;

            var customerelem = FindExistingCustomerByEmail(driver, email);

            TestCheck.AssertIsNotNull(customerelem, "Created Customer is not found");
            var orgname = customerelem.FindElement(By.CssSelector("td:nth-child(1)")).Text;
            TestCheck.AssertIsEqual(org.Name, orgname, "Created customer org name is not same");
        }

        private IWebElement FindExistingCustomerByEmail(IWebDriver driver, string email)
        {
            return
                driver.FindElements(By.CssSelector(CustomerItemsSelecterFormat))
                .FirstOrDefault(x => x.FindElement(By.CssSelector("td:nth-child(3)")).Text == email);
        }

        private IWebElement FindNthProposalOfferElement(IWebDriver driver, int nth = 1)
        {
            var format = string.Format(CustomerNthItemSelecterFormat, nth);
            return driver.FindElement(By.CssSelector(format));
        }


        public void ClickAcceptOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 100);
            ActionsModule.ClickAcceptOnJsAlert(driver);
        }

        public void ClickDismissOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 100);
            ActionsModule.ClickDismissOnJsAlert(driver);
        }

        private void ClickActionButtonOnOffer(IWebElement offerElement)
        {
            var actionitem = offerElement.FindElement(By.CssSelector(actionsButton));
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
            var json1 = SpecFlow.GetContext(DealerLatestCreatedContact);
            var contact = ModelUtils.JsonDeserialize<OrganisationContactDetail>(json1);

            var customerelem = FindExistingCustomerByEmail(driver, contact.Email);
            ClickActionButtonOnOffer(customerelem);
            var deleteElem = customerelem.FindElement(By.CssSelector(".js-mps-delete"));
            var id = deleteElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);
            deleteElem.Click();
        }

        public void ClickOnDeleteOnActionItem(IWebDriver driver)
        {
            var customerelem = FindNthProposalOfferElement(driver);
            ClickActionButtonOnOffer(customerelem);
            var deleteElem = customerelem.FindElement(By.CssSelector(".js-mps-delete"));
            var id = deleteElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);
            deleteElem.Click();
        }

        public void NotExistTheDeletedItem(IWebDriver driver)
        {
            var id = SpecFlow.GetContext(DealerLatestOperatingCustomerItemId);
            var exisitng = ContainsItemById(driver, id);

            TestCheck.AssertIsEqual(false, exisitng,
                "Deleted Item still exists on table.");
        }

        public void ExistsNotDeletedItem(IWebDriver driver)
        {
            var id = SpecFlow.GetContext(DealerLatestOperatingCustomerItemId);
            var exisitng = ContainsItemById(driver, id);

            TestCheck.AssertIsEqual(true, exisitng,
                "Cancelled Item does not exist on table.");
        }

        public CloudManageCustomerPage ClickOnEditOnActionItemAgainstNewlyCreated(IWebDriver driver)
        {
            var json1 = SpecFlow.GetContext(DealerLatestCreatedContact);
            var contact = ModelUtils.JsonDeserialize<OrganisationContactDetail>(json1);

            var customerelem = FindExistingCustomerByEmail(driver, contact.Email);
            ClickActionButtonOnOffer(customerelem);
            var editElem = customerelem.FindElement(By.CssSelector(".js-mps-edit"));
            var id = editElem.GetAttribute("data-person-id");
            SpecFlow.SetContext(DealerLatestOperatingCustomerItemId, id);
            editElem.Click();
            return GetInstance<CloudManageCustomerPage>();
        }
    }
}
