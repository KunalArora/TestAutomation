using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement;
using Brother.Tests.Selenium.Lib.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class LocalOfficeAdminSteps : BaseSteps
    {
        [Given(@"I enable Easy Print Pro contract")]
        public void GivenIEnableEasyPrintProContract()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToEasyPrintProPage();
            CurrentPage.As<EasyPrintProPage>().EnableContractType();
        }

        [Given(@"I navigate to Local Office Admin Dashboard page")]
        public void GivenINavigateToLocalOfficeAdminDashboardPage()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToLOAdminDashboard();
        }
    }
}
