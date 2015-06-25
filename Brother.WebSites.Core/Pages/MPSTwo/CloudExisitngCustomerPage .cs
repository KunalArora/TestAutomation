using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.ViewModels;
using Brother.WebSites.Core.ViewModels.MPSTwo;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CloudExisitngCustomerPage : BasePage
    {
        public static string URL = "/mps/dealer/customers/existing";

        public const string DealerLatestCreatedOrganization = "DealerLatestCreatedOrganization";
        public const string DealerLatestCreatedContact = "DealerLatestCreatedContact";
        public const string DealerLatestCreatedBank = "DealerLatestCreatedBank";

        private const string CustomerItemsSelecterFormat = "div.js-mps-customer-list-container tr.js-mps-delete-remove";

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

        public CloudManageCustomerPage ClickCreateCustomerPage()
        {
            createCustomerButtonElement.Click();
            return GetInstance<CloudManageCustomerPage>();
        }

        public void ConfirmCreatedCustomer(IWebDriver driver)
        {
            var json1 = SpecFlow.GetContext(DealerLatestCreatedContact);
            var contact = ModelUtils.JsonDeserialize<OrganisationContactDetail>(json1);

            var json2 = SpecFlow.GetContext(DealerLatestCreatedOrganization);
            var org = ModelUtils.JsonDeserialize<OrganisationDetail>(json2);

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
    }
}
