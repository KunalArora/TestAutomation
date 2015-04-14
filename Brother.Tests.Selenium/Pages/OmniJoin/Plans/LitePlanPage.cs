using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Basket;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin.Trial;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.OmniJoin.Plans
{
    public class LitePlanPage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
            get { return OmniJoinPageTitles.Default["LitePlanPage"] + OmniJoinPageTitles.Default["LandingPage"].ToString(); }
        }
       
    }
}
