using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium.Support.UI;


namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ManageDevicesPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


        [FindsBy(How = How.CssSelector, Using = "#content_1_ComponentIntroductionAlert")]
        public IWebElement CompanyConfirmationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DeviceListFilter_InputFilterByLocation")]
        public IWebElement CompanyLocationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonCreateRequest")]
        public IWebElement CreateRequestElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-alert")]
        public IWebElement LocationSelectionAlertElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-installation-request-container")]
        public IWebElement InstallationRequestLineElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement InstallationRequestContainerElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-ignore button")]
        public IWebElement InstallationRequestActionButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-delete-installation-request")]
        public IWebElement InstallationRequestDeleteActionElement;
        [FindsBy(How = How.CssSelector, Using = ".modal-header [aria-hidden=\"true\"]")]
        public IWebElement InstallationRequestClosePopUpElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-show-installation-request-email")]
        public IWebElement ShowInstallationRequestEmailElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-show-devices-for-installation-request")]
        public IWebElement ShowAssignedDevicesElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-resend-emails-installation-request")]
        public IWebElement ResendEmailElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-cancel-installation-request")]
        public IWebElement CancelInstallationRequestElement;
        [FindsBy(How = How.CssSelector, Using = "p[style=\"margin: 12px 0px;\"] a")]
        public IWebElement InstallerLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".modal-header .modal-title")]
        public IWebElement ModalPopUpElement;
        [FindsBy(How = How.CssSelector, Using = ".active [href='/mps/dealer/contracts/manage-devices/manage'] span")]
        public IWebElement ManageDevicesTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_RequestList_List_CellInstallationRequestStatus_0")]
        public IWebElement InstallationRequestStatusElement;






        private string GetCancelledInstallationStatus()
        {
            var status = "";

            if (IsUKSystem())
            {
                status = "Cancelled";
            }
            else if (IsGermanSystem() || IsAustriaSystem())
            {
                status = "Abgebrochen";
            } 
            else if (IsItalySystem())
            {
                status = "Annullata";
            }
            else if (IsFranceSystem())
            {
                status = "Annulée";
            }else if (IsSpainSystem())
            {
                status = "Cancelado";
            } 

            

            return status;
        }

        public void IsInstallationRequestCancelled()
        {
            if(InstallationRequestStatusElement == null)
                throw new Exception("Installation Request element is not displayed");
            TestCheck.AssertTextContains(GetCancelledInstallationStatus(), InstallationRequestStatusElement.Text);
        }

        public void RefreshManageDeviceScreen()
        {
            if(ManageDevicesTabElement == null)
                throw new Exception("Manage Device Screen is not displayed");
            ManageDevicesTabElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }
        
        private string GetGeneratedCompany()
        {
            return SpecFlow.GetContext("GeneratedCompanyName");
        }

        public void IsManagedDeviceScreenDisplayed()
        {
            if(CompanyConfirmationElement == null)
                throw new Exception("Managed Device screen is not displayed");
            
            var genCompany = GetGeneratedCompany();

            if (String.IsNullOrWhiteSpace(genCompany))
            {
                genCompany = "Middle Mall_160322123145 Ltd";
            }

            AssertElementContainsText(CompanyConfirmationElement, genCompany, "Generated Company is empty");
            HeadlessDismissAlertOk();
        }

        public void ClickOnActionButton()
        {
            if(InstallationRequestActionButtonElement == null)
                throw new Exception("Installation Action is not displayed");
            InstallationRequestActionButtonElement.Click();
        }

        public void ClickOnCancelRequest()
        {
            if(CancelInstallationRequestElement == null)
                throw new Exception("Cancel installation button not displayed");
            CancelInstallationRequestElement.Click();
            ClickAcceptOnConfrimation(Driver);
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void ClickAcceptOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 1000);
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert(driver);
        }

        public void ClickToExposeInstallationRequest()
        {
            if(ShowInstallationRequestEmailElement == null)
                throw new Exception("Show Installation Request element is not displayed");
            ShowInstallationRequestEmailElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void IsInstallationRequestScreenDisplayed()
        {
            TestCheck.AssertIsEqual(true, ModalPopUpElement.Displayed, "Installation request pop up is opened");
           // WebDriver.Wait(DurationType.Second, 3);
        }

        public string GetInstallationLink()
        {
             var installLink = InstallerLinkElement.GetAttribute("href");
            SpecFlow.SetContext("InstallerLink", installLink);

            return installLink;

        }

        public InstallerDeviceInstallationPage LaunchInstallerPage()
        {
            Driver.Navigate().GoToUrl(GetInstallationLink());
            return GetInstance<InstallerDeviceInstallationPage>(Driver);
        }

        public void CloseInstallationrequestPopUp()
        {
            var potentialAlert = GetSeleniumAlert();

            if (potentialAlert != null)
            {
                InstallationRequestClosePopUpElement.Click();
            }

            WebDriver.Wait(DurationType.Second, 5);
        }
        
        

        public void SelectCompanyLocation()
        {
            var company = new SelectElement(CompanyLocationElement);

            var selectableList = company.Options;

            foreach (var coy in selectableList)
            {
                if (coy.Text.Contains(GetGeneratedCompany()))
                {
                    coy.Click();
                }
            }

            WebDriver.Wait(DurationType.Second, 2);

        }

        public void ClickOnNextButtonToInvokeError()
        {
            CreateRequestElement.Click();
            
        }

        public DealerSetCommunicationMethodPage CreateInstallationRequest()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, CreateRequestElement);
            WebDriver.Wait(DurationType.Second, 10);

            return GetTabInstance<DealerSetCommunicationMethodPage>(Driver);
        }

        public void IsInstallationRequestDisplayed()
        {
            MPSJobRunnerPage.RunCompleteInstallationCommandJob();
            AssertElementPresent(InstallationRequestContainerElement, "Installation not finished");
            HeadlessDismissAlertOk();
        }

        public void SelectLocationErrorIsDisplayed()
        {
            TestCheck.AssertIsEqual(true, LocationSelectionAlertElement.Displayed, "Location alert is not displayed"); 
        }


    }
}
