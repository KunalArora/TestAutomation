using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;

namespace Brother.Tests.Selenium.Lib.Pages.OmniJoin.Plans
{
    public class ProfessionalPlanPage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
            get { return OmniJoinPageTitles.Default["ProfessionalPlanPage"] + OmniJoinPageTitles.Default["LandingPage"].ToString(); }
        }
    }
}
