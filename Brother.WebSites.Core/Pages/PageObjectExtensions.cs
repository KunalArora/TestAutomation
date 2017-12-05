using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Brother.WebSites.Core.Pages
{
    public static class PageObjectExtensions
    {
        public static void ClickSafely(this IPageObject pageObject)
        {
            //pageObject.SeleniumHelper.ClickSafely()
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class IgnoreParse : System.Attribute { }

    public static class PageElementValueCollectExtensions
    {
        public static IEnumerable<string> CollectDigitOnly(this IList<IWebElement> ellist)
        {
            var ans = ellist.Select(d => d.CollectDigitOnly());
            return ans;
        }
        public static string CollectDigitOnly(this IWebElement element)
        {
            return new Regex(@"[^0-9]").Replace(element.Text, "");

        }

        public static IEnumerable<T> CreateElementValueList<T>(this object page, Func<IWebElement, string> toValueFunc = null)
        {
            return CreateElementValueDictionary<T>(page, toValueFunc).Values.ToList();
        }
        public static Dictionary<IList<string>, T> CreateElementValueDictionary<T>(this object page, Func<IWebElement, string> toValueFunc = null)
        {
            var regx = new Regex(@"content_(?<RegIndexA>[0-9]*)[^0-9]*(?<RegIndexB>[0-9]*)[^0-9]*(?<RegIndexC>[0-9]*)");
            var pageType = page.GetType();
            var pageFields = pageType.GetFields();
            var itemType = typeof(T);
            var itemProperties = itemType.GetProperties();
            var resultDict = new Dictionary<IList<string>, T>(new MyEqualityComparer());
            if (toValueFunc == null)
            {
                toValueFunc = new Func<IWebElement, string>(element => element.Text);
            }
            foreach (var propertyInfo in itemProperties)
            {
                if(  propertyInfo.GetCustomAttribute(typeof(IgnoreParse)) != null)
                {
                    continue;
                }
                const BindingFlags bindingFields = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField;
                var pageElementList = (IList<IWebElement>)pageType.InvokeMember(propertyInfo.Name, bindingFields, null, page, null);

                foreach (var pageElement in pageElementList)
                {
                    var elementId = pageElement.GetAttribute("id");
                    var elementValue = toValueFunc(pageElement);
                    var elementMatch = regx.Match(elementId);
                    var dictKey = CreateDicKey(elementMatch);
                    if (resultDict.ContainsKey(dictKey) == false)
                    {
                        resultDict[dictKey] = (T)Activator.CreateInstance(typeof(T));
                    }
                    var item = resultDict[dictKey];
                    itemType.InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, item, new object[] { elementValue });
                }
            }
            return resultDict;
        }

        private static IList<string> CreateDicKey(Match idMatch)
        {
            var idlist = new List<string>();
            (new[] { "RegIndexA", "RegIndexB", "RegIndexC" }).All(d => { idlist.Add(idMatch.Groups[d].Value); return true; });
            return idlist;
        }

        private class MyEqualityComparer : IEqualityComparer<IList<string>>
        {
            public bool Equals(IList<string> x, IList<string> y)
            {
                if (x.Count != y.Count) { return false; }
                for (int loc = 0; loc < x.Count; loc++)
                {
                    if (x[loc] != y[loc])
                    {
                        return false;
                    }
                }
                return true;
            }


            public int GetHashCode(IList<string> list)
            {
                unchecked
                {
                    int hash = 19;
                    foreach (var item in list)
                    {
                        hash = hash * 31 + item.GetHashCode();
                    }
                    return hash;
                }
            }
        }

    }
}
