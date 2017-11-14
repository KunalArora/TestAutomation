
namespace Brother.WebSites.Core.Domain.Constants
{
    public class InstallationRequestStatus
    {
        public string NotSent
        {
            get
            {
                return "Not sent";
            }
        }
        public string NotStarted
        {
            get
            {
                return "Not started";
            }
        }
        public string Cancelled
        {
            get
            {
                return "Cancelled";
            }
        }
        public string InProcess
        {
            get
            {
                return "In-process";
            }
        }
    }
}
