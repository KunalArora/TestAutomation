﻿namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail : DealerSendSwapInstallationEmailPage, IPageObject
    {
        public static string _url = "/mps/local-office/manage-devices/send-swap-device-installation-email";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/manage-devices/send-swap-device-installation-email\"]";

        public new string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public new string PageUrl
        {
            get
            {
                return _url;
            }
        }

    }
}
