using System;
using System.Diagnostics;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs
{
    [Binding]
    public class tmpScratch : BaseSteps
    {
        [Given(@"SqlCall")]
        public void GivenSqlCall()
        {
            var foo = Utils.GetOrpActivationCode("SQL");
        }

        [Given(@"Setup")]
        public void Setup()
        {
//            BasePage.LoadBolHomePage(CurrentDriver, "ie.brotherdv2.eu", "");

//            CurrentDriver.Navigate().GoToUrl(@"http://www.brother.ch/imprimantes\imprimantes-laser");
//            Helper.MsgOutput(TestController.CurrentDriver.Url);

//            StartGrid();
//            AddHubNode("headlessDriver");
//            AddHubNode("chromeDriver");
//            //AddHubNode("ffDriver");
//            //AddHubNode("ieDriver");
//            //AddHubNode("headlessDriver");

//            //StartRemoteWebDriver("127.0.0.1", "4444", "phantomjs");
//            StartRemoteWebDriver("127.0.0.1", "4444", "chrome");
//            StartRemoteWebDriver("127.0.0.1", "4444", "firefox");
//            StartRemoteWebDriver("127.0.0.1", "4444", "ie");
////            StartRemoteWebDriver("127.0.0.1", "4444", "phantomjs");

        }

        public void AddHubNode(string browserDriverName)
        {
            string webDriver = string.Empty;

            switch (browserDriverName)
            {
                case "chromeDriver":
                    webDriver = @"-Dwebdriver.chrome.driver=C:\Projects\Test\Drivers\chromedriver.exe";
                    break;
                case "ffDriver":
                    webDriver = @"-Dwebdriver.chrome.driver=C:\Projects\Test\Drivers\firefoxdriver.exe";
                    break;
                case "ieDriver":
                    webDriver = @"-Dwebdriver.chrome.driver=C:\Projects\Test\Drivers\IEDriverServer.exe";
                    break;
                case "headlessDriver":
                    webDriver = @"-Dwebdriver.chrome.driver=C:\Projects\Test\Drivers\phantomjs.exe";
                    break;
            }

            var arguments =
                string.Format(
                    @"-jar C:\Projects\Test\Selenium\Server\selenium-server-standalone-2.45.0.jar -role node -hub http://localhost:4444/grid/register {0}", webDriver);
            
            const string hubFilename = @"C:\Program Files\Java\jre1.8.0_20\bin\java.exe ";

            var process = new Process
            {
                StartInfo = { Arguments = arguments, FileName = hubFilename, CreateNoWindow = false }
            }; 

            if (process.Start())
            {

            }   

        }

        private void StartGrid()
        {
            var process = new Process
            {
                StartInfo = {Arguments = @"-jar C:\Projects\Test\Selenium\Server\selenium-server-standalone-2.45.0.jar -role hub", FileName = @"C:\Program Files\Java\jre1.8.0_20\bin\java.exe", CreateNoWindow = false}
            };
            if (process.Start())
            {
                
            }
        }

        //private static DesiredCapabilities SetDesiredCapabilities(string browserDriver)
        //{
        //    var capabilities = DesiredCapabilities.PhantomJS();
        //    capabilities.SetCapability("acceptSslCerts", true);
        //    capabilities.SetCapability("javascriptEnabled", true);
        //    capabilities.SetCapability("unexpectedAlertBehaviour", "Accept");
        //    capabilities.SetCapability("platform", "WINDOWS");
        //    capabilities.SetCapability("web-security", false);
        //    capabilities.SetCapability("ignore-sss-errors", true);
        //    capabilities.SetCapability("unexpectedAlertBehaviour", "accept");
        //    capabilities.SetCapability("browserName", browserDriver);

        //    if (capabilities.IsJavaScriptEnabled)
        //    {
        //        Helper.MsgOutput("Driver Capabilities", "Javascript support is Enabled");
        //    }

        //    return capabilities;
        //}

        //public static IWebDriver StartRemoteWebDriver(string ipAddress, string port, string browserName)
        //{
        //    var uri = string.Format(@"http://{0}:{1}/wd/hub", ipAddress, port);
        //    var capabilities = SetDesiredCapabilities(browserName);
        //    IWebDriver newDriver;
        //    try
        //    {
        //        newDriver = new RemoteWebDriver(new Uri(uri), capabilities);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new SpecFlowSeleniumException(string.Format("{0} - {1}", "Unable to Connect to GhostDriver via RemoteWebDriver", ex.Message));
        //    }
        //    return newDriver;
        //}
    }
}
