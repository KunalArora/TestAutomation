using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public abstract class MPSJobRunnerPage
    {
        private const string uaturl = @"http://online.uk.cms.brotherqas.eu/sitecore/admin/projects/mps2/";
        private const string testurl = @"http://online.uk.brotherdv2.eu/sitecore/admin/projects/mps2/";
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
        
        public static void RunCreateCustomerAndPersonCommandJob()
        {

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + customerAndPersonCommand;

                    WebDriver.Wait(Helper.DurationType.Second, 10);
                    var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                   // TestCheck.AssertIsEqual(true, response.Equals(HttpStatusCode.OK), "");
                    
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + customerAndPersonCommand;

                    WebDriver.Wait(Helper.DurationType.Second, 10);
                    var response = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                    //TestCheck.AssertIsEqual(true, response.Equals(HttpStatusCode.OK), "");
                    
                }
                    break;
            }
        }


        public static void RunResetSerialNumberJob(string serial)
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT" :
                {
                    var reset = uaturl + resetSerialNumberJob + serial;
                    var response = Utils.GetPageResponse(reset, WebRequestMethods.Http.Get);
                    // TestCheck.AssertIsEqual(true, response.Equals(HttpStatusCode.OK), "");
                }
                    break;
                case "TEST":
                    {
                        var reset = testurl + resetSerialNumberJob + serial;
                        var response = Utils.GetPageResponse(reset, WebRequestMethods.Http.Get);
                        // TestCheck.AssertIsEqual(true, response.Equals(HttpStatusCode.OK), "");
                    }
                    break;
            }
        }


        public static void RunClickRateInvoiceCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + clickRateInvoiceCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + clickRateInvoiceCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
            }
        }


        public static void RunCompleteInstallationCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + completeInstallationCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + completeInstallationCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
            }
        }

        public static void RunSendClickRateInvoicesToSapCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + sendClickRateInvoicesToSapCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + sendClickRateInvoicesToSapCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
            }
        }

        public static void RunRefreshPrintCountsCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + refreshPrintCountsCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + refreshPrintCountsCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
            }
        }

        public static void RunRefreshPrintCountsFromMedioCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + refreshPrintCountsFromMedioCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + refreshPrintCountsFromMedioCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
            }
        }

        public static void RunStaffAccountCreationCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + staffAccountCreationCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + staffAccountCreationCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
            }
        }

        public static void RunConsumableOrderRequestsCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + consumableOrderRequestsCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + consumableOrderRequestsCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
            }
        }

        public static void RunCreateOrderAndServiceRequestsCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + createOrderAndServiceRequestsCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + createOrderAndServiceRequestsCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
            }
        }

        public static void RunSystemJobCreateCustomerTaxCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                {
                    const string webSite = uaturl + systemJobCreateCustomerTaxCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
                case "TEST":
                {
                    const string webSite = testurl + systemJobCreateCustomerTaxCommand;

                    Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                }
                    break;
            }
        }

        public static void RunSystemJobCreateCustomerAndPersonCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    {
                        const string webSite = uaturl + systemJobCreateCustomerAndPersonCommand;

                        Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                    }
                    break;
                case "TEST":
                    {
                        const string webSite = testurl + systemJobCreateCustomerAndPersonCommand;

                        Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                    }
                    break;
            }
        }

        public static void RunCloseConsumableOrdersCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    {
                        const string webSite = uaturl + closeConsumableOrdersCommand;

                        Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                    }
                    break;
                case "TEST":
                    {
                        const string webSite = testurl + closeConsumableOrdersCommand;

                        Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                    }
                    break;
            }
        }

        public static void RunPollConsumableOrderStatusCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    {
                        const string webSite = uaturl + pollConsumableOrderStatusCommand;

                        Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                    }
                    break;
                case "TEST":
                    {
                        const string webSite = testurl + pollConsumableOrderStatusCommand;

                        Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                    }
                    break;
            }
        }

        public static void RunCheckForSilentDevicesCommandJob()
        {
            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    {
                        const string webSite = uaturl + checkForSilentDevicesCommand;

                        Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                    }
                    break;
                case "TEST":
                    {
                        const string webSite = testurl + checkForSilentDevicesCommand;

                        Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
                    }
                    break;
            }
        }

    }
}
