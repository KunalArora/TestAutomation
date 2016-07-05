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
    public static class MpsUserLogins
    {

        private const string GermanUrl = @"online.de";
        private const string AustriaUrl = @"online.at";
        private const string EnglandUrl = @"online.uk";
        private const string FranceUrl = @"online.fr";
        private const string SpainUrl = @"online.es";
        private const string ItalyUrl = @"online.it";
        private const string IrelandUrl = @"online.ie";
        private const string BelgiumUrl = @"online.be";
        private const string PolandUrl = @"online.it";
        private const string Denmark = @"online.dk";
        private const string Sweden = @"online.se";
        private const string Dutch = @"online.nl";
        private const string existingSerialNumber = @"A1T010001";
        private const string existingSerialNumberBIG = @"A1T010002";
        private const string existingSerialNumberAUT = @"A1T010003";


        public static string UsedSerialNumber(IWebDriver driver)
        {
            string serial = null;
            var currentUrl = CurrentUrl(driver);

            if (currentUrl.Contains(EnglandUrl))
            {
                serial = existingSerialNumber;
            }
            else if (currentUrl.Contains(GermanUrl))
            {
                serial = existingSerialNumberBIG;
            }
            else if (currentUrl.Contains(AustriaUrl))
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
                case "PROD":
                    dealerUser = MPSProd.Default.ProdMPSDealer;
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
                case "PROD":
                    pwd = MPSProd.Default.ProdDealerPassword;
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
                case "PROD":
                    BankUser = MPSProd.Default.ProdMPSBank;
                    break;
            }

            return BankUser;
        }

        private static string CustomerUsername(IWebDriver driver)
        {
            var username = "";

            var currentUrl = CurrentUrl(driver);

            if (currentUrl.Contains(GermanUrl))
            {
                username = MPSQAS.Default.QASDECustomer;

            } else if (currentUrl.Contains(AustriaUrl))
            {
                username = MPSQAS.Default.QASATCustomer;
            }
            else if(currentUrl.Contains(EnglandUrl))
            {
                username = MPSQAS.Default.QASUKCustomer;
            }
            else if (currentUrl.Contains(FranceUrl))
            {
                username = MPSQAS.Default.QASFRCustomer;
            }
            else if (currentUrl.Contains(SpainUrl))
            {
                username = MPSQAS.Default.QASESCustomer;
            }
            else if (currentUrl.Contains(ItalyUrl))
            {
                username = MPSQAS.Default.QASITCustomer;
            }
            else if (currentUrl.Contains(IrelandUrl))
            {
                username = MPSQAS.Default.QASIRCustomer;
            }
            else if (currentUrl.Contains(Sweden))
            {
                username = MPSQAS.Default.QASSECustomer;
            }
            else if (currentUrl.Contains(Dutch))
            {
                username = MPSQAS.Default.QASNLCustomer;
            }
            else if (currentUrl.Contains(Denmark))
            {
                username = MPSQAS.Default.QASDKCustomer;
            }
            return username;
        }

        private static string ServiceDeskCustomer()
        {
            var customer = "";

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    customer = MPSQAS.Default.QASMPSUKServiceDeskCustomer;
                    break;
            }
            return customer;
        }

        private static string ServiceDeskUser()
        {
            var customer = "";

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    customer = MPSQAS.Default.QASMPSServiceDesk;
                    break;

                case "DV2":
                    customer = MPSDV2.Default.DV2MPSServiceDesk;
                    break;
            }

            return customer;
        }

        private static string ServiceDeskUserPassword()
        {
            var pwd = "";

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    pwd = MPSQAS.Default.QASMPSServiceDeskPassword;
                    break;
                case "DV2":
                    pwd = MPSDV2.Default.DV2MPSServiceDeskPassword;
                    break;
            }
            return pwd;
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
                case "PROD":
                    pwd = MPSProd.Default.ProdBankPassword;
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
                case "PROD":
                    ApproverUser = MPSProd.Default.ProdMPSLOApprover;
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
                case "PROD":
                    pwd = MPSProd.Default.ProdLOApproverPassword;
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
                case "PROD":
                    AdminUser = MPSProd.Default.ProdMPSLOAdmin;
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
                case "PROD":
                    pwd = MPSProd.Default.ProdLOAdminPassword;
                    break;
            }

            return pwd;
        }

        
        public static string Username(string country, string userType, IWebDriver driver)
        {
            Helper.SetMpsCountryAbbreviation(country);

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
                case "Cloud MPS Service Desk":
                    finishedUsername = String.Format(ServiceDeskUser(), abbr);
                    break;
                case "Cloud MPS Customer" :
                    finishedUsername = CustomerUsername(driver);
                    break;
                case "Cloud MPS Service Desk Customer":
                    finishedUsername = ServiceDeskCustomer();
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
                
                case "Cloud MPS Service Desk":
                    finishPwd = ServiceDeskUserPassword();
                    finishPwd = String.Format(finishPwd, PasswordPrefix());
                    break;
                
                case "Cloud MPS Customer":
                    finishPwd = CustomerPassword();
                    break;
                
                case "Cloud MPS Service Desk Customer":
                    finishPwd = CustomerPassword();
                    break;
            }
            
            Helper.MsgOutput(String.Format("The password formed for {0} is {1}", userType, finishPwd));

            return finishPwd;
        }
        

        public static string PasswordPrefix()
        {
            var country = HelperClasses.SpecFlow.GetContext("CountryOfTest");
            var pre = Helper.Locale;
            switch (country)
            {
                case "Ireland":
                    pre = "IR";
                    break;
            }
            return pre.ToUpper();
        }
    }
}
