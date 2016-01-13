using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
    public class ExperienceEditorPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }
        [FindsBy(How = How.CssSelector, Using = ".sc-applicationHeader-row1")] 
        public IWebElement LinkTextAvailable;

        [FindsBy(How = How.CssSelector, Using = "[href=\"/sitecore/shell/Applications/Content Editor.aspx?sc_bw=1\"]")]
        public IWebElement ContentEditorLink;

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div > a:nth-child(1)")]
        public IWebElement PageHeader;

        public void IsContentEditorLinkAvailable()
        {
            if (LinkTextAvailable == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(LinkTextAvailable, "Sitecore Experience Platform");
        }
        public ContentEditorPage ClickOnContentEditor(string country)
        {   
            ContentEditorLink.Click();
            return GetInstance<ContentEditorPage>();
        }
        public void IsPageHeaderDisplayed()
        {
            WaitForElementToExistByCssSelector("body > header > div > div > a:nth-child(1)");
            if (PageHeader == null)
            {
                throw new NullReferenceException("Unable to locate page header");
            }
            AssertElementPresent(PageHeader, "Page Header", 30);
        }

    }
}
