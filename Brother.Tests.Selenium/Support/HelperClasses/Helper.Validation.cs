using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Xml;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class Validation : Helper
    {
        public class ValidationSet
        {
            public string ValidationString { get; set; }
            public bool HasExceededMaxChars { get; set; }
            public bool IsErrorExpected { get; set; }

            public ValidationSet(string value, bool maxCharsExceeded, bool isErrorExpected)
            {
                ValidationString = value;
                HasExceededMaxChars = maxCharsExceeded;
                IsErrorExpected = isErrorExpected;
            }
        }

        private const string InformationBar = ".info-bar";
        private const string WarningBar = ".warning-bar";
        private const string ErrorMsg = ".error";

        public enum ValidationType {Valid, Invalid};
        public enum MessageBar {Warning, Information};

        private static IWebElement GetMessageBar(MessageBar messageBarType)
        {
            const int retryCount = 5;
            const int timeout = 5;

            switch (messageBarType)
            {
                case MessageBar.Information:
                    if (SeleniumHelper.WaitForElementToExistByCssSelector(InformationBar, retryCount, timeout))
                    {
                        return TestController.CurrentDriver.FindElement(By.CssSelector(InformationBar));
                    }
                    break;

                case MessageBar.Warning:
                    if (SeleniumHelper.WaitForElementToExistByCssSelector(WarningBar, retryCount, timeout))
                    {
                        return TestController.CurrentDriver.FindElement(By.CssSelector(WarningBar));
                    }
                    break;
            }
            return null;
        }


        public static bool ValidateInformationMessageBarStatus(bool expectedDisplayResult)
        {
            var isDisplayed = GetMessageBar(MessageBar.Information).Displayed;
            return isDisplayed == expectedDisplayResult;
        }

        public static bool ValidateWarningMessageBarStatus(bool expectedDisplayResult)
        {
            var isDisplayed = false;
            var messageBar = GetMessageBar(MessageBar.Warning);
            if (messageBar == null)
            {
                MsgOutput("Warning Message Bar was not present");
            }
            else
            {
                isDisplayed = messageBar.Displayed;
            }
            return isDisplayed == expectedDisplayResult;
        }

        public static void CheckForErrorNotifications(bool notificationExpected)
        {
            var errorsPresent = false;
            var errors = TestController.CurrentDriver.FindElements(By.CssSelector(ErrorMsg));
            foreach (var error in errors)
            {
                if (error.Displayed)
                {
                    errorsPresent = true;
                }
            }
            TestCheck.AssertIsEqual(notificationExpected, errorsPresent, "Error notification present");
        }

        /// <summary>
        /// Validation lookup. Takes an xml string representing a form field and returns a validation
        /// string based on the current locale.
        /// </summary>
        /// <param name="xPathExpression"></param>
        /// <param name="validationLookupFile"></param>
        public static List<ValidationSet> GetValidationItems(string xPathExpression, string validationLookupFile)
        {
            var validationStringList = new List<ValidationSet>();
            validationStringList.Clear();
            var doc = new XmlDocument();
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            if (directoryInfo == null) return validationStringList;

            var validationFile = directoryInfo.FullName + SupportingFilesLocation + validationLookupFile;

            try
            {
                var reader = new XmlTextReader(validationFile);
                doc.Load(reader);
                reader.Close();
            }
            catch (FileNotFoundException fileNotFound)
            {
                MsgOutput("Unable to locate Validation file", fileNotFound.Message);
            }

            var root = doc.DocumentElement;
            if (root == null) return validationStringList;

            var nodeList = root.SelectNodes(xPathExpression);
            if (nodeList == null) return validationStringList;
            foreach (XmlNode node in nodeList)
            {
                var validationSet = new ValidationSet(string.Empty, false, false);
                var xmlAttrCollection = node.Attributes;
                if (xmlAttrCollection != null)
                {
                    validationSet.HasExceededMaxChars = Convert.ToBoolean(xmlAttrCollection["MaxCharsExceeded"].Value);
                    validationSet.ValidationString = xmlAttrCollection["Value"].Value;
                    validationSet.IsErrorExpected = Convert.ToBoolean(xmlAttrCollection["ExpectErrorResult"].Value);
                }
                validationStringList.Add(validationSet);
            }

            return validationStringList;
        }

        //public void ValidateFormField(IWebElement field, List<string> validationStrings)
        //{
        //    field.Clear();
        //    field.SendKeys(validationStrings + Keys.Tab);
        //    if (maxCharsExceeded.Equals("True"))
        //    {
        //        Assert.AreNotEqual(validationStrings, GetTextBoxValue("PhoneNumberText"), "Phone Number Text Box");
        //    }
        //    break;
        //}
    }
}
