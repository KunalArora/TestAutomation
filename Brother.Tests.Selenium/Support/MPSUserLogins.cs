using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;

namespace Brother.Tests.Selenium.Lib.Support
{
    public class MPSUserLogins
    {

        private const string germanUrl = @"online.de";
        private const string austriaUrl = @"online.at";
        private const string englandUrl = @"online.uk";
        private const string franceUrl = @"online.fr";
        private const string existingSerialNumber = @"A1T010004";
        private const string existingSerialNumberBIG = @"A1T010005";
        private const string existingSerialNumberAUT = @"A1T010006";


        public static string UsedSerialNumber(IWebDriver driver)
        {
            string serial = null;
            var currentUrl = CurrentUrl(driver);

            if (currentUrl.Contains(englandUrl))
            {
                serial = existingSerialNumber;
            }
            else if (currentUrl.Contains(germanUrl))
            {
                serial = existingSerialNumberBIG;
            }
            else if (currentUrl.Contains(austriaUrl))
            {
                serial = existingSerialNumberAUT;
            }

            HelperClasses.SpecFlow.SetContext("SerialNumber", serial);

            return serial;
        }

        public static string DealerUsername()
        {
            string dealerUser = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    dealerUser = MPSQAS.Default.QASMPSDealer;
                    break;
                case "TEST":
                    dealerUser = MPSDV2.Default.DV2MPSDealer;
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
                    pwd = MPSQAS.Default.QASDealerPassword;
                    break;
                case "DV2" :
                    pwd = MPSDV2.Default.DV2DealerPassword;
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
                    BankUser = MPSQAS.Default.QASMPSBank;
                    break;
                case "TEST":
                    BankUser = MPSDV2.Default.DV2MPSBank;
                    break;
            }

            return BankUser;
        }

        public static string CustomerUsername(IWebDriver driver)
        {
            string username = null;
            var currentUrl = CurrentUrl(driver);

            if (currentUrl.Contains(germanUrl))
            {
                username = MPSQAS.Default.QASDECustomer;

            } else if (currentUrl.Contains(austriaUrl))
            {
                username = MPSQAS.Default.QASATCustomer;
            }
            else if(currentUrl.Contains(englandUrl))
            {
                username = MPSQAS.Default.QASUKCustomer;
            }

            return username;
        }

        private static string CurrentUrl(IWebDriver driver)
        {
            var currentUrl = driver.Url;
            return currentUrl;
        }

        public static string CustomerPassword()
        {
            return MPSQAS.Default.QASCustomerPassword;
        }

        public static string BankPassword()
        {
            string pwd = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    pwd = MPSQAS.Default.QASBankPassword;
                    break;
                case "DV2":
                    pwd = MPSDV2.Default.DV2BankPassword;
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
                    ApproverUser = MPSQAS.Default.QASMPSLOApprover;
                    break;
                case "TEST":
                    ApproverUser = MPSDV2.Default.DV2MPSLOApprover;
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
                    pwd = MPSQAS.Default.QASLOApproverPassword;
                    break;
                case "DV2":
                    pwd = MPSDV2.Default.DV2LOApproverPassword;
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
                    AdminUser = MPSQAS.Default.QASMPSLOAdmin;
                    break;
                case "TEST":
                    AdminUser = MPSDV2.Default.DV2MPSLOAdmin;
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
                    pwd = MPSQAS.Default.QASLOAdminPassword;
                    break;
                case "DV2":
                    pwd = MPSDV2.Default.DV2LOAdminPassword;
                    break;
            }

            return pwd;
        }

        
        public static string Username(string country, string userType, IWebDriver driver)
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
                    finishedUsername = CustomerUsername(driver);
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
                    finishPwd = CustomerPassword();
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
