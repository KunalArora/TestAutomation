using System;
using System.IO;
using System.Xml;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class Navigation : Helper
    {
        private const string LanguageLookupFile = @"LanguageLookup.xml";

        public static string ConvertButtonNameForLocale(string productString, string buttonNameString)
        {
            var country = Helper.CountryLookup(Helper.Locale);
            var xPathExpression = String.Format(@"/Lookup/Language[@Country='{0}']/ProductButtons/{1}/{2}", country, productString, buttonNameString);
            return GetMenuItemString(xPathExpression);
        }

        public static string ConvertMyAccountMenuItemForLocale(string menuItemString)
        {
            var country = Helper.CountryLookup(Helper.Locale);
            var xPathExpression = String.Format(@"/Lookup/Language[@Country='{0}']/MyAccountSideNavMenu/{1}", country, menuItemString);
            return GetMenuItemString(xPathExpression);
        }

        public static string ConvertProductMenuItemForLocale(string menuItemString)
        {
            var country = Helper.CountryLookup(Helper.Locale);
            var xPathExpression = String.Format(@"/Lookup/Language[@Country='{0}']/ProductItem/{1}", country, menuItemString);
            return GetMenuItemString(xPathExpression);
        }

        public static string ConvertPrimaryNavMenuItemForLocale(string menuItemString)
        {
            var country = Helper.CountryLookup(Helper.Locale);
            var xPathExpression = String.Format(@"/Lookup/Language[@Country='{0}']/PrimaryNavTopMenu/{1}", country, menuItemString);
            return GetMenuItemString(xPathExpression);
        }

        /// <summary>
        /// Takes an English string representing a My Account menu item and converts it to the correct language based 
        /// on the current locale.
        /// </summary>
        /// <param name="xPathExpression"></param>
        private static string GetMenuItemString(string xPathExpression)
        {
            var doc = new XmlDocument();
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            if (directoryInfo == null) return String.Empty;

            var languageLookupFile = directoryInfo.FullName + Helper.SupportingFilesLocation + LanguageLookupFile;

            try
            {
                var reader = new XmlTextReader(languageLookupFile);
                doc.Load(reader);
                reader.Close();
            }
            catch (FileNotFoundException fileNotFound)
            {
                MsgOutput("Unable to locate LanguageLookup file", fileNotFound.Message);
            }

            var root = doc.DocumentElement;
            if (root == null) return String.Empty;

            var selectSingleNode = root.SelectSingleNode(xPathExpression);
            return selectSingleNode != null ? selectSingleNode.InnerText : String.Empty;
        }
    }
}
