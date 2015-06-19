using Brother.WebSites.Core.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerEditProposalPage : BasePage
    {
        public static string Url = "/mps/dealer/proposals/create/description";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }
    }
}
