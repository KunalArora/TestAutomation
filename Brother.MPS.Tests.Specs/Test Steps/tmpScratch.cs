using System;
using System.Diagnostics;
using System.Linq;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs
{
    [Binding]
    public class tmpScratch : BaseSteps
    {
        [Given(@"I am testing some code")]
        public void GivenIAmTestingSomeCode()
        {
            Utils.GrantUserRole("AutoTest_11-25-2014_15-25-56@BrotherAutoTest.com", @"extranenBrother Online Ink Supply User");
        }
    }
}
