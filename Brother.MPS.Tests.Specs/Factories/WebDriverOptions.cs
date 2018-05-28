using Brother.Tests.Selenium.Lib.Support;
namespace Brother.Tests.Specs.Factories
{
    public class WebDriverOptions
    {
        /// <summary>
        /// Culture for the remote driver instance
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Default download folder for the remote driver instance
        /// </summary>
        public string DownloadFolder { 
            get
            {
                return TestController.DownloadPath;
            }
            set
            {

            } 
        }
    }
}
