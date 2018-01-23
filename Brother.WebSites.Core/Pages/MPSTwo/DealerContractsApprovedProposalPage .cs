using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Helpers;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    // LocalOfficeApproverAprovalProposalsApprovedPage
    public class DealerContractsApprovedProposalPage : IPageObject
    {
        private const string _url = "/mps/dealer/contracts/approved-proposals";
        private const string _validationElementSelector = "div.usabilla_live_button_container"; // TODO temp

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }
    }
}