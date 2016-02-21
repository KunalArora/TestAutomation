using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework.Constraints;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class MPSJobRunnerPage
    {
        private const string Uaturl = @"http://online.{0}.cms.brotherqas.eu/sitecore/admin/integration/mps2/";
        private const string Testurl = @"http://online.{0}.brotherdv2.eu/sitecore/admin/integration/mps2/";
        private const string customerAndPersonCommand = @"runcommand.aspx?command=MPS:SystemJobCreateCustomerAndPersonCommand";
        private const string clickRateInvoiceCommand = @"runcommand.aspx?command=MPS:RaiseClickRateInvoicesCommand";
        private const string completeInstallationCommand = @"runcommand.aspx?command=MPS:CompleteInstallationCommand";
        private const string sendClickRateInvoicesToSapCommand = @"runcommand.aspx?command=MPS:SendClickRateInvoicesToSapCommand";
        private const string refreshPrintCountsCommand = @"runcommand.aspx?command=MPS:RefreshPrintCountsCommand";
        private const string refreshPrintCountsFromMedioCommand = @"runcommand.aspx?command=MPS:RefreshPrintCountsFromMedioCommand";
        private const string staffAccountCreationCommand = @"runcommand.aspx?command=MPS:StaffAccountCreationCommand";
        private const string consumableOrderRequestsCommand = @"runcommand.aspx?command=MPS:ConsumableOrderRequestsCommand";
        private const string createOrderAndServiceRequestsCommand = @"runcommand.aspx?command=MPS:CreateOrderAndServiceRequestsCommand";
        private const string systemJobCreateCustomerAndPersonCommand = @"runcommand.aspx?command=MPS:SystemJobCreateCustomerAndPersonCommand";
        private const string systemJobCreateCustomerTaxCommand = @"runcommand.aspx?command=MPS:SystemJobCreateCustomerTaxCommand";
        private const string closeConsumableOrdersCommand = @"runcommand.aspx?command=MPS:CloseConsumableOrdersCommand";
        private const string pollConsumableOrderStatusCommand = @"runcommand.aspx?command=MPS:PollConsumableOrderStatusCommand";
        private const string checkForSilentDevicesCommand = @"runcommand.aspx?command=MPS:CheckForSilentDevicesCommand";
        private const string resetSerialNumberJob = @"resetinstalledprinter.aspx?serial=";
        private const string setCustomerSAPIdJob = @"setcustomersapid.aspx?name={0}&sapid={1}";
        private const string setPersonSAPIdJob = @"setpersonsapid.aspx?email={0}&sapid={1}";
        private const string removeConsumableOrderById = @"removeconsumableorderbyid.aspx?orderid=";
        private const string removeConsumableOrderByInstalledPrinter = @"removeconsumableorderbyinstalledprinter.aspx?serial=";
       
        private const string setConsumableStatusJob = @"setconsumableorderstatus.aspx?orderid={0}&statusid={1}";

        private static readonly Dictionary<string, string> authHeader = new Dictionary<string, string>
        {
            { @"X-BROTHER-Auth", @".Kol%CV#<X$6o4C4/0WKxK36yYaH10" }
        };
        
        //Device Simulator variables
        private const string DevSimUrl = @"http://10.2.23.137:8080/bvd/device/";
        private const string SetSupplyUrl = @"supply/set";
        private const string StatusChangeUrl = @"status/change?id={0}&online=true&subscribe=false";
        private const string RegisterDeviceUrl = @"register?id={0}&pin={1}";
        private const string NotifyBocUrl = @"notify?id={0}&all=true";
        private const string CreateNewDevice = @"create?model=MFC-L8650CDW&serial={0}&id={1}";
    
        
        public static void RunCreateCustomerAndPersonCommandJob()
        {
            var webSite = CoinedUrl() + customerAndPersonCommand;

            Helper.MsgOutput(String.Format("The url formed for Create Customer and Person Command is {0}", webSite));

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
            
            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

        private static string GetSavedNewDeviceSerial()
        {
            return SpecFlow.GetContext("JoinedSerialNumber");
        }

        private static string GetInstallationPin()
        {
            return SpecFlow.GetContext("InstallationPin");
        }

        public static void CreateNewVirtualDevice()
        {
            var newDevice = String.Format(RegisterDeviceUrl, GetSavedNewDeviceSerial(), SetGuidForNewDevice());
            var webSite = DevSimUrl + newDevice;

            Helper.MsgOutput(String.Format("The url formed for Create New Virtual Device is {0}", webSite));

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RegisterNewDevice()
        {
            var newDevice = String.Format(CreateNewDevice, GetSavedDeviceId(), GetInstallationPin());
            var webSite = DevSimUrl + newDevice;

            Helper.MsgOutput(String.Format("The url formed for Register New Device is {0}", webSite));

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void ChangeDeviceStatus()
        {
            var newDevice = String.Format(StatusChangeUrl, GetSavedDeviceId());
            var webSite = DevSimUrl + newDevice;

            Helper.MsgOutput(String.Format("The url formed for Change Device Status is {0}", webSite));

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void SetSupplyStatusForNewPrinter()
        {
            const string webSite = DevSimUrl + SetSupplyUrl;

            Helper.MsgOutput(String.Format("The url formed for Set Supply Status is {0}", webSite));

            const string deviceWithDefaultPrintCount = "{\"name\": \"TonerInk_Black\",\"value\": \"Empty\"}," +
                                                       "{\"name\": \"PageCount\",\"value\": 1000}," +
                                                       "{\"name\": \"PageCount_Mono\",\"value\": 100}," +
                                                       "{\"name\": \"PageCount_Color\",\"value\": 900}";

            var json = "{\"id\": \"{0}\",\"items\": [{1}]}";

            json = String.Format(json, GetSavedDeviceId(), deviceWithDefaultPrintCount);

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Post, "application/json", json, authHeader);

            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

        public static void NotifyBocOfNewChanges()
        {
            var newDevice = String.Format(NotifyBocUrl, GetSavedDeviceId());
            var webSite = DevSimUrl + newDevice;

            Helper.MsgOutput(String.Format("The url formed for Notify BOC of New Changes is {0}", webSite));

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

       private static string SetGuidForNewDevice()
        {
            var guid = Guid.NewGuid();

            var deviceId = "babeface" + guid.ToString().Substring(8);
            SpecFlow.SetContext("DeviceId", deviceId);

            return deviceId;
        }

        private static string GetSavedDeviceId()
        {
            return SpecFlow.GetContext("DeviceId");
        }


        private static string CoinedUrl()
        {
            string url = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT" :
                    url = String.Format(Uaturl, Helper.Locale);
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
                var webSite = CoinedUrl() + setConsumableStatusJob;

                webSite = String.Format(webSite, orderid, status);

                response = Utils.GetSuccessStringFromUrl(webSite, 5, authHeader);  
            }
            
            return response;
        }


        public static void RunResetSerialNumberJob(string serial)
        {
            if (String.IsNullOrWhiteSpace(serial)) return;
            var reset = CoinedUrl() + resetSerialNumberJob + serial;
            var response = Utils.GetPageResponse(reset, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
            // TestCheck.AssertIsEqual(true, response.Equals(HttpStatusCode.OK), "");
        }


        public static void RunClickRateInvoiceCommandJob()
        {
            var webSite = CoinedUrl() + clickRateInvoiceCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunRemoveConsumableOrderByIdJob(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) return;
            var webSite = CoinedUrl() + removeConsumableOrderById + id;
            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunRemoveConsumableOrderByInstalledPrinterJob(string serial)
        {
            if (String.IsNullOrWhiteSpace(serial)) return;
            var webSite = CoinedUrl() + removeConsumableOrderByInstalledPrinter + serial;
            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }


        public static void RunCompleteInstallationCommandJob()
        {
            var webSite = CoinedUrl() + completeInstallationCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunSendClickRateInvoicesToSapCommandJob()
        {
            var webSite = CoinedUrl() + sendClickRateInvoicesToSapCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunRefreshPrintCountsCommandJob()
        {
            var webSite = CoinedUrl() + refreshPrintCountsCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunRefreshPrintCountsFromMedioCommandJob()
        {
            var webSite = CoinedUrl() + refreshPrintCountsFromMedioCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunStaffAccountCreationCommandJob()
        {
            var webSite = CoinedUrl() + staffAccountCreationCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunConsumableOrderRequestsCommandJob()
        {
                var webSite = CoinedUrl() + consumableOrderRequestsCommand;

                Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunCreateOrderAndServiceRequestsCommandJob()
        {
            var webSite = CoinedUrl() + createOrderAndServiceRequestsCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunSystemJobCreateCustomerTaxCommandJob()
        {
            
            var webSite = CoinedUrl() + systemJobCreateCustomerTaxCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
                
        }

        public static void RunSystemJobCreateCustomerAndPersonCommandJob()
        {
            var webSite = CoinedUrl() + systemJobCreateCustomerAndPersonCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunCloseConsumableOrdersCommandJob()
        {
            var webSite = CoinedUrl() + closeConsumableOrdersCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunPollConsumableOrderStatusCommandJob()
        {
            var webSite = CoinedUrl() + pollConsumableOrderStatusCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
        }

        public static void RunCheckForSilentDevicesCommandJob()
        {
            var webSite = CoinedUrl() + checkForSilentDevicesCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, additionalHeaders: authHeader);
                    
        }
    }
}
