using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline;
using Brother.Tests.Selenium.Lib.Properties;

namespace Brother.Tests.Selenium.Lib.Pages.MPSOne
{
    public class ConsumablePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["HomePage"].ToString(); }
        }

    }
}
