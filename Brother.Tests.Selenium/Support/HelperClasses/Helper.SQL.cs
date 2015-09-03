using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class Sql : Helper
    {
        /// <summary>
        /// GetUserBpId()
        /// 
        /// In : String : Email Address
        /// Return: String : BpId of user
        /// </summary>
        public static string GetUserBpId(string emailAddress)
        {
            var userBpid = string.Empty;

            using (var brotherContext = new Brother_MM_UserDataEntities())
            {
                try
                {
                    var users = from usr in brotherContext.Users
                                where usr.Email.Equals(emailAddress)
                                select usr;
                    
                    foreach (var userAccount in users)
                    {
                        return userAccount.BusinessPartnerId;
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


        /// <summary>
        /// GetSqlServer()
        /// 
        /// </summary>
        private static string GetSqlServer()
        {
            // Note, there is no local access to the TEST or UAT SQL boxes. If you need to access SQL locally, you'll have to 
            // add your local host name and remove it when pushing to GitHub
            return GetRunTimeEnv() == "TEST" ? "PRDAT204V" : (GetRunTimeEnv() == "UAT" ? "PRDAT168V" : string.Empty);

            //else
            //{
            //    return Environment.GetEnvironmentVariable("COMPUTERNAME");
            //}
        }

        /// <summary>
        /// GetOrpDealerId()
        /// 
        /// </summary>
        public static string GetOrpDealerId(string emailAddress)
        {
            var userBpid = string.Empty;

            using (var brotherContext = new Brother_MM_UserDataEntities())
            {
                try
                {
                    var users = from usr in brotherContext.Users
                                where usr.Email.Equals(emailAddress)
                                select usr;
                    
                    foreach (var userAccount in users)
                    {
                        return userAccount.DealershipId;
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

        /// <summary>
        /// GetOrpActivationCode()
        /// 
        /// </summary>
    //    public static string GetOrpActivationCode(Guid dealershipId, int licenseTerm, int numLicenses, string comment)
    //    {
    //        var sqlConnection = GetSqlConnection();

    //        var sql = string.Format("SELECT ActivationCode, DealershipId, LicenceType, TermInMonths, DateActivated, DateCreated, NumberOfLicences, Comment FROM ActivationCode WHERE DealershipId = '{0}' AND (DateActivated IS NULL) AND (Comment ='{1}') ORDER BY DateCreated DESC", dealershipId, comment);

    //        var sqlCmd = new SqlCommand(sql, sqlConnection);

    //        var codeActivated = false;
    //        var activationCode = string.Empty;

    //        using (sqlConnection)
    //        {
    //            using (var reader = sqlCmd.ExecuteReader())
    //            {
    //                // Check is the reader has any rows at all before starting to read.
    //                if (!reader.HasRows) return "";
    //                // Read advances to the next row.
    //                while (reader.Read())
    //                {
    //                    activationCode = reader.GetString(reader.GetOrdinal("ActivationCode"));
    //                    try
    //                    {
    //                        // Double check the code has not already been activated
    //                        var dateActivated = reader.GetDateTime(reader.GetOrdinal("DateActivated"));
    //                        codeActivated = true;
    //                    }
    //                    catch (SqlNullValueException fieldIsNull)
    //                    {
    //                        MsgOutput(string.Format("Activation code has not activated [{0}]", fieldIsNull));
    //                    }
    //                }
    //            }
    //        }
    //        CloseSqlConnection(sqlConnection);
    //        return !codeActivated ? activationCode : string.Empty;
    //    }
    }
}
