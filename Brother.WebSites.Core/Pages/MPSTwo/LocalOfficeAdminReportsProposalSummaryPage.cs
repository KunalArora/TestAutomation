using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminReportsProposalSummaryPage : LocalOfficeApproverReportsProposalSummaryPage
    {
        private const string EditProposalNotesButtonSelector = ".js-mps-edit-proposal-notes";
        private const string NotesTextSelector = ".js-mps-proposal-notes-text.mps-proposal-notes-text-input";
        private const string ProposalNotesSelector = "#mps-proposal-notes";
        private const string NoteDescription = "This is a test note.";

        [FindsBy(How = How.CssSelector, Using = ".js-mps-proposal-notes-save")]
        public IWebElement SaveButtonElement;

        public void EditProposalNotes()
        {
            LoggingService.WriteLogOnMethodEntry();

            SeleniumHelper.ClickSafety(SeleniumHelper.FindElementByCssSelector(EditProposalNotesButtonSelector));
            var NotesTextElement = SeleniumHelper.FindElementByCssSelector(NotesTextSelector);
            ClearAndType(NotesTextElement, NoteDescription);
        }

        public bool VerifyProposalNotes()
        {
            LoggingService.WriteLogOnMethodEntry();

            var ProposalNotesElement = SeleniumHelper.FindElementByCssSelector(ProposalNotesSelector);
            if(!(ProposalNotesElement.Text.Contains(NoteDescription)))
            {
                return false;
            }
            return true;
        }
    }
}
