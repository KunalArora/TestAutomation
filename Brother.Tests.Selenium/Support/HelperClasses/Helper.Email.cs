using System;
using System.Globalization;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class Email : Helper
    {
        public static string EmailSuffix { get; set; }
        private const string _AutoTestEmailPrefix = @"AutoTest_";
        public static string RegistrationEmailAddress { get; set; }
        private static string _emailDomain = "guerrillamail.com";
        private static string _AutoTestMaxEmailLengthPrefix = @"Maaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaax";
        public static string ForgottenPasswordEmailAddress { get; set; }

        public static string RegistrationEmailDomain
        {
            get { return _emailDomain; }
            set { _emailDomain = value; }
        }

        public static string AutoTestEmailPrefix
        {
            get { return _AutoTestEmailPrefix; }
        }

        public static string AutoTestMaxEmailLengthPrefix
        {
            get { return _AutoTestMaxEmailLengthPrefix; }
        }

        public static string CurrentEmailInUseForTest { get; set; }

        /// <summary>
        /// Generates a unique email address
        /// </summary>
        /// <returns>Generated Email address as string</returns>
        public static string GenerateUniqueEmailAddress()
        {
            string emailDomain;

            if (!CheckEmailPackage("MailinatorEmail"))
            {
                emailDomain = CheckEmailPackage("BrotherEmail") ? "@BrotherAutoTest.com" : "@Guerrillamail.com";
            }
            else
            {
                emailDomain = "@Mailinator.com";
            }


            // NEEDS A REGULAR EXPRESSION HERE!
            var emailDateTime =
                DateTime.Now.ToString(CultureInfo.InvariantCulture)
                    .Replace(@"/", "-")
                    .Replace(" ", "_")
                    .Replace(":", "-");
            EmailSuffix = String.Format("{0}{1}", AutoTestEmailPrefix, emailDateTime);
            var generatedEmailAddress = String.Format("{0}{1}{2}", AutoTestEmailPrefix, emailDateTime, emailDomain);
            RegistrationEmailAddress = generatedEmailAddress;
            RegistrationEmailDomain = emailDomain;
            return generatedEmailAddress;
        }

        public static string GenerateUniqueMaxLengthEmailAddress()
        {
            string emailDomain;

            if (!CheckEmailPackage("MailinatorEmail"))
            {
                emailDomain = CheckEmailPackage("BrotherEmail") ? "@BrotherAutoTest.com" : "@Guerrillamail.com";
            }
            else
            {
                emailDomain = "@Mailinator.com";
            }


            // NEEDS A REGULAR EXPRESSION HERE!
            var emailDateTime =
                DateTime.Now.ToString(CultureInfo.InvariantCulture)

                    .Replace(@"/", "-")
                    .Replace(" ", "_")
                    .Replace(":", "-");
            EmailSuffix = String.Format("{0}{1}", AutoTestMaxEmailLengthPrefix, emailDateTime);
            var generatedEmailAddress = String.Format("{0}{1}{2}", AutoTestMaxEmailLengthPrefix, emailDateTime, emailDomain);
            RegistrationEmailAddress = generatedEmailAddress;
            RegistrationEmailDomain = emailDomain;
            return generatedEmailAddress;
        }

        public static string GenerateUniqueCCEmailAddress()
        {
            string emailDomain;

            if (!CheckEmailPackage("MailinatorEmail"))
            {
                emailDomain = CheckEmailPackage("BrotherEmail") ? "@BrotherAutoTest.com" : "@Guerrillamail.com";
            }
            else
            {
                emailDomain = "@Mailinator.com";
            }


            // NEEDS A REGULAR EXPRESSION HERE!
            var emailDateTime =
                DateTime.Now.ToString(CultureInfo.InvariantCulture)

                    .Replace(@"/", "-")
                    .Replace(" ", "_")
                    .Replace(":", "-");
            EmailSuffix = String.Format("{0}{1}", AutoTestEmailPrefix, emailDateTime);
            var generatedEmailAddress = String.Format("{0}{1}{2}", AutoTestEmailPrefix, emailDateTime, emailDomain);
            RegistrationEmailAddress = generatedEmailAddress;
            RegistrationEmailDomain = emailDomain;
            return generatedEmailAddress;
        }

        public static bool SetEmailPackage(string emailPackage)
        {
            if (CheckEmailPackage(emailPackage))
            {
                return true;
            }

            Environment.SetEnvironmentVariable("AutoTestEmailClient", emailPackage, EnvironmentVariableTarget.Machine);
            return CheckEmailPackage(emailPackage);
        }

        public static bool CheckEmailPackage(string emailClient)
        {
            try
            {
                var emailClientSet = Environment.GetEnvironmentVariable("AutoTestEmailClient", EnvironmentVariableTarget.Machine);
                if (emailClientSet != null && emailClientSet.Equals(emailClient))
                {
                    return true;
                }
            }
            catch (ArgumentNullException noSuchEnvVar)
            {
                // If this environment variable is not present, do email check
                MsgOutput(string.Format("Unable to locate Email Environment setting [{0}]", noSuchEnvVar.Message));
                return true;
            }

            return false;
        }
    }
}
