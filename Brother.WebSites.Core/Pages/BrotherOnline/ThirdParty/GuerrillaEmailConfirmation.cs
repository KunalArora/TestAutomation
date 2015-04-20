﻿using System;
using System.Net;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.ThirdParty
{
    public class BrotherEmail
    {
        public IWebElement EmailElement { get; set; }
        public IWebElement EmailCheckboxElement { get; set; }
        public IWebElement EmailAddressElement { get; set; }
        public IWebElement EmailSubjectElement { get; set; }
        public string EmailAddress { get; set; }
        public string EmailSubject{ get; set; }

        public BrotherEmail()
        {
            EmailElement = null;
            EmailCheckboxElement = null;
            EmailAddressElement = null;
            EmailSubjectElement = null;
            EmailAddress = string.Empty;
            EmailSubject = string.Empty;
        }

    }
    
    public class GuerillaEmailConfirmationPage : BasePage
    {
        public static string Url = @"https://www.guerrillamail.com/inbox";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#forget_button")]
        public IWebElement ForgetMeButton;

        [FindsBy(How = How.CssSelector, Using = "#inbox-id")]
        public IWebElement EmailEditBox;

        [FindsBy(How = How.CssSelector, Using = ".save.button.small")]
        public IWebElement SetEmailButton;

        [FindsBy(How = How.CssSelector, Using = "#gm-host-select")]
        public IWebElement DomainSelectionList;

        [FindsBy(How = How.CssSelector, Using = "#del_button")]
        public IWebElement DeleteEmailButton;

        [FindsBy(How = How.CssSelector, Using = "#back_to_inbox_link")]
        public IWebElement BackToInboxButton;

        [FindsBy(How = How.CssSelector, Using = ".email_list_form #email_table #email_list")]
        public IWebElement InBox;
        
        public IWebElement IsEmailListAvailable()
        {
            ResetEmailToCurrent();
            IWebElement emailList = null;
            int retryCount = 1;
            while (((emailList == null) && (retryCount < 5)))
            {
                try
                {
                    WaitForElementToExistByCssSelector(".email_list_form #email_table #email_list");
                    emailList = Driver.FindElement(By.CssSelector(".email_list_form #email_table #email_list"));
                }
                catch (StaleElementReferenceException staleElement)
                {
                    MsgOutput(string.Format("Stale Element thrown looking for Email Inbox List. Exception was [{0}]", staleElement.Message));
                    retryCount++;
                }
                catch (ElementNotVisibleException elementNotVisible)
                {
                    MsgOutput(string.Format("Element not visible exception thrown looking for Email Inbox List. Exception was [{0}]", elementNotVisible.Message));
                    retryCount++;
                }
            }

            AssertElementPresent(emailList, "Email List");
            return emailList;
        }

        public bool DeleteGuerrillaWelcomeMail()
        {
            try
            {
                WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0,0,0,30));
                var welcomeMail = Driver.FindElement(By.CssSelector("#mr_1 .td1"));
                if (welcomeMail != null)
                {
                    // now retrieve the checkbox for this email
                    var checkbox = Driver.FindElement(By.CssSelector("#mr_1 .td1 input"));
                    if (checkbox == null)
                    {
                        MsgOutput("Could not locate welcome email or checkbox. Email might have been deleted");
                    }
                    else
                    {
                        if (checkbox.Selected)
                        {
                            DeleteEmailButton.Click();
                        }
                        else
                        {
                            checkbox.Click();
                            DeleteEmailButton.Click();
                        }
                        welcomeMail = Driver.FindElement(By.CssSelector("#mr_1 .td1"));
                        if (welcomeMail.Text.ToLower().Contains("welcome to guerrilla mail"))
                        {
                            MsgOutput("Something went wrong as the Welcome email was not deleted");
                            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
                            return false;
                        }
                    }
                }
            }
            catch (NoSuchElementException)
            {
                MsgOutput("Could not locate Welcome email or checkbox. Email might have been deleted");
                WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
            }
            MsgOutput("Welcome email deleted");
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
            return true;
        }

        public bool IsBackToInboxButtonAvailable()
        {
            try
            {
                BackToInboxButton = Driver.FindElement(By.CssSelector("#back_to_inbox_link"));
                if (BackToInboxButton == null)
                {
                    throw new NullReferenceException("Unable to locate Back To Inbox Button on page");
                }
                //AssertElementPresent(BackToInboxButton, "Back To Inbox Button");
                return true;
            }
            catch (ElementNotVisibleException)
            {
                Helper.MsgOutput("Back To Inbox button not available");
                return false;
            }
            catch (NoSuchElementException)
            {
                Helper.MsgOutput("Back To Inbox button not available");
                return false;
            }
        }

        public void IsForgetMeButtonAvailable()
        {
            if (ForgetMeButton == null)
            {
                throw new NullReferenceException("Unable to locate Forget Me Button on page");
            }
            AssertElementPresent(ForgetMeButton, "Forget Me Button");
        }

        private void ResetEmailToCurrent()
        {
            SetEmailText(Email.RegistrationEmailAddress);
            SelectEmailDomain(Email.RegistrationEmailDomain.ToLower().Replace("@", string.Empty));
        }

        public void IsSetEmailButtonAvailable()
        {
            SetEmailButton = Driver.FindElement(By.CssSelector(".save.button.small"));
            if (SetEmailButton == null)
            {
                throw new NullReferenceException("Unable to locate Set Email Button on page");
            }
            AssertElementPresent(SetEmailButton, "Set Email Button");
        }

        public bool IsDeleteEmailButtonAvailable()
        {
            try
            {
                var deleteEmailButton = Driver.FindElement(By.CssSelector("#del_button"));
            }
            catch (NoSuchElementException elementNotFound)
            {
                Helper.MsgOutput("Could not locate Delete Email Button", elementNotFound.Message);
                return false;
            }
            return true;
        }

        private static void CheckCorrectUrlDomain(string url)
        {
            TestCheck.AssertIsEqual(true, url.Contains(Helper.CurrentDomain), "Correct URL Domain");
        }

        public void CheckAllEmailLinks()
        {
            WebDriver.Wait(Helper.DurationType.Second, 2); // brief pause for email to load
            var emailLinks = Driver.FindElements(By.CssSelector(".email a[href]"));
            if (emailLinks.Count > 0)
            {
                Helper.MsgOutput(string.Format("Checking {0} email links for valid responses", emailLinks.Count));
                foreach (var emailLink in emailLinks)
                {
                    var href = emailLink.GetAttribute("href");
                    if (emailLink.Text == string.Empty) continue;
                    if (href.ToLower().Contains("policy"))
                    {
                        //NOTE: Guerrilla mail intercepts the Brother Policy link and adds its own domain
                        Helper.MsgOutput("Skipping Policy link as Guerrilla email intecepts with incorrect domain");
                    }
                    else
                    {
                        if ((href.ToLower().Contains("account")) || (href.ToLower().Contains("sign") || (href.ToLower().Contains("sc_")))
)                        {
                            Helper.MsgOutput("Skipping account and sign-in validation link checking as we will validate those anyway by using the link direct");
                        }
                        else
                        {
                            CheckCorrectUrlDomain(href);
                            Helper.MsgOutput(string.Format("Validating Link [{0}]", href));
                            var responseCode = Utils.GetPageResponse(href, "HEAD", 10);
                            TestCheck.AssertIsEqual(HttpStatusCode.OK, responseCode, "HttpStatusCode");
                        }
                    }
                }
            }
            else
            {
                Helper.MsgOutput("Email contains no links to validate");
            }
        }

        public void EmailEditBoxClick()
        {
            EmailEditBox = Driver.FindElement(By.CssSelector("#inbox-id"));
            if (EmailEditBox == null)
            {
                throw new NullReferenceException("Unable to locate Email Edit Box on page");
            }
            EmailEditBox.Click();
        }

        private bool PopulateEmailEditControl(string email)
        {
            WebDriver.Wait(Helper.DurationType.Second, 1);
            var script = string.Format("return $('#inbox-id').text(\"{0}\")", email);
            return RunScript(script) != null;
        }

        private void SetCurrentEmail()
        {
            const string setButtonClick = "return $('.save.button.small').click()";
            const string emailEditClick = "return $('#inbox-id').click()";
            
            RunScript(setButtonClick);
            WebDriver.Wait(Helper.DurationType.Second, 1);
            RunScript(emailEditClick);
            WebDriver.Wait(Helper.DurationType.Second, 1);
            RunScript(setButtonClick);
        }

        public void SetEmailText(string email)
        {
            if (EmailEditBox == null)
            {
                throw new NullReferenceException("Unable to locate Email Edit Box on page");
            }

            MoveToElement(Driver, EmailEditBox);
            // Set the email subject via jQuery as it is the only viable method
            PopulateEmailEditControl(email);
            SetCurrentEmail();
            Helper.MsgOutput(string.Format("Setting email to [{0}]", email));
        }

        public void SelectEmailDomain(string domain)
        {
            DomainSelectionList = Driver.FindElement(By.CssSelector("#gm-host-select"));
            if (DomainSelectionList == null)
            {
                throw new NullReferenceException("Unable to selection email domain from domain list");
            }
            SelectFromDropdownByValue(DomainSelectionList, domain);
            Helper.MsgOutput(string.Format("Setting email Domain to [{0}]", domain));
        }

        private IWebElement ValidateEmailSubject(IWebElement emailItem, string emailSubject)
        {
            var newEmailSubject = string.Empty;

            switch (emailSubject)
            {
                case "Registration":
                    Language.GetRegistrationEmailSubject(Helper.Locale, out newEmailSubject);
                    break;
                case "Password":
                    break;
                case "Update":
                    break;
                case "Important":
                    break;
                
            }
            return emailItem.Text.ToLower().Contains(newEmailSubject.ToLower()) ? emailItem : null;
        }

        private bool FindEmail(string emailSubject, out BrotherEmail foundEmail)
        {
            var emailFound = false;
            var retryCount = 0;
            IWebElement foundEmailElement = null;
            foundEmail = new BrotherEmail();

            while ((!emailFound) && (retryCount != 5))
            {
                IsEmailListAvailable();
                try
                {
                    WebDriver.Wait(Helper.DurationType.Second, 2);
                    if (WaitForElementToExistByCssSelector(".mail_row"))
                    {
                        var inboxItems = Driver.FindElements(By.CssSelector(".mail_row"));
                        foreach (var emailItem in inboxItems)
                        {
                            if (!emailItem.Text.ToUpper().Contains(emailSubject.ToUpper())) continue;
                            foundEmailElement = emailItem;
                            emailFound = true;
                        }
                    }

                    if (!emailFound)
                    {
                        Helper.MsgOutput(string.Format("Unable to locate valid emails in Inbox, retrying [{0}] times", retryCount));
                        retryCount++;
                    }
                    else
                    {
                        retryCount++;
                    }
                }
                catch (StaleElementReferenceException staleElement)
                {
                    MsgOutput(string.Format("Stale Element thrown retrieving email items [{0}]. Retrying [{1}] times", staleElement.Message, retryCount));
                    retryCount++;
                }
            }

            if (!emailFound)
            {
                return false;
            }

            foundEmail.EmailElement = foundEmailElement;
            foundEmail.EmailCheckboxElement = Driver.FindElement(By.CssSelector(".mail_row .td1"));
            foundEmail.EmailAddressElement = Driver.FindElement(By.CssSelector(".mail_row .td2"));
            foundEmail.EmailSubjectElement = Driver.FindElement(By.CssSelector(".mail_row .td3"));

            return true;
        }

        private IWebElement GetInboxItems()
        {
            var emailFound = false;
            var retryCount = 0;
            IWebElement emailItemFound = null;
            while ((!emailFound) && (retryCount != 5))
            {
                IsEmailListAvailable();
                try
                {
                    WebDriver.Wait(Helper.DurationType.Second, 2);
                    if (WaitForElementToExistByCssSelector("[id*=mr_] .td1 input"))
                    {
                        var inboxItems = Driver.FindElements(By.CssSelector("[id*=mr_]"));
                        foreach (var emailItem in inboxItems)
                        {
                            if ((emailItem.GetAttribute("id").Contains("mr_")) &&
                                (!emailItem.GetAttribute("id").Equals("mr_1")))
                            {
                                emailItemFound = emailItem;
                                emailFound = true;
                            }
                        }

                        if (!emailFound)
                        {
                            Helper.MsgOutput(
                                string.Format("Unable to locate valid emails in Inbox, retrying [{0}] times",
                                    retryCount));
                            retryCount++;
                        }
                    }
                    else
                    {
                        retryCount++;
                    }
                }
                catch (StaleElementReferenceException staleElement)
                {
                    MsgOutput(string.Format("Stale Element thrown retrieving email items [{0}]. Retrying [{1}] times",
                        staleElement.Message, retryCount));
                    retryCount++;
                }
            }

            return emailItemFound;
        }

        public void SelectEmail2(string email)
        {
            MsgOutput(string.Format("Searching for email [{0}]", email));
            var emailSelected = false;
            var retryCount = 0;
            var displayedRetryCount = 0;
            var foundMail = new BrotherEmail();

            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0));
            while ((!emailSelected) && (retryCount != 5))
            {
                try
                {
                    if (FindEmail(email, out foundMail))
                    {
                        foundMail.EmailAddressElement.Click();
                        WebDriver.Wait(DurationType.Second, 2);
                        while ((foundMail.EmailAddressElement.Displayed == true) && (displayedRetryCount < 15))
                        {
                            foundMail.EmailAddressElement.Click();
                            WebDriver.Wait(DurationType.Second, 1);
                            if (foundMail.EmailAddressElement.Displayed == false)
                            {
                                displayedRetryCount++;
                                MsgOutput(string.Format("Failed to select email - retrying [{0}] times",
                                displayedRetryCount));
                            }
                        }

                        if (!foundMail.EmailAddressElement.Displayed)
                        {
                            emailSelected = true;
                        }

                        if (IsBackToInboxButtonAvailable())
                        {
                            emailSelected = true;
                        }
                    }
                }
                catch (StaleElementReferenceException staleElement)
                {
                    MsgOutput(string.Format("Stale Element [{0}] thrown whilst trying to select [{1}] email from Inbox", staleElement.Message, email));
                    retryCount++;
                }
                catch (NoSuchElementException noSuchElement)
                {
                    MsgOutput(string.Format("Element not found [{0}] whilst trying to select [{1}] email from Inbox", noSuchElement, email));
                    retryCount++;
                }
            }

            TestCheck.AssertIsEqual(false, foundMail.EmailAddressElement.Displayed, "Is Email Item Displayed");
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
        }

        public void SelectEmail(string email)
        {
            MsgOutput(string.Format("Searching for email [{0}]", email));
            IWebElement emailItem = null;
            var emailSelected = false;
            var retryCount = 0;
            var displayedRetryCount = 0;
            var foundMail = new BrotherEmail();

            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0));
            while ((!emailSelected) && (retryCount != 5))
            {
                try
                {
                    WebDriver.Wait(DurationType.Second, 2);
                    IWebElement inboxItem = GetInboxItems();
                    if (inboxItem == null)
                    {
                        throw new NullReferenceException(string.Format("SelectEmail:Unable to locate emails in inbox"));
                    }

                    emailItem = ValidateEmailSubject(inboxItem, email);
                    if (emailItem == null)
                    {
                        throw new NullReferenceException(string.Format("Unable to locate email subject \"{0}\"", email));
                    }

                    MsgOutput("Subject email found, moving to Element");

                    MoveToElement(emailItem);
                    emailItem.Click();
                    WebDriver.Wait(DurationType.Second, 2);
                    while ((emailItem.Displayed == true) && (displayedRetryCount < 15))
                    {
                        emailItem.Click();
                        WebDriver.Wait(DurationType.Second, 1);
                        if (emailItem.Displayed == false)
                        {
                            displayedRetryCount++;
                            MsgOutput(string.Format("Failed to select email - retrying [{0}] times",
                            displayedRetryCount));
                        }
                    }

                    if (!emailItem.Displayed)
                    {
                        emailSelected = true;
                    }

                    if (IsBackToInboxButtonAvailable())
                    {
                        emailSelected = true;
                    }
                }
                catch (StaleElementReferenceException staleElement)
                {
                    MsgOutput(string.Format("Stale Element [{0}] thrown whilst trying to select [{1}] email from Inbox", staleElement.Message, email));
                    retryCount++;
                }
                catch (NoSuchElementException noSuchElement)
                {
                    MsgOutput(string.Format("Element not found [{0}] whilst trying to select [{1}] email from Inbox", noSuchElement.Message, email));
                    retryCount++;
                }
            }

            TestCheck.AssertIsEqual(false, emailItem.Displayed, "Is Email Item Displayed");
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
        }

        private void ValidateEmailUrl(string errorMessage, bool deleteEmailAfterValidation, bool closeEmailAfterValidation)
        {
            var validationUrl = GetEmailValidationLink();
            if (validationUrl == string.Empty)
            {
                MsgOutput(string.Format("Invalid {0} URL", errorMessage));
            }
            else
            {
                if (deleteEmailAfterValidation)
                {
                    DeleteEmail();
                }
                LaunchValidationLinkInNewTab(validationUrl, closeEmailAfterValidation);
            }
        }

        private void LaunchValidationLinkInNewTab(string url, bool closeEmailAfterValidation)
        {
            var currentHandleCount = Driver.WindowHandles.Count;
            var currentWindow = Driver.CurrentWindowHandle;
            var newHandleCount = 0;
            var newTabWindow = string.Empty;

            // Create a new tab and launch the validation URL into this tab
            ((IJavaScriptExecutor)Driver).ExecuteScript(string.Format("window.open('{0}','_blank');", url));

            newHandleCount = Driver.WindowHandles.Count;
            if (currentHandleCount < newHandleCount)
            {
                foreach (var window in Driver.WindowHandles)
                {
                    if (window != currentWindow)
                    {
                        if (closeEmailAfterValidation)
                        {
                            Driver.SwitchTo().Window(currentWindow);
                            Driver.Close();
                            Driver.SwitchTo().Window(window);
                        }
                        else
                        {
                            Driver.SwitchTo().Window(window);
                            Driver.Close();
                            Driver.SwitchTo().Window(currentWindow);
                        }
                    }
                }
            }
        }

        public RegistrationPage ValidatePasswordResetEmail()
        {
            ValidateEmailUrl("Password Reset Email", true, true);
            return GetInstance<RegistrationPage>(Driver, "", "");
        }

        public MyOrdersPage ValidateOmniJoinMyAccountPlanChangeEmail()
        {
            ValidateEmailUrl("My Account", true, true);
            return GetInstance<MyOrdersPage>(Driver, "", "");
        }

        public MyOrdersPage ValidateOrderEmail()
        {
            ValidateEmailUrl("Basket", true, true);
            return GetInstance<MyOrdersPage>(Driver, "", "");
        }

        public void ValidateActivationCodeEmail()
        {
            //Assert.AreEqual();
        }

        public MySignInDetailsPage ValidateAccountDetailsChangeEmail()
        {
            ValidateEmailUrl("Account Details Change", true, true);
            return GetInstance<MySignInDetailsPage>(Driver, "", "");
        }


        public RegistrationPage ValidateRegistrationEmail()
        {
            ValidateEmailUrl("Account Validation", true, true);
            return GetInstance<RegistrationPage>(Driver, "", "");
        }

        public bool CheckDealerPortalActivationCodes(int qty)
        {
            var emailDisplay = Driver.FindElement(By.CssSelector("#display_email"));
            WaitUpTo(40, () => IsElementPresent(emailDisplay), "Email Display Window");
            if (!emailDisplay.Displayed) return false;
            try
            {
                //var url = Driver.FindElement(By.CssSelector("[href*='online']")).GetAttribute("href");
                //return url;
            }
            catch (StaleElementReferenceException staleElement)
            {
                MsgOutput("Error retrieving account validation url", staleElement.Message);
            }
            return false;
        }

        public void DeleteEmail(string emailSubject)
        {
            var emailToDelete = new BrotherEmail();

            if (!IsDeleteEmailButtonAvailable())
            {
                if (!IsBackToInboxButtonAvailable())
                {
                    TestCheck.AssertFailTest(string.Format("Unable to delete email {0}", emailToDelete.EmailSubject));
                }
            }

            var inboxItems = Driver.FindElements(By.CssSelector("[id*=mr_]"));

            var emailNotDeleted = true;
            while (emailNotDeleted)
            {
                try
                {
                    if (!FindEmail(emailSubject, out emailToDelete)) continue;
                    WebDriver.Wait(DurationType.Second, 1);
//                    var email = emailToDelete.EmailElement.FindElement(By.XPath("//input[@type='checkbox']"));
                    //if (!emailToDelete.EmailElement.Selected)
                    emailToDelete.EmailCheckboxElement.Click();
                    if (!emailToDelete.EmailElement.Selected)
                    {
                        while (!emailToDelete.EmailElement.Selected)
                        {
                            // select email for deletion
                            emailToDelete.EmailCheckboxElement.Click();
                            FindEmail(emailSubject, out emailToDelete);
                        }
                    }
                    else
                    {
                        emailNotDeleted = false;
                    }
                }
                catch (StaleElementReferenceException elementNoLongerAttached)
                {
                    MsgOutput(string.Format("Email Message not found [{0}] as element now stale - retrying", elementNoLongerAttached.Message));
                }
            }
            DeleteEmailButtonClick();
        }

        public void DeleteEmail()
        {
            BackToInboxButtonClick();
            IsDeleteEmailButtonAvailable();
            foreach (IWebElement email in Driver.FindElements(By.XPath("//input[@type='checkbox']")))
            {
                WebDriver.Wait(Helper.DurationType.Second, 1);
                if (email.Selected) continue;
                while (!email.Selected)
                {
                    // select email for deletion
                    email.Click();
                }
            }
            DeleteEmailButtonClick();
        }

        private string GetEmailValidationLink()
        {
            var emailDisplay = Driver.FindElement(By.CssSelector("#display_email"));
            WaitUpTo(40, () => IsElementPresent(emailDisplay), "Email Display Window");
            if (!emailDisplay.Displayed) return string.Empty;
            try
            {
                var url = Driver.FindElement(By.CssSelector("[href*='online']")).GetAttribute("href");
                return url;
            }
            catch (StaleElementReferenceException staleElement)
            {
                Helper.MsgOutput("Error retrieving account validation url", staleElement.Message);
            }
            return string.Empty;
        }

        public void ForgetMeButtonClick()
        {
            IsForgetMeButtonAvailable();
            ForgetMeButton.Click();
        }

        public void BackToInboxButtonClick()
        {
            if (IsBackToInboxButtonAvailable())
            {
                BackToInboxButton.Click();
            }
            else
            {
               TestCheck.AssertIsEqual(true, IsBackToInboxButtonAvailable(), "Is back to inbox button available");
            }
        }

        public void SetEmailButtonClick()
        {
            SetEmailButton = Driver.FindElement(By.CssSelector("#inbox-id"));
            if (SetEmailButton == null)
            {
                throw new NullReferenceException("Unable to locate Email Set Button");
            }
            SetEmailButton.Click();
        }

        public void DeleteEmailButtonClick()
        {
            IsDeleteEmailButtonAvailable();
            DeleteEmailButton.Click();
            if (!WasEmailDeleted())
            {
                DeleteEmailButton.Click();
            }
            WebDriver.Wait(Helper.DurationType.Second, 2);
            TestCheck.AssertIsEqual(true, WasEmailDeleted(), "Validate Email Was Deleted");
        }

        private bool WasEmailDeleted()
        {
            var inBoxList = IsEmailListAvailable();
            var emailItems = inBoxList.FindElements(By.TagName("tr"));
           
            return emailItems[0].Text.ToLower().Contains("there are no emails present");
        }
    }
}