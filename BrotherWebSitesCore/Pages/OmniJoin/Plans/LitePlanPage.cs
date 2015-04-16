using BrotherWebSitesCore.Pages.Base;

namespace BrotherWebSitesCore.Pages.OmniJoin.Plans
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
