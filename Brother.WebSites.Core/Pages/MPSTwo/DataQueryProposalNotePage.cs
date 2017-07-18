using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DataQueryProposalNotePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#content_0_NoteText")]
        public IWebElement NoteTextArea;
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonSave")]
        public IWebElement NoteSaveButton;



        public void EnterSomeNoteToTextArea()
        {
            if(NoteTextArea == null)
                throw new Exception("Comment box not found");

            ClearAndType(NoteTextArea, "Test Automation created this for testing purpose");
        }

        public void EnterSomeNoteToTextArea(string text)
        {
            if (NoteTextArea == null)
                throw new Exception("Comment box not found");

            ClearAndType(NoteTextArea, text);
        }

        public ReportProposalSummaryPage SaveTheNoteAdded()
        {
            if (NoteSaveButton == null)
                throw new Exception("Save button not found");

            NoteSaveButton.Click();

            return GetInstance<ReportProposalSummaryPage>();
        }
    }
}
