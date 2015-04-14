using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin;

namespace Brother.Tests.Selenium.Lib.Pages.OmniJoin.Plans
{
    public class BusinessPlanPage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
            get { return OmniJoinPageTitles.Default["BusinessPlanPage"] + OmniJoinPageTitles.Default["LandingPage"].ToString(); }
        }
    }
}
