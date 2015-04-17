using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Brother.Tests.Selenium.Lib.Support
{
    public class WebDriverPackage
    {
        public IWebDriver Driver { get; set; }
        public int HeadlessProcess { get; set; }
    }
}
