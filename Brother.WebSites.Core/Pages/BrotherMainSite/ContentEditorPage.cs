using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
    public class ContentEditorPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "Ribbon")]
        public IWebElement RibbonBarExist;

        [FindsBy(How = How.Id, Using = "Tree_Glyph_0DE95AE441AB4D019EB067441B7C2450")]
        public IWebElement ContentEditor;

        public void IsRibbonBarExist()
        {
            if (ContentEditor == null)
            {
                throw new NullReferenceException("Unable to locate ribbon on page");
            }
            AssertElementPresent(ContentEditor, "ShowRibbonContextMenu");
        }

        public void ClickOnContent(string country)
        {
            ContentEditor.Click();
        }
    }
}
