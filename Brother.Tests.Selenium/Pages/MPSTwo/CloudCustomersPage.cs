using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Properties;

namespace Brother.Tests.Selenium.Lib.Pages.MPSTwo
{
    public class CloudCustomersPage : Base.BasePage
    {
        public static string URL = "/mps/dealer/proposals/in-progress";

        public override string DefaultTitle
        {
            get { return MPSTWOMAP.Default["PageTitle"].ToString(); }
        }
    }
}
