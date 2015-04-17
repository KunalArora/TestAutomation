using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace TestRunner
{
    static class TestRunner
    {
        [DllImport( "kernel32.dll" )]
        static extern bool AttachConsole( int dwProcessId );
        private const int ATTACH_PARENT_PROCESS = -1;
        public static bool InteractiveExecution = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] commandOptions)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);

            if (commandOptions.Length <= 0)
            {
                InteractiveExecution = true;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BrotherTestRunner());
            }
            else
            {
                if (!ProcessCommandLineOptions(commandOptions))
                {
                    Helper.MsgOutput("Invalid command line options - check and re-run");
                }

                SendKeys.SendWait("{ENTER}");
                Application.Exit();
            }
        }

        private static bool ProcessCommandLineOptions(string [] commandOptions)
        {
            Helper.MsgOutput("\n\n");
            Helper.MsgOutput("Running in command line mode...");
            Helper.MsgOutput("\n");

            foreach (var commandOption in commandOptions)
            {
                if (commandOption.Contains("RunTimeEnv"))
                {
                    var runTimeEnv = commandOption.Split('=');
                    if (runTimeEnv.Length == 2)
                    {
                        Helper.SetRunTimeEnv(runTimeEnv[1]);
                        Helper.MsgOutput(string.Format(@"Running tests on [{0}] Environment", runTimeEnv[1]));
                    }
                    else
                    {
                        Helper.MsgOutput(@"Missing parameter for Run Time Env");
                        return false;
                    }
                }

                if (commandOption.Contains("MailValidation"))
                {
                    var emailValidationPackage = commandOption.Split('=');
                    if (emailValidationPackage.Length == 2)
                    {
                        Email.SetEmailPackage(emailValidationPackage[1]);
                        Helper.MsgOutput(string.Format(@"Mail Validation = [{0}]", emailValidationPackage[1]));
                    }
                    else
                    {
                        Helper.MsgOutput(@"Missing parameter for Mail Validation");
                        return false;
                    }
                }

                if (commandOption.Contains("BrowserType"))
                {
                    var browserType = commandOption.Split('=');
                    if (browserType.Length == 2)
                    {
                        Brother.Tests.Selenium.Lib.Support.HelperClasses.WebDriver.SetBrowserType(browserType[1]);
                        Helper.MsgOutput(string.Format(@"Running in [{0}] mode", browserType[1]));
                    }
                    else
                    {
                        Helper.MsgOutput(@"Missing parameter for Browser Type");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
