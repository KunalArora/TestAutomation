using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class Sql : Helper
    {

        /// <summary>
        /// GetSqlServer()
        /// 
        /// </summary>
        private static string GetSqlServer()
        {
            return GetRunTimeEnv() == "TEST" ? "PRDAT204V" : (GetRunTimeEnv() == "UAT" ? "PRDAT168V" : string.Empty);

            //else
            //{
            //    return Environment.GetEnvironmentVariable("COMPUTERNAME");
            //}
        }

        /// <summary>
        /// GetSqlConnection()
        /// 
        /// </summary>
        private static SqlConnection GetSqlConnection()
        {
            var server = GetSqlServer(); 
            MsgOutput(string.Format("SQL: Connecting to SQL Server [{0}]", server));
            //const string username = @"EU\EUSiteCoreTestAuto";
            const string username = @"AutoTestLocalUser";
            const string password = "@utoT3stL0c@lUs3r";
            //const string database = "Brother_MM_UserData";
            const string database = "Brother_UserData";

            var connectionString = "Data Source=" + server + ";";
            connectionString += "User ID=" + username + ";";
            connectionString += "Password=" + password + ";";
            connectionString += "Initial Catalog=" + database;

            MsgOutput(string.Format("SQL: SQL Connection string = [{0}]", connectionString));

            var sqlConnection = new SqlConnection();
            try
            {
                sqlConnection.ConnectionString = connectionString;
                sqlConnection.Open();
            }
            catch (SqlException sqlException)
            {
                MsgOutput(string.Format("Sql connection error - {0}", sqlException.Message));
                if (sqlConnection != null)
                    sqlConnection.Dispose();
            }
            return sqlConnection;
        }

        /// <summary>
        /// GetOrpDealerId()
        /// 
        /// </summary>
        public static Guid GetOrpDealerId(string emailAddress)
        {
            var sqlConnection = GetSqlConnection();
            var sql = string.Format("SELECT DealershipId FROM Dealership WHERE (Email = '{0}')", emailAddress);
            var sqlCmd = new SqlCommand(sql, sqlConnection);
            var dealershipId = Guid.Empty;

            using (sqlConnection)
            {
                using (var reader = sqlCmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (!reader.HasRows) return Guid.Empty;
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        dealershipId = reader.GetGuid(reader.GetOrdinal("DealershipId"));
                    }
                    reader.Close();
                }
            }
            sqlConnection.Close();
            return dealershipId;
        }

        /// <summary>
        /// GetCustomerBpid()
        /// 
        /// </summary>
        public static Guid GetCustomerBpid(string emailAddress)
        {
            var sqlConnection = GetSqlConnection();
            var sql = string.Format("SELECT DealershipId FROM Dealership WHERE (Email = '{0}')", emailAddress);
            var sqlCmd = new SqlCommand(sql, sqlConnection);
            var dealershipId = Guid.Empty;

            using (sqlConnection)
            {
                using (var reader = sqlCmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (!reader.HasRows) return Guid.Empty;
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        dealershipId = reader.GetGuid(reader.GetOrdinal("DealershipId"));
                    }
                    reader.Close();
                }
            }
            sqlConnection.Close();
            return dealershipId;
        }

        /// <summary>
        /// GetOrpActivationCode()
        /// 
        /// </summary>
        public static string GetOrpActivationCode(Guid dealershipId, int licenseTerm, int numLicenses, string comment)
        {
            var sqlConnection = GetSqlConnection();

            var sql = string.Format("SELECT ActivationCode, DealershipId, LicenceType, TermInMonths, DateActivated, DateCreated, NumberOfLicences, Comment FROM ActivationCode WHERE DealershipId = '{0}' AND (DateActivated IS NULL) AND (Comment ='{1}') ORDER BY DateCreated DESC", dealershipId, comment);

            var sqlCmd = new SqlCommand(sql, sqlConnection);
            var codeActivated = false;
            var activationCode = string.Empty;

            using (sqlConnection)
            {
                using (var reader = sqlCmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (!reader.HasRows) return "";
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        activationCode = reader.GetString(reader.GetOrdinal("ActivationCode"));
                        try
                        {
                            // Double check the code has not already been activated
                            var dateActivated = reader.GetDateTime(reader.GetOrdinal("DateActivated"));
                            codeActivated = true;
                        }
                        catch (SqlNullValueException fieldIsNull)
                        {
                            MsgOutput(string.Format("Activation code has not activated [{0}]", fieldIsNull));
                        }
                    }
                }
            }
            return !codeActivated ? activationCode : string.Empty;
        }
    }
}
