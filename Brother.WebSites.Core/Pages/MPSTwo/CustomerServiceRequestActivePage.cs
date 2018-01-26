using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CustomerServiceRequestActivePage : BasePage, IPageObject
    {
        public static string _url = "/mps/customer/service-requests/active";
        private const string _validationElementSelector = ".js-mps-service-request-list-container"; 

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

        // id=content_1_ServiceRequestListFilter_InputFilterBy
        [FindsBy(How = How.CssSelector, Using = ".mps-filter-search-field")]
        public IWebElement FilterSearchFieldElement;
        // for item count
        [FindsBy(How = How.CssSelector, Using = "[id*=_ServiceRequestList_List_Row_]")]
        public IList<IWebElement> List_Row;

        // ex.  <td id="content_1_ServiceRequestList_List_SerialNumber_0">A3P145590</td>
        [FindsBy(How = How.CssSelector, Using = "[id*=_ServiceRequestList_List_SerialNumber_]")]
        public IList<IWebElement> List_SerialNumber;
        // ex.  <td id="content_1_ServiceRequestList_List_Model_0">DCP-8110DN</td>
        [FindsBy(How = How.CssSelector, Using = "[id*=_ServiceRequestList_List_Model_]")]
        public IList<IWebElement> List_Model;
        // ex.  <td id="content_1_ServiceRequestList_List_RequestType_0">General machine use</td>
        [FindsBy(How = How.CssSelector, Using = "[id*=_ServiceRequestList_List_RequestType_]")]
        public IList<IWebElement> List_RequestType;
        // ex.  <td id="content_1_ServiceRequestList_List_Subject_0">Changing supplies</td>
        [FindsBy(How = How.CssSelector, Using = "[id*=_ServiceRequestList_List_Subject_]")]
        public IList<IWebElement> List_Subject;
        // ex.  <td id="content_1_ServiceRequestList_List_Date_0" data-sort="2017-12-01T02:23:19Z">01/12/2017 02:23</td>
        [FindsBy(How = How.CssSelector, Using = "[id*=_ServiceRequestList_List_Date_]")]
        public IList<IWebElement> List_Date;


    }
}
