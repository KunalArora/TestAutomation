using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.MPSTwo;

namespace Brother.Tests.Selenium.Lib.Support
{
    public class MPSUserLogins
    {


        public static string DealerUsername()
        {
            string dealerUser = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    dealerUser = Properties.MPSQAS.Default.QASMPSDealer;
                    break;
                case "TEST":
                    dealerUser = Properties.MPSDV2.Default.DV2MPSDealer;
                    break;
            }

            return dealerUser;
        }

        public static string DealerPassword()
        {
            string pwd = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT" :
                    pwd = Properties.MPSQAS.Default.QASDealerPassword;
                    break;
                case "DV2" :
                    pwd = Properties.MPSDV2.Default.DV2DealerPassword;
                    break;
            }

            return pwd;
        }


        public static string BankUsername()
        {
            string BankUser = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    BankUser = Properties.MPSQAS.Default.QASMPSBank;
                    break;
                case "TEST":
                    BankUser = Properties.MPSDV2.Default.DV2MPSBank;
                    break;
            }

            return BankUser;
        }

        public static string BankPassword()
        {
            string pwd = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    pwd = Properties.MPSQAS.Default.QASBankPassword;
                    break;
                case "DV2":
                    pwd = Properties.MPSDV2.Default.DV2BankPassword;
                    break;
            }

            return pwd;
        }

        public static string ApproverUsername()
        {
            string ApproverUser = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    ApproverUser = Properties.MPSQAS.Default.QASMPSLOApprover;
                    break;
                case "TEST":
                    ApproverUser = Properties.MPSDV2.Default.DV2MPSLOApprover;
                    break;
            }

            return ApproverUser;
        }

        public static string ApproverPassword()
        {
            string pwd = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    pwd = Properties.MPSQAS.Default.QASLOApproverPassword;
                    break;
                case "DV2":
                    pwd = Properties.MPSDV2.Default.DV2LOApproverPassword;
                    break;
            }

            return pwd;
        }

        public static string AdminUsername()
        {
            string AdminUser = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    AdminUser = Properties.MPSQAS.Default.QASMPSLOAdmin;
                    break;
                case "TEST":
                    AdminUser = Properties.MPSDV2.Default.DV2MPSLOAdmin;
                    break;
            }

            return AdminUser;
        }

        public static string AdminPassword()
        {
            string pwd = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    pwd = Properties.MPSQAS.Default.QASLOAdminPassword;
                    break;
                case "DV2":
                    pwd = Properties.MPSDV2.Default.DV2LOAdminPassword;
                    break;
            }

            return pwd;
        }

        public static string Username(string country, string userType)
        {
            Helper.SetMPSCountryAbbreviation(country);

            string finishedUsername = null;
            var abbr = Helper.Abbrev.ToUpper();

            switch (userType)
            {
                case "Cloud MPS Dealer" :
                    finishedUsername = String.Format(DealerUsername(), abbr);
                    break;

                case "Cloud MPS Bank":
                    finishedUsername = String.Format(BankUsername(), abbr);
                    break;

                case "Cloud MPS Local Office":
                    finishedUsername = String.Format(AdminUsername(), abbr);
                    break;

                case "Cloud MPS Local Office Approver":
                    finishedUsername = String.Format(ApproverUsername(), abbr);
                    break;
                case "Cloud MPS Customer" :
                    finishedUsername = MpsUtil.CreatedEmail();
                    break;

            }

            Helper.MsgOutput(String.Format("The username formed for {0} is {1}", country, finishedUsername));

            return finishedUsername;
        }


        public static string Password(string userType)
        {
            string finishPwd = null;
            

            switch (userType)
            {
                case "Cloud MPS Dealer" :
                    finishPwd = DealerPassword();
                    finishPwd = String.Format(finishPwd, PasswordPrefix());
                    break;

                case "Cloud MPS Bank" :
                    finishPwd = BankPassword();
                    finishPwd = String.Format(finishPwd, PasswordPrefix());
                    break;

                case "Cloud MPS Local Office":
                    finishPwd = AdminPassword();
                    finishPwd = String.Format(finishPwd, PasswordPrefix());
                    break;

                case "Cloud MPS Local Office Approver":
                    finishPwd = ApproverPassword();
                    finishPwd = String.Format(finishPwd, PasswordPrefix());
                    break;
                case "Cloud MPS Customer":
                    finishPwd = MPSJobRunnerPage.GetCustomerCreatedPassword(MpsUtil.CreatedEmail());
                    break;
            }

            
            Helper.MsgOutput(String.Format("The password formed for {0} is {1}", userType, finishPwd));

            return finishPwd;
        }
        

        public static string PasswordPrefix()
        {
            var pre = Helper.Locale;
            return pre.ToUpper();
        }


       


    }
}
