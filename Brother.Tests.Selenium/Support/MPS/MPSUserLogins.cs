﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;

namespace Brother.Tests.Selenium.Lib.Support
{
    public static class MpsUserLogins
    {

        private const string GermanUrl = @"online65.de";
        private const string AustriaUrl = @"online65.at";
        private const string EnglandUrl = @"online65.uk";
        private const string FranceUrl = @"online65.fr";
        private const string SpainUrl = @"online65.es";
        private const string ItalyUrl = @"online65.it";
        private const string IrelandUrl = @"online65.ie";
        private const string BelgiumUrl = @"online65.be";
        private const string PolandUrl = @"online65.pl";
        private const string Denmark = @"online65.dk";
        private const string Sweden = @"online65.se";
        private const string Dutch = @"online65.nl";
        private const string Switzerland = @"online65.ch";
        private const string Finland = @"online65.fi";
        private const string Norway = @"online65.no";
        private const string ExistingSerialNumber = @"A1T010001";
        private const string ExistingSerialNumberBig = @"A1T010002";
        private const string ExistingSerialNumberAut = @"A1T010003";


        public static string UsedSerialNumber(IWebDriver driver)
        {
            string serial = null;
            var currentUrl = CurrentUrl(driver);

            if (currentUrl.Contains(EnglandUrl))
            {
                serial = ExistingSerialNumber;
            }
            else if (currentUrl.Contains(GermanUrl))
            {
                serial = ExistingSerialNumberBig;
            }
            else if (currentUrl.Contains(AustriaUrl))
            {
                serial = ExistingSerialNumberAut;
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


        public static string SuperUserUsername()
        {
            string superUser = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    superUser = MPSQAS.Default.QASMPSBIEAdmin;
                    break;
                case "TEST":
                    superUser = MPSDV2.Default.DV2MPSBIEAdmin;
                    break;
                case "PROD":
                    superUser = MPSProd.Default.ProdMPSBIEAdmin;
                    break;
            }

            return superUser;
        }

        public static string SuperUserPassword()
        {
            string pwd = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    pwd = MPSQAS.Default.QASMPSBIEPassword;
                    break;
                case "DV2":
                    pwd = MPSDV2.Default.DV2MPSBIEPassword;
                    break;
                case "PROD":
                    pwd = MPSProd.Default.ProdMPSBIEPassword;
                    break;
            }

            return pwd;
        }

        public static string BankUsername()
        {
            string bankUser = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    bankUser = MPSQAS.Default.QASMPSBank;
                    break;
                case "TEST":
                    bankUser = MPSDV2.Default.DV2MPSBank;
                    break;
                case "PROD":
                    bankUser = MPSProd.Default.ProdMPSBank;
                    break;
            }

            return bankUser;
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
            else if (currentUrl.Contains(BelgiumUrl))
            {
                username = MPSQAS.Default.QASBECustomer;
            }
            else if (currentUrl.Contains(PolandUrl))
            {
                username = MPSQAS.Default.QASPLCustomer;
            }
            else if (currentUrl.Contains(Switzerland))
            {
                username = MPSQAS.Default.QASCHCustomer;
            }
            else if (currentUrl.Contains(Finland))
            {
                username = MPSQAS.Default.QASFICustomer;
            }
            else if (currentUrl.Contains(Norway))
            {
                username = MPSQAS.Default.QASNOCustomer;
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

        private static string FinanceUser()
        {
            var finance = "";

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    finance = MPSQAS.Default.QASMPSFinance;
                    break;

                case "DV2":
                    finance = MPSDV2.Default.DV2MPSFinance;
                    break;
            }

            return finance;
        }

        private static string FinanceUserPassword()
        {
            var pwd = "";

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    pwd = MPSQAS.Default.QASMPSFinancePassword;
                    break;
                case "DV2":
                    pwd = MPSDV2.Default.DV2MPSFinancePassword;
                    break;
            }
            return pwd;
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
            string approverUser = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    approverUser = MPSQAS.Default.QASMPSLOApprover;
                    break;
                case "TEST":
                    approverUser = MPSDV2.Default.DV2MPSLOApprover;
                    break;
                case "PROD":
                    approverUser = MPSProd.Default.ProdMPSLOApprover;
                    break;

            }

            return approverUser;
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
            string adminUser = null;

            switch (Helper.GetRunTimeEnv())
            {
                case "UAT":
                    adminUser = MPSQAS.Default.QASMPSLOAdmin;
                    break;
                case "TEST":
                    adminUser = MPSDV2.Default.DV2MPSLOAdmin;
                    break;
                case "PROD":
                    adminUser = MPSProd.Default.ProdMPSLOAdmin;
                    break;

            }

            return adminUser;
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
                case "Cloud MPS Finance":
                    finishedUsername = String.Format(FinanceUser(), abbr);
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
                case "Cloud MPS BIE Admin":
                    finishedUsername = SuperUserUsername();
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

                case "Cloud MPS BIE Admin":
                    finishPwd = SuperUserPassword();
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
