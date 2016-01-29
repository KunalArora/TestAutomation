using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
   public class EditUsersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".btn-add-colleague.button-aqua")]
        public IWebElement AdduserButton;

        [FindsBy(How = How.CssSelector, Using = "#txtEmail")]
        public IWebElement AddNewUserEmailAddressTxtBox;

        [FindsBy(How = How.CssSelector, Using = ".check-email.button-blue")]
        public IWebElement NextButton;

        [FindsBy(How = How.CssSelector, Using = "#txtFirstName")]
        public IWebElement FirstNameTxtBox;

        [FindsBy(How = How.CssSelector, Using = "#txtLastName")]
        public IWebElement LastNameTxtBox;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnSumbit")]
        public IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = ".add-colleague-message .box-out p")]
        public IWebElement SuccessMessage;

        [FindsBy(How = How.CssSelector, Using = ".add-colleague-message.dp-pop-up.cf .lightbox-close")]
        public IWebElement MessageClose;

        [FindsBy(How = How.CssSelector, Using = ".odd>td")]
        public IWebElement CreatedUsersinList;

       public void IsAddUserButtonDisplayed()
       {
           if (AdduserButton == null)
           {
               throw new NullReferenceException("Unable to locate the button");
           }
           TestCheck.AssertIsEqual(true, AdduserButton.Displayed ,"Is adduser button displayed");
       }
       public EditUsersPage AdduserButtonClick()
        {
           if (AdduserButton == null)
           {
               throw new NullReferenceException("Add new colleague button");
           }

           AdduserButton.Click();
           return GetInstance<EditUsersPage>(Driver);

         }
       public void PopulateAddNewUserEmailAddressTxtBox(string emailAddress)
        {
           if (emailAddress.Equals(string.Empty))
           {
               emailAddress = Email.GenerateUniqueEmailAddress();
               SpecFlow.SetContext("NewUser Email Address", emailAddress);
           }

           AddNewUserEmailAddressTxtBox.SendKeys(emailAddress);
        }
        public void  EnterFirstNameTextBox(string firstName)
         {
            if (FirstNameTxtBox == null)
            {
                throw new NullReferenceException("Unable to locate firstname textbox");
            }
            FirstNameTxtBox.SendKeys(firstName);
            FirstNameTxtBox.SendKeys(Keys.Tab);
         }
        public EditUsersPage ClickNextButton()
        {
            if (NextButton == null)
            {
                throw new NullReferenceException("unable to locate next button");
            }
            NextButton.Click();
            return GetInstance<EditUsersPage>(Driver);

        }
         public void EnterLastNameTextBox(string lastName)
         {
            if (LastNameTxtBox == null)
            {
                throw new NullReferenceException("Unable to locate lastName textbox");
            }
            LastNameTxtBox.SendKeys(lastName);
            LastNameTxtBox.SendKeys(Keys.Tab);
         }
         public EditUsersPage ClickSubmitButton()
         {
             if (SubmitButton == null)
             {
                 throw new NullReferenceException("Unable to locate element");
             }
             SubmitButton.Click();
             return GetInstance<EditUsersPage>(Driver);
         }
         public void IsSuccessMessageDisplayed()
         {
             TestCheck.AssertIsEqual(true, SuccessMessage.Displayed, "Is Success Message Displayed");
         }

         public EditUsersPage PopUpMessageClose()
         {
             if (MessageClose == null)
             {
                 throw new NullReferenceException("Unable to locate popup message close icon");
             }
             MessageClose.Click();
             return GetInstance<EditUsersPage>(Driver);
         }

         public void IsUserEmailAddressDisplayed()
         {
             var createdUserEmail = SpecFlow.GetContext("New user Email Address");

             var newlyGenerated = CreatedEmailActionButton(createdUserEmail);

             var newlyGeneratedColleague = FindElementByJs(newlyGenerated);

             TestCheck.AssertIsEqual(true, newlyGeneratedColleague.Displayed, "");

         }

         private static string CreatedEmailActionButton(string user)
         {
             return String.Format("return $('td:contains(\"{0}\")')",
                 user);
         }

         public void IsCreatedUsersinListDisplayed()
         {
             TestCheck.AssertIsEqual(true, CreatedUsersinList.Displayed, "Is Created User list Displayed");
             IsUserEmailAddressDisplayed();

         }
       }
    }

