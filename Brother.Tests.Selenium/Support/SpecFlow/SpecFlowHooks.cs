using System;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;

namespace Brother.Tests.Selenium.Lib.Support.SpecFlow
{
    [Binding]
    public class Initialise
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Helper.MsgOutput("Starting Test Run........");

            // Clear old snapshots
            Helper.MsgOutput("Purging old snapshots");
            Helper.PurgeSnapshots();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Helper.MsgOutput("........Ending Test Run");
        }

        [BeforeStep]
        public static void BeforeStep()
        {
            Helper.MsgOutput("Step start time ", DateTime.Now.TimeOfDay.ToString());
        }

        [AfterStep]
        public static void AfterStep()
        {
            if (ScenarioContext.Current.TestError == null)
            {
                return;
            }

            Helper.MsgOutput(string.Format("This step caused the following error [{0}]", ScenarioContext.Current.TestError.Message));
            Helper.TakeSnapshot();
            Helper.MsgOutput(string.Format("[AfterStep] SnapShot Taken : Location = [{0}]", Helper.CurrentSnapShot));
        }

        [BeforeFeature]
        public static void BeforeFeatureHeadless()
        {
            #if DEBUG
                BeforeFeatureHeadlessAndInteractive();
            #else
                TestController.HeadlessRunning();
            #endif
        }

        public static void BeforeFeatureHeadlessAndInteractive()
        {
            #if DEBUG
                TestController.Test_Setup();
                Helper.MsgOutput("Feature start - Starting Selenium");
            #endif
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Helper.MsgOutput("Feature end - Tearing Down");
            TestController.Test_Teardown();
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            var testRunTimeSetting = new NUnitRuntimeProvider();

            // First check the Runtime environment for a valid value
            if (!CheckForValidRunTimeEnv(Helper.GetRunTimeEnv()))
            {
                Helper.MsgOutput("Test could not be executed as the Run Time Environment is Invalid!");
                testRunTimeSetting.TestIgnore("Test skipped as Run Time Environment is Invalid!");
            }

            // Now check if this Scenario has Tagging present, and use this level in the first instance
            if ((ScenarioContext.Current.ScenarioInfo.Tags.Length > 0) && (!ScenarioContext.Current.ScenarioInfo.Tags.Contains("SMOKE")))
            {
                Helper.MsgOutput("Scenario Tags present - using these to determine Runtime Environment");

                // Use ScenarioContext override tag
                // if the run time environment does not match, do not run test
                if (!Helper.CheckScenarioEnv(Helper.GetRunTimeEnv()))
                {
                    Helper.MsgOutput(
                        "Test could not be executed as the Scenario Tags did not match Run Time Environment");
                    testRunTimeSetting.TestIgnore("Test skipped as Run Time Environment invalid for this test");
                }
            }
            else
            {
                switch (FeatureContext.Current.FeatureInfo.Tags.Length)
                {
                    case (0):
                        Helper.MsgOutput("NO Feature Tags present - skipping all Scenarios under this Feature");
                        testRunTimeSetting.TestIgnore("Test skipped as NO Feature Tags present");
                        break;

                    default:
                        if (!Helper.CheckFeatureEnv(Helper.GetRunTimeEnv()))
                        {
                            Helper.MsgOutput("Test could not be executed as the Run Time Environment did not match");
                            var provider = new NUnitRuntimeProvider();
                            provider.TestIgnore("Test skipped as Run Time Environment invalid for this test");
                        }
                        else
                        {
                            Helper.MsgOutput("Using Feature Tags to determine Runtime Environment");
                        }
                        break;
                }
            }

            if (Helper.IsSmokeTest())
            {
                if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("SMOKE"))
                {
                    Helper.MsgOutput("!!!!SMOKE TEST IN PROGRESS!!!!");
                }
                else
                {
                    Helper.MsgOutput("Skipping test for Smoke Test run");
                    testRunTimeSetting.TestIgnore("Test skipped as NO Smoke Tag present and this is a Smoke Test Run"); 
                }
            }

            if (!ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                ScenarioContext.Current.Add("CurrentDriver", TestController.CurrentDriver);
            }
            else
            {
                TestController.CurrentDriver = (IWebDriver)ScenarioContext.Current["CurrentDriver"];
            }
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                ScenarioContext.Current.Remove("CurrentDriver");
            }

            if (ScenarioContext.Current.TestError == null)
            {
                return;
            }

            // Close and re-launch current driver so we start the next test from a clean sheet
            Helper.MsgOutput("Scenario Failed! - Restarting Driver");
            WebDriver.ClearWebDriverPackage();
            TestController.Test_Teardown();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            BeforeFeatureHeadless();
        }

        private static bool CheckForValidRunTimeEnv(string runTimeEnv)
        {
            return (runTimeEnv.Equals(Helper.RunTimeLive)) || (runTimeEnv.Equals(Helper.RunTimeTest)) || (runTimeEnv.Equals(Helper.RunTimeUat)) || (runTimeEnv.Equals(Helper.RunTimeDev));
        }
    }
}
