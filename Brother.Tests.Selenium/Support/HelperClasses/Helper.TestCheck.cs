using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class TestCheck : Helper
    {
        public static void AssertIsNotNullOrEmpty(string itemToValidate, string validationMessage)
        {
            MsgOutput("Validating if string is NOT Null or Empty");
            Assert.IsNotNullOrEmpty(itemToValidate, validationMessage);
        }

        public static void AssertIsNullOrEmpty(string itemToValidate, string validationMessage)
        {
            MsgOutput("Validating if string is Null or Empty");
            Assert.IsNullOrEmpty(itemToValidate, validationMessage);
        }

        public static void AssertIsEqual(object expectedValue, object actualValue, string validationMessage)
        {
            if (!expectedValue.Equals(actualValue))
            {
                throw new AssertionException(string.Format("AssertIsEqual Failed: {0} validation didn't match expectations. Expected [{1}], Actual [{2}]", validationMessage, expectedValue, actualValue));
            }
        }

        public static void AssertIsNotNull(object itemToCheck, string validationMessage)
        {
            if (itemToCheck == null)
            {
                throw new AssertionException(string.Format("AssertIsNotNull Failed: {0} validation didn't match expectations. Expected Null, Actual [{0}]", validationMessage, itemToCheck));
            }
        }

        public static void AssertFailTest(string validationMessage)
        {
            Assert.Fail(validationMessage);
        }

        public static void AssertTextContains(string actualText, string expectedText)
        {
            if (!actualText.Contains(expectedText))
            {
                throw new AssertionException(string.Format("AssetTextContains Failed: Value for '{0}' did not match expectations. Expected: [{1}] ", actualText, expectedText));
            }
        }

        public static void AssertIsNotEqual(object expectedValue, object actualValue, string validationMessage)
        {
            if (expectedValue.Equals(actualValue))
            {
                throw new AssertionException(string.Format("AssertIsNotEqual Failed: {0} validation didn't match expectations. Expected [{1}], Actual [{2}]", validationMessage, expectedValue, actualValue));
            }
        }

        public static void AssertTextContains(string textSnippet, string containingString, string validationMessage)
        {
            if (!containingString.Contains(textSnippet))
            {
                throw new AssertionException(string.Format("AssertTextContains Failed: '{0}' didn't match expectations. String [{1}] should have contained the text snippet [{2}]", validationMessage, containingString, textSnippet));
            }
        }
    }
}
