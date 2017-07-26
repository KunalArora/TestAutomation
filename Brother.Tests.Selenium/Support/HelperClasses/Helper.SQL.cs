using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class Sql : Helper
    {

        public static void SetDatabaseConnection()
        {
            var sqlServer = GetSqlServer();
            var connString = ConfigurationManager.ConnectionStrings["Brother_MM_UserDataEntities"].ConnectionString;

            var connectionStrings = connString.Split(';');
            var fullString = string.Empty; 

            foreach (var cString in connectionStrings)
            {

                if (cString.Contains("provider connection string"))
                {
                    var dbString = cString.Split('=');
                    var newString = string.Format("{0}={1}={2}", dbString[0], dbString[1], sqlServer);
                    fullString = fullString += newString;
                }
                else
                {
                    fullString = fullString += cString;
                }
            }

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["Brother_MM_UserDataEntities"].ConnectionString = fullString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

            
        }

        /// <summary>
        /// GetSqlServer()
        /// 
        /// </summary>
        private static string GetSqlServer()
        {
            // Note, there is no local access to the TEST or UAT SQL boxes. If you need to access SQL locally, you'll have to 
            // add your local host name and remove it when pushing to GitHub
            return GetRunTimeEnv() == "TEST" ? "PRDAT204V" : (GetRunTimeEnv() == "UAT" ? "PRDAT169V" : string.Empty);

            //else
            //{
            //    return Environment.GetEnvironmentVariable("COMPUTERNAME");
            //}
        }

        /// <summary>
        /// GetOrpDealerId()
        /// 
        /// </summary>
        public static Guid GetOrpDealerId(string emailAddress)
        {
            var dealerId = Guid.Empty;

            using (var brotherContext = new Brother_MM_UserDataEntities())
            {
                try
                {
                    var users = from usr in brotherContext.Users
                                where usr.Email.Equals(emailAddress)
                                select usr;
                    
                    foreach (var userAccount in users)
                    {
                        dealerId = new Guid(userAccount.DealershipId);
                        return dealerId;
                    }
                }
                catch (ArgumentException argument)
                {
                    Helper.MsgOutput(argument.Message);
                    if (argument.InnerException != null)
                    {
                        Helper.MsgOutput(argument.InnerException.Message);
                    }
                }
            }
            return Guid.Empty;
        }

        public static string GetOrpActivationCode(Guid dealerId)
        {

            using (var brotherContext = new Brother_MM_UserDataEntities())
            {
                try
                {
                    var activationCodes = from code in brotherContext.ActivationCodes
                                where code.DealershipId.Equals(dealerId)
                                select code;

                    foreach (var activationCode in activationCodes)
                    {
                        return activationCode.ActivationCode1;
                    }
                }
                catch (ArgumentException argument)
                {
                    Helper.MsgOutput(argument.Message);
                    if (argument.InnerException != null)
                    {
                        Helper.MsgOutput(argument.InnerException.Message);
                    }
                }
            }
            return string.Empty;
        }
    }
}
