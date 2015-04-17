using OpenQA.Selenium;

namespace Brother.Tests.Selenium.Lib.Support.Misc
{
    public class WebDriverPackage
    {
        public IWebDriver Driver { get; set; }
        public int HeadlessProcess { get; set; }
    }
}
