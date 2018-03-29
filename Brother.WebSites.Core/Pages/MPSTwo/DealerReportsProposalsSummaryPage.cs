using Brother.WebSites.Core.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerReportsProposalsSummaryPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_0_ButtonBack";
        private const string _url = "/mps/dealer/reports/proposal-summary";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

    }
}
