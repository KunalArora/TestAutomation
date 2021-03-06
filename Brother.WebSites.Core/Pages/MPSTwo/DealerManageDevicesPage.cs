﻿using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerManageDevicesPage : BasePage, IPageObject
    {
        public static string Url = "/";
        //private string _body = "<" + "Status Notification" + ">" + "\r\n" + 
        //                        "The device status is [{0}] \r\n" + "\r\n"+
                                
        //                        "<Node Information>\r\n" +
        //                        "Name: BRN30055C15474D \r\n" +
        //                        "Model Name: Brother {1} \r\n" +
        //                        "Location: \r\n" +
        //                        "Contact: \r\n" +
        //                        "IP Address: 10.135.102.139 \r\n" +
        //                        "Device serial number: U63783{2} \r\n" +
        //                        "URL: http://10.135.102.139\r\n" +
        //                        "Page Count: 0 \r\n" + 
        //                        "Drum Count: 355 \r\n";

        private const string _validationElementSelector = "#content_1_DeviceListFilter_btnShowPrintCounts";
        private const string _url = "/mps/dealer/contracts/manage-devices/manage";

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
                return _url;
            }
        }


        private const string InstallationRequestContainerSelector = ".js-mps-installation-request-list-container";
        private const string InstallationRequestRowSelector = ".js-mps-searchable";
        private const string InstallationRequestEmailSelector = "[id*=content_1_RequestList_List_CellInstallerEmail_]";
        private const string InstallationRequestCompanySiteSelector = "[id*=content_1_RequestList_List_CellLocation_]";
        private const string InstallationRequestStatusSelector = "[id*=content_1_RequestList_List_CellInstallationRequestStatus_]";
        private const string InstallationRequestCommunicationMethodSelector = "[id*=content_1_RequestList_List_CellCommunicationMethodIcon_]";
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string CreateRequestButtonSelector = "#content_1_ButtonCreateRequest";
        private const string CancelInstallationRequestSelector = ".js-mps-cancel-installation-request";
        private const string InstallationRequestSelector = ".js-mps-show-installation-request-email";
        private const string DeviceListContainerSelector = ".js-mps-device-list-container";
        private const string DeviceListContainerRowSelector = ".js-mps-searchable";
        private const string DeviceSerialNumberSelector = "[id*=content_1_DeviceList_List_CellSerial_]";
        private const string SwapDeviceButtonSelector = ".js-mps-swap-device";
        private const string SwapDeviceModalSelector = ".js-mps-swap-device-confirmation";
        private const string SwapDeviceConfirmSelector = ".js-mps-swap-device-confirm";
        private const string SwapDeviceTypesSelector = ".js-mps-swap-device-swap-types";
        private const string SwapDeviceTypesDataAttributeSelector = "swap-type-enum-id";
        private const string SwapDeviceTypesModalNextButtonSelector = ".js-mps-swap-type-selected";
        private const string DeviceStatusSelector = ".js-mps-filter-ignore";
        private const string SwapDeviceReplacementModelListSelector = ".js-mps-replacement-model-list";
        private const string SwapDeviceReplacementModelNextButtonSelector = ".js-mps-swap-replacement-model-selected-btn";

        private const string Body1 = @"&lt;Status Notification&gt;";
        private string _body2 = "<br/>";
        private string _body3 = @"The device status is [{0}]";
        private string _body4 = "<br/>" + "<br/>";
        private const string Body5 = @"&lt;Node Information&gt;";
        private string _body6 = "<br/>";
        private const string Body7 = @"Name: BRN30055C15474D";
        private string _body8 = "<br/>";
        private string _body9 = @"Model Name: Brother {0}";
        private string _body10 = "<br/>";
        private const string Body11 = @"Location:" ;
        private string _body12 = "<br/>";                             
        private const string Body13 = @"Contact:" ;
        private string _body14 = "<br/>";
        private const string Body15 = @"IP Address: 10.135.102.139";
        private string _body16 = "<br/>";
        private string _body17 = @"Device serial number: U63783{0}";
        private string _body18 = "<br/>";
        private const string Body19 = @"URL: http://10.135.102.139" ;
        private string _body20 = "<br/>";
        private const string Body21 = @"Page Count: 0" ;
        private string _body22 = "<br/>";
        private const string Body23 = @"Drum Count: 355";

        private string _subject = @"Status Notification [{0}]";

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
        [FindsBy(How = How.CssSelector, Using = ".js-mps-swap-type-item[data-swap-type-enum-id=\"ReplaceWithSameModel\"]")]
        public IWebElement ReplaceWithSameModelElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-swap-type-item[data-swap-type-enum-id=\"ReplaceWithDifferentModel\"]")]
        public IWebElement ReplaceWithDifferentModelElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-swap-type-item[data-swap-type-enum-id=\"ReplaceThePcb\"]")]
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



        private const string InstallationDeviceListSelector = ".js-mps-device-list-container";
        private const string InstallationDeviceTableSelector = ".js-mps-searchable";
        private const string InstallationRespondingTypeSelector = "[id*=content_1_DeviceList_List_CellCommunicationType_].mps-txt-c.responding";
        private const string InstallationSerialNumberSelector = "[id*=content_1_DeviceList_List_CellSerial_]";
        private const string InstallationTotalPagesSelector = "[id*=content_1_DeviceList_List_CellTotalPages_]";
        private const string ShowPrintCountButtonSelector = ".js-mps-device-list-general-view.js-mps-toggle-device-view";
        

        private const string InstallationCommunicationTypeSelector = "[id*=_DeviceList_List_CellCommunicationType_]";



        public void IsInstallationRequestCancelled()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (InstallationRequestStatusElement == null)
                TestCheck.AssertFailTest("Installation Request element is not displayed");
            TestCheck.AssertIsEqual(false, String.IsNullOrWhiteSpace(InstallationRequestStatusElement.Text), "Installation has not been cancelled");
        }

        public void RefreshManageDeviceScreen()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ManageDevicesTabElement == null)
                TestCheck.AssertFailTest("Manage Device Screen is not displayed");
            ManageDevicesTabElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }
        
        private string GetGeneratedCompany()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            if (CompanyConfirmationElement == null)
                TestCheck.AssertFailTest("Managed Device screen is not displayed");

            var genCompany = GetGeneratedCompany();

            AssertElementContainsText(CompanyConfirmationElement, genCompany, "Generated Company is empty");
            
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
        }

        public void ClickOnActionButtonOnDisplay()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (InstallationRequestActionButtonElement == null)
                TestCheck.AssertFailTest("Installation Action is not displayed");
            InstallationRequestActionButtonElement.Click();
        }

        public void ClickOnTheLastActionButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (InstallationRequestActionButtonsElement == null)
                TestCheck.AssertFailTest("No action button displayed");

            InstallationRequestActionButtonsElement.Last().Click();
        }

        public void BeginSwapProcess()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            RefreshManageDeviceScreen();
            
            if (Method() == "Email")
            {
                if (EmailGreenIconElement == null)
                    TestCheck.AssertFailTest("Email Green Icon is returned as null");

                TestCheck.AssertIsEqual(true, EmailGreenIconElement.Displayed, "Email Green Icon is not displayed");
            }
           
        }

        public void BeginReInstallationProcess()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            ClickOnActionButtonOnDisplay();
            WaitForElementToBeClickableByCssSelector(".open .js-mps-complete-swap-device", 5, 5);
            CompleteSwapProcessElement.Click();

            return GetInstance<CompleteSwapProcessPage>();
        }



        public DealerSetCommunicationMethodPage ConfirmReinstallProcessCommencement()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ReInstallCommencementButtonElement == null)
                TestCheck.AssertFailTest("Reinstall confirmation pop up not displayed");
            WebDriver.Wait(DurationType.Second, 5);
            ReInstallCommencementButtonElement.Click();

            return GetInstance<DealerSetCommunicationMethodPage>();
        }

        public void ConfirmSwapProcessCommencement()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (SwapCommencementConfirmationElement == null)
                TestCheck.AssertFailTest("Swap confirmation pop up not displayed");
            SwapCommencementConfirmationElement.Click();
            WebDriver.Wait(DurationType.Second, 10);
        }

        public DealerSetCommunicationMethodPage ConfirmSameSwapDeviceType()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ReplaceWithSameModelElement == null)
                TestCheck.AssertFailTest("Swap confirmation pop up not displayed");

            WaitForElementToExistByCssSelector(".js-mps-swap-type-item[data-swap-type-enum-id=\"ReplaceWithSameModel\"]");
            
            ReplaceWithSameModelElement.Click();
            WaitForElementToBeClickableByCssSelector(".js-mps-swap-type-selected", 5, 5);
            SwapTypeNextButtonElement.Click();


            return GetInstance<DealerSetCommunicationMethodPage>();
        }


        public DealerSetCommunicationMethodPage ConfirmPcbProcess()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ReplacePcbElement == null)
                TestCheck.AssertFailTest("Swap confirmation pop up not displayed");


            WaitForElementToExistByCssSelector(".js-mps-swap-type-item[data-swap-type-enum-id=\"ReplaceWithSameModel\"]");
            ReplacePcbElement.Click();
            WaitForElementToExistByCssSelector(".js-mps-swap-type-selected");
            SwapTypeNextButtonElement.Click();

            return GetInstance<DealerSetCommunicationMethodPage>();
        }
        

        public void ConfirmDifferentSwapDeviceType()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ReplaceWithDifferentModelElement == null)
                TestCheck.AssertFailTest("Swap different device pop up not displayed");

            WaitForElementToExistByCssSelector(".js-mps-swap-type-item[data-swap-type-enum-id=\"ReplaceWithSameModel\"]");
            ReplaceWithDifferentModelElement.Click();
            WaitForElementToExistByCssSelector("#MeterReadingLabel");
            try
            {
                SwapTypeNextButtonElement.Click();
            }
            catch (InvalidOperationException ioe)
            {
                ReplaceWithSameModelElement.Click();
                ReplaceWithDifferentModelElement.Click();
                WebDriver.Wait(DurationType.Millisecond, 3);
                SwapTypeNextButtonElement.Click();
            }
            
        }

        public DealerSetCommunicationMethodPage SelectANewSwapDevice(string device)
        {
            LoggingService.WriteLogOnMethodEntry(device);
            if (SwapModelDeviceSelectorElement == null)
                TestCheck.AssertFailTest("Swap model device pop up not displayed");
            SelectFromDropdown(SwapModelDeviceSelectorElement, device);

            WebDriver.Wait(DurationType.Millisecond, 5);
            SwapModelNextElement.Click();

            return GetInstance<DealerSetCommunicationMethodPage>();
        }



        public void IsSwapInstallationRequestSent()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (SwapRequestSuccessConfirmationElement == null)
                TestCheck.AssertFailTest("Swap request success confirmation is not displayed");
            AssertElementPresent(SwapRequestSuccessConfirmationElement, "Swap request installation not sent");
        }

        public void IsReinstallationRequestSent()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ReinstallRequestSuccessConfirmationElement == null)
                TestCheck.AssertFailTest("Reinstall request success confirmation is not displayed");
            AssertElementPresent(ReinstallRequestSuccessConfirmationElement, "Reinstall request installation not sent");
        }

        

        public void IsSwapDeviceLineDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var lineCount = DisplayedDevicesLineElement.Count;

            TestCheck.AssertIsEqual(true, lineCount > 1, "Swap device line is not displayed");
        }
        

        public void ClickOnCancelRequest()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CancelInstallationRequestElement == null)
                TestCheck.AssertFailTest("Cancel installation button not displayed");
            ClickAcceptOnJsAlert();
            CancelInstallationRequestElement.Click();
            ClickAcceptOnConfirmation();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void ClickAcceptOnConfirmation()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Millisecond, 1000);
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
        }

        public void IsSwapProgressTextDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(false, String.IsNullOrWhiteSpace(SwapProgressIndicatorElement.Text),
                                            "Swap progress text is not displayed");
        }

        public void ClickToExposeInstallationRequest()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ShowInstallationRequestEmailElement == null)
                TestCheck.AssertFailTest("Show Installation Request element is not displayed");
            ShowInstallationRequestEmailElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void ClickToExposeSwapInstallationRequest()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ShowInstallationRequestEmailElement == null)
                TestCheck.AssertFailTest("Show Installation Request element is not displayed");
            ClickOnActionButtonOnDisplay();
            ShowInstallationRequestEmailElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }


        public void CancelSwapInstallationRequest()
        {
            LoggingService.WriteLogOnMethodEntry();
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();

            if (ShowInstallationRequestEmailElement == null)
                TestCheck.AssertFailTest("Show Installation Request element is not displayed");
            ClickOnActionButtonOnDisplay();
            CancelInstallationRequestElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void IsSwapInstallationRequestCancelled()
        {
            LoggingService.WriteLogOnMethodEntry();
            var disp =
                IsElementPresent(GetElementByCssSelector(".js-mps-delete-remove.mps-installation-request-container"));

            TestCheck.AssertIsEqual(false, disp, "Installation request container is still displayed");
        }

        public void IsNewlySwappedDeviceDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 3);
            TestCheck.AssertIsEqual(true, ModalPopUpElement.Displayed, "Installation request pop up is opened");
           
        }

        public string GetInstallationLink()
        {
            LoggingService.WriteLogOnMethodEntry();
            var installLink = InstallerLinkElement.GetAttribute("href");
            SpecFlow.SetContext("InstallerLink", installLink);

            return installLink;

        }

        public InstallerDeviceInstallationPage LaunchInstallerPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            MpsJobRunnerPage.RunCompleteInstallationCommandJob(MpsUtil.CreatedProposal());
            Driver.Navigate().GoToUrl(GetInstallationLink());
            return GetInstance<InstallerDeviceInstallationPage>(Driver);
        }

      public void SelectCompanyLocation()
        {
            LoggingService.WriteLogOnMethodEntry();

            SelectElementOptionsByIndex(CompanyLocationElement, 1);

         

          WaitForElementToBeClickableByCssSelector("#content_1_ButtonCreateRequest", 5, 5);

        }

        public void ClickOnNextButtonToInvokeError()
        {
            LoggingService.WriteLogOnMethodEntry();
            CreateRequestElement.Click();
            
        }

        public DealerSetCommunicationMethodPage CreateInstallationRequest()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 2);
            MpsUtil.JsClickButtonThenNavigateToDifferentUrl(Driver, CreateRequestElement);
            
            return GetTabInstance<DealerSetCommunicationMethodPage>(Driver);
        }

        public void IsInstallationRequestDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            AssertElementPresent(InstallationRequestContainerElement, "Installation not finished");
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
        }

        private string Method()
        {
            LoggingService.WriteLogOnMethodEntry();
            return SpecFlow.GetContext("InstallationMethod");
        }

        public DealerCustomersExistingPage NavigateToCustomerAndContactPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CustomerAndContactTabElement == null)
                TestCheck.AssertFailTest("Customer and Contact Tab is not displayed");
            CustomerAndContactTabElement.Click();

            return GetInstance<DealerCustomersExistingPage>();
        }

        public void SendEmailForServiceRequest(string address, string subject, string model, string serial)
        {
            LoggingService.WriteLogOnMethodEntry(address,subject,model,serial);
            _subject = String.Format(_subject, subject);
            var message1 = String.Format(_body3, subject);
            var message2 = String.Format(_body9, model);
            var message3 = String.Format(_body17, serial);

            var fullBody = Body1 + _body2 + message1 + _body4 + Body5 + _body6 + Body7 + _body8 + message2 + _body10 +
                           Body11 + _body12 + Body13 + _body14 + Body15
                           + _body16 + message3 + _body18 + Body19 + _body20 + Body21 + _body22 + Body23;

            //_body = String.Format(_body, subject, model, serial);
            WebDriver.Wait(DurationType.Second, 10);
            ActionsModule.SendServiceRequestEmail(address, _subject, fullBody);
            ActionsModule.RunServiceRequestCreationJobs();
        }

        public void InstallationCompleteCheck(string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber);
            var deviceListContainer = SeleniumHelper.FindElementByCssSelector(InstallationDeviceListSelector);
            var tableContainer = SeleniumHelper.FindElementByCssSelector(deviceListContainer, InstallationDeviceTableSelector);

            var rows = SeleniumHelper.FindRowElementsWithinTable(tableContainer);
            
            foreach (var row in rows)
            {
                var serialNumberElement = SeleniumHelper.FindElementByCssSelector(row, InstallationSerialNumberSelector);
                if (serialNumberElement.Text.Equals(serialNumber))
                {
                    var connection = SeleniumHelper.FindElementByCssSelector(row, InstallationRespondingTypeSelector).Displayed;
                    TestCheck.AssertIsEqual(true, connection, "Installation is not successfully connected to BOC");
                    break;
                }
            }
        }

        public bool CheckForUpdatedPrintCount(IWebDriver driver, int totalPageCount, string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(driver,totalPageCount,serialNumber);
            int retryCount = RuntimeSettings.DefaultRetryCount;
            var retries = 0;
            var elementStatus = false;

            do
            {
                try
                {
                    var showPrintCountButtonElement = SeleniumHelper.FindElementByCssSelector(ShowPrintCountButtonSelector);
                    showPrintCountButtonElement.Click();
                    var deviceListElement = SeleniumHelper.FindElementByCssSelector(InstallationDeviceListSelector);
                    var deviceTableElement = SeleniumHelper.FindElementByCssSelector(deviceListElement, InstallationDeviceTableSelector);

                    var rows = SeleniumHelper.FindRowElementsWithinTable(deviceTableElement);

                    foreach (var row in rows)
                    {
                        var serialNumberElement = SeleniumHelper.FindElementByCssSelector(row, InstallationSerialNumberSelector);
                        var InstallationCommunicationTypeElement = SeleniumHelper.FindElementByCssSelector(row, InstallationCommunicationTypeSelector);
                        var communicationType = InstallationCommunicationTypeElement.GetAttribute("class").Contains("responding");
                        if (serialNumberElement.Text.Equals(serialNumber) && communicationType)
                        {
                            var totalPagesElement = SeleniumHelper.FindElementByCssSelector(row, InstallationTotalPagesSelector);
                            if (totalPagesElement.Text.Equals(totalPageCount.ToString()))
                            {
                                elementStatus = true;
                                return elementStatus;
                            }
                            else if (totalPagesElement.Text.Equals("8128"))
                            {
                                return false;
                            }
                        }
                    }

                }
                catch(WebDriverException e)
                {
                    if(retries > retryCount)
                    {
                        TestCheck.AssertFailTest("Updated print count for device cannnot be verified e="+e);
                    }
                }
            } while ((!elementStatus) && (retries <= retryCount));
            return elementStatus;
        }

        public void IsInstallationCompleted()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry(number1,number2,number3,number4);
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
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, LocationSelectionAlertElement.Displayed, "Location alert is not displayed"); 
        }

        public string SelectLocation()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(CompanyLocationElement);
            SelectElementOptionsByIndex(CompanyLocationElement, 1);
            string companyLocation = SeleniumHelper.SelectDropdownElementTextByIndex(CompanyLocationElement, 1);
            SeleniumHelper.WaitUntil(d => ExpectedConditions.StalenessOf(CompanyLocationElement));
            return companyLocation;
        }

        public void ClickCreateRequest()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createRequestButtonElement = SeleniumHelper.FindElementByCssSelector(CreateRequestButtonSelector);
            ScrollTo(createRequestButtonElement);
            SeleniumHelper.ClickSafety(CreateRequestElement, RuntimeSettings.DefaultFindElementTimeout, true);
        }

        public string RetrieveInstallationRequestUrl(string installerEmail, string companyLocation, string resourceInstallationStatusNotStarted)
        {
            LoggingService.WriteLogOnMethodEntry(installerEmail,companyLocation,resourceInstallationStatusNotStarted);
            var installationRequestContainer = SeleniumHelper.FindElementByCssSelector(InstallationRequestContainerSelector);
            var IRRowElementsContainer = SeleniumHelper.FindElementByCssSelector(installationRequestContainer, InstallationRequestRowSelector);
            var elements = SeleniumHelper.FindRowElementsWithinTable(IRRowElementsContainer);
            foreach(var element in elements)
            {
                var InstallerEmailElement = SeleniumHelper.FindElementByCssSelector(element, InstallationRequestEmailSelector);
                var CompanySiteElement = SeleniumHelper.FindElementByCssSelector(element, InstallationRequestCompanySiteSelector);
                var IRStatusElement = SeleniumHelper.FindElementByCssSelector(element, InstallationRequestStatusSelector);
                TestCheck.AssertIsEqual(InstallerEmailElement.Text, installerEmail, "Installer email does not match");
                TestCheck.AssertIsEqual(CompanySiteElement.Text, companyLocation, "Company location does not match");
                TestCheck.AssertIsEqual(IRStatusElement.Text, resourceInstallationStatusNotStarted, "Installation status is not equal to Not Started");
                if (InstallerEmailElement.Text.Equals(installerEmail) && CompanySiteElement.Text.Equals(companyLocation) && IRStatusElement.Text.Equals(resourceInstallationStatusNotStarted))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(element, ActionsButtonSelector);
                    SeleniumHelper.ClickSafety(ActionsButtonElement);
                    var ShowInstallationRequestButtonElement = SeleniumHelper.FindElementByCssSelector(element, InstallationRequestSelector);
                    SeleniumHelper.ClickSafety(ShowInstallationRequestButtonElement);

                    var ModalElement = SeleniumHelper.FindElementByCssSelector("div.modal-body.js-modal-body");
                    var InstallationRequestUrlElement = SeleniumHelper.FindElementByCssSelector(ModalElement, "a");
                    var url = InstallationRequestUrlElement.GetAttribute("href");

                    SeleniumHelper.ClickSafety(InstallationRequestClosePopUpElement); 
                    return url;
                }
            }
            return null;
        }

        public void ClickOnSwapDevice(string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber);

            var deviceContainer = SeleniumHelper.FindElementByCssSelector(DeviceListContainerSelector);
            var deviceListRowContainer = SeleniumHelper.FindElementByCssSelector(deviceContainer, DeviceListContainerRowSelector);
            var elements = SeleniumHelper.FindRowElementsWithinTable(deviceListRowContainer);
            foreach (var element in elements)
            {
                var DeviceSerialNumberElement = SeleniumHelper.FindElementByCssSelector(element, DeviceSerialNumberSelector);
                if (DeviceSerialNumberElement.Text.Equals(serialNumber))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(element, ActionsButtonSelector);
                    SeleniumHelper.ClickSafety(ActionsButtonElement);
                    var SwapDeviceButtonElement = SeleniumHelper.FindElementByCssSelector(element, SwapDeviceButtonSelector);
                    SeleniumHelper.ClickSafety(SwapDeviceButtonElement);
                    break;
                }
            }        
        }

        public void ConfirmSwapAndSelectSwapType(string swapType, string resourceSwapTypeReplaceWithDifferentModel)
        {
            LoggingService.WriteLogOnMethodEntry(swapType,resourceSwapTypeReplaceWithDifferentModel);

            var SwapDeviceModalElement = SeleniumHelper.FindElementByCssSelector(SwapDeviceModalSelector);
            var SwapDeviceModalConfirmElement = SeleniumHelper.FindElementByCssSelector(SwapDeviceModalElement, SwapDeviceConfirmSelector);
            SeleniumHelper.ClickSafety(SwapDeviceModalConfirmElement);
            var SwapDeviceTypesModalElement = SeleniumHelper.FindElementByCssSelector(SwapDeviceTypesSelector);
            var SwapTypeRadioButtonElement = SeleniumHelper.FindElementByDataAttributeValue(SwapDeviceTypesModalElement, SwapDeviceTypesDataAttributeSelector, swapType);
            SeleniumHelper.ClickSafety(SwapTypeRadioButtonElement);
            var SwapTypeModalNextButtonElement = SeleniumHelper.FindElementByCssSelector(SwapDeviceTypesModalElement, SwapDeviceTypesModalNextButtonSelector);
            SeleniumHelper.ClickSafety(SwapTypeModalNextButtonElement);
            if (swapType.Equals(resourceSwapTypeReplaceWithDifferentModel))
            {
                var SwapReplacementModelModalElement = SeleniumHelper.FindElementByCssSelector(SwapDeviceTypesSelector);
                var SwapReplacementModelDropdownElement = SeleniumHelper.FindElementByCssSelector(SwapReplacementModelModalElement, SwapDeviceReplacementModelListSelector);
                // TODO: Add the replacement printer model in the feature file as variable & insert the logic here to use the value
                // For now, just select the first model in the dropdown list
                SelectElementOptionsByIndex(SwapReplacementModelDropdownElement, 1);
                var SwapReplacementModelNextButtonElement = SeleniumHelper.FindElementByCssSelector(SwapReplacementModelModalElement, SwapDeviceReplacementModelNextButtonSelector);
                SeleniumHelper.ClickSafety(SwapReplacementModelNextButtonElement);    
            }
        }

        public bool VerifySwappedDeviceStatus(string serialNumber, string resourceInstalledPrinterStatusBeingReplaced)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber,resourceInstalledPrinterStatusBeingReplaced);
            bool exists = false;
            var deviceContainer = SeleniumHelper.FindElementByCssSelector(DeviceListContainerSelector);
            var deviceListRowContainer = SeleniumHelper.FindElementByCssSelector(deviceContainer, DeviceListContainerRowSelector);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(deviceListRowContainer);
            foreach (var element in deviceRowElements)
            {
                var DeviceSerialNumberElement = SeleniumHelper.FindElementByCssSelector(element, DeviceSerialNumberSelector);
                var DeviceStatusElement = SeleniumHelper.FindElementByCssSelector(element, DeviceStatusSelector);
                if (DeviceSerialNumberElement.Text.Equals(serialNumber) && DeviceStatusElement.Text.Equals(resourceInstalledPrinterStatusBeingReplaced));
                {
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        public bool EmailInstallationCompleteCheck(string resourceInstallationCompletedStatus)
        {
            LoggingService.WriteLogOnMethodEntry(resourceInstallationCompletedStatus);
            var InstallationRequestContainerElement = SeleniumHelper.FindElementByCssSelector(InstallationRequestContainerSelector);
            var InstallationRequestRowElement = SeleniumHelper.FindElementByCssSelector(InstallationRequestContainerElement, InstallationRequestRowSelector);
            var rowElements = SeleniumHelper.FindRowElementsWithinTable(InstallationRequestRowElement);

            foreach(var row in rowElements)
            {
                var IRCommunicationMethodElement = SeleniumHelper.FindElementByCssSelector(row, InstallationRequestCommunicationMethodSelector);
                var IRStatusElement = SeleniumHelper.FindElementByCssSelector(row, InstallationRequestStatusSelector);

                var communicationMethodActual = IRCommunicationMethodElement.GetAttribute("class").Contains("glyphicon-envelope");
                if(!communicationMethodActual)
                {
                    LoggingService.WriteLog(LoggingLevel.FAILURE, "The communication method is not set to Email on the Manage devices page even after email installation is completed.");
                    return false;
                }
                var statusActual = IRStatusElement.Text;
                if(statusActual!= resourceInstallationCompletedStatus)
                {
                    LoggingService.WriteLog(LoggingLevel.FAILURE, "The installation status is not turned to completed even after email installation is completed.");
                    return false;
                }
            }
            return true;
        }
    }
}
