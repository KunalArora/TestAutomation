using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class MPSJobRunnerPage
    {
        private const string uaturl = @"http://online.{0}.cms.brotherqas.eu/sitecore/admin/integration/mps2/";
        private const string testurl = @"http://online.{0}.brotherdv2.eu/sitecore/admin/integration/mps2/";
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
       
        private const string setConsumableStatusJob = @"setconsumableorderstatus.aspx?orderid={0}&statusid={1}";

        private static readonly Dictionary<string, string> authHeader = new Dictionary<string, string>
        {
            { @"X-BROTHER-Auth", @".Kol%CV#<X$6o4C4/0WKxK36yYaH10" }
        };
        
        public static void RunCreateCustomerAndPersonCommandJob()
        {
            var webSite = CoinedUrl() + customerAndPersonCommand;

            Helper.MsgOutput(String.Format("The url formed for Create Customer and Person Command is {0}", webSite));

            var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
            //TestCheck.AssertIsEqual(true, response.Equals(HttpStatusCode.OK), "");
            WebDriver.Wait(Helper.DurationType.Second, 20);
        }


        private static string CoinedUrl()
        {
            string url = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT" :
                    url = String.Format(uaturl, Helper.Locale);
                    break;

                case "TEST" :
                    url = String.Format(testurl, Helper.Locale);
                    break;
            }

            Helper.MsgOutput(String.Format("The command job url formed is {0}", url));

            return url;

        }


        public static string GetConsumableOrderStatusResetMsg(string orderid, string status)
        {
            var webSite = CoinedUrl() + setConsumableStatusJob;

            webSite = String.Format(webSite, orderid, status);

            var response = Utils.GetSuccessStringFromUrl(webSite, 5, authHeader);

            return response;
        }


        public static void RunResetSerialNumberJob(string serial)
        {
            var reset = CoinedUrl() + resetSerialNumberJob + serial;
            var response = Utils.GetPageResponse(reset, WebRequestMethods.Http.Get, authHeader);
            // TestCheck.AssertIsEqual(true, response.Equals(HttpStatusCode.OK), "");
        }


        public static void RunClickRateInvoiceCommandJob()
        {
            var webSite = CoinedUrl() + clickRateInvoiceCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }


        public static void RunCompleteInstallationCommandJob()
        {
            var webSite = CoinedUrl() + completeInstallationCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunSendClickRateInvoicesToSapCommandJob()
        {
            var webSite = CoinedUrl() + sendClickRateInvoicesToSapCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunRefreshPrintCountsCommandJob()
        {
            var webSite = CoinedUrl() + refreshPrintCountsCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunRefreshPrintCountsFromMedioCommandJob()
        {
            var webSite = CoinedUrl() + refreshPrintCountsFromMedioCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunStaffAccountCreationCommandJob()
        {
            var webSite = CoinedUrl() + staffAccountCreationCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunConsumableOrderRequestsCommandJob()
        {
                var webSite = CoinedUrl() + consumableOrderRequestsCommand;

                Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunCreateOrderAndServiceRequestsCommandJob()
        {
            var webSite = CoinedUrl() + createOrderAndServiceRequestsCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunSystemJobCreateCustomerTaxCommandJob()
        {
            
            var webSite = CoinedUrl() + systemJobCreateCustomerTaxCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
                
        }

        public static void RunSystemJobCreateCustomerAndPersonCommandJob()
        {
            var webSite = CoinedUrl() + systemJobCreateCustomerAndPersonCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunCloseConsumableOrdersCommandJob()
        {
            var webSite = CoinedUrl() + closeConsumableOrdersCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunPollConsumableOrderStatusCommandJob()
        {
            var webSite = CoinedUrl() + pollConsumableOrderStatusCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
        }

        public static void RunCheckForSilentDevicesCommandJob()
        {
            var webSite = CoinedUrl() + checkForSilentDevicesCommand;

            Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get, authHeader);
                    
        }

    }
}
