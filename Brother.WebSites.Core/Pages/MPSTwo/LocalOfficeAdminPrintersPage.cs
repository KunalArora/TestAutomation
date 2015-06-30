using System;
using System.Collections.Generic;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminPrintersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement SaveButtonElement;


        private IWebElement GetPrinterElement(string model)
        {
            string x = string.Format("//label[text()='{0}']/input", model);
            return Driver.FindElement(By.XPath(x));
        }

        public void EnablePrinter(string model)
        {
            IWebElement element = GetPrinterElement(model);
            if (element == null)
                throw new NullReferenceException(string.Format("Unable to locate the element of \"{0}\"", model));
            if (!element.Selected)
                element.Click();
        }

        public void DisablePrinter(string model)
        {
            IWebElement element = GetPrinterElement(model);
            if (element == null)
                throw new NullReferenceException(string.Format("Unable to locate the element of \"{0}\"", model));
            if (element.Selected)
                element.Click();
        }

        public void ClickSaveButton()
        {
            if (SaveButtonElement == null)
                throw new NullReferenceException("Unable to locate Save Button Element");
            ScrollTo(SaveButtonElement);
            SaveButtonElement.Click();
        }
        
    }
}
