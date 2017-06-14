using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium.Support.UI;


namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerManageDevicesPage : BasePage
    {
        public static string Url = "/";
        private string Body = @"<Status Notification >
                                The device status is [{0}] 

                                <Node Information>
                                Name: BRN30055C15474D
                                Model Name: Brother {1}
                                Location: 
                                Contact: 
                                IP Address: 10.135.102.139
                                Device serial number: U63783{2}
                                URL: http://10.135.102.139
                                Page Count: 0
                                Drum Count: 355";
        private string Subject = @"Status Notification [{0}]";

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
        [FindsBy(How = How.CssSelector, Using = ".js-mps-delete-remove.mps-installation-request-container")]
        public IWebElement InstallationRequestLineElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement InstallationRequestContainerElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-ignore button")]
        public IWebElement InstallationRequestActionButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-ignore button")]
        public IList<IWebElement> InstallationRequestActionButtonsElement;
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
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-swap-device")]
        public IWebElement SwapRequestElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-reinstall-device")]
        public IWebElement ReinstallationRequestElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-swap-device-confirm")]
        public IWebElement SwapCommencementConfirmationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ComponentSuccess")]
        public IWebElement SwapRequestSuccessConfirmationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_EmailSendSuccess")]
        public IWebElement ReinstallRequestSuccessConfirmationElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-ignore .mps-txt-r")]
        public IWebElement SwapProgressIndicatorElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-device-container")]
        public IList<IWebElement> DisplayedDevicesLineElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_1_DeviceList_List_CellSerial_\"]")]
        public IList<IWebElement> DisplayedSerialNumberElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-complete-swap-device")]
        public IWebElement CompleteSwapProcessElement;
        [FindsBy(How = How.CssSelector, Using = "[class=\"mps-txt-c responding\"]")]
        public IWebElement DeviceRespondingActionElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/customers\"]")]
        public IWebElement CustomerAndContactTabElement;
        [FindsBy(How = How.CssSelector, Using = "[data-swap-type-enum-id=\"ReplaceWithSameModel\"]")]
        public IWebElement ReplaceWithSameModelElement;
        [FindsBy(How = How.CssSelector, Using = "[data-swap-type-enum-id=\"ReplaceWithDifferentModel\"]")]
        public IWebElement ReplaceWithDifferentModelElement;
        [FindsBy(How = How.CssSelector, Using = "[data-swap-type-enum-id=\"ReplaceThePcb\"]")]
        public IWebElement ReplacePcbElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-swap-type-selected")]
        public IWebElement SwapTypeNextButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".form-control.js-mps-replacement-model-list")]
        public IWebElement SwapModelDeviceSelectorElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-swap-replacement-model-selected-btn")]
        public IWebElement SwapModelNextElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-reinstall-device-confirm")]
        public IWebElement ReInstallCommencementButtonElement;
        [FindsBy(How = How.CssSelector, Using = "[data-original-title=\"Type: Email<br />Status: Responding\"]")]
        public IWebElement EmailGreenIconElement;
        
        
        

        
        public void IsInstallationRequestCancelled()
        {
            if(InstallationRequestStatusElement == null)
                throw new Exception("Installation Request element is not displayed");
            //TestCheck.AssertTextContains(GetCancelledInstallationStatus(), InstallationRequestStatusElement.Text);
            TestCheck.AssertIsEqual(false, String.IsNullOrWhiteSpace(InstallationRequestStatusElement.Text), "Installation has not been cancelled");
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
            string genCompany;

            try
            {
                genCompany = SpecFlow.GetContext("GeneratedCompanyName");

            }
            catch (KeyNotFoundException e)
            {
                genCompany = GenCoyOptions();
                MsgOutput(String.Format("Generated company was empty so {0} was used", genCompany));
            }

            return genCompany;
        }

        private string GenCoyOptions()
        {
            var coy = "";

            if (IsAustriaSystem())
            {
                coy = "Blue Hollow_160322133924 Ltd";
            } else if (IsUKSystem())
            {
                coy = "Honey Pines_160514201608 Ltd";
            } else if (IsGermanSystem())
            {
                coy = "Middle Mall_160322135029 Ltd";
            }
            else if (IsSpainSystem())
            {
                coy = "Rocky Bear_160322140949 Ltd";
            }
            else if (IsItalySystem())
            {
                coy = "Colonial Avenue_160322121421 Ltd";
            }
            else if (IsFranceSystem())
            {
                coy = "Silent Field_160322142114 Ltd";
            }
            else if (IsIrelandSystem())
            {
                coy = "Cotton Blossom_16061114137 Ltd";
            }else if (IsSwedenSystem())
            {
                coy = "Fallen Pond_160616191239 Ltd";
            }
            else if (IsNetherlandSystem())
            {
                coy = "Rustic Parade_160524081137 Ltd";
            }
            else if (IsDenmarkSystem())
            {
                coy = "Hidden Run_160630151142 Ltd";
            }
            else if (IsBelgiumSystem())
            {
                coy = "Colonial Avenue_160718082853 Ltd";
            }
            else if (IsPolandSystem())
            {
                coy = "Coleen Salazar Ltd";
            }
            
           return coy;
        }

        public void IsManagedDeviceScreenDisplayed()
        {
            if(CompanyConfirmationElement == null)
                throw new Exception("Managed Device screen is not displayed");

            var genCompany = GetGeneratedCompany();

            AssertElementContainsText(CompanyConfirmationElement, genCompany, "Generated Company is empty");
            
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
        }

        public void ClickOnActionButtonOnDisplay()
        {
            if(InstallationRequestActionButtonElement == null)
                throw new Exception("Installation Action is not displayed");
            InstallationRequestActionButtonElement.Click();
        }

        public void ClickOnTheLastActionButton()
        {
            if(InstallationRequestActionButtonsElement == null)
                throw new Exception("No action button displayed");

            InstallationRequestActionButtonsElement.Last().Click();
        }

        public void BeginSwapProcess()
        {
            if (InstallationRequestActionButtonsElement.Count > 1)
            {
                ClickOnTheLastActionButton();
            }
            else
            {
                ClickOnActionButtonOnDisplay();
            }

            WaitForElementToBeClickableByCssSelector(".open .js-mps-swap-device", 5, 5);
            SwapRequestElement.Click();
        }

        public void IsEmailInstallationSuccessful()
        {
            RefreshManageDeviceScreen();
            
            if (Method() == "Email")
            {
                if (EmailGreenIconElement == null)
                    throw new Exception("Email Green Icon is returned as null");

                TestCheck.AssertIsEqual(true, EmailGreenIconElement.Displayed, "Email Green Icon is not displayed");
            }
           
        }

        public void BeginReInstallationProcess()
        {
            if (InstallationRequestActionButtonsElement.Count > 1)
            {
                ClickOnTheLastActionButton();
            }
            else
            {
                ClickOnActionButtonOnDisplay();
            }

            WaitForElementToBeClickableByCssSelector(".open .js-mps-reinstall-device", 5, 5);
            ReinstallationRequestElement.Click();
        }

        public CompleteSwapProcessPage CompleteSwapProcess()
        {
            ClickOnActionButtonOnDisplay();
            WaitForElementToBeClickableByCssSelector(".open .js-mps-complete-swap-device", 5, 5);
            CompleteSwapProcessElement.Click();

            return GetInstance<CompleteSwapProcessPage>();
        }



        public DealerSetCommunicationMethodPage ConfirmReinstallProcessCommencement()
        {
            if (ReInstallCommencementButtonElement == null)
                throw new Exception("Reinstall confirmation pop up not displayed");
            ReInstallCommencementButtonElement.Click();

            return GetInstance<DealerSetCommunicationMethodPage>();
        }

        public void ConfirmSwapProcessCommencement()
        {
            if (SwapCommencementConfirmationElement == null)
                throw new Exception("Swap confirmation pop up not displayed");
            SwapCommencementConfirmationElement.Click();
        }

        public DealerSetCommunicationMethodPage ConfirmSameSwapDeviceType()
        {
            if (ReplaceWithSameModelElement == null)
                throw new Exception("Swap confirmation pop up not displayed");
            ReplaceWithSameModelElement.Click();
            SwapTypeNextButtonElement.Click();

            return GetInstance<DealerSetCommunicationMethodPage>();
        }


        public DealerSetCommunicationMethodPage ConfirmPcbProcess()
        {
            if (ReplacePcbElement == null)
                throw new Exception("Swap confirmation pop up not displayed");
            ReplacePcbElement.Click();
            SwapTypeNextButtonElement.Click();

            return GetInstance<DealerSetCommunicationMethodPage>();
        }
        

        public void ConfirmDifferentSwapDeviceType()
        {
            if (ReplaceWithDifferentModelElement == null)
                throw new Exception("Swap different device pop up not displayed");
            ReplaceWithDifferentModelElement.Click();
            SwapTypeNextButtonElement.Click();
        }

        public DealerSetCommunicationMethodPage SelectANewSwapDevice(string device)
        {
            if (SwapModelDeviceSelectorElement == null)
                throw new Exception("Swap model device pop up not displayed");
            SelectFromDropdown(SwapModelDeviceSelectorElement, device);

            SwapModelNextElement.Click();

            return GetInstance<DealerSetCommunicationMethodPage>();
        }



        public void IsSwapInstallationRequestSent()
        {
            if(SwapRequestSuccessConfirmationElement == null)
                throw new Exception("Swap request success confirmation is not displayed");
            AssertElementPresent(SwapRequestSuccessConfirmationElement, "Swap request installation not sent");
        }

        public void IsReinstallationRequestSent()
        {
            if (ReinstallRequestSuccessConfirmationElement == null)
                throw new Exception("Reinstall request success confirmation is not displayed");
            AssertElementPresent(ReinstallRequestSuccessConfirmationElement, "Reinstall request installation not sent");
        }

        

        public void IsSwapDeviceLineDisplayed()
        {
            var lineCount = DisplayedDevicesLineElement.Count;

            TestCheck.AssertIsEqual(true, lineCount > 1, "Swap device line is not displayed");
        }
        

        public void ClickOnCancelRequest()
        {
            if(CancelInstallationRequestElement == null)
                throw new Exception("Cancel installation button not displayed");
            ClickAcceptOnJsAlert();
            CancelInstallationRequestElement.Click();
            ClickAcceptOnConfirmation();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void ClickAcceptOnConfirmation()
        {
            WebDriver.Wait(DurationType.Millisecond, 1000);
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
        }

        public void IsSwapProgressTextDisplayed()
        {
           TestCheck.AssertIsEqual(false, String.IsNullOrWhiteSpace(SwapProgressIndicatorElement.Text),
                                            "Swap progress text is not displayed");
        }

        public void ClickToExposeInstallationRequest()
        {
            if(ShowInstallationRequestEmailElement == null)
                throw new Exception("Show Installation Request element is not displayed");
            ShowInstallationRequestEmailElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void ClickToExposeSwapInstallationRequest()
        {
            if (ShowInstallationRequestEmailElement == null)
                throw new Exception("Show Installation Request element is not displayed");
            ClickOnActionButtonOnDisplay();
            ShowInstallationRequestEmailElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }


        public void CancelSwapInstallationRequest()
        {
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();

            if (ShowInstallationRequestEmailElement == null)
                throw new Exception("Show Installation Request element is not displayed");
            ClickOnActionButtonOnDisplay();
            CancelInstallationRequestElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void IsSwapInstallationRequestCancelled()
        {
            var disp =
                IsElementPresent(GetElementByCssSelector(".js-mps-delete-remove.mps-installation-request-container"));

            TestCheck.AssertIsEqual(false, disp, "Installation request container is still displayed");
        }

        public void IsNewlySwappedDeviceDisplayed()
        {
            var serialContainer = new List<String>();
            var swapSerial = SpecFlow.GetContext("SwapSerialNumber");

            foreach (var serial in DisplayedSerialNumberElement)
            {
                var serialText = serial.Text;

                serialContainer.Add(serialText);
            }

            TestCheck.AssertIsEqual(true, serialContainer.Contains(swapSerial), 
                                                "Swapped Device is not displayed");

        }

        public void IsInstallationRequestScreenDisplayed()
        {
            WebDriver.Wait(DurationType.Second, 3);
            TestCheck.AssertIsEqual(true, ModalPopUpElement.Displayed, "Installation request pop up is opened");
           
        }

        public string GetInstallationLink()
        {
             var installLink = InstallerLinkElement.GetAttribute("href");
            SpecFlow.SetContext("InstallerLink", installLink);

            return installLink;

        }

        public InstallerDeviceInstallationPage LaunchInstallerPage()
        {
            MpsJobRunnerPage.RunCompleteInstallationCommandJob(MpsUtil.CreatedProposal());
            Driver.Navigate().GoToUrl(GetInstallationLink());
            return GetInstance<InstallerDeviceInstallationPage>(Driver);
        }

      public void SelectCompanyLocation()
        {
           

            SelectElementOptionsByIndex(CompanyLocationElement, 1);

         

          WaitForElementToBeClickableByCssSelector("#content_1_ButtonCreateRequest", 5, 5);

        }

        public void ClickOnNextButtonToInvokeError()
        {
            CreateRequestElement.Click();
            
        }

        public DealerSetCommunicationMethodPage CreateInstallationRequest()
        {
            WebDriver.Wait(DurationType.Second, 2);
            MpsUtil.JsClickButtonThenNavigateToDifferentUrl(Driver, CreateRequestElement);
            
            return GetTabInstance<DealerSetCommunicationMethodPage>(Driver);
        }

        public void IsInstallationRequestDisplayed()
        {
            AssertElementPresent(InstallationRequestContainerElement, "Installation not finished");
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
        }

        private string Method()
        {
            return SpecFlow.GetContext("InstallationMethod");
        }

        public DealerCustomersExistingPage NavigateToCustomerAndContactPage()
        {
            if(CustomerAndContactTabElement == null)
                throw new Exception("Customer and Contact Tab is not displayed");
            CustomerAndContactTabElement.Click();

            return GetInstance<DealerCustomersExistingPage>();
        }

        public void SendEmailForServiceRequest(string address, string subject, string model, string serial)
        {
            Subject = String.Format(Subject, subject);
            Body = String.Format(Body, subject, model, serial);
            ActionsModule.SendServiceRequestEmail(address, Subject, Body);
            ActionsModule.RunConsumableOrderCreationJobs();
        }

        public void IsInstallationCompleted()
        {

            if ((Method() != "Email" && !String.IsNullOrWhiteSpace(Method())))
            {
                var connection = DeviceRespondingActionElement.Displayed;

                MpsJobRunnerPage.NotifyBocOfNewChanges();
                TestCheck.AssertIsEqual(true, connection, "Installation is not successfully connected to BOC");
            }
           
            //MpsJobRunnerPage.RunCreateOrderAndServiceRequestsCommandJob();
            MpsJobRunnerPage.RunConsumableOrderRequestsCommandJob();
            MpsJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob(MpsUtil.CreatedProposal(), Locale);
            if (Method() == "Email" || String.IsNullOrWhiteSpace(Method()))
            {
                MpsJobRunnerPage.RunRefreshPrintCountsFromEmailCommandJob(Locale);
                WebDriver.Wait(DurationType.Second, 5);
                MpsJobRunnerPage.RunCompleteInstallationCommandJob(MpsUtil.CreatedProposal());
                WebDriver.Wait(DurationType.Second, 5);
            }
            

        }

        public void IsInstallationCompleted(string number1, string number2, string number3, string number4)
        {
            if (Method() != "Email")
            {
                var connection = DeviceRespondingActionElement.Displayed;

                MpsJobRunnerPage.NotifyBocOfNewChanges(number1);
                MpsJobRunnerPage.NotifyBocOfNewChanges(number2);
                MpsJobRunnerPage.NotifyBocOfNewChanges(number3);
                MpsJobRunnerPage.NotifyBocOfNewChanges(number4);
                TestCheck.AssertIsEqual(true, connection, "Installation is not successfully connected to BOC");
            }

            //MpsJobRunnerPage.RunCreateOrderAndServiceRequestsCommandJob();
            MpsJobRunnerPage.RunConsumableOrderRequestsCommandJob();
            MpsJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob(MpsUtil.CreatedProposal(), Locale);
            MpsJobRunnerPage.RunRefreshPrintCountsFromEmailCommandJob(Locale);
        }

        public void SelectLocationErrorIsDisplayed()
        {
            TestCheck.AssertIsEqual(true, LocationSelectionAlertElement.Displayed, "Location alert is not displayed"); 
        }


    }
}
