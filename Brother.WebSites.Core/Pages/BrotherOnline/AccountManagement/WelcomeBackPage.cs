using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSOne;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.OmniJoin.Plans;
using Brother.WebSites.Core.Pages.OmniJoin.Trial;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class WelcomeBackPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["HomePage"].ToString(); }
        }

        //[FindsBy(How = How.CssSelector, Using = "a[href*='register-your-device']")]
        [FindsBy(How = How.CssSelector, Using = ".add-device")]
        public IWebElement RegisterDeviceLink;
        [FindsBy(How = How.CssSelector, Using = "#content_2_CurrentControlPanelItem_ConferenceButtons.two-conference-buttons .conference-button.right")]
        public IWebElement OmniJoinTryNowButton;
        [FindsBy(How = How.CssSelector, Using = "#content_2_CurrentControlPanelItem_ConferenceButtons.two-conference-buttons .conference-button.left")]
        public IWebElement OmniJoinBuyNowButton;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_2_ProductsTabRepeater_ProductLinkButton\"] p strong")]
        public IList<IWebElement> MpsPrintSmartButton;
        [FindsBy(How = How.CssSelector, Using = ".clearfix a[href*='customer-information']")]
        public IWebElement NewProposalButton;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/print-smart/my-proposals\"]")]
        public IWebElement ExistingProposalButton;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/print-smart/my-contracts\"]")]
        public IWebElement ExistingContractButton;
        [FindsBy(How = How.CssSelector, Using = "#TopNavigationControl_rptPrimaryLevelNav_aSectionLink_3")]
        public IWebElement MyAccountNavigationButton;
        [FindsBy(How = How.CssSelector, Using = "a.button-blue[href=\"/print-smart/my-services/consumables\"]")]
        public IWebElement ConsumableNavigationButton;
        [FindsBy(How = How.CssSelector, Using = "a.button-blue[href=\"/print-smart/my-services/service-request\"]")]
        public IWebElement TechnicalServicesNavigationButton;
        [FindsBy(How = How.CssSelector, Using = "a[href*=\"/dashboard\"].mps-link")] 
        public IWebElement CloudDealerDashboardButton;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office\"].mps-link")] 
        public IWebElement CloudLocalOfficeAdminDashboardButton;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bank\"].mps-link")]
        public IWebElement BankUserLandingPageButton;
        [FindsBy(How = How.CssSelector, Using = ".brother_ink_Sta_Sum div")]
        public IList<IWebElement> InkStatusSummaryListElement;
        [FindsBy(How = How.CssSelector, Using = ".brother_ink_Sta_Sum")]
        public IWebElement InkDevicePropertiesContainer;
        [FindsBy(How = How.CssSelector, Using = ".container-dp-header")]
        public IWebElement Containerheader;
        

        

        public void IsDealerDashboardDisplayed()
        {
            if (CloudDealerDashboardButton == null)
            {
                throw new Exception("Dealer Dashboard page not displayed");
            }
            AssertElementPresent(CloudDealerDashboardButton, "Dealer Dashboard");
        }

        public void IsLOAdminDashboardDisplayed()
        {
            if (CloudLocalOfficeAdminDashboardButton == null)
            {
                throw new Exception("LO Admin page not displayed");
            }
            AssertElementPresent(CloudLocalOfficeAdminDashboardButton, "Local Admin Dashboard");
        }

        public void IsBankLandingPageLinkDisplayed()
        {
            if (BankUserLandingPageButton == null)
            {
                throw new Exception("Bank dashboard page not displayed");
            }
            AssertElementPresent(BankUserLandingPageButton, "Bank landing page link");
        }


        public void IsInkDevicePropertiesContainerAvailable()
        {
            if (InkDevicePropertiesContainer == null)
            {
                throw new Exception("Unable to find ink device container on page");
            }
            AssertElementPresent(InkDevicePropertiesContainer, "Ink Device Container");
        }

        public void VerifyContainerheader(string title)
        {
            if (Containerheader == null)
            {
                throw new Exception("Unable to find Status Monitor section on page");
            }
            AssertElementPresent(Containerheader, "Header is present");
        }


        public void VerifyInkDeviceName(string device)
        {
            if (InkStatusSummaryListElement == null)
            {
                throw new Exception("Unable to find ink device container on page");
            }
            AssertElementText(InkStatusSummaryListElement.First(), device, "Ink Device Container");
        }

        public void IsRegisterDeviceLinkAvailable()
        {
            if (RegisterDeviceLink == null)
            {
                throw new Exception("Unable to locate link on page");
            }
            ScrollTo(RegisterDeviceLink);
            AssertElementPresent(RegisterDeviceLink, "Register Device Link");
        }

        // Clicks the Register Device link and proceeds to the RegisterYourDevice page
        public RegisterDevicePage ClickRegisterDeviceLink()
        {
            if (!WaitForElementToExistByCssSelector(".add-device"))
            {
                TestCheck.AssertFailTest("Unable to locate the Add Device button");
            }
            RegisterDeviceLink = Driver.FindElement(By.CssSelector(".add-device"));
            ScrollTo(RegisterDeviceLink);
            RegisterDeviceLink.Click();
            return GetInstance<RegisterDevicePage>(Driver);
        }
      public PlansHomePage OmniJoinBuyNowButtonClick()
        {
            OmniJoinBuyNowButton.Click();
            return GetInstance<PlansHomePage>(Driver);
        }

        public FreeTrialPage OmniJoinTryNowButtonClick()
        {
           OmniJoinTryNowButton.Click();
           return GetInstance<FreeTrialPage>(Driver);
        }

        public MyPersonalDetailsPage PersonalDetailsButtonClick(IWebElement button)
        {
            TestCheck.AssertIsNotNull(button, "Personal Details Button");
            button.Click();
            return GetInstance<MyPersonalDetailsPage>(Driver);
        }

        public void ClickOnManagedPrintServices(string navigation)
        {
            try
            {
                foreach (var button in MpsPrintSmartButton)
                {
                    var countryPrintSmart = button.Text.ToLower();

                    if (countryPrintSmart.Contains(navigation))
                    {
                        button.Click();
                        break;
                    }

                }
            
            }
            catch (NoSuchElementException noSuchElementException)
            { 
                throw new Exception(string.Format("MPS's navigational link is not displayed [{0}]", noSuchElementException.Message));
            }

            WebDriver.Wait(Helper.DurationType.Second, 3);

        }


        public ExistingContractPage NavigateToContractPage(string country)
        {
           ExistingContractButton.Click();
           var title = ValidateCountryTitle(country);
           return GetInstance<ExistingContractPage>(Driver, BasePage.BaseUrl, title);
        }

        public ExistingProposalPage NavigateToProposalPage(string country)
        {
            ExistingProposalButton.Click();
            var title = ValidateCountryTitle(country);
            return GetInstance<ExistingProposalPage>(Driver, BasePage.BaseUrl, title);
        }

        public MyAccountPage NavigateToMyAccountPage(string country)
        {
            MyAccountNavigationButton.Click();
            var title = ValidateMyAccountCountryTitle(country);
            return GetInstance<MyAccountPage>(Driver, BasePage.BaseUrl, title);
        }

        public DealerDashBoardPage NavigateToDealerDashboard()
        {
            ClickOnManagedPrintServices("mps");
            IsDealerDashboardDisplayed();
            CloudDealerDashboardButton.Click();
            return GetInstance<DealerDashBoardPage>(Driver);
        }

        public LocalOfficeAdminDashBoardPage NavigateToLOAdminDashboard()
        {
            ClickOnManagedPrintServices("mps");
            IsLOAdminDashboardDisplayed();
            CloudLocalOfficeAdminDashboardButton.Click();
            return GetInstance<LocalOfficeAdminDashBoardPage>(Driver);
        }

        public ListOfOrganisationsPage NavigateToListOfOrganisationsPage(string country)
        {
            NewProposalButton.Click();
            var title = ValidateCountryTitle(country);
            return GetInstance<ListOfOrganisationsPage>(Driver, BasePage.BaseUrl, title);
        }

        public ConsumablePage NavigateToConsumablePage(string country)
        {
            ConsumableNavigationButton.Click();
            var title = ValidateCountryTitle(country);
            return GetInstance<ConsumablePage>(Driver, BasePage.BaseUrl, title);
        }

        public TechnicalServicePage NavigateToTechnicalServicePage(string country)
        {
            ConsumableNavigationButton.Click();
            var title = ValidateCountryTitle(country);
            return GetInstance<TechnicalServicePage>(Driver, BasePage.BaseUrl, title);
        }

        public void VerifyDealerPrivilege()
        {
            ClickOnManagedPrintServices("print");
            IsExistingContractButtonDisplayed();
            IsExistingProposalButtonDisplayed();
            IsNewProposalButtonDisplayed();

        }

        public void VerifyCustomerPrivilege()
        {
            ClickOnManagedPrintServices("print");
            IsConsummableButtonDisplayed();
            IsTechnicalServiceButtonDisplayed();
            
        }

        public void IsExistingContractButtonDisplayed()
        {
            if (ExistingContractButton == null)
            {
                throw new Exception("Unable to locate Existing Contract Button on page");
            }
            AssertElementPresent(ExistingContractButton, "Existing Contract Button");
        }

        public void IsExistingProposalButtonDisplayed()
        {
            if (ExistingProposalButton == null)
            {
                throw new Exception("Unable to locate Existing Proposal Button on page");
            }
            AssertElementPresent(ExistingProposalButton, "Existing Proposal Button");
        }

        public void IsNewProposalButtonDisplayed()
        {
            if (NewProposalButton == null)
            {
                throw new Exception("Unable to locate New Proposal Button on page");
            }
            AssertElementPresent(NewProposalButton, "New Proposal Button");
        }

        public void IsConsummableButtonDisplayed()
        {
            if (ConsumableNavigationButton == null)
            {
                throw new Exception("Unable to locate New Proposal Button on page");
            }
            AssertElementPresent(ConsumableNavigationButton, "New Proposal Button");
        }

        public void IsTechnicalServiceButtonDisplayed()
        {
            if (TechnicalServicesNavigationButton == null)
            {
                throw new Exception("Unable to locate New Proposal Button on page");
            }
            AssertElementPresent(TechnicalServicesNavigationButton, "New Proposal Button");
        }

        private static readonly Dictionary<string, string> _pageTitle = new Dictionary<string, string>
        {
            {"Spain", " "},
	        {"Poland", " "},    
	        {"United Kingdom", " "},
	        {"Ireland", " "},
        };

        public static String ValidateCountryTitle(string country)
        {
            string title;
            return _pageTitle.TryGetValue(country, out title) ? title : string.Empty;
        }

        private static readonly Dictionary<string, string> _myAccountPageTitle = new Dictionary<string, string>
        {
            {"Spain", "Factura"},
	        {"Poland", ""},    
	        {"United Kingdom", ""},
	        {"Ireland", ""},
        };

        public static String ValidateMyAccountCountryTitle(string country)
        {
            string title;
            return _myAccountPageTitle.TryGetValue(country, out title) ? title : string.Empty;
        }

    }
}
