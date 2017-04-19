using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public static class MultipleLanguageSwitcher
    {
        private const string GermanUrl = @"online.de";
        private const string AustriaUrl = @"online.at";
        private const string EnglandUrl = @"online.uk";
        private const string FranceUrl = @"online.fr";
        private const string ItalyUrl = @"online.it";
        private const string SpainUrl = @"online.es";
        private const string IrelandUrl = @"online.ie";
        private const string PolandUrl = @"online.pl";
        private const string NetherlandUrl = @"online.nl";
        private const string SwedenUrl = @"online.se";
        private const string BelgiumUrl = @"online.be";
        private const string SwissUrl = @"online.ch";
        private const string FinlandUrl = @"online.fi";
        private const string DenmarkUrl = @"online.dk";
        private const string NorwayUrl = @"online.no";
        private const string EnglandProdUrl = @".co.uk";
        private const string MultipleLanguages = @".mps-lang > span > a";
        private const string SwitchedLanguageIdentifier = @"a[href='/mps/dealer/contracts'] .media-body .media-heading";
        private const string SwitchedLoLanguageIdentifier = @"a[href='/mps/local-office/approval'] .media-body .media-heading";


        
        private static IList<IWebElement> MultipleLanguagesElement(ISearchContext driver)
        {
            return driver.FindElements(By.CssSelector(MultipleLanguages));
        }

        private static IWebElement SwitchedLanguageIdentifierElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(SwitchedLanguageIdentifier));
        }

        private static IWebElement SwitchedLoLanguageIdentifierElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(SwitchedLoLanguageIdentifier));
        }

        public static void SwitchMultiplelanguages(IWebDriver driver, string language)
        {

            if (language==String.Empty)
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            
            if (driver.Url.Contains("dealer"))
            {
                SwitchBetweenDealerMultipleLanguages(driver, language);
            }
            else if (driver.Url.Contains("local-office"))
            {
                SwitchBetweenLoApproverMultipleLanguages(driver, language);
            }

            SpecFlow.SetContext("BelgianLanguage", language);
        }

        private static void SwitchBetweenDealerMultipleLanguages(IWebDriver driver, string language)
        {
            if (driver.Url.Contains(BelgiumUrl))
            {
                SwitchBelgianLanguage(driver, language);
            }
            else if (driver.Url.Contains(FinlandUrl))
            {
                SwitchFinnishLanguage(driver, language);
            }
            else if (driver.Url.Contains(SwissUrl))
            {
                SwitchSwissLanguage(driver, language);
            }

        }

        private static void SwitchBetweenLoApproverMultipleLanguages(IWebDriver driver, string language)
        {
            if (driver.Url.Contains(BelgiumUrl))
            {
                SwitchLoOfficeBelgianLanguage(driver, language);
            }
            else if (driver.Url.Contains(FinlandUrl))
            {
                SwitchLoOfficeFinnishLanguage(driver, language);
            }
            else if (driver.Url.Contains(SwissUrl))
            {
                SwitchLoOfficeSwissLanguage(driver, language);
            }

         }

        private static void SwitchBelgianLanguage(IWebDriver driver, string lang)
        {
            if (lang.Equals("French"))
            {
                MultipleLanguagesElement(driver).First().Click();
                IsSwitchedLanguageSelected(driver, "Contrats");
            }
            else if (lang.Equals("Dutch"))
            {
                MultipleLanguagesElement(driver).Last().Click();
                IsSwitchedLanguageSelected(driver, "Contracten");
            }
        }

        private static void SwitchSwissLanguage(IWebDriver driver, string lang)
        {
            if (lang.Equals("Deutsch"))
            {
                MultipleLanguagesElement(driver).First().Click();
                IsSwitchedLanguageSelected(driver, "Verträge");
            }
            else if (lang.Equals("Français"))
            {
                MultipleLanguagesElement(driver).Last().Click();
                IsSwitchedLanguageSelected(driver, "Contrats");
            }
        }

        private static void SwitchFinnishLanguage(IWebDriver driver, string lang)
        {
            if (lang.Equals("Suomi"))
            {
                MultipleLanguagesElement(driver).First().Click();
                IsSwitchedLanguageSelected(driver, "Sopimukset");
            }
            else if (lang.Equals("Svenska"))
            {
                MultipleLanguagesElement(driver).Last().Click();
                IsSwitchedLanguageSelected(driver, "Avtal");
            }
        }


        private static void SwitchLoOfficeBelgianLanguage(IWebDriver driver, string lang)
        {
            if (lang.Equals("French"))
            {
                MultipleLanguagesElement(driver).First().Click();
                IsSwitchedLanguageSelected(driver, "Acceptation");
            }
            else if (lang.Equals("Dutch"))
            {
                MultipleLanguagesElement(driver).Last().Click();
                IsSwitchedLanguageSelected(driver, "Goedkeuring");
            }
        }

        private static void SwitchLoOfficeFinnishLanguage(IWebDriver driver, string lang)
        {
            if (lang.Equals("Suomi"))
            {
                MultipleLanguagesElement(driver).First().Click();
                IsSwitchedLanguageSelected(driver, "Hyväksyminen");
            }
            else if (lang.Equals("Svenska"))
            {
                MultipleLanguagesElement(driver).Last().Click();
                IsSwitchedLanguageSelected(driver, "Godkännande");
            }
        }

        private static void SwitchLoOfficeSwissLanguage(IWebDriver driver, string lang)
        {
            if (lang.Equals("Deutsch"))
            {
                MultipleLanguagesElement(driver).First().Click();
                IsSwitchedLanguageSelected(driver, "Freigabe");
            }
            else if (lang.Equals("Français"))
            {
                MultipleLanguagesElement(driver).Last().Click();
                IsSwitchedLanguageSelected(driver, "Acceptation");
            }
        }

        private static void IsSwitchedLanguageSelected(IWebDriver driver, string text)
        {
            try
            {
                SeleniumHelper.WaitForElementToExistByCssSelector(".mps-lang > span > a", 3, 5);

                var languageSwitch = driver.Url.Contains("dealer")
                ? SwitchedLanguageIdentifierElement(driver)
                : SwitchedLoLanguageIdentifierElement(driver);

                SeleniumHelper.AssertElementContainsText(languageSwitch, text,
                                    String.Format("The word displayed was {0}", languageSwitch.Text));
            }
            catch (StaleElementReferenceException e)
            {
                throw new Exception("The page refreshed and the element became stale with the following error" + e);

            }
        }
       
    }
}
