using Brother.WebSites.Core.Pages.Base;

namespace Brother.WebSites.Core.Pages.OmniJoin.Plans
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
