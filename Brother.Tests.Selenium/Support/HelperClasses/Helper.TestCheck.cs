using NUnit.Framework;
using System;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class TestCheck : Helper
    {
        public static void AssertIsGreater(int comparable1, int comparable2, string validationMessage)
        {
            MsgOutput("Validating if value is greater");
            Assert.Greater(comparable1, comparable2, validationMessage);
        }

        public static void AssertIsNotNullOrEmpty(string itemToValidate, string validationMessage)
        {
            MsgOutput("Validating if string is NOT Null or Empty");
            //Assert.IsNotNullOrEmpty(itemToValidate, validationMessage);
            Assert.That(itemToValidate, Is.Not.Null.Or.Empty, validationMessage);
        }

        public static void AssertIsNullOrEmpty(string itemToValidate, string validationMessage)
        {
            MsgOutput("Validating if string is Null or Empty");
            //Assert.IsNullOrEmpty(itemToValidate, validationMessage);
            Assert.That(itemToValidate, Is.Null.Or.Empty, validationMessage);
        }

        public static void AssertIsEqual(object expectedValue, object actualValue, string validationMessage)
        {
            Assert.AreEqual(expectedValue, actualValue, string.Format("[{0}] validation didn't match expectations. Expected [{1}], Actual [{2}]",
                        validationMessage, expectedValue, actualValue));
        }

        public static void AssertIsNotNull(object itemToCheck, string validationMessage)
        {
            if (itemToCheck == null)
            {
                throw new AssertionException(
                    string.Format(
                        "AssertIsNotNull Failed: [{0}] validation didn't match expectations. Expected Not Null, Actual [{1}]",
                        validationMessage, itemToCheck));
            }
        }

        public static void AssertIsNull(object itemToCheck)
        {
            Assert.IsNull(itemToCheck);
        }

        public static void AssertFailTest(string validationMessage)
        {
           Assert.Fail(validationMessage);
        }

        public static void AssertTextContains(string actualText, string expectedText)
        {
            if (!actualText.Contains(expectedText))
            {
                throw new AssertionException(
                    string.Format(
                        "AssetTextContains Failed: Value for [{0}] did not match expectations. Expected: [{1}] ",
                        actualText, expectedText));
            }
        }

        public static void AssertIsNotEqual(object expectedValue, object actualValue, string validationMessage)
        {
            Assert.AreNotEqual(expectedValue, actualValue, string.Format("AssertIsNotEqual Failed: [{0}] validation didn't match expectations. Expected [{1}], Actual [{2}]",
                        validationMessage, expectedValue, actualValue));
        }

        public static void AssertTextContains(string textSnippet, string containingString, string validationMessage)
        {
            if (!containingString.Contains(textSnippet))
            {
                throw new AssertionException(
                    string.Format(
                        "AssertTextContains Failed: [{0}] didn't match expectations. String [{1}] should have contained the text snippet [{2}]",
                        validationMessage, containingString, textSnippet));
            }
        }

        public static void AssertIsEqualDouble(double expected, double actual, int decimalPlaces, string message)
        {
            var threshold = double.Parse("0." + new String('0', decimalPlaces - 1) + "1");
            var actualDiff = Math.Abs(actual - expected);
            if( actualDiff < threshold) { return; }
            Assert.AreEqual(expected, actual, message+ " decimalPlaces="+ decimalPlaces); // = Assert.Fail
        }

        public static void AssertIsEqualValueInvariant(string invariantExpected, string invariantActual, string message=null, int decimalPlaces = 2)
        {
            double invariantExpectedDouble = Math.Round(double.Parse(invariantExpected), decimalPlaces, MidpointRounding.AwayFromZero);
            double invariantActualDouble = Math.Round(double.Parse(invariantActual), decimalPlaces, MidpointRounding.AwayFromZero);

            Assert.AreEqual(invariantExpectedDouble, invariantActualDouble, message + " decimalPlaces=" + decimalPlaces);
        }
    }
}
