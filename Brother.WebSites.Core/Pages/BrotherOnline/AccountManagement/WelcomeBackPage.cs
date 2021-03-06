﻿using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSOne;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal;
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

        [FindsBy(How = How.CssSelector, Using = ".button-blue")] public IWebElement SignOutButton;
        [FindsBy(How = How.CssSelector, Using = ".add-device")] public IWebElement RegisterDeviceLink;
        [FindsBy(How = How.CssSelector, Using ="#content_2_CurrentControlPanelItem_ConferenceButtons.two-conference-buttons .conference-button.right")] 
        public IWebElement OmniJoinTryNowButton;
        [FindsBy(How = How.CssSelector, Using ="#content_2_CurrentControlPanelItem_ConferenceButtons.two-conference-buttons .conference-button.left")] 
        public IWebElement OmniJoinBuyNowButton;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_2_ProductsTabRepeater_tabItem\"] p strong")] 
        public IList<IWebElement> MpsPrintSmartButton;
        [FindsBy(How = How.CssSelector, Using = ".clearfix a[href*='customer-information']")] 
        public IWebElement NewProposalButton;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/print-smart/my-proposals\"]")] 
        public IWebElement ExistingProposalButton;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/print-smart/my-contracts\"]")] 
        public IWebElement ExistingContractButton;
        [FindsBy(How = How.CssSelector, Using = "a.mps-link[href=\"/mps/customer/dashboard\"]")] 
        public IWebElement CustomerLinkButton;
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

        [FindsBy(How = How.CssSelector, Using = ".icon [alt=\"Managed Print Services\"]")]
        public IWebElement MpsIconElement;
        
        [FindsBy(How = How.CssSelector, Using = ".brother_ink_Sta_Sum")] 
        public IWebElement InkDevicePropertiesContainer;
        [FindsBy(How = How.CssSelector, Using = ".container-dp-header")] 
        public IWebElement Containerheader;
        [FindsBy(How = How.Id, Using = "294daeb7-aaa8-4202-b845-d89121cf3b3d")] 
        public IWebElement BusinessDetailLink;
        public string BussinessUpdateButtonId = "#content_2_innercontent_1_SubmitButton";

        [FindsBy(How = How.Id, Using = "BusinessAccountYesRadioButton")] 
        public IWebElement UseMyAccountForBusinessCheckbox;

        [FindsBy(How = How.Id, Using = "110d559f-dea5-42ea-9c1c-8a5df7e70ef9")] 
        public IWebElement BroOnlineLink;

        [FindsBy(How = How.Id, Using = "f200cbab-dac8-4dfd-a10f-9c1af427a95c")] 
        public IWebElement InstantInkSupplyMenuItem;

        [FindsBy(How = How.CssSelector, Using = "#content_2_ProductsTabRepeater_tabItem_2")] 
        public IWebElement PartnerPortalMenu;

        [FindsBy(How = How.CssSelector, Using = ".dp-button-aqua")] 
        public IWebElement PartnerPortalButton;

        // Added TryNow button Locator 
        [FindsBy(How = How.XPath, Using = ".//*[@id='content_2_CurrentControlPanelItem_ConferenceButtons']/a[2]")] 
        public IWebElement TryNowOmniJoinFreeTrailButton;

        public bool IsWarningBarPresent(int retry, int timeToWait)
        {
            try
            {
                if (WaitForElementToExistByCssSelector(".warning-bar", retry, timeToWait))
                {
                    var warningBar = Driver.FindElement(By.CssSelector(".warning-bar"));
                    if (warningBar != null)
                    {
                        if (warningBar.Displayed)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                MsgOutput(string.Format("Warning bar could not be located [{0}]", elementNotVisible.Message));
                return false;
            }
            return false;
        }

        public void IsDealerDashboardDisplayed()
        {
            if (CloudDealerDashboardButton == null)
            {
                throw new Exception("Dealer Dashboard page not displayed");
            }
            AssertElementPresent(CloudDealerDashboardButton, "Dealer Dashboard");
        }

        public void IsCustomerLinkOnDashboardDisplayed()
        {
            if (CustomerLinkButton == null)
            {
                throw new Exception("Cloud MPS Customer link not displayed");
            }
            AssertElementPresent(CustomerLinkButton, "Dealer Dashboard");
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

        public void IsInkSupplyMenuItemAvailable()
        {
            if (InstantInkSupplyMenuItem == null)
            {
                throw new Exception("Unable to find Ink Supply Menu Item on page");
            }
            AssertElementPresent(InstantInkSupplyMenuItem, "Ink Supply Menu Item");
        }

        // Without moving off the Welcome Back page
        public void InkSupplyMenuItemClick()
        {
            if (InstantInkSupplyMenuItem == null)
            {
                throw new Exception("Unable to find Ink Supply Menu Item on page");
            }
            InstantInkSupplyMenuItem.Click();
        }

        public bool IsInkSupplyMenuItemMissing()
        {
            try
            {
                // set global timeout and reset afterwards
                Driver.FindElement(By.Id("f200cbab-dac8-4dfd-a10f-9c1af427a95c"));
            }
            catch (ElementNotVisibleException)
            {
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return true;
            }
            catch (WebDriverException)
            {
                return true;
            }
            return false;
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

        public void VerifyInkDeviceSerialNumber(string serialnumber)
        {
            if (InkStatusSummaryListElement == null)
            {
                throw new Exception("Unable to find ink device container on page");
            }
            AssertElementText(InkStatusSummaryListElement.ElementAt(1), serialnumber, "Ink Device Serialnumber");
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

        public void ClickOnManagedPrintServices(string navigation)
        {
            try
            {
                foreach (var button in MpsPrintSmartButton)
                {
                    var countryPrintSmart = button.Text;

                    if (!countryPrintSmart.Contains(navigation)) continue;
                    button.Click();
                    break;
                }

            }
            catch (NoSuchElementException noSuchElementException)
            {
                throw new Exception(string.Format("MPS's navigational link is not displayed [{0}]",
                    noSuchElementException.Message));
            }

            WebDriver.Wait(DurationType.Second, 3);

        }

        public void ClickOnMpsLinkOnWelcomePage()
        {
            var mpsLink = MpsIconElement;
            mpsLink.Click();
            WaitForElementToExistByCssSelector("a[href*=\"/mps/customer\"].mps-link");
        }

        
        public ExistingContractPage NavigateToContractPage(string country)
        {
            ExistingContractButton.Click();
            var title = ValidateCountryTitle(country);
            return GetInstance<ExistingContractPage>(Driver, BrotherOnlineBaseUrl, title);
        }

        public ExistingProposalPage NavigateToProposalPage(string country)
        {
            ExistingProposalButton.Click();
            var title = ValidateCountryTitle(country);
            return GetInstance<ExistingProposalPage>(Driver, BrotherOnlineBaseUrl, title);
        }

        public MyAccountPage NavigateToMyAccountPage(string country)
        {
            MyAccountNavigationButton.Click();
            return GetInstance<MyAccountPage>(Driver, BrotherOnlineBaseUrl, string.Empty);
        }

        public MyAccountPage MyAccountNavigationButtonClick()
        {
            MyAccountNavigationButton.Click();
            return GetInstance<MyAccountPage>(Driver, BrotherOnlineBaseUrl, string.Empty);

        }

        public DealerDashBoardPage NavigateToDealerDashboard()
        {
            ClickOnManagedPrintServices("mps");
            IsDealerDashboardDisplayed();
            CloudDealerDashboardButton.Click();
            return GetInstance<DealerDashBoardPage>(Driver);
        }

        public CustomerPortalDashboardPage NavigateToCustomerDashboardPage()
        {
            //ClickOnManagedPrintServices("MANAGED PRINT SERVICES");
            ClickOnMpsLinkOnWelcomePage();
            IsCustomerLinkOnDashboardDisplayed();
            CustomerLinkButton.Click();
            return GetInstance<CustomerPortalDashboardPage>(Driver);
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
            return GetInstance<ListOfOrganisationsPage>(Driver, BrotherOnlineBaseUrl, title);
        }

        public ConsumablePage NavigateToConsumablePage(string country)
        {
            ConsumableNavigationButton.Click();
            var title = ValidateCountryTitle(country);
            return GetInstance<ConsumablePage>(Driver, BrotherOnlineBaseUrl, title);
        }

        public TechnicalServicePage NavigateToTechnicalServicePage(string country)
        {
            ConsumableNavigationButton.Click();
            var title = ValidateCountryTitle(country);
            return GetInstance<TechnicalServicePage>(Driver, BrotherOnlineBaseUrl, title);
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

        public void IsSignOutButtonDisplayed()
        {
            if (SignOutButton == null)
            {
                throw new Exception("Unable to locate Sign Out Button on page");
            }
            AssertElementPresent(SignOutButton, "Sign Out Button");
        }

        public void BusinessDetailsClick()
        {
            ScrollTo(BusinessDetailLink);
            BusinessDetailLink.Click();
        }

        public void PartnerPortalMenuClick()
        {
            //ScrollTo(PartnerPortalMenu);
            PartnerPortalMenu.Click();
        }

        public void BroOnlineHomeClick()
        {
            ScrollTo(BroOnlineLink);
            BroOnlineLink.Click();
        }

        public void IsBusinessUpdateButtonAvailable()
        {
            IWebElement updateButton = null;
            if (WaitForElementToExistByCssSelector(BussinessUpdateButtonId, 5, 5))
            {
                updateButton = Driver.FindElement(By.CssSelector(BussinessUpdateButtonId));
            }
            AssertElementPresent(updateButton, "Update Button");
        }


        public void UseAccountForBusinessIsSelectedForCc()
        {
            TestCheck.AssertIsEqual("True", UseMyAccountForBusinessCheckbox.Selected.ToString(),
                "Use Account For Business Button");
        }

        public FreeTrialPage TryNowOmniJoinFreeTrailButtonClick()
        {
            TryNowOmniJoinFreeTrailButton.Click();
            return GetInstance<FreeTrialPage>(Driver);
        }
    }
}

