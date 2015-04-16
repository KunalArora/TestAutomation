using Brother.Tests.Selenium.Lib.Properties;
using BrotherWebSitesCore.Pages.Base;

namespace BrotherWebSitesCore.Pages.MPSTwo
{
    public class CloudCustomersPage : BasePage
    {
        public static string URL = "/mps/dealer/proposals/in-progress";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }
    }
}
