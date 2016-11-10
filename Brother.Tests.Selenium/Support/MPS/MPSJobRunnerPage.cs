using System;
using System.Collections.Generic;
using System.Net;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace Brother.Tests.Selenium.Lib.Support.MPS
{
    public static class MpsJobRunnerPage
    {
        private const string Uaturl = @"http://online.{0}.cms.brotherqas.eu/sitecore/admin/integration/mps2/"; //@"http://online.brother.{0}.local/sitecore/admin/integration/mps2/"; 
        private const string Testurl = @"http://online.{0}.brotherdv2.eu/sitecore/admin/integration/mps2/";
        private const string CustomerAndPersonCommand = @"runcommand.aspx?command=MPS:SystemJobCreateCustomerAndPersonCommand";
        private const string ClickRateInvoiceCommand = @"runcommand.aspx?command=MPS:RaiseClickRateInvoicesCommand";
        private const string CompleteInstallationCommand = @"runcommand.aspx?command=MPS:CompleteInstallationCommand";
        private const string SendClickRateInvoicesToSapCommand = @"runcommand.aspx?command=MPS:SendClickRateInvoicesToSapCommand";
        private const string RefreshPrintCountsCommand = @"runcommand.aspx?command=MPS:RefreshPrintCountsCommand";
        private const string RefreshPrintCountsFromMedioCommand = @"runcommand.aspx?command=MPS:RefreshPrintCountsFromMedioCommand";
        private const string StaffAccountCreationCommand = @"runcommand.aspx?command=MPS:StaffAccountCreationCommand";
        private const string ConsumableOrderRequestsCommand = @"runcommand.aspx?command=MPS:ConsumableOrderRequestsCommand";
        private const string CreateOrderAndServiceRequestsCommand = @"runcommand.aspx?command=MPS:CreateOrderAndServiceRequestsCommand";
        private const string SystemJobCreateCustomerAndPersonCommand = @"runcommand.aspx?command=MPS:SystemJobCreateCustomerAndPersonCommand";
        private const string SystemJobCreateCustomerTaxCommand = @"runcommand.aspx?command=MPS:SystemJobCreateCustomerTaxCommand";
        private const string CloseConsumableOrdersCommand = @"runcommand.aspx?command=MPS:CloseConsumableOrdersCommand";
        private const string PollConsumableOrderStatusCommand = @"runcommand.aspx?command=MPS:PollConsumableOrderStatusCommand";
        private const string CheckForSilentEmailDevicesCommand = @"runcommand.aspx?command=MPS:CheckForSilentEmailDevicesCommand";
        private const string SystemJobCreateConsumableOrderCommand = @"runcommand.aspx?command=MPS:SystemJobCreateConsumableOrderCommand";
        private const string CheckForSilentMedioDevicesCommand = @"runcommand.aspx?command=MPS:CheckForSilentEmailDevicesCommand";
        private const string ResetSerialNumberJob = @"recycleserial.aspx?serial=";
        private const string SetCustomerSapIdJob = @"setcustomersapid.aspx?name={0}&sapid={1}";
        private const string SetPersonSapIdJob = @"setpersonsapid.aspx?email={0}&sapid={1}";
        private const string RemoveConsumableOrderById = @"removeconsumableorderbyid.aspx?orderid=";
        private const string RemoveConsumableOrderByInstalledPrinter = @"removeconsumableorderbyinstalledprinter.aspx?serial=";
       
        private const string SetConsumableStatusJob = @"setconsumableorderstatus.aspx?orderid={0}&statusid={1}";

        public static readonly Dictionary<string, string> AuthHeader = new Dictionary<string, string>
        {
            { @"X-BROTHER-Auth", @".Kol%CV#<X$6o4C4/0WKxK36yYaH10" }
            //{ @"X-BROTHER-Auth", @"OX6Z{mO~nQ87rE!32j6Sjo!21@+`by" }
            
        };
        
        //Device Simulator variables
        private const string DevSimUrl = @"http://localhost:8080/bvd/device/";
        private const string SetSupplyUrl = @"supply/set";
        private const string StatusChangeUrl = @"status/change?id={0}&online=true&subscribe=false";
        private const string RegisterDeviceUrl = @"register?id={0}&pin={1}";
        private const string NotifyBocUrl = @"notify?id={0}&all=true";
        private const string CreateNewDevice = @"create?model=MFC-L8650CDW&serial={0}&id={1}";
        private const string CreateNewDeviceForSpecific = @"create?model={0}&serial={1}&id={2}";
    
        
        public static void RunCreateCustomerAndPersonCommandJob()
        {
            var webSite = CoinedUrl() + CustomerAndPersonCommand;

            Helper.MsgOutput(String.Format("The url formed for Create Customer and Person Command is {0}", webSite));

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);
            
            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "CreateCustomerAndPersonCommand job ran successfully"
                : "CreateCustomerAndPersonCommand probably did not run properly");
        }

        private static string GetSavedNewDeviceSerial()
        {
            return HelperClasses.SpecFlow.GetContext("JoinedSerialNumber");
        }

        private static string GetInstallationPin()
        {
            return HelperClasses.SpecFlow.GetContext("InstallationPin");
        }

        public static void CreateNewVirtualDevice()
        {
            var newDevice = String.Format(CreateNewDevice, GetSavedNewDeviceSerial(), SetGuidForNewDevice());
            var webSite = DevSimUrl + newDevice;

            Helper.MsgOutput(String.Format("The url formed for Create New Virtual Device is {0}", webSite));

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "CreateNewVirtualDevice job ran successfully"
                : "CreateNewVirtualDevice probably did not run properly");
        }

        public static void CreateNewVirtualDevice(string device)
        {
            var newDevice = String.Format(CreateNewDeviceForSpecific, device, GetSavedNewDeviceSerial(), SetGuidForNewDevice());
            var webSite = DevSimUrl + newDevice;

            Helper.MsgOutput(String.Format("The url formed for Create New Virtual Device is {0}", webSite));

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "CreateNewVirtualDevice job ran successfully"
                : "CreateNewVirtualDevice probably did not run properly");
        }

        public static void RegisterNewDevice()
        {
            var newDevice = String.Format(RegisterDeviceUrl, GetSavedDeviceId(), GetInstallationPin());
            var webSite = DevSimUrl + newDevice;

            Helper.MsgOutput(String.Format("The url formed for Register New Device is {0}", webSite));

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RegisterNewDevice job ran successfully"
                : "RegisterNewDevice probably did not run properly");
        }

        public static void ChangeDeviceStatus()
        {
            var newDevice = String.Format(StatusChangeUrl, GetSavedDeviceId());
            var webSite = DevSimUrl + newDevice;

            Helper.MsgOutput(String.Format("The url formed for Change Device Status is {0}", webSite));

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "ChangeDeviceStatus job ran successfully"
                : "ChangeDeviceStatus probably did not run properly");
        }

        public static void SetSupplyStatusForNewPrinter()
        {
            const string webSite = DevSimUrl + SetSupplyUrl;

            Helper.MsgOutput(String.Format("The url formed for Set Supply Status is {0}", webSite));

            const string deviceWithDefaultPrintCount = "{\"name\": \"TonerInk_Black\",\"value\": \"Empty\"}," +
                                                       "{\"name\": \"PageCount\",\"value\": 1000}," +
                                                       "{\"name\": \"PageCount_Mono\",\"value\": 100}," +
                                                       "{\"name\": \"PageCount_Color\",\"value\": 900}";

            var json = "{\"id\": \"" + GetSavedDeviceId() + "\",\"items\": [" + deviceWithDefaultPrintCount + "]}";

            //var json = "{\"id\": \"{0}\",\"items\": [{1}]}";
            //json = String.Format(json, GetSavedDeviceId(), deviceWithDefaultPrintCount);

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Post, "application/json", json, AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 5);
            Helper.MsgOutput("SetSupplyStatusForNewPrinter job ran successfully");
        }

        public static void SetTonerInkStatusForNewPrinter(string tonerType)
        {
            const string webSite = DevSimUrl + SetSupplyUrl;

            Helper.MsgOutput(String.Format("The url formed for Set Supply Status is {0}", webSite));

            var toner = string.Format("TonerInk_{0}", tonerType);

            var deviceWithDefaultPrintCount = "{\"name\": \"" + toner + "\",\"value\": \"Empty\"}";

            var json = "{\"id\": \"" + GetSavedDeviceId() + "\",\"items\": [" + deviceWithDefaultPrintCount + "]}";

            
            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Post, "application/json", json, AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 5);
            Helper.MsgOutput(String.Format("SetTonerInkStatus job for {0} ran successfully", tonerType));
        }

        public static void NotifyBocOfNewChanges()
        {
           
            var newDevice = String.Format(NotifyBocUrl, GetSavedDeviceId());
            var webSite = DevSimUrl + newDevice;

            Helper.MsgOutput(String.Format("The url formed for Notify BOC of New Changes is {0}", webSite));

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "NotifyBocOfNewChanges job ran successfully"
                : "NotifyBocOfNewChanges probably did not run properly");
        }

       private static string SetGuidForNewDevice()
        {
            var guid = Guid.NewGuid();

            var deviceId = "babeface" + guid.ToString().Substring(8);
            HelperClasses.SpecFlow.SetContext("DeviceId", deviceId);

            Helper.MsgOutput(String.Format("Device Simulators Guid set as {0}", deviceId));

            return deviceId;
        }

        private static string GetSavedDeviceId()
        {
            return HelperClasses.SpecFlow.GetContext("DeviceId");
        }


        private static string CoinedUrl()
        {
            string url = null;
            var country = Helper.Locale;

            //if (country.Equals("uk"))
            //{
            //    country = "co.uk";
            //}

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT" :
                    //url = String.Format(Uaturl, Helper.Locale);
                    url = String.Format(Uaturl, country);
                    break;

                case "TEST" :
                    url = String.Format(Testurl, Helper.Locale);
                    break;
            }

            Helper.MsgOutput(String.Format("The command job url formed is {0}", url));

            return url;

        }


        public static string GetConsumableOrderStatusResetMsg(string orderid, string status)
        {
            string response = null;

            if (String.IsNullOrWhiteSpace(orderid))
            {
                var webSite = CoinedUrl() + SetConsumableStatusJob;

                webSite = String.Format(webSite, orderid, status);

                response = Utils.GetSuccessStringFromUrl(webSite, 5, AuthHeader);  
            }

            return response;
        }


        public static void RunResetSerialNumberJob(string serial)
        {
            if (String.IsNullOrWhiteSpace(serial)) return;
            var reset = CoinedUrl() + ResetSerialNumberJob + serial;
            var response = Utils.GetPageResponse(reset, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunResetSerialNumberJob job ran successfully"
                : "RunResetSerialNumberJob probably did not run properly");
        }


        public static void RunClickRateInvoiceCommandJob()
        {
            var webSite = CoinedUrl() + ClickRateInvoiceCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);
        }

        public static void RunRemoveConsumableOrderByIdJob(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) return;
            var webSite = CoinedUrl() + RemoveConsumableOrderById + id;
            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunRemoveConsumableOrderByIdJob job ran successfully"
                : "RunRemoveConsumableOrderByIdJob probably did not run properly");
        }

        public static void RunRemoveConsumableOrderByInstalledPrinterJob(string serial)
        {
            if (String.IsNullOrWhiteSpace(serial)) return;
            var webSite = CoinedUrl() + RemoveConsumableOrderByInstalledPrinter + serial;
            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunRemoveConsumableOrderByInstalledPrinterJob job ran successfully"
                : "RunRemoveConsumableOrderByInstalledPrinterJob probably did not run properly");
        }


        public static void RunCompleteInstallationCommandJob()
        {
            var webSite = CoinedUrl() + CompleteInstallationCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunCompleteInstallationCommandJob job ran successfully"
                : "RunCompleteInstallationCommandJob probably did not run properly");
        }

        public static void RunSendClickRateInvoicesToSapCommandJob()
        {
            var webSite = CoinedUrl() + SendClickRateInvoicesToSapCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunSendClickRateInvoicesToSapCommandJob job ran successfully"
                : "RunSendClickRateInvoicesToSapCommandJob probably did not run properly");
        }

        public static void RunRefreshPrintCountsCommandJob()
        {
            var webSite = CoinedUrl() + RefreshPrintCountsCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunRefreshPrintCountsCommandJob job ran successfully"
                : "RunRefreshPrintCountsCommandJob probably did not run properly");
        }

        public static void RunRefreshPrintCountsFromMedioCommandJob()
        {
            var webSite = CoinedUrl() + RefreshPrintCountsFromMedioCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunRefreshPrintCountsFromMedioCommandJob job ran successfully"
                : "RunRefreshPrintCountsFromMedioCommandJob probably did not run properly");
        }

        public static void RunStaffAccountCreationCommandJob()
        {
            var webSite = CoinedUrl() + StaffAccountCreationCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunStaffAccountCreationCommandJob job ran successfully"
                : "RunStaffAccountCreationCommandJob probably did not run properly");
        }

        public static void RunConsumableOrderRequestsCommandJob()
        {
                var webSite = CoinedUrl() + ConsumableOrderRequestsCommand;

                var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

                WebDriver.Wait(Helper.DurationType.Second, 1);

                Helper.MsgOutput(response.ToString().Equals("OK")
                    ? "RunConsumableOrderRequestsCommandJob job ran successfully"
                    : "RunConsumableOrderRequestsCommandJob probably did not run properly");
        }

        public static void RunCreateOrderAndServiceRequestsCommandJob()
        {
            var webSite = CoinedUrl() + CreateOrderAndServiceRequestsCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunCreateOrderAndServiceRequestsCommandJob job ran successfully"
                : "RunCreateOrderAndServiceRequestsCommandJob probably did not run properly");
        }

        public static void RunSystemJobCreateCustomerTaxCommandJob()
        {
            
            var webSite = CoinedUrl() + SystemJobCreateCustomerTaxCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunSystemJobCreateCustomerTaxCommandJob job ran successfully"
                : "RunSystemJobCreateCustomerTaxCommandJob probably did not run properly");
                
        }

        public static void RunSystemJobCreateCustomerAndPersonCommandJob()
        {
            var webSite = CoinedUrl() + SystemJobCreateCustomerAndPersonCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunSystemJobCreateCustomerAndPersonCommandJob job ran successfully"
                : "RunSystemJobCreateCustomerAndPersonCommandJob probably did not run properly");
        }

        public static void RunCloseConsumableOrdersCommandJob()
        {
            var webSite = CoinedUrl() + CloseConsumableOrdersCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunCloseConsumableOrdersCommandJob job ran successfully"
                : "RunCloseConsumableOrdersCommandJob probably did not run properly");
        }

        public static void RunPollConsumableOrderStatusCommandJob()
        {
            var webSite = CoinedUrl() + PollConsumableOrderStatusCommand;
            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunPollConsumableOrderStatusCommandJob job ran successfully"
                : "RunPollConsumableOrderStatusCommandJob probably did not run properly");
        }

        public static void RunCheckForSilentEmailDevicesCommandJob()
        {
            var webSite = CoinedUrl() + CheckForSilentEmailDevicesCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "RunCheckForSilentDevicesCommandJob job ran successfully"
                : "RunCheckForSilentDevicesCommandJob probably did not run properly");
                    
        }


        public static void RunCheckForSilentMedioDevicesCommandJob()
        {
            var webSite = CoinedUrl() + CheckForSilentMedioDevicesCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "CheckForSilentMedioDevicesCommand job ran successfully"
                : "CheckForSilentMedioDevicesCommand probably did not run properly");

        }

        public static void RunSystemJobCreateConsumableOrderCommandJob()
        {
            var webSite = CoinedUrl() + SystemJobCreateConsumableOrderCommand;

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: AuthHeader);

            WebDriver.Wait(Helper.DurationType.Second, 1);

            Helper.MsgOutput(response.ToString().Equals("OK")
                ? "SystemJobCreateConsumableOrderCommand job ran successfully"
                : "SystemJobCreateConsumableOrderCommand probably did not run properly");

        }
    }
}
