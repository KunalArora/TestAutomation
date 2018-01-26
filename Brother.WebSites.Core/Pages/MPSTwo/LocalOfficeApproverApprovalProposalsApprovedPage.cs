using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalProposalsApprovedPage : BasePage,IPageObject
    {
        private const string _url = "/mps/local-office/approval/proposals/approved";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/approval/proposals/approved\"]";// list Next as "#DataTables_Table_0_next"

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }



        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }
    }
}
