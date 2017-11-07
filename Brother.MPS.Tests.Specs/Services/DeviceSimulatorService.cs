using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Brother.Tests.Specs.Domain;

namespace Brother.Tests.Specs.Services
{
    public class DeviceSimulatorService : IDeviceSimulatorService
    {
        private const string DEVICE_SIMULATOR_BASE_URL = "http://localhost:8080/bvd/device/{0}";
        private const string CREATE_NEW_DEVICE_PATTERN = "create?model={0}&serial={1}&id={2}";
        private const string REGISTER_NEW_DEVICE_PATTERN = "register?id={0}&pin={1}";
        private const string CHANGE_DEVICE_STATUS_PATTERN = "status/change?id={0}&online={1}&subscribe={2}";
        private const string NOTIFY_BOC_PATTERN = "notify?id={0}&all=true";
        private const string DEVICE_ID_PATTERN = "babeface{0}";

        private readonly IWebRequestService _webRequestService;

        public DeviceSimulatorService(IWebRequestService webRequestService)
        {
            _webRequestService = webRequestService;
        }

        /// <summary>
        /// Creates a new virtual device via the Device Simulator API
        /// </summary>
        /// <param name="model"></param>
        /// <param name="serialNumber"></param>
        /// <returns>Newly created device id</returns>
        public string CreateNewDevice(string model, string serialNumber)
        {
            string deviceId = CreateNewDeviceId();
            string actionPath = string.Format(CREATE_NEW_DEVICE_PATTERN, model, serialNumber, deviceId);
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, actionPath);

            var response = _webRequestService.GetPageResponse(url, "GET", 10);

            return deviceId;
        }

        /// <summary>
        /// Registers the specified device with BOC
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="installationPin"></param>
        public void RegisterNewDevice(string deviceId, string installationPin)
        {
            string actionPath = string.Format(REGISTER_NEW_DEVICE_PATTERN, deviceId, installationPin);
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, actionPath);

            var response = _webRequestService.GetPageResponse(url, "GET", 10);
        }

        /// <summary>
        /// Sets the status of the specified device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="online"></param>
        /// <param name="subscribe"></param>
        public void ChangeDeviceStatus(string deviceId, bool online, bool subscribe)
        {
            string actionPath = string.Format(CHANGE_DEVICE_STATUS_PATTERN, deviceId, online.ToString().ToLower(), subscribe.ToString().ToLower());
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, actionPath);

            var response = _webRequestService.GetPageResponse(url, "GET", 10);
        }

        public void NotifyBocOfDeviceChanges(string deviceId)
        {
            string actionPath = string.Format(NOTIFY_BOC_PATTERN, deviceId);
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, actionPath);

            var response = _webRequestService.GetPageResponse(url, "GET", 10);            
        }

        public string CreateNewDeviceId()
        {
            var guid = Guid.NewGuid().ToString();
            var deviceId = string.Format(DEVICE_ID_PATTERN, guid.Substring(8));

            Console.WriteLine("Device Simulators Guid set as {0}", deviceId);

            return deviceId;
        }


    }
}
