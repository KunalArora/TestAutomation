using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
   public class CloseAccountPage :BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["CloseAccountPage"].ToString(); }
        }

       [FindsBy(How = How.Id, Using = "content_2_innercontent_1_reasonDropDwn")]
        public IWebElement ReasonForCancellationDDownList;

       [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_1_CloseBtn")]
       public IWebElement CloseAccountButton;

       [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_1_SentMailContent>p")]
       public IWebElement EmailSentMessageContent;

       public void SelectReasonForCancellationDropDownList(string reasonForDropDownList)
       {
           SelectFromDropdown(ReasonForCancellationDDownList, reasonForDropDownList);
           AssertItemIsSelected(ReasonForCancellationDDownList, reasonForDropDownList, "reason for cancellation dropdownlist");
       }

       public CloseAccountPage ClickCloseAccountButton()
       {
           if (CloseAccountButton == null)
           {
            throw  new Exception("unable to locate button");
           }
           CloseAccountButton.Click();
           return GetInstance<CloseAccountPage>(Driver);
       }

       public void IsEmailSentMessageDisplayed()
       {
           TestCheck.AssertIsEqual(true, EmailSentMessageContent.Displayed, " Is email sent message displayed");
       }
       
    }
}
