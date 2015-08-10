using System;
using System.Collections.Generic;
using System.Diagnostics;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs
{
    [Binding]
    public class tmpScratch : BaseSteps
    {
        [Given(@"I want to run multiple instances of PhantomJs")]
        public void GivenIWantToRunMultipleInstancesOfPhantomJs()
        {
            var ipAddress = "127.0.0.1";
            var port = "5500";

            var drivers = new IWebDriver[10];
            var driverId = 0;

            foreach (var driver in drivers)
            { 
                var portNum = Convert.ToInt32(port);
                portNum++;
                port = Convert.ToString(portNum);
                TestController.StartNewPhantomJsProcess(ipAddress, port);
                WebDriver.Wait(Helper.DurationType.Second, 1);
                drivers[driverId] = TestController.StartNewRemoteWebDriver(ipAddress, port);
                //drivers[driverId] = TestController.StartNewRemoteWebDriver("4444", port);
                WebDriver.Wait(Helper.DurationType.Second, 1);
                driverId++;
            }

            driverId = 0;
            foreach (var driver in drivers)
            {
                drivers[driverId].Navigate().GoToUrl("www.brother.co.uk");
                driverId++;
            }

            TestController.KillPhantomJsIfRunning();
        }

  
        [Given(@"SqlCall")]
        public void GivenSqlCall()
        {
            var dealerEmail = "ORP_Cushty_Dealer_001@guerrillamail.com";
            var dealerId = Sql.GetOrpDealerId(dealerEmail);
            TestCheck.AssertIsNotEqual(Guid.Empty, dealerId, "Dealer Id");

            var activationCode = Sql.GetOrpActivationCode(dealerId, 12, 1, "Order28052015");
            if (activationCode == string.Empty)
            {
                TestCheck.AssertFailTest(string.Format("Unable to retrieve Activation Code for Dealer [{0}]", dealerEmail));
            }
        }
    }
}
