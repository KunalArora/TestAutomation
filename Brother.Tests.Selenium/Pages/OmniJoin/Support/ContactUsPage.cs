using Brother.Tests.Selenium.Lib.Pages.Base;

namespace Brother.Tests.Selenium.Lib.Pages.OmniJoin.Support
{
    public class ContactUsPage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
            get { return OmniJoinPageTitles.Default["ContactUsPage"] + OmniJoinPageTitles.Default["LandingPage"].ToString(); }
        }
    }
}
