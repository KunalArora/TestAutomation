using Brother.WebSites.Core.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalContractsApprovedProposalsPage : LocalOfficeApproverContractsPage, IPageObject
    {
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/approval/contracts/approved-proposals\"]"; // list Next as "#DataTables_Table_0_next"
        private const string _url = "/mps/local-office/approval/contracts/approved-proposals";

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper
        {
            get; set;
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
