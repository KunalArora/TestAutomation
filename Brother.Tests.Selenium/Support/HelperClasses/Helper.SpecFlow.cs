using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class SpecFlow : Helper
    {
        public static string GetContext(string contextKey)
        {
            return ScenarioContext.Current[contextKey].ToString();
        }

        public static void SetContext(string contextKey, string value)
        {
            ScenarioContext.Current[contextKey] = value;
        }

        public static IEnumerable GetEnumerator()
        {
            return ScenarioContext.Current.AsEnumerable();
        }
    }
}
