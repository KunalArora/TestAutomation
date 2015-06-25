using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
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

        static public void SetObject<T>(string key, T data) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, data);
                var json = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
                SetContext(key, json);
            }
        }

        static public T GetObject<T>(string key) where T : class
        {
            var json = GetContext(key);
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return serializer.ReadObject(ms) as T;
            }
        }
    }
}
