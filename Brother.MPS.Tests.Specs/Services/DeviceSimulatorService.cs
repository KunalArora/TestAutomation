using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Domain.DeviceSimulator;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Brother.Tests.Specs.Services
{
    public class DeviceSimulatorService : IDeviceSimulatorService
    {
        private const string DEVICE_SIMULATOR_BASE_URL = "http://localhost:8080/bvd/device/{0}";
        private const string CREATE_NEW_DEVICE_PATTERN = "create?model={0}&serial={1}&id={2}";
        private const string DELETE_DEVICE_PATTERN = "delete?id={0}";
        private const string REGISTER_NEW_DEVICE_PATTERN = "register?id={0}&pin={1}";
        private const string CHANGE_DEVICE_STATUS_PATTERN = "status/change?id={0}&online={1}&subscribe={2}";
        private const string SET_SUPPLY_PATTERN = "supply/set";
        private const string GET_SUPPLY_PATTERN = "supply/get";
        private const string NOTIFY_BOC_PATTERN = "notify?id={0}&all=true";
        private const string DEVICE_ID_PATTERN = "babeface{0}";

        private readonly IWebRequestService _webRequestService;
        private readonly IRuntimeSettings _runtimeSettings;
        private IContextData _contextData;
        private readonly int _warningSec;

        private ILoggingService LoggingService { get; set; }

        public DeviceSimulatorService(IWebRequestService webRequestService, IRuntimeSettings runtimeSettings, ILoggingService loggingService, IContextData contextData )
        {
            _webRequestService = webRequestService;
            _runtimeSettings = runtimeSettings;
            LoggingService = loggingService;
            _contextData = contextData;
            _warningSec = runtimeSettings.DefaultDeviceSimulatorTimeout / 6;
        }

        /// <summary>
        /// Creates a new virtual device via the Device Simulator API
        /// </summary>
        /// <param name="model"></param>
        /// <param name="serialNumber"></param>
        /// <returns>Newly created device id</returns>
        public string CreateNewDevice(string model, string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(model, serialNumber);
            string deviceId = CreateNewDeviceId();
            string actionPath = string.Format(CREATE_NEW_DEVICE_PATTERN, model, serialNumber, deviceId);
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, actionPath);

            var response = LoggingService.WriteLogWhenWarningTimeoutExceeds( l => _webRequestService.GetPageResponse(url, "GET", _runtimeSettings.DefaultDeviceSimulatorTimeout), _warningSec ) ;

            _contextData.RegisteredDeviceIds.Add(deviceId);

            return deviceId;
        }

        /// <summary>
        /// Registers the specified device with BOC
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="installationPin"></param>
        public void RegisterNewDevice(string deviceId, string installationPin)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId, installationPin);
            string actionPath = string.Format(REGISTER_NEW_DEVICE_PATTERN, deviceId, installationPin);
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, actionPath);
            
            var response = LoggingService.WriteLogWhenWarningTimeoutExceeds( l => _webRequestService.GetPageResponse(url, "GET", _runtimeSettings.DefaultDeviceSimulatorTimeout), _warningSec );
        }

        /// <summary>
        /// Sets the status of the specified device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="online"></param>
        /// <param name="subscribe"></param>
        public void ChangeDeviceStatus(string deviceId, bool online, bool subscribe)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId, online, subscribe);
            string actionPath = string.Format(CHANGE_DEVICE_STATUS_PATTERN, deviceId, online.ToString().ToLower(), subscribe.ToString().ToLower());
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, actionPath);

            var response = LoggingService.WriteLogWhenWarningTimeoutExceeds( l => _webRequestService.GetPageResponse(url, "GET", _runtimeSettings.DefaultDeviceSimulatorTimeout), _warningSec);
        }

        public void NotifyBocOfDeviceChanges(string deviceId)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId);
            string actionPath = string.Format(NOTIFY_BOC_PATTERN, deviceId);
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, actionPath);

            var response = LoggingService.WriteLogWhenWarningTimeoutExceeds( l => _webRequestService.GetPageResponse(url, "GET", _runtimeSettings.DefaultDeviceSimulatorTimeout), _warningSec);            
        }

        public void SetPrintCounts(string deviceId, int monoPrintCount, int colourPrintCount)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId, monoPrintCount, colourPrintCount);
            var printCount = monoPrintCount + colourPrintCount;

            var setSupplyRequest = new SetSupplyRequest
            {
                id = deviceId,
                items = new List<SetSupplyRequestItem>
                {
                    new SetSupplyRequestItem {name = "PageCount", value = printCount},
                    new SetSupplyRequestItem {name = "PageCount_Mono", value = monoPrintCount},
                    new SetSupplyRequestItem {name = "PageCount_Color", value = colourPrintCount}
                }
            };

            LoggingService.WriteLog(LoggingLevel.DEBUG,"Setting print counts for device with id {0}: mono = {1}, colour = {2}", deviceId, monoPrintCount.ToString(), colourPrintCount.ToString());

            SetSupply(setSupplyRequest);
        }

        public void RaiseConsumableOrder(string deviceId, string tonerInkBlackStatus, string tonerInkCyanStatus, string tonerInkMagentaStatus, string tonerInkYellowStatus)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId, tonerInkBlackStatus, tonerInkCyanStatus, tonerInkMagentaStatus, tonerInkYellowStatus);
            var setSupplyRequest = new SetSupplyRequest
            {
                id = deviceId,
                items = new List<SetSupplyRequestItem>
                {
                    new SetSupplyRequestItem {name = "TonerInk_Black", value = tonerInkBlackStatus},
                    new SetSupplyRequestItem {name = "TonerInk_Cyan", value = tonerInkCyanStatus},
                    new SetSupplyRequestItem {name = "TonerInk_Magenta", value = tonerInkMagentaStatus},
                    new SetSupplyRequestItem {name = "TonerInk_Yellow", value = tonerInkYellowStatus}
                }

            };

            LoggingService.WriteLog(LoggingLevel.DEBUG, "Setting consumable order for device with id {0}: black = {1}, cyan = {2}, magenta = {3}, yellow = {4}", deviceId, tonerInkBlackStatus, tonerInkCyanStatus, tonerInkMagentaStatus, tonerInkYellowStatus);

            SetSupply(setSupplyRequest);
        }

        public void SetRemainingLife(string deviceId, string tonerInkBlackRemLife, string tonerInkCyanRemLife, string tonerInkMagentaRemLife, string tonerInkYellowRemLife)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId, tonerInkBlackRemLife, tonerInkCyanRemLife, tonerInkMagentaRemLife, tonerInkYellowRemLife);
            var setSupplyRequest = new SetSupplyRequest
            {
                id = deviceId,
                items = new List<SetSupplyRequestItem>
                {
                    new SetSupplyRequestItem {name = "TonerInk_Life_Black", value = tonerInkBlackRemLife},
                    new SetSupplyRequestItem {name = "TonerInk_Life_Cyan", value = tonerInkCyanRemLife},
                    new SetSupplyRequestItem {name = "TonerInk_Life_Magenta", value = tonerInkMagentaRemLife},
                    new SetSupplyRequestItem {name = "TonerInk_Life_Yellow", value = tonerInkYellowRemLife},
                }

            };

            LoggingService.WriteLog(LoggingLevel.DEBUG, "Setting remaining life for device with id {0}: blackRemLife = {1}, cyanRemLife = {2}, magentaRemLife = {3}, yellowRemLife = {4}",
                deviceId, tonerInkBlackRemLife, tonerInkCyanRemLife, tonerInkMagentaRemLife, tonerInkYellowRemLife);

            SetSupply(setSupplyRequest);
        }

        public void SetReplaceCount(string deviceId, string tonerInkBlackReplaceCount, string tonerInkCyanReplaceCount, string tonerInkMagentaReplaceCount, string tonerInkYellowReplaceCount)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId, tonerInkBlackReplaceCount, tonerInkCyanReplaceCount, tonerInkMagentaReplaceCount, tonerInkYellowReplaceCount);
            var setSupplyRequest = new SetSupplyRequest
            {
                id = deviceId,
                items = new List<SetSupplyRequestItem>
                {
                    new SetSupplyRequestItem {name = "TonerInk_ReplaceCount_Black", value = tonerInkBlackReplaceCount},
                    new SetSupplyRequestItem {name = "TonerInk_ReplaceCount_Cyan", value = tonerInkCyanReplaceCount},
                    new SetSupplyRequestItem {name = "TonerInk_ReplaceCount_Magenta", value = tonerInkMagentaReplaceCount},
                    new SetSupplyRequestItem {name = "TonerInk_ReplaceCount_Yellow", value = tonerInkYellowReplaceCount}
                }

            };

            LoggingService.WriteLog(LoggingLevel.DEBUG, "Setting replace count for device with id {0}: blackReplaceCount = {1}, cyanReplaceCount = {2}, magentaReplaceCount = {3}, yellowReplaceCount = {4}",
                deviceId, tonerInkBlackReplaceCount, tonerInkCyanReplaceCount, tonerInkMagentaReplaceCount, tonerInkYellowReplaceCount);

            SetSupply(setSupplyRequest);
        }

        public void RaiseServiceRequest(string deviceId, string laserUnitStatus, string fuserUnitStatus, string paperFeedingKit1Status, string paperFeedingKit2Status, string paperFeedingKit3Status)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId, laserUnitStatus, fuserUnitStatus, paperFeedingKit1Status, paperFeedingKit2Status, paperFeedingKit3Status);
            var setSupplyRequest = new SetSupplyRequest
            {
                id = deviceId,
                items = new List<SetSupplyRequestItem>
                {
                    new SetSupplyRequestItem {name = "LaserUnit", value = laserUnitStatus},
                    new SetSupplyRequestItem {name = "FuserUnit", value = fuserUnitStatus},
                    new SetSupplyRequestItem {name = "PaperFeedingKit1", value = paperFeedingKit1Status},
                    new SetSupplyRequestItem {name = "PaperFeedingKit2", value = paperFeedingKit2Status},
                    new SetSupplyRequestItem {name = "PaperFeedingKit3", value = paperFeedingKit3Status}
                }

            };

            LoggingService.WriteLog(LoggingLevel.DEBUG, "Setting service request for device with id {0}: laserUnit = {1}, fuserUnit = {2}, paperFeedingKit1 = {3}, paperFeedingKit2 = {4}, paperFeedingKit3 = {5}", deviceId, laserUnitStatus, fuserUnitStatus, paperFeedingKit1Status, paperFeedingKit2Status, paperFeedingKit3Status);

            SetSupply(setSupplyRequest);
        }

        public void SetSupply(SetSupplyRequest setSupplyRequest)
        {
            LoggingService.WriteLogOnMethodEntry(setSupplyRequest);
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, SET_SUPPLY_PATTERN);

            var json = JsonConvert.SerializeObject(setSupplyRequest);

            var response = LoggingService.WriteLogWhenWarningTimeoutExceeds( l => _webRequestService.GetPageResponse(url, "POST", _runtimeSettings.DefaultDeviceSimulatorTimeout, "application/json", json),_warningSec);
        }

        public string CreateNewDeviceId()
        {
            LoggingService.WriteLogOnMethodEntry();
            var guid = Guid.NewGuid().ToString();
            var deviceId = string.Format(DEVICE_ID_PATTERN, guid.Substring(8));

            LoggingService.WriteLog(LoggingLevel.DEBUG, "Device Simulators Guid set as {0}", deviceId);

            return deviceId;
        }

        /// <summary>
        /// Deletes an existing virtual device via the Device Simulator API
        /// Does not remove from BOC
        /// </summary>
        /// <param name="deviceId"></param>
        public void DeleteDevice(string deviceId)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId);
            string actionPath = string.Format(DELETE_DEVICE_PATTERN, deviceId);
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, actionPath);

            var response = LoggingService.WriteLogWhenWarningTimeoutExceeds(l => _webRequestService.GetPageResponse(url, "GET", _runtimeSettings.DefaultDeviceSimulatorTimeout), _warningSec);

        }


        public IEnumerable<BocSupplyItem> GetSupply( string deviceId)
        {
            LoggingService.WriteLogOnMethodEntry(deviceId);
            string url = string.Format(DEVICE_SIMULATOR_BASE_URL, GET_SUPPLY_PATTERN);

            var json = JsonConvert.SerializeObject(new Dictionary<string, object>()
            {
                {"id" ,deviceId},
                {"items", new string[]{
                     "TonerInk_Black",
                     "TonerInk_Cyan",
                     "TonerInk_Magenta",
                     "TonerInk_Yellow",
                     "TonerInk_Life_Black",
                     "TonerInk_Life_Cyan",
                     "TonerInk_Life_Magenta",
                     "TonerInk_Life_Yellow",
                     "TonerInk_ReplaceCount_Black",
                     "TonerInk_ReplaceCount_Cyan",
                     "TonerInk_ReplaceCount_Magenta",
                     "TonerInk_ReplaceCount_Yellow"}
                }
            });

            var response = LoggingService.WriteLogWhenWarningTimeoutExceeds(l => _webRequestService.GetPageResponse(url, "POST", _runtimeSettings.DefaultDeviceSimulatorTimeout, "application/json", json), _warningSec);
            var resJson = (BocResult<IEnumerable<BocSupplyItem>>)JsonConvert.DeserializeObject <BocResult<IEnumerable<BocSupplyItem>>>(response.ResponseBody);            
            Assert.True( resJson.success, "GetSupply({0}) error message={1}",deviceId,resJson.message);
            return resJson.results;
        }
    }
    
    class BocResult<T>
    {
        public string id { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public T results { get; set; }

    }
    public class BocSupplyItem
    {
        public string item { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public object value { get; set; } // string or int
    }

}
